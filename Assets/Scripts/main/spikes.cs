using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่า GameObject ที่ชนมีแท็กเป็น "Player"
        if (collision.CompareTag("PlayerStats"))
        {
            Debug.Log("Player hit by spikes");

            // ดึงคอมโพเนนต์ PlayerStats จาก GameObject ที่ชน
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();

            // ตรวจสอบว่ามี PlayerStats อยู่จริง ก่อนที่จะเรียกฟังก์ชัน TakeDamage
            if (playerStats == null)
            {
                Debug.LogError("PlayerStats component not found on the player. Check if the Player GameObject has PlayerStats attached.");
                return; // ออกจากฟังก์ชันถ้าไม่มี PlayerStats
            }

            // เรียกใช้ฟังก์ชัน TakeDamage
            playerStats.TakeDamage(damage);
        }
    }
}
