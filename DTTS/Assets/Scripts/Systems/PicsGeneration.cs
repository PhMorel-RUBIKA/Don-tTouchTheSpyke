using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PicsGeneration : MonoBehaviour {
    [SerializeField] private bool duoMode = false;
    [SerializeField] private List<GameObject> picsGamListLeft = null;
    [SerializeField] private List<GameObject> picsGamListRight = null;
    [Space] 
    [SerializeField] private Vector2 picsValue = new Vector2();
    [Space] 
    [SerializeField] private int score = 0;
    [SerializeField] private int maxScoreForMaxPics = 100;

    /// <summary>
    /// Generate random pics on the left
    /// </summary>
    public void GenerateRandomPicsBySide(Side side) {
        float randomPicsValue = Mathf.Lerp(picsValue.x, picsValue.y, (float) score / maxScoreForMaxPics);
        int randomPics = (int) Random.Range(randomPicsValue - 1, randomPicsValue + 2);
        Debug.Log($"il y a {randomPics} qui vont etre spawn, {(float) score / maxScoreForMaxPics}");

        switch (side) {
            case Side.Left:
                GetRandomPics(randomPics, picsGamListLeft);
                if(!duoMode) ResetPicsBySide(Side.Right, false);
                break;
            case Side.Right:
                GetRandomPics(randomPics, picsGamListRight);
                if(!duoMode) ResetPicsBySide(Side.Left, false);
                break;
        }
    }

    /// <summary>
    /// Get the random pics and enable them
    /// </summary>
    /// <param name="randomPics"></param>
    /// <param name="picsGamList"></param>
    private void GetRandomPics(int randomPics, List<GameObject> picsGamList) {
        List<GameObject> picsChoose = new List<GameObject>();
        for (int i = 0; i < randomPics; i++) {
            int randomPicsInlist = Random.Range(0, picsGamList.Count);
            while (picsChoose.Contains(picsGamList[randomPicsInlist])) {
                randomPicsInlist = Random.Range(0, picsGamList.Count);
            }
            
            picsGamList[randomPicsInlist].SetActive(true);
            picsChoose.Add(picsGamList[randomPicsInlist]);
        }
        
        foreach (GameObject pics in picsGamList) {
            if(!picsChoose.Contains(pics)) pics.SetActive(false);
        }
    }

    /// <summary>
    /// Reset all the left pics
    /// </summary>
    public void ResetPicsBySide(Side side, bool activation) {
        switch (side) {
            case Side.Left:
                foreach (GameObject pics in picsGamListLeft) {
                    pics.SetActive(activation);
                }
                break;
            case Side.Right:
                foreach (GameObject pics in picsGamListRight) {
                    pics.SetActive(activation);
                }
                break;
        }
    }
}

public enum Side {
    Left, Right
}
