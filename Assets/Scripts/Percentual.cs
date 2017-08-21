using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Percentual : MonoBehaviour {
    public Text meuTexto;
    public Text minhasTentativas;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        meuTexto.text = (string)GerenciadorPalavras.progressoPercentual.ToString("F2");
        minhasTentativas.text = (string)GerenciadorPalavras.vidas.ToString();
    }
}
