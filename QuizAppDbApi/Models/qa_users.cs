using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAppDbApi.Models
{
  public class qa_users
  {
    [Key]
    public int qa_users_pk { get; set; }
    public string qa_users_name { get; set; }
    public string qa_users_pass { get; set; }
    public string qa_users_email { get; set; }
    public int qa_users_score { get; set; }
  }
}
