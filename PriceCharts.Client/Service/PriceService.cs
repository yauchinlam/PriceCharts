using Newtonsoft.Json;
using PriceCharts.Common;

namespace PriceCharts.Client.Service
{
	public class PriceService : IPriceService
	{
		private readonly HttpClient _httpClient;
		private IConfiguration _configuration;
		private string BaseServerUrl;
		public PriceService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
			BaseServerUrl = _configuration.GetSection("APIUrl").Value;
		}
		public async Task<PriceModelDTO> Get(int priceId)
		{
			var response = await _httpClient.GetAsync($"/api/price/{priceId}");
			var content = await response.Content.ReadAsStringAsync();
			if (response.IsSuccessStatusCode)
			{
				var product = JsonConvert.DeserializeObject<PriceModelDTO>(content);
				return product;
			}
			else
			{
				var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
				throw new Exception(errorModel.ErrorMessage);
			}
		}

		public async Task<IEnumerable<PriceModelDTO>> GetAll()
		{
			var response = await _httpClient.GetAsync("/api/price");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var prices = JsonConvert.DeserializeObject<IEnumerable<PriceModelDTO>>(content);
				return prices;
			}

			return new List<PriceModelDTO>();
		}

        public async Task<IEnumerable<PriceModelDTO>> GetTop10()
        {
            var response = await _httpClient.GetAsync("/api/price/top10");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var prices = JsonConvert.DeserializeObject<IEnumerable<PriceModelDTO>>(content);
                return prices;
            }

            return new List<PriceModelDTO>();
        }
    }
}
