using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaMeteorito : MonoBehaviour
{
    public Quaternion angMeteorito;
    public int randomNum;
    public GameObject meteorito;
    public GameObject meteoroG;
    Vector3 posicion1 = new Vector3(0,13,0);
    Vector3 posicion2 = new Vector3(-8,13,0);
    Vector3 posicion3 = new Vector3(8,13,0);
    int i;
    int c; 
    int dificultadMeteoroG;

    // Start is called before the first frame update
    void Start()
    {    
        dificultadMeteoroG = 9;
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
        i++;
        randomNum = Random.Range(1,4);
        if (i<dificultadMeteoroG){
            Debug.Log(randomNum);
            if (randomNum==1){
                Instantiate(meteorito, posicion1, angMeteorito);
            }
            if (randomNum==2){
                Instantiate(meteorito, posicion2, angMeteorito);
            }
            if (randomNum==3){
                Instantiate(meteorito, posicion3, angMeteorito);
            }
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
        randomNum = Random.Range(1,4);
            if (randomNum==1){
                Instantiate(meteoroG, posicion1, angMeteorito);
            }
            if (randomNum==2){
                Instantiate(meteoroG, posicion2, angMeteorito);
            }
            if (randomNum==3){
                Instantiate(meteoroG, posicion3, angMeteorito);
            }
    }
}
