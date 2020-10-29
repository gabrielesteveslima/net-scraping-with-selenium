namespace CipScrapingBot
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPageObject
    {
        Task<List<Bank>> RunWebScraping();
    }
}