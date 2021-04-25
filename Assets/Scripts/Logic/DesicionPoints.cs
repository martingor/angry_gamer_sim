using Yarn;
using UnityEngine;

public class DesicionPoints : MonoBehaviour
{
    public GameState controller;
    public GameObject dialogue;
    public void CheckGivePoints()
    {
        
        if (dialogue.GetComponent<VariableStorage>().GetValue("$give_points").AsBool)
        {
            controller.internetPoints += (int)dialogue.GetComponent<VariableStorage>().GetValue("$reward").AsNumber;
        }
    }
}
