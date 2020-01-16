using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SistemaFesta.Bussines
{
    public class ValidacaoEmailAttribute : ValidationAttribute
    {
        public ValidacaoEmailAttribute()
        {
        }

        // VALIDAÇÃO
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return false;

            bool valido = ValidaEmail(value.ToString());

            return valido;
        }

        // ALGORITMO PARA VALIDAR EMAIL
        public bool ValidaEmail(string email)
        {
            if (email.Length == 0)
                return false;

            string modeloInvalido = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}" + "\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\" + ".)+))([a-zA-Z]{2,4}|[0,9]{1,3})(\\]?)$";

            Regex regex = new Regex(modeloInvalido);

            if (!regex.IsMatch(email))
                return false;

            return true;
        }
    }
}