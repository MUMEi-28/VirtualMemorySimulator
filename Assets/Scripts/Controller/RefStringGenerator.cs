using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This is used to generate random page-reference string and takes data from ReferenceLengthController.cs
/// Is controlled by the generate button
/// </summary>

public class RefStringGenerator : MonoBehaviour
{
    public int[] pageRefStr;

    public ReferenceLengthController pageRefLengthController;
    public TMP_Text refStringTxt;

    private DataManager dataManager;

	// Start is called before the first frame update
	void Start()
    {

        // Initially Generate a andom page-reference string
        pageRefStr = new int[pageRefLengthController.currentRefLength];    // + 1 to prevent it going out of bounds [arrays start at 0 but ref string legnth start at 1]
        for (int i = 0; i < pageRefLengthController.currentRefLength; i++)
        {
            int randomNumber = Random.Range(0, 9);

            pageRefStr[i] = randomNumber;
        }
		UpdateRefStringText();

		// Initially add value
		DataManager.instance.SetRefStringArray(pageRefStr);

	}

	// Update is called once per frame
	void Update()
    {
        
    }

    public void OnClickGenerate()
    {
        // Set the size of the array base on the pageRefLenght
		pageRefStr = new int[pageRefLengthController.currentRefLength];

		// Generate a random number arrays base on refLength
		for (int i = 0; i < pageRefLengthController.currentRefLength; i++)
		{
			int randomNumber = Random.Range(0, 9);
			pageRefStr[i] = randomNumber;
		}

		// Update DataManager with the new reference string
		DataManager.instance.SetRefStringArray(pageRefStr);

		// Update the GUI
		UpdateRefStringText();
	}

    private void UpdateRefStringText()
    {
        // Clear the text first before setting another
        refStringTxt.text = "";


        // Set the text to the value
        for (int i = 0; i< pageRefLengthController.currentRefLength; i++)
        {
			// To make sure the string shows [2-5-1-5-6]
			refStringTxt.text += pageRefStr[i];

			// Add dash unless it's the last number
			if (i != pageRefLengthController.currentRefLength - 1)
			{
				refStringTxt.text += "-";
			}
		}
    }
}
