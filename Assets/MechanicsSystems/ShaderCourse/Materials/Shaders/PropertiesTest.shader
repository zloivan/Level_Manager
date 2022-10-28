Shader "Custom/PropertiesTest"
{
    Properties
    {
        _myTexture ("Test texture", 2D) = "white" {}
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert


        sampler2D _myTexture;

        struct Input
        {
            float2 uv_myTexture;
        };


        void surf(Input IN, inout SurfaceOutput o)
        {
            const float4 greenColor = float4(0, 1, 0, 1);


            o.Albedo = (tex2D(_myTexture, IN.uv_myTexture) * greenColor).rgb;
            
            //o.Albedo.g = _myFloat;
        }
        ENDCG
    }

    FallBack "Diffuse"
}