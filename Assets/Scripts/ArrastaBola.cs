using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrastaBola : MonoBehaviour {

    //Variável de verificação
    public bool toque;
    //Objeto da Classe
    public Corpo objetoCorpo;
    //Componente do front-end responsável pelo físico do sprite
    Rigidbody2D corpoFisico;

    //Variáveis responsáveis para o controle da barra de força
    public float forcaMaxima { get; set;}
    public float forcaAtual { get; set; }
    public float incremento { get; set; }
    public Slider barraForca;
    public float velocidadeMaxima {get; set;}

    private void Awake()
    {
       
    }

    
    void Start() {

     

        //Controle da barra de força
        forcaMaxima = 1.0f;
        incremento = 0.01f;
        forcaAtual = 0.0f;
        velocidadeMaxima = 30.0f;

        
    }


    void Update () {
	
        if(toque == true)
        {
            //ArrastarCorpo();
            verificaForca();
        }
        
	}

    private void OnMouseDown()
    {
        toque = true;
        Debug.Log("Tocou!");
        
    }
    private void OnMouseUp()
    {

        toque = false;
        Debug.Log("Soltou");
        print(valorVelocidadeLancamento());
        
    }

    void verificaForca()
    {

        forcaAtual += incremento;
        if (forcaAtual >= forcaMaxima || forcaAtual < 0)
            incremento *= -1;
        barraForca.value += incremento;
    }

    float valorVelocidadeLancamento()
    {

        float velocidadeLancamento = forcaAtual * velocidadeMaxima; ;
        return velocidadeLancamento;
    }


  

}