using test_projekt.Entities;
using test_projekt.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace test_projekt.Services.Users
{
    public class UserServiceImpl : IUserService
    {
        private IConfiguration configuration;
        private string connString;

        public UserServiceImpl(IConfiguration configuration)
        {
            this.configuration = configuration;
            //this.connectionString = "Server=db; Database=projekt; Uid=root; Pwd=;";
            this.connString = configuration["connetionString"];
        }

        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            User user = GetByUsername(request.Username);
            if (user == null || user.Password != request.Password)
            {
                return null;
            }
            string token = GenerateJwtToken(user);
            return new AuthenticationResponse(user, token);
        }

        public User GetById(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User();
                        user.Id = reader.GetInt32("Id");
                        user.Username = reader.GetString("Username");
                        user.Password = reader.GetString("Password");
                        user.Roles = GetUserRoles(user.Id);
                        return user;
                    }
                }
            }
            return null;
        }

        public User GetByUsername(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE Username = @Username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User();
                        user.Id = reader.GetInt32("Id");
                        user.Username = reader.GetString("Username");
                        user.Password = reader.GetString("Password");
                        user.Roles = GetUserRoles(user.Id);
                        return user;
                    }
                }
            }
            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            List<User> userList = new List<User>();
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "SELECT * FROM users";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Id = reader.GetInt32("Id");
                        user.Username = reader.GetString("Username");
                        user.Password = reader.GetString("Password");
                        user.Roles = GetUserRoles(user.Id);
                        userList.Add(user);
                    }
                }
            }
            return userList;
        }

        public List<Role> GetUserRoles(int userId)
        {
            List<Role> roles = new List<Role>();
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();
                string query = "SELECT r.* FROM role AS r INNER JOIN userroles AS ur ON r.Id = ur.role_id WHERE ur.users_id = @UserId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Role role = new Role();
                        role.Id = reader.GetInt32("Id");
                        role.Role_ = reader.GetString("Role_");
                        roles.Add(role);
                    }
                }
            }
            return roles;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"]);
            var claims = new List<Claim>();
            claims.Add(new Claim("id", user.Id.ToString()));
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role_));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
