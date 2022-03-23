using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
   
    public void Reload()
    {
        SceneManager.LoadScene("2D-First-deliver");
        scoreText.score = 0;
    }
}
