using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SistemaFesta.Bussines
{
    public class ValidacaoTelefoneAttribute : ValidationAttribute
    {
        public ValidacaoTelefoneAttribute()
        {
        }

        // VALIDAÇÃO
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return false;

            bool valido = ValidaTelefone(value.ToString());

            return valido;
        }

        // ALGORITMO PARA VALIDAR TELEFONE
        public bool ValidaTelefone(string telefone)
        {
            telefone = telefone.Trim();
            telefone = telefone.Replace(".", "").Replace("-", "").Replace("_", "").Replace("(", "").Replace(")", "");
            if (telefone.Length < 11)
                return false;
            return true;
        }
    }
}