using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Apresentacao : MonoBehaviour
{

    // variavel que controla o carrocel com as imagens
    public GameObject carrocel;

   private int trocaCena = 20;
    // variavel que controla os Slides da Apresentação
    public Image slide;
    public GameObject[] sojaCaindo;

    void Start()
    {
        slide.GetComponent<Image>();
        carrocel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void TrocarSlide()
    {
        
        

        switch (trocaCena)
        {
            case 20:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/02 02");
                Debug.Log("TROCOU PARA A IMAGEM 3");
                carrocel.SetActive(true);
                trocaCena = 31;
                break;
            case 31:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/03 01");
                Debug.Log("TROCOU PARA A IMAGEM 4");
                carrocel.SetActive(false);
                trocaCena = 41;
                break;
            case 41:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/04 01");
                Debug.Log("TROCOU PARA A IMAGEM 4.1");
                trocaCena = 42;
                break;
            case 42:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/04 02");
                Debug.Log("TROCOU PARA A IMAGEM 4.2");
                trocaCena = 43;
                break;
            case 43:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/04 03");
                Debug.Log("TROCOU PARA A IMAGEM 4.3");
                trocaCena = 51;
                break;
            case 51:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/05 01");
                Debug.Log("TROCOU PARA A IMAGEM 5.1");

                for(int i = 0; i < sojaCaindo.Length; i++)
                {
                    sojaCaindo[i].SetActive(true);
                }


                trocaCena = 52;
                break;
            case 52:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/05 02");
                Debug.Log("TROCOU PARA A IMAGEM 5.2");
                trocaCena = 61;
                break;
            case 61:

                for (int i = 0; i < sojaCaindo.Length; i++)
                {
                    sojaCaindo[i].SetActive(false);
                }

                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/06 01");
                Debug.Log("TROCOU PARA A IMAGEM 6.1");
                trocaCena = 71;
                break;
            case 71:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/07 01");
                Debug.Log("TROCOU PARA A IMAGEM 3");
                trocaCena = 81;
                break;
            case 81:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/08 01");
                Debug.Log("TROCOU PARA A IMAGEM 8.1");
                trocaCena = 0;
                break;
            case 0:
                SceneManager.LoadScene(0);
                break;
            default:
                break;
                    
        }

    }

    // fUNÇÃO QUE CONTROLA AS IMAGENS DO CARROCEL COM OS BOTÕES PARA AS DOENÇAS
    public void Carrocel(int d)
    {
        switch (d)
        {
            case 1:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/DOENÇA 01");
                break;
            case 2:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/DOENÇA 02");
                break;
            case 3:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/DOENÇA 03");
                break;
            case 4:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/DOENÇA 04");
                break;
            case 5:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/DOENÇA 05");
                break;
            case 6:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/DOENÇA 06");
                break;
            case 7:
                slide.sprite = Resources.Load<Sprite>("Imagens/TELAS/DOENÇA 07");
                break;
            default:
                break;

        }
        
    }


}
