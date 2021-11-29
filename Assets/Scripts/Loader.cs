using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel(String scene)
    {
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

        // transition.SetTrigger("End");

        // yield return new WaitForSeconds(transitionTime);
    }

    IEnumerator LoadAsynchronously(String scene)
    {
        // StartCoroutine(LoadLoading());

        // Starts the animation
        transition.SetTrigger("Start");

        // Waits for the set transition time
        yield return new WaitForSeconds(transitionTime);

        // Starts loading the next scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

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
