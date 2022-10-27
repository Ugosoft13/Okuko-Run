using System.Collections;
using UnityEngine;

public class PlayController2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move;
  

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes

    public bool isGrounded;

   

    public float gravity = -12f;
    public float jumpHeight = 2;
    private Vector3 velocity;

   
    

    

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;
    }

    private void FixedUpdate()
    {
       
        
    }

    void Update()
    {
      

       
       
      
        if (isGrounded && velocity.y < 0)
            velocity.y = -1f;

        if (isGrounded)
        {
            if (SwipeManager.swipeUp)
                Jump();

           
        }
        
        controller.Move(velocity * Time.deltaTime);

        //Gather the inputs on which lane we should be
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        //transform.position = targetPosition;
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }

        controller.Move(move * Time.deltaTime);
    }

    private void Jump()
    {
        

        controller.center = Vector3.zero;
        controller.height = 2;
        

        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);
    }

   

  
}