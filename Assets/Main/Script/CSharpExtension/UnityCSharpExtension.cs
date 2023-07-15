using System.Collections.Generic;
using UnityEngine;

public static class UnityCSharpExtension
{
    public static int GetArrayIndex(List<string> array, string item)
    {
        int ret = array.Count + 1;

        for (int i = 0; i < array.Count; i++)
        {
            if (array[i] == item)
            {
                ret = i;
                break;
            }
        }

        return ret;
    }

    public static float InterpolateValue(float currentValue, float minValue, float maxValue)
    {

        float clampedValue = Mathf.Clamp(currentValue, minValue, maxValue);


        float normalizedValue = (clampedValue - minValue) / (maxValue - minValue);


        return Mathf.Lerp(0f, 1f, normalizedValue);
    }

    public static float BicubicInterpolation(float t)
    {
        float a = -0.5f;  // Bicubic interpolation parameter

        // Apply bicubic interpolation formula
        float p = t * (t * (t * -a + (2 - a)) + (a - 3));
        float q = t * t * (t * (2 * a - 3) + (3 - 2 * a));
        float r = t * (t * (t * -a + (a - 2)) + 1);
        float s = t * t * (t * (a - 1) + a);

        // Return the interpolated value
        return p + q + r + s;
    }


}
