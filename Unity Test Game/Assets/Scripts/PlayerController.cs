using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3;
    public Text ScoreText;
    public Text WinText;

    private Rigidbody body;
    private int score;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        score = 0;

        UpdateDisplay();
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal") * Speed;
        var moveVertical = Input.GetAxis("Vertical") * Speed;

        var right = Vector3.ProjectOnPlane(Camera.main.transform.right, Vector3.up).normalized;
        var forward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;

        body.AddForce(forward * moveVertical + right * moveHorizontal);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            ++score;
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        ScoreText.text = "Score: " + score;

        if (score >= 3)
        {
            WinText.gameObject.SetActive(true);
        }
    }
}
