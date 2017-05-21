Shader "Custom/OmniSim/ColorReplace/ToonLit" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_SwapTex ("Color Replacement Matrix", 2D) = "transparent" {}
		_SwapIndex ("Color Scheme Row ID", Range(0,1)) = 0.875
		_OverColor ("Additional Color", Color) = (0.5,0.5,0.5,1)
		_OverTex ("Additional Texture Layer (Alpha)", 2D) = "transparent" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
CGPROGRAM
#pragma surface surf ToonRamp

sampler2D _Ramp;

// custom lighting function that uses a texture ramp based
// on angle between light direction and normal
#pragma lighting ToonRamp exclude_path:prepass
inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
{
	#ifndef USING_DIRECTIONAL_LIGHT
	lightDir = normalize(lightDir);
	#endif
	
	half d = dot (s.Normal, lightDir)*0.5 + 0.5;
	half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
	
	half4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
	c.a = 0;
	return c;
}


sampler2D _MainTex;
sampler2D _SwapTex;
sampler2D _OverTex;
float _SwapIndex;
float4 _Color;
float4 _OverColor;

struct Input {
	float2 uv_MainTex : TEXCOORD0;
};

void surf (Input IN, inout SurfaceOutput o) {
	half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;

	// Replace the initial color using Swap Texture
	// with the red value of the initial color as the U-coordinate
	// and the provided _SwapIndex as the V-coordinate (to select a row corresponding to a color scheme)
	half4 c2 = tex2D(_SwapTex, float2(c.r, _SwapIndex));

	// Replace all color data with black if the _OverTex pixel is not transparent
	fixed4 c3 = tex2D (_OverTex, IN.uv_MainTex);
	c2.r = c2.r * (1 - c3.a) + (c3.a) * _OverColor.r;
	c2.g = c2.g * (1 - c3.a) + (c3.a) * _OverColor.g;
	c2.b = c2.b * (1 - c3.a) + (c3.a) * _OverColor.b;

	o.Albedo = c2.rgb;
	o.Alpha = c.a;
}
ENDCG

	} 

	Fallback "Diffuse"
}
