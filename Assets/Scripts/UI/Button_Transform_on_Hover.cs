using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_Transform_on_Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    private Image buttImage;
    private Color standartColor;
    void Start()
    {
        buttImage = GetComponentInChildren<Image>();
        standartColor = buttImage.color;
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttImage.color = new Color (buttImage.color.r, buttImage.color.g, buttImage.color.b, 1f);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
         buttImage.color = standartColor;
    }

}
