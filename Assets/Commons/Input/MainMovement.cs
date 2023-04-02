using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMovement : MonoBehaviour
{

    public bool isMove= false;
    public float speed;
    public Vector3 direction = Vector3.back;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            this.transform.Translate(direction * Time.deltaTime * speed, Space.Self);
        }
    }

    public void startToMove()
    {
        isMove = true;
    }
}
