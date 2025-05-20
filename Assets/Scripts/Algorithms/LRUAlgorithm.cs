using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LRUAlgorithm : MonoBehaviour
{
	public Transform frameSlotParent;
	public GameObject frameSlot;
	public TMP_Text faultTextPrefab;
	public TMP_Text totalFaultText;
	public FrameGui[] frameGui;

	public static LRUAlgorithm instance;
	private void Awake()
	{
		instance = this;
	}

	public void SimulateLRU()
	{
		int[] refString = DataManager.instance.GetRefStringArray();
		int frameCount = DataManager.instance.GetFrameCount();

		List<int> frameList = new List<int>(frameCount);
		Dictionary<int, int> lastUsedMap = new Dictionary<int, int>();
		int pageFaults = 0;

		// Sort FrameGui based on hierarchy
		frameGui = FindObjectsOfType<FrameGui>()
			.OrderBy(fg => fg.transform.GetSiblingIndex())
			.ToArray();

		// Clear previous frame states
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
					// Find least recently used page
					int lruPage = frameList.OrderBy(p => lastUsedMap.ContainsKey(p) ? lastUsedMap[p] : -1).First();
					int indexToReplace = frameList.IndexOf(lruPage);
					frameList[indexToReplace] = currentPage;
				}
			}

			// Update last used time
			lastUsedMap[currentPage] = i;

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
