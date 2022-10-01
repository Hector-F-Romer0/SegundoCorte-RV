using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InstanciaMeteorito : MonoBehaviour
{
    public Quaternion angMeteorito;
    public int spawnMeteorito;
    public GameObject meteorito;
    public GameObject meteoroG;
    public List<Vector3> posicionesSpawnMeteoritos;
    int i;
    int c; 
    int dificultadMeteoroG;

    // Start is called before the first frame update
    void Start()
    {
        posicionesSpawnMeteoritos.Add(new Vector3(5, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(8, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(14, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(24, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(28, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(35, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(42, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(47, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(50, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(53, 30, 0));
        posicionesSpawnMeteoritos.Add(new Vector3(57, 30, 0));
        dificultadMeteoroG = 9;
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
        i++;
        spawnMeteorito = Random.Range(0,posicionesSpawnMeteoritos.Count);
        Debug.Log("Posición aleatoria: " + spawnMeteorito);
        if (i<dificultadMeteoroG){ 
            
            Instantiate(meteorito, posicionesSpawnMeteoritos[spawnMeteorito], angMeteorito);
            
            } else{
                InvocarMeteoritoGrande();
                i=0;
                c++;
                if(dificultadMeteoroG>0){
                    dificultadMeteoroG--;
                }
                if (c==10){
                    dificultadMeteoroG = 0;
                }
            }  
    }
    public void InvocarMeteoritoGrande(){
        //randomNum = Random.Range(1,4);
        spawnMeteorito = Random.Range(0, posicionesSpawnMeteoritos.Count);
        Instantiate(meteorito, posicionesSpawnMeteoritos[spawnMeteorito], angMeteorito);
    }
}
