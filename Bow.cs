using System.Collections;
using UnityEngine;

/*
 No tutorial ele cria um sistema de Bow/Arrow que por fim a static mesh do Bow vai para o modelo do MotionController
 oque Acredito que para fazer um sistema de troca de armas como no caso estou imaginando criar um sistema de magias
 e aplicar o arco e flechas como uma magia do personagem seria apenas criar um componente que troque o renderer do staticmesh
 da mao do personagem neste caso seria criar um Instantiate e dar spawn no prefab da Bow em questão neste script

    obs: para remover um componente de um determinado PREFAB basta clicar na raiz dele em cena e selecionar a opção
    unpackd prefab que ele abre o prefab para ser editado na cena
     coloque o arco no controller Right e o controller do GameObject Input da cena tem que ser o Left e vice-versa
     este Script apenas cria a dinamica do arco nao dispara a flesha ainda mas ja da para identificar que basta fazer a troca de PREFABS
     para funcionar corretamente o sistema de MAGIAS do personagem
     
     */









public class Bow : MonoBehaviour
{
    [Header("Assets")]
    // arrastar aqui o obj que sera a Flecha
    public GameObject m_ArrowPrefabs = null;

    [Header("Bow")]
    public float m_GrabThershold = 0.15f;
    // ponto de comparação inicial ou seja onde o controle faz o pickup do socket
    // este é umobjeto lincado na corda que define onde ela esta quando esta solta
    public Transform m_Start = null;
    // este é um object lincado no socket da corda que define ate onde ela pode ser puxada
    // ponto de comparação final ou seja onde o controle faz o drop do socket
    public Transform m_End = null;
    // define o GameObject que estara sendo pego pelo controller
    // este item esta no PREFAB do arco e um GameObject lincado na corda do arco
    public Transform m_Socket = null;

    // marca o movimento da mao
    private Transform m_PullingHand = null;
    // marca qual a flecha atual
    private Arrow m_CurrentArrow = null;
    // define o animator de animação do arco sendo puxado
    private Animator m_Animator = null;

    // veloidade de movimento da flecha solta
    private float m_PullValue = 0.0f;


    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(CreateArrow(0.0f));
    }



    private void Update()
    {
        if (!m_PullingHand || !m_CurrentArrow)
        {
            return;
        }

        m_PullValue = CalculatePull(m_PullingHand);
        m_PullValue = Mathf.Clamp(m_PullValue, 0.0f, 1.0f);

        m_Animator.SetFloat("Blend", m_PullValue);
    }

    private float CalculatePull(Transform pullHand)
    {
        Vector3 direction = m_End.position - m_Start.position;
        float magnitude = direction.magnitude;

        direction.Normalize();
        Vector3 difference = pullHand.position - m_Start.position;
       

        return Vector3.Dot(difference, direction) / magnitude;
    }


    private IEnumerator CreateArrow(float waitTime)
    {
        // wait
        yield return new WaitForSeconds(waitTime);

        // create, child
        GameObject arrowObject = Instantiate(m_ArrowPrefabs, m_Socket);



        // orient
        arrowObject.transform.localPosition = new Vector3(0, 0, 0.425f);
        arrowObject.transform.localEulerAngles = Vector3.zero;



        // set

        m_CurrentArrow = arrowObject.GetComponent<Arrow>();
    }


    public void Pull(Transform hand)
    {
        float distance = Vector3.Distance(hand.position, m_Start.position);
        if (distance > m_GrabThershold)
        {
            return;
        }
        m_PullingHand = hand;
    }

    public void Release()
    {
        if (m_PullValue > 0.25f)
        {
            FireArrow();
        }

        m_PullingHand = null;
        m_PullValue = 0.0f;
        m_Animator.SetFloat("Blend", 0);
        if (!m_CurrentArrow)
        {
            StartCoroutine(CreateArrow(0.25f));
        }
    }

    private void FireArrow()
    {

        m_CurrentArrow.Fire(m_PullValue);
        m_CurrentArrow = null;
    }

}
