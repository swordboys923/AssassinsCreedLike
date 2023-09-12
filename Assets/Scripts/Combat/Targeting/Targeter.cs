using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour {
    private List<Target> targetList = new List<Target>();

    private void OnTriggerEnter(Collider other) {
        // if(other.TryGetComponent<Target>()) {
            
        // }
    }

    private void OnTriggerExit(Collider other) {
        
    }
}
