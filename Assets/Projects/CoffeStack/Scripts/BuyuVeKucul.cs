using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyuVeKucul : MonoBehaviour
{
    public float growthDuration = 1f; // büyüme/küçülme süresi
    public float growthAmount = 0.2f; // büyüme/küçülme oranı
    public AnimationCurve growthCurve; // büyüme/küçülme eğrisi

    private Vector3 initialScale; // başlangıç boyutu
    private Vector3 targetScale; // hedef boyut
    private bool isBuyuKucul;
    void Start()
    {

    }

    IEnumerator GrowAndShrink()
    {
        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            float t = elapsedTime / growthDuration; // büyüme/küçülme oranı

            float growthValue = growthCurve.Evaluate(t); // büyüme/küçülme eğrisine göre boyut değişimi hesaplanır            

            Vector3 newScale = Vector3.Lerp(initialScale, targetScale, growthValue); // obje boyutu değiştirilir

            newScale.z = initialScale.z;

            transform.localScale = newScale;

            elapsedTime += Time.deltaTime; // geçen süre güncellenir

            yield return null; // bir sonraki frame beklenir
        }

        transform.localScale = initialScale; // büyütme/küçültme işlemi tamamlandıktan sonra obje boyutu başlangıç boyutuna döndürülür
        isBuyuKucul = false;
    }

    public void buyutKucult()
    {
        if (isBuyuKucul)
        {
            return;
        }
        initialScale = transform.localScale;
        targetScale = initialScale * (1f + growthAmount); // hedef boyut, başlangıç boyutunun belirli bir oranı kadar büyük
        isBuyuKucul = true;
        StartCoroutine(GrowAndShrink());
      //  StartCoroutine(GrowAndShrink());
    }

}
