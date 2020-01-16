using SistemaFesta.Bussines;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaFesta.Models
{
    public class Fornecedor : Login
    {
        // Nome 
        [Required(ErrorMessage = "Preencha seu nome!"), MaxLength(100, ErrorMessage = "Número de caracteres excedido!")]
        public string Nome { get; set; }

        // CPF
        [Required(ErrorMessage = "Preencha seu CPF!")]
        [ValidacaoCPF(ErrorMessage = "CPF inválido!")]
        public string CPF { get; set; }

        // Nome da empresa
        [Required(ErrorMessage = "Preencha o nome da sua empresa!")]
        public string NomeEmpresa { get; set; }

        // CNPJ
        [ValidacaoCNPJ(ErrorMessage = "CNPJ inválido!")]
        public string CNPJ { get; set; }

        // Telefone
        [Required(ErrorMessage = "Preencha seu telefone de contato!")]
        [ValidacaoTelefone(ErrorMessage = "Número inválido!")]
        public string Telefone { get; set; }

        // Email
        [Required(ErrorMessage = "Preencha seu email!")]
        [ValidacaoEmail(ErrorMessage = "Email inválido!")]
        public string Email { get; set; }

        // Confirmar Senha
        [Required(ErrorMessage = "Campo obrigatório!"), MaxLength(40, ErrorMessage = "Número de caracteres excedido!")]
        [Compare("Senha", ErrorMessage = "Senhas diferentes!")]
        public string ComfirmarSenha { get; set; }

        // Pessoa Jurídica pode ter varios temas
        public virtual IList<Tema> Temas { get; set; }
    }
}