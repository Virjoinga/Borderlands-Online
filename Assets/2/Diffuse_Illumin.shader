è¡Shader "Shader Forge/Diffuse_Illumin" {
Properties {
 _Diffuse ("Diffuse", 2D) = "white" {}
 _Mask ("Mask", 2D) = "white" {}
 _Illumin_Color ("Illumin_Color", Color) = (1,0.960937,0.905882,1)
 _Illumin ("Illumin", Float) = 1
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
MUL result.texcoord[3].xyz, R0.w, R2;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[1].xyz, R0;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[0].w, vertex.position, c[8];
DP4 result.texcoord[0].z, vertex.position, c[7];
DP4 result.texcoord[0].y, vertex.position, c[6];
DP4 result.texcoord[0].x, vertex.position, c[5];
END
# 28 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
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
def c12, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
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
mul o4.xyz, r0.w, r2
mov o3.xyz, r1
mov o2.xyz, r0
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
Bind "tangent" TexCoord2
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedfikjfbnkefffmbceeoljgmfklaknnigfabaaaaaabaafaaaaadaaaaaa
cmaaaaaamaaaaaaagaabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaadaaaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefckiadaaaaeaaaabaaokaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaa
aeaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaa
anaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaabaaaaaa
egiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaabaaaaaai
bcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaabaaaaaai
ccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaabaaaaaai
ecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaadgaaaaaf
hccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaa
acaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
aaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaabaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaa
diaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaiaebaaaaaa
acaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaacaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaaeaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"3.0-!!ARBfp1.0
PARAM c[1] = { { 0.5 } };
TEMP R0;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD result.color.xyz, R0, c[0].x, c[0].x;
MOV result.color.w, c[0].x;
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
"ps_3_0
def c0, 0.50000000, 0, 0, 0
dcl_texcoord1 v0.xyz
dp3 r0.x, v0, v0
rsq r0.x, r0.x
mul r0.xyz, r0.x, v0
mad oC0.xyz, r0, c0.x, c0.x
mov_pp oC0.w, c0.x
"
}
SubProgram "d3d11 " {
"ps_4_0
eefiecedkcbedjgjbhiplcoalmkndmlmpnibgnpmabaaaaaanaabaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcmiaaaaaaeaaaaaaadcaaaaaagcbaaaadhcbabaaaacaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacabaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaa
acaaaaaaegbcbaaaacaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaacaaaaaadcaaaaap
hccabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaadpdoaaaaab"
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
Bind "tangent" ATTR14
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
TEMP R3;
TEMP R4;
TEMP R5;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R1, c[11];
DP4 R0.y, R1, c[10];
DP4 R0.x, R1, c[9];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R4.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
ADD R3.xyz, R1, c[0].x;
MUL R0.xyz, R3.zxyw, R4.yzxw;
MAD R0.xyz, R3.yzxw, R4.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.normal;
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
RSQ R1.w, R0.w;
MUL R1.xyz, R2, c[25].w;
MUL result.texcoord[4].xyz, R1.w, R0;
MOV R1.w, c[0].y;
MUL R0.w, R1.y, R1.y;
MAD R0.x, R1, R1, -R0.w;
MUL R2.xyz, R0.x, c[24];
MUL R0, R1.xyzz, R1.yzzx;
DP4 R5.z, R1, c[20];
DP4 R5.y, R1, c[19];
DP4 R5.x, R1, c[18];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, R0, c[23];
DP4 R1.x, R0, c[21];
DP4 R1.y, R0, c[22];
ADD R0.xyz, R5, R1;
ADD R0.xyz, R0, R2;
MUL result.texcoord[6].xyz, R0, c[0].z;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R1.xyz, R0.xyww, c[0].z;
MUL R1.y, R1, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
MOV result.texcoord[3].xyz, R4;
ADD result.texcoord[5].xy, R1, R1.z;
MOV result.texcoord[2].xyz, R3;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[5].z, -R0.x;
MOV result.texcoord[5].w, R1;
END
# 57 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
dcl_texcoord5 o6
dcl_texcoord6 o7
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.w, c26.x
mov r1.xyz, v2
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
add r2.xyz, r1, c26.x
mul r0.xyz, r2.zxyw, r3.yzxw
mad r0.xyz, r2.yzxw, r3.zxyw, -r0
mul r1.xyz, v2.w, r0
dp3 r1.w, r1, r1
mov r0.w, c26.x
mov r0.xyz, v1
dp4 r4.z, r0, c10
dp4 r4.x, r0, c8
dp4 r4.y, r0, c9
rsq r0.w, r1.w
mul r0.xyz, r4, c25.w
mul o5.xyz, r0.w, r1
mov r0.w, c26.y
mul r1.w, r0.y, r0.y
mad r1.x, r0, r0, -r1.w
mul r4.xyz, r1.x, c24
mul r1, r0.xyzz, r0.yzzx
dp4 r5.z, r0, c20
dp4 r5.y, r0, c19
dp4 r5.x, r0, c18
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
dp4 r1.w, v0, c7
add r0.xyz, r5, r0
add r0.xyz, r0, r4
mul o7.xyz, r0, c26.z
dp4 r0.x, v0, c4
mov r0.w, r1
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c26.z
mul r1.y, r1, c16.x
dp4 r0.z, v0, c6
mov o0, r0
dp4 r0.x, v0, c2
mov o4.xyz, r3
mad o6.xy, r1.z, c17.zwzw, r1
mov o3.xyz, r2
mov o1.xy, v3
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o6.z, -r0.x
mov o6.w, r1
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
eefiecedcbfeaeoigcamnjhefflbadekomfhggpnabaaaaaaeaajaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefchiahaaaaeaaaabaanoabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaai
pcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaafecaabaaaaaaaaaaa
ckaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaakgakbaaaaaaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahecaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafecaabaaaaaaaaaaa
ckaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaagaaaaaadkaabaaaaaaaaaaa
diaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaa
aaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
bcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaaakaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaackbabaaa
aaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaa
ahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaaagaaaaaa
akaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
abaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
abaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
abaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaaahaaaaaa
egacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[20] = { { 0, 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP4 R1.w, vertex.position, c[8];
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[11];
DP4 R1.y, R0, c[10];
DP4 R1.x, R0, c[9];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[14];
MAD R0.xyz, vertex.normal.x, c[13], R0;
MAD R0.xyz, vertex.normal.z, c[15], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
MOV R0.w, R1;
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].y;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
DP4 R0.w, vertex.position, c[12];
MOV result.texcoord[1], R0;
ADD R0.xyz, R0, -c[18];
MUL result.texcoord[7].xyz, R0, c[18].w;
MOV R0.x, c[0].z;
ADD R0.y, R0.x, -c[18].w;
DP4 R0.x, vertex.position, c[3];
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[6].xy, vertex.texcoord[1], c[19], c[19].zwzw;
MUL result.texcoord[7].w, -R0.x, R0.y;
MOV result.texcoord[5].z, -R0.x;
MOV result.texcoord[5].w, R1;
END
# 44 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
def c20, 0.00000000, 0.50000000, 1.00000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dp4 r1.w, v0, c7
mov r0.w, c20.x
mov r0.xyz, v2
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c13
mad r0.xyz, v1.x, c12, r0
mad r0.xyz, v1.z, c14, r0
add r1.xyz, r0, c20.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
mov r0.w, r1
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r2.xyz, r0.xyww, c20.y
dp4 r0.z, v0, c6
mov o0, r0
mul r2.y, r2, c16.x
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
dp4 r0.w, v0, c11
mov o2, r0
add r0.xyz, r0, -c18
mul o8.xyz, r0, c18.w
mov r0.x, c18.w
add r0.y, c20.z, -r0.x
dp4 r0.x, v0, c2
mov o4.xyz, r3
mad o6.xy, r2.z, c17.zwzw, r2
mov o3.xyz, r1
mov o1.xy, v3
mad o7.xy, v4, c19, c19.zwzw
mul o8.w, -r0.x, r0.y
mov o6.z, -r0.x
mov o6.w, r1
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedckmnckhfojcpeklpkdhollldnfnicnknabaaaaaabiaiaaaaadaaaaaa
cmaaaaaaniaaaaaaniabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheopiaaaaaa
ajaaaaaaaiaaaaaaoaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
omaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaomaaaaaaagaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaaomaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
omaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaaomaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaaomaaaaaaahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiagaaaa
eaaaabaaioabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabkaaaaaafjaaaaaeegiocaaa
adaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaa
fpaaaaadpcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaa
aeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaa
gfaaaaadmccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaaagiecaaa
aaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaabaaaaaaaaaaaaajhcaabaaaabaaaaaa
egacbaaaabaaaaaaegiccaiaebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaa
ahaaaaaaegacbaaaabaaaaaapgipcaaaacaaaaaabjaaaaaabaaaaaaibcaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabaaaaaaabaaaaaaiccaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabbaaaaaabaaaaaaiecaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabcaaaaaadgaaaaafhccabaaa
adaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaakgakbaaaaaaaaaaa
egacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaah
hcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaa
diaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaakgakbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaficcabaaaagaaaaaadkaabaaa
aaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaadaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
agaaaaaaakaabaiaebaaaaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaia
ebaaaaaaacaaaaaabjaaaaaaabeaaaaaaaaaiadpdiaaaaaiiccabaaaahaaaaaa
bkaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[20] = { { 0, 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP4 R1.w, vertex.position, c[8];
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[11];
DP4 R1.y, R0, c[10];
DP4 R1.x, R0, c[9];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[14];
MAD R0.xyz, vertex.normal.x, c[13], R0;
MAD R0.xyz, vertex.normal.z, c[15], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
MOV R0.w, R1;
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].y;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
DP4 R0.w, vertex.position, c[12];
MOV result.texcoord[1], R0;
ADD R0.xyz, R0, -c[18];
MUL result.texcoord[7].xyz, R0, c[18].w;
MOV R0.x, c[0].z;
ADD R0.y, R0.x, -c[18].w;
DP4 R0.x, vertex.position, c[3];
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[6].xy, vertex.texcoord[1], c[19], c[19].zwzw;
MUL result.texcoord[7].w, -R0.x, R0.y;
MOV result.texcoord[5].z, -R0.x;
MOV result.texcoord[5].w, R1;
END
# 44 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
def c20, 0.00000000, 0.50000000, 1.00000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dp4 r1.w, v0, c7
mov r0.w, c20.x
mov r0.xyz, v2
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c13
mad r0.xyz, v1.x, c12, r0
mad r0.xyz, v1.z, c14, r0
add r1.xyz, r0, c20.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
mov r0.w, r1
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r2.xyz, r0.xyww, c20.y
dp4 r0.z, v0, c6
mov o0, r0
mul r2.y, r2, c16.x
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
dp4 r0.w, v0, c11
mov o2, r0
add r0.xyz, r0, -c18
mul o8.xyz, r0, c18.w
mov r0.x, c18.w
add r0.y, c20.z, -r0.x
dp4 r0.x, v0, c2
mov o4.xyz, r3
mad o6.xy, r2.z, c17.zwzw, r2
mov o3.xyz, r1
mov o1.xy, v3
mad o7.xy, v4, c19, c19.zwzw
mul o8.w, -r0.x, r0.y
mov o6.z, -r0.x
mov o6.w, r1
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedckmnckhfojcpeklpkdhollldnfnicnknabaaaaaabiaiaaaaadaaaaaa
cmaaaaaaniaaaaaaniabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheopiaaaaaa
ajaaaaaaaiaaaaaaoaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
omaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaomaaaaaaagaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaaomaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
omaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaaomaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaaomaaaaaaahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiagaaaa
eaaaabaaioabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabkaaaaaafjaaaaaeegiocaaa
adaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaa
fpaaaaadpcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaa
aeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaa
gfaaaaadmccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaaagiecaaa
aaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaabaaaaaaaaaaaaajhcaabaaaabaaaaaa
egacbaaaabaaaaaaegiccaiaebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaa
ahaaaaaaegacbaaaabaaaaaapgipcaaaacaaaaaabjaaaaaabaaaaaaibcaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabaaaaaaabaaaaaaiccaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabbaaaaaabaaaaaaiecaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabcaaaaaadgaaaaafhccabaaa
adaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaakgakbaaaaaaaaaaa
egacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaah
hcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaa
diaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaakgakbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaficcabaaaagaaaaaadkaabaaa
aaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaadaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
agaaaaaaakaabaiaebaaaaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaia
ebaaaaaaacaaaaaabjaaaaaaabeaaaaaaaaaiadpdiaaaaaiiccabaaaahaaaaaa
bkaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
TEMP R3;
TEMP R4;
TEMP R5;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R1, c[11];
DP4 R0.y, R1, c[10];
DP4 R0.x, R1, c[9];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R4.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[14];
MAD R1.xyz, vertex.normal.x, c[13], R1;
MAD R1.xyz, vertex.normal.z, c[15], R1;
ADD R3.xyz, R1, c[0].x;
MUL R0.xyz, R3.zxyw, R4.yzxw;
MAD R0.xyz, R3.yzxw, R4.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.normal;
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
RSQ R1.w, R0.w;
MUL R1.xyz, R2, c[25].w;
MUL result.texcoord[4].xyz, R1.w, R0;
MOV R1.w, c[0].y;
MUL R0.w, R1.y, R1.y;
MAD R0.x, R1, R1, -R0.w;
MUL R2.xyz, R0.x, c[24];
MUL R0, R1.xyzz, R1.yzzx;
DP4 R5.z, R1, c[20];
DP4 R5.y, R1, c[19];
DP4 R5.x, R1, c[18];
DP4 R1.w, vertex.position, c[8];
DP4 R1.z, R0, c[23];
DP4 R1.x, R0, c[21];
DP4 R1.y, R0, c[22];
ADD R0.xyz, R5, R1;
ADD R0.xyz, R0, R2;
MUL result.texcoord[6].xyz, R0, c[0].z;
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R1.xyz, R0.xyww, c[0].z;
MUL R1.y, R1, c[17].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
MOV result.texcoord[3].xyz, R4;
ADD result.texcoord[5].xy, R1, R1.z;
MOV result.texcoord[2].xyz, R3;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[12];
DP4 result.texcoord[1].z, vertex.position, c[11];
DP4 result.texcoord[1].y, vertex.position, c[10];
DP4 result.texcoord[1].x, vertex.position, c[9];
MOV result.texcoord[5].z, -R0.x;
MOV result.texcoord[5].w, R1;
END
# 57 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
dcl_texcoord5 o6
dcl_texcoord6 o7
def c26, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.w, c26.x
mov r1.xyz, v2
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r1.xyz, v1.y, c13
mad r1.xyz, v1.x, c12, r1
mad r1.xyz, v1.z, c14, r1
add r2.xyz, r1, c26.x
mul r0.xyz, r2.zxyw, r3.yzxw
mad r0.xyz, r2.yzxw, r3.zxyw, -r0
mul r1.xyz, v2.w, r0
dp3 r1.w, r1, r1
mov r0.w, c26.x
mov r0.xyz, v1
dp4 r4.z, r0, c10
dp4 r4.x, r0, c8
dp4 r4.y, r0, c9
rsq r0.w, r1.w
mul r0.xyz, r4, c25.w
mul o5.xyz, r0.w, r1
mov r0.w, c26.y
mul r1.w, r0.y, r0.y
mad r1.x, r0, r0, -r1.w
mul r4.xyz, r1.x, c24
mul r1, r0.xyzz, r0.yzzx
dp4 r5.z, r0, c20
dp4 r5.y, r0, c19
dp4 r5.x, r0, c18
dp4 r0.z, r1, c23
dp4 r0.x, r1, c21
dp4 r0.y, r1, c22
dp4 r1.w, v0, c7
add r0.xyz, r5, r0
add r0.xyz, r0, r4
mul o7.xyz, r0, c26.z
dp4 r0.x, v0, c4
mov r0.w, r1
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c26.z
mul r1.y, r1, c16.x
dp4 r0.z, v0, c6
mov o0, r0
dp4 r0.x, v0, c2
mov o4.xyz, r3
mad o6.xy, r1.z, c17.zwzw, r1
mov o3.xyz, r2
mov o1.xy, v3
dp4 o2.w, v0, c11
dp4 o2.z, v0, c10
dp4 o2.y, v0, c9
dp4 o2.x, v0, c8
mov o6.z, -r0.x
mov o6.w, r1
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
eefiecedcbfeaeoigcamnjhefflbadekomfhggpnabaaaaaaeaajaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefchiahaaaaeaaaabaanoabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaai
pcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaafecaabaaaaaaaaaaa
ckaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaakgakbaaaaaaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahecaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafecaabaaaaaaaaaaa
ckaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaaagaaaaaadkaabaaaaaaaaaaa
diaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaa
aaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
bcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaaakaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaackbabaaa
aaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaa
ahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaaagaaaaaa
akaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaabaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
abaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
abaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
abaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhccabaaaahaaaaaa
egacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[20] = { { 0, 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP4 R1.w, vertex.position, c[8];
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[11];
DP4 R1.y, R0, c[10];
DP4 R1.x, R0, c[9];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[14];
MAD R0.xyz, vertex.normal.x, c[13], R0;
MAD R0.xyz, vertex.normal.z, c[15], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
MOV R0.w, R1;
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].y;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
DP4 R0.w, vertex.position, c[12];
MOV result.texcoord[1], R0;
ADD R0.xyz, R0, -c[18];
MUL result.texcoord[7].xyz, R0, c[18].w;
MOV R0.x, c[0].z;
ADD R0.y, R0.x, -c[18].w;
DP4 R0.x, vertex.position, c[3];
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[6].xy, vertex.texcoord[1], c[19], c[19].zwzw;
MUL result.texcoord[7].w, -R0.x, R0.y;
MOV result.texcoord[5].z, -R0.x;
MOV result.texcoord[5].w, R1;
END
# 44 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
def c20, 0.00000000, 0.50000000, 1.00000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dp4 r1.w, v0, c7
mov r0.w, c20.x
mov r0.xyz, v2
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c13
mad r0.xyz, v1.x, c12, r0
mad r0.xyz, v1.z, c14, r0
add r1.xyz, r0, c20.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
mov r0.w, r1
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r2.xyz, r0.xyww, c20.y
dp4 r0.z, v0, c6
mov o0, r0
mul r2.y, r2, c16.x
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
dp4 r0.w, v0, c11
mov o2, r0
add r0.xyz, r0, -c18
mul o8.xyz, r0, c18.w
mov r0.x, c18.w
add r0.y, c20.z, -r0.x
dp4 r0.x, v0, c2
mov o4.xyz, r3
mad o6.xy, r2.z, c17.zwzw, r2
mov o3.xyz, r1
mov o1.xy, v3
mad o7.xy, v4, c19, c19.zwzw
mul o8.w, -r0.x, r0.y
mov o6.z, -r0.x
mov o6.w, r1
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedckmnckhfojcpeklpkdhollldnfnicnknabaaaaaabiaiaaaaadaaaaaa
cmaaaaaaniaaaaaaniabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheopiaaaaaa
ajaaaaaaaiaaaaaaoaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
omaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaomaaaaaaagaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaaomaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
omaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaaomaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaaomaaaaaaahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiagaaaa
eaaaabaaioabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabkaaaaaafjaaaaaeegiocaaa
adaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaa
fpaaaaadpcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaa
aeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaa
gfaaaaadmccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaaagiecaaa
aaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaabaaaaaaaaaaaaajhcaabaaaabaaaaaa
egacbaaaabaaaaaaegiccaiaebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaa
ahaaaaaaegacbaaaabaaaaaapgipcaaaacaaaaaabjaaaaaabaaaaaaibcaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabaaaaaaabaaaaaaiccaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabbaaaaaabaaaaaaiecaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabcaaaaaadgaaaaafhccabaaa
adaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaakgakbaaaaaaaaaaa
egacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaah
hcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaa
diaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaakgakbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaficcabaaaagaaaaaadkaabaaa
aaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaadaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
agaaaaaaakaabaiaebaaaaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaia
ebaaaaaaacaaaaaabjaaaaaaabeaaaaaaaaaiadpdiaaaaaiiccabaaaahaaaaaa
bkaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_Object2World]
Matrix 13 [_World2Object]
Vector 17 [_ProjectionParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"3.0-!!ARBvp1.0
PARAM c[20] = { { 0, 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP4 R1.w, vertex.position, c[8];
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.attrib[14];
DP4 R1.z, R0, c[11];
DP4 R1.y, R0, c[10];
DP4 R1.x, R0, c[9];
DP3 R0.w, R1, R1;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R1;
MUL R0.xyz, vertex.normal.y, c[14];
MAD R0.xyz, vertex.normal.x, c[13], R0;
MAD R0.xyz, vertex.normal.z, c[15], R0;
ADD R1.xyz, R0, c[0].x;
MUL R0.xyz, R1.zxyw, R3.yzxw;
MAD R0.xyz, R1.yzxw, R3.zxyw, -R0;
MUL R0.xyz, vertex.attrib[14].w, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL result.texcoord[4].xyz, R0.w, R0;
MOV R0.w, R1;
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R2.xyz, R0.xyww, c[0].y;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
MUL R2.y, R2, c[17].x;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
DP4 R0.w, vertex.position, c[12];
MOV result.texcoord[1], R0;
ADD R0.xyz, R0, -c[18];
MUL result.texcoord[7].xyz, R0, c[18].w;
MOV R0.x, c[0].z;
ADD R0.y, R0.x, -c[18].w;
DP4 R0.x, vertex.position, c[3];
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R2, R2.z;
MOV result.texcoord[2].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[6].xy, vertex.texcoord[1], c[19], c[19].zwzw;
MUL result.texcoord[7].w, -R0.x, R0.y;
MOV result.texcoord[5].z, -R0.x;
MOV result.texcoord[5].w, R1;
END
# 44 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Matrix 12 [_World2Object]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_ShadowFadeCenterAndType]
Vector 19 [unity_LightmapST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
dcl_texcoord7 o8
def c20, 0.00000000, 0.50000000, 1.00000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
dp4 r1.w, v0, c7
mov r0.w, c20.x
mov r0.xyz, v2
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
dp3 r0.w, r1, r1
rsq r0.w, r0.w
mul r3.xyz, r0.w, r1
mul r0.xyz, v1.y, c13
mad r0.xyz, v1.x, c12, r0
mad r0.xyz, v1.z, c14, r0
add r1.xyz, r0, c20.x
mul r0.xyz, r1.zxyw, r3.yzxw
mad r0.xyz, r1.yzxw, r3.zxyw, -r0
mul r0.xyz, v2.w, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul o5.xyz, r0.w, r0
mov r0.w, r1
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r2.xyz, r0.xyww, c20.y
dp4 r0.z, v0, c6
mov o0, r0
mul r2.y, r2, c16.x
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
dp4 r0.w, v0, c11
mov o2, r0
add r0.xyz, r0, -c18
mul o8.xyz, r0, c18.w
mov r0.x, c18.w
add r0.y, c20.z, -r0.x
dp4 r0.x, v0, c2
mov o4.xyz, r3
mad o6.xy, r2.z, c17.zwzw, r2
mov o3.xyz, r1
mov o1.xy, v3
mad o7.xy, v4, c19, c19.zwzw
mul o8.w, -r0.x, r0.y
mov o6.z, -r0.x
mov o6.w, r1
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedckmnckhfojcpeklpkdhollldnfnicnknabaaaaaabiaiaaaaadaaaaaa
cmaaaaaaniaaaaaaniabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheopiaaaaaa
ajaaaaaaaiaaaaaaoaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
omaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaomaaaaaaagaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaaomaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
omaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaaomaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaaomaaaaaaahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcdiagaaaa
eaaaabaaioabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabkaaaaaafjaaaaaeegiocaaa
adaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaa
fpaaaaadpcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaa
aeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaa
gfaaaaadmccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaaagiecaaa
aaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaabaaaaaaaaaaaaajhcaabaaaabaaaaaa
egacbaaaabaaaaaaegiccaiaebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaa
ahaaaaaaegacbaaaabaaaaaapgipcaaaacaaaaaabjaaaaaabaaaaaaibcaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabaaaaaaabaaaaaaiccaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabbaaaaaabaaaaaaiecaabaaa
abaaaaaaegbcbaaaabaaaaaaegiccaaaadaaaaaabcaaaaaadgaaaaafhccabaaa
adaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaakgakbaaaaaaaaaaa
egacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaah
hcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaa
diaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaah
ecaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaakgakbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaficcabaaaagaaaaaadkaabaaa
aaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaadaaaaaaafaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaaakbabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaagaaaaaa
ckbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaa
agaaaaaaakaabaiaebaaaaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaia
ebaaaaaaacaaaaaabjaaaaaaabeaaaaaaaaaiadpdiaaaaaiiccabaaaahaaaaaa
bkaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 0.5, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R0.xyz, fragment.texcoord[5], texture[0], 2D;
LG2 R1.x, R0.x;
LG2 R1.y, R0.y;
LG2 R1.z, R0.z;
MAD R0.xy, fragment.texcoord[0], c[1], c[1].zwzw;
TEX R0.x, R0, texture[1], 2D;
MUL R2.xyz, R0.x, c[2];
MUL R1.xyz, -R1, c[4].x;
MAD R0.xy, fragment.texcoord[0], c[0], c[0].zwzw;
ADD R1.xyz, R1, fragment.texcoord[6];
MUL R2.xyz, R2, c[3].x;
TEX R0.xyz, R0, texture[2], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[4].y;
END
# 14 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 0.50000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord5 v2
dcl_texcoord6 v3.xyz
texldp r0.xyz, v2, s0
log_pp r1.x, r0.x
log_pp r1.y, r0.y
log_pp r1.z, r0.z
mad r0.xy, v0, c1, c1.zwzw
mul_pp r1.xyz, -r1, c4.x
texld r0.x, r0, s1
add r2.xyz, r1, v3
mul r1.xyz, r0.x, c2
mad r0.xy, v0, c0, c0.zwzw
mul r1.xyz, r1, c3.x
texld r0.xyz, r0, s2
mad oC0.xyz, r2, r0, r1
mov_pp oC0.w, c4.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Mask] 2D 2
SetTexture 2 [_Diffuse] 2D 1
ConstBuffer "$Globals" 128
Vector 64 [_Diffuse_ST]
Vector 80 [_Mask_ST]
Vector 96 [_Illumin_Color]
Float 112 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecednegpladmmaibjcgjnmpmbhfcbkdibnomabaaaaaajeadaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apalaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefceeacaaaaeaaaaaaajbaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadlcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaaldcaabaaaaaaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaa
efaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
agaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaa
ahaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaagaaaaaapgbpbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaacpaaaaafhcaabaaaabaaaaaaegacbaaaabaaaaaadcaaaaamhcaabaaa
abaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaaalpaaaaaalpaaaaaalpaaaaaaaa
egbcbaaaahaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaacaaaaaa
egaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaajhccabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"3.0-!!ARBfp1.0
PARAM c[6] = { program.local[0..4],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[6], texture[2], 2D;
MUL R0.xyz, R0.w, R0;
TEX R1, fragment.texcoord[6], texture[1], 2D;
DP4 R0.w, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.w;
RCP R0.w, R0.w;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R0, c[5].x;
MAD R2.xyz, R1, c[5].x, -R0;
TXP R1.xyz, fragment.texcoord[5], texture[0], 2D;
MAD_SAT R0.w, R0, c[0].z, c[0];
MAD R0.xyz, R0.w, R2, R0;
MAD R2.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R2.x, R2, texture[3], 2D;
MUL R2.xyz, R2.x, c[3];
LG2 R1.x, R1.x;
LG2 R1.y, R1.y;
LG2 R1.z, R1.z;
ADD R1.xyz, -R1, R0;
MAD R0.xy, fragment.texcoord[0], c[1], c[1].zwzw;
MUL R2.xyz, R2, c[4].x;
TEX R0.xyz, R0, texture[4], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[5].y;
END
# 24 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c5, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord5 v2
dcl_texcoord6 v3.xy
dcl_texcoord7 v4
texld r0, v3, s1
mul_pp r0.xyz, r0.w, r0
texld r1, v3, s2
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c5.x
mad_pp r2.xyz, r0, c5.x, -r1
texldp r0.xyz, v2, s0
dp4 r0.w, v4, v4
rsq r0.w, r0.w
rcp r0.w, r0.w
mad_sat r0.w, r0, c0.z, c0
mad_pp r1.xyz, r0.w, r2, r1
mad r2.xy, v0, c2, c2.zwzw
texld r2.x, r2, s3
mul r2.xyz, r2.x, c3
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r1.xyz, -r0, r1
mad r0.xy, v0, c1, c1.zwzw
mul r2.xyz, r2, c4.x
texld r0.xyz, r0, s4
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c5.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [unity_Lightmap] 2D 1
SetTexture 1 [_LightBuffer] 2D 0
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 4
SetTexture 4 [_Diffuse] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [unity_LightmapFade]
Vector 96 [_Diffuse_ST]
Vector 112 [_Mask_ST]
Vector 128 [_Illumin_Color]
Float 144 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmgfoeccmmdpajajlemnefcpmecbhkmfhabaaaaaaceafaaaaadaaaaaa
cmaaaaaacmabaaaagaabaaaaejfdeheopiaaaaaaajaaaaaaaiaaaaaaoaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaomaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaomaaaaaaagaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaomaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaomaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaaomaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapalaaaaomaaaaaa
ahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefclmadaaaaeaaaaaaaopaaaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaae
aahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaadlcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaabbaaaaahbcaabaaaaaaaaaaaegbobaaa
ahaaaaaaegbobaaaahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
dccaaaalbcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaaaaaaaaaaafaaaaaa
dkiacaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaa
abaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaa
fgafbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaagaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaacpaaaaafhcaabaaaabaaaaaa
egacbaaaabaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaia
ebaaaaaaabaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaabaaaaaa
egaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaaeaaaaaadiaaaaaihcaabaaa
abaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaaiaaaaaadiaaaaaihcaabaaa
abaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaaajaaaaaadcaaaaaldcaabaaa
acaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaeaaaaaa
aagabaaaadaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadp
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"3.0-!!ARBfp1.0
PARAM c[6] = { program.local[0..4],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[6], texture[2], 2D;
MUL R0.xyz, R0.w, R0;
TEX R1, fragment.texcoord[6], texture[1], 2D;
DP4 R0.w, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R0.w;
RCP R0.w, R0.w;
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R0, c[5].x;
MAD R2.xyz, R1, c[5].x, -R0;
TXP R1.xyz, fragment.texcoord[5], texture[0], 2D;
MAD_SAT R0.w, R0, c[0].z, c[0];
MAD R0.xyz, R0.w, R2, R0;
MAD R2.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R2.x, R2, texture[3], 2D;
MUL R2.xyz, R2.x, c[3];
LG2 R1.x, R1.x;
LG2 R1.y, R1.y;
LG2 R1.z, R1.z;
ADD R1.xyz, -R1, R0;
MAD R0.xy, fragment.texcoord[0], c[1], c[1].zwzw;
MUL R2.xyz, R2, c[4].x;
TEX R0.xyz, R0, texture[4], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[5].y;
END
# 24 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c5, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord5 v2
dcl_texcoord6 v3.xy
dcl_texcoord7 v4
texld r0, v3, s1
mul_pp r0.xyz, r0.w, r0
texld r1, v3, s2
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c5.x
mad_pp r2.xyz, r0, c5.x, -r1
texldp r0.xyz, v2, s0
dp4 r0.w, v4, v4
rsq r0.w, r0.w
rcp r0.w, r0.w
mad_sat r0.w, r0, c0.z, c0
mad_pp r1.xyz, r0.w, r2, r1
mad r2.xy, v0, c2, c2.zwzw
texld r2.x, r2, s3
mul r2.xyz, r2.x, c3
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r1.xyz, -r0, r1
mad r0.xy, v0, c1, c1.zwzw
mul r2.xyz, r2, c4.x
texld r0.xyz, r0, s4
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c5.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [unity_Lightmap] 2D 1
SetTexture 1 [_LightBuffer] 2D 0
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 4
SetTexture 4 [_Diffuse] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [unity_LightmapFade]
Vector 96 [_Diffuse_ST]
Vector 112 [_Mask_ST]
Vector 128 [_Illumin_Color]
Float 144 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmgfoeccmmdpajajlemnefcpmecbhkmfhabaaaaaaceafaaaaadaaaaaa
cmaaaaaacmabaaaagaabaaaaejfdeheopiaaaaaaajaaaaaaaiaaaaaaoaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaomaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaomaaaaaaagaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaomaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaomaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaaomaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapalaaaaomaaaaaa
ahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefclmadaaaaeaaaaaaaopaaaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaae
aahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaadlcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaabbaaaaahbcaabaaaaaaaaaaaegbobaaa
ahaaaaaaegbobaaaahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
dccaaaalbcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaaaaaaaaaaafaaaaaa
dkiacaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaa
abaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaa
fgafbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaagaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaacpaaaaafhcaabaaaabaaaaaa
egacbaaaabaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaia
ebaaaaaaabaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaabaaaaaa
egaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaaeaaaaaadiaaaaaihcaabaaa
abaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaaiaaaaaadiaaaaaihcaabaaa
abaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaaajaaaaaadcaaaaaldcaabaaa
acaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaeaaaaaa
aagabaaaadaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadp
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 0.5, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R0.xyz, fragment.texcoord[5], texture[0], 2D;
MUL R2.xyz, R0, c[4].x;
MAD R1.xy, fragment.texcoord[0], c[1], c[1].zwzw;
TEX R0.x, R1, texture[1], 2D;
ADD R1.xyz, R2, fragment.texcoord[6];
MUL R2.xyz, R0.x, c[2];
MAD R0.xy, fragment.texcoord[0], c[0], c[0].zwzw;
MUL R2.xyz, R2, c[3].x;
TEX R0.xyz, R0, texture[2], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[4].y;
END
# 11 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 0.50000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord5 v2
dcl_texcoord6 v3.xyz
texldp r0.xyz, v2, s0
mul_pp r2.xyz, r0, c4.x
mad r1.xy, v0, c1, c1.zwzw
texld r0.x, r1, s1
mul r1.xyz, r0.x, c2
mad r0.xy, v0, c0, c0.zwzw
add r2.xyz, r2, v3
mul r1.xyz, r1, c3.x
texld r0.xyz, r0, s2
mad oC0.xyz, r2, r0, r1
mov_pp oC0.w, c4.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_Mask] 2D 2
SetTexture 2 [_Diffuse] 2D 1
ConstBuffer "$Globals" 128
Vector 64 [_Diffuse_ST]
Vector 80 [_Mask_ST]
Vector 96 [_Illumin_Color]
Float 112 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedicmpbcjphcbchmbpphgphhicjapcboenabaaaaaaiaadaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apalaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcdaacaaaaeaaaaaaaimaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadlcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaaldcaabaaaaaaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaa
efaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
agaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaa
ahaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaagaaaaaapgbpbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaamhcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaaegbcbaaaahaaaaaadcaaaaaldcaabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
abaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"3.0-!!ARBfp1.0
PARAM c[6] = { program.local[0..4],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[6], texture[1], 2D;
MUL R1.xyz, R0.w, R0;
TEX R0, fragment.texcoord[6], texture[2], 2D;
MUL R0.xyz, R0.w, R0;
MUL R0.xyz, R0, c[5].x;
MAD R2.xy, fragment.texcoord[0], c[2], c[2].zwzw;
DP4 R1.w, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R1.w;
RCP R0.w, R0.w;
TEX R2.x, R2, texture[3], 2D;
MUL R2.xyz, R2.x, c[3];
MAD R1.xyz, R1, c[5].x, -R0;
MAD_SAT R0.w, R0, c[0].z, c[0];
MAD R1.xyz, R0.w, R1, R0;
TXP R0.xyz, fragment.texcoord[5], texture[0], 2D;
ADD R1.xyz, R0, R1;
MAD R0.xy, fragment.texcoord[0], c[1], c[1].zwzw;
MUL R2.xyz, R2, c[4].x;
TEX R0.xyz, R0, texture[4], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[5].y;
END
# 21 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c5, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord5 v2
dcl_texcoord6 v3.xy
dcl_texcoord7 v4
texld r0, v3, s1
mul_pp r1.xyz, r0.w, r0
texld r0, v3, s2
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, c5.x
mad r2.xy, v0, c2, c2.zwzw
dp4 r1.w, v4, v4
rsq r0.w, r1.w
rcp r0.w, r0.w
texld r2.x, r2, s3
mul r2.xyz, r2.x, c3
mad_pp r1.xyz, r1, c5.x, -r0
mad_sat r0.w, r0, c0.z, c0
mad_pp r1.xyz, r0.w, r1, r0
texldp r0.xyz, v2, s0
add_pp r1.xyz, r0, r1
mad r0.xy, v0, c1, c1.zwzw
mul r2.xyz, r2, c4.x
texld r0.xyz, r0, s4
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c5.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [unity_Lightmap] 2D 1
SetTexture 1 [_LightBuffer] 2D 0
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 4
SetTexture 4 [_Diffuse] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [unity_LightmapFade]
Vector 96 [_Diffuse_ST]
Vector 112 [_Mask_ST]
Vector 128 [_Illumin_Color]
Float 144 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmnfflpcaifbdglfibgokdeldmcmnncclabaaaaaaamafaaaaadaaaaaa
cmaaaaaacmabaaaagaabaaaaejfdeheopiaaaaaaajaaaaaaaiaaaaaaoaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaomaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaomaaaaaaagaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaomaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaomaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaaomaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapalaaaaomaaaaaa
ahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefckeadaaaaeaaaaaaaojaaaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaae
aahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaadlcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaabbaaaaahbcaabaaaaaaaaaaaegbobaaa
ahaaaaaaegbobaaaahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
dccaaaalbcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaaaaaaaaaaafaaaaaa
dkiacaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaa
abaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaa
fgafbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaagaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaaeaaaaaa
diaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaaiaaaaaa
diaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaaajaaaaaa
dcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaa
ogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaaeaaaaaaaagabaaaadaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"3.0-!!ARBfp1.0
PARAM c[6] = { program.local[0..4],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[6], texture[1], 2D;
MUL R1.xyz, R0.w, R0;
TEX R0, fragment.texcoord[6], texture[2], 2D;
MUL R0.xyz, R0.w, R0;
MUL R0.xyz, R0, c[5].x;
MAD R2.xy, fragment.texcoord[0], c[2], c[2].zwzw;
DP4 R1.w, fragment.texcoord[7], fragment.texcoord[7];
RSQ R0.w, R1.w;
RCP R0.w, R0.w;
TEX R2.x, R2, texture[3], 2D;
MUL R2.xyz, R2.x, c[3];
MAD R1.xyz, R1, c[5].x, -R0;
MAD_SAT R0.w, R0, c[0].z, c[0];
MAD R1.xyz, R0.w, R1, R0;
TXP R0.xyz, fragment.texcoord[5], texture[0], 2D;
ADD R1.xyz, R0, R1;
MAD R0.xy, fragment.texcoord[0], c[1], c[1].zwzw;
MUL R2.xyz, R2, c[4].x;
TEX R0.xyz, R0, texture[4], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[5].y;
END
# 21 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [unity_LightmapFade]
Vector 1 [_Diffuse_ST]
Vector 2 [_Mask_ST]
Vector 3 [_Illumin_Color]
Float 4 [_Illumin]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 3
SetTexture 4 [_Diffuse] 2D 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c5, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord5 v2
dcl_texcoord6 v3.xy
dcl_texcoord7 v4
texld r0, v3, s1
mul_pp r1.xyz, r0.w, r0
texld r0, v3, s2
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, c5.x
mad r2.xy, v0, c2, c2.zwzw
dp4 r1.w, v4, v4
rsq r0.w, r1.w
rcp r0.w, r0.w
texld r2.x, r2, s3
mul r2.xyz, r2.x, c3
mad_pp r1.xyz, r1, c5.x, -r0
mad_sat r0.w, r0, c0.z, c0
mad_pp r1.xyz, r0.w, r1, r0
texldp r0.xyz, v2, s0
add_pp r1.xyz, r0, r1
mad r0.xy, v0, c1, c1.zwzw
mul r2.xyz, r2, c4.x
texld r0.xyz, r0, s4
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c5.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [unity_Lightmap] 2D 1
SetTexture 1 [_LightBuffer] 2D 0
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_Mask] 2D 4
SetTexture 4 [_Diffuse] 2D 3
ConstBuffer "$Globals" 160
Vector 80 [unity_LightmapFade]
Vector 96 [_Diffuse_ST]
Vector 112 [_Mask_ST]
Vector 128 [_Illumin_Color]
Float 144 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmnfflpcaifbdglfibgokdeldmcmnncclabaaaaaaamafaaaaadaaaaaa
cmaaaaaacmabaaaagaabaaaaejfdeheopiaaaaaaajaaaaaaaiaaaaaaoaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaomaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaomaaaaaaagaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaomaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaomaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaomaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaaomaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaaomaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapalaaaaomaaaaaa
ahaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefckeadaaaaeaaaaaaaojaaaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaae
aahabaaaaeaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaadlcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaabbaaaaahbcaabaaaaaaaaaaaegbobaaa
ahaaaaaaegbobaaaahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
dccaaaalbcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaaaaaaaaaaafaaaaaa
dkiacaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaa
abaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaa
fgafbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaagaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaaeaaaaaa
diaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaaiaaaaaa
diaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaaajaaaaaa
dcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaa
ogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaaeaaaaaaaagabaaaadaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaa
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
Bind "tangent" ATTR14
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
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R2.xyz, R1, c[0].x;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.normal;
MOV R1.w, c[0].y;
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
MUL R1.xyz, R1, c[20].w;
MUL R0, R1.xyzz, R1.yzzx;
DP4 R5.z, R1, c[15];
DP4 R5.y, R1, c[14];
DP4 R5.x, R1, c[13];
MUL R4.xyz, vertex.attrib[14].w, R4;
DP4 R6.z, R0, c[18];
DP4 R6.x, R0, c[16];
DP4 R6.y, R0, c[17];
MUL R0.w, R1.y, R1.y;
MAD R0.w, R1.x, R1.x, -R0;
MUL R1.xyz, R0.w, c[19];
ADD R0.xyz, R5, R6;
DP3 R1.w, R4, R4;
RSQ R0.w, R1.w;
ADD R0.xyz, R0, R1;
MUL result.texcoord[4].xyz, R0.w, R4;
MUL result.texcoord[7].xyz, R0, c[0].z;
MOV result.texcoord[3].xyz, R3;
MOV result.texcoord[2].xyz, R2;
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
# 49 instructions, 7 R-regs
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
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord7 o6
def c20, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.w, c20.x
mov r1.xyz, v2
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r2.xyz, r1, c20.x
mul r4.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r4
mov r0.w, c20.x
mov r0.xyz, v1
mov r1.w, c20.y
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
mul r1.xyz, r1, c19.w
mul r0, r1.xyzz, r1.yzzx
dp4 r5.z, r1, c14
dp4 r5.y, r1, c13
dp4 r5.x, r1, c12
mul r4.xyz, v2.w, r4
dp4 r6.z, r0, c17
dp4 r6.x, r0, c15
dp4 r6.y, r0, c16
mul r0.w, r1.y, r1.y
mad r0.w, r1.x, r1.x, -r0
mul r1.xyz, r0.w, c18
add r0.xyz, r5, r6
dp3 r1.w, r4, r4
rsq r0.w, r1.w
add r0.xyz, r0, r1
mul o5.xyz, r0.w, r4
mul o6.xyz, r0, c20.z
mov o4.xyz, r3
mov o3.xyz, r2
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
eefiecedmpjbaooocaoackojkepnoaakfpdmaahmabaaaaaanaahaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaahaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefccaagaaaaeaaaabaaiiabaaaafjaaaaaeegiocaaa
aaaaaaaacnaaaaaafjaaaaaeegiocaaaabaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabaaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabbaaaaaabaaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaaoaaaaaa
kgbkbaaaacaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
hccabaaaaeaaaaaaegacbaaaabaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaa
aaaaaaaajgaebaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaa
cgajbaaaabaaaaaaegacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhccabaaaafaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaa
aaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaa
abaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaabaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaabaaaaaaegiocaaaaaaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaabaaaaaaegiocaaaaaaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaabaaaaaaegiocaaaaaaaaaaaciaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaai
bcaabaaaadaaaaaaegiocaaaaaaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaai
ccaabaaaadaaaaaaegiocaaaaaaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaai
ecaabaaaadaaaaaaegiocaaaaaaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaaaaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaakhccabaaaagaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 128
Vector 48 [unity_LightmapST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedpkockhdgbjndlkacfjfcahpojdafmblfabaaaaaaniafaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaahaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
lmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaadaaaaaakgiocaaaaaaaaaaaadaaaaaadgaaaaafdccabaaa
abaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pccabaaaacaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaa
baaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaa
bbaaaaaabaaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaa
bcaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaa
egacbaaaabaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaa
abaaaaaadcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaa
egacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgbpbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaa
afaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 128
Vector 48 [unity_LightmapST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedpkockhdgbjndlkacfjfcahpojdafmblfabaaaaaaniafaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaahaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
lmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaadaaaaaakgiocaaaaaaaaaaaadaaaaaadgaaaaafdccabaaa
abaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pccabaaaacaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaa
baaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaa
bbaaaaaabaaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaa
bcaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaa
egacbaaaabaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaa
abaaaaaadcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaa
egacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgbpbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaa
afaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
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
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R2.xyz, R1, c[0].x;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.normal;
MOV R1.w, c[0].y;
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
MUL R1.xyz, R1, c[21].w;
MUL R0, R1.xyzz, R1.yzzx;
DP4 R5.z, R1, c[16];
DP4 R5.y, R1, c[15];
DP4 R5.x, R1, c[14];
MUL R4.xyz, vertex.attrib[14].w, R4;
DP4 R6.z, R0, c[19];
DP4 R6.x, R0, c[17];
DP4 R6.y, R0, c[18];
MUL R0.w, R1.y, R1.y;
MAD R0.w, R1.x, R1.x, -R0;
MUL R1.xyz, R0.w, c[20];
ADD R0.xyz, R5, R6;
ADD R0.xyz, R0, R1;
MUL result.texcoord[7].xyz, R0, c[0].z;
DP3 R1.w, R4, R4;
RSQ R0.w, R1.w;
MUL result.texcoord[4].xyz, R0.w, R4;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].z;
MUL R1.y, R1, c[13].x;
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MOV result.texcoord[2].xyz, R2;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 54 instructions, 7 R-regs
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
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c22, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.w, c22.x
mov r1.xyz, v2
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r2.xyz, r1, c22.x
mul r4.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r4
mov r0.w, c22.x
mov r0.xyz, v1
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
mul r0.xyz, r1, c21.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c22.y
dp4 r5.z, r0, c16
dp4 r5.y, r0, c15
dp4 r5.x, r0, c14
mul r0.y, r0, r0
mul r4.xyz, v2.w, r4
mad r0.x, r0, r0, -r0.y
dp3 r0.w, r4, r4
rsq r0.w, r0.w
mul o5.xyz, r0.w, r4
dp4 r0.w, v0, c3
dp4 r6.z, r1, c19
dp4 r6.x, r1, c17
dp4 r6.y, r1, c18
add r1.xyz, r5, r6
mul r0.xyz, r0.x, c20
add r0.xyz, r1, r0
mul o7.xyz, r0, c22.z
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c22.z
mul r1.y, r1, c12.x
mov o4.xyz, r3
mad o6.xy, r1.z, c13.zwzw, r1
mov o0, r0
mov o6.zw, r0
mov o3.xyz, r2
mov o1.xy, v3
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
Bind "tangent" TexCoord2
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
eefiecedcaiekpbjdiiaicmnddelfclbdjbedjliabaaaaaajaaiaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaahaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcmiagaaaaeaaaabaalcabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaai
pcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadgaaaaafmccabaaaagaaaaaakgaobaaaaaaaaaaa
diaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaa
aaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
hcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaa
aaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaa
abaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaai
bcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaai
ccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaai
ecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaakhccabaaaahaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
Vector 112 [unity_LightmapST]
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
eefieceddjnbgnghejiahhllpehhafgfmhhkjbmhabaaaaaajiagaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaahaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
neaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaaneaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcnaaeaaaaeaaaabaadeabaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaa
fjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaahaaaaaakgiocaaaaaaaaaaaahaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaabaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaa
egiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaabaaaaaabaaaaaaibcaabaaaabaaaaaaegbcbaaaabaaaaaa
egiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaaegbcbaaaabaaaaaa
egiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaaegbcbaaaabaaaaaa
egiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaa
diaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaacaaaaaa
egacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaaacaaaaaadgaaaaaf
hccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaaadaaaaaacgajbaaa
abaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaajgaebaaaabaaaaaa
cgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaa
diaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaagaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
agaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
Vector 112 [unity_LightmapST]
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
eefieceddjnbgnghejiahhllpehhafgfmhhkjbmhabaaaaaajiagaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaahaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
neaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaaneaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcnaaeaaaaeaaaabaadeabaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaa
fjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaalmccabaaaabaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaahaaaaaakgiocaaaaaaaaaaaahaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaabaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaa
egiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaabaaaaaabaaaaaaibcaabaaaabaaaaaaegbcbaaaabaaaaaa
egiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaaegbcbaaaabaaaaaa
egiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaaegbcbaaaabaaaaaa
egiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaa
diaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaacaaaaaa
egacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaaacaaaaaadgaaaaaf
hccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaaadaaaaaacgajbaaa
abaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaajgaebaaaabaaaaaa
cgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaa
diaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaagaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
agaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
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
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R2.xyz, R1, c[0].x;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.normal;
MOV R1.w, c[0].y;
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
MUL R1.xyz, R1, c[20].w;
MUL R0, R1.xyzz, R1.yzzx;
DP4 R5.z, R1, c[15];
DP4 R5.y, R1, c[14];
DP4 R5.x, R1, c[13];
MUL R4.xyz, vertex.attrib[14].w, R4;
DP4 R6.z, R0, c[18];
DP4 R6.x, R0, c[16];
DP4 R6.y, R0, c[17];
MUL R0.w, R1.y, R1.y;
MAD R0.w, R1.x, R1.x, -R0;
MUL R1.xyz, R0.w, c[19];
ADD R0.xyz, R5, R6;
DP3 R1.w, R4, R4;
RSQ R0.w, R1.w;
ADD R0.xyz, R0, R1;
MUL result.texcoord[4].xyz, R0.w, R4;
MUL result.texcoord[7].xyz, R0, c[0].z;
MOV result.texcoord[3].xyz, R3;
MOV result.texcoord[2].xyz, R2;
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
# 49 instructions, 7 R-regs
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
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord7 o6
def c20, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.w, c20.x
mov r1.xyz, v2
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r2.xyz, r1, c20.x
mul r4.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r4
mov r0.w, c20.x
mov r0.xyz, v1
mov r1.w, c20.y
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
mul r1.xyz, r1, c19.w
mul r0, r1.xyzz, r1.yzzx
dp4 r5.z, r1, c14
dp4 r5.y, r1, c13
dp4 r5.x, r1, c12
mul r4.xyz, v2.w, r4
dp4 r6.z, r0, c17
dp4 r6.x, r0, c15
dp4 r6.y, r0, c16
mul r0.w, r1.y, r1.y
mad r0.w, r1.x, r1.x, -r0
mul r1.xyz, r0.w, c18
add r0.xyz, r5, r6
dp3 r1.w, r4, r4
rsq r0.w, r1.w
add r0.xyz, r0, r1
mul o5.xyz, r0.w, r4
mul o6.xyz, r0, c20.z
mov o4.xyz, r3
mov o3.xyz, r2
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
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
eefiecedmpjbaooocaoackojkepnoaakfpdmaahmabaaaaaanaahaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaahaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefccaagaaaaeaaaabaaiiabaaaafjaaaaaeegiocaaa
aaaaaaaacnaaaaaafjaaaaaeegiocaaaabaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabaaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabbaaaaaabaaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaa
egiccaaaabaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaaaoaaaaaa
kgbkbaaaacaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
hccabaaaaeaaaaaaegacbaaaabaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaa
aaaaaaaajgaebaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaa
cgajbaaaabaaaaaaegacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhccabaaaafaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaa
aaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaa
abaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaabaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaabaaaaaaegiocaaaaaaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaabaaaaaaegiocaaaaaaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaabaaaaaaegiocaaaaaaaaaaaciaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaai
bcaabaaaadaaaaaaegiocaaaaaaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaai
ccaabaaaadaaaaaaegiocaaaaaaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaai
ecaabaaaadaaaaaaegiocaaaaaaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaaaaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaakhccabaaaagaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadoaaaaab"
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
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R1, c[7];
DP4 R0.y, R1, c[6];
DP4 R0.x, R1, c[5];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R3.xyz, R0.w, R0;
MUL R1.xyz, vertex.normal.y, c[10];
MAD R1.xyz, vertex.normal.x, c[9], R1;
MAD R1.xyz, vertex.normal.z, c[11], R1;
ADD R2.xyz, R1, c[0].x;
MUL R4.xyz, R2.zxyw, R3.yzxw;
MAD R4.xyz, R2.yzxw, R3.zxyw, -R4;
MOV R0.w, c[0].x;
MOV R0.xyz, vertex.normal;
MOV R1.w, c[0].y;
DP4 R1.z, R0, c[7];
DP4 R1.y, R0, c[6];
DP4 R1.x, R0, c[5];
MUL R1.xyz, R1, c[21].w;
MUL R0, R1.xyzz, R1.yzzx;
DP4 R5.z, R1, c[16];
DP4 R5.y, R1, c[15];
DP4 R5.x, R1, c[14];
MUL R4.xyz, vertex.attrib[14].w, R4;
DP4 R6.z, R0, c[19];
DP4 R6.x, R0, c[17];
DP4 R6.y, R0, c[18];
MUL R0.w, R1.y, R1.y;
MAD R0.w, R1.x, R1.x, -R0;
MUL R1.xyz, R0.w, c[20];
ADD R0.xyz, R5, R6;
ADD R0.xyz, R0, R1;
MUL result.texcoord[7].xyz, R0, c[0].z;
DP3 R1.w, R4, R4;
RSQ R0.w, R1.w;
MUL result.texcoord[4].xyz, R0.w, R4;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].z;
MUL R1.y, R1, c[13].x;
MOV result.texcoord[3].xyz, R3;
ADD result.texcoord[5].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
MOV result.texcoord[2].xyz, R2;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.texcoord[1].w, vertex.position, c[8];
DP4 result.texcoord[1].z, vertex.position, c[7];
DP4 result.texcoord[1].y, vertex.position, c[6];
DP4 result.texcoord[1].x, vertex.position, c[5];
END
# 54 instructions, 7 R-regs
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
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord7 o7
def c22, 0.00000000, 1.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_tangent0 v2
dcl_texcoord0 v3
mov r1.w, c22.x
mov r1.xyz, v2
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r3.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r2.xyz, r1, c22.x
mul r4.xyz, r2.zxyw, r3.yzxw
mad r4.xyz, r2.yzxw, r3.zxyw, -r4
mov r0.w, c22.x
mov r0.xyz, v1
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
mul r0.xyz, r1, c21.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c22.y
dp4 r5.z, r0, c16
dp4 r5.y, r0, c15
dp4 r5.x, r0, c14
mul r0.y, r0, r0
mul r4.xyz, v2.w, r4
mad r0.x, r0, r0, -r0.y
dp3 r0.w, r4, r4
rsq r0.w, r0.w
mul o5.xyz, r0.w, r4
dp4 r0.w, v0, c3
dp4 r6.z, r1, c19
dp4 r6.x, r1, c17
dp4 r6.y, r1, c18
add r1.xyz, r5, r6
mul r0.xyz, r0.x, c20
add r0.xyz, r1, r0
mul o7.xyz, r0, c22.z
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c22.z
mul r1.y, r1, c12.x
mov o4.xyz, r3
mad o6.xy, r1.z, c13.zwzw, r1
mov o0, r0
mov o6.zw, r0
mov o3.xyz, r2
mov o1.xy, v3
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
Bind "tangent" TexCoord2
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
eefiecedcaiekpbjdiiaicmnddelfclbdjbedjliabaaaaaajaaiaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaahaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcmiagaaaaeaaaabaalcabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaai
pcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaakhcaabaaaabaaaaaaegadbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadgaaaaafmccabaaaagaaaaaakgaobaaaaaaaaaaa
diaaaaaiicaabaaaabaaaaaabkaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaa
aaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
hcaabaaaaaaaaaaafgbfbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaabaaaaaaegacbaaa
aaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaa
abaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabeaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaai
bcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaai
ccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaai
ecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadiaaaaakhccabaaaahaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
Vector 3 [_Mask_ST]
Vector 4 [_Illumin_Color]
Float 5 [_Illumin]
SetTexture 0 [_Mask] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
DP3 R0.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.x;
DP3 R0.y, c[0], c[0];
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, c[0];
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R1, R0;
MAX R0.y, R0.x, c[6].x;
MAD R0.zw, fragment.texcoord[0].xyxy, c[3].xyxy, c[3];
TEX R0.x, R0.zwzw, texture[0], 2D;
MUL R1.xyz, R0.x, c[4];
MAD R2.xyz, R0.y, c[1], fragment.texcoord[7];
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MUL R1.xyz, R1, c[5].x;
TEX R0.xyz, R0, texture[1], 2D;
MAD result.color.xyz, R2, R0, R1;
MOV result.color.w, c[6].y;
END
# 17 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
Vector 3 [_Mask_ST]
Vector 4 [_Illumin_Color]
Float 5 [_Illumin]
SetTexture 0 [_Mask] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord7 v2.xyz
dp3 r0.x, v1, v1
rsq r0.w, r0.x
dp3_pp r0.y, c0, c0
rsq_pp r0.y, r0.y
mul_pp r0.xyz, r0.y, c0
mul r1.xyz, r0.w, v1
dp3 r0.z, r1, r0
mad r0.xy, v0, c3, c3.zwzw
max r0.z, r0, c6.x
texld r0.x, r0, s0
mul r1.xyz, r0.x, c4
mad r2.xyz, r0.z, c1, v2
mad r0.xy, v0, c2, c2.zwzw
mul r1.xyz, r1, c5.x
texld r0.xyz, r0, s1
mad oC0.xyz, r2, r0, r1
mov_pp oC0.w, c6.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Mask] 2D 1
SetTexture 1 [_Diffuse] 2D 0
ConstBuffer "$Globals" 112
Vector 16 [_LightColor0]
Vector 48 [_Diffuse_ST]
Vector 64 [_Mask_ST]
Vector 80 [_Illumin_Color]
Float 96 [_Illumin]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedlpoccgbkpibgemlgcjpfmeakknablgcaabaaaaaapaadaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaalmaaaaaaahaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcliacaaaaeaaaaaaakoaaaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaagaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaaj
icaabaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaabaaaaaaegbcbaaaagaaaaaadcaaaaaldcaabaaaabaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaa
afaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaa
agaaaaaadcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaa
acaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[7], texture[0], 2D;
MUL R2.xyz, R0.w, R0;
MAD R1.xy, fragment.texcoord[0], c[1], c[1].zwzw;
TEX R0.x, R1, texture[1], 2D;
MUL R1.xyz, R2, c[4].x;
MUL R2.xyz, R0.x, c[2];
MAD R0.xy, fragment.texcoord[0], c[0], c[0].zwzw;
MUL R2.xyz, R2, c[3].x;
TEX R0.xyz, R0, texture[2], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[4].y;
END
# 11 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord7 v2.xy
texld r0, v2, s0
mul_pp r2.xyz, r0.w, r0
mad r1.xy, v0, c1, c1.zwzw
texld r0.x, r1, s1
mul_pp r1.xyz, r2, c4.x
mul r2.xyz, r0.x, c2
mad r0.xy, v0, c0, c0.zwzw
mul r2.xyz, r2, c3.x
texld r0.xyz, r0, s2
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c4.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 2
SetTexture 2 [_Diffuse] 2D 1
ConstBuffer "$Globals" 128
Vector 64 [_Diffuse_ST]
Vector 80 [_Mask_ST]
Vector 96 [_Illumin_Color]
Float 112 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedhebojpadgallabbkgnnonklmaghbjonlabaaaaaaeiadaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaahaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaacaaaaeaaaaaaaieaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
diaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaagaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaahaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaeb
diaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaabaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[7], texture[0], 2D;
MUL R2.xyz, R0.w, R0;
MAD R1.xy, fragment.texcoord[0], c[1], c[1].zwzw;
TEX R0.x, R1, texture[1], 2D;
MUL R1.xyz, R2, c[4].x;
MUL R2.xyz, R0.x, c[2];
MAD R0.xy, fragment.texcoord[0], c[0], c[0].zwzw;
MUL R2.xyz, R2, c[3].x;
TEX R0.xyz, R0, texture[2], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[4].y;
END
# 11 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord7 v2.xy
texld r0, v2, s0
mul_pp r2.xyz, r0.w, r0
mad r1.xy, v0, c1, c1.zwzw
texld r0.x, r1, s1
mul_pp r1.xyz, r2, c4.x
mul r2.xyz, r0.x, c2
mad r0.xy, v0, c0, c0.zwzw
mul r2.xyz, r2, c3.x
texld r0.xyz, r0, s2
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c4.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 2
SetTexture 2 [_Diffuse] 2D 1
ConstBuffer "$Globals" 128
Vector 64 [_Diffuse_ST]
Vector 80 [_Mask_ST]
Vector 96 [_Illumin_Color]
Float 112 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedhebojpadgallabbkgnnonklmaghbjonlabaaaaaaeiadaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaahaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaacaaaaeaaaaaaaieaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
diaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaagaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaahaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaeb
diaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaadcaaaaal
dcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaabaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
Vector 3 [_Mask_ST]
Vector 4 [_Illumin_Color]
Float 5 [_Illumin]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
DP3 R0.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.w, R0.x;
DP3 R0.y, c[0], c[0];
RSQ R0.y, R0.y;
MUL R0.xyz, R0.y, c[0];
MUL R1.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R1, R0;
MAX R0.y, R0.x, c[6].x;
TXP R0.x, fragment.texcoord[5], texture[0], 2D;
MUL R1.xyz, R0.x, c[1];
MAD R0.zw, fragment.texcoord[0].xyxy, c[3].xyxy, c[3];
TEX R0.x, R0.zwzw, texture[1], 2D;
MUL R2.xyz, R0.x, c[4];
MAD R1.xyz, R0.y, R1, fragment.texcoord[7];
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MUL R2.xyz, R2, c[5].x;
TEX R0.xyz, R0, texture[2], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[6].y;
END
# 19 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
Vector 3 [_Mask_ST]
Vector 4 [_Illumin_Color]
Float 5 [_Illumin]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Mask] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c6, 0.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord2 v1.xyz
dcl_texcoord5 v2
dcl_texcoord7 v3.xyz
dp3 r0.x, v1, v1
rsq r0.w, r0.x
dp3_pp r0.y, c0, c0
rsq_pp r0.y, r0.y
mul_pp r0.xyz, r0.y, c0
mul r1.xyz, r0.w, v1
dp3 r0.x, r1, r0
max r0.y, r0.x, c6.x
texldp r0.x, v2, s0
mul r2.xyz, r0.x, c1
mad r1.xy, v0, c3, c3.zwzw
texld r0.x, r1, s1
mad r1.xyz, r0.y, r2, v3
mul r2.xyz, r0.x, c4
mad r0.xy, v0, c2, c2.zwzw
mul r2.xyz, r2, c5.x
texld r0.xyz, r0, s2
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c6.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Mask] 2D 2
SetTexture 2 [_Diffuse] 2D 1
ConstBuffer "$Globals" 176
Vector 80 [_LightColor0]
Vector 112 [_Diffuse_ST]
Vector 128 [_Mask_ST]
Vector 144 [_Illumin_Color]
Float 160 [_Illumin]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedlgcpjkfkbkbpgjnagafedoamiaadgbkaabaaaaaaimaeaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apalaaaaneaaaaaaahaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcdmadaaaaeaaaaaaampaaaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
adaaaaaagcbaaaadlcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaaj
icaabaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaoaaaaahgcaabaaaaaaaaaaaagbbbaaaagaaaaaa
pgbpbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaaiocaabaaaaaaaaaaaagaabaaaabaaaaaa
agijcaaaaaaaaaaaafaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegbcbaaaahaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaa
abaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaaj
pcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
diaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaajaaaaaa
diaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaaakaaaaaa
dcaaaaaldcaabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 2 [_Mask] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[7], texture[0], 2D;
MUL R2.xyz, R0.w, R0;
MAD R1.xy, fragment.texcoord[0], c[1], c[1].zwzw;
TEX R0.x, R1, texture[2], 2D;
MUL R1.xyz, R2, c[4].x;
MUL R2.xyz, R0.x, c[2];
MAD R0.xy, fragment.texcoord[0], c[0], c[0].zwzw;
MUL R2.xyz, R2, c[3].x;
TEX R0.xyz, R0, texture[3], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[4].y;
END
# 11 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 2 [_Mask] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s2
dcl_2d s3
def c4, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord7 v3.xy
texld r0, v3, s0
mul_pp r2.xyz, r0.w, r0
mad r1.xy, v0, c1, c1.zwzw
texld r0.x, r1, s2
mul_pp r1.xyz, r2, c4.x
mul r2.xyz, r0.x, c2
mad r0.xy, v0, c0, c0.zwzw
mul r2.xyz, r2, c3.x
texld r0.xyz, r0, s3
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c4.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 2
SetTexture 2 [_Diffuse] 2D 1
ConstBuffer "$Globals" 192
Vector 128 [_Diffuse_ST]
Vector 144 [_Mask_ST]
Vector 160 [_Illumin_Color]
Float 176 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjnadcobdphlgfcnjlljcbccmkkhcijgfabaaaaaagaadaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaahaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaneaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcbaacaaaaeaaaaaaaieaaaaaafjaaaaaeegiocaaa
aaaaaaaaamaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaaihcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaakaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaalaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
icaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
abaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 2 [_Mask] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 8, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[7], texture[0], 2D;
MUL R2.xyz, R0.w, R0;
MAD R1.xy, fragment.texcoord[0], c[1], c[1].zwzw;
TEX R0.x, R1, texture[2], 2D;
MUL R1.xyz, R2, c[4].x;
MUL R2.xyz, R0.x, c[2];
MAD R0.xy, fragment.texcoord[0], c[0], c[0].zwzw;
MUL R2.xyz, R2, c[3].x;
TEX R0.xyz, R0, texture[3], 2D;
MAD result.color.xyz, R1, R0, R2;
MOV result.color.w, c[4].y;
END
# 11 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Diffuse_ST]
Vector 1 [_Mask_ST]
Vector 2 [_Illumin_Color]
Float 3 [_Illumin]
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 2 [_Mask] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s2
dcl_2d s3
def c4, 8.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord7 v3.xy
texld r0, v3, s0
mul_pp r2.xyz, r0.w, r0
mad r1.xy, v0, c1, c1.zwzw
texld r0.x, r1, s2
mul_pp r1.xyz, r2, c4.x
mul r2.xyz, r0.x, c2
mad r0.xy, v0, c0, c0.zwzw
mul r2.xyz, r2, c3.x
texld r0.xyz, r0, s3
mad oC0.xyz, r1, r0, r2
mov_pp oC0.w, c4.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [unity_Lightmap] 2D 0
SetTexture 1 [_Mask] 2D 2
SetTexture 2 [_Diffuse] 2D 1
ConstBuffer "$Globals" 192
Vector 128 [_Diffuse_ST]
Vector 144 [_Mask_ST]
Vector 160 [_Illumin_Color]
Float 176 [_Illumin]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjnadcobdphlgfcnjlljcbccmkkhcijgfabaaaaaagaadaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaahaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaneaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcbaacaaaaeaaaaaaaieaaaaaafjaaaaaeegiocaaa
aaaaaaaaamaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaadcaaaaaldcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaaihcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaakaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaalaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
icaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
abaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab
"
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
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedjjackmedmcfkmahbdiffjoafkefgfiheabaaaaaaemagaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefcjmaeaaaaeaaaabaachabaaaafjaaaaaeegiocaaa
aaaaaaaaafaaaaaafjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaiccaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaiecaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaabaaaaaaegacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
acaaaaaadiaaaaahhcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaia
ebaaaaaaadaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaaaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
aaaaaaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhccabaaaagaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedpmkkpmjgmfhkapnlndnafnemkanapedgabaaaaaagmafaaaaadaaaaaa
cmaaaaaaniaaaaaajaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaaeaaaabaapfaaaaaa
fjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaanaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaacaaaaaaegiocaaa
aaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaa
aaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaabaaaaaaiccaabaaa
aaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaabaaaaaaiecaabaaa
aaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaadgaaaaafhccabaaa
adaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaacaaaaaa
egiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaa
amaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaabaaaaaadiaaaaah
hcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaadcaaaaakhcaabaaa
aaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaiaebaaaaaaacaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaacaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedjopagelkoopbnemfpbjcjmnpnjclcmlpabaaaaaaemagaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefcjmaeaaaaeaaaabaachabaaaafjaaaaaeegiocaaa
aaaaaaaaafaaaaaafjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaiccaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaiecaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaabaaaaaaegacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
acaaaaaadiaaaaahhcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaia
ebaaaaaaadaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiocaaaaaaaaaaaacaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
aaaaaaaaabaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpccabaaaagaaaaaaegiocaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaa
egaobaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedjjackmedmcfkmahbdiffjoafkefgfiheabaaaaaaemagaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefcjmaeaaaaeaaaabaachabaaaafjaaaaaeegiocaaa
aaaaaaaaafaaaaaafjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaiccaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaiecaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaabaaaaaaegacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
acaaaaaadiaaaaahhcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaia
ebaaaaaaadaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaaaaaaaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
aaaaaaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhccabaaaagaaaaaaegiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
Matrix 16 [_LightMatrix0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedmlnamaoapfpgjbkaabedaoaefbibokboabaaaaaaemagaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaafaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
lmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefcjmaeaaaaeaaaabaachabaaaafjaaaaaeegiocaaa
aaaaaaaaafaaaaaafjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaa
giaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaanaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiacaaaaaaaaaaaacaaaaaadcaaaaakdcaabaaa
abaaaaaaegiacaaaaaaaaaaaabaaaaaaagaabaaaaaaaaaaaegaabaaaabaaaaaa
dcaaaaakdcaabaaaabaaaaaaegiacaaaaaaaaaaaadaaaaaakgakbaaaaaaaaaaa
egaabaaaabaaaaaadcaaaaakmccabaaaabaaaaaaagiecaaaaaaaaaaaaeaaaaaa
pgapbaaaaaaaaaaaagaebaaaabaaaaaadgaaaaafpccabaaaacaaaaaaegaobaaa
aaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaabaaaaaaibcaabaaa
aaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaabaaaaaaiccaabaaa
aaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaabaaaaaaiecaabaaa
aaaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaadgaaaaafhccabaaa
adaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaacaaaaaa
egiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaa
amaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaabaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaabaaaaaadiaaaaah
hcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaadcaaaaakhcaabaaa
aaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaiaebaaaaaaacaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaacaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
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
eefiecedjelpdeoopadpedpbgdkpcnfblgcbogbcabaaaaaabiahaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcfaafaaaaeaaaabaafeabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaa
acaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaaagaabaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaagaaaaaa
egiocaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaakgakbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaahaaaaaaegiocaaaabaaaaaa
alaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
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
eefiecedjelpdeoopadpedpbgdkpcnfblgcbogbcabaaaaaabiahaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcfaafaaaaeaaaabaafeabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaa
acaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaaagaabaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaagaaaaaa
egiocaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaakgakbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaahaaaaaaegiocaaaabaaaaaa
alaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "UnityPerCamera" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedjdbokkigndphgmmfobicdpjkdiibgmjkabaaaaaacmagaaaaadaaaaaa
cmaaaaaaniaaaaaakiabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklfdeieefchmaeaaaaeaaaabaabpabaaaafjaaaaaeegiocaaa
aaaaaaaaagaaaaaafjaaaaaeegiocaaaabaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
abaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaa
baaaaaaibcaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabaaaaaaa
baaaaaaiccaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabbaaaaaa
baaaaaaiecaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaabaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaacaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaabaaaaaaegacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
acaaaaaadiaaaaahhcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaia
ebaaaaaaadaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaaaaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
agaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 256
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
eefiecedkjoahnniblfmjhfbkcaohodlkgbngkhfabaaaaaaamahaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
neaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaaneaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefceeafaaaaeaaaabaafbabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaa
fjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaabaaaaaa
diaaaaaidcaabaaaacaaaaaafgafbaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaa
dcaaaaakdcaabaaaacaaaaaaegiacaaaaaaaaaaaafaaaaaaagaabaaaabaaaaaa
egaabaaaacaaaaaadcaaaaakdcaabaaaacaaaaaaegiacaaaaaaaaaaaahaaaaaa
kgakbaaaabaaaaaaegaabaaaacaaaaaadcaaaaakmccabaaaabaaaaaaagiecaaa
aaaaaaaaaiaaaaaapgapbaaaabaaaaaaagaebaaaacaaaaaadgaaaaafpccabaaa
acaaaaaaegaobaaaabaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaadaaaaaa
baaaaaaibcaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaa
baaaaaaiccaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaa
baaaaaaiecaabaaaabaaaaaaegbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaacaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaacaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaabaaaaaaegacbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
acaaaaaadiaaaaahhcaabaaaadaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaajgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaia
ebaaaaaaadaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
agaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
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
eefiecedmodaoomfaaabboflfmnpbnlnedbbidlpabaaaaaakeagaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcnmaeaaaaeaaaabaadhabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
hccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaa
adaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaagaaaaaa
egiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaj
hccabaaaahaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaaabaaaaaa
doaaaaab"
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
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
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
eefiecedmodaoomfaaabboflfmnpbnlnedbbidlpabaaaaaakeagaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcnmaeaaaaeaaaabaadhabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
hccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaa
adaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaagaaaaaa
egiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaj
hccabaaaahaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaaabaaaaaa
doaaaaab"
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
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 256
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
eefiecedlelnjgfogmhafemalgjhleenelbnjojoabaaaaaabiahaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcfaafaaaaeaaaabaafeabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaa
fjaaaaaeegiocaaaabaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaa
agaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaaagaabaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaa
ahaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaagaaaaaa
egiocaaaaaaaaaaaaiaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaakgakbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaahaaaaaaegiocaaaabaaaaaa
alaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 256
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
eefiecedlelnjgfogmhafemalgjhleenelbnjojoabaaaaaabiahaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcfaafaaaaeaaaabaafeabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaa
fjaaaaaeegiocaaaabaaaaaaamaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaa
agaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaaagaabaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaa
ahaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaagaaaaaa
egiocaaaaaaaaaaaaiaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaabaaaaaaajaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaabaaaaaaaiaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaabaaaaaaakaaaaaakgakbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaahaaaaaaegiocaaaabaaaaaa
alaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
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
eefiecedmodaoomfaaabboflfmnpbnlnedbbidlpabaaaaaakeagaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcnmaeaaaaeaaaabaadhabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
hccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaa
adaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaagaaaaaa
egiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaj
hccabaaaahaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaaabaaaaaa
doaaaaab"
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
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 192
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
eefiecedmodaoomfaaabboflfmnpbnlnedbbidlpabaaaaaakeagaaaaadaaaaaa
cmaaaaaaniaaaaaamaabaaaaejfdeheokeaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaijaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaajaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaajiaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaafaepfdejfeejepeoaaeoepfc
enebemaafeebeoehefeofeaafeeffiedepepfceeaaklklklepfdeheooaaaaaaa
aiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
neaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaaneaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaa
ahaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcnmaeaaaaeaaaabaadhabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaaacaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
hccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaacaaaaaaegaobaaaaaaaaaaabaaaaaaibcaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabaaaaaaabaaaaaaiccaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabbaaaaaabaaaaaaiecaabaaaabaaaaaa
egbcbaaaabaaaaaaegiccaaaacaaaaaabcaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaacaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaa
agbabaaaacaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadiaaaaahhcaabaaa
adaaaaaacgajbaaaabaaaaaajgaebaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgaebaaaabaaaaaacgajbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaacaaaaaabaaaaaahicaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaabaaaaaa
dkaabaaaabaaaaaadiaaaaahhccabaaaafaaaaaapgapbaaaabaaaaaaegacbaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaa
adaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaagaaaaaa
egiccaaaaaaaaaaaaeaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaj
hccabaaaahaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaabaaaaaaabaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R1.w, R0.y, texture[0], 2D;
MAX R0.w, R0.x, c[3].x;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MUL R1.xyz, R1.w, c[1];
TEX R0.xyz, R0, texture[1], 2D;
MUL R1.xyz, R0.w, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[3].x;
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 0.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
mad r0.xyz, -v1, c0.w, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
dp3 r1.x, v2, v2
rsq r1.x, r1.x
mul r0.xyz, r0.w, r0
mul r1.xyz, r1.x, v2
dp3 r0.y, r1, r0
dp3 r0.x, v3, v3
texld r1.x, r0.x, s0
max r0.w, r0.y, c3.x
mad r0.xy, v0, c2, c2.zwzw
mul r1.xyz, r1.x, c1
texld r0.xyz, r0, s1
mul r1.xyz, r0.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c3.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_OFF" }
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffuse] 2D 1
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedopaeobpmoofndgaiddecaodphnbnibchabaaaaaanmadaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckeacaaaaeaaaaaaakjaaaaaa
fjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadcaaaaam
hcaabaaaaaaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
deaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaabaaaaaah
ccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaaefaaaaajpcaabaaa
abaaaaaafgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
ocaabaaaaaaaaaaaagaabaaaabaaaaaaagijcaaaaaaaaaaaafaaaaaadiaaaaah
hcaabaaaaaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaadcaaaaaldcaabaaa
abaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaa
aiaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_Diffuse] 2D 0
"3.0-!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
MAD R1.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MAX R0.w, R0.x, c[3].x;
TEX R0.xyz, R1, texture[0], 2D;
MUL R1.xyz, R0.w, c[1];
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[3].x;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_Diffuse] 2D 0
"ps_3_0
dcl_2d s0
def c3, 0.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
mad_pp r0.xyz, -v1, c0.w, c0
dp3_pp r1.x, r0, r0
dp3 r0.w, v2, v2
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.z, r0, r1
max r0.w, r0.z, c3.x
mad r0.xy, v0, c2, c2.zwzw
texld r0.xyz, r0, s0
mul r1.xyz, r0.w, c1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c3.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" }
SetTexture 0 [_Diffuse] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_LightColor0]
Vector 64 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedfehhkoebkhinpbfichekgbabbandecmnabaaaaaaeaadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefccaacaaaa
eaaaaaaaiiaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadcaaaaam
hcaabaaaaaaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
deaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaal
dcaabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0, 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
DP3 R0.z, fragment.texcoord[5], fragment.texcoord[5];
MAX R2.x, R0, c[3];
RCP R0.y, fragment.texcoord[5].w;
MAD R0.xy, fragment.texcoord[5], R0.y, c[3].y;
TEX R0.w, R0, texture[0], 2D;
SLT R0.x, c[3], fragment.texcoord[5].z;
MUL R0.x, R0, R0.w;
TEX R1.w, R0.z, texture[1], 2D;
MUL R0.z, R0.x, R1.w;
MUL R1.xyz, R0.z, c[1];
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0.xyz, R0, texture[2], 2D;
MUL R1.xyz, R2.x, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[3].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 0.00000000, 1.00000000, 0.50000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
mad r0.xyz, -v1, c0.w, c0
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
rcp r0.y, v3.w
mad r1.xy, v3, r0.y, c3.z
max r1.w, r0.x, c3.x
dp3 r0.x, v3, v3
texld r0.w, r1, s0
cmp r0.y, -v3.z, c3.x, c3
texld r0.x, r0.x, s1
mul_pp r0.y, r0, r0.w
mul_pp r0.z, r0.y, r0.x
mul r1.xyz, r0.z, c1
mad r0.xy, v0, c2, c2.zwzw
texld r0.xyz, r0, s2
mul r1.xyz, r1.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c3.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_OFF" }
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecediidealnmeebgcmphcgnokcepbcamopfdabaaaaaanaaeaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcjiadaaaaeaaaaaaaogaaaaaa
fjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaaoaaaaahdcaabaaa
aaaaaaaaegbabaaaagaaaaaapgbpbaaaagaaaaaaaaaaaaakdcaabaaaaaaaaaaa
egaabaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dbaaaaahbcaabaaaaaaaaaaaabeaaaaaaaaaaaaackbabaaaagaaaaaaabaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahbcaabaaa
aaaaaaaadkaabaaaaaaaaaaaakaabaaaaaaaaaaabaaaaaahccaabaaaaaaaaaaa
egbcbaaaagaaaaaaegbcbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaafgafbaaa
aaaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaa
aaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaamhcaabaaaabaaaaaapgipcaaa
abaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaaaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaadaaaaaa
egbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaah
hccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTextureB0] 2D 0
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
MAX R1.w, R0.x, c[3].x;
DP3 R0.x, fragment.texcoord[5], fragment.texcoord[5];
TEX R2.w, R0.x, texture[0], 2D;
TEX R0.w, fragment.texcoord[5], texture[1], CUBE;
MUL R0.z, R2.w, R0.w;
MUL R1.xyz, R0.z, c[1];
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0.xyz, R0, texture[2], 2D;
MUL R1.xyz, R1.w, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[3].x;
END
# 19 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTextureB0] 2D 0
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
def c3, 0.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
mad r0.xyz, -v1, c0.w, c0
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
max r1.w, r0.x, c3.x
dp3 r0.x, v3, v3
texld r0.x, r0.x, s0
texld r0.w, v3, s1
mul r0.z, r0.x, r0.w
mul r1.xyz, r0.z, c1
mad r0.xy, v0, c2, c2.zwzw
texld r0.xyz, r0, s2
mul r1.xyz, r1.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c3.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_OFF" }
SetTexture 0 [_LightTextureB0] 2D 1
SetTexture 1 [_LightTexture0] CUBE 0
SetTexture 2 [_Diffuse] 2D 2
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedllfmecginbloklgnkpehbajgkcbndgikabaaaaaadiaeaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcaaadaaaaeaaaaaaamaaaaaaa
fjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaamhcaabaaa
aaaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
abaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadeaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaabaaaaaahccaabaaa
aaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaa
fgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaa
acaaaaaaegbcbaaaagaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaah
ccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaaacaaaaaadiaaaaaiocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagijcaaaaaaaaaaaafaaaaaadiaaaaahhcaabaaa
aaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
MAX R0.w, R0.x, c[3].x;
TEX R1.w, fragment.texcoord[5], texture[0], 2D;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MUL R1.xyz, R1.w, c[1];
TEX R0.xyz, R0, texture[1], 2D;
MUL R1.xyz, R0.w, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[3].x;
END
# 16 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 0.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xy
mad_pp r0.xyz, -v1, c0.w, c0
dp3_pp r1.x, r0, r0
dp3 r0.w, v2, v2
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
max r0.w, r0.x, c3.x
texld r1.w, v3, s0
mad r0.xy, v0, c2, c2.zwzw
mul r1.xyz, r1.w, c1
texld r0.xyz, r0, s1
mul r1.xyz, r0.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c3.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_OFF" }
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_Diffuse] 2D 1
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedfllomkkapofghdmchhhjdbkllccmjhpoabaaaaaamaadaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapahaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefciiacaaaaeaaaaaaakcaaaaaa
fjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadcaaaaam
hcaabaaaaaaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
deaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
diaaaaaiocaabaaaaaaaaaaapgapbaaaabaaaaaaagijcaaaaaaaaaaaafaaaaaa
diaaaaahhcaabaaaaaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaadcaaaaal
dcaabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_LightColor0]
Vector 3 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ 0, 0.5, 1 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, R1.x, fragment.texcoord[2];
DP3 R0.x, R1, R0;
MAX R1.x, R0, c[4];
RCP R0.y, fragment.texcoord[6].w;
TXP R0.x, fragment.texcoord[6], texture[2], 2D;
MAD R0.x, -fragment.texcoord[6].z, R0.y, R0;
MOV R0.z, c[4];
CMP R0.x, R0, c[1], R0.z;
RCP R0.y, fragment.texcoord[5].w;
MAD R0.zw, fragment.texcoord[5].xyxy, R0.y, c[4].y;
TEX R1.w, R0.zwzw, texture[0], 2D;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R0.w, R0.y, texture[1], 2D;
SLT R0.y, c[4].x, fragment.texcoord[5].z;
MUL R0.y, R0, R1.w;
MUL R0.y, R0, R0.w;
MUL R0.z, R0.y, R0.x;
MUL R1.yzw, R0.z, c[2].xxyz;
MAD R0.xy, fragment.texcoord[0], c[3], c[3].zwzw;
TEX R0.xyz, R0, texture[3], 2D;
MUL R1.xyz, R1.x, R1.yzww;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[4].x;
END
# 29 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_LightColor0]
Vector 3 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c4, 0.00000000, 1.00000000, 0.50000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
mad r0.xyz, -v1, c0.w, c0
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
max r1.w, r0.x, c4.x
texldp r0.x, v4, s2
rcp r0.y, v4.w
mad r0.y, -v4.z, r0, r0.x
mov r0.z, c1.x
cmp r0.y, r0, c4, r0.z
rcp r0.x, v3.w
mad r1.xy, v3, r0.x, c4.z
dp3 r0.x, v3, v3
texld r0.w, r1, s0
cmp r0.z, -v3, c4.x, c4.y
mul_pp r0.z, r0, r0.w
texld r0.x, r0.x, s1
mul_pp r0.x, r0.z, r0
mul_pp r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c2
mad r0.xy, v0, c3, c3.zwzw
texld r0.xyz, r0, s3
mul r1.xyz, r1.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c4.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_ShadowMapTexture] 2D 0
SetTexture 3 [_Diffuse] 2D 3
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedefbbojheinadnimfhojnllpjchenofbcabaaaaaamaafaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefchaaeaaaaeaaaaaaabmabaaaafjaaaaaeegiocaaa
aaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
pcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaagaaaaaapgbpbaaa
agaaaaaaaaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadbaaaaahbcaabaaaaaaaaaaaabeaaaaa
aaaaaaaackbabaaaagaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaiadpdiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaa
aaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aoaaaaahocaabaaaaaaaaaaaagbjbaaaahaaaaaapgbpbaaaahaaaaaaefaaaaaj
pcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaa
dbaaaaahccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaaaaaaaaaadhaaaaak
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaacaaaaaabiaaaaaaabeaaaaa
aaaaiadpdiaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaa
dcaaaaamhcaabaaaabaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaa
acaaaaaaegiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaa
egbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaa
abaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadcaaaaal
dcaabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_LightColor0]
Vector 3 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[5] = { program.local[0..3],
		{ 0, 0.5, 1 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, R1.x, fragment.texcoord[2];
DP3 R0.x, R1, R0;
MAX R1.x, R0, c[4];
MOV R0.x, c[4].z;
ADD R0.y, R0.x, -c[1].x;
RCP R0.z, fragment.texcoord[5].w;
MAD R0.zw, fragment.texcoord[5].xyxy, R0.z, c[4].y;
TXP R0.x, fragment.texcoord[6], texture[2], SHADOW2D;
MAD R0.x, R0, R0.y, c[1];
TEX R1.w, R0.zwzw, texture[0], 2D;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R0.w, R0.y, texture[1], 2D;
SLT R0.y, c[4].x, fragment.texcoord[5].z;
MUL R0.y, R0, R1.w;
MUL R0.y, R0, R0.w;
MUL R0.z, R0.y, R0.x;
MUL R1.yzw, R0.z, c[2].xxyz;
MAD R0.xy, fragment.texcoord[0], c[3], c[3].zwzw;
TEX R0.xyz, R0, texture[3], 2D;
MUL R1.xyz, R1.x, R1.yzww;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[4].x;
END
# 28 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_LightColor0]
Vector 3 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c4, 0.00000000, 1.00000000, 0.50000000, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
mad r0.xyz, -v1, c0.w, c0
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
max r1.w, r0.x, c4.x
mov r0.x, c1
rcp r0.z, v3.w
mad r1.xy, v3, r0.z, c4.z
add r0.y, c4, -r0.x
texldp r0.x, v4, s2
mad r0.y, r0.x, r0, c1.x
dp3 r0.x, v3, v3
texld r0.w, r1, s0
cmp r0.z, -v3, c4.x, c4.y
mul_pp r0.z, r0, r0.w
texld r0.x, r0.x, s1
mul_pp r0.x, r0.z, r0
mul_pp r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c2
mad r0.xy, v0, c3, c3.zwzw
texld r0.xyz, r0, s3
mul r1.xyz, r1.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c4.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_NATIVE" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_Diffuse] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedmanfelcbookhchdnolhmnamcahkoldonabaaaaaanaafaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefciaaeaaaaeaaaaaaacaabaaaafjaaaaaeegiocaaa
aaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaiaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
pcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaagaaaaaapgbpbaaa
agaaaaaaaaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadbaaaaahbcaabaaaaaaaaaaaabeaaaaa
aaaaaaaackbabaaaagaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaiadpdiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaa
aaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aoaaaaahocaabaaaaaaaaaaaagbjbaaaahaaaaaapgbpbaaaahaaaaaaehaaaaal
ccaabaaaaaaaaaaajgafbaaaaaaaaaaaaghabaaaadaaaaaaaagabaaaaaaaaaaa
dkaabaaaaaaaaaaaaaaaaaajecaabaaaaaaaaaaaakiacaiaebaaaaaaacaaaaaa
biaaaaaaabeaaaaaaaaaiadpdcaaaaakccaabaaaaaaaaaaabkaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakiacaaaacaaaaaabiaaaaaadiaaaaahbcaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaa
aaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaamhcaabaaaabaaaaaapgipcaaa
abaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaaaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaadaaaaaa
egbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaadiaaaaah
hccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"3.0-!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
MAX R0.w, R0.x, c[3].x;
TXP R1.x, fragment.texcoord[5], texture[0], 2D;
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
MUL R1.xyz, R1.x, c[1];
TEX R0.xyz, R0, texture[1], 2D;
MUL R1.xyz, R0.w, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[3].x;
END
# 16 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffuse] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 0.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
mad_pp r0.xyz, -v1, c0.w, c0
dp3_pp r1.x, r0, r0
dp3 r0.w, v2, v2
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
max r0.w, r0.x, c3.x
texldp r1.x, v3, s0
mad r0.xy, v0, c2, c2.zwzw
mul r1.xyz, r1.x, c1
texld r0.xyz, r0, s1
mul r1.xyz, r0.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c3.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" }
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_Diffuse] 2D 1
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedjejcjhddpnanlkcjolblaocjiabdglblabaaaaaanmadaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckeacaaaaeaaaaaaakjaaaaaa
fjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
lcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadcaaaaam
hcaabaaaaaaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
deaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaaaoaaaaah
gcaabaaaaaaaaaaaagbbbaaaagaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaa
abaaaaaajgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
ocaabaaaaaaaaaaaagaabaaaabaaaaaaagijcaaaaaaaaaaaafaaaaaadiaaaaah
hcaabaaaaaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaadcaaaaaldcaabaaa
abaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaa
aiaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
MAX R1.w, R0.x, c[3].x;
TXP R0.x, fragment.texcoord[6], texture[0], 2D;
TEX R0.w, fragment.texcoord[5], texture[1], 2D;
MUL R0.z, R0.w, R0.x;
MUL R1.xyz, R0.z, c[1];
MAD R0.xy, fragment.texcoord[0], c[2], c[2].zwzw;
TEX R0.xyz, R0, texture[2], 2D;
MUL R1.xyz, R1.w, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[3].x;
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 0.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xy
dcl_texcoord6 v4
mad_pp r0.xyz, -v1, c0.w, c0
dp3_pp r1.x, r0, r0
dp3 r0.w, v2, v2
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
max r0.w, r0.x, c3.x
texldp r0.x, v4, s0
texld r1.w, v3, s1
mul r0.z, r1.w, r0.x
mul r1.xyz, r0.z, c1
mad r0.xy, v0, c2, c2.zwzw
texld r0.xyz, r0, s2
mul r1.xyz, r0.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c3.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" "SHADOWS_SCREEN" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_ShadowMapTexture] 2D 0
SetTexture 2 [_Diffuse] 2D 2
ConstBuffer "$Globals" 256
Vector 144 [_LightColor0]
Vector 192 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedhfgjbbpldhaicjpeaigdmhklcfmkmeaoabaaaaaafmaeaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapahaaaaneaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaaaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaagaaaaaaapalaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcamadaaaaeaaaaaaamdaaaaaafjaaaaaeegiocaaa
aaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
lcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaadcaaaaam
hcaabaaaaaaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
deaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaaaoaaaaah
gcaabaaaaaaaaaaaagbbbaaaagaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaa
abaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
diaaaaahccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaaacaaaaaadiaaaaai
ocaabaaaaaaaaaaafgafbaaaaaaaaaaaagijcaaaaaaaaaaaajaaaaaadiaaaaah
hcaabaaaaaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaadcaaaaaldcaabaaa
abaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaamaaaaaaogikcaaaaaaaaaaa
amaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaa
aagabaaaacaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..4],
		{ 0, 0.97000003, 1 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
TEX R1, fragment.texcoord[6], texture[0], CUBE;
DP3 R0.y, fragment.texcoord[6], fragment.texcoord[6];
MAX R0.w, R0.x, c[5].x;
RSQ R0.x, R0.y;
RCP R0.x, R0.x;
DP4 R0.y, R1, c[6];
MUL R0.x, R0, c[1].w;
MAD R0.z, -R0.x, c[5].y, R0.y;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
MOV R0.x, c[5].z;
CMP R0.x, R0.z, c[2], R0;
TEX R1.w, R0.y, texture[1], 2D;
MUL R0.z, R1.w, R0.x;
MUL R1.xyz, R0.z, c[3];
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0.xyz, R0, texture[2], 2D;
MUL R1.xyz, R0.w, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[5].x;
END
# 27 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_2d s2
def c5, 0.00000000, 0.97000003, 1.00000000, 0
def c6, 1.00000000, 0.00392157, 0.00001538, 0.00000006
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
mad r0.xyz, -v1, c0.w, c0
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
dp3 r0.y, v4, v4
max r0.w, r0.x, c5.x
rsq r0.x, r0.y
texld r1, v4, s0
rcp r0.x, r0.x
dp4 r0.y, r1, c6
mul r0.x, r0, c1.w
mad r0.y, -r0.x, c5, r0
mov r0.z, c2.x
dp3 r0.x, v3, v3
cmp r0.y, r0, c5.z, r0.z
texld r0.x, r0.x, s1
mul r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c3
mad r0.xy, v0, c4, c4.zwzw
texld r0.xyz, r0, s2
mul r1.xyz, r0.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c5.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_ShadowMapTexture] CUBE 0
SetTexture 2 [_Diffuse] 2D 2
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedkinmmmkaipndidhmgggidpkljfajfpdcabaaaaaaeeafaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcpeadaaaaeaaaaaaapnaaaaaafjaaaaaeegiocaaa
aaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaahaaaaaa
egbcbaaaahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaai
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaabaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaomfbhidpefaaaaajpcaabaaa
abaaaaaaegbcbaaaahaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaabbaaaaak
ccaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdh
afidibdddbaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaa
dhaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaacaaaaaabiaaaaaa
abeaaaaaaaaaiadpbaaaaaahccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaa
agaaaaaaefaaaaajpcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
abaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
afaaaaaadcaaaaamhcaabaaaabaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaia
ebaaaaaaacaaaaaaegiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahicaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaa
aaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaabaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaa
dcaaaaaldcaabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaa
ogikcaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
PARAM c[7] = { program.local[0..4],
		{ 0, 0.97000003, 1 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[2];
MUL R0.xyz, R0.w, R0;
DP3 R0.x, R1, R0;
MAX R1.x, R0, c[5];
TEX R0, fragment.texcoord[6], texture[0], CUBE;
DP4 R0.x, R0, c[6];
DP3 R1.y, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.y, R1.y;
RCP R0.y, R1.y;
MUL R0.y, R0, c[1].w;
MAD R0.x, -R0.y, c[5].y, R0;
MOV R0.z, c[5];
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
CMP R0.x, R0, c[2], R0.z;
TEX R1.w, R0.y, texture[1], 2D;
TEX R0.w, fragment.texcoord[5], texture[2], CUBE;
MUL R0.y, R1.w, R0.w;
MUL R0.z, R0.y, R0.x;
MUL R1.yzw, R0.z, c[3].xxyz;
MAD R0.xy, fragment.texcoord[0], c[4], c[4].zwzw;
TEX R0.xyz, R0, texture[3], 2D;
MUL R1.xyz, R1.x, R1.yzww;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[5].x;
END
# 29 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_cube s2
dcl_2d s3
def c5, 0.00000000, 0.97000003, 1.00000000, 0
def c6, 1.00000000, 0.00392157, 0.00001538, 0.00000006
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
mad r0.xyz, -v1, c0.w, c0
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.x, r0, r1
max r1.w, r0.x, c5.x
texld r0, v4, s0
dp4 r0.y, r0, c6
dp3 r1.x, v4, v4
rsq r1.x, r1.x
rcp r0.x, r1.x
mul r0.x, r0, c1.w
mad r0.x, -r0, c5.y, r0.y
mov r0.z, c2.x
cmp r0.y, r0.x, c5.z, r0.z
dp3 r0.x, v3, v3
texld r0.w, v3, s2
texld r0.x, r0.x, s1
mul r0.x, r0, r0.w
mul r0.z, r0.x, r0.y
mul r1.xyz, r0.z, c3
mad r0.xy, v0, c4, c4.zwzw
texld r0.xyz, r0, s3
mul r1.xyz, r1.w, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c5.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" }
SetTexture 0 [_LightTextureB0] 2D 2
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_ShadowMapTexture] CUBE 0
SetTexture 3 [_Diffuse] 2D 3
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedoodllokmfclecdbekbofpfopigpfhfmdabaaaaaakaafaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcfaaeaaaaeaaaaaaabeabaaaafjaaaaaeegiocaaa
aaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaaffffaaaafidaaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaahaaaaaaegbcbaaa
ahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaa
aaaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaabaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaomfbhidpefaaaaajpcaabaaaabaaaaaa
egbcbaaaahaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaabbaaaaakccaabaaa
aaaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdhafidibdd
dbaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaadhaaaaak
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaacaaaaaabiaaaaaaabeaaaaa
aaaaiadpbaaaaaahccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
acaaaaaaefaaaaajpcaabaaaacaaaaaaegbcbaaaagaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaahccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaa
acaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaa
dcaaaaamhcaabaaaabaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaa
acaaaaaaegiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaa
egbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaa
abaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadcaaaaal
dcaabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_ShadowOffsets0]
Vector 3 [_ShadowOffsets1]
Vector 4 [_ShadowOffsets2]
Vector 5 [_ShadowOffsets3]
Vector 6 [_LightColor0]
Vector 7 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0, 0.5, 1, 0.25 } };
TEMP R0;
TEMP R1;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
RCP R1.y, fragment.texcoord[6].w;
MUL R0.xyz, R0.w, R0;
MUL R1.xzw, R1.x, fragment.texcoord[2].xyyz;
DP3 R0.z, R1.xzww, R0;
MAD R0.xy, fragment.texcoord[6], R1.y, c[5];
TEX R0.x, R0, texture[2], 2D;
MAD R1.zw, fragment.texcoord[6].xyxy, R1.y, c[4].xyxy;
MOV R0.w, R0.x;
TEX R0.x, R1.zwzw, texture[2], 2D;
MAX R1.x, R0.z, c[8];
MAD R1.zw, fragment.texcoord[6].xyxy, R1.y, c[3].xyxy;
MOV R0.z, R0.x;
TEX R0.x, R1.zwzw, texture[2], 2D;
MAD R1.zw, fragment.texcoord[6].xyxy, R1.y, c[2].xyxy;
MOV R0.y, R0.x;
TEX R0.x, R1.zwzw, texture[2], 2D;
MAD R0, -fragment.texcoord[6].z, R1.y, R0;
MOV R1.z, c[8];
CMP R0, R0, c[1].x, R1.z;
DP4 R0.x, R0, c[8].w;
RCP R1.y, fragment.texcoord[5].w;
MAD R0.zw, fragment.texcoord[5].xyxy, R1.y, c[8].y;
TEX R1.w, R0.zwzw, texture[0], 2D;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
TEX R0.w, R0.y, texture[1], 2D;
SLT R0.y, c[8].x, fragment.texcoord[5].z;
MUL R0.y, R0, R1.w;
MUL R0.y, R0, R0.w;
MUL R0.z, R0.y, R0.x;
MUL R1.yzw, R0.z, c[6].xxyz;
MAD R0.xy, fragment.texcoord[0], c[7], c[7].zwzw;
TEX R0.xyz, R0, texture[3], 2D;
MUL R1.xyz, R1.x, R1.yzww;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[8].x;
END
# 40 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_ShadowOffsets0]
Vector 3 [_ShadowOffsets1]
Vector 4 [_ShadowOffsets2]
Vector 5 [_ShadowOffsets3]
Vector 6 [_LightColor0]
Vector 7 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c8, 0.00000000, 1.00000000, 0.50000000, 0.25000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
mad r0.xyz, -v1, c0.w, c0
dp3 r1.x, r0, r0
rsq r1.x, r1.x
dp3 r0.w, v2, v2
rcp r1.y, v4.w
mul r2.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.z, r0, r2
mad r0.xy, v4, r1.y, c5
texld r0.x, r0, s2
mad r2.xy, v4, r1.y, c4
mov r0.w, r0.x
texld r0.x, r2, s2
max r1.x, r0.z, c8
mad r2.xy, v4, r1.y, c3
mov r0.z, r0.x
texld r0.x, r2, s2
mad r2.xy, v4, r1.y, c2
mov r0.y, r0.x
texld r0.x, r2, s2
mad r0, -v4.z, r1.y, r0
mov r1.z, c1.x
cmp r0, r0, c8.y, r1.z
dp4_pp r0.y, r0, c8.w
rcp r1.y, v3.w
mad r2.xy, v3, r1.y, c8.z
dp3 r0.x, v3, v3
texld r0.w, r2, s0
cmp r0.z, -v3, c8.x, c8.y
mul_pp r0.z, r0, r0.w
texld r0.x, r0.x, s1
mul_pp r0.x, r0.z, r0
mul_pp r0.z, r0.x, r0.y
mul r2.xyz, r0.z, c6
mad r0.xy, v0, c7, c7.zwzw
texld r0.xyz, r0, s3
mul r1.xyz, r1.x, r2
mul oC0.xyz, r1, r0
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_ShadowMapTexture] 2D 0
SetTexture 3 [_Diffuse] 2D 3
ConstBuffer "$Globals" 256
Vector 16 [_ShadowOffsets0]
Vector 32 [_ShadowOffsets1]
Vector 48 [_ShadowOffsets2]
Vector 64 [_ShadowOffsets3]
Vector 144 [_LightColor0]
Vector 192 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedfpchfccechkbhnplpichmmhafckehfdpabaaaaaabmahaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcmmafaaaaeaaaaaaahdabaaaafjaaaaaeegiocaaa
aaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
pcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaaaoaaaaahhcaabaaaaaaaaaaaegbcbaaaahaaaaaapgbpbaaa
ahaaaaaaaaaaaaaidcaabaaaabaaaaaaegaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaa
aagabaaaaaaaaaaaaaaaaaaidcaabaaaacaaaaaaegaabaaaaaaaaaaaegiacaaa
aaaaaaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaaaaaaaaadgaaaaafccaabaaaabaaaaaaakaabaaaacaaaaaa
aaaaaaaidcaabaaaacaaaaaaegaabaaaaaaaaaaaegiacaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
aaaaaaaadgaaaaafecaabaaaabaaaaaaakaabaaaacaaaaaaaaaaaaaidcaabaaa
aaaaaaaaegaabaaaaaaaaaaaegiacaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadgaaaaaf
icaabaaaabaaaaaaakaabaaaacaaaaaadbaaaaahpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgakbaaaaaaaaaaadhaaaaanpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
agiacaaaacaaaaaabiaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
bbaaaaakbcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiado
aaaaiadoaaaaiadoaoaaaaahgcaabaaaaaaaaaaaagbbbaaaagaaaaaapgbpbaaa
agaaaaaaaaaaaaakgcaabaaaaaaaaaaafgagbaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaadpaaaaaadpaaaaaaaaefaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadbaaaaahccaabaaaaaaaaaaaabeaaaaa
aaaaaaaackbabaaaagaaaaaaabaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaaaaaaiadpdiaaaaahccaabaaaaaaaaaaadkaabaaaabaaaaaabkaabaaa
aaaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaakgakbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaabaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaajaaaaaadcaaaaam
hcaabaaaabaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaa
deaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaa
abaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaamaaaaaaogikcaaaaaaaaaaa
amaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaa
aagabaaaadaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_ShadowOffsets0]
Vector 3 [_ShadowOffsets1]
Vector 4 [_ShadowOffsets2]
Vector 5 [_ShadowOffsets3]
Vector 6 [_LightColor0]
Vector 7 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
OPTION ARB_fragment_program_shadow;
PARAM c[9] = { program.local[0..7],
		{ 0, 0.5, 1, 0.25 } };
