using PriceCharts.Common;

namespace PriceCharts.Client.Service
{
	public interface IPriceService
	{
		public Task<IEnumerable<PriceModelDTO>> GetAll();

        public Task<IEnumerable<PriceModelDTO>> GetTop10();


        public Task<PriceModelDTO> Get(int priceId);
	}
}
