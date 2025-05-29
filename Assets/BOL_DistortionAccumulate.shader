Ž;Shader "BOL/FX/DistortionAccumulate" {
Properties {
 _OffsetTex ("Offset Tex", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZWrite Off
  Blend One One, Zero One
Program "vp" {
// Platform d3d11 had shader errors
//   Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
// Platform d3d11_9x had shader errors
//   Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 5 [_OffsetTex_ST]
"!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
TEMP R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[1], R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[5], c[5].zwzw;
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_OffsetTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
dcl_color0 v2
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mov oPos, r0
mov oD0, v2
mov oT1, r0
mad oT0.xy, v1, c4, c4.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 5 [_OffsetTex_ST]
"!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
TEMP R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[1], R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[5], c[5].zwzw;
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_OffsetTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
dcl_color0 v2
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mov oPos, r0
mov oD0, v2
mov oT1, r0
mad oT0.xy, v1, c4, c4.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 5 [_OffsetTex_ST]
"!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
TEMP R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[1], R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[5], c[5].zwzw;
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_OffsetTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
dcl_color0 v2
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mov oPos, r0
mov oD0, v2
mov oT1, r0
mad oT0.xy, v1, c4, c4.zwzw
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 5 [_OffsetTex_ST]
"!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
TEMP R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[1], R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[5], c[5].zwzw;
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_OffsetTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
dcl_color0 v2
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mov oPos, r0
mov oD0, v2
mov oT1, r0
mad oT0.xy, v1, c4, c4.zwzw
"
}
}
Program "fp" {
// Platform d3d11 had shader errors
//   Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
// Platform d3d11_9x had shader errors
//   Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_OffsetTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0, 2, 1 } };
TEMP R0;
TEX R0.y, fragment.texcoord[0], texture[0], 2D;
MAD R0.x, R0.y, c[0].y, -c[0].z;
MOV result.color.yzw, c[0].x;
MUL result.color.x, R0, fragment.color.primary;
END
# 4 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_OffsetTex] 2D 0
"ps_2_0
dcl_2d s0
def c0, 2.00000000, -1.00000000, 0.00000000, 0
dcl t0.xy
dcl v0.x
texld r0, t0, s0
mad r0.x, r0.y, c0, c0.y
mov r0.yzw, c0.z
mul r0.x, r0, v0
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_OffsetTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0, 2, 1 } };
TEMP R0;
TEX R0.y, fragment.texcoord[0], texture[0], 2D;
MAD R0.x, R0.y, c[0].y, -c[0].z;
MOV result.color.yzw, c[0].x;
MUL result.color.x, R0, fragment.color.primary;
END
# 4 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_OffsetTex] 2D 0
"ps_2_0
dcl_2d s0
def c0, 2.00000000, -1.00000000, 0.00000000, 0
dcl t0.xy
dcl v0.x
texld r0, t0, s0
mad r0.x, r0.y, c0, c0.y
mov r0.yzw, c0.z
mul r0.x, r0, v0
mov oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_OffsetTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0, 2, 1 } };
TEMP R0;
TEX R0.y, fragment.texcoord[0], texture[0], 2D;
MAD R0.x, R0.y, c[0].y, -c[0].z;
MOV result.color.yzw, c[0].x;
MUL result.color.x, R0, fragment.color.primary;
END
# 4 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_OffsetTex] 2D 0
"ps_2_0
dcl_2d s0
def c0, 2.00000000, -1.00000000, 0.00000000, 0
dcl t0.xy
dcl v0.x
texld r0, t0, s0
mad r0.x, r0.y, c0, c0.y
mov r0.yzw, c0.z
mul r0.x, r0, v0
mov oC0, r0
"
}
}
 }
}
Fallback "Diffuse"
}