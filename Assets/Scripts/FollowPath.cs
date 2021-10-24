using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotSpeed = 2.0f;
    //wpManager hod waypoints and graph information and NPC need to know
    public GameObject wpManager; 
    GameObject[] wps;
    GameObject currentNode; //the temprary goal
    int currentWP = 0; //index of the waypoint path. It's update every path
    Graph g;

    void Start() {

        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];
    }

    // Update is called once per frame
    public void GotToHeli() {

        //A* Algorihm
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }

    public void GoToRuin() {

        g.AStar(currentNode, wps[5]);
        currentWP = 0;
    }

    public void GoToTanks() {

        g.AStar(currentNode, wps[9]);
        currentWP = 0;
    }

    private void LateUpdate() {

        //Dont keep moving, if no path, or waypoint
        if (g.getPathLength() == 0 || currentWP == g.getPathLength()) {

            return;
        }

        // The node we are closest to at this point
        currentNode = g.getPathPoint(currentWP);

        // If we are close enought to the current waypoint move to next
        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position) < accuracy) {

            currentWP++;
        }

        if (currentWP < g.getPathLength()) {

            goal = g.getPathPoint(currentWP).transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x,
                this.transform.position.y,
                goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);

            this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        }
    }
}
