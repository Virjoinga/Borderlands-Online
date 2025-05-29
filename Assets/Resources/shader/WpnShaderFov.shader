биShader "Custom/WpnShaderFov" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Shininess ("Shininess", Range(0.03,1)) = 0.078125
 _MainTex ("Base (RGB) Gloss (A)", 2D) = "black" {}
 _BumpMap ("Normal map", 2D) = "bump" {}
 _MaskMap ("Mask Map", 2D) = "black" {}
 _CubeMap ("Reflection Cubmap", CUBE) = "_Skybox" { TexGen CubeReflect }
 _KrPara ("Reflect param", Range(0,10)) = 5
 _GlowPara ("Glow Param", Range(0,10)) = 2
 _GlowColor ("Glow Color", Color) = (0.5,0.5,0.5,1)
}
SubShader { 
 LOD 200
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
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
Vector 12 [unity_Scale]
Vector 13 [_BumpMap_ST]
"vs_2_0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r0.xyz, r0, v1.w
dp3 r1.y, r0, c4
dp3 r1.x, v1, c4
dp3 r1.z, v2, c4
mul oT1.xyz, r1, c12.w
dp3 r1.y, r0, c5
dp3 r0.y, r0, c6
dp3 r1.x, v1, c5
dp3 r1.z, v2, c5
mov r0.w, c11.y
mul oT2.xyz, r1, c12.w
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT3.xyz, r0, c12.w
mul r1, c1, r0.w
mov r0.x, c11
mad r1, c0, r0.x, r1
mov r0.x, c11.z
mad r1, c2, r0.x, r1
mov r0.x, c11.w
mad r1, c3, r0.x, r1
mov r0.x, c10.y
dp4 oPos.w, r1, v0
mul r1, c1, r0.x
mov r0.x, c10
mad r1, c0, r0.x, r1
mov r0.x, c10.z
mad r1, c2, r0.x, r1
mov r0.x, c10.w
mad r1, c3, r0.x, r1
mov r0.x, c9.y
dp4 oPos.z, v0, r1
mul r1, c1, r0.x
mov r0.x, c9
mad r1, c0, r0.x, r1
mov r0.x, c9.z
mad r1, c2, r0.x, r1
mov r0.y, c9.w
mad r1, c3, r0.y, r1
mov r0.x, c8.y
mov r2.x, c8
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c8.z
mad r0, c2, r2.x, r0
mov r2.x, c8.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
mad oT0.xy, v3, c13, c13.zwzw
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Float 0 [_Shininess]
SetTexture 0 [_BumpMap] 2D 0
"ps_2_0
dcl_2d s0
def c1, 2.00000000, -1.00000000, 1.00000000, 0.50000000
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r0, t0, s0
mov r0.x, r0.w
mad_pp r1.xy, r0, c1.x, c1.y
mul_pp r0.xy, r1, r1
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c1.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
dp3 r0.z, t3, r1
dp3 r0.x, r1, t1
dp3 r0.y, r1, t2
mad_pp r0.xyz, r0, c1.w, c1.w
mov_pp r0.w, c0.x
mov_pp oC0, r0
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
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_BumpMap_ST]
"vs_2_0
def c29, 0.50000000, 1.00000000, 2.00000000, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r0.w, r0, v0
mov r1.x, c12.y
mov r3.w, c29.y
mov r0.x, c12
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.y, c12.w
mad r2, c3, r0.y, r1
mov r0.x, c13.y
mul r1, c1, r0.x
mov r0.x, c13
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r2
dp4 r0.y, v0, r1
mul r1.xyz, v2, c26.w
mul r2.xyz, r0.xyww, c29.x
dp3 r0.z, r1, c5
mov r3.y, r0.z
mul r2.y, r2, c17.x
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mul r1, r3.xyzz, r3.yzzx
mad oT1.xy, r2.z, c18.zwzw, r2
mul r0.z, r0, r0
dp4 r4.z, r1, c24
dp4 r4.x, r1, c22
dp4 r4.y, r1, c23
mov r2.w, c29.y
dp4 r2.z, r3, c21
dp4 r2.y, r3, c20
dp4 r2.x, r3, c19
add r1.xyz, r2, r4
mov r2.xyz, c16
mad r0.z, r3.x, r3.x, -r0
mul r3.xyz, r0.z, c25
add oT2.xyz, r1, r3
mov r1.xyz, v1
dp4 r4.z, r2, c10
dp4 r4.x, r2, c8
dp4 r4.y, r2, c9
mad r2.xyz, r4, c26.w, -v0
dp3 r2.w, v2, -r2
mul r4.xyz, v2, r2.w
mad r4.xyz, -r4, c29.z, -r2
mul r1.xyz, v2.zxyw, r1.yzxw
mov r3.xyz, v1
mad r3.xyz, v2.yzxw, r3.zxyw, -r1
mov r0.z, c14.y
mul r1, c1, r0.z
mov r0.z, c14.x
mad r1, c0, r0.z, r1
mov r0.z, c14
mad r1, c2, r0.z, r1
mov r0.z, c14.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mul r3.xyz, r3, v1.w
dp3 oT3.z, r4, c6
dp3 oT3.y, r4, c5
dp3 oT3.x, r4, c4
dp3 oT4.y, r2, r3
mov oPos, r0
mov oT1.zw, r0
mov oT4.z, -r2.w
dp3 oT4.x, r2, v1
mad oT0.zw, v3.xyxy, c28.xyxy, c28
mad oT0.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_LightmapST]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
"vs_2_0
def c18, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
dcl_texcoord1 v2
mov r0.x, c11.y
mul r1, c1, r0.x
mov r0.x, c11
mad r1, c0, r0.x, r1
mov r0.x, c11.z
mad r1, c2, r0.x, r1
mov r0.x, c11.w
mad r1, c3, r0.x, r1
dp4 r0.w, r1, v0
mov r0.x, c8.y
mul r1, c1, r0.x
mov r0.x, c8
mad r1, c0, r0.x, r1
mov r0.x, c8.z
mad r1, c2, r0.x, r1
mov r0.x, c8.w
mad r2, c3, r0.x, r1
mov r0.y, c9
mul r1, c1, r0.y
mov r0.x, c9
mad r1, c0, r0.x, r1
mov r0.x, c9.z
mad r1, c2, r0.x, r1
mov r0.x, c9.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r2
dp4 r0.y, v0, r1
mul r2.xyz, r0.xyww, c18.x
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r0.z, c10
mad r1, c2, r0.z, r1
mov r0.z, c10.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov r0.x, c14.w
add r0.y, c18, -r0.x
mul r2.y, r2, c12.x
dp4 r0.x, v0, c2
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
add r1.xyz, r1, -c14
mad oT1.xy, r2.z, c13.zwzw, r2
mov oT1.zw, r0
mul oT3.xyz, r1, c14.w
mad oT0.zw, v1.xyxy, c17.xyxy, c17
mad oT0.xy, v1, c16, c16.zwzw
mad oT2.xy, v2, c15, c15.zwzw
mul oT3.w, -r0.x, r0.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_World2Object]
Matrix 8 [_ProjMat]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c11.y
mul r1, c1, r0.x
mov r0.x, c11
mad r1, c0, r0.x, r1
mov r0.x, c11.z
mad r1, c2, r0.x, r1
mov r0.x, c11.w
mad r0, c3, r0.x, r1
dp4 r0.w, r0, v0
mov r1.x, c8.y
mov r0.x, c8
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c8.z
mad r1, c2, r0.x, r1
mov r0.y, c8.w
mad r2, c3, r0.y, r1
mov r0.x, c9.y
mul r1, c1, r0.x
mov r0.x, c9
mad r1, c0, r0.x, r1
mov r0.x, c9.z
mad r1, c2, r0.x, r1
mov r0.x, c9.w
mad r1, c3, r0.x, r1
dp4 r0.y, v0, r1
dp4 r0.x, v0, r2
mul r1.xyz, r0.xyww, c19.x
mul r1.y, r1, c13.x
mad oT1.xy, r1.z, c14.zwzw, r1
mov r1.w, c19.y
mov r1.xyz, c12
dp4 r2.z, r1, c6
dp4 r2.x, r1, c4
dp4 r2.y, r1, c5
mad r2.xyz, r2, c15.w, -v0
mov r1.xyz, v1
mul r1.xyz, v2.zxyw, r1.yzxw
mov r3.xyz, v1
mad r3.xyz, v2.yzxw, r3.zxyw, -r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r0.z, c10
mad r1, c2, r0.z, r1
mov r0.z, c10.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mul r3.xyz, r3, v1.w
dp3 oT3.y, r2, r3
mov oPos, r0
mov oT1.zw, r0
dp3 oT3.z, v2, r2
dp3 oT3.x, r2, v1
mad oT0.zw, v3.xyxy, c18.xyxy, c18
mad oT0.xy, v3, c17, c17.zwzw
mad oT2.xy, v4, c16, c16.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_BumpMap_ST]
"vs_2_0
def c29, 0.50000000, 1.00000000, 2.00000000, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r0.w, r0, v0
mov r1.x, c12.y
mov r3.w, c29.y
mov r0.x, c12
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.y, c12.w
mad r2, c3, r0.y, r1
mov r0.x, c13.y
mul r1, c1, r0.x
mov r0.x, c13
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r2
dp4 r0.y, v0, r1
mul r1.xyz, v2, c26.w
mul r2.xyz, r0.xyww, c29.x
dp3 r0.z, r1, c5
mov r3.y, r0.z
mul r2.y, r2, c17.x
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mul r1, r3.xyzz, r3.yzzx
mad oT1.xy, r2.z, c18.zwzw, r2
mul r0.z, r0, r0
dp4 r4.z, r1, c24
dp4 r4.x, r1, c22
dp4 r4.y, r1, c23
mov r2.w, c29.y
dp4 r2.z, r3, c21
dp4 r2.y, r3, c20
dp4 r2.x, r3, c19
add r1.xyz, r2, r4
mov r2.xyz, c16
mad r0.z, r3.x, r3.x, -r0
mul r3.xyz, r0.z, c25
add oT2.xyz, r1, r3
mov r1.xyz, v1
dp4 r4.z, r2, c10
dp4 r4.x, r2, c8
dp4 r4.y, r2, c9
mad r2.xyz, r4, c26.w, -v0
dp3 r2.w, v2, -r2
mul r4.xyz, v2, r2.w
mad r4.xyz, -r4, c29.z, -r2
mul r1.xyz, v2.zxyw, r1.yzxw
mov r3.xyz, v1
mad r3.xyz, v2.yzxw, r3.zxyw, -r1
mov r0.z, c14.y
mul r1, c1, r0.z
mov r0.z, c14.x
mad r1, c0, r0.z, r1
mov r0.z, c14
mad r1, c2, r0.z, r1
mov r0.z, c14.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mul r3.xyz, r3, v1.w
dp3 oT3.z, r4, c6
dp3 oT3.y, r4, c5
dp3 oT3.x, r4, c4
dp3 oT4.y, r2, r3
mov oPos, r0
mov oT1.zw, r0
mov oT4.z, -r2.w
dp3 oT4.x, r2, v1
mad oT0.zw, v3.xyxy, c28.xyxy, c28
mad oT0.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_LightmapST]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
"vs_2_0
def c18, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
dcl_texcoord1 v2
mov r0.x, c11.y
mul r1, c1, r0.x
mov r0.x, c11
mad r1, c0, r0.x, r1
mov r0.x, c11.z
mad r1, c2, r0.x, r1
mov r0.x, c11.w
mad r1, c3, r0.x, r1
dp4 r0.w, r1, v0
mov r0.x, c8.y
mul r1, c1, r0.x
mov r0.x, c8
mad r1, c0, r0.x, r1
mov r0.x, c8.z
mad r1, c2, r0.x, r1
mov r0.x, c8.w
mad r2, c3, r0.x, r1
mov r0.y, c9
mul r1, c1, r0.y
mov r0.x, c9
mad r1, c0, r0.x, r1
mov r0.x, c9.z
mad r1, c2, r0.x, r1
mov r0.x, c9.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r2
dp4 r0.y, v0, r1
mul r2.xyz, r0.xyww, c18.x
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r0.z, c10
mad r1, c2, r0.z, r1
mov r0.z, c10.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov r0.x, c14.w
add r0.y, c18, -r0.x
mul r2.y, r2, c12.x
dp4 r0.x, v0, c2
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
add r1.xyz, r1, -c14
mad oT1.xy, r2.z, c13.zwzw, r2
mov oT1.zw, r0
mul oT3.xyz, r1, c14.w
mad oT0.zw, v1.xyxy, c17.xyxy, c17
mad oT0.xy, v1, c16, c16.zwzw
mad oT2.xy, v2, c15, c15.zwzw
mul oT3.w, -r0.x, r0.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_World2Object]
Matrix 8 [_ProjMat]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c11.y
mul r1, c1, r0.x
mov r0.x, c11
mad r1, c0, r0.x, r1
mov r0.x, c11.z
mad r1, c2, r0.x, r1
mov r0.x, c11.w
mad r0, c3, r0.x, r1
dp4 r0.w, r0, v0
mov r1.x, c8.y
mov r0.x, c8
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c8.z
mad r1, c2, r0.x, r1
mov r0.y, c8.w
mad r2, c3, r0.y, r1
mov r0.x, c9.y
mul r1, c1, r0.x
mov r0.x, c9
mad r1, c0, r0.x, r1
mov r0.x, c9.z
mad r1, c2, r0.x, r1
mov r0.x, c9.w
mad r1, c3, r0.x, r1
dp4 r0.y, v0, r1
dp4 r0.x, v0, r2
mul r1.xyz, r0.xyww, c19.x
mul r1.y, r1, c13.x
mad oT1.xy, r1.z, c14.zwzw, r1
mov r1.w, c19.y
mov r1.xyz, c12
dp4 r2.z, r1, c6
dp4 r2.x, r1, c4
dp4 r2.y, r1, c5
mad r2.xyz, r2, c15.w, -v0
mov r1.xyz, v1
mul r1.xyz, v2.zxyw, r1.yzxw
mov r3.xyz, v1
mad r3.xyz, v2.yzxw, r3.zxyw, -r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r0.z, c10
mad r1, c2, r0.z, r1
mov r0.z, c10.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mul r3.xyz, r3, v1.w
dp3 oT3.y, r2, r3
mov oPos, r0
mov oT1.zw, r0
dp3 oT3.z, v2, r2
dp3 oT3.x, r2, v1
mad oT0.zw, v3.xyxy, c18.xyxy, c18
mad oT0.xy, v3, c17, c17.zwzw
mad oT2.xy, v4, c16, c16.zwzw
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_GlowColor]
Float 2 [_KrPara]
Float 3 [_GlowPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightBuffer] 2D 2
SetTexture 3 [_MaskMap] 2D 3
SetTexture 4 [_CubeMap] CUBE 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 0.12298584, 0, 0, 0
dcl t0
dcl t1
dcl t2.xyz
dcl t3.xyz
dcl t4.xyz
texld r3, t3, s4
texld r5, t0, s0
texld r4, t0, s3
texldp r2, t1, s2
mov r0.y, t0.w
mov r0.x, t0.z
log_pp r2.x, r2.x
log_pp r2.z, r2.z
log_pp r2.y, r2.y
add_pp r2.xyz, -r2, t2
mul_pp r5.xyz, r5, c0
texld r0, r0, s1
mov r0.x, r0.w
mad_pp r6.xy, r0, c4.x, c4.y
mul_pp r0.xy, r6, r6
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r6.z, r0.x
dp3_pp r0.x, r6, r6
rsq_pp r1.x, r0.x
dp3 r0.x, t4, t4
rsq r0.x, r0.x
mul_pp r1.xyz, r1.x, r6
mul r0.xyz, r0.x, t4
dp3 r0.x, r0, r1
log_pp r1.x, r2.w
mul_pp r1.xyz, r2, -r1.x
mul_pp r1.xyz, r1, r4.x
mad_pp r1.xyz, r5, r2, r1
max r0.x, r0, c4.w
add r0.x, -r0, c4.z
mul_pp r2.xyz, r4.z, r3
mul r2.xyz, r2, r0.x
mul r0.x, r4.y, c3
mul r2.xyz, r2, c2.x
mul r0.xyz, r0.x, c1
add_pp r1.xyz, r1, r2
add_pp r0.xyz, r1, r0
mov_pp r0.w, c5.x
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [unity_LightmapFade]
SetTexture 0 [_MainTex] 2D 0
SetTexture 2 [_LightBuffer] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
SetTexture 4 [unity_LightmapInd] 2D 4
SetTexture 5 [_MaskMap] 2D 5
"ps_2_0
dcl_2d s0
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c2, 8.00000000, 0.12298584, 0, 0
dcl t0.xy
dcl t1
dcl t2.xy
dcl t3
texld r2, t0, s0
texld r5, t0, s5
texldp r1, t1, s2
texld r0, t2, s3
texld r3, t2, s4
mul_pp r4.xyz, r0.w, r0
mul_pp r3.xyz, r3.w, r3
mul_pp r3.xyz, r3, c2.x
dp4 r0.x, t3, t3
rsq r0.x, r0.x
rcp r0.x, r0.x
mad_sat r0.x, r0, c1.z, c1.w
mad_pp r4.xyz, r4, c2.x, -r3
mad_pp r3.xyz, r0.x, r4, r3
log_pp r0.x, r1.w
log_pp r1.x, r1.x
log_pp r1.y, r1.y
log_pp r1.z, r1.z
add_pp r1.xyz, -r1, r3
mul_pp r0.xyz, r1, -r0.x
mul_pp r0.xyz, r0, r5.x
mul_pp r2.xyz, r2, c0
mad_pp r0.xyz, r2, r1, r0
mov_pp r0.w, c2.y
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Float 1 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightBuffer] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
SetTexture 4 [unity_LightmapInd] 2D 4
SetTexture 5 [_MaskMap] 2D 5
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c2, 2.00000000, -1.00000000, 1.00000000, 8.00000000
def c3, -0.40824828, -0.70710677, 0.57735026, 0.00000000
def c4, -0.40824831, 0.70710677, 0.57735026, 128.00000000
def c5, 0.81649655, 0.00000000, 0.57735026, 0.12298584
dcl t0
dcl t1
dcl t2.xy
dcl t3.xyz
texld r2, t0, s5
texld r1, t0, s0
texldp r3, t1, s2
texld r4, t2, s3
texld r5, t2, s4
mul_pp r5.xyz, r5.w, r5
mul_pp r5.xyz, r5, c2.w
mul r6.xyz, r5.y, c4
mad r6.xyz, r5.x, c5, r6
mad r6.xyz, r5.z, c3, r6
log_pp r3.x, r3.x
log_pp r3.y, r3.y
log_pp r3.z, r3.z
mov r0.y, t0.w
mov r0.x, t0.z
mul_pp r4.xyz, r4.w, r4
log_pp r3.w, r3.w
mul_pp r1.xyz, r1, c0
texld r0, r0, s1
dp3 r0.x, r6, r6
rsq r0.x, r0.x
mul r6.xyz, r0.x, r6
mov r0.x, r0.w
mad_pp r8.xy, r0, c2.x, c2.y
dp3_pp r0.x, t3, t3
rsq_pp r0.x, r0.x
mad_pp r0.xyz, r0.x, t3, r6
mul_pp r7.xy, r8, r8
add_pp_sat r6.x, r7, r7.y
dp3_pp r7.x, r0, r0
rsq_pp r7.x, r7.x
add_pp r6.x, -r6, c2.z
rsq_pp r6.x, r6.x
rcp_pp r8.z, r6.x
mul_pp r0.xyz, r7.x, r0
dp3_pp r0.x, r8, r0
mov_pp r6.x, c1
max_pp r0.x, r0, c3.w
mul_pp r6.x, c4.w, r6
pow r7.x, r0.x, r6.x
dp3_pp_sat r0.z, r8, c3
dp3_pp_sat r0.y, r8, c4
dp3_pp_sat r0.x, r8, c5
dp3_pp r0.x, r0, r5
mul_pp r0.xyz, r4, r0.x
mov r0.w, r7.x
mul_pp r0.xyz, r0, c2.w
add_pp r0, -r3, r0
mul_pp r3.xyz, r0, r0.w
mul_pp r2.xyz, r3, r2.x
mad_pp r0.xyz, r1, r0, r2
mov_pp r0.w, c5
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_GlowColor]
Float 2 [_KrPara]
Float 3 [_GlowPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightBuffer] 2D 2
SetTexture 3 [_MaskMap] 2D 3
SetTexture 4 [_CubeMap] CUBE 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 0.12298584, 0, 0, 0
dcl t0
dcl t1
dcl t2.xyz
dcl t3.xyz
dcl t4.xyz
texld r2, t3, s4
texld r4, t0, s0
texld r3, t0, s3
texldp r1, t1, s2
add_pp r1.xyz, r1, t2
mov r0.y, t0.w
mov r0.x, t0.z
mul_pp r4.xyz, r4, c0
mul_pp r2.xyz, r3.z, r2
texld r0, r0, s1
mov r0.x, r0.w
mad_pp r5.xy, r0, c4.x, c4.y
mul_pp r0.xy, r5, r5
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r5.z, r0.x
dp3_pp r0.x, r5, r5
rsq_pp r0.x, r0.x
mul_pp r5.xyz, r0.x, r5
dp3 r0.x, t4, t4
rsq r0.x, r0.x
mul r0.xyz, r0.x, t4
dp3 r0.x, r0, r5
mul_pp r5.xyz, r1, r1.w
mul_pp r5.xyz, r5, r3.x
max r0.x, r0, c4.w
add r0.x, -r0, c4.z
mul r2.xyz, r2, r0.x
mul r0.x, r3.y, c3
mad_pp r1.xyz, r4, r1, r5
mul r2.xyz, r2, c2.x
mul r0.xyz, r0.x, c1
add_pp r1.xyz, r1, r2
add_pp r0.xyz, r1, r0
mov_pp r0.w, c5.x
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [unity_LightmapFade]
SetTexture 0 [_MainTex] 2D 0
SetTexture 2 [_LightBuffer] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
SetTexture 4 [unity_LightmapInd] 2D 4
SetTexture 5 [_MaskMap] 2D 5
"ps_2_0
dcl_2d s0
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c2, 8.00000000, 0.12298584, 0, 0
dcl t0.xy
dcl t1
dcl t2.xy
dcl t3
texld r2, t0, s0
texld r5, t0, s5
texldp r1, t1, s2
texld r0, t2, s3
texld r3, t2, s4
mul_pp r4.xyz, r0.w, r0
dp4 r0.x, t3, t3
mul_pp r3.xyz, r3.w, r3
mul_pp r3.xyz, r3, c2.x
rsq r0.x, r0.x
rcp r0.x, r0.x
mad_pp r4.xyz, r4, c2.x, -r3
mad_sat r0.x, r0, c1.z, c1.w
mad_pp r0.xyz, r0.x, r4, r3
add_pp r0.xyz, r1, r0
mul_pp r1.xyz, r0, r1.w
mul_pp r1.xyz, r1, r5.x
mul_pp r2.xyz, r2, c0
mad_pp r0.xyz, r2, r0, r1
mov_pp r0.w, c2.y
mov_pp oC0, r0
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Float 1 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightBuffer] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
SetTexture 4 [unity_LightmapInd] 2D 4
SetTexture 5 [_MaskMap] 2D 5
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c2, 2.00000000, -1.00000000, 1.00000000, 8.00000000
def c3, -0.40824828, -0.70710677, 0.57735026, 0.00000000
def c4, -0.40824831, 0.70710677, 0.57735026, 128.00000000
def c5, 0.81649655, 0.00000000, 0.57735026, 0.12298584
dcl t0
dcl t1
dcl t2.xy
dcl t3.xyz
texld r2, t0, s5
texld r1, t0, s0
texldp r3, t1, s2
texld r4, t2, s3
texld r5, t2, s4
mul_pp r5.xyz, r5.w, r5
mul_pp r5.xyz, r5, c2.w
mul r6.xyz, r5.y, c4
mad r6.xyz, r5.x, c5, r6
mad r6.xyz, r5.z, c3, r6
mov r0.y, t0.w
mov r0.x, t0.z
mul_pp r4.xyz, r4.w, r4
mul_pp r1.xyz, r1, c0
texld r0, r0, s1
dp3 r0.x, r6, r6
rsq r0.x, r0.x
mul r6.xyz, r0.x, r6
mov r0.x, r0.w
mad_pp r8.xy, r0, c2.x, c2.y
dp3_pp r0.x, t3, t3
rsq_pp r0.x, r0.x
mad_pp r0.xyz, r0.x, t3, r6
mul_pp r7.xy, r8, r8
add_pp_sat r6.x, r7, r7.y
dp3_pp r7.x, r0, r0
rsq_pp r7.x, r7.x
add_pp r6.x, -r6, c2.z
rsq_pp r6.x, r6.x
rcp_pp r8.z, r6.x
mul_pp r0.xyz, r7.x, r0
dp3_pp r0.x, r8, r0
mov_pp r6.x, c1
max_pp r0.x, r0, c3.w
mul_pp r6.x, c4.w, r6
pow r7.x, r0.x, r6.x
dp3_pp_sat r0.z, r8, c3
dp3_pp_sat r0.y, r8, c4
dp3_pp_sat r0.x, r8, c5
dp3_pp r0.x, r0, r5
mul_pp r0.xyz, r4, r0.x
mov r0.w, r7.x
mul_pp r0.xyz, r0, c2.w
add_pp r0, r3, r0
mul_pp r3.xyz, r0, r0.w
mul_pp r2.xyz, r3, r2.x
mad_pp r0.xyz, r1, r0, r2
mov_pp r0.w, c5
mov_pp oC0, r0
"
}
}
 }
}
Fallback "Diffuse"
}