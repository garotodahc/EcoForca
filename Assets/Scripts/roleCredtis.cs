using UnityEngine;
using System.Collections;

public class roleCredtis : MonoBehaviour {


     float velocidade = 0.5f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



        transform.Translate(0,velocidade * Time.deltaTime,  0);

        if (transform.position.y > 6f)
        {
            Application.LoadLevel("optionsScene");
        }
	}
}
