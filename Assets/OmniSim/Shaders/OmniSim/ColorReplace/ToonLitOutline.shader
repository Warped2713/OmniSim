Shader "Custom/OmniSim/ColorReplace/ToonLitOutline" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (.002, 0.03)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SwapTex ("Color Replacement Matrix", 2D) = "transparent" {}
		_SwapIndex ("Color Scheme Row ID", Range(0,1)) = 0.875
		_OverColor ("Additional Color", Color) = (0.5,0.5,0.5,1)
		_OverTex ("Additional Texture Layer (Alpha)", 2D) = "transparent" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		UsePass "Custom/OmniSim/ColorReplace/ToonLit/FORWARD"
		UsePass "Toon/Basic Outline/OUTLINE"
	} 
	
	Fallback "Custom/OmniSim/ColorReplace/ToonLit"
}
