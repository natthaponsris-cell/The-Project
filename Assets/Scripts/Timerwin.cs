using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Timerwin : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public GameObject btmenu;
    public GameObject winsc;

    public float elapsedTime = 1800;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btmenu.SetActive(false);
        winsc.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime -= Time.deltaTime;

        // 2. คำนวณนาทีและวินาที
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // 3. แสดงผลในรูปแบบ 00:00
        // {0:00} หมายถึงตัวแปรลำดับที่ 0 ให้แสดงเลข 2 หลักเสมอ (เติมเลข 0 ข้างหน้าถ้าไม่ถึง)
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (elapsedTime < 0)
        {
            Time.timeScale = 0f;
            btmenu.SetActive(true);
            winsc?.SetActive(true);
        }

    }
}
