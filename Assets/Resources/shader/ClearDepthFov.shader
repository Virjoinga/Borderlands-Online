žkShader "Custom/ClearDepthFov" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Geometry+1" "RenderType"="Opaque" }
 Pass {
  Name "CLEARPASS"
  Tags { "LIGHTMODE"="PrePassBase" "QUEUE"="Geometry+1" "RenderType"="Opaque" }
  ZTest Always
  ColorMask 0
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 5 [_ProjMat]
"!!ARBvp1.0
PARAM c[9] = { { 0.0099999998 },
		state.matrix.modelview[0],
		program.local[5..8] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R3, R0, c[8].y;
MUL R2, R0, c[7].y;
MAD R4, R1, c[8].x, R3;
MAD R3, R1, c[7].x, R2;
MOV R2, c[3];
MAD R5, R2, c[7].z, R3;
MOV R3, c[4];
MAD R5, R3, c[7].w, R5;
MAD R4, R2, c[8].z, R4;
MAD R4, R3, c[8].w, R4;
DP4 R5.x, R5, vertex.position;
DP4 result.position.w, vertex.position, R4;
MUL R4, R0, c[6].y;
MUL R0, R0, c[5].y;
MAD R0, R1, c[5].x, R0;
MAD R4, R1, c[6].x, R4;
MAD R1, R2, c[6].z, R4;
MAD R0, R2, c[5].z, R0;
MAD R1, R3, c[6].w, R1;
MAD R0, R3, c[5].w, R0;
ADD result.position.z, R5.x, c[0].x;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
END
# 25 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
"vs_2_0
def c8, 0.01000000, 0, 0, 0
dcl_position0 v0
mov r0.x, c6.y
mul r1, c1, r0.x
mov r0.x, c6
mad r1, c0, r0.x, r1
mov r0.x, c6.z
mad r1, c2, r0.x, r1
mov r0.x, c6.w
mad r0, c3, r0.x, r1
dp4 r0.y, r0, v0
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
add oPos.z, r0.y, c8.x
mov r0.x, c5.y
dp4 oPos.w, v0, r1
mul r1, c1, r0.x
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.y, c5.w
mad r1, c3, r0.y, r1
mov r0.x, c4.y
mov r2.x, c4
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c4.z
mad r0, c2, r2.x, r0
mov r2.x, c4.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 5 [_ProjMat]
"!!ARBvp1.0
PARAM c[9] = { { 0.0099999998 },
		state.matrix.modelview[0],
		program.local[5..8] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R3, R0, c[8].y;
MUL R2, R0, c[7].y;
MAD R4, R1, c[8].x, R3;
MAD R3, R1, c[7].x, R2;
MOV R2, c[3];
MAD R5, R2, c[7].z, R3;
MOV R3, c[4];
MAD R5, R3, c[7].w, R5;
MAD R4, R2, c[8].z, R4;
MAD R4, R3, c[8].w, R4;
DP4 R5.x, R5, vertex.position;
DP4 result.position.w, vertex.position, R4;
MUL R4, R0, c[6].y;
MUL R0, R0, c[5].y;
MAD R0, R1, c[5].x, R0;
MAD R4, R1, c[6].x, R4;
MAD R1, R2, c[6].z, R4;
MAD R0, R2, c[5].z, R0;
MAD R1, R3, c[6].w, R1;
MAD R0, R3, c[5].w, R0;
ADD result.position.z, R5.x, c[0].x;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
END
# 25 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
"vs_2_0
def c8, 0.01000000, 0, 0, 0
dcl_position0 v0
mov r0.x, c6.y
mul r1, c1, r0.x
mov r0.x, c6
mad r1, c0, r0.x, r1
mov r0.x, c6.z
mad r1, c2, r0.x, r1
mov r0.x, c6.w
mad r0, c3, r0.x, r1
dp4 r0.y, r0, v0
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
add oPos.z, r0.y, c8.x
mov r0.x, c5.y
dp4 oPos.w, v0, r1
mul r1, c1, r0.x
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.y, c5.w
mad r1, c3, r0.y, r1
mov r0.x, c4.y
mov r2.x, c4
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c4.z
mad r0, c2, r2.x, r0
mov r2.x, c4.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 5 [_ProjMat]
"!!ARBvp1.0
PARAM c[9] = { { 0.0099999998 },
		state.matrix.modelview[0],
		program.local[5..8] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R3, R0, c[8].y;
MUL R2, R0, c[7].y;
MAD R4, R1, c[8].x, R3;
MAD R3, R1, c[7].x, R2;
MOV R2, c[3];
MAD R5, R2, c[7].z, R3;
MOV R3, c[4];
MAD R5, R3, c[7].w, R5;
MAD R4, R2, c[8].z, R4;
MAD R4, R3, c[8].w, R4;
DP4 R5.x, R5, vertex.position;
DP4 result.position.w, vertex.position, R4;
MUL R4, R0, c[6].y;
MUL R0, R0, c[5].y;
MAD R0, R1, c[5].x, R0;
MAD R4, R1, c[6].x, R4;
MAD R1, R2, c[6].z, R4;
MAD R0, R2, c[5].z, R0;
MAD R1, R3, c[6].w, R1;
MAD R0, R3, c[5].w, R0;
ADD result.position.z, R5.x, c[0].x;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
END
# 25 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
"vs_2_0
def c8, 0.01000000, 0, 0, 0
dcl_position0 v0
mov r0.x, c6.y
mul r1, c1, r0.x
mov r0.x, c6
mad r1, c0, r0.x, r1
mov r0.x, c6.z
mad r1, c2, r0.x, r1
mov r0.x, c6.w
mad r0, c3, r0.x, r1
dp4 r0.y, r0, v0
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
add oPos.z, r0.y, c8.x
mov r0.x, c5.y
dp4 oPos.w, v0, r1
mul r1, c1, r0.x
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.y, c5.w
mad r1, c3, r0.y, r1
mov r0.x, c4.y
mov r2.x, c4
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c4.z
mad r0, c2, r2.x, r0
mov r2.x, c4.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 5 [_ProjMat]
"!!ARBvp1.0
PARAM c[9] = { { 0.0099999998 },
		state.matrix.modelview[0],
		program.local[5..8] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R3, R0, c[8].y;
MUL R2, R0, c[7].y;
MAD R4, R1, c[8].x, R3;
MAD R3, R1, c[7].x, R2;
MOV R2, c[3];
MAD R5, R2, c[7].z, R3;
MOV R3, c[4];
MAD R5, R3, c[7].w, R5;
MAD R4, R2, c[8].z, R4;
MAD R4, R3, c[8].w, R4;
DP4 R5.x, R5, vertex.position;
DP4 result.position.w, vertex.position, R4;
MUL R4, R0, c[6].y;
MUL R0, R0, c[5].y;
MAD R0, R1, c[5].x, R0;
MAD R4, R1, c[6].x, R4;
MAD R1, R2, c[6].z, R4;
MAD R0, R2, c[5].z, R0;
MAD R1, R3, c[6].w, R1;
MAD R0, R3, c[5].w, R0;
ADD result.position.z, R5.x, c[0].x;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
END
# 25 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
"vs_2_0
def c8, 0.01000000, 0, 0, 0
dcl_position0 v0
mov r0.x, c6.y
mul r1, c1, r0.x
mov r0.x, c6
mad r1, c0, r0.x, r1
mov r0.x, c6.z
mad r1, c2, r0.x, r1
mov r0.x, c6.w
mad r0, c3, r0.x, r1
dp4 r0.y, r0, v0
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
add oPos.z, r0.y, c8.x
mov r0.x, c5.y
dp4 oPos.w, v0, r1
mul r1, c1, r0.x
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.y, c5.w
mad r1, c3, r0.y, r1
mov r0.x, c4.y
mov r2.x, c4
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c4.z
mad r0, c2, r2.x, r0
mov r2.x, c4.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 5 [_ProjMat]
"!!ARBvp1.0
PARAM c[9] = { { 0.0099999998 },
		state.matrix.modelview[0],
		program.local[5..8] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R3, R0, c[8].y;
MUL R2, R0, c[7].y;
MAD R4, R1, c[8].x, R3;
MAD R3, R1, c[7].x, R2;
MOV R2, c[3];
MAD R5, R2, c[7].z, R3;
MOV R3, c[4];
MAD R5, R3, c[7].w, R5;
MAD R4, R2, c[8].z, R4;
MAD R4, R3, c[8].w, R4;
DP4 R5.x, R5, vertex.position;
DP4 result.position.w, vertex.position, R4;
MUL R4, R0, c[6].y;
MUL R0, R0, c[5].y;
MAD R0, R1, c[5].x, R0;
MAD R4, R1, c[6].x, R4;
MAD R1, R2, c[6].z, R4;
MAD R0, R2, c[5].z, R0;
MAD R1, R3, c[6].w, R1;
MAD R0, R3, c[5].w, R0;
ADD result.position.z, R5.x, c[0].x;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
END
# 25 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
"vs_2_0
def c8, 0.01000000, 0, 0, 0
dcl_position0 v0
mov r0.x, c6.y
mul r1, c1, r0.x
mov r0.x, c6
mad r1, c0, r0.x, r1
mov r0.x, c6.z
mad r1, c2, r0.x, r1
mov r0.x, c6.w
mad r0, c3, r0.x, r1
dp4 r0.y, r0, v0
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
add oPos.z, r0.y, c8.x
mov r0.x, c5.y
dp4 oPos.w, v0, r1
mul r1, c1, r0.x
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.y, c5.w
mad r1, c3, r0.y, r1
mov r0.x, c4.y
mov r2.x, c4
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c4.z
mad r0, c2, r2.x, r0
mov r2.x, c4.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 5 [_ProjMat]
"!!ARBvp1.0
PARAM c[9] = { { 0.0099999998 },
		state.matrix.modelview[0],
		program.local[5..8] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R3, R0, c[8].y;
MUL R2, R0, c[7].y;
MAD R4, R1, c[8].x, R3;
MAD R3, R1, c[7].x, R2;
MOV R2, c[3];
MAD R5, R2, c[7].z, R3;
MOV R3, c[4];
MAD R5, R3, c[7].w, R5;
MAD R4, R2, c[8].z, R4;
MAD R4, R3, c[8].w, R4;
DP4 R5.x, R5, vertex.position;
DP4 result.position.w, vertex.position, R4;
MUL R4, R0, c[6].y;
MUL R0, R0, c[5].y;
MAD R0, R1, c[5].x, R0;
MAD R4, R1, c[6].x, R4;
MAD R1, R2, c[6].z, R4;
MAD R0, R2, c[5].z, R0;
MAD R1, R3, c[6].w, R1;
MAD R0, R3, c[5].w, R0;
ADD result.position.z, R5.x, c[0].x;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
END
# 25 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
"vs_2_0
def c8, 0.01000000, 0, 0, 0
dcl_position0 v0
mov r0.x, c6.y
mul r1, c1, r0.x
mov r0.x, c6
mad r1, c0, r0.x, r1
mov r0.x, c6.z
mad r1, c2, r0.x, r1
mov r0.x, c6.w
mad r0, c3, r0.x, r1
dp4 r0.y, r0, v0
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
add oPos.z, r0.y, c8.x
mov r0.x, c5.y
dp4 oPos.w, v0, r1
mul r1, c1, r0.x
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.y, c5.w
mad r1, c3, r0.y, r1
mov r0.x, c4.y
mov r2.x, c4
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c4.z
mad r0, c2, r2.x, r0
mov r2.x, c4.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 1, 0 } };
MOV result.color, c[0].xyyx;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"ps_2_0
def c0, 1.00000000, 0.00000000, 0, 0
mov r0.yz, c0.y
mov r0.xw, c0.x
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 1, 0 } };
MOV result.color, c[0].xyyx;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
"ps_2_0
def c0, 1.00000000, 0.00000000, 0, 0
mov r0.yz, c0.y
mov r0.xw, c0.x
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 1, 0 } };
MOV result.color, c[0].xyyx;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
"ps_2_0
def c0, 1.00000000, 0.00000000, 0, 0
mov r0.yz, c0.y
mov r0.xw, c0.x
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 1, 0 } };
MOV result.color, c[0].xyyx;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"ps_2_0
def c0, 1.00000000, 0.00000000, 0, 0
mov r0.yz, c0.y
mov r0.xw, c0.x
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 1, 0 } };
MOV result.color, c[0].xyyx;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
"ps_2_0
def c0, 1.00000000, 0.00000000, 0, 0
mov r0.yz, c0.y
mov r0.xw, c0.x
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 1, 0 } };
MOV result.color, c[0].xyyx;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
"ps_2_0
def c0, 1.00000000, 0.00000000, 0, 0
mov r0.yz, c0.y
mov r0.xw, c0.x
mov oC0, r0
"
}
}
 }
}
}