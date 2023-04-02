using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofeMove : MonoBehaviour
{
    public float movementRange = 2f; // Nesnenin hareket edebileceği maksimum mesafe.
    public float movementSpeed = 1f; // Nesnenin hareket hızı.
    private float startXPos; // Başlangıç pozisyonu.

    void Start()
    {
        startXPos = transform.position.x;
    }

    void Update()
    {
        // Hareket mesafesi hesaplanıyor.
        float movementDistance = movementRange * Mathf.Sin(Time.time * movementSpeed);

        // Yeni pozisyon hesaplanıyor ve nesneye atanıyor.
        Vector3 newPos = new Vector3(startXPos + movementDistance, transform.position.y, transform.position.z);
        transform.position = newPos;
    }
}
