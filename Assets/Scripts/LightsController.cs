using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour {

	LightmapData[] lightmap_data;

	void Awake () {
		lightmap_data = LightmapSettings.lightmaps;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	public void DisableLightMaps() {
		// Disable lightmaps in scene by removing the lightmap data references
		LightmapSettings.lightmaps = new LightmapData[]{};
	}

	public void EnableLightMaps () {
		LightmapSettings.lightmaps = lightmap_data;
	}
}
