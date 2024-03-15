using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoEncontredotnet.Core.Models;
using AutoEncontredotnet.Core.Services;
using AutoEncontredotnet.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoEncontredotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly ISecurityService _securityService = new SecurityService();

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            var user = _userRepository.Verify(username);

            if (user == null)
            {
                return NotFound();
            }

            var passwordCrypt = _securityService.ComparePassword(password, user.Password);

            if (passwordCrypt)
            {
                return Unauthorized("username or password invalid");
            }

            var token = TokenService.GenerateToken(user);

            return Ok(token);

        }
    }
}

