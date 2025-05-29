ÔíShader "Hidden/Shader Forge/Diffuse_Color_Mask" {
Properties {
 _Diffus ("Diffus", 2D) = "white" {}
 _Color ("Color", Color) = (1,0,0,1)
 _Mask ("Mask", 2D) = "bump" {}
 _Blend ("Blend", Float) = 0.7
 _Specular ("Specular", Float) = 0.8
}
SubShader { 
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "PREPASSBASE"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
"3.0-!!ARBvp1.0
PARAM c[13] = { { 0 },
		state.matrix.mvp,
		program.local[5..12] };
TEMP R0;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD result.texcoord[1].xyz, R0, c[0].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[0].w, vertex.position, c[8];
DP4 result.texcoord[0].z, vertex.position, c[7];
DP4 result.texcoord[0].y, vertex.position, c[6];
DP4 result.texcoord[0].x, vertex.position, c[5];
END
# 12 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c12, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add o2.xyz, r0, c12.x
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
dp4 o1.w, v0, c7
dp4 o1.z, v0, c6
dp4 o1.y, v0, c5
dp4 o1.x, v0, c4
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "normal" Normal
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedkapihgpikbiolldfoakdecgifmdillmpabaaaaaaoiacaaaaadaaaaaa
cmaaaaaahmaaaaaaomaaaaaaejfdeheoeiaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaafaepfdejfeejepeoaaeoepfcenebemaaepfdeheo
giaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaafmaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcpeabaaaaeaaaabaahnaaaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
abaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaaaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pccabaaaabaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaabaaaaaaibccabaaaacaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaa
baaaaaaabaaaaaaicccabaaaacaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaa
bbaaaaaabaaaaaaieccabaaaacaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaa
bcaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"3.0-!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 0.5 } };
TEMP R0;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD result.color.xyz, R0, c[1].x, c[1].x;
MOV result.color.w, c[1].x;
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
"ps_3_0
def c0, 0.50000000, 0, 0, 0
dcl_texcoord1 v1.xyz
dp3 r0.x, v1, v1
rsq r0.x, r0.x
mul r0.xyz, r0.x, v1
mad oC0.xyz, r0, c0.x, c0.x
mov_pp oC0.w, c0.x
"
}
SubProgram "d3d11 " {
"ps_4_0
eefiecedjgeakidckpjkcfnpakecpjanhedacnbhabaaaaaakaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmiaaaaaaeaaaaaaadcaaaaaa
gcbaaaadhcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaacaaaaaaegbcbaaaacaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaa
aaaaaaaaegbcbaaaacaaaaaadcaaaaaphccabaaaaaaaaaaaegacbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaadpdoaaaaab
"
}
}
 }
 Pass {
  Name "PREPASSFINAL"
  Tags { "LIGHTMODE"="PrePassFinal" "RenderType"="Opaque" }
  ZWrite Off
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[26] = { { 0, 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..25] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MUL R0.xyz, R0, c[25].w;
MUL R1.x, R0.y, R0.y;
MAD R2.w, R0.x, R0.x, -R1.x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[20];
DP4 R2.y, R0, c[19];
DP4 R2.x, R0, c[18];
DP4 R0.z, R1, c[23];
DP4 R0.x, R1, c[21];
DP4 R0.y, R1, c[22];
DP4 R1.w, vertex.position, c[8];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R2.w, c[24];
ADD R1.xyz, R0, R1;
MUL result.texcoord[4].xyz, R1, c[0].z;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
ADD result.texcoord[3].xy, R2, R2.z;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[3].z, -R0.x;
MOV result.texcoord[3].w, R1;
END
# 41 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c26.x
mov r0.w, c26.y
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mul r0.xyz, r0, c25.w
mul r1.x, r0.y, r0.y
mad r2.w, r0.x, r0.x, -r1.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c20
dp4 r2.y, r0, c19
dp4 r2.x, r0, c18
dp4 r0.w, v0, c7
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
mul r1.xyz, r2.w, c24
add r0.xyz, r2, r0
add r2.xyz, r0, r1
mul o5.xyz, r2, c26.z
mov r1.w, r0
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r0.xyz, r1.xyww, c26.z
mul r0.y, r0, c16.x
dp4 r1.z, v0, c6
mul r2.xyz, v1.y, c13
mad o4.xy, r0.z, c17.zwzw, r0
mad r0.xyz, v1.x, c12, r2
mad r0.xyz, v1.z, c14, r0
add o3.xyz, r0, c26.x
dp4 r0.x, v0, c2
mov o0, r1
mov o1.xy, v2
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o4.z, -r0.x
mov o4.w, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedmfbalefdhkjojeelanblceedleaeoaflabaaaaaaceahaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcmeafaaaa
eaaaabaahbabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaeaaaaaadkaabaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
acaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
aeaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
abaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
abaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
abaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
abaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaa
afaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[26] = { { 0, 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..25] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MUL R0.xyz, R0, c[25].w;
MUL R1.x, R0.y, R0.y;
MAD R2.w, R0.x, R0.x, -R1.x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[20];
DP4 R2.y, R0, c[19];
DP4 R2.x, R0, c[18];
DP4 R0.z, R1, c[23];
DP4 R0.x, R1, c[21];
DP4 R0.y, R1, c[22];
DP4 R1.w, vertex.position, c[8];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R2.w, c[24];
ADD R1.xyz, R0, R1;
MUL result.texcoord[4].xyz, R1, c[0].z;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
ADD result.texcoord[3].xy, R2, R2.z;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[3].z, -R0.x;
MOV result.texcoord[3].w, R1;
END
# 41 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c26.x
mov r0.w, c26.y
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mul r0.xyz, r0, c25.w
mul r1.x, r0.y, r0.y
mad r2.w, r0.x, r0.x, -r1.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c20
dp4 r2.y, r0, c19
dp4 r2.x, r0, c18
dp4 r0.w, v0, c7
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
mul r1.xyz, r2.w, c24
add r0.xyz, r2, r0
add r2.xyz, r0, r1
mul o5.xyz, r2, c26.z
mov r1.w, r0
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r0.xyz, r1.xyww, c26.z
mul r0.y, r0, c16.x
dp4 r1.z, v0, c6
mul r2.xyz, v1.y, c13
mad o4.xy, r0.z, c17.zwzw, r0
mad r0.xyz, v1.x, c12, r2
mad r0.xyz, v1.z, c14, r0
add o3.xyz, r0, c26.x
dp4 r0.x, v0, c2
mov o0, r1
mov o1.xy, v2
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o4.z, -r0.x
mov o4.w, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedmfbalefdhkjojeelanblceedleaeoaflabaaaaaaceahaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcmeafaaaa
eaaaabaahbabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaeaaaaaadkaabaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
acaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
aeaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
abaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
abaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
abaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
abaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaa
afaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[26] = { { 0, 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..25] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MUL R0.xyz, R0, c[25].w;
MUL R1.x, R0.y, R0.y;
MAD R2.w, R0.x, R0.x, -R1.x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[20];
DP4 R2.y, R0, c[19];
DP4 R2.x, R0, c[18];
DP4 R0.z, R1, c[23];
DP4 R0.x, R1, c[21];
DP4 R0.y, R1, c[22];
DP4 R1.w, vertex.position, c[8];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R2.w, c[24];
ADD R1.xyz, R0, R1;
MUL result.texcoord[4].xyz, R1, c[0].z;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
ADD result.texcoord[3].xy, R2, R2.z;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[3].z, -R0.x;
MOV result.texcoord[3].w, R1;
END
# 41 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c26.x
mov r0.w, c26.y
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mul r0.xyz, r0, c25.w
mul r1.x, r0.y, r0.y
mad r2.w, r0.x, r0.x, -r1.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c20
dp4 r2.y, r0, c19
dp4 r2.x, r0, c18
dp4 r0.w, v0, c7
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
mul r1.xyz, r2.w, c24
add r0.xyz, r2, r0
add r2.xyz, r0, r1
mul o5.xyz, r2, c26.z
mov r1.w, r0
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r0.xyz, r1.xyww, c26.z
mul r0.y, r0, c16.x
dp4 r1.z, v0, c6
mul r2.xyz, v1.y, c13
mad o4.xy, r0.z, c17.zwzw, r0
mad r0.xyz, v1.x, c12, r2
mad r0.xyz, v1.z, c14, r0
add o3.xyz, r0, c26.x
dp4 r0.x, v0, c2
mov o0, r1
mov o1.xy, v2
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o4.z, -r0.x
mov o4.w, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedmfbalefdhkjojeelanblceedleaeoaflabaaaaaaceahaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcmeafaaaa
eaaaabaahbabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaeaaaaaadkaabaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
acaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
aeaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
abaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
abaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
abaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
abaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaa
afaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[26] = { { 0, 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..25] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MUL R0.xyz, R0, c[25].w;
MUL R1.x, R0.y, R0.y;
MAD R2.w, R0.x, R0.x, -R1.x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[20];
DP4 R2.y, R0, c[19];
DP4 R2.x, R0, c[18];
DP4 R0.z, R1, c[23];
DP4 R0.x, R1, c[21];
DP4 R0.y, R1, c[22];
DP4 R1.w, vertex.position, c[8];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R2.w, c[24];
ADD R1.xyz, R0, R1;
MUL result.texcoord[4].xyz, R1, c[0].z;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
ADD result.texcoord[3].xy, R2, R2.z;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[3].z, -R0.x;
MOV result.texcoord[3].w, R1;
END
# 41 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c26.x
mov r0.w, c26.y
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mul r0.xyz, r0, c25.w
mul r1.x, r0.y, r0.y
mad r2.w, r0.x, r0.x, -r1.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c20
dp4 r2.y, r0, c19
dp4 r2.x, r0, c18
dp4 r0.w, v0, c7
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
mul r1.xyz, r2.w, c24
add r0.xyz, r2, r0
add r2.xyz, r0, r1
mul o5.xyz, r2, c26.z
mov r1.w, r0
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r0.xyz, r1.xyww, c26.z
mul r0.y, r0, c16.x
dp4 r1.z, v0, c6
mul r2.xyz, v1.y, c13
mad o4.xy, r0.z, c17.zwzw, r0
mad r0.xyz, v1.x, c12, r2
mad r0.xyz, v1.z, c14, r0
add o3.xyz, r0, c26.x
dp4 r0.x, v0, c2
mov o0, r1
mov o1.xy, v2
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o4.z, -r0.x
mov o4.w, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedmfbalefdhkjojeelanblceedleaeoaflabaaaaaaceahaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcmeafaaaa
eaaaabaahbabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaeaaaaaadkaabaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
acaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
aeaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
abaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
abaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
abaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
abaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaa
afaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[26] = { { 0, 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..25] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MUL R0.xyz, R0, c[25].w;
MUL R1.x, R0.y, R0.y;
MAD R2.w, R0.x, R0.x, -R1.x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[20];
DP4 R2.y, R0, c[19];
DP4 R2.x, R0, c[18];
DP4 R0.z, R1, c[23];
DP4 R0.x, R1, c[21];
DP4 R0.y, R1, c[22];
DP4 R1.w, vertex.position, c[8];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R2.w, c[24];
ADD R1.xyz, R0, R1;
MUL result.texcoord[4].xyz, R1, c[0].z;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
ADD result.texcoord[3].xy, R2, R2.z;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[3].z, -R0.x;
MOV result.texcoord[3].w, R1;
END
# 41 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c26.x
mov r0.w, c26.y
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mul r0.xyz, r0, c25.w
mul r1.x, r0.y, r0.y
mad r2.w, r0.x, r0.x, -r1.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c20
dp4 r2.y, r0, c19
dp4 r2.x, r0, c18
dp4 r0.w, v0, c7
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
mul r1.xyz, r2.w, c24
add r0.xyz, r2, r0
add r2.xyz, r0, r1
mul o5.xyz, r2, c26.z
mov r1.w, r0
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r0.xyz, r1.xyww, c26.z
mul r0.y, r0, c16.x
dp4 r1.z, v0, c6
mul r2.xyz, v1.y, c13
mad o4.xy, r0.z, c17.zwzw, r0
mad r0.xyz, v1.x, c12, r2
mad r0.xyz, v1.z, c14, r0
add o3.xyz, r0, c26.x
dp4 r0.x, v0, c2
mov o0, r1
mov o1.xy, v2
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o4.z, -r0.x
mov o4.w, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedmfbalefdhkjojeelanblceedleaeoaflabaaaaaaceahaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcmeafaaaa
eaaaabaahbabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaeaaaaaadkaabaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
acaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
aeaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
abaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
abaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
abaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
abaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaa
afaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[26] = { { 0, 1, 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..25] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MUL R0.xyz, R0, c[25].w;
MUL R1.x, R0.y, R0.y;
MAD R2.w, R0.x, R0.x, -R1.x;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[20];
DP4 R2.y, R0, c[19];
DP4 R2.x, R0, c[18];
DP4 R0.z, R1, c[23];
DP4 R0.x, R1, c[21];
DP4 R0.y, R1, c[22];
DP4 R1.w, vertex.position, c[8];
ADD R0.xyz, R2, R0;
MUL R1.xyz, R2.w, c[24];
ADD R1.xyz, R0, R1;
MUL result.texcoord[4].xyz, R1, c[0].z;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
ADD result.texcoord[3].xy, R2, R2.z;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[3].z, -R0.x;
MOV result.texcoord[3].w, R1;
END
# 41 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c26.x
mov r0.w, c26.y
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mul r0.xyz, r0, c25.w
mul r1.x, r0.y, r0.y
mad r2.w, r0.x, r0.x, -r1.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c20
dp4 r2.y, r0, c19
dp4 r2.x, r0, c18
dp4 r0.w, v0, c7
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
mul r1.xyz, r2.w, c24
add r0.xyz, r2, r0
add r2.xyz, r0, r1
mul o5.xyz, r2, c26.z
mov r1.w, r0
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
mul r0.xyz, r1.xyww, c26.z
mul r0.y, r0, c16.x
dp4 r1.z, v0, c6
mul r2.xyz, v1.y, c13
mad o4.xy, r0.z, c17.zwzw, r0
mad r0.xyz, v1.x, c12, r2
mad r0.xyz, v1.z, c14, r0
add o3.xyz, r0, c26.x
dp4 r0.x, v0, c2
mov o0, r1
mov o1.xy, v2
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o4.z, -r0.x
mov o4.w, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedmfbalefdhkjojeelanblceedleaeoaflabaaaaaaceahaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcmeafaaaa
eaaaabaahbabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaaeaaaaaadkaabaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
acaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
aeaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
abaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
abaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
abaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
abaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaa
afaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 1 [_Color]
Vector 2 [_Diffus_ST]
Vector 3 [_Mask_ST]
Float 4 [_Blend]
Float 5 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TXP R0, fragment.texcoord[3], texture[0], 2D;
LG2 R2.x, R0.x;
MAD R3.xy, fragment.texcoord[0], c[3], c[3].zwzw;
LG2 R2.y, R0.y;
LG2 R0.x, R0.w;
LG2 R2.z, R0.z;
TEX R1.z, R3, texture[2], 2D;
MUL R1.xyw, -R2.xyzz, -R0.x;
MUL R0.w, R1.z, c[4].x;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0.xyz, R0, texture[1], 2D;
ADD R3.xyz, -R0, c[1];
MAD R3.xyz, R0.w, R3, R0;
MUL R0.w, R0.x, c[5].x;
MUL R1.xyz, R1.xyww, c[6].y;
MUL R0.xyz, -R2, c[6].x;
MUL R1.xyz, R1, R0.w;
ADD R0.xyz, R0, fragment.texcoord[4];
MAD result.color.xyz, R0, R3, R1;
MOV result.color.w, c[6].z;
END
# 20 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_Diffus_ST]
Vector 2 [_Mask_ST]
Float 3 [_Blend]
Float 4 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.50000000, 2.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord3 v3
dcl_texcoord4 v4.xyz
texldp r0, v3, s0
log_pp r2.x, r0.x
mad r1.xy, v0, c2, c2.zwzw
log_pp r2.y, r0.y
log_pp r2.z, r0.z
log_pp r0.x, r0.w
mul_pp r3.xyz, -r2, -r0.x
texld r1.z, r1, s2
mad r0.xy, v0, c1, c1.zwzw
texld r0.xyz, r0, s1
mul r0.w, r1.z, c3.x
add r1.xyw, -r0.xyzz, c0.xyzz
mad r1.xyz, r0.w, r1.xyww, r0
mul r0.w, r0.x, c4.x
mul_pp r0.xyz, -r2, c5.x
mul_pp r3.xyz, r3, c5.y
mul r2.xyz, r3, r0.w
add r0.xyz, r0, v4
mad oC0.xyz, r0, r1, r2
mov_pp oC0.w, c5.z
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 96
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjgomiiajjdbcceimhglkilmdejnpljbjabaaaaaaaaaeaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaacaaaa
eaaaaaaaliaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadlcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadcaaaaalgcaabaaaaaaaaaaa
agbbbaaaabaaaaaaagibcaaaaaaaaaaaadaaaaaakgilcaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaaaaaaaaajocaabaaaaaaaaaaaagajbaiaebaaaaaaabaaaaaaagijcaaa
aaaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaa
bkiacaaaaaaaaaaaafaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaacpaaaaafpcaabaaaabaaaaaaegaobaaaabaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaadcaaaaam
hcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaaalpaaaaaalpaaaaaalp
aaaaaaaaegbcbaaaafaaaaaaaaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaa
egacbaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
egacbaaaacaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 1 [_Color]
Vector 2 [_Diffus_ST]
Vector 3 [_Mask_ST]
Float 4 [_Blend]
Float 5 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TXP R0, fragment.texcoord[3], texture[0], 2D;
LG2 R2.x, R0.x;
MAD R3.xy, fragment.texcoord[0], c[3], c[3].zwzw;
LG2 R2.y, R0.y;
LG2 R0.x, R0.w;
LG2 R2.z, R0.z;
TEX R1.z, R3, texture[2], 2D;
MUL R1.xyw, -R2.xyzz, -R0.x;
MUL R0.w, R1.z, c[4].x;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0.xyz, R0, texture[1], 2D;
ADD R3.xyz, -R0, c[1];
MAD R3.xyz, R0.w, R3, R0;
MUL R0.w, R0.x, c[5].x;
MUL R1.xyz, R1.xyww, c[6].y;
MUL R0.xyz, -R2, c[6].x;
MUL R1.xyz, R1, R0.w;
ADD R0.xyz, R0, fragment.texcoord[4];
MAD result.color.xyz, R0, R3, R1;
MOV result.color.w, c[6].z;
END
# 20 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_Diffus_ST]
Vector 2 [_Mask_ST]
Float 3 [_Blend]
Float 4 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.50000000, 2.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord3 v3
dcl_texcoord4 v4.xyz
texldp r0, v3, s0
log_pp r2.x, r0.x
mad r1.xy, v0, c2, c2.zwzw
log_pp r2.y, r0.y
log_pp r2.z, r0.z
log_pp r0.x, r0.w
mul_pp r3.xyz, -r2, -r0.x
texld r1.z, r1, s2
mad r0.xy, v0, c1, c1.zwzw
texld r0.xyz, r0, s1
mul r0.w, r1.z, c3.x
add r1.xyw, -r0.xyzz, c0.xyzz
mad r1.xyz, r0.w, r1.xyww, r0
mul r0.w, r0.x, c4.x
mul_pp r0.xyz, -r2, c5.x
mul_pp r3.xyz, r3, c5.y
mul r2.xyz, r3, r0.w
add r0.xyz, r0, v4
mad oC0.xyz, r0, r1, r2
mov_pp oC0.w, c5.z
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 96
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjgomiiajjdbcceimhglkilmdejnpljbjabaaaaaaaaaeaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaacaaaa
eaaaaaaaliaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadlcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadcaaaaalgcaabaaaaaaaaaaa
agbbbaaaabaaaaaaagibcaaaaaaaaaaaadaaaaaakgilcaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaaaaaaaaajocaabaaaaaaaaaaaagajbaiaebaaaaaaabaaaaaaagijcaaa
aaaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaa
bkiacaaaaaaaaaaaafaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaacpaaaaafpcaabaaaabaaaaaaegaobaaaabaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaadcaaaaam
hcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaaalpaaaaaalpaaaaaalp
aaaaaaaaegbcbaaaafaaaaaaaaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaa
egacbaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
egacbaaaacaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 1 [_Color]
Vector 2 [_Diffus_ST]
Vector 3 [_Mask_ST]
Float 4 [_Blend]
Float 5 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TXP R0, fragment.texcoord[3], texture[0], 2D;
LG2 R2.x, R0.x;
MAD R3.xy, fragment.texcoord[0], c[3], c[3].zwzw;
LG2 R2.y, R0.y;
LG2 R0.x, R0.w;
LG2 R2.z, R0.z;
TEX R1.z, R3, texture[2], 2D;
MUL R1.xyw, -R2.xyzz, -R0.x;
MUL R0.w, R1.z, c[4].x;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0.xyz, R0, texture[1], 2D;
ADD R3.xyz, -R0, c[1];
MAD R3.xyz, R0.w, R3, R0;
MUL R0.w, R0.x, c[5].x;
MUL R1.xyz, R1.xyww, c[6].y;
MUL R0.xyz, -R2, c[6].x;
MUL R1.xyz, R1, R0.w;
ADD R0.xyz, R0, fragment.texcoord[4];
MAD result.color.xyz, R0, R3, R1;
MOV result.color.w, c[6].z;
END
# 20 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_Diffus_ST]
Vector 2 [_Mask_ST]
Float 3 [_Blend]
Float 4 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.50000000, 2.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord3 v3
dcl_texcoord4 v4.xyz
texldp r0, v3, s0
log_pp r2.x, r0.x
mad r1.xy, v0, c2, c2.zwzw
log_pp r2.y, r0.y
log_pp r2.z, r0.z
log_pp r0.x, r0.w
mul_pp r3.xyz, -r2, -r0.x
texld r1.z, r1, s2
mad r0.xy, v0, c1, c1.zwzw
texld r0.xyz, r0, s1
mul r0.w, r1.z, c3.x
add r1.xyw, -r0.xyzz, c0.xyzz
mad r1.xyz, r0.w, r1.xyww, r0
mul r0.w, r0.x, c4.x
mul_pp r0.xyz, -r2, c5.x
mul_pp r3.xyz, r3, c5.y
mul r2.xyz, r3, r0.w
add r0.xyz, r0, v4
mad oC0.xyz, r0, r1, r2
mov_pp oC0.w, c5.z
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 96
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjgomiiajjdbcceimhglkilmdejnpljbjabaaaaaaaaaeaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaacaaaa
eaaaaaaaliaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadlcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadcaaaaalgcaabaaaaaaaaaaa
agbbbaaaabaaaaaaagibcaaaaaaaaaaaadaaaaaakgilcaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaaaaaaaaajocaabaaaaaaaaaaaagajbaiaebaaaaaaabaaaaaaagijcaaa
aaaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaa
bkiacaaaaaaaaaaaafaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaacpaaaaafpcaabaaaabaaaaaaegaobaaaabaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaadcaaaaam
hcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaaalpaaaaaalpaaaaaalp
aaaaaaaaegbcbaaaafaaaaaaaaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaa
egacbaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
egacbaaaacaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 1 [_Color]
Vector 2 [_Diffus_ST]
Vector 3 [_Mask_ST]
Float 4 [_Blend]
Float 5 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MAD R2.xy, fragment.texcoord[0], c[3], c[3].zwzw;
TEX R2.z, R2, texture[2], 2D;
MAD R1.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R1.xyz, R1, texture[1], 2D;
TXP R0, fragment.texcoord[3], texture[0], 2D;
ADD R2.xyw, -R1.xyzz, c[1].xyzz;
MUL R1.w, R2.z, c[4].x;
MAD R1.yzw, R1.w, R2.xxyw, R1.xxyz;
MUL R2.xyz, R0, c[6].x;
MUL R0.xyz, R0, R0.w;
MUL R0.w, R1.x, c[5].x;
MUL R0.xyz, R0, c[6].y;
MUL R0.xyz, R0, R0.w;
ADD R2.xyz, R2, fragment.texcoord[4];
MAD result.color.xyz, R2, R1.yzww, R0;
MOV result.color.w, c[6].z;
END
# 16 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_Diffus_ST]
Vector 2 [_Mask_ST]
Float 3 [_Blend]
Float 4 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.50000000, 2.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord3 v3
dcl_texcoord4 v4.xyz
mad r2.xy, v0, c2, c2.zwzw
texld r2.z, r2, s2
mad r1.xy, v0, c1, c1.zwzw
texld r1.xyz, r1, s1
texldp r0, v3, s0
add r2.xyw, -r1.xyzz, c0.xyzz
mul r1.w, r2.z, c3.x
mad r1.yzw, r1.w, r2.xxyw, r1.xxyz
mul_pp r2.xyz, r0, c5.x
mul_pp r0.xyz, r0, r0.w
mul r0.w, r1.x, c4.x
mul_pp r0.xyz, r0, c5.y
mul r0.xyz, r0, r0.w
add r2.xyz, r2, v4
mad oC0.xyz, r2, r1.yzww, r0
mov_pp oC0.w, c5.z
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 96
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
BindCB  "$Globals" 0
"ps_4_0
eefiecednoikhfioaknhbblbhdfaljfblddbckolabaaaaaaomadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmmacaaaa
eaaaaaaaldaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadlcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadcaaaaalgcaabaaaaaaaaaaa
agbbbaaaabaaaaaaagibcaaaaaaaaaaaadaaaaaakgilcaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaaaaaaaaajocaabaaaaaaaaaaaagajbaiaebaaaaaaabaaaaaaagijcaaa
aaaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaa
bkiacaaaaaaaaaaaafaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaa
egacbaaaabaaaaaadcaaaaamhcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaaegbcbaaaafaaaaaaaaaaaaahhcaabaaa
acaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 1 [_Color]
Vector 2 [_Diffus_ST]
Vector 3 [_Mask_ST]
Float 4 [_Blend]
Float 5 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MAD R2.xy, fragment.texcoord[0], c[3], c[3].zwzw;
TEX R2.z, R2, texture[2], 2D;
MAD R1.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R1.xyz, R1, texture[1], 2D;
TXP R0, fragment.texcoord[3], texture[0], 2D;
ADD R2.xyw, -R1.xyzz, c[1].xyzz;
MUL R1.w, R2.z, c[4].x;
MAD R1.yzw, R1.w, R2.xxyw, R1.xxyz;
MUL R2.xyz, R0, c[6].x;
MUL R0.xyz, R0, R0.w;
MUL R0.w, R1.x, c[5].x;
MUL R0.xyz, R0, c[6].y;
MUL R0.xyz, R0, R0.w;
ADD R2.xyz, R2, fragment.texcoord[4];
MAD result.color.xyz, R2, R1.yzww, R0;
MOV result.color.w, c[6].z;
END
# 16 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_Diffus_ST]
Vector 2 [_Mask_ST]
Float 3 [_Blend]
Float 4 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.50000000, 2.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord3 v3
dcl_texcoord4 v4.xyz
mad r2.xy, v0, c2, c2.zwzw
texld r2.z, r2, s2
mad r1.xy, v0, c1, c1.zwzw
texld r1.xyz, r1, s1
texldp r0, v3, s0
add r2.xyw, -r1.xyzz, c0.xyzz
mul r1.w, r2.z, c3.x
mad r1.yzw, r1.w, r2.xxyw, r1.xxyz
mul_pp r2.xyz, r0, c5.x
mul_pp r0.xyz, r0, r0.w
mul r0.w, r1.x, c4.x
mul_pp r0.xyz, r0, c5.y
mul r0.xyz, r0, r0.w
add r2.xyz, r2, v4
mad oC0.xyz, r2, r1.yzww, r0
mov_pp oC0.w, c5.z
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 96
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
BindCB  "$Globals" 0
"ps_4_0
eefiecednoikhfioaknhbblbhdfaljfblddbckolabaaaaaaomadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmmacaaaa
eaaaaaaaldaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadlcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadcaaaaalgcaabaaaaaaaaaaa
agbbbaaaabaaaaaaagibcaaaaaaaaaaaadaaaaaakgilcaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaaaaaaaaajocaabaaaaaaaaaaaagajbaiaebaaaaaaabaaaaaaagijcaaa
aaaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaa
bkiacaaaaaaaaaaaafaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaa
egacbaaaabaaaaaadcaaaaamhcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaaegbcbaaaafaaaaaaaaaaaaahhcaabaaa
acaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 1 [_Color]
Vector 2 [_Diffus_ST]
Vector 3 [_Mask_ST]
Float 4 [_Blend]
Float 5 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MAD R2.xy, fragment.texcoord[0], c[3], c[3].zwzw;
TEX R2.z, R2, texture[2], 2D;
MAD R1.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R1.xyz, R1, texture[1], 2D;
TXP R0, fragment.texcoord[3], texture[0], 2D;
ADD R2.xyw, -R1.xyzz, c[1].xyzz;
MUL R1.w, R2.z, c[4].x;
MAD R1.yzw, R1.w, R2.xxyw, R1.xxyz;
MUL R2.xyz, R0, c[6].x;
MUL R0.xyz, R0, R0.w;
MUL R0.w, R1.x, c[5].x;
MUL R0.xyz, R0, c[6].y;
MUL R0.xyz, R0, R0.w;
ADD R2.xyz, R2, fragment.texcoord[4];
MAD result.color.xyz, R2, R1.yzww, R0;
MOV result.color.w, c[6].z;
END
# 16 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_Diffus_ST]
Vector 2 [_Mask_ST]
Float 3 [_Blend]
Float 4 [_Specular]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c5, 0.50000000, 2.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord3 v3
dcl_texcoord4 v4.xyz
mad r2.xy, v0, c2, c2.zwzw
texld r2.z, r2, s2
mad r1.xy, v0, c1, c1.zwzw
texld r1.xyz, r1, s1
texldp r0, v3, s0
add r2.xyw, -r1.xyzz, c0.xyzz
mul r1.w, r2.z, c3.x
mad r1.yzw, r1.w, r2.xxyw, r1.xxyz
mul_pp r2.xyz, r0, c5.x
mul_pp r0.xyz, r0, r0.w
mul r0.w, r1.x, c4.x
mul_pp r0.xyz, r0, c5.y
mul r0.xyz, r0, r0.w
add r2.xyz, r2, v4
mad oC0.xyz, r2, r1.yzww, r0
mov_pp oC0.w, c5.z
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 96
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
BindCB  "$Globals" 0
"ps_4_0
eefiecednoikhfioaknhbblbhdfaljfblddbckolabaaaaaaomadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmmacaaaa
eaaaaaaaldaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadlcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadcaaaaalgcaabaaaaaaaaaaa
agbbbaaaabaaaaaaagibcaaaaaaaaaaaadaaaaaakgilcaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaaaaaaaaajocaabaaaaaaaaaaaagajbaiaebaaaaaaabaaaaaaagijcaaa
aaaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaa
bkiacaaaaaaaaaaaafaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaa
egacbaaaabaaaaaadcaaaaamhcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaaegbcbaaaafaaaaaaaaaaaaahhcaabaaa
acaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
}
 }
 Pass {
  Name "FORWARDBASE"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "RenderType"="Opaque" }
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_SHAr]
Vector 14 [unity_SHAg]
Vector 15 [unity_SHAb]
Vector 16 [unity_SHBr]
Vector 17 [unity_SHBg]
Vector 18 [unity_SHBb]
Vector 19 [unity_SHC]
Vector 20 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.normal;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[20].w;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[15];
DP4 R2.y, R0, c[14];
DP4 R2.x, R0, c[13];
MUL R2.w, R0.y, R0.y;
DP4 R0.y, R1, c[16];
DP4 R0.z, R1, c[17];
DP4 R0.w, R1, c[18];
ADD R1.xyz, R2, R0.yzww;
MAD R0.x, R0, R0, -R2.w;
MUL R2.xyz, vertex.normal.y, c[10];
MUL R0.xyz, R0.x, c[19];
ADD R0.xyz, R1, R0;
MAD R2.xyz, vertex.normal.x, c[9], R2;
MAD R1.xyz, vertex.normal.z, c[11], R2;
MUL result.texcoord[5].xyz, R0, c[0].z;
ADD result.texcoord[2].xyz, R1, c[0].x;
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
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord5 o4
def c20, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.w, c20.x
mov r1.xyz, v1
mov r0.w, c20.y
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c19.w
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c14
dp4 r2.y, r0, c13
dp4 r2.x, r0, c12
mul r2.w, r0.y, r0.y
dp4 r0.y, r1, c15
dp4 r0.z, r1, c16
dp4 r0.w, r1, c17
add r1.xyz, r2, r0.yzww
mad r0.x, r0, r0, -r2.w
mul r2.xyz, v1.y, c9
mul r0.xyz, r0.x, c18
add r0.xyz, r1, r0
mad r2.xyz, v1.x, c8, r2
mad r1.xyz, v1.z, c10, r2
mul o4.xyz, r0, c20.z
add o3.xyz, r1, c20.x
mov o1.xy, v2
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityLighting" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedkannhlebopidfcdoceokmjmhaaajclpmabaaaaaaleafaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaafaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcgmaeaaaaeaaaabaablabaaaafjaaaaaeegiocaaaaaaaaaaacnaaaaaa
fjaaaaaeegiocaaaabaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaabaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaabaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaaaaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaaaaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaaaaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaaaaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaaaaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaaaaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaaeaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_SHAr]
Vector 14 [unity_SHAg]
Vector 15 [unity_SHAb]
Vector 16 [unity_SHBr]
Vector 17 [unity_SHBg]
Vector 18 [unity_SHBb]
Vector 19 [unity_SHC]
Vector 20 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.normal;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[20].w;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[15];
DP4 R2.y, R0, c[14];
DP4 R2.x, R0, c[13];
MUL R2.w, R0.y, R0.y;
DP4 R0.y, R1, c[16];
DP4 R0.z, R1, c[17];
DP4 R0.w, R1, c[18];
ADD R1.xyz, R2, R0.yzww;
MAD R0.x, R0, R0, -R2.w;
MUL R2.xyz, vertex.normal.y, c[10];
MUL R0.xyz, R0.x, c[19];
ADD R0.xyz, R1, R0;
MAD R2.xyz, vertex.normal.x, c[9], R2;
MAD R1.xyz, vertex.normal.z, c[11], R2;
MUL result.texcoord[5].xyz, R0, c[0].z;
ADD result.texcoord[2].xyz, R1, c[0].x;
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
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord5 o4
def c20, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.w, c20.x
mov r1.xyz, v1
mov r0.w, c20.y
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c19.w
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c14
dp4 r2.y, r0, c13
dp4 r2.x, r0, c12
mul r2.w, r0.y, r0.y
dp4 r0.y, r1, c15
dp4 r0.z, r1, c16
dp4 r0.w, r1, c17
add r1.xyz, r2, r0.yzww
mad r0.x, r0, r0, -r2.w
mul r2.xyz, v1.y, c9
mul r0.xyz, r0.x, c18
add r0.xyz, r1, r0
mad r2.xyz, v1.x, c8, r2
mad r1.xyz, v1.z, c10, r2
mul o4.xyz, r0, c20.z
add o3.xyz, r1, c20.x
mov o1.xy, v2
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityLighting" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedkannhlebopidfcdoceokmjmhaaajclpmabaaaaaaleafaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaafaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcgmaeaaaaeaaaabaablabaaaafjaaaaaeegiocaaaaaaaaaaacnaaaaaa
fjaaaaaeegiocaaaabaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaabaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaabaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaaaaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaaaaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaaaaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaaaaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaaaaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaaaaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaaeaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_SHAr]
Vector 14 [unity_SHAg]
Vector 15 [unity_SHAb]
Vector 16 [unity_SHBr]
Vector 17 [unity_SHBg]
Vector 18 [unity_SHBb]
Vector 19 [unity_SHC]
Vector 20 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.normal;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[20].w;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[15];
DP4 R2.y, R0, c[14];
DP4 R2.x, R0, c[13];
MUL R2.w, R0.y, R0.y;
DP4 R0.y, R1, c[16];
DP4 R0.z, R1, c[17];
DP4 R0.w, R1, c[18];
ADD R1.xyz, R2, R0.yzww;
MAD R0.x, R0, R0, -R2.w;
MUL R2.xyz, vertex.normal.y, c[10];
MUL R0.xyz, R0.x, c[19];
ADD R0.xyz, R1, R0;
MAD R2.xyz, vertex.normal.x, c[9], R2;
MAD R1.xyz, vertex.normal.z, c[11], R2;
MUL result.texcoord[5].xyz, R0, c[0].z;
ADD result.texcoord[2].xyz, R1, c[0].x;
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
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord5 o4
def c20, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.w, c20.x
mov r1.xyz, v1
mov r0.w, c20.y
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c19.w
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c14
dp4 r2.y, r0, c13
dp4 r2.x, r0, c12
mul r2.w, r0.y, r0.y
dp4 r0.y, r1, c15
dp4 r0.z, r1, c16
dp4 r0.w, r1, c17
add r1.xyz, r2, r0.yzww
mad r0.x, r0, r0, -r2.w
mul r2.xyz, v1.y, c9
mul r0.xyz, r0.x, c18
add r0.xyz, r1, r0
mad r2.xyz, v1.x, c8, r2
mad r1.xyz, v1.z, c10, r2
mul o4.xyz, r0, c20.z
add o3.xyz, r1, c20.x
mov o1.xy, v2
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityLighting" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedkannhlebopidfcdoceokmjmhaaajclpmabaaaaaaleafaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaafaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcgmaeaaaaeaaaabaablabaaaafjaaaaaeegiocaaaaaaaaaaacnaaaaaa
fjaaaaaeegiocaaaabaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaabaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaabaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaaaaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaaaaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaaaaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaaaaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaaaaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaaaaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaaeaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[22] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[21].w;
MUL R0.w, R0.y, R0.y;
MAD R1.x, R0, R0, -R0.w;
MOV R0.w, c[0].y;
MUL R2.xyz, R1.x, c[20];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[16];
DP4 R3.y, R0, c[15];
DP4 R3.x, R0, c[14];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, R1, c[19];
DP4 R0.x, R1, c[17];
DP4 R0.y, R1, c[18];
ADD R0.xyz, R3, R0;
ADD R1.xyz, R0, R2;
DP4 R0.z, vertex.position, c[3];
MUL result.texcoord[5].xyz, R1, c[0].z;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R1.y, R2, c[13].x;
MOV R1.x, R2;
ADD result.texcoord[3].xy, R1, R2.z;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 39 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord5 o5
def c22, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c22.x
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c21.w
mul r0.w, r0.y, r0.y
mad r1.x, r0, r0, -r0.w
mov r0.w, c22.y
mul r2.xyz, r1.x, c20
mul r1, r0.xyzz, r0.yzzx
dp4 r3.z, r0, c16
dp4 r3.y, r0, c15
dp4 r3.x, r0, c14
dp4 r0.z, r1, c19
dp4 r0.x, r1, c17
dp4 r0.y, r1, c18
add r0.xyz, r3, r0
add r2.xyz, r0, r2
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c22.z
mul r0.y, r0, c12.x
mad o4.xy, r0.z, c13.zwzw, r0
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
mul o5.xyz, r2, c22.z
mov o0, r1
mov o4.zw, r1
add o3.xyz, r0, c22.x
mov o1.xy, v2
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedlaicjbklnelmnhpgpkaaigilopgaffnoabaaaaaaheagaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbeafaaaa
eaaaabaaefabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaafmccabaaaaeaaaaaakgaobaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaafaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[22] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[21].w;
MUL R0.w, R0.y, R0.y;
MAD R1.x, R0, R0, -R0.w;
MOV R0.w, c[0].y;
MUL R2.xyz, R1.x, c[20];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[16];
DP4 R3.y, R0, c[15];
DP4 R3.x, R0, c[14];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, R1, c[19];
DP4 R0.x, R1, c[17];
DP4 R0.y, R1, c[18];
ADD R0.xyz, R3, R0;
ADD R1.xyz, R0, R2;
DP4 R0.z, vertex.position, c[3];
MUL result.texcoord[5].xyz, R1, c[0].z;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R1.y, R2, c[13].x;
MOV R1.x, R2;
ADD result.texcoord[3].xy, R1, R2.z;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 39 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord5 o5
def c22, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c22.x
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c21.w
mul r0.w, r0.y, r0.y
mad r1.x, r0, r0, -r0.w
mov r0.w, c22.y
mul r2.xyz, r1.x, c20
mul r1, r0.xyzz, r0.yzzx
dp4 r3.z, r0, c16
dp4 r3.y, r0, c15
dp4 r3.x, r0, c14
dp4 r0.z, r1, c19
dp4 r0.x, r1, c17
dp4 r0.y, r1, c18
add r0.xyz, r3, r0
add r2.xyz, r0, r2
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c22.z
mul r0.y, r0, c12.x
mad o4.xy, r0.z, c13.zwzw, r0
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
mul o5.xyz, r2, c22.z
mov o0, r1
mov o4.zw, r1
add o3.xyz, r0, c22.x
mov o1.xy, v2
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedlaicjbklnelmnhpgpkaaigilopgaffnoabaaaaaaheagaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbeafaaaa
eaaaabaaefabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaafmccabaaaaeaaaaaakgaobaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaafaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[22] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[21].w;
MUL R0.w, R0.y, R0.y;
MAD R1.x, R0, R0, -R0.w;
MOV R0.w, c[0].y;
MUL R2.xyz, R1.x, c[20];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[16];
DP4 R3.y, R0, c[15];
DP4 R3.x, R0, c[14];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, R1, c[19];
DP4 R0.x, R1, c[17];
DP4 R0.y, R1, c[18];
ADD R0.xyz, R3, R0;
ADD R1.xyz, R0, R2;
DP4 R0.z, vertex.position, c[3];
MUL result.texcoord[5].xyz, R1, c[0].z;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R1.y, R2, c[13].x;
MOV R1.x, R2;
ADD result.texcoord[3].xy, R1, R2.z;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 39 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord5 o5
def c22, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c22.x
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c21.w
mul r0.w, r0.y, r0.y
mad r1.x, r0, r0, -r0.w
mov r0.w, c22.y
mul r2.xyz, r1.x, c20
mul r1, r0.xyzz, r0.yzzx
dp4 r3.z, r0, c16
dp4 r3.y, r0, c15
dp4 r3.x, r0, c14
dp4 r0.z, r1, c19
dp4 r0.x, r1, c17
dp4 r0.y, r1, c18
add r0.xyz, r3, r0
add r2.xyz, r0, r2
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c22.z
mul r0.y, r0, c12.x
mad o4.xy, r0.z, c13.zwzw, r0
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
mul o5.xyz, r2, c22.z
mov o0, r1
mov o4.zw, r1
add o3.xyz, r0, c22.x
mov o1.xy, v2
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedlaicjbklnelmnhpgpkaaigilopgaffnoabaaaaaaheagaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbeafaaaa
eaaaabaaefabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaafmccabaaaaeaaaaaakgaobaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaafaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [unity_SHAr]
Vector 14 [unity_SHAg]
Vector 15 [unity_SHAb]
Vector 16 [unity_SHBr]
Vector 17 [unity_SHBg]
Vector 18 [unity_SHBb]
Vector 19 [unity_SHC]
Vector 20 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[21] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.normal;
MOV R0.w, c[0].y;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[20].w;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[15];
DP4 R2.y, R0, c[14];
DP4 R2.x, R0, c[13];
MUL R2.w, R0.y, R0.y;
DP4 R0.y, R1, c[16];
DP4 R0.z, R1, c[17];
DP4 R0.w, R1, c[18];
ADD R1.xyz, R2, R0.yzww;
MAD R0.x, R0, R0, -R2.w;
MUL R2.xyz, vertex.normal.y, c[10];
MUL R0.xyz, R0.x, c[19];
ADD R0.xyz, R1, R0;
MAD R2.xyz, vertex.normal.x, c[9], R2;
MAD R1.xyz, vertex.normal.z, c[11], R2;
MUL result.texcoord[5].xyz, R0, c[0].z;
ADD result.texcoord[2].xyz, R1, c[0].x;
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
# 33 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord5 o4
def c20, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.w, c20.x
mov r1.xyz, v1
mov r0.w, c20.y
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c19.w
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c14
dp4 r2.y, r0, c13
dp4 r2.x, r0, c12
mul r2.w, r0.y, r0.y
dp4 r0.y, r1, c15
dp4 r0.z, r1, c16
dp4 r0.w, r1, c17
add r1.xyz, r2, r0.yzww
mad r0.x, r0, r0, -r2.w
mul r2.xyz, v1.y, c9
mul r0.xyz, r0.x, c18
add r0.xyz, r1, r0
mad r2.xyz, v1.x, c8, r2
mad r1.xyz, v1.z, c10, r2
mul o4.xyz, r0, c20.z
add o3.xyz, r1, c20.x
mov o1.xy, v2
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityLighting" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedkannhlebopidfcdoceokmjmhaaajclpmabaaaaaaleafaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaafaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcgmaeaaaaeaaaabaablabaaaafjaaaaaeegiocaaaaaaaaaaacnaaaaaa
fjaaaaaeegiocaaaabaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaabaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaabaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaaaaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaaaaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaaaaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaaaaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaaaaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaaaaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaaeaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"3.0-!!ARBvp1.0
PARAM c[22] = { { 0, 1, 0.5 },
		state.matrix.mvp,
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xyz, vertex.normal;
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[7];
DP4 R0.x, R1, c[5];
DP4 R0.y, R1, c[6];
MUL R0.xyz, R0, c[21].w;
MUL R0.w, R0.y, R0.y;
MAD R1.x, R0, R0, -R0.w;
MOV R0.w, c[0].y;
MUL R2.xyz, R1.x, c[20];
MUL R1, R0.xyzz, R0.yzzx;
DP4 R3.z, R0, c[16];
DP4 R3.y, R0, c[15];
DP4 R3.x, R0, c[14];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, R1, c[19];
DP4 R0.x, R1, c[17];
DP4 R0.y, R1, c[18];
ADD R0.xyz, R3, R0;
ADD R1.xyz, R0, R2;
DP4 R0.z, vertex.position, c[3];
MUL result.texcoord[5].xyz, R1, c[0].z;
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].z;
MUL R1.y, R2, c[13].x;
MOV R1.x, R2;
ADD result.texcoord[3].xy, R1, R2.z;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 39 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord5 o5
def c22, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mov r1.xyz, v1
mov r1.w, c22.x
dp4 r0.z, r1, c6
dp4 r0.x, r1, c4
dp4 r0.y, r1, c5
mul r0.xyz, r0, c21.w
mul r0.w, r0.y, r0.y
mad r1.x, r0, r0, -r0.w
mov r0.w, c22.y
mul r2.xyz, r1.x, c20
mul r1, r0.xyzz, r0.yzzx
dp4 r3.z, r0, c16
dp4 r3.y, r0, c15
dp4 r3.x, r0, c14
dp4 r0.z, r1, c19
dp4 r0.x, r1, c17
dp4 r0.y, r1, c18
add r0.xyz, r3, r0
add r2.xyz, r0, r2
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c22.z
mul r0.y, r0, c12.x
mad o4.xy, r0.z, c13.zwzw, r0
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
mul o5.xyz, r2, c22.z
mov o0, r1
mov o4.zw, r1
add o3.xyz, r0, c22.x
mov o1.xy, v2
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "UnityPerCamera" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedlaicjbklnelmnhpgpkaaigilopgaffnoabaaaaaaheagaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbeafaaaa
eaaaabaaefabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
dccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaafmccabaaaaeaaaaaakgaobaaa
aaaaaaaadiaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaabaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhccabaaaafaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, c[1], c[1];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, c[1];
DP3 R1.x, R0, R0;
RSQ R0.w, R1.x;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.z, R1, R0;
MAX R0.w, R0.z, c[8].x;
POW R0.w, R0.w, c[8].y;
MUL R3.xyz, R0.w, c[2];
DP3 R0.w, R1, R2;
MAD R1.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0.xyz, R0, texture[0], 2D;
MUL R1.w, R0.x, c[7].x;
TEX R2.z, R1, texture[1], 2D;
MUL R3.xyz, R3, R1.w;
ADD R1.xyz, -R0, c[3];
MUL R1.w, R2.z, c[6].x;
MAD R1.xyz, R1.w, R1, R0;
MAX R0.w, R0, c[8].x;
MAD R0.xyz, R0.w, c[2], fragment.texcoord[5];
MAD result.color.xyz, R0, R1, R3;
MOV result.color.w, c[8].z;
END
# 31 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c8, 0.00000000, 64.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
add r0.xyz, -v1, c0
dp3_pp r0.w, c1, c1
rsq_pp r0.w, r0.w
mad r3.xy, v0, c4, c4.zwzw
mul_pp r2.xyz, r0.w, c1
dp3 r1.x, r0, r0
rsq r0.w, r1.x
mad r0.xyz, r0.w, r0, r2
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
mul r0.xyz, r1.x, r0
rsq r0.w, r0.w
mul r1.xyz, r0.w, v2
dp3 r0.x, r1, r0
max r1.w, r0.x, c8.x
pow r0, r1.w, c8.y
texld r3.xyz, r3, s0
mul r0.w, r3.x, c7.x
mul r0.xyz, r0.x, c2
mul r0.xyz, r0, r0.w
dp3 r0.w, r1, r2
mad r1.xy, v0, c5, c5.zwzw
texld r2.z, r1, s1
add r1.xyz, -r3, c3
mul r1.w, r2.z, c6.x
mad r2.xyz, r1.w, r1, r3
max r0.w, r0, c8.x
mad r1.xyz, r0.w, c2, v3
mad oC0.xyz, r1, r2, r0
mov_pp oC0.w, c8.z
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedhmdjjpojdlbdmooeedjicbnjhbgcinacabaaaaaajaafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
afaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefciiaeaaaaeaaaaaaaccabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaabaaaaaajbcaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaaegiccaaaacaaaaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadcaaaaakocaabaaaaaaaaaaafgafbaaaaaaaaaaaagijcaaaaaaaaaaa
abaaaaaaagbjbaaaaeaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaa
aaaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
diaaaaaibcaabaaaaaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaaafaaaaaa
diaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaal
dcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaackaabaaaadaaaaaa
akiacaaaaaaaaaaaafaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaiaebaaaaaa
acaaaaaaegiccaaaaaaaaaaaacaaaaaadcaaaaajhcaabaaaacaaaaaaagaabaaa
aaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, c[1], c[1];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, c[1];
DP3 R1.x, R0, R0;
RSQ R0.w, R1.x;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.z, R1, R0;
MAX R0.w, R0.z, c[8].x;
POW R0.w, R0.w, c[8].y;
MUL R3.xyz, R0.w, c[2];
DP3 R0.w, R1, R2;
MAD R1.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0.xyz, R0, texture[0], 2D;
MUL R1.w, R0.x, c[7].x;
TEX R2.z, R1, texture[1], 2D;
MUL R3.xyz, R3, R1.w;
ADD R1.xyz, -R0, c[3];
MUL R1.w, R2.z, c[6].x;
MAD R1.xyz, R1.w, R1, R0;
MAX R0.w, R0, c[8].x;
MAD R0.xyz, R0.w, c[2], fragment.texcoord[5];
MAD result.color.xyz, R0, R1, R3;
MOV result.color.w, c[8].z;
END
# 31 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c8, 0.00000000, 64.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
add r0.xyz, -v1, c0
dp3_pp r0.w, c1, c1
rsq_pp r0.w, r0.w
mad r3.xy, v0, c4, c4.zwzw
mul_pp r2.xyz, r0.w, c1
dp3 r1.x, r0, r0
rsq r0.w, r1.x
mad r0.xyz, r0.w, r0, r2
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
mul r0.xyz, r1.x, r0
rsq r0.w, r0.w
mul r1.xyz, r0.w, v2
dp3 r0.x, r1, r0
max r1.w, r0.x, c8.x
pow r0, r1.w, c8.y
texld r3.xyz, r3, s0
mul r0.w, r3.x, c7.x
mul r0.xyz, r0.x, c2
mul r0.xyz, r0, r0.w
dp3 r0.w, r1, r2
mad r1.xy, v0, c5, c5.zwzw
texld r2.z, r1, s1
add r1.xyz, -r3, c3
mul r1.w, r2.z, c6.x
mad r2.xyz, r1.w, r1, r3
max r0.w, r0, c8.x
mad r1.xyz, r0.w, c2, v3
mad oC0.xyz, r1, r2, r0
mov_pp oC0.w, c8.z
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedhmdjjpojdlbdmooeedjicbnjhbgcinacabaaaaaajaafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
afaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefciiaeaaaaeaaaaaaaccabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaabaaaaaajbcaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaaegiccaaaacaaaaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadcaaaaakocaabaaaaaaaaaaafgafbaaaaaaaaaaaagijcaaaaaaaaaaa
abaaaaaaagbjbaaaaeaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaa
aaaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
diaaaaaibcaabaaaaaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaaafaaaaaa
diaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaal
dcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaackaabaaaadaaaaaa
akiacaaaaaaaaaaaafaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaiaebaaaaaa
acaaaaaaegiccaaaaaaaaaaaacaaaaaadcaaaaajhcaabaaaacaaaaaaagaabaaa
aaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, c[1], c[1];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, c[1];
DP3 R1.x, R0, R0;
RSQ R0.w, R1.x;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.z, R1, R0;
MAX R0.w, R0.z, c[8].x;
POW R0.w, R0.w, c[8].y;
MUL R3.xyz, R0.w, c[2];
DP3 R0.w, R1, R2;
MAD R1.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0.xyz, R0, texture[0], 2D;
MUL R1.w, R0.x, c[7].x;
TEX R2.z, R1, texture[1], 2D;
MUL R3.xyz, R3, R1.w;
ADD R1.xyz, -R0, c[3];
MUL R1.w, R2.z, c[6].x;
MAD R1.xyz, R1.w, R1, R0;
MAX R0.w, R0, c[8].x;
MAD R0.xyz, R0.w, c[2], fragment.texcoord[5];
MAD result.color.xyz, R0, R1, R3;
MOV result.color.w, c[8].z;
END
# 31 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c8, 0.00000000, 64.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
add r0.xyz, -v1, c0
dp3_pp r0.w, c1, c1
rsq_pp r0.w, r0.w
mad r3.xy, v0, c4, c4.zwzw
mul_pp r2.xyz, r0.w, c1
dp3 r1.x, r0, r0
rsq r0.w, r1.x
mad r0.xyz, r0.w, r0, r2
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
mul r0.xyz, r1.x, r0
rsq r0.w, r0.w
mul r1.xyz, r0.w, v2
dp3 r0.x, r1, r0
max r1.w, r0.x, c8.x
pow r0, r1.w, c8.y
texld r3.xyz, r3, s0
mul r0.w, r3.x, c7.x
mul r0.xyz, r0.x, c2
mul r0.xyz, r0, r0.w
dp3 r0.w, r1, r2
mad r1.xy, v0, c5, c5.zwzw
texld r2.z, r1, s1
add r1.xyz, -r3, c3
mul r1.w, r2.z, c6.x
mad r2.xyz, r1.w, r1, r3
max r0.w, r0, c8.x
mad r1.xyz, r0.w, c2, v3
mad oC0.xyz, r1, r2, r0
mov_pp oC0.w, c8.z
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedhmdjjpojdlbdmooeedjicbnjhbgcinacabaaaaaajaafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
afaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefciiaeaaaaeaaaaaaaccabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaabaaaaaajbcaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaaegiccaaaacaaaaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadcaaaaakocaabaaaaaaaaaaafgafbaaaaaaaaaaaagijcaaaaaaaaaaa
abaaaaaaagbjbaaaaeaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaa
aaaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
diaaaaaibcaabaaaaaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaaafaaaaaa
diaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaal
dcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaackaabaaaadaaaaaa
akiacaaaaaaaaaaaafaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaiaebaaaaaa
acaaaaaaegiccaaaaaaaaaaaacaaaaaadcaaaaajhcaabaaaacaaaaaaagaabaaa
aaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, c[1], c[1];
RSQ R0.w, R0.w;
DP3 R1.x, R0, R0;
MUL R3.xyz, R0.w, c[1];
RSQ R0.w, R1.x;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
MUL R0.xyz, R1.x, R0;
MUL R2.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R2, R0;
MAX R0.x, R0, c[8];
POW R1.w, R0.x, c[8].y;
TXP R0.x, fragment.texcoord[3], texture[0], 2D;
FLR R0.y, R0.x;
MAD R0.zw, fragment.texcoord[0].xyxy, c[4].xyxy, c[4];
TEX R1.xyz, R0.zwzw, texture[1], 2D;
MUL R4.xyz, R0.y, c[2];
MAD R0.zw, fragment.texcoord[0].xyxy, c[5].xyxy, c[5];
TEX R0.z, R0.zwzw, texture[2], 2D;
DP3 R0.w, R2, R3;
MUL R0.y, R1.x, c[7].x;
MUL R4.xyz, R4, R1.w;
MUL R5.xyz, R4, R0.y;
MUL R0.y, R0.z, c[6].x;
ADD R4.xyz, -R1, c[3];
MAD R1.xyz, R0.y, R4, R1;
MUL R0.xyz, R0.x, c[2];
MAX R0.w, R0, c[8].x;
MAD R0.xyz, R0.w, R0, fragment.texcoord[5];
MAD result.color.xyz, R0, R1, R5;
MOV result.color.w, c[8].z;
END
# 35 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c8, 0.00000000, 64.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
dcl_texcoord5 v4.xyz
dp3_pp r0.w, c1, c1
rsq_pp r1.x, r0.w
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
dp3 r1.w, v2, v2
rsq r1.w, r1.w
mul_pp r1.xyz, r1.x, c1
rsq r0.w, r0.w
mad r0.xyz, r0.w, r0, r1
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r2.xyz, r1.w, v2
dp3 r0.x, r2, r0
max r0.x, r0, c8
pow r3, r0.x, c8.y
texldp r0.x, v3, s0
mov r0.y, r3.x
frc r0.z, r0.x
mad r3.xy, v0, c4, c4.zwzw
dp3 r0.w, r2, r1
texld r4.xyz, r3, s1
add r0.z, r0.x, -r0
mul r3.xyz, r0.z, c2
mul r3.xyz, r3, r0.y
mul r0.y, r4.x, c7.x
mad r5.xy, v0, c5, c5.zwzw
texld r0.z, r5, s2
mul r3.xyz, r3, r0.y
mul r0.y, r0.z, c6.x
add r5.xyz, -r4, c3
mad r4.xyz, r0.y, r5, r4
mul r0.xyz, r0.x, c2
max r0.w, r0, c8.x
mad r0.xyz, r0.w, r0, v4
mad oC0.xyz, r0, r4, r3
mov_pp oC0.w, c8.z
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedgmaekfpmfhbcjjbcamffampocaffddknabaaaaaafmagaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdmafaaaa
eaaaaaaaepabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaabaaaaaajbcaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaaegiccaaaacaaaaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaaoaaaaahmcaabaaaaaaaaaaaagbebaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaebaaaaafecaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaai
hcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegacbaaaabaaaaaaegbcbaaaafaaaaaa
diaaaaaiocaabaaaaaaaaaaakgakbaaaaaaaaaaaagijcaaaaaaaaaaaafaaaaaa
diaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaacaaaaaa
bkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaadaaaaaa
egaabaaaadaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaiicaabaaa
aaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
dcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, c[1], c[1];
RSQ R0.w, R0.w;
DP3 R1.x, R0, R0;
MUL R3.xyz, R0.w, c[1];
RSQ R0.w, R1.x;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
MUL R0.xyz, R1.x, R0;
MUL R2.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R2, R0;
MAX R0.x, R0, c[8];
POW R1.w, R0.x, c[8].y;
TXP R0.x, fragment.texcoord[3], texture[0], 2D;
FLR R0.y, R0.x;
MAD R0.zw, fragment.texcoord[0].xyxy, c[4].xyxy, c[4];
TEX R1.xyz, R0.zwzw, texture[1], 2D;
MUL R4.xyz, R0.y, c[2];
MAD R0.zw, fragment.texcoord[0].xyxy, c[5].xyxy, c[5];
TEX R0.z, R0.zwzw, texture[2], 2D;
DP3 R0.w, R2, R3;
MUL R0.y, R1.x, c[7].x;
MUL R4.xyz, R4, R1.w;
MUL R5.xyz, R4, R0.y;
MUL R0.y, R0.z, c[6].x;
ADD R4.xyz, -R1, c[3];
MAD R1.xyz, R0.y, R4, R1;
MUL R0.xyz, R0.x, c[2];
MAX R0.w, R0, c[8].x;
MAD R0.xyz, R0.w, R0, fragment.texcoord[5];
MAD result.color.xyz, R0, R1, R5;
MOV result.color.w, c[8].z;
END
# 35 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c8, 0.00000000, 64.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
dcl_texcoord5 v4.xyz
dp3_pp r0.w, c1, c1
rsq_pp r1.x, r0.w
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
dp3 r1.w, v2, v2
rsq r1.w, r1.w
mul_pp r1.xyz, r1.x, c1
rsq r0.w, r0.w
mad r0.xyz, r0.w, r0, r1
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r2.xyz, r1.w, v2
dp3 r0.x, r2, r0
max r0.x, r0, c8
pow r3, r0.x, c8.y
texldp r0.x, v3, s0
mov r0.y, r3.x
frc r0.z, r0.x
mad r3.xy, v0, c4, c4.zwzw
dp3 r0.w, r2, r1
texld r4.xyz, r3, s1
add r0.z, r0.x, -r0
mul r3.xyz, r0.z, c2
mul r3.xyz, r3, r0.y
mul r0.y, r4.x, c7.x
mad r5.xy, v0, c5, c5.zwzw
texld r0.z, r5, s2
mul r3.xyz, r3, r0.y
mul r0.y, r0.z, c6.x
add r5.xyz, -r4, c3
mad r4.xyz, r0.y, r5, r4
mul r0.xyz, r0.x, c2
max r0.w, r0, c8.x
mad r0.xyz, r0.w, r0, v4
mad oC0.xyz, r0, r4, r3
mov_pp oC0.w, c8.z
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedgmaekfpmfhbcjjbcamffampocaffddknabaaaaaafmagaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdmafaaaa
eaaaaaaaepabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaabaaaaaajbcaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaaegiccaaaacaaaaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaaoaaaaahmcaabaaaaaaaaaaaagbebaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaebaaaaafecaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaai
hcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegacbaaaabaaaaaaegbcbaaaafaaaaaa
diaaaaaiocaabaaaaaaaaaaakgakbaaaaaaaaaaaagijcaaaaaaaaaaaafaaaaaa
diaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaacaaaaaa
bkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaadaaaaaa
egaabaaaadaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaiicaabaaa
aaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
dcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, c[1], c[1];
RSQ R0.w, R0.w;
DP3 R1.x, R0, R0;
MUL R3.xyz, R0.w, c[1];
RSQ R0.w, R1.x;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
MUL R0.xyz, R1.x, R0;
MUL R2.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R2, R0;
MAX R0.x, R0, c[8];
POW R1.w, R0.x, c[8].y;
TXP R0.x, fragment.texcoord[3], texture[0], 2D;
FLR R0.y, R0.x;
MAD R0.zw, fragment.texcoord[0].xyxy, c[4].xyxy, c[4];
TEX R1.xyz, R0.zwzw, texture[1], 2D;
MUL R4.xyz, R0.y, c[2];
MAD R0.zw, fragment.texcoord[0].xyxy, c[5].xyxy, c[5];
TEX R0.z, R0.zwzw, texture[2], 2D;
DP3 R0.w, R2, R3;
MUL R0.y, R1.x, c[7].x;
MUL R4.xyz, R4, R1.w;
MUL R5.xyz, R4, R0.y;
MUL R0.y, R0.z, c[6].x;
ADD R4.xyz, -R1, c[3];
MAD R1.xyz, R0.y, R4, R1;
MUL R0.xyz, R0.x, c[2];
MAX R0.w, R0, c[8].x;
MAD R0.xyz, R0.w, R0, fragment.texcoord[5];
MAD result.color.xyz, R0, R1, R5;
MOV result.color.w, c[8].z;
END
# 35 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c8, 0.00000000, 64.00000000, 1.00000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
dcl_texcoord5 v4.xyz
dp3_pp r0.w, c1, c1
rsq_pp r1.x, r0.w
add r0.xyz, -v1, c0
dp3 r0.w, r0, r0
dp3 r1.w, v2, v2
rsq r1.w, r1.w
mul_pp r1.xyz, r1.x, c1
rsq r0.w, r0.w
mad r0.xyz, r0.w, r0, r1
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r2.xyz, r1.w, v2
dp3 r0.x, r2, r0
max r0.x, r0, c8
pow r3, r0.x, c8.y
texldp r0.x, v3, s0
mov r0.y, r3.x
frc r0.z, r0.x
mad r3.xy, v0, c4, c4.zwzw
dp3 r0.w, r2, r1
texld r4.xyz, r3, s1
add r0.z, r0.x, -r0
mul r3.xyz, r0.z, c2
mul r3.xyz, r3, r0.y
mul r0.y, r4.x, c7.x
mad r5.xy, v0, c5, c5.zwzw
texld r0.z, r5, s2
mul r3.xyz, r3, r0.y
mul r0.y, r0.z, c6.x
add r5.xyz, -r4, c3
mad r4.xyz, r0.y, r5, r4
mul r0.xyz, r0.x, c2
max r0.w, r0, c8.x
mad r0.xyz, r0.w, r0, v4
mad oC0.xyz, r0, r4, r3
mov_pp oC0.w, c8.z
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedgmaekfpmfhbcjjbcamffampocaffddknabaaaaaafmagaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdmafaaaa
eaaaaaaaepabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaabaaaaaajbcaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaaegiccaaaacaaaaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
acaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaaoaaaaahmcaabaaaaaaaaaaaagbebaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaebaaaaafecaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaai
hcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegacbaaaabaaaaaaegbcbaaaafaaaaaa
diaaaaaiocaabaaaaaaaaaaakgakbaaaaaaaaaaaagijcaaaaaaaaaaaafaaaaaa
diaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaacaaaaaa
bkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaadaaaaaa
egaabaaaadaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaiicaabaaa
aaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
dcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
}
 }
 Pass {
  Name "FORWARDADD"
  Tags { "LIGHTMODE"="ForwardAdd" "SHADOWSUPPORT"="true" "RenderType"="Opaque" }
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
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o2, r0
dp4 o4.z, r0, c14
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c16.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedhhhpekmnnehpknojhpbnlflkcfafimehabaaaaaadaaeaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcoiacaaaaeaaaabaalkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaaaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
"3.0-!!ARBvp1.0
PARAM c[13] = { { 0 },
		state.matrix.mvp,
		program.local[5..12] };
TEMP R0;
MUL R0.xyz, vertex.normal.y, c[10];
MAD R0.xyz, vertex.normal.x, c[9], R0;
MAD R0.xyz, vertex.normal.z, c[11], R0;
ADD result.texcoord[2].xyz, R0, c[0].x;
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
# 13 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
def c12, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1.y, c9
mad r0.xyz, v1.x, c8, r0
mad r0.xyz, v1.z, c10, r0
add o3.xyz, r0, c12.x
mov o1.xy, v2
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedjdljhkejdilcbihingpimmjodnapadhmabaaaaaafaadaaaaadaaaaaa
cmaaaaaakaaaaaaaciabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
heaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaheaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefccaacaaaaeaaaabaaiiaaaaaafjaaaaaeegiocaaa
aaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaa
fpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
dccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaa
egiccaaaaaaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaa
egiccaaaaaaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaa
egiccaaaaaaaaaaabcaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].w, R0, c[16];
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o2, r0
dp4 o4.w, r0, c15
dp4 o4.z, r0, c14
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c16.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedpcklnekfccpaoemkodbgligplhcdedpeabaaaaaadaaeaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcoiacaaaaeaaaabaalkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaadiaaaaaipcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaadcaaaaakpcaabaaaabaaaaaa
egiocaaaaaaaaaaaabaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpccabaaaaeaaaaaaegiocaaaaaaaaaaaaeaaaaaapgapbaaa
aaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o2, r0
dp4 o4.z, r0, c14
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c16.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedhhhpekmnnehpknojhpbnlflkcfafimehabaaaaaadaaeaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcoiacaaaaeaaaabaalkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaaaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
"3.0-!!ARBvp1.0
PARAM c[17] = { { 0 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 16 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c16, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o2, r0
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c16.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddphbgoiomdiiaippcecingclkammnpfhabaaaaaadaaeaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaadaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaaimaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcoiacaaaaeaaaabaalkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiacaaaaaaaaaaaacaaaaaadcaaaaakdcaabaaaabaaaaaaegiacaaaaaaaaaaa
abaaaaaaagaabaaaaaaaaaaaegaabaaaabaaaaaadcaaaaakdcaabaaaabaaaaaa
egiacaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaaegaabaaaabaaaaaadcaaaaak
mccabaaaabaaaaaaagiecaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaagaebaaa
abaaaaaadgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaa
abaaaaaaegbabaaaacaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabcaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].w, R0, c[20];
DP4 result.texcoord[3].z, R0, c[19];
DP4 result.texcoord[3].y, R0, c[18];
DP4 result.texcoord[3].x, R0, c[17];
DP4 result.texcoord[4].w, R0, c[8];
DP4 result.texcoord[4].z, R0, c[7];
DP4 result.texcoord[4].y, R0, c[6];
DP4 result.texcoord[4].x, R0, c[5];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 22 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o4.w, r0, c19
dp4 o4.z, r0, c18
dp4 o4.y, r0, c17
dp4 o4.x, r0, c16
dp4 o5.w, r0, c7
dp4 o5.z, r0, c6
dp4 o5.y, r0, c5
dp4 o5.x, r0, c4
add o3.xyz, r1, c20.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityShadows" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityShadows" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefieceddcjnccjlihbfdilnckoambplnffllkpeabaaaaaapmaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcjmadaaaa
eaaaabaaohaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
pccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaa
aaaaaaaaacaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaa
aeaaaaaaegiocaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaa
dcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaa
kgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaa
abaaaaaaalaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].w, R0, c[20];
DP4 result.texcoord[3].z, R0, c[19];
DP4 result.texcoord[3].y, R0, c[18];
DP4 result.texcoord[3].x, R0, c[17];
DP4 result.texcoord[4].w, R0, c[8];
DP4 result.texcoord[4].z, R0, c[7];
DP4 result.texcoord[4].y, R0, c[6];
DP4 result.texcoord[4].x, R0, c[5];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 22 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o4.w, r0, c19
dp4 o4.z, r0, c18
dp4 o4.y, r0, c17
dp4 o4.x, r0, c16
dp4 o5.w, r0, c7
dp4 o5.z, r0, c6
dp4 o5.y, r0, c5
dp4 o5.x, r0, c4
add o3.xyz, r1, c20.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityShadows" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityShadows" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefieceddcjnccjlihbfdilnckoambplnffllkpeabaaaaaapmaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcjmadaaaa
eaaaabaaohaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
pccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaa
aaaaaaaaacaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaa
aeaaaaaaegiocaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaa
dcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaa
kgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaa
abaaaaaaalaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_ProjectionParams]
"3.0-!!ARBvp1.0
PARAM c[14] = { { 0, 0.5 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].y;
MUL R1.y, R1, c[13].x;
ADD result.texcoord[3].xy, R1, R1.z;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c14, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c14.y
mul r1.y, r1, c12.x
mad o4.xy, r1.z, c13.zwzw, r1
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
mov o0, r0
mov o4.zw, r0
add o3.xyz, r1, c14.x
mov o1.xy, v2
dp4 o2.w, v0, c7
dp4 o2.z, v0, c6
dp4 o2.y, v0, c5
dp4 o2.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "UnityPerCamera" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedoleaaeocfpnmajljolmnfdplcfcelhpcabaaaaaabaaeaaaaadaaaaaa
cmaaaaaakaaaaaaaeaabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcmiacaaaaeaaaabaalcaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaabaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaabaaaaaaibccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[10];
DP4 R2.w, vertex.position, c[4];
DP4 R2.z, vertex.position, c[3];
DP4 R0.w, vertex.position, c[8];
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MUL R0.xyz, R2.xyww, c[0].y;
MUL R0.y, R0, c[17].x;
ADD result.texcoord[4].xy, R0, R0.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].y, R0, c[14];
MAD R1.xyz, vertex.normal.x, c[9], R1;
DP4 result.texcoord[3].x, R0, c[13];
MAD R0.xyz, vertex.normal.z, c[11], R1;
MOV result.position, R2;
MOV result.texcoord[4].zw, R2;
ADD result.texcoord[2].xyz, R0, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
END
# 21 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c18, 0.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
dp4 r2.w, v0, c3
dp4 r2.z, v0, c2
dp4 r0.w, v0, c7
dp4 r2.x, v0, c0
dp4 r2.y, v0, c1
mul r0.xyz, r2.xyww, c18.y
mul r0.y, r0, c16.x
mad o5.xy, r0.z, c17.zwzw, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov o2, r0
dp4 o4.y, r0, c13
mad r1.xyz, v1.x, c8, r1
dp4 o4.x, r0, c12
mad r0.xyz, v1.z, c10, r1
mov o0, r2
mov o5.zw, r2
add o3.xyz, r0, c18.x
mov o1.xy, v2
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 224
Matrix 80 [_LightMatrix0]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedcnbjiajjmpmbpppeahnackcjpdlkpjcpabaaaaaapaaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcjaadaaaa
eaaaabaaoeaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaai
pcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaadiaaaaaidcaabaaaacaaaaaa
fgafbaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaadcaaaaakdcaabaaaacaaaaaa
egiacaaaaaaaaaaaafaaaaaaagaabaaaabaaaaaaegaabaaaacaaaaaadcaaaaak
dcaabaaaacaaaaaaegiacaaaaaaaaaaaahaaaaaakgakbaaaabaaaaaaegaabaaa
acaaaaaadcaaaaakmccabaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaapgapbaaa
abaaaaaaagaebaaaacaaaaaadgaaaaafpccabaaaacaaaaaaegaobaaaabaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaabaaaaaaibccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
ADD result.texcoord[4].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o4.z, r0, c14
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c17.x
add o5.xyz, r0, -c16
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityLighting" 720
Vector 16 [_LightPositionRange]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedgedeknicllmedjokbahpiabcncpenngcabaaaaaaiiaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcciadaaaa
eaaaabaamkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
aaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
aaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
aaaaaaajhccabaaaafaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaa
abaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
ADD result.texcoord[4].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o4.z, r0, c14
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c17.x
add o5.xyz, r0, -c16
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityLighting" 720
Vector 16 [_LightPositionRange]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedgedeknicllmedjokbahpiabcncpenngcabaaaaaaiiaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcciadaaaa
eaaaabaamkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
aaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
aaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
aaaaaaajhccabaaaafaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaa
abaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].w, R0, c[20];
DP4 result.texcoord[3].z, R0, c[19];
DP4 result.texcoord[3].y, R0, c[18];
DP4 result.texcoord[3].x, R0, c[17];
DP4 result.texcoord[4].w, R0, c[8];
DP4 result.texcoord[4].z, R0, c[7];
DP4 result.texcoord[4].y, R0, c[6];
DP4 result.texcoord[4].x, R0, c[5];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 22 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o4.w, r0, c19
dp4 o4.z, r0, c18
dp4 o4.y, r0, c17
dp4 o4.x, r0, c16
dp4 o5.w, r0, c7
dp4 o5.z, r0, c6
dp4 o5.y, r0, c5
dp4 o5.x, r0, c4
add o3.xyz, r1, c20.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 224
Matrix 80 [_LightMatrix0]
ConstBuffer "UnityShadows" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityShadows" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedihhmiofalmplahehmpgnpaigpfomioneabaaaaaapmaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcjmadaaaa
eaaaabaaohaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
pccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaa
aaaaaaaaagaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
agaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaa
aeaaaaaaegiocaaaaaaaaaaaaiaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaa
dcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaa
kgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaa
abaaaaaaalaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
DP4 R0.w, vertex.position, c[12];
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].w, R0, c[20];
DP4 result.texcoord[3].z, R0, c[19];
DP4 result.texcoord[3].y, R0, c[18];
DP4 result.texcoord[3].x, R0, c[17];
DP4 result.texcoord[4].w, R0, c[8];
DP4 result.texcoord[4].z, R0, c[7];
DP4 result.texcoord[4].y, R0, c[6];
DP4 result.texcoord[4].x, R0, c[5];
ADD result.texcoord[2].xyz, R1, c[0].x;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 22 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c20, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
dp4 r0.w, v0, c11
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mov o2, r0
dp4 o4.w, r0, c19
dp4 o4.z, r0, c18
dp4 o4.y, r0, c17
dp4 o4.x, r0, c16
dp4 o5.w, r0, c7
dp4 o5.z, r0, c6
dp4 o5.y, r0, c5
dp4 o5.x, r0, c4
add o3.xyz, r1, c20.x
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 224
Matrix 80 [_LightMatrix0]
ConstBuffer "UnityShadows" 416
Matrix 128 [unity_World2Shadow0]
Matrix 192 [unity_World2Shadow1]
Matrix 256 [unity_World2Shadow2]
Matrix 320 [unity_World2Shadow3]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityShadows" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedihhmiofalmplahehmpgnpaigpfomioneabaaaaaapmaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcjmadaaaa
eaaaabaaohaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaad
pccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaa
aaaaaaaaagaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
agaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaa
aeaaaaaaegiocaaaaaaaaaaaaiaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaa
dcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaa
kgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaa
abaaaaaaalaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
ADD result.texcoord[4].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o4.z, r0, c14
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c17.x
add o5.xyz, r0, -c16
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityLighting" 720
Vector 16 [_LightPositionRange]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedgedeknicllmedjokbahpiabcncpenngcabaaaaaaiiaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcciadaaaa
eaaaabaamkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
aaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
aaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
aaaaaaajhccabaaaafaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaa
abaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.texcoord[1], R0;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
ADD result.texcoord[2].xyz, R1, c[0].x;
ADD result.texcoord[4].xyz, R0, -c[17];
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
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
def c17, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov o2, r0
dp4 o4.z, r0, c14
dp4 o4.y, r0, c13
dp4 o4.x, r0, c12
add o3.xyz, r1, c17.x
add o5.xyz, r0, -c16
mov o1.xy, v2
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityLighting" 720
Vector 16 [_LightPositionRange]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedgedeknicllmedjokbahpiabcncpenngcabaaaaaaiiaeaaaaadaaaaaa
cmaaaaaakaaaaaaafiabaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcciadaaaa
eaaaabaamkaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaa
egaobaaaaaaaaaaabaaaaaaibccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabaaaaaaabaaaaaaicccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabbaaaaaabaaaaaaieccabaaaadaaaaaaegbcbaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
aaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
aaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
aaaaaaajhccabaaaafaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaa
abaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.w, R0, R1;
DP3 R0.z, R0, R2;
MAX R0.w, R0, c[8].x;
POW R2.w, R0.w, c[8].y;
MAD R1.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R1.xyz, R1, texture[1], 2D;
DP3 R0.w, fragment.texcoord[3], fragment.texcoord[3];
TEX R0.w, R0.w, texture[0], 2D;
MUL R3.xyz, R0.w, c[2];
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAX R0.w, R0.z, c[8].x;
TEX R0.z, R0, texture[2], 2D;
MUL R1.w, R1.x, c[7].x;
MUL R4.xyz, R3, R2.w;
ADD R2.xyz, -R1, c[3];
MUL R0.x, R0.z, c[6];
MAD R0.xyz, R0.x, R2, R1;
MUL R4.xyz, R4, R1.w;
MUL R1.xyz, R0.w, R3;
MAD result.color.xyz, R1, R0, R4;
MOV result.color.w, c[8].x;
END
# 35 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c8, 0.00000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.x, r2, r0
max r1.x, r0, c8
pow r0, r1.x, c8.y
mov r0.z, r0.x
mad r1.xy, v0, c4, c4.zwzw
texld r1.xyz, r1, s1
dp3 r0.x, v3, v3
texld r0.x, r0.x, s0
mul r0.xyw, r0.x, c2.xyzz
mul r4.xyz, r0.xyww, r0.z
dp3 r0.z, r2, r3
mul r1.w, r1.x, c7.x
mul r4.xyz, r4, r1.w
mad r2.xy, v0, c5, c5.zwzw
max r1.w, r0.z, c8.x
texld r0.z, r2, s2
mul r0.z, r0, c6.x
add r2.xyz, -r1, c3
mad r1.xyz, r0.z, r2, r1
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_OFF" }
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedecbeeockecpkoagpibkfhhjpnoimpfbhabaaaaaacaagaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcbiafaaaaeaaaaaaaegabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaamhcaabaaa
aaaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaabaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaak
dcaabaaaaaaaaaaamgaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaakgakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
aaaaaaaaafaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaa
acaaaaaabkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaa
aaaaaaaajgahbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
adaaaaaaegaabaaaadaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaai
icaabaaaaaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaaj
hcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaa
dcaaaaajhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaa
acaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.z, R1, R0;
MAX R0.w, R0.z, c[8].x;
POW R0.w, R0.w, c[8].y;
MUL R3.xyz, R0.w, c[2];
DP3 R0.w, R1, R2;
MAD R1.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0.xyz, R0, texture[0], 2D;
MUL R1.w, R0.x, c[7].x;
TEX R2.z, R1, texture[1], 2D;
MUL R3.xyz, R3, R1.w;
ADD R1.xyz, -R0, c[3];
MUL R1.w, R2.z, c[6].x;
MAD R1.xyz, R1.w, R1, R0;
MAX R0.w, R0, c[8].x;
MUL R0.xyz, R0.w, c[2];
MAD result.color.xyz, R0, R1, R3;
MOV result.color.w, c[8].x;
END
# 32 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c8, 0.00000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
mad_pp r1.xyz, -v1, c1.w, c1
dp3_pp r0.w, r1, r1
add r0.xyz, -v1, c0
rsq_pp r0.w, r0.w
mad r3.xy, v0, c4, c4.zwzw
mul_pp r2.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r2
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
mul r0.xyz, r1.x, r0
rsq r0.w, r0.w
mul r1.xyz, r0.w, v2
dp3 r0.x, r1, r0
max r1.w, r0.x, c8.x
pow r0, r1.w, c8.y
texld r3.xyz, r3, s0
mul r0.w, r3.x, c7.x
mul r0.xyz, r0.x, c2
mul r0.xyz, r0, r0.w
dp3 r0.w, r1, r2
mad r1.xy, v0, c5, c5.zwzw
texld r2.z, r1, s1
add r1.xyz, -r3, c3
mul r1.w, r2.z, c6.x
mad r2.xyz, r1.w, r1, r3
max r0.w, r0, c8.x
mul r1.xyz, r0.w, c2
mad oC0.xyz, r1, r2, r0
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
SetTexture 0 [_Diffus] 2D 0
SetTexture 1 [_Mask] 2D 1
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
Vector 32 [_Color]
Vector 48 [_Diffus_ST]
Vector 64 [_Mask_ST]
Float 80 [_Blend]
Float 84 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedokjfpepbgednfoomefcegaadiikgnoboabaaaaaaiiafaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcjiaeaaaaeaaaaaaacgabaaaafjaaaaaeegiocaaa
aaaaaaaaagaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaamhcaabaaa
aaaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaabaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaak
jcaabaaaaaaaaaaaagambaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
abaaaaaacpaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaapgapbaaaaaaaaaaaegiccaaa
aaaaaaaaabaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaacaaaaaa
egaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaiicaabaaa
aaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaaafaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaldcaabaaaadaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaa
efaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaa
afaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaa
aaaaaaaaacaaaaaadcaaaaajhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 0.5, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
DP3 R1.w, fragment.texcoord[3], fragment.texcoord[3];
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.w, R0, R1;
DP3 R0.z, R0, R2;
MAX R0.w, R0, c[8].x;
POW R2.w, R0.w, c[8].z;
RCP R0.w, fragment.texcoord[3].w;
MAD R3.xy, fragment.texcoord[3], R0.w, c[8].y;
TEX R0.w, R3, texture[0], 2D;
SLT R3.x, c[8], fragment.texcoord[3].z;
MAD R1.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R1.xyz, R1, texture[2], 2D;
MUL R0.w, R3.x, R0;
TEX R1.w, R1.w, texture[1], 2D;
MUL R1.w, R0, R1;
MUL R3.xyz, R1.w, c[2];
MUL R0.w, R1.x, c[7].x;
MUL R4.xyz, R3, R2.w;
MUL R4.xyz, R4, R0.w;
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAX R0.w, R0.z, c[8].x;
TEX R0.z, R0, texture[3], 2D;
ADD R2.xyz, -R1, c[3];
MUL R0.x, R0.z, c[6];
MAD R0.xyz, R0.x, R2, R1;
MUL R1.xyz, R0.w, R3;
MAD result.color.xyz, R1, R0, R4;
MOV result.color.w, c[8].x;
END
# 41 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c8, 0.00000000, 1.00000000, 0.50000000, 64.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.x, r2, r0
max r1.x, r0, c8
pow r0, r1.x, c8.w
mov r0.z, r0.x
mad r0.xy, v0, c4, c4.zwzw
texld r1.xyz, r0, s2
rcp r0.w, v3.w
mad r4.xy, v3, r0.w, c8.z
dp3 r0.x, v3, v3
texld r0.w, r4, s0
cmp r0.y, -v3.z, c8.x, c8
mul r1.w, r1.x, c7.x
mul_pp r0.y, r0, r0.w
texld r0.x, r0.x, s1
mul_pp r0.x, r0.y, r0
mul r0.xyw, r0.x, c2.xyzz
mul r4.xyz, r0.xyww, r0.z
dp3 r0.z, r2, r3
mul r4.xyz, r4, r1.w
mad r2.xy, v0, c5, c5.zwzw
max r1.w, r0.z, c8.x
texld r0.z, r2, s3
mul r0.z, r0, c6.x
add r2.xyz, -r1, c3
mad r1.xyz, r0.z, r2, r1
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_OFF" }
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedejhknidolbabcenogfhjioapaccakbgeabaaaaaabeahaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcamagaaaaeaaaaaaaidabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaamhcaabaaaaaaaaaaa
pgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaacaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaabaaaaaaegbcbaia
ebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaakdcaabaaa
aaaaaaaamgaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
cpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafccaabaaaaaaaaaaabkaabaaa
aaaaaaaaaoaaaaahmcaabaaaaaaaaaaaagbebaaaaeaaaaaapgbpbaaaaeaaaaaa
aaaaaaakmcaabaaaaaaaaaaakgaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaadpaaaaaadpefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadbaaaaahecaabaaaaaaaaaaaabeaaaaaaaaaaaaa
ckbabaaaaeaaaaaaabaaaaahecaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaiadpdiaaaaahecaabaaaaaaaaaaadkaabaaaabaaaaaackaabaaaaaaaaaaa
baaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaapgapbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaahecaabaaaaaaaaaaackaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaai
hcaabaaaabaaaaaakgakbaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadiaaaaah
ocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaaabaaaaaadiaaaaahhcaabaaa
abaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaldcaabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaa
ajaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaa
dcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaa
ogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaa
eghobaaaadaaaaaaaagabaaaadaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaa
adaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaia
ebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaajhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTextureB0] 2D 0
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
DP3 R1.w, fragment.texcoord[3], fragment.texcoord[3];
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.w, R0, R1;
DP3 R0.z, R0, R2;
MAX R0.w, R0, c[8].x;
POW R2.w, R0.w, c[8].y;
MAD R1.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R1.xyz, R1, texture[2], 2D;
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
TEX R0.w, fragment.texcoord[3], texture[1], CUBE;
TEX R1.w, R1.w, texture[0], 2D;
MUL R1.w, R1, R0;
MUL R3.xyz, R1.w, c[2];
MUL R0.w, R1.x, c[7].x;
MUL R4.xyz, R3, R2.w;
MUL R4.xyz, R4, R0.w;
MAX R0.w, R0.z, c[8].x;
TEX R0.z, R0, texture[3], 2D;
ADD R2.xyz, -R1, c[3];
MUL R0.x, R0.z, c[6];
MAD R0.xyz, R0.x, R2, R1;
MUL R1.xyz, R0.w, R3;
MAD result.color.xyz, R1, R0, R4;
MOV result.color.w, c[8].x;
END
# 37 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTextureB0] 2D 0
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"ps_3_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
dcl_2d s3
def c8, 0.00000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.x, r2, r0
max r1.x, r0, c8
pow r0, r1.x, c8.y
mov r0.z, r0.x
mad r1.xy, v0, c4, c4.zwzw
texld r1.xyz, r1, s2
dp3 r0.x, v3, v3
mul r1.w, r1.x, c7.x
texld r0.w, v3, s1
texld r0.x, r0.x, s0
mul r0.x, r0, r0.w
mul r0.xyw, r0.x, c2.xyzz
mul r4.xyz, r0.xyww, r0.z
dp3 r0.z, r2, r3
mul r4.xyz, r4, r1.w
mad r2.xy, v0, c5, c5.zwzw
max r1.w, r0.z, c8.x
texld r0.z, r2, s3
mul r0.z, r0, c6.x
add r2.xyz, -r1, c3
mad r1.xyz, r0.z, r2, r1
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
SetTexture 0 [_LightTextureB0] 2D 1
SetTexture 1 [_LightTexture0] CUBE 0
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedbfkiiihggeacgaenijibnapdbhmodcccabaaaaaahmagaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcheafaaaaeaaaaaaafnabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fidaaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaamhcaabaaaaaaaaaaa
pgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaacaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaabaaaaaaegbcbaia
ebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaakdcaabaaa
aaaaaaaamgaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
cpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafccaabaaaaaaaaaaabkaabaaa
aaaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaa
efaaaaajpcaabaaaabaaaaaakgakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaegbcbaaaaeaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahecaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaa
acaaaaaadiaaaaaihcaabaaaabaaaaaakgakbaaaaaaaaaaaegiccaaaaaaaaaaa
afaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaaabaaaaaa
diaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaacaaaaaa
bkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaa
jgahbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaadaaaaaa
egaabaaaadaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaadiaaaaaiicaabaaa
aaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
dcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.w, R0, R1;
DP3 R0.z, R0, R2;
MAX R0.w, R0, c[8].x;
POW R2.w, R0.w, c[8].y;
TEX R0.w, fragment.texcoord[3], texture[0], 2D;
MUL R3.xyz, R0.w, c[2];
MAD R1.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R1.xyz, R1, texture[1], 2D;
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAX R0.w, R0.z, c[8].x;
TEX R0.z, R0, texture[2], 2D;
MUL R1.w, R1.x, c[7].x;
MUL R4.xyz, R3, R2.w;
ADD R2.xyz, -R1, c[3];
MUL R0.x, R0.z, c[6];
MAD R0.xyz, R0.x, R2, R1;
MUL R4.xyz, R4, R1.w;
MUL R1.xyz, R0.w, R3;
MAD result.color.xyz, R1, R0, R4;
MOV result.color.w, c[8].x;
END
# 34 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c8, 0.00000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xy
mad_pp r1.xyz, -v1, c1.w, c1
dp3_pp r0.w, r1, r1
add r0.xyz, -v1, c0
rsq_pp r0.w, r0.w
mul_pp r2.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r2
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.w, r0, r1
dp3 r0.z, r0, r2
max r0.w, r0, c8.x
pow r1, r0.w, c8.y
mad r0.xy, v0, c5, c5.zwzw
mad r3.xy, v0, c4, c4.zwzw
mov r2.w, r1.x
texld r1.xyz, r3, s1
texld r0.w, v3, s0
mul r3.xyz, r0.w, c2
max r0.w, r0.z, c8.x
texld r0.z, r0, s2
mul r1.w, r1.x, c7.x
mul r4.xyz, r3, r2.w
add r2.xyz, -r1, c3
mul r0.x, r0.z, c6
mad r0.xyz, r0.x, r2, r1
mul r4.xyz, r4, r1.w
mul r1.xyz, r0.w, r3
mad oC0.xyz, r1, r0, r4
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedmajghplffocicjgchjpaffjnmpojmjkgabaaaaaaaeagaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapahaaaaimaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcpmaeaaaaeaaaaaaadpabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaamhcaabaaa
aaaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaabaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaak
dcaabaaaaaaaaaaamgaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaapgapbaaaabaaaaaa
egiccaaaaaaaaaaaafaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agajbaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
ahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaa
acaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaacaaaaaabkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaa
agaabaaaaaaaaaaajgahbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaa
diaaaaaiicaabaaaaaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaa
aaaaaaajhcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaa
agaaaaaadcaaaaajhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaa
egacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Color]
Vector 5 [_Diffus_ST]
Vector 6 [_Mask_ST]
Float 7 [_Blend]
Float 8 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"3.0-!!ARBfp1.0
PARAM c[10] = { program.local[0..8],
		{ 0, 0.5, 1, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
DP3 R1.w, fragment.texcoord[3], fragment.texcoord[3];
MUL R0.xyz, R1.x, R0;
MUL R2.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R2, R0;
MAX R0.z, R0.x, c[9].x;
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
TEX R1.xyz, R0, texture[3], 2D;
POW R0.z, R0.z, c[9].w;
TXP R0.x, fragment.texcoord[4], texture[2], 2D;
RCP R0.y, fragment.texcoord[4].w;
MAD R0.w, -fragment.texcoord[4].z, R0.y, R0.x;
MOV R0.x, c[9].z;
CMP R2.w, R0, c[2].x, R0.x;
RCP R0.y, fragment.texcoord[3].w;
MAD R0.xy, fragment.texcoord[3], R0.y, c[9].y;
TEX R0.w, R0, texture[0], 2D;
SLT R0.x, c[9], fragment.texcoord[3].z;
MUL R0.x, R0, R0.w;
TEX R1.w, R1.w, texture[1], 2D;
MUL R0.x, R0, R1.w;
MUL R0.x, R0, R2.w;
MUL R0.xyw, R0.x, c[3].xyzz;
MUL R4.xyz, R0.xyww, R0.z;
DP3 R0.z, R2, R3;
MUL R1.w, R1.x, c[8].x;
MUL R4.xyz, R4, R1.w;
MAD R2.xy, fragment.texcoord[0], c[6], c[6].zwzw;
MAX R1.w, R0.z, c[9].x;
TEX R0.z, R2, texture[4], 2D;
MUL R0.z, R0, c[7].x;
ADD R2.xyz, -R1, c[4];
MAD R1.xyz, R0.z, R2, R1;
MUL R0.xyz, R1.w, R0.xyww;
MAD result.color.xyz, R0, R1, R4;
MOV result.color.w, c[9].x;
END
# 47 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Color]
Vector 5 [_Diffus_ST]
Vector 6 [_Mask_ST]
Float 7 [_Blend]
Float 8 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c9, 0.00000000, 1.00000000, 0.50000000, 64.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
dcl_texcoord4 v4
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.x, r2, r0
max r1.x, r0, c9
pow r0, r1.x, c9.w
mov r0.z, r0.x
mad r1.xy, v0, c5, c5.zwzw
texld r1.xyz, r1, s3
texldp r0.x, v4, s2
rcp r0.y, v4.w
mad r0.y, -v4.z, r0, r0.x
mov r0.w, c2.x
rcp r0.x, v3.w
mad r4.xy, v3, r0.x, c9.z
cmp r0.y, r0, c9, r0.w
dp3 r0.x, v3, v3
texld r0.w, r4, s0
cmp r1.w, -v3.z, c9.x, c9.y
mul_pp r0.w, r1, r0
texld r0.x, r0.x, s1
mul_pp r0.x, r0.w, r0
mul_pp r0.x, r0, r0.y
mul r0.xyw, r0.x, c3.xyzz
mul r4.xyz, r0.xyww, r0.z
dp3 r0.z, r2, r3
mul r1.w, r1.x, c8.x
mul r4.xyz, r4, r1.w
mad r2.xy, v0, c6, c6.zwzw
max r1.w, r0.z, c9.x
texld r0.z, r2, s4
mul r0.z, r0, c7.x
add r2.xyz, -r1, c4
mad r1.xyz, r0.z, r2, r1
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c9.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_ShadowMapTexture] 2D 0
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedanggkiceocjhhojfdjmpaaldkglfephiabaaaaaabeaiaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcpeagaaaa
eaaaaaaalnabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaa
aeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaa
aeaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
aeaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaaeaaaaaapgbpbaaaaeaaaaaa
aaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadbaaaaahbcaabaaaaaaaaaaaabeaaaaaaaaaaaaa
ckbabaaaaeaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaiadpdiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaaaaaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaaaoaaaaah
ocaabaaaaaaaaaaaagbjbaaaafaaaaaapgbpbaaaafaaaaaaefaaaaajpcaabaaa
abaaaaaajgafbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadbaaaaah
ccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaaaaaaaaaadhaaaaakccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaadaaaaaabiaaaaaaabeaaaaaaaaaiadp
diaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaam
hcaabaaaabaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaacaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaajhcaabaaa
acaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaacaaaaaaegacbaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaadaaaaaapgapbaaaaaaaaaaa
egbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaa
adaaaaaabaaaaaahbcaabaaaabaaaaaaegacbaaaadaaaaaaegacbaaaabaaaaaa
deaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaaaaaaaaaagaabaaaabaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaiaecbjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
adaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaa
ajaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaa
ogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaa
eghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaa
adaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaia
ebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaajhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Color]
Vector 5 [_Diffus_ST]
Vector 6 [_Mask_ST]
Float 7 [_Blend]
Float 8 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[10] = { program.local[0..8],
		{ 0, 0.5, 1, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
DP3 R1.w, fragment.texcoord[3], fragment.texcoord[3];
MUL R0.xyz, R1.x, R0;
MUL R2.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R2, R0;
MAX R0.z, R0.x, c[9].x;
MAD R0.xy, fragment.texcoord[0], c[5], c[5].zwzw;
TEX R1.xyz, R0, texture[3], 2D;
MOV R0.x, c[9].z;
ADD R0.w, R0.x, -c[2].x;
TXP R0.x, fragment.texcoord[4], texture[2], SHADOW2D;
MAD R2.w, R0.x, R0, c[2].x;
RCP R0.y, fragment.texcoord[3].w;
MAD R0.xy, fragment.texcoord[3], R0.y, c[9].y;
TEX R0.w, R0, texture[0], 2D;
SLT R0.x, c[9], fragment.texcoord[3].z;
MUL R0.x, R0, R0.w;
TEX R1.w, R1.w, texture[1], 2D;
MUL R0.x, R0, R1.w;
MUL R0.x, R0, R2.w;
MUL R1.w, R1.x, c[8].x;
POW R0.z, R0.z, c[9].w;
MUL R0.xyw, R0.x, c[3].xyzz;
MUL R4.xyz, R0.xyww, R0.z;
DP3 R0.z, R2, R3;
MUL R4.xyz, R4, R1.w;
MAD R2.xy, fragment.texcoord[0], c[6], c[6].zwzw;
MAX R1.w, R0.z, c[9].x;
TEX R0.z, R2, texture[4], 2D;
MUL R0.z, R0, c[7].x;
ADD R2.xyz, -R1, c[4];
MAD R1.xyz, R0.z, R2, R1;
MUL R0.xyz, R1.w, R0.xyww;
MAD result.color.xyz, R0, R1, R4;
MOV result.color.w, c[9].x;
END
# 46 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Color]
Vector 5 [_Diffus_ST]
Vector 6 [_Mask_ST]
Float 7 [_Blend]
Float 8 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c9, 0.00000000, 1.00000000, 0.50000000, 64.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
dcl_texcoord4 v4
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.x, r2, r0
max r1.x, r0, c9
pow r0, r1.x, c9.w
mov r0.z, r0.x
mov r0.x, c2
rcp r0.w, v3.w
mad r4.xy, v3, r0.w, c9.z
add r0.y, c9, -r0.x
texldp r0.x, v4, s2
mad r0.y, r0.x, r0, c2.x
mad r1.xy, v0, c5, c5.zwzw
dp3 r0.x, v3, v3
texld r1.xyz, r1, s3
texld r0.w, r4, s0
cmp r1.w, -v3.z, c9.x, c9.y
mul_pp r0.w, r1, r0
texld r0.x, r0.x, s1
mul_pp r0.x, r0.w, r0
mul_pp r0.x, r0, r0.y
mul r0.xyw, r0.x, c3.xyzz
mul r4.xyz, r0.xyww, r0.z
dp3 r0.z, r2, r3
mul r1.w, r1.x, c8.x
mul r4.xyz, r4, r1.w
mad r2.xy, v0, c6, c6.zwzw
max r1.w, r0.z, c9.x
texld r0.z, r2, s4
mul r0.z, r0, c7.x
add r2.xyz, -r1, c4
mad r1.xyz, r0.z, r2, r1
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c9.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_Diffus] 2D 3
SetTexture 3 [_Mask] 2D 4
SetTexture 4 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedmkpkilhbomajcbdealllkannagnbocjmabaaaaaaceaiaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcaeahaaaa
eaaaaaaambabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaiaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaa
aeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaa
aeaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
aeaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaaeaaaaaapgbpbaaaaeaaaaaa
aaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadbaaaaahbcaabaaaaaaaaaaaabeaaaaaaaaaaaaa
ckbabaaaaeaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaiadpdiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaaaaaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaaaoaaaaah
ocaabaaaaaaaaaaaagbjbaaaafaaaaaapgbpbaaaafaaaaaaehaaaaalccaabaaa
aaaaaaaajgafbaaaaaaaaaaaaghabaaaaeaaaaaaaagabaaaaaaaaaaadkaabaaa
aaaaaaaaaaaaaaajecaabaaaaaaaaaaaakiacaiaebaaaaaaadaaaaaabiaaaaaa
abeaaaaaaaaaiadpdcaaaaakccaabaaaaaaaaaaabkaabaaaaaaaaaaackaabaaa
aaaaaaaaakiacaaaadaaaaaabiaaaaaadiaaaaahbcaabaaaaaaaaaaabkaabaaa
aaaaaaaaakaabaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaafaaaaaadcaaaaamhcaabaaaabaaaaaapgipcaaaacaaaaaa
aaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaacaaaaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaaaaaaaaajhcaabaaaacaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaacaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaaj
hcaabaaaacaaaaaaegacbaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaa
aaaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaadaaaaaa
egbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaadaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaabaaaaaahbcaabaaaabaaaaaa
egacbaaaadaaaaaaegacbaaaabaaaaaadeaaaaahbcaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaaaaaaaaa
agaabaaaabaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaaaaacpaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
ahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaa
acaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaadiaaaaaiicaabaaaaaaaaaaa
akaabaaaacaaaaaabkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaaadaaaaaaaagabaaaaeaaaaaa
diaaaaaiicaabaaaaaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaa
aaaaaaajhcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaa
agaaaaaadcaaaaajhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaa
egacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
MUL R0.xyz, R1.x, R0;
MUL R2.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R2, R0;
MAX R0.z, R0.x, c[8].x;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R1.xyz, R0, texture[1], 2D;
POW R1.w, R0.z, c[8].y;
TXP R0.x, fragment.texcoord[3], texture[0], 2D;
MUL R0.xyw, R0.x, c[2].xyzz;
MUL R0.z, R1.x, c[7].x;
MUL R4.xyz, R0.xyww, R1.w;
MUL R4.xyz, R4, R0.z;
DP3 R0.z, R2, R3;
MAD R2.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAX R1.w, R0.z, c[8].x;
TEX R0.z, R2, texture[2], 2D;
MUL R0.z, R0, c[6].x;
ADD R2.xyz, -R1, c[3];
MAD R1.xyz, R0.z, R2, R1;
MUL R0.xyz, R1.w, R0.xyww;
MAD result.color.xyz, R0, R1, R4;
MOV result.color.w, c[8].x;
END
# 34 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c8, 0.00000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
mad_pp r1.xyz, -v1, c1.w, c1
dp3_pp r0.w, r1, r1
add r0.xyz, -v1, c0
rsq_pp r0.w, r0.w
mul_pp r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.x, r2, r0
max r1.x, r0, c8
pow r0, r1.x, c8.y
mov r1.w, r0.x
mad r1.xy, v0, c4, c4.zwzw
texld r1.xyz, r1, s1
texldp r0.x, v3, s0
mul r0.xyw, r0.x, c2.xyzz
mul r0.z, r1.x, c7.x
mul r4.xyz, r0.xyww, r1.w
mul r4.xyz, r4, r0.z
dp3 r0.z, r2, r3
mad r2.xy, v0, c5, c5.zwzw
max r1.w, r0.z, c8.x
texld r0.z, r2, s2
mul r0.z, r0, c6.x
add r2.xyz, -r1, c3
mad r1.xyz, r0.z, r2, r1
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffus] 2D 1
SetTexture 2 [_Mask] 2D 2
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedgelhjfjfdjhabcjbngmebdnlcknnbblkabaaaaaacaagaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcbiafaaaaeaaaaaaaegabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaamhcaabaaa
aaaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaabaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaak
dcaabaaaaaaaaaaamgaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaaoaaaaahmcaabaaaaaaaaaaaagbebaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
aaaaaaaaafaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaa
acaaaaaabkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaa
aaaaaaaajgahbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
adaaaaaaegaabaaaadaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaai
icaabaaaaaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaaj
hcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaa
dcaaaaajhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaa
acaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, fragment.texcoord[2];
MUL R0.xyz, R1.x, R0;
DP3 R0.x, R2, R0;
MAX R0.z, R0.x, c[8].x;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R1.xyz, R0, texture[2], 2D;
POW R1.w, R0.z, c[8].y;
MUL R0.z, R1.x, c[7].x;
TEX R0.w, fragment.texcoord[3], texture[1], 2D;
TXP R0.x, fragment.texcoord[4], texture[0], 2D;
MUL R0.x, R0.w, R0;
MUL R0.xyw, R0.x, c[2].xyzz;
MUL R4.xyz, R0.xyww, R1.w;
MUL R4.xyz, R4, R0.z;
DP3 R0.z, R2, R3;
MAD R2.xy, fragment.texcoord[0], c[5], c[5].zwzw;
MAX R1.w, R0.z, c[8].x;
TEX R0.z, R2, texture[3], 2D;
MUL R0.z, R0, c[6].x;
ADD R2.xyz, -R1, c[3];
MAD R1.xyz, R0.z, R2, R1;
MUL R0.xyz, R1.w, R0.xyww;
MAD result.color.xyz, R0, R1, R4;
MOV result.color.w, c[8].x;
END
# 36 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightColor0]
Vector 3 [_Color]
Vector 4 [_Diffus_ST]
Vector 5 [_Mask_ST]
Float 6 [_Blend]
Float 7 [_Specular]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c8, 0.00000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xy
dcl_texcoord4 v4
mad_pp r1.xyz, -v1, c1.w, c1
dp3_pp r0.w, r1, r1
add r0.xyz, -v1, c0
rsq_pp r0.w, r0.w
mul_pp r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.x, r2, r0
max r1.x, r0, c8
pow r0, r1.x, c8.y
mov r0.z, r0.x
mad r1.xy, v0, c4, c4.zwzw
texld r1.xyz, r1, s2
mul r1.w, r1.x, c7.x
texld r0.w, v3, s1
texldp r0.x, v4, s0
mul r0.x, r0.w, r0
mul r0.xyw, r0.x, c2.xyzz
mul r4.xyz, r0.xyww, r0.z
dp3 r0.z, r2, r3
mul r4.xyz, r4, r1.w
mad r2.xy, v0, c5, c5.zwzw
max r1.w, r0.z, c8.x
texld r0.z, r2, s3
mul r0.z, r0, c6.x
add r2.xyz, -r1, c3
mad r1.xyz, r0.z, r2, r1
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_ShadowMapTexture] 2D 0
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
ConstBuffer "$Globals" 224
Vector 144 [_LightColor0]
Vector 160 [_Color]
Vector 176 [_Diffus_ST]
Vector 192 [_Mask_ST]
Float 208 [_Blend]
Float 212 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
"ps_4_0
eefiecedagpjjdbelcpiahjlegjgijkgmeapckelabaaaaaakaagaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapahaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefciaafaaaa
eaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaaaoaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaamhcaabaaa
aaaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaabaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaak
dcaabaaaaaaaaaaamgaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaaoaaaaahmcaabaaaaaaaaaaaagbebaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaahecaabaaaaaaaaaaaakaabaaaabaaaaaa
dkaabaaaacaaaaaadiaaaaaihcaabaaaabaaaaaakgakbaaaaaaaaaaaegiccaaa
aaaaaaaaajaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaalaaaaaa
ogikcaaaaaaaaaaaalaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaa
acaaaaaabkiacaaaaaaaaaaaanaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaa
aaaaaaaajgahbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaamaaaaaaogikcaaaaaaaaaaaamaaaaaaefaaaaajpcaabaaa
adaaaaaaegaabaaaadaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaadiaaaaai
icaabaaaaaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaaanaaaaaaaaaaaaaj
hcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaaaaaaaaaakaaaaaa
dcaaaaajhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaa
acaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"3.0-!!ARBfp1.0
PARAM c[12] = { program.local[0..9],
		{ 0, 0.97000003, 1, 64 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R4.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R4;
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.w, R0, R1;
DP3 R0.z, R0, R4;
TEX R1, fragment.texcoord[4], texture[0], CUBE;
MAX R0.w, R0, c[10].x;
POW R2.w, R0.w, c[10].w;
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
DP4 R1.y, R1, c[11];
RSQ R0.w, R0.w;
RCP R1.x, R0.w;
MUL R1.x, R1, c[2].w;
MAD R0.xy, fragment.texcoord[0], c[7], c[7].zwzw;
MOV R0.w, c[10].z;
MAD R1.x, -R1, c[10].y, R1.y;
CMP R1.z, R1.x, c[3].x, R0.w;
DP3 R0.w, fragment.texcoord[3], fragment.texcoord[3];
TEX R0.w, R0.w, texture[1], 2D;
MUL R0.w, R0, R1.z;
MUL R2.xyz, R0.w, c[4];
MAD R1.xy, fragment.texcoord[0], c[6], c[6].zwzw;
TEX R1.xyz, R1, texture[2], 2D;
MUL R0.w, R1.x, c[9].x;
MUL R3.xyz, R2, R2.w;
MUL R3.xyz, R3, R0.w;
MAX R0.w, R0.z, c[10].x;
TEX R0.z, R0, texture[3], 2D;
ADD R4.xyz, -R1, c[5];
MUL R0.x, R0.z, c[8];
MAD R0.xyz, R0.x, R4, R1;
MUL R1.xyz, R0.w, R2;
MAD result.color.xyz, R1, R0, R3;
MOV result.color.w, c[10].x;
END
# 45 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c10, 0.00000000, 0.97000003, 1.00000000, 64.00000000
def c11, 1.00000000, 0.00392157, 0.00001538, 0.00000006
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
dp3 r2.x, v4, v4
mul r4.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r4
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.w, r0, r1
dp3 r0.z, r0, r4
max r0.w, r0, c10.x
pow r1, r0.w, c10.w
mov r0.w, r1.x
texld r1, v4, s0
dp4 r1.y, r1, c11
rsq r2.x, r2.x
rcp r1.x, r2.x
mul r1.x, r1, c2.w
mad r1.x, -r1, c10.y, r1.y
mov r1.z, c3.x
cmp r1.y, r1.x, c10.z, r1.z
dp3 r1.x, v3, v3
texld r1.x, r1.x, s1
mul r1.w, r1.x, r1.y
mad r2.xy, v0, c6, c6.zwzw
texld r1.xyz, r2, s2
mul r2.xyz, r1.w, c4
mul r3.xyz, r2, r0.w
mul r1.w, r1.x, c9.x
mad r0.xy, v0, c7, c7.zwzw
max r0.w, r0.z, c10.x
texld r0.z, r0, s3
add r4.xyz, -r1, c5
mul r0.x, r0.z, c8
mad r0.xyz, r0.x, r4, r1
mul r3.xyz, r3, r1.w
mul r1.xyz, r0.w, r2
mad oC0.xyz, r1, r0, r3
mov_pp oC0.w, c10.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_ShadowMapTexture] CUBE 0
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedknaiggnadaglfjhiikfaelnnokpcacbnabaaaaaaiiahaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgiagaaaa
eaaaaaaajkabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaacaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacaeaaaaaadcaaaaamhcaabaaaaaaaaaaapgipcaaaacaaaaaaaaaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaacaaaaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
abaaaaaaaeaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaa
abaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
acaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaaaaaaaaadeaaaaakdcaabaaaaaaaaaaamgaabaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacpaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
aaaaiaecbjaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaabaaaaaahecaabaaa
aaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaaelaaaaafecaabaaaaaaaaaaa
ckaabaaaaaaaaaaadiaaaaaiecaabaaaaaaaaaaackaabaaaaaaaaaaadkiacaaa
acaaaaaaabaaaaaadiaaaaahecaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
omfbhidpefaaaaajpcaabaaaabaaaaaaegbcbaaaafaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaabbaaaaakicaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaa
aaaaiadpibiaiadlicabibdhafidibdddbaaaaahecaabaaaaaaaaaaadkaabaaa
aaaaaaaackaabaaaaaaaaaaadhaaaaakecaabaaaaaaaaaaackaabaaaaaaaaaaa
akiacaaaadaaaaaabiaaaaaaabeaaaaaaaaaiadpbaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaapgapbaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaahecaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaakgakbaaa
aaaaaaaaegiccaaaaaaaaaaaafaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaa
aaaaaaaaagajbaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaa
egaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaaibcaabaaa
aaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaaajaaaaaadiaaaaahhcaabaaa
aaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadcaaaaaldcaabaaaadaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
efaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaaadaaaaaaaagabaaa
adaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaaadaaaaaaakiacaaaaaaaaaaa
ajaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaa
aaaaaaaaagaaaaaadcaaaaajhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"3.0-!!ARBfp1.0
PARAM c[12] = { program.local[0..9],
		{ 0, 0.97000003, 1, 64 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R0.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R0, R0;
ADD R1.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R1.w, R1, R1;
RSQ R0.w, R1.w;
MAD R1.xyz, R0.w, R1, R0;
DP3 R1.w, R1, R1;
RSQ R1.w, R1.w;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
MUL R2.xyz, R1.w, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.w, R1, R2;
DP3 R0.z, R1, R0;
TEX R2, fragment.texcoord[4], texture[0], CUBE;
MAX R0.w, R0, c[10].x;
POW R3.w, R0.w, c[10].w;
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R0.w, R0.w;
RCP R1.w, R0.w;
DP4 R2.x, R2, c[11];
MUL R1.w, R1, c[2];
MAD R1.w, -R1, c[10].y, R2.x;
MOV R0.w, c[10].z;
CMP R2.z, R1.w, c[3].x, R0.w;
DP3 R1.w, fragment.texcoord[3], fragment.texcoord[3];
MAD R0.xy, fragment.texcoord[0], c[7], c[7].zwzw;
MAD R2.xy, fragment.texcoord[0], c[6], c[6].zwzw;
TEX R0.w, fragment.texcoord[3], texture[2], CUBE;
TEX R1.w, R1.w, texture[1], 2D;
MUL R0.w, R1, R0;
MUL R0.w, R0, R2.z;
TEX R2.xyz, R2, texture[3], 2D;
MUL R3.xyz, R0.w, c[4];
MUL R0.w, R2.x, c[9].x;
MUL R4.xyz, R3, R3.w;
MUL R4.xyz, R4, R0.w;
MAX R0.w, R0.z, c[10].x;
TEX R0.z, R0, texture[4], 2D;
ADD R1.xyz, -R2, c[5];
MUL R0.x, R0.z, c[8];
MAD R0.xyz, R0.x, R1, R2;
MUL R1.xyz, R0.w, R3;
MAD result.color.xyz, R1, R0, R4;
MOV result.color.w, c[10].x;
END
# 47 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_cube s2
dcl_2d s3
dcl_2d s4
def c10, 0.00000000, 0.97000003, 1.00000000, 64.00000000
def c11, 1.00000000, 0.00392157, 0.00001538, 0.00000006
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
dp3 r2.w, v4, v4
mad r3.xy, v0, c6, c6.zwzw
mul r2.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r2
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
mul r0.xyz, r1.x, r0
rsq r0.w, r0.w
mul r1.xyz, r0.w, v2
dp3 r0.x, r1, r0
max r1.w, r0.x, c10.x
pow r0, r1.w, c10.w
mov r1.w, r0.x
texld r0, v4, s0
dp4 r0.y, r0, c11
rsq r2.w, r2.w
rcp r0.x, r2.w
mul r0.x, r0, c2.w
mad r0.x, -r0, c10.y, r0.y
mov r0.z, c3.x
cmp r0.y, r0.x, c10.z, r0.z
texld r3.xyz, r3, s3
dp3 r0.x, v3, v3
texld r0.w, v3, s2
texld r0.x, r0.x, s1
mul r0.x, r0, r0.w
mul r0.x, r0, r0.y
mul r0.xyw, r0.x, c4.xyzz
mul r4.xyz, r0.xyww, r1.w
mul r0.z, r3.x, c9.x
mul r4.xyz, r4, r0.z
dp3 r0.z, r1, r2
mad r1.xy, v0, c7, c7.zwzw
max r1.w, r0.z, c10.x
texld r0.z, r1, s4
mul r0.z, r0, c8.x
add r1.xyz, -r3, c5
mad r1.xyz, r0.z, r1, r3
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c10.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
SetTexture 0 [_LightTextureB0] 2D 2
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_ShadowMapTexture] CUBE 0
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedgkeongogdgcehlicihfnimklbbllcnpbabaaaaaapeahaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcneagaaaa
eaaaaaaalfabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaacaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaa
aeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaa
ffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
aeaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaa
elaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkiacaaaacaaaaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaomfbhidpefaaaaajpcaabaaaabaaaaaaegbcbaaa
afaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaabbaaaaakccaabaaaaaaaaaaa
egaobaaaabaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdhafidibdddbaaaaah
bcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaadhaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakiacaaaadaaaaaabiaaaaaaabeaaaaaaaaaiadp
baaaaaahccaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaegbcbaaaaeaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadiaaaaahccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaaacaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaam
hcaabaaaabaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaacaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaajhcaabaaa
acaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaacaaaaaaegacbaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaadaaaaaapgapbaaaaaaaaaaa
egbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaa
adaaaaaabaaaaaahbcaabaaaabaaaaaaegacbaaaadaaaaaaegacbaaaabaaaaaa
deaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaaaaaaaaaagaabaaaabaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaiaecbjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
adaaaaaadiaaaaaiicaabaaaaaaaaaaaakaabaaaacaaaaaabkiacaaaaaaaaaaa
ajaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaaldcaabaaaadaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaa
ogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaa
eghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaa
adaaaaaaakiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaaadaaaaaaegacbaia
ebaaaaaaacaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaajhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaadcaaaaajhccabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
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
Vector 8 [_Color]
Vector 9 [_Diffus_ST]
Vector 10 [_Mask_ST]
Float 11 [_Blend]
Float 12 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"3.0-!!ARBfp1.0
PARAM c[15] = { program.local[0..12],
		{ 0, 0.5, 1, 0.25 },
		{ 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
RCP R2.w, fragment.texcoord[4].w;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R2;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.z, R1, R0;
MAD R0.xy, fragment.texcoord[4], R2.w, c[6];
TEX R0.x, R0, texture[2], 2D;
MAX R1.w, R0.z, c[13].x;
MAD R3.xy, fragment.texcoord[4], R2.w, c[5];
MOV R0.w, R0.x;
TEX R0.x, R3, texture[2], 2D;
MAD R3.xy, fragment.texcoord[4], R2.w, c[4];
MOV R0.z, R0.x;
TEX R0.x, R3, texture[2], 2D;
MAD R3.xy, fragment.texcoord[4], R2.w, c[3];
MOV R0.y, R0.x;
TEX R0.x, R3, texture[2], 2D;
MAD R0, -fragment.texcoord[4].z, R2.w, R0;
MOV R3.x, c[13].z;
CMP R0, R0, c[2].x, R3.x;
DP4 R3.x, R0, c[13].w;
POW R2.w, R1.w, c[14].x;
RCP R0.z, fragment.texcoord[3].w;
MAD R0.zw, fragment.texcoord[3].xyxy, R0.z, c[13].y;
TEX R0.w, R0.zwzw, texture[0], 2D;
DP3 R1.w, fragment.texcoord[3], fragment.texcoord[3];
SLT R0.z, c[13].x, fragment.texcoord[3];
MUL R0.z, R0, R0.w;
TEX R1.w, R1.w, texture[1], 2D;
MUL R0.z, R0, R1.w;
MUL R0.z, R0, R3.x;
MAD R0.xy, fragment.texcoord[0], c[9], c[9].zwzw;
TEX R3.xyz, R0, texture[3], 2D;
MUL R0.xyw, R0.z, c[7].xyzz;
MUL R0.z, R3.x, c[12].x;
MUL R4.xyz, R0.xyww, R2.w;
MUL R4.xyz, R4, R0.z;
DP3 R0.z, R1, R2;
MAD R1.xy, fragment.texcoord[0], c[10], c[10].zwzw;
MAX R1.w, R0.z, c[13].x;
TEX R0.z, R1, texture[4], 2D;
MUL R0.z, R0, c[11].x;
ADD R1.xyz, -R3, c[8];
MAD R1.xyz, R0.z, R1, R3;
MUL R0.xyz, R1.w, R0.xyww;
MAD result.color.xyz, R0, R1, R4;
MOV result.color.w, c[13].x;
END
# 58 instructions, 5 R-regs
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
Vector 8 [_Color]
Vector 9 [_Diffus_ST]
Vector 10 [_Mask_ST]
Float 11 [_Blend]
Float 12 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c13, 0.00000000, 1.00000000, 0.50000000, 0.25000000
def c14, 64.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
dcl_texcoord4 v4
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r2.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r2
rcp r1.w, v4.w
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
mul r0.xyz, r1.x, r0
rsq r0.w, r0.w
mul r1.xyz, r0.w, v2
dp3 r0.x, r1, r0
max r0.x, r0, c13
pow r3, r0.x, c14.x
mad r0.xy, v4, r1.w, c6
texld r0.x, r0, s2
mad r4.xy, v4, r1.w, c5
mov r0.w, r0.x
texld r0.x, r4, s2
mad r4.xy, v4, r1.w, c4
mov r0.z, r0.x
texld r0.x, r4, s2
mad r4.xy, v4, r1.w, c3
mov r0.y, r0.x
texld r0.x, r4, s2
mad r0, -v4.z, r1.w, r0
mov r1.w, r3.x
mov r2.w, c2.x
cmp r0, r0, c13.y, r2.w
dp4_pp r0.y, r0, c13.w
rcp r0.x, v3.w
mad r4.xy, v3, r0.x, c13.z
mad r3.xy, v0, c9, c9.zwzw
dp3 r0.x, v3, v3
texld r0.w, r4, s0
cmp r0.z, -v3, c13.x, c13.y
mul_pp r0.z, r0, r0.w
texld r0.x, r0.x, s1
mul_pp r0.x, r0.z, r0
texld r3.xyz, r3, s3
mul_pp r0.x, r0, r0.y
mul r0.xyw, r0.x, c7.xyzz
mul r4.xyz, r0.xyww, r1.w
mul r0.z, r3.x, c12.x
mul r4.xyz, r4, r0.z
dp3 r0.z, r1, r2
mad r1.xy, v0, c10, c10.zwzw
max r1.w, r0.z, c13.x
texld r0.z, r1, s4
mul r0.z, r0, c11.x
add r1.xyz, -r3, c8
mad r1.xyz, r0.z, r1, r3
mul r0.xyz, r1.w, r0.xyww
mad oC0.xyz, r0, r1, r4
mov_pp oC0.w, c13.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_ShadowMapTexture] 2D 0
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
ConstBuffer "$Globals" 224
Vector 16 [_ShadowOffsets0]
Vector 32 [_ShadowOffsets1]
Vector 48 [_ShadowOffsets2]
Vector 64 [_ShadowOffsets3]
Vector 144 [_LightColor0]
Vector 160 [_Color]
Vector 176 [_Diffus_ST]
Vector 192 [_Mask_ST]
Float 208 [_Blend]
Float 212 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedobdccdpbabgdfmdhlolejhophkddlcngabaaaaaahaajaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfaaiaaaa
eaaaaaaabeacaaaafjaaaaaeegiocaaaaaaaaaaaaoaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaa
aeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaa
aeaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
afaaaaaaaoaaaaahhcaabaaaaaaaaaaaegbcbaaaafaaaaaapgbpbaaaafaaaaaa
aaaaaaaidcaabaaaabaaaaaaegaabaaaaaaaaaaaegiacaaaaaaaaaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaaaagabaaa
aaaaaaaaaaaaaaaidcaabaaaacaaaaaaegaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaa
aagabaaaaaaaaaaadgaaaaafccaabaaaabaaaaaaakaabaaaacaaaaaaaaaaaaai
dcaabaaaacaaaaaaegaabaaaaaaaaaaaegiacaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaa
dgaaaaafecaabaaaabaaaaaaakaabaaaacaaaaaaaaaaaaaidcaabaaaaaaaaaaa
egaabaaaaaaaaaaaegiacaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaacaaaaaa
egaabaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadgaaaaaficaabaaa
abaaaaaaakaabaaaacaaaaaadbaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgakbaaaaaaaaaaadhaaaaanpcaabaaaaaaaaaaaegaobaaaaaaaaaaaagiacaaa
adaaaaaabiaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpbbaaaaak
bcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiado
aaaaiadoaoaaaaahgcaabaaaaaaaaaaaagbbbaaaaeaaaaaapgbpbaaaaeaaaaaa
aaaaaaakgcaabaaaaaaaaaaafgagbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaadp
aaaaaadpaaaaaaaaefaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadbaaaaahccaabaaaaaaaaaaaabeaaaaaaaaaaaaa
ckbabaaaaeaaaaaaabaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
aaaaiadpdiaaaaahccaabaaaaaaaaaaadkaabaaaabaaaaaabkaabaaaaaaaaaaa
baaaaaahecaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaakgakbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
diaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaajaaaaaadcaaaaamhcaabaaa
abaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaa
adaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaajhcaabaaaaeaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaeaaaaaaegacbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaaeaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiaec
bjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaaefaaaaaj
pcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaa
diaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaabkiacaaaaaaaaaaaanaaaaaa
diaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaamaaaaaaogikcaaa
aaaaaaaaamaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
aeaaaaaaaagabaaaaeaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaaacaaaaaa
akiacaaaaaaaaaaaanaaaaaaaaaaaaajhcaabaaaacaaaaaaegacbaiaebaaaaaa
abaaaaaaegiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadcaaaaajhccabaaaaaaaaaaa
egacbaaaadaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
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
Vector 8 [_Color]
Vector 9 [_Diffus_ST]
Vector 10 [_Mask_ST]
Float 11 [_Blend]
Float 12 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"3.0-!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[15] = { program.local[0..12],
		{ 0, 0.5, 1, 0.25 },
		{ 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R3;
DP3 R1.x, R0, R0;
RSQ R1.x, R1.x;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.w;
RCP R1.w, fragment.texcoord[4].w;
MUL R0.xyz, R1.x, R0;
MUL R2.xyz, R0.w, fragment.texcoord[2];
DP3 R0.w, R2, R0;
MAD R0.xyz, fragment.texcoord[4], R1.w, c[6];
MAD R1.xyz, fragment.texcoord[4], R1.w, c[4];
MAX R0.w, R0, c[13].x;
TEX R0.x, R0, texture[2], SHADOW2D;
POW R2.w, R0.w, c[14].x;
MOV R0.w, R0.x;
MAD R0.xyz, fragment.texcoord[4], R1.w, c[5];
TEX R0.x, R0, texture[2], SHADOW2D;
TEX R1.x, R1, texture[2], SHADOW2D;
MOV R0.z, R0.x;
MOV R0.y, R1.x;
MAD R1.xyz, fragment.texcoord[4], R1.w, c[3];
MOV R0.x, c[13].z;
ADD R1.w, R0.x, -c[2].x;
TEX R0.x, R1, texture[2], SHADOW2D;
MAD R0, R0, R1.w, c[2].x;
DP4 R0.z, R0, c[13].w;
RCP R1.x, fragment.texcoord[3].w;
MAD R0.xy, fragment.texcoord[3], R1.x, c[13].y;
TEX R0.w, R0, texture[0], 2D;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
TEX R1.w, R1.x, texture[1], 2D;
SLT R0.x, c[13], fragment.texcoord[3].z;
MUL R0.x, R0, R0.w;
MUL R0.x, R0, R1.w;
MUL R0.x, R0, R0.z;
MUL R0.xyz, R0.x, c[7];
MAD R1.xy, fragment.texcoord[0], c[9], c[9].zwzw;
TEX R1.xyz, R1, texture[3], 2D;
MUL R4.xyz, R0, R2.w;
DP3 R1.w, R2, R3;
MUL R0.w, R1.x, c[12].x;
MUL R2.xyz, R4, R0.w;
MAX R0.w, R1, c[13].x;
MUL R3.xyz, R0.w, R0;
MAD R4.xy, fragment.texcoord[0], c[10], c[10].zwzw;
TEX R0.z, R4, texture[4], 2D;
ADD R4.xyz, -R1, c[8];
MUL R0.x, R0.z, c[11];
MAD R0.xyz, R0.x, R4, R1;
MAD result.color.xyz, R3, R0, R2;
MOV result.color.w, c[13].x;
END
# 58 instructions, 5 R-regs
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
Vector 8 [_Color]
Vector 9 [_Diffus_ST]
Vector 10 [_Mask_ST]
Float 11 [_Blend]
Float 12 [_Specular]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c13, 0.00000000, 1.00000000, 0.50000000, 0.25000000
def c14, 64.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3
dcl_texcoord4 v4
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
rcp r2.w, v4.w
mul r0.xyz, r1.x, r0
mul r2.xyz, r0.w, v2
dp3 r0.x, r2, r0
max r0.x, r0, c13
pow r1, r0.x, c14.x
mad r0.xyz, v4, r2.w, c6
mov r1.w, r1.x
mad r1.xyz, v4, r2.w, c4
texld r0.x, r0, s2
mov_pp r0.w, r0.x
mad r0.xyz, v4, r2.w, c5
texld r0.x, r0, s2
texld r1.x, r1, s2
mov_pp r0.z, r0.x
mov_pp r0.y, r1.x
mad r1.xyz, v4, r2.w, c3
mov r0.x, c2
add r2.w, c13.y, -r0.x
texld r0.x, r1, s2
mad r0, r0, r2.w, c2.x
dp4_pp r0.y, r0, c13.w
rcp r1.x, v3.w
mad r1.xy, v3, r1.x, c13.z
texld r0.w, r1, s0
dp3 r0.x, v3, v3
cmp r0.z, -v3, c13.x, c13.y
mad r1.xy, v0, c9, c9.zwzw
mul_pp r0.z, r0, r0.w
texld r1.xyz, r1, s3
texld r0.x, r0.x, s1
mul_pp r0.x, r0.z, r0
mul_pp r0.x, r0, r0.y
mul r0.xyz, r0.x, c7
mul r4.xyz, r0, r1.w
dp3 r1.w, r2, r3
mul r0.w, r1.x, c12.x
mul r2.xyz, r4, r0.w
max r0.w, r1, c13.x
mul r3.xyz, r0.w, r0
mad r4.xy, v0, c10, c10.zwzw
texld r0.z, r4, s4
add r4.xyz, -r1, c8
mul r0.x, r0.z, c11
mad r0.xyz, r0.x, r4, r1
mad oC0.xyz, r3, r0, r2
mov_pp oC0.w, c13.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_Diffus] 2D 3
SetTexture 3 [_Mask] 2D 4
SetTexture 4 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 224
Vector 16 [_ShadowOffsets0]
Vector 32 [_ShadowOffsets1]
Vector 48 [_ShadowOffsets2]
Vector 64 [_ShadowOffsets3]
Vector 144 [_LightColor0]
Vector 160 [_Color]
Vector 176 [_Diffus_ST]
Vector 192 [_Mask_ST]
Float 208 [_Blend]
Float 212 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedidpmpngdphhapjmifelbngnkganejebmabaaaaaafaajaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdaaiaaaa
eaaaaaaaamacaaaafjaaaaaeegiocaaaaaaaaaaaaoaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaiaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaa
aeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaa
aeaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
afaaaaaaaaaaaaajbcaabaaaaaaaaaaaakiacaiaebaaaaaaadaaaaaabiaaaaaa
abeaaaaaaaaaiadpaoaaaaahocaabaaaaaaaaaaaagbjbaaaafaaaaaapgbpbaaa
afaaaaaaaaaaaaaihcaabaaaabaaaaaajgahbaaaaaaaaaaaegiccaaaaaaaaaaa
abaaaaaaehaaaaalbcaabaaaabaaaaaaegaabaaaabaaaaaaaghabaaaaeaaaaaa
aagabaaaaaaaaaaackaabaaaabaaaaaaaaaaaaaihcaabaaaacaaaaaajgahbaaa
aaaaaaaaegiccaaaaaaaaaaaacaaaaaaehaaaaalccaabaaaabaaaaaaegaabaaa
acaaaaaaaghabaaaaeaaaaaaaagabaaaaaaaaaaackaabaaaacaaaaaaaaaaaaai
hcaabaaaacaaaaaajgahbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaaaaaaaai
ocaabaaaaaaaaaaafgaobaaaaaaaaaaaagijcaaaaaaaaaaaaeaaaaaaehaaaaal
icaabaaaabaaaaaajgafbaaaaaaaaaaaaghabaaaaeaaaaaaaagabaaaaaaaaaaa
dkaabaaaaaaaaaaaehaaaaalecaabaaaabaaaaaaegaabaaaacaaaaaaaghabaaa
aeaaaaaaaagabaaaaaaaaaaackaabaaaacaaaaaadcaaaaakpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagaabaaaaaaaaaaaagiacaaaadaaaaaabiaaaaaabbaaaaak
bcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiado
aaaaiadoaoaaaaahgcaabaaaaaaaaaaaagbbbaaaaeaaaaaapgbpbaaaaeaaaaaa
aaaaaaakgcaabaaaaaaaaaaafgagbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaadp
aaaaaadpaaaaaaaaefaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadbaaaaahccaabaaaaaaaaaaaabeaaaaaaaaaaaaa
ckbabaaaaeaaaaaaabaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
aaaaiadpdiaaaaahccaabaaaaaaaaaaadkaabaaaabaaaaaabkaabaaaaaaaaaaa
baaaaaahecaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaakgakbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
diaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaajaaaaaadcaaaaamhcaabaaa
abaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaa
adaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaajhcaabaaaaeaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaeaaaaaaegacbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaaeaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiaec
bjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaaefaaaaaj
pcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaa
diaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaabkiacaaaaaaaaaaaanaaaaaa
diaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaamaaaaaaogikcaaa
aaaaaaaaamaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
adaaaaaaaagabaaaaeaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaaacaaaaaa
akiacaaaaaaaaaaaanaaaaaaaaaaaaajhcaabaaaacaaaaaaegacbaiaebaaaaaa
abaaaaaaegiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadcaaaaajhccabaaaaaaaaaaa
egacbaaaadaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..9],
		{ 0, 0.97000003, 0.0078125, -0.0078125 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 },
		{ 0.25, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
DP3 R0.w, R1, R1;
ADD R0.xyz, -fragment.texcoord[1], c[0];
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R0.xyz, R0.w, R0, R3;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.w, R0.w;
MUL R2.xyz, R1.w, fragment.texcoord[2];
DP3 R2.w, R2, R1;
ADD R0.xyz, fragment.texcoord[4], c[10].zwww;
TEX R0, R0, texture[0], CUBE;
DP4 R4.w, R0, c[11];
ADD R0.xyz, fragment.texcoord[4], c[10].wzww;
TEX R0, R0, texture[0], CUBE;
DP4 R4.z, R0, c[11];
ADD R1.xyz, fragment.texcoord[4], c[10].wwzw;
TEX R1, R1, texture[0], CUBE;
DP4 R4.y, R1, c[11];
ADD R0.xyz, fragment.texcoord[4], c[10].z;
TEX R0, R0, texture[0], CUBE;
DP3 R1.x, fragment.texcoord[4], fragment.texcoord[4];
DP4 R4.x, R0, c[11];
RSQ R1.x, R1.x;
RCP R0.x, R1.x;
MUL R0.x, R0, c[2].w;
MAD R0, -R0.x, c[10].y, R4;
MOV R1.x, c[11];
CMP R0, R0, c[3].x, R1.x;
DP4 R0.x, R0, c[12].x;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
TEX R0.w, R1.x, texture[1], 2D;
MUL R0.x, R0.w, R0;
DP3 R0.w, R2, R3;
MAD R1.xy, fragment.texcoord[0], c[6], c[6].zwzw;
MUL R0.xyz, R0.x, c[4];
MAX R0.w, R0, c[10].x;
MUL R2.xyz, R0.w, R0;
MAX R0.w, R2, c[10].x;
POW R0.w, R0.w, c[12].y;
MUL R3.xyz, R0, R0.w;
TEX R1.xyz, R1, texture[2], 2D;
MUL R0.z, R1.x, c[9].x;
MUL R4.xyz, R3, R0.z;
MAD R0.xy, fragment.texcoord[0], c[7], c[7].zwzw;
TEX R0.z, R0, texture[3], 2D;
ADD R3.xyz, -R1, c[5];
MUL R0.x, R0.z, c[8];
MAD R0.xyz, R0.x, R3, R1;
MAD result.color.xyz, R2, R0, R4;
MOV result.color.w, c[10].x;
END
# 56 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c10, 0.00000000, 0.00781250, -0.00781250, 0.97000003
def c11, 1.00000000, 0.00392157, 0.00001538, 0.00000006
def c12, 0.25000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
mul r0.xyz, r1.x, r0
dp3 r0.w, r2, r0
max r1.x, r0.w, c10
pow r4, r1.x, c12.y
add r0.xyz, v4, c10.yzzw
texld r0, r0, s0
dp4 r5.w, r0, c11
add r0.xyz, v4, c10.zyzw
texld r0, r0, s0
dp4 r5.z, r0, c11
add r1.xyz, v4, c10.zzyw
texld r1, r1, s0
dp4 r5.y, r1, c11
add r0.xyz, v4, c10.y
texld r0, r0, s0
dp3 r1.x, v4, v4
rsq r1.x, r1.x
dp4 r5.x, r0, c11
rcp r0.x, r1.x
mul r0.x, r0, c2.w
mad r0, -r0.x, c10.w, r5
mov r1.x, c3
cmp r1, r0, c11.x, r1.x
dp4_pp r0.y, r1, c12.x
dp3 r0.w, r2, r3
dp3 r0.x, v3, v3
texld r0.x, r0.x, s1
mul r0.x, r0, r0.y
mad r1.xy, v0, c6, c6.zwzw
mul r0.xyz, r0.x, c4
max r0.w, r0, c10.x
mul r2.xyz, r0.w, r0
mov r0.w, r4.x
mul r3.xyz, r0, r0.w
texld r1.xyz, r1, s2
mul r0.z, r1.x, c9.x
mul r4.xyz, r3, r0.z
mad r0.xy, v0, c7, c7.zwzw
texld r0.z, r0, s3
add r3.xyz, -r1, c5
mul r0.x, r0.z, c8
mad r0.xyz, r0.x, r3, r1
mad oC0.xyz, r2, r0, r4
mov_pp oC0.w, c10.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_ShadowMapTexture] CUBE 0
SetTexture 2 [_Diffus] 2D 2
SetTexture 3 [_Mask] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedaipcjembglmokmcckdblmhkjndnphpnmabaaaaaafaajaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdaaiaaaa
eaaaaaaaamacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaacaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacafaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaa
afaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaa
aaaaaaaaakaabaaaaaaaaaaadkiacaaaacaaaaaaabaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaomfbhidpaaaaaaakocaabaaaaaaaaaaa
agbjbaaaafaaaaaaaceaaaaaaaaaaaaaaaaaaadmaaaaaadmaaaaaadmefaaaaaj
pcaabaaaabaaaaaajgahbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
bbaaaaakbcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaiadpibiaiadl
icabibdhafidibddaaaaaaakocaabaaaaaaaaaaaagbjbaaaafaaaaaaaceaaaaa
aaaaaaaaaaaaaalmaaaaaalmaaaaaadmefaaaaajpcaabaaaacaaaaaajgahbaaa
aaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaabbaaaaakccaabaaaabaaaaaa
egaobaaaacaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdhafidibddaaaaaaak
ocaabaaaaaaaaaaaagbjbaaaafaaaaaaaceaaaaaaaaaaaaaaaaaaalmaaaaaadm
aaaaaalmefaaaaajpcaabaaaacaaaaaajgahbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaabbaaaaakecaabaaaabaaaaaaegaobaaaacaaaaaaaceaaaaa
aaaaiadpibiaiadlicabibdhafidibddaaaaaaakocaabaaaaaaaaaaaagbjbaaa
afaaaaaaaceaaaaaaaaaaaaaaaaaaadmaaaaaalmaaaaaalmefaaaaajpcaabaaa
acaaaaaajgahbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaabbaaaaak
icaabaaaabaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdh
afidibdddbaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaagaabaaaaaaaaaaa
dhaaaaanpcaabaaaaaaaaaaaegaobaaaaaaaaaaaagiacaaaadaaaaaabiaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpbbaaaaakbcaabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiadoaaaaiadobaaaaaah
ccaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaajpcaabaaa
abaaaaaafgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaaihcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaamhcaabaaa
abaaaaaapgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
acaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaa
adaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaajhcaabaaaaeaaaaaa
egbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaeaaaaaaegacbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaaeaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiaec
bjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaa
diaaaaaiicaabaaaaaaaaaaaakaabaaaabaaaaaabkiacaaaaaaaaaaaajaaaaaa
diaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaaacaaaaaa
akiacaaaaaaaaaaaajaaaaaaaaaaaaajhcaabaaaacaaaaaaegacbaiaebaaaaaa
abaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaajhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadcaaaaajhccabaaaaaaaaaaa
egacbaaaadaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"3.0-!!ARBfp1.0
PARAM c[13] = { program.local[0..9],
		{ 0, 0.97000003, 0.0078125, -0.0078125 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 },
		{ 0.25, 64 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MAD R1.xyz, -fragment.texcoord[1], c[1].w, c[1];
ADD R0.xyz, -fragment.texcoord[1], c[0];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R2.xyz, R0.w, R1;
DP3 R1.w, R0, R0;
RSQ R0.w, R1.w;
MAD R1.xyz, R0.w, R0, R2;
DP3 R0.w, R1, R1;
RSQ R1.w, R0.w;
MUL R3.xyz, R1.w, R1;
ADD R0.xyz, fragment.texcoord[4], c[10].zwww;
TEX R0, R0, texture[0], CUBE;
DP4 R4.w, R0, c[11];
ADD R0.xyz, fragment.texcoord[4], c[10].wzww;
TEX R0, R0, texture[0], CUBE;
DP4 R4.z, R0, c[11];
ADD R1.xyz, fragment.texcoord[4], c[10].wwzw;
TEX R1, R1, texture[0], CUBE;
DP4 R4.y, R1, c[11];
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
RSQ R1.x, R0.w;
ADD R0.xyz, fragment.texcoord[4], c[10].z;
TEX R0, R0, texture[0], CUBE;
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
DP4 R4.x, R0, c[11];
RCP R1.x, R1.x;
MUL R0.x, R1, c[2].w;
MAD R0, -R0.x, c[10].y, R4;
MOV R1.x, c[11];
CMP R0, R0, c[3].x, R1.x;
DP4 R0.y, R0, c[12].x;
DP3 R0.x, fragment.texcoord[3], fragment.texcoord[3];
RSQ R1.y, R1.y;
MUL R1.xyz, R1.y, fragment.texcoord[2];
DP3 R2.w, R1, R3;
TEX R0.w, fragment.texcoord[3], texture[2], CUBE;
TEX R1.w, R0.x, texture[1], 2D;
MUL R0.x, R1.w, R0.w;
DP3 R0.w, R1, R2;
MUL R0.x, R0, R0.y;
MAD R1.xy, fragment.texcoord[0], c[6], c[6].zwzw;
MUL R0.xyz, R0.x, c[4];
MAX R0.w, R0, c[10].x;
MUL R2.xyz, R0.w, R0;
MAX R0.w, R2, c[10].x;
POW R0.w, R0.w, c[12].y;
MUL R3.xyz, R0, R0.w;
TEX R1.xyz, R1, texture[3], 2D;
MUL R0.z, R1.x, c[9].x;
MUL R4.xyz, R3, R0.z;
MAD R0.xy, fragment.texcoord[0], c[7], c[7].zwzw;
TEX R0.z, R0, texture[4], 2D;
ADD R3.xyz, -R1, c[5];
MUL R0.x, R0.z, c[8];
MAD R0.xyz, R0.x, R3, R1;
MAD result.color.xyz, R2, R0, R4;
MOV result.color.w, c[10].x;
END
# 58 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceCameraPos]
Vector 1 [_WorldSpaceLightPos0]
Vector 2 [_LightPositionRange]
Vector 3 [_LightShadowData]
Vector 4 [_LightColor0]
Vector 5 [_Color]
Vector 6 [_Diffus_ST]
Vector 7 [_Mask_ST]
Float 8 [_Blend]
Float 9 [_Specular]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_cube s2
dcl_2d s3
dcl_2d s4
def c10, 0.00000000, 0.00781250, -0.00781250, 0.97000003
def c11, 1.00000000, 0.00392157, 0.00001538, 0.00000006
def c12, 0.25000000, 64.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mad r1.xyz, -v1, c1.w, c1
dp3 r0.w, r1, r1
add r0.xyz, -v1, c0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
dp3 r1.w, r0, r0
rsq r0.w, r1.w
mad r0.xyz, r0.w, r0, r3
dp3 r0.w, r0, r0
rsq r1.x, r0.w
mul r1.xyz, r1.x, r0
dp3 r0.w, v2, v2
rsq r0.w, r0.w
mul r2.xyz, r0.w, v2
dp3 r1.x, r2, r1
max r2.w, r1.x, c10.x
add r0.xyz, v4, c10.yzzw
texld r0, r0, s0
dp4 r4.w, r0, c11
add r0.xyz, v4, c10.zyzw
texld r0, r0, s0
dp4 r4.z, r0, c11
add r1.xyz, v4, c10.zzyw
texld r1, r1, s0
dp4 r4.y, r1, c11
add r0.xyz, v4, c10.y
texld r0, r0, s0
dp3 r1.x, v4, v4
dp4 r4.x, r0, c11
rsq r1.x, r1.x
rcp r0.x, r1.x
mul r0.x, r0, c2.w
mad r0, -r0.x, c10.w, r4
mov r1.x, c3
cmp r1, r0, c11.x, r1.x
pow r0, r2.w, c12.y
dp4_pp r0.z, r1, c12.x
dp3 r1.x, v3, v3
texld r0.w, v3, s2
texld r1.x, r1.x, s1
mul r0.y, r1.x, r0.w
mul r0.z, r0.y, r0
dp3 r0.y, r2, r3
max r0.y, r0, c10.x
mul r3.xyz, r0.z, c4
mad r1.xy, v0, c6, c6.zwzw
mul r2.xyz, r0.y, r3
mul r3.xyz, r3, r0.x
texld r1.xyz, r1, s3
mul r0.z, r1.x, c9.x
mul r4.xyz, r3, r0.z
mad r0.xy, v0, c7, c7.zwzw
texld r0.z, r0, s4
add r3.xyz, -r1, c5
mul r0.x, r0.z, c8
mad r0.xyz, r0.x, r3, r1
mad oC0.xyz, r2, r0, r4
mov_pp oC0.w, c10.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
SetTexture 0 [_LightTextureB0] 2D 2
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_ShadowMapTexture] CUBE 0
SetTexture 3 [_Diffus] 2D 3
SetTexture 4 [_Mask] 2D 4
ConstBuffer "$Globals" 160
Vector 80 [_LightColor0]
Vector 96 [_Color]
Vector 112 [_Diffus_ST]
Vector 128 [_Mask_ST]
Float 144 [_Blend]
Float 148 [_Specular]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityShadows" 3
"ps_4_0
eefiecedficocdicmgpielibfjmglgglfnolenbnabaaaaaakmajaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcimaiaaaa
eaaaaaaacdacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaacaaaaaafjaaaaaeegiocaaa
adaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaa
aeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaa
ffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
afaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaa
elaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkiacaaaacaaaaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaomfbhidpaaaaaaakocaabaaaaaaaaaaaagbjbaaa
afaaaaaaaceaaaaaaaaaaaaaaaaaaadmaaaaaadmaaaaaadmefaaaaajpcaabaaa
abaaaaaajgahbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaabbaaaaak
bcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdh
afidibddaaaaaaakocaabaaaaaaaaaaaagbjbaaaafaaaaaaaceaaaaaaaaaaaaa
aaaaaalmaaaaaalmaaaaaadmefaaaaajpcaabaaaacaaaaaajgahbaaaaaaaaaaa
eghobaaaacaaaaaaaagabaaaaaaaaaaabbaaaaakccaabaaaabaaaaaaegaobaaa
acaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdhafidibddaaaaaaakocaabaaa
aaaaaaaaagbjbaaaafaaaaaaaceaaaaaaaaaaaaaaaaaaalmaaaaaadmaaaaaalm
efaaaaajpcaabaaaacaaaaaajgahbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaa
aaaaaaaabbaaaaakecaabaaaabaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadp
ibiaiadlicabibdhafidibddaaaaaaakocaabaaaaaaaaaaaagbjbaaaafaaaaaa
aceaaaaaaaaaaaaaaaaaaadmaaaaaalmaaaaaalmefaaaaajpcaabaaaacaaaaaa
jgahbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaabbaaaaakicaabaaa
abaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdhafidibdd
dbaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaagaabaaaaaaaaaaadhaaaaan
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaagiacaaaadaaaaaabiaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpbbaaaaakbcaabaaaaaaaaaaaegaobaaa
aaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiadoaaaaiadobaaaaaahccaabaaa
aaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaa
fgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
acaaaaaaegbcbaaaaeaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
ccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaaacaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaamhcaabaaaabaaaaaa
pgipcaaaacaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaacaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaaadaaaaaa
egacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaajhcaabaaaaeaaaaaaegbcbaia
ebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaaeaaaaaaegacbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaaeaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiaecbjaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaadiaaaaai
icaabaaaaaaaaaaaakaabaaaabaaaaaabkiacaaaaaaaaaaaajaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaldcaabaaa
acaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaa
aiaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaeaaaaaa
aagabaaaaeaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaaacaaaaaaakiacaaa
aaaaaaaaajaaaaaaaaaaaaajhcaabaaaacaaaaaaegacbaiaebaaaaaaabaaaaaa
egiccaaaaaaaaaaaagaaaaaadcaaaaajhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaacaaaaaaegacbaaaabaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaaaaadoaaaaab"
}
}
 }
}
Fallback "Diffuse"
}