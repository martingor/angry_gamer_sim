using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_game_button : MonoBehaviour
{
    [SerializeField] private string gameTitle;
    [SerializeField] private int gameScreen;
    [SerializeField] private GameObject gameplayObj;

    public void StartGame()
    {
        gameplayObj.gameObject.GetComponent<Gameplay>().SetupGame(gameScreen);
    }
}
