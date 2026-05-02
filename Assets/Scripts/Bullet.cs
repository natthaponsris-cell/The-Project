using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 50;


    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<enemyPatrol>().Enemyhealth -= damage;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
