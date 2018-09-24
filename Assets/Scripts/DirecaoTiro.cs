using UnityEngine;
using System.Collections;

public class DirecaoTiro : MonoBehaviour {

    SpriteRenderer desenhar;
    float angulo = 0.000001f;
    public float posX = 320.0f, posY, posAtual;
    

    private void Awake()
    {
        desenhar = GetComponent<SpriteRenderer>();
    }

    void Start () {

        desenhar.enabled = true;
        
    }
	
	// Update is called once per frame
	void Update () {

        Direcao();


    }
    
    void Direcao()
    {

        posY++;
        Vector3 posicao = new Vector3(posX, posY);
        transform.position = posicao;

        if (posY == 170 || posY == -170)
        {
            
            posY *= -1;
            
        }
        
    }

    
}
