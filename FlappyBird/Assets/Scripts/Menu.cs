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
    public void StartGame()
    {
        
        spawning.game = true;
        startButton.SetActive(false);
        playerRb.SetActive(true);
        gameUI.SetActive(true);
        title.SetActive(false);
    }
    public void PlayAgain()
    {
        startButton.SetActive(true);
        endGame.SetActive(false);
    }
}
