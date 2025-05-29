ô¹Shader "Custom/UIScanWeapon" {
Properties {
 _IllumnColor ("Emissive Color (Mask R)", Color) = (0.5,0.5,0.5,1)
 _MetalColor ("Metallic Color (Mask G)", Color) = (0.5,0.5,0.5,1)
 _MetalShininess ("Metallic Shininess (Mask G)", Range(0.03,1)) = 0.078125
 _SkinColor ("Skin Color (Mask B)", Color) = (1,1,1,1)
 _SkinShininess ("Skin Shininess (Mask B)", Range(0.03,1)) = 0.078125
 _ClothColor ("Cloth Color (Mask A)", Color) = (1,1,1,1)
 _ClothShininess ("Cloth Shininess (Mask A)", Range(0.03,1)) = 0.078125
 _Color ("Main Color", Color) = (1,1,1,1)
 _Shininess ("Main Shininess", Range(0.03,1)) = 0.078125
 _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
 _MaskTex ("Mask (RGB)", 2D) = "white" {}
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _Cube ("Reflection Cubemap", CUBE) = "" { TexGen CubeReflect }
 _EffectColor ("Effect Color", Color) = (0,1,0,1)
 _EffectColorWeight ("Effect Color Weight", Float) = 0
 _MoveTex ("Move Tex(RGB)", 2D) = "white" {}
 _MoveRedCol ("Move Red channel color", Color) = (0,1,1,1)
 _MoveGreenCol ("Move Green channel color", Color) = (0,1,1,1)
 _MoveSpeed ("Move Speed", Vector) = (-0.7,-2,0,0)
 _EmissivePara ("EmissivePara", Float) = 1
 _Plane ("Plane", Vector) = (0,0,1,0)
 _StartPoint ("Start Point", Vector) = (0,0,0,0)
 _EndPoint ("End Point", Vector) = (0,0,0,0)
 _NeedInvt ("Need Invert", Float) = 0
 _OffsetWidth ("Offset With", Float) = 0.05
 _TransitionColor ("Transition Color", Color) = (0,1,0,1)
}
SubShader { 
 Pass {
  Name "DIFFUSEMASKMUL"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="Transparent" "RenderType"="Transparent" }
  Blend SrcAlpha OneMinusSrcAlpha
  AlphaTest Greater 0
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_WorldSpaceLightPos0]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_StartPoint]
Vector 25 [_EndPoint]
Vector 26 [_Plane]
Vector 27 [_MainTex_ST]
Vector 28 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[18];
DP4 R2.y, R0, c[17];
DP4 R2.x, R0, c[16];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[21];
DP4 R0.y, R1, c[20];
DP4 R0.x, R1, c[19];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R0.w, c[22];
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.xyz, c[14];
MOV R1.w, c[0];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[23].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[15];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 result.texcoord[5].y, R2, R1;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
DP3 R0.y, R2, c[5];
DP3 R0.w, -R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[23].w;
DP3 R0.y, R2, c[6];
DP3 R0.w, -R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.y, R2, c[7];
DP3 R0.w, -R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[23].w;
DP4 R0.w, vertex.position, c[6];
MOV R0.xyz, c[24];
ADD R0.xyz, -R0, c[25];
DP3 R0.x, R0, R0;
MOV R1.y, R0.w;
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
ADD R1.xyz, R1, -c[24];
DP3 R1.x, R1, c[26];
RSQ R1.y, R0.x;
ADD R0.x, R0.w, -c[24].y;
MOV R0.w, c[13].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MUL R1.z, R0.w, c[28].y;
MUL R0.z, R1.y, R1.x;
MAD R0.x, R0.z, c[0], R1.z;
MUL R0.y, R0, c[0].x;
MUL R1.z, R0.w, c[28].x;
MOV R0.w, R0.y;
MAD R0.z, R0, c[0].x, R1;
DP3 result.texcoord[6].y, R2, R3;
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
MOV result.texcoord[0].zw, R0;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.color.y, R1.x;
RCP result.color.z, R1.y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
MOV result.color.x, c[26].w;
END
# 84 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_StartPoint]
Vector 24 [_EndPoint]
Vector 25 [_Plane]
Vector 26 [_MainTex_ST]
Vector 27 [_MoveSpeed]
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
dcl_color1 o9
def c28, 3.00000000, 2.00000000, 0.16666667, 1.00000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c28
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c28
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c22.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r1, c8
dp4 r4.x, c14, r1
mov r0, c10
dp4 r4.z, c14, r0
mov r0, c9
dp4 r4.y, c14, r0
dp3 r0.y, r2, c4
dp3 r0.w, -r3, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c22.w
dp3 r0.y, r2, c5
dp3 r0.w, -r3, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c22.w
dp3 r0.y, r2, c6
dp3 r0.w, -r3, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c22.w
dp4 r0.w, v0, c5
mov r0.xyz, c24
add r0.xyz, -c23, r0
dp3 r0.x, r0, r0
add r0.y, r0.w, -c23
mov r1.y, r0.w
add r0.y, r0, c28
mul r0.y, r0, c28.z
mov r0.w, c27.x
mul r0.y, r0, c28.x
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
add r1.xyz, r1, -c23
dp3 r1.x, r1, c25
rsq r1.y, r0.x
mul r1.z, c12.y, r0.w
mov r0.x, c27.y
mul r0.z, r1.y, r1.x
mul r0.x, c12.y, r0
mad r0.x, r0.z, c28, r0
mov r0.w, r0.y
mad r0.z, r0, c28.x, r1
dp3 o6.y, r2, r4
dp3 o7.y, r2, r3
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov o1.zw, r0
mov o9.zw, r0.xyxy
mov o8.y, r1.x
rcp o8.z, r1.y
mad o1.xy, v3, c26, c26.zwzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
mov o8.x, c25.w
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_WorldSpaceLightPos0]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_StartPoint]
Vector 25 [_EndPoint]
Vector 26 [_Plane]
Vector 27 [_MainTex_ST]
Vector 28 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[18];
DP4 R2.y, R0, c[17];
DP4 R2.x, R0, c[16];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[21];
DP4 R0.y, R1, c[20];
DP4 R0.x, R1, c[19];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R0.w, c[22];
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.xyz, c[14];
MOV R1.w, c[0];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[23].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[15];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 result.texcoord[5].y, R2, R1;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
DP3 R0.y, R2, c[5];
DP3 R0.w, -R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[23].w;
DP3 R0.y, R2, c[6];
DP3 R0.w, -R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.y, R2, c[7];
DP3 R0.w, -R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[23].w;
DP4 R0.w, vertex.position, c[6];
MOV R0.xyz, c[24];
ADD R0.xyz, -R0, c[25];
DP3 R0.x, R0, R0;
MOV R1.y, R0.w;
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
ADD R1.xyz, R1, -c[24];
DP3 R1.x, R1, c[26];
RSQ R1.y, R0.x;
ADD R0.x, R0.w, -c[24].y;
MOV R0.w, c[13].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MUL R1.z, R0.w, c[28].y;
MUL R0.z, R1.y, R1.x;
MAD R0.x, R0.z, c[0], R1.z;
MUL R0.y, R0, c[0].x;
MUL R1.z, R0.w, c[28].x;
MOV R0.w, R0.y;
MAD R0.z, R0, c[0].x, R1;
DP3 result.texcoord[6].y, R2, R3;
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
MOV result.texcoord[0].zw, R0;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.color.y, R1.x;
RCP result.color.z, R1.y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
MOV result.color.x, c[26].w;
END
# 84 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_StartPoint]
Vector 24 [_EndPoint]
Vector 25 [_Plane]
Vector 26 [_MainTex_ST]
Vector 27 [_MoveSpeed]
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
dcl_color1 o9
def c28, 3.00000000, 2.00000000, 0.16666667, 1.00000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c28
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c28
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c22.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r1, c8
dp4 r4.x, c14, r1
mov r0, c10
dp4 r4.z, c14, r0
mov r0, c9
dp4 r4.y, c14, r0
dp3 r0.y, r2, c4
dp3 r0.w, -r3, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c22.w
dp3 r0.y, r2, c5
dp3 r0.w, -r3, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c22.w
dp3 r0.y, r2, c6
dp3 r0.w, -r3, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c22.w
dp4 r0.w, v0, c5
mov r0.xyz, c24
add r0.xyz, -c23, r0
dp3 r0.x, r0, r0
add r0.y, r0.w, -c23
mov r1.y, r0.w
add r0.y, r0, c28
mul r0.y, r0, c28.z
mov r0.w, c27.x
mul r0.y, r0, c28.x
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
add r1.xyz, r1, -c23
dp3 r1.x, r1, c25
rsq r1.y, r0.x
mul r1.z, c12.y, r0.w
mov r0.x, c27.y
mul r0.z, r1.y, r1.x
mul r0.x, c12.y, r0
mad r0.x, r0.z, c28, r0
mov r0.w, r0.y
mad r0.z, r0, c28.x, r1
dp3 o6.y, r2, r4
dp3 o7.y, r2, r3
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov o1.zw, r0
mov o9.zw, r0.xyxy
mov o8.y, r1.x
rcp o8.z, r1.y
mad o1.xy, v3, c26, c26.zwzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
mov o8.x, c25.w
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_WorldSpaceLightPos0]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_StartPoint]
Vector 25 [_EndPoint]
Vector 26 [_Plane]
Vector 27 [_MainTex_ST]
Vector 28 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[18];
DP4 R2.y, R0, c[17];
DP4 R2.x, R0, c[16];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[21];
DP4 R0.y, R1, c[20];
DP4 R0.x, R1, c[19];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R0.w, c[22];
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.xyz, c[14];
MOV R1.w, c[0];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[23].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[15];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 result.texcoord[5].y, R2, R1;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
DP3 R0.y, R2, c[5];
DP3 R0.w, -R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[23].w;
DP3 R0.y, R2, c[6];
DP3 R0.w, -R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[23].w;
DP3 R0.y, R2, c[7];
DP3 R0.w, -R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[23].w;
DP4 R0.w, vertex.position, c[6];
MOV R0.xyz, c[24];
ADD R0.xyz, -R0, c[25];
DP3 R0.x, R0, R0;
MOV R1.y, R0.w;
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
ADD R1.xyz, R1, -c[24];
DP3 R1.x, R1, c[26];
RSQ R1.y, R0.x;
ADD R0.x, R0.w, -c[24].y;
MOV R0.w, c[13].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MUL R1.z, R0.w, c[28].y;
MUL R0.z, R1.y, R1.x;
MAD R0.x, R0.z, c[0], R1.z;
MUL R0.y, R0, c[0].x;
MUL R1.z, R0.w, c[28].x;
MOV R0.w, R0.y;
MAD R0.z, R0, c[0].x, R1;
DP3 result.texcoord[6].y, R2, R3;
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
MOV result.texcoord[0].zw, R0;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.color.y, R1.x;
RCP result.color.z, R1.y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
MOV result.color.x, c[26].w;
END
# 84 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_StartPoint]
Vector 24 [_EndPoint]
Vector 25 [_Plane]
Vector 26 [_MainTex_ST]
Vector 27 [_MoveSpeed]
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
dcl_color1 o9
def c28, 3.00000000, 2.00000000, 0.16666667, 1.00000000
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c22.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c28
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c20
dp4 r0.y, r1, c19
dp4 r0.x, r1, c18
mul r1.xyz, r0.w, c21
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c28
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c22.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r1, c8
dp4 r4.x, c14, r1
mov r0, c10
dp4 r4.z, c14, r0
mov r0, c9
dp4 r4.y, c14, r0
dp3 r0.y, r2, c4
dp3 r0.w, -r3, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c22.w
dp3 r0.y, r2, c5
dp3 r0.w, -r3, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c22.w
dp3 r0.y, r2, c6
dp3 r0.w, -r3, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c22.w
dp4 r0.w, v0, c5
mov r0.xyz, c24
add r0.xyz, -c23, r0
dp3 r0.x, r0, r0
add r0.y, r0.w, -c23
mov r1.y, r0.w
add r0.y, r0, c28
mul r0.y, r0, c28.z
mov r0.w, c27.x
mul r0.y, r0, c28.x
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
add r1.xyz, r1, -c23
dp3 r1.x, r1, c25
rsq r1.y, r0.x
mul r1.z, c12.y, r0.w
mov r0.x, c27.y
mul r0.z, r1.y, r1.x
mul r0.x, c12.y, r0
mad r0.x, r0.z, c28, r0
mov r0.w, r0.y
mad r0.z, r0, c28.x, r1
dp3 o6.y, r2, r4
dp3 o7.y, r2, r3
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov o1.zw, r0
mov o9.zw, r0.xyxy
mov o8.y, r1.x
rcp o8.z, r1.y
mad o1.xy, v3, c26, c26.zwzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
mov o8.x, c25.w
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [unity_Scale]
Vector 25 [_StartPoint]
Vector 26 [_EndPoint]
Vector 27 [_Plane]
Vector 28 [_MainTex_ST]
Vector 29 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[31] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..29],
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[24].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[19];
DP4 R2.y, R0, c[18];
DP4 R2.x, R0, c[17];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[22];
DP4 R0.y, R1, c[21];
DP4 R0.x, R1, c[20];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R0.w, c[23];
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.w, c[0];
MOV R1.xyz, c[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[24].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[16];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 R0.y, R2, c[5];
DP3 result.texcoord[5].y, R2, R1;
DP3 result.texcoord[6].y, R2, R3;
MOV R1.w, c[13].y;
DP3 R0.w, -R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[24].w;
DP3 R0.y, R2, c[6];
DP3 R0.w, -R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[24].w;
DP3 R0.y, R2, c[7];
DP3 R0.w, -R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[24].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MOV result.position, R0;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
MUL R1.xyz, R0.xyww, c[30].x;
MUL R1.y, R1, c[15].x;
DP4 R0.x, vertex.position, c[6];
MOV R2.y, R0.x;
ADD result.texcoord[7].xy, R1, R1.z;
MOV R1.xyz, c[25];
ADD R1.xyz, -R1, c[26];
DP3 R0.y, R1, R1;
RSQ R1.y, R0.y;
ADD R0.x, R0, -c[25].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MUL R0.y, R0, c[0].x;
DP4 R2.z, vertex.position, c[7];
DP4 R2.x, vertex.position, c[5];
ADD R2.xyz, R2, -c[25];
DP3 R1.x, R2, c[27];
MUL R2.x, R1.w, c[29].y;
MUL R1.z, R1.y, R1.x;
MAD R0.x, R1.z, c[0], R2;
MUL R2.x, R1.w, c[29];
MOV R1.w, R0.y;
MAD R1.z, R1, c[0].x, R2.x;
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
MOV result.texcoord[0].zw, R1;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.texcoord[7].zw, R0;
MOV result.color.y, R1.x;
RCP result.color.z, R1.y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.color.x, c[27].w;
END
# 89 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
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
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [unity_Scale]
Vector 25 [_StartPoint]
Vector 26 [_EndPoint]
Vector 27 [_Plane]
Vector 28 [_MainTex_ST]
Vector 29 [_MoveSpeed]
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
dcl_color1 o9
dcl_texcoord7 o10
def c30, 3.00000000, 2.00000000, 0.16666667, 1.00000000
def c31, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c24.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c30
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c19
dp4 r2.y, r0, c18
dp4 r2.x, r0, c17
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c22
dp4 r0.y, r1, c21
dp4 r0.x, r1, c20
mul r1.xyz, r0.w, c23
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c30
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c24.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r1, c8
mov r0, c10
dp4 r4.z, c16, r0
mov r0, c9
dp4 r4.y, c16, r0
dp4 r4.x, c16, r1
dp3 r0.y, r2, c4
dp3 o6.y, r2, r4
dp3 o7.y, r2, r3
dp3 r0.w, -r3, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c24.w
dp3 r0.y, r2, c5
dp3 r0.w, -r3, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c24.w
dp3 r0.y, r2, c6
dp3 r0.w, -r3, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c24.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.x
mul r1.y, r1, c14.x
mov o0, r0
dp4 r0.x, v0, c5
mov r2.y, r0.x
mad o10.xy, r1.z, c15.zwzw, r1
mov r1.xyz, c26
add r1.xyz, -c25, r1
dp3 r0.y, r1, r1
rsq r1.y, r0.y
mov r0.y, c29
mul r1.w, c12.y, r0.y
add r0.x, r0, -c25.y
add r0.y, r0.x, c30
mul r0.y, r0, c30.z
mul r0.y, r0, c30.x
dp4 r2.z, v0, c6
dp4 r2.x, v0, c4
add r2.xyz, r2, -c25
dp3 r1.x, r2, c27
mul r1.z, r1.y, r1.x
mad r0.x, r1.z, c30, r1.w
mov r1.w, c29.x
mul r2.x, c12.y, r1.w
mov r1.w, r0.y
mad r1.z, r1, c30.x, r2.x
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov o1.zw, r1
mov o9.zw, r0.xyxy
mov o10.zw, r0
mov o8.y, r1.x
rcp o8.z, r1.y
mad o1.xy, v3, c28, c28.zwzw
mov o8.x, c27.w
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [unity_Scale]
Vector 25 [_StartPoint]
Vector 26 [_EndPoint]
Vector 27 [_Plane]
Vector 28 [_MainTex_ST]
Vector 29 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[31] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..29],
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[24].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[19];
DP4 R2.y, R0, c[18];
DP4 R2.x, R0, c[17];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[22];
DP4 R0.y, R1, c[21];
DP4 R0.x, R1, c[20];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R0.w, c[23];
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.w, c[0];
MOV R1.xyz, c[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[24].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[16];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 R0.y, R2, c[5];
DP3 result.texcoord[5].y, R2, R1;
DP3 result.texcoord[6].y, R2, R3;
MOV R1.w, c[13].y;
DP3 R0.w, -R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[24].w;
DP3 R0.y, R2, c[6];
DP3 R0.w, -R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[24].w;
DP3 R0.y, R2, c[7];
DP3 R0.w, -R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[24].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MOV result.position, R0;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
MUL R1.xyz, R0.xyww, c[30].x;
MUL R1.y, R1, c[15].x;
DP4 R0.x, vertex.position, c[6];
MOV R2.y, R0.x;
ADD result.texcoord[7].xy, R1, R1.z;
MOV R1.xyz, c[25];
ADD R1.xyz, -R1, c[26];
DP3 R0.y, R1, R1;
RSQ R1.y, R0.y;
ADD R0.x, R0, -c[25].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MUL R0.y, R0, c[0].x;
DP4 R2.z, vertex.position, c[7];
DP4 R2.x, vertex.position, c[5];
ADD R2.xyz, R2, -c[25];
DP3 R1.x, R2, c[27];
MUL R2.x, R1.w, c[29].y;
MUL R1.z, R1.y, R1.x;
MAD R0.x, R1.z, c[0], R2;
MUL R2.x, R1.w, c[29];
MOV R1.w, R0.y;
MAD R1.z, R1, c[0].x, R2.x;
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
MOV result.texcoord[0].zw, R1;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.texcoord[7].zw, R0;
MOV result.color.y, R1.x;
RCP result.color.z, R1.y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.color.x, c[27].w;
END
# 89 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
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
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [unity_Scale]
Vector 25 [_StartPoint]
Vector 26 [_EndPoint]
Vector 27 [_Plane]
Vector 28 [_MainTex_ST]
Vector 29 [_MoveSpeed]
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
dcl_color1 o9
dcl_texcoord7 o10
def c30, 3.00000000, 2.00000000, 0.16666667, 1.00000000
def c31, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c24.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c30
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c19
dp4 r2.y, r0, c18
dp4 r2.x, r0, c17
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c22
dp4 r0.y, r1, c21
dp4 r0.x, r1, c20
mul r1.xyz, r0.w, c23
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c30
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c24.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r1, c8
mov r0, c10
dp4 r4.z, c16, r0
mov r0, c9
dp4 r4.y, c16, r0
dp4 r4.x, c16, r1
dp3 r0.y, r2, c4
dp3 o6.y, r2, r4
dp3 o7.y, r2, r3
dp3 r0.w, -r3, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c24.w
dp3 r0.y, r2, c5
dp3 r0.w, -r3, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c24.w
dp3 r0.y, r2, c6
dp3 r0.w, -r3, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c24.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.x
mul r1.y, r1, c14.x
mov o0, r0
dp4 r0.x, v0, c5
mov r2.y, r0.x
mad o10.xy, r1.z, c15.zwzw, r1
mov r1.xyz, c26
add r1.xyz, -c25, r1
dp3 r0.y, r1, r1
rsq r1.y, r0.y
mov r0.y, c29
mul r1.w, c12.y, r0.y
add r0.x, r0, -c25.y
add r0.y, r0.x, c30
mul r0.y, r0, c30.z
mul r0.y, r0, c30.x
dp4 r2.z, v0, c6
dp4 r2.x, v0, c4
add r2.xyz, r2, -c25
dp3 r1.x, r2, c27
mul r1.z, r1.y, r1.x
mad r0.x, r1.z, c30, r1.w
mov r1.w, c29.x
mul r2.x, c12.y, r1.w
mov r1.w, r0.y
mad r1.z, r1, c30.x, r2.x
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov o1.zw, r1
mov o9.zw, r0.xyxy
mov o10.zw, r0
mov o8.y, r1.x
rcp o8.z, r1.y
mad o1.xy, v3, c28, c28.zwzw
mov o8.x, c27.w
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [unity_Scale]
Vector 25 [_StartPoint]
Vector 26 [_EndPoint]
Vector 27 [_Plane]
Vector 28 [_MainTex_ST]
Vector 29 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[31] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..29],
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[24].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[19];
DP4 R2.y, R0, c[18];
DP4 R2.x, R0, c[17];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[22];
DP4 R0.y, R1, c[21];
DP4 R0.x, R1, c[20];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R0.w, c[23];
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.w, c[0];
MOV R1.xyz, c[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[24].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[16];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 R0.y, R2, c[5];
DP3 result.texcoord[5].y, R2, R1;
DP3 result.texcoord[6].y, R2, R3;
MOV R1.w, c[13].y;
DP3 R0.w, -R3, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[24].w;
DP3 R0.y, R2, c[6];
DP3 R0.w, -R3, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[24].w;
DP3 R0.y, R2, c[7];
DP3 R0.w, -R3, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[24].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MOV result.position, R0;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
MUL R1.xyz, R0.xyww, c[30].x;
MUL R1.y, R1, c[15].x;
DP4 R0.x, vertex.position, c[6];
MOV R2.y, R0.x;
ADD result.texcoord[7].xy, R1, R1.z;
MOV R1.xyz, c[25];
ADD R1.xyz, -R1, c[26];
DP3 R0.y, R1, R1;
RSQ R1.y, R0.y;
ADD R0.x, R0, -c[25].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MUL R0.y, R0, c[0].x;
DP4 R2.z, vertex.position, c[7];
DP4 R2.x, vertex.position, c[5];
ADD R2.xyz, R2, -c[25];
DP3 R1.x, R2, c[27];
MUL R2.x, R1.w, c[29].y;
MUL R1.z, R1.y, R1.x;
MAD R0.x, R1.z, c[0], R2;
MUL R2.x, R1.w, c[29];
MOV R1.w, R0.y;
MAD R1.z, R1, c[0].x, R2.x;
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
MOV result.texcoord[0].zw, R1;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.texcoord[7].zw, R0;
MOV result.color.y, R1.x;
RCP result.color.z, R1.y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.color.x, c[27].w;
END
# 89 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
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
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [unity_Scale]
Vector 25 [_StartPoint]
Vector 26 [_EndPoint]
Vector 27 [_Plane]
Vector 28 [_MainTex_ST]
Vector 29 [_MoveSpeed]
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
dcl_color1 o9
dcl_texcoord7 o10
def c30, 3.00000000, 2.00000000, 0.16666667, 1.00000000
def c31, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c24.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c30
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c19
dp4 r2.y, r0, c18
dp4 r2.x, r0, c17
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c22
dp4 r0.y, r1, c21
dp4 r0.x, r1, c20
mul r1.xyz, r0.w, c23
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c30
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c24.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r1, c8
mov r0, c10
dp4 r4.z, c16, r0
mov r0, c9
dp4 r4.y, c16, r0
dp4 r4.x, c16, r1
dp3 r0.y, r2, c4
dp3 o6.y, r2, r4
dp3 o7.y, r2, r3
dp3 r0.w, -r3, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c24.w
dp3 r0.y, r2, c5
dp3 r0.w, -r3, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c24.w
dp3 r0.y, r2, c6
dp3 r0.w, -r3, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c24.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c31.x
mul r1.y, r1, c14.x
mov o0, r0
dp4 r0.x, v0, c5
mov r2.y, r0.x
mad o10.xy, r1.z, c15.zwzw, r1
mov r1.xyz, c26
add r1.xyz, -c25, r1
dp3 r0.y, r1, r1
rsq r1.y, r0.y
mov r0.y, c29
mul r1.w, c12.y, r0.y
add r0.x, r0, -c25.y
add r0.y, r0.x, c30
mul r0.y, r0, c30.z
mul r0.y, r0, c30.x
dp4 r2.z, v0, c6
dp4 r2.x, v0, c4
add r2.xyz, r2, -c25
dp3 r1.x, r2, c27
mul r1.z, r1.y, r1.x
mad r0.x, r1.z, c30, r1.w
mov r1.w, c29.x
mul r2.x, c12.y, r1.w
mov r1.w, r0.y
mad r1.z, r1, c30.x, r2.x
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov o1.zw, r1
mov o9.zw, r0.xyxy
mov o10.zw, r0
mov o8.y, r1.x
rcp o8.z, r1.y
mad o1.xy, v3, c28, c28.zwzw
mov o8.x, c27.w
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_WorldSpaceLightPos0]
Vector 16 [unity_4LightPosX0]
Vector 17 [unity_4LightPosY0]
Vector 18 [unity_4LightPosZ0]
Vector 19 [unity_4LightAtten0]
Vector 20 [unity_LightColor0]
Vector 21 [unity_LightColor1]
Vector 22 [unity_LightColor2]
Vector 23 [unity_LightColor3]
Vector 24 [unity_SHAr]
Vector 25 [unity_SHAg]
Vector 26 [unity_SHAb]
Vector 27 [unity_SHBr]
Vector 28 [unity_SHBg]
Vector 29 [unity_SHBb]
Vector 30 [unity_SHC]
Vector 31 [unity_Scale]
Vector 32 [_StartPoint]
Vector 33 [_EndPoint]
Vector 34 [_Plane]
Vector 35 [_MainTex_ST]
Vector 36 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[38] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..36],
		{ 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MUL R3.xyz, vertex.normal, c[31].w;
DP3 R5.y, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
DP4 R5.x, vertex.position, c[6];
ADD R1, -R5.x, c[17];
DP4 R3.w, vertex.position, c[5];
MUL R2, R5.y, R1;
ADD R0, -R3.w, c[16];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MOV R4.y, R5;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0];
DP4 R5.z, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R5.z, c[18];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[19];
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].w;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[37].x;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[21];
MAD R1.xyz, R0.x, c[20], R1;
MAD R0.xyz, R0.z, c[22], R1;
MAD R1.xyz, R0.w, c[23], R0;
MUL R0, R4.xyzz, R4.yzzx;
MUL R1.w, R5.y, R5.y;
DP4 R3.z, R0, c[29];
DP4 R3.y, R0, c[28];
DP4 R3.x, R0, c[27];
MAD R1.w, R4.x, R4.x, -R1;
MUL R0.xyz, R1.w, c[30];
MOV R1.w, c[0];
DP4 R2.z, R4, c[26];
DP4 R2.y, R4, c[25];
DP4 R2.x, R4, c[24];
ADD R2.xyz, R2, R3;
ADD R0.xyz, R2, R0;
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.xyz, c[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[31].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[15];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 R0.w, -R3, c[5];
DP3 result.texcoord[6].y, R2, R3;
DP3 R0.y, R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[31].w;
DP3 R0.w, -R3, c[6];
DP3 R0.y, R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[31].w;
DP3 R0.w, -R3, c[7];
DP3 R0.y, R2, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[31].w;
MOV R0.xyz, c[32];
ADD R0.xyz, -R0, c[33];
DP3 R0.x, R0, R0;
MOV R0.w, c[13].y;
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
DP3 result.texcoord[5].y, R2, R1;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
MOV R3.x, R5;
MOV R3.y, R5.z;
ADD R1.xyz, R3.wxyw, -c[32];
DP3 R1.x, R1, c[34];
RSQ R1.y, R0.x;
ADD R0.x, R5, -c[32].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MUL R1.z, R0.w, c[36].y;
MUL R0.z, R1.y, R1.x;
MAD R0.x, R0.z, c[0], R1.z;
MUL R0.y, R0, c[0].x;
MUL R1.z, R0.w, c[36].x;
MOV R0.w, R0.y;
MAD R0.z, R0, c[0].x, R1;
MOV result.texcoord[0].zw, R0;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.color.y, R1.x;
RCP result.color.z, R1.y;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[35], c[35].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
MOV result.color.x, c[34].w;
END
# 113 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_4LightPosX0]
Vector 16 [unity_4LightPosY0]
Vector 17 [unity_4LightPosZ0]
Vector 18 [unity_4LightAtten0]
Vector 19 [unity_LightColor0]
Vector 20 [unity_LightColor1]
Vector 21 [unity_LightColor2]
Vector 22 [unity_LightColor3]
Vector 23 [unity_SHAr]
Vector 24 [unity_SHAg]
Vector 25 [unity_SHAb]
Vector 26 [unity_SHBr]
Vector 27 [unity_SHBg]
Vector 28 [unity_SHBb]
Vector 29 [unity_SHC]
Vector 30 [unity_Scale]
Vector 31 [_StartPoint]
Vector 32 [_EndPoint]
Vector 33 [_Plane]
Vector 34 [_MainTex_ST]
Vector 35 [_MoveSpeed]
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
dcl_color1 o9
def c36, 3.00000000, 2.00000000, 0.16666667, 1.00000000
def c37, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r3.xyz, v2, c30.w
dp3 r5.y, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
dp4 r5.x, v0, c5
add r1, -r5.x, c16
dp4 r3.w, v0, c4
mul r2, r5.y, r1
add r0, -r3.w, c15
mul r1, r1, r1
mov r4.z, r3.x
mov r4.y, r5
mad r2, r4.x, r0, r2
mov r4.w, c36
dp4 r5.z, v0, c6
mad r1, r0, r0, r1
add r0, -r5.z, c17
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c18
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c36.w
dp4 r2.z, r4, c25
dp4 r2.y, r4, c24
dp4 r2.x, r4, c23
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c37.x
mul r0, r0, r1
mul r1.xyz, r0.y, c20
mad r1.xyz, r0.x, c19, r1
mad r0.xyz, r0.z, c21, r1
mad r1.xyz, r0.w, c22, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r5.y, r5.y
dp4 r3.z, r0, c28
dp4 r3.y, r0, c27
dp4 r3.x, r0, c26
mad r1.w, r4.x, r4.x, -r1
add r2.xyz, r2, r3
mul r0.xyz, r1.w, c29
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c36
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c30.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r0, c10
dp4 r4.z, c14, r0
mov r0, c9
dp4 r4.y, c14, r0
mov r1, c8
dp4 r4.x, c14, r1
dp3 r0.w, -r3, c4
dp3 o7.y, r2, r3
dp3 r0.y, r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c30.w
dp3 r0.w, -r3, c5
dp3 r0.y, r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c30.w
dp3 r0.w, -r3, c6
dp3 r0.y, r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c30.w
mov r0.xyz, c32
add r0.xyz, -c31, r0
dp3 r0.x, r0, r0
add r0.y, r5.x, -c31
add r0.y, r0, c36
mul r0.y, r0, c36.z
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov r0.w, c35.x
mul r0.y, r0, c36.x
mov r3.x, r5
mov r3.y, r5.z
add r1.xyz, r3.wxyw, -c31
dp3 r1.x, r1, c33
rsq r1.y, r0.x
mul r1.z, c12.y, r0.w
mov r0.x, c35.y
mul r0.z, r1.y, r1.x
mul r0.x, c12.y, r0
mad r0.x, r0.z, c36, r0
mov r0.w, r0.y
mad r0.z, r0, c36.x, r1
dp3 o6.y, r2, r4
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
mov o1.zw, r0
mov o9.zw, r0.xyxy
mov o8.y, r1.x
rcp o8.z, r1.y
mad o1.xy, v3, c34, c34.zwzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
mov o8.x, c33.w
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [_ProjectionParams]
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_4LightPosX0]
Vector 18 [unity_4LightPosY0]
Vector 19 [unity_4LightPosZ0]
Vector 20 [unity_4LightAtten0]
Vector 21 [unity_LightColor0]
Vector 22 [unity_LightColor1]
Vector 23 [unity_LightColor2]
Vector 24 [unity_LightColor3]
Vector 25 [unity_SHAr]
Vector 26 [unity_SHAg]
Vector 27 [unity_SHAb]
Vector 28 [unity_SHBr]
Vector 29 [unity_SHBg]
Vector 30 [unity_SHBb]
Vector 31 [unity_SHC]
Vector 32 [unity_Scale]
Vector 33 [_StartPoint]
Vector 34 [_EndPoint]
Vector 35 [_Plane]
Vector 36 [_MainTex_ST]
Vector 37 [_MoveSpeed]
"3.0-!!ARBvp1.0
PARAM c[39] = { { 3, 2, 0.16666667, 1 },
		state.matrix.mvp,
		program.local[5..37],
		{ 0, 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MUL R3.xyz, vertex.normal, c[32].w;
DP3 R5.y, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
DP4 R5.x, vertex.position, c[6];
ADD R1, -R5.x, c[18];
DP4 R3.w, vertex.position, c[5];
MUL R2, R5.y, R1;
ADD R0, -R3.w, c[17];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MOV R4.y, R5;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0];
DP4 R5.z, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R5.z, c[19];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[20];
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].w;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[38].x;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[22];
MAD R1.xyz, R0.x, c[21], R1;
MAD R0.xyz, R0.z, c[23], R1;
MAD R1.xyz, R0.w, c[24], R0;
MUL R0, R4.xyzz, R4.yzzx;
MUL R1.w, R5.y, R5.y;
DP4 R3.z, R0, c[30];
DP4 R3.y, R0, c[29];
DP4 R3.x, R0, c[28];
MAD R1.w, R4.x, R4.x, -R1;
MUL R0.xyz, R1.w, c[31];
MOV R1.w, c[0];
DP4 R2.z, R4, c[27];
DP4 R2.y, R4, c[26];
DP4 R2.x, R4, c[25];
ADD R2.xyz, R2, R3;
ADD R0.xyz, R2, R0;
ADD result.texcoord[4].xyz, R0, R1;
MOV R1.xyz, c[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R3.xyz, R2, c[32].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R2.xyz, vertex.attrib[14].w, R1;
MOV R0, c[16];
DP4 R1.z, R0, c[11];
DP4 R1.x, R0, c[9];
DP4 R1.y, R0, c[10];
DP3 R0.w, -R3, c[5];
DP3 result.texcoord[6].y, R2, R3;
DP3 R0.y, R2, c[5];
DP3 result.texcoord[5].y, R2, R1;
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1], R0, c[32].w;
DP3 R0.w, -R3, c[6];
DP3 R0.y, R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2], R0, c[32].w;
DP3 R0.w, -R3, c[7];
DP3 R0.y, R2, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3], R0, c[32].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 result.texcoord[6].z, vertex.normal, R3;
DP3 result.texcoord[6].x, vertex.attrib[14], R3;
MOV result.position, R0;
DP3 result.texcoord[5].z, vertex.normal, R1;
DP3 result.texcoord[5].x, vertex.attrib[14], R1;
MUL R1.xyz, R0.xyww, c[38].y;
MUL R1.y, R1, c[15].x;
ADD result.texcoord[7].xy, R1, R1.z;
MOV R1.xyz, c[33];
ADD R1.xyz, -R1, c[34];
DP3 R0.x, R1, R1;
RSQ R1.w, R0.x;
ADD R0.x, R5, -c[33].y;
ADD R0.x, R0, c[0].y;
MUL R0.y, R0.x, c[0].z;
MOV R1.y, c[13];
MUL R0.y, R0, c[0].x;
MOV R3.x, R5;
MOV R3.y, R5.z;
ADD R2.xyz, R3.wxyw, -c[33];
DP3 R1.z, R2, c[35];
MUL R2.x, R1.y, c[37].y;
MUL R1.x, R1.w, R1.z;
MAD R0.x, R1, c[0], R2;
MUL R2.x, R1.y, c[37];
MOV R1.y, R0;
MAD R1.x, R1, c[0], R2;
MOV result.texcoord[0].zw, R1.xyxy;
MOV result.color.secondary.zw, R0.xyxy;
MOV result.texcoord[7].zw, R0;
MOV result.color.y, R1.z;
RCP result.color.z, R1.w;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[36], c[36].zwzw;
MOV result.color.x, c[35].w;
END
# 118 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
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
Vector 16 [_WorldSpaceLightPos0]
Vector 17 [unity_4LightPosX0]
Vector 18 [unity_4LightPosY0]
Vector 19 [unity_4LightPosZ0]
Vector 20 [unity_4LightAtten0]
Vector 21 [unity_LightColor0]
Vector 22 [unity_LightColor1]
Vector 23 [unity_LightColor2]
Vector 24 [unity_LightColor3]
Vector 25 [unity_SHAr]
Vector 26 [unity_SHAg]
Vector 27 [unity_SHAb]
Vector 28 [unity_SHBr]
Vector 29 [unity_SHBg]
Vector 30 [unity_SHBb]
Vector 31 [unity_SHC]
Vector 32 [unity_Scale]
Vector 33 [_StartPoint]
Vector 34 [_EndPoint]
Vector 35 [_Plane]
Vector 36 [_MainTex_ST]
Vector 37 [_MoveSpeed]
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
dcl_color1 o9
dcl_texcoord7 o10
def c38, 3.00000000, 2.00000000, 0.16666667, 1.00000000
def c39, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r3.xyz, v2, c32.w
dp3 r5.y, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
dp4 r5.x, v0, c5
add r1, -r5.x, c18
dp4 r3.w, v0, c4
mul r2, r5.y, r1
add r0, -r3.w, c17
mul r1, r1, r1
mov r4.z, r3.x
mov r4.y, r5
mad r2, r4.x, r0, r2
mov r4.w, c38
dp4 r5.z, v0, c6
mad r1, r0, r0, r1
add r0, -r5.z, c19
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c20
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c38.w
dp4 r2.z, r4, c27
dp4 r2.y, r4, c26
dp4 r2.x, r4, c25
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c39.x
mul r0, r0, r1
mul r1.xyz, r0.y, c22
mad r1.xyz, r0.x, c21, r1
mad r0.xyz, r0.z, c23, r1
mad r1.xyz, r0.w, c24, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r5.y, r5.y
dp4 r3.z, r0, c30
dp4 r3.y, r0, c29
dp4 r3.x, r0, c28
mad r1.w, r4.x, r4.x, -r1
add r2.xyz, r2, r3
mul r0.xyz, r1.w, c31
add r0.xyz, r2, r0
add o5.xyz, r0, r1
mov r0.w, c38
mov r0.xyz, c13
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c32.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, v1.w, r1
mov r1, c8
mov r0, c10
dp4 r4.z, c16, r0
mov r0, c9
dp4 r4.y, c16, r0
dp4 r4.x, c16, r1
dp3 r0.w, -r3, c4
dp3 o7.y, r2, r3
dp3 r0.y, r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2, r0, c32.w
dp3 r0.w, -r3, c5
dp3 r0.y, r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3, r0, c32.w
dp3 r0.w, -r3, c6
dp3 r0.y, r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4, r0, c32.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c39.y
mul r1.y, r1, c14.x
mov o0, r0
mad o10.xy, r1.z, c15.zwzw, r1
mov r1.xyz, c34
add r1.xyz, -c33, r1
dp3 r0.x, r1, r1
rsq r1.w, r0.x
mov r0.x, c37.y
add r0.y, r5.x, -c33
add r0.y, r0, c38
mul r0.y, r0, c38.z
dp3 o7.z, v2, r3
dp3 o7.x, v1, r3
mov r1.y, c37.x
mul r0.y, r0, c38.x
dp3 o6.y, r2, r4
mov r3.x, r5
mov r3.y, r5.z
add r2.xyz, r3.wxyw, -c33
dp3 r1.z, r2, c35
mul r2.x, c12.y, r1.y
mul r1.x, r1.w, r1.z
mul r0.x, c12.y, r0
mad r0.x, r1, c38, r0
mov r1.y, r0
mad r1.x, r1, c38, r2
dp3 o6.z, v2, r4
dp3 o6.x, v1, r4
mov o1.zw, r1.xyxy
mov o9.zw, r0.xyxy
mov o10.zw, r0
mov o8.y, r1.z
rcp o8.z, r1.w
mad o1.xy, v3, c36, c36.zwzw
mov o8.x, c35.w
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_MoveTex] 2D 3
"3.0-!!ARBfp1.0
PARAM c[19] = { program.local[0..16],
		{ 0.5, 0, 1, 0.029999999 },
		{ 2, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0, c[3];
TEX R2.yzw, fragment.texcoord[0], texture[1], 2D;
ADD R0, -R0, c[6];
MAD R0, R2.w, R0, c[3];
ADD R1, -R0, c[5];
MAD R0, R2.z, R1, R0;
ADD R1, -R0, c[4];
MAD R1, R2.y, R1, R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, R1;
MUL R1.xyz, R0, fragment.texcoord[4];
MOV R2.x, c[17].z;
TEX R3.yw, fragment.texcoord[0], texture[2], 2D;
MAD R3.xy, R3.wyzw, c[18].x, -R2.x;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R2.x, R3.z, R3.w;
ADD R1.w, -R2.x, c[17].z;
RSQ R1.w, R1.w;
RCP R3.z, R1.w;
MOV R1.w, c[7].x;
SGE R2.xyz, R2.yzww, c[17].x;
DP3 R3.w, R3, fragment.texcoord[5];
ADD R1.w, -R1, c[10].x;
MAD R1.w, R2.z, R1, c[7].x;
ADD R2.z, -R1.w, c[9].x;
MAD R1.w, R2.y, R2.z, R1;
DP3 R2.y, fragment.texcoord[6], fragment.texcoord[6];
MAX R2.w, R3, c[17].y;
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R2.w;
RSQ R2.y, R2.y;
MOV R4.xyz, fragment.texcoord[5];
MAD R4.xyz, R2.y, fragment.texcoord[6], R4;
ADD R2.y, -R1.w, c[8].x;
MAD R1.w, R2.x, R2.y, R1;
MUL R2.w, R1, R1;
DP3 R2.z, R4, R4;
ADD R2.w, R2, c[17];
RSQ R2.x, R2.z;
MUL R2.xyz, R2.x, R4;
DP3 R2.x, R3, R2;
MUL R0.w, R2, R0;
MAX R2.w, R2.x, c[17].y;
MUL R1.w, R1, c[18].y;
POW R1.w, R2.w, R1.w;
MOV R2.xyz, c[1];
MUL R0.w, R0, R1;
MUL R2.xyz, R2, c[0];
MUL R2.xyz, R0.w, R2;
MAD R0.xyz, R2, c[18].x, R0;
MAD R2.xyz, R0, c[18].x, R1;
TEX R0.y, fragment.color.secondary.zwzw, texture[3], 2D;
MUL R1, R0.y, c[15];
TEX R0.x, fragment.texcoord[0].zwzw, texture[3], 2D;
MUL R0, R0.x, c[14];
MAD R0, R0, c[16].x, R1;
MOV R2.w, c[17].z;
ADD R1.z, fragment.color.primary, -c[17].x;
ADD R1.y, fragment.color.primary, c[12].x;
ADD R0, R0, -R2;
SIN R1.x, c[13].x;
MAD R0, R1.x, R0, R2;
SLT R1.x, fragment.color.primary, fragment.color.primary.y;
SLT R1.z, fragment.color.primary.x, R1;
SLT R1.y, fragment.color.primary.x, R1;
MUL R1.w, R1.y, R1.z;
ABS R1.z, R1.x;
MOV R1.xy, c[17];
SLT R2.x, c[11], R1;
CMP R1.z, -R1, c[17].y, c[17];
MUL R2.y, R2.x, R1.z;
ABS R1.x, R1.w;
ABS R2.x, R2;
CMP R2.z, -R1.x, c[17].y, c[17];
MUL R1.z, R2.y, R1.w;
MUL R2.y, R2, R2.z;
CMP R1, -R1.z, c[2], R1.y;
CMP R1, -R2.y, R0, R1;
SLT R2.y, fragment.color.primary, fragment.color.primary.x;
CMP R2.x, -R2, c[17].y, c[17].z;
MUL R2.w, R2.x, R2.y;
ABS R2.z, R2.y;
CMP R2.y, -R2.z, c[17], c[17].z;
CMP R1, -R2.w, c[17].y, R1;
MUL R2.x, R2, R2.y;
CMP result.color, -R2.x, R0, R1;
END
# 86 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_MoveTex] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c17, -0.50000000, 0.00000000, 1.00000000, 0.03000000
def c18, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c19, 2.00000000, -1.00000000, 128.00000000, 0
dcl_texcoord0 v0
dcl_texcoord4 v1.xyz
dcl_texcoord5 v2.xyz
dcl_texcoord6 v3.xyz
dcl_color0 v4.xyz
dcl_color1 v5.xyzw
texld r3.yw, v0, s2
mad_pp r3.xy, r3.wyzw, c19.x, c19.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
add_pp_sat r2.x, r3.z, r3.w
mov r0, c6
texld r2.yzw, v0, s1
add r0, -c3, r0
mad r0, r2.w, r0, c3
add r1, -r0, c5
mad r0, r2.z, r1, r0
add r1, -r0, c4
mad r1, r2.y, r1, r0
texld r0, v0, s0
mul r0, r0, r1
mul r1.xyz, r0, v1
add_pp r2.x, -r2, c17.z
rsq_pp r1.w, r2.x
rcp_pp r3.z, r1.w
add r2.xyz, r2.yzww, c17.x
mov_pp r3.w, c10.x
cmp r2.xyz, r2, c17.z, c17.y
add_pp r2.w, -c7.x, r3
mad_pp r2.z, r2, r2.w, c7.x
dp3_pp r1.w, r3, v2
max_pp r2.w, r1, c17.y
add_pp r1.w, -r2.z, c9.x
mad_pp r1.w, r2.y, r1, r2.z
mul_pp r0.xyz, r0, c0
dp3_pp r2.y, v3, v3
mul_pp r0.xyz, r0, r2.w
rsq_pp r2.y, r2.y
mov_pp r4.xyz, v2
mad_pp r4.xyz, r2.y, v3, r4
add_pp r2.y, -r1.w, c8.x
mad_pp r1.w, r2.x, r2.y, r1
mul_pp r2.w, r1, r1
dp3_pp r2.z, r4, r4
add r3.w, r2, c17
rsq_pp r2.x, r2.z
mul_pp r2.xyz, r2.x, r4
dp3_pp r2.x, r3, r2
mul_pp r3.x, r1.w, c19.z
max_pp r1.w, r2.x, c17.y
pow r2, r1.w, r3.x
mov r1.w, r2.x
mov_pp r3.xyz, c0
mul r0.w, r3, r0
mul r0.w, r0, r1
mul_pp r2.xyz, c1, r3
mul r2.xyz, r0.w, r2
mad r0.xyz, r2, c19.x, r0
mad r2.xyz, r0, c19.x, r1
texld r0.x, v0.zwzw, s3
mov r0.y, c13.x
mul r1, r0.x, c14
mad r0.x, r0.y, c18, c18.y
frc r2.w, r0.x
texld r0.y, v5.zwzw, s3
mul r0, r0.y, c15
mad r1, r1, c16.x, r0
mad r2.w, r2, c18.z, c18
sincos r0.xy, r2.w
mov r2.w, c17.z
add r1, r1, -r2
mad r0, r0.y, r1, r2
add r2.y, v4.z, c17.x
add r2.x, v4.y, c12
add r2.y, v4.x, -r2
add r2.x, v4, -r2
cmp r2.y, r2, c17, c17.z
cmp r2.x, r2, c17.y, c17.z
mul_pp r2.z, r2.x, r2.y
mov r2.x, c11
add_pp r2.y, v4.x, -v4
add r2.x, c17, r2
abs_pp r2.w, r2.z
cmp r2.x, r2, c17.y, c17.z
cmp_pp r2.y, r2, c17.z, c17
mul_pp r2.y, r2.x, r2
mul_pp r3.x, r2.y, r2.z
cmp_pp r2.z, -r2.w, c17, c17.y
mov r1, c2
abs_pp r2.x, r2
mul_pp r2.y, r2, r2.z
cmp r1, -r3.x, c17.y, r1
cmp r1, -r2.y, r1, r0
add r2.y, -v4.x, v4
cmp r2.y, r2, c17, c17.z
cmp_pp r2.x, -r2, c17.z, c17.y
mul_pp r2.w, r2.x, r2.y
abs_pp r2.z, r2.y
cmp_pp r2.y, -r2.z, c17.z, c17
cmp r1, -r2.w, r1, c17.y
mul_pp r2.x, r2, r2.y
cmp oC0, -r2.x, r1, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_MoveTex] 2D 3
"3.0-!!ARBfp1.0
PARAM c[19] = { program.local[0..16],
		{ 0.5, 0, 1, 0.029999999 },
		{ 2, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0, c[3];
TEX R2.yzw, fragment.texcoord[0], texture[1], 2D;
ADD R0, -R0, c[6];
MAD R0, R2.w, R0, c[3];
ADD R1, -R0, c[5];
MAD R0, R2.z, R1, R0;
ADD R1, -R0, c[4];
MAD R1, R2.y, R1, R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, R1;
MUL R1.xyz, R0, fragment.texcoord[4];
MOV R2.x, c[17].z;
TEX R3.yw, fragment.texcoord[0], texture[2], 2D;
MAD R3.xy, R3.wyzw, c[18].x, -R2.x;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R2.x, R3.z, R3.w;
ADD R1.w, -R2.x, c[17].z;
RSQ R1.w, R1.w;
RCP R3.z, R1.w;
MOV R1.w, c[7].x;
SGE R2.xyz, R2.yzww, c[17].x;
DP3 R3.w, R3, fragment.texcoord[5];
ADD R1.w, -R1, c[10].x;
MAD R1.w, R2.z, R1, c[7].x;
ADD R2.z, -R1.w, c[9].x;
MAD R1.w, R2.y, R2.z, R1;
DP3 R2.y, fragment.texcoord[6], fragment.texcoord[6];
MAX R2.w, R3, c[17].y;
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R2.w;
RSQ R2.y, R2.y;
MOV R4.xyz, fragment.texcoord[5];
MAD R4.xyz, R2.y, fragment.texcoord[6], R4;
ADD R2.y, -R1.w, c[8].x;
MAD R1.w, R2.x, R2.y, R1;
MUL R2.w, R1, R1;
DP3 R2.z, R4, R4;
ADD R2.w, R2, c[17];
RSQ R2.x, R2.z;
MUL R2.xyz, R2.x, R4;
DP3 R2.x, R3, R2;
MUL R0.w, R2, R0;
MAX R2.w, R2.x, c[17].y;
MUL R1.w, R1, c[18].y;
POW R1.w, R2.w, R1.w;
MOV R2.xyz, c[1];
MUL R0.w, R0, R1;
MUL R2.xyz, R2, c[0];
MUL R2.xyz, R0.w, R2;
MAD R0.xyz, R2, c[18].x, R0;
MAD R2.xyz, R0, c[18].x, R1;
TEX R0.y, fragment.color.secondary.zwzw, texture[3], 2D;
MUL R1, R0.y, c[15];
TEX R0.x, fragment.texcoord[0].zwzw, texture[3], 2D;
MUL R0, R0.x, c[14];
MAD R0, R0, c[16].x, R1;
MOV R2.w, c[17].z;
ADD R1.z, fragment.color.primary, -c[17].x;
ADD R1.y, fragment.color.primary, c[12].x;
ADD R0, R0, -R2;
SIN R1.x, c[13].x;
MAD R0, R1.x, R0, R2;
SLT R1.x, fragment.color.primary, fragment.color.primary.y;
SLT R1.z, fragment.color.primary.x, R1;
SLT R1.y, fragment.color.primary.x, R1;
MUL R1.w, R1.y, R1.z;
ABS R1.z, R1.x;
MOV R1.xy, c[17];
SLT R2.x, c[11], R1;
CMP R1.z, -R1, c[17].y, c[17];
MUL R2.y, R2.x, R1.z;
ABS R1.x, R1.w;
ABS R2.x, R2;
CMP R2.z, -R1.x, c[17].y, c[17];
MUL R1.z, R2.y, R1.w;
MUL R2.y, R2, R2.z;
CMP R1, -R1.z, c[2], R1.y;
CMP R1, -R2.y, R0, R1;
SLT R2.y, fragment.color.primary, fragment.color.primary.x;
CMP R2.x, -R2, c[17].y, c[17].z;
MUL R2.w, R2.x, R2.y;
ABS R2.z, R2.y;
CMP R2.y, -R2.z, c[17], c[17].z;
CMP R1, -R2.w, c[17].y, R1;
MUL R2.x, R2, R2.y;
CMP result.color, -R2.x, R0, R1;
END
# 86 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_MoveTex] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c17, -0.50000000, 0.00000000, 1.00000000, 0.03000000
def c18, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c19, 2.00000000, -1.00000000, 128.00000000, 0
dcl_texcoord0 v0
dcl_texcoord4 v1.xyz
dcl_texcoord5 v2.xyz
dcl_texcoord6 v3.xyz
dcl_color0 v4.xyz
dcl_color1 v5.xyzw
texld r3.yw, v0, s2
mad_pp r3.xy, r3.wyzw, c19.x, c19.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
add_pp_sat r2.x, r3.z, r3.w
mov r0, c6
texld r2.yzw, v0, s1
add r0, -c3, r0
mad r0, r2.w, r0, c3
add r1, -r0, c5
mad r0, r2.z, r1, r0
add r1, -r0, c4
mad r1, r2.y, r1, r0
texld r0, v0, s0
mul r0, r0, r1
mul r1.xyz, r0, v1
add_pp r2.x, -r2, c17.z
rsq_pp r1.w, r2.x
rcp_pp r3.z, r1.w
add r2.xyz, r2.yzww, c17.x
mov_pp r3.w, c10.x
cmp r2.xyz, r2, c17.z, c17.y
add_pp r2.w, -c7.x, r3
mad_pp r2.z, r2, r2.w, c7.x
dp3_pp r1.w, r3, v2
max_pp r2.w, r1, c17.y
add_pp r1.w, -r2.z, c9.x
mad_pp r1.w, r2.y, r1, r2.z
mul_pp r0.xyz, r0, c0
dp3_pp r2.y, v3, v3
mul_pp r0.xyz, r0, r2.w
rsq_pp r2.y, r2.y
mov_pp r4.xyz, v2
mad_pp r4.xyz, r2.y, v3, r4
add_pp r2.y, -r1.w, c8.x
mad_pp r1.w, r2.x, r2.y, r1
mul_pp r2.w, r1, r1
dp3_pp r2.z, r4, r4
add r3.w, r2, c17
rsq_pp r2.x, r2.z
mul_pp r2.xyz, r2.x, r4
dp3_pp r2.x, r3, r2
mul_pp r3.x, r1.w, c19.z
max_pp r1.w, r2.x, c17.y
pow r2, r1.w, r3.x
mov r1.w, r2.x
mov_pp r3.xyz, c0
mul r0.w, r3, r0
mul r0.w, r0, r1
mul_pp r2.xyz, c1, r3
mul r2.xyz, r0.w, r2
mad r0.xyz, r2, c19.x, r0
mad r2.xyz, r0, c19.x, r1
texld r0.x, v0.zwzw, s3
mov r0.y, c13.x
mul r1, r0.x, c14
mad r0.x, r0.y, c18, c18.y
frc r2.w, r0.x
texld r0.y, v5.zwzw, s3
mul r0, r0.y, c15
mad r1, r1, c16.x, r0
mad r2.w, r2, c18.z, c18
sincos r0.xy, r2.w
mov r2.w, c17.z
add r1, r1, -r2
mad r0, r0.y, r1, r2
add r2.y, v4.z, c17.x
add r2.x, v4.y, c12
add r2.y, v4.x, -r2
add r2.x, v4, -r2
cmp r2.y, r2, c17, c17.z
cmp r2.x, r2, c17.y, c17.z
mul_pp r2.z, r2.x, r2.y
mov r2.x, c11
add_pp r2.y, v4.x, -v4
add r2.x, c17, r2
abs_pp r2.w, r2.z
cmp r2.x, r2, c17.y, c17.z
cmp_pp r2.y, r2, c17.z, c17
mul_pp r2.y, r2.x, r2
mul_pp r3.x, r2.y, r2.z
cmp_pp r2.z, -r2.w, c17, c17.y
mov r1, c2
abs_pp r2.x, r2
mul_pp r2.y, r2, r2.z
cmp r1, -r3.x, c17.y, r1
cmp r1, -r2.y, r1, r0
add r2.y, -v4.x, v4
cmp r2.y, r2, c17, c17.z
cmp_pp r2.x, -r2, c17.z, c17.y
mul_pp r2.w, r2.x, r2.y
abs_pp r2.z, r2.y
cmp_pp r2.y, -r2.z, c17.z, c17
cmp r1, -r2.w, r1, c17.y
mul_pp r2.x, r2, r2.y
cmp oC0, -r2.x, r1, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_MoveTex] 2D 3
"3.0-!!ARBfp1.0
PARAM c[19] = { program.local[0..16],
		{ 0.5, 0, 1, 0.029999999 },
		{ 2, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0, c[3];
TEX R2.yzw, fragment.texcoord[0], texture[1], 2D;
ADD R0, -R0, c[6];
MAD R0, R2.w, R0, c[3];
ADD R1, -R0, c[5];
MAD R0, R2.z, R1, R0;
ADD R1, -R0, c[4];
MAD R1, R2.y, R1, R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, R1;
MUL R1.xyz, R0, fragment.texcoord[4];
MOV R2.x, c[17].z;
TEX R3.yw, fragment.texcoord[0], texture[2], 2D;
MAD R3.xy, R3.wyzw, c[18].x, -R2.x;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R2.x, R3.z, R3.w;
ADD R1.w, -R2.x, c[17].z;
RSQ R1.w, R1.w;
RCP R3.z, R1.w;
MOV R1.w, c[7].x;
SGE R2.xyz, R2.yzww, c[17].x;
DP3 R3.w, R3, fragment.texcoord[5];
ADD R1.w, -R1, c[10].x;
MAD R1.w, R2.z, R1, c[7].x;
ADD R2.z, -R1.w, c[9].x;
MAD R1.w, R2.y, R2.z, R1;
DP3 R2.y, fragment.texcoord[6], fragment.texcoord[6];
MAX R2.w, R3, c[17].y;
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R2.w;
RSQ R2.y, R2.y;
MOV R4.xyz, fragment.texcoord[5];
MAD R4.xyz, R2.y, fragment.texcoord[6], R4;
ADD R2.y, -R1.w, c[8].x;
MAD R1.w, R2.x, R2.y, R1;
MUL R2.w, R1, R1;
DP3 R2.z, R4, R4;
ADD R2.w, R2, c[17];
RSQ R2.x, R2.z;
MUL R2.xyz, R2.x, R4;
DP3 R2.x, R3, R2;
MUL R0.w, R2, R0;
MAX R2.w, R2.x, c[17].y;
MUL R1.w, R1, c[18].y;
POW R1.w, R2.w, R1.w;
MOV R2.xyz, c[1];
MUL R0.w, R0, R1;
MUL R2.xyz, R2, c[0];
MUL R2.xyz, R0.w, R2;
MAD R0.xyz, R2, c[18].x, R0;
MAD R2.xyz, R0, c[18].x, R1;
TEX R0.y, fragment.color.secondary.zwzw, texture[3], 2D;
MUL R1, R0.y, c[15];
TEX R0.x, fragment.texcoord[0].zwzw, texture[3], 2D;
MUL R0, R0.x, c[14];
MAD R0, R0, c[16].x, R1;
MOV R2.w, c[17].z;
ADD R1.z, fragment.color.primary, -c[17].x;
ADD R1.y, fragment.color.primary, c[12].x;
ADD R0, R0, -R2;
SIN R1.x, c[13].x;
MAD R0, R1.x, R0, R2;
SLT R1.x, fragment.color.primary, fragment.color.primary.y;
SLT R1.z, fragment.color.primary.x, R1;
SLT R1.y, fragment.color.primary.x, R1;
MUL R1.w, R1.y, R1.z;
ABS R1.z, R1.x;
MOV R1.xy, c[17];
SLT R2.x, c[11], R1;
CMP R1.z, -R1, c[17].y, c[17];
MUL R2.y, R2.x, R1.z;
ABS R1.x, R1.w;
ABS R2.x, R2;
CMP R2.z, -R1.x, c[17].y, c[17];
MUL R1.z, R2.y, R1.w;
MUL R2.y, R2, R2.z;
CMP R1, -R1.z, c[2], R1.y;
CMP R1, -R2.y, R0, R1;
SLT R2.y, fragment.color.primary, fragment.color.primary.x;
CMP R2.x, -R2, c[17].y, c[17].z;
MUL R2.w, R2.x, R2.y;
ABS R2.z, R2.y;
CMP R2.y, -R2.z, c[17], c[17].z;
CMP R1, -R2.w, c[17].y, R1;
MUL R2.x, R2, R2.y;
CMP result.color, -R2.x, R0, R1;
END
# 86 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_MoveTex] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c17, -0.50000000, 0.00000000, 1.00000000, 0.03000000
def c18, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c19, 2.00000000, -1.00000000, 128.00000000, 0
dcl_texcoord0 v0
dcl_texcoord4 v1.xyz
dcl_texcoord5 v2.xyz
dcl_texcoord6 v3.xyz
dcl_color0 v4.xyz
dcl_color1 v5.xyzw
texld r3.yw, v0, s2
mad_pp r3.xy, r3.wyzw, c19.x, c19.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
add_pp_sat r2.x, r3.z, r3.w
mov r0, c6
texld r2.yzw, v0, s1
add r0, -c3, r0
mad r0, r2.w, r0, c3
add r1, -r0, c5
mad r0, r2.z, r1, r0
add r1, -r0, c4
mad r1, r2.y, r1, r0
texld r0, v0, s0
mul r0, r0, r1
mul r1.xyz, r0, v1
add_pp r2.x, -r2, c17.z
rsq_pp r1.w, r2.x
rcp_pp r3.z, r1.w
add r2.xyz, r2.yzww, c17.x
mov_pp r3.w, c10.x
cmp r2.xyz, r2, c17.z, c17.y
add_pp r2.w, -c7.x, r3
mad_pp r2.z, r2, r2.w, c7.x
dp3_pp r1.w, r3, v2
max_pp r2.w, r1, c17.y
add_pp r1.w, -r2.z, c9.x
mad_pp r1.w, r2.y, r1, r2.z
mul_pp r0.xyz, r0, c0
dp3_pp r2.y, v3, v3
mul_pp r0.xyz, r0, r2.w
rsq_pp r2.y, r2.y
mov_pp r4.xyz, v2
mad_pp r4.xyz, r2.y, v3, r4
add_pp r2.y, -r1.w, c8.x
mad_pp r1.w, r2.x, r2.y, r1
mul_pp r2.w, r1, r1
dp3_pp r2.z, r4, r4
add r3.w, r2, c17
rsq_pp r2.x, r2.z
mul_pp r2.xyz, r2.x, r4
dp3_pp r2.x, r3, r2
mul_pp r3.x, r1.w, c19.z
max_pp r1.w, r2.x, c17.y
pow r2, r1.w, r3.x
mov r1.w, r2.x
mov_pp r3.xyz, c0
mul r0.w, r3, r0
mul r0.w, r0, r1
mul_pp r2.xyz, c1, r3
mul r2.xyz, r0.w, r2
mad r0.xyz, r2, c19.x, r0
mad r2.xyz, r0, c19.x, r1
texld r0.x, v0.zwzw, s3
mov r0.y, c13.x
mul r1, r0.x, c14
mad r0.x, r0.y, c18, c18.y
frc r2.w, r0.x
texld r0.y, v5.zwzw, s3
mul r0, r0.y, c15
mad r1, r1, c16.x, r0
mad r2.w, r2, c18.z, c18
sincos r0.xy, r2.w
mov r2.w, c17.z
add r1, r1, -r2
mad r0, r0.y, r1, r2
add r2.y, v4.z, c17.x
add r2.x, v4.y, c12
add r2.y, v4.x, -r2
add r2.x, v4, -r2
cmp r2.y, r2, c17, c17.z
cmp r2.x, r2, c17.y, c17.z
mul_pp r2.z, r2.x, r2.y
mov r2.x, c11
add_pp r2.y, v4.x, -v4
add r2.x, c17, r2
abs_pp r2.w, r2.z
cmp r2.x, r2, c17.y, c17.z
cmp_pp r2.y, r2, c17.z, c17
mul_pp r2.y, r2.x, r2
mul_pp r3.x, r2.y, r2.z
cmp_pp r2.z, -r2.w, c17, c17.y
mov r1, c2
abs_pp r2.x, r2
mul_pp r2.y, r2, r2.z
cmp r1, -r3.x, c17.y, r1
cmp r1, -r2.y, r1, r0
add r2.y, -v4.x, v4
cmp r2.y, r2, c17, c17.z
cmp_pp r2.x, -r2, c17.z, c17.y
mul_pp r2.w, r2.x, r2.y
abs_pp r2.z, r2.y
cmp_pp r2.y, -r2.z, c17.z, c17
cmp r1, -r2.w, r1, c17.y
mul_pp r2.x, r2, r2.y
cmp oC0, -r2.x, r1, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [_MoveTex] 2D 4
"3.0-!!ARBfp1.0
PARAM c[19] = { program.local[0..16],
		{ 0.5, 0, 1, 0.029999999 },
		{ 2, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0, c[3];
TEX R2.yzw, fragment.texcoord[0], texture[1], 2D;
ADD R0, -R0, c[6];
MAD R0, R2.w, R0, c[3];
ADD R1, -R0, c[5];
MAD R0, R2.z, R1, R0;
MOV R1.x, c[17].z;
TEX R1.yw, fragment.texcoord[0], texture[2], 2D;
MAD R3.xy, R1.wyzw, c[18].x, -R1.x;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R2.x, R3.z, R3.w;
ADD R1, -R0, c[4];
MAD R1, R2.y, R1, R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, R1;
ADD R2.x, -R2, c[17].z;
RSQ R1.w, R2.x;
RCP R3.z, R1.w;
MOV R1.w, c[7].x;
SGE R2.xyz, R2.yzww, c[17].x;
DP3 R3.w, R3, fragment.texcoord[5];
ADD R1.w, -R1, c[10].x;
MAD R1.w, R2.z, R1, c[7].x;
ADD R2.z, -R1.w, c[9].x;
MAD R1.w, R2.y, R2.z, R1;
DP3 R2.y, fragment.texcoord[6], fragment.texcoord[6];
MUL R1.xyz, R0, c[0];
MAX R2.w, R3, c[17].y;
MUL R1.xyz, R1, R2.w;
RSQ R2.y, R2.y;
MOV R4.xyz, fragment.texcoord[5];
MAD R4.xyz, R2.y, fragment.texcoord[6], R4;
ADD R2.y, -R1.w, c[8].x;
MAD R1.w, R2.x, R2.y, R1;
MUL R2.w, R1, R1;
DP3 R2.z, R4, R4;
ADD R2.w, R2, c[17];
RSQ R2.x, R2.z;
MUL R2.xyz, R2.x, R4;
DP3 R2.x, R3, R2;
MUL R3.xyz, R0, fragment.texcoord[4];
MUL R0.w, R2, R0;
MAX R2.w, R2.x, c[17].y;
MUL R1.w, R1, c[18].y;
POW R1.w, R2.w, R1.w;
MOV R2.xyz, c[1];
MUL R0.w, R0, R1;
MUL R2.xyz, R2, c[0];
MUL R2.xyz, R0.w, R2;
MAD R2.xyz, R2, c[18].x, R1;
TXP R1.x, fragment.texcoord[7], texture[3], 2D;
MUL R0.x, R1, c[18];
MAD R2.xyz, R2, R0.x, R3;
TEX R0.y, fragment.color.secondary.zwzw, texture[4], 2D;
MUL R1, R0.y, c[15];
TEX R0.x, fragment.texcoord[0].zwzw, texture[4], 2D;
MUL R0, R0.x, c[14];
MAD R0, R0, c[16].x, R1;
MOV R2.w, c[17].z;
ADD R1.z, fragment.color.primary, -c[17].x;
ADD R1.y, fragment.color.primary, c[12].x;
ADD R0, R0, -R2;
SIN R1.x, c[13].x;
MAD R0, R1.x, R0, R2;
SLT R1.x, fragment.color.primary, fragment.color.primary.y;
SLT R1.z, fragment.color.primary.x, R1;
SLT R1.y, fragment.color.primary.x, R1;
MUL R1.w, R1.y, R1.z;
ABS R1.z, R1.x;
MOV R1.xy, c[17];
SLT R2.x, c[11], R1;
CMP R1.z, -R1, c[17].y, c[17];
MUL R2.y, R2.x, R1.z;
ABS R1.x, R1.w;
ABS R2.x, R2;
CMP R2.z, -R1.x, c[17].y, c[17];
MUL R1.z, R2.y, R1.w;
MUL R2.y, R2, R2.z;
CMP R1, -R1.z, c[2], R1.y;
CMP R1, -R2.y, R0, R1;
SLT R2.y, fragment.color.primary, fragment.color.primary.x;
CMP R2.x, -R2, c[17].y, c[17].z;
MUL R2.w, R2.x, R2.y;
ABS R2.z, R2.y;
CMP R2.y, -R2.z, c[17], c[17].z;
CMP R1, -R2.w, c[17].y, R1;
MUL R2.x, R2, R2.y;
CMP result.color, -R2.x, R0, R1;
END
# 88 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [_MoveTex] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c17, -0.50000000, 0.00000000, 1.00000000, 0.03000000
def c18, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c19, 2.00000000, -1.00000000, 128.00000000, 0
dcl_texcoord0 v0
dcl_texcoord4 v1.xyz
dcl_texcoord5 v2.xyz
dcl_texcoord6 v3.xyz
dcl_color0 v4.xyz
dcl_color1 v5.xyzw
dcl_texcoord7 v6
texld r3.yw, v0, s2
mad_pp r3.xy, r3.wyzw, c19.x, c19.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
add_pp_sat r2.x, r3.z, r3.w
mov r0, c6
add_pp r2.x, -r2, c17.z
rsq_pp r2.x, r2.x
texld r2.yzw, v0, s1
add r0, -c3, r0
mad r0, r2.w, r0, c3
add r1, -r0, c5
mad r0, r2.z, r1, r0
add r1, -r0, c4
mad r1, r2.y, r1, r0
rcp_pp r3.z, r2.x
add r2.xyz, r2.yzww, c17.x
mov_pp r3.w, c10.x
texld r0, v0, s0
mul r0, r0, r1
cmp r2.xyz, r2, c17.z, c17.y
add_pp r2.w, -c7.x, r3
mad_pp r2.z, r2, r2.w, c7.x
dp3_pp r1.w, r3, v2
max_pp r2.w, r1, c17.y
mul_pp r1.xyz, r0, c0
add_pp r1.w, -r2.z, c9.x
mad_pp r1.w, r2.y, r1, r2.z
dp3_pp r2.y, v3, v3
mul_pp r1.xyz, r1, r2.w
rsq_pp r2.y, r2.y
mov_pp r4.xyz, v2
mad_pp r4.xyz, r2.y, v3, r4
add_pp r2.y, -r1.w, c8.x
mad_pp r1.w, r2.x, r2.y, r1
mul_pp r2.w, r1, r1
dp3_pp r2.z, r4, r4
add r3.w, r2, c17
rsq_pp r2.x, r2.z
mul_pp r2.xyz, r2.x, r4
dp3_pp r2.x, r3, r2
mul_pp r3.x, r1.w, c19.z
max_pp r1.w, r2.x, c17.y
pow r2, r1.w, r3.x
mov r1.w, r2.x
mov_pp r3.xyz, c0
mul_pp r2.xyz, c1, r3
mul r3.xyz, r0, v1
mul r0.w, r3, r0
mul r0.w, r0, r1
mul r2.xyz, r0.w, r2
mad r2.xyz, r2, c19.x, r1
texldp r1.x, v6, s3
mul_pp r0.x, r1, c19
mad r2.xyz, r2, r0.x, r3
texld r0.x, v0.zwzw, s4
mov r0.y, c13.x
mul r1, r0.x, c14
mad r0.x, r0.y, c18, c18.y
frc r2.w, r0.x
texld r0.y, v5.zwzw, s4
mul r0, r0.y, c15
mad r1, r1, c16.x, r0
mad r2.w, r2, c18.z, c18
sincos r0.xy, r2.w
mov r2.w, c17.z
add r1, r1, -r2
mad r0, r0.y, r1, r2
add r2.y, v4.z, c17.x
add r2.x, v4.y, c12
add r2.y, v4.x, -r2
add r2.x, v4, -r2
cmp r2.y, r2, c17, c17.z
cmp r2.x, r2, c17.y, c17.z
mul_pp r2.z, r2.x, r2.y
mov r2.x, c11
add_pp r2.y, v4.x, -v4
add r2.x, c17, r2
abs_pp r2.w, r2.z
cmp r2.x, r2, c17.y, c17.z
cmp_pp r2.y, r2, c17.z, c17
mul_pp r2.y, r2.x, r2
mul_pp r3.x, r2.y, r2.z
cmp_pp r2.z, -r2.w, c17, c17.y
mov r1, c2
abs_pp r2.x, r2
mul_pp r2.y, r2, r2.z
cmp r1, -r3.x, c17.y, r1
cmp r1, -r2.y, r1, r0
add r2.y, -v4.x, v4
cmp r2.y, r2, c17, c17.z
cmp_pp r2.x, -r2, c17.z, c17.y
mul_pp r2.w, r2.x, r2.y
abs_pp r2.z, r2.y
cmp_pp r2.y, -r2.z, c17.z, c17
cmp r1, -r2.w, r1, c17.y
mul_pp r2.x, r2, r2.y
cmp oC0, -r2.x, r1, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [_MoveTex] 2D 4
"3.0-!!ARBfp1.0
PARAM c[19] = { program.local[0..16],
		{ 0.5, 0, 1, 0.029999999 },
		{ 2, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0, c[3];
TEX R2.yzw, fragment.texcoord[0], texture[1], 2D;
ADD R0, -R0, c[6];
MAD R0, R2.w, R0, c[3];
ADD R1, -R0, c[5];
MAD R0, R2.z, R1, R0;
MOV R1.x, c[17].z;
TEX R1.yw, fragment.texcoord[0], texture[2], 2D;
MAD R3.xy, R1.wyzw, c[18].x, -R1.x;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R2.x, R3.z, R3.w;
ADD R1, -R0, c[4];
MAD R1, R2.y, R1, R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, R1;
ADD R2.x, -R2, c[17].z;
RSQ R1.w, R2.x;
RCP R3.z, R1.w;
MOV R1.w, c[7].x;
SGE R2.xyz, R2.yzww, c[17].x;
DP3 R3.w, R3, fragment.texcoord[5];
ADD R1.w, -R1, c[10].x;
MAD R1.w, R2.z, R1, c[7].x;
ADD R2.z, -R1.w, c[9].x;
MAD R1.w, R2.y, R2.z, R1;
DP3 R2.y, fragment.texcoord[6], fragment.texcoord[6];
MUL R1.xyz, R0, c[0];
MAX R2.w, R3, c[17].y;
MUL R1.xyz, R1, R2.w;
RSQ R2.y, R2.y;
MOV R4.xyz, fragment.texcoord[5];
MAD R4.xyz, R2.y, fragment.texcoord[6], R4;
ADD R2.y, -R1.w, c[8].x;
MAD R1.w, R2.x, R2.y, R1;
MUL R2.w, R1, R1;
DP3 R2.z, R4, R4;
ADD R2.w, R2, c[17];
RSQ R2.x, R2.z;
MUL R2.xyz, R2.x, R4;
DP3 R2.x, R3, R2;
MUL R3.xyz, R0, fragment.texcoord[4];
MUL R0.w, R2, R0;
MAX R2.w, R2.x, c[17].y;
MUL R1.w, R1, c[18].y;
POW R1.w, R2.w, R1.w;
MOV R2.xyz, c[1];
MUL R0.w, R0, R1;
MUL R2.xyz, R2, c[0];
MUL R2.xyz, R0.w, R2;
MAD R2.xyz, R2, c[18].x, R1;
TXP R1.x, fragment.texcoord[7], texture[3], 2D;
MUL R0.x, R1, c[18];
MAD R2.xyz, R2, R0.x, R3;
TEX R0.y, fragment.color.secondary.zwzw, texture[4], 2D;
MUL R1, R0.y, c[15];
TEX R0.x, fragment.texcoord[0].zwzw, texture[4], 2D;
MUL R0, R0.x, c[14];
MAD R0, R0, c[16].x, R1;
MOV R2.w, c[17].z;
ADD R1.z, fragment.color.primary, -c[17].x;
ADD R1.y, fragment.color.primary, c[12].x;
ADD R0, R0, -R2;
SIN R1.x, c[13].x;
MAD R0, R1.x, R0, R2;
SLT R1.x, fragment.color.primary, fragment.color.primary.y;
SLT R1.z, fragment.color.primary.x, R1;
SLT R1.y, fragment.color.primary.x, R1;
MUL R1.w, R1.y, R1.z;
ABS R1.z, R1.x;
MOV R1.xy, c[17];
SLT R2.x, c[11], R1;
CMP R1.z, -R1, c[17].y, c[17];
MUL R2.y, R2.x, R1.z;
ABS R1.x, R1.w;
ABS R2.x, R2;
CMP R2.z, -R1.x, c[17].y, c[17];
MUL R1.z, R2.y, R1.w;
MUL R2.y, R2, R2.z;
CMP R1, -R1.z, c[2], R1.y;
CMP R1, -R2.y, R0, R1;
SLT R2.y, fragment.color.primary, fragment.color.primary.x;
CMP R2.x, -R2, c[17].y, c[17].z;
MUL R2.w, R2.x, R2.y;
ABS R2.z, R2.y;
CMP R2.y, -R2.z, c[17], c[17].z;
CMP R1, -R2.w, c[17].y, R1;
MUL R2.x, R2, R2.y;
CMP result.color, -R2.x, R0, R1;
END
# 88 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [_MoveTex] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c17, -0.50000000, 0.00000000, 1.00000000, 0.03000000
def c18, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c19, 2.00000000, -1.00000000, 128.00000000, 0
dcl_texcoord0 v0
dcl_texcoord4 v1.xyz
dcl_texcoord5 v2.xyz
dcl_texcoord6 v3.xyz
dcl_color0 v4.xyz
dcl_color1 v5.xyzw
dcl_texcoord7 v6
texld r3.yw, v0, s2
mad_pp r3.xy, r3.wyzw, c19.x, c19.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
add_pp_sat r2.x, r3.z, r3.w
mov r0, c6
add_pp r2.x, -r2, c17.z
rsq_pp r2.x, r2.x
texld r2.yzw, v0, s1
add r0, -c3, r0
mad r0, r2.w, r0, c3
add r1, -r0, c5
mad r0, r2.z, r1, r0
add r1, -r0, c4
mad r1, r2.y, r1, r0
rcp_pp r3.z, r2.x
add r2.xyz, r2.yzww, c17.x
mov_pp r3.w, c10.x
texld r0, v0, s0
mul r0, r0, r1
cmp r2.xyz, r2, c17.z, c17.y
add_pp r2.w, -c7.x, r3
mad_pp r2.z, r2, r2.w, c7.x
dp3_pp r1.w, r3, v2
max_pp r2.w, r1, c17.y
mul_pp r1.xyz, r0, c0
add_pp r1.w, -r2.z, c9.x
mad_pp r1.w, r2.y, r1, r2.z
dp3_pp r2.y, v3, v3
mul_pp r1.xyz, r1, r2.w
rsq_pp r2.y, r2.y
mov_pp r4.xyz, v2
mad_pp r4.xyz, r2.y, v3, r4
add_pp r2.y, -r1.w, c8.x
mad_pp r1.w, r2.x, r2.y, r1
mul_pp r2.w, r1, r1
dp3_pp r2.z, r4, r4
add r3.w, r2, c17
rsq_pp r2.x, r2.z
mul_pp r2.xyz, r2.x, r4
dp3_pp r2.x, r3, r2
mul_pp r3.x, r1.w, c19.z
max_pp r1.w, r2.x, c17.y
pow r2, r1.w, r3.x
mov r1.w, r2.x
mov_pp r3.xyz, c0
mul_pp r2.xyz, c1, r3
mul r3.xyz, r0, v1
mul r0.w, r3, r0
mul r0.w, r0, r1
mul r2.xyz, r0.w, r2
mad r2.xyz, r2, c19.x, r1
texldp r1.x, v6, s3
mul_pp r0.x, r1, c19
mad r2.xyz, r2, r0.x, r3
texld r0.x, v0.zwzw, s4
mov r0.y, c13.x
mul r1, r0.x, c14
mad r0.x, r0.y, c18, c18.y
frc r2.w, r0.x
texld r0.y, v5.zwzw, s4
mul r0, r0.y, c15
mad r1, r1, c16.x, r0
mad r2.w, r2, c18.z, c18
sincos r0.xy, r2.w
mov r2.w, c17.z
add r1, r1, -r2
mad r0, r0.y, r1, r2
add r2.y, v4.z, c17.x
add r2.x, v4.y, c12
add r2.y, v4.x, -r2
add r2.x, v4, -r2
cmp r2.y, r2, c17, c17.z
cmp r2.x, r2, c17.y, c17.z
mul_pp r2.z, r2.x, r2.y
mov r2.x, c11
add_pp r2.y, v4.x, -v4
add r2.x, c17, r2
abs_pp r2.w, r2.z
cmp r2.x, r2, c17.y, c17.z
cmp_pp r2.y, r2, c17.z, c17
mul_pp r2.y, r2.x, r2
mul_pp r3.x, r2.y, r2.z
cmp_pp r2.z, -r2.w, c17, c17.y
mov r1, c2
abs_pp r2.x, r2
mul_pp r2.y, r2, r2.z
cmp r1, -r3.x, c17.y, r1
cmp r1, -r2.y, r1, r0
add r2.y, -v4.x, v4
cmp r2.y, r2, c17, c17.z
cmp_pp r2.x, -r2, c17.z, c17.y
mul_pp r2.w, r2.x, r2.y
abs_pp r2.z, r2.y
cmp_pp r2.y, -r2.z, c17.z, c17
cmp r1, -r2.w, r1, c17.y
mul_pp r2.x, r2, r2.y
cmp oC0, -r2.x, r1, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [_MoveTex] 2D 4
"3.0-!!ARBfp1.0
PARAM c[19] = { program.local[0..16],
		{ 0.5, 0, 1, 0.029999999 },
		{ 2, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0, c[3];
TEX R2.yzw, fragment.texcoord[0], texture[1], 2D;
ADD R0, -R0, c[6];
MAD R0, R2.w, R0, c[3];
ADD R1, -R0, c[5];
MAD R0, R2.z, R1, R0;
MOV R1.x, c[17].z;
TEX R1.yw, fragment.texcoord[0], texture[2], 2D;
MAD R3.xy, R1.wyzw, c[18].x, -R1.x;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R2.x, R3.z, R3.w;
ADD R1, -R0, c[4];
MAD R1, R2.y, R1, R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, R1;
ADD R2.x, -R2, c[17].z;
RSQ R1.w, R2.x;
RCP R3.z, R1.w;
MOV R1.w, c[7].x;
SGE R2.xyz, R2.yzww, c[17].x;
DP3 R3.w, R3, fragment.texcoord[5];
ADD R1.w, -R1, c[10].x;
MAD R1.w, R2.z, R1, c[7].x;
ADD R2.z, -R1.w, c[9].x;
MAD R1.w, R2.y, R2.z, R1;
DP3 R2.y, fragment.texcoord[6], fragment.texcoord[6];
MUL R1.xyz, R0, c[0];
MAX R2.w, R3, c[17].y;
MUL R1.xyz, R1, R2.w;
RSQ R2.y, R2.y;
MOV R4.xyz, fragment.texcoord[5];
MAD R4.xyz, R2.y, fragment.texcoord[6], R4;
ADD R2.y, -R1.w, c[8].x;
MAD R1.w, R2.x, R2.y, R1;
MUL R2.w, R1, R1;
DP3 R2.z, R4, R4;
ADD R2.w, R2, c[17];
RSQ R2.x, R2.z;
MUL R2.xyz, R2.x, R4;
DP3 R2.x, R3, R2;
MUL R3.xyz, R0, fragment.texcoord[4];
MUL R0.w, R2, R0;
MAX R2.w, R2.x, c[17].y;
MUL R1.w, R1, c[18].y;
POW R1.w, R2.w, R1.w;
MOV R2.xyz, c[1];
MUL R0.w, R0, R1;
MUL R2.xyz, R2, c[0];
MUL R2.xyz, R0.w, R2;
MAD R2.xyz, R2, c[18].x, R1;
TXP R1.x, fragment.texcoord[7], texture[3], 2D;
MUL R0.x, R1, c[18];
MAD R2.xyz, R2, R0.x, R3;
TEX R0.y, fragment.color.secondary.zwzw, texture[4], 2D;
MUL R1, R0.y, c[15];
TEX R0.x, fragment.texcoord[0].zwzw, texture[4], 2D;
MUL R0, R0.x, c[14];
MAD R0, R0, c[16].x, R1;
MOV R2.w, c[17].z;
ADD R1.z, fragment.color.primary, -c[17].x;
ADD R1.y, fragment.color.primary, c[12].x;
ADD R0, R0, -R2;
SIN R1.x, c[13].x;
MAD R0, R1.x, R0, R2;
SLT R1.x, fragment.color.primary, fragment.color.primary.y;
SLT R1.z, fragment.color.primary.x, R1;
SLT R1.y, fragment.color.primary.x, R1;
MUL R1.w, R1.y, R1.z;
ABS R1.z, R1.x;
MOV R1.xy, c[17];
SLT R2.x, c[11], R1;
CMP R1.z, -R1, c[17].y, c[17];
MUL R2.y, R2.x, R1.z;
ABS R1.x, R1.w;
ABS R2.x, R2;
CMP R2.z, -R1.x, c[17].y, c[17];
MUL R1.z, R2.y, R1.w;
MUL R2.y, R2, R2.z;
CMP R1, -R1.z, c[2], R1.y;
CMP R1, -R2.y, R0, R1;
SLT R2.y, fragment.color.primary, fragment.color.primary.x;
CMP R2.x, -R2, c[17].y, c[17].z;
MUL R2.w, R2.x, R2.y;
ABS R2.z, R2.y;
CMP R2.y, -R2.z, c[17], c[17].z;
CMP R1, -R2.w, c[17].y, R1;
MUL R2.x, R2, R2.y;
CMP result.color, -R2.x, R0, R1;
END
# 88 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_TransitionColor]
Vector 3 [_Color]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ClothColor]
Float 7 [_Shininess]
Float 8 [_MetalShininess]
Float 9 [_SkinShininess]
Float 10 [_ClothShininess]
Float 11 [_NeedInvt]
Float 12 [_OffsetWidth]
Float 13 [_EffectColorWeight]
Vector 14 [_MoveRedCol]
Vector 15 [_MoveGreenCol]
Float 16 [_EmissivePara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [_MoveTex] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c17, -0.50000000, 0.00000000, 1.00000000, 0.03000000
def c18, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c19, 2.00000000, -1.00000000, 128.00000000, 0
dcl_texcoord0 v0
dcl_texcoord4 v1.xyz
dcl_texcoord5 v2.xyz
dcl_texcoord6 v3.xyz
dcl_color0 v4.xyz
dcl_color1 v5.xyzw
dcl_texcoord7 v6
texld r3.yw, v0, s2
mad_pp r3.xy, r3.wyzw, c19.x, c19.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
add_pp_sat r2.x, r3.z, r3.w
mov r0, c6
add_pp r2.x, -r2, c17.z
rsq_pp r2.x, r2.x
texld r2.yzw, v0, s1
add r0, -c3, r0
mad r0, r2.w, r0, c3
add r1, -r0, c5
mad r0, r2.z, r1, r0
add r1, -r0, c4
mad r1, r2.y, r1, r0
rcp_pp r3.z, r2.x
add r2.xyz, r2.yzww, c17.x
mov_pp r3.w, c10.x
texld r0, v0, s0
mul r0, r0, r1
cmp r2.xyz, r2, c17.z, c17.y
add_pp r2.w, -c7.x, r3
mad_pp r2.z, r2, r2.w, c7.x
dp3_pp r1.w, r3, v2
max_pp r2.w, r1, c17.y
mul_pp r1.xyz, r0, c0
add_pp r1.w, -r2.z, c9.x
mad_pp r1.w, r2.y, r1, r2.z
dp3_pp r2.y, v3, v3
mul_pp r1.xyz, r1, r2.w
rsq_pp r2.y, r2.y
mov_pp r4.xyz, v2
mad_pp r4.xyz, r2.y, v3, r4
add_pp r2.y, -r1.w, c8.x
mad_pp r1.w, r2.x, r2.y, r1
mul_pp r2.w, r1, r1
dp3_pp r2.z, r4, r4
add r3.w, r2, c17
rsq_pp r2.x, r2.z
mul_pp r2.xyz, r2.x, r4
dp3_pp r2.x, r3, r2
mul_pp r3.x, r1.w, c19.z
max_pp r1.w, r2.x, c17.y
pow r2, r1.w, r3.x
mov r1.w, r2.x
mov_pp r3.xyz, c0
mul_pp r2.xyz, c1, r3
mul r3.xyz, r0, v1
mul r0.w, r3, r0
mul r0.w, r0, r1
mul r2.xyz, r0.w, r2
mad r2.xyz, r2, c19.x, r1
texldp r1.x, v6, s3
mul_pp r0.x, r1, c19
mad r2.xyz, r2, r0.x, r3
texld r0.x, v0.zwzw, s4
mov r0.y, c13.x
mul r1, r0.x, c14
mad r0.x, r0.y, c18, c18.y
frc r2.w, r0.x
texld r0.y, v5.zwzw, s4
mul r0, r0.y, c15
mad r1, r1, c16.x, r0
mad r2.w, r2, c18.z, c18
sincos r0.xy, r2.w
mov r2.w, c17.z
add r1, r1, -r2
mad r0, r0.y, r1, r2
add r2.y, v4.z, c17.x
add r2.x, v4.y, c12
add r2.y, v4.x, -r2
add r2.x, v4, -r2
cmp r2.y, r2, c17, c17.z
cmp r2.x, r2, c17.y, c17.z
mul_pp r2.z, r2.x, r2.y
mov r2.x, c11
add_pp r2.y, v4.x, -v4
add r2.x, c17, r2
abs_pp r2.w, r2.z
cmp r2.x, r2, c17.y, c17.z
cmp_pp r2.y, r2, c17.z, c17
mul_pp r2.y, r2.x, r2
mul_pp r3.x, r2.y, r2.z
cmp_pp r2.z, -r2.w, c17, c17.y
mov r1, c2
abs_pp r2.x, r2
mul_pp r2.y, r2, r2.z
cmp r1, -r3.x, c17.y, r1
cmp r1, -r2.y, r1, r0
add r2.y, -v4.x, v4
cmp r2.y, r2, c17, c17.z
cmp_pp r2.x, -r2, c17.z, c17.y
mul_pp r2.w, r2.x, r2.y
abs_pp r2.z, r2.y
cmp_pp r2.y, -r2.z, c17.z, c17
cmp r1, -r2.w, r1, c17.y
mul_pp r2.x, r2, r2.y
cmp oC0, -r2.x, r1, r0
"
}
}
 }
}
}