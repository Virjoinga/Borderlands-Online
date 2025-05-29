»≈Shader "Custom/BOL_Wpn_MaskReflectFov" {
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
 _GlossStrength ("Gloss Strength", Range(0,1)) = 0.5
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
 _DecalRotate ("Decal Rotation", Float) = 0
 _DecalChannel ("Decal Mask Channel", Vector) = (0,0,0,0)
 _UseFullColorDecal ("Use Full Color Decal", Float) = 0
 _Effect_Para ("Effect Para", Float) = 0
 _Effect_Color ("Effect Color", Color) = (1,1,1,1)
}
SubShader { 
 LOD 400
 Tags { "QUEUE"="Geometry+2" "RenderType"="Opaque" }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "QUEUE"="Geometry+2" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
Vector 13 [unity_Scale]
Vector 14 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.modelview[0],
		program.local[5..14] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R1, c[2];
MOV R0, c[1];
MUL R3, R1, c[11].y;
MUL R2, R1, c[12].y;
MAD R5, R0, c[11].x, R3;
MAD R3, R0, c[12].x, R2;
MOV R2, c[3];
MAD R4, R2, c[12].z, R3;
MOV R3, c[4];
MAD R4, R3, c[12].w, R4;
MAD R5, R2, c[11].z, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R1, c[10].y;
MAD R4, R0, c[10].x, R4;
MUL R1, R1, c[9].y;
MAD R0, R0, c[9].x, R1;
MAD R5, R3, c[11].w, R5;
MAD R4, R2, c[10].z, R4;
MAD R1, R3, c[10].w, R4;
MAD R0, R2, c[9].z, R0;
DP4 result.position.y, vertex.position, R1;
MUL R1.xyz, vertex.normal, c[13].w;
MAD R0, R3, c[9].w, R0;
DP4 result.position.z, vertex.position, R5;
DP4 result.position.x, vertex.position, R0;
DP3 result.texcoord[1].z, R1, c[7];
DP3 result.texcoord[1].y, R1, c[6];
DP3 result.texcoord[1].x, R1, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[14], c[14].zwzw;
END
# 29 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
Vector 12 [unity_Scale]
Vector 13 [_MaskTex_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r0.x, c11.y
mul r1, c1, r0.x
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
mov r0.x, c9.w
mad r1, c3, r0.x, r1
mov r0.x, c8.y
dp4 oPos.y, v0, r1
mul r1, c1, r0.x
mov r0.x, c8
mad r1, c0, r0.x, r1
mov r0.x, c8.z
mad r1, c2, r0.x, r1
mov r0.x, c8.w
mad r0, c3, r0.x, r1
mul r1.xyz, v1, c12.w
dp4 oPos.x, v0, r0
dp3 oT1.z, r1, c6
dp3 oT1.y, r1, c5
dp3 oT1.x, r1, c4
mad oT0.xy, v2, c13, c13.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_Mask1SpecularShininess]
Float 1 [_Mask2SpecularShininess]
Float 2 [_Mask3SpecularShininess]
Float 3 [_GlossSpecularShininess]
SetTexture 0 [_MaskTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1, 0.0099999998, 0.5 } };
TEMP R0;
TEMP R1;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
ADD R0.w, -R0.x, -R0.y;
ADD R0.w, -R0.z, R0;
MOV_SAT R1.x, c[1];
MUL R1.x, R0.y, R1;
MOV_SAT R0.y, c[0].x;
MAD R0.y, R0.x, R0, R1.x;
ADD R0.w, R0, c[4].x;
MOV_SAT R0.x, c[2];
MAD R0.y, R0.x, R0.w, R0;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.w, R1.x;
MOV_SAT R0.x, c[3];
MAD R0.x, R0, R0.z, R0.y;
MUL R1.xyz, R0.w, fragment.texcoord[1];
ADD result.color.w, R0.x, c[4].y;
MAD result.color.xyz, R1, c[4].z, c[4].z;
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_Mask1SpecularShininess]
Float 1 [_Mask2SpecularShininess]
Float 2 [_Mask3SpecularShininess]
Float 3 [_GlossSpecularShininess]
SetTexture 0 [_MaskTex] 2D 0
"ps_2_0
dcl_2d s0
def c4, 1.00000000, 0.01000000, 0.50000000, 0
dcl t0.xy
dcl t1.xyz
texld r4, t0, s0
mov_sat r1.x, c1
mul r3.x, r4.y, r1
add r0.x, -r4, -r4.y
add r0.x, -r4.z, r0
dp3 r1.x, t1, t1
mov_sat r2.x, c0
mad r2.x, r4, r2, r3
rsq r1.x, r1.x
add r0.x, r0, c4
mov_sat r3.x, c2
mad r0.x, r3, r0, r2
mul r2.xyz, r1.x, t1
mov_sat r1.x, c3
mad r0.x, r1, r4.z, r0
mad r1.xyz, r2, c4.z, c4.z
add r1.w, r0.x, c4.y
mov_pp oC0, r1
"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "QUEUE"="Geometry+2" "RenderType"="Opaque" }
  ZWrite Off
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[38] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..34],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[32];
FRC R1.z, R0.x;
SLT R0, R1.z, c[35];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[35].xxzz;
DP3 R1.x, R2, c[35].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.zzww, c[37].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
MUL R2.y, R6.w, c[34].x;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.zw, R1.xyxy, R1;
MUL R1.x, R6.w, c[33];
FRC R2.x, R1;
SLT R1, R2.x, c[35];
FRC R4.w, R2.y;
MOV R0.x, -R0.w;
MOV R0.y, R0.z;
MUL R0.xy, vertex.position.z, R0;
MAD R5.xy, vertex.position.y, R0.zwzw, R0;
ADD R0.xyz, R1.yzww, -R1;
MOV R1.yzw, R0.xxyz;
DP4 R0.w, R1, c[35].xxzz;
DP3 R0.z, R0, c[35].yyww;
ADD R0.xy, R2.x, -R0.zwzw;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[35];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[36].xyxy, c[36].zwzw;
MAD R2, R2, R3.zzww, c[37].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[35].yyww;
DP4 R5.w, R0, c[35].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.xxyy, c[37].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[35].y;
MUL R4.w, R6, c[30].x;
MUL R4.y, R4, c[18].x;
MOV R1.w, c[0].z;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[35];
MOV R3.x, R4;
RCP R5.y, c[31].y;
RCP R5.x, c[31].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[31];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[35].xxzz;
DP3 R4.z, R5, c[35].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[36].xyxy, c[36].zwzw;
MAD R0, R0, R1.xxyy, c[37].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[26].w;
DP3 R4.z, R2, c[7];
MUL R1.xy, vertex.position.zyzw, c[29];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[29].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[35].y;
MOV R1.z, R4;
DP3 R4.x, R2, c[5];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
DP3 R0.zw, R2, c[6];
ADD result.texcoord[1].xy, R0, c[35].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R4;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R3.z, R1, c[21];
DP4 R3.y, R1, c[20];
DP4 R3.x, R1, c[19];
DP4 R1.z, R2, c[24];
DP4 R1.x, R2, c[22];
DP4 R1.y, R2, c[23];
ADD R2.xyz, R3, R1;
MOV R1.xyz, c[17];
MOV R1.w, c[0].z;
DP4 R3.z, R1, c[11];
DP4 R3.x, R1, c[9];
DP4 R3.y, R1, c[10];
MAD R1.xyz, R3, c[26].w, -vertex.position;
DP3 R0.y, vertex.normal, -R1;
MUL R3.xyz, vertex.normal, R0.y;
MAD R1.xyz, -R3, c[37].z, -R1;
MAD R0.x, R4, R4, -R0;
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[3].xyz, R2, R0;
MOV R4.w, R6.z;
MOV R4.y, R0.w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R1, c[7];
DP3 result.texcoord[6].y, R1, c[6];
DP3 result.texcoord[6].x, R1, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[17];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
MOV result.texcoord[3].w, R6.z;
MOV result.texcoord[4].w, R6.z;
END
# 162 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c35, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c36, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c26.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r0, c2, r0.x, r2
mov r1.y, c12.w
mad r2, c3, r1.y, r0
mov r1.x, c13.y
mul r0, c1, r1.x
mov r1.x, c13
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c35.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mul r0.y, r0, c17.x
mad o3.xy, r0.z, c18.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c36.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c21
dp4 r4.y, r2, c20
dp4 r4.x, r2, c19
dp4 r2.z, r3, c24
dp4 r2.x, r3, c22
dp4 r2.y, r3, c23
add r2.xyz, r4, r2
mov r3.w, c36.y
mov r3.xyz, c16
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c26.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c36.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c25
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mad r2, c0, r0.x, r2
mov r0.x, c14.z
mad r2, c2, r0.x, r2
mov r0.y, c32.x
mad r0.y, r0, c35.x, c35
frc r0.y, r0
mov r0.z, c33.x
mad r0.z, r0, c35.x, c35.y
frc r0.z, r0
mad r0.y, r0, c35.z, c35.w
mov r0.x, c14.w
mad r0.z, r0, c35, c35.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c3, r0.x, r2
dp4 r1.z, v0, r3
mov o0, r1
sincos r2.xy, r0.y
sincos r3.xy, r0.z
mov r1.x, c34
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
mad r1.x, r0.z, c35.z, c35.w
rcp r0.z, r3.x
mov r0.x, -r2.y
mov r0.y, r2.x
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
sincos r2.xy, r1.x
mul r0.z, r3.y, r0
mov r1.x, c30
mad r0.x, r0.y, r0.z, r0
rcp r0.z, r2.x
mul r0.z, r2.y, r0
mad r0.y, r0.x, r0.z, r0
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
rcp r1.y, c31.y
rcp r1.x, c31.x
mad o2.zw, r0.xyxy, r1.xyxy, c31
mad r0.x, r0.z, c35.z, c35.w
mov o3.zw, r1
sincos r1.xy, r0.x
mul r0.xy, v0.zyzw, c29
mul r0.xy, r0, c36
add r0.xy, r0, c29.zwzw
add r0.xy, r0, c36.z
mov r1.z, r1.x
mov r1.w, -r1.y
mul r1.zw, r0.xyxy, r1
mul r1.xy, r1.yxzw, r0
add r0.x, r1.z, r1.w
add r0.y, r1.x, r1
add o2.xy, r0, c35.y
mov r5.w, r4
mov r5.y, r0.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
add o5.xyz, -r0, c16
mad o1.zw, v2.xyxy, c28.xyxy, c28
mad o1.xy, v2, c27, c27.zwzw
mov o4.w, r4
mov o5.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[38] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..34],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[32];
FRC R1.z, R0.x;
SLT R0, R1.z, c[35];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[35].xxzz;
DP3 R1.x, R2, c[35].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.zzww, c[37].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
MUL R2.y, R6.w, c[34].x;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.zw, R1.xyxy, R1;
MUL R1.x, R6.w, c[33];
FRC R2.x, R1;
SLT R1, R2.x, c[35];
FRC R4.w, R2.y;
MOV R0.x, -R0.w;
MOV R0.y, R0.z;
MUL R0.xy, vertex.position.z, R0;
MAD R5.xy, vertex.position.y, R0.zwzw, R0;
ADD R0.xyz, R1.yzww, -R1;
MOV R1.yzw, R0.xxyz;
DP4 R0.w, R1, c[35].xxzz;
DP3 R0.z, R0, c[35].yyww;
ADD R0.xy, R2.x, -R0.zwzw;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[35];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[36].xyxy, c[36].zwzw;
MAD R2, R2, R3.zzww, c[37].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[35].yyww;
DP4 R5.w, R0, c[35].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.xxyy, c[37].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[35].y;
MUL R4.w, R6, c[30].x;
MUL R4.y, R4, c[18].x;
MOV R1.w, c[0].z;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[35];
MOV R3.x, R4;
RCP R5.y, c[31].y;
RCP R5.x, c[31].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[31];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[35].xxzz;
DP3 R4.z, R5, c[35].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[36].xyxy, c[36].zwzw;
MAD R0, R0, R1.xxyy, c[37].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[26].w;
DP3 R4.z, R2, c[7];
MUL R1.xy, vertex.position.zyzw, c[29];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[29].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[35].y;
MOV R1.z, R4;
DP3 R4.x, R2, c[5];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
DP3 R0.zw, R2, c[6];
ADD result.texcoord[1].xy, R0, c[35].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R4;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R3.z, R1, c[21];
DP4 R3.y, R1, c[20];
DP4 R3.x, R1, c[19];
DP4 R1.z, R2, c[24];
DP4 R1.x, R2, c[22];
DP4 R1.y, R2, c[23];
ADD R2.xyz, R3, R1;
MOV R1.xyz, c[17];
MOV R1.w, c[0].z;
DP4 R3.z, R1, c[11];
DP4 R3.x, R1, c[9];
DP4 R3.y, R1, c[10];
MAD R1.xyz, R3, c[26].w, -vertex.position;
DP3 R0.y, vertex.normal, -R1;
MUL R3.xyz, vertex.normal, R0.y;
MAD R1.xyz, -R3, c[37].z, -R1;
MAD R0.x, R4, R4, -R0;
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[3].xyz, R2, R0;
MOV R4.w, R6.z;
MOV R4.y, R0.w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R1, c[7];
DP3 result.texcoord[6].y, R1, c[6];
DP3 result.texcoord[6].x, R1, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[17];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
MOV result.texcoord[3].w, R6.z;
MOV result.texcoord[4].w, R6.z;
END
# 162 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c35, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c36, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c26.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r0, c2, r0.x, r2
mov r1.y, c12.w
mad r2, c3, r1.y, r0
mov r1.x, c13.y
mul r0, c1, r1.x
mov r1.x, c13
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c35.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mul r0.y, r0, c17.x
mad o3.xy, r0.z, c18.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c36.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c21
dp4 r4.y, r2, c20
dp4 r4.x, r2, c19
dp4 r2.z, r3, c24
dp4 r2.x, r3, c22
dp4 r2.y, r3, c23
add r2.xyz, r4, r2
mov r3.w, c36.y
mov r3.xyz, c16
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c26.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c36.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c25
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mad r2, c0, r0.x, r2
mov r0.x, c14.z
mad r2, c2, r0.x, r2
mov r0.y, c32.x
mad r0.y, r0, c35.x, c35
frc r0.y, r0
mov r0.z, c33.x
mad r0.z, r0, c35.x, c35.y
frc r0.z, r0
mad r0.y, r0, c35.z, c35.w
mov r0.x, c14.w
mad r0.z, r0, c35, c35.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c3, r0.x, r2
dp4 r1.z, v0, r3
mov o0, r1
sincos r2.xy, r0.y
sincos r3.xy, r0.z
mov r1.x, c34
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
mad r1.x, r0.z, c35.z, c35.w
rcp r0.z, r3.x
mov r0.x, -r2.y
mov r0.y, r2.x
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
sincos r2.xy, r1.x
mul r0.z, r3.y, r0
mov r1.x, c30
mad r0.x, r0.y, r0.z, r0
rcp r0.z, r2.x
mul r0.z, r2.y, r0
mad r0.y, r0.x, r0.z, r0
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
rcp r1.y, c31.y
rcp r1.x, c31.x
mad o2.zw, r0.xyxy, r1.xyxy, c31
mad r0.x, r0.z, c35.z, c35.w
mov o3.zw, r1
sincos r1.xy, r0.x
mul r0.xy, v0.zyzw, c29
mul r0.xy, r0, c36
add r0.xy, r0, c29.zwzw
add r0.xy, r0, c36.z
mov r1.z, r1.x
mov r1.w, -r1.y
mul r1.zw, r0.xyxy, r1
mul r1.xy, r1.yxzw, r0
add r0.x, r1.z, r1.w
add r0.y, r1.x, r1
add o2.xy, r0, c35.y
mov r5.w, r4
mov r5.y, r0.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
add o5.xyz, -r0, c16
mad o1.zw, v2.xyxy, c28.xyxy, c28
mad o1.xy, v2, c27, c27.zwzw
mov o4.w, r4
mov o5.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[38] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..34],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[32];
FRC R1.z, R0.x;
SLT R0, R1.z, c[35];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[35].xxzz;
DP3 R1.x, R2, c[35].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.zzww, c[37].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
MUL R2.y, R6.w, c[34].x;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.zw, R1.xyxy, R1;
MUL R1.x, R6.w, c[33];
FRC R2.x, R1;
SLT R1, R2.x, c[35];
FRC R4.w, R2.y;
MOV R0.x, -R0.w;
MOV R0.y, R0.z;
MUL R0.xy, vertex.position.z, R0;
MAD R5.xy, vertex.position.y, R0.zwzw, R0;
ADD R0.xyz, R1.yzww, -R1;
MOV R1.yzw, R0.xxyz;
DP4 R0.w, R1, c[35].xxzz;
DP3 R0.z, R0, c[35].yyww;
ADD R0.xy, R2.x, -R0.zwzw;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[35];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[36].xyxy, c[36].zwzw;
MAD R2, R2, R3.zzww, c[37].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[35].yyww;
DP4 R5.w, R0, c[35].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.xxyy, c[37].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[35].y;
MUL R4.w, R6, c[30].x;
MUL R4.y, R4, c[18].x;
MOV R1.w, c[0].z;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[35];
MOV R3.x, R4;
RCP R5.y, c[31].y;
RCP R5.x, c[31].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[31];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[35].xxzz;
DP3 R4.z, R5, c[35].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[36].xyxy, c[36].zwzw;
MAD R0, R0, R1.xxyy, c[37].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[26].w;
DP3 R4.z, R2, c[7];
MUL R1.xy, vertex.position.zyzw, c[29];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[29].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[35].y;
MOV R1.z, R4;
DP3 R4.x, R2, c[5];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
DP3 R0.zw, R2, c[6];
ADD result.texcoord[1].xy, R0, c[35].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R4;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R3.z, R1, c[21];
DP4 R3.y, R1, c[20];
DP4 R3.x, R1, c[19];
DP4 R1.z, R2, c[24];
DP4 R1.x, R2, c[22];
DP4 R1.y, R2, c[23];
ADD R2.xyz, R3, R1;
MOV R1.xyz, c[17];
MOV R1.w, c[0].z;
DP4 R3.z, R1, c[11];
DP4 R3.x, R1, c[9];
DP4 R3.y, R1, c[10];
MAD R1.xyz, R3, c[26].w, -vertex.position;
DP3 R0.y, vertex.normal, -R1;
MUL R3.xyz, vertex.normal, R0.y;
MAD R1.xyz, -R3, c[37].z, -R1;
MAD R0.x, R4, R4, -R0;
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[3].xyz, R2, R0;
MOV R4.w, R6.z;
MOV R4.y, R0.w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R1, c[7];
DP3 result.texcoord[6].y, R1, c[6];
DP3 result.texcoord[6].x, R1, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[17];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
MOV result.texcoord[3].w, R6.z;
MOV result.texcoord[4].w, R6.z;
END
# 162 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c35, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c36, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c26.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r0, c2, r0.x, r2
mov r1.y, c12.w
mad r2, c3, r1.y, r0
mov r1.x, c13.y
mul r0, c1, r1.x
mov r1.x, c13
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c35.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mul r0.y, r0, c17.x
mad o3.xy, r0.z, c18.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c36.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c21
dp4 r4.y, r2, c20
dp4 r4.x, r2, c19
dp4 r2.z, r3, c24
dp4 r2.x, r3, c22
dp4 r2.y, r3, c23
add r2.xyz, r4, r2
mov r3.w, c36.y
mov r3.xyz, c16
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c26.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c36.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c25
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mad r2, c0, r0.x, r2
mov r0.x, c14.z
mad r2, c2, r0.x, r2
mov r0.y, c32.x
mad r0.y, r0, c35.x, c35
frc r0.y, r0
mov r0.z, c33.x
mad r0.z, r0, c35.x, c35.y
frc r0.z, r0
mad r0.y, r0, c35.z, c35.w
mov r0.x, c14.w
mad r0.z, r0, c35, c35.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c3, r0.x, r2
dp4 r1.z, v0, r3
mov o0, r1
sincos r2.xy, r0.y
sincos r3.xy, r0.z
mov r1.x, c34
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
mad r1.x, r0.z, c35.z, c35.w
rcp r0.z, r3.x
mov r0.x, -r2.y
mov r0.y, r2.x
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
sincos r2.xy, r1.x
mul r0.z, r3.y, r0
mov r1.x, c30
mad r0.x, r0.y, r0.z, r0
rcp r0.z, r2.x
mul r0.z, r2.y, r0
mad r0.y, r0.x, r0.z, r0
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
rcp r1.y, c31.y
rcp r1.x, c31.x
mad o2.zw, r0.xyxy, r1.xyxy, c31
mad r0.x, r0.z, c35.z, c35.w
mov o3.zw, r1
sincos r1.xy, r0.x
mul r0.xy, v0.zyzw, c29
mul r0.xy, r0, c36
add r0.xy, r0, c29.zwzw
add r0.xy, r0, c36.z
mov r1.z, r1.x
mov r1.w, -r1.y
mul r1.zw, r0.xyxy, r1
mul r1.xy, r1.yxzw, r0
add r0.x, r1.z, r1.w
add r0.y, r1.x, r1
add o2.xy, r0, c35.y
mov r5.w, r4
mov r5.y, r0.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
add o5.xyz, -r0, c16
mad o1.zw, v2.xyxy, c28.xyxy, c28
mad o1.xy, v2, c27, c27.zwzw
mov o4.w, r4
mov o5.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[38] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..34],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[32];
FRC R1.z, R0.x;
SLT R0, R1.z, c[35];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[35].xxzz;
DP3 R1.x, R2, c[35].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.zzww, c[37].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
MUL R2.y, R6.w, c[34].x;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.zw, R1.xyxy, R1;
MUL R1.x, R6.w, c[33];
FRC R2.x, R1;
SLT R1, R2.x, c[35];
FRC R4.w, R2.y;
MOV R0.x, -R0.w;
MOV R0.y, R0.z;
MUL R0.xy, vertex.position.z, R0;
MAD R5.xy, vertex.position.y, R0.zwzw, R0;
ADD R0.xyz, R1.yzww, -R1;
MOV R1.yzw, R0.xxyz;
DP4 R0.w, R1, c[35].xxzz;
DP3 R0.z, R0, c[35].yyww;
ADD R0.xy, R2.x, -R0.zwzw;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[35];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[36].xyxy, c[36].zwzw;
MAD R2, R2, R3.zzww, c[37].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[35].yyww;
DP4 R5.w, R0, c[35].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.xxyy, c[37].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[35].y;
MUL R4.w, R6, c[30].x;
MUL R4.y, R4, c[18].x;
MOV R1.w, c[0].z;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[35];
MOV R3.x, R4;
RCP R5.y, c[31].y;
RCP R5.x, c[31].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[31];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[35].xxzz;
DP3 R4.z, R5, c[35].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[36].xyxy, c[36].zwzw;
MAD R0, R0, R1.xxyy, c[37].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[26].w;
DP3 R4.z, R2, c[7];
MUL R1.xy, vertex.position.zyzw, c[29];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[29].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[35].y;
MOV R1.z, R4;
DP3 R4.x, R2, c[5];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
DP3 R0.zw, R2, c[6];
ADD result.texcoord[1].xy, R0, c[35].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R4;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R3.z, R1, c[21];
DP4 R3.y, R1, c[20];
DP4 R3.x, R1, c[19];
DP4 R1.z, R2, c[24];
DP4 R1.x, R2, c[22];
DP4 R1.y, R2, c[23];
ADD R2.xyz, R3, R1;
MOV R1.xyz, c[17];
MOV R1.w, c[0].z;
DP4 R3.z, R1, c[11];
DP4 R3.x, R1, c[9];
DP4 R3.y, R1, c[10];
MAD R1.xyz, R3, c[26].w, -vertex.position;
DP3 R0.y, vertex.normal, -R1;
MUL R3.xyz, vertex.normal, R0.y;
MAD R1.xyz, -R3, c[37].z, -R1;
MAD R0.x, R4, R4, -R0;
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[3].xyz, R2, R0;
MOV R4.w, R6.z;
MOV R4.y, R0.w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R1, c[7];
DP3 result.texcoord[6].y, R1, c[6];
DP3 result.texcoord[6].x, R1, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[17];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
MOV result.texcoord[3].w, R6.z;
MOV result.texcoord[4].w, R6.z;
END
# 162 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c35, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c36, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c26.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r0, c2, r0.x, r2
mov r1.y, c12.w
mad r2, c3, r1.y, r0
mov r1.x, c13.y
mul r0, c1, r1.x
mov r1.x, c13
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c35.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mul r0.y, r0, c17.x
mad o3.xy, r0.z, c18.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c36.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c21
dp4 r4.y, r2, c20
dp4 r4.x, r2, c19
dp4 r2.z, r3, c24
dp4 r2.x, r3, c22
dp4 r2.y, r3, c23
add r2.xyz, r4, r2
mov r3.w, c36.y
mov r3.xyz, c16
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c26.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c36.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c25
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mad r2, c0, r0.x, r2
mov r0.x, c14.z
mad r2, c2, r0.x, r2
mov r0.y, c32.x
mad r0.y, r0, c35.x, c35
frc r0.y, r0
mov r0.z, c33.x
mad r0.z, r0, c35.x, c35.y
frc r0.z, r0
mad r0.y, r0, c35.z, c35.w
mov r0.x, c14.w
mad r0.z, r0, c35, c35.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c3, r0.x, r2
dp4 r1.z, v0, r3
mov o0, r1
sincos r2.xy, r0.y
sincos r3.xy, r0.z
mov r1.x, c34
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
mad r1.x, r0.z, c35.z, c35.w
rcp r0.z, r3.x
mov r0.x, -r2.y
mov r0.y, r2.x
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
sincos r2.xy, r1.x
mul r0.z, r3.y, r0
mov r1.x, c30
mad r0.x, r0.y, r0.z, r0
rcp r0.z, r2.x
mul r0.z, r2.y, r0
mad r0.y, r0.x, r0.z, r0
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
rcp r1.y, c31.y
rcp r1.x, c31.x
mad o2.zw, r0.xyxy, r1.xyxy, c31
mad r0.x, r0.z, c35.z, c35.w
mov o3.zw, r1
sincos r1.xy, r0.x
mul r0.xy, v0.zyzw, c29
mul r0.xy, r0, c36
add r0.xy, r0, c29.zwzw
add r0.xy, r0, c36.z
mov r1.z, r1.x
mov r1.w, -r1.y
mul r1.zw, r0.xyxy, r1
mul r1.xy, r1.yxzw, r0
add r0.x, r1.z, r1.w
add r0.y, r1.x, r1
add o2.xy, r0, c35.y
mov r5.w, r4
mov r5.y, r0.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
add o5.xyz, -r0, c16
mad o1.zw, v2.xyxy, c28.xyxy, c28
mad o1.xy, v2, c27, c27.zwzw
mov o4.w, r4
mov o5.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[38] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..34],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[32];
FRC R1.z, R0.x;
SLT R0, R1.z, c[35];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[35].xxzz;
DP3 R1.x, R2, c[35].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.zzww, c[37].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
MUL R2.y, R6.w, c[34].x;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.zw, R1.xyxy, R1;
MUL R1.x, R6.w, c[33];
FRC R2.x, R1;
SLT R1, R2.x, c[35];
FRC R4.w, R2.y;
MOV R0.x, -R0.w;
MOV R0.y, R0.z;
MUL R0.xy, vertex.position.z, R0;
MAD R5.xy, vertex.position.y, R0.zwzw, R0;
ADD R0.xyz, R1.yzww, -R1;
MOV R1.yzw, R0.xxyz;
DP4 R0.w, R1, c[35].xxzz;
DP3 R0.z, R0, c[35].yyww;
ADD R0.xy, R2.x, -R0.zwzw;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[35];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[36].xyxy, c[36].zwzw;
MAD R2, R2, R3.zzww, c[37].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[35].yyww;
DP4 R5.w, R0, c[35].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.xxyy, c[37].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[35].y;
MUL R4.w, R6, c[30].x;
MUL R4.y, R4, c[18].x;
MOV R1.w, c[0].z;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[35];
MOV R3.x, R4;
RCP R5.y, c[31].y;
RCP R5.x, c[31].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[31];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[35].xxzz;
DP3 R4.z, R5, c[35].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[36].xyxy, c[36].zwzw;
MAD R0, R0, R1.xxyy, c[37].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[26].w;
DP3 R4.z, R2, c[7];
MUL R1.xy, vertex.position.zyzw, c[29];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[29].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[35].y;
MOV R1.z, R4;
DP3 R4.x, R2, c[5];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
DP3 R0.zw, R2, c[6];
ADD result.texcoord[1].xy, R0, c[35].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R4;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R3.z, R1, c[21];
DP4 R3.y, R1, c[20];
DP4 R3.x, R1, c[19];
DP4 R1.z, R2, c[24];
DP4 R1.x, R2, c[22];
DP4 R1.y, R2, c[23];
ADD R2.xyz, R3, R1;
MOV R1.xyz, c[17];
MOV R1.w, c[0].z;
DP4 R3.z, R1, c[11];
DP4 R3.x, R1, c[9];
DP4 R3.y, R1, c[10];
MAD R1.xyz, R3, c[26].w, -vertex.position;
DP3 R0.y, vertex.normal, -R1;
MUL R3.xyz, vertex.normal, R0.y;
MAD R1.xyz, -R3, c[37].z, -R1;
MAD R0.x, R4, R4, -R0;
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[3].xyz, R2, R0;
MOV R4.w, R6.z;
MOV R4.y, R0.w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R1, c[7];
DP3 result.texcoord[6].y, R1, c[6];
DP3 result.texcoord[6].x, R1, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[17];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
MOV result.texcoord[3].w, R6.z;
MOV result.texcoord[4].w, R6.z;
END
# 162 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c35, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c36, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c26.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r0, c2, r0.x, r2
mov r1.y, c12.w
mad r2, c3, r1.y, r0
mov r1.x, c13.y
mul r0, c1, r1.x
mov r1.x, c13
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c35.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mul r0.y, r0, c17.x
mad o3.xy, r0.z, c18.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c36.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c21
dp4 r4.y, r2, c20
dp4 r4.x, r2, c19
dp4 r2.z, r3, c24
dp4 r2.x, r3, c22
dp4 r2.y, r3, c23
add r2.xyz, r4, r2
mov r3.w, c36.y
mov r3.xyz, c16
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c26.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c36.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c25
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mad r2, c0, r0.x, r2
mov r0.x, c14.z
mad r2, c2, r0.x, r2
mov r0.y, c32.x
mad r0.y, r0, c35.x, c35
frc r0.y, r0
mov r0.z, c33.x
mad r0.z, r0, c35.x, c35.y
frc r0.z, r0
mad r0.y, r0, c35.z, c35.w
mov r0.x, c14.w
mad r0.z, r0, c35, c35.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c3, r0.x, r2
dp4 r1.z, v0, r3
mov o0, r1
sincos r2.xy, r0.y
sincos r3.xy, r0.z
mov r1.x, c34
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
mad r1.x, r0.z, c35.z, c35.w
rcp r0.z, r3.x
mov r0.x, -r2.y
mov r0.y, r2.x
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
sincos r2.xy, r1.x
mul r0.z, r3.y, r0
mov r1.x, c30
mad r0.x, r0.y, r0.z, r0
rcp r0.z, r2.x
mul r0.z, r2.y, r0
mad r0.y, r0.x, r0.z, r0
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
rcp r1.y, c31.y
rcp r1.x, c31.x
mad o2.zw, r0.xyxy, r1.xyxy, c31
mad r0.x, r0.z, c35.z, c35.w
mov o3.zw, r1
sincos r1.xy, r0.x
mul r0.xy, v0.zyzw, c29
mul r0.xy, r0, c36
add r0.xy, r0, c29.zwzw
add r0.xy, r0, c36.z
mov r1.z, r1.x
mov r1.w, -r1.y
mul r1.zw, r0.xyxy, r1
mul r1.xy, r1.yxzw, r0
add r0.x, r1.z, r1.w
add r0.y, r1.x, r1
add o2.xy, r0, c35.y
mov r5.w, r4
mov r5.y, r0.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
add o5.xyz, -r0, c16
mad o1.zw, v2.xyxy, c28.xyxy, c28
mad o1.xy, v2, c27, c27.zwzw
mov o4.w, r4
mov o5.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[38] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..34],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[32];
FRC R1.z, R0.x;
SLT R0, R1.z, c[35];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[35].xxzz;
DP3 R1.x, R2, c[35].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.zzww, c[37].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
MUL R2.y, R6.w, c[34].x;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.zw, R1.xyxy, R1;
MUL R1.x, R6.w, c[33];
FRC R2.x, R1;
SLT R1, R2.x, c[35];
FRC R4.w, R2.y;
MOV R0.x, -R0.w;
MOV R0.y, R0.z;
MUL R0.xy, vertex.position.z, R0;
MAD R5.xy, vertex.position.y, R0.zwzw, R0;
ADD R0.xyz, R1.yzww, -R1;
MOV R1.yzw, R0.xxyz;
DP4 R0.w, R1, c[35].xxzz;
DP3 R0.z, R0, c[35].yyww;
ADD R0.xy, R2.x, -R0.zwzw;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[35];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[36].xyxy, c[36].zwzw;
MAD R2, R2, R3.zzww, c[37].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[35].yyww;
DP4 R5.w, R0, c[35].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[36].xyxy, c[36].zwzw;
MAD R1, R1, R2.xxyy, c[37].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[35].y;
MUL R4.w, R6, c[30].x;
MUL R4.y, R4, c[18].x;
MOV R1.w, c[0].z;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[35];
MOV R3.x, R4;
RCP R5.y, c[31].y;
RCP R5.x, c[31].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[31];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[35].xxzz;
DP3 R4.z, R5, c[35].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[36].xyxy, c[36].zwzw;
MAD R0, R0, R1.xxyy, c[37].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[26].w;
DP3 R4.z, R2, c[7];
MUL R1.xy, vertex.position.zyzw, c[29];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[29].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[35].y;
MOV R1.z, R4;
DP3 R4.x, R2, c[5];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
DP3 R0.zw, R2, c[6];
ADD result.texcoord[1].xy, R0, c[35].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R4;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R3.z, R1, c[21];
DP4 R3.y, R1, c[20];
DP4 R3.x, R1, c[19];
DP4 R1.z, R2, c[24];
DP4 R1.x, R2, c[22];
DP4 R1.y, R2, c[23];
ADD R2.xyz, R3, R1;
MOV R1.xyz, c[17];
MOV R1.w, c[0].z;
DP4 R3.z, R1, c[11];
DP4 R3.x, R1, c[9];
DP4 R3.y, R1, c[10];
MAD R1.xyz, R3, c[26].w, -vertex.position;
DP3 R0.y, vertex.normal, -R1;
MUL R3.xyz, vertex.normal, R0.y;
MAD R1.xyz, -R3, c[37].z, -R1;
MAD R0.x, R4, R4, -R0;
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[3].xyz, R2, R0;
MOV R4.w, R6.z;
MOV R4.y, R0.w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R1, c[7];
DP3 result.texcoord[6].y, R1, c[6];
DP3 result.texcoord[6].x, R1, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[17];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
MOV result.texcoord[3].w, R6.z;
MOV result.texcoord[4].w, R6.z;
END
# 162 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
Vector 28 [_MaskTex_ST]
Vector 29 [_PatternTex_ST]
Float 30 [_PatternRotate]
Vector 31 [_DecalScaleOffset]
Float 32 [_DecalRotate]
Float 33 [_DecalShearX]
Float 34 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c35, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c36, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c26.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r0, c2, r0.x, r2
mov r1.y, c12.w
mad r2, c3, r1.y, r0
mov r1.x, c13.y
mul r0, c1, r1.x
mov r1.x, c13
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c35.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mul r0.y, r0, c17.x
mad o3.xy, r0.z, c18.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c36.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c21
dp4 r4.y, r2, c20
dp4 r4.x, r2, c19
dp4 r2.z, r3, c24
dp4 r2.x, r3, c22
dp4 r2.y, r3, c23
add r2.xyz, r4, r2
mov r3.w, c36.y
mov r3.xyz, c16
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c26.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c36.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c25
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mad r2, c0, r0.x, r2
mov r0.x, c14.z
mad r2, c2, r0.x, r2
mov r0.y, c32.x
mad r0.y, r0, c35.x, c35
frc r0.y, r0
mov r0.z, c33.x
mad r0.z, r0, c35.x, c35.y
frc r0.z, r0
mad r0.y, r0, c35.z, c35.w
mov r0.x, c14.w
mad r0.z, r0, c35, c35.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c3, r0.x, r2
dp4 r1.z, v0, r3
mov o0, r1
sincos r2.xy, r0.y
sincos r3.xy, r0.z
mov r1.x, c34
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
mad r1.x, r0.z, c35.z, c35.w
rcp r0.z, r3.x
mov r0.x, -r2.y
mov r0.y, r2.x
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
sincos r2.xy, r1.x
mul r0.z, r3.y, r0
mov r1.x, c30
mad r0.x, r0.y, r0.z, r0
rcp r0.z, r2.x
mul r0.z, r2.y, r0
mad r0.y, r0.x, r0.z, r0
mad r1.x, r1, c35, c35.y
frc r0.z, r1.x
rcp r1.y, c31.y
rcp r1.x, c31.x
mad o2.zw, r0.xyxy, r1.xyxy, c31
mad r0.x, r0.z, c35.z, c35.w
mov o3.zw, r1
sincos r1.xy, r0.x
mul r0.xy, v0.zyzw, c29
mul r0.xy, r0, c36
add r0.xy, r0, c29.zwzw
add r0.xy, r0, c36.z
mov r1.z, r1.x
mov r1.w, -r1.y
mul r1.zw, r0.xyxy, r1
mul r1.xy, r1.yxzw, r0
add r0.x, r1.z, r1.w
add r0.y, r1.x, r1
add o2.xy, r0, c35.y
mov r5.w, r4
mov r5.y, r0.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
add o5.xyz, -r0, c16
mad o1.zw, v2.xyxy, c28.xyxy, c28
mad o1.xy, v2, c27, c27.zwzw
mov o4.w, r4
mov o5.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_Time]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_ProjectionParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[42] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.zzww, c[41].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R1.xy, R1, R1.zwzw;
MUL R0.z, R6.w, c[34].x;
FRC R2.w, R0.z;
MOV R0.x, -R1.y;
MOV R0.y, R1.x;
MUL R1.zw, vertex.position.z, R0.xyxy;
SLT R0, R2.w, c[39];
ADD R2.xyz, R0.yzww, -R0;
MAD R5.xy, vertex.position.y, R1, R1.zwzw;
MOV R1.x, R0;
MOV R1.yzw, R2.xxyz;
MUL R0.z, R6.w, c[35].x;
FRC R4.w, R0.z;
DP4 R0.y, R1, c[39].xxzz;
DP3 R0.x, R2, c[39].yyww;
ADD R0.xy, R2.w, -R0;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[39];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[40].xyxy, c[40].zwzw;
MAD R2, R2, R3.zzww, c[41].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[39].yyww;
DP4 R5.w, R0, c[39].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.xxyy, c[41].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[39].y;
MUL R4.w, R6, c[31].x;
MUL R4.y, R4, c[19].x;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[39];
MOV R3.x, R4;
RCP R5.y, c[32].y;
RCP R5.x, c[32].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[32];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[39].xxzz;
DP3 R4.z, R5, c[39].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R1.xxyy, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R1.zw, R2, c[6];
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[39].y;
DP3 R4.x, R2, c[5];
DP3 R4.z, R2, c[7];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
ADD result.texcoord[1].xy, R0, c[39].y;
MOV R0.y, R1.z;
MOV R0.x, R4;
MOV R0.z, R4;
MOV R0.w, c[0].z;
MUL R2, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[22];
DP4 R3.y, R0, c[21];
DP4 R3.x, R0, c[20];
MUL R0.w, R1.z, R1.z;
DP4 R0.z, R2, c[25];
DP4 R0.x, R2, c[23];
DP4 R0.y, R2, c[24];
ADD R0.xyz, R3, R0;
MOV R2.xyz, c[18];
MOV R2.w, c[0].z;
DP4 R3.z, R2, c[11];
DP4 R3.x, R2, c[9];
DP4 R3.y, R2, c[10];
MAD R2.xyz, R3, c[27].w, -vertex.position;
DP3 R1.x, vertex.normal, -R2;
MUL R3.xyz, vertex.normal, R1.x;
MAD R2.xyz, -R3, c[41].z, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R1.xyz, R0.w, c[26];
ADD result.texcoord[3].xyz, R0, R1;
MAD R0.zw, vertex.position.xyzy, c[36].xyxy, c[36];
MOV R0.x, c[37];
MOV R0.y, c[38].x;
MAD R0.xy, R0, c[17].y, R0.zwzw;
MOV R4.w, R0.x;
MOV R4.y, R1.w;
MOV result.texcoord[4].w, R0.y;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R6.z;
END
# 167 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_Time]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_ScreenParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c39, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c40, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c27.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c39.y
mul r0.y, r0, c18.x
mad o3.xy, r0.z, c19.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c40.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c22
dp4 r4.y, r2, c21
dp4 r4.x, r2, c20
dp4 r2.z, r3, c25
dp4 r2.x, r3, c23
dp4 r2.y, r3, c24
add r2.xyz, r4, r2
mov r3.w, c40.y
mov r3.xyz, c17
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c27.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c40.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c26
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mov r0.y, c33.x
mad r0.y, r0, c39.x, c39
mov r0.z, c34.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
mad r2, c0, r0.x, r2
frc r0.y, r0
mad r0.x, r0.y, c39.z, c39.w
mov r0.y, c14.z
mad r0.z, r0, c39, c39.w
mov r5.y, r0.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c2, r0.y, r2
sincos r2.xy, r0.x
mov r0.x, c14.w
mad r3, c3, r0.x, r3
dp4 r1.z, v0, r3
mov o0, r1
sincos r3.xy, r0.z
mov r1.x, c35
mad r1.x, r1, c39, c39.y
frc r1.x, r1
rcp r0.z, r3.x
mov r0.y, r2.x
mov r0.x, -r2.y
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
mad r1.x, r1, c39.z, c39.w
sincos r2.xy, r1.x
rcp r1.x, r2.x
mul r1.y, r2, r1.x
mul r0.z, r3.y, r0
mad r1.x, r0.y, r0.z, r0
mad r1.y, r1.x, r1, r0
rcp r0.y, c32.y
rcp r0.x, c32.x
mad o2.zw, r1.xyxy, r0.xyxy, c32
mov r0.z, c31.x
mov r0.x, c37
mov r0.y, c38.x
mad r1.xy, v0.zyzw, c36, c36.zwzw
mad r1.xy, r0, c16.y, r1
mad r0.x, r0.z, c39, c39.y
mov r5.w, r1.x
frc r0.x, r0
mad r1.x, r0, c39.z, c39.w
sincos r0.xy, r1.x
mul r0.zw, v0.xyzy, c30.xyxy
mov o3.zw, r1
mul r1.zw, r0, c40.xyxy
add r1.zw, r1, c30
mov r0.z, r0.x
mov r0.w, -r0.y
add r1.zw, r1, c40.z
mul r2.xy, r1.zwzw, r0.zwzw
mul r0.zw, r0.xyyx, r1
add r0.y, r0.z, r0.w
add r0.x, r2, r2.y
add o2.xy, r0, c39.y
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
mov o5.w, r1.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_Time]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_ProjectionParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[42] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.zzww, c[41].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R1.xy, R1, R1.zwzw;
MUL R0.z, R6.w, c[34].x;
FRC R2.w, R0.z;
MOV R0.x, -R1.y;
MOV R0.y, R1.x;
MUL R1.zw, vertex.position.z, R0.xyxy;
SLT R0, R2.w, c[39];
ADD R2.xyz, R0.yzww, -R0;
MAD R5.xy, vertex.position.y, R1, R1.zwzw;
MOV R1.x, R0;
MOV R1.yzw, R2.xxyz;
MUL R0.z, R6.w, c[35].x;
FRC R4.w, R0.z;
DP4 R0.y, R1, c[39].xxzz;
DP3 R0.x, R2, c[39].yyww;
ADD R0.xy, R2.w, -R0;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[39];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[40].xyxy, c[40].zwzw;
MAD R2, R2, R3.zzww, c[41].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[39].yyww;
DP4 R5.w, R0, c[39].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.xxyy, c[41].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[39].y;
MUL R4.w, R6, c[31].x;
MUL R4.y, R4, c[19].x;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[39];
MOV R3.x, R4;
RCP R5.y, c[32].y;
RCP R5.x, c[32].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[32];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[39].xxzz;
DP3 R4.z, R5, c[39].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R1.xxyy, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R1.zw, R2, c[6];
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[39].y;
DP3 R4.x, R2, c[5];
DP3 R4.z, R2, c[7];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
ADD result.texcoord[1].xy, R0, c[39].y;
MOV R0.y, R1.z;
MOV R0.x, R4;
MOV R0.z, R4;
MOV R0.w, c[0].z;
MUL R2, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[22];
DP4 R3.y, R0, c[21];
DP4 R3.x, R0, c[20];
MUL R0.w, R1.z, R1.z;
DP4 R0.z, R2, c[25];
DP4 R0.x, R2, c[23];
DP4 R0.y, R2, c[24];
ADD R0.xyz, R3, R0;
MOV R2.xyz, c[18];
MOV R2.w, c[0].z;
DP4 R3.z, R2, c[11];
DP4 R3.x, R2, c[9];
DP4 R3.y, R2, c[10];
MAD R2.xyz, R3, c[27].w, -vertex.position;
DP3 R1.x, vertex.normal, -R2;
MUL R3.xyz, vertex.normal, R1.x;
MAD R2.xyz, -R3, c[41].z, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R1.xyz, R0.w, c[26];
ADD result.texcoord[3].xyz, R0, R1;
MAD R0.zw, vertex.position.xyzy, c[36].xyxy, c[36];
MOV R0.x, c[37];
MOV R0.y, c[38].x;
MAD R0.xy, R0, c[17].y, R0.zwzw;
MOV R4.w, R0.x;
MOV R4.y, R1.w;
MOV result.texcoord[4].w, R0.y;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R6.z;
END
# 167 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_Time]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_ScreenParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c39, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c40, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c27.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c39.y
mul r0.y, r0, c18.x
mad o3.xy, r0.z, c19.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c40.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c22
dp4 r4.y, r2, c21
dp4 r4.x, r2, c20
dp4 r2.z, r3, c25
dp4 r2.x, r3, c23
dp4 r2.y, r3, c24
add r2.xyz, r4, r2
mov r3.w, c40.y
mov r3.xyz, c17
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c27.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c40.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c26
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mov r0.y, c33.x
mad r0.y, r0, c39.x, c39
mov r0.z, c34.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
mad r2, c0, r0.x, r2
frc r0.y, r0
mad r0.x, r0.y, c39.z, c39.w
mov r0.y, c14.z
mad r0.z, r0, c39, c39.w
mov r5.y, r0.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c2, r0.y, r2
sincos r2.xy, r0.x
mov r0.x, c14.w
mad r3, c3, r0.x, r3
dp4 r1.z, v0, r3
mov o0, r1
sincos r3.xy, r0.z
mov r1.x, c35
mad r1.x, r1, c39, c39.y
frc r1.x, r1
rcp r0.z, r3.x
mov r0.y, r2.x
mov r0.x, -r2.y
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
mad r1.x, r1, c39.z, c39.w
sincos r2.xy, r1.x
rcp r1.x, r2.x
mul r1.y, r2, r1.x
mul r0.z, r3.y, r0
mad r1.x, r0.y, r0.z, r0
mad r1.y, r1.x, r1, r0
rcp r0.y, c32.y
rcp r0.x, c32.x
mad o2.zw, r1.xyxy, r0.xyxy, c32
mov r0.z, c31.x
mov r0.x, c37
mov r0.y, c38.x
mad r1.xy, v0.zyzw, c36, c36.zwzw
mad r1.xy, r0, c16.y, r1
mad r0.x, r0.z, c39, c39.y
mov r5.w, r1.x
frc r0.x, r0
mad r1.x, r0, c39.z, c39.w
sincos r0.xy, r1.x
mul r0.zw, v0.xyzy, c30.xyxy
mov o3.zw, r1
mul r1.zw, r0, c40.xyxy
add r1.zw, r1, c30
mov r0.z, r0.x
mov r0.w, -r0.y
add r1.zw, r1, c40.z
mul r2.xy, r1.zwzw, r0.zwzw
mul r0.zw, r0.xyyx, r1
add r0.y, r0.z, r0.w
add r0.x, r2, r2.y
add o2.xy, r0, c39.y
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
mov o5.w, r1.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_Time]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_ProjectionParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[42] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.zzww, c[41].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R1.xy, R1, R1.zwzw;
MUL R0.z, R6.w, c[34].x;
FRC R2.w, R0.z;
MOV R0.x, -R1.y;
MOV R0.y, R1.x;
MUL R1.zw, vertex.position.z, R0.xyxy;
SLT R0, R2.w, c[39];
ADD R2.xyz, R0.yzww, -R0;
MAD R5.xy, vertex.position.y, R1, R1.zwzw;
MOV R1.x, R0;
MOV R1.yzw, R2.xxyz;
MUL R0.z, R6.w, c[35].x;
FRC R4.w, R0.z;
DP4 R0.y, R1, c[39].xxzz;
DP3 R0.x, R2, c[39].yyww;
ADD R0.xy, R2.w, -R0;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[39];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[40].xyxy, c[40].zwzw;
MAD R2, R2, R3.zzww, c[41].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[39].yyww;
DP4 R5.w, R0, c[39].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.xxyy, c[41].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[39].y;
MUL R4.w, R6, c[31].x;
MUL R4.y, R4, c[19].x;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[39];
MOV R3.x, R4;
RCP R5.y, c[32].y;
RCP R5.x, c[32].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[32];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[39].xxzz;
DP3 R4.z, R5, c[39].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R1.xxyy, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R1.zw, R2, c[6];
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[39].y;
DP3 R4.x, R2, c[5];
DP3 R4.z, R2, c[7];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
ADD result.texcoord[1].xy, R0, c[39].y;
MOV R0.y, R1.z;
MOV R0.x, R4;
MOV R0.z, R4;
MOV R0.w, c[0].z;
MUL R2, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[22];
DP4 R3.y, R0, c[21];
DP4 R3.x, R0, c[20];
MUL R0.w, R1.z, R1.z;
DP4 R0.z, R2, c[25];
DP4 R0.x, R2, c[23];
DP4 R0.y, R2, c[24];
ADD R0.xyz, R3, R0;
MOV R2.xyz, c[18];
MOV R2.w, c[0].z;
DP4 R3.z, R2, c[11];
DP4 R3.x, R2, c[9];
DP4 R3.y, R2, c[10];
MAD R2.xyz, R3, c[27].w, -vertex.position;
DP3 R1.x, vertex.normal, -R2;
MUL R3.xyz, vertex.normal, R1.x;
MAD R2.xyz, -R3, c[41].z, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R1.xyz, R0.w, c[26];
ADD result.texcoord[3].xyz, R0, R1;
MAD R0.zw, vertex.position.xyzy, c[36].xyxy, c[36];
MOV R0.x, c[37];
MOV R0.y, c[38].x;
MAD R0.xy, R0, c[17].y, R0.zwzw;
MOV R4.w, R0.x;
MOV R4.y, R1.w;
MOV result.texcoord[4].w, R0.y;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R6.z;
END
# 167 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_Time]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_ScreenParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c39, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c40, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c27.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c39.y
mul r0.y, r0, c18.x
mad o3.xy, r0.z, c19.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c40.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c22
dp4 r4.y, r2, c21
dp4 r4.x, r2, c20
dp4 r2.z, r3, c25
dp4 r2.x, r3, c23
dp4 r2.y, r3, c24
add r2.xyz, r4, r2
mov r3.w, c40.y
mov r3.xyz, c17
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c27.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c40.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c26
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mov r0.y, c33.x
mad r0.y, r0, c39.x, c39
mov r0.z, c34.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
mad r2, c0, r0.x, r2
frc r0.y, r0
mad r0.x, r0.y, c39.z, c39.w
mov r0.y, c14.z
mad r0.z, r0, c39, c39.w
mov r5.y, r0.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c2, r0.y, r2
sincos r2.xy, r0.x
mov r0.x, c14.w
mad r3, c3, r0.x, r3
dp4 r1.z, v0, r3
mov o0, r1
sincos r3.xy, r0.z
mov r1.x, c35
mad r1.x, r1, c39, c39.y
frc r1.x, r1
rcp r0.z, r3.x
mov r0.y, r2.x
mov r0.x, -r2.y
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
mad r1.x, r1, c39.z, c39.w
sincos r2.xy, r1.x
rcp r1.x, r2.x
mul r1.y, r2, r1.x
mul r0.z, r3.y, r0
mad r1.x, r0.y, r0.z, r0
mad r1.y, r1.x, r1, r0
rcp r0.y, c32.y
rcp r0.x, c32.x
mad o2.zw, r1.xyxy, r0.xyxy, c32
mov r0.z, c31.x
mov r0.x, c37
mov r0.y, c38.x
mad r1.xy, v0.zyzw, c36, c36.zwzw
mad r1.xy, r0, c16.y, r1
mad r0.x, r0.z, c39, c39.y
mov r5.w, r1.x
frc r0.x, r0
mad r1.x, r0, c39.z, c39.w
sincos r0.xy, r1.x
mul r0.zw, v0.xyzy, c30.xyxy
mov o3.zw, r1
mul r1.zw, r0, c40.xyxy
add r1.zw, r1, c30
mov r0.z, r0.x
mov r0.w, -r0.y
add r1.zw, r1, c40.z
mul r2.xy, r1.zwzw, r0.zwzw
mul r0.zw, r0.xyyx, r1
add r0.y, r0.z, r0.w
add r0.x, r2, r2.y
add o2.xy, r0, c39.y
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
mov o5.w, r1.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_Time]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_ProjectionParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[42] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.zzww, c[41].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R1.xy, R1, R1.zwzw;
MUL R0.z, R6.w, c[34].x;
FRC R2.w, R0.z;
MOV R0.x, -R1.y;
MOV R0.y, R1.x;
MUL R1.zw, vertex.position.z, R0.xyxy;
SLT R0, R2.w, c[39];
ADD R2.xyz, R0.yzww, -R0;
MAD R5.xy, vertex.position.y, R1, R1.zwzw;
MOV R1.x, R0;
MOV R1.yzw, R2.xxyz;
MUL R0.z, R6.w, c[35].x;
FRC R4.w, R0.z;
DP4 R0.y, R1, c[39].xxzz;
DP3 R0.x, R2, c[39].yyww;
ADD R0.xy, R2.w, -R0;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[39];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[40].xyxy, c[40].zwzw;
MAD R2, R2, R3.zzww, c[41].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[39].yyww;
DP4 R5.w, R0, c[39].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.xxyy, c[41].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[39].y;
MUL R4.w, R6, c[31].x;
MUL R4.y, R4, c[19].x;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[39];
MOV R3.x, R4;
RCP R5.y, c[32].y;
RCP R5.x, c[32].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[32];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[39].xxzz;
DP3 R4.z, R5, c[39].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R1.xxyy, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R1.zw, R2, c[6];
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[39].y;
DP3 R4.x, R2, c[5];
DP3 R4.z, R2, c[7];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
ADD result.texcoord[1].xy, R0, c[39].y;
MOV R0.y, R1.z;
MOV R0.x, R4;
MOV R0.z, R4;
MOV R0.w, c[0].z;
MUL R2, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[22];
DP4 R3.y, R0, c[21];
DP4 R3.x, R0, c[20];
MUL R0.w, R1.z, R1.z;
DP4 R0.z, R2, c[25];
DP4 R0.x, R2, c[23];
DP4 R0.y, R2, c[24];
ADD R0.xyz, R3, R0;
MOV R2.xyz, c[18];
MOV R2.w, c[0].z;
DP4 R3.z, R2, c[11];
DP4 R3.x, R2, c[9];
DP4 R3.y, R2, c[10];
MAD R2.xyz, R3, c[27].w, -vertex.position;
DP3 R1.x, vertex.normal, -R2;
MUL R3.xyz, vertex.normal, R1.x;
MAD R2.xyz, -R3, c[41].z, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R1.xyz, R0.w, c[26];
ADD result.texcoord[3].xyz, R0, R1;
MAD R0.zw, vertex.position.xyzy, c[36].xyxy, c[36];
MOV R0.x, c[37];
MOV R0.y, c[38].x;
MAD R0.xy, R0, c[17].y, R0.zwzw;
MOV R4.w, R0.x;
MOV R4.y, R1.w;
MOV result.texcoord[4].w, R0.y;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R6.z;
END
# 167 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_Time]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_ScreenParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c39, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c40, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c27.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c39.y
mul r0.y, r0, c18.x
mad o3.xy, r0.z, c19.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c40.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c22
dp4 r4.y, r2, c21
dp4 r4.x, r2, c20
dp4 r2.z, r3, c25
dp4 r2.x, r3, c23
dp4 r2.y, r3, c24
add r2.xyz, r4, r2
mov r3.w, c40.y
mov r3.xyz, c17
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c27.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c40.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c26
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mov r0.y, c33.x
mad r0.y, r0, c39.x, c39
mov r0.z, c34.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
mad r2, c0, r0.x, r2
frc r0.y, r0
mad r0.x, r0.y, c39.z, c39.w
mov r0.y, c14.z
mad r0.z, r0, c39, c39.w
mov r5.y, r0.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c2, r0.y, r2
sincos r2.xy, r0.x
mov r0.x, c14.w
mad r3, c3, r0.x, r3
dp4 r1.z, v0, r3
mov o0, r1
sincos r3.xy, r0.z
mov r1.x, c35
mad r1.x, r1, c39, c39.y
frc r1.x, r1
rcp r0.z, r3.x
mov r0.y, r2.x
mov r0.x, -r2.y
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
mad r1.x, r1, c39.z, c39.w
sincos r2.xy, r1.x
rcp r1.x, r2.x
mul r1.y, r2, r1.x
mul r0.z, r3.y, r0
mad r1.x, r0.y, r0.z, r0
mad r1.y, r1.x, r1, r0
rcp r0.y, c32.y
rcp r0.x, c32.x
mad o2.zw, r1.xyxy, r0.xyxy, c32
mov r0.z, c31.x
mov r0.x, c37
mov r0.y, c38.x
mad r1.xy, v0.zyzw, c36, c36.zwzw
mad r1.xy, r0, c16.y, r1
mad r0.x, r0.z, c39, c39.y
mov r5.w, r1.x
frc r0.x, r0
mad r1.x, r0, c39.z, c39.w
sincos r0.xy, r1.x
mul r0.zw, v0.xyzy, c30.xyxy
mov o3.zw, r1
mul r1.zw, r0, c40.xyxy
add r1.zw, r1, c30
mov r0.z, r0.x
mov r0.w, -r0.y
add r1.zw, r1, c40.z
mul r2.xy, r1.zwzw, r0.zwzw
mul r0.zw, r0.xyyx, r1
add r0.y, r0.z, r0.w
add r0.x, r2, r2.y
add o2.xy, r0, c39.y
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
mov o5.w, r1.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_Time]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_ProjectionParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[42] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.zzww, c[41].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R1.xy, R1, R1.zwzw;
MUL R0.z, R6.w, c[34].x;
FRC R2.w, R0.z;
MOV R0.x, -R1.y;
MOV R0.y, R1.x;
MUL R1.zw, vertex.position.z, R0.xyxy;
SLT R0, R2.w, c[39];
ADD R2.xyz, R0.yzww, -R0;
MAD R5.xy, vertex.position.y, R1, R1.zwzw;
MOV R1.x, R0;
MOV R1.yzw, R2.xxyz;
MUL R0.z, R6.w, c[35].x;
FRC R4.w, R0.z;
DP4 R0.y, R1, c[39].xxzz;
DP3 R0.x, R2, c[39].yyww;
ADD R0.xy, R2.w, -R0;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[39];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[40].xyxy, c[40].zwzw;
MAD R2, R2, R3.zzww, c[41].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[39].yyww;
DP4 R5.w, R0, c[39].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.xxyy, c[41].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[39].y;
MUL R4.w, R6, c[31].x;
MUL R4.y, R4, c[19].x;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[39];
MOV R3.x, R4;
RCP R5.y, c[32].y;
RCP R5.x, c[32].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[32];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[39].xxzz;
DP3 R4.z, R5, c[39].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R1.xxyy, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R1.zw, R2, c[6];
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[39].y;
DP3 R4.x, R2, c[5];
DP3 R4.z, R2, c[7];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
ADD result.texcoord[1].xy, R0, c[39].y;
MOV R0.y, R1.z;
MOV R0.x, R4;
MOV R0.z, R4;
MOV R0.w, c[0].z;
MUL R2, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[22];
DP4 R3.y, R0, c[21];
DP4 R3.x, R0, c[20];
MUL R0.w, R1.z, R1.z;
DP4 R0.z, R2, c[25];
DP4 R0.x, R2, c[23];
DP4 R0.y, R2, c[24];
ADD R0.xyz, R3, R0;
MOV R2.xyz, c[18];
MOV R2.w, c[0].z;
DP4 R3.z, R2, c[11];
DP4 R3.x, R2, c[9];
DP4 R3.y, R2, c[10];
MAD R2.xyz, R3, c[27].w, -vertex.position;
DP3 R1.x, vertex.normal, -R2;
MUL R3.xyz, vertex.normal, R1.x;
MAD R2.xyz, -R3, c[41].z, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R1.xyz, R0.w, c[26];
ADD result.texcoord[3].xyz, R0, R1;
MAD R0.zw, vertex.position.xyzy, c[36].xyxy, c[36];
MOV R0.x, c[37];
MOV R0.y, c[38].x;
MAD R0.xy, R0, c[17].y, R0.zwzw;
MOV R4.w, R0.x;
MOV R4.y, R1.w;
MOV result.texcoord[4].w, R0.y;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R6.z;
END
# 167 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_Time]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_ScreenParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c39, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c40, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c27.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c39.y
mul r0.y, r0, c18.x
mad o3.xy, r0.z, c19.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c40.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c22
dp4 r4.y, r2, c21
dp4 r4.x, r2, c20
dp4 r2.z, r3, c25
dp4 r2.x, r3, c23
dp4 r2.y, r3, c24
add r2.xyz, r4, r2
mov r3.w, c40.y
mov r3.xyz, c17
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c27.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c40.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c26
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mov r0.y, c33.x
mad r0.y, r0, c39.x, c39
mov r0.z, c34.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
mad r2, c0, r0.x, r2
frc r0.y, r0
mad r0.x, r0.y, c39.z, c39.w
mov r0.y, c14.z
mad r0.z, r0, c39, c39.w
mov r5.y, r0.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c2, r0.y, r2
sincos r2.xy, r0.x
mov r0.x, c14.w
mad r3, c3, r0.x, r3
dp4 r1.z, v0, r3
mov o0, r1
sincos r3.xy, r0.z
mov r1.x, c35
mad r1.x, r1, c39, c39.y
frc r1.x, r1
rcp r0.z, r3.x
mov r0.y, r2.x
mov r0.x, -r2.y
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
mad r1.x, r1, c39.z, c39.w
sincos r2.xy, r1.x
rcp r1.x, r2.x
mul r1.y, r2, r1.x
mul r0.z, r3.y, r0
mad r1.x, r0.y, r0.z, r0
mad r1.y, r1.x, r1, r0
rcp r0.y, c32.y
rcp r0.x, c32.x
mad o2.zw, r1.xyxy, r0.xyxy, c32
mov r0.z, c31.x
mov r0.x, c37
mov r0.y, c38.x
mad r1.xy, v0.zyzw, c36, c36.zwzw
mad r1.xy, r0, c16.y, r1
mad r0.x, r0.z, c39, c39.y
mov r5.w, r1.x
frc r0.x, r0
mad r1.x, r0, c39.z, c39.w
sincos r0.xy, r1.x
mul r0.zw, v0.xyzy, c30.xyxy
mov o3.zw, r1
mul r1.zw, r0, c40.xyxy
add r1.zw, r1, c30
mov r0.z, r0.x
mov r0.w, -r0.y
add r1.zw, r1, c40.z
mul r2.xy, r1.zwzw, r0.zwzw
mul r0.zw, r0.xyyx, r1
add r0.y, r0.z, r0.w
add r0.x, r2, r2.y
add o2.xy, r0, c39.y
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
mov o5.w, r1.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r4
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_Time]
Vector 18 [_WorldSpaceCameraPos]
Vector 19 [_ProjectionParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[42] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.modelview[0],
		program.local[5..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R6.w, c[0].x;
MUL R0.x, R6.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.zzww, c[41].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R1.xy, R1, R1.zwzw;
MUL R0.z, R6.w, c[34].x;
FRC R2.w, R0.z;
MOV R0.x, -R1.y;
MOV R0.y, R1.x;
MUL R1.zw, vertex.position.z, R0.xyxy;
SLT R0, R2.w, c[39];
ADD R2.xyz, R0.yzww, -R0;
MAD R5.xy, vertex.position.y, R1, R1.zwzw;
MOV R1.x, R0;
MOV R1.yzw, R2.xxyz;
MUL R0.z, R6.w, c[35].x;
FRC R4.w, R0.z;
DP4 R0.y, R1, c[39].xxzz;
DP3 R0.x, R2, c[39].yyww;
ADD R0.xy, R2.w, -R0;
MUL R3.xy, R0, R0;
SLT R0, R4.w, c[39];
ADD R4.xyz, R0.yzww, -R0;
MUL R3.zw, R3.xyxy, R3.xyxy;
MOV R0.yzw, R4.xxyz;
MAD R2, R3.zzww, c[40].xyxy, c[40].zwzw;
MAD R2, R2, R3.zzww, c[41].xyxy;
MAD R2.zw, R2.xyxz, R3.xyxy, R2.xyyw;
DP3 R5.z, R4, c[39].yyww;
DP4 R5.w, R0, c[39].xxzz;
ADD R4.xy, R4.w, -R5.zwzw;
MUL R3.zw, R4.xyxy, R4.xyxy;
MUL R2.xy, R3.zwzw, R3.zwzw;
DP4 R3.y, R1, c[0].zzww;
DP4 R3.x, R1, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R1, R2.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R2.xxyy, c[41].xyxy;
MAD R1.zw, R1.xyxz, R3, R1.xyyw;
RCP R2.z, R2.z;
MUL R2.x, R2.w, R2.z;
MAD R6.x, R5.y, R2, R5;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R0.xy, R1, R1.zwzw;
RCP R0.x, R0.x;
MUL R5.x, R0.y, R0;
MOV R3, c[2];
MAD R6.y, R6.x, R5.x, R5;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R7.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MUL R3, R3, c[15].y;
MAD R5, R1, c[13].z, R5;
MAD R5, R0, c[13].w, R5;
DP4 R7.x, vertex.position, R5;
MAD R4, R1, c[14].z, R4;
MAD R2, R2, c[15].x, R3;
MAD R4, R0, c[14].w, R4;
DP4 R7.y, vertex.position, R4;
MAD R1, R1, c[15].z, R2;
MAD R0, R0, c[15].w, R1;
DP4 R7.z, vertex.position, R0;
MUL R4.xyz, R7.xyww, c[39].y;
MUL R4.w, R6, c[31].x;
MUL R4.y, R4, c[19].x;
FRC R5.w, R4;
ADD result.texcoord[2].xy, R4, R4.z;
SLT R4, R5.w, c[39];
MOV R3.x, R4;
RCP R5.y, c[32].y;
RCP R5.x, c[32].x;
MAD result.texcoord[1].zw, R6.xyxy, R5.xyxy, c[32];
ADD R5.xyz, R4.yzww, -R4;
MOV R3.yzw, R5.xxyz;
DP4 R4.w, R3, c[39].xxzz;
DP3 R4.z, R5, c[39].yyww;
ADD R4.xy, R5.w, -R4.zwzw;
MUL R2.xy, R4, R4;
MUL R1.xy, R2, R2;
MAD R0, R1.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R1.xxyy, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R1.zw, R2, c[6];
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
DP4 R0.y, R3, c[0].zzww;
DP4 R0.x, R3, c[0].zwwz;
MUL R0.zw, R0.xyxy, R0;
ADD R1.xy, R1, -c[39].y;
DP3 R4.x, R2, c[5];
DP3 R4.z, R2, c[7];
MOV R0.x, R0.z;
MOV R0.y, -R0.w;
MUL R0.xy, R1, R0;
MUL R0.zw, R0.xywz, R1.xyxy;
ADD R0.x, R0, R0.y;
ADD R0.y, R0.z, R0.w;
ADD result.texcoord[1].xy, R0, c[39].y;
MOV R0.y, R1.z;
MOV R0.x, R4;
MOV R0.z, R4;
MOV R0.w, c[0].z;
MUL R2, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[22];
DP4 R3.y, R0, c[21];
DP4 R3.x, R0, c[20];
MUL R0.w, R1.z, R1.z;
DP4 R0.z, R2, c[25];
DP4 R0.x, R2, c[23];
DP4 R0.y, R2, c[24];
ADD R0.xyz, R3, R0;
MOV R2.xyz, c[18];
MOV R2.w, c[0].z;
DP4 R3.z, R2, c[11];
DP4 R3.x, R2, c[9];
DP4 R3.y, R2, c[10];
MAD R2.xyz, R3, c[27].w, -vertex.position;
DP3 R1.x, vertex.normal, -R2;
MUL R3.xyz, vertex.normal, R1.x;
MAD R2.xyz, -R3, c[41].z, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R1.xyz, R0.w, c[26];
ADD result.texcoord[3].xyz, R0, R1;
MAD R0.zw, vertex.position.xyzy, c[36].xyxy, c[36];
MOV R0.x, c[37];
MOV R0.y, c[38].x;
MAD R0.xy, R0, c[17].y, R0.zwzw;
MOV R4.w, R0.x;
MOV R4.y, R1.w;
MOV result.texcoord[4].w, R0.y;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R7;
MOV result.texcoord[2].zw, R7;
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R4;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R6.z;
END
# 167 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_Time]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_ScreenParams]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_MaskTex_ST]
Vector 30 [_PatternTex_ST]
Float 31 [_PatternRotate]
Vector 32 [_DecalScaleOffset]
Float 33 [_DecalRotate]
Float 34 [_DecalShearX]
Float 35 [_DecalShearY]
Vector 36 [_RespawnTexture_ST]
Float 37 [_RespawnSpeedU]
Float 38 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c39, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c40, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c27.w
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
dp3 r5.x, r3, c4
dp3 r5.z, r3, c6
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c39.y
mul r0.y, r0, c18.x
mad o3.xy, r0.z, c19.zwzw, r0
dp3 r0.zw, r3, c5
mul r0.x, r0.z, r0.z
mov r2.y, r0.z
mov r2.x, r5
mov r2.z, r5
mov r2.w, c40.y
mul r3, r2.xyzz, r2.yzzx
dp4 r4.z, r2, c22
dp4 r4.y, r2, c21
dp4 r4.x, r2, c20
dp4 r2.z, r3, c25
dp4 r2.x, r3, c23
dp4 r2.y, r3, c24
add r2.xyz, r4, r2
mov r3.w, c40.y
mov r3.xyz, c17
dp4 r4.z, r3, c10
dp4 r4.x, r3, c8
dp4 r4.y, r3, c9
mad r3.xyz, r4, c27.w, -v0
dp3 r0.y, v1, -r3
mul r4.xyz, v1, r0.y
mad r3.xyz, -r4, c40.w, -r3
mad r0.x, r5, r5, -r0
mul r0.xyz, r0.x, c26
add o4.xyz, r2, r0
mov r0.x, c14.y
mul r2, c1, r0.x
mov r0.x, c14
mov r0.y, c33.x
mad r0.y, r0, c39.x, c39
mov r0.z, c34.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
mad r2, c0, r0.x, r2
frc r0.y, r0
mad r0.x, r0.y, c39.z, c39.w
mov r0.y, c14.z
mad r0.z, r0, c39, c39.w
mov r5.y, r0.w
dp3 o7.z, r3, c6
dp3 o7.y, r3, c5
dp3 o7.x, r3, c4
mad r3, c2, r0.y, r2
sincos r2.xy, r0.x
mov r0.x, c14.w
mad r3, c3, r0.x, r3
dp4 r1.z, v0, r3
mov o0, r1
sincos r3.xy, r0.z
mov r1.x, c35
mad r1.x, r1, c39, c39.y
frc r1.x, r1
rcp r0.z, r3.x
mov r0.y, r2.x
mov r0.x, -r2.y
mul r0.xy, v0.z, r0
mad r0.xy, v0.y, r2, r0
mad r1.x, r1, c39.z, c39.w
sincos r2.xy, r1.x
rcp r1.x, r2.x
mul r1.y, r2, r1.x
mul r0.z, r3.y, r0
mad r1.x, r0.y, r0.z, r0
mad r1.y, r1.x, r1, r0
rcp r0.y, c32.y
rcp r0.x, c32.x
mad o2.zw, r1.xyxy, r0.xyxy, c32
mov r0.z, c31.x
mov r0.x, c37
mov r0.y, c38.x
mad r1.xy, v0.zyzw, c36, c36.zwzw
mad r1.xy, r0, c16.y, r1
mad r0.x, r0.z, c39, c39.y
mov r5.w, r1.x
frc r0.x, r0
mad r1.x, r0, c39.z, c39.w
sincos r0.xy, r1.x
mul r0.zw, v0.xyzy, c30.xyxy
mov o3.zw, r1
mul r1.zw, r0, c40.xyxy
add r1.zw, r1, c30
mov r0.z, r0.x
mov r0.w, -r0.y
add r1.zw, r1, c40.z
mul r2.xy, r1.zwzw, r0.zwzw
mul r0.zw, r0.xyyx, r1
add r0.y, r0.z, r0.w
add r0.x, r2, r2.y
add o2.xy, r0, c39.y
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o6, r5
mov o5.w, r1.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r4
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[26] = { program.local[0..23],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[25];
MAD R1.w, R2.x, c[25].z, R0;
MAD R2.w, R2.z, c[25].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[24], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[24].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[25], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[25].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[25].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[25].x, R0;
ADD R1.z, R1, c[24].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[24].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
LG2 R1.w, R2.w;
MOV_SAT R2.w, c[22].x;
MUL R4.xyz, R3.y, R4;
MUL R2.w, R1.y, R2;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R1.w;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[24].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
DP3_SAT R2.x, R2, R3;
MUL R0.xyz, R0, R1.x;
ADD R1.y, -R2.x, c[24].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[0];
MAD result.color.xyz, R0.x, c[1], R1;
MOV result.color.w, c[24].x;
END
# 107 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
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
def c24, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c25, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c26, 16.00000000, 0, 0, 0
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
add r1.xyz, -r3, c3
mad r1.xyz, r1, c17.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c24.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c24.y
mul r2.w, r2.y, c24.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c24, r2
mad r2.w, r2.z, c25.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c25.y, c25.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c25
texld r2, v1.zwzw, s5
cmp r3.w, r3, c25.z, c25.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c26.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c25
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c25.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r1.xyz, r0, r0.w
mov r0.xyz, c1
mad oC0.xyz, c0.x, r0, r1
mov_pp oC0.w, c25.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[26] = { program.local[0..23],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[25];
MAD R1.w, R2.x, c[25].z, R0;
MAD R2.w, R2.z, c[25].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[24], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[24].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[25], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[25].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[25].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[25].x, R0;
ADD R1.z, R1, c[24].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[24].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
LG2 R1.w, R2.w;
MOV_SAT R2.w, c[22].x;
MUL R4.xyz, R3.y, R4;
MUL R2.w, R1.y, R2;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R1.w;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[24].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
DP3_SAT R2.x, R2, R3;
MUL R0.xyz, R0, R1.x;
ADD R1.y, -R2.x, c[24].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[0];
MAD result.color.xyz, R0.x, c[1], R1;
MOV result.color.w, c[24].x;
END
# 107 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
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
def c24, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c25, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c26, 16.00000000, 0, 0, 0
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
add r1.xyz, -r3, c3
mad r1.xyz, r1, c17.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c24.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c24.y
mul r2.w, r2.y, c24.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c24, r2
mad r2.w, r2.z, c25.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c25.y, c25.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c25
texld r2, v1.zwzw, s5
cmp r3.w, r3, c25.z, c25.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c26.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c25
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c25.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r1.xyz, r0, r0.w
mov r0.xyz, c1
mad oC0.xyz, c0.x, r0, r1
mov_pp oC0.w, c25.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[26] = { program.local[0..23],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[25];
MAD R1.w, R2.x, c[25].z, R0;
MAD R2.w, R2.z, c[25].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[24], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[24].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[25], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[25].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[25].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[25].x, R0;
ADD R1.z, R1, c[24].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[24].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
LG2 R1.w, R2.w;
MOV_SAT R2.w, c[22].x;
MUL R4.xyz, R3.y, R4;
MUL R2.w, R1.y, R2;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R1.w;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[24].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
DP3_SAT R2.x, R2, R3;
MUL R0.xyz, R0, R1.x;
ADD R1.y, -R2.x, c[24].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[0];
MAD result.color.xyz, R0.x, c[1], R1;
MOV result.color.w, c[24].x;
END
# 107 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
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
def c24, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c25, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c26, 16.00000000, 0, 0, 0
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
add r1.xyz, -r3, c3
mad r1.xyz, r1, c17.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c24.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c24.y
mul r2.w, r2.y, c24.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c24, r2
mad r2.w, r2.z, c25.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c25.y, c25.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c25
texld r2, v1.zwzw, s5
cmp r3.w, r3, c25.z, c25.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c26.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c25
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c25.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r1.xyz, r0, r0.w
mov r0.xyz, c1
mad oC0.xyz, c0.x, r0, r1
mov_pp oC0.w, c25.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[26] = { program.local[0..23],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[25];
MAD R1.w, R2.x, c[25].z, R0;
MAD R2.w, R2.z, c[25].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[24], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[24].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[25], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[25].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[25].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[25].x, R0;
ADD R1.z, R1, c[24].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[24].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MUL R5.xyz, R2, R2.w;
MOV_SAT R1.w, c[22].x;
MUL R2.w, R1.y, R1;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R4.xyz, R3.y, R4;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[24].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
DP3_SAT R2.x, R2, R3;
MUL R0.xyz, R0, R1.x;
ADD R1.y, -R2.x, c[24].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[0];
MAD result.color.xyz, R0.x, c[1], R1;
MOV result.color.w, c[24].x;
END
# 103 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
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
def c24, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c25, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c26, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c3
mad r1.xyz, r0, c17.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c24.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c24.y
mul r2.w, r2.y, c24.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c24, r2
mad r2.w, r2.z, c25.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c25.y, c25.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c25
texld r2, v1.zwzw, s5
cmp r3.w, r3, c25.z, c25.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c26.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c25
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c25.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r1.xyz, r0, r0.w
mov r0.xyz, c1
mad oC0.xyz, c0.x, r0, r1
mov_pp oC0.w, c25.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[26] = { program.local[0..23],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[25];
MAD R1.w, R2.x, c[25].z, R0;
MAD R2.w, R2.z, c[25].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[24], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[24].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[25], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[25].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[25].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[25].x, R0;
ADD R1.z, R1, c[24].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[24].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MUL R5.xyz, R2, R2.w;
MOV_SAT R1.w, c[22].x;
MUL R2.w, R1.y, R1;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R4.xyz, R3.y, R4;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[24].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
DP3_SAT R2.x, R2, R3;
MUL R0.xyz, R0, R1.x;
ADD R1.y, -R2.x, c[24].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[0];
MAD result.color.xyz, R0.x, c[1], R1;
MOV result.color.w, c[24].x;
END
# 103 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
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
def c24, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c25, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c26, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c3
mad r1.xyz, r0, c17.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c24.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c24.y
mul r2.w, r2.y, c24.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c24, r2
mad r2.w, r2.z, c25.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c25.y, c25.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c25
texld r2, v1.zwzw, s5
cmp r3.w, r3, c25.z, c25.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c26.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c25
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c25.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r1.xyz, r0, r0.w
mov r0.xyz, c1
mad oC0.xyz, c0.x, r0, r1
mov_pp oC0.w, c25.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[26] = { program.local[0..23],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[25];
MAD R1.w, R2.x, c[25].z, R0;
MAD R2.w, R2.z, c[25].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[24], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[24].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[25], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[25].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[25].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[25].x, R0;
ADD R1.z, R1, c[24].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[24].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MUL R5.xyz, R2, R2.w;
MOV_SAT R1.w, c[22].x;
MUL R2.w, R1.y, R1;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R4.xyz, R3.y, R4;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[24].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
DP3_SAT R2.x, R2, R3;
MUL R0.xyz, R0, R1.x;
ADD R1.y, -R2.x, c[24].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[0];
MAD result.color.xyz, R0.x, c[1], R1;
MOV result.color.w, c[24].x;
END
# 103 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
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
def c24, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c25, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c26, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c3
mad r1.xyz, r0, c17.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c24.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c24.y
mul r2.w, r2.y, c24.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c24, r2
mad r2.w, r2.z, c25.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c25.y, c25.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c25.y, c25.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c25
texld r2, v1.zwzw, s5
cmp r3.w, r3, c25.z, c25.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c26.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c25
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c25.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r1.xyz, r0, r0.w
mov r0.xyz, c1
mad oC0.xyz, c0.x, r0, r1
mov_pp oC0.w, c25.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[27] = { program.local[0..24],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[26];
MAD R1.w, R2.x, c[26].z, R0;
MAD R2.w, R2.z, c[26].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[25], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[25].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[26], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[26].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[26].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[26].x, R0;
ADD R1.z, R1, c[25].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[25].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
LG2 R1.w, R2.w;
MOV_SAT R2.w, c[22].x;
MUL R4.xyz, R3.y, R4;
MUL R2.w, R1.y, R2;
ADD R0.w, R0, -c[0].x;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R1.w;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[25].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
MUL R0.xyz, R0, R1.x;
DP3_SAT R2.x, R2, R3;
ADD R1.y, -R2.x, c[25].x;
MAD R0.xyz, R0, R1.y, R4;
MUL R2.xyz, R0, R0.w;
MOV R1.x, c[0];
MAD R1.xyz, R1.x, c[1], R2;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[24].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[25].x;
END
# 113 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c25, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c26, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c27, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
dcl_texcoord6 v6.xyz
texldp r0, v2, s0
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
texld r2.xyz, v1, s3
add r1.xyz, -r3, c3
mad r1.xyz, r1, c17.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c25.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c25.y
mul r2.w, r2.y, c25.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c25, r2
mad r2.w, r2.z, c26.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c26.y, c26.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c26
texld r2, v1.zwzw, s5
cmp r3.w, r3, c26.z, c26.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c27.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c26
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c26.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r2.xyz, r0, r0.w
mov r1.xyz, c1
mad r1.xyz, c0.x, r1, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c24.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c26.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[27] = { program.local[0..24],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[26];
MAD R1.w, R2.x, c[26].z, R0;
MAD R2.w, R2.z, c[26].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[25], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[25].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[26], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[26].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[26].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[26].x, R0;
ADD R1.z, R1, c[25].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[25].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
LG2 R1.w, R2.w;
MOV_SAT R2.w, c[22].x;
MUL R4.xyz, R3.y, R4;
MUL R2.w, R1.y, R2;
ADD R0.w, R0, -c[0].x;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R1.w;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[25].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
MUL R0.xyz, R0, R1.x;
DP3_SAT R2.x, R2, R3;
ADD R1.y, -R2.x, c[25].x;
MAD R0.xyz, R0, R1.y, R4;
MUL R2.xyz, R0, R0.w;
MOV R1.x, c[0];
MAD R1.xyz, R1.x, c[1], R2;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[24].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[25].x;
END
# 113 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c25, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c26, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c27, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
dcl_texcoord6 v6.xyz
texldp r0, v2, s0
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
texld r2.xyz, v1, s3
add r1.xyz, -r3, c3
mad r1.xyz, r1, c17.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c25.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c25.y
mul r2.w, r2.y, c25.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c25, r2
mad r2.w, r2.z, c26.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c26.y, c26.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c26
texld r2, v1.zwzw, s5
cmp r3.w, r3, c26.z, c26.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c27.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c26
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c26.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r2.xyz, r0, r0.w
mov r1.xyz, c1
mad r1.xyz, c0.x, r1, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c24.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c26.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[27] = { program.local[0..24],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[26];
MAD R1.w, R2.x, c[26].z, R0;
MAD R2.w, R2.z, c[26].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[25], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[25].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[26], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[26].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[26].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[26].x, R0;
ADD R1.z, R1, c[25].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[25].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
LG2 R1.w, R2.w;
MOV_SAT R2.w, c[22].x;
MUL R4.xyz, R3.y, R4;
MUL R2.w, R1.y, R2;
ADD R0.w, R0, -c[0].x;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R1.w;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[25].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
MUL R0.xyz, R0, R1.x;
DP3_SAT R2.x, R2, R3;
ADD R1.y, -R2.x, c[25].x;
MAD R0.xyz, R0, R1.y, R4;
MUL R2.xyz, R0, R0.w;
MOV R1.x, c[0];
MAD R1.xyz, R1.x, c[1], R2;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[24].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[25].x;
END
# 113 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c25, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c26, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c27, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
dcl_texcoord6 v6.xyz
texldp r0, v2, s0
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
texld r2.xyz, v1, s3
add r1.xyz, -r3, c3
mad r1.xyz, r1, c17.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c25.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c25.y
mul r2.w, r2.y, c25.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c25, r2
mad r2.w, r2.z, c26.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c26.y, c26.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c26
texld r2, v1.zwzw, s5
cmp r3.w, r3, c26.z, c26.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c27.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c26
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c26.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r2.xyz, r0, r0.w
mov r1.xyz, c1
mad r1.xyz, c0.x, r1, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c24.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c26.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[27] = { program.local[0..24],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[26];
MAD R1.w, R2.x, c[26].z, R0;
MAD R2.w, R2.z, c[26].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[25], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[25].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[26], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[26].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[26].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[26].x, R0;
ADD R1.z, R1, c[25].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[25].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MUL R5.xyz, R2, R2.w;
MOV_SAT R1.w, c[22].x;
MUL R2.w, R1.y, R1;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R4.xyz, R3.y, R4;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[25].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
MUL R0.xyz, R0, R1.x;
DP3_SAT R2.x, R2, R3;
ADD R1.y, -R2.x, c[25].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R2.xyz, R0, R0.w;
MOV R1.x, c[0];
MAD R1.xyz, R1.x, c[1], R2;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[24].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[25].x;
END
# 109 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c25, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c26, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c27, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c3
mad r1.xyz, r0, c17.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c25.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c25.y
mul r2.w, r2.y, c25.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c25, r2
mad r2.w, r2.z, c26.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c26.y, c26.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c26
texld r2, v1.zwzw, s5
cmp r3.w, r3, c26.z, c26.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c27.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c26
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c26.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r2.xyz, r0, r0.w
mov r1.xyz, c1
mad r1.xyz, c0.x, r1, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c24.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c26.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[27] = { program.local[0..24],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[26];
MAD R1.w, R2.x, c[26].z, R0;
MAD R2.w, R2.z, c[26].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[25], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[25].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[26], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[26].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[26].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[26].x, R0;
ADD R1.z, R1, c[25].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[25].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MUL R5.xyz, R2, R2.w;
MOV_SAT R1.w, c[22].x;
MUL R2.w, R1.y, R1;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R4.xyz, R3.y, R4;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[25].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
MUL R0.xyz, R0, R1.x;
DP3_SAT R2.x, R2, R3;
ADD R1.y, -R2.x, c[25].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R2.xyz, R0, R0.w;
MOV R1.x, c[0];
MAD R1.xyz, R1.x, c[1], R2;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[24].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[25].x;
END
# 109 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c25, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c26, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c27, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c3
mad r1.xyz, r0, c17.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c25.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c25.y
mul r2.w, r2.y, c25.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c25, r2
mad r2.w, r2.z, c26.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c26.y, c26.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c26
texld r2, v1.zwzw, s5
cmp r3.w, r3, c26.z, c26.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c27.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c26
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c26.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r2.xyz, r0, r0.w
mov r1.xyz, c1
mad r1.xyz, c0.x, r1, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c24.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c26.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[27] = { program.local[0..24],
		{ 1, 16, 0.5, 0.0099999998 },
		{ 0, 0.1, 0.30000001, 0.60000002 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0.xyz, fragment.texcoord[6], texture[4], CUBE;
ADD R3.xyz, -R2, c[4];
MUL R0.w, R2.y, c[26];
MAD R1.w, R2.x, c[26].z, R0;
MAD R2.w, R2.z, c[26].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[25], R0;
SLT R3.w, R2, c[7].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[3];
MAD R4.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1, c[17].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MOV R0.w, c[25].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[26], R0.w;
MUL R3.w, R1, R3.x;
MAD R5.xyz, R1.x, R2, R4;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[9].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[5];
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[26].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[6];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[11].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[26].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R1.w, -R1, c[26].x, R0;
ADD R1.z, R1, c[25].x;
MAD R3.xyz, R3, c[12].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[4], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.y, c[5], R2;
CMP R2.xyz, -R1.w, R3, R2;
MAD R3.xyz, R1.z, c[6], R2;
MUL R2.w, R1.y, c[14].x;
MAD R2.w, R1.x, c[13].x, R2;
CMP R3.xyz, -R1.w, R3, R2;
MAD_SAT R2.w, R1.z, c[15].x, R2;
SGE R1.w, R2, c[25].z;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R2.xyz, R2, c[16], -R3;
MUL R1.w, R2, R1;
MAD R4.xyz, R1.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MUL R5.xyz, R2, R2.w;
MOV_SAT R1.w, c[22].x;
MUL R2.w, R1.y, R1;
MOV_SAT R1.w, c[21].x;
MAD R2.w, R1.x, R1, R2;
MOV_SAT R1.w, c[23].x;
MAD R1.w, R1.z, R1, R2;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R1.w;
MUL R4.xyz, R3.y, R4;
MUL R1.w, R3.x, c[2];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R1.w, c[2];
MAD R4.xyz, R2, c[25].y, R3;
DP3 R2.x, fragment.texcoord[5], fragment.texcoord[5];
RSQ R2.w, R2.x;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, fragment.texcoord[4];
MUL R3.xyz, R2.w, fragment.texcoord[5];
MOV_SAT R1.w, c[19].x;
MUL R1.w, R1.y, R1;
MOV_SAT R1.y, c[18].x;
MAD R1.y, R1.x, R1, R1.w;
MOV_SAT R1.x, c[20];
MAD R1.x, R1, R1.z, R1.y;
MUL R0.xyz, R0, R1.x;
DP3_SAT R2.x, R2, R3;
ADD R1.y, -R2.x, c[25].x;
MAD R0.xyz, R0, R1.y, R4;
ADD R0.w, R0, -c[0].x;
MUL R2.xyz, R0, R0.w;
MOV R1.x, c[0];
MAD R1.xyz, R1.x, c[1], R2;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[24].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[25].x;
END
# 109 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Float 0 [_Effect_Para]
Vector 1 [_Effect_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_GlossColor]
Vector 4 [_Mask1DiffuseColor]
Vector 5 [_Mask2DiffuseColor]
Vector 6 [_Mask3DiffuseColor]
Float 7 [_Pattern0MaxIntensity]
Float 8 [_Pattern0Blend]
Float 9 [_Pattern1MaxIntensity]
Float 10 [_Pattern1Blend]
Float 11 [_Pattern2MaxIntensity]
Float 12 [_Pattern2Blend]
Float 13 [_DecalMask0Blend]
Float 14 [_DecalMask1Blend]
Float 15 [_DecalMask2Blend]
Vector 16 [_DecalColor]
Float 17 [_GlossStrength]
Float 18 [_Mask1ReflectionRatio]
Float 19 [_Mask2ReflectionRatio]
Float 20 [_Mask3ReflectionRatio]
Float 21 [_Mask1SpecularGrading]
Float 22 [_Mask2SpecularGrading]
Float 23 [_Mask3SpecularGrading]
Float 24 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c25, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c26, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c27, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
dcl_texcoord6 v6.xyz
texld r5.xyz, v0.zwzw, s2
texld r3.xyz, v6, s4
add r0.xyz, -r3, c3
mad r1.xyz, r0, c17.x, r3
mul r4.xyz, r5.z, r1
texld r2.xyz, v1, s3
texldp r0, v2, s0
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c25.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c25.y
mul r2.w, r2.y, c25.z
add r5.xyz, -r2, c4
mad r5.xyz, r5, c8.x, r2
mad r2.w, r2.x, c25, r2
mad r2.w, r2.z, c26.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c7.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c5
mad r5.xyz, r6, c10.x, r2
add r3.w, r2, -c9.x
cmp r3.w, r3, c26.y, c26.z
mad r5.xyz, r7.y, r5, r4
add r4.w, r2, -c9.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.y, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c6
mad r5.xyz, r6, c12.x, r2
add r3.w, r2, -c11.x
add r2.w, r2, -c11.x
mad r5.xyz, r1.w, r5, r4
cmp r4.xyz, r2.w, r4, r5
cmp r2.w, r3, c26.y, c26.z
mad r2.xyz, r2, r1.w, r4
abs_pp r2.w, r2
cmp r4.xyz, -r2.w, r2, r4
else
mad r2.xyz, r7.x, c4, r4
mad r2.xyz, r7.y, c5, r2
mad r4.xyz, r1.w, c6, r2
endif
mul r2.x, r7.y, c14
mad r2.x, r7, c13, r2
mad_sat r2.x, r1.w, c15, r2
add r3.w, r2.x, c26
texld r2, v1.zwzw, s5
cmp r3.w, r3, c26.z, c26.y
mad r2.xyz, r2, c16, -r4
mul r2.w, r2, r3
mad r2.xyz, r2.w, r2, r4
mul_pp r4.xyz, r0, r0.w
mul r2.xyz, r1.y, r2
mov_sat r1.y, c22.x
mov_sat r0.w, c21.x
mul r1.y, r7, r1
mad r1.y, r7.x, r0.w, r1
mov_sat r0.w, c23.x
mad r0.w, r1, r0, r1.y
mul r4.xyz, r1.z, r4
mul r4.xyz, r4, r0.w
mul r0.w, r1.x, c2
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c2
mad r2.xyz, r1, c27.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c19
add r0.z, -r0.y, c26
mul r0.y, r7, r0.x
mov_sat r0.x, c18
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c20
mad r0.y, r0.x, r1.w, r0
mov r0.x, c0
mul r1.xyz, r3, r0.y
add r0.w, c26.z, -r0.x
mad r0.xyz, r1, r0.z, r2
mul r2.xyz, r0, r0.w
mov r1.xyz, c1
mad r1.xyz, c0.x, r1, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c24.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c26.z
"
}
}
 }
}
Fallback "Diffuse"
}