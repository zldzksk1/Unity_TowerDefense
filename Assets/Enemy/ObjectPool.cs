using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;
    [SerializeField] TextMeshProUGUI displayWave;

    int maxRound = 5;
    int currRound = 1;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
        levelUpdateDisplay();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void Update()
    {
        
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()   //if the object is not active, make this active, so it can automaticallt spawn enermy. But, if it reach the end alive, respawn at start position.
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        //Debug.Log(currRound < maxRound);
        while (currRound < 4)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
            Debug.Log("heeloa");
        }
    }

    void levelUpdateDisplay()
    {
       // displayWave.text = "Wave:" + currRound;
    }
}
