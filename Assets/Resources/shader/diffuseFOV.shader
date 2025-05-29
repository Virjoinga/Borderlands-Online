„¹Shader "Custom/diffuseFOV" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _Effect_Para ("Effect Para", Float) = 0
 _Effect_Color ("Effect Color", Color) = (1,1,1,1)
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Geometry+2" "RenderType"="Opaque" }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "QUEUE"="Geometry+2" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
Vector 13 [unity_Scale]
"!!ARBvp1.0
PARAM c[14] = { program.local[0],
		state.matrix.modelview[0],
		program.local[5..13] };
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
DP3 result.texcoord[0].z, R1, c[7];
DP3 result.texcoord[0].y, R1, c[6];
DP3 result.texcoord[0].x, R1, c[5];
END
# 28 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
Vector 12 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
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
dp3 oT0.z, r1, c6
dp3 oT0.y, r1, c5
dp3 oT0.x, r1, c4
"
}
}
Program "fp" {
SubProgram "opengl " {
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0, 0.5 } };
MAD result.color.xyz, fragment.texcoord[0], c[0].y, c[0].y;
MOV result.color.w, c[0].x;
END
# 2 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
"ps_2_0
def c0, 0.50000000, 0.00000000, 0, 0
dcl t0.xyz
mad_pp r0.xyz, t0, c0.x, c0.x
mov_pp r0.w, c0.y
mov_pp oC0, r0
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
Matrix 9 [_ProjMat]
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
"!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1, c[2];
MOV R3, c[3];
MOV R0, c[1];
MUL R2, R1, c[12].y;
MAD R2, R0, c[12].x, R2;
MUL R5, R1, c[11].y;
MAD R2, R3, c[12].z, R2;
MOV R4, c[4];
MAD R2, R4, c[12].w, R2;
DP4 R6.w, R2, vertex.position;
MUL R2, R1, c[9].y;
MAD R2, R0, c[9].x, R2;
MAD R5, R0, c[11].x, R5;
MUL R1, R1, c[10].y;
MAD R0, R0, c[10].x, R1;
MAD R1, R3, c[9].z, R2;
MAD R0, R3, c[10].z, R0;
MAD R0, R4, c[10].w, R0;
MAD R1, R4, c[9].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R1, R3, c[11].z, R5;
MAD R1, R4, c[11].w, R1;
DP4 R6.z, vertex.position, R1;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[1].xy, R0, R0.z;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R3.w, R0, c[6];
DP3 R1.w, R0, c[7];
DP3 R2.x, R0, c[5];
MOV R2.y, R3.w;
MOV R2.z, R1.w;
MUL R0, R2.xyzz, R2.yzzx;
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[17];
DP4 R1.y, R2, c[16];
DP4 R1.x, R2, c[15];
MUL R2.y, R3.w, R3.w;
DP4 R3.z, R0, c[20];
DP4 R3.y, R0, c[19];
DP4 R3.x, R0, c[18];
MAD R2.y, R2.x, R2.x, -R2;
MUL R0.xyz, R2.y, c[21];
ADD R1.xyz, R1, R3;
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3].z, R1.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R2;
ADD result.texcoord[4].xyz, -R0, c[13];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 57 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
"vs_2_0
def c24, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.y, v0, r1
mul r1.xyz, v1, c22.w
dp4 r0.x, v0, r2
dp3 r2.w, r1, c4
mul r2.xyz, r0.xyww, c24.x
dp3 r4.x, r1, c5
dp3 r3.w, r1, c6
mul r2.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r2
mov r2.x, r4
mov r2.y, r3.w
mov r2.z, c24.y
mul r1, r2.wxyy, r2.xyyw
dp4 r3.z, r2.wxyz, c17
dp4 r3.y, r2.wxyz, c16
dp4 r3.x, r2.wxyz, c15
dp4 r2.z, r1, c20
dp4 r2.y, r1, c19
dp4 r2.x, r1, c18
add r3.xyz, r3, r2
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.x, c10.z
mad r1, c2, r2.x, r1
mov r2.x, c10.w
mul r0.z, r4.x, r4.x
mad r0.z, r2.w, r2.w, -r0
mad r1, c3, r2.x, r1
mul r2.xyz, r0.z, c21
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, r3, r2
mov oT3.z, r3.w
mov oT3.y, r4.x
mov oT3.x, r2.w
add oT4.xyz, -r0, c12
mov oT5.xyz, r0
mad oT0.xy, v2, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
"!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1, c[2];
MOV R3, c[3];
MOV R0, c[1];
MUL R2, R1, c[12].y;
MAD R2, R0, c[12].x, R2;
MUL R5, R1, c[11].y;
MAD R2, R3, c[12].z, R2;
MOV R4, c[4];
MAD R2, R4, c[12].w, R2;
DP4 R6.w, R2, vertex.position;
MUL R2, R1, c[9].y;
MAD R2, R0, c[9].x, R2;
MAD R5, R0, c[11].x, R5;
MUL R1, R1, c[10].y;
MAD R0, R0, c[10].x, R1;
MAD R1, R3, c[9].z, R2;
MAD R0, R3, c[10].z, R0;
MAD R0, R4, c[10].w, R0;
MAD R1, R4, c[9].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R1, R3, c[11].z, R5;
MAD R1, R4, c[11].w, R1;
DP4 R6.z, vertex.position, R1;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[1].xy, R0, R0.z;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R3.w, R0, c[6];
DP3 R1.w, R0, c[7];
DP3 R2.x, R0, c[5];
MOV R2.y, R3.w;
MOV R2.z, R1.w;
MUL R0, R2.xyzz, R2.yzzx;
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[17];
DP4 R1.y, R2, c[16];
DP4 R1.x, R2, c[15];
MUL R2.y, R3.w, R3.w;
DP4 R3.z, R0, c[20];
DP4 R3.y, R0, c[19];
DP4 R3.x, R0, c[18];
MAD R2.y, R2.x, R2.x, -R2;
MUL R0.xyz, R2.y, c[21];
ADD R1.xyz, R1, R3;
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3].z, R1.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R2;
ADD result.texcoord[4].xyz, -R0, c[13];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 57 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
"vs_2_0
def c24, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.y, v0, r1
mul r1.xyz, v1, c22.w
dp4 r0.x, v0, r2
dp3 r2.w, r1, c4
mul r2.xyz, r0.xyww, c24.x
dp3 r4.x, r1, c5
dp3 r3.w, r1, c6
mul r2.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r2
mov r2.x, r4
mov r2.y, r3.w
mov r2.z, c24.y
mul r1, r2.wxyy, r2.xyyw
dp4 r3.z, r2.wxyz, c17
dp4 r3.y, r2.wxyz, c16
dp4 r3.x, r2.wxyz, c15
dp4 r2.z, r1, c20
dp4 r2.y, r1, c19
dp4 r2.x, r1, c18
add r3.xyz, r3, r2
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.x, c10.z
mad r1, c2, r2.x, r1
mov r2.x, c10.w
mul r0.z, r4.x, r4.x
mad r0.z, r2.w, r2.w, -r0
mad r1, c3, r2.x, r1
mul r2.xyz, r0.z, c21
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, r3, r2
mov oT3.z, r3.w
mov oT3.y, r4.x
mov oT3.x, r2.w
add oT4.xyz, -r0, c12
mov oT5.xyz, r0
mad oT0.xy, v2, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
"!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1, c[2];
MOV R3, c[3];
MOV R0, c[1];
MUL R2, R1, c[12].y;
MAD R2, R0, c[12].x, R2;
MUL R5, R1, c[11].y;
MAD R2, R3, c[12].z, R2;
MOV R4, c[4];
MAD R2, R4, c[12].w, R2;
DP4 R6.w, R2, vertex.position;
MUL R2, R1, c[9].y;
MAD R2, R0, c[9].x, R2;
MAD R5, R0, c[11].x, R5;
MUL R1, R1, c[10].y;
MAD R0, R0, c[10].x, R1;
MAD R1, R3, c[9].z, R2;
MAD R0, R3, c[10].z, R0;
MAD R0, R4, c[10].w, R0;
MAD R1, R4, c[9].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R1, R3, c[11].z, R5;
MAD R1, R4, c[11].w, R1;
DP4 R6.z, vertex.position, R1;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[1].xy, R0, R0.z;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R3.w, R0, c[6];
DP3 R1.w, R0, c[7];
DP3 R2.x, R0, c[5];
MOV R2.y, R3.w;
MOV R2.z, R1.w;
MUL R0, R2.xyzz, R2.yzzx;
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[17];
DP4 R1.y, R2, c[16];
DP4 R1.x, R2, c[15];
MUL R2.y, R3.w, R3.w;
DP4 R3.z, R0, c[20];
DP4 R3.y, R0, c[19];
DP4 R3.x, R0, c[18];
MAD R2.y, R2.x, R2.x, -R2;
MUL R0.xyz, R2.y, c[21];
ADD R1.xyz, R1, R3;
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3].z, R1.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R2;
ADD result.texcoord[4].xyz, -R0, c[13];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 57 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
"vs_2_0
def c24, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.y, v0, r1
mul r1.xyz, v1, c22.w
dp4 r0.x, v0, r2
dp3 r2.w, r1, c4
mul r2.xyz, r0.xyww, c24.x
dp3 r4.x, r1, c5
dp3 r3.w, r1, c6
mul r2.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r2
mov r2.x, r4
mov r2.y, r3.w
mov r2.z, c24.y
mul r1, r2.wxyy, r2.xyyw
dp4 r3.z, r2.wxyz, c17
dp4 r3.y, r2.wxyz, c16
dp4 r3.x, r2.wxyz, c15
dp4 r2.z, r1, c20
dp4 r2.y, r1, c19
dp4 r2.x, r1, c18
add r3.xyz, r3, r2
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.x, c10.z
mad r1, c2, r2.x, r1
mov r2.x, c10.w
mul r0.z, r4.x, r4.x
mad r0.z, r2.w, r2.w, -r0
mad r1, c3, r2.x, r1
mul r2.xyz, r0.z, c21
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, r3, r2
mov oT3.z, r3.w
mov oT3.y, r4.x
mov oT3.x, r2.w
add oT4.xyz, -r0, c12
mov oT5.xyz, r0
mad oT0.xy, v2, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
"!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1, c[2];
MOV R3, c[3];
MOV R0, c[1];
MUL R2, R1, c[12].y;
MAD R2, R0, c[12].x, R2;
MUL R5, R1, c[11].y;
MAD R2, R3, c[12].z, R2;
MOV R4, c[4];
MAD R2, R4, c[12].w, R2;
DP4 R6.w, R2, vertex.position;
MUL R2, R1, c[9].y;
MAD R2, R0, c[9].x, R2;
MAD R5, R0, c[11].x, R5;
MUL R1, R1, c[10].y;
MAD R0, R0, c[10].x, R1;
MAD R1, R3, c[9].z, R2;
MAD R0, R3, c[10].z, R0;
MAD R0, R4, c[10].w, R0;
MAD R1, R4, c[9].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R1, R3, c[11].z, R5;
MAD R1, R4, c[11].w, R1;
DP4 R6.z, vertex.position, R1;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[1].xy, R0, R0.z;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R3.w, R0, c[6];
DP3 R1.w, R0, c[7];
DP3 R2.x, R0, c[5];
MOV R2.y, R3.w;
MOV R2.z, R1.w;
MUL R0, R2.xyzz, R2.yzzx;
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[17];
DP4 R1.y, R2, c[16];
DP4 R1.x, R2, c[15];
MUL R2.y, R3.w, R3.w;
DP4 R3.z, R0, c[20];
DP4 R3.y, R0, c[19];
DP4 R3.x, R0, c[18];
MAD R2.y, R2.x, R2.x, -R2;
MUL R0.xyz, R2.y, c[21];
ADD R1.xyz, R1, R3;
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3].z, R1.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R2;
ADD result.texcoord[4].xyz, -R0, c[13];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 57 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
"vs_2_0
def c24, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.y, v0, r1
mul r1.xyz, v1, c22.w
dp4 r0.x, v0, r2
dp3 r2.w, r1, c4
mul r2.xyz, r0.xyww, c24.x
dp3 r4.x, r1, c5
dp3 r3.w, r1, c6
mul r2.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r2
mov r2.x, r4
mov r2.y, r3.w
mov r2.z, c24.y
mul r1, r2.wxyy, r2.xyyw
dp4 r3.z, r2.wxyz, c17
dp4 r3.y, r2.wxyz, c16
dp4 r3.x, r2.wxyz, c15
dp4 r2.z, r1, c20
dp4 r2.y, r1, c19
dp4 r2.x, r1, c18
add r3.xyz, r3, r2
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.x, c10.z
mad r1, c2, r2.x, r1
mov r2.x, c10.w
mul r0.z, r4.x, r4.x
mad r0.z, r2.w, r2.w, -r0
mad r1, c3, r2.x, r1
mul r2.xyz, r0.z, c21
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, r3, r2
mov oT3.z, r3.w
mov oT3.y, r4.x
mov oT3.x, r2.w
add oT4.xyz, -r0, c12
mov oT5.xyz, r0
mad oT0.xy, v2, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
"!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1, c[2];
MOV R3, c[3];
MOV R0, c[1];
MUL R2, R1, c[12].y;
MAD R2, R0, c[12].x, R2;
MUL R5, R1, c[11].y;
MAD R2, R3, c[12].z, R2;
MOV R4, c[4];
MAD R2, R4, c[12].w, R2;
DP4 R6.w, R2, vertex.position;
MUL R2, R1, c[9].y;
MAD R2, R0, c[9].x, R2;
MAD R5, R0, c[11].x, R5;
MUL R1, R1, c[10].y;
MAD R0, R0, c[10].x, R1;
MAD R1, R3, c[9].z, R2;
MAD R0, R3, c[10].z, R0;
MAD R0, R4, c[10].w, R0;
MAD R1, R4, c[9].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R1, R3, c[11].z, R5;
MAD R1, R4, c[11].w, R1;
DP4 R6.z, vertex.position, R1;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[1].xy, R0, R0.z;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R3.w, R0, c[6];
DP3 R1.w, R0, c[7];
DP3 R2.x, R0, c[5];
MOV R2.y, R3.w;
MOV R2.z, R1.w;
MUL R0, R2.xyzz, R2.yzzx;
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[17];
DP4 R1.y, R2, c[16];
DP4 R1.x, R2, c[15];
MUL R2.y, R3.w, R3.w;
DP4 R3.z, R0, c[20];
DP4 R3.y, R0, c[19];
DP4 R3.x, R0, c[18];
MAD R2.y, R2.x, R2.x, -R2;
MUL R0.xyz, R2.y, c[21];
ADD R1.xyz, R1, R3;
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3].z, R1.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R2;
ADD result.texcoord[4].xyz, -R0, c[13];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 57 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
"vs_2_0
def c24, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.y, v0, r1
mul r1.xyz, v1, c22.w
dp4 r0.x, v0, r2
dp3 r2.w, r1, c4
mul r2.xyz, r0.xyww, c24.x
dp3 r4.x, r1, c5
dp3 r3.w, r1, c6
mul r2.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r2
mov r2.x, r4
mov r2.y, r3.w
mov r2.z, c24.y
mul r1, r2.wxyy, r2.xyyw
dp4 r3.z, r2.wxyz, c17
dp4 r3.y, r2.wxyz, c16
dp4 r3.x, r2.wxyz, c15
dp4 r2.z, r1, c20
dp4 r2.y, r1, c19
dp4 r2.x, r1, c18
add r3.xyz, r3, r2
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.x, c10.z
mad r1, c2, r2.x, r1
mov r2.x, c10.w
mul r0.z, r4.x, r4.x
mad r0.z, r2.w, r2.w, -r0
mad r1, c3, r2.x, r1
mul r2.xyz, r0.z, c21
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, r3, r2
mov oT3.z, r3.w
mov oT3.y, r4.x
mov oT3.x, r2.w
add oT4.xyz, -r0, c12
mov oT5.xyz, r0
mad oT0.xy, v2, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
"!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1, c[2];
MOV R3, c[3];
MOV R0, c[1];
MUL R2, R1, c[12].y;
MAD R2, R0, c[12].x, R2;
MUL R5, R1, c[11].y;
MAD R2, R3, c[12].z, R2;
MOV R4, c[4];
MAD R2, R4, c[12].w, R2;
DP4 R6.w, R2, vertex.position;
MUL R2, R1, c[9].y;
MAD R2, R0, c[9].x, R2;
MAD R5, R0, c[11].x, R5;
MUL R1, R1, c[10].y;
MAD R0, R0, c[10].x, R1;
MAD R1, R3, c[9].z, R2;
MAD R0, R3, c[10].z, R0;
MAD R0, R4, c[10].w, R0;
MAD R1, R4, c[9].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R1, R3, c[11].z, R5;
MAD R1, R4, c[11].w, R1;
DP4 R6.z, vertex.position, R1;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MUL R0.y, R0, c[14].x;
ADD result.texcoord[1].xy, R0, R0.z;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R3.w, R0, c[6];
DP3 R1.w, R0, c[7];
DP3 R2.x, R0, c[5];
MOV R2.y, R3.w;
MOV R2.z, R1.w;
MUL R0, R2.xyzz, R2.yzzx;
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[17];
DP4 R1.y, R2, c[16];
DP4 R1.x, R2, c[15];
MUL R2.y, R3.w, R3.w;
DP4 R3.z, R0, c[20];
DP4 R3.y, R0, c[19];
DP4 R3.x, R0, c[18];
MAD R2.y, R2.x, R2.x, -R2;
MUL R0.xyz, R2.y, c[21];
ADD R1.xyz, R1, R3;
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3].z, R1.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R2;
ADD result.texcoord[4].xyz, -R0, c[13];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 57 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
"vs_2_0
def c24, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.y, v0, r1
mul r1.xyz, v1, c22.w
dp4 r0.x, v0, r2
dp3 r2.w, r1, c4
mul r2.xyz, r0.xyww, c24.x
dp3 r4.x, r1, c5
dp3 r3.w, r1, c6
mul r2.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r2
mov r2.x, r4
mov r2.y, r3.w
mov r2.z, c24.y
mul r1, r2.wxyy, r2.xyyw
dp4 r3.z, r2.wxyz, c17
dp4 r3.y, r2.wxyz, c16
dp4 r3.x, r2.wxyz, c15
dp4 r2.z, r1, c20
dp4 r2.y, r1, c19
dp4 r2.x, r1, c18
add r3.xyz, r3, r2
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.x, c10.z
mad r1, c2, r2.x, r1
mov r2.x, c10.w
mul r0.z, r4.x, r4.x
mad r0.z, r2.w, r2.w, -r0
mad r1, c3, r2.x, r1
mul r2.xyz, r0.z, c21
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, r3, r2
mov oT3.z, r3.w
mov oT3.y, r4.x
mov oT3.x, r2.w
add oT4.xyz, -r0, c12
mov oT5.xyz, r0
mad oT0.xy, v2, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"!!ARBvp1.0
PARAM c[28] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..27] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[12].y;
MUL R5, R3, c[11].y;
MOV R1, c[3];
MAD R0, R2, c[12].x, R0;
MAD R4, R1, c[12].z, R0;
MOV R0, c[4];
MAD R4, R0, c[12].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[9].y;
MAD R4, R2, c[9].x, R4;
MAD R5, R2, c[11].x, R5;
MUL R3, R3, c[10].y;
MAD R2, R2, c[10].x, R3;
MAD R3, R1, c[9].z, R4;
MAD R2, R1, c[10].z, R2;
MAD R3, R0, c[9].w, R3;
MAD R2, R0, c[10].w, R2;
MAD R1, R1, c[11].z, R5;
MAD R0, R0, c[11].w, R1;
DP4 R6.z, vertex.position, R0;
DP4 R6.x, vertex.position, R3;
DP4 R6.y, vertex.position, R2;
MUL R0.xyz, vertex.normal, c[23].w;
DP3 R2.w, R0, c[6];
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R3.x, R0, c[5];
DP3 R3.z, R0, c[7];
MUL R2.y, R2, c[15].x;
MOV R1.x, R3;
MOV R1.y, R2.w;
MOV R1.z, R3;
MUL R0, R1.xyzz, R1.yzzx;
MOV R1.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.y, R1, c[17];
DP4 R2.x, R1, c[16];
DP4 R2.z, R1, c[18];
DP4 R1.z, R0, c[21];
DP4 R1.y, R0, c[20];
DP4 R1.x, R0, c[19];
ADD R1.xyz, R2, R1;
MUL R1.w, R2, R2;
MAD R0.x, R3, R3, -R1.w;
MUL R0.xyz, R0.x, c[22];
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD R4.xy, vertex.position.zyzw, c[25], c[25].zwzw;
MOV R2.x, c[26];
MOV R2.y, c[27].x;
MAD R2.xy, R2, c[13].y, R4;
MOV R3.w, R2.x;
MOV R3.y, R2.w;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3], R3;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[14];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 63 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"vs_2_0
def c28, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.x, v0, r2
mul r2.xyz, v1, c23.w
dp4 r0.y, v0, r1
mul r1.xyz, r0.xyww, c28.x
mul r1.y, r1, c14.x
dp3 r3.w, r2, c4
mad oT1.xy, r1.z, c15.zwzw, r1
dp3 r4.y, r2, c5
dp3 r4.x, r2, c6
mov r1.x, r3.w
mov r1.y, r4
mov r1.z, r4.x
mov r1.w, c28.y
mul r2, r1.xyzz, r1.yzzx
dp4 r3.z, r1, c18
dp4 r3.y, r1, c17
dp4 r3.x, r1, c16
dp4 r1.z, r2, c21
dp4 r1.y, r2, c20
dp4 r1.x, r2, c19
add r2.xyz, r3, r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.w, c10.z
mad r1, c2, r2.w, r1
mul r0.z, r4.y, r4.y
mad r0.z, r3.w, r3.w, -r0
mul r3.xyz, r0.z, c22
add oT2.xyz, r2, r3
mov r2.w, c10
mad r1, c3, r2.w, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
mad r1.xy, v0.zyzw, c25, c25.zwzw
mov r0.x, c26
mov r0.y, c27.x
mad r0.xy, r0, c12.y, r1
mov r3.z, r0.x
mov oT4.w, r0.y
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov r3.x, r4.y
mov r3.y, r4.x
mov oT3, r3.wxyz
add oT4.xyz, -r0, c13
mov oT5.xyz, r0
mad oT0.xy, v2, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"!!ARBvp1.0
PARAM c[28] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..27] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[12].y;
MUL R5, R3, c[11].y;
MOV R1, c[3];
MAD R0, R2, c[12].x, R0;
MAD R4, R1, c[12].z, R0;
MOV R0, c[4];
MAD R4, R0, c[12].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[9].y;
MAD R4, R2, c[9].x, R4;
MAD R5, R2, c[11].x, R5;
MUL R3, R3, c[10].y;
MAD R2, R2, c[10].x, R3;
MAD R3, R1, c[9].z, R4;
MAD R2, R1, c[10].z, R2;
MAD R3, R0, c[9].w, R3;
MAD R2, R0, c[10].w, R2;
MAD R1, R1, c[11].z, R5;
MAD R0, R0, c[11].w, R1;
DP4 R6.z, vertex.position, R0;
DP4 R6.x, vertex.position, R3;
DP4 R6.y, vertex.position, R2;
MUL R0.xyz, vertex.normal, c[23].w;
DP3 R2.w, R0, c[6];
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R3.x, R0, c[5];
DP3 R3.z, R0, c[7];
MUL R2.y, R2, c[15].x;
MOV R1.x, R3;
MOV R1.y, R2.w;
MOV R1.z, R3;
MUL R0, R1.xyzz, R1.yzzx;
MOV R1.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.y, R1, c[17];
DP4 R2.x, R1, c[16];
DP4 R2.z, R1, c[18];
DP4 R1.z, R0, c[21];
DP4 R1.y, R0, c[20];
DP4 R1.x, R0, c[19];
ADD R1.xyz, R2, R1;
MUL R1.w, R2, R2;
MAD R0.x, R3, R3, -R1.w;
MUL R0.xyz, R0.x, c[22];
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD R4.xy, vertex.position.zyzw, c[25], c[25].zwzw;
MOV R2.x, c[26];
MOV R2.y, c[27].x;
MAD R2.xy, R2, c[13].y, R4;
MOV R3.w, R2.x;
MOV R3.y, R2.w;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3], R3;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[14];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 63 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"vs_2_0
def c28, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.x, v0, r2
mul r2.xyz, v1, c23.w
dp4 r0.y, v0, r1
mul r1.xyz, r0.xyww, c28.x
mul r1.y, r1, c14.x
dp3 r3.w, r2, c4
mad oT1.xy, r1.z, c15.zwzw, r1
dp3 r4.y, r2, c5
dp3 r4.x, r2, c6
mov r1.x, r3.w
mov r1.y, r4
mov r1.z, r4.x
mov r1.w, c28.y
mul r2, r1.xyzz, r1.yzzx
dp4 r3.z, r1, c18
dp4 r3.y, r1, c17
dp4 r3.x, r1, c16
dp4 r1.z, r2, c21
dp4 r1.y, r2, c20
dp4 r1.x, r2, c19
add r2.xyz, r3, r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.w, c10.z
mad r1, c2, r2.w, r1
mul r0.z, r4.y, r4.y
mad r0.z, r3.w, r3.w, -r0
mul r3.xyz, r0.z, c22
add oT2.xyz, r2, r3
mov r2.w, c10
mad r1, c3, r2.w, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
mad r1.xy, v0.zyzw, c25, c25.zwzw
mov r0.x, c26
mov r0.y, c27.x
mad r0.xy, r0, c12.y, r1
mov r3.z, r0.x
mov oT4.w, r0.y
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov r3.x, r4.y
mov r3.y, r4.x
mov oT3, r3.wxyz
add oT4.xyz, -r0, c13
mov oT5.xyz, r0
mad oT0.xy, v2, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"!!ARBvp1.0
PARAM c[28] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..27] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[12].y;
MUL R5, R3, c[11].y;
MOV R1, c[3];
MAD R0, R2, c[12].x, R0;
MAD R4, R1, c[12].z, R0;
MOV R0, c[4];
MAD R4, R0, c[12].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[9].y;
MAD R4, R2, c[9].x, R4;
MAD R5, R2, c[11].x, R5;
MUL R3, R3, c[10].y;
MAD R2, R2, c[10].x, R3;
MAD R3, R1, c[9].z, R4;
MAD R2, R1, c[10].z, R2;
MAD R3, R0, c[9].w, R3;
MAD R2, R0, c[10].w, R2;
MAD R1, R1, c[11].z, R5;
MAD R0, R0, c[11].w, R1;
DP4 R6.z, vertex.position, R0;
DP4 R6.x, vertex.position, R3;
DP4 R6.y, vertex.position, R2;
MUL R0.xyz, vertex.normal, c[23].w;
DP3 R2.w, R0, c[6];
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R3.x, R0, c[5];
DP3 R3.z, R0, c[7];
MUL R2.y, R2, c[15].x;
MOV R1.x, R3;
MOV R1.y, R2.w;
MOV R1.z, R3;
MUL R0, R1.xyzz, R1.yzzx;
MOV R1.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.y, R1, c[17];
DP4 R2.x, R1, c[16];
DP4 R2.z, R1, c[18];
DP4 R1.z, R0, c[21];
DP4 R1.y, R0, c[20];
DP4 R1.x, R0, c[19];
ADD R1.xyz, R2, R1;
MUL R1.w, R2, R2;
MAD R0.x, R3, R3, -R1.w;
MUL R0.xyz, R0.x, c[22];
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD R4.xy, vertex.position.zyzw, c[25], c[25].zwzw;
MOV R2.x, c[26];
MOV R2.y, c[27].x;
MAD R2.xy, R2, c[13].y, R4;
MOV R3.w, R2.x;
MOV R3.y, R2.w;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3], R3;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[14];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 63 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"vs_2_0
def c28, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.x, v0, r2
mul r2.xyz, v1, c23.w
dp4 r0.y, v0, r1
mul r1.xyz, r0.xyww, c28.x
mul r1.y, r1, c14.x
dp3 r3.w, r2, c4
mad oT1.xy, r1.z, c15.zwzw, r1
dp3 r4.y, r2, c5
dp3 r4.x, r2, c6
mov r1.x, r3.w
mov r1.y, r4
mov r1.z, r4.x
mov r1.w, c28.y
mul r2, r1.xyzz, r1.yzzx
dp4 r3.z, r1, c18
dp4 r3.y, r1, c17
dp4 r3.x, r1, c16
dp4 r1.z, r2, c21
dp4 r1.y, r2, c20
dp4 r1.x, r2, c19
add r2.xyz, r3, r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.w, c10.z
mad r1, c2, r2.w, r1
mul r0.z, r4.y, r4.y
mad r0.z, r3.w, r3.w, -r0
mul r3.xyz, r0.z, c22
add oT2.xyz, r2, r3
mov r2.w, c10
mad r1, c3, r2.w, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
mad r1.xy, v0.zyzw, c25, c25.zwzw
mov r0.x, c26
mov r0.y, c27.x
mad r0.xy, r0, c12.y, r1
mov r3.z, r0.x
mov oT4.w, r0.y
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov r3.x, r4.y
mov r3.y, r4.x
mov oT3, r3.wxyz
add oT4.xyz, -r0, c13
mov oT5.xyz, r0
mad oT0.xy, v2, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"!!ARBvp1.0
PARAM c[28] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..27] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[12].y;
MUL R5, R3, c[11].y;
MOV R1, c[3];
MAD R0, R2, c[12].x, R0;
MAD R4, R1, c[12].z, R0;
MOV R0, c[4];
MAD R4, R0, c[12].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[9].y;
MAD R4, R2, c[9].x, R4;
MAD R5, R2, c[11].x, R5;
MUL R3, R3, c[10].y;
MAD R2, R2, c[10].x, R3;
MAD R3, R1, c[9].z, R4;
MAD R2, R1, c[10].z, R2;
MAD R3, R0, c[9].w, R3;
MAD R2, R0, c[10].w, R2;
MAD R1, R1, c[11].z, R5;
MAD R0, R0, c[11].w, R1;
DP4 R6.z, vertex.position, R0;
DP4 R6.x, vertex.position, R3;
DP4 R6.y, vertex.position, R2;
MUL R0.xyz, vertex.normal, c[23].w;
DP3 R2.w, R0, c[6];
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R3.x, R0, c[5];
DP3 R3.z, R0, c[7];
MUL R2.y, R2, c[15].x;
MOV R1.x, R3;
MOV R1.y, R2.w;
MOV R1.z, R3;
MUL R0, R1.xyzz, R1.yzzx;
MOV R1.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.y, R1, c[17];
DP4 R2.x, R1, c[16];
DP4 R2.z, R1, c[18];
DP4 R1.z, R0, c[21];
DP4 R1.y, R0, c[20];
DP4 R1.x, R0, c[19];
ADD R1.xyz, R2, R1;
MUL R1.w, R2, R2;
MAD R0.x, R3, R3, -R1.w;
MUL R0.xyz, R0.x, c[22];
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD R4.xy, vertex.position.zyzw, c[25], c[25].zwzw;
MOV R2.x, c[26];
MOV R2.y, c[27].x;
MAD R2.xy, R2, c[13].y, R4;
MOV R3.w, R2.x;
MOV R3.y, R2.w;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3], R3;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[14];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 63 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"vs_2_0
def c28, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.x, v0, r2
mul r2.xyz, v1, c23.w
dp4 r0.y, v0, r1
mul r1.xyz, r0.xyww, c28.x
mul r1.y, r1, c14.x
dp3 r3.w, r2, c4
mad oT1.xy, r1.z, c15.zwzw, r1
dp3 r4.y, r2, c5
dp3 r4.x, r2, c6
mov r1.x, r3.w
mov r1.y, r4
mov r1.z, r4.x
mov r1.w, c28.y
mul r2, r1.xyzz, r1.yzzx
dp4 r3.z, r1, c18
dp4 r3.y, r1, c17
dp4 r3.x, r1, c16
dp4 r1.z, r2, c21
dp4 r1.y, r2, c20
dp4 r1.x, r2, c19
add r2.xyz, r3, r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.w, c10.z
mad r1, c2, r2.w, r1
mul r0.z, r4.y, r4.y
mad r0.z, r3.w, r3.w, -r0
mul r3.xyz, r0.z, c22
add oT2.xyz, r2, r3
mov r2.w, c10
mad r1, c3, r2.w, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
mad r1.xy, v0.zyzw, c25, c25.zwzw
mov r0.x, c26
mov r0.y, c27.x
mad r0.xy, r0, c12.y, r1
mov r3.z, r0.x
mov oT4.w, r0.y
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov r3.x, r4.y
mov r3.y, r4.x
mov oT3, r3.wxyz
add oT4.xyz, -r0, c13
mov oT5.xyz, r0
mad oT0.xy, v2, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"!!ARBvp1.0
PARAM c[28] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..27] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[12].y;
MUL R5, R3, c[11].y;
MOV R1, c[3];
MAD R0, R2, c[12].x, R0;
MAD R4, R1, c[12].z, R0;
MOV R0, c[4];
MAD R4, R0, c[12].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[9].y;
MAD R4, R2, c[9].x, R4;
MAD R5, R2, c[11].x, R5;
MUL R3, R3, c[10].y;
MAD R2, R2, c[10].x, R3;
MAD R3, R1, c[9].z, R4;
MAD R2, R1, c[10].z, R2;
MAD R3, R0, c[9].w, R3;
MAD R2, R0, c[10].w, R2;
MAD R1, R1, c[11].z, R5;
MAD R0, R0, c[11].w, R1;
DP4 R6.z, vertex.position, R0;
DP4 R6.x, vertex.position, R3;
DP4 R6.y, vertex.position, R2;
MUL R0.xyz, vertex.normal, c[23].w;
DP3 R2.w, R0, c[6];
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R3.x, R0, c[5];
DP3 R3.z, R0, c[7];
MUL R2.y, R2, c[15].x;
MOV R1.x, R3;
MOV R1.y, R2.w;
MOV R1.z, R3;
MUL R0, R1.xyzz, R1.yzzx;
MOV R1.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.y, R1, c[17];
DP4 R2.x, R1, c[16];
DP4 R2.z, R1, c[18];
DP4 R1.z, R0, c[21];
DP4 R1.y, R0, c[20];
DP4 R1.x, R0, c[19];
ADD R1.xyz, R2, R1;
MUL R1.w, R2, R2;
MAD R0.x, R3, R3, -R1.w;
MUL R0.xyz, R0.x, c[22];
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD R4.xy, vertex.position.zyzw, c[25], c[25].zwzw;
MOV R2.x, c[26];
MOV R2.y, c[27].x;
MAD R2.xy, R2, c[13].y, R4;
MOV R3.w, R2.x;
MOV R3.y, R2.w;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3], R3;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[14];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 63 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"vs_2_0
def c28, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.x, v0, r2
mul r2.xyz, v1, c23.w
dp4 r0.y, v0, r1
mul r1.xyz, r0.xyww, c28.x
mul r1.y, r1, c14.x
dp3 r3.w, r2, c4
mad oT1.xy, r1.z, c15.zwzw, r1
dp3 r4.y, r2, c5
dp3 r4.x, r2, c6
mov r1.x, r3.w
mov r1.y, r4
mov r1.z, r4.x
mov r1.w, c28.y
mul r2, r1.xyzz, r1.yzzx
dp4 r3.z, r1, c18
dp4 r3.y, r1, c17
dp4 r3.x, r1, c16
dp4 r1.z, r2, c21
dp4 r1.y, r2, c20
dp4 r1.x, r2, c19
add r2.xyz, r3, r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.w, c10.z
mad r1, c2, r2.w, r1
mul r0.z, r4.y, r4.y
mad r0.z, r3.w, r3.w, -r0
mul r3.xyz, r0.z, c22
add oT2.xyz, r2, r3
mov r2.w, c10
mad r1, c3, r2.w, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
mad r1.xy, v0.zyzw, c25, c25.zwzw
mov r0.x, c26
mov r0.y, c27.x
mad r0.xy, r0, c12.y, r1
mov r3.z, r0.x
mov oT4.w, r0.y
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov r3.x, r4.y
mov r3.y, r4.x
mov oT3, r3.wxyz
add oT4.xyz, -r0, c13
mov oT5.xyz, r0
mad oT0.xy, v2, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"!!ARBvp1.0
PARAM c[28] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..27] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[12].y;
MUL R5, R3, c[11].y;
MOV R1, c[3];
MAD R0, R2, c[12].x, R0;
MAD R4, R1, c[12].z, R0;
MOV R0, c[4];
MAD R4, R0, c[12].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[9].y;
MAD R4, R2, c[9].x, R4;
MAD R5, R2, c[11].x, R5;
MUL R3, R3, c[10].y;
MAD R2, R2, c[10].x, R3;
MAD R3, R1, c[9].z, R4;
MAD R2, R1, c[10].z, R2;
MAD R3, R0, c[9].w, R3;
MAD R2, R0, c[10].w, R2;
MAD R1, R1, c[11].z, R5;
MAD R0, R0, c[11].w, R1;
DP4 R6.z, vertex.position, R0;
DP4 R6.x, vertex.position, R3;
DP4 R6.y, vertex.position, R2;
MUL R0.xyz, vertex.normal, c[23].w;
DP3 R2.w, R0, c[6];
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R3.x, R0, c[5];
DP3 R3.z, R0, c[7];
MUL R2.y, R2, c[15].x;
MOV R1.x, R3;
MOV R1.y, R2.w;
MOV R1.z, R3;
MUL R0, R1.xyzz, R1.yzzx;
MOV R1.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.y, R1, c[17];
DP4 R2.x, R1, c[16];
DP4 R2.z, R1, c[18];
DP4 R1.z, R0, c[21];
DP4 R1.y, R0, c[20];
DP4 R1.x, R0, c[19];
ADD R1.xyz, R2, R1;
MUL R1.w, R2, R2;
MAD R0.x, R3, R3, -R1.w;
MUL R0.xyz, R0.x, c[22];
ADD result.texcoord[2].xyz, R1, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD R4.xy, vertex.position.zyzw, c[25], c[25].zwzw;
MOV R2.x, c[26];
MOV R2.y, c[27].x;
MAD R2.xy, R2, c[13].y, R4;
MOV R3.w, R2.x;
MOV R3.y, R2.w;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MOV result.texcoord[3], R3;
MOV result.texcoord[4].w, R2.y;
ADD result.texcoord[4].xyz, -R0, c[14];
MOV result.texcoord[5].xyz, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 63 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
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
Vector 25 [_RespawnTexture_ST]
Float 26 [_RespawnSpeedU]
Float 27 [_RespawnSpeedV]
"vs_2_0
def c28, 0.50000000, 1.00000000, 0, 0
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
dp4 r0.x, v0, r2
mul r2.xyz, v1, c23.w
dp4 r0.y, v0, r1
mul r1.xyz, r0.xyww, c28.x
mul r1.y, r1, c14.x
dp3 r3.w, r2, c4
mad oT1.xy, r1.z, c15.zwzw, r1
dp3 r4.y, r2, c5
dp3 r4.x, r2, c6
mov r1.x, r3.w
mov r1.y, r4
mov r1.z, r4.x
mov r1.w, c28.y
mul r2, r1.xyzz, r1.yzzx
dp4 r3.z, r1, c18
dp4 r3.y, r1, c17
dp4 r3.x, r1, c16
dp4 r1.z, r2, c21
dp4 r1.y, r2, c20
dp4 r1.x, r2, c19
add r2.xyz, r3, r1
mov r0.z, c10.y
mul r1, c1, r0.z
mov r0.z, c10.x
mad r1, c0, r0.z, r1
mov r2.w, c10.z
mad r1, c2, r2.w, r1
mul r0.z, r4.y, r4.y
mad r0.z, r3.w, r3.w, -r0
mul r3.xyz, r0.z, c22
add oT2.xyz, r2, r3
mov r2.w, c10
mad r1, c3, r2.w, r1
dp4 r0.z, v0, r1
mov oPos, r0
mov oT1.zw, r0
dp4 r0.z, v0, c6
mad r1.xy, v0.zyzw, c25, c25.zwzw
mov r0.x, c26
mov r0.y, c27.x
mad r0.xy, r0, c12.y, r1
mov r3.z, r0.x
mov oT4.w, r0.y
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov r3.x, r4.y
mov r3.y, r4.x
mov oT3, r3.wxyz
add oT4.xyz, -r0, c13
mov oT5.xyz, r0
mad oT0.xy, v2, c24, c24.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 1 } };
TEMP R0;
TEMP R1;
TXP R1.xyz, fragment.texcoord[1], texture[1], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
MOV R0.w, c[3].x;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1;
ADD R0.w, R0, -c[1].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[1];
MAD result.color.xyz, R0.x, c[2], R1;
MOV result.color.w, c[3].x;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
texldp r0, t1, s1
texld r1, t0, s0
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r2.xyz, -r0, t2
mov r0.x, c1
mul r1.xyz, r1, c0
add r0.x, c3, -r0
mul_pp r1.xyz, r1, r2
mul r1.xyz, r1, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r1
mov_pp r0.w, c3.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 1 } };
TEMP R0;
TEMP R1;
TXP R1.xyz, fragment.texcoord[1], texture[1], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
MOV R0.w, c[3].x;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1;
ADD R0.w, R0, -c[1].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[1];
MAD result.color.xyz, R0.x, c[2], R1;
MOV result.color.w, c[3].x;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
texldp r0, t1, s1
texld r1, t0, s0
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r2.xyz, -r0, t2
mov r0.x, c1
mul r1.xyz, r1, c0
add r0.x, c3, -r0
mul_pp r1.xyz, r1, r2
mul r1.xyz, r1, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r1
mov_pp r0.w, c3.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 1 } };
TEMP R0;
TEMP R1;
TXP R1.xyz, fragment.texcoord[1], texture[1], 2D;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
MOV R0.w, c[3].x;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1;
ADD R0.w, R0, -c[1].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[1];
MAD result.color.xyz, R0.x, c[2], R1;
MOV result.color.w, c[3].x;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
texldp r0, t1, s1
texld r1, t0, s0
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r2.xyz, -r0, t2
mov r0.x, c1
mul r1.xyz, r1, c0
add r0.x, c3, -r0
mul_pp r1.xyz, r1, r2
mul r1.xyz, r1, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r1
mov_pp r0.w, c3.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 1 } };
TEMP R0;
TEMP R1;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TXP R1.xyz, fragment.texcoord[1], texture[1], 2D;
MOV R0.w, c[3].x;
ADD R1.xyz, R1, fragment.texcoord[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1;
ADD R0.w, R0, -c[1].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[1];
MAD result.color.xyz, R0.x, c[2], R1;
MOV result.color.w, c[3].x;
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
texld r0, t0, s0
texldp r2, t1, s1
mul r1.xyz, r0, c0
mov r0.x, c1
add_pp r2.xyz, r2, t2
add r0.x, c3, -r0
mul_pp r1.xyz, r1, r2
mul r1.xyz, r1, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r1
mov_pp r0.w, c3.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 1 } };
TEMP R0;
TEMP R1;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TXP R1.xyz, fragment.texcoord[1], texture[1], 2D;
MOV R0.w, c[3].x;
ADD R1.xyz, R1, fragment.texcoord[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1;
ADD R0.w, R0, -c[1].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[1];
MAD result.color.xyz, R0.x, c[2], R1;
MOV result.color.w, c[3].x;
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
texld r0, t0, s0
texldp r2, t1, s1
mul r1.xyz, r0, c0
mov r0.x, c1
add_pp r2.xyz, r2, t2
add r0.x, c3, -r0
mul_pp r1.xyz, r1, r2
mul r1.xyz, r1, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r1
mov_pp r0.w, c3.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 1 } };
TEMP R0;
TEMP R1;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
TXP R1.xyz, fragment.texcoord[1], texture[1], 2D;
MOV R0.w, c[3].x;
ADD R1.xyz, R1, fragment.texcoord[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1;
ADD R0.w, R0, -c[1].x;
MUL R1.xyz, R0, R0.w;
MOV R0.x, c[1];
MAD result.color.xyz, R0.x, c[2], R1;
MOV result.color.w, c[3].x;
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_OFF" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
texld r0, t0, s0
texldp r2, t1, s1
mul r1.xyz, r0, c0
mov r0.x, c1
add_pp r2.xyz, r2, t2
add r0.x, c3, -r0
mul_pp r1.xyz, r1, r2
mul r1.xyz, r1, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r1
mov_pp r0.w, c3.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R2.xyz, fragment.texcoord[1], texture[1], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
MOV R1.w, c[4].x;
ADD R1.w, R1, -c[1].x;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[3].w;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[2];
MUL R1.xyz, R1, c[0];
MUL R1.xyz, R1, R2;
MUL R1.xyz, R1, R1.w;
MOV R1.w, c[1].x;
MAD R1.xyz, R1.w, c[2], R1;
MOV result.color.w, c[4].x;
TEX R0, R0, texture[2], 2D;
MUL R0.xyz, R0, c[3].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
END
# 20 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
dcl t3.xyzw
dcl t4.xyzw
texld r2, t0, s0
mov r0.y, t4.w
mov r0.x, t3.w
mul r2.xyz, r2, c0
texld r1, r0, s2
texldp r0, t1, s1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, t2
mov r0.x, c1
add r0.x, c4, -r0
mul_pp r2.xyz, r2, r3
mul r2.xyz, r2, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r2
mul r1.xyz, r1, c3.x
add_pp r1.xyz, r1, -r0
mov_pp r0.w, c4.x
mad_pp r0.xyz, r1.w, r1, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R2.xyz, fragment.texcoord[1], texture[1], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
MOV R1.w, c[4].x;
ADD R1.w, R1, -c[1].x;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[3].w;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[2];
MUL R1.xyz, R1, c[0];
MUL R1.xyz, R1, R2;
MUL R1.xyz, R1, R1.w;
MOV R1.w, c[1].x;
MAD R1.xyz, R1.w, c[2], R1;
MOV result.color.w, c[4].x;
TEX R0, R0, texture[2], 2D;
MUL R0.xyz, R0, c[3].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
END
# 20 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
dcl t3.xyzw
dcl t4.xyzw
texld r2, t0, s0
mov r0.y, t4.w
mov r0.x, t3.w
mul r2.xyz, r2, c0
texld r1, r0, s2
texldp r0, t1, s1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, t2
mov r0.x, c1
add r0.x, c4, -r0
mul_pp r2.xyz, r2, r3
mul r2.xyz, r2, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r2
mul r1.xyz, r1, c3.x
add_pp r1.xyz, r1, -r0
mov_pp r0.w, c4.x
mad_pp r0.xyz, r1.w, r1, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R2.xyz, fragment.texcoord[1], texture[1], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
MOV R1.w, c[4].x;
ADD R1.w, R1, -c[1].x;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[3].w;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
ADD R2.xyz, -R2, fragment.texcoord[2];
MUL R1.xyz, R1, c[0];
MUL R1.xyz, R1, R2;
MUL R1.xyz, R1, R1.w;
MOV R1.w, c[1].x;
MAD R1.xyz, R1.w, c[2], R1;
MOV result.color.w, c[4].x;
TEX R0, R0, texture[2], 2D;
MUL R0.xyz, R0, c[3].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
END
# 20 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
dcl t3.xyzw
dcl t4.xyzw
texld r2, t0, s0
mov r0.y, t4.w
mov r0.x, t3.w
mul r2.xyz, r2, c0
texld r1, r0, s2
texldp r0, t1, s1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, t2
mov r0.x, c1
add r0.x, c4, -r0
mul_pp r2.xyz, r2, r3
mul r2.xyz, r2, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r2
mul r1.xyz, r1, c3.x
add_pp r1.xyz, r1, -r0
mov_pp r0.w, c4.x
mad_pp r0.xyz, r1.w, r1, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
TXP R2.xyz, fragment.texcoord[1], texture[1], 2D;
MOV R1.w, c[4].x;
ADD R1.w, R1, -c[1].x;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[3].w;
MUL R1.xyz, R1, c[0];
ADD R2.xyz, R2, fragment.texcoord[2];
MUL R1.xyz, R1, R2;
MUL R1.xyz, R1, R1.w;
MOV R1.w, c[1].x;
MAD R1.xyz, R1.w, c[2], R1;
MOV result.color.w, c[4].x;
TEX R0, R0, texture[2], 2D;
MUL R0.xyz, R0, c[3].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
END
# 17 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
dcl t3.xyzw
dcl t4.xyzw
texldp r2, t1, s1
mov r0.y, t4.w
mov r0.x, t3.w
add_pp r2.xyz, r2, t2
texld r1, r0, s2
texld r0, t0, s0
mul r3.xyz, r0, c0
mov r0.x, c1
add r0.x, c4, -r0
mul_pp r2.xyz, r3, r2
mul r2.xyz, r2, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r2
mul r1.xyz, r1, c3.x
add_pp r1.xyz, r1, -r0
mov_pp r0.w, c4.x
mad_pp r0.xyz, r1.w, r1, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
TXP R2.xyz, fragment.texcoord[1], texture[1], 2D;
MOV R1.w, c[4].x;
ADD R1.w, R1, -c[1].x;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[3].w;
MUL R1.xyz, R1, c[0];
ADD R2.xyz, R2, fragment.texcoord[2];
MUL R1.xyz, R1, R2;
MUL R1.xyz, R1, R1.w;
MOV R1.w, c[1].x;
MAD R1.xyz, R1.w, c[2], R1;
MOV result.color.w, c[4].x;
TEX R0, R0, texture[2], 2D;
MUL R0.xyz, R0, c[3].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
END
# 17 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
dcl t3.xyzw
dcl t4.xyzw
texldp r2, t1, s1
mov r0.y, t4.w
mov r0.x, t3.w
add_pp r2.xyz, r2, t2
texld r1, r0, s2
texld r0, t0, s0
mul r3.xyz, r0, c0
mov r0.x, c1
add r0.x, c4, -r0
mul_pp r2.xyz, r3, r2
mul r2.xyz, r2, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r2
mul r1.xyz, r1, c3.x
add_pp r1.xyz, r1, -r0
mov_pp r0.w, c4.x
mad_pp r0.xyz, r1.w, r1, r0
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
TXP R2.xyz, fragment.texcoord[1], texture[1], 2D;
MOV R1.w, c[4].x;
ADD R1.w, R1, -c[1].x;
MOV R0.y, fragment.texcoord[4].w;
MOV R0.x, fragment.texcoord[3].w;
MUL R1.xyz, R1, c[0];
ADD R2.xyz, R2, fragment.texcoord[2];
MUL R1.xyz, R1, R2;
MUL R1.xyz, R1, R1.w;
MOV R1.w, c[1].x;
MAD R1.xyz, R1.w, c[2], R1;
MOV result.color.w, c[4].x;
TEX R0, R0, texture[2], 2D;
MUL R0.xyz, R0, c[3].x;
ADD R0.xyz, R0, -R1;
MAD result.color.xyz, R0.w, R0, R1;
END
# 17 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "RESPAWN_ON" }
Vector 0 [_Color]
Float 1 [_Effect_Para]
Vector 2 [_Effect_Color]
Float 3 [_RespawnStrength]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightBuffer] 2D 1
SetTexture 2 [_RespawnTexture] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 1.00000000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2.xyz
dcl t3.xyzw
dcl t4.xyzw
texldp r2, t1, s1
mov r0.y, t4.w
mov r0.x, t3.w
add_pp r2.xyz, r2, t2
texld r1, r0, s2
texld r0, t0, s0
mul r3.xyz, r0, c0
mov r0.x, c1
add r0.x, c4, -r0
mul_pp r2.xyz, r3, r2
mul r2.xyz, r2, r0.x
mov r0.xyz, c2
mad r0.xyz, c1.x, r0, r2
mul r1.xyz, r1, c3.x
add_pp r1.xyz, r1, -r0
mov_pp r0.w, c4.x
mad_pp r0.xyz, r1.w, r1, r0
mov_pp oC0, r0
"
}
}
 }
}
Fallback "VertexLit"
}