using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.8f;

    [SerializeField] private AudioClip explosionAudio;
    [SerializeField] private AudioClip successAudio;
    
    [SerializeField] private ParticleSystem explosionParticles;
    [SerializeField] private ParticleSystem successParticles;

    AudioSource audioSource;

    bool isTransitioling = false;
    bool collisionDisabled = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        RespondToDebugKeys();    
    }

    void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(isTransitioling || collisionDisabled) { return; }

        switch(other.gameObject.tag)
        {           
            case "Friendly":
                Debug.Log("Começou o jogo");
                break;
            case "Finish":
                StartSuccessSequence();
                break;          
            default:
                StartCrashSequence();
                break;
        }                        
    }

    void StartSuccessSequence(){
        isTransitioling = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successAudio);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;        
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioling = true;
        audioSource.Stop();
        audioSource.PlayOneShot(explosionAudio);
        explosionParticles.Play();
        GetComponent<Movement>().enabled = false;        
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
