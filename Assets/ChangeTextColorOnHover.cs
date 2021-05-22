using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeTextColorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;
    private Color standartColor;
    void Start()
    {
        standartColor = text.color; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("dskdjaslkdja");  
        text.color = Color.white;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = standartColor;
    }
}
