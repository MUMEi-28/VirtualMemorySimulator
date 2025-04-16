using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FrameGuiController : MonoBehaviour
{
    [Header("Frame Containers")]
	public GameObject frameContainer;
    public Transform fifoContainerTransform;
    public Transform lruContainerTransform;
    public Transform optContainerTransform;

    public GameObject[] frameContainerArray;


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

	public void OnClickApply()
    {
        GenerateFrameContainers();
    }

    public void GenerateFrameContainers()
    {
        if (DataManager.instance.algorithmEnum == AlgorithmEnum.fifo)
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
		else if (DataManager.instance.algorithmEnum == AlgorithmEnum.opt)
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
		else if (DataManager.instance.algorithmEnum == AlgorithmEnum.lru)
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
        else
        {
            Debug.Log("CAN'T FIND ALGORITHM");
        }
	}

}
