using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] mariposa;

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
        int randomIndex = UnityEngine.Random.Range(0, mariposa.Length);
        GameObject cloud = Instantiate(mariposa[randomIndex]);

        cloud.transform.position = startPos;

        startPos.y = UnityEngine.Random.Range(distance_01, distance_02);
        cloud.transform.position = startPos;

        float scale = UnityEngine.Random.Range(0.8f, 2f);
        cloud.transform.localScale = new Vector2(scale, scale);


        float speed = UnityEngine.Random.Range(4f, 8f);
        cloud.GetComponent<Butterfly>().StartFloating(speed, endPoint.transform.position.x);

    }
    void AttemptSpawn()
    {
        SpawnCloud();


        Invoke("AttemptSpawn", spawnInterval);
    }
}
