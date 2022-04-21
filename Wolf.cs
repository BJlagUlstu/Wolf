using UnityEngine;
using UnityEngine.UI;

public class Wolf : MonoBehaviour
{
    public float speed = 50;
    private int counter = 0;

    public Object bottle;
    public Text text;
    public Generator generator;

    public Rigidbody rigidBody;
    public float rotationSpeed = 1;

    [SerializeField, Range(0.01f, 10f)]
    float velocityStop = 0.5f;
    float maxVelocity = 0f;

    void Start()
    {
        maxVelocity = 1f * speed;
        text.text = $"{counter++} bottles collected";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bottle>())
        {
            Destroy(collision.gameObject);
            text.text = $"{counter++} bottles collected";
            generator.AddBottle();
        }     
    }

    private void FixedUpdate()
    {
        Move();
        Rotation();
    }

    private void Move()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            Vector3 force = -transform.right * speed * Mathf.Sign(Input.GetAxis("Vertical"));
            rigidBody.AddForce(force, ForceMode.Force);
        }
        else
        {
            rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Vector3.zero, velocityStop);
        }
        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocity);
    }

    private void Rotation()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Input.GetAxis("Horizontal")));
        }
    }
}