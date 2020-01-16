using System.ComponentModel.DataAnnotations;

namespace SistemaFesta.Models
{
    public class Tema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        // Nome do tema
        [Required(ErrorMessage = "Preencha o nome do tema!")]
        public string Nome { get; set; }

        // Descrição do tema
        [Required(ErrorMessage = "Preencha a descrição sobre o tema!")]
        public string Descricao { get; set; }

        // Imagem vai armazenar a rota onde a imagem esta armazenada
        public string Imagem { get; set; }

        // Link para solicitar festa
        [Required(ErrorMessage = "Preencha o link de solicitação do tema!")]
        public string LinkSolicitarFesta { get; set; }

        // Link para ir para album do facebook
        [Required(ErrorMessage = "Preencha o link de álbum do tema!")]
        public string LinkAlbum { get; set; }

        // Pessoa Jurídica pode ter varios temas
        public int PessoaJuridicaId { get; set; }
        public virtual Fornecedor PessoaJuridica { get; set; }

    }
}