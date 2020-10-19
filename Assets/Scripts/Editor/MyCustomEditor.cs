using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyWall))]
public class MyCustomEditor : Editor
{
    private MyWall _myWall = new MyWall();
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _myWall = target as MyWall;
        EditorGUILayout.LabelField("defColor", _myWall.ToString());
        if (GUILayout.Button("Reset Color"))
        {
            _myWall.ResetColor();
        }
    }
    
}
