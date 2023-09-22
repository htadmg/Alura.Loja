using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private LojaContext contexto;
        public ProdutoDAOEntity() 
        {
            this.contexto = new LojaContext();
        }
        public void Adicionar(Produto p)
        { 
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            contexto.Produtos.Update(p);
            contexto.SaveChanges();
        }

        public IList<Produto> Produtos()
        {
            return contexto.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            contexto.Produtos.Remove(p);
            contexto.SaveChanges();
        }
        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
