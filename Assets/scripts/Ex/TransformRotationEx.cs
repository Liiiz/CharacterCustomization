// IllusionUtility.SetUtility.TransformRotationEx
using UnityEngine;

public static class TransformRotationEx
{
    public static void SetRotationX(this Transform transform, float x)
    {
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        float y = eulerAngles.y;
        Vector3 eulerAngles2 = transform.rotation.eulerAngles;
        Vector3 euler = new Vector3(x, y, eulerAngles2.z);
        transform.rotation = Quaternion.Euler(euler);
    }

    public static void SetRotationY(this Transform transform, float y)
    {
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        float x = eulerAngles.x;
        Vector3 eulerAngles2 = transform.rotation.eulerAngles;
        Vector3 euler = new Vector3(x, y, eulerAngles2.z);
        transform.rotation = Quaternion.Euler(euler);
    }

    public static void SetRotationZ(this Transform transform, float z)
    {
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        float x = eulerAngles.x;
        Vector3 eulerAngles2 = transform.rotation.eulerAngles;
        Vector3 euler = new Vector3(x, eulerAngles2.y, z);
        transform.rotation = Quaternion.Euler(euler);
    }

    public static void SetRotation(this Transform transform, float x, float y, float z)
    {
        Vector3 euler = new Vector3(x, y, z);
        transform.rotation = Quaternion.Euler(euler);
    }

    public static void SetLocalRotationX(this Transform transform, float x)
    {
        Vector3 eulerAngles = transform.localRotation.eulerAngles;
        float y = eulerAngles.y;
        Vector3 eulerAngles2 = transform.localRotation.eulerAngles;
        Vector3 euler = new Vector3(x, y, eulerAngles2.z);
        transform.localRotation = Quaternion.Euler(euler);
    }

    public static void SetLocalRotationY(this Transform transform, float y)
    {
        Vector3 eulerAngles = transform.localRotation.eulerAngles;
        float x = eulerAngles.x;
        Vector3 eulerAngles2 = transform.localRotation.eulerAngles;
        Vector3 euler = new Vector3(x, y, eulerAngles2.z);
        transform.localRotation = Quaternion.Euler(euler);
    }

    public static void SetLocalRotationZ(this Transform transform, float z)
    {
        Vector3 eulerAngles = transform.localRotation.eulerAngles;
        float x = eulerAngles.x;
        Vector3 eulerAngles2 = transform.localRotation.eulerAngles;
        Vector3 euler = new Vector3(x, eulerAngles2.y, z);
        transform.localRotation = Quaternion.Euler(euler);
    }

    public static void SetLocalRotation(this Transform transform, float x, float y, float z)
    {
        Vector3 euler = new Vector3(x, y, z);
        transform.localRotation = Quaternion.Euler(euler);
    }
}
