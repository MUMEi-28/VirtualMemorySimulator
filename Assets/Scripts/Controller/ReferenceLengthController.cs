using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ReferenceLengthController : MonoBehaviour
{
	public int currentRefLength = 2;
	public int maxRefStrLength = 9;
	public int minRefStrLength = 1;

	public TMP_Text refStrCountText;
	public Warnings warning;


	// Start is called before the first frame update
	void Start()
	{
		currentRefLength = minRefStrLength;

		// Set the count initially
		refStrCountText.text = "Reference String Length: " + currentRefLength;

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
	}

	private void UpdateRefStrText()
	{
		refStrCountText.text = "Reference String Length: " + currentRefLength;
	}
}
