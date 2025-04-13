using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This is the gameObject prefab block that get instantiated accordingly
/// </summary>
public class FrameGui : MonoBehaviour
{
    public TMP_Text refStringNumTxt;

    [Header("Page Frame Row")]
    public GameObject frameSlot;
    public GameObject frameSlotParent;

	[SerializeField]
	FifoFrameGuiController fifoFrameGuiController;
	
	// Awake is called before the first frame update
	private void Awake()
	{
		fifoFrameGuiController = FindObjectOfType<FifoFrameGuiController>();
	}

	// Start is called before the first frame update
	void Start()
    {
        // Set the Frame Slots when they got instantiated
        GenerateFrameSlots();


	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void GenerateFrameSlots()
	{
		int[] refString = DataManager.instance.GetRefStringArray();
		Debug.Log(refString.Length);


		for (int i = 0; i < DataManager.instance.GetFrameCount(); i++)
		{
			Instantiate(frameSlot, frameSlotParent.gameObject.transform);
		}

		for (int i = 0; i < refString.Length; i++)
		{
			GameObject frameObj = fifoFrameGuiController.frameContainerArray[i];
			TMP_Text text = frameObj.GetComponentInChildren<TMP_Text>();

			if (text != null)
			{
				text.text = refString[i].ToString();
			}
			else
			{
				Debug.LogWarning("TMP_Text not found in frameContainer child");
			}
		}
	}
}
