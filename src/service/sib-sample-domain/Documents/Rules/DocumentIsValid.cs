﻿namespace SibSample.Domain.Documents.Rules
{
    using System;
    using Core.Domain;
    using SeedWorks.Logs;
    using static System.Int32;


    public class DocumentIsValid : IBusinessRule
    {
        private readonly string _cnpj;

        public DocumentIsValid(string cnpj)
        {
            _cnpj = cnpj;
        }

        public string Message => "Document does match with CNPJ";

        public bool IsBroken()
        {
            return !IsDoesMatchCnpj(_cnpj);
        }

        private static bool IsDoesMatchCnpj(string cnpj)
        {
            try
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
            catch (Exception e)
            {
                Log.Error(new {details = "Error on verify cnpj", exception = new {e.Message, e.InnerException}});
                return false;
            }
        }
    }
}