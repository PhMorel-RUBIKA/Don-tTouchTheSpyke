using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    public static ResourceManager instance = null;
    
    public int resources = 0;

    private void Awake() {
        if (instance == null) instance = this;
    }
}
