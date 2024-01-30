using EntertainmentDB.DAL;
using EntertainmentDB.Data;
using EntertainmentDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EntertainmentDB.Models;
using EntertainmentDB.JWTBearerConfig;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Load local settings
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(connectionString)
);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddScoped(typeof(ICrudService<>), typeof(CrudService<>));

// configure strongly typed settings objects
var jwtSection = builder.Configuration.GetSection("JWTBearerTokenSettings");

builder.Services.Configure<JWTBearerTokenSettings>(jwtSection);

var jwtBearerTokenSettings = jwtSection.Get<JWTBearerTokenSettings>() ?? new();
var key = System.Text.Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);

builder.Services.AddAuthentication(
        options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    )
    .AddJwtBearer(
        options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.Authority = jwtBearerTokenSettings.Authority;
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidIssuer = jwtBearerTokenSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtBearerTokenSettings.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
