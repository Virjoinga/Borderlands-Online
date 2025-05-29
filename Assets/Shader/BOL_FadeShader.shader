≥êShader "BOL/Character/FadeShader" {
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
 _RoilingFlameModule ("Roiling Flame", 2D) = "white" {}
 _PyroEnergy ("PyroEnergy", 2D) = "white" {}
 _EmissiveHightColor ("Emissive highlight color", Color) = (0.5,0.5,0.5,1)
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
Keywords { "DirUpToDown" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_Scale]
Vector 14 [_CenterPosTime]
Vector 15 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[16] = { { 0.039999999, 0.0099999998, 1 },
		state.matrix.mvp,
		program.local[5..15] };
TEMP R0;
TEMP R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, R0, vertex.attrib[14].w;
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1].xyz, R0, c[13].w;
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2].xyz, R0, c[13].w;
MOV R0.xyz, c[14];
MOV R0.w, c[0].z;
DP4 R0.x, R0, c[9];
ADD R0.w, -vertex.position.x, R0.x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.y, R1, c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3].xyz, R0, c[13].w;
DP4 R0.x, vertex.position, c[6];
ADD R0.x, R0, -c[14].y;
ABS result.color.x, R0.w;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MOV result.color.zw, c[0].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
ABS result.color.y, R0.x;
END
# 30 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DirUpToDown" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_CenterPosTime]
Vector 14 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_color0 o5
def c15, 1.00000000, 0.04000000, 0.01000000, 0
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
mul o2.xyz, r0, c12.w
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3.xyz, r0, c12.w
mov r0.xyz, c13
mov r0.w, c15.x
dp4 r0.x, r0, c8
add r0.w, -v0.x, r0.x
dp3 r0.x, v1, c6
dp3 r0.y, r1, c6
dp3 r0.z, v2, c6
mul o4.xyz, r0, c12.w
dp4 r0.x, v0, c5
add r0.x, r0, -c13.y
abs o5.x, r0.w
mad o1.xy, v3, c14, c14.zwzw
mov o5.zw, c15.xyyz
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
abs o5.y, r0.x
"
}
SubProgram "opengl " {
Keywords { "DirDownToUp" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_Scale]
Vector 14 [_CenterPosTime]
Vector 15 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[16] = { { 0.039999999, 0.0099999998, 1 },
		state.matrix.mvp,
		program.local[5..15] };
TEMP R0;
TEMP R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, R0, vertex.attrib[14].w;
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1].xyz, R0, c[13].w;
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2].xyz, R0, c[13].w;
MOV R0.xyz, c[14];
MOV R0.w, c[0].z;
DP4 R0.x, R0, c[9];
ADD R0.w, -vertex.position.x, R0.x;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.y, R1, c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3].xyz, R0, c[13].w;
DP4 R0.x, vertex.position, c[6];
ADD R0.x, R0, -c[14].y;
ABS result.color.x, R0.w;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MOV result.color.zw, c[0].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
ABS result.color.y, R0.x;
END
# 30 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DirDownToUp" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_Scale]
Vector 13 [_CenterPosTime]
Vector 14 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_color0 o5
def c15, 1.00000000, 0.04000000, 0.01000000, 0
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
mul o2.xyz, r0, c12.w
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3.xyz, r0, c12.w
mov r0.xyz, c13
mov r0.w, c15.x
dp4 r0.x, r0, c8
add r0.w, -v0.x, r0.x
dp3 r0.x, v1, c6
dp3 r0.y, r1, c6
dp3 r0.z, v2, c6
mul o4.xyz, r0, c12.w
dp4 r0.x, v0, c5
add r0.x, r0, -c13.y
abs o5.x, r0.w
mad o1.xy, v3, c14, c14.zwzw
mov o5.zw, c15.xyyz
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
abs o5.y, r0.x
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DirUpToDown" }
Vector 0 [_CenterPosTime]
Float 1 [_MetalShininess]
Float 2 [_SkinShininess]
SetTexture 0 [_RoilingFlameModule] 2D 0
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..2],
		{ 0.5, 2, 1, 5 },
		{ 0.1, 0 } };
TEMP R0;
TEMP R1;
TEX R0.yw, fragment.texcoord[0], texture[3], 2D;
MAD R0.xy, R0.wyzw, c[3].y, -c[3].z;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[3];
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
DP3 R1.x, R0, fragment.texcoord[1];
DP3 R1.z, fragment.texcoord[3], R0;
DP3 R1.y, R0, fragment.texcoord[2];
TEX R0.yz, fragment.texcoord[0], texture[2], 2D;
SGE R0.xy, R0.yzzw, c[3].x;
MUL R0.w, R0.y, c[2].x;
MOV R0.z, c[1].x;
MAD R0.y, -R0, c[2].x, R0.z;
MAD result.color.w, R0.x, R0.y, R0;
MUL R0.zw, fragment.texcoord[0].xyxy, c[3].w;
TEX R0.z, R0.zwzw, texture[0], 2D;
MUL R0.y, R0.z, c[4].x;
ADD R0.w, R0.y, c[0];
MOV R0.x, c[4];
MAD result.color.xyz, R1, c[3].x, c[3].x;
ADD R1.x, -R0, c[0].w;
MAD R0.x, R0.z, c[4], R1;
SLT R0.y, R1.x, fragment.color.primary;
MOV R0.z, c[3];
ABS R1.x, R0.y;
CMP R1.x, -R1, c[4].y, R0.z;
SLT R0.z, fragment.color.primary.y, R0.w;
MUL R0.w, R0.z, R1.x;
SLT R1.x, fragment.color.primary.y, R0;
MUL R0.x, R0.z, R0.y;
MUL R0.x, R0, R1;
KIL -R0.w;
KIL -R0.x;
END
# 35 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DirUpToDown" }
Vector 0 [_CenterPosTime]
Float 1 [_MetalShininess]
Float 2 [_SkinShininess]
SetTexture 0 [_RoilingFlameModule] 2D 0
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s2
dcl_2d s3
def c3, 5.00000000, -0.10000000, 0.10000000, 1.00000000
def c4, -0.50000000, 1.00000000, 0.00000000, 0.50000000
def c5, 2.00000000, -1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_color0 v4.xy
mul r0.xy, v0, c3.x
texld r0.z, r0, s0
mul r0.y, r0.z, c3.z
mov r0.x, c0.w
add r0.x, c3.y, r0
add r0.w, r0.y, c0
mad r0.y, r0.z, c3.z, r0.x
if_lt v4.y, r0.w
if_gt v4.y, r0.x
if_lt v4.y, r0.y
mov_pp r0, -c3.w
texkill r0.xyzw
else
endif
else
mov_pp r0, -c3.w
texkill r0.xyzw
endif
endif
texld r0.yw, v0, s3
mad_pp r2.xy, r0.wyzw, c5.x, c5.y
mul_pp r0.xy, r2, r2
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.y
rsq_pp r0.x, r0.x
rcp_pp r2.z, r0.x
texld r0.yz, v0, s2
add r0.xy, r0.yzzw, c4.x
cmp r0.xy, r0, c4.y, c4.z
mul_pp r0.w, r0.y, c2.x
mov_pp r0.z, c1.x
mad_pp r0.y, -r0, c2.x, r0.z
dp3 r1.z, v3, r2
dp3 r1.y, r2, v2
dp3 r1.x, r2, v1
mad_pp oC0.xyz, r1, c4.w, c4.w
mad_pp oC0.w, r0.x, r0.y, r0
"
}
SubProgram "opengl " {
Keywords { "DirDownToUp" }
Vector 0 [_CenterPosTime]
Float 1 [_MetalShininess]
Float 2 [_SkinShininess]
SetTexture 0 [_RoilingFlameModule] 2D 0
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..2],
		{ 0.5, 2, 1, 5 },
		{ 0.1, 0 } };
