using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLayer1 : MonoBehaviour
{
    public ThanhMau thanhmau;
    public float mauhientai;
    public float mautoida;
    [SerializeField]
    private AudioClip hit;
    [SerializeField]
    private AudioSource source;
    public Rigidbody2D Play;
    public float move = 4f;
    public float ngang, doc;
    public Animator ani2;
    [SerializeField]
    private GameObject hit_ringht, hit_up, hit_dow;
    private bool is_attack;
    private float timer;
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public ThanhMau thanhMauUI;
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            // Xử lý khi chết
            Destroy(gameObject); // Hoặc chuyển Scene
        }

        // Cập nhật UI
        if (thanhMauUI != null)
        {
            thanhMauUI.Capnhatthanhmau(currentHealth, maxHealth);
        }
    }
    public static void Loadsin()
    {
        SceneManager.LoadScene("Stage 2");
    }
    public static void Loadsin1()
    {
        SceneManager.LoadScene("Stage 3");
    }
    public static void Loadsin2()
    {
        SceneManager.LoadScene("Los");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Loadsin();
        }
        if (collision.gameObject.CompareTag("Box1"))
        {
            Loadsin1();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enermy"))
        {
            mauhientai -= 10;
            thanhmau.Capnhatthanhmau(mauhientai, mautoida);
            if (mauhientai <= 0)
            {
                GameData.LastDeathPosition = transform.position;
                GameData.LastScene = SceneManager.GetActiveScene().name;
                // Chuyển sang scene thua
                SceneManager.LoadScene("Los");

            }
        }
    }



    void Start()
    {
        
        

        mauhientai = mautoida;
        GetComponent<Rigidbody2D>();
        thanhmau.Capnhatthanhmau(mauhientai, mautoida);
        }

        // Update is called once per frame
        void Update()
        {
           
           
            ngang = Input.GetAxisRaw("Horizontal");
            doc = Input.GetAxisRaw("Vertical");
            Play.velocity = new Vector2(ngang * move, doc * move);

            if (Input.GetAxisRaw("Horizontal") > 0)
            {

                ani2.SetBool("chayad", true);
                transform.localScale = new Vector3(5, 5, 5);

                if (Input.GetMouseButtonDown(0))
                {
                    is_attack = true;
                    source.PlayOneShot(hit);
                    ani2.SetTrigger("danhad");
                    hit_ringht.SetActive(is_attack);

                }
                timer = 0;
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                ani2.SetBool("chayad", true);

                transform.localScale = new Vector3(-5, 5, 5);
                if (Input.GetMouseButtonDown(0))
                {
                    is_attack = true;
                    source.PlayOneShot(hit);
                    ani2.SetTrigger("danhad");
                    hit_ringht.SetActive(is_attack);

                }
                timer = 0;
            }
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                ani2.SetBool("chayad", false);

            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                ani2.SetBool("chayw", true);

                ani2.SetBool("chays", false);
                if (Input.GetMouseButtonDown(0))
                {
                    is_attack = true;
                    source.PlayOneShot(hit);
                    ani2.SetTrigger("danhw");
                    hit_up.SetActive(is_attack);

                }
                timer = 0;
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                ani2.SetBool("chays", true);

                ani2.SetBool("chayw", false);
                if (Input.GetMouseButtonDown(0))
                {
                    is_attack = true;
                    source.PlayOneShot(hit);
                    ani2.SetTrigger("danhs");
                    hit_dow.SetActive(is_attack);

                }
                timer = 0;
            }
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                ani2.SetBool("chays", false);
                ani2.SetBool("chayw", false);

            }
            if (is_attack)
            {
                timer += Time.deltaTime;
                if (timer > 0.2f)
                {
                    is_attack = false;
                    hit_ringht.SetActive(is_attack);
                    hit_up.SetActive(is_attack);
                    hit_dow.SetActive(is_attack);
                }
            }

        }
    
}

