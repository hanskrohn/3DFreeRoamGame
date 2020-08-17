using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public int points;
    public Text pointsText;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        pointsText.text = "Points: " + points.ToString();
    }
}
