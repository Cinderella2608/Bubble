using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour
{
    public Rigidbody2D rg;
    public Animator Anim;

    private float AtkTime = 0.25f;
    private float AtkCounter = 0.25f;
    private bool IsAtk;

    public float moveSpeed = 5f; // Tốc độ di chuyển của nhân vật
    private float moveDirection;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        rg.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAtk)
        {
            rg.velocity = Vector2.zero;
            AtkCounter -= Time.deltaTime;
            if (AtkCounter <= 0)
            {
                Anim.SetBool("IsAtk", false);
                IsAtk = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AtkCounter = AtkTime;
            Anim.SetBool("IsAtk", true);
            IsAtk = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection = 1f; // Di chuyển lên
            rg.angularVelocity = 0f;
            transform.rotation = Quaternion.identity;
        }

        // Kiểm tra khi nhấn phím S để di chuyển xuống
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection = -1f; // Di chuyển xuống
        }

        // Kiểm tra khi nhả phím W hoặc S để dừng di chuyển
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            moveDirection = 0f; // Dừng di chuyển
        }

        // Di chuyển nhân vật theo hướng xác định
        transform.Translate(Vector3.up * moveDirection * moveSpeed * Time.deltaTime);
    }
}
