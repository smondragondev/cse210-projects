public class Swimming : Activity
{
    private int _lapsNumber;
    public Swimming(string date, double length, int lapsNumber) : base(date, length)
    {
        _lapsNumber = lapsNumber;
        _name = "Swimming";
    }

    public override double GetDistance()
    {
        return _lapsNumber * 50.0 / 1000;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }

    public override double GetSpeed()
    {
        return GetDistance() / _length * 60;
    }
}