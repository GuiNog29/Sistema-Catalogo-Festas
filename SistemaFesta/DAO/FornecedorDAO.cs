using SistemaFesta.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFesta.DAO
{
    public class FornecedorDAO
    {
        public FestaContext contexto = new FestaContext();

        public void Adicionar(Fornecedor fornecedor)
        {
            contexto.Fornecedores.Add(fornecedor);
            fornecedor.ControleAcesso = true;
            contexto.SaveChanges();
        }

        public void Atualizar(Fornecedor fornecedor)
        {
            contexto.Fornecedores.Update(fornecedor);
            contexto.SaveChanges();
        }

        public void Remover(Fornecedor fornecedor)
        {
            int id = 0;
            contexto.Fornecedores.Where(x => x.Id == id).FirstOrDefault();
            contexto.Fornecedores.Remove(fornecedor);
            contexto.SaveChanges();
        }

        public IList<Fornecedor> Listagem()
        {
            return contexto.Fornecedores.ToList();
        }

        public Fornecedor BuscaPorId(int id)
        {
            return contexto.Fornecedores.Where(x => x.Id == id).FirstOrDefault();
        }

        public Fornecedor BuscaFornecedor(string login, string senha)
        {
            return contexto.Fornecedores.FirstOrDefault(x => x.NomeUsuario == login && x.Senha == senha);
        }

        public Fornecedor VerificarFornecedor(string login)
        {
            return contexto.Fornecedores.FirstOrDefault(fornecedor => fornecedor.NomeUsuario == login);
        }
    }
}