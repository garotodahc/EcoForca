using UnityEngine;
using System.Collections;

public class ItensPanel : MonoBehaviour {
    public GameObject ItemLiberado;

    // Use this for initialization
    void Start(){
        ItemLiberado.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
    }

    public void Recomecar() {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Menu()
    {
        Application.LoadLevel("Menuscene");
    }
}
