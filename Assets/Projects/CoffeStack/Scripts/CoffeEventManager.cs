using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoffeEventManager
{
    public static CoffeEventManager instance = new CoffeEventManager();



    public UnityEvent<int> OnMoneyGet = new UnityEvent<int>();

    public void fireMoneyAdd(int val)
    {
        OnMoneyGet.Invoke(val);
    }

    public UnityEvent<Vector3, int> OnShowTotalEarn = new UnityEvent<Vector3, int>();

    public void fireShowTotalEarn(Vector3 pos, int val)
    {
        OnShowTotalEarn.Invoke(pos,val);
    }

}
