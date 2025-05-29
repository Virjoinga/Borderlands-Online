òŠShader "BOL/FX/SkagSpitter" {
Properties {
 _SpecialFxTex ("Special Fx", 2D) = "white" {}
 _Cube ("Reflection Cubemap", CUBE) = "" { TexGen CubeReflect }
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _BaseColor ("Base Color", Color) = (1,1,1,1)
}
SubShader { 
 LOD 200
 Tags { "LIGHTMODE"="ForwardBase" "RenderType"="Transparent" }
 Pass {
  Tags { "LIGHTMODE"="ForwardBase" "RenderType"="Transparent" }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_Time]
Vector 14 [_WorldSpaceCameraPos]
Vector 15 [unity_Scale]
Vector 16 [_SpecialFxTex_ST]
Vector 17 [_BumpMap_ST]
Vector 18 [_AlphaCullOffTex_ST]
"3.0-!!ARBvp1.0
PARAM c[22] = { { 0.079577453, 0, 1, -1 },
		state.matrix.mvp,
		program.local[5..18],
		{ 0.25, 0.5, 0.75, 1 },
		{ -24.980801, 60.145809, -85.453789, 64.939346 },
		{ -19.73921, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.x, c[0];
MUL R0.x, R0, c[13].y;
FRC R1.z, R0.x;
SLT R0, R1.z, c[19];
ADD R2.xyz, R0.yzww, -R0;
MOV R0.yzw, R2.xxyz;
DP4 R1.y, R0, c[19].xxzz;
DP3 R1.x, R2, c[19].yyww;
ADD R1.xy, R1.z, -R1;
MUL R2.xy, R1, R1;
MUL R2.zw, R2.xyxy, R2.xyxy;
MAD R1, R2.zzww, c[20].xyxy, c[20].zwzw;
MAD R1, R1, R2.zzww, c[21].xyxy;
MAD R1.zw, R1.xyxz, R2.xyxy, R1.xyyw;
DP4 R1.y, R0, c[0].zzww;
DP4 R1.x, R0, c[0].zwwz;
MUL R1.zw, R1.xyxy, R1;
MAD R0.zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
ADD R2.xy, R0.zwzw, -c[19].y;
MOV R0.w, c[0].z;
DP3 R3.xy, vertex.normal, c[5];
MOV R0.x, R1.z;
MOV R0.y, -R1.w;
MUL R1.zw, R1.xywz, R2.xyxy;
MUL R0.xy, R2, R0;
ADD R1.x, R0, R0.y;
MOV R0.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R0.yzxw;
ADD R1.y, R1.z, R1.w;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R2;
ADD result.texcoord[4].xy, R1, c[19].y;
MUL R1.xyz, vertex.attrib[14].w, R0;
MOV R0.xyz, c[14];
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[15].w, -vertex.position;
DP3 R3.zw, -R2, c[5];
DP3 R4.xy, -R2, c[6];
DP3 R2.xy, -R2, c[7];
DP3 R0.y, R1, c[5];
MOV R0.w, R3;
MOV R0.z, R3.y;
DP3 R0.x, vertex.attrib[14], c[5];
MUL result.texcoord[1], R0, c[15].w;
DP3 R3.yw, vertex.normal, c[6];
DP3 R0.y, R1, c[6];
MOV R0.w, R4.y;
MOV R0.z, R3.w;
DP3 R0.x, vertex.attrib[14], c[6];
MUL result.texcoord[2], R0, c[15].w;
DP3 R0.y, R1, c[7];
DP3 R1.z, vertex.normal, c[7];
MOV R0.w, R2.y;
DP3 R0.x, vertex.attrib[14], c[7];
MOV R0.z, R1;
MOV R1.x, R3;
MOV R1.y, R3;
MUL result.texcoord[3], R0, c[15].w;
MOV result.texcoord[6].z, -R2.x;
MOV result.texcoord[6].y, -R4.x;
MOV result.texcoord[6].x, -R3.z;
MOV result.texcoord[5].xyz, R1;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
MOV result.texcoord[4].zw, c[0].y;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 70 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_Time]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_Scale]
Vector 15 [_SpecialFxTex_ST]
Vector 16 [_BumpMap_ST]
Vector 17 [_AlphaCullOffTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord4 o2
dcl_texcoord1 o3
dcl_texcoord2 o4
dcl_texcoord3 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c18, 0.07957745, 0.50000000, 6.28318501, -3.14159298
def c19, -0.50000000, 0.00000000, 1.00000000, 0
dcl_position0 v0
dcl_texcoord0 v1
dcl_tangent0 v2
dcl_normal0 v3
mov r0.xyz, v2
mul r1.xyz, v3.zxyw, r0.yzxw
mov r0.xyz, v2
mad r0.xyz, v3.yzxw, r0.zxyw, -r1
mul r1.xyz, v2.w, r0
mov r0.xyz, c13
mov r0.w, c19.z
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c14.w, -v0
dp3 r3.zw, -r2, c4
dp3 r3.xy, v3, c4
dp3 r4.xy, -r2, c5
dp3 r0.y, r1, c4
mov r0.w, r3
mov r0.z, r3.y
dp3 r0.x, v2, c4
mul o3, r0, c14.w
dp3 r3.yw, v3, c5
dp3 r0.y, r1, c5
mov r0.w, r4.y
mov r0.z, r3.w
dp3 r0.x, v2, c5
mul o4, r0, c14.w
dp3 r0.y, r1, c6
dp3 r1.xy, -r2, c6
dp3 r1.z, v3, c6
mov r0.x, c12.y
mov r0.w, r1.y
mad r0.x, r0, c18, c18.y
frc r1.y, r0.x
dp3 r0.x, v2, c6
mov r0.z, r1
mad r1.y, r1, c18.z, c18.w
mul o5, r0, c14.w
sincos r0.xy, r1.y
mov o7.z, -r1.x
mad r0.zw, v1.xyxy, c16.xyxy, c16
mov r1.x, r0
mov r1.y, -r0
add r0.zw, r0, c19.x
mul r1.xy, r0.zwzw, r1
mul r0.zw, r0.xyyx, r0
add r0.x, r1, r1.y
add r0.y, r0.z, r0.w
mov r1.x, r3
mov r1.y, r3
mov o7.y, -r4.x
mov o7.x, -r3.z
add o2.xy, r0, c18.y
mov o6.xyz, r1
mad o1.zw, v1.xyxy, c17.xyxy, c17
mad o1.xy, v1, c15, c15.zwzw
mov o2.zw, c19.y
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 128
Vector 80 [_SpecialFxTex_ST]
Vector 96 [_BumpMap_ST]
Vector 112 [_AlphaCullOffTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedcckdolpbgapfgffphaakjhaegpjnaalbabaaaaaakiajaaaaadaaaaaa
cmaaaaaamaaaaaaakiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaicaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdej
feejepeoaafeeffiedepepfceeaafeebeoehefeofeaaeoepfcenebemaaklklkl
epfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
neaaaaaaaeaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaneaaaaaaabaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
neaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaahaiaaaaneaaaaaaagaaaaaa
aaaaaaaaadaaaaaaahaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaafeeffied
epepfceeaaklklklfdeieefcpiahaaaaeaaaabaapoabaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
fpaaaaadpcbabaaaacaaaaaafpaaaaadhcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaa
afaaaaaagfaaaaadhccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaac
afaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaa
aaaaaaaaafaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaahaaaaaakgiocaaaaaaaaaaaahaaaaaadcaaaaaldcaabaaaaaaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaa
aaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaalpaaaaaalp
aaaaaaaaaaaaaaaadiaaaaaiecaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaa
abeaaaaaaaaaaadpenaaaaahbcaabaaaabaaaaaabcaabaaaacaaaaaackaabaaa
aaaaaaaadgaaaaagbcaabaaaadaaaaaaakaabaiaebaaaaaaabaaaaaadgaaaaaf
ccaabaaaadaaaaaaakaabaaaacaaaaaadgaaaaafecaabaaaadaaaaaaakaabaaa
abaaaaaaapaaaaahccaabaaaabaaaaaaggakbaaaadaaaaaaegaabaaaaaaaaaaa
apaaaaahbcaabaaaabaaaaaabgafbaaaadaaaaaaegaabaaaaaaaaaaaaaaaaaak
dccabaaaacaaaaaaegaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaa
aaaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaa
acaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaa
egiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
aaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaacaaaaaabdaaaaaa
dcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
egbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaaabaaaaaafgafbaiaebaaaaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaa
acaaaaaaamaaaaaaagaabaiaebaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaal
lcaabaaaabaaaaaaegiicaaaacaaaaaaaoaaaaaakgakbaiaebaaaaaaaaaaaaaa
egaibaaaabaaaaaadgaaaaaficaabaaaacaaaaaaakaabaaaabaaaaaadiaaaaah
hcaabaaaadaaaaaajgbebaaaacaaaaaacgbjbaaaadaaaaaadcaaaaakhcaabaaa
adaaaaaajgbebaaaadaaaaaacgbjbaaaacaaaaaaegacbaiaebaaaaaaadaaaaaa
diaaaaahhcaabaaaadaaaaaaegacbaaaadaaaaaapgbpbaaaacaaaaaadgaaaaag
bcaabaaaaeaaaaaaakiacaaaacaaaaaaamaaaaaadgaaaaagccaabaaaaeaaaaaa
akiacaaaacaaaaaaanaaaaaadgaaaaagecaabaaaaeaaaaaaakiacaaaacaaaaaa
aoaaaaaabaaaaaahccaabaaaacaaaaaaegacbaaaadaaaaaaegacbaaaaeaaaaaa
baaaaaahbcaabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaaaeaaaaaabaaaaaah
ecaabaaaacaaaaaaegbcbaaaadaaaaaaegacbaaaaeaaaaaadiaaaaaipccabaaa
adaaaaaaegaobaaaacaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaaficaabaaa
acaaaaaabkaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaabkiacaaaacaaaaaa
amaaaaaadgaaaaagccaabaaaaeaaaaaabkiacaaaacaaaaaaanaaaaaadgaaaaag
ecaabaaaaeaaaaaabkiacaaaacaaaaaaaoaaaaaabaaaaaahccaabaaaacaaaaaa
egacbaaaadaaaaaaegacbaaaaeaaaaaabaaaaaahbcaabaaaacaaaaaaegbcbaaa
acaaaaaaegacbaaaaeaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaaadaaaaaa
egacbaaaaeaaaaaadiaaaaaipccabaaaaeaaaaaaegaobaaaacaaaaaapgipcaaa
acaaaaaabeaaaaaadgaaaaagbcaabaaaacaaaaaackiacaaaacaaaaaaamaaaaaa
dgaaaaagccaabaaaacaaaaaackiacaaaacaaaaaaanaaaaaadgaaaaagecaabaaa
acaaaaaackiacaaaacaaaaaaaoaaaaaabaaaaaahccaabaaaabaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaacaaaaaa
egacbaaaacaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaaadaaaaaaegacbaaa
acaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaabaaaaaapgipcaaaacaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaadaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaa
adaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaaacaaaaaa
aoaaaaaakgbkbaaaadaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaa
egiicaaaacaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaak
hccabaaaahaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaa
aaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_Time]
Vector 1 [_BaseColor]
SetTexture 0 [_SpecialFxTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_Cube] CUBE 2
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..1],
		{ 2, 1, 0.5, 0 },
		{ 0.30000001, 0.58999997, 0.11, 3 } };
TEMP R0;
TEMP R1;
TEMP R2;
DP3 R0.y, fragment.texcoord[5], fragment.texcoord[5];
RSQ R0.y, R0.y;
DP3 R0.x, fragment.texcoord[6], fragment.texcoord[6];
MUL R1.xyz, R0.y, fragment.texcoord[5];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[6];
DP3 R0.x, R0, R1;
MAX R0.x, R0, c[2].w;
ADD R0.y, -R0.x, c[2];
TEX R1.yw, fragment.texcoord[4], texture[1], 2D;
MAD R2.xy, R1.wyzw, c[2].x, -c[2].y;
MAD R1.x, R0.y, R0.y, -c[2].z;
MOV R0.x, c[2].z;
MUL R0.y, R0.x, c[0];
COS R0.x, R0.y;
SIN R2.z, R0.y;
MOV R2.w, R0.x;
MUL R0.zw, R2, R1.x;
ADD R1.y, R0.z, R0.w;
MUL R0.zw, R2.xyxy, R2.xyxy;
ADD_SAT R0.z, R0, R0.w;
MOV R0.y, -R2.z;
MUL R0.xy, R1.x, R0;
ADD R1.x, R0, R0.y;
ADD R0.z, -R0, c[2].y;
RSQ R0.z, R0.z;
RCP R2.z, R0.z;
ADD R0.xy, R1, c[2].z;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R1.x, fragment.texcoord[1], R2;
DP3 R1.y, R2, fragment.texcoord[2];
DP3 R1.z, R2, fragment.texcoord[3];
MUL R1.xyz, R1, R0;
MOV R0.x, fragment.texcoord[1].w;
MOV R0.z, fragment.texcoord[3].w;
MOV R0.y, fragment.texcoord[2].w;
DP3 R0.w, R1, R0;
MUL R1.xyz, R1, R0.w;
MAD R0.xyz, -R1, c[2].x, R0;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
TEX R0.xyz, R0, texture[2], CUBE;
DP3 R0.x, R0, c[3];
TEX R0.w, fragment.texcoord[0], texture[0], 2D;
MUL R0.x, R0, R0.w;
MUL R0.xyz, R0.x, c[1];
MUL R0.xyz, R0, c[1].w;
MUL_SAT result.color.xyz, R0, c[3].w;
MOV result.color.w, c[2];
END
# 50 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Time]
Vector 1 [_BaseColor]
SetTexture 0 [_SpecialFxTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_Cube] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c2, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c3, 0.07957745, 0.50000000, 6.28318501, -3.14159298
def c4, -0.50000000, 0.30000001, 0.58999997, 0.11000000
def c5, 3.00000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord4 v1.xy
dcl_texcoord1 v2
dcl_texcoord2 v3
dcl_texcoord3 v4
dcl_texcoord5 v5.xyz
dcl_texcoord6 v6.xyz
dp3 r0.w, v5, v5
rsq r1.x, r0.w
dp3 r0.x, v6, v6
rsq r0.x, r0.x
mov r0.w, c0.y
texld r2.yw, v1, s1
mul r1.xyz, r1.x, v5
mul r0.xyz, r0.x, v6
dp3 r0.y, r0, r1
mad r0.w, r0, c3.x, c3.y
frc r0.x, r0.w
max r0.y, r0, c2.w
mad_pp r2.xy, r2.wyzw, c2.x, c2.y
mad r1.x, r0, c3.z, c3.w
add r1.y, -r0, c2.z
sincos r0.xy, r1.x
mad r1.x, r1.y, r1.y, c4
mul r0.zw, r0.xyyx, r1.x
add r1.y, r0.z, r0.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
add_pp_sat r0.z, r0, r0.w
mov r0.y, -r0
mul r0.xy, r1.x, r0
add r1.x, r0, r0.y
add_pp r0.z, -r0, c2
rsq_pp r0.z, r0.z
rcp_pp r2.z, r0.z
add r0.xy, r1, c3.y
texld r0.xyz, r0, s0
dp3 r1.x, v2, r2
dp3 r1.y, r2, v3
dp3 r1.z, r2, v4
mul r1.xyz, r1, r0
mov r0.x, v2.w
mov r0.z, v4.w
mov r0.y, v3.w
dp3 r0.w, r1, r0
mul r1.xyz, r1, r0.w
mad r0.xyz, -r1, c2.x, r0
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
texld r0.xyz, r0, s2
dp3 r0.x, r0, c4.yzww
texld r0.w, v0, s0
mul r0.x, r0, r0.w
mul r0.xyz, r0.x, c1
mul r0.xyz, r0, c1.w
mul_sat oC0.xyz, r0, c5.x
mov_pp oC0.w, c2
"
}
SubProgram "d3d11 " {
SetTexture 0 [_SpecialFxTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_Cube] CUBE 2
ConstBuffer "$Globals" 128
Vector 48 [_BaseColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedhhmikedfnnaegiednmkagnjnjkkicpcfabaaaaaahiahaaaaadaaaaaa
cmaaaaaabeabaaaaeiabaaaaejfdeheooaaaaaaaaiaaaaaaaiaaaaaamiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapadaaaaneaaaaaaaeaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apadaaaaneaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaaneaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaaneaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaaneaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaaahahaaaafdfgfpfa
gphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcciagaaaaeaaaaaaaikabaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafidaaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaaddcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadpcbabaaaaeaaaaaagcbaaaad
pcbabaaaafaaaaaagcbaaaadhcbabaaaagaaaaaagcbaaaadhcbabaaaahaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaahaaaaaaegbcbaaaahaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaahaaaaaa
baaaaaahicaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegbcbaaaagaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaa
aaaaiadpdcaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaaalpdiaaaaaiccaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaa
abeaaaaaaaaaaadpenaaaaahbcaabaaaabaaaaaabcaabaaaacaaaaaabkaabaaa
aaaaaaaadgaaaaagbcaabaaaadaaaaaaakaabaiaebaaaaaaabaaaaaadgaaaaaf
ccaabaaaadaaaaaaakaabaaaacaaaaaadgaaaaafecaabaaaadaaaaaaakaabaaa
abaaaaaaapaaaaahccaabaaaabaaaaaaggakbaaaadaaaaaaagaabaaaaaaaaaaa
apaaaaahbcaabaaaabaaaaaabgafbaaaadaaaaaaagaabaaaaaaaaaaaaaaaaaak
dcaabaaaaaaaaaaaegaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaaabaaaaaa
aceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialp
aaaaaaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaaegaabaaa
abaaaaaaddaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadp
aaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadp
elaaaaafecaabaaaabaaaaaadkaabaaaaaaaaaaabaaaaaahbcaabaaaacaaaaaa
egbcbaaaadaaaaaaegacbaaaabaaaaaabaaaaaahccaabaaaacaaaaaaegbcbaaa
aeaaaaaaegacbaaaabaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaaafaaaaaa
egacbaaaabaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
acaaaaaadgaaaaafbcaabaaaabaaaaaadkbabaaaadaaaaaadgaaaaafccaabaaa
abaaaaaadkbabaaaaeaaaaaadgaaaaafecaabaaaabaaaaaadkbabaaaafaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaaaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegacbaaaaaaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegacbaaaaaaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaabaaaaaakbcaabaaaaaaaaaaaegacbaaa
aaaaaaaaaceaaaaajkjjjjdodnakbhdpkoehobdnaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaaaaaaaaapgipcaaaaaaaaaaaadaaaaaadicaaaakhccabaaa
aaaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaeaeaaaaaeaeaaaaaeaeaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
}
 }
}
}