using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get called on exit button click
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void OnClickSounds()
    {
        Debug.Log("SOUND CLICKED");
    }

    public void OnClickGithub()
    {
        Application.OpenURL("https://github.com/MUMEi-28/VirtualMemorySimulator");
    }


    public void ChangeImageOnClick(Sprite imgPrefab, Image imgComponent)
    {
        imgComponent.sprite = imgPrefab;
    }
}