TEMP R0;
TEMP R1;
TEMP R2;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, R0;
RCP R0.w, fragment.texcoord[6].w;
DP3 R0.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[2];
DP3 R0.y, R0, R1;
MAD R1.xyz, fragment.texcoord[6], R0.w, c[3];
TEX R1.x, R1, texture[2], SHADOW2D;
MAD R2.xyz, fragment.texcoord[6], R0.w, c[5];
TEX R0.x, R2, texture[2], SHADOW2D;
MOV R1.y, R1.x;
MAX R2.x, R0.y, c[8];
MOV R1.w, R0.x;
MAD R0.xyz, fragment.texcoord[6], R0.w, c[4];
TEX R0.x, R0, texture[2], SHADOW2D;
MOV R1.z, R0.x;
MAD R0.xyz, fragment.texcoord[6], R0.w, c[2];
MOV R1.x, c[8].z;
ADD R0.w, R1.x, -c[1].x;
TEX R1.x, R0, texture[2], SHADOW2D;
MAD R1, R1, R0.w, c[1].x;
RCP R0.x, fragment.texcoord[5].w;
MAD R0.xy, fragment.texcoord[5], R0.x, c[8].y;
TEX R0.w, R0, texture[0], 2D;
SLT R0.x, c[8], fragment.texcoord[5].z;
DP4 R1.x, R1, c[8].w;
DP3 R0.z, fragment.texcoord[5], fragment.texcoord[5];
MUL R0.x, R0, R0.w;
TEX R1.w, R0.z, texture[1], 2D;
MUL R0.x, R0, R1.w;
MUL R0.x, R0, R1;
MUL R1.xyz, R0.x, c[6];
MAD R0.zw, fragment.texcoord[0].xyxy, c[7].xyxy, c[7];
TEX R0.xyz, R0.zwzw, texture[3], 2D;
MUL R1.xyz, R2.x, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[8].x;
END
# 40 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightShadowData]
Vector 2 [_ShadowOffsets0]
Vector 3 [_ShadowOffsets1]
Vector 4 [_ShadowOffsets2]
Vector 5 [_ShadowOffsets3]
Vector 6 [_LightColor0]
Vector 7 [_Diffuse_ST]
SetTexture 0 [_LightTexture0] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c8, 0.00000000, 1.00000000, 0.50000000, 0.25000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3
dcl_texcoord6 v4
mad r0.xyz, -v1, c0.w, c0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r2.xyz, r0.w, r0
dp3 r0.x, v2, v2
rsq r1.x, r0.x
rcp r0.w, v4.w
mad r0.xyz, v4, r0.w, c5
mul r1.xyz, r1.x, v2
dp3 r1.x, r1, r2
texld r0.x, r0, s2
max r2.x, r1, c8
mad r1.xyz, v4, r0.w, c3
texld r1.x, r1, s2
mov_pp r1.w, r0.x
mad r0.xyz, v4, r0.w, c4
texld r0.x, r0, s2
mov_pp r1.z, r0.x
mov_pp r1.y, r1.x
mad r0.xyz, v4, r0.w, c2
mov r1.x, c1
add r0.w, c8.y, -r1.x
texld r1.x, r0, s2
mad r1, r1, r0.w, c1.x
dp4_pp r0.z, r1, c8.w
rcp r0.x, v3.w
mad r1.xy, v3, r0.x, c8.z
dp3 r0.x, v3, v3
texld r0.w, r1, s0
cmp r0.y, -v3.z, c8.x, c8
mul_pp r0.y, r0, r0.w
texld r0.x, r0.x, s1
mul_pp r0.x, r0.y, r0
mul_pp r0.z, r0.x, r0
mul r1.xyz, r0.z, c6
mad r0.xy, v0, c7, c7.zwzw
texld r0.xyz, r0, s3
mul r1.xyz, r2.x, r1
mul oC0.xyz, r1, r0
mov_pp oC0.w, c8.x
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" "SHADOWS_DEPTH" "SHADOWS_SOFT" "SHADOWS_NATIVE" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_LightTextureB0] 2D 2
SetTexture 2 [_Diffuse] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 256
Vector 16 [_ShadowOffsets0]
Vector 32 [_ShadowOffsets1]
Vector 48 [_ShadowOffsets2]
Vector 64 [_ShadowOffsets3]
Vector 144 [_LightColor0]
Vector 192 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedmodednbdnljgfjocjpkhamedhfjaeemkabaaaaaapmagaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefckmafaaaaeaaaaaaaglabaaaafjaaaaaeegiocaaa
aaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaiaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
pcbabaaaagaaaaaagcbaaaadpcbabaaaahaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaaaaaaaaajbcaabaaaaaaaaaaaakiacaiaebaaaaaaacaaaaaa
biaaaaaaabeaaaaaaaaaiadpaoaaaaahocaabaaaaaaaaaaaagbjbaaaahaaaaaa
pgbpbaaaahaaaaaaaaaaaaaihcaabaaaabaaaaaajgahbaaaaaaaaaaaegiccaaa
aaaaaaaaabaaaaaaehaaaaalbcaabaaaabaaaaaaegaabaaaabaaaaaaaghabaaa
adaaaaaaaagabaaaaaaaaaaackaabaaaabaaaaaaaaaaaaaihcaabaaaacaaaaaa
jgahbaaaaaaaaaaaegiccaaaaaaaaaaaacaaaaaaehaaaaalccaabaaaabaaaaaa
egaabaaaacaaaaaaaghabaaaadaaaaaaaagabaaaaaaaaaaackaabaaaacaaaaaa
aaaaaaaihcaabaaaacaaaaaajgahbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaa
aaaaaaaiocaabaaaaaaaaaaafgaobaaaaaaaaaaaagijcaaaaaaaaaaaaeaaaaaa
ehaaaaalicaabaaaabaaaaaajgafbaaaaaaaaaaaaghabaaaadaaaaaaaagabaaa
aaaaaaaadkaabaaaaaaaaaaaehaaaaalecaabaaaabaaaaaaegaabaaaacaaaaaa
aghabaaaadaaaaaaaagabaaaaaaaaaaackaabaaaacaaaaaadcaaaaakpcaabaaa
aaaaaaaaegaobaaaabaaaaaaagaabaaaaaaaaaaaagiacaaaacaaaaaabiaaaaaa
bbaaaaakbcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiado
aaaaiadoaaaaiadoaoaaaaahgcaabaaaaaaaaaaaagbbbaaaagaaaaaapgbpbaaa
agaaaaaaaaaaaaakgcaabaaaaaaaaaaafgagbaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaadpaaaaaadpaaaaaaaaefaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadbaaaaahccaabaaaaaaaaaaaabeaaaaa
aaaaaaaackbabaaaagaaaaaaabaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaaaaaaiadpdiaaaaahccaabaaaaaaaaaaadkaabaaaabaaaaaabkaabaaa
aaaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaakgakbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaabaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaajaaaaaadcaaaaam
hcaabaaaabaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaa
deaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaa
abaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaamaaaaaaogikcaaaaaaaaaaa
amaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaa
aagabaaaadaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"3.0-!!ARBfp1.0
PARAM c[8] = { program.local[0..4],
		{ 0, 0.97000003, 0.0078125, -0.0078125 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 },
		{ 0.25 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, fragment.texcoord[6], c[5].zwww;
TEX R0, R0, texture[0], CUBE;
DP4 R2.w, R0, c[6];
ADD R0.xyz, fragment.texcoord[6], c[5].wzww;
TEX R0, R0, texture[0], CUBE;
DP4 R2.z, R0, c[6];
ADD R1.xyz, fragment.texcoord[6], c[5].wwzw;
TEX R1, R1, texture[0], CUBE;
DP4 R2.y, R1, c[6];
ADD R0.xyz, fragment.texcoord[6], c[5].z;
TEX R0, R0, texture[0], CUBE;
DP4 R2.x, R0, c[6];
DP3 R1.x, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.x, R1.x;
RCP R0.y, R1.x;
MUL R0.y, R0, c[1].w;
MAD R1, -R0.y, c[5].y, R2;
MOV R0.x, c[6];
CMP R1, R1, c[2].x, R0.x;
DP3 R0.x, fragment.texcoord[5], fragment.texcoord[5];
DP4 R0.y, R1, c[7].x;
TEX R0.w, R0.x, texture[1], 2D;
MUL R0.w, R0, R0.y;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
MUL R2.xyz, R0.w, c[3];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
MAD R1.xy, fragment.texcoord[0], c[4], c[4].zwzw;
MAX R0.w, R0.x, c[5].x;
TEX R0.xyz, R1, texture[2], 2D;
MUL R1.xyz, R0.w, R2;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[5].x;
END
# 38 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_Diffuse] 2D 2
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_2d s2
def c5, 0.00000000, 0.00781250, -0.00781250, 0.97000003
def c6, 1.00000000, 0.00392157, 0.00001538, 0.00000006
def c7, 0.25000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
add r0.xyz, v4, c5.yzzw
texld r0, r0, s0
dp4 r2.w, r0, c6
add r0.xyz, v4, c5.zyzw
texld r0, r0, s0
dp4 r2.z, r0, c6
add r1.xyz, v4, c5.zzyw
texld r1, r1, s0
dp4 r2.y, r1, c6
add r0.xyz, v4, c5.y
texld r0, r0, s0
dp3 r1.x, v4, v4
dp4 r2.x, r0, c6
rsq r1.x, r1.x
rcp r0.x, r1.x
mul r0.x, r0, c1.w
mad r0, -r0.x, c5.w, r2
mov r1.x, c2
cmp r1, r0, c6.x, r1.x
dp3 r0.x, v3, v3
dp4_pp r0.y, r1, c7.x
texld r0.x, r0.x, s1
mul r0.w, r0.x, r0.y
mad r0.xyz, -v1, c0.w, c0
mul r2.xyz, r0.w, c3
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.z, r0, r1
max r0.w, r0.z, c5.x
mad r0.xy, v0, c4, c4.zwzw
texld r0.xyz, r0, s2
mul r1.xyz, r0.w, r2
mul oC0.xyz, r1, r0
mov_pp oC0.w, c5.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT" "SHADOWS_CUBE" "SHADOWS_SOFT" }
SetTexture 0 [_LightTexture0] 2D 1
SetTexture 1 [_ShadowMapTexture] CUBE 0
SetTexture 2 [_Diffuse] 2D 2
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedihjelmjedokncnmjbbceofjkfpifkbcgabaaaaaapmagaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefckmafaaaaeaaaaaaaglabaaaafjaaaaaeegiocaaa
aaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaahaaaaaa
egbcbaaaahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaai
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaabaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaomfbhidpaaaaaaakocaabaaa
aaaaaaaaagbjbaaaahaaaaaaaceaaaaaaaaaaaaaaaaaaadmaaaaaadmaaaaaadm
efaaaaajpcaabaaaabaaaaaajgahbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaabbaaaaakbcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaiadp
ibiaiadlicabibdhafidibddaaaaaaakocaabaaaaaaaaaaaagbjbaaaahaaaaaa
aceaaaaaaaaaaaaaaaaaaalmaaaaaalmaaaaaadmefaaaaajpcaabaaaacaaaaaa
jgahbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaabbaaaaakccaabaaa
abaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdhafidibdd
aaaaaaakocaabaaaaaaaaaaaagbjbaaaahaaaaaaaceaaaaaaaaaaaaaaaaaaalm
aaaaaadmaaaaaalmefaaaaajpcaabaaaacaaaaaajgahbaaaaaaaaaaaeghobaaa
abaaaaaaaagabaaaaaaaaaaabbaaaaakecaabaaaabaaaaaaegaobaaaacaaaaaa
aceaaaaaaaaaiadpibiaiadlicabibdhafidibddaaaaaaakocaabaaaaaaaaaaa
agbjbaaaahaaaaaaaceaaaaaaaaaaaaaaaaaaadmaaaaaalmaaaaaalmefaaaaaj
pcaabaaaacaaaaaajgahbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
bbaaaaakicaabaaaabaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadpibiaiadl
icabibdhafidibdddbaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaagaabaaa
aaaaaaaadhaaaaanpcaabaaaaaaaaaaaegaobaaaaaaaaaaaagiacaaaacaaaaaa
biaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpbbaaaaakbcaabaaa
aaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiadoaaaaiado
baaaaaahccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaaefaaaaaj
pcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaai
hcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaam
hcaabaaaabaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaa
adaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaa
deaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaa
abaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaa
aiaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaa
aagabaaaacaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffuse] 2D 3
"3.0-!!ARBfp1.0
PARAM c[8] = { program.local[0..4],
		{ 0, 0.97000003, 0.0078125, -0.0078125 },
		{ 1, 0.0039215689, 1.53787e-005, 6.0308629e-008 },
		{ 0.25 } };
TEMP R0;
TEMP R1;
TEMP R2;
ADD R0.xyz, fragment.texcoord[6], c[5].zwww;
TEX R0, R0, texture[0], CUBE;
DP4 R2.w, R0, c[6];
ADD R0.xyz, fragment.texcoord[6], c[5].wzww;
TEX R0, R0, texture[0], CUBE;
DP4 R2.z, R0, c[6];
ADD R1.xyz, fragment.texcoord[6], c[5].wwzw;
TEX R1, R1, texture[0], CUBE;
DP4 R2.y, R1, c[6];
ADD R0.xyz, fragment.texcoord[6], c[5].z;
TEX R0, R0, texture[0], CUBE;
DP4 R2.x, R0, c[6];
DP3 R1.x, fragment.texcoord[6], fragment.texcoord[6];
RSQ R1.x, R1.x;
RCP R0.y, R1.x;
MUL R0.y, R0, c[1].w;
MAD R1, -R0.y, c[5].y, R2;
MOV R0.x, c[6];
CMP R0, R1, c[2].x, R0.x;
DP4 R0.y, R0, c[7].x;
DP3 R0.x, fragment.texcoord[5], fragment.texcoord[5];
TEX R0.w, fragment.texcoord[5], texture[2], CUBE;
TEX R1.w, R0.x, texture[1], 2D;
MUL R0.x, R1.w, R0.w;
MUL R0.w, R0.x, R0.y;
MAD R0.xyz, -fragment.texcoord[1], c[0].w, c[0];
MUL R2.xyz, R0.w, c[3];
DP3 R1.x, R0, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, fragment.texcoord[2];
DP3 R0.x, R0, R1;
MAD R1.xy, fragment.texcoord[0], c[4], c[4].zwzw;
MAX R0.w, R0.x, c[5].x;
TEX R0.xyz, R1, texture[3], 2D;
MUL R1.xyz, R0.w, R2;
MUL result.color.xyz, R1, R0;
MOV result.color.w, c[5].x;
END
# 40 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightPositionRange]
Vector 2 [_LightShadowData]
Vector 3 [_LightColor0]
Vector 4 [_Diffuse_ST]
SetTexture 0 [_ShadowMapTexture] CUBE 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
SetTexture 3 [_Diffuse] 2D 3
"ps_3_0
dcl_cube s0
dcl_2d s1
dcl_cube s2
dcl_2d s3
def c5, 0.00000000, 0.00781250, -0.00781250, 0.97000003
def c6, 1.00000000, 0.00392157, 0.00001538, 0.00000006
def c7, 0.25000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord5 v3.xyz
dcl_texcoord6 v4.xyz
add r0.xyz, v4, c5.yzzw
texld r0, r0, s0
dp4 r2.w, r0, c6
add r0.xyz, v4, c5.zyzw
texld r0, r0, s0
dp4 r2.z, r0, c6
add r1.xyz, v4, c5.zzyw
texld r1, r1, s0
dp4 r2.y, r1, c6
add r0.xyz, v4, c5.y
texld r0, r0, s0
dp3 r1.x, v4, v4
dp4 r2.x, r0, c6
rsq r1.x, r1.x
rcp r0.x, r1.x
mul r0.x, r0, c1.w
mad r0, -r0.x, c5.w, r2
mov r1.x, c2
cmp r0, r0, c6.x, r1.x
dp4_pp r0.y, r0, c7.x
dp3 r0.x, v3, v3
texld r0.w, v3, s2
texld r0.x, r0.x, s1
mul r0.x, r0, r0.w
mul r0.w, r0.x, r0.y
mad r0.xyz, -v1, c0.w, c0
mul r2.xyz, r0.w, c3
dp3 r1.x, r0, r0
dp3 r0.w, v2, v2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, v2
dp3 r0.z, r0, r1
max r0.w, r0.z, c5.x
mad r0.xy, v0, c4, c4.zwzw
texld r0.xyz, r0, s3
mul r1.xyz, r0.w, r2
mul oC0.xyz, r1, r0
mov_pp oC0.w, c5.x
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" "SHADOWS_CUBE" "SHADOWS_SOFT" }
SetTexture 0 [_LightTextureB0] 2D 2
SetTexture 1 [_LightTexture0] CUBE 1
SetTexture 2 [_ShadowMapTexture] CUBE 0
SetTexture 3 [_Diffuse] 2D 3
ConstBuffer "$Globals" 192
Vector 80 [_LightColor0]
Vector 128 [_Diffuse_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 16 [_LightPositionRange]
ConstBuffer "UnityShadows" 416
Vector 384 [_LightShadowData]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityShadows" 2
"ps_4_0
eefiecedhbjbhjglmhclhobiamhdohgmlhneepngabaaaaaafiahaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaneaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaaneaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcaiagaaaaeaaaaaaaicabaaaafjaaaaaeegiocaaa
aaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaacaaaaaafjaaaaaeegiocaaa
acaaaaaabjaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaaffffaaaafidaaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaahaaaaaaegbcbaaa
ahaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaa
aaaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaabaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaomfbhidpaaaaaaakocaabaaaaaaaaaaa
agbjbaaaahaaaaaaaceaaaaaaaaaaaaaaaaaaadmaaaaaadmaaaaaadmefaaaaaj
pcaabaaaabaaaaaajgahbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaa
bbaaaaakbcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaiadpibiaiadl
icabibdhafidibddaaaaaaakocaabaaaaaaaaaaaagbjbaaaahaaaaaaaceaaaaa
aaaaaaaaaaaaaalmaaaaaalmaaaaaadmefaaaaajpcaabaaaacaaaaaajgahbaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaabbaaaaakccaabaaaabaaaaaa
egaobaaaacaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdhafidibddaaaaaaak
ocaabaaaaaaaaaaaagbjbaaaahaaaaaaaceaaaaaaaaaaaaaaaaaaalmaaaaaadm
aaaaaalmefaaaaajpcaabaaaacaaaaaajgahbaaaaaaaaaaaeghobaaaacaaaaaa
aagabaaaaaaaaaaabbaaaaakecaabaaaabaaaaaaegaobaaaacaaaaaaaceaaaaa
aaaaiadpibiaiadlicabibdhafidibddaaaaaaakocaabaaaaaaaaaaaagbjbaaa
ahaaaaaaaceaaaaaaaaaaaaaaaaaaadmaaaaaalmaaaaaalmefaaaaajpcaabaaa
acaaaaaajgahbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaabbaaaaak
icaabaaaabaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadpibiaiadlicabibdh
afidibdddbaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaagaabaaaaaaaaaaa
dhaaaaanpcaabaaaaaaaaaaaegaobaaaaaaaaaaaagiacaaaacaaaaaabiaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpbbaaaaakbcaabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiadoaaaaiadobaaaaaah
ccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaaefaaaaajpcaabaaa
abaaaaaafgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbcbaaaagaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaahccaabaaaaaaaaaaaakaabaaaabaaaaaadkaabaaaacaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadcaaaaamhcaabaaa
abaaaaaapgipcaaaabaaaaaaaaaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaa
abaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadeaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadcaaaaaldcaabaaaabaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaa
adaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
}
 }
}
Fallback "Diffuse"
}