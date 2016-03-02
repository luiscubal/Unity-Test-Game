using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject Player;
    public float CameraRotationSpeed = 3;

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

        var horizontalCameraAxis = Input.GetAxis("Camera Horizontal") * CameraRotationSpeed;

        var rotationCenter = playerPosition + new Vector3(0, offset.y, 0);

        transform.RotateAround(rotationCenter, Vector3.up, horizontalCameraAxis);

        UpdateOffset();
    }
        
	void LateUpdate()
    {
        var playerPosition = Player.transform.position;

        transform.position = playerPosition + offset;
	}
}
