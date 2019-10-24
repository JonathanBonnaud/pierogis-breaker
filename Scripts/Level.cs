using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;  // Serialized for debugging puposes

    SceneLoader sceneLoader;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        FindObjectOfType<GameSession>().SetLife(3);        
    }

    public void CountBlocks()
    {
        /*foreach (Transform child in GameObject.Find("Blocks").transform)
        {
            breakableBlocks += 1;
        }*/
        breakableBlocks++;
    }

    public void SubstractBreakableBlock()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
