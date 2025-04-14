using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifoFrameGuiController : MonoBehaviour
{
    [Header("Frame Containers")]
	public GameObject frameContainer;
    public Transform containerTransform;

    public GameObject[] frameContainerArray;

	// Start is called before the first frame update
	void Start()
    {
        GenerateFrameContainers();
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
        // Reset the container first before adding, to avoid duplications
        foreach (Transform item in containerTransform)
        {
            Destroy(item.gameObject);
        }

		int refLength = DataManager.instance.GetRefStringLength();
		frameContainerArray = new GameObject[refLength];

		// Instantiate the frames depending on how many the stringlenght is
		for (int i = 0; i < refLength; i++)
        {
            GameObject item = Instantiate(frameContainer, containerTransform);

            // Add the frame to the array [used to compare on FrameGui.cs
            frameContainerArray[i] = item;

            // Set the Gui frame
          /*  FifoAlgorithm.instance.frameGui[i] = item.GetComponent<FrameGui>();*/

        } 
	}

}
