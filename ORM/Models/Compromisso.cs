namespace ORM.Models
{
    public class Compromisso
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        public int ContatoId { get; set; }

        public int LocalId { get; set; }

        public Contato Contato { get; set; }

        public Local Local { get; set; }
    }
}
