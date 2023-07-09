using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMessage : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       target.GetComponent<PopHandle>().Popping("Hit Da Gate");
    }
}
