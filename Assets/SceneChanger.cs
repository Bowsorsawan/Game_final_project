using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Transform player;            // ตัวละครผู้เล่น
    public Transform targetPoint;       // จุดที่ผู้เล่นต้องเดินไปถึง
    public float proximity = 1.0f;      // ระยะที่ถือว่าใกล้พอที่จะเปลี่ยนฉาก
    public string nextSceneName;        // ชื่อของ Scene ถัดไปที่ต้องการโหลด

    void Update()
    {
        // คำนวณระยะห่างระหว่างผู้เล่นกับจุดเปลี่ยนฉาก
        float distance = Vector2.Distance(player.position, targetPoint.position);

        // ถ้าผู้เล่นอยู่ในระยะใกล้พอกับจุดเปลี่ยนฉาก
        if (distance <= proximity)
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        // โหลด Scene ตามชื่อที่กำหนดใน Inspector
        SceneManager.LoadScene(nextSceneName);
    }
}
