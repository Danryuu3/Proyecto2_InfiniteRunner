using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject panel;
    public Player player;
    public bool termino;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

     public void OnCollisionEnter2D(Collision2D collision)
     {
    
         if (collision.collider.CompareTag("Player"))
         {
             Destroy(player.personaje.gameObject);
             termino = true;
             panel.SetActive(true);
    
         }
     }
}

