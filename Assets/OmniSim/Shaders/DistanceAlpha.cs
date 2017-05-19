using UnityEngine;
using System.Collections;

public class DistanceAlpha : MonoBehaviour {

  /*public float minRange = 10f;
  public float maxRange = 100f;
  public GameObject camera = null;
  public GameObject objWithRenderer = null;
 
  // Update is called once per frame
  void Update () {
 
     // calculate lerp amount (alpha) by the distance and the provided ranges
     float distance = Vector3.Distance(transform.position, camera.transform.position);
     float lerpAmt = 1.0f - Mathf.Clamp01((distance - minRange) / (maxRange - minRange));
     // update material's alpha
     Renderer renderer = objWithRenderer.GetComponent<Renderer>();
     Color color = renderer.material.color;
     color.a = lerpAmt;
     renderer.material.color = color;
     
     // output current values
     Debug.Log(string.Format("Distance = {0} \t(range = {1} to {2})\t LerpAmt = {3}", 
                             distance, minRange, maxRange, lerpAmt));
  }*/
    
  public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public string textureName = "_MainTex";
	public GameObject obj;

	Renderer renderer;
	Vector2 uvOffset = Vector2.zero;

	// Use this for initialization
	void Start () {
		renderer = obj.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		uvOffset += uvAnimationRate * Time.deltaTime;
		if( renderer.enabled )
		{
			renderer.materials[ materialIndex ].SetTextureOffset( textureName, uvOffset );
		}
	}
}
