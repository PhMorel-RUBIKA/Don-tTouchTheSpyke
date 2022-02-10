using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGroupData : MonoBehaviour {
    [SerializeField] private Image birdsImg = null;
    [SerializeField] private TextMeshProUGUI birdsName = null;
    [SerializeField] private TextMeshProUGUI birdsCost = null;
    [SerializeField] private int id = 0;
    
    /// <summary>
    /// Update the data of the group
    /// </summary>
    /// <param name="image"></param>
    /// <param name="name"></param>
    /// <param name="cost"></param>
    public void UpdateData(Sprite image, string name, string cost, int id) {
        birdsImg.sprite = image;
        birdsName.text = name;
        birdsCost.text = $"cost : {cost}";
        this.id = id;
    }

    public void BuySprite() {
        
    }
}
