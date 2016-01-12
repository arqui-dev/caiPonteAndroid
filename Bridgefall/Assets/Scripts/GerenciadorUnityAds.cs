using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class GerenciadorUnityAds : MonoBehaviour
{
	public GameObject _canvasAdProprio;

	static GameObject canvasAdProprio;

	void Awake()
	{
		canvasAdProprio = _canvasAdProprio;
	}

	public static bool Inicializado()
	{
		return Advertisement.isInitialized;
		//return false;
	}

	public static bool ConexaoInternet()
	{
		Debug.Log ("Conexao internet: "+
		           Application.internetReachability);
		if (Application.internetReachability == 
		    NetworkReachability.NotReachable)
		{
			return false;
		}
		return true;
	}

	public static void ShowRewardedAd()
	{
		//MostrarAdProprio();

		if (!Inicializado() || !ConexaoInternet())
		{
			Debug.Log ("Unity ads not initialized.");
			//Utilidade.AdicionarMensagemNaoViuAd();
			AdicionarMacas(1);
			MostrarAdProprio();
			return;
		}

		//*
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions 
			{ 
				resultCallback = HandleShowResult
			};
			Advertisement.Show("rewardedVideo", options);
		}
		//*/
	}

	//*
	static void HandleShowResult(ShowResult result)
	{
		// Adiciona 1 mesmo que o video nao de certo.
		AdicionarMacas(1);

		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			AdicionarMacas(Dados.macasPorVideo - 1);
			UnityAnalytics.AbriuAd(true, Inicializado());
			break;
		case ShowResult.Skipped:
			Debug.Log ("Saltou o ad");
			break;
		case ShowResult.Failed:
			Debug.Log ("Falhou ao mostrar ad");
			MostrarAdProprio();
			break;
		}
	}
	//*/

	public static void AdicionarMacas(int macas = 1)
	{
		Utilidade.AdicionarMacasPorQuantidade(macas);
		Utilidade.AjeitarMacasVerdes();
		UnityAnalytics.GanhouMaca(true, macas);
	}

	public static void MostrarAdProprio()
	{
		UnityAnalytics.AbriuAd(false, Inicializado());

		Debug.Log ("Mostrando Ad proprio.");
		AdicionarMacas(Dados.macasPorVideo - 1);

		if (canvasAdProprio != null)
		{
			Instantiate(canvasAdProprio);
		}
		else
		{
			Debug.Log ("Canvas nulo");
		}
	}
}

