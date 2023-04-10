using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMoney : MonoBehaviour
{

    public float activeTime;
    public float ofsetX= 1F;
    public float yokEtmeZamani;
    public float posY;

    private TMPro.TextMeshPro textMesh;

    private float initialTime;

    private int totalVal;

    private bool actif;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshPro>();
        textMesh.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!actif)
        {
            return;
        }
        if (Time.timeScale - initialTime > activeTime)
        {
            StartCoroutine(yokEt());
        }
    }

    void OnBecameInvisible()
    {
        Debug.Log("Object is no longer visible to the camera");
        actif = false;
        textMesh.alpha = 0;
    }

    IEnumerator yokEt()
    {
        yield return new WaitForSeconds(yokEtmeZamani);
        actif = false;
        textMesh.alpha = 0;
    }

    private void addNewVal(int val)
    {
        totalVal += val;
        textMesh.text = "$" + totalVal.ToString();
    }

    public void showingEarning(Vector3 coordinates, int val)
    {
        if (actif)
        {
            addNewVal(val);
            return;
        }
        actif = true;
        textMesh.alpha = 1;
        Vector3 pos = new Vector3(coordinates.x + ofsetX, posY, coordinates.z);
        transform.position = pos;
        initialTime = Time.unscaledTime;
        totalVal = val;
        textMesh.text = "$" + val.ToString();
    }

    private void OnEnable()
    {
        CoffeEventManager.instance.OnShowTotalEarn.AddListener(showingEarning);
    }

    private void OnDisable()
    {
        CoffeEventManager.instance.OnShowTotalEarn.RemoveListener(showingEarning);
    }
}
