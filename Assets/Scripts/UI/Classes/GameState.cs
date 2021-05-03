using UnityEngine;
using Yarn.Unity;
using Yarn;
using TMPro;
public class GameState : MonoBehaviour
{
    public int dailyPoints;
    public int internetPoints;

    public DayClass[] days;
    public int currentDayQuestion = 0;

    public int currentDay = 0;
    public int dayEndTime = 10;
    public float timevar = 0;
    public int dayTime = 0;

    public bool pause = false;

    public bool playing = false;
    public GameClass game = null;
    public float gamePercentVar = 0;
    public int gamepPercent = 0;
    public float gamerPercentPerSec = 1;
    public int currentGameQuestion = 0;

    public TextMeshProUGUI clock; 
    public DialogueRunner dialogue;

    public GameObject varStor;

    public YarnProgram dayEndDialgoue = null;

    public void CheckTimeForQuestion()
    {
        DayClass day = days[currentDay];
        if (day.timeToAsk.Length > currentDayQuestion)
        {
            if (day.timeToAsk[currentDayQuestion] == dayTime)
            {
                dialogue.Add(day.dayQuestions);
                dialogue.StartDialogue(currentDayQuestion.ToString());
                currentDayQuestion++;
            }
        }
    }

    public void CheckGamePercentForQuestion()
    {
        if (game.percentToAsk.Length > currentGameQuestion)
        {
            if (gamepPercent <= 100)
            {
                if (game.percentToAsk[currentGameQuestion] == gamepPercent)
                {
                    dialogue.Add(game.gameQuestions);
                    dialogue.StartDialogue(gamepPercent + "%");
                    currentGameQuestion++;
                }
            }
        }
    }

    public void PauseUnpause()
    {
        pause = !pause;
    }

    public void SetClock (string timeToSet)
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
            StartNewDay();        } 
    }

    public void StartNewDay()
    {
        currentDay++;
        varStor.GetComponent<VariableStorage>().SetValue("$daily_reward", 0);
        dayTime = 0;
        dailyPoints = 0;
    }
    public void Update()
    {
        if (pause == false)
        {
            timevar += Time.deltaTime;
            dayTime = (int)timevar;
            gamepPercent = (int)(timevar * gamerPercentPerSec);
            CheckTimeForQuestion();
            if (playing)
            {
                gamePercentVar += Time.deltaTime;
                gamepPercent = (int)gamePercentVar;
                print(gamepPercent);
                CheckGamePercentForQuestion();
            }
            CheckForEndDay(); 
            CalculateTime();
            
        }

        
    }
}
