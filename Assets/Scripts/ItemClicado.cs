using UnityEngine;
using System.Collections;

public class ItemClicado : MonoBehaviour
{
    public GameObject ItemLiberado;
    public GameObject panelScrollItens;
    public int indexItem;

    // Use this for initialization
    void Start()
    {
        ItemLiberado.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GerenciadorPalavras.controleItensLiberados[indexItem])
        {
            ItemLiberado.SetActive(true);
        }
    }

    public void Clicado()
    {   //Verifica se o item foi acionado
        if (GerenciadorPalavras.acertou && GerenciadorPalavras.controleItensLiberados[indexItem] == false)
        {
            Liberar();
            panelScrollItens.SetActive(false);
            GerenciadorPalavras.itemAdicionado = true;
            GerenciadorPalavras.acertou = false;
            for (int i = 0; i < 15; i++)
            {
                GerenciadorPalavras.exibirInformativo[i] = false;
            }
        }
        else {
        }
    }

    public void exibirInforacao()
    {// Quando o cursor do mouse passar por cima
            // Exibe a Sprite com sobreamento
           GerenciadorPalavras.exibirInformativo[indexItem] = true ;
        Debug.Log("passou o mouse");
    }

    void Liberar()
    {
        GerenciadorPalavras.controleItensLiberados[indexItem] = true;
        GerenciadorPalavras.quantidadeItensDesbloqueados++;
    }

  
    public void ocultarInforacao()
    {// Quando o cursor do mouse sair de cima
        for (int i =0;i<15;i++) {
            GerenciadorPalavras.exibirInformativo[i] = false;
        }
    }
}