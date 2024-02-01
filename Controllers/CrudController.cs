using EntertainmentDB.Models;
using EntertainmentDB.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentDB.Controllers;

public abstract class CrudController<TEntity>(ICrudService<TEntity> entityService) : ControllerBase where TEntity : class, IEntity<Guid>
{
    protected readonly ICrudService<TEntity> entityService = entityService;

    [HttpGet]
    public virtual ActionResult<IEnumerable<TEntity>> Get()
    {
        return Ok(entityService.GetAll());
    }

    [HttpGet("{id}")]
    public virtual ActionResult<TEntity> Get(Guid id)
    {
        var entity = entityService.GetById(id);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public virtual IActionResult Put(Guid id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        try
        {
            entityService.Update(entity);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TEntityExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public virtual ActionResult<TEntity> Post(TEntity entity)
    {
        entityService.Insert(entity);

        return CreatedAtAction("Get", new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public virtual IActionResult Delete(Guid id)
    {
        var entity = entityService.GetById(id);

        if (entity == null)
        {
            return NotFound();
        }

        entityService.Delete(entity);

        return NoContent();
    }

    protected virtual bool TEntityExists(Guid id)
    {
        return entityService.GetById(id) != null;
    }
}
