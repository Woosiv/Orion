using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Loader sceneManager;
    public GameObject thisButton;
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<Loader>();
        thisButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => sceneManager.LoadLevel("Scorpius"));
        // thisButton.onClick.AddListener(() => sceneManager.LoadLevel(levelName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
