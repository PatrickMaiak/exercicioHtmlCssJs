namespace CrudDoExercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produtos>listaDeProdutos = new List<Produtos>();
            Console.WriteLine("Hello Crud");
            Console.WriteLine("Opções: ");
            Console.WriteLine(" 1 - para  Create \n 2 - para  Read\n 3 - para  Update\n 4 - para  Delete");
            Console.Write("Somente Numeros: ");
            int Numero = Convert.ToInt32(Console.ReadLine());
            

            SetOption(Numero,listaDeProdutos);
        }

        static void SetOption(int n ,List<Produtos>listaDeProdutos)
        {
            bool continuar = true;
            while (continuar)
            {
                switch (n)
                {
                    case 1:

                        bool chaveDoWhile = true;
                        while (chaveDoWhile)
                        {


                            Console.WriteLine("Create  Crie um novo produto: ");
                            Console.Write("Descrição:");

                            string descriçao = Console.ReadLine();
                            Console.Write("Quantidade Estoque :");

                            int estoque = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Valor Unitário:");

                            double valor = Convert.ToDouble(Console.ReadLine());

                            int autoIncrement = listaDeProdutos.Count;


                            Produtos produto = new Produtos();
                            produto.Id = autoIncrement + 1;
                            produto.Descricao = descriçao;
                            produto.Valor = valor;
                            produto.Estoque = estoque;

                            listaDeProdutos.Add(produto);

                            Console.WriteLine(listaDeProdutos.ToArray()[autoIncrement].ToString().ToUpper());
                            Console.WriteLine();

                            Console.WriteLine("Deseja criar outro produto: (S/N)");

                            string controle = Console.ReadLine().ToUpper();
                            if (controle != "S")
                            { 
                                chaveDoWhile = false;
                                Console.WriteLine("Saindo de create..");

                            }

                        }

                        break;
                    case 2:

                        Console.WriteLine("Read   Itens da lista:");
                            
                        foreach (var item in listaDeProdutos)                           
                        {
                             Console.WriteLine(item.ToString());

                        }

                        break;
                    case 3:
                        Console.WriteLine("Update atualizar item da lista");

                        foreach (var item in listaDeProdutos)
                        {
                            Console.WriteLine(item.ToString());

                        }
                        Console.WriteLine("digite o ID do tem que deseja atualizar");

                        int controle3 = Convert.ToInt32(Console.ReadLine());


                        int indice = listaDeProdutos.FindIndex(produtos => produtos.Id == controle3);

                        if (indice != -1)
                        {
                            Console.WriteLine($"alterando o produto \n{listaDeProdutos.ToArray()[indice].ToString()}");
                            

                            Console.Write("ID:");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Descrição:");
                            string descriçao = Console.ReadLine();

                            Console.Write("Quantidade Estoque :");
                            int estoque = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Valor Unitário:");
                            double valor = Convert.ToDouble(Console.ReadLine());

                            Produtos produto = new Produtos();
                            produto.Id = id;
                            produto.Descricao = descriçao;
                            produto.Valor = valor;
                            produto.Estoque = estoque;

                            listaDeProdutos[controle3-1] = produto;

                        }

                        break;
                    case 4:
                        Console.WriteLine("Delete");
                        foreach (var item in listaDeProdutos)
                        {
                            Console.WriteLine(item.ToString());

                        }
                        Console.WriteLine("digite o ID do tem que deseja deletar");

                        int controle4Err = Convert.ToInt32(Console.ReadLine());

                        int controle4 = controle4Err - 1;

                        int indice4 = listaDeProdutos.FindIndex(produtos => produtos.Id == controle4);

                        if (controle4 != -1)
                        {
                            Console.WriteLine($"Deletando o produto \n{listaDeProdutos.ToArray()[controle4].ToString()}");
                            Console.ReadKey();
                            listaDeProdutos.RemoveAt(controle4);
                            for (int i = 0; i < listaDeProdutos.Count; i++)
                            {
                                listaDeProdutos[i].Id = i + 1;
                            }

                        }
                            break;
                    default:
                        break;
                }

                Console.WriteLine("Deseja escolher outra opção? (S/N)");
                string escolha = Console.ReadLine();

                if (escolha.ToUpper() != "S")
                {
                    continuar = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Escolha uma nova opção: ");
                    Console.WriteLine(" 1 - para  Create \n 2 - para  Read\n 3 - para  Update\n 4 - para  Delete");
                    n = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}