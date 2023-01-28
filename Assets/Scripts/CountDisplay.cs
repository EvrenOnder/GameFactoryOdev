using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDisplay : MonoBehaviour
{
    public float timer= 0.2F;

    private int count = 0;
    private float maxZpos= -200000F;//en düşük z ilk değeri
    public TMPro.TextMeshPro textMesh;
    private ArrayList mans = new ArrayList();
    private bool isControl= true;

    private Transform maxPoint = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //belirli aralıklar ile pozisyonları kontrol edip maximum pozisyon değerleri bulunuyor.
        if (isControl)
        {
            controlPos();
            isControl = false;
            StartCoroutine(controlTimer());
        }   
        if (maxPoint == null )
        {
            return;
        }
        Vector3 targetPos = transform.localPosition;
        targetPos.z = maxPoint.localPosition.z;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, 0.1F);

    }
    /*
        Hem toplam sayıyı gösterecek pozisyonu bulmak hem de grubun dışarı taşmasını engellemek için maksimum 
        ve minimum  xpozisyonları bulmak için bu method berlirli aralıklarla çağrılıyor.
    */
    private void controlPos()
    {
        Man[] mans = transform.parent.GetComponentsInChildren<Man>();
        if( mans.Length == 0)
        {
            return;
        }
        StaticInfoHolder.mans = mans;
        maxZpos = -200000;

        foreach (var man in mans)
        {
            if (maxZpos < man.transform.localPosition.z)
            {
                maxZpos = man.transform.localPosition.z;
                maxPoint = man.transform;
            }

        }
    }

    //son pozisyonu kontrol etmek için kullanılacak
    private IEnumerator controlTimer ()
    {
        yield return new WaitForSeconds(timer);
        isControl = true;
    }

    public void addCount(int val)
    {
        count += val;
        textMesh.text = count.ToString();
    }
}
