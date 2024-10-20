using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ����Ѻ��èѴ��� Scene

public class GameOverMenu2 : MonoBehaviour
{
    public GameObject gameOverUI; // ��ҧ�ԧ UI �ͧ Game Over

    // �ѧ��ѹ�����ʴ� UI Game Over �����ش��
    public void GameOver()
    {
        gameOverUI.SetActive(true); // �ʴ� UI Game Over
        Time.timeScale = 0f; // ��ش�������
    }

    // �ѧ��ѹ Restart ���������������
    public void Restart()
    {
        Time.timeScale = 1f; // ���������Ѻ�ҷӧҹ�������

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

        SceneManager.LoadScene("Scene 1"); // ��Ŵ�չ������ "Scene 1"
    }

}
