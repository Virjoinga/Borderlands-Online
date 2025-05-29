¿ÙShader "BOL/Weapon/FadeShader" {
Properties {
 _EmissiveColor ("Emissive Color (Mask R)", Color) = (0.5,0.5,0.5,1)
 _Mask1DiffuseColor ("Mask1 Diffuse Color (Area A)", Color) = (1,1,1,1)
 _Mask1SpecularShininess ("Mask1 Specular Shininess (Area A)", Float) = 0
 _Mask1SpecularGrading ("Mask1 Specular Grading (Area A)", Float) = 0
 _Mask1ReflectionRatio ("Mask1 Reflection Ratio (Area A)", Float) = 1
 _Mask2DiffuseColor ("Mask2 Diffuse Color (Area B)", Color) = (1,1,1,1)
 _Mask2SpecularShininess ("Mask2 Specular Shininess (Area B)", Float) = 0
 _Mask2SpecularGrading ("Mask1 Specular Grading (Area B)", Float) = 0
 _Mask2ReflectionRatio ("Mask2 Reflection Ratio (Area B)", Float) = 1
 _Mask3DiffuseColor ("Mask3 Diffuse Color (Area C)", Color) = (1,1,1,1)
 _Mask3SpecularShininess ("Mask3 Specular Shininess (Area C)", Float) = 0
 _Mask3SpecularGrading ("Mask3 Specular Grading (Area C)", Float) = 0
 _Mask3ReflectionRatio ("Mask3 Reflection Ratio (Area C)", Float) = 1
 _GlossColor ("Gloss Color (Mask A)", Color) = (1,1,1,1)
 _GlossStrength ("Gloss Strength", Float) = 0.5
 _GlossSpecularShininess ("Gloss Specular Shininess", Float) = 0
 _MainTex ("Base (RGB)", 2D) = "black" {}
 _MaskTex ("Mask (RGB)", 2D) = "black" {}
 _Cube ("Reflection Cubemap", CUBE) = "" { TexGen CubeReflect }
 _PatternTex ("Pattern Tex", 2D) = "black" {}
 _PatternRotate ("Pattern Rotation", Float) = 0
 _Pattern0MaxIntensity ("Pattern 0 Max intensity", Float) = 0.01
 _Pattern0Blend ("Pattern 0 Blend Para", Float) = 1
 _Pattern1MaxIntensity ("Pattern 1 Max intensity", Float) = 0.01
 _Pattern1Blend ("Pattern 1 Blend Para", Float) = 1
 _Pattern2MaxIntensity ("Pattern 2 Max intensity", Float) = 0.01
 _Pattern2Blend ("Pattern 2 Blend Para", Float) = 1
 _DecalTex ("Decal Tex", 2D) = "black" {}
 _DecalScaleOffset ("Decal Scale And Position", Vector) = (1,1,0,0)
 _DecalRotate ("Decal Rotation", Float) = 0
 _DecalShearX ("Decal Shear X", Float) = 0
 _DecalShearY ("Decal Shear Y", Float) = 0
 _DecalMask0Blend ("Decal Mask 0 Blend", Float) = 1
 _DecalMask1Blend ("Decal Mask 1 Blend", Float) = 1
 _DecalMask2Blend ("Decal Mask 2 Blend", Float) = 1
 _DecalColor ("Decal Color", Color) = (1,1,1,1)
}
SubShader { 
 LOD 400
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_CenterPosTime]
Vector 14 [_MaskTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
def c15, 1.00000000, 0.04000000, 0.01000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r0.w, c15.x
mov r0.xyz, c13
dp4 r0.x, r0, c8
add r0.w, -v0.x, r0.x
mul r0.xyz, v1, c12.w
dp3 o2.z, r0, c6
dp3 o2.y, r0, c5
dp3 o2.x, r0, c4
dp4 r0.x, v0, c5
add r0.x, r0, -c13.y
abs o3.x, r0.w
mad o1.xy, v2, c14, c14.zwzw
mov o3.zw, c15.xyyz
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
abs o3.y, r0.x
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Vector 0 [_CenterPosTime]
Float 1 [_Mask1SpecularShininess]
Float 2 [_Mask2SpecularShininess]
Float 3 [_Mask3SpecularShininess]
Float 4 [_GlossSpecularShininess]
SetTexture 0 [_RoilingFlameModule] 2D 0
SetTexture 2 [_MaskTex] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s2
def c5, 5.00000000, 0.10000000, -0.10000000, 1.00000000
def c6, 0.01000000, 0.50000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xy
mul r0.xy, v0, c5.x
texld r0.z, r0, s0
mul r0.x, r0.z, c5.y
add r0.x, r0, c0.w
add r0.y, r0.x, c5.z
if_gt v2.y, r0.y
if_lt v2.y, r0.x
else
mov_pp r0, -c5.w
texkill r0.xyzw
endif
endif
texld r0.xyz, v0, s2
add r0.w, -r0.x, -r0.y
add r0.w, -r0.z, r0
mov_sat r1.x, c2
mul r1.x, r0.y, r1
mov_sat r0.y, c1.x
mad r0.y, r0.x, r0, r1.x
add r0.w, r0, c5
mov_sat r0.x, c3
mad r0.y, r0.x, r0.w, r0
dp3 r1.x, v1, v1
rsq r0.w, r1.x
mov_sat r0.x, c4
mad r0.x, r0, r0.z, r0.y
mul r1.xyz, r0.w, v1
add oC0.w, r0.x, c6.x
mad oC0.xyz, r1, c6.y, c6.y
"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "RenderType"="Opaque" }
  ZWrite Off
Program "vp" {
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_MaskTex_ST]
Vector 26 [_PatternTex_ST]
Float 27 [_PatternRotate]
Vector 28 [_DecalScaleOffset]
Float 29 [_DecalRotate]
Float 30 [_DecalShearX]
Float 31 [_DecalShearY]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_color0 o8
def c32, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c33, -1.00000000, 1.00000000, -0.50000000, 2.00000000
def c34, 0.10000000, 0.00000000, 0.01000000, -0.05000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_2d s0
mul r1.xyz, v1, c22.w
dp3 r4.zw, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r3.y, r4.w
mov r0.y, r4.z
mov r0.x, r3
mov r0.z, r3
mov r0.w, c33.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4.z, r4.z
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c33.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c29.x
mad r0.w, r0, c32.x, c32.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c33.w, -r0
mad r1.w, r0, c32.z, c32
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
dp3 o7.x, r1, c4
mov r1.x, c30
mov r0.z, -r0.y
mov r0.w, r0.x
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mad r1.x, r1, c32, c32.y
frc r0.x, r1
mad r0.x, r0, c32.z, c32.w
sincos r1.xy, r0.x
mov r0.y, c31.x
mad r0.y, r0, c32.x, c32
frc r0.x, r0.y
mad r1.z, r0.x, c32, c32.w
sincos r0.xy, r1.z
rcp r1.x, r1.x
mul r0.z, r1.y, r1.x
rcp r0.x, r0.x
mad r0.z, r2.y, r0, r2.x
mul r0.x, r0.y, r0
mov r0.w, c27.x
mad r0.y, r0.w, c32.x, c32
frc r1.x, r0.y
mad r0.w, r0.z, r0.x, r2.y
mad r1.z, r1.x, c32, c32.w
dp4 r1.w, v0, c3
rcp r0.y, c28.y
rcp r0.x, c28.x
mad o2.zw, r0, r0.xyxy, c28
sincos r0.xy, r1.z
mul r0.zw, v0.xyzy, c26.xyxy
mul r0.zw, r0, c33.xyxy
add r0.zw, r0, c26
add r0.zw, r0, c33.z
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c32.y
mul r2.y, r2, c13.x
mad o3.xy, r2.z, c14.zwzw, r2
mov r2.xyz, c23
mov r2.w, c33.y
dp4 r1.z, r2, c10
dp4 r5.xy, v0, c5
add r1.z, -v0, r1
add r2.y, r5.x, -c23
abs r2.x, r1.z
mov r4.x, r0
mov r4.y, -r0
mul r0.xy, r0.yxzw, r0.zwzw
mul r4.xy, r0.zwzw, r4
add r5.w, r0.x, r0.y
add r5.z, r4.x, r4.y
abs r2.y, r2
mov r4.z, c34.y
mul r4.xy, r2, c34.x
texldl r1.z, r4.xyzz, s0
mul r0.z, r1, c34
min r0.x, r0.z, c34
dp4 r1.z, v0, c2
max r0.x, r0, c34.z
add r2.w, r0.x, c34
mov r2.z, c34.x
mov r0.y, r5
dp4 r0.x, v0, c4
dp4 r0.z, v0, c6
add o2.xy, r5.zwzw, c32.y
mov o6.xyz, r3
mov o8, r2
mov o0, r1
mov o3.zw, r1
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c25.xyxy, c25
mad o1.xy, v2, c24, c24.zwzw
mov o4.w, r3
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_MaskTex_ST]
Vector 26 [_PatternTex_ST]
Float 27 [_PatternRotate]
Vector 28 [_DecalScaleOffset]
Float 29 [_DecalRotate]
Float 30 [_DecalShearX]
Float 31 [_DecalShearY]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_color0 o8
def c32, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c33, -1.00000000, 1.00000000, -0.50000000, 2.00000000
def c34, 0.10000000, 0.00000000, 0.01000000, -0.05000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_2d s0
mul r1.xyz, v1, c22.w
dp3 r4.zw, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r3.y, r4.w
mov r0.y, r4.z
mov r0.x, r3
mov r0.z, r3
mov r0.w, c33.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4.z, r4.z
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c33.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c29.x
mad r0.w, r0, c32.x, c32.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c33.w, -r0
mad r1.w, r0, c32.z, c32
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
dp3 o7.x, r1, c4
mov r1.x, c30
mov r0.z, -r0.y
mov r0.w, r0.x
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mad r1.x, r1, c32, c32.y
frc r0.x, r1
mad r0.x, r0, c32.z, c32.w
sincos r1.xy, r0.x
mov r0.y, c31.x
mad r0.y, r0, c32.x, c32
frc r0.x, r0.y
mad r1.z, r0.x, c32, c32.w
sincos r0.xy, r1.z
rcp r1.x, r1.x
mul r0.z, r1.y, r1.x
rcp r0.x, r0.x
mad r0.z, r2.y, r0, r2.x
mul r0.x, r0.y, r0
mov r0.w, c27.x
mad r0.y, r0.w, c32.x, c32
frc r1.x, r0.y
mad r0.w, r0.z, r0.x, r2.y
mad r1.z, r1.x, c32, c32.w
dp4 r1.w, v0, c3
rcp r0.y, c28.y
rcp r0.x, c28.x
mad o2.zw, r0, r0.xyxy, c28
sincos r0.xy, r1.z
mul r0.zw, v0.xyzy, c26.xyxy
mul r0.zw, r0, c33.xyxy
add r0.zw, r0, c26
add r0.zw, r0, c33.z
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c32.y
mul r2.y, r2, c13.x
mad o3.xy, r2.z, c14.zwzw, r2
mov r2.xyz, c23
mov r2.w, c33.y
dp4 r1.z, r2, c10
dp4 r5.xy, v0, c5
add r1.z, -v0, r1
add r2.y, r5.x, -c23
abs r2.x, r1.z
mov r4.x, r0
mov r4.y, -r0
mul r0.xy, r0.yxzw, r0.zwzw
mul r4.xy, r0.zwzw, r4
add r5.w, r0.x, r0.y
add r5.z, r4.x, r4.y
abs r2.y, r2
mov r4.z, c34.y
mul r4.xy, r2, c34.x
texldl r1.z, r4.xyzz, s0
mul r0.z, r1, c34
min r0.x, r0.z, c34
dp4 r1.z, v0, c2
max r0.x, r0, c34.z
add r2.w, r0.x, c34
mov r2.z, c34.x
mov r0.y, r5
dp4 r0.x, v0, c4
dp4 r0.z, v0, c6
add o2.xy, r5.zwzw, c32.y
mov o6.xyz, r3
mov o8, r2
mov o0, r1
mov o3.zw, r1
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c25.xyxy, c25
mad o1.xy, v2, c24, c24.zwzw
mov o4.w, r3
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_MaskTex_ST]
Vector 26 [_PatternTex_ST]
Float 27 [_PatternRotate]
Vector 28 [_DecalScaleOffset]
Float 29 [_DecalRotate]
Float 30 [_DecalShearX]
Float 31 [_DecalShearY]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_color0 o8
def c32, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c33, -1.00000000, 1.00000000, -0.50000000, 2.00000000
def c34, 0.10000000, 0.00000000, 0.01000000, -0.05000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_2d s0
mul r1.xyz, v1, c22.w
dp3 r4.zw, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r3.y, r4.w
mov r0.y, r4.z
mov r0.x, r3
mov r0.z, r3
mov r0.w, c33.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4.z, r4.z
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c33.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c29.x
mad r0.w, r0, c32.x, c32.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c33.w, -r0
mad r1.w, r0, c32.z, c32
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
dp3 o7.x, r1, c4
mov r1.x, c30
mov r0.z, -r0.y
mov r0.w, r0.x
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mad r1.x, r1, c32, c32.y
frc r0.x, r1
mad r0.x, r0, c32.z, c32.w
sincos r1.xy, r0.x
mov r0.y, c31.x
mad r0.y, r0, c32.x, c32
frc r0.x, r0.y
mad r1.z, r0.x, c32, c32.w
sincos r0.xy, r1.z
rcp r1.x, r1.x
mul r0.z, r1.y, r1.x
rcp r0.x, r0.x
mad r0.z, r2.y, r0, r2.x
mul r0.x, r0.y, r0
mov r0.w, c27.x
mad r0.y, r0.w, c32.x, c32
frc r1.x, r0.y
mad r0.w, r0.z, r0.x, r2.y
mad r1.z, r1.x, c32, c32.w
dp4 r1.w, v0, c3
rcp r0.y, c28.y
rcp r0.x, c28.x
mad o2.zw, r0, r0.xyxy, c28
sincos r0.xy, r1.z
mul r0.zw, v0.xyzy, c26.xyxy
mul r0.zw, r0, c33.xyxy
add r0.zw, r0, c26
add r0.zw, r0, c33.z
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c32.y
mul r2.y, r2, c13.x
mad o3.xy, r2.z, c14.zwzw, r2
mov r2.xyz, c23
mov r2.w, c33.y
dp4 r1.z, r2, c10
dp4 r5.xy, v0, c5
add r1.z, -v0, r1
add r2.y, r5.x, -c23
abs r2.x, r1.z
mov r4.x, r0
mov r4.y, -r0
mul r0.xy, r0.yxzw, r0.zwzw
mul r4.xy, r0.zwzw, r4
add r5.w, r0.x, r0.y
add r5.z, r4.x, r4.y
abs r2.y, r2
mov r4.z, c34.y
mul r4.xy, r2, c34.x
texldl r1.z, r4.xyzz, s0
mul r0.z, r1, c34
min r0.x, r0.z, c34
dp4 r1.z, v0, c2
max r0.x, r0, c34.z
add r2.w, r0.x, c34
mov r2.z, c34.x
mov r0.y, r5
dp4 r0.x, v0, c4
dp4 r0.z, v0, c6
add o2.xy, r5.zwzw, c32.y
mov o6.xyz, r3
mov o8, r2
mov o0, r1
mov o3.zw, r1
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c25.xyxy, c25
mad o1.xy, v2, c24, c24.zwzw
mov o4.w, r3
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_MaskTex_ST]
Vector 26 [_PatternTex_ST]
Float 27 [_PatternRotate]
Vector 28 [_DecalScaleOffset]
Float 29 [_DecalRotate]
Float 30 [_DecalShearX]
Float 31 [_DecalShearY]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_color0 o8
def c32, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c33, -1.00000000, 1.00000000, -0.50000000, 2.00000000
def c34, 0.10000000, 0.00000000, 0.01000000, -0.05000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_2d s0
mul r1.xyz, v1, c22.w
dp3 r4.zw, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r3.y, r4.w
mov r0.y, r4.z
mov r0.x, r3
mov r0.z, r3
mov r0.w, c33.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4.z, r4.z
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c33.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c29.x
mad r0.w, r0, c32.x, c32.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c33.w, -r0
mad r1.w, r0, c32.z, c32
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
dp3 o7.x, r1, c4
mov r1.x, c30
mov r0.z, -r0.y
mov r0.w, r0.x
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mad r1.x, r1, c32, c32.y
frc r0.x, r1
mad r0.x, r0, c32.z, c32.w
sincos r1.xy, r0.x
mov r0.y, c31.x
mad r0.y, r0, c32.x, c32
frc r0.x, r0.y
mad r1.z, r0.x, c32, c32.w
sincos r0.xy, r1.z
rcp r1.x, r1.x
mul r0.z, r1.y, r1.x
rcp r0.x, r0.x
mad r0.z, r2.y, r0, r2.x
mul r0.x, r0.y, r0
mov r0.w, c27.x
mad r0.y, r0.w, c32.x, c32
frc r1.x, r0.y
mad r0.w, r0.z, r0.x, r2.y
mad r1.z, r1.x, c32, c32.w
dp4 r1.w, v0, c3
rcp r0.y, c28.y
rcp r0.x, c28.x
mad o2.zw, r0, r0.xyxy, c28
sincos r0.xy, r1.z
mul r0.zw, v0.xyzy, c26.xyxy
mul r0.zw, r0, c33.xyxy
add r0.zw, r0, c26
add r0.zw, r0, c33.z
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c32.y
mul r2.y, r2, c13.x
mad o3.xy, r2.z, c14.zwzw, r2
mov r2.xyz, c23
mov r2.w, c33.y
dp4 r1.z, r2, c10
dp4 r5.xy, v0, c5
add r1.z, -v0, r1
add r2.y, r5.x, -c23
abs r2.x, r1.z
mov r4.x, r0
mov r4.y, -r0
mul r0.xy, r0.yxzw, r0.zwzw
mul r4.xy, r0.zwzw, r4
add r5.w, r0.x, r0.y
add r5.z, r4.x, r4.y
abs r2.y, r2
mov r4.z, c34.y
mul r4.xy, r2, c34.x
texldl r1.z, r4.xyzz, s0
mul r0.z, r1, c34
min r0.x, r0.z, c34
dp4 r1.z, v0, c2
max r0.x, r0, c34.z
add r2.w, r0.x, c34
mov r2.z, c34.x
mov r0.y, r5
dp4 r0.x, v0, c4
dp4 r0.z, v0, c6
add o2.xy, r5.zwzw, c32.y
mov o6.xyz, r3
mov o8, r2
mov o0, r1
mov o3.zw, r1
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c25.xyxy, c25
mad o1.xy, v2, c24, c24.zwzw
mov o4.w, r3
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_MaskTex_ST]
Vector 26 [_PatternTex_ST]
Float 27 [_PatternRotate]
Vector 28 [_DecalScaleOffset]
Float 29 [_DecalRotate]
Float 30 [_DecalShearX]
Float 31 [_DecalShearY]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_color0 o8
def c32, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c33, -1.00000000, 1.00000000, -0.50000000, 2.00000000
def c34, 0.10000000, 0.00000000, 0.01000000, -0.05000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_2d s0
mul r1.xyz, v1, c22.w
dp3 r4.zw, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r3.y, r4.w
mov r0.y, r4.z
mov r0.x, r3
mov r0.z, r3
mov r0.w, c33.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4.z, r4.z
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c33.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c29.x
mad r0.w, r0, c32.x, c32.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c33.w, -r0
mad r1.w, r0, c32.z, c32
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
dp3 o7.x, r1, c4
mov r1.x, c30
mov r0.z, -r0.y
mov r0.w, r0.x
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mad r1.x, r1, c32, c32.y
frc r0.x, r1
mad r0.x, r0, c32.z, c32.w
sincos r1.xy, r0.x
mov r0.y, c31.x
mad r0.y, r0, c32.x, c32
frc r0.x, r0.y
mad r1.z, r0.x, c32, c32.w
sincos r0.xy, r1.z
rcp r1.x, r1.x
mul r0.z, r1.y, r1.x
rcp r0.x, r0.x
mad r0.z, r2.y, r0, r2.x
mul r0.x, r0.y, r0
mov r0.w, c27.x
mad r0.y, r0.w, c32.x, c32
frc r1.x, r0.y
mad r0.w, r0.z, r0.x, r2.y
mad r1.z, r1.x, c32, c32.w
dp4 r1.w, v0, c3
rcp r0.y, c28.y
rcp r0.x, c28.x
mad o2.zw, r0, r0.xyxy, c28
sincos r0.xy, r1.z
mul r0.zw, v0.xyzy, c26.xyxy
mul r0.zw, r0, c33.xyxy
add r0.zw, r0, c26
add r0.zw, r0, c33.z
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c32.y
mul r2.y, r2, c13.x
mad o3.xy, r2.z, c14.zwzw, r2
mov r2.xyz, c23
mov r2.w, c33.y
dp4 r1.z, r2, c10
dp4 r5.xy, v0, c5
add r1.z, -v0, r1
add r2.y, r5.x, -c23
abs r2.x, r1.z
mov r4.x, r0
mov r4.y, -r0
mul r0.xy, r0.yxzw, r0.zwzw
mul r4.xy, r0.zwzw, r4
add r5.w, r0.x, r0.y
add r5.z, r4.x, r4.y
abs r2.y, r2
mov r4.z, c34.y
mul r4.xy, r2, c34.x
texldl r1.z, r4.xyzz, s0
mul r0.z, r1, c34
min r0.x, r0.z, c34
dp4 r1.z, v0, c2
max r0.x, r0, c34.z
add r2.w, r0.x, c34
mov r2.z, c34.x
mov r0.y, r5
dp4 r0.x, v0, c4
dp4 r0.z, v0, c6
add o2.xy, r5.zwzw, c32.y
mov o6.xyz, r3
mov o8, r2
mov o0, r1
mov o3.zw, r1
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c25.xyxy, c25
mad o1.xy, v2, c24, c24.zwzw
mov o4.w, r3
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_MaskTex_ST]
Vector 26 [_PatternTex_ST]
Float 27 [_PatternRotate]
Vector 28 [_DecalScaleOffset]
Float 29 [_DecalRotate]
Float 30 [_DecalShearX]
Float 31 [_DecalShearY]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_color0 o8
def c32, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c33, -1.00000000, 1.00000000, -0.50000000, 2.00000000
def c34, 0.10000000, 0.00000000, 0.01000000, -0.05000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_2d s0
mul r1.xyz, v1, c22.w
dp3 r4.zw, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r3.y, r4.w
mov r0.y, r4.z
mov r0.x, r3
mov r0.z, r3
mov r0.w, c33.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4.z, r4.z
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c33.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.x, r0, c8
dp4 r1.y, r0, c9
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c29.x
mad r0.w, r0, c32.x, c32.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c33.w, -r0
mad r1.w, r0, c32.z, c32
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
dp3 o7.x, r1, c4
mov r1.x, c30
mov r0.z, -r0.y
mov r0.w, r0.x
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mad r1.x, r1, c32, c32.y
frc r0.x, r1
mad r0.x, r0, c32.z, c32.w
sincos r1.xy, r0.x
mov r0.y, c31.x
mad r0.y, r0, c32.x, c32
frc r0.x, r0.y
mad r1.z, r0.x, c32, c32.w
sincos r0.xy, r1.z
rcp r1.x, r1.x
mul r0.z, r1.y, r1.x
rcp r0.x, r0.x
mad r0.z, r2.y, r0, r2.x
mul r0.x, r0.y, r0
mov r0.w, c27.x
mad r0.y, r0.w, c32.x, c32
frc r1.x, r0.y
mad r0.w, r0.z, r0.x, r2.y
mad r1.z, r1.x, c32, c32.w
dp4 r1.w, v0, c3
rcp r0.y, c28.y
rcp r0.x, c28.x
mad o2.zw, r0, r0.xyxy, c28
sincos r0.xy, r1.z
mul r0.zw, v0.xyzy, c26.xyxy
mul r0.zw, r0, c33.xyxy
add r0.zw, r0, c26
add r0.zw, r0, c33.z
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c32.y
mul r2.y, r2, c13.x
mad o3.xy, r2.z, c14.zwzw, r2
mov r2.xyz, c23
mov r2.w, c33.y
dp4 r1.z, r2, c10
dp4 r5.xy, v0, c5
add r1.z, -v0, r1
add r2.y, r5.x, -c23
abs r2.x, r1.z
mov r4.x, r0
mov r4.y, -r0
mul r0.xy, r0.yxzw, r0.zwzw
mul r4.xy, r0.zwzw, r4
add r5.w, r0.x, r0.y
add r5.z, r4.x, r4.y
abs r2.y, r2
mov r4.z, c34.y
mul r4.xy, r2, c34.x
texldl r1.z, r4.xyzz, s0
mul r0.z, r1, c34
min r0.x, r0.z, c34
dp4 r1.z, v0, c2
max r0.x, r0, c34.z
add r2.w, r0.x, c34
mov r2.z, c34.x
mov r0.y, r5
dp4 r0.x, v0, c4
dp4 r0.z, v0, c6
add o2.xy, r5.zwzw, c32.y
mov o6.xyz, r3
mov o8, r2
mov o0, r1
mov o3.zw, r1
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c25.xyxy, c25
mad o1.xy, v2, c24, c24.zwzw
mov o4.w, r3
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_EmissiveColor]
Vector 1 [_GlossColor]
Vector 2 [_Mask1DiffuseColor]
Vector 3 [_Mask2DiffuseColor]
Vector 4 [_Mask3DiffuseColor]
Float 5 [_Pattern0MaxIntensity]
Float 6 [_Pattern0Blend]
Float 7 [_Pattern1MaxIntensity]
Float 8 [_Pattern1Blend]
Float 9 [_Pattern2MaxIntensity]
Float 10 [_Pattern2Blend]
Float 11 [_DecalMask0Blend]
Float 12 [_DecalMask1Blend]
Float 13 [_DecalMask2Blend]
Vector 14 [_DecalColor]
Float 15 [_GlossStrength]
Float 16 [_Mask1ReflectionRatio]
Float 17 [_Mask2ReflectionRatio]
Float 18 [_Mask3ReflectionRatio]
Float 19 [_Mask1SpecularGrading]
Float 20 [_Mask2SpecularGrading]
Float 21 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c22, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c23, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c24, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texldp r0, v2, s0
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
texld r2.xyz, v1, s3
add r1.xyz, -r3, c1
mad r1.xyz, r1, c15.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c22.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c22.y
mul r2.w, r2.y, c22.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c22, r2
mad r2.w, r2.z, c23.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c4
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
add r2.w, r2, -c9.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c23.y, c23.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c2, r4
mad r2.xyz, r7.y, c3, r2
mad r4.xyz, r1.w, c4, r2
endif
mul r2.x, r7.y, c12
mad r2.x, r7, c11, r2
mad_sat r2.x, r1.w, c13, r2
add r3.w, r2.x, c23
texld r2, v1.zwzw, s5
cmp r3.w, r3, c23.z, c23.y
mad r2.xyz, r2, c14, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c20.x
mov_sat r0.w, c19.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c21.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c0
mul r1.xyz, r0.w, c0
mad r0.xyz, r2, r0, r4
mad r2.xyz, r1, c24.x, r0
dp3 r0.x, v4, v4
rsq r0.x, r0.x
dp3 r0.y, v5, v5
mul r1.xyz, r0.x, v4
rsq r0.y, r0.y
mul r0.xyz, r0.y, v5
dp3_sat r0.z, r1, r0
mov_sat r0.w, c17.x
mul r0.y, r7, r0.w
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
add r0.w, -r0.z, c23.z
mad r0.x, r0, r1.w, r0.y
mul r0.xyz, r3, r0.x
mad oC0.xyz, r0, r0.w, r2
mov_pp oC0.w, c23.z
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_EmissiveColor]
Vector 1 [_GlossColor]
Vector 2 [_Mask1DiffuseColor]
Vector 3 [_Mask2DiffuseColor]
Vector 4 [_Mask3DiffuseColor]
Float 5 [_Pattern0MaxIntensity]
Float 6 [_Pattern0Blend]
Float 7 [_Pattern1MaxIntensity]
Float 8 [_Pattern1Blend]
Float 9 [_Pattern2MaxIntensity]
Float 10 [_Pattern2Blend]
Float 11 [_DecalMask0Blend]
Float 12 [_DecalMask1Blend]
Float 13 [_DecalMask2Blend]
Vector 14 [_DecalColor]
Float 15 [_GlossStrength]
Float 16 [_Mask1ReflectionRatio]
Float 17 [_Mask2ReflectionRatio]
Float 18 [_Mask3ReflectionRatio]
Float 19 [_Mask1SpecularGrading]
Float 20 [_Mask2SpecularGrading]
Float 21 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c22, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c23, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c24, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texldp r0, v2, s0
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
texld r2.xyz, v1, s3
add r1.xyz, -r3, c1
mad r1.xyz, r1, c15.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c22.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c22.y
mul r2.w, r2.y, c22.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c22, r2
mad r2.w, r2.z, c23.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c4
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
add r2.w, r2, -c9.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c23.y, c23.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c2, r4
mad r2.xyz, r7.y, c3, r2
mad r4.xyz, r1.w, c4, r2
endif
mul r2.x, r7.y, c12
mad r2.x, r7, c11, r2
mad_sat r2.x, r1.w, c13, r2
add r3.w, r2.x, c23
texld r2, v1.zwzw, s5
cmp r3.w, r3, c23.z, c23.y
mad r2.xyz, r2, c14, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c20.x
mov_sat r0.w, c19.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c21.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c0
mul r1.xyz, r0.w, c0
mad r0.xyz, r2, r0, r4
mad r2.xyz, r1, c24.x, r0
dp3 r0.x, v4, v4
rsq r0.x, r0.x
dp3 r0.y, v5, v5
mul r1.xyz, r0.x, v4
rsq r0.y, r0.y
mul r0.xyz, r0.y, v5
dp3_sat r0.z, r1, r0
mov_sat r0.w, c17.x
mul r0.y, r7, r0.w
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
add r0.w, -r0.z, c23.z
mad r0.x, r0, r1.w, r0.y
mul r0.xyz, r3, r0.x
mad oC0.xyz, r0, r0.w, r2
mov_pp oC0.w, c23.z
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_EmissiveColor]
Vector 1 [_GlossColor]
Vector 2 [_Mask1DiffuseColor]
Vector 3 [_Mask2DiffuseColor]
Vector 4 [_Mask3DiffuseColor]
Float 5 [_Pattern0MaxIntensity]
Float 6 [_Pattern0Blend]
Float 7 [_Pattern1MaxIntensity]
Float 8 [_Pattern1Blend]
Float 9 [_Pattern2MaxIntensity]
Float 10 [_Pattern2Blend]
Float 11 [_DecalMask0Blend]
Float 12 [_DecalMask1Blend]
Float 13 [_DecalMask2Blend]
Vector 14 [_DecalColor]
Float 15 [_GlossStrength]
Float 16 [_Mask1ReflectionRatio]
Float 17 [_Mask2ReflectionRatio]
Float 18 [_Mask3ReflectionRatio]
Float 19 [_Mask1SpecularGrading]
Float 20 [_Mask2SpecularGrading]
Float 21 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c22, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c23, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c24, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texldp r0, v2, s0
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
texld r2.xyz, v1, s3
add r1.xyz, -r3, c1
mad r1.xyz, r1, c15.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c22.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c22.y
mul r2.w, r2.y, c22.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c22, r2
mad r2.w, r2.z, c23.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c4
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
add r2.w, r2, -c9.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c23.y, c23.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c2, r4
mad r2.xyz, r7.y, c3, r2
mad r4.xyz, r1.w, c4, r2
endif
mul r2.x, r7.y, c12
mad r2.x, r7, c11, r2
mad_sat r2.x, r1.w, c13, r2
add r3.w, r2.x, c23
texld r2, v1.zwzw, s5
cmp r3.w, r3, c23.z, c23.y
mad r2.xyz, r2, c14, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c20.x
mov_sat r0.w, c19.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c21.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c0
mul r1.xyz, r0.w, c0
mad r0.xyz, r2, r0, r4
mad r2.xyz, r1, c24.x, r0
dp3 r0.x, v4, v4
rsq r0.x, r0.x
dp3 r0.y, v5, v5
mul r1.xyz, r0.x, v4
rsq r0.y, r0.y
mul r0.xyz, r0.y, v5
dp3_sat r0.z, r1, r0
mov_sat r0.w, c17.x
mul r0.y, r7, r0.w
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
add r0.w, -r0.z, c23.z
mad r0.x, r0, r1.w, r0.y
mul r0.xyz, r3, r0.x
mad oC0.xyz, r0, r0.w, r2
mov_pp oC0.w, c23.z
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_EmissiveColor]
Vector 1 [_GlossColor]
Vector 2 [_Mask1DiffuseColor]
Vector 3 [_Mask2DiffuseColor]
Vector 4 [_Mask3DiffuseColor]
Float 5 [_Pattern0MaxIntensity]
Float 6 [_Pattern0Blend]
Float 7 [_Pattern1MaxIntensity]
Float 8 [_Pattern1Blend]
Float 9 [_Pattern2MaxIntensity]
Float 10 [_Pattern2Blend]
Float 11 [_DecalMask0Blend]
Float 12 [_DecalMask1Blend]
Float 13 [_DecalMask2Blend]
Vector 14 [_DecalColor]
Float 15 [_GlossStrength]
Float 16 [_Mask1ReflectionRatio]
Float 17 [_Mask2ReflectionRatio]
Float 18 [_Mask3ReflectionRatio]
Float 19 [_Mask1SpecularGrading]
Float 20 [_Mask2SpecularGrading]
Float 21 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c22, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c23, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c24, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c1
mad r1.xyz, r0, c15.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c22.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c22.y
mul r2.w, r2.y, c22.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c22, r2
mad r2.w, r2.z, c23.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c4
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
add r2.w, r2, -c9.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c23.y, c23.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c2, r4
mad r2.xyz, r7.y, c3, r2
mad r4.xyz, r1.w, c4, r2
endif
mul r2.x, r7.y, c12
mad r2.x, r7, c11, r2
mad_sat r2.x, r1.w, c13, r2
add r3.w, r2.x, c23
texld r2, v1.zwzw, s5
cmp r3.w, r3, c23.z, c23.y
mad r2.xyz, r2, c14, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c20.x
mov_sat r0.w, c19.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c21.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c0
mul r1.xyz, r0.w, c0
mad r0.xyz, r2, r0, r4
mad r2.xyz, r1, c24.x, r0
dp3 r0.x, v4, v4
rsq r0.x, r0.x
dp3 r0.y, v5, v5
mul r1.xyz, r0.x, v4
rsq r0.y, r0.y
mul r0.xyz, r0.y, v5
dp3_sat r0.z, r1, r0
mov_sat r0.w, c17.x
mul r0.y, r7, r0.w
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
add r0.w, -r0.z, c23.z
mad r0.x, r0, r1.w, r0.y
mul r0.xyz, r3, r0.x
mad oC0.xyz, r0, r0.w, r2
mov_pp oC0.w, c23.z
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_EmissiveColor]
Vector 1 [_GlossColor]
Vector 2 [_Mask1DiffuseColor]
Vector 3 [_Mask2DiffuseColor]
Vector 4 [_Mask3DiffuseColor]
Float 5 [_Pattern0MaxIntensity]
Float 6 [_Pattern0Blend]
Float 7 [_Pattern1MaxIntensity]
Float 8 [_Pattern1Blend]
Float 9 [_Pattern2MaxIntensity]
Float 10 [_Pattern2Blend]
Float 11 [_DecalMask0Blend]
Float 12 [_DecalMask1Blend]
Float 13 [_DecalMask2Blend]
Vector 14 [_DecalColor]
Float 15 [_GlossStrength]
Float 16 [_Mask1ReflectionRatio]
Float 17 [_Mask2ReflectionRatio]
Float 18 [_Mask3ReflectionRatio]
Float 19 [_Mask1SpecularGrading]
Float 20 [_Mask2SpecularGrading]
Float 21 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c22, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c23, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c24, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c1
mad r1.xyz, r0, c15.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c22.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c22.y
mul r2.w, r2.y, c22.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c22, r2
mad r2.w, r2.z, c23.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c4
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
add r2.w, r2, -c9.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c23.y, c23.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c2, r4
mad r2.xyz, r7.y, c3, r2
mad r4.xyz, r1.w, c4, r2
endif
mul r2.x, r7.y, c12
mad r2.x, r7, c11, r2
mad_sat r2.x, r1.w, c13, r2
add r3.w, r2.x, c23
texld r2, v1.zwzw, s5
cmp r3.w, r3, c23.z, c23.y
mad r2.xyz, r2, c14, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c20.x
mov_sat r0.w, c19.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c21.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c0
mul r1.xyz, r0.w, c0
mad r0.xyz, r2, r0, r4
mad r2.xyz, r1, c24.x, r0
dp3 r0.x, v4, v4
rsq r0.x, r0.x
dp3 r0.y, v5, v5
mul r1.xyz, r0.x, v4
rsq r0.y, r0.y
mul r0.xyz, r0.y, v5
dp3_sat r0.z, r1, r0
mov_sat r0.w, c17.x
mul r0.y, r7, r0.w
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
add r0.w, -r0.z, c23.z
mad r0.x, r0, r1.w, r0.y
mul r0.xyz, r3, r0.x
mad oC0.xyz, r0, r0.w, r2
mov_pp oC0.w, c23.z
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_EmissiveColor]
Vector 1 [_GlossColor]
Vector 2 [_Mask1DiffuseColor]
Vector 3 [_Mask2DiffuseColor]
Vector 4 [_Mask3DiffuseColor]
Float 5 [_Pattern0MaxIntensity]
Float 6 [_Pattern0Blend]
Float 7 [_Pattern1MaxIntensity]
Float 8 [_Pattern1Blend]
Float 9 [_Pattern2MaxIntensity]
Float 10 [_Pattern2Blend]
Float 11 [_DecalMask0Blend]
Float 12 [_DecalMask1Blend]
Float 13 [_DecalMask2Blend]
Vector 14 [_DecalColor]
Float 15 [_GlossStrength]
Float 16 [_Mask1ReflectionRatio]
Float 17 [_Mask2ReflectionRatio]
Float 18 [_Mask3ReflectionRatio]
Float 19 [_Mask1SpecularGrading]
Float 20 [_Mask2SpecularGrading]
Float 21 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c22, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c23, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c24, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c1
mad r1.xyz, r0, c15.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c22.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c22.y
mul r2.w, r2.y, c22.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c22, r2
mad r2.w, r2.z, c23.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c23.y, c23.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c4
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
add r2.w, r2, -c9.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c23.y, c23.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c2, r4
mad r2.xyz, r7.y, c3, r2
mad r4.xyz, r1.w, c4, r2
endif
mul r2.x, r7.y, c12
mad r2.x, r7, c11, r2
mad_sat r2.x, r1.w, c13, r2
add r3.w, r2.x, c23
texld r2, v1.zwzw, s5
cmp r3.w, r3, c23.z, c23.y
mad r2.xyz, r2, c14, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c20.x
mov_sat r0.w, c19.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c21.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c0
mul r1.xyz, r0.w, c0
mad r0.xyz, r2, r0, r4
mad r2.xyz, r1, c24.x, r0
dp3 r0.x, v4, v4
rsq r0.x, r0.x
dp3 r0.y, v5, v5
mul r1.xyz, r0.x, v4
rsq r0.y, r0.y
mul r0.xyz, r0.y, v5
dp3_sat r0.z, r1, r0
mov_sat r0.w, c17.x
mul r0.y, r7, r0.w
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
add r0.w, -r0.z, c23.z
mad r0.x, r0, r1.w, r0.y
mul r0.xyz, r3, r0.x
mad oC0.xyz, r0, r0.w, r2
mov_pp oC0.w, c23.z
"
}
}
 }
}
Fallback "Diffuse"
}