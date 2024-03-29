﻿using System.ComponentModel.DataAnnotations;

namespace QuizAppDbApi.Models
{
	public class qa_users
	{
		[Key]
		public int qa_users_pk { get; set; }
		public int qa_users_class_key { get; set; }
		public string qa_users_name { get; set; }
		public string qa_users_login { get; set; }
		public string qa_users_pass { get; set; }
		[EmailAddress]
		public string qa_users_email { get; set; }
		public int qa_users_score { get; set; }
		public int qa_users_correct { get; set; }
		public int qa_users_incorrect { get; set; }
		public bool qa_users_isadmin { get; set; }
	}
}
