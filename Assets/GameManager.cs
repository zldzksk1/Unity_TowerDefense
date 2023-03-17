using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameStart;
    public int gameLevel;
    void Awake()
    {
        Instance = this;
        gameStart = false;
        gameLevel = 1;
    }

    public void UpdateStatus()
    {
        gameStart = !gameStart;
    }

    public void UpdateLevel()
    {
        gameLevel++;
    }
}

//public enum GameState
//{ 
    
//}
