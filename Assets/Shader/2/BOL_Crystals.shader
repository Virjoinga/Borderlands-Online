Î√Shader "BOL/Scene/Crystals" {
Properties {
 _Color ("Diffuse Color(G channel)", Color) = (0.5,0.5,0.5,1)
 _StaticIllumColor ("Static Illum Color(R channle)", Color) = (0.5,0.5,0.5,1)
 _DynamiIllumColor ("DynamiIllum Color(B channel)", Color) = (0.5,0.5,0.5,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _MaskTex ("Mask Tex (A)", 2D) = "white" {}
 _StaticEmissionLM ("Static Emission (Lightmapper)", Float) = 1
 _DynamiEmissionLM ("Dynamic Emission", Float) = 1
 _AnimSpeed ("Anim Speed", Float) = 1
 _Tiling ("Tiling Value", Float) = 1
 _SpecularColor ("Specular Color", Color) = (0.5,0.5,0.5,1)
 _Shininess ("Shininess", Range(0.01,1)) = 0.078125
}
SubShader { 
 Tags { "QUEUE"="Geometry" "RenderType"="Opaque" }
 Pass {
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="Geometry" "RenderType"="Opaque" }
  AlphaTest Greater 0.01
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [unity_SHAr]
Vector 12 [unity_SHAg]
Vector 13 [unity_SHAb]
Vector 14 [unity_SHBr]
Vector 15 [unity_SHBg]
Vector 16 [unity_SHBb]
Vector 17 [unity_SHC]
Vector 18 [unity_Scale]
Vector 19 [_MainTex_ST]
Float 20 [_AnimSpeed]
Float 21 [_Tiling]
"!!ARBvp1.0
PARAM c[27] = { { 0.5, 24.980801, -24.980801, 0.15915491 },
		state.matrix.mvp,
		program.local[5..21],
		{ 0, 0.5, 1, 0.25 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -1, 1, -9, 0.75 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R0.x, vertex.position, c[0].w;
ADD R0.x, R0, -c[22].w;
FRC R0.w, R0.x;
ADD R0.xyz, -R0.w, c[22];
MUL R0.xyz, R0, R0;
MUL R1.xyz, R0, c[0].yzyw;
ADD R1.xyz, R1, c[23].xyxw;
MAD R1.xyz, R1, R0, c[23].zwzw;
MAD R1.xyz, R1, R0, c[24].xyxw;
MAD R1.xyz, R1, R0, c[24].zwzw;
MAD R0.xyz, R1, R0, c[25].xyxw;
SGE R2.yz, R0.w, c[25].xzww;
SLT R2.x, R0.w, c[22].w;
DP3 R3.y, R2, c[25].xyxw;
MOV R3.xz, R2;
DP3 R2.w, R0, -R3;
MUL R1.xyz, vertex.normal, c[18].w;
DP3 R3.x, R1, c[6];
DP3 R3.y, R1, c[7];
DP3 R0.x, R1, c[5];
MOV R0.y, R3.x;
MOV R0.z, R3.y;
MOV R0.w, c[22].z;
MUL R1, R0.xyzz, R0.yzzx;
DP4 R2.z, R0, c[13];
DP4 R2.y, R0, c[12];
DP4 R2.x, R0, c[11];
DP4 R0.w, R1, c[16];
DP4 R0.y, R1, c[14];
DP4 R0.z, R1, c[15];
ADD R1.xyz, R2, R0.yzww;
MUL R0.y, R3.x, R3.x;
MOV R0.z, c[20].x;
MAD R0.y, R0.x, R0.x, -R0;
MUL R2.xyz, R0.y, c[17];
ADD result.texcoord[4].xyz, R1, R2;
MUL R0.z, R0, c[9].x;
MAD R0.w, R2, c[0].x, c[0].x;
MAD R0.w, R0, c[26].x, R0.z;
DP4 R1.z, vertex.position, c[7];
DP4 R1.x, vertex.position, c[5];
DP4 R1.y, vertex.position, c[6];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[21].x, R0.zwzw;
ADD result.texcoord[2].xyz, -R1, c[10];
MOV result.texcoord[3].z, R3.y;
MOV result.texcoord[3].y, R3.x;
MOV result.texcoord[3].x, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
MOV result.texcoord[1].zw, c[22].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 53 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_SHAr]
Vector 11 [unity_SHAg]
Vector 12 [unity_SHAb]
Vector 13 [unity_SHBr]
Vector 14 [unity_SHBg]
Vector 15 [unity_SHBb]
Vector 16 [unity_SHC]
Vector 17 [unity_Scale]
Vector 18 [_MainTex_ST]
Float 19 [_AnimSpeed]
Float 20 [_Tiling]
"vs_2_0
def c21, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c22, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c23, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c24, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c17.w
dp3 r2.w, r0, c5
dp3 r1.w, r0, c6
dp3 r3.x, r0, c4
mov r3.y, r2.w
mov r3.z, r1.w
mul r0, r3.xyzz, r3.yzzx
mov r3.w, c21.z
dp4 r2.z, r0, c15
dp4 r2.x, r0, c13
dp4 r2.y, r0, c14
mad r0.x, v0, c23, c23.y
mul r0.y, r2.w, r2.w
dp4 r1.z, r3, c12
dp4 r1.y, r3, c11
dp4 r1.x, r3, c10
frc r0.x, r0
add r2.xyz, r1, r2
mad r0.y, r3.x, r3.x, -r0
mul r1.xyz, r0.y, c16
mad r3.y, r0.x, c23.z, c23.w
sincos r0.xy, r3.y, c22.xyzw, c21.xyzw
mov r0.x, c8
mul r0.x, c19, r0
mad r0.y, r0, c21.w, c21.w
mad r0.y, r0, c24.x, r0.x
mad oT1.xy, v2, c20.x, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT4.xyz, r2, r1
add oT2.xyz, -r0, c9
mov oT3.z, r1.w
mov oT3.y, r2.w
mov oT3.x, r3
mad oT0.xy, v2, c18, c18.zwzw
mov oT1.zw, c24.y
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Vector 112 [_MainTex_ST]
Float 128 [_AnimSpeed]
Float 132 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedioldaphmahladgepabekpbcidobioieoabaaaaaaoaagaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklfdeieefccmafaaaaeaaaabaaelabaaaafjaaaaae
egiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaenaaaaagbcaabaaa
aaaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaabaaaaaa
akiacaaaaaaaaaaaaiaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaa
abaaaaaaakaabaaaaaaaaaaaabeaaaaamnmmemdoakaabaaaabaaaaaadcaaaaak
dccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaaaiaaaaaaegaabaaa
abaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaaj
hccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaeaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
aaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaa
abaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaa
abaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaa
abaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaa
acaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaa
egiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaa
egiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaa
egiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaafaaaaaa
egiccaaaacaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Vector 112 [_MainTex_ST]
Float 128 [_AnimSpeed]
Float 132 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedfohnbbbmedcpnjjlmodkecfekjamfckbabaaaaaajeakaaaaaeaaaaaa
daaaaaaaoaadaaaabeajaaaanmajaaaaebgpgodjkiadaaaakiadaaaaaaacpopp
cmadaaaahmaaaaaaahaaceaaaaaahiaaaaaahiaaaaaaceaaabaahiaaaaaaahaa
acaaabaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaabaaaeaaabaaaeaaaaaaaaaa
acaacgaaahaaafaaaaaaaaaaadaaaaaaaeaaamaaaaaaaaaaadaaamaaaeaabaaa
aaaaaaaaadaabeaaabaabeaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbfaaapka
idpjccdoaaaaaadpnlapmjeanlapejmafbaaaaafbgaaapkamnmmemdoaaaaiadp
aaaaaaaaaaaaaaaafbaaaaafbhaaapkaabannalfgballglhklkkckdlijiiiidj
fbaaaaafbiaaapkaklkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaaeaaaaaeaaaaabiaaaaaaajabfaaaaka
bfaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaabiaaaaaaaiabfaakkka
bfaappkacfaaaaaeabaaaciaaaaaaaiabhaaoekabiaaoekaaeaaaaaeaaaaabia
abaaffiabfaaffkabfaaffkaabaaaaacabaaabiaacaaaakaafaaaaadabaaabia
abaaaaiaadaaaakaaeaaaaaeabaaaciaaaaaaaiabgaaaakaabaaaaiaaeaaaaae
abaaadoaadaaoejaacaaffkaabaaoeiaafaaaaadaaaaahiaaaaaffjabbaaoeka
aeaaaaaeaaaaahiabaaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabcaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiabdaaoekaaaaappjaaaaaoeiaacaaaaad
acaaahoaaaaaoeibaeaaoekaafaaaaadaaaaahiaacaaoejabeaappkaafaaaaad
abaaahiaaaaaffiabbaaoekaaeaaaaaeaaaaaliabaaakekaaaaaaaiaabaakeia
aeaaaaaeaaaaahiabcaaoekaaaaakkiaaaaapeiaabaaaaacaaaaaiiabgaaffka
ajaaaaadabaaabiaafaaoekaaaaaoeiaajaaaaadabaaaciaagaaoekaaaaaoeia
ajaaaaadabaaaeiaahaaoekaaaaaoeiaafaaaaadacaaapiaaaaacjiaaaaakeia
ajaaaaadadaaabiaaiaaoekaacaaoeiaajaaaaadadaaaciaajaaoekaacaaoeia
ajaaaaadadaaaeiaakaaoekaacaaoeiaacaaaaadabaaahiaabaaoeiaadaaoeia
afaaaaadaaaaaiiaaaaaffiaaaaaffiaaeaaaaaeaaaaaiiaaaaaaaiaaaaaaaia
aaaappibabaaaaacadaaahoaaaaaoeiaaeaaaaaeaeaaahoaalaaoekaaaaappia
abaaoeiaafaaaaadaaaaapiaaaaaffjaanaaoekaaeaaaaaeaaaaapiaamaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaapaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacabaaamoabgaakkkappppaaaa
fdeieefccmafaaaaeaaaabaaelabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaa
fjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaa
giaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaaenaaaaagbcaabaaaaaaaaaaaaanaaaaaakbabaaa
aaaaaaaadcaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadp
abeaaaaaaaaaaadpdiaaaaajbcaabaaaabaaaaaaakiacaaaaaaaaaaaaiaaaaaa
akiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaaabaaaaaaakaabaaaaaaaaaaa
abeaaaaamnmmemdoakaabaaaabaaaaaadcaaaaakdccabaaaacaaaaaaegbabaaa
adaaaaaafgifcaaaaaaaaaaaaiaaaaaaegaabaaaabaaaaaadgaaaaaimccabaaa
acaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaaadaaaaaaegacbaia
ebaaaaaaaaaaaaaaegiccaaaabaaaaaaaeaaaaaadiaaaaaihcaabaaaaaaaaaaa
egbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaa
egiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaa
aaaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaaaaaaaaadgaaaaaficaabaaa
aaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaacaaaaaa
cgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaacaaaaaa
chaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaacaaaaaa
ciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaa
egakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaacjaaaaaa
egaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaackaaaaaa
egaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaaclaaaaaa
egaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
adaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaaacaaaaaacmaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeo
ehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheo
laaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfa
gphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [unity_Scale]
Vector 12 [_MainTex_ST]
Vector 13 [unity_LightmapST]
Float 14 [_AnimSpeed]
Float 15 [_Tiling]
"!!ARBvp1.0
PARAM c[21] = { { 0.5, 24.980801, -24.980801, 0.15915491 },
		state.matrix.mvp,
		program.local[5..15],
		{ 0, 0.5, 1, 0.25 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -1, 1, -9, 0.75 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
MUL R0.x, vertex.position, c[0].w;
ADD R0.x, R0, -c[16].w;
FRC R0.w, R0.x;
ADD R0.xyz, -R0.w, c[16];
MUL R0.xyz, R0, R0;
MUL R1.xyz, R0, c[0].yzyw;
ADD R1.xyz, R1, c[17].xyxw;
MAD R1.xyz, R1, R0, c[17].zwzw;
MAD R1.xyz, R1, R0, c[18].xyxw;
MAD R1.xyz, R1, R0, c[18].zwzw;
MAD R0.xyz, R1, R0, c[19].xyxw;
SLT R1.x, R0.w, c[16].w;
SGE R1.yz, R0.w, c[19].xzww;
DP3 R1.y, R1, c[19].xyxw;
DP3 R0.y, R0, -R1;
MUL R1.xyz, vertex.normal, c[11].w;
MOV R0.w, c[14].x;
MUL R0.x, R0.w, c[9];
MAD R0.y, R0, c[0].x, c[0].x;
MAD R0.y, R0, c[20].x, R0.x;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[15].x, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, -R0, c[10];
DP3 result.texcoord[3].z, R1, c[7];
DP3 result.texcoord[3].y, R1, c[6];
DP3 result.texcoord[3].x, R1, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MOV result.texcoord[1].zw, c[16].x;
MAD result.texcoord[4].xy, vertex.texcoord[1], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 35 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
Vector 11 [_MainTex_ST]
Vector 12 [unity_LightmapST]
Float 13 [_AnimSpeed]
Float 14 [_Tiling]
"vs_2_0
def c15, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c16, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c17, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c18, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
mad r0.x, v0, c17, c17.y
frc r0.x, r0
mad r1.x, r0, c17.z, c17.w
sincos r0.xy, r1.x, c16.xyzw, c15.xyzw
mul r1.xyz, v1, c10.w
mov r0.x, c8
mul r0.x, c13, r0
mad r0.y, r0, c15.w, c15.w
mad r0.y, r0, c18.x, r0.x
mad oT1.xy, v2, c14.x, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, -r0, c9
dp3 oT3.z, r1, c6
dp3 oT3.y, r1, c5
dp3 oT3.x, r1, c4
mad oT0.xy, v2, c11, c11.zwzw
mov oT1.zw, c18.y
mad oT4.xy, v3, c12, c12.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 176
Vector 112 [_MainTex_ST]
Vector 128 [unity_LightmapST]
Float 144 [_AnimSpeed]
Float 148 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedchmhkcafeakajcpmfmbjlnmfeelnljinabaaaaaahmafaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklfdeieefcmiadaaaaeaaaabaapcaaaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaa
enaaaaagbcaabaaaaaaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaaj
bcaabaaaabaaaaaaakiacaaaaaaaaaaaajaaaaaaakiacaaaabaaaaaaaaaaaaaa
dcaaaaajccaabaaaabaaaaaaakaabaaaaaaaaaaaabeaaaaamnmmemdoakaabaaa
abaaaaaadcaaaaakdccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaa
ajaaaaaaegaabaaaabaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaa
acaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaa
acaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 176
Vector 112 [_MainTex_ST]
Vector 128 [unity_LightmapST]
Float 144 [_AnimSpeed]
Float 148 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedcfhfdogeobiabdmbekohpekpnmmmgakcabaaaaaaheaiaaaaaeaaaaaa
daaaaaaaceadaaaapeagaaaalmahaaaaebgpgodjomacaaaaomacaaaaaaacpopp
hmacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaahaa
adaaabaaaaaaaaaaabaaaaaaabaaaeaaaaaaaaaaabaaaeaaabaaafaaaaaaaaaa
acaaaaaaaeaaagaaaaaaaaaaacaaamaaaeaaakaaaaaaaaaaacaabeaaabaaaoaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafapaaapkaidpjccdoaaaaaadpnlapmjea
nlapejmafbaaaaafbaaaapkamnmmemdoaaaaaaaaaaaaaaaaaaaaaaaafbaaaaaf
bbaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafbcaaapkaklkkkklm
aaaaaaloaaaaiadpaaaaaadpbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaaeaaaaaeaaaaabiaaaaaaajaapaaaaka
apaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaabiaaaaaaaiaapaakkka
apaappkacfaaaaaeabaaaciaaaaaaaiabbaaoekabcaaoekaaeaaaaaeaaaaabia
abaaffiaapaaffkaapaaffkaabaaaaacabaaabiaadaaaakaafaaaaadabaaabia
abaaaaiaaeaaaakaaeaaaaaeabaaaciaaaaaaaiabaaaaakaabaaaaiaaeaaaaae
abaaadoaadaaoejaadaaffkaabaaoeiaafaaaaadaaaaahiaaaaaffjaalaaoeka
aeaaaaaeaaaaahiaakaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiaamaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaappjaaaaaoeiaacaaaaad
acaaahoaaaaaoeibafaaoekaafaaaaadaaaaahiaacaaoejaaoaappkaafaaaaad
abaaahiaaaaaffiaalaaoekaaeaaaaaeaaaaaliaakaakekaaaaaaaiaabaakeia
aeaaaaaeadaaahoaamaaoekaaaaakkiaaaaapeiaaeaaaaaeaaaaamoaaeaabeja
acaabekaacaalekaafaaaaadaaaaapiaaaaaffjaahaaoekaaeaaaaaeaaaaapia
agaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaajaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacabaaamoabaaaffka
ppppaaaafdeieefcmiadaaaaeaaaabaapcaaaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaaenaaaaagbcaabaaa
aaaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaabaaaaaa
akiacaaaaaaaaaaaajaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaa
abaaaaaaakaabaaaaaaaaaaaabeaaaaamnmmemdoakaabaaaabaaaaaadcaaaaak
dccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaaajaaaaaaegaabaaa
abaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaaj
hccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaeaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeo
ehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheo
laaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
gphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [unity_Scale]
Vector 12 [_MainTex_ST]
Vector 13 [unity_LightmapST]
Float 14 [_AnimSpeed]
Float 15 [_Tiling]
"!!ARBvp1.0
PARAM c[21] = { { 0.5, 24.980801, -24.980801, 0.15915491 },
		state.matrix.mvp,
		program.local[5..15],
		{ 0, 0.5, 1, 0.25 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -1, 1, -9, 0.75 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
MUL R0.x, vertex.position, c[0].w;
ADD R0.x, R0, -c[16].w;
FRC R0.w, R0.x;
ADD R0.xyz, -R0.w, c[16];
MUL R0.xyz, R0, R0;
MUL R1.xyz, R0, c[0].yzyw;
ADD R1.xyz, R1, c[17].xyxw;
MAD R1.xyz, R1, R0, c[17].zwzw;
MAD R1.xyz, R1, R0, c[18].xyxw;
MAD R1.xyz, R1, R0, c[18].zwzw;
MAD R0.xyz, R1, R0, c[19].xyxw;
SLT R1.x, R0.w, c[16].w;
SGE R1.yz, R0.w, c[19].xzww;
DP3 R1.y, R1, c[19].xyxw;
DP3 R0.y, R0, -R1;
MUL R1.xyz, vertex.normal, c[11].w;
MOV R0.w, c[14].x;
MUL R0.x, R0.w, c[9];
MAD R0.y, R0, c[0].x, c[0].x;
MAD R0.y, R0, c[20].x, R0.x;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[15].x, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[2].xyz, -R0, c[10];
DP3 result.texcoord[3].z, R1, c[7];
DP3 result.texcoord[3].y, R1, c[6];
DP3 result.texcoord[3].x, R1, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MOV result.texcoord[1].zw, c[16].x;
MAD result.texcoord[4].xy, vertex.texcoord[1], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 35 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
Vector 11 [_MainTex_ST]
Vector 12 [unity_LightmapST]
Float 13 [_AnimSpeed]
Float 14 [_Tiling]
"vs_2_0
def c15, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c16, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c17, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c18, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
mad r0.x, v0, c17, c17.y
frc r0.x, r0
mad r1.x, r0, c17.z, c17.w
sincos r0.xy, r1.x, c16.xyzw, c15.xyzw
mul r1.xyz, v1, c10.w
mov r0.x, c8
mul r0.x, c13, r0
mad r0.y, r0, c15.w, c15.w
mad r0.y, r0, c18.x, r0.x
mad oT1.xy, v2, c14.x, r0
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, -r0, c9
dp3 oT3.z, r1, c6
dp3 oT3.y, r1, c5
dp3 oT3.x, r1, c4
mad oT0.xy, v2, c11, c11.zwzw
mov oT1.zw, c18.y
mad oT4.xy, v3, c12, c12.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 176
Vector 112 [_MainTex_ST]
Vector 128 [unity_LightmapST]
Float 144 [_AnimSpeed]
Float 148 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedchmhkcafeakajcpmfmbjlnmfeelnljinabaaaaaahmafaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklfdeieefcmiadaaaaeaaaabaapcaaaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaa
enaaaaagbcaabaaaaaaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaaj
bcaabaaaabaaaaaaakiacaaaaaaaaaaaajaaaaaaakiacaaaabaaaaaaaaaaaaaa
dcaaaaajccaabaaaabaaaaaaakaabaaaaaaaaaaaabeaaaaamnmmemdoakaabaaa
abaaaaaadcaaaaakdccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaa
ajaaaaaaegaabaaaabaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaa
acaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaa
acaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 176
Vector 112 [_MainTex_ST]
Vector 128 [unity_LightmapST]
Float 144 [_AnimSpeed]
Float 148 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedcfhfdogeobiabdmbekohpekpnmmmgakcabaaaaaaheaiaaaaaeaaaaaa
daaaaaaaceadaaaapeagaaaalmahaaaaebgpgodjomacaaaaomacaaaaaaacpopp
hmacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaahaa
adaaabaaaaaaaaaaabaaaaaaabaaaeaaaaaaaaaaabaaaeaaabaaafaaaaaaaaaa
acaaaaaaaeaaagaaaaaaaaaaacaaamaaaeaaakaaaaaaaaaaacaabeaaabaaaoaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafapaaapkaidpjccdoaaaaaadpnlapmjea
nlapejmafbaaaaafbaaaapkamnmmemdoaaaaaaaaaaaaaaaaaaaaaaaafbaaaaaf
bbaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafbcaaapkaklkkkklm
aaaaaaloaaaaiadpaaaaaadpbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaaeaaaaaeaaaaabiaaaaaaajaapaaaaka
apaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaabiaaaaaaaiaapaakkka
apaappkacfaaaaaeabaaaciaaaaaaaiabbaaoekabcaaoekaaeaaaaaeaaaaabia
abaaffiaapaaffkaapaaffkaabaaaaacabaaabiaadaaaakaafaaaaadabaaabia
abaaaaiaaeaaaakaaeaaaaaeabaaaciaaaaaaaiabaaaaakaabaaaaiaaeaaaaae
abaaadoaadaaoejaadaaffkaabaaoeiaafaaaaadaaaaahiaaaaaffjaalaaoeka
aeaaaaaeaaaaahiaakaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiaamaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaappjaaaaaoeiaacaaaaad
acaaahoaaaaaoeibafaaoekaafaaaaadaaaaahiaacaaoejaaoaappkaafaaaaad
abaaahiaaaaaffiaalaaoekaaeaaaaaeaaaaaliaakaakekaaaaaaaiaabaakeia
aeaaaaaeadaaahoaamaaoekaaaaakkiaaaaapeiaaeaaaaaeaaaaamoaaeaabeja
acaabekaacaalekaafaaaaadaaaaapiaaaaaffjaahaaoekaaeaaaaaeaaaaapia
agaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaajaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacabaaamoabaaaffka
ppppaaaafdeieefcmiadaaaaeaaaabaapcaaaaaafjaaaaaeegiocaaaaaaaaaaa
akaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaaenaaaaagbcaabaaa
aaaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaabaaaaaa
akiacaaaaaaaaaaaajaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaa
abaaaaaaakaabaaaaaaaaaaaabeaaaaamnmmemdoakaabaaaabaaaaaadcaaaaak
dccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaaajaaaaaaegaabaaa
abaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaaj
hccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaeaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeo
ehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheo
laaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
gphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [_ProjectionParams]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [unity_Scale]
Vector 20 [_MainTex_ST]
Float 21 [_AnimSpeed]
Float 22 [_Tiling]
"!!ARBvp1.0
PARAM c[28] = { { 0.5, 24.980801, -24.980801, 0.15915491 },
		state.matrix.mvp,
		program.local[5..22],
		{ 0, 0.5, 1, 0.25 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -1, 1, -9, 0.75 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R0.xyz, vertex.normal, c[19].w;
DP3 R3.w, R0, c[6];
DP3 R0.w, R0, c[7];
DP3 R2.w, R0, c[5];
MOV R2.x, R3.w;
MOV R2.y, R0.w;
MOV R2.z, c[23];
DP4 R0.z, R2.wxyz, c[14];
DP4 R0.y, R2.wxyz, c[13];
DP4 R0.x, R2.wxyz, c[12];
MUL R1.x, vertex.position, c[0].w;
ADD R2.z, R1.x, -c[23].w;
MUL R1, R2.wxyy, R2.xyyw;
FRC R4.x, R2.z;
ADD R2.xyz, -R4.x, c[23];
MUL R2.xyz, R2, R2;
DP4 R3.z, R1, c[17];
DP4 R3.y, R1, c[16];
DP4 R3.x, R1, c[15];
MUL R1.xyz, R2, c[0].yzyw;
ADD R1.xyz, R1, c[24].xyxw;
MAD R1.xyz, R1, R2, c[24].zwzw;
MAD R1.xyz, R1, R2, c[25].xyxw;
MUL R1.w, R3, R3;
MAD R1.xyz, R1, R2, c[25].zwzw;
ADD R0.xyz, R0, R3;
MAD R1.w, R2, R2, -R1;
MUL R3.xyz, R1.w, c[18];
ADD result.texcoord[4].xyz, R0, R3;
MAD R0.xyz, R1, R2, c[26].xyxw;
MOV R1.w, c[21].x;
MUL R2.x, R1.w, c[9];
SLT R1.x, R4, c[23].w;
SGE R1.yz, R4.x, c[26].xzww;
DP3 R1.y, R1, c[26].xyxw;
DP3 R0.x, R0, -R1;
MAD R0.x, R0, c[0], c[0];
MAD R2.y, R0.x, c[27].x, R2.x;
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[11].x;
ADD result.texcoord[5].xy, R0, R0.z;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[22].x, R2;
MOV result.position, R1;
MOV result.texcoord[5].zw, R1;
ADD result.texcoord[2].xyz, -R0, c[10];
MOV result.texcoord[3].z, R0.w;
MOV result.texcoord[3].y, R3.w;
MOV result.texcoord[3].x, R2.w;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[20], c[20].zwzw;
MOV result.texcoord[1].zw, c[23].x;
END
# 57 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 12 [unity_SHAr]
Vector 13 [unity_SHAg]
Vector 14 [unity_SHAb]
Vector 15 [unity_SHBr]
Vector 16 [unity_SHBg]
Vector 17 [unity_SHBb]
Vector 18 [unity_SHC]
Vector 19 [unity_Scale]
Vector 20 [_MainTex_ST]
Float 21 [_AnimSpeed]
Float 22 [_Tiling]
"vs_2_0
def c23, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c24, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c25, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c26, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c19.w
dp3 r3.x, r0, c5
dp3 r3.y, r0, c6
dp3 r2.x, r0, c4
mov r2.y, r3.x
mov r2.z, r3.y
mov r2.w, c23.z
mul r0, r2.xyzz, r2.yzzx
dp4 r1.z, r2, c14
dp4 r1.y, r2, c13
dp4 r1.x, r2, c12
dp4 r2.w, r0, c17
dp4 r2.z, r0, c16
dp4 r2.y, r0, c15
mul r0.w, r3.x, r3.x
add r0.xyz, r1, r2.yzww
mad r0.w, r2.x, r2.x, -r0
mul r1.xyz, r0.w, c18
add oT4.xyz, r0, r1
mad r1.w, v0.x, c25.x, c25.y
frc r0.w, r1
mad r1.z, r0.w, c25, c25.w
sincos r0.xy, r1.z, c24.xyzw, c23.xyzw
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.yzw, r1.xxyw, c23.w
mul r0.w, r2.z, c10.x
mov r0.z, r2.y
mad r0.x, r0.y, c23.w, c23.w
mad oT5.xy, r2.w, c11.zwzw, r0.zwzw
mov r0.z, c8.x
mul r0.z, c21.x, r0
mad r0.w, r0.x, c26.x, r0.z
mad oT1.xy, v2, c22.x, r0.zwzw
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oPos, r1
mov oT5.zw, r1
add oT2.xyz, -r0, c9
mov oT3.z, r3.y
mov oT3.y, r3.x
mov oT3.x, r2
mad oT0.xy, v2, c20, c20.zwzw
mov oT1.zw, c26.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 224
Vector 176 [_MainTex_ST]
Float 192 [_AnimSpeed]
Float 196 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedlipjibgfnahooaolphealkabfnikcbppabaaaaaajaahaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklfdeieefcmeafaaaaeaaaabaahbabaaaafjaaaaaeegiocaaaaaaaaaaa
anaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacafaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
alaaaaaaogikcaaaaaaaaaaaalaaaaaaenaaaaagbcaabaaaabaaaaaaaanaaaaa
akbabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaa
aaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaacaaaaaaakiacaaaaaaaaaaa
amaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaaacaaaaaaakaabaaa
abaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaakdccabaaaacaaaaaa
egbabaaaadaaaaaafgifcaaaaaaaaaaaamaaaaaaegaabaaaacaaaaaadgaaaaai
mccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaai
hcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaajhccabaaaadaaaaaa
egacbaiaebaaaaaaabaaaaaaegiccaaaabaaaaaaaeaaaaaadiaaaaaihcaabaaa
abaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
abaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaabaaaaaa
egadbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaabaaaaaadgaaaaaf
icaabaaaabaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaabaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaa
abaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaadaaaaaaaaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaa
egacbaaaaeaaaaaadiaaaaahccaabaaaabaaaaaabkaabaaaabaaaaaabkaabaaa
abaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaa
bkaabaiaebaaaaaaabaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaabaaaaaaegacbaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaagaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 224
Vector 176 [_MainTex_ST]
Float 192 [_AnimSpeed]
Float 196 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedhndblelbjmmpmmlkfgiopnheeeeckkkiabaaaaaajaalaaaaaeaaaaaa
daaaaaaacmaeaaaapiajaaaamaakaaaaebgpgodjpeadaaaapeadaaaaaaacpopp
hiadaaaahmaaaaaaahaaceaaaaaahiaaaaaahiaaaaaaceaaabaahiaaaaaaalaa
acaaabaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaabaaaeaaacaaaeaaaaaaaaaa
acaacgaaahaaagaaaaaaaaaaadaaaaaaaeaaanaaaaaaaaaaadaaamaaaeaabbaa
aaaaaaaaadaabeaaabaabfaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbgaaapka
idpjccdoaaaaaadpnlapmjeanlapejmafbaaaaafbhaaapkamnmmemdoaaaaiadp
aaaaaaaaaaaaaaaafbaaaaafbiaaapkaabannalfgballglhklkkckdlijiiiidj
fbaaaaafbjaaapkaklkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaaeaaaaaeaaaaabiaaaaaaajabgaaaaka
bgaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaabiaaaaaaaiabgaakkka
bgaappkacfaaaaaeabaaaciaaaaaaaiabiaaoekabjaaoekaaeaaaaaeaaaaabia
abaaffiabgaaffkabgaaffkaabaaaaacabaaabiaacaaaakaafaaaaadabaaabia
abaaaaiaadaaaakaaeaaaaaeabaaaciaaaaaaaiabhaaaakaabaaaaiaaeaaaaae
abaaadoaadaaoejaacaaffkaabaaoeiaafaaaaadaaaaahiaaaaaffjabcaaoeka
aeaaaaaeaaaaahiabbaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabdaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiabeaaoekaaaaappjaaaaaoeiaacaaaaad
acaaahoaaaaaoeibaeaaoekaafaaaaadaaaaahiaacaaoejabfaappkaafaaaaad
abaaahiaaaaaffiabcaaoekaaeaaaaaeaaaaaliabbaakekaaaaaaaiaabaakeia
aeaaaaaeaaaaahiabdaaoekaaaaakkiaaaaapeiaabaaaaacaaaaaiiabhaaffka
ajaaaaadabaaabiaagaaoekaaaaaoeiaajaaaaadabaaaciaahaaoekaaaaaoeia
ajaaaaadabaaaeiaaiaaoekaaaaaoeiaafaaaaadacaaapiaaaaacjiaaaaakeia
ajaaaaadadaaabiaajaaoekaacaaoeiaajaaaaadadaaaciaakaaoekaacaaoeia
ajaaaaadadaaaeiaalaaoekaacaaoeiaacaaaaadabaaahiaabaaoeiaadaaoeia
afaaaaadaaaaaiiaaaaaffiaaaaaffiaaeaaaaaeaaaaaiiaaaaaaaiaaaaaaaia
aaaappibabaaaaacadaaahoaaaaaoeiaaeaaaaaeaeaaahoaamaaoekaaaaappia
abaaoeiaafaaaaadaaaaapiaaaaaffjaaoaaoekaaeaaaaaeaaaaapiaanaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaapaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiabaaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaafaaaaka
afaaaaadabaaaiiaabaaaaiabgaaffkaafaaaaadabaaafiaaaaapeiabgaaffka
acaaaaadafaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacafaaamoaaaaaoeiaabaaaaac
abaaamoabhaakkkappppaaaafdeieefcmeafaaaaeaaaabaahbabaaaafjaaaaae
egiocaaaaaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacafaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaaenaaaaagbcaabaaa
abaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaacaaaaaa
akiacaaaaaaaaaaaamaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaa
acaaaaaaakaabaaaabaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaak
dccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaaamaaaaaaegaabaaa
acaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaj
hccabaaaadaaaaaaegacbaiaebaaaaaaabaaaaaaegiccaaaabaaaaaaaeaaaaaa
diaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaa
diaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaaklcaabaaaabaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaabaaaaaa
egaibaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgakbaaaabaaaaaaegadbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaa
acaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaaiccaabaaa
acaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaaiecaabaaa
acaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaadiaaaaahpcaabaaa
adaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaa
egiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaa
egiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaa
egiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaaaaaaaaahhcaabaaaacaaaaaa
egacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaahccaabaaaabaaaaaabkaabaaa
abaaaaaabkaabaaaabaaaaaadcaaaaakbcaabaaaabaaaaaaakaabaaaabaaaaaa
akaabaaaabaaaaaabkaabaiaebaaaaaaabaaaaaadcaaaaakhccabaaaafaaaaaa
egiccaaaacaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaaacaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaagaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
agaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
kbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
ljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
lmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaa
lmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [_ProjectionParams]
Vector 12 [unity_Scale]
Vector 13 [_MainTex_ST]
Vector 14 [unity_LightmapST]
Float 15 [_AnimSpeed]
Float 16 [_Tiling]
"!!ARBvp1.0
PARAM c[22] = { { 0.5, 24.980801, -24.980801, 0.15915491 },
		state.matrix.mvp,
		program.local[5..16],
		{ 0, 0.5, 1, 0.25 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -1, 1, -9, 0.75 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
MUL R0.x, vertex.position, c[0].w;
ADD R0.x, R0, -c[17].w;
FRC R0.w, R0.x;
ADD R0.xyz, -R0.w, c[17];
MUL R0.xyz, R0, R0;
MUL R1.xyz, R0, c[0].yzyw;
ADD R1.xyz, R1, c[18].xyxw;
MAD R1.xyz, R1, R0, c[18].zwzw;
MAD R1.xyz, R1, R0, c[19].xyxw;
MAD R1.xyz, R1, R0, c[19].zwzw;
MAD R0.xyz, R1, R0, c[20].xyxw;
SLT R1.x, R0.w, c[17].w;
SGE R1.yz, R0.w, c[20].xzww;
DP3 R1.y, R1, c[20].xyxw;
DP3 R0.x, R0, -R1;
MOV R0.w, c[15].x;
MUL R2.x, R0.w, c[9];
MAD R0.x, R0, c[0], c[0];
MAD R2.y, R0.x, c[21].x, R2.x;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[11].x;
ADD result.texcoord[5].xy, R1, R1.z;
MUL R1.xyz, vertex.normal, c[12].w;
MOV result.texcoord[5].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[16].x, R2;
ADD result.texcoord[2].xyz, -R0, c[10];
DP3 result.texcoord[3].z, R1, c[7];
DP3 result.texcoord[3].y, R1, c[6];
DP3 result.texcoord[3].x, R1, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MOV result.texcoord[1].zw, c[17].x;
MAD result.texcoord[4].xy, vertex.texcoord[1], c[14], c[14].zwzw;
END
# 40 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 12 [unity_Scale]
Vector 13 [_MainTex_ST]
Vector 14 [unity_LightmapST]
Float 15 [_AnimSpeed]
Float 16 [_Tiling]
"vs_2_0
def c17, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c18, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c19, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c20, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
mad r0.x, v0, c19, c19.y
frc r0.x, r0
mad r1.z, r0.x, c19, c19.w
sincos r0.xy, r1.z, c18.xyzw, c17.xyzw
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c17.w
mov r0.z, r2.x
mul r0.w, r2.y, c10.x
mad oT5.xy, r2.z, c11.zwzw, r0.zwzw
mov r0.x, c8
mul r0.x, c15, r0
mad r0.y, r0, c17.w, c17.w
mad r0.y, r0, c20.x, r0.x
mad oT1.xy, v2, c16.x, r0
mov oPos, r1
mov oT5.zw, r1
mul r1.xyz, v1, c12.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, -r0, c9
dp3 oT3.z, r1, c6
dp3 oT3.y, r1, c5
dp3 oT3.x, r1, c4
mad oT0.xy, v2, c13, c13.zwzw
mov oT1.zw, c20.y
mad oT4.xy, v3, c14, c14.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 240
Vector 176 [_MainTex_ST]
Vector 192 [unity_LightmapST]
Float 208 [_AnimSpeed]
Float 212 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedebfjdeapmmhkfljfanpppllnpfagdmfnabaaaaaacmagaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklfdeieefcgaaeaaaaeaaaabaabiabaaaafjaaaaaeegiocaaaaaaaaaaa
aoaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadpccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaalaaaaaa
ogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaaenaaaaagbcaabaaa
abaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaacaaaaaa
akiacaaaaaaaaaaaanaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaa
acaaaaaaakaabaaaabaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaak
dccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaaanaaaaaaegaabaaa
acaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaj
hccabaaaadaaaaaaegacbaiaebaaaaaaabaaaaaaegiccaaaabaaaaaaaeaaaaaa
diaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaa
diaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaaklcaabaaaabaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaabaaaaaa
egaibaaaacaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgakbaaaabaaaaaaegadbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
afaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 240
Vector 176 [_MainTex_ST]
Vector 192 [unity_LightmapST]
Float 208 [_AnimSpeed]
Float 212 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedfooadmhlpbbgfidjepidkokahkgdbcnhabaaaaaahaajaaaaaeaaaaaa
daaaaaaahaadaaaaniahaaaakaaiaaaaebgpgodjdiadaaaadiadaaaaaaacpopp
miacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaalaa
adaaabaaaaaaaaaaabaaaaaaabaaaeaaaaaaaaaaabaaaeaaacaaafaaaaaaaaaa
acaaaaaaaeaaahaaaaaaaaaaacaaamaaaeaaalaaaaaaaaaaacaabeaaabaaapaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafbaaaapkaidpjccdoaaaaaadpnlapmjea
nlapejmafbaaaaafbbaaapkamnmmemdoaaaaaaaaaaaaaaaaaaaaaaaafbaaaaaf
bcaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafbdaaapkaklkkkklm
aaaaaaloaaaaiadpaaaaaadpbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaaeaaaaaeaaaaabiaaaaaaajabaaaaaka
baaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaabiaaaaaaaiabaaakkka
baaappkacfaaaaaeabaaaciaaaaaaaiabcaaoekabdaaoekaaeaaaaaeaaaaabia
abaaffiabaaaffkabaaaffkaabaaaaacabaaabiaadaaaakaafaaaaadabaaabia
abaaaaiaaeaaaakaaeaaaaaeabaaaciaaaaaaaiabbaaaakaabaaaaiaaeaaaaae
abaaadoaadaaoejaadaaffkaabaaoeiaafaaaaadaaaaahiaaaaaffjaamaaoeka
aeaaaaaeaaaaahiaalaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiaanaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiaaoaaoekaaaaappjaaaaaoeiaacaaaaad
acaaahoaaaaaoeibafaaoekaafaaaaadaaaaahiaacaaoejaapaappkaafaaaaad
abaaahiaaaaaffiaamaaoekaaeaaaaaeaaaaaliaalaakekaaaaaaaiaabaakeia
aeaaaaaeadaaahoaanaaoekaaaaakkiaaaaapeiaaeaaaaaeaaaaamoaaeaabeja
acaabekaacaalekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapia
ahaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaakaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffia
agaaaakaafaaaaadabaaaiiaabaaaaiabaaaffkaafaaaaadabaaafiaaaaapeia
baaaffkaacaaaaadaeaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacaeaaamoaaaaaoeia
abaaaaacabaaamoabbaaffkappppaaaafdeieefcgaaeaaaaeaaaabaabiabaaaa
fjaaaaaeegiocaaaaaaaaaaaaoaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
mccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacadaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaa
amaaaaaaenaaaaagbcaabaaaabaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaaj
bcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadp
diaaaaajbcaabaaaacaaaaaaakiacaaaaaaaaaaaanaaaaaaakiacaaaabaaaaaa
aaaaaaaadcaaaaajccaabaaaacaaaaaaakaabaaaabaaaaaaabeaaaaamnmmemdo
akaabaaaacaaaaaadcaaaaakdccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaa
aaaaaaaaanaaaaaaegaabaaaacaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaabaaaaaaaaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaabaaaaaa
egiccaaaabaaaaaaaeaaaaaadiaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaa
pgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaabaaaaaaegiicaaaacaaaaaa
amaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaacaaaaaaaoaaaaaakgakbaaaabaaaaaaegadbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaafaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
afaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
kbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaa
ljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [_ProjectionParams]
Vector 12 [unity_Scale]
Vector 13 [_MainTex_ST]
Vector 14 [unity_LightmapST]
Float 15 [_AnimSpeed]
Float 16 [_Tiling]
"!!ARBvp1.0
PARAM c[22] = { { 0.5, 24.980801, -24.980801, 0.15915491 },
		state.matrix.mvp,
		program.local[5..16],
		{ 0, 0.5, 1, 0.25 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -1, 1, -9, 0.75 },
		{ 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
MUL R0.x, vertex.position, c[0].w;
ADD R0.x, R0, -c[17].w;
FRC R0.w, R0.x;
ADD R0.xyz, -R0.w, c[17];
MUL R0.xyz, R0, R0;
MUL R1.xyz, R0, c[0].yzyw;
ADD R1.xyz, R1, c[18].xyxw;
MAD R1.xyz, R1, R0, c[18].zwzw;
MAD R1.xyz, R1, R0, c[19].xyxw;
MAD R1.xyz, R1, R0, c[19].zwzw;
MAD R0.xyz, R1, R0, c[20].xyxw;
SLT R1.x, R0.w, c[17].w;
SGE R1.yz, R0.w, c[20].xzww;
DP3 R1.y, R1, c[20].xyxw;
DP3 R0.x, R0, -R1;
MOV R0.w, c[15].x;
MUL R2.x, R0.w, c[9];
MAD R0.x, R0, c[0], c[0];
MAD R2.y, R0.x, c[21].x, R2.x;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[11].x;
ADD result.texcoord[5].xy, R1, R1.z;
MUL R1.xyz, vertex.normal, c[12].w;
MOV result.texcoord[5].zw, R0;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[16].x, R2;
ADD result.texcoord[2].xyz, -R0, c[10];
DP3 result.texcoord[3].z, R1, c[7];
DP3 result.texcoord[3].y, R1, c[6];
DP3 result.texcoord[3].x, R1, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MOV result.texcoord[1].zw, c[17].x;
MAD result.texcoord[4].xy, vertex.texcoord[1], c[14], c[14].zwzw;
END
# 40 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 12 [unity_Scale]
Vector 13 [_MainTex_ST]
Vector 14 [unity_LightmapST]
Float 15 [_AnimSpeed]
Float 16 [_Tiling]
"vs_2_0
def c17, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c18, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c19, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c20, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
mad r0.x, v0, c19, c19.y
frc r0.x, r0
mad r1.z, r0.x, c19, c19.w
sincos r0.xy, r1.z, c18.xyzw, c17.xyzw
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c17.w
mov r0.z, r2.x
mul r0.w, r2.y, c10.x
mad oT5.xy, r2.z, c11.zwzw, r0.zwzw
mov r0.x, c8
mul r0.x, c15, r0
mad r0.y, r0, c17.w, c17.w
mad r0.y, r0, c20.x, r0.x
mad oT1.xy, v2, c16.x, r0
mov oPos, r1
mov oT5.zw, r1
mul r1.xyz, v1, c12.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT2.xyz, -r0, c9
dp3 oT3.z, r1, c6
dp3 oT3.y, r1, c5
dp3 oT3.x, r1, c4
mad oT0.xy, v2, c13, c13.zwzw
mov oT1.zw, c20.y
mad oT4.xy, v3, c14, c14.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 240
Vector 176 [_MainTex_ST]
Vector 192 [unity_LightmapST]
Float 208 [_AnimSpeed]
Float 212 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedebfjdeapmmhkfljfanpppllnpfagdmfnabaaaaaacmagaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklfdeieefcgaaeaaaaeaaaabaabiabaaaafjaaaaaeegiocaaaaaaaaaaa
aoaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadpccabaaaafaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaalaaaaaa
ogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaaenaaaaagbcaabaaa
abaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaacaaaaaa
akiacaaaaaaaaaaaanaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaa
acaaaaaaakaabaaaabaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaak
dccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaaanaaaaaaegaabaaa
acaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaj
hccabaaaadaaaaaaegacbaiaebaaaaaaabaaaaaaegiccaaaabaaaaaaaeaaaaaa
diaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaa
diaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaaklcaabaaaabaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaabaaaaaa
egaibaaaacaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgakbaaaabaaaaaaegadbaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
afaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 240
Vector 176 [_MainTex_ST]
Vector 192 [unity_LightmapST]
Float 208 [_AnimSpeed]
Float 212 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedfooadmhlpbbgfidjepidkokahkgdbcnhabaaaaaahaajaaaaaeaaaaaa
daaaaaaahaadaaaaniahaaaakaaiaaaaebgpgodjdiadaaaadiadaaaaaaacpopp
miacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaalaa
adaaabaaaaaaaaaaabaaaaaaabaaaeaaaaaaaaaaabaaaeaaacaaafaaaaaaaaaa
acaaaaaaaeaaahaaaaaaaaaaacaaamaaaeaaalaaaaaaaaaaacaabeaaabaaapaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafbaaaapkaidpjccdoaaaaaadpnlapmjea
nlapejmafbaaaaafbbaaapkamnmmemdoaaaaaaaaaaaaaaaaaaaaaaaafbaaaaaf
bcaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafbdaaapkaklkkkklm
aaaaaaloaaaaiadpaaaaaadpbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaaeaaaaaeaaaaabiaaaaaaajabaaaaaka
baaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaabiaaaaaaaiabaaakkka
baaappkacfaaaaaeabaaaciaaaaaaaiabcaaoekabdaaoekaaeaaaaaeaaaaabia
abaaffiabaaaffkabaaaffkaabaaaaacabaaabiaadaaaakaafaaaaadabaaabia
abaaaaiaaeaaaakaaeaaaaaeabaaaciaaaaaaaiabbaaaakaabaaaaiaaeaaaaae
abaaadoaadaaoejaadaaffkaabaaoeiaafaaaaadaaaaahiaaaaaffjaamaaoeka
aeaaaaaeaaaaahiaalaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiaanaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiaaoaaoekaaaaappjaaaaaoeiaacaaaaad
acaaahoaaaaaoeibafaaoekaafaaaaadaaaaahiaacaaoejaapaappkaafaaaaad
abaaahiaaaaaffiaamaaoekaaeaaaaaeaaaaaliaalaakekaaaaaaaiaabaakeia
aeaaaaaeadaaahoaanaaoekaaaaakkiaaaaapeiaaeaaaaaeaaaaamoaaeaabeja
acaabekaacaalekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapia
ahaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaakaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffia
agaaaakaafaaaaadabaaaiiaabaaaaiabaaaffkaafaaaaadabaaafiaaaaapeia
baaaffkaacaaaaadaeaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacaeaaamoaaaaaoeia
abaaaaacabaaamoabbaaffkappppaaaafdeieefcgaaeaaaaeaaaabaabiabaaaa
fjaaaaaeegiocaaaaaaaaaaaaoaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
mccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacadaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaa
amaaaaaaenaaaaagbcaabaaaabaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaaj
bcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadp
diaaaaajbcaabaaaacaaaaaaakiacaaaaaaaaaaaanaaaaaaakiacaaaabaaaaaa
aaaaaaaadcaaaaajccaabaaaacaaaaaaakaabaaaabaaaaaaabeaaaaamnmmemdo
akaabaaaacaaaaaadcaaaaakdccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaa
aaaaaaaaanaaaaaaegaabaaaacaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgbfbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaabaaaaaaaaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaabaaaaaa
egiccaaaabaaaaaaaeaaaaaadiaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaa
pgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaabaaaaaaegiicaaaacaaaaaa
amaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaacaaaaaaaoaaaaaakgakbaaaabaaaaaaegadbaaaabaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaafaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
afaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
kbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaa
ljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [unity_4LightPosX0]
Vector 12 [unity_4LightPosY0]
Vector 13 [unity_4LightPosZ0]
Vector 14 [unity_4LightAtten0]
Vector 15 [unity_LightColor0]
Vector 16 [unity_LightColor1]
Vector 17 [unity_LightColor2]
Vector 18 [unity_LightColor3]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Float 28 [_AnimSpeed]
Float 29 [_Tiling]
"!!ARBvp1.0
PARAM c[34] = { { 0.15915491, 0.25, 24.980801, -24.980801 },
		state.matrix.mvp,
		program.local[5..29],
		{ 0, 0.5, 1, -1 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -9, 0.75, 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MUL R3.xyz, vertex.normal, c[26].w;
DP3 R5.x, R3, c[5];
DP4 R4.zw, vertex.position, c[6];
ADD R2, -R4.z, c[12];
DP3 R4.z, R3, c[6];
DP4 R3.w, vertex.position, c[5];
MUL R0, R4.z, R2;
ADD R1, -R3.w, c[11];
MUL R2, R2, R2;
MOV R5.y, R4.z;
MOV R5.w, c[30].z;
DP4 R4.xy, vertex.position, c[7];
MAD R0, R5.x, R1, R0;
MAD R2, R1, R1, R2;
ADD R1, -R4.x, c[13];
DP3 R4.x, R3, c[7];
MAD R2, R1, R1, R2;
MAD R0, R4.x, R1, R0;
MUL R1, R2, c[14];
ADD R1, R1, c[30].z;
MOV R5.z, R4.x;
RSQ R2.x, R2.x;
RSQ R2.y, R2.y;
RSQ R2.w, R2.w;
RSQ R2.z, R2.z;
MUL R0, R0, R2;
MUL R2, R5.xyzz, R5.yzzx;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[30].x;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[16];
MAD R1.xyz, R0.x, c[15], R1;
MAD R0.xyz, R0.z, c[17], R1;
MAD R0.xyz, R0.w, c[18], R0;
MAD R0.w, vertex.position.x, c[0].x, -c[0].y;
FRC R0.w, R0;
ADD R3.xyz, -R0.w, c[30];
MUL R1.w, R4.z, R4.z;
MUL R3.xyz, R3, R3;
DP4 R1.z, R5, c[21];
DP4 R1.y, R5, c[20];
DP4 R1.x, R5, c[19];
DP4 R5.w, R2, c[24];
DP4 R5.z, R2, c[23];
DP4 R5.y, R2, c[22];
MUL R2.xyz, R3, c[0].zwzw;
ADD R2.xyz, R2, c[31].xyxw;
MAD R2.xyz, R2, R3, c[31].zwzw;
MAD R2.xyz, R2, R3, c[32].xyxw;
MAD R2.xyz, R2, R3, c[32].zwzw;
MAD R2.xyz, R2, R3, c[30].wzww;
SLT R3.x, R0.w, c[0].y;
SGE R3.yz, R0.w, c[33].xxyw;
ADD R1.xyz, R1, R5.yzww;
MAD R1.w, R5.x, R5.x, -R1;
MUL R5.yzw, R1.w, c[25].xxyz;
DP3 R3.y, R3, c[30].wzww;
DP3 R1.w, R2, -R3;
MOV R0.w, c[28].x;
MUL R2.x, R0.w, c[9];
ADD R1.xyz, R1, R5.yzww;
MAD R0.w, R1, c[30].y, c[30].y;
MAD R2.y, R0.w, c[33].z, R2.x;
MOV R3.x, R4.w;
MOV R3.y, R4;
ADD result.texcoord[4].xyz, R1, R0;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[29].x, R2;
ADD result.texcoord[2].xyz, -R3.wxyw, c[10];
MOV result.texcoord[3].z, R4.x;
MOV result.texcoord[3].y, R4.z;
MOV result.texcoord[3].x, R5;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
MOV result.texcoord[1].zw, c[30].x;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 80 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_4LightPosX0]
Vector 11 [unity_4LightPosY0]
Vector 12 [unity_4LightPosZ0]
Vector 13 [unity_4LightAtten0]
Vector 14 [unity_LightColor0]
Vector 15 [unity_LightColor1]
Vector 16 [unity_LightColor2]
Vector 17 [unity_LightColor3]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
Vector 26 [_MainTex_ST]
Float 27 [_AnimSpeed]
Float 28 [_Tiling]
"vs_2_0
def c29, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c30, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c31, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c32, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c25.w
dp3 r5.x, r3, c4
dp4 r4.zw, v0, c5
add r2, -r4.z, c11
dp3 r4.z, r3, c5
dp3 r3.z, r3, c6
dp4 r3.w, v0, c4
mul r0, r4.z, r2
add r1, -r3.w, c10
dp4 r4.xy, v0, c6
mul r2, r2, r2
mov r5.y, r4.z
mov r5.z, r3
mov r5.w, c29.z
mad r0, r5.x, r1, r0
mad r2, r1, r1, r2
add r1, -r4.x, c12
mad r2, r1, r1, r2
mad r0, r3.z, r1, r0
mul r1, r2, c13
add r1, r1, c29.z
rsq r2.x, r2.x
rsq r2.y, r2.y
rsq r2.z, r2.z
rsq r2.w, r2.w
mul r0, r0, r2
dp4 r2.z, r5, c20
dp4 r2.y, r5, c19
dp4 r2.x, r5, c18
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c32.y
mul r0, r0, r1
mul r1.xyz, r0.y, c15
mad r1.xyz, r0.x, c14, r1
mad r0.xyz, r0.z, c16, r1
mad r1.xyz, r0.w, c17, r0
mul r0, r5.xyzz, r5.yzzx
mul r1.w, r4.z, r4.z
dp4 r5.w, r0, c23
dp4 r5.y, r0, c21
dp4 r5.z, r0, c22
mad r0.w, v0.x, c31.x, c31.y
add r0.xyz, r2, r5.yzww
mad r1.w, r5.x, r5.x, -r1
mul r2.xyz, r1.w, c24
frc r0.w, r0
add r2.xyz, r0, r2
mad r1.w, r0, c31.z, c31
sincos r0.xy, r1.w, c30.xyzw, c29.xyzw
mov r0.x, c8
mul r0.x, c27, r0
mad r0.y, r0, c29.w, c29.w
mad r0.y, r0, c32.x, r0.x
mov r3.x, r4.w
mov r3.y, r4
add oT4.xyz, r2, r1
mad oT1.xy, v2, c28.x, r0
add oT2.xyz, -r3.wxyw, c9
mov oT3.z, r3
mov oT3.y, r4.z
mov oT3.x, r5
mad oT0.xy, v2, c26, c26.zwzw
mov oT1.zw, c32.y
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Vector 112 [_MainTex_ST]
Float 128 [_AnimSpeed]
Float 132 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedhcjmciocdhjgpepholbbdpmfenpbmhbcabaaaaaajiajaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklfdeieefcoeahaaaaeaaaabaapjabaaaafjaaaaae
egiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacagaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaaenaaaaagbcaabaaa
aaaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaabaaaaaa
akiacaaaaaaaaaaaaiaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaa
abaaaaaaakaabaaaaaaaaaaaabeaaaaamnmmemdoakaabaaaabaaaaaadcaaaaak
dccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaaaaaaaaaaaiaaaaaaegaabaaa
abaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaaj
hccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaeaaaaaa
diaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaa
diaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaaklcaabaaaabaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaabaaaaaa
egaibaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgakbaaaabaaaaaaegadbaaaabaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaa
abaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaa
acaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaaiccaabaaa
acaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaaiecaabaaa
acaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaadiaaaaahpcaabaaa
adaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaa
egiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaa
egiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaa
egiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaaaaaaaaahhcaabaaaacaaaaaa
egacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaahicaabaaaaaaaaaaabkaabaaa
abaaaaaabkaabaaaabaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaaabaaaaaa
akaabaaaabaaaaaadkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaacaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaaaaaaaaaj
pcaabaaaadaaaaaafgafbaiaebaaaaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
diaaaaahpcaabaaaaeaaaaaafgafbaaaabaaaaaaegaobaaaadaaaaaadiaaaaah
pcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaa
afaaaaaaagaabaiaebaaaaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaaj
pcaabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaaegiocaaaacaaaaaaaeaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaaabaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaa
egaobaaaadaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaaaaaaaaaegaobaaa
aaaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
kgakbaaaabaaaaaaegaobaaaaeaaaaaaeeaaaaafpcaabaaaabaaaaaaegaobaaa
adaaaaaadcaaaaanpcaabaaaadaaaaaaegaobaaaadaaaaaaegiocaaaacaaaaaa
afaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaa
adaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaadaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadeaaaaak
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaadaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaaahaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaiaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaa
afaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Vector 112 [_MainTex_ST]
Float 128 [_AnimSpeed]
Float 132 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedhlmmjkfmdeidpdojdnbkciogcckioloaabaaaaaaaeapaaaaaeaaaaaa
daaaaaaajiafaaaaieanaaaaemaoaaaaebgpgodjgaafaaaagaafaaaaaaacpopp
niaeaaaaiiaaaaaaaiaaceaaaaaaieaaaaaaieaaaaaaceaaabaaieaaaaaaahaa
acaaabaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaabaaaeaaabaaaeaaaaaaaaaa
acaaacaaaiaaafaaaaaaaaaaacaacgaaahaaanaaaaaaaaaaadaaaaaaaeaabeaa
aaaaaaaaadaaamaaaeaabiaaaaaaaaaaadaabeaaabaabmaaaaaaaaaaaaaaaaaa
aaacpoppfbaaaaafbnaaapkaidpjccdoaaaaaadpnlapmjeanlapejmafbaaaaaf
boaaapkamnmmemdoaaaaiadpaaaaaaaaaaaaaaaafbaaaaafbpaaapkaabannalf
gballglhklkkckdlijiiiidjfbaaaaafcaaaapkaklkkkklmaaaaaaloaaaaiadp
aaaaaadpbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoekaabaaookaaeaaaaae
aaaaabiaaaaaaajabnaaaakabnaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaae
aaaaabiaaaaaaaiabnaakkkabnaappkacfaaaaaeabaaaciaaaaaaaiabpaaoeka
caaaoekaaeaaaaaeaaaaabiaabaaffiabnaaffkabnaaffkaabaaaaacabaaabia
acaaaakaafaaaaadabaaabiaabaaaaiaadaaaakaaeaaaaaeabaaaciaaaaaaaia
boaaaakaabaaaaiaaeaaaaaeabaaadoaadaaoejaacaaffkaabaaoeiaafaaaaad
aaaaahiaaaaaffjabjaaoekaaeaaaaaeaaaaahiabiaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaahiabkaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiablaaoeka
aaaappjaaaaaoeiaacaaaaadacaaahoaaaaaoeibaeaaoekaacaaaaadabaaapia
aaaaffibagaaoekaafaaaaadacaaapiaabaaoeiaabaaoeiaacaaaaadadaaapia
aaaaaaibafaaoekaacaaaaadaaaaapiaaaaakkibahaaoekaaeaaaaaeacaaapia
adaaoeiaadaaoeiaacaaoeiaaeaaaaaeacaaapiaaaaaoeiaaaaaoeiaacaaoeia
ahaaaaacaeaaabiaacaaaaiaahaaaaacaeaaaciaacaaffiaahaaaaacaeaaaeia
acaakkiaahaaaaacaeaaaiiaacaappiaabaaaaacafaaaciaboaaffkaaeaaaaae
acaaapiaacaaoeiaaiaaoekaafaaffiaafaaaaadafaaahiaacaaoejabmaappka
afaaaaadagaaahiaafaaffiabjaaoekaaeaaaaaeafaaaliabiaakekaafaaaaia
agaakeiaaeaaaaaeafaaahiabkaaoekaafaakkiaafaapeiaafaaaaadabaaapia
abaaoeiaafaaffiaaeaaaaaeabaaapiaadaaoeiaafaaaaiaabaaoeiaaeaaaaae
aaaaapiaaaaaoeiaafaakkiaabaaoeiaafaaaaadaaaaapiaaeaaoeiaaaaaoeia
alaaaaadaaaaapiaaaaaoeiaboaakkkaagaaaaacabaaabiaacaaaaiaagaaaaac
abaaaciaacaaffiaagaaaaacabaaaeiaacaakkiaagaaaaacabaaaiiaacaappia
afaaaaadaaaaapiaaaaaoeiaabaaoeiaafaaaaadabaaahiaaaaaffiaakaaoeka
aeaaaaaeabaaahiaajaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiaalaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaahiaamaaoekaaaaappiaaaaaoeiaabaaaaac
afaaaiiaboaaffkaajaaaaadabaaabiaanaaoekaafaaoeiaajaaaaadabaaacia
aoaaoekaafaaoeiaajaaaaadabaaaeiaapaaoekaafaaoeiaafaaaaadacaaapia
afaacjiaafaakeiaajaaaaadadaaabiabaaaoekaacaaoeiaajaaaaadadaaacia
bbaaoekaacaaoeiaajaaaaadadaaaeiabcaaoekaacaaoeiaacaaaaadabaaahia
abaaoeiaadaaoeiaafaaaaadaaaaaiiaafaaffiaafaaffiaaeaaaaaeaaaaaiia
afaaaaiaafaaaaiaaaaappibabaaaaacadaaahoaafaaoeiaaeaaaaaeabaaahia
bdaaoekaaaaappiaabaaoeiaacaaaaadaeaaahoaaaaaoeiaabaaoeiaafaaaaad
aaaaapiaaaaaffjabfaaoekaaeaaaaaeaaaaapiabeaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiabgaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabhaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacabaaamoaboaakkkappppaaaafdeieefcoeahaaaa
eaaaabaapjabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaa
adaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
dccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacagaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
adaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaa
ahaaaaaaenaaaaagbcaabaaaaaaaaaaaaanaaaaaakbabaaaaaaaaaaadcaaaaaj
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadp
diaaaaajbcaabaaaabaaaaaaakiacaaaaaaaaaaaaiaaaaaaakiacaaaabaaaaaa
aaaaaaaadcaaaaajccaabaaaabaaaaaaakaabaaaaaaaaaaaabeaaaaamnmmemdo
akaabaaaabaaaaaadcaaaaakdccabaaaacaaaaaaegbabaaaadaaaaaafgifcaaa
aaaaaaaaaiaaaaaaegaabaaaabaaaaaadgaaaaaimccabaaaacaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaaaaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaa
egiccaaaabaaaaaaaeaaaaaadiaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaa
pgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaabaaaaaaegiicaaaadaaaaaa
amaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaadaaaaaaaoaaaaaakgakbaaaabaaaaaaegadbaaaabaaaaaadgaaaaaf
hccabaaaaeaaaaaaegacbaaaabaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaa
abaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaa
abaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaa
abaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaa
bbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaa
bbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaa
bbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaa
aaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaah
icaabaaaaaaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaakicaabaaa
aaaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaadkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaaaaaaaaa
egacbaaaacaaaaaaaaaaaaajpcaabaaaadaaaaaafgafbaiaebaaaaaaaaaaaaaa
egiocaaaacaaaaaaadaaaaaadiaaaaahpcaabaaaaeaaaaaafgafbaaaabaaaaaa
egaobaaaadaaaaaadiaaaaahpcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaa
adaaaaaaaaaaaaajpcaabaaaafaaaaaaagaabaiaebaaaaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaaaaaaaaajpcaabaaaaaaaaaaakgakbaiaebaaaaaaaaaaaaaa
egiocaaaacaaaaaaaeaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaa
agaabaaaabaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaa
afaaaaaaegaobaaaafaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaaadaaaaaa
egaobaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaaaaaaaaakgakbaaaabaaaaaaegaobaaaaeaaaaaaeeaaaaaf
pcaabaaaabaaaaaaegaobaaaadaaaaaadcaaaaanpcaabaaaadaaaaaaegaobaaa
adaaaaaaegiocaaaacaaaaaaafaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadp
aaaaiadpaoaaaaakpcaabaaaadaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadp
aaaaiadpegaobaaaadaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
egaobaaaabaaaaaadeaaaaakpcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
adaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiccaaaacaaaaaaahaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
agaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaiaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaa
doaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_Time]
Vector 10 [_WorldSpaceCameraPos]
Vector 11 [_ProjectionParams]
Vector 12 [unity_4LightPosX0]
Vector 13 [unity_4LightPosY0]
Vector 14 [unity_4LightPosZ0]
Vector 15 [unity_4LightAtten0]
Vector 16 [unity_LightColor0]
Vector 17 [unity_LightColor1]
Vector 18 [unity_LightColor2]
Vector 19 [unity_LightColor3]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Float 29 [_AnimSpeed]
Float 30 [_Tiling]
"!!ARBvp1.0
PARAM c[35] = { { 0.15915491, 0.25, 24.980801, -24.980801 },
		state.matrix.mvp,
		program.local[5..30],
		{ 0, 0.5, 1, -1 },
		{ -60.145809, 60.145809, 85.453789, -85.453789 },
		{ -64.939346, 64.939346, 19.73921, -19.73921 },
		{ -9, 0.75, 0.2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MUL R3.xyz, vertex.normal, c[27].w;
DP3 R5.x, R3, c[5];
DP4 R4.zw, vertex.position, c[6];
ADD R2, -R4.z, c[13];
DP3 R4.z, R3, c[6];
DP4 R3.w, vertex.position, c[5];
MUL R0, R4.z, R2;
ADD R1, -R3.w, c[12];
MUL R2, R2, R2;
MOV R5.y, R4.z;
MOV R5.w, c[31].z;
DP4 R4.xy, vertex.position, c[7];
MAD R0, R5.x, R1, R0;
MAD R2, R1, R1, R2;
ADD R1, -R4.x, c[14];
DP3 R4.x, R3, c[7];
MAD R2, R1, R1, R2;
MAD R0, R4.x, R1, R0;
MUL R1, R2, c[15];
ADD R1, R1, c[31].z;
MOV R5.z, R4.x;
RSQ R2.x, R2.x;
RSQ R2.y, R2.y;
RSQ R2.w, R2.w;
RSQ R2.z, R2.z;
MUL R0, R0, R2;
MUL R2, R5.xyzz, R5.yzzx;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[31].x;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[17];
MAD R1.xyz, R0.x, c[16], R1;
MAD R0.xyz, R0.z, c[18], R1;
MAD R0.xyz, R0.w, c[19], R0;
MAD R0.w, vertex.position.x, c[0].x, -c[0].y;
FRC R0.w, R0;
MUL R1.w, R4.z, R4.z;
DP4 R1.z, R5, c[22];
DP4 R1.y, R5, c[21];
DP4 R1.x, R5, c[20];
DP4 R5.w, R2, c[25];
DP4 R5.z, R2, c[24];
ADD R3.xyz, -R0.w, c[31];
DP4 R5.y, R2, c[23];
MUL R2.xyz, R3, R3;
ADD R3.xyz, R1, R5.yzww;
MUL R1.xyz, R2, c[0].zwzw;
ADD R1.xyz, R1, c[32].xyxw;
MAD R1.xyz, R1, R2, c[32].zwzw;
MAD R1.xyz, R1, R2, c[33].xyxw;
MAD R1.w, R5.x, R5.x, -R1;
MUL R5.yzw, R1.w, c[26].xxyz;
ADD R3.xyz, R3, R5.yzww;
ADD result.texcoord[4].xyz, R3, R0;
MAD R1.xyz, R1, R2, c[33].zwzw;
MAD R0.xyz, R1, R2, c[31].wzww;
SLT R1.x, R0.w, c[0].y;
SGE R1.yz, R0.w, c[34].xxyw;
DP3 R1.y, R1, c[31].wzww;
DP3 R0.x, R0, -R1;
MOV R0.w, c[29].x;
MUL R2.x, R0.w, c[9];
MAD R0.x, R0, c[31].y, c[31].y;
MAD R2.y, R0.x, c[34].z, R2.x;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[31].y;
MUL R1.y, R1, c[11].x;
MOV R3.x, R4.w;
MOV R3.y, R4;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[30].x, R2;
ADD result.texcoord[5].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[5].zw, R0;
ADD result.texcoord[2].xyz, -R3.wxyw, c[10];
MOV result.texcoord[3].z, R4.x;
MOV result.texcoord[3].y, R4.z;
MOV result.texcoord[3].x, R5;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
MOV result.texcoord[1].zw, c[31].x;
END
# 85 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_Time]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [_ScreenParams]
Vector 12 [unity_4LightPosX0]
Vector 13 [unity_4LightPosY0]
Vector 14 [unity_4LightPosZ0]
Vector 15 [unity_4LightAtten0]
Vector 16 [unity_LightColor0]
Vector 17 [unity_LightColor1]
Vector 18 [unity_LightColor2]
Vector 19 [unity_LightColor3]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Float 29 [_AnimSpeed]
Float 30 [_Tiling]
"vs_2_0
def c31, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c32, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c33, 0.15915491, 0.50000000, 6.28318501, -3.14159298
def c34, 0.20000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c27.w
dp3 r5.x, r3, c4
dp4 r4.zw, v0, c5
add r2, -r4.z, c13
dp3 r4.z, r3, c5
dp3 r3.z, r3, c6
dp4 r3.w, v0, c4
mul r0, r4.z, r2
add r1, -r3.w, c12
dp4 r4.xy, v0, c6
mul r2, r2, r2
mov r5.y, r4.z
mov r5.z, r3
mov r5.w, c31.z
mad r0, r5.x, r1, r0
mad r2, r1, r1, r2
add r1, -r4.x, c14
mad r2, r1, r1, r2
mad r0, r3.z, r1, r0
mul r1, r2, c15
add r1, r1, c31.z
rsq r2.x, r2.x
rsq r2.y, r2.y
rsq r2.z, r2.z
rsq r2.w, r2.w
mul r0, r0, r2
dp4 r2.z, r5, c22
dp4 r2.y, r5, c21
dp4 r2.x, r5, c20
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c34.y
mul r0, r0, r1
mul r1.xyz, r0.y, c17
mad r1.xyz, r0.x, c16, r1
mad r0.xyz, r0.z, c18, r1
mad r1.xyz, r0.w, c19, r0
mul r0, r5.xyzz, r5.yzzx
dp4 r5.w, r0, c25
dp4 r5.z, r0, c24
dp4 r5.y, r0, c23
mul r1.w, r4.z, r4.z
mad r0.w, r5.x, r5.x, -r1
add r0.xyz, r2, r5.yzww
mul r2.xyz, r0.w, c26
add r0.xyz, r0, r2
add oT4.xyz, r0, r1
mad r0.w, v0.x, c33.x, c33.y
frc r0.w, r0
mad r1.z, r0.w, c33, c33.w
sincos r0.xy, r1.z, c32.xyzw, c31.xyzw
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r2.xyz, r1.xyww, c31.w
mul r0.w, r2.y, c10.x
mov r0.z, r2.x
mov r0.x, c8
mul r0.x, c29, r0
mad r0.y, r0, c31.w, c31.w
mad r0.y, r0, c34.x, r0.x
mov r3.x, r4.w
mov r3.y, r4
mad oT5.xy, r2.z, c11.zwzw, r0.zwzw
mov oPos, r1
mad oT1.xy, v2, c30.x, r0
mov oT5.zw, r1
add oT2.xyz, -r3.wxyw, c9
mov oT3.z, r3
mov oT3.y, r4.z
mov oT3.x, r5
mad oT0.xy, v2, c28, c28.zwzw
mov oT1.zw, c34.y
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 224
Vector 176 [_MainTex_ST]
Float 192 [_AnimSpeed]
Float 196 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedldejmaoodjmnkliibnpoipmeeinemkogabaaaaaaeiakaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklfdeieefchmaiaaaaeaaaabaabpacaaaafjaaaaaeegiocaaaaaaaaaaa
anaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacahaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
alaaaaaaogikcaaaaaaaaaaaalaaaaaaenaaaaagbcaabaaaabaaaaaaaanaaaaa
akbabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaa
aaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaacaaaaaaakiacaaaaaaaaaaa
amaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaaacaaaaaaakaabaaa
abaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaakdccabaaaacaaaaaa
egbabaaaadaaaaaafgifcaaaaaaaaaaaamaaaaaaegaabaaaacaaaaaadgaaaaai
mccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaai
hcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaajhccabaaaadaaaaaa
egacbaiaebaaaaaaabaaaaaaegiccaaaabaaaaaaaeaaaaaadiaaaaaihcaabaaa
acaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
adaaaaaafgafbaaaacaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
acaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaacaaaaaaegaibaaaadaaaaaa
dcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaacaaaaaa
egadbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadgaaaaaf
icaabaaaacaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaacaaaaaadiaaaaahpcaabaaaaeaaaaaajgacbaaa
acaaaaaaegakbaaaacaaaaaabbaaaaaibcaabaaaafaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaaeaaaaaabbaaaaaiccaabaaaafaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaaeaaaaaabbaaaaaiecaabaaaafaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaaeaaaaaaaaaaaaahhcaabaaaadaaaaaaegacbaaaadaaaaaa
egacbaaaafaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaacaaaaaabkaabaaa
acaaaaaadcaaaaakicaabaaaabaaaaaaakaabaaaacaaaaaaakaabaaaacaaaaaa
dkaabaiaebaaaaaaabaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaacaaaaaa
cmaaaaaapgapbaaaabaaaaaaegacbaaaadaaaaaaaaaaaaajpcaabaaaaeaaaaaa
fgafbaiaebaaaaaaabaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaahpcaabaaa
afaaaaaafgafbaaaacaaaaaaegaobaaaaeaaaaaadiaaaaahpcaabaaaaeaaaaaa
egaobaaaaeaaaaaaegaobaaaaeaaaaaaaaaaaaajpcaabaaaagaaaaaaagaabaia
ebaaaaaaabaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaaabaaaaaa
kgakbaiaebaaaaaaabaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaajpcaabaaa
afaaaaaaegaobaaaagaaaaaaagaabaaaacaaaaaaegaobaaaafaaaaaadcaaaaaj
pcaabaaaaeaaaaaaegaobaaaagaaaaaaegaobaaaagaaaaaaegaobaaaaeaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaakgakbaaaacaaaaaa
egaobaaaafaaaaaaeeaaaaafpcaabaaaacaaaaaaegaobaaaaeaaaaaadcaaaaan
pcaabaaaaeaaaaaaegaobaaaaeaaaaaaegiocaaaacaaaaaaafaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaaeaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaaeaaaaaadiaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaadeaaaaakpcaabaaaabaaaaaa
egaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaah
pcaabaaaabaaaaaaegaobaaaaeaaaaaaegaobaaaabaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaaabaaaaaa
egacbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaajaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaa
akiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaagaaaaaa
kgaobaaaaaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaa
abaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 224
Vector 176 [_MainTex_ST]
Float 192 [_AnimSpeed]
Float 196 [_Tiling]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecednnphijplppgilhaikjbahpcpjkghicoeabaaaaaaaabaaaaaaeaaaaaa
daaaaaaaoeafaaaagiaoaaaadaapaaaaebgpgodjkmafaaaakmafaaaaaaacpopp
ceafaaaaiiaaaaaaaiaaceaaaaaaieaaaaaaieaaaaaaceaaabaaieaaaaaaalaa
acaaabaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaabaaaeaaacaaaeaaaaaaaaaa
acaaacaaaiaaagaaaaaaaaaaacaacgaaahaaaoaaaaaaaaaaadaaaaaaaeaabfaa
aaaaaaaaadaaamaaaeaabjaaaaaaaaaaadaabeaaabaabnaaaaaaaaaaaaaaaaaa
aaacpoppfbaaaaafboaaapkaidpjccdoaaaaaadpnlapmjeanlapejmafbaaaaaf
bpaaapkamnmmemdoaaaaiadpaaaaaaaaaaaaaaaafbaaaaafcaaaapkaabannalf
gballglhklkkckdlijiiiidjfbaaaaafcbaaapkaklkkkklmaaaaaaloaaaaiadp
aaaaaadpbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoekaabaaookaaeaaaaae
aaaaabiaaaaaaajaboaaaakaboaaffkabdaaaaacaaaaabiaaaaaaaiaaeaaaaae
aaaaabiaaaaaaaiaboaakkkaboaappkacfaaaaaeabaaaciaaaaaaaiacaaaoeka
cbaaoekaaeaaaaaeaaaaabiaabaaffiaboaaffkaboaaffkaabaaaaacabaaabia
acaaaakaafaaaaadabaaabiaabaaaaiaadaaaakaaeaaaaaeabaaaciaaaaaaaia
bpaaaakaabaaaaiaaeaaaaaeabaaadoaadaaoejaacaaffkaabaaoeiaafaaaaad
aaaaahiaaaaaffjabkaaoekaaeaaaaaeaaaaahiabjaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaahiablaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiabmaaoeka
aaaappjaaaaaoeiaacaaaaadacaaahoaaaaaoeibaeaaoekaacaaaaadabaaapia
aaaaffibahaaoekaafaaaaadacaaapiaabaaoeiaabaaoeiaacaaaaadadaaapia
aaaaaaibagaaoekaacaaaaadaaaaapiaaaaakkibaiaaoekaaeaaaaaeacaaapia
adaaoeiaadaaoeiaacaaoeiaaeaaaaaeacaaapiaaaaaoeiaaaaaoeiaacaaoeia
ahaaaaacaeaaabiaacaaaaiaahaaaaacaeaaaciaacaaffiaahaaaaacaeaaaeia
acaakkiaahaaaaacaeaaaiiaacaappiaabaaaaacafaaaciabpaaffkaaeaaaaae
acaaapiaacaaoeiaajaaoekaafaaffiaafaaaaadafaaahiaacaaoejabnaappka
afaaaaadagaaahiaafaaffiabkaaoekaaeaaaaaeafaaaliabjaakekaafaaaaia
agaakeiaaeaaaaaeafaaahiablaaoekaafaakkiaafaapeiaafaaaaadabaaapia
abaaoeiaafaaffiaaeaaaaaeabaaapiaadaaoeiaafaaaaiaabaaoeiaaeaaaaae
aaaaapiaaaaaoeiaafaakkiaabaaoeiaafaaaaadaaaaapiaaeaaoeiaaaaaoeia
alaaaaadaaaaapiaaaaaoeiabpaakkkaagaaaaacabaaabiaacaaaaiaagaaaaac
abaaaciaacaaffiaagaaaaacabaaaeiaacaakkiaagaaaaacabaaaiiaacaappia
afaaaaadaaaaapiaaaaaoeiaabaaoeiaafaaaaadabaaahiaaaaaffiaalaaoeka
aeaaaaaeabaaahiaakaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiaamaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaappiaaaaaoeiaabaaaaac
afaaaiiabpaaffkaajaaaaadabaaabiaaoaaoekaafaaoeiaajaaaaadabaaacia
apaaoekaafaaoeiaajaaaaadabaaaeiabaaaoekaafaaoeiaafaaaaadacaaapia
afaacjiaafaakeiaajaaaaadadaaabiabbaaoekaacaaoeiaajaaaaadadaaacia
bcaaoekaacaaoeiaajaaaaadadaaaeiabdaaoekaacaaoeiaacaaaaadabaaahia
abaaoeiaadaaoeiaafaaaaadaaaaaiiaafaaffiaafaaffiaaeaaaaaeaaaaaiia
afaaaaiaafaaaaiaaaaappibabaaaaacadaaahoaafaaoeiaaeaaaaaeabaaahia
beaaoekaaaaappiaabaaoeiaacaaaaadaeaaahoaaaaaoeiaabaaoeiaafaaaaad
aaaaapiaaaaaffjabgaaoekaaeaaaaaeaaaaapiabfaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiabhaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabiaaoeka
aaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaafaaaakaafaaaaadabaaaiia
abaaaaiaboaaffkaafaaaaadabaaafiaaaaapeiaboaaffkaacaaaaadafaaadoa
abaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacafaaamoaaaaaoeiaabaaaaacabaaamoabpaakkka
ppppaaaafdeieefchmaiaaaaeaaaabaabpacaaaafjaaaaaeegiocaaaaaaaaaaa
anaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacahaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
alaaaaaaogikcaaaaaaaaaaaalaaaaaaenaaaaagbcaabaaaabaaaaaaaanaaaaa
akbabaaaaaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaa
aaaaaadpabeaaaaaaaaaaadpdiaaaaajbcaabaaaacaaaaaaakiacaaaaaaaaaaa
amaaaaaaakiacaaaabaaaaaaaaaaaaaadcaaaaajccaabaaaacaaaaaaakaabaaa
abaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaakdccabaaaacaaaaaa
egbabaaaadaaaaaafgifcaaaaaaaaaaaamaaaaaaegaabaaaacaaaaaadgaaaaai
mccabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaai
hcaabaaaabaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaajhccabaaaadaaaaaa
egacbaiaebaaaaaaabaaaaaaegiccaaaabaaaaaaaeaaaaaadiaaaaaihcaabaaa
acaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
adaaaaaafgafbaaaacaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
acaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaacaaaaaaegaibaaaadaaaaaa
dcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaacaaaaaa
egadbaaaacaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaacaaaaaadgaaaaaf
icaabaaaacaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaacaaaaaadiaaaaahpcaabaaaaeaaaaaajgacbaaa
acaaaaaaegakbaaaacaaaaaabbaaaaaibcaabaaaafaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaaeaaaaaabbaaaaaiccaabaaaafaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaaeaaaaaabbaaaaaiecaabaaaafaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaaeaaaaaaaaaaaaahhcaabaaaadaaaaaaegacbaaaadaaaaaa
egacbaaaafaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaacaaaaaabkaabaaa
acaaaaaadcaaaaakicaabaaaabaaaaaaakaabaaaacaaaaaaakaabaaaacaaaaaa
dkaabaiaebaaaaaaabaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaacaaaaaa
cmaaaaaapgapbaaaabaaaaaaegacbaaaadaaaaaaaaaaaaajpcaabaaaaeaaaaaa
fgafbaiaebaaaaaaabaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaahpcaabaaa
afaaaaaafgafbaaaacaaaaaaegaobaaaaeaaaaaadiaaaaahpcaabaaaaeaaaaaa
egaobaaaaeaaaaaaegaobaaaaeaaaaaaaaaaaaajpcaabaaaagaaaaaaagaabaia
ebaaaaaaabaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaaabaaaaaa
kgakbaiaebaaaaaaabaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaajpcaabaaa
afaaaaaaegaobaaaagaaaaaaagaabaaaacaaaaaaegaobaaaafaaaaaadcaaaaaj
pcaabaaaaeaaaaaaegaobaaaagaaaaaaegaobaaaagaaaaaaegaobaaaaeaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaakgakbaaaacaaaaaa
egaobaaaafaaaaaaeeaaaaafpcaabaaaacaaaaaaegaobaaaaeaaaaaadcaaaaan
pcaabaaaaeaaaaaaegaobaaaaeaaaaaaegiocaaaacaaaaaaafaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaaeaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaaeaaaaaadiaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaadeaaaaakpcaabaaaabaaaaaa
egaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaah
pcaabaaaabaaaaaaegaobaaaaeaaaaaaegaobaaaabaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaabaaaaaaegacbaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaaabaaaaaa
egacbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaajaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaa
akiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaagaaaaaa
kgaobaaaaaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaa
abaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaa
laaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadamaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
lmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaa
agaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Float 2 [_StaticEmissionLM]
Float 3 [_DynamiEmissionLM]
Vector 4 [_Color]
Vector 5 [_StaticIllumColor]
Vector 6 [_DynamiIllumColor]
Float 7 [_Shininess]
Vector 8 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[10] = { program.local[0..8],
		{ 0.70703125, 0, 128, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TEX R0.xz, fragment.texcoord[0], texture[1], 2D;
TEX R2.z, fragment.texcoord[1], texture[1], 2D;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.y, R0.y;
MAD R3.xyz, R0.y, fragment.texcoord[2], c[9].xxyw;
DP3 R0.y, R3, R3;
RSQ R0.y, R0.y;
MUL R3.xyz, R0.y, R3;
DP3 R0.y, fragment.texcoord[3], R3;
MUL R3.xyz, R0.x, c[5];
DP3 R0.w, fragment.texcoord[3], c[0];
MAX R0.w, R0, c[9].y;
MUL R2.xyw, R0.w, c[1].xyzz;
MUL R1, R1, c[4];
MUL R1, R1, c[9].w;
MUL R2.xyw, R2, c[9].w;
MOV R0.w, c[9].z;
ADD R2.xyw, R2, fragment.texcoord[4].xyzz;
MUL R3.xyz, R3, c[2].x;
MAD R1.xyz, R1, R2.xyww, R3;
MAX R2.x, R0.y, c[9].y;
MUL R0.y, R2.z, c[3].x;
MUL R0.w, R0, c[7].x;
POW R0.w, R2.x, R0.w;
MUL R0.y, R0, R0.z;
MUL R2.xyz, R0.y, c[6];
MAD R0.xyz, R2, R0.x, R1;
MUL R0.w, R0, R1;
MAD result.color.xyz, R0.w, c[8], R0;
MOV result.color.w, R1;
END
# 31 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Float 2 [_StaticEmissionLM]
Float 3 [_DynamiEmissionLM]
Vector 4 [_Color]
Vector 5 [_StaticIllumColor]
Vector 6 [_DynamiIllumColor]
Float 7 [_Shininess]
Vector 8 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c9, 0.70703125, 0.00000000, 128.00000000, 2.00000000
dcl t0.xy
dcl t1.xy
dcl t2.xyz
dcl t3.xyz
dcl t4.xyz
texld r5, t1, s1
texld r4, t0, s1
texld r1, t0, s0
dp3_pp r0.x, t2, t2
mul r1, r1, c4
mul r1, r1, c9.w
mul r3.xyz, r4.x, c5
rsq_pp r0.x, r0.x
mov r2.xy, c9.x
mov r2.z, c9.y
mad_pp r2.xyz, r0.x, t2, r2
dp3_pp r0.x, r2, r2
rsq_pp r0.x, r0.x
mul_pp r2.xyz, r0.x, r2
dp3_pp r0.x, t3, c0
max_pp r0.x, r0, c9.y
mul_pp r0.xyz, r0.x, c1
mul_pp r0.xyz, r0, c9.w
add r0.xyz, r0, t4
mul r3.xyz, r3, c2.x
mad r3.xyz, r1, r0, r3
dp3_pp r0.x, t3, r2
mov r1.x, c7
max_pp r0.x, r0, c9.y
mul r1.x, c9.z, r1
pow r2.x, r0.x, r1.x
mul r0.x, r5.z, c3
mul r1.x, r0, r4.z
mov r0.x, r2.x
mul r1.xyz, r1.x, c6
mad r1.xyz, r1, r4.x, r3
mul r0.x, r0, r1.w
mov r0.w, r1
mad r0.xyz, r0.x, c8, r1
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
Float 48 [_StaticEmissionLM]
Float 52 [_DynamiEmissionLM]
Vector 64 [_Color]
Vector 80 [_StaticIllumColor]
Vector 96 [_DynamiIllumColor]
Float 136 [_Shininess]
Vector 144 [_SpecularColor]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedhpjppgokeeiffhflmajafjigipmkaapdabaaaaaaiaafaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgaaeaaaa
eaaaaaaabiabaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaa
abaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegiccaaaabaaaaaaaaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegbcbaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaa
egaobaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaaaaaaaaahpcaabaaaabaaaaaa
egaobaaaabaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaa
agaabaaaacaaaaaaegiccaaaaaaaaaaaafaaaaaadiaaaaaihcaabaaaadaaaaaa
egacbaaaadaaaaaaagiacaaaaaaaaaaaadaaaaaadcaaaaajhcaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaaaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaa
adaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaai
icaabaaaaaaaaaaackaabaaaadaaaaaabkiacaaaaaaaaaaaadaaaaaadiaaaaah
icaabaaaaaaaaaaackaabaaaacaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaapgapbaaaaaaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaajhcaabaaa
aaaaaaaaegacbaaaabaaaaaaagaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaa
pgapbaaaaaaaaaaaaceaaaaapdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaa
abaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
cpaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaa
ckiacaaaaaaaaaaaaiaaaaaaabeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaakaabaaaabaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaa
egiccaaaaaaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
Float 48 [_StaticEmissionLM]
Float 52 [_DynamiEmissionLM]
Vector 64 [_Color]
Vector 80 [_StaticIllumColor]
Vector 96 [_DynamiIllumColor]
Float 136 [_Shininess]
Vector 144 [_SpecularColor]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0_level_9_1
eefieceddpfpfballjcndhllckmdgglelncolndfabaaaaaacaaiaaaaaeaaaaaa
daaaaaaammacaaaadeahaaaaomahaaaaebgpgodjjeacaaaajeacaaaaaaacpppp
diacaaaafmaaaaaaaeaacmaaaaaafmaaaaaafmaaacaaceaaaaaafmaaaaaaaaaa
abababaaaaaaabaaabaaaaaaaaaaaaaaaaaaadaaaeaaabaaaaaaaaaaaaaaaiaa
acaaafaaaaaaaaaaabaaaaaaabaaahaaaaaaaaaaaaacppppfbaaaaafaiaaapka
aaaaaaaapdaedfdppdaedfdpaaaaaaedbpaaaaacaaaaaaiaaaaaadlabpaaaaac
aaaaaaiaabaaaplabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaiaadaachla
bpaaaaacaaaaaaiaaeaaahlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaaja
abaiapkaecaaaaadaaaaapiaaaaaoelaaaaioekaecaaaaadabaaapiaaaaaoela
abaioekaecaaaaadacaaapiaabaaoelaabaioekaaiaaaaadabaacciaadaaoela
ahaaoekaalaaaaadacaacbiaabaaffiaaiaaaakaacaaaaadabaacciaacaaaaia
acaaaaiaaeaaaaaeadaaahiaaaaaoekaabaaffiaaeaaoelaafaaaaadaaaaapia
aaaaoeiaacaaoekaacaaaaadaaaaapiaaaaaoeiaaaaaoeiaafaaaaadaeaaahia
abaaaaiaadaaoekaafaaaaadaeaaahiaaeaaoeiaabaaaakaaeaaaaaeadaaahia
aaaaoeiaadaaoeiaaeaaoeiaafaaaaadadaaaiiaacaakkiaabaaffkaafaaaaad
adaaaiiaabaakkiaadaappiaafaaaaadabaaaoiaadaappiaaeaablkaaeaaaaae
abaaahiaabaabliaabaaaaiaadaaoeiaaiaaaaadabaaciiaacaaoelaacaaoela
ahaaaaacabaaciiaabaappiaaeaaaaaeacaachiaacaaoelaabaappiaaiaamjka
ceaaaaacadaachiaacaaoeiaaiaaaaadabaaciiaadaaoelaadaaoeiaalaaaaad
acaaabiaabaappiaaiaaaakaabaaaaacabaaaiiaaiaappkaafaaaaadabaaaiia
abaappiaafaakkkacaaaaaadadaaabiaacaaaaiaabaappiaafaaaaadabaaaiia
aaaappiaadaaaaiaaeaaaaaeaaaaahiaagaaoekaabaappiaabaaoeiaabaaaaac
aaaiapiaaaaaoeiappppaaaafdeieefcgaaeaaaaeaaaaaaabiabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
aeaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaaeaaaaaaegiccaaaabaaaaaa
aaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaaagaabaaaaaaaaaaaegbcbaaa
afaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaaacaaaaaaegiccaaa
aaaaaaaaafaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaaadaaaaaaagiacaaa
aaaaaaaaadaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaaadaaaaaaegbabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaa
adaaaaaabkiacaaaaaaaaaaaadaaaaaadiaaaaahicaabaaaaaaaaaaackaabaaa
acaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaapgapbaaaaaaaaaaa
egiccaaaaaaaaaaaagaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaa
agaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
dcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaapgapbaaaaaaaaaaaaceaaaaa
pdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaackiacaaaaaaaaaaaaiaaaaaa
abeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaa
abaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaaaaaaaaaaajaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahahaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..6],
		{ 0.70703125, 0, 128, 2 },
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R1, fragment.texcoord[4], texture[2], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.xz, fragment.texcoord[0], texture[1], 2D;
TEX R3.z, fragment.texcoord[1], texture[1], 2D;
MUL R1.xyz, R1.w, R1;
DP3 R2.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R2.y, R2.y;
MAD R3.xyw, R2.y, fragment.texcoord[2].xyzz, c[7].xxzy;
DP3 R2.y, R3.xyww, R3.xyww;
RSQ R2.y, R2.y;
MUL R3.xyw, R2.y, R3;
DP3 R2.y, fragment.texcoord[3], R3.xyww;
MUL R0, R0, c[2];
MUL R0, R0, c[7].w;
MUL R3.xyw, R2.x, c[3].xyzz;
MUL R1.xyz, R1, c[8].x;
MUL R3.xyw, R3, c[0].x;
MAD R0.xyz, R0, R1, R3.xyww;
MOV R1.x, c[7].z;
MUL R1.z, R3, c[1].x;
MAX R1.y, R2, c[7];
MUL R1.x, R1, c[5];
POW R1.w, R1.y, R1.x;
MUL R1.z, R1, R2;
MUL R1.xyz, R1.z, c[4];
MAD R1.xyz, R1, R2.x, R0;
MUL R0.x, R1.w, R0.w;
MAD result.color.xyz, R0.x, c[6], R1;
MOV result.color.w, R0;
END
# 29 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c7, 0.70703125, 0.00000000, 128.00000000, 2.00000000
def c8, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xy
dcl t2.xyz
dcl t3.xyz
dcl t4.xy
texld r5, t1, s1
texld r1, t4, s2
texld r3, t0, s1
texld r2, t0, s0
dp3_pp r0.x, t2, t2
mul r2, r2, c2
mul r2, r2, c7.w
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c8.x
rsq_pp r0.x, r0.x
mov r4.xy, c7.x
mov r4.z, c7.y
mad_pp r4.xyz, r0.x, t2, r4
dp3_pp r0.x, r4, r4
rsq_pp r0.x, r0.x
mul_pp r0.xyz, r0.x, r4
dp3_pp r0.x, t3, r0
mul r4.xyz, r3.x, c3
mul r4.xyz, r4, c0.x
mad r2.xyz, r2, r1, r4
mov r1.x, c5
max_pp r0.x, r0, c7.y
mul r1.x, c7.z, r1
pow r4.x, r0.x, r1.x
mul r0.x, r5.z, c1
mul r1.x, r0, r3.z
mov r0.x, r4.x
mul r1.xyz, r1.x, c4
mad r1.xyz, r1, r3.x, r2
mul r0.x, r0, r2.w
mov r0.w, r2
mad r0.xyz, r0.x, c6, r1
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 176
Float 48 [_StaticEmissionLM]
Float 52 [_DynamiEmissionLM]
Vector 64 [_Color]
Vector 80 [_StaticIllumColor]
Vector 96 [_DynamiIllumColor]
Float 152 [_Shininess]
Vector 160 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedaiofjlmacjhakoeomclenpgcmifodkmgabaaaaaagiafaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapadaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefceiaeaaaa
eaaaaaaabcabaaaafjaaaaaeegiocaaaaaaaaaaaalaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaabaaaaaah
bcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadcaaaaamhcaabaaaaaaaaaaaegbcbaaaadaaaaaa
agaabaaaaaaaaaaaaceaaaaapdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaa
aaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaiccaabaaaaaaaaaaa
ckiacaaaaaaaaaaaajaaaaaaabeaaaaaaaaaaaeddiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
abaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaaeb
diaaaaahocaabaaaaaaaaaaaagajbaaaacaaaaaafgafbaaaaaaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaaihcaabaaaadaaaaaaagaabaaaacaaaaaaegiccaaaaaaaaaaaafaaaaaa
diaaaaaihcaabaaaadaaaaaaegacbaaaadaaaaaaagiacaaaaaaaaaaaadaaaaaa
dcaaaaajocaabaaaaaaaaaaaagajbaaaabaaaaaafgaobaaaaaaaaaaaagajbaaa
adaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaackaabaaaabaaaaaabkiacaaaaaaaaaaaadaaaaaadiaaaaah
bcaabaaaabaaaaaackaabaaaacaaaaaaakaabaaaabaaaaaadiaaaaaihcaabaaa
abaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaajocaabaaa
aaaaaaaaagajbaaaabaaaaaaagaabaaaacaaaaaafgaobaaaaaaaaaaadcaaaaak
hccabaaaaaaaaaaaegiccaaaaaaaaaaaakaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 176
Float 48 [_StaticEmissionLM]
Float 52 [_DynamiEmissionLM]
Vector 64 [_Color]
Vector 80 [_StaticIllumColor]
Vector 96 [_DynamiIllumColor]
Float 152 [_Shininess]
Vector 160 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedipdlkonbaodlmolibpldegfpkidbeklkabaaaaaaaeaiaaaaaeaaaaaa
daaaaaaamiacaaaabiahaaaanaahaaaaebgpgodjjaacaaaajaacaaaaaaacpppp
eiacaaaaeiaaaaaaacaadaaaaaaaeiaaaaaaeiaaadaaceaaaaaaeiaaaaaaaaaa
abababaaacacacaaaaaaadaaaeaaaaaaaaaaaaaaaaaaajaaacaaaeaaaaaaaaaa
aaacppppfbaaaaafagaaapkaaaaaaaebaaaaaaaapdaedfdppdaedfdpfbaaaaaf
ahaaapkaaaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaapla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaia
adaachlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkaabaaaaacaaaaadiaaaaabllaecaaaaadaaaacpiaaaaaoeia
acaioekaecaaaaadabaaapiaaaaaoelaaaaioekaecaaaaadacaaapiaaaaaoela
abaioekaecaaaaadadaaapiaabaaoelaabaioekaafaaaaadaaaaciiaaaaappia
agaaaakaafaaaaadaaaachiaaaaaoeiaaaaappiaafaaaaadabaaapiaabaaoeia
abaaoekaacaaaaadabaaapiaabaaoeiaabaaoeiaafaaaaadaeaaahiaacaaaaia
acaaoekaafaaaaadaeaaahiaaeaaoeiaaaaaaakaaeaaaaaeaaaaahiaabaaoeia
aaaaoeiaaeaaoeiaafaaaaadaaaaaiiaadaakkiaaaaaffkaafaaaaadaaaaaiia
acaakkiaaaaappiaafaaaaadacaaaoiaaaaappiaadaablkaaeaaaaaeaaaaahia
acaabliaacaaaaiaaaaaoeiaaiaaaaadaaaaciiaacaaoelaacaaoelaahaaaaac
aaaaciiaaaaappiaaeaaaaaeacaachiaacaaoelaaaaappiaagaablkaceaaaaac
adaachiaacaaoeiaaiaaaaadaaaaciiaadaaoelaadaaoeiaalaaaaadacaaabia
aaaappiaagaaffkaabaaaaacaaaaaiiaaeaakkkaafaaaaadaaaaaiiaaaaappia
ahaaaakacaaaaaadadaaabiaacaaaaiaaaaappiaafaaaaadaaaaaiiaabaappia
adaaaaiaaeaaaaaeabaaahiaafaaoekaaaaappiaaaaaoeiaabaaaaacaaaiapia
abaaoeiappppaaaafdeieefceiaeaaaaeaaaaaaabcabaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaeaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaa
egbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaam
hcaabaaaaaaaaaaaegbcbaaaadaaaaaaagaabaaaaaaaaaaaaceaaaaapdaedfdp
pdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaaeaaaaaaegacbaaaaaaaaaaadeaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaaiccaabaaaaaaaaaaackiacaaaaaaaaaaaajaaaaaaabeaaaaa
aaaaaaeddiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaa
bjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaa
abaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaaaaaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaaegaobaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkaabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaa
abaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahccaabaaaaaaaaaaa
dkaabaaaacaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaaagajbaaa
acaaaaaafgafbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaa
acaaaaaaegiccaaaaaaaaaaaafaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaa
adaaaaaaagiacaaaaaaaaaaaadaaaaaadcaaaaajocaabaaaaaaaaaaaagajbaaa
abaaaaaafgaobaaaaaaaaaaaagajbaaaadaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackaabaaaabaaaaaa
bkiacaaaaaaaaaaaadaaaaaadiaaaaahbcaabaaaabaaaaaackaabaaaacaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
aaaaaaaaagaaaaaadcaaaaajocaabaaaaaaaaaaaagajbaaaabaaaaaaagaabaaa
acaaaaaafgaobaaaaaaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaaaaaaaaaa
akaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..6],
		{ 0.70703125, 0, 128, 2 },
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R1, fragment.texcoord[4], texture[2], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.xz, fragment.texcoord[0], texture[1], 2D;
TEX R3.z, fragment.texcoord[1], texture[1], 2D;
MUL R1.xyz, R1.w, R1;
DP3 R2.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R2.y, R2.y;
MAD R3.xyw, R2.y, fragment.texcoord[2].xyzz, c[7].xxzy;
DP3 R2.y, R3.xyww, R3.xyww;
RSQ R2.y, R2.y;
MUL R3.xyw, R2.y, R3;
DP3 R2.y, fragment.texcoord[3], R3.xyww;
MUL R0, R0, c[2];
MUL R0, R0, c[7].w;
MUL R3.xyw, R2.x, c[3].xyzz;
MUL R1.xyz, R1, c[8].x;
MUL R3.xyw, R3, c[0].x;
MAD R0.xyz, R0, R1, R3.xyww;
MOV R1.x, c[7].z;
MUL R1.z, R3, c[1].x;
MAX R1.y, R2, c[7];
MUL R1.x, R1, c[5];
POW R1.w, R1.y, R1.x;
MUL R1.z, R1, R2;
MUL R1.xyz, R1.z, c[4];
MAD R1.xyz, R1, R2.x, R0;
MUL R0.x, R1.w, R0.w;
MAD result.color.xyz, R0.x, c[6], R1;
MOV result.color.w, R0;
END
# 29 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c7, 0.70703125, 0.00000000, 128.00000000, 2.00000000
def c8, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xy
dcl t2.xyz
dcl t3.xyz
dcl t4.xy
texld r5, t1, s1
texld r1, t4, s2
texld r3, t0, s1
texld r2, t0, s0
dp3_pp r0.x, t2, t2
mul r2, r2, c2
mul r2, r2, c7.w
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c8.x
rsq_pp r0.x, r0.x
mov r4.xy, c7.x
mov r4.z, c7.y
mad_pp r4.xyz, r0.x, t2, r4
dp3_pp r0.x, r4, r4
rsq_pp r0.x, r0.x
mul_pp r0.xyz, r0.x, r4
dp3_pp r0.x, t3, r0
mul r4.xyz, r3.x, c3
mul r4.xyz, r4, c0.x
mad r2.xyz, r2, r1, r4
mov r1.x, c5
max_pp r0.x, r0, c7.y
mul r1.x, c7.z, r1
pow r4.x, r0.x, r1.x
mul r0.x, r5.z, c1
mul r1.x, r0, r3.z
mov r0.x, r4.x
mul r1.xyz, r1.x, c4
mad r1.xyz, r1, r3.x, r2
mul r0.x, r0, r2.w
mov r0.w, r2
mad r0.xyz, r0.x, c6, r1
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 176
Float 48 [_StaticEmissionLM]
Float 52 [_DynamiEmissionLM]
Vector 64 [_Color]
Vector 80 [_StaticIllumColor]
Vector 96 [_DynamiIllumColor]
Float 152 [_Shininess]
Vector 160 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedaiofjlmacjhakoeomclenpgcmifodkmgabaaaaaagiafaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapadaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefceiaeaaaa
eaaaaaaabcabaaaafjaaaaaeegiocaaaaaaaaaaaalaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaabaaaaaah
bcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadcaaaaamhcaabaaaaaaaaaaaegbcbaaaadaaaaaa
agaabaaaaaaaaaaaaceaaaaapdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaa
aaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaiccaabaaaaaaaaaaa
ckiacaaaaaaaaaaaajaaaaaaabeaaaaaaaaaaaeddiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
abaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaaeb
diaaaaahocaabaaaaaaaaaaaagajbaaaacaaaaaafgafbaaaaaaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaaihcaabaaaadaaaaaaagaabaaaacaaaaaaegiccaaaaaaaaaaaafaaaaaa
diaaaaaihcaabaaaadaaaaaaegacbaaaadaaaaaaagiacaaaaaaaaaaaadaaaaaa
dcaaaaajocaabaaaaaaaaaaaagajbaaaabaaaaaafgaobaaaaaaaaaaaagajbaaa
adaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaackaabaaaabaaaaaabkiacaaaaaaaaaaaadaaaaaadiaaaaah
bcaabaaaabaaaaaackaabaaaacaaaaaaakaabaaaabaaaaaadiaaaaaihcaabaaa
abaaaaaaagaabaaaabaaaaaaegiccaaaaaaaaaaaagaaaaaadcaaaaajocaabaaa
aaaaaaaaagajbaaaabaaaaaaagaabaaaacaaaaaafgaobaaaaaaaaaaadcaaaaak
hccabaaaaaaaaaaaegiccaaaaaaaaaaaakaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 176
Float 48 [_StaticEmissionLM]
Float 52 [_DynamiEmissionLM]
Vector 64 [_Color]
Vector 80 [_StaticIllumColor]
Vector 96 [_DynamiIllumColor]
Float 152 [_Shininess]
Vector 160 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedipdlkonbaodlmolibpldegfpkidbeklkabaaaaaaaeaiaaaaaeaaaaaa
daaaaaaamiacaaaabiahaaaanaahaaaaebgpgodjjaacaaaajaacaaaaaaacpppp
eiacaaaaeiaaaaaaacaadaaaaaaaeiaaaaaaeiaaadaaceaaaaaaeiaaaaaaaaaa
abababaaacacacaaaaaaadaaaeaaaaaaaaaaaaaaaaaaajaaacaaaeaaaaaaaaaa
aaacppppfbaaaaafagaaapkaaaaaaaebaaaaaaaapdaedfdppdaedfdpfbaaaaaf
ahaaapkaaaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaapla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaia
adaachlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkaabaaaaacaaaaadiaaaaabllaecaaaaadaaaacpiaaaaaoeia
acaioekaecaaaaadabaaapiaaaaaoelaaaaioekaecaaaaadacaaapiaaaaaoela
abaioekaecaaaaadadaaapiaabaaoelaabaioekaafaaaaadaaaaciiaaaaappia
agaaaakaafaaaaadaaaachiaaaaaoeiaaaaappiaafaaaaadabaaapiaabaaoeia
abaaoekaacaaaaadabaaapiaabaaoeiaabaaoeiaafaaaaadaeaaahiaacaaaaia
acaaoekaafaaaaadaeaaahiaaeaaoeiaaaaaaakaaeaaaaaeaaaaahiaabaaoeia
aaaaoeiaaeaaoeiaafaaaaadaaaaaiiaadaakkiaaaaaffkaafaaaaadaaaaaiia
acaakkiaaaaappiaafaaaaadacaaaoiaaaaappiaadaablkaaeaaaaaeaaaaahia
acaabliaacaaaaiaaaaaoeiaaiaaaaadaaaaciiaacaaoelaacaaoelaahaaaaac
aaaaciiaaaaappiaaeaaaaaeacaachiaacaaoelaaaaappiaagaablkaceaaaaac
adaachiaacaaoeiaaiaaaaadaaaaciiaadaaoelaadaaoeiaalaaaaadacaaabia
aaaappiaagaaffkaabaaaaacaaaaaiiaaeaakkkaafaaaaadaaaaaiiaaaaappia
ahaaaakacaaaaaadadaaabiaacaaaaiaaaaappiaafaaaaadaaaaaiiaabaappia
adaaaaiaaeaaaaaeabaaahiaafaaoekaaaaappiaaaaaoeiaabaaaaacaaaiapia
abaaoeiappppaaaafdeieefceiaeaaaaeaaaaaaabcabaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaeaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaa
egbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaam
hcaabaaaaaaaaaaaegbcbaaaadaaaaaaagaabaaaaaaaaaaaaceaaaaapdaedfdp
pdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaaeaaaaaaegacbaaaaaaaaaaadeaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaaiccaabaaaaaaaaaaackiacaaaaaaaaaaaajaaaaaaabeaaaaa
aaaaaaeddiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaa
bjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaa
abaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaaaaaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaaegaobaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkaabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaa
abaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahccaabaaaaaaaaaaa
dkaabaaaacaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaaagajbaaa
acaaaaaafgafbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaa
acaaaaaaegiccaaaaaaaaaaaafaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaa
adaaaaaaagiacaaaaaaaaaaaadaaaaaadcaaaaajocaabaaaaaaaaaaaagajbaaa
abaaaaaafgaobaaaaaaaaaaaagajbaaaadaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaabaaaaaackaabaaaabaaaaaa
bkiacaaaaaaaaaaaadaaaaaadiaaaaahbcaabaaaabaaaaaackaabaaaacaaaaaa
akaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaagaabaaaabaaaaaaegiccaaa
aaaaaaaaagaaaaaadcaaaaajocaabaaaaaaaaaaaagajbaaaabaaaaaaagaabaaa
acaaaaaafgaobaaaaaaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaaaaaaaaaa
akaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Float 2 [_StaticEmissionLM]
Float 3 [_DynamiEmissionLM]
Vector 4 [_Color]
Vector 5 [_StaticIllumColor]
Vector 6 [_DynamiIllumColor]
Float 7 [_Shininess]
Vector 8 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[10] = { program.local[0..8],
		{ 0.70703125, 0, 128, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TEX R1.xz, fragment.texcoord[0], texture[1], 2D;
TEX R0.z, fragment.texcoord[1], texture[1], 2D;
TXP R0.x, fragment.texcoord[5], texture[2], 2D;
DP3 R0.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.y, R0.y;
MAD R3.xyz, R0.y, fragment.texcoord[2], c[9].xxyw;
DP3 R0.y, R3, R3;
RSQ R0.y, R0.y;
MUL R3.xyz, R0.y, R3;
DP3 R1.y, fragment.texcoord[3], R3;
DP3 R0.y, fragment.texcoord[3], c[0];
MAX R0.y, R0, c[9];
MUL R2, R2, c[4];
MUL R2, R2, c[9].w;
MUL R0.x, R0.y, R0;
MUL R0.xyw, R0.x, c[1].xyzz;
MUL R3.xyz, R1.x, c[5];
MUL R0.xyw, R0, c[9].w;
ADD R0.xyw, R0, fragment.texcoord[4].xyzz;
MUL R3.xyz, R3, c[2].x;
MAD R2.xyz, R2, R0.xyww, R3;
MUL R0.x, R0.z, c[3];
MOV R0.y, c[9].z;
MUL R0.y, R0, c[7].x;
MAX R0.w, R1.y, c[9].y;
POW R0.w, R0.w, R0.y;
MUL R0.x, R0, R1.z;
MUL R0.xyz, R0.x, c[6];
MAD R0.xyz, R0, R1.x, R2;
MUL R0.w, R0, R2;
MAD result.color.xyz, R0.w, c[8], R0;
MOV result.color.w, R2;
END
# 33 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Float 2 [_StaticEmissionLM]
Float 3 [_DynamiEmissionLM]
Vector 4 [_Color]
Vector 5 [_StaticIllumColor]
Vector 6 [_DynamiIllumColor]
Float 7 [_Shininess]
Vector 8 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_ShadowMapTexture] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c9, 0.70703125, 0.00000000, 128.00000000, 2.00000000
dcl t0.xy
dcl t1.xy
dcl t2.xyz
dcl t3.xyz
dcl t4.xyz
dcl t5
texldp r4, t5, s2
texld r5, t1, s1
texld r2, t0, s1
texld r1, t0, s0
dp3_pp r0.x, t2, t2
mul r1, r1, c4
mul r1, r1, c9.w
rsq_pp r0.x, r0.x
mov r3.xy, c9.x
mov r3.z, c9.y
mad_pp r3.xyz, r0.x, t2, r3
dp3_pp r0.x, r3, r3
rsq_pp r0.x, r0.x
mul_pp r3.xyz, r0.x, r3
dp3_pp r0.x, t3, c0
max_pp r0.x, r0, c9.y
mul_pp r0.x, r0, r4
mul_pp r0.xyz, r0.x, c1
mul r4.xyz, r2.x, c5
mul_pp r0.xyz, r0, c9.w
add r0.xyz, r0, t4
mul r4.xyz, r4, c2.x
mad r4.xyz, r1, r0, r4
dp3_pp r0.x, t3, r3
mov r1.x, c7
max_pp r0.x, r0, c9.y
mul r1.x, c9.z, r1
pow r3.x, r0.x, r1.x
mul r0.x, r5.z, c3
mul r1.x, r0, r2.z
mov r0.x, r3.x
mul r1.xyz, r1.x, c6
mad r1.xyz, r1, r2.x, r4
mul r0.x, r0, r1.w
mov r0.w, r1
mad r0.xyz, r0.x, c8, r1
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_MaskTex] 2D 2
SetTexture 2 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 224
Vector 16 [_LightColor0]
Float 112 [_StaticEmissionLM]
Float 116 [_DynamiEmissionLM]
Vector 128 [_Color]
Vector 144 [_StaticIllumColor]
Vector 160 [_DynamiIllumColor]
Float 200 [_Shininess]
Vector 208 [_SpecularColor]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecednaolmdcifglognakcabfkndokhinpdhdabaaaaaaaaagaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apadaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apalaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmiaeaaaaeaaaaaaadcabaaaa
fjaaaaaeegiocaaaaaaaaaaaaoaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadlcbabaaaagaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaa
agaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaa
eghobaaaacaaaaaaaagabaaaaaaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegiccaaaabaaaaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaapaaaaahbcaabaaaaaaaaaaafgafbaaaaaaaaaaa
agaabaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaa
agaabaaaaaaaaaaaegbcbaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaaipcaabaaaabaaaaaa
egaobaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaaaaaaaaahpcaabaaaabaaaaaa
egaobaaaabaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaaihcaabaaaadaaaaaa
agaabaaaacaaaaaaegiccaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaaadaaaaaa
egacbaaaadaaaaaaagiacaaaaaaaaaaaahaaaaaadcaaaaajhcaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaaaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaa
adaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaai
icaabaaaaaaaaaaackaabaaaadaaaaaabkiacaaaaaaaaaaaahaaaaaadiaaaaah
icaabaaaaaaaaaaackaabaaaacaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaapgapbaaaaaaaaaaaegiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaa
aaaaaaaaegacbaaaabaaaaaaagaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaa
pgapbaaaaaaaaaaaaceaaaaapdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaa
abaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
cpaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaa
ckiacaaaaaaaaaaaamaaaaaaabeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaakaabaaaabaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaa
egiccaaaaaaaaaaaanaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_MaskTex] 2D 2
SetTexture 2 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 224
Vector 16 [_LightColor0]
Float 112 [_StaticEmissionLM]
Float 116 [_DynamiEmissionLM]
Vector 128 [_Color]
Vector 144 [_StaticIllumColor]
Vector 160 [_DynamiIllumColor]
Float 200 [_Shininess]
Vector 208 [_SpecularColor]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0_level_9_1
eefiecednabpngjneaeecojddkmipjpdlegmoekkabaaaaaapmaiaaaaaeaaaaaa
daaaaaaaciadaaaapiahaaaamiaiaaaaebgpgodjpaacaaaapaacaaaaaaacpppp
jaacaaaagaaaaaaaaeaadaaaaaaagaaaaaaagaaaadaaceaaaaaagaaaacaaaaaa
aaababaaabacacaaaaaaabaaabaaaaaaaaaaaaaaaaaaahaaaeaaabaaaaaaaaaa
aaaaamaaacaaafaaaaaaaaaaabaaaaaaabaaahaaaaaaaaaaaaacppppfbaaaaaf
aiaaapkaaaaaaaaapdaedfdppdaedfdpaaaaaaedbpaaaaacaaaaaaiaaaaaadla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaia
adaachlabpaaaaacaaaaaaiaaeaaahlabpaaaaacaaaaaaiaafaaaplabpaaaaac
aaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapka
agaaaaacaaaaaiiaafaapplaafaaaaadaaaaadiaaaaappiaafaaoelaecaaaaad
aaaacpiaaaaaoeiaaaaioekaecaaaaadabaaapiaaaaaoelaabaioekaecaaaaad
acaaapiaaaaaoelaacaioekaecaaaaadadaaapiaabaaoelaacaioekaaiaaaaad
aaaacciaadaaoelaahaaoekaafaaaaadaaaacbiaaaaaaaiaaaaaffiafiaaaaae
aaaacbiaaaaaffiaaaaaaaiaaiaaaakaacaaaaadaaaacbiaaaaaaaiaaaaaaaia
aeaaaaaeaaaaahiaaaaaoekaaaaaaaiaaeaaoelaafaaaaadabaaapiaabaaoeia
acaaoekaacaaaaadabaaapiaabaaoeiaabaaoeiaafaaaaadaeaaahiaacaaaaia
adaaoekaafaaaaadaeaaahiaaeaaoeiaabaaaakaaeaaaaaeaaaaahiaabaaoeia
aaaaoeiaaeaaoeiaafaaaaadaaaaaiiaadaakkiaabaaffkaafaaaaadaaaaaiia
acaakkiaaaaappiaafaaaaadacaaaoiaaaaappiaaeaablkaaeaaaaaeaaaaahia
acaabliaacaaaaiaaaaaoeiaaiaaaaadaaaaciiaacaaoelaacaaoelaahaaaaac
aaaaciiaaaaappiaaeaaaaaeacaachiaacaaoelaaaaappiaaiaamjkaceaaaaac
adaachiaacaaoeiaaiaaaaadaaaaciiaadaaoelaadaaoeiaalaaaaadacaaabia
aaaappiaaiaaaakaabaaaaacaaaaaiiaaiaappkaafaaaaadaaaaaiiaaaaappia
afaakkkacaaaaaadadaaabiaacaaaaiaaaaappiaafaaaaadaaaaaiiaabaappia
adaaaaiaaeaaaaaeabaaahiaagaaoekaaaaappiaaaaaoeiaabaaaaacaaaiapia
abaaoeiappppaaaafdeieefcmiaeaaaaeaaaaaaadcabaaaafjaaaaaeegiocaaa
aaaaaaaaaoaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaaddcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagcbaaaadlcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacaeaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaagaaaaaapgbpbaaa
agaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaacaaaaaa
aagabaaaaaaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaaeaaaaaaegiccaaa
abaaaaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
aaaaaaaaapaaaaahbcaabaaaaaaaaaaafgafbaaaaaaaaaaaagaabaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaaagaabaaaaaaaaaaa
egbcbaaaafaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaa
egiocaaaaaaaaaaaaiaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaa
egaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaacaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaaacaaaaaa
egiccaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaaadaaaaaa
agiacaaaaaaaaaaaahaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaaaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaaadaaaaaaegbabaaa
acaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaaiicaabaaaaaaaaaaa
ckaabaaaadaaaaaabkiacaaaaaaaaaaaahaaaaaadiaaaaahicaabaaaaaaaaaaa
ckaabaaaacaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaapgapbaaa
aaaaaaaaegiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaa
abaaaaaaagaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaapgapbaaaaaaaaaaa
aceaaaaapdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaadeaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaackiacaaaaaaaaaaa
amaaaaaaabeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
akaabaaaabaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
icaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaadkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaaaaaaaaaa
anaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheomiaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapadaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahahaaaalmaaaaaaafaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapalaaaafdfgfpfagphdgjhegjgpgoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 3 [unity_Lightmap] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..6],
		{ 0.70703125, 0, 128, 2 },
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[4], texture[3], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.xz, fragment.texcoord[0], texture[1], 2D;
TEX R3.z, fragment.texcoord[1], texture[1], 2D;
MUL R4.xyz, R1.w, R1;
DP3 R2.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R2.y, R2.y;
MAD R3.xyw, R2.y, fragment.texcoord[2].xyzz, c[7].xxzy;
DP3 R1.w, R3.xyww, R3.xyww;
RSQ R1.w, R1.w;
MUL R3.xyw, R1.w, R3;
MUL R0, R0, c[2];
MUL R0, R0, c[7].w;
MUL R4.xyz, R4, c[8].x;
MUL R1.xyz, R1, c[7].w;
MIN R1.xyz, R4, R1;
MAX R1.xyz, R1, R4;
MUL R4.xyz, R2.x, c[3];
MUL R4.xyz, R4, c[0].x;
MAD R0.xyz, R0, R1, R4;
DP3 R1.w, fragment.texcoord[3], R3.xyww;
MOV R1.y, c[7].z;
MUL R1.x, R3.z, c[1];
MAX R1.z, R1.w, c[7].y;
MUL R1.y, R1, c[5].x;
POW R1.w, R1.z, R1.y;
MUL R1.x, R1, R2.z;
MUL R1.xyz, R1.x, c[4];
MAD R0.xyz, R1, R2.x, R0;
MUL R1.x, R1.w, R0.w;
MAD result.color.xyz, R1.x, c[6], R0;
MOV result.color.w, R0;
END
# 32 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 3 [unity_Lightmap] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s3
def c7, 0.70703125, 0.00000000, 128.00000000, 2.00000000
def c8, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xy
dcl t2.xyz
dcl t3.xyz
dcl t4.xy
texld r0, t1, s1
texld r1, t0, s0
texld r2, t0, s1
texld r3, t4, s3
mul_pp r5.xyz, r3.w, r3
dp3_pp r0.x, t2, t2
mul r1, r1, c2
mul r1, r1, c7.w
mul_pp r5.xyz, r5, c8.x
mul_pp r3.xyz, r3, c7.w
min_pp r3.xyz, r5, r3
max_pp r3.xyz, r3, r5
mul r5.xyz, r2.x, c3
mul r5.xyz, r5, c0.x
mad r1.xyz, r1, r3, r5
mov r3.x, c5
rsq_pp r0.x, r0.x
mul r3.x, c7.z, r3
mov r4.xy, c7.x
mov r4.z, c7.y
mad_pp r4.xyz, r0.x, t2, r4
dp3_pp r0.x, r4, r4
rsq_pp r0.x, r0.x
mul_pp r4.xyz, r0.x, r4
dp3_pp r0.x, t3, r4
max_pp r0.x, r0, c7.y
pow r4.x, r0.x, r3.x
mul r0.x, r0.z, c1
mul r0.x, r0, r2.z
mul r0.xyz, r0.x, c4
mad r0.xyz, r0, r2.x, r1
mov r3.x, r4.x
mul r1.x, r3, r1.w
mov r0.w, r1
mad r0.xyz, r1.x, c6, r0
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 240
Float 112 [_StaticEmissionLM]
Float 116 [_DynamiEmissionLM]
Vector 128 [_Color]
Vector 144 [_StaticIllumColor]
Vector 160 [_DynamiIllumColor]
Float 216 [_Shininess]
Vector 224 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedeclnjeghbpkjnplekekijieggfalpphjabaaaaaaneafaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapadaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcjmaeaaaaeaaaaaaachabaaaa
fjaaaaaeegiocaaaaaaaaaaaapaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaa
egacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaddaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadeaaaaahhcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaaiaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaaacaaaaaaegiccaaa
aaaaaaaaajaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaaadaaaaaaagiacaaa
aaaaaaaaahaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaaadaaaaaaegbabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaa
adaaaaaabkiacaaaaaaaaaaaahaaaaaadiaaaaahicaabaaaaaaaaaaackaabaaa
acaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaapgapbaaaaaaaaaaa
egiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaa
agaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
dcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaapgapbaaaaaaaaaaaaceaaaaa
pdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaackiacaaaaaaaaaaaanaaaaaa
abeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaa
abaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 240
Float 112 [_StaticEmissionLM]
Float 116 [_DynamiEmissionLM]
Vector 128 [_Color]
Vector 144 [_StaticIllumColor]
Vector 160 [_DynamiIllumColor]
Float 216 [_Shininess]
Vector 224 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfcglgahihldmgoolflbkjijplbbjicpjabaaaaaakaaiaaaaaeaaaaaa
daaaaaaapiacaaaajmahaaaagmaiaaaaebgpgodjmaacaaaamaacaaaaaaacpppp
hiacaaaaeiaaaaaaacaadaaaaaaaeiaaaaaaeiaaadaaceaaaaaaeiaaaaaaaaaa
abababaaacacacaaaaaaahaaaeaaaaaaaaaaaaaaaaaaanaaacaaaeaaaaaaaaaa
aaacppppfbaaaaafagaaapkaaaaaaaebaaaaaaaapdaedfdppdaedfdpfbaaaaaf
ahaaapkaaaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaapla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaia
adaachlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkaabaaaaacaaaaadiaaaaabllaecaaaaadaaaacpiaaaaaoeia
acaioekaecaaaaadabaaapiaaaaaoelaaaaioekaecaaaaadacaaapiaaaaaoela
abaioekaecaaaaadadaaapiaabaaoelaabaioekaafaaaaadaaaaciiaaaaappia
agaaaakaafaaaaadaeaachiaaaaaoeiaaaaappiaacaaaaadaaaachiaaaaaoeia
aaaaoeiaakaaaaadafaachiaaaaaoeiaaeaaoeiaalaaaaadaaaaahiaafaaoeia
aeaaoeiaafaaaaadabaaapiaabaaoeiaabaaoekaacaaaaadabaaapiaabaaoeia
abaaoeiaafaaaaadaeaaahiaacaaaaiaacaaoekaafaaaaadaeaaahiaaeaaoeia
aaaaaakaaeaaaaaeaaaaahiaabaaoeiaaaaaoeiaaeaaoeiaafaaaaadaaaaaiia
adaakkiaaaaaffkaafaaaaadaaaaaiiaacaakkiaaaaappiaafaaaaadacaaaoia
aaaappiaadaablkaaeaaaaaeaaaaahiaacaabliaacaaaaiaaaaaoeiaaiaaaaad
aaaaciiaacaaoelaacaaoelaahaaaaacaaaaciiaaaaappiaaeaaaaaeacaachia
acaaoelaaaaappiaagaablkaceaaaaacadaachiaacaaoeiaaiaaaaadaaaaciia
adaaoelaadaaoeiaalaaaaadacaaabiaaaaappiaagaaffkaabaaaaacaaaaaiia
aeaakkkaafaaaaadaaaaaiiaaaaappiaahaaaakacaaaaaadadaaabiaacaaaaia
aaaappiaafaaaaadaaaaaiiaabaappiaadaaaaiaaeaaaaaeabaaahiaafaaoeka
aaaappiaaaaaoeiaabaaaaacaaaiapiaabaaoeiappppaaaafdeieefcjmaeaaaa
eaaaaaaachabaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaa
diaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaebdiaaaaah
hcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaddaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahhcaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaa
abaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaa
acaaaaaaegiccaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaa
adaaaaaaagiacaaaaaaaaaaaahaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaaadaaaaaa
egbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaa
aaaaaaaackaabaaaadaaaaaabkiacaaaaaaaaaaaahaaaaaadiaaaaahicaabaaa
aaaaaaaackaabaaaacaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaaaaaaaaaa
egacbaaaabaaaaaaagaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaapgapbaaa
aaaaaaaaaceaaaaapdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
deaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaackiacaaa
aaaaaaaaanaaaaaaabeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakaabaaaabaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaa
aaaaaaaaaoaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheo
miaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaabaaaaaaamamaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapadaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaa
afaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 3 [unity_Lightmap] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[9] = { program.local[0..6],
		{ 0.70703125, 0, 128, 2 },
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[4], texture[3], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.xz, fragment.texcoord[0], texture[1], 2D;
TEX R3.z, fragment.texcoord[1], texture[1], 2D;
MUL R4.xyz, R1.w, R1;
DP3 R2.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R2.y, R2.y;
MAD R3.xyw, R2.y, fragment.texcoord[2].xyzz, c[7].xxzy;
DP3 R1.w, R3.xyww, R3.xyww;
RSQ R1.w, R1.w;
MUL R3.xyw, R1.w, R3;
MUL R0, R0, c[2];
MUL R0, R0, c[7].w;
MUL R4.xyz, R4, c[8].x;
MUL R1.xyz, R1, c[7].w;
MIN R1.xyz, R4, R1;
MAX R1.xyz, R1, R4;
MUL R4.xyz, R2.x, c[3];
MUL R4.xyz, R4, c[0].x;
MAD R0.xyz, R0, R1, R4;
DP3 R1.w, fragment.texcoord[3], R3.xyww;
MOV R1.y, c[7].z;
MUL R1.x, R3.z, c[1];
MAX R1.z, R1.w, c[7].y;
MUL R1.y, R1, c[5].x;
POW R1.w, R1.z, R1.y;
MUL R1.x, R1, R2.z;
MUL R1.xyz, R1.x, c[4];
MAD R0.xyz, R1, R2.x, R0;
MUL R1.x, R1.w, R0.w;
MAD result.color.xyz, R1.x, c[6], R0;
MOV result.color.w, R0;
END
# 32 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Float 0 [_StaticEmissionLM]
Float 1 [_DynamiEmissionLM]
Vector 2 [_Color]
Vector 3 [_StaticIllumColor]
Vector 4 [_DynamiIllumColor]
Float 5 [_Shininess]
Vector 6 [_SpecularColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 3 [unity_Lightmap] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s3
def c7, 0.70703125, 0.00000000, 128.00000000, 2.00000000
def c8, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xy
dcl t2.xyz
dcl t3.xyz
dcl t4.xy
texld r0, t1, s1
texld r1, t0, s0
texld r2, t0, s1
texld r3, t4, s3
mul_pp r5.xyz, r3.w, r3
dp3_pp r0.x, t2, t2
mul r1, r1, c2
mul r1, r1, c7.w
mul_pp r5.xyz, r5, c8.x
mul_pp r3.xyz, r3, c7.w
min_pp r3.xyz, r5, r3
max_pp r3.xyz, r3, r5
mul r5.xyz, r2.x, c3
mul r5.xyz, r5, c0.x
mad r1.xyz, r1, r3, r5
mov r3.x, c5
rsq_pp r0.x, r0.x
mul r3.x, c7.z, r3
mov r4.xy, c7.x
mov r4.z, c7.y
mad_pp r4.xyz, r0.x, t2, r4
dp3_pp r0.x, r4, r4
rsq_pp r0.x, r0.x
mul_pp r4.xyz, r0.x, r4
dp3_pp r0.x, t3, r4
max_pp r0.x, r0, c7.y
pow r4.x, r0.x, r3.x
mul r0.x, r0.z, c1
mul r0.x, r0, r2.z
mul r0.xyz, r0.x, c4
mad r0.xyz, r0, r2.x, r1
mov r3.x, r4.x
mul r1.x, r3, r1.w
mov r0.w, r1
mad r0.xyz, r1.x, c6, r0
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 240
Float 112 [_StaticEmissionLM]
Float 116 [_DynamiEmissionLM]
Vector 128 [_Color]
Vector 144 [_StaticIllumColor]
Vector 160 [_DynamiIllumColor]
Float 216 [_Shininess]
Vector 224 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedeclnjeghbpkjnplekekijieggfalpphjabaaaaaaneafaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapadaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcjmaeaaaaeaaaaaaachabaaaa
fjaaaaaeegiocaaaaaaaaaaaapaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaa
egacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaaaaaaaaaddaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadeaaaaahhcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaaiaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaaacaaaaaaegiccaaa
aaaaaaaaajaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaaadaaaaaaagiacaaa
aaaaaaaaahaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaaadaaaaaaegbabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaaaaaaaaaackaabaaa
adaaaaaabkiacaaaaaaaaaaaahaaaaaadiaaaaahicaabaaaaaaaaaaackaabaaa
acaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaapgapbaaaaaaaaaaa
egiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaa
agaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
dcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaapgapbaaaaaaaaaaaaceaaaaa
pdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaackiacaaaaaaaaaaaanaaaaaa
abeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaa
abaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaaaaaaaaaaaoaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 240
Float 112 [_StaticEmissionLM]
Float 116 [_DynamiEmissionLM]
Vector 128 [_Color]
Vector 144 [_StaticIllumColor]
Vector 160 [_DynamiIllumColor]
Float 216 [_Shininess]
Vector 224 [_SpecularColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfcglgahihldmgoolflbkjijplbbjicpjabaaaaaakaaiaaaaaeaaaaaa
daaaaaaapiacaaaajmahaaaagmaiaaaaebgpgodjmaacaaaamaacaaaaaaacpppp
hiacaaaaeiaaaaaaacaadaaaaaaaeiaaaaaaeiaaadaaceaaaaaaeiaaaaaaaaaa
abababaaacacacaaaaaaahaaaeaaaaaaaaaaaaaaaaaaanaaacaaaeaaaaaaaaaa
aaacppppfbaaaaafagaaapkaaaaaaaebaaaaaaaapdaedfdppdaedfdpfbaaaaaf
ahaaapkaaaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaapla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaia
adaachlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkaabaaaaacaaaaadiaaaaabllaecaaaaadaaaacpiaaaaaoeia
acaioekaecaaaaadabaaapiaaaaaoelaaaaioekaecaaaaadacaaapiaaaaaoela
abaioekaecaaaaadadaaapiaabaaoelaabaioekaafaaaaadaaaaciiaaaaappia
agaaaakaafaaaaadaeaachiaaaaaoeiaaaaappiaacaaaaadaaaachiaaaaaoeia
aaaaoeiaakaaaaadafaachiaaaaaoeiaaeaaoeiaalaaaaadaaaaahiaafaaoeia
aeaaoeiaafaaaaadabaaapiaabaaoeiaabaaoekaacaaaaadabaaapiaabaaoeia
abaaoeiaafaaaaadaeaaahiaacaaaaiaacaaoekaafaaaaadaeaaahiaaeaaoeia
aaaaaakaaeaaaaaeaaaaahiaabaaoeiaaaaaoeiaaeaaoeiaafaaaaadaaaaaiia
adaakkiaaaaaffkaafaaaaadaaaaaiiaacaakkiaaaaappiaafaaaaadacaaaoia
aaaappiaadaablkaaeaaaaaeaaaaahiaacaabliaacaaaaiaaaaaoeiaaiaaaaad
aaaaciiaacaaoelaacaaoelaahaaaaacaaaaciiaaaaappiaaeaaaaaeacaachia
acaaoelaaaaappiaagaablkaceaaaaacadaachiaacaaoeiaaiaaaaadaaaaciia
adaaoelaadaaoeiaalaaaaadacaaabiaaaaappiaagaaffkaabaaaaacaaaaaiia
aeaakkkaafaaaaadaaaaaiiaaaaappiaahaaaakacaaaaaadadaaabiaacaaaaia
aaaappiaafaaaaadaaaaaiiaabaappiaadaaaaiaaeaaaaaeabaaahiaafaaoeka
aaaappiaaaaaoeiaabaaaaacaaaiapiaabaaoeiappppaaaafdeieefcjmaeaaaa
eaaaaaaachabaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaa
diaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaebdiaaaaah
hcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaddaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahhcaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaa
abaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaadaaaaaaagaabaaa
acaaaaaaegiccaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaaadaaaaaaegacbaaa
adaaaaaaagiacaaaaaaaaaaaahaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaegacbaaaadaaaaaaefaaaaajpcaabaaaadaaaaaa
egbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaiicaabaaa
aaaaaaaackaabaaaadaaaaaabkiacaaaaaaaaaaaahaaaaaadiaaaaahicaabaaa
aaaaaaaackaabaaaacaaaaaadkaabaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegiccaaaaaaaaaaaakaaaaaadcaaaaajhcaabaaaaaaaaaaa
egacbaaaabaaaaaaagaabaaaacaaaaaaegacbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaamhcaabaaaabaaaaaaegbcbaaaadaaaaaapgapbaaa
aaaaaaaaaceaaaaapdaedfdppdaedfdpaaaaaaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaa
deaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaacpaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaackiacaaa
aaaaaaaaanaaaaaaabeaaaaaaaaaaaeddiaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaaakaabaaaabaaaaaabjaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegiccaaa
aaaaaaaaaoaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheo
miaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaabaaaaaaamamaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapadaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaa
afaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
"
}
}
 }
}
Fallback "VertexLit"
}