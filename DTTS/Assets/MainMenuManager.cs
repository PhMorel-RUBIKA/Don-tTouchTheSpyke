using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private PlayerController _playerController;
    public void LaunchGame()
    {
        _playerController.launchGame = true;
    }
}
