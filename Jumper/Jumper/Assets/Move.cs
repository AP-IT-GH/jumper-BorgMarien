using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = UnityEngine.Random.Range(2f,3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void  OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("EndZone")==true){
            Destroy(this.gameObject);
        }
    }
}
