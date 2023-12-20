using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciciosRetornoAoCSharp
{
    internal class Carro
    {
        private string placa;
        private string marca;
        private string modelo;
        private string cor;
        


        public string Placa
        {
            get{ return placa; }

            set
            {
                if (value.Length < 3 )
                {
                    Console.WriteLine($"a placa deve ter  7 caracteres ");
                }
                else
                {
                     placa = value;
                }
               
            }
        }
        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (value.Length < 2 )
                {
                    Console.WriteLine("o nome da modelo deve ser maior que 2 caracteres");
                }
                else
                {
                    modelo = value;
                }

            }
        }
        public string Marca
        {
            get { return marca; }

            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine($"o nome da marca deve ser maior que 3 caracteres");
                }
                else
                {
                    marca = value;
                }

            }
        }
        public string Cor
        {
            get { return cor; }
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("o nome da cor deve ter mais de 3 caracteres");
                }
                else
                {
                    cor = value;
                }
            }    
        }




        public void display()
        {
            Console.WriteLine(marca);
            Console.WriteLine(modelo);
            
            Console.WriteLine(cor);
            Console.WriteLine(placa);
      
            Console.WriteLine();
        }
    }
}
