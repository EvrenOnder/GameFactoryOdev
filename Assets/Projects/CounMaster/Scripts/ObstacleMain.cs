using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMain : MonoBehaviour
{
    public Vector2 leftRightPos = new Vector2();
    // Start is called before the first frame update
    void Awake()
    {
        this.tag = "Obstacle";
    }
}
