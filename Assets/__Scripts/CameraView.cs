using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject thirdCam;
    public GameObject firstCam;
    public static int camMode;
    public GameObject player;
    [HideInInspector]
    public Vector3 euler;

    // Update is called once per frame
    void Start(){
        if(camMode == 0 ){
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
        }
        if(camMode == 1){
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
        }
    }
    void Update()
    {
        if(Input.GetButtonDown("Camera")){
            
            if(camMode == 1){
                camMode = 0;
            }
            else{
                camMode += 1;
            }
            euler = player.transform.rotation.eulerAngles;
            StartCoroutine (CamChange());
            player.transform.rotation = Quaternion.Euler(new Vector3(0, euler.y,0));
        }
        
    }
   
    IEnumerator CamChange(){
        yield return new WaitForSeconds(0.01f);
        if(camMode == 0 ){
            thirdCam.SetActive(true);
            firstCam.SetActive(false);
            
        }
        if(camMode == 1){
            thirdCam.SetActive(false);
            firstCam.SetActive(true);
            
        }
    }
}
