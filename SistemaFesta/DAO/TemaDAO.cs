using SistemaFesta.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFesta.DAO
{
    public class TemaDAO
    {
        public FestaContext contexto = new FestaContext();
        public void Adicionar(Tema tema)
        {
            contexto.Temas.Add(tema);
            contexto.SaveChanges();
        }

        public void Atualizar(Tema tema)
        {
            contexto.Temas.Update(tema);
            contexto.SaveChanges();
        }
        public void Remover(Tema tema)
        {
            int id = 0;
            contexto.Temas.Where(x => x.Id == id).FirstOrDefault();
            contexto.Temas.Remove(tema);
            contexto.SaveChanges();
        }
        public IList<Tema> Lista()
        {
            return contexto.Temas.ToList();
        }

        public IList<Tema> ListaDoDecorador(int idPessoaJuridica)
        {
            return contexto.Temas.Where(t => t.PessoaJuridicaId == idPessoaJuridica).ToList();
        }
       

        public Tema BuscaPorId(int id)
        {
            return contexto.Temas.Where(x => x.Id == id).FirstOrDefault();
        }

        public Tema BuscaPessoaId(int id)
        {
            return contexto.Temas.Where(x => x.PessoaJuridicaId == id).FirstOrDefault();
        }
    }
}