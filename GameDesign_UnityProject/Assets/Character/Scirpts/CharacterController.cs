using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZZCharacterController : MonoBehaviour
{
    private Animator animator;
    private bool isMoving, isRunning, isJumping;
    private Vector2 movementVector;
    [SerializeField] private bool analogMovement = true;
    [SerializeField] private bool capVelocity = false;
    [SerializeField] private bool animationSpeedModulation = false;
    [SerializeField] private float walkSpeedMultiplier = 1.7f;
    [SerializeField] private float runSpeedMultiplier = 2.6f;
    [SerializeField] private float movementDeadZone = 0.15f;
    [SerializeField] private float xBoundLeft = -10f, xBoundRight = 10f, zBoundDown = -10f, zBoundUp = 10f;

    [SerializeField] public bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    private Vector3 velocity;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void GetMovementInput()
    {
        string horizontalAxisName = "Horizontal";
        string verticalAxisName = "Vertical";
        if (analogMovement)
        {
            horizontalAxisName = "HorizontalAnalog";
            verticalAxisName = "VerticalAnalog";
        }

        float xComponent = Input.GetAxis(horizontalAxisName);
        float zComponent = Input.GetAxis(verticalAxisName);

        movementVector = new Vector2(xComponent, zComponent);

        if (capVelocity && movementVector.magnitude > 1.0f)
        {
            movementVector.Normalize();
        }

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
    }

    private float GetRunInput()
    {
       // InputVisualizer.Instance.UpdateButtonSlider(Input.GetAxis("RunButton"));

        if (Input.GetButton("RunButton"))
        {
            isRunning = true;
            return runSpeedMultiplier;
        }
        else
        {
            isRunning = false;
            return walkSpeedMultiplier;
        }
    }

    private void Move(float multiplier)
    {
        if (movementVector.magnitude >= movementDeadZone)
        {
            isMoving = true;
            RotateTowardsDirection(movementVector);
        }
        else
        {
            isMoving = false;
            return;
        }

        transform.position += new Vector3(movementVector.x, 0.0f, movementVector.y) * multiplier * Time.deltaTime;
    }

    private void RotateTowardsDirection(Vector2 rotateTowards)
    {
        Vector2 unitVector = rotateTowards.normalized;
        float yRotation = Mathf.Atan2(rotateTowards.x, rotateTowards.y) * 57.3f; //57.3 multiplication to convert radians to degrees
        transform.rotation = Quaternion.Euler(0.0f, yRotation, 0.0f);
    }

    private void UpdateAnimator()
    {
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isRunning", isRunning);
        if (animationSpeedModulation)
        {
            animator.SetFloat("animationSpeedModulation", movementVector.magnitude);
        }
        else
        {
            animator.SetFloat("animationSpeedModulation", 1.0f);
        }
        //insert here other animator variables
    }

  
    /*private void GetJumpInput()
    {
        //InputVisualizer.Instance.UpdateButtonSlider(Input.GetAxis("RunButton"));

        if (Input.GetButtonDown("JumpButton"))
        {
            isRunning = true;
            animator.SetBool("Jump", true);
            Debug.Log("ha saltato");
            //SetBool
        }
        else
        {
            isRunning = false;
            animator.SetBool("Jump", false);
        }

    }*/

    private void StopTime()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    private void Update()
    {
        GetMovementInput();
        //CheckBoundaries();
        Move(GetRunInput());
        UpdateAnimator();
        StopTime();
        //GetJumpInput();
    }
}
