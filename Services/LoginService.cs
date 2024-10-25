using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Grabby_Two.Model;
using Grabby_Two.Services;

public class LoginService : ILoginService
    {
    private readonly HttpClient _httpClient;

    public LoginService(HttpClient httpClient)
        {
        _httpClient = httpClient;

        // Set base URL for your API if not already set
        if (_httpClient.BaseAddress == null)
            {
            _httpClient.BaseAddress = new Uri("https://grabbyfanalapi.onrender.com/"); // Adjust base URL if necessary
            }
        }

    public async Task<User?> Login(string email, string password)
        {
        var loginModel = new
            {
            Email = email,
            Password = password
            };

        try
            {
            var response = await _httpClient.PostAsJsonAsync("api/login", loginModel);

            if (response.IsSuccessStatusCode)
                {
                // Deserialize the response content into a User object
                var user = await response.Content.ReadFromJsonAsync<User>();
                return user;
                }
            else
                {
                // Handle login failure
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login failed: {error}");
                return null;
                }
            }
        catch (HttpRequestException ex)
            {
            Console.WriteLine($"Request error: {ex.Message}");
            return null;
            }
        }
    }
