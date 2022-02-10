using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGroupData : MonoBehaviour {
    [SerializeField] private Image birdsImgParent = null;
    [SerializeField] private Image birdsImg = null;
    [SerializeField] private Image birsSelection = null;
    [SerializeField] private SpriteManager man = null;
    [SerializeField] private TextMeshProUGUI birdsName = null;
    [SerializeField] private TextMeshProUGUI birdsCost = null;
    [SerializeField] private int id = 0;
    private bool actiavated;
    

    /// <summary>
    /// Update the data of the group
    /// </summary>
    /// <param name="image"></param>
    /// <param name="name"></param>
    /// <param name="cost"></param>
    public void UpdateData(Sprite image, string name, string cost, int id, bool activate, SpriteManager manager) {
        birdsImg.sprite = image;
        birdsName.text = name;
        birdsCost.text = $"cost : {cost}";
        this.id = id;
        actiavated = activate;
        if (actiavated) {
            birsSelection.enabled = true;
            birdsImgParent.color = new Color(1, 1, 1, 89f / 256f);
        }

        man = manager;
    }

    public void BuySprite() {
        if (actiavated) {
            //Selectionne le sprite comme défaut
            birsSelection.enabled = true;
        }
        else {
            man.ActivateBird(id);
            birdsImgParent.color = new Color(1, 1, 1, 89f / 256f);
            actiavated = true;
        }
    }
}
