using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    public void loadScorpius()
    {
        Loader.Load(Loader.Scene.Scorpius);
    }
}
