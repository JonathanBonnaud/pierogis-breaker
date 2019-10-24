using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;
    int maxHits;

    // Cached references
    Level level;
    SpriteRenderer spriteRenderer;

    // State variables
    [SerializeField] int currentHits = 0;  // serialized for debug purposes

    void Start()
    {
        CountBreakableBlocks();
        maxHits = hitSprites.Length + 1;
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);


        if (tag == "Breakable")
        {
            currentHits++;
            if (currentHits >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteIndex = currentHits - 1;
        if (hitSprites[spriteIndex] != null)
        {
            spriteRenderer.sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().AddToScore();
        Destroy(gameObject);  // gameObject here is the current gameObject = the block
        level.SubstractBreakableBlock();
        
        // Debug.Log(collision.gameObject.name);
    }

    // Not used methods
    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
