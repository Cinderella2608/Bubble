using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cung : MonoBehaviour
{
    public GameObject arrowPrefab;  // Prefab của mũi tên
    public Transform firePoint;     // Vị trí bắn mũi tên (thường là nơi cung hoặc tay nhân vật)
    public float fireRate = 1f;     // Thời gian giữa các lần bắn (số lần bắn mỗi giây)
    private bool Fire = true;

    void Update()
    {
        // Kiểm tra khi người chơi bấm phím "Space" và đảm bảo đủ thời gian để bắn tiếp
        if (Input.GetKey(KeyCode.Z) && Fire)
        {
            FireArrow(); // Gọi hàm để bắn mũi tên
            StartCoroutine(RateOfFire()); // Cập nhật thời gian cho lần bắn tiếp theo
        }
    }

    void FireArrow()
    {
        // Tạo mũi tên từ vị trí firePoint và theo hướng mà cung đang hướng tới
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator RateOfFire()
    {
        Fire = false; // Tạm ngừng bắn
        yield return new WaitForSeconds(fireRate); // Đợi đến thời gian cho phép bắn tiếp
        Fire = true; // Cho phép bắn tiếp
    }
}
