using UnityEngine;

public class Flip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0) spriteRenderer.flipX = false; // Face Right
        else if (move < 0) spriteRenderer.flipX = true; // Face Left
    }
}
