using UnityEngine;
using System.Collections;

public class DirecaoTiro : MonoBehaviour {

    ArrastaBola bola;

    SpriteRenderer desenharSeta;
    float angulo;

    private void Awake()
    {
       desenharSeta = GetComponent<SpriteRenderer>();
 
    }

    void Start () {

        bola = new ArrastaBola();
        

        desenharSeta.enabled = false;
        angulo = 90.0f;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(bola.toque == true) {

            desenharSeta.enabled = true;
            angulo++;
            this.transform.Rotate(this.transform.position, angulo);
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
