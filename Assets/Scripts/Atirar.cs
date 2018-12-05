using UnityEngine;
using System.Collections;

public class Atirar : MonoBehaviour
{

    //Scripts e objetos
    ArrastaBola meuScriptBola;
    ControleSeta meuScriptSeta;
    UnityStandardAssets.Utility.AutoMoveAndRotate meuScriptMovimento;
    public GameObject bola;
    public GameObject seta;

    Rigidbody2D rbBola;


    private void Awake()
    {
        rbBola = GetComponent<Rigidbody2D>() as Rigidbody2D;
    }

    void Start()
    {

        //Acessando variáveis dos scripts
        meuScriptBola = (ArrastaBola)bola.GetComponent(typeof(ArrastaBola));
        meuScriptSeta = (ControleSeta)seta.GetComponent(typeof(ControleSeta));
        meuScriptMovimento = (UnityStandardAssets.Utility.AutoMoveAndRotate)seta.GetComponent(typeof(UnityStandardAssets.Utility.AutoMoveAndRotate));


    }

    public void Disparar()
    {

        rbBola.AddForce(new Vector2(meuScriptSeta.rbSeta.transform.position.x, meuScriptSeta.rbSeta.transform.position.y) 
            * (meuScriptBola.valorVelocidadeLancamento()), ForceMode2D.Impulse);

        Debug.Log("Atirou!");

    }


}