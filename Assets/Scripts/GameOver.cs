using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // ����Ѻ��Ŵ�չ����

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI; // ��ҧ�ԧ UI �ͧ˹�Ҩ� Game Over

    void Start()
    {
        // �Դ Game Over UI �͹�������
        gameOverUI.SetActive(false);
    }

    // �ѧ��ѹ�����ʴ� UI Game Over
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // ��ش����
    }

    // �ѧ��ѹ Restart ���������������
    public void Restart()
    {
        Time.timeScale = 1f; // ������������Ѻ���繻���
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ��Ŵ�չ����
    }

    // �ѧ��ѹ Quit �����͡�ҡ��
    public void Quit()
    {
        // �ѧ��ѹ�͡�ҡ��
        Application.Quit();
    }
}
