using Unity.VisualScripting;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D bird;
    public float jumpForce = 10;
    public float holdForce = 3;
    public float sprintForce = 5;
    public LogicScript logic;
    public bool birdIsActive = true;

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
        
        if(Input.GetKeyDown(KeyCode.Space) && birdIsActive){
            Jump();
        }

        if(Input.GetKey(KeyCode.LeftArrow) && birdIsActive){
            Hold();
        }

        if(Input.GetKey(KeyCode.RightArrow) && birdIsActive){
            Sprint();
        }

        CheckOffScreen();

    }

    void Jump(){
        bird.linearVelocity = Vector2.up*jumpForce;
    }

    void Hold(){
        bird.linearVelocity = Vector2.left*holdForce;
    }

    void Sprint(){
        bird.linearVelocity = Vector2.right*sprintForce;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
     
        birdIsActive = false;
    }

    void CheckOffScreen(){
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPosition.y > 1 || screenPosition.y < 0)
    {
        logic.gameOver();
        birdIsActive = false;
    }
    }
}
