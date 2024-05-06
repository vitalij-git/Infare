using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.Models
{
	public class FlightModel
	{
		public Header header { get; set; }
		public Body body { get; set; }
	}

	
	public class AirportArrival
	{
		public string code { get; set; }
		public string description { get; set; }
		public bool resident { get; set; }
		public string type { get; set; }
		public string zone { get; set; }
		public string image { get; set; }
	}

	public class AirportDeparture
	{
		public string code { get; set; }
		public string description { get; set; }
		public bool resident { get; set; }
		public string type { get; set; }
		public string zone { get; set; }
		public string image { get; set; }
	}

	public class AvailabilityFactor
	{
		public string availabilityProviderType { get; set; }
		public string availabilityProviderReasonType { get; set; }
	}

	public class BaggageWeight
	{
		public double amount { get; set; }
		public MeasurementType measurementType { get; set; }
	}

	public class Body
	{
		public Data data { get; set; }
	}

	public class CabinClass
	{
		public string code { get; set; }
		public string description { get; set; }
	}

	public class CabinInformation
	{
		public int number { get; set; }
		public BaggageWeight baggageWeight { get; set; }
		public string description { get; set; }
	}

	public class Data
	{
		public string sessionId { get; set; }
		public string availabilityId { get; set; }
		public string locale { get; set; }
		public string marketCode { get; set; }
		public bool swirt { get; set; }
		public bool switax { get; set; }
		public bool swisdto { get; set; }
		public int adultPax { get; set; }
		public int childPax { get; set; }
		public int infantPax { get; set; }
		public int adultPaxResident { get; set; }
		public int childPaxResident { get; set; }
		public int infantPaxResident { get; set; }
		public List<object> messageItemization { get; set; }
		public int serviceFee { get; set; }
		public int serviceFeeDiscount { get; set; }
		public int serviceFeeResidentDiscount { get; set; }
		public List<TotalAvailability> totalAvailabilities { get; set; }
		public List<Journey> journeys { get; set; }
		public List<object> calendarJourneys { get; set; }
		public List<object> journeyConstraint { get; set; }
		public string blockType { get; set; }
		public AvailabilityFactor availabilityFactor { get; set; }
		public bool showDiscounts { get; set; }
		public string discountLabel { get; set; }
		public bool swiservicefee { get; set; }
		public string availabilityZoneType { get; set; }
	}

	public class FareFamily
	{
		public string code { get; set; }
		public string description { get; set; }
	}

	public class Flight
	{
		public string number { get; set; }
		public AirportDeparture airportDeparture { get; set; }
		public AirportArrival airportArrival { get; set; }
		public string dateDeparture { get; set; }
		public string dateArrival { get; set; }
		public string gmtDateDeparture { get; set; }
		public string gmtDateArrival { get; set; }
		public string companyCode { get; set; }
		public string @operator { get; set; }
		public Flote flote { get; set; }
		public TechnicalStop technicalStop { get; set; }
		public string terminalDeparture { get; set; }
		public string terminalArrival { get; set; }
		public CabinClass cabinClass { get; set; }
	}

	public class Flote
	{
		public string code { get; set; }
		public string description { get; set; }
	}

	public class FranchiseInformation
	{
		public int franchise { get; set; }
		public BaggageWeight baggageWeight { get; set; }
		public bool hiringSupported { get; set; }
		public string description { get; set; }
	}

	public class Header
	{
		public string message { get; set; }
		public int code { get; set; }
		public bool error { get; set; }
		public string bodyType { get; set; }
	}

	public class Journey
	{
		public int recommendationId { get; set; }
		public int identity { get; set; }
		public string direction { get; set; }
		public string cabinClass { get; set; }
		public double importChild { get; set; }
		public double importInfant { get; set; }
		public int importAdultResident { get; set; }
		public int importChildResident { get; set; }
		public int importInfantResident { get; set; }
		public int discountAdultResident { get; set; }
		public int discountChildResident { get; set; }
		public int discountInfantResident { get; set; }
		public double importTaxAdl { get; set; }
		public double importTaxChd { get; set; }
		public double importTaxInf { get; set; }
		public string classCode { get; set; }
		public string farebasisCode { get; set; }
		public object promotionLabel { get; set; }
		public List<Flight> flights { get; set; }
		public List<object> businessJourneys { get; set; }
		public int passengersAvailable { get; set; }
		public FareFamily fareFamily { get; set; }
		public FranchiseInformation franchiseInformation { get; set; }
		public CabinInformation cabinInformation { get; set; }
	}

	public class MeasurementType
	{
		public string code { get; set; }
		public string description { get; set; }
	}



	public class TechnicalStop
	{
		public int numberStops { get; set; }
		public List<object> airportStops { get; set; }
	}

	public class TotalAvailability
	{
		public int recommendationId { get; set; }
		public double total { get; set; }
	}


}
