using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Controlled by the buttons to select which algorithm will be used
/// </summary>
public class AlgorithmSelector : MonoBehaviour
{
	public GameObject[] algorithmPanels;
	public int currentAlgoIndex;

	public void OnClickNext()
	{
		// Prevent the index from going out of bounds
		if (currentAlgoIndex >= algorithmPanels.Length - 1)
		{
			// Go to the index zero to loop
			currentAlgoIndex = 0;
		}
		else
		{
			currentAlgoIndex++;
		}
		SetAlgorithmEnum(currentAlgoIndex);
		ActivateSelectedAlgoPanel(currentAlgoIndex);
	}
	public void OnClickPrev()
	{
		// Prevent the index from going out of bounds
		if (currentAlgoIndex <= 0)
		{
			// Go to the max index to loop
			currentAlgoIndex = algorithmPanels.Length - 1;
		}
		else
		{
			currentAlgoIndex--;
		}

		SetAlgorithmEnum(currentAlgoIndex);
		ActivateSelectedAlgoPanel(currentAlgoIndex);
	}

	// Activate which panel should be activated
	private void ActivateSelectedAlgoPanel(int index)
	{

		StopCoroutine(CallAlgorithmInstance(index));
		switch (index)
		{
			// FIFO
			case 0:
				algorithmPanels[0].gameObject.SetActive(true);
				algorithmPanels[1].gameObject.SetActive(false);
				algorithmPanels[2].gameObject.SetActive(false);

				break;
			// LRU
			case 1:
				algorithmPanels[0].gameObject.SetActive(false);
				algorithmPanels[1].gameObject.SetActive(true);
				algorithmPanels[2].gameObject.SetActive(false);

				break;
			case 2:
			// OPTIMAL
				algorithmPanels[0].gameObject.SetActive(false);
				algorithmPanels[1].gameObject.SetActive(false);
				algorithmPanels[2].gameObject.SetActive(true);

				break;
			default:
				Debug.Log("OUT OF BOUNDS");
				break;
		}

		StartCoroutine(CallAlgorithmInstance(index));

	}

	public void OnCLickApplySettings()
	{
		StopCoroutine(CallAlgorithmInstance(currentAlgoIndex));
		StartCoroutine(CallAlgorithmInstance(currentAlgoIndex));
	}

	private IEnumerator CallAlgorithmInstance(int index)
	{
		yield return new WaitForSeconds(0.02f);

		switch (index)
		{
			case 0:
				
				FifoAlgorithm.instance.SimulateFIFO();
				break;
			case 1:
				
				LRUAlgorithm.instance.SimulateLRU();
				break;
			case 2:
				
				OptimalAlgorithm.instance.SimulateOptimal();
				break;
			default:
				Debug.Log("OUT OF BOUNDS");
				break;
		}
	}
	private void SetAlgorithmEnum(int index)
	{
		switch (index)
		{
			case 0:
				DataManager.instance.algorithmEnum = AlgorithmEnum.fifo;
				break;
			case 1: 
				DataManager.instance.algorithmEnum = AlgorithmEnum.lru;
				break;
			case 2:
				DataManager.instance.algorithmEnum = AlgorithmEnum.opt;
				break;
			default:
				Debug.Log("OUT OF BOUNDS");
				break;
		}
	}
}
