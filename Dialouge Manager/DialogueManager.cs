using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialougeBox;

    public Image fadeImage;

    private Queue<string> sentences;

    public TMP_Text nameText;
    public TMP_Text dialougeText;

    int levelIndex = 0;

    public bool allowButtonPress;
    bool startFade = false;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {

        if (startFade)
        {
            fadeImage.CrossFadeAlpha(255f, .5f, false);


        }
        else
             if (!startFade)
        {
            fadeImage.CrossFadeAlpha(1f, .5f, false);
        }


        if (allowButtonPress && Input.GetButtonDown("Fire1"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialouge(Dialouge dialoue)
    {
      
        nameText.text = dialoue.name;

        sentences.Clear();
        
        foreach(string sentence in dialoue.sentecnes)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {


        if(sentences.Count == 0)
        {
            EndDialouge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
   
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialougeText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialougeText.text += letter;
            yield return null;
        }
    }

    void EndDialouge()
    {
        //Debug.Log("End of conversation");
        dialougeBox.SetActive(false);
        startFade = true;
        levelIndex++;
        StartCoroutine(CallPLM());


    }

    IEnumerator CallPLM()
    {
        yield return new WaitForSeconds(4f);

        FindObjectOfType<DebuggingMenu>().PlayerLocations(levelIndex);

        yield return new WaitForSeconds(1f);

        startFade = false;


    }

    
}
