¢ûShader "BOL/Character/Stealth" {
Properties {
 _Color ("Main Color", Color) = (0.59,0.59,0.59,0)
 _IllumnColor ("Emissive Color (Mask R)", Color) = (0,0,0,0)
 _MetalColor ("Variant Color (Mask G)", Color) = (0.59,0.59,0.59,0)
 _SkinColor ("Variant Color (Mask B)", Color) = (0.59,0.59,0.59,0)
 _ReflectColor ("Reflect Color (Mask A)", Color) = (0.59,0.59,0.59,0)
 _MainTex ("Diffuse Map", 2D) = "white" {}
 _MaskTex ("Mask (RGB)", 2D) = "black" {}
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _OutlineColor ("Outline Color", Color) = (1,1,1,0)
 _OutlineWidth ("Outline Width", Range(0,1)) = 0.8
 _NoiseTex ("Normal Texture (RGB)", 2D) = "white" {}
 _Strength ("Strength", Float) = 10
}
SubShader { 
 Tags { "QUEUE"="Transparent+10" }
 GrabPass {
  Name "BASE"
  Tags { "LIGHTMODE"="FORWARDBASE" }
 }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="FORWARDBASE" "SHADOWSUPPORT"="true" "QUEUE"="Transparent+10" }
  Cull Off
  AlphaTest Greater 0
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[18].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R4.x, R0, c[5];
MOV R4.y, R3.w;
MOV R4.z, R2.w;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R1.z, R4, c[13];
DP4 R1.y, R4, c[12];
DP4 R1.x, R4, c[11];
DP4 R4.y, vertex.position, c[2];
DP4 R2.z, R0, c[16];
DP4 R2.y, R0, c[15];
DP4 R2.x, R0, c[14];
ADD R3.xyz, R1, R2;
DP4 R0.w, vertex.position, c[4];
DP4 R4.z, vertex.position, c[1];
MUL R0.x, R3.w, R3.w;
MAD R0.x, R4, R4, -R0;
MUL R2.xyz, R0.x, c[17];
MOV R1.w, R0;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R4.z;
MOV R1.y, R4;
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV R4.w, R4.y;
ADD R1.xy, R0.w, R4.zwzw;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, R3, R2;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[5].zw, R1;
MOV result.texcoord[3].z, R2.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R4;
ADD result.texcoord[4].xyz, -R0, c[9];
MUL result.texcoord[5].xy, R1, c[0].x;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
END
# 44 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c18.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r4.x, r0, c4
mov r4.y, r3.w
mov r4.z, r2.w
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c21.y
dp4 r1.z, r4, c13
dp4 r1.y, r4, c12
dp4 r1.x, r4, c11
dp4 r4.y, v0, c1
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
add r3.xyz, r1, r2
dp4 r0.w, v0, c3
dp4 r4.z, v0, c0
mul r0.x, r3.w, r3.w
mad r0.x, r4, r4, -r0
mul r2.xyz, r0.x, c17
mov r1.w, r0
dp4 r1.z, v0, c2
mov r1.x, r4.z
mov r1.y, r4
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c9.x
mad o2.xy, r0.z, c10.zwzw, r0
mov o0, r1
mov r4.w, -r4.y
add r1.xy, r0.w, r4.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o3.xyz, r3, r2
mov o2.zw, r1
mov o6.zw, r1
mov o4.z, r2.w
mov o4.y, r3.w
mov o4.x, r4
add o5.xyz, -r0, c8
mul o6.xy, r1, c21.x
mad o1.zw, v2.xyxy, c20.xyxy, c20
mad o1.xy, v2, c19, c19.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
PARAM c[11] = { program.local[0..8],
		{ 1, 16, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R2.xyz, R0.z, R1, c[1];
ADD R1.xyz, -R2, c[3];
MAD R1.xyz, R0.y, R1, R2;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
MUL R0.y, R0.w, c[5].x;
MUL R1.xyz, R2, R1;
MUL R2.xyz, R1, R0.y;
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xyz, R1, fragment.texcoord[2], R2;
RSQ R0.z, R0.z;
MUL R2.xyz, R0.z, fragment.texcoord[4];
RSQ R0.y, R0.y;
MUL R0.yzw, R0.y, fragment.texcoord[3].xxyz;
DP3_SAT R0.w, R2, R0.yzww;
RCP R1.w, c[7].x;
MUL R1.w, R0, R1;
MUL R0.x, R0, c[2].w;
MUL R0.xyz, R0.x, c[2];
MAD R0.xyz, R0, c[9].y, R1;
ADD R2.x, -R1.w, c[9];
MUL R1.xyz, R2.x, c[6];
TEX R2.yw, fragment.texcoord[0], texture[4], 2D;
MAD R2.xy, R2.wyzw, c[9].z, -c[9].x;
MAD R1.xyz, R0, R1.w, R1;
ADD R0.w, R0, -c[7].x;
CMP R0.xyz, R0.w, R1, R0;
MUL R2.xy, R2, c[0].x;
MUL R1.xy, R2, c[8];
MOV R1.z, fragment.texcoord[5].w;
MAD R1.xy, R1, fragment.texcoord[5].z, fragment.texcoord[5];
TXP R1.xyz, R1.xyzz, texture[0], 2D;
DP3 R0.x, R0, c[10];
ADD result.color.xyz, R0.x, R1;
MOV result.color.w, c[9].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"ps_3_0
dcl_2d s1
dcl_2d s2
dcl_2d s4
dcl_2d s0
def c9, 16.00000000, 1.00000000, 2.00000000, -1.00000000
def c10, 0.21997070, 0.70703125, 0.07098389, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord3 v2.xyz
dcl_texcoord4 v3.xyz
dcl_texcoord5 v4
mov_pp r0.xyz, c4
add_pp r1.xyz, -c1, r0
texld r0, v0, s2
mad_pp r2.xyz, r0.z, r1, c1
add_pp r1.xyz, -r2, c3
mad_pp r1.xyz, r0.y, r1, r2
texld r2.xyz, v0, s1
dp3 r0.z, v3, v3
mul r0.y, r0.w, c5.x
mul r1.xyz, r2, r1
mul r2.xyz, r1, r0.y
dp3 r0.y, v2, v2
mad r1.xyz, r1, v1, r2
rsq r0.z, r0.z
mul r2.xyz, r0.z, v3
rsq r0.y, r0.y
mul r0.yzw, r0.y, v2.xxyz
dp3_sat r0.w, r2, r0.yzww
rcp r1.w, c7.x
mul r1.w, r0, r1
mul r0.x, r0, c2.w
mul r0.xyz, r0.x, c2
mad r0.xyz, r0, c9.x, r1
add r2.x, -r1.w, c9.y
mul r1.xyz, r2.x, c6
texld r2.yw, v0, s4
mad_pp r2.xy, r2.wyzw, c9.z, c9.w
mad r1.xyz, r0, r1.w, r1
add r0.w, r0, -c7.x
cmp_pp r0.xyz, r0.w, r0, r1
mul r2.xy, r2, c0.x
mul r1.xy, r2, c8
mov r1.zw, v4
mad r1.xy, r1, v4.z, v4
texldp r1.xyz, r1, s0
dp3_pp r0.x, r0, c10
add_pp oC0.xyz, r0.x, r1
mov_pp oC0.w, c9.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
PARAM c[11] = { program.local[0..8],
		{ 1, 16, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R2.xyz, R0.z, R1, c[1];
ADD R1.xyz, -R2, c[3];
MAD R1.xyz, R0.y, R1, R2;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
MUL R0.y, R0.w, c[5].x;
MUL R1.xyz, R2, R1;
MUL R2.xyz, R1, R0.y;
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xyz, R1, fragment.texcoord[2], R2;
RSQ R0.z, R0.z;
MUL R2.xyz, R0.z, fragment.texcoord[4];
RSQ R0.y, R0.y;
MUL R0.yzw, R0.y, fragment.texcoord[3].xxyz;
DP3_SAT R0.w, R2, R0.yzww;
RCP R1.w, c[7].x;
MUL R1.w, R0, R1;
MUL R0.x, R0, c[2].w;
MUL R0.xyz, R0.x, c[2];
MAD R0.xyz, R0, c[9].y, R1;
ADD R2.x, -R1.w, c[9];
MUL R1.xyz, R2.x, c[6];
TEX R2.yw, fragment.texcoord[0], texture[4], 2D;
MAD R2.xy, R2.wyzw, c[9].z, -c[9].x;
MAD R1.xyz, R0, R1.w, R1;
ADD R0.w, R0, -c[7].x;
CMP R0.xyz, R0.w, R1, R0;
MUL R2.xy, R2, c[0].x;
MUL R1.xy, R2, c[8];
MOV R1.z, fragment.texcoord[5].w;
MAD R1.xy, R1, fragment.texcoord[5].z, fragment.texcoord[5];
TXP R1.xyz, R1.xyzz, texture[0], 2D;
DP3 R0.x, R0, c[10];
ADD result.color.xyz, R0.x, R1;
MOV result.color.w, c[9].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"ps_3_0
dcl_2d s1
dcl_2d s2
dcl_2d s4
dcl_2d s0
def c9, 16.00000000, 1.00000000, 2.00000000, -1.00000000
def c10, 0.21997070, 0.70703125, 0.07098389, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord3 v2.xyz
dcl_texcoord4 v3.xyz
dcl_texcoord5 v4
mov_pp r0.xyz, c4
add_pp r1.xyz, -c1, r0
texld r0, v0, s2
mad_pp r2.xyz, r0.z, r1, c1
add_pp r1.xyz, -r2, c3
mad_pp r1.xyz, r0.y, r1, r2
texld r2.xyz, v0, s1
dp3 r0.z, v3, v3
mul r0.y, r0.w, c5.x
mul r1.xyz, r2, r1
mul r2.xyz, r1, r0.y
dp3 r0.y, v2, v2
mad r1.xyz, r1, v1, r2
rsq r0.z, r0.z
mul r2.xyz, r0.z, v3
rsq r0.y, r0.y
mul r0.yzw, r0.y, v2.xxyz
dp3_sat r0.w, r2, r0.yzww
rcp r1.w, c7.x
mul r1.w, r0, r1
mul r0.x, r0, c2.w
mul r0.xyz, r0.x, c2
mad r0.xyz, r0, c9.x, r1
add r2.x, -r1.w, c9.y
mul r1.xyz, r2.x, c6
texld r2.yw, v0, s4
mad_pp r2.xy, r2.wyzw, c9.z, c9.w
mad r1.xyz, r0, r1.w, r1
add r0.w, r0, -c7.x
cmp_pp r0.xyz, r0.w, r0, r1
mul r2.xy, r2, c0.x
mul r1.xy, r2, c8
mov r1.zw, v4
mad r1.xy, r1, v4.z, v4
texldp r1.xyz, r1, s0
dp3_pp r0.x, r0, c10
add_pp oC0.xyz, r0.x, r1
mov_pp oC0.w, c9.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
PARAM c[11] = { program.local[0..8],
		{ 1, 16, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R2.xyz, R0.z, R1, c[1];
ADD R1.xyz, -R2, c[3];
MAD R1.xyz, R0.y, R1, R2;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
MUL R0.y, R0.w, c[5].x;
MUL R1.xyz, R2, R1;
MUL R2.xyz, R1, R0.y;
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xyz, R1, fragment.texcoord[2], R2;
RSQ R0.z, R0.z;
MUL R2.xyz, R0.z, fragment.texcoord[4];
RSQ R0.y, R0.y;
MUL R0.yzw, R0.y, fragment.texcoord[3].xxyz;
DP3_SAT R0.w, R2, R0.yzww;
RCP R1.w, c[7].x;
MUL R1.w, R0, R1;
MUL R0.x, R0, c[2].w;
MUL R0.xyz, R0.x, c[2];
MAD R0.xyz, R0, c[9].y, R1;
ADD R2.x, -R1.w, c[9];
MUL R1.xyz, R2.x, c[6];
TEX R2.yw, fragment.texcoord[0], texture[4], 2D;
MAD R2.xy, R2.wyzw, c[9].z, -c[9].x;
MAD R1.xyz, R0, R1.w, R1;
ADD R0.w, R0, -c[7].x;
CMP R0.xyz, R0.w, R1, R0;
MUL R2.xy, R2, c[0].x;
MUL R1.xy, R2, c[8];
MOV R1.z, fragment.texcoord[5].w;
MAD R1.xy, R1, fragment.texcoord[5].z, fragment.texcoord[5];
TXP R1.xyz, R1.xyzz, texture[0], 2D;
DP3 R0.x, R0, c[10];
ADD result.color.xyz, R0.x, R1;
MOV result.color.w, c[9].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"ps_3_0
dcl_2d s1
dcl_2d s2
dcl_2d s4
dcl_2d s0
def c9, 16.00000000, 1.00000000, 2.00000000, -1.00000000
def c10, 0.21997070, 0.70703125, 0.07098389, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord3 v2.xyz
dcl_texcoord4 v3.xyz
dcl_texcoord5 v4
mov_pp r0.xyz, c4
add_pp r1.xyz, -c1, r0
texld r0, v0, s2
mad_pp r2.xyz, r0.z, r1, c1
add_pp r1.xyz, -r2, c3
mad_pp r1.xyz, r0.y, r1, r2
texld r2.xyz, v0, s1
dp3 r0.z, v3, v3
mul r0.y, r0.w, c5.x
mul r1.xyz, r2, r1
mul r2.xyz, r1, r0.y
dp3 r0.y, v2, v2
mad r1.xyz, r1, v1, r2
rsq r0.z, r0.z
mul r2.xyz, r0.z, v3
rsq r0.y, r0.y
mul r0.yzw, r0.y, v2.xxyz
dp3_sat r0.w, r2, r0.yzww
rcp r1.w, c7.x
mul r1.w, r0, r1
mul r0.x, r0, c2.w
mul r0.xyz, r0.x, c2
mad r0.xyz, r0, c9.x, r1
add r2.x, -r1.w, c9.y
mul r1.xyz, r2.x, c6
texld r2.yw, v0, s4
mad_pp r2.xy, r2.wyzw, c9.z, c9.w
mad r1.xyz, r0, r1.w, r1
add r0.w, r0, -c7.x
cmp_pp r0.xyz, r0.w, r0, r1
mul r2.xy, r2, c0.x
mul r1.xy, r2, c8
mov r1.zw, v4
mad r1.xy, r1, v4.z, v4
texldp r1.xyz, r1, s0
dp3_pp r0.x, r0, c10
add_pp oC0.xyz, r0.x, r1
mov_pp oC0.w, c9.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
PARAM c[11] = { program.local[0..8],
		{ 1, 16, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R2.xyz, R0.z, R1, c[1];
ADD R1.xyz, -R2, c[3];
MAD R1.xyz, R0.y, R1, R2;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
MUL R0.y, R0.w, c[5].x;
MUL R1.xyz, R2, R1;
MUL R2.xyz, R1, R0.y;
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xyz, R1, fragment.texcoord[2], R2;
RSQ R0.z, R0.z;
MUL R2.xyz, R0.z, fragment.texcoord[4];
RSQ R0.y, R0.y;
MUL R0.yzw, R0.y, fragment.texcoord[3].xxyz;
DP3_SAT R0.w, R2, R0.yzww;
RCP R1.w, c[7].x;
MUL R1.w, R0, R1;
MUL R0.x, R0, c[2].w;
MUL R0.xyz, R0.x, c[2];
MAD R0.xyz, R0, c[9].y, R1;
ADD R2.x, -R1.w, c[9];
MUL R1.xyz, R2.x, c[6];
TEX R2.yw, fragment.texcoord[0], texture[4], 2D;
MAD R2.xy, R2.wyzw, c[9].z, -c[9].x;
MAD R1.xyz, R0, R1.w, R1;
ADD R0.w, R0, -c[7].x;
CMP R0.xyz, R0.w, R1, R0;
MUL R2.xy, R2, c[0].x;
MUL R1.xy, R2, c[8];
MOV R1.z, fragment.texcoord[5].w;
MAD R1.xy, R1, fragment.texcoord[5].z, fragment.texcoord[5];
TXP R1.xyz, R1.xyzz, texture[0], 2D;
DP3 R0.x, R0, c[10];
ADD result.color.xyz, R0.x, R1;
MOV result.color.w, c[9].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"ps_3_0
dcl_2d s1
dcl_2d s2
dcl_2d s4
dcl_2d s0
def c9, 16.00000000, 1.00000000, 2.00000000, -1.00000000
def c10, 0.21997070, 0.70703125, 0.07098389, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord3 v2.xyz
dcl_texcoord4 v3.xyz
dcl_texcoord5 v4
mov_pp r0.xyz, c4
add_pp r1.xyz, -c1, r0
texld r0, v0, s2
mad_pp r2.xyz, r0.z, r1, c1
add_pp r1.xyz, -r2, c3
mad_pp r1.xyz, r0.y, r1, r2
texld r2.xyz, v0, s1
dp3 r0.z, v3, v3
mul r0.y, r0.w, c5.x
mul r1.xyz, r2, r1
mul r2.xyz, r1, r0.y
dp3 r0.y, v2, v2
mad r1.xyz, r1, v1, r2
rsq r0.z, r0.z
mul r2.xyz, r0.z, v3
rsq r0.y, r0.y
mul r0.yzw, r0.y, v2.xxyz
dp3_sat r0.w, r2, r0.yzww
rcp r1.w, c7.x
mul r1.w, r0, r1
mul r0.x, r0, c2.w
mul r0.xyz, r0.x, c2
mad r0.xyz, r0, c9.x, r1
add r2.x, -r1.w, c9.y
mul r1.xyz, r2.x, c6
texld r2.yw, v0, s4
mad_pp r2.xy, r2.wyzw, c9.z, c9.w
mad r1.xyz, r0, r1.w, r1
add r0.w, r0, -c7.x
cmp_pp r0.xyz, r0.w, r0, r1
mul r2.xy, r2, c0.x
mul r1.xy, r2, c8
mov r1.zw, v4
mad r1.xy, r1, v4.z, v4
texldp r1.xyz, r1, s0
dp3_pp r0.x, r0, c10
add_pp oC0.xyz, r0.x, r1
mov_pp oC0.w, c9.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
PARAM c[11] = { program.local[0..8],
		{ 1, 16, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R2.xyz, R0.z, R1, c[1];
ADD R1.xyz, -R2, c[3];
MAD R1.xyz, R0.y, R1, R2;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
MUL R0.y, R0.w, c[5].x;
MUL R1.xyz, R2, R1;
MUL R2.xyz, R1, R0.y;
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xyz, R1, fragment.texcoord[2], R2;
RSQ R0.z, R0.z;
MUL R2.xyz, R0.z, fragment.texcoord[4];
RSQ R0.y, R0.y;
MUL R0.yzw, R0.y, fragment.texcoord[3].xxyz;
DP3_SAT R0.w, R2, R0.yzww;
RCP R1.w, c[7].x;
MUL R1.w, R0, R1;
MUL R0.x, R0, c[2].w;
MUL R0.xyz, R0.x, c[2];
MAD R0.xyz, R0, c[9].y, R1;
ADD R2.x, -R1.w, c[9];
MUL R1.xyz, R2.x, c[6];
TEX R2.yw, fragment.texcoord[0], texture[4], 2D;
MAD R2.xy, R2.wyzw, c[9].z, -c[9].x;
MAD R1.xyz, R0, R1.w, R1;
ADD R0.w, R0, -c[7].x;
CMP R0.xyz, R0.w, R1, R0;
MUL R2.xy, R2, c[0].x;
MUL R1.xy, R2, c[8];
MOV R1.z, fragment.texcoord[5].w;
MAD R1.xy, R1, fragment.texcoord[5].z, fragment.texcoord[5];
TXP R1.xyz, R1.xyzz, texture[0], 2D;
DP3 R0.x, R0, c[10];
ADD result.color.xyz, R0.x, R1;
MOV result.color.w, c[9].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"ps_3_0
dcl_2d s1
dcl_2d s2
dcl_2d s4
dcl_2d s0
def c9, 16.00000000, 1.00000000, 2.00000000, -1.00000000
def c10, 0.21997070, 0.70703125, 0.07098389, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord3 v2.xyz
dcl_texcoord4 v3.xyz
dcl_texcoord5 v4
mov_pp r0.xyz, c4
add_pp r1.xyz, -c1, r0
texld r0, v0, s2
mad_pp r2.xyz, r0.z, r1, c1
add_pp r1.xyz, -r2, c3
mad_pp r1.xyz, r0.y, r1, r2
texld r2.xyz, v0, s1
dp3 r0.z, v3, v3
mul r0.y, r0.w, c5.x
mul r1.xyz, r2, r1
mul r2.xyz, r1, r0.y
dp3 r0.y, v2, v2
mad r1.xyz, r1, v1, r2
rsq r0.z, r0.z
mul r2.xyz, r0.z, v3
rsq r0.y, r0.y
mul r0.yzw, r0.y, v2.xxyz
dp3_sat r0.w, r2, r0.yzww
rcp r1.w, c7.x
mul r1.w, r0, r1
mul r0.x, r0, c2.w
mul r0.xyz, r0.x, c2
mad r0.xyz, r0, c9.x, r1
add r2.x, -r1.w, c9.y
mul r1.xyz, r2.x, c6
texld r2.yw, v0, s4
mad_pp r2.xy, r2.wyzw, c9.z, c9.w
mad r1.xyz, r0, r1.w, r1
add r0.w, r0, -c7.x
cmp_pp r0.xyz, r0.w, r0, r1
mul r2.xy, r2, c0.x
mul r1.xy, r2, c8
mov r1.zw, v4
mad r1.xy, r1, v4.z, v4
texldp r1.xyz, r1, s0
dp3_pp r0.x, r0, c10
add_pp oC0.xyz, r0.x, r1
mov_pp oC0.w, c9.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
PARAM c[11] = { program.local[0..8],
		{ 1, 16, 2 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R2.xyz, R0.z, R1, c[1];
ADD R1.xyz, -R2, c[3];
MAD R1.xyz, R0.y, R1, R2;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
MUL R0.y, R0.w, c[5].x;
MUL R1.xyz, R2, R1;
MUL R2.xyz, R1, R0.y;
DP3 R0.y, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xyz, R1, fragment.texcoord[2], R2;
RSQ R0.z, R0.z;
MUL R2.xyz, R0.z, fragment.texcoord[4];
RSQ R0.y, R0.y;
MUL R0.yzw, R0.y, fragment.texcoord[3].xxyz;
DP3_SAT R0.w, R2, R0.yzww;
RCP R1.w, c[7].x;
MUL R1.w, R0, R1;
MUL R0.x, R0, c[2].w;
MUL R0.xyz, R0.x, c[2];
MAD R0.xyz, R0, c[9].y, R1;
ADD R2.x, -R1.w, c[9];
MUL R1.xyz, R2.x, c[6];
TEX R2.yw, fragment.texcoord[0], texture[4], 2D;
MAD R2.xy, R2.wyzw, c[9].z, -c[9].x;
MAD R1.xyz, R0, R1.w, R1;
ADD R0.w, R0, -c[7].x;
CMP R0.xyz, R0.w, R1, R0;
MUL R2.xy, R2, c[0].x;
MUL R1.xy, R2, c[8];
MOV R1.z, fragment.texcoord[5].w;
MAD R1.xy, R1, fragment.texcoord[5].z, fragment.texcoord[5];
TXP R1.xyz, R1.xyzz, texture[0], 2D;
DP3 R0.x, R0, c[10];
ADD result.color.xyz, R0.x, R1;
MOV result.color.w, c[9].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_Strength]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Vector 6 [_OutlineColor]
Float 7 [_OutlineWidth]
Vector 8 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 4 [_NoiseTex] 2D 4
"ps_3_0
dcl_2d s1
dcl_2d s2
dcl_2d s4
dcl_2d s0
def c9, 16.00000000, 1.00000000, 2.00000000, -1.00000000
def c10, 0.21997070, 0.70703125, 0.07098389, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord3 v2.xyz
dcl_texcoord4 v3.xyz
dcl_texcoord5 v4
mov_pp r0.xyz, c4
add_pp r1.xyz, -c1, r0
texld r0, v0, s2
mad_pp r2.xyz, r0.z, r1, c1
add_pp r1.xyz, -r2, c3
mad_pp r1.xyz, r0.y, r1, r2
texld r2.xyz, v0, s1
dp3 r0.z, v3, v3
mul r0.y, r0.w, c5.x
mul r1.xyz, r2, r1
mul r2.xyz, r1, r0.y
dp3 r0.y, v2, v2
mad r1.xyz, r1, v1, r2
rsq r0.z, r0.z
mul r2.xyz, r0.z, v3
rsq r0.y, r0.y
mul r0.yzw, r0.y, v2.xxyz
dp3_sat r0.w, r2, r0.yzww
rcp r1.w, c7.x
mul r1.w, r0, r1
mul r0.x, r0, c2.w
mul r0.xyz, r0.x, c2
mad r0.xyz, r0, c9.x, r1
add r2.x, -r1.w, c9.y
mul r1.xyz, r2.x, c6
texld r2.yw, v0, s4
mad_pp r2.xy, r2.wyzw, c9.z, c9.w
mad r1.xyz, r0, r1.w, r1
add r0.w, r0, -c7.x
cmp_pp r0.xyz, r0.w, r0, r1
mul r2.xy, r2, c0.x
mul r1.xy, r2, c8
mov r1.zw, v4
mad r1.xy, r1, v4.z, v4
texldp r1.xyz, r1, s0
dp3_pp r0.x, r0, c10
add_pp oC0.xyz, r0.x, r1
mov_pp oC0.w, c9.y
"
}
}
 }
}
}