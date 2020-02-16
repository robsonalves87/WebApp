using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public static class BaseCategoriaDoProduto
    {
        public static IEnumerable<CategoriaDoProduto> CategoriasDoProduto()
        {
            return new List<CategoriaDoProduto>
            {
                new CategoriaDoProduto {Id = 1, Descricao = "Livros"},
                new CategoriaDoProduto {Id = 2, Descricao = "Games"},
                new CategoriaDoProduto {Id = 3, Descricao = "Filmes"}
            };
        }
    }
    public class CategoriaDoProduto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

    }
}