using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proceed : MonoBehaviour
{
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name.Contains("Player"))
        {
            FindObjectOfType<GameManager>().Proceed();
        }
    }
}
