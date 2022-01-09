using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successLandingSound;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successLandingParticle;
    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter(Collision other) {
        if(isTransitioning) { return; }

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
        //TODO: add particle effects upon crash

        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSound);
        crashParticle.Play();
        isTransitioning = true;
        Invoke("ReloadLevel", delayTime);
    }

    void StartChangingLevelSequence()
    {
        //TODO: add particle effects upon crash

        GetComponent<Movement>().enabled = false;
        audioSource.Stop();
        if(!audioSource.isPlaying) 
        {
            audioSource.PlayOneShot(successLandingSound);
        } 
        successLandingParticle.Play();
        isTransitioning = true;    
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
