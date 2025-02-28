using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logic;

    AudioManager audioManager;

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
            logic.addScore(1);
            // audio -45 add 
            audioManager.PlaySFX(audioManager.score);
        }
    }
}
