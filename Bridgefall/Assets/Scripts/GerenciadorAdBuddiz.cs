using UnityEngine;

public class GerenciadorAdBuddiz : MonoBehaviour
{
	static GerenciadorAdBuddiz _instancia = null;

	void Start() // Init SDK on app start
	{ 
		if( _instancia != null && _instancia != this)
		{
			DestroyImmediate(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		_instancia = this;

		AdBuddizBinding.SetLogLevel(AdBuddizBinding.ABLogLevel.Info);         // log level

		//AdBuddizBinding.SetTestModeActive();                                  // to delete before submitting to store

		AdBuddizBinding.SetAndroidPublisherKey(
			"34cd1a8b-9924-4234-8a9c-8ebb2e12e371"); // replace with your Android app publisher key
		AdBuddizBinding.SetIOSPublisherKey("TEST_PUBLISHER_KEY_IOS");         // replace with your iOS app publisher key

		AdBuddizBinding.CacheAds();                                           // start caching ads
	}

	public static void ShowBanner()
	{
		AdBuddizBinding.ShowAd();
	}

	public static void ShowVideo()
	{
		AdicionarMacas(1);
		AdBuddizBinding.RewardedVideo.Fetch();
		AdBuddizBinding.RewardedVideo.Show();
	}

	static void AdicionarMacas(int macas = 1)
	{
		Utilidade.AdicionarMacasPorQuantidade(macas);
		Utilidade.AjeitarMacasVerdes();
		UnityAnalytics.GanhouMaca(true, macas);
	}

	/*
	public void OnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.button);
		style.fontSize = 40;

		if (GUI.Button (new Rect (20, 20, Screen.width - 40, 60), "Show Interstitial Ad", style) == true) {
			AdBuddizBinding.ShowAd();
		}
		if (GUI.Button (new Rect (20, 100, Screen.width - 40, 60), "Fetch Rewarded Video Ad", style) == true) {
			AdBuddizBinding.RewardedVideo.Fetch();
		}
		if (GUI.Button (new Rect (20, 180, Screen.width - 40, 60), "Show Rewarded Video Ad", style) == true) {
			AdBuddizBinding.RewardedVideo.Show();
		}
	}
	//*/
	
	void OnEnable()
	{
		// Listen to AdBuddiz events
		AdBuddizManager.didFailToShowAd += DidFailToShowAd;
		AdBuddizManager.didCacheAd += DidCacheAd;
		AdBuddizManager.didShowAd += DidShowAd;
		AdBuddizManager.didClick += DidClick;
		AdBuddizManager.didHideAd += DidHideAd;

		//Listen to AdBuddiz events for incentivized video
		AdBuddizRewardedVideoManager.didFetch += DidFetch;
		AdBuddizRewardedVideoManager.didFail += DidFail;
		AdBuddizRewardedVideoManager.didComplete += DidComplete;
		AdBuddizRewardedVideoManager.didNotComplete += DidNotComplete;
	}
	
	void OnDisable()
	{
		// Remove all event handlers
		AdBuddizManager.didFailToShowAd -= DidFailToShowAd;
		AdBuddizManager.didCacheAd -= DidCacheAd;
		AdBuddizManager.didShowAd -= DidShowAd;
		AdBuddizManager.didClick -= DidClick;
		AdBuddizManager.didHideAd -= DidHideAd;

		AdBuddizRewardedVideoManager.didFetch -= DidFetch;
		AdBuddizRewardedVideoManager.didFail -= DidFail;
		AdBuddizRewardedVideoManager.didComplete -= DidComplete;
		AdBuddizRewardedVideoManager.didNotComplete -= DidNotComplete;
	}
	
	void DidFailToShowAd(string adBuddizError) {
		//AdBuddizBinding.LogNative("DidFailToShowAd: " + adBuddizError);
		//AdBuddizBinding.ToastNative("DidFailToShowAd: " + adBuddizError);
		Debug.Log ("Unity: DidFailToShowAd: " + adBuddizError);
	}
	
	void DidCacheAd() {
		//AdBuddizBinding.LogNative ("DidCacheAd");
		//AdBuddizBinding.ToastNative ("DidCacheAd");
		Debug.Log ("Unity: DidCacheAd");
	}

	void DidShowAd() {
		//AdBuddizBinding.LogNative ("DidShowAd");
		//AdBuddizBinding.ToastNative ("DidShowAd");
		Debug.Log ("Unity: DidShowAd");
	}
	
	void DidClick() {
		//AdBuddizBinding.LogNative ("DidClick");
		//AdBuddizBinding.ToastNative ("DidClick");
		Debug.Log ("Unity: DidClick");
	}
	
	void DidHideAd() {
		//AdBuddizBinding.LogNative ("DidHideAd");
		//AdBuddizBinding.ToastNative ("DidHideAd");
		Debug.Log ("Unity: DidHideAd");
	}

	void DidFetch() {
		//AdBuddizBinding.LogNative ("DidFetch");
		//AdBuddizBinding.ToastNative ("DidFetch");
		Debug.Log ("Unity: DidFetch");
	}

	void DidFail(string adBuddizError) {
		//AdBuddizBinding.LogNative ("DidFail: " + adBuddizError);
		//AdBuddizBinding.ToastNative ("DidFail: " + adBuddizError);
		Debug.Log ("Unity: DidFail: " + adBuddizError);
		//GerenciadorUnityAds.MostrarAdProprio();
	}

	void DidComplete() {
		//AdBuddizBinding.LogNative ("DidComplete");
		//AdBuddizBinding.ToastNative ("DidComplete");
		Debug.Log ("Unity: DidComplete");
		AdicionarMacas(Dados.macasPorVideo - 1);
	}

	void DidNotComplete() {
		//AdBuddizBinding.LogNative ("DidNotComplete");
		//AdBuddizBinding.ToastNative ("DidNotComplete");
		Debug.Log ("Unity: DidNotComplete");
	}
}