TEMP R0;
TEMP R1;
TEX R0.yw, fragment.texcoord[0], texture[3], 2D;
MAD R1.xy, R0.wyzw, c[3].y, -c[3].z;
MUL R0.xy, R1, R1;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[3].z;
RSQ R0.x, R0.x;
RCP R1.z, R0.x;
MUL R0.xz, fragment.texcoord[0].xyyw, c[3].w;
TEX R0.z, R0.xzzw, texture[0], 2D;
DP3 R0.w, fragment.texcoord[3], R1;
DP3 R0.y, R1, fragment.texcoord[2];
DP3 R0.x, R1, fragment.texcoord[1];
MAD result.color.xyz, R0.xyww, c[3].x, c[3].x;
MUL R0.z, R0, c[4].x;
ADD R0.x, R0.z, c[0].w;
SLT R1.x, fragment.color.primary.y, R0;
ADD R0.w, R0.x, -c[4].x;
TEX R0.yz, fragment.texcoord[0], texture[2], 2D;
MOV R0.x, c[3].z;
ABS R1.x, R1;
CMP R1.x, -R1, c[4].y, R0;
SLT R0.x, R0.w, fragment.color.primary.y;
MUL R1.x, R0, R1;
SGE R0.xy, R0.yzzw, c[3].x;
MUL R0.w, R0.y, c[2].x;
MOV R0.z, c[1].x;
MAD R0.y, -R0, c[2].x, R0.z;
MAD result.color.w, R0.x, R0.y, R0;
KIL -R1.x;
END
# 29 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DirDownToUp" }
Vector 0 [_CenterPosTime]
Float 1 [_MetalShininess]
Float 2 [_SkinShininess]
SetTexture 0 [_RoilingFlameModule] 2D 0
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s2
dcl_2d s3
def c3, 5.00000000, 0.10000000, -0.10000000, 1.00000000
def c4, -0.50000000, 1.00000000, 0.00000000, 0.50000000
def c5, 2.00000000, -1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_color0 v4.xy
mul r0.xy, v0, c3.x
texld r0.z, r0, s0
mul r0.x, r0.z, c3.y
add r0.x, r0, c0.w
add r0.y, r0.x, c3.z
if_gt v4.y, r0.y
if_lt v4.y, r0.x
else
mov_pp r0, -c3.w
texkill r0.xyzw
endif
endif
texld r0.yw, v0, s3
mad_pp r2.xy, r0.wyzw, c5.x, c5.y
mul_pp r0.xy, r2, r2
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.y
rsq_pp r0.x, r0.x
rcp_pp r2.z, r0.x
texld r0.yz, v0, s2
add r0.xy, r0.yzzw, c4.x
cmp r0.xy, r0, c4.y, c4.z
mul_pp r0.w, r0.y, c2.x
mov_pp r0.z, c1.x
mad_pp r0.y, -r0, c2.x, r0.z
dp3 r1.z, v3, r2
dp3 r1.y, r2, v2
dp3 r1.x, r2, v1
mad_pp oC0.xyz, r1, c4.w, c4.w
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirUpToDown" }
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
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c26, 0.50000000, 1.00000000, 0.10000000, 0.00000000
def c27, 0.01000000, -0.05000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_2d s0
mul r1.xyz, v2, c22.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c26.y
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.y, r2.w, r2.w
mad r0.w, r0.x, r0.x, -r0.y
dp4 r3.z, r1, c20
dp4 r3.y, r1, c19
dp4 r3.x, r1, c18
add r2.xyz, r2, r3
mul r3.xyz, r0.w, c21
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c26.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r3.y, r1, c6
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
mov r0.xyz, c23
mov r0.w, c26.y
dp4 r0.x, r0, c10
add r0.x, -v0.z, r0
dp4 r0.y, v0, c5
add r0.y, r0, -c23
abs r1.x, r0
abs r1.y, r0
mul r0.xy, r1, c26.z
mov r0.z, c26.w
texldl r0.z, r0.xyzz, s0
mul r0.x, r0.z, c27
min r0.z, r0.x, c26
dp4 r0.w, v0, c3
dp3 r3.w, -r2, c6
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c26.x
max r0.z, r0, c27.x
mul r1.w, r2.y, c13.x
mov r1.z, r2.x
mad o2.xy, r2.z, c14.zwzw, r1.zwzw
add r1.w, r0.z, c27.y
dp4 r0.z, v0, c2
mov r1.z, c26
dp3 r3.x, v1, c6
dp3 r3.z, v2, c6
mul o5, r3, c22.w
mov o7, r1
mov o0, r0
mov o2.zw, r0
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirUpToDown" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "DirUpToDown" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirUpToDown" }
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
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c26, 0.50000000, 1.00000000, 0.10000000, 0.00000000
def c27, 0.01000000, -0.05000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_2d s0
mul r1.xyz, v2, c22.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c26.y
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.y, r2.w, r2.w
mad r0.w, r0.x, r0.x, -r0.y
dp4 r3.z, r1, c20
dp4 r3.y, r1, c19
dp4 r3.x, r1, c18
add r2.xyz, r2, r3
mul r3.xyz, r0.w, c21
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c26.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r3.y, r1, c6
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
mov r0.xyz, c23
mov r0.w, c26.y
dp4 r0.x, r0, c10
add r0.x, -v0.z, r0
dp4 r0.y, v0, c5
add r0.y, r0, -c23
abs r1.x, r0
abs r1.y, r0
mul r0.xy, r1, c26.z
mov r0.z, c26.w
texldl r0.z, r0.xyzz, s0
mul r0.x, r0.z, c27
min r0.z, r0.x, c26
dp4 r0.w, v0, c3
dp3 r3.w, -r2, c6
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c26.x
max r0.z, r0, c27.x
mul r1.w, r2.y, c13.x
mov r1.z, r2.x
mad o2.xy, r2.z, c14.zwzw, r1.zwzw
add r1.w, r0.z, c27.y
dp4 r0.z, v0, c2
mov r1.z, c26
dp3 r3.x, v1, c6
dp3 r3.z, v2, c6
mul o5, r3, c22.w
mov o7, r1
mov o0, r0
mov o2.zw, r0
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirUpToDown" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "DirUpToDown" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirDownToUp" }
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
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c26, 0.50000000, 1.00000000, 0.10000000, 0.00000000
def c27, 0.01000000, -0.05000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_2d s0
mul r1.xyz, v2, c22.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c26.y
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.y, r2.w, r2.w
mad r0.w, r0.x, r0.x, -r0.y
dp4 r3.z, r1, c20
dp4 r3.y, r1, c19
dp4 r3.x, r1, c18
add r2.xyz, r2, r3
mul r3.xyz, r0.w, c21
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c26.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r3.y, r1, c6
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
mov r0.xyz, c23
mov r0.w, c26.y
dp4 r0.x, r0, c10
add r0.x, -v0.z, r0
dp4 r0.y, v0, c5
add r0.y, r0, -c23
abs r1.x, r0
abs r1.y, r0
mul r0.xy, r1, c26.z
mov r0.z, c26.w
texldl r0.z, r0.xyzz, s0
mul r0.x, r0.z, c27
min r0.z, r0.x, c26
dp4 r0.w, v0, c3
dp3 r3.w, -r2, c6
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c26.x
max r0.z, r0, c27.x
mul r1.w, r2.y, c13.x
mov r1.z, r2.x
mad o2.xy, r2.z, c14.zwzw, r1.zwzw
add r1.w, r0.z, c27.y
dp4 r0.z, v0, c2
mov r1.z, c26
dp3 r3.x, v1, c6
dp3 r3.z, v2, c6
mul o5, r3, c22.w
mov o7, r1
mov o0, r0
mov o2.zw, r0
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirDownToUp" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "DirDownToUp" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirDownToUp" }
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
Vector 23 [_CenterPosTime]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
SetTexture 0 [_RoilingFlameModule] 2D 0
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c26, 0.50000000, 1.00000000, 0.10000000, 0.00000000
def c27, 0.01000000, -0.05000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_2d s0
mul r1.xyz, v2, c22.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c26.y
dp4 r2.z, r0, c17
dp4 r2.y, r0, c16
dp4 r2.x, r0, c15
mul r0.y, r2.w, r2.w
mad r0.w, r0.x, r0.x, -r0.y
dp4 r3.z, r1, c20
dp4 r3.y, r1, c19
dp4 r3.x, r1, c18
add r2.xyz, r2, r3
mul r3.xyz, r0.w, c21
add o6.xyz, r2, r3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
mov r0.w, c26.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r0.y, r1, c4
dp3 r3.y, r1, c6
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c22.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c22.w
mov r0.xyz, c23
mov r0.w, c26.y
dp4 r0.x, r0, c10
add r0.x, -v0.z, r0
dp4 r0.y, v0, c5
add r0.y, r0, -c23
abs r1.x, r0
abs r1.y, r0
mul r0.xy, r1, c26.z
mov r0.z, c26.w
texldl r0.z, r0.xyzz, s0
mul r0.x, r0.z, c27
min r0.z, r0.x, c26
dp4 r0.w, v0, c3
dp3 r3.w, -r2, c6
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c26.x
max r0.z, r0, c27.x
mul r1.w, r2.y, c13.x
mov r1.z, r2.x
mad o2.xy, r2.z, c14.zwzw, r1.zwzw
add r1.w, r0.z, c27.y
dp4 r0.z, v0, c2
mov r1.z, c26
dp3 r3.x, v1, c6
dp3 r3.z, v2, c6
mul o5, r3, c22.w
mov o7, r1
mov o0, r0
mov o2.zw, r0
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c24, c24.zwzw
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirDownToUp" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "DirDownToUp" }
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
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirUpToDown" }
Vector 0 [_CenterPosTime]
Vector 1 [_EmissiveHightColor]
Vector 2 [_Color]
Vector 3 [_IllumnColor]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ReflectColor]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RoilingFlameModule] 2D 5
SetTexture 6 [_PyroEnergy] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
def c8, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c9, 5.00000000, -0.10000000, 0.10000000, 0.50000000
def c10, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c11, 50.00000000, 0.20000000, 1.00000000, 0.00000000
def c12, -0.01000000, 0.40000001, 3.00000000, 8.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
mov_pp r0.xyz, c5
add_pp r0.xyz, -c2, r0
texld r5, v0, s2
mad_pp r1.xyz, r5.z, r0, c2
texld r3.yw, v0.zwzw, s3
mad_pp r0.xy, r3.wyzw, c7.x, c7.y
add_pp r2.xyz, -r1, c4
mad_pp r2.xyz, r5.y, r2, r1
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
texld r1.xyz, v0, s1
mul r1.xyz, r1, r2
mul r3.w, r5, c6.x
add_pp r0.z, -r0, c7
rsq_pp r0.z, r0.z
rcp_pp r0.z, r0.z
mul r4.xyz, r1, r3.w
dp3_pp r3.x, v2, r0
dp3_pp r3.y, r0, v3
dp3_pp r3.z, r0, v4
texldp r0, v1, s0
mov r2.x, v2.w
mov r2.z, v4.w
mov r2.y, v3.w
dp3 r1.w, r3, r2
mul r3.xyz, r3, r1.w
log_pp r1.w, r0.w
mad r2.xyz, -r3, c7.x, r2
mul r4.xyz, r4, -r1.w
texld r2.xyz, r2, s4
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, v5
mad r0.xyz, r1, r3, r4
mul r1.xyz, r3.w, r2
mul r0.w, r5.x, c3
mul r2.xyz, r0.w, c3
mad r1.xyz, r2, c7.w, r1
mov r3.w, c0
mad r0.w, r3, c10.x, c10.y
frc r0.w, r0
add r2.xyz, r0, r1
mad r3.w, r0, c10.z, c10
sincos r0.xy, r3.w
mov_pp r3.w, -r1
dp4_pp r1.w, r3, c8
mad r3.w, r0.y, c9, c9
mul r0.xy, v0, c9.x
texld r0.z, r0, s6
mov r3.xyz, c1
mov r4.x, r0.z
texld r0.z, r0, s5
mul r0.y, r0.z, c9.z
mov r0.x, c0.w
add r0.x, c9.y, r0
add r0.w, r0.y, c0
mad r0.y, r0.z, c9.z, r0.x
mov_pp r1.xyz, r2
mul r3.xyz, c11.x, r3
if_lt v6.y, r0.w
if_gt v6.y, r0.x
if_lt v6.y, r0.y
mov_pp r0, -c7.z
texkill r0.xyzw
else
mul r0.x, v6.z, c7
rcp r4.z, r0.x
add r0.x, v6.y, c11.y
mul r5.z, r0.x, r4
add r0.z, r5, c7.y
frc r6.x, r5.z
add r5.z, r5, -r6.x
mul r5.z, r5, c9.w
frc r5.z, r5
add r5.z, r5, c12.x
add r4.y, v6.x, c11
rcp r4.w, v6.z
mul r5.y, r4, r4.w
add r0.y, r5, c7
frc r5.w, r5.y
add r5.y, r5, -r5.w
mul r5.y, r5, c9.w
frc r5.y, r5
add r5.y, r5, c12.x
cmp_pp r0.w, r0.y, c11.z, c11
cmp r0.z, r0, c11.w, c11
mul_pp r5.x, r0.w, r0.z
cmp_pp r0.z, -r5.x, r0.w, c8.w
mul_pp r0.w, r0, r0.z
cmp r5.z, r5, c11.w, c11
cmp r5.y, r5, c11.w, c11.z
mul_pp r5.y, r5, r5.z
cmp r5.z, r0.y, r2.w, c8.w
mul_pp r5.y, r0.w, r5
cmp_pp r0.y, -r5, r0.z, c8.w
cmp r0.z, -r5.x, r5, c8.w
mul_pp r5.z, r0.w, r0.y
cmp r5.y, -r5, r0.z, c9.z
add r0.y, v6, v6.w
add r0.z, r0.y, c11.y
mul r6.x, r4.w, r0.z
add r4.w, r6.x, c7.y
frc r6.z, r6.x
add r6.x, r6, -r6.z
add r0.w, v6.x, v6
add r0.w, r0, c11.y
mul r5.w, r4.z, r0
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c12
add r4.z, r5.w, c7.y
frc r6.y, r5.w
add r5.w, r5, -r6.y
cmp r5.x, r4.w, c11.w, c11.z
cmp_pp r4.w, r4.z, c11.z, c11
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c12.x
mul_pp r5.x, r4.w, r5
cmp r5.y, -r5.z, r5, c8.w
cmp_pp r5.z, -r5.x, r4.w, c8.w
mul_pp r4.w, r4, r5.z
cmp r6.x, r6, c11.w, c11.z
cmp r5.w, r5, c11, c11.z
mul_pp r5.w, r5, r6.x
cmp r6.x, r4.z, r2.w, c8.w
mul_pp r4.z, r4.w, r5.w
cmp r5.w, -r5.x, r6.x, c8
cmp_pp r5.x, -r4.z, r5.z, c8.w
cmp r5.z, -r4, r5.w, c9
mul_pp r4.z, r4.w, r5.x
mul r4.w, v6.z, c12.y
cmp r4.z, -r4, r5, c8.w
rcp r5.w, r4.w
mul r5.z, r0.x, r5.w
mul r5.x, r4.w, c12.z
rcp r6.x, r5.x
mul r0.x, r0, r6
add r4.z, r5.y, r4
mul r5.y, r0.w, r6.x
add r4.w, r5.y, c7.y
frc r6.z, r5.y
add r5.y, r5, -r6.z
add r5.x, r5.z, c7.y
frc r6.w, r5.z
add r5.z, r5, -r6.w
mul r6.w, r0, r5
add r5.w, r0.x, c7.y
frc r7.y, r0.x
mul r5.z, r5, c9.w
mul r5.y, r5, c9.w
frc r5.z, r5
frc r5.y, r5
add r5.z, r5, c12.x
add r5.y, r5, c12.x
cmp_pp r6.y, r4.w, c11.z, c11.w
cmp r5.x, r5, c11.w, c11.z
mul_pp r5.x, r6.y, r5
add r0.w, r6, c7.y
cmp r6.x, r5.w, c11.w, c11.z
cmp_pp r5.w, r0, c11.z, c11
mul_pp r6.x, r5.w, r6
cmp_pp r6.z, -r6.x, r5.w, c8.w
cmp r5.y, r5, c11.w, c11.z
cmp r5.z, r5, c11.w, c11
mul_pp r5.z, r5.y, r5
cmp_pp r5.y, -r5.x, r6, c8.w
mul_pp r6.y, r6, r5
mul_pp r5.z, r6.y, r5
frc r7.x, r6.w
add r7.y, r0.x, -r7
add r0.x, r6.w, -r7
mul r6.w, r7.y, c9
mul r0.x, r0, c9.w
frc r6.w, r6
frc r0.x, r0
add r6.w, r6, c12.x
add r0.x, r0, c12
cmp r0.x, r0, c11.w, c11.z
cmp r6.w, r6, c11, c11.z
mul_pp r6.w, r0.x, r6
mul_pp r0.x, r5.w, r6.z
cmp r5.w, r0, r2, c8
cmp r6.x, -r6, r5.w, c8.w
mul_pp r0.w, r0.x, r6
cmp_pp r5.w, -r0, r6.z, c8
cmp r0.w, -r0, r6.x, c9.z
mul_pp r0.x, r0, r5.w
cmp r0.x, -r0, r0.w, c8.w
cmp_pp r0.w, -r5.z, r5.y, c8
add r0.x, r4.z, r0
cmp r4.z, r4.w, r2.w, c8.w
cmp r4.z, -r5.x, r4, c8.w
mul r4.w, v6.z, c11.y
mul r5.x, r4.w, c7
cmp r5.z, -r5, r4, c9
rcp r4.z, r5.x
mul r6.x, r0.z, r4.z
add r5.x, r6, c7.y
mul_pp r0.w, r6.y, r0
cmp r0.w, -r0, r5.z, c8
rcp r4.w, r4.w
mul r5.w, r4.y, r4
frc r6.z, r6.x
add r6.x, r6, -r6.z
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c12
add r0.z, r5.w, c7.y
cmp r5.y, r5.x, c11.w, c11.z
cmp_pp r5.x, r0.z, c11.z, c11.w
mul_pp r5.y, r5.x, r5
cmp_pp r5.z, -r5.y, r5.x, c8.w
frc r6.y, r5.w
add r5.w, r5, -r6.y
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c12.x
mul_pp r5.x, r5, r5.z
cmp r6.x, r6, c11.w, c11.z
cmp r5.w, r5, c11, c11.z
mul_pp r5.w, r5, r6.x
cmp r6.x, r0.z, r2.w, c8.w
mul_pp r0.z, r5.x, r5.w
cmp r5.w, -r5.y, r6.x, c8
cmp_pp r5.y, -r0.z, r5.z, c8.w
cmp r5.z, -r0, r5.w, c9
mul_pp r0.z, r5.x, r5.y
add r5.y, v6.w, r0
cmp r0.z, -r0, r5, c8.w
add r0.x, r0, r0.w
add r5.x, r0, r0.z
pow r0, r3.w, c12.w
add r0.y, r5, c11
mul r4.w, r4, r0.y
mul r3.w, r4.y, r4.z
add r0.y, r3.w, c7
frc r4.z, r3.w
add r3.w, r3, -r4.z
add r0.z, r4.w, c7.y
mad r3.xyz, r0.x, r3, r4.x
frc r5.y, r4.w
add r4.w, r4, -r5.y
mul r4.z, r4.w, c9.w
mul r3.w, r3, c9
frc r4.z, r4
frc r3.w, r3
add r4.z, r4, c12.x
add r3.w, r3, c12.x
cmp_pp r4.y, r0, c11.z, c11.w
cmp r0.z, r0, c11.w, c11
mul_pp r0.z, r4.y, r0
cmp r2.w, r0.y, r2, c8
cmp_pp r0.w, -r0.z, r4.y, c8
cmp r3.w, r3, c11, c11.z
cmp r4.z, r4, c11.w, c11
mul_pp r4.z, r3.w, r4
mul_pp r3.w, r4.y, r0
mul_pp r0.y, r3.w, r4.z
cmp r2.w, -r0.z, r2, c8
cmp_pp r0.z, -r0.y, r0.w, c8.w
cmp r0.w, -r0.y, r2, c9.z
mul_pp r0.y, r3.w, r0.z
cmp r0.y, -r0, r0.w, c8.w
add r0.x, r5, r0.y
add_pp r2.xyz, r2, r3
add r0.x, r0, c9.y
cmp_pp r1.xyz, -r0.x, r1, r2
endif
else
mov_pp r0, -c7.z
texkill r0.xyzw
endif
endif
mov_pp oC0, r1
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirUpToDown" }
Vector 0 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, 8.00000000, 0.00000000, 0, 0
def c2, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
texld r1, v5, s1
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
mul_pp r2.xyz, r1.w, r1
mul_pp r1.xyz, r0, c1.x
dp4 r0.x, v6, v6
rsq r1.w, r0.x
texldp r0, v1, s0
rcp r1.w, r1.w
log_pp r0.w, r0.w
mad_pp r2.xyz, r2, c1.x, -r1
mad_sat r1.w, r1, c0.z, c0
mad_pp r1.xyz, r1.w, r2, r1
mov_pp r0.w, -r0
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, r1
dp4_pp oC0.w, r0, c2
mov_pp oC0.xyz, c1.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "DirUpToDown" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c0, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c1, -0.40824831, 0.70710677, 0.57735026, 1.00000000
def c2, 0.81649655, 0.00000000, 0.57735026, 0
def c3, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
dp3_pp_sat r2.z, r1, c0
dp3_pp_sat r2.x, r1, c2
dp3_pp_sat r2.y, r1, c1
mul_pp r1.xyz, r0, r2
texld r0, v5, s1
mul_pp r0.xyz, r0.w, r0
dp3_pp r1.x, r1, c0.w
mul_pp r1.xyz, r0, r1.x
texldp r0, v1, s0
mul_pp r1.xyz, r1, c0.w
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
mov_pp r1.w, c1
log_pp r0.w, r0.w
add_pp r0, -r0, r1
dp4_pp oC0.w, r0, c3
mov_pp oC0.xyz, c2.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirUpToDown" }
Vector 0 [_CenterPosTime]
Vector 1 [_EmissiveHightColor]
Vector 2 [_Color]
Vector 3 [_IllumnColor]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ReflectColor]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RoilingFlameModule] 2D 5
SetTexture 6 [_PyroEnergy] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
def c8, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c9, 5.00000000, -0.10000000, 0.10000000, 0.50000000
def c10, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c11, 50.00000000, 0.20000000, 1.00000000, 0.00000000
def c12, -0.01000000, 0.40000001, 3.00000000, 8.00000000
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
texld r0.yw, v0.zwzw, s3
mad_pp r0.xy, r0.wyzw, c7.x, c7.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
texld r5, v0, s2
mov_pp r1.xyz, c5
add_pp r1.xyz, -c2, r1
mad_pp r1.xyz, r5.z, r1, c2
add_pp r2.xyz, -r1, c4
mad_pp r2.xyz, r5.y, r2, r1
texld r1.xyz, v0, s1
add_pp r0.z, -r0, c7
rsq_pp r0.z, r0.z
mul r2.xyz, r1, r2
rcp_pp r0.z, r0.z
mul r0.w, r5, c6.x
dp3_pp r1.x, v2, r0
dp3_pp r1.y, r0, v3
dp3_pp r1.z, r0, v4
mul r3.xyz, r2, r0.w
mov r0.x, v2.w
mov r0.z, v4.w
mov r0.y, v3.w
dp3 r1.w, r1, r0
mul r1.xyz, r1, r1.w
mad r0.xyz, -r1, c7.x, r0
texldp r1, v1, s0
mul r4.xyz, r1.w, r3
add_pp r3.xyz, r1, v5
texld r0.xyz, r0, s4
mul r0.xyz, r0.w, r0
mad r1.xyz, r2, r3, r4
mul r0.w, r5.x, c3
mul r2.xyz, r0.w, c3
mad r0.xyz, r2, c7.w, r0
add r2.xyz, r1, r0
mov r3.w, c0
mad r0.w, r3, c10.x, c10.y
frc r0.w, r0
mad r3.w, r0, c10.z, c10
sincos r0.xy, r3.w
mov_pp r3.w, r1
dp4_pp r1.w, r3, c8
mad r3.w, r0.y, c9, c9
mul r0.xy, v0, c9.x
texld r0.z, r0, s6
mov r3.xyz, c1
mov r4.x, r0.z
texld r0.z, r0, s5
mul r0.y, r0.z, c9.z
mov r0.x, c0.w
add r0.x, c9.y, r0
add r0.w, r0.y, c0
mad r0.y, r0.z, c9.z, r0.x
mov_pp r1.xyz, r2
mul r3.xyz, c11.x, r3
if_lt v6.y, r0.w
if_gt v6.y, r0.x
if_lt v6.y, r0.y
mov_pp r0, -c7.z
texkill r0.xyzw
else
mul r0.x, v6.z, c7
rcp r4.z, r0.x
add r0.x, v6.y, c11.y
mul r5.z, r0.x, r4
add r0.z, r5, c7.y
frc r6.x, r5.z
add r5.z, r5, -r6.x
mul r5.z, r5, c9.w
frc r5.z, r5
add r5.z, r5, c12.x
add r4.y, v6.x, c11
rcp r4.w, v6.z
mul r5.y, r4, r4.w
add r0.y, r5, c7
frc r5.w, r5.y
add r5.y, r5, -r5.w
mul r5.y, r5, c9.w
frc r5.y, r5
add r5.y, r5, c12.x
cmp_pp r0.w, r0.y, c11.z, c11
cmp r0.z, r0, c11.w, c11
mul_pp r5.x, r0.w, r0.z
cmp_pp r0.z, -r5.x, r0.w, c8.w
mul_pp r0.w, r0, r0.z
cmp r5.z, r5, c11.w, c11
cmp r5.y, r5, c11.w, c11.z
mul_pp r5.y, r5, r5.z
cmp r5.z, r0.y, r2.w, c8.w
mul_pp r5.y, r0.w, r5
cmp_pp r0.y, -r5, r0.z, c8.w
cmp r0.z, -r5.x, r5, c8.w
mul_pp r5.z, r0.w, r0.y
cmp r5.y, -r5, r0.z, c9.z
add r0.y, v6, v6.w
add r0.z, r0.y, c11.y
mul r6.x, r4.w, r0.z
add r4.w, r6.x, c7.y
frc r6.z, r6.x
add r6.x, r6, -r6.z
add r0.w, v6.x, v6
add r0.w, r0, c11.y
mul r5.w, r4.z, r0
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c12
add r4.z, r5.w, c7.y
frc r6.y, r5.w
add r5.w, r5, -r6.y
cmp r5.x, r4.w, c11.w, c11.z
cmp_pp r4.w, r4.z, c11.z, c11
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c12.x
mul_pp r5.x, r4.w, r5
cmp r5.y, -r5.z, r5, c8.w
cmp_pp r5.z, -r5.x, r4.w, c8.w
mul_pp r4.w, r4, r5.z
cmp r6.x, r6, c11.w, c11.z
cmp r5.w, r5, c11, c11.z
mul_pp r5.w, r5, r6.x
cmp r6.x, r4.z, r2.w, c8.w
mul_pp r4.z, r4.w, r5.w
cmp r5.w, -r5.x, r6.x, c8
cmp_pp r5.x, -r4.z, r5.z, c8.w
cmp r5.z, -r4, r5.w, c9
mul_pp r4.z, r4.w, r5.x
mul r4.w, v6.z, c12.y
cmp r4.z, -r4, r5, c8.w
rcp r5.w, r4.w
mul r5.z, r0.x, r5.w
mul r5.x, r4.w, c12.z
rcp r6.x, r5.x
mul r0.x, r0, r6
add r4.z, r5.y, r4
mul r5.y, r0.w, r6.x
add r4.w, r5.y, c7.y
frc r6.z, r5.y
add r5.y, r5, -r6.z
add r5.x, r5.z, c7.y
frc r6.w, r5.z
add r5.z, r5, -r6.w
mul r6.w, r0, r5
add r5.w, r0.x, c7.y
frc r7.y, r0.x
mul r5.z, r5, c9.w
mul r5.y, r5, c9.w
frc r5.z, r5
frc r5.y, r5
add r5.z, r5, c12.x
add r5.y, r5, c12.x
cmp_pp r6.y, r4.w, c11.z, c11.w
cmp r5.x, r5, c11.w, c11.z
mul_pp r5.x, r6.y, r5
add r0.w, r6, c7.y
cmp r6.x, r5.w, c11.w, c11.z
cmp_pp r5.w, r0, c11.z, c11
mul_pp r6.x, r5.w, r6
cmp_pp r6.z, -r6.x, r5.w, c8.w
cmp r5.y, r5, c11.w, c11.z
cmp r5.z, r5, c11.w, c11
mul_pp r5.z, r5.y, r5
cmp_pp r5.y, -r5.x, r6, c8.w
mul_pp r6.y, r6, r5
mul_pp r5.z, r6.y, r5
frc r7.x, r6.w
add r7.y, r0.x, -r7
add r0.x, r6.w, -r7
mul r6.w, r7.y, c9
mul r0.x, r0, c9.w
frc r6.w, r6
frc r0.x, r0
add r6.w, r6, c12.x
add r0.x, r0, c12
cmp r0.x, r0, c11.w, c11.z
cmp r6.w, r6, c11, c11.z
mul_pp r6.w, r0.x, r6
mul_pp r0.x, r5.w, r6.z
cmp r5.w, r0, r2, c8
cmp r6.x, -r6, r5.w, c8.w
mul_pp r0.w, r0.x, r6
cmp_pp r5.w, -r0, r6.z, c8
cmp r0.w, -r0, r6.x, c9.z
mul_pp r0.x, r0, r5.w
cmp r0.x, -r0, r0.w, c8.w
cmp_pp r0.w, -r5.z, r5.y, c8
add r0.x, r4.z, r0
cmp r4.z, r4.w, r2.w, c8.w
cmp r4.z, -r5.x, r4, c8.w
mul r4.w, v6.z, c11.y
mul r5.x, r4.w, c7
cmp r5.z, -r5, r4, c9
rcp r4.z, r5.x
mul r6.x, r0.z, r4.z
add r5.x, r6, c7.y
mul_pp r0.w, r6.y, r0
cmp r0.w, -r0, r5.z, c8
rcp r4.w, r4.w
mul r5.w, r4.y, r4
frc r6.z, r6.x
add r6.x, r6, -r6.z
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c12
add r0.z, r5.w, c7.y
cmp r5.y, r5.x, c11.w, c11.z
cmp_pp r5.x, r0.z, c11.z, c11.w
mul_pp r5.y, r5.x, r5
cmp_pp r5.z, -r5.y, r5.x, c8.w
frc r6.y, r5.w
add r5.w, r5, -r6.y
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c12.x
mul_pp r5.x, r5, r5.z
cmp r6.x, r6, c11.w, c11.z
cmp r5.w, r5, c11, c11.z
mul_pp r5.w, r5, r6.x
cmp r6.x, r0.z, r2.w, c8.w
mul_pp r0.z, r5.x, r5.w
cmp r5.w, -r5.y, r6.x, c8
cmp_pp r5.y, -r0.z, r5.z, c8.w
cmp r5.z, -r0, r5.w, c9
mul_pp r0.z, r5.x, r5.y
add r5.y, v6.w, r0
cmp r0.z, -r0, r5, c8.w
add r0.x, r0, r0.w
add r5.x, r0, r0.z
pow r0, r3.w, c12.w
add r0.y, r5, c11
mul r4.w, r4, r0.y
mul r3.w, r4.y, r4.z
add r0.y, r3.w, c7
frc r4.z, r3.w
add r3.w, r3, -r4.z
add r0.z, r4.w, c7.y
mad r3.xyz, r0.x, r3, r4.x
frc r5.y, r4.w
add r4.w, r4, -r5.y
mul r4.z, r4.w, c9.w
mul r3.w, r3, c9
frc r4.z, r4
frc r3.w, r3
add r4.z, r4, c12.x
add r3.w, r3, c12.x
cmp_pp r4.y, r0, c11.z, c11.w
cmp r0.z, r0, c11.w, c11
mul_pp r0.z, r4.y, r0
cmp r2.w, r0.y, r2, c8
cmp_pp r0.w, -r0.z, r4.y, c8
cmp r3.w, r3, c11, c11.z
cmp r4.z, r4, c11.w, c11
mul_pp r4.z, r3.w, r4
mul_pp r3.w, r4.y, r0
mul_pp r0.y, r3.w, r4.z
cmp r2.w, -r0.z, r2, c8
cmp_pp r0.z, -r0.y, r0.w, c8.w
cmp r0.w, -r0.y, r2, c9.z
mul_pp r0.y, r3.w, r0.z
cmp r0.y, -r0, r0.w, c8.w
add r0.x, r5, r0.y
add_pp r2.xyz, r2, r3
add r0.x, r0, c9.y
cmp_pp r1.xyz, -r0.x, r1, r2
endif
else
mov_pp r0, -c7.z
texkill r0.xyzw
endif
endif
mov_pp oC0, r1
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirUpToDown" }
Vector 0 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, 8.00000000, 0.00000000, 0, 0
def c2, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
texld r0, v5, s1
mul_pp r0.xyz, r0.w, r0
texld r1, v5, s2
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c1.x
dp4 r0.w, v6, v6
rsq r0.w, r0.w
rcp r1.w, r0.w
mad_pp r2.xyz, r0, c1.x, -r1
mad_sat r1.w, r1, c0.z, c0
texldp r0, v1, s0
mad_pp r1.xyz, r1.w, r2, r1
add_pp r0.xyz, r0, r1
dp4_pp oC0.w, r0, c2
mov_pp oC0.xyz, c1.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "DirUpToDown" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c0, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c1, -0.40824831, 0.70710677, 0.57735026, 1.00000000
def c2, 0.81649655, 0.00000000, 0.57735026, 0
def c3, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
dp3_pp_sat r2.z, r1, c0
dp3_pp_sat r2.x, r1, c2
dp3_pp_sat r2.y, r1, c1
mul_pp r1.xyz, r0, r2
texld r0, v5, s1
dp3_pp r1.x, r1, c0.w
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, r1.x
mul_pp r1.xyz, r0, c0.w
mov_pp r1.w, c1
texldp r0, v1, s0
add_pp r0, r0, r1
dp4_pp oC0.w, r0, c3
mov_pp oC0.xyz, c2.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirDownToUp" }
Vector 0 [_CenterPosTime]
Vector 1 [_EmissiveHightColor]
Vector 2 [_Color]
Vector 3 [_IllumnColor]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ReflectColor]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RoilingFlameModule] 2D 5
SetTexture 6 [_PyroEnergy] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
def c8, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c9, 5.00000000, 0.10000000, 0.15915491, 0.50000000
def c10, 6.28318501, -3.14159298, 50.00000000, -0.10000000
def c11, 0.20000000, 1.00000000, 0.00000000, -0.01000000
def c12, 0.40000001, 3.00000000, 8.00000000, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
texld r5, v0, s2
texld r3.yw, v0.zwzw, s3
mad_pp r3.xy, r3.wyzw, c7.x, c7.y
mul_pp r2.xy, r3, r3
mov_pp r0.xyz, c5
add_pp r0.xyz, -c2, r0
mad_pp r0.xyz, r5.z, r0, c2
add_pp r1.xyz, -r0, c4
mad_pp r1.xyz, r5.y, r1, r0
texld r0.xyz, v0, s1
mul r1.xyz, r0, r1
add_pp_sat r0.w, r2.x, r2.y
mul r1.w, r5, c6.x
add_pp r0.x, -r0.w, c7.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
texldp r0, v1, s0
dp3_pp r4.x, v2, r3
dp3_pp r4.y, r3, v3
dp3_pp r4.z, r3, v4
mul r2.xyz, r1, r1.w
log_pp r0.w, r0.w
mul r2.xyz, r2, -r0.w
mov r3.x, v2.w
mov r3.z, v4.w
mov r3.y, v3.w
dp3 r3.w, r4, r3
mul r4.xyz, r4, r3.w
mad r4.xyz, -r4, c7.x, r3
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, v5
mad r0.xyz, r1, r3, r2
texld r1.xyz, r4, s4
mul r2.xyz, r1.w, r1
mul r3.w, r5.x, c3
mul r1.xyz, r3.w, c3
mad r1.xyz, r1, c7.w, r2
add r2.xyz, r0, r1
mov r1.w, c0
mad r1.w, r1, c9.z, c9
frc r0.x, r1.w
mad r1.w, r0.x, c10.x, c10.y
mov_pp r3.w, -r0
sincos r0.xy, r1.w
dp4_pp r1.w, r3, c8
mul r4.xy, v0, c9.x
texld r0.z, r4, s5
mul r0.x, r0.z, c9.y
mov r3.xyz, c1
texld r0.z, r4, s6
add r0.x, r0, c0.w
mad r3.w, r0.y, c9, c9
add r0.y, r0.x, c10.w
mov_pp r1.xyz, r2
mul r3.xyz, c10.z, r3
mov r4.x, r0.z
if_gt v6.y, r0.y
if_lt v6.y, r0.x
mul r0.x, v6.z, c7
rcp r4.z, r0.x
add r0.x, v6.y, c11
mul r5.z, r0.x, r4
add r0.z, r5, c7.y
frc r6.x, r5.z
add r5.z, r5, -r6.x
mul r5.z, r5, c9.w
frc r5.z, r5
add r5.z, r5, c11.w
add r4.y, v6.x, c11.x
rcp r4.w, v6.z
mul r5.y, r4, r4.w
add r0.y, r5, c7
frc r5.w, r5.y
add r5.y, r5, -r5.w
mul r5.y, r5, c9.w
frc r5.y, r5
add r5.y, r5, c11.w
cmp_pp r0.w, r0.y, c11.y, c11.z
cmp r0.z, r0, c11, c11.y
mul_pp r5.x, r0.w, r0.z
cmp_pp r0.z, -r5.x, r0.w, c8.w
mul_pp r0.w, r0, r0.z
cmp r5.z, r5, c11, c11.y
cmp r5.y, r5, c11.z, c11
mul_pp r5.y, r5, r5.z
cmp r5.z, r0.y, r2.w, c8.w
mul_pp r5.y, r0.w, r5
cmp_pp r0.y, -r5, r0.z, c8.w
cmp r0.z, -r5.x, r5, c8.w
mul_pp r5.z, r0.w, r0.y
cmp r5.y, -r5, r0.z, c9
add r0.y, v6, v6.w
add r0.z, r0.y, c11.x
mul r6.x, r4.w, r0.z
add r4.w, r6.x, c7.y
frc r6.z, r6.x
add r6.x, r6, -r6.z
add r0.w, v6.x, v6
add r0.w, r0, c11.x
mul r5.w, r4.z, r0
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c11.w
add r4.z, r5.w, c7.y
frc r6.y, r5.w
add r5.w, r5, -r6.y
cmp r5.x, r4.w, c11.z, c11.y
cmp_pp r4.w, r4.z, c11.y, c11.z
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c11
mul_pp r5.x, r4.w, r5
cmp r5.y, -r5.z, r5, c8.w
cmp_pp r5.z, -r5.x, r4.w, c8.w
mul_pp r4.w, r4, r5.z
cmp r6.x, r6, c11.z, c11.y
cmp r5.w, r5, c11.z, c11.y
mul_pp r5.w, r5, r6.x
cmp r6.x, r4.z, r2.w, c8.w
mul_pp r4.z, r4.w, r5.w
cmp r5.w, -r5.x, r6.x, c8
cmp_pp r5.x, -r4.z, r5.z, c8.w
cmp r5.z, -r4, r5.w, c9.y
mul_pp r4.z, r4.w, r5.x
mul r4.w, v6.z, c12.x
cmp r4.z, -r4, r5, c8.w
rcp r5.w, r4.w
mul r5.z, r0.x, r5.w
mul r5.x, r4.w, c12.y
rcp r6.x, r5.x
mul r0.x, r0, r6
add r4.z, r5.y, r4
mul r5.y, r0.w, r6.x
add r4.w, r5.y, c7.y
frc r6.z, r5.y
add r5.y, r5, -r6.z
add r5.x, r5.z, c7.y
frc r6.w, r5.z
add r5.z, r5, -r6.w
mul r6.w, r0, r5
add r5.w, r0.x, c7.y
frc r7.y, r0.x
mul r5.z, r5, c9.w
mul r5.y, r5, c9.w
frc r5.z, r5
frc r5.y, r5
add r5.z, r5, c11.w
add r5.y, r5, c11.w
cmp_pp r6.y, r4.w, c11, c11.z
cmp r5.x, r5, c11.z, c11.y
mul_pp r5.x, r6.y, r5
add r0.w, r6, c7.y
cmp r6.x, r5.w, c11.z, c11.y
cmp_pp r5.w, r0, c11.y, c11.z
mul_pp r6.x, r5.w, r6
cmp_pp r6.z, -r6.x, r5.w, c8.w
cmp r5.y, r5, c11.z, c11
cmp r5.z, r5, c11, c11.y
mul_pp r5.z, r5.y, r5
cmp_pp r5.y, -r5.x, r6, c8.w
mul_pp r6.y, r6, r5
mul_pp r5.z, r6.y, r5
frc r7.x, r6.w
add r7.y, r0.x, -r7
add r0.x, r6.w, -r7
mul r6.w, r7.y, c9
mul r0.x, r0, c9.w
frc r6.w, r6
frc r0.x, r0
add r6.w, r6, c11
add r0.x, r0, c11.w
cmp r0.x, r0, c11.z, c11.y
cmp r6.w, r6, c11.z, c11.y
mul_pp r6.w, r0.x, r6
mul_pp r0.x, r5.w, r6.z
cmp r5.w, r0, r2, c8
cmp r6.x, -r6, r5.w, c8.w
mul_pp r0.w, r0.x, r6
cmp_pp r5.w, -r0, r6.z, c8
cmp r0.w, -r0, r6.x, c9.y
mul_pp r0.x, r0, r5.w
cmp r0.x, -r0, r0.w, c8.w
cmp_pp r0.w, -r5.z, r5.y, c8
add r0.x, r4.z, r0
cmp r4.z, r4.w, r2.w, c8.w
cmp r4.z, -r5.x, r4, c8.w
mul r4.w, v6.z, c11.x
mul r5.x, r4.w, c7
cmp r5.z, -r5, r4, c9.y
rcp r4.z, r5.x
mul r6.x, r0.z, r4.z
add r5.x, r6, c7.y
mul_pp r0.w, r6.y, r0
cmp r0.w, -r0, r5.z, c8
rcp r4.w, r4.w
mul r5.w, r4.y, r4
frc r6.z, r6.x
add r6.x, r6, -r6.z
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c11.w
add r0.z, r5.w, c7.y
cmp r5.y, r5.x, c11.z, c11
cmp_pp r5.x, r0.z, c11.y, c11.z
mul_pp r5.y, r5.x, r5
cmp_pp r5.z, -r5.y, r5.x, c8.w
frc r6.y, r5.w
add r5.w, r5, -r6.y
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c11
mul_pp r5.x, r5, r5.z
cmp r6.x, r6, c11.z, c11.y
cmp r5.w, r5, c11.z, c11.y
mul_pp r5.w, r5, r6.x
cmp r6.x, r0.z, r2.w, c8.w
mul_pp r0.z, r5.x, r5.w
cmp r5.w, -r5.y, r6.x, c8
cmp_pp r5.y, -r0.z, r5.z, c8.w
cmp r5.z, -r0, r5.w, c9.y
mul_pp r0.z, r5.x, r5.y
add r5.y, v6.w, r0
cmp r0.z, -r0, r5, c8.w
add r0.x, r0, r0.w
add r5.x, r0, r0.z
pow r0, r3.w, c12.z
add r0.y, r5, c11.x
mul r4.w, r4, r0.y
mul r3.w, r4.y, r4.z
add r0.y, r3.w, c7
frc r4.z, r3.w
add r3.w, r3, -r4.z
add r0.z, r4.w, c7.y
mad r3.xyz, r0.x, r3, r4.x
frc r5.y, r4.w
add r4.w, r4, -r5.y
mul r4.z, r4.w, c9.w
mul r3.w, r3, c9
frc r4.z, r4
frc r3.w, r3
add r4.z, r4, c11.w
add r3.w, r3, c11
cmp_pp r4.y, r0, c11, c11.z
cmp r0.z, r0, c11, c11.y
mul_pp r0.z, r4.y, r0
cmp r2.w, r0.y, r2, c8
cmp_pp r0.w, -r0.z, r4.y, c8
cmp r3.w, r3, c11.z, c11.y
cmp r4.z, r4, c11, c11.y
mul_pp r4.z, r3.w, r4
mul_pp r3.w, r4.y, r0
mul_pp r0.y, r3.w, r4.z
cmp r2.w, -r0.z, r2, c8
cmp_pp r0.z, -r0.y, r0.w, c8.w
cmp r0.w, -r0.y, r2, c9.y
mul_pp r0.y, r3.w, r0.z
cmp r0.y, -r0, r0.w, c8.w
add r0.x, r5, r0.y
add_pp r2.xyz, r2, r3
add r0.x, r0, c10.w
cmp_pp r1.xyz, -r0.x, r1, r2
else
mov_pp r0, -c7.z
texkill r0.xyzw
endif
endif
mov_pp oC0, r1
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" "DirDownToUp" }
Vector 0 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, 8.00000000, 0.00000000, 0, 0
def c2, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
texld r1, v5, s1
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
mul_pp r2.xyz, r1.w, r1
mul_pp r1.xyz, r0, c1.x
dp4 r0.x, v6, v6
rsq r1.w, r0.x
texldp r0, v1, s0
rcp r1.w, r1.w
log_pp r0.w, r0.w
mad_pp r2.xyz, r2, c1.x, -r1
mad_sat r1.w, r1, c0.z, c0
mad_pp r1.xyz, r1.w, r2, r1
mov_pp r0.w, -r0
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, r1
dp4_pp oC0.w, r0, c2
mov_pp oC0.xyz, c1.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" "DirDownToUp" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c0, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c1, -0.40824831, 0.70710677, 0.57735026, 1.00000000
def c2, 0.81649655, 0.00000000, 0.57735026, 0
def c3, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
dp3_pp_sat r2.z, r1, c0
dp3_pp_sat r2.x, r1, c2
dp3_pp_sat r2.y, r1, c1
mul_pp r1.xyz, r0, r2
texld r0, v5, s1
mul_pp r0.xyz, r0.w, r0
dp3_pp r1.x, r1, c0.w
mul_pp r1.xyz, r0, r1.x
texldp r0, v1, s0
mul_pp r1.xyz, r1, c0.w
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
mov_pp r1.w, c1
log_pp r0.w, r0.w
add_pp r0, -r0, r1
dp4_pp oC0.w, r0, c3
mov_pp oC0.xyz, c2.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirDownToUp" }
Vector 0 [_CenterPosTime]
Vector 1 [_EmissiveHightColor]
Vector 2 [_Color]
Vector 3 [_IllumnColor]
Vector 4 [_MetalColor]
Vector 5 [_SkinColor]
Vector 6 [_ReflectColor]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
SetTexture 5 [_RoilingFlameModule] 2D 5
SetTexture 6 [_PyroEnergy] 2D 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
dcl_2d s5
dcl_2d s6
def c7, 2.00000000, -1.00000000, 1.00000000, 16.00000000
def c8, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c9, 5.00000000, 0.10000000, 0.15915491, 0.50000000
def c10, 6.28318501, -3.14159298, 50.00000000, -0.10000000
def c11, 0.20000000, 1.00000000, 0.00000000, -0.01000000
def c12, 0.40000001, 3.00000000, 8.00000000, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
dcl_texcoord7 v6
texld r5, v0, s2
texld r1.yw, v0.zwzw, s3
mad_pp r1.xy, r1.wyzw, c7.x, c7.y
mul_pp r1.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.w, r1.z, r1
mov_pp r0.xyz, c5
add_pp r0.xyz, -c2, r0
mad_pp r0.xyz, r5.z, r0, c2
add_pp r2.xyz, -r0, c4
mad_pp r2.xyz, r5.y, r2, r0
texld r0.xyz, v0, s1
add_pp r0.w, -r0, c7.z
rsq_pp r0.w, r0.w
mul r2.xyz, r0, r2
rcp_pp r1.z, r0.w
mul r1.w, r5, c6.x
dp3_pp r0.x, v2, r1
dp3_pp r0.y, r1, v3
dp3_pp r0.z, r1, v4
mul r4.xyz, r2, r1.w
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r0.w, r0, r1
mul r3.xyz, r0, r0.w
texldp r0, v1, s0
mad r1.xyz, -r3, c7.x, r1
add_pp r3.xyz, r0, v5
mul r4.xyz, r0.w, r4
mad r0.xyz, r2, r3, r4
texld r1.xyz, r1, s4
mul r2.xyz, r1.w, r1
mul r3.w, r5.x, c3
mul r1.xyz, r3.w, c3
mad r1.xyz, r1, c7.w, r2
add r2.xyz, r0, r1
mov r1.w, c0
mad r1.w, r1, c9.z, c9
frc r0.x, r1.w
mad r1.w, r0.x, c10.x, c10.y
mov_pp r3.w, r0
sincos r0.xy, r1.w
dp4_pp r1.w, r3, c8
mul r4.xy, v0, c9.x
texld r0.z, r4, s5
mul r0.x, r0.z, c9.y
mov r3.xyz, c1
texld r0.z, r4, s6
add r0.x, r0, c0.w
mad r3.w, r0.y, c9, c9
add r0.y, r0.x, c10.w
mov_pp r1.xyz, r2
mul r3.xyz, c10.z, r3
mov r4.x, r0.z
if_gt v6.y, r0.y
if_lt v6.y, r0.x
mul r0.x, v6.z, c7
rcp r4.z, r0.x
add r0.x, v6.y, c11
mul r5.z, r0.x, r4
add r0.z, r5, c7.y
frc r6.x, r5.z
add r5.z, r5, -r6.x
mul r5.z, r5, c9.w
frc r5.z, r5
add r5.z, r5, c11.w
add r4.y, v6.x, c11.x
rcp r4.w, v6.z
mul r5.y, r4, r4.w
add r0.y, r5, c7
frc r5.w, r5.y
add r5.y, r5, -r5.w
mul r5.y, r5, c9.w
frc r5.y, r5
add r5.y, r5, c11.w
cmp_pp r0.w, r0.y, c11.y, c11.z
cmp r0.z, r0, c11, c11.y
mul_pp r5.x, r0.w, r0.z
cmp_pp r0.z, -r5.x, r0.w, c8.w
mul_pp r0.w, r0, r0.z
cmp r5.z, r5, c11, c11.y
cmp r5.y, r5, c11.z, c11
mul_pp r5.y, r5, r5.z
cmp r5.z, r0.y, r2.w, c8.w
mul_pp r5.y, r0.w, r5
cmp_pp r0.y, -r5, r0.z, c8.w
cmp r0.z, -r5.x, r5, c8.w
mul_pp r5.z, r0.w, r0.y
cmp r5.y, -r5, r0.z, c9
add r0.y, v6, v6.w
add r0.z, r0.y, c11.x
mul r6.x, r4.w, r0.z
add r4.w, r6.x, c7.y
frc r6.z, r6.x
add r6.x, r6, -r6.z
add r0.w, v6.x, v6
add r0.w, r0, c11.x
mul r5.w, r4.z, r0
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c11.w
add r4.z, r5.w, c7.y
frc r6.y, r5.w
add r5.w, r5, -r6.y
cmp r5.x, r4.w, c11.z, c11.y
cmp_pp r4.w, r4.z, c11.y, c11.z
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c11
mul_pp r5.x, r4.w, r5
cmp r5.y, -r5.z, r5, c8.w
cmp_pp r5.z, -r5.x, r4.w, c8.w
mul_pp r4.w, r4, r5.z
cmp r6.x, r6, c11.z, c11.y
cmp r5.w, r5, c11.z, c11.y
mul_pp r5.w, r5, r6.x
cmp r6.x, r4.z, r2.w, c8.w
mul_pp r4.z, r4.w, r5.w
cmp r5.w, -r5.x, r6.x, c8
cmp_pp r5.x, -r4.z, r5.z, c8.w
cmp r5.z, -r4, r5.w, c9.y
mul_pp r4.z, r4.w, r5.x
mul r4.w, v6.z, c12.x
cmp r4.z, -r4, r5, c8.w
rcp r5.w, r4.w
mul r5.z, r0.x, r5.w
mul r5.x, r4.w, c12.y
rcp r6.x, r5.x
mul r0.x, r0, r6
add r4.z, r5.y, r4
mul r5.y, r0.w, r6.x
add r4.w, r5.y, c7.y
frc r6.z, r5.y
add r5.y, r5, -r6.z
add r5.x, r5.z, c7.y
frc r6.w, r5.z
add r5.z, r5, -r6.w
mul r6.w, r0, r5
add r5.w, r0.x, c7.y
frc r7.y, r0.x
mul r5.z, r5, c9.w
mul r5.y, r5, c9.w
frc r5.z, r5
frc r5.y, r5
add r5.z, r5, c11.w
add r5.y, r5, c11.w
cmp_pp r6.y, r4.w, c11, c11.z
cmp r5.x, r5, c11.z, c11.y
mul_pp r5.x, r6.y, r5
add r0.w, r6, c7.y
cmp r6.x, r5.w, c11.z, c11.y
cmp_pp r5.w, r0, c11.y, c11.z
mul_pp r6.x, r5.w, r6
cmp_pp r6.z, -r6.x, r5.w, c8.w
cmp r5.y, r5, c11.z, c11
cmp r5.z, r5, c11, c11.y
mul_pp r5.z, r5.y, r5
cmp_pp r5.y, -r5.x, r6, c8.w
mul_pp r6.y, r6, r5
mul_pp r5.z, r6.y, r5
frc r7.x, r6.w
add r7.y, r0.x, -r7
add r0.x, r6.w, -r7
mul r6.w, r7.y, c9
mul r0.x, r0, c9.w
frc r6.w, r6
frc r0.x, r0
add r6.w, r6, c11
add r0.x, r0, c11.w
cmp r0.x, r0, c11.z, c11.y
cmp r6.w, r6, c11.z, c11.y
mul_pp r6.w, r0.x, r6
mul_pp r0.x, r5.w, r6.z
cmp r5.w, r0, r2, c8
cmp r6.x, -r6, r5.w, c8.w
mul_pp r0.w, r0.x, r6
cmp_pp r5.w, -r0, r6.z, c8
cmp r0.w, -r0, r6.x, c9.y
mul_pp r0.x, r0, r5.w
cmp r0.x, -r0, r0.w, c8.w
cmp_pp r0.w, -r5.z, r5.y, c8
add r0.x, r4.z, r0
cmp r4.z, r4.w, r2.w, c8.w
cmp r4.z, -r5.x, r4, c8.w
mul r4.w, v6.z, c11.x
mul r5.x, r4.w, c7
cmp r5.z, -r5, r4, c9.y
rcp r4.z, r5.x
mul r6.x, r0.z, r4.z
add r5.x, r6, c7.y
mul_pp r0.w, r6.y, r0
cmp r0.w, -r0, r5.z, c8
rcp r4.w, r4.w
mul r5.w, r4.y, r4
frc r6.z, r6.x
add r6.x, r6, -r6.z
mul r6.x, r6, c9.w
frc r6.x, r6
add r6.x, r6, c11.w
add r0.z, r5.w, c7.y
cmp r5.y, r5.x, c11.z, c11
cmp_pp r5.x, r0.z, c11.y, c11.z
mul_pp r5.y, r5.x, r5
cmp_pp r5.z, -r5.y, r5.x, c8.w
frc r6.y, r5.w
add r5.w, r5, -r6.y
mul r5.w, r5, c9
frc r5.w, r5
add r5.w, r5, c11
mul_pp r5.x, r5, r5.z
cmp r6.x, r6, c11.z, c11.y
cmp r5.w, r5, c11.z, c11.y
mul_pp r5.w, r5, r6.x
cmp r6.x, r0.z, r2.w, c8.w
mul_pp r0.z, r5.x, r5.w
cmp r5.w, -r5.y, r6.x, c8
cmp_pp r5.y, -r0.z, r5.z, c8.w
cmp r5.z, -r0, r5.w, c9.y
mul_pp r0.z, r5.x, r5.y
add r5.y, v6.w, r0
cmp r0.z, -r0, r5, c8.w
add r0.x, r0, r0.w
add r5.x, r0, r0.z
pow r0, r3.w, c12.z
add r0.y, r5, c11.x
mul r4.w, r4, r0.y
mul r3.w, r4.y, r4.z
add r0.y, r3.w, c7
frc r4.z, r3.w
add r3.w, r3, -r4.z
add r0.z, r4.w, c7.y
mad r3.xyz, r0.x, r3, r4.x
frc r5.y, r4.w
add r4.w, r4, -r5.y
mul r4.z, r4.w, c9.w
mul r3.w, r3, c9
frc r4.z, r4
frc r3.w, r3
add r4.z, r4, c11.w
add r3.w, r3, c11
cmp_pp r4.y, r0, c11, c11.z
cmp r0.z, r0, c11, c11.y
mul_pp r0.z, r4.y, r0
cmp r2.w, r0.y, r2, c8
cmp_pp r0.w, -r0.z, r4.y, c8
cmp r3.w, r3, c11.z, c11.y
cmp r4.z, r4, c11, c11.y
mul_pp r4.z, r3.w, r4
mul_pp r3.w, r4.y, r0
mul_pp r0.y, r3.w, r4.z
cmp r2.w, -r0.z, r2, c8
cmp_pp r0.z, -r0.y, r0.w, c8.w
cmp r0.w, -r0.y, r2, c9.y
mul_pp r0.y, r3.w, r0.z
cmp r0.y, -r0, r0.w, c8.w
add r0.x, r5, r0.y
add_pp r2.xyz, r2, r3
add r0.x, r0, c10.w
cmp_pp r1.xyz, -r0.x, r1, r2
else
mov_pp r0, -c7.z
texkill r0.xyzw
endif
endif
mov_pp oC0, r1
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" "DirDownToUp" }
Vector 0 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, 8.00000000, 0.00000000, 0, 0
def c2, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
texld r0, v5, s1
mul_pp r0.xyz, r0.w, r0
texld r1, v5, s2
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c1.x
dp4 r0.w, v6, v6
rsq r0.w, r0.w
rcp r1.w, r0.w
mad_pp r2.xyz, r0, c1.x, -r1
mad_sat r1.w, r1, c0.z, c0
texldp r0, v1, s0
mad_pp r1.xyz, r1.w, r2, r1
add_pp r0.xyz, r0, r1
dp4_pp oC0.w, r0, c2
mov_pp oC0.xyz, c1.y
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" "DirDownToUp" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c0, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c1, -0.40824831, 0.70710677, 0.57735026, 1.00000000
def c2, 0.81649655, 0.00000000, 0.57735026, 0
def c3, 0.30004883, 0.60009766, 0.09997559, 0.00000000
dcl_texcoord1 v1
dcl_texcoord5 v5.xy
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
dp3_pp_sat r2.z, r1, c0
dp3_pp_sat r2.x, r1, c2
dp3_pp_sat r2.y, r1, c1
mul_pp r1.xyz, r0, r2
texld r0, v5, s1
dp3_pp r1.x, r1, c0.w
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, r1.x
mul_pp r1.xyz, r0, c0.w
mov_pp r1.w, c1
texldp r0, v1, s0
add_pp r0, r0, r1
dp4_pp oC0.w, r0, c3
mov_pp oC0.xyz, c2.y
"
}
}
 }
}
Fallback "Diffuse"
}