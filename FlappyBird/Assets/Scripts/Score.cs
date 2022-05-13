using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    public int score=0;
    public int bombs = 1;
    int newBomb=0;
    public Text scoreText;
    public Text bombsText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        bombsText.text = "Bombs \n" + bombs;
        if (newBomb == 10)
        {
            newBomb = 0;
            if (bombs < 3)
            {
                bombs++;
            }
        }
    }
    public void AddScore()
    {
        score++;
        newBomb++;
    }
}
