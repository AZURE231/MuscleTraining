using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    public float speed = 1.0f; // How fast it shakes
    public float amount = 1.0f; // How much it shakes
    public float shakeDuration = 2.0f; // How long it shakes (in seconds)

    private float shakeTimer = 0.0f;
    private Vector3 originalLocalPosition;

    void Start()
    {
        originalLocalPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            transform.localPosition = originalLocalPosition + new Vector3(Mathf.Sin(Time.time * speed) * amount, 0, 0);
        }
        else
        {
            transform.localPosition = originalLocalPosition; // Reset to original local position when done shaking
        }
    }

    public void StartShaking()
    {
        shakeTimer = shakeDuration; // Set the shake timer to the shake duration
    }
}
