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


    // Start is called before the first frame update
    void Start()
    {
        bgTrack = GameObject.FindGameObjectWithTag("BgTrack").GetComponent<AudioSource>();
		soundButtonUnpressedBtnSprite = soundButton.sprite;
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
