// MathfEx
using UnityEngine;

public static class MathfEx
{
    public delegate float Func(float x);

    public static float LerpAccel(float from, float to, float t)
    {
        return Mathf.Lerp(from, to, Mathf.Sqrt(t));
    }

    public static bool RangeEqualOn(int min, int n, int max)
    {
        return min <= n && max >= n && true;
    }

    public static bool RangeEqualOn(float min, float n, float max)
    {
        return min <= n && max >= n && true;
    }

    public static bool RangeEqualOff(int min, int n, int max)
    {
        return min < n && max > n && true;
    }

    public static bool RangeEqualOff(float min, float n, float max)
    {
        return min < n && max > n && true;
    }

    public static float LerpBrake(float from, float to, float t)
    {
        return Mathf.Lerp(from, to, t * (2f - t));
    }

    public static float NewtonMethod(Func func, Func derive, float initX, int maxLoop)
    {
        float num = initX;
        for (int i = 0; i < maxLoop; i++)
        {
            float num2 = func(num);
            if (num2 < 1E-05f && num2 > -1E-05f)
            {
                break;
            }
            num -= num2 / derive(num);
        }
        return num;
    }

    public static void LoopValue(ref int value, int start, int end)
    {
        if (value > end)
        {
            value = start;
        }
        else if (value < start)
        {
            value = end;
        }
    }

    public static Rect AspectRect(float baseH = 1280f, float rate = 720f)
    {
        float y = ((float)Screen.height - (float)Screen.width / baseH * rate) * 0.5f / (float)Screen.height;
        float height = rate * (float)Screen.width / baseH / (float)Screen.height;
        return new Rect(0f, y, 1f, height);
    }

    public static long Min(long _a, long _b)
    {
        return (_a <= _b) ? _a : _b;
    }

    public static long Max(long _a, long _b)
    {
        return (_a <= _b) ? _b : _a;
    }

    public static long Clamp(long _value, long _min, long _max)
    {
        return Min(Max(_value, _min), _max);
    }

    public static float ToRadian(float degree)
    {
        return degree * 0.0174532924f;
    }

    public static float ToDegree(float radian)
    {
        return radian * 57.29578f;
    }
}
