using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadwin : MonoBehaviour
{
    public void loadWin() {
        SceneManager.LoadScene("GameWin");
    }

    public void retry() {
        SceneManager.LoadScene("Scorpius");
    }

    public void leaveGame() {
        Application.Quit();
    }
}
