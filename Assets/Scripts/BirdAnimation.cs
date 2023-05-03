using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    [SerializeField] float bounceRange=1;
    [SerializeField] float speed = 1;
    float timer = 0;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.IsGameActive()) return;
        timer += Time.deltaTime*speed*GameManager.Instance.speedRatio();
        var value = Mathf.Sin(timer)*bounceRange;
        this.gameObject.transform.localRotation=Quaternion.Euler( Vector3.left*value);
    }
}
