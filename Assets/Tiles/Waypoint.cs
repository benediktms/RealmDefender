using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    bool isPlaceable;

    [SerializeField]
    GameObject towerPrefab;

    private void OnMouseUp()
    {
        if (isPlaceable)
        {
            towerPrefab = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
