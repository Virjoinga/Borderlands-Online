χύShader "BOL/Scene/Ice/Ice" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _EmissiveColor ("Emissive Color", Color) = (0.5,0.5,0.5,0.5)
 _SpecColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Shininess ("Shininess", Range(0.01,1)) = 0.078125
 _Parallax ("Parallax", Float) = 0
 _DownBlend ("DownBlendPara", Range(0,1)) = 0.5
 _RefTex ("Reflection (RGB)", 2D) = "black" {}
 _RefPara ("Reflection Para", Float) = 0.5
 _MainTex ("Up Base (RGB)", 2D) = "black" {}
 _MainTex1 ("Down Base (RGB)", 2D) = "black" {}
 _LakerTex ("Laker (RGB)", 2D) = "white" {}
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _SnowTex ("Snow Tex", 2D) = "black" {}
 _SnowMaskTex ("Snow Mask Tex", 2D) = "black" {}
 _SnowColor ("Snow Color", Color) = (1,1,1,1)
 _SnowDirection ("Snow Direction", Vector) = (0,1,0,1)
 _SnowRange ("Snow Para", Float) = 4
}
SubShader { 
 LOD 10
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Vector 9 [unity_Scale]
Vector 10 [_BumpMap_ST]
Vector 11 [_MainTex_ST]
"3.0-!!ARBvp1.0
PARAM c[12] = { program.local[0],
		state.matrix.mvp,
		program.local[5..11] };
TEMP R0;
TEMP R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, R0, vertex.attrib[14].w;
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1].xyz, R0, c[9].w;
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2].xyz, R0, c[9].w;
DP3 R0.y, R1, c[7];
MUL R1.xyz, vertex.normal, c[9].w;
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MUL result.texcoord[3].xyz, R0, c[9].w;
DP3 result.texcoord[4].z, R1, c[7];
DP3 result.texcoord[4].y, R1, c[6];
DP3 result.texcoord[4].x, R1, c[5];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 26 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [unity_Scale]
Vector 9 [_BumpMap_ST]
Vector 10 [_MainTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, r0, v1.w
dp3 r0.y, r1, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o2.xyz, r0, c8.w
dp3 r0.y, r1, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o3.xyz, r0, c8.w
dp3 r0.y, r1, c6
mul r1.xyz, v2, c8.w
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4.xyz, r0, c8.w
dp3 o5.z, r1, c6
dp3 o5.y, r1, c5
dp3 o5.x, r1, c4
mad o1.zw, v3.xyxy, c10.xyxy, c10
mad o1.xy, v3, c9, c9.zwzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 128
Vector 96 [_BumpMap_ST]
Vector 112 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddndppgkifbpgbaonlpkjdpimapflpkfgabaaaaaahiagaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcmeaeaaaaeaaaabaadbabaaaafjaaaaae
egiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacadaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
abaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaa
agaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
ahaaaaaakgiocaaaaaaaaaaaahaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaa
abaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaa
cgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgbpbaaaabaaaaaadgaaaaagbcaabaaaabaaaaaaakiacaaa
abaaaaaaamaaaaaadgaaaaagccaabaaaabaaaaaaakiacaaaabaaaaaaanaaaaaa
dgaaaaagecaabaaaabaaaaaaakiacaaaabaaaaaaaoaaaaaabaaaaaahccaabaaa
acaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaaacaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaaihccabaaaacaaaaaaegacbaaaacaaaaaa
pgipcaaaabaaaaaabeaaaaaadgaaaaagbcaabaaaabaaaaaabkiacaaaabaaaaaa
amaaaaaadgaaaaagccaabaaaabaaaaaabkiacaaaabaaaaaaanaaaaaadgaaaaag
ecaabaaaabaaaaaabkiacaaaabaaaaaaaoaaaaaabaaaaaahccaabaaaacaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaaacaaaaaaegbcbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaaacaaaaaa
egacbaaaabaaaaaadiaaaaaihccabaaaadaaaaaaegacbaaaacaaaaaapgipcaaa
abaaaaaabeaaaaaadgaaaaagbcaabaaaabaaaaaackiacaaaabaaaaaaamaaaaaa
dgaaaaagccaabaaaabaaaaaackiacaaaabaaaaaaanaaaaaadgaaaaagecaabaaa
abaaaaaackiacaaaabaaaaaaaoaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaabaaaaaa
egacbaaaabaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaacaaaaaaegacbaaa
abaaaaaadiaaaaaihccabaaaaeaaaaaaegacbaaaaaaaaaaapgipcaaaabaaaaaa
beaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaabaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaabaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaaabaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"3.0-!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 2, 1, 0.5 } };
TEMP R0;
TEMP R1;
TEX R0.yw, fragment.texcoord[0], texture[1], 2D;
MAD R0.xy, R0.wyzw, c[1].x, -c[1].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.w, -R0.z, c[1].y;
RSQ R1.x, R0.w;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
RSQ R0.w, R0.z;
RCP R0.z, R1.x;
MUL R1.xyz, R0.w, fragment.texcoord[4];
ADD R1.xyz, R1, -R0;
TEX R0.w, fragment.texcoord[0].zwzw, texture[0], 2D;
MAD R1.xyz, R0.w, R1, R0;
DP3 R0.z, fragment.texcoord[3], R1;
DP3 R0.x, R1, fragment.texcoord[1];
DP3 R0.y, R1, fragment.texcoord[2];
MAD result.color.xyz, R0, c[1].z, c[1].z;
MOV result.color.w, c[0].x;
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c1, 2.00000000, -1.00000000, 1.00000000, 0.50000000
dcl_texcoord0 v0
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
texld r0.yw, v0, s1
mad_pp r0.xy, r0.wyzw, c1.x, c1.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r0.w, -r0.z, c1.z
rsq_pp r1.x, r0.w
dp3 r0.z, v4, v4
rsq r0.w, r0.z
rcp_pp r0.z, r1.x
mul r1.xyz, r0.w, v4
add_pp r1.xyz, r1, -r0
texld r0.w, v0.zwzw, s0
mad_pp r1.xyz, r0.w, r1, r0
dp3 r0.z, v3, r1
dp3 r0.x, r1, v1
dp3 r0.y, r1, v2
mad_pp oC0.xyz, r0, c1.w, c1.w
mov_pp oC0.w, c0.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
ConstBuffer "$Globals" 128
Float 80 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedkaokhjfipddhmkjanlmgdlgjoocnnnhmabaaaaaaniadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcliacaaaa
eaaaaaaakoaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaapdcaabaaaabaaaaaa
hgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaa
aaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahccaabaaaaaaaaaaaegaabaaa
abaaaaaaegaabaaaabaaaaaaddaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaaaaaaiadpaaaaaaaiccaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
abeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaabkaabaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegbcbaaaafaaaaaaagaabaaaaaaaaaaaegacbaiaebaaaaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaaacaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaacaaaaaa
egacbaaaaaaaaaaabaaaaaahccaabaaaabaaaaaaegbcbaaaadaaaaaaegacbaaa
aaaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaaaeaaaaaaegacbaaaaaaaaaaa
dcaaaaaphccabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaag
iccabaaaaaaaaaaaakiacaaaaaaaaaaaafaaaaaadoaaaaab"
}
}
 }
 Pass {
  Name "PREPASS"
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
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R2.zw, R0, c[6];
DP3 R4.x, R0, c[5];
DP3 R4.z, R0, c[7];
MOV R4.y, R2.z;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R3.z, R0, c[20];
DP4 R3.x, R0, c[18];
DP4 R3.y, R0, c[19];
MUL R0.w, R2.z, R2.z;
DP4 R1.z, R4, c[17];
DP4 R1.y, R4, c[16];
DP4 R1.x, R4, c[15];
ADD R0.xyz, R1, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R3.xyz, R0.w, c[21];
ADD result.texcoord[5].xyz, R0, R3;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R1.w, -R2, c[6];
MUL result.texcoord[3], R1, c[22].w;
DP3 result.color.y, -R2, R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 R1.w, -R2, c[5];
MOV R1.xyz, vertex.attrib[14];
MUL result.texcoord[2], R1, c[22].w;
DP3 R1.w, -R2, c[7];
MOV R1.xyz, vertex.normal;
MUL result.texcoord[4], R1, c[22].w;
DP3 result.color.z, -R2, vertex.normal;
DP3 result.color.x, vertex.attrib[14], -R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.texcoord[7].z, R4;
MOV result.texcoord[7].y, R2.w;
MOV result.texcoord[7].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[26], c[26].zwzw;
MAD result.color.secondary.zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.color.secondary.xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 58 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord6 o6
dcl_color1 o7
dcl_texcoord7 o8
dcl_color0 o9
dcl_texcoord5 o10
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r0.xyz, v2, c22.w
dp3 r2.zw, r0, c5
dp3 r4.x, r0, c4
dp3 r4.z, r0, c6
mov r4.y, r2.z
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c29.y
dp4 r3.z, r0, c20
dp4 r3.y, r0, c19
dp4 r3.x, r0, c18
mul r0.x, r2.z, r2.z
mad r0.w, r4.x, r4.x, -r0.x
dp4 r1.z, r4, c17
dp4 r1.y, r4, c16
dp4 r1.x, r4, c15
add r2.xyz, r1, r3
mul r3.xyz, r0.w, c21
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
add o10.xyz, r2, r3
mov r0.w, c29.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r1.w, -r2, c5
mul o4, r1, c22.w
dp3 o9.y, -r2, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c29.x
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 r1.w, -r2, c4
mov r1.xyz, v1
mul o3, r1, c22.w
dp3 r1.w, -r2, c6
mov r1.xyz, v2
mul o5, r1, c22.w
dp3 o9.z, -r2, v2
dp3 o9.x, v1, -r2
mov o0, r0
mov o2.zw, r0
mov o8.z, r4
mov o8.y, r2.w
mov o8.x, r4
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c23, c23.zwzw
mad o6.zw, v3.xyxy, c24.xyxy, c24
mad o6.xy, v3, c26, c26.zwzw
mad o7.zw, v3.xyxy, c28.xyxy, c28
mad o7.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 272
Vector 160 [_MainTex_ST]
Vector 176 [_MainTex1_ST]
Vector 192 [_BumpMap_ST]
Vector 208 [_LakerTex_ST]
Vector 224 [_SnowTex_ST]
Vector 240 [_SnowMaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
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
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedgkhafbpdpnngkdffdmbfghploakkfknjabaaaaaadiakaaaaadaaaaaa
cmaaaaaapeaaaaaaciacaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmabaaaaalaaaaaa
aiaaaaaabaabaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaabmabaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaabmabaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaabmabaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaabmabaaaaagaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaabmabaaaaahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahaiaaaacfabaaaa
aaaaaaaaaaaaaaaaadaaaaaaajaaaaaaahaiaaaabmabaaaaafaaaaaaaaaaaaaa
adaaaaaaakaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcaiaiaaaaeaaaabaaacacaaaafjaaaaaeegiocaaa
aaaaaaaabaaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagfaaaaadhccabaaaaiaaaaaagfaaaaadhccabaaa
ajaaaaaagfaaaaadhccabaaaakaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
akaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
acaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaafhcaabaaaaaaaaaaa
egbcbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
abaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaaacaaaaaafgafbaia
ebaaaaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaallcaabaaaacaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaa
abaaaaaaegaibaaaacaaaaaadgaaaaaficaabaaaaaaaaaaaakaabaaaacaaaaaa
diaaaaaipccabaaaadaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaabkaabaaaacaaaaaadiaaaaahhcaabaaaadaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaadaaaaaapgbpbaaaabaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaabaaaaaaicccabaaaajaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaafhcaabaaaacaaaaaa
egbcbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaagaaaaaa
agbebaaaadaaaaaaagiecaaaaaaaaaaaalaaaaaakgiocaaaaaaaaaaaalaaaaaa
dcaaaaaldccabaaaahaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaahaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaaiaaaaaaegacbaaaaaaaaaaabaaaaaai
bccabaaaajaaaaaaegbcbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaai
eccabaaaajaaaaaaegbcbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaakaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R2.zw, R0, c[6];
DP3 R4.x, R0, c[5];
DP3 R4.z, R0, c[7];
MOV R4.y, R2.z;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R3.z, R0, c[20];
DP4 R3.x, R0, c[18];
DP4 R3.y, R0, c[19];
MUL R0.w, R2.z, R2.z;
DP4 R1.z, R4, c[17];
DP4 R1.y, R4, c[16];
DP4 R1.x, R4, c[15];
ADD R0.xyz, R1, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R3.xyz, R0.w, c[21];
ADD result.texcoord[5].xyz, R0, R3;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R1.w, -R2, c[6];
MUL result.texcoord[3], R1, c[22].w;
DP3 result.color.y, -R2, R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 R1.w, -R2, c[5];
MOV R1.xyz, vertex.attrib[14];
MUL result.texcoord[2], R1, c[22].w;
DP3 R1.w, -R2, c[7];
MOV R1.xyz, vertex.normal;
MUL result.texcoord[4], R1, c[22].w;
DP3 result.color.z, -R2, vertex.normal;
DP3 result.color.x, vertex.attrib[14], -R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.texcoord[7].z, R4;
MOV result.texcoord[7].y, R2.w;
MOV result.texcoord[7].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[26], c[26].zwzw;
MAD result.color.secondary.zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.color.secondary.xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 58 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord6 o6
dcl_color1 o7
dcl_texcoord7 o8
dcl_color0 o9
dcl_texcoord5 o10
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r0.xyz, v2, c22.w
dp3 r2.zw, r0, c5
dp3 r4.x, r0, c4
dp3 r4.z, r0, c6
mov r4.y, r2.z
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c29.y
dp4 r3.z, r0, c20
dp4 r3.y, r0, c19
dp4 r3.x, r0, c18
mul r0.x, r2.z, r2.z
mad r0.w, r4.x, r4.x, -r0.x
dp4 r1.z, r4, c17
dp4 r1.y, r4, c16
dp4 r1.x, r4, c15
add r2.xyz, r1, r3
mul r3.xyz, r0.w, c21
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
add o10.xyz, r2, r3
mov r0.w, c29.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r1.w, -r2, c5
mul o4, r1, c22.w
dp3 o9.y, -r2, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c29.x
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 r1.w, -r2, c4
mov r1.xyz, v1
mul o3, r1, c22.w
dp3 r1.w, -r2, c6
mov r1.xyz, v2
mul o5, r1, c22.w
dp3 o9.z, -r2, v2
dp3 o9.x, v1, -r2
mov o0, r0
mov o2.zw, r0
mov o8.z, r4
mov o8.y, r2.w
mov o8.x, r4
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c23, c23.zwzw
mad o6.zw, v3.xyxy, c24.xyxy, c24
mad o6.xy, v3, c26, c26.zwzw
mad o7.zw, v3.xyxy, c28.xyxy, c28
mad o7.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Vector 160 [_MainTex_ST]
Vector 176 [_MainTex1_ST]
Vector 192 [_BumpMap_ST]
Vector 208 [_LakerTex_ST]
Vector 224 [_SnowTex_ST]
Vector 240 [_SnowMaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
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
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedgkhafbpdpnngkdffdmbfghploakkfknjabaaaaaadiakaaaaadaaaaaa
cmaaaaaapeaaaaaaciacaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmabaaaaalaaaaaa
aiaaaaaabaabaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaabmabaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaabmabaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaabmabaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaabmabaaaaagaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaabmabaaaaahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahaiaaaacfabaaaa
aaaaaaaaaaaaaaaaadaaaaaaajaaaaaaahaiaaaabmabaaaaafaaaaaaaaaaaaaa
adaaaaaaakaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcaiaiaaaaeaaaabaaacacaaaafjaaaaaeegiocaaa
aaaaaaaabaaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagfaaaaadhccabaaaaiaaaaaagfaaaaadhccabaaa
ajaaaaaagfaaaaadhccabaaaakaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
akaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
acaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaafhcaabaaaaaaaaaaa
egbcbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
abaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaaacaaaaaafgafbaia
ebaaaaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaallcaabaaaacaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaa
abaaaaaaegaibaaaacaaaaaadgaaaaaficaabaaaaaaaaaaaakaabaaaacaaaaaa
diaaaaaipccabaaaadaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaabkaabaaaacaaaaaadiaaaaahhcaabaaaadaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaadaaaaaapgbpbaaaabaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaabaaaaaaicccabaaaajaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaafhcaabaaaacaaaaaa
egbcbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaagaaaaaa
agbebaaaadaaaaaaagiecaaaaaaaaaaaalaaaaaakgiocaaaaaaaaaaaalaaaaaa
dcaaaaaldccabaaaahaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaahaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaaiaaaaaaegacbaaaaaaaaaaabaaaaaai
bccabaaaajaaaaaaegbcbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaai
eccabaaaajaaaaaaegbcbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaakaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R2.zw, R0, c[6];
DP3 R4.x, R0, c[5];
DP3 R4.z, R0, c[7];
MOV R4.y, R2.z;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R3.z, R0, c[20];
DP4 R3.x, R0, c[18];
DP4 R3.y, R0, c[19];
MUL R0.w, R2.z, R2.z;
DP4 R1.z, R4, c[17];
DP4 R1.y, R4, c[16];
DP4 R1.x, R4, c[15];
ADD R0.xyz, R1, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R3.xyz, R0.w, c[21];
ADD result.texcoord[5].xyz, R0, R3;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R1.w, -R2, c[6];
MUL result.texcoord[3], R1, c[22].w;
DP3 result.color.y, -R2, R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 R1.w, -R2, c[5];
MOV R1.xyz, vertex.attrib[14];
MUL result.texcoord[2], R1, c[22].w;
DP3 R1.w, -R2, c[7];
MOV R1.xyz, vertex.normal;
MUL result.texcoord[4], R1, c[22].w;
DP3 result.color.z, -R2, vertex.normal;
DP3 result.color.x, vertex.attrib[14], -R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.texcoord[7].z, R4;
MOV result.texcoord[7].y, R2.w;
MOV result.texcoord[7].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[26], c[26].zwzw;
MAD result.color.secondary.zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.color.secondary.xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 58 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord6 o6
dcl_color1 o7
dcl_texcoord7 o8
dcl_color0 o9
dcl_texcoord5 o10
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r0.xyz, v2, c22.w
dp3 r2.zw, r0, c5
dp3 r4.x, r0, c4
dp3 r4.z, r0, c6
mov r4.y, r2.z
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c29.y
dp4 r3.z, r0, c20
dp4 r3.y, r0, c19
dp4 r3.x, r0, c18
mul r0.x, r2.z, r2.z
mad r0.w, r4.x, r4.x, -r0.x
dp4 r1.z, r4, c17
dp4 r1.y, r4, c16
dp4 r1.x, r4, c15
add r2.xyz, r1, r3
mul r3.xyz, r0.w, c21
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
add o10.xyz, r2, r3
mov r0.w, c29.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r1.w, -r2, c5
mul o4, r1, c22.w
dp3 o9.y, -r2, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c29.x
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 r1.w, -r2, c4
mov r1.xyz, v1
mul o3, r1, c22.w
dp3 r1.w, -r2, c6
mov r1.xyz, v2
mul o5, r1, c22.w
dp3 o9.z, -r2, v2
dp3 o9.x, v1, -r2
mov o0, r0
mov o2.zw, r0
mov o8.z, r4
mov o8.y, r2.w
mov o8.x, r4
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c23, c23.zwzw
mad o6.zw, v3.xyxy, c24.xyxy, c24
mad o6.xy, v3, c26, c26.zwzw
mad o7.zw, v3.xyxy, c28.xyxy, c28
mad o7.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Vector 160 [_MainTex_ST]
Vector 176 [_MainTex1_ST]
Vector 192 [_BumpMap_ST]
Vector 208 [_LakerTex_ST]
Vector 224 [_SnowTex_ST]
Vector 240 [_SnowMaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
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
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedgkhafbpdpnngkdffdmbfghploakkfknjabaaaaaadiakaaaaadaaaaaa
cmaaaaaapeaaaaaaciacaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmabaaaaalaaaaaa
aiaaaaaabaabaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaabmabaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaabmabaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaabmabaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaabmabaaaaagaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaabmabaaaaahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahaiaaaacfabaaaa
aaaaaaaaaaaaaaaaadaaaaaaajaaaaaaahaiaaaabmabaaaaafaaaaaaaaaaaaaa
adaaaaaaakaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcaiaiaaaaeaaaabaaacacaaaafjaaaaaeegiocaaa
aaaaaaaabaaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagfaaaaadhccabaaaaiaaaaaagfaaaaadhccabaaa
ajaaaaaagfaaaaadhccabaaaakaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
akaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
acaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaafhcaabaaaaaaaaaaa
egbcbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
abaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaaacaaaaaafgafbaia
ebaaaaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaallcaabaaaacaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaa
abaaaaaaegaibaaaacaaaaaadgaaaaaficaabaaaaaaaaaaaakaabaaaacaaaaaa
diaaaaaipccabaaaadaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaabkaabaaaacaaaaaadiaaaaahhcaabaaaadaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaadaaaaaapgbpbaaaabaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaabaaaaaaicccabaaaajaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaafhcaabaaaacaaaaaa
egbcbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaagaaaaaa
agbebaaaadaaaaaaagiecaaaaaaaaaaaalaaaaaakgiocaaaaaaaaaaaalaaaaaa
dcaaaaaldccabaaaahaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaahaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaaiaaaaaaegacbaaaaaaaaaaabaaaaaai
bccabaaaajaaaaaaegbcbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaai
eccabaaaajaaaaaaegbcbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaakaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R2.zw, R0, c[6];
DP3 R4.x, R0, c[5];
DP3 R4.z, R0, c[7];
MOV R4.y, R2.z;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R3.z, R0, c[20];
DP4 R3.x, R0, c[18];
DP4 R3.y, R0, c[19];
MUL R0.w, R2.z, R2.z;
DP4 R1.z, R4, c[17];
DP4 R1.y, R4, c[16];
DP4 R1.x, R4, c[15];
ADD R0.xyz, R1, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R3.xyz, R0.w, c[21];
ADD result.texcoord[5].xyz, R0, R3;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R1.w, -R2, c[6];
MUL result.texcoord[3], R1, c[22].w;
DP3 result.color.y, -R2, R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 R1.w, -R2, c[5];
MOV R1.xyz, vertex.attrib[14];
MUL result.texcoord[2], R1, c[22].w;
DP3 R1.w, -R2, c[7];
MOV R1.xyz, vertex.normal;
MUL result.texcoord[4], R1, c[22].w;
DP3 result.color.z, -R2, vertex.normal;
DP3 result.color.x, vertex.attrib[14], -R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.texcoord[7].z, R4;
MOV result.texcoord[7].y, R2.w;
MOV result.texcoord[7].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[26], c[26].zwzw;
MAD result.color.secondary.zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.color.secondary.xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 58 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord6 o6
dcl_color1 o7
dcl_texcoord7 o8
dcl_color0 o9
dcl_texcoord5 o10
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r0.xyz, v2, c22.w
dp3 r2.zw, r0, c5
dp3 r4.x, r0, c4
dp3 r4.z, r0, c6
mov r4.y, r2.z
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c29.y
dp4 r3.z, r0, c20
dp4 r3.y, r0, c19
dp4 r3.x, r0, c18
mul r0.x, r2.z, r2.z
mad r0.w, r4.x, r4.x, -r0.x
dp4 r1.z, r4, c17
dp4 r1.y, r4, c16
dp4 r1.x, r4, c15
add r2.xyz, r1, r3
mul r3.xyz, r0.w, c21
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
add o10.xyz, r2, r3
mov r0.w, c29.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r1.w, -r2, c5
mul o4, r1, c22.w
dp3 o9.y, -r2, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c29.x
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 r1.w, -r2, c4
mov r1.xyz, v1
mul o3, r1, c22.w
dp3 r1.w, -r2, c6
mov r1.xyz, v2
mul o5, r1, c22.w
dp3 o9.z, -r2, v2
dp3 o9.x, v1, -r2
mov o0, r0
mov o2.zw, r0
mov o8.z, r4
mov o8.y, r2.w
mov o8.x, r4
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c23, c23.zwzw
mad o6.zw, v3.xyxy, c24.xyxy, c24
mad o6.xy, v3, c26, c26.zwzw
mad o7.zw, v3.xyxy, c28.xyxy, c28
mad o7.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 272
Vector 160 [_MainTex_ST]
Vector 176 [_MainTex1_ST]
Vector 192 [_BumpMap_ST]
Vector 208 [_LakerTex_ST]
Vector 224 [_SnowTex_ST]
Vector 240 [_SnowMaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
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
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedgkhafbpdpnngkdffdmbfghploakkfknjabaaaaaadiakaaaaadaaaaaa
cmaaaaaapeaaaaaaciacaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmabaaaaalaaaaaa
aiaaaaaabaabaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaabmabaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaabmabaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaabmabaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaabmabaaaaagaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaabmabaaaaahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahaiaaaacfabaaaa
aaaaaaaaaaaaaaaaadaaaaaaajaaaaaaahaiaaaabmabaaaaafaaaaaaaaaaaaaa
adaaaaaaakaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcaiaiaaaaeaaaabaaacacaaaafjaaaaaeegiocaaa
aaaaaaaabaaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagfaaaaadhccabaaaaiaaaaaagfaaaaadhccabaaa
ajaaaaaagfaaaaadhccabaaaakaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
akaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
acaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaafhcaabaaaaaaaaaaa
egbcbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
abaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaaacaaaaaafgafbaia
ebaaaaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaallcaabaaaacaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaa
abaaaaaaegaibaaaacaaaaaadgaaaaaficaabaaaaaaaaaaaakaabaaaacaaaaaa
diaaaaaipccabaaaadaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaabkaabaaaacaaaaaadiaaaaahhcaabaaaadaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaadaaaaaapgbpbaaaabaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaabaaaaaaicccabaaaajaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaafhcaabaaaacaaaaaa
egbcbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaagaaaaaa
agbebaaaadaaaaaaagiecaaaaaaaaaaaalaaaaaakgiocaaaaaaaaaaaalaaaaaa
dcaaaaaldccabaaaahaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaahaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaaiaaaaaaegacbaaaaaaaaaaabaaaaaai
bccabaaaajaaaaaaegbcbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaai
eccabaaaajaaaaaaegbcbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaakaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R2.zw, R0, c[6];
DP3 R4.x, R0, c[5];
DP3 R4.z, R0, c[7];
MOV R4.y, R2.z;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R3.z, R0, c[20];
DP4 R3.x, R0, c[18];
DP4 R3.y, R0, c[19];
MUL R0.w, R2.z, R2.z;
DP4 R1.z, R4, c[17];
DP4 R1.y, R4, c[16];
DP4 R1.x, R4, c[15];
ADD R0.xyz, R1, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R3.xyz, R0.w, c[21];
ADD result.texcoord[5].xyz, R0, R3;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R1.w, -R2, c[6];
MUL result.texcoord[3], R1, c[22].w;
DP3 result.color.y, -R2, R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 R1.w, -R2, c[5];
MOV R1.xyz, vertex.attrib[14];
MUL result.texcoord[2], R1, c[22].w;
DP3 R1.w, -R2, c[7];
MOV R1.xyz, vertex.normal;
MUL result.texcoord[4], R1, c[22].w;
DP3 result.color.z, -R2, vertex.normal;
DP3 result.color.x, vertex.attrib[14], -R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.texcoord[7].z, R4;
MOV result.texcoord[7].y, R2.w;
MOV result.texcoord[7].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[26], c[26].zwzw;
MAD result.color.secondary.zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.color.secondary.xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 58 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord6 o6
dcl_color1 o7
dcl_texcoord7 o8
dcl_color0 o9
dcl_texcoord5 o10
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r0.xyz, v2, c22.w
dp3 r2.zw, r0, c5
dp3 r4.x, r0, c4
dp3 r4.z, r0, c6
mov r4.y, r2.z
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c29.y
dp4 r3.z, r0, c20
dp4 r3.y, r0, c19
dp4 r3.x, r0, c18
mul r0.x, r2.z, r2.z
mad r0.w, r4.x, r4.x, -r0.x
dp4 r1.z, r4, c17
dp4 r1.y, r4, c16
dp4 r1.x, r4, c15
add r2.xyz, r1, r3
mul r3.xyz, r0.w, c21
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
add o10.xyz, r2, r3
mov r0.w, c29.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r1.w, -r2, c5
mul o4, r1, c22.w
dp3 o9.y, -r2, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c29.x
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 r1.w, -r2, c4
mov r1.xyz, v1
mul o3, r1, c22.w
dp3 r1.w, -r2, c6
mov r1.xyz, v2
mul o5, r1, c22.w
dp3 o9.z, -r2, v2
dp3 o9.x, v1, -r2
mov o0, r0
mov o2.zw, r0
mov o8.z, r4
mov o8.y, r2.w
mov o8.x, r4
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c23, c23.zwzw
mad o6.zw, v3.xyxy, c24.xyxy, c24
mad o6.xy, v3, c26, c26.zwzw
mad o7.zw, v3.xyxy, c28.xyxy, c28
mad o7.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Vector 160 [_MainTex_ST]
Vector 176 [_MainTex1_ST]
Vector 192 [_BumpMap_ST]
Vector 208 [_LakerTex_ST]
Vector 224 [_SnowTex_ST]
Vector 240 [_SnowMaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
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
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedgkhafbpdpnngkdffdmbfghploakkfknjabaaaaaadiakaaaaadaaaaaa
cmaaaaaapeaaaaaaciacaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmabaaaaalaaaaaa
aiaaaaaabaabaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaabmabaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaabmabaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaabmabaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaabmabaaaaagaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaabmabaaaaahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahaiaaaacfabaaaa
aaaaaaaaaaaaaaaaadaaaaaaajaaaaaaahaiaaaabmabaaaaafaaaaaaaaaaaaaa
adaaaaaaakaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcaiaiaaaaeaaaabaaacacaaaafjaaaaaeegiocaaa
aaaaaaaabaaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagfaaaaadhccabaaaaiaaaaaagfaaaaadhccabaaa
ajaaaaaagfaaaaadhccabaaaakaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
akaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
acaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaafhcaabaaaaaaaaaaa
egbcbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
abaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaaacaaaaaafgafbaia
ebaaaaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaallcaabaaaacaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaa
abaaaaaaegaibaaaacaaaaaadgaaaaaficaabaaaaaaaaaaaakaabaaaacaaaaaa
diaaaaaipccabaaaadaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaabkaabaaaacaaaaaadiaaaaahhcaabaaaadaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaadaaaaaapgbpbaaaabaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaabaaaaaaicccabaaaajaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaafhcaabaaaacaaaaaa
egbcbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaagaaaaaa
agbebaaaadaaaaaaagiecaaaaaaaaaaaalaaaaaakgiocaaaaaaaaaaaalaaaaaa
dcaaaaaldccabaaaahaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaahaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaaiaaaaaaegacbaaaaaaaaaaabaaaaaai
bccabaaaajaaaaaaegbcbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaai
eccabaaaajaaaaaaegbcbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaakaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_ProjectionParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[22].w;
DP3 R2.zw, R0, c[6];
DP3 R4.x, R0, c[5];
DP3 R4.z, R0, c[7];
MOV R4.y, R2.z;
MUL R0, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
DP4 R3.z, R0, c[20];
DP4 R3.x, R0, c[18];
DP4 R3.y, R0, c[19];
MUL R0.w, R2.z, R2.z;
DP4 R1.z, R4, c[17];
DP4 R1.y, R4, c[16];
DP4 R1.x, R4, c[15];
ADD R0.xyz, R1, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MAD R0.w, R4.x, R4.x, -R0;
MUL R3.xyz, R0.w, c[21];
ADD result.texcoord[5].xyz, R0, R3;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R0.xyz, c[13];
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[11];
DP4 R2.x, R0, c[9];
DP4 R2.y, R0, c[10];
MAD R2.xyz, R2, c[22].w, -vertex.position;
DP3 R1.w, -R2, c[6];
MUL result.texcoord[3], R1, c[22].w;
DP3 result.color.y, -R2, R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R3.xyz, R0.xyww, c[0].x;
MUL R1.y, R3, c[14].x;
MOV R1.x, R3;
ADD result.texcoord[1].xy, R1, R3.z;
DP3 R1.w, -R2, c[5];
MOV R1.xyz, vertex.attrib[14];
MUL result.texcoord[2], R1, c[22].w;
DP3 R1.w, -R2, c[7];
MOV R1.xyz, vertex.normal;
MUL result.texcoord[4], R1, c[22].w;
DP3 result.color.z, -R2, vertex.normal;
DP3 result.color.x, vertex.attrib[14], -R2;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
MOV result.texcoord[7].z, R4;
MOV result.texcoord[7].y, R2.w;
MOV result.texcoord[7].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[23], c[23].zwzw;
MAD result.texcoord[6].zw, vertex.texcoord[0].xyxy, c[24].xyxy, c[24];
MAD result.texcoord[6].xy, vertex.texcoord[0], c[26], c[26].zwzw;
MAD result.color.secondary.zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.color.secondary.xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 58 instructions, 5 R-regs
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
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_ProjectionParams]
Vector 14 [_ScreenParams]
Vector 15 [unity_SHAr]
Vector 16 [unity_SHAg]
Vector 17 [unity_SHAb]
Vector 18 [unity_SHBr]
Vector 19 [unity_SHBg]
Vector 20 [unity_SHBb]
Vector 21 [unity_SHC]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_MainTex1_ST]
Vector 25 [_BumpMap_ST]
Vector 26 [_LakerTex_ST]
Vector 27 [_SnowTex_ST]
Vector 28 [_SnowMaskTex_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord6 o6
dcl_color1 o7
dcl_texcoord7 o8
dcl_color0 o9
dcl_texcoord5 o10
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r0.xyz, v2, c22.w
dp3 r2.zw, r0, c5
dp3 r4.x, r0, c4
dp3 r4.z, r0, c6
mov r4.y, r2.z
mul r0, r4.xyzz, r4.yzzx
mov r4.w, c29.y
dp4 r3.z, r0, c20
dp4 r3.y, r0, c19
dp4 r3.x, r0, c18
mul r0.x, r2.z, r2.z
mad r0.w, r4.x, r4.x, -r0.x
dp4 r1.z, r4, c17
dp4 r1.y, r4, c16
dp4 r1.x, r4, c15
add r2.xyz, r1, r3
mul r3.xyz, r0.w, c21
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c12
add o10.xyz, r2, r3
mov r0.w, c29.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c22.w, -v0
dp3 r1.w, -r2, c5
mul o4, r1, c22.w
dp3 o9.y, -r2, r1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r3.xyz, r0.xyww, c29.x
mul r1.y, r3, c13.x
mov r1.x, r3
mad o2.xy, r3.z, c14.zwzw, r1
dp3 r1.w, -r2, c4
mov r1.xyz, v1
mul o3, r1, c22.w
dp3 r1.w, -r2, c6
mov r1.xyz, v2
mul o5, r1, c22.w
dp3 o9.z, -r2, v2
dp3 o9.x, v1, -r2
mov o0, r0
mov o2.zw, r0
mov o8.z, r4
mov o8.y, r2.w
mov o8.x, r4
mad o1.zw, v3.xyxy, c25.xyxy, c25
mad o1.xy, v3, c23, c23.zwzw
mad o6.zw, v3.xyxy, c24.xyxy, c24
mad o6.xy, v3, c26, c26.zwzw
mad o7.zw, v3.xyxy, c28.xyxy, c28
mad o7.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Vector 160 [_MainTex_ST]
Vector 176 [_MainTex1_ST]
Vector 192 [_BumpMap_ST]
Vector 208 [_LakerTex_ST]
Vector 224 [_SnowTex_ST]
Vector 240 [_SnowMaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
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
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedgkhafbpdpnngkdffdmbfghploakkfknjabaaaaaadiakaaaaadaaaaaa
cmaaaaaapeaaaaaaciacaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmabaaaaalaaaaaa
aiaaaaaabaabaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaabmabaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaabmabaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaabmabaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaabmabaaaaagaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaabmabaaaaahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahaiaaaacfabaaaa
aaaaaaaaaaaaaaaaadaaaaaaajaaaaaaahaiaaaabmabaaaaafaaaaaaaaaaaaaa
adaaaaaaakaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcaiaiaaaaeaaaabaaacacaaaafjaaaaaeegiocaaa
aaaaaaaabaaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagfaaaaadhccabaaaaiaaaaaagfaaaaadhccabaaa
ajaaaaaagfaaaaadhccabaaaakaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
akaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
acaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaafhcaabaaaaaaaaaaa
egbcbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
abaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaaacaaaaaafgafbaia
ebaaaaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaallcaabaaaacaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaa
abaaaaaaegaibaaaacaaaaaadgaaaaaficaabaaaaaaaaaaaakaabaaaacaaaaaa
diaaaaaipccabaaaadaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dgaaaaaficaabaaaaaaaaaaabkaabaaaacaaaaaadiaaaaahhcaabaaaadaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaadaaaaaapgbpbaaaabaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaabaaaaaaicccabaaaajaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaafhcaabaaaacaaaaaa
egbcbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaagaaaaaa
agbebaaaadaaaaaaagiecaaaaaaaaaaaalaaaaaakgiocaaaaaaaaaaaalaaaaaa
dcaaaaaldccabaaaahaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaahaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaaiaaaaaaegacbaaaaaaaaaaabaaaaaai
bccabaaaajaaaaaaegbcbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaabaaaaaai
eccabaaaajaaaaaaegbcbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaakaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..8],
		{ 2, 1, 0.5, 0.07 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R0.xy, R0.wyzw, c[9].x, -c[9].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[9].y;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
TEX R1, fragment.texcoord[0], texture[0], 2D;
ADD R2.xyz, fragment.texcoord[7], -R0;
MAD R2.xyz, R1.w, R2, R0;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R0.x, R0, fragment.color.primary;
MUL R0.x, R0, c[6];
MUL R2.w, R0.x, c[9];
DP3 R0.y, fragment.texcoord[2], R2;
DP3 R0.w, R2, fragment.texcoord[4];
DP3 R0.z, R2, fragment.texcoord[3];
DP3 R2.x, fragment.color.primary, R0.yzww;
MUL R2.xyz, R0.yzww, R2.x;
MAD R2.xyz, -R2, c[9].x, fragment.color.primary;
DP3 R2.z, R2, R2;
RSQ R2.z, R2.z;
MUL R3.xy, R2.z, R2;
ADD R2.xy, R2.w, fragment.texcoord[6];
TEX R0.x, R2, texture[4], 2D;
TEX R3.xyz, R3, texture[2], 2D;
TEX R2.xyz, fragment.texcoord[6], texture[4], 2D;
ADD R2.xyz, R2, -R0.x;
MAD R2.xyz, R2, c[10].x, R0.x;
MUL R3.xyz, R3, c[8].x;
ADD R3.xyz, R2, R3;
ADD R4.xy, R2.w, fragment.texcoord[6].zwzw;
TEX R2, R4, texture[3], 2D;
ADD R2.xyz, R2, -R3;
MUL R0.x, R2.w, c[7];
MAD R2.xyz, R0.x, R2, R3;
ADD R1.xyz, R1, -R2;
MAD R1.xyz, R1.w, R1, R2;
MOV R2.x, R0.y;
MOV R2.y, R0.z;
MOV R2.z, R0.w;
DP3 R2.w, R2, R2;
RSQ R2.w, R2.w;
MUL R2.xyz, R2.w, R2;
MOV R0.xz, c[4];
MOV R0.y, -c[4];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, R2;
TEX R0.xyz, fragment.color.secondary, texture[5], 2D;
MAD R0.w, R0, c[9].z, c[9].z;
MUL R0.xyz, R0, c[3];
MAD R0.xyz, -R1, c[1], R0;
MUL_SAT R0.w, R0, c[5].x;
ADD R0.w, -R0, c[9].y;
MUL R2.xyz, R0.w, R0;
TXP R0, fragment.texcoord[1], texture[7], 2D;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R3.xyz, -R0, fragment.texcoord[5];
LG2 R0.x, R0.w;
ADD R0.y, -R1.w, c[9];
MUL R2.w, -R0.x, R0.y;
MUL R0.xyz, R3, c[0];
MUL R0.yzw, R0.xxyz, R2.w;
TEX R0.x, fragment.color.secondary.zwzw, texture[6], 2D;
MUL R1.xyz, R1, c[1];
MAD R1.xyz, R0.x, R2, R1;
MAD R0.xyz, R1, R3, R0.yzww;
MUL R0.w, R2, c[0];
MAD result.color.xyz, R1, c[2], R0;
MAD result.color.w, R1, c[1], R0;
END
# 75 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c9, 2.00000000, -1.00000000, 1.00000000, 0.50000000
def c10, 0.07000000, 0.20000000, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord6 v5
dcl_color1 v6
dcl_texcoord7 v7.xyz
dcl_color0 v8.xyz
dcl_texcoord5 v9.xyz
texld r0.yw, v0.zwzw, s1
mad_pp r0.xy, r0.wyzw, c9.x, c9.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r0.z, -r0, c9
rsq_pp r0.z, r0.z
rcp_pp r0.z, r0.z
texld r1, v0, s0
add_pp r2.xyz, v7, -r0
mad_pp r2.xyz, r1.w, r2, r0
dp3 r0.x, v8, v8
rsq r0.x, r0.x
mul r0.x, r0, v8
mul r0.x, r0, c6
mul r2.w, r0.x, c10.x
dp3_pp r0.y, v2, r2
dp3_pp r0.w, r2, v4
dp3_pp r0.z, r2, v3
dp3 r2.x, v8, r0.yzww
mul r2.xyz, r0.yzww, r2.x
mad r2.xyz, -r2, c9.x, v8
dp3 r2.z, r2, r2
rsq r2.z, r2.z
mul r3.xy, r2.z, r2
add_pp r2.xy, r2.w, v5
texld r0.x, r2, s4
texld r3.xyz, r3, s2
texld r2.xyz, v5, s4
add r2.xyz, r2, -r0.x
mad r2.xyz, r2, c10.y, r0.x
mul r3.xyz, r3, c8.x
add_pp r3.xyz, r2, r3
add r4.xy, r2.w, v5.zwzw
texld r2, r4, s3
add_pp r2.xyz, r2, -r3
mul_pp r0.x, r2.w, c7
mad_pp r2.xyz, r0.x, r2, r3
add_pp r1.xyz, r1, -r2
mad_pp r1.xyz, r1.w, r1, r2
mov r2.x, r0.y
mov r2.y, r0.z
mov r2.z, r0.w
dp3 r2.w, r2, r2
rsq r2.w, r2.w
mov r0.xz, c4
mov r0.y, -c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r2.xyz, r2.w, r2
dp3 r0.w, r0, r2
texld r0.xyz, v6, s5
mad r0.w, r0, c9, c9
mul r0.xyz, r0, c3
mad_pp r0.xyz, -r1, c1, r0
mul_sat r0.w, r0, c5.x
add r0.w, -r0, c9.z
mul_pp r2.xyz, r0.w, r0
texldp r0, v1, s7
mul_pp r1.xyz, r1, c1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, v9
log_pp r0.x, r0.w
add r0.y, -r1.w, c9.z
mul_pp r0.w, -r0.x, r0.y
mul_pp r0.xyz, r3, c0
mul_pp r4.xyz, r0, r0.w
texld r0.x, v6.zwzw, s6
mad_pp r0.xyz, r0.x, r2, r1
mad_pp r1.xyz, r0, r3, r4
mul_pp r0.w, r0, c0
mad_pp oC0.xyz, r0, c2, r1
mad_pp oC0.w, r1, c1, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LakerTex] 2D 3
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_RefTex] 2D 4
SetTexture 4 [_MainTex1] 2D 1
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
ConstBuffer "$Globals" 272
Vector 32 [_SpecColor]
Vector 48 [_Color]
Vector 64 [_EmissiveColor]
Vector 96 [_SnowColor]
Vector 112 [_SnowDirection]
Float 128 [_SnowRange]
Float 136 [_Parallax]
Float 140 [_DownBlend]
Float 144 [_RefPara]
BindCB  "$Globals" 0
"ps_4_0
eefiecedbhidemnkeiikgckedpcdgbflafiklfdfabaaaaaafmalaaaaadaaaaaa
cmaaaaaagaabaaaajeabaaaaejfdeheocmabaaaaalaaaaaaaiaaaaaabaabaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaabmabaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apalaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaabmabaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapahaaaabmabaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapahaaaabmabaaaaagaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaabmabaaaa
ahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahahaaaacfabaaaaaaaaaaaaaaaaaaaa
adaaaaaaajaaaaaaahahaaaabmabaaaaafaaaaaaaaaaaaaaadaaaaaaakaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmaajaaaaeaaaaaaa
haacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafkaaaaad
aagabaaaagaaaaaafkaaaaadaagabaaaahaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaafibiaaaeaahabaaaagaaaaaa
ffffaaaafibiaaaeaahabaaaahaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadlcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadpcbabaaaagaaaaaagcbaaaad
pcbabaaaahaaaaaagcbaaaadhcbabaaaaiaaaaaagcbaaaadhcbabaaaajaaaaaa
gcbaaaadhcbabaaaakaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaajaaaaaaegbcbaaaajaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakbabaaaajaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaacjfmipdndcaaaaakpcaabaaaaaaaaaaaagaabaaaaaaaaaaakgikcaaa
aaaaaaaaaiaaaaaaegbobaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaa
aaaaaaaaeghobaaaaeaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaaiccaabaaa
aaaaaaaadkaabaaaabaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaagaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaaaaaaaaai
hcaabaaaacaaaaaaagaabaiaebaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaam
ncaabaaaaaaaaaaaagajbaaaacaaaaaaaceaaaaamnmmemdoaaaaaaaamnmmemdo
mnmmemdoagaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaa
acaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaabaaaaaaegaabaaaacaaaaaa
egaabaaaacaaaaaaddaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaacaaaaaadkaabaaaabaaaaaaaaaaaaaihcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegbcbaaaaiaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaeaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaadaaaaaaegbcbaaaadaaaaaaegacbaaaacaaaaaabaaaaaah
ccaabaaaadaaaaaaegbcbaaaaeaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
adaaaaaaegbcbaaaafaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egbcbaaaajaaaaaaegacbaaaadaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaadkaabaaaabaaaaaadcaaaaakhcaabaaaacaaaaaaegacbaaaadaaaaaa
pgapbaiaebaaaaaaabaaaaaaegbcbaaaajaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahdcaabaaaacaaaaaapgapbaaaabaaaaaaegaabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
aeaaaaaadcaaaaakncaabaaaaaaaaaaaagiacaaaaaaaaaaaajaaaaaaagajbaaa
acaaaaaaagaobaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaigadbaiaebaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaajhcaabaaaaaaaaaaafgafbaaaaaaaaaaa
egacbaaaabaaaaaaigadbaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaia
ebaaaaaaaaaaaaaaegacbaaaaeaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaa
aeaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaahaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadcaaaaalhcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaaegacbaiaebaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaadiaaaaalhcaabaaaadaaaaaaegiccaaa
aaaaaaaaahaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaaifcaabaaaadaaaaaapgapbaaaaaaaaaaa
agiccaaaaaaaaaaaahaaaaaadiaaaaajccaabaaaadaaaaaadkaabaaaaaaaaaaa
bkiacaiaebaaaaaaaaaaaaaaahaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaadpabeaaaaaaaaaaadpdicaaaaiicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakiacaaaaaaaaaaaaiaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaahaaaaaa
eghobaaaagaaaaaaaagabaaaagaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
acaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaahaaaaaaaagabaaaahaaaaaacpaaaaafpcaabaaaabaaaaaa
egaobaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaiaebaaaaaaabaaaaaa
egbcbaaaakaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaeaaaaaa
abeaaaaaaaaaiadpdiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaia
ebaaaaaaabaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
acaaaaaadiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkiacaaaaaaaaaaa
acaaaaaadcaaaaakiccabaaaaaaaaaaadkaabaaaaeaaaaaadkiacaaaaaaaaaaa
adaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaaeaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..8],
		{ 2, 1, 0.5, 0.07 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R0.xy, R0.wyzw, c[9].x, -c[9].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[9].y;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
TEX R1, fragment.texcoord[0], texture[0], 2D;
ADD R2.xyz, fragment.texcoord[7], -R0;
MAD R2.xyz, R1.w, R2, R0;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R0.x, R0, fragment.color.primary;
MUL R0.x, R0, c[6];
MUL R2.w, R0.x, c[9];
DP3 R0.y, fragment.texcoord[2], R2;
DP3 R0.w, R2, fragment.texcoord[4];
DP3 R0.z, R2, fragment.texcoord[3];
DP3 R2.x, fragment.color.primary, R0.yzww;
MUL R2.xyz, R0.yzww, R2.x;
MAD R2.xyz, -R2, c[9].x, fragment.color.primary;
DP3 R2.z, R2, R2;
RSQ R2.z, R2.z;
MUL R3.xy, R2.z, R2;
ADD R2.xy, R2.w, fragment.texcoord[6];
TEX R0.x, R2, texture[4], 2D;
TEX R3.xyz, R3, texture[2], 2D;
TEX R2.xyz, fragment.texcoord[6], texture[4], 2D;
ADD R2.xyz, R2, -R0.x;
MAD R2.xyz, R2, c[10].x, R0.x;
MUL R3.xyz, R3, c[8].x;
ADD R3.xyz, R2, R3;
ADD R4.xy, R2.w, fragment.texcoord[6].zwzw;
TEX R2, R4, texture[3], 2D;
ADD R2.xyz, R2, -R3;
MUL R0.x, R2.w, c[7];
MAD R2.xyz, R0.x, R2, R3;
ADD R1.xyz, R1, -R2;
MAD R1.xyz, R1.w, R1, R2;
MOV R2.x, R0.y;
MOV R2.y, R0.z;
MOV R2.z, R0.w;
DP3 R2.w, R2, R2;
RSQ R2.w, R2.w;
MUL R2.xyz, R2.w, R2;
MOV R0.xz, c[4];
MOV R0.y, -c[4];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, R2;
TEX R0.xyz, fragment.color.secondary, texture[5], 2D;
MAD R0.w, R0, c[9].z, c[9].z;
MUL R0.xyz, R0, c[3];
MAD R0.xyz, -R1, c[1], R0;
MUL_SAT R0.w, R0, c[5].x;
ADD R0.w, -R0, c[9].y;
MUL R2.xyz, R0.w, R0;
TXP R0, fragment.texcoord[1], texture[7], 2D;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R3.xyz, -R0, fragment.texcoord[5];
LG2 R0.x, R0.w;
ADD R0.y, -R1.w, c[9];
MUL R2.w, -R0.x, R0.y;
MUL R0.xyz, R3, c[0];
MUL R0.yzw, R0.xxyz, R2.w;
TEX R0.x, fragment.color.secondary.zwzw, texture[6], 2D;
MUL R1.xyz, R1, c[1];
MAD R1.xyz, R0.x, R2, R1;
MAD R0.xyz, R1, R3, R0.yzww;
MUL R0.w, R2, c[0];
MAD result.color.xyz, R1, c[2], R0;
MAD result.color.w, R1, c[1], R0;
END
# 75 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c9, 2.00000000, -1.00000000, 1.00000000, 0.50000000
def c10, 0.07000000, 0.20000000, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord6 v5
dcl_color1 v6
dcl_texcoord7 v7.xyz
dcl_color0 v8.xyz
dcl_texcoord5 v9.xyz
texld r0.yw, v0.zwzw, s1
mad_pp r0.xy, r0.wyzw, c9.x, c9.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r0.z, -r0, c9
rsq_pp r0.z, r0.z
rcp_pp r0.z, r0.z
texld r1, v0, s0
add_pp r2.xyz, v7, -r0
mad_pp r2.xyz, r1.w, r2, r0
dp3 r0.x, v8, v8
rsq r0.x, r0.x
mul r0.x, r0, v8
mul r0.x, r0, c6
mul r2.w, r0.x, c10.x
dp3_pp r0.y, v2, r2
dp3_pp r0.w, r2, v4
dp3_pp r0.z, r2, v3
dp3 r2.x, v8, r0.yzww
mul r2.xyz, r0.yzww, r2.x
mad r2.xyz, -r2, c9.x, v8
dp3 r2.z, r2, r2
rsq r2.z, r2.z
mul r3.xy, r2.z, r2
add_pp r2.xy, r2.w, v5
texld r0.x, r2, s4
texld r3.xyz, r3, s2
texld r2.xyz, v5, s4
add r2.xyz, r2, -r0.x
mad r2.xyz, r2, c10.y, r0.x
mul r3.xyz, r3, c8.x
add_pp r3.xyz, r2, r3
add r4.xy, r2.w, v5.zwzw
texld r2, r4, s3
add_pp r2.xyz, r2, -r3
mul_pp r0.x, r2.w, c7
mad_pp r2.xyz, r0.x, r2, r3
add_pp r1.xyz, r1, -r2
mad_pp r1.xyz, r1.w, r1, r2
mov r2.x, r0.y
mov r2.y, r0.z
mov r2.z, r0.w
dp3 r2.w, r2, r2
rsq r2.w, r2.w
mov r0.xz, c4
mov r0.y, -c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r2.xyz, r2.w, r2
dp3 r0.w, r0, r2
texld r0.xyz, v6, s5
mad r0.w, r0, c9, c9
mul r0.xyz, r0, c3
mad_pp r0.xyz, -r1, c1, r0
mul_sat r0.w, r0, c5.x
add r0.w, -r0, c9.z
mul_pp r2.xyz, r0.w, r0
texldp r0, v1, s7
mul_pp r1.xyz, r1, c1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, v9
log_pp r0.x, r0.w
add r0.y, -r1.w, c9.z
mul_pp r0.w, -r0.x, r0.y
mul_pp r0.xyz, r3, c0
mul_pp r4.xyz, r0, r0.w
texld r0.x, v6.zwzw, s6
mad_pp r0.xyz, r0.x, r2, r1
mad_pp r1.xyz, r0, r3, r4
mul_pp r0.w, r0, c0
mad_pp oC0.xyz, r0, c2, r1
mad_pp oC0.w, r1, c1, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LakerTex] 2D 3
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_RefTex] 2D 4
SetTexture 4 [_MainTex1] 2D 1
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
ConstBuffer "$Globals" 288
Vector 32 [_SpecColor]
Vector 48 [_Color]
Vector 64 [_EmissiveColor]
Vector 96 [_SnowColor]
Vector 112 [_SnowDirection]
Float 128 [_SnowRange]
Float 136 [_Parallax]
Float 140 [_DownBlend]
Float 144 [_RefPara]
BindCB  "$Globals" 0
"ps_4_0
eefiecedbhidemnkeiikgckedpcdgbflafiklfdfabaaaaaafmalaaaaadaaaaaa
cmaaaaaagaabaaaajeabaaaaejfdeheocmabaaaaalaaaaaaaiaaaaaabaabaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaabmabaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apalaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaabmabaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapahaaaabmabaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapahaaaabmabaaaaagaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaabmabaaaa
ahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahahaaaacfabaaaaaaaaaaaaaaaaaaaa
adaaaaaaajaaaaaaahahaaaabmabaaaaafaaaaaaaaaaaaaaadaaaaaaakaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmaajaaaaeaaaaaaa
haacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafkaaaaad
aagabaaaagaaaaaafkaaaaadaagabaaaahaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaafibiaaaeaahabaaaagaaaaaa
ffffaaaafibiaaaeaahabaaaahaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadlcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadpcbabaaaagaaaaaagcbaaaad
pcbabaaaahaaaaaagcbaaaadhcbabaaaaiaaaaaagcbaaaadhcbabaaaajaaaaaa
gcbaaaadhcbabaaaakaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaajaaaaaaegbcbaaaajaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakbabaaaajaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaacjfmipdndcaaaaakpcaabaaaaaaaaaaaagaabaaaaaaaaaaakgikcaaa
aaaaaaaaaiaaaaaaegbobaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaa
aaaaaaaaeghobaaaaeaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaaiccaabaaa
aaaaaaaadkaabaaaabaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaagaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaaaaaaaaai
hcaabaaaacaaaaaaagaabaiaebaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaam
ncaabaaaaaaaaaaaagajbaaaacaaaaaaaceaaaaamnmmemdoaaaaaaaamnmmemdo
mnmmemdoagaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaa
acaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaabaaaaaaegaabaaaacaaaaaa
egaabaaaacaaaaaaddaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaacaaaaaadkaabaaaabaaaaaaaaaaaaaihcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegbcbaaaaiaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaeaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaadaaaaaaegbcbaaaadaaaaaaegacbaaaacaaaaaabaaaaaah
ccaabaaaadaaaaaaegbcbaaaaeaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
adaaaaaaegbcbaaaafaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egbcbaaaajaaaaaaegacbaaaadaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaadkaabaaaabaaaaaadcaaaaakhcaabaaaacaaaaaaegacbaaaadaaaaaa
pgapbaiaebaaaaaaabaaaaaaegbcbaaaajaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahdcaabaaaacaaaaaapgapbaaaabaaaaaaegaabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
aeaaaaaadcaaaaakncaabaaaaaaaaaaaagiacaaaaaaaaaaaajaaaaaaagajbaaa
acaaaaaaagaobaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaigadbaiaebaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaajhcaabaaaaaaaaaaafgafbaaaaaaaaaaa
egacbaaaabaaaaaaigadbaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaia
ebaaaaaaaaaaaaaaegacbaaaaeaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaa
aeaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaahaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadcaaaaalhcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaaegacbaiaebaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaadiaaaaalhcaabaaaadaaaaaaegiccaaa
aaaaaaaaahaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaaifcaabaaaadaaaaaapgapbaaaaaaaaaaa
agiccaaaaaaaaaaaahaaaaaadiaaaaajccaabaaaadaaaaaadkaabaaaaaaaaaaa
bkiacaiaebaaaaaaaaaaaaaaahaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaadpabeaaaaaaaaaaadpdicaaaaiicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakiacaaaaaaaaaaaaiaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaahaaaaaa
eghobaaaagaaaaaaaagabaaaagaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
acaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaahaaaaaaaagabaaaahaaaaaacpaaaaafpcaabaaaabaaaaaa
egaobaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaiaebaaaaaaabaaaaaa
egbcbaaaakaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaeaaaaaa
abeaaaaaaaaaiadpdiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaia
ebaaaaaaabaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
acaaaaaadiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkiacaaaaaaaaaaa
acaaaaaadcaaaaakiccabaaaaaaaaaaadkaabaaaaeaaaaaadkiacaaaaaaaaaaa
adaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaaeaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..8],
		{ 2, 1, 0.5, 0.07 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R0.xy, R0.wyzw, c[9].x, -c[9].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[9].y;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
TEX R1, fragment.texcoord[0], texture[0], 2D;
ADD R2.xyz, fragment.texcoord[7], -R0;
MAD R2.xyz, R1.w, R2, R0;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R0.x, R0, fragment.color.primary;
MUL R0.x, R0, c[6];
MUL R2.w, R0.x, c[9];
DP3 R0.y, fragment.texcoord[2], R2;
DP3 R0.w, R2, fragment.texcoord[4];
DP3 R0.z, R2, fragment.texcoord[3];
DP3 R2.x, fragment.color.primary, R0.yzww;
MUL R2.xyz, R0.yzww, R2.x;
MAD R2.xyz, -R2, c[9].x, fragment.color.primary;
DP3 R2.z, R2, R2;
RSQ R2.z, R2.z;
MUL R3.xy, R2.z, R2;
ADD R2.xy, R2.w, fragment.texcoord[6];
TEX R0.x, R2, texture[4], 2D;
TEX R3.xyz, R3, texture[2], 2D;
TEX R2.xyz, fragment.texcoord[6], texture[4], 2D;
ADD R2.xyz, R2, -R0.x;
MAD R2.xyz, R2, c[10].x, R0.x;
MUL R3.xyz, R3, c[8].x;
ADD R3.xyz, R2, R3;
ADD R4.xy, R2.w, fragment.texcoord[6].zwzw;
TEX R2, R4, texture[3], 2D;
ADD R2.xyz, R2, -R3;
MUL R0.x, R2.w, c[7];
MAD R2.xyz, R0.x, R2, R3;
ADD R1.xyz, R1, -R2;
MAD R1.xyz, R1.w, R1, R2;
MOV R2.x, R0.y;
MOV R2.y, R0.z;
MOV R2.z, R0.w;
DP3 R2.w, R2, R2;
RSQ R2.w, R2.w;
MUL R2.xyz, R2.w, R2;
MOV R0.xz, c[4];
MOV R0.y, -c[4];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, R2;
TEX R0.xyz, fragment.color.secondary, texture[5], 2D;
MAD R0.w, R0, c[9].z, c[9].z;
MUL R0.xyz, R0, c[3];
MAD R0.xyz, -R1, c[1], R0;
MUL_SAT R0.w, R0, c[5].x;
ADD R0.w, -R0, c[9].y;
MUL R2.xyz, R0.w, R0;
TXP R0, fragment.texcoord[1], texture[7], 2D;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R3.xyz, -R0, fragment.texcoord[5];
LG2 R0.x, R0.w;
ADD R0.y, -R1.w, c[9];
MUL R2.w, -R0.x, R0.y;
MUL R0.xyz, R3, c[0];
MUL R0.yzw, R0.xxyz, R2.w;
TEX R0.x, fragment.color.secondary.zwzw, texture[6], 2D;
MUL R1.xyz, R1, c[1];
MAD R1.xyz, R0.x, R2, R1;
MAD R0.xyz, R1, R3, R0.yzww;
MUL R0.w, R2, c[0];
MAD result.color.xyz, R1, c[2], R0;
MAD result.color.w, R1, c[1], R0;
END
# 75 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c9, 2.00000000, -1.00000000, 1.00000000, 0.50000000
def c10, 0.07000000, 0.20000000, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord6 v5
dcl_color1 v6
dcl_texcoord7 v7.xyz
dcl_color0 v8.xyz
dcl_texcoord5 v9.xyz
texld r0.yw, v0.zwzw, s1
mad_pp r0.xy, r0.wyzw, c9.x, c9.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r0.z, -r0, c9
rsq_pp r0.z, r0.z
rcp_pp r0.z, r0.z
texld r1, v0, s0
add_pp r2.xyz, v7, -r0
mad_pp r2.xyz, r1.w, r2, r0
dp3 r0.x, v8, v8
rsq r0.x, r0.x
mul r0.x, r0, v8
mul r0.x, r0, c6
mul r2.w, r0.x, c10.x
dp3_pp r0.y, v2, r2
dp3_pp r0.w, r2, v4
dp3_pp r0.z, r2, v3
dp3 r2.x, v8, r0.yzww
mul r2.xyz, r0.yzww, r2.x
mad r2.xyz, -r2, c9.x, v8
dp3 r2.z, r2, r2
rsq r2.z, r2.z
mul r3.xy, r2.z, r2
add_pp r2.xy, r2.w, v5
texld r0.x, r2, s4
texld r3.xyz, r3, s2
texld r2.xyz, v5, s4
add r2.xyz, r2, -r0.x
mad r2.xyz, r2, c10.y, r0.x
mul r3.xyz, r3, c8.x
add_pp r3.xyz, r2, r3
add r4.xy, r2.w, v5.zwzw
texld r2, r4, s3
add_pp r2.xyz, r2, -r3
mul_pp r0.x, r2.w, c7
mad_pp r2.xyz, r0.x, r2, r3
add_pp r1.xyz, r1, -r2
mad_pp r1.xyz, r1.w, r1, r2
mov r2.x, r0.y
mov r2.y, r0.z
mov r2.z, r0.w
dp3 r2.w, r2, r2
rsq r2.w, r2.w
mov r0.xz, c4
mov r0.y, -c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
mul r2.xyz, r2.w, r2
dp3 r0.w, r0, r2
texld r0.xyz, v6, s5
mad r0.w, r0, c9, c9
mul r0.xyz, r0, c3
mad_pp r0.xyz, -r1, c1, r0
mul_sat r0.w, r0, c5.x
add r0.w, -r0, c9.z
mul_pp r2.xyz, r0.w, r0
texldp r0, v1, s7
mul_pp r1.xyz, r1, c1
log_pp r0.x, r0.x
log_pp r0.z, r0.z
log_pp r0.y, r0.y
add_pp r3.xyz, -r0, v9
log_pp r0.x, r0.w
add r0.y, -r1.w, c9.z
mul_pp r0.w, -r0.x, r0.y
mul_pp r0.xyz, r3, c0
mul_pp r4.xyz, r0, r0.w
texld r0.x, v6.zwzw, s6
mad_pp r0.xyz, r0.x, r2, r1
mad_pp r1.xyz, r0, r3, r4
mul_pp r0.w, r0, c0
mad_pp oC0.xyz, r0, c2, r1
mad_pp oC0.w, r1, c1, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LakerTex] 2D 3
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_RefTex] 2D 4
SetTexture 4 [_MainTex1] 2D 1
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
ConstBuffer "$Globals" 288
Vector 32 [_SpecColor]
Vector 48 [_Color]
Vector 64 [_EmissiveColor]
Vector 96 [_SnowColor]
Vector 112 [_SnowDirection]
Float 128 [_SnowRange]
Float 136 [_Parallax]
Float 140 [_DownBlend]
Float 144 [_RefPara]
BindCB  "$Globals" 0
"ps_4_0
eefiecedbhidemnkeiikgckedpcdgbflafiklfdfabaaaaaafmalaaaaadaaaaaa
cmaaaaaagaabaaaajeabaaaaejfdeheocmabaaaaalaaaaaaaiaaaaaabaabaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaabmabaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apalaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaabmabaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapahaaaabmabaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapahaaaabmabaaaaagaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaabmabaaaa
ahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahahaaaacfabaaaaaaaaaaaaaaaaaaaa
adaaaaaaajaaaaaaahahaaaabmabaaaaafaaaaaaaaaaaaaaadaaaaaaakaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmaajaaaaeaaaaaaa
haacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafkaaaaad
aagabaaaagaaaaaafkaaaaadaagabaaaahaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaafibiaaaeaahabaaaagaaaaaa
ffffaaaafibiaaaeaahabaaaahaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadlcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadpcbabaaaagaaaaaagcbaaaad
pcbabaaaahaaaaaagcbaaaadhcbabaaaaiaaaaaagcbaaaadhcbabaaaajaaaaaa
gcbaaaadhcbabaaaakaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaajaaaaaaegbcbaaaajaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakbabaaaajaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaacjfmipdndcaaaaakpcaabaaaaaaaaaaaagaabaaaaaaaaaaakgikcaaa
aaaaaaaaaiaaaaaaegbobaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaa
aaaaaaaaeghobaaaaeaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaaiccaabaaa
aaaaaaaadkaabaaaabaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaagaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaaaaaaaaai
hcaabaaaacaaaaaaagaabaiaebaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaam
ncaabaaaaaaaaaaaagajbaaaacaaaaaaaceaaaaamnmmemdoaaaaaaaamnmmemdo
mnmmemdoagaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaa
acaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaabaaaaaaegaabaaaacaaaaaa
egaabaaaacaaaaaaddaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaacaaaaaadkaabaaaabaaaaaaaaaaaaaihcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegbcbaaaaiaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaeaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaadaaaaaaegbcbaaaadaaaaaaegacbaaaacaaaaaabaaaaaah
ccaabaaaadaaaaaaegbcbaaaaeaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
adaaaaaaegbcbaaaafaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egbcbaaaajaaaaaaegacbaaaadaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaadkaabaaaabaaaaaadcaaaaakhcaabaaaacaaaaaaegacbaaaadaaaaaa
pgapbaiaebaaaaaaabaaaaaaegbcbaaaajaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahdcaabaaaacaaaaaapgapbaaaabaaaaaaegaabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
aeaaaaaadcaaaaakncaabaaaaaaaaaaaagiacaaaaaaaaaaaajaaaaaaagajbaaa
acaaaaaaagaobaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaigadbaiaebaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaajhcaabaaaaaaaaaaafgafbaaaaaaaaaaa
egacbaaaabaaaaaaigadbaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaia
ebaaaaaaaaaaaaaaegacbaaaaeaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaa
aeaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaahaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadcaaaaalhcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaaegacbaiaebaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaadiaaaaalhcaabaaaadaaaaaaegiccaaa
aaaaaaaaahaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaaifcaabaaaadaaaaaapgapbaaaaaaaaaaa
agiccaaaaaaaaaaaahaaaaaadiaaaaajccaabaaaadaaaaaadkaabaaaaaaaaaaa
bkiacaiaebaaaaaaaaaaaaaaahaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaadpabeaaaaaaaaaaadpdicaaaaiicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakiacaaaaaaaaaaaaiaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaahaaaaaa
eghobaaaagaaaaaaaagabaaaagaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
acaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaahaaaaaaaagabaaaahaaaaaacpaaaaafpcaabaaaabaaaaaa
egaobaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaiaebaaaaaaabaaaaaa
egbcbaaaakaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaeaaaaaa
abeaaaaaaaaaiadpdiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaia
ebaaaaaaabaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegacbaaa
acaaaaaadiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkiacaaaaaaaaaaa
acaaaaaadcaaaaakiccabaaaaaaaaaaadkaabaaaaeaaaaaadkiacaaaaaaaaaaa
adaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaaeaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..8],
		{ 2, 1, 0.5, 0.07 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R0.xy, R0.wyzw, c[9].x, -c[9].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[9].y;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
TEX R1, fragment.texcoord[0], texture[0], 2D;
ADD R2.xyz, fragment.texcoord[7], -R0;
MAD R2.xyz, R1.w, R2, R0;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R0.x, R0, fragment.color.primary;
MUL R0.x, R0, c[6];
MUL R2.w, R0.x, c[9];
DP3 R0.y, fragment.texcoord[2], R2;
DP3 R0.w, R2, fragment.texcoord[4];
DP3 R0.z, R2, fragment.texcoord[3];
DP3 R2.x, fragment.color.primary, R0.yzww;
MUL R2.xyz, R0.yzww, R2.x;
MAD R2.xyz, -R2, c[9].x, fragment.color.primary;
DP3 R2.z, R2, R2;
RSQ R2.z, R2.z;
MUL R3.xy, R2.z, R2;
ADD R2.xy, R2.w, fragment.texcoord[6];
TEX R0.x, R2, texture[4], 2D;
TEX R3.xyz, R3, texture[2], 2D;
TEX R2.xyz, fragment.texcoord[6], texture[4], 2D;
ADD R2.xyz, R2, -R0.x;
MAD R2.xyz, R2, c[10].x, R0.x;
MUL R3.xyz, R3, c[8].x;
ADD R3.xyz, R2, R3;
ADD R4.xy, R2.w, fragment.texcoord[6].zwzw;
TEX R2, R4, texture[3], 2D;
ADD R2.xyz, R2, -R3;
MUL R0.x, R2.w, c[7];
MAD R2.xyz, R0.x, R2, R3;
ADD R1.xyz, R1, -R2;
MAD R2.xyz, R1.w, R1, R2;
MOV R1.x, R0.y;
MOV R1.y, R0.z;
MOV R1.z, R0.w;
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
MOV R0.xz, c[4];
MOV R0.y, -c[4];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, R1;
TEX R0.xyz, fragment.color.secondary, texture[5], 2D;
MAD R0.w, R0, c[9].z, c[9].z;
MUL R0.xyz, R0, c[3];
MAD R0.xyz, -R2, c[1], R0;
MUL_SAT R0.w, R0, c[5].x;
ADD R0.w, -R0, c[9].y;
MUL R1.xyz, R0.w, R0;
TXP R0, fragment.texcoord[1], texture[7], 2D;
ADD R3.xyz, R0, fragment.texcoord[5];
ADD R2.w, -R1, c[9].y;
MUL R2.w, R0, R2;
MUL R0.xyz, R3, c[0];
MUL R0.yzw, R0.xxyz, R2.w;
TEX R0.x, fragment.color.secondary.zwzw, texture[6], 2D;
MUL R2.xyz, R2, c[1];
MAD R1.xyz, R0.x, R1, R2;
MAD R0.xyz, R1, R3, R0.yzww;
MUL R0.w, R2, c[0];
MAD result.color.xyz, R1, c[2], R0;
MAD result.color.w, R1, c[1], R0;
END
# 71 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c9, 2.00000000, -1.00000000, 1.00000000, 0.50000000
def c10, 0.07000000, 0.20000000, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord6 v5
dcl_color1 v6
dcl_texcoord7 v7.xyz
dcl_color0 v8.xyz
dcl_texcoord5 v9.xyz
texld r0.yw, v0.zwzw, s1
mad_pp r0.xy, r0.wyzw, c9.x, c9.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r0.z, -r0, c9
rsq_pp r0.z, r0.z
rcp_pp r0.z, r0.z
texld r1, v0, s0
add_pp r2.xyz, v7, -r0
mad_pp r2.xyz, r1.w, r2, r0
dp3 r0.x, v8, v8
rsq r0.x, r0.x
mul r0.x, r0, v8
mul r0.x, r0, c6
mul r2.w, r0.x, c10.x
dp3_pp r0.y, v2, r2
dp3_pp r0.w, r2, v4
dp3_pp r0.z, r2, v3
dp3 r2.x, v8, r0.yzww
mul r2.xyz, r0.yzww, r2.x
mad r2.xyz, -r2, c9.x, v8
dp3 r2.z, r2, r2
rsq r2.z, r2.z
mul r3.xy, r2.z, r2
add_pp r2.xy, r2.w, v5
texld r0.x, r2, s4
texld r3.xyz, r3, s2
texld r2.xyz, v5, s4
add r2.xyz, r2, -r0.x
mad r2.xyz, r2, c10.y, r0.x
mul r3.xyz, r3, c8.x
add_pp r3.xyz, r2, r3
add r4.xy, r2.w, v5.zwzw
texld r2, r4, s3
add_pp r2.xyz, r2, -r3
mul_pp r0.x, r2.w, c7
mad_pp r2.xyz, r0.x, r2, r3
add_pp r1.xyz, r1, -r2
mad_pp r2.xyz, r1.w, r1, r2
mov r1.x, r0.y
mov r1.y, r0.z
mov r1.z, r0.w
dp3 r2.w, r1, r1
rsq r2.w, r2.w
mul r1.xyz, r2.w, r1
mov r0.xz, c4
mov r0.y, -c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, r1
texld r0.xyz, v6, s5
mad r0.w, r0, c9, c9
mul r0.xyz, r0, c3
mad_pp r0.xyz, -r2, c1, r0
mul_sat r0.w, r0, c5.x
add r0.w, -r0, c9.z
mul_pp r1.xyz, r0.w, r0
texldp r0, v1, s7
add_pp r3.xyz, r0, v9
add r2.w, -r1, c9.z
mul_pp r0.xyz, r3, c0
mul_pp r0.w, r0, r2
mul_pp r4.xyz, r0, r0.w
mul_pp r0.w, r0, c0
mul_pp r2.xyz, r2, c1
texld r0.x, v6.zwzw, s6
mad_pp r0.xyz, r0.x, r1, r2
mad_pp r1.xyz, r0, r3, r4
mad_pp oC0.xyz, r0, c2, r1
mad_pp oC0.w, r1, c1, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LakerTex] 2D 3
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_RefTex] 2D 4
SetTexture 4 [_MainTex1] 2D 1
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
ConstBuffer "$Globals" 272
Vector 32 [_SpecColor]
Vector 48 [_Color]
Vector 64 [_EmissiveColor]
Vector 96 [_SnowColor]
Vector 112 [_SnowDirection]
Float 128 [_SnowRange]
Float 136 [_Parallax]
Float 140 [_DownBlend]
Float 144 [_RefPara]
BindCB  "$Globals" 0
"ps_4_0
eefiecedcjkgfnnhkiggognhknkipccieafdgaehabaaaaaaeaalaaaaadaaaaaa
cmaaaaaagaabaaaajeabaaaaejfdeheocmabaaaaalaaaaaaaiaaaaaabaabaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaabmabaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apalaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaabmabaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapahaaaabmabaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapahaaaabmabaaaaagaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaabmabaaaa
ahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahahaaaacfabaaaaaaaaaaaaaaaaaaaa
adaaaaaaajaaaaaaahahaaaabmabaaaaafaaaaaaaaaaaaaaadaaaaaaakaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckeajaaaaeaaaaaaa
gjacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafkaaaaad
aagabaaaagaaaaaafkaaaaadaagabaaaahaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaafibiaaaeaahabaaaagaaaaaa
ffffaaaafibiaaaeaahabaaaahaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadlcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadpcbabaaaagaaaaaagcbaaaad
pcbabaaaahaaaaaagcbaaaadhcbabaaaaiaaaaaagcbaaaadhcbabaaaajaaaaaa
gcbaaaadhcbabaaaakaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaajaaaaaaegbcbaaaajaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakbabaaaajaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaacjfmipdndcaaaaakpcaabaaaaaaaaaaaagaabaaaaaaaaaaakgikcaaa
aaaaaaaaaiaaaaaaegbobaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaa
aaaaaaaaeghobaaaaeaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaaiccaabaaa
aaaaaaaadkaabaaaabaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaagaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaaaaaaaaai
hcaabaaaacaaaaaaagaabaiaebaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaam
ncaabaaaaaaaaaaaagajbaaaacaaaaaaaceaaaaamnmmemdoaaaaaaaamnmmemdo
mnmmemdoagaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaa
acaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaabaaaaaaegaabaaaacaaaaaa
egaabaaaacaaaaaaddaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaacaaaaaadkaabaaaabaaaaaaaaaaaaaihcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegbcbaaaaiaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaeaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaadaaaaaaegbcbaaaadaaaaaaegacbaaaacaaaaaabaaaaaah
ccaabaaaadaaaaaaegbcbaaaaeaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
adaaaaaaegbcbaaaafaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egbcbaaaajaaaaaaegacbaaaadaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaadkaabaaaabaaaaaadcaaaaakhcaabaaaacaaaaaaegacbaaaadaaaaaa
pgapbaiaebaaaaaaabaaaaaaegbcbaaaajaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahdcaabaaaacaaaaaapgapbaaaabaaaaaaegaabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
aeaaaaaadcaaaaakncaabaaaaaaaaaaaagiacaaaaaaaaaaaajaaaaaaagajbaaa
acaaaaaaagaobaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaigadbaiaebaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaajhcaabaaaaaaaaaaafgafbaaaaaaaaaaa
egacbaaaabaaaaaaigadbaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaia
ebaaaaaaaaaaaaaaegacbaaaaeaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaa
aeaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaahaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadcaaaaalhcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaaegacbaiaebaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaadiaaaaalhcaabaaaadaaaaaaegiccaaa
aaaaaaaaahaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaaifcaabaaaadaaaaaapgapbaaaaaaaaaaa
agiccaaaaaaaaaaaahaaaaaadiaaaaajccaabaaaadaaaaaadkaabaaaaaaaaaaa
bkiacaiaebaaaaaaaaaaaaaaahaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaadpabeaaaaaaaaaaadpdicaaaaiicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakiacaaaaaaaaaaaaiaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaahaaaaaa
eghobaaaagaaaaaaaagabaaaagaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
acaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaahaaaaaaaagabaaaahaaaaaaaaaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaaegbcbaaaakaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaeaaaaaaabeaaaaaaaaaiadpdiaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaaabaaaaaa
egiccaaaaaaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaa
egacbaaaacaaaaaadiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkiacaaa
aaaaaaaaacaaaaaadcaaaaakiccabaaaaaaaaaaadkaabaaaaeaaaaaadkiacaaa
aaaaaaaaadaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadcaaaaakhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..8],
		{ 2, 1, 0.5, 0.07 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R0.xy, R0.wyzw, c[9].x, -c[9].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[9].y;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
TEX R1, fragment.texcoord[0], texture[0], 2D;
ADD R2.xyz, fragment.texcoord[7], -R0;
MAD R2.xyz, R1.w, R2, R0;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R0.x, R0, fragment.color.primary;
MUL R0.x, R0, c[6];
MUL R2.w, R0.x, c[9];
DP3 R0.y, fragment.texcoord[2], R2;
DP3 R0.w, R2, fragment.texcoord[4];
DP3 R0.z, R2, fragment.texcoord[3];
DP3 R2.x, fragment.color.primary, R0.yzww;
MUL R2.xyz, R0.yzww, R2.x;
MAD R2.xyz, -R2, c[9].x, fragment.color.primary;
DP3 R2.z, R2, R2;
RSQ R2.z, R2.z;
MUL R3.xy, R2.z, R2;
ADD R2.xy, R2.w, fragment.texcoord[6];
TEX R0.x, R2, texture[4], 2D;
TEX R3.xyz, R3, texture[2], 2D;
TEX R2.xyz, fragment.texcoord[6], texture[4], 2D;
ADD R2.xyz, R2, -R0.x;
MAD R2.xyz, R2, c[10].x, R0.x;
MUL R3.xyz, R3, c[8].x;
ADD R3.xyz, R2, R3;
ADD R4.xy, R2.w, fragment.texcoord[6].zwzw;
TEX R2, R4, texture[3], 2D;
ADD R2.xyz, R2, -R3;
MUL R0.x, R2.w, c[7];
MAD R2.xyz, R0.x, R2, R3;
ADD R1.xyz, R1, -R2;
MAD R2.xyz, R1.w, R1, R2;
MOV R1.x, R0.y;
MOV R1.y, R0.z;
MOV R1.z, R0.w;
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
MOV R0.xz, c[4];
MOV R0.y, -c[4];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, R1;
TEX R0.xyz, fragment.color.secondary, texture[5], 2D;
MAD R0.w, R0, c[9].z, c[9].z;
MUL R0.xyz, R0, c[3];
MAD R0.xyz, -R2, c[1], R0;
MUL_SAT R0.w, R0, c[5].x;
ADD R0.w, -R0, c[9].y;
MUL R1.xyz, R0.w, R0;
TXP R0, fragment.texcoord[1], texture[7], 2D;
ADD R3.xyz, R0, fragment.texcoord[5];
ADD R2.w, -R1, c[9].y;
MUL R2.w, R0, R2;
MUL R0.xyz, R3, c[0];
MUL R0.yzw, R0.xxyz, R2.w;
TEX R0.x, fragment.color.secondary.zwzw, texture[6], 2D;
MUL R2.xyz, R2, c[1];
MAD R1.xyz, R0.x, R1, R2;
MAD R0.xyz, R1, R3, R0.yzww;
MUL R0.w, R2, c[0];
MAD result.color.xyz, R1, c[2], R0;
MAD result.color.w, R1, c[1], R0;
END
# 71 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c9, 2.00000000, -1.00000000, 1.00000000, 0.50000000
def c10, 0.07000000, 0.20000000, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord6 v5
dcl_color1 v6
dcl_texcoord7 v7.xyz
dcl_color0 v8.xyz
dcl_texcoord5 v9.xyz
texld r0.yw, v0.zwzw, s1
mad_pp r0.xy, r0.wyzw, c9.x, c9.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r0.z, -r0, c9
rsq_pp r0.z, r0.z
rcp_pp r0.z, r0.z
texld r1, v0, s0
add_pp r2.xyz, v7, -r0
mad_pp r2.xyz, r1.w, r2, r0
dp3 r0.x, v8, v8
rsq r0.x, r0.x
mul r0.x, r0, v8
mul r0.x, r0, c6
mul r2.w, r0.x, c10.x
dp3_pp r0.y, v2, r2
dp3_pp r0.w, r2, v4
dp3_pp r0.z, r2, v3
dp3 r2.x, v8, r0.yzww
mul r2.xyz, r0.yzww, r2.x
mad r2.xyz, -r2, c9.x, v8
dp3 r2.z, r2, r2
rsq r2.z, r2.z
mul r3.xy, r2.z, r2
add_pp r2.xy, r2.w, v5
texld r0.x, r2, s4
texld r3.xyz, r3, s2
texld r2.xyz, v5, s4
add r2.xyz, r2, -r0.x
mad r2.xyz, r2, c10.y, r0.x
mul r3.xyz, r3, c8.x
add_pp r3.xyz, r2, r3
add r4.xy, r2.w, v5.zwzw
texld r2, r4, s3
add_pp r2.xyz, r2, -r3
mul_pp r0.x, r2.w, c7
mad_pp r2.xyz, r0.x, r2, r3
add_pp r1.xyz, r1, -r2
mad_pp r2.xyz, r1.w, r1, r2
mov r1.x, r0.y
mov r1.y, r0.z
mov r1.z, r0.w
dp3 r2.w, r1, r1
rsq r2.w, r2.w
mul r1.xyz, r2.w, r1
mov r0.xz, c4
mov r0.y, -c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, r1
texld r0.xyz, v6, s5
mad r0.w, r0, c9, c9
mul r0.xyz, r0, c3
mad_pp r0.xyz, -r2, c1, r0
mul_sat r0.w, r0, c5.x
add r0.w, -r0, c9.z
mul_pp r1.xyz, r0.w, r0
texldp r0, v1, s7
add_pp r3.xyz, r0, v9
add r2.w, -r1, c9.z
mul_pp r0.xyz, r3, c0
mul_pp r0.w, r0, r2
mul_pp r4.xyz, r0, r0.w
mul_pp r0.w, r0, c0
mul_pp r2.xyz, r2, c1
texld r0.x, v6.zwzw, s6
mad_pp r0.xyz, r0.x, r1, r2
mad_pp r1.xyz, r0, r3, r4
mad_pp oC0.xyz, r0, c2, r1
mad_pp oC0.w, r1, c1, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LakerTex] 2D 3
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_RefTex] 2D 4
SetTexture 4 [_MainTex1] 2D 1
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
ConstBuffer "$Globals" 288
Vector 32 [_SpecColor]
Vector 48 [_Color]
Vector 64 [_EmissiveColor]
Vector 96 [_SnowColor]
Vector 112 [_SnowDirection]
Float 128 [_SnowRange]
Float 136 [_Parallax]
Float 140 [_DownBlend]
Float 144 [_RefPara]
BindCB  "$Globals" 0
"ps_4_0
eefiecedcjkgfnnhkiggognhknkipccieafdgaehabaaaaaaeaalaaaaadaaaaaa
cmaaaaaagaabaaaajeabaaaaejfdeheocmabaaaaalaaaaaaaiaaaaaabaabaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaabmabaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apalaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaabmabaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapahaaaabmabaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapahaaaabmabaaaaagaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaabmabaaaa
ahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahahaaaacfabaaaaaaaaaaaaaaaaaaaa
adaaaaaaajaaaaaaahahaaaabmabaaaaafaaaaaaaaaaaaaaadaaaaaaakaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckeajaaaaeaaaaaaa
gjacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafkaaaaad
aagabaaaagaaaaaafkaaaaadaagabaaaahaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaafibiaaaeaahabaaaagaaaaaa
ffffaaaafibiaaaeaahabaaaahaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadlcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadpcbabaaaagaaaaaagcbaaaad
pcbabaaaahaaaaaagcbaaaadhcbabaaaaiaaaaaagcbaaaadhcbabaaaajaaaaaa
gcbaaaadhcbabaaaakaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaajaaaaaaegbcbaaaajaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakbabaaaajaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaacjfmipdndcaaaaakpcaabaaaaaaaaaaaagaabaaaaaaaaaaakgikcaaa
aaaaaaaaaiaaaaaaegbobaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaa
aaaaaaaaeghobaaaaeaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaaiccaabaaa
aaaaaaaadkaabaaaabaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaagaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaaaaaaaaai
hcaabaaaacaaaaaaagaabaiaebaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaam
ncaabaaaaaaaaaaaagajbaaaacaaaaaaaceaaaaamnmmemdoaaaaaaaamnmmemdo
mnmmemdoagaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaa
acaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaabaaaaaaegaabaaaacaaaaaa
egaabaaaacaaaaaaddaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaacaaaaaadkaabaaaabaaaaaaaaaaaaaihcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegbcbaaaaiaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaeaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaadaaaaaaegbcbaaaadaaaaaaegacbaaaacaaaaaabaaaaaah
ccaabaaaadaaaaaaegbcbaaaaeaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
adaaaaaaegbcbaaaafaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egbcbaaaajaaaaaaegacbaaaadaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaadkaabaaaabaaaaaadcaaaaakhcaabaaaacaaaaaaegacbaaaadaaaaaa
pgapbaiaebaaaaaaabaaaaaaegbcbaaaajaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahdcaabaaaacaaaaaapgapbaaaabaaaaaaegaabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
aeaaaaaadcaaaaakncaabaaaaaaaaaaaagiacaaaaaaaaaaaajaaaaaaagajbaaa
acaaaaaaagaobaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaigadbaiaebaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaajhcaabaaaaaaaaaaafgafbaaaaaaaaaaa
egacbaaaabaaaaaaigadbaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaia
ebaaaaaaaaaaaaaaegacbaaaaeaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaa
aeaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaahaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadcaaaaalhcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaaegacbaiaebaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaadiaaaaalhcaabaaaadaaaaaaegiccaaa
aaaaaaaaahaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaaifcaabaaaadaaaaaapgapbaaaaaaaaaaa
agiccaaaaaaaaaaaahaaaaaadiaaaaajccaabaaaadaaaaaadkaabaaaaaaaaaaa
bkiacaiaebaaaaaaaaaaaaaaahaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaadpabeaaaaaaaaaaadpdicaaaaiicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakiacaaaaaaaaaaaaiaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaahaaaaaa
eghobaaaagaaaaaaaagabaaaagaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
acaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaahaaaaaaaagabaaaahaaaaaaaaaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaaegbcbaaaakaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaeaaaaaaabeaaaaaaaaaiadpdiaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaaabaaaaaa
egiccaaaaaaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaa
egacbaaaacaaaaaadiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkiacaaa
aaaaaaaaacaaaaaadcaaaaakiccabaaaaaaaaaaadkaabaaaaeaaaaaadkiacaaa
aaaaaaaaadaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadcaaaaakhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"3.0-!!ARBfp1.0
PARAM c[11] = { program.local[0..8],
		{ 2, 1, 0.5, 0.07 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R0.xy, R0.wyzw, c[9].x, -c[9].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R0.z, -R0, c[9].y;
RSQ R0.z, R0.z;
RCP R0.z, R0.z;
TEX R1, fragment.texcoord[0], texture[0], 2D;
ADD R2.xyz, fragment.texcoord[7], -R0;
MAD R2.xyz, R1.w, R2, R0;
DP3 R0.x, fragment.color.primary, fragment.color.primary;
RSQ R0.x, R0.x;
MUL R0.x, R0, fragment.color.primary;
MUL R0.x, R0, c[6];
MUL R2.w, R0.x, c[9];
DP3 R0.y, fragment.texcoord[2], R2;
DP3 R0.w, R2, fragment.texcoord[4];
DP3 R0.z, R2, fragment.texcoord[3];
DP3 R2.x, fragment.color.primary, R0.yzww;
MUL R2.xyz, R0.yzww, R2.x;
MAD R2.xyz, -R2, c[9].x, fragment.color.primary;
DP3 R2.z, R2, R2;
RSQ R2.z, R2.z;
MUL R3.xy, R2.z, R2;
ADD R2.xy, R2.w, fragment.texcoord[6];
TEX R0.x, R2, texture[4], 2D;
TEX R3.xyz, R3, texture[2], 2D;
TEX R2.xyz, fragment.texcoord[6], texture[4], 2D;
ADD R2.xyz, R2, -R0.x;
MAD R2.xyz, R2, c[10].x, R0.x;
MUL R3.xyz, R3, c[8].x;
ADD R3.xyz, R2, R3;
ADD R4.xy, R2.w, fragment.texcoord[6].zwzw;
TEX R2, R4, texture[3], 2D;
ADD R2.xyz, R2, -R3;
MUL R0.x, R2.w, c[7];
MAD R2.xyz, R0.x, R2, R3;
ADD R1.xyz, R1, -R2;
MAD R2.xyz, R1.w, R1, R2;
MOV R1.x, R0.y;
MOV R1.y, R0.z;
MOV R1.z, R0.w;
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
MOV R0.xz, c[4];
MOV R0.y, -c[4];
DP3 R0.w, R0, R0;
RSQ R0.w, R0.w;
MUL R0.xyz, R0.w, R0;
DP3 R0.w, R0, R1;
TEX R0.xyz, fragment.color.secondary, texture[5], 2D;
MAD R0.w, R0, c[9].z, c[9].z;
MUL R0.xyz, R0, c[3];
MAD R0.xyz, -R2, c[1], R0;
MUL_SAT R0.w, R0, c[5].x;
ADD R0.w, -R0, c[9].y;
MUL R1.xyz, R0.w, R0;
TXP R0, fragment.texcoord[1], texture[7], 2D;
ADD R3.xyz, R0, fragment.texcoord[5];
ADD R2.w, -R1, c[9].y;
MUL R2.w, R0, R2;
MUL R0.xyz, R3, c[0];
MUL R0.yzw, R0.xxyz, R2.w;
TEX R0.x, fragment.color.secondary.zwzw, texture[6], 2D;
MUL R2.xyz, R2, c[1];
MAD R1.xyz, R0.x, R1, R2;
MAD R0.xyz, R1, R3, R0.yzww;
MUL R0.w, R2, c[0];
MAD result.color.xyz, R1, c[2], R0;
MAD result.color.w, R1, c[1], R0;
END
# 71 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_SpecColor]
Vector 1 [_Color]
Vector 2 [_EmissiveColor]
Vector 3 [_SnowColor]
Vector 4 [_SnowDirection]
Float 5 [_SnowRange]
Float 6 [_Parallax]
Float 7 [_DownBlend]
Float 8 [_RefPara]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_RefTex] 2D 2
SetTexture 3 [_MainTex1] 2D 3
SetTexture 4 [_LakerTex] 2D 4
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_2d s6
dcl_2d s7
def c9, 2.00000000, -1.00000000, 1.00000000, 0.50000000
def c10, 0.07000000, 0.20000000, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
dcl_texcoord4 v4.xyz
dcl_texcoord6 v5
dcl_color1 v6
dcl_texcoord7 v7.xyz
dcl_color0 v8.xyz
dcl_texcoord5 v9.xyz
texld r0.yw, v0.zwzw, s1
mad_pp r0.xy, r0.wyzw, c9.x, c9.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r0.z, -r0, c9
rsq_pp r0.z, r0.z
rcp_pp r0.z, r0.z
texld r1, v0, s0
add_pp r2.xyz, v7, -r0
mad_pp r2.xyz, r1.w, r2, r0
dp3 r0.x, v8, v8
rsq r0.x, r0.x
mul r0.x, r0, v8
mul r0.x, r0, c6
mul r2.w, r0.x, c10.x
dp3_pp r0.y, v2, r2
dp3_pp r0.w, r2, v4
dp3_pp r0.z, r2, v3
dp3 r2.x, v8, r0.yzww
mul r2.xyz, r0.yzww, r2.x
mad r2.xyz, -r2, c9.x, v8
dp3 r2.z, r2, r2
rsq r2.z, r2.z
mul r3.xy, r2.z, r2
add_pp r2.xy, r2.w, v5
texld r0.x, r2, s4
texld r3.xyz, r3, s2
texld r2.xyz, v5, s4
add r2.xyz, r2, -r0.x
mad r2.xyz, r2, c10.y, r0.x
mul r3.xyz, r3, c8.x
add_pp r3.xyz, r2, r3
add r4.xy, r2.w, v5.zwzw
texld r2, r4, s3
add_pp r2.xyz, r2, -r3
mul_pp r0.x, r2.w, c7
mad_pp r2.xyz, r0.x, r2, r3
add_pp r1.xyz, r1, -r2
mad_pp r2.xyz, r1.w, r1, r2
mov r1.x, r0.y
mov r1.y, r0.z
mov r1.z, r0.w
dp3 r2.w, r1, r1
rsq r2.w, r2.w
mul r1.xyz, r2.w, r1
mov r0.xz, c4
mov r0.y, -c4
dp3 r0.w, r0, r0
rsq r0.w, r0.w
mul r0.xyz, r0.w, r0
dp3 r0.w, r0, r1
texld r0.xyz, v6, s5
mad r0.w, r0, c9, c9
mul r0.xyz, r0, c3
mad_pp r0.xyz, -r2, c1, r0
mul_sat r0.w, r0, c5.x
add r0.w, -r0, c9.z
mul_pp r1.xyz, r0.w, r0
texldp r0, v1, s7
add_pp r3.xyz, r0, v9
add r2.w, -r1, c9.z
mul_pp r0.xyz, r3, c0
mul_pp r0.w, r0, r2
mul_pp r4.xyz, r0, r0.w
mul_pp r0.w, r0, c0
mul_pp r2.xyz, r2, c1
texld r0.x, v6.zwzw, s6
mad_pp r0.xyz, r0.x, r1, r2
mad_pp r1.xyz, r0, r3, r4
mad_pp oC0.xyz, r0, c2, r1
mad_pp oC0.w, r1, c1, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LakerTex] 2D 3
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_RefTex] 2D 4
SetTexture 4 [_MainTex1] 2D 1
SetTexture 5 [_SnowTex] 2D 5
SetTexture 6 [_SnowMaskTex] 2D 6
SetTexture 7 [_LightBuffer] 2D 7
ConstBuffer "$Globals" 288
Vector 32 [_SpecColor]
Vector 48 [_Color]
Vector 64 [_EmissiveColor]
Vector 96 [_SnowColor]
Vector 112 [_SnowDirection]
Float 128 [_SnowRange]
Float 136 [_Parallax]
Float 140 [_DownBlend]
Float 144 [_RefPara]
BindCB  "$Globals" 0
"ps_4_0
eefiecedcjkgfnnhkiggognhknkipccieafdgaehabaaaaaaeaalaaaaadaaaaaa
cmaaaaaagaabaaaajeabaaaaejfdeheocmabaaaaalaaaaaaaiaaaaaabaabaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaabmabaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaabmabaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apalaaaabmabaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaabmabaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapahaaaabmabaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapahaaaabmabaaaaagaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaacfabaaaaabaaaaaaaaaaaaaaadaaaaaaahaaaaaaapapaaaabmabaaaa
ahaaaaaaaaaaaaaaadaaaaaaaiaaaaaaahahaaaacfabaaaaaaaaaaaaaaaaaaaa
adaaaaaaajaaaaaaahahaaaabmabaaaaafaaaaaaaaaaaaaaadaaaaaaakaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckeajaaaaeaaaaaaa
gjacaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafkaaaaad
aagabaaaagaaaaaafkaaaaadaagabaaaahaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaafibiaaaeaahabaaaagaaaaaa
ffffaaaafibiaaaeaahabaaaahaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadlcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadpcbabaaaagaaaaaagcbaaaad
pcbabaaaahaaaaaagcbaaaadhcbabaaaaiaaaaaagcbaaaadhcbabaaaajaaaaaa
gcbaaaadhcbabaaaakaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaajaaaaaaegbcbaaaajaaaaaaeeaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakbabaaaajaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaacjfmipdndcaaaaakpcaabaaaaaaaaaaaagaabaaaaaaaaaaakgikcaaa
aaaaaaaaaiaaaaaaegbobaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaa
aaaaaaaaeghobaaaaeaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaaiccaabaaa
aaaaaaaadkaabaaaabaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaagaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaaaaaaaaai
hcaabaaaacaaaaaaagaabaiaebaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaam
ncaabaaaaaaaaaaaagajbaaaacaaaaaaaceaaaaamnmmemdoaaaaaaaamnmmemdo
mnmmemdoagaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaa
acaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaabaaaaaaegaabaaaacaaaaaa
egaabaaaacaaaaaaddaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaacaaaaaadkaabaaaabaaaaaaaaaaaaaihcaabaaa
adaaaaaaegacbaiaebaaaaaaacaaaaaaegbcbaaaaiaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hcaabaaaacaaaaaapgapbaaaaeaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaa
baaaaaahbcaabaaaadaaaaaaegbcbaaaadaaaaaaegacbaaaacaaaaaabaaaaaah
ccaabaaaadaaaaaaegbcbaaaaeaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaa
adaaaaaaegbcbaaaafaaaaaaegacbaaaacaaaaaabaaaaaahicaabaaaabaaaaaa
egbcbaaaajaaaaaaegacbaaaadaaaaaaaaaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaadkaabaaaabaaaaaadcaaaaakhcaabaaaacaaaaaaegacbaaaadaaaaaa
pgapbaiaebaaaaaaabaaaaaaegbcbaaaajaaaaaabaaaaaahicaabaaaabaaaaaa
egacbaaaacaaaaaaegacbaaaacaaaaaaeeaaaaaficaabaaaabaaaaaadkaabaaa
abaaaaaadiaaaaahdcaabaaaacaaaaaapgapbaaaabaaaaaaegaabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaa
aeaaaaaadcaaaaakncaabaaaaaaaaaaaagiacaaaaaaaaaaaajaaaaaaagajbaaa
acaaaaaaagaobaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaigadbaiaebaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaajhcaabaaaaaaaaaaafgafbaaaaaaaaaaa
egacbaaaabaaaaaaigadbaaaaaaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaia
ebaaaaaaaaaaaaaaegacbaaaaeaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaa
aeaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaahaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadcaaaaalhcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaaegacbaiaebaaaaaa
aaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaadiaaaaalhcaabaaaadaaaaaaegiccaaa
aaaaaaaaahaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaaifcaabaaaadaaaaaapgapbaaaaaaaaaaa
agiccaaaaaaaaaaaahaaaaaadiaaaaajccaabaaaadaaaaaadkaabaaaaaaaaaaa
bkiacaiaebaaaaaaaaaaaaaaahaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
adaaaaaaegacbaaaacaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaadpabeaaaaaaaaaaadpdicaaaaiicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakiacaaaaaaaaaaaaiaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaahaaaaaa
eghobaaaagaaaaaaaagabaaaagaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaa
acaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaahaaaaaaaagabaaaahaaaaaaaaaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaaegbcbaaaakaaaaaaaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaeaaaaaaabeaaaaaaaaaiadpdiaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaaabaaaaaa
egiccaaaaaaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaa
egacbaaaacaaaaaadiaaaaaiicaabaaaaaaaaaaadkaabaaaaaaaaaaadkiacaaa
aaaaaaaaacaaaaaadcaaaaakiccabaaaaaaaaaaadkaabaaaaeaaaaaadkiacaaa
aaaaaaaaadaaaaaadkaabaaaaaaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadcaaaaakhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
}
 }
}
Fallback "Diffuse"
}