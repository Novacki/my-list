using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Identity.Services.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IdentityResult> RegisterUserAsync(IdentityUser identityUser, string password)
        {
            return await _userManager.CreateAsync(identityUser, password);
        }

        public async Task<IdentityResult> RegisterUserAsync(IdentityUser identityUser)
        {
            return await _userManager.CreateAsync(identityUser);
        }

        public async Task<SignInResult> SignInAsync(string email, string password, bool isPersistent = false, bool lockoutOnFailure = true)
        {
            return await _signInManager.PasswordSignInAsync(email, password, isPersistent, lockoutOnFailure);
        }
    }
}
