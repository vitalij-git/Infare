using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebScraper.Models;

namespace WebScraper.Services
{
	public class FlightService
	{
		public FlightModel FlightModel { get; set; } = new FlightModel();
        public List<Journey> Journeys { get; set; } = new List<Journey>();
        public List<TotalAvailability> TotalAvailabilities { get; set; } = new List<TotalAvailability>();
		

        public async Task GetFlightData()
		{
			var url = UriBuilder();
			await HttpRequest(url);
			ExportDataToCSV(FillFlightsCsvModel());
		}
		 string UriBuilder()
		{
			string url = "http://homeworktask.infare.lt/search.php";
			var uriBuilder = new UriBuilder(url);
			var query = HttpUtility.ParseQueryString(uriBuilder.Query);
			query["from"] = "MAD";
			query["to"] = "AUH";
			query["depart"] = "2024-06-24";
			query["return"] = "2024-06-30";
			uriBuilder.Query = query.ToString();
			string requestUrl = uriBuilder.ToString();
			return requestUrl;
		}

		 async Task HttpRequest(string requestUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(requestUrl);

				if (response.IsSuccessStatusCode)
				{
					string responseData = await response.Content.ReadAsStringAsync();

					FlightModel = JsonConvert.DeserializeObject<FlightModel>(responseData);
					Journeys = FlightModel.body.data.journeys;
					TotalAvailabilities = FlightModel.body.data.totalAvailabilities;
				}
			}

		}


		List<FlightCSVModel> FillFlightsCsvModel()
		{
			List<FlightCSVModel> flightCSVModels = new List<FlightCSVModel>();
			var firstDeparture = "";
			var firstArrival = "";
			var firstTimeDeparture = "";
			var firstTimeArrival = "";
			var firstFlightNumber = "";
			double firstTaxes = 0;
			var i = 1;

			foreach(var journey in Journeys)
			{
				//check flight connection, skip if has 2 connections.
				if (journey.flights.Count == 1)
				{
					foreach (var flight in journey.flights)
					{
						if (i % 2 != 0)
						{
							firstDeparture = flight.airportDeparture.code;
							firstArrival = flight.airportArrival.code;
							firstTimeDeparture = flight.dateDeparture;
							firstTimeArrival = flight.dateArrival;
							firstTaxes = journey.importTaxAdl;
							firstFlightNumber = flight.companyCode + flight.number;
							i++;
						}
						else if (i % 2 == 0)
						{
							flightCSVModels.Add(new FlightCSVModel
							{
								RecommendationId = journey.recommendationId,
								Price = TotalAvailabilities.FirstOrDefault(id => id.recommendationId == journey.recommendationId).total,
								Taxes = journey.importTaxAdl + firstTaxes,
								FirstDeparture = firstDeparture,
								FirstArrival = firstArrival,
								FirstTimeDeparture = firstTimeDeparture,
								FirstTimeArrival = firstTimeArrival,
								FirstFlightNumber = firstFlightNumber,
								SecondDeparture = flight.airportDeparture.code,
								SecondArrival = flight.airportArrival.code,
								SecondTimeDeparture = flight.dateDeparture,
								SecondTimeArrival = flight.dateArrival,
								SecondFlightNumber = flight.companyCode + flight.number

							});
							i++;
						}
					}
				}
				
			}

			return flightCSVModels;
		}

		void ExportDataToCSV(List<FlightCSVModel> flightCSVModels)
		{
			// file location
			var projectDirectory = @"E:\\Programavimas\\Infare\\WebScraper";
			var fileName = $"flights-{DateTime.Now.ToFileTime()}.csv";
			var csvPath = Path.Combine(projectDirectory, fileName);
			using(var writer = new StreamWriter(csvPath) )
			{
				using(var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
				{
					var flights = flightCSVModels;
					csvWriter.WriteRecords(flights);
					csvWriter.WriteField("Cheapest price");
					csvWriter.NextRecord();
					csvWriter.WriteRecord(flights.OrderBy(obj => obj.Price).FirstOrDefault());
				}
			}
		}

	}
}
