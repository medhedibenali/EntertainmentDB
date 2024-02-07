using EntertainmentDB.DAL;
using EntertainmentDB.Data;
using EntertainmentDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EntertainmentDB.Models;
using EntertainmentDB.JWTBearerConfig;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EntertainmentDB.Services.Mapping;
using EntertainmentDB.RequestModels;
using System.Text.Json.Serialization;
using EntertainmentDB.Services.Crud;

var builder = WebApplication.CreateBuilder(args);

// Load local settings
builder.Configuration.AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

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

builder.Services
    .AddScoped(typeof(IRepository<>), typeof(Repository<>))
    .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));

builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IRoleService), typeof(RoleService));

builder.Services
    .AddScoped(typeof(ICrudService<>), typeof(CrudService<>))
    .AddScoped(typeof(ICrudService<Book>), typeof(BookCrudService))
    .AddScoped(typeof(ICrudService<Game>), typeof(GameCrudService))
    .AddScoped(typeof(ICrudService<Movie>), typeof(MovieCrudService))
    .AddScoped(typeof(ICrudService<Track>), typeof(TrackCrudService))
    .AddScoped(typeof(ICrudService<Show>), typeof(ShowCrudService))
    .AddScoped(typeof(ICrudService<Season>), typeof(SeasonCrudService))
    .AddScoped(typeof(ICrudService<Episode>), typeof(EpisodeCrudService))
    .AddScoped(typeof(ICrudService<Tag>), typeof(TagCrudService))
    .AddScoped(typeof(ICrudService<Person>), typeof(PersonCrudService));

builder.Services
    .AddScoped(typeof(IMappingService<,>), typeof(MappingService<,>))
    .AddScoped(typeof(IMappingService<Book, BookInput>), typeof(BookMappingService))
    .AddScoped(typeof(IMappingService<Game, GameInput>), typeof(GameMappingService))
    .AddScoped(typeof(IMappingService<Movie, MovieInput>), typeof(MovieMappingService))
    .AddScoped(typeof(IMappingService<Track, TrackInput>), typeof(TrackMappingService))
    .AddScoped(typeof(IMappingService<Show, ShowInput>), typeof(ShowMappingService))
    .AddScoped(typeof(IMappingService<Season, SeasonInput>), typeof(SeasonMappingService))
    .AddScoped(typeof(IMappingService<Episode, EpisodeInput>), typeof(EpisodeMappingService))
    .AddScoped(typeof(IMappingService<Tag, TagInput>), typeof(TagMappingService))
    .AddScoped(typeof(IMappingService<Person, PersonInput>), typeof(PersonMappingService));

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
