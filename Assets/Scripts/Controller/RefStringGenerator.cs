using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RefStringGenerator : MonoBehaviour
{
    public int[] pageRefStr;

    public ReferenceLengthController pageRefLengthController;
    public TMP_Text refStringTxt;

	// Start is called before the first frame update
	void Start()
    {

        // Initially Generate a andom page-reference string
        pageRefStr = new int[pageRefLengthController.currentRefLength];    // + 1 to prevent it going out of bounds [arrays start at 0 but ref string legnth start at 1]
        for (int i = 0; i < pageRefLengthController.currentRefLength; i++)
        {
            int randomNumber = Random.Range(0, 9);
            Debug.Log(randomNumber);

            pageRefStr[i] = randomNumber;
        }
		UpdateRefStringText();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickGenerate()
    {
        // Set the size of the array base on the pageRefLenght
		pageRefStr = new int[pageRefLengthController.currentRefLength];// + 1 to prevent it going out of bounds [arrays start at 0 but ref string legnth start at 1]

		// Initially Generate a andom page-reference string
		for (int i = 0; i < pageRefLengthController.currentRefLength; i++)
		{
			int randomNumber = Random.Range(0, 9);
			Debug.Log(randomNumber);

			pageRefStr[i] = randomNumber;
		}

        UpdateRefStringText();

        Debug.Log("REF LENGTH IS : " + pageRefLengthController.currentRefLength);
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
