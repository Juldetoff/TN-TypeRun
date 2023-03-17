using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        run.interactable = false;
        menu.SetActive(true);
        play.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject menu = null;
    public GameObject play= null;
    public Button run;


    public void enableRun(){
        run.interactable = true;
    }

    public void ChooseInfo(){
        PlayerPrefs.SetString("liste", "info");
        enableRun();
    }

    public void ChooseFish(){
        PlayerPrefs.SetString("liste", "fish");
        enableRun();
    }

    public void ChooseSport(){
        PlayerPrefs.SetString("liste", "sport");
        enableRun();
    }

    public void ChooseShool(){
        PlayerPrefs.SetString("liste", "school");
        enableRun();
    }

    public void ChooseFood(){
        PlayerPrefs.SetString("liste", "food");
        enableRun();
    }

    public void ChooseAnimal(){
        PlayerPrefs.SetString("liste", "animal");
        enableRun();
    }


    public void Menu(){
        menu.SetActive(false);
        play.SetActive(true);
    }

    public void Play(){
        //lancer scene suivante
        SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }
}
