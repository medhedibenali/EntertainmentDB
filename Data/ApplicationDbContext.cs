using Microsoft.EntityFrameworkCore;

namespace EntertainmentDB.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

}
