using System;
using AutoEncontredotnet.Entities;
using AutoEncontredotnet.Database;
using AutoEncontredotnet.Models;

namespace AutoEncontredotnet.Database.Repositories
{
	public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context;

        public UserRepository(ConnectionContext context)
		{
            _context = context;
        }

		public void Add(User user)
		{
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar no banco de dados: " + ex.InnerException.Message);
                transaction.Rollback();
            }
        }

        public User Verify(string username)
        {
            var user = _context.Users.FirstOrDefault(d => d.Username == username);

            return user;
        }
	}
}

