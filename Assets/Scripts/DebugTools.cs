using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugTools : MonoBehaviour
{

    public bool collisionDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys() 
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            DisableEnableCollision();
        }
    }

    void LoadNextLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void DisableEnableCollision() 
    {
        collisionDisabled = !collisionDisabled;
        
    }
}
