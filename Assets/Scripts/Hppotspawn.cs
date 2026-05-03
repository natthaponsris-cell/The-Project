using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hppotspawn : MonoBehaviour
{
    public float spawnRate = 10.0f;
    public float timeBetweenWaves = 30.0f;
    public int pot = 1;
    public GameObject hppot;

    bool waveIsDone = true;

    void Update()
    {
        if (waveIsDone)
        {
            StartCoroutine(waveSpawner());
        }
    }

    IEnumerator waveSpawner()
    {
        waveIsDone = false; // ล็อคไว้ไม่ให้ Update เรียกซ้ำ

        for (int i = 0; i < pot; i++)
        {
            Instantiate(hppot, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }

        // ปรับระดับความยาก
        if (spawnRate > 0.1f) // ป้องกันไม่ให้ค่าติดลบหรือเร็วเกินไป
        {
            spawnRate -= 0.1f;
        }
        pot += 0;

        // รอเวลาพักระหว่าง Wave
        yield return new WaitForSeconds(timeBetweenWaves);

        waveIsDone = true; // ปลดล็อคให้เริ่ม Wave ต่อไปได้
    }
}
