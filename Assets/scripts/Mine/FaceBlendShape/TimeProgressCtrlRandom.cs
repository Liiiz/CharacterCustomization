// FBSAssist.TimeProgressCtrlRandom
using UnityEngine;

public class TimeProgressCtrlRandom : TimeProgressCtrl
{
    private float minTime = 0.1f;

    private float maxTime = 0.2f;

    public TimeProgressCtrlRandom()
        : base(0.15f)
    {
    }

    public void Init(float min, float max)
    {
        minTime = min;
        maxTime = max;
        base.SetProgressTime(Random.Range(minTime, maxTime));
        base.Start();
    }

    public new float Calculate()
    {
        float num = base.Calculate();
        if (num == 1f)
        {
            base.SetProgressTime(Random.Range(minTime, maxTime));
            base.Start();
        }
        return num;
    }

    public float Calculate(float _minTime, float _maxTime)
    {
        minTime = _minTime;
        maxTime = _maxTime;
        return Calculate();
    }
}
