using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{

    public static class BaseProdutos
    {
        public static IEnumerable<Produto> Produtos()
        {
            CategoriaDoProduto categoria1 = BaseCategoriaDoProduto.CategoriasDoProduto().FirstOrDefault(c => c.Id == 1);
            CategoriaDoProduto categoria2 = BaseCategoriaDoProduto.CategoriasDoProduto().FirstOrDefault(c => c.Id == 2);
            CategoriaDoProduto categoria3 = BaseCategoriaDoProduto.CategoriasDoProduto().FirstOrDefault(c => c.Id == 3);

            return new List<Produto>
            {
                new Produto {Id = 1,Nome = "Produto 1", Valor = 10, categoriaDoProdutoId = 1, categoriaDoProduto = categoria1},
                new Produto {Id = 2,Nome = "Produto 2", Valor = 11, categoriaDoProdutoId = 2, categoriaDoProduto = categoria2},
                new Produto {Id = 3,Nome = "Produto 3", Valor = 12, categoriaDoProdutoId = 3, categoriaDoProduto = categoria3}
            };
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int categoriaDoProdutoId { get; set; }
        public virtual CategoriaDoProduto categoriaDoProduto { get; set; }


    }
}