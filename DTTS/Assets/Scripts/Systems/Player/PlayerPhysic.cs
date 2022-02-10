using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PicsGeneration pics = null;
    [SerializeField] private ScoreManager score = null;
    [SerializeField] private CandyManager candy = null;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            other.GetComponent<CandyScore>().UpdateValue();
        }
        if (other.CompareTag("Wall")) {
            if (playerController.goLeft) {
                playerController.goLeft = false;
                if(pics != null) pics.GenerateRandomPicsBySide(Side.Right);
                if(candy != null) candy.GenerateRandomCandy(Side.Right);
                score.IncreaseScore(1);
            }
            else {
                playerController.goLeft = true;
                if(pics != null) pics.GenerateRandomPicsBySide(Side.Left);
                if(candy != null) candy.GenerateRandomCandy(Side.Left);
                score.IncreaseScore(1);
            }
        }
        if (other.CompareTag("Spike"))
        {
            Debug.Log("death");
        }
    }
}
