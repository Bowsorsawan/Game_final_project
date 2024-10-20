using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string nextSceneName;  // กำหนดชื่อ Scene ถัดไปใน Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(nextSceneName);  // ใช้ชื่อ Scene ที่กำหนดเอง
    }
}
