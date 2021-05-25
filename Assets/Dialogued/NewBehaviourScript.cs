using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void ClickToOpenClose()
    {
        if (this.gameObject.activeSelf) // проверка активно ли окно
        {
            this.gameObject.SetActive(false); // закрываем если активно
        }
        else this.gameObject.SetActive(true);
    }
}
