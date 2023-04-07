using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofeMove : MonoBehaviour
{
    public Vector3 moveDirection;
    public float movementRange = 2f; // Nesnenin hareket edebileceği maksimum mesafe.
    public float movementSpeed = 1f; // Nesnenin hareket hızı.
    private Vector3 startPos; // Başlangıç pozisyonu.

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Hareket mesafesi hesaplanıyor.
        float movementDistance = movementRange * Mathf.Sin(Time.time * movementSpeed);

        // Yeni pozisyon hesaplanıyor ve nesneye atanıyor.
        Vector3 newPos =startPos + moveDirection * movementDistance;
        transform.position = newPos;
    }
}
