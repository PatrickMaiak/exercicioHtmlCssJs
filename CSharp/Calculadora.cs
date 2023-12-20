using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerciciosRetornoAoCSharp
{
    internal class Calculadora
    {
        private double numero1;
        private double numero2;

        //para o encapsulamento
        //o atributo é privado mas pode ser usado e chamado por um metodo public
        public double Numero1
        {
            get{ return numero1; }
            set
            {
                if (value <= 0 )
                {
                    Console.WriteLine("o numero 1 deve ser maior que zero ");
                }
                else 
                {
                     numero1 = value;
                }
            }
        }
        public double Numero2
        {
            get { return numero2; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("o numero 2 deve ser maior que zero ");
                }
                else
                {
                    numero2 = value;
                }
            }
        }


        public double somar()
        {
            Console.WriteLine($"o resultado da soma de {numero1} e {numero2} é");
            return numero1 + numero2;
            
        }
        public void subtrair()
        {
            Console.WriteLine($"o resultado da subtração de {numero1} e {numero2} é");
            var resultado = numero1 - numero2;
            Console.WriteLine(resultado);
        }
        public void multiplicar()
        {
            Console.WriteLine($"o resultado da multiplicação de {numero1} e {numero2} é");
            var resultado = numero1 * numero2;
            Console.WriteLine(resultado);
        }
        public void dividir()
        {
            Console.WriteLine($"o resultado da divisão de {numero1} e {numero2} é");
            if (numero1 == 0 || numero2 == 0) 
            {
                Console.WriteLine("Nao é possivel dividir por zero");
                return;
            }
            var resultado = numero1 / numero2;
            Console.WriteLine(resultado);
        }
        public void display()
        {
            Console.WriteLine($"numero 1 : {numero1}");
            Console.WriteLine($"numero 2 : {numero2}");
        }
    }
}
