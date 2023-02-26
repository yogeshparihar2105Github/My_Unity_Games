using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(0.6f);
        Debug.Log("Returned value of "+PlayerPrefsController.GetMasterVolume());
    }

    
}
