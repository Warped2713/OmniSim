Shader "Custom/Camera/DepthShaderAlpha" {
  Properties {
    _MainTex ("Base (RGB)", 2D) = "white" {}
    _BGTexture ("Base (RGB)", 2D) = "red" {}
    _bwBlend ("Black & White blend", Range (0, 1)) = 0
  }
  SubShader {
    //ZWrite Off //Turn Zwrite Off if depth artifacts
    
    Pass {
      CGPROGRAM
      #pragma vertex vert_img
      #pragma fragment frag
 
      #include "UnityCG.cginc"
 
      uniform sampler2D _MainTex;
      uniform float _bwBlend;
      
      uniform sampler2D _LastCameraDepthTexture;
      uniform sampler2D _BGTexture;
 
      float4 frag(v2f_img i) : COLOR {
        float4 c = tex2D(_MainTex, i.uv);
        
        // Calculates greyscale based on human eye RGB magic numbers
        //float lum = c.r*.3 + c.g*.59 + c.b*.11;
        //float3 bw = float3( lum, lum, lum );
        
        // Interpolate and output the result
        //float4 result = c;
        //result.rgb = lerp(c.rgb, bw, _bwBlend);
        //return result;
        
        float4 cd = tex2D(_LastCameraDepthTexture, i.uv);
        float4 bg = tex2D(_BGTexture, i.uv);
        
        // Calculates alpha based on depth texture value
        
        // Interpolate and output the result
        float4 result = c;
        result.r = (1.0f - cd.r) + bg.r;
        //result.r = lerp(c.r, cd.r, _bwBlend);
        return result;
      }
      ENDCG
    }
  }
  Fallback "Standard"
}