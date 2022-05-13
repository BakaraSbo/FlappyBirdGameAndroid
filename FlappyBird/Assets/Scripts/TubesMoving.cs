using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (TubeSpawner.game)
        {
            this.transform.position += new Vector3(-1.7f, 0.0f, 0.0f) * Time.deltaTime;
        }
        if(this.transform.position.x<= -10)
        {
            Destroy(gameObject);
        }
        if(this.transform.position.x <= 0 && passed)
        {
            Score score = scoreText.GetComponent<Score>();
            score.AddScore();
            passed = false;
        }
    }
    
}
