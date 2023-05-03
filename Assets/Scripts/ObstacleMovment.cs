using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovment : MonoBehaviour
{
    [SerializeField] float speedMultiplier = 1;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.transform.position.x <-20) GameObject.Destroy(this.gameObject);
        
        if(!GameManager.Instance.IsGameActive()) return;
         GetComponent<Rigidbody>().MovePosition(transform.position+ Vector3.left*Time.fixedDeltaTime*GameManager.Instance.GetGameSpeed());
    }
}
