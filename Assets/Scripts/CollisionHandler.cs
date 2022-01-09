using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly target hit");
                break;
            case "Finish":
                //Debug.Log("Finish area hit");
                StartChangingLevelSequence();
                break;
            default:
                //Debug.Log("Object hit, dead");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        //TODO: add SFX upon crash
        //TODO: add particle effects upon crash

        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();
        Invoke("ReloadLevel", delayTime);
    }

    void StartChangingLevelSequence()
    {
        //TODO: add SFX upon crash
        //TODO: add particle effects upon crash

        GetComponent<Movement>().enabled = false;
        GetComponent<AudioSource>().Stop();
        Invoke("LoadNextLevel", delayTime);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
