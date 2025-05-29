®$Shader "Custom/ClearDepth" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "CLEARPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "RenderType"="Opaque" }
  ZTest Always
  ColorMask 0
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
"!!ARBvp1.0
PARAM c[5] = { { 0.0099999998 },
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[3];
ADD result.position.z, R0.x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
def c4, 0.01000000, 0, 0, 0
dcl_position0 v0
dp4 r0.x, v0, c2
add oPos.z, r0.x, c4.x
dp4 oPos.w, v0, c3
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
"!!ARBvp1.0
PARAM c[5] = { { 0.0099999998 },
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[3];
ADD result.position.z, R0.x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
def c4, 0.01000000, 0, 0, 0
dcl_position0 v0
dp4 r0.x, v0, c2
add oPos.z, r0.x, c4.x
dp4 oPos.w, v0, c3
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
"!!ARBvp1.0
PARAM c[5] = { { 0.0099999998 },
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[3];
ADD result.position.z, R0.x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
def c4, 0.01000000, 0, 0, 0
dcl_position0 v0
dp4 r0.x, v0, c2
add oPos.z, r0.x, c4.x
dp4 oPos.w, v0, c3
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
"!!ARBvp1.0
PARAM c[5] = { { 0.0099999998 },
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[3];
ADD result.position.z, R0.x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
def c4, 0.01000000, 0, 0, 0
dcl_position0 v0
dp4 r0.x, v0, c2
add oPos.z, r0.x, c4.x
dp4 oPos.w, v0, c3
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
"!!ARBvp1.0
PARAM c[5] = { { 0.0099999998 },
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[3];
ADD result.position.z, R0.x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
def c4, 0.01000000, 0, 0, 0
dcl_position0 v0
dp4 r0.x, v0, c2
add oPos.z, r0.x, c4.x
dp4 oPos.w, v0, c3
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
"!!ARBvp1.0
PARAM c[5] = { { 0.0099999998 },
		state.matrix.mvp };
TEMP R0;
DP4 R0.x, vertex.position, c[3];
ADD result.position.z, R0.x, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
def c4, 0.01000000, 0, 0, 0
dcl_position0 v0
dp4 r0.x, v0, c2
add oPos.z, r0.x, c4.x
dp4 oPos.w, v0, c3
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
 }
}
Fallback "Diffuse"
}