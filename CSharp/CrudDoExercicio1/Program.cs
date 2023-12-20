using System.Numerics;

namespace exerciciosRetornoAoCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carro> carros = new List<Carro>();
          
            bool continuar = true;
            while (continuar)
            {
                // Coleta de comando
                Console.WriteLine("Bem vindo ao Exercicio Carros: Pressione ENTER para começar");
                Console.ReadKey();
                
                Console.WriteLine("Lista de comandos: \n C para Adicionar \n R para Ler\n U para Editar \n D para Deletar\n S para Sair");
                string comando = Console.ReadLine().ToUpper();
                Console.WriteLine($"Você escolheu {comando}");

                if (comando == "S")
                {
                    Console.WriteLine("fim do exercicio Carro \nPressione ENTER para ir para o Exercicio Produto ");
                    Console.ReadKey();
                    continuar = false; 
                }
                else
                {
                    CriaCarro(comando, carros);
                    Console.ReadKey();
                   // Console.Clear();
                }
            }

        }

        public static void CriaCarro(string comando,List<Carro> carros)
        {
            if (comando == "C")
            {
                bool continuar = true;
                while (continuar)
                {
                    Console.WriteLine("Vamos criar o carro");
                    Console.Write("Informe a Marca:");
                    string marca = Console.ReadLine();

                    Console.Write("Informe a Modelo:");
                    string modelo = Console.ReadLine();

                    Console.Write("Informe a Cor:");
                    string cor = Console.ReadLine();

                    Console.Write("Informe a Placa Exemplo: (ABC-1234) :  ");
                    string placa = Console.ReadLine();

                    Console.Clear();


                    bool placaDuplicada = carros.Any(carro => carro.Placa == placa);
                    bool modeloDuplicado = carros.Any(carro => carro.Modelo == modelo);
                    if (placaDuplicada && modeloDuplicado == true)
                    {
                        Console.WriteLine($"ja existe um veiculo: {modelo} com a placa: {placa}");
                        Console.WriteLine($"pressione C para digitar um veiculo valido ou S para sair");
                        string comandoSair = Console.ReadLine().ToUpper();

                        if (comandoSair == "S")
                        {
                            continuar = false;
                        }

                    }


                    else
                    {
                        Carro novoCarro = new Carro();
                        novoCarro.Marca = marca;
                        novoCarro.Modelo = modelo;
                        novoCarro.Cor = cor;
                        novoCarro.Placa = placa;


                        carros.Add(novoCarro);
                        Console.Clear();

                        Console.WriteLine("Novo carro adicionado");
                        Console.WriteLine($"pressione ENTER para cadastrar um novo veiculo ou M para voltar ao menu de comandos");
                        string comandoSairFinal = Console.ReadLine().ToUpper();

                        if (comandoSairFinal == "M")
                        {
                            continuar = false;
                        }

                    }


                }


            }

            else if (comando == "R")
            {
                bool continuar = true;
                while (continuar)
                {
                    Console.WriteLine("Lista de Carros:");
                    foreach (Carro carro in carros)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Marca: {carro.Marca}\n Modelo: {carro.Modelo}\n Cor: {carro.Cor}\n Placa: {carro.Placa}\n...");

                    }
                    Console.WriteLine("Digite M para voltar ao menu de comandos");
                    string comandoSair = Console.ReadLine().ToUpper();

                    if (comandoSair == "M")
                    {
                        continuar = false;
                    }

                }


            }

            else if (comando == "U")
            {
                Console.WriteLine("Informe a placa do carro que deseja atualizar\n Exemplo: ABC-1234:");
                string placa = Console.ReadLine();

                Carro carroParaAtualizar = carros.Find(carro => carro.Placa == placa);

                if (carroParaAtualizar != null)
                {
                    Console.WriteLine("Informe os novos dados do carro:");
                    Console.Write("Marca: ");
                    string novaMarca = Console.ReadLine();
                    Console.Write("Modelo: ");
                    string novoModelo = Console.ReadLine();
                    Console.Write("Cor: ");
                    string novaCor = Console.ReadLine();
                    Console.Write("Placa: ");
                    string novaPlaca = Console.ReadLine();

                    carroParaAtualizar.Marca = novaMarca;
                    carroParaAtualizar.Modelo = novoModelo;
                    carroParaAtualizar.Cor = novaCor;
                    carroParaAtualizar.Placa = novaPlaca;

                    Console.WriteLine("Carro atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Carro não encontrado.");
                }
            }

            else if (comando == "D")
            {
                bool continua = true;
                while (continua)
                {
                    Console.WriteLine("Informe a placa do carro que deseja Excluir\n Exemplo: (ABC-1234) : ");
                    string placa = Console.ReadLine();

                    Carro carroParaExcluir = carros.Find(carro => carro.Placa == placa);

                    if (carroParaExcluir != null)
                    {
                        Console.WriteLine("Tem certeza que deseja excluir o veiculo");
                        Console.WriteLine(carroParaExcluir.Marca);
                        Console.WriteLine(carroParaExcluir.Modelo);
                        Console.WriteLine(carroParaExcluir.Cor);
                        Console.WriteLine(carroParaExcluir.Placa);
                        Console.WriteLine("digite S para sim e N para não : ");
                        string comandoTemCerteza = Console.ReadLine().ToUpper();
                        if (comandoTemCerteza == "S")
                        {
                            carros.Remove(carroParaExcluir);
                            Console.WriteLine("Carro excluido com sucesso : ");
                            continua = false;
                        }
                        else if (comandoTemCerteza == "N")
                        {

                            continua = false;
                        }
                        else
                        {
                            Console.WriteLine("Comando invalido: ");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Comando invalido \n Pressione ENTER para tentar um novo comando ");
            }

        }

        
       
        
    }
}