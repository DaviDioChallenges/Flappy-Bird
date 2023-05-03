using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject simpleSpawn, doubleSpawn;
    [SerializeField] int simpleRate=1;
    [SerializeField] float xoffset= 0;

    [SerializeField] private float spawnIntervals= 15f;
    [SerializeField] private float warmUp=5f;
    private float cooldown=0;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = warmUp;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.IsGameActive()) return;
        cooldown -= Time.deltaTime;
        if(!simpleSpawn) return;

        if(cooldown<0)
        {
            if(Random.Range(0,simpleRate)+1==simpleRate ||!doubleSpawn)
                Instantiate(simpleSpawn,Vector3.right*xoffset,Quaternion.identity);
            else  
                Instantiate(doubleSpawn,Vector3.right*xoffset,Quaternion.identity);

            cooldown = spawnIntervals;
        }
    }
}
