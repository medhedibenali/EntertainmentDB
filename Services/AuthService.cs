using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using EntertainmentDB.Exceptions;
using EntertainmentDB.JWTBearerConfig;
using EntertainmentDB.Models;
using EntertainmentDB.RequestModels;

namespace EntertainmentDB.Services;

public class AuthService(UserManager<ApplicationUser> userManager, IOptions<JWTBearerTokenSettings> jwtTokenOptions) : IAuthService
{
    private readonly UserManager<ApplicationUser> userManager = userManager;
    private readonly JWTBearerTokenSettings jwtBearerTokenSettings = jwtTokenOptions.Value;

    public async Task Register(RegisterCredentials credentials)
    {
        var user = new ApplicationUser()
        {
            UserName = credentials.Username,
        };

        var result = await userManager.CreateAsync(user, credentials.Password);

        if (!result.Succeeded)
        {
            var dictionary = new Dictionary<string, string>();

            foreach (IdentityError error in result.Errors)
            {
                dictionary.Add(error.Code, error.Description);
            }

            throw new AuthException("Login Failed")
            {
                Errors = dictionary
            };
        }
    }

    public async Task<string> Login(LoginCredentials credentials)
    {
        ApplicationUser? user = await ValidateUser(credentials) ?? throw new ArgumentException("Login failed");

        return await GenerateToken(user);
    }

    private async Task<ApplicationUser?> ValidateUser(LoginCredentials credentials)
    {
        var user = await userManager.FindByNameAsync(credentials.Username);

        if (user == null)
        {
            return null;
        }

        var result = userManager.PasswordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash ?? "",
            credentials.Password
        );

        return result == PasswordVerificationResult.Failed ? null : user;
    }

    private async Task<string> GenerateToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(jwtBearerTokenSettings.SecretKey);
        var claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, user.Id),
            new (ClaimTypes.Name, user.UserName ?? ""),
        };

        var roles = await userManager.GetRolesAsync(user);

        foreach (var role in roles)
        {
            claims.Add(new(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new(claims),
            Expires = DateTime.UtcNow.AddSeconds(jwtBearerTokenSettings.ExpireTimeInSeconds),
            SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            Audience = jwtBearerTokenSettings.Audience,
            Issuer = jwtBearerTokenSettings.Issuer,

        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
