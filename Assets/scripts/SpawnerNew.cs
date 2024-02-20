using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNew : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] enemySpawn;

        public GameObject[] GetEnemySpawnList()
        {
            return enemySpawn;
        }
    }
    Transform player;
    public List<Transform> relativeSpawnPoints;

    [SerializeField][NonReorderable] WaveContent[] waves;
    int currentWave = 0;
    float spawnRange = 10f;
    public float enemiesKilled;
    public List<GameObject> currentEnemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnemy.Count==0)
        {
      
            currentWave++;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        for(int i=0;i< waves[currentWave].GetEnemySpawnList().Length;i++)
        {
            
            GameObject newspawn= Instantiate(waves[currentWave].GetEnemySpawnList()[i], FindSpawnLoc(), Quaternion.identity);
            //player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position
            currentEnemy.Add(newspawn);

            //Enemy monster = newspawn.GetComponent<Enemy>();
        }
    }

    Vector3 FindSpawnLoc()
    {
        Vector3 SpawnPos;

        float xLoc = Random.Range(-spawnRange, spawnRange) + transform.position.x;
        float zLoc = Random.Range(-spawnRange, spawnRange) + transform.position.z;
        float yLoc = transform.position.y;

        SpawnPos = new Vector3(xLoc, yLoc, zLoc);

        if (Physics.Raycast(SpawnPos, Vector3.down, 5))
        {
            return SpawnPos;
        }
        else
        {
            return FindSpawnLoc();
        }
    }
}
