Shader "Color Replace Tessellation Sample" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _SwapTex ("Color Data", 2D) = "transparent" {}
        _OverTex ("Outline Data", 2D) = "transparent" {}
        _DispTex ("Disp Texture", 2D) = "gray" {}
        _NormalMap ("Normalmap", 2D) = "bump" {}
        _Displacement ("Displacement", Range(0, 1.0)) = 0.3
        _Color ("Color", color) = (1,1,1,0)
        _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
        _SwapIndex ("Color Scheme Row ID", Range(0,1)) = 0.875
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 300
        
        CGPROGRAM
        #pragma surface surf BlinnPhong addshadow fullforwardshadows vertex:disp nolightmap
        #pragma target 4.6

        struct appdata {
            float4 vertex : POSITION;
            float4 tangent : TANGENT;
            float3 normal : NORMAL;
            float2 texcoord : TEXCOORD0;
        };

        sampler2D _DispTex;
        float _Displacement;

        void disp (inout appdata v)
        {
            float d = tex2Dlod(_DispTex, float4(v.texcoord.xy,0,0)).r * _Displacement;
            v.vertex.xyz += v.normal * d;
        }

        struct Input {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        sampler2D _OverTex;
        sampler2D _NormalMap;
        fixed4 _Color;

        sampler2D _SwapTex;
		float _SwapIndex;

        void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D (_MainTex, IN.uv_MainTex);// * _Color;

            fixed4 c2 = tex2D(_SwapTex, float2(c.r, _SwapIndex));// * _Color;
			//fixed4 c2 = lerp(c, swapCol, swapCol.a) * _Color;
			//c2.a = c.a;

			fixed4 c3 = tex2D (_OverTex, IN.uv_MainTex);
			c2.r = c2.r * (1 - c3.a) + c3.r;
			c2.g = c2.g * (1 - c3.a) + c3.g;
			c2.b = c2.b * (1 - c3.a) + c3.b;

            o.Albedo = c2.rgb;
            o.Specular = 0.2;
            o.Gloss = 1.0;
            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
            o.Alpha = c2.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}