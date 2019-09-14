using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAppDbApi.Models;

namespace QuizAppDbApi.Controllers
{
  [Route("api/teachers")]
  [ApiController]
  public class TeacherController : ControllerBase
  {
    private readonly QuizAppDbContext _context;

    public TeacherController(QuizAppDbContext context)
    {
      _context = context;

      if(_context.Qa_admins.Count() == 0)
      {
        _context.Qa_admins.Add(new qa_admins
        {
          qa_admin_login = "admin1",
          qa_admin_password = "pass"
        });
        _context.SaveChanges();
      }
    }

    [HttpGet(Name = "GetTeachersInfo")]
    public async Task<ActionResult<IEnumerable<qa_admins>>> GetTeachersInfo()
    {
      return await _context.Qa_admins.ToListAsync();
    }

    [HttpGet("{pk}", Name = "GetTeacherInfo")]
    public async Task<ActionResult<qa_admins>> GetTeacherInfo(int pk)
    {
      var teacherInfo = await _context.Qa_admins.FindAsync(pk);

      if (teacherInfo == null)
      {
        return NotFound();
      }

      return teacherInfo;
    }

    [HttpPost]
    public async Task<ActionResult<qa_users>> PostStudentInfo(qa_admins teacherInfo)
    {
      _context.Qa_admins.Add(teacherInfo);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTeachersInfo", teacherInfo, null);
    }
  }
}
