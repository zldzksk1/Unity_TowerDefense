using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefabs;
    [SerializeField] bool isPlaceable;

    int levelLimit = 3;
    int currLevel = 1;
    bool isUpgradable = false;

    public bool isPlacaeble {get{return isPlaceable;}}  //getter method like, use when the valuse is not changeable

    //Getter method
    //public bool GetIsPlacable()
    //{
    //    return isPlaceable;
    //}

    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefabs.CreateTower(towerPrefabs, transform.position);
            isPlaceable = !isPlaced;
        }

        else if (!isPlacaeble && isUpgradable)
        {
            towerPrefabs.upGrade();
        }

        if (currLevel < levelLimit)
        {
            isUpgradable = true;
            currLevel++;
        }
        else
            isUpgradable = false;
         
    }
}
