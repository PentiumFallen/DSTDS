using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBetweenSpawns;
    public GameObject enemy;
    public Transform[] spawnSpots;
    private float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns<=0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
