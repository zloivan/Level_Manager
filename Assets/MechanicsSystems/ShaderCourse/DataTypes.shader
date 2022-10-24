Shader "Custom/DataTypes"
{
    Properties
    {
        MyColor1 ("My Color 1", color) = (1,1,1,1)
        MyColor2 ("My Color 2", color) = (1,1,1,1)
    }
    SubShader
    {
        CGPROGRAM
            #pragma surface Surf Lambert

            struct Input
            {
               float2 uv_MainTex;
            };

            fixed4 MyColor1;
            fixed3 MyColor2;
    
            fixed3x3 MyColorHolder;

            void Surf(Input isMeshInfo, inout SurfaceOutput outSurfaceInfo)
            {
                MyColorHolder[0] = MyColor1.rgb;
                MyColorHolder[1] = MyColor2;
    
                
                outSurfaceInfo.Albedo = MyColorHolder[0];
                outSurfaceInfo.Emission = MyColorHolder[1];
    
    
                outSurfaceInfo.Alpha = MyColor1.a;
            }
        ENDCG
    }
    
    FallBack "Diffuse"
}