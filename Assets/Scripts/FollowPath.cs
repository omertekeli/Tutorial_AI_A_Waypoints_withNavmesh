using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{


    //wpManager hod waypoints and graph information and NPC need to know
    public GameObject wpManager;
    GameObject[] wps;
    UnityEngine.AI.NavMeshAgent agent;


    void Start()
    {

        wps = wpManager.GetComponent<WPManager>().waypoints;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    public void GotToHeli()
    {
        agent.SetDestination(wps[4].transform.position);
        //A* Algorihm
        //g.AStar(currentNode, wps[1]);
        //currentWP = 0;
    }

    public void GoToRuin()
    {
        agent.SetDestination(wps[0].transform.position);
        //g.AStar(currentNode, wps[5]);
        //currentWP = 0;
    }

    public void GoToTanks()
    {

        //g.AStar(currentNode, wps[9]);
        //currentWP = 0;
    }

    private void LateUpdate()
    {

        ////Dont keep moving, if no path, or waypoint
        //if (g.getPathLength() == 0 || currentWP == g.getPathLength())
        //{

        //    return;
        //}

        //// The node we are closest to at this point
        //currentNode = g.getPathPoint(currentWP);

        //// If we are close enought to the current waypoint move to next
        //if (Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        //{

        //    currentWP++;
        //}

        //if (currentWP < g.getPathLength())
        //{

        //    goal = g.getPathPoint(currentWP).transform;
        //    Vector3 lookAtGoal = new Vector3(goal.position.x,
        //        this.transform.position.y,
        //        goal.position.z);
        //    Vector3 direction = lookAtGoal - this.transform.position;

        //    this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
        //        Quaternion.LookRotation(direction),
        //        Time.deltaTime * rotSpeed);

        //    this.transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        }
    }
