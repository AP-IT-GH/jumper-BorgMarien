using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject block = null;
    public Transform spawn = null;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn",4);
    }

    // Update is called once per frame
    private void Spawn(){
        GameObject go = Instantiate(block);
        go.transform.position   = new Vector3(spawn.position.x, spawn.position.y,spawn.position.z);
        Invoke("Spawn",2);
    }
}
