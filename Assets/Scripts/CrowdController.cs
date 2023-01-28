using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour
{
    public Man manFull;
    public Transform pivot;
    private float pi = 3F;
    private int targetCount = 0;
    private int currentCount = 0;

    public int modAzalt = 1;

    public int testCountSil;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    public void generateCrowd(int count)
    {   
        count = testCountSil;
        targetCount = count;
        //cember mantığı düşünülerek kişiler yerleştirilecek
        int cap =((int) Mathf.Sqrt(count  / pi) )* 2 + 1;
        
        Debug.Log("ÇAP = " + cap);
        //orta yani captaki sıra dolduruluyor.
        generateRow(0,0,cap);
        currentCount = cap;
        int nextLineCountOn = cap;

        bool sayiAzalt = true;
   
        int nextCount;
        int zpos = 1;
        int tekSira = 1;
        int siraAzaltmali = 1;//modüler bölme sonucu bu değer 0 olursa sıra zalacak
        //hedef kişi sayısına ulaşana kadar döngü devam edecek
        while(true)
        {
            // çaptan sonra sırayla diğer sıralar için ilgili sıraya yerleştirilecek kişi sayısı hesaplanır.
            nextCount = nextLineCountHesapla(nextLineCountOn,sayiAzalt);
            //demekki hedef sayıya ulaştık. Artık döngüden çıkalım.
            if (nextCount<= 0)
            {
                break;
            }
            //bir sonaki sıranın yatayda yerleşirken kullanacağ x pozisyonu için hesaplama yapılıyor (bir kişinin genişliği kullanılıyor.). 
            float xpos = manFull.manInfo.distanceBetween/2;
            //2 sırada bir x pozisyonu kaydırılarak kovan yerleşim örgüsü oluşturuluyor.
            if (tekSira == 0)
            {
                xpos = 0;
            }
            // hedef sayısı aşmamak için kontrolde kullandığımız mevcut sayı güncelleniyor.
            currentCount += nextCount;
                    
            nextLineCountOn = nextCount;
            //sıradaki sıra için kişiler oluşturuluyor
            generateRow(zpos, xpos, nextLineCountOn);
            //aynı sayıda kişi çapa göre simetrik olacak şekilde arka tarafa yerleştiriliyor. ama hedef sayıyı aşmamak gerekiyor.
            nextCount = Mathf.Min(nextCount, targetCount-currentCount);  
       
            currentCount += nextCount;//mevcut sayıyı yine güncelliyoruz.
            //çapa göre simetrik olacak şekilde arka sırayı da oluşturuyoruz.
            generateRow(-zpos, xpos, nextCount);

            zpos++;
            tekSira = (tekSira+1) % 2;//teki sıra hesabı. kovan yerleşim düzeni için
            
            siraAzaltmali = (siraAzaltmali + 1) % modAzalt;
            Debug.Log("Sıralamayı Azalt " + siraAzaltmali);
            if (siraAzaltmali == 0)
            {
                sayiAzalt = !sayiAzalt;
            }
            
        }
    }

    private int nextLineCountHesapla(int prevLineCount, bool sayiAzalt )
    {
        int val = 0;

        if (sayiAzalt)
        {            
            val = -1;
        }
        int count = prevLineCount + val;
        return Mathf.Min(count, targetCount-currentCount);        
    }

    private void generateRow (float zPos, float xpos,int count)
    {
        
        Man newMan;
        int sag = 0;
        int sol = 1;
        float defYPos = manFull.manInfo.defYPos;
        float distanceBetween = manFull.manInfo.distanceBetween;
        while (true)
        {
            newMan = GameObject.Instantiate(manFull);
            newMan.transform.parent = this.transform;
            newMan.transform.localPosition = new Vector3(xpos + sag * distanceBetween , defYPos,zPos);
            sag++;
            if ((sag+sol) > count) break;
            newMan = GameObject.Instantiate(manFull);
            newMan.transform.parent = this.transform;
            newMan.transform.localPosition = new Vector3(xpos - sol * distanceBetween , defYPos ,zPos);
            sol++;
            if ((sag+sol) > count) break;
        }
    }    
}
