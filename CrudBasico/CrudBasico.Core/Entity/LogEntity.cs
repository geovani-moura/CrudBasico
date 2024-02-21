using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBasico.Core.Entity
{
	public class LogEntity
	{
        public int Id { get; set; }
        public string LogText { get; set; }
        public DateTime LogDate { get; set; }
    }
}
