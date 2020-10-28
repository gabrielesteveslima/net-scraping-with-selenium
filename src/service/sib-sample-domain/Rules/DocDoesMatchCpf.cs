namespace SibSample.Domain.Rules
{
    using Core.Domain;
    using static System.Int32;

    public class DocDoesMatchCpf : IBusinessRule
    {
        private readonly string _cpf;

        public DocDoesMatchCpf(string cpf)
        {
            _cpf = cpf;
        }

        public string Message => "User document does match with CPF";

        public bool IsBroken()
        {
            return !IsDoesMatchCpf(_cpf);
        }

        private static bool IsDoesMatchCpf(string cpf)
        {
            const int totalLengthValid = 11;

            var mult1 = new[] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            var mult2 = new[] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            string cpfCompleted;

            //there is a rule that only the first 3 digits of the cpf can be sequentially 0
            if (cpf.Length < 8)
            {
                return false;
            }

            cpfCompleted = cpf.PadLeft(totalLengthValid, '0').Substring(0, 9);
            var sum = 0;

            for (var i = 0; i < 9; i++)
            {
                sum += Parse(cpfCompleted[i].ToString()) * mult1[i];
            }

            var restDiv = sum % 11;

            if (restDiv < 2)
            {
                restDiv = 0;
            }
            else
            {
                restDiv = 11 - restDiv;
            }

            var digit = restDiv.ToString();
            cpfCompleted += digit;
            sum = 0;

            for (var i = 0; i < 10; i++)
            {
                sum += Parse(cpfCompleted[i].ToString()) * mult2[i];
            }

            restDiv = sum % 11;

            if (restDiv < 2)
            {
                restDiv = 0;
            }
            else
            {
                restDiv = 11 - restDiv;
            }

            digit += restDiv;
            return cpf.EndsWith(digit);
        }
    }
}