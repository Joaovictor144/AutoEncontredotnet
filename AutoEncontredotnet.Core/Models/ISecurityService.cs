using System;
namespace AutoEncontredotnet.Core.Models
{
	public interface ISecurityService
	{

        public bool ComparePassword(string password, string hashPassword);

        public string EcnryptPassword(string password);

    }
}

