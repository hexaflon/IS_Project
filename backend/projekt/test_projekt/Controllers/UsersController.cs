using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_projekt.Model;
using test_projekt.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

namespace test_projekt.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController
	{
		private IUserService userService;

		public UsersController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpPost("authenticate")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Authenticate(AuthenticationRequest request)
		{
			var response = userService.Authenticate(request);
			if (response == null) return new BadRequestObjectResult(new { message = "Username or password is incorrect" });
			return new OkObjectResult(response);
		}

        [HttpGet("menu")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Menu()
        {
			return new OkObjectResult(userService.GetUsers());
        }

		[HttpGet("getall")]
		[Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public IActionResult GetAllUsers()
		{
			return new OkObjectResult(userService.GetUsers());
		}
        [HttpPost("getroles")]
		[Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public IActionResult getuserroles(int userId)
        {
			return new OkObjectResult(userService.GetUserRoles(userId));
		}

		[HttpGet("count")]
		[Authorize(Roles = "user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public IActionResult GetCount()
		{
			return new OkObjectResult(new { userCount = userService.GetUsers().Count() });
		}

		[HttpGet("prime")]
		[Authorize(Roles = "number", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public IActionResult GetNumber()
		{
			int[] primes = { 2, 3, 5, 7, 11, 13 };
			int idx = RandomNumberGenerator.GetInt32(primes.Length);
			return new OkObjectResult(new { number = primes[idx] });
		}
	}
}
