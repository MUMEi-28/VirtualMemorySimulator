using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	private int[] refString;

    public static DataManager instance;

    // Awake is called before the first frame updata
	private void Awake()
	{
        instance = this;
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

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
}
