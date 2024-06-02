using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    public float  range=5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        Vector3 direction= Vector3.forward; 
        Ray theRay= new Ray(transform.position,transform.TransformDirection(direction*range));
        if(Physics.Raycast(theRay,out RaycastHit hit, range)){

            if(hit.collider.tag=="Usable"){

                Debug.Log("woking hit collide");
            }
        }

    }
    
}
