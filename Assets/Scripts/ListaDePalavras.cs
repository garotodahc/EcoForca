using UnityEngine;
using System.Collections.Generic;

namespace Forca{
public class ListaDePalavras : MonoBehaviour {
	public List<Palavra> Palavras = new List<Palavra> ();
	public Palavra novaPalavra;

	public Palavra getPalvra(int index){
		foreach(Palavra minha in Palavras){

			if(minha.getid() == index){

				Debug.Log(""+minha.getPalavra());
				novaPalavra = minha;
				return novaPalavra;
			}else{
				string sms = "pavra n econtrada para o id =";
				Debug.Log(""+sms + index);
				novaPalavra = null;
			}
		}
			return novaPalavra;
	}

	}
}