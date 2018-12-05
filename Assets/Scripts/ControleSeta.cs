using UnityEngine;
using System.Collections;

public class ControleSeta : MonoBehaviour
{

    //Renderiza a seta
    SpriteRenderer renderizar;

    //Acessa o script Arrastar
    ArrastaBola meuScriptArrastar;
    public GameObject bola;
    public GameObject seta;
    public Rigidbody2D rbSeta;
    public Rigidbody2D rbBola;
    UnityStandardAssets.Utility.AutoMoveAndRotate rotateSeta;

    public Transform transformSeta;

    float velocidadeInicial = 0.0f;
    float angulo = 0.0f;
    const float gravidade = 10.0f;
    float seno = 0.0f;
    float cosseno = 0.0f;
    float momentoLancamento = 0.0f;
    bool isMoving = false;
    bool hasMouseOver = false;


    float velocidadeBola;
    Vector3 posicaoBola;
    Vector2 novaPosicaoBola;
    Vector2 vetorVelocidade;


    float veloX, veloY, tempo;


    private void Awake()
    {
        renderizar = GetComponent<SpriteRenderer>();
    //    rbSeta = GetComponent<Rigidbody2D>();
    //    rbBola = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        //Recebendo atributos de outro script
        meuScriptArrastar = (ArrastaBola)bola.GetComponent(typeof(ArrastaBola));
        rotateSeta = (UnityStandardAssets.Utility.AutoMoveAndRotate)seta.GetComponent(typeof(UnityStandardAssets.Utility.AutoMoveAndRotate));
    }

    // Update is called once per frame
    private void Update()
    {

        verificaObjeto();
        if (isMoving)
        
         MovimentoBola();
        // lancamentoOblicuo();

    }

    //Verifica o toque e renderiza o objeto na cena
    void verificaObjeto()
    {

        if (meuScriptArrastar.toque == true)
        {
            renderizar.enabled = true;
            rbSeta.isKinematic = false;
            rotateSeta.enabled = true;
            rotateSeta.moveUnitsPerSecond.value.y = 75.0f;
            hasMouseOver = true;
        }
        else
        {
            renderizar.enabled = false;
            rbSeta.isKinematic = true;
            rotateSeta.enabled = false;
            rotateSeta.moveUnitsPerSecond.value.y = 0.0f;
        }

        if (hasMouseOver && !meuScriptArrastar.toque)
        {
            isMoving = true;
            hasMouseOver = false;
            meuScriptArrastar.rbBola.isKinematic = false;

        }

    }

    void MovimentoBola()
    {

        velocidadeBola = meuScriptArrastar.valorVelocidadeLancamento();
        rbBola.AddForce(new Vector2(rbSeta.transform.position.x, rbSeta.transform.position.y) * (velocidadeBola * Time.deltaTime * velocidadeBola), ForceMode2D.Impulse);



        //veloX = meuScriptArrastar.valorVelocidadeLancamento();
        //veloY = meuScriptArrastar.valorVelocidadeLancamento();

        //posicaoBola.x = rbBola.transform.position.x;
        //posicaoBola.y = rbBola.transform.position.y;
        //posicaoBola.z = rbBola.transform.position.z;
        //transform.position = posicaoBola;

        //tempo = tempo * Time.deltaTime;

        //if (posicaoBola.y < 170.0f || posicaoBola.y > -175.0f)
        //{
        //    posicaoBola.y = rbSeta.transform.position.y + veloY * tempo - 4.9f * tempo * tempo;
        //    posicaoBola.x = rbSeta.transform.position.x + veloX * tempo;
        //}




        //float angulo = Angle(rbSeta.transform.position);
        //posicaoObjetoSeta.transform.localEulerAngles.z;

        //if (angulo < 0)
        //{
        //    angulo = (angulo * -1) + 180;
        //}

        //carregaValoresLancamento(angulo, velocidadeBola);





        ////Bloco de códico de movimento único, sem calculo físico
        //velocidadeBola = meuScriptArrastar.valorVelocidadeLancamento();
        //vetorVelocidade = new Vector2(velocidadeBola, velocidadeBola);
        //novaPosicaoBola = (seta.transform.position - bola.transform.position).normalized;
        //rbBola.MovePosition(novaPosicaoBola * velocidadeBola);



        //velocidadeBola = meuScriptArrastar.valorVelocidadeLancamento();
        //vetorVelocidade.x = velocidadeBola;
        //vetorVelocidade.y = velocidadeBola;
        

    }


    //void carregaValoresLancamento(float angulo, float velocidade)
    //{
    //    this.velocidadeInicial = velocidade;
    //    this.angulo = angulo;
    //    this.seno = Mathf.Sin(angulo);
    //    this.cosseno = Mathf.Cos(angulo);
    //    this.posicaoBola = rbBola.transform.position;
    //    this.momentoLancamento = Time.time;
    //}

    //void lancamentoOblicuo()
    //{
    //    float tempoLancamento = Time.time - momentoLancamento;
    //    float posiX = this.velocidadeInicial * this.cosseno * tempoLancamento;
    //    // velocidade inicial em relação ao seno
    //    float velocidade = this.velocidadeInicial * this.seno;
    //    //velocidade atual
    //    float velocidadeAtual = velocidade - (gravidade * tempoLancamento);
    //    //posição de Y
    //    float posiY = velocidadeAtual * tempoLancamento - (gravidade * (Mathf.Pow(tempoLancamento, 2.0f) / 2));

    //    rbBola.transform.Translate(posicaoBola.x + posiX, posicaoBola.y, 0f);
    //    //rbBola.AddForce(posicaoBola.x + posiX, ForceMode2D.Impulse);

    //}

    //public float Angle(Vector2 vetor)
    //{
    //    float anguloFinal = 0.0f;
    //    if (vetor.y < 0)
    //    {
    //        anguloFinal = 360 - (Mathf.Atan2(vetor.y, vetor.x) * Mathf.Rad2Deg * -1);
    //    }
    //    else
    //    {
    //        anguloFinal = Mathf.Atan2(vetor.y, vetor.x) * Mathf.Rad2Deg;
    //    }
    //    return anguloFinal;
    //}

}