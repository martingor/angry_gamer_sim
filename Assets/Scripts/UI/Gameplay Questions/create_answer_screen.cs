using UnityEngine;
using TMPro;

public class create_answer_screen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;
   public void SetupScreen(string text)
    {
        this.gameObject.SetActive(true);
        transform.SetAsLastSibling();
        message.text = text;
        
    }
}
