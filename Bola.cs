using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // fazendo a bola mudar de posição ou angulo ou ser rebatida de lado dependendo da posição que toca na rackete esta funcao hitFactor e responsavel por isto e bem legal rss
        if (col.gameObject.name == "Racket_Esquerda")
        {
            // esta função calcula a posicao da raquete em relacao a bola ou da bola em relacao a raquete e passa um valor 1 ou -1 ou 0
            // esta variavel y recebe o valor da funcao float hitFactor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            // aqui eu atribuo ele normalizando em uma variavel para ser adcionada a velocidade do rigidbody para que a bola receba o efeito de mudar de direcao vertical
            // o valor de x tem que ser positivo para uma rackete e negativo para outra para nao perder a velocidade continua na horizontal
            // esta movimenta a bolinha para a Direita da Tela
            Vector2 direcao = new Vector2(1, y).normalized;

            // aqui eu aplico a variavel de direcao para mudar a velocidade do rigidbody
            GetComponent<Rigidbody2D>().velocity = direcao * velocidade;

            Debug.Log("Esquerda");
        }

        if(col.gameObject.name == "Racket_Direita")
        {


            // esta função calcula a posicao da raquete em relacao a bola ou da bola em relacao a raquete e passa um valor 1 ou -1 ou 0
            // esta variavel y recebe o valor da funcao float hitFactor
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            // aqui eu atribuo ele normalizando em uma variavel para ser adcionada a velocidade do rigidbody para que a bola receba o efeito de mudar de direcao vertical
            // o valor de x tem que ser positivo para uma rackete e negativo para outra para nao perder a velocidade continua na horizontal
            // esta movimenta a bolinha para a Esquerda da Tela
            Vector2 direcao = new Vector2(1, y).normalized;

            // aqui eu aplico a variavel de direcao para mudar a velocidade do rigidbody
            GetComponent<Rigidbody2D>().velocity = direcao * velocidade;


            Debug.Log("Direita");
        }
    }

    // funcao que pega os valores da colisao com a raquete
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight ;
    }

}
