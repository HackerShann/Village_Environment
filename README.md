# 3D Village Environment Unity Project

## Overview
Welcome to the **3D Environment Unity Project**! This project features a beautifully crafted 3D world with a charming little village, a tiny mushroom village, and a wicked witch that brings a touch of mystery to the scene. The project also includes a player character with keyboard and mouse movement controls for immersive navigation.

## Features
- A detailed 3D environment featuring:
  - A quaint little village.
  - A magical tiny mushroom village.
  - A wicked witch character.
- **Keyboard and Mouse Movement Controls** for player navigation.
- Adjustable movement speed, rotation speed, and mouse sensitivity.

## Controls
### Keyboard
- **W / Up Arrow**: Move forward
- **S / Down Arrow**: Move backward
- **A / Left Arrow**: Rotate/move left
- **D / Right Arrow**: Rotate/move right

### Mouse
- **Mouse Movement**: Look around (rotate camera)

## How to Use
1. Clone the repository or download the project files.
2. Open the project in Unity.
3. Ensure the **KeyboardMovement.cs** script is attached to the player GameObject.
4. Assign the player camera (a child of the player) to the `playerCamera` field in the script.
5. Press **Play** in the Unity Editor to explore the 3D environment.

## Code
Below is the main movement script used in the project:

```csharp
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
```

## Requirements
- **Unity Version**: Unity 2020.3 or higher
- **Dependencies**: None

## Customization
You can tweak the player movement settings by modifying the following variables in the **KeyboardMovement.cs** script:
- `moveSpeed`: Adjust the speed of movement.
- `rotationSpeed`: Change the speed of rotation using keyboard.
- `mouseSensitivity`: Set how sensitive the mouse movement is.
Feel free to contribute or suggest improvements to make the project even better!
