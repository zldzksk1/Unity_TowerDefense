using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] int cost = 50;
    [SerializeField] int upgradeCost = 30;
    TargetLocator targetLocator;
  
    //public int currentDamage { get { return damage; } }  //pass damage info to enemy health

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
            return false;

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        else
            return false;
        
    }

    public void upGrade()
    {
        Bank bank = FindObjectOfType<Bank>();
        TargetLocator targetLocator = FindObjectOfType<TargetLocator>();

        if (bank == null || targetLocator == null)
            return;

        if (bank.CurrentBalance >= upgradeCost)
        {
            targetLocator.isUpgaded();
            bank.Withdraw(upgradeCost);
        }
    }


}
