using UnityEngine;

public class Close_Window_button : MonoBehaviour
{
    [SerializeField] private GameObject windowToClose;
    public void onClick()
    {
        windowToClose.gameObject.SetActive(false);
    }
}
