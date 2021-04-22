using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InsertTextInField : MonoBehaviour
{
    public void InsertText (string text)
    {
        this.GetComponent<TextMeshProUGUI>().text = text;
    }
}
