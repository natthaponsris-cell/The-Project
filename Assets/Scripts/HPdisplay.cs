using TMPro;
using UnityEngine;

public class HPdisplay : MonoBehaviour
{

    [SerializeField] public TMP_Text HPText;

    public Movement Movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = "Player HP : " + Movement.Playerhealth.ToString();
    }
}
