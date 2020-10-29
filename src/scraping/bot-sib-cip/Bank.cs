namespace CipScrapingBot
{
    using System;

    public class Bank
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Document { get; set; }
        public string ISPB { get; set; }
    }
}