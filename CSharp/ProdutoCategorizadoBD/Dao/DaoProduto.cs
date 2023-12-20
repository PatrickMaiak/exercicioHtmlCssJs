using CategoriaProdutobd.Entidades;
using CategoriaProdutobd.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriaProdutobd.Dao
{
    public class DaoProduto : ICrudGenerico<Produto>
    {
        public bool alterar(Produto produto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                /*criado conexão com database*/
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();

                /*monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $"UPDATE tb_produto SET tb_produto.descricao = @descricao, valorunt = @valorunt, estoqueqtd = @estoqueqtd, categoriaid = @categoriaid WHERE id = {produto.Id}";


                /*envia dados a serem gravados*/
                cn.Parameters.Add("@descricao", SqlDbType.VarChar).Value = produto.Descricao;
                cn.Parameters.Add("@valorunt", SqlDbType.Decimal).Value = produto.ValorUnt;
                cn.Parameters.Add("@estoqueqtd", SqlDbType.Int).Value = produto.EstoqueQtd;
                cn.Parameters.Add("@categoriaid", SqlDbType.Int).Value = produto.CategoriaId;

                /*abrir conexão*/
                cn.Connection = con;
                /*executa conexão*/
                return cn.ExecuteNonQuery() > 0;
            }
        }

        public List<Produto> consultar()
        {
            List<Produto> listaProduto = new List<Produto>();

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "select * from tb_produto";


                cn.Connection = con;


                SqlDataReader dr;
                dr = cn.ExecuteReader();
                while (dr.Read())
                {
                    Produto ct = new Produto();
                    ct.Id = Convert.ToInt32(dr["id"]);
                    ct.Descricao = Convert.ToString(dr["descricao"]);
                    ct.ValorUnt = Convert.ToDouble(dr["valorunt"]);
                    ct.EstoqueQtd = Convert.ToInt32(dr["estoqueqtd"]);
                    ct.CategoriaId = Convert.ToInt32(dr["categoriaid"]);



                    listaProduto.Add(ct);
                }
            }

            return listaProduto;
        }

        public string consultarpeloid(int id, List<Produto> listaProduto)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "select * from tb_produto WHERE [Id] = @Id";

                cn.Parameters.Add("Id", SqlDbType.Int).Value = id;
                con.Open();

                cn.Connection = con;


                SqlDataReader dr;
                dr = cn.ExecuteReader();

                while (dr.Read())
                {
                    int ids = Convert.ToInt32(dr["Id"]);
                    string descricao = Convert.ToString(dr["descricao"]);
                    double valorunt = Convert.ToDouble(dr["valorunt"]);
                    int estoqueqtd = Convert.ToInt32(dr["estoqueqtd"]);
                    int categoriaid = Convert.ToInt32(dr["categoriaid"]);

                    Produto ct = new Produto(ids, descricao, valorunt, estoqueqtd, categoriaid);
                    listaProduto.Add(ct);
                }

                Produto variavel = null;

                foreach (Produto ct in listaProduto)
                {
                    variavel = ct;
                }

                return $"{variavel.Id} - {variavel.Descricao} - {variavel.ValorUnt} - {variavel.EstoqueQtd} - {variavel.CategoriaId}";
            }
        }

        public bool excluir(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "DELETE FROM tb_produto WHERE [Id] = @Id";

                cn.Parameters.Add("Id", SqlDbType.Int).Value = id;

                cn.Connection = con;

                return cn.ExecuteNonQuery() > 0;

            }
        }

        public bool salvar(Produto produto)
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "INSERT INTO tb_produto ([descricao], [valorunt], [estoqueqtd], [categoriaid]) VALUES (@descricao, @valorunt, @estoqueqtd, @categoriaid)";
                cn.Parameters.Add("@descricao", SqlDbType.VarChar).Value = produto.Descricao;
                cn.Parameters.Add("@valorunt", SqlDbType.Decimal).Value = produto.ValorUnt;
                cn.Parameters.Add("@estoqueqtd", SqlDbType.Int).Value = produto.EstoqueQtd;
                cn.Parameters.Add("@categoriaid", SqlDbType.Int).Value = produto.CategoriaId;

                cn.Connection = con;


                return cn.ExecuteNonQuery() > 0;
            }
        }


    }
}
