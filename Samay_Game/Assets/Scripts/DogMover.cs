using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMover : MonoBehaviour
{
    [SerializeField] private WaypointPath waypointPath;
    [SerializeField] private float speed = 1f;

    private int targetWaypointIndex;
    private Transform targetWaypoint;
    private Transform previousWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;
    private bool canMove = false;

    void Start()
    {
        TargetNextWaypoint();
    }

    public void FixedUpdate()
    {
        if (!canMove) return;

        elapsedTime += Time.deltaTime;
        float elapsePercentage = elapsedTime / timeToWaypoint;

        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsePercentage);

        if (elapsePercentage >= 1)
        {
            TargetNextWaypoint();
            canMove = false;
        }
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = waypointPath.GetWayPoint(targetWaypointIndex);
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWayPoint(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            canMove = true;
        }
    }
}

