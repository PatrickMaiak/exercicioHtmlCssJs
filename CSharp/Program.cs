namespace exerciciosRetornoAoCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Carros : digite enter para começar");
            CriaCarro();
            Console.ReadKey();

            Console.WriteLine("Calculadora precione : digite enter para começar");
            Console.ReadKey();
            CriaCalculadora();
            Console.ReadKey();

            Console.WriteLine("Retangulo Area e perimetro: digite enter para começar");
            Console.ReadKey();
            CriarRetangulo();
            Console.ReadKey();

            Console.WriteLine("Produtos com desconto em reais\n acrecimo em porcentegem: digite enter para começar");
            Console.ReadKey();
            DescontarProdutos();
            Console.ReadKey();


        }

        private static void DescontarProdutos()
        {
            Produtos produto1 = new Produtos();
            produto1.Id = 1;
            produto1.Descricao = "xbox one";
            produto1.Estoque = 10;
            produto1.Preco = 1500;

            produto1.retornarPreco();
            
            produto1.descontarValor(10); 
            
            produto1.acrecentarValor(50);
           
           
        }

        private static void CriarRetangulo() 
        {
            Retangulo retangulo = new Retangulo();
            Console.WriteLine("infrome a alura");
            retangulo.Altura = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("infrome a largura");
            retangulo.Largura = Convert.ToDouble(Console.ReadLine());
            retangulo.display();
            retangulo.medirArea();
            retangulo.medirPerimetro(); 
        }



        private static void CriaCalculadora()
        {
            Calculadora calculadora = new Calculadora();
            calculadora.Numero1 = 10;
            calculadora.Numero2 = 10;
            calculadora.display();
            Console.WriteLine(calculadora.somar());
            calculadora.subtrair();
            calculadora.multiplicar();
            calculadora.dividir();
            
        }


        private static void CriaCarro()
        {
            Carro c1 = new Carro();
            c1.Placa = "AAA-1234";
            c1.Modelo = "Nivus";
            c1.Marca = "Volksvagen";
            c1.Cor = "Dark Nardo";
          
            c1.display();

            Carro c2 = new Carro();
            c2.Placa = "DEN-5500";
            c2.Modelo = "Civic";
            c2.Marca = "Honda";
            c2.Cor = "Dourado";
            
            c2.display();

            Carro c3 = new Carro();
            c3.Placa = "BBB-1234";
            c3.Modelo = "Transalp XL 800V";
            c3.Marca = "Honda";
            c3.Cor = "Branco";
          
            c3.display();
        }
    }
}