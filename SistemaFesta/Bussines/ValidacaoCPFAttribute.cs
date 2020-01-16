using System.ComponentModel.DataAnnotations;

namespace SistemaFesta.Bussines
{
    public class ValidacaoCPFAttribute : ValidationAttribute
    {
        public ValidacaoCPFAttribute()
        {
        }

        // Validação
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return false;
            bool valido = ValidaCPF(value.ToString());
            return valido;
        }

        // Valida se um cpf é válido       
        public static bool ValidaCPF(string cpf)
        {
            //if (cpf.Length == 0)
            //    return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string auxiliarCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("_", "");

            if (cpf.Length != 11)
                return false;

            auxiliarCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(auxiliarCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            auxiliarCpf = auxiliarCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(auxiliarCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (!cpf.EndsWith(digito))
                return false;

            return true;
        }
    }
}