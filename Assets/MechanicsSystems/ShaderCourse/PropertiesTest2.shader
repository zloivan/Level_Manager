Shader "Custom/Properties"
{
    Properties
    {
        _myDiffuse ("Diffuse", 2D) = "white" {}
        _diffuseMultiplier ("Diffuse Multiplier", Range(0,5)) = 1
        _myEmission ("Emission", 2D) = "black" {}
        _emittionMultiplier ("Emission Multiplier", Range(0,5)) = 1
        
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _myDiffuse;
        sampler2D _myEmission;
        half _emittionMultiplier;
        half _diffuseMultiplier;


        struct Input
        {
            float2 uv_myDiffuse;
            float2 uv_myEmission;
        };


        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = (tex2D(_myDiffuse, IN.uv_myDiffuse)*_diffuseMultiplier).rgb;
            o.Emission = (tex2D(_myEmission, IN.uv_myEmission) * _emittionMultiplier).rgb;
        }
        ENDCG
    }

    FallBack "Diffuse"
}