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

    public void AngleSizeWaypointWalls(){
        Transform currentWaypoint;
        Transform nextWaypoint;
        Transform previousWaypoint;

        int next;
        int previous;

        Quaternion currentRotation;
        Quaternion previousRotation;

        for(int i = 0; i < this.transform.childCount; i++){
            next = idxNextWaypoint(i);
            previous = idxPreviousWaypoint(i);

            //Surrounding wheckpoints
            currentWaypoint = this.transform.GetChild(i);
            nextWaypoint = this.transform.GetChild(next);
            previousWaypoint = this.transform.GetChild(previous);

            //The wall size
            currentWaypoint.localScale = WallSize;

            //Angling the surrounding waypoints
            currentWaypoint.LookAt(nextWaypoint);
            currentRotation = new Quaternion(currentWaypoint.transform.rotation.x, currentWaypoint.transform.rotation.y, currentWaypoint.transform.rotation.z,
            currentWaypoint.transform.rotation.w);
            currentWaypoint.LookAt(previousWaypoint);
            previousRotation = new Quaternion(previousWaypoint.transform.rotation.x, previousWaypoint.transform.rotation.y, previousWaypoint.transform.rotation.z,
            previousWaypoint.transform.rotation.w);

            //Setting the waypoints to smoothen the angle between the surrounding waypoints
            currentWaypoint.transform.rotation = Quaternion.Lerp(currentRotation, previousRotation, 0.5f);
        }
    }

    private int idxNextWaypoint(int i){
        if(i < this.transform.childCount - 1){
            return (i + 1);
        }
        else{
            return 0;
        }
    }

    private int idxPreviousWaypoint(int i){
        if(i == 0){
            return (this.transform.childCount - 1);
        }
        else{
            return (i - 1);
        }
    }

    public string Description(){
        return string.Format("There are {0} waypoints.", this.transform.childCount);
    }
}
