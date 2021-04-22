using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_Transform_on_Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform controlPanel;
    [SerializeField] private Transform closeButton;
    [SerializeField] private Transform wholePanel;
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

    public void OpenStartMenu()
    {        
        controlPanel.position = new Vector3(controlPanel.position.x * -1, controlPanel.position.y, controlPanel.position.z);
        closeButton.position = new Vector3(closeButton.position.x * -1, closeButton.position.y, closeButton.position.z);
        wholePanel.SetAsLastSibling();
    }
}
