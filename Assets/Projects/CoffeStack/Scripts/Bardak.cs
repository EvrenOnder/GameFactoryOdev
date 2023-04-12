using System.Collections;
using UnityEngine;

public class Bardak : PoolAbleObject
{
    public float bardakAralik;
    public BardakManager bardakManager;
    private Bardak parentBardak { get; set; }//hangi bardağın arkasına eklenmişim
    private Bardak childBardak { get; set; }// hangi bardak benim arkama eklenmiş

    private Rigidbody rb;

    private BuyuVeKucul buyuVeKucul;


    // Start is called before the first frame update
    void Start()
    {
        buyuVeKucul = GetComponent<BuyuVeKucul>();
    }

    // Update is called once per frame
    void Update()
    {

        if (parentBardak != null)
        {
            Vector3 pos =  parentBardak.transform.position;
            Vector3 myPos = transform.position;
            float newX = Mathf.Lerp(this.transform.position.x, pos.x, bardakManager.xMoveSensitivity);
            pos.z += bardakManager.bardakAralik;
            pos.x = newX;
            pos.y = myPos.y;
            transform.position = pos;
        }
    }

    public void addChildBardak(Bardak bardak)
    {
        childBardak = bardak;        
        bardak.parentBardak = this;
        childBardak.changeSizeUpDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger " + this.name + " -> " + other.name);
        if (other.tag == "Bardak")
        {
            Debug.Log("myname,  Other Tag = " + this.name + " , " + other.tag);
            Bardak bardak = other.GetComponent<Bardak>();
            if (bardak != null)
            {
                bardakManager.addNewBardak(bardak);
                CoffeEventManager.instance.fireMoneyAdd(1);
                CoffeEventManager.instance.fireShowTotalEarn(this.transform.position , 1);
            }
        }else if (other.tag == "Kahve")
        {
            kahveDoldur();
            CoffeEventManager.instance.fireMoneyAdd(1);
            CoffeEventManager.instance.fireShowTotalEarn(this.transform.position , 1);
        }
    }

    private void kahveDoldur()
    {
        KahveDolum kahveDolum = GetComponentInChildren<KahveDolum>();
        if (kahveDolum != null)
        {
            kahveDolum.yuksel = true;
        }
    }

    public void setAddedBardakProps()
    {
        //adding rigidbody;
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        this.tag = "Untagged";
    }

    public void changeSizeUpDown()
    {
        buyuVeKucul.buyutKucult();
        if (parentBardak != null)
        {
            StartCoroutine(bekleVeParentBuyut());
        }
    }

    IEnumerator bekleVeParentBuyut()
    {
        yield return new WaitForSeconds(0.1f);
        parentBardak.changeSizeUpDown();
    }
    

    public void bardakKolda (Transform kol)
    {
        // bardagi aradan çıkarıp childı ile parentını birbirine bağlıyoruz.
        if (childBardak != null)
        {
            childBardak.parentBardak = parentBardak; 
        } else//son bardağım demekki
        {
            bardakManager.lastAddedBardak = parentBardak;
        }       
        parentBardak.childBardak = childBardak;
        parentBardak = null;
        childBardak = null;

        transform.parent = kol;        
        transform.localPosition = Vector3.zero;
    }
}
