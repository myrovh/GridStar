using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Graph))]
class GraphEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Graph component = (Graph)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Rebuild Graph"))
        {
            component.BuildGraph();
        }
    }
}