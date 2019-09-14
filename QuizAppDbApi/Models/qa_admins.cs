using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAppDbApi.Models
{
  public class qa_admins
  {
    [Key]
    public int qa_admin_pk { get; set; }
    public string qa_admin_login { get; set; }
    public string qa_admin_password { get; set; }
  }
}
