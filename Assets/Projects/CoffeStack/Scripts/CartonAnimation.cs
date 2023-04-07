using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartonAnimation : MonoBehaviour
{
    public Vector3 startPosLocal;

    public Vector3 finPosLocal;

    public float hiz;

    public float resetMesafe;

    public float waitTime;

    private bool bekle = false;
    public float rotationSpeed;

    private bool isRotating = false;
    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

        if (bekle)
        {
            return;
        }
        float uzaklik = Mathf.Abs(Vector3.Distance(finPosLocal, transform.localPosition));

        if (uzaklik < resetMesafe)
        {

            StartCoroutine(yerindeBekle());
        }

        transform.position += transform.up * hiz * Time.deltaTime;
    }

    IEnumerator yerindeBekle()
    {
        bekle = true;
        yield return new WaitForSeconds(waitTime);
        transform.localPosition = startPosLocal;
        bekle = false;
    }

    public void RotateObject()
    {
        // 45 dereceye kadar döndürmek için hedef rotasyonu ayarla
        targetRotation = Quaternion.Euler(0, 45, 0) * transform.rotation;

        // Döndürmeyi başlat
        isRotating = true;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Kapak Takma Basladi");
    }

}
