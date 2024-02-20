using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudBasico.Models
{
	public class LogModel
	{
		public int Id { get; set; }
		public string LogText { get; set; }
        public DateTime LogDate { get; set; }
    }
}