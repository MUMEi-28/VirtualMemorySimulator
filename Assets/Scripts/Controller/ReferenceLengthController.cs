using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is used to control the length of your page-reference string 
/// page-reference length is controlled by the add and reduce buttons
/// </summary>
public class ReferenceLengthController : MonoBehaviour
{
	public int currentRefLength = 2;
	public int maxRefStrLength = 9;
	public int minRefStrLength = 1;

	public TMP_Text refStrCountText;
	public Warnings warning;

	public Button applyButton;

	// Start is called before the first frame update
	void Start()
	{
		currentRefLength = minRefStrLength;

		// Set the count initially
		refStrCountText.text = "Reference String Length: " + currentRefLength;

		// Add initial value to the dataManager
		DataManager.instance.SetRefStringLength(currentRefLength);
		
	}
	// Add frame count
	public void OnClickAdd()
	{
		currentRefLength++;

		// Add limit to the currentRefLength
		if (currentRefLength >= maxRefStrLength)
		{
			currentRefLength = maxRefStrLength;

			// Display warning from Warning.cs
			warning.gameObject.SetActive(true);
			warning.DisplayWarning("Maximum Reference String Count Reached!");
		}
		UpdateRefStrText();

		// Save the data
		DataManager.instance.SetRefStringLength(currentRefLength);

		// Disable the button when the generate button is not clicked yet
		applyButton.interactable = false;
	}

	// Reduce frame count
	public void OnClickReduce()
	{
		currentRefLength--;

		// Add limit to the currentRefLength
		if (currentRefLength <= minRefStrLength)
		{
			currentRefLength = minRefStrLength;

			// Display warning from Warning.cs
			warning.gameObject.SetActive(true);
			warning.DisplayWarning("Minimum Reference String Count Reached!");
		}
		UpdateRefStrText();

		// Save the data
		DataManager.instance.SetRefStringLength(currentRefLength);

		// Disable the button when the generate button is not clicked yet
		applyButton.interactable = false;
	}

	private void UpdateRefStrText()
	{
		refStrCountText.text = "Reference String Length: " + currentRefLength;
	}
}
