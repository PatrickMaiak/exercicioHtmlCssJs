using CategoriaProdutobd.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using CategoriaProdutobd.Interface;

namespace CategoriaProdutobd.Dao
{
    internal class DaoCategoria : ICrudGenerico<Categoria>
    {
        public bool salvar(Categoria categoria)
        {
            using (SqlConnection con = new SqlConnection())
            {
                /*criado conexão com database*/
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();

                /*monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "insert into tb_categoria([categoria])values(@descricao)";

                /*envia dados a serem gravados*/
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = categoria.Descricao;

                /*abrir conexão*/
                cn.Connection = con;

                /*executa conexão*/
                return cn.ExecuteNonQuery() > 0;
            }

            
        }

        public List<Categoria> consultar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "select * from tb_categoria";

                /*abrir a conexaõ*/
                cn.Connection = con;

                /*executa a conexão*/
                SqlDataReader dr;
                dr = cn.ExecuteReader();
                while (dr.Read())
                {
                    Categoria ct = new Categoria();
                    ct.Id = Convert.ToInt32(dr["id"]);
                    ct.Descricao = Convert.ToString(dr["categoria"]);



                    listaCategoria.Add(ct);
                }
            }

            return listaCategoria;
        }

        public bool alterar(Categoria categoria)
        {
            

            using (SqlConnection con = new SqlConnection())
            {
                /*criado conexão com database*/
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();

                /*monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = $"UPDATE tb_categoria SET tb_categoria.categoria = @descricao WHERE id = @id";

                /*envia dados a serem gravados*/
                cn.Parameters.Add("descricao", SqlDbType.VarChar).Value = categoria.Descricao;
                cn.Parameters.Add("id", SqlDbType.Int).Value = categoria.Id;

                /*abrir conexão*/
                cn.Connection = con;
                 /*executa conexão*/
                return cn.ExecuteNonQuery() > 0;
            }
        }

        public string consultarpeloid(int id,List<Categoria> listaCategoria)
        {
            
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_produto;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "select * from tb_categoria WHERE [Id] = @Id";

                cn.Parameters.Add("Id", SqlDbType.Int).Value = id;
                con.Open();

                cn.Connection = con;


                SqlDataReader dr;
                dr = cn.ExecuteReader();

                while (dr.Read())
                {
                    int ids = Convert.ToInt32(dr["Id"]);
                    string descricao = Convert.ToString(dr["categoria"]);

                    Categoria ct = new Categoria(ids, descricao);
                    listaCategoria.Add(ct);
                }

                Categoria variavel = null;

                foreach(Categoria ct in listaCategoria)
                {
                    variavel = ct;
                }

                return $"{variavel.Id} - {variavel.Descricao}";
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
                cn.CommandText = "DELETE FROM tb_categoria WHERE [Id] = @Id";

                cn.Parameters.Add("Id", SqlDbType.Int).Value = id;

                cn.Connection = con;

                return cn.ExecuteNonQuery() > 0;

            }
        }   
    }
}
