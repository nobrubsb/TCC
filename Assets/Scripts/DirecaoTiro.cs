using UnityEngine;
using System.Collections;

public class DirecaoTiro : MonoBehaviour {

    ArrastaBola bola;


    SpriteRenderer desenharSeta;

    private void Awake()
    {
       desenharSeta = GetComponent<SpriteRenderer>();
 
    }

    void Start () {

        bola = new ArrastaBola();        

        desenharSeta.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
        
        if(bola.toque == true) {

            desenharSeta.enabled = true;
        }

	}
    private void OnMouseDown()
    {
        bola.toque= true;
        
    }
    private void OnMouseUp()
    {
        bola.toque = false;

    }

    
}
