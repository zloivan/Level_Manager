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

            struct Input // RESERVED STRUCT NAME!!
            {
               float2 uv_MainTex; // RESERVED FIELD NAME!!
            };

            fixed4 _myColor1;
            fixed3 _myColor2;
    
            fixed3x3 _myColorHolder;

            void Surf(Input inMeshData, inout SurfaceOutput outSurfaceData)
            {
                _myColorHolder[0] = _myColor1.rgb;
                _myColorHolder[1] = _myColor2;
    
                
                outSurfaceData.Albedo = _myColorHolder[0];
                outSurfaceData.Emission = _myColorHolder[1];
    
    
                outSurfaceData.Alpha = _myColor1.a;
            }
        ENDCG
    }
    
    FallBack "Diffuse"
}