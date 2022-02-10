using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {
    [SerializeField] private List<SpriteClass> spriteList = new List<SpriteClass>();

    public List<SpriteClass> SpriteList {
        get => spriteList;
        set => spriteList = value;
    }

    [SerializeField] private GameObject birdsLayoutGam = null;
    [SerializeField] private Transform birdsLayoutTrans = null;
    private void Start() => CreateBirdsSpriteShop();

    /// <summary>
    /// Create birds sprite
    /// </summary>
    private void CreateBirdsSpriteShop() {
        for (int i = 0; i < spriteList.Count; i++) {
            GameObject bird = Instantiate(birdsLayoutGam, birdsLayoutTrans);
            bird.GetComponent<SpriteGroupData>().UpdateData(spriteList[i].Sprite, spriteList[i].Name, spriteList[i].Cost.ToString(), i, spriteList[i].unlocked, this);
        }
    }

    public void ActivateBird(int id) {
        spriteList[id].unlocked = true;
    }
}

[System.Serializable]
public class SpriteClass {
    [SerializeField] private string name = "";
    [SerializeField] private Sprite sprite = null;
    [SerializeField] private int cost = 0;
    public bool unlocked = false;

    public string Name => name;
    public Sprite Sprite => sprite;
    public int Cost => cost;
}
