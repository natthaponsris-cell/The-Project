using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Return2 : MonoBehaviour
{
    public void Restart2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene2");
        
    }
}
