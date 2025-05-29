‹ÄShader "BOL/Scene/TwoSideDiffuseAlpha" {
Properties {
 _MainTex ("Main Tex", 2D) = "white" {}
 _MainColor ("Main Color", Color) = (1,1,1,1)
 _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="AlphaTest" "RenderType"="TransparentCutout" }
 Pass {
  Name "FORWARDBASE"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="AlphaTest" "RenderType"="TransparentCutout" }
  Cull Off
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
"3.0-!!ARBvp1.0
PARAM c[13] = { { 0 },
		state.matrix.mvp,
		program.local[5..12] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R0.xyz, R0, c[0].x;
MUL R2.xyz, R0.zxyw, R1.yzxw;
MAD R2.xyz, R0.yzxw, R1.zxyw, -R2;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[3].xyz, R1;
MOV result.texcoord[2].xyz, R0;
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
# 29 instructions, 3 R-regs
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
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c12, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c12.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r1.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r0.xyz, r0, c12.x
mul r2.xyz, r0.zxyw, r1.yzxw
mad r2.xyz, r0.yzxw, r1.zxyw, -r2
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
mov o4.xyz, r1
mov o3.xyz, r0
mov o1.xy, v3
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
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[14] = { { 0 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[3].xyz, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[7].xy, vertex.texcoord[1], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 30 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord7 o6
def c13, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r1.xyz, v2
mov r1.w, c13.x
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r1.xyz, r1, c13.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
mov o4.xyz, r0
mov o3.xyz, r1
mov o1.xy, v3
mad o6.xy, v4, c12, c12.zwzw
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
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[14] = { { 0 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[3].xyz, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[7].xy, vertex.texcoord[1], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 30 instructions, 3 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord7 o6
def c13, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r1.xyz, v2
mov r1.w, c13.x
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r1.xyz, r1, c13.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
mov o4.xyz, r0
mov o3.xyz, r1
mov o1.xy, v3
mad o6.xy, v4, c12, c12.zwzw
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
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
"3.0-!!ARBvp1.0
PARAM c[14] = { { 0, 0.5 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
MUL R2.y, R2, c[13].x;
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 34 instructions, 4 R-regs
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
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c14, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c14.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r1.xyz, r0, c14.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c14.y
mul r2.y, r2, c12.x
mov o4.xyz, r3
mad o6.xy, r2.z, c13.zwzw, r2
mov o0, r0
mov o6.zw, r0
mov o3.xyz, r1
mov o1.xy, v3
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[15] = { { 0, 0.5 },
		state.matrix.mvp,
		program.local[5..14] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
MUL R2.y, R2, c[13].x;
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[7].xy, vertex.texcoord[1], c[14], c[14].zwzw;
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 35 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c15, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.w, c15.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r1.xyz, r0, c15.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c15.y
mul r2.y, r2, c12.x
mov o4.xyz, r3
mad o6.xy, r2.z, c13.zwzw, r2
mov o0, r0
mov o6.zw, r0
mov o3.xyz, r1
mov o1.xy, v3
mad o7.xy, v4, c14, c14.zwzw
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[15] = { { 0, 0.5 },
		state.matrix.mvp,
		program.local[5..14] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
MUL R2.y, R2, c[13].x;
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[7].xy, vertex.texcoord[1], c[14], c[14].zwzw;
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 35 instructions, 4 R-regs
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
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c15, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.w, c15.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r1.xyz, r0, c15.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c15.y
mul r2.y, r2, c12.x
mov o4.xyz, r3
mad o6.xy, r2.z, c13.zwzw, r2
mov o0, r0
mov o6.zw, r0
mov o3.xyz, r1
mov o1.xy, v3
mad o7.xy, v4, c14, c14.zwzw
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
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
"3.0-!!ARBvp1.0
PARAM c[13] = { { 0 },
		state.matrix.mvp,
		program.local[5..12] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R0.xyz, R0, c[0].x;
MUL R2.xyz, R0.zxyw, R1.yzxw;
MAD R2.xyz, R0.yzxw, R1.zxyw, -R2;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[3].xyz, R1;
MOV result.texcoord[2].xyz, R0;
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
# 29 instructions, 3 R-regs
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
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c12, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c12.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r1.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r0.xyz, r0, c12.x
mul r2.xyz, r0.zxyw, r1.yzxw
mad r2.xyz, r0.yzxw, r1.zxyw, -r2
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
mov o4.xyz, r1
mov o3.xyz, r0
mov o1.xy, v3
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
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
"3.0-!!ARBvp1.0
PARAM c[14] = { { 0, 0.5 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
MUL R2.y, R2, c[13].x;
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 34 instructions, 4 R-regs
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
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c14, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c14.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r1.xyz, r0, c14.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c14.y
mul r2.y, r2, c12.x
mov o4.xyz, r3
mad o6.xy, r2.z, c13.zwzw, r2
mov o0, r0
mov o6.zw, r0
mov o3.xyz, r1
mov o1.xy, v3
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987, 1 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.x, fragment.texcoord[2], R0;
SLT R0.y, c[6].x, R0.x;
DP3 R0.z, c[1], c[1];
RSQ R0.z, R0.z;
SLT R0.x, R0, c[6];
MUL R1.xyz, R0.z, c[1];
ADD R0.x, R0.y, -R0;
MUL R0.xyz, fragment.texcoord[2], R0.x;
DP3 R0.x, R0, R1;
MAX R1.x, R0, c[6];
MAD R0.zw, fragment.texcoord[0].xyxy, c[4].xyxy, c[4];
TEX R0, R0.zwzw, texture[0], 2D;
MUL R1.xyz, R1.x, c[2];
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].z;
END
# 23 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.x, v2, r0
cmp r0.y, -r0.x, c6.x, c6
dp3_pp r0.z, c1, c1
rsq_pp r0.z, r0.z
cmp r0.x, r0, c6, c6.y
mul_pp r1.xyz, r0.z, c1
add r0.x, r0.y, -r0
mul r0.xyz, v2, r0.x
dp3 r0.z, r0, r1
max r1.x, r0.z, c6
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.x, c2
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.z
texkill r0.xyzw
mov_pp oC0.w, c6.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 1 [_Cutoff]
Vector 2 [_MainTex_ST]
Vector 3 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEX R1, fragment.texcoord[7], texture[1], 2D;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.w, R1;
MUL R1.xyz, R1, c[4].x;
MUL R0.xyz, R1, R0;
SLT R0.w, R0, c[1].x;
MUL result.color.xyz, R0, c[3];
KIL -R0.w;
MOV result.color.w, c[4].y;
END
# 10 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_Cutoff]
Vector 1 [_MainTex_ST]
Vector 2 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 0.00000000, 1.00000000, 8.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord7 v3.xy
mad r0.xy, v0, c1, c1.zwzw
texld r0, r0, s0
texld r1, v3, s1
mul_pp r1.xyz, r1.w, r1
add r0.w, r0, -c0.x
mul_pp r1.xyz, r1, c3.z
mul r1.xyz, r0, r1
cmp r0.w, r0, c3.x, c3.y
mov_pp r0, -r0.w
mul oC0.xyz, r1, c2
texkill r0.xyzw
mov_pp oC0.w, c3.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 1 [_Cutoff]
Vector 2 [_MainTex_ST]
Vector 3 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 0.57714844, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[7], texture[2], 2D;
MUL R2.xyz, R0.w, R0;
TEX R0, fragment.texcoord[7], texture[1], 2D;
MUL R0.xyz, R0.w, R0;
MAD R1.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MUL R2.xyz, R2, c[4].x;
TEX R1, R1, texture[0], 2D;
DP3 R0.w, R2, c[4].y;
MUL R0.xyz, R0, c[4].x;
MUL R0.xyz, R0, R0.w;
MUL R0.xyz, R0, R1;
SLT R0.w, R1, c[1].x;
MUL result.color.xyz, R0, c[3];
KIL -R0.w;
MOV result.color.w, c[4].z;
END
# 15 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_Cutoff]
Vector 1 [_MainTex_ST]
Vector 2 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 0.00000000, 1.00000000, 8.00000000, 0.57714844
dcl_texcoord0 v0.xy
dcl_texcoord7 v5.xy
texld r1, v5, s2
mul_pp r2.xyz, r1.w, r1
texld r1, v5, s1
mul_pp r1.xyz, r1.w, r1
mad r0.xy, v0, c1, c1.zwzw
texld r0, r0, s0
add r0.w, r0, -c0.x
mul_pp r2.xyz, r2, c3.z
dp3_pp r1.w, r2, c3.w
mul_pp r1.xyz, r1, c3.z
mul r1.xyz, r1, r1.w
mul r1.xyz, r0, r1
cmp r0.w, r0, c3.x, c3.y
mov_pp r0, -r0.w
mul oC0.xyz, r1, c2
texkill r0.xyzw
mov_pp oC0.w, c3.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987, 1 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.x, fragment.texcoord[2], R0;
SLT R0.y, c[6].x, R0.x;
DP3 R0.z, c[1], c[1];
RSQ R0.z, R0.z;
SLT R0.x, R0, c[6];
MUL R1.xyz, R0.z, c[1];
ADD R0.x, R0.y, -R0;
MUL R0.xyz, fragment.texcoord[2], R0.x;
DP3 R0.x, R0, R1;
MAX R1.w, R0.x, c[6].x;
TXP R1.x, fragment.texcoord[5], texture[1], 2D;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.x, c[2];
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].z;
END
# 25 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.x, v2, r0
cmp r0.y, -r0.x, c6.x, c6
dp3_pp r0.z, c1, c1
rsq_pp r0.z, r0.z
cmp r0.x, r0, c6, c6.y
mul_pp r1.xyz, r0.z, c1
add r0.x, r0.y, -r0
mul r0.xyz, v2, r0.x
dp3 r0.x, r0, r1
max r1.w, r0.x, c6.x
texldp r1.x, v3, s1
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.x, c2
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.z
texkill r0.xyzw
mov_pp oC0.w, c6.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 1 [_Cutoff]
Vector 2 [_MainTex_ST]
Vector 3 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEX R1, fragment.texcoord[7], texture[1], 2D;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.w, R1;
MUL R1.xyz, R1, c[4].x;
MUL R0.xyz, R1, R0;
SLT R0.w, R0, c[1].x;
MUL result.color.xyz, R0, c[3];
KIL -R0.w;
MOV result.color.w, c[4].y;
END
# 10 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_Cutoff]
Vector 1 [_MainTex_ST]
Vector 2 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 0.00000000, 1.00000000, 8.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord7 v4.xy
mad r0.xy, v0, c1, c1.zwzw
texld r0, r0, s0
texld r1, v4, s1
mul_pp r1.xyz, r1.w, r1
add r0.w, r0, -c0.x
mul_pp r1.xyz, r1, c3.z
mul r1.xyz, r0, r1
cmp r0.w, r0, c3.x, c3.y
mov_pp r0, -r0.w
mul oC0.xyz, r1, c2
texkill r0.xyzw
mov_pp oC0.w, c3.y
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 1 [_Cutoff]
Vector 2 [_MainTex_ST]
Vector 3 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 0.57714844, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[7], texture[2], 2D;
MUL R2.xyz, R0.w, R0;
TEX R0, fragment.texcoord[7], texture[1], 2D;
MUL R0.xyz, R0.w, R0;
MAD R1.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MUL R2.xyz, R2, c[4].x;
TEX R1, R1, texture[0], 2D;
DP3 R0.w, R2, c[4].y;
MUL R0.xyz, R0, c[4].x;
MUL R0.xyz, R0, R0.w;
MUL R0.xyz, R0, R1;
SLT R0.w, R1, c[1].x;
MUL result.color.xyz, R0, c[3];
KIL -R0.w;
MOV result.color.w, c[4].z;
END
# 15 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_Cutoff]
Vector 1 [_MainTex_ST]
Vector 2 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 0.00000000, 1.00000000, 8.00000000, 0.57714844
dcl_texcoord0 v0.xy
dcl_texcoord7 v6.xy
texld r1, v6, s2
mul_pp r2.xyz, r1.w, r1
texld r1, v6, s1
mul_pp r1.xyz, r1.w, r1
mad r0.xy, v0, c1, c1.zwzw
texld r0, r0, s0
add r0.w, r0, -c0.x
mul_pp r2.xyz, r2, c3.z
dp3_pp r1.w, r2, c3.w
mul_pp r1.xyz, r1, c3.z
mul r1.xyz, r1, r1.w
mul r1.xyz, r0, r1
cmp r0.w, r0, c3.x, c3.y
mov_pp r0, -r0.w
mul oC0.xyz, r1, c2
texkill r0.xyzw
mov_pp oC0.w, c3.y
"
}
}
 }
 Pass {
  Name "FORWARDADD"
  Tags { "LIGHTMODE"="ForwardAdd" "SHADOWSUPPORT"="true" "QUEUE"="AlphaTest" "RenderType"="TransparentCutout" }
  Cull Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R0.xyz, R0, c[0].x;
MUL R2.xyz, R0.zxyw, R1.yzxw;
MAD R2.xyz, R0.yzxw, R1.zxyw, -R2;
MOV result.texcoord[3].xyz, R1;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[1], R1;
DP4 result.texcoord[5].z, R1, c[15];
DP4 result.texcoord[5].y, R1, c[14];
DP4 result.texcoord[5].x, R1, c[13];
MOV result.texcoord[2].xyz, R0;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c16.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r1.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r0.xyz, r0, c16.x
mul r2.xyz, r0.zxyw, r1.yzxw
mad r2.xyz, r0.yzxw, r1.zxyw, -r2
mov o4.xyz, r1
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
dp4 r1.w, v0, c7
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul o5.xyz, r0.w, r2
mov o2, r1
dp4 o6.z, r1, c14
dp4 o6.y, r1, c13
dp4 o6.x, r1, c12
mov o3.xyz, r0
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
"3.0-!!ARBvp1.0
PARAM c[13] = { { 0 },
		state.matrix.mvp,
		program.local[5..12] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R0.xyz, R0, c[0].x;
MUL R2.xyz, R0.zxyw, R1.yzxw;
MAD R2.xyz, R0.yzxw, R1.zxyw, -R2;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[3].xyz, R1;
MOV result.texcoord[2].xyz, R0;
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
# 29 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c12, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c12.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r1.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r0.xyz, r0, c12.x
mul r2.xyz, r0.zxyw, r1.yzxw
mad r2.xyz, r0.yzxw, r1.zxyw, -r2
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
mov o4.xyz, r1
mov o3.xyz, r0
mov o1.xy, v3
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
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
TEMP R2;
DP4 R1.w, vertex.position, c[8];
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R0.xyz, R0, c[0].x;
MUL R2.xyz, R0.zxyw, R1.yzxw;
MAD R2.xyz, R0.yzxw, R1.zxyw, -R2;
MOV result.texcoord[3].xyz, R1;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[1], R1;
DP4 result.texcoord[5].w, R1, c[16];
DP4 result.texcoord[5].z, R1, c[15];
DP4 result.texcoord[5].y, R1, c[14];
DP4 result.texcoord[5].x, R1, c[13];
MOV result.texcoord[2].xyz, R0;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 34 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dp4 r1.w, v0, c7
mov r0.w, c16.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r1.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r0.xyz, r0, c16.x
mul r2.xyz, r0.zxyw, r1.yzxw
mad r2.xyz, r0.yzxw, r1.zxyw, -r2
mov o4.xyz, r1
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul o5.xyz, r0.w, r2
mov o2, r1
dp4 o6.w, r1, c15
dp4 o6.z, r1, c14
dp4 o6.y, r1, c13
dp4 o6.x, r1, c12
mov o3.xyz, r0
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R0.xyz, R0, c[0].x;
MUL R2.xyz, R0.zxyw, R1.yzxw;
MAD R2.xyz, R0.yzxw, R1.zxyw, -R2;
MOV result.texcoord[3].xyz, R1;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[1], R1;
DP4 result.texcoord[5].z, R1, c[15];
DP4 result.texcoord[5].y, R1, c[14];
DP4 result.texcoord[5].x, R1, c[13];
MOV result.texcoord[2].xyz, R0;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c16.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r1.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r0.xyz, r0, c16.x
mul r2.xyz, r0.zxyw, r1.yzxw
mad r2.xyz, r0.yzxw, r1.zxyw, -r2
mov o4.xyz, r1
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
dp4 r1.w, v0, c7
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul o5.xyz, r0.w, r2
mov o2, r1
dp4 o6.z, r1, c14
dp4 o6.y, r1, c13
dp4 o6.x, r1, c12
mov o3.xyz, r0
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R0.xyz, R0, c[0].x;
MUL R2.xyz, R0.zxyw, R1.yzxw;
MAD R2.xyz, R0.yzxw, R1.zxyw, -R2;
MOV result.texcoord[3].xyz, R1;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MUL result.texcoord[4].xyz, R0.w, R2;
MOV result.texcoord[1], R1;
DP4 result.texcoord[5].y, R1, c[14];
DP4 result.texcoord[5].x, R1, c[13];
MOV result.texcoord[2].xyz, R0;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 32 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c16.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r1.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r0.xyz, r0, c16.x
mul r2.xyz, r0.zxyw, r1.yzxw
mad r2.xyz, r0.yzxw, r1.zxyw, -r2
mov o4.xyz, r1
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
dp4 r1.w, v0, c7
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul o5.xyz, r0.w, r2
mov o2, r1
dp4 o6.y, r1, c13
dp4 o6.x, r1, c12
mov o3.xyz, r0
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [unity_World2Shadow0]
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[11];
DP4 R0.y, R1, c[10];
DP4 R0.x, R1, c[9];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].w, R0, c[20];
DP4 result.texcoord[5].z, R0, c[19];
DP4 result.texcoord[5].y, R0, c[18];
DP4 result.texcoord[5].x, R0, c[17];
DP4 result.texcoord[6].w, R0, c[8];
DP4 result.texcoord[6].z, R0, c[7];
DP4 result.texcoord[6].y, R0, c[6];
DP4 result.texcoord[6].x, R0, c[5];
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [unity_World2Shadow0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c20.x
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
add r1.xyz, r1, c20.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o6.w, r0, c19
dp4 o6.z, r0, c18
dp4 o6.y, r0, c17
dp4 o6.x, r0, c16
dp4 o7.w, r0, c7
dp4 o7.z, r0, c6
dp4 o7.y, r0, c5
dp4 o7.x, r0, c4
mov o3.xyz, r1
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [unity_World2Shadow0]
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[11];
DP4 R0.y, R1, c[10];
DP4 R0.x, R1, c[9];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].w, R0, c[20];
DP4 result.texcoord[5].z, R0, c[19];
DP4 result.texcoord[5].y, R0, c[18];
DP4 result.texcoord[5].x, R0, c[17];
DP4 result.texcoord[6].w, R0, c[8];
DP4 result.texcoord[6].z, R0, c[7];
DP4 result.texcoord[6].y, R0, c[6];
DP4 result.texcoord[6].x, R0, c[5];
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [unity_World2Shadow0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c20.x
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
add r1.xyz, r1, c20.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o6.w, r0, c19
dp4 o6.z, r0, c18
dp4 o6.y, r0, c17
dp4 o6.x, r0, c16
dp4 o7.w, r0, c7
dp4 o7.z, r0, c6
dp4 o7.y, r0, c5
dp4 o7.x, r0, c4
mov o3.xyz, r1
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
"3.0-!!ARBvp1.0
PARAM c[14] = { { 0, 0.5 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
MUL R2.y, R2, c[13].x;
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 34 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c14, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c14.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r1.xyz, r0, c14.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c14.y
mul r2.y, r2, c12.x
mov o4.xyz, r3
mad o6.xy, r2.z, c13.zwzw, r2
mov o0, r0
mov o6.zw, r0
mov o3.xyz, r1
mov o1.xy, v3
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_ProjectionParams]
"3.0-!!ARBvp1.0
PARAM c[18] = { { 0, 0.5 },
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R2.w, vertex.position, c[8];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].y;
MUL R2.y, R2, c[17].x;
ADD result.texcoord[6].xy, R2, R2.z;
DP4 R2.z, vertex.position, c[7];
DP4 R2.x, vertex.position, c[5];
DP4 R2.y, vertex.position, c[6];
MOV result.texcoord[3].xyz, R3;
MOV result.position, R0;
MOV result.texcoord[1], R2;
DP4 result.texcoord[5].y, R2, c[14];
DP4 result.texcoord[5].x, R2, c[13];
MOV result.texcoord[6].zw, R0;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
END
# 37 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c18, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r0.w, c18.x
mov r0.xyz, v2
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add r1.xyz, r0, c18.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r2.w, v0, c7
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c18.y
mul r2.y, r2, c16.x
mad o7.xy, r2.z, c17.zwzw, r2
dp4 r2.z, v0, c6
dp4 r2.x, v0, c4
dp4 r2.y, v0, c5
mov o4.xyz, r3
mov o0, r0
mov o2, r2
dp4 o6.y, r2, c13
dp4 o6.x, r2, c12
mov o7.zw, r0
mov o3.xyz, r1
mov o1.xy, v3
"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_LightPositionRange]
"3.0-!!ARBvp1.0
PARAM c[18] = { { 0 },
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].z, R0, c[15];
DP4 result.texcoord[5].y, R0, c[14];
DP4 result.texcoord[5].x, R0, c[13];
MOV result.texcoord[2].xyz, R1;
ADD result.texcoord[6].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 34 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_LightPositionRange]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c17.x
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r1.xyz, r1, c17.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o6.z, r0, c14
dp4 o6.y, r0, c13
dp4 o6.x, r0, c12
mov o3.xyz, r1
add o7.xyz, r0, -c16
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_LightPositionRange]
"3.0-!!ARBvp1.0
PARAM c[18] = { { 0 },
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].z, R0, c[15];
DP4 result.texcoord[5].y, R0, c[14];
DP4 result.texcoord[5].x, R0, c[13];
MOV result.texcoord[2].xyz, R1;
ADD result.texcoord[6].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 34 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_LightPositionRange]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c17.x
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r1.xyz, r1, c17.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o6.z, r0, c14
dp4 o6.y, r0, c13
dp4 o6.x, r0, c12
mov o3.xyz, r1
add o7.xyz, r0, -c16
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [unity_World2Shadow0]
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[11];
DP4 R0.y, R1, c[10];
DP4 R0.x, R1, c[9];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].w, R0, c[20];
DP4 result.texcoord[5].z, R0, c[19];
DP4 result.texcoord[5].y, R0, c[18];
DP4 result.texcoord[5].x, R0, c[17];
DP4 result.texcoord[6].w, R0, c[8];
DP4 result.texcoord[6].z, R0, c[7];
DP4 result.texcoord[6].y, R0, c[6];
DP4 result.texcoord[6].x, R0, c[5];
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [unity_World2Shadow0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c20.x
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
add r1.xyz, r1, c20.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o6.w, r0, c19
dp4 o6.z, r0, c18
dp4 o6.y, r0, c17
dp4 o6.x, r0, c16
dp4 o7.w, r0, c7
dp4 o7.z, r0, c6
dp4 o7.y, r0, c5
dp4 o7.x, r0, c4
mov o3.xyz, r1
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [unity_World2Shadow0]
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Matrix 17 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[11];
DP4 R0.y, R1, c[10];
DP4 R0.x, R1, c[9];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].w, R0, c[20];
DP4 result.texcoord[5].z, R0, c[19];
DP4 result.texcoord[5].y, R0, c[18];
DP4 result.texcoord[5].x, R0, c[17];
DP4 result.texcoord[6].w, R0, c[8];
DP4 result.texcoord[6].z, R0, c[7];
DP4 result.texcoord[6].y, R0, c[6];
DP4 result.texcoord[6].x, R0, c[5];
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [unity_World2Shadow0]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Matrix 16 [_LightMatrix0]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c20.x
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
add r1.xyz, r1, c20.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o6.w, r0, c19
dp4 o6.z, r0, c18
dp4 o6.y, r0, c17
dp4 o6.x, r0, c16
dp4 o7.w, r0, c7
dp4 o7.z, r0, c6
dp4 o7.y, r0, c5
dp4 o7.x, r0, c4
mov o3.xyz, r1
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_LightPositionRange]
"3.0-!!ARBvp1.0
PARAM c[18] = { { 0 },
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].z, R0, c[15];
DP4 result.texcoord[5].y, R0, c[14];
DP4 result.texcoord[5].x, R0, c[13];
MOV result.texcoord[2].xyz, R1;
ADD result.texcoord[6].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 34 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_LightPositionRange]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c17.x
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r1.xyz, r1, c17.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o6.z, r0, c14
dp4 o6.y, r0, c13
dp4 o6.x, r0, c12
mov o3.xyz, r1
add o7.xyz, r0, -c16
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Vector 17 [_LightPositionRange]
"3.0-!!ARBvp1.0
PARAM c[18] = { { 0 },
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.attrib[14];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R1.xyz, R1, c[0].x;
MUL R2.xyz, R1.zxyw, R0.yzxw;
MAD R2.xyz, R1.yzxw, R0.zxyw, -R2;
MOV result.texcoord[3].xyz, R0;
MUL R2.xyz, vertex.attrib[14].w, R2;
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R2;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[5].z, R0, c[15];
DP4 result.texcoord[5].y, R0, c[14];
DP4 result.texcoord[5].x, R0, c[13];
MOV result.texcoord[2].xyz, R1;
ADD result.texcoord[6].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 34 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Vector 16 [_LightPositionRange]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c17.x
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r1.xyz, r1, c17.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mov o4.xyz, r0
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o5.xyz, r0.w, r2
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o6.z, r0, c14
dp4 o6.y, r0, c13
dp4 o6.x, r0, c12
mov o3.xyz, r1
add o7.xyz, r0, -c16
mov o1.xy, v3
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[6], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[6].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R0.w, R0.y, texture[1], 2D;
MAX R1.w, R0.x, c[6].x;
MUL R1.xyz, R0.w, c[2];
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].x;
END
# 27 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
add r1.xyz, -v1, c0
dp3 r0.x, r1, r1
rsq r0.x, r0.x
mul r0.xyz, r0.x, r1
dp3 r1.x, v2, r0
cmp r1.y, -r1.x, c6.x, c6
mad r0.xyz, -v1, c1.w, c1
dp3 r0.w, r0, r0
rsq r0.w, r0.w
cmp r1.x, r1, c6, c6.y
add r1.x, r1.y, -r1
mul r0.xyz, r0.w, r0
mul r1.xyz, v2, r1.x
dp3 r0.y, r1, r0
dp3 r0.x, v3, v3
texld r1.x, r0.x, s1
max r1.w, r0.y, c6.x
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.x, c2
mul r1.xyz, r1.w, r1
mul r0.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.w, r0, c6.x, c6.y
mul r0.xyz, r0, c5
mov_pp r1, -r0.w
mul oC0.xyz, r0, c6.z
texkill r1.xyzw
mov_pp oC0.w, c6.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[6], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[6].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
MAX R1.x, R0, c[6];
MAD R0.zw, fragment.texcoord[0].xyxy, c[4].xyxy, c[4];
TEX R0, R0.zwzw, texture[0], 2D;
MUL R1.xyz, R1.x, c[2];
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].x;
END
# 24 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad_pp r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c6, c6.y
dp3_pp r1.y, r0, r0
cmp r0.w, r0, c6.x, c6.y
add r0.w, r1.x, -r0
rsq_pp r1.y, r1.y
mul_pp r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.z, r0, r1
max r1.x, r0.z, c6
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.x, c2
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.z
texkill r0.xyzw
mov_pp oC0.w, c6.x
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.5, 0.31830987 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[6], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[6].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
DP3 R0.z, fragment.texcoord[5], fragment.texcoord[5];
MAX R2.x, R0, c[6];
RCP R0.y, fragment.texcoord[5].w;
MAD R0.xy, fragment.texcoord[5], R0.y, c[6].y;
TEX R0.w, R0, texture[1], 2D;
SLT R0.x, c[6], fragment.texcoord[5].z;
MUL R0.x, R0, R0.w;
TEX R1.w, R0.z, texture[2], 2D;
MUL R0.z, R0.x, R1.w;
MUL R1.xyz, R0.z, c[2];
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R2.x, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].z;
KIL -R0.w;
MOV result.color.w, c[6].x;
END
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c6, 0.00000000, 1.00000000, 0.50000000, 0.31830987
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c6, c6.y
dp3 r1.y, r0, r0
cmp r0.w, r0, c6.x, c6.y
add r0.w, r1.x, -r0
rsq r1.y, r1.y
mul r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
rcp r0.y, v3.w
mad r1.xy, v3, r0.y, c6.z
max r1.w, r0.x, c6.x
dp3 r0.x, v3, v3
texld r0.w, r1, s1
cmp r0.y, -v3.z, c6.x, c6
mul_pp r0.y, r0, r0.w
texld r0.x, r0.x, s2
mul_pp r0.z, r0.y, r0.x
mul r1.xyz, r0.z, c2
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.w
texkill r0.xyzw
mov_pp oC0.w, c6.x
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[6], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[6].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
MAX R1.w, R0.x, c[6].x;
DP3 R0.x, fragment.texcoord[5], fragment.texcoord[5];
TEX R2.w, R0.x, texture[1], 2D;
TEX R0.w, fragment.texcoord[5], texture[2], CUBE;
MUL R0.z, R2.w, R0.w;
MUL R1.xyz, R0.z, c[2];
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].x;
END
# 29 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c6, c6.y
dp3 r1.y, r0, r0
cmp r0.w, r0, c6.x, c6.y
add r0.w, r1.x, -r0
rsq r1.y, r1.y
mul r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
max r1.w, r0.x, c6.x
dp3 r0.x, v3, v3
texld r0.w, v3, s2
texld r0.x, r0.x, s1
mul r0.z, r0.x, r0.w
mul r1.xyz, r0.z, c2
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.z
texkill r0.xyzw
mov_pp oC0.w, c6.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[6], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[6].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
MAX R1.w, R0.x, c[6].x;
TEX R0.w, fragment.texcoord[5], texture[1], 2D;
MUL R1.xyz, R0.w, c[2];
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].x;
END
# 26 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xy
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad_pp r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c6, c6.y
dp3_pp r1.y, r0, r0
cmp r0.w, r0, c6.x, c6.y
add r0.w, r1.x, -r0
rsq_pp r1.y, r1.y
mul_pp r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
max r1.w, r0.x, c6.x
texld r0.w, v3, s1
mul r1.xyz, r0.w, c2
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.z
texkill r0.xyzw
mov_pp oC0.w, c6.x
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
Vector 6 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"3.0-!!ARBfp1.0
PARAM c[8] = { program.local[0..6],
		{ 0, 0.5, 1, 0.31830987 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[7], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[7].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
MAX R2.x, R0, c[7];
TXP R0.x, fragment.texcoord[6], texture[3], 2D;
RCP R0.y, fragment.texcoord[6].w;
MAD R0.z, -fragment.texcoord[6], R0.y, R0.x;
MOV R0.x, c[7].z;
CMP R0.x, R0.z, c[2], R0;
RCP R0.y, fragment.texcoord[5].w;
MAD R0.zw, fragment.texcoord[5].xyxy, R0.y, c[7].y;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R1.w, R0.y, texture[2], 2D;
TEX R0.w, R0.zwzw, texture[1], 2D;
SLT R0.y, c[7].x, fragment.texcoord[5].z;
MUL R0.y, R0, R0.w;
MUL R0.y, R0, R1.w;
MUL R0.z, R0.y, R0.x;
MUL R1.xyz, R0.z, c[3];
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R2.x, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[6];
SLT R0.w, R0, c[4].x;
MUL result.color.xyz, R0, c[7].w;
KIL -R0.w;
MOV result.color.w, c[7].x;
END
# 39 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
Vector 6 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c7, 0.00000000, 1.00000000, 0.50000000, 0.31830987
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c7, c7.y
dp3 r1.y, r0, r0
cmp r0.w, r0, c7.x, c7.y
add r0.w, r1.x, -r0
rsq r1.y, r1.y
mul r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
max r1.w, r0.x, c7.x
texldp r0.x, v4, s3
rcp r0.y, v4.w
mad r0.y, -v4.z, r0, r0.x
mov r0.z, c2.x
cmp r0.y, r0, c7, r0.z
rcp r0.x, v3.w
mad r1.xy, v3, r0.x, c7.z
dp3 r0.x, v3, v3
texld r0.w, r1, s1
cmp r0.z, -v3, c7.x, c7.y
mul_pp r0.z, r0, r0.w
texld r0.x, r0.x, s2
mul_pp r0.x, r0.z, r0
mul_pp r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c3
mad r0.xy, v0, c5, c5.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c4.x
cmp r0.x, r0.w, c7, c7.y
mul r1.xyz, r1, c6
mov_pp r0, -r0.x
mul oC0.xyz, r1, c7.w
texkill r0.xyzw
mov_pp oC0.w, c7.x
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
Vector 6 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"3.0-!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[8] = { program.local[0..6],
		{ 0, 0.5, 1, 0.31830987 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[7], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[7].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
MAX R2.x, R0, c[7];
MOV R0.x, c[7].z;
ADD R0.z, R0.x, -c[2].x;
TXP R0.x, fragment.texcoord[6], texture[3], SHADOW2D;
MAD R0.x, R0, R0.z, c[2];
RCP R0.y, fragment.texcoord[5].w;
MAD R0.zw, fragment.texcoord[5].xyxy, R0.y, c[7].y;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R1.w, R0.y, texture[2], 2D;
TEX R0.w, R0.zwzw, texture[1], 2D;
SLT R0.y, c[7].x, fragment.texcoord[5].z;
MUL R0.y, R0, R0.w;
MUL R0.y, R0, R1.w;
MUL R0.z, R0.y, R0.x;
MUL R1.xyz, R0.z, c[3];
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R2.x, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[6];
SLT R0.w, R0, c[4].x;
MUL result.color.xyz, R0, c[7].w;
KIL -R0.w;
MOV result.color.w, c[7].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
Vector 6 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c7, 0.00000000, 1.00000000, 0.50000000, 0.31830987
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c7, c7.y
dp3 r1.y, r0, r0
cmp r0.w, r0, c7.x, c7.y
add r0.w, r1.x, -r0
rsq r1.y, r1.y
mul r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
max r1.w, r0.x, c7.x
mov r0.x, c2
rcp r0.z, v3.w
mad r1.xy, v3, r0.z, c7.z
add r0.y, c7, -r0.x
texldp r0.x, v4, s3
mad r0.y, r0.x, r0, c2.x
dp3 r0.x, v3, v3
texld r0.w, r1, s1
cmp r0.z, -v3, c7.x, c7.y
mul_pp r0.z, r0, r0.w
texld r0.x, r0.x, s2
mul_pp r0.x, r0.z, r0
mul_pp r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c3
mad r0.xy, v0, c5, c5.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c4.x
cmp r0.x, r0.w, c7, c7.y
mul r1.xyz, r1, c6
mov_pp r0, -r0.x
mul oC0.xyz, r1, c7.w
texkill r0.xyzw
mov_pp oC0.w, c7.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[6], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[6].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
MAX R1.w, R0.x, c[6].x;
TXP R1.x, fragment.texcoord[5], texture[1], 2D;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.x, c[2];
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].x;
END
# 26 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad_pp r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c6, c6.y
dp3_pp r1.y, r0, r0
cmp r0.w, r0, c6.x, c6.y
add r0.w, r1.x, -r0
rsq_pp r1.y, r1.y
mul_pp r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
max r1.w, r0.x, c6.x
texldp r1.x, v3, s1
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.x, c2
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.z
texkill r0.xyzw
mov_pp oC0.w, c6.x
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 0.31830987 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[6], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[6].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
MAX R1.w, R0.x, c[6].x;
TXP R0.x, fragment.texcoord[6], texture[1], 2D;
TEX R0.w, fragment.texcoord[5], texture[2], 2D;
MUL R0.z, R0.w, R0.x;
MUL R1.xyz, R0.z, c[2];
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[5];
SLT R0.w, R0, c[3].x;
MUL result.color.xyz, R0, c[6].y;
KIL -R0.w;
MOV result.color.w, c[6].x;
END
# 28 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Float 3 [_Cutoff]
Vector 4 [_MainTex_ST]
Vector 5 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c6, 0.00000000, 1.00000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xy
dcl_texcoord6 v4
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad_pp r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c6, c6.y
dp3_pp r1.y, r0, r0
cmp r0.w, r0, c6.x, c6.y
add r0.w, r1.x, -r0
rsq_pp r1.y, r1.y
mul_pp r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
max r1.w, r0.x, c6.x
texldp r0.x, v4, s1
texld r0.w, v3, s2
mul r0.z, r0.w, r0.x
mul r1.xyz, r0.z, c2
mad r0.xy, v0, c4, c4.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c3.x
cmp r0.x, r0.w, c6, c6.y
mul r1.xyz, r1, c5
mov_pp r0, -r0.x
mul oC0.xyz, r1, c6.z
texkill r0.xyzw
mov_pp oC0.w, c6.x
"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTexture0] 2D 2
"3.0-!!ARBfp1.0
PARAM c[10] = { program.local[0..7],
		{ 0, 0.97000003, 1, 0.31830987 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 } };
TEMP R0;
TEMP R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], R0;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
SLT R1.x, c[8], R0.w;
DP3 R1.y, R0, R0;
SLT R0.w, R0, c[8].x;
ADD R0.w, R1.x, -R0;
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, R0;
MUL R0.xyz, fragment.texcoord[2], R0.w;
DP3 R0.x, R0, R1;
DP3 R0.y, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.x, R0.y;
MAX R1.w, R0.x, c[8].x;
TEX R0, fragment.texcoord[6], texture[1], CUBE;
DP4 R0.y, R0, c[9];
RCP R1.x, R1.x;
MUL R0.x, R1, c[2].w;
MAD R0.z, -R0.x, c[8].y, R0.y;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
MOV R0.x, c[8].z;
CMP R0.x, R0.z, c[3], R0;
TEX R0.w, R0.y, texture[2], 2D;
MUL R0.z, R0.w, R0.x;
MUL R1.xyz, R0.z, c[4];
MAD R0.xy, fragment.texcoord[0], c[6], c[6].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[7];
SLT R0.w, R0, c[5].x;
MUL result.color.xyz, R0, c[8].w;
KIL -R0.w;
MOV result.color.w, c[8].x;
END
# 37 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTexture0] 2D 2
"ps_3_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
def c8, 0.00000000, 1.00000000, 0.97000003, 0.31830987
def c9, 1.00000000, 0.00392157, 0.00001538, 0.00000006
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c8, c8.y
dp3 r1.y, r0, r0
cmp r0.w, r0, c8.x, c8.y
add r0.w, r1.x, -r0
rsq r1.y, r1.y
mul r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
dp3 r0.y, v4, v4
rsq r1.x, r0.y
max r1.w, r0.x, c8.x
texld r0, v4, s1
dp4 r0.y, r0, c9
rcp r1.x, r1.x
mul r0.x, r1, c2.w
mad r0.y, -r0.x, c8.z, r0
mov r0.z, c3.x
dp3 r0.x, v3, v3
cmp r0.y, r0, c8, r0.z
texld r0.x, r0.x, s2
mul r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c4
mad r0.xy, v0, c6, c6.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c5.x
cmp r0.x, r0.w, c8, c8.y
mul r1.xyz, r1, c7
mov_pp r0, -r0.x
mul oC0.xyz, r1, c8.w
texkill r0.xyzw
mov_pp oC0.w, c8.x
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"3.0-!!ARBfp1.0
PARAM c[10] = { program.local[0..7],
		{ 0, 0.97000003, 1, 0.31830987 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 } };
TEMP R0;
TEMP R1;
ADD R1.xyz, -fragment.texcoord[1], c[0];
DP3 R0.x, R1, R1;
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, R1;
DP3 R1.x, fragment.texcoord[2], R0;
SLT R1.y, c[8].x, R1.x;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
SLT R1.x, R1, c[8];
ADD R1.x, R1.y, -R1;
MUL R1.xyz, fragment.texcoord[2], R1.x;
MUL R0.xyz, R0.w, R0;
DP3 R0.x, R1, R0;
MAX R1.x, R0, c[8];
TEX R0, fragment.texcoord[6], texture[1], CUBE;
DP4 R0.x, R0, c[9];
DP3 R1.y, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.y, R1.y;
RCP R0.y, R1.y;
MUL R0.y, R0, c[2].w;
MAD R0.x, -R0.y, c[8].y, R0;
MOV R0.z, c[8];
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
CMP R0.x, R0, c[3], R0.z;
TEX R1.w, R0.y, texture[2], 2D;
TEX R0.w, fragment.texcoord[5], texture[3], CUBE;
MUL R0.y, R1.w, R0.w;
MUL R0.z, R0.y, R0.x;
MUL R1.yzw, R0.z, c[4].xxyz;
MAD R0.xy, fragment.texcoord[0], c[6], c[6].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.x, R1.yzww;
MUL R0.xyz, R1, R0;
MUL R1.xyz, R0, c[7];
SLT R0.x, R0.w, c[5];
MUL result.color.xyz, R1, c[8].w;
KIL -R0.x;
MOV result.color.w, c[8].x;
END
# 39 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"ps_3_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
dcl_cube s3
def c8, 0.00000000, 1.00000000, 0.97000003, 0.31830987
def c9, 1.00000000, 0.00392157, 0.00001538, 0.00000006
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
mad r0.xyz, -v1, c1.w, c1
cmp r1.x, -r0.w, c8, c8.y
dp3 r1.y, r0, r0
cmp r0.w, r0, c8.x, c8.y
add r0.w, r1.x, -r0
rsq r1.y, r1.y
mul r1.xyz, r1.y, r0
mul r0.xyz, v2, r0.w
dp3 r0.x, r0, r1
max r1.w, r0.x, c8.x
texld r0, v4, s1
dp4 r0.y, r0, c9
dp3 r1.x, v4, v4
rsq r1.x, r1.x
rcp r0.x, r1.x
mul r0.x, r0, c2.w
mad r0.x, -r0, c8.z, r0.y
mov r0.z, c3.x
cmp r0.y, r0.x, c8, r0.z
dp3 r0.x, v3, v3
texld r0.w, v3, s3
texld r0.x, r0.x, s2
mul r0.x, r0, r0.w
mul r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c4
mad r0.xy, v0, c6, c6.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c5.x
cmp r0.x, r0.w, c8, c8.y
mul r1.xyz, r1, c7
mov_pp r0, -r0.x
mul oC0.xyz, r1, c8.w
texkill r0.xyzw
mov_pp oC0.w, c8.x
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_ShadowOffsets0]
Vector 4 [_ShadowOffsets1]
Vector 5 [_ShadowOffsets2]
Vector 6 [_ShadowOffsets3]
Vector 7 [_LightColor0]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
Vector 10 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..10],
		{ 0, 0.5, 1, 0.25 },
		{ 0.31830987 } };
TEMP R0;
TEMP R1;
ADD R1.xyz, -fragment.texcoord[1], c[0];
DP3 R0.x, R1, R1;
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, R1;
DP3 R0.w, fragment.texcoord[2], R0;
RCP R1.w, fragment.texcoord[6].w;
SLT R1.y, c[11].x, R0.w;
SLT R1.x, R0.w, c[11];
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
ADD R1.x, R1.y, -R1;
MUL R1.xyz, fragment.texcoord[2], R1.x;
MUL R0.xyz, R0.w, R0;
DP3 R0.z, R1, R0;
MAD R0.xy, fragment.texcoord[6], R1.w, c[6];
TEX R0.x, R0, texture[3], 2D;
MAX R1.x, R0.z, c[11];
MAD R0.yz, fragment.texcoord[6].xxyw, R1.w, c[5].xxyw;
MOV R0.w, R0.x;
TEX R0.x, R0.yzzw, texture[3], 2D;
MAD R1.yz, fragment.texcoord[6].xxyw, R1.w, c[4].xxyw;
MOV R0.z, R0.x;
TEX R0.x, R1.yzzw, texture[3], 2D;
MAD R1.yz, fragment.texcoord[6].xxyw, R1.w, c[3].xxyw;
MOV R0.y, R0.x;
TEX R0.x, R1.yzzw, texture[3], 2D;
MOV R1.y, c[11].z;
MAD R0, -fragment.texcoord[6].z, R1.w, R0;
CMP R0, R0, c[2].x, R1.y;
DP4 R0.x, R0, c[11].w;
RCP R1.y, fragment.texcoord[5].w;
MAD R0.zw, fragment.texcoord[5].xyxy, R1.y, c[11].y;
TEX R1.w, R0.zwzw, texture[1], 2D;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R0.w, R0.y, texture[2], 2D;
SLT R0.y, c[11].x, fragment.texcoord[5].z;
MUL R0.y, R0, R1.w;
MUL R0.y, R0, R0.w;
MUL R0.z, R0.y, R0.x;
MUL R1.yzw, R0.z, c[7].xxyz;
MAD R0.xy, fragment.texcoord[0], c[9], c[9].zwzw;
TEX R0, R0, texture[0], 2D;
MUL R1.xyz, R1.x, R1.yzww;
MUL R0.xyz, R1, R0;
MUL R1.xyz, R0, c[10];
SLT R0.x, R0.w, c[8];
MUL result.color.xyz, R1, c[12].x;
KIL -R0.x;
MOV result.color.w, c[11].x;
END
# 50 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_ShadowOffsets0]
Vector 4 [_ShadowOffsets1]
Vector 5 [_ShadowOffsets2]
Vector 6 [_ShadowOffsets3]
Vector 7 [_LightColor0]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
Vector 10 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c11, 0.00000000, 1.00000000, 0.50000000, 0.25000000
def c12, 0.31830987, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.x, v2, r0
cmp r0.y, -r0.x, c11.x, c11
mad r1.xyz, -v1, c1.w, c1
dp3 r0.z, r1, r1
rsq r0.w, r0.z
mul r1.xyw, r0.w, r1.xyzz
cmp r0.x, r0, c11, c11.y
add r0.x, r0.y, -r0
mul r0.xyz, v2, r0.x
dp3 r0.z, r0, r1.xyww
rcp r1.z, v4.w
mad r0.xy, v4, r1.z, c6
texld r0.x, r0, s3
mad r1.xy, v4, r1.z, c5
mov r0.w, r0.x
texld r0.x, r1, s3
max r1.w, r0.z, c11.x
mad r1.xy, v4, r1.z, c4
mov r0.z, r0.x
texld r0.x, r1, s3
mad r1.xy, v4, r1.z, c3
mov r0.y, r0.x
texld r0.x, r1, s3
mov r1.x, c2
mad r0, -v4.z, r1.z, r0
cmp r0, r0, c11.y, r1.x
dp4_pp r0.y, r0, c11.w
rcp r1.x, v3.w
mad r1.xy, v3, r1.x, c11.z
dp3 r0.x, v3, v3
texld r0.w, r1, s1
cmp r0.z, -v3, c11.x, c11.y
mul_pp r0.z, r0, r0.w
texld r0.x, r0.x, s2
mul_pp r0.x, r0.z, r0
mul_pp r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c7
mad r0.xy, v0, c9, c9.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c8.x
cmp r0.x, r0.w, c11, c11.y
mul r1.xyz, r1, c10
mov_pp r0, -r0.x
mul oC0.xyz, r1, c12.x
texkill r0.xyzw
mov_pp oC0.w, c11.x
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_ShadowOffsets0]
Vector 4 [_ShadowOffsets1]
Vector 5 [_ShadowOffsets2]
Vector 6 [_ShadowOffsets3]
Vector 7 [_LightColor0]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
Vector 10 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"3.0-!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[13] = { program.local[0..10],
		{ 0, 0.5, 1, 0.25 },
		{ 0.31830987 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.x, fragment.texcoord[2], R0;
SLT R0.y, c[11].x, R0.x;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
RSQ R1.w, R0.w;
RCP R0.w, fragment.texcoord[6].w;
SLT R0.x, R0, c[11];
ADD R0.x, R0.y, -R0;
MUL R0.xyz, fragment.texcoord[2], R0.x;
MUL R1.xyz, R1.w, R1;
DP3 R0.y, R0, R1;
MAD R1.xyz, fragment.texcoord[6], R0.w, c[4];
TEX R1.x, R1, texture[3], SHADOW2D;
MAD R2.xyz, fragment.texcoord[6], R0.w, c[6];
TEX R0.x, R2, texture[3], SHADOW2D;
MOV R1.y, R1.x;
MAX R2.x, R0.y, c[11];
MOV R1.w, R0.x;
MAD R0.xyz, fragment.texcoord[6], R0.w, c[5];
TEX R0.x, R0, texture[3], SHADOW2D;
MOV R1.z, R0.x;
MAD R0.xyz, fragment.texcoord[6], R0.w, c[3];
MOV R1.x, c[11].z;
ADD R0.w, R1.x, -c[2].x;
TEX R1.x, R0, texture[3], SHADOW2D;
MAD R1, R1, R0.w, c[2].x;
RCP R0.x, fragment.texcoord[5].w;
MAD R0.xy, fragment.texcoord[5], R0.x, c[11].y;
TEX R0.w, R0, texture[1], 2D;
SLT R0.x, c[11], fragment.texcoord[5].z;
DP4 R1.x, R1, c[11].w;
DP3 R0.z, fragment.texcoord[5], fragment.texcoord[5];
MUL R0.x, R0, R0.w;
TEX R1.w, R0.z, texture[2], 2D;
MUL R0.x, R0, R1.w;
MUL R0.x, R0, R1;
MUL R1.xyz, R0.x, c[7];
MAD R0.zw, fragment.texcoord[0].xyxy, c[9].xyxy, c[9];
TEX R0, R0.zwzw, texture[0], 2D;
MUL R1.xyz, R2.x, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[10];
SLT R0.w, R0, c[8].x;
MUL result.color.xyz, R0, c[12].x;
KIL -R0.w;
MOV result.color.w, c[11].x;
END
# 50 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_ShadowOffsets0]
Vector 4 [_ShadowOffsets1]
Vector 5 [_ShadowOffsets2]
Vector 6 [_ShadowOffsets3]
Vector 7 [_LightColor0]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
Vector 10 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c11, 0.00000000, 1.00000000, 0.50000000, 0.25000000
def c12, 0.31830987, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.x, v2, r0
cmp r1.x, r0, c11, c11.y
cmp r0.w, -r0.x, c11.x, c11.y
add r0.w, r0, -r1.x
mad r0.xyz, -v1, c1.w, c1
mul r1.xyz, v2, r0.w
dp3 r1.w, r0, r0
rsq r1.w, r1.w
mul r2.xyz, r1.w, r0
rcp r0.w, v4.w
dp3 r1.x, r1, r2
mad r0.xyz, v4, r0.w, c6
texld r0.x, r0, s3
max r2.x, r1, c11
mad r1.xyz, v4, r0.w, c4
texld r1.x, r1, s3
mov_pp r1.w, r0.x
mad r0.xyz, v4, r0.w, c5
texld r0.x, r0, s3
mov_pp r1.z, r0.x
mov_pp r1.y, r1.x
mad r0.xyz, v4, r0.w, c3
mov r1.x, c2
add r0.w, c11.y, -r1.x
texld r1.x, r0, s3
mad r1, r1, r0.w, c2.x
dp4_pp r0.z, r1, c11.w
rcp r0.x, v3.w
mad r1.xy, v3, r0.x, c11.z
dp3 r0.x, v3, v3
texld r0.w, r1, s1
cmp r0.y, -v3.z, c11.x, c11
mul_pp r0.y, r0, r0.w
texld r0.x, r0.x, s2
mul_pp r0.x, r0.y, r0
mul_pp r0.z, r0.x, r0
mul r1.xyz, r0.z, c7
mad r0.xy, v0, c9, c9.zwzw
texld r0, r0, s0
mul r1.xyz, r2.x, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c8.x
cmp r0.x, r0.w, c11, c11.y
mul r1.xyz, r1, c10
mov_pp r0, -r0.x
mul oC0.xyz, r1, c12.x
texkill r0.xyzw
mov_pp oC0.w, c11.x
"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTexture0] 2D 2
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..7],
		{ 0, 0.97000003, 0.0078125, -0.0078125 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 },
		{ 0.25, 0.31830987 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.x, fragment.texcoord[2], R0;
SLT R0.y, c[8].x, R0.x;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.z, R1, R1;
RSQ R0.w, R0.z;
SLT R0.x, R0, c[8];
ADD R0.x, R0.y, -R0;
MUL R1.xyz, R0.w, R1;
MUL R0.xyz, fragment.texcoord[2], R0.x;
DP3 R1.x, R0, R1;
ADD R2.xyz, fragment.texcoord[6], c[8].zwww;
TEX R0, R2, texture[1], CUBE;
DP4 R2.w, R0, c[9];
MAX R3.x, R1, c[8];
ADD R0.xyz, fragment.texcoord[6], c[8].wzww;
TEX R0, R0, texture[1], CUBE;
DP4 R2.z, R0, c[9];
ADD R1.xyz, fragment.texcoord[6], c[8].wwzw;
TEX R1, R1, texture[1], CUBE;
DP4 R2.y, R1, c[9];
ADD R0.xyz, fragment.texcoord[6], c[8].z;
TEX R0, R0, texture[1], CUBE;
DP4 R2.x, R0, c[9];
DP3 R1.x, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.x, R1.x;
RCP R0.y, R1.x;
MUL R0.y, R0, c[2].w;
MOV R0.x, c[9];
MAD R1, -R0.y, c[8].y, R2;
CMP R1, R1, c[3].x, R0.x;
DP3 R0.x, fragment.texcoord[5], fragment.texcoord[5];
DP4 R0.y, R1, c[10].x;
TEX R0.w, R0.x, texture[2], 2D;
MUL R0.x, R0.w, R0.y;
MUL R1.xyz, R0.x, c[4];
MAD R0.zw, fragment.texcoord[0].xyxy, c[6].xyxy, c[6];
TEX R0, R0.zwzw, texture[0], 2D;
MUL R1.xyz, R3.x, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[7];
SLT R0.w, R0, c[5].x;
MUL result.color.xyz, R0, c[10].y;
KIL -R0.w;
MOV result.color.w, c[8].x;
END
# 48 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTexture0] 2D 2
"ps_3_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
def c8, 0.00000000, 1.00000000, 0.00781250, -0.00781250
def c9, 1.00000000, 0.00392157, 0.00001538, 0.00000006
def c10, 0.97000003, 0.25000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, v2, r0
cmp r1.x, -r0.w, c8, c8.y
mad r0.xyz, -v1, c1.w, c1
dp3 r1.y, r0, r0
rsq r1.w, r1.y
mul r2.xyz, r1.w, r0
cmp r0.w, r0, c8.x, c8.y
add r0.w, r1.x, -r0
mul r1.xyz, v2, r0.w
dp3 r1.x, r1, r2
max r3.x, r1, c8
add r0.xyz, v4, c8.zwww
texld r0, r0, s1
dp4 r2.w, r0, c9
add r0.xyz, v4, c8.wzww
texld r0, r0, s1
dp4 r2.z, r0, c9
add r1.xyz, v4, c8.wwzw
texld r1, r1, s1
dp4 r2.y, r1, c9
add r0.xyz, v4, c8.z
texld r0, r0, s1
dp3 r1.x, v4, v4
rsq r1.x, r1.x
dp4 r2.x, r0, c9
rcp r0.x, r1.x
mul r0.x, r0, c2.w
mad r0, -r0.x, c10.x, r2
mov r1.x, c3
cmp r1, r0, c8.y, r1.x
dp3 r0.x, v3, v3
dp4_pp r0.y, r1, c10.y
texld r0.x, r0.x, s2
mul r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c4
mad r0.xy, v0, c6, c6.zwzw
texld r0, r0, s0
mul r1.xyz, r3.x, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c5.x
cmp r0.x, r0.w, c8, c8.y
mul r1.xyz, r1, c7
mov_pp r0, -r0.x
mul oC0.xyz, r1, c10.z
texkill r0.xyzw
mov_pp oC0.w, c8.x
"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..7],
		{ 0, 0.97000003, 0.0078125, -0.0078125 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 },
		{ 0.25, 0.31830987 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.x, fragment.texcoord[2], R0;
SLT R0.y, c[8].x, R0.x;
SLT R0.x, R0, c[8];
ADD R0.x, R0.y, -R0;
MAD R2.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.y, R2, R2;
RSQ R0.w, R0.y;
MUL R1.xyz, fragment.texcoord[2], R0.x;
MUL R2.xyz, R0.w, R2;
DP3 R3.x, R1, R2;
ADD R0.xyz, fragment.texcoord[6], c[8].zwww;
TEX R0, R0, texture[1], CUBE;
DP4 R2.w, R0, c[9];
ADD R0.xyz, fragment.texcoord[6], c[8].wzww;
TEX R0, R0, texture[1], CUBE;
DP4 R2.z, R0, c[9];
ADD R1.xyz, fragment.texcoord[6], c[8].wwzw;
TEX R1, R1, texture[1], CUBE;
DP4 R2.y, R1, c[9];
ADD R0.xyz, fragment.texcoord[6], c[8].z;
TEX R0, R0, texture[1], CUBE;
DP4 R2.x, R0, c[9];
DP3 R1.x, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.x, R1.x;
RCP R0.y, R1.x;
MUL R0.y, R0, c[2].w;
MAD R1, -R0.y, c[8].y, R2;
MOV R0.x, c[9];
CMP R0, R1, c[3].x, R0.x;
DP4 R0.y, R0, c[10].x;
DP3 R0.x, fragment.texcoord[5], fragment.texcoord[5];
TEX R0.w, fragment.texcoord[5], texture[3], CUBE;
TEX R1.w, R0.x, texture[2], 2D;
MUL R0.x, R1.w, R0.w;
MUL R0.x, R0, R0.y;
MUL R1.xyz, R0.x, c[4];
MAX R2.x, R3, c[8];
MAD R0.zw, fragment.texcoord[0].xyxy, c[6].xyxy, c[6];
TEX R0, R0.zwzw, texture[0], 2D;
MUL R1.xyz, R2.x, R1;
MUL R0.xyz, R1, R0;
MUL R0.xyz, R0, c[7];
SLT R0.w, R0, c[5].x;
MUL result.color.xyz, R0, c[10].y;
KIL -R0.w;
MOV result.color.w, c[8].x;
END
# 50 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Float 5 [_Cutoff]
Vector 6 [_MainTex_ST]
Vector 7 [_MainColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] CUBE 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"ps_3_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
dcl_cube s3
def c8, 0.00000000, 1.00000000, 0.00781250, -0.00781250
def c9, 1.00000000, 0.00392157, 0.00001538, 0.00000006
def c10, 0.97000003, 0.25000000, 0.31830987, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.x, v2, r0
cmp r0.y, -r0.x, c8.x, c8
cmp r0.x, r0, c8, c8.y
add r0.x, r0.y, -r0
mad r2.xyz, -v1, c1.w, c1
dp3 r0.y, r2, r2
rsq r0.w, r0.y
mul r1.xyz, v2, r0.x
mul r2.xyz, r0.w, r2
dp3 r3.x, r1, r2
add r0.xyz, v4, c8.zwww
texld r0, r0, s1
dp4 r2.w, r0, c9
add r0.xyz, v4, c8.wzww
texld r0, r0, s1
dp4 r2.z, r0, c9
add r1.xyz, v4, c8.wwzw
texld r1, r1, s1
dp4 r2.y, r1, c9
add r0.xyz, v4, c8.z
texld r0, r0, s1
dp3 r1.x, v4, v4
rsq r1.x, r1.x
dp4 r2.x, r0, c9
rcp r0.x, r1.x
mul r0.x, r0, c2.w
mov r1.x, c3
mad r0, -r0.x, c10.x, r2
cmp r0, r0, c8.y, r1.x
dp4_pp r0.y, r0, c10.y
dp3 r0.x, v3, v3
texld r0.w, v3, s3
texld r0.x, r0.x, s2
mul r0.x, r0, r0.w
mul r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c4
max r1.w, r3.x, c8.x
mad r0.xy, v0, c6, c6.zwzw
texld r0, r0, s0
mul r1.xyz, r1.w, r1
mul r1.xyz, r0, r1
add r0.w, r0, -c5.x
cmp r0.x, r0.w, c8, c8.y
mul r1.xyz, r1, c7
mov_pp r0, -r0.x
mul oC0.xyz, r1, c10.z
texkill r0.xyzw
mov_pp oC0.w, c8.x
"
}
}
 }
 Pass {
  Name "SHADOWCOLLECTOR"
  Tags { "LIGHTMODE"="SHADOWCOLLECTOR" "QUEUE"="AlphaTest" "RenderType"="TransparentCutout" }
  Cull Off
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[29] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..28] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MOV result.texcoord[5].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [unity_World2Shadow0]
Matrix 12 [unity_World2Shadow1]
Matrix 16 [unity_World2Shadow2]
Matrix 20 [unity_World2Shadow3]
Matrix 24 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_position0 v0
dcl_texcoord0 v1
dp4 r0.w, v0, c2
dp4 r1.w, v0, c27
dp4 r0.z, v0, c26
dp4 r0.x, v0, c24
dp4 r0.y, v0, c25
mov r1.xyz, r0
mov r0.w, -r0
dp4 o1.z, r1, c10
dp4 o1.y, r1, c9
dp4 o1.x, r1, c8
dp4 o2.z, r1, c14
dp4 o2.y, r1, c13
dp4 o2.x, r1, c12
dp4 o3.z, r1, c18
dp4 o3.y, r1, c17
dp4 o3.x, r1, c16
dp4 o4.z, r1, c22
dp4 o4.y, r1, c21
dp4 o4.x, r1, c20
mov o5, r0
mov o6.xy, v1
dp4 o0.w, v0, c7
dp4 o0.z, v0, c6
dp4 o0.y, v0, c5
dp4 o0.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[29] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..28] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MOV result.texcoord[5].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [unity_World2Shadow0]
Matrix 12 [unity_World2Shadow1]
Matrix 16 [unity_World2Shadow2]
Matrix 20 [unity_World2Shadow3]
Matrix 24 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_position0 v0
dcl_texcoord0 v1
dp4 r0.w, v0, c2
dp4 r1.w, v0, c27
dp4 r0.z, v0, c26
dp4 r0.x, v0, c24
dp4 r0.y, v0, c25
mov r1.xyz, r0
mov r0.w, -r0
dp4 o1.z, r1, c10
dp4 o1.y, r1, c9
dp4 o1.x, r1, c8
dp4 o2.z, r1, c14
dp4 o2.y, r1, c13
dp4 o2.x, r1, c12
dp4 o3.z, r1, c18
dp4 o3.y, r1, c17
dp4 o3.x, r1, c16
dp4 o4.z, r1, c22
dp4 o4.y, r1, c21
dp4 o4.x, r1, c20
mov o5, r0
mov o6.xy, v1
dp4 o0.w, v0, c7
dp4 o0.z, v0, c6
dp4 o0.y, v0, c5
dp4 o0.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[29] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..28] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MOV result.texcoord[5].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [unity_World2Shadow0]
Matrix 12 [unity_World2Shadow1]
Matrix 16 [unity_World2Shadow2]
Matrix 20 [unity_World2Shadow3]
Matrix 24 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_position0 v0
dcl_texcoord0 v1
dp4 r0.w, v0, c2
dp4 r1.w, v0, c27
dp4 r0.z, v0, c26
dp4 r0.x, v0, c24
dp4 r0.y, v0, c25
mov r1.xyz, r0
mov r0.w, -r0
dp4 o1.z, r1, c10
dp4 o1.y, r1, c9
dp4 o1.x, r1, c8
dp4 o2.z, r1, c14
dp4 o2.y, r1, c13
dp4 o2.x, r1, c12
dp4 o3.z, r1, c18
dp4 o3.y, r1, c17
dp4 o3.x, r1, c16
dp4 o4.z, r1, c22
dp4 o4.y, r1, c21
dp4 o4.x, r1, c20
mov o5, r0
mov o6.xy, v1
dp4 o0.w, v0, c7
dp4 o0.z, v0, c6
dp4 o0.y, v0, c5
dp4 o0.x, v0, c4
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 9 [unity_World2Shadow0]
Matrix 13 [unity_World2Shadow1]
Matrix 17 [unity_World2Shadow2]
Matrix 21 [unity_World2Shadow3]
Matrix 25 [_Object2World]
"3.0-!!ARBvp1.0
PARAM c[29] = { program.local[0],
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..28] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[3];
DP4 R1.w, vertex.position, c[28];
DP4 R0.z, vertex.position, c[27];
DP4 R0.x, vertex.position, c[25];
DP4 R0.y, vertex.position, c[26];
MOV R1.xyz, R0;
MOV R0.w, -R0;
DP4 result.texcoord[0].z, R1, c[11];
DP4 result.texcoord[0].y, R1, c[10];
DP4 result.texcoord[0].x, R1, c[9];
DP4 result.texcoord[1].z, R1, c[15];
DP4 result.texcoord[1].y, R1, c[14];
DP4 result.texcoord[1].x, R1, c[13];
DP4 result.texcoord[2].z, R1, c[19];
DP4 result.texcoord[2].y, R1, c[18];
DP4 result.texcoord[2].x, R1, c[17];
DP4 result.texcoord[3].z, R1, c[23];
DP4 result.texcoord[3].y, R1, c[22];
DP4 result.texcoord[3].x, R1, c[21];
MOV result.texcoord[4], R0;
MOV result.texcoord[5].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[8];
DP4 result.position.z, vertex.position, c[7];
DP4 result.position.y, vertex.position, c[6];
DP4 result.position.x, vertex.position, c[5];
END
# 25 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [unity_World2Shadow0]
Matrix 12 [unity_World2Shadow1]
Matrix 16 [unity_World2Shadow2]
Matrix 20 [unity_World2Shadow3]
Matrix 24 [_Object2World]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_position0 v0
dcl_texcoord0 v1
dp4 r0.w, v0, c2
dp4 r1.w, v0, c27
dp4 r0.z, v0, c26
dp4 r0.x, v0, c24
dp4 r0.y, v0, c25
mov r1.xyz, r0
mov r0.w, -r0
dp4 o1.z, r1, c10
dp4 o1.y, r1, c9
dp4 o1.x, r1, c8
dp4 o2.z, r1, c14
dp4 o2.y, r1, c13
dp4 o2.x, r1, c12
dp4 o3.z, r1, c18
dp4 o3.y, r1, c17
dp4 o3.x, r1, c16
dp4 o4.z, r1, c22
dp4 o4.y, r1, c21
dp4 o4.x, r1, c20
mov o5, r0
mov o6.xy, v1
dp4 o0.w, v0, c7
dp4 o0.z, v0, c6
dp4 o0.y, v0, c5
dp4 o0.x, v0, c4
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightSplitsNear]
Vector 2 [_LightSplitsFar]
Vector 3 [_LightShadowData]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[7] = { program.local[0..5],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
SLT R1, fragment.texcoord[4].w, c[2];
SGE R0, fragment.texcoord[4].w, c[1];
MUL R0, R0, R1;
MUL R1.xyz, R0.y, fragment.texcoord[1];
MAD R1.xyz, R0.x, fragment.texcoord[0], R1;
MAD R0.xyz, R0.z, fragment.texcoord[2], R1;
MAD R0.xyz, fragment.texcoord[3], R0.w, R0;
TEX R0.x, R0, texture[1], 2D;
ADD R0.y, R0.x, -R0.z;
MOV R0.x, c[6];
CMP R0.x, R0.y, c[3], R0;
MAD_SAT R0.z, fragment.texcoord[4].w, c[3], c[3].w;
ADD_SAT result.color.x, R0, R0.z;
MAD R0.zw, fragment.texcoord[5].xyxy, c[5].xyxy, c[5];
TEX R0.w, R0.zwzw, texture[0], 2D;
SLT R1.x, R0.w, c[4];
MUL R0.x, -fragment.texcoord[4].w, c[0].w;
ADD R0.x, R0, c[6];
MUL R0.xy, R0.x, c[6];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[6].z, R0.z;
KIL -R1.x;
MOV result.color.zw, R0.xyxy;
MOV result.color.y, c[6].x;
END
# 25 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightSplitsNear]
Vector 2 [_LightSplitsFar]
Vector 3 [_LightShadowData]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl_texcoord0 v0.xyz
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyzw
dcl_texcoord5 v5.xy
add r1, v4.w, -c2
add r0, v4.w, -c1
cmp r1, r1, c6.x, c6.y
cmp r0, r0, c6.y, c6.x
mul r0, r0, r1
mul r1.xyz, r0.y, v1
mad r1.xyz, r0.x, v0, r1
mad r0.xyz, r0.z, v2, r1
mad r0.xyz, v3, r0.w, r0
texld r0.x, r0, s1
add r0.x, r0, -r0.z
mov r0.y, c3.x
cmp r0.z, r0.x, c6.y, r0.y
mad_sat r0.w, v4, c3.z, c3
mad r0.xy, v5, c5, c5.zwzw
add_sat oC0.x, r0.z, r0.w
texld r0.w, r0, s0
add r0.x, r0.w, -c4
mul r0.y, -v4.w, c0.w
add r0.y, r0, c6
mul r1.xy, r0.y, c6.yzzw
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
frc r1.xy, r1
texkill r0.xyzw
mov r0.y, r1
mad r0.x, -r1.y, c6.w, r1
mov oC0.zw, r0.xyxy
mov oC0.y, c6
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightSplitsNear]
Vector 2 [_LightSplitsFar]
Vector 3 [_LightShadowData]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fragment_program_shadow;
PARAM c[7] = { program.local[0..5],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
SLT R1, fragment.texcoord[4].w, c[2];
SGE R0, fragment.texcoord[4].w, c[1];
MUL R0, R0, R1;
MUL R1.xyz, R0.y, fragment.texcoord[1];
MAD R1.xyz, R0.x, fragment.texcoord[0], R1;
MAD R0.xyz, R0.z, fragment.texcoord[2], R1;
MAD R1.xyz, fragment.texcoord[3], R0.w, R0;
MOV R0.y, c[6].x;
TEX R0.x, R1, texture[1], SHADOW2D;
ADD R0.y, R0, -c[3].x;
MAD R0.x, R0, R0.y, c[3];
MAD_SAT R0.z, fragment.texcoord[4].w, c[3], c[3].w;
ADD_SAT result.color.x, R0, R0.z;
MAD R0.zw, fragment.texcoord[5].xyxy, c[5].xyxy, c[5];
TEX R0.w, R0.zwzw, texture[0], 2D;
SLT R1.x, R0.w, c[4];
MUL R0.x, -fragment.texcoord[4].w, c[0].w;
ADD R0.x, R0, c[6];
MUL R0.xy, R0.x, c[6];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[6].z, R0.z;
KIL -R1.x;
MOV result.color.zw, R0.xyxy;
MOV result.color.y, c[6].x;
END
# 25 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [_LightSplitsNear]
Vector 2 [_LightSplitsFar]
Vector 3 [_LightShadowData]
Float 4 [_Cutoff]
Vector 5 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl_texcoord0 v0.xyz
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyzw
dcl_texcoord5 v5.xy
add r1, v4.w, -c2
add r0, v4.w, -c1
cmp r1, r1, c6.x, c6.y
cmp r0, r0, c6.y, c6.x
mul r0, r0, r1
mul r1.xyz, r0.y, v1
mad r1.xyz, r0.x, v0, r1
mad r0.xyz, r0.z, v2, r1
mad r0.xyz, v3, r0.w, r0
mov r1.x, c3
texld r0.x, r0, s1
add r0.w, c6.y, -r1.x
mad r0.z, r0.x, r0.w, c3.x
mad_sat r0.w, v4, c3.z, c3
mad r0.xy, v5, c5, c5.zwzw
add_sat oC0.x, r0.z, r0.w
texld r0.w, r0, s0
add r0.x, r0.w, -c4
mul r0.y, -v4.w, c0.w
add r0.y, r0, c6
mul r1.xy, r0.y, c6.yzzw
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
frc r1.xy, r1
texkill r0.xyzw
mov r0.y, r1
mad r0.x, -r1.y, c6.w, r1
mov oC0.zw, r0.xyxy
mov oC0.y, c6
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [unity_ShadowSplitSpheres0]
Vector 2 [unity_ShadowSplitSpheres1]
Vector 3 [unity_ShadowSplitSpheres2]
Vector 4 [unity_ShadowSplitSpheres3]
Vector 5 [unity_ShadowSplitSqRadii]
Vector 6 [_LightShadowData]
Vector 7 [unity_ShadowFadeCenterAndType]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[11] = { program.local[0..9],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, fragment.texcoord[4], -c[1];
ADD R2.xyz, fragment.texcoord[4], -c[4];
DP3 R0.x, R0, R0;
ADD R1.xyz, fragment.texcoord[4], -c[2];
DP3 R0.y, R1, R1;
ADD R1.xyz, fragment.texcoord[4], -c[3];
DP3 R0.w, R2, R2;
DP3 R0.z, R1, R1;
SLT R1, R0, c[5];
ADD_SAT R2.xyz, R1.yzww, -R1;
MUL R0.xyz, R2.x, fragment.texcoord[1];
MAD R0.xyz, R1.x, fragment.texcoord[0], R0;
ADD R1.xyz, -fragment.texcoord[4], c[7];
DP3 R0.w, R1, R1;
MAD R0.xyz, R2.y, fragment.texcoord[2], R0;
MAD R0.xyz, fragment.texcoord[3], R2.z, R0;
TEX R0.x, R0, texture[1], 2D;
ADD R0.y, R0.x, -R0.z;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MOV R0.x, c[10];
CMP R0.x, R0.y, c[6], R0;
MAD_SAT R0.z, R0, c[6], c[6].w;
ADD_SAT result.color.x, R0, R0.z;
MAD R0.zw, fragment.texcoord[5].xyxy, c[9].xyxy, c[9];
TEX R0.w, R0.zwzw, texture[0], 2D;
SLT R1.x, R0.w, c[8];
MUL R0.x, -fragment.texcoord[4].w, c[0].w;
ADD R0.x, R0, c[10];
MUL R0.xy, R0.x, c[10];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[10].z, R0.z;
KIL -R1.x;
MOV result.color.zw, R0.xyxy;
MOV result.color.y, c[10].x;
END
# 36 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NONATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [unity_ShadowSplitSpheres0]
Vector 2 [unity_ShadowSplitSpheres1]
Vector 3 [unity_ShadowSplitSpheres2]
Vector 4 [unity_ShadowSplitSpheres3]
Vector 5 [unity_ShadowSplitSqRadii]
Vector 6 [_LightShadowData]
Vector 7 [unity_ShadowFadeCenterAndType]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c10, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl_texcoord0 v0.xyz
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
add r0.xyz, v4, -c1
add r2.xyz, v4, -c4
dp3 r0.x, r0, r0
add r1.xyz, v4, -c2
dp3 r0.y, r1, r1
add r1.xyz, v4, -c3
dp3 r0.w, r2, r2
dp3 r0.z, r1, r1
add r0, r0, -c5
cmp r2, r0, c10.x, c10.y
add_sat r0.xyz, r2.yzww, -r2
mul r1.xyz, r0.x, v1
mad r1.xyz, r2.x, v0, r1
mad r1.xyz, r0.y, v2, r1
mad r0.xyz, v3, r0.z, r1
texld r0.x, r0, s1
add r1.xyz, -v4, c7
add r0.x, r0, -r0.z
dp3 r0.y, r1, r1
rsq r0.z, r0.y
rcp r0.w, r0.z
mov r0.y, c6.x
cmp r0.z, r0.x, c10.y, r0.y
mad_sat r0.w, r0, c6.z, c6
mad r0.xy, v5, c9, c9.zwzw
add_sat oC0.x, r0.z, r0.w
texld r0.w, r0, s0
add r0.x, r0.w, -c8
mul r0.y, -v4.w, c0.w
add r0.y, r0, c10
mul r1.xy, r0.y, c10.yzzw
cmp r0.x, r0, c10, c10.y
mov_pp r0, -r0.x
frc r1.xy, r1
texkill r0.xyzw
mov r0.y, r1
mad r0.x, -r1.y, c10.w, r1
mov oC0.zw, r0.xyxy
mov oC0.y, c10
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [unity_ShadowSplitSpheres0]
Vector 2 [unity_ShadowSplitSpheres1]
Vector 3 [unity_ShadowSplitSpheres2]
Vector 4 [unity_ShadowSplitSpheres3]
Vector 5 [unity_ShadowSplitSqRadii]
Vector 6 [_LightShadowData]
Vector 7 [unity_ShadowFadeCenterAndType]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
OPTION ARB_fragment_program_shadow;
PARAM c[11] = { program.local[0..9],
		{ 1, 255, 0.0039215689 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, fragment.texcoord[4], -c[1];
ADD R2.xyz, fragment.texcoord[4], -c[4];
DP3 R0.x, R0, R0;
ADD R1.xyz, fragment.texcoord[4], -c[2];
DP3 R0.y, R1, R1;
ADD R1.xyz, fragment.texcoord[4], -c[3];
DP3 R0.w, R2, R2;
DP3 R0.z, R1, R1;
SLT R1, R0, c[5];
ADD_SAT R2.xyz, R1.yzww, -R1;
MUL R0.xyz, R2.x, fragment.texcoord[1];
MAD R0.xyz, R1.x, fragment.texcoord[0], R0;
ADD R1.xyz, -fragment.texcoord[4], c[7];
MAD R0.xyz, R2.y, fragment.texcoord[2], R0;
MAD R0.xyz, fragment.texcoord[3], R2.z, R0;
TEX R0.x, R0, texture[1], SHADOW2D;
DP3 R0.w, R1, R1;
RSQ R0.z, R0.w;
MOV R0.y, c[10].x;
ADD R0.y, R0, -c[6].x;
RCP R0.z, R0.z;
MAD R0.x, R0, R0.y, c[6];
MAD_SAT R0.z, R0, c[6], c[6].w;
ADD_SAT result.color.x, R0, R0.z;
MAD R0.zw, fragment.texcoord[5].xyxy, c[9].xyxy, c[9];
TEX R0.w, R0.zwzw, texture[0], 2D;
SLT R1.x, R0.w, c[8];
MUL R0.x, -fragment.texcoord[4].w, c[0].w;
ADD R0.x, R0, c[10];
MUL R0.xy, R0.x, c[10];
FRC R0.zw, R0.xyxy;
MOV R0.y, R0.w;
MAD R0.x, -R0.w, c[10].z, R0.z;
KIL -R1.x;
MOV result.color.zw, R0.xyxy;
MOV result.color.y, c[10].x;
END
# 36 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_SPLIT_SPHERES" "SHADOWS_NATIVE" }
Vector 0 [_ProjectionParams]
Vector 1 [unity_ShadowSplitSpheres0]
Vector 2 [unity_ShadowSplitSpheres1]
Vector 3 [unity_ShadowSplitSpheres2]
Vector 4 [unity_ShadowSplitSpheres3]
Vector 5 [unity_ShadowSplitSqRadii]
Vector 6 [_LightShadowData]
Vector 7 [unity_ShadowFadeCenterAndType]
Float 8 [_Cutoff]
Vector 9 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c10, 0.00000000, 1.00000000, 255.00000000, 0.00392157
dcl_texcoord0 v0.xyz
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
add r0.xyz, v4, -c1
add r2.xyz, v4, -c4
dp3 r0.x, r0, r0
add r1.xyz, v4, -c2
dp3 r0.y, r1, r1
add r1.xyz, v4, -c3
dp3 r0.w, r2, r2
dp3 r0.z, r1, r1
add r0, r0, -c5
cmp r2, r0, c10.x, c10.y
add_sat r0.xyz, r2.yzww, -r2
mul r1.xyz, r0.x, v1
mad r1.xyz, r2.x, v0, r1
mad r1.xyz, r0.y, v2, r1
mad r0.xyz, v3, r0.z, r1
texld r0.x, r0, s1
add r1.xyz, -v4, c7
dp3 r0.z, r1, r1
rsq r0.z, r0.z
rcp r0.w, r0.z
mov r0.y, c6.x
add r0.y, c10, -r0
mad r0.z, r0.x, r0.y, c6.x
mad_sat r0.w, r0, c6.z, c6
mad r0.xy, v5, c9, c9.zwzw
add_sat oC0.x, r0.z, r0.w
texld r0.w, r0, s0
add r0.x, r0.w, -c8
mul r0.y, -v4.w, c0.w
add r0.y, r0, c10
mul r1.xy, r0.y, c10.yzzw
cmp r0.x, r0, c10, c10.y
mov_pp r0, -r0.x
frc r1.xy, r1
texkill r0.xyzw
mov r0.y, r1
mad r0.x, -r1.y, c10.w, r1
mov oC0.zw, r0.xyxy
mov oC0.y, c10
"
}
}
 }
 Pass {
  Name "SHADOWCASTER"
  Tags { "LIGHTMODE"="SHADOWCASTER" "SHADOWSUPPORT"="true" "QUEUE"="AlphaTest" "RenderType"="TransparentCutout" }
  Cull Off
  Fog { Mode Off }
  Offset 1, 1
Program "vp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Vector 5 [unity_LightShadowBias]
"3.0-!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
TEMP R0;
DP4 R0.x, vertex.position, c[4];
DP4 R0.y, vertex.position, c[3];
ADD R0.y, R0, c[5].x;
MAX R0.z, R0.y, -R0.x;
ADD R0.z, R0, -R0.y;
MAD result.position.z, R0, c[5].y, R0.y;
MOV result.texcoord[1].xy, vertex.texcoord[0];
MOV result.position.w, R0.x;
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 10 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [unity_LightShadowBias]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
dp4 r0.x, v0, c2
add r0.x, r0, c4
max r0.y, r0.x, c5.x
add r0.y, r0, -r0.x
mad r0.z, r0.y, c4.y, r0.x
dp4 r0.w, v0, c3
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mov o0, r0
mov o1, r0
mov o2.xy, v1
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_LightPositionRange]
"3.0-!!ARBvp1.0
PARAM c[10] = { program.local[0],
		state.matrix.mvp,
		program.local[5..9] };
TEMP R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[0].xyz, R0, -c[9];
MOV result.texcoord[1].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_LightPositionRange]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add o1.xyz, r0, -c8
mov o2.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SHADOWS_DEPTH" }
Float 0 [_Cutoff]
Vector 1 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 0 } };
TEMP R0;
MAD R0.xy, fragment.texcoord[1], c[1], c[1].zwzw;
TEX R0.w, R0, texture[0], 2D;
SLT R0.x, R0.w, c[0];
MOV result.color, c[2].x;
KIL -R0.x;
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_DEPTH" }
Float 0 [_Cutoff]
Vector 1 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c2, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xyzw
dcl_texcoord1 v1.xy
mad r0.xy, v1, c1, c1.zwzw
texld r0.w, r0, s0
add r0.x, r0.w, -c0
cmp r0.x, r0, c2, c2.y
mov_pp r0, -r0.x
rcp r1.x, v0.w
texkill r0.xyzw
mul oC0, v0.z, r1.x
"
}
SubProgram "opengl " {
Keywords { "SHADOWS_CUBE" }
Vector 0 [_LightPositionRange]
Float 1 [_Cutoff]
Vector 2 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..2],
		{ 1, 255, 65025, 16581375 },
		{ 0.99900001, 0.0039215689 } };
