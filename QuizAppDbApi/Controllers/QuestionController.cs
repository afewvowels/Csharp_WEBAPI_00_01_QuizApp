using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAppDbApi.Models;

namespace QuizAppDbApi.Controllers
{
  [Route("api/questions")]
  [ApiController]
  public class QuestionController : ControllerBase
  {
    private readonly QuizAppDbContext _context;

    public QuestionController(QuizAppDbContext context)
    {
      _context = context;

      if(_context.Qa_questions.Count() == 0)
      {
        _context.Qa_questions.Add(new qa_questions
        {
          qa_questions_class_key = 1,
          qa_questions_lesson_key = 1,
          qa_questions_question = "question",
          qa_questions_answer_1 = "A",
          qa_questions_answer_2 = "B",
          qa_questions_answer_3 = "C",
          qa_questions_answer_4 = "D",
          qa_questions_answer_5 = "E",
          qa_questions_correct = 0,
          qa_questions_incorrect = 0,
        });
        _context.SaveChanges();
      }
    }

    [HttpGet(Name = "GetQuestionsInfo")]
    public async Task<ActionResult<IEnumerable<qa_questions>>> GetQuestionsInfo()
    {
      return await _context.Qa_questions.ToListAsync();
    }

    [HttpGet("{pk}", Name = "GetQuestionInfo")]
    public async Task<ActionResult<qa_questions>> GetQuestionInfo(int pk)
    {
      var questionInfo = await _context.Qa_questions.FindAsync(pk);

      if (questionInfo == null)
      {
        return NotFound();
      }

      return questionInfo;
    }

    [HttpPost]
    public async Task<ActionResult<qa_questions>> PostQuestionInfo(qa_questions questionInfo)
    {
      _context.Qa_questions.Add(questionInfo);
      await _context.SaveChangesAsync();

      //return CreatedAtAction(nameof(GetStudentInfo), new
      //{
      //  qa_users_name = studentInfo.qa_users_name,
      //  qa_users_pass = studentInfo.qa_users_pass,
      //  qa_users_email = studentInfo.qa_users_email,
      //  qa_users_score = studentInfo.qa_users_score
      //}, studentInfo);

      return CreatedAtAction("GetQuestionsInfo", questionInfo, null);
    }

    [HttpPut("{pk}")]
    public async Task<IActionResult> PutQuestionInfo(int pk, qa_questions questionInfo)
    {
      if (pk != questionInfo.qa_questions_pk)
      {
        return BadRequest();
      }

      _context.Entry(questionInfo).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpDelete("{pk}")]
    public async Task<IActionResult> DeleteQuestionInfo(int pk)
    {
      var questionInfo = await _context.Qa_questions.FindAsync(pk);

      if (questionInfo == null)
      {
        return NotFound();
      }

      _context.Qa_questions.Remove(questionInfo);
      await _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
