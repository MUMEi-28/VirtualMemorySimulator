using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FifoAlgorithm : MonoBehaviour
{
	private Queue<int> fifoQueue;
	public Transform frameSlotParent;
	public GameObject frameSlot;

	public FrameGui[] frameGui;

	public static FifoAlgorithm instance;

	// Awake is called before start
	private void Awake()
	{
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
	{
		fifoQueue = new Queue<int>();

	}

	public void SimulateFIFO()
	{
		int[] refString = DataManager.instance.GetRefStringArray();
		int frameCount = DataManager.instance.GetFrameCount();

		Queue<int> fifoQueue = new Queue<int>();
		HashSet<int> frameSet = new HashSet<int>(); // for fast lookup

		frameGui = FindObjectsOfType<FrameGui>();

		// Clear old children
		for (int i = 0; i < frameGui.Length; i++)
		{
			foreach (Transform child in frameGui[i].frameSlotParent.transform)
			{
				Destroy(child.gameObject);
			}
		}

		int pageFaults = 0;

		for (int i = 0; i < refString.Length; i++)
		{
			int currentPage = refString[i];

			// Create a column (a container for this step's frame state)
			GameObject column = new GameObject("Step " + i);
			column.transform.SetParent(frameGui[i].frameSlotParent.transform);

			GuiSettings(column);

			// Check if currentPage is in memory
			if (!frameSet.Contains(currentPage))
			{
				pageFaults++;

				// If full, remove the oldest page
				if (fifoQueue.Count >= frameCount)
				{
					int removed = fifoQueue.Dequeue();
					frameSet.Remove(removed);
				}

				// Add the current page
				fifoQueue.Enqueue(currentPage);
				frameSet.Add(currentPage);
			}

			// Convert queue to list so we can index it
			List<int> currentFrameList = new List<int>(fifoQueue);

			// Fill frame slots
			for (int j = 0; j < frameCount; j++)
			{
				GameObject slot = Instantiate(frameSlot, column.transform);
				TMP_Text txt = slot.GetComponentInChildren<TMP_Text>();

				if (j < currentFrameList.Count)
				{
					txt.text = currentFrameList[j].ToString();
				}
				else
				{
					txt.text = "";
				}
			}
		}

		Debug.Log("Total Page Faults: " + pageFaults);
	}


	private void GuiSettings(GameObject column)
	{
		// Layout Settings
		VerticalLayoutGroup vlg = column.AddComponent<VerticalLayoutGroup>();
		vlg.spacing = 15;
		vlg.childForceExpandWidth = true;
		vlg.childForceExpandHeight = false;
		vlg.childControlHeight = false;
		vlg.childControlWidth = false;
		vlg.childAlignment = TextAnchor.UpperCenter;

		// Rect Settings [To position the frames]
		RectTransform rectTransform = column.GetComponent<RectTransform>();
		if (rectTransform != null)
		{
			// Set anchors to stretch
			rectTransform.anchorMin = new Vector2(0, 0);
			rectTransform.anchorMax = new Vector2(1, 1);

			// Optionally, reset the offsets
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
		}
		else
		{
			Debug.LogError("RectTransform component not found.");
		}
	}
}
