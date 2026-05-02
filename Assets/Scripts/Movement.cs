using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb2d;

    float move;
    [SerializeField] int Playerhealth = 100;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] private float cooldownDuration = 2f;
    private float nextReadyTime;
    public GameObject gameOverScreen;
    private bool isGameOver = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
            nextReadyTime = Time.time + cooldownDuration;
        }
        if (Playerhealth <= 0)
        {
            Lose();
        }
    }
    void Lose()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
        gameOverScreen.SetActive(true);
    }
}