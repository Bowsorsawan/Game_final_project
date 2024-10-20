using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับโหลดซีนใหม่

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI; // อ้างอิง UI ของหน้าจอ Game Over

    void Start()
    {
        // ปิด Game Over UI ตอนเริ่มต้น
        gameOverUI.SetActive(false);
    }

    // ฟังก์ชันที่จะแสดง UI Game Over
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // หยุดเวลา
    }

    // ฟังก์ชัน Restart เพื่อเริ่มเกมใหม่
    public void Restart()
    {
        Time.timeScale = 1f; // รีเซ็ตเวลาให้กลับมาเป็นปกติ
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // โหลดซีนใหม่
    }

    // ฟังก์ชัน Quit เพื่อออกจากเกม
    public void Quit()
    {
        // ฟังก์ชันออกจากเกม
        Application.Quit();
    }
}
