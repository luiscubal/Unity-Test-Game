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
        var moveVertical = Input.GetAxis("Vertical") * Speed;

        body.AddForce(Camera.main.transform.forward * moveVertical);
    }
}
