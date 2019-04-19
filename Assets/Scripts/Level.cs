using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField] int breakableblock;
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableblock++;
    }

    public void BlockDestroyed()
    {
        breakableblock--;
        if (breakableblock <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
