using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 

public class ScreenLogic : MonoBehaviour
{
    
    public GameObject titleScreen;
    
    public void LoadGame(){
        Debug.Log("Game Screen Loaded");
        SceneManager.LoadScene(1); //Changes it to the first screen in the scenes hierarchy

    }
}
