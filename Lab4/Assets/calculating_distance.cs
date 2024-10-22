using UnityEngine;
using TMPro;

public class MeasureDistance : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 finalPosition;

    private bool isHit = false;

    private Rigidbody rb;

    public float stopThreshold = 0.01f;
    public Vector3 testForce = new Vector3(0, 0, 500f);

    private Vector3 initialVelocity;
    private Vector3 finalVelocity;

    public float drag = 0.5f;
    public float angularDrag = 0.5f;

    public TextMeshProUGUI scoreText;
    public Transform vrCamera;

    private bool hasScored = false;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;
        rb.angularDrag = angularDrag;

        if (scoreText == null)
        {
            Debug.LogError("scoreText is not set in the Inspector. Please assign a TextMeshProUGUI object.");
        }

        if (vrCamera == null)
        {
            Debug.LogError("vrCamera is not set in the Inspector. Please assign the VR Camera object.");
        }

        if (scoreText != null)
        {
            scoreText.text = "Loveste mingea!";
        }
    }

    void Update()
    {
        if (isHit)
        {
            if (rb.velocity.magnitude < stopThreshold)
            {
                finalPosition = transform.position;
                finalVelocity = rb.velocity;
                CalculateDistance();
                isHit = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Hit(testForce);
        }

        if (scoreText != null && vrCamera != null)
        {
            Vector3 newPosition = vrCamera.position + vrCamera.forward * 2.0f;
            scoreText.transform.position = newPosition;
            scoreText.transform.LookAt(vrCamera);
            scoreText.transform.Rotate(0, 180, 0);
        }
    }

    public void Hit(Vector3 force)
    {
        isHit = true;
        rb.AddForce(force);
        initialVelocity = rb.velocity;
    }

    private void CalculateDistance()
    {
        float distance = Vector3.Distance(initialPosition, finalPosition);

        Debug.Log(distance);

        string score = CalculateScore(distance);


        if ( !hasScored) 
        {
            scoreText.text = score.ToString();
            hasScored = true;
        }
    }

    private string CalculateScore(float distance)
    {
        int score;

        string result;
        string text;

        if (distance < 7)
        {
            score = Mathf.RoundToInt(distance) * 5;
            text = "Lovitura de viteza mica:<";
        }
        else if (distance < 20)
        {
            score = Mathf.RoundToInt(distance) * 15;
            text = "Lovitura de viteza medie";
        }
        else
        {
            score = Mathf.RoundToInt(distance) * 50;
            text = "Lovitura de viteza mare:>";
        }

        result = "Scor: " + score.ToString() + "-" + text;

        return result;
    }
}
