using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;
using UnityEngine.WSA;

public class CandyScore : MonoBehaviour
{
    [SerializeField] private int ressource;
    [SerializeField] public bool activate;
    
    //PRIVATE
    private SpriteRenderer spriteCandy;
    private CircleCollider2D colliderCandy;
    


    // Start is called before the first frame update
    void Awake()
    {
        spriteCandy = GetComponent<SpriteRenderer>();
        colliderCandy = GetComponent<CircleCollider2D>();
        activate = false;
    }
    
    void FixedUpdate()
    {
        if (activate)
        {
            spriteCandy.enabled = true;
            colliderCandy.enabled = true;
        }
        else
        {
            spriteCandy.enabled = false;
            colliderCandy.enabled = false;
        }
    }

    public void UpdateValue() {
        ResourceManager.instance.resources += ressource;
        CandyManager.instance.RemoveCandy(this.gameObject);
        activate = false;
    }

}
