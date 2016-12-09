Shader "Custom/FlipNormals" {
	// Taken from guywhosignedup on Unity 3D answers
	// http://answers.unity3D.com/questions/176487/materialtexture-on-the-inside-of-a-sphere.html
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }

		Cull Front
		
		CGPROGRAM

		#pragma surface surf Lambert vertex:vert
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 color : COLOR;
		};

		void vert (inout appdata_full v) {
			v.normal.xyz = v.normal * -1;
		}

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed3 result = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = result.rgb;
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
