емShader "Custom/BOL_Charactor_BRDF" {
Properties {
 _Color ("Main Color", Color) = (0.59,0.59,0.59,0)
 _IllumnColor ("Emissive Color (Mask R)", Color) = (0,0,0,0)
 _MetalColor ("Variant Color (Mask G)", Color) = (0.59,0.59,0.59,0)
 _SkinColor ("Variant Color (Mask B)", Color) = (0.59,0.59,0.59,0)
 _ReflectColor ("Reflect Color (Mask A)", Color) = (0.59,0.59,0.59,0)
 _MainTex ("Diffuse Map", 2D) = "white" {}
 _MaskTex ("Mask (RGB)", 2D) = "black" {}
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _Cube ("Reflection Cubemap", CUBE) = "" { TexGen CubeReflect }
 _Ramp ("BRDF map", 2D) = "black" {}
 _BRDF_PARA ("BRDF Para", Float) = 1
}
SubShader { 
 LOD 400
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Vector 9 [unity_Scale]
Vector 10 [_BumpMap_ST]
Vector 11 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[12] = { program.local[0],
		state.matrix.mvp,
		program.local[5..11] };
TEMP R0;
TEMP R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, R0, vertex.attrib[14].w;
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1].xyz, R0, c[9].w;
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2].xyz, R0, c[9].w;
DP3 R0.y, R1, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3].xyz, R0, c[9].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 22 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [unity_Scale]
Vector 9 [_BumpMap_ST]
Vector 10 [_MaskTex_ST]
"vs_2_0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, r0, v1.w
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT1.xyz, r0, c8.w
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT2.xyz, r0, c8.w
dp3 r0.y, r1, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT3.xyz, r0, c8.w
mad oT0.zw, v3.xyxy, c10.xyxy, c10
mad oT0.xy, v3, c9, c9.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_MetalShininess]
Float 1 [_SkinShininess]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1.yw, fragment.texcoord[0], texture[1], 2D;
TEX R0.yz, fragment.texcoord[0].zwzw, texture[0], 2D;
MAD R2.xy, R1.wyzw, c[2].y, -c[2].z;
MUL R1.xy, R2, R2;
ADD_SAT R0.x, R1, R1.y;
ADD R0.x, -R0, c[2].z;
RSQ R0.x, R0.x;
RCP R2.z, R0.x;
SGE R0.xy, R0.yzzw, c[2].x;
MUL R0.w, R0.y, c[1].x;
MOV R0.z, c[0].x;
MAD R0.y, -R0, c[1].x, R0.z;
DP3 R1.z, fragment.texcoord[3], R2;
DP3 R1.x, R2, fragment.texcoord[1];
DP3 R1.y, R2, fragment.texcoord[2];
MAD result.color.xyz, R1, c[2].x, c[2].x;
MAD result.color.w, R0.x, R0.y, R0;
END
# 17 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_MetalShininess]
Float 1 [_SkinShininess]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c2, -0.50000000, 1.00000000, 0.00000000, 0.50000000
def c3, 2.00000000, -1.00000000, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r1, t0, s1
mov r1.x, r1.w
mad_pp r1.xy, r1, c3.x, c3.y
mul_pp r2.xy, r1, r1
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s0
add_pp_sat r0.x, r2, r2.y
add_pp r0.x, -r0, c2.y
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
add r0.yz, r0, c2.x
cmp r0.yz, r0, c2.y, c2.z
dp3 r2.z, t3, r1
dp3 r2.y, r1, t2
dp3 r2.x, r1, t1
mov_pp r1.x, c0
mad_pp r2.xyz, r2, c2.w, c2.w
mul_pp r0.x, r0.z, c1
mad_pp r1.x, -r0.z, c1, r1
mad_pp r2.w, r0.y, r1.x, r0.x
mov_pp oC0, r2
"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "RenderType"="Opaque" }
  ZWrite Off
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
Vector 24 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[25] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..24] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[22].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[17];
DP4 R1.y, R0, c[16];
DP4 R1.x, R0, c[15];
DP4 R0.z, R4, c[20];
DP4 R0.x, R4, c[18];
DP4 R0.y, R4, c[19];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[21];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
ADD result.texcoord[5].xyz, R2, R3;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[22].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[22].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 R4.y, R1, c[7];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[14].x;
ADD result.texcoord[1].xy, R1, R1.z;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 R4.w, -R2, c[7];
DP3 R4.x, vertex.attrib[14], c[7];
DP3 R4.z, vertex.normal, c[7];
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MUL result.texcoord[4], R4, c[22].w;
MOV result.texcoord[7].xyz, R1.wxyw;
MOV result.texcoord[6].xyz, R0;
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
Vector 24 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c25, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c25.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c17
dp4 r1.y, r0, c16
dp4 r1.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c21
dp4 r0.z, r4, c20
dp4 r0.y, r4, c19
dp4 r0.x, r4, c18
add r2.xyz, r1, r0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c25.y
add o6.xyz, r2, r3
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp3 r4.y, r1, c6
mul r1.xyz, r0.xyww, c25.x
mov o0, r0
mul r1.y, r1, c13.x
mad o2.xy, r1.z, c14.zwzw, r1
mov o2.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 r4.w, -r2, c6
dp3 r4.x, v1, c6
dp3 r4.z, v2, c6
mov r1.y, r3.w
mov r1.x, r2.w
mul o5, r4, c22.w
mov o8.xyz, r1.wxyw
mov o7.xyz, r0
add o9.xyz, -r0, c12
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
Vector 24 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[25] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..24] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[22].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[17];
DP4 R1.y, R0, c[16];
DP4 R1.x, R0, c[15];
DP4 R0.z, R4, c[20];
DP4 R0.x, R4, c[18];
DP4 R0.y, R4, c[19];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[21];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
ADD result.texcoord[5].xyz, R2, R3;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[22].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[22].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 R4.y, R1, c[7];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[14].x;
ADD result.texcoord[1].xy, R1, R1.z;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 R4.w, -R2, c[7];
DP3 R4.x, vertex.attrib[14], c[7];
DP3 R4.z, vertex.normal, c[7];
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MUL result.texcoord[4], R4, c[22].w;
MOV result.texcoord[7].xyz, R1.wxyw;
MOV result.texcoord[6].xyz, R0;
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
Vector 24 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c25, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c25.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c17
dp4 r1.y, r0, c16
dp4 r1.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c21
dp4 r0.z, r4, c20
dp4 r0.y, r4, c19
dp4 r0.x, r4, c18
add r2.xyz, r1, r0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c25.y
add o6.xyz, r2, r3
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp3 r4.y, r1, c6
mul r1.xyz, r0.xyww, c25.x
mov o0, r0
mul r1.y, r1, c13.x
mad o2.xy, r1.z, c14.zwzw, r1
mov o2.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 r4.w, -r2, c6
dp3 r4.x, v1, c6
dp3 r4.z, v2, c6
mov r1.y, r3.w
mov r1.x, r2.w
mul o5, r4, c22.w
mov o8.xyz, r1.wxyw
mov o7.xyz, r0
add o9.xyz, -r0, c12
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
Vector 24 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[25] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..24] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[22].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[17];
DP4 R1.y, R0, c[16];
DP4 R1.x, R0, c[15];
DP4 R0.z, R4, c[20];
DP4 R0.x, R4, c[18];
DP4 R0.y, R4, c[19];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[21];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
ADD result.texcoord[5].xyz, R2, R3;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[22].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[22].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 R4.y, R1, c[7];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[14].x;
ADD result.texcoord[1].xy, R1, R1.z;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 R4.w, -R2, c[7];
DP3 R4.x, vertex.attrib[14], c[7];
DP3 R4.z, vertex.normal, c[7];
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MUL result.texcoord[4], R4, c[22].w;
MOV result.texcoord[7].xyz, R1.wxyw;
MOV result.texcoord[6].xyz, R0;
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
Vector 24 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c25, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c25.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c17
dp4 r1.y, r0, c16
dp4 r1.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c21
dp4 r0.z, r4, c20
dp4 r0.y, r4, c19
dp4 r0.x, r4, c18
add r2.xyz, r1, r0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c25.y
add o6.xyz, r2, r3
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp3 r4.y, r1, c6
mul r1.xyz, r0.xyww, c25.x
mov o0, r0
mul r1.y, r1, c13.x
mad o2.xy, r1.z, c14.zwzw, r1
mov o2.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 r4.w, -r2, c6
dp3 r4.x, v1, c6
dp3 r4.z, v2, c6
mov r1.y, r3.w
mov r1.x, r2.w
mul o5, r4, c22.w
mov o8.xyz, r1.wxyw
mov o7.xyz, r0
add o9.xyz, -r0, c12
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
Vector 24 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[25] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..24] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[22].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[17];
DP4 R1.y, R0, c[16];
DP4 R1.x, R0, c[15];
DP4 R0.z, R4, c[20];
DP4 R0.x, R4, c[18];
DP4 R0.y, R4, c[19];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[21];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
ADD result.texcoord[5].xyz, R2, R3;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[22].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[22].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 R4.y, R1, c[7];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[14].x;
ADD result.texcoord[1].xy, R1, R1.z;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 R4.w, -R2, c[7];
DP3 R4.x, vertex.attrib[14], c[7];
DP3 R4.z, vertex.normal, c[7];
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MUL result.texcoord[4], R4, c[22].w;
MOV result.texcoord[7].xyz, R1.wxyw;
MOV result.texcoord[6].xyz, R0;
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
Vector 24 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c25, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c25.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c17
dp4 r1.y, r0, c16
dp4 r1.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c21
dp4 r0.z, r4, c20
dp4 r0.y, r4, c19
dp4 r0.x, r4, c18
add r2.xyz, r1, r0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c25.y
add o6.xyz, r2, r3
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp3 r4.y, r1, c6
mul r1.xyz, r0.xyww, c25.x
mov o0, r0
mul r1.y, r1, c13.x
mad o2.xy, r1.z, c14.zwzw, r1
mov o2.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 r4.w, -r2, c6
dp3 r4.x, v1, c6
dp3 r4.z, v2, c6
mov r1.y, r3.w
mov r1.x, r2.w
mul o5, r4, c22.w
mov o8.xyz, r1.wxyw
mov o7.xyz, r0
add o9.xyz, -r0, c12
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
Vector 24 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[25] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..24] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[22].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[17];
DP4 R1.y, R0, c[16];
DP4 R1.x, R0, c[15];
DP4 R0.z, R4, c[20];
DP4 R0.x, R4, c[18];
DP4 R0.y, R4, c[19];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[21];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
ADD result.texcoord[5].xyz, R2, R3;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[22].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[22].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 R4.y, R1, c[7];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[14].x;
ADD result.texcoord[1].xy, R1, R1.z;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 R4.w, -R2, c[7];
DP3 R4.x, vertex.attrib[14], c[7];
DP3 R4.z, vertex.normal, c[7];
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MUL result.texcoord[4], R4, c[22].w;
MOV result.texcoord[7].xyz, R1.wxyw;
MOV result.texcoord[6].xyz, R0;
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
Vector 24 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c25, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c25.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c17
dp4 r1.y, r0, c16
dp4 r1.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c21
dp4 r0.z, r4, c20
dp4 r0.y, r4, c19
dp4 r0.x, r4, c18
add r2.xyz, r1, r0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c25.y
add o6.xyz, r2, r3
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp3 r4.y, r1, c6
mul r1.xyz, r0.xyww, c25.x
mov o0, r0
mul r1.y, r1, c13.x
mad o2.xy, r1.z, c14.zwzw, r1
mov o2.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 r4.w, -r2, c6
dp3 r4.x, v1, c6
dp3 r4.z, v2, c6
mov r1.y, r3.w
mov r1.x, r2.w
mul o5, r4, c22.w
mov o8.xyz, r1.wxyw
mov o7.xyz, r0
add o9.xyz, -r0, c12
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
Vector 24 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[25] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..24] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[22].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[17];
DP4 R1.y, R0, c[16];
DP4 R1.x, R0, c[15];
DP4 R0.z, R4, c[20];
DP4 R0.x, R4, c[18];
DP4 R0.y, R4, c[19];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[21];
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
ADD result.texcoord[5].xyz, R2, R3;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[22].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[22].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 R4.y, R1, c[7];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[14].x;
ADD result.texcoord[1].xy, R1, R1.z;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 R4.w, -R2, c[7];
DP3 R4.x, vertex.attrib[14], c[7];
DP3 R4.z, vertex.normal, c[7];
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MUL result.texcoord[4], R4, c[22].w;
MOV result.texcoord[7].xyz, R1.wxyw;
MOV result.texcoord[6].xyz, R0;
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
Vector 24 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c25, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c25.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c17
dp4 r1.y, r0, c16
dp4 r1.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c21
dp4 r0.z, r4, c20
dp4 r0.y, r4, c19
dp4 r0.x, r4, c18
add r2.xyz, r1, r0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c25.y
add o6.xyz, r2, r3
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
dp3 r4.y, r1, c6
mul r1.xyz, r0.xyww, c25.x
mov o0, r0
mul r1.y, r1, c13.x
mad o2.xy, r1.z, c14.zwzw, r1
mov o2.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 r4.w, -r2, c6
dp3 r4.x, v1, c6
dp3 r4.z, v2, c6
mov r1.y, r3.w
mov r1.x, r2.w
mul o5, r4, c22.w
mov o8.xyz, r1.wxyw
mov o7.xyz, r0
add o9.xyz, -r0, c12
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[18];
DP4 R1.y, R0, c[17];
DP4 R1.x, R0, c[16];
DP4 R0.z, R4, c[21];
DP4 R0.x, R4, c[19];
DP4 R0.y, R4, c[20];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[22];
ADD result.texcoord[5].xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[14];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[23].w, -vertex.position;
DP3 R0.w, -R2, c[5];
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[23].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R1, c[7];
DP4 R2.x, vertex.position, c[5];
DP4 R2.y, vertex.position, c[6];
DP4 R2.z, vertex.position, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[23].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[15].x;
ADD result.texcoord[1].xy, R1, R1.z;
MAD R4.xy, R2, c[26], c[26].zwzw;
MOV R3.x, c[27];
MOV R3.y, c[28].x;
MAD R3.xy, R3, c[13].y, R4;
MOV R1.z, R3.x;
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MOV result.texcoord[7], R1.wxyz;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.color.w, R3.y;
MOV result.texcoord[6].xyz, R2;
ADD result.color.xyz, -R2, c[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 70 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c23.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c29.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c18
dp4 r1.y, r0, c17
dp4 r1.x, r0, c16
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c22
mov r0.w, c29.y
dp4 r0.z, r4, c21
dp4 r0.y, r4, c20
dp4 r0.x, r4, c19
add r2.xyz, r1, r0
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c13
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c23.w, -v0
dp3 r0.w, -r2, c4
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c23.w
dp3 r0.w, -r2, c5
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c23.w
dp3 r0.w, -r2, c6
dp3 r0.y, r1, c6
dp4 r2.x, v0, c4
dp4 r2.y, v0, c5
dp4 r2.z, v0, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c23.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c29.x
mul r1.y, r1, c14.x
mad o2.xy, r1.z, c15.zwzw, r1
mad r4.xy, r2, c26, c26.zwzw
mov r3.x, c27
mov r3.y, c28.x
mad r3.xy, r3, c12.y, r4
mov r1.z, r3.x
mov r1.y, r3.w
mov r1.x, r2.w
mov o8, r1.wxyz
mov o0, r0
mov o2.zw, r0
mov o9.w, r3.y
mov o7.xyz, r2
add o9.xyz, -r2, c13
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[18];
DP4 R1.y, R0, c[17];
DP4 R1.x, R0, c[16];
DP4 R0.z, R4, c[21];
DP4 R0.x, R4, c[19];
DP4 R0.y, R4, c[20];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[22];
ADD result.texcoord[5].xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[14];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[23].w, -vertex.position;
DP3 R0.w, -R2, c[5];
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[23].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R1, c[7];
DP4 R2.x, vertex.position, c[5];
DP4 R2.y, vertex.position, c[6];
DP4 R2.z, vertex.position, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[23].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[15].x;
ADD result.texcoord[1].xy, R1, R1.z;
MAD R4.xy, R2, c[26], c[26].zwzw;
MOV R3.x, c[27];
MOV R3.y, c[28].x;
MAD R3.xy, R3, c[13].y, R4;
MOV R1.z, R3.x;
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MOV result.texcoord[7], R1.wxyz;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.color.w, R3.y;
MOV result.texcoord[6].xyz, R2;
ADD result.color.xyz, -R2, c[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 70 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c23.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c29.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c18
dp4 r1.y, r0, c17
dp4 r1.x, r0, c16
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c22
mov r0.w, c29.y
dp4 r0.z, r4, c21
dp4 r0.y, r4, c20
dp4 r0.x, r4, c19
add r2.xyz, r1, r0
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c13
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c23.w, -v0
dp3 r0.w, -r2, c4
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c23.w
dp3 r0.w, -r2, c5
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c23.w
dp3 r0.w, -r2, c6
dp3 r0.y, r1, c6
dp4 r2.x, v0, c4
dp4 r2.y, v0, c5
dp4 r2.z, v0, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c23.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c29.x
mul r1.y, r1, c14.x
mad o2.xy, r1.z, c15.zwzw, r1
mad r4.xy, r2, c26, c26.zwzw
mov r3.x, c27
mov r3.y, c28.x
mad r3.xy, r3, c12.y, r4
mov r1.z, r3.x
mov r1.y, r3.w
mov r1.x, r2.w
mov o8, r1.wxyz
mov o0, r0
mov o2.zw, r0
mov o9.w, r3.y
mov o7.xyz, r2
add o9.xyz, -r2, c13
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[18];
DP4 R1.y, R0, c[17];
DP4 R1.x, R0, c[16];
DP4 R0.z, R4, c[21];
DP4 R0.x, R4, c[19];
DP4 R0.y, R4, c[20];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[22];
ADD result.texcoord[5].xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[14];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[23].w, -vertex.position;
DP3 R0.w, -R2, c[5];
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[23].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R1, c[7];
DP4 R2.x, vertex.position, c[5];
DP4 R2.y, vertex.position, c[6];
DP4 R2.z, vertex.position, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[23].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[15].x;
ADD result.texcoord[1].xy, R1, R1.z;
MAD R4.xy, R2, c[26], c[26].zwzw;
MOV R3.x, c[27];
MOV R3.y, c[28].x;
MAD R3.xy, R3, c[13].y, R4;
MOV R1.z, R3.x;
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MOV result.texcoord[7], R1.wxyz;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.color.w, R3.y;
MOV result.texcoord[6].xyz, R2;
ADD result.color.xyz, -R2, c[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 70 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c23.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c29.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c18
dp4 r1.y, r0, c17
dp4 r1.x, r0, c16
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c22
mov r0.w, c29.y
dp4 r0.z, r4, c21
dp4 r0.y, r4, c20
dp4 r0.x, r4, c19
add r2.xyz, r1, r0
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c13
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c23.w, -v0
dp3 r0.w, -r2, c4
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c23.w
dp3 r0.w, -r2, c5
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c23.w
dp3 r0.w, -r2, c6
dp3 r0.y, r1, c6
dp4 r2.x, v0, c4
dp4 r2.y, v0, c5
dp4 r2.z, v0, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c23.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c29.x
mul r1.y, r1, c14.x
mad o2.xy, r1.z, c15.zwzw, r1
mad r4.xy, r2, c26, c26.zwzw
mov r3.x, c27
mov r3.y, c28.x
mad r3.xy, r3, c12.y, r4
mov r1.z, r3.x
mov r1.y, r3.w
mov r1.x, r2.w
mov o8, r1.wxyz
mov o0, r0
mov o2.zw, r0
mov o9.w, r3.y
mov o7.xyz, r2
add o9.xyz, -r2, c13
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[18];
DP4 R1.y, R0, c[17];
DP4 R1.x, R0, c[16];
DP4 R0.z, R4, c[21];
DP4 R0.x, R4, c[19];
DP4 R0.y, R4, c[20];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[22];
ADD result.texcoord[5].xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[14];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[23].w, -vertex.position;
DP3 R0.w, -R2, c[5];
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[23].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R1, c[7];
DP4 R2.x, vertex.position, c[5];
DP4 R2.y, vertex.position, c[6];
DP4 R2.z, vertex.position, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[23].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[15].x;
ADD result.texcoord[1].xy, R1, R1.z;
MAD R4.xy, R2, c[26], c[26].zwzw;
MOV R3.x, c[27];
MOV R3.y, c[28].x;
MAD R3.xy, R3, c[13].y, R4;
MOV R1.z, R3.x;
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MOV result.texcoord[7], R1.wxyz;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.color.w, R3.y;
MOV result.texcoord[6].xyz, R2;
ADD result.color.xyz, -R2, c[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 70 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c23.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c29.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c18
dp4 r1.y, r0, c17
dp4 r1.x, r0, c16
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c22
mov r0.w, c29.y
dp4 r0.z, r4, c21
dp4 r0.y, r4, c20
dp4 r0.x, r4, c19
add r2.xyz, r1, r0
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c13
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c23.w, -v0
dp3 r0.w, -r2, c4
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c23.w
dp3 r0.w, -r2, c5
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c23.w
dp3 r0.w, -r2, c6
dp3 r0.y, r1, c6
dp4 r2.x, v0, c4
dp4 r2.y, v0, c5
dp4 r2.z, v0, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c23.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c29.x
mul r1.y, r1, c14.x
mad o2.xy, r1.z, c15.zwzw, r1
mad r4.xy, r2, c26, c26.zwzw
mov r3.x, c27
mov r3.y, c28.x
mad r3.xy, r3, c12.y, r4
mov r1.z, r3.x
mov r1.y, r3.w
mov r1.x, r2.w
mov o8, r1.wxyz
mov o0, r0
mov o2.zw, r0
mov o9.w, r3.y
mov o7.xyz, r2
add o9.xyz, -r2, c13
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[18];
DP4 R1.y, R0, c[17];
DP4 R1.x, R0, c[16];
DP4 R0.z, R4, c[21];
DP4 R0.x, R4, c[19];
DP4 R0.y, R4, c[20];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[22];
ADD result.texcoord[5].xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[14];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[23].w, -vertex.position;
DP3 R0.w, -R2, c[5];
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[23].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R1, c[7];
DP4 R2.x, vertex.position, c[5];
DP4 R2.y, vertex.position, c[6];
DP4 R2.z, vertex.position, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[23].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[15].x;
ADD result.texcoord[1].xy, R1, R1.z;
MAD R4.xy, R2, c[26], c[26].zwzw;
MOV R3.x, c[27];
MOV R3.y, c[28].x;
MAD R3.xy, R3, c[13].y, R4;
MOV R1.z, R3.x;
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MOV result.texcoord[7], R1.wxyz;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.color.w, R3.y;
MOV result.texcoord[6].xyz, R2;
ADD result.color.xyz, -R2, c[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 70 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c23.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c29.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c18
dp4 r1.y, r0, c17
dp4 r1.x, r0, c16
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c22
mov r0.w, c29.y
dp4 r0.z, r4, c21
dp4 r0.y, r4, c20
dp4 r0.x, r4, c19
add r2.xyz, r1, r0
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c13
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c23.w, -v0
dp3 r0.w, -r2, c4
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c23.w
dp3 r0.w, -r2, c5
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c23.w
dp3 r0.w, -r2, c6
dp3 r0.y, r1, c6
dp4 r2.x, v0, c4
dp4 r2.y, v0, c5
dp4 r2.z, v0, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c23.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c29.x
mul r1.y, r1, c14.x
mad o2.xy, r1.z, c15.zwzw, r1
mad r4.xy, r2, c26, c26.zwzw
mov r3.x, c27
mov r3.y, c28.x
mad r3.xy, r3, c12.y, r4
mov r1.z, r3.x
mov r1.y, r3.w
mov r1.x, r2.w
mov o8, r1.wxyz
mov o0, r0
mov o2.zw, r0
mov o9.w, r3.y
mov o7.xyz, r2
add o9.xyz, -r2, c13
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R1.w, R1, c[5];
DP3 R2.w, R1, c[6];
DP3 R3.w, R1, c[7];
MOV R0.x, R1.w;
MOV R0.y, R2.w;
MOV R0.z, R3.w;
MOV R0.w, c[0].y;
MUL R4, R0.xyzz, R0.yzzx;
DP4 R1.z, R0, c[18];
DP4 R1.y, R0, c[17];
DP4 R1.x, R0, c[16];
DP4 R0.z, R4, c[21];
DP4 R0.x, R4, c[19];
DP4 R0.y, R4, c[20];
ADD R2.xyz, R1, R0;
MUL R0.x, R2.w, R2.w;
MAD R0.w, R1, R1, -R0.x;
MUL R3.xyz, R0.w, c[22];
ADD result.texcoord[5].xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R0;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[14];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[23].w, -vertex.position;
DP3 R0.w, -R2, c[5];
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.w, -R2, c[6];
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[23].w;
DP3 R0.w, -R2, c[7];
DP3 R0.y, R1, c[7];
DP4 R2.x, vertex.position, c[5];
DP4 R2.y, vertex.position, c[6];
DP4 R2.z, vertex.position, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[23].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[15].x;
ADD result.texcoord[1].xy, R1, R1.z;
MAD R4.xy, R2, c[26], c[26].zwzw;
MOV R3.x, c[27];
MOV R3.y, c[28].x;
MAD R3.xy, R3, c[13].y, R4;
MOV R1.z, R3.x;
MOV R1.y, R3.w;
MOV R1.x, R2.w;
MOV result.texcoord[7], R1.wxyz;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.color.w, R3.y;
MOV result.texcoord[6].xyz, R2;
ADD result.color.xyz, -R2, c[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 70 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [_ScreenParams]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_RespawnTexture_ST]
Float 27 [_RespawnSpeedU]
Float 28 [_RespawnSpeedV]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
dcl_color0 o9
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c23.w
dp3 r1.w, r1, c4
dp3 r2.w, r1, c5
dp3 r3.w, r1, c6
mov r0.x, r1.w
mov r0.y, r2.w
mov r0.z, r3.w
mov r0.w, c29.y
mul r4, r0.xyzz, r0.yzzx
dp4 r1.z, r0, c18
dp4 r1.y, r0, c17
dp4 r1.x, r0, c16
mul r0.w, r2, r2
mad r0.w, r1, r1, -r0
mul r3.xyz, r0.w, c22
mov r0.w, c29.y
dp4 r0.z, r4, c21
dp4 r0.y, r4, c20
dp4 r0.x, r4, c19
add r2.xyz, r1, r0
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c13
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c23.w, -v0
dp3 r0.w, -r2, c4
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c23.w
dp3 r0.w, -r2, c5
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c23.w
dp3 r0.w, -r2, c6
dp3 r0.y, r1, c6
dp4 r2.x, v0, c4
dp4 r2.y, v0, c5
dp4 r2.z, v0, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c23.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c29.x
mul r1.y, r1, c14.x
mad o2.xy, r1.z, c15.zwzw, r1
mad r4.xy, r2, c26, c26.zwzw
mov r3.x, c27
mov r3.y, c28.x
mad r3.xy, r3, c12.y, r4
mov r1.z, r3.x
mov r1.y, r3.w
mov r1.x, r2.w
mov o8, r1.wxyz
mov o0, r0
mov o2.zw, r0
mov o9.w, r3.y
mov o7.xyz, r2
add o9.xyz, -r2, c13
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[0], texture[2], 2D;
MOV R0.xyz, c[0];
ADD R2.xyz, -R0, c[3];
MAD R2.xyz, R1.z, R2, c[0];
ADD R3.xyz, -R2, c[2];
MAD R2.xyz, R1.y, R3, R2;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MUL R2.w, R1, c[4].x;
MUL R2.xyz, R3, R2;
DP3 R1.y, fragment.texcoord[2], R0;
DP3 R1.z, R0, fragment.texcoord[3];
DP3 R1.w, R0, fragment.texcoord[4];
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R3.xyz, R2, R2.w;
LG2 R0.w, R0.w;
MUL R3.xyz, R3, -R0.w;
MUL R0.w, R1.x, c[1];
MOV R4.x, fragment.texcoord[2].w;
MOV R4.z, fragment.texcoord[4].w;
MOV R4.y, fragment.texcoord[3].w;
DP3 R3.w, R1.yzww, R4;
MUL R1.yzw, R1, R3.w;
MAD R4.xyz, -R1.yzww, c[7].z, R4;
TEX R4.xyz, R4, texture[4], CUBE;
MUL R1.xyz, R2.w, R4;
MUL R4.xyz, R0.w, c[1];
DP3 R0.w, fragment.texcoord[7], fragment.texcoord[7];
MAD R1.xyz, R4, c[7].y, R1;
RSQ R0.w, R0.w;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R0.xyz, -R0, fragment.texcoord[5];
MAD R0.xyz, R2, R0, R3;
ADD R0.xyz, R0, R1;
MUL R2.xyz, R0.w, fragment.texcoord[7];
DP3 R1.x, fragment.color.primary, fragment.color.primary;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.color.primary;
DP3_SAT R1.w, R1, R2;
RCP R0.w, c[6].x;
MUL R0.w, R1, R0;
MUL R1.xyz, R0.w, R0;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R0.w, c[5], R1;
ADD R0.w, R1, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
MOV result.color.w, c[7].x;
END
# 55 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6.xyz
dcl_color0 v7.xyz
mov_pp r0.xyz, c3
texld r2, v0, s2
add_pp r0.xyz, -c0, r0
mad_pp r3.xyz, r2.z, r0, c0
texld r0.yw, v0.zwzw, s3
mad_pp r1.xy, r0.wyzw, c7.x, c7.y
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r4.xyz, -r3, c2
mul r1.w, r2, c4.x
mad_pp r3.xyz, r2.y, r4, r3
texld r0.xyz, v0, s1
mul r3.xyz, r0, r3
add_pp r0.x, -r0.w, c7.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
texldp r0, v1, s0
dp3_pp r2.y, v2, r1
dp3_pp r2.z, r1, v3
dp3_pp r2.w, r1, v4
mul r4.xyz, r3, r1.w
log_pp r0.w, r0.w
mul r4.xyz, r4, -r0.w
mul r0.w, r2.x, c1
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r3.w, r2.yzww, r1
mul r2.yzw, r2, r3.w
mad r1.xyz, -r2.yzww, c7.x, r1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r0.xyz, -r0, v5
mad r3.xyz, r3, r0, r4
texld r0.xyz, r1, s4
mul r0.xyz, r1.w, r0
mul r1.xyz, r0.w, c1
mad r1.xyz, r1, c7.w, r0
dp3 r0.x, v7, v7
rsq r0.x, r0.x
dp3 r0.y, v6, v6
mul r2.xyz, r0.x, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v6
dp3_sat r0.w, r2, r0
rcp r1.w, c6.x
mul r1.w, r0, r1
add r0.xyz, r3, r1
mul r2.xyz, r0, r1.w
add r1.x, -r1.w, c7.z
mad r1.xyz, r1.x, c5, r2
add r0.w, r0, -c6.x
cmp_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c7.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[0], texture[2], 2D;
MOV R0.xyz, c[0];
ADD R2.xyz, -R0, c[3];
MAD R2.xyz, R1.z, R2, c[0];
ADD R3.xyz, -R2, c[2];
MAD R2.xyz, R1.y, R3, R2;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MUL R2.w, R1, c[4].x;
MUL R2.xyz, R3, R2;
DP3 R1.y, fragment.texcoord[2], R0;
DP3 R1.z, R0, fragment.texcoord[3];
DP3 R1.w, R0, fragment.texcoord[4];
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R3.xyz, R2, R2.w;
LG2 R0.w, R0.w;
MUL R3.xyz, R3, -R0.w;
MUL R0.w, R1.x, c[1];
MOV R4.x, fragment.texcoord[2].w;
MOV R4.z, fragment.texcoord[4].w;
MOV R4.y, fragment.texcoord[3].w;
DP3 R3.w, R1.yzww, R4;
MUL R1.yzw, R1, R3.w;
MAD R4.xyz, -R1.yzww, c[7].z, R4;
TEX R4.xyz, R4, texture[4], CUBE;
MUL R1.xyz, R2.w, R4;
MUL R4.xyz, R0.w, c[1];
DP3 R0.w, fragment.texcoord[7], fragment.texcoord[7];
MAD R1.xyz, R4, c[7].y, R1;
RSQ R0.w, R0.w;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R0.xyz, -R0, fragment.texcoord[5];
MAD R0.xyz, R2, R0, R3;
ADD R0.xyz, R0, R1;
MUL R2.xyz, R0.w, fragment.texcoord[7];
DP3 R1.x, fragment.color.primary, fragment.color.primary;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.color.primary;
DP3_SAT R1.w, R1, R2;
RCP R0.w, c[6].x;
MUL R0.w, R1, R0;
MUL R1.xyz, R0.w, R0;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R0.w, c[5], R1;
ADD R0.w, R1, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
MOV result.color.w, c[7].x;
END
# 55 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6.xyz
dcl_color0 v7.xyz
mov_pp r0.xyz, c3
texld r2, v0, s2
add_pp r0.xyz, -c0, r0
mad_pp r3.xyz, r2.z, r0, c0
texld r0.yw, v0.zwzw, s3
mad_pp r1.xy, r0.wyzw, c7.x, c7.y
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r4.xyz, -r3, c2
mul r1.w, r2, c4.x
mad_pp r3.xyz, r2.y, r4, r3
texld r0.xyz, v0, s1
mul r3.xyz, r0, r3
add_pp r0.x, -r0.w, c7.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
texldp r0, v1, s0
dp3_pp r2.y, v2, r1
dp3_pp r2.z, r1, v3
dp3_pp r2.w, r1, v4
mul r4.xyz, r3, r1.w
log_pp r0.w, r0.w
mul r4.xyz, r4, -r0.w
mul r0.w, r2.x, c1
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r3.w, r2.yzww, r1
mul r2.yzw, r2, r3.w
mad r1.xyz, -r2.yzww, c7.x, r1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r0.xyz, -r0, v5
mad r3.xyz, r3, r0, r4
texld r0.xyz, r1, s4
mul r0.xyz, r1.w, r0
mul r1.xyz, r0.w, c1
mad r1.xyz, r1, c7.w, r0
dp3 r0.x, v7, v7
rsq r0.x, r0.x
dp3 r0.y, v6, v6
mul r2.xyz, r0.x, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v6
dp3_sat r0.w, r2, r0
rcp r1.w, c6.x
mul r1.w, r0, r1
add r0.xyz, r3, r1
mul r2.xyz, r0, r1.w
add r1.x, -r1.w, c7.z
mad r1.xyz, r1.x, c5, r2
add r0.w, r0, -c6.x
cmp_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c7.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[0], texture[2], 2D;
MOV R0.xyz, c[0];
ADD R2.xyz, -R0, c[3];
MAD R2.xyz, R1.z, R2, c[0];
ADD R3.xyz, -R2, c[2];
MAD R2.xyz, R1.y, R3, R2;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MUL R2.w, R1, c[4].x;
MUL R2.xyz, R3, R2;
DP3 R1.y, fragment.texcoord[2], R0;
DP3 R1.z, R0, fragment.texcoord[3];
DP3 R1.w, R0, fragment.texcoord[4];
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R3.xyz, R2, R2.w;
LG2 R0.w, R0.w;
MUL R3.xyz, R3, -R0.w;
MUL R0.w, R1.x, c[1];
MOV R4.x, fragment.texcoord[2].w;
MOV R4.z, fragment.texcoord[4].w;
MOV R4.y, fragment.texcoord[3].w;
DP3 R3.w, R1.yzww, R4;
MUL R1.yzw, R1, R3.w;
MAD R4.xyz, -R1.yzww, c[7].z, R4;
TEX R4.xyz, R4, texture[4], CUBE;
MUL R1.xyz, R2.w, R4;
MUL R4.xyz, R0.w, c[1];
DP3 R0.w, fragment.texcoord[7], fragment.texcoord[7];
MAD R1.xyz, R4, c[7].y, R1;
RSQ R0.w, R0.w;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R0.xyz, -R0, fragment.texcoord[5];
MAD R0.xyz, R2, R0, R3;
ADD R0.xyz, R0, R1;
MUL R2.xyz, R0.w, fragment.texcoord[7];
DP3 R1.x, fragment.color.primary, fragment.color.primary;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.color.primary;
DP3_SAT R1.w, R1, R2;
RCP R0.w, c[6].x;
MUL R0.w, R1, R0;
MUL R1.xyz, R0.w, R0;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R0.w, c[5], R1;
ADD R0.w, R1, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
MOV result.color.w, c[7].x;
END
# 55 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6.xyz
dcl_color0 v7.xyz
mov_pp r0.xyz, c3
texld r2, v0, s2
add_pp r0.xyz, -c0, r0
mad_pp r3.xyz, r2.z, r0, c0
texld r0.yw, v0.zwzw, s3
mad_pp r1.xy, r0.wyzw, c7.x, c7.y
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r4.xyz, -r3, c2
mul r1.w, r2, c4.x
mad_pp r3.xyz, r2.y, r4, r3
texld r0.xyz, v0, s1
mul r3.xyz, r0, r3
add_pp r0.x, -r0.w, c7.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
texldp r0, v1, s0
dp3_pp r2.y, v2, r1
dp3_pp r2.z, r1, v3
dp3_pp r2.w, r1, v4
mul r4.xyz, r3, r1.w
log_pp r0.w, r0.w
mul r4.xyz, r4, -r0.w
mul r0.w, r2.x, c1
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r3.w, r2.yzww, r1
mul r2.yzw, r2, r3.w
mad r1.xyz, -r2.yzww, c7.x, r1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r0.xyz, -r0, v5
mad r3.xyz, r3, r0, r4
texld r0.xyz, r1, s4
mul r0.xyz, r1.w, r0
mul r1.xyz, r0.w, c1
mad r1.xyz, r1, c7.w, r0
dp3 r0.x, v7, v7
rsq r0.x, r0.x
dp3 r0.y, v6, v6
mul r2.xyz, r0.x, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v6
dp3_sat r0.w, r2, r0
rcp r1.w, c6.x
mul r1.w, r0, r1
add r0.xyz, r3, r1
mul r2.xyz, r0, r1.w
add r1.x, -r1.w, c7.z
mad r1.xyz, r1.x, c5, r2
add r0.w, r0, -c6.x
cmp_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c7.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4, fragment.texcoord[0], texture[2], 2D;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
MOV R1.xyz, c[0];
ADD R1.xyz, -R1, c[3];
MAD R1.xyz, R4.z, R1, c[0];
ADD R2.xyz, -R1, c[2];
MAD R2.xyz, R4.y, R2, R1;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
TEX R1.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R1.xyz, R1, R2;
RCP R0.z, R0.z;
DP3 R2.x, fragment.texcoord[2], R0;
DP3 R2.y, R0, fragment.texcoord[3];
DP3 R2.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R2, R0;
MUL R3.xyz, R2, R0.w;
MAD R3.xyz, -R3, c[7].z, R0;
MUL R1.w, R4, c[4].x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R2.xyz, R1, R1.w;
MUL R2.xyz, R0.w, R2;
ADD R0.xyz, R0, fragment.texcoord[5];
MAD R0.xyz, R1, R0, R2;
MUL R0.w, R4.x, c[1];
TEX R3.xyz, R3, texture[4], CUBE;
MUL R4.xyz, R1.w, R3;
MUL R3.xyz, R0.w, c[1];
MAD R3.xyz, R3, c[7].y, R4;
ADD R2.xyz, R0, R3;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
DP3 R0.y, fragment.texcoord[7], fragment.texcoord[7];
MUL R1.xyz, R0.x, fragment.color.primary;
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, fragment.texcoord[7];
DP3_SAT R0.w, R1, R0;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R0.xyz, R1.x, R2;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R0;
ADD R0.x, R0.w, -c[6];
CMP result.color.xyz, R0.x, R1, R2;
MOV result.color.w, c[7].x;
END
# 51 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6.xyz
dcl_color0 v7.xyz
texld r0, v0, s2
texld r1.yw, v0.zwzw, s3
mad_pp r1.xy, r1.wyzw, c7.x, c7.y
mov_pp r2.xyz, c3
add_pp r2.xyz, -c0, r2
mad_pp r3.xyz, r0.z, r2, c0
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp r2.xyz, -r3, c2
mad_pp r2.xyz, r0.y, r2, r3
add_pp_sat r0.z, r1, r1.w
texld r3.xyz, v0, s1
mul r2.xyz, r3, r2
mul r2.w, r0, c4.x
add_pp r0.y, -r0.z, c7.z
rsq_pp r0.y, r0.y
rcp_pp r1.z, r0.y
dp3_pp r0.y, v2, r1
dp3_pp r0.z, r1, v3
dp3_pp r0.w, r1, v4
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r1.x, r0.yzww, r3
mul r0.yzw, r0, r1.x
mad r3.xyz, -r0.yzww, c7.x, r3
texldp r1, v1, s0
mul r4.xyz, r2, r2.w
mul r0.w, r0.x, c1
mul r4.xyz, r1.w, r4
add_pp r1.xyz, r1, v5
mad r1.xyz, r2, r1, r4
texld r2.xyz, r3, s4
mul r0.xyz, r2.w, r2
mul r2.xyz, r0.w, c1
mad r2.xyz, r2, c7.w, r0
dp3 r0.x, v6, v6
rsq r0.w, r0.x
mul r3.xyz, r0.w, v6
dp3 r0.y, v7, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v7
dp3_sat r1.w, r0, r3
rcp r0.w, c6.x
add r0.xyz, r1, r2
mul r0.w, r1, r0
mul r1.xyz, r0, r0.w
add r0.w, -r0, c7.z
mad r1.xyz, r0.w, c5, r1
add r0.w, r1, -c6.x
cmp_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c7.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4, fragment.texcoord[0], texture[2], 2D;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
MOV R1.xyz, c[0];
ADD R1.xyz, -R1, c[3];
MAD R1.xyz, R4.z, R1, c[0];
ADD R2.xyz, -R1, c[2];
MAD R2.xyz, R4.y, R2, R1;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
TEX R1.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R1.xyz, R1, R2;
RCP R0.z, R0.z;
DP3 R2.x, fragment.texcoord[2], R0;
DP3 R2.y, R0, fragment.texcoord[3];
DP3 R2.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R2, R0;
MUL R3.xyz, R2, R0.w;
MAD R3.xyz, -R3, c[7].z, R0;
MUL R1.w, R4, c[4].x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R2.xyz, R1, R1.w;
MUL R2.xyz, R0.w, R2;
ADD R0.xyz, R0, fragment.texcoord[5];
MAD R0.xyz, R1, R0, R2;
MUL R0.w, R4.x, c[1];
TEX R3.xyz, R3, texture[4], CUBE;
MUL R4.xyz, R1.w, R3;
MUL R3.xyz, R0.w, c[1];
MAD R3.xyz, R3, c[7].y, R4;
ADD R2.xyz, R0, R3;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
DP3 R0.y, fragment.texcoord[7], fragment.texcoord[7];
MUL R1.xyz, R0.x, fragment.color.primary;
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, fragment.texcoord[7];
DP3_SAT R0.w, R1, R0;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R0.xyz, R1.x, R2;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R0;
ADD R0.x, R0.w, -c[6];
CMP result.color.xyz, R0.x, R1, R2;
MOV result.color.w, c[7].x;
END
# 51 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6.xyz
dcl_color0 v7.xyz
texld r0, v0, s2
texld r1.yw, v0.zwzw, s3
mad_pp r1.xy, r1.wyzw, c7.x, c7.y
mov_pp r2.xyz, c3
add_pp r2.xyz, -c0, r2
mad_pp r3.xyz, r0.z, r2, c0
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp r2.xyz, -r3, c2
mad_pp r2.xyz, r0.y, r2, r3
add_pp_sat r0.z, r1, r1.w
texld r3.xyz, v0, s1
mul r2.xyz, r3, r2
mul r2.w, r0, c4.x
add_pp r0.y, -r0.z, c7.z
rsq_pp r0.y, r0.y
rcp_pp r1.z, r0.y
dp3_pp r0.y, v2, r1
dp3_pp r0.z, r1, v3
dp3_pp r0.w, r1, v4
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r1.x, r0.yzww, r3
mul r0.yzw, r0, r1.x
mad r3.xyz, -r0.yzww, c7.x, r3
texldp r1, v1, s0
mul r4.xyz, r2, r2.w
mul r0.w, r0.x, c1
mul r4.xyz, r1.w, r4
add_pp r1.xyz, r1, v5
mad r1.xyz, r2, r1, r4
texld r2.xyz, r3, s4
mul r0.xyz, r2.w, r2
mul r2.xyz, r0.w, c1
mad r2.xyz, r2, c7.w, r0
dp3 r0.x, v6, v6
rsq r0.w, r0.x
mul r3.xyz, r0.w, v6
dp3 r0.y, v7, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v7
dp3_sat r1.w, r0, r3
rcp r0.w, c6.x
add r0.xyz, r1, r2
mul r0.w, r1, r0
mul r1.xyz, r0, r0.w
add r0.w, -r0, c7.z
mad r1.xyz, r0.w, c5, r1
add r0.w, r1, -c6.x
cmp_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c7.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4, fragment.texcoord[0], texture[2], 2D;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
MOV R1.xyz, c[0];
ADD R1.xyz, -R1, c[3];
MAD R1.xyz, R4.z, R1, c[0];
ADD R2.xyz, -R1, c[2];
MAD R2.xyz, R4.y, R2, R1;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
TEX R1.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R1.xyz, R1, R2;
RCP R0.z, R0.z;
DP3 R2.x, fragment.texcoord[2], R0;
DP3 R2.y, R0, fragment.texcoord[3];
DP3 R2.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R2, R0;
MUL R3.xyz, R2, R0.w;
MAD R3.xyz, -R3, c[7].z, R0;
MUL R1.w, R4, c[4].x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R2.xyz, R1, R1.w;
MUL R2.xyz, R0.w, R2;
ADD R0.xyz, R0, fragment.texcoord[5];
MAD R0.xyz, R1, R0, R2;
MUL R0.w, R4.x, c[1];
TEX R3.xyz, R3, texture[4], CUBE;
MUL R4.xyz, R1.w, R3;
MUL R3.xyz, R0.w, c[1];
MAD R3.xyz, R3, c[7].y, R4;
ADD R2.xyz, R0, R3;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
DP3 R0.y, fragment.texcoord[7], fragment.texcoord[7];
MUL R1.xyz, R0.x, fragment.color.primary;
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, fragment.texcoord[7];
DP3_SAT R0.w, R1, R0;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R0.xyz, R1.x, R2;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R0;
ADD R0.x, R0.w, -c[6];
CMP result.color.xyz, R0.x, R1, R2;
MOV result.color.w, c[7].x;
END
# 51 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6.xyz
dcl_color0 v7.xyz
texld r0, v0, s2
texld r1.yw, v0.zwzw, s3
mad_pp r1.xy, r1.wyzw, c7.x, c7.y
mov_pp r2.xyz, c3
add_pp r2.xyz, -c0, r2
mad_pp r3.xyz, r0.z, r2, c0
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp r2.xyz, -r3, c2
mad_pp r2.xyz, r0.y, r2, r3
add_pp_sat r0.z, r1, r1.w
texld r3.xyz, v0, s1
mul r2.xyz, r3, r2
mul r2.w, r0, c4.x
add_pp r0.y, -r0.z, c7.z
rsq_pp r0.y, r0.y
rcp_pp r1.z, r0.y
dp3_pp r0.y, v2, r1
dp3_pp r0.z, r1, v3
dp3_pp r0.w, r1, v4
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r1.x, r0.yzww, r3
mul r0.yzw, r0, r1.x
mad r3.xyz, -r0.yzww, c7.x, r3
texldp r1, v1, s0
mul r4.xyz, r2, r2.w
mul r0.w, r0.x, c1
mul r4.xyz, r1.w, r4
add_pp r1.xyz, r1, v5
mad r1.xyz, r2, r1, r4
texld r2.xyz, r3, s4
mul r0.xyz, r2.w, r2
mul r2.xyz, r0.w, c1
mad r2.xyz, r2, c7.w, r0
dp3 r0.x, v6, v6
rsq r0.w, r0.x
mul r3.xyz, r0.w, v6
dp3 r0.y, v7, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v7
dp3_sat r1.w, r0, r3
rcp r0.w, c6.x
add r0.xyz, r1, r2
mul r0.w, r1, r0
mul r1.xyz, r0, r0.w
add r0.w, -r0, c7.z
mad r1.xyz, r0.w, c5, r1
add r0.w, r1, -c6.x
cmp_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c7.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[0], texture[2], 2D;
MOV R0.xyz, c[0];
ADD R2.xyz, -R0, c[3];
MAD R2.xyz, R1.z, R2, c[0];
ADD R3.xyz, -R2, c[2];
MAD R2.xyz, R1.y, R3, R2;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[8].z, -c[8].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
ADD R0.z, -R0, c[8].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MUL R2.w, R1, c[4].x;
MUL R2.xyz, R3, R2;
DP3 R1.y, fragment.texcoord[2], R0;
DP3 R1.z, R0, fragment.texcoord[3];
DP3 R1.w, R0, fragment.texcoord[4];
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R3.xyz, R2, R2.w;
LG2 R0.w, R0.w;
MUL R3.xyz, R3, -R0.w;
MUL R0.w, R1.x, c[1];
MOV R4.x, fragment.texcoord[2].w;
MOV R4.z, fragment.texcoord[4].w;
MOV R4.y, fragment.texcoord[3].w;
DP3 R3.w, R1.yzww, R4;
MUL R1.yzw, R1, R3.w;
MAD R4.xyz, -R1.yzww, c[8].z, R4;
TEX R4.xyz, R4, texture[4], CUBE;
MUL R1.xyz, R2.w, R4;
MUL R4.xyz, R0.w, c[1];
MAD R1.xyz, R4, c[8].y, R1;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R0.xyz, -R0, fragment.texcoord[5];
MAD R0.xyz, R2, R0, R3;
ADD R1.xyz, R0, R1;
DP3 R0.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.x;
MUL R2.xyz, R0.w, fragment.texcoord[7];
DP3 R0.y, fragment.color.primary, fragment.color.primary;
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, fragment.color.primary;
DP3_SAT R1.w, R0, R2;
RCP R0.w, c[6].x;
MUL R0.w, R1, R0;
MUL R0.xyz, R0.w, R1;
ADD R0.w, -R0, c[8].x;
MAD R2.xyz, R0.w, c[5], R0;
ADD R1.w, R1, -c[6].x;
CMP R1.xyz, R1.w, R2, R1;
MOV R0.y, fragment.color.primary.w;
MOV R0.x, fragment.texcoord[7].w;
TEX R0, R0, texture[5], 2D;
MUL R0.xyz, R0, c[7].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[8].x;
END
# 61 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c8, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
dcl_color0 v7
mov_pp r0.xyz, c3
texld r2, v0, s2
add_pp r0.xyz, -c0, r0
mad_pp r3.xyz, r2.z, r0, c0
texld r0.yw, v0.zwzw, s3
mad_pp r1.xy, r0.wyzw, c8.x, c8.y
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r4.xyz, -r3, c2
mul r1.w, r2, c4.x
mad_pp r3.xyz, r2.y, r4, r3
texld r0.xyz, v0, s1
mul r3.xyz, r0, r3
add_pp r0.x, -r0.w, c8.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
texldp r0, v1, s0
dp3_pp r2.y, v2, r1
dp3_pp r2.z, r1, v3
dp3_pp r2.w, r1, v4
mul r4.xyz, r3, r1.w
log_pp r0.w, r0.w
mul r4.xyz, r4, -r0.w
mul r0.w, r2.x, c1
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r3.w, r2.yzww, r1
mul r2.yzw, r2, r3.w
mad r1.xyz, -r2.yzww, c8.x, r1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r0.xyz, -r0, v5
mad r3.xyz, r3, r0, r4
texld r0.xyz, r1, s4
mul r1.xyz, r0.w, c1
mul r0.xyz, r1.w, r0
mad r1.xyz, r1, c8.w, r0
dp3 r0.x, v7, v7
rsq r0.x, r0.x
dp3 r0.y, v6, v6
mul r2.xyz, r0.x, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v6
dp3_sat r0.x, r2, r0
rcp r0.w, c6.x
mul r0.y, r0.x, r0.w
add r2.xyz, r3, r1
mul r1.xyz, r2, r0.y
add r0.y, -r0, c8.z
mad r1.xyz, r0.y, c5, r1
add r1.w, r0.x, -c6.x
cmp_pp r1.xyz, r1.w, r2, r1
mov r0.y, v7.w
mov r0.x, v6.w
texld r0, r0, s5
mul r0.xyz, r0, c7.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c8.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[0], texture[2], 2D;
MOV R0.xyz, c[0];
ADD R2.xyz, -R0, c[3];
MAD R2.xyz, R1.z, R2, c[0];
ADD R3.xyz, -R2, c[2];
MAD R2.xyz, R1.y, R3, R2;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[8].z, -c[8].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
ADD R0.z, -R0, c[8].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MUL R2.w, R1, c[4].x;
MUL R2.xyz, R3, R2;
DP3 R1.y, fragment.texcoord[2], R0;
DP3 R1.z, R0, fragment.texcoord[3];
DP3 R1.w, R0, fragment.texcoord[4];
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R3.xyz, R2, R2.w;
LG2 R0.w, R0.w;
MUL R3.xyz, R3, -R0.w;
MUL R0.w, R1.x, c[1];
MOV R4.x, fragment.texcoord[2].w;
MOV R4.z, fragment.texcoord[4].w;
MOV R4.y, fragment.texcoord[3].w;
DP3 R3.w, R1.yzww, R4;
MUL R1.yzw, R1, R3.w;
MAD R4.xyz, -R1.yzww, c[8].z, R4;
TEX R4.xyz, R4, texture[4], CUBE;
MUL R1.xyz, R2.w, R4;
MUL R4.xyz, R0.w, c[1];
MAD R1.xyz, R4, c[8].y, R1;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R0.xyz, -R0, fragment.texcoord[5];
MAD R0.xyz, R2, R0, R3;
ADD R1.xyz, R0, R1;
DP3 R0.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.x;
MUL R2.xyz, R0.w, fragment.texcoord[7];
DP3 R0.y, fragment.color.primary, fragment.color.primary;
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, fragment.color.primary;
DP3_SAT R1.w, R0, R2;
RCP R0.w, c[6].x;
MUL R0.w, R1, R0;
MUL R0.xyz, R0.w, R1;
ADD R0.w, -R0, c[8].x;
MAD R2.xyz, R0.w, c[5], R0;
ADD R1.w, R1, -c[6].x;
CMP R1.xyz, R1.w, R2, R1;
MOV R0.y, fragment.color.primary.w;
MOV R0.x, fragment.texcoord[7].w;
TEX R0, R0, texture[5], 2D;
MUL R0.xyz, R0, c[7].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[8].x;
END
# 61 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c8, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
dcl_color0 v7
mov_pp r0.xyz, c3
texld r2, v0, s2
add_pp r0.xyz, -c0, r0
mad_pp r3.xyz, r2.z, r0, c0
texld r0.yw, v0.zwzw, s3
mad_pp r1.xy, r0.wyzw, c8.x, c8.y
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r4.xyz, -r3, c2
mul r1.w, r2, c4.x
mad_pp r3.xyz, r2.y, r4, r3
texld r0.xyz, v0, s1
mul r3.xyz, r0, r3
add_pp r0.x, -r0.w, c8.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
texldp r0, v1, s0
dp3_pp r2.y, v2, r1
dp3_pp r2.z, r1, v3
dp3_pp r2.w, r1, v4
mul r4.xyz, r3, r1.w
log_pp r0.w, r0.w
mul r4.xyz, r4, -r0.w
mul r0.w, r2.x, c1
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r3.w, r2.yzww, r1
mul r2.yzw, r2, r3.w
mad r1.xyz, -r2.yzww, c8.x, r1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r0.xyz, -r0, v5
mad r3.xyz, r3, r0, r4
texld r0.xyz, r1, s4
mul r1.xyz, r0.w, c1
mul r0.xyz, r1.w, r0
mad r1.xyz, r1, c8.w, r0
dp3 r0.x, v7, v7
rsq r0.x, r0.x
dp3 r0.y, v6, v6
mul r2.xyz, r0.x, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v6
dp3_sat r0.x, r2, r0
rcp r0.w, c6.x
mul r0.y, r0.x, r0.w
add r2.xyz, r3, r1
mul r1.xyz, r2, r0.y
add r0.y, -r0, c8.z
mad r1.xyz, r0.y, c5, r1
add r1.w, r0.x, -c6.x
cmp_pp r1.xyz, r1.w, r2, r1
mov r0.y, v7.w
mov r0.x, v6.w
texld r0, r0, s5
mul r0.xyz, r0, c7.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c8.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[0], texture[2], 2D;
MOV R0.xyz, c[0];
ADD R2.xyz, -R0, c[3];
MAD R2.xyz, R1.z, R2, c[0];
ADD R3.xyz, -R2, c[2];
MAD R2.xyz, R1.y, R3, R2;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[8].z, -c[8].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
ADD R0.z, -R0, c[8].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MUL R2.w, R1, c[4].x;
MUL R2.xyz, R3, R2;
DP3 R1.y, fragment.texcoord[2], R0;
DP3 R1.z, R0, fragment.texcoord[3];
DP3 R1.w, R0, fragment.texcoord[4];
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R3.xyz, R2, R2.w;
LG2 R0.w, R0.w;
MUL R3.xyz, R3, -R0.w;
MUL R0.w, R1.x, c[1];
MOV R4.x, fragment.texcoord[2].w;
MOV R4.z, fragment.texcoord[4].w;
MOV R4.y, fragment.texcoord[3].w;
DP3 R3.w, R1.yzww, R4;
MUL R1.yzw, R1, R3.w;
MAD R4.xyz, -R1.yzww, c[8].z, R4;
TEX R4.xyz, R4, texture[4], CUBE;
MUL R1.xyz, R2.w, R4;
MUL R4.xyz, R0.w, c[1];
MAD R1.xyz, R4, c[8].y, R1;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R0.xyz, -R0, fragment.texcoord[5];
MAD R0.xyz, R2, R0, R3;
ADD R1.xyz, R0, R1;
DP3 R0.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.x;
MUL R2.xyz, R0.w, fragment.texcoord[7];
DP3 R0.y, fragment.color.primary, fragment.color.primary;
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, fragment.color.primary;
DP3_SAT R1.w, R0, R2;
RCP R0.w, c[6].x;
MUL R0.w, R1, R0;
MUL R0.xyz, R0.w, R1;
ADD R0.w, -R0, c[8].x;
MAD R2.xyz, R0.w, c[5], R0;
ADD R1.w, R1, -c[6].x;
CMP R1.xyz, R1.w, R2, R1;
MOV R0.y, fragment.color.primary.w;
MOV R0.x, fragment.texcoord[7].w;
TEX R0, R0, texture[5], 2D;
MUL R0.xyz, R0, c[7].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[8].x;
END
# 61 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c8, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
dcl_color0 v7
mov_pp r0.xyz, c3
texld r2, v0, s2
add_pp r0.xyz, -c0, r0
mad_pp r3.xyz, r2.z, r0, c0
texld r0.yw, v0.zwzw, s3
mad_pp r1.xy, r0.wyzw, c8.x, c8.y
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r4.xyz, -r3, c2
mul r1.w, r2, c4.x
mad_pp r3.xyz, r2.y, r4, r3
texld r0.xyz, v0, s1
mul r3.xyz, r0, r3
add_pp r0.x, -r0.w, c8.z
rsq_pp r0.x, r0.x
rcp_pp r1.z, r0.x
texldp r0, v1, s0
dp3_pp r2.y, v2, r1
dp3_pp r2.z, r1, v3
dp3_pp r2.w, r1, v4
mul r4.xyz, r3, r1.w
log_pp r0.w, r0.w
mul r4.xyz, r4, -r0.w
mul r0.w, r2.x, c1
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r3.w, r2.yzww, r1
mul r2.yzw, r2, r3.w
mad r1.xyz, -r2.yzww, c8.x, r1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r0.xyz, -r0, v5
mad r3.xyz, r3, r0, r4
texld r0.xyz, r1, s4
mul r1.xyz, r0.w, c1
mul r0.xyz, r1.w, r0
mad r1.xyz, r1, c8.w, r0
dp3 r0.x, v7, v7
rsq r0.x, r0.x
dp3 r0.y, v6, v6
mul r2.xyz, r0.x, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v6
dp3_sat r0.x, r2, r0
rcp r0.w, c6.x
mul r0.y, r0.x, r0.w
add r2.xyz, r3, r1
mul r1.xyz, r2, r0.y
add r0.y, -r0, c8.z
mad r1.xyz, r0.y, c5, r1
add r1.w, r0.x, -c6.x
cmp_pp r1.xyz, r1.w, r2, r1
mov r0.y, v7.w
mov r0.x, v6.w
texld r0, r0, s5
mul r0.xyz, r0, c7.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c8.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4, fragment.texcoord[0], texture[2], 2D;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[8].z, -c[8].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
MOV R1.xyz, c[0];
ADD R1.xyz, -R1, c[3];
MAD R1.xyz, R4.z, R1, c[0];
ADD R2.xyz, -R1, c[2];
MAD R2.xyz, R4.y, R2, R1;
ADD R0.z, -R0, c[8].x;
RSQ R0.z, R0.z;
TEX R1.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R1.xyz, R1, R2;
RCP R0.z, R0.z;
DP3 R2.x, fragment.texcoord[2], R0;
DP3 R2.y, R0, fragment.texcoord[3];
DP3 R2.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R2, R0;
MUL R3.xyz, R2, R0.w;
MAD R3.xyz, -R3, c[8].z, R0;
MUL R1.w, R4, c[4].x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R2.xyz, R1, R1.w;
MUL R2.xyz, R0.w, R2;
ADD R0.xyz, R0, fragment.texcoord[5];
MAD R0.xyz, R1, R0, R2;
MUL R0.w, R4.x, c[1];
TEX R3.xyz, R3, texture[4], CUBE;
MUL R4.xyz, R1.w, R3;
MUL R3.xyz, R0.w, c[1];
MAD R3.xyz, R3, c[8].y, R4;
ADD R1.xyz, R0, R3;
DP3 R0.y, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.y;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R2.xyz, R0.w, fragment.texcoord[7];
MUL R0.xyz, R0.x, fragment.color.primary;
DP3_SAT R0.w, R0, R2;
RCP R1.w, c[6].x;
MUL R1.w, R0, R1;
MUL R0.xyz, R1.w, R1;
ADD R1.w, -R1, c[8].x;
MAD R2.xyz, R1.w, c[5], R0;
ADD R1.w, R0, -c[6].x;
CMP R1.xyz, R1.w, R2, R1;
MOV R0.y, fragment.color.primary.w;
MOV R0.x, fragment.texcoord[7].w;
TEX R0, R0, texture[5], 2D;
MUL R0.xyz, R0, c[7].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[8].x;
END
# 57 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c8, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
dcl_color0 v7
texld r0, v0, s2
texld r1.yw, v0.zwzw, s3
mad_pp r1.xy, r1.wyzw, c8.x, c8.y
mov_pp r2.xyz, c3
add_pp r2.xyz, -c0, r2
mad_pp r3.xyz, r0.z, r2, c0
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp r2.xyz, -r3, c2
mad_pp r2.xyz, r0.y, r2, r3
add_pp_sat r0.z, r1, r1.w
texld r3.xyz, v0, s1
mul r2.xyz, r3, r2
mul r2.w, r0, c4.x
add_pp r0.y, -r0.z, c8.z
rsq_pp r0.y, r0.y
rcp_pp r1.z, r0.y
dp3_pp r0.y, v2, r1
dp3_pp r0.z, r1, v3
dp3_pp r0.w, r1, v4
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r1.x, r0.yzww, r3
mul r0.yzw, r0, r1.x
mad r3.xyz, -r0.yzww, c8.x, r3
texldp r1, v1, s0
mul r4.xyz, r2, r2.w
mul r0.w, r0.x, c1
mul r4.xyz, r1.w, r4
add_pp r1.xyz, r1, v5
mad r1.xyz, r2, r1, r4
texld r2.xyz, r3, s4
mul r0.xyz, r2.w, r2
mul r2.xyz, r0.w, c1
mad r2.xyz, r2, c8.w, r0
dp3 r0.x, v6, v6
rsq r0.w, r0.x
mul r3.xyz, r0.w, v6
dp3 r0.y, v7, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v7
add r1.xyz, r1, r2
dp3_sat r1.w, r0, r3
rcp r0.w, c6.x
mul r0.w, r1, r0
mul r0.xyz, r1, r0.w
add r0.w, -r0, c8.z
mad r2.xyz, r0.w, c5, r0
add r1.w, r1, -c6.x
cmp_pp r1.xyz, r1.w, r1, r2
mov r0.y, v7.w
mov r0.x, v6.w
texld r0, r0, s5
mul r0.xyz, r0, c7.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c8.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4, fragment.texcoord[0], texture[2], 2D;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[8].z, -c[8].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
MOV R1.xyz, c[0];
ADD R1.xyz, -R1, c[3];
MAD R1.xyz, R4.z, R1, c[0];
ADD R2.xyz, -R1, c[2];
MAD R2.xyz, R4.y, R2, R1;
ADD R0.z, -R0, c[8].x;
RSQ R0.z, R0.z;
TEX R1.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R1.xyz, R1, R2;
RCP R0.z, R0.z;
DP3 R2.x, fragment.texcoord[2], R0;
DP3 R2.y, R0, fragment.texcoord[3];
DP3 R2.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R2, R0;
MUL R3.xyz, R2, R0.w;
MAD R3.xyz, -R3, c[8].z, R0;
MUL R1.w, R4, c[4].x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R2.xyz, R1, R1.w;
MUL R2.xyz, R0.w, R2;
ADD R0.xyz, R0, fragment.texcoord[5];
MAD R0.xyz, R1, R0, R2;
MUL R0.w, R4.x, c[1];
TEX R3.xyz, R3, texture[4], CUBE;
MUL R4.xyz, R1.w, R3;
MUL R3.xyz, R0.w, c[1];
MAD R3.xyz, R3, c[8].y, R4;
ADD R1.xyz, R0, R3;
DP3 R0.y, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.y;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R2.xyz, R0.w, fragment.texcoord[7];
MUL R0.xyz, R0.x, fragment.color.primary;
DP3_SAT R0.w, R0, R2;
RCP R1.w, c[6].x;
MUL R1.w, R0, R1;
MUL R0.xyz, R1.w, R1;
ADD R1.w, -R1, c[8].x;
MAD R2.xyz, R1.w, c[5], R0;
ADD R1.w, R0, -c[6].x;
CMP R1.xyz, R1.w, R2, R1;
MOV R0.y, fragment.color.primary.w;
MOV R0.x, fragment.texcoord[7].w;
TEX R0, R0, texture[5], 2D;
MUL R0.xyz, R0, c[7].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[8].x;
END
# 57 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c8, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
dcl_color0 v7
texld r0, v0, s2
texld r1.yw, v0.zwzw, s3
mad_pp r1.xy, r1.wyzw, c8.x, c8.y
mov_pp r2.xyz, c3
add_pp r2.xyz, -c0, r2
mad_pp r3.xyz, r0.z, r2, c0
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp r2.xyz, -r3, c2
mad_pp r2.xyz, r0.y, r2, r3
add_pp_sat r0.z, r1, r1.w
texld r3.xyz, v0, s1
mul r2.xyz, r3, r2
mul r2.w, r0, c4.x
add_pp r0.y, -r0.z, c8.z
rsq_pp r0.y, r0.y
rcp_pp r1.z, r0.y
dp3_pp r0.y, v2, r1
dp3_pp r0.z, r1, v3
dp3_pp r0.w, r1, v4
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r1.x, r0.yzww, r3
mul r0.yzw, r0, r1.x
mad r3.xyz, -r0.yzww, c8.x, r3
texldp r1, v1, s0
mul r4.xyz, r2, r2.w
mul r0.w, r0.x, c1
mul r4.xyz, r1.w, r4
add_pp r1.xyz, r1, v5
mad r1.xyz, r2, r1, r4
texld r2.xyz, r3, s4
mul r0.xyz, r2.w, r2
mul r2.xyz, r0.w, c1
mad r2.xyz, r2, c8.w, r0
dp3 r0.x, v6, v6
rsq r0.w, r0.x
mul r3.xyz, r0.w, v6
dp3 r0.y, v7, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v7
add r1.xyz, r1, r2
dp3_sat r1.w, r0, r3
rcp r0.w, c6.x
mul r0.w, r1, r0
mul r0.xyz, r1, r0.w
add r0.w, -r0, c8.z
mad r2.xyz, r0.w, c5, r0
add r1.w, r1, -c6.x
cmp_pp r1.xyz, r1.w, r1, r2
mov r0.y, v7.w
mov r0.x, v6.w
texld r0, r0, s5
mul r0.xyz, r0, c7.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c8.z
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R4, fragment.texcoord[0], texture[2], 2D;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R0.xy, R0.wyzw, c[8].z, -c[8].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
MOV R1.xyz, c[0];
ADD R1.xyz, -R1, c[3];
MAD R1.xyz, R4.z, R1, c[0];
ADD R2.xyz, -R1, c[2];
MAD R2.xyz, R4.y, R2, R1;
ADD R0.z, -R0, c[8].x;
RSQ R0.z, R0.z;
TEX R1.xyz, fragment.texcoord[0], texture[1], 2D;
MUL R1.xyz, R1, R2;
RCP R0.z, R0.z;
DP3 R2.x, fragment.texcoord[2], R0;
DP3 R2.y, R0, fragment.texcoord[3];
DP3 R2.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R2, R0;
MUL R3.xyz, R2, R0.w;
MAD R3.xyz, -R3, c[8].z, R0;
MUL R1.w, R4, c[4].x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R2.xyz, R1, R1.w;
MUL R2.xyz, R0.w, R2;
ADD R0.xyz, R0, fragment.texcoord[5];
MAD R0.xyz, R1, R0, R2;
MUL R0.w, R4.x, c[1];
TEX R3.xyz, R3, texture[4], CUBE;
MUL R4.xyz, R1.w, R3;
MUL R3.xyz, R0.w, c[1];
MAD R3.xyz, R3, c[8].y, R4;
ADD R1.xyz, R0, R3;
DP3 R0.y, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.y;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R2.xyz, R0.w, fragment.texcoord[7];
MUL R0.xyz, R0.x, fragment.color.primary;
DP3_SAT R0.w, R0, R2;
RCP R1.w, c[6].x;
MUL R1.w, R0, R1;
MUL R0.xyz, R1.w, R1;
ADD R1.w, -R1, c[8].x;
MAD R2.xyz, R1.w, c[5], R0;
ADD R1.w, R0, -c[6].x;
CMP R1.xyz, R1.w, R2, R1;
MOV R0.y, fragment.color.primary.w;
MOV R0.x, fragment.texcoord[7].w;
TEX R0, R0, texture[5], 2D;
MUL R0.xyz, R0, c[7].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
MOV result.color.w, c[8].x;
END
# 57 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Vector 5 [_OutlineColor]
Float 6 [_OutlineWidth]
Float 7 [_RespawnStrength]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RespawnTexture] 2D 5
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
def c8, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
dcl_color0 v7
texld r0, v0, s2
texld r1.yw, v0.zwzw, s3
mad_pp r1.xy, r1.wyzw, c8.x, c8.y
mov_pp r2.xyz, c3
add_pp r2.xyz, -c0, r2
mad_pp r3.xyz, r0.z, r2, c0
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp r2.xyz, -r3, c2
mad_pp r2.xyz, r0.y, r2, r3
add_pp_sat r0.z, r1, r1.w
texld r3.xyz, v0, s1
mul r2.xyz, r3, r2
mul r2.w, r0, c4.x
add_pp r0.y, -r0.z, c8.z
rsq_pp r0.y, r0.y
rcp_pp r1.z, r0.y
dp3_pp r0.y, v2, r1
dp3_pp r0.z, r1, v3
dp3_pp r0.w, r1, v4
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r1.x, r0.yzww, r3
mul r0.yzw, r0, r1.x
mad r3.xyz, -r0.yzww, c8.x, r3
texldp r1, v1, s0
mul r4.xyz, r2, r2.w
mul r0.w, r0.x, c1
mul r4.xyz, r1.w, r4
add_pp r1.xyz, r1, v5
mad r1.xyz, r2, r1, r4
texld r2.xyz, r3, s4
mul r0.xyz, r2.w, r2
mul r2.xyz, r0.w, c1
mad r2.xyz, r2, c8.w, r0
dp3 r0.x, v6, v6
rsq r0.w, r0.x
mul r3.xyz, r0.w, v6
dp3 r0.y, v7, v7
rsq r0.y, r0.y
mul r0.xyz, r0.y, v7
add r1.xyz, r1, r2
dp3_sat r1.w, r0, r3
rcp r0.w, c6.x
mul r0.w, r1, r0
mul r0.xyz, r1, r0.w
add r0.w, -r0, c8.z
mad r2.xyz, r0.w, c5, r0
add r1.w, r1, -c6.x
cmp_pp r1.xyz, r1.w, r1, r2
mov r0.y, v7.w
mov r0.x, v6.w
texld r0, r0, s5
mul r0.xyz, r0, c7.x
add_pp r0.xyz, r0, -r1
mad_pp oC0.xyz, r0.w, r0, r1
mov_pp oC0.w, c8.z
"
}
}
 }
}
Fallback "Diffuse"
}