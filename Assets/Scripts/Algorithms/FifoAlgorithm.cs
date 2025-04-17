using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FifoAlgorithm : MonoBehaviour
{
	private Queue<int> fifoQueue;
	public Transform frameSlotParent;
	public GameObject frameSlot;

	public Transform fifoContainer;

	public FrameGui[] frameGui;
	public TMP_Text faultTextPrefab;
	public TMP_Text totalFaultText;

	/*	public static FifoAlgorithm instance;
	*/
	// Awake is called before start
	private void Awake()
	{
		//instance = this;
	}

	// Start is called before the first frame update
	void Start()
	{
		fifoQueue = new Queue<int>();

	}

	// Called when the simulate button is pressed
	public void SimulateFIFO()
	{

		// Generate the Frame containers first
		//		FrameGuiController.instance.GenerateFrameContainers();

		// Get all the data from DataManager.cs
		int[] refString = DataManager.instance.GetRefStringArray();
		int frameCount = DataManager.instance.GetFrameCount();

		// List is like an array in c#
		List<int> frameList = new List<int>(frameCount);
		HashSet<int> frameSet = new HashSet<int>();
		int pointer = 0;


		// Get the frameGui in sorted way by hierachy(Use this code if frames got inverted)
		frameGui = FindObjectsOfType<FrameGui>()
			.OrderBy(fg => fg.transform.GetSiblingIndex())
			.ToArray();

		// Get all the FrameGui
		/*	frameGui = FindObjectsOfType<FrameGui>();*/

		// Clear old children [to prevent them from stacking up]
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

			// Create column UI
			GameObject column = new GameObject("Step " + i);
			column.transform.SetParent(frameGui[i].frameSlotParent.transform); // set the new object parent to prevent the gui from getting messed up
			GuiSettings(column);

			// If there's a same number inside the frameSet then pageFault true
			bool isPageFault = !frameSet.Contains(currentPage);

			if (isPageFault)
			{
				pageFaults++;

				if (frameList.Count < frameCount)
				{
					// Just add new
					frameList.Add(currentPage);
					frameSet.Add(currentPage);
				}
				else
				{
					// Replace oldest using pointer logic
					int removedPage = frameList[pointer];
					frameSet.Remove(removedPage);

					frameList[pointer] = currentPage;
					frameSet.Add(currentPage);

					pointer = (pointer + 1) % frameCount; // move circularly
				}
			}

			// Render current frame state from top (oldest) to bottom (newest)
			for (int j = 0; j < frameCount; j++)
			{
				GameObject slot = Instantiate(frameSlot, column.transform);
				TMP_Text txt = slot.GetComponentInChildren<TMP_Text>();

				if (j < frameList.Count)
				{
					txt.text = frameList[j].ToString();

					// Highlight if newly replaced
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
