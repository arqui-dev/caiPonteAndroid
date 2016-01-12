using UnityEngine;
using System.Collections;

public class TelaFaltouMaca : MonoBehaviour
{
	void Awake()
	{
		Time.timeScale = Dados.fluxoTemporalPausado;
	}

	void OnDestroy()
	{
		Time.timeScale = Dados.fluxoTemporalNormal;
	}

	void OnDisable()
	{
		Time.timeScale = Dados.fluxoTemporalNormal;
	}

	public void IniciarVideo()
	{
		if (Random.value < 0.5f)
		{
			GerenciadorUnityAds.ShowRewardedAd();
			Debug.Log ("Mostrou video unity ads");
		}
		else
		{
			GerenciadorAdBuddiz.ShowVideo();
			Debug.Log ("Mostrou video adbuddiz");
		}

		Fechar();
	}

	public void IniciarBanner()
	{
		GerenciadorUnityAds.AdicionarMacas(1);
		GerenciadorAdBuddiz.ShowBanner();
		Debug.Log ("Mostrou banner AdBuddiz");
		Fechar();
	}

	public void IniciarSobrevivencia()
	{
		Debug.Log ("Iniciou sobrevivencia");
		Dados.jogoRapidoDificuldade = 1;
		Dados.modoDeJogo = ModosDeJogo.Sobrevivencia;
		Navegacao.CarregarTelaEstatico(Telas.Jogo);
		ControleMusica.MusicaSobrevivencia();
	}

	public void Fechar()
	{
		Time.timeScale = Dados.fluxoTemporalNormal;
		Destroy(gameObject);
	}
}

