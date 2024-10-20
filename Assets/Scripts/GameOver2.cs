using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // สำหรับการจัดการ Scene

public class GameOverMenu2 : MonoBehaviour
{
    public GameObject gameOverUI; // อ้างอิง UI ของ Game Over

    // ฟังก์ชันที่จะแสดง UI Game Over และหยุดเกม
    public void GameOver()
    {
        gameOverUI.SetActive(true); // แสดง UI Game Over
        Time.timeScale = 0f; // หยุดเวลาในเกม
    }

    // ฟังก์ชัน Restart เพื่อเริ่มเกมใหม่
    public void Restart()
    {
        Time.timeScale = 1f; // ทำให้เกมกลับมาทำงานตามปกติ

        Debug.Log("Restart() called.");

        PlayerStats playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.ResetScore();
            Debug.Log("ResetScore() called successfully.");
        }
        else
        {
            Debug.LogError("PlayerStats not found!");
        }

        SceneManager.LoadScene("Scene 1"); // โหลดซีนที่ชื่อ "Scene 1"
    }

}
