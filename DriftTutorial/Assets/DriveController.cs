using UnityEngine;

public class DriveController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float moveForce = 10.0f, turnSpeed = 2.0f, traction = 0.1f;
    [SerializeField] private const float drag = 0.981f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //read input
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        //Set velocity vector
        if (v != 0)
        {
            velocity = v * moveForce * transform.forward;
            velocity *= drag;
        }

        float angle = (h * v * turnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, angle);


        //apply Vector
        transform.position += velocity * Time.deltaTime;

        //visualise vectors
        Debug.DrawRay(transform.position, transform.forward * 10.0f, Color.red);
        Debug.DrawRay(transform.position, velocity, Color.blue);
        Debug.DrawRay(transform.position, transform.right * 5.0f, Color.yellow);
    }

    private void OnValidate()
    {
        
    }
}
