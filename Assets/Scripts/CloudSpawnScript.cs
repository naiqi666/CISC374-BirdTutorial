using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject clouds;
    public float spawnRate = 50;
    private float timer = 0;
    public float heightOffset = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnClouds();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer = timer + Time.deltaTime;
        }
        else{
            SpawnClouds();
            timer = 0;
        }
    }

    void SpawnClouds()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(clouds, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
