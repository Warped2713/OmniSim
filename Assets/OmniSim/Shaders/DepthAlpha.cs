using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent (typeof(Camera))]
public class DepthAlpha : MonoBehaviour {

	public float intensity;
	private Material material;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material( Shader.Find("Custom/Camera/GreyScale") );
		this.gameObject.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
	}
  
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if (intensity == 0)
		{
			Graphics.Blit (source, destination);
			return;
		}

		material.SetFloat("_bwBlend", intensity);
		Graphics.Blit (source, destination, material);
	}
}