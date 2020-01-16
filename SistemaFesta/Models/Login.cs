using System.ComponentModel.DataAnnotations;

namespace SistemaFesta.Models
{
    public class Login
    {
        [Key]
        [Required]
        public int Id { get; set; }

        // Nome de usuário
        [Required(ErrorMessage = "Preencha seu nome de usuário!"), MaxLength(50, ErrorMessage = "Número de caracteres excedido!")]
        public string NomeUsuario { get; set; }

        // Senha
        [Required(ErrorMessage = "Preencha sua senha de acesso!"), MaxLength(40, ErrorMessage = "Número de caracteres excedido!")]
        public string Senha { get; set; }
        public bool ControleAcesso { get; set; }
    }
}