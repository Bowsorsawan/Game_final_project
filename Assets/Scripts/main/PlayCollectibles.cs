using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayCollectibles : MonoBehaviour
{
    public Text textComponent;
    // ตอนนี้เราจะไม่ใช้ตัวแปร gemNumber แยกกัน แต่จะใช้ ScoreManager
    // public int gemNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        textComponent.text = ScoreManager.instance.GetScore().ToString();
    }

    public void GemCollected()
    {
        ScoreManager.instance.AddScore(1);  // เพิ่มคะแนนไปที่ ScoreManager
        UpdateText();
    }
}
