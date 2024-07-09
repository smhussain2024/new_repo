using ConsoleWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ConsoleWebAPI.Repository
{
    public interface IAccountRepository
    {
        Task<string> LoginAsync(SignInModel signInModel);
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    }
}
