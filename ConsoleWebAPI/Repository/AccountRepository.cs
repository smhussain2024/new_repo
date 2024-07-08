using ConsoleWebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ConsoleWebAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IdentityResult> SignUp(SignUpModel signUpModel)
        {
            var user = new ApplicationUser
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.FirstName + "-" + signUpModel.LastName
            };

            return await _userManager.CreateAsync(user, signUpModel.Password);
        }
    }
}
