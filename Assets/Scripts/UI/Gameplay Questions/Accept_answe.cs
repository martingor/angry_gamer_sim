using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accept_answe : MonoBehaviour
{
    [SerializeField] private GameObject gameplay;
    [SerializeField] private GameState controller;
    public void closeGameplay()
    {

        gameplay.SetActive(false);
    }
}
