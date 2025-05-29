â›	Shader "BOL/Scene/Glass" {
Properties {
 _MainTex ("Base Texture", 2D) = "white" {}
 _Cube ("Reflection Cubemap", CUBE) = "_Skybox" { TexGen CubeReflect }
 _ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
 _ReflectBrightness ("Reflection Brightness", Float) = 1
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Blend SrcAlpha OneMinusSrcAlpha
  AlphaTest Greater 0
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_SHAr]
Vector 15 [unity_SHAg]
Vector 16 [unity_SHAb]
Vector 17 [unity_SHBr]
Vector 18 [unity_SHBg]
Vector 19 [unity_SHBb]
Vector 20 [unity_SHC]
Vector 21 [unity_Scale]
Vector 22 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[23] = { { 1, 2 },
		state.matrix.mvp,
		program.local[5..22] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[21].w;
DP3 R3.w, R1, c[6];
DP3 R2.w, R1, c[7];
DP3 R0.w, R1, c[5];
MOV R0.x, R3.w;
MOV R0.y, R2.w;
MOV R0.z, c[0].x;
MUL R1, R0.wxyy, R0.xyyw;
DP4 R2.z, R0.wxyz, c[16];
DP4 R2.y, R0.wxyz, c[15];
DP4 R2.x, R0.wxyz, c[14];
DP4 R0.z, R1, c[19];
DP4 R0.x, R1, c[17];
DP4 R0.y, R1, c[18];
ADD R2.xyz, R2, R0;
MOV R1.w, c[0].x;
MOV R1.xyz, c[13];
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MAD R1.xyz, R0, c[21].w, -vertex.position;
MUL R0.y, R3.w, R3.w;
MAD R1.w, R0, R0, -R0.y;
DP3 R0.x, vertex.normal, -R1;
MUL R0.xyz, vertex.normal, R0.x;
MAD R0.xyz, -R0, c[0].y, -R1;
MUL R3.xyz, R1.w, c[20];
DP3 result.texcoord[1].z, R0, c[7];
DP3 result.texcoord[1].y, R0, c[6];
DP3 result.texcoord[1].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD result.texcoord[3].xyz, R2, R3;
MOV result.texcoord[2].z, R2.w;
MOV result.texcoord[2].y, R3.w;
MOV result.texcoord[2].x, R0.w;
ADD result.texcoord[4].xyz, -R0, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[22], c[22].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 43 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_SHAr]
Vector 14 [unity_SHAg]
Vector 15 [unity_SHAb]
Vector 16 [unity_SHBr]
Vector 17 [unity_SHBg]
Vector 18 [unity_SHBb]
Vector 19 [unity_SHC]
Vector 20 [unity_Scale]
Vector 21 [_MainTex_ST]
"vs_2_0
def c22, 1.00000000, 2.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c20.w
dp3 r3.w, r1, c5
dp3 r2.w, r1, c6
dp3 r0.w, r1, c4
mov r0.x, r3.w
mov r0.y, r2.w
mov r0.z, c22.x
mul r1, r0.wxyy, r0.xyyw
dp4 r2.z, r0.wxyz, c15
dp4 r2.y, r0.wxyz, c14
dp4 r2.x, r0.wxyz, c13
dp4 r0.z, r1, c18
dp4 r0.x, r1, c16
dp4 r0.y, r1, c17
add r2.xyz, r2, r0
mov r1.w, c22.x
mov r1.xyz, c12
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mad r1.xyz, r0, c20.w, -v0
mul r0.y, r3.w, r3.w
mad r1.w, r0, r0, -r0.y
dp3 r0.x, v1, -r1
mul r0.xyz, v1, r0.x
mad r0.xyz, -r0, c22.y, -r1
mul r3.xyz, r1.w, c19
dp3 oT1.z, r0, c6
dp3 oT1.y, r0, c5
dp3 oT1.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
add oT3.xyz, r2, r3
mov oT2.z, r2.w
mov oT2.y, r3.w
mov oT2.x, r0.w
add oT4.xyz, -r0, c12
mad oT0.xy, v2, c21, c21.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 96
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
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
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedmcnikbaemeolmfhmfjnkobgbhbibmncjabaaaaaaleahaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcaaagaaaaeaaaabaaiaabaaaafjaaaaae
egiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaadiaaaaajhcaabaaa
aaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaadaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
baaaaaaiicaabaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaaegbcbaaaacaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaal
hcaabaaaaaaaaaaaegbcbaaaacaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaia
ebaaaaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaa
adaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadgaaaaaf
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
bkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaa
cmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaaafaaaaaaegacbaiaebaaaaaa
aaaaaaaaegiccaaaabaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 96
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
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
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedalmakjddjnnhoiadhlekfpnaolpiddlcabaaaaaadaalaaaaaeaaaaaa
daaaaaaakiadaaaalaajaaaahiakaaaaebgpgodjhaadaaaahaadaaaaaaacpopp
amadaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaafaa
abaaabaaaaaaaaaaabaaaeaaabaaacaaaaaaaaaaacaacgaaahaaadaaaaaaaaaa
adaaaaaaaeaaakaaaaaaaaaaadaaamaaajaaaoaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbhaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaabaaoekaabaaookaabaaaaacaaaaahiaacaaoekaafaaaaad
abaaahiaaaaaffiabdaaoekaaeaaaaaeaaaaaliabcaakekaaaaaaaiaabaakeia
aeaaaaaeaaaaahiabeaaoekaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeia
bfaaoekaaeaaaaaeaaaaahiaaaaaoeiabgaappkaaaaaoejbaiaaaaadaaaaaiia
aaaaoeibacaaoejaacaaaaadaaaaaiiaaaaappiaaaaappiaaeaaaaaeaaaaahia
acaaoejaaaaappibaaaaoeibafaaaaadabaaahiaaaaaffiaapaaoekaaeaaaaae
aaaaaliaaoaakekaaaaaaaiaabaakeiaaeaaaaaeabaaahoabaaaoekaaaaakkia
aaaapeiaafaaaaadaaaaahiaaaaaffjaapaaoekaaeaaaaaeaaaaahiaaoaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaahiabaaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaahiabbaaoekaaaaappjaaaaaoeiaacaaaaadaeaaahoaaaaaoeibacaaoeka
afaaaaadaaaaahiaacaaoejabgaappkaafaaaaadabaaahiaaaaaffiaapaaoeka
aeaaaaaeaaaaaliaaoaakekaaaaaaaiaabaakeiaaeaaaaaeaaaaahiabaaaoeka
aaaakkiaaaaapeiaabaaaaacaaaaaiiabhaaaakaajaaaaadabaaabiaadaaoeka
aaaaoeiaajaaaaadabaaaciaaeaaoekaaaaaoeiaajaaaaadabaaaeiaafaaoeka
aaaaoeiaafaaaaadacaaapiaaaaacjiaaaaakeiaajaaaaadadaaabiaagaaoeka
acaaoeiaajaaaaadadaaaciaahaaoekaacaaoeiaajaaaaadadaaaeiaaiaaoeka
acaaoeiaacaaaaadabaaahiaabaaoeiaadaaoeiaafaaaaadaaaaaiiaaaaaffia
aaaaffiaaeaaaaaeaaaaaiiaaaaaaaiaaaaaaaiaaaaappibabaaaaacacaaahoa
aaaaoeiaaeaaaaaeadaaahoaajaaoekaaaaappiaabaaoeiaafaaaaadaaaaapia
aaaaffjaalaaoekaaeaaaaaeaaaaapiaakaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiaamaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaanaaoekaaaaappja
aaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaamma
aaaaoeiappppaaaafdeieefcaaagaaaaeaaaabaaiaabaaaafjaaaaaeegiocaaa
aaaaaaaaagaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaadiaaaaajhcaabaaaaaaaaaaa
fgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaa
aaaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaa
aaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaa
abaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaai
icaabaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaaegbcbaaaacaaaaaaaaaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaalhcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaiaebaaaaaa
aaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaa
egiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaa
aaaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadgaaaaaficaabaaa
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
ebaaaaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaacmaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaaaaaaaaajhccabaaaafaaaaaaegacbaiaebaaaaaaaaaaaaaa
egiccaaaabaaaaaaaeaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaa
laaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_Scale]
Vector 15 [unity_LightmapST]
Vector 16 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[17] = { { 1, 2 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MOV R1.xyz, c[13];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MAD R0.xyz, R0, c[14].w, -vertex.position;
DP3 R0.w, vertex.normal, -R0;
MUL R1.xyz, vertex.normal, R0.w;
MAD R0.xyz, -R1, c[0].y, -R0;
DP3 result.texcoord[1].z, R0, c[7];
DP3 result.texcoord[1].y, R0, c[6];
DP3 result.texcoord[1].x, R0, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[15], c[15].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_Scale]
Vector 14 [unity_LightmapST]
Vector 15 [_MainTex_ST]
"vs_2_0
def c16, 1.00000000, 2.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
mov r1.xyz, c12
mov r1.w, c16.x
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mad r0.xyz, r0, c13.w, -v0
dp3 r0.w, v1, -r0
mul r1.xyz, v1, r0.w
mad r0.xyz, -r1, c16.y, -r0
dp3 oT1.z, r0, c6
dp3 oT1.y, r0, c5
dp3 oT1.x, r0, c4
mad oT0.xy, v2, c15, c15.zwzw
mad oT2.xy, v3, c14, c14.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 112
Vector 80 [unity_LightmapST]
Vector 96 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
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
eefiecedhdkdijbgdkiekidcfpjjgdnodogffnpkabaaaaaalmaeaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaheaaaaaaacaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
diadaaaaeaaaabaamoaaaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaae
egiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
dccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaagaaaaaa
ogikcaaaaaaaaaaaagaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadiaaaaajhcaabaaa
aaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaacaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
baaaaaaiicaabaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaaegbcbaaaacaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaal
hcaabaaaaaaaaaaaegbcbaaaacaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaia
ebaaaaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 112
Vector 80 [unity_LightmapST]
Vector 96 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecednmanbljifihiclojpdkbhjdbecfknkpgabaaaaaammagaaaaaeaaaaaa
daaaaaaadmacaaaahmafaaaaeeagaaaaebgpgodjaeacaaaaaeacaaaaaaacpopp
kaabaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaafaa
acaaabaaaaaaaaaaabaaaeaaabaaadaaaaaaaaaaacaaaaaaaeaaaeaaaaaaaaaa
acaaamaaadaaaiaaaaaaaaaaacaabaaaafaaalaaaaaaaaaaaaaaaaaaaaacpopp
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadia
adaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoeka
acaaookaabaaaaacaaaaahiaadaaoekaafaaaaadabaaahiaaaaaffiaamaaoeka
aeaaaaaeaaaaaliaalaakekaaaaaaaiaabaakeiaaeaaaaaeaaaaahiaanaaoeka
aaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeiaaoaaoekaaeaaaaaeaaaaahia
aaaaoeiaapaappkaaaaaoejbaiaaaaadaaaaaiiaaaaaoeibacaaoejaacaaaaad
aaaaaiiaaaaappiaaaaappiaaeaaaaaeaaaaahiaacaaoejaaaaappibaaaaoeib
afaaaaadabaaahiaaaaaffiaajaaoekaaeaaaaaeaaaaaliaaiaakekaaaaaaaia
abaakeiaaeaaaaaeabaaahoaakaaoekaaaaakkiaaaaapeiaaeaaaaaeaaaaamoa
aeaabejaabaabekaabaalekaafaaaaadaaaaapiaaaaaffjaafaaoekaaeaaaaae
aaaaapiaaeaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiaahaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadma
aaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefc
diadaaaaeaaaabaamoaaaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaae
egiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
dccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaagaaaaaa
ogikcaaaaaaaaaaaagaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadiaaaaajhcaabaaa
aaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaacaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
baaaaaaiicaabaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaaegbcbaaaacaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaal
hcaabaaaaaaaaaaaegbcbaaaacaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaia
ebaaaaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaa
acaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaabejfdeheo
maaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaaheaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_Scale]
Vector 15 [unity_LightmapST]
Vector 16 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[17] = { { 1, 2 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R2.xyz, vertex.attrib[14];
MUL R3.xyz, vertex.normal.zxyw, R2.yzxw;
MAD R2.xyz, vertex.normal.yzxw, R2.zxyw, -R3;
MOV R1.xyz, c[13];
MOV R1.w, c[0].x;
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MAD R1.xyz, R0, c[14].w, -vertex.position;
DP3 R0.w, vertex.normal, -R1;
MUL R0.xyz, vertex.normal, R0.w;
MAD R0.xyz, -R0, c[0].y, -R1;
MUL R2.xyz, R2, vertex.attrib[14].w;
DP3 result.texcoord[1].z, R0, c[7];
DP3 result.texcoord[1].y, R0, c[6];
DP3 result.texcoord[1].x, R0, c[5];
DP3 result.texcoord[3].y, R1, R2;
MOV result.texcoord[3].z, -R0.w;
DP3 result.texcoord[3].x, R1, vertex.attrib[14];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[15], c[15].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 25 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_Scale]
Vector 14 [unity_LightmapST]
Vector 15 [_MainTex_ST]
"vs_2_0
def c16, 1.00000000, 2.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r2.xyz, v1
mul r3.xyz, v2.zxyw, r2.yzxw
mov r2.xyz, v1
mad r2.xyz, v2.yzxw, r2.zxyw, -r3
mov r1.xyz, c12
mov r1.w, c16.x
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mad r0.xyz, r0, c13.w, -v0
dp3 r0.w, v2, -r0
mul r1.xyz, v2, r0.w
mad r1.xyz, -r1, c16.y, -r0
mul r2.xyz, r2, v1.w
dp3 oT1.z, r1, c6
dp3 oT1.y, r1, c5
dp3 oT1.x, r1, c4
dp3 oT3.y, r0, r2
mov oT3.z, -r0.w
dp3 oT3.x, r0, v1
mad oT0.xy, v3, c15, c15.zwzw
mad oT2.xy, v4, c14, c14.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 112
Vector 80 [unity_LightmapST]
Vector 96 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
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
eefiecednopmpnkkhmjlfdadnobobkfpiljbkkdpabaaaaaakaafaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaimaaaaaaacaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcaeaeaaaaeaaaabaa
ababaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacadaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaa
aaaaaaaaafaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaa
aaaaaaaaegiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
aaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaacaaaaaa
bdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaaiicaabaaaaaaaaaaaegacbaia
ebaaaaaaaaaaaaaaegbcbaaaacaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaadkaabaaaaaaaaaaadcaaaaalhcaabaaaabaaaaaaegbcbaaaacaaaaaa
pgapbaiaebaaaaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaa
abaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaabaaaaaa
egadbaaaabaaaaaadiaaaaahhcaabaaaabaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgbpbaaaabaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaaaaaaaaaa
baaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 112
Vector 80 [unity_LightmapST]
Vector 96 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedcofkclifnchdoeefcknbkcibhgckmcpkabaaaaaacmaiaaaaaeaaaaaa
daaaaaaaliacaaaameagaaaaimahaaaaebgpgodjiaacaaaaiaacaaaaaaacpopp
bmacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaafaa
acaaabaaaaaaaaaaabaaaeaaabaaadaaaaaaaaaaacaaaaaaaeaaaeaaaaaaaaaa
acaaamaaadaaaiaaaaaaaaaaacaabaaaafaaalaaaaaaaaaaaaaaaaaaaaacpopp
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaae
aaaaadoaadaaoejaacaaoekaacaaookaabaaaaacaaaaahiaadaaoekaafaaaaad
abaaahiaaaaaffiaamaaoekaaeaaaaaeaaaaaliaalaakekaaaaaaaiaabaakeia
aeaaaaaeaaaaahiaanaaoekaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeia
aoaaoekaaeaaaaaeaaaaahiaaaaaoeiaapaappkaaaaaoejbaiaaaaadaaaaaiia
aaaaoeibacaaoejaacaaaaadaaaaaiiaaaaappiaaaaappiaaeaaaaaeabaaahia
acaaoejaaaaappibaaaaoeibafaaaaadacaaahiaabaaffiaajaaoekaaeaaaaae
abaaaliaaiaakekaabaaaaiaacaakeiaaeaaaaaeabaaahoaakaaoekaabaakkia
abaapeiaaeaaaaaeaaaaamoaaeaabejaabaabekaabaalekaaiaaaaadacaaaboa
abaaoejaaaaaoeiaabaaaaacabaaahiaacaaoejaafaaaaadacaaahiaabaancia
abaamjjaaeaaaaaeabaaahiaabaamjiaabaancjaacaaoeibafaaaaadabaaahia
abaaoeiaabaappjaaiaaaaadacaaacoaabaaoeiaaaaaoeiaaiaaaaadacaaaeoa
acaaoejaaaaaoeiaafaaaaadaaaaapiaaaaaffjaafaaoekaaeaaaaaeaaaaapia
aeaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaahaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcaeaeaaaa
eaaaabaaababaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacadaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaa
dcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaafaaaaaa
kgiocaaaaaaaaaaaafaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaa
aeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaa
acaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaa
acaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaa
acaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaaiicaabaaaaaaaaaaa
egacbaiaebaaaaaaaaaaaaaaegbcbaaaacaaaaaaaaaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaalhcaabaaaabaaaaaaegbcbaaa
acaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaai
hcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaak
lcaabaaaabaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaabaaaaaaegaibaaa
acaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaa
abaaaaaaegadbaaaabaaaaaadiaaaaahhcaabaaaabaaaaaajgbebaaaabaaaaaa
cgbjbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaajgbebaaaacaaaaaacgbjbaaa
abaaaaaaegacbaiaebaaaaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgbpbaaaabaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaaabaaaaaa
egacbaaaaaaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaa
aaaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaaaaaaaaaa
doaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_4LightPosX0]
Vector 15 [unity_4LightPosY0]
Vector 16 [unity_4LightPosZ0]
Vector 17 [unity_4LightAtten0]
Vector 18 [unity_LightColor0]
Vector 19 [unity_LightColor1]
Vector 20 [unity_LightColor2]
Vector 21 [unity_LightColor3]
Vector 22 [unity_SHAr]
Vector 23 [unity_SHAg]
Vector 24 [unity_SHAb]
Vector 25 [unity_SHBr]
Vector 26 [unity_SHBg]
Vector 27 [unity_SHBb]
Vector 28 [unity_SHC]
Vector 29 [unity_Scale]
Vector 30 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[31] = { { 1, 2, 0 },
		state.matrix.mvp,
		program.local[5..30] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MUL R3.xyz, vertex.normal, c[29].w;
DP3 R5.x, R3, c[5];
DP4 R4.zw, vertex.position, c[6];
ADD R2, -R4.z, c[15];
DP3 R4.z, R3, c[6];
DP4 R3.w, vertex.position, c[5];
MUL R0, R4.z, R2;
ADD R1, -R3.w, c[14];
MUL R2, R2, R2;
MOV R5.y, R4.z;
MOV R5.w, c[0].x;
DP4 R4.xy, vertex.position, c[7];
MAD R0, R5.x, R1, R0;
MAD R2, R1, R1, R2;
ADD R1, -R4.x, c[16];
DP3 R4.x, R3, c[7];
MAD R2, R1, R1, R2;
MAD R0, R4.x, R1, R0;
MUL R1, R2, c[17];
ADD R1, R1, c[0].x;
MOV R5.z, R4.x;
RSQ R2.x, R2.x;
RSQ R2.y, R2.y;
RSQ R2.z, R2.z;
RSQ R2.w, R2.w;
MUL R0, R0, R2;
DP4 R2.z, R5, c[24];
DP4 R2.y, R5, c[23];
DP4 R2.x, R5, c[22];
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].z;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[19];
MAD R1.xyz, R0.x, c[18], R1;
MAD R0.xyz, R0.z, c[20], R1;
MUL R1, R5.xyzz, R5.yzzx;
MAD R0.xyz, R0.w, c[21], R0;
DP4 R3.z, R1, c[27];
DP4 R3.x, R1, c[25];
DP4 R3.y, R1, c[26];
ADD R3.xyz, R2, R3;
MOV R1.w, c[0].x;
MOV R1.xyz, c[13];
DP4 R2.z, R1, c[11];
DP4 R2.y, R1, c[10];
DP4 R2.x, R1, c[9];
MUL R0.w, R4.z, R4.z;
MAD R1.w, R5.x, R5.x, -R0;
MAD R1.xyz, R2, c[29].w, -vertex.position;
DP3 R0.w, vertex.normal, -R1;
MUL R5.yzw, R1.w, c[28].xxyz;
ADD R3.xyz, R3, R5.yzww;
ADD result.texcoord[3].xyz, R3, R0;
MUL R2.xyz, vertex.normal, R0.w;
MAD R1.xyz, -R2, c[0].y, -R1;
MOV R3.x, R4.w;
MOV R3.y, R4;
DP3 result.texcoord[1].z, R1, c[7];
DP3 result.texcoord[1].y, R1, c[6];
DP3 result.texcoord[1].x, R1, c[5];
MOV result.texcoord[2].z, R4.x;
MOV result.texcoord[2].y, R4.z;
MOV result.texcoord[2].x, R5;
ADD result.texcoord[4].xyz, -R3.wxyw, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[30], c[30].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 72 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_4LightPosX0]
Vector 14 [unity_4LightPosY0]
Vector 15 [unity_4LightPosZ0]
Vector 16 [unity_4LightAtten0]
Vector 17 [unity_LightColor0]
Vector 18 [unity_LightColor1]
Vector 19 [unity_LightColor2]
Vector 20 [unity_LightColor3]
Vector 21 [unity_SHAr]
Vector 22 [unity_SHAg]
Vector 23 [unity_SHAb]
Vector 24 [unity_SHBr]
Vector 25 [unity_SHBg]
Vector 26 [unity_SHBb]
Vector 27 [unity_SHC]
Vector 28 [unity_Scale]
Vector 29 [_MainTex_ST]
"vs_2_0
def c30, 1.00000000, 2.00000000, 0.00000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r3.xyz, v1, c28.w
dp3 r5.x, r3, c4
dp4 r4.zw, v0, c5
add r2, -r4.z, c14
dp3 r4.z, r3, c5
dp4 r3.w, v0, c4
mul r0, r4.z, r2
add r1, -r3.w, c13
mul r2, r2, r2
mov r5.y, r4.z
mov r5.w, c30.x
dp4 r4.xy, v0, c6
mad r0, r5.x, r1, r0
mad r2, r1, r1, r2
add r1, -r4.x, c15
dp3 r4.x, r3, c6
mad r2, r1, r1, r2
mad r0, r4.x, r1, r0
mul r1, r2, c16
add r1, r1, c30.x
mov r5.z, r4.x
rsq r2.x, r2.x
rsq r2.y, r2.y
rsq r2.z, r2.z
rsq r2.w, r2.w
mul r0, r0, r2
dp4 r2.z, r5, c23
dp4 r2.y, r5, c22
dp4 r2.x, r5, c21
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c30.z
mul r0, r0, r1
mul r1.xyz, r0.y, c18
mad r1.xyz, r0.x, c17, r1
mad r0.xyz, r0.z, c19, r1
mul r1, r5.xyzz, r5.yzzx
mad r0.xyz, r0.w, c20, r0
dp4 r3.z, r1, c26
dp4 r3.x, r1, c24
dp4 r3.y, r1, c25
add r3.xyz, r2, r3
mov r1.w, c30.x
mov r1.xyz, c12
dp4 r2.z, r1, c10
dp4 r2.y, r1, c9
dp4 r2.x, r1, c8
mul r0.w, r4.z, r4.z
mad r1.w, r5.x, r5.x, -r0
mad r1.xyz, r2, c28.w, -v0
dp3 r0.w, v1, -r1
mul r5.yzw, r1.w, c27.xxyz
add r3.xyz, r3, r5.yzww
add oT3.xyz, r3, r0
mul r2.xyz, v1, r0.w
mad r1.xyz, -r2, c30.y, -r1
mov r3.x, r4.w
mov r3.y, r4
dp3 oT1.z, r1, c6
dp3 oT1.y, r1, c5
dp3 oT1.x, r1, c4
mov oT2.z, r4.x
mov oT2.y, r4.z
mov oT2.x, r5
add oT4.xyz, -r3.wxyw, c12
mad oT0.xy, v2, c29, c29.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 96
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
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
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedfodflkmcojkjchgapappeifajhjfgijpabaaaaaagmakaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcliaiaaaaeaaaabaacoacaaaafjaaaaae
egiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacagaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaadiaaaaajhcaabaaa
aaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaadaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
baaaaaaiicaabaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaaegbcbaaaacaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaal
hcaabaaaaaaaaaaaegbcbaaaacaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaia
ebaaaaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaa
adaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaafhccabaaaadaaaaaaegacbaaaaaaaaaaadgaaaaaf
icaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaa
aaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaahicaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
aaaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaa
dkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
cmaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaacaaaaaaaaaaaaajpcaabaaaadaaaaaafgafbaiaebaaaaaa
acaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaahpcaabaaaaeaaaaaafgafbaaa
aaaaaaaaegaobaaaadaaaaaadiaaaaahpcaabaaaadaaaaaaegaobaaaadaaaaaa
egaobaaaadaaaaaaaaaaaaajpcaabaaaafaaaaaaagaabaiaebaaaaaaacaaaaaa
egiocaaaacaaaaaaacaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaa
agaabaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaa
afaaaaaaegaobaaaafaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaaafaaaaaa
kgakbaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaaeaaaaaaaaaaaaajhccabaaa
afaaaaaaegacbaiaebaaaaaaacaaaaaaegiccaaaabaaaaaaaeaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaafaaaaaakgakbaaaaaaaaaaaegaobaaaaeaaaaaa
dcaaaaajpcaabaaaacaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaaegaobaaa
adaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaaacaaaaaadcaaaaanpcaabaaa
acaaaaaaegaobaaaacaaaaaaegiocaaaacaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaacaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpegaobaaaacaaaaaadiaaaaahpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaakpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaacaaaaaa
fgafbaaaaaaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaacaaaaaaagaaaaaaagaabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaajaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaaaeaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 96
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
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
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedianhcicombadfbfkflcaodjkbdgdfjbkabaaaaaakaapaaaaaeaaaaaa
daaaaaaagaafaaaacaaoaaaaoiaoaaaaebgpgodjciafaaaaciafaaaaaaacpopp
liaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaafaa
abaaabaaaaaaaaaaabaaaeaaabaaacaaaaaaaaaaacaaacaaaiaaadaaaaaaaaaa
acaacgaaahaaalaaaaaaaaaaadaaaaaaaeaabcaaaaaaaaaaadaaamaaajaabgaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafbpaaapkaaaaaiadpaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoekaabaaookaabaaaaac
aaaaahiaacaaoekaafaaaaadabaaahiaaaaaffiablaaoekaaeaaaaaeaaaaalia
bkaakekaaaaaaaiaabaakeiaaeaaaaaeaaaaahiabmaaoekaaaaakkiaaaaapeia
acaaaaadaaaaahiaaaaaoeiabnaaoekaaeaaaaaeaaaaahiaaaaaoeiaboaappka
aaaaoejbaiaaaaadaaaaaiiaaaaaoeibacaaoejaacaaaaadaaaaaiiaaaaappia
aaaappiaaeaaaaaeaaaaahiaacaaoejaaaaappibaaaaoeibafaaaaadabaaahia
aaaaffiabhaaoekaaeaaaaaeaaaaaliabgaakekaaaaaaaiaabaakeiaaeaaaaae
abaaahoabiaaoekaaaaakkiaaaaapeiaafaaaaadaaaaahiaaaaaffjabhaaoeka
aeaaaaaeaaaaahiabgaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabiaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiabjaaoekaaaaappjaaaaaoeiaacaaaaad
aeaaahoaaaaaoeibacaaoekaacaaaaadabaaapiaaaaaffibaeaaoekaafaaaaad
acaaapiaabaaoeiaabaaoeiaacaaaaadadaaapiaaaaaaaibadaaoekaacaaaaad
aaaaapiaaaaakkibafaaoekaaeaaaaaeacaaapiaadaaoeiaadaaoeiaacaaoeia
aeaaaaaeacaaapiaaaaaoeiaaaaaoeiaacaaoeiaahaaaaacaeaaabiaacaaaaia
ahaaaaacaeaaaciaacaaffiaahaaaaacaeaaaeiaacaakkiaahaaaaacaeaaaiia
acaappiaabaaaaacafaaabiabpaaaakaaeaaaaaeacaaapiaacaaoeiaagaaoeka
afaaaaiaafaaaaadafaaahiaacaaoejaboaappkaafaaaaadagaaahiaafaaffia
bhaaoekaaeaaaaaeafaaaliabgaakekaafaaaaiaagaakeiaaeaaaaaeafaaahia
biaaoekaafaakkiaafaapeiaafaaaaadabaaapiaabaaoeiaafaaffiaaeaaaaae
abaaapiaadaaoeiaafaaaaiaabaaoeiaaeaaaaaeaaaaapiaaaaaoeiaafaakkia
abaaoeiaafaaaaadaaaaapiaaeaaoeiaaaaaoeiaalaaaaadaaaaapiaaaaaoeia
bpaaffkaagaaaaacabaaabiaacaaaaiaagaaaaacabaaaciaacaaffiaagaaaaac
abaaaeiaacaakkiaagaaaaacabaaaiiaacaappiaafaaaaadaaaaapiaaaaaoeia
abaaoeiaafaaaaadabaaahiaaaaaffiaaiaaoekaaeaaaaaeabaaahiaahaaoeka
aaaaaaiaabaaoeiaaeaaaaaeaaaaahiaajaaoekaaaaakkiaabaaoeiaaeaaaaae
aaaaahiaakaaoekaaaaappiaaaaaoeiaabaaaaacafaaaiiabpaaaakaajaaaaad
abaaabiaalaaoekaafaaoeiaajaaaaadabaaaciaamaaoekaafaaoeiaajaaaaad
abaaaeiaanaaoekaafaaoeiaafaaaaadacaaapiaafaacjiaafaakeiaajaaaaad
adaaabiaaoaaoekaacaaoeiaajaaaaadadaaaciaapaaoekaacaaoeiaajaaaaad
adaaaeiabaaaoekaacaaoeiaacaaaaadabaaahiaabaaoeiaadaaoeiaafaaaaad
aaaaaiiaafaaffiaafaaffiaaeaaaaaeaaaaaiiaafaaaaiaafaaaaiaaaaappib
abaaaaacacaaahoaafaaoeiaaeaaaaaeabaaahiabbaaoekaaaaappiaabaaoeia
acaaaaadadaaahoaaaaaoeiaabaaoeiaafaaaaadaaaaapiaaaaaffjabdaaoeka
aeaaaaaeaaaaapiabcaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiabeaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiabfaaoekaaaaappjaaaaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaa
fdeieefcliaiaaaaeaaaabaacoacaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaa
fjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaa
giaaaaacagaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaa
ogikcaaaaaaaaaaaafaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaa
aeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaa
adaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaa
adaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaa
adaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaaiicaabaaaaaaaaaaa
egacbaiaebaaaaaaaaaaaaaaegbcbaaaacaaaaaaaaaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaai
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
lcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaa
abaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaa
aaaaaaaaegadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaa
pgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaa
amaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaf
hccabaaaadaaaaaaegacbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
icaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakicaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaacaaaaaa
aaaaaaajpcaabaaaadaaaaaafgafbaiaebaaaaaaacaaaaaaegiocaaaacaaaaaa
adaaaaaadiaaaaahpcaabaaaaeaaaaaafgafbaaaaaaaaaaaegaobaaaadaaaaaa
diaaaaahpcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaaj
pcaabaaaafaaaaaaagaabaiaebaaaaaaacaaaaaaegiocaaaacaaaaaaacaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaa
egaobaaaadaaaaaaaaaaaaajpcaabaaaafaaaaaakgakbaiaebaaaaaaacaaaaaa
egiocaaaacaaaaaaaeaaaaaaaaaaaaajhccabaaaafaaaaaaegacbaiaebaaaaaa
acaaaaaaegiccaaaabaaaaaaaeaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
afaaaaaakgakbaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaacaaaaaa
egaobaaaafaaaaaaegaobaaaafaaaaaaegaobaaaadaaaaaaeeaaaaafpcaabaaa
adaaaaaaegaobaaaacaaaaaadcaaaaanpcaabaaaacaaaaaaegaobaaaacaaaaaa
egiocaaaacaaaaaaafaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
aoaaaaakpcaabaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
egaobaaaacaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaa
adaaaaaadeaaaaakpcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaacaaaaaa
egaobaaaaaaaaaaadiaaaaaihcaabaaaacaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaahaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaagaaaaaa
agaabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaaiaaaaaakgakbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaahhccabaaaaeaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaa
keaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 3 [_ReflectColor]
Float 4 [_ReflectBrightness]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
"!!ARBfp1.0
PARAM c[6] = { program.local[0..4],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.xyz, fragment.texcoord[1], texture[1], CUBE;
DP3 R1.w, fragment.texcoord[2], c[0];
MUL R2.xyz, R0, c[1];
MAX R1.w, R1, c[5].x;
MUL R2.xyz, R2, R1.w;
ADD R2.xyz, R2, c[5].x;
MUL R2.xyz, R2, c[5].y;
MAD R0.xyz, R0, fragment.texcoord[3], R2;
MUL R1.xyz, R1, c[3];
MAD result.color.xyz, R1, c[4].x, R0;
MOV result.color.w, R0;
END
# 12 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_ReflectColor]
Float 3 [_ReflectBrightness]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
"ps_2_0
dcl_2d s0
dcl_cube s1
def c4, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t1, s1
texld r1, t0, s0
dp3_pp r0.x, t2, c0
mul_pp r3.xyz, r1, c1
max_pp r0.x, r0, c4
mul_pp r0.xyz, r3, r0.x
add r0.xyz, r0, c4.x
mul r0.xyz, r0, c4.y
mad_pp r0.xyz, r1, t3, r0
mul_pp r1.xyz, r2, c2
mad_pp r0.xyz, r1, c3.x, r0
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
Vector 48 [_ReflectColor]
Float 64 [_ReflectBrightness]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedgpiajoagopiglolleecciopmnceephekabaaaaaaceadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcaeacaaaa
eaaaaaaaibaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagcbaaaadhcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
acaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaadaaaaaaegiccaaaabaaaaaa
aaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaaabaaaaaaagijcaaaaaaaaaaa
abaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaa
aaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaj
hcaabaaaaaaaaaaaegacbaaaabaaaaaaegbcbaaaaeaaaaaaegacbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egbcbaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaadcaaaaakhccabaaa
aaaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaaaeaaaaaaegacbaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
Vector 48 [_ReflectColor]
Float 64 [_ReflectBrightness]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0_level_9_1
eefiecedajgmmpgjogbphgfhljaagefbgjeadjneabaaaaaajmaeaaaaaeaaaaaa
daaaaaaakeabaaaalaadaaaagiaeaaaaebgpgodjgmabaaaagmabaaaaaaacpppp
bmabaaaafaaaaaaaadaacmaaaaaafaaaaaaafaaaacaaceaaaaaafaaaaaaaaaaa
abababaaaaaaabaaabaaaaaaaaaaaaaaaaaaadaaacaaabaaaaaaaaaaabaaaaaa
abaaadaaaaaaaaaaaaacppppfbaaaaafaeaaapkaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaaiaabaaahlabpaaaaac
aaaaaaiaacaachlabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaajaaaaiapka
bpaaaaacaaaaaajiabaiapkaecaaaaadaaaacpiaaaaaoelaaaaioekaecaaaaad
abaacpiaabaaoelaabaioekaaiaaaaadabaaciiaacaaoelaadaaoekaalaaaaad
acaaciiaabaappiaaeaaaakaafaaaaadacaachiaaaaaoeiaaaaaoekaafaaaaad
acaaahiaacaappiaacaaoeiaacaaaaadacaachiaacaaoeiaacaaoeiaaeaaaaae
acaachiaaaaaoeiaadaaoelaacaaoeiaafaaaaadabaachiaabaaoeiaabaaoeka
aeaaaaaeaaaachiaabaaoeiaacaaaakaacaaoeiaabaaaaacaaaicpiaaaaaoeia
ppppaaaafdeieefcaeacaaaaeaaaaaaaibaaaaaafjaaaaaeegiocaaaaaaaaaaa
afaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaae
aahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaa
adaaaaaaegiccaaaabaaaaaaaaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaa
abaaaaaaagijcaaaaaaaaaaaabaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaa
aaaaaaaajgahbaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaegbcbaaa
aeaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegbcbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
adaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaaabaaaaaaagiacaaaaaaaaaaa
aeaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_ReflectColor]
Float 1 [_ReflectBrightness]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[1], texture[1], CUBE;
TEX R1, fragment.texcoord[2], texture[2], 2D;
MUL R2.xyz, R2, c[0];
MUL R1.xyz, R1.w, R1;
MUL R2.xyz, R2, c[1].x;
MUL R0.xyz, R0, R1;
MAD result.color.xyz, R0, c[2].x, R2;
MOV result.color.w, R0;
END
# 9 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_ReflectColor]
Float 1 [_ReflectBrightness]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
"ps_2_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
def c2, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xy
texld r1, t0, s0
texld r2, t1, s1
texld r0, t2, s2
mul_pp r2.xyz, r2, c0
mul_pp r0.xyz, r0.w, r0
mul_pp r2.xyz, r2, c1.x
mul_pp r0.xyz, r1, r0
mad_pp r0.xyz, r0, c2.x, r2
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 112
Vector 48 [_ReflectColor]
Float 64 [_ReflectBrightness]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmeefanfjfaiijhhconjcgjfjbcednannabaaaaaaleacaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcmeabaaaaeaaaaaaahbaaaaaafjaaaaaeegiocaaa
aaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbcbaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaah
icaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajhccabaaa
aaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaacaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 112
Vector 48 [_ReflectColor]
Float 64 [_ReflectBrightness]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedpjfhohelchgocpgffeiflaioaealmcnaabaaaaaapeadaaaaaeaaaaaa
daaaaaaagmabaaaadiadaaaamaadaaaaebgpgodjdeabaaaadeabaaaaaaacpppp
piaaaaaadmaaaaaaabaadaaaaaaadmaaaaaadmaaadaaceaaaaaadmaaaaaaaaaa
abababaaacacacaaaaaaadaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapka
aaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaahlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajiabaiapka
bpaaaaacaaaaaajaacaiapkaabaaaaacaaaaadiaaaaabllaecaaaaadaaaacpia
aaaaoeiaacaioekaecaaaaadabaacpiaabaaoelaabaioekaecaaaaadacaacpia
aaaaoelaaaaioekaafaaaaadaaaaciiaaaaappiaacaaaakaafaaaaadaaaachia
aaaaoeiaaaaappiaafaaaaadabaachiaabaaoeiaaaaaoekaafaaaaadabaachia
abaaoeiaabaaaakaaeaaaaaeacaachiaacaaoeiaaaaaoeiaabaaoeiaabaaaaac
aaaicpiaacaaoeiappppaaaafdeieefcmeabaaaaeaaaaaaahbaaaaaafjaaaaae
egiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaa
abaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fidaaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbcbaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaa
diaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hccabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaacaaaaaadoaaaaabejfdeheoiaaaaaaa
aeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
heaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaaheaaaaaaacaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamamaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_ReflectColor]
Float 1 [_ReflectBrightness]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[1], texture[1], CUBE;
TEX R1, fragment.texcoord[2], texture[2], 2D;
MUL R2.xyz, R2, c[0];
MUL R1.xyz, R1.w, R1;
MUL R2.xyz, R2, c[1].x;
MUL R0.xyz, R0, R1;
MAD result.color.xyz, R0, c[2].x, R2;
MOV result.color.w, R0;
END
# 9 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_ReflectColor]
Float 1 [_ReflectBrightness]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
"ps_2_0
dcl_2d s0
dcl_cube s1
dcl_2d s2
def c2, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xy
texld r1, t0, s0
texld r2, t1, s1
texld r0, t2, s2
mul_pp r2.xyz, r2, c0
mul_pp r0.xyz, r0.w, r0
mul_pp r2.xyz, r2, c1.x
mul_pp r0.xyz, r1, r0
mad_pp r0.xyz, r0, c2.x, r2
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 112
Vector 48 [_ReflectColor]
Float 64 [_ReflectBrightness]
BindCB  "$Globals" 0
"ps_4_0
eefiecedioponacnfabflhlpcljjgpfcdkbecolkabaaaaaammacaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcmeabaaaaeaaaaaaahbaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafidaaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaaegbcbaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaagiacaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
abaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahicaabaaaaaaaaaaa
dkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaacaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Cube] CUBE 1
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 112
Vector 48 [_ReflectColor]
Float 64 [_ReflectBrightness]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedcaamedgbdgcipimedjibojhijdhpfcflabaaaaaaamaeaaaaaeaaaaaa
daaaaaaagmabaaaadiadaaaaniadaaaaebgpgodjdeabaaaadeabaaaaaaacpppp
piaaaaaadmaaaaaaabaadaaaaaaadmaaaaaadmaaadaaceaaaaaadmaaaaaaaaaa
abababaaacacacaaaaaaadaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapka
aaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaahlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajiabaiapka
bpaaaaacaaaaaajaacaiapkaabaaaaacaaaaadiaaaaabllaecaaaaadaaaacpia
aaaaoeiaacaioekaecaaaaadabaacpiaabaaoelaabaioekaecaaaaadacaacpia
aaaaoelaaaaioekaafaaaaadaaaaciiaaaaappiaacaaaakaafaaaaadaaaachia
aaaaoeiaaaaappiaafaaaaadabaachiaabaaoeiaaaaaoekaafaaaaadabaachia
abaaoeiaabaaaakaaeaaaaaeacaachiaacaaoeiaaaaaoeiaabaaoeiaabaaaaac
aaaicpiaacaaoeiappppaaaafdeieefcmeabaaaaeaaaaaaahbaaaaaafjaaaaae
egiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaa
abaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fidaaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbcbaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaaeaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaa
diaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
hccabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaacaaaaaadoaaaaabejfdeheojiaaaaaa
afaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
imaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamamaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  AlphaTest Greater 0
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[17] = { program.local[0],
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[15].w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
DP4 result.texcoord[4].z, R0, c[11];
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[1].z, R1, c[7];
DP3 result.texcoord[1].y, R1, c[6];
DP3 result.texcoord[1].x, R1, c[5];
ADD result.texcoord[2].xyz, -R0, c[14];
ADD result.texcoord[3].xyz, -R0, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c14.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
dp4 oT4.z, r0, c10
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT1.z, r1, c6
dp3 oT1.y, r1, c5
dp3 oT1.x, r1, c4
add oT2.xyz, -r0, c13
add oT3.xyz, -r0, c12
mad oT0.xy, v2, c15, c15.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefieceddkhojckcjneafinnekcccjfkgdifbkbdabaaaaaanmafaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedmkfifmbiknhdjifkgaehhgpehpdoilemabaaaaaafmaiaaaaaeaaaaaa
daaaaaaakmacaaaanmagaaaakeahaaaaebgpgodjheacaaaaheacaaaaaaacpopp
piabaaaahmaaaaaaahaaceaaaaaahiaaaaaahiaaaaaaceaaabaahiaaaaaaadaa
aeaaabaaaaaaaaaaaaaaajaaabaaafaaaaaaaaaaabaaaeaaabaaagaaaaaaaaaa
acaaaaaaabaaahaaaaaaaaaaadaaaaaaaeaaaiaaaaaaaaaaadaaamaaaeaaamaa
aaaaaaaaadaabeaaabaabaaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaafaaaaadaaaaahiaacaaoejabaaappka
afaaaaadabaaahiaaaaaffiaanaaoekaaeaaaaaeaaaaaliaamaakekaaaaaaaia
abaakeiaaeaaaaaeabaaahoaaoaaoekaaaaakkiaaaaapeiaafaaaaadaaaaahia
aaaaffjaanaaoekaaeaaaaaeaaaaahiaamaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaahiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaappja
aaaaoeiaacaaaaadacaaahoaaaaaoeibahaaoekaacaaaaadadaaahoaaaaaoeib
agaaoekaafaaaaadaaaaapiaaaaaffjaanaaoekaaeaaaaaeaaaaapiaamaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaapaaoekaaaaappjaaaaaoeiaafaaaaadabaaahiaaaaaffiaacaaoeka
aeaaaaaeabaaahiaabaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiaadaaoeka
aaaakkiaabaaoeiaaeaaaaaeaeaaahoaaeaaoekaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaajaaoekaaeaaaaaeaaaaapiaaiaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaakaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaalaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheo
maaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_WorldSpaceLightPos0]
Vector 11 [unity_Scale]
Vector 12 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[13] = { program.local[0],
		state.matrix.mvp,
		program.local[5..12] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[11].w;
DP3 result.texcoord[1].z, R0, c[7];
DP3 result.texcoord[1].y, R0, c[6];
DP3 result.texcoord[1].x, R0, c[5];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.texcoord[2].xyz, c[10];
ADD result.texcoord[3].xyz, -R0, c[9];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[12], c[12].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 14 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_WorldSpaceLightPos0]
Vector 10 [unity_Scale]
Vector 11 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c10.w
dp3 oT1.z, r0, c6
dp3 oT1.y, r0, c5
dp3 oT1.x, r0, c4
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oT2.xyz, c9
add oT3.xyz, -r0, c8
mad oT0.xy, v2, c11, c11.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 96
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedcfagdplbneeencmfjejmjkpdlemjafdhabaaaaaahmaeaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcoaacaaaaeaaaabaa
liaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaa
egbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaa
egiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaak
hccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaa
aaaaaaaadgaaaaaghccabaaaadaaaaaaegiccaaaacaaaaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaaaeaaaaaa
egacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 96
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefieceddmgjhcinfafkhpainiggdkgdmlbabnlgabaaaaaafeagaaaaaeaaaaaa
daaaaaaaaeacaaaaomaeaaaaleafaaaaebgpgodjmmabaaaammabaaaaaaacpopp
fmabaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaafaa
abaaabaaaaaaaaaaabaaaeaaabaaacaaaaaaaaaaacaaaaaaabaaadaaaaaaaaaa
adaaaaaaaeaaaeaaaaaaaaaaadaaamaaaeaaaiaaaaaaaaaaadaabeaaabaaamaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaafaaaaadaaaaahiaacaaoejaamaappkaafaaaaadabaaahiaaaaaffia
ajaaoekaaeaaaaaeaaaaaliaaiaakekaaaaaaaiaabaakeiaaeaaaaaeabaaahoa
akaaoekaaaaakkiaaaaapeiaafaaaaadaaaaahiaaaaaffjaajaaoekaaeaaaaae
aaaaahiaaiaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiaakaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaahiaalaaoekaaaaappjaaaaaoeiaacaaaaadadaaahoa
aaaaoeibacaaoekaafaaaaadaaaaapiaaaaaffjaafaaoekaaeaaaaaeaaaaapia
aeaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaahaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacacaaahoaadaaoeka
ppppaaaafdeieefcoaacaaaaeaaaabaaliaaaaaafjaaaaaeegiocaaaaaaaaaaa
agaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaa
abaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaa
gfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacacaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
adaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaa
afaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaghccabaaaadaaaaaa
egiccaaaacaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[17] = { program.local[0],
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[15].w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
DP4 result.texcoord[4].w, R0, c[12];
DP4 result.texcoord[4].z, R0, c[11];
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[1].z, R1, c[7];
DP3 result.texcoord[1].y, R1, c[6];
DP3 result.texcoord[1].x, R1, c[5];
ADD result.texcoord[2].xyz, -R0, c[14];
ADD result.texcoord[3].xyz, -R0, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 19 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c14.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
dp4 oT4.w, r0, c11
dp4 oT4.z, r0, c10
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT1.z, r1, c6
dp3 oT1.y, r1, c5
dp3 oT1.x, r1, c4
add oT2.xyz, -r0, c13
add oT3.xyz, -r0, c12
mad oT0.xy, v2, c15, c15.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefieceddbanifbcfgnkplbfjfiabeclhhodmaonabaaaaaanmafaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadpccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaa
dcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedfhcpcgibhfhmgcnpfhmoablmeinpfleoabaaaaaafmaiaaaaaeaaaaaa
daaaaaaakmacaaaanmagaaaakeahaaaaebgpgodjheacaaaaheacaaaaaaacpopp
piabaaaahmaaaaaaahaaceaaaaaahiaaaaaahiaaaaaaceaaabaahiaaaaaaadaa
aeaaabaaaaaaaaaaaaaaajaaabaaafaaaaaaaaaaabaaaeaaabaaagaaaaaaaaaa
acaaaaaaabaaahaaaaaaaaaaadaaaaaaaeaaaiaaaaaaaaaaadaaamaaaeaaamaa
aaaaaaaaadaabeaaabaabaaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaafaaaaadaaaaahiaacaaoejabaaappka
afaaaaadabaaahiaaaaaffiaanaaoekaaeaaaaaeaaaaaliaamaakekaaaaaaaia
abaakeiaaeaaaaaeabaaahoaaoaaoekaaaaakkiaaaaapeiaafaaaaadaaaaahia
aaaaffjaanaaoekaaeaaaaaeaaaaahiaamaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaahiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaappja
aaaaoeiaacaaaaadacaaahoaaaaaoeibahaaoekaacaaaaadadaaahoaaaaaoeib
agaaoekaafaaaaadaaaaapiaaaaaffjaanaaoekaaeaaaaaeaaaaapiaamaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaapaaoekaaaaappjaaaaaoeiaafaaaaadabaaapiaaaaaffiaacaaoeka
aeaaaaaeabaaapiaabaaoekaaaaaaaiaabaaoeiaaeaaaaaeabaaapiaadaaoeka
aaaakkiaabaaoeiaaeaaaaaeaeaaapoaaeaaoekaaaaappiaabaaoeiaafaaaaad
aaaaapiaaaaaffjaajaaoekaaeaaaaaeaaaaapiaaiaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaakaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaalaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadpccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaa
dcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaafaaaaaaegiocaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaabejfdeheo
maaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[17] = { program.local[0],
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[15].w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
DP4 result.texcoord[4].z, R0, c[11];
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[1].z, R1, c[7];
DP3 result.texcoord[1].y, R1, c[6];
DP3 result.texcoord[1].x, R1, c[5];
ADD result.texcoord[2].xyz, -R0, c[14];
ADD result.texcoord[3].xyz, -R0, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c14.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
dp4 oT4.z, r0, c10
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT1.z, r1, c6
dp3 oT1.y, r1, c5
dp3 oT1.x, r1, c4
add oT2.xyz, -r0, c13
add oT3.xyz, -r0, c12
mad oT0.xy, v2, c15, c15.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefieceddkhojckcjneafinnekcccjfkgdifbkbdabaaaaaanmafaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedmkfifmbiknhdjifkgaehhgpehpdoilemabaaaaaafmaiaaaaaeaaaaaa
daaaaaaakmacaaaanmagaaaakeahaaaaebgpgodjheacaaaaheacaaaaaaacpopp
piabaaaahmaaaaaaahaaceaaaaaahiaaaaaahiaaaaaaceaaabaahiaaaaaaadaa
aeaaabaaaaaaaaaaaaaaajaaabaaafaaaaaaaaaaabaaaeaaabaaagaaaaaaaaaa
acaaaaaaabaaahaaaaaaaaaaadaaaaaaaeaaaiaaaaaaaaaaadaaamaaaeaaamaa
aaaaaaaaadaabeaaabaabaaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaafaaaaadaaaaahiaacaaoejabaaappka
afaaaaadabaaahiaaaaaffiaanaaoekaaeaaaaaeaaaaaliaamaakekaaaaaaaia
abaakeiaaeaaaaaeabaaahoaaoaaoekaaaaakkiaaaaapeiaafaaaaadaaaaahia
aaaaffjaanaaoekaaeaaaaaeaaaaahiaamaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaahiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaappja
aaaaoeiaacaaaaadacaaahoaaaaaoeibahaaoekaacaaaaadadaaahoaaaaaoeib
agaaoekaafaaaaadaaaaapiaaaaaffjaanaaoekaaeaaaaaeaaaaapiaamaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaapaaoekaaaaappjaaaaaoeiaafaaaaadabaaahiaaaaaffiaacaaoeka
aeaaaaaeabaaahiaabaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiaadaaoeka
aaaakkiaabaaoeiaaeaaaaaeaeaaahoaaeaaoekaaaaappiaaaaaoeiaafaaaaad
aaaaapiaaaaaffjaajaaoekaaeaaaaaeaaaaapiaaiaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaakaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaalaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcciaeaaaaeaaaabaaakabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaajhccabaaaadaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheo
maaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[17] = { program.local[0],
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[15].w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[1].z, R1, c[7];
DP3 result.texcoord[1].y, R1, c[6];
DP3 result.texcoord[1].x, R1, c[5];
MOV result.texcoord[2].xyz, c[14];
ADD result.texcoord[3].xyz, -R0, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c14.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT1.z, r1, c6
dp3 oT1.y, r1, c5
dp3 oT1.x, r1, c4
mov oT2.xyz, c13
add oT3.xyz, -r0, c12
mad oT0.xy, v2, c15, c15.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedlkbknaccddfnmdhicobpnnbbamkejdeaabaaaaaanaafaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcbmaeaaaaeaaaabaaahabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
mccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaaidcaabaaaabaaaaaafgafbaaaaaaaaaaaegiacaaaaaaaaaaa
aeaaaaaadcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaaadaaaaaaagaabaaa
aaaaaaaaegaabaaaabaaaaaadcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
afaaaaaakgakbaaaaaaaaaaaegaabaaaaaaaaaaadcaaaaakmccabaaaabaaaaaa
agiecaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaagaebaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaa
aaaaaaaaajaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaa
adaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaghccabaaa
adaaaaaaegiccaaaacaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaa
egiccaaaabaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 160
Matrix 48 [_LightMatrix0]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedgojoikhpnkbjpapijmhplbnomkhpindiabaaaaaaemaiaaaaaeaaaaaa
daaaaaaakiacaaaammagaaaajeahaaaaebgpgodjhaacaaaahaacaaaaaaacpopp
peabaaaahmaaaaaaahaaceaaaaaahiaaaaaahiaaaaaaceaaabaahiaaaaaaadaa
aeaaabaaaaaaaaaaaaaaajaaabaaafaaaaaaaaaaabaaaeaaabaaagaaaaaaaaaa
acaaaaaaabaaahaaaaaaaaaaadaaaaaaaeaaaiaaaaaaaaaaadaaamaaaeaaamaa
aaaaaaaaadaabeaaabaabaaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaafaaaaadaaaaahiaacaaoejabaaappka
afaaaaadabaaahiaaaaaffiaanaaoekaaeaaaaaeaaaaaliaamaakekaaaaaaaia
abaakeiaaeaaaaaeabaaahoaaoaaoekaaaaakkiaaaaapeiaafaaaaadaaaaahia
aaaaffjaanaaoekaaeaaaaaeaaaaahiaamaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaahiaaoaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaappja
aaaaoeiaacaaaaadadaaahoaaaaaoeibagaaoekaafaaaaadaaaaapiaaaaaffja
anaaoekaaeaaaaaeaaaaapiaamaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
aoaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaapaaoekaaaaappjaaaaaoeia
afaaaaadabaaadiaaaaaffiaacaaobkaaeaaaaaeaaaaadiaabaaobkaaaaaaaia
abaaoeiaaeaaaaaeaaaaadiaadaaobkaaaaakkiaaaaaoeiaaeaaaaaeaaaaamoa
aeaabekaaaaappiaaaaaeeiaafaaaaadaaaaapiaaaaaffjaajaaoekaaeaaaaae
aaaaapiaaiaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaakaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiaalaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadma
aaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacacaaahoa
ahaaoekappppaaaafdeieefcbmaeaaaaeaaaabaaahabaaaafjaaaaaeegiocaaa
aaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaidcaabaaaabaaaaaafgafbaaaaaaaaaaaegiacaaaaaaaaaaaaeaaaaaa
dcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egaabaaaabaaaaaadcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegaabaaaaaaaaaaadcaaaaakmccabaaaabaaaaaaagiecaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaagaebaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaacaaaaaaegiccaaaadaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaghccabaaaadaaaaaa
egiccaaaacaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhccabaaaaeaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaa
abaaaaaaaeaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
DP3 R1.x, fragment.texcoord[4], fragment.texcoord[4];
MUL R0.xyz, R0, c[0];
MOV result.color.w, R0;
TEX R1.w, R1.x, texture[1], 2D;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[2];
DP3 R1.x, fragment.texcoord[1], R1;
MAX R1.x, R1, c[2];
MUL R0.xyz, R0, R1.x;
MUL R1.x, R1.w, c[2].y;
ADD R0.xyz, R0, c[2].x;
MUL result.color.xyz, R0, R1.x;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t4.xyz
texld r1, t0, s0
dp3 r0.x, t4, t4
mov r0.xy, r0.x
mul_pp r1.xyz, r1, c0
mov_pp r0.w, r1
texld r2, r0, s1
dp3_pp r0.x, t2, t2
rsq_pp r0.x, r0.x
mul_pp r0.xyz, r0.x, t2
dp3_pp r0.x, t1, r0
max_pp r0.x, r0, c1
mul_pp r1.xyz, r1, r0.x
mul_pp r0.x, r2, c1.y
add r1.xyz, r1, c1.x
mul r0.xyz, r1, r0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "POINT" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjmhbcbppmmlpflodcpabocijcndlemccabaaaaaaciadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcaiacaaaa
eaaaaaaaicaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaafaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaa
baaaaaahbcaabaaaaaaaaaaaegbcbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaai
ocaabaaaaaaaaaaaagajbaaaabaaaaaaagijcaaaaaaaaaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaa
aaaaaaaajgahbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaafaaaaaa
egbcbaaaafaaaaaaefaaaaajpcaabaaaabaaaaaapgapbaaaaaaaaaaaeghobaaa
abaaaaaaaagabaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaa
akaabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedllcanglhiddoimgpgjnebcpnehjmkmdkabaaaaaaiiaeaaaaaeaaaaaa
daaaaaaaimabaaaajmadaaaafeaeaaaaebgpgodjfeabaaaafeabaaaaaaacpppp
bmabaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaaia
abaachlabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaiaaeaaahlabpaaaaac
aaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaaiaaaaadaaaaaiiaaeaaoela
aeaaoelaabaaaaacaaaaadiaaaaappiaecaaaaadaaaacpiaaaaaoeiaaaaioeka
ecaaaaadabaacpiaaaaaoelaabaioekaacaaaaadaaaaabiaaaaaaaiaaaaaaaia
ceaaaaacacaachiaacaaoelaaiaaaaadaaaacciaabaaoelaacaaoeiaalaaaaad
acaacbiaaaaaffiaabaaaakaafaaaaadaaaacoiaabaabliaaaaablkaafaaaaad
aaaaaoiaacaaaaiaaaaaoeiaafaaaaadabaachiaaaaaaaiaaaaabliaabaaaaac
aaaicpiaabaaoeiappppaaaafdeieefcaiacaaaaeaaaaaaaicaaaaaafjaaaaae
egiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaa
abaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaacaaaaaaegacbaaaaaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaa
abaaaaaaagijcaaaaaaaaaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
abaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaa
baaaaaahicaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaaefaaaaaj
pcaabaaaabaaaaaapgapbaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
aaaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaadiaaaaah
hccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheo
laaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaakeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MOV R1.xyz, fragment.texcoord[2];
DP3 R1.x, fragment.texcoord[1], R1;
MAX R1.x, R1, c[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1.x;
ADD R0.xyz, R0, c[2].x;
MUL result.color.xyz, R0, c[2].y;
MOV result.color.w, R0;
END
# 9 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
texld r1, t0, s0
mov_pp r0.xyz, t2
dp3_pp r0.x, t1, r0
max_pp r0.x, r0, c1
mul_pp r1.xyz, r1, c0
mul_pp r0.xyz, r1, r0.x
add r0.xyz, r0, c1.x
mul r0.xyz, r0, c1.y
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmepjnlopkggomelikkclphaomfadilnbabaaaaaaeaacaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcdiabaaaaeaaaaaaaeoaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaacaaaaaaegbcbaaaadaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaa
abaaaaaaagijcaaaaaaaaaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
abaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaa
aaaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 96
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfmclojbadimncobcnnjpnpiaegbdgeneabaaaaaaeiadaaaaaeaaaaaa
daaaaaaadeabaaaaheacaaaabeadaaaaebgpgodjpmaaaaaapmaaaaaaaaacpppp
miaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaabaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaaiaabaachla
bpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaacpia
aaaaoelaaaaioekaabaaaaacabaaahiaabaaoelaaiaaaaadabaacbiaabaaoeia
acaaoelaalaaaaadacaaciiaabaaaaiaabaaaakaafaaaaadabaachiaaaaaoeia
aaaaoekaafaaaaadabaaahiaacaappiaabaaoeiaacaaaaadaaaachiaabaaoeia
abaaoeiaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdiabaaaaeaaaaaaa
eoaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaacaaaaaaegbcbaaa
adaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaaabaaaaaaagijcaaaaaaaaaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaahhcaabaaa
aaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaaaaaaaaahhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahahaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 0.5, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R2, fragment.texcoord[0], texture[0], 2D;
DP3 R0.z, fragment.texcoord[4], fragment.texcoord[4];
RCP R0.x, fragment.texcoord[4].w;
MAD R0.xy, fragment.texcoord[4], R0.x, c[2].y;
MOV result.color.w, R2;
TEX R0.w, R0, texture[1], 2D;
TEX R1.w, R0.z, texture[2], 2D;
DP3 R0.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[2];
DP3 R1.x, fragment.texcoord[1], R0;
MAX R1.y, R1.x, c[2].x;
MUL R0.xyz, R2, c[0];
SLT R1.x, c[2], fragment.texcoord[4].z;
MUL R0.w, R1.x, R0;
MUL R0.w, R0, R1;
MUL R0.xyz, R0, R1.y;
MUL R0.w, R0, c[2].z;
ADD R0.xyz, R0, c[2].x;
MUL result.color.xyz, R0, R0.w;
END
# 20 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, 0.50000000, 0.00000000, 1.00000000, 2.00000000
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t4
texld r2, t0, s0
dp3 r1.x, t4, t4
mov r1.xy, r1.x
rcp r0.x, t4.w
mad r0.xy, t4, r0.x, c1.x
mul_pp r2.xyz, r2, c0
texld r3, r1, s2
texld r0, r0, s1
dp3_pp r1.x, t2, t2
cmp r0.x, -t4.z, c1.y, c1.z
mul_pp r0.x, r0, r0.w
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, t2
dp3_pp r1.x, t1, r1
mul_pp r0.x, r0, r3
max_pp r1.x, r1, c1.y
mul_pp r1.xyz, r2, r1.x
mul_pp r0.x, r0, c1.w
add r1.xyz, r1, c1.y
mul r0.xyz, r1, r0.x
mov_pp r0.w, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_LightTexture0] 2D 0
SetTexture 2 [_LightTextureB0] 2D 1
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmmofbcofobfjehlidopfkfnlbndookababaaaaaaaaaeaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaacaaaa
eaaaaaaaliaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaa
afaaaaaapgbpbaaaafaaaaaaaaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadbaaaaahbcaabaaa
aaaaaaaaabeaaaaaaaaaaaaackbabaaaafaaaaaaabaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahbcaabaaaaaaaaaaadkaabaaa
aaaaaaaaakaabaaaaaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaafaaaaaa
egbcbaaaafaaaaaaefaaaaajpcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaa
acaaaaaaaagabaaaabaaaaaaapaaaaahbcaabaaaaaaaaaaaagaabaaaaaaaaaaa
agaabaaaabaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagbjbaaaadaaaaaabaaaaaahccaabaaaaaaaaaaa
egbcbaaaacaaaaaajgahbaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaacaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
abaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaaabaaaaaa
diaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "SPOT" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_LightTexture0] 2D 0
SetTexture 2 [_LightTextureB0] 2D 1
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedlkgnnjbliehkamihibbnphdohgekelfoabaaaaaameafaaaaaeaaaaaa
daaaaaaapaabaaaaniaeaaaajaafaaaaebgpgodjliabaaaaliabaaaaaaacpppp
hmabaaaadmaaaaaaabaadaaaaaaadmaaaaaadmaaadaaceaaaaaadmaaabaaaaaa
acababaaaaacacaaaaaaabaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapka
aaaaaadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaac
aaaaaaiaabaachlabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaiaaeaaapla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaaja
acaiapkaagaaaaacaaaaaiiaaeaapplaaeaaaaaeaaaaadiaaeaaoelaaaaappia
abaaaakaaiaaaaadabaaaiiaaeaaoelaaeaaoelaabaaaaacabaaadiaabaappia
ecaaaaadaaaacpiaaaaaoeiaaaaioekaecaaaaadabaacpiaabaaoeiaabaioeka
ecaaaaadacaacpiaaaaaoelaacaioekaafaaaaadaaaacbiaaaaappiaabaaaaia
fiaaaaaeaaaacbiaaeaakklbabaaffkaaaaaaaiaacaaaaadaaaaabiaaaaaaaia
aaaaaaiaceaaaaacabaachiaacaaoelaaiaaaaadaaaacciaabaaoelaabaaoeia
alaaaaadabaacbiaaaaaffiaabaaffkaafaaaaadaaaacoiaacaabliaaaaablka
afaaaaadaaaaaoiaabaaaaiaaaaaoeiaafaaaaadacaachiaaaaaaaiaaaaablia
abaaaaacaaaicpiaacaaoeiappppaaaafdeieefcoaacaaaaeaaaaaaaliaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaafaaaaaapgbpbaaa
afaaaaaaaaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadbaaaaahbcaabaaaaaaaaaaaabeaaaaa
aaaaaaaackbabaaaafaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaiadpdiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaa
aaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaa
efaaaaajpcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaa
abaaaaaaapaaaaahbcaabaaaaaaaaaaaagaabaaaaaaaaaaaagaabaaaabaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaa
aaaaaaaaagbjbaaaadaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaacaaaaaa
jgahbaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaacaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaah
ocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaaabaaaaaadiaaaaahhccabaaa
aaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[4], texture[2], CUBE;
DP3 R0.x, fragment.texcoord[4], fragment.texcoord[4];
MOV result.color.w, R2;
TEX R0.w, R0.x, texture[1], 2D;
DP3 R0.x, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[2];
DP3 R1.x, fragment.texcoord[1], R0;
MUL R0.w, R0, R1;
MUL R0.xyz, R2, c[0];
MAX R1.x, R1, c[2];
MUL R0.xyz, R0, R1.x;
MUL R0.w, R0, c[2].y;
ADD R0.xyz, R0, c[2].x;
MUL result.color.xyz, R0, R0.w;
END
# 16 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_cube s2
def c1, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t4.xyz
texld r2, t0, s0
dp3 r0.x, t4, t4
mov r1.xy, r0.x
mul_pp r2.xyz, r2, c0
texld r0, t4, s2
texld r1, r1, s1
dp3_pp r0.x, t2, t2
rsq_pp r0.x, r0.x
mul_pp r3.xyz, r0.x, t2
mul r0.x, r1, r0.w
dp3_pp r1.x, t1, r3
max_pp r1.x, r1, c1
mul_pp r1.xyz, r2, r1.x
mul_pp r0.x, r0, c1.y
add r1.xyz, r1, c1.x
mul r0.xyz, r1, r0.x
mov_pp r0.w, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 0
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0
eefiecedipfoebnmbimhdkbolagakieidhhohlgcabaaaaaagiadaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefceiacaaaa
eaaaaaaajcaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafidaaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaa
afaaaaaaegbcbaaaafaaaaaaefaaaaajpcaabaaaaaaaaaaaagaabaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbcbaaa
afaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaaapaaaaahbcaabaaaaaaaaaaa
agaabaaaaaaaaaaapgapbaaaabaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaa
diaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagbjbaaaadaaaaaabaaaaaah
ccaabaaaaaaaaaaaegbcbaaaacaaaaaajgahbaaaaaaaaaaadeaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadiaaaaaihcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaadgaaaaaficcabaaa
aaaaaaaadkaabaaaabaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agajbaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT_COOKIE" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_LightTextureB0] 2D 1
SetTexture 2 [_LightTexture0] CUBE 0
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedpfnegedkogmfkhfpdgkncmnglbklhhkdabaaaaaapiaeaaaaaeaaaaaa
daaaaaaalmabaaaaamaeaaaameaeaaaaebgpgodjieabaaaaieabaaaaaaacpppp
eiabaaaadmaaaaaaabaadaaaaaaadmaaaaaadmaaadaaceaaaaaadmaaacaaaaaa
abababaaaaacacaaaaaaabaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapka
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaac
aaaaaaiaabaachlabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaiaaeaaahla
bpaaaaacaaaaaajiaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaaja
acaiapkaaiaaaaadaaaaaiiaaeaaoelaaeaaoelaabaaaaacaaaaadiaaaaappia
ecaaaaadaaaaapiaaaaaoeiaabaioekaecaaaaadabaaapiaaeaaoelaaaaioeka
ecaaaaadacaacpiaaaaaoelaacaioekaafaaaaadaaaacbiaaaaaaaiaabaappia
acaaaaadaaaaabiaaaaaaaiaaaaaaaiaceaaaaacabaachiaacaaoelaaiaaaaad
aaaacciaabaaoelaabaaoeiaalaaaaadabaacbiaaaaaffiaabaaaakaafaaaaad
aaaacoiaacaabliaaaaablkaafaaaaadaaaaaoiaabaaaaiaaaaaoeiaafaaaaad
acaachiaaaaaaaiaaaaabliaabaaaaacaaaicpiaacaaoeiappppaaaafdeieefc
eiacaaaaeaaaaaaajcaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
fidaaaaeaahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaafaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaafaaaaaaegbcbaaaafaaaaaaefaaaaajpcaabaaaaaaaaaaaagaabaaa
aaaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egbcbaaaafaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaaapaaaaahbcaabaaa
aaaaaaaaagaabaaaaaaaaaaapgapbaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafccaabaaaaaaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagbjbaaaadaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaacaaaaaajgahbaaaaaaaaaaadeaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadiaaaaai
hcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaa
aaaaaaaaagajbaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaa
jgahbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[4], texture[1], 2D;
MOV R1.xyz, fragment.texcoord[2];
DP3 R1.x, fragment.texcoord[1], R1;
MAX R1.x, R1, c[2];
MUL R0.xyz, R0, c[0];
MUL R0.xyz, R0, R1.x;
MUL R1.x, R1.w, c[2].y;
ADD R0.xyz, R0, c[2].x;
MUL result.color.xyz, R0, R1.x;
MOV result.color.w, R0;
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LightTexture0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t4.xy
texld r0, t4, s1
texld r1, t0, s0
mov_pp r0.xyz, t2
dp3_pp r0.x, t1, r0
max_pp r0.x, r0, c1
mul_pp r1.xyz, r1, c0
mul_pp r1.xyz, r1, r0.x
mul_pp r0.x, r0.w, c1.y
add r1.xyz, r1, c1.x
mul r0.xyz, r1, r0.x
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0
eefiecedgfeibbmlnbgmnnhjgipphecpoddimnfhabaaaaaamaacaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaabaaaa
eaaaaaaagiaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
mcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaacaaaaaaegbcbaaaadaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaa
abaaaaaaagijcaaaaaaaaaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
abaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaabaaaaaa
diaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL_COOKIE" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 160
Vector 16 [_LightColor0]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedopemddjfoceihdjibmpjfjhpjlbfckapabaaaaaaaeaeaaaaaeaaaaaa
daaaaaaahaabaaaabiadaaaanaadaaaaebgpgodjdiabaaaadiabaaaaaaacpppp
aaabaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaia
abaachlabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaajaaaaiapkabpaaaaac
aaaaaajaabaiapkaabaaaaacaaaaadiaaaaabllaecaaaaadaaaacpiaaaaaoeia
aaaioekaecaaaaadabaacpiaaaaaoelaabaioekaacaaaaadaaaaabiaaaaappia
aaaappiaabaaaaacacaaahiaabaaoelaaiaaaaadaaaacciaacaaoeiaacaaoela
alaaaaadacaacbiaaaaaffiaabaaaakaafaaaaadaaaacoiaabaabliaaaaablka
afaaaaadaaaaaoiaacaaaaiaaaaaoeiaafaaaaadabaachiaaaaaaaiaaaaablia
abaaaaacaaaicpiaabaaoeiappppaaaafdeieefckaabaaaaeaaaaaaagiaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaacaaaaaa
egbcbaaaadaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaaabaaaaaaagijcaaa
aaaaaaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaah
hcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaaaaaaaah
icaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaabaaaaaadiaaaaahhccabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaaaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
}
 }
}
Fallback "Diffuse"
}