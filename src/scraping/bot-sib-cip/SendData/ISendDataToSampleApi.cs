namespace CipScrapingBot.SendData
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISendDataToSampleApi
    {
        Task Share(IEnumerable<Bank> banks);
    }
}