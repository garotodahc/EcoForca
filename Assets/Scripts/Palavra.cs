using UnityEngine;
using System.Collections;

public class Palavra {
	public  int id;
	public int nivel;
	public string palavra;
	public string dica1;
	public string dica2;
	public int tamanho;
    public string Pergunta;


	public void setDados(int id, int nivel, string palavra, string dica1, string dica2, int tamanho, string question) {
		this.id = id;
		this.nivel = nivel;
		this.palavra = palavra;
		this.dica1 = dica1;
		this.dica2 = dica2;
		this.tamanho = tamanho;
        this.Pergunta = question;
	}
	
	// Update is called once per frame
	public Palavra getDados () {
		Palavra	palavraTemp = new Palavra();
		palavraTemp.id = this.id;
		palavraTemp.nivel = this.nivel;
		palavraTemp.palavra = this.palavra;
		palavraTemp.dica1 = this.dica1;
		palavraTemp.dica2 = this.dica2;
		palavraTemp.tamanho = this.tamanho;
        palavraTemp.Pergunta = this.Pergunta;

		return palavraTemp;
	}

	public int getid(){
		return id;
	}
	public string getPalavra(){
		return palavra;
	}
	public int Tamanho(){
		return tamanho;
	}


    public string getPergunta(int id) {

        return Pergunta;
    }
 }