using System;
using AutoEncontredotnet.Core.Models;

namespace AutoEncontredotnet.Core.Services
{
	public class SecurityService : ISecurityService
    {
		public bool ComparePassword(string password, string hashPassword)
		{
            var passwordConfirm = BCrypt.Net.BCrypt.Equals(password, hashPassword);

            return passwordConfirm;

        }

        public string EcnryptPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            return passwordHash;
        }
    }
}

