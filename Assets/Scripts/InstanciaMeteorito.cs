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
    int dificultadMeteoroG;
    public float modificadorGravedad;

    int i;
    int c;

    // Start is called before the first frame update
    void Start()
    {
        meteoroG.transform.localScale = new Vector3(4, 4, 4);
        meteorito.transform.localScale = new Vector3(2.7f, 2.7f, 2.7f);
        posicionesSpawnMeteoritos.Add(new Vector3(582, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(589, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(594, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(595, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(599, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(604, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(612, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(619, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(625, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(633, 40, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(637, 40, 0));
        dificultadMeteoroG = 8;
        modificadorGravedad = 2.0f;
        Physics.gravity*=modificadorGravedad;
        i=0;
        c=0;
         angMeteorito = meteorito.transform.rotation;
         ClonarMeteroritos();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ClonarMeteroritos(){
        //Debug.Log("i = "+i);

        spawnMeteorito = Random.Range(0,posicionesSpawnMeteoritos.Count);
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
        spawnMeteorito = Random.Range(0, posicionesSpawnMeteoritos.Count);
        Instantiate(meteoroG, posicionesSpawnMeteoritos[spawnMeteorito], angMeteorito);
    }
}
