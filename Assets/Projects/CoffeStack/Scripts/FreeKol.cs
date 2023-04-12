using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeKol : MonoBehaviour
{
    public Transform hedefHiza;

    public Transform bardakTutPos;
    public float rotationSpeed;

    public float xMoveSensitivity;

    private bool isRotating = false;
    private Quaternion targetRotation;

    public float hedefAci;

    private bool isRotated;

    private bool bardakAldi;
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
            transform.parent.rotation = Quaternion.RotateTowards(transform.parent.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (transform.parent.rotation == targetRotation)
            {
                //dereceye ulaşıldı, döndürmeyi durdur
                isRotating = false;
            }
        }
        if (isRotated)
        {
            return;
        }
        float newX = Mathf.Lerp(this.transform.position.x, hedefHiza.position.x, xMoveSensitivity);
        //kolu hizala
        if (newX > -1)
        {
            transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
        }
        
        
        
    }

    public void RotateObject()
    {
        if (isRotated)
        {
            return;
        }
        // 45 dereceye kadar döndürmek için hedef rotasyonu ayarla
        targetRotation = Quaternion.Euler(0,  0, hedefAci) * transform.parent.rotation;

        // Döndürmeyi başlat
        isRotating = true;
        isRotated = true;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("El tuttu Takma Basladi");
        if (bardakAldi  )
        {
            return;
        }
        Bardak bardak = other.GetComponent<Bardak>();
        if (bardak == null)
        {
            return;
        }
        bardak.bardakKolda(bardakTutPos);
        bardakAldi = true;
        RotateObject();

    } 
}
