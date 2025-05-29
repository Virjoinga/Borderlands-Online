ûßShader "VPaint/Lit/Blend 3 Textures" {
Properties {
 _Color ("Base Color", Color) = (1,1,1,1)
 _Texture1 ("Texture 1", 2D) = "white" {}
 _Texture2 ("Texture 2", 2D) = "white" {}
 _Texture3 ("Texture 3", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "RenderType"="Opaque" }
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [unity_SHAr]
Vector 10 [unity_SHAg]
Vector 11 [unity_SHAb]
Vector 12 [unity_SHBr]
Vector 13 [unity_SHBg]
Vector 14 [unity_SHBb]
Vector 15 [unity_SHC]
Vector 16 [unity_Scale]
Vector 17 [_Texture1_ST]
Vector 18 [_Texture2_ST]
Vector 19 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[20] = { { 1 },
		state.matrix.mvp,
		program.local[5..19] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[16].w;
DP3 R3.w, R1, c[6];
DP3 R2.w, R1, c[7];
DP3 R0.x, R1, c[5];
MOV R0.y, R3.w;
MOV R0.z, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].x;
DP4 R2.z, R0, c[11];
DP4 R2.y, R0, c[10];
DP4 R2.x, R0, c[9];
MUL R0.y, R3.w, R3.w;
DP4 R3.z, R1, c[14];
DP4 R3.y, R1, c[13];
DP4 R3.x, R1, c[12];
MAD R0.y, R0.x, R0.x, -R0;
MUL R1.xyz, R0.y, c[15];
ADD R2.xyz, R2, R3;
ADD result.texcoord[3].xyz, R2, R1;
MOV result.color, vertex.color;
MOV result.texcoord[2].z, R2.w;
MOV result.texcoord[2].y, R3.w;
MOV result.texcoord[2].x, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[17], c[17].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[19], c[19].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 30 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [unity_SHAr]
Vector 9 [unity_SHAg]
Vector 10 [unity_SHAb]
Vector 11 [unity_SHBr]
Vector 12 [unity_SHBg]
Vector 13 [unity_SHBb]
Vector 14 [unity_SHC]
Vector 15 [unity_Scale]
Vector 16 [_Texture1_ST]
Vector 17 [_Texture2_ST]
Vector 18 [_Texture3_ST]
"vs_2_0
def c19, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r1.xyz, v1, c15.w
dp3 r3.w, r1, c5
dp3 r2.w, r1, c6
dp3 r0.x, r1, c4
mov r0.y, r3.w
mov r0.z, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c19.x
dp4 r2.z, r0, c10
dp4 r2.y, r0, c9
dp4 r2.x, r0, c8
mul r0.y, r3.w, r3.w
dp4 r3.z, r1, c13
dp4 r3.y, r1, c12
dp4 r3.x, r1, c11
mad r0.y, r0.x, r0.x, -r0
mul r1.xyz, r0.y, c14
add r2.xyz, r2, r3
add oT3.xyz, r2, r1
mov oD0, v3
mov oT2.z, r2.w
mov oT2.y, r3.w
mov oT2.x, r0
mad oT0.zw, v2.xyxy, c17.xyxy, c17
mad oT0.xy, v2, c16, c16.zwzw
mad oT1.xy, v2, c18, c18.zwzw
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
ConstBuffer "$Globals" 112
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedjicaicmknnbafmkehlcfondffpnlemjoabaaaaaameafaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefcamaeaaaaeaaaabaaadabaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaa
afaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
agaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaa
afaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaafhccabaaaaeaaaaaa
egacbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaai
bcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaai
ccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaai
ecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaa
afaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedphhphddmafbmlpbckjccafelplacjpnbabaaaaaafaaiaaaaaeaaaaaa
daaaaaaaliacaaaammagaaaajeahaaaaebgpgodjiaacaaaaiaacaaaaaaacpopp
bmacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaaeaa
adaaabaaaaaaaaaaabaacgaaahaaaeaaaaaaaaaaacaaaaaaaeaaalaaaaaaaaaa
acaaamaaadaaapaaaaaaaaaaacaabeaaabaabcaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbdaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjabpaaaaac
afaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoekaabaaookaaeaaaaae
aaaaamoaadaaeejaacaaeekaacaaoekaaeaaaaaeabaaadoaadaaoejaadaaoeka
adaaookaafaaaaadaaaaahiaacaaoejabcaappkaafaaaaadabaaahiaaaaaffia
baaaoekaaeaaaaaeaaaaaliaapaakekaaaaaaaiaabaakeiaaeaaaaaeaaaaahia
bbaaoekaaaaakkiaaaaapeiaabaaaaacaaaaaiiabdaaaakaajaaaaadabaaabia
aeaaoekaaaaaoeiaajaaaaadabaaaciaafaaoekaaaaaoeiaajaaaaadabaaaeia
agaaoekaaaaaoeiaafaaaaadacaaapiaaaaacjiaaaaakeiaajaaaaadadaaabia
ahaaoekaacaaoeiaajaaaaadadaaaciaaiaaoekaacaaoeiaajaaaaadadaaaeia
ajaaoekaacaaoeiaacaaaaadabaaahiaabaaoeiaadaaoeiaafaaaaadaaaaaiia
aaaaffiaaaaaffiaaeaaaaaeaaaaaiiaaaaaaaiaaaaaaaiaaaaappibabaaaaac
adaaahoaaaaaoeiaaeaaaaaeaeaaahoaakaaoekaaaaappiaabaaoeiaafaaaaad
aaaaapiaaaaaffjaamaaoekaaeaaaaaeaaaaapiaalaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaoaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacacaaapoaafaaoejappppaaaafdeieefcamaeaaaa
eaaaabaaadabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaad
pcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaa
dcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaafaaaaaa
kgiocaaaaaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaafpccabaaa
adaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaa
pgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaa
amaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaf
hccabaaaaeaaaaaaegacbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
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
dcaaaaakhccabaaaafaaaaaaegiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [unity_LightmapST]
Vector 10 [_Texture1_ST]
Vector 11 [_Texture2_ST]
Vector 12 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[13] = { program.local[0],
		state.matrix.mvp,
		program.local[5..12] };
MOV result.color, vertex.color;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[9], c[9].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [unity_LightmapST]
Vector 9 [_Texture1_ST]
Vector 10 [_Texture2_ST]
Vector 11 [_Texture3_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
dcl_color0 v4
mov oD0, v4
mad oT0.zw, v2.xyxy, c10.xyxy, c10
mad oT0.xy, v2, c9, c9.zwzw
mad oT1.xy, v2, c11, c11.zwzw
mad oT2.xy, v3, c8, c8.zwzw
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
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 128
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedfpfdmgadjhodkckoijjblfifijkmecmmabaaaaaakaadaaaaadaaaaaa
cmaaaaaapeaaaaaajiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaaklfdeieefcaaacaaaa
eaaaabaaiaaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
abaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaa
afaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
agaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 128
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefieceddflfcbajinekaeckmlgcpeiphgigeajpabaaaaaaomaeaaaaaeaaaaaa
daaaaaaahiabaaaaiaadaaaaeiaeaaaaebgpgodjeaabaaaaeaabaaaaaaacpopp
aaabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaeaa
aeaaabaaaaaaaaaaabaaaaaaaeaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapja
bpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoekaacaaooka
aeaaaaaeaaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoaadaaoeja
aeaaoekaaeaaookaaeaaaaaeabaaamoaaeaabejaabaabekaabaalekaafaaaaad
aaaaapiaaaaaffjaagaaoekaaeaaaaaeaaaaapiaafaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaahaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaiaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacacaaapoaafaaoejappppaaaafdeieefcaaacaaaa
eaaaabaaiaaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
abaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaa
afaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
agaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamadaaaajfaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [unity_LightmapST]
Vector 10 [_Texture1_ST]
Vector 11 [_Texture2_ST]
Vector 12 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[13] = { program.local[0],
		state.matrix.mvp,
		program.local[5..12] };
MOV result.color, vertex.color;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[9], c[9].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [unity_LightmapST]
Vector 9 [_Texture1_ST]
Vector 10 [_Texture2_ST]
Vector 11 [_Texture3_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
dcl_color0 v4
mov oD0, v4
mad oT0.zw, v2.xyxy, c10.xyxy, c10
mad oT0.xy, v2, c9, c9.zwzw
mad oT1.xy, v2, c11, c11.zwzw
mad oT2.xy, v3, c8, c8.zwzw
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
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 128
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedfpfdmgadjhodkckoijjblfifijkmecmmabaaaaaakaadaaaaadaaaaaa
cmaaaaaapeaaaaaajiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaaklfdeieefcaaacaaaa
eaaaabaaiaaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
abaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaa
afaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
agaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 128
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefieceddflfcbajinekaeckmlgcpeiphgigeajpabaaaaaaomaeaaaaaeaaaaaa
daaaaaaahiabaaaaiaadaaaaeiaeaaaaebgpgodjeaabaaaaeaabaaaaaaacpopp
aaabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaeaa
aeaaabaaaaaaaaaaabaaaaaaaeaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapja
bpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoekaacaaooka
aeaaaaaeaaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoaadaaoeja
aeaaoekaaeaaookaaeaaaaaeabaaamoaaeaabejaabaabekaabaalekaafaaaaad
aaaaapiaaaaaffjaagaaoekaaeaaaaaeaaaaapiaafaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaahaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaiaaoeka
aaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacacaaapoaafaaoejappppaaaafdeieefcaaacaaaa
eaaaabaaiaaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
abaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaa
afaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
agaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamadaaaajfaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_ProjectionParams]
Vector 10 [unity_SHAr]
Vector 11 [unity_SHAg]
Vector 12 [unity_SHAb]
Vector 13 [unity_SHBr]
Vector 14 [unity_SHBg]
Vector 15 [unity_SHBb]
Vector 16 [unity_SHC]
Vector 17 [unity_Scale]
Vector 18 [_Texture1_ST]
Vector 19 [_Texture2_ST]
Vector 20 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[21] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R0.xyz, vertex.normal, c[17].w;
DP3 R3.w, R0, c[6];
DP3 R2.w, R0, c[7];
DP3 R1.w, R0, c[5];
MOV R1.x, R3.w;
MOV R1.y, R2.w;
MOV R1.z, c[0].x;
MUL R0, R1.wxyy, R1.xyyw;
DP4 R2.z, R1.wxyz, c[12];
DP4 R2.y, R1.wxyz, c[11];
DP4 R2.x, R1.wxyz, c[10];
DP4 R1.z, R0, c[15];
DP4 R1.y, R0, c[14];
DP4 R1.x, R0, c[13];
MUL R3.x, R3.w, R3.w;
MAD R0.x, R1.w, R1.w, -R3;
ADD R3.xyz, R2, R1;
MUL R2.xyz, R0.x, c[16];
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].y;
MUL R1.y, R1, c[9].x;
ADD result.texcoord[3].xyz, R3, R2;
ADD result.texcoord[4].xy, R1, R1.z;
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[4].zw, R0;
MOV result.texcoord[2].z, R2.w;
MOV result.texcoord[2].y, R3.w;
MOV result.texcoord[2].x, R1.w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[19].xyxy, c[19];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[20], c[20].zwzw;
END
# 35 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_SHAr]
Vector 11 [unity_SHAg]
Vector 12 [unity_SHAb]
Vector 13 [unity_SHBr]
Vector 14 [unity_SHBg]
Vector 15 [unity_SHBb]
Vector 16 [unity_SHC]
Vector 17 [unity_Scale]
Vector 18 [_Texture1_ST]
Vector 19 [_Texture2_ST]
Vector 20 [_Texture3_ST]
"vs_2_0
def c21, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r0.xyz, v1, c17.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r1.w, r0, c4
mov r1.x, r3.w
mov r1.y, r2.w
mov r1.z, c21.x
mul r0, r1.wxyy, r1.xyyw
dp4 r2.z, r1.wxyz, c12
dp4 r2.y, r1.wxyz, c11
dp4 r2.x, r1.wxyz, c10
dp4 r1.z, r0, c15
dp4 r1.y, r0, c14
dp4 r1.x, r0, c13
mul r3.x, r3.w, r3.w
mad r0.x, r1.w, r1.w, -r3
add r3.xyz, r2, r1
mul r2.xyz, r0.x, c16
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c21.y
mul r1.y, r1, c8.x
add oT3.xyz, r3, r2
mad oT4.xy, r1.z, c9.zwzw, r1
mov oPos, r0
mov oD0, v3
mov oT4.zw, r0
mov oT2.z, r2.w
mov oT2.y, r3.w
mov oT2.x, r1.w
mad oT0.zw, v2.xyxy, c19.xyxy, c19
mad oT0.xy, v2, c18, c18.zwzw
mad oT1.xy, v2, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedokabjhkihbhdckcjkchccbhlnjgfajclabaaaaaaieagaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcleaeaaaaeaaaabaacnabaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaad
pcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
giaaaaacafaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
dcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaa
kgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaafpccabaaa
adaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaa
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
ccaabaaaabaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaakbcaabaaa
abaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaabkaabaiaebaaaaaaabaaaaaa
dcaaaaakhccabaaaafaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaabaaaaaa
egacbaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaagaaaaaakgaobaaa
aaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedakbajjknckaklnmbklmembmcpmpknacgabaaaaaagiajaaaaaeaaaaaa
daaaaaaabaadaaaammahaaaajeaiaaaaebgpgodjniacaaaaniacaaaaaaacpopp
giacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaaiaa
adaaabaaaaaaaaaaabaaafaaabaaaeaaaaaaaaaaacaacgaaahaaafaaaaaaaaaa
adaaaaaaaeaaamaaaaaaaaaaadaaamaaadaabaaaaaaaaaaaadaabeaaabaabdaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaiadpaaaaaadpaaaaaaaa
aaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoeja
abaaoekaabaaookaaeaaaaaeaaaaamoaadaaeejaacaaeekaacaaoekaaeaaaaae
abaaadoaadaaoejaadaaoekaadaaookaafaaaaadaaaaahiaacaaoejabdaappka
afaaaaadabaaahiaaaaaffiabbaaoekaaeaaaaaeaaaaaliabaaakekaaaaaaaia
abaakeiaaeaaaaaeaaaaahiabcaaoekaaaaakkiaaaaapeiaabaaaaacaaaaaiia
beaaaakaajaaaaadabaaabiaafaaoekaaaaaoeiaajaaaaadabaaaciaagaaoeka
aaaaoeiaajaaaaadabaaaeiaahaaoekaaaaaoeiaafaaaaadacaaapiaaaaacjia
aaaakeiaajaaaaadadaaabiaaiaaoekaacaaoeiaajaaaaadadaaaciaajaaoeka
acaaoeiaajaaaaadadaaaeiaakaaoekaacaaoeiaacaaaaadabaaahiaabaaoeia
adaaoeiaafaaaaadaaaaaiiaaaaaffiaaaaaffiaaeaaaaaeaaaaaiiaaaaaaaia
aaaaaaiaaaaappibabaaaaacadaaahoaaaaaoeiaaeaaaaaeaeaaahoaalaaoeka
aaaappiaabaaoeiaafaaaaadaaaaapiaaaaaffjaanaaoekaaeaaaaaeaaaaapia
amaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaoaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaapaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffia
aeaaaakaafaaaaadabaaaiiaabaaaaiabeaaffkaafaaaaadabaaafiaaaaapeia
beaaffkaacaaaaadafaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacafaaamoaaaaaoeia
abaaaaacacaaapoaafaaoejappppaaaafdeieefcleaeaaaaeaaaabaacnabaaaa
fjaaaaaeegiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaad
pccabaaaagaaaaaagiaaaaacafaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaa
aaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaa
dgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaabaaaaaa
egbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaacaaaaaa
fgafbaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaabaaaaaa
egiicaaaadaaaaaaamaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaabaaaaaaegadbaaa
abaaaaaadgaaaaafhccabaaaaeaaaaaaegacbaaaabaaaaaadgaaaaaficaabaaa
abaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaa
cgaaaaaaegaobaaaabaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaa
chaaaaaaegaobaaaabaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaa
ciaaaaaaegaobaaaabaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaaabaaaaaa
egakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaacjaaaaaa
egaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaackaaaaaa
egaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaaclaaaaaa
egaobaaaadaaaaaaaaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaa
aeaaaaaadiaaaaahccaabaaaabaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaa
dcaaaaakbcaabaaaabaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaabkaabaia
ebaaaaaaabaaaaaadcaaaaakhccabaaaafaaaaaaegiccaaaacaaaaaacmaaaaaa
agaabaaaabaaaaaaegacbaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaa
agaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaa
mgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [_ProjectionParams]
Vector 10 [unity_LightmapST]
Vector 11 [_Texture1_ST]
Vector 12 [_Texture2_ST]
Vector 13 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[14] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[9].x;
ADD result.texcoord[3].xy, R1, R1.z;
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[3].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[12].xyxy, c[12];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[10], c[10].zwzw;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_LightmapST]
Vector 11 [_Texture1_ST]
Vector 12 [_Texture2_ST]
Vector 13 [_Texture3_ST]
"vs_2_0
def c14, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
dcl_color0 v4
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c14.x
mul r1.y, r1, c8.x
mad oT3.xy, r1.z, c9.zwzw, r1
mov oPos, r0
mov oD0, v4
mov oT3.zw, r0
mad oT0.zw, v2.xyxy, c12.xyxy, c12
mad oT0.xy, v2, c11, c11.zwzw
mad oT1.xy, v2, c13, c13.zwzw
mad oT2.xy, v3, c10, c10.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 192
Vector 128 [unity_LightmapST]
Vector 144 [_Texture1_ST]
Vector 160 [_Texture2_ST]
Vector 176 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecednkfegopddclmjceokleekahpeamjjhhcabaaaaaagaaeaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefckiacaaaaeaaaabaakkaaaaaa
fjaaaaaeegiocaaaaaaaaaaaamaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadpccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaa
ogikcaaaaaaaaaaaajaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaakaaaaaakgiocaaaaaaaaaaaakaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaa
alaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaa
aiaaaaaakgiocaaaaaaaaaaaaiaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaa
afaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 192
Vector 128 [unity_LightmapST]
Vector 144 [_Texture1_ST]
Vector 160 [_Texture2_ST]
Vector 176 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedlaipbfclnjpjnbgeplbaekibfcnaocbpabaaaaaabmagaaaaaeaaaaaa
daaaaaaaoiabaaaajiaeaaaagaafaaaaebgpgodjlaabaaaalaabaaaaaaacpopp
geabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaaiaa
aeaaabaaaaaaaaaaabaaafaaabaaafaaaaaaaaaaacaaaaaaaeaaagaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafakaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeia
aeaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoeka
acaaookaaeaaaaaeaaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoa
adaaoejaaeaaoekaaeaaookaaeaaaaaeabaaamoaaeaabejaabaabekaabaaleka
afaaaaadaaaaapiaaaaaffjaahaaoekaaeaaaaaeaaaaapiaagaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
ajaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaafaaaakaafaaaaad
abaaaiiaabaaaaiaakaaaakaafaaaaadabaaafiaaaaapeiaakaaaakaacaaaaad
adaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoa
afaaoejappppaaaafdeieefckiacaaaaeaaaabaakkaaaaaafjaaaaaeegiocaaa
aaaaaaaaamaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
akaaaaaakgiocaaaaaaaaaaaakaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaa
aaaaaaaaaiaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
aeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
kbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaa
ljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [_ProjectionParams]
Vector 10 [unity_LightmapST]
Vector 11 [_Texture1_ST]
Vector 12 [_Texture2_ST]
Vector 13 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[14] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[9].x;
ADD result.texcoord[3].xy, R1, R1.z;
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[3].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[12].xyxy, c[12];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[10], c[10].zwzw;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_LightmapST]
Vector 11 [_Texture1_ST]
Vector 12 [_Texture2_ST]
Vector 13 [_Texture3_ST]
"vs_2_0
def c14, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
dcl_color0 v4
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c14.x
mul r1.y, r1, c8.x
mad oT3.xy, r1.z, c9.zwzw, r1
mov oPos, r0
mov oD0, v4
mov oT3.zw, r0
mad oT0.zw, v2.xyxy, c12.xyxy, c12
mad oT0.xy, v2, c11, c11.zwzw
mad oT1.xy, v2, c13, c13.zwzw
mad oT2.xy, v3, c10, c10.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 192
Vector 128 [unity_LightmapST]
Vector 144 [_Texture1_ST]
Vector 160 [_Texture2_ST]
Vector 176 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecednkfegopddclmjceokleekahpeamjjhhcabaaaaaagaaeaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefckiacaaaaeaaaabaakkaaaaaa
fjaaaaaeegiocaaaaaaaaaaaamaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadpccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaa
ogikcaaaaaaaaaaaajaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaakaaaaaakgiocaaaaaaaaaaaakaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaa
alaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaa
aiaaaaaakgiocaaaaaaaaaaaaiaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaa
afaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 192
Vector 128 [unity_LightmapST]
Vector 144 [_Texture1_ST]
Vector 160 [_Texture2_ST]
Vector 176 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedlaipbfclnjpjnbgeplbaekibfcnaocbpabaaaaaabmagaaaaaeaaaaaa
daaaaaaaoiabaaaajiaeaaaagaafaaaaebgpgodjlaabaaaalaabaaaaaaacpopp
geabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaaiaa
aeaaabaaaaaaaaaaabaaafaaabaaafaaaaaaaaaaacaaaaaaaeaaagaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafakaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeia
aeaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoeka
acaaookaaeaaaaaeaaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoa
adaaoejaaeaaoekaaeaaookaaeaaaaaeabaaamoaaeaabejaabaabekaabaaleka
afaaaaadaaaaapiaaaaaffjaahaaoekaaeaaaaaeaaaaapiaagaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
ajaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaafaaaakaafaaaaad
abaaaiiaabaaaaiaakaaaakaafaaaaadabaaafiaaaaapeiaakaaaakaacaaaaad
adaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoa
afaaoejappppaaaafdeieefckiacaaaaeaaaabaakkaaaaaafjaaaaaeegiocaaa
aaaaaaaaamaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
akaaaaaakgiocaaaaaaaaaaaakaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaa
aaaaaaaaaiaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
aeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
kbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaa
ljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [unity_4LightPosX0]
Vector 10 [unity_4LightPosY0]
Vector 11 [unity_4LightPosZ0]
Vector 12 [unity_4LightAtten0]
Vector 13 [unity_LightColor0]
Vector 14 [unity_LightColor1]
Vector 15 [unity_LightColor2]
Vector 16 [unity_LightColor3]
Vector 17 [unity_SHAr]
Vector 18 [unity_SHAg]
Vector 19 [unity_SHAb]
Vector 20 [unity_SHBr]
Vector 21 [unity_SHBg]
Vector 22 [unity_SHBb]
Vector 23 [unity_SHC]
Vector 24 [unity_Scale]
Vector 25 [_Texture1_ST]
Vector 26 [_Texture2_ST]
Vector 27 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[28] = { { 1, 0 },
		state.matrix.mvp,
		program.local[5..27] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R3.xyz, vertex.normal, c[24].w;
DP3 R4.x, R3, c[5];
DP3 R3.w, R3, c[6];
DP3 R3.x, R3, c[7];
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[10];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[9];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MOV R4.w, c[0].x;
MAD R2, R4.x, R0, R2;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[11];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[12];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
DP4 R2.z, R4, c[19];
DP4 R2.y, R4, c[18];
DP4 R2.x, R4, c[17];
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[14];
MAD R1.xyz, R0.x, c[13], R1;
MAD R0.xyz, R0.z, c[15], R1;
MAD R1.xyz, R0.w, c[16], R0;
MUL R0, R4.xyzz, R4.yzzx;
MUL R1.w, R3, R3;
DP4 R4.w, R0, c[22];
DP4 R4.z, R0, c[21];
DP4 R4.y, R0, c[20];
MAD R1.w, R4.x, R4.x, -R1;
MUL R0.xyz, R1.w, c[23];
ADD R2.xyz, R2, R4.yzww;
ADD R0.xyz, R2, R0;
ADD result.texcoord[3].xyz, R0, R1;
MOV result.color, vertex.color;
MOV result.texcoord[2].z, R3.x;
MOV result.texcoord[2].y, R3.w;
MOV result.texcoord[2].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[26].xyxy, c[26];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[25], c[25].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[27], c[27].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 60 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [unity_4LightPosX0]
Vector 9 [unity_4LightPosY0]
Vector 10 [unity_4LightPosZ0]
Vector 11 [unity_4LightAtten0]
Vector 12 [unity_LightColor0]
Vector 13 [unity_LightColor1]
Vector 14 [unity_LightColor2]
Vector 15 [unity_LightColor3]
Vector 16 [unity_SHAr]
Vector 17 [unity_SHAg]
Vector 18 [unity_SHAb]
Vector 19 [unity_SHBr]
Vector 20 [unity_SHBg]
Vector 21 [unity_SHBb]
Vector 22 [unity_SHC]
Vector 23 [unity_Scale]
Vector 24 [_Texture1_ST]
Vector 25 [_Texture2_ST]
Vector 26 [_Texture3_ST]
"vs_2_0
def c27, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r3.xyz, v1, c23.w
dp3 r4.x, r3, c4
dp3 r3.w, r3, c5
dp3 r3.x, r3, c6
dp4 r0.x, v0, c5
add r1, -r0.x, c9
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c8
mul r1, r1, r1
mov r4.z, r3.x
mov r4.w, c27.x
mad r2, r4.x, r0, r2
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c10
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c11
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c27.x
dp4 r2.z, r4, c18
dp4 r2.y, r4, c17
dp4 r2.x, r4, c16
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c27.y
mul r0, r0, r1
mul r1.xyz, r0.y, c13
mad r1.xyz, r0.x, c12, r1
mad r0.xyz, r0.z, c14, r1
mad r1.xyz, r0.w, c15, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r3, r3
dp4 r4.w, r0, c21
dp4 r4.z, r0, c20
dp4 r4.y, r0, c19
mad r1.w, r4.x, r4.x, -r1
mul r0.xyz, r1.w, c22
add r2.xyz, r2, r4.yzww
add r0.xyz, r2, r0
add oT3.xyz, r0, r1
mov oD0, v3
mov oT2.z, r3.x
mov oT2.y, r3.w
mov oT2.x, r4
mad oT0.zw, v2.xyxy, c25.xyxy, c25
mad oT0.xy, v2, c24, c24.zwzw
mad oT1.xy, v2, c26, c26.zwzw
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
ConstBuffer "$Globals" 112
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedjaomlppdegiadbfeicakdkongkinkajfabaaaaaabeajaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefcfmahaaaaeaaaabaanhabaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaacnaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacagaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaa
afaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
agaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaa
afaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaafhccabaaaaeaaaaaa
egacbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaai
bcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaai
ccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaai
ecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaa
adaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaa
adaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaa
adaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahicaabaaaaaaaaaaa
bkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaa
aaaaaaaaakaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
diaaaaaihcaabaaaacaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaa
egacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaa
acaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaacaaaaaaaaaaaaajpcaabaaa
adaaaaaafgafbaiaebaaaaaaacaaaaaaegiocaaaabaaaaaaadaaaaaadiaaaaah
pcaabaaaaeaaaaaafgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaahpcaabaaa
adaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaaafaaaaaa
agaabaiaebaaaaaaacaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaajpcaabaaa
acaaaaaakgakbaiaebaaaaaaacaaaaaaegiocaaaabaaaaaaaeaaaaaadcaaaaaj
pcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaaaeaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaacaaaaaakgakbaaaaaaaaaaaegaobaaa
aeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaa
egaobaaaadaaaaaadcaaaaajpcaabaaaacaaaaaaegaobaaaacaaaaaaegaobaaa
acaaaaaaegaobaaaadaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaaacaaaaaa
dcaaaaanpcaabaaaacaaaaaaegaobaaaacaaaaaaegiocaaaabaaaaaaafaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaacaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaacaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaakpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaadiaaaaai
hcaabaaaacaaaaaafgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaakgakbaaa
aaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
ajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaaafaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedgngookbkijnpnnhbhddafhkcjmckfejkabaaaaaakeanaaaaaeaaaaaa
daaaaaaalmaeaaaacaamaaaaoiamaaaaebgpgodjieaeaaaaieaeaaaaaaacpopp
beaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaaeaa
adaaabaaaaaaaaaaabaaacaaaiaaaeaaaaaaaaaaabaacgaaahaaamaaaaaaaaaa
acaaaaaaaeaabdaaaaaaaaaaacaaamaaaeaabhaaaaaaaaaaacaabeaaabaablaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafbmaaapkaaaaaiadpaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoeja
abaaoekaabaaookaaeaaaaaeaaaaamoaadaaeejaacaaeekaacaaoekaaeaaaaae
abaaadoaadaaoejaadaaoekaadaaookaafaaaaadaaaaahiaaaaaffjabiaaoeka
aeaaaaaeaaaaahiabhaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiabjaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaahiabkaaoekaaaaappjaaaaaoeiaacaaaaad
abaaapiaaaaaffibafaaoekaafaaaaadacaaapiaabaaoeiaabaaoeiaacaaaaad
adaaapiaaaaaaaibaeaaoekaacaaaaadaaaaapiaaaaakkibagaaoekaaeaaaaae
acaaapiaadaaoeiaadaaoeiaacaaoeiaaeaaaaaeacaaapiaaaaaoeiaaaaaoeia
acaaoeiaahaaaaacaeaaabiaacaaaaiaahaaaaacaeaaaciaacaaffiaahaaaaac
aeaaaeiaacaakkiaahaaaaacaeaaaiiaacaappiaabaaaaacafaaabiabmaaaaka
aeaaaaaeacaaapiaacaaoeiaahaaoekaafaaaaiaafaaaaadafaaahiaacaaoeja
blaappkaafaaaaadagaaahiaafaaffiabiaaoekaaeaaaaaeafaaaliabhaakeka
afaaaaiaagaakeiaaeaaaaaeafaaahiabjaaoekaafaakkiaafaapeiaafaaaaad
abaaapiaabaaoeiaafaaffiaaeaaaaaeabaaapiaadaaoeiaafaaaaiaabaaoeia
aeaaaaaeaaaaapiaaaaaoeiaafaakkiaabaaoeiaafaaaaadaaaaapiaaeaaoeia
aaaaoeiaalaaaaadaaaaapiaaaaaoeiabmaaffkaagaaaaacabaaabiaacaaaaia
agaaaaacabaaaciaacaaffiaagaaaaacabaaaeiaacaakkiaagaaaaacabaaaiia
acaappiaafaaaaadaaaaapiaaaaaoeiaabaaoeiaafaaaaadabaaahiaaaaaffia
ajaaoekaaeaaaaaeabaaahiaaiaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahia
akaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahiaalaaoekaaaaappiaaaaaoeia
abaaaaacafaaaiiabmaaaakaajaaaaadabaaabiaamaaoekaafaaoeiaajaaaaad
abaaaciaanaaoekaafaaoeiaajaaaaadabaaaeiaaoaaoekaafaaoeiaafaaaaad
acaaapiaafaacjiaafaakeiaajaaaaadadaaabiaapaaoekaacaaoeiaajaaaaad
adaaaciabaaaoekaacaaoeiaajaaaaadadaaaeiabbaaoekaacaaoeiaacaaaaad
abaaahiaabaaoeiaadaaoeiaafaaaaadaaaaaiiaafaaffiaafaaffiaaeaaaaae
aaaaaiiaafaaaaiaafaaaaiaaaaappibabaaaaacadaaahoaafaaoeiaaeaaaaae
abaaahiabcaaoekaaaaappiaabaaoeiaacaaaaadaeaaahoaaaaaoeiaabaaoeia
afaaaaadaaaaapiaaaaaffjabeaaoekaaeaaaaaeaaaaapiabdaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiabfaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
bgaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacacaaapoaafaaoejappppaaaafdeieefc
fmahaaaaeaaaabaanhabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaae
egiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacagaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaa
aeaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
afaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaaf
pccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
acaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
dgaaaaafhccabaaaaeaaaaaaegacbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaa
abeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaabaaaaaacgaaaaaa
egaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaabaaaaaachaaaaaa
egaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaabaaaaaaciaaaaaa
egaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaa
aaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaaabaaaaaacjaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaabaaaaaackaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaabaaaaaaclaaaaaaegaobaaa
acaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaa
diaaaaahicaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaak
icaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaiaebaaaaaa
aaaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaabaaaaaacmaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaacaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
acaaaaaaaaaaaaajpcaabaaaadaaaaaafgafbaiaebaaaaaaacaaaaaaegiocaaa
abaaaaaaadaaaaaadiaaaaahpcaabaaaaeaaaaaafgafbaaaaaaaaaaaegaobaaa
adaaaaaadiaaaaahpcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaa
aaaaaaajpcaabaaaafaaaaaaagaabaiaebaaaaaaacaaaaaaegiocaaaabaaaaaa
acaaaaaaaaaaaaajpcaabaaaacaaaaaakgakbaiaebaaaaaaacaaaaaaegiocaaa
abaaaaaaaeaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaafaaaaaaagaabaaa
aaaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaacaaaaaa
kgakbaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaa
afaaaaaaegaobaaaafaaaaaaegaobaaaadaaaaaadcaaaaajpcaabaaaacaaaaaa
egaobaaaacaaaaaaegaobaaaacaaaaaaegaobaaaadaaaaaaeeaaaaafpcaabaaa
adaaaaaaegaobaaaacaaaaaadcaaaaanpcaabaaaacaaaaaaegaobaaaacaaaaaa
egiocaaaabaaaaaaafaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
aoaaaaakpcaabaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
egaobaaaacaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaa
adaaaaaadeaaaaakpcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaacaaaaaa
egaobaaaaaaaaaaadiaaaaaihcaabaaaacaaaaaafgafbaaaaaaaaaaaegiccaaa
abaaaaaaahaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaabaaaaaaagaaaaaa
agaabaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaaaiaaaaaakgakbaaaaaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaabaaaaaaajaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
aaaaaaahhccabaaaafaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaa
knaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_ProjectionParams]
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
Vector 26 [_Texture1_ST]
Vector 27 [_Texture2_ST]
Vector 28 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[29] = { { 1, 0, 0.5 },
		state.matrix.mvp,
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R3.xyz, vertex.normal, c[25].w;
DP3 R4.x, R3, c[5];
DP3 R3.w, R3, c[6];
DP3 R3.x, R3, c[7];
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[11];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[10];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MOV R4.w, c[0].x;
MAD R2, R4.x, R0, R2;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[12];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[13];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
DP4 R2.z, R4, c[20];
DP4 R2.y, R4, c[19];
DP4 R2.x, R4, c[18];
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[15];
MAD R1.xyz, R0.x, c[14], R1;
MAD R0.xyz, R0.z, c[16], R1;
MAD R1.xyz, R0.w, c[17], R0;
MUL R0, R4.xyzz, R4.yzzx;
MUL R1.w, R3, R3;
DP4 R4.w, R0, c[23];
DP4 R4.z, R0, c[22];
DP4 R4.y, R0, c[21];
MAD R1.w, R4.x, R4.x, -R1;
MUL R0.xyz, R1.w, c[24];
ADD R2.xyz, R2, R4.yzww;
ADD R4.yzw, R2.xxyz, R0.xxyz;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R2.xyz, R0.xyww, c[0].z;
ADD result.texcoord[3].xyz, R4.yzww, R1;
MOV R1.x, R2;
MUL R1.y, R2, c[9].x;
ADD result.texcoord[4].xy, R1, R2.z;
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[4].zw, R0;
MOV result.texcoord[2].z, R3.x;
MOV result.texcoord[2].y, R3.w;
MOV result.texcoord[2].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[27].xyxy, c[27];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[26], c[26].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[28], c[28].zwzw;
END
# 66 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
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
Vector 26 [_Texture1_ST]
Vector 27 [_Texture2_ST]
Vector 28 [_Texture3_ST]
"vs_2_0
def c29, 1.00000000, 0.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r3.xyz, v1, c25.w
dp3 r4.x, r3, c4
dp3 r3.w, r3, c5
dp3 r3.x, r3, c6
dp4 r0.x, v0, c5
add r1, -r0.x, c11
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c10
mul r1, r1, r1
mov r4.z, r3.x
mov r4.w, c29.x
mad r2, r4.x, r0, r2
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c12
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c13
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c29.x
dp4 r2.z, r4, c20
dp4 r2.y, r4, c19
dp4 r2.x, r4, c18
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c29.y
mul r0, r0, r1
mul r1.xyz, r0.y, c15
mad r1.xyz, r0.x, c14, r1
mad r0.xyz, r0.z, c16, r1
mad r1.xyz, r0.w, c17, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r3, r3
dp4 r4.w, r0, c23
dp4 r4.z, r0, c22
dp4 r4.y, r0, c21
mad r1.w, r4.x, r4.x, -r1
mul r0.xyz, r1.w, c24
add r2.xyz, r2, r4.yzww
add r4.yzw, r2.xxyz, r0.xxyz
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r2.xyz, r0.xyww, c29.z
add oT3.xyz, r4.yzww, r1
mov r1.x, r2
mul r1.y, r2, c8.x
mad oT4.xy, r2.z, c9.zwzw, r1
mov oPos, r0
mov oD0, v3
mov oT4.zw, r0
mov oT2.z, r3.x
mov oT2.y, r3.w
mov oT2.x, r4
mad oT0.zw, v2.xyxy, c27.xyxy, c27
mad oT0.xy, v2, c26, c26.zwzw
mad oT1.xy, v2, c28, c28.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
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
eefiecedgnjmbfekjieimolehaaogeopdakabccbabaaaaaaneajaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcaeaiaaaaeaaaabaaabacaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaad
pcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaa
giaaaaacahaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaa
dcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaa
kgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaafpccabaaa
adaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaa
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
icaabaaaabaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaakicaabaaa
abaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaa
dcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaabaaaaaa
egacbaaaacaaaaaadiaaaaaihcaabaaaadaaaaaafgbfbaaaaaaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaadaaaaaaamaaaaaa
agbabaaaaaaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaa
adaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaa
adaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaadaaaaaa
aaaaaaajpcaabaaaaeaaaaaafgafbaiaebaaaaaaadaaaaaaegiocaaaacaaaaaa
adaaaaaadiaaaaahpcaabaaaafaaaaaafgafbaaaabaaaaaaegaobaaaaeaaaaaa
diaaaaahpcaabaaaaeaaaaaaegaobaaaaeaaaaaaegaobaaaaeaaaaaaaaaaaaaj
pcaabaaaagaaaaaaagaabaiaebaaaaaaadaaaaaaegiocaaaacaaaaaaacaaaaaa
aaaaaaajpcaabaaaadaaaaaakgakbaiaebaaaaaaadaaaaaaegiocaaaacaaaaaa
aeaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaaagaaaaaaagaabaaaabaaaaaa
egaobaaaafaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaadaaaaaakgakbaaa
abaaaaaaegaobaaaafaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaagaaaaaa
egaobaaaagaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaa
adaaaaaaegaobaaaadaaaaaaegaobaaaaeaaaaaaeeaaaaafpcaabaaaaeaaaaaa
egaobaaaadaaaaaadcaaaaanpcaabaaaadaaaaaaegaobaaaadaaaaaaegiocaaa
acaaaaaaafaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaak
pcaabaaaadaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaa
adaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaaeaaaaaa
deaaaaakpcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaadaaaaaaegaobaaa
abaaaaaadiaaaaaihcaabaaaadaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaa
ahaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaa
abaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
aiaaaaaakgakbaaaabaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaacaaaaaaajaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaaaaaaaah
hccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaaiccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaa
abaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadp
dgaaaaafmccabaaaagaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaagaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
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
eefiecedopmcjombpedcgeoihmgbcmimicjkcoeeabaaaaaalmaoaaaaaeaaaaaa
daaaaaaabeafaaaacaanaaaaoianaaaaebgpgodjnmaeaaaanmaeaaaaaaacpopp
gaaeaaaahmaaaaaaahaaceaaaaaahiaaaaaahiaaaaaaceaaabaahiaaaaaaaiaa
adaaabaaaaaaaaaaabaaafaaabaaaeaaaaaaaaaaacaaacaaaiaaafaaaaaaaaaa
acaacgaaahaaanaaaaaaaaaaadaaaaaaaeaabeaaaaaaaaaaadaaamaaaeaabiaa
aaaaaaaaadaabeaaabaabmaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafbnaaapka
aaaaiadpaaaaaaaaaaaaaadpaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaac
afaaaciaacaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaafiaafaaapja
aeaaaaaeaaaaadoaadaaoejaabaaoekaabaaookaaeaaaaaeaaaaamoaadaaeeja
acaaeekaacaaoekaaeaaaaaeabaaadoaadaaoejaadaaoekaadaaookaafaaaaad
aaaaahiaaaaaffjabjaaoekaaeaaaaaeaaaaahiabiaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaahiabkaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiablaaoeka
aaaappjaaaaaoeiaacaaaaadabaaapiaaaaaffibagaaoekaafaaaaadacaaapia
abaaoeiaabaaoeiaacaaaaadadaaapiaaaaaaaibafaaoekaacaaaaadaaaaapia
aaaakkibahaaoekaaeaaaaaeacaaapiaadaaoeiaadaaoeiaacaaoeiaaeaaaaae
acaaapiaaaaaoeiaaaaaoeiaacaaoeiaahaaaaacaeaaabiaacaaaaiaahaaaaac
aeaaaciaacaaffiaahaaaaacaeaaaeiaacaakkiaahaaaaacaeaaaiiaacaappia
abaaaaacafaaabiabnaaaakaaeaaaaaeacaaapiaacaaoeiaaiaaoekaafaaaaia
afaaaaadafaaahiaacaaoejabmaappkaafaaaaadagaaahiaafaaffiabjaaoeka
aeaaaaaeafaaaliabiaakekaafaaaaiaagaakeiaaeaaaaaeafaaahiabkaaoeka
afaakkiaafaapeiaafaaaaadabaaapiaabaaoeiaafaaffiaaeaaaaaeabaaapia
adaaoeiaafaaaaiaabaaoeiaaeaaaaaeaaaaapiaaaaaoeiaafaakkiaabaaoeia
afaaaaadaaaaapiaaeaaoeiaaaaaoeiaalaaaaadaaaaapiaaaaaoeiabnaaffka
agaaaaacabaaabiaacaaaaiaagaaaaacabaaaciaacaaffiaagaaaaacabaaaeia
acaakkiaagaaaaacabaaaiiaacaappiaafaaaaadaaaaapiaaaaaoeiaabaaoeia
afaaaaadabaaahiaaaaaffiaakaaoekaaeaaaaaeabaaahiaajaaoekaaaaaaaia
abaaoeiaaeaaaaaeaaaaahiaalaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahia
amaaoekaaaaappiaaaaaoeiaabaaaaacafaaaiiabnaaaakaajaaaaadabaaabia
anaaoekaafaaoeiaajaaaaadabaaaciaaoaaoekaafaaoeiaajaaaaadabaaaeia
apaaoekaafaaoeiaafaaaaadacaaapiaafaacjiaafaakeiaajaaaaadadaaabia
baaaoekaacaaoeiaajaaaaadadaaaciabbaaoekaacaaoeiaajaaaaadadaaaeia
bcaaoekaacaaoeiaacaaaaadabaaahiaabaaoeiaadaaoeiaafaaaaadaaaaaiia
afaaffiaafaaffiaaeaaaaaeaaaaaiiaafaaaaiaafaaaaiaaaaappibabaaaaac
adaaahoaafaaoeiaaeaaaaaeabaaahiabdaaoekaaaaappiaabaaoeiaacaaaaad
aeaaahoaaaaaoeiaabaaoeiaafaaaaadaaaaapiaaaaaffjabfaaoekaaeaaaaae
aaaaapiabeaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiabgaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiabhaaoekaaaaappjaaaaaoeiaafaaaaadabaaabia
aaaaffiaaeaaaakaafaaaaadabaaaiiaabaaaaiabnaakkkaafaaaaadabaaafia
aaaapeiabnaakkkaacaaaaadafaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadma
aaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacafaaamoa
aaaaoeiaabaaaaacacaaapoaafaaoejappppaaaafdeieefcaeaiaaaaeaaaabaa
abacaaaafjaaaaaeegiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaa
agaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaad
pccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaa
gfaaaaadpccabaaaagaaaaaagiaaaaacahaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaa
ogikcaaaaaaaaaaaaiaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaa
akaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaa
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
egacbaaaaeaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaabaaaaaabkaabaaa
abaaaaaadcaaaaakicaabaaaabaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaa
dkaabaiaebaaaaaaabaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaa
cmaaaaaapgapbaaaabaaaaaaegacbaaaacaaaaaadiaaaaaihcaabaaaadaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaadaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaadaaaaaadcaaaaak
hcaabaaaadaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
adaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaadaaaaaaaaaaaaajpcaabaaaaeaaaaaafgafbaiaebaaaaaa
adaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaahpcaabaaaafaaaaaafgafbaaa
abaaaaaaegaobaaaaeaaaaaadiaaaaahpcaabaaaaeaaaaaaegaobaaaaeaaaaaa
egaobaaaaeaaaaaaaaaaaaajpcaabaaaagaaaaaaagaabaiaebaaaaaaadaaaaaa
egiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaaadaaaaaakgakbaiaebaaaaaa
adaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaa
agaaaaaaagaabaaaabaaaaaaegaobaaaafaaaaaadcaaaaajpcaabaaaabaaaaaa
egaobaaaadaaaaaakgakbaaaabaaaaaaegaobaaaafaaaaaadcaaaaajpcaabaaa
aeaaaaaaegaobaaaagaaaaaaegaobaaaagaaaaaaegaobaaaaeaaaaaadcaaaaaj
pcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaegaobaaaaeaaaaaa
eeaaaaafpcaabaaaaeaaaaaaegaobaaaadaaaaaadcaaaaanpcaabaaaadaaaaaa
egaobaaaadaaaaaaegiocaaaacaaaaaaafaaaaaaaceaaaaaaaaaiadpaaaaiadp
aaaaiadpaaaaiadpaoaaaaakpcaabaaaadaaaaaaaceaaaaaaaaaiadpaaaaiadp
aaaaiadpaaaaiadpegaobaaaadaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaa
abaaaaaaegaobaaaaeaaaaaadeaaaaakpcaabaaaabaaaaaaegaobaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaaabaaaaaa
egaobaaaadaaaaaaegaobaaaabaaaaaadiaaaaaihcaabaaaadaaaaaafgafbaaa
abaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaa
acaaaaaaagaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaaabaaaaaaegacbaaaadaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaajaaaaaapgapbaaaabaaaaaa
egacbaaaabaaaaaaaaaaaaahhccabaaaafaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaagaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaagaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaa
mfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
"!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R3.x, fragment.color.primary, fragment.color.primary.y;
ADD R3.x, R3, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R3.x;
MUL R1, R0, R2.x;
ABS R2.x, R3;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[2];
MAD R1, R3.x, R0, c[2];
MUL R0.xyz, R1, fragment.texcoord[3];
DP3 R0.w, fragment.texcoord[2], c[0];
MUL R1.xyz, R1, c[1];
MAX R0.w, R0, c[3].x;
MUL R1.xyz, R0.w, R1;
MAD result.color.xyz, R1, c[3].y, R0;
MOV result.color.w, R1;
END
# 21 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 0.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r3, v0.y, r0
mad r3, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r2, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r2, r3
add_pp r1, r1, -c2
mad_pp r1, r0.x, r1, c2
mul_pp r2.xyz, r1, t3
dp3_pp r0.x, t2, c0
mov_pp r0.w, r1
mul_pp r1.xyz, r1, c1
max_pp r0.x, r0, c3
mul_pp r0.xyz, r0.x, r1
mad_pp r0.xyz, r0, c3.y, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
ConstBuffer "$Globals" 112
Vector 16 [_LightColor0]
Vector 48 [_Color]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedbohhjlhdhminomnhbnfnnejjgmjgoifmabaaaaaahaaeaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
emadaaaaeaaaaaaandaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaae
egiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaa
abaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaa
egaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaaegaobaaaaaaaaaaa
aaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaah
bcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaaaoaaaaahpcaabaaa
acaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaahccaabaaaabaaaaaa
akaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaaaaaaaaaafgafbaaa
abaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaajpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaadcaaaaakpcaabaaa
aaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaa
diaaaaaihcaabaaaabaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegbcbaaaafaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaaaaaaaaabaaaaaaiicaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegiccaaaabaaaaaaaaaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
dkaabaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
ConstBuffer "$Globals" 112
Vector 16 [_LightColor0]
Vector 48 [_Color]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0_level_9_1
eefiecedhnbmjmjlhmhdaobpbgibihifbedicjmgabaaaaaaleagaaaaaeaaaaaa
daaaaaaahaacaaaameafaaaaiaagaaaaebgpgodjdiacaaaadiacaaaaaaacpppp
oeabaaaafeaaaaaaadaadaaaaaaafeaaaaaafeaaadaaceaaaaaafeaaaaaaaaaa
abababaaacacacaaaaaaabaaabaaaaaaaaaaaaaaaaaaadaaabaaabaaaaaaaaaa
abaaaaaaabaaacaaaaaaaaaaaaacppppfbaaaaafadaaapkaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaiaabaacdla
bpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaaia
aeaachlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkaabaaaaacaaaacbiaaaaakklaabaaaaacaaaacciaaaaappla
ecaaaaadaaaacpiaaaaaoeiaabaioekaecaaaaadabaacpiaaaaaoelaaaaioeka
ecaaaaadacaacpiaabaaoelaacaioekaafaaaaadaaaaapiaaaaaoeiaacaaffla
aeaaaaaeaaaaapiaabaaoeiaacaaaalaaaaaoeiaaeaaaaaeaaaacpiaacaaoeia
acaakklaaaaaoeiaacaaaaadabaaabiaacaafflaacaaaalaacaaaaadabaacbia
abaaaaiaacaakklaagaaaaacabaaaciaabaaaaiaafaaaaadacaacpiaaaaaoeia
abaaffiaafaaaaadabaaaciaabaaaaiaabaaaaiafiaaaaaeaaaacpiaabaaffib
aaaaoeiaacaaoeiabcaaaaaeacaacpiaabaaaaiaaaaaoeiaabaaoekaafaaaaad
aaaachiaacaaoeiaaaaaoekaafaaaaadabaachiaacaaoeiaaeaaoelaaiaaaaad
aaaaciiaadaaoelaacaaoekaalaaaaadabaaciiaaaaappiaadaaaakaacaaaaad
aaaaciiaabaappiaabaappiaaeaaaaaeacaachiaaaaaoeiaaaaappiaabaaoeia
abaaaaacaaaicpiaacaaoeiappppaaaafdeieefcemadaaaaeaaaaaaandaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaa
adaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
adaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgbkbaaaadaaaaaaegaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaa
bkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaa
abaaaaaackbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaa
agaabaaaabaaaaaadjaaaaahccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaa
aaaaaaaadhaaaaajpcaabaaaaaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaa
egaobaaaaaaaaaaaaaaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaia
ebaaaaaaaaaaaaaaadaaaaaadcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaadiaaaaaihcaabaaaabaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegbcbaaaafaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
aaaaaaaabaaaaaaiicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegiccaaaabaaaaaa
aaaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaaj
hccabaaaaaaaaaaaegacbaaaabaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
doaaaaabejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaaknaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R3, fragment.texcoord[2], texture[3], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R4.x, fragment.color.primary, fragment.color.primary.y;
ADD R4.x, R4, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R4.x;
MUL R1, R0, R2.x;
ABS R2.x, R4;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R4.x, R0, c[0];
MUL R1.xyz, R3.w, R3;
MUL R0.xyz, R0, R1;
MOV result.color.w, R0;
MUL result.color.xyz, R0, c[1].x;
END
# 19 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c1, 8.00000000, 0, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xy
texld r2, t2, s3
texld r3, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
mul_pp r2.xyz, r2.w, r2
texld r0, r0, s1
mul r4, v0.y, r0
mad r4, v0.x, r1, r4
add r0.x, v0, v0.y
add r0.x, r0, v0.z
rcp_pp r1.x, r0.x
mad r3, v0.z, r3, r4
mul_pp r4, r3, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r3, r4
add_pp r1, r1, -c0
mad_pp r0, r0.x, r1, c0
mul_pp r0.xyz, r0, r2
mul_pp r0.xyz, r0, c1.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedioippinfkkmfinhebhkpbhfbgndckiafabaaaaaabiaeaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefcamadaaaaeaaaaaaamdaaaaaafjaaaaaeegiocaaaaaaaaaaa
aeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaad
aagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaa
egaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaa
adaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaa
aoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaah
ccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaa
aaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaaj
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaa
dcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
aaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaa
abaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecednnnpcedjajghbgkackhpnkglhcdofbdiabaaaaaaceagaaaaaeaaaaaa
daaaaaaadiacaaaaemafaaaapaafaaaaebgpgodjaaacaaaaaaacaaaaaaacpppp
maabaaaaeaaaaaaaabaadeaaaaaaeaaaaaaaeaaaaeaaceaaaaaaeaaaaaaaaaaa
abababaaacacacaaadadadaaaaaaadaaabaaaaaaaaaaaaaaaaacppppfbaaaaaf
abaaapkaaaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacpla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkabpaaaaac
aaaaaajaadaiapkaabaaaaacaaaacbiaaaaakklaabaaaaacaaaacciaaaaappla
abaaaaacabaaadiaabaabllaecaaaaadaaaacpiaaaaaoeiaabaioekaecaaaaad
acaacpiaaaaaoelaaaaioekaecaaaaadadaacpiaabaaoelaacaioekaecaaaaad
abaacpiaabaaoeiaadaioekaafaaaaadaaaaapiaaaaaoeiaacaafflaaeaaaaae
aaaaapiaacaaoeiaacaaaalaaaaaoeiaaeaaaaaeaaaacpiaadaaoeiaacaakkla
aaaaoeiaacaaaaadacaaabiaacaafflaacaaaalaacaaaaadacaacbiaacaaaaia
acaakklaagaaaaacacaaaciaacaaaaiaafaaaaadadaacpiaaaaaoeiaacaaffia
afaaaaadacaaaciaacaaaaiaacaaaaiafiaaaaaeaaaacpiaacaaffibaaaaoeia
adaaoeiabcaaaaaeadaacpiaacaaaaiaaaaaoeiaaaaaoekaafaaaaadabaaciia
abaappiaabaaaakaafaaaaadaaaachiaabaaoeiaabaappiaafaaaaadadaachia
aaaaoeiaadaaoeiaabaaaaacaaaicpiaadaaoeiappppaaaafdeieefcamadaaaa
eaaaaaaamdaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaaegaobaaaaaaaaaaaaaaaaaah
bcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaahbcaabaaa
abaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaa
egaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaahccaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaaaaaaaaaafgafbaaaabaaaaaa
egaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaajpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaadcaaaaakpcaabaaaaaaaaaaa
agaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaa
diaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaabaaaaaadiaaaaahhccabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaaaaaaaaadoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R3, fragment.texcoord[2], texture[3], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R4.x, fragment.color.primary, fragment.color.primary.y;
ADD R4.x, R4, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R4.x;
MUL R1, R0, R2.x;
ABS R2.x, R4;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R4.x, R0, c[0];
MUL R1.xyz, R3.w, R3;
MUL R0.xyz, R0, R1;
MOV result.color.w, R0;
MUL result.color.xyz, R0, c[1].x;
END
# 19 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c1, 8.00000000, 0, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xy
texld r2, t2, s3
texld r3, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
mul_pp r2.xyz, r2.w, r2
texld r0, r0, s1
mul r4, v0.y, r0
mad r4, v0.x, r1, r4
add r0.x, v0, v0.y
add r0.x, r0, v0.z
rcp_pp r1.x, r0.x
mad r3, v0.z, r3, r4
mul_pp r4, r3, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r3, r4
add_pp r1, r1, -c0
mad_pp r0, r0.x, r1, c0
mul_pp r0.xyz, r0, r2
mul_pp r0.xyz, r0, c1.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedioippinfkkmfinhebhkpbhfbgndckiafabaaaaaabiaeaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefcamadaaaaeaaaaaaamdaaaaaafjaaaaaeegiocaaaaaaaaaaa
aeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaad
aagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaa
egaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaa
adaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaa
aoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaah
ccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaa
aaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaaj
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaa
dcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
aaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaa
abaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [unity_Lightmap] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecednnnpcedjajghbgkackhpnkglhcdofbdiabaaaaaaceagaaaaaeaaaaaa
daaaaaaadiacaaaaemafaaaapaafaaaaebgpgodjaaacaaaaaaacaaaaaaacpppp
maabaaaaeaaaaaaaabaadeaaaaaaeaaaaaaaeaaaaeaaceaaaaaaeaaaaaaaaaaa
abababaaacacacaaadadadaaaaaaadaaabaaaaaaaaaaaaaaaaacppppfbaaaaaf
abaaapkaaaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacpla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkabpaaaaac
aaaaaajaadaiapkaabaaaaacaaaacbiaaaaakklaabaaaaacaaaacciaaaaappla
abaaaaacabaaadiaabaabllaecaaaaadaaaacpiaaaaaoeiaabaioekaecaaaaad
acaacpiaaaaaoelaaaaioekaecaaaaadadaacpiaabaaoelaacaioekaecaaaaad
abaacpiaabaaoeiaadaioekaafaaaaadaaaaapiaaaaaoeiaacaafflaaeaaaaae
aaaaapiaacaaoeiaacaaaalaaaaaoeiaaeaaaaaeaaaacpiaadaaoeiaacaakkla
aaaaoeiaacaaaaadacaaabiaacaafflaacaaaalaacaaaaadacaacbiaacaaaaia
acaakklaagaaaaacacaaaciaacaaaaiaafaaaaadadaacpiaaaaaoeiaacaaffia
afaaaaadacaaaciaacaaaaiaacaaaaiafiaaaaaeaaaacpiaacaaffibaaaaoeia
adaaoeiabcaaaaaeadaacpiaacaaaaiaaaaaoeiaaaaaoekaafaaaaadabaaciia
abaappiaabaaaakaafaaaaadaaaachiaabaaoeiaabaappiaafaaaaadadaachia
aaaaoeiaadaaoeiaabaaaaacaaaicpiaadaaoeiappppaaaafdeieefcamadaaaa
eaaaaaaamdaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaaegaobaaaaaaaaaaaaaaaaaah
bcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaahbcaabaaa
abaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaa
egaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaahccaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaaaaaaaaaafgafbaaaabaaaaaa
egaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaajpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaadcaaaaakpcaabaaaaaaaaaaa
agaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaa
diaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaabaaaaaadiaaaaahhccabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaaaaaaaaadoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"!!ARBfp1.0
PARAM c[4] = { program.local[0..2],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TXP R3.x, fragment.texcoord[4], texture[3], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R3.y, fragment.color.primary.x, fragment.color.primary;
ADD R3.y, R3, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R3.y;
MUL R1, R0, R2.x;
ABS R2.x, R3.y;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[2];
MAD R0, R3.y, R0, c[2];
MUL R1.xyz, R0, fragment.texcoord[3];
DP3 R1.w, fragment.texcoord[2], c[0];
MAX R1.w, R1, c[3].x;
MUL R0.xyz, R0, c[1];
MUL R1.w, R1, R3.x;
MUL R0.xyz, R1.w, R0;
MAD result.color.xyz, R0, c[3].y, R1;
MOV result.color.w, R0;
END
# 23 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c3, 0.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
texldp r4, t4, s3
texld r2, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r3, v0.y, r0
mad r3, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r2, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r2, r3
add_pp r1, r1, -c2
mad_pp r0, r0.x, r1, c2
mul_pp r2.xyz, r0, t3
mul_pp r1.xyz, r0, c1
dp3_pp r0.x, t2, c0
max_pp r0.x, r0, c3
mul_pp r0.x, r0, r4
mul_pp r0.xyz, r0.x, r1
mad_pp r0.xyz, r0, c3.y, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefieceddpbkfdjcljklpnogokcglfkoppfcdbomabaaaaaapaaeaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcleadaaaaeaaaaaaa
onaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaa
abaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaad
aagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadlcbabaaaagaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaa
agaaaaaapgbpbaaaagaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaa
eghobaaaadaaaaaaaagabaaaaaaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegiccaaaabaaaaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaaaaaaaaaaapaaaaahbcaabaaaaaaaaaaafgafbaaaaaaaaaaa
agaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaacaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaa
fgbfbaaaadaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaa
agbabaaaadaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaa
acaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaadcaaaaajpcaabaaaabaaaaaa
egaobaaaacaaaaaakgbkbaaaadaaaaaaegaobaaaabaaaaaaaaaaaaahccaabaaa
aaaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaackbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaa
abaaaaaafgafbaaaaaaaaaaadjaaaaahecaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaaaaaaaaaadhaaaaajpcaabaaaabaaaaaakgakbaaaaaaaaaaaegaobaaa
acaaaaaaegaobaaaabaaaaaaaaaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaa
egiocaiaebaaaaaaaaaaaaaaahaaaaaadcaaaaakpcaabaaaabaaaaaafgafbaaa
aaaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaadiaaaaaiocaabaaa
aaaaaaaaagajbaaaabaaaaaaagijcaaaaaaaaaaaabaaaaaadiaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaaegbcbaaaafaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaabaaaaaadcaaaaajhccabaaaaaaaaaaajgahbaaaaaaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0_level_9_1
eefiecedjbhjjabcabjlehlghgcegdbmnebepflpabaaaaaajaahaaaaaeaaaaaa
daaaaaaammacaaaaiiagaaaafmahaaaaebgpgodjjeacaaaajeacaaaaaaacpppp
dmacaaaafiaaaaaaadaadeaaaaaafiaaaaaafiaaaeaaceaaaaaafiaaadaaaaaa
aaababaaabacacaaacadadaaaaaaabaaabaaaaaaaaaaaaaaaaaaahaaabaaabaa
aaaaaaaaabaaaaaaabaaacaaaaaaaaaaaaacppppfbaaaaafadaaapkaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaia
abaacdlabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaachlabpaaaaac
aaaaaaiaaeaachlabpaaaaacaaaaaaiaafaaaplabpaaaaacaaaaaajaaaaiapka
bpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaaja
adaiapkaagaaaaacaaaaaiiaafaapplaafaaaaadaaaaadiaaaaappiaafaaoela
abaaaaacabaacbiaaaaakklaabaaaaacabaacciaaaaapplaecaaaaadaaaacpia
aaaaoeiaaaaioekaecaaaaadabaacpiaabaaoeiaacaioekaecaaaaadacaacpia
aaaaoelaabaioekaecaaaaadadaacpiaabaaoelaadaioekaaiaaaaadaaaaccia
adaaoelaacaaoekaafaaaaadaaaacbiaaaaaaaiaaaaaffiafiaaaaaeaaaacbia
aaaaffiaaaaaaaiaadaaaakaacaaaaadaaaacbiaaaaaaaiaaaaaaaiaafaaaaad
abaaapiaabaaoeiaacaafflaaeaaaaaeabaaapiaacaaoeiaacaaaalaabaaoeia
aeaaaaaeabaacpiaadaaoeiaacaakklaabaaoeiaacaaaaadaaaaaciaacaaffla
acaaaalaacaaaaadaaaacciaaaaaffiaacaakklaagaaaaacaaaaaeiaaaaaffia
afaaaaadacaacpiaaaaakkiaabaaoeiaafaaaaadaaaaaeiaaaaaffiaaaaaffia
fiaaaaaeabaacpiaaaaakkibabaaoeiaacaaoeiabcaaaaaeacaacpiaaaaaffia
abaaoeiaabaaoekaafaaaaadaaaacoiaacaabliaaaaablkaafaaaaadabaachia
acaaoeiaaeaaoelaaeaaaaaeacaachiaaaaabliaaaaaaaiaabaaoeiaabaaaaac
aaaicpiaacaaoeiappppaaaafdeieefcleadaaaaeaaaaaaaonaaaaaafjaaaaae
egiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagcbaaaadlcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaagaaaaaapgbpbaaa
agaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaadaaaaaa
aagabaaaaaaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaaeaaaaaaegiccaaa
abaaaaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
aaaaaaaaapaaaaahbcaabaaaaaaaaaaafgafbaaaaaaaaaaaagaabaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaa
egaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaadaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaa
kgbkbaaaadaaaaaaegaobaaaabaaaaaaaaaaaaahccaabaaaaaaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
ckbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaabaaaaaafgafbaaa
aaaaaaaadjaaaaahecaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dhaaaaajpcaabaaaabaaaaaakgakbaaaaaaaaaaaegaobaaaacaaaaaaegaobaaa
abaaaaaaaaaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaa
aaaaaaaaahaaaaaadcaaaaakpcaabaaaabaaaaaafgafbaaaaaaaaaaaegaobaaa
abaaaaaaegiocaaaaaaaaaaaahaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaa
abaaaaaaagijcaaaaaaaaaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegbcbaaaafaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
dcaaaaajhccabaaaaaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
mfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaaapalaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaaklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R3, fragment.texcoord[2], texture[4], 2D;
TXP R4.x, fragment.texcoord[3], texture[3], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R4.y, fragment.color.primary.x, fragment.color.primary;
ADD R4.y, R4, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R4.y;
MUL R1, R0, R2.x;
ABS R2.x, R4.y;
CMP R0, -R2.x, R1, R0;
MUL R1.xyz, R3.w, R3;
MUL R2.xyz, R3, R4.x;
MUL R1.xyz, R1, c[1].x;
ADD R0, R0, -c[0];
MAD R0, R4.y, R0, c[0];
MUL R3.xyz, R1, R4.x;
MUL R2.xyz, R2, c[1].y;
MIN R1.xyz, R1, R2;
MAX R1.xyz, R1, R3;
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 25 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c1, 8.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xy
dcl t3
texldp r5, t3, s3
texld r2, t2, s4
texld r3, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r4, v0.y, r0
mad r4, v0.x, r1, r4
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r3, v0.z, r3, r4
rcp_pp r1.x, r0.x
mul_pp r4, r3, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r3, r4
mul_pp r3.xyz, r2.w, r2
mul_pp r3.xyz, r3, c1.x
add_pp r1, r1, -c0
mul_pp r2.xyz, r2, r5.x
mul_pp r2.xyz, r2, c1.y
mad_pp r0, r0.x, r1, c0
mul_pp r4.xyz, r3, r5.x
min_pp r2.xyz, r3, r2
max_pp r2.xyz, r2, r4
mul_pp r0.xyz, r0, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 192
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedbahjfhbbfddooaallmegfflfbfdclllkabaaaaaaceafaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaknaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
aaaeaaaaeaaaaaaaaaabaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaa
aeaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaoaaaaahdcaabaaa
aaaaaaaaegbabaaaaeaaaaaapgbpbaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaaaaaaaaahccaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagajbaaaabaaaaaadiaaaaahicaabaaaabaaaaaa
dkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaabaaaaaaddaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaa
agajbaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadeaaaaahhcaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaa
egaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaadaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaa
kgbkbaaaadaaaaaaegaobaaaabaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
ckbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaabaaaaaapgapbaaa
aaaaaaaadjaaaaahbcaabaaaadaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dhaaaaajpcaabaaaabaaaaaaagaabaaaadaaaaaaegaobaaaacaaaaaaegaobaaa
abaaaaaaaaaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaa
aaaaaaaaahaaaaaadcaaaaakpcaabaaaabaaaaaapgapbaaaaaaaaaaaegaobaaa
abaaaaaaegiocaaaaaaaaaaaahaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 192
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedeebffmopdlmobmdkgdkmkdeccbiefmgdabaaaaaamiahaaaaaeaaaaaa
daaaaaaanaacaaaaniagaaaajeahaaaaebgpgodjjiacaaaajiacaaaaaaacpppp
feacaaaaeeaaaaaaabaadiaaaaaaeeaaaaaaeeaaafaaceaaaaaaeeaaadaaaaaa
aaababaaabacacaaacadadaaaeaeaeaaaaaaahaaabaaaaaaaaaaaaaaaaacpppp
fbaaaaafabaaapkaaaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaacplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaac
aaaaaaiaadaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapka
bpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaacaaaaaaja
aeaiapkaagaaaaacaaaaaiiaadaapplaafaaaaadaaaaadiaaaaappiaadaaoela
abaaaaacabaaadiaabaabllaabaaaaacacaacbiaaaaakklaabaaaaacacaaccia
aaaapplaecaaaaadaaaacpiaaaaaoeiaaaaioekaecaaaaadabaacpiaabaaoeia
aeaioekaecaaaaadacaacpiaacaaoeiaacaioekaecaaaaadadaacpiaaaaaoela
abaioekaecaaaaadaeaacpiaabaaoelaadaioekaacaaaaadaaaacciaaaaaaaia
aaaaaaiaafaaaaadaaaacoiaabaabliaaaaaffiaafaaaaadabaaciiaabaappia
abaaaakaafaaaaadabaachiaabaaoeiaabaappiaakaaaaadafaachiaaaaablia
abaaoeiaafaaaaadaaaachiaaaaaaaiaabaaoeiaalaaaaadabaachiaafaaoeia
aaaaoeiaafaaaaadaaaaapiaacaaoeiaacaafflaaeaaaaaeaaaaapiaadaaoeia
acaaaalaaaaaoeiaaeaaaaaeaaaacpiaaeaaoeiaacaakklaaaaaoeiaacaaaaad
abaaaiiaacaafflaacaaaalaacaaaaadabaaciiaabaappiaacaakklaagaaaaac
acaaabiaabaappiaafaaaaadacaacpiaaaaaoeiaacaaaaiaafaaaaadadaaabia
abaappiaabaappiafiaaaaaeaaaacpiaadaaaaibaaaaoeiaacaaoeiabcaaaaae
acaacpiaabaappiaaaaaoeiaaaaaoekaafaaaaadacaachiaabaaoeiaacaaoeia
abaaaaacaaaicpiaacaaoeiappppaaaafdeieefcaaaeaaaaeaaaaaaaaaabaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaa
fkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaad
pcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaeaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
adaaaaaaaagabaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaa
aeaaaaaaaagabaaaaeaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agajbaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaabaaaaaa
ddaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagajbaaaabaaaaaadiaaaaah
hcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahhcaabaaa
aaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaacaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaajpcaabaaa
abaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaaegaobaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaakgbkbaaaadaaaaaaegaobaaa
abaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaaaoaaaaah
pcaabaaaacaaaaaaegaobaaaabaaaaaapgapbaaaaaaaaaaadjaaaaahbcaabaaa
adaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaaabaaaaaa
agaabaaaadaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaaaaaaaaajpcaabaaa
abaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaaaaaaaaaaahaaaaaadcaaaaak
pcaabaaaabaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaa
ahaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaabejfdeheoleaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
acaaaaaaamamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R3, fragment.texcoord[2], texture[4], 2D;
TXP R4.x, fragment.texcoord[3], texture[3], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R4.y, fragment.color.primary.x, fragment.color.primary;
ADD R4.y, R4, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R4.y;
MUL R1, R0, R2.x;
ABS R2.x, R4.y;
CMP R0, -R2.x, R1, R0;
MUL R1.xyz, R3.w, R3;
MUL R2.xyz, R3, R4.x;
MUL R1.xyz, R1, c[1].x;
ADD R0, R0, -c[0];
MAD R0, R4.y, R0, c[0];
MUL R3.xyz, R1, R4.x;
MUL R2.xyz, R2, c[1].y;
MIN R1.xyz, R1, R2;
MAX R1.xyz, R1, R3;
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 25 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c1, 8.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xy
dcl t3
texldp r5, t3, s3
texld r2, t2, s4
texld r3, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r4, v0.y, r0
mad r4, v0.x, r1, r4
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r3, v0.z, r3, r4
rcp_pp r1.x, r0.x
mul_pp r4, r3, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r3, r4
mul_pp r3.xyz, r2.w, r2
mul_pp r3.xyz, r3, c1.x
add_pp r1, r1, -c0
mul_pp r2.xyz, r2, r5.x
mul_pp r2.xyz, r2, c1.y
mad_pp r0, r0.x, r1, c0
mul_pp r4.xyz, r3, r5.x
min_pp r2.xyz, r3, r2
max_pp r2.xyz, r2, r4
mul_pp r0.xyz, r0, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 192
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedbahjfhbbfddooaallmegfflfbfdclllkabaaaaaaceafaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaknaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
aaaeaaaaeaaaaaaaaaabaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaa
aeaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaoaaaaahdcaabaaa
aaaaaaaaegbabaaaaeaaaaaapgbpbaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaaaaaaaaahccaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagajbaaaabaaaaaadiaaaaahicaabaaaabaaaaaa
dkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaapgapbaaaabaaaaaaddaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaa
agajbaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadeaaaaahhcaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaa
egaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaadaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaa
kgbkbaaaadaaaaaaegaobaaaabaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
ckbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaabaaaaaapgapbaaa
aaaaaaaadjaaaaahbcaabaaaadaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dhaaaaajpcaabaaaabaaaaaaagaabaaaadaaaaaaegaobaaaacaaaaaaegaobaaa
abaaaaaaaaaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaa
aaaaaaaaahaaaaaadcaaaaakpcaabaaaabaaaaaapgapbaaaaaaaaaaaegaobaaa
abaaaaaaegiocaaaaaaaaaaaahaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 192
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedeebffmopdlmobmdkgdkmkdeccbiefmgdabaaaaaamiahaaaaaeaaaaaa
daaaaaaanaacaaaaniagaaaajeahaaaaebgpgodjjiacaaaajiacaaaaaaacpppp
feacaaaaeeaaaaaaabaadiaaaaaaeeaaaaaaeeaaafaaceaaaaaaeeaaadaaaaaa
aaababaaabacacaaacadadaaaeaeaeaaaaaaahaaabaaaaaaaaaaaaaaaaacpppp
fbaaaaafabaaapkaaaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaacplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaac
aaaaaaiaadaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapka
bpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaacaaaaaaja
aeaiapkaagaaaaacaaaaaiiaadaapplaafaaaaadaaaaadiaaaaappiaadaaoela
abaaaaacabaaadiaabaabllaabaaaaacacaacbiaaaaakklaabaaaaacacaaccia
aaaapplaecaaaaadaaaacpiaaaaaoeiaaaaioekaecaaaaadabaacpiaabaaoeia
aeaioekaecaaaaadacaacpiaacaaoeiaacaioekaecaaaaadadaacpiaaaaaoela
abaioekaecaaaaadaeaacpiaabaaoelaadaioekaacaaaaadaaaacciaaaaaaaia
aaaaaaiaafaaaaadaaaacoiaabaabliaaaaaffiaafaaaaadabaaciiaabaappia
abaaaakaafaaaaadabaachiaabaaoeiaabaappiaakaaaaadafaachiaaaaablia
abaaoeiaafaaaaadaaaachiaaaaaaaiaabaaoeiaalaaaaadabaachiaafaaoeia
aaaaoeiaafaaaaadaaaaapiaacaaoeiaacaafflaaeaaaaaeaaaaapiaadaaoeia
acaaaalaaaaaoeiaaeaaaaaeaaaacpiaaeaaoeiaacaakklaaaaaoeiaacaaaaad
abaaaiiaacaafflaacaaaalaacaaaaadabaaciiaabaappiaacaakklaagaaaaac
acaaabiaabaappiaafaaaaadacaacpiaaaaaoeiaacaaaaiaafaaaaadadaaabia
abaappiaabaappiafiaaaaaeaaaacpiaadaaaaibaaaaoeiaacaaoeiabcaaaaae
acaacpiaabaappiaaaaaoeiaaaaaoekaafaaaaadacaachiaabaaoeiaacaaoeia
abaaaaacaaaicpiaacaaoeiappppaaaafdeieefcaaaeaaaaeaaaaaaaaaabaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaa
fkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaad
pcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaeaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
adaaaaaaaagabaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaa
aeaaaaaaaagabaaaaeaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaa
agajbaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgapbaaaabaaaaaa
ddaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagajbaaaabaaaaaadiaaaaah
hcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadeaaaaahhcaabaaa
aaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaacaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaajpcaabaaa
abaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaaegaobaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaakgbkbaaaadaaaaaaegaobaaa
abaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaaaoaaaaah
pcaabaaaacaaaaaaegaobaaaabaaaaaapgapbaaaaaaaaaaadjaaaaahbcaabaaa
adaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaaabaaaaaa
agaabaaaadaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaaaaaaaaajpcaabaaa
abaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaaaaaaaaaaahaaaaaadcaaaaak
pcaabaaaabaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaa
ahaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaabejfdeheoleaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
acaaaaaaamamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "RenderType"="Opaque" }
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_Texture1_ST]
Vector 16 [_Texture2_ST]
Vector 17 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[18] = { program.local[0],
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[14].w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.color, vertex.color;
DP4 result.texcoord[4].z, R0, c[11];
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[2].z, R1, c[7];
DP3 result.texcoord[2].y, R1, c[6];
DP3 result.texcoord[2].x, R1, c[5];
ADD result.texcoord[3].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[17], c[17].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 20 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceLightPos0]
Vector 13 [unity_Scale]
Vector 14 [_Texture1_ST]
Vector 15 [_Texture2_ST]
Vector 16 [_Texture3_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r1.xyz, v1, c13.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov oD0, v3
dp4 oT4.z, r0, c10
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT2.z, r1, c6
dp3 oT2.y, r1, c5
dp3 oT2.x, r1, c4
add oT3.xyz, -r0, c12
mad oT0.zw, v2.xyxy, c15.xyxy, c15
mad oT0.xy, v2, c14, c14.zwzw
mad oT1.xy, v2, c16, c16.zwzw
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
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedgeeaiefopaimihoppcijlnmgphndacddabaaaaaaeiagaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefchiaeaaaaeaaaabaaboabaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaa
aaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaafpccabaaaadaaaaaa
egbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaa
acaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaa
acaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaaafaaaaaaegacbaia
ebaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiccaaaaaaaaaaaaeaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaa
adaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaagaaaaaaegiccaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedflkmjnpalnnafdiobdpdpnfnmlggahglabaaaaaaomaiaaaaaeaaaaaa
daaaaaaanaacaaaafaahaaaabiaiaaaaebgpgodjjiacaaaajiacaaaaaaacpopp
ciacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aeaaabaaaaaaaaaaaaaaaiaaadaaafaaaaaaaaaaabaaaaaaabaaaiaaaaaaaaaa
acaaaaaaaeaaajaaaaaaaaaaacaaamaaaeaaanaaaaaaaaaaacaabeaaabaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaaeaaaaaeaaaaamoaadaaeejaagaaeeka
agaaoekaaeaaaaaeabaaadoaadaaoejaahaaoekaahaaookaafaaaaadaaaaahia
acaaoejabbaappkaafaaaaadabaaahiaaaaaffiaaoaaoekaaeaaaaaeaaaaalia
anaakekaaaaaaaiaabaakeiaaeaaaaaeadaaahoaapaaoekaaaaakkiaaaaapeia
afaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahia
baaaoekaaaaappjaaaaaoeiaacaaaaadaeaaahoaaaaaoeibaiaaoekaafaaaaad
aaaaapiaaaaaffjaaoaaoekaaeaaaaaeaaaaapiaanaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabaaaoeka
aaaappjaaaaaoeiaafaaaaadabaaahiaaaaaffiaacaaoekaaeaaaaaeabaaahia
abaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiaadaaoekaaaaakkiaabaaoeia
aeaaaaaeafaaahoaaeaaoekaaaaappiaaaaaoeiaafaaaaadaaaaapiaaaaaffja
akaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
alaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoekaaaaappjaaaaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
abaaaaacacaaapoaafaaoejappppaaaafdeieefchiaeaaaaeaaaabaaboabaaaa
fjaaaaaeegiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaacacaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaa
aiaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
ajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaaf
pccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
acaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaa
afaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaaaaaaaaaaagaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaa
laaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_WorldSpaceLightPos0]
Vector 10 [unity_Scale]
Vector 11 [_Texture1_ST]
Vector 12 [_Texture2_ST]
Vector 13 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[14] = { program.local[0],
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[10].w;
MOV result.color, vertex.color;
DP3 result.texcoord[2].z, R0, c[7];
DP3 result.texcoord[2].y, R0, c[6];
DP3 result.texcoord[2].x, R0, c[5];
MOV result.texcoord[3].xyz, c[9];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[12].xyxy, c[12];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 13 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_WorldSpaceLightPos0]
Vector 9 [unity_Scale]
Vector 10 [_Texture1_ST]
Vector 11 [_Texture2_ST]
Vector 12 [_Texture3_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r0.xyz, v1, c9.w
mov oD0, v3
dp3 oT2.z, r0, c6
dp3 oT2.y, r0, c5
dp3 oT2.x, r0, c4
mov oT3.xyz, c8
mad oT0.zw, v2.xyxy, c11.xyxy, c11
mad oT0.xy, v2, c10, c10.zwzw
mad oT1.xy, v2, c12, c12.zwzw
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
ConstBuffer "$Globals" 112
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedklhnndhoielcgojhmapcoopiccbhghiiabaaaaaafaaeaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefcjiacaaaaeaaaabaakgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaa
afaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
agaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaa
afaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaghccabaaaafaaaaaa
egiccaaaabaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedmmnclcoinaaglplomlmfkjnlcahffmdcabaaaaaaaaagaaaaaeaaaaaa
daaaaaaanmabaaaahmaeaaaaeeafaaaaebgpgodjkeabaaaakeabaaaaaaacpopp
eaabaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaaeaa
adaaabaaaaaaaaaaabaaaaaaabaaaeaaaaaaaaaaacaaaaaaaeaaafaaaaaaaaaa
acaaamaaadaaajaaaaaaaaaaacaabeaaabaaamaaaaaaaaaaaaaaaaaaaaacpopp
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadia
adaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaabaaoeka
abaaookaaeaaaaaeaaaaamoaadaaeejaacaaeekaacaaoekaaeaaaaaeabaaadoa
adaaoejaadaaoekaadaaookaafaaaaadaaaaahiaacaaoejaamaappkaafaaaaad
abaaahiaaaaaffiaakaaoekaaeaaaaaeaaaaaliaajaakekaaaaaaaiaabaakeia
aeaaaaaeadaaahoaalaaoekaaaaakkiaaaaapeiaafaaaaadaaaaapiaaaaaffja
agaaoekaaeaaaaaeaaaaapiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaappjaaaaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
abaaaaacacaaapoaafaaoejaabaaaaacaeaaahoaaeaaoekappppaaaafdeieefc
jiacaaaaeaaaabaakgaaaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaae
egiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacacaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaa
aeaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
afaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaaf
pccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
acaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
dgaaaaaghccabaaaafaaaaaaegiccaaaabaaaaaaaaaaaaaadoaaaaabejfdeheo
maaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaaknaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_Texture1_ST]
Vector 16 [_Texture2_ST]
Vector 17 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[18] = { program.local[0],
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[14].w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.color, vertex.color;
DP4 result.texcoord[4].w, R0, c[12];
DP4 result.texcoord[4].z, R0, c[11];
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[2].z, R1, c[7];
DP3 result.texcoord[2].y, R1, c[6];
DP3 result.texcoord[2].x, R1, c[5];
ADD result.texcoord[3].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[17], c[17].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 21 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceLightPos0]
Vector 13 [unity_Scale]
Vector 14 [_Texture1_ST]
Vector 15 [_Texture2_ST]
Vector 16 [_Texture3_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r1.xyz, v1, c13.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov oD0, v3
dp4 oT4.w, r0, c11
dp4 oT4.z, r0, c10
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT2.z, r1, c6
dp3 oT2.y, r1, c5
dp3 oT2.x, r1, c4
add oT3.xyz, -r0, c12
mad oT0.zw, v2.xyxy, c15.xyxy, c15
mad oT0.xy, v2, c14, c14.zwzw
mad oT1.xy, v2, c16, c16.zwzw
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
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedplmdnibkgpnffamjobndgabfnalemahmabaaaaaaeiagaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaagaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefchiaeaaaaeaaaabaaboabaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaa
aaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaafpccabaaaadaaaaaa
egbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaa
acaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaa
acaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaaafaaaaaaegacbaia
ebaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiocaaaaaaaaaaaaeaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaak
pccabaaaagaaaaaaegiocaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegaobaaa
abaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefieceddiiceolkmhladkfhaahikgfnmgbefkejabaaaaaaomaiaaaaaeaaaaaa
daaaaaaanaacaaaafaahaaaabiaiaaaaebgpgodjjiacaaaajiacaaaaaaacpopp
ciacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aeaaabaaaaaaaaaaaaaaaiaaadaaafaaaaaaaaaaabaaaaaaabaaaiaaaaaaaaaa
acaaaaaaaeaaajaaaaaaaaaaacaaamaaaeaaanaaaaaaaaaaacaabeaaabaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaaeaaaaaeaaaaamoaadaaeejaagaaeeka
agaaoekaaeaaaaaeabaaadoaadaaoejaahaaoekaahaaookaafaaaaadaaaaahia
acaaoejabbaappkaafaaaaadabaaahiaaaaaffiaaoaaoekaaeaaaaaeaaaaalia
anaakekaaaaaaaiaabaakeiaaeaaaaaeadaaahoaapaaoekaaaaakkiaaaaapeia
afaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahia
baaaoekaaaaappjaaaaaoeiaacaaaaadaeaaahoaaaaaoeibaiaaoekaafaaaaad
aaaaapiaaaaaffjaaoaaoekaaeaaaaaeaaaaapiaanaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabaaaoeka
aaaappjaaaaaoeiaafaaaaadabaaapiaaaaaffiaacaaoekaaeaaaaaeabaaapia
abaaoekaaaaaaaiaabaaoeiaaeaaaaaeabaaapiaadaaoekaaaaakkiaabaaoeia
aeaaaaaeafaaapoaaeaaoekaaaaappiaabaaoeiaafaaaaadaaaaapiaaaaaffja
akaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
alaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoekaaaaappjaaaaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
abaaaaacacaaapoaafaaoejappppaaaafdeieefchiaeaaaaeaaaabaaboabaaaa
fjaaaaaeegiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacacaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaa
aiaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
ajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaaf
pccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
acaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaa
afaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaadcaaaaakpcaabaaaabaaaaaa
egiocaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaadcaaaaak
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaakpccabaaaagaaaaaaegiocaaaaaaaaaaaagaaaaaapgapbaaa
aaaaaaaaegaobaaaabaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaa
laaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_Texture1_ST]
Vector 16 [_Texture2_ST]
Vector 17 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[18] = { program.local[0],
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[14].w;
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 R0.w, vertex.position, c[8];
MOV result.color, vertex.color;
DP4 result.texcoord[4].z, R0, c[11];
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[2].z, R1, c[7];
DP3 result.texcoord[2].y, R1, c[6];
DP3 result.texcoord[2].x, R1, c[5];
ADD result.texcoord[3].xyz, -R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[17], c[17].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 20 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceLightPos0]
Vector 13 [unity_Scale]
Vector 14 [_Texture1_ST]
Vector 15 [_Texture2_ST]
Vector 16 [_Texture3_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r1.xyz, v1, c13.w
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp4 r0.w, v0, c7
mov oD0, v3
dp4 oT4.z, r0, c10
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT2.z, r1, c6
dp3 oT2.y, r1, c5
dp3 oT2.x, r1, c4
add oT3.xyz, -r0, c12
mad oT0.zw, v2.xyxy, c15.xyxy, c15
mad oT0.xy, v2, c14, c14.zwzw
mad oT1.xy, v2, c16, c16.zwzw
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
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedgeeaiefopaimihoppcijlnmgphndacddabaaaaaaeiagaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefchiaeaaaaeaaaabaaboabaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
afaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaa
aaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaafpccabaaaadaaaaaa
egbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaa
acaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaa
acaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaa
agaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaa
acaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaaafaaaaaaegacbaia
ebaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiccaaaaaaaaaaaaeaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaa
adaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hccabaaaagaaaaaaegiccaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedflkmjnpalnnafdiobdpdpnfnmlggahglabaaaaaaomaiaaaaaeaaaaaa
daaaaaaanaacaaaafaahaaaabiaiaaaaebgpgodjjiacaaaajiacaaaaaaacpopp
ciacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aeaaabaaaaaaaaaaaaaaaiaaadaaafaaaaaaaaaaabaaaaaaabaaaiaaaaaaaaaa
acaaaaaaaeaaajaaaaaaaaaaacaaamaaaeaaanaaaaaaaaaaacaabeaaabaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaaeaaaaaeaaaaamoaadaaeejaagaaeeka
agaaoekaaeaaaaaeabaaadoaadaaoejaahaaoekaahaaookaafaaaaadaaaaahia
acaaoejabbaappkaafaaaaadabaaahiaaaaaffiaaoaaoekaaeaaaaaeaaaaalia
anaakekaaaaaaaiaabaakeiaaeaaaaaeadaaahoaapaaoekaaaaakkiaaaaapeia
afaaaaadaaaaahiaaaaaffjaaoaaoekaaeaaaaaeaaaaahiaanaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahia
baaaoekaaaaappjaaaaaoeiaacaaaaadaeaaahoaaaaaoeibaiaaoekaafaaaaad
aaaaapiaaaaaffjaaoaaoekaaeaaaaaeaaaaapiaanaaoekaaaaaaajaaaaaoeia
aeaaaaaeaaaaapiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabaaaoeka
aaaappjaaaaaoeiaafaaaaadabaaahiaaaaaffiaacaaoekaaeaaaaaeabaaahia
abaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiaadaaoekaaaaakkiaabaaoeia
aeaaaaaeafaaahoaaeaaoekaaaaappiaaaaaoeiaafaaaaadaaaaapiaaaaaffja
akaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
alaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoekaaaaappjaaaaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
abaaaaacacaaapoaafaaoejappppaaaafdeieefchiaeaaaaeaaaabaaboabaaaa
fjaaaaaeegiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaacacaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaa
aiaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
ajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaaf
pccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
acaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
acaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhccabaaa
afaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaabaaaaaaaaaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaaaaaaaaaaagaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaa
laaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
lmaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaalmaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_LightMatrix0]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_Texture1_ST]
Vector 16 [_Texture2_ST]
Vector 17 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[18] = { program.local[0],
		state.matrix.mvp,
		program.local[5..17] };
