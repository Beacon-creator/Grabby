using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;


namespace Grabby_Two.Model
{
    public class JwtService
        {
        public string? GetEmailFromToken(string token)
            {
            try
                {
                var handler = new JwtSecurityTokenHandler();

                if (!handler.CanReadToken(token))
                    {
                    Console.WriteLine("Invalid JWT token format.");
                    return null;
                    }

                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    {
                    Console.WriteLine("Failed to read JWT token.");
                    return null;
                    }

                // Log token claims for debugging
                foreach (var claim in jwtToken.Claims)
                    {
                    Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
                    }

                // Extract the email claim using the "sub" claim type
                var emailClaim = jwtToken.Claims.FirstOrDefault(claim =>
                    claim.Type == JwtRegisteredClaimNames.Sub);

                if (emailClaim == null)
                    {
                    Console.WriteLine("Email claim not found in the JWT token.");
                    return null;
                    }

                return emailClaim.Value;
                }
            catch (ArgumentException ex)
                {
                Console.WriteLine($"Argument Exception: {ex.Message}");
                }
            catch (SecurityTokenExpiredException ex)
                {
                Console.WriteLine($"Token Expired Exception: {ex.Message}");
                }
            catch (SecurityTokenInvalidSignatureException ex)
                {
                Console.WriteLine($"Invalid Signature Exception: {ex.Message}");
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error parsing token: {ex.Message}");
                }

            return null;
            }
        }
    }
