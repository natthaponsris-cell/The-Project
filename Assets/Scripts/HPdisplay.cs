using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPdisplay : MonoBehaviour
{
    public Movement movement;
    public Image hpImage;
    public GameObject deathScreen;
    public GameObject restartb;

    public Sprite hp100;
    public Sprite hp60;
    public Sprite hp20;
    public Sprite emptyHP;

    private void Start()
    {
        //deathScreen.SetActive(false);
        //restartb.SetActive(false);
    }

    void Update()
    {
        int hp = movement.Playerhealth;

        if (hp >= 100)
        {
            hpImage.sprite = hp100;
        }
        else if (hp >= 60)
        {
            hpImage.sprite = hp60;
        }
        else if (hp >= 20)
        {
            hpImage.sprite = hp20;
        }
        else
        {
            hpImage.sprite = emptyHP;
            deathScreen.SetActive(true);
            restartb.SetActive(true);
        }
    }
}

