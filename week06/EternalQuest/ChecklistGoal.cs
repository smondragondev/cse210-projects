public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }
        _amountCompleted++;
        int computedPoints = _target == _amountCompleted ? _points + _bonus : _points;
        return computedPoints;
    }

    public override bool IsComplete()
    {
        return _target == _amountCompleted;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted} / {_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName}|{_description}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }
}