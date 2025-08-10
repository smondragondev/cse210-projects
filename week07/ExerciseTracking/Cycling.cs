public class Cycling : Activity
{
    private double _speed;
    public Cycling(string date, int length, double speed) : base(date, length)
    {
        _speed = speed;
        _name = "Cycling";
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