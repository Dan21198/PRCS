using System;
using System.Runtime.InteropServices;
[Serializable]
public class Electricity
{
	private DateTime time;
    private double value;
	private string? comment;
    private double cost;

    public Electricity()   {  }

    public Electricity(DateTime time, double value, string? comment, double cost)
	{
		this.time = time;
		this.value = value;
		this.comment = comment;
        this.cost = cost;
    }

	public DateTime Time { get; set; }
	public double Value { get; set; }
	public string Comment { get; set; }
    public double Cost { get; set; }

}
