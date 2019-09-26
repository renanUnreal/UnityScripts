using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misturador : MonoBehaviour
{ 
    public GameObject[] pecas;
    public Vector3[] posicao;

    public int valorMin = 0;
    public int valorMax = 14;
    private int contador = 0;
    public int numeroSorteado;
    [Space(20)]
    public List<int> numerosJaSorteados = new List<int>();

    public List<int> numeros = new List<int>();

    private void Awake()
    {
        for (int x = valorMin; x <= valorMax; x++)
        {
            numeros.Add(x);
        }
    }


    void Start()
    {
      

               

                
               


       
        }

  

    // Update is called once per frame
    void Update()
    {
        if (numeros.Count > 0)
        {
            GerarNumerosAleatorios();
          
        }
        if(contador == valorMax + 1)
        {
            
            ordenar();
            contador++;
        }
        
    }


    void GerarNumerosAleatorios()
    {
        int indice = Random.Range(0, numeros.Count);
        
        numeroSorteado = numeros[indice];
        numerosJaSorteados.Add(numeroSorteado);
        numeros.Remove(numeros[indice]);
        // Debug.Log(numerosJaSorteados[contador]);
       
         
            contador++;
   
       
    }

    void ordenar()
    {
        for (int x = valorMin; x <= valorMax; x++)
        {
            pecas[x].transform.position = posicao[numerosJaSorteados[x]];
        }
    }
}
