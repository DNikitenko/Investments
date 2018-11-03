using System;

internal class WeeklyValue
{
    public DateTime Date { get; set; }

    public double Price { get; set; }

    public double? MovingAverage3Weeks { get; set; }

    public double? MovingAverage30Weeks { get; set; }

    public double? MovingAverage3WeeksDerivative { get; set; }

    public double? MovingAverage30WeeksDerivative { get; set; }

    public double? DerivativeDifference => MovingAverage3WeeksDerivative - MovingAverage30WeeksDerivative;

    public WeeklyValue(string csvValue)
    {
        var splittedRawValue = csvValue.Split(";");

        Date = DateTime.Parse(splittedRawValue[0]);
        Price = Double.Parse(splittedRawValue[1]);
        MovingAverage3Weeks = String.IsNullOrEmpty(splittedRawValue[2]) ? (double?)null : Double.Parse(splittedRawValue[2]);
        MovingAverage30Weeks = String.IsNullOrEmpty(splittedRawValue[3]) ? (double?)null : Double.Parse(splittedRawValue[3]);
        MovingAverage3WeeksDerivative = String.IsNullOrEmpty(splittedRawValue[4]) ? (double?)null : Double.Parse(splittedRawValue[4]);
        MovingAverage30WeeksDerivative = String.IsNullOrEmpty(splittedRawValue[5]) ? (double?)null : Double.Parse(splittedRawValue[5]);
    }
}