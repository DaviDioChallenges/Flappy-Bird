using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Vector2 yPositionRange = new Vector2(-5,5);
    [SerializeField] float speedMultiplier = 1;
    bool reverse = false;
    // Start is called before the first frame update
    void Start()
    {
        float newpos = Random.Range(yPositionRange.x, yPositionRange.y);
        transform.position = transform.position + newpos*Vector3.up;
        if(Random.Range(0,2)>0)
        {
            reverse=true;
            transform.rotation = Quaternion.Euler(Vector3.forward*180);
        }  
    }
}
