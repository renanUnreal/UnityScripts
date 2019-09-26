using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChecarEstado : MonoBehaviour
{ 
 public bool completou;
float cronometro;
 public bool game;
private static int pontos;
public int cena;
public float tempo;
 private float tempoDeJogo;
public bool final;
    private float contador;
public GameObject final1;
public GameObject final2;
public bool inicioGame;

 [SerializeField] private TextMesh timeLabel;
 [SerializeField] private TextMesh totalLabel;

    MoveObject2D[] objetos;

void Start()
{
    cronometro = 0;
    completou = false;
    objetos = FindObjectsOfType<MoveObject2D>();
        tempoDeJogo = tempo;

        if (final)
        {
            if (pontos > 9)
            {
                final1.SetActive(true);
                final2.SetActive(false);
            }
            else
            {
                final1.SetActive(false);
                final2.SetActive(true);
            }
        }

        if (inicioGame)
        {
            pontos = 0;
        }

}

void Update()
{
        if (game)
        {
            tempoDeJogo = tempoDeJogo - Time.deltaTime;
            timeLabel.text = "Tempo: " + tempoDeJogo.ToString("f0");
            contador += Time.deltaTime;
            cronometro += Time.deltaTime;
            if (cronometro >= 0.2f)
            { //5Hz
                cronometro = 0;
                int soma = 0;
                for (int x = 0; x < objetos.Length; x++)
                {
                    if (objetos[x].estaConectado)
                    {
                        soma++;
                        pontos = soma;
                        totalLabel.text = "Pontos: " + soma.ToString("f0");
                    }
                }

                if (soma >= objetos.Length)
                {
                    completou = true;
                    mudacena(2);
                }
            }
            if (tempo < contador)
            {
                mudacena(2);
            }
        }

}

   public void mudacena(int x)
    {
       SceneManager.LoadScene(x);
      
        
    }

}