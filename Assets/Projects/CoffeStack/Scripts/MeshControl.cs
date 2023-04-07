using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshControl : MonoBehaviour
{
    public Transform[] meshs;

    private int activeMesh;
    // Start is called before the first frame update
    void Start()
    {
        for ( int i = 0; i < meshs.Length;i++)
        {
            meshs[i].gameObject.SetActive(false);
        }
        meshs[0].gameObject.SetActive(true);
        activeMesh = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger " + this.name + " -> " + other.name);
        if (other.tag == "Kapak")
        {
            meshDegistir(1);
        }
        
    }

    public  void meshDegistir(int newMesh)
    {
        meshs[activeMesh].gameObject.SetActive(false);
        meshs[newMesh].gameObject.SetActive(true);
        activeMesh = newMesh;
    }
}
