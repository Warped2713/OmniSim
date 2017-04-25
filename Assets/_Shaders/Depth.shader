Shader "Custom/Depth"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }        
        Cull Off        
        CGPROGRAM
        #pragma surface surf Lambert
        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };
        sampler2D _MainTex;
        void surf (Input IN, inout SurfaceOutput o) {     
            o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
            o.Alpha = 1.0f - (worldPos.z + 8.0f) / 16.0f;
        }
        ENDCG
        
    } Fallback "Diffuse"
}