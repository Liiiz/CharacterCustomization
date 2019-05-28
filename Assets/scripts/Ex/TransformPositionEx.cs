// IllusionUtility.SetUtility.TransformPositionEx
using UnityEngine;

public static class TransformPositionEx
{
    public static void SetPositionX(this Transform transform, float x)
    {
        Vector3 position = transform.position;
        float y = position.y;
        Vector3 position2 = transform.position;
        Vector3 vector2 = transform.position = new Vector3(x, y, position2.z);
    }

    public static void SetPositionY(this Transform transform, float y)
    {
        Vector3 position = transform.position;
        float x = position.x;
        Vector3 position2 = transform.position;
        Vector3 vector2 = transform.position = new Vector3(x, y, position2.z);
    }

    public static void SetPositionZ(this Transform transform, float z)
    {
        Vector3 position = transform.position;
        float x = position.x;
        Vector3 position2 = transform.position;
        Vector3 vector2 = transform.position = new Vector3(x, position2.y, z);
    }

    public static void SetPosition(this Transform transform, float x, float y, float z)
    {
        Vector3 vector2 = transform.position = new Vector3(x, y, z);
    }

    public static void SetLocalPositionX(this Transform transform, float x)
    {
        Vector3 localPosition = transform.localPosition;
        float y = localPosition.y;
        Vector3 localPosition2 = transform.localPosition;
        Vector3 vector2 = transform.localPosition = new Vector3(x, y, localPosition2.z);
    }

    public static void SetLocalPositionY(this Transform transform, float y)
    {
        Vector3 localPosition = transform.localPosition;
        float x = localPosition.x;
        Vector3 localPosition2 = transform.localPosition;
        Vector3 vector2 = transform.localPosition = new Vector3(x, y, localPosition2.z);
    }

    public static void SetLocalPositionZ(this Transform transform, float z)
    {
        Vector3 localPosition = transform.localPosition;
        float x = localPosition.x;
        Vector3 localPosition2 = transform.localPosition;
        Vector3 vector2 = transform.localPosition = new Vector3(x, localPosition2.y, z);
    }

    public static void SetLocalPosition(this Transform transform, float x, float y, float z)
    {
        Vector3 vector2 = transform.localPosition = new Vector3(x, y, z);
    }
}
