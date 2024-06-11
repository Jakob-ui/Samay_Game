using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float maximumSpeed;

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float jumpButtonGracePeriod;

    [SerializeField]
    private Transform cameraTransform;
    private bool toggleControllerSprint = false;


    [Header("Character Movement")]
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private bool isJumping;
    private bool isGrounded;
    private bool wasGroundedLastFrame;
    private bool isCasting;

    [Header("Everything else")]
    private Animator animator;

    [Header("Audio")]
    [SerializeField] AK.Wwise.Event footsteps;
    private bool footstepplay = false;
    private float lastfootsteptime = 0f;
    [SerializeField] private AK.Wwise.Event jump;
    [SerializeField] private AK.Wwise.Event land;
    [SerializeField] AK.Wwise.RTPC myspeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        lastfootsteptime = Time.time;
        myspeed.SetGlobalValue(0);
    }

    void Update()
    {
        wasGroundedLastFrame = isGrounded;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 horizontalVelocity = characterController.velocity;
        horizontalVelocity = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude += 0.5f;
        }

        //Audio
        if (horizontalSpeed > 0 && !footstepplay && !isJumping)
        {
            footsteps.Post(gameObject);
            lastfootsteptime = Time.time;
            footstepplay = true;
        }
        else if (horizontalSpeed > 1 && Time.time - lastfootsteptime > 290 / horizontalSpeed * Time.deltaTime)
        {
            footstepplay = false;
        }
        myspeed.SetGlobalValue(horizontalSpeed);


        if (Input.GetKeyDown("joystick button 8"))
        {
            toggleControllerSprint = !toggleControllerSprint;
        }
        if (toggleControllerSprint)
        {
            inputMagnitude += 0.5f;
        }
        if (horizontalInput == 0 && verticalInput == 0)
        {
            toggleControllerSprint = false;
        }

        // walk blend 
        //if (Input.GetKey(KeyCode.RightShift))
        //{
        //  inputMagnitude /= 2;
        //}
        //animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);

        float speed = inputMagnitude * maximumSpeed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump") && isGrounded || Input.GetKeyDown("joystick button 0") && isGrounded)
        {
            jumpButtonPressedTime = Time.time;
            jump.Post(gameObject);
        }


        if (!wasGroundedLastFrame && isGrounded)
        {
            land.Post(gameObject);
        }


        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            animator.SetBool("IsGrounded", true);
            isGrounded = true;
            animator.SetBool("IsJumping", false);
            isJumping = false;
            animator.SetBool("IsFalling", false);

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;
                animator.SetBool("IsJumping", true);
                isJumping = true;
                ySpeed -= 2f * Time.deltaTime;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("IsGrounded", false);
            isGrounded = false;

            if ((isJumping && ySpeed < 0) || ySpeed < 0)
            {
                animator.SetBool("IsFalling", true);
            }
        }

        Vector3 velocity = movementDirection * speed;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {

            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }


        // Casting
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isCasting = true;
            animator.SetBool("IsCasting", true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            isCasting = false;
            animator.SetBool("IsCasting", false);
        }

    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
