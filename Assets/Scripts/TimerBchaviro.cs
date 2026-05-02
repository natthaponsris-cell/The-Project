using UnityEngine;
using TMPro;

public class TimerBchaviro : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime = 120;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
    }
}
