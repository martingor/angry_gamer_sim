//FILE FOR MANAGING GAMEPLAY IN SOME OF US
using Yarn.Unity;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameInGameManager : MonoBehaviour
{
    public bool surviving = false;
    public float timeToSurvive;
    public float inGameTime;

    public GameObject preLevel;
    public GameState gameplay;
    public GameObject restartMenu;

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
            print("cutscene detected");
            dialogue.Add(currentLevel.dialogue);
            dialogueImage.GetComponent<Image>().sprite = currentLevel.imageForDialogue;
            dialogue.StartDialogue("Start");
        } else
        {
            preLevel.SetActive(true);
            foreach (GameObject heart in hearts)
                heart.SetActive(true);
            Instantiate(currentLevel.leftSpawner, new Vector3 (leftSpawn.position.x, leftSpawn.position.y, leftSpawn.position.z) , Quaternion.identity);
            Instantiate(currentLevel.rightSpawner, new Vector3(rightSpawn.position.x, rightSpawn.position.y, rightSpawn.position.z), Quaternion.identity);
            Instantiate(Player, new Vector3(playerSpawn.position.x, playerSpawn.position.y, playerSpawn.position.z), Quaternion.identity);
            
        }
    }
    public void ShowAmmoCount(int ammo, int maxAmmo)
    {
        ammoUI.text = ammo+"/"+maxAmmo;
    }
    public void ResetGame()
    {

        GameObject[] destroyables = GameObject.FindGameObjectsWithTag("Respawn");

        foreach (GameObject game in destroyables)
            GameObject.Destroy(game);

        CharacterController character = FindObjectOfType<CharacterController>();
        GameObject.Destroy(character);

        gameplay.pause = true;

        surviving = false;

        restartMenu.SetActive(true);
    }
    public void CompleteLevel()
    {
        GameLevel currentLevel = levels[level];
        if (currentLevel.cutscene)
        {
            dialogue.Clear();
            level++;
        } else
        {
            GameObject[] destroyables = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (GameObject game in destroyables)
                GameObject.Destroy(game);
            CharacterController character = FindObjectOfType<CharacterController>();
            GameObject.Destroy(character);
            level++;
        }
        gameplay.playing = false;
        currentLevel = levels[level];
        LevelNameText.text = currentLevel.levelName;
    }

    public TextMeshProUGUI LevelNameText;
    public void StartLevel()
    {
        preLevel.SetActive(false);
        gameplay.playing = true;
        gameplay.pause = false;
        surviving = true;
        inGameTime = timeToSurvive;
    }
    public void RestartGame()
    {
        restartMenu.SetActive(false);
        openGame();
    }

    public void Update()
    {
        if (surviving)
        {
            //print(inGameTime);
            inGameTime -= Time.deltaTime;
            if (inGameTime < 0)
            {
                surviving = false;

                CompleteLevel();

            }
        }

        
    }
}
