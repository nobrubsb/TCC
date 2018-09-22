using UnityEngine;
using System.Collections;

public class Corpo {


    public Rigidbody2D rigidBody { get; set; }
    public SpringJoint2D mola { get; set; }
    public Transform ancora { get; set; }
    bool estadoJogador { get; set; }
    public float velocidadePersonagem { get; set; }
    public string nomeJogador { get; set; }
    public float massa { get; set; }
    public float posX { get; set; }
    public float posY { get; set; }
    public float posZ { get; set; }


    public Corpo()
    {

    }
    public Corpo(Rigidbody2D rigid, SpringJoint2D junta, Transform anchor, bool estado, float velo, string nome, float peso, 
        float posicaoX, float posicaoY, float posicaoZ)
    {
        
        rigidBody = rigid;
        mola = junta;
        ancora = anchor;
        estadoJogador = estado;
        velocidadePersonagem = velo;
        nomeJogador = nome;
        massa = peso;
        posX = posicaoX;
        posY = posicaoY;
        posZ = posicaoZ;
    }
    
}
