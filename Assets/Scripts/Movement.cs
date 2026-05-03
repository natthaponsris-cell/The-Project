using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;

    float move;
    [SerializeField] public int Playerhealth = 100;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] private float jumpcooldown = 1.5f;
    private float nextReadyTime;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && Time.time >= nextReadyTime)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump!");
            nextReadyTime = Time.time + jumpcooldown;
        }

        if (Playerhealth > 100)
        {
            Playerhealth = 100;
        }
        if (Playerhealth <= 0)
        {
            Time.timeScale = 0f;
        }
    }
}