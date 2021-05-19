using Yarn.Unity;
using UnityEngine;
using UnityEngine.UI;

public class GameInGameManager : MonoBehaviour
{
    public Transform leftSpawn;
    public Transform rightSpawn;

    public int level = 0;
    public GameLevel[] levels;
    public GameObject dialogueImage;
    public DialogueRunner dialogue;
    public void openGame()
    {
        GameLevel currentLevel = levels[level];

        if (currentLevel.cutscene == true)
        {
            dialogue.Add(currentLevel.dialogue);
            dialogueImage.GetComponent<Image>().sprite = currentLevel.imageForDialogue;
            dialogue.StartDialogue("Start");
        } else
        {

        }
    }

}
