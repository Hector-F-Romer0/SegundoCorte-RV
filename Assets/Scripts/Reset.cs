using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    InstanciaMeteorito instanciaMeteoritoScript;
    // Start is called before the first frame update
     public void reiniciarJuego(){
        SceneManager.LoadScene("SampleScene");
        instanciaMeteoritoScript = GameObject.FindGameObjectWithTag("Instanciador").GetComponent<InstanciaMeteorito>();
        Physics.gravity /= instanciaMeteoritoScript.modificadorGravedad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
