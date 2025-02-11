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

    public void CreateTile()
    {
        int rand = Random.Range(0, tiles.Count);
        Instantiate(tiles[rand], spawnPoint);
    }



    static internal GameManager instance => FindAnyObjectByType<GameManager>();

}
