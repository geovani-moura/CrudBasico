using CrudBasico.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBasico.Core.DB;

namespace CrudBasico.Core.NG
{
	public class ClienteNG
	{
		public int Inserir(ClienteEntity cliente)
		{
			var clienteDB = new ClienteDB();
            var retorno = clienteDB.Inserir(cliente);
			return retorno;
		}
		public ClienteEntity Obter(int Id)
		{
            var clienteDB = new ClienteDB();
            var retorno = clienteDB.Obter(Id);		
			return retorno;
		}

		public ClienteEntity ObterEscondido(int Id)
		{
            var clienteDB = new ClienteDB();
            var retorno = clienteDB.Obter(Id);
			return retorno;
		}
		public List<ClienteEntity> Listar()
		{
            var clienteDB = new ClienteDB();
            var retornoColecao = clienteDB.Listar();
			return retornoColecao;
		}
		public bool Atualizar(ClienteEntity cliente)
		{
            var clienteDB = new ClienteDB();
            var retorno = clienteDB.Atualizar(cliente);
			return retorno;
		}
		public bool Delete(int Id)
		{
            var clienteDB = new ClienteDB();
            var retorno = clienteDB.Delete(Id);
			return retorno;
		}
	}
}
