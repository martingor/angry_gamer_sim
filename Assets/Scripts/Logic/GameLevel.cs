using Yarn.Unity;
using Yarn;
using UnityEngine;
using System;

[Serializable]public class GameLevel
{
    public bool cutscene;

    public string levelName;

    public GameObject leftSpawner;
    public GameObject rightSpawner;

    public YarnProgram dialogue;
    public Sprite imageForDialogue;
}
