using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wingame : MonoBehaviour
{

    public static int scoref;
    public Text fpoints;
    // Start is called before the first frame update
    void Start()
    {
        fpoints.GetComponent<Text>();
        scoref = scoreText.score;
    }

    // Update is called once per frame
    void Update()
    {
        fpoints.text="+ " + scoref + " Study Points";
    }
}
