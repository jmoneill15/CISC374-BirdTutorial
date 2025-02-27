using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    //public AudioSource ; add in audio

  
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        if(gameOverScreen.activeSelf == false){ //checks to see if the gameover screen is not active, if it is it won't increase score
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }
 
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
    }
    
}
