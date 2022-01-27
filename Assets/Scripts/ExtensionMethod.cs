using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperBehavior
{
    public static RectTransform GetRect(this Behaviour obj)
    {
        return obj.GetComponent<RectTransform>();
    }
}

public static class HelperGameObject
{
    public static RectTransform GetRect(this GameObject obj)
    {
        return obj.GetComponent<RectTransform>();
    }
}