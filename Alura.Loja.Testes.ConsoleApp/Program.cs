using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());


                var produtos = contexto.Produtos.ToList();
                foreach(var produto in produtos)
                {
                    Console.WriteLine(produto);
                }
                Console.WriteLine("================");
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                //var p1 = produtos.First();
                //p1.Nome = "007";
                var novoProduto = new Produto()
                {
                    Nome = "Desinfetante",
                    Categoria = "Limpeza",
                    Preco = 2.99
                };
                contexto.Produtos.Add(novoProduto);

            Console.WriteLine("================");
                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.Entity.ToString() + " - ", e.State) ;
                }
                contexto.SaveChanges();


                //var produtos1 = contexto.Produtos.ToList();
                //foreach (var produto in produtos)
                //{
                //    Console.WriteLine(produto);
                //}
            }
        }
    }
}
