using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuGui : MonoBehaviour
{
	// SOUND BUTTON
	public Image soundButton;
	public Sprite soundButtonPressedBtnSprite;
	private Sprite soundButtonUnpressedBtnSprite;
	public AudioSource bgTrack;


    // About panel
    public GameObject[] aboutPanels;
    public int currentPanel;

    // Start is called before the first frame update
    void Start()
    {
        bgTrack = GameObject.FindGameObjectWithTag("BgTrack").GetComponent<AudioSource>();
		soundButtonUnpressedBtnSprite = soundButton.sprite;

		// Deactivate all panels initially

		// Deactivate everything
		for (int i = 0; i < aboutPanels.Length; i++)
		{
			aboutPanels[i].SetActive(false);
		}

		// activate the currentPanel index
		aboutPanels[currentPanel].SetActive(true);
	}

    // About Panels
    public void OnClickNextPanel()
    {
        currentPanel++;
        UpdateCurrentPanel();
    }
    public void OnClickPrevPanel()
    {
        currentPanel--;
        UpdateCurrentPanel();
    }
    private void UpdateCurrentPanel()
    {
        // create the looping illusion
        if (currentPanel >= aboutPanels.Length)
        {
        // go back to the start panel
            currentPanel = 0;
        }
        else  if (currentPanel < 0)
        {
            // Go to the last
            currentPanel = aboutPanels.Length - 1;
        }

        // Deactivate everything
        for (int i = 0; i < aboutPanels.Length; i++)
        {
            aboutPanels[i].SetActive(false);
        }

        // activate the currentPanel index
        aboutPanels[currentPanel].SetActive(true);
        
    }

    // Get called on exit button click
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

    public void OnClickSounds()
    {
        if (bgTrack.isPlaying)
        {
            bgTrack.Pause();
            soundButton.sprite = soundButtonPressedBtnSprite;
        }
        else
        {
            bgTrack.Play();
            soundButton.sprite = soundButtonUnpressedBtnSprite;
        }
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
