using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameInGameManager manager;

    // Update is called once per frame
    void Update()
    {
        print((int)manager.inGameTime);
        this.GetComponent<TextMeshProUGUI>().text = "осталось: " + (int)manager.inGameTime + "c.";
    }
}
