©“Shader "FX/Water" {
Properties {
 _WaveScale ("Wave scale", Range(0.02,0.15)) = 0.063
 _ReflDistort ("Reflection distort", Range(0,1.5)) = 0.44
 _RefrDistort ("Refraction distort", Range(0,1.5)) = 0.4
 _RefrColor ("Refraction color", Color) = (0.34,0.85,0.92,1)
 _Fresnel ("Fresnel (A) ", 2D) = "gray" {}
 _BumpMap ("Normalmap ", 2D) = "bump" {}
 WaveSpeed ("Wave speed (map1 x,y; map2 x,y)", Vector) = (19,9,-16,-7)
 _ReflectiveColor ("Reflective color (RGB) fresnel (A) ", 2D) = "" {}
 _ReflectiveColorCube ("Reflective color cube (RGB) fresnel (A)", CUBE) = "" { TexGen CubeReflect }
 _HorizonColor ("Simple water horizon color", Color) = (0.172,0.463,0.435,1)
 _MainTex ("Fallback texture", 2D) = "" {}
 _ReflectionTex ("Internal Reflection", 2D) = "" {}
 _RefractionTex ("Internal Refraction", 2D) = "" {}
 _WaterColor ("Water Color", Color) = (0.5,0.5,0.5,1)
}
SubShader { 
 Tags { "RenderType"="Opaque" "WaterMode"="Refractive" }
 Pass {
  Tags { "RenderType"="Opaque" "WaterMode"="Refractive" }
Program "vp" {
SubProgram "opengl " {
Keywords { "WATER_REFRACTIVE" }
Bind "vertex" Vertex
Matrix 5 [_World2Object]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_Scale]
Vector 12 [_WaveScale4]
Vector 13 [_WaveOffset]
"!!ARBvp1.0
PARAM c[14] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP4 R2.w, vertex.position, c[4];
DP4 R2.z, vertex.position, c[3];
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MUL R0.xyz, R2.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[0].xy, R0, R0.z;
MUL R0, vertex.position.xzxz, c[12];
RCP R1.x, c[11].w;
MAD R1, R0, R1.x, c[13];
MOV R0.w, c[0].y;
MOV R0.xyz, c[9];
DP4 R3.z, R0, c[7];
DP4 R3.x, R0, c[5];
DP4 R3.y, R0, c[6];
MAD result.texcoord[3].xyz, R3.xzyw, c[11].w, -vertex.position.xzyw;
MOV result.texcoord[1].xy, R1;
MOV result.texcoord[2].xy, R1.wzzw;
MOV result.position, R2;
MOV result.texcoord[0].zw, R2;
END
# 20 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_REFRACTIVE" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_Scale]
Vector 12 [_WaveScale4]
Vector 13 [_WaveOffset]
"vs_2_0
def c14, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dp4 r2.w, v0, c3
dp4 r2.z, v0, c2
dp4 r2.x, v0, c0
dp4 r2.y, v0, c1
mul r0.xyz, r2.xyww, c14.x
mul r0.y, r0, c9.x
mad oT0.xy, r0.z, c10.zwzw, r0
mul r0, v0.xzxz, c12
rcp r1.x, c11.w
mad r1, r0, r1.x, c13
mov r0.w, c14.y
mov r0.xyz, c8
dp4 r3.z, r0, c6
dp4 r3.x, r0, c4
dp4 r3.y, r0, c5
mad oT3.xyz, r3.xzyw, c11.w, -v0.xzyw
mov oT1.xy, r1
mov oT2.xy, r1.wzzw
mov oPos, r2
mov oT0.zw, r2
"
}
SubProgram "d3d11 " {
Keywords { "WATER_REFRACTIVE" }
Bind "vertex" Vertex
ConstBuffer "$Globals" 96
Vector 16 [_WaveScale4]
Vector 32 [_WaveOffset]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedbinindjlbpbimofpcieniloaoomhbfnmabaaaaaaaaaeaaaaadaaaaaa
cmaaaaaahmaaaaaabmabaaaaejfdeheoeiaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafaepfdejfeejepeoaaeoepfcenebemaaepfdeheo
jiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaaimaaaaaaacaaaaaaaaaaaaaa
adaaaaaaacaaaaaaamadaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
nmacaaaaeaaaabaalhaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaabaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
abaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaa
igbcbaaaaaaaaaaaegilcaaaaaaaaaaaabaaaaaaaoaaaaaipcaabaaaaaaaaaaa
egaobaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaaaaaaaaaipccabaaaacaaaaaa
egaobaaaaaaaaaaaegilcaaaaaaaaaaaacaaaaaadiaaaaajhcaabaaaaaaaaaaa
fgifcaaaabaaaaaaaeaaaaaaigibcaaaacaaaaaabbaaaaaadcaaaaalhcaabaaa
aaaaaaaaigibcaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaa
aaaaaaaadcaaaaalhcaabaaaaaaaaaaaigibcaaaacaaaaaabcaaaaaakgikcaaa
abaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaigibcaaaacaaaaaabdaaaaaadcaaaaalhccabaaaadaaaaaaegacbaaa
aaaaaaaapgipcaaaacaaaaaabeaaaaaaigbbbaiaebaaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "WATER_REFRACTIVE" }
Bind "vertex" Vertex
ConstBuffer "$Globals" 96
Vector 16 [_WaveScale4]
Vector 32 [_WaveOffset]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedkponkaglehhjfnkbjgcoljnmbkjimlmaabaaaaaaoaafaaaaaeaaaaaa
daaaaaaaamacaaaapaaeaaaaeaafaaaaebgpgodjneabaaaaneabaaaaaaacpopp
hmabaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaabaa
acaaabaaaaaaaaaaabaaaeaaacaaadaaaaaaaaaaacaaaaaaaeaaafaaaaaaaaaa
acaabaaaafaaajaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafaoaaapkaaaaaaadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjaafaaaaadaaaaapia
aaaaiijaabaaoekaagaaaaacabaaabiaanaappkaaeaaaaaeabaaapoaaaaaoeia
abaaaaiaacaaoekaabaaaaacaaaaahiaadaaoekaafaaaaadabaaahiaaaaaffia
akaanikaaeaaaaaeaaaaaliaajaagikaaaaaaaiaabaakeiaaeaaaaaeaaaaahia
alaanikaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeiaamaanikaaeaaaaae
acaaahoaaaaaoeiaanaappkaaaaanijbafaaaaadaaaaapiaaaaaffjaagaaoeka
aeaaaaaeaaaaapiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaahaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaappjaaaaaoeiaafaaaaad
abaaabiaaaaaffiaaeaaaakaafaaaaadabaaaiiaabaaaaiaaoaaaakaafaaaaad
abaaafiaaaaapeiaaoaaaakaacaaaaadaaaaadoaabaakkiaabaaomiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
aaaaamoaaaaaoeiappppaaaafdeieefcnmacaaaaeaaaabaalhaaaaaafjaaaaae
egiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacacaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaa
akiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaabaaaaaa
kgaobaaaaaaaaaaaaaaaaaahdccabaaaabaaaaaakgakbaaaabaaaaaamgaabaaa
abaaaaaadiaaaaaipcaabaaaaaaaaaaaigbcbaaaaaaaaaaaegilcaaaaaaaaaaa
abaaaaaaaoaaaaaipcaabaaaaaaaaaaaegaobaaaaaaaaaaapgipcaaaacaaaaaa
beaaaaaaaaaaaaaipccabaaaacaaaaaaegaobaaaaaaaaaaaegilcaaaaaaaaaaa
acaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaaigibcaaa
acaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaigibcaaaacaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaa
igibcaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
aaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaigibcaaaacaaaaaabdaaaaaa
dcaaaaalhccabaaaadaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
igbbbaiaebaaaaaaaaaaaaaadoaaaaabejfdeheoeiaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaahaaaaaafaepfdejfeejepeoaaeoepfcenebemaa
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamadaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
"
}
SubProgram "opengl " {
Keywords { "WATER_REFLECTIVE" }
Bind "vertex" Vertex
Matrix 5 [_World2Object]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [_ProjectionParams]
Vector 11 [unity_Scale]
Vector 12 [_WaveScale4]
Vector 13 [_WaveOffset]
"!!ARBvp1.0
PARAM c[14] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..13] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
DP4 R2.w, vertex.position, c[4];
DP4 R2.z, vertex.position, c[3];
DP4 R2.x, vertex.position, c[1];
DP4 R2.y, vertex.position, c[2];
MUL R0.xyz, R2.xyww, c[0].x;
MUL R0.y, R0, c[10].x;
ADD result.texcoord[0].xy, R0, R0.z;
MUL R0, vertex.position.xzxz, c[12];
RCP R1.x, c[11].w;
MAD R1, R0, R1.x, c[13];
MOV R0.w, c[0].y;
MOV R0.xyz, c[9];
DP4 R3.z, R0, c[7];
DP4 R3.x, R0, c[5];
DP4 R3.y, R0, c[6];
MAD result.texcoord[3].xyz, R3.xzyw, c[11].w, -vertex.position.xzyw;
MOV result.texcoord[1].xy, R1;
MOV result.texcoord[2].xy, R1.wzzw;
MOV result.position, R2;
MOV result.texcoord[0].zw, R2;
END
# 20 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_REFLECTIVE" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [_ProjectionParams]
Vector 10 [_ScreenParams]
Vector 11 [unity_Scale]
Vector 12 [_WaveScale4]
Vector 13 [_WaveOffset]
"vs_2_0
def c14, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dp4 r2.w, v0, c3
dp4 r2.z, v0, c2
dp4 r2.x, v0, c0
dp4 r2.y, v0, c1
mul r0.xyz, r2.xyww, c14.x
mul r0.y, r0, c9.x
mad oT0.xy, r0.z, c10.zwzw, r0
mul r0, v0.xzxz, c12
rcp r1.x, c11.w
mad r1, r0, r1.x, c13
mov r0.w, c14.y
mov r0.xyz, c8
dp4 r3.z, r0, c6
dp4 r3.x, r0, c4
dp4 r3.y, r0, c5
mad oT3.xyz, r3.xzyw, c11.w, -v0.xzyw
mov oT1.xy, r1
mov oT2.xy, r1.wzzw
mov oPos, r2
mov oT0.zw, r2
"
}
SubProgram "d3d11 " {
Keywords { "WATER_REFLECTIVE" }
Bind "vertex" Vertex
ConstBuffer "$Globals" 80
Vector 16 [_WaveScale4]
Vector 32 [_WaveOffset]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedbinindjlbpbimofpcieniloaoomhbfnmabaaaaaaaaaeaaaaadaaaaaa
cmaaaaaahmaaaaaabmabaaaaejfdeheoeiaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafaepfdejfeejepeoaaeoepfcenebemaaepfdeheo
jiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaaimaaaaaaacaaaaaaaaaaaaaa
adaaaaaaacaaaaaaamadaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
nmacaaaaeaaaabaalhaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaabaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
abaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaa
igbcbaaaaaaaaaaaegilcaaaaaaaaaaaabaaaaaaaoaaaaaipcaabaaaaaaaaaaa
egaobaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaaaaaaaaaipccabaaaacaaaaaa
egaobaaaaaaaaaaaegilcaaaaaaaaaaaacaaaaaadiaaaaajhcaabaaaaaaaaaaa
fgifcaaaabaaaaaaaeaaaaaaigibcaaaacaaaaaabbaaaaaadcaaaaalhcaabaaa
aaaaaaaaigibcaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaa
aaaaaaaadcaaaaalhcaabaaaaaaaaaaaigibcaaaacaaaaaabcaaaaaakgikcaaa
abaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaa
aaaaaaaaigibcaaaacaaaaaabdaaaaaadcaaaaalhccabaaaadaaaaaaegacbaaa
aaaaaaaapgipcaaaacaaaaaabeaaaaaaigbbbaiaebaaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "WATER_REFLECTIVE" }
Bind "vertex" Vertex
ConstBuffer "$Globals" 80
Vector 16 [_WaveScale4]
Vector 32 [_WaveOffset]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedkponkaglehhjfnkbjgcoljnmbkjimlmaabaaaaaaoaafaaaaaeaaaaaa
daaaaaaaamacaaaapaaeaaaaeaafaaaaebgpgodjneabaaaaneabaaaaaaacpopp
hmabaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaabaa
acaaabaaaaaaaaaaabaaaeaaacaaadaaaaaaaaaaacaaaaaaaeaaafaaaaaaaaaa
acaabaaaafaaajaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafaoaaapkaaaaaaadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjaafaaaaadaaaaapia
aaaaiijaabaaoekaagaaaaacabaaabiaanaappkaaeaaaaaeabaaapoaaaaaoeia
abaaaaiaacaaoekaabaaaaacaaaaahiaadaaoekaafaaaaadabaaahiaaaaaffia
akaanikaaeaaaaaeaaaaaliaajaagikaaaaaaaiaabaakeiaaeaaaaaeaaaaahia
alaanikaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeiaamaanikaaeaaaaae
acaaahoaaaaaoeiaanaappkaaaaanijbafaaaaadaaaaapiaaaaaffjaagaaoeka
aeaaaaaeaaaaapiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaahaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaappjaaaaaoeiaafaaaaad
abaaabiaaaaaffiaaeaaaakaafaaaaadabaaaiiaabaaaaiaaoaaaakaafaaaaad
abaaafiaaaaapeiaaoaaaakaacaaaaadaaaaadoaabaakkiaabaaomiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
aaaaamoaaaaaoeiappppaaaafdeieefcnmacaaaaeaaaabaalhaaaaaafjaaaaae
egiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadmccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacacaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaa
akiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaabaaaaaa
kgaobaaaaaaaaaaaaaaaaaahdccabaaaabaaaaaakgakbaaaabaaaaaamgaabaaa
abaaaaaadiaaaaaipcaabaaaaaaaaaaaigbcbaaaaaaaaaaaegilcaaaaaaaaaaa
abaaaaaaaoaaaaaipcaabaaaaaaaaaaaegaobaaaaaaaaaaapgipcaaaacaaaaaa
beaaaaaaaaaaaaaipccabaaaacaaaaaaegaobaaaaaaaaaaaegilcaaaaaaaaaaa
acaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaaigibcaaa
acaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaigibcaaaacaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaa
igibcaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
aaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaigibcaaaacaaaaaabdaaaaaa
dcaaaaalhccabaaaadaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
igbbbaiaebaaaaaaaaaaaaaadoaaaaabejfdeheoeiaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaahaaaaaafaepfdejfeejepeoaaeoepfcenebemaa
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamadaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
"
}
SubProgram "opengl " {
Keywords { "WATER_SIMPLE" }
Bind "vertex" Vertex
Matrix 5 [_World2Object]
Vector 9 [_WorldSpaceCameraPos]
Vector 10 [unity_Scale]
Vector 11 [_WaveScale4]
Vector 12 [_WaveOffset]
"!!ARBvp1.0
PARAM c[13] = { { 1 },
		state.matrix.mvp,
		program.local[5..12] };
TEMP R0;
TEMP R1;
TEMP R2;
MUL R0, vertex.position.xzxz, c[11];
RCP R1.x, c[10].w;
MAD R1, R0, R1.x, c[12];
MOV R0.w, c[0].x;
MOV R0.xyz, c[9];
DP4 R2.z, R0, c[7];
DP4 R2.x, R0, c[5];
DP4 R2.y, R0, c[6];
MAD result.texcoord[2].xyz, R2.xzyw, c[10].w, -vertex.position.xzyw;
MOV result.texcoord[0].xy, R1;
MOV result.texcoord[1].xy, R1.wzzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 15 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_SIMPLE" }
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_World2Object]
Vector 8 [_WorldSpaceCameraPos]
Vector 9 [unity_Scale]
Vector 10 [_WaveScale4]
Vector 11 [_WaveOffset]
"vs_2_0
def c12, 1.00000000, 0, 0, 0
dcl_position0 v0
mul r0, v0.xzxz, c10
rcp r1.x, c9.w
mad r1, r0, r1.x, c11
mov r0.w, c12.x
mov r0.xyz, c8
dp4 r2.z, r0, c6
dp4 r2.x, r0, c4
dp4 r2.y, r0, c5
mad oT2.xyz, r2.xzyw, c9.w, -v0.xzyw
mov oT0.xy, r1
mov oT1.xy, r1.wzzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "WATER_SIMPLE" }
Bind "vertex" Vertex
ConstBuffer "$Globals" 80
Vector 16 [_WaveScale4]
Vector 32 [_WaveOffset]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedahanajlibekhogiglmajgiioanefpndmabaaaaaafaadaaaaadaaaaaa
cmaaaaaahmaaaaaaaeabaaaaejfdeheoeiaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaafaepfdejfeejepeoaaeoepfcenebemaaepfdeheo
iaaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaheaaaaaa
abaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaaheaaaaaaacaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefceeacaaaaeaaaabaajbaaaaaafjaaaaaeegiocaaaaaaaaaaa
adaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
aaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaaipcaabaaaaaaaaaaaigbcbaaaaaaaaaaaegilcaaaaaaaaaaa
abaaaaaaaoaaaaaipcaabaaaaaaaaaaaegaobaaaaaaaaaaapgipcaaaacaaaaaa
beaaaaaaaaaaaaaipccabaaaabaaaaaaegaobaaaaaaaaaaaegilcaaaaaaaaaaa
acaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaaigibcaaa
acaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaigibcaaaacaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaa
igibcaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
aaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaigibcaaaacaaaaaabdaaaaaa
dcaaaaalhccabaaaacaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaabeaaaaaa
igbbbaiaebaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "WATER_SIMPLE" }
Bind "vertex" Vertex
ConstBuffer "$Globals" 80
Vector 16 [_WaveScale4]
Vector 32 [_WaveOffset]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedbjhjjcljbgannidmgipkjdjidnlafkcgabaaaaaammaeaaaaaeaaaaaa
daaaaaaakiabaaaapeadaaaaeeaeaaaaebgpgodjhaabaaaahaabaaaaaaacpopp
biabaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaabaa
acaaabaaaaaaaaaaabaaaeaaabaaadaaaaaaaaaaacaaaaaaaeaaaeaaaaaaaaaa
acaabaaaafaaaiaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapja
afaaaaadaaaaapiaaaaaiijaabaaoekaagaaaaacabaaabiaamaappkaaeaaaaae
aaaaapoaaaaaoeiaabaaaaiaacaaoekaabaaaaacaaaaahiaadaaoekaafaaaaad
abaaahiaaaaaffiaajaanikaaeaaaaaeaaaaaliaaiaagikaaaaaaaiaabaakeia
aeaaaaaeaaaaahiaakaanikaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeia
alaanikaaeaaaaaeabaaahoaaaaaoeiaamaappkaaaaanijbafaaaaadaaaaapia
aaaaffjaafaaoekaaeaaaaaeaaaaapiaaeaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiaagaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaahaaoekaaaaappja
aaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaamma
aaaaoeiappppaaaafdeieefceeacaaaaeaaaabaajbaaaaaafjaaaaaeegiocaaa
aaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaaigbcbaaaaaaaaaaaegilcaaa
aaaaaaaaabaaaaaaaoaaaaaipcaabaaaaaaaaaaaegaobaaaaaaaaaaapgipcaaa
acaaaaaabeaaaaaaaaaaaaaipccabaaaabaaaaaaegaobaaaaaaaaaaaegilcaaa
aaaaaaaaacaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaa
igibcaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaaigibcaaaacaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaa
aaaaaaaaigibcaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
aaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaaigibcaaaacaaaaaa
bdaaaaaadcaaaaalhccabaaaacaaaaaaegacbaaaaaaaaaaapgipcaaaacaaaaaa
beaaaaaaigbbbaiaebaaaaaaaaaaaaaadoaaaaabejfdeheoeiaaaaaaacaaaaaa
aiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaahaaaaaafaepfdejfeejepeoaaeoepfc
enebemaaepfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaaheaaaaaa
acaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "WATER_REFRACTIVE" }
Float 0 [_ReflDistort]
Float 1 [_RefrDistort]
Vector 2 [_RefrColor]
Vector 3 [_WaterColor]
SetTexture 0 [_BumpMap] 2D 0
SetTexture 1 [_ReflectionTex] 2D 1
SetTexture 2 [_RefractionTex] 2D 2
SetTexture 3 [_Fresnel] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 2, 1, 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R1.yw, fragment.texcoord[2], texture[0], 2D;
TEX R0.yw, fragment.texcoord[1], texture[0], 2D;
MAD R0.xy, R0.wyzw, c[4].x, -c[4].y;
MUL R0.zw, R0.xyxy, R0.xyxy;
MAD R1.xy, R1.wyzw, c[4].x, -c[4].y;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD_SAT R1.z, R1, R1.w;
ADD R0.w, -R1.z, c[4].y;
RSQ R0.w, R0.w;
ADD R0.z, -R0, c[4].y;
RSQ R0.z, R0.z;
RCP R1.z, R0.w;
RCP R0.z, R0.z;
ADD R1.xyz, R0, R1;
MUL R3.xyz, R1, c[4].z;
DP3 R0.x, fragment.texcoord[3], fragment.texcoord[3];
RSQ R0.x, R0.x;
MUL R2.xyz, R0.x, fragment.texcoord[3];
DP3 R0.w, R2, R3;
MAD R1.xy, R3, c[0].x, fragment.texcoord[0];
MOV R1.z, fragment.texcoord[0].w;
MAD R0.xy, -R3, c[1].x, fragment.texcoord[0];
MOV R0.z, fragment.texcoord[0].w;
TEX R2.w, R0.w, texture[3], 2D;
TXP R0, R0.xyzz, texture[2], 2D;
TXP R1, R1.xyzz, texture[1], 2D;
MUL R0, R0, c[2];
ADD R1, R1, -R0;
MAD R0, R2.w, R1, R0;
MUL result.color.xyz, R0, c[3];
MOV result.color.w, R0;
END
# 32 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_REFRACTIVE" }
Float 0 [_ReflDistort]
Float 1 [_RefrDistort]
Vector 2 [_RefrColor]
Vector 3 [_WaterColor]
SetTexture 0 [_BumpMap] 2D 0
SetTexture 1 [_ReflectionTex] 2D 1
SetTexture 2 [_RefractionTex] 2D 2
SetTexture 3 [_Fresnel] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c4, 2.00000000, -1.00000000, 1.00000000, 0.50000000
dcl t0
dcl t1.xy
dcl t2.xy
dcl t3.xyz
texld r1, t1, s0
texld r0, t2, s0
mov r1.x, r1.w
mov r0.x, r0.w
mad_pp r2.xy, r0, c4.x, c4.y
mad_pp r3.xy, r1, c4.x, c4.y
mul_pp r1.xy, r2, r2
mul_pp r0.xy, r3, r3
add_pp_sat r0.x, r0, r0.y
add_pp_sat r1.x, r1, r1.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
add_pp r1.x, -r1, c4.z
rsq_pp r1.x, r1.x
rcp_pp r2.z, r1.x
add_pp r1.xyz, r3, r2
mul_pp r3.xyz, r1, c4.w
dp3 r0.x, t3, t3
rsq r0.x, r0.x
mul r0.xyz, r0.x, t3
dp3 r2.x, r0, r3
mov r2.xy, r2.x
mad r1.xy, r3, c0.x, t0
mov r1.zw, t0
mad r0.xy, -r3, c1.x, t0
mov r0.zw, t0
texld r2, r2, s3
texldp r0, r0, s2
texldp r1, r1, s1
mul r0, r0, c2
add_pp r1, r1, -r0
mad_pp r0, r2.w, r1, r0
mul_pp r0.xyz, r0, c3
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "WATER_REFRACTIVE" }
SetTexture 0 [_BumpMap] 2D 3
SetTexture 1 [_ReflectionTex] 2D 0
SetTexture 2 [_RefractionTex] 2D 2
SetTexture 3 [_Fresnel] 2D 1
ConstBuffer "$Globals" 96
Float 48 [_ReflDistort]
Float 52 [_RefrDistort]
Vector 64 [_RefrColor]
Vector 80 [_WaterColor]
BindCB  "$Globals" 0
"ps_4_0
eefieceddophjmeenioknfhljeoihkjakfmhdnahabaaaaaaliafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapalaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefclaaeaaaaeaaaaaaacmabaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaadlcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaadaaaaaadcaaaaapdcaabaaa
aaaaaaaahgapbaaaaaaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaa
aceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaa
egaabaaaaaaaaaaaegaabaaaaaaaaaaaddaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaaaaaaaaadkaabaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
adaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaea
aaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaa
apaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaa
aaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaa
abaaaaaadkaabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadcaaaaakdcaabaaaabaaaaaaegaabaaa
aaaaaaaaagiacaaaaaaaaaaaadaaaaaaegbabaaaabaaaaaaaoaaaaahdcaabaaa
abaaaaaaegaabaaaabaaaaaapgbpbaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadcaaaaaldcaabaaa
acaaaaaaegaabaiaebaaaaaaaaaaaaaafgifcaaaaaaaaaaaadaaaaaaegbabaaa
abaaaaaaaoaaaaahdcaabaaaacaaaaaaegaabaaaacaaaaaapgbpbaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaa
acaaaaaadcaaaaalpcaabaaaabaaaaaaegaobaiaebaaaaaaacaaaaaaegiocaaa
aaaaaaaaaeaaaaaaegaobaaaabaaaaaadiaaaaaipcaabaaaacaaaaaaegaobaaa
acaaaaaaegiocaaaaaaaaaaaaeaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaadaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaagaabaaaaaaaaaaaeghobaaaadaaaaaaaagabaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaaegaobaaaacaaaaaa
diaaaaaihccabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "WATER_REFRACTIVE" }
SetTexture 0 [_BumpMap] 2D 3
SetTexture 1 [_ReflectionTex] 2D 0
SetTexture 2 [_RefractionTex] 2D 2
SetTexture 3 [_Fresnel] 2D 1
ConstBuffer "$Globals" 96
Float 48 [_ReflDistort]
Float 52 [_RefrDistort]
Vector 64 [_RefrColor]
Vector 80 [_WaterColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedbaeonjlaalchkdfmdnepemggonbkclepabaaaaaajiaiaaaaaeaaaaaa
daaaaaaaamadaaaameahaaaageaiaaaaebgpgodjneacaaaaneacaaaaaaacpppp
jeacaaaaeaaaaaaaabaadeaaaaaaeaaaaaaaeaaaaeaaceaaaaaaeaaaabaaaaaa
adababaaacacacaaaaadadaaaaaaadaaadaaaaaaaaaaaaaaaaacppppfbaaaaaf
adaaapkaaaaaaaeaaaaaialpaaaaaaaaaaaaiadpfbaaaaafaeaaapkaaaaaaadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaia
abaaaplabpaaaaacaaaaaaiaacaaahlabpaaaaacaaaaaajaaaaiapkabpaaaaac
aaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapka
abaaaaacaaaaadiaabaabllaecaaaaadaaaacpiaaaaaoeiaadaioekaecaaaaad
abaacpiaabaaoelaadaioekaaeaaaaaeacaacbiaaaaappiaadaaaakaadaaffka
aeaaaaaeacaacciaaaaaffiaadaaaakaadaaffkafkaaaaaeacaadiiaacaaoeia
acaaoeiaadaakkkaacaaaaadacaaciiaacaappibadaappkaahaaaaacacaaciia
acaappiaagaaaaacacaaceiaacaappiaaeaaaaaeaaaacbiaabaappiaadaaaaka
adaaffkaaeaaaaaeaaaacciaabaaffiaadaaaakaadaaffkafkaaaaaeaaaadiia
aaaaoeiaaaaaoeiaadaakkkaacaaaaadaaaaciiaaaaappibadaappkaahaaaaac
aaaaciiaaaaappiaagaaaaacaaaaceiaaaaappiaacaaaaadaaaachiaacaaoeia
aaaaoeiaafaaaaadaaaachiaaaaaoeiaaeaaaakaaeaaaaaeabaaadiaaaaaoeia
aaaaaakaaaaaoelaagaaaaacaaaaaiiaaaaapplaafaaaaadabaaadiaaaaappia
abaaoeiaaeaaaaaeabaaamiaaaaabliaaaaaffkbaaaabllaafaaaaadacaaadia
aaaappiaabaabliaceaaaaacadaaahiaacaaoelaaiaaaaadaaaacdiaadaaoeia
aaaaoeiaecaaaaadabaacpiaabaaoeiaaaaioekaecaaaaadacaaapiaacaaoeia
acaioekaecaaaaadaaaacpiaaaaaoeiaabaioekaaeaaaaaeabaacpiaacaaoeia
abaaoekbabaaoeiaafaaaaadacaacpiaacaaoeiaabaaoekaaeaaaaaeaaaacpia
aaaappiaabaaoeiaacaaoeiaafaaaaadaaaachiaaaaaoeiaacaaoekaabaaaaac
aaaicpiaaaaaoeiappppaaaafdeieefclaaeaaaaeaaaaaaacmabaaaafjaaaaae
egiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaa
abaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaad
lcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaa
efaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
adaaaaaadcaaaaapdcaabaaaaaaaaaaahgapbaaaaaaaaaaaaceaaaaaaaaaaaea
aaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaa
apaaaaahicaabaaaaaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaaddaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaa
aaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaa
aaaaaaaadkaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaadaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaa
abaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaa
egaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaaaaaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaakhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadcaaaaak
dcaabaaaabaaaaaaegaabaaaaaaaaaaaagiacaaaaaaaaaaaadaaaaaaegbabaaa
abaaaaaaaoaaaaahdcaabaaaabaaaaaaegaabaaaabaaaaaapgbpbaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadcaaaaaldcaabaaaacaaaaaaegaabaiaebaaaaaaaaaaaaaafgifcaaa
aaaaaaaaadaaaaaaegbabaaaabaaaaaaaoaaaaahdcaabaaaacaaaaaaegaabaaa
acaaaaaapgbpbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaacaaaaaaaagabaaaacaaaaaadcaaaaalpcaabaaaabaaaaaaegaobaia
ebaaaaaaacaaaaaaegiocaaaaaaaaaaaaeaaaaaaegaobaaaabaaaaaadiaaaaai
pcaabaaaacaaaaaaegaobaaaacaaaaaaegiocaaaaaaaaaaaaeaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaadaaaaaapgapbaaaaaaaaaaa
egbcbaaaadaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaadaaaaaaegacbaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaagaabaaaaaaaaaaaeghobaaaadaaaaaa
aagabaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaapgapbaaaaaaaaaaaegaobaaa
abaaaaaaegaobaaaacaaaaaadiaaaaaihccabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaaaaaaaaaafaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaa
doaaaaabejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apalaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaaimaaaaaa
acaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaimaaaaaaadaaaaaaaaaaaaaa
adaaaaaaadaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "WATER_REFLECTIVE" }
Float 0 [_ReflDistort]
Vector 1 [_WaterColor]
SetTexture 0 [_BumpMap] 2D 0
SetTexture 1 [_ReflectionTex] 2D 1
SetTexture 2 [_ReflectiveColor] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 2, 1, 0.5 } };
TEMP R0;
TEMP R1;
TEX R1.yw, fragment.texcoord[1], texture[0], 2D;
TEX R0.yw, fragment.texcoord[2], texture[0], 2D;
MAD R0.xy, R0.wyzw, c[2].x, -c[2].y;
MAD R1.xy, R1.wyzw, c[2].x, -c[2].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[2].y;
RSQ R0.z, R0.z;
ADD R0.w, -R0, c[2].y;
RSQ R0.w, R0.w;
RCP R1.z, R0.z;
RCP R0.z, R0.w;
ADD R1.xyz, R1, R0;
DP3 R0.w, fragment.texcoord[3], fragment.texcoord[3];
RSQ R0.x, R0.w;
MUL R1.xyz, R1, c[2].z;
MUL R0.xyz, R0.x, fragment.texcoord[3];
DP3 R0.x, R0, R1;
MOV R1.z, fragment.texcoord[0].w;
MAD R1.xy, R1, c[0].x, fragment.texcoord[0];
TEX R0, R0.x, texture[2], 2D;
TXP R1, R1.xyzz, texture[1], 2D;
ADD R1.xyz, -R0, R1;
MAD R0.xyz, R0.w, R1, R0;
MUL result.color.xyz, R0, c[1];
MUL result.color.w, R0, R1;
END
# 28 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_REFLECTIVE" }
Float 0 [_ReflDistort]
Vector 1 [_WaterColor]
SetTexture 0 [_BumpMap] 2D 0
SetTexture 1 [_ReflectionTex] 2D 1
SetTexture 2 [_ReflectiveColor] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c2, 2.00000000, -1.00000000, 1.00000000, 0.50000000
dcl t0
dcl t1.xy
dcl t2.xy
dcl t3.xyz
texld r1, t1, s0
texld r0, t2, s0
mov r1.x, r1.w
mov r0.x, r0.w
mad_pp r2.xy, r0, c2.x, c2.y
mad_pp r3.xy, r1, c2.x, c2.y
mul_pp r1.xy, r2, r2
add_pp_sat r1.x, r1, r1.y
mul_pp r0.xy, r3, r3
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c2.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
add_pp r1.x, -r1, c2.z
rsq_pp r1.x, r1.x
rcp_pp r2.z, r1.x
add_pp r1.xyz, r3, r2
dp3 r0.x, t3, t3
rsq r0.x, r0.x
mul_pp r2.xyz, r1, c2.w
mul r0.xyz, r0.x, t3
dp3 r0.x, r0, r2
mov r1.xy, r0.x
mov r0.zw, t0
mad r0.xy, r2, c0.x, t0
texldp r0, r0, s1
texld r1, r1, s2
add_pp r0.xyz, -r1, r0
mad_pp r0.xyz, r1.w, r0, r1
mul_pp r0.w, r1, r0
mul_pp r0.xyz, r0, c1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "WATER_REFLECTIVE" }
SetTexture 0 [_BumpMap] 2D 2
SetTexture 1 [_ReflectionTex] 2D 0
SetTexture 2 [_ReflectiveColor] 2D 1
ConstBuffer "$Globals" 80
Float 48 [_ReflDistort]
Vector 64 [_WaterColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecednnpcfekjfnikcoaljohgbmnlpejaonnaabaaaaaaamafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapalaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcaeaeaaaaeaaaaaaaababaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaadlcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadcaaaaap
dcaabaaaaaaaaaaahgapbaaaaaaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaaaaaaaaadkaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaa
aagabaaaacaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaa
aaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaa
aaaaaaaaapaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaa
ddaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaai
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaaf
ecaabaaaabaaaaaadkaabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaadcaaaaakdcaabaaaabaaaaaa
egaabaaaaaaaaaaaagiacaaaaaaaaaaaadaaaaaaegbabaaaabaaaaaaaoaaaaah
dcaabaaaabaaaaaaegaabaaaabaaaaaapgbpbaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaabaaaaaah
icaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaa
egbcbaaaadaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaagaabaaaaaaaaaaaeghobaaaacaaaaaa
aagabaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaahiccabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaa
abaaaaaadcaaaaajhcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaaaaaaaaadiaaaaaihccabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaa
aaaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "WATER_REFLECTIVE" }
SetTexture 0 [_BumpMap] 2D 2
SetTexture 1 [_ReflectionTex] 2D 0
SetTexture 2 [_ReflectiveColor] 2D 1
ConstBuffer "$Globals" 80
Float 48 [_ReflDistort]
Vector 64 [_WaterColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedaedidoejhddnnmmclbejgaeaiabokikfabaaaaaajeahaaaaaeaaaaaa
daaaaaaaleacaaaamaagaaaagaahaaaaebgpgodjhmacaaaahmacaaaaaaacpppp
eaacaaaadmaaaaaaabaadaaaaaaadmaaaaaadmaaadaaceaaaaaadmaaabaaaaaa
acababaaaaacacaaaaaaadaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapka
aaaaaaeaaaaaialpaaaaaaaaaaaaiadpfbaaaaafadaaapkaaaaaaadpaaaaaaaa
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaaapla
bpaaaaacaaaaaaiaacaaahlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaaja
abaiapkabpaaaaacaaaaaajaacaiapkaabaaaaacaaaaadiaabaabllaecaaaaad
aaaacpiaaaaaoeiaacaioekaecaaaaadabaacpiaabaaoelaacaioekaaeaaaaae
acaacbiaaaaappiaacaaaakaacaaffkaaeaaaaaeacaacciaaaaaffiaacaaaaka
acaaffkafkaaaaaeacaadiiaacaaoeiaacaaoeiaacaakkkaacaaaaadacaaciia
acaappibacaappkaahaaaaacacaaciiaacaappiaagaaaaacacaaceiaacaappia
aeaaaaaeaaaacbiaabaappiaacaaaakaacaaffkaaeaaaaaeaaaacciaabaaffia
acaaaakaacaaffkafkaaaaaeaaaadiiaaaaaoeiaaaaaoeiaacaakkkaacaaaaad
aaaaciiaaaaappibacaappkaahaaaaacaaaaciiaaaaappiaagaaaaacaaaaceia
aaaappiaacaaaaadaaaachiaacaaoeiaaaaaoeiaafaaaaadaaaachiaaaaaoeia
adaaaakaaeaaaaaeabaaadiaaaaaoeiaaaaaaakaaaaaoelaagaaaaacaaaaaiia
aaaapplaafaaaaadabaaadiaaaaappiaabaaoeiaceaaaaacacaaahiaacaaoela
aiaaaaadaaaacdiaacaaoeiaaaaaoeiaecaaaaadabaacpiaabaaoeiaaaaioeka
ecaaaaadaaaacpiaaaaaoeiaabaioekabcaaaaaeacaachiaaaaappiaabaaoeia
aaaaoeiaafaaaaadaaaaciiaaaaappiaabaappiaafaaaaadaaaachiaacaaoeia
abaaoekaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcaeaeaaaaeaaaaaaa
ababaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaagcbaaaadlcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadmcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaaaaaaaaahgapbaaa
aaaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaaegaabaaaaaaaaaaa
egaabaaaaaaaaaaaddaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaaaaaaaaadkaabaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
diaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaadcaaaaakdcaabaaaabaaaaaaegaabaaaaaaaaaaaagiacaaa
aaaaaaaaadaaaaaaegbabaaaabaaaaaaaoaaaaahdcaabaaaabaaaaaaegaabaaa
abaaaaaapgbpbaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
adaaaaaaegbcbaaaadaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaacaaaaaapgapbaaaaaaaaaaaegbcbaaaadaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaagaabaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaabaaaaaaaaaaaaai
hcaabaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaaegacbaaaabaaaaaadiaaaaah
iccabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaabaaaaaadcaaaaajhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadiaaaaai
hccabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaadoaaaaab
ejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapalaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaacaaaaaaamamaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "WATER_SIMPLE" }
Vector 0 [_HorizonColor]
SetTexture 0 [_BumpMap] 2D 0
SetTexture 1 [_ReflectiveColor] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 2, 1, 0.5 } };
TEMP R0;
TEMP R1;
TEX R1.yw, fragment.texcoord[0], texture[0], 2D;
TEX R0.yw, fragment.texcoord[1], texture[0], 2D;
MAD R0.xy, R0.wyzw, c[1].x, -c[1].y;
MAD R1.xy, R1.wyzw, c[1].x, -c[1].y;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
MUL R1.zw, R0.xyxy, R0.xyxy;
ADD_SAT R0.w, R1.z, R1;
ADD R0.z, -R0, c[1].y;
RSQ R0.z, R0.z;
ADD R0.w, -R0, c[1].y;
RSQ R0.w, R0.w;
RCP R1.z, R0.z;
RCP R0.z, R0.w;
ADD R1.xyz, R1, R0;
DP3 R0.w, fragment.texcoord[2], fragment.texcoord[2];
RSQ R0.x, R0.w;
MUL R0.xyz, R0.x, fragment.texcoord[2];
MUL R1.xyz, R1, c[1].z;
DP3 R0.x, R0, R1;
MOV result.color.w, c[0];
TEX R0, R0.x, texture[1], 2D;
ADD R1.xyz, -R0, c[0];
MAD result.color.xyz, R0.w, R1, R0;
END
# 24 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "WATER_SIMPLE" }
Vector 0 [_HorizonColor]
SetTexture 0 [_BumpMap] 2D 0
SetTexture 1 [_ReflectiveColor] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 2.00000000, -1.00000000, 1.00000000, 0.50000000
dcl t0.xy
dcl t1.xy
dcl t2.xyz
texld r1, t0, s0
texld r0, t1, s0
mov r0.x, r0.w
mov r1.x, r1.w
mad_pp r3.xy, r1, c1.x, c1.y
mad_pp r2.xy, r0, c1.x, c1.y
mul_pp r0.xy, r3, r3
add_pp_sat r0.x, r0, r0.y
mul_pp r1.xy, r2, r2
add_pp_sat r1.x, r1, r1.y
add_pp r0.x, -r0, c1.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
add_pp r1.x, -r1, c1.z
rsq_pp r1.x, r1.x
rcp_pp r2.z, r1.x
dp3 r0.x, t2, t2
add_pp r1.xyz, r3, r2
rsq r0.x, r0.x
mul r0.xyz, r0.x, t2
mul_pp r1.xyz, r1, c1.w
dp3 r0.x, r0, r1
mov r0.xy, r0.x
texld r0, r0, s1
add_pp r1.xyz, -r0, c0
mad_pp r0.xyz, r0.w, r1, r0
mov_pp r0.w, c0
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "WATER_SIMPLE" }
SetTexture 0 [_BumpMap] 2D 1
SetTexture 1 [_ReflectiveColor] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_HorizonColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedapmnlbjplhedadnnfnejklieoaadoahjabaaaaaaeeaeaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcfeadaaaaeaaaaaaanfaaaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaap
dcaabaaaaaaaaaaahgapbaaaaaaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaaaaaaaaadkaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaa
aaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaa
aaaaaaaaapaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaa
ddaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaai
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaaf
ecaabaaaabaaaaaadkaabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaacaaaaaaegbcbaaaacaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaacaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaagaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
aaaaaaajhcaabaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaaaaaaaaa
adaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaaaaaaaaadgaaaaagiccabaaaaaaaaaaadkiacaaaaaaaaaaaadaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "WATER_SIMPLE" }
SetTexture 0 [_BumpMap] 2D 1
SetTexture 1 [_ReflectiveColor] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_HorizonColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedojfindjfkgoofbckbdadedmnnagabiagabaaaaaafmagaaaaaeaaaaaa
daaaaaaaeeacaaaakaafaaaaciagaaaaebgpgodjamacaaaaamacaaaaaaacpppp
neabaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaabaaaaaa
aaababaaaaaaadaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaaaea
aaaaialpaaaaaaaaaaaaiadpfbaaaaafacaaapkaaaaaaadpaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaaahlabpaaaaac
aaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaacaaaaadiaaaaablla
ecaaaaadaaaacpiaaaaaoeiaabaioekaecaaaaadabaacpiaaaaaoelaabaioeka
aeaaaaaeacaacbiaaaaappiaabaaaakaabaaffkaaeaaaaaeacaacciaaaaaffia
abaaaakaabaaffkafkaaaaaeacaadiiaacaaoeiaacaaoeiaabaakkkaacaaaaad
acaaciiaacaappibabaappkaahaaaaacacaaciiaacaappiaagaaaaacacaaceia
acaappiaaeaaaaaeaaaacbiaabaappiaabaaaakaabaaffkaaeaaaaaeaaaaccia
abaaffiaabaaaakaabaaffkafkaaaaaeaaaadiiaaaaaoeiaaaaaoeiaabaakkka
acaaaaadaaaaciiaaaaappibabaappkaahaaaaacaaaaciiaaaaappiaagaaaaac
aaaaceiaaaaappiaacaaaaadaaaachiaacaaoeiaaaaaoeiaafaaaaadaaaachia
aaaaoeiaacaaaakaceaaaaacabaaahiaabaaoelaaiaaaaadaaaacdiaabaaoeia
aaaaoeiaecaaaaadaaaacpiaaaaaoeiaaaaioekabcaaaaaeabaachiaaaaappia
aaaaoekaaaaaoeiaabaaaaacabaaciiaaaaappkaabaaaaacaaaicpiaabaaoeia
ppppaaaafdeieefcfeadaaaaeaaaaaaanfaaaaaafjaaaaaeegiocaaaaaaaaaaa
aeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaapdcaabaaa
aaaaaaaahgapbaaaaaaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaa
aceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaa
egaabaaaaaaaaaaaegaabaaaaaaaaaaaddaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaaaaaaaaadkaabaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaea
aaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaa
apaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaa
aaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaa
abaaaaaadkaabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaa
acaaaaaaegbcbaaaacaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahhcaabaaaabaaaaaapgapbaaaaaaaaaaaegbcbaaaacaaaaaabaaaaaah
bcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaagaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaaaaaaaaj
hcaabaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaa
dcaaaaajhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
aaaaaaaadgaaaaagiccabaaaaaaaaaaadkiacaaaaaaaaaaaadaaaaaadoaaaaab
ejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
heaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamamaaaaheaaaaaaacaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
SubShader { 
 Tags { "RenderType"="Opaque" "WaterMode"="Simple" }
 Pass {
  Tags { "RenderType"="Opaque" "WaterMode"="Simple" }
  Color (0.5,0.5,0.5,0.5)
  SetTexture [_MainTex] { Matrix [_WaveMatrix] combine texture * primary }
  SetTexture [_MainTex] { Matrix [_WaveMatrix2] combine texture * primary + previous }
  SetTexture [_ReflectiveColorCube] { Matrix [_Reflection] combine texture +- previous, primary alpha }
 }
}
SubShader { 
 Tags { "RenderType"="Opaque" "WaterMode"="Simple" }
 Pass {
  Tags { "RenderType"="Opaque" "WaterMode"="Simple" }
  Color (0.5,0.5,0.5,0.5)
  SetTexture [_MainTex] { Matrix [_WaveMatrix] combine texture }
  SetTexture [_ReflectiveColorCube] { Matrix [_Reflection] combine texture +- previous, primary alpha }
 }
}
SubShader { 
 Tags { "RenderType"="Opaque" "WaterMode"="Simple" }
 Pass {
  Tags { "RenderType"="Opaque" "WaterMode"="Simple" }
  Color (0.5,0.5,0.5,0)
  SetTexture [_MainTex] { Matrix [_WaveMatrix] combine texture, primary alpha }
 }
}
}