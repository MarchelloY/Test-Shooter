using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyWall))]
public class MyCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var _myWall = target as MyWall;
        EditorGUILayout.LabelField("defColor", _myWall.ToString());
        if (GUILayout.Button("Reset Color"))
        {
            _myWall.ResetColor();
        }
    }
    
}
