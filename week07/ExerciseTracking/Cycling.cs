public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes)
    {
        _speed = speedKph;
    }

    public override double GetDistance()
    {
        return _speed * (GetMinutes() / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
