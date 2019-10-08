using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAppDbApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAppDbApi.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly QuizAppDbContext _context;

		public UserController(QuizAppDbContext context)
		{
			_context = context;

			if (_context.Qa_users.Count() == 0)
			{
				_context.Qa_users.Add(new qa_users
				{
					qa_users_class_key = 0,
					qa_users_name = "name",
					qa_users_login = "login",
					qa_users_pass = "pass",
					qa_users_email = "email@email.com",
					qa_users_score = 1,
					qa_users_correct = 0,
					qa_users_incorrect = 0,
					qa_users_isadmin = false
				});
				_context.SaveChanges();
			}
		}

		[HttpGet(Name = "GetUsersInfo")]
		public async Task<ActionResult<IEnumerable<qa_users>>> GetUsersInfo()
		{
			return await _context.Qa_users.ToListAsync();
		}

		[HttpGet("{pk}", Name = "GetUserInfo")]
		public async Task<ActionResult<qa_users>> GetUserInfo(int pk)
		{
			var userInfo = await _context.Qa_users.FindAsync(pk);

			if (userInfo == null)
			{
				return NotFound();
			}

			return userInfo;
		}

		[HttpPost]
		public async Task<ActionResult<qa_users>> PostUserInfo(qa_users userInfo)
		{
			if (await IsLoginUniqueAsync(Convert.ToChar(userInfo.qa_users_login)))
			{
				_context.Qa_users.Add(userInfo);
				await _context.SaveChangesAsync();
				return CreatedAtAction("GetUsersInfo", userInfo, null);
			}
			else
			{
				return NotFound();
			}

		}

		[HttpPut("{pk}")]
		public async Task<IActionResult> PutUserInfo(int pk, qa_users userInfo)
		{
			if (Convert.ToInt32(pk) != userInfo.qa_users_pk)
			{
				return BadRequest();
			}

			_context.Entry(userInfo).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

		[HttpDelete("{pk}")]
		public async Task<IActionResult> DeleteUserInfo(int pk)
		{
			var userInfo = await _context.Qa_users.FindAsync(pk);

			if (userInfo == null)
			{
				return NotFound();
			}

			_context.Qa_users.Remove(userInfo);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private async Task<bool> IsLoginUniqueAsync(char login)
		{
			Boolean isValid = false;

			var checkLogin = await _context.Qa_users.FindAsync(login);

			foreach (char dbLogin in checkLogin.qa_users_login)
			{
				if (login == dbLogin)
				{
					isValid = false;
					break;
				}
				else
				{
					isValid = true;
				}
			}

			return isValid;
		}
	}
}
