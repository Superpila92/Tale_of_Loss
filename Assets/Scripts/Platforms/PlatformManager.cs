using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

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
        Instantiate(platformPrefab, new Vector2(-20f, 152f), platformPrefab.transform.rotation);
    }

    IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(5f);

        Instantiate(platformPrefab, spawnPosition, platformPrefab.transform.rotation);
    }
}
