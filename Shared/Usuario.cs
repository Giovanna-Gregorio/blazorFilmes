using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorFilmes.Shared
{
    public class Usuario
    {      
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Título é obrigatório")] 
        public string Title { get; set; }     

        [Required(ErrorMessage = "Nome é obrigatório")] 
        public string FirstName { get; set; }       

        [Required(ErrorMessage = "Sobrenome é obrigatório")] 
        public string LastName { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatório")] 
        public DateTime? DateBirth { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")] 
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")] 
        [MinLength(6, ErrorMessage = "A senha deve conter, no mínimo, 6 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmação da senha é obrigatório")] 
        [Compare(nameof(Password), ErrorMessage = "As senhas não correspondem")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "É necessário aceitar os termos")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "É necessário aceitar os termos")]
        public bool Accept { get; set; }
    }
}