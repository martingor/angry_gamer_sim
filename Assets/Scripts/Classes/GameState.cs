using UnityEngine;
using Yarn.Unity;
using Yarn;
using TMPro;
public class GameState : MonoBehaviour
{

    // VARS THAT SAVE 
    public int currentDay;
    public int internetPoints;

    // LOCAL VARS
    public int dailyPoints;

    public DayClass[] days;
    public int currentDayQuestion = 0;
    public GameObject notification;
    public TextMeshProUGUI notificationTittle;

    public int dayEndTime = 10;
    public float timevar = 0;
    public int dayTime = 0;

    public bool pause = false;
    public bool playing = false;

    public float gamerPercentPerSec = 1;


    public TextMeshProUGUI clock;
    public DialogueRunner dialogue;

    public GameObject varStor;
    public YarnProgram dayEndDialgoue = null;


    //FUNCTIONS
    public bool waitingForOpen = false;
    private float waitingTime = 0;
    public int timeToOpen = 5;
    public void CheckTimeForQuestion()
    {
        DayClass day = days[currentDay];
        if (day.timeToAsk.Length > currentDayQuestion)
        {
            if (day.timeToAsk[currentDayQuestion] == dayTime)
            {
                notificationTittle.text = day.tittle[currentDayQuestion];
                notification.SetActive(true);
                dialogue.Add(day.dayQuestions);
                waitingForOpen = true;
                waitingTime = timeToOpen;
                
            }
        }
    }
    public void StartDailyQustion()
    {
        waitingForOpen = false;
        notification.SetActive(false);
        dialogue.StartDialogue(currentDayQuestion.ToString());
        currentDayQuestion++;
    }
    public void PauseUnpause()
    {
        pause = !pause;
    }
    public void SetClock(string timeToSet)
    {
        clock.text = timeToSet;
    }
    public void CalculateTime()
    {
        string timeString = "";
        int hours = 0;
        int minutes = 0;

        hours = 18 + (dayTime / 60);
        minutes = dayTime % 60;
        if (minutes > 9)
        {
            timeString = hours + ":" + minutes;
        }
        else timeString = hours + ":0" + minutes;
        SetClock(timeString);
    }
    public void CheckForEndDay()
    {
        if (dayTime == dayEndTime)
        {
            varStor.GetComponent<VariableStorage>().SetValue("$daily_reward", dailyPoints);
            dialogue.Add(dayEndDialgoue);
            dialogue.StartDialogue("end");
            StartNewDay();
        }
    }

    public GameObject gameEnd;
    public void StartNewDay()
    {
        if (currentDay+1 == days.Length)
        {
            gameEnd.SetActive(true);
        }
        else
        {
            currentDay++;
            varStor.GetComponent<VariableStorage>().SetValue("$daily_reward", 0);
            dayTime = 0;
            dailyPoints = 0;
        }
        
    }
    public void Update()
    {
        if (pause == false)
        {
            timevar += Time.deltaTime;
            dayTime = (int)timevar;

            if (waitingForOpen == true)
            {
                if (waitingTime > 0)
                {
                    waitingTime -= Time.deltaTime;
                }
                else
                {
                    waitingForOpen = false;
                    notification.SetActive(false);
                    currentDayQuestion++;
                    dialogue.Clear();
                }
            }
            else
            {
                CheckTimeForQuestion();
            }
            CheckForEndDay();
            CalculateTime();

        }

        

    }
    public void Start()
    {
        LoadGame();
    }
    public void SaveGame()
    {
        SaveSystem.SaveProgress(this);
    }
    public void LoadGame()
    {
        GameData data = SaveSystem.LoadProgress();
        currentDay = data.currentDay;
        internetPoints = data.internetPoints;
    }
}
