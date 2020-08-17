using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleScene : MonoBehaviour
{
    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            Application.LoadLevel("SampleScene");
        }
    }
}
