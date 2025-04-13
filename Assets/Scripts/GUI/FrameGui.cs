using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This is the gameObject prefab block that get instantiated accordingly
/// </summary>
public class FrameGui : MonoBehaviour
{
    public TMP_Text refStringNum;

    [Header("Page Frame Row")]
    public GameObject frameSlot;
    public GameObject frameSlotParent;

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
        for (int i = 0; i < DataManager.instance.GetFrameCount(); i++)
        {
            Instantiate(frameSlot, frameSlotParent.gameObject.transform);
        }
    }

    // Apply the settings
    public void OnClickApply()
    {
        GenerateFrameSlots();
    }
}
