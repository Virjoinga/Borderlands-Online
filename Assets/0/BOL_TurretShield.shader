³ªShader "BOL/FX/TurretShield" {
Properties {
 _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _FresnelParaH ("Fresnel H Para", Float) = 1
 _FresnelParaV ("Fresnel V Para", Float) = 1
 _NoiseTex ("Noise Tex", 2D) = "white" {}
 _NoiseScale ("Noise Scale", Float) = 1
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZTest Less
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  AlphaTest Greater 0.01
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_Scale]
Vector 15 [_MainTex_ST]
Vector 16 [_NoiseTex_ST]
"!!ARBvp1.0
PARAM c[17] = { { 1 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MOV R1.w, c[0].x;
MOV R1.xyz, c[13];
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MAD result.texcoord[1].xyz, R0, c[14].w, -vertex.position;
MOV result.color, vertex.color;
MOV result.texcoord[2].xyz, vertex.normal;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[4].z, vertex.position, c[7];
DP4 result.texcoord[4].y, vertex.position, c[6];
DP4 result.texcoord[4].x, vertex.position, c[5];
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_Scale]
Vector 14 [_MainTex_ST]
Vector 15 [_NoiseTex_ST]
"vs_2_0
def c16, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
dcl_normal0 v3
mov r1.w, c16.x
mov r1.xyz, c12
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mad oT1.xyz, r0, c13.w, -v0
mov oD0, v1
mov oT2.xyz, v3
mad oT0.zw, v2.xyxy, c15.xyxy, c15
mad oT0.xy, v2, c14, c14.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oT4.z, v0, c6
dp4 oT4.y, v0, c5
dp4 oT4.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
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
eefiecedfcigbnhgamkpomibfpjjmhbheanpkcilabaaaaaanaaeaaaaadaaaaaa
cmaaaaaalmaaaaaajaabaaaaejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdej
feejepeoaaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheo
mmaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaamcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefcdiadaaaaeaaaabaamoaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
pcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaafpaaaaadhcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaagaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaa
dcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaa
ogikcaaaaaaaaaaaacaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaacaaaaaa
agiecaaaaaaaaaaaadaaaaaakgiocaaaaaaaaaaaadaaaaaadiaaaaajhcaabaaa
aaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaacaaaaaabdaaaaaadcaaaaalhccabaaaadaaaaaa
egacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
dgaaaaafhccabaaaaeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
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
eefiecedaoffoiidianbkbgodojjiglibjknmehjabaaaaaammagaaaaaeaaaaaa
daaaaaaaciacaaaagiafaaaapiafaaaaebgpgodjpaabaaaapaabaaaaaaacpopp
jiabaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaacaa
acaaabaaaaaaaaaaabaaaeaaabaaadaaaaaaaaaaacaaaaaaaeaaaeaaaaaaaaaa
acaaamaaajaaaiaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapja
bpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadia
adaaapjaaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaaeaaaaaeabaaamoa
acaaeejaacaaeekaacaaoekaabaaaaacaaaaahiaadaaoekaafaaaaadabaaahia
aaaaffiaanaaoekaaeaaaaaeaaaaaliaamaakekaaaaaaaiaabaakeiaaeaaaaae
aaaaahiaaoaaoekaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeiaapaaoeka
aeaaaaaeacaaahoaaaaaoeiabaaappkaaaaaoejbafaaaaadaaaaahiaaaaaffja
ajaaoekaaeaaaaaeaaaaahiaaiaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
akaaoekaaaaakkjaaaaaoeiaaeaaaaaeafaaahoaalaaoekaaaaappjaaaaaoeia
afaaaaadaaaaapiaaaaaffjaafaaoekaaeaaaaaeaaaaapiaaeaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
ahaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacaaaaapoaabaaoejaabaaaaacadaaahoa
adaaoejappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaa
fpaaaaaddcbabaaaacaaaaaafpaaaaadhcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
agaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaa
acaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaacaaaaaaagiecaaaaaaaaaaa
adaaaaaakgiocaaaaaaaaaaaadaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaa
egiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
dcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaacaaaaaabdaaaaaadcaaaaalhccabaaaadaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaadgaaaaafhccabaaa
aeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hccabaaaagaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaadoaaaaabejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
iaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdejfeejepeo
aaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheommaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
mcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaaedepemep
fcaafeeffiedepepfceeaakl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [unity_Scale]
Vector 15 [_MainTex_ST]
Vector 16 [_NoiseTex_ST]
"!!ARBvp1.0
PARAM c[17] = { { 1 },
		state.matrix.mvp,
		program.local[5..16] };
TEMP R0;
TEMP R1;
MOV R1.w, c[0].x;
MOV R1.xyz, c[13];
DP4 R0.z, R1, c[11];
DP4 R0.x, R1, c[9];
DP4 R0.y, R1, c[10];
MAD result.texcoord[1].xyz, R0, c[14].w, -vertex.position;
MOV result.color, vertex.color;
MOV result.texcoord[2].xyz, vertex.normal;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[16].xyxy, c[16];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[15], c[15].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.texcoord[4].z, vertex.position, c[7];
DP4 result.texcoord[4].y, vertex.position, c[6];
DP4 result.texcoord[4].x, vertex.position, c[5];
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [unity_Scale]
Vector 14 [_MainTex_ST]
Vector 15 [_NoiseTex_ST]
"vs_2_0
def c16, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
dcl_normal0 v3
mov r1.w, c16.x
mov r1.xyz, c12
dp4 r0.z, r1, c10
dp4 r0.x, r1, c8
dp4 r0.y, r1, c9
mad oT1.xyz, r0, c13.w, -v0
mov oD0, v1
mov oT2.xyz, v3
mad oT0.zw, v2.xyxy, c15.xyxy, c15
mad oT0.xy, v2, c14, c14.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oT4.z, v0, c6
dp4 oT4.y, v0, c5
dp4 oT4.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
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
eefiecedfcigbnhgamkpomibfpjjmhbheanpkcilabaaaaaanaaeaaaaadaaaaaa
cmaaaaaalmaaaaaajaabaaaaejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdej
feejepeoaaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheo
mmaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaamcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefcdiadaaaaeaaaabaamoaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaa
fjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
pcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaafpaaaaadhcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaagaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaa
dcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaa
ogikcaaaaaaaaaaaacaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaacaaaaaa
agiecaaaaaaaaaaaadaaaaaakgiocaaaaaaaaaaaadaaaaaadiaaaaajhcaabaaa
aaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaal
hcaabaaaaaaaaaaaegiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaacaaaaaabdaaaaaadcaaaaalhccabaaaadaaaaaa
egacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
dgaaaaafhccabaaaaeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
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
eefiecedaoffoiidianbkbgodojjiglibjknmehjabaaaaaammagaaaaaeaaaaaa
daaaaaaaciacaaaagiafaaaapiafaaaaebgpgodjpaabaaaapaabaaaaaaacpopp
jiabaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaacaa
acaaabaaaaaaaaaaabaaaeaaabaaadaaaaaaaaaaacaaaaaaaeaaaeaaaaaaaaaa
acaaamaaajaaaiaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapja
bpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadia
adaaapjaaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaaeaaaaaeabaaamoa
acaaeejaacaaeekaacaaoekaabaaaaacaaaaahiaadaaoekaafaaaaadabaaahia
aaaaffiaanaaoekaaeaaaaaeaaaaaliaamaakekaaaaaaaiaabaakeiaaeaaaaae
aaaaahiaaoaaoekaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeiaapaaoeka
aeaaaaaeacaaahoaaaaaoeiabaaappkaaaaaoejbafaaaaadaaaaahiaaaaaffja
ajaaoekaaeaaaaaeaaaaahiaaiaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
akaaoekaaaaakkjaaaaaoeiaaeaaaaaeafaaahoaalaaoekaaaaappjaaaaaoeia
afaaaaadaaaaapiaaaaaffjaafaaoekaaeaaaaaeaaaaapiaaeaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
ahaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacaaaaapoaabaaoejaabaaaaacadaaahoa
adaaoejappppaaaafdeieefcdiadaaaaeaaaabaamoaaaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaa
fpaaaaaddcbabaaaacaaaaaafpaaaaadhcbabaaaadaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaa
agaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaa
acaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaaacaaaaaaagiecaaaaaaaaaaa
adaaaaaakgiocaaaaaaaaaaaadaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaa
egiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
dcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaacaaaaaabdaaaaaadcaaaaalhccabaaaadaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaadgaaaaafhccabaaa
aeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaacaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaacaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hccabaaaagaaaaaaegiccaaaacaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaadoaaaaabejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
iaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdejfeejepeo
aaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheommaaaaaa
ahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
lmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaa
mcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaaedepemep
fcaafeeffiedepepfceeaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaH]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.xyz, fragment.texcoord[0].zwzw, texture[0], 2D;
MOV R1.xyz, c[3];
ADD R2.xyz, -R1, c[4];
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MAD R0.xyz, R0, c[2].x, fragment.texcoord[4];
ADD R1.xyz, -R1, c[5];
ADD R0.xyz, R0, -c[3];
MUL R2.xyz, R0.w, R2;
DP3 R0.y, R2, R0;
DP3 R0.x, R1, R2;
SLT R0.x, R0, R0.y;
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.y, R1.y;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R2.xyz, R1.y, fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[1];
DP3 R1.x, R1, R2;
ABS R1.x, R1;
ADD R2.x, -R1, c[6].y;
MUL R1, fragment.color.primary, c[0];
KIL -R0.x;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MUL R0, R1, R0;
MUL R0, R0, c[6].x;
POW R1.x, R2.x, c[1].x;
MUL result.color.w, R0, R1.x;
MOV result.color.xyz, R0;
END
# 29 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaH]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 2.00000000, 0
dcl v0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t4.xyz
mov r1.xyz, c4
mov r3.xyz, c5
add r1.xyz, -c3, r1
mov r0.y, t0.w
mov r0.x, t0.z
add r3.xyz, -c3, r3
texld r0, r0, s0
mad r0.xyz, r0, c2.x, t4
add r2.xyz, r0, -c3
dp3 r0.x, r1, r1
rsq r0.x, r0.x
mul r1.xyz, r0.x, r1
dp3 r0.x, r1, r3
dp3 r1.x, r2, r1
add r0.x, -r1, r0
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
dp3 r2.x, t2, t2
rsq r2.x, r2.x
mul r2.xyz, r2.x, t2
texkill r0.xyzw
texld r1, t0, s1
dp3 r0.x, t1, t1
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
dp3 r0.x, r0, r2
abs r0.x, r0
add r0.x, -r0, c6.y
pow r2.x, r0.x, c1.x
mul r0, v0, c0
mul r0, r0, r1
mul r1, r0, c6.z
mov r0.x, r2.x
mul r1.w, r1, r0.x
mov_pp oC0, r1
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 64 [_FresnelParaH]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmalbjgcfjhblppppjhfnkgkdnoahmgppabaaaaaabeafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaamcaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcniadaaaaeaaaaaaa
pgaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaad
hcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
aaaaaaakhcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egacbaaaaaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaak
ocaabaaaaaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaa
ahaaaaaabaaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaa
dbaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaead
akaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaai
bcaabaaaaaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaa
diaaaaahiccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaaf
hccabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 64 [_FresnelParaH]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedjkiocpkilabajacgnjemhondcekcpkkjabaaaaaafiahaaaaaeaaaaaa
daaaaaaahaacaaaafaagaaaaceahaaaaebgpgodjdiacaaaadiacaaaaaaacpppp
peabaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaaaaeaaaeaaabaaaaaaaaaaaaacpppp
fbaaaaafafaaapkaaaaaaaiaaaaaialpaaaaiadpaaaaaaaabpaaaaacaaaaaaia
aaaaaplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaahlabpaaaaac
aaaaaaiaadaaahlabpaaaaacaaaaaaiaafaaahlabpaaaaacaaaaaajaaaaiapka
bpaaaaacaaaaaajaabaiapkaabaaaaacaaaaabiaabaakklaabaaaaacaaaaacia
abaapplaecaaaaadaaaaapiaaaaaoeiaabaioekaaeaaaaaeaaaaahiaaaaaoeia
abaakkkaafaaoelaacaaaaadaaaaahiaaaaaoeiaacaaoekbabaaaaacabaaahia
acaaoekaacaaaaadacaaahiaabaaoeibadaaoekaceaaaaacadaaahiaacaaoeia
aiaaaaadabaaaiiaaaaaoeiaadaaoeiaacaaaaadaaaaahiaabaaoeibaeaaoeka
aiaaaaadaaaaabiaaaaaoeiaadaaoeiaacaaaaadaaaaabiaabaappibaaaaaaia
fiaaaaaeaaaaapiaaaaaaaiaafaaaakaafaaffkaebaaaaabaaaaapiaceaaaaac
aaaaahiaacaaoelaceaaaaacabaaahiaadaaoelaaiaaaaadaaaaabiaaaaaoeia
abaaoeiacdaaaaacaaaacbiaaaaaaaiaacaaaaadaaaaabiaaaaaaaibafaakkka
caaaaaadabaacbiaaaaaaaiaabaaaakaafaaaaadaaaaapiaaaaaoelaaaaaoeka
acaaaaadaaaaapiaaaaaoeiaaaaaoeiaecaaaaadacaaapiaabaaoelaaaaioeka
afaaaaadaaaaapiaaaaaoeiaacaaoeiaafaaaaadaaaaciiaabaaaaiaaaaappia
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcniadaaaaeaaaaaaapgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaak
hcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaaaaaaaaaa
agaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegacbaaa
aaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaajhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaakocaabaaa
aaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaaahaaaaaa
baaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaadbaaaaah
bcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaeadakaabaaa
aaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaa
eeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaibcaabaaa
aaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaa
akiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaadiaaaaah
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaafhccabaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
mcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
agaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepep
fceeaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaH]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.xyz, fragment.texcoord[0].zwzw, texture[0], 2D;
MOV R1.xyz, c[3];
ADD R2.xyz, -R1, c[4];
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MAD R0.xyz, R0, c[2].x, fragment.texcoord[4];
ADD R1.xyz, -R1, c[5];
ADD R0.xyz, R0, -c[3];
MUL R2.xyz, R0.w, R2;
DP3 R0.y, R2, R0;
DP3 R0.x, R1, R2;
SLT R0.x, R0, R0.y;
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.y, R1.y;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R2.xyz, R1.y, fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[1];
DP3 R1.x, R1, R2;
ABS R1.x, R1;
ADD R2.x, -R1, c[6].y;
MUL R1, fragment.color.primary, c[0];
KIL -R0.x;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MUL R0, R1, R0;
MUL R0, R0, c[6].x;
POW R1.x, R2.x, c[1].x;
MUL result.color.w, R0, R1.x;
MOV result.color.xyz, R0;
END
# 29 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaH]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 2.00000000, 0
dcl v0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t4.xyz
mov r1.xyz, c4
mov r3.xyz, c5
add r1.xyz, -c3, r1
mov r0.y, t0.w
mov r0.x, t0.z
add r3.xyz, -c3, r3
texld r0, r0, s0
mad r0.xyz, r0, c2.x, t4
add r2.xyz, r0, -c3
dp3 r0.x, r1, r1
rsq r0.x, r0.x
mul r1.xyz, r0.x, r1
dp3 r0.x, r1, r3
dp3 r1.x, r2, r1
add r0.x, -r1, r0
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
dp3 r2.x, t2, t2
rsq r2.x, r2.x
mul r2.xyz, r2.x, t2
texkill r0.xyzw
texld r1, t0, s1
dp3 r0.x, t1, t1
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
dp3 r0.x, r0, r2
abs r0.x, r0
add r0.x, -r0, c6.y
pow r2.x, r0.x, c1.x
mul r0, v0, c0
mul r0, r0, r1
mul r1, r0, c6.z
mov r0.x, r2.x
mul r1.w, r1, r0.x
mov_pp oC0, r1
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 64 [_FresnelParaH]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmalbjgcfjhblppppjhfnkgkdnoahmgppabaaaaaabeafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaamcaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcniadaaaaeaaaaaaa
pgaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaad
hcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
aaaaaaakhcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egacbaaaaaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaak
ocaabaaaaaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaa
ahaaaaaabaaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaa
dbaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaead
akaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaai
bcaabaaaaaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaa
diaaaaahiccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaaf
hccabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 64 [_FresnelParaH]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedjkiocpkilabajacgnjemhondcekcpkkjabaaaaaafiahaaaaaeaaaaaa
daaaaaaahaacaaaafaagaaaaceahaaaaebgpgodjdiacaaaadiacaaaaaaacpppp
peabaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaaaaeaaaeaaabaaaaaaaaaaaaacpppp
fbaaaaafafaaapkaaaaaaaiaaaaaialpaaaaiadpaaaaaaaabpaaaaacaaaaaaia
aaaaaplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaahlabpaaaaac
aaaaaaiaadaaahlabpaaaaacaaaaaaiaafaaahlabpaaaaacaaaaaajaaaaiapka
bpaaaaacaaaaaajaabaiapkaabaaaaacaaaaabiaabaakklaabaaaaacaaaaacia
abaapplaecaaaaadaaaaapiaaaaaoeiaabaioekaaeaaaaaeaaaaahiaaaaaoeia
abaakkkaafaaoelaacaaaaadaaaaahiaaaaaoeiaacaaoekbabaaaaacabaaahia
acaaoekaacaaaaadacaaahiaabaaoeibadaaoekaceaaaaacadaaahiaacaaoeia
aiaaaaadabaaaiiaaaaaoeiaadaaoeiaacaaaaadaaaaahiaabaaoeibaeaaoeka
aiaaaaadaaaaabiaaaaaoeiaadaaoeiaacaaaaadaaaaabiaabaappibaaaaaaia
fiaaaaaeaaaaapiaaaaaaaiaafaaaakaafaaffkaebaaaaabaaaaapiaceaaaaac
aaaaahiaacaaoelaceaaaaacabaaahiaadaaoelaaiaaaaadaaaaabiaaaaaoeia
abaaoeiacdaaaaacaaaacbiaaaaaaaiaacaaaaadaaaaabiaaaaaaaibafaakkka
caaaaaadabaacbiaaaaaaaiaabaaaakaafaaaaadaaaaapiaaaaaoelaaaaaoeka
acaaaaadaaaaapiaaaaaoeiaaaaaoeiaecaaaaadacaaapiaabaaoelaaaaioeka
afaaaaadaaaaapiaaaaaoeiaacaaoeiaafaaaaadaaaaciiaabaaaaiaaaaappia
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcniadaaaaeaaaaaaapgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaak
hcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaaaaaaaaaa
agaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegacbaaa
aaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaajhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaakocaabaaa
aaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaaahaaaaaa
baaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaadbaaaaah
bcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaeadakaabaaa
aaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaa
eeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaibcaabaaa
aaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaa
akiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaadiaaaaah
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaafhccabaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
mcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
agaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepep
fceeaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZTest Less
  ZWrite Off
  Cull Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  AlphaTest Greater 0.01
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_MainTex_ST]
Vector 14 [_NoiseTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MOV result.color, vertex.color;
MOV result.texcoord[2].xyz, vertex.normal;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
MOV result.texcoord[1].z, c[11].y;
MOV result.texcoord[1].y, c[10];
MOV result.texcoord[1].x, c[9].y;
DP4 result.texcoord[4].z, vertex.position, c[7];
DP4 result.texcoord[4].y, vertex.position, c[6];
DP4 result.texcoord[4].x, vertex.position, c[5];
END
# 14 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_MainTex_ST]
Vector 13 [_NoiseTex_ST]
"vs_2_0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
dcl_normal0 v3
mov oD0, v1
mov oT2.xyz, v3
mad oT0.zw, v2.xyxy, c13.xyxy, c13
mad oT0.xy, v2, c12, c12.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mov oT1.z, c10.y
mov oT1.y, c9
mov oT1.x, c8.y
dp4 oT4.z, v0, c6
dp4 oT4.y, v0, c5
dp4 oT4.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedmoebegbmnpceiblgbfnihaeaakbfakdnabaaaaaabaaeaaaaadaaaaaa
cmaaaaaalmaaaaaajaabaaaaejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdej
feejepeoaaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheo
mmaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaamcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefchiacaaaaeaaaabaajoaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaabcaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaafpaaaaadhcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
acaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaacaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadgaaaaaghccabaaaadaaaaaaegiccaaaabaaaaaabbaaaaaa
dgaaaaafhccabaaaaeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedoipijbbjffgpmnfgmjnioabgnpeaaifnabaaaaaalaafaaaaaeaaaaaa
daaaaaaammabaaaaemaeaaaanmaeaaaaebgpgodjjeabaaaajeabaaaaaaacpopp
dmabaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaacaa
acaaabaaaaaaaaaaabaaaaaaaeaaadaaaaaaaaaaabaaamaaaeaaahaaaaaaaaaa
abaabbaaabaaalaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapja
bpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadia
adaaapjaaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaaeaaaaaeabaaamoa
acaaeejaacaaeekaacaaoekaafaaaaadaaaaahiaaaaaffjaaiaaoekaaeaaaaae
aaaaahiaahaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiaajaaoekaaaaakkja
aaaaoeiaaeaaaaaeafaaahoaakaaoekaaaaappjaaaaaoeiaafaaaaadaaaaapia
aaaaffjaaeaaoekaaeaaaaaeaaaaapiaadaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiaafaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaappja
aaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaamma
aaaaoeiaabaaaaacaaaaapoaabaaoejaabaaaaacacaaahoaalaaoekaabaaaaac
adaaahoaadaaoejappppaaaafdeieefchiacaaaaeaaaabaajoaaaaaafjaaaaae
egiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaabcaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaa
fpaaaaadhcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaacabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
abaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
abaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalmccabaaa
acaaaaaaagbebaaaacaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaaaaaaaaaa
adaaaaaadgaaaaaghccabaaaadaaaaaaegiccaaaabaaaaaabbaaaaaadgaaaaaf
hccabaaaaeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaagaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdej
feejepeoaaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheo
mmaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaamcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaakl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Vector 13 [_MainTex_ST]
Vector 14 [_NoiseTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MOV result.color, vertex.color;
MOV result.texcoord[2].xyz, vertex.normal;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[13], c[13].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
MOV result.texcoord[1].z, c[11].y;
MOV result.texcoord[1].y, c[10];
MOV result.texcoord[1].x, c[9].y;
DP4 result.texcoord[4].z, vertex.position, c[7];
DP4 result.texcoord[4].y, vertex.position, c[6];
DP4 result.texcoord[4].x, vertex.position, c[5];
END
# 14 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Vector 12 [_MainTex_ST]
Vector 13 [_NoiseTex_ST]
"vs_2_0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
dcl_normal0 v3
mov oD0, v1
mov oT2.xyz, v3
mad oT0.zw, v2.xyxy, c13.xyxy, c13
mad oT0.xy, v2, c12, c12.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
mov oT1.z, c10.y
mov oT1.y, c9
mov oT1.x, c8.y
dp4 oT4.z, v0, c6
dp4 oT4.y, v0, c5
dp4 oT4.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedmoebegbmnpceiblgbfnihaeaakbfakdnabaaaaaabaaeaaaaadaaaaaa
cmaaaaaalmaaaaaajaabaaaaejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdej
feejepeoaaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheo
mmaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaamcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefchiacaaaaeaaaabaajoaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaabcaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaafpaaaaadhcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
acaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaal
mccabaaaacaaaaaaagbebaaaacaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaa
aaaaaaaaadaaaaaadgaaaaaghccabaaaadaaaaaaegiccaaaabaaaaaabbaaaaaa
dgaaaaafhccabaaaaeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 32 [_MainTex_ST]
Vector 48 [_NoiseTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedoipijbbjffgpmnfgmjnioabgnpeaaifnabaaaaaalaafaaaaaeaaaaaa
daaaaaaammabaaaaemaeaaaanmaeaaaaebgpgodjjeabaaaajeabaaaaaaacpopp
dmabaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaacaa
acaaabaaaaaaaaaaabaaaaaaaeaaadaaaaaaaaaaabaaamaaaeaaahaaaaaaaaaa
abaabbaaabaaalaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapja
bpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadia
adaaapjaaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaaeaaaaaeabaaamoa
acaaeejaacaaeekaacaaoekaafaaaaadaaaaahiaaaaaffjaaiaaoekaaeaaaaae
aaaaahiaahaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahiaajaaoekaaaaakkja
aaaaoeiaaeaaaaaeafaaahoaakaaoekaaaaappjaaaaaoeiaafaaaaadaaaaapia
aaaaffjaaeaaoekaaeaaaaaeaaaaapiaadaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiaafaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaappja
aaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaamma
aaaaoeiaabaaaaacaaaaapoaabaaoejaabaaaaacacaaahoaalaaoekaabaaaaac
adaaahoaadaaoejappppaaaafdeieefchiacaaaaeaaaabaajoaaaaaafjaaaaae
egiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaabcaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaa
fpaaaaadhcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaacabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
abaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
abaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadcaaaaalmccabaaa
acaaaaaaagbebaaaacaaaaaaagiecaaaaaaaaaaaadaaaaaakgiocaaaaaaaaaaa
adaaaaaadgaaaaaghccabaaaadaaaaaaegiccaaaabaaaaaabbaaaaaadgaaaaaf
hccabaaaaeaaaaaaegbcbaaaadaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaa
abaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhccabaaaagaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaa
egacbaaaaaaaaaaadoaaaaabejfdeheoiiaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaahbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahhaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaiaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafaepfdej
feejepeoaaedepemepfcaafeeffiedepepfceeaaeoepfcenebemaaklepfdeheo
mmaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaamcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaamcaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahaiaaaamcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
ahaiaaaamcaaaaaaadaaaaaaaaaaaaaaadaaaaaaafaaaaaaahapaaaamcaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaagaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaV]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.xyz, fragment.texcoord[0].zwzw, texture[0], 2D;
MOV R1.xyz, c[3];
ADD R2.xyz, -R1, c[4];
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MAD R0.xyz, R0, c[2].x, fragment.texcoord[4];
ADD R1.xyz, -R1, c[5];
ADD R0.xyz, R0, -c[3];
MUL R2.xyz, R0.w, R2;
DP3 R0.y, R2, R0;
DP3 R0.x, R1, R2;
SLT R0.x, R0, R0.y;
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.y, R1.y;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R2.xyz, R1.y, fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[1];
DP3 R1.x, R1, R2;
ABS R1.x, R1;
ADD R2.x, -R1, c[6].y;
MUL R1, fragment.color.primary, c[0];
KIL -R0.x;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MUL R0, R1, R0;
MUL R0, R0, c[6].x;
POW R1.x, R2.x, c[1].x;
MUL result.color.w, R0, R1.x;
MOV result.color.xyz, R0;
END
# 29 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaV]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 2.00000000, 0
dcl v0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t4.xyz
mov r1.xyz, c4
mov r3.xyz, c5
add r1.xyz, -c3, r1
mov r0.y, t0.w
mov r0.x, t0.z
add r3.xyz, -c3, r3
texld r0, r0, s0
mad r0.xyz, r0, c2.x, t4
add r2.xyz, r0, -c3
dp3 r0.x, r1, r1
rsq r0.x, r0.x
mul r1.xyz, r0.x, r1
dp3 r0.x, r1, r3
dp3 r1.x, r2, r1
add r0.x, -r1, r0
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
dp3 r2.x, t2, t2
rsq r2.x, r2.x
mul r2.xyz, r2.x, t2
texkill r0.xyzw
texld r1, t0, s1
dp3 r0.x, t1, t1
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
dp3 r0.x, r0, r2
abs r0.x, r0
add r0.x, -r0, c6.y
pow r2.x, r0.x, c1.x
mul r0, v0, c0
mul r0, r0, r1
mul r1, r0, c6.z
mov r0.x, r2.x
mul r1.w, r1, r0.x
mov_pp oC0, r1
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 68 [_FresnelParaV]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0
eefiecedhaeemclmedkobbigmfelmggckdefdfdjabaaaaaabeafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaamcaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcniadaaaaeaaaaaaa
pgaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaad
hcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
aaaaaaakhcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egacbaaaaaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaak
ocaabaaaaaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaa
ahaaaaaabaaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaa
dbaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaead
akaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaai
bcaabaaaaaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaa
aaaaaaaabkiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaa
diaaaaahiccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaaf
hccabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 68 [_FresnelParaV]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfbagkbjcancnclneemokcgmfcaeoklfmabaaaaaafiahaaaaaeaaaaaa
daaaaaaahaacaaaafaagaaaaceahaaaaebgpgodjdiacaaaadiacaaaaaaacpppp
peabaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaaaaeaaaeaaabaaaaaaaaaaaaacpppp
fbaaaaafafaaapkaaaaaaaiaaaaaialpaaaaiadpaaaaaaaabpaaaaacaaaaaaia
aaaaaplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaahlabpaaaaac
aaaaaaiaadaaahlabpaaaaacaaaaaaiaafaaahlabpaaaaacaaaaaajaaaaiapka
bpaaaaacaaaaaajaabaiapkaabaaaaacaaaaabiaabaakklaabaaaaacaaaaacia
abaapplaecaaaaadaaaaapiaaaaaoeiaabaioekaaeaaaaaeaaaaahiaaaaaoeia
abaakkkaafaaoelaacaaaaadaaaaahiaaaaaoeiaacaaoekbabaaaaacabaaahia
acaaoekaacaaaaadacaaahiaabaaoeibadaaoekaceaaaaacadaaahiaacaaoeia
aiaaaaadabaaaiiaaaaaoeiaadaaoeiaacaaaaadaaaaahiaabaaoeibaeaaoeka
aiaaaaadaaaaabiaaaaaoeiaadaaoeiaacaaaaadaaaaabiaabaappibaaaaaaia
fiaaaaaeaaaaapiaaaaaaaiaafaaaakaafaaffkaebaaaaabaaaaapiaceaaaaac
aaaaahiaacaaoelaceaaaaacabaaahiaadaaoelaaiaaaaadaaaaabiaaaaaoeia
abaaoeiacdaaaaacaaaacbiaaaaaaaiaacaaaaadaaaaabiaaaaaaaibafaakkka
caaaaaadabaacbiaaaaaaaiaabaaffkaafaaaaadaaaaapiaaaaaoelaaaaaoeka
acaaaaadaaaaapiaaaaaoeiaaaaaoeiaecaaaaadacaaapiaabaaoelaaaaioeka
afaaaaadaaaaapiaaaaaoeiaacaaoeiaafaaaaadaaaaciiaabaaaaiaaaaappia
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcniadaaaaeaaaaaaapgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaak
hcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaaaaaaaaaa
agaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegacbaaa
aaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaajhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaakocaabaaa
aaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaaahaaaaaa
baaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaadbaaaaah
bcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaeadakaabaaa
aaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaa
eeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaibcaabaaa
aaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaadiaaaaah
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaafhccabaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
mcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
agaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepep
fceeaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaV]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
PARAM c[7] = { program.local[0..5],
		{ 2, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.xyz, fragment.texcoord[0].zwzw, texture[0], 2D;
MOV R1.xyz, c[3];
ADD R2.xyz, -R1, c[4];
DP3 R0.w, R2, R2;
RSQ R0.w, R0.w;
MAD R0.xyz, R0, c[2].x, fragment.texcoord[4];
ADD R1.xyz, -R1, c[5];
ADD R0.xyz, R0, -c[3];
MUL R2.xyz, R0.w, R2;
DP3 R0.y, R2, R0;
DP3 R0.x, R1, R2;
SLT R0.x, R0, R0.y;
DP3 R1.y, fragment.texcoord[2], fragment.texcoord[2];
RSQ R1.y, R1.y;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
MUL R2.xyz, R1.y, fragment.texcoord[2];
RSQ R1.x, R1.x;
MUL R1.xyz, R1.x, fragment.texcoord[1];
DP3 R1.x, R1, R2;
ABS R1.x, R1;
ADD R2.x, -R1, c[6].y;
MUL R1, fragment.color.primary, c[0];
KIL -R0.x;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MUL R0, R1, R0;
MUL R0, R0, c[6].x;
POW R1.x, R2.x, c[1].x;
MUL result.color.w, R0, R1.x;
MOV result.color.xyz, R0;
END
# 29 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_TintColor]
Float 1 [_FresnelParaV]
Float 2 [_NoiseScale]
Vector 3 [_StartPosInWS]
Vector 4 [_StopPostInWS]
Vector 5 [_CurPosInWS]
SetTexture 0 [_NoiseTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c6, 0.00000000, 1.00000000, 2.00000000, 0
dcl v0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t4.xyz
mov r1.xyz, c4
mov r3.xyz, c5
add r1.xyz, -c3, r1
mov r0.y, t0.w
mov r0.x, t0.z
add r3.xyz, -c3, r3
texld r0, r0, s0
mad r0.xyz, r0, c2.x, t4
add r2.xyz, r0, -c3
dp3 r0.x, r1, r1
rsq r0.x, r0.x
mul r1.xyz, r0.x, r1
dp3 r0.x, r1, r3
dp3 r1.x, r2, r1
add r0.x, -r1, r0
cmp r0.x, r0, c6, c6.y
mov_pp r0, -r0.x
dp3 r2.x, t2, t2
rsq r2.x, r2.x
mul r2.xyz, r2.x, t2
texkill r0.xyzw
texld r1, t0, s1
dp3 r0.x, t1, t1
rsq r0.x, r0.x
mul r0.xyz, r0.x, t1
dp3 r0.x, r0, r2
abs r0.x, r0
add r0.x, -r0, c6.y
pow r2.x, r0.x, c1.x
mul r0, v0, c0
mul r0, r0, r1
mul r1, r0, c6.z
mov r0.x, r2.x
mul r1.w, r1, r0.x
mov_pp oC0, r1
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 68 [_FresnelParaV]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0
eefiecedhaeemclmedkobbigmfelmggckdefdfdjabaaaaaabeafaaaaadaaaaaa
cmaaaaaaaaabaaaadeabaaaaejfdeheommaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaamcaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaaagaaaaaa
ahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcniadaaaaeaaaaaaa
pgaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaad
hcbabaaaagaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
aaaaaaakhcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaa
aaaaaaaaagaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaa
egacbaaaaaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaaj
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaak
ocaabaaaaaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaa
ahaaaaaabaaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaa
dbaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaead
akaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaaagaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaai
bcaabaaaaaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaa
aaaaaaaabkiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaa
diaaaaahiccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaaf
hccabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_NoiseTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_TintColor]
Float 68 [_FresnelParaV]
Float 72 [_NoiseScale]
Vector 80 [_StartPosInWS]
Vector 96 [_StopPostInWS]
Vector 112 [_CurPosInWS]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfbagkbjcancnclneemokcgmfcaeoklfmabaaaaaafiahaaaaaeaaaaaa
daaaaaaahaacaaaafaagaaaaceahaaaaebgpgodjdiacaaaadiacaaaaaaacpppp
peabaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaaaaeaaaeaaabaaaaaaaaaaaaacpppp
fbaaaaafafaaapkaaaaaaaiaaaaaialpaaaaiadpaaaaaaaabpaaaaacaaaaaaia
aaaaaplabpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaahlabpaaaaac
aaaaaaiaadaaahlabpaaaaacaaaaaaiaafaaahlabpaaaaacaaaaaajaaaaiapka
bpaaaaacaaaaaajaabaiapkaabaaaaacaaaaabiaabaakklaabaaaaacaaaaacia
abaapplaecaaaaadaaaaapiaaaaaoeiaabaioekaaeaaaaaeaaaaahiaaaaaoeia
abaakkkaafaaoelaacaaaaadaaaaahiaaaaaoeiaacaaoekbabaaaaacabaaahia
acaaoekaacaaaaadacaaahiaabaaoeibadaaoekaceaaaaacadaaahiaacaaoeia
aiaaaaadabaaaiiaaaaaoeiaadaaoeiaacaaaaadaaaaahiaabaaoeibaeaaoeka
aiaaaaadaaaaabiaaaaaoeiaadaaoeiaacaaaaadaaaaabiaabaappibaaaaaaia
fiaaaaaeaaaaapiaaaaaaaiaafaaaakaafaaffkaebaaaaabaaaaapiaceaaaaac
aaaaahiaacaaoelaceaaaaacabaaahiaadaaoelaaiaaaaadaaaaabiaaaaaoeia
abaaoeiacdaaaaacaaaacbiaaaaaaaiaacaaaaadaaaaabiaaaaaaaibafaakkka
caaaaaadabaacbiaaaaaaaiaabaaffkaafaaaaadaaaaapiaaaaaoelaaaaaoeka
acaaaaadaaaaapiaaaaaoeiaaaaaoeiaecaaaaadacaaapiaabaaoelaaaaioeka
afaaaaadaaaaapiaaaaaoeiaacaaoeiaafaaaaadaaaaciiaabaaaaiaaaaappia
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcniadaaaaeaaaaaaapgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaak
hcaabaaaabaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaaegiccaaaaaaaaaaa
agaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaa
eeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegacbaaa
aaaaaaaakgikcaaaaaaaaaaaaeaaaaaaegbcbaaaagaaaaaaaaaaaaajhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaaaaaaaaaaafaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaakocaabaaa
aaaaaaaaagijcaiaebaaaaaaaaaaaaaaafaaaaaaagijcaaaaaaaaaaaahaaaaaa
baaaaaahccaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaadbaaaaah
bcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaanaaaeadakaabaaa
aaaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaa
eeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
aeaaaaaaegbcbaaaaeaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaaeaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaaaaaaaaaibcaabaaa
aaaaaaaaakaabaiambaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkiacaaaaaaaaaaaaeaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaahpcaabaaaabaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaadiaaaaai
pcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaaj
pcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaadiaaaaah
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadgaaaaafhccabaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaabejfdeheommaaaaaaahaaaaaaaiaaaaaa
laaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaamcaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaapapaaaamcaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
mcaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaamcaaaaaaadaaaaaa
aaaaaaaaadaaaaaaafaaaaaaahaaaaaamcaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
agaaaaaaahahaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepep
fceeaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback "Diffuse"
}