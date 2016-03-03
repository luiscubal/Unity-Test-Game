using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public float RotationSpeed = 1;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * RotationSpeed * Time.deltaTime);
    }
}
