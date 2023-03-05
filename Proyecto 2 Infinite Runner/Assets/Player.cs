using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    bool isJumping;
    public bool puedeMoverse;
    public bool saltando;
    public Rigidbody2D personaje;
    public Animator personajeAnim;

    // Start is called before the first frame update
    void Start()
    {
        personaje = gameObject.GetComponent<Rigidbody2D>();
        personajeAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            if (!puedeMoverse)
            {
                personaje.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                AnimacionSalto(saltando);
                isJumping = true;

            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Plataform"))
        {
            AnimacionCaida(saltando);
            isJumping = false;
        }
    }

    public void AnimacionSalto(bool saltando)
    {
        personajeAnim.SetBool("Saltando", true);

    }

    public void AnimacionCaida(bool caida)
    {
        personajeAnim.SetBool("Saltando", false);
    }
}
