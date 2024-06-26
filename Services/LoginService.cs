using Grabby_Two.Model;
using System.Net.Http.Json;

namespace Grabby_Two.Services
{

    //adding api, this is the action when method is called
    public class LoginService : ILoginService
    {
        public async Task<User> Login(string email, string password)
        {
            _ = new User();
            var client = new HttpClient();
            string url = "http://localhost:5240/api/User/" + email + "/" + password;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                User user = await response.Content.ReadFromJsonAsync<User>();
                return await Task.FromResult(user!);
            }
            return null!;
        }
    }
}
