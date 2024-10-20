using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject heartPrefab;    // ชื่อ heart เปลี่ยนเป็น heartPrefab เพื่อให้ชัดเจน
    public List<Image> hearts = new List<Image>();

    private PlayerStats playerStats;

    void Start()
    {
        // หา PlayerStats
        playerStats = GameObject.FindObjectOfType<PlayerStats>();

        if (playerStats == null)
        {
            Debug.LogError("PlayerStats not found!");
            return;
        }

        Debug.Log("PlayerStats found with maxHealth: " + playerStats.maxHealth);

        // ตรวจสอบว่ามีหัวใจตามจำนวน maxHealth หรือไม่
        for (int i = 0; i < playerStats.maxHealth; i++)
        {
            GameObject h = Instantiate(heartPrefab, this.transform);
            hearts.Add(h.GetComponent<Image>());
        }

        // ตรวจสอบว่ามีหัวใจในลิสต์หรือไม่
        if (hearts.Count > 0)
        {
            Debug.Log("Hearts have been added to the UI");
        }
        else
        {
            Debug.LogError("No hearts were added to the UI");
        }

        // เรียก UpdateHearts เพื่อแสดงผลหัวใจ
        UpdateHearts();
    }

    void UpdateHearts()
    {
        // ตรวจสอบ playerStats ก่อนทำงาน
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats is null in UpdateHearts.");
            return;
        }

        int heartFill = (int)playerStats.health;

        // ตรวจสอบจำนวนหัวใจในลิสต์ hearts ก่อนทำงาน
        if (hearts == null || hearts.Count == 0)
        {
            Debug.LogError("No hearts found in the UI.");
            return;
        }

        // ปรับปรุงสถานะของหัวใจ
        foreach (Image heart in hearts)
        {
            if (heartFill > 0)
            {
                heart.fillAmount = 1; // หัวใจเต็ม
                heartFill -= 1;
            }
            else
            {
                heart.fillAmount = 0; // หัวใจว่าง
            }
        }
    }
}
