using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDoExercicio4
{
    internal class Produtos
    {
        public int Id { get; set; }
        public int  Estoque{ get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set;}

        public string ToString()
        {
            return $"{Id} - {Descricao} R$: {Valor} QTD: {Estoque} ";
        }

    }
}
