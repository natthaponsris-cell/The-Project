using UnityEngine;

public class Hppotion : MonoBehaviour
{

    [SerializeField] int heal = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Movement>().Playerhealth += heal;
            Destroy(gameObject);
        }
    }
}
