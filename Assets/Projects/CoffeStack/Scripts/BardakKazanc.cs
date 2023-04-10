using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardakKazanc : MonoBehaviour
{
    public float beklemeSuresi;
    public float yokOlmaHizi;
    public float posY;

    public float ofsetX;

    public TMPro.TextMeshPro textMesh;

    private bool actif;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshPro>();
        textMesh.alpha = 0;
    }
    // Start is called before the first frame update

    public void showKazanc(Vector3 coordinates, int val)
    {
        if (actif)
        {
            return;
        }

        actif = true;
        textMesh.alpha = 1;
        Vector3 pos = new Vector3(coordinates.x - ofsetX, posY, coordinates.z);
        transform.position = pos;
        textMesh.text = "$" + val.ToString();
        StartCoroutine(fadeNumber());
        BardakKazanc yenisi = Instantiate<BardakKazanc>(this);
        yenisi.textMesh.alpha = 0;
    }

    IEnumerator fadeNumber()
    {
        yield return new WaitForSeconds(beklemeSuresi);
        textMesh.alpha = Mathf.Lerp(textMesh.alpha, 0, yokOlmaHizi);
        if (textMesh.alpha < 0.1F)
        {
            DestroyImmediate(this.gameObject);
            yield return null;
        }
        StartCoroutine(fadeNumber());
    }

    private void OnEnable()
    {
        CoffeEventManager.instance.OnShowTotalEarn.AddListener(showKazanc);
    }

    private void OnDisable()
    {
        CoffeEventManager.instance.OnShowTotalEarn.RemoveListener(showKazanc);
    }
}
