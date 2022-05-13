using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class handling spawning of new tubes when the game is in progress.
public class SpawningTubes : MonoBehaviour
{
    float spawnTime = 2;
    public GameObject Tubes;
    public bool game;
    private void Start()
    {
        game = false;
    }
    void Update()
    {
        if (game)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0)
            {
                //changing position for one with y in range of -2 and 1.5 and x position 6.
                this.transform.position = new Vector3(6, Random.Range(-2f, 1.5f), 0);
                //Instantiating tubes at the position and rotation oh this gameObject.
                Instantiate(Tubes, this.transform.position, this.transform.rotation);
                spawnTime = 2;
            }
        }
    }
}
