using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player1, player2;

    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.08f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        player1 = player1.GetChild(0).gameObject.transform;
        player2 = player2.GetChild(0).gameObject.transform;
    }
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
        }

        UpdatePosition();

    }

    private void UpdatePosition()
    {
        float distance = Mathf.Abs(player1.position.x - player2.position.x);

        if (player1.position.x < player2.position.x)
        {
            this.transform.position = new Vector3(player1.position.x + distance / 2, this.transform.position.y, this.transform.position.z);

        }
        else if (player1.position.x > player2.position.x)
        {
            this.transform.position = new Vector3(player2.position.x + distance / 2, this.transform.position.y, this.transform.position.z);

        }

    }

    public void TriggerShake()
    {
        shakeDuration = 0.08f;
    }
}
