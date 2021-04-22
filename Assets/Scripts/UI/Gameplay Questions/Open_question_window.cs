using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_question_window : MonoBehaviour
{
    [SerializeField] private GameState gameData;
    public void askQuestion()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.SetAsLastSibling();
    }
}
