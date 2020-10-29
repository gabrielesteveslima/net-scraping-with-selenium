namespace CipScrapingBot.SendData
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Configuration;
    using Flurl;
    using Flurl.Http;
    using Flurl.Http.Configuration;
    using JsonApiSerializer;
    using Newtonsoft.Json;

    public class SendDataToSampleApi : ISendDataToSampleApi
    {
        private readonly SibApiConfig _sibApiConfig;

        public SendDataToSampleApi(SibApiConfig sibApiConfig)
        {
            _sibApiConfig = sibApiConfig;
        }

        public async Task Share(IEnumerable<Bank> banks)
        {
            var serialize = JsonConvert.SerializeObject(banks,
                new JsonApiSerializerSettings());
            
            await _sibApiConfig.ImportDataPath
                .AppendPathSegment("import-data")
                .ConfigureRequest(setup =>
                {
                    setup.JsonSerializer = new NewtonsoftJsonSerializer(new JsonApiSerializerSettings()
                    {
                    });
                })
                .PostJsonAsync(banks);
        }
    }
}