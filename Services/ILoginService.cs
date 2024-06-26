//it is an interface
using Grabby_Two.Model;

namespace Grabby_Two.Services;

public interface ILoginService
{
    Task<User> Login(string email, string password);
}
