using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MostrarPontosTelaDerrota : MonoBehaviour
{
	public string textoPontos = "Pontos";

	void Awake()
	{
		GetComponent<Text>().text = 
			textoPontos + ": " + Dados.pontosUltimaFasePassantes;
	}
}

