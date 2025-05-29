íÄShader "Custom/BOL_Wpn_MaskReflect" {
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
  Name "PREPASSBASE"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [unity_Scale]
Vector 10 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[9].w;
DP3 result.texcoord[1].z, R0, c[7];
DP3 result.texcoord[1].y, R0, c[6];
DP3 result.texcoord[1].x, R0, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [unity_Scale]
Vector 9 [_MaskTex_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c8.w
dp3 oT1.z, r0, c6
dp3 oT1.y, r0, c5
dp3 oT1.x, r0, c4
mad oT0.xy, v2, c9, c9.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
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
mov oC0, r1
"
}
}
 }
 Pass {
  Name "PREPASSFINAL"
  Tags { "LIGHTMODE"="PrePassFinal" "RenderType"="Opaque" }
  ZWrite Off
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[34] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.mvp,
		program.local[5..30],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.y, c[0].x;
MUL R0.x, R3.y, c[28];
FRC R1.w, R0.x;
SLT R0, R1.w, c[31];
ADD R1.xyz, R0.yzww, -R0;
MOV R0.yzw, R1.xxyz;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R1.w, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[29];
FRC R4.w, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R4.w, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R4.w, -R3.zwzw;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R2.zw, R3, R2;
MAD R0, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R4.xxyy, c[33].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.zw, R0, R0.xyxy;
MUL R2.x, R3.y, c[30];
MOV R3.z, -R2.w;
MOV R3.w, R2.z;
MUL R3.zw, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3;
FRC R2.z, R2.x;
RCP R2.x, R1.z;
SLT R0, R2.z, c[31];
ADD R1.xyz, R0.yzww, -R0;
MUL R1.w, R1, R2.x;
MOV R0.yzw, R1.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R2.z, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[26];
FRC R3.y, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R3.y, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R3.y, -R3.zwzw;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R0.xy, R3.zwzw, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.y, R0, R0.x;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R2.zzww, c[33].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[25];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[25].zwzw;
ADD R1.xy, R1, -c[31].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[27].y;
RCP R2.z, c[27].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[27];
MUL R2.xyz, vertex.normal, c[22].w;
DP3 R0.zw, R2, c[6];
DP3 R5.x, R2, c[5];
DP3 R5.z, R2, c[7];
ADD result.texcoord[1].xy, R0, c[31].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[17];
DP4 R4.y, R1, c[16];
DP4 R4.x, R1, c[15];
DP4 R1.z, R2, c[20];
DP4 R1.x, R2, c[18];
DP4 R1.y, R2, c[19];
ADD R1.xyz, R4, R1;
MOV R2.xyz, c[13];
MOV R2.w, c[0].z;
DP4 R4.z, R2, c[11];
DP4 R4.x, R2, c[9];
DP4 R4.y, R2, c[10];
MAD R2.xyz, R4, c[22].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[33].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[21];
ADD result.texcoord[3].xyz, R1, R0;
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[31].y;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[2].xy, R0, R0.z;
MOV R5.y, R0.w;
MOV R5.w, R3.x;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
ADD result.texcoord[4].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.texcoord[3].w, R3.x;
MOV result.texcoord[4].w, R3.x;
END
# 143 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c31, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c32, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c22.w
dp3 r4.xy, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r0.x, r3
mov r0.y, r4.x
mov r0.z, r3
mov r0.w, c32.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4, r4
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c32.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c28.x
mad r0.w, r0, c31.x, c31.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c32.w, -r0
mad r1.w, r0, c31.z, c31
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c30.x
mov r0.x, c29
mad r0.y, r0, c31.x, c31
mad r0.x, r0, c31, c31.y
frc r0.x, r0
dp3 o7.x, r1, c4
frc r0.y, r0
mad r1.x, r0.y, c31.z, c31.w
mad r2.z, r0.x, c31, c31.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
rcp r0.x, r1.x
mul r0.y, r0, r0.z
mul r0.x, r1.y, r0
mad r0.z, r2.y, r0.x, r2.x
mad r0.w, r0.z, r0.y, r2.y
rcp r0.y, c27.y
rcp r0.x, c27.x
mad o2.zw, r0, r0.xyxy, c27
mov r0.z, c26.x
mad r0.z, r0, c31.x, c31.y
frc r0.z, r0
dp4 r0.w, v0, c3
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.y
mul r1.y, r1, c13.x
mad r0.z, r0, c31, c31.w
mad o3.xy, r1.z, c14.zwzw, r1
sincos r1.xy, r0.z
mul r1.zw, v0.xyzy, c25.xyxy
dp4 r0.z, v0, c2
mov o0, r0
mul r2.xy, r1.zwzw, c32
add r2.xy, r2, c25.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r2.xy, r2, c32.z
mul r1.zw, r2.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r2
add r1.w, r1.x, r1.y
mov r3.y, r4
mov r3.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o2.xy, r1.zwzw, c31.y
mov o6, r3
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c24.xyxy, c24
mad o1.xy, v2, c23, c23.zwzw
mov o4.w, r2
mov o5.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[34] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.mvp,
		program.local[5..30],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.y, c[0].x;
MUL R0.x, R3.y, c[28];
FRC R1.w, R0.x;
SLT R0, R1.w, c[31];
ADD R1.xyz, R0.yzww, -R0;
MOV R0.yzw, R1.xxyz;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R1.w, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[29];
FRC R4.w, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R4.w, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R4.w, -R3.zwzw;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R2.zw, R3, R2;
MAD R0, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R4.xxyy, c[33].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.zw, R0, R0.xyxy;
MUL R2.x, R3.y, c[30];
MOV R3.z, -R2.w;
MOV R3.w, R2.z;
MUL R3.zw, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3;
FRC R2.z, R2.x;
RCP R2.x, R1.z;
SLT R0, R2.z, c[31];
ADD R1.xyz, R0.yzww, -R0;
MUL R1.w, R1, R2.x;
MOV R0.yzw, R1.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R2.z, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[26];
FRC R3.y, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R3.y, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R3.y, -R3.zwzw;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R0.xy, R3.zwzw, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.y, R0, R0.x;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R2.zzww, c[33].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[25];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[25].zwzw;
ADD R1.xy, R1, -c[31].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[27].y;
RCP R2.z, c[27].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[27];
MUL R2.xyz, vertex.normal, c[22].w;
DP3 R0.zw, R2, c[6];
DP3 R5.x, R2, c[5];
DP3 R5.z, R2, c[7];
ADD result.texcoord[1].xy, R0, c[31].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[17];
DP4 R4.y, R1, c[16];
DP4 R4.x, R1, c[15];
DP4 R1.z, R2, c[20];
DP4 R1.x, R2, c[18];
DP4 R1.y, R2, c[19];
ADD R1.xyz, R4, R1;
MOV R2.xyz, c[13];
MOV R2.w, c[0].z;
DP4 R4.z, R2, c[11];
DP4 R4.x, R2, c[9];
DP4 R4.y, R2, c[10];
MAD R2.xyz, R4, c[22].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[33].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[21];
ADD result.texcoord[3].xyz, R1, R0;
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[31].y;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[2].xy, R0, R0.z;
MOV R5.y, R0.w;
MOV R5.w, R3.x;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
ADD result.texcoord[4].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.texcoord[3].w, R3.x;
MOV result.texcoord[4].w, R3.x;
END
# 143 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c31, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c32, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c22.w
dp3 r4.xy, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r0.x, r3
mov r0.y, r4.x
mov r0.z, r3
mov r0.w, c32.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4, r4
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c32.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c28.x
mad r0.w, r0, c31.x, c31.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c32.w, -r0
mad r1.w, r0, c31.z, c31
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c30.x
mov r0.x, c29
mad r0.y, r0, c31.x, c31
mad r0.x, r0, c31, c31.y
frc r0.x, r0
dp3 o7.x, r1, c4
frc r0.y, r0
mad r1.x, r0.y, c31.z, c31.w
mad r2.z, r0.x, c31, c31.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
rcp r0.x, r1.x
mul r0.y, r0, r0.z
mul r0.x, r1.y, r0
mad r0.z, r2.y, r0.x, r2.x
mad r0.w, r0.z, r0.y, r2.y
rcp r0.y, c27.y
rcp r0.x, c27.x
mad o2.zw, r0, r0.xyxy, c27
mov r0.z, c26.x
mad r0.z, r0, c31.x, c31.y
frc r0.z, r0
dp4 r0.w, v0, c3
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.y
mul r1.y, r1, c13.x
mad r0.z, r0, c31, c31.w
mad o3.xy, r1.z, c14.zwzw, r1
sincos r1.xy, r0.z
mul r1.zw, v0.xyzy, c25.xyxy
dp4 r0.z, v0, c2
mov o0, r0
mul r2.xy, r1.zwzw, c32
add r2.xy, r2, c25.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r2.xy, r2, c32.z
mul r1.zw, r2.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r2
add r1.w, r1.x, r1.y
mov r3.y, r4
mov r3.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o2.xy, r1.zwzw, c31.y
mov o6, r3
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c24.xyxy, c24
mad o1.xy, v2, c23, c23.zwzw
mov o4.w, r2
mov o5.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[34] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.mvp,
		program.local[5..30],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.y, c[0].x;
MUL R0.x, R3.y, c[28];
FRC R1.w, R0.x;
SLT R0, R1.w, c[31];
ADD R1.xyz, R0.yzww, -R0;
MOV R0.yzw, R1.xxyz;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R1.w, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[29];
FRC R4.w, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R4.w, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R4.w, -R3.zwzw;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R2.zw, R3, R2;
MAD R0, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R4.xxyy, c[33].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.zw, R0, R0.xyxy;
MUL R2.x, R3.y, c[30];
MOV R3.z, -R2.w;
MOV R3.w, R2.z;
MUL R3.zw, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3;
FRC R2.z, R2.x;
RCP R2.x, R1.z;
SLT R0, R2.z, c[31];
ADD R1.xyz, R0.yzww, -R0;
MUL R1.w, R1, R2.x;
MOV R0.yzw, R1.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R2.z, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[26];
FRC R3.y, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R3.y, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R3.y, -R3.zwzw;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R0.xy, R3.zwzw, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.y, R0, R0.x;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R2.zzww, c[33].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[25];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[25].zwzw;
ADD R1.xy, R1, -c[31].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[27].y;
RCP R2.z, c[27].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[27];
MUL R2.xyz, vertex.normal, c[22].w;
DP3 R0.zw, R2, c[6];
DP3 R5.x, R2, c[5];
DP3 R5.z, R2, c[7];
ADD result.texcoord[1].xy, R0, c[31].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[17];
DP4 R4.y, R1, c[16];
DP4 R4.x, R1, c[15];
DP4 R1.z, R2, c[20];
DP4 R1.x, R2, c[18];
DP4 R1.y, R2, c[19];
ADD R1.xyz, R4, R1;
MOV R2.xyz, c[13];
MOV R2.w, c[0].z;
DP4 R4.z, R2, c[11];
DP4 R4.x, R2, c[9];
DP4 R4.y, R2, c[10];
MAD R2.xyz, R4, c[22].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[33].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[21];
ADD result.texcoord[3].xyz, R1, R0;
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[31].y;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[2].xy, R0, R0.z;
MOV R5.y, R0.w;
MOV R5.w, R3.x;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
ADD result.texcoord[4].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.texcoord[3].w, R3.x;
MOV result.texcoord[4].w, R3.x;
END
# 143 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c31, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c32, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c22.w
dp3 r4.xy, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r0.x, r3
mov r0.y, r4.x
mov r0.z, r3
mov r0.w, c32.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4, r4
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c32.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c28.x
mad r0.w, r0, c31.x, c31.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c32.w, -r0
mad r1.w, r0, c31.z, c31
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c30.x
mov r0.x, c29
mad r0.y, r0, c31.x, c31
mad r0.x, r0, c31, c31.y
frc r0.x, r0
dp3 o7.x, r1, c4
frc r0.y, r0
mad r1.x, r0.y, c31.z, c31.w
mad r2.z, r0.x, c31, c31.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
rcp r0.x, r1.x
mul r0.y, r0, r0.z
mul r0.x, r1.y, r0
mad r0.z, r2.y, r0.x, r2.x
mad r0.w, r0.z, r0.y, r2.y
rcp r0.y, c27.y
rcp r0.x, c27.x
mad o2.zw, r0, r0.xyxy, c27
mov r0.z, c26.x
mad r0.z, r0, c31.x, c31.y
frc r0.z, r0
dp4 r0.w, v0, c3
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.y
mul r1.y, r1, c13.x
mad r0.z, r0, c31, c31.w
mad o3.xy, r1.z, c14.zwzw, r1
sincos r1.xy, r0.z
mul r1.zw, v0.xyzy, c25.xyxy
dp4 r0.z, v0, c2
mov o0, r0
mul r2.xy, r1.zwzw, c32
add r2.xy, r2, c25.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r2.xy, r2, c32.z
mul r1.zw, r2.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r2
add r1.w, r1.x, r1.y
mov r3.y, r4
mov r3.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o2.xy, r1.zwzw, c31.y
mov o6, r3
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c24.xyxy, c24
mad o1.xy, v2, c23, c23.zwzw
mov o4.w, r2
mov o5.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[34] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.mvp,
		program.local[5..30],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.y, c[0].x;
MUL R0.x, R3.y, c[28];
FRC R1.w, R0.x;
SLT R0, R1.w, c[31];
ADD R1.xyz, R0.yzww, -R0;
MOV R0.yzw, R1.xxyz;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R1.w, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[29];
FRC R4.w, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R4.w, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R4.w, -R3.zwzw;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R2.zw, R3, R2;
MAD R0, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R4.xxyy, c[33].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.zw, R0, R0.xyxy;
MUL R2.x, R3.y, c[30];
MOV R3.z, -R2.w;
MOV R3.w, R2.z;
MUL R3.zw, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3;
FRC R2.z, R2.x;
RCP R2.x, R1.z;
SLT R0, R2.z, c[31];
ADD R1.xyz, R0.yzww, -R0;
MUL R1.w, R1, R2.x;
MOV R0.yzw, R1.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R2.z, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[26];
FRC R3.y, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R3.y, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R3.y, -R3.zwzw;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R0.xy, R3.zwzw, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.y, R0, R0.x;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R2.zzww, c[33].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[25];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[25].zwzw;
ADD R1.xy, R1, -c[31].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[27].y;
RCP R2.z, c[27].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[27];
MUL R2.xyz, vertex.normal, c[22].w;
DP3 R0.zw, R2, c[6];
DP3 R5.x, R2, c[5];
DP3 R5.z, R2, c[7];
ADD result.texcoord[1].xy, R0, c[31].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[17];
DP4 R4.y, R1, c[16];
DP4 R4.x, R1, c[15];
DP4 R1.z, R2, c[20];
DP4 R1.x, R2, c[18];
DP4 R1.y, R2, c[19];
ADD R1.xyz, R4, R1;
MOV R2.xyz, c[13];
MOV R2.w, c[0].z;
DP4 R4.z, R2, c[11];
DP4 R4.x, R2, c[9];
DP4 R4.y, R2, c[10];
MAD R2.xyz, R4, c[22].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[33].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[21];
ADD result.texcoord[3].xyz, R1, R0;
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[31].y;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[2].xy, R0, R0.z;
MOV R5.y, R0.w;
MOV R5.w, R3.x;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
ADD result.texcoord[4].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.texcoord[3].w, R3.x;
MOV result.texcoord[4].w, R3.x;
END
# 143 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c31, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c32, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c22.w
dp3 r4.xy, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r0.x, r3
mov r0.y, r4.x
mov r0.z, r3
mov r0.w, c32.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4, r4
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c32.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c28.x
mad r0.w, r0, c31.x, c31.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c32.w, -r0
mad r1.w, r0, c31.z, c31
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c30.x
mov r0.x, c29
mad r0.y, r0, c31.x, c31
mad r0.x, r0, c31, c31.y
frc r0.x, r0
dp3 o7.x, r1, c4
frc r0.y, r0
mad r1.x, r0.y, c31.z, c31.w
mad r2.z, r0.x, c31, c31.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
rcp r0.x, r1.x
mul r0.y, r0, r0.z
mul r0.x, r1.y, r0
mad r0.z, r2.y, r0.x, r2.x
mad r0.w, r0.z, r0.y, r2.y
rcp r0.y, c27.y
rcp r0.x, c27.x
mad o2.zw, r0, r0.xyxy, c27
mov r0.z, c26.x
mad r0.z, r0, c31.x, c31.y
frc r0.z, r0
dp4 r0.w, v0, c3
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.y
mul r1.y, r1, c13.x
mad r0.z, r0, c31, c31.w
mad o3.xy, r1.z, c14.zwzw, r1
sincos r1.xy, r0.z
mul r1.zw, v0.xyzy, c25.xyxy
dp4 r0.z, v0, c2
mov o0, r0
mul r2.xy, r1.zwzw, c32
add r2.xy, r2, c25.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r2.xy, r2, c32.z
mul r1.zw, r2.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r2
add r1.w, r1.x, r1.y
mov r3.y, r4
mov r3.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o2.xy, r1.zwzw, c31.y
mov o6, r3
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c24.xyxy, c24
mad o1.xy, v2, c23, c23.zwzw
mov o4.w, r2
mov o5.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[34] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.mvp,
		program.local[5..30],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.y, c[0].x;
MUL R0.x, R3.y, c[28];
FRC R1.w, R0.x;
SLT R0, R1.w, c[31];
ADD R1.xyz, R0.yzww, -R0;
MOV R0.yzw, R1.xxyz;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R1.w, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[29];
FRC R4.w, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R4.w, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R4.w, -R3.zwzw;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R2.zw, R3, R2;
MAD R0, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R4.xxyy, c[33].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.zw, R0, R0.xyxy;
MUL R2.x, R3.y, c[30];
MOV R3.z, -R2.w;
MOV R3.w, R2.z;
MUL R3.zw, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3;
FRC R2.z, R2.x;
RCP R2.x, R1.z;
SLT R0, R2.z, c[31];
ADD R1.xyz, R0.yzww, -R0;
MUL R1.w, R1, R2.x;
MOV R0.yzw, R1.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R2.z, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[26];
FRC R3.y, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R3.y, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R3.y, -R3.zwzw;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R0.xy, R3.zwzw, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.y, R0, R0.x;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R2.zzww, c[33].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[25];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[25].zwzw;
ADD R1.xy, R1, -c[31].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[27].y;
RCP R2.z, c[27].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[27];
MUL R2.xyz, vertex.normal, c[22].w;
DP3 R0.zw, R2, c[6];
DP3 R5.x, R2, c[5];
DP3 R5.z, R2, c[7];
ADD result.texcoord[1].xy, R0, c[31].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[17];
DP4 R4.y, R1, c[16];
DP4 R4.x, R1, c[15];
DP4 R1.z, R2, c[20];
DP4 R1.x, R2, c[18];
DP4 R1.y, R2, c[19];
ADD R1.xyz, R4, R1;
MOV R2.xyz, c[13];
MOV R2.w, c[0].z;
DP4 R4.z, R2, c[11];
DP4 R4.x, R2, c[9];
DP4 R4.y, R2, c[10];
MAD R2.xyz, R4, c[22].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[33].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[21];
ADD result.texcoord[3].xyz, R1, R0;
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[31].y;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[2].xy, R0, R0.z;
MOV R5.y, R0.w;
MOV R5.w, R3.x;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
ADD result.texcoord[4].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.texcoord[3].w, R3.x;
MOV result.texcoord[4].w, R3.x;
END
# 143 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c31, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c32, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c22.w
dp3 r4.xy, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r0.x, r3
mov r0.y, r4.x
mov r0.z, r3
mov r0.w, c32.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4, r4
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c32.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c28.x
mad r0.w, r0, c31.x, c31.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c32.w, -r0
mad r1.w, r0, c31.z, c31
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c30.x
mov r0.x, c29
mad r0.y, r0, c31.x, c31
mad r0.x, r0, c31, c31.y
frc r0.x, r0
dp3 o7.x, r1, c4
frc r0.y, r0
mad r1.x, r0.y, c31.z, c31.w
mad r2.z, r0.x, c31, c31.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
rcp r0.x, r1.x
mul r0.y, r0, r0.z
mul r0.x, r1.y, r0
mad r0.z, r2.y, r0.x, r2.x
mad r0.w, r0.z, r0.y, r2.y
rcp r0.y, c27.y
rcp r0.x, c27.x
mad o2.zw, r0, r0.xyxy, c27
mov r0.z, c26.x
mad r0.z, r0, c31.x, c31.y
frc r0.z, r0
dp4 r0.w, v0, c3
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.y
mul r1.y, r1, c13.x
mad r0.z, r0, c31, c31.w
mad o3.xy, r1.z, c14.zwzw, r1
sincos r1.xy, r0.z
mul r1.zw, v0.xyzy, c25.xyxy
dp4 r0.z, v0, c2
mov o0, r0
mul r2.xy, r1.zwzw, c32
add r2.xy, r2, c25.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r2.xy, r2, c32.z
mul r1.zw, r2.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r2
add r1.w, r1.x, r1.y
mov r3.y, r4
mov r3.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o2.xy, r1.zwzw, c31.y
mov o6, r3
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c24.xyxy, c24
mad o1.xy, v2, c23, c23.zwzw
mov o4.w, r2
mov o5.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"3.0-!!ARBvp1.0
PARAM c[34] = { { 0.0027777769, 0, 1, -1 },
		state.matrix.mvp,
		program.local[5..30],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.y, c[0].x;
MUL R0.x, R3.y, c[28];
FRC R1.w, R0.x;
SLT R0, R1.w, c[31];
ADD R1.xyz, R0.yzww, -R0;
MOV R0.yzw, R1.xxyz;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R1.w, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[29];
FRC R4.w, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R4.w, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R4.w, -R3.zwzw;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R2.zw, R3, R2;
MAD R0, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R4.xxyy, c[33].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.zw, R0, R0.xyxy;
MUL R2.x, R3.y, c[30];
MOV R3.z, -R2.w;
MOV R3.w, R2.z;
MUL R3.zw, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3;
FRC R2.z, R2.x;
RCP R2.x, R1.z;
SLT R0, R2.z, c[31];
ADD R1.xyz, R0.yzww, -R0;
MUL R1.w, R1, R2.x;
MOV R0.yzw, R1.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP3 R2.x, R1, c[31].yyww;
DP4 R2.y, R0, c[31].xxzz;
ADD R1.xy, R2.z, -R2;
MUL R3.zw, R1.xyxy, R1.xyxy;
MUL R1.x, R3.y, c[26];
FRC R3.y, R1.x;
MUL R4.xy, R3.zwzw, R3.zwzw;
MAD R1, R4.xxyy, c[32].xyxy, c[32].zwzw;
MAD R1, R1, R4.xxyy, c[33].xyxy;
SLT R2, R3.y, c[31];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.z, R4, c[31].yyww;
DP4 R3.w, R1, c[31].xxzz;
ADD R2.xy, R3.y, -R3.zwzw;
DP4 R3.w, R0, c[0].zzww;
DP4 R3.z, R0, c[0].zwwz;
MUL R0.xy, R3.zwzw, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.y, R0, R0.x;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[32].xyxy, c[32].zwzw;
MAD R0, R0, R2.zzww, c[33].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[25];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[25].zwzw;
ADD R1.xy, R1, -c[31].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[27].y;
RCP R2.z, c[27].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[27];
MUL R2.xyz, vertex.normal, c[22].w;
DP3 R0.zw, R2, c[6];
DP3 R5.x, R2, c[5];
DP3 R5.z, R2, c[7];
ADD result.texcoord[1].xy, R0, c[31].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[17];
DP4 R4.y, R1, c[16];
DP4 R4.x, R1, c[15];
DP4 R1.z, R2, c[20];
DP4 R1.x, R2, c[18];
DP4 R1.y, R2, c[19];
ADD R1.xyz, R4, R1;
MOV R2.xyz, c[13];
MOV R2.w, c[0].z;
DP4 R4.z, R2, c[11];
DP4 R4.x, R2, c[9];
DP4 R4.y, R2, c[10];
MAD R2.xyz, R4, c[22].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[33].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[21];
ADD result.texcoord[3].xyz, R1, R0;
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[31].y;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[2].xy, R0, R0.z;
MOV R5.y, R0.w;
MOV R5.w, R3.x;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[6].z, R2, c[7];
DP3 result.texcoord[6].y, R2, c[6];
DP3 result.texcoord[6].x, R2, c[5];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
ADD result.texcoord[4].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MOV result.texcoord[3].w, R3.x;
MOV result.texcoord[4].w, R3.x;
END
# 143 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
Vector 23 [_MainTex_ST]
Vector 24 [_MaskTex_ST]
Vector 25 [_PatternTex_ST]
Float 26 [_PatternRotate]
Vector 27 [_DecalScaleOffset]
Float 28 [_DecalRotate]
Float 29 [_DecalShearX]
Float 30 [_DecalShearY]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c31, 0.00277778, 0.50000000, 6.28318501, -3.14159298
def c32, -1.00000000, 1.00000000, -0.50000000, 2.00000000
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c22.w
dp3 r4.xy, r1, c5
dp3 r3.x, r1, c4
dp3 r3.z, r1, c6
mov r0.x, r3
mov r0.y, r4.x
mov r0.z, r3
mov r0.w, c32.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.x, r4, r4
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c32.y
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r0.xyz, r1, c22.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c28.x
mad r0.w, r0, c31.x, c31.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c32.w, -r0
mad r1.w, r0, c31.z, c31
sincos r0.xy, r1.w
dp3 o7.z, r1, c6
dp3 o7.y, r1, c5
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c30.x
mov r0.x, c29
mad r0.y, r0, c31.x, c31
mad r0.x, r0, c31, c31.y
frc r0.x, r0
dp3 o7.x, r1, c4
frc r0.y, r0
mad r1.x, r0.y, c31.z, c31.w
mad r2.z, r0.x, c31, c31.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
rcp r0.x, r1.x
mul r0.y, r0, r0.z
mul r0.x, r1.y, r0
mad r0.z, r2.y, r0.x, r2.x
mad r0.w, r0.z, r0.y, r2.y
rcp r0.y, c27.y
rcp r0.x, c27.x
mad o2.zw, r0, r0.xyxy, c27
mov r0.z, c26.x
mad r0.z, r0, c31.x, c31.y
frc r0.z, r0
dp4 r0.w, v0, c3
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.y
mul r1.y, r1, c13.x
mad r0.z, r0, c31, c31.w
mad o3.xy, r1.z, c14.zwzw, r1
sincos r1.xy, r0.z
mul r1.zw, v0.xyzy, c25.xyxy
dp4 r0.z, v0, c2
mov o0, r0
mul r2.xy, r1.zwzw, c32
add r2.xy, r2, c25.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r2.xy, r2, c32.z
mul r1.zw, r2.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r2
add r1.w, r1.x, r1.y
mov r3.y, r4
mov r3.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o2.xy, r1.zwzw, c31.y
mov o6, r3
add o5.xyz, -r0, c12
mad o1.zw, v2.xyxy, c24.xyxy, c24
mad o1.xy, v2, c23, c23.zwzw
mov o4.w, r2
mov o5.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
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
		state.matrix.mvp,
		program.local[9..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.w, c[0].x;
MUL R0.x, R3.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP3 R1.x, R2, c[39].yyww;
DP4 R1.y, R0, c[39].xxzz;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[34];
FRC R4.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R4.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP4 R3.y, R1, c[39].xxzz;
DP3 R3.x, R4, c[39].yyww;
ADD R2.xy, R4.w, -R3;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.y, R0, c[0].zzww;
DP4 R3.x, R0, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R0, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R4.xxyy, c[41].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.xy, R0.zwzw, R0;
MUL R2.x, R3.w, c[35];
FRC R1.z, R2.x;
RCP R1.x, R1.x;
SLT R0, R1.z, c[39];
MUL R1.w, R1.y, R1.x;
MOV R3.x, -R2.w;
MOV R3.y, R2.z;
MUL R3.xy, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3.xyxy;
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[31];
FRC R3.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R3.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.x, R4, c[39].yyww;
DP4 R3.y, R1, c[39].xxzz;
ADD R2.xy, R3.w, -R3;
DP4 R3.x, R0, c[0].zwwz;
DP4 R3.y, R0, c[0].zzww;
MUL R0.xy, R3, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.x, R0.y, R0;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R2.zzww, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3.x, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
ADD R1.xy, R1, -c[39].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[32].y;
RCP R2.z, c[32].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[32];
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R0.zw, R2, c[10];
DP3 R5.x, R2, c[9];
DP3 R5.z, R2, c[11];
ADD result.texcoord[1].xy, R0, c[39].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[22];
DP4 R4.y, R1, c[21];
DP4 R4.x, R1, c[20];
DP4 R1.z, R2, c[25];
DP4 R1.x, R2, c[23];
DP4 R1.y, R2, c[24];
ADD R1.xyz, R4, R1;
MOV R2.w, c[0].z;
MOV R2.xyz, c[18];
DP4 R4.z, R2, c[15];
DP4 R4.x, R2, c[13];
DP4 R4.y, R2, c[14];
MAD R2.xyz, R4, c[27].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[41].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[26];
ADD result.texcoord[3].xyz, R1, R0;
DP3 result.texcoord[6].z, R2, c[11];
DP3 result.texcoord[6].y, R2, c[10];
DP3 result.texcoord[6].x, R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R0.xyz, R1.xyww, c[39].y;
MUL R0.y, R0, c[19].x;
ADD result.texcoord[2].xy, R0, R0.z;
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MAD R2.zw, R2.xyxy, c[36].xyxy, c[36];
MOV R2.x, c[37];
MOV R2.y, c[38].x;
MAD R2.xy, R2, c[17].y, R2.zwzw;
MOV R5.w, R2.x;
MOV R5.y, R0.w;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R3.z;
END
# 149 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
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
mul r1.xyz, v1, c27.w
dp3 r3.yw, r1, c9
dp3 r3.x, r1, c8
dp3 r3.z, r1, c10
mov r0.x, r3
mov r0.y, r3.w
mov r0.z, r3
mov r0.w, c40.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c22
dp4 r2.y, r0, c21
dp4 r2.x, r0, c20
mul r0.x, r3.w, r3.w
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c25
dp4 r0.y, r1, c24
dp4 r0.x, r1, c23
mul r1.xyz, r0.w, c26
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c40.y
mov r0.xyz, c17
dp4 r1.z, r0, c14
dp4 r1.y, r0, c13
dp4 r1.x, r0, c12
mad r0.xyz, r1, c27.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c33.x
mad r0.w, r0, c39.x, c39.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c40.w, -r0
mad r1.w, r0, c39.z, c39
sincos r0.xy, r1.w
dp3 o7.z, r1, c10
dp3 o7.y, r1, c9
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c35.x
mov r0.x, c34
mad r0.y, r0, c39.x, c39
mad r0.x, r0, c39, c39.y
frc r0.x, r0
dp3 o7.x, r1, c8
frc r0.y, r0
mad r1.x, r0.y, c39.z, c39.w
mad r2.z, r0.x, c39, c39.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
mul r0.y, r0, r0.z
rcp r0.x, r1.x
mul r0.x, r1.y, r0
mad r2.x, r2.y, r0, r2
mad r2.y, r2.x, r0, r2
mov r0.z, c31.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
dp4 r0.w, v0, c7
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c39.y
mul r1.y, r1, c18.x
mad o3.xy, r1.z, c19.zwzw, r1
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mad r1.zw, r1.xyxy, c36.xyxy, c36
mov r1.x, c37
mov r1.y, c38.x
mad r0.z, r0, c39, c39.w
rcp r4.y, c32.y
rcp r4.x, c32.x
mad o2.zw, r2.xyxy, r4.xyxy, c32
mad r2.xy, r1, c16.y, r1.zwzw
sincos r1.xy, r0.z
dp4 r0.z, v0, c6
mov o0, r0
mul r1.zw, v0.xyzy, c30.xyxy
mov r3.w, r2.x
mov o6, r3
mul r3.xy, r1.zwzw, c40
add r3.xy, r3, c30.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r3.xy, r3, c40.z
mul r1.zw, r3.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r3
add r1.w, r1.x, r1.y
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add o2.xy, r1.zwzw, c39.y
mov o5.w, r2.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
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
		state.matrix.mvp,
		program.local[9..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.w, c[0].x;
MUL R0.x, R3.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP3 R1.x, R2, c[39].yyww;
DP4 R1.y, R0, c[39].xxzz;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[34];
FRC R4.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R4.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP4 R3.y, R1, c[39].xxzz;
DP3 R3.x, R4, c[39].yyww;
ADD R2.xy, R4.w, -R3;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.y, R0, c[0].zzww;
DP4 R3.x, R0, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R0, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R4.xxyy, c[41].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.xy, R0.zwzw, R0;
MUL R2.x, R3.w, c[35];
FRC R1.z, R2.x;
RCP R1.x, R1.x;
SLT R0, R1.z, c[39];
MUL R1.w, R1.y, R1.x;
MOV R3.x, -R2.w;
MOV R3.y, R2.z;
MUL R3.xy, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3.xyxy;
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[31];
FRC R3.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R3.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.x, R4, c[39].yyww;
DP4 R3.y, R1, c[39].xxzz;
ADD R2.xy, R3.w, -R3;
DP4 R3.x, R0, c[0].zwwz;
DP4 R3.y, R0, c[0].zzww;
MUL R0.xy, R3, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.x, R0.y, R0;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R2.zzww, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3.x, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
ADD R1.xy, R1, -c[39].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[32].y;
RCP R2.z, c[32].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[32];
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R0.zw, R2, c[10];
DP3 R5.x, R2, c[9];
DP3 R5.z, R2, c[11];
ADD result.texcoord[1].xy, R0, c[39].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[22];
DP4 R4.y, R1, c[21];
DP4 R4.x, R1, c[20];
DP4 R1.z, R2, c[25];
DP4 R1.x, R2, c[23];
DP4 R1.y, R2, c[24];
ADD R1.xyz, R4, R1;
MOV R2.w, c[0].z;
MOV R2.xyz, c[18];
DP4 R4.z, R2, c[15];
DP4 R4.x, R2, c[13];
DP4 R4.y, R2, c[14];
MAD R2.xyz, R4, c[27].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[41].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[26];
ADD result.texcoord[3].xyz, R1, R0;
DP3 result.texcoord[6].z, R2, c[11];
DP3 result.texcoord[6].y, R2, c[10];
DP3 result.texcoord[6].x, R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R0.xyz, R1.xyww, c[39].y;
MUL R0.y, R0, c[19].x;
ADD result.texcoord[2].xy, R0, R0.z;
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MAD R2.zw, R2.xyxy, c[36].xyxy, c[36];
MOV R2.x, c[37];
MOV R2.y, c[38].x;
MAD R2.xy, R2, c[17].y, R2.zwzw;
MOV R5.w, R2.x;
MOV R5.y, R0.w;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R3.z;
END
# 149 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
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
mul r1.xyz, v1, c27.w
dp3 r3.yw, r1, c9
dp3 r3.x, r1, c8
dp3 r3.z, r1, c10
mov r0.x, r3
mov r0.y, r3.w
mov r0.z, r3
mov r0.w, c40.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c22
dp4 r2.y, r0, c21
dp4 r2.x, r0, c20
mul r0.x, r3.w, r3.w
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c25
dp4 r0.y, r1, c24
dp4 r0.x, r1, c23
mul r1.xyz, r0.w, c26
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c40.y
mov r0.xyz, c17
dp4 r1.z, r0, c14
dp4 r1.y, r0, c13
dp4 r1.x, r0, c12
mad r0.xyz, r1, c27.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c33.x
mad r0.w, r0, c39.x, c39.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c40.w, -r0
mad r1.w, r0, c39.z, c39
sincos r0.xy, r1.w
dp3 o7.z, r1, c10
dp3 o7.y, r1, c9
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c35.x
mov r0.x, c34
mad r0.y, r0, c39.x, c39
mad r0.x, r0, c39, c39.y
frc r0.x, r0
dp3 o7.x, r1, c8
frc r0.y, r0
mad r1.x, r0.y, c39.z, c39.w
mad r2.z, r0.x, c39, c39.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
mul r0.y, r0, r0.z
rcp r0.x, r1.x
mul r0.x, r1.y, r0
mad r2.x, r2.y, r0, r2
mad r2.y, r2.x, r0, r2
mov r0.z, c31.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
dp4 r0.w, v0, c7
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c39.y
mul r1.y, r1, c18.x
mad o3.xy, r1.z, c19.zwzw, r1
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mad r1.zw, r1.xyxy, c36.xyxy, c36
mov r1.x, c37
mov r1.y, c38.x
mad r0.z, r0, c39, c39.w
rcp r4.y, c32.y
rcp r4.x, c32.x
mad o2.zw, r2.xyxy, r4.xyxy, c32
mad r2.xy, r1, c16.y, r1.zwzw
sincos r1.xy, r0.z
dp4 r0.z, v0, c6
mov o0, r0
mul r1.zw, v0.xyzy, c30.xyxy
mov r3.w, r2.x
mov o6, r3
mul r3.xy, r1.zwzw, c40
add r3.xy, r3, c30.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r3.xy, r3, c40.z
mul r1.zw, r3.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r3
add r1.w, r1.x, r1.y
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add o2.xy, r1.zwzw, c39.y
mov o5.w, r2.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
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
		state.matrix.mvp,
		program.local[9..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.w, c[0].x;
MUL R0.x, R3.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP3 R1.x, R2, c[39].yyww;
DP4 R1.y, R0, c[39].xxzz;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[34];
FRC R4.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R4.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP4 R3.y, R1, c[39].xxzz;
DP3 R3.x, R4, c[39].yyww;
ADD R2.xy, R4.w, -R3;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.y, R0, c[0].zzww;
DP4 R3.x, R0, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R0, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R4.xxyy, c[41].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.xy, R0.zwzw, R0;
MUL R2.x, R3.w, c[35];
FRC R1.z, R2.x;
RCP R1.x, R1.x;
SLT R0, R1.z, c[39];
MUL R1.w, R1.y, R1.x;
MOV R3.x, -R2.w;
MOV R3.y, R2.z;
MUL R3.xy, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3.xyxy;
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[31];
FRC R3.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R3.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.x, R4, c[39].yyww;
DP4 R3.y, R1, c[39].xxzz;
ADD R2.xy, R3.w, -R3;
DP4 R3.x, R0, c[0].zwwz;
DP4 R3.y, R0, c[0].zzww;
MUL R0.xy, R3, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.x, R0.y, R0;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R2.zzww, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3.x, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
ADD R1.xy, R1, -c[39].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[32].y;
RCP R2.z, c[32].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[32];
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R0.zw, R2, c[10];
DP3 R5.x, R2, c[9];
DP3 R5.z, R2, c[11];
ADD result.texcoord[1].xy, R0, c[39].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[22];
DP4 R4.y, R1, c[21];
DP4 R4.x, R1, c[20];
DP4 R1.z, R2, c[25];
DP4 R1.x, R2, c[23];
DP4 R1.y, R2, c[24];
ADD R1.xyz, R4, R1;
MOV R2.w, c[0].z;
MOV R2.xyz, c[18];
DP4 R4.z, R2, c[15];
DP4 R4.x, R2, c[13];
DP4 R4.y, R2, c[14];
MAD R2.xyz, R4, c[27].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[41].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[26];
ADD result.texcoord[3].xyz, R1, R0;
DP3 result.texcoord[6].z, R2, c[11];
DP3 result.texcoord[6].y, R2, c[10];
DP3 result.texcoord[6].x, R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R0.xyz, R1.xyww, c[39].y;
MUL R0.y, R0, c[19].x;
ADD result.texcoord[2].xy, R0, R0.z;
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MAD R2.zw, R2.xyxy, c[36].xyxy, c[36];
MOV R2.x, c[37];
MOV R2.y, c[38].x;
MAD R2.xy, R2, c[17].y, R2.zwzw;
MOV R5.w, R2.x;
MOV R5.y, R0.w;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R3.z;
END
# 149 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
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
mul r1.xyz, v1, c27.w
dp3 r3.yw, r1, c9
dp3 r3.x, r1, c8
dp3 r3.z, r1, c10
mov r0.x, r3
mov r0.y, r3.w
mov r0.z, r3
mov r0.w, c40.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c22
dp4 r2.y, r0, c21
dp4 r2.x, r0, c20
mul r0.x, r3.w, r3.w
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c25
dp4 r0.y, r1, c24
dp4 r0.x, r1, c23
mul r1.xyz, r0.w, c26
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c40.y
mov r0.xyz, c17
dp4 r1.z, r0, c14
dp4 r1.y, r0, c13
dp4 r1.x, r0, c12
mad r0.xyz, r1, c27.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c33.x
mad r0.w, r0, c39.x, c39.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c40.w, -r0
mad r1.w, r0, c39.z, c39
sincos r0.xy, r1.w
dp3 o7.z, r1, c10
dp3 o7.y, r1, c9
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c35.x
mov r0.x, c34
mad r0.y, r0, c39.x, c39
mad r0.x, r0, c39, c39.y
frc r0.x, r0
dp3 o7.x, r1, c8
frc r0.y, r0
mad r1.x, r0.y, c39.z, c39.w
mad r2.z, r0.x, c39, c39.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
mul r0.y, r0, r0.z
rcp r0.x, r1.x
mul r0.x, r1.y, r0
mad r2.x, r2.y, r0, r2
mad r2.y, r2.x, r0, r2
mov r0.z, c31.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
dp4 r0.w, v0, c7
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c39.y
mul r1.y, r1, c18.x
mad o3.xy, r1.z, c19.zwzw, r1
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mad r1.zw, r1.xyxy, c36.xyxy, c36
mov r1.x, c37
mov r1.y, c38.x
mad r0.z, r0, c39, c39.w
rcp r4.y, c32.y
rcp r4.x, c32.x
mad o2.zw, r2.xyxy, r4.xyxy, c32
mad r2.xy, r1, c16.y, r1.zwzw
sincos r1.xy, r0.z
dp4 r0.z, v0, c6
mov o0, r0
mul r1.zw, v0.xyzy, c30.xyxy
mov r3.w, r2.x
mov o6, r3
mul r3.xy, r1.zwzw, c40
add r3.xy, r3, c30.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r3.xy, r3, c40.z
mul r1.zw, r3.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r3
add r1.w, r1.x, r1.y
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add o2.xy, r1.zwzw, c39.y
mov o5.w, r2.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
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
		state.matrix.mvp,
		program.local[9..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.w, c[0].x;
MUL R0.x, R3.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP3 R1.x, R2, c[39].yyww;
DP4 R1.y, R0, c[39].xxzz;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[34];
FRC R4.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R4.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP4 R3.y, R1, c[39].xxzz;
DP3 R3.x, R4, c[39].yyww;
ADD R2.xy, R4.w, -R3;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.y, R0, c[0].zzww;
DP4 R3.x, R0, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R0, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R4.xxyy, c[41].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.xy, R0.zwzw, R0;
MUL R2.x, R3.w, c[35];
FRC R1.z, R2.x;
RCP R1.x, R1.x;
SLT R0, R1.z, c[39];
MUL R1.w, R1.y, R1.x;
MOV R3.x, -R2.w;
MOV R3.y, R2.z;
MUL R3.xy, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3.xyxy;
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[31];
FRC R3.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R3.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.x, R4, c[39].yyww;
DP4 R3.y, R1, c[39].xxzz;
ADD R2.xy, R3.w, -R3;
DP4 R3.x, R0, c[0].zwwz;
DP4 R3.y, R0, c[0].zzww;
MUL R0.xy, R3, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.x, R0.y, R0;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R2.zzww, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3.x, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
ADD R1.xy, R1, -c[39].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[32].y;
RCP R2.z, c[32].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[32];
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R0.zw, R2, c[10];
DP3 R5.x, R2, c[9];
DP3 R5.z, R2, c[11];
ADD result.texcoord[1].xy, R0, c[39].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[22];
DP4 R4.y, R1, c[21];
DP4 R4.x, R1, c[20];
DP4 R1.z, R2, c[25];
DP4 R1.x, R2, c[23];
DP4 R1.y, R2, c[24];
ADD R1.xyz, R4, R1;
MOV R2.w, c[0].z;
MOV R2.xyz, c[18];
DP4 R4.z, R2, c[15];
DP4 R4.x, R2, c[13];
DP4 R4.y, R2, c[14];
MAD R2.xyz, R4, c[27].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[41].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[26];
ADD result.texcoord[3].xyz, R1, R0;
DP3 result.texcoord[6].z, R2, c[11];
DP3 result.texcoord[6].y, R2, c[10];
DP3 result.texcoord[6].x, R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R0.xyz, R1.xyww, c[39].y;
MUL R0.y, R0, c[19].x;
ADD result.texcoord[2].xy, R0, R0.z;
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MAD R2.zw, R2.xyxy, c[36].xyxy, c[36];
MOV R2.x, c[37];
MOV R2.y, c[38].x;
MAD R2.xy, R2, c[17].y, R2.zwzw;
MOV R5.w, R2.x;
MOV R5.y, R0.w;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R3.z;
END
# 149 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
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
mul r1.xyz, v1, c27.w
dp3 r3.yw, r1, c9
dp3 r3.x, r1, c8
dp3 r3.z, r1, c10
mov r0.x, r3
mov r0.y, r3.w
mov r0.z, r3
mov r0.w, c40.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c22
dp4 r2.y, r0, c21
dp4 r2.x, r0, c20
mul r0.x, r3.w, r3.w
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c25
dp4 r0.y, r1, c24
dp4 r0.x, r1, c23
mul r1.xyz, r0.w, c26
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c40.y
mov r0.xyz, c17
dp4 r1.z, r0, c14
dp4 r1.y, r0, c13
dp4 r1.x, r0, c12
mad r0.xyz, r1, c27.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c33.x
mad r0.w, r0, c39.x, c39.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c40.w, -r0
mad r1.w, r0, c39.z, c39
sincos r0.xy, r1.w
dp3 o7.z, r1, c10
dp3 o7.y, r1, c9
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c35.x
mov r0.x, c34
mad r0.y, r0, c39.x, c39
mad r0.x, r0, c39, c39.y
frc r0.x, r0
dp3 o7.x, r1, c8
frc r0.y, r0
mad r1.x, r0.y, c39.z, c39.w
mad r2.z, r0.x, c39, c39.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
mul r0.y, r0, r0.z
rcp r0.x, r1.x
mul r0.x, r1.y, r0
mad r2.x, r2.y, r0, r2
mad r2.y, r2.x, r0, r2
mov r0.z, c31.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
dp4 r0.w, v0, c7
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c39.y
mul r1.y, r1, c18.x
mad o3.xy, r1.z, c19.zwzw, r1
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mad r1.zw, r1.xyxy, c36.xyxy, c36
mov r1.x, c37
mov r1.y, c38.x
mad r0.z, r0, c39, c39.w
rcp r4.y, c32.y
rcp r4.x, c32.x
mad o2.zw, r2.xyxy, r4.xyxy, c32
mad r2.xy, r1, c16.y, r1.zwzw
sincos r1.xy, r0.z
dp4 r0.z, v0, c6
mov o0, r0
mul r1.zw, v0.xyzy, c30.xyxy
mov r3.w, r2.x
mov o6, r3
mul r3.xy, r1.zwzw, c40
add r3.xy, r3, c30.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r3.xy, r3, c40.z
mul r1.zw, r3.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r3
add r1.w, r1.x, r1.y
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add o2.xy, r1.zwzw, c39.y
mov o5.w, r2.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
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
		state.matrix.mvp,
		program.local[9..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.w, c[0].x;
MUL R0.x, R3.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP3 R1.x, R2, c[39].yyww;
DP4 R1.y, R0, c[39].xxzz;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[34];
FRC R4.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R4.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP4 R3.y, R1, c[39].xxzz;
DP3 R3.x, R4, c[39].yyww;
ADD R2.xy, R4.w, -R3;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.y, R0, c[0].zzww;
DP4 R3.x, R0, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R0, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R4.xxyy, c[41].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.xy, R0.zwzw, R0;
MUL R2.x, R3.w, c[35];
FRC R1.z, R2.x;
RCP R1.x, R1.x;
SLT R0, R1.z, c[39];
MUL R1.w, R1.y, R1.x;
MOV R3.x, -R2.w;
MOV R3.y, R2.z;
MUL R3.xy, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3.xyxy;
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[31];
FRC R3.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R3.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.x, R4, c[39].yyww;
DP4 R3.y, R1, c[39].xxzz;
ADD R2.xy, R3.w, -R3;
DP4 R3.x, R0, c[0].zwwz;
DP4 R3.y, R0, c[0].zzww;
MUL R0.xy, R3, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.x, R0.y, R0;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R2.zzww, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3.x, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
ADD R1.xy, R1, -c[39].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[32].y;
RCP R2.z, c[32].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[32];
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R0.zw, R2, c[10];
DP3 R5.x, R2, c[9];
DP3 R5.z, R2, c[11];
ADD result.texcoord[1].xy, R0, c[39].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[22];
DP4 R4.y, R1, c[21];
DP4 R4.x, R1, c[20];
DP4 R1.z, R2, c[25];
DP4 R1.x, R2, c[23];
DP4 R1.y, R2, c[24];
ADD R1.xyz, R4, R1;
MOV R2.w, c[0].z;
MOV R2.xyz, c[18];
DP4 R4.z, R2, c[15];
DP4 R4.x, R2, c[13];
DP4 R4.y, R2, c[14];
MAD R2.xyz, R4, c[27].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[41].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[26];
ADD result.texcoord[3].xyz, R1, R0;
DP3 result.texcoord[6].z, R2, c[11];
DP3 result.texcoord[6].y, R2, c[10];
DP3 result.texcoord[6].x, R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R0.xyz, R1.xyww, c[39].y;
MUL R0.y, R0, c[19].x;
ADD result.texcoord[2].xy, R0, R0.z;
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MAD R2.zw, R2.xyxy, c[36].xyxy, c[36];
MOV R2.x, c[37];
MOV R2.y, c[38].x;
MAD R2.xy, R2, c[17].y, R2.zwzw;
MOV R5.w, R2.x;
MOV R5.y, R0.w;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R3.z;
END
# 149 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
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
mul r1.xyz, v1, c27.w
dp3 r3.yw, r1, c9
dp3 r3.x, r1, c8
dp3 r3.z, r1, c10
mov r0.x, r3
mov r0.y, r3.w
mov r0.z, r3
mov r0.w, c40.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c22
dp4 r2.y, r0, c21
dp4 r2.x, r0, c20
mul r0.x, r3.w, r3.w
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c25
dp4 r0.y, r1, c24
dp4 r0.x, r1, c23
mul r1.xyz, r0.w, c26
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c40.y
mov r0.xyz, c17
dp4 r1.z, r0, c14
dp4 r1.y, r0, c13
dp4 r1.x, r0, c12
mad r0.xyz, r1, c27.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c33.x
mad r0.w, r0, c39.x, c39.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c40.w, -r0
mad r1.w, r0, c39.z, c39
sincos r0.xy, r1.w
dp3 o7.z, r1, c10
dp3 o7.y, r1, c9
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c35.x
mov r0.x, c34
mad r0.y, r0, c39.x, c39
mad r0.x, r0, c39, c39.y
frc r0.x, r0
dp3 o7.x, r1, c8
frc r0.y, r0
mad r1.x, r0.y, c39.z, c39.w
mad r2.z, r0.x, c39, c39.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
mul r0.y, r0, r0.z
rcp r0.x, r1.x
mul r0.x, r1.y, r0
mad r2.x, r2.y, r0, r2
mad r2.y, r2.x, r0, r2
mov r0.z, c31.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
dp4 r0.w, v0, c7
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c39.y
mul r1.y, r1, c18.x
mad o3.xy, r1.z, c19.zwzw, r1
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mad r1.zw, r1.xyxy, c36.xyxy, c36
mov r1.x, c37
mov r1.y, c38.x
mad r0.z, r0, c39, c39.w
rcp r4.y, c32.y
rcp r4.x, c32.x
mad o2.zw, r2.xyxy, r4.xyxy, c32
mad r2.xy, r1, c16.y, r1.zwzw
sincos r1.xy, r0.z
dp4 r0.z, v0, c6
mov o0, r0
mul r1.zw, v0.xyzy, c30.xyxy
mov r3.w, r2.x
mov o6, r3
mul r3.xy, r1.zwzw, c40
add r3.xy, r3, c30.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r3.xy, r3, c40.z
mul r1.zw, r3.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r3
add r1.w, r1.x, r1.y
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add o2.xy, r1.zwzw, c39.y
mov o5.w, r2.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r2
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
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
		state.matrix.mvp,
		program.local[9..38],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R3.w, c[0].x;
MUL R0.x, R3.w, c[33];
FRC R1.z, R0.x;
SLT R0, R1.z, c[39];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP3 R1.x, R2, c[39].yyww;
DP4 R1.y, R0, c[39].xxzz;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[34];
FRC R4.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R4.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP4 R3.y, R1, c[39].xxzz;
DP3 R3.x, R4, c[39].yyww;
ADD R2.xy, R4.w, -R3;
MUL R2.xy, R2, R2;
MUL R4.xy, R2, R2;
DP4 R3.y, R0, c[0].zzww;
DP4 R3.x, R0, c[0].zwwz;
MUL R2.zw, R3.xyxy, R2;
MAD R0, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R4.xxyy, c[41].xyxy;
MAD R0.xy, R0.xzzw, R2, R0.ywzw;
DP4 R0.w, R1, c[0].zzww;
DP4 R0.z, R1, c[0].zwwz;
MUL R1.xy, R0.zwzw, R0;
MUL R2.x, R3.w, c[35];
FRC R1.z, R2.x;
RCP R1.x, R1.x;
SLT R0, R1.z, c[39];
MUL R1.w, R1.y, R1.x;
MOV R3.x, -R2.w;
MOV R3.y, R2.z;
MUL R3.xy, vertex.position.z, R3;
MAD R4.zw, vertex.position.y, R2, R3.xyxy;
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
MAD R5.x, R4.w, R1.w, R4.z;
DP4 R1.y, R0, c[39].xxzz;
DP3 R1.x, R2, c[39].yyww;
ADD R1.xy, R1.z, -R1;
MUL R3.xy, R1, R1;
MUL R1.x, R3.w, c[31];
FRC R3.w, R1.x;
MUL R4.xy, R3, R3;
MAD R1, R4.xxyy, c[40].xyxy, c[40].zwzw;
MAD R1, R1, R4.xxyy, c[41].xyxy;
SLT R2, R3.w, c[39];
ADD R4.xyz, R2.yzww, -R2;
MAD R2.zw, R1.xyxz, R3.xyxy, R1.xyyw;
MOV R1.yzw, R4.xxyz;
MOV R1.x, R2;
DP3 R3.x, R4, c[39].yyww;
DP4 R3.y, R1, c[39].xxzz;
ADD R2.xy, R3.w, -R3;
DP4 R3.x, R0, c[0].zwwz;
DP4 R3.y, R0, c[0].zzww;
MUL R0.xy, R3, R2.zwzw;
MUL R2.xy, R2, R2;
RCP R0.x, R0.x;
MUL R3.x, R0.y, R0;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R0, R2.zzww, c[40].xyxy, c[40].zwzw;
MAD R0, R0, R2.zzww, c[41].xyxy;
MAD R0.zw, R0.xyxz, R2.xyxy, R0.xyyw;
MAD R5.y, R5.x, R3.x, R4.w;
DP4 R0.y, R1, c[0].zzww;
DP4 R0.x, R1, c[0].zwwz;
MUL R0.xy, R0, R0.zwzw;
MUL R1.xy, vertex.position.zyzw, c[30];
MUL R1.xy, R1, c[0].wzzw;
ADD R1.xy, R1, c[30].zwzw;
ADD R1.xy, R1, -c[39].y;
MOV R0.z, R0.x;
MOV R0.w, -R0.y;
MUL R1.zw, R1.xyxy, R0;
MUL R0.zw, R0.xyyx, R1.xyxy;
ADD R0.x, R1.z, R1.w;
ADD R0.y, R0.z, R0.w;
MOV R1.w, c[0].z;
RCP R2.w, c[32].y;
RCP R2.z, c[32].x;
MAD result.texcoord[1].zw, R5.xyxy, R2, c[32];
MUL R2.xyz, vertex.normal, c[27].w;
DP3 R0.zw, R2, c[10];
DP3 R5.x, R2, c[9];
DP3 R5.z, R2, c[11];
ADD result.texcoord[1].xy, R0, c[39].y;
MUL R0.x, R0.z, R0.z;
MOV R1.y, R0.z;
MOV R1.x, R5;
MOV R1.z, R5;
MUL R2, R1.xyzz, R1.yzzx;
DP4 R4.z, R1, c[22];
DP4 R4.y, R1, c[21];
DP4 R4.x, R1, c[20];
DP4 R1.z, R2, c[25];
DP4 R1.x, R2, c[23];
DP4 R1.y, R2, c[24];
ADD R1.xyz, R4, R1;
MOV R2.w, c[0].z;
MOV R2.xyz, c[18];
DP4 R4.z, R2, c[15];
DP4 R4.x, R2, c[13];
DP4 R4.y, R2, c[14];
MAD R2.xyz, R4, c[27].w, -vertex.position;
DP3 R0.y, vertex.normal, -R2;
MUL R4.xyz, vertex.normal, R0.y;
MAD R2.xyz, -R4, c[41].z, -R2;
MAD R0.x, R5, R5, -R0;
MUL R0.xyz, R0.x, c[26];
ADD result.texcoord[3].xyz, R1, R0;
DP3 result.texcoord[6].z, R2, c[11];
DP3 result.texcoord[6].y, R2, c[10];
DP3 result.texcoord[6].x, R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R0.xyz, R1.xyww, c[39].y;
MUL R0.y, R0, c[19].x;
ADD result.texcoord[2].xy, R0, R0.z;
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MAD R2.zw, R2.xyxy, c[36].xyxy, c[36];
MOV R2.x, c[37];
MOV R2.y, c[38].x;
MAD R2.xy, R2, c[17].y, R2.zwzw;
MOV R5.w, R2.x;
MOV R5.y, R0.w;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[5], R5;
MOV result.position, R1;
MOV result.texcoord[2].zw, R1;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[18];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[3].w, R3.z;
END
# 149 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
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
mul r1.xyz, v1, c27.w
dp3 r3.yw, r1, c9
dp3 r3.x, r1, c8
dp3 r3.z, r1, c10
mov r0.x, r3
mov r0.y, r3.w
mov r0.z, r3
mov r0.w, c40.y
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c22
dp4 r2.y, r0, c21
dp4 r2.x, r0, c20
mul r0.x, r3.w, r3.w
mad r0.w, r3.x, r3.x, -r0.x
dp4 r0.z, r1, c25
dp4 r0.y, r1, c24
dp4 r0.x, r1, c23
mul r1.xyz, r0.w, c26
add r0.xyz, r2, r0
add o4.xyz, r0, r1
mov r0.w, c40.y
mov r0.xyz, c17
dp4 r1.z, r0, c14
dp4 r1.y, r0, c13
dp4 r1.x, r0, c12
mad r0.xyz, r1, c27.w, -v0
dp3 r1.x, v1, -r0
mov r0.w, c33.x
mad r0.w, r0, c39.x, c39.y
frc r0.w, r0
mul r1.xyz, v1, r1.x
mad r1.xyz, -r1, c40.w, -r0
mad r1.w, r0, c39.z, c39
sincos r0.xy, r1.w
dp3 o7.z, r1, c10
dp3 o7.y, r1, c9
mov r0.w, r0.x
mov r0.z, -r0.y
mul r0.zw, v0.z, r0
mad r2.xy, v0.y, r0, r0.zwzw
mov r0.y, c35.x
mov r0.x, c34
mad r0.y, r0, c39.x, c39
mad r0.x, r0, c39, c39.y
frc r0.x, r0
dp3 o7.x, r1, c8
frc r0.y, r0
mad r1.x, r0.y, c39.z, c39.w
mad r2.z, r0.x, c39, c39.w
sincos r0.xy, r1.x
sincos r1.xy, r2.z
rcp r0.z, r0.x
mul r0.y, r0, r0.z
rcp r0.x, r1.x
mul r0.x, r1.y, r0
mad r2.x, r2.y, r0, r2
mad r2.y, r2.x, r0, r2
mov r0.z, c31.x
mad r0.z, r0, c39.x, c39.y
frc r0.z, r0
dp4 r0.w, v0, c7
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c39.y
mul r1.y, r1, c18.x
mad o3.xy, r1.z, c19.zwzw, r1
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mad r1.zw, r1.xyxy, c36.xyxy, c36
mov r1.x, c37
mov r1.y, c38.x
mad r0.z, r0, c39, c39.w
rcp r4.y, c32.y
rcp r4.x, c32.x
mad o2.zw, r2.xyxy, r4.xyxy, c32
mad r2.xy, r1, c16.y, r1.zwzw
sincos r1.xy, r0.z
dp4 r0.z, v0, c6
mov o0, r0
mul r1.zw, v0.xyzy, c30.xyxy
mov r3.w, r2.x
mov o6, r3
mul r3.xy, r1.zwzw, c40
add r3.xy, r3, c30.zwzw
mov o3.zw, r0
mov r1.z, r1.x
mov r1.w, -r1.y
add r3.xy, r3, c40.z
mul r1.zw, r3.xyxy, r1
add r1.z, r1, r1.w
mul r1.xy, r1.yxzw, r3
add r1.w, r1.x, r1.y
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add o2.xy, r1.zwzw, c39.y
mov o5.w, r2.y
add o5.xyz, -r0, c17
mad o1.zw, v2.xyxy, c29.xyxy, c29
mad o1.xy, v2, c28, c28.zwzw
mov o4.w, r2
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[24] = { program.local[0..21],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[23];
MAD R1.w, R2.x, c[23].z, R0;
MAD R2.w, R2.z, c[23].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[22], R0;
SLT R3.w, R2, c[5].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[22].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[23], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[23].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[23].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[23].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[22].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R1.w, R1.x, c[11].x, R1;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[22].z;
MOV_SAT R1.w, c[20].x;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R4.xyz, R3.y, R4;
LG2 R0.w, R2.w;
MUL R1.w, R1.y, R1;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R0.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MAD R4.xyz, R2, c[22].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
DP3_SAT R1.w, R2, R3;
ADD R1.x, -R1.w, c[22];
MUL R0.xyz, R0, R0.w;
MAD result.color.xyz, R0, R1.x, R4;
MOV result.color.w, c[22].x;
END
# 103 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[24] = { program.local[0..21],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[23];
MAD R1.w, R2.x, c[23].z, R0;
MAD R2.w, R2.z, c[23].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[22], R0;
SLT R3.w, R2, c[5].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[22].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[23], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[23].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[23].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[23].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[22].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R1.w, R1.x, c[11].x, R1;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[22].z;
MOV_SAT R1.w, c[20].x;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R4.xyz, R3.y, R4;
LG2 R0.w, R2.w;
MUL R1.w, R1.y, R1;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R0.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MAD R4.xyz, R2, c[22].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
DP3_SAT R1.w, R2, R3;
ADD R1.x, -R1.w, c[22];
MUL R0.xyz, R0, R0.w;
MAD result.color.xyz, R0, R1.x, R4;
MOV result.color.w, c[22].x;
END
# 103 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[24] = { program.local[0..21],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[23];
MAD R1.w, R2.x, c[23].z, R0;
MAD R2.w, R2.z, c[23].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[22], R0;
SLT R3.w, R2, c[5].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[22].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[23], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[23].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[23].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[23].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[22].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R1.w, R1.x, c[11].x, R1;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[22].z;
MOV_SAT R1.w, c[20].x;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R4.xyz, R3.y, R4;
LG2 R0.w, R2.w;
MUL R1.w, R1.y, R1;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R0.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MAD R4.xyz, R2, c[22].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
DP3_SAT R1.w, R2, R3;
ADD R1.x, -R1.w, c[22];
MUL R0.xyz, R0, R0.w;
MAD result.color.xyz, R0, R1.x, R4;
MOV result.color.w, c[22].x;
END
# 103 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
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
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[24] = { program.local[0..21],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[23];
MAD R1.w, R2.x, c[23].z, R0;
MAD R2.w, R2.z, c[23].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[22], R0;
SLT R3.w, R2, c[5].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[22].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[23], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[23].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[23].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[23].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[22].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R1.w, R1.x, c[11].x, R1;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[22].z;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MOV_SAT R0.w, c[20].x;
MUL R1.w, R1.y, R0;
MUL R5.xyz, R2, R2.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MUL R4.xyz, R3.y, R4;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MAD R4.xyz, R2, c[22].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
DP3_SAT R1.w, R2, R3;
ADD R1.x, -R1.w, c[22];
MUL R0.xyz, R0, R0.w;
MAD result.color.xyz, R0, R1.x, R4;
MOV result.color.w, c[22].x;
END
# 99 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[24] = { program.local[0..21],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[23];
MAD R1.w, R2.x, c[23].z, R0;
MAD R2.w, R2.z, c[23].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[22], R0;
SLT R3.w, R2, c[5].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[22].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[23], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[23].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[23].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[23].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[22].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R1.w, R1.x, c[11].x, R1;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[22].z;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MOV_SAT R0.w, c[20].x;
MUL R1.w, R1.y, R0;
MUL R5.xyz, R2, R2.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MUL R4.xyz, R3.y, R4;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MAD R4.xyz, R2, c[22].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
DP3_SAT R1.w, R2, R3;
ADD R1.x, -R1.w, c[22];
MUL R0.xyz, R0, R0.w;
MAD result.color.xyz, R0, R1.x, R4;
MOV result.color.w, c[22].x;
END
# 99 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[24] = { program.local[0..21],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[23];
MAD R1.w, R2.x, c[23].z, R0;
MAD R2.w, R2.z, c[23].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[22], R0;
SLT R3.w, R2, c[5].x;
MUL R0.w, R1, R3;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[22].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[23], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[23].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[23].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[23].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[22].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R1.w, R1.x, c[11].x, R1;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[22].z;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MOV_SAT R0.w, c[20].x;
MUL R1.w, R1.y, R0;
MUL R5.xyz, R2, R2.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MUL R4.xyz, R3.y, R4;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MAD R4.xyz, R2, c[22].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
DP3_SAT R1.w, R2, R3;
ADD R1.x, -R1.w, c[22];
MUL R0.xyz, R0, R0.w;
MAD result.color.xyz, R0, R1.x, R4;
MOV result.color.w, c[22].x;
END
# 99 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
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
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[25] = { program.local[0..22],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[24];
MAD R1.w, R2.x, c[24].z, R0;
MAD R2.w, R2.z, c[24].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[23], R0;
SLT R3.w, R2, c[5].x;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
MUL R0.w, R1, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[23].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[24], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[24].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[24].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[24].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[23].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R1.w, R1.x, c[11].x, R1;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[23].z;
MOV_SAT R1.w, c[20].x;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R4.xyz, R3.y, R4;
LG2 R0.w, R2.w;
MUL R1.w, R1.y, R1;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R0.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MAD R4.xyz, R2, c[23].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
DP3_SAT R1.w, R2, R3;
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
MUL R1.xyz, R0, R0.w;
ADD R1.w, -R1, c[23].x;
MAD R1.xyz, R1, R1.w, R4;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[22].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[23].x;
END
# 109 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
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
def c23, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c24, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c25, 16.00000000, 0, 0, 0
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
add r1.xyz, -r3, c1
mad r1.xyz, r1, c15.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c23.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c23.y
mul r2.w, r2.y, c23.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c23, r2
mad r2.w, r2.z, c24.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c24.y, c24.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c24.y, c24.z
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
cmp r2.w, r3, c24.y, c24.z
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
add r3.w, r2.x, c24
texld r2, v1.zwzw, s5
cmp r3.w, r3, c24.z, c24.y
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
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c0
mad r2.xyz, r1, c25.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c17
add r2.w, -r0.y, c24.z
mul r0.y, r7, r0.x
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
mad r1.x, r0, r1.w, r0.y
mul r1.xyz, r3, r1.x
mad r1.xyz, r1, r2.w, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c22.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c24.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[25] = { program.local[0..22],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[24];
MAD R1.w, R2.x, c[24].z, R0;
MAD R2.w, R2.z, c[24].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[23], R0;
SLT R3.w, R2, c[5].x;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
MUL R0.w, R1, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[23].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[24], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[24].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[24].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[24].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[23].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R1.w, R1.x, c[11].x, R1;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[23].z;
MOV_SAT R1.w, c[20].x;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R4.xyz, R3.y, R4;
LG2 R0.w, R2.w;
MUL R1.w, R1.y, R1;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R0.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MAD R4.xyz, R2, c[23].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
DP3_SAT R1.w, R2, R3;
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
MUL R1.xyz, R0, R0.w;
ADD R1.w, -R1, c[23].x;
MAD R1.xyz, R1, R1.w, R4;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[22].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[23].x;
END
# 109 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
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
def c23, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c24, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c25, 16.00000000, 0, 0, 0
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
add r1.xyz, -r3, c1
mad r1.xyz, r1, c15.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c23.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c23.y
mul r2.w, r2.y, c23.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c23, r2
mad r2.w, r2.z, c24.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c24.y, c24.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c24.y, c24.z
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
cmp r2.w, r3, c24.y, c24.z
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
add r3.w, r2.x, c24
texld r2, v1.zwzw, s5
cmp r3.w, r3, c24.z, c24.y
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
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c0
mad r2.xyz, r1, c25.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c17
add r2.w, -r0.y, c24.z
mul r0.y, r7, r0.x
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
mad r1.x, r0, r1.w, r0.y
mul r1.xyz, r3, r1.x
mad r1.xyz, r1, r2.w, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c22.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c24.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[25] = { program.local[0..22],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[24];
MAD R1.w, R2.x, c[24].z, R0;
MAD R2.w, R2.z, c[24].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[23], R0;
SLT R3.w, R2, c[5].x;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
MUL R0.w, R1, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[23].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[24], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[24].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[24].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[24].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[23].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R1.w, R1.x, c[11].x, R1;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[23].z;
MOV_SAT R1.w, c[20].x;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TXP R2, fragment.texcoord[2], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R4.xyz, R3.y, R4;
LG2 R0.w, R2.w;
MUL R1.w, R1.y, R1;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[3];
MUL R5.xyz, R2, -R0.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MAD R4.xyz, R2, c[23].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
DP3_SAT R1.w, R2, R3;
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
MUL R1.xyz, R0, R0.w;
ADD R1.w, -R1, c[23].x;
MAD R1.xyz, R1, R1.w, R4;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[22].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[23].x;
END
# 109 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
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
def c23, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c24, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c25, 16.00000000, 0, 0, 0
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
add r1.xyz, -r3, c1
mad r1.xyz, r1, c15.x, r3
mul r4.xyz, r5.z, r1
log_pp r0.w, r0.w
add r1.x, -r5, -r5.y
add r1.x, -r5.z, r1
add r1.w, r1.x, c23.x
add r2.w, r2.x, r2.y
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, v3
add r2.w, r2.z, r2
mov_pp r0.w, -r0
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c23.y
mul r2.w, r2.y, c23.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c23, r2
mad r2.w, r2.z, c24.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c24.y, c24.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c24.y, c24.z
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
cmp r2.w, r3, c24.y, c24.z
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
add r3.w, r2.x, c24
texld r2, v1.zwzw, s5
cmp r3.w, r3, c24.z, c24.y
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
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c0
mad r2.xyz, r1, c25.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c17
add r2.w, -r0.y, c24.z
mul r0.y, r7, r0.x
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
mad r1.x, r0, r1.w, r0.y
mul r1.xyz, r3, r1.x
mad r1.xyz, r1, r2.w, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c22.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c24.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[25] = { program.local[0..22],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[24];
MAD R1.w, R2.x, c[24].z, R0;
MAD R2.w, R2.z, c[24].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[23], R0;
SLT R3.w, R2, c[5].x;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
MUL R0.w, R1, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[23].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[24], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[24].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[24].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[24].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[23].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R1.w, R1.x, c[11].x, R1;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[23].z;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MOV_SAT R0.w, c[20].x;
MUL R1.w, R1.y, R0;
MUL R5.xyz, R2, R2.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MUL R4.xyz, R3.y, R4;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MAD R4.xyz, R2, c[23].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
DP3_SAT R1.w, R2, R3;
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
MUL R1.xyz, R0, R0.w;
ADD R1.w, -R1, c[23].x;
MAD R1.xyz, R1, R1.w, R4;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[22].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[23].x;
END
# 105 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
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
def c23, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c24, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c25, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
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
add r1.w, r1.x, c23.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c23.y
mul r2.w, r2.y, c23.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c23, r2
mad r2.w, r2.z, c24.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c24.y, c24.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c24.y, c24.z
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
cmp r2.w, r3, c24.y, c24.z
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
add r3.w, r2.x, c24
texld r2, v1.zwzw, s5
cmp r3.w, r3, c24.z, c24.y
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
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c0
mad r2.xyz, r1, c25.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c17
add r2.w, -r0.y, c24.z
mul r0.y, r7, r0.x
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
mad r1.x, r0, r1.w, r0.y
mul r1.xyz, r3, r1.x
mad r1.xyz, r1, r2.w, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c22.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c24.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[25] = { program.local[0..22],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[24];
MAD R1.w, R2.x, c[24].z, R0;
MAD R2.w, R2.z, c[24].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[23], R0;
SLT R3.w, R2, c[5].x;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
MUL R0.w, R1, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[23].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[24], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[24].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[24].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[24].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[23].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R1.w, R1.x, c[11].x, R1;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[23].z;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MOV_SAT R0.w, c[20].x;
MUL R1.w, R1.y, R0;
MUL R5.xyz, R2, R2.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MUL R4.xyz, R3.y, R4;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MAD R4.xyz, R2, c[23].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
DP3_SAT R1.w, R2, R3;
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
MUL R1.xyz, R0, R0.w;
ADD R1.w, -R1, c[23].x;
MAD R1.xyz, R1, R1.w, R4;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[22].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[23].x;
END
# 105 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
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
def c23, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c24, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c25, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
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
add r1.w, r1.x, c23.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c23.y
mul r2.w, r2.y, c23.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c23, r2
mad r2.w, r2.z, c24.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c24.y, c24.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c24.y, c24.z
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
cmp r2.w, r3, c24.y, c24.z
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
add r3.w, r2.x, c24
texld r2, v1.zwzw, s5
cmp r3.w, r3, c24.z, c24.y
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
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c0
mad r2.xyz, r1, c25.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c17
add r2.w, -r0.y, c24.z
mul r0.y, r7, r0.x
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
mad r1.x, r0, r1.w, r0.y
mul r1.xyz, r3, r1.x
mad r1.xyz, r1, r2.w, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c22.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c24.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_PatternTex] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_DecalTex] 2D 5
SetTexture 6 [_RespawnTexture] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[25] = { program.local[0..22],
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
ADD R3.xyz, -R2, c[2];
MUL R0.w, R2.y, c[24];
MAD R1.w, R2.x, c[24].z, R0;
MAD R2.w, R2.z, c[24].y, R1;
ADD R0.w, R2.x, R2.y;
ADD R0.w, R0, R2.z;
SLT R1.w, c[23], R0;
SLT R3.w, R2, c[5].x;
ADD R1.xyz, -R0, c[1];
MAD R4.xyz, R3, c[6].x, R2;
MAD R3.xyz, R1, c[15].x, R0;
TEX R1.xyz, fragment.texcoord[0].zwzw, texture[2], 2D;
MUL R3.xyz, R1.z, R3;
MAD R4.xyz, R1.x, R4, R3;
MUL R0.w, R1, R3;
CMP R4.xyz, -R0.w, R4, R3;
MAD R5.xyz, R1.x, R2, R4;
MOV R0.w, c[23].x;
ABS R3.x, R3.w;
CMP R3.x, -R3, c[24], R0.w;
MUL R3.w, R1, R3.x;
CMP R4.xyz, -R3.w, R5, R4;
SLT R3.w, R2, c[7].x;
MUL R4.w, R1, R3;
ADD R3.xyz, -R2, c[3];
MAD R3.xyz, R3, c[8].x, R2;
MAD R3.xyz, R1.y, R3, R4;
CMP R3.xyz, -R4.w, R3, R4;
ABS R3.w, R3;
CMP R3.w, -R3, c[24].x, R0;
MAD R4.xyz, R1.y, R2, R3;
MUL R3.w, R1, R3;
CMP R4.xyz, -R3.w, R4, R3;
ADD R3.w, -R1.x, -R1.y;
ADD R3.xyz, -R2, c[4];
ADD R1.z, R3.w, -R1;
SLT R2.w, R2, c[9].x;
MUL R3.w, R1, R2;
ABS R2.w, R2;
CMP R2.w, -R2, c[24].x, R0;
MUL R2.w, R1, R2;
ABS R1.w, R1;
CMP R0.w, -R1, c[24].x, R0;
MUL R1.w, R1.y, c[12].x;
ADD R1.z, R1, c[23].x;
MAD R3.xyz, R3, c[10].x, R2;
MAD R3.xyz, R1.z, R3, R4;
CMP R3.xyz, -R3.w, R3, R4;
MAD R2.xyz, R1.z, R2, R3;
CMP R2.xyz, -R2.w, R2, R3;
MAD R3.xyz, R1.x, c[2], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.y, c[3], R2;
CMP R2.xyz, -R0.w, R3, R2;
MAD R3.xyz, R1.z, c[4], R2;
CMP R3.xyz, -R0.w, R3, R2;
TEX R2, fragment.texcoord[1].zwzw, texture[5], 2D;
MAD R1.w, R1.x, c[11].x, R1;
MAD_SAT R1.w, R1.z, c[13].x, R1;
SGE R0.w, R1, c[23].z;
MAD R2.xyz, R2, c[14], -R3;
MUL R0.w, R2, R0;
MAD R4.xyz, R0.w, R2, R3;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
TXP R2, fragment.texcoord[2], texture[0], 2D;
ADD R2.xyz, R2, fragment.texcoord[3];
MOV_SAT R0.w, c[20].x;
MUL R1.w, R1.y, R0;
MUL R5.xyz, R2, R2.w;
MOV_SAT R0.w, c[19].x;
MAD R1.w, R1.x, R0, R1;
MOV_SAT R0.w, c[21].x;
MAD R0.w, R1.z, R0, R1;
MUL R5.xyz, R3.z, R5;
MUL R5.xyz, R5, R0.w;
DP3 R1.w, fragment.texcoord[5], fragment.texcoord[5];
MUL R4.xyz, R3.y, R4;
MUL R0.w, R3.x, c[0];
MAD R3.xyz, R4, R2, R5;
MUL R2.xyz, R0.w, c[0];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MAD R4.xyz, R2, c[23].y, R3;
RSQ R0.w, R0.w;
RSQ R1.w, R1.w;
MUL R2.xyz, R0.w, fragment.texcoord[4];
MOV_SAT R0.w, c[17].x;
MUL R1.y, R1, R0.w;
MOV_SAT R0.w, c[16].x;
MAD R1.x, R1, R0.w, R1.y;
MUL R3.xyz, R1.w, fragment.texcoord[5];
DP3_SAT R1.w, R2, R3;
MOV_SAT R0.w, c[18].x;
MAD R0.w, R0, R1.z, R1.x;
MUL R1.xyz, R0, R0.w;
ADD R1.w, -R1, c[23].x;
MAD R1.xyz, R1, R1.w, R4;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[5].w;
TEX R0, R0, texture[6], 2D;
MUL R0.xyz, R0, c[22].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[23].x;
END
# 105 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
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
Float 22 [_RespawnStrength]
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
def c23, 1.00000000, 0.01000000, 0.60000002, 0.30000001
def c24, 0.10000000, 0.00000000, 1.00000000, -0.50000000
def c25, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5
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
add r1.w, r1.x, c23.x
add r2.w, r2.x, r2.y
add_pp r0.xyz, r0, v3
add r2.w, r2.z, r2
texld r1.xyz, v0, s1
mov r7.xy, r5
if_gt r2.w, c23.y
mul r2.w, r2.y, c23.z
add r5.xyz, -r2, c2
mad r5.xyz, r5, c6.x, r2
mad r2.w, r2.x, c23, r2
mad r2.w, r2.z, c24.x, r2
add r3.w, r2, -c5.x
cmp r3.w, r3, c24.y, c24.z
mad r5.xyz, r7.x, r5, r4
add r4.w, r2, -c5.x
cmp r4.xyz, r4.w, r4, r5
mad r5.xyz, r2, r7.x, r4
abs_pp r3.w, r3
cmp r4.xyz, -r3.w, r5, r4
add r6.xyz, -r2, c3
mad r5.xyz, r6, c8.x, r2
add r3.w, r2, -c7.x
cmp r3.w, r3, c24.y, c24.z
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
cmp r2.w, r3, c24.y, c24.z
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
add r3.w, r2.x, c24
texld r2, v1.zwzw, s5
cmp r3.w, r3, c24.z, c24.y
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
mad r0.xyz, r2, r0, r4
mul r1.xyz, r0.w, c0
mad r2.xyz, r1, c25.x, r0
dp3 r0.y, v5, v5
rsq r0.y, r0.y
dp3 r0.x, v4, v4
mul r1.xyz, r0.y, v5
rsq r0.x, r0.x
mul r0.xyz, r0.x, v4
dp3_sat r0.y, r0, r1
mov_sat r0.x, c17
add r2.w, -r0.y, c24.z
mul r0.y, r7, r0.x
mov_sat r0.x, c16
mad r0.y, r0.x, r7.x, r0
mov_sat r0.x, c18
mad r1.x, r0, r1.w, r0.y
mul r1.xyz, r3, r1.x
mad r1.xyz, r1, r2.w, r2
mov r0.y, v4.w
mov r0.x, v5.w
texld r0, r0, s6
mul r0.xyz, r0, c22.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c24.z
"
}
}
 }
}
Fallback "Diffuse"
}