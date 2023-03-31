using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManPool: MonoBehaviour
{
    Queue<Man> manQue = new Queue<Man>();

    public Man prefab;

    public int addCount = 5;

    void Awake()
    {
        Man[] mans = GetComponentsInChildren<Man>();
        foreach (var man in mans)
        {
            man.gameObject.SetActive(false);
            manQue.Enqueue(man);
        }
    }
    public Man getManFromPool()
    {
        if (manQue.Count == 0)
        {
            generateNewMans();
        }
        Man man = manQue.Dequeue();   
        man.gameObject.SetActive(true);    
        return man;
    }

    private void generateNewMans()
    {
        Man newMan;
        for (int i = 0; i < addCount; i++)
        {
            newMan = GameObject.Instantiate(prefab);
            newMan.transform.parent = this.transform;
            newMan.transform.localPosition = Vector3.zero;
            newMan.gameObject.SetActive(false);
            manQue.Enqueue(newMan);
        }
    }

    public void realeaseMan(Man man)
    {
        man.gameObject.SetActive(false);
        man.transform.parent = this.transform;
        man.transform.localPosition = Vector3.zero;
        manQue.Enqueue(man);
    } 
}
