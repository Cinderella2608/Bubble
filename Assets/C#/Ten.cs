using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ten : MonoBehaviour
{
    public float speed = 10f;  // Tốc độ bay của mũi tên
    public float destroyTime; // Thời gian sống của mũi tên nếu không trúng mục tiêu

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;  // Ngừng ảnh hưởng của trọng lực lên mũi tên
        rb.velocity = transform.right * speed; // Mũi tên sẽ bay theo hướng của cung
    }
    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu mũi tên va vào quả bóng
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Destroy(collision.gameObject); // Hủy quả bóng
        }
    }
}
