using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
   
    public float moveSpeed = 5;
    public float deadZone = -30; //Space of left side of camera once pipes exit screen

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; //moves pipes at a constant speed across the screen
        if(transform.position.x < deadZone){ //if pipe is past deadzone
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
