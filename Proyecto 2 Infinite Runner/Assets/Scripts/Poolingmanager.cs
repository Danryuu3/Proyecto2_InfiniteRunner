using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolingmanager : MonoBehaviour
{
    public GameObject[] escenearios;
    public GameObject spawn;
    int i;
    
    // Start is called before the first frame update
    void Start()
    {
        
        AparecerEscenarios();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AparecerEscenarios()
    {
        StartCoroutine(Escenario());
        
    }

    private IEnumerator Escenario()
    {
        while(i != 100) 
        { 
            i++;
            int numeroRandom = Random.Range(0, escenearios.Length);
            yield return new WaitForSeconds(6.3f);
            Instantiate(escenearios[numeroRandom], spawn.transform.position, Quaternion.identity);
        }
    }

   



}
