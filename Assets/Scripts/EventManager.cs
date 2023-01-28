using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager
{
    public static EventManager instance = new EventManager();


    public UnityEvent OnMoveToCenter = new UnityEvent();//kişişlerin merkeze yönelmesini bildirir.

    public void fireMoveToCenter()
    {
        OnMoveToCenter.Invoke();
    }

    public UnityEvent<int> OnBonusGet = new UnityEvent<int>();//bonusa tıklanınca ne yapılması gerektiğ

    public void fireBonusGet(int bonusVal)
    {
        OnBonusGet.Invoke(bonusVal);
    }


    public UnityEvent<Man> OnManDamaged = new UnityEvent<Man>();//bonusa tıklanınca ne yapılması gerektiğ

    public void fireManDamage(Man man)
    {
        OnManDamaged.Invoke(man);
    }

}
