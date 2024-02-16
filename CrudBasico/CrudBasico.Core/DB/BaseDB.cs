using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBasico.Core.DB
{
	internal class BaseDB
	{
		private readonly string connectionString;

		public BaseDB(string connectionString = null)
		{
			this.connectionString = connectionString ?? ConfigurationManager.ConnectionStrings["Teste123"].ConnectionString; ;
		}

		public int Create(string query, List<SqlParameter> sqlParameters = null)
		{
			var idRetorno = 0;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.Add(sqlParameters);
					command.ExecuteNonQuery();

					// Recuperar o ID do registro inserido
					command.CommandText = "SELECT SCOPE_IDENTITY()";
					idRetorno = Convert.ToInt32(command.ExecuteScalar());
				}
			}
			catch (Exception ex)
			{
				//Fazer nada ou guardar um log
			}

			return idRetorno;
		}

		public DataTable Reads(string query, List<SqlParameter> sqlParameters = null)
		{
			DataTable dataTable = null;

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.Add(sqlParameters);

					SqlDataAdapter adapter = new SqlDataAdapter(command);
					adapter.Fill(dataTable);
				}
			}
			catch (Exception ex)
			{
				//Fazer nada ou guardar um log
			}

			return dataTable;
		}

		public DataRow Read(string query, List<SqlParameter> sqlParameters = null)
		{
			DataTable dataTable = null;
			DataRow dataRow = null;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.Add(sqlParameters);

					SqlDataAdapter adapter = new SqlDataAdapter(command);
					adapter.Fill(dataTable);
					if (dataTable.Rows.Count > 0)
					{
						dataRow = dataTable.Rows[0];
					}
				}
			}
			catch (Exception ex)
			{
				//Fazer nada ou guardar um log
			}

			return dataRow;
		}

		public bool Update(string query, List<SqlParameter> sqlParameters = null)
		{
			DataTable dataTable = new DataTable();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.Add(sqlParameters);
					command.ExecuteNonQuery();
				}
				return true;
			}
			catch (Exception ex)
			{
				//Fazer nada ou guardar um log
				return false;
			}
		}

		public bool Delete(string query, List<SqlParameter> sqlParameters = null)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					command.Parameters.Add(sqlParameters);
					command.ExecuteNonQuery();
				}
				return true;
			}
			catch (Exception ex)
			{
				//Fazer nada ou guardar um log
				return false;
			}
		}
	}
}
