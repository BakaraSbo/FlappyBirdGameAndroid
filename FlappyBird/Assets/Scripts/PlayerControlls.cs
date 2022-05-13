using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControlls : MonoBehaviour
{
    [SerializeField]
    public SpawningTubes TubeSpawner;
    public Rigidbody2D rb;
    public GameObject bomb;
    public GameObject endGame;
    public GameObject gameUI;
    public Score scoreTextUI;
    public HighScores highScores;
    public Text yourScoreText;
    public Text highScoreText;
    public GameObject newHighScoreText;
    public SaveManager saveManager;
    private float lastClickTime, bombActiveTime;


    void Update()
    {
        //Checking if game is in progress and if it is using contrilling() for player controll.
        if (TubeSpawner.game)
        {
            Controlling();
        }
    }
    //On collision ending game and switching UI from ingame to post game and saving the high scores and preparing player object for the next game.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TubeSpawner.game = false;
        endGame.SetActive(true);
        gameUI.SetActive(false);
        CheckingForHighScore();
        ChangingTextOfEndGameScreen();
        this.transform.position = Vector2.zero;
        this.gameObject.SetActive(false);
    }
    //Function for checking where on local scoreboard our score is placing.
    private void CheckingForHighScore()
    {
        if (highScores.scores[4] < scoreTextUI.score)
        {
            //Activating text showing that you got new top 5 score.
            newHighScoreText.SetActive(true);
            for (int i = 3; i >= 0; i--)
            {
                if (highScores.scores[i] < scoreTextUI.score)
                {
                    if (i > 0)
                    {
                        highScores.scores[i + 1] = highScores.scores[i];
                    }
                    else
                    {
                        highScores.scores[i + 1] = highScores.scores[i];
                        highScores.scores[i] = scoreTextUI.score;
                    }
                }
                else
                {
                    highScores.scores[i + 1] = scoreTextUI.score;
                    break;
                }
            }
        }
        //Saving the high scores after every game.
        saveManager.Save();
    }
    //Changing the end game text to be accurate with last game.
    private void ChangingTextOfEndGameScreen()
    {
        yourScoreText.text = "Your Score \n" + scoreTextUI.score.ToString();
        highScoreText.text = "Highest Scores \n";
        for (int i = 0; i < 5; i++)
        {
            int scoreNumber = i + 1;
            highScoreText.text += scoreNumber.ToString() + ". " + highScores.scores[i].ToString() + "\n";
        }
    }
    //Function for controlling player character.
    private void Controlling()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                //Checking for the double click to use bomb.
                if (Time.time - lastClickTime < 0.23f && scoreTextUI.bombs>0)
                {
                    bomb.SetActive(true);
                    bombActiveTime = 1;
                    lastClickTime = Time.time;
                    scoreTextUI.bombs -= 1;
                }
                else
                {
                    rb.velocity = new Vector2(0, 3.0f);
                    lastClickTime = Time.time;
                }
            }
        }
        //Limiting bomb active time.
        if (bombActiveTime > 0)
        {
            bombActiveTime -= Time.deltaTime;
        }
        else
        {
            bomb.SetActive(false);
        }
    }
}
