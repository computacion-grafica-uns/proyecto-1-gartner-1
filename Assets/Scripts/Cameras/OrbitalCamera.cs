using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    [Header("Centro de órbita")]
    public Vector3 target = Vector3.zero;

    [Header("Estado orbital")]
    public float distance = 20f;
    public float yaw = 0f;
    public float pitch = 20f;

    [Header("Velocidades")]
    public float keyboardSpeed = 100f;
    public float mouseSpeed = 3f;
    public float zoomSpeed = 5f;

    [Header("Límites")]
    public float minPitch = -80f;
    public float maxPitch = 80f;
    public float minDistance = 1f;
    public float maxDistance = 20f;

    public void HandleRotation()
    {
        float yawInput = 0f;
        float pitchInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow)) yawInput -= 1f;
        if (Input.GetKey(KeyCode.RightArrow)) yawInput += 1f;
        if (Input.GetKey(KeyCode.UpArrow)) pitchInput += 1f;
        if (Input.GetKey(KeyCode.DownArrow)) pitchInput -= 1f;

        yaw += yawInput * keyboardSpeed * Time.deltaTime;
        pitch += pitchInput * keyboardSpeed * Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yaw += mouseX * mouseSpeed;
            pitch -= mouseY * mouseSpeed;
        }

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
    }

    public void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.0001f)
        {
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }
    }

    public Matrix4x4 GetViewMatrix()
    {
        float yawRad = yaw * Mathf.Deg2Rad;
        float pitchRad = pitch * Mathf.Deg2Rad;

        Vector3 position = new Vector3(
            target.x + distance * Mathf.Cos(pitchRad) * Mathf.Sin(yawRad),
            target.y + distance * Mathf.Sin(pitchRad),
            target.z - distance * Mathf.Cos(pitchRad) * Mathf.Cos(yawRad)
        );

        return ViewMatrix.CreateViewMatrix(
            position,
            target,
            Vector3.up
        );
    }
}