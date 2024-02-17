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
		internal int Inserir(ClienteEntity cliente)
		{
			string query = @"
				INSERT INTO 
					TB_CLIENTE (Nome) 
				VALUES 
					(@Nome)
			";
			List<SqlParameter> parametroColecao = new List<SqlParameter> {
				new SqlParameter("@Nome ", cliente.Nome),
			};
			return Create(query, parametroColecao);
		}

		internal ClienteEntity Obter(int Id)
		{
			ClienteEntity retorno = null;
			string query = @"
				SELECT
					Id,
					Nome
				FROM
					TB_CLIENTE
				WHERE
					Id = @Id
			";
			List<SqlParameter> parametroColecao = new List<SqlParameter> {
				new SqlParameter("@Id ", Id),
			};
			var row = Read(query, parametroColecao);
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

		internal List<ClienteEntity> Listar()
		{
			List<ClienteEntity> retorno = new List<ClienteEntity>();
			string query = @"
				SELECT
					Id,
					Nome
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

		internal bool Atualizar(ClienteEntity cliente)
		{
			string query = @"
				UPDATE TB_Cliente
					SET Nome = @Nome
				WHERE
					Id = @Id
			";
			List<SqlParameter> parametroColecao = new List<SqlParameter> {
				new SqlParameter("@Id ", cliente.Id),
				new SqlParameter("@Nome ", cliente.Nome),
			};
			return Update(query, parametroColecao);
		}

		internal bool Delete(int Id)
		{
			string query = @"
				DELETE FROM 
					TB_Cliente
				WHERE
					Id = @Id
			";
			List<SqlParameter> parametroColecao = new List<SqlParameter> {
				new SqlParameter("@Id ", Id),
			};
			return Delete(query, parametroColecao);
		}
	}
}
