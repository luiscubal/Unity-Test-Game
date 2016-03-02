using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal") * Speed;
        var moveVertical = Input.GetAxis("Vertical") * Speed;

        var right = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized;
        var forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;

        body.AddForce(forward * moveVertical + right * moveHorizontal);
    }
}
