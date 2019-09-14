using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAppDbApi.Models;

namespace QuizAppDbApi.Controllers
{
  [Route("api/students")]
  [ApiController]
  public class StudentController : ControllerBase
  {
    private readonly QuizAppDbContext _context;

    public StudentController(QuizAppDbContext context)
    {
      _context = context;

      if(_context.Qa_users.Count() == 0)
      {
        _context.Qa_users.Add(new qa_users
        {
          qa_users_email = "email@email.com",
          qa_users_name = "name",
          qa_users_pass = "pass",
          qa_users_score = 1
        });
        _context.SaveChanges();
      }
    }

    [HttpGet(Name = "GetStudentsInfo")]
    public async Task<ActionResult<IEnumerable<qa_users>>> GetStudentsInfo()
    {
      return await _context.Qa_users.ToListAsync();
    }

    [HttpGet("{pk}", Name = "GetStudentInfo")]
    public async Task<ActionResult<qa_users>> GetStudentInfo(int pk)
    {
      var studentInfo = await _context.Qa_users.FindAsync(pk);

      if (studentInfo == null)
      {
        return NotFound();
      }

      return studentInfo;
    }

    [HttpPost]
    public async Task<ActionResult<qa_users>> PostStudentInfo(qa_users studentInfo)
    {
      _context.Qa_users.Add(studentInfo);
      await _context.SaveChangesAsync();

      //return CreatedAtAction(nameof(GetStudentInfo), new
      //{
      //  qa_users_name = studentInfo.qa_users_name,
      //  qa_users_pass = studentInfo.qa_users_pass,
      //  qa_users_email = studentInfo.qa_users_email,
      //  qa_users_score = studentInfo.qa_users_score
      //}, studentInfo);

      return CreatedAtAction("GetStudentsInfo", studentInfo, null);
    }
  }
}
