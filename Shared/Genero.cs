using System.ComponentModel.DataAnnotations;

namespace BlazorFilmes.Shared
{
    public class Genero
    {
        public int Id { get; set; }    
        [Required(ErrorMessage = "Nome é obrigatório")] 
        public string Name { get; set; }
    }
}