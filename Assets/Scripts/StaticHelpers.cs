using UnityEngine;

public static class StaticHelpers
{
    public static void ChangeXPosPerFrame(this Transform transform, float value)
    {
        Vector3 currentPos = transform.position;
        currentPos.x += value * Time.deltaTime;
        transform.position = currentPos;
    }
}
