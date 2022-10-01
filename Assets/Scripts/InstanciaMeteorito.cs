using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InstanciaMeteorito : MonoBehaviour
{
    Quaternion angMeteorito;
    int spawnMeteorito;
    public GameObject meteorito;
    public GameObject meteoroG;
    public List<Vector3> posicionesSpawnMeteoritos;
    int i;
    int c; 
    int dificultadMeteoroG;
    float modificadorGravedad;

    // Start is called before the first frame update
    void Start()
    {
        meteoroG.transform.localScale = new Vector3(4,4,4);
        meteorito.transform.localScale = new Vector3(2.7f,2.7f,2.7f);

        posicionesSpawnMeteoritos.Add(new Vector3(2, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(8, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(14, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(24, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(28, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(35, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(42, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(47, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(52, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(55, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(62, 30, 0));
        dificultadMeteoroG = 8;
        modificadorGravedad = 2.5f;
        Physics.gravity*=modificadorGravedad;
        i=0;
        c=0;
         angMeteorito = meteorito.transform.rotation;
         ClonarMeteroritos();
        Debug.Log(posicionesSpawnMeteoritos.Count);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void ClonarMeteroritos(){
        Debug.Log("i = "+i);
        spawnMeteorito = Random.Range(0,posicionesSpawnMeteoritos.Count);
        //Debug.Log("Posici�n aleatoria: " + spawnMeteorito);
        if (i<=dificultadMeteoroG){ 
            if (dificultadMeteoroG == 0){
                meteoroG.transform.localScale = new Vector3(5,5,5);
                InvocarMeteoritoGrande();
            }else{
                Instantiate(meteorito, posicionesSpawnMeteoritos[spawnMeteorito], angMeteorito);
                i++;
            }
        }else{  
            if (modificadorGravedad<13.0f){
                    Physics.gravity/=modificadorGravedad;
                    modificadorGravedad += 0.5f;
                    Physics.gravity*=modificadorGravedad;
                }
                InvocarMeteoritoGrande();
                meteorito.transform.localScale = new Vector3(3.2f,3.2f,3.2f);
                i=0;
                c++;
                //Debug.Log("Contador meteorito"+c);
               // Debug.Log("Gravedad"+modificadorGravedad);
                if(dificultadMeteoroG>0){
                    dificultadMeteoroG--;
                }

            }  
    }
    public void InvocarMeteoritoGrande(){
        //randomNum = Random.Range(1,4);
        spawnMeteorito = Random.Range(0, posicionesSpawnMeteoritos.Count);
        Instantiate(meteoroG, posicionesSpawnMeteoritos[spawnMeteorito], angMeteorito);
    }
}
