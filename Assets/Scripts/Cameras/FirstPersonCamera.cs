using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [Header("Camera state")]
    public Vector3 position = new Vector3(0f, 1.8f, -5f);
    public float yaw = 0f;
    public float pitch = 0f;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 9f;
    public float mouseSensitivity = 2f;
    public float keyboardRotationSpeed = 100f;

    [Header("Limits")]
    public float minPitch = -80f;
    public float maxPitch = 80f;

    public Vector3 Forward { get; private set; }
    public Vector3 Right { get; private set; }
    public Vector3 Up { get; private set; }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void HandleRotation()
    {
        float yawInput = 0f;
        float pitchInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) yawInput -= 1f;
        if (Input.GetKey(KeyCode.RightArrow)) yawInput += 1f;
        if (Input.GetKey(KeyCode.UpArrow)) pitchInput += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) pitchInput -= 1f;

        yaw += yawInput * keyboardRotationSpeed * Time.deltaTime;
        pitch += pitchInput * keyboardRotationSpeed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        yaw += mouseX * mouseSensitivity;
        pitch += mouseY * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    public void UpdateCameraVectors()
    {
        float yawRad = yaw * Mathf.Deg2Rad;
        float pitchRad = pitch * Mathf.Deg2Rad;

        Forward = new Vector3(
            Mathf.Sin(yawRad) * Mathf.Cos(pitchRad),
            Mathf.Sin(pitchRad),
            Mathf.Cos(yawRad) * Mathf.Cos(pitchRad)
        ).normalized;

        Right = Vector3.Cross(Vector3.up, Forward).normalized;
        Up = Vector3.Cross(Forward, Right).normalized;
    }

    public void HandleMovement()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        float step = speed * Time.deltaTime;

        Vector3 flatForward = new Vector3(Forward.x, 0f, Forward.z).normalized;
        Vector3 flatRight = new Vector3(Right.x, 0f, Right.z).normalized;

        if (Input.GetKey(KeyCode.W)) position += flatForward * step;
        if (Input.GetKey(KeyCode.S)) position -= flatForward * step;
        if (Input.GetKey(KeyCode.A)) position -= flatRight * step;
        if (Input.GetKey(KeyCode.D)) position += flatRight * step;

        if (Input.GetKey(KeyCode.E)) position += Vector3.up * step;
        if (Input.GetKey(KeyCode.Q)) position -= Vector3.up * step;
    }

    public Matrix4x4 GetViewMatrix()
    {
        return ViewMatrix.CreateViewMatrix(
            position,
            position + Forward,
            Up
        );
    }
}