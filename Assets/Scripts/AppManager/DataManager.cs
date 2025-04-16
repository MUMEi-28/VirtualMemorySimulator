using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum AlgorithmEnum
{
	fifo,
	lru,
	opt
}

/// <summary>
/// This is where all the datas are saved
/// </summary>
public class DataManager : MonoBehaviour
{
    [SerializeField]
    private int frameCount;
    [SerializeField]
	private int refStringLenght;
    [SerializeField]
    private int[] refStringArray;

	[SerializeField]
	private int pageFault;

	public AlgorithmEnum algorithmEnum;

	public static DataManager instance;

    // Awake is called before the first frame updata
	private void Awake()
	{
        instance = this;
	}
	// Start is called before the first frame update
	/*void Start()
    {
		// This would be from another script, like a generator
		SetRefStringArray(new int[] { 7, 0, 1, 2 });
	}*/

	// Update is called once per frame
	void Update()
    {
        
    }

    
    public int GetFrameCount()
    {
        return frameCount;
    }
    public void SetFrameCount(int count)
    {
        frameCount = count;
    }
    public int GetRefStringLength()
    {
        return refStringLenght;
    }
    public void SetRefStringLength(int length)
    {
        refStringLenght = length;
    }
    public void SetRefStringArray(int[] strArray)
    {
        refStringArray = strArray;
    }
    public int[] GetRefStringArray()
    {
        return refStringArray;
    }

    public void SetPageFault(int fault)
    {
        pageFault = fault;
	}
    public int GetPageFault()
    {
        return pageFault;
    }
}
