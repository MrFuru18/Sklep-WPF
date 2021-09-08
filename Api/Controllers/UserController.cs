using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Microsoft.AspNetCore.Authorization;
using Api.Model.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Api.Controllers
{
    [ApiController]
    [Route("User")]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly DB db;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public UserController(ILogger<UserController> logger, DB dbContext, UserManager<User> userMgr, SignInManager<User> signMgr)
        {
            _logger = logger;
            db = dbContext;
            userManager = userMgr;
            signInManager = signMgr;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserView>> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return new BadRequestResult();
            User u = await userManager.FindByEmailAsync(loginModel.email);
            if (u == null) return new EmptyResult();
            await signInManager.SignOutAsync();
            Microsoft.AspNetCore.Identity.SignInResult x = await signInManager.PasswordSignInAsync(u, loginModel.password, false, false);
            if (x.Succeeded)
            {
                return new UserView(u);
            }
            return new EmptyResult();
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IdentityResult> Register(RegisterModel model)
        {
            User u = new()
            {
                imie = model.firstName,
                UserName = model.email,
                nazwisko = model.lastName,
                Email = model.email,
                PhoneNumber=model.phoneNumber
            };
            IdentityResult r = await userManager.CreateAsync(u, model.password);
            return r;
        }

        [HttpGet]
        [Route("Logout")]
        [Authorize]
        public async void Logout()
        {
            await signInManager.SignOutAsync();
        }

    }
}
