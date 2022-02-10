using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandyManager : MonoBehaviour {
    public static CandyManager instance = null;
    
    private void Awake() {
        if (instance == null) instance = this;
    }
    
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
        GenerateRandomCandy(Side.Right);
    }


    public void GenerateRandomCandy(Side side) {
        if (debugObject.Count >= numberOfCandyToActivate) return;
        
        switch (side)
        {
            case Side.Left:
                ActivateRandomCandy(numberOfCandyToActivate, leftCandySpawnPoint);
                break;
            case Side.Right:
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

    /// <summary>
    /// Remove a candy
    /// </summary>
    /// <param name="candy"></param>
    public void RemoveCandy(GameObject candy) {
        debugObject.Remove(candy);
    }
}