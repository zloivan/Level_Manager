Shader "Custom/MyFirstShader"
{
    Properties
    {
        _bodyColor ("Body Color", Color) = (1,1,1,1)
        _emissionColor ("Emission Color", Color) = (1,1,1,1)
        _normalColor ("Normal color", Color) = (1,1,1,1)
    }
    SubShader
    {

        CGPROGRAM
        #pragma surface surf Lambert


        fixed4 _bodyColor;
        fixed4 _emissionColor;
        fixed4 _normalColor;

        struct Input
        {
            float2 uv_MainTex;
        };


        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _bodyColor.rgb;
            o.Emission = _emissionColor.rgb;
            //o.Normal = _normalColor.rgb;
        }
        ENDCG
    }

    FallBack "Diffuse"
}