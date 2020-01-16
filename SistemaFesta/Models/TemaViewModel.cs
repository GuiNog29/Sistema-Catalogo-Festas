using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SistemaFesta.Models
{
    // Utilizei uma ModelView para cadastrar imagem
    public class TemaViewModel
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

        // Método onde vai armazenar a imagem
        [Required(ErrorMessage = "Selecione uma imagem!")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

        // Link para solicitar festa
        [Required(ErrorMessage = "Preencha o link de solicitação do tema!")]
        public string LinkPedirFesta { get; set; }

        // Link para ir para album do facebook
        [Required(ErrorMessage = "Preencha o link de álbum do tema!")]
        public string LinkAlbumFacebook { get; set; }

        // Somente Pessoa Jurídica pode fazer upload de imagem
        public int FornecedorId { get; set; }
    }
}