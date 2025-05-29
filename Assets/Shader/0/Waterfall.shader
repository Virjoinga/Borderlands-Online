¢ÂShader "Shader Forge/Waterfall" {
Properties {
 _Color ("Color", Color) = (0.647167,0.868444,0.977941,1)
 _Alpha ("Alpha", Float) = 2
 _Diffuse ("Diffuse", 2D) = "white" {}
 _UV_Tilling_1 ("UV_Tilling_1", Float) = 2
 _Wave_speed ("Wave_speed", Float) = 0.3
 _Water_Diffuse ("Water_Diffuse", 2D) = "white" {}
 _UV_Tilling_2 ("UV_Tilling_2", Float) = 2
 _Water_Speed ("Water_Speed", Float) = 0.3
 _Blend ("Blend", Float) = 2
[HideInInspector]  _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Name "FORWARDBASE"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
Program "vp" {
// Platform d3d11 had shader errors
//   Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
//   Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
//   Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
//   Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
}
Program "fp" {
// Platform d3d11 had shader errors
//   Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
//   Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
//   Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..11],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.x, c[2].y;
ADD R0.z, R0.x, c[0].y;
ADD R1.xyz, -fragment.texcoord[1], c[1];
DP3 R0.y, R1, R1;
RSQ R0.w, R0.y;
MUL R0.x, R0.z, c[7];
MUL R0.z, R0, c[10].x;
MUL R2.xy, R0.z, c[12];
MUL R0.xy, R0.x, c[12];
MAD R0.xy, fragment.texcoord[0], c[3].x, R0;
MAD R0.xy, R0, c[6], c[6].zwzw;
MUL R1.xyz, R0.w, R1;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R0.w, R0, R1;
MAD R2.xy, fragment.texcoord[0], c[9].x, R2;
MAD R1.xy, R2, c[8], c[8].zwzw;
MAX R0.w, R0, c[12].x;
TEX R1.xyz, R1, texture[1], 2D;
ADD R0.w, -R0, c[12].y;
MAD R0.xyz, R0.w, R1, R0;
ADD R1.xyz, -R0, c[4];
MAD result.color.xyz, R1, c[11].x, R0;
MUL result.color.w, R0.x, c[5].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c12, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
mov r0.x, c0.y
add r0.z, c2.y, r0.x
add r1.xyz, -v1, c1
dp3 r0.y, r1, r1
rsq r0.w, r0.y
mul r0.x, r0.z, c7
mul r0.z, r0, c10.x
mul r2.xy, r0.z, c12
mul r0.xy, r0.x, c12
mad r0.xy, v0, c3.x, r0
mad r0.xy, r0, c6, c6.zwzw
mul r1.xyz, r0.w, r1
texld r0.xyz, r0, s0
dp3 r0.w, r0, r1
mad r2.xy, v0, c9.x, r2
mad r1.xy, r2, c8, c8.zwzw
max r0.w, r0, c12.x
texld r1.xyz, r1, s1
add r0.w, -r0, c12.y
mad r0.xyz, r0.w, r1, r0
add r1.xyz, -r0, c4
mad oC0.xyz, r1, c11.x, r0
mul oC0.w, r0.x, c5.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..11],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.x, c[2].y;
ADD R0.z, R0.x, c[0].y;
ADD R1.xyz, -fragment.texcoord[1], c[1];
DP3 R0.y, R1, R1;
RSQ R0.w, R0.y;
MUL R0.x, R0.z, c[7];
MUL R0.z, R0, c[10].x;
MUL R2.xy, R0.z, c[12];
MUL R0.xy, R0.x, c[12];
MAD R0.xy, fragment.texcoord[0], c[3].x, R0;
MAD R0.xy, R0, c[6], c[6].zwzw;
MUL R1.xyz, R0.w, R1;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R0.w, R0, R1;
MAD R2.xy, fragment.texcoord[0], c[9].x, R2;
MAD R1.xy, R2, c[8], c[8].zwzw;
MAX R0.w, R0, c[12].x;
TEX R1.xyz, R1, texture[1], 2D;
ADD R0.w, -R0, c[12].y;
MAD R0.xyz, R0.w, R1, R0;
ADD R1.xyz, -R0, c[4];
MAD result.color.xyz, R1, c[11].x, R0;
MUL result.color.w, R0.x, c[5].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c12, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
mov r0.x, c0.y
add r0.z, c2.y, r0.x
add r1.xyz, -v1, c1
dp3 r0.y, r1, r1
rsq r0.w, r0.y
mul r0.x, r0.z, c7
mul r0.z, r0, c10.x
mul r2.xy, r0.z, c12
mul r0.xy, r0.x, c12
mad r0.xy, v0, c3.x, r0
mad r0.xy, r0, c6, c6.zwzw
mul r1.xyz, r0.w, r1
texld r0.xyz, r0, s0
dp3 r0.w, r0, r1
mad r2.xy, v0, c9.x, r2
mad r1.xy, r2, c8, c8.zwzw
max r0.w, r0, c12.x
texld r1.xyz, r1, s1
add r0.w, -r0, c12.y
mad r0.xyz, r0.w, r1, r0
add r1.xyz, -r0, c4
mad oC0.xyz, r1, c11.x, r0
mul oC0.w, r0.x, c5.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..11],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.x, c[2].y;
ADD R0.z, R0.x, c[0].y;
ADD R1.xyz, -fragment.texcoord[1], c[1];
DP3 R0.y, R1, R1;
RSQ R0.w, R0.y;
MUL R0.x, R0.z, c[7];
MUL R0.z, R0, c[10].x;
MUL R2.xy, R0.z, c[12];
MUL R0.xy, R0.x, c[12];
MAD R0.xy, fragment.texcoord[0], c[3].x, R0;
MAD R0.xy, R0, c[6], c[6].zwzw;
MUL R1.xyz, R0.w, R1;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R0.w, R0, R1;
MAD R2.xy, fragment.texcoord[0], c[9].x, R2;
MAD R1.xy, R2, c[8], c[8].zwzw;
MAX R0.w, R0, c[12].x;
TEX R1.xyz, R1, texture[1], 2D;
ADD R0.w, -R0, c[12].y;
MAD R0.xyz, R0.w, R1, R0;
ADD R1.xyz, -R0, c[4];
MAD result.color.xyz, R1, c[11].x, R0;
MUL result.color.w, R0.x, c[5].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c12, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
mov r0.x, c0.y
add r0.z, c2.y, r0.x
add r1.xyz, -v1, c1
dp3 r0.y, r1, r1
rsq r0.w, r0.y
mul r0.x, r0.z, c7
mul r0.z, r0, c10.x
mul r2.xy, r0.z, c12
mul r0.xy, r0.x, c12
mad r0.xy, v0, c3.x, r0
mad r0.xy, r0, c6, c6.zwzw
mul r1.xyz, r0.w, r1
texld r0.xyz, r0, s0
dp3 r0.w, r0, r1
mad r2.xy, v0, c9.x, r2
mad r1.xy, r2, c8, c8.zwzw
max r0.w, r0, c12.x
texld r1.xyz, r1, s1
add r0.w, -r0, c12.y
mad r0.xyz, r0.w, r1, r0
add r1.xyz, -r0, c4
mad oC0.xyz, r1, c11.x, r0
mul oC0.w, r0.x, c5.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..11],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.x, c[2].y;
ADD R0.z, R0.x, c[0].y;
ADD R1.xyz, -fragment.texcoord[1], c[1];
DP3 R0.y, R1, R1;
RSQ R0.w, R0.y;
MUL R0.x, R0.z, c[7];
MUL R0.z, R0, c[10].x;
MUL R2.xy, R0.z, c[12];
MUL R0.xy, R0.x, c[12];
MAD R0.xy, fragment.texcoord[0], c[3].x, R0;
MAD R0.xy, R0, c[6], c[6].zwzw;
MUL R1.xyz, R0.w, R1;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R0.w, R0, R1;
MAD R2.xy, fragment.texcoord[0], c[9].x, R2;
MAD R1.xy, R2, c[8], c[8].zwzw;
MAX R0.w, R0, c[12].x;
TEX R1.xyz, R1, texture[1], 2D;
ADD R0.w, -R0, c[12].y;
MAD R0.xyz, R0.w, R1, R0;
ADD R1.xyz, -R0, c[4];
MAD result.color.xyz, R1, c[11].x, R0;
MUL result.color.w, R0.x, c[5].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c12, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
mov r0.x, c0.y
add r0.z, c2.y, r0.x
add r1.xyz, -v1, c1
dp3 r0.y, r1, r1
rsq r0.w, r0.y
mul r0.x, r0.z, c7
mul r0.z, r0, c10.x
mul r2.xy, r0.z, c12
mul r0.xy, r0.x, c12
mad r0.xy, v0, c3.x, r0
mad r0.xy, r0, c6, c6.zwzw
mul r1.xyz, r0.w, r1
texld r0.xyz, r0, s0
dp3 r0.w, r0, r1
mad r2.xy, v0, c9.x, r2
mad r1.xy, r2, c8, c8.zwzw
max r0.w, r0, c12.x
texld r1.xyz, r1, s1
add r0.w, -r0, c12.y
mad r0.xyz, r0.w, r1, r0
add r1.xyz, -r0, c4
mad oC0.xyz, r1, c11.x, r0
mul oC0.w, r0.x, c5.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..11],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.x, c[2].y;
ADD R0.z, R0.x, c[0].y;
ADD R1.xyz, -fragment.texcoord[1], c[1];
DP3 R0.y, R1, R1;
RSQ R0.w, R0.y;
MUL R0.x, R0.z, c[7];
MUL R0.z, R0, c[10].x;
MUL R2.xy, R0.z, c[12];
MUL R0.xy, R0.x, c[12];
MAD R0.xy, fragment.texcoord[0], c[3].x, R0;
MAD R0.xy, R0, c[6], c[6].zwzw;
MUL R1.xyz, R0.w, R1;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R0.w, R0, R1;
MAD R2.xy, fragment.texcoord[0], c[9].x, R2;
MAD R1.xy, R2, c[8], c[8].zwzw;
MAX R0.w, R0, c[12].x;
TEX R1.xyz, R1, texture[1], 2D;
ADD R0.w, -R0, c[12].y;
MAD R0.xyz, R0.w, R1, R0;
ADD R1.xyz, -R0, c[4];
MAD result.color.xyz, R1, c[11].x, R0;
MUL result.color.w, R0.x, c[5].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c12, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
mov r0.x, c0.y
add r0.z, c2.y, r0.x
add r1.xyz, -v1, c1
dp3 r0.y, r1, r1
rsq r0.w, r0.y
mul r0.x, r0.z, c7
mul r0.z, r0, c10.x
mul r2.xy, r0.z, c12
mul r0.xy, r0.x, c12
mad r0.xy, v0, c3.x, r0
mad r0.xy, r0, c6, c6.zwzw
mul r1.xyz, r0.w, r1
texld r0.xyz, r0, s0
dp3 r0.w, r0, r1
mad r2.xy, v0, c9.x, r2
mad r1.xy, r2, c8, c8.zwzw
max r0.w, r0, c12.x
texld r1.xyz, r1, s1
add r0.w, -r0, c12.y
mad r0.xyz, r0.w, r1, r0
add r1.xyz, -r0, c4
mad oC0.xyz, r1, c11.x, r0
mul oC0.w, r0.x, c5.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..11],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.x, c[2].y;
ADD R0.z, R0.x, c[0].y;
ADD R1.xyz, -fragment.texcoord[1], c[1];
DP3 R0.y, R1, R1;
RSQ R0.w, R0.y;
MUL R0.x, R0.z, c[7];
MUL R0.z, R0, c[10].x;
MUL R2.xy, R0.z, c[12];
MUL R0.xy, R0.x, c[12];
MAD R0.xy, fragment.texcoord[0], c[3].x, R0;
MAD R0.xy, R0, c[6], c[6].zwzw;
MUL R1.xyz, R0.w, R1;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R0.w, R0, R1;
MAD R2.xy, fragment.texcoord[0], c[9].x, R2;
MAD R1.xy, R2, c[8], c[8].zwzw;
MAX R0.w, R0, c[12].x;
TEX R1.xyz, R1, texture[1], 2D;
ADD R0.w, -R0, c[12].y;
MAD R0.xyz, R0.w, R1, R0;
ADD R1.xyz, -R0, c[4];
MAD result.color.xyz, R1, c[11].x, R0;
MUL result.color.w, R0.x, c[5].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Float 3 [_UV_Tilling_1]
Vector 4 [_Color]
Float 5 [_Alpha]
Vector 6 [_Diffuse_ST]
Float 7 [_Wave_speed]
Vector 8 [_Water_Diffuse_ST]
Float 9 [_UV_Tilling_2]
Float 10 [_Water_Speed]
Float 11 [_Blend]
SetTexture 0 [_Diffuse] 2D 0
SetTexture 1 [_Water_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c12, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
mov r0.x, c0.y
add r0.z, c2.y, r0.x
add r1.xyz, -v1, c1
dp3 r0.y, r1, r1
rsq r0.w, r0.y
mul r0.x, r0.z, c7
mul r0.z, r0, c10.x
mul r2.xy, r0.z, c12
mul r0.xy, r0.x, c12
mad r0.xy, v0, c3.x, r0
mad r0.xy, r0, c6, c6.zwzw
mul r1.xyz, r0.w, r1
texld r0.xyz, r0, s0
dp3 r0.w, r0, r1
mad r2.xy, v0, c9.x, r2
mad r1.xy, r2, c8, c8.zwzw
max r0.w, r0, c12.x
texld r1.xyz, r1, s1
add r0.w, -r0, c12.y
mad r0.xyz, r0.w, r1, r0
add r1.xyz, -r0, c4
mad oC0.xyz, r1, c11.x, r0
mul oC0.w, r0.x, c5.x
"
}
}
 }
}
Fallback "Diffuse"
}