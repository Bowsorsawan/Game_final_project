using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    private void Awake()
    {
        // ����� instance �ͧ ScoreManager �����������������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ����� GameObject ������١ź���������¹ Scene
        }
        else
        {
            Destroy(gameObject);  // �ҡ�� instance �������� ���ź������������
        }
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }
}
