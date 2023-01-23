using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Waypoints))]

public class WaypointsEditor : Editor
{
    public override void OnInspectorGUI(){
        base.OnInspectorGUI();

        Waypoints script = (Waypoints)target;

        GUI.backgroundColor = Color.yellow;

        if(GUILayout.Button("Angle Size Waypoint Walls") == true){
            script.AngleSizeWaypointWalls();
        }

        GUILayout.Label(script.Description());
    }
}
