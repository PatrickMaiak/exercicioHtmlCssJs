using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciciosRetornoAoCSharp
{
    internal class Produtos
    {
        /* Criar uma classe de produtos com código,
         * descrição, estoque e valor Unitário.
         * Criar métodos que retorne o preço do produto
         * aplicando um desconto e um acréscimo.
         */
        private int id;
        private string descricao;
        private int estoque;
        private double preco;
        private double precoDesconto;
        private double precoAcrecimo;

        public int Id 
        {
            get{return id;}
            set 
            {
                if (value <= 0)
                {
                    Console.WriteLine("o valor deve ser maior que zero");
                }
                else 
                {
                    id = value;
                }
            }
        }
        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (value.Length < 4)
                {
                    Console.WriteLine("o numero de caracteres deve ser maior que 4");
                }
                else
                {
                    descricao = value;
                }
            }
        }
        public int Estoque
        {
            get { return estoque; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("o valor deve ser maior que zero");
                }
                else
                {
                    estoque = value;
                }
            }
        }
        public double Preco
        {
            get { return preco; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("o valor deve ser maior que zero");
                }
                else
                { 
                    preco = value; 
                }
            }
        }
        public void retornarPreco()
        {
            Console.WriteLine("O Valor do " + $"{descricao}" +" É :"+ $"{preco}");
        }
        public void descontarValor(double taxa)
        {
            var total = preco - taxa ;
            
            Console.WriteLine("O Valor Do Desconto É " + $"{taxa}R$" + " e o preço cai para :" + $"{total}");
        }

        public void acrecentarValor(double taxa)
        {
            var total =taxa/100;
            var total2 = total * preco;
            
            Console.WriteLine("O Valor Do Acrecimo É " + $"{taxa}%" + " e o preço sobe para :" + $"{(total2 + preco)}");
        }
    }
}
