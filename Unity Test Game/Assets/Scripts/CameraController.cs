using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject Player;
    public float CameraRotationSpeed = 3;
    public float CameraVerticalSpeed = 30;

    public float MinVerticalAngle = 20;
    public float MaxVerticalAngle = 80;

    Vector3 offset;

    void Start()
    {
        UpdateOffset();
    }

    void UpdateOffset()
    {
        offset = transform.position - Player.transform.position;
    }

    void FixedUpdate()
    {
        var playerPosition = Player.transform.position;

        var verticalCameraAxis = Input.GetAxis("Camera Vertical") * CameraVerticalSpeed;
        var horizontalCameraAxis = Input.GetAxis("Camera Horizontal") * CameraRotationSpeed;

        // Horizontal Rotation
        var horizontalRotationCenter = playerPosition + new Vector3(0, offset.y, 0);
        transform.RotateAround(horizontalRotationCenter, Vector3.up, horizontalCameraAxis);

        // Vertical Rotation
        var verticalRotationCenter = Player.transform.position;
        var angle = transform.localEulerAngles.x;
        var targetAngle = angle + verticalCameraAxis;
        targetAngle = Mathf.Max(targetAngle, MinVerticalAngle);
        targetAngle = Mathf.Min(targetAngle, MaxVerticalAngle);
        var diffAngle = targetAngle - angle;
        diffAngle *= Mathf.Deg2Rad;
        transform.RotateAround(verticalRotationCenter, transform.right, diffAngle);

        UpdateOffset();
    }

    void LateUpdate()
    {
        var playerPosition = Player.transform.position;

        transform.position = playerPosition + offset;
    }
}
