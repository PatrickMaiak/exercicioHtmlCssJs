using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriaProdutobd.Entidades
{
    internal class Categoria
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

   
        public Categoria() { }
        public Categoria(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            
        }
    }
}
