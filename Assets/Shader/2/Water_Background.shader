шеShader "Shader Forge/Water_Background" {
Properties {
 _Wave_Tilling ("Wave_Tilling", Float) = 1
 _Normal ("Normal", 2D) = "bump" {}
 _Wave_Size ("Wave_Size", Float) = 2
 _Wave_Speed ("Wave_Speed", Float) = 0.1
 _Water_Color ("Water_Color", Color) = (0.155725,0.398524,0.65098,1)
 _Water_HighLight ("Water_HighLight", Float) = 5
 _Cubemap ("Cubemap", CUBE) = "_Skybox" {}
 _Reflect ("Reflect", Float) = 0.5
 _Wave_Speed_L ("Wave_Speed_L", Float) = 1
 _Wave_Speed_R ("Wave_Speed_R", Float) = 1
 _Diffuse ("Diffuse", 2D) = "white" {}
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
MUL result.texcoord[3].xyz, R0.w, R2;
MOV result.texcoord[2].xyz, R0;
MOV result.texcoord[1].xyz, R1;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 25 instructions, 3 R-regs
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
dcl_texcoord0 v3
mov r1.xyz, v2
mov r1.w, c12.x
dp4 r0.z, r1, c6
dp4 r0.y, r1, c5
dp4 r0.x, r1, c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r1.xyz, v1.y, c9
mad r1.xyz, v1.x, c8, r1
mad r1.xyz, v1.z, c10, r1
add r1.xyz, r1, c12.x
mul r2.xyz, r1.zxyw, r0.yzxw
mad r2.xyz, r1.yzxw, r0.zxyw, -r2
mul r2.xyz, v2.w, r2
dp3 r0.w, r2, r2
rsq r0.w, r0.w
mul o4.xyz, r0.w, r2
mov o3.xyz, r0
mov o2.xyz, r1
mov o1.xy, v3
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
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedjedomjhkomfchimiomdedkmnbbnnlimnabaaaaaajiaeaaaaadaaaaaa
cmaaaaaamaaaaaaagaabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcdaadaaaaeaaaabaammaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaa
adaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaa
baaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaa
bbaaaaaabaaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaa
bcaaaaaadgaaaaafhccabaaaacaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaadaaaaaa
egacbaaaabaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaa
abaaaaaadcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaa
egacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgbpbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
aaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaa
aeaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_Time]
Vector 1 [_TimeEditor]
Vector 2 [_Normal_ST]
Float 3 [_Wave_Tilling]
Float 4 [_Wave_Size]
Float 5 [_Wave_Speed]
Float 6 [_Wave_Speed_L]
Float 7 [_Wave_Speed_R]
SetTexture 0 [_Normal] 2D 0
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..7],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xy, c[1];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.y, R2.z, c[6].x;
COS R0.x, R0.y;
SIN R1.z, R0.y;
MUL R0.zw, fragment.texcoord[0].xyxy, c[3].x;
ADD R0.zw, R0, -c[8].x;
MOV R1.w, R0.x;
MUL R1.xy, R0.w, R1.zwzw;
MOV R0.y, -R1.z;
MAD R0.xy, R0.z, R0, R1;
ADD R0.xy, R0, c[8].x;
MAD R0.xy, R0, c[2], c[2].zwzw;
TEX R1.yw, R0, texture[0], 2D;
MAD R2.xy, R1.wyzw, c[8].y, -c[8].z;
MUL R1.y, R2.z, c[7].x;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
COS R1.x, R1.y;
ADD R0.x, -R0, c[8].z;
RSQ R0.x, R0.x;
RCP R2.z, R0.x;
SIN R0.x, R1.y;
MOV R0.y, R1.x;
MUL R1.zw, R0.w, R0.xyxy;
MOV R1.y, -R0.x;
MAD R0.xy, R0.z, R1, R1.zwzw;
ADD R0.zw, R0.xyxy, c[8].x;
MAD R0.zw, R0, c[2].xyxy, c[2];
MUL R1.x, R2.w, c[5];
MAD R0.xy, fragment.texcoord[0], c[4].x, R1.x;
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R0, c[2], c[2].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[8].y, -c[8].z;
MAD R1.xy, R1.wyzw, c[8].y, -c[8].z;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[8];
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R0.w, -R0, c[8].z;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
ADD R1.xyz, R2, R1;
MUL R2.xyz, R1, R0;
MUL R0.xyz, R2.y, fragment.texcoord[3];
DP3 R0.w, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.w, R0.w;
MAD R1.xyz, R2.x, fragment.texcoord[2], R0;
MUL R0.xyz, R0.w, fragment.texcoord[1];
MAD R0.xyz, R2.z, R0, R1;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
MAD result.color.xyz, R0, c[8].x, c[8].x;
MOV result.color.w, c[8].x;
END
# 59 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Time]
Vector 1 [_TimeEditor]
Vector 2 [_Normal_ST]
Float 3 [_Wave_Tilling]
Float 4 [_Wave_Size]
Float 5 [_Wave_Speed]
Float 6 [_Wave_Speed_L]
Float 7 [_Wave_Speed_R]
SetTexture 0 [_Normal] 2D 0
"ps_3_0
dcl_2d s0
def c8, -0.50000000, 0.15915491, 0.50000000, 1.00000000
def c9, 6.28318501, -3.14159298, 2.00000000, -1.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
mov r0.xy, c0
add r1.zw, c1.xyxy, r0.xyxy
mul r0.x, r1.z, c6
mad r0.x, r0, c8.y, c8.z
frc r0.x, r0
mad r1.x, r0, c9, c9.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c3.x
add r1.xy, r0.zwzw, c8.x
mul r2.xy, r1.y, r0.yxzw
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r2
add r0.xy, r0, c8.z
mad r0.xy, r0, c2, c2.zwzw
texld r0.yw, r0, s0
mul r0.x, r1.z, c7
mad r0.z, r0.x, c8.y, c8
mad_pp r2.xy, r0.wyzw, c9.z, c9.w
mul_pp r0.xy, r2, r2
frc r0.z, r0
add_pp_sat r0.x, r0, r0.y
mad r2.z, r0, c9.x, c9.y
add_pp r1.z, -r0.x, c8.w
sincos r0.xy, r2.z
rsq_pp r0.z, r1.z
rcp_pp r2.z, r0.z
mul r1.yz, r1.y, r0.xyxw
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.yzzw
add r0.zw, r0.xyxy, c8.z
mul r1.x, r1.w, c5
mad r0.xy, v0, c4.x, r1.x
mad r1.xy, r0.zwzw, c2, c2.zwzw
mad r0.xy, r0, c2, c2.zwzw
texld r1.yw, r1, s0
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c9.z, c9.w
mad_pp r1.xy, r1.wyzw, c9.z, c9.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c8.w
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add_pp r0.w, -r0, c8
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
add r1.xyz, r2, r1
mul r2.xyz, r1, r0
mul r0.xyz, r2.y, v3
dp3 r0.w, v1, v1
rsq r0.w, r0.w
mad r1.xyz, r2.x, v2, r0
mul r0.xyz, r0.w, v1
mad r0.xyz, r2.z, r0, r1
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mad oC0.xyz, r0, c8.z, c8.z
mov_pp oC0.w, c8.z
"
}
SubProgram "d3d11 " {
SetTexture 0 [_Normal] 2D 0
ConstBuffer "$Globals" 96
Vector 32 [_TimeEditor]
Vector 48 [_Normal_ST]
Float 64 [_Wave_Tilling]
Float 68 [_Wave_Size]
Float 72 [_Wave_Speed]
Float 76 [_Wave_Speed_L]
Float 80 [_Wave_Speed_R]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedhodegbliojaeiehpikcnjmhaofnikfimabaaaaaadiaiaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcdaahaaaaeaaaaaaammabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacafaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaa
aaaaaaaaacaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaiecaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadiaaaaaidcaabaaaaaaaaaaa
egaabaaaaaaaaaaalgipcaaaaaaaaaaaaeaaaaaaenaaaaahbcaabaaaabaaaaaa
bcaabaaaacaaaaaackaabaaaaaaaaaaadgaaaaafecaabaaaadaaaaaaakaabaaa
abaaaaaadgaaaaafccaabaaaadaaaaaaakaabaaaacaaaaaadgaaaaagbcaabaaa
adaaaaaaakaabaiaebaaaaaaabaaaaaadcaaaaanmcaabaaaaaaaaaaaagbebaaa
abaaaaaaagiacaaaaaaaaaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaalp
aaaaaalpapaaaaahbcaabaaaabaaaaaaogakbaaaaaaaaaaajgafbaaaadaaaaaa
apaaaaahccaabaaaabaaaaaaogakbaaaaaaaaaaaegaabaaaadaaaaaaaaaaaaak
dcaabaaaabaaaaaaegaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaa
aaaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaapdcaabaaaabaaaaaa
hgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaa
aaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaabaaaaaaegaabaaa
abaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaiadpaaaaaaaiicaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaa
abeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaaabaaaaaaenaaaaah
bcaabaaaaaaaaaaabcaabaaaacaaaaaaakaabaaaaaaaaaaadcaaaaakgcaabaaa
acaaaaaaagbbbaaaabaaaaaafgifcaaaaaaaaaaaaeaaaaaafgafbaaaaaaaaaaa
dcaaaaalgcaabaaaacaaaaaafgagbaaaacaaaaaaagibcaaaaaaaaaaaadaaaaaa
kgilcaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaapdcaabaaaadaaaaaahgapbaaa
adaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaa
dgaaaaafccaabaaaaeaaaaaaakaabaaaacaaaaaadgaaaaagbcaabaaaaeaaaaaa
akaabaiaebaaaaaaaaaaaaaaapaaaaahccaabaaaaaaaaaaaogakbaaaaaaaaaaa
egaabaaaaeaaaaaaapaaaaahbcaabaaaaaaaaaaaogakbaaaaaaaaaaajgafbaaa
aeaaaaaaaaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaaaaaaaaaaaadcaaaaaldcaabaaaaaaaaaaaegaabaaaaaaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaaaaaaaaahgapbaaaaaaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaaaaaaaaadkaabaaa
aaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
apaaaaahicaabaaaaaaaaaaaegaabaaaadaaaaaaegaabaaaadaaaaaaddaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaa
aaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaa
adaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaadaaaaaadiaaaaahhcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaa
aeaaaaaadcaaaaajlcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbibaaaadaaaaaa
egaibaaaabaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaacaaaaaaegbcbaaa
acaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaadiaaaaahhcaabaaa
abaaaaaaagaabaaaabaaaaaaegbcbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaaegadbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaaphccabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaadpdoaaaaab"
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
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
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
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 128
Vector 32 [_TimeEditor]
Vector 48 [_Normal_ST]
Float 64 [_Wave_Tilling]
Float 68 [_Wave_Size]
Float 72 [_Wave_Speed]
Vector 80 [_Water_Color]
Float 96 [_Water_HighLight]
Float 100 [_Reflect]
Float 104 [_Wave_Speed_L]
Float 108 [_Wave_Speed_R]
Vector 112 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedmeepofdnldgfcgolemmombnlcfkhmiejabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaagaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaaeaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
aeaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
aeaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaa
ahaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
agaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaafaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaagaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 128
Vector 32 [_TimeEditor]
Vector 48 [_Normal_ST]
Float 64 [_Wave_Tilling]
Float 68 [_Wave_Size]
Float 72 [_Wave_Speed]
Vector 80 [_Water_Color]
Float 96 [_Water_HighLight]
Float 100 [_Reflect]
Float 104 [_Wave_Speed_L]
Float 108 [_Wave_Speed_R]
Vector 112 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedmeepofdnldgfcgolemmombnlcfkhmiejabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaagaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaaeaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
aeaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
aeaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaa
ahaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
agaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaafaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaagaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 128
Vector 32 [_TimeEditor]
Vector 48 [_Normal_ST]
Float 64 [_Wave_Tilling]
Float 68 [_Wave_Size]
Float 72 [_Wave_Speed]
Vector 80 [_Water_Color]
Float 96 [_Water_HighLight]
Float 100 [_Reflect]
Float 104 [_Wave_Speed_L]
Float 108 [_Wave_Speed_R]
Vector 112 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedmeepofdnldgfcgolemmombnlcfkhmiejabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaagaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaaeaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
aeaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
aeaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaa
ahaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
agaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaafaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaagaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 128
Vector 32 [_TimeEditor]
Vector 48 [_Normal_ST]
Float 64 [_Wave_Tilling]
Float 68 [_Wave_Size]
Float 72 [_Wave_Speed]
Vector 80 [_Water_Color]
Float 96 [_Water_HighLight]
Float 100 [_Reflect]
Float 104 [_Wave_Speed_L]
Float 108 [_Wave_Speed_R]
Vector 112 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedmeepofdnldgfcgolemmombnlcfkhmiejabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaagaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaaeaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
aeaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
aeaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaa
ahaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
agaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaafaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaagaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 128
Vector 32 [_TimeEditor]
Vector 48 [_Normal_ST]
Float 64 [_Wave_Tilling]
Float 68 [_Wave_Size]
Float 72 [_Wave_Speed]
Vector 80 [_Water_Color]
Float 96 [_Water_HighLight]
Float 100 [_Reflect]
Float 104 [_Wave_Speed_L]
Float 108 [_Wave_Speed_R]
Vector 112 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedmeepofdnldgfcgolemmombnlcfkhmiejabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaagaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaaeaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
aeaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
aeaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaa
ahaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
agaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaafaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaagaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 128
Vector 32 [_TimeEditor]
Vector 48 [_Normal_ST]
Float 64 [_Wave_Tilling]
Float 68 [_Wave_Size]
Float 72 [_Wave_Speed]
Vector 80 [_Water_Color]
Float 96 [_Water_HighLight]
Float 100 [_Reflect]
Float 104 [_Wave_Speed_L]
Float 108 [_Wave_Speed_R]
Vector 112 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedmeepofdnldgfcgolemmombnlcfkhmiejabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaagaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaaeaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
adaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaaahaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
aeaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
aeaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaahaaaaaakgilcaaaaaaaaaaa
ahaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
agaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaafaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaagaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
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
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
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
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
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
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
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
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
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
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
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
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
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
eefiecedooilndalaneljhihncooenjckicbkmglabaaaaaafeafaaaaadaaaaaa
cmaaaaaamaaaaaaahiabaaaaejfdeheoimaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaahiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaadadaaaafaepfdej
feejepeoaaeoepfcenebemaafeebeoehefeofeaafeeffiedepepfceeaaklklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcneadaaaa
eaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaabaaaaaafpaaaaadpcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaa
egbabaaaadaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
acaaaaaaegiocaaaaaaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
baaaaaaibcaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabaaaaaaa
baaaaaaiccaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabbaaaaaa
baaaaaaiecaabaaaaaaaaaaaegbcbaaaabaaaaaaegiccaaaaaaaaaaabcaaaaaa
dgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgbfbaaaacaaaaaaegiccaaaaaaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaamaaaaaaagbabaaaacaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaakgbkbaaaacaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadiaaaaahhcaabaaaacaaaaaacgajbaaaaaaaaaaajgaebaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgaebaaaaaaaaaaacgajbaaaabaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
acaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaafaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 112
Vector 16 [_TimeEditor]
Vector 32 [_Normal_ST]
Float 48 [_Wave_Tilling]
Float 52 [_Wave_Size]
Float 56 [_Wave_Speed]
Vector 64 [_Water_Color]
Float 80 [_Water_HighLight]
Float 84 [_Reflect]
Float 88 [_Wave_Speed_L]
Float 92 [_Wave_Speed_R]
Vector 96 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedijaknmlojbekpfnfkealghhnijemgjmoabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaafaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaadaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaacaaaaaakgiocaaa
aaaaaaaaacaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaaagaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
adaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
adaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
afaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaaeaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaafaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 112
Vector 16 [_TimeEditor]
Vector 32 [_Normal_ST]
Float 48 [_Wave_Tilling]
Float 52 [_Wave_Size]
Float 56 [_Wave_Speed]
Vector 64 [_Water_Color]
Float 80 [_Water_HighLight]
Float 84 [_Reflect]
Float 88 [_Wave_Speed_L]
Float 92 [_Wave_Speed_R]
Vector 96 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedijaknmlojbekpfnfkealghhnijemgjmoabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaafaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaadaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaacaaaaaakgiocaaa
aaaaaaaaacaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaaagaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
adaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
adaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
afaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaaeaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaafaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 112
Vector 16 [_TimeEditor]
Vector 32 [_Normal_ST]
Float 48 [_Wave_Tilling]
Float 52 [_Wave_Size]
Float 56 [_Wave_Speed]
Vector 64 [_Water_Color]
Float 80 [_Water_HighLight]
Float 84 [_Reflect]
Float 88 [_Wave_Speed_L]
Float 92 [_Wave_Speed_R]
Vector 96 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedijaknmlojbekpfnfkealghhnijemgjmoabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaafaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaadaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaacaaaaaakgiocaaa
aaaaaaaaacaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaaagaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
adaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
adaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
afaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaaeaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaafaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 112
Vector 16 [_TimeEditor]
Vector 32 [_Normal_ST]
Float 48 [_Wave_Tilling]
Float 52 [_Wave_Size]
Float 56 [_Wave_Speed]
Vector 64 [_Water_Color]
Float 80 [_Water_HighLight]
Float 84 [_Reflect]
Float 88 [_Wave_Speed_L]
Float 92 [_Wave_Speed_R]
Vector 96 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedijaknmlojbekpfnfkealghhnijemgjmoabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaafaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaadaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaacaaaaaakgiocaaa
aaaaaaaaacaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaaagaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
adaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
adaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
afaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaaeaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaafaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 112
Vector 16 [_TimeEditor]
Vector 32 [_Normal_ST]
Float 48 [_Wave_Tilling]
Float 52 [_Wave_Size]
Float 56 [_Wave_Speed]
Vector 64 [_Water_Color]
Float 80 [_Water_HighLight]
Float 84 [_Reflect]
Float 88 [_Wave_Speed_L]
Float 92 [_Wave_Speed_R]
Vector 96 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedijaknmlojbekpfnfkealghhnijemgjmoabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaafaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaadaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaacaaaaaakgiocaaa
aaaaaaaaacaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaaagaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
adaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
adaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
afaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaaeaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaafaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"3.0-!!ARBfp1.0
PARAM c[14] = { program.local[0..12],
		{ 0.5, 1, 2, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MOV R0.xy, c[2];
ADD R2.zw, R0.xyxy, c[0].xyxy;
MUL R0.w, R2.z, c[10].x;
MUL R0.xy, fragment.texcoord[0], c[4].x;
ADD R1.xy, R0, -c[13].x;
COS R0.z, R0.w;
SIN R0.x, R0.w;
MOV R0.y, R0.z;
MUL R1.zw, R1.y, R0.xyxy;
MOV R0.w, -R0.x;
MAD R0.xy, R1.x, R0.zwzw, R1.zwzw;
ADD R3.xy, R0, c[13].x;
MAD R0.xy, R3, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R2.xy, R0.wyzw, c[13].z, -c[13].y;
MUL R0.xy, R2, R2;
ADD_SAT R0.x, R0, R0.y;
ADD R0.x, -R0, c[13].y;
MUL R0.y, R2.z, c[11].x;
RSQ R0.z, R0.x;
COS R0.x, R0.y;
RCP R2.z, R0.z;
SIN R0.z, R0.y;
MOV R0.w, R0.x;
MUL R1.zw, R1.y, R0;
MOV R0.y, -R0.z;
MAD R0.xy, R1.x, R0, R1.zwzw;
MUL R0.z, R2.w, c[6].x;
ADD R4.xy, R0, c[13].x;
MAD R3.zw, fragment.texcoord[0].xyxy, c[5].x, R0.z;
MAD R0.zw, R4.xyxy, c[3].xyxy, c[3];
TEX R1.yw, R0.zwzw, texture[0], 2D;
MAD R0.xy, R3.zwzw, c[3], c[3].zwzw;
TEX R0.yw, R0, texture[0], 2D;
MAD R0.xy, R0.wyzw, c[13].z, -c[13].y;
MAD R1.xy, R1.wyzw, c[13].z, -c[13].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[13].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R1.xyz, R2, R1;
ADD R0.w, -R0, c[13].y;
RSQ R0.w, R0.w;
RCP R0.z, R0.w;
MUL R0.xyw, R1.xyzz, R0.xyzz;
MUL R1.xyz, R0.y, fragment.texcoord[4];
MAD R1.xyz, R0.x, fragment.texcoord[3], R1;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.y;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MAD R0.xyz, R0.w, R0, R1;
ADD R2.xyz, -fragment.texcoord[1], c[1];
DP3 R1.x, R2, R2;
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, R2;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, -R1;
MUL R0.xyz, R0, R0.w;
MAX R1.w, -R0, c[13];
MAD R0.xyz, -R0, c[13].z, -R1;
ADD R0.w, -R1, c[13].y;
MUL R1.xyz, R0.w, c[7];
TEX R0.xyz, R0, texture[2], CUBE;
MAD R0.xyz, R0, c[7], -R1;
MAD R2.xy, R4, c[12], c[12].zwzw;
MAD R4.xyz, R0, c[9].x, R1;
MAD R0.zw, R3.xyxy, c[12].xyxy, c[12];
MOV R0.y, c[13];
ADD R0.y, -R0, c[8].x;
TEX R0.x, R2, texture[1], 2D;
MAD R1.zw, R3, c[12].xyxy, c[12];
TEX R1.x, R0.zwzw, texture[1], 2D;
TEX R2.x, R1.zwzw, texture[1], 2D;
ADD R0.x, R0, R1;
MUL R0.x, R0, R2;
MUL R0.x, R0, c[8];
FLR R0.x, R0;
RCP R0.y, R0.y;
MAD result.color.xyz, R0.x, R0.y, R4;
MOV result.color.w, c[13].y;
END
# 85 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Vector 1 [_WorldSpaceCameraPos]
Vector 2 [_TimeEditor]
Vector 3 [_Normal_ST]
Float 4 [_Wave_Tilling]
Float 5 [_Wave_Size]
Float 6 [_Wave_Speed]
Vector 7 [_Water_Color]
Float 8 [_Water_HighLight]
Float 9 [_Reflect]
Float 10 [_Wave_Speed_L]
Float 11 [_Wave_Speed_R]
Vector 12 [_Diffuse_ST]
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 1
SetTexture 2 [_Cubemap] CUBE 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c13, -0.50000000, 0.15915491, 0.50000000, -1.00000000
def c14, 6.28318501, -3.14159298, 2.00000000, -1.00000000
def c15, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
mov r0.xy, c0
add r2.zw, c2.xyxy, r0.xyxy
mul r0.x, r2.z, c10
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.x, r0, c14, c14.y
sincos r0.xy, r1.x
mul r0.zw, v0.xyxy, c4.x
add r1.xy, r0.zwzw, c13.x
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r3.xy, r0, c13.z
mad r0.xy, r3, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r2.xy, r0.wyzw, c14.z, c14.w
mul_pp r0.zw, r2.xyxy, r2.xyxy
mul r0.x, r2.z, c11
add_pp_sat r0.y, r0.z, r0.w
mad r0.x, r0, c13.y, c13.z
frc r0.x, r0
mad r1.z, r0.x, c14.x, c14.y
add_pp r1.w, -r0.y, c15.x
sincos r0.xy, r1.z
rsq_pp r0.z, r1.w
rcp_pp r2.z, r0.z
mul r1.zw, r1.y, r0.xyyx
mov r0.z, r0.x
mov r0.w, -r0.y
mad r0.xy, r1.x, r0.zwzw, r1.zwzw
add r4.xy, r0, c13.z
mad r1.xy, r4, c3, c3.zwzw
texld r1.yw, r1, s0
mul r0.z, r2.w, c6.x
mad r3.zw, v0.xyxy, c5.x, r0.z
mad r0.xy, r3.zwzw, c3, c3.zwzw
texld r0.yw, r0, s0
mad_pp r0.xy, r0.wyzw, c14.z, c14.w
mad_pp r1.xy, r1.wyzw, c14.z, c14.w
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
mul_pp r1.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.w, r1.z, r1
add_pp r0.z, -r0, c15.x
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r1.xyz, r2, r1
add_pp r0.w, -r0, c15.x
rsq_pp r0.w, r0.w
rcp_pp r0.z, r0.w
mul r0.xyw, r1.xyzz, r0.xyzz
mul r1.xyz, r0.y, v4
mad r1.xyz, r0.x, v3, r1
dp3 r0.y, v2, v2
rsq r0.x, r0.y
mul r0.xyz, r0.x, v2
mad r0.xyz, r0.w, r0, r1
add r2.xyz, -v1, c1
dp3 r1.x, r2, r2
dp3 r0.w, r0, r0
rsq r0.w, r0.w
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, -r1
mul r0.xyz, r0, r0.w
mad r0.xyz, -r0, c14.z, -r1
max r0.w, -r0, c15.y
texld r1.xyz, r0, s2
mad r2.xy, r4, c12, c12.zwzw
texld r0.x, r2, s1
add r0.w, -r0, c15.x
mul r0.yzw, r0.w, c7.xxyz
mad r4.xyz, r1, c7, -r0.yzww
mad r1.xy, r3, c12, c12.zwzw
texld r1.x, r1, s1
mad r2.xy, r3.zwzw, c12, c12.zwzw
add r0.x, r0, r1
texld r2.x, r2, s1
mul r1.x, r0, r2
mul r1.x, r1, c8
mad r0.xyz, r4, c9.x, r0.yzww
mov r0.w, c8.x
frc r1.y, r1.x
add r1.z, c13.w, r0.w
add r0.w, r1.x, -r1.y
rcp r1.x, r1.z
mad oC0.xyz, r0.w, r1.x, r0
mov_pp oC0.w, c15.x
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_Normal] 2D 0
SetTexture 1 [_Diffuse] 2D 2
SetTexture 2 [_Cubemap] CUBE 1
ConstBuffer "$Globals" 112
Vector 16 [_TimeEditor]
Vector 32 [_Normal_ST]
Float 48 [_Wave_Tilling]
Float 52 [_Wave_Size]
Float 56 [_Wave_Speed]
Vector 64 [_Water_Color]
Float 80 [_Water_HighLight]
Float 84 [_Reflect]
Float 88 [_Wave_Speed_L]
Float 92 [_Wave_Speed_R]
Vector 96 [_Diffuse_ST]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedijaknmlojbekpfnfkealghhnijemgjmoabaaaaaanealaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleakaaaa
eaaaaaaaknacaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaaaaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaaegiacaaaabaaaaaaaaaaaaaadiaaaaaifcaabaaaaaaaaaaaagaabaaa
aaaaaaaakgilcaaaaaaaaaaaafaaaaaaenaaaaahbcaabaaaaaaaaaaabcaabaaa
abaaaaaaakaabaaaaaaaaaaaenaaaaahbcaabaaaacaaaaaabcaabaaaadaaaaaa
ckaabaaaaaaaaaaadgaaaaafecaabaaaaeaaaaaaakaabaaaaaaaaaaadgaaaaaf
ccaabaaaaeaaaaaaakaabaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakaabaia
ebaaaaaaaaaaaaaadcaaaaanfcaabaaaaaaaaaaaagbbbaaaabaaaaaaagiacaaa
aaaaaaaaadaaaaaaaceaaaaaaaaaaalpaaaaaaaaaaaaaalpaaaaaaaaapaaaaah
bcaabaaaabaaaaaaigaabaaaaaaaaaaajgafbaaaaeaaaaaaapaaaaahccaabaaa
abaaaaaaigaabaaaaaaaaaaaegaabaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaa
egaabaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaadcaaaaal
mcaabaaaabaaaaaaagaebaaaabaaaaaaagiecaaaaaaaaaaaacaaaaaakgiocaaa
aaaaaaaaacaaaaaadcaaaaaldcaabaaaabaaaaaaegaabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaadgaaaaafecaabaaaafaaaaaaakaabaaaacaaaaaadgaaaaafccaabaaa
afaaaaaaakaabaaaadaaaaaadgaaaaagbcaabaaaafaaaaaaakaabaiaebaaaaaa
acaaaaaaapaaaaahccaabaaaacaaaaaaigaabaaaaaaaaaaaegaabaaaafaaaaaa
apaaaaahbcaabaaaacaaaaaaigaabaaaaaaaaaaajgafbaaaafaaaaaaaaaaaaak
fcaabaaaaaaaaaaaagabbaaaacaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadcaaaaaldcaabaaaacaaaaaaigaabaaaaaaaaaaaegiacaaaaaaaaaaa
acaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalfcaabaaaaaaaaaaaagacbaaa
aaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaaagaaaaaaefaaaaaj
pcaabaaaadaaaaaaigaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaeaaaaaaakaabaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
ecaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaa
ckaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
ckaabaaaaaaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaimcaabaaaaaaaaaaaagbebaaaabaaaaaafgifcaaaaaaaaaaa
adaaaaaadcaaaaakgcaabaaaaaaaaaaafgafbaaaaaaaaaaakgikcaaaaaaaaaaa
adaaaaaakgalbaaaaaaaaaaadcaaaaaldcaabaaaacaaaaaajgafbaaaaaaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalgcaabaaa
aaaaaaaafgagbaaaaaaaaaaaagibcaaaaaaaaaaaagaaaaaakgilcaaaaaaaaaaa
agaaaaaaefaaaaajpcaabaaaadaaaaaajgafbaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
adaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
afaaaaaaebaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaap
dcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaa
aaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagajbaaaacaaaaaa
diaaaaahhcaabaaaabaaaaaakgakbaaaaaaaaaaaegbcbaaaafaaaaaadcaaaaaj
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaafgafbaaa
aaaaaaaaegbcbaaaadaaaaaadcaaaaajocaabaaaaaaaaaaapgapbaaaaaaaaaaa
agajbaaaacaaaaaaagajbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaajgahbaaa
aaaaaaaajgahbaaaaaaaaaaaeeaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaa
diaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegbcbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaa
baaaaaahicaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaf
icaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaiicaabaaaabaaaaaaegacbaiaebaaaaaa
abaaaaaajgahbaaaaaaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
dkaabaaaabaaaaaadcaaaaalhcaabaaaacaaaaaajgahbaaaaaaaaaaapgapbaia
ebaaaaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
jgahbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaiocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agijcaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegacbaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaaeaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaak
ocaabaaaaaaaaaaafgifcaaaaaaaaaaaafaaaaaaagajbaaaabaaaaaafgaobaaa
aaaaaaaaaaaaaaaibcaabaaaabaaaaaaakiacaaaaaaaaaaaafaaaaaaabeaaaaa
aaaaialpaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaa
aaaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
}
 }
}
Fallback "Diffuse"
}