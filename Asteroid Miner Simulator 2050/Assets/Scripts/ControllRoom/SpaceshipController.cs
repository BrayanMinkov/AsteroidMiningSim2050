using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    public float thrust = 50.0f;
    public float rotateSpeed = 5.0f;
    public float brakePower = 10.0f;
    public float maxVelocity = 50.0f;

    Rigidbody spaceship;

    void Start()
    {
        spaceship = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0)
        {
            spaceship.AddRelativeForce(Vector3.forward * thrust * verticalInput);
        }
        else if (verticalInput < 0)
        {
            spaceship.AddRelativeForce(Vector3.forward * brakePower * verticalInput);
        }
        spaceship.velocity = Vector3.ClampMagnitude(spaceship.velocity, maxVelocity);

        float horizontalInput = Input.GetAxis("Horizontal");
        spaceship.AddRelativeTorque(Vector3.up * rotateSpeed * horizontalInput);
    }
}
