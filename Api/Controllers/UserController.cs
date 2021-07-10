﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<UserView>> Login([FromBody] string mail, [FromBody] string pass)
        {
            if (!ModelState.IsValid) return null;
            User u = await userManager.FindByEmailAsync(mail);
            if (u == null) return null;
            await signInManager.SignOutAsync();
            Microsoft.AspNetCore.Identity.SignInResult x = await signInManager.PasswordSignInAsync(u, pass, false, false);
            if (x.Succeeded)
            {
                return new UserView(u);
            }
            return null;
        }

        [HttpPost]
        [Route("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return null;
        }
    }
}
