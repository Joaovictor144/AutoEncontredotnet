using System;
using AutoEncontredotnet.Entities;

namespace AutoEncontredotnet.Models
{
	public interface IUserRepository
	{
        public void Add(User user);

        User Verify(string username);

    }
}

