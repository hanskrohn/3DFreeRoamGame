using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharacter : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject parent;
    public GameObject gameObject;
    private int distance = 1;
    private void Awake()
    {
        if(ChangeText.currentWeapon == true){
            gameObject = Instantiate(character1, parent.transform.position  ,Quaternion.Euler(0f,0f,0f) );
            gameObject.transform.parent = parent.transform;
            gameObject.transform.localScale = new Vector3(1,1,1);
            gameObject.transform.Translate(0.0f, -1.0f, 0.0f);
            if(CameraView.camMode == 1){
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180 ,0));
            }
        }
        else{
            gameObject = Instantiate(character2, parent.transform.position  ,Quaternion.Euler(0f,0f,0f) );
            gameObject.transform.parent = parent.transform;
            gameObject.transform.localScale = new Vector3(1,1,1);
            gameObject.transform.Translate(0.0f, -1.0f, 0.0f);
            if(CameraView.camMode == 1){
                gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180 ,0));
            }
        }
            
    }
   
    
}
