namespace MED.Domain.Entities
{
    public class Contato: Entity
    {
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public bool Ativo {  get; set; }
        public string sexo { get; set; }
        public int? Idade { get; set; }
    }
}
