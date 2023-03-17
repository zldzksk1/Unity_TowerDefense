using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class Enemy_Health : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int damage = 0;
    [Tooltip("Adds amount to maxHitPoints when enery died")]    //give an tooltip msg for front designer, when mouse hover the below attributes (difficultyRamp);
    [SerializeField] int difficultyRamp = 2;
    int currentHitPoints = 0;

    Enemy enemy;
    Tower tower;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
        //tower = FindObjectOfType<Tower>();
        //damage = tower.currentDamge;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    public void ProcessHit()
    {
        currentHitPoints -= damage;   //once tower got level up, increase the dmg

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
        
    }
}
