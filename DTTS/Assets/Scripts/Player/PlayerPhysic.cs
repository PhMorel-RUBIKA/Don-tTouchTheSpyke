using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            
        }
        if (other.CompareTag("Wall"))
        {
            if (playerController.goLeft)
                playerController.goLeft = false;
            else
            {
                Debug.Log("test");
                playerController.goLeft = true;
            }
            
        }
        if (other.CompareTag("Spike"))
        {
            
        }
    }
}
