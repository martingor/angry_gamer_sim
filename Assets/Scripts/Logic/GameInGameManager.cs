//FILE FOR MANAGING GAMEPLAY IN SOME OF US
using Yarn.Unity;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameInGameManager : MonoBehaviour
{
    public Transform leftSpawn;
    public Transform rightSpawn;
    public Transform playerSpawn;

    public TextMeshProUGUI ammoUI;
    public GameObject Player;

    public GameObject[] hearts;

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
            Instantiate(currentLevel.leftSpawner, new Vector3 (leftSpawn.position.x, leftSpawn.position.y, leftSpawn.position.z) , Quaternion.identity);
            Instantiate(currentLevel.rightSpawner, new Vector3(rightSpawn.position.x, rightSpawn.position.y, rightSpawn.position.z), Quaternion.identity);
            Instantiate(Player, new Vector3(playerSpawn.position.x, playerSpawn.position.y, playerSpawn.position.z), Quaternion.identity);
        }
    }

    public void ShowAmmoCount(int ammo, int maxAmmo)
    {
        ammoUI.text = ammo+"/"+maxAmmo;
    }
}
