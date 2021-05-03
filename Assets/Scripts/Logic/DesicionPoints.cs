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
            controller.dailyPoints += (int)dialogue.GetComponent<VariableStorage>().GetValue("$reward").AsNumber;
            controller.internetPoints += (int)dialogue.GetComponent<VariableStorage>().GetValue("$reward").AsNumber;
        }
    }

    public void ResetVars()
    {
        dialogue.GetComponent<VariableStorage>().SetValue("$give_points", 0);
        dialogue.GetComponent<VariableStorage>().SetValue("$reward", 0);   
    }
}
