using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                this.transform.position = new Vector3(6, Random.Range(-1.5f, 1.5f), 0);
                Instantiate(Tubes, this.transform.position, this.transform.rotation);
                spawnTime = 2;
            }
        }
    }
}
