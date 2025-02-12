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

    public List<GameObject> instantiatedTiles;

    void Start()
    {
        
    }

    public void CreateTile()
    {
        int rand = Random.Range(0, tiles.Count);
        GameObject tile =  Instantiate(tiles[rand], spawnPoint);
        instantiatedTiles.Add(tile);
    }

    public void SetTileSpeed(float speed)
    {
        foreach (var i in instantiatedTiles)
        {
            i.GetComponent<Tile>().speed = speed;
        }
    }

    static internal GameManager instance => FindAnyObjectByType<GameManager>();

}
