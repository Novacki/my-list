using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Identity.Services.Interfaces
{
    public interface IIdentityService
    {
        public Task<IdentityResult> RegisterUserAsync(IdentityUser identityUser);
        public Task<IdentityResult> RegisterUserAsync(IdentityUser identityUser, string password);
        public Task<SignInResult> SignInAsync(string email, string password, bool isPersistent = false, bool lockoutOnFailure = true);
    }
}
