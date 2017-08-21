using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public GameObject ItemLiberado;
    public int indexItem;

    // Use this for initialization
    void Start () {
        ItemLiberado.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        if (GerenciadorPalavras.controleItensLiberados[indexItem])
        {
            ItemLiberado.SetActive(true);
        }
        else {
            ItemLiberado.SetActive(false);
        }
    }
}
