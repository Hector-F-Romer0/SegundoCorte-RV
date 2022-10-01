using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIReset : MonoBehaviour
{
    public GameObject reset;
    public Image fondo;
    // Start is called before the first frame update
    void Start()
    {
        
        reset.gameObject.SetActive(false);
        fondo.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision c){
        Destroy(gameObject);
        reset.gameObject.SetActive(true);
        fondo.enabled = true ;
    }
}
