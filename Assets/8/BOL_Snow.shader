ܙ	Shader "BOL/Scene/Snow" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _SnowTex ("Snow Tex", 2D) = "white" {}
 _MaskTex ("Mask Tex", 2D) = "white" {}
 _SnowColor ("Snow Color", Color) = (1,1,1,1)
 _SnowDirection ("Snow Direction", Vector) = (0,1,0,1)
 _SplitValue ("Split Value", Range(0,1)) = 0.5
 _TransformWidth ("Transform width", Range(0,1)) = 0.2
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
Vector 17 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[18] = { { 1 },
		state.matrix.mvp,
		program.local[5..17] };
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
ADD result.texcoord[2].xyz, R2, R1;
MOV result.texcoord[1].z, R2.w;
MOV result.texcoord[1].y, R3.w;
MOV result.texcoord[1].x, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[17], c[17].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 27 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
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
Vector 16 [_MainTex_ST]
"vs_2_0
def c17, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c15.w
dp3 r3.w, r1, c5
dp3 r2.w, r1, c6
dp3 r0.x, r1, c4
mov r0.y, r3.w
mov r0.z, r2.w
mul r1, r0.xyzz, r0.yzzx
mov r0.w, c17.x
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
add oT2.xyz, r2, r1
mov oT1.z, r2.w
mov oT1.y, r3.w
mov oT1.x, r0
mad oT0.xy, v2, c16, c16.zwzw
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
ConstBuffer "$Globals" 80
Vector 64 [_MainTex_ST]
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
eefiecedmeamhaemlcgfalnjhgkobjjhfnaajhajabaaaaaaaaafaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
hmadaaaaeaaaabaanpaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaae
egiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacaeaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaafhccabaaaacaaaaaaegacbaaa
aaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaa
abaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaa
abaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaa
abaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaa
acaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaa
egiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaa
egiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaa
egiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaadaaaaaa
egiccaaaabaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [unity_LightmapST]
Vector 10 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[9], c[9].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 6 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [unity_LightmapST]
Vector 9 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
mad oT0.xy, v2, c9, c9.zwzw
mad oT1.xy, v3, c8, c8.zwzw
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
ConstBuffer "$Globals" 96
Vector 64 [unity_LightmapST]
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedcfkcpnmicbbciekgpppgkdiffapeadpoabaaaaaanmacaaaaadaaaaaa
cmaaaaaapeaaaaaageabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefchaabaaaaeaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaa
agaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaa
ogikcaaaaaaaaaaaafaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [unity_LightmapST]
Vector 10 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[11] = { program.local[0],
		state.matrix.mvp,
		program.local[5..10] };
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[9], c[9].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 6 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [unity_LightmapST]
Vector 9 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
mad oT0.xy, v2, c9, c9.zwzw
mad oT1.xy, v3, c8, c8.zwzw
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
ConstBuffer "$Globals" 96
Vector 64 [unity_LightmapST]
Vector 80 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedcfkcpnmicbbciekgpppgkdiffapeadpoabaaaaaanmacaaaaadaaaaaa
cmaaaaaapeaaaaaageabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefchaabaaaaeaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaa
agaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaafaaaaaa
ogikcaaaaaaaaaaaafaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaaeaaaaaa
agiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
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
Vector 18 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[19] = { { 1, 0.5 },
		state.matrix.mvp,
		program.local[5..18] };
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
ADD result.texcoord[2].xyz, R3, R2;
ADD result.texcoord[3].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
MOV result.texcoord[1].z, R2.w;
MOV result.texcoord[1].y, R3.w;
MOV result.texcoord[1].x, R1.w;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[18], c[18].zwzw;
END
# 32 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
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
Vector 18 [_MainTex_ST]
"vs_2_0
def c19, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r0.xyz, v1, c17.w
dp3 r3.w, r0, c5
dp3 r2.w, r0, c6
dp3 r1.w, r0, c4
mov r1.x, r3.w
mov r1.y, r2.w
mov r1.z, c19.x
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
mul r1.xyz, r0.xyww, c19.y
mul r1.y, r1, c8.x
add oT2.xyz, r3, r2
mad oT3.xy, r1.z, c9.zwzw, r1
mov oPos, r0
mov oT3.zw, r0
mov oT1.z, r2.w
mov oT1.y, r3.w
mov oT1.x, r1.w
mad oT0.xy, v2, c18, c18.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 144
Vector 128 [_MainTex_ST]
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
eefiecedjdljnlhejhgmdifnjjfjcgldiofnppggabaaaaaamaafaaaaadaaaaaa
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
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcceaeaaaaeaaaabaa
ajabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaa
agaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagiaaaaacafaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadiaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadiaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaaklcaabaaaabaaaaaaegiicaaaadaaaaaaamaaaaaa
agaabaaaabaaaaaaegaibaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
adaaaaaaaoaaaaaakgakbaaaabaaaaaaegadbaaaabaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaabaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaa
diaaaaahpcaabaaaadaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaabbaaaaai
bcaabaaaaeaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaabbaaaaai
ccaabaaaaeaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaabbaaaaai
ecaabaaaaeaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaaaaaaaaah
hcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaahccaabaaa
abaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaakbcaabaaaabaaaaaa
akaabaaaabaaaaaaakaabaaaabaaaaaabkaabaiaebaaaaaaabaaaaaadcaaaaak
hccabaaaadaaaaaaegiccaaaacaaaaaacmaaaaaaagaabaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [_ProjectionParams]
Vector 10 [unity_LightmapST]
Vector 11 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[12] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..11] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[9].x;
ADD result.texcoord[2].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[2].zw, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[10], c[10].zwzw;
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_LightmapST]
Vector 11 [_MainTex_ST]
"vs_2_0
def c12, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c12.x
mul r1.y, r1, c8.x
mad oT2.xy, r1.z, c9.zwzw, r1
mov oPos, r0
mov oT2.zw, r0
mad oT0.xy, v2, c11, c11.zwzw
mad oT1.xy, v3, c10, c10.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 128 [unity_LightmapST]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedafhpfajigmklogiabkpbjcondfkgjlbjabaaaaaajmadaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
biacaaaaeaaaabaaigaaaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
mccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadcaaaaalmccabaaaabaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaa
diaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaa
diaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaa
aaaaaadpaaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaah
dccabaaaacaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 9 [_ProjectionParams]
Vector 10 [unity_LightmapST]
Vector 11 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[12] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..11] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[9].x;
ADD result.texcoord[2].xy, R1, R1.z;
MOV result.position, R0;
MOV result.texcoord[2].zw, R0;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[11], c[11].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[10], c[10].zwzw;
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_LightmapST]
Vector 11 [_MainTex_ST]
"vs_2_0
def c12, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v2
dcl_texcoord1 v3
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c12.x
mul r1.y, r1, c8.x
mad oT2.xy, r1.z, c9.zwzw, r1
mov oPos, r0
mov oT2.zw, r0
mad oT0.xy, v2, c11, c11.zwzw
mad oT1.xy, v3, c10, c10.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 160
Vector 128 [unity_LightmapST]
Vector 144 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedafhpfajigmklogiabkpbjcondfkgjlbjabaaaaaajmadaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamadaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
biacaaaaeaaaabaaigaaaaaafjaaaaaeegiocaaaaaaaaaaaakaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
mccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaajaaaaaaogikcaaaaaaaaaaaajaaaaaadcaaaaalmccabaaaabaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaa
diaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaa
diaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaa
aaaaaadpaaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaah
dccabaaaacaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
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
Vector 25 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[26] = { { 1, 0 },
		state.matrix.mvp,
		program.local[5..25] };
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
ADD result.texcoord[2].xyz, R0, R1;
MOV result.texcoord[1].z, R3.x;
MOV result.texcoord[1].y, R3.w;
MOV result.texcoord[1].x, R4;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[25], c[25].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 57 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
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
Vector 24 [_MainTex_ST]
"vs_2_0
def c25, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
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
mov r4.w, c25.x
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
add r1, r2, c25.x
dp4 r2.z, r4, c18
dp4 r2.y, r4, c17
dp4 r2.x, r4, c16
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c25.y
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
add oT2.xyz, r0, r1
mov oT1.z, r3.x
mov oT1.y, r3.w
mov oT1.x, r4
mad oT0.xy, v2, c24, c24.zwzw
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
ConstBuffer "$Globals" 80
Vector 64 [_MainTex_ST]
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
eefiecedfbigkjmadelpjkpcmmkgojebjnhpomeeabaaaaaafaaiaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
mmagaaaaeaaaabaaldabaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaae
egiocaaaabaaaaaacnaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacagaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaacaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaaaaaaaaaaaeaaaaaa
diaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaa
diaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaa
dcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaacaaaaaaaoaaaaaa
kgakbaaaaaaaaaaaegadbaaaaaaaaaaadgaaaaafhccabaaaacaaaaaaegacbaaa
aaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaa
abaaaaaaegiocaaaabaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaa
abaaaaaaegiocaaaabaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaa
abaaaaaaegiocaaaabaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaa
acaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaa
egiocaaaabaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaa
egiocaaaabaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaa
egiocaaaabaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahicaabaaaaaaaaaaabkaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaaaaaaaaaa
akaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaabaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadiaaaaai
hcaabaaaacaaaaaafgbfbaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaacaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaaoaaaaaakgbkbaaa
aaaaaaaaegacbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaa
apaaaaaapgbpbaaaaaaaaaaaegacbaaaacaaaaaaaaaaaaajpcaabaaaadaaaaaa
fgafbaiaebaaaaaaacaaaaaaegiocaaaabaaaaaaadaaaaaadiaaaaahpcaabaaa
aeaaaaaafgafbaaaaaaaaaaaegaobaaaadaaaaaadiaaaaahpcaabaaaadaaaaaa
egaobaaaadaaaaaaegaobaaaadaaaaaaaaaaaaajpcaabaaaafaaaaaaagaabaia
ebaaaaaaacaaaaaaegiocaaaabaaaaaaacaaaaaaaaaaaaajpcaabaaaacaaaaaa
kgakbaiaebaaaaaaacaaaaaaegiocaaaabaaaaaaaeaaaaaadcaaaaajpcaabaaa
aeaaaaaaegaobaaaafaaaaaaagaabaaaaaaaaaaaegaobaaaaeaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaacaaaaaakgakbaaaaaaaaaaaegaobaaaaeaaaaaa
dcaaaaajpcaabaaaadaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaaegaobaaa
adaaaaaadcaaaaajpcaabaaaacaaaaaaegaobaaaacaaaaaaegaobaaaacaaaaaa
egaobaaaadaaaaaaeeaaaaafpcaabaaaadaaaaaaegaobaaaacaaaaaadcaaaaan
pcaabaaaacaaaaaaegaobaaaacaaaaaaegiocaaaabaaaaaaafaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaacaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaacaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegaobaaaadaaaaaadeaaaaakpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaaaaaaaaaegiccaaaabaaaaaaahaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaabaaaaaaagaaaaaaagaabaaaaaaaaaaaegacbaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaaiaaaaaakgakbaaaaaaaaaaa
egacbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaajaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaahhccabaaaadaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
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
Vector 26 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[27] = { { 1, 0, 0.5 },
		state.matrix.mvp,
		program.local[5..26] };
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
ADD result.texcoord[2].xyz, R4.yzww, R1;
MOV R1.x, R2;
MUL R1.y, R2, c[9].x;
ADD result.texcoord[3].xy, R1, R2.z;
MOV result.position, R0;
MOV result.texcoord[3].zw, R0;
MOV result.texcoord[1].z, R3.x;
MOV result.texcoord[1].y, R3.w;
MOV result.texcoord[1].x, R4;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[26], c[26].zwzw;
END
# 63 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
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
Vector 26 [_MainTex_ST]
"vs_2_0
def c27, 1.00000000, 0.00000000, 0.50000000, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
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
mov r4.w, c27.x
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
add r1, r2, c27.x
dp4 r2.z, r4, c20
dp4 r2.y, r4, c19
dp4 r2.x, r4, c18
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c27.y
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
mul r2.xyz, r0.xyww, c27.z
add oT2.xyz, r4.yzww, r1
mov r1.x, r2
mul r1.y, r2, c8.x
mad oT3.xy, r2.z, c9.zwzw, r1
mov oPos, r0
mov oT3.zw, r0
mov oT1.z, r3.x
mov oT1.y, r3.w
mov oT1.x, r4
mad oT0.xy, v2, c26, c26.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 144
Vector 128 [_MainTex_ST]
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
eefiecedfpmbmbacfcpchkhlhickfdhaekjadnmhabaaaaaabaajaaaaadaaaaaa
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
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcheahaaaaeaaaabaa
nnabaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaa
agaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagiaaaaacahaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadiaaaaaihcaabaaaabaaaaaaegbcbaaaacaaaaaapgipcaaa
adaaaaaabeaaaaaadiaaaaaihcaabaaaacaaaaaafgafbaaaabaaaaaaegiccaaa
adaaaaaaanaaaaaadcaaaaaklcaabaaaabaaaaaaegiicaaaadaaaaaaamaaaaaa
agaabaaaabaaaaaaegaibaaaacaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
adaaaaaaaoaaaaaakgakbaaaabaaaaaaegadbaaaabaaaaaadgaaaaafhccabaaa
acaaaaaaegacbaaaabaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaacaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaa
bbaaaaaiccaabaaaacaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaa
bbaaaaaiecaabaaaacaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaa
diaaaaahpcaabaaaadaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaabbaaaaai
bcaabaaaaeaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaabbaaaaai
ccaabaaaaeaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaabbaaaaai
ecaabaaaaeaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaaaaaaaaah
hcaabaaaacaaaaaaegacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaahicaabaaa
abaaaaaabkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaakicaabaaaabaaaaaa
akaabaaaabaaaaaaakaabaaaabaaaaaadkaabaiaebaaaaaaabaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaaihcaabaaaadaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaadaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaadaaaaaa
egiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaadaaaaaaaaaaaaaj
pcaabaaaaeaaaaaafgafbaiaebaaaaaaadaaaaaaegiocaaaacaaaaaaadaaaaaa
diaaaaahpcaabaaaafaaaaaafgafbaaaabaaaaaaegaobaaaaeaaaaaadiaaaaah
pcaabaaaaeaaaaaaegaobaaaaeaaaaaaegaobaaaaeaaaaaaaaaaaaajpcaabaaa
agaaaaaaagaabaiaebaaaaaaadaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaaj
pcaabaaaadaaaaaakgakbaiaebaaaaaaadaaaaaaegiocaaaacaaaaaaaeaaaaaa
dcaaaaajpcaabaaaafaaaaaaegaobaaaagaaaaaaagaabaaaabaaaaaaegaobaaa
afaaaaaadcaaaaajpcaabaaaabaaaaaaegaobaaaadaaaaaakgakbaaaabaaaaaa
egaobaaaafaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaagaaaaaaegaobaaa
agaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaadaaaaaa
egaobaaaadaaaaaaegaobaaaaeaaaaaaeeaaaaafpcaabaaaaeaaaaaaegaobaaa
adaaaaaadcaaaaanpcaabaaaadaaaaaaegaobaaaadaaaaaaegiocaaaacaaaaaa
afaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaa
adaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaadaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaaeaaaaaadeaaaaak
pcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaaadaaaaaaegaobaaaabaaaaaa
diaaaaaihcaabaaaadaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaahaaaaaa
dcaaaaakhcaabaaaadaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaabaaaaaa
egacbaaaadaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaiaaaaaa
kgakbaaaabaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaa
acaaaaaaajaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaaaaaaaahhccabaaa
adaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, c[2];
MUL R1.xyz, R0, fragment.texcoord[2];
DP3 R1.w, fragment.texcoord[1], c[0];
MUL R0.xyz, R0, c[1];
MAX R1.w, R1, c[3].x;
MUL R0.xyz, R1.w, R0;
MAD result.color.xyz, R0, c[3].y, R1;
MOV result.color.w, R0;
END
# 9 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c3, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
texld r0, t0, s0
mul r1, r0, c2
mul_pp r2.xyz, r1, t2
dp3_pp r0.x, t1, c0
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
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_LightColor0]
Vector 48 [_Color]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedjingjfedchcemmfgfcfaggbifgbgckjcabaaaaaaiaacaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcjaabaaaaeaaaaaaageaaaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaabaaaaaaibcaabaaaaaaaaaaaegbcbaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaaabaaaaaaagijcaaa
aaaaaaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegbcbaaa
adaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadcaaaaajhccabaaa
aaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 8 } };
TEMP R0;
TEMP R1;
TEX R1, fragment.texcoord[1], texture[1], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, c[0];
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R0, R1;
MUL result.color.xyz, R0, c[1].x;
MOV result.color.w, R0;
END
# 7 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xy
texld r0, t1, s1
texld r1, t0, s0
mul_pp r0.xyz, r0.w, r0
mul r1, r1, c0
mul_pp r0.xyz, r1, r0
mul_pp r0.xyz, r0, c1.x
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
ConstBuffer "$Globals" 96
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjchbcmemegjhcigimofnjienmdmbhmgeabaaaaaaciacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfaabaaaaeaaaaaaafeaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaa
egaobaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaadiaaaaahhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
abaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 8 } };
TEMP R0;
TEMP R1;
TEX R1, fragment.texcoord[1], texture[1], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, c[0];
MUL R1.xyz, R1.w, R1;
MUL R0.xyz, R0, R1;
MUL result.color.xyz, R0, c[1].x;
MOV result.color.w, R0;
END
# 7 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 8.00000000, 0, 0, 0
dcl t0.xy
dcl t1.xy
texld r0, t1, s1
texld r1, t0, s0
mul_pp r0.xyz, r0.w, r0
mul r1, r1, c0
mul_pp r0.xyz, r1, r0
mul_pp r0.xyz, r0, c1.x
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
ConstBuffer "$Globals" 96
Vector 48 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjchbcmemegjhcigimofnjienmdmbhmgeabaaaaaaciacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfaabaaaaeaaaaaaafeaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaa
egaobaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaadiaaaaahhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
abaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 0, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TXP R2.x, fragment.texcoord[3], texture[1], 2D;
MUL R0, R0, c[2];
MUL R1.xyz, R0, fragment.texcoord[2];
DP3 R1.w, fragment.texcoord[1], c[0];
MAX R1.w, R1, c[3].x;
MUL R0.xyz, R0, c[1];
MUL R1.w, R1, R2.x;
MUL R0.xyz, R1.w, R0;
MAD result.color.xyz, R0, c[3].y, R1;
MOV result.color.w, R0;
END
# 11 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_WorldSpaceLightPos0]
Vector 1 [_LightColor0]
Vector 2 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xyz
dcl t2.xyz
dcl t3
texld r0, t0, s0
texldp r3, t3, s1
mul r1, r0, c2
mul_pp r2.xyz, r1, c1
dp3_pp r0.x, t1, c0
max_pp r0.x, r0, c3
mul_pp r0.x, r0, r3
mul_pp r0.xyz, r0.x, r2
mul_pp r1.xyz, r1, t2
mov_pp r0.w, r1
mad_pp r0.xyz, r0, c3.y, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 144
Vector 16 [_LightColor0]
Vector 112 [_Color]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
BindCB  "$Globals" 0
BindCB  "UnityLighting" 1
"ps_4_0
eefiecedcegjnhnijpkndilnfakneihaahfkhlcmabaaaaaaaaadaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcpiabaaaaeaaaaaaahoaaaaaafjaaaaaeegiocaaaaaaaaaaaaiaaaaaa
fjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadlcbabaaaaeaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaaeaaaaaa
pgbpbaaaaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
abaaaaaaaagabaaaaaaaaaaabaaaaaaiccaabaaaaaaaaaaaegbcbaaaacaaaaaa
egiccaaaabaaaaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaaaaaaaaaaapaaaaahbcaabaaaaaaaaaaafgafbaaaaaaaaaaaagaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadiaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaadiaaaaaiocaabaaaaaaaaaaaagajbaaaabaaaaaaagijcaaa
aaaaaaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegbcbaaa
adaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadcaaaaajhccabaaa
aaaaaaaajgahbaaaaaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[1], texture[2], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TXP R3.x, fragment.texcoord[2], texture[1], 2D;
MUL R1.xyz, R2.w, R2;
MUL R2.xyz, R2, R3.x;
MUL R1.xyz, R1, c[1].x;
MUL R0, R0, c[0];
MUL R3.xyz, R1, R3.x;
MUL R2.xyz, R2, c[1].y;
MIN R1.xyz, R1, R2;
MAX R1.xyz, R1, R3;
MUL result.color.xyz, R0, R1;
MOV result.color.w, R0;
END
# 13 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, 8.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xy
dcl t2
texld r1, t0, s0
texldp r3, t2, s1
texld r0, t1, s2
mul_pp r2.xyz, r0, r3.x
mul_pp r0.xyz, r0.w, r0
mul r1, r1, c0
mul_pp r0.xyz, r0, c1.x
mul_pp r2.xyz, r2, c1.y
min_pp r2.xyz, r0, r2
mul_pp r0.xyz, r0, r3.x
max_pp r0.xyz, r2, r0
mul_pp r0.xyz, r1, r0
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_ShadowMapTexture] 2D 0
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 160
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjmlmjomdglbcnooojafiekgdnmpnnjflabaaaaaadeadaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapalaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefceeacaaaaeaaaaaaajbaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadlcbabaaaacaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
abaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahocaabaaaaaaaaaaa
fgafbaaaaaaaaaaaagajbaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgapbaaaabaaaaaaddaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagajbaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
deaaaaahhcaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
diaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 8, 2 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R2, fragment.texcoord[1], texture[2], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TXP R3.x, fragment.texcoord[2], texture[1], 2D;
MUL R1.xyz, R2.w, R2;
MUL R2.xyz, R2, R3.x;
MUL R1.xyz, R1, c[1].x;
MUL R0, R0, c[0];
MUL R3.xyz, R1, R3.x;
MUL R2.xyz, R2, c[1].y;
MIN R1.xyz, R1, R2;
MAX R1.xyz, R1, R3;
MUL result.color.xyz, R0, R1;
MOV result.color.w, R0;
END
# 13 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Color]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_ShadowMapTexture] 2D 1
SetTexture 2 [unity_Lightmap] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, 8.00000000, 2.00000000, 0, 0
dcl t0.xy
dcl t1.xy
dcl t2
texld r1, t0, s0
texldp r3, t2, s1
texld r0, t1, s2
mul_pp r2.xyz, r0, r3.x
mul_pp r0.xyz, r0.w, r0
mul r1, r1, c0
mul_pp r0.xyz, r0, c1.x
mul_pp r2.xyz, r2, c1.y
min_pp r2.xyz, r0, r2
mul_pp r0.xyz, r0, r3.x
max_pp r0.xyz, r2, r0
mul_pp r0.xyz, r1, r0
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_ShadowMapTexture] 2D 0
SetTexture 2 [unity_Lightmap] 2D 2
ConstBuffer "$Globals" 160
Vector 112 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjmlmjomdglbcnooojafiekgdnmpnnjflabaaaaaadeadaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaapalaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefceeacaaaaeaaaaaaajbaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagcbaaaadlcbabaaaacaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaa
egbabaaaacaaaaaapgbpbaaaacaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
abaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaadiaaaaahocaabaaaaaaaaaaa
fgafbaaaaaaaaaaaagajbaaaabaaaaaadiaaaaahicaabaaaabaaaaaadkaabaaa
abaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgapbaaaabaaaaaaddaaaaahocaabaaaaaaaaaaafgaobaaaaaaaaaaaagajbaaa
abaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
deaaaaahhcaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
diaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
diaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
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
}
Program "fp" {
SubProgram "opengl " {
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
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
Vector 18 [_MainTex_ST]
Vector 19 [_SnowTex_ST]
Vector 20 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[17].w;
DP3 R0.zw, R1, c[6];
DP3 R4.x, R1, c[5];
DP3 R4.z, R1, c[7];
MOV R4.y, R0.z;
MUL R1, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
MUL R0.x, R0.z, R0.z;
DP4 R3.z, R1, c[15];
DP4 R3.y, R1, c[14];
DP4 R3.x, R1, c[13];
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R2.z, R4, c[12];
DP4 R2.y, R4, c[11];
DP4 R2.x, R4, c[10];
MAD R0.x, R4, R4, -R0;
ADD R3.xyz, R2, R3;
MUL R2.xyz, R0.x, c[16];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[9].x;
ADD result.texcoord[2].xyz, R3, R2;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[4].z, R4;
MOV result.texcoord[4].y, R0.w;
MOV result.texcoord[4].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[19].xyxy, c[19];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[20], c[20].zwzw;
END
# 33 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
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
Vector 18 [_MainTex_ST]
Vector 19 [_SnowTex_ST]
Vector 20 [_MaskTex_ST]
"vs_2_0
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c17.w
dp3 r0.zw, r1, c5
dp3 r4.x, r1, c4
dp3 r4.z, r1, c6
mov r4.y, r0.z
mul r1, r4.xyzz, r4.yzzx
mov r4.w, c21.y
mul r0.x, r0.z, r0.z
dp4 r3.z, r1, c15
dp4 r3.y, r1, c14
dp4 r3.x, r1, c13
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r2.z, r4, c12
dp4 r2.y, r4, c11
dp4 r2.x, r4, c10
mad r0.x, r4, r4, -r0
add r3.xyz, r2, r3
mul r2.xyz, r0.x, c16
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c8.x
add oT2.xyz, r3, r2
mad oT1.xy, r0.z, c9.zwzw, r0
mov oPos, r1
mov oT1.zw, r1
mov oT4.z, r4
mov oT4.y, r0.w
mov oT4.x, r4
mad oT0.zw, v2.xyxy, c19.xyxy, c19
mad oT0.xy, v2, c18, c18.zwzw
mad oT5.xy, v2, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Vector 112 [_MainTex_ST]
Vector 128 [_SnowTex_ST]
Vector 144 [_MaskTex_ST]
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
eefiecedocnllodipknododeokoclfahcnopakababaaaaaadmagaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefciiaeaaaaeaaaabaaccabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
hcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaai
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
lcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaa
abaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaa
aaaaaaaaegadbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaabaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaabaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaabaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaai
bcaabaaaadaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaai
ccaabaaaadaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaai
ecaabaaaadaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahicaabaaa
aaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakicaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaadgaaaaaf
hccabaaaafaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaa
acaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 9 [_Object2World]
Vector 13 [_ProjectionParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_SnowTex_ST]
Vector 19 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[20] = { { 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..19] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[13].x;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
ADD result.texcoord[1].xy, R1, R1.z;
ADD R1.xyz, R0, -c[14];
MUL R0.xyz, vertex.normal, c[15].w;
DP3 result.texcoord[4].z, R0, c[11];
DP3 result.texcoord[4].y, R0, c[10];
DP3 result.texcoord[4].x, R0, c[9];
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[14].w;
DP4 R0.x, vertex.position, c[3];
MUL result.texcoord[3].xyz, R1, c[14].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[17], c[17].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[19], c[19].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[16], c[16].zwzw;
MUL result.texcoord[3].w, -R0.x, R0.y;
END
# 26 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_SnowTex_ST]
Vector 19 [_MaskTex_ST]
"vs_2_0
def c20, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c20.x
mov oPos, r0
mul r1.y, r1, c12.x
mov oT1.zw, r0
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mad oT1.xy, r1.z, c13.zwzw, r1
add r1.xyz, r0, -c14
mul r0.xyz, v1, c15.w
dp3 oT4.z, r0, c10
dp3 oT4.y, r0, c9
dp3 oT4.x, r0, c8
mov r0.x, c14.w
add r0.y, c20, -r0.x
dp4 r0.x, v0, c2
mul oT3.xyz, r1, c14.w
mad oT0.zw, v2.xyxy, c18.xyxy, c18
mad oT0.xy, v2, c17, c17.zwzw
mad oT5.xy, v2, c19, c19.zwzw
mad oT2.xy, v3, c16, c16.zwzw
mul oT3.w, -r0.x, r0.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 208
Vector 112 [unity_LightmapST]
Vector 128 [_MainTex_ST]
Vector 144 [_SnowTex_ST]
Vector 160 [_MaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedncdcicemdliddfojjnhdnlcahkafmabeabaaaaaameagaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcpiaeaaaaeaaaabaadoabaaaafjaaaaaeegiocaaaaaaaaaaa
alaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
bkaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaa
aeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
acaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaa
aaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaacaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaahaaaaaakgiocaaaaaaaaaaaahaaaaaa
diaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaa
diaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaa
aaaaaadpaaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaah
dccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaiaebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaaaeaaaaaa
egacbaaaaaaaaaaapgipcaaaacaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaa
bkbabaaaaaaaaaaackiacaaaadaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaa
ckiacaaaadaaaaaaaeaaaaaaakbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaadaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaa
aaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaa
acaaaaaabjaaaaaaabeaaaaaaaaaiadpdiaaaaaiiccabaaaaeaaaaaabkaabaaa
aaaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
adaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaa
afaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_ProjectionParams]
Vector 10 [unity_Scale]
Vector 11 [unity_LightmapST]
Vector 12 [_MainTex_ST]
Vector 13 [_SnowTex_ST]
Vector 14 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[15] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..14] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[9].x;
ADD result.texcoord[1].xy, R1, R1.z;
MUL R1.xyz, vertex.normal, c[10].w;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
DP3 result.texcoord[4].z, R1, c[7];
DP3 result.texcoord[4].y, R1, c[6];
DP3 result.texcoord[4].x, R1, c[5];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[13].xyxy, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[14], c[14].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[11], c[11].zwzw;
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_Scale]
Vector 11 [unity_LightmapST]
Vector 12 [_MainTex_ST]
Vector 13 [_SnowTex_ST]
Vector 14 [_MaskTex_ST]
"vs_2_0
def c15, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c15.x
mul r1.y, r1, c8.x
mad oT1.xy, r1.z, c9.zwzw, r1
mul r1.xyz, v1, c10.w
mov oPos, r0
mov oT1.zw, r0
dp3 oT4.z, r1, c6
dp3 oT4.y, r1, c5
dp3 oT4.x, r1, c4
mad oT0.zw, v2.xyxy, c13.xyxy, c13
mad oT0.xy, v2, c12, c12.zwzw
mad oT5.xy, v2, c14, c14.zwzw
mad oT2.xy, v3, c11, c11.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 208
Vector 112 [unity_LightmapST]
Vector 128 [_MainTex_ST]
Vector 144 [_SnowTex_ST]
Vector 160 [_MaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedjlhjefjbdhlcaicgnffickieomkjhdlcabaaaaaaniaeaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcceadaaaaeaaaabaamjaaaaaafjaaaaae
egiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaa
acaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaa
aaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaahaaaaaa
kgiocaaaaaaaaaaaahaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaa
akiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaadaaaaaa
kgaobaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaa
abaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
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
Vector 18 [_MainTex_ST]
Vector 19 [_SnowTex_ST]
Vector 20 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[21] = { { 0.5, 1 },
		state.matrix.mvp,
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
MUL R1.xyz, vertex.normal, c[17].w;
DP3 R0.zw, R1, c[6];
DP3 R4.x, R1, c[5];
DP3 R4.z, R1, c[7];
MOV R4.y, R0.z;
MUL R1, R4.xyzz, R4.yzzx;
MOV R4.w, c[0].y;
MUL R0.x, R0.z, R0.z;
DP4 R3.z, R1, c[15];
DP4 R3.y, R1, c[14];
DP4 R3.x, R1, c[13];
DP4 R1.w, vertex.position, c[4];
DP4 R1.z, vertex.position, c[3];
DP4 R2.z, R4, c[12];
DP4 R2.y, R4, c[11];
DP4 R2.x, R4, c[10];
MAD R0.x, R4, R4, -R0;
ADD R3.xyz, R2, R3;
MUL R2.xyz, R0.x, c[16];
DP4 R1.x, vertex.position, c[1];
DP4 R1.y, vertex.position, c[2];
MUL R0.xyz, R1.xyww, c[0].x;
MUL R0.y, R0, c[9].x;
ADD result.texcoord[2].xyz, R3, R2;
ADD result.texcoord[1].xy, R0, R0.z;
MOV result.position, R1;
MOV result.texcoord[1].zw, R1;
MOV result.texcoord[4].z, R4;
MOV result.texcoord[4].y, R0.w;
MOV result.texcoord[4].x, R4;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[19].xyxy, c[19];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[18], c[18].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[20], c[20].zwzw;
END
# 33 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
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
Vector 18 [_MainTex_ST]
Vector 19 [_SnowTex_ST]
Vector 20 [_MaskTex_ST]
"vs_2_0
def c21, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
mul r1.xyz, v1, c17.w
dp3 r0.zw, r1, c5
dp3 r4.x, r1, c4
dp3 r4.z, r1, c6
mov r4.y, r0.z
mul r1, r4.xyzz, r4.yzzx
mov r4.w, c21.y
mul r0.x, r0.z, r0.z
dp4 r3.z, r1, c15
dp4 r3.y, r1, c14
dp4 r3.x, r1, c13
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r2.z, r4, c12
dp4 r2.y, r4, c11
dp4 r2.x, r4, c10
mad r0.x, r4, r4, -r0
add r3.xyz, r2, r3
mul r2.xyz, r0.x, c16
dp4 r1.x, v0, c0
dp4 r1.y, v0, c1
mul r0.xyz, r1.xyww, c21.x
mul r0.y, r0, c8.x
add oT2.xyz, r3, r2
mad oT1.xy, r0.z, c9.zwzw, r0
mov oPos, r1
mov oT1.zw, r1
mov oT4.z, r4
mov oT4.y, r0.w
mov oT4.x, r4
mad oT0.zw, v2.xyxy, c19.xyxy, c19
mad oT0.xy, v2, c18, c18.zwzw
mad oT5.xy, v2, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 176
Vector 112 [_MainTex_ST]
Vector 128 [_SnowTex_ST]
Vector 144 [_MaskTex_ST]
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
eefiecedocnllodipknododeokoclfahcnopakababaaaaaadmagaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefciiaeaaaaeaaaabaaccabaaaafjaaaaae
egiocaaaaaaaaaaaakaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
gfaaaaadhccabaaaafaaaaaagiaaaaacaeaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaahaaaaaa
ogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
hcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaai
hcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaak
lcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaa
abaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaa
aaaaaaaaegadbaaaaaaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadp
bbaaaaaibcaabaaaabaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaa
bbaaaaaiccaabaaaabaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaa
bbaaaaaiecaabaaaabaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaacaaaaaajgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaai
bcaabaaaadaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaai
ccaabaaaadaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaai
ecaabaaaadaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaadaaaaaadiaaaaahicaabaaa
aaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakicaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaadgaaaaaf
hccabaaaafaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaa
acaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 9 [_Object2World]
Vector 13 [_ProjectionParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_SnowTex_ST]
Vector 19 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[20] = { { 0.5, 1 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..19] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
MUL R1.xyz, R0.xyww, c[0].x;
MOV result.position, R0;
MUL R1.y, R1, c[13].x;
MOV result.texcoord[1].zw, R0;
DP4 R0.z, vertex.position, c[11];
DP4 R0.x, vertex.position, c[9];
DP4 R0.y, vertex.position, c[10];
ADD result.texcoord[1].xy, R1, R1.z;
ADD R1.xyz, R0, -c[14];
MUL R0.xyz, vertex.normal, c[15].w;
DP3 result.texcoord[4].z, R0, c[11];
DP3 result.texcoord[4].y, R0, c[10];
DP3 result.texcoord[4].x, R0, c[9];
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[14].w;
DP4 R0.x, vertex.position, c[3];
MUL result.texcoord[3].xyz, R1, c[14].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[18].xyxy, c[18];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[17], c[17].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[19], c[19].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[16], c[16].zwzw;
MUL result.texcoord[3].w, -R0.x, R0.y;
END
# 26 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Matrix 8 [_Object2World]
Vector 12 [_ProjectionParams]
Vector 13 [_ScreenParams]
Vector 14 [unity_ShadowFadeCenterAndType]
Vector 15 [unity_Scale]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_SnowTex_ST]
Vector 19 [_MaskTex_ST]
"vs_2_0
def c20, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c20.x
mov oPos, r0
mul r1.y, r1, c12.x
mov oT1.zw, r0
dp4 r0.z, v0, c10
dp4 r0.x, v0, c8
dp4 r0.y, v0, c9
mad oT1.xy, r1.z, c13.zwzw, r1
add r1.xyz, r0, -c14
mul r0.xyz, v1, c15.w
dp3 oT4.z, r0, c10
dp3 oT4.y, r0, c9
dp3 oT4.x, r0, c8
mov r0.x, c14.w
add r0.y, c20, -r0.x
dp4 r0.x, v0, c2
mul oT3.xyz, r1, c14.w
mad oT0.zw, v2.xyxy, c18.xyxy, c18
mad oT0.xy, v2, c17, c17.zwzw
mad oT5.xy, v2, c19, c19.zwzw
mad oT2.xy, v3, c16, c16.zwzw
mul oT3.w, -r0.x, r0.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 208
Vector 112 [unity_LightmapST]
Vector 128 [_MainTex_ST]
Vector 144 [_SnowTex_ST]
Vector 160 [_MaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedncdcicemdliddfojjnhdnlcahkafmabeabaaaaaameagaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcpiaeaaaaeaaaabaadoabaaaafjaaaaaeegiocaaaaaaaaaaa
alaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
bkaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaa
aeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadhccabaaaafaaaaaagiaaaaac
acaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaa
aaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaadaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadcaaaaalmccabaaaacaaaaaa
agbebaaaaeaaaaaaagiecaaaaaaaaaaaahaaaaaakgiocaaaaaaaaaaaahaaaaaa
diaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaa
diaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaa
aaaaaadpaaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaah
dccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaaihcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaiaebaaaaaaacaaaaaabjaaaaaadiaaaaaihccabaaaaeaaaaaa
egacbaaaaaaaaaaapgipcaaaacaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaa
bkbabaaaaaaaaaaackiacaaaadaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaa
ckiacaaaadaaaaaaaeaaaaaaakbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaadaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaa
aaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaa
acaaaaaabjaaaaaaabeaaaaaaaaaiadpdiaaaaaiiccabaaaaeaaaaaabkaabaaa
aaaaaaaaakaabaiaebaaaaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
adaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaa
afaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
doaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 5 [_Object2World]
Vector 9 [_ProjectionParams]
Vector 10 [unity_Scale]
Vector 11 [unity_LightmapST]
Vector 12 [_MainTex_ST]
Vector 13 [_SnowTex_ST]
Vector 14 [_MaskTex_ST]
"!!ARBvp1.0
PARAM c[15] = { { 0.5 },
		state.matrix.mvp,
		program.local[5..14] };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[4];
DP4 R0.z, vertex.position, c[3];
DP4 R0.x, vertex.position, c[1];
DP4 R0.y, vertex.position, c[2];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[9].x;
ADD result.texcoord[1].xy, R1, R1.z;
MUL R1.xyz, vertex.normal, c[10].w;
MOV result.position, R0;
MOV result.texcoord[1].zw, R0;
DP3 result.texcoord[4].z, R1, c[7];
DP3 result.texcoord[4].y, R1, c[6];
DP3 result.texcoord[4].x, R1, c[5];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[13].xyxy, c[13];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[0], c[14], c[14].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[1], c[11], c[11].zwzw;
END
# 17 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [unity_Scale]
Vector 11 [unity_LightmapST]
Vector 12 [_MainTex_ST]
Vector 13 [_SnowTex_ST]
Vector 14 [_MaskTex_ST]
"vs_2_0
def c15, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dcl_texcoord0 v2
dcl_texcoord1 v3
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.x, v0, c0
dp4 r0.y, v0, c1
mul r1.xyz, r0.xyww, c15.x
mul r1.y, r1, c8.x
mad oT1.xy, r1.z, c9.zwzw, r1
mul r1.xyz, v1, c10.w
mov oPos, r0
mov oT1.zw, r0
dp3 oT4.z, r1, c6
dp3 oT4.y, r1, c5
dp3 oT4.x, r1, c4
mad oT0.zw, v2.xyxy, c13.xyxy, c13
mad oT0.xy, v2, c12, c12.zwzw
mad oT5.xy, v2, c14, c14.zwzw
mad oT2.xy, v3, c11, c11.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 208
Vector 112 [unity_LightmapST]
Vector 128 [_MainTex_ST]
Vector 144 [_SnowTex_ST]
Vector 160 [_MaskTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedjlhjefjbdhlcaicgnffickieomkjhdlcabaaaaaaniaeaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaafaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcceadaaaaeaaaabaamjaaaaaafjaaaaae
egiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaa
acaaaaaagfaaaaadmccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaiaaaaaaogikcaaa
aaaaaaaaaiaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaa
aaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaahaaaaaa
kgiocaaaaaaaaaaaahaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaa
akiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaadaaaaaa
kgaobaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaa
abaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaacaaaaaa
anaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaaacaaaaaaamaaaaaaagaabaaa
aaaaaaaaegaibaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaacaaaaaa
aoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[6] = { program.local[0..4],
		{ 0.5, 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TXP R0.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R4.x, fragment.texcoord[5], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TEX R2.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
MUL R1, R1, c[0];
MUL R2.xyz, R2, c[1];
ADD R3.xyz, R1, -R2;
ADD R0.w, -R4.x, c[5].z;
MUL R3.xyz, R0.w, R3;
ADD R4.xyz, R2, R3;
ADD R6.xyz, R1, -R4;
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MOV R1.xz, c[2];
MOV R1.y, -c[2];
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R5.xyz, R2.w, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[4];
DP3 R1.x, R1, R5;
MOV R0.w, c[5].x;
MUL R1.y, R0.w, c[4].x;
MAD R0.w, R1.x, c[5].x, c[5].x;
ADD R1.x, -R1.y, c[3];
RCP R2.w, R1.y;
ADD R1.x, R0.w, -R1;
MUL_SAT R1.x, R1, R2.w;
ADD R3.w, R0, -c[3].x;
ADD R1.x, -R1, c[5].z;
MUL_SAT R2.w, R2, R3;
SLT R0.w, c[3].x, R0;
ADD R2.w, -R2, c[5].z;
ABS R0.w, R0;
MAD R1.xyz, R1.x, R6, R4;
MAD R2.xyz, R3, R2.w, R2;
CMP R0.w, -R0, c[5].y, c[5].z;
LG2 R0.x, R0.x;
LG2 R0.z, R0.z;
LG2 R0.y, R0.y;
ADD R0.xyz, -R0, fragment.texcoord[2];
CMP R1.xyz, -R0.w, R1, R2;
MUL result.color.xyz, R1, R0;
MOV result.color.w, R1;
END
# 43 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c5, 0.00000000, 1.00000000, 0.50000000, 0
dcl t0
dcl t5.xy
dcl t1
dcl t2.xyz
dcl t4.xyz
texld r2, t5, s2
texldp r4, t1, s3
mov r0.y, t0.w
mov r0.x, t0.z
mov r1.xy, r0
mov r2.y, -c2
texld r1, r1, s1
texld r0, t0, s0
mul r5.xyz, r1, c1
mul r1, r0, c0
add r0.x, -r2, c5.y
add_pp r3.xyz, r1, -r5
mul_pp r6.xyz, r0.x, r3
add_pp r7.xyz, r5, r6
mov r2.xz, c2
dp3 r0.x, r2, r2
add r8.xyz, r1, -r7
rsq r1.x, r0.x
mul r2.xyz, r1.x, r2
dp3 r0.x, t4, t4
rsq r1.x, r0.x
mul r3.xyz, r1.x, t4
mov r0.x, c4
mul r1.x, c5.z, r0
dp3 r0.x, r3, r2
mad r0.x, r0, c5.z, c5.z
add r2.x, -r1, c3
rcp r1.x, r1.x
add r2.x, r0, -r2
add r3.x, r0, -c3
mul_sat r2.x, r2, r1
mul_sat r3.x, r1, r3
add r1.x, -r3, c5.y
add r2.x, -r2, c5.y
add r0.x, -r0, c3
cmp r0.x, r0, c5, c5.y
mad r2.xyz, r2.x, r8, r7
mad r1.xyz, r6, r1.x, r5
abs_pp r0.x, r0
log_pp r3.x, r4.x
log_pp r3.z, r4.z
log_pp r3.y, r4.y
add_pp r3.xyz, -r3, t2
cmp_pp r0.xyz, -r0.x, r2, r1
mul_pp r0.xyz, r0, r3
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
ConstBuffer "$Globals" 176
Vector 48 [_Color]
Vector 64 [_SnowColor]
Vector 80 [_SnowDirection]
Float 96 [_SplitValue]
Float 100 [_TransformWidth]
BindCB  "$Globals" 0
"ps_4_0
eefiecedpjhjodkjnjkbbfncpgdmjcenfmhomgmiabaaaaaapaagaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapalaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcnaafaaaa
eaaaaaaaheabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadlcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaa
afaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaaeeaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaa
afaaaaaadiaaaaalhcaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaaaceaaaaa
aaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaaifcaabaaaabaaaaaapgapbaaaaaaaaaaaagiccaaaaaaaaaaaafaaaaaa
diaaaaajccaabaaaabaaaaaadkaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaa
afaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaa
aaaaaadpdcaaaaamccaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaagaaaaaa
abeaaaaaaaaaaadpakiacaaaaaaaaaaaagaaaaaaaaaaaaaiecaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaaakiacaaaaaaaaaaaagaaaaaaaocaaaahccaabaaa
aaaaaaaackaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaaaaaaaaaiecaabaaa
aaaaaaaaakaabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaai
hcaabaaaacaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaaeaaaaaaefaaaaaj
pcaabaaaadaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaalhcaabaaaaeaaaaaaegacbaaaadaaaaaaegiccaaaaaaaaaaaadaaaaaa
egacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaaeaaaaaakgakbaaaaaaaaaaa
egacbaaaaeaaaaaadcaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaaeaaaaaaegacbaaaaeaaaaaadcaaaaalhcaabaaaadaaaaaaegacbaaa
adaaaaaaegiccaaaaaaaaaaaadaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaaj
ocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaaadaaaaaaagajbaaaabaaaaaa
diaaaaaibcaabaaaabaaaaaadkaabaaaadaaaaaadkiacaaaaaaaaaaaadaaaaaa
dgaaaaaficcabaaaaaaaaaaaakaabaaaabaaaaaadbaaaaaibcaabaaaabaaaaaa
akiacaaaaaaaaaaaagaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaiaebaaaaaaaaaaaaaaagaaaaaadiaaaaaiccaabaaa
abaaaaaabkiacaaaaaaaaaaaagaaaaaaabeaaaaaaaaaaadpaocaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaabkaabaaaabaaaaaaaaaaaaaibcaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaajocaabaaaabaaaaaa
agaabaaaaaaaaaaaagajbaaaaeaaaaaaagajbaaaacaaaaaadhaaaaajhcaabaaa
aaaaaaaaagaabaaaabaaaaaajgahbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaah
dcaabaaaabaaaaaaegbabaaaadaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaacpaaaaaf
hcaabaaaabaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaia
ebaaaaaaabaaaaaaegbcbaaaaeaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
Vector 5 [unity_LightmapFade]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[7] = { program.local[0..5],
		{ 0.5, 0, 1, 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
TEX R0, fragment.texcoord[2], texture[4], 2D;
TEX R4.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R5.x, fragment.texcoord[5], texture[2], 2D;
TEX R1, fragment.texcoord[2], texture[5], 2D;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TXP R3.xyz, fragment.texcoord[1], texture[3], 2D;
MUL R2, R2, c[0];
MUL R6.xyz, R4, c[1];
MUL R0.xyz, R0.w, R0;
DP4 R0.w, fragment.texcoord[3], fragment.texcoord[3];
MUL R1.xyz, R1.w, R1;
MUL R1.xyz, R1, c[6].w;
RSQ R0.w, R0.w;
RCP R0.w, R0.w;
MAD R0.xyz, R0, c[6].w, -R1;
MAD_SAT R0.w, R0, c[5].z, c[5];
MAD R0.xyz, R0.w, R0, R1;
ADD R4.xyz, R2, -R6;
ADD R3.w, -R5.x, c[6].z;
MUL R7.xyz, R3.w, R4;
ADD R8.xyz, R6, R7;
DP3 R3.w, fragment.texcoord[4], fragment.texcoord[4];
MOV R4.xz, c[2];
MOV R4.y, -c[2];
DP3 R4.w, R4, R4;
RSQ R4.w, R4.w;
RSQ R3.w, R3.w;
MUL R5.xyz, R4.w, R4;
MUL R4.xyz, R3.w, fragment.texcoord[4];
DP3 R4.x, R4, R5;
MOV R3.w, c[6].x;
MUL R4.y, R3.w, c[4].x;
MAD R3.w, R4.x, c[6].x, c[6].x;
RCP R4.x, R4.y;
ADD R4.z, -R4.y, c[3].x;
ADD R4.y, R3.w, -R4.z;
MUL_SAT R4.y, R4, R4.x;
ADD R0.w, R3, -c[3].x;
LG2 R1.x, R3.x;
LG2 R1.y, R3.y;
LG2 R1.z, R3.z;
ADD R0.xyz, -R1, R0;
MUL_SAT R1.x, R4, R0.w;
SLT R0.w, c[3].x, R3;
ADD R1.x, -R1, c[6].z;
ABS R0.w, R0;
ADD R2.xyz, R2, -R8;
ADD R4.y, -R4, c[6].z;
MAD R2.xyz, R4.y, R2, R8;
MAD R1.xyz, R7, R1.x, R6;
CMP R0.w, -R0, c[6].y, c[6].z;
CMP R1.xyz, -R0.w, R2, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, R2;
END
# 54 instructions, 9 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
Vector 5 [unity_LightmapFade]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
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
def c6, 0.00000000, 1.00000000, 0.50000000, 8.00000000
dcl t0
dcl t5.xy
dcl t1
dcl t2.xy
dcl t3
dcl t4.xyz
texld r1, t5, s2
texldp r6, t1, s3
texld r3, t2, s5
texld r4, t2, s4
mul_pp r3.xyz, r3.w, r3
mov r0.y, t0.w
mov r0.x, t0.z
mov r2.xy, r0
mul_pp r3.xyz, r3, c6.w
mul_pp r4.xyz, r4.w, r4
mad_pp r4.xyz, r4, c6.w, -r3
texld r0, t0, s0
texld r2, r2, s1
mul r5, r0, c0
mul r7.xyz, r2, c1
add_pp r2.xyz, r5, -r7
add r0.x, -r1, c6.y
mul_pp r8.xyz, r0.x, r2
add_pp r9.xyz, r7, r8
dp3 r0.x, t4, t4
mov r2.xz, c2
mov r2.y, -c2
dp3 r1.x, r2, r2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
rsq r0.x, r0.x
mul r2.xyz, r0.x, t4
dp3 r2.x, r2, r1
mov r0.x, c4
mul r1.x, c6.z, r0
mad r0.x, r2, c6.z, c6.z
add r2.x, -r1, c3
rcp r1.x, r1.x
add r2.x, r0, -r2
mul_sat r2.x, r2, r1
add r2.x, -r2, c6.y
add r5.xyz, r5, -r9
mad r5.xyz, r2.x, r5, r9
dp4 r2.x, t3, t3
rsq r2.x, r2.x
rcp r2.x, r2.x
mad_sat r2.x, r2, c5.z, c5.w
mad_pp r3.xyz, r2.x, r4, r3
add r2.x, r0, -c3
mul_sat r1.x, r1, r2
add r0.x, -r0, c3
add r1.x, -r1, c6.y
cmp r0.x, r0, c6, c6.y
log_pp r4.x, r6.x
log_pp r4.y, r6.y
log_pp r4.z, r6.z
add_pp r3.xyz, -r4, r3
mad r1.xyz, r8, r1.x, r7
abs_pp r0.x, r0
cmp_pp r0.xyz, -r0.x, r5, r1
mul_pp r0.xyz, r0, r3
mov_pp r0.w, r5
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
ConstBuffer "$Globals" 208
Vector 48 [_Color]
Vector 64 [_SnowColor]
Vector 80 [_SnowDirection]
Float 96 [_SplitValue]
Float 100 [_TransformWidth]
Vector 176 [unity_LightmapFade]
BindCB  "$Globals" 0
"ps_4_0
eefiecedbomafbpjliphbbmaahhakebaaibcloanabaaaaaajaaiaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaalmaaaaaa
abaaaaaaaaaaaaaaadaaaaaaadaaaaaaapalaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapapaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfiahaaaaeaaaaaaangabaaaa
fjaaaaaeegiocaaaaaaaaaaaamaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaa
fkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaa
aeaaaaaaffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaad
lcbabaaaadaaaaaagcbaaaadpcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaafaaaaaaegbcbaaaafaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaafaaaaaa
diaaaaalhcaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaialpaaaaiadpaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaai
fcaabaaaabaaaaaapgapbaaaaaaaaaaaagiccaaaaaaaaaaaafaaaaaadiaaaaaj
ccaabaaaabaaaaaadkaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaj
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadp
dcaaaaamccaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaaadpakiacaaaaaaaaaaaagaaaaaaaaaaaaaiecaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakiacaaaaaaaaaaaagaaaaaaaocaaaahccaabaaaaaaaaaaa
ckaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaaegbabaaa
acaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaaaaaaaaaiecaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaa
acaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaa
adaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaal
hcaabaaaaeaaaaaaegacbaaaadaaaaaaegiccaaaaaaaaaaaadaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaeaaaaaakgakbaaaaaaaaaaaegacbaaa
aeaaaaaadcaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
aeaaaaaaegacbaaaaeaaaaaadcaaaaalhcaabaaaadaaaaaaegacbaaaadaaaaaa
egiccaaaaaaaaaaaadaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaajocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagajbaaaadaaaaaaagajbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaadkaabaaaadaaaaaadkiacaaaaaaaaaaaadaaaaaadgaaaaaf
iccabaaaaaaaaaaaakaabaaaabaaaaaadbaaaaaibcaabaaaabaaaaaaakiacaaa
aaaaaaaaagaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaiaebaaaaaaaaaaaaaaagaaaaaadiaaaaaiccaabaaaabaaaaaa
bkiacaaaaaaaaaaaagaaaaaaabeaaaaaaaaaaadpaocaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaabaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaajocaabaaaabaaaaaaagaabaaa
aaaaaaaaagajbaaaaeaaaaaaagajbaaaacaaaaaadhaaaaajhcaabaaaaaaaaaaa
agaabaaaabaaaaaajgahbaaaabaaaaaajgahbaaaaaaaaaaabbaaaaahicaabaaa
aaaaaaaaegbobaaaaeaaaaaaegbobaaaaeaaaaaaelaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadccaaaalicaabaaaaaaaaaaadkaabaaaaaaaaaaackiacaaa
aaaaaaaaalaaaaaadkiacaaaaaaaaaaaalaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadiaaaaahicaabaaa
abaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaapgapbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaa
acaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaabaaaaaa
dkaabaaaacaaaaaaabeaaaaaaaaaaaebdcaaaaakhcaabaaaacaaaaaapgapbaaa
abaaaaaaegacbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaajhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaaaoaaaaah
dcaabaaaacaaaaaaegbabaaaadaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaacpaaaaaf
hcaabaaaacaaaaaaegacbaaaacaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaiaebaaaaaaacaaaaaadiaaaaahhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[6] = { program.local[0..4],
		{ 0.5, 0, 1, 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TXP R2.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R0, fragment.texcoord[2], texture[4], 2D;
TEX R3.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R4.x, fragment.texcoord[5], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
MUL R1, R1, c[0];
MUL R5.xyz, R3, c[1];
ADD R3.xyz, R1, -R5;
ADD R2.w, -R4.x, c[5].z;
MUL R6.xyz, R2.w, R3;
ADD R7.xyz, R5, R6;
DP3 R2.w, fragment.texcoord[4], fragment.texcoord[4];
MOV R3.xz, c[2];
MOV R3.y, -c[2];
DP3 R3.w, R3, R3;
RSQ R3.w, R3.w;
RSQ R2.w, R2.w;
MUL R4.xyz, R3.w, R3;
MUL R3.xyz, R2.w, fragment.texcoord[4];
DP3 R3.x, R3, R4;
MOV R2.w, c[5].x;
MUL R3.y, R2.w, c[4].x;
MAD R2.w, R3.x, c[5].x, c[5].x;
MUL R0.xyz, R0.w, R0;
SLT R0.w, c[3].x, R2;
ABS R0.w, R0;
RCP R3.x, R3.y;
ADD R3.z, -R3.y, c[3].x;
ADD R3.y, R2.w, -R3.z;
MUL_SAT R3.y, R3, R3.x;
ADD R3.y, -R3, c[5].z;
ADD R1.xyz, R1, -R7;
MAD R1.xyz, R3.y, R1, R7;
LG2 R2.x, R2.x;
LG2 R2.z, R2.z;
LG2 R2.y, R2.y;
MAD R0.xyz, R0, c[5].w, -R2;
ADD R3.y, R2.w, -c[3].x;
MUL_SAT R2.x, R3, R3.y;
ADD R2.x, -R2, c[5].z;
MAD R2.xyz, R6, R2.x, R5;
CMP R0.w, -R0, c[5].y, c[5].z;
CMP R1.xyz, -R0.w, R1, R2;
MUL result.color.xyz, R1, R0;
MOV result.color.w, R1;
END
# 45 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c5, 0.00000000, 1.00000000, 0.50000000, 8.00000000
dcl t0
dcl t5.xy
dcl t1
dcl t2.xy
dcl t4.xyz
texld r1, t5, s2
texldp r5, t1, s3
texld r4, t2, s4
mov r0.y, t0.w
mov r0.x, t0.z
mov r2.xy, r0
add r1.x, -r1, c5.y
texld r0, t0, s0
texld r2, r2, s1
mul r0, r0, c0
mul r6.xyz, r2, c1
add_pp r2.xyz, r0, -r6
mul_pp r7.xyz, r1.x, r2
add_pp r8.xyz, r6, r7
add r9.xyz, r0, -r8
dp3 r0.x, t4, t4
rsq r0.x, r0.x
mov r2.xz, c2
mov r2.y, -c2
dp3 r1.x, r2, r2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.x, t4
dp3 r0.x, r0, r1
mov r1.x, c4
mul r2.x, c5.z, r1
mad r0.x, r0, c5.z, c5.z
add r3.x, -r2, c3
rcp r2.x, r2.x
add r1.x, r0, -c3
add r3.x, r0, -r3
mul_sat r1.x, r2, r1
mul_sat r3.x, r3, r2
add r2.x, -r3, c5.y
mul_pp r3.xyz, r4.w, r4
add r1.x, -r1, c5.y
add r0.x, -r0, c3
cmp r0.x, r0, c5, c5.y
mad r2.xyz, r2.x, r9, r8
mad r1.xyz, r7, r1.x, r6
abs_pp r0.x, r0
log_pp r4.x, r5.x
log_pp r4.z, r5.z
log_pp r4.y, r5.y
mad_pp r3.xyz, r3, c5.w, -r4
cmp_pp r0.xyz, -r0.x, r2, r1
mul_pp r0.xyz, r0, r3
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 208
Vector 48 [_Color]
Vector 64 [_SnowColor]
Vector 80 [_SnowDirection]
Float 96 [_SplitValue]
Float 100 [_TransformWidth]
BindCB  "$Globals" 0
"ps_4_0
eefiecedegfncjbkmdjlgcgkhipkbjkeogiggomlabaaaaaafeahaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaakeaaaaaa
abaaaaaaaaaaaaaaadaaaaaaadaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdeagaaaa
eaaaaaaainabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaad
mcbabaaaacaaaaaagcbaaaadlcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaaeaaaaaa
diaaaaalhcaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaialpaaaaiadpaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaai
fcaabaaaabaaaaaapgapbaaaaaaaaaaaagiccaaaaaaaaaaaafaaaaaadiaaaaaj
ccaabaaaabaaaaaadkaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaj
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadp
dcaaaaamccaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaaadpakiacaaaaaaaaaaaagaaaaaaaaaaaaaiecaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakiacaaaaaaaaaaaagaaaaaaaocaaaahccaabaaaaaaaaaaa
ckaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaaegbabaaa
acaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaaaaaaaaaiecaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaa
acaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaa
adaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaal
hcaabaaaaeaaaaaaegacbaaaadaaaaaaegiccaaaaaaaaaaaadaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaeaaaaaakgakbaaaaaaaaaaaegacbaaa
aeaaaaaadcaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
aeaaaaaaegacbaaaaeaaaaaadcaaaaalhcaabaaaadaaaaaaegacbaaaadaaaaaa
egiccaaaaaaaaaaaadaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaajocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagajbaaaadaaaaaaagajbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaadkaabaaaadaaaaaadkiacaaaaaaaaaaaadaaaaaadgaaaaaf
iccabaaaaaaaaaaaakaabaaaabaaaaaadbaaaaaibcaabaaaabaaaaaaakiacaaa
aaaaaaaaagaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaiaebaaaaaaaaaaaaaaagaaaaaadiaaaaaiccaabaaaabaaaaaa
bkiacaaaaaaaaaaaagaaaaaaabeaaaaaaaaaaadpaocaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaabaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaajocaabaaaabaaaaaaagaabaaa
aaaaaaaaagajbaaaaeaaaaaaagajbaaaacaaaaaadhaaaaajhcaabaaaaaaaaaaa
agaabaaaabaaaaaajgahbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaahdcaabaaa
abaaaaaaegbabaaaadaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaacpaaaaafhcaabaaa
abaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaacaaaaaa
eghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaa
acaaaaaaabeaaaaaaaaaaaebdcaaaaakhcaabaaaabaaaaaapgapbaaaaaaaaaaa
egacbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadiaaaaahhccabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[6] = { program.local[0..4],
		{ 0.5, 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEX R4.x, fragment.texcoord[5], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TXP R0.xyz, fragment.texcoord[1], texture[3], 2D;
TEX R2.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
MUL R1, R1, c[0];
MUL R2.xyz, R2, c[1];
ADD R3.xyz, R1, -R2;
ADD R0.w, -R4.x, c[5].z;
MUL R3.xyz, R0.w, R3;
ADD R4.xyz, R2, R3;
ADD R6.xyz, R1, -R4;
DP3 R0.w, fragment.texcoord[4], fragment.texcoord[4];
MOV R1.xz, c[2];
MOV R1.y, -c[2];
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R5.xyz, R2.w, R1;
RSQ R0.w, R0.w;
MUL R1.xyz, R0.w, fragment.texcoord[4];
DP3 R1.x, R1, R5;
MOV R0.w, c[5].x;
MUL R1.y, R0.w, c[4].x;
MAD R0.w, R1.x, c[5].x, c[5].x;
ADD R1.x, -R1.y, c[3];
RCP R2.w, R1.y;
ADD R1.x, R0.w, -R1;
MUL_SAT R1.x, R1, R2.w;
ADD R3.w, R0, -c[3].x;
ADD R1.x, -R1, c[5].z;
MUL_SAT R2.w, R2, R3;
SLT R0.w, c[3].x, R0;
ADD R2.w, -R2, c[5].z;
ABS R0.w, R0;
MAD R1.xyz, R1.x, R6, R4;
MAD R2.xyz, R3, R2.w, R2;
CMP R0.w, -R0, c[5].y, c[5].z;
ADD R0.xyz, R0, fragment.texcoord[2];
CMP R1.xyz, -R0.w, R1, R2;
MUL result.color.xyz, R1, R0;
MOV result.color.w, R1;
END
# 40 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c5, 0.00000000, 1.00000000, 0.50000000, 0
dcl t0
dcl t5.xy
dcl t1
dcl t2.xyz
dcl t4.xyz
texld r1, t5, s2
texldp r4, t1, s3
mov r0.y, t0.w
mov r0.x, t0.z
mov r2.xy, r0
add r1.x, -r1, c5.y
texld r0, t0, s0
texld r2, r2, s1
mul r0, r0, c0
mul r5.xyz, r2, c1
add_pp r2.xyz, r0, -r5
mul_pp r6.xyz, r1.x, r2
add_pp r7.xyz, r5, r6
add r8.xyz, r0, -r7
dp3 r0.x, t4, t4
rsq r0.x, r0.x
mov r2.xz, c2
mov r2.y, -c2
dp3 r1.x, r2, r2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.x, t4
dp3 r0.x, r0, r1
mov r1.x, c4
mul r2.x, c5.z, r1
mad r0.x, r0, c5.z, c5.z
add r3.x, -r2, c3
rcp r2.x, r2.x
add r1.x, r0, -c3
add r3.x, r0, -r3
mul_sat r1.x, r2, r1
mul_sat r3.x, r3, r2
add r2.x, -r3, c5.y
add r1.x, -r1, c5.y
add r0.x, -r0, c3
cmp r0.x, r0, c5, c5.y
mad r2.xyz, r2.x, r8, r7
mad r1.xyz, r6, r1.x, r5
abs_pp r0.x, r0
add_pp r3.xyz, r4, t2
cmp_pp r0.xyz, -r0.x, r2, r1
mul_pp r0.xyz, r0, r3
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
ConstBuffer "$Globals" 176
Vector 48 [_Color]
Vector 64 [_SnowColor]
Vector 80 [_SnowDirection]
Float 96 [_SplitValue]
Float 100 [_TransformWidth]
BindCB  "$Globals" 0
"ps_4_0
eefiecediokkehdlonfpdehlopkoobnagnhcpnbjabaaaaaaniagaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapalaaaakeaaaaaa
acaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcliafaaaa
eaaaaaaagoabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaa
gcbaaaadlcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadhcbabaaa
afaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaafaaaaaaegbcbaaaafaaaaaaeeaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaa
afaaaaaadiaaaaalhcaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaaaceaaaaa
aaaaiadpaaaaialpaaaaiadpaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaaifcaabaaaabaaaaaapgapbaaaaaaaaaaaagiccaaaaaaaaaaaafaaaaaa
diaaaaajccaabaaaabaaaaaadkaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaa
afaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaa
aaaaaadpdcaaaaamccaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaagaaaaaa
abeaaaaaaaaaaadpakiacaaaaaaaaaaaagaaaaaaaaaaaaaiecaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaaakiacaaaaaaaaaaaagaaaaaaaocaaaahccaabaaa
aaaaaaaackaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaaaaaaaaaiecaabaaa
aaaaaaaaakaabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaai
hcaabaaaacaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaaeaaaaaaefaaaaaj
pcaabaaaadaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaalhcaabaaaaeaaaaaaegacbaaaadaaaaaaegiccaaaaaaaaaaaadaaaaaa
egacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaaeaaaaaakgakbaaaaaaaaaaa
egacbaaaaeaaaaaadcaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaaeaaaaaaegacbaaaaeaaaaaadcaaaaalhcaabaaaadaaaaaaegacbaaa
adaaaaaaegiccaaaaaaaaaaaadaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaaj
ocaabaaaaaaaaaaafgafbaaaaaaaaaaaagajbaaaadaaaaaaagajbaaaabaaaaaa
diaaaaaibcaabaaaabaaaaaadkaabaaaadaaaaaadkiacaaaaaaaaaaaadaaaaaa
dgaaaaaficcabaaaaaaaaaaaakaabaaaabaaaaaadbaaaaaibcaabaaaabaaaaaa
akiacaaaaaaaaaaaagaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaiaebaaaaaaaaaaaaaaagaaaaaadiaaaaaiccaabaaa
abaaaaaabkiacaaaaaaaaaaaagaaaaaaabeaaaaaaaaaaadpaocaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaabkaabaaaabaaaaaaaaaaaaaibcaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaajocaabaaaabaaaaaa
agaabaaaaaaaaaaaagajbaaaaeaaaaaaagajbaaaacaaaaaadhaaaaajhcaabaaa
aaaaaaaaagaabaaaabaaaaaajgahbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaah
dcaabaaaabaaaaaaegbabaaaadaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegbcbaaaaeaaaaaadiaaaaahhccabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
Vector 5 [unity_LightmapFade]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[7] = { program.local[0..5],
		{ 0.5, 0, 1, 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
TEX R0, fragment.texcoord[2], texture[4], 2D;
TEX R4.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R5.x, fragment.texcoord[5], texture[2], 2D;
TEX R1, fragment.texcoord[2], texture[5], 2D;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TXP R3.xyz, fragment.texcoord[1], texture[3], 2D;
MUL R2, R2, c[0];
MUL R6.xyz, R4, c[1];
MUL R0.xyz, R0.w, R0;
DP4 R0.w, fragment.texcoord[3], fragment.texcoord[3];
MUL R1.xyz, R1.w, R1;
MUL R1.xyz, R1, c[6].w;
RSQ R0.w, R0.w;
RCP R0.w, R0.w;
ADD R4.xyz, R2, -R6;
ADD R3.w, -R5.x, c[6].z;
MUL R7.xyz, R3.w, R4;
ADD R8.xyz, R6, R7;
DP3 R3.w, fragment.texcoord[4], fragment.texcoord[4];
MAD R0.xyz, R0, c[6].w, -R1;
MAD_SAT R0.w, R0, c[5].z, c[5];
MAD R0.xyz, R0.w, R0, R1;
MOV R4.xz, c[2];
MOV R4.y, -c[2];
DP3 R4.w, R4, R4;
RSQ R4.w, R4.w;
RSQ R3.w, R3.w;
MUL R5.xyz, R4.w, R4;
MUL R4.xyz, R3.w, fragment.texcoord[4];
DP3 R4.x, R4, R5;
MOV R3.w, c[6].x;
MUL R4.y, R3.w, c[4].x;
MAD R3.w, R4.x, c[6].x, c[6].x;
RCP R4.x, R4.y;
ADD R0.w, R3, -c[3].x;
MUL_SAT R1.x, R4, R0.w;
ADD R4.z, -R4.y, c[3].x;
ADD R4.y, R3.w, -R4.z;
MUL_SAT R4.y, R4, R4.x;
SLT R0.w, c[3].x, R3;
ADD R1.x, -R1, c[6].z;
ABS R0.w, R0;
ADD R2.xyz, R2, -R8;
ADD R4.y, -R4, c[6].z;
MAD R2.xyz, R4.y, R2, R8;
ADD R0.xyz, R3, R0;
MAD R1.xyz, R7, R1.x, R6;
CMP R0.w, -R0, c[6].y, c[6].z;
CMP R1.xyz, -R0.w, R2, R1;
MUL result.color.xyz, R1, R0;
MOV result.color.w, R2;
END
# 51 instructions, 9 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
Vector 5 [unity_LightmapFade]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
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
def c6, 0.00000000, 1.00000000, 0.50000000, 8.00000000
dcl t0
dcl t5.xy
dcl t1
dcl t2.xy
dcl t3
dcl t4.xyz
texld r2, t5, s2
texldp r6, t1, s3
texld r4, t2, s5
texld r5, t2, s4
mul_pp r4.xyz, r4.w, r4
mov r0.y, t0.w
mov r0.x, t0.z
mov r1.xy, r0
mov r2.y, -c2
mul_pp r4.xyz, r4, c6.w
mul_pp r5.xyz, r5.w, r5
mad_pp r5.xyz, r5, c6.w, -r4
texld r1, r1, s1
texld r0, t0, s0
mul r7.xyz, r1, c1
mul r1, r0, c0
add r0.x, -r2, c6.y
add_pp r3.xyz, r1, -r7
mul_pp r8.xyz, r0.x, r3
add_pp r9.xyz, r7, r8
mov r2.xz, c2
dp3 r0.x, r2, r2
add r10.xyz, r1, -r9
rsq r1.x, r0.x
mul r2.xyz, r1.x, r2
dp3 r0.x, t4, t4
rsq r1.x, r0.x
mul r3.xyz, r1.x, t4
mov r0.x, c4
mul r1.x, c6.z, r0
dp3 r0.x, r3, r2
mad r0.x, r0, c6.z, c6.z
add r2.x, -r1, c3
rcp r1.x, r1.x
add r2.x, r0, -r2
add r3.x, r0, -c3
mul_sat r2.x, r2, r1
mul_sat r3.x, r1, r3
add r1.x, -r3, c6.y
mad r3.xyz, r8, r1.x, r7
add r2.x, -r2, c6.y
dp4 r1.x, t3, t3
rsq r1.x, r1.x
rcp r1.x, r1.x
add r0.x, -r0, c3
mad_sat r1.x, r1, c5.z, c5.w
mad_pp r1.xyz, r1.x, r5, r4
cmp r0.x, r0, c6, c6.y
mad r2.xyz, r2.x, r10, r9
abs_pp r0.x, r0
add_pp r1.xyz, r6, r1
cmp_pp r0.xyz, -r0.x, r2, r3
mul_pp r0.xyz, r0, r1
mov_pp r0.w, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
SetTexture 5 [unity_LightmapInd] 2D 5
ConstBuffer "$Globals" 208
Vector 48 [_Color]
Vector 64 [_SnowColor]
Vector 80 [_SnowDirection]
Float 96 [_SplitValue]
Float 100 [_TransformWidth]
Vector 176 [unity_LightmapFade]
BindCB  "$Globals" 0
"ps_4_0
eefiecedpeepdciblahnlnepfhigbakkidacohgpabaaaaaahiaiaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaalmaaaaaa
abaaaaaaaaaaaaaaadaaaaaaadaaaaaaapalaaaalmaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapapaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaa
ahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefceaahaaaaeaaaaaaanaabaaaa
fjaaaaaeegiocaaaaaaaaaaaamaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaa
fkaaaaadaagabaaaaeaaaaaafkaaaaadaagabaaaafaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaa
aeaaaaaaffffaaaafibiaaaeaahabaaaafaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagcbaaaad
lcbabaaaadaaaaaagcbaaaadpcbabaaaaeaaaaaagcbaaaadhcbabaaaafaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaafaaaaaaegbcbaaaafaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaafaaaaaa
diaaaaalhcaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaialpaaaaiadpaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaai
fcaabaaaabaaaaaapgapbaaaaaaaaaaaagiccaaaaaaaaaaaafaaaaaadiaaaaaj
ccaabaaaabaaaaaadkaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaj
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadp
dcaaaaamccaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaaadpakiacaaaaaaaaaaaagaaaaaaaaaaaaaiecaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakiacaaaaaaaaaaaagaaaaaaaocaaaahccaabaaaaaaaaaaa
ckaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaaegbabaaa
acaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaaaaaaaaaiecaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaa
acaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaa
adaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaal
hcaabaaaaeaaaaaaegacbaaaadaaaaaaegiccaaaaaaaaaaaadaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaeaaaaaakgakbaaaaaaaaaaaegacbaaa
aeaaaaaadcaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
aeaaaaaaegacbaaaaeaaaaaadcaaaaalhcaabaaaadaaaaaaegacbaaaadaaaaaa
egiccaaaaaaaaaaaadaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaajocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagajbaaaadaaaaaaagajbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaadkaabaaaadaaaaaadkiacaaaaaaaaaaaadaaaaaadgaaaaaf
iccabaaaaaaaaaaaakaabaaaabaaaaaadbaaaaaibcaabaaaabaaaaaaakiacaaa
aaaaaaaaagaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaiaebaaaaaaaaaaaaaaagaaaaaadiaaaaaiccaabaaaabaaaaaa
bkiacaaaaaaaaaaaagaaaaaaabeaaaaaaaaaaadpaocaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaabaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaajocaabaaaabaaaaaaagaabaaa
aaaaaaaaagajbaaaaeaaaaaaagajbaaaacaaaaaadhaaaaajhcaabaaaaaaaaaaa
agaabaaaabaaaaaajgahbaaaabaaaaaajgahbaaaaaaaaaaabbaaaaahicaabaaa
aaaaaaaaegbobaaaaeaaaaaaegbobaaaaeaaaaaaelaaaaaficaabaaaaaaaaaaa
dkaabaaaaaaaaaaadccaaaalicaabaaaaaaaaaaadkaabaaaaaaaaaaackiacaaa
aaaaaaaaalaaaaaadkiacaaaaaaaaaaaalaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaafaaaaaaaagabaaaafaaaaaadiaaaaahicaabaaa
abaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaebdiaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaapgapbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaa
acaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaahicaabaaaabaaaaaa
dkaabaaaacaaaaaaabeaaaaaaaaaaaebdcaaaaakhcaabaaaacaaaaaapgapbaaa
abaaaaaaegacbaaaacaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaajhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaaaoaaaaah
dcaabaaaacaaaaaaegbabaaaadaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaa
acaaaaaaegaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaaaaaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaahhccabaaa
aaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[6] = { program.local[0..4],
		{ 0.5, 0, 1, 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEX R0, fragment.texcoord[2], texture[4], 2D;
TEX R5.x, fragment.texcoord[5], texture[2], 2D;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TEX R3.xyz, fragment.texcoord[0].zwzw, texture[1], 2D;
TXP R2.xyz, fragment.texcoord[1], texture[3], 2D;
MUL R1, R1, c[0];
MUL R3.xyz, R3, c[1];
MUL R0.xyz, R0.w, R0;
ADD R4.xyz, R1, -R3;
ADD R2.w, -R5.x, c[5].z;
MUL R4.xyz, R2.w, R4;
ADD R5.xyz, R3, R4;
ADD R7.xyz, R1, -R5;
DP3 R2.w, fragment.texcoord[4], fragment.texcoord[4];
MOV R1.xz, c[2];
MOV R1.y, -c[2];
DP3 R3.w, R1, R1;
RSQ R3.w, R3.w;
MUL R6.xyz, R3.w, R1;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, fragment.texcoord[4];
DP3 R1.y, R1, R6;
MAD R2.w, R1.y, c[5].x, c[5].x;
MOV R1.x, c[5];
MUL R1.x, R1, c[4];
RCP R1.z, R1.x;
ADD R1.y, -R1.x, c[3].x;
ADD R1.x, R2.w, -R1.y;
ADD R3.w, R2, -c[3].x;
MUL_SAT R1.x, R1, R1.z;
MUL_SAT R3.w, R1.z, R3;
ADD R1.x, -R1, c[5].z;
ADD R3.w, -R3, c[5].z;
SLT R2.w, c[3].x, R2;
ABS R2.w, R2;
MAD R1.xyz, R1.x, R7, R5;
MAD R3.xyz, R4, R3.w, R3;
CMP R0.w, -R2, c[5].y, c[5].z;
MAD R0.xyz, R0, c[5].w, R2;
CMP R1.xyz, -R0.w, R1, R3;
MUL result.color.xyz, R1, R0;
MOV result.color.w, R1;
END
# 42 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_SnowColor]
Vector 2 [_SnowDirection]
Float 3 [_SplitValue]
Float 4 [_TransformWidth]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
def c5, 0.00000000, 1.00000000, 0.50000000, 8.00000000
dcl t0
dcl t5.xy
dcl t1
dcl t2.xy
dcl t4.xyz
texld r1, t5, s2
texldp r5, t1, s3
texld r4, t2, s4
mov r0.y, t0.w
mov r0.x, t0.z
mov r2.xy, r0
add r1.x, -r1, c5.y
texld r0, t0, s0
texld r2, r2, s1
mul r0, r0, c0
mul r6.xyz, r2, c1
add_pp r2.xyz, r0, -r6
mul_pp r7.xyz, r1.x, r2
add_pp r8.xyz, r6, r7
add r9.xyz, r0, -r8
dp3 r0.x, t4, t4
rsq r0.x, r0.x
mov r2.xz, c2
mov r2.y, -c2
dp3 r1.x, r2, r2
rsq r1.x, r1.x
mul r1.xyz, r1.x, r2
mul r0.xyz, r0.x, t4
dp3 r0.x, r0, r1
mov r1.x, c4
mul r2.x, c5.z, r1
mad r0.x, r0, c5.z, c5.z
add r3.x, -r2, c3
rcp r2.x, r2.x
add r1.x, r0, -c3
add r3.x, r0, -r3
mul_sat r1.x, r2, r1
mul_sat r3.x, r3, r2
add r2.x, -r3, c5.y
add r1.x, -r1, c5.y
add r0.x, -r0, c3
cmp r0.x, r0, c5, c5.y
mul_pp r3.xyz, r4.w, r4
mad r2.xyz, r2.x, r9, r8
mad r1.xyz, r7, r1.x, r6
abs_pp r0.x, r0
mad_pp r3.xyz, r3, c5.w, r5
cmp_pp r0.xyz, -r0.x, r2, r1
mul_pp r0.xyz, r0, r3
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SnowTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_LightBuffer] 2D 3
SetTexture 4 [unity_Lightmap] 2D 4
ConstBuffer "$Globals" 208
Vector 48 [_Color]
Vector 64 [_SnowColor]
Vector 80 [_SnowDirection]
Float 96 [_SplitValue]
Float 100 [_TransformWidth]
BindCB  "$Globals" 0
"ps_4_0
eefiecedehndfijgbafjajjobacjdekipmhhbgefabaaaaaadmahaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaafaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaakeaaaaaa
abaaaaaaaaaaaaaaadaaaaaaadaaaaaaapalaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbmagaaaa
eaaaaaaaihabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafkaaaaadaagabaaaaeaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaafibiaaaeaahabaaaaeaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaad
mcbabaaaacaaaaaagcbaaaadlcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbcbaaaaeaaaaaa
diaaaaalhcaabaaaabaaaaaaegiccaaaaaaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaialpaaaaiadpaaaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaabaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaai
fcaabaaaabaaaaaapgapbaaaaaaaaaaaagiccaaaaaaaaaaaafaaaaaadiaaaaaj
ccaabaaaabaaaaaadkaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaafaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaaj
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpabeaaaaaaaaaaadp
dcaaaaamccaabaaaaaaaaaaabkiacaiaebaaaaaaaaaaaaaaagaaaaaaabeaaaaa
aaaaaadpakiacaaaaaaaaaaaagaaaaaaaaaaaaaiecaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakiacaaaaaaaaaaaagaaaaaaaocaaaahccaabaaaaaaaaaaa
ckaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaaegbabaaa
acaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaaaaaaaaaiecaabaaaaaaaaaaa
akaabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaihcaabaaa
acaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaaeaaaaaaefaaaaajpcaabaaa
adaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaal
hcaabaaaaeaaaaaaegacbaaaadaaaaaaegiccaaaaaaaaaaaadaaaaaaegacbaia
ebaaaaaaacaaaaaadiaaaaahhcaabaaaaeaaaaaakgakbaaaaaaaaaaaegacbaaa
aeaaaaaadcaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
aeaaaaaaegacbaaaaeaaaaaadcaaaaalhcaabaaaadaaaaaaegacbaaaadaaaaaa
egiccaaaaaaaaaaaadaaaaaaegacbaiaebaaaaaaabaaaaaadcaaaaajocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagajbaaaadaaaaaaagajbaaaabaaaaaadiaaaaai
bcaabaaaabaaaaaadkaabaaaadaaaaaadkiacaaaaaaaaaaaadaaaaaadgaaaaaf
iccabaaaaaaaaaaaakaabaaaabaaaaaadbaaaaaibcaabaaaabaaaaaaakiacaaa
aaaaaaaaagaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaiaebaaaaaaaaaaaaaaagaaaaaadiaaaaaiccaabaaaabaaaaaa
bkiacaaaaaaaaaaaagaaaaaaabeaaaaaaaaaaadpaocaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaabaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaajocaabaaaabaaaaaaagaabaaa
aaaaaaaaagajbaaaaeaaaaaaagajbaaaacaaaaaadhaaaaajhcaabaaaaaaaaaaa
agaabaaaabaaaaaajgahbaaaabaaaaaajgahbaaaaaaaaaaaaoaaaaahdcaabaaa
abaaaaaaegbabaaaadaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
egaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaaadaaaaaaefaaaaajpcaabaaa
acaaaaaaogbkbaaaacaaaaaaeghobaaaaeaaaaaaaagabaaaaeaaaaaadiaaaaah
icaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaaebdcaaaaajhcaabaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaadiaaaaah
hccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
}
 }
}
Fallback "Diffuse"
}