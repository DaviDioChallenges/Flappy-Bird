using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    Rigidbody birdRigidBody;
    [SerializeField] float flapPower=1f;
    [SerializeField] float flapInterval = 0.1f;
    private float flapCooldown=0;
    // Start is called before the first frame update
    void Start()
    {
        birdRigidBody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.IsGameActive()) return;
        flapCooldown -= Time.deltaTime;
        if(transform.rotation.z>0)
            transform.Rotate(Vector3.back,5*Time.deltaTime);
        if(Input.GetKey(KeyCode.Space)&& flapCooldown<0)
        {
            birdRigidBody.velocity =  new Vector3(birdRigidBody.velocity.x, 0, birdRigidBody.velocity.z);
            birdRigidBody.AddForce(Vector3.up*flapPower,ForceMode.Impulse);
            flapCooldown = flapInterval;
        }     
    }
}
