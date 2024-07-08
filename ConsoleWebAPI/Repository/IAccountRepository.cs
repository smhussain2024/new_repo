using ConsoleWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ConsoleWebAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUp(SignUpModel signUpModel);
    }
}
