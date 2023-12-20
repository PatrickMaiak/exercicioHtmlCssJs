using CategoriaProdutobd.Dao;
using CategoriaProdutobd.Entidades;
using System.Collections.Generic;
using System.IO;
namespace CategoriaProdutobd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = false;
            while (loop == false)
            {
                Console.WriteLine("lista de produtos");

                Console.WriteLine("==== Menu ====");
                Console.WriteLine("1. Adicionar Categoria");
                Console.WriteLine("2. Adicionar Produto");
                Console.WriteLine("3. Listar Produtos");
                Console.WriteLine("4. Listar Categorias");
                Console.WriteLine("5. Editar");
                Console.WriteLine("6. Excluir");
                Console.WriteLine("7. Sair");
                Console.WriteLine("8. Listar pelo Id");
                Console.WriteLine("================");

                int Comando = Convert.ToInt32(Console.ReadLine());

                switch (Comando)
                {

                    case 1:
                        //int autoIncrement = lista.Max(c => c.Id) + 1;

                        Console.Write("Adicione uma Categoria ");
                        Console.Write("Nome da categoria : ");
                        string Nome = Console.ReadLine();


                        Categoria categoria = new Categoria(1, $"{Nome}");

                        DaoCategoria daoCategoria = new DaoCategoria();


                        if (daoCategoria.salvar(categoria))
                        {
                            Console.WriteLine($"Categoria:{Nome} adicionada com sucesso!!");
                        }
                        else { Console.WriteLine($"ERRO ao adicionar categoria:{Nome} :("); }

                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Write("Adicione um produto ");

                        Console.Write("Nome do produto : ");
                        string NomeProduto = Console.ReadLine();

                        Console.Write($"Valor Unitario De{NomeProduto} : ");
                        double ValorProduto = Convert.ToDouble(Console.ReadLine());

                        Console.Write($"Quantidade de {NomeProduto} no estoque : ");
                        int EstoqueProduto = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Informe Id da categoria do produto ");
                        listarCategoria();
                        int categoriaProduto = Convert.ToInt32(Console.ReadLine());


                        Produto produto = new Produto(2, $"{NomeProduto}", ValorProduto, EstoqueProduto, categoriaProduto);



                        DaoProduto daoproduto = new DaoProduto();

                        if (daoproduto.salvar(produto))
                        {
                            Console.WriteLine($"produto:{NomeProduto} adicionado com sucesso!!");
                        }
                        else { Console.WriteLine($"erro ao adicionar produto:{NomeProduto} :"); }


                        Console.ReadKey();

                        break;
                    case 3:

                        listarProduto();

                        Console.ReadKey();
                        break;
                    case 4:
                        listarCategoria();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Editar");
                        Console.WriteLine("[1- Produto | 2- Categoria]");
                        string controle = Console.ReadLine();

                        if (controle == "1")
                        {
                            alterarProduto();
                        }
                        else if (controle == "2")
                        {
                            alterarCategoria();
                        }
                        else { Console.WriteLine("opcão invalida"); }


                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Excluir");
                        Console.WriteLine("[1- Produto | 2- Categoria]");
                        int controle6 = Convert.ToInt32(Console.ReadLine());

                        if (controle6 == 1)
                        {
                            excluirCategoria();
                        }
                        else if (controle6 == 2)
                        {
                            excluirCategoria();
                        }
                        else { Console.WriteLine("opcão invalida"); }


                        Console.ReadKey();



                        break;
                    case 7:

                        loop = true;
                        break;

                    case 8:
                        Console.WriteLine("listar pelo Id");
                        Console.WriteLine("[1- Produto | 2- Categoria]");
                        string controler = Console.ReadLine();

                        if (controler == "1")
                        {
                            listarpeloidProduto();
                        }
                        else if (controler == "2")
                        {
                            listarpeloidCategoria();
                        }
                        else { Console.WriteLine("opacao invalida"); }


                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }


            Console.ReadKey();
        }

        static void excluirCategoria()
        {
            DaoCategoria daoCategoria = new DaoCategoria();


            Console.WriteLine("insira id  da categoria que deseja excluir");

            int idcat = Convert.ToInt32(Console.ReadLine());
            daoCategoria.excluir(idcat);

        }
        static void excluirProduto()
        {
            DaoProduto daoProduto = new DaoProduto();


            Console.WriteLine("insira id  da produto que deseja excluir");

            int idprod = Convert.ToInt32(Console.ReadLine());
            daoProduto.excluir(idprod);

        }
        static void listarpeloidCategoria()
        {
            DaoCategoria daoCategoria = new DaoCategoria();
            List<Categoria> listaCategoria = new List<Categoria>();

            Console.WriteLine("insira id  da categoria que deseja listar");

            int idcat = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(daoCategoria.consultarpeloid(idcat, listaCategoria));
        }
        static void listarpeloidProduto()
        {
            DaoProduto daoProduto = new DaoProduto();
            List<Produto> listaProduto = new List<Produto>();

            Console.WriteLine("insira id  do Produto que deseja listar");

            int idprod = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(daoProduto.consultarpeloid(idprod, listaProduto));
        }
        static void listarCategoria()
        {
            DaoCategoria daoCategoria = new DaoCategoria();

            List<Categoria> listadecategoria = daoCategoria.consultar();

            foreach (Categoria categoria in listadecategoria)
            {
                Console.WriteLine($"ID: {categoria.Id}, Descrição: {categoria.Descricao}");
            }
        }
        static void listarProduto()
        {

            DaoProduto daoProduto = new DaoProduto();

            List<Produto> listadeproduto = daoProduto.consultar();

            foreach (Produto produto in listadeproduto)
            {
                Console.WriteLine($"ID: {produto.Id}, Descrição: {produto.Descricao}" +
                    $", Valor unitario:{produto.ValorUnt}, Quantidade em estoque: {produto.EstoqueQtd}, Categoria: {produto.CategoriaId} ");
            }
        }
        static void alterarCategoria()
        {
            DaoCategoria daoCategoria = new DaoCategoria();
            Categoria categoria = new Categoria();

            Console.WriteLine("insira id  da categoria que deseja alterar");
            int idcat = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("insira o novo nome pra categoria");
            string novacat = Console.ReadLine();

            categoria.Id = idcat;
            categoria.Descricao = novacat;

            if (daoCategoria.alterar(categoria))
            {
                Console.WriteLine("foi");
            };

        }
        static void alterarProduto()
        {
            DaoProduto daoProduto = new DaoProduto();
            Produto produto = new Produto();

            Console.WriteLine("insira id  do Produto que deseja alterar");
            int idprod = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("insira o novo nome pra Produto");
            string novaprod = Console.ReadLine();

            Console.WriteLine("insira o novo valor unitario pra Produto");
            double valoruntprod = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("insira a nova quantidade no estoque pra Produto");
            int estoqueqtdprod = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("insira o novo id da categoria do produto ");
            listarCategoria();
            int idcategoria = Convert.ToInt32(Console.ReadLine());




            produto.Id = idprod;
            produto.Descricao = novaprod;
            produto.ValorUnt = valoruntprod;
            produto.EstoqueQtd = estoqueqtdprod;
            produto.CategoriaId = idcategoria;

            if (daoProduto.alterar(produto))
            {
                Console.WriteLine("foi");
            };

        }
    }
}