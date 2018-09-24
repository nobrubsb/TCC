using UnityEngine;
using System.Collections;

public class Direcional : MonoBehaviour {

    public GameObject alvo;

    public float velocidadeRotacao;
    public float velocidadeMovimento;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Localiza();
	
	}


    //Faz com que a bola siga o alvo
    void Localiza()
    {
        transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, 
            velocidadeMovimento * Time.deltaTime);

        Vector3 vetorParaAlvo = alvo.transform.position - transform.position;
        float angulo = Mathf.Atan2(vetorParaAlvo.y, vetorParaAlvo.x) * Mathf.Rad2Deg;
        Quaternion qt = Quaternion.AngleAxis(angulo, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qt, Time.deltaTime * velocidadeRotacao);
    }
}
