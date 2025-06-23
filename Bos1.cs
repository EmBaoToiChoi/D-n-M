using System.Collections;
using UnityEngine;

public class Bos1 : MonoBehaviour
{
    public ThanhMau2 thanhMauUI;
    public float currentHealth;
    public float maxHealth = 100f;

    public Transform enermy, player;
    [SerializeField] public Animator ani6;

    private float speed = 2f, PVipHien = 20f;

    private bool isChasing = false;
    private bool isAttacking = false;

    private float damageCooldown = 1f;
    private float damageTimer = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
{
    if (isAttacking)
    {
        ani6.SetBool("Run", false);
        return;
    }

    // ✅ Nên kiểm tra ngay đầu Update
    if (player == null || enermy == null)
        return;

    float distanceToPlayer = Vector2.Distance(enermy.position, player.position);
    isChasing = distanceToPlayer < PVipHien;

    if (isChasing)
    {
        MoveToPlayer(player.position);
        ani6.SetBool("Run", true);
    }
    else
    {
        ani6.SetBool("Run", false);
    }
}

    void MoveToPlayer(Vector3 target)
    {
        Vector3 direction = (target - enermy.position).normalized;
        enermy.Translate(direction * speed * Time.deltaTime);

        if (direction.x > 0)
            enermy.localScale = new Vector3(5, 5, 5);
        else if (direction.x < 0)
            enermy.localScale = new Vector3(-5, 5, 5);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boxtet"))
        {
            isAttacking = true;
            ani6.SetBool("Danh", true);
        }

        if (other.CompareTag("Hit"))
        {
            TakeDamage(1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Boxtet"))
        {
            isAttacking = false;
            ani6.SetBool("Danh", false);
            damageTimer = 0f;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Boxtet") && isAttacking)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageCooldown)
            {
                // Trừ máu player
                PLayer1 player = other.GetComponentInParent<PLayer1>();
                if (player != null)
                {
                    player.TakeDamage(10);
                }

                // Trừ máu Boss
                TakeDamage(1);

                damageTimer = 0f; // reset
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (thanhMauUI != null)
        {
            thanhMauUI.CapnhatThanhmau(currentHealth, maxHealth);
        }
    }
}

