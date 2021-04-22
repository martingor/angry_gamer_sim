using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Window_Button : MonoBehaviour
{
    [SerializeField] private GameObject windowToOpen;

    public void openWindow()
    {
        windowToOpen.gameObject.SetActive(true);
    }
}
