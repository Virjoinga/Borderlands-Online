ÔêShader "BOL/Character/Character_Outline_Transparent" {
Properties {
 _OutlineColor ("Outline Color", Color) = (1,1,1,0)
 _OutlineWidth ("Outline Width", Float) = 0
}
SubShader { 
 LOD 400
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Name "FORWARDBASE"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZTest Always
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
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
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
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
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
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
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[1].xyz, -R0, c[9];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c9.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT1.xyz, -r0, c8
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
DP3 R0.y, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.y, R0.y;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R1.xyz, R0.y, fragment.texcoord[0];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
DP3_SAT R0.w, R0, R1;
SLT R0.x, R0.w, c[1];
ABS R0.x, R0;
CMP R1.y, -R0.x, c[2], c[2].x;
RCP R1.x, c[1].x;
MOV R0.xyz, c[0];
MAD R0.w, -R0, R1.x, c[2].x;
CMP result.color, -R1.y, c[2].y, R0;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"ps_2_0
def c2, 0.00000000, 1.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dp3 r1.x, t0, t0
dp3 r0.x, t1, t1
rsq r1.x, r1.x
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
mul r1.xyz, r1.x, t0
dp3_sat r0.x, r0, r1
add r1.x, r0, -c1
cmp r1.x, r1, c2, c2.y
rcp r2.x, c1.x
abs_pp r1.x, r1
mov r3.xyz, c0
mad r3.w, -r0.x, r2.x, c2.y
cmp r0, -r1.x, c2.x, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
DP3 R0.y, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.y, R0.y;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R1.xyz, R0.y, fragment.texcoord[0];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
DP3_SAT R0.w, R0, R1;
SLT R0.x, R0.w, c[1];
ABS R0.x, R0;
CMP R1.y, -R0.x, c[2], c[2].x;
RCP R1.x, c[1].x;
MOV R0.xyz, c[0];
MAD R0.w, -R0, R1.x, c[2].x;
CMP result.color, -R1.y, c[2].y, R0;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"ps_2_0
def c2, 0.00000000, 1.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dp3 r1.x, t0, t0
dp3 r0.x, t1, t1
rsq r1.x, r1.x
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
mul r1.xyz, r1.x, t0
dp3_sat r0.x, r0, r1
add r1.x, r0, -c1
cmp r1.x, r1, c2, c2.y
rcp r2.x, c1.x
abs_pp r1.x, r1
mov r3.xyz, c0
mad r3.w, -r0.x, r2.x, c2.y
cmp r0, -r1.x, c2.x, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
DP3 R0.y, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.y, R0.y;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R1.xyz, R0.y, fragment.texcoord[0];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
DP3_SAT R0.w, R0, R1;
SLT R0.x, R0.w, c[1];
ABS R0.x, R0;
CMP R1.y, -R0.x, c[2], c[2].x;
RCP R1.x, c[1].x;
MOV R0.xyz, c[0];
MAD R0.w, -R0, R1.x, c[2].x;
CMP result.color, -R1.y, c[2].y, R0;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"ps_2_0
def c2, 0.00000000, 1.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dp3 r1.x, t0, t0
dp3 r0.x, t1, t1
rsq r1.x, r1.x
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
mul r1.xyz, r1.x, t0
dp3_sat r0.x, r0, r1
add r1.x, r0, -c1
cmp r1.x, r1, c2, c2.y
rcp r2.x, c1.x
abs_pp r1.x, r1
mov r3.xyz, c0
mad r3.w, -r0.x, r2.x, c2.y
cmp r0, -r1.x, c2.x, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
DP3 R0.y, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.y, R0.y;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R1.xyz, R0.y, fragment.texcoord[0];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
DP3_SAT R0.w, R0, R1;
SLT R0.x, R0.w, c[1];
ABS R0.x, R0;
CMP R1.y, -R0.x, c[2], c[2].x;
RCP R1.x, c[1].x;
MOV R0.xyz, c[0];
MAD R0.w, -R0, R1.x, c[2].x;
CMP result.color, -R1.y, c[2].y, R0;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"ps_2_0
def c2, 0.00000000, 1.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dp3 r1.x, t0, t0
dp3 r0.x, t1, t1
rsq r1.x, r1.x
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
mul r1.xyz, r1.x, t0
dp3_sat r0.x, r0, r1
add r1.x, r0, -c1
cmp r1.x, r1, c2, c2.y
rcp r2.x, c1.x
abs_pp r1.x, r1
mov r3.xyz, c0
mad r3.w, -r0.x, r2.x, c2.y
cmp r0, -r1.x, c2.x, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
DP3 R0.y, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.y, R0.y;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R1.xyz, R0.y, fragment.texcoord[0];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
DP3_SAT R0.w, R0, R1;
SLT R0.x, R0.w, c[1];
ABS R0.x, R0;
CMP R1.y, -R0.x, c[2], c[2].x;
RCP R1.x, c[1].x;
MOV R0.xyz, c[0];
MAD R0.w, -R0, R1.x, c[2].x;
CMP result.color, -R1.y, c[2].y, R0;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"ps_2_0
def c2, 0.00000000, 1.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dp3 r1.x, t0, t0
dp3 r0.x, t1, t1
rsq r1.x, r1.x
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
mul r1.xyz, r1.x, t0
dp3_sat r0.x, r0, r1
add r1.x, r0, -c1
cmp r1.x, r1, c2, c2.y
rcp r2.x, c1.x
abs_pp r1.x, r1
mov r3.xyz, c0
mad r3.w, -r0.x, r2.x, c2.y
cmp r0, -r1.x, c2.x, r3
mov_pp oC0, r0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
DP3 R0.y, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.y, R0.y;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R1.xyz, R0.y, fragment.texcoord[0];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
DP3_SAT R0.w, R0, R1;
SLT R0.x, R0.w, c[1];
ABS R0.x, R0;
CMP R1.y, -R0.x, c[2], c[2].x;
RCP R1.x, c[1].x;
MOV R0.xyz, c[0];
MAD R0.w, -R0, R1.x, c[2].x;
CMP result.color, -R1.y, c[2].y, R0;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_OutlineColor]
Float 1 [_OutlineWidth]
"ps_2_0
def c2, 0.00000000, 1.00000000, 0, 0
dcl t0.xyz
dcl t1.xyz
dp3 r1.x, t0, t0
dp3 r0.x, t1, t1
rsq r1.x, r1.x
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
mul r1.xyz, r1.x, t0
dp3_sat r0.x, r0, r1
add r1.x, r0, -c1
cmp r1.x, r1, c2, c2.y
rcp r2.x, c1.x
abs_pp r1.x, r1
mov r3.xyz, c0
mad r3.w, -r0.x, r2.x, c2.y
cmp r0, -r1.x, c2.x, r3
mov_pp oC0, r0
"
}
}
 }
}
}