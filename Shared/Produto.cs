using System.ComponentModel.DataAnnotations;

namespace BlazorFilmes.Shared
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descrição é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Valor é obrigatório")]
        public decimal Valor { get; set; }
    }
}