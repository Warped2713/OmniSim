Shader "Custom/ColorReplace" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_SwapTex ("Color Data", 2D) = "transparent" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_SwapIndex ("Color Scheme Row ID", Range(0,1)) = 0.875
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _SwapTex;
		float _SwapIndex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex); //* _Color;

			fixed4 swapCol = tex2D(_SwapTex, float2(c.r, _SwapIndex));// * _Color;
			fixed4 c2 = lerp(c, swapCol, swapCol.a) * _Color;
			c2.a = c.a;

			o.Albedo = c2.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c2.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
