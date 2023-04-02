using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool: MonoBehaviour
{
    Queue<GameObject> itemQue = new Queue<GameObject>();
    

    public GameObject prefab;

    public int addCount = 5;

    void Awake()
    {
        PoolAbleObject[] items = GetComponentsInChildren<PoolAbleObject>();
        foreach (var item in items)
        {
            item.gameObject.SetActive(false);
            itemQue.Enqueue(item.gameObject);
        }
    }
    public GameObject getItemFromPool()
    {
        if (itemQue.Count == 0)
        {
            generateNewItems();
        }
        GameObject item = itemQue.Dequeue();   
        item.SetActive(true);    
        return item;
    }

    private void generateNewItems()
    {
        GameObject newItem;
        for (int i = 0; i < addCount; i++)
        {
            newItem = GameObject.Instantiate(prefab);
            newItem.transform.parent = this.transform;
            newItem.transform.localPosition = Vector3.zero;
            newItem.gameObject.SetActive(false);
            itemQue.Enqueue(newItem);
        }
    }

    public void realeaseItem(GameObject item)
    {
        item.gameObject.SetActive(false);
        item.transform.parent = this.transform;
        item.transform.localPosition = Vector3.zero;
        itemQue.Enqueue(item);
    } 
}
