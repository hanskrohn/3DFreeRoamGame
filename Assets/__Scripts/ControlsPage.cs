using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsPage : MonoBehaviour
{
    public void PlayScene(){
        SceneManager.LoadScene("SampleScene");
    }
    public void ControlsScene(){
        SceneManager.LoadScene("ControlsScene");
    }
    public void MainScene(){
        SceneManager.LoadScene("Start");
    }
    public void Objectives(){
        SceneManager.LoadScene("Objectives");
    }
}
