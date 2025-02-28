using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering;

public class GameCharacterScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); //calls all logical functions
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true)
        { //bird can move as long as space is hit and game is active
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            //DM-CGS-07 could be used for keyboard sounds or -46
            audioManager.PlaySFX(audioManager.wings);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //works to restart game when bird hits the pipes or the borders
    {
        logic.gameOver();
        birdIsAlive = false;
        //import audio DM-CGS-03 here its a bonk noise 
        audioManager.PlaySFX(audioManager.death);
    }
}
