using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // comando da biblioteca fisica da unity que pede ponto de saida, direção e distancia de projeção
        // raycasthit cria o ponto da colisao do raycast
        RaycastHit pontoDeColisao;
        
        if(Physics.Raycast(transform.position, transform.forward, out pontoDeColisao, 8))
        {
            Debug.Log(pontoDeColisao.point);
            Debug.DrawLine(transform.position, pontoDeColisao.point);
            if (Input.GetMouseButtonDown(0))
            {
                // cria um objeto na cena ou da o spawn como e chamado na unreal e precisa de uma variavel de referencia do objeto
                Instantiate(objeto, pontoDeColisao.point - transform.forward * 0.1f, Quaternion.Euler(pontoDeColisao.normal));
            }

            // identifica o objeto que esta sendo colidido o raycast quase que como um event hit da ue4 e se identificar ele troca a cor do objeto
            if (pontoDeColisao.transform.gameObject.GetComponent<MeshRenderer>() != null){
                pontoDeColisao.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                
            }
        }
        else
        {
            Debug.Log("nao esta colidindo");
        }
    }
}
