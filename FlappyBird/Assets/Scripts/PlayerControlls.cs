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
    public Score score;
    public HighScores highScores;
    public Text yourScoreText;
    public Text highScoreText;
    public GameObject newHighScoreText;
    public SaveManager saveManager;
    private float lastClickTime, bombActiveTime;


    void Update()
    {
        if (TubeSpawner.game)
        {
            Controlling();
        }
    }
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

    private void CheckingForHighScore()
    {
        if (highScores.scores[4] < score.score)
        {
            newHighScoreText.SetActive(true);
            for (int i = 3; i >= 0; i--)
            {
                if (highScores.scores[i] < score.score)
                {
                    if (i > 0)
                    {
                        highScores.scores[i + 1] = highScores.scores[i];
                    }
                    else
                    {
                        highScores.scores[i + 1] = highScores.scores[i];
                        highScores.scores[i] = score.score;
                    }
                }
                else
                {
                    highScores.scores[i + 1] = score.score;
                    break;
                }
            }
        }
        saveManager.Save();
    }
    private void ChangingTextOfEndGameScreen()
    {
        yourScoreText.text = "Your Score \n" + score.score.ToString();
        highScoreText.text = "Highest Scores \n";
        for (int i = 0; i < 5; i++)
        {
            int scoreNumber = i + 1;
            highScoreText.text += scoreNumber.ToString() + ". " + highScores.scores[i].ToString() + "\n";
        }
    }
    private void Controlling()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastClickTime < 0.2f && score.bombs>0)
                {
                    bomb.SetActive(true);
                    bombActiveTime = 1;
                    lastClickTime = Time.time;
                    score.bombs -= 1;
                }
                else
                {
                    rb.velocity = new Vector2(0, 3.0f);
                    lastClickTime = Time.time;
                }
            }
        }
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
