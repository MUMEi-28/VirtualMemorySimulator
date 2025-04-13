using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifoFrameGuiController : MonoBehaviour
{
    [Header("Frame Containers")]
	public GameObject frameContainer;
    public Transform containerTransform;

	// Start is called before the first frame update
	void Start()
    {
        
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


    // Instantiate the frames depending on how many the stringlenght is
		for (int i = 0; i < DataManager.instance.GetRefStringLength(); i++)
		{
			Instantiate(frameContainer, containerTransform);
		}
	}

}
