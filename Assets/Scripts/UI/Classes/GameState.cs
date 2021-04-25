using UnityEngine;
using Yarn.Unity;
public class GameState : MonoBehaviour
{
    public int internetPoints;

    public DayClass[] days;
    public int currentDayQuestion = 0;

    public int currentDay = 0;
    public float timevar = 0;
    public int dayTime = 0;

    public bool pause = false;

    public bool playing = false;
    public GameClass game = null;
    public float gamePercentVar = 0;
    public int gamepPercent = 0;
    public float gamerPercentPerSec = 1;
    public int currentGameQuestion = 0;


    public DialogueRunner dialogue;
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
            
        }

        
    }
}
