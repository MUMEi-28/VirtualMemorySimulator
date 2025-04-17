using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;



public class FrameGuiController : MonoBehaviour
{
    [Header("Frame Containers")]
	public GameObject frameContainer;
    public Transform fifoContainerTransform;
    public Transform lruContainerTransform;
    public Transform optContainerTransform;

    public GameObject[] frameContainerArray;

    public static FrameGuiController instance;

	// Controls for simulation GUI
	[Header("Simulated Panels")]
	public bool isFifoSimulated;
	public bool isLruSimulated;
	public bool isOptimalSimulated;
	public TMP_Text[] pageFaultTexts;

	private void Awake()
	{
		// Make an instance of the object
		instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
     /*   GenerateFrameContainers();*/
	//	frameContainerArray = new GameObject[DataManager.instance.GetRefStringLength()];

	}

	// Update is called once per frame
	void Update()
    {
	}
	// Updates the boolean of each simulation panel
	public void OnClickSimulated(int index)
	{
		switch (index)
		{
			case 0:
				isFifoSimulated = true;
			/*	isLruSimulated = false;
				isOptimalSimulated = false;*/
				break;
			case 1:
				//isFifoSimulated = false;
				isLruSimulated = true;
				//isOptimalSimulated = false;
				break;
			case 2:
			/*	isFifoSimulated = false;
				isLruSimulated = false;*/
				isOptimalSimulated = true;
				break;
		}
	}
	// Generate the reference string on prev next click
	public void OnClickPrevNextButton()
	{
		GenerateFrameContainers();
	}

	public void OnClickApply()
    {
		// If any of algorithm are simulated then reset them all
		if (isFifoSimulated | isLruSimulated | isOptimalSimulated)
		{

			// Reset the fifoContainerTransform 
			foreach (Transform item in fifoContainerTransform)
			{
				Destroy(item.gameObject);
			}
			// Reset the optContainerTransform
			foreach (Transform item in optContainerTransform)
			{
				Destroy(item.gameObject);
			}

			// Reset the lruContainerTransform
			foreach (Transform item in lruContainerTransform)
			{
				Destroy(item.gameObject);
			}
		}

		// Reset all simulations to create new ones
		isFifoSimulated = false;
		isLruSimulated = false;
		isOptimalSimulated = false;

		GenerateFrameContainers();


		// Reset all page fault texts
		foreach (TMP_Text item in pageFaultTexts)
		{
			item.text = "Total Page Faults: ";
		}

	}
	public void GenerateFrameContainers()
    {


		if (DataManager.instance.algorithmEnum == AlgorithmEnum.fifo)
		{
			// Don't continue if theres already a frame instantiated
			if (!isFifoSimulated)
			{
				// Reset the container first before adding, to avoid duplications
				foreach (Transform item in fifoContainerTransform)
				{
					Destroy(item.gameObject);
				}

				int refLength = DataManager.instance.GetRefStringLength();
				frameContainerArray = new GameObject[refLength];

				// Instantiate the frames depending on how many the stringlenght is
				for (int i = 0; i < refLength; i++)
				{
					GameObject item = Instantiate(frameContainer, fifoContainerTransform);

					// Add the frame to the array [used to compare on FrameGui.cs
					frameContainerArray[i] = item;
				}
			}
		}
		else if (DataManager.instance.algorithmEnum == AlgorithmEnum.opt)
		{

			// Don't continue if theres already a frame instantiated
			if (!isOptimalSimulated)
			{
				// Reset the container first before adding, to avoid duplications
				foreach (Transform item in optContainerTransform)
				{
					Destroy(item.gameObject);
				}

				int refLength = DataManager.instance.GetRefStringLength();
				frameContainerArray = new GameObject[refLength];

				// Instantiate the frames depending on how many the stringlenght is
				for (int i = 0; i < refLength; i++)
				{
					GameObject item = Instantiate(frameContainer, optContainerTransform);

					// Add the frame to the array [used to compare on FrameGui.cs
					frameContainerArray[i] = item;
				}
			}

		}
		else if (DataManager.instance.algorithmEnum == AlgorithmEnum.lru)
		{
			// Don't continue if theres already a frame instantiated
			if (!isLruSimulated)
			{
				// Reset the container first before adding, to avoid duplications
				foreach (Transform item in lruContainerTransform)
				{
					Destroy(item.gameObject);
				}

				int refLength = DataManager.instance.GetRefStringLength();
				frameContainerArray = new GameObject[refLength];

				// Instantiate the frames depending on how many the stringlenght is
				for (int i = 0; i < refLength; i++)
				{
					GameObject item = Instantiate(frameContainer, lruContainerTransform);

					// Add the frame to the array [used to compare on FrameGui.cs
					frameContainerArray[i] = item;
				}
			}
		}
		else
		{
			Debug.Log("CAN'T FIND ALGORITHM");
		}
	}

}
