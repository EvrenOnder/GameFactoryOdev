using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardakManager : MonoBehaviour
{
    

    public Bardak lastAddedBardak;

    private Object addLock = new Object();//bardak ekleme anının tekil çalışması için

    public float bardakAralik = 0;

    public float xMoveSensitivity;
    // Start is called before the first frame update
    void Start()
    {
        Bardak firstBardak = GetComponentInChildren<Bardak>();
        if (firstBardak != null)
        {
            lastAddedBardak = firstBardak;
            firstBardak.setAddedBardakProps();
            firstBardak.bardakManager = this;
        }
    }

    

    // Update is called once per frame
    void Update()
    {

    }

    public void addNewBardak(Bardak addedBardak)
    {
        lock (addLock)
        {
            
            addedBardak.setAddedBardakProps();
            lastAddedBardak.addChildBardak(addedBardak);
            lastAddedBardak = addedBardak;            
            lastAddedBardak.bardakManager = this;
            
        }
    }
}
