using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAppDbApi.Models;

namespace QuizAppDbApi.Controllers
{
  [Route("api/class")]
  [ApiController]
  public class ClassController : ControllerBase
  {
    private readonly QuizAppDbContext _context;

    public ClassController(QuizAppDbContext context)
    {
      _context = context;

      if(_context.Qa_class.Count() == 0)
      {
        _context.Qa_class.Add(new qa_class
        {
          qa_class_title = "intro 101",
          qa_class_description = "this is your first class"
        });
        _context.SaveChanges();
      }
    }

    [HttpGet(Name = "GetClassesInfo")]
    public async Task<ActionResult<IEnumerable<qa_class>>> GetClassesInfo()
    {
      return await _context.Qa_class.ToListAsync();
    }

    [HttpGet("{pk}", Name = "GetClassInfo")]
    public async Task<ActionResult<qa_class>> GetClassInfo(int pk)
    {
      var classInfo = await _context.Qa_class.FindAsync(pk);

      if (classInfo == null)
      {
        return NotFound();
      }

      return classInfo;
    }

    [HttpPost]
    public async Task<ActionResult<qa_questions>> PostStudentInfo(qa_class classInfo)
    {
      _context.Qa_class.Add(classInfo);
      await _context.SaveChangesAsync();

      //return CreatedAtAction(nameof(GetStudentInfo), new
      //{
      //  qa_users_name = studentInfo.qa_users_name,
      //  qa_users_pass = studentInfo.qa_users_pass,
      //  qa_users_email = studentInfo.qa_users_email,
      //  qa_users_score = studentInfo.qa_users_score
      //}, studentInfo);

      return CreatedAtAction("GetClassesInfo", classInfo, null);
    }
  }
}
