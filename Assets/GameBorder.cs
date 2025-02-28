using UnityEngine;

public class GameBorder : MonoBehaviour
{
public LogicScript logic;

    AudioManager audioManager; //calls audio manager to access sound
    

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3 ){
            logic.gameOver();
            audioManager.PlaySFX(audioManager.death);

        }
    }
}
