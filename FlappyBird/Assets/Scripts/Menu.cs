using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public SpawningTubes spawning;
    public GameObject startButton;
    public GameObject playerRb;
    public GameObject endGame;
    public GameObject gameUI;
    public GameObject title;
    public GameObject newHighScoreText;
    GameObject[] tubesInGame;
    public void StartGame()
    {
        spawning.game = true;
        startButton.SetActive(false);
        playerRb.SetActive(true);
        gameUI.SetActive(true);
        title.SetActive(false);
        gameUI.GetComponentInChildren<Score>().score = 0;
        gameUI.GetComponentInChildren<Score>().bombs = 1;
    }
    public void PlayAgain()
    {
        startButton.SetActive(true);
        endGame.SetActive(false);
        newHighScoreText.SetActive(false);
        tubesInGame = GameObject.FindGameObjectsWithTag("Tubes");
        foreach(GameObject tube in tubesInGame)
        {
            Destroy(tube);
        }
    }
}
