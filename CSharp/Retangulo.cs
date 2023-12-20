using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciciosRetornoAoCSharp
{
    internal class Retangulo
    {
        private double altura;
        private double largura;

        public double Altura {
            get { return altura; }
            set 
            {
                if (value <= 0)
                {
                    Console.WriteLine("A Altura deve ser maior que zero");
                }
                else 
                {
                    altura = value;
                }
            }
        }
        public double Largura
        {
            get { return largura; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("A Largura deve ser maior que zero");
                }
                else
                {
                    largura = value;
                }
            }
        }

        public void medirPerimetro()
        {
            var perimetro = altura + altura + largura + largura;
            Console.WriteLine($"O Perimetro Total é : " + $"{perimetro}");
        }

        public void medirArea()
        {
            var area = altura * largura;
            Console.WriteLine($"A Area Total é : " + $"{area}");
        }

        public void display() 
        {
            Console.WriteLine($"altura : {altura} largura : {largura}");
            if ( altura > largura)
            {
                Console.WriteLine("----------\n|        |\n|        |\n|        |\n|        |\n|        |\n|        |\n|        |\n----------");
            }
            else
            {
                Console.WriteLine("---------------\n|             |\n|             |\n|             |\n---------------");
            }
        }
    }
}
