using System.Text.Json.Serialization;

namespace CrudDeProduto.Models
{
    public class TodoProduto
    {
        //public long Id { get; set; }
        //public string? Name { get; set; }
        //public bool IsComplete { get; set; }

        public int Id { get; set; }
        public string Produto { get; set; }
        
        public double Valor { get; set; }
        [JsonIgnore]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
