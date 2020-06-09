using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector3d : MonoBehaviour
{
    [SerializeField]
    Vector3 force;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col){
        col.gameObject.GetComponent<Rigidbody>().velocity = force;
    }
}
