using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperRect
{
    public static RectTransform GetRect(this GameObject rect)
    {
        return rect.GetComponent<RectTransform>();
    }
}