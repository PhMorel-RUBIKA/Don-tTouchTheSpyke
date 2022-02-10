using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {
    [SerializeField] private List<SpriteClass> spritelist = new List<SpriteClass>();
    
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
