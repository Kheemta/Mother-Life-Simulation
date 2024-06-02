// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.AI;


// public class ZoombieController : MonoBehaviour
// {
//     public int damage;
//     public int  headDamage;
//     public int lifeOfAi;
//     public  GameObject HitEffect;
//     private Animator animator;
//     private bool canPlay = true;

//     private void Awake()
//     {
//         animator = GetComponent<Animator>();
        
//     }
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }
//     // Update is called once per frame
//     //void Update()
//     //{

//         //if(ControlFreak2.CF2Input .GetKeyDown(KeyCode.L))
//         //{
//         //    if(EmeraldComponent.IsDead)
//         //    {
//         //        ReLife();
//         //    }
//         //}
//     //}
  
//     public void ReLife()
//     {
        
//     }
//     public void Action()
//     {
//         this.GetComponent<NavMeshAgent>().enabled = false;
//         animator.SetTrigger("Action");
//     }
//     public void ReturnAction()
//     {
//         this.GetComponent<NavMeshAgent>().enabled = true;
//         animator.SetTrigger("ReturnAction");
//     }
//     public void Bodyhitpoints(RaycastHit hitInfo)
//     {
     

        
//         if (canPlay == true)
//         {

//             if (hitInfo.collider.gameObject.name == "Head")
//             {
                
//                 Invoke("Delay", 0.05f);
//                 Debug.Log(hitInfo.collider.gameObject.name);
//                 hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().Damage(headDamage, EmeraldAI.EmeraldAISystem.TargetType.Player);


//                 if (canPlay == true)
//                 {
//                    Instantiate(HitEffect, hitInfo.point, transform.rotation);
//                     Debug.Log(4);
//                     canPlay = false;
//                     hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().gameObject.GetComponent<Animator>().SetInteger("Hit Index", 1);

                    

//                 }
//             }
//             else if (hitInfo.collider.gameObject.name == "Chest")
//             {
//                 Invoke("Delay", 0.05f);
//                 Debug.Log(hitInfo.collider.gameObject.name);
//                 hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().Damage(damage, EmeraldAI.EmeraldAISystem.TargetType.Player);
//                 if (canPlay == true)
//                 {
//                     Instantiate(HitEffect, hitInfo.point, transform.rotation);
//                     Debug.Log(4);
//                     canPlay = false;
//                     hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().gameObject.GetComponent<Animator>().SetInteger("Hit Index", 2);
//                 }
//             }
//             else if (hitInfo.collider.gameObject.name == "LeftLeg")
//             {
//                 Invoke("Delay", 0.05f);
//                 Debug.Log(hitInfo.collider.gameObject.name);
//                 hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().Damage(damage, EmeraldAI.EmeraldAISystem.TargetType.Player);
//                 if (canPlay == true)
//                 {
//                     Instantiate(HitEffect, hitInfo.point, transform.rotation);
//                     Debug.Log(4);
//                     canPlay = false;
//                     hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().gameObject.GetComponent<Animator>().SetInteger("Hit Index", 3);
//                 }
//             }
//             else if (hitInfo.collider.gameObject.name == "RightLeg")
//             {
//                 Invoke("Delay", 0.05f);
//                 Debug.Log(hitInfo.collider.gameObject.name);
//                 hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().Damage(damage, EmeraldAI.EmeraldAISystem.TargetType.Player);
//                 if (canPlay == true)
//                 {
//                     Instantiate(HitEffect, hitInfo.point, transform.rotation);
//                     Debug.Log(4);
//                     canPlay = false;
//                     hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().gameObject.GetComponent<Animator>().SetInteger("Hit Index", 4);
//                 }
//             }
//             else if (hitInfo.collider.gameObject.name == "LeftArm")
//             {
//                 Invoke("Delay", 0.05f);
//                 Debug.Log(hitInfo.collider.gameObject.name);
//                 hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().Damage(damage, EmeraldAI.EmeraldAISystem.TargetType.Player);
//                 if (canPlay == true)
//                 {
//                     Instantiate(HitEffect, hitInfo.point, transform.rotation);
//                     Debug.Log(4);
//                     canPlay = false;
//                     hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().gameObject.GetComponent<Animator>().SetInteger("Hit Index", 5);
//                 }
//             }
//             else if (hitInfo.collider.gameObject.name == "RightArm")
//             {
//                 Invoke("Delay", 0.05f);
//                 Debug.Log(hitInfo.collider.gameObject.name);
//                 hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().Damage(damage, EmeraldAI.EmeraldAISystem.TargetType.Player);
//                 if (canPlay == true)
//                 {
//                     Instantiate(HitEffect, hitInfo.point, transform.rotation);
//                     Debug.Log(4);
//                     canPlay = false;
//                     hitInfo.collider.gameObject.GetComponentInParent<EmeraldAI.EmeraldAISystem>().gameObject.GetComponent<Animator>().SetInteger("Hit Index", 6);
//                 }
//             }
//         }
        
//     }
//     public void Delay()
//     {
//         Debug.Log(5);
//         canPlay = true;
//         animator.SetTrigger("Back");
//         animator.SetInteger("Hit Index",0);
//     }
    
    
// }
