using System.ComponentModel.DataAnnotations;

namespace SistemaFesta.Bussines
{
    public class ValidacaoCNPJAttribute : ValidationAttribute
    {
        public ValidacaoCNPJAttribute()
        {
        }

        // VALIDAÇÃO
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            bool valido = ValidaCNPJ(value.ToString());

            return valido;
        }

        // ALGORITMO PARA VALIDAÇÃO
        public static bool ValidaCNPJ(string cnpj)
        {
            //if (cnpj.Length == 0)
            //    return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;
            string digito;
            string auxiliarCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");

            if (cnpj.Length != 14)
                return false;

            auxiliarCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(auxiliarCnpj[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            auxiliarCnpj = auxiliarCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(auxiliarCnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (!cnpj.EndsWith(digito))
                return false;
            return true;
        }
    }
}