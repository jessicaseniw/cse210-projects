using System;
using System.Collections.Generic;

// Base class representing an activity
public abstract class Activity
{
    protected DateTime ActivityDate { get; }
    protected int ActivityLengthMinutes { get; }

    protected Activity(DateTime date, int lengthMinutes)
    {
        ActivityDate = date;
        ActivityLengthMinutes = lengthMinutes;
    }

    public abstract double CalculateDistance();
    public abstract double CalculateSpeed();
    public abstract double CalculatePace();

    public virtual string GetSummary()
    {
        double distance = CalculateDistance();
        double speed = CalculateSpeed();
        double pace = CalculatePace();

        return $"{ActivityDate.ToShortDateString()} {GetType().Name} ({ActivityLengthMinutes} min) - Distance: {distance:F2} miles, Speed: {speed:F2} mph, Pace: {pace:F2} min per mile";
    }
}

// Derived class for running activity
public class Running : Activity
{
    public double DistanceInMiles { get; }

    public Running(DateTime date, int lengthMinutes, double distanceMiles)
        : base(date, lengthMinutes)
    {
        DistanceInMiles = distanceMiles;
    }

    public override double CalculateDistance()
    {
        return DistanceInMiles;
    }

    public override double CalculateSpeed()
    {
        return (DistanceInMiles / ActivityLengthMinutes) * 60;
    }

    public override double CalculatePace()
    {
        return ActivityLengthMinutes / DistanceInMiles;
    }
}

// Derived class for cycling activity
public class Cycling : Activity
{
    public double SpeedInKph { get; }

    public Cycling(DateTime date, int lengthMinutes, double speedKph)
        : base(date, lengthMinutes)
    {
        SpeedInKph = speedKph;
    }

    public override double CalculateSpeed()
    {
        return SpeedInKph;
    }

    public override double CalculateDistance()
    {
        return (SpeedInKph * ActivityLengthMinutes) / 60;
    }

    public override double CalculatePace()
    {
        return 60 / SpeedInKph;
    }
}

// Derived class for swimming activity
public class Swimming : Activity
{
    public int Laps { get; }

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        Laps = laps;
    }

    public override double CalculateDistance()
    {
        return Laps * 50 / 1000 * 0.62; // Convert laps to miles
    }

    public override double CalculateSpeed()
    {
        return (CalculateDistance() / ActivityLengthMinutes) * 60;
    }

    public override double CalculatePace()
    {
        return ActivityLengthMinutes / CalculateDistance();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create list of different activity types
        List<Activity> activities = new List<Activity>
        {
            new Running(DateTime.Parse("2024-04-03"), 30, 3.0),
            new Cycling(DateTime.Parse("2024-04-03"), 30, 12.0),
            new Swimming(DateTime.Parse("2024-04-03"), 30, 20)
        };

        // Display summary information for each activity
        Console.WriteLine("Activity Summaries:");
        Console.WriteLine("===================");

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}