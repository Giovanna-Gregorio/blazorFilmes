using System;
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
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Valor deve ser maior que zero")]
        public decimal Valor { get; set; }
    }
}