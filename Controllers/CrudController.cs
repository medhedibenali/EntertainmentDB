using EntertainmentDB.Models;
using EntertainmentDB.Services.Crud;
using EntertainmentDB.Services.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntertainmentDB.Controllers;

public abstract class CrudController<TEntity, TEntityInput>(ICrudService<TEntity> entityService, IMappingService<TEntity, TEntityInput> mappingService) : ControllerBase
    where TEntity : class, IEntity<Guid>
    where TEntityInput : class
{
    protected readonly ICrudService<TEntity> entityService = entityService;
    protected readonly IMappingService<TEntity, TEntityInput> mappingService = mappingService;

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
    public virtual IActionResult Put(Guid id, TEntityInput entityInput)
    {
        try
        {
            TEntity entity = mappingService.Map(entityInput);
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
    public virtual ActionResult<TEntity> Post(TEntityInput entityInput)
    {
        TEntity entity = mappingService.Map(entityInput);
        entityService.Insert(entity);

        return CreatedAtAction("Get", new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
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
