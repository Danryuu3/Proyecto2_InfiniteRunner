using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlBotones : MonoBehaviour
{

    public bool isPause = false;
    public GameObject panel;
    public TextMeshProUGUI scoreF;
    public TextMeshProUGUI score;
    public GameObject boton;
    public Player player;
   
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreF.text = "Has logrado: " + player.score.ToString() + " puntos";
        if (player.ter == true)
        {
            Time.timeScale = 0;
        }
    }

    public void Reinicia()
    {
        SceneManager.LoadScene(0);
    }

    public void Pausa()
    {
        isPause = true;
        panel.SetActive(isPause);
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void Continuar()
        {
        panel.SetActive(false);
         Time.timeScale = 1;

        }
    
}
