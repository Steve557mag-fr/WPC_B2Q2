using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [Header("Tiles")]
    public Transform spawnPoint;

    public List<GameObject> tiles;

    public List<GameObject> instantiatedTiles;

    [SerializeField] QTE qte;
    [SerializeField] UI ui;

    [Header("Player")]
    public int lives = 10;
    public int highScore;
    
    private void Start()
    {
        qte.onQTEFailed += Fail;
        qte.onQTEPassed += Pass;
        qte.onQTEEnded += End;
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

    public void End()
    {
        Debug.Log("QTE Ended");
        SetTileSpeed(3);
    }

    public void Pass()
    {
        Debug.Log("Passed QTE");
    }

    public void Fail()
    {
        Debug.Log("Failed QTE");
        lives--;
        if (lives == 0) EndGame();
    }
    public void EndGame()
    {
        Debug.Log("c'est finit");
        Time.timeScale = 0;
        highScore = qte.score;
        qte.score = 0;

        if(qte.score >= PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }

        //afficher ui end game nullos t'as perdu
    }

    static internal GameManager instance => FindAnyObjectByType<GameManager>();

}
