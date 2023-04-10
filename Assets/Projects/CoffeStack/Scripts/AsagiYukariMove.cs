using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsagiYukariMove : MonoBehaviour
{
   public float speed = 1f;
    public float distance = 2f;

    private float startPosY;
    private float time = 0f;

    private bool isMove = false;
    public void asagiYukariHareket()
    {
        startPosY = transform.localPosition.y;
        isMove = true;
        Debug.Log(name + " moved");
    }

    private void Update() 
    {
        if (!isMove)
        {
            return;
        }
        // Hareket mesafesi kadar bir açı hesapla
        float angle = Mathf.Sin(time * speed) * Mathf.PI / 2f;
        Vector3 bufferPos = transform.localPosition;
        bufferPos.y = startPosY + -Mathf.Abs(distance) * Mathf.Cos(angle);
        

        // Nesneyi yeni pozisyona taşı
        transform.localPosition = bufferPos;

        // Zamanı güncelle
        time += Time.deltaTime;

        // Hareket tamamlandıysa, nesneyi başlangıç pozisyonuna geri döndür
        if (time > Mathf.PI / (2f * speed))
        {
//            transform.localPosition = startPosition;
            isMove = false;
        }
    }
}
