using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grabby_Two.Model
{
    public interface IEmailVerificationService
    {
        Task<bool> VerifyEmailAsync(string emailAddress);
    }

    public class VerificationCodeGenerator
    {
        public static string GenerateCode()
        {
            // Generate a random verification code (you can customize this logic)
            return Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
        }
    }

    public static class VerificationCodeGenerator1
    {
        private static readonly Random random = new Random();

        public static string GenerateCode()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            const int codeLength = 6;

            // Generate a random verification code with the specified length
            string code = new string(Enumerable.Repeat(characters, codeLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return code;
        }
    }


    public class EmailService
    {
        public static void SendVerificationEmail(string emailAddress, string verificationCode)
        {
            // Implement your email sending logic here
            // This could involve using an SMTP server, a third-party email service, or any other method you prefer
            // For demonstration purposes, let's print the details to the console
            Console.WriteLine($"Sending verification email to: {emailAddress}");
            Console.WriteLine($"Verification code: {verificationCode}");
        }
    }
    public class VerificationService
    {
        public static bool VerifyCode(string emailAddress, string userEnteredCode)
        {
            // Implement your server-side logic to validate the code
            // Retrieve the stored verification code for the given email address
            // Compare it with the user-entered code
            // Return true if the codes match; otherwise, return false
            // You may also want to implement expiration checks for security
            return true; // Placeholder, replace with your logic
        }
    }


}
