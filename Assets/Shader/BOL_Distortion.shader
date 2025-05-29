ÌShader "BOL/FX/Distortion" {
Properties {
 _NoiseTex ("Normal Texture (RGB)", 2D) = "white" {}
 strength ("Strength", Range(0.1,1)) = 0.2
}
SubShader { 
 Tags { "QUEUE"="Transparent+10" }
 GrabPass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" }
 }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" "QUEUE"="Transparent+10" }
  Cull Off
  Blend SrcAlpha OneMinusSrcAlpha
  AlphaTest Greater 0
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_Scale]
Vector 15 [_NoiseTex_ST]
Float 16 [strength]
"!!ARBvp1.0
PARAM c[17] = { { 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..16] };
TEMP R0;
TEMP R1;
MOV R1.xyz, c[13];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MAD R0.xyz, R0, c[14].w, -vertex.position;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.x, R0, vertex.normal;
DP4 R1.x, vertex.position, c[3];
ADD R0.w, -R1.x, c[0].x;
RCP R0.y, R0.w;
MUL R0.x, R0, R0;
MUL R0.x, R0, R0.y;
MUL result.texcoord[1].x, R0, c[16];
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.position, R0;
MOV result.texcoord[0], R0;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[15], c[15].zwzw;
END
# 23 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_Scale]
Vector 14 [_NoiseTex_ST]
Float 15 [strength]
"vs_2_0
def c16, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, c12
mov r1.w, c16.x
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mad r0.xyz, r0, c13.w, -v0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.x, r0, v1
dp4 r1.x, v0, c2
add r0.w, -r1.x, c16.x
rcp r0.y, r0.w
mul r0.x, r0, r0
mul r0.x, r0, r0.y
mul oT1.x, r0, c15
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r0
mov oT0, r0
mad oT2.xy, v2, c14, c14.zwzw
"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_Time]
Vector 1 [_ProjectionParams]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_NoiseTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fog_exp2;
PARAM c[3] = { program.local[0..1],
		{ 1, 0.5 } };
TEMP R0;
TEMP R1;
ADD R0.zw, fragment.texcoord[2].xyxy, -c[0].xyyx;
ADD R0.xy, fragment.texcoord[2], c[0].xzzw;
TEX R1.xy, R0.zwzw, texture[1], 2D;
TEX R0.xy, R0, texture[1], 2D;
ADD R0.x, R0, R1;
RCP R0.z, fragment.texcoord[0].w;
MAD R0.w, fragment.texcoord[0].y, R0.z, c[2].x;
MUL R0.w, R0, c[2].y;
ADD R0.x, R0, -c[2];
ADD R1.x, -R0.w, c[2];
ADD R1.y, R0, R1;
CMP R0.y, c[1].x, R1.x, R0.w;
ADD R0.w, R1.y, -c[2].x;
MAD R0.z, fragment.texcoord[0].x, R0, c[2].x;
MUL R0.x, fragment.texcoord[1], R0;
MAD R0.x, R0.z, c[2].y, R0;
MAD R0.y, R0.w, fragment.texcoord[1].x, R0;
TEX R0.z, fragment.texcoord[2], texture[1], 2D;
TEX result.color.xyz, R0, texture[0], 2D;
MOV result.color.w, R0.z;
END
# 20 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Time]
Vector 1 [_ProjectionParams]
SetTexture 0 [_GrabTexture] 2D 0
SetTexture 1 [_NoiseTex] 2D 1
"ps_2_0
dcl_2d s1
dcl_2d s0
def c2, 1.00000000, 0.50000000, -1.00000000, 0
dcl t0.xyzw
dcl t2.xy
dcl t1.x
mov r0.y, c0.z
mov r0.x, c0
add r1.xy, t2, r0
mov r0.y, -c0.x
mov r0.x, -c0.y
add r0.xy, t2, r0
texld r2, r0, s1
texld r3, r1, s1
rcp r0.x, t0.w
mad r1.x, t0.y, r0, c2
add_pp r3.x, r3, r2
mul r2.x, r1, c2.y
add_pp r1.x, r3, c2.z
add r3.x, -r2, c2
cmp r2.x, c1, r2, r3
add_pp r4.x, r3.y, r2.y
add_pp r3.x, r4, c2.z
mul r1.x, t1, r1
mad r0.x, t0, r0, c2
mad r0.x, r0, c2.y, r1
mad r0.y, r3.x, t1.x, r2.x
texld r0, r0, s0
texld r1, t2, s1
mov_pp r0.w, r1.z
mov_pp oC0, r0
"
}
}
 }
}
}