using UnityEngine;
using UnityEditor;

public class MenuItems : MonoBehaviour
{
    [MenuItem("Tools/PaintAllObjects")]
    public static void PaintAllObjects()
    {
        var obj = FindObjectsOfType<Renderer>();
        foreach (var item in obj)
            item.material.SetColor("_Color", Color.red);
    }
}
