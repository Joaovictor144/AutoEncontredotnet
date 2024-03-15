using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoEncontredotnet.Entities;
using AutoEncontredotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using AutoEncontredotnet.Core.Models;
using AutoEncontredotnet.Core.Services;





namespace AutoEncontredotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        private readonly ISecurityService _securityService = new SecurityService();

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User data)
        {
            var passwordCrypt = _securityService.EcnryptPassword(data.Password);


            var user = new User(data.Name, data.Username, passwordCrypt, data.PhoneNumber, data.PermissionId, data.StoreId);

            _userRepository.Add(user);

            return Ok();
        }
    }
}

