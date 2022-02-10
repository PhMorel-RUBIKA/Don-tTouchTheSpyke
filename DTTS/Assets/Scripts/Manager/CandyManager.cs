using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandyManager : MonoBehaviour
{
    //COMPONENT
    [SerializeField] public List<GameObject> leftCandySpawnPoint;
    [SerializeField] public List<GameObject> rightCandySpawnPoint;
    [SerializeField] private bool direction;
    [SerializeField] private int numberOfCandyToActivate;
    [Space] 
    [SerializeField] private List<GameObject> debugObject;

    //PRIVATE
    private int numberCandyIncrement;

    private void Start()
    {   
        GenerateRandomCandy(direction);
    }


    void GenerateRandomCandy(bool left)
    {
        switch (left)
        {
            case true:
                ActivateRandomCandy(numberOfCandyToActivate, leftCandySpawnPoint);
                break;
            case false:
                ActivateRandomCandy(numberOfCandyToActivate, rightCandySpawnPoint);
                break;
        }
    }

    void ActivateRandomCandy(int numberBonbonActivate, List<GameObject> candyList)
    {
        List<GameObject> candyToActivate = new List<GameObject>();
        for (int i = 0; i < numberBonbonActivate; i++)
        {
            int randomCandyInList = Random.Range(0, candyList.Count);
            Debug.Log(randomCandyInList);
            candyToActivate.Add(candyList[randomCandyInList]);
            debugObject.Add(candyList[randomCandyInList]);

        }
        foreach (GameObject candyAct in debugObject)
        {
            candyAct.GetComponent<CandyScore>().activate = true;
            Debug.Log("ici");
        }
    }
}