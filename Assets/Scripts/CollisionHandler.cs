using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly target hit");
                break;
            case "Finish":
                Debug.Log("Finish area hit");
                break;
            case "Fuel":
                Debug.Log("Fuel hit");
                break;
            default:
                //Debug.Log("Object hit, dead");
                ReloadLevel();
                
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
