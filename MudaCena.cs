using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    // variavel que define se o level e o bonus ou nao
    public bool levelBonus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // esta funcao faz um toggle para alternar entre os dois leveis
        // sendo assim se estiver no principal o botao te levara para o bonus ou se estiver no bonus para o comum

        // esta variavel sera global para ambos os leveis e no editor deve marcar como true ou false 
        // se for o level bonus marca ela como true caso contrario como false
        // por padrao ela esta como false entao basta editar apenas no level bonus
        if (!levelBonus)
        {
            // este input esta definido nas opçoes de player preferences input e la o botao definido 
            // Alt Positive Button 
            // acredito eu que isto signifique botao pressionado
            // neste caso defini o botao t 
            if (Input.GetButtonDown("TrocarLevel"))
            {
                // volta para o level bonus
                // no caso deste numero de cena deve ser editado de acordo com o numero setado no projeto ou seja qual level
                // voce quer carregar
                SceneManager.LoadScene(1);
            }
        }
        else
        {
            if (Input.GetButtonDown("TrocarLevel"))
            {
                // volta para o level principal
                // no caso deste numero de cena deve ser editado de acordo com o numero setado no projeto ou seja qual level
                // voce quer carregar
                SceneManager.LoadScene(0);
            }
        }



    }
}
