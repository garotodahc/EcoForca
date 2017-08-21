using UnityEngine;
using System.Collections;

public class avisosScript : MonoBehaviour {

    public GameObject[] aviso;
    public float tempo ;
    public int contador = 0;
    public bool pausa = true;
    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        tempo = (tempo - Time.deltaTime) ;

        if (tempo <= 0)
        {
           
            contador = contador + 1;
            for (int i = 0; i< aviso.Length; i++)
            {
                if (contador == 1)
                {
                    Instantiate(aviso[0], new Vector3(0.0f, 0.0f, -5.1f), Quaternion.identity);
                 
                }

                if (contador == 2)
                {
                    Instantiate(aviso[1], new Vector3(0.0f, 0.0f, -5.1f), Quaternion.identity);
                  
                }
                if (contador == 3)
                {
                    Instantiate(aviso[2], new Vector3(0.0f, 0.0f, -5.1f), Quaternion.identity);
                   
                }
                
            }
           
            tempo = 2f;
            if (contador >3)
            {
                Destroy(gameObject);
            }
           
        }

        Debug.Log("contador: " + contador);
        Debug.Log("Tempo: " + tempo);
    }


    /*void instacia()
    {
        

        if (contador == 1)
        {
            Instantiate(aviso[0], new Vector3(0.0f,0.0f, -5.1f), Quaternion.identity);

            if (GameObject.FindWithTag("Aviso").transform.position.x <= -0.1f)
            {
                OnUnPaused();
                Destroy(GameObject.Find("aviso01(Clone)"));
            }

        }
        if (contador == 2)
        {
            Instantiate(aviso[1], new Vector3(0.0f, 0.0f, -5.1f), Quaternion.identity);

            if (GameObject.FindWithTag("Aviso").transform.position.x <= -0.1f)
            {
                OnUnPaused();
                Destroy(GameObject.Find("aviso02(Clone)"));
            }

        }
        if (contador == 3)
        {
            Instantiate(aviso[2], new Vector3(0.0f, 0.0f, -5.1f), Quaternion.identity);

            if (GameObject.FindWithTag("Aviso").transform.position.x <= -0.1f)
            {
                OnUnPaused();
                Destroy(GameObject.Find("aviso03(Clone)"));
            }
        }
       


    }*/


  


    
}
