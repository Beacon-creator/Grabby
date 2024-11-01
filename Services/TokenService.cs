using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Grabby_Two.EventHandlers
    {
    public class TokenService
        {
        private const string TokenKey = "jwt_token";
        private readonly string? _secretKey;


        // Save the token asynchronously using SecureStorage
        public static async Task SaveTokenAsync(string token)
            {
            await SecureStorage.SetAsync(TokenKey, token);
            }

        // Retrieve the token synchronously
        public static async Task<string> GetTokenAsync()
            {
            var token = await SecureStorage.GetAsync(TokenKey);
            if (string.IsNullOrEmpty(token))
                {
                throw new Exception("Token not found in storage.");
                }
            return token;
            }


        // Optionally, if needed, you could add a method to remove the token from storage
        public static async Task RemoveTokenAsync()
            {
            await SecureStorage.SetAsync(TokenKey, string.Empty); // Or use RemoveAsync if available
            }

        // Generate JWT token based on userId and email
        public string GenerateToken(string userId, string email)
            {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
                {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // Return the generated token as a string
            }


        public static bool IsTokenExpired(string token)
            {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            return jwtToken.ValidTo < DateTime.UtcNow;
            }



        // Validate JWT token
        public ClaimsPrincipal? ValidateToken(string token)
            {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            try
                {
                var validationParameters = new TokenValidationParameters
                    {
                    ValidateIssuerSigningKey = true, // Ensure the token was signed with the correct secret
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Use the same secret key to validate
                    ValidateIssuer = false, // Issuer validation is not required in this case
                    ValidateAudience = false, // Audience validation is not required in this case
                    ValidateLifetime = true, // Ensure the token has not expired
                    ClockSkew = TimeSpan.Zero // Remove clock skew for token expiration
                    };

                // Validate the token and return the claims
                var claims = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return claims;
                }
            catch (SecurityTokenExpiredException)
                {
               
                return null;
                }
            catch (SecurityTokenException) { 
         
                return null;
                }
            catch (Exception)
                {
     
                return null;
                }
            }
        }


    }
