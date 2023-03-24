using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] bird;

    [SerializeField]
    float spawnInterval;

    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;

    public float distance_01;
    public float distance_02;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        SpawnCloud();
        Invoke("AttemptSpawn", spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnCloud()
    {
        int randomIndex = UnityEngine.Random.Range(0, bird.Length);
        GameObject cloud = Instantiate(bird[randomIndex]);

        cloud.transform.position = startPos;

        startPos.y = UnityEngine.Random.Range(distance_01, distance_02);
        cloud.transform.position = startPos;

        float scale = UnityEngine.Random.Range(1f, 4f);
        cloud.transform.localScale = new Vector2(scale, scale);


        float speed = UnityEngine.Random.Range(8f, 16f);
        cloud.GetComponent<Pajaro>().StartFloating(speed, endPoint.transform.position.x);

    }
    void AttemptSpawn()
    {
        SpawnCloud();


        Invoke("AttemptSpawn", spawnInterval);
    }
}
