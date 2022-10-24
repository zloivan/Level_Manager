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
    
            fixed4 _bodyColor;
            fixed4 _emissionColor;
            fixed4 _normalColor;
    
    
            void surf(Input inMeshData, inout SurfaceOutput outSurfaceData)
            {
                outSurfaceData.Albedo = _bodyColor.rgb;
                outSurfaceData.Emission = _emissionColor.rgb;
                outSurfaceData.Normal = _normalColor.rgb;
            }
        ENDCG
    }

    FallBack "Diffuse"
}