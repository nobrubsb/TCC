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

    //Variáveis responsáveis por direcionar o sprite
    Ray raioParaMouse;
    SpringJoint2D mola;
    Transform ancora;
    float esticadaMaximaQuadrado;

    public SpriteRenderer seta;
    

    private void Awake()
    {
        //Inicialização dos objetos antes de tudo
        corpoFisico = GetComponent<Rigidbody2D>();
        mola = GetComponent<SpringJoint2D>();
        seta = GetComponent<SpriteRenderer>();
        
    }

    
    void Start() {

        objetoCorpo = new Corpo();
        objetoCorpo.rigidBody = corpoFisico;
        objetoCorpo.mola = mola;
        objetoCorpo.ancora = ancora;

        //Controle da barra de força
        forcaMaxima = 1.0f;
        incremento = 0.01f;
        forcaAtual = 0.0f;
        velocidadeMaxima = 30.0f;

        //Objeto ancora conecta com a mola do objeto;
        objetoCorpo.ancora = objetoCorpo.mola.connectedBody.transform;
        raioParaMouse = new Ray(objetoCorpo.ancora.position, Vector2.zero);

        //Valor maximo para esticada
        esticadaMaximaQuadrado = valorVelocidadeLancamento() * valorVelocidadeLancamento();

        seta.enabled = false;
        
    }


    void Update () {
	
        if(toque == true)
        {
            ArrastarCorpo();
            verificaForca();
        }
        
	}

    private void OnMouseDown()
    {
        toque = true;
        Debug.Log("Tocou!");
        seta.enabled = true;
        
    }
    private void OnMouseUp()
    {

        toque = false;
        Debug.Log("Soltou");
        seta.enabled = false;
        print(valorVelocidadeLancamento());
        
    }

    void ArrastarCorpo()
    {
        Vector3 mouseParaMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Movimenta a bola na tela em todas as posições
        //objetoCorpo.posX = mouseParaMundo.x;
        //objetoCorpo.posY = mouseParaMundo.y;
        //objetoCorpo.posZ = mouseParaMundo.z;
        //Vector3 posicaoObjeto = new Vector3(objetoCorpo.posX, objetoCorpo.posY, objetoCorpo.posZ + 11.0f);
        //transform.position = posicaoObjeto;


        //
        Vector2 ancoraParaMouse = mouseParaMundo - objetoCorpo.ancora.position;

        
        if (ancoraParaMouse.sqrMagnitude > esticadaMaximaQuadrado)
        {
            raioParaMouse.direction = ancoraParaMouse;
            mouseParaMundo = raioParaMouse.GetPoint(valorVelocidadeLancamento());
        }


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