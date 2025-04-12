using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warnings : MonoBehaviour
{
	public TMP_Text warningText;
	public float maxWarnTimer;
	private float currentWarnTimer;

	public CanvasGroup fadeOutWarning;
	private float fadeOutCurve;



	// Gets called on first frame
	private void Start()
	{
		currentWarnTimer = maxWarnTimer;

		// Deactivate Initially
		gameObject.SetActive(false);
	}
	
	// Called every frame
	private void Update()
	{
		FadeOutWarning();
	}

	// Timer for the warning to stop showing
	private void FadeOutWarning()
	{
		// Reduce the timer count in real time (This is just a timer)
		currentWarnTimer -= Time.deltaTime;
		if (currentWarnTimer <= 0)
		{
			currentWarnTimer = maxWarnTimer;

			// Deactivate warning panel after some time
			gameObject.SetActive(false);
		}

		// Start the fade out animation
		fadeOutWarning.alpha = currentWarnTimer / maxWarnTimer; // 1 is non transparent, 0 is fully transparent (3/3 = 1)

		/*		Debug.Log(currentWarnTimer / maxWarnTimer);*/
	}
	// Gets called on other scripts for each specific warnings
	public void DisplayWarning(string warningMessage)
	{
		// Restart the timer again if function got called again
		currentWarnTimer = maxWarnTimer;
		warningText.text = warningMessage;
	}
}
