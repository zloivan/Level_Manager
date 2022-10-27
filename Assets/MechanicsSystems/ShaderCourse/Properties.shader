Shader "Custom/Properties"
{
    Properties
    {
        _color ("Main Color", Color) = (1,1,1,1)
        _float ("Float", float) = 0.0
        _intFrom ("Int Range", Range(0,5)) = 1

    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float2 uv_myText;
        };

        float4 _color;
        float _float;
        half _intFrom;

        void surf(Input IN, inout SurfaceOutput o)
        {
        }
        ENDCG
    }

    FallBack "Diffuse"
}