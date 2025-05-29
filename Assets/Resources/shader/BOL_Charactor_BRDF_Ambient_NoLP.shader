¬üShader "Custom/BOL_Charactor_BRDF_Ambient_NoLP" {
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
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP4 R1.w, vertex.position, c[4];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP3 R0.y, R1, c[7];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
DP3 R0.w, -R2, c[7];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[15].w;
MOV R0.x, R2;
MUL R0.y, R2, c[14].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MUL R1.xyz, vertex.normal, c[15].w;
MOV result.texcoord[5].xyz, c[18];
MOV result.texcoord[6].xyz, R0;
DP3 result.texcoord[7].z, R1, c[7];
DP3 result.texcoord[7].y, R1, c[6];
DP3 result.texcoord[7].x, R1, c[5];
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
END
# 47 instructions, 3 R-regs
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
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c19.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c15.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp4 r1.w, v0, c3
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c15.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c15.w
dp3 r0.y, r1, c6
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
dp3 r0.w, -r2, c6
mul r2.xyz, r1.xyww, c19.x
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c15.w
mov r0.x, r2
mul r0.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r1
mov oT1.zw, r1
mul r1.xyz, v2, c15.w
mov oT5.xyz, c18
mov oT6.xyz, r0
dp3 oT7.z, r1, c6
dp3 oT7.y, r1, c5
dp3 oT7.x, r1, c4
add oD0.xyz, -r0, c12
mad oT0.zw, v3.xyxy, c17.xyxy, c17
mad oT0.xy, v3, c16, c16.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP4 R1.w, vertex.position, c[4];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP3 R0.y, R1, c[7];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
DP3 R0.w, -R2, c[7];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[15].w;
MOV R0.x, R2;
MUL R0.y, R2, c[14].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MUL R1.xyz, vertex.normal, c[15].w;
MOV result.texcoord[5].xyz, c[18];
MOV result.texcoord[6].xyz, R0;
DP3 result.texcoord[7].z, R1, c[7];
DP3 result.texcoord[7].y, R1, c[6];
DP3 result.texcoord[7].x, R1, c[5];
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
END
# 47 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c19.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c15.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp4 r1.w, v0, c3
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c15.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c15.w
dp3 r0.y, r1, c6
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
dp3 r0.w, -r2, c6
mul r2.xyz, r1.xyww, c19.x
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c15.w
mov r0.x, r2
mul r0.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r1
mov oT1.zw, r1
mul r1.xyz, v2, c15.w
mov oT5.xyz, c18
mov oT6.xyz, r0
dp3 oT7.z, r1, c6
dp3 oT7.y, r1, c5
dp3 oT7.x, r1, c4
add oD0.xyz, -r0, c12
mad oT0.zw, v3.xyxy, c17.xyxy, c17
mad oT0.xy, v3, c16, c16.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP4 R1.w, vertex.position, c[4];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP3 R0.y, R1, c[7];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
DP3 R0.w, -R2, c[7];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[15].w;
MOV R0.x, R2;
MUL R0.y, R2, c[14].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MUL R1.xyz, vertex.normal, c[15].w;
MOV result.texcoord[5].xyz, c[18];
MOV result.texcoord[6].xyz, R0;
DP3 result.texcoord[7].z, R1, c[7];
DP3 result.texcoord[7].y, R1, c[6];
DP3 result.texcoord[7].x, R1, c[5];
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
END
# 47 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
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
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c19.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c15.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp4 r1.w, v0, c3
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c15.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c15.w
dp3 r0.y, r1, c6
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
dp3 r0.w, -r2, c6
mul r2.xyz, r1.xyww, c19.x
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c15.w
mov r0.x, r2
mul r0.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r1
mov oT1.zw, r1
mul r1.xyz, v2, c15.w
mov oT5.xyz, c18
mov oT6.xyz, r0
dp3 oT7.z, r1, c6
dp3 oT7.y, r1, c5
dp3 oT7.x, r1, c4
add oD0.xyz, -r0, c12
mad oT0.zw, v3.xyxy, c17.xyxy, c17
mad oT0.xy, v3, c16, c16.zwzw
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
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP4 R1.w, vertex.position, c[4];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP3 R0.y, R1, c[7];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
DP3 R0.w, -R2, c[7];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[15].w;
MOV R0.x, R2;
MUL R0.y, R2, c[14].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MUL R1.xyz, vertex.normal, c[15].w;
MOV result.texcoord[5].xyz, c[18];
MOV result.texcoord[6].xyz, R0;
DP3 result.texcoord[7].z, R1, c[7];
DP3 result.texcoord[7].y, R1, c[6];
DP3 result.texcoord[7].x, R1, c[5];
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
END
# 47 instructions, 3 R-regs
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
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c19.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c15.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp4 r1.w, v0, c3
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c15.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c15.w
dp3 r0.y, r1, c6
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
dp3 r0.w, -r2, c6
mul r2.xyz, r1.xyww, c19.x
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c15.w
mov r0.x, r2
mul r0.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r1
mov oT1.zw, r1
mul r1.xyz, v2, c15.w
mov oT5.xyz, c18
mov oT6.xyz, r0
dp3 oT7.z, r1, c6
dp3 oT7.y, r1, c5
dp3 oT7.x, r1, c4
add oD0.xyz, -r0, c12
mad oT0.zw, v3.xyxy, c17.xyxy, c17
mad oT0.xy, v3, c16, c16.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP4 R1.w, vertex.position, c[4];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP3 R0.y, R1, c[7];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
DP3 R0.w, -R2, c[7];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[15].w;
MOV R0.x, R2;
MUL R0.y, R2, c[14].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MUL R1.xyz, vertex.normal, c[15].w;
MOV result.texcoord[5].xyz, c[18];
MOV result.texcoord[6].xyz, R0;
DP3 result.texcoord[7].z, R1, c[7];
DP3 result.texcoord[7].y, R1, c[6];
DP3 result.texcoord[7].x, R1, c[5];
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
END
# 47 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c19.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c15.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp4 r1.w, v0, c3
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c15.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c15.w
dp3 r0.y, r1, c6
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
dp3 r0.w, -r2, c6
mul r2.xyz, r1.xyww, c19.x
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c15.w
mov r0.x, r2
mul r0.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r1
mov oT1.zw, r1
mul r1.xyz, v2, c15.w
mov oT5.xyz, c18
mov oT6.xyz, r0
dp3 oT7.z, r1, c6
dp3 oT7.y, r1, c5
dp3 oT7.x, r1, c4
add oD0.xyz, -r0, c12
mad oT0.zw, v3.xyxy, c17.xyxy, c17
mad oT0.xy, v3, c16, c16.zwzw
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..18] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
DP3 R0.y, R1, c[5];
DP3 R0.w, -R2, c[5];
DP4 R1.w, vertex.position, c[4];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[6];
DP3 R0.w, -R2, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[3], R0, c[15].w;
DP3 R0.y, R1, c[7];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
DP3 R0.w, -R2, c[7];
MUL R2.xyz, R1.xyww, c[0].x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[4], R0, c[15].w;
MOV R0.x, R2;
MUL R0.y, R2, c[14].x;
ADD result.texcoord[1].xy, R0, R2.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MUL R1.xyz, vertex.normal, c[15].w;
MOV result.texcoord[5].xyz, c[18];
MOV result.texcoord[6].xyz, R0;
DP3 result.texcoord[7].z, R1, c[7];
DP3 result.texcoord[7].y, R1, c[6];
DP3 result.texcoord[7].x, R1, c[5];
ADD result.color.xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
END
# 47 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
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
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [custom_ambient]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c19.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c15.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp4 r1.w, v0, c3
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul oT2, r0, c15.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul oT3, r0, c15.w
dp3 r0.y, r1, c6
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
dp3 r0.w, -r2, c6
mul r2.xyz, r1.xyww, c19.x
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul oT4, r0, c15.w
mov r0.x, r2
mul r0.y, r2, c13.x
mad oT1.xy, r2.z, c14.zwzw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r1
mov oT1.zw, r1
mul r1.xyz, v2, c15.w
mov oT5.xyz, c18
mov oT6.xyz, r0
dp3 oT7.z, r1, c6
dp3 oT7.y, r1, c5
dp3 oT7.x, r1, c4
add oD0.xyz, -r0, c12
mad oT0.zw, v3.xyxy, c17.xyxy, c17
mad oT0.xy, v3, c16, c16.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MOV R4.xyz, c[0];
DP3 R1.x, fragment.texcoord[2], R0;
DP3 R1.y, R0, fragment.texcoord[3];
DP3 R1.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
ADD R4.xyz, -R4, c[3];
MOV result.color.w, c[7].x;
TXP R1, fragment.texcoord[1], texture[0], 2D;
TEX R3.xyz, R0, texture[4], CUBE;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R4.xyz, R0.z, R4, c[0];
ADD R5.xyz, -R4, c[2];
MAD R4.xyz, R0.y, R5, R4;
MUL R0.y, R0.w, c[4].x;
MUL R2.xyz, R2, R4;
DP3 R0.w, fragment.color.primary, fragment.color.primary;
LG2 R0.z, R1.w;
MUL R4.xyz, R2, R0.y;
MUL R4.xyz, R4, -R0.z;
MUL R3.xyz, R0.y, R3;
MUL R0.x, R0, c[1].w;
MUL R0.xyz, R0.x, c[1];
RSQ R0.w, R0.w;
MAD R0.xyz, R0, c[7].y, R3;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R4;
ADD R0.xyz, R1, R0;
DP3 R1.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R1.w, R1.x;
MUL R2.xyz, R1.w, fragment.texcoord[7];
MUL R1.xyz, R0.w, fragment.color.primary;
DP3_SAT R0.w, R1, R2;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R2.xyz, R1.x, R0;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R2;
ADD R0.w, R0, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
END
# 55 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl t0
dcl t1
dcl t2
dcl t3
dcl t4
dcl t5.xyz
dcl t7.xyz
dcl v0.xyz
mov_pp r4.xyz, c3
mov r1.z, t4.w
mov r0.y, t0.w
mov r0.x, t0.z
add_pp r4.xyz, -c0, r4
texld r0, r0, s3
mov r0.x, r0.w
mad_pp r0.xy, r0, c7.x, c7.y
mul_pp r1.xy, r0, r0
add_pp_sat r1.x, r1, r1.y
add_pp r1.x, -r1, c7.z
rsq_pp r1.x, r1.x
rcp_pp r0.z, r1.x
dp3_pp r2.x, t2, r0
dp3_pp r2.y, r0, t3
dp3_pp r2.z, r0, t4
mov r1.x, t2.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.x, r1
texld r3, r0, s4
texld r0, t0, s1
texldp r1, t1, s0
texld r2, t0, s2
mad_pp r4.xyz, r2.z, r4, c0
add_pp r5.xyz, -r4, c2
mad_pp r4.xyz, r2.y, r5, r4
mul r5.xyz, r0, r4
mul r0.x, r2.w, c4
mul r6.xyz, r5, r0.x
log_pp r4.x, r1.w
mul r0.xyz, r0.x, r3
mul r4.xyz, r6, -r4.x
log_pp r1.x, r1.x
log_pp r1.z, r1.z
log_pp r1.y, r1.y
add_pp r1.xyz, -r1, t5
mad r4.xyz, r5, r1, r4
mul r1.x, r2, c1.w
mul r1.xyz, r1.x, c1
mad r2.xyz, r1, c7.w, r0
dp3 r1.x, v0, v0
rsq r1.x, r1.x
mul r3.xyz, r1.x, v0
dp3 r0.x, t7, t7
rsq r0.x, r0.x
mul r0.xyz, r0.x, t7
dp3_sat r0.x, r3, r0
rcp r1.x, c6.x
mul r1.x, r0, r1
add r2.xyz, r4, r2
mul r3.xyz, r2, r1.x
add r1.x, -r1, c7.z
mad r1.xyz, r1.x, c5, r3
add r0.x, r0, -c6
cmp_pp r0.xyz, r0.x, r2, r1
mov_pp r0.w, c7.z
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MOV R4.xyz, c[0];
DP3 R1.x, fragment.texcoord[2], R0;
DP3 R1.y, R0, fragment.texcoord[3];
DP3 R1.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
ADD R4.xyz, -R4, c[3];
MOV result.color.w, c[7].x;
TXP R1, fragment.texcoord[1], texture[0], 2D;
TEX R3.xyz, R0, texture[4], CUBE;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R4.xyz, R0.z, R4, c[0];
ADD R5.xyz, -R4, c[2];
MAD R4.xyz, R0.y, R5, R4;
MUL R0.y, R0.w, c[4].x;
MUL R2.xyz, R2, R4;
DP3 R0.w, fragment.color.primary, fragment.color.primary;
LG2 R0.z, R1.w;
MUL R4.xyz, R2, R0.y;
MUL R4.xyz, R4, -R0.z;
MUL R3.xyz, R0.y, R3;
MUL R0.x, R0, c[1].w;
MUL R0.xyz, R0.x, c[1];
RSQ R0.w, R0.w;
MAD R0.xyz, R0, c[7].y, R3;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R4;
ADD R0.xyz, R1, R0;
DP3 R1.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R1.w, R1.x;
MUL R2.xyz, R1.w, fragment.texcoord[7];
MUL R1.xyz, R0.w, fragment.color.primary;
DP3_SAT R0.w, R1, R2;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R2.xyz, R1.x, R0;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R2;
ADD R0.w, R0, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
END
# 55 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl t0
dcl t1
dcl t2
dcl t3
dcl t4
dcl t5.xyz
dcl t7.xyz
dcl v0.xyz
mov_pp r4.xyz, c3
mov r1.z, t4.w
mov r0.y, t0.w
mov r0.x, t0.z
add_pp r4.xyz, -c0, r4
texld r0, r0, s3
mov r0.x, r0.w
mad_pp r0.xy, r0, c7.x, c7.y
mul_pp r1.xy, r0, r0
add_pp_sat r1.x, r1, r1.y
add_pp r1.x, -r1, c7.z
rsq_pp r1.x, r1.x
rcp_pp r0.z, r1.x
dp3_pp r2.x, t2, r0
dp3_pp r2.y, r0, t3
dp3_pp r2.z, r0, t4
mov r1.x, t2.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.x, r1
texld r3, r0, s4
texld r0, t0, s1
texldp r1, t1, s0
texld r2, t0, s2
mad_pp r4.xyz, r2.z, r4, c0
add_pp r5.xyz, -r4, c2
mad_pp r4.xyz, r2.y, r5, r4
mul r5.xyz, r0, r4
mul r0.x, r2.w, c4
mul r6.xyz, r5, r0.x
log_pp r4.x, r1.w
mul r0.xyz, r0.x, r3
mul r4.xyz, r6, -r4.x
log_pp r1.x, r1.x
log_pp r1.z, r1.z
log_pp r1.y, r1.y
add_pp r1.xyz, -r1, t5
mad r4.xyz, r5, r1, r4
mul r1.x, r2, c1.w
mul r1.xyz, r1.x, c1
mad r2.xyz, r1, c7.w, r0
dp3 r1.x, v0, v0
rsq r1.x, r1.x
mul r3.xyz, r1.x, v0
dp3 r0.x, t7, t7
rsq r0.x, r0.x
mul r0.xyz, r0.x, t7
dp3_sat r0.x, r3, r0
rcp r1.x, c6.x
mul r1.x, r0, r1
add r2.xyz, r4, r2
mul r3.xyz, r2, r1.x
add r1.x, -r1, c7.z
mad r1.xyz, r1.x, c5, r3
add r0.x, r0, -c6
cmp_pp r0.xyz, r0.x, r2, r1
mov_pp r0.w, c7.z
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
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
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MOV R4.xyz, c[0];
DP3 R1.x, fragment.texcoord[2], R0;
DP3 R1.y, R0, fragment.texcoord[3];
DP3 R1.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
ADD R4.xyz, -R4, c[3];
MOV result.color.w, c[7].x;
TXP R1, fragment.texcoord[1], texture[0], 2D;
TEX R3.xyz, R0, texture[4], CUBE;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R4.xyz, R0.z, R4, c[0];
ADD R5.xyz, -R4, c[2];
MAD R4.xyz, R0.y, R5, R4;
MUL R0.y, R0.w, c[4].x;
MUL R2.xyz, R2, R4;
DP3 R0.w, fragment.color.primary, fragment.color.primary;
LG2 R0.z, R1.w;
MUL R4.xyz, R2, R0.y;
MUL R4.xyz, R4, -R0.z;
MUL R3.xyz, R0.y, R3;
MUL R0.x, R0, c[1].w;
MUL R0.xyz, R0.x, c[1];
RSQ R0.w, R0.w;
MAD R0.xyz, R0, c[7].y, R3;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R4;
ADD R0.xyz, R1, R0;
DP3 R1.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R1.w, R1.x;
MUL R2.xyz, R1.w, fragment.texcoord[7];
MUL R1.xyz, R0.w, fragment.color.primary;
DP3_SAT R0.w, R1, R2;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R2.xyz, R1.x, R0;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R2;
ADD R0.w, R0, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
END
# 55 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
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
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl t0
dcl t1
dcl t2
dcl t3
dcl t4
dcl t5.xyz
dcl t7.xyz
dcl v0.xyz
mov_pp r4.xyz, c3
mov r1.z, t4.w
mov r0.y, t0.w
mov r0.x, t0.z
add_pp r4.xyz, -c0, r4
texld r0, r0, s3
mov r0.x, r0.w
mad_pp r0.xy, r0, c7.x, c7.y
mul_pp r1.xy, r0, r0
add_pp_sat r1.x, r1, r1.y
add_pp r1.x, -r1, c7.z
rsq_pp r1.x, r1.x
rcp_pp r0.z, r1.x
dp3_pp r2.x, t2, r0
dp3_pp r2.y, r0, t3
dp3_pp r2.z, r0, t4
mov r1.x, t2.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.x, r1
texld r3, r0, s4
texld r0, t0, s1
texldp r1, t1, s0
texld r2, t0, s2
mad_pp r4.xyz, r2.z, r4, c0
add_pp r5.xyz, -r4, c2
mad_pp r4.xyz, r2.y, r5, r4
mul r5.xyz, r0, r4
mul r0.x, r2.w, c4
mul r6.xyz, r5, r0.x
log_pp r4.x, r1.w
mul r0.xyz, r0.x, r3
mul r4.xyz, r6, -r4.x
log_pp r1.x, r1.x
log_pp r1.z, r1.z
log_pp r1.y, r1.y
add_pp r1.xyz, -r1, t5
mad r4.xyz, r5, r1, r4
mul r1.x, r2, c1.w
mul r1.xyz, r1.x, c1
mad r2.xyz, r1, c7.w, r0
dp3 r1.x, v0, v0
rsq r1.x, r1.x
mul r3.xyz, r1.x, v0
dp3 r0.x, t7, t7
rsq r0.x, r0.x
mul r0.xyz, r0.x, t7
dp3_sat r0.x, r3, r0
rcp r1.x, c6.x
mul r1.x, r0, r1
add r2.xyz, r4, r2
mul r3.xyz, r2, r1.x
add r1.x, -r1, c7.z
mad r1.xyz, r1.x, c5, r3
add r0.x, r0, -c6
cmp_pp r0.xyz, r0.x, r2, r1
mov_pp r0.w, c7.z
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MOV R4.xyz, c[0];
DP3 R1.x, fragment.texcoord[2], R0;
DP3 R1.y, R0, fragment.texcoord[3];
DP3 R1.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
ADD R4.xyz, -R4, c[3];
MOV result.color.w, c[7].x;
TXP R1, fragment.texcoord[1], texture[0], 2D;
TEX R3.xyz, R0, texture[4], CUBE;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R4.xyz, R0.z, R4, c[0];
ADD R5.xyz, -R4, c[2];
MAD R4.xyz, R0.y, R5, R4;
MUL R0.y, R0.w, c[4].x;
MUL R2.xyz, R2, R4;
MUL R4.xyz, R2, R0.y;
DP3 R0.w, fragment.color.primary, fragment.color.primary;
MUL R4.xyz, R1.w, R4;
ADD R1.xyz, R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R4;
MUL R3.xyz, R0.y, R3;
MUL R0.x, R0, c[1].w;
MUL R0.xyz, R0.x, c[1];
MAD R0.xyz, R0, c[7].y, R3;
ADD R0.xyz, R1, R0;
DP3 R1.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R1.w, R1.x;
MUL R2.xyz, R1.w, fragment.texcoord[7];
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.color.primary;
DP3_SAT R0.w, R1, R2;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R2.xyz, R1.x, R0;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R2;
ADD R0.w, R0, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
END
# 51 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl t0
dcl t1
dcl t2
dcl t3
dcl t4
dcl t5.xyz
dcl t7.xyz
dcl v0.xyz
texld r3, t0, s2
mov r1.z, t4.w
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s3
mov r0.x, r0.w
mad_pp r0.xy, r0, c7.x, c7.y
mul_pp r1.xy, r0, r0
add_pp_sat r1.x, r1, r1.y
add_pp r1.x, -r1, c7.z
rsq_pp r1.x, r1.x
rcp_pp r0.z, r1.x
dp3_pp r2.x, t2, r0
dp3_pp r2.y, r0, t3
dp3_pp r2.z, r0, t4
mov r1.x, t2.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.x, r1
mov_pp r0.w, c7.z
texld r4, r0, s4
texldp r1, t1, s0
texld r2, t0, s1
mov_pp r0.xyz, c3
add_pp r0.xyz, -c0, r0
mad_pp r0.xyz, r3.z, r0, c0
add_pp r5.xyz, -r0, c2
mad_pp r5.xyz, r3.y, r5, r0
add_pp r1.xyz, r1, t5
mul r2.xyz, r2, r5
mul r0.x, r3.w, c4
mul r5.xyz, r2, r0.x
mul r5.xyz, r1.w, r5
mad r2.xyz, r2, r1, r5
mul r1.x, r3, c1.w
mul r0.xyz, r0.x, r4
mul r1.xyz, r1.x, c1
mad r3.xyz, r1, c7.w, r0
dp3 r1.x, v0, v0
rsq r1.x, r1.x
mul r4.xyz, r1.x, v0
dp3 r0.x, t7, t7
rsq r0.x, r0.x
mul r0.xyz, r0.x, t7
dp3_sat r0.x, r4, r0
rcp r1.x, c6.x
mul r1.x, r0, r1
add r2.xyz, r2, r3
mul r3.xyz, r2, r1.x
add r1.x, -r1, c7.z
mad r1.xyz, r1.x, c5, r3
add r0.x, r0, -c6
cmp_pp r0.xyz, r0.x, r2, r1
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MOV R4.xyz, c[0];
DP3 R1.x, fragment.texcoord[2], R0;
DP3 R1.y, R0, fragment.texcoord[3];
DP3 R1.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
ADD R4.xyz, -R4, c[3];
MOV result.color.w, c[7].x;
TXP R1, fragment.texcoord[1], texture[0], 2D;
TEX R3.xyz, R0, texture[4], CUBE;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R4.xyz, R0.z, R4, c[0];
ADD R5.xyz, -R4, c[2];
MAD R4.xyz, R0.y, R5, R4;
MUL R0.y, R0.w, c[4].x;
MUL R2.xyz, R2, R4;
MUL R4.xyz, R2, R0.y;
DP3 R0.w, fragment.color.primary, fragment.color.primary;
MUL R4.xyz, R1.w, R4;
ADD R1.xyz, R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R4;
MUL R3.xyz, R0.y, R3;
MUL R0.x, R0, c[1].w;
MUL R0.xyz, R0.x, c[1];
MAD R0.xyz, R0, c[7].y, R3;
ADD R0.xyz, R1, R0;
DP3 R1.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R1.w, R1.x;
MUL R2.xyz, R1.w, fragment.texcoord[7];
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.color.primary;
DP3_SAT R0.w, R1, R2;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R2.xyz, R1.x, R0;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R2;
ADD R0.w, R0, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
END
# 51 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl t0
dcl t1
dcl t2
dcl t3
dcl t4
dcl t5.xyz
dcl t7.xyz
dcl v0.xyz
texld r3, t0, s2
mov r1.z, t4.w
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s3
mov r0.x, r0.w
mad_pp r0.xy, r0, c7.x, c7.y
mul_pp r1.xy, r0, r0
add_pp_sat r1.x, r1, r1.y
add_pp r1.x, -r1, c7.z
rsq_pp r1.x, r1.x
rcp_pp r0.z, r1.x
dp3_pp r2.x, t2, r0
dp3_pp r2.y, r0, t3
dp3_pp r2.z, r0, t4
mov r1.x, t2.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.x, r1
mov_pp r0.w, c7.z
texld r4, r0, s4
texldp r1, t1, s0
texld r2, t0, s1
mov_pp r0.xyz, c3
add_pp r0.xyz, -c0, r0
mad_pp r0.xyz, r3.z, r0, c0
add_pp r5.xyz, -r0, c2
mad_pp r5.xyz, r3.y, r5, r0
add_pp r1.xyz, r1, t5
mul r2.xyz, r2, r5
mul r0.x, r3.w, c4
mul r5.xyz, r2, r0.x
mul r5.xyz, r1.w, r5
mad r2.xyz, r2, r1, r5
mul r1.x, r3, c1.w
mul r0.xyz, r0.x, r4
mul r1.xyz, r1.x, c1
mad r3.xyz, r1, c7.w, r0
dp3 r1.x, v0, v0
rsq r1.x, r1.x
mul r4.xyz, r1.x, v0
dp3 r0.x, t7, t7
rsq r0.x, r0.x
mul r0.xyz, r0.x, t7
dp3_sat r0.x, r4, r0
rcp r1.x, c6.x
mul r1.x, r0, r1
add r2.xyz, r2, r3
mul r3.xyz, r2, r1.x
add r1.x, -r1, c7.z
mad r1.xyz, r1.x, c5, r3
add r0.x, r0, -c6
cmp_pp r0.xyz, r0.x, r2, r1
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
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
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[8] = { program.local[0..6],
		{ 1, 16, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
TEX R2.xyz, fragment.texcoord[0], texture[1], 2D;
MAD R0.xy, R0.wyzw, c[7].z, -c[7].x;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[7].x;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
MOV R4.xyz, c[0];
DP3 R1.x, fragment.texcoord[2], R0;
DP3 R1.y, R0, fragment.texcoord[3];
DP3 R1.z, R0, fragment.texcoord[4];
MOV R0.x, fragment.texcoord[2].w;
MOV R0.z, fragment.texcoord[4].w;
MOV R0.y, fragment.texcoord[3].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[7].z, R0;
ADD R4.xyz, -R4, c[3];
MOV result.color.w, c[7].x;
TXP R1, fragment.texcoord[1], texture[0], 2D;
TEX R3.xyz, R0, texture[4], CUBE;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAD R4.xyz, R0.z, R4, c[0];
ADD R5.xyz, -R4, c[2];
MAD R4.xyz, R0.y, R5, R4;
MUL R0.y, R0.w, c[4].x;
MUL R2.xyz, R2, R4;
MUL R4.xyz, R2, R0.y;
DP3 R0.w, fragment.color.primary, fragment.color.primary;
MUL R4.xyz, R1.w, R4;
ADD R1.xyz, R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R4;
MUL R3.xyz, R0.y, R3;
MUL R0.x, R0, c[1].w;
MUL R0.xyz, R0.x, c[1];
MAD R0.xyz, R0, c[7].y, R3;
ADD R0.xyz, R1, R0;
DP3 R1.x, fragment.texcoord[7], fragment.texcoord[7];
RSQ R1.w, R1.x;
MUL R2.xyz, R1.w, fragment.texcoord[7];
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.color.primary;
DP3_SAT R0.w, R1, R2;
RCP R1.w, c[6].x;
MUL R1.x, R0.w, R1.w;
MUL R2.xyz, R1.x, R0;
ADD R1.x, -R1, c[7];
MAD R1.xyz, R1.x, c[5], R2;
ADD R0.w, R0, -c[6].x;
CMP result.color.xyz, R0.w, R1, R0;
END
# 51 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
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
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
dcl t0
dcl t1
dcl t2
dcl t3
dcl t4
dcl t5.xyz
dcl t7.xyz
dcl v0.xyz
texld r3, t0, s2
mov r1.z, t4.w
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s3
mov r0.x, r0.w
mad_pp r0.xy, r0, c7.x, c7.y
mul_pp r1.xy, r0, r0
add_pp_sat r1.x, r1, r1.y
add_pp r1.x, -r1, c7.z
rsq_pp r1.x, r1.x
rcp_pp r0.z, r1.x
dp3_pp r2.x, t2, r0
dp3_pp r2.y, r0, t3
dp3_pp r2.z, r0, t4
mov r1.x, t2.w
mov r1.y, t3.w
dp3 r0.x, r2, r1
mul r0.xyz, r2, r0.x
mad r0.xyz, -r0, c7.x, r1
mov_pp r0.w, c7.z
texld r4, r0, s4
texldp r1, t1, s0
texld r2, t0, s1
mov_pp r0.xyz, c3
add_pp r0.xyz, -c0, r0
mad_pp r0.xyz, r3.z, r0, c0
add_pp r5.xyz, -r0, c2
mad_pp r5.xyz, r3.y, r5, r0
add_pp r1.xyz, r1, t5
mul r2.xyz, r2, r5
mul r0.x, r3.w, c4
mul r5.xyz, r2, r0.x
mul r5.xyz, r1.w, r5
mad r2.xyz, r2, r1, r5
mul r1.x, r3, c1.w
mul r0.xyz, r0.x, r4
mul r1.xyz, r1.x, c1
mad r3.xyz, r1, c7.w, r0
dp3 r1.x, v0, v0
rsq r1.x, r1.x
mul r4.xyz, r1.x, v0
dp3 r0.x, t7, t7
rsq r0.x, r0.x
mul r0.xyz, r0.x, t7
dp3_sat r0.x, r4, r0
rcp r1.x, c6.x
mul r1.x, r0, r1
add r2.xyz, r2, r3
mul r3.xyz, r2, r1.x
add r1.x, -r1, c7.z
mad r1.xyz, r1.x, c5, r3
add r0.x, r0, -c6
cmp_pp r0.xyz, r0.x, r2, r1
mov_pp oC0, r0
"
}
}
 }
}
Fallback "Diffuse"
}