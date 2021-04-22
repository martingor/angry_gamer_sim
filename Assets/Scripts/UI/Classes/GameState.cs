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
        }
        print(dayTime);
    }
}
