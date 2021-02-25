using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    public float minSpeed = 4f;
    public float maxSpeed = 12f;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed) + CarSpeedChanger.speedChangeValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }
}