TEMP R0;
TEMP R1;
MUL R1.xyz, vertex.normal, c[14].w;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MOV result.color, vertex.color;
DP4 result.texcoord[4].y, R0, c[10];
DP4 result.texcoord[4].x, R0, c[9];
DP3 result.texcoord[2].z, R1, c[7];
DP3 result.texcoord[2].y, R1, c[6];
DP3 result.texcoord[2].x, R1, c[5];
MOV result.texcoord[3].xyz, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[17], c[17].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 19 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_LightMatrix0]
Vector 12 [_WorldSpaceLightPos0]
Vector 13 [unity_Scale]
Vector 14 [_Texture1_ST]
Vector 15 [_Texture2_ST]
Vector 16 [_Texture3_ST]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r1.xyz, v1, c13.w
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mov oD0, v3
dp4 oT4.y, r0, c9
dp4 oT4.x, r0, c8
dp3 oT2.z, r1, c6
dp3 oT2.y, r1, c5
dp3 oT2.x, r1, c4
mov oT3.xyz, c12
mad oT0.zw, v2.xyxy, c15.xyxy, c15
mad oT0.xy, v2, c14, c14.zwzw
mad oT1.xy, v2, c16, c16.zwzw
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
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecednidnmffjegjnmfbkdocmbpnfplnckpdaabaaaaaakeafaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefcneadaaaaeaaaabaapfaaaaaafjaaaaaeegiocaaa
aaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaa
aeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaa
aaaaaaaaajaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaidcaabaaaabaaaaaafgafbaaaaaaaaaaaegiacaaaaaaaaaaaaeaaaaaa
dcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egaabaaaabaaaaaadcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaaafaaaaaa
kgakbaaaaaaaaaaaegaabaaaaaaaaaaadcaaaaakmccabaaaacaaaaaaagiecaaa
aaaaaaaaagaaaaaapgapbaaaaaaaaaaaagaebaaaaaaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaa
akaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaa
aaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaa
aaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaa
dcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaa
egadbaaaaaaaaaaadgaaaaaghccabaaaafaaaaaaegiccaaaabaaaaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Matrix 48 [_LightMatrix0]
Vector 128 [_Texture1_ST]
Vector 144 [_Texture2_ST]
Vector 160 [_Texture3_ST]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedodibkjlnlhcbffkbnbjphmbclkbgpaplabaaaaaapiahaaaaaeaaaaaa
daaaaaaaiaacaaaafmagaaaaceahaaaaebgpgodjeiacaaaaeiacaaaaaaacpopp
niabaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aeaaabaaaaaaaaaaaaaaaiaaadaaafaaaaaaaaaaabaaaaaaabaaaiaaaaaaaaaa
acaaaaaaaeaaajaaaaaaaaaaacaaamaaaeaaanaaaaaaaaaaacaabeaaabaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaaeaaaaaeaaaaamoaadaaeejaagaaeeka
agaaoekaaeaaaaaeabaaadoaadaaoejaahaaoekaahaaookaafaaaaadaaaaahia
acaaoejabbaappkaafaaaaadabaaahiaaaaaffiaaoaaoekaaeaaaaaeaaaaalia
anaakekaaaaaaaiaabaakeiaaeaaaaaeadaaahoaapaaoekaaaaakkiaaaaapeia
afaaaaadaaaaapiaaaaaffjaaoaaoekaaeaaaaaeaaaaapiaanaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaapaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
baaaoekaaaaappjaaaaaoeiaafaaaaadabaaadiaaaaaffiaacaaobkaaeaaaaae
aaaaadiaabaaobkaaaaaaaiaabaaoeiaaeaaaaaeaaaaadiaadaaobkaaaaakkia
aaaaoeiaaeaaaaaeabaaamoaaeaabekaaaaappiaaaaaeeiaafaaaaadaaaaapia
aaaaffjaakaaoekaaeaaaaaeaaaaapiaajaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiaalaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaamaaoekaaaaappja
aaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaamma
aaaaoeiaabaaaaacacaaapoaafaaoejaabaaaaacaeaaahoaaiaaoekappppaaaa
fdeieefcneadaaaaeaaaabaapfaaaaaafjaaaaaeegiocaaaaaaaaaaaalaaaaaa
fjaaaaaeegiocaaaabaaaaaaabaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
hccabaaaafaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaadcaaaaalmccabaaaabaaaaaa
agbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaanaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiacaaaaaaaaaaaaeaaaaaadcaaaaakdcaabaaa
aaaaaaaaegiacaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegaabaaaabaaaaaa
dcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaa
egaabaaaaaaaaaaadcaaaaakmccabaaaacaaaaaaagiecaaaaaaaaaaaagaaaaaa
pgapbaaaaaaaaaaaagaebaaaaaaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadgaaaaaf
pccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaacaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
acaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaa
aeaaaaaaegiccaaaacaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
dgaaaaaghccabaaaafaaaaaaegiccaaaabaaaaaaaaaaaaaadoaaaaabejfdeheo
maaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaacaaaaaaamadaaaamfaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTexture0] 2D 3
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R2.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R0.xyz, fragment.texcoord[1], texture[2], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
MUL R2.xyz, fragment.color.primary.y, R2;
MAD R1.xyz, fragment.color.primary.x, R1, R2;
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
ADD R1.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R1.w, R1, fragment.color.primary.z;
MAD R0.xyz, fragment.color.primary.z, R0, R1;
RCP R2.x, R1.w;
MUL R1.xyz, R0, R2.x;
ABS R2.y, R1.w;
CMP R0.xyz, -R2.y, R1, R0;
ADD R1.xyz, R0, -c[1];
DP3 R2.x, fragment.texcoord[3], fragment.texcoord[3];
RSQ R2.x, R2.x;
MAD R1.xyz, R1.w, R1, c[1];
MUL R0.xyz, R2.x, fragment.texcoord[3];
DP3 R1.w, fragment.texcoord[2], R0;
MUL R0.xyz, R1, c[0];
MAX R1.x, R1.w, c[2];
MOV result.color.w, c[2].x;
TEX R0.w, R0.w, texture[3], 2D;
MUL R0.w, R1.x, R0;
MUL R0.xyz, R0.w, R0;
MUL result.color.xyz, R0, c[2].y;
END
# 26 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTexture0] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c2, 0.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xyz
texld r2, t1, s2
dp3 r0.x, t4, t4
mov r1.xy, r0.x
mov r0.y, t0.w
mov r0.x, t0.z
texld r4, r1, s3
texld r0, r0, s1
texld r1, t0, s0
mul r3.xyz, v0.y, r0
mad r3.xyz, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r2.xyz, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3.xyz, r2, r1.x
abs_pp r1.x, r0
cmp_pp r2.xyz, -r1.x, r2, r3
dp3_pp r1.x, t3, t3
add_pp r2.xyz, r2, -c1
rsq_pp r1.x, r1.x
mad_pp r0.xyz, r0.x, r2, c1
mul_pp r1.xyz, r1.x, t3
dp3_pp r1.x, t2, r1
mul_pp r0.xyz, r0, c0
max_pp r1.x, r1, c2
mul_pp r1.x, r1, r4
mul_pp r0.xyz, r1.x, r0
mul_pp r0.xyz, r0, c2.y
mov_pp r0.w, c2.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "POINT" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecediilndmdbledhpdpiaalblhmehofnabioabaaaaaaaeafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmiadaaaaeaaaaaaa
pcaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaa
gcbaaaadhcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaa
efaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaagbabaaaadaaaaaa
egacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaadaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaa
kgbkbaaaadaaaaaaegacbaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
ckbabaaaadaaaaaaaoaaaaahhcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaadjaaaaahicaabaaaabaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dhaaaaajhcaabaaaaaaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaa
aaaaaaaaahaaaaaadcaaaaakhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaahaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
afaaaaaaegbcbaaaafaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaafaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaabaaaaaahbcaabaaaabaaaaaa
egbcbaaaagaaaaaaegbcbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaagaabaaa
abaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaa
pgapbaaaaaaaaaaaagaabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedcadkmknknibjpoohmgkoahphkgdaakcpabaaaaaajmahaaaaaeaaaaaa
daaaaaaameacaaaajeagaaaagiahaaaaebgpgodjimacaaaaimacaaaaaaacpppp
eaacaaaaemaaaaaaacaadeaaaaaaemaaaaaaemaaaeaaceaaaaaaemaaadaaaaaa
aaababaaabacacaaacadadaaaaaaabaaabaaaaaaaaaaaaaaaaaaahaaabaaabaa
aaaaaaaaaaacppppfbaaaaafacaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaiaabaacdlabpaaaaacaaaaaaia
acaaaplabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaaiaaeaachlabpaaaaac
aaaaaaiaafaaahlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapka
bpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkaabaaaaacaaaacbia
aaaakklaabaaaaacaaaacciaaaaapplaaiaaaaadabaaaiiaafaaoelaafaaoela
abaaaaacabaaadiaabaappiaecaaaaadaaaacpiaaaaaoeiaacaioekaecaaaaad
acaacpiaaaaaoelaabaioekaecaaaaadadaacpiaabaaoelaadaioekaecaaaaad
abaacpiaabaaoeiaaaaioekaafaaaaadaaaaahiaaaaaoeiaacaafflaaeaaaaae
aaaaahiaacaaoeiaacaaaalaaaaaoeiaaeaaaaaeaaaachiaadaaoeiaacaakkla
aaaaoeiaacaaaaadaaaaaiiaacaafflaacaaaalaacaaaaadaaaaciiaaaaappia
acaakklaagaaaaacabaaaciaaaaappiaafaaaaadabaacoiaaaaabliaabaaffia
afaaaaadacaaabiaaaaappiaaaaappiafiaaaaaeaaaachiaacaaaaibaaaaoeia
abaabliabcaaaaaeabaacoiaaaaappiaaaaabliaabaablkaafaaaaadaaaachia
abaabliaaaaaoekaceaaaaacacaachiaaeaaoelaaiaaaaadaaaaciiaadaaoela
acaaoeiaafaaaaadabaacbiaabaaaaiaaaaappiafiaaaaaeaaaaciiaaaaappia
abaaaaiaacaaaakaacaaaaadaaaaciiaaaaappiaaaaappiaafaaaaadaaaachia
aaaappiaaaaaoeiaabaaaaacaaaaaiiaacaaaakaabaaaaacaaaicpiaaaaaoeia
ppppaaaafdeieefcmiadaaaaeaaaaaaapcaaaaaafjaaaaaeegiocaaaaaaaaaaa
aiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaad
aagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadhcbabaaaagaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaajhcaabaaaaaaaaaaa
egacbaaaabaaaaaaagbabaaaadaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaadcaaaaaj
hcaabaaaaaaaaaaaegacbaaaabaaaaaakgbkbaaaadaaaaaaegacbaaaaaaaaaaa
aaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaaaoaaaaahhcaabaaa
abaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadjaaaaahicaabaaaabaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaajhcaabaaaaaaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaahaaaaaadcaaaaakhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaahaaaaaa
diaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaa
baaaaaahicaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaa
aaaaaaaaegbcbaaaafaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaa
egacbaaaabaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaa
efaaaaajpcaabaaaabaaaaaaagaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaa
aaaaaaaaapaaaaahicaabaaaaaaaaaaapgapbaaaaaaaaaaaagaabaaaabaaaaaa
diaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaagaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R2.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R0.xyz, fragment.texcoord[1], texture[2], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
ADD R0.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R0.w, R0, fragment.color.primary.z;
MUL R2.xyz, fragment.color.primary.y, R2;
MAD R1.xyz, fragment.color.primary.x, R1, R2;
MAD R0.xyz, fragment.color.primary.z, R0, R1;
RCP R1.w, R0.w;
MUL R1.xyz, R0, R1.w;
ABS R1.w, R0;
CMP R0.xyz, -R1.w, R1, R0;
ADD R1.xyz, R0, -c[1];
MOV R0.xyz, fragment.texcoord[3];
DP3 R0.x, fragment.texcoord[2], R0;
MAD R1.xyz, R0.w, R1, c[1];
MUL R1.xyz, R1, c[0];
MAX R0.x, R0, c[2];
MUL R0.xyz, R0.x, R1;
MUL result.color.xyz, R0, c[2].y;
MOV result.color.w, c[2].x;
END
# 21 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c2, 0.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r3.xyz, v0.y, r0
mad r3.xyz, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r2.xyz, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3.xyz, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1.xyz, -r1.x, r2, r3
add_pp r2.xyz, r1, -c1
mov_pp r1.xyz, t3
mad_pp r2.xyz, r0.x, r2, c1
dp3_pp r0.x, t2, r1
mul_pp r1.xyz, r2, c0
max_pp r0.x, r0, c2
mul_pp r0.xyz, r0.x, r1
mul_pp r0.xyz, r0, c2.y
mov_pp r0.w, c2.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
ConstBuffer "$Globals" 112
Vector 16 [_LightColor0]
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecednjighbllldoafjpgkceegbenialnfpaiabaaaaaadiaeaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
beadaaaaeaaaaaaamfaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
fibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaa
efaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaagbabaaaadaaaaaa
egacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaa
kgbkbaaaadaaaaaaegacbaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
ckbabaaaadaaaaaaaoaaaaahhcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaadjaaaaahicaabaaaabaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dhaaaaajhcaabaaaaaaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaa
aaaaaaaaadaaaaaadcaaaaakhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegbcbaaaafaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
ConstBuffer "$Globals" 112
Vector 16 [_LightColor0]
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedicdckfajbpegbpojfojbpigbkhadfkcdabaaaaaaheagaaaaaeaaaaaa
daaaaaaagiacaaaaieafaaaaeaagaaaaebgpgodjdaacaaaadaacaaaaaaacpppp
oiabaaaaeiaaaaaaacaadaaaaaaaeiaaaaaaeiaaadaaceaaaaaaeiaaaaaaaaaa
abababaaacacacaaaaaaabaaabaaaaaaaaaaaaaaaaaaadaaabaaabaaaaaaaaaa
aaacppppfbaaaaafacaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
aaaaaaiaaaaacplabpaaaaacaaaaaaiaabaacdlabpaaaaacaaaaaaiaacaaapla
bpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaaiaaeaachlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkaabaaaaac
aaaacbiaaaaakklaabaaaaacaaaacciaaaaapplaecaaaaadaaaacpiaaaaaoeia
abaioekaecaaaaadabaacpiaaaaaoelaaaaioekaecaaaaadacaacpiaabaaoela
acaioekaafaaaaadaaaaahiaaaaaoeiaacaafflaaeaaaaaeaaaaahiaabaaoeia
acaaaalaaaaaoeiaaeaaaaaeaaaachiaacaaoeiaacaakklaaaaaoeiaacaaaaad
aaaaaiiaacaafflaacaaaalaacaaaaadaaaaciiaaaaappiaacaakklaagaaaaac
abaaabiaaaaappiaafaaaaadabaachiaaaaaoeiaabaaaaiaafaaaaadabaaaiia
aaaappiaaaaappiafiaaaaaeaaaachiaabaappibaaaaoeiaabaaoeiabcaaaaae
abaachiaaaaappiaaaaaoeiaabaaoekaafaaaaadaaaachiaabaaoeiaaaaaoeka
abaaaaacabaaahiaadaaoelaaiaaaaadaaaaciiaabaaoeiaaeaaoelaalaaaaad
abaacbiaaaaappiaacaaaakaacaaaaadaaaaciiaabaaaaiaabaaaaiaafaaaaad
aaaachiaaaaappiaaaaaoeiaabaaaaacaaaaaiiaacaaaakaabaaaaacaaaicpia
aaaaoeiappppaaaafdeieefcbeadaaaaeaaaaaaamfaaaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
pcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaa
abaaaaaaagbabaaaadaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaajhcaabaaa
aaaaaaaaegacbaaaabaaaaaakgbkbaaaadaaaaaaegacbaaaaaaaaaaaaaaaaaah
icaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaaaoaaaaahhcaabaaaabaaaaaa
egacbaaaaaaaaaaapgapbaaaaaaaaaaadjaaaaahicaabaaaabaaaaaadkaabaaa
aaaaaaaaabeaaaaaaaaaaaaadhaaaaajhcaabaaaaaaaaaaapgapbaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaiaebaaaaaaaaaaaaaaadaaaaaadcaaaaakhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaabaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaafaaaaaadeaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaa
doaaaaabejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaaknaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTexture0] 2D 3
SetTexture 4 [_LightTextureB0] 2D 4
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 0.5, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
RCP R0.x, fragment.texcoord[4].w;
MAD R3.xy, fragment.texcoord[4], R0.x, c[2].y;
MUL R2.xyz, fragment.color.primary.y, R2;
DP3 R1.w, fragment.texcoord[4], fragment.texcoord[4];
ADD R2.w, fragment.color.primary.x, fragment.color.primary.y;
MAD R1.xyz, fragment.color.primary.x, R1, R2;
ADD R2.w, R2, fragment.color.primary.z;
RCP R2.x, R2.w;
MOV result.color.w, c[2].x;
TEX R0.xyz, fragment.texcoord[1], texture[2], 2D;
TEX R0.w, R3, texture[3], 2D;
TEX R1.w, R1.w, texture[4], 2D;
MAD R0.xyz, fragment.color.primary.z, R0, R1;
MUL R1.xyz, R0, R2.x;
ABS R2.x, R2.w;
CMP R0.xyz, -R2.x, R1, R0;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
ADD R0.xyz, R0, -c[1];
RSQ R2.x, R1.x;
MAD R1.xyz, R2.w, R0, c[1];
MUL R0.xyz, R2.x, fragment.texcoord[3];
DP3 R0.x, fragment.texcoord[2], R0;
SLT R0.y, c[2].x, fragment.texcoord[4].z;
MUL R0.y, R0, R0.w;
MUL R0.y, R0, R1.w;
MAX R0.x, R0, c[2];
MUL R1.xyz, R1, c[0];
MUL R0.x, R0, R0.y;
MUL R0.xyz, R0.x, R1;
MUL result.color.xyz, R0, c[2].z;
END
# 32 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTexture0] 2D 3
SetTexture 4 [_LightTextureB0] 2D 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c2, 0.00000000, 1.00000000, 0.50000000, 2.00000000
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
dp3 r2.x, t4, t4
mov r2.xy, r2.x
rcp r1.x, t4.w
mad r1.xy, t4, r1.x, c2.z
mov r0.y, t0.w
mov r0.x, t0.z
texld r4, r2, s4
texld r3, r1, s3
texld r0, r0, s1
texld r2, t1, s2
texld r1, t0, s0
mul r3.xyz, v0.y, r0
add r0.x, v0, v0.y
mad r3.xyz, v0.x, r1, r3
add r0.x, r0, v0.z
mad r2.xyz, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3.xyz, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1.xyz, -r1.x, r2, r3
add_pp r1.xyz, r1, -c1
mad_pp r0.xyz, r0.x, r1, c1
mul_pp r2.xyz, r0, c0
dp3_pp r0.x, t3, t3
rsq_pp r1.x, r0.x
mul_pp r1.xyz, r1.x, t3
dp3_pp r1.x, t2, r1
cmp r0.x, -t4.z, c2, c2.y
mul_pp r0.x, r0, r3.w
mul_pp r0.x, r0, r4
max_pp r1.x, r1, c2
mul_pp r0.x, r1, r0
mul_pp r0.xyz, r0.x, r2
mul_pp r0.xyz, r0, c2.w
mov_pp r0.w, c2.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" }
SetTexture 0 [_Texture1] 2D 2
SetTexture 1 [_Texture2] 2D 3
SetTexture 2 [_Texture3] 2D 4
SetTexture 3 [_LightTexture0] 2D 0
SetTexture 4 [_LightTextureB0] 2D 1
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedeiknlmanjbgdpfnbmkenpfenpepmooaiabaaaaaapiafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefclmaeaaaaeaaaaaaa
cpabaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaad
pcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaaoaaaaah
dcaabaaaaaaaaaaaegbabaaaagaaaaaapgbpbaaaagaaaaaaaaaaaaakdcaabaaa
aaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaa
efaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaadaaaaaaaagabaaa
aaaaaaaadbaaaaahbcaabaaaaaaaaaaaabeaaaaaaaaaaaaackbabaaaagaaaaaa
abaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaah
bcaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaaaaaaaaaabaaaaaahccaabaaa
aaaaaaaaegbcbaaaagaaaaaaegbcbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaa
fgafbaaaaaaaaaaaeghobaaaaeaaaaaaaagabaaaabaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaabaaaaaabaaaaaahccaabaaaaaaaaaaa
egbcbaaaafaaaaaaegbcbaaaafaaaaaaeeaaaaafccaabaaaaaaaaaaabkaabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagbjbaaaafaaaaaa
baaaaaahccaabaaaaaaaaaaaegbcbaaaaeaaaaaajgahbaaaaaaaaaaadeaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaaaaaapaaaaahbcaabaaa
aaaaaaaafgafbaaaaaaaaaaaagaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaahocaabaaa
aaaaaaaaagajbaaaabaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadcaaaaajocaabaaa
aaaaaaaaagajbaaaabaaaaaaagbabaaaadaaaaaafgaobaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaaeaaaaaa
dcaaaaajocaabaaaaaaaaaaaagajbaaaabaaaaaakgbkbaaaadaaaaaafgaobaaa
aaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaa
aaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaaaoaaaaah
ocaabaaaabaaaaaafgaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaahbcaabaaa
acaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaajocaabaaaaaaaaaaa
agaabaaaacaaaaaafgaobaaaabaaaaaafgaobaaaaaaaaaaaaaaaaaajocaabaaa
aaaaaaaafgaobaaaaaaaaaaaagijcaiaebaaaaaaaaaaaaaaahaaaaaadcaaaaak
ocaabaaaaaaaaaaaagaabaaaabaaaaaafgaobaaaaaaaaaaaagijcaaaaaaaaaaa
ahaaaaaadiaaaaaiocaabaaaaaaaaaaafgaobaaaaaaaaaaaagijcaaaaaaaaaaa
abaaaaaadiaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SPOT" }
SetTexture 0 [_Texture1] 2D 2
SetTexture 1 [_Texture2] 2D 3
SetTexture 2 [_Texture3] 2D 4
SetTexture 3 [_LightTexture0] 2D 0
SetTexture 4 [_LightTextureB0] 2D 1
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfnlhhbklbhohlmlgpdplpfnhdkgggjlbabaaaaaapaaiaaaaaeaaaaaa
daaaaaaaceadaaaaoiahaaaalmaiaaaaebgpgodjomacaaaaomacaaaaaaacpppp
jmacaaaafaaaaaaaacaadiaaaaaafaaaaaaafaaaafaaceaaaaaafaaaadaaaaaa
aeababaaaaacacaaabadadaaacaeaeaaaaaaabaaabaaaaaaaaaaaaaaaaaaahaa
abaaabaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaaadpaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaiaabaacdlabpaaaaac
aaaaaaiaacaaaplabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaaiaaeaachla
bpaaaaacaaaaaaiaafaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaaja
abaiapkabpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaac
aaaaaajaaeaiapkaabaaaaacaaaacbiaaaaakklaabaaaaacaaaacciaaaaappla
agaaaaacaaaaaeiaafaapplaaeaaaaaeabaaadiaafaaoelaaaaakkiaacaaaaka
aiaaaaadacaaaiiaafaaoelaafaaoelaabaaaaacacaaadiaacaappiaecaaaaad
aaaacpiaaaaaoeiaadaioekaecaaaaadadaacpiaaaaaoelaacaioekaecaaaaad
aeaacpiaabaaoelaaeaioekaecaaaaadabaacpiaabaaoeiaaaaioekaecaaaaad
acaacpiaacaaoeiaabaioekaafaaaaadaaaaahiaaaaaoeiaacaafflaaeaaaaae
aaaaahiaadaaoeiaacaaaalaaaaaoeiaaeaaaaaeaaaachiaaeaaoeiaacaakkla
aaaaoeiaacaaaaadaaaaaiiaacaafflaacaaaalaacaaaaadaaaaciiaaaaappia
acaakklaagaaaaacabaaabiaaaaappiaafaaaaadabaachiaaaaaoeiaabaaaaia
afaaaaadacaaaciaaaaappiaaaaappiafiaaaaaeaaaachiaacaaffibaaaaoeia
abaaoeiabcaaaaaeabaachiaaaaappiaaaaaoeiaabaaoekaafaaaaadaaaachia
abaaoeiaaaaaoekaafaaaaadaaaaciiaabaappiaacaaaaiafiaaaaaeaaaaciia
afaakklbacaaffkaaaaappiaceaaaaacabaachiaaeaaoelaaiaaaaadabaacbia
adaaoelaabaaoeiaalaaaaadacaacbiaabaaaaiaacaaffkaafaaaaadaaaaciia
aaaappiaacaaaaiaacaaaaadaaaaciiaaaaappiaaaaappiaafaaaaadaaaachia
aaaappiaaaaaoeiaabaaaaacaaaaaiiaacaaffkaabaaaaacaaaicpiaaaaaoeia
ppppaaaafdeieefclmaeaaaaeaaaaaaacpabaaaafjaaaaaeegiocaaaaaaaaaaa
aiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaad
aagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
fibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaa
fibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gcbaaaadhcbabaaaafaaaaaagcbaaaadpcbabaaaagaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaagaaaaaa
pgbpbaaaagaaaaaaaaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaadbaaaaahbcaabaaaaaaaaaaa
abeaaaaaaaaaaaaackbabaaaagaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaa
akaabaaaaaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaagaaaaaaegbcbaaa
agaaaaaaefaaaaajpcaabaaaabaaaaaafgafbaaaaaaaaaaaeghobaaaaeaaaaaa
aagabaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
abaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaa
eeaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahocaabaaaaaaaaaaa
fgafbaaaaaaaaaaaagbjbaaaafaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaa
aeaaaaaajgahbaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaaaaaaaaaaapaaaaahbcaabaaaaaaaaaaafgafbaaaaaaaaaaaagaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaadaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaafgbfbaaa
adaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaacaaaaaadcaaaaajocaabaaaaaaaaaaaagajbaaaabaaaaaaagbabaaa
adaaaaaafgaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaaeaaaaaadcaaaaajocaabaaaaaaaaaaaagajbaaa
abaaaaaakgbkbaaaadaaaaaafgaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaa
bkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaa
abaaaaaackbabaaaadaaaaaaaoaaaaahocaabaaaabaaaaaafgaobaaaaaaaaaaa
agaabaaaabaaaaaadjaaaaahbcaabaaaacaaaaaaakaabaaaabaaaaaaabeaaaaa
aaaaaaaadhaaaaajocaabaaaaaaaaaaaagaabaaaacaaaaaafgaobaaaabaaaaaa
fgaobaaaaaaaaaaaaaaaaaajocaabaaaaaaaaaaafgaobaaaaaaaaaaaagijcaia
ebaaaaaaaaaaaaaaahaaaaaadcaaaaakocaabaaaaaaaaaaaagaabaaaabaaaaaa
fgaobaaaaaaaaaaaagijcaaaaaaaaaaaahaaaaaadiaaaaaiocaabaaaaaaaaaaa
fgaobaaaaaaaaaaaagijcaaaaaaaaaaaabaaaaaadiaaaaahhccabaaaaaaaaaaa
agaabaaaaaaaaaaajgahbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
mfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaaapapaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaaklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTextureB0] 2D 3
SetTexture 4 [_LightTexture0] CUBE 4
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R2.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R0.xyz, fragment.texcoord[1], texture[2], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[4], texture[4], CUBE;
MUL R2.xyz, fragment.color.primary.y, R2;
MAD R1.xyz, fragment.color.primary.x, R1, R2;
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
ADD R2.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R2.w, R2, fragment.color.primary.z;
MAD R0.xyz, fragment.color.primary.z, R0, R1;
RCP R2.x, R2.w;
MUL R1.xyz, R0, R2.x;
ABS R2.x, R2.w;
CMP R0.xyz, -R2.x, R1, R0;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
ADD R0.xyz, R0, -c[1];
RSQ R2.x, R1.x;
MAD R1.xyz, R2.w, R0, c[1];
MUL R0.xyz, R2.x, fragment.texcoord[3];
DP3 R0.x, fragment.texcoord[2], R0;
MUL R1.xyz, R1, c[0];
MAX R0.x, R0, c[2];
MOV result.color.w, c[2].x;
TEX R0.w, R0.w, texture[3], 2D;
MUL R0.y, R0.w, R1.w;
MUL R0.x, R0, R0.y;
MUL R0.xyz, R0.x, R1;
MUL result.color.xyz, R0, c[2].y;
END
# 28 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTextureB0] 2D 3
SetTexture 4 [_LightTexture0] CUBE 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c2, 0.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xyz
texld r2, t1, s2
texld r3, t4, s4
dp3 r1.x, t4, t4
mov r1.xy, r1.x
mov r0.y, t0.w
mov r0.x, t0.z
texld r4, r1, s3
texld r0, r0, s1
texld r1, t0, s0
mul r3.xyz, v0.y, r0
mad r3.xyz, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r2.xyz, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3.xyz, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1.xyz, -r1.x, r2, r3
add_pp r1.xyz, r1, -c1
mad_pp r1.xyz, r0.x, r1, c1
dp3_pp r0.x, t3, t3
rsq_pp r0.x, r0.x
mul_pp r0.xyz, r0.x, t3
dp3_pp r0.x, t2, r0
mul_pp r1.xyz, r1, c0
mul r2.x, r4, r3.w
max_pp r0.x, r0, c2
mul_pp r0.x, r0, r2
mul_pp r0.xyz, r0.x, r1
mul_pp r0.xyz, r0, c2.y
mov_pp r0.w, c2.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" }
SetTexture 0 [_Texture1] 2D 2
SetTexture 1 [_Texture2] 2D 3
SetTexture 2 [_Texture3] 2D 4
SetTexture 3 [_LightTextureB0] 2D 1
SetTexture 4 [_LightTexture0] CUBE 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmnnpbiillcgplgofjgidcakmchgjgojfabaaaaaagaafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcceaeaaaaeaaaaaaa
ajabaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fibiaaaeaahabaaaadaaaaaaffffaaaafidaaaaeaahabaaaaeaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaad
hcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaa
dcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaagbabaaaadaaaaaaegacbaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaa
aagabaaaaeaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaakgbkbaaa
adaaaaaaegacbaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaa
akbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaa
adaaaaaaaoaaaaahhcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaa
djaaaaahicaabaaaabaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaaj
hcaabaaaaaaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
aaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaa
ahaaaaaadcaaaaakhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaaaaaaaaaahaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaaaaaaaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaafaaaaaa
egbcbaaaafaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaafaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaaeaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaa
agaaaaaaegbcbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaagaabaaaabaaaaaa
eghobaaaadaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbcbaaa
agaaaaaaeghobaaaaeaaaaaaaagabaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaa
akaabaaaabaaaaaadkaabaaaacaaaaaaapaaaaahicaabaaaaaaaaaaapgapbaaa
aaaaaaaaagaabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "POINT_COOKIE" }
SetTexture 0 [_Texture1] 2D 2
SetTexture 1 [_Texture2] 2D 3
SetTexture 2 [_Texture3] 2D 4
SetTexture 3 [_LightTextureB0] 2D 1
SetTexture 4 [_LightTexture0] CUBE 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedmcnohooelelgljhchploocnafehijcepabaaaaaaceaiaaaaaeaaaaaa
daaaaaaapaacaaaabmahaaaapaahaaaaebgpgodjliacaaaaliacaaaaaaacpppp
giacaaaafaaaaaaaacaadiaaaaaafaaaaaaafaaaafaaceaaaaaafaaaaeaaaaaa
adababaaaaacacaaabadadaaacaeaeaaaaaaabaaabaaaaaaaaaaaaaaaaaaahaa
abaaabaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaiaabaacdlabpaaaaac
aaaaaaiaacaaaplabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaaiaaeaachla
bpaaaaacaaaaaaiaafaaahlabpaaaaacaaaaaajiaaaiapkabpaaaaacaaaaaaja
abaiapkabpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaac
aaaaaajaaeaiapkaabaaaaacaaaacbiaaaaakklaabaaaaacaaaacciaaaaappla
aiaaaaadabaaaiiaafaaoelaafaaoelaabaaaaacabaaadiaabaappiaecaaaaad
aaaacpiaaaaaoeiaadaioekaecaaaaadacaacpiaaaaaoelaacaioekaecaaaaad
adaacpiaabaaoelaaeaioekaecaaaaadabaaapiaabaaoeiaabaioekaecaaaaad
aeaaapiaafaaoelaaaaioekaafaaaaadaaaaahiaaaaaoeiaacaafflaaeaaaaae
aaaaahiaacaaoeiaacaaaalaaaaaoeiaaeaaaaaeaaaachiaadaaoeiaacaakkla
aaaaoeiaacaaaaadaaaaaiiaacaafflaacaaaalaacaaaaadaaaaciiaaaaappia
acaakklaagaaaaacabaaaciaaaaappiaafaaaaadabaacoiaaaaabliaabaaffia
afaaaaadacaaabiaaaaappiaaaaappiafiaaaaaeaaaachiaacaaaaibaaaaoeia
abaabliabcaaaaaeabaacoiaaaaappiaaaaabliaabaablkaafaaaaadaaaachia
abaabliaaaaaoekaafaaaaadaaaaciiaabaaaaiaaeaappiaceaaaaacabaachia
aeaaoelaaiaaaaadabaacbiaadaaoelaabaaoeiaalaaaaadacaacbiaabaaaaia
acaaaakaafaaaaadaaaaciiaaaaappiaacaaaaiaacaaaaadaaaaciiaaaaappia
aaaappiaafaaaaadaaaachiaaaaappiaaaaaoeiaabaaaaacaaaaaiiaacaaaaka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcceaeaaaaeaaaaaaaajabaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaa
fkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaafidaaaaeaahabaaaaeaaaaaaffffaaaagcbaaaad
pcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaagcbaaaadhcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadiaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadcaaaaaj
hcaabaaaaaaaaaaaegacbaaaabaaaaaaagbabaaaadaaaaaaegacbaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
aeaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaakgbkbaaaadaaaaaa
egacbaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaa
adaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaa
aoaaaaahhcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadjaaaaah
icaabaaaabaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaajhcaabaaa
aaaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaahaaaaaa
dcaaaaakhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaa
aaaaaaaaahaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaa
aaaaaaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaafaaaaaaegbcbaaa
afaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegbcbaaaafaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegacbaaaabaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaaabeaaaaaaaaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaagaaaaaa
egbcbaaaagaaaaaaefaaaaajpcaabaaaabaaaaaaagaabaaaabaaaaaaeghobaaa
adaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbcbaaaagaaaaaa
eghobaaaaeaaaaaaaagabaaaaaaaaaaadiaaaaahbcaabaaaabaaaaaaakaabaaa
abaaaaaadkaabaaaacaaaaaaapaaaaahicaabaaaaaaaaaaapgapbaaaaaaaaaaa
agaabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheo
mmaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaalmaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaamfaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahahaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaagaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTexture0] 2D 3
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R2.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R0.xyz, fragment.texcoord[1], texture[2], 2D;
TEX R1.xyz, fragment.texcoord[0], texture[0], 2D;
TEX R0.w, fragment.texcoord[4], texture[3], 2D;
MUL R2.xyz, fragment.color.primary.y, R2;
MAD R1.xyz, fragment.color.primary.x, R1, R2;
ADD R1.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R1.w, R1, fragment.color.primary.z;
MAD R0.xyz, fragment.color.primary.z, R0, R1;
RCP R2.x, R1.w;
MUL R1.xyz, R0, R2.x;
ABS R2.x, R1.w;
CMP R0.xyz, -R2.x, R1, R0;
ADD R1.xyz, R0, -c[1];
MAD R1.xyz, R1.w, R1, c[1];
MOV R0.xyz, fragment.texcoord[3];
DP3 R1.w, fragment.texcoord[2], R0;
MUL R0.xyz, R1, c[0];
MAX R1.x, R1.w, c[2];
MUL R0.w, R1.x, R0;
MUL R0.xyz, R0.w, R0;
MUL result.color.xyz, R0, c[2].y;
MOV result.color.w, c[2].x;
END
# 23 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightTexture0] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c2, 0.00000000, 2.00000000, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4.xy
texld r2, t1, s2
texld r1, t0, s0
texld r3, t4, s3
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r3.xyz, v0.y, r0
mad r3.xyz, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
rcp_pp r1.x, r0.x
mad r2.xyz, v0.z, r2, r3
mul_pp r3.xyz, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1.xyz, -r1.x, r2, r3
add_pp r1.xyz, r1, -c1
mad_pp r1.xyz, r0.x, r1, c1
mov_pp r0.xyz, t3
dp3_pp r0.x, t2, r0
mul_pp r1.xyz, r1, c0
max_pp r0.x, r0, c2
mul_pp r0.x, r0, r3.w
mul_pp r0.xyz, r0.x, r1
mul_pp r0.xyz, r0, c2.y
mov_pp r0.w, c2.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmhbfckfddegljhoblcigkdfkjcfjoeecabaaaaaajmaeaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaamfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgaadaaaaeaaaaaaa
niaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaad
mcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gcbaaaadhcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaa
efaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaaagbabaaaadaaaaaa
egacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaadaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaa
kgbkbaaaadaaaaaaegacbaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
ckbabaaaadaaaaaaaoaaaaahhcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaa
aaaaaaaadjaaaaahicaabaaaabaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dhaaaaajhcaabaaaaaaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaa
aaaaaaaaahaaaaaadcaaaaakhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaahaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaabaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegbcbaaaafaaaaaadeaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaa
adaaaaaaaagabaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaapgapbaaaaaaaaaaa
pgapbaaaabaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL_COOKIE" }
SetTexture 0 [_Texture1] 2D 1
SetTexture 1 [_Texture2] 2D 2
SetTexture 2 [_Texture3] 2D 3
SetTexture 3 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedjkpenbalikfjnajbikhgkenbpfcgafogabaaaaaabiahaaaaaeaaaaaa
daaaaaaakiacaaaabaagaaaaoeagaaaaebgpgodjhaacaaaahaacaaaaaaacpppp
ceacaaaaemaaaaaaacaadeaaaaaaemaaaaaaemaaaeaaceaaaaaaemaaadaaaaaa
aaababaaabacacaaacadadaaaaaaabaaabaaaaaaaaaaaaaaaaaaahaaabaaabaa
aaaaaaaaaaacppppfbaaaaafacaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaia
acaaaplabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaaiaaeaachlabpaaaaac
aaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapka
bpaaaaacaaaaaajaadaiapkaabaaaaacaaaacbiaaaaakklaabaaaaacaaaaccia
aaaapplaabaaaaacabaaadiaabaabllaecaaaaadaaaacpiaaaaaoeiaacaioeka
ecaaaaadacaacpiaaaaaoelaabaioekaecaaaaadadaacpiaabaaoelaadaioeka
ecaaaaadabaacpiaabaaoeiaaaaioekaafaaaaadaaaaahiaaaaaoeiaacaaffla
aeaaaaaeaaaaahiaacaaoeiaacaaaalaaaaaoeiaaeaaaaaeaaaachiaadaaoeia
acaakklaaaaaoeiaacaaaaadaaaaaiiaacaafflaacaaaalaacaaaaadaaaaciia
aaaappiaacaakklaagaaaaacabaaabiaaaaappiaafaaaaadabaachiaaaaaoeia
abaaaaiaafaaaaadacaaabiaaaaappiaaaaappiafiaaaaaeaaaachiaacaaaaib
aaaaoeiaabaaoeiabcaaaaaeabaachiaaaaappiaaaaaoeiaabaaoekaafaaaaad
aaaachiaabaaoeiaaaaaoekaabaaaaacabaaahiaadaaoelaaiaaaaadaaaaciia
abaaoeiaaeaaoelaafaaaaadabaacbiaabaappiaaaaappiafiaaaaaeaaaaciia
aaaappiaabaaaaiaacaaaakaacaaaaadaaaaciiaaaaappiaaaaappiaafaaaaad
aaaachiaaaaappiaaaaaoeiaabaaaaacaaaaaiiaacaaaakaabaaaaacaaaicpia
aaaaoeiappppaaaafdeieefcgaadaaaaeaaaaaaaniaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaajhcaabaaa
aaaaaaaaegacbaaaabaaaaaaagbabaaaadaaaaaaegacbaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaa
dcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaakgbkbaaaadaaaaaaegacbaaa
aaaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaaaoaaaaah
hcaabaaaabaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadjaaaaahicaabaaa
abaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaajhcaabaaaaaaaaaaa
pgapbaaaabaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaahaaaaaadcaaaaak
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaa
ahaaaaaadiaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaa
abaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaaafaaaaaa
deaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaa
apaaaaahicaabaaaaaaaaaaapgapbaaaaaaaaaaapgapbaaaabaaaaaadiaaaaah
hccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadadaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaa
mfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahahaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 5 [_Object2World]
Vector 9 [unity_Scale]
"!!ARBvp1.0
PARAM c[10] = { program.local[0],
		state.matrix.mvp,
		program.local[5..9] };
