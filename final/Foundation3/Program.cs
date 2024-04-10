using System;

// Class representing an address
public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string StateProvince { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string stateProvince, string country)
    {
        Street = street;
        City = city;
        StateProvince = stateProvince;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {StateProvince}, {Country}";
    }
}

// Base class representing an event
public abstract class Event
{
    private string _eventTitle;
    private string _description;
    private DateTime _date;
    private string _time;
    private Address _eventAddress;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        _eventTitle = title;
        _description = description;
        _date = date;
        _time = time;
        _eventAddress = address;
    }

    public string GetStandardDetails()
    {
        return $"Event: {_eventTitle}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nAddress: {_eventAddress}\n";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nEvent: {_eventTitle}\nDate: {_date.ToShortDateString()}\n";
    }
}

// Derived class for lectures
public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + $"Type: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}\n";
    }
}

// Derived class for receptions
public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + $"Type: Reception\nRSVP Email: {_rsvpEmail}\n";
    }
}

// Derived class for outdoor gatherings
public class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return GetStandardDetails() + $"Type: Outdoor Gathering\nWeather Forecast: {_weatherForecast}\n";
    }
}

// Main program
public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Oak Ave", "Othercity", "NY", "USA");
        Address address3 = new Address("789 Elm St", "Anothercity", "TX", "USA");

        // Create events
        Event lectureEvent = new Lecture("Introduction to Programming", "Learn the basics of programming", DateTime.Parse("2024-04-15"), "10:00 AM", address1, "John Smith", 50);
        Event receptionEvent = new Reception("Networking Reception", "Join us for networking and refreshments", DateTime.Parse("2024-05-20"), "6:00 PM", address2, "info@example.com");
        Event outdoorEvent = new OutdoorGathering("Summer Picnic", "Enjoy a picnic in the park", DateTime.Parse("2024-06-30"), "12:00 PM", address3, "Sunny with a chance of showers");

        // Display marketing messages for each event
        Console.WriteLine("Marketing Messages:");
        Console.WriteLine("===================");

        Console.WriteLine("\nStandard Details:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(outdoorEvent.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(outdoorEvent.GetFullDetails());

        Console.WriteLine("\nShort Descriptions:");
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}