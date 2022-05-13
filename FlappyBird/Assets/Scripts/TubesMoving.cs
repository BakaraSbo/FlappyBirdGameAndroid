using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for tubes movement and interaction with score.
public class TubesMoving : MonoBehaviour
{
    public GameObject scoreText;
    public SpawningTubes TubeSpawner;
    bool passed;
    
    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score");
        TubeSpawner = GameObject.FindGameObjectWithTag("TubeSpawner").GetComponent<SpawningTubes>();
        passed = true;
    }
    void Update()
    {
        //If game is in progress moving tubes to the left.
        if (TubeSpawner.game)
        {
            this.transform.position += new Vector3(-1.7f, 0.0f, 0.0f) * Time.deltaTime;
        }
        //Checking if the position of the tube is far outside of the screen and destroing this gameObject as it is no longer needed.
        if(this.transform.position.x<= -10)
        {
            Destroy(gameObject);
        }
        //Checking if tube went past player and adding score.
        if(this.transform.position.x <= 0 && passed)
        {
            Score score = scoreText.GetComponent<Score>();
            score.AddScore();
            passed = false;
        }
    }
    
}
