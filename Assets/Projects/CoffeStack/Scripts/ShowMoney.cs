using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoney : MonoBehaviour
{
    private TMPro.TextMeshPro textMesh;

    private int money;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshPro>();
    }

    // Update is called once per frame
    private void OnEnable() {
        CoffeEventManager.instance.OnMoneyGet.AddListener(addMoney);
    }
    private void OnDisable() {
        CoffeEventManager.instance.OnMoneyGet.RemoveListener(addMoney);
    }

    public void addMoney(int val)
    {
        money += val;
        textMesh.text=money.ToString();
    }
}
