using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
   public int brakeableBlock;

    //cached reference
    SceneLoader sceneLoaderScript;

    private void Start()
    {
        sceneLoaderScript = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        brakeableBlock++;
    }

    public void MinusBrakeableBlock()
    {
        brakeableBlock--;

        if(brakeableBlock==0)
        {
            sceneLoaderScript.LoadNextScene();
        }
    }

     
}
