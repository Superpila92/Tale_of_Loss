using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager2 : MonoBehaviour
{
    public static PlatformManager2 Instance = null;

    [SerializeField]
    GameObject platformPrefab;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Instantiate(platformPrefab, new Vector2(462f, 73f), platformPrefab.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(5f);

        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
