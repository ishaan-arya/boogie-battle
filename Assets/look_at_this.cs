using UnityEngine;

public class look_at_this : MonoBehaviour
{
    private Light _discoLight; 
    [SerializeField] private float changeInterval = 0.5f;
    
    // Rotation parameters
    [SerializeField] private float rotationAmplitude = 15f; // Degrees
    [SerializeField] private float rotationFrequency = 0.5f; // Oscillations per second

    // Movement parameters
    [SerializeField] private float moveAmplitude = 0.5f; // Units
    [SerializeField] private float moveFrequency = 0.5f; // Oscillations per second

    private Vector3 initialPosition;
    private Vector3 initialRotation;

    void Start()
    {
        _discoLight = GetComponent<Light>();
        if (_discoLight == null)
        {
            Debug.LogError("No Light component found on this GameObject.");
            return;
        }
        initialPosition = transform.position;
        initialRotation = transform.eulerAngles;
        InvokeRepeating("ChangeLightColor", 0, changeInterval);
    }

    void Update()
    {
        ApplyOscillations();
    }

    void ChangeLightColor()
    {
        var randomColor = new Color(Random.value, Random.value, Random.value);
        _discoLight.color = randomColor;
    }

    void ApplyOscillations()
    {
        // Calculate oscillating rotation
        float rotZ = Mathf.Sin(Time.time * rotationFrequency * 2 * Mathf.PI) * rotationAmplitude;
        Quaternion targetRotation = Quaternion.Euler(initialRotation.x, initialRotation.y, initialRotation.z + rotZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationFrequency);

        // Calculate oscillating movement
        float moveX = Mathf.Sin(Time.time * moveFrequency * 2 * Mathf.PI) * moveAmplitude;
        float moveZ = Mathf.Cos(Time.time * moveFrequency * 2 * Mathf.PI) * moveAmplitude;
        Vector3 targetPosition = initialPosition + new Vector3(moveX, 0, moveZ);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveFrequency);
    }
}
