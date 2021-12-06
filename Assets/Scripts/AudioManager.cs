using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private bool battleStarted = false;

    // Use this for initialization
    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Play("Theme");
    }

    // Play the given sound based on the name
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Couldn't find sound \"" + name + "\".");
            return;
        }
        s.source.Play();
    }

    // Update once per frame
    void Update()
    {
        if (!battleStarted)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Scorpius")
            {
                Sound themeSong = Array.Find(sounds, sound => sound.name == "Theme");
                themeSong.source.Stop();
                Play("Battle");
                battleStarted = true;
            }
        }
    }
}
