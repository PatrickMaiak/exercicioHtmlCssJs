using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriaProdutobd.Entidades
{
    public class Produto
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public double ValorUnt { get; set; }
        public int EstoqueQtd { get; set; }
        public int CategoriaId { get; set; }

        public Produto() { }
        public Produto(int id, string descricao, double valorunt, int estoqueqtd, int categoriaid)
        {
            Id = id;
            Descricao = descricao;
            ValorUnt = valorunt;
            EstoqueQtd = estoqueqtd;
            CategoriaId = categoriaid;
        }
    }
}
