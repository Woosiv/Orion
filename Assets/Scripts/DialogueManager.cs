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
public Text dialogueText;

public float dialogueSpeed=0.01f;

public Animator animator;

    public Dialogue dialogue;
    private Queue<string[]> sentences;
    void Start()
    {
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
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }

        string[] namesen = sentences.Dequeue();
        nameText.text=namesen[0];
        if (namesen[0].Equals("Orion"))
        {
            dialogueBox.GetComponent<Image>().sprite= playerBox;
            nameText.transform.position = new Vector3(103f,83.2f,0.3f);
        }
        else {
            dialogueBox.GetComponent<Image>().sprite= enemyBox;
            nameText.transform.position = new Vector3(520f,83.2f,0.3f);
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
