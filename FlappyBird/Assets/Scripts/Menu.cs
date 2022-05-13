using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for all the button interactions
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
    //Function for using Start Game button
    public void StartGame()
    {
        spawning.game = true;
        startButton.SetActive(false);
        playerRb.SetActive(true);
        gameUI.SetActive(true);
        title.SetActive(false);
        gameUI.GetComponentInChildren<Score>().score = 0;
        gameUI.GetComponentInChildren<Score>().bombs = 1;
        gameUI.GetComponentInChildren<Score>().newBomb = 0;
    }
    //Function for using Play Again button
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
