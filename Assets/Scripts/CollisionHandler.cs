using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Acabou o jogo");
                break;
            case "Friendly":
                Debug.Log("Começou o jogo");
                break;
            case "Fuel":
                Debug.Log("Combustivel");
                break;            
            default:
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
