/*
 * (Jacob Welch)
 * (CameraMovement)
 * (CitySim)
 * (Description: Handles the movement of the camera by the player.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region Fields
    [Range(0.0f, 1000.0f)]
    [Tooltip("The speed that players can move the camera with their keyboard")]
    [SerializeField] private float keyboardMoveSpeed = 8;

    [Range(0.0f, 1000.0f)]
    [Tooltip("The speed that players can move the camera with the mouse")]
    [SerializeField] private float mouseMoveSpeed = 5;

    /// <summary>
    /// The last position recieved for the users mouse.
    /// </summary>
    private Vector2 lastMousePos = Vector2.zero;

    /// <summary>
    /// A reduction applied to the mosue move speed.
    /// </summary>
    private const float mouseSpeedReduction = 0.01f;

    private Rigidbody2D rb2D;
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Awake()
    {
        lastMousePos = Input.mousePosition;
        rb2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void FixedUpdate()
    {
        CheckForInput();
    }

    /// <summary>
    /// Checks for the users keyboard and mouse inputs for moving the camera.
    /// </summary>
    private void CheckForInput()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            // Moves the player based on the mouses delta position
            var mosueDelta = lastMousePos - (Vector2)Input.mousePosition;
            MoveCamera(mosueDelta, mouseMoveSpeed*mouseSpeedReduction, Time.fixedDeltaTime);
        }
        else
        {
            CheckKeyboardInput();
        }

        lastMousePos = Input.mousePosition;
    }

    /// <summary>
    /// Checks for keyboard input and moves the 
    /// </summary>
    private void CheckKeyboardInput()
    {
        var xMove = Input.GetAxisRaw("Horizontal");
        var yMove = Input.GetAxisRaw("Vertical");

        var moveDir = new Vector2(xMove, yMove);
        moveDir.Normalize();

        MoveCamera(moveDir, keyboardMoveSpeed, Time.fixedDeltaTime);
    }

    /// <summary>
    /// Moves the camera in a give direction and for a given amount.
    /// </summary>
    /// <param name="direction">The direction to move the camera.</param>
    /// <param name="delta">The delta over which the camera will move.</param>
    /// <param name="moveSpeed">The speed at which the camera will move.</param>
    private void MoveCamera(Vector2 direction, float moveSpeed, float delta = 1)
    {
        var moveVector = (direction * moveSpeed * delta);
        rb2D.MovePosition(rb2D.position + moveVector);
    }
    #endregion
}
