using UnityEngine;

public class Util
{
    public static float EaseOutPow(float t, float pow, float min, float max)
    {
        float e = 1 - Mathf.Pow(1 - t, pow);
        return min * (1 - e) + max * e;
    }
}
