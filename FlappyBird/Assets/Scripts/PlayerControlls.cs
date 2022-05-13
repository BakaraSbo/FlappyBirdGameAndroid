using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlls : MonoBehaviour
{
    public SpawningTubes TubeSpawner;
    public Rigidbody2D rb;
    public GameObject bomb;
    public GameObject endGame;
    public GameObject gameUI;
    float lastClickTime, bombActiveTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TubeSpawner.game)
        {
            if (bombActiveTime > 0)
            {
                bombActiveTime -= Time.deltaTime;
            }
            else
            {
                bomb.SetActive(false);
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (Time.time - lastClickTime < 0.2f)
                    {
                        bomb.SetActive(true);
                        bombActiveTime = 1;
                        lastClickTime = Time.time;
                    }
                    else
                    {
                        rb.velocity = new Vector2(0, 3.0f);
                        lastClickTime = Time.time;
                    }
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        TubeSpawner.game = false;
        endGame.SetActive(true);
        gameUI.SetActive(false);
        this.transform.position = Vector2.zero;
        this.gameObject.SetActive(false);
    }
}
