using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name.Contains("Player"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    } 

}
