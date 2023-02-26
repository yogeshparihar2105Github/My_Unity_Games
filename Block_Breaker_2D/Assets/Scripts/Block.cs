using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject sparkleVFX;
    
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    level LevelScript;  //making LevelScript variable of type level class;
    gameSession GameSessionScript; 

    private void Start()
    {
        CountBreakableBlocks();

        GameSessionScript = FindObjectOfType<gameSession>();
    }

    private void CountBreakableBlocks()
    {
        LevelScript = FindObjectOfType<level>();

        if(tag == "breakable")
        {
            LevelScript.CountBlocks();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "breakable")
        {
            HandlingHits();

        }

    }

    private void HandlingHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Missing sprite : " + gameObject.name);
        }
        
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        LevelScript.MinusBrakeableBlock();
        GameSessionScript.AddToScore();
        TriggerSparkleVFX();
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    public void TriggerSparkleVFX()
    {
        GameObject sparkle = Instantiate(sparkleVFX, transform.position, transform.rotation);
        Destroy(sparkle, 2f);
    }
}
