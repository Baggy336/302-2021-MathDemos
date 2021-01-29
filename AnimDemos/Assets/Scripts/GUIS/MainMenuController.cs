using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    EventSystem events;
    void Start()
    {
        events = GetComponentInChildren<EventSystem>();
    }
    void Update()
    {
        if (events == null) return; // If no events present
        if(events.currentSelectedGameObject == null) // If nothing is selected
        {
            if (events.firstSelectedGameObject != null) 
                events.SetSelectedGameObject(events.firstSelectedGameObject); // Select what is set to first selected
        }
    }
    public void ButtonPlay()
    {
        //print("play");
        SceneManager.LoadScene("week1");
    }
    public void ButtonAbout()
    {
        print("about");
    }
    public void ButtonQuit()
    {
        //print("quit");
        Application.Quit();
    }

}
