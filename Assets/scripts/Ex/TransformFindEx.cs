// IllusionUtility.GetUtility.TransformFindEx
using System;
using System.Collections.Generic;
using UnityEngine;

public static class TransformFindEx
{
    public static GameObject FindLoop(this Transform transform, string name)
    {
        if (string.Compare(name, transform.gameObject.name) == 0)
        {
            return transform.gameObject;
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject gameObject = FindLoop(transform.GetChild(i), name);
            if ((UnityEngine.Object)null != (UnityEngine.Object)gameObject)
            {
                return gameObject;
            }
        }
        return null;
    }

    public static void FindLoopPrefix(this Transform transform, List<GameObject> list, string name)
    {
        if (string.Compare(name, 0, transform.gameObject.name, 0, name.Length) == 0)
        {
            list.Add(transform.gameObject);
        }
        foreach (Transform item in transform)
        {
            FindLoopPrefix(item, list, name);
        }
    }

    public static void FindLoopTag(this Transform transform, List<GameObject> list, string tag)
    {
        if (transform.gameObject.CompareTag(tag))
        {
            list.Add(transform.gameObject);
        }
        foreach (Transform item in transform)
        {
            FindLoopTag(item, list, tag);
        }
    }

    public static void FindLoopAll(this Transform transform, List<GameObject> list)
    {
        list.Add(transform.gameObject);
        foreach (Transform item in transform)
        {
            FindLoopAll(item, list);
        }
    }

    public static GameObject FindTop(this Transform transform)
    {
        return (!((UnityEngine.Object)null == (UnityEngine.Object)transform.parent)) ? FindTop(transform.parent) : transform.gameObject;
    }

    public static GameObject[] FindRootObject(this Transform transform)
    {
        return Array.FindAll(UnityEngine.Object.FindObjectsOfType<GameObject>(), (GameObject item) => (UnityEngine.Object)item.transform.parent == (UnityEngine.Object)null);
    }
}
