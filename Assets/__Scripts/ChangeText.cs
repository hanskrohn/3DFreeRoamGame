using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    public TextMesh text1;
    public TextMesh text2;
    public GameObject character1;
    public GameObject character2;
    public static bool currentWeapon;
    [HideInInspector]
    public GameObject gameObject;
    // Update is called once per frame
    void Start(){
        if(currentWeapon){
            text1.text = "Weapon In Pack";
            text2.text = "Current Weapon";
            gameObject = Instantiate(character2, new Vector3(-4.78f,-1.59f,-5.0f),Quaternion.Euler(0f,180f,0f) );
            gameObject.transform.localScale = new Vector3(3,3,3);
        }
        else{
            text1.text = "Current Weapon";
            text2.text = "Weapon In Pack";
            gameObject = Instantiate(character1, new Vector3(-4.78f,-1.59f,-5.0f),Quaternion.Euler(0f,180f,0f) );
            gameObject.transform.localScale = new Vector3(3,3,3);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            if(currentWeapon){
                text1.text = "Current Weapon";
                text2.text = "Weapon In Pack";
                currentWeapon = false;
                Destroy(gameObject);
                gameObject = Instantiate(character1, new Vector3(-4.78f,-1.59f,-5.0f),Quaternion.Euler(0f,180f,0f) );
                gameObject.transform.localScale = new Vector3(3,3,3);
            }
            else{
                text1.text = "Weapon In Pack";
                text2.text = "Current Weapon";
                currentWeapon = true;
                Destroy(gameObject);
                gameObject = Instantiate(character2, new Vector3(-4.78f,-1.59f,-5.0f),Quaternion.Euler(0f,180f,0f) );
                gameObject.transform.localScale = new Vector3(3,3,3);
            }
        }
    }
    
}
