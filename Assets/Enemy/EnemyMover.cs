using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    List<Waypoint> path = new List<Waypoint>();

    [SerializeField]
    float waitTime = 1f;

    void Start()
    {
        StartCoroutine(PrintWaypointName());
    }

    private IEnumerator PrintWaypointName()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }

    }
}
