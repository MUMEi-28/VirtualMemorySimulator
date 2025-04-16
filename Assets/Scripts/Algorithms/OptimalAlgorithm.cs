using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptimalAlgorithm : MonoBehaviour
{
	public Transform frameSlotParent;
	public GameObject frameSlot;
	public TMP_Text faultTextPrefab;
	public TMP_Text totalFaultText;
	public FrameGui[] frameGui;

	public static OptimalAlgorithm instance;

	private void Awake()
	{
		instance = this;
	}

	public void SimulateOptimal()
	{
		int[] refString = DataManager.instance.GetRefStringArray();
		int frameCount = DataManager.instance.GetFrameCount();

		List<int> frameList = new List<int>(frameCount);
		int pageFaults = 0;

		// Sort FrameGui based on hierarchy
		frameGui = FindObjectsOfType<FrameGui>()
			.OrderBy(fg => fg.transform.GetSiblingIndex())
			.ToArray();

		// Clear old children
		foreach (var gui in frameGui)
		{
			foreach (Transform child in gui.frameSlotParent.transform)
			{
				Destroy(child.gameObject);
			}
		}

		for (int i = 0; i < refString.Length; i++)
		{
			int currentPage = refString[i];

			// Create column for current step
			GameObject column = new GameObject("Step " + i);
			column.transform.SetParent(frameGui[i].frameSlotParent.transform);
			GuiSettings(column);

			bool isPageFault = !frameList.Contains(currentPage);

			if (isPageFault)
			{
				pageFaults++;

				if (frameList.Count < frameCount)
				{
					frameList.Add(currentPage);
				}
				else
				{
					// Find optimal page to replace
					int indexToReplace = -1;
					int farthestUse = -1;

					for (int j = 0; j < frameList.Count; j++)
					{
						int futureIndex = int.MaxValue;
						for (int k = i + 1; k < refString.Length; k++)
						{
							if (refString[k] == frameList[j])
							{
								futureIndex = k;
								break;
							}
						}

						if (futureIndex > farthestUse)
						{
							farthestUse = futureIndex;
							indexToReplace = j;
						}
					}

					frameList[indexToReplace] = currentPage;
				}
			}

			// Render current frame state
			for (int j = 0; j < frameCount; j++)
			{
				GameObject slot = Instantiate(frameSlot, column.transform);
				TMP_Text txt = slot.GetComponentInChildren<TMP_Text>();

				if (j < frameList.Count)
				{
					txt.text = frameList[j].ToString();

					if (isPageFault && frameList[j] == currentPage)
					{
						slot.GetComponent<Image>().color = Color.red;
					}
				}
				else
				{
					txt.text = "";
				}
			}

			if (isPageFault)
			{
				Instantiate(faultTextPrefab, column.transform);
			}
		}

		totalFaultText.text = "Total Page Faults: " + pageFaults;
		DataManager.instance.SetPageFault(pageFaults);
	}

	private void GuiSettings(GameObject column)
	{
		VerticalLayoutGroup vlg = column.AddComponent<VerticalLayoutGroup>();
		vlg.spacing = 15;
		vlg.childForceExpandWidth = true;
		vlg.childForceExpandHeight = false;
		vlg.childControlHeight = false;
		vlg.childControlWidth = false;
		vlg.childAlignment = TextAnchor.UpperCenter;

		RectTransform rectTransform = column.GetComponent<RectTransform>();
		if (rectTransform != null)
		{
			rectTransform.anchorMin = new Vector2(0, 0);
			rectTransform.anchorMax = new Vector2(1, 1);
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
		}
		else
		{
			Debug.LogError("RectTransform component not found.");
		}
	}
}
