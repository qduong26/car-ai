using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class tenlua : MonoBehaviour
{
    public GameObject target;
    Vector3 direction;
    Vector3 direction2;


    //Waypoints
    [SerializeField] WaypointNode currentWaypoint = null;
    WaypointNode[] allWayPoints;
    ItemHandler ItemHandler;
    GameObject car;
    private void Awake()
    {

    }
    void Start()
    {
        int closestCarIndex = FindClosestCarIndex();
        if (closestCarIndex != -1)
        {
            car = Cpplayer.OrderGameobject[closestCarIndex];
            
        }
        Cpplayer cpplayer = car.GetComponent<Cpplayer>();
        target = cpplayer.timxephiatruoc();
        Debug.Log(target);
        allWayPoints = FindObjectsOfType<WaypointNode>();
        if (currentWaypoint == null)
        { currentWaypoint = FindClosestWayPoint(); }
    }
    int FindClosestCarIndex()
    {
        int closestCarIndex = -1;
        float closestDistance = Mathf.Infinity;
        Vector3 Position = transform.position;

        for (int i = 0; i < Cpplayer.OrderGameobject.Length; i++)
        {
            if (Cpplayer.OrderGameobject[i] != null)
            {
                float distance = Vector3.Distance(Cpplayer.OrderGameobject[i].transform.position, Position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCarIndex = i;
                }
            }
        }

        return closestCarIndex;
    
}
WaypointNode FindClosestWayPoint()
    {
        return allWayPoints
            .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
            .FirstOrDefault();
    }
    // Update is called once per frame
    void Update()
    {
        

        //Set the target on the waypoints position
        if (currentWaypoint != null)
        {

            //Set the target position of for the AI. 


            //Store how close we are to the target
            float distanceToWayPoint = (gameObject.transform.position - currentWaypoint.transform.position).magnitude;
            float distanceToxe = (gameObject.transform.position - target.transform.position).magnitude;
            direction = (target.transform.position - gameObject.transform.position).normalized;
            direction2 = (currentWaypoint.transform.position - gameObject.transform.position).normalized;
            if (distanceToxe > distanceToWayPoint)
            {


                gameObject.transform.Translate(direction2 * Time.deltaTime * 40);
                if (distanceToWayPoint <= 3f)
                {

                    //If we are close enough then follow to the next waypoint, if there are multiple waypoints then pick one at random.
                    currentWaypoint = currentWaypoint.nextWaypointNode[Random.Range(0, currentWaypoint.nextWaypointNode.Length)];

                }

            }
            else if (distanceToxe < distanceToWayPoint)
            {

                gameObject.transform.Translate(direction * Time.deltaTime * 40);
                

            }
            Cpplayer cpptarget = target.GetComponent<Cpplayer>();
            ItemHandler = target.GetComponent<ItemHandler>();
            if (distanceToxe <= 8f && ItemHandler.isthrough)
            {
                target= cpptarget.timxephiatruoc();
                

            }


        }
    }
}