TEMP R0;
MUL R0.xyz, vertex.normal, c[9].w;
DP3 result.texcoord[0].z, R0, c[7];
DP3 result.texcoord[0].y, R0, c[6];
DP3 result.texcoord[0].x, R0, c[5];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [unity_Scale]
"vs_2_0
dcl_position0 v0
dcl_normal0 v1
mul r0.xyz, v1, c8.w
dp3 oT0.z, r0, c6
dp3 oT0.y, r0, c5
dp3 oT0.x, r0, c4
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefieceddgoflhcgfinoonoplgmdiabihpafgdafabaaaaaaneacaaaaadaaaaaa
cmaaaaaapeaaaaaaemabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheofaaaaaaaacaaaaaa
aiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefciaabaaaaeaaaabaagaaaaaaafjaaaaae
egiocaaaaaaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadhccabaaaabaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
aaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaaaaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaaaaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhccabaaaabaaaaaaegiccaaaaaaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "UnityPerDraw" 0
"vs_4_0_level_9_1
eefiecedfpmclfcoogjdlpcnlpgnljpcdonknacmabaaaaaaaaaeaaaaaeaaaaaa
daaaaaaafiabaaaaoaacaaaakiadaaaaebgpgodjcaabaaaacaabaaaaaaacpopp
neaaaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaamaaadaaafaaaaaaaaaaaaaabeaaabaaaiaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapja
afaaaaadaaaaahiaacaaoejaaiaappkaafaaaaadabaaahiaaaaaffiaagaaoeka
aeaaaaaeaaaaaliaafaakekaaaaaaaiaabaakeiaaeaaaaaeaaaaahoaahaaoeka
aaaakkiaaaaapeiaafaaaaadaaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapia
abaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaaeaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefciaabaaaa
eaaaabaagaaaaaaafjaaaaaeegiocaaaaaaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadhcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadhccabaaaabaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaa
pgipcaaaaaaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiccaaaaaaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaaaaaaaaa
amaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaabaaaaaa
egiccaaaaaaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
"
}
}
Program "fp" {
SubProgram "opengl " {
"!!ARBfp1.0
PARAM c[1] = { { 0, 0.5 } };
MAD result.color.xyz, fragment.texcoord[0], c[0].y, c[0].y;
MOV result.color.w, c[0].x;
END
# 2 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
"ps_2_0
def c0, 0.50000000, 0.00000000, 0, 0
dcl t0.xyz
mad_pp r0.xyz, t0, c0.x, c0.x
mov_pp r0.w, c0.y
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
"ps_4_0
eefiecedhbdiiogganilkmhhpogjlnaalcliljppabaaaaaadeabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcheaaaaaa
eaaaaaaabnaaaaaagcbaaaadhcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
dcaaaaaphccabaaaaaaaaaaaegbcbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
"ps_4_0_level_9_1
eefiecedbcfagkfmhchaonghfjackccpkbjompokabaaaaaalmabaaaaaeaaaaaa
daaaaaaaleaaaaaadaabaaaaiiabaaaaebgpgodjhmaaaaaahmaaaaaaaaacpppp
fiaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaachlaaeaaaaaeaaaachiaaaaaoelaaaaaaakaaaaaaakaabaaaaacaaaaciia
aaaaffkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcheaaaaaaeaaaaaaa
bnaaaaaagcbaaaadhcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaadcaaaaap
hccabaaaaaaaaaaaegbcbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
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
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_ProjectionParams]
Vector 10 [unity_SHAr]
Vector 11 [unity_SHAg]
Vector 12 [unity_SHAb]
Vector 13 [unity_SHBr]
Vector 14 [unity_SHBg]
Vector 15 [unity_SHBb]
Vector 16 [unity_SHC]
Vector 17 [unity_Scale]
Vector 18 [_Texture1_ST]
Vector 19 [_Texture2_ST]
Vector 20 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[17].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[12];
DP4 R2.y, R0, c[11];
DP4 R2.x, R0, c[10];
MUL R0.y, R2.w, R2.w;
DP4 R3.z, R1, c[15];
DP4 R3.y, R1, c[14];
DP4 R3.x, R1, c[13];
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
MAD R0.x, R0, R0, -R0.y;
ADD R3.xyz, R2, R3;
MUL R2.xyz, R0.x, c[16];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[9].x;
ADD result.texcoord[3].xyz, R3, R2;
ADD result.texcoord[2].xy, R0, R0.z;
MOV result.position, R1;
MOV result.color, vertex.color;
MOV result.texcoord[2].zw, R1;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[19].xyxy, c[19];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[20], c[20].zwzw;
END
# 31 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_SHAr]
Vector 11 [unity_SHAg]
Vector 12 [unity_SHAb]
Vector 13 [unity_SHBr]
Vector 14 [unity_SHBg]
Vector 15 [unity_SHBb]
Vector 16 [unity_SHC]
Vector 17 [unity_Scale]
Vector 18 [_Texture1_ST]
Vector 19 [_Texture2_ST]
Vector 20 [_Texture3_ST]
"vs_2_0
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r1.xyz, v1, c17.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c21.y
dp4 r2.z, r0, c12
dp4 r2.y, r0, c11
dp4 r2.x, r0, c10
mul r0.y, r2.w, r2.w
dp4 r3.z, r1, c15
dp4 r3.y, r1, c14
dp4 r3.x, r1, c13
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
mad r0.x, r0, r0, -r0.y
add r3.xyz, r2, r3
mul r2.xyz, r0.x, c16
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c8.x
add oT3.xyz, r3, r2
mad oT2.xy, r0.z, c9.zwzw, r0
mov oPos, r1
mov oD0, v3
mov oT2.zw, r1
mad oT0.zw, v2.xyxy, c19.xyxy, c19
mad oT0.xy, v2, c18, c18.zwzw
mad oT1.xy, v2, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedlfignkkgloddodjknmimmmkadnafhogbabaaaaaaemagaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefcjeaeaaaaeaaaabaacfabaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
aeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaa
aaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaafpccabaaaadaaaaaa
egbobaaaafaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaa
aaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhccabaaaafaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefieceddpoffidoleggjdldcdakgoejmncjcmapabaaaaaaceajaaaaaeaaaaaa
daaaaaaaaeadaaaakaahaaaagiaiaaaaebgpgodjmmacaaaammacaaaaaaacpopp
fmacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaaeaa
adaaabaaaaaaaaaaabaaafaaabaaaeaaaaaaaaaaacaacgaaahaaafaaaaaaaaaa
adaaaaaaaeaaamaaaaaaaaaaadaaamaaadaabaaaaaaaaaaaadaabeaaabaabdaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaaadpaaaaiadpaaaaaaaa
aaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoeja
abaaoekaabaaookaaeaaaaaeaaaaamoaadaaeejaacaaeekaacaaoekaaeaaaaae
abaaadoaadaaoejaadaaoekaadaaookaafaaaaadaaaaapiaaaaaffjaanaaoeka
aeaaaaaeaaaaapiaamaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaoaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiaapaaoekaaaaappjaaaaaoeiaafaaaaad
abaaabiaaaaaffiaaeaaaakaafaaaaadabaaaiiaabaaaaiabeaaaakaafaaaaad
abaaafiaaaaapeiabeaaaakaacaaaaadadaaadoaabaakkiaabaaomiaafaaaaad
abaaahiaacaaoejabdaappkaafaaaaadacaaahiaabaaffiabbaaoekaaeaaaaae
abaaaliabaaakekaabaaaaiaacaakeiaaeaaaaaeabaaahiabcaaoekaabaakkia
abaapeiaabaaaaacabaaaiiabeaaffkaajaaaaadacaaabiaafaaoekaabaaoeia
ajaaaaadacaaaciaagaaoekaabaaoeiaajaaaaadacaaaeiaahaaoekaabaaoeia
afaaaaadadaaapiaabaacjiaabaakeiaajaaaaadaeaaabiaaiaaoekaadaaoeia
ajaaaaadaeaaaciaajaaoekaadaaoeiaajaaaaadaeaaaeiaakaaoekaadaaoeia
acaaaaadacaaahiaacaaoeiaaeaaoeiaafaaaaadabaaaciaabaaffiaabaaffia
aeaaaaaeabaaabiaabaaaaiaabaaaaiaabaaffibaeaaaaaeaeaaahoaalaaoeka
abaaaaiaacaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoaafaaoeja
ppppaaaafdeieefcjeaeaaaaeaaaabaacfabaaaafjaaaaaeegiocaaaaaaaaaaa
ahaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaa
afaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaal
dccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaa
aaaaaaaaagaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
aeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaa
egbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaa
egiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaa
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
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaa
knaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaakl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 9 [_Object2World]
Vector 13 [_ProjectionParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_LightmapST]
Vector 16 [_Texture1_ST]
Vector 17 [_Texture2_ST]
Vector 18 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..18] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[13].x;
ADD result.texcoord[2].xy, R1, R1.z;
MOV result.position, R0;
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[14].w;
DP4 R0.x, vertex.position, c[3];
DP4 R1.z, vertex.position, c[11];
DP4 R1.x, vertex.position, c[9];
DP4 R1.y, vertex.position, c[10];
ADD R1.xyz, R1, -c[14];
MOV result.color, vertex.color;
MOV result.texcoord[2].zw, R0;
MUL result.texcoord[4].xyz, R1, c[14].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[3].xy, vertex.texcoord[1], c[15], c[15].zwzw;
MUL result.texcoord[4].w, -R0.x, R0.y;
END
# 23 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_LightmapST]
Vector 16 [_Texture1_ST]
Vector 17 [_Texture2_ST]
Vector 18 [_Texture3_ST]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
dcl_texcoord1 v2
dcl_color0 v3
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c19.x
mul r1.y, r1, c12.x
mad oT2.xy, r1.z, c13.zwzw, r1
mov oPos, r0
mov r0.x, c14.w
add r0.y, c19, -r0.x
dp4 r0.x, v0, c2
dp4 r1.z, v0, c10
dp4 r1.x, v0, c8
dp4 r1.y, v0, c9
add r1.xyz, r1, -c14
mov oD0, v3
mov oT2.zw, r0
mul oT4.xyz, r1, c14.w
mad oT0.zw, v1.xyxy, c17.xyxy, c17
mad oT0.xy, v1, c16, c16.zwzw
mad oT1.xy, v1, c18, c18.zwzw
mad oT3.xy, v2, c15, c15.zwzw
mul oT4.w, -r0.x, r0.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefieceddnnanikphiemgpalcmhmcdchejjhdjgbabaaaaaaemagaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefchmaeaaaaeaaaabaabpabaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaabkaaaaaafjaaaaaeegiocaaaadaaaaaabaaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaad
pcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaad
pccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaa
dcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaagaaaaaa
kgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaa
acaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaa
aeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaiccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaa
abaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadp
dgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaia
ebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaaafaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaa
ckiacaaaadaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaa
aeaaaaaaakbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
ckiacaaaadaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaaacaaaaaabjaaaaaa
abeaaaaaaaaaiadpdiaaaaaiiccabaaaafaaaaaabkaabaaaaaaaaaaaakaabaia
ebaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedbfhahbmcoepihebchemggibimofpmefbabaaaaaaaeajaaaaaeaaaaaa
daaaaaaaoeacaaaagiahaaaadaaiaaaaebgpgodjkmacaaaakmacaaaaaaacpopp
eiacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaaeaa
aeaaabaaaaaaaaaaabaaafaaabaaafaaaaaaaaaaacaabjaaabaaagaaaaaaaaaa
adaaaaaaaiaaahaaaaaaaaaaadaaamaaaeaaapaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbdaaapkaaaaaaadpaaaaiadpaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjabpaaaaac
afaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoekaacaaookaaeaaaaae
aaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoaadaaoejaaeaaoeka
aeaaookaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaafaaaaka
afaaaaadabaaaiiaabaaaaiabdaaaakaafaaaaadabaaafiaaaaapeiabdaaaaka
acaaaaadadaaadoaabaakkiaabaaomiaaeaaaaaeabaaamoaaeaabejaabaabeka
abaalekaafaaaaadabaaahiaaaaaffjabaaaoekaaeaaaaaeabaaahiaapaaoeka
aaaaaajaabaaoeiaaeaaaaaeabaaahiabbaaoekaaaaakkjaabaaoeiaaeaaaaae
abaaahiabcaaoekaaaaappjaabaaoeiaacaaaaadabaaahiaabaaoeiaagaaoekb
afaaaaadaeaaahoaabaaoeiaagaappkaafaaaaadabaaabiaaaaaffjaamaakkka
aeaaaaaeabaaabiaalaakkkaaaaaaajaabaaaaiaaeaaaaaeabaaabiaanaakkka
aaaakkjaabaaaaiaaeaaaaaeabaaabiaaoaakkkaaaaappjaabaaaaiaabaaaaac
abaaaiiaagaappkaacaaaaadabaaaciaabaappibbdaaffkaafaaaaadaeaaaioa
abaaffiaabaaaaibaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoaafaaoeja
ppppaaaafdeieefchmaeaaaaeaaaabaabpabaaaafjaaaaaeegiocaaaaaaaaaaa
aiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
bkaaaaaafjaaaaaeegiocaaaadaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaa
afaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaac
acaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaagaaaaaakgiocaaa
aaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaacaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaa
dgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaa
acaaaaaabjaaaaaadiaaaaaihccabaaaafaaaaaaegacbaaaaaaaaaaapgipcaaa
acaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaa
adaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaa
akbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaaacaaaaaabjaaaaaaabeaaaaa
aaaaiadpdiaaaaaiiccabaaaafaaaaaabkaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
laaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadamaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaaamadaaaa
mfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaakl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 5 [_ProjectionParams]
Vector 6 [unity_LightmapST]
Vector 7 [_Texture1_ST]
Vector 8 [_Texture2_ST]
Vector 9 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[10] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..9] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[5].x;
ADD result.texcoord[2].xy, R1, R1.z;
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[2].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[8].xyxy, c[8];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[7], c[7].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[3].xy, vertex.texcoord[1], c[6], c[6].zwzw;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_ProjectionParams]
Vector 5 [_ScreenParams]
Vector 6 [unity_LightmapST]
Vector 7 [_Texture1_ST]
Vector 8 [_Texture2_ST]
Vector 9 [_Texture3_ST]
"vs_2_0
def c10, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
dcl_texcoord1 v2
dcl_color0 v3
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c10.x
mul r1.y, r1, c4.x
mad oT2.xy, r1.z, c5.zwzw, r1
mov oPos, r0
mov oD0, v3
mov oT2.zw, r0
mad oT0.zw, v1.xyxy, c8.xyxy, c8
mad oT0.xy, v1, c7, c7.zwzw
mad oT1.xy, v1, c9, c9.zwzw
mad oT3.xy, v2, c6, c6.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefieceddcgjgmnogklhigmnjejpmgcabegbhkodabaaaaaagaaeaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefckiacaaaaeaaaabaakkaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadpccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaa
ogikcaaaaaaaaaaaafaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaagaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaa
ahaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaa
aeaaaaaakgiocaaaaaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaa
afaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedmnlngofegplgkmlenojojdcpfgiebgflabaaaaaabmagaaaaaeaaaaaa
daaaaaaaoiabaaaajiaeaaaagaafaaaaebgpgodjlaabaaaalaabaaaaaaacpopp
geabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaaeaa
aeaaabaaaaaaaaaaabaaafaaabaaafaaaaaaaaaaacaaaaaaaeaaagaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafakaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeia
aeaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoeka
acaaookaaeaaaaaeaaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoa
adaaoejaaeaaoekaaeaaookaafaaaaadaaaaapiaaaaaffjaahaaoekaaeaaaaae
aaaaapiaagaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaappjaaaaaoeiaafaaaaadabaaabia
aaaaffiaafaaaakaafaaaaadabaaaiiaabaaaaiaakaaaakaafaaaaadabaaafia
aaaapeiaakaaaakaacaaaaadadaaadoaabaakkiaabaaomiaaeaaaaaeabaaamoa
aeaabejaabaabekaabaalekaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoa
afaaoejappppaaaafdeieefckiacaaaaeaaaabaakkaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaa
afaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
agaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
aeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
kbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaa
ljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaakeaaaaaaadaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_ProjectionParams]
Vector 10 [unity_SHAr]
Vector 11 [unity_SHAg]
Vector 12 [unity_SHAb]
Vector 13 [unity_SHBr]
Vector 14 [unity_SHBg]
Vector 15 [unity_SHBb]
Vector 16 [unity_SHC]
Vector 17 [unity_Scale]
Vector 18 [_Texture1_ST]
Vector 19 [_Texture2_ST]
Vector 20 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MUL R1.xyz, vertex.normal, c[17].w;
DP3 R2.w, R1, c[6];
DP3 R0.x, R1, c[5];
DP3 R0.z, R1, c[7];
MOV R0.y, R2.w;
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].y;
DP4 R2.z, R0, c[12];
DP4 R2.y, R0, c[11];
DP4 R2.x, R0, c[10];
MUL R0.y, R2.w, R2.w;
DP4 R3.z, R1, c[15];
DP4 R3.y, R1, c[14];
DP4 R3.x, R1, c[13];
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
MAD R0.x, R0, R0, -R0.y;
ADD R3.xyz, R2, R3;
MUL R2.xyz, R0.x, c[16];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[9].x;
ADD result.texcoord[3].xyz, R3, R2;
ADD result.texcoord[2].xy, R0, R0.z;
MOV result.position, R1;
MOV result.color, vertex.color;
MOV result.texcoord[2].zw, R1;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[19].xyxy, c[19];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[20], c[20].zwzw;
END
# 31 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_SHAr]
Vector 11 [unity_SHAg]
Vector 12 [unity_SHAb]
Vector 13 [unity_SHBr]
Vector 14 [unity_SHBg]
Vector 15 [unity_SHBb]
Vector 16 [unity_SHC]
Vector 17 [unity_Scale]
Vector 18 [_Texture1_ST]
Vector 19 [_Texture2_ST]
Vector 20 [_Texture3_ST]
"vs_2_0
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_color0 v3
mul r1.xyz, v1, c17.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c21.y
dp4 r2.z, r0, c12
dp4 r2.y, r0, c11
dp4 r2.x, r0, c10
mul r0.y, r2.w, r2.w
dp4 r3.z, r1, c15
dp4 r3.y, r1, c14
dp4 r3.x, r1, c13
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
mad r0.x, r0, r0, -r0.y
add r3.xyz, r2, r3
mul r2.xyz, r0.x, c16
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c8.x
add oT3.xyz, r3, r2
mad oT2.xy, r0.z, c9.zwzw, r0
mov oPos, r1
mov oD0, v3
mov oT2.zw, r1
mad oT0.zw, v2.xyxy, c19.xyxy, c19
mad oT0.xy, v2, c18, c18.zwzw
mad oT1.xy, v2, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedlfignkkgloddodjknmimmmkadnafhogbabaaaaaaemagaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefcjeaeaaaaeaaaabaacfabaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
aeaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaa
aaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadgaaaaafpccabaaaadaaaaaa
egbobaaaafaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaa
aaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaabaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaa
aaaaaaaabbaaaaaiccaabaaaabaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaa
aaaaaaaabbaaaaaiecaabaaaabaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaa
bbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaa
bbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaa
bbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaa
aaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaa
dcaaaaakhccabaaaafaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 64 [_Texture1_ST]
Vector 80 [_Texture2_ST]
Vector 96 [_Texture3_ST]
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
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefieceddpoffidoleggjdldcdakgoejmncjcmapabaaaaaaceajaaaaaeaaaaaa
daaaaaaaaeadaaaakaahaaaagiaiaaaaebgpgodjmmacaaaammacaaaaaaacpopp
fmacaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaaeaa
adaaabaaaaaaaaaaabaaafaaabaaaeaaaaaaaaaaacaacgaaahaaafaaaaaaaaaa
adaaaaaaaeaaamaaaaaaaaaaadaaamaaadaabaaaaaaaaaaaadaabeaaabaabdaa
aaaaaaaaaaaaaaaaaaacpoppfbaaaaafbeaaapkaaaaaaadpaaaaiadpaaaaaaaa
aaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoeja
abaaoekaabaaookaaeaaaaaeaaaaamoaadaaeejaacaaeekaacaaoekaaeaaaaae
abaaadoaadaaoejaadaaoekaadaaookaafaaaaadaaaaapiaaaaaffjaanaaoeka
aeaaaaaeaaaaapiaamaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaoaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiaapaaoekaaaaappjaaaaaoeiaafaaaaad
abaaabiaaaaaffiaaeaaaakaafaaaaadabaaaiiaabaaaaiabeaaaakaafaaaaad
abaaafiaaaaapeiabeaaaakaacaaaaadadaaadoaabaakkiaabaaomiaafaaaaad
abaaahiaacaaoejabdaappkaafaaaaadacaaahiaabaaffiabbaaoekaaeaaaaae
abaaaliabaaakekaabaaaaiaacaakeiaaeaaaaaeabaaahiabcaaoekaabaakkia
abaapeiaabaaaaacabaaaiiabeaaffkaajaaaaadacaaabiaafaaoekaabaaoeia
ajaaaaadacaaaciaagaaoekaabaaoeiaajaaaaadacaaaeiaahaaoekaabaaoeia
afaaaaadadaaapiaabaacjiaabaakeiaajaaaaadaeaaabiaaiaaoekaadaaoeia
ajaaaaadaeaaaciaajaaoekaadaaoeiaajaaaaadaeaaaeiaakaaoekaadaaoeia
acaaaaadacaaahiaacaaoeiaaeaaoeiaafaaaaadabaaaciaabaaffiaabaaffia
aeaaaaaeabaaabiaabaaaaiaabaaaaiaabaaffibaeaaaaaeaeaaahoaalaaoeka
abaaaaiaacaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoaafaaoeja
ppppaaaafdeieefcjeaeaaaaeaaaabaacfabaaaafjaaaaaeegiocaaaaaaaaaaa
ahaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaadpcbabaaa
afaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
aeaaaaaaogikcaaaaaaaaaaaaeaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaal
dccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaa
aaaaaaaaagaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
aeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaa
egbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaa
fgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaa
egiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaa
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
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaa
knaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
afaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaakl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 9 [_Object2World]
Vector 13 [_ProjectionParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_LightmapST]
Vector 16 [_Texture1_ST]
Vector 17 [_Texture2_ST]
Vector 18 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[19] = { { 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..18] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[13].x;
ADD result.texcoord[2].xy, R1, R1.z;
MOV result.position, R0;
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[14].w;
DP4 R0.x, vertex.position, c[3];
DP4 R1.z, vertex.position, c[11];
DP4 R1.x, vertex.position, c[9];
DP4 R1.y, vertex.position, c[10];
ADD R1.xyz, R1, -c[14];
MOV result.color, vertex.color;
MOV result.texcoord[2].zw, R0;
MUL result.texcoord[4].xyz, R1, c[14].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[3].xy, vertex.texcoord[1], c[15], c[15].zwzw;
MUL result.texcoord[4].w, -R0.x, R0.y;
END
# 23 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_LightmapST]
Vector 16 [_Texture1_ST]
Vector 17 [_Texture2_ST]
Vector 18 [_Texture3_ST]
"vs_2_0
def c19, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
dcl_texcoord1 v2
dcl_color0 v3
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c19.x
mul r1.y, r1, c12.x
mad oT2.xy, r1.z, c13.zwzw, r1
mov oPos, r0
mov r0.x, c14.w
add r0.y, c19, -r0.x
dp4 r0.x, v0, c2
dp4 r1.z, v0, c10
dp4 r1.x, v0, c8
dp4 r1.y, v0, c9
add r1.xyz, r1, -c14
mov oD0, v3
mov oT2.zw, r0
mul oT4.xyz, r1, c14.w
mad oT0.zw, v1.xyxy, c17.xyxy, c17
mad oT0.xy, v1, c16, c16.zwzw
mad oT1.xy, v1, c18, c18.zwzw
mad oT3.xy, v2, c15, c15.zwzw
mul oT4.w, -r0.x, r0.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefieceddnnanikphiemgpalcmhmcdchejjhdjgbabaaaaaaemagaaaaadaaaaaa
cmaaaaaapeaaaaaamiabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklfdeieefchmaeaaaaeaaaabaabpabaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaabkaaaaaafjaaaaaeegiocaaaadaaaaaabaaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaad
pcbabaaaafaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaad
pccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
adaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaa
dcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaagaaaaaa
kgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaa
acaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaa
aeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaiccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaa
abaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadp
dgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
adaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaia
ebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaaafaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaa
ckiacaaaadaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaa
aeaaaaaaakbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
ckiacaaaadaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaaacaaaaaabjaaaaaa
abeaaaaaaaaaiadpdiaaaaaiiccabaaaafaaaaaabkaabaaaaaaaaaaaakaabaia
ebaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedbfhahbmcoepihebchemggibimofpmefbabaaaaaaaeajaaaaaeaaaaaa
daaaaaaaoeacaaaagiahaaaadaaiaaaaebgpgodjkmacaaaakmacaaaaaaacpopp
eiacaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaaeaa
aeaaabaaaaaaaaaaabaaafaaabaaafaaaaaaaaaaacaabjaaabaaagaaaaaaaaaa
adaaaaaaaiaaahaaaaaaaaaaadaaamaaaeaaapaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbdaaapkaaaaaaadpaaaaiadpaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjabpaaaaac
afaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoekaacaaookaaeaaaaae
aaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoaadaaoejaaeaaoeka
aeaaookaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaafaaaaka
afaaaaadabaaaiiaabaaaaiabdaaaakaafaaaaadabaaafiaaaaapeiabdaaaaka
acaaaaadadaaadoaabaakkiaabaaomiaaeaaaaaeabaaamoaaeaabejaabaabeka
abaalekaafaaaaadabaaahiaaaaaffjabaaaoekaaeaaaaaeabaaahiaapaaoeka
aaaaaajaabaaoeiaaeaaaaaeabaaahiabbaaoekaaaaakkjaabaaoeiaaeaaaaae
abaaahiabcaaoekaaaaappjaabaaoeiaacaaaaadabaaahiaabaaoeiaagaaoekb
afaaaaadaeaaahoaabaaoeiaagaappkaafaaaaadabaaabiaaaaaffjaamaakkka
aeaaaaaeabaaabiaalaakkkaaaaaaajaabaaaaiaaeaaaaaeabaaabiaanaakkka
aaaakkjaabaaaaiaaeaaaaaeabaaabiaaoaakkkaaaaappjaabaaaaiaabaaaaac
abaaaiiaagaappkaacaaaaadabaaaciaabaappibbdaaffkaafaaaaadaeaaaioa
abaaffiaabaaaaibaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoaafaaoeja
ppppaaaafdeieefchmaeaaaaeaaaabaabpabaaaafjaaaaaeegiocaaaaaaaaaaa
aiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
bkaaaaaafjaaaaaeegiocaaaadaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaa
afaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaac
acaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaaafaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaagaaaaaakgiocaaa
aaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaacaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaa
dgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaa
acaaaaaabjaaaaaadiaaaaaihccabaaaafaaaaaaegacbaaaaaaaaaaapgipcaaa
acaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaa
adaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaa
akbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaaacaaaaaabjaaaaaaabeaaaaa
aaaaiadpdiaaaaaiiccabaaaafaaaaaabkaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaa
laaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheommaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadamaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaaamadaaaa
mfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaakl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 5 [_ProjectionParams]
Vector 6 [unity_LightmapST]
Vector 7 [_Texture1_ST]
Vector 8 [_Texture2_ST]
Vector 9 [_Texture3_ST]
"!!ARBvp1.0
PARAM c[10] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..9] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[5].x;
ADD result.texcoord[2].xy, R1, R1.z;
MOV result.position, R0;
MOV result.color, vertex.color;
MOV result.texcoord[2].zw, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[8].xyxy, c[8];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[7], c[7].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[3].xy, vertex.texcoord[1], c[6], c[6].zwzw;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_ProjectionParams]
Vector 5 [_ScreenParams]
Vector 6 [unity_LightmapST]
Vector 7 [_Texture1_ST]
Vector 8 [_Texture2_ST]
Vector 9 [_Texture3_ST]
"vs_2_0
def c10, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
dcl_texcoord1 v2
dcl_color0 v3
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c10.x
mul r1.y, r1, c4.x
mad oT2.xy, r1.z, c5.zwzw, r1
mov oPos, r0
mov oD0, v3
mov oT2.zw, r0
mad oT0.zw, v1.xyxy, c8.xyxy, c8
mad oT0.xy, v1, c7, c7.zwzw
mad oT1.xy, v1, c9, c9.zwzw
mad oT3.xy, v2, c6, c6.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefieceddcgjgmnogklhigmnjejpmgcabegbhkodabaaaaaagaaeaaaaadaaaaaa
cmaaaaaapeaaaaaalaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklfdeieefckiacaaaaeaaaabaakkaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaa
fjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadpccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaa
ogikcaaaaaaaaaaaafaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaagaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaa
ahaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaa
aeaaaaaakgiocaaaaaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaa
afaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 64 [unity_LightmapST]
Vector 80 [_Texture1_ST]
Vector 96 [_Texture2_ST]
Vector 112 [_Texture3_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedmnlngofegplgkmlenojojdcpfgiebgflabaaaaaabmagaaaaaeaaaaaa
daaaaaaaoiabaaaajiaeaaaagaafaaaaebgpgodjlaabaaaalaabaaaaaaacpopp
geabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaaeaa
aeaaabaaaaaaaaaaabaaafaaabaaafaaaaaaaaaaacaaaaaaaeaaagaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafakaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeia
aeaaapjabpaaaaacafaaafiaafaaapjaaeaaaaaeaaaaadoaadaaoejaacaaoeka
acaaookaaeaaaaaeaaaaamoaadaaeejaadaaeekaadaaoekaaeaaaaaeabaaadoa
adaaoejaaeaaoekaaeaaookaafaaaaadaaaaapiaaaaaffjaahaaoekaaeaaaaae
aaaaapiaagaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaakkja
aaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaappjaaaaaoeiaafaaaaadabaaabia
aaaaffiaafaaaakaafaaaaadabaaaiiaabaaaaiaakaaaakaafaaaaadabaaafia
aaaapeiaakaaaakaacaaaaadadaaadoaabaakkiaabaaomiaaeaaaaaeabaaamoa
aeaabejaabaabekaabaalekaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeiaabaaaaacacaaapoa
afaaoejappppaaaafdeieefckiacaaaaeaaaabaakkaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaaogikcaaaaaaaaaaa
afaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
agaaaaaakgiocaaaaaaaaaaaagaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadgaaaaafpccabaaaadaaaaaaegbobaaaafaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
aeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaabejfdeheomaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
kbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaa
ljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeo
aafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaakl
epfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaakeaaaaaaadaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"!!ARBfp1.0
PARAM c[1] = { program.local[0] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TXP R3.xyz, fragment.texcoord[2], texture[3], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R3.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R3.w, R3, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R3.w;
MUL R1, R0, R2.x;
ABS R2.x, R3.w;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R3.w, R0, c[0];
LG2 R1.x, R3.x;
LG2 R1.z, R3.z;
LG2 R1.y, R3.y;
ADD R1.xyz, -R1, fragment.texcoord[3];
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 21 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2
dcl t3.xyz
texldp r4, t2, s3
texld r2, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r3, v0.y, r0
mad r3, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r2, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r2, r3
add_pp r1, r1, -c0
mad_pp r0, r0.x, r1, c0
log_pp r2.x, r4.x
log_pp r2.z, r4.z
log_pp r2.y, r4.y
add_pp r2.xyz, -r2, t3
mul_pp r0.xyz, r0, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjhhmkdihcmdanejghebbkdkecehkkamaabaaaaaafeaeaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
daadaaaaeaaaaaaammaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaa
aagabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaa
adaaaaaaegaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaa
akbabaaaadaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaa
adaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaa
djaaaaahccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaaj
pcaabaaaaaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaa
aaaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaa
adaaaaaadcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaa
egiocaaaaaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaacpaaaaafhcaabaaaabaaaaaaegacbaaaabaaaaaa
aaaaaaaihcaabaaaabaaaaaaegacbaiaebaaaaaaabaaaaaaegbcbaaaafaaaaaa
diaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedaambcepjnmkicfgjfifojpemdkmdofmdabaaaaaaieagaaaaaeaaaaaa
daaaaaaafmacaaaajeafaaaafaagaaaaebgpgodjceacaaaaceacaaaaaaacpppp
oeabaaaaeaaaaaaaabaadeaaaaaaeaaaaaaaeaaaaeaaceaaaaaaeaaaaaaaaaaa
abababaaacacacaaadadadaaaaaaadaaabaaaaaaaaaaaaaaaaacppppbpaaaaac
aaaaaaiaaaaacplabpaaaaacaaaaaaiaabaacdlabpaaaaacaaaaaaiaacaaapla
bpaaaaacaaaaaaiaadaaaplabpaaaaacaaaaaaiaaeaaahlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkabpaaaaac
aaaaaajaadaiapkaagaaaaacaaaaaiiaadaapplaafaaaaadaaaaadiaaaaappia
adaaoelaabaaaaacabaacbiaaaaakklaabaaaaacabaacciaaaaapplaecaaaaad
aaaacpiaaaaaoeiaadaioekaecaaaaadabaacpiaabaaoeiaabaioekaecaaaaad
acaacpiaaaaaoelaaaaioekaecaaaaadadaacpiaabaaoelaacaioekaapaaaaac
aeaacbiaaaaaaaiaapaaaaacaeaacciaaaaaffiaapaaaaacaeaaceiaaaaakkia
acaaaaadaaaachiaaeaaoeibaeaaoelaafaaaaadabaaapiaabaaoeiaacaaffla
aeaaaaaeabaaapiaacaaoeiaacaaaalaabaaoeiaaeaaaaaeabaacpiaadaaoeia
acaakklaabaaoeiaacaaaaadaaaaaiiaacaafflaacaaaalaacaaaaadaaaaciia
aaaappiaacaakklaagaaaaacacaaabiaaaaappiaafaaaaadacaacpiaabaaoeia
acaaaaiaafaaaaadadaaabiaaaaappiaaaaappiafiaaaaaeabaacpiaadaaaaib
abaaoeiaacaaoeiabcaaaaaeacaacpiaaaaappiaabaaoeiaaaaaoekaafaaaaad
acaachiaaaaaoeiaacaaoeiaabaaaaacaaaicpiaacaaoeiappppaaaafdeieefc
daadaaaaeaaaaaaammaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaa
aagabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaa
adaaaaaaegaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaa
akbabaaaadaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaa
adaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaa
djaaaaahccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaaj
pcaabaaaaaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaa
aaaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaa
adaaaaaadcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaa
egiocaaaaaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaacpaaaaafhcaabaaaabaaaaaaegacbaaaabaaaaaa
aaaaaaaihcaabaaaabaaaaaaegacbaiaebaaaaaaabaaaaaaegbcbaaaafaaaaaa
diaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaabejfdeheoleaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [unity_LightmapFade]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TXP R5.xyz, fragment.texcoord[2], texture[3], 2D;
TEX R4, fragment.texcoord[3], texture[5], 2D;
TEX R3, fragment.texcoord[3], texture[4], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R5.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R5.w, R5, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R5.w;
MUL R1, R0, R2.x;
ABS R2.x, R5.w;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R5.w, R0, c[0];
DP4 R1.w, fragment.texcoord[4], fragment.texcoord[4];
MUL R2.xyz, R4.w, R4;
RSQ R1.w, R1.w;
RCP R1.w, R1.w;
MUL R2.xyz, R2, c[2].x;
MUL R1.xyz, R3.w, R3;
MAD R1.xyz, R1, c[2].x, -R2;
MAD_SAT R1.w, R1, c[1].z, c[1];
MAD R1.xyz, R1.w, R1, R2;
LG2 R2.x, R5.x;
LG2 R2.y, R5.y;
LG2 R2.z, R5.z;
ADD R1.xyz, -R2, R1;
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 32 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [unity_LightmapFade]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c2, 8.00000000, 0, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2
dcl t3.xy
dcl t4
texldp r6, t2, s3
texld r2, t3, s5
texld r3, t3, s4
texld r4, t1, s2
texld r1, t0, s0
mul_pp r2.xyz, r2.w, r2
mul_pp r2.xyz, r2, c2.x
mul_pp r3.xyz, r3.w, r3
mad_pp r3.xyz, r3, c2.x, -r2
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r5, v0.y, r0
mad r5, v0.x, r1, r5
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r4, v0.z, r4, r5
rcp_pp r1.x, r0.x
mul_pp r5, r4, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r4, r5
add_pp r4, r1, -c0
dp4 r1.x, t4, t4
rsq r1.x, r1.x
rcp r1.x, r1.x
mad_sat r1.x, r1, c1.z, c1.w
mad_pp r1.xyz, r1.x, r3, r2
mad_pp r0, r0.x, r4, c0
log_pp r2.x, r6.x
log_pp r2.y, r6.y
log_pp r2.z, r6.z
add_pp r1.xyz, -r2, r1
mul_pp r0.xyz, r0, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
ConstBuffer "$Globals" 160
Vector 48 [_Color]
Vector 128 [unity_LightmapFade]
BindCB  "$Globals" 0
"ps_4_0
eefiecedimighkcpjimpopgnnagfjcigddmmlfehabaaaaaapeafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaamfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapalaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcliaeaaaaeaaaaaaa
coabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaae
aahabaaaaeaaaaaaffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaagcbaaaad
pcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaadpcbabaaa
afaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaabbaaaaahbcaabaaa
aaaaaaaaegbobaaaafaaaaaaegbobaaaafaaaaaaelaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadccaaaalbcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaa
aaaaaaaaaiaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadiaaaaahccaabaaa
aaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaa
agajbaaaabaaaaaafgafbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
acaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaabaaaaaa
dkaabaaaabaaaaaaabeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaajhcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaah
dcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaaaeaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaacpaaaaaf
hcaabaaaabaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaiaebaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahpcaabaaaabaaaaaa
egaobaaaabaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajpcaabaaaabaaaaaa
egaobaaaacaaaaaaagbabaaaadaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaaj
pcaabaaaabaaaaaaegaobaaaacaaaaaakgbkbaaaadaaaaaaegaobaaaabaaaaaa
aaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaaaoaaaaahpcaabaaa
acaaaaaaegaobaaaabaaaaaapgapbaaaaaaaaaaadjaaaaahbcaabaaaadaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaaabaaaaaaagaabaaa
adaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaaaaaaaaajpcaabaaaabaaaaaa
egaobaaaabaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaadcaaaaakpcaabaaa
abaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
diaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
ConstBuffer "$Globals" 160
Vector 48 [_Color]
Vector 128 [unity_LightmapFade]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedihknbjbcammfjclkmolcgeebikhcifmnabaaaaaaciajaaaaaeaaaaaa
daaaaaaagaadaaaacaaiaaaapeaiaaaaebgpgodjciadaaaaciadaaaaaaacpppp
neacaaaafeaaaaaaacaadmaaaaaafeaaaaaafeaaagaaceaaaaaafeaaaaaaaaaa
abababaaacacacaaadadadaaaeaeaeaaafafafaaaaaaadaaabaaaaaaaaaaaaaa
aaaaaiaaabaaabaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaaaebaaaaaaaa
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaiaabaaapla
bpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaaplabpaaaaacaaaaaaia
aeaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaacaaaaaajaaeaiapka
bpaaaaacaaaaaajaafaiapkaajaaaaadaaaaaiiaaeaaoelaaeaaoelaahaaaaac
aaaaabiaaaaappiaagaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaadbiaaaaaaaia
abaakkkaabaappkaabaaaaacabaaadiaabaabllaagaaaaacaaaaaciaadaappla
afaaaaadacaaadiaaaaaffiaadaaoelaabaaaaacadaacbiaaaaakklaabaaaaac
adaacciaaaaapplaecaaaaadaeaacpiaabaaoeiaafaioekaecaaaaadabaacpia
abaaoeiaaeaioekaecaaaaadacaacpiaacaaoeiaadaioekaecaaaaadadaacpia
adaaoeiaabaioekaecaaaaadafaacpiaaaaaoelaaaaioekaecaaaaadagaacpia
abaaoelaacaioekaafaaaaadacaaciiaaeaappiaacaaaakaafaaaaadaaaacoia
aeaabliaacaappiaafaaaaadabaaciiaabaappiaacaaaakaaeaaaaaeabaachia
abaappiaabaaoeiaaaaablibaeaaaaaeaaaachiaaaaaaaiaabaaoeiaaaaablia
apaaaaacabaacbiaacaaaaiaapaaaaacabaacciaacaaffiaapaaaaacabaaceia
acaakkiaacaaaaadaaaachiaaaaaoeiaabaaoeibafaaaaadabaaapiaadaaoeia
acaafflaaeaaaaaeabaaapiaafaaoeiaacaaaalaabaaoeiaaeaaaaaeabaacpia
agaaoeiaacaakklaabaaoeiaacaaaaadaaaaaiiaacaafflaacaaaalaacaaaaad
aaaaciiaaaaappiaacaakklaagaaaaacacaaabiaaaaappiaafaaaaadacaacpia
abaaoeiaacaaaaiaafaaaaadadaaabiaaaaappiaaaaappiafiaaaaaeabaacpia
adaaaaibabaaoeiaacaaoeiabcaaaaaeacaacpiaaaaappiaabaaoeiaaaaaoeka
afaaaaadacaachiaaaaaoeiaacaaoeiaabaaaaacaaaicpiaacaaoeiappppaaaa
fdeieefcliaeaaaaeaaaaaaacoabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaad
aagabaaaafaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaafibiaaaeaahabaaa
afaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaa
aeaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
aeaaaaaabbaaaaahbcaabaaaaaaaaaaaegbobaaaafaaaaaaegbobaaaafaaaaaa
elaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadccaaaalbcaabaaaaaaaaaaa
akaabaaaaaaaaaaackiacaaaaaaaaaaaaiaaaaaadkiacaaaaaaaaaaaaiaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaafaaaaaaaagabaaa
afaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaeb
diaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaafgafbaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaa
diaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdcaaaaak
hcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaajgahbaiaebaaaaaa
aaaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
jgahbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaa
aagabaaaadaaaaaacpaaaaafhcaabaaaabaaaaaaegacbaaaabaaaaaaaaaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaiaebaaaaaaabaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaaegaobaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaa
aagabaaaacaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaakgbkbaaa
adaaaaaaegaobaaaabaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaa
akbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaa
adaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaabaaaaaapgapbaaaaaaaaaaa
djaaaaahbcaabaaaadaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaaj
pcaabaaaabaaaaaaagaabaaaadaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaa
aaaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaaaaaaaaaa
adaaaaaadcaaaaakpcaabaaaabaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaa
egiocaaaaaaaaaaaadaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab
ejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
lmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaalmaaaaaaadaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamamaaaamfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaa
lmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TXP R4.xyz, fragment.texcoord[2], texture[3], 2D;
TEX R3, fragment.texcoord[3], texture[4], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R4.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R4.w, R4, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R4.w;
MUL R1, R0, R2.x;
ABS R2.x, R4.w;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R4.w, R0, c[0];
MUL R1.xyz, R3.w, R3;
LG2 R2.x, R4.x;
LG2 R2.z, R4.z;
LG2 R2.y, R4.y;
MAD R1.xyz, R1, c[1].x, -R2;
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 23 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c1, 8.00000000, 0, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2
dcl t3.xy
texldp r5, t2, s3
texld r2, t3, s4
texld r3, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
mul_pp r2.xyz, r2.w, r2
texld r0, r0, s1
mul r4, v0.y, r0
mad r4, v0.x, r1, r4
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r3, v0.z, r3, r4
rcp_pp r1.x, r0.x
mul_pp r4, r3, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r3, r4
add_pp r1, r1, -c0
mad_pp r0, r0.x, r1, c0
log_pp r3.x, r5.x
log_pp r3.z, r5.z
log_pp r3.y, r5.y
mad_pp r2.xyz, r2, c1.x, -r3
mul_pp r0.xyz, r0, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 160
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjjjpopbjceheoknaadlelnpahbfdmehfabaaaaaaliaeaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaknaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
jeadaaaaeaaaaaaaofaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaa
aeaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaa
egaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaa
adaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaa
aoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaah
ccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaa
aaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaaj
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaa
dcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
aaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaa
aagabaaaadaaaaaacpaaaaafhcaabaaaabaaaaaaegacbaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaogbkbaaaacaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaa
diaaaaahicaabaaaabaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaaebdcaaaaak
hcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaaacaaaaaaegacbaiaebaaaaaa
abaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 160
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedgmlgljdekdoklbfjnionbhemndfmojiiabaaaaaadeahaaaaaeaaaaaa
daaaaaaakiacaaaaeeagaaaaaaahaaaaebgpgodjhaacaaaahaacaaaaaaacpppp
cmacaaaaeeaaaaaaabaadiaaaaaaeeaaaaaaeeaaafaaceaaaaaaeeaaaaaaaaaa
abababaaacacacaaadadadaaaeaeaeaaaaaaadaaabaaaaaaaaaaaaaaaaacpppp
fbaaaaafabaaapkaaaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaacplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaac
aaaaaaiaadaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapka
bpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaacaaaaaaja
aeaiapkaabaaaaacaaaaadiaabaabllaagaaaaacaaaaaeiaadaapplaafaaaaad
abaaadiaaaaakkiaadaaoelaabaaaaacacaacbiaaaaakklaabaaaaacacaaccia
aaaapplaecaaaaadaaaacpiaaaaaoeiaaeaioekaecaaaaadabaacpiaabaaoeia
adaioekaecaaaaadacaacpiaacaaoeiaabaioekaecaaaaadadaacpiaaaaaoela
aaaioekaecaaaaadaeaacpiaabaaoelaacaioekaafaaaaadaaaaciiaaaaappia
abaaaakaapaaaaacafaacbiaabaaaaiaapaaaaacafaacciaabaaffiaapaaaaac
afaaceiaabaakkiaaeaaaaaeaaaachiaaaaappiaaaaaoeiaafaaoeibafaaaaad
abaaapiaacaaoeiaacaafflaaeaaaaaeabaaapiaadaaoeiaacaaaalaabaaoeia
aeaaaaaeabaacpiaaeaaoeiaacaakklaabaaoeiaacaaaaadaaaaaiiaacaaffla
acaaaalaacaaaaadaaaaciiaaaaappiaacaakklaagaaaaacacaaabiaaaaappia
afaaaaadacaacpiaabaaoeiaacaaaaiaafaaaaadadaaabiaaaaappiaaaaappia
fiaaaaaeabaacpiaadaaaaibabaaoeiaacaaoeiabcaaaaaeacaacpiaaaaappia
abaaoeiaaaaaoekaafaaaaadacaachiaaaaaoeiaacaaoeiaabaaaaacaaaicpia
acaaoeiappppaaaafdeieefcjeadaaaaeaaaaaaaofaaaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaa
aeaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagcbaaaadlcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaa
adaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
adaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgbkbaaaadaaaaaaegaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaa
bkbabaaaadaaaaaaakbabaaaadaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaa
abaaaaaackbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaa
agaabaaaabaaaaaadjaaaaahccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaa
aaaaaaaadhaaaaajpcaabaaaaaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaa
egaobaaaaaaaaaaaaaaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaia
ebaaaaaaaaaaaaaaadaaaaaadcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaaeaaaaaapgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaa
abaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaacpaaaaafhcaabaaaabaaaaaa
egacbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaacaaaaaaeghobaaa
aeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaacaaaaaa
abeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaaegacbaiaebaaaaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaa
doaaaaabejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaknaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"!!ARBfp1.0
PARAM c[1] = { program.local[0] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TXP R3.xyz, fragment.texcoord[2], texture[3], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R3.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R3.w, R3, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R3.w;
MUL R1, R0, R2.x;
ABS R2.x, R3.w;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R3.w, R0, c[0];
ADD R1.xyz, R3, fragment.texcoord[3];
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 18 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2
dcl t3.xyz
texldp r4, t2, s3
texld r2, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mul r3, v0.y, r0
mad r3, v0.x, r1, r3
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r2, v0.z, r2, r3
rcp_pp r1.x, r0.x
mul_pp r3, r2, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r2, r3
add_pp r1, r1, -c0
mad_pp r0, r0.x, r1, c0
add_pp r2.xyz, r4, t3
mul_pp r0.xyz, r0, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedgngnlnakedimkpdafakclmbookakbkniabaaaaaadmaeaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaakeaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
biadaaaaeaaaaaaamgaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaad
hcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaa
aagabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaa
adaaaaaaegaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaa
akbabaaaadaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaa
adaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaa
djaaaaahccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaaj
pcaabaaaaaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaa
aaaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaa
adaaaaaadcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaa
egiocaaaaaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaa
adaaaaaaaagabaaaadaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
egbcbaaaafaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
ConstBuffer "$Globals" 128
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedifbdlbfmnfhdmgkadggjbflfkemeigeoabaaaaaaeiagaaaaaeaaaaaa
daaaaaaadiacaaaafiafaaaabeagaaaaebgpgodjaaacaaaaaaacaaaaaaacpppp
maabaaaaeaaaaaaaabaadeaaaaaaeaaaaaaaeaaaaeaaceaaaaaaeaaaaaaaaaaa
abababaaacacacaaadadadaaaaaaadaaabaaaaaaaaaaaaaaaaacppppbpaaaaac
aaaaaaiaaaaacplabpaaaaacaaaaaaiaabaacdlabpaaaaacaaaaaaiaacaaapla
bpaaaaacaaaaaaiaadaaaplabpaaaaacaaaaaaiaaeaaahlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkabpaaaaac
aaaaaajaadaiapkaabaaaaacaaaacbiaaaaakklaabaaaaacaaaacciaaaaappla
agaaaaacaaaaaeiaadaapplaafaaaaadabaaadiaaaaakkiaadaaoelaecaaaaad
aaaacpiaaaaaoeiaabaioekaecaaaaadacaacpiaaaaaoelaaaaioekaecaaaaad
adaacpiaabaaoelaacaioekaecaaaaadabaacpiaabaaoeiaadaioekaafaaaaad
aaaaapiaaaaaoeiaacaafflaaeaaaaaeaaaaapiaacaaoeiaacaaaalaaaaaoeia
aeaaaaaeaaaacpiaadaaoeiaacaakklaaaaaoeiaacaaaaadabaaaiiaacaaffla
acaaaalaacaaaaadabaaciiaabaappiaacaakklaagaaaaacacaaabiaabaappia
afaaaaadacaacpiaaaaaoeiaacaaaaiaafaaaaadadaaabiaabaappiaabaappia
fiaaaaaeaaaacpiaadaaaaibaaaaoeiaacaaoeiabcaaaaaeacaacpiaabaappia
aaaaoeiaaaaaoekaacaaaaadaaaachiaabaaoeiaaeaaoelaafaaaaadacaachia
aaaaoeiaacaaoeiaabaaaaacaaaicpiaacaaoeiappppaaaafdeieefcbiadaaaa
eaaaaaaamgaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaadhcbabaaa
afaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaa
egaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaa
adaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaa
aoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaah
ccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaa
aaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaaj
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaa
dcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
aaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaa
aagabaaaadaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegbcbaaa
afaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaabejfdeheoleaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadadaaaaknaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [unity_LightmapFade]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R4, fragment.texcoord[3], texture[5], 2D;
TEX R3, fragment.texcoord[3], texture[4], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TXP R5.xyz, fragment.texcoord[2], texture[3], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R5.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R5.w, R5, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R5.w;
MUL R1, R0, R2.x;
ABS R2.x, R5.w;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R5.w, R0, c[0];
DP4 R1.w, fragment.texcoord[4], fragment.texcoord[4];
MUL R2.xyz, R4.w, R4;
RSQ R1.w, R1.w;
RCP R1.w, R1.w;
MUL R2.xyz, R2, c[2].x;
MUL R1.xyz, R3.w, R3;
MAD R1.xyz, R1, c[2].x, -R2;
MAD_SAT R1.w, R1, c[1].z, c[1];
MAD R1.xyz, R1.w, R1, R2;
ADD R1.xyz, R5, R1;
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 29 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [unity_LightmapFade]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
def c2, 8.00000000, 0, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2
dcl t3.xy
dcl t4
texldp r6, t2, s3
texld r2, t3, s5
texld r3, t3, s4
texld r4, t1, s2
texld r1, t0, s0
mul_pp r2.xyz, r2.w, r2
mul_pp r2.xyz, r2, c2.x
mul_pp r3.xyz, r3.w, r3
mov r0.y, t0.w
mov r0.x, t0.z
mad_pp r3.xyz, r3, c2.x, -r2
texld r0, r0, s1
mul r5, v0.y, r0
mad r5, v0.x, r1, r5
add r0.x, v0, v0.y
add r0.x, r0, v0.z
mad r4, v0.z, r4, r5
rcp_pp r1.x, r0.x
mul_pp r5, r4, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r4, r5
add_pp r4, r1, -c0
dp4 r1.x, t4, t4
rsq r1.x, r1.x
rcp r1.x, r1.x
mad_sat r1.x, r1, c1.z, c1.w
mad_pp r1.xyz, r1.x, r3, r2
mad_pp r0, r0.x, r4, c0
add_pp r1.xyz, r6, r1
mul_pp r0.xyz, r0, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
ConstBuffer "$Globals" 160
Vector 48 [_Color]
Vector 128 [unity_LightmapFade]
BindCB  "$Globals" 0
"ps_4_0
eefiecedpfpmbekhcfjeeehfoaijhinmobbkjmllabaaaaaanmafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaamfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapalaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apapaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefckaaeaaaaeaaaaaaa
ciabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaae
aahabaaaaeaaaaaaffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaagcbaaaad
pcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagcbaaaadpcbabaaa
afaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaabbaaaaahbcaabaaa
aaaaaaaaegbobaaaafaaaaaaegbobaaaafaaaaaaelaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadccaaaalbcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaa
aaaaaaaaaiaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadiaaaaahccaabaaa
aaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahocaabaaaaaaaaaaa
agajbaaaabaaaaaafgafbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
acaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaabaaaaaa
dkaabaaaabaaaaaaabeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaabaaaaaajgahbaiaebaaaaaaaaaaaaaadcaaaaajhcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaah
dcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaaaeaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaaaaaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
pcaabaaaabaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
pcaabaaaabaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaaegaobaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaakgbkbaaaadaaaaaa
egaobaaaabaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaaadaaaaaaakbabaaa
adaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaackbabaaaadaaaaaa
aoaaaaahpcaabaaaacaaaaaaegaobaaaabaaaaaapgapbaaaaaaaaaaadjaaaaah
bcaabaaaadaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaa
abaaaaaaagaabaaaadaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaaaaaaaaaj
pcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaa
dcaaaaakpcaabaaaabaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
ConstBuffer "$Globals" 160
Vector 48 [_Color]
Vector 128 [unity_LightmapFade]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedhiiiplefgemblnfbdamdigfnomjdpbmaabaaaaaaomaiaaaaaeaaaaaa
daaaaaaadmadaaaaoeahaaaaliaiaaaaebgpgodjaeadaaaaaeadaaaaaaacpppp
laacaaaafeaaaaaaacaadmaaaaaafeaaaaaafeaaagaaceaaaaaafeaaaaaaaaaa
abababaaacacacaaadadadaaaeaeaeaaafafafaaaaaaadaaabaaaaaaaaaaaaaa
aaaaaiaaabaaabaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaaaebaaaaaaaa
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacplabpaaaaacaaaaaaiaabaaapla
bpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaaplabpaaaaacaaaaaaia
aeaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaacaaaaaajaaeaiapka
bpaaaaacaaaaaajaafaiapkaajaaaaadaaaaaiiaaeaaoelaaeaaoelaahaaaaac
aaaaabiaaaaappiaagaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaadbiaaaaaaaia
abaakkkaabaappkaabaaaaacabaaadiaabaabllaagaaaaacaaaaaciaadaappla
afaaaaadacaaadiaaaaaffiaadaaoelaabaaaaacadaacbiaaaaakklaabaaaaac
adaacciaaaaapplaecaaaaadaeaacpiaabaaoeiaafaioekaecaaaaadabaacpia
abaaoeiaaeaioekaecaaaaadacaacpiaacaaoeiaadaioekaecaaaaadadaacpia
adaaoeiaabaioekaecaaaaadafaacpiaaaaaoelaaaaioekaecaaaaadagaacpia
abaaoelaacaioekaafaaaaadacaaciiaaeaappiaacaaaakaafaaaaadaaaacoia
aeaabliaacaappiaafaaaaadabaaciiaabaappiaacaaaakaaeaaaaaeabaachia
abaappiaabaaoeiaaaaablibaeaaaaaeaaaachiaaaaaaaiaabaaoeiaaaaablia
acaaaaadaaaachiaaaaaoeiaacaaoeiaafaaaaadabaaapiaadaaoeiaacaaffla
aeaaaaaeabaaapiaafaaoeiaacaaaalaabaaoeiaaeaaaaaeabaacpiaagaaoeia
acaakklaabaaoeiaacaaaaadaaaaaiiaacaafflaacaaaalaacaaaaadaaaaciia
aaaappiaacaakklaagaaaaacacaaabiaaaaappiaafaaaaadacaacpiaabaaoeia
acaaaaiaafaaaaadadaaabiaaaaappiaaaaappiafiaaaaaeabaacpiaadaaaaib
abaaoeiaacaaoeiabcaaaaaeacaacpiaaaaappiaabaaoeiaaaaaoekaafaaaaad
acaachiaaaaaoeiaacaaoeiaabaaaaacaaaicpiaacaaoeiappppaaaafdeieefc
kaaeaaaaeaaaaaaaciabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaa
afaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaafibiaaaeaahabaaaaeaaaaaaffffaaaafibiaaaeaahabaaaafaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaad
mcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaa
gcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaa
bbaaaaahbcaabaaaaaaaaaaaegbobaaaafaaaaaaegbobaaaafaaaaaaelaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadccaaaalbcaabaaaaaaaaaaaakaabaaa
aaaaaaaackiacaaaaaaaaaaaaiaaaaaadkiacaaaaaaaaaaaaiaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaa
diaaaaahccaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaah
ocaabaaaaaaaaaaaagajbaaaabaaaaaafgafbaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaacaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaah
icaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdcaaaaakhcaabaaa
abaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaajgahbaiaebaaaaaaaaaaaaaa
dcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaajgahbaaa
aaaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaaaeaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaa
adaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaaagbabaaaadaaaaaa
egaobaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaacaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaa
kgbkbaaaadaaaaaaegaobaaaabaaaaaaaaaaaaahicaabaaaaaaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
ckbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaabaaaaaapgapbaaa
aaaaaaaadjaaaaahbcaabaaaadaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dhaaaaajpcaabaaaabaaaaaaagaabaaaadaaaaaaegaobaaaacaaaaaaegaobaaa
abaaaaaaaaaaaaajpcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaiaebaaaaaa
aaaaaaaaadaaaaaadcaaaaakpcaabaaaabaaaaaapgapbaaaaaaaaaaaegaobaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
doaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaamfaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapahaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apalaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R2, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R3, fragment.texcoord[3], texture[4], 2D;
TEX R0, fragment.texcoord[1], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TXP R4.xyz, fragment.texcoord[2], texture[3], 2D;
MUL R2, fragment.color.primary.y, R2;
MAD R1, fragment.color.primary.x, R1, R2;
ADD R4.w, fragment.color.primary.x, fragment.color.primary.y;
ADD R4.w, R4, fragment.color.primary.z;
MAD R0, fragment.color.primary.z, R0, R1;
RCP R2.x, R4.w;
MUL R1, R0, R2.x;
ABS R2.x, R4.w;
CMP R0, -R2.x, R1, R0;
ADD R0, R0, -c[0];
MAD R0, R4.w, R0, c[0];
MUL R1.xyz, R3.w, R3;
MAD R1.xyz, R1, c[1].x, R4;
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1;
END
# 20 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c1, 8.00000000, 0, 0, 0
dcl t0
dcl t1.xy
dcl v0.xyz
dcl t2
dcl t3.xy
texldp r5, t2, s3
texld r2, t3, s4
texld r3, t1, s2
texld r1, t0, s0
mov r0.y, t0.w
mov r0.x, t0.z
mul_pp r2.xyz, r2.w, r2
mad_pp r2.xyz, r2, c1.x, r5
texld r0, r0, s1
mul r4, v0.y, r0
mad r4, v0.x, r1, r4
add r0.x, v0, v0.y
add r0.x, r0, v0.z
rcp_pp r1.x, r0.x
mad r3, v0.z, r3, r4
mul_pp r4, r3, r1.x
abs_pp r1.x, r0
cmp_pp r1, -r1.x, r3, r4
add_pp r1, r1, -c0
mad_pp r0, r0.x, r1, c0
mul_pp r0.xyz, r0, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 160
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedoolifgldodjnkhcfchgepdjhikgfnmbiabaaaaaakaaeaaaaadaaaaaa
cmaaaaaaoiaaaaaabmabaaaaejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaknaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefc
hmadaaaaeaaaaaaanpaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaa
aeaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaaegaobaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaadaaaaaa
egaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaaadaaaaaaakbabaaa
adaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaackbabaaaadaaaaaa
aoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaadjaaaaah
ccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaadhaaaaajpcaabaaa
aaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaaj
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaaadaaaaaa
dcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
aaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaa
aagabaaaadaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaacaaaaaaeghobaaa
aeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaaacaaaaaa
abeaaaaaaaaaaaebdcaaaaajhcaabaaaabaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_Texture1] 2D 0
SetTexture 1 [_Texture2] 2D 1
SetTexture 2 [_Texture3] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 160
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedkbnpaciecfkhiijjjmcegagkfdjhbfgfabaaaaaapiagaaaaaeaaaaaa
daaaaaaaieacaaaaaiagaaaameagaaaaebgpgodjemacaaaaemacaaaaaaacpppp
aiacaaaaeeaaaaaaabaadiaaaaaaeeaaaaaaeeaaafaaceaaaaaaeeaaaaaaaaaa
abababaaacacacaaadadadaaaeaeaeaaaaaaadaaabaaaaaaaaaaaaaaaaacpppp
fbaaaaafabaaapkaaaaaaaebaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaacplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaac
aaaaaaiaadaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapka
bpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkabpaaaaacaaaaaaja
aeaiapkaagaaaaacaaaaaiiaadaapplaafaaaaadaaaaadiaaaaappiaadaaoela
abaaaaacabaaadiaabaabllaabaaaaacacaacbiaaaaakklaabaaaaacacaaccia
aaaapplaecaaaaadaaaacpiaaaaaoeiaadaioekaecaaaaadabaacpiaabaaoeia
aeaioekaecaaaaadacaacpiaacaaoeiaabaioekaecaaaaadadaacpiaaaaaoela
aaaioekaecaaaaadaeaacpiaabaaoelaacaioekaafaaaaadaaaaciiaabaappia
abaaaakaaeaaaaaeaaaachiaaaaappiaabaaoeiaaaaaoeiaafaaaaadabaaapia
acaaoeiaacaafflaaeaaaaaeabaaapiaadaaoeiaacaaaalaabaaoeiaaeaaaaae
abaacpiaaeaaoeiaacaakklaabaaoeiaacaaaaadaaaaaiiaacaafflaacaaaala
acaaaaadaaaaciiaaaaappiaacaakklaagaaaaacacaaabiaaaaappiaafaaaaad
acaacpiaabaaoeiaacaaaaiaafaaaaadadaaabiaaaaappiaaaaappiafiaaaaae
abaacpiaadaaaaibabaaoeiaacaaoeiabcaaaaaeacaacpiaaaaappiaabaaoeia
aaaaoekaafaaaaadacaachiaaaaaoeiaacaaoeiaabaaaaacaaaicpiaacaaoeia
ppppaaaafdeieefchmadaaaaeaaaaaaanpaaaaaafjaaaaaeegiocaaaaaaaaaaa
aeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaad
aagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
fibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaa
fibiaaaeaahabaaaaeaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gcbaaaadlcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaa
efaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaadaaaaaa
egaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
acaaaaaaaagabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgbkbaaaadaaaaaaegaobaaaaaaaaaaaaaaaaaahbcaabaaaabaaaaaabkbabaaa
adaaaaaaakbabaaaadaaaaaaaaaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaa
ckbabaaaadaaaaaaaoaaaaahpcaabaaaacaaaaaaegaobaaaaaaaaaaaagaabaaa
abaaaaaadjaaaaahccaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaaa
dhaaaaajpcaabaaaaaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaa
aaaaaaaaaaaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaiaebaaaaaa
aaaaaaaaadaaaaaadcaaaaakpcaabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaa
aeaaaaaapgbpbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaa
eghobaaaadaaaaaaaagabaaaadaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaa
acaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaabaaaaaa
dkaabaaaacaaaaaaabeaaaaaaaaaaaebdcaaaaajhcaabaaaabaaaaaapgapbaaa
abaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadiaaaaahhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
aaaaaaaadoaaaaabejfdeheoleaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaknaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback "Diffuse"
}