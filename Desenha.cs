using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Desenha : MonoBehaviour
{
    /*
    public Gradient corLaser;
    public Color luzColor = Color.green;
    public int distanciaDoLaser = 50;
    public float larguraInicial = 0.02f, larguraFinal = 0.1f;
    private GameObject luzColisao;
    private Vector3 posicLuz;
    public Material materialLaser;


    
    // Start is called before the first frame update
    void Start()
    {
        // tirar depois
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        luzColisao.GetComponent<Light>().intensity = 8;
        luzColisao.GetComponent<Light>().bounceIntensity = 8;
        luzColisao.GetComponent<Light>().range = larguraFinal * 2;
        luzColisao.GetComponent<Light>().color = luzColor;
        posicLuz = new Vector3(0, 0, larguraFinal);

        
        //
        LineRenderer linha = gameObject.AddComponent<LineRenderer>();
        linha.material = materialLaser;
        linha.colorGradient =  corLaser;
        linha.startWidth = larguraInicial;
        linha.endWidth = larguraFinal;
        linha.positionCount = 2;
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pontoFinalDoLaser = transform.position + transform.forward * distanciaDoLaser;
        RaycastHit pontoDeColisao;
        if(Physics.Raycast(transform.position, transform.forward, out pontoDeColisao, distanciaDoLaser))
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, pontoDeColisao.point);
            luzColisao.transform.position = (pontoDeColisao.point - posicLuz);
        }
        else
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, pontoFinalDoLaser);
            luzColisao.transform.position = pontoFinalDoLaser;
        }
    }

    */

    public Gradient corLaser;
    public Color luzColor = Color.green;
    public int distanciaDoLaser = 50;
    public float larguraInicial = 0.02f, larguraFinal = 0.1f;
    private GameObject luzColisao;
    private Vector3 posicLuz;
    public Material materialLaser;
    public GameObject m23;
    public GameObject[] origem;
    private static Laser l;
    private bool estaConectado;
    private float distancia;
    public float distanciaMaxima;
    public int acerto;
    private Vector3 inicial;
    public GameObject laser;
    

    // Start is called before the first frame update
    void Start()
    {
        // tirar depois
        luzColisao = new GameObject();
        luzColisao.AddComponent<Light>();
        luzColisao.GetComponent<Light>().intensity = 8;
        luzColisao.GetComponent<Light>().bounceIntensity = 8;
        luzColisao.GetComponent<Light>().range = larguraFinal * 2;
        luzColisao.GetComponent<Light>().color = luzColor;
        posicLuz = new Vector3(0, 0, larguraFinal);

        inicial = transform.position;
        estaConectado = false;
        //
        LineRenderer linha = gameObject.AddComponent<LineRenderer>();
        linha.material = materialLaser;
        linha.colorGradient = corLaser;
        linha.startWidth = larguraInicial;
        linha.endWidth = larguraFinal;
        linha.positionCount = 2;
        linha.startWidth = larguraInicial;
        linha.endWidth = larguraFinal;

        // checando se o botao está selecionado
        laser.GetComponent<Laser>();

    }

    // Update is called once per frame
    void Update()
    {
        

        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, m23.transform.position);

      

    }

    private void FixedUpdate()
    {
        if (!laser.GetComponent<Laser>().t && !estaConectado)
        {
            distancia = Vector3.Distance(transform.transform.position, origem[acerto].transform.position);
            if (distancia < distanciaMaxima)
            {
                transform.position = Vector3.MoveTowards(transform.position, origem[acerto].transform.position, 0.002f);

               
                Debug.Log("Não");
            }
            if(distancia > distanciaMaxima)
            {
                transform.position = Vector3.MoveTowards(transform.position, inicial, 0.02f);
               
            }
            if (distancia < 0.01f)
            {
                Debug.Log("Sim");
                
                transform.position = origem[acerto].transform.position;
                
            }
            
        }
    }
}
