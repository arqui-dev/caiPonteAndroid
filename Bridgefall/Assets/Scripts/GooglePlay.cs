using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlay : MonoBehaviour
{
	//static GooglePlay _instancia = null;

	void Awake()
	{
		//_instancia = this;
		PlayGamesPlatform.Activate();
		Conectar();
	}

	static public void Conectar()
	{
		Social.localUser.Authenticate((bool sucesso) =>
		{
			if (sucesso)
			{
				Debug.Log ("Google Play - Conectou!");
			}
			else
			{
				Debug.Log ("Google Play - Nao Conectou!");
			}
		});
	}

	static public void Conquista(Conquistas conquista, float completo)
	{
		if (Social.localUser.authenticated == false) return;

		// completo vai de 0 a 100.
		// se a conquista for escondida, 0.0f indica que ela foi mostrada.
		Social.ReportProgress("id da conquista", completo, (bool suc) =>
		{
			if (suc)
			{
				Debug.Log ("Google Play - Conquista X: "+completo+"!");
			}
			else
			{
				Debug.Log ("Google Play - Erro ao enviar conquista X");
			}
		});
	}

	static public void Pontuar(LeaderBoards tabela, long pontos)
	{
		if (Social.localUser.authenticated == false) return;

		string tbl = GPlay.Constants.leaderboard_normal_mode;

		if (tabela != LeaderBoards.ModoNormal)
		{
			tbl = GPlay.Constants.leaderboards_quickplay[(int)tabela];
		}

		Social.ReportScore(pontos, tbl, (bool suc)=>
		{
			if (suc)
			{
				Debug.Log ("Google Play - Tabela X: "+pontos+"!");
			}
			else
			{
				Debug.Log ("Google Play - Erro ao enviar para tabela X");
			}
		});
	}

	static public void MostrarConquistas()
	{
		if (Social.localUser.authenticated == false) return;

		Social.ShowAchievementsUI();
	}

	static public void MostrarLeaderBoards()
	{
		if (Social.localUser.authenticated == false) return;

		Social.ShowLeaderboardUI();
	}
}

