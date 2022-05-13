using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroying tubes on collision.
        if (collision.gameObject.tag == "Tubes")
        {
            Destroy(collision.gameObject);
        }
    }
}
