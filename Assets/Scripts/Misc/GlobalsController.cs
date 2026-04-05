using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalsController : MonoBehaviour
{
	[SerializeField] private ConstantData m_constants;

	private void Awake()
	{
		if (Globals.CurrentController != null)
		{
			Globals.CurrentConstants = m_constants;

			Destroy(gameObject);
			return;
		}
#if UNITY_ANDROID
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
#endif

		Globals.CurrentController = this;
		Globals.CurrentConstants = m_constants;

		PlayerConfig config = PlayerConfig.Load();
		if (config == null)
		{
			config = new PlayerConfig();
			PlayerConfig.Save(config);
		}
		Globals.CurrentConfig = config;

		DontDestroyOnLoad(gameObject);
	}
}
