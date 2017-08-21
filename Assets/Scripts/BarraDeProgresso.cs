using UnityEngine;
using System.Collections;

public class BarraDeProgresso : MonoBehaviour {
    public GameObject Barra;
    // Use this for initialization
    void Start () {
        Barra.transform.position = new Vector3(6.5f, -2f, 0);
        Barra.transform.localScale = new Vector3(1, 0, 1);
    }

    // Update is called once per frame
    void Update () {
        Barra.transform.position = new Vector3(6.5f, (float)(GerenciadorPalavras.progressoPercentual *-2f)/(float)100f, 0);
        Barra.transform.localScale = new Vector3(1, (float)GerenciadorPalavras.progressoPercentual/(float)100f, 1);
    }
}
