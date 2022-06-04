using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int maxHitPoints = 5;

    [SerializeField]
    int currentHitPoints = 0;

    private void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    private void OnParticleCollision()
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints < 1)
        {
            Destroy(gameObject);
        }

    }
}
