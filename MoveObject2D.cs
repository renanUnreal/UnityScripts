using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//requer um boxCollider2D
[RequireComponent(typeof(Rigidbody2D))]
public class MoveObject2D : MonoBehaviour
{
    Vector3 posicInicial;
    Vector3 posicDestino;
    Vector3 vetorDirecao;
    Rigidbody2D _rigidbody2D;
    bool estaArrastando;
    float distancia;
    public bool acerto = false;
    private Vector2 origem;

    [HideInInspector]
    public bool estaConectado;

    public Vector2 parou;

    [Range(1, 15)]
    public float velocidadeDeMovimento = 10;
    [Space(10)]
    public Transform conector;
    [Space(10)]
    public Transform conectorP;
    [Range(0.1f, 20.0f)]
    public float distanciaMinimaConector = 0.5f;

    public GameObject animErrar;
    public GameObject animAcertar;

    void Start()
    {
        _rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.mass = 2.0f;
        StartCoroutine(Sortear());
    }

    void OnMouseDown()
    {
        posicInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody2D.gravityScale = 0;
        estaArrastando = true;
        estaConectado = false;
    }

    void OnMouseDrag()
    {
        posicDestino = posicInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicInicial.z = 2;
        vetorDirecao = posicDestino - transform.root.position;
        _rigidbody2D.velocity = vetorDirecao * velocidadeDeMovimento;
        _rigidbody2D.mass = 0.00001f;
    }

    void OnMouseUp()
    {
        _rigidbody2D.gravityScale = 0;
        estaArrastando = false;
        _rigidbody2D.velocity = parou;
        _rigidbody2D.mass = 2.0f;

        StartCoroutine(Pausa());
        StartCoroutine(AnimErro());


    }

    void FixedUpdate()
    {
        /// checa se esta no lugar certo 
        if (!estaArrastando && !estaConectado)
        {
            distancia = Vector2.Distance(transform.root.position, conector.position);
            if (distancia < distanciaMinimaConector)
            {
                /// aqui pode ser criada a condição para retornar para a posição inicial
                _rigidbody2D.gravityScale = 0;
                _rigidbody2D.mass = 0.00001f;

                _rigidbody2D.velocity = Vector2.zero;
                transform.root.position = Vector2.MoveTowards(transform.root.position, conector.position, 0.2f);
            }
            if (distancia < 0.2f)
            {


                estaConectado = true;
                transform.root.position = conectorP.position;
                transform.root.localScale = conectorP.localScale;
                StartCoroutine(AnimAcerto());
                _rigidbody2D.mass = 2.0f;



            }
        }





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pecas")
        {


        }

    }
    IEnumerator Pausa()
    {

        
        yield return new WaitForSeconds(0.7f);
        if (!estaConectado)
        {

            transform.root.position = origem;
            

        }




      
    }

    IEnumerator Sortear()
    {
        yield return new WaitForSeconds(0.3f);
        origem = transform.position;

    }

    IEnumerator AnimErro()
    {
        yield return new WaitForSeconds(0.5f);
        if (!estaConectado) {
            animErrar.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            animErrar.SetActive(false);
        }
        

    }

    IEnumerator AnimAcerto()
    {
       
            animAcertar.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            animAcertar.SetActive(false);

    }
}

