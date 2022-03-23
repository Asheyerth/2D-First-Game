using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{

    public static int score;
    public Text points;
    // Start is called before the first frame update
    void Start()
    {
        points.GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points.text="Study Points: "+score;
    }
}
