using CrudBasico.Core.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CrudBasico.Core.DB.ClienteDB;

namespace CrudBasico.Core.DB
{
	internal class ClienteDB : BaseDB
	{
		public int Inserir(ClienteEntity cliente)
		{
			string query = @"
				INSERT INTO 
					TB_CLIENTE (Nome) 
				VALUES 
					(@Nome)
			";
			List<SqlParameter> parameters = new List<SqlParameter> {
				new SqlParameter("@Nome ", cliente.Nome),
			};

			return Create(query, parameters);
		}

		public ClienteEntity Obter(int Id)
		{
			ClienteEntity retorno = null;
			string query = @"
				SELECT
					*
				FROM
					TB_CLIENTE
				WHERE
					Id = @Id
			";
			List<SqlParameter> parameters = new List<SqlParameter> {
				new SqlParameter("@Id ", Id),
			};
			var row = Read(query, parameters);
			if(row != null)
			{
				retorno = new ClienteEntity()
				{
					Id = Convert.ToInt32(row["Id"]),
					Nome = Convert.ToString(row["Nome"]),
				};
			}
			return retorno;
		}

		public List<ClienteEntity> Listar()
		{
			List<ClienteEntity> retorno = new List<ClienteEntity>();
			string query = @"
				SELECT
					*
				FROM
					TB_CLIENTE
			";
			var dataTable = Reads(query);
			if (dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					retorno.Add(new ClienteEntity()
					{
						Id = Convert.ToInt32(row["Id"]),
						Nome = Convert.ToString(row["Nome"]),
					});
				}
			}
			return retorno;
		}
	}
}
