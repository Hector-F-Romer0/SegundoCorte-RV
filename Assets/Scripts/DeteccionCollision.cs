using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        //Debug.Log("hubo collision");
        instanciaMeteoritoScript.ClonarMeteroritos();
        /*if (tocado.gameObject.tag != "meteorito"){
         Destroy(gameObject);
        }*/ //era para que los meteoritos no se destruyeran entre sì, pero luego ya no fue necesario
        Destroy(gameObject);
        
    }
}
