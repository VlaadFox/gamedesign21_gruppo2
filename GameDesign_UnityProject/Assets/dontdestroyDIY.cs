using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroyDIY : MonoBehaviour
{
    static dontdestroyDIY instance;
    
    void Awake() {
        //Singleton method
        if (instance == null) {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);
    
        } else if (instance != this) {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
