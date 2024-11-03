using UnityEngine;

public static class StaticHelpers
{
    public static void ChangeXPosPerFrame(this Transform transform, float value)
    {
        Vector3 currentPos = transform.position;
        currentPos.x += value * Time.deltaTime;
        transform.position = currentPos;
    }

    public static float Remap (this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }


    public static int Remap (this int value, int fromMin, int fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }
}
