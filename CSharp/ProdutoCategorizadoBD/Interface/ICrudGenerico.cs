using CategoriaProdutobd.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoriaProdutobd.Interface
{
    public interface ICrudGenerico<T>
    {
        public bool salvar(T t);
       
        public List<T> consultar();
        public bool alterar(T t);
        public string consultarpeloid(int id, List<T> t);
        public bool excluir(int id);
    }
}
