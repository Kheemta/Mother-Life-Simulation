using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyDetection : MonoBehaviour
{
    public enum bodyPartName { Head,Chest,LeftLeg,RightLeg,LeftArm,RightArm};
    public bodyPartName bodyPartNames;
    private  GameObject bodyPart;

    

    // Start is called before the first frame update
    void Start()
    {
        bodyPart = this.gameObject;
       bodyPart.name= bodyPartNames.ToString();

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
