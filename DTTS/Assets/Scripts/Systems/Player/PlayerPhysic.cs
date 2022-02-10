using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PicsGeneration pics = null;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            
        }
        if (other.CompareTag("Wall")) {
            if (playerController.goLeft) {
                playerController.goLeft = false;
                if(pics != null) pics.GenerateRandomPicsBySide(Side.Right);
            }
            else {
                playerController.goLeft = true;
                if(pics != null) pics.GenerateRandomPicsBySide(Side.Left);
            }
        }
        if (other.CompareTag("Spike"))
        {
            Debug.Log("death");
        }
    }
}
