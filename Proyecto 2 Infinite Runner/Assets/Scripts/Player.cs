using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    bool isJumping;
    public bool puedeMoverse;
    public bool saltando;
    public bool retroceso;
    public GameObject panel;
    public Transform target;
    public Rigidbody2D personaje;
    public Animator personajeAnim;
    public Vector2 velocidadRebote;
    public TextMeshProUGUI scoretexto;
    public int score;
    public bool ter;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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

        AnimacionRetroceso(retroceso);

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Plataform"))
        {
            AnimacionCaida(saltando);
            isJumping = false;
        }

        if (collision.collider.CompareTag("Obstacle"))
        {
            Rebote(velocidadRebote);
            personajeAnim.SetTrigger("Rebote");
            StartCoroutine(Mover());
            StartCoroutine(Invulnerable());
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(personaje.gameObject);
            panel.SetActive(true);
            ter = true;

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable")) 
        { 
        score += 100;
        scoretexto.text = score.ToString();
        }
    }

    public void Rebote(Vector2 rebote)
    {
        personaje.velocity = new Vector2(-velocidadRebote.x * rebote.x, velocidadRebote.y);
    }

    public void AnimacionSalto(bool saltando)
    {
        personajeAnim.SetBool("Saltando", true);

    }

    public void AnimacionCaida(bool caida)
    {
        personajeAnim.SetBool("Saltando", false);
    }

    public void AnimacionRetroceso(bool retroceso)
    {
        
            personajeAnim.SetBool("Volver", false);
    }

    private IEnumerator Mover()
    {
        puedeMoverse = true;
        yield return new WaitForSeconds(1.5f);
        puedeMoverse = false;

    }

    private IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
