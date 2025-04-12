using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class FrameCountController : MonoBehaviour
{
	public int currentFrameCount = 2;
	public int maxFrameCount = 9;
	public int minFrameCount = 1;

	public TMP_Text frameCountText;
	public Warnings warning;

	// Called on very first frame
	private void Start()
	{
		currentFrameCount = minFrameCount;

		// Set the count initially
		frameCountText.text = "Frames: " + currentFrameCount;
	}
	
	// Add frame count
	public void OnClickAdd()
	{
		currentFrameCount++;

		// Add limit to the currentFrameCount
		if (currentFrameCount >= maxFrameCount)
		{
			currentFrameCount = maxFrameCount;

			// Display warning from Warning.cs
			warning.gameObject.SetActive(true);
			warning.DisplayWarning("Maximum Frame Count Reached!");
		}
		UpdateFrameText();
	}

	// Reduce frame count
	public void OnClickReduce()
	{
		currentFrameCount--;

		// Add limit to the currentFrameCount
		if (currentFrameCount <= minFrameCount)
		{
			currentFrameCount = minFrameCount;

			// Display warning from Warning.cs
			warning.gameObject.SetActive(true);
			warning.DisplayWarning("Minimum Frame Count Reached!");
		}
		UpdateFrameText();
	}

	private void UpdateFrameText()
	{
		if (currentFrameCount > 1)
		{
			frameCountText.text = "Frames: " + currentFrameCount;
		}
		else
		{
			frameCountText.text = "Frame: " + currentFrameCount;
		}

	}
}
