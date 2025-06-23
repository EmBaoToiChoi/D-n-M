using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BosNeCon : MonoBehaviour
{
    public ThanhMau2 thanhMauUI;
    public float currentHealth;
    public float maxHealth = 100f;
    PlayerBoss playerInRange;
    Coroutine attackCoroutine;
    public Transform enermy, player;
    [SerializeField] public Animator ani6;

    bool isChasing = false;
    bool isAttacking = false;
    bool hasDealtDamage = false; // Ngăn đánh liên tục

    private float speed = 2f, PVipHien = 20f;
    public static void Loadsin()
    {
        SceneManager.LoadScene("Win");
    }
    void Update()
    {
        if (isAttacking)
        {
            ani6.SetBool("Run", false);
            return;
        }

        float khoangCachPlayer = Vector2.Distance(enermy.position, player.position);
        isChasing = khoangCachPlayer < PVipHien;

        if (isChasing)
        {
            dichuyentoiPlayer(player.position);
            ani6.SetBool("Run", true);
        }
        else
        {
            ani6.SetBool("Run", false);
        }
    }

    void dichuyentoiPlayer(Vector3 target)
    {
        Vector3 direction = (target - enermy.position).normalized;
        enermy.Translate(direction * speed * Time.deltaTime);

        if (direction.x > 0)
            enermy.localScale = new Vector3(5, 5, 5);
        if (direction.x < 0)
            enermy.localScale = new Vector3(-5, 5, 5);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boxtet"))
        {
            isAttacking = true;
            ani6.SetBool("Danh", true);

            playerInRange = other.GetComponentInParent<PlayerBoss>();
            if (playerInRange != null && attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackPlayerRepeatedly());
            }
        }

        // 👉 Boss bị trúng đạn hoặc súng
        if (other.CompareTag("Playerban"))
        {
            TakeDamage(1); // Boss mất 1 máu
        }
    }
    public void TakeDamage(float amount)
{
    currentHealth -= amount;

    if (currentHealth <= 0)
    {
        // Gọi scene "Win" trước khi huỷ Boss
        Loadsin();
        Destroy(gameObject);
    }

    // Cập nhật thanh máu UI nếu có
    if (thanhMauUI != null)
    {
        thanhMauUI.CapnhatThanhmau(currentHealth, maxHealth); // maxHealth là biến đã có
    }
}

    IEnumerator AttackPlayerRepeatedly()
    {
        while (true)
        {
            if (playerInRange != null)
            {
                playerInRange.TakeDamage(10);
            }
            yield return new WaitForSeconds(0.5f); // Mỗi 1 giây trừ 10 máu
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (isAttacking && !hasDealtDamage && other.CompareTag("Boxtet"))
        {
            PlayerBoss player = other.GetComponentInParent<PlayerBoss>(); // lấy script từ cha của collider
            if (player != null)
            {
                player.TakeDamage(10); // Gọi trừ máu
                hasDealtDamage = true;
                StartCoroutine(ResetDamageCooldown()); // delay để đánh lại
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boxtet"))
        {
            isAttacking = false;
            ani6.SetBool("Danh", false);

            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
            playerInRange = null;
        }
    }

    IEnumerator ResetDamageCooldown()
    {
        yield return new WaitForSeconds(1f); // Thời gian delay giữa 2 lần đánh
        hasDealtDamage = false;
    }
    void Start()
{
    currentHealth = maxHealth; // 👈 Gán máu ban đầu = 100
}
}
