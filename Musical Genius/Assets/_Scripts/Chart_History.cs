using System;

[Serializable]
public class ChartHistory
{
    public string chartName;
    public int peakPosition;
    public int debutPosition;
    public int weeksOnChart;
    // This u need to calculate
    public int streams;
    public int DigitalSales;
    public int PureSales;
    public int RadioService;

    //gets calculated
    public int currentPoints;
    public int currentPosition;
}