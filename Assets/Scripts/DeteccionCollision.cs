using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeteccionCollision : MonoBehaviour
{   
    InstanciaMeteorito instanciaMeteoritoScript;
    // Start is called before the first frame update
    void Start()
    {
        instanciaMeteoritoScript = GameObject.FindGameObjectWithTag("Instanciador").GetComponent<InstanciaMeteorito>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision tocado)
    {   
        if (tocado.gameObject.tag == "Player"){
            Destroy(tocado.gameObject);
        }   
        if (tocado.gameObject.tag == "PlaneDestroy"){
            instanciaMeteoritoScript.ClonarMeteroritos();
            Destroy(gameObject);
        }
        
    }
}
