using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerBoss : MonoBehaviour
{

    public ThanhMau2 thanhMauUI;
    public float currentHealth;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float moveSpeed = 4f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public static void Loadsin2()
    {
        SceneManager.LoadScene("Stage 2,1");
    }
    public static void Loadsin3()
    {
        SceneManager.LoadScene("Stage 3,1");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box2"))
        {
            Loadsin2();
        }
        if (collision.gameObject.CompareTag("Box3"))
        {
            Loadsin3();
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = input.normalized * moveSpeed;

        if (input.x < 0)
            spriteRenderer.flipX = true;
        else if (input.x > 0)
            spriteRenderer.flipX = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enermy"))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(float amount)
{
    currentHealth -= amount;
    UpdateHealthBar();

    if (currentHealth <= 0)
    {
        GameData.LastDeathPosition = transform.position;
        GameData.LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Los");
    }
}


    void UpdateHealthBar()
    {
        if (thanhMauUI != null)
        {
            thanhMauUI.CapnhatThanhmau(currentHealth, maxHealth);
        }
    }
    
}
