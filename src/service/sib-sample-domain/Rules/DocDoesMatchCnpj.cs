namespace SibSample.Domain.Rules
{
    using Core.Domain;
    using static System.Int32;


    public class DocDoesMatchCnpj : IBusinessRule
    {
        private readonly string _cnpj;

        public DocDoesMatchCnpj(string cnpj)
        {
            _cnpj = cnpj;
        }

        public string Message => "User document does match with CNPJ";

        public bool IsBroken()
        {
            return !IsDoesMatchCnpj(_cnpj);
        }

        private static bool IsDoesMatchCnpj(string cnpj)
        {
            const int totalLengthValid = 14;

            var mult1 = new[] {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
            var mult2 = new[] {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

            var cnpjCompleted = cnpj.PadLeft(totalLengthValid, '0').Substring(0, 12);

            var sum = 0;
            for (var i = 0; i < 12; i++)
            {
                sum += Parse(cnpjCompleted[i].ToString()) * mult1[i];
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
            cnpjCompleted += digit;

            sum = 0;
            for (var i = 0; i < 13; i++)
            {
                sum += Parse(cnpjCompleted[i].ToString()) * mult2[i];
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
            return cnpj.EndsWith(digit);
        }
    }
}