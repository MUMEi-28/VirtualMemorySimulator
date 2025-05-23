using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This script is used to control how many frames you want to have
/// Frame count is controlled by the add and reduce buttons
/// </summary>
public class FrameCountController : MonoBehaviour
{
	public int currentFrameCount;
	public int maxFrameCount;
	public int minFrameCount;

	public TMP_Text frameCountText;
	public Warnings warning;


	// Called on very first frame
	private void Start()
	{
		// Set the count initially
		frameCountText.text = "Frames: " + currentFrameCount;

		// Add initial value to the dataManager
		DataManager.instance.SetFrameCount(currentFrameCount);
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

		// Update DataManager datas
		DataManager.instance.SetFrameCount(currentFrameCount);
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

		// Update DataManager datas
		DataManager.instance.SetFrameCount(currentFrameCount);
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
