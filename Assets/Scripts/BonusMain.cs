using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMain : MonoBehaviour
{
    public Bonus leftBonus;
    public Bonus rightBonus;



    void Start()
    {
        generateBonuses();
        rightBonus.otherBonus = leftBonus;
        leftBonus.otherBonus = rightBonus;
    }

    private void generateBonuses()
    {
        do
        {
            generatForOneSight(leftBonus);
            generatForOneSight(rightBonus);
        } while (isTwoBonusSame());
    }

    private bool isTwoBonusSame()
    {
        //her ikisi de çarpan olmasın
        if (leftBonus.bonusType == rightBonus.bonusType && rightBonus.bonusType == Bonus.BONUS_TYPE_MULTIPLY)
        {
            return true;
        }
        if ( leftBonus.bonusType == rightBonus.bonusType && leftBonus.bonusVal == rightBonus.bonusVal)
        {
            return true;
        }
        return false;
    }

    private void generatForOneSight(Bonus bonus)
    {
        int randInt = Random.Range(1,101);
        bonus.bonusType = randInt % 2; //sonuc ya 0 ya da 1 olacak BONUS_TYPE_MULTIPLY = 1 ; BONUS_TYPE_ADD = 0

        if (bonus.bonusType == Bonus.BONUS_TYPE_MULTIPLY)
        {
            bonus.setBonusVal(Random.Range(2,6));
        }else{
            bonus.setBonusVal(Random.Range(10,50));
        }        
    }
}
