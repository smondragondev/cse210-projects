public class Swimming : Activity
{
    private int _lapsNumber;
    public Swimming(string date, int length, int lapsNumber) : base(date, length)
    {
        _lapsNumber = lapsNumber;
        _name = "Swimming";
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