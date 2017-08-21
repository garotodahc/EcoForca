using UnityEngine;
using System.Collections;

public class PainelInformativo : MonoBehaviour {
    public GameObject itemDoCenario;
    public int indexItem;
    // Use this for initialization
    void Start () {
        itemDoCenario.transform.position = new Vector3(1000,1000,0);
    }
	
	// Update is called once per frame
	void Update () {
        if (GerenciadorPalavras.exibirInformativo[indexItem])
        {
            itemDoCenario.transform.position = new Vector3(0,0,0);
        }
        else {
            itemDoCenario.transform.position = new Vector3(1000, 1000, 0);
        }
    }
}
