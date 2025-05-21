using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore; //Current game round score
    public Text scoreText;
    public GameObject gameOverScreen;

    public GameObject gameCharacter;

    public GameObject highScoreText; //CurrentHighScore

    public GameObject newHighScoreScreen; //New high score text

    



    //public AudioSource ; add in audio

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (gameOverScreen.activeSelf == false)
        { //checks to see if the gameover screen is not active, if it is it won't increase score
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
    }

    public void restartGame()
    {
        audioManager.PlaySFX(audioManager.restart); //plays button sound
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void updateHighScore(int newScore){
        //Gets the players highscore stored
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        Debug.Log("HighScore = " + highScore.ToString());
        
        //checks if new score is larger than highest
        bool gotNewHighScore = newScore > highScore;

        if (gotNewHighScore){
            //updates highscore to new one
            PlayerPrefs.SetInt("HighScore", newScore);
            PlayerPrefs.Save();
            highScoreText.GetComponent<Text>().text = highScore.ToString();
            newHighScoreScreen.SetActive(true); //Puts new score text on screen
        }
        else{ // if no new highscore just reputs up the most recent high score onto game over screen
            highScoreText.GetComponent<Text>().text = highScore.ToString();
            newHighScoreScreen.SetActive(false);
        }

    }
    public void gameOver()
    {
        updateHighScore(playerScore);
        gameOverScreen.SetActive(true);
        gameCharacter.GetComponent<GameCharacterScript>().birdIsAlive = false;

    }



}
