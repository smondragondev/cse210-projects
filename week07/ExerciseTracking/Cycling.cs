public class Cycling : Activity
{
    private double _speed;
    public Cycling(string date, double length, double speed) : base(date, length)
    {
        _speed = speed;
        _name = "Cycling";
    }

    public override double GetDistance()
    {
        return _speed / 60.0 * _length;
    }

    public override double GetPace()
    {
        return 60.0 / _speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }
}