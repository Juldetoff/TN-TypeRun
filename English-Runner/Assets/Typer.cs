using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typer : MonoBehaviour
{
    public WordBank wordbank = null;
    public TextMeshPro wordOutput = null;

    private string remainingWord = string.Empty;
    private string typedWord = string.Empty;
    private string currentWord = string.Empty;

    // Start is called before the first frame update
    private void Start()
    {
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        currentWord = wordbank.GetWord();
        typedWord = string.Empty;
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = "<color=green>" +typedWord 
            + "</color>" + remainingWord;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
            Debug.Log(keysPressed);
            if(keysPressed.Length ==1 && keysPressed!=" ")
            {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsWordComplete())
            {
                //BOOM LE CAILLOUX
                SetCurrentWord(); 
            }
        }
        else
        {
            WrongLetter();
        }
    }

    private void WrongLetter()
    {
        typedWord = string.Empty;
        remainingWord = currentWord;
        wordOutput.text = "<color=red>"+ remainingWord + "</color>";
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        char typedLetter = remainingWord[0];
        typedWord += typedLetter;
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

}
