using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear : MonoBehaviour
{
    public GameObject mygameObject;


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
            mygameObject.SetActive(true); 
    }
}
