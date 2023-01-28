using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public static int BONUS_TYPE_ADD = 0;
    public static int BONUS_TYPE_MULTIPLY = 1;

    public int bonusType; // yukardaki static değerlerden birisini alacak.
    public int bonusVal = 0;
    private BoxCollider col = null;

    private bool isCollided = false;

    private TMPro.TextMeshPro textMeshPro;
    public Bonus otherBonus;

     void Awake()
    {
        textMeshPro = GetComponentInChildren<TMPro.TextMeshPro>();
        col = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        otherBonus.disableCollider();
        col.enabled = false;
        isCollided = true;
        calculateAndProvideBonus();
    }

    public void disableCollider()
    {
        col.enabled = false;
    }

    public void setBonusVal(int val)
    {
        bonusVal = val;
        string preChar = "x";
        if (bonusType != BONUS_TYPE_MULTIPLY)
        {
            preChar = "+";
        }
        textMeshPro.text = preChar + bonusVal.ToString();
    }

    private void calculateAndProvideBonus()
    {
        int bonus = 0;
        if(bonusType == BONUS_TYPE_MULTIPLY)
        {
            bonus = StaticInfoHolder.mans.Length * bonusVal;
        }else
        {
            bonus = bonusVal;
        }
        EventManager.instance.fireBonusGet(bonus);
    }
}
