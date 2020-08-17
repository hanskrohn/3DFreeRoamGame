using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer S = null;
    

    void Awake()
    {
        if (S == null)
        {
            S = this;
        }       
        else
        {
            Debug.Log("Singleton already exists!");
        }
    }
    void Update(){
        
        if(Input.GetKeyDown(KeyCode.P)){
            Application.LoadLevel("Inventory");
        }
        
        
    }

}
