using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour
{

    public ManPool manPool;

    public int initialCount;

    private CountDisplay countDisplay;

    private int[,] dirs = { { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 0 }, { 0, -1 }, { -1, -1 } };
    private int index = -1;

    public float cap;

    // public int count;
    public int divider;//her frame de kaç tane ekleyeceğiz

    private int addDivider;
    private int targetCount;
    private int currentCount;

    void Start()
    {
        countDisplay = GetComponentInChildren<CountDisplay>();
        initCrowd();
    }

    void OnEnable()
    {
        EventManager.instance.OnBonusGet.AddListener(AddNewMans);
        EventManager.instance.OnManDamaged.AddListener(removeMan);

    }
    void OnDisable()
    {
        EventManager.instance.OnBonusGet.RemoveListener(AddNewMans);
        EventManager.instance.OnManDamaged.RemoveListener(removeMan);
    }

    public void removeMan(Man man)
    {
        manPool.realeaseMan(man);
        countDisplay.addCount(-1);
    }

    public void AddNewMans(int count)
    {
        Debug.Log(count + " adam eklendi");
        targetCount = count;
        currentCount = 0;
        addDivider = divider;
        StartCoroutine(AddNewMansDivided());
    }

    private IEnumerator AddNewMansDivided()
    {
        for (int i = 0; i < addDivider; i++)
        {
            addMan();
        }
        countDisplay.addCount(addDivider);        
        yield return new WaitForSeconds(0.1F);
        currentCount += addDivider;
        addDivider = Mathf.Min(divider, targetCount - currentCount);
        EventManager.instance.fireMoveToCenter();
        if (addDivider > 0)
        {
            StartCoroutine(AddNewMansDivided());
        }
    }

    private void addMan()
    {
        float factor = 0.5F;
        index = (index + 1) % dirs.GetLength(0);//dirs tan bir sonraki koordinatı al
        Man newMan;
        newMan = manPool.getManFromPool();        
        newMan.transform.parent = this.transform;
        //yukardaki default tanımlı x ve z koordinatlarını sıradan kullanarak nesneyi konumlandırıyoruz.
        newMan.transform.localPosition = new Vector3(dirs[index, 0] * factor, newMan.manInfo.defYPos, dirs[index, 1] * factor);
        newMan.setPosForAgent();
    }

    private void initCrowd()
    {
        Man newMan;
        Vector3 bufferPos;
        for (int i = 0; i < initialCount; i++)
        {            
            newMan = manPool.getManFromPool();
            bufferPos = newMan.transform.localPosition;
            newMan.transform.parent = this.transform;
            //yukardaki default tanımlı x ve z koordinatlarını sıradan kullanarak nesneyi konumlandırıyoruz.
            newMan.transform.localPosition = bufferPos;
            newMan.setPosForAgent();
            newMan.stopAgent();
        }
         countDisplay.addCount(initialCount);
    }
}
