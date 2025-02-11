using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    internal float spawnTimer;

    [Header("Tiles")]
    public Transform spawnPoint;

    public List<GameObject> tiles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += 1 * Time.deltaTime;

        //Debug.Log(spawnTimer);

        if (spawnTimer % 4  == 0 )
        {
            Debug.Log("Spawn");
            int rand = Random.Range(0, tiles.Count);
            Instantiate(tiles[rand], spawnPoint);
        }
    }
}
