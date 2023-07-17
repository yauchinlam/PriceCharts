using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCharts.Common
{
	public class PriceModelDTO
	{
		public string Name { get; set; }
		public string LowestPrice { get; set; }
		public DateTime DateofLowestPrice { get; set; }
		public string CurrentPrice { get; set; }
		public List<PriceAtTimeDTO> priceAtTime { get; set; }
	}
}
