using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordBank : MonoBehaviour
{
    private List<string> originalWords = new List<string>()
    {
        "Rock", "Obstacle", "Danger","Squid"
    };
    private List<string> difficulWords = new List<string>()
    {
        "Anticonstitutionnellement"
    };

    private List<string> workingWords = new List<string>();
    private List<string> hardwords = new List<string>();

    private void Awake()
    {
        ResetBank();
    }

    private void ResetBank(){
        workingWords.Clear();
        workingWords.AddRange(originalWords); //addrange copie 
        hardwords.AddRange(difficulWords);
        ConvertToLower(hardwords);
        ConvertToLower(workingWords);
        Shuffle(hardwords);
        Shuffle(workingWords);
    }

    private void Shuffle(List<string> list)
    {
        for(int i=0;i<list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void ConvertToLower(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if(workingWords.Count > 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        else{
            ResetBank();
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        return newWord;
    }

    public string GetHardWord()
    {
        string newWord = string.Empty;

        if(hardwords.Count > 0)
        {
            newWord = hardwords.Last();
            hardwords.Remove(newWord);
        }
        return newWord;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
