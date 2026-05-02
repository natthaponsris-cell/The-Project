using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        // ใช้คำสั่งคลิกที่แก้ Error ไปก่อนหน้านี้ (ตัวอย่างนี้ใช้ระบบใหม่)
        if (UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                // 1. สั่งให้เป้าขยับไปจุดที่คลิก (อันนี้ทำได้แล้ว)
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                Debug.Log("hit " + hit.collider.name);

                // 2. สั่งยิงกระสุนออกมา (เพิ่มส่วนนี้เข้าไปครับ!)
                FireProjectile();
            }
        }
    }

    // สร้างฟังก์ชันแยกออกมาเพื่อให้โค้ดไม่อ่านยาก
    void FireProjectile()
    {
        // สร้างลูกกระสุนจาก Prefab ที่ตำแหน่งปากกระบอก (shootPoint)
        Rigidbody2D shootBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        // คำนวณความเร็วที่ต้องใช้ (ใช้เวลาเดินทาง 1 วินาที)
        Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, target.transform.position, 1.0f);

        Destroy(shootBullet.gameObject, 5.0f);

        // ใส่แรงให้กระสุนวิ่งออกไป
        shootBullet.linearVelocity = projectileVelocity;
    }

    // ฟังก์ชันคำนวณที่คัดลอกจากรูปที่แล้ว
    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
        return new Vector2(velocityX, velocityY);
    }
}
