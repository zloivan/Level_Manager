Shader "Custom/DataTypes"
{
    Properties
    {
        _myColor1 ("My Color 1", color) = (1,1,1,1)
        _myColor2 ("My Color 2", color) = (1,1,1,1)
    }
    SubShader
    {
        CGPROGRAM
            #pragma surface Surf Lambert

            struct Input
            {
               float2 uv_MainTex;
            };

            fixed4 _myColor1;
            fixed3 _myColor2;
    
            fixed3x3 _myColorHolder;

            void Surf(Input isMeshInfo, inout SurfaceOutput outSurfaceInfo)
            {
                _myColorHolder[0] = _myColor1.rgb;
                _myColorHolder[1] = _myColor2;
    
                
                outSurfaceInfo.Albedo = _myColorHolder[0];
                outSurfaceInfo.Emission = _myColorHolder[1];
    
    
                outSurfaceInfo.Alpha = _myColor1.a;
            }
        ENDCG
    }
    
    FallBack "Diffuse"
}