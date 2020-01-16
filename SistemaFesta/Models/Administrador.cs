using System.ComponentModel.DataAnnotations;

namespace SistemaFesta.Models
{
    public class Administrador : Login
    {
        [Required]
        public string Email { get; set; }
    }
}