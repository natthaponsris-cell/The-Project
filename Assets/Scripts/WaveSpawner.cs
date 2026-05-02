using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float spawnRate = 10.0f;
    public float timeBetweenWaves = 20.0f;
    public int enemyCount = 1; // กำหนดค่าเริ่มต้นไว้หน่อยก็ดีครับ
    public GameObject enemy;

    bool waveIsDone = true;

    void Update()
    {
        // ตรวจสอบว่า Wave เก่าจบหรือยัง และต้องมั่นใจว่าไม่ได้รันซ้ำซ้อน
        if (waveIsDone)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false; // ล็อคไว้ไม่ให้ Update เรียกซ้ำ

        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }

        // ปรับระดับความยาก
        if (spawnRate > 0.1f) // ป้องกันไม่ให้ค่าติดลบหรือเร็วเกินไป
        {
            spawnRate -= 0.1f;
        }
        enemyCount += 1;

        // รอเวลาพักระหว่าง Wave
        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true; // ปลดล็อคให้เริ่ม Wave ต่อไปได้
    }
}