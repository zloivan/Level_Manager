Shader "Custom/TestNormalMaps"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Emission ("Emission(RGB)", color) = (1,1,1,1)
        _NormalTexture ("Normal (RGB)", 2D) = "white" {}
    }
    SubShader
    {

        CGPROGRAM
        #pragma surface surf Lambert


        sampler2D _MainTex;
        sampler2D _NormalTexture;
        half4 _Emission;
        
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalTexture;
        };


        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
            o.Normal = UnpackNormal(tex2D(_NormalTexture, IN.uv_NormalTexture));
            o.Emission = _Emission.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}