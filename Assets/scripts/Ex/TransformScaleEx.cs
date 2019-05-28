// IllusionUtility.SetUtility.TransformScaleEx
using UnityEngine;

public static class TransformScaleEx
{
    public static void SetLocalScaleX(this Transform transform, float x)
    {
        Vector3 localScale = transform.localScale;
        float y = localScale.y;
        Vector3 localScale2 = transform.localScale;
        Vector3 vector2 = transform.localScale = new Vector3(x, y, localScale2.z);
    }

    public static void SetLocalScaleY(this Transform transform, float y)
    {
        Vector3 localScale = transform.localScale;
        float x = localScale.x;
        Vector3 localScale2 = transform.localScale;
        Vector3 vector2 = transform.localScale = new Vector3(x, y, localScale2.z);
    }   

    public static void SetLocalScaleZ(this Transform transform, float z)
    {
        Vector3 localScale = transform.localScale;
        float x = localScale.x;
        Vector3 localScale2 = transform.localScale;
        Vector3 vector2 = transform.localScale = new Vector3(x, localScale2.y, z);
    }

    public static void SetLocalScale(this Transform transform, float x, float y, float z)
    {
        Vector3 vector2 = transform.localScale = new Vector3(x, y, z);
    }
}
