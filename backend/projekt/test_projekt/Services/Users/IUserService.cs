using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_projekt.Entities;
using test_projekt.Model;

namespace test_projekt.Services.Users
{
	public interface IUserService
	{
		AuthenticationResponse Authenticate(AuthenticationRequest request);
		IEnumerable<User> GetUsers();
		User GetByUsername(string username);
		User GetById(int id);
		List<Role> GetUserRoles(int userId);

	}
}
