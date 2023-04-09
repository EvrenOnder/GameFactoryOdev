using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartonDondur : MonoBehaviour
{
    public float rotationSpeed;

    private bool isRotating = false;
    private Quaternion targetRotation;

    public float hedefAci;

    private bool isRotated;
    // Start is called before the first frame update
    void Start()
    {
        // Başlangıçta nesne 0 derecede dursun
        targetRotation = Quaternion.identity;
    }

    void Update()
    {
        if (isRotating)
        {
            // Y ekseninde döndürme
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (transform.rotation == targetRotation)
            {
                // 45 dereceye ulaşıldı, döndürmeyi durdur
                isRotating = false;
            }
        }
    }

    public void RotateObject()
    {
        if (isRotated)
        {
            return;
        }
        // 45 dereceye kadar döndürmek için hedef rotasyonu ayarla
        targetRotation = Quaternion.Euler(0, hedefAci, 0) * transform.rotation;

        // Döndürmeyi başlat
        isRotating = true;
        isRotated = true;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Kapak Takma Basladi");
        RotateObject();
        MeshControl meshControl = other.GetComponent<MeshControl>();
        if (meshControl != null)
        {
            meshControl.meshDegistir (2);//karton takılmış bardak hali.
        }
    }    
}
