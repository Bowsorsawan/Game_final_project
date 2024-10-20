using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ǩ�ͺ��� GameObject ��誹������ "Player"
        if (collision.CompareTag("PlayerStats"))
        {
            Debug.Log("Player hit by spikes");

            // �֧����๹�� PlayerStats �ҡ GameObject ��誹
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();

            // ��Ǩ�ͺ����� PlayerStats �����ԧ ��͹�������¡�ѧ��ѹ TakeDamage
            if (playerStats == null)
            {
                Debug.LogError("PlayerStats component not found on the player. Check if the Player GameObject has PlayerStats attached.");
                return; // �͡�ҡ�ѧ��ѹ�������� PlayerStats
            }

            // ���¡��ѧ��ѹ TakeDamage
            playerStats.TakeDamage(damage);
        }
    }
}
