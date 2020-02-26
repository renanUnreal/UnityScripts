using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    

    public GameObject dragObject;
    public Material material;
    public float larguraLinha;
    public int extenLinha;
    public bool t = false;
    public Text txt;
    private bool semOBJ;
    

    void Start()
    {
        
       LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        //lineRenderer.material = material;
        //lineRenderer.startColor = Color.green;
        //lineRenderer.endColor = Color.green;
        // lineRenderer.startWidth = larguraLinha;
        // lineRenderer.endWidth = larguraLinha;
        // lineRenderer.positionCount = extenLinha;
      
      
    }

    // Update is called once per frame
    void Update()
    {
        

        DragButton();
    }



    

    public void Teste()
    {
        if (t == false)
        {
            t = true;
          
        }
        else
        {
            t = false;
            semOBJ = true;
           
        }
        
       
       
           
        
    }




    public void DragButton()
    {
        if (t)
        {
            Vector3 pontoFinalDoLAser = transform.position + transform.forward * extenLinha;

            RaycastHit pontodeColisao;
            if (Physics.Raycast(transform.position, transform.forward, out pontodeColisao, extenLinha))
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, pontodeColisao.point);
                Debug.Log("RayRayRay");

                // dragObject  =  pontodeColisao.collider.gameObject;
                //  dragObject.transform.position = testevetor;

                if (pontodeColisao.transform.CompareTag("Drag"))
                {
                    
                    Debug.Log("pegou");
                    if (semOBJ)
                    {
                        dragObject = pontodeColisao.transform.gameObject;
                        semOBJ = false;
                    }
                    else
                    {
                        Vector3 testevetor = new Vector3(dragObject.transform.position.x, pontodeColisao.point.y, pontodeColisao.point.z);
                        dragObject.transform.position = testevetor;

                    }
                    
                }
                else
                {
                    Debug.Log("Não Viu!");
                }


            }
            else
            {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, pontoFinalDoLAser);
            }
        }
        else
        {

        }
        
      
}


 
}
