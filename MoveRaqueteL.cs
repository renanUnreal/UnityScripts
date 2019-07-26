using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRaqueteL : MonoBehaviour
{

    public float velocidade;
    private Rigidbody2D racket;
    // esta variavel esta ai para definir os botoes para cada player
    public string axis;

    // Start is called before the first frame update
    void Start()
    {
        // passando um rigidbody para uma variavel para nao precisar fazer isto toda hora
        racket = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        // mvimentando na vertical os players
        float moviment = Input.GetAxisRaw(axis);
        racket.velocity = new Vector2(0, moviment) * velocidade;
    }
}
