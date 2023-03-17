using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{

    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem prohjecttitleParticles;
    [SerializeField] float range = 15f;
    Transform target;
    float arrowSpeed = 1.0f;

    void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity; //set maxDistance to maxFloat for comparison later

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);  // get distance of two object, 
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon() 
    {
        if (target == null)
        {
            Attack(false);
            return;
        }

        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance <= range)
            Attack(true);
        else
            Attack(false);
    }

    void Attack(bool isActive)
    {

        var emissionMidule = prohjecttitleParticles.emission;
        emissionMidule.enabled = isActive;
        emissionMidule.rateOverTime = arrowSpeed;
    }

    public void isUpgaded()
    {
        arrowSpeed = arrowSpeed + .7f;
        Debug.Log("heelo");
    }
}
