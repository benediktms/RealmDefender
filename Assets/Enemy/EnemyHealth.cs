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

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
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
            gameObject.SetActive(false);
            enemy.RewardGold();
        }

    }
}
