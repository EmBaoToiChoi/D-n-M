using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quai2 : MonoBehaviour
{
    public Transform enermy, player;
    private bool isRight;
    [SerializeField]

    bool isChasing = false;
    private float speed = 2f, PVipHien = 30f;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float khoangCachPlayer = Vector2.Distance(enermy.position, player.position);
        if (khoangCachPlayer < PVipHien)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
        if (isChasing)
        {
            dichuyentoiPlayer(player.position);
        }
    }
    void dichuyentoiPlayer(Vector3 target)
    {
        Vector3 direction = (target - enermy.position).normalized;
        enermy.Translate(direction * speed * Time.deltaTime);

        // Lật quái
        if (direction.x > 0)
            enermy.localScale = new Vector3(10, 10, 10);
        if (direction.x < 0)
            enermy.localScale = new Vector3(-10, 10, 10);
    }
        void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Playerban"))
    {
        Destroy(gameObject); // Hủy quái vật
        Destroy(other.gameObject); // Hủy viên đạn
    }
}

    
}