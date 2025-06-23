 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float Move = 25f;
    [SerializeField] private float timeDestroy = 0.1f;


    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        transform.Translate(Move * Time.deltaTime * Vector2.right);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Nếu chạm Boss hoặc Enemy, hủy đạn
        if ( other.CompareTag("enermy"))
        {
            Destroy(gameObject);
        }
    }
    
}
