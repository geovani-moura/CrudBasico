using CrudBasico.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBasico.Core.DB
{
	internal class LogDB : BaseDB
	{

		internal int Inserir(LogEntity entity)
		{
			string query = @"
				INSERT INTO 
					TB_LOG (LogText, LogDate) 
				VALUES 
					(@LogText, GETDATE())
			";
			List<SqlParameter> parametroColecao = new List<SqlParameter> {
				new SqlParameter("@LogText ", entity.LogText)
			};
			return Create(query, parametroColecao);
		}

		internal List<LogEntity> Listar()
		{
			List<LogEntity> retorno = new List<LogEntity>();
			string query = @"
				SELECT
					Id,
					LogText,
					LogDate
				FROM
					TB_LOG
				WHERE
					CONVERT(DATE, LogDate) >= CONVERT(DATE, GETDATE()) 
				ORDER BY
					Id DESC
			";
			var dataTable = Reads(query);
			if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					retorno.Add(new LogEntity()
					{
						Id = Convert.ToInt32(row["Id"]),
						LogText = Convert.ToString(row["LogText"]),
						LogDate = Convert.ToDateTime(row["LogDate"])
					});
				}
			}
			return retorno;
		}
	}
}
