using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserMessage : MonoBehaviour
{
    public GameState manager;
    void Awake()
    {
        
        manager.pause = true;
    }

    public void OnClick()
    {
        manager.pause = false;
        Destroy(this.gameObject);
        
    }
}