TEMP R0;
TEMP R1;
MAD R1.xy, fragment.texcoord[1], c[2], c[2].zwzw;
DP3 R0.x, fragment.texcoord[0], fragment.texcoord[0];
RSQ R0.x, R0.x;
RCP R0.x, R0.x;
MUL R0.x, R0, c[0].w;
MIN R0.x, R0, c[4];
MUL R0, R0.x, c[3];
TEX R1.w, R1, texture[0], 2D;
FRC R0, R0;
SLT R1.x, R1.w, c[1];
MAD result.color, -R0.yzww, c[4].y, R0;
KIL -R1.x;
END
# 12 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SHADOWS_CUBE" }
Vector 0 [_LightPositionRange]
Float 1 [_Cutoff]
Vector 2 [_MainTex_ST]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c3, 0.00000000, 1.00000000, 0.99900001, 0.00392157
def c4, 1.00000000, 255.00000000, 65025.00000000, 16581375.00000000
dcl_texcoord0 v0.xyz
dcl_texcoord1 v1.xy
dp3 r0.x, v0, v0
rsq r0.z, r0.x
mad r0.xy, v1, c2, c2.zwzw
texld r0.w, r0, s0
rcp r0.z, r0.z
mul r0.y, r0.z, c0.w
add r0.x, r0.w, -c1
min r0.y, r0, c3.z
mul r1, r0.y, c4
cmp r0.x, r0, c3, c3.y
mov_pp r0, -r0.x
frc r1, r1
texkill r0.xyzw
mad oC0, -r1.yzww, c3.w, r1
"
}
}
 }
}
Fallback "Diffuse"
}