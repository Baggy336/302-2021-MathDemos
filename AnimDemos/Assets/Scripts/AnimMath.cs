using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath 
{
   public static float Lerp(float min, float max, float p, bool allowExtrapolation = true)
    {
        if(!allowExtrapolation)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }
        return (max - min) * p + min;
    }

    public static Vector3 Lerp(Vector3 min, Vector3 max, float p, bool allowExtrapolation = true)
    {
        if (!allowExtrapolation)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }

        return (max - min) * p + min;
    }
}
