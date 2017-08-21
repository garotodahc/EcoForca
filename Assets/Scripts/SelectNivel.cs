using UnityEngine;
using System.Collections;

public class SelectNivel : MonoBehaviour {


    public static string level;
	// Use this for initialization
	void Start () {
	
	}

    public void ChangeToscene(string sceneToChange)
    {
        //Seto variável static para puder verificar se user clicou em repetir ou prosseguir level.
        //StatusScript.levelToChange = sceneToChange;

        level = "facil";
        Application.LoadLevel(sceneToChange);
      
    }
}
