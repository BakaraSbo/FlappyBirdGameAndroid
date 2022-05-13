using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class for holding information and updating text for score and bombs ammount.
public class Score : MonoBehaviour
{

    public int score=0;
    public int bombs = 1;
    public int newBomb=0;
    public Text scoreText;
    public Text bombsText;
    //In update we change text of score and bomb amount to be correct with our data.
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
    //Function to add score outside of the class.
    public void AddScore()
    {
        score++;
        newBomb++;
    }
}
