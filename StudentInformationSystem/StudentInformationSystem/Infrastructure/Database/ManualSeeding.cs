using Microsoft.AspNetCore.Identity;
using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Infrastructure.Database
{
    public class ManualSeeding
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStudent _student;
        public ManualSeeding(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            //RoleManager<IdentityRole> roleManager
            IStudent student
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _student = student;

        }
       
        public async Task<bool> ManualSeedingMethod()
        {
            var data =await _student.GetAllAsync();
            if (data is not null)
            {
                foreach (var item in data)
                {
                    User user = new User()
                    {
                        Email = item.Email,
                        UserName = item.UserName,

                    };
                    string? email = await _userManager.GetEmailAsync(user);
                    //if (string.IsNullOrEmpty(email))
                    //{
                        var result = await _userManager.CreateAsync(user, item.Password);
                    //}
                }
                return true;
            }
            return false;
        }
    }
}
