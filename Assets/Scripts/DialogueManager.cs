using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

public GameObject dialogueBox;
public GameObject continueButton;
public Sprite enemyBox;
public Sprite playerBox;
public Text nameText;
public Text enemyName;
public Text dialogueText;

public float dialogueSpeed=0.01f;

public Animator animator;

    public Dialogue dialogue;
    private Queue<string[]> sentences;
    void Start()
    {
        Debug.Log("STARTUP FOR DM");
        sentences=new Queue<string[]>();
        StartDialogue(dialogue);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen",true);
        Debug.Log("isOPen bool"+animator.GetBool("isOpen"));
        
        Time.timeScale=0;
        // Debug.Log("Starting Conversation with "+dialogue.name);

        continueButton.SetActive(true);

        sentences.Clear();

        for (int x=0; x<dialogue.sentences.Length; x++)
        {
            Debug.Log(dialogue.names[x]+" "+dialogue.sentences[x]);
            sentences.Enqueue(new string[]{dialogue.names[x],dialogue.sentences[x]});
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log("displaying next sentence");
        if (sentences.Count==0)
        {
            Debug.Log("ENDING DIALOGUE NO MORE SENTENCES LEFT");
            EndDialogue();
            return;
        }

        string[] namesen = sentences.Dequeue();
        if (namesen[0].Equals("Orion"))
        {
            nameText.text=namesen[0];
            enemyName.text="";
            dialogueBox.GetComponent<Image>().sprite= playerBox;
        }
        else {
            enemyName.text=namesen[0];
            nameText.text="";
            dialogueBox.GetComponent<Image>().sprite= enemyBox;
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(namesen[1]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text="";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text+=letter;
            yield return new WaitForSecondsRealtime(dialogueSpeed);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen",false);
        continueButton.SetActive(false);
        Time.timeScale=1;
        Debug.Log("End conversation");
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        Time.timeScale=1;
        Debug.Log("Reached time");
    }

}
