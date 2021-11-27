using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void NewGameButton()
    {
        Loader.Load(Loader.Scene.LevelSelect);
    }
}
