using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float rotationSpeed = 100f; // Speed of rotation for the player
    public float mouseSensitivity = 2f; // Sensitivity for mouse movement

    public Transform playerCamera; // Assign your Camera here (child of the player)
    private float rotationX = 0f; // Track vertical rotation

    void Update()
    {
        // Movement using arrow keys or WASD
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left/Right (A/D or arrow keys)
        float moveVertical = Input.GetAxis("Vertical"); // Forward/Backward (W/S or arrow keys)

        Vector3 direction = transform.forward * moveVertical + transform.right * moveHorizontal;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Horizontal rotation (Y-axis) using mouse or keyboard
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseX, 0); // Rotate the player horizontally

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0); // Rotate left
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0); // Rotate right
        }

        // Vertical rotation (X-axis) for the camera
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationX -= mouseY; // Invert mouse Y for natural movement
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical rotation to prevent flipping

        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Rotate the camera vertically
    }
}
