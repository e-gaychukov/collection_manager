using CollectionManager.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CollectionManager.Controllers
{
    public class Utils
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly UserManager<IdentityUser> _userManger;
        private readonly SignInManager<IdentityUser> _signInManager;

        public Utils(ApplicationDbContext applicationContext,
                     UserManager<IdentityUser> userManager,
                     SignInManager<IdentityUser> signInManager)
        {
            _applicationContext = applicationContext;
            _userManger = userManager;
            _signInManager = signInManager;
        }

      
    }
}
