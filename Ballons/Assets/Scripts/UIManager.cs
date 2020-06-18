using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Se debe exportar esto
using TMPro;

public class UIManager : MonoBehaviour
{
    int tiempo = 0;
    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;

    //Nuevo Metodo

    public void AddScore(int punto)
    {
       score= score + (punto);
        if (score >= 5)
        {
            SceneManager.LoadScene(3);
        }else if(score <= -1)
        {
            SceneManager.LoadScene(2);

        }
        scoreText.text = score.ToString();
       
    }
    public void AddTimer(int punto)
    {
        tiempo += punto;
        timerText.text = tiempo.ToString();
    }
}
