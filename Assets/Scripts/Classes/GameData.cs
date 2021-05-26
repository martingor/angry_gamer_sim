using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentDay;
    public int gamepPercent;
    public int currentGameQuestion;
    public int internetPoints;

    public GameData(GameState data)
    {
        currentDay = data.currentDay;
        internetPoints = data.internetPoints;


    }
}
