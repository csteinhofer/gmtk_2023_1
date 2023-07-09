using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMessage : MonoBehaviour
{
    public GameObject MsgGate;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Debug.Log("Hit Gate");
            MsgGate.SetActive(true);
        }
 
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MsgGate.SetActive(false);
        }

    }
}
