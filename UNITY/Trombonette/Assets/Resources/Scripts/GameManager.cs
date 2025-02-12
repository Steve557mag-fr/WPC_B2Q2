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

    [SerializeField] QTE qte;
    [SerializeField] UI ui;

    [Header("Player")]
    public int lives = 3;
    
    private void Start()
    {
        qte.onQTEFailed += Fail;
        qte.onQTEPassed += Pass;
    }

    public void CreateTile()
    {
        int rand = Random.Range(0, tiles.Count);
        GameObject tile = Instantiate(tiles[rand], spawnPoint);
        instantiatedTiles.Add(tile);
    }

    public void SetTileSpeed(float speed)
    {
        foreach (var i in instantiatedTiles)
        {
            i.GetComponent<Tile>().speed = speed;
        }
    }

    public void Pass()
    {
        // QTE.currentCombinationIndex--;
        // QTE.NextCombination
    }

    public void Fail()
    {

        lives--;
        if (lives == 0) EndGame();
        // QTE.currentCombinationIndex--;
        // QTE.NextCombination
    }
    public void EndGame()
    {

    }

    static internal GameManager instance => FindAnyObjectByType<GameManager>();

}
