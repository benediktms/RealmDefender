using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField]
    Transform weapon;

    [SerializeField]
    float towerRange = 15f;

    [SerializeField]
    ParticleSystem projectileParticle;

    Transform target;

    void Update()
    {
        FindClosesTarget();
        AimWeapon();
    }

    private void FindClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closesTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < maxDistance)
            {
                closesTarget = enemy.transform;
                maxDistance = distance;
            }
        }

        target = closesTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance < towerRange)
        {
            weapon.LookAt(target);
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
