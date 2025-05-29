ÀšShader "Custom/BOL_Charactor_BRDF_DeathFading" {
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
 _FadingMap ("Fading map", 2D) = "white" {}
 _Fading_Time ("Fading Time", Float) = 5
}
SubShader { 
 LOD 400
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "RenderType"="Opaque" }
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
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
Vector 23 [_MainTex_ST]
Vector 24 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[25] = { { 1 },
		state.matrix.mvp,
		program.local[5..24] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[22].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0].x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[17];
DP4 R2.y, R0, c[16];
DP4 R2.x, R0, c[15];
MUL R0.w, R2, R2;
MAD R0.w, R0.x, R0.x, -R0;
DP4 R0.z, R1, c[20];
DP4 R0.y, R1, c[19];
DP4 R0.x, R1, c[18];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R0.w, c[21];
ADD result.texcoord[2].xyz, R0, R1;
MOV R1.xyz, c[13];
MOV R1.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[22].w, -vertex.position;
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0, c[14];
MUL R1.xyz, R1, vertex.attrib[14].w;
DP4 R3.z, R0, c[11];
DP4 R3.y, R0, c[10];
DP4 R3.x, R0, c[9];
DP3 result.texcoord[1].y, R3, R1;
DP3 result.texcoord[3].y, R1, R2;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R2;
DP3 result.texcoord[3].x, vertex.attrib[14], R2;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 44 instructions, 4 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"vs_2_0
def c24, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c21.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c24.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
dp4 r2.x, r0, c14
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c19
dp4 r0.y, r1, c18
dp4 r0.x, r1, c17
mul r1.xyz, r0.w, c20
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov r0.w, c24.x
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c21.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c13, r0
mov r0, c9
mov r1, c8
dp4 r4.y, c13, r0
dp4 r4.x, c13, r1
dp3 oT1.y, r4, r2
dp3 oT3.y, r2, r3
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT3.z, v2, r3
dp3 oT3.x, v1, r3
mad oT0.zw, v3.xyxy, c23.xyxy, c23
mad oT0.xy, v3, c22, c22.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 14 [unity_LightmapST]
Vector 15 [_MainTex_ST]
Vector 16 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[17] = { program.local[0],
		state.matrix.mvp,
		program.local[5..16] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[14], c[14].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 7 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 12 [unity_LightmapST]
Vector 13 [_MainTex_ST]
Vector 14 [_BumpMap_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v3
dcl_texcoord1 v4
mad oT0.zw, v3.xyxy, c14.xyxy, c14
mad oT0.xy, v3, c13, c13.zwzw
mad oT1.xy, v4, c12, c12.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[19] = { { 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, R0, vertex.attrib[14].w;
MOV R0.xyz, c[13];
MOV R0.w, c[0].x;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R0.xyz, R2, c[15].w, -vertex.position;
DP3 result.texcoord[2].y, R0, R1;
DP3 result.texcoord[2].z, vertex.normal, R0;
DP3 result.texcoord[2].x, R0, vertex.attrib[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[17], c[17].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[16], c[16].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 20 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_Scale]
Vector 14 [unity_LightmapST]
Vector 15 [_MainTex_ST]
Vector 16 [_BumpMap_ST]
"vs_2_0
def c17, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, r0, v1.w
mov r0.xyz, c12
mov r0.w, c17.x
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r0.xyz, r2, c13.w, -v0
dp3 oT2.y, r0, r1
dp3 oT2.z, v2, r0
dp3 oT2.x, r0, v1
mad oT0.zw, v3.xyxy, c16.xyxy, c16
mad oT0.xy, v3, c15, c15.zwzw
mad oT1.xy, v4, c14, c14.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
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
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [_WorldSpaceLightPos0]
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
"!!ARBvp1.0
PARAM c[26] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..25] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[23].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MOV R0.w, c[0].x;
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
ADD result.texcoord[2].xyz, R0, R1;
MOV R1.xyz, c[13];
MOV R1.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[23].w, -vertex.position;
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0, c[15];
MUL R1.xyz, R1, vertex.attrib[14].w;
DP4 R3.z, R0, c[11];
DP4 R3.y, R0, c[10];
DP4 R3.x, R0, c[9];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
DP3 result.texcoord[1].y, R3, R1;
DP3 result.texcoord[3].y, R1, R2;
MUL R1.xyz, R0.xyww, c[0].y;
MUL R1.y, R1, c[14].x;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R2;
DP3 result.texcoord[3].x, vertex.attrib[14], R2;
ADD result.texcoord[4].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[4].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 49 instructions, 4 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [_WorldSpaceLightPos0]
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
"vs_2_0
def c26, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c23.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c26.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c18
dp4 r2.y, r0, c17
dp4 r2.x, r0, c16
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c21
dp4 r0.y, r1, c20
dp4 r0.x, r1, c19
mul r1.xyz, r0.w, c22
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov r0.w, c26.x
mov r0.xyz, c12
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c23.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c15, r0
mov r0, c9
dp4 r4.y, c15, r0
mov r1, c8
dp4 r4.x, c15, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c26.y
mul r1.y, r1, c13.x
dp3 oT1.y, r4, r2
dp3 oT3.y, r2, r3
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT3.z, v2, r3
dp3 oT3.x, v1, r3
mad oT4.xy, r1.z, c14.zwzw, r1
mov oPos, r0
mov oT4.zw, r0
mad oT0.zw, v3.xyxy, c25.xyxy, c25
mad oT0.xy, v3, c24, c24.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 13 [_ProjectionParams]
Vector 15 [unity_LightmapST]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[18] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[13].x;
ADD result.texcoord[2].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[2].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[15], c[15].zwzw;
END
# 12 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_LightmapST]
Vector 15 [_MainTex_ST]
Vector 16 [_BumpMap_ST]
"vs_2_0
def c17, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v3
dcl_texcoord1 v4
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c17.x
mul r1.y, r1, c12.x
mad oT2.xy, r1.z, c13.zwzw, r1
mov oPos, r0
mov oT2.zw, r0
mad oT0.zw, v3.xyxy, c16.xyxy, c16
mad oT0.xy, v3, c15, c15.zwzw
mad oT1.xy, v4, c14, c14.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 16 [unity_Scale]
Vector 17 [unity_LightmapST]
Vector 18 [_MainTex_ST]
Vector 19 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[20] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..19] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.xyz, c[13];
MOV R1.w, c[0].x;
DP4 R0.w, vertex.position, c[4];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[16].w, -vertex.position;
DP3 result.texcoord[2].y, R2, R0;
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].y;
MUL R1.y, R1, c[14].x;
DP3 result.texcoord[2].z, vertex.normal, R2;
DP3 result.texcoord[2].x, R2, vertex.attrib[14];
ADD result.texcoord[3].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[19].xyxy, c[19];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[17], c[17].zwzw;
END
# 25 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"vs_2_0
def c19, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r0.xyz, r0, v1.w
mov r1.xyz, c12
mov r1.w, c19.x
dp4 r0.w, v0, c3
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c15.w, -v0
dp3 oT2.y, r2, r0
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c19.y
mul r1.y, r1, c13.x
dp3 oT2.z, v2, r2
dp3 oT2.x, r2, v1
mad oT3.xy, r1.z, c14.zwzw, r1
mov oPos, r0
mov oT3.zw, r0
mad oT0.zw, v3.xyxy, c18.xyxy, c18
mad oT0.xy, v3, c17, c17.zwzw
mad oT1.xy, v4, c16, c16.zwzw
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
Vector 31 [_MainTex_ST]
Vector 32 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[33] = { { 1, 0 },
		state.matrix.mvp,
		program.local[5..32] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R3.xyz, vertex.normal, c[30].w;
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[16];
DP3 R3.w, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[15];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0].x;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[17];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[18];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[20];
MAD R1.xyz, R0.x, c[19], R1;
MAD R0.xyz, R0.z, c[21], R1;
MAD R1.xyz, R0.w, c[22], R0;
MUL R0, R4.xyzz, R4.yzzx;
MUL R1.w, R3, R3;
DP4 R3.z, R0, c[28];
DP4 R3.y, R0, c[27];
DP4 R3.x, R0, c[26];
MAD R1.w, R4.x, R4.x, -R1;
MUL R0.xyz, R1.w, c[29];
MOV R1.w, c[0].x;
DP4 R2.z, R4, c[25];
DP4 R2.y, R4, c[24];
DP4 R2.x, R4, c[23];
ADD R2.xyz, R2, R3;
ADD R0.xyz, R2, R0;
ADD result.texcoord[2].xyz, R0, R1;
MOV R1.xyz, c[13];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[30].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1, c[14];
MUL R0.xyz, R0, vertex.attrib[14].w;
DP4 R3.z, R1, c[11];
DP4 R3.y, R1, c[10];
DP4 R3.x, R1, c[9];
DP3 result.texcoord[1].y, R3, R0;
DP3 result.texcoord[3].y, R0, R2;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R2;
DP3 result.texcoord[3].x, vertex.attrib[14], R2;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[32].xyxy, c[32];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[31], c[31].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 75 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_4LightPosX0]
Vector 15 [unity_4LightPosY0]
Vector 16 [unity_4LightPosZ0]
Vector 17 [unity_4LightAtten0]
Vector 18 [unity_LightColor0]
Vector 19 [unity_LightColor1]
Vector 20 [unity_LightColor2]
Vector 21 [unity_LightColor3]
Vector 22 [unity_SHAr]
Vector 23 [unity_SHAg]
Vector 24 [unity_SHAb]
Vector 25 [unity_SHBr]
Vector 26 [unity_SHBg]
Vector 27 [unity_SHBb]
Vector 28 [unity_SHC]
Vector 29 [unity_Scale]
Vector 30 [_MainTex_ST]
Vector 31 [_BumpMap_ST]
"vs_2_0
def c32, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r3.xyz, v2, c29.w
dp4 r0.x, v0, c5
add r1, -r0.x, c15
dp3 r3.w, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c14
mul r1, r1, r1
mov r4.z, r3.x
mad r2, r4.x, r0, r2
mov r4.w, c32.x
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c16
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c17
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c32.x
dp4 r2.z, r4, c24
dp4 r2.y, r4, c23
dp4 r2.x, r4, c22
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c32.y
mul r0, r0, r1
mul r1.xyz, r0.y, c19
mad r1.xyz, r0.x, c18, r1
mad r0.xyz, r0.z, c20, r1
mad r1.xyz, r0.w, c21, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r3, r3
dp4 r3.z, r0, c27
dp4 r3.y, r0, c26
dp4 r3.x, r0, c25
mad r1.w, r4.x, r4.x, -r1
mul r0.xyz, r1.w, c28
add r2.xyz, r2, r3
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov r1.w, c32.x
mov r1.xyz, c12
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
mad r3.xyz, r0, c29.w, -v0
mov r1.xyz, v1
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r1.yzxw
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c13, r0
mov r1, c9
mov r0, c8
dp4 r4.y, c13, r1
dp4 r4.x, c13, r0
dp3 oT1.y, r4, r2
dp3 oT3.y, r2, r3
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT3.z, v2, r3
dp3 oT3.x, v1, r3
mad oT0.zw, v3.xyxy, c31.xyxy, c31
mad oT0.xy, v3, c30, c30.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
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
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
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
Vector 32 [_MainTex_ST]
Vector 33 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[34] = { { 1, 0, 0.5 },
		state.matrix.mvp,
		program.local[5..33] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R3.xyz, vertex.normal, c[31].w;
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[17];
DP3 R3.w, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[16];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0].x;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[18];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[19];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[21];
MAD R1.xyz, R0.x, c[20], R1;
MAD R0.xyz, R0.z, c[22], R1;
MAD R1.xyz, R0.w, c[23], R0;
MUL R0, R4.xyzz, R4.yzzx;
MUL R1.w, R3, R3;
DP4 R3.z, R0, c[29];
DP4 R3.y, R0, c[28];
DP4 R3.x, R0, c[27];
MAD R1.w, R4.x, R4.x, -R1;
MUL R0.xyz, R1.w, c[30];
MOV R1.w, c[0].x;
DP4 R0.w, vertex.position, c[4];
DP4 R2.z, R4, c[26];
DP4 R2.y, R4, c[25];
DP4 R2.x, R4, c[24];
ADD R2.xyz, R2, R3;
ADD R0.xyz, R2, R0;
ADD result.texcoord[2].xyz, R0, R1;
MOV R1.xyz, c[13];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[31].w, -vertex.position;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1, c[15];
MUL R0.xyz, R0, vertex.attrib[14].w;
DP4 R3.z, R1, c[11];
DP4 R3.y, R1, c[10];
DP4 R3.x, R1, c[9];
DP3 result.texcoord[1].y, R3, R0;
DP3 result.texcoord[3].y, R0, R2;
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].z;
MUL R1.y, R1, c[14].x;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R2;
DP3 result.texcoord[3].x, vertex.attrib[14], R2;
ADD result.texcoord[4].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[4].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[33].xyxy, c[33];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[32], c[32].zwzw;
END
# 80 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
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
Vector 32 [_MainTex_ST]
Vector 33 [_BumpMap_ST]
"vs_2_0
def c34, 1.00000000, 0.00000000, 0.50000000, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r3.xyz, v2, c31.w
dp4 r0.x, v0, c5
add r1, -r0.x, c17
dp3 r3.w, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c16
mul r1, r1, r1
mov r4.z, r3.x
mad r2, r4.x, r0, r2
mov r4.w, c34.x
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c18
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c19
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c34.x
dp4 r2.z, r4, c26
dp4 r2.y, r4, c25
dp4 r2.x, r4, c24
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c34.y
mul r0, r0, r1
mul r1.xyz, r0.y, c21
mad r1.xyz, r0.x, c20, r1
mad r0.xyz, r0.z, c22, r1
mad r1.xyz, r0.w, c23, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r3, r3
dp4 r3.z, r0, c29
dp4 r3.y, r0, c28
dp4 r3.x, r0, c27
mad r1.w, r4.x, r4.x, -r1
mul r0.xyz, r1.w, c30
add r2.xyz, r2, r3
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov r1.w, c34.x
mov r1.xyz, c12
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
mad r3.xyz, r0, c31.w, -v0
mov r1.xyz, v1
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r1.yzxw
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c15, r0
mov r0, c8
dp4 r4.x, c15, r0
mov r1, c9
dp4 r4.y, c15, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c34.z
mul r1.y, r1, c13.x
dp3 oT1.y, r4, r2
dp3 oT3.y, r2, r3
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT3.z, v2, r3
dp3 oT3.x, v1, r3
mad oT4.xy, r1.z, c14.zwzw, r1
mov oPos, r0
mov oT4.zw, r0
mad oT0.zw, v3.xyxy, c33.xyxy, c33
mad oT0.xy, v3, c32, c32.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[10] = { program.local[0..7],
		{ 0.5, 0.029999999, 2, 1 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R3.yzw, fragment.texcoord[0], texture[1], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R4.yw, fragment.texcoord[0].zwzw, texture[2], 2D;
MOV R1, c[2];
ADD R1, -R1, c[5];
MAD R1, R3.w, R1, c[2];
ADD R2, -R1, c[4];
MAD R1, R3.z, R2, R1;
ADD R2, -R1, c[3];
MAD R1, R3.y, R2, R1;
MUL R0, R0, R1;
DP3 R2.w, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xy, R4.wyzw, c[8].z, -c[8].w;
RSQ R2.w, R2.w;
MOV R2.xyz, fragment.texcoord[1];
MAD R2.xyz, R2.w, fragment.texcoord[3], R2;
DP3 R1.z, R2, R2;
RSQ R2.w, R1.z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
SGE R3.xy, R3.yzzw, c[8].x;
ADD R1.z, -R1, c[8].w;
RSQ R1.z, R1.z;
MUL R2.xyz, R2.w, R2;
RCP R1.z, R1.z;
DP3 R2.x, R1, R2;
MUL R1.w, -R3.y, c[7].x;
ADD R2.w, R1, c[6].x;
MAD R1.w, R3.x, R2, -R1;
MAX R2.y, R2.x, c[9].x;
DP3 R1.x, R1, fragment.texcoord[1];
MUL R2.x, R1.w, R1.w;
MUL R2.z, R1.w, c[9].y;
ADD R1.w, R2.x, c[8].y;
MUL R0.w, R0, R1;
POW R2.x, R2.y, R2.z;
MUL R0.w, R0, R2.x;
MAX R2.w, R1.x, c[9].x;
MOV R1, c[1];
MUL R2.xyz, R0, c[0];
MUL R0.w, R0, c[8].z;
MUL R1.w, R1, c[0];
MUL R2.xyz, R2, R2.w;
MUL R1.xyz, R1, c[0];
MAD R1.xyz, R1, R0.w, R2;
MUL R1.xyz, R1, c[8].z;
MAD result.color.xyz, R0, fragment.texcoord[2], R1;
MUL result.color.w, R0, R1;
END
# 48 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c8, -0.50000000, 1.00000000, 0.00000000, 0.03000000
def c9, 2.00000000, -1.00000000, 128.00000000, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s1
texld r1, t0, s0
mov_pp r3, c5
add_pp r3, -c2, r3
mad_pp r3, r2.w, r3, c2
add_pp r4, -r3, c4
mad_pp r3, r2.z, r4, r3
add_pp r4, -r3, c3
add r5.yz, r2, c8.x
mad_pp r2, r2.y, r4, r3
dp3_pp r3.x, t3, t3
mul r1, r1, r2
cmp r3.yz, r5, c8.y, c8.z
mov r0.y, t0.w
mov r0.x, t0.z
rsq_pp r3.x, r3.x
texld r0, r0, s2
mul r0.x, -r3.z, c7
add r2.x, r0, c6
mov r4.x, r0.w
mov r4.y, r0
mad_pp r5.xy, r4, c9.x, c9.y
mad r0.x, r3.y, r2, -r0
mov_pp r4.xyz, t1
mad_pp r3.xyz, r3.x, t3, r4
mul_pp r2.xy, r5, r5
add_pp_sat r2.x, r2, r2.y
dp3_pp r4.x, r3, r3
rsq_pp r4.x, r4.x
add_pp r2.x, -r2, c8.y
rsq_pp r2.x, r2.x
mul_pp r3.xyz, r4.x, r3
rcp_pp r5.z, r2.x
dp3_pp r2.x, r5, r3
mul_pp r3.x, r0, c9.z
max_pp r2.x, r2, c8.z
pow r4.w, r2.x, r3.x
mov r2.x, r4.w
mul_pp r0.x, r0, r0
add r0.x, r0, c8.w
mul r0.x, r1.w, r0
mul r0.x, r0, r2
dp3_pp r2.x, r5, t1
mul r0.x, r0, c9
mul_pp r3.xyz, r1, c0
max_pp r2.x, r2, c8.z
mul_pp r2.xyz, r3, r2.x
mov_pp r4.xyz, c0
mul_pp r3.xyz, c1, r4
mad r2.xyz, r3, r0.x, r2
mov_pp r0.w, c0
mul_pp r3.x, c1.w, r0.w
mul r0.w, r0.x, r3.x
mul r2.xyz, r2, c9.x
mad_pp r0.xyz, r1, t2, r2
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[10] = { program.local[0..7],
		{ 0.5, 0.029999999, 2, 1 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R3.yzw, fragment.texcoord[0], texture[1], 2D;
TXP R3.x, fragment.texcoord[4], texture[3], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R4.yw, fragment.texcoord[0].zwzw, texture[2], 2D;
MOV R1, c[2];
ADD R1, -R1, c[5];
MAD R1, R3.w, R1, c[2];
ADD R2, -R1, c[4];
MAD R1, R3.z, R2, R1;
ADD R2, -R1, c[3];
MAD R1, R3.y, R2, R1;
MUL R0, R0, R1;
DP3 R2.w, fragment.texcoord[3], fragment.texcoord[3];
MAD R1.xy, R4.wyzw, c[8].z, -c[8].w;
RSQ R2.w, R2.w;
MOV R2.xyz, fragment.texcoord[1];
MAD R2.xyz, R2.w, fragment.texcoord[3], R2;
DP3 R1.z, R2, R2;
RSQ R2.w, R1.z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
SGE R3.zw, R3.xyyz, c[8].x;
ADD R1.z, -R1, c[8].w;
RSQ R1.z, R1.z;
MUL R2.xyz, R2.w, R2;
RCP R1.z, R1.z;
DP3 R2.x, R1, R2;
MUL R1.w, -R3, c[7].x;
ADD R2.w, R1, c[6].x;
MAD R1.w, R3.z, R2, -R1;
MAX R2.y, R2.x, c[9].x;
DP3 R1.x, R1, fragment.texcoord[1];
MUL R2.x, R1.w, R1.w;
MUL R2.z, R1.w, c[9].y;
ADD R1.w, R2.x, c[8].y;
MUL R0.w, R0, R1;
POW R2.x, R2.y, R2.z;
MUL R0.w, R0, R2.x;
MAX R2.w, R1.x, c[9].x;
MOV R1, c[1];
MUL R2.xyz, R0, c[0];
MUL R0.w, R0, c[8].z;
MUL R2.xyz, R2, R2.w;
MUL R1.xyz, R1, c[0];
MAD R1.xyz, R1, R0.w, R2;
MUL R2.x, R3, c[8].z;
MUL R1.w, R1, c[0];
MUL R1.xyz, R1, R2.x;
MUL R0.w, R0, R1;
MAD result.color.xyz, R0, fragment.texcoord[2], R1;
MUL result.color.w, R3.x, R0;
END
# 51 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c8, -0.50000000, 1.00000000, 0.00000000, 0.03000000
def c9, 2.00000000, -1.00000000, 128.00000000, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
texld r3, t0, s1
texld r2, t0, s0
texldp r1, t4, s3
add r1.yz, r3, c8.x
cmp r1.yz, r1, c8.y, c8.z
mov_pp r4, c5
add_pp r4, -c2, r4
mad_pp r4, r3.w, r4, c2
add_pp r5, -r4, c4
mad_pp r4, r3.z, r5, r4
add_pp r5, -r4, c3
mad_pp r3, r3.y, r5, r4
mul r2, r2, r3
mov_pp r5.xyz, t1
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s2
mul r0.x, -r1.z, c7
add r3.x, r0, c6
mov r4.x, r0.w
mov r4.y, r0
mad_pp r6.xy, r4, c9.x, c9.y
mad r0.x, r1.y, r3, -r0
mul_pp r3.xy, r6, r6
add_pp_sat r3.x, r3, r3.y
dp3_pp r4.x, t3, t3
rsq_pp r4.x, r4.x
mad_pp r4.xyz, r4.x, t3, r5
dp3_pp r5.x, r4, r4
rsq_pp r5.x, r5.x
add_pp r3.x, -r3, c8.y
rsq_pp r3.x, r3.x
mul_pp r4.xyz, r5.x, r4
rcp_pp r6.z, r3.x
dp3_pp r3.x, r6, r4
mul_pp r4.x, r0, c9.z
max_pp r3.x, r3, c8.z
pow r5.w, r3.x, r4.x
mov r3.x, r5.w
mul_pp r0.x, r0, r0
add r0.x, r0, c8.w
mul r0.x, r2.w, r0
mul r0.x, r0, r3
dp3_pp r3.x, r6, t1
mul r0.x, r0, c9
mul_pp r4.xyz, r2, c0
max_pp r3.x, r3, c8.z
mov_pp r5.xyz, c0
mul_pp r3.xyz, r4, r3.x
mul_pp r4.xyz, c1, r5
mad r3.xyz, r4, r0.x, r3
mov_pp r0.w, c0
mul_pp r4.x, c1.w, r0.w
mul r0.x, r0, r4
mul_pp r5.x, r1, c9
mul r0.w, r1.x, r0.x
mul r3.xyz, r3, r5.x
mad_pp r0.xyz, r2, t2, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "RenderType"="Opaque" }
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
Vector 19 [unity_Scale]
Vector 20 [_MainTex_ST]
Vector 21 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[22] = { { 1 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, c[17];
MOV R1.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[19].w, -vertex.position;
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0, c[18];
MUL R1.xyz, R1, vertex.attrib[14].w;
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R0.xyz, R3, c[19].w, -vertex.position;
DP3 result.texcoord[1].y, R0, R1;
DP3 result.texcoord[1].z, vertex.normal, R0;
DP3 result.texcoord[1].x, R0, vertex.attrib[14];
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[2].y, R1, R2;
DP3 result.texcoord[2].z, vertex.normal, R2;
DP3 result.texcoord[2].x, vertex.attrib[14], R2;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[21].xyxy, c[21];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[20], c[20].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 34 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_2_0
def c21, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c21.x
mov r0.xyz, c16
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c18.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c17, r0
mov r0, c9
dp4 r4.y, c17, r0
mov r1, c8
dp4 r4.x, c17, r1
mad r0.xyz, r4, c18.w, -v0
dp3 oT1.y, r0, r2
dp3 oT1.z, v2, r0
dp3 oT1.x, r0, v1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT2.y, r2, r3
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c20.xyxy, c20
mad oT0.xy, v3, c19, c19.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_World2Object]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_WorldSpaceLightPos0]
Vector 11 [unity_Scale]
Vector 12 [_MainTex_ST]
Vector 13 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[14] = { { 1 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, c[9];
MOV R1.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R2.z, R1, c[7];
DP4 R2.y, R1, c[6];
DP4 R2.x, R1, c[5];
MAD R2.xyz, R2, c[11].w, -vertex.position;
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0, c[10];
MUL R1.xyz, R1, vertex.attrib[14].w;
DP4 R3.z, R0, c[7];
DP4 R3.y, R0, c[6];
DP4 R3.x, R0, c[5];
DP3 result.texcoord[1].y, R3, R1;
DP3 result.texcoord[2].y, R1, R2;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[2].z, vertex.normal, R2;
DP3 result.texcoord[2].x, vertex.attrib[14], R2;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[13].xyxy, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[12], c[12].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 26 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_WorldSpaceLightPos0]
Vector 10 [unity_Scale]
Vector 11 [_MainTex_ST]
Vector 12 [_BumpMap_ST]
"vs_2_0
def c13, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c13.x
mov r0.xyz, c8
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
mad r3.xyz, r1, c10.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c6
dp4 r4.z, c9, r0
mov r0, c5
mov r1, c4
dp4 r4.y, c9, r0
dp4 r4.x, c9, r1
dp3 oT1.y, r4, r2
dp3 oT2.y, r2, r3
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
mad oT0.zw, v3.xyxy, c12.xyxy, c12
mad oT0.xy, v3, c11, c11.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
Vector 19 [unity_Scale]
Vector 20 [_MainTex_ST]
Vector 21 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[22] = { { 1 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, c[17];
MOV R1.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[19].w, -vertex.position;
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0, c[18];
MUL R1.xyz, R1, vertex.attrib[14].w;
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R0.xyz, R3, c[19].w, -vertex.position;
DP4 R0.w, vertex.position, c[8];
DP3 result.texcoord[1].y, R0, R1;
DP3 result.texcoord[1].z, vertex.normal, R0;
DP3 result.texcoord[1].x, R0, vertex.attrib[14];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[2].y, R1, R2;
DP3 result.texcoord[2].z, vertex.normal, R2;
DP3 result.texcoord[2].x, vertex.attrib[14], R2;
DP4 result.texcoord[3].w, R0, c[16];
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[21].xyxy, c[21];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[20], c[20].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 35 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_2_0
def c21, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c21.x
mov r0.xyz, c16
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c18.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c17, r0
mov r0, c9
dp4 r4.y, c17, r0
mov r1, c8
dp4 r4.x, c17, r1
mad r0.xyz, r4, c18.w, -v0
dp4 r0.w, v0, c7
dp3 oT1.y, r0, r2
dp3 oT1.z, v2, r0
dp3 oT1.x, r0, v1
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT2.y, r2, r3
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oT3.w, r0, c15
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c20.xyxy, c20
mad oT0.xy, v3, c19, c19.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
Vector 19 [unity_Scale]
Vector 20 [_MainTex_ST]
Vector 21 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[22] = { { 1 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, c[17];
MOV R1.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[19].w, -vertex.position;
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0, c[18];
MUL R1.xyz, R1, vertex.attrib[14].w;
DP4 R3.z, R0, c[11];
DP4 R3.x, R0, c[9];
DP4 R3.y, R0, c[10];
MAD R0.xyz, R3, c[19].w, -vertex.position;
DP3 result.texcoord[1].y, R0, R1;
DP3 result.texcoord[1].z, vertex.normal, R0;
DP3 result.texcoord[1].x, R0, vertex.attrib[14];
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[2].y, R1, R2;
DP3 result.texcoord[2].z, vertex.normal, R2;
DP3 result.texcoord[2].x, vertex.attrib[14], R2;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[21].xyxy, c[21];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[20], c[20].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 34 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_2_0
def c21, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c21.x
mov r0.xyz, c16
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c18.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c17, r0
mov r0, c9
dp4 r4.y, c17, r0
mov r1, c8
dp4 r4.x, c17, r1
mad r0.xyz, r4, c18.w, -v0
dp3 oT1.y, r0, r2
dp3 oT1.z, v2, r0
dp3 oT1.x, r0, v1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT2.y, r2, r3
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c20.xyxy, c20
mad oT0.xy, v3, c19, c19.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
Vector 19 [unity_Scale]
Vector 20 [_MainTex_ST]
Vector 21 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[22] = { { 1 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, c[17];
MOV R1.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MAD R2.xyz, R2, c[19].w, -vertex.position;
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R0, c[18];
MUL R1.xyz, R1, vertex.attrib[14].w;
DP4 R3.z, R0, c[11];
DP4 R3.y, R0, c[10];
DP4 R3.x, R0, c[9];
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP3 result.texcoord[1].y, R3, R1;
DP3 result.texcoord[2].y, R1, R2;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[2].z, vertex.normal, R2;
DP3 result.texcoord[2].x, vertex.attrib[14], R2;
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[21].xyxy, c[21];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[20], c[20].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 32 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_2_0
def c21, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c21.x
mov r0.xyz, c16
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c18.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c17, r0
mov r0, c9
dp4 r4.y, c17, r0
mov r1, c8
dp4 r4.x, c17, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT1.y, r4, r2
dp3 oT2.y, r2, r3
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c20.xyxy, c20
mad oT0.xy, v3, c19, c19.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
DP3 R3.x, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R0, c[2];
RSQ R3.x, R3.x;
MOV result.color.w, c[4].x;
TEX R2.w, R1.x, texture[2], 2D;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R1.x, R1.x;
MUL R2.xyz, R1.x, fragment.texcoord[1];
MAD R1.xy, R1.wyzw, c[4].y, -c[4].z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
MAD R3.xyz, R3.x, fragment.texcoord[2], R2;
DP3 R1.w, R3, R3;
RSQ R1.w, R1.w;
MUL R3.xyz, R1.w, R3;
ADD R1.z, -R1, c[4];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
DP3 R3.x, R1, R3;
MOV R1.w, c[4];
MUL R3.y, R1.w, c[3].x;
MAX R1.w, R3.x, c[4].x;
POW R1.w, R1.w, R3.y;
MUL R0.w, R1, R0;
DP3 R1.x, R1, R2;
MAX R1.w, R1.x, c[4].x;
MUL R1.xyz, R0, c[0];
MUL R1.xyz, R1, R1.w;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R1.w, R2, c[4].y;
MAD R0.xyz, R0, R0.w, R1;
MUL result.color.xyz, R0, R1.w;
END
# 36 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
dp3 r0.x, t3, t3
mov r1.xy, r0.x
mul_pp r2.xyz, r2, c2
mul_pp r2.xyz, r2, c0
mov r0.y, t0.w
mov r0.x, t0.z
texld r6, r1, s2
texld r0, r0, s1
mov r0.x, r0.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3_pp r1.x, t2, t2
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
mov_pp r0.x, c3
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r4, r1
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r5.x, r1.x, r0.x
dp3_pp r1.x, r4, r3
max_pp r1.x, r1, c4.w
mul_pp r3.xyz, r2, r1.x
mov r0.x, r5.x
mov_pp r2.xyz, c0
mul r0.x, r0, r2.w
mul_pp r2.xyz, c1, r2
mul_pp r1.x, r6, c4
mad r0.xyz, r2, r0.x, r3
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R1.xy, R1.wyzw, c[4].y, -c[4].z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
DP3 R2.w, fragment.texcoord[2], fragment.texcoord[2];
ADD R1.z, -R1, c[4];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
MUL R0.xyz, R0, c[2];
MOV R2.xyz, fragment.texcoord[1];
RSQ R2.w, R2.w;
MAD R2.xyz, R2.w, fragment.texcoord[2], R2;
DP3 R1.w, R2, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R2;
DP3 R2.x, R1, R2;
MOV R1.w, c[4];
MUL R2.y, R1.w, c[3].x;
MAX R1.w, R2.x, c[4].x;
POW R1.w, R1.w, R2.y;
MUL R0.w, R1, R0;
DP3 R1.w, R1, fragment.texcoord[1];
MUL R1.xyz, R0, c[0];
MAX R1.w, R1, c[4].x;
MOV R0.xyz, c[1];
MUL R1.xyz, R1, R1.w;
MUL R0.xyz, R0, c[0];
MAD R0.xyz, R0, R0.w, R1;
MUL result.color.xyz, R0, c[4].y;
MOV result.color.w, c[4].x;
END
# 31 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
texld r2, t0, s0
dp3_pp r1.x, t2, t2
rsq_pp r1.x, r1.x
mov_pp r3.xyz, t1
mad_pp r3.xyz, r1.x, t2, r3
mul_pp r2.xyz, r2, c2
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mov r0.x, r0.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
add_pp r1.x, -r0, c4.z
dp3_pp r0.x, r3, r3
rsq_pp r1.x, r1.x
rcp_pp r4.z, r1.x
rsq_pp r0.x, r0.x
mul_pp r1.xyz, r0.x, r3
dp3_pp r1.x, r4, r1
mov_pp r0.x, c3
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r3.w, r1.x, r0.x
mov r0.x, r3.w
mul_pp r3.xyz, r2, c0
dp3_pp r1.x, r4, t1
max_pp r1.x, r1, c4.w
mov_pp r2.xyz, c0
mul r0.x, r0, r2.w
mul_pp r1.xyz, r3, r1.x
mul_pp r2.xyz, c1, r2
mad r0.xyz, r2, r0.x, r1
mul r0.xyz, r0, c4.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
SetTexture 3 [_LightTextureB0] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[6] = { program.local[0..3],
		{ 0, 2, 1, 128 },
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R2, fragment.texcoord[0], texture[0], 2D;
MAD R3.xy, R3.wyzw, c[4].y, -c[4].z;
DP3 R0.z, fragment.texcoord[3], fragment.texcoord[3];
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R3.z, R3, R3.w;
RCP R0.x, fragment.texcoord[3].w;
MAD R0.xy, fragment.texcoord[3], R0.x, c[5].x;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R3.z, -R3, c[4];
RSQ R3.z, R3.z;
RCP R3.z, R3.z;
RSQ R1.x, R1.x;
MOV result.color.w, c[4].x;
TEX R0.w, R0, texture[2], 2D;
TEX R1.w, R0.z, texture[3], 2D;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, R1.x, fragment.texcoord[2], R0;
DP3 R3.w, R1, R1;
RSQ R3.w, R3.w;
MUL R1.xyz, R3.w, R1;
DP3 R1.x, R3, R1;
MOV R3.w, c[4];
MUL R1.y, R3.w, c[3].x;
MAX R1.x, R1, c[4];
POW R1.x, R1.x, R1.y;
MUL R2.w, R1.x, R2;
DP3 R1.x, R3, R0;
MUL R0.xyz, R2, c[2];
SLT R2.x, c[4], fragment.texcoord[3].z;
MUL R0.w, R2.x, R0;
MUL R0.w, R0, R1;
MUL R0.xyz, R0, c[0];
MAX R1.x, R1, c[4];
MUL R1.xyz, R0, R1.x;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R0.w, R0, c[4].y;
MAD R0.xyz, R0, R2.w, R1;
MUL result.color.xyz, R0, R0.w;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
SetTexture 3 [_LightTextureB0] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0.50000000, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3
rcp r2.x, t3.w
mad r3.xy, t3, r2.x, c5.y
mov r0.y, t0.w
mov r0.x, t0.z
mov r1.xy, r0
dp3 r0.x, t3, t3
mov r2.xy, r0.x
texld r6, r2, s3
texld r1, r1, s1
texld r2, t0, s0
texld r0, r3, s2
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3_pp r1.x, t2, t2
mul_pp r2.xyz, r2, c2
mov r0.y, r1
mov r0.x, r1.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
mov_pp r0.x, c3
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r4, r1
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r5.x, r1.x, r0.x
dp3_pp r1.x, r4, r3
mov r0.x, r5.x
mul r0.x, r0, r2.w
mov_pp r3.xyz, c0
max_pp r1.x, r1, c4.w
mul_pp r2.xyz, r2, c0
mul_pp r2.xyz, r2, r1.x
cmp r1.x, -t3.z, c4.w, c4.z
mul_pp r1.x, r1, r0.w
mul_pp r1.x, r1, r6
mul_pp r3.xyz, c1, r3
mul_pp r1.x, r1, c4
mad r0.xyz, r3, r0.x, r2
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[3], texture[3], CUBE;
MAD R3.xy, R3.wyzw, c[4].y, -c[4].z;
DP3 R0.x, fragment.texcoord[3], fragment.texcoord[3];
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R3.z, R3, R3.w;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R3.z, -R3, c[4];
RSQ R3.z, R3.z;
RCP R3.z, R3.z;
RSQ R1.x, R1.x;
MOV result.color.w, c[4].x;
TEX R0.w, R0.x, texture[2], 2D;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, R1.x, fragment.texcoord[2], R0;
DP3 R3.w, R1, R1;
RSQ R3.w, R3.w;
MUL R1.xyz, R3.w, R1;
DP3 R1.x, R3, R1;
MOV R3.w, c[4];
MUL R0.w, R0, R1;
MUL R1.y, R3.w, c[3].x;
MAX R1.x, R1, c[4];
POW R1.x, R1.x, R1.y;
MUL R2.w, R1.x, R2;
DP3 R1.x, R3, R0;
MUL R0.xyz, R2, c[2];
MUL R0.xyz, R0, c[0];
MAX R1.x, R1, c[4];
MUL R1.xyz, R0, R1.x;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R0.w, R0, c[4].y;
MAD R0.xyz, R0, R2.w, R1;
MUL result.color.xyz, R0, R0.w;
END
# 38 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_cube s3
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
dp3 r0.x, t3, t3
mov r0.xy, r0.x
mul_pp r2.xyz, r2, c2
mov r1.y, t0.w
mov r1.x, t0.z
mul_pp r2.xyz, r2, c0
texld r6, r0, s2
texld r1, r1, s1
texld r0, t3, s3
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3_pp r1.x, t2, t2
mov r0.y, r1
mov r0.x, r1.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
mov_pp r0.x, c3
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r4, r1
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r5.x, r1.x, r0.x
dp3_pp r1.x, r4, r3
max_pp r1.x, r1, c4.w
mov r0.x, r5.x
mul r0.x, r0, r2.w
mov_pp r3.xyz, c0
mul_pp r2.xyz, r2, r1.x
mul r1.x, r6, r0.w
mul_pp r3.xyz, c1, r3
mul_pp r1.x, r1, c4
mad r0.xyz, r3, r0.x, r2
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R2.w, fragment.texcoord[3], texture[2], 2D;
MAD R1.xy, R1.wyzw, c[4].y, -c[4].z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
DP3 R3.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R1.z, -R1, c[4];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
MUL R0.xyz, R0, c[2];
MOV R2.xyz, fragment.texcoord[1];
RSQ R3.x, R3.x;
MAD R2.xyz, R3.x, fragment.texcoord[2], R2;
DP3 R1.w, R2, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R2;
DP3 R2.x, R1, R2;
MOV R1.w, c[4];
MUL R2.y, R1.w, c[3].x;
MAX R1.w, R2.x, c[4].x;
POW R1.w, R1.w, R2.y;
MUL R0.w, R1, R0;
DP3 R1.w, R1, fragment.texcoord[1];
MUL R1.xyz, R0, c[0];
MAX R1.w, R1, c[4].x;
MUL R1.xyz, R1, R1.w;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R1.w, R2, c[4].y;
MAD R0.xyz, R0, R0.w, R1;
MUL result.color.xyz, R0, R1.w;
MOV result.color.w, c[4].x;
END
# 33 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xy
texld r2, t0, s0
mul_pp r2.xyz, r2, c2
mov r0.y, t0.w
mov r0.x, t0.z
mov r1.xy, r0
mul_pp r2.xyz, r2, c0
mov_pp r4.xyz, t1
texld r1, r1, s1
texld r0, t3, s2
dp3_pp r1.x, t2, t2
rsq_pp r1.x, r1.x
mad_pp r4.xyz, r1.x, t2, r4
dp3_pp r1.x, r4, r4
mov r0.y, r1
mov r0.x, r1.w
mad_pp r3.xy, r0, c4.x, c4.y
mul_pp r0.xy, r3, r3
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r4
dp3_pp r1.x, r3, r1
mov_pp r0.x, c3
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r4.x, r1.x, r0.x
dp3_pp r1.x, r3, t1
max_pp r1.x, r1, c4.w
mul_pp r3.xyz, r2, r1.x
mov r0.x, r4.x
mul r0.x, r0, r2.w
mul_pp r1.x, r0.w, c4
mov_pp r2.xyz, c0
mul_pp r2.xyz, c1, r2
mad r0.xyz, r2, r0.x, r3
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
}
 }
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
"3.0-!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
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
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 21 instructions, 2 R-regs
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
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
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
mul o2.xyz, r0, c8.w
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3.xyz, r0, c8.w
dp3 r0.y, r1, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4.xyz, r0, c8.w
mad o1.xy, v3, c9, c9.zwzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_MetalShininess]
Float 1 [_SkinShininess]
Float 2 [_Fading_Time]
Float 3 [_CurrentTime]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_FadingMap] 2D 2
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.yw, fragment.texcoord[0], texture[1], 2D;
MAD R2.xy, R0.wyzw, c[4].y, -c[4].z;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[4].z;
RSQ R0.x, R0.x;
RCP R2.z, R0.x;
RCP R0.w, c[2].x;
DP3 R0.z, fragment.texcoord[3], R2;
DP3 R0.x, R2, fragment.texcoord[1];
DP3 R0.y, R2, fragment.texcoord[2];
MAD result.color.xyz, R0, c[4].x, c[4].x;
TEX R0.x, R1, texture[2], 2D;
MUL R0.w, R0, c[3].x;
SGE R1.x, R0.w, R0;
TEX R0.yz, fragment.texcoord[0], texture[0], 2D;
SGE R0.xy, R0.yzzw, c[4].x;
MUL R0.w, R0.y, c[1].x;
MOV R0.z, c[0].x;
MAD R0.y, -R0, c[1].x, R0.z;
MAD result.color.w, R0.x, R0.y, R0;
KIL -R1.x;
END
# 22 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_MetalShininess]
Float 1 [_SkinShininess]
Float 2 [_Fading_Time]
Float 3 [_CurrentTime]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_FadingMap] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 1.00000000, 0.00000000, -0.50000000, 0.50000000
def c5, 2.00000000, -1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
texld r0.x, r0, s2
texld r1.yw, v0, s1
mad_pp r1.xy, r1.wyzw, c5.x, c5.y
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
rcp r0.y, c2.x
add_pp r0.z, -r0, c4.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
mad r0.w, r0.y, c3.x, -r0.x
dp3 r0.z, v3, r1
dp3 r0.x, r1, v1
dp3 r0.y, r1, v2
mad_pp oC0.xyz, r0, c4.w, c4.w
cmp r0.x, r0.w, c4, c4.y
mov_pp r1, -r0.x
texld r0.yz, v0, s0
add r0.xy, r0.yzzw, c4.z
cmp r0.xy, r0, c4.x, c4.y
mul_pp r0.w, r0.y, c1.x
mov_pp r0.z, c0.x
mad_pp r0.y, -r0, c1.x, r0.z
texkill r1.xyzw
mad_pp oC0.w, r0.x, r0.y, r0
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
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
MOV result.texcoord[6].xyz, R1.wxyw;
ADD result.texcoord[7].xyz, -R0, c[13];
MOV result.color.xyz, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
mov o7.xyz, r1.wxyw
add o8.xyz, -r0, c12
mov o9.xyz, r0
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..23] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[17];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[15];
DP4 R2.x, R0, c[13];
DP4 R2.y, R0, c[14];
MAD R2.xyz, R2, c[20].w, -vertex.position;
DP3 R0.y, R1, c[9];
DP3 R0.w, -R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP3 R0.x, vertex.attrib[14], c[9];
DP3 R0.z, vertex.normal, c[9];
MUL result.texcoord[2], R0, c[20].w;
DP3 R0.y, R1, c[10];
DP3 R0.w, -R2, c[10];
DP3 R0.x, vertex.attrib[14], c[10];
DP3 R0.z, vertex.normal, c[10];
MUL result.texcoord[3], R0, c[20].w;
DP3 R0.y, R1, c[11];
DP4 R1.z, vertex.position, c[7];
DP3 R0.w, -R2, c[11];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[11];
DP3 R0.z, vertex.normal, c[11];
MUL result.texcoord[4], R0, c[20].w;
MOV R0.x, R2;
MUL R0.y, R2, c[18].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
ADD R0.xyz, R0, -c[19];
MUL result.texcoord[6].xyz, R0, c[19].w;
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[19].w;
DP4 R0.x, vertex.position, c[3];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[23].xyxy, c[23];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[22], c[22].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[21], c[21].zwzw;
MUL result.texcoord[6].w, -R0.x, R0.y;
END
# 47 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c24, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c16
mov r0.w, c24.y
dp4 r2.z, r0, c14
dp4 r2.x, r0, c12
dp4 r2.y, r0, c13
mad r2.xyz, r2, c20.w, -v0
dp3 r0.y, r1, c8
dp3 r0.w, -r2, c8
dp4 r1.w, v0, c7
dp3 r0.x, v1, c8
dp3 r0.z, v2, c8
mul o3, r0, c20.w
dp3 r0.y, r1, c9
dp3 r0.w, -r2, c9
dp3 r0.x, v1, c9
dp3 r0.z, v2, c9
mul o4, r0, c20.w
dp3 r0.y, r1, c10
dp4 r1.z, v0, c6
dp3 r0.w, -r2, c10
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r2.xyz, r1.xyww, c24.x
dp3 r0.x, v1, c10
dp3 r0.z, v2, c10
mul o5, r0, c20.w
mov r0.x, r2
mul r0.y, r2, c17.x
mad o2.xy, r2.z, c18.zwzw, r0
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add r0.xyz, r0, -c19
mul o7.xyz, r0, c19.w
mov r0.x, c19.w
add r0.y, c24, -r0.x
dp4 r0.x, v0, c2
mov o0, r1
mov o2.zw, r1
mad o1.zw, v3.xyxy, c23.xyxy, c23
mad o1.xy, v3, c22, c22.zwzw
mad o6.xy, v4, c21, c21.zwzw
mul o7.w, -r0.x, r0.y
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1.w, c[0].y;
MOV R1.xyz, c[13];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
MUL R1.xyz, vertex.attrib[14].w, R0;
DP3 R0.y, R1, c[5];
DP3 result.texcoord[6].y, R1, R2;
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R1.y, R1, c[7];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
DP3 R1.x, vertex.attrib[14], c[7];
DP3 R1.w, -R2, c[7];
DP3 R1.z, vertex.normal, c[7];
MUL result.texcoord[4], R1, c[15].w;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 result.texcoord[6].z, vertex.normal, R2;
DP3 result.texcoord[6].x, vertex.attrib[14], R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[17], c[17].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[16], c[16].zwzw;
END
# 41 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mov r1.w, c19.y
mov r1.xyz, c12
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c15.w, -v0
mul r1.xyz, v1.w, r0
dp3 r0.y, r1, c4
dp3 o7.y, r1, r2
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c15.w
dp3 r0.y, r1, c5
dp3 r1.y, r1, c6
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c15.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c19.x
dp3 r1.x, v1, c6
dp3 r1.w, -r2, c6
dp3 r1.z, v2, c6
mul o5, r1, c15.w
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 o7.z, v2, r2
dp3 o7.x, v1, r2
mov o0, r0
mov o2.zw, r0
mad o1.zw, v3.xyxy, c18.xyxy, c18
mad o1.xy, v3, c17, c17.zwzw
mad o6.xy, v4, c16, c16.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
MOV result.texcoord[6].xyz, R1.wxyw;
ADD result.texcoord[7].xyz, -R0, c[13];
MOV result.color.xyz, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
END
# 64 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
mov o7.xyz, r1.wxyw
add o8.xyz, -r0, c12
mov o9.xyz, r0
mad o1.zw, v3.xyxy, c24.xyxy, c24
mad o1.xy, v3, c23, c23.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..23] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[17];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[15];
DP4 R2.x, R0, c[13];
DP4 R2.y, R0, c[14];
MAD R2.xyz, R2, c[20].w, -vertex.position;
DP3 R0.y, R1, c[9];
DP3 R0.w, -R2, c[9];
DP4 R1.w, vertex.position, c[8];
DP3 R0.x, vertex.attrib[14], c[9];
DP3 R0.z, vertex.normal, c[9];
MUL result.texcoord[2], R0, c[20].w;
DP3 R0.y, R1, c[10];
DP3 R0.w, -R2, c[10];
DP3 R0.x, vertex.attrib[14], c[10];
DP3 R0.z, vertex.normal, c[10];
MUL result.texcoord[3], R0, c[20].w;
DP3 R0.y, R1, c[11];
DP4 R1.z, vertex.position, c[7];
DP3 R0.w, -R2, c[11];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[11];
DP3 R0.z, vertex.normal, c[11];
MUL result.texcoord[4], R0, c[20].w;
MOV R0.x, R2;
MUL R0.y, R2, c[18].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
ADD R0.xyz, R0, -c[19];
MUL result.texcoord[6].xyz, R0, c[19].w;
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[19].w;
DP4 R0.x, vertex.position, c[3];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[23].xyxy, c[23];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[22], c[22].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[21], c[21].zwzw;
MUL result.texcoord[6].w, -R0.x, R0.y;
END
# 47 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c24, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c16
mov r0.w, c24.y
dp4 r2.z, r0, c14
dp4 r2.x, r0, c12
dp4 r2.y, r0, c13
mad r2.xyz, r2, c20.w, -v0
dp3 r0.y, r1, c8
dp3 r0.w, -r2, c8
dp4 r1.w, v0, c7
dp3 r0.x, v1, c8
dp3 r0.z, v2, c8
mul o3, r0, c20.w
dp3 r0.y, r1, c9
dp3 r0.w, -r2, c9
dp3 r0.x, v1, c9
dp3 r0.z, v2, c9
mul o4, r0, c20.w
dp3 r0.y, r1, c10
dp4 r1.z, v0, c6
dp3 r0.w, -r2, c10
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r2.xyz, r1.xyww, c24.x
dp3 r0.x, v1, c10
dp3 r0.z, v2, c10
mul o5, r0, c20.w
mov r0.x, r2
mul r0.y, r2, c17.x
mad o2.xy, r2.z, c18.zwzw, r0
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
add r0.xyz, r0, -c19
mul o7.xyz, r0, c19.w
mov r0.x, c19.w
add r0.y, c24, -r0.x
dp4 r0.x, v0, c2
mov o0, r1
mov o2.zw, r1
mad o1.zw, v3.xyxy, c23.xyxy, c23
mad o1.xy, v3, c22, c22.zwzw
mad o6.xy, v4, c21, c21.zwzw
mul o7.w, -r0.x, r0.y
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1.w, c[0].y;
MOV R1.xyz, c[13];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
MUL R1.xyz, vertex.attrib[14].w, R0;
DP3 R0.y, R1, c[5];
DP3 result.texcoord[6].y, R1, R2;
DP3 R0.w, -R2, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R1.y, R1, c[7];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
DP3 R1.x, vertex.attrib[14], c[7];
DP3 R1.w, -R2, c[7];
DP3 R1.z, vertex.normal, c[7];
MUL result.texcoord[4], R1, c[15].w;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 result.texcoord[6].z, vertex.normal, R2;
DP3 result.texcoord[6].x, vertex.attrib[14], R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[17], c[17].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[16], c[16].zwzw;
END
# 41 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mov r1.w, c19.y
mov r1.xyz, c12
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c15.w, -v0
mul r1.xyz, v1.w, r0
dp3 r0.y, r1, c4
dp3 o7.y, r1, r2
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c15.w
dp3 r0.y, r1, c5
dp3 r1.y, r1, c6
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c15.w
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c19.x
dp3 r1.x, v1, c6
dp3 r1.w, -r2, c6
dp3 r1.z, v2, c6
mul o5, r1, c15.w
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 o7.z, v2, r2
dp3 o7.x, v1, r2
mov o0, r0
mov o2.zw, r0
mad o1.zw, v3.xyxy, c18.xyxy, c18
mad o1.xy, v3, c17, c17.zwzw
mad o6.xy, v4, c16, c16.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_BRDF_PARA]
Float 7 [_Fading_Time]
Float 8 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_Ramp] 2D 5
SetTexture 6 [_FadingMap] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[11] = { program.local[0..8],
		{ 1, 0.80000001, 0.30000001, 0.5 },
		{ 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R1.xyz, R0.z, R1, c[1];
ADD R2.xyz, -R1, c[3];
MAD R3.xyz, R0.y, R2, R1;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MOV R0.y, c[9].x;
MAD R2.xy, R1.wyzw, c[10].y, -R0.y;
DP3 R0.z, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.y, R0.z;
MUL R1.xyz, R0.y, fragment.texcoord[7];
DP3 R0.y, fragment.texcoord[6], R1;
DP3 R0.z, fragment.texcoord[6], c[0];
MUL R2.zw, R2.xyxy, R2.xyxy;
MUL R1.x, R0.y, c[9].y;
ADD_SAT R0.y, R2.z, R2.w;
MAD R1.y, R0.z, c[9].z, c[9].w;
TEX R1.xyz, R1, texture[5], 2D;
MUL R4.xyz, R1, c[6].x;
TEX R1.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R3.xyz, R1, R3, R4;
TXP R1, fragment.texcoord[1], texture[0], 2D;
MUL R2.w, R0, c[5].x;
ADD R0.y, -R0, c[9].x;
RSQ R0.y, R0.y;
RCP R2.z, R0.y;
DP3 R0.y, fragment.texcoord[2], R2;
DP3 R0.z, R2, fragment.texcoord[3];
DP3 R0.w, R2, fragment.texcoord[4];
MUL R4.xyz, R3, R2.w;
LG2 R1.w, R1.w;
MOV R2.x, fragment.texcoord[2].w;
MOV R2.z, fragment.texcoord[4].w;
MOV R2.y, fragment.texcoord[3].w;
DP3 R3.w, R0.yzww, R2;
MUL R0.yzw, R0, R3.w;
MAD R2.xyz, -R0.yzww, c[10].y, R2;
MUL R0.w, R0.x, c[2];
MUL R4.xyz, R4, -R1.w;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[5];
MAD R3.xyz, R3, R1, R4;
TEX R1.xyz, R2, texture[4], CUBE;
MUL R0.xyz, R2.w, R1;
MUL R1.xyz, R0.w, c[2];
MAD R1.xyz, R1, c[10].x, R0;
RCP R0.y, c[7].x;
TEX R0.x, fragment.texcoord[0], texture[6], 2D;
MUL R0.y, R0, c[8].x;
SGE R0.x, R0.y, R0;
ADD result.color.xyz, R3, R1;
KIL -R0.x;
MOV result.color.w, c[9].x;
END
# 56 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_BRDF_PARA]
Float 7 [_Fading_Time]
Float 8 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_Ramp] 2D 5
SetTexture 6 [_FadingMap] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c9, 1.00000000, 0.00000000, 0.80000001, 2.00000000
def c10, 0.30000001, 0.50000000, 2.00000000, -1.00000000
def c11, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
dcl_texcoord7 v7.xyz
texld r2, v0, s2
mov_pp r0.xyz, c4
add_pp r0.xyz, -c1, r0
mad_pp r3.xyz, r2.z, r0, c1
add_pp r1.xyz, -r3, c3
mad_pp r3.xyz, r2.y, r1, r3
dp3 r0.w, v7, v7
rsq r0.x, r0.w
mul r0.xyz, r0.x, v7
dp3 r0.x, v6, r0
texld r0.yw, v0.zwzw, s3
mad_pp r2.yz, r0.xwyw, c10.z, c10.w
mul_pp r4.xy, r2.yzzw, r2.yzzw
dp3 r0.z, v6, c0
add_pp_sat r0.w, r4.x, r4.y
texld r1.xyz, v0, s1
mul r1.w, r2, c5.x
add_pp r0.w, -r0, c9.x
mul r0.x, r0, c9.z
mad r0.y, r0.z, c10.x, c10
texld r0.xyz, r0, s5
mul r0.xyz, r0, c6.x
mad r3.xyz, r1, r3, r0
rsq_pp r0.x, r0.w
rcp_pp r2.w, r0.x
texldp r0, v1, s0
dp3_pp r1.x, v2, r2.yzww
dp3_pp r1.y, r2.yzww, v3
dp3_pp r1.z, r2.yzww, v4
mul r4.xyz, r3, r1.w
log_pp r0.w, r0.w
mul r4.xyz, r4, -r0.w
mov r2.y, v2.w
mov r2.z, v3.w
mov r2.w, v4
dp3 r3.w, r1, r2.yzww
mul r1.xyz, r1, r3.w
mad r1.xyz, -r1, c9.w, r2.yzww
texld r1.xyz, r1, s4
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r0.xyz, -r0, v5
mad r0.xyz, r3, r0, r4
mul r3.xyz, r1.w, r1
mul r1.y, r2.x, c2.w
texld r1.x, v0, s6
rcp r0.w, c7.x
mad r0.w, r0, c8.x, -r1.x
mul r1.xyz, r1.y, c2
mad r2.xyz, r1, c11.x, r3
cmp r0.w, r0, c9.x, c9.y
mov_pp r1, -r0.w
add oC0.xyz, r0, r2
texkill r1.xyzw
mov_pp oC0.w, c9.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
Vector 7 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 8, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[5], texture[1], 2D;
TEX R0, fragment.texcoord[5], texture[2], 2D;
MUL R0.xyz, R0.w, R0;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
MAD R3.xy, R3.wyzw, c[8].w, -c[8].x;
DP4 R0.w, fragment.texcoord[6], fragment.texcoord[6];
RSQ R0.w, R0.w;
RCP R0.w, R0.w;
MUL R3.zw, R3.xyxy, R3.xyxy;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R0, c[8].y;
MAD R2.xyz, R1, c[8].y, -R0;
TXP R1, fragment.texcoord[1], texture[0], 2D;
MAD_SAT R0.w, R0, c[7].z, c[7];
MAD R0.xyz, R0.w, R2, R0;
MOV R2.xyz, c[0];
LG2 R1.x, R1.x;
LG2 R1.y, R1.y;
LG2 R1.z, R1.z;
ADD R1.xyz, -R1, R0;
TEX R0, fragment.texcoord[0], texture[4], 2D;
ADD R2.xyz, -R2, c[3];
MAD R2.xyz, R0.z, R2, c[0];
ADD R4.xyz, -R2, c[2];
MAD R2.xyz, R0.y, R4, R2;
ADD_SAT R0.y, R3.z, R3.w;
TEX R4.xyz, fragment.texcoord[0], texture[3], 2D;
ADD R0.y, -R0, c[8].x;
RSQ R0.y, R0.y;
RCP R3.z, R0.y;
MUL R2.w, R0, c[4].x;
MUL R2.xyz, R4, R2;
DP3 R0.y, fragment.texcoord[2], R3;
DP3 R0.z, R3, fragment.texcoord[3];
DP3 R0.w, R3, fragment.texcoord[4];
MUL R4.xyz, R2, R2.w;
LG2 R1.w, R1.w;
MUL R4.xyz, R4, -R1.w;
MOV R3.x, fragment.texcoord[2].w;
MOV R3.z, fragment.texcoord[4].w;
MOV R3.y, fragment.texcoord[3].w;
DP3 R3.w, R0.yzww, R3;
MUL R0.yzw, R0, R3.w;
MAD R3.xyz, -R0.yzww, c[8].w, R3;
MAD R1.xyz, R2, R1, R4;
TEX R2.xyz, R3, texture[6], CUBE;
MUL R0.w, R0.x, c[1];
MUL R0.xyz, R2.w, R2;
MUL R2.xyz, R0.w, c[1];
MAD R2.xyz, R2, c[8].z, R0;
RCP R0.y, c[5].x;
TEX R0.x, fragment.texcoord[0], texture[7], 2D;
MUL R0.y, R0, c[6].x;
SGE R0.x, R0.y, R0;
ADD result.color.xyz, R1, R2;
KIL -R0.x;
MOV result.color.w, c[8].x;
END
# 57 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
Vector 7 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
dcl_2d s7
def c8, 1.00000000, 0.00000000, 8.00000000, 2.00000000
def c9, 2.00000000, -1.00000000, 16.00000000, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
texld r1, v5, s1
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
texld r3.yw, v0.zwzw, s5
mad_pp r3.xy, r3.wyzw, c9.x, c9.y
dp4 r0.w, v6, v6
rsq r0.w, r0.w
rcp r0.w, r0.w
mul_pp r3.zw, r3.xyxy, r3.xyxy
mul_pp r1.xyz, r1.w, r1
mul_pp r0.xyz, r0, c8.z
mad_pp r2.xyz, r1, c8.z, -r0
texldp r1, v1, s0
mad_sat r0.w, r0, c7.z, c7
mad_pp r0.xyz, r0.w, r2, r0
mov_pp r2.xyz, c3
add_pp r2.xyz, -c0, r2
log_pp r1.x, r1.x
log_pp r1.y, r1.y
log_pp r1.z, r1.z
add_pp r1.xyz, -r1, r0
texld r0, v0, s4
mad_pp r4.xyz, r0.z, r2, c0
add_pp r2.xyz, -r4, c2
mad_pp r2.xyz, r0.y, r2, r4
add_pp_sat r0.z, r3, r3.w
texld r4.xyz, v0, s3
mul r2.xyz, r4, r2
add_pp r0.y, -r0.z, c8.x
rsq_pp r0.y, r0.y
rcp_pp r3.z, r0.y
mul r2.w, r0, c4.x
dp3_pp r0.y, v2, r3
dp3_pp r0.z, r3, v3
dp3_pp r0.w, r3, v4
mul r3.xyz, r2, r2.w
mov r4.x, v2.w
mov r4.z, v4.w
mov r4.y, v3.w
dp3 r3.w, r0.yzww, r4
mul r0.yzw, r0, r3.w
mad r4.xyz, -r0.yzww, c8.w, r4
log_pp r1.w, r1.w
mul r0.yzw, r3.xxyz, -r1.w
mad r1.xyz, r2, r1, r0.yzww
mul r0.y, r0.x, c1.w
texld r3.xyz, r4, s6
mul r2.xyz, r2.w, r3
texld r0.x, v0, s7
rcp r0.z, c5.x
mad r0.w, r0.z, c6.x, -r0.x
mul r0.xyz, r0.y, c1
mad r0.xyz, r0, c9.z, r2
cmp r0.w, r0, c8.x, c8.y
mov_pp r2, -r0.w
add oC0.xyz, r1, r0
texkill r2.xyzw
mov_pp oC0.w, c8.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[11] = { program.local[0..6],
		{ 1, -0.40824828, -0.70710677, 0.57735026 },
		{ -0.40824831, 0.70710677, 0.57735026, 8 },
		{ 0.81649655, 0, 0.57735026, 16 },
		{ 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[5], texture[2], 2D;
DP3_SAT R2.z, R1, c[7].yzww;
DP3_SAT R2.x, R1, c[9];
DP3_SAT R2.y, R1, c[8];
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, R0, R2;
TEX R0, fragment.texcoord[5], texture[1], 2D;
MOV R2.xyz, c[0];
MUL R0.xyz, R0.w, R0;
DP3 R1.x, R1, c[8].w;
MUL R1.xyz, R0, R1.x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
LG2 R0.x, R0.x;
LG2 R0.y, R0.y;
LG2 R0.z, R0.z;
LG2 R0.w, R0.w;
MOV R2.w, c[7].x;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
MAD R3.xy, R3.wyzw, c[10].x, -R2.w;
MUL R3.zw, R3.xyxy, R3.xyxy;
MUL R1.xyz, R1, c[8].w;
MOV R1.w, c[7].x;
ADD R1, -R0, R1;
TEX R0, fragment.texcoord[0], texture[4], 2D;
ADD R2.xyz, -R2, c[3];
MAD R2.xyz, R0.z, R2, c[0];
ADD_SAT R0.z, R3, R3.w;
ADD R4.xyz, -R2, c[2];
MAD R2.xyz, R0.y, R4, R2;
ADD R0.z, -R0, c[7].x;
RSQ R0.y, R0.z;
RCP R3.z, R0.y;
MUL R2.w, R0, c[4].x;
TEX R4.xyz, fragment.texcoord[0], texture[3], 2D;
MUL R2.xyz, R4, R2;
MUL R4.xyz, R2, R2.w;
MUL R4.xyz, R1.w, R4;
DP3 R0.y, fragment.texcoord[2], R3;
DP3 R0.z, R3, fragment.texcoord[3];
DP3 R0.w, R3, fragment.texcoord[4];
MOV R3.x, fragment.texcoord[2].w;
MOV R3.z, fragment.texcoord[4].w;
MOV R3.y, fragment.texcoord[3].w;
DP3 R3.w, R0.yzww, R3;
MUL R0.yzw, R0, R3.w;
MAD R3.xyz, -R0.yzww, c[10].x, R3;
MAD R1.xyz, R2, R1, R4;
TEX R2.xyz, R3, texture[6], CUBE;
MUL R0.w, R0.x, c[1];
MUL R0.xyz, R2.w, R2;
MUL R2.xyz, R0.w, c[1];
MAD R2.xyz, R2, c[9].w, R0;
RCP R0.y, c[5].x;
TEX R0.x, fragment.texcoord[0], texture[7], 2D;
MUL R0.y, R0, c[6].x;
SGE R0.x, R0.y, R0;
ADD result.color.xyz, R1, R2;
KIL -R0.x;
MOV result.color.w, c[7].x;
END
# 59 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
dcl_2d s7
def c7, 1.00000000, 0.00000000, 0.81649655, 0.57735026
def c8, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c9, -0.40824831, 0.70710677, 0.57735026, 2.00000000
def c10, 2.00000000, -1.00000000, 16.00000000, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
texld r0, v5, s2
texld r3.yw, v0.zwzw, s5
mad_pp r3.xy, r3.wyzw, c10.x, c10.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
dp3_pp_sat r2.z, r1, c8
dp3_pp_sat r2.x, r1, c7.zyww
dp3_pp_sat r2.y, r1, c9
mul_pp r0.xyz, r0.w, r0
mul_pp r1.xyz, r0, r2
texld r0, v5, s1
mov_pp r2.xyz, c3
mul_pp r0.xyz, r0.w, r0
dp3_pp r1.x, r1, c8.w
mul_pp r1.xyz, r0, r1.x
texldp r0, v1, s0
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
log_pp r0.w, r0.w
mul_pp r1.xyz, r1, c8.w
mov_pp r1.w, c7.x
add_pp r1, -r0, r1
texld r0, v0, s4
add_pp r2.xyz, -c0, r2
mad_pp r2.xyz, r0.z, r2, c0
add_pp r4.xyz, -r2, c2
mad_pp r2.xyz, r0.y, r4, r2
texld r4.xyz, v0, s3
add_pp_sat r0.z, r3, r3.w
add_pp r0.z, -r0, c7.x
rsq_pp r0.y, r0.z
mul r2.xyz, r4, r2
rcp_pp r3.z, r0.y
dp3_pp r4.x, v2, r3
dp3_pp r4.y, r3, v3
dp3_pp r4.z, r3, v4
mul r2.w, r0, c4.x
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r0.y, r4, r3
mul r0.yzw, r4.xxyz, r0.y
mad r3.xyz, -r0.yzww, c9.w, r3
mul r4.xyz, r2, r2.w
mul r0.y, r0.x, c1.w
mul r4.xyz, r1.w, r4
mad r1.xyz, r2, r1, r4
texld r3.xyz, r3, s6
mul r2.xyz, r2.w, r3
texld r0.x, v0, s7
rcp r0.z, c5.x
mad r0.w, r0.z, c6.x, -r0.x
mul r0.xyz, r0.y, c1
mad r0.xyz, r0, c10.z, r2
cmp r0.w, r0, c7.x, c7.y
mov_pp r2, -r0.w
add oC0.xyz, r1, r0
texkill r2.xyzw
mov_pp oC0.w, c7.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_BRDF_PARA]
Float 7 [_Fading_Time]
Float 8 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_Ramp] 2D 5
SetTexture 6 [_FadingMap] 2D 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[11] = { program.local[0..8],
		{ 1, 0.80000001, 0.30000001, 0.5 },
		{ 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xyz, c[1];
ADD R1.xyz, -R0, c[4];
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R3.xyz, R0.z, R1, c[1];
ADD R2.xyz, -R3, c[3];
MAD R2.xyz, R0.y, R2, R3;
MUL R2.w, R0, c[5].x;
MOV R0.z, c[9].x;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R1.xy, R1.wyzw, c[10].y, -R0.z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.y, R1.z, R1.w;
DP3 R0.z, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.z, R0.z;
MUL R3.xyz, R0.z, fragment.texcoord[7];
DP3 R0.z, fragment.texcoord[6], c[0];
DP3 R1.z, fragment.texcoord[6], R3;
ADD R0.y, -R0, c[9].x;
MAD R1.w, R0.z, c[9].z, c[9];
MUL R1.z, R1, c[9].y;
TEX R3.xyz, R1.zwzw, texture[5], 2D;
MUL R4.xyz, R3, c[6].x;
TEX R3.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R2.xyz, R3, R2, R4;
RSQ R0.y, R0.y;
RCP R1.z, R0.y;
DP3 R0.y, fragment.texcoord[2], R1;
DP3 R0.z, R1, fragment.texcoord[3];
DP3 R0.w, R1, fragment.texcoord[4];
MOV R3.x, fragment.texcoord[2].w;
MOV R3.z, fragment.texcoord[4].w;
MOV R3.y, fragment.texcoord[3].w;
DP3 R1.x, R0.yzww, R3;
MUL R0.yzw, R0, R1.x;
MAD R3.xyz, -R0.yzww, c[10].y, R3;
TXP R1, fragment.texcoord[1], texture[0], 2D;
MUL R4.xyz, R2, R2.w;
MUL R0.w, R0.x, c[2];
MUL R4.xyz, R1.w, R4;
ADD R1.xyz, R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R4;
TEX R2.xyz, R3, texture[4], CUBE;
MUL R0.xyz, R2.w, R2;
MUL R2.xyz, R0.w, c[2];
MAD R2.xyz, R2, c[10].x, R0;
RCP R0.y, c[7].x;
TEX R0.x, fragment.texcoord[0], texture[6], 2D;
MUL R0.y, R0, c[8].x;
SGE R0.x, R0.y, R0;
ADD result.color.xyz, R1, R2;
KIL -R0.x;
MOV result.color.w, c[9].x;
END
# 52 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_Color]
Vector 2 [_IllumnColor]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ReflectColor]
Float 6 [_BRDF_PARA]
Float 7 [_Fading_Time]
Float 8 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_Ramp] 2D 5
SetTexture 6 [_FadingMap] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c9, 1.00000000, 0.00000000, 0.80000001, 2.00000000
def c10, 0.30000001, 0.50000000, 2.00000000, -1.00000000
def c11, 16.00000000, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
dcl_texcoord7 v7.xyz
mov_pp r0.xyz, c4
dp3 r0.w, v7, v7
texld r3.yw, v0.zwzw, s3
mad_pp r3.xy, r3.wyzw, c10.z, c10.w
texld r4, v0, s2
add_pp r0.xyz, -c1, r0
mad_pp r0.xyz, r4.z, r0, c1
add_pp r1.xyz, -r0, c3
mad_pp r2.xyz, r4.y, r1, r0
rsq r0.w, r0.w
mul r1.xyz, r0.w, v7
dp3 r0.w, v6, r1
mul_pp r1.zw, r3.xyxy, r3.xyxy
mul r1.x, r0.w, c9.z
dp3 r0.w, v6, c0
add_pp_sat r1.z, r1, r1.w
mad r1.y, r0.w, c10.x, c10
add_pp r0.w, -r1.z, c9.x
rsq_pp r0.w, r0.w
rcp_pp r3.z, r0.w
texld r1.xyz, r1, s5
mul r1.xyz, r1, c6.x
texld r0.xyz, v0, s1
mad r0.xyz, r0, r2, r1
dp3_pp r2.x, v2, r3
dp3_pp r2.y, r3, v3
dp3_pp r2.z, r3, v4
mul r0.w, r4, c5.x
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r1.w, r2, r1
mul r2.xyz, r2, r1.w
mad r2.xyz, -r2, c9.w, r1
texldp r1, v1, s0
mul r3.xyz, r0, r0.w
mul r3.xyz, r1.w, r3
add_pp r1.xyz, r1, v5
texld r2.xyz, r2, s4
mad r0.xyz, r0, r1, r3
mul r1.xyz, r0.w, r2
mul r1.w, r4.x, c2
texld r2.x, v0, s6
rcp r0.w, c7.x
mad r0.w, r0, c8.x, -r2.x
mul r2.xyz, r1.w, c2
mad r2.xyz, r2, c11.x, r1
cmp r0.w, r0, c9.x, c9.y
mov_pp r1, -r0.w
add oC0.xyz, r0, r2
texkill r1.xyzw
mov_pp oC0.w, c9.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
Vector 7 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..7],
		{ 1, 8, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEX R1, fragment.texcoord[0], texture[4], 2D;
TEX R5, fragment.texcoord[5], texture[1], 2D;
MUL R6.xyz, R5.w, R5;
MOV R0.xyz, c[0];
ADD R0.xyz, -R0, c[3];
MAD R2.xyz, R1.z, R0, c[0];
ADD R0.xyz, -R2, c[2];
MAD R2.xyz, R1.y, R0, R2;
MUL R2.w, R1, c[4].x;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
MAD R4.xy, R1.wyzw, c[8].w, -c[8].x;
TEX R0.xyz, fragment.texcoord[0], texture[3], 2D;
MUL R2.xyz, R0, R2;
TEX R5, fragment.texcoord[5], texture[2], 2D;
MUL R5.xyz, R5.w, R5;
MUL R1.zw, R4.xyxy, R4.xyxy;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R3.xyz, R2, R2.w;
MUL R3.xyz, R0.w, R3;
ADD_SAT R0.w, R1.z, R1;
MUL R5.xyz, R5, c[8].y;
ADD R0.w, -R0, c[8].x;
RSQ R0.w, R0.w;
RCP R4.z, R0.w;
MAD R1.yzw, R6.xxyz, c[8].y, -R5.xxyz;
DP4 R0.w, fragment.texcoord[6], fragment.texcoord[6];
RSQ R0.w, R0.w;
RCP R3.w, R0.w;
MAD_SAT R3.w, R3, c[7].z, c[7];
MAD R5.xyz, R3.w, R1.yzww, R5;
ADD R0.xyz, R0, R5;
DP3 R6.x, fragment.texcoord[2], R4;
DP3 R6.y, R4, fragment.texcoord[3];
DP3 R6.z, R4, fragment.texcoord[4];
MOV R4.x, fragment.texcoord[2].w;
MOV R4.z, fragment.texcoord[4].w;
MOV R4.y, fragment.texcoord[3].w;
DP3 R0.w, R6, R4;
MUL R6.xyz, R6, R0.w;
MUL R0.w, R1.x, c[1];
MAD R2.xyz, R2, R0, R3;
MAD R4.xyz, -R6, c[8].w, R4;
TEX R0.xyz, R4, texture[6], CUBE;
MUL R0.xyz, R2.w, R0;
MUL R1.xyz, R0.w, c[1];
MAD R1.xyz, R1, c[8].z, R0;
RCP R0.y, c[5].x;
TEX R0.x, fragment.texcoord[0], texture[7], 2D;
MUL R0.y, R0, c[6].x;
SGE R0.x, R0.y, R0;
ADD result.color.xyz, R2, R1;
KIL -R0.x;
MOV result.color.w, c[8].x;
END
# 53 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
Vector 7 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
dcl_2d s7
def c8, 1.00000000, 0.00000000, 8.00000000, 2.00000000
def c9, 2.00000000, -1.00000000, 16.00000000, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
texld r2, v0, s4
mov_pp r0.xyz, c3
add_pp r0.xyz, -c0, r0
mad_pp r0.xyz, r2.z, r0, c0
add_pp r1.xyz, -r0, c2
mad_pp r1.xyz, r2.y, r1, r0
texld r0.xyz, v0, s3
mul r3.xyz, r0, r1
mul r3.w, r2, c4.x
texld r0.yw, v0.zwzw, s5
mad_pp r5.xy, r0.wyzw, c9.x, c9.y
texld r0, v5, s1
mul_pp r6.xyz, r0.w, r0
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, c8.z
mul_pp r2.zw, r5.xyxy, r5.xyxy
texldp r1, v1, s0
mul r4.xyz, r3, r3.w
mul r4.xyz, r1.w, r4
add_pp_sat r1.w, r2.z, r2
add_pp r1.w, -r1, c8.x
rsq_pp r0.w, r1.w
rcp_pp r5.z, r0.w
dp4 r0.w, v6, v6
rsq r0.w, r0.w
rcp r0.w, r0.w
dp3_pp r2.y, v2, r5
dp3_pp r2.z, r5, v3
dp3_pp r2.w, r5, v4
mad_pp r6.xyz, r6, c8.z, -r0
mad_sat r0.w, r0, c7.z, c7
mad_pp r6.xyz, r0.w, r6, r0
add_pp r1.xyz, r1, r6
mov r5.x, v2.w
mov r5.z, v4.w
mov r5.y, v3.w
dp3 r1.w, r2.yzww, r5
mul r2.yzw, r2, r1.w
mad r0.xyz, -r2.yzww, c8.w, r5
texld r0.xyz, r0, s6
mad r1.xyz, r3, r1, r4
mul r3.xyz, r3.w, r0
mul r0.z, r2.x, c1.w
mul r2.xyz, r0.z, c1
mad r2.xyz, r2, c9.z, r3
rcp r0.y, c5.x
texld r0.x, v0, s7
mad r0.x, r0.y, c6, -r0
cmp r0.x, r0, c8, c8.y
mov_pp r0, -r0.x
add oC0.xyz, r1, r2
texkill r0.xyzw
mov_pp oC0.w, c8.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[11] = { program.local[0..6],
		{ 1, -0.40824828, -0.70710677, 0.57735026 },
		{ -0.40824831, 0.70710677, 0.57735026, 8 },
		{ 0.81649655, 0, 0.57735026, 16 },
		{ 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[5], texture[2], 2D;
DP3_SAT R2.z, R1, c[7].yzww;
DP3_SAT R2.x, R1, c[9];
DP3_SAT R2.y, R1, c[8];
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, R0, R2;
TEX R0, fragment.texcoord[5], texture[1], 2D;
MOV R2.xyz, c[0];
DP3 R1.x, R1, c[8].w;
MUL R0.xyz, R0.w, R0;
MUL R0.xyz, R0, R1.x;
MUL R1.xyz, R0, c[8].w;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MOV R1.w, c[7].x;
ADD R1, R0, R1;
TEX R0, fragment.texcoord[0], texture[4], 2D;
ADD R2.xyz, -R2, c[3];
MAD R2.xyz, R0.z, R2, c[0];
ADD R4.xyz, -R2, c[2];
MAD R2.xyz, R0.y, R4, R2;
TEX R4.xyz, fragment.texcoord[0], texture[3], 2D;
MUL R2.xyz, R4, R2;
MOV R2.w, c[7].x;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
MAD R3.xy, R3.wyzw, c[10].x, -R2.w;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R0.z, R3, R3.w;
MUL R2.w, R0, c[4].x;
ADD R0.z, -R0, c[7].x;
RSQ R0.y, R0.z;
RCP R3.z, R0.y;
MUL R4.xyz, R2, R2.w;
MUL R4.xyz, R1.w, R4;
DP3 R0.y, fragment.texcoord[2], R3;
DP3 R0.z, R3, fragment.texcoord[3];
DP3 R0.w, R3, fragment.texcoord[4];
MOV R3.x, fragment.texcoord[2].w;
MOV R3.z, fragment.texcoord[4].w;
MOV R3.y, fragment.texcoord[3].w;
DP3 R3.w, R0.yzww, R3;
MUL R0.yzw, R0, R3.w;
MAD R3.xyz, -R0.yzww, c[10].x, R3;
MAD R1.xyz, R2, R1, R4;
TEX R2.xyz, R3, texture[6], CUBE;
MUL R0.w, R0.x, c[1];
MUL R0.xyz, R2.w, R2;
MUL R2.xyz, R0.w, c[1];
MAD R2.xyz, R2, c[9].w, R0;
RCP R0.y, c[5].x;
TEX R0.x, fragment.texcoord[0], texture[7], 2D;
MUL R0.y, R0, c[6].x;
SGE R0.x, R0.y, R0;
ADD result.color.xyz, R1, R2;
KIL -R0.x;
MOV result.color.w, c[7].x;
END
# 55 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ReflectColor]
Float 5 [_Fading_Time]
Float 6 [_CurrentTime]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
SetTexture 7 [_FadingMap] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
dcl_2d s7
def c7, 1.00000000, 0.00000000, 0.81649655, 0.57735026
def c8, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c9, -0.40824831, 0.70710677, 0.57735026, 2.00000000
def c10, 2.00000000, -1.00000000, 16.00000000, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
texld r0, v5, s2
texld r3.yw, v0.zwzw, s5
mad_pp r3.xy, r3.wyzw, c10.x, c10.y
mul_pp r3.zw, r3.xyxy, r3.xyxy
dp3_pp_sat r2.z, r1, c8
dp3_pp_sat r2.x, r1, c7.zyww
dp3_pp_sat r2.y, r1, c9
mul_pp r0.xyz, r0.w, r0
mul_pp r1.xyz, r0, r2
texld r0, v5, s1
mov_pp r2.xyz, c3
dp3_pp r1.x, r1, c8.w
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, r1.x
mul_pp r1.xyz, r0, c8.w
texldp r0, v1, s0
mov_pp r1.w, c7.x
add_pp r1, r0, r1
texld r0, v0, s4
add_pp r2.xyz, -c0, r2
mad_pp r2.xyz, r0.z, r2, c0
add_pp r4.xyz, -r2, c2
mad_pp r2.xyz, r0.y, r4, r2
texld r4.xyz, v0, s3
add_pp_sat r0.z, r3, r3.w
add_pp r0.z, -r0, c7.x
rsq_pp r0.y, r0.z
mul r2.xyz, r4, r2
rcp_pp r3.z, r0.y
dp3_pp r4.x, v2, r3
dp3_pp r4.y, r3, v3
dp3_pp r4.z, r3, v4
mul r2.w, r0, c4.x
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r0.y, r4, r3
mul r0.yzw, r4.xxyz, r0.y
mad r3.xyz, -r0.yzww, c9.w, r3
mul r4.xyz, r2, r2.w
mul r0.y, r0.x, c1.w
mul r4.xyz, r1.w, r4
mad r1.xyz, r2, r1, r4
texld r3.xyz, r3, s6
mul r2.xyz, r2.w, r3
texld r0.x, v0, s7
rcp r0.z, c5.x
mad r0.w, r0.z, c6.x, -r0.x
mul r0.xyz, r0.y, c1
mad r0.xyz, r0, c10.z, r2
cmp r0.w, r0, c7.x, c7.y
mov_pp r2, -r0.w
add oC0.xyz, r1, r0
texkill r2.xyzw
mov_pp oC0.w, c7.x
"
}
}
 }
}
Fallback "Diffuse"
}