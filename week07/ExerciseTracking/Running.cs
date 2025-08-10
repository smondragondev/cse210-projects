public class Running : Activity
{
    private double _distance;
    public Running(string date, int length, double distance) : base(date, length)
    {
        _name = "Running";
        _distance = distance;
    }

    public override double GetDistance()
    {
        throw new NotImplementedException();
    }

    public override double GetPace()
    {
        throw new NotImplementedException();
    }

    public override double GetSpeed()
    {
        throw new NotImplementedException();
    }
}