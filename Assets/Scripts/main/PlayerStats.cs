using System.Collections;
using UnityEngine;
using UnityEngine.UI; // นำเข้า Slider และจัดการ UI
using UnityEngine.SceneManagement; // สำหรับการจัดการ Scene (เช่น Restart)

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 50f;
    public float health;
    public Slider healthBar;  // อ้างอิงไปยัง Slider ของ Health Bar
    private int score;

    private Animator animator;
    private bool canTakeDamage = true;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        health = maxHealth;
        score = 0; // เริ่มต้นคะแนนที่ 0

        // ตั้งค่า Health Bar ให้แสดงผลสุขภาพเต็มตั้งแต่เริ่มต้น
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }

    public void TakeDamage(float damage)
    {
        if (!canTakeDamage) { return; }

        health -= damage;
        animator.SetBool("Damage", true);

        // อัปเดต Health Bar หลังจากได้รับความเสียหาย
        UpdateHealthBar();

        Debug.Log("Player health " + health);
        if (health <= 0)
        {
            GetComponentInParent<GatherInput>().DisableControls();
            Debug.Log("Player is dead");

            // เรียกฟังก์ชัน GameOver เพื่อเปลี่ยนไป Scene "Game Over"
            GameOver();
        }

        StartCoroutine(DamagePrevention());
    }

    private void UpdateHealthBar()
    {
        // อัปเดตค่า health ใน Health Bar
        healthBar.value = health;
    }

    private IEnumerator DamagePrevention()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(0.15f);

        if (health > 0)
        {
            canTakeDamage = true;
            animator.SetBool("Damage", false); // ไปยังแอนิเมชัน idle
        }
        else
        {
            animator.SetBool("Death", true); // ไปยังแอนิเมชันตาย
        }
    }

    private void GameOver()
    {
        // โหลด Scene "Game Over" เมื่อผู้เล่นตาย
        SceneManager.LoadScene("Game Over");
    }
    public void ResetScore()
    {
        // สมมุติว่าคุณมีตัวแปรคะแนนใน PlayerStats
        score = 0; // รีเซ็ตคะแนนเป็น 0
        Debug.Log("Score reset to 0.");
    }

}
