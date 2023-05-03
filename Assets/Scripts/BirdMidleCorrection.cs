using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMidleCorrection : MonoBehaviour
{
    [SerializeField] float correctionSpeed=1;
    float startingX;
    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x> startingX) transform.Translate(Vector3.left*Time.deltaTime*correctionSpeed);
        else transform.Translate(Vector3.right*Time.deltaTime*correctionSpeed);
    }
}
