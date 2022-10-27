Shader "Custom/Properties"
{
    Properties
    {
        _color ("Main Color", Color) = (1,1,1,1)//ADD THIS TO ALBEDO
        _float ("Float", float) = 0.0
        _textureMultiplier ("Albido multiplier", Range(0,5)) = 1
        _skyMultiplier ("Sky Multiplier", Range(0,5)) = 1
        _myCube ("Cube", CUBE) = "" {}
        _myTexture ("Test texture", 2D) = "white" {}
        _vectorExample ("My Vector", Vector) = (.1,1,1,0)
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert


        float4 _color;
        float _float;
        half _textureMultiplier;
        half _skyMultiplier;
        sampler2D _myTexture;
        samplerCUBE _myCube;
        float4 _vectorExample;
        
        struct Input
        {
            float2 uv_myTexture;
            float3 worldRefl;
        };


        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = (tex2D(_myTexture, IN.uv_myTexture) * _textureMultiplier ).rgb + _color.rgb;
            o.Emission = (texCUBE(_myCube, IN.worldRefl) * _skyMultiplier).rgb;
        }
        ENDCG
    }

    FallBack "Diffuse"
}