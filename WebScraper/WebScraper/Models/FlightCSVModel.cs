using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models
{
	public class FlightCSVClassMap : ClassMap<FlightCSVModel>
	{
        public FlightCSVClassMap()
        {
			Map(m => m.RecommendationId).Name("Recommendation Id");
			Map(m => m.Price).Name("Price");
			Map(m => m.Taxes).Name("Taxes");
			Map(m => m.FirstDeparture).Name("outbound 1 airport departure");
			Map(m => m.FirstArrival).Name("outbound 1 airport arrival");
			Map(m => m.FirstTimeDeparture).Name("outbound 1 time departure");
			Map(m => m.FirstTimeArrival).Name("outbound 1 time arrival");
			Map(m => m.FirstFlightNumber).Name("outbound 1 flight number");
			Map(m => m.SecondDeparture).Name("outbound 2 airport departure");
			Map(m => m.SecondArrival).Name("outbound 2 airport arrival");
			Map(m => m.SecondTimeDeparture).Name("outbound 2 time departure");
			Map(m => m.SecondTimeArrival).Name("outbound 2 time arrival");
			Map(m => m.SecondFlightNumber).Name("outbound 2 flight number");
		}

    }
	public class FlightCSVModel
	{
        public int RecommendationId { get; set; }
		public double Price { get; set; }
        public double Taxes { get; set; }
        public string FirstDeparture { get; set; }
		public string FirstArrival { get; set; }
		public string FirstTimeDeparture { get; set; }
		public string FirstTimeArrival { get; set; }
		public string FirstFlightNumber { get; set; }
		public string SecondDeparture { get; set; }
		public string SecondArrival { get; set; }
		public string SecondTimeDeparture { get; set; }
		public string SecondTimeArrival { get; set; }
		public string SecondFlightNumber { get; set; }

	}
}
