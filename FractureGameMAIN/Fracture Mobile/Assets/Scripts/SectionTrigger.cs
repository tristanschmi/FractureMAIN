using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
   public GameObject Level;

   private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.CompareTag("Trigger"))
       {
           Instantiate(Level);
       }
   }
}
