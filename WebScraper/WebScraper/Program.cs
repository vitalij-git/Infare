using System.Web;
using WebScraper.Services;

namespace WebScraper
{
	public class Program
	{
		 static async Task Main(string[] args)
		{
			var flightService = new FlightService();
			await flightService.GetFlightData();

		}

		

	}
}