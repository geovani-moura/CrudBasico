using CrudBasico.Core.DB;
using CrudBasico.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBasico.Core.NG
{
	public class LogNG
	{
		public void Inserir(string log)
		{
			var logEntity = new LogEntity()
			{
				LogText = log
			};
			new LogDB().Inserir(logEntity);
		}

		public List<LogEntity> Listar()
		{
			return new LogDB().Listar();
		}
	}
}
