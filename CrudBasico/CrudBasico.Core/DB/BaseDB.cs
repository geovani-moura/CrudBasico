﻿using CrudBasico.Core.NG;
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
			this.connectionString = connectionString ?? ConfigurationManager.ConnectionStrings["Teste123"].ConnectionString;
		}

		public int Create(string query, List<SqlParameter> sqlParameters = null)
		{
			var idRetorno = 0;
			query += " SELECT SCOPE_IDENTITY();";
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();

					SqlCommand command = new SqlCommand(query, connection);
					if (sqlParameters != null)
					{
						command.Parameters.Clear();
						foreach (SqlParameter param in sqlParameters)
						{
							command.Parameters.Add(param);
						}
					}
					idRetorno = Convert.ToInt32(command.ExecuteScalar());
				}
			}
			catch (Exception ex)
			{
				new LogNG().Inserir(ex.ToString());
			}

			return idRetorno;
		}

		public DataTable Reads(string query, List<SqlParameter> sqlParameters = null)
		{
			DataTable dataTable = new DataTable();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					if (sqlParameters != null)
					{
						command.Parameters.Clear();
						foreach (SqlParameter param in sqlParameters)
						{
							command.Parameters.Add(param);
						}
					}

					SqlDataAdapter adapter = new SqlDataAdapter(command);
					adapter.Fill(dataTable);
				}
			}
			catch (Exception ex)
			{
				new LogNG().Inserir(ex.ToString());
			}

			return dataTable;
		}

		public DataRow Read(string query, List<SqlParameter> sqlParameters = null)
		{
			DataTable dataTable = new DataTable();
			DataRow dataRow = null;
			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand command = new SqlCommand(query, connection);
					if (sqlParameters != null)
					{
						command.Parameters.Clear();
						foreach (SqlParameter param in sqlParameters)
						{
							command.Parameters.Add(param);
						}
					}

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
				new LogNG().Inserir(ex.ToString());
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
					if (sqlParameters != null)
					{
						command.Parameters.Clear();
						foreach (SqlParameter param in sqlParameters)
						{
							command.Parameters.Add(param);
						}
					}
					command.ExecuteNonQuery();
				}
				return true;
			}
			catch (Exception ex)
			{
				new LogNG().Inserir(ex.ToString());
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
					if (sqlParameters != null)
					{
						command.Parameters.Clear();
						foreach (SqlParameter param in sqlParameters)
						{
							command.Parameters.Add(param);
						}
					}
					command.ExecuteNonQuery();
				}
				return true;
			}
			catch (Exception ex)
			{
				new LogNG().Inserir(ex.ToString());
				return false;
			}
		}
	}
}
