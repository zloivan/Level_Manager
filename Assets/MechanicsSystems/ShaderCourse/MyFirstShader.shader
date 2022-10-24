Shader "Custom/MyFirstShader"
{
    Properties
    {
        _BodyColor ("Body Color", Color) = (1,1,1,1)
        _EmissionColor ("Emission Color", Color) = (1,1,1,1)
        _NormalColor ("Normal color", Color) = (1,1,1,1)
    }
    SubShader
    {

        CGPROGRAM
            #pragma surface surf Lambert

            struct Input
            {
                float2 uv_MainTex;
            };
    
            fixed4 _BodyColor;
            fixed4 _EmissionColor;
            fixed4 _NormalColor;
    
    
            void surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = _BodyColor.rgb;
                o.Emission = _EmissionColor.rgb;
                o.Normal = _NormalColor.rgb;
            }
        ENDCG
    }

    FallBack "Diffuse"
}