using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void LoadLevel(String scene)
    {
        // Debug.Log("Starts the loading");
        // SceneManager.LoadScene("Loading");
        // StartCoroutine(LoadLoading());
        
        // Used to simulate health lost throughout multiple scenes
        // Debug.Log("Current health is " + health.hp);
        // health.hp -= 1;
        // Debug.Log("Current health is now" + health.hp);

        // Debug.Log("Starts the level");
        StartCoroutine(LoadAsynchronously(scene));
    }

    IEnumerator LoadLoading()
    {
        // Starts the animation
        transition.SetTrigger("Start");

        // Waits for the set transition time
        yield return new WaitForSeconds(transitionTime);

        // Loads the loading screen
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadAsynchronously(String scene)
    {
        Debug.Log("It reached here");
        // Starts the animation
        transition.SetTrigger("Start");

        Debug.Log(transitionTime);
        // Waits for the set transition time
        yield return new WaitForSeconds(transitionTime);

        Debug.Log("Made it past yield");
        // Starts loading the next scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        Debug.Log(operation.isDone);
        Debug.Log(operation.progress);

        // Waits for operation to complete
        while (!operation.isDone)
        {
            // Debug.Log(operation.progress);
            yield return null;
        }

        // if (operation.isDone)
        // {
        //     Debug.Log("It finished");
        // }
    }
}
