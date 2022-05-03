using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed;
    public float laneDistance = 3;
    public float jumpForce;
    public float Gravity = -20;
    public float maxSpeed;

    private CharacterController controller;
    private Vector3 direction;
    private int desiredLane = 1;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Increase Speed
        if(forwardSpeed < maxSpeed) {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
        
        direction.z = forwardSpeed;

        if (controller.isGrounded)
        {
            direction.y = -1;
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }

            if(SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if(desiredLane == 3){
                desiredLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if(desiredLane == -1){
                desiredLane = 0;
            }
        }

        // For Swipe
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if(desiredLane == 3){
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if(desiredLane == -1){
                desiredLane = 0;
            }
        }

        // Calculated where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        // transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.fixedDeltaTime);
        // controller.center = controller.center;
        if (transform.position == targetPosition) {
            return;
        }

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude) {
            controller.Move(moveDir);
        } else {
            controller.Move(diff);
        }
    }

    private void FixedUpdate(){
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }
}
