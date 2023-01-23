using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Vector3 WallSize = new Vector3(1, 1, 1);

    private void OnDrawGizmos(){
        if(this.transform.childCount < 2){
            return;
        }

        //A line will be drawn between each waypoint
        for(int i = 0; i < this.transform.childCount - 1; i++){
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(this.transform.GetChild(i).position, this.transform.GetChild(i + 1).position);
        }

        //Making the last line red
        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.GetChild(this.transform.childCount - 1).position, this.transform.GetChild(0).position);
    }
}
