using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    private void Awake()
    {
        // เช็คว่า instance ของ ScoreManager มีอยู่แล้วหรือไม่
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ทำให้ GameObject นี้ไม่ถูกลบเมื่อเปลี่ยน Scene
        }
        else
        {
            Destroy(gameObject);  // หากมี instance อยู่แล้ว ให้ลบตัวใหม่นี้ทิ้งไป
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
