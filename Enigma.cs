using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//   ESTE SCRIPT DEVE IR DENTRO DE UM COMPONENT TEXT NA UI PARA QUE NAO HAJA CONFLITO
// BASTA COLOCA-LO DENTRO DE TODAS AS FASES QUE O SISTEMA ERA FUNCIONAR
// A FUNCAO SAVE DEVEM IR NAS RESPOSTAS CORRETAS
// A FUNCAO LOAD PARA CARREGAR DEVE IR NO BOTAO INICIAR DO MENU PRINCIPAL

// BASTA AGORA CRIAR UMA ANIMAÇAO DE PISCAR OU ACERTO PARA AS RESPOSTAS CORRETAS
// ISTO DEVE SER FEITO COM ANIMATION E ANIMCONTROLLER O


public class Enigma : MonoBehaviour
{
    // CRIANDO A VARIAVEL PARA A PERGUNTA 
    // A VARIAVEL DE PERGUNTA TEM DE SER ESCRITA TODA EM UPCASE
    public string pergunta = "";
    // CRIANDO A VARIAVEL PARA CONVERTER A RESPOSTA EM UPCASE
    private string convertUp = "";
   //  CRIANDO A VARIAVEL PARA A RESPOSTA QUE SERA CONVERTIDA E DEPOIS COMPARADA
    private string resposta = "";

      // CRIANDO A VARIAVEL QUE IRA DEFINIR QUAL SERA A FASE CHAMADA
    private int fase = 0;

    // SETANDO TEXTO ESTE DEVE SER TROCADO PARA VARIAVEL PERGUNTA
   Text txtPergunta;

        
        
    


    // Start is called before the first frame update
    void Start()
    {
        pergunta = "esTou testando Esto";
        resposta = "ESTOU TESTANDO ESTO";
         // convertendo a pergunta
        convertUp = pergunta.ToUpper();
        Debug.Log(convertUp);

        //Setar texto da pergunta aqui
        txtPergunta = GetComponent<Text>();
        txtPergunta.text = fase.ToString();

        // comparando a resposta e setando o valor de ponto 

        if(convertUp == resposta)
        {
            // aqui deve dar ponto e fazer a chamada para nova fase ou questao
            Debug.Log("Verdadeiro");
        }
        else
        {
            // aqui ou chama a nova questao e nao marca ponto
            // ou apenas nao faz nada
            Debug.Log("False");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // FUNCAO PARA CHAMAR A CENA
    public void TrocaPergunta()
    {
        SceneManager.LoadScene(0);
        fase++;
        Debug.Log(fase);
        SavePergunta();
    }


    // função para salvar a pergunta da vez
    public void SavePergunta()
    {
        fase++;
        PlayerPrefs.SetInt("fase", fase);

    }

    // funcao para carregar a pergunta da vez
    public void LoadPergunta()
    {
        fase = PlayerPrefs.GetInt("fase", fase);
        // checando se esta mantido o save
        txtPergunta.text = fase.ToString();
    }

}
