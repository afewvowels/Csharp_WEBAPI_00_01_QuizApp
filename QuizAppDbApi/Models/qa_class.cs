using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizAppDbApi.Models
{
  public class qa_class
  {
    [Key]
    public int qa_class_pk { get; set; }
    public string qa_class_title { get; set; }
    public string qa_class_description { get; set; }
  }
}
