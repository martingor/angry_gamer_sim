using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private Sprite[] background;
    [SerializeField] private GameState controller;
    public void SetupGame(int imgNumber)
    {
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<Image>().sprite = background[imgNumber];
        this.transform.SetAsLastSibling();
        controller.playing = true;
    }

}
