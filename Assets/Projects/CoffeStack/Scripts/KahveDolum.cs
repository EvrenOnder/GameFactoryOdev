using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KahveDolum : MonoBehaviour
{
    public float genislemeHizi;

    public float yukselmeHizi;

    public float maxYPos;

    public bool yuksel{ set; get; }

    private bool doldu;

    private MeshRenderer rend;

    Bardak parent;

    // Start is called before the first frame update
    private void Start() {
        parent = transform.parent.GetComponent<Bardak>();
        rend = transform.GetComponent<MeshRenderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (doldu)
        {
            return;
        }
        if (yuksel)
        {
            rend.enabled = true;
            transform.Translate(transform.up * yukselmeHizi * Time.deltaTime);
            transform.localScale += new Vector3(1,0,1) * genislemeHizi * Time.deltaTime;
            if (transform.localPosition.y > maxYPos)
            {
                doldu= true;
            }
        }        
    }
}
