using UnityEngine;

[CreateAssetMenu(fileName = "Job_Data", menuName = "Scriptable Objects/Job_Data")]
public class Job_Data : ScriptableObject
{
    public string jobTitle;
    public int salary;
    public int weeksInbetweenPayment;

    public int weeksAtJob;

    public int lastPaymentWeek;
    public int lastPaymentYear;

    // date stuff
    public int startWeek;
    public int startYear;
    public int endWeek;
    public int endYear;
}
