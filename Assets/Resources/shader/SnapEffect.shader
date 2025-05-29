ьзShader "Custom/SnapEffect" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
"3.0-!!ARBvp1.0
PARAM c[5] = { program.local[0],
		state.matrix.mvp };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedgcclnnbgpijgpddakojponflfpghdgniabaaaaaaoeabaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefcaeabaaaa
eaaaabaaebaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"3.0-!!ARBfp1.0
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
"ps_3_0
def c0, 0.00000000, 0, 0, 0
mov oC0, c0.x
"
}
SubProgram "d3d11 " {
"ps_4_0
eefiecedkjchoibnfhkdnbjinbbnkdkcngndlcpgabaaaaaapiaaaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaa
eaaaaaaaaoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend SrcAlpha OneMinusSrcAlpha
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
"3.0-!!ARBvp1.0
PARAM c[5] = { program.local[0],
		state.matrix.mvp };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedgcclnnbgpijgpddakojponflfpghdgniabaaaaaaoeabaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefcaeabaaaa
eaaaabaaebaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0],
		{ 2, 0, 0.5, 1 },
		{ -24, -3, 15, 12 },
		{ 0.16666667, 9, -15, 6 },
		{ 2, -1, 1, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
RCP R0.x, c[0].x;
MUL R1.x, fragment.texcoord[0], R0;
RCP R0.z, R0.x;
ABS R0.y, R1.x;
MOV R3, c[4];
FRC R4.w, R1.x;
SLT R0.x, R1, c[1].y;
FLR R0.y, R0;
CMP R0.y, -R0.x, -R0, R0;
MUL R0.w, R0.z, c[1].z;
MAD R5.x, R0.y, R0.z, R0.w;
RCP R0.x, c[0].y;
MUL R0.y, fragment.texcoord[0], R0.x;
RCP R0.w, R0.x;
ABS R0.x, R0.y;
FLR R0.z, R0.x;
SLT R0.x, R0.y, c[1].y;
FRC R2.x, R0.y;
CMP R0.x, -R0, -R0.z, R0.z;
MUL R1.y, R0.w, c[1].z;
MAD R5.y, R0.x, R0.w, R1;
CMP R1.y, R2.x, -R2.x, R2.x;
MUL R2.z, R1.y, R1.y;
MAD R0.xy, R3.ywzw, c[0], R5;
SLT R1.z, R1.y, c[1].w;
ABS R1.z, R1;
MUL R2.w, R1.y, R2.z;
SLT R2.y, R1, c[1].x;
SGE R1.w, R1.y, c[1];
MUL R1.w, R1, R2.y;
CMP R1.z, -R1, c[1].y, c[1].w;
MUL R2.y, R1.z, R1.w;
MUL R4.x, R2.z, c[2].z;
MUL R4.y, R2.z, c[3].z;
MAD R2.z, R2.w, c[2].y, R4.x;
MAD R1.y, R1, c[2].x, R2.z;
MAD R2.w, R2, c[3].y, R4.y;
ADD R2.z, R2.w, c[3].w;
ADD R1.y, R1, c[2].w;
MUL R2.z, R2, c[3].x;
MUL R1.y, R1, c[3].x;
CMP R2.y, -R2, R1, R2.z;
ABS R1.y, R1.w;
CMP R1.x, -R1.y, c[1].y, c[1].w;
MUL R1.x, R1.z, R1;
ADD R1.y, -R4.w, c[4];
CMP R1.y, R1, -R1, R1;
CMP R6.z, -R1.x, c[1].y, R2.y;
MUL R2.y, R1, R1;
MUL R2.z, R1.y, R2.y;
SGE R1.x, R1.y, c[1].w;
SLT R1.z, R1.y, c[1].x;
MUL R1.z, R1.x, R1;
SLT R1.x, R1.y, c[1].w;
ABS R1.w, R1.z;
ABS R1.x, R1;
CMP R1.x, -R1, c[1].y, c[1].w;
MUL R1.z, R1.x, R1;
CMP R1.w, -R1, c[1].y, c[1];
MUL R2.w, R2.y, c[2].z;
MUL R4.x, R2.y, c[3].z;
MAD R2.y, R2.z, c[2], R2.w;
MAD R1.y, R1, c[2].x, R2;
MAD R2.z, R2, c[3].y, R4.x;
ADD R2.y, R2.z, c[3].w;
ADD R1.y, R1, c[2].w;
MUL R2.y, R2, c[3].x;
MUL R1.y, R1, c[3].x;
CMP R1.y, -R1.z, R1, R2;
MUL R1.x, R1, R1.w;
ADD R2.y, -R2.x, c[4];
CMP R2.y, -R2, R2, -R2;
CMP R5.z, -R1.x, c[1].y, R1.y;
TEX R0, R0, texture[0], 2D;
MUL R0, R5.z, R0;
MUL R1, R0, R6.z;
ADD R0.xy, R5, -c[0];
TEX R0, R0, texture[0], 2D;
MUL R0, R5.z, R0;
SLT R2.w, R2.y, c[1].x;
SGE R2.z, R2.y, c[1].w;
MUL R4.x, R2.z, R2.w;
SLT R2.z, R2.y, c[1].w;
ABS R2.w, R2.z;
ABS R4.y, R4.x;
CMP R2.z, -R4.y, c[1].y, c[1].w;
MUL R4.y, R2, R2;
CMP R2.w, -R2, c[1].y, c[1];
MUL R4.z, R2.y, R4.y;
MUL R5.w, R4.y, c[2].z;
MUL R6.x, R4.y, c[3].z;
MAD R4.y, R4.z, c[2], R5.w;
MAD R2.y, R2, c[2].x, R4;
MAD R4.z, R4, c[3].y, R6.x;
ADD R4.y, R4.z, c[3].w;
ADD R2.y, R2, c[2].w;
MUL R4.x, R2.w, R4;
MUL R4.y, R4, c[3].x;
MUL R2.y, R2, c[3].x;
CMP R4.x, -R4, R2.y, R4.y;
MUL R2.y, R2.w, R2.z;
CMP R6.y, -R2, c[1], R4.x;
ADD R2.y, -R2.x, c[1].w;
CMP R2.y, -R2, R2, -R2;
MAD R1, R0, R6.y, R1;
MAD R0.xy, R3.yzzw, c[0], R5;
TEX R0, R0, texture[0], 2D;
ADD R2.x, -R2, c[1];
CMP R2.x, -R2, R2, -R2;
MUL R0, R5.z, R0;
SLT R2.w, R2.y, c[1].x;
SGE R2.z, R2.y, c[1].w;
MUL R4.x, R2.z, R2.w;
SLT R2.z, R2.y, c[1].w;
ABS R2.w, R2.z;
ABS R4.y, R4.x;
CMP R2.z, -R4.y, c[1].y, c[1].w;
MUL R4.y, R2, R2;
CMP R2.w, -R2, c[1].y, c[1];
MUL R4.z, R2.y, R4.y;
MUL R5.w, R4.y, c[2].z;
MUL R6.x, R4.y, c[3].z;
MAD R4.y, R4.z, c[2], R5.w;
MAD R2.y, R2, c[2].x, R4;
MAD R4.z, R4, c[3].y, R6.x;
ADD R4.y, R4.z, c[3].w;
ADD R2.y, R2, c[2].w;
MUL R4.x, R2.w, R4;
MUL R4.y, R4, c[3].x;
MUL R2.y, R2, c[3].x;
CMP R4.x, -R4, R2.y, R4.y;
MUL R2.y, R2.w, R2.z;
CMP R6.x, -R2.y, c[1].y, R4;
MAD R1, R0, R6.x, R1;
MAD R0.xy, R3.yxzw, c[0], R5;
TEX R0, R0, texture[0], 2D;
MUL R0, R0, R5.z;
SLT R2.z, R2.x, c[1].x;
SGE R2.y, R2.x, c[1].w;
MUL R2.w, R2.y, R2.z;
SLT R2.y, R2.x, c[1].w;
ABS R2.z, R2.y;
ABS R4.x, R2.w;
CMP R2.y, -R4.x, c[1], c[1].w;
MUL R4.x, R2, R2;
CMP R2.z, -R2, c[1].y, c[1].w;
MUL R4.y, R2.x, R4.x;
MUL R4.z, R4.x, c[2];
MUL R5.w, R4.x, c[3].z;
MAD R4.x, R4.y, c[2].y, R4.z;
MAD R2.x, R2, c[2], R4;
MAD R4.y, R4, c[3], R5.w;
ADD R4.x, R4.y, c[3].w;
ADD R2.x, R2, c[2].w;
MUL R2.w, R2.z, R2;
MUL R4.x, R4, c[3];
MUL R2.x, R2, c[3];
CMP R2.w, -R2, R2.x, R4.x;
MUL R2.x, R2.z, R2.y;
CMP R5.w, -R2.x, c[1].y, R2;
CMP R2.x, -R4.w, R4.w, -R4.w;
MAD R1, R0, R5.w, R1;
MAD R0.xy, R3.wyzw, c[0], R5;
SLT R2.z, R2.x, c[1].x;
SGE R2.y, R2.x, c[1].w;
MUL R2.w, R2.y, R2.z;
SLT R2.y, R2.x, c[1].w;
ABS R2.z, R2.y;
ABS R3.w, R2;
CMP R2.y, -R3.w, c[1], c[1].w;
MUL R3.w, R2.x, R2.x;
CMP R2.z, -R2, c[1].y, c[1].w;
MUL R4.x, R2, R3.w;
MUL R4.y, R3.w, c[2].z;
MUL R4.z, R3.w, c[3];
MAD R3.w, R4.x, c[2].y, R4.y;
MAD R2.x, R2, c[2], R3.w;
MAD R4.x, R4, c[3].y, R4.z;
ADD R3.w, R4.x, c[3];
MOV R4.xyz, c[1].xyww;
ADD R2.x, R2, c[2].w;
MUL R2.w, R2.z, R2;
MUL R3.w, R3, c[3].x;
MUL R2.x, R2, c[3];
CMP R2.w, -R2, R2.x, R3;
MUL R2.x, R2.z, R2.y;
CMP R3.w, -R2.x, c[1].y, R2;
TEX R0, R0, texture[0], 2D;
MUL R0, R3.w, R0;
MAD R1, R0, R6.y, R1;
TEX R0, R5, texture[0], 2D;
MUL R0, R3.w, R0;
MAD R2, R0, R6.z, R1;
MAD R7.xy, R4.yzzw, c[0], R5;
TEX R0, R7, texture[0], 2D;
MUL R1, R3.w, R0;
MAD R1, R1, R6.x, R2;
MAD R7.xy, R4.yxzw, c[0], R5;
TEX R0, R7, texture[0], 2D;
MUL R0, R0, R3.w;
MAD R1, R0, R5.w, R1;
MAD R0.xy, R3.zyzw, c[0], R5;
ADD R2.x, -R4.w, c[1].w;
CMP R2.x, R2, -R2, R2;
MUL R6.w, R2.x, R2.x;
SLT R2.z, R2.x, c[1].x;
SGE R2.y, R2.x, c[1].w;
MUL R2.w, R2.y, R2.z;
SLT R2.y, R2.x, c[1].w;
ABS R2.z, R2.y;
ABS R3.z, R2.w;
CMP R2.y, -R3.z, c[1], c[1].w;
CMP R2.z, -R2, c[1].y, c[1].w;
MUL R3.z, R2.x, R6.w;
TEX R0, R0, texture[0], 2D;
MUL R2.w, R2.z, R2;
MUL R7.w, R6, c[3].z;
MUL R7.z, R6.w, c[2];
MAD R6.w, R3.z, c[2].y, R7.z;
MAD R2.x, R2, c[2], R6.w;
MAD R3.z, R3, c[3].y, R7.w;
ADD R3.z, R3, c[3].w;
ADD R2.x, R2, c[2].w;
MUL R3.z, R3, c[3].x;
MUL R2.x, R2, c[3];
CMP R2.w, -R2, R2.x, R3.z;
MUL R2.x, R2.z, R2.y;
CMP R3.z, -R2.x, c[1].y, R2.w;
MUL R2, R3.z, R0;
MAD R7.xy, R4.zyzw, c[0], R5;
TEX R0, R7, texture[0], 2D;
MUL R0, R3.z, R0;
MAD R1, R2, R6.y, R1;
MAD R1, R0, R6.z, R1;
MUL R0.z, R5, R6;
MAD R2.x, R5.z, R6.y, R0.z;
ADD R0.xy, R5, c[0];
TEX R0, R0, texture[0], 2D;
MUL R0, R3.z, R0;
MAD R1, R0, R6.x, R1;
MAD R2.x, R5.z, R6, R2;
MAD R0.z, R5, R5.w, R2.x;
MAD R2.x, R3.w, R6.y, R0.z;
MAD R2.x, R3.w, R6.z, R2;
MAD R2.y, R3.w, R6.x, R2.x;
MAD R0.xy, R4.zxzw, c[0], R5;
TEX R0, R0, texture[0], 2D;
MUL R0, R0, R3.z;
MAD R0, R0, R5.w, R1;
ADD R1.z, -R4.w, c[1].x;
CMP R2.x, R1.z, -R1.z, R1.z;
MAD R1.xy, R3, c[0], R5;
SLT R2.w, R2.x, c[1].x;
SGE R2.z, R2.x, c[1].w;
MUL R3.x, R2.z, R2.w;
SLT R2.z, R2.x, c[1].w;
ABS R2.w, R2.z;
ABS R3.y, R3.x;
CMP R2.z, -R3.y, c[1].y, c[1].w;
MUL R3.y, R2.x, R2.x;
CMP R2.w, -R2, c[1].y, c[1];
MUL R4.w, R2.x, R3.y;
MUL R6.w, R3.y, c[3].z;
MUL R5.z, R3.y, c[2];
MAD R3.y, R4.w, c[2], R5.z;
MAD R2.x, R2, c[2], R3.y;
MAD R4.w, R4, c[3].y, R6;
ADD R3.y, R4.w, c[3].w;
ADD R2.x, R2, c[2].w;
MUL R2.x, R2, c[3];
MAD R2.y, R3.w, R5.w, R2;
TEX R1, R1, texture[0], 2D;
MUL R3.x, R2.w, R3;
MUL R3.y, R3, c[3].x;
CMP R3.x, -R3, R2, R3.y;
MUL R2.x, R2.w, R2.z;
CMP R2.x, -R2, c[1].y, R3;
MUL R1, R2.x, R1;
MAD R1, R1, R6.y, R0;
MAD R0.z, R3, R6.y, R2.y;
MAD R2.y, R3.z, R6.z, R0.z;
MAD R0.xy, R4, c[0], R5;
TEX R0, R0, texture[0], 2D;
MUL R0, R2.x, R0;
MAD R0, R0, R6.z, R1;
MAD R2.y, R3.z, R6.x, R2;
MAD R1.z, R3, R5.w, R2.y;
MAD R2.y, R2.x, R6, R1.z;
MAD R1.xy, R4.xzzw, c[0], R5;
TEX R1, R1, texture[0], 2D;
MUL R1, R2.x, R1;
MAD R0, R1, R6.x, R0;
MAD R2.y, R2.x, R6.z, R2;
MAD R1.z, R2.x, R6.x, R2.y;
MAD R2.y, R2.x, R5.w, R1.z;
MAD R1.xy, R4.x, c[0], R5;
TEX R1, R1, texture[0], 2D;
MUL R1, R1, R2.x;
RCP R2.y, R2.y;
MAD R0, R1, R5.w, R0;
MUL result.color, R0, R2.y;
END
# 301 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c1, 0.50000000, 2.00000000, 0.00000000, -2.00000000
def c2, -15.00000000, 9.00000000, 6.00000000, 0.16666667
def c3, 15.00000000, -3.00000000, -24.00000000, 12.00000000
def c4, 2.00000000, 1.00000000, -1.00000000, 0.00000000
dcl_texcoord0 v0.xy
rcp r0.y, c0.y
mul r0.z, v0.y, r0.y
frc r0.w, r0.z
cmp r2.y, r0.w, r0.w, -r0.w
add r1.x, r2.y, c4.z
cmp r1.y, r1.x, c4.w, c4
add r0.x, r2.y, c1.w
cmp r0.x, r0, c4.w, c4.y
cmp r1.x, r1, c4.y, c4.w
mul_pp r1.w, r1.x, r0.x
abs_pp r0.x, r1.y
mul r1.x, r2.y, r2.y
cmp_pp r2.x, -r0, c4.y, c4.w
mul r1.y, r2, r1.x
mul r0.x, r1, c3
mad r0.x, r1.y, c3.y, r0
mad r0.x, r2.y, c3.z, r0
mul r1.x, r1, c2
mad r1.x, r1.y, c2.y, r1
abs_pp r1.y, r1.w
add r0.x, r0, c3.w
add r1.x, r1, c2.z
cmp_pp r1.y, -r1, c4, c4.w
mul_pp r1.z, r2.x, r1.w
rcp r2.y, c0.x
mul_pp r1.y, r2.x, r1
mul r1.x, r1, c2.w
mul r0.x, r0, c2.w
cmp r0.x, -r1.z, r1, r0
cmp r3.x, -r1.y, r0, c1.z
mul r1.x, v0, r2.y
abs r1.w, r1.x
frc r1.z, r1.w
add r0.x, r1.w, -r1.z
rcp r1.y, r2.y
cmp r1.z, r1.x, r0.x, -r0.x
mul r0.x, r1.y, c1
mad r0.x, r1.z, r1.y, r0
abs r1.w, r0.z
rcp r1.y, r0.y
frc r1.z, r1.w
add r1.z, r1.w, -r1
cmp r0.z, r0, r1, -r1
mul r0.y, r1, c1.x
mad r0.y, r0.z, r1, r0
frc r0.z, r1.x
add r1.z, -r0, c4
cmp r2.z, r1, r1, -r1
add r3.y, r2.z, c4.z
add r2.x, r2.z, c1.w
mov r1.xy, c0
mad r1.xy, c4.zwzw, r1, r0
cmp r2.y, r3, c4, c4.w
cmp r2.x, r2, c4.w, c4.y
mul_pp r2.w, r2.y, r2.x
cmp r2.y, r3, c4.w, c4
mul r3.y, r2.z, r2.z
abs_pp r2.x, r2.w
abs_pp r2.y, r2
cmp_pp r2.y, -r2, c4, c4.w
mul_pp r3.w, r2.y, r2
cmp_pp r2.x, -r2, c4.y, c4.w
mul r3.z, r2, r3.y
mul r2.w, r3.y, c3.x
mad r2.w, r3.z, c3.y, r2
mad r2.z, r2, c3, r2.w
mul r3.y, r3, c2.x
mad r2.w, r3.z, c2.y, r3.y
add r3.z, -r0.w, c4
cmp r4.y, -r3.z, -r3.z, r3.z
mul r4.w, r4.y, r4.y
add r3.z, r4.y, c1.w
add r2.z, r2, c3.w
add r2.w, r2, c2.z
mul r5.x, r4.y, r4.w
add r4.z, r4.y, c4
mul r2.w, r2, c2
mul r2.z, r2, c2.w
cmp r2.z, -r3.w, r2.w, r2
mul_pp r2.x, r2.y, r2
cmp r3.y, -r2.x, r2.z, c1.z
texld r1, r1, s0
mul r1, r3.y, r1
mul r2, r1, r3.x
add r1.xy, r0, -c0
texld r1, r1, s0
cmp r3.w, r4.z, c4.y, c4
cmp r3.z, r3, c4.w, c4.y
mul_pp r4.x, r3.w, r3.z
cmp r3.w, r4.z, c4, c4.y
mul r4.z, r4.w, c3.x
mad r4.z, r5.x, c3.y, r4
mad r4.y, r4, c3.z, r4.z
abs_pp r3.z, r4.x
mul r4.w, r4, c2.x
mad r4.z, r5.x, c2.y, r4.w
abs_pp r3.w, r3
cmp_pp r3.w, -r3, c4.y, c4
cmp_pp r3.z, -r3, c4.y, c4.w
add r4.y, r4, c3.w
add r4.z, r4, c2
mul r1, r3.y, r1
mul_pp r4.x, r3.w, r4
mul r4.y, r4, c2.w
mul r4.z, r4, c2.w
cmp r4.x, -r4, r4.z, r4.y
mul_pp r3.z, r3.w, r3
cmp r4.x, -r3.z, r4, c1.z
mad r1, r1, r4.x, r2
mov r3.zw, c0.xyxy
mad r2.xy, c4.zyzw, r3.zwzw, r0
add r3.z, -r0.w, c4.y
cmp r4.y, -r3.z, -r3.z, r3.z
add r4.w, r4.y, c4.z
mul r5.y, r4, r4
add r3.z, r4.y, c1.w
texld r2, r2, s0
mul r2, r3.y, r2
cmp r3.w, r4, c4.y, c4
cmp r3.z, r3, c4.w, c4.y
mul_pp r4.z, r3.w, r3
cmp r3.w, r4, c4, c4.y
abs_pp r3.z, r4
abs_pp r3.w, r3
cmp_pp r3.w, -r3, c4.y, c4
cmp_pp r3.z, -r3, c4.y, c4.w
mul r4.w, r4.y, r5.y
mul r5.x, r5.y, c3
mad r5.x, r4.w, c3.y, r5
mad r4.y, r4, c3.z, r5.x
mul r5.y, r5, c2.x
mad r4.w, r4, c2.y, r5.y
add r4.y, r4, c3.w
add r4.w, r4, c2.z
mul_pp r4.z, r3.w, r4
mul r4.w, r4, c2
mul r4.y, r4, c2.w
cmp r4.y, -r4.z, r4.w, r4
mul_pp r3.z, r3.w, r3
cmp r4.y, -r3.z, r4, c1.z
mov r3.zw, c0.xyxy
mad r1, r2, r4.y, r1
mad r2.xy, c4.zxzw, r3.zwzw, r0
add r0.w, -r0, c1.y
cmp r3.w, -r0, -r0, r0
add r4.w, r3, c4.z
mul r5.y, r3.w, r3.w
add r0.w, r3, c1
texld r2, r2, s0
mul r2, r2, r3.y
cmp r3.z, r4.w, c4.y, c4.w
cmp r0.w, r0, c4, c4.y
mul_pp r4.z, r3, r0.w
cmp r3.z, r4.w, c4.w, c4.y
abs_pp r0.w, r4.z
abs_pp r3.z, r3
cmp_pp r3.z, -r3, c4.y, c4.w
cmp_pp r0.w, -r0, c4.y, c4
mul r4.w, r3, r5.y
mul r5.x, r5.y, c3
mad r5.x, r4.w, c3.y, r5
mad r3.w, r3, c3.z, r5.x
mul r5.y, r5, c2.x
mad r4.w, r4, c2.y, r5.y
add r3.w, r3, c3
add r4.w, r4, c2.z
mul_pp r4.z, r3, r4
mul r4.w, r4, c2
mul r3.w, r3, c2
cmp r3.w, -r4.z, r4, r3
mul_pp r0.w, r3.z, r0
cmp r0.w, -r0, r3, c1.z
mov r3.zw, c0.xyxy
mad r1, r2, r0.w, r1
mad r2.xy, c4.wzzw, r3.zwzw, r0
cmp r3.z, -r0, -r0, r0
add r5.x, r3.z, c4.z
mul r5.y, r3.z, r3.z
add r3.w, r3.z, c1
cmp r4.z, r5.x, c4.y, c4.w
cmp r3.w, r3, c4, c4.y
mul_pp r4.w, r4.z, r3
cmp r4.z, r5.x, c4.w, c4.y
abs_pp r3.w, r4
abs_pp r4.z, r4
cmp_pp r4.z, -r4, c4.y, c4.w
cmp_pp r3.w, -r3, c4.y, c4
mul r5.x, r3.z, r5.y
mul r5.z, r5.y, c3.x
mad r5.z, r5.x, c3.y, r5
mad r3.z, r3, c3, r5
mul r5.y, r5, c2.x
mad r5.x, r5, c2.y, r5.y
add r3.z, r3, c3.w
add r5.x, r5, c2.z
mul_pp r3.w, r4.z, r3
mul_pp r4.w, r4.z, r4
mul r5.x, r5, c2.w
mul r3.z, r3, c2.w
cmp r3.z, -r4.w, r5.x, r3
cmp r3.z, -r3.w, r3, c1
texld r2, r2, s0
mul r2, r3.z, r2
texld r5, r0, s0
mad r1, r2, r4.x, r1
mul r2, r3.z, r5
mad r1, r2, r3.x, r1
mov r4.zw, c0.xyxy
mad r2.xy, c4.wyzw, r4.zwzw, r0
texld r5, r2, s0
mul r5, r3.z, r5
mov r2.zw, c0.xyxy
mad r2.xy, c1.zyzw, r2.zwzw, r0
texld r2, r2, s0
mul r2, r2, r3.z
mad r1, r5, r4.y, r1
mad r1, r2, r0.w, r1
add r2.z, -r0, c4.y
cmp r4.z, r2, r2, -r2
add r4.w, r4.z, c4.z
mul r5.y, r4.z, r4.z
add r2.z, r4, c1.w
mov r2.xy, c0
add r0.z, -r0, c1.y
cmp r0.z, r0, r0, -r0
mad r2.xy, c4.yzzw, r2, r0
cmp r2.w, r4, c4.y, c4
cmp r2.z, r2, c4.w, c4.y
mul_pp r3.w, r2, r2.z
cmp r2.w, r4, c4, c4.y
abs_pp r2.z, r3.w
abs_pp r2.w, r2
cmp_pp r2.w, -r2, c4.y, c4
cmp_pp r2.z, -r2, c4.y, c4.w
mul r4.w, r4.z, r5.y
mul r5.x, r5.y, c3
mad r5.x, r4.w, c3.y, r5
mad r4.z, r4, c3, r5.x
mul r5.y, r5, c2.x
mad r4.w, r4, c2.y, r5.y
add r4.z, r4, c3.w
add r4.w, r4, c2.z
mul_pp r3.w, r2, r3
mul r4.z, r4, c2.w
mul r4.w, r4, c2
cmp r3.w, -r3, r4, r4.z
mov r4.zw, c0.xyxy
mul_pp r2.z, r2.w, r2
cmp r3.w, -r2.z, r3, c1.z
texld r2, r2, s0
mul r2, r3.w, r2
mad r5.xy, c4.ywzw, r4.zwzw, r0
mad r1, r2, r4.x, r1
texld r2, r5, s0
add r5.xy, r0, c0
mul r2, r3.w, r2
texld r5, r5, s0
mad r1, r2, r3.x, r1
mul r2, r3.w, r5
mad r1, r2, r4.y, r1
add r5.y, r0.z, c4.z
mul r5.w, r0.z, r0.z
mul r2.z, r3.y, r3.x
mad r2.z, r3.y, r4.x, r2
mad r4.z, r3.y, r4.y, r2
mad r3.y, r3, r0.w, r4.z
add r4.z, r0, c1.w
mov r2.xy, c0
mad r2.xy, c4.yxzw, r2, r0
texld r2, r2, s0
mul r2, r2, r3.w
mad r1, r2, r0.w, r1
mov r2.xy, c0
mad r2.xy, c4.xzzw, r2, r0
cmp r4.w, r5.y, c4.y, c4
cmp r4.z, r4, c4.w, c4.y
mul_pp r5.x, r4.w, r4.z
cmp r4.w, r5.y, c4, c4.y
abs_pp r4.z, r5.x
abs_pp r4.w, r4
cmp_pp r4.w, -r4, c4.y, c4
cmp_pp r4.z, -r4, c4.y, c4.w
mul r5.y, r0.z, r5.w
mul r5.z, r5.w, c3.x
mad r5.z, r5.y, c3.y, r5
mul r5.w, r5, c2.x
mad r0.z, r0, c3, r5
mad r5.y, r5, c2, r5.w
add r0.z, r0, c3.w
add r5.y, r5, c2.z
mad r3.y, r3.z, r4.x, r3
texld r2, r2, s0
mul_pp r5.x, r4.w, r5
mul r0.z, r0, c2.w
mul r5.y, r5, c2.w
cmp r0.z, -r5.x, r5.y, r0
mul_pp r4.z, r4.w, r4
cmp r0.z, -r4, r0, c1
mul r2, r0.z, r2
mad r1, r2, r4.x, r1
mad r2.z, r3, r3.x, r3.y
mad r2.z, r3, r4.y, r2
mad r3.y, r3.z, r0.w, r2.z
mov r2.xy, c0
mad r2.xy, c1.yzzw, r2, r0
texld r2, r2, s0
mul r2, r0.z, r2
mad r1, r2, r3.x, r1
mad r3.y, r3.w, r4.x, r3
mad r2.z, r3.w, r3.x, r3.y
mad r2.z, r3.w, r4.y, r2
mad r3.y, r3.w, r0.w, r2.z
mov r2.xy, c0
mad r2.xy, c4, r2, r0
texld r2, r2, s0
mul r2, r0.z, r2
mad r1, r2, r4.y, r1
mov r2.zw, c0.xyxy
mad r3.y, r0.z, r4.x, r3
mad r2.x, r0.z, r3, r3.y
mad r2.x, r0.z, r4.y, r2
mad r0.xy, c1.y, r2.zwzw, r0
mad r3.x, r0.z, r0.w, r2
texld r2, r0, s0
mul r2, r2, r0.z
rcp r0.x, r3.x
mad r1, r2, r0.w, r1
mul oC0, r1, r0.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 48
Vector 16 [_MainTex_TexelSize]
BindCB  "$Globals" 0
"ps_4_0
eefiecedabilpbnncgcbpmofmijpkpphlejeemfoabaaaaaacaaoaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgaanaaaa
eaaaaaaafiadaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaiaaaaaagjaaaaaeaaaaaaaabaaaaaaa
aeaaaaaaaoaaaaaldcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadp
aaaaiadpegiacaaaaaaaaaaaabaaaaaadiaaaaahmcaabaaaaaaaaaaaagaebaaa
aaaaaaaaagbebaaaabaaaaaabkaaaaafdcaabaaaabaaaaaaogakbaaaaaaaaaaa
edaaaaafmcaabaaaaaaaaaaakgaobaaaaaaaaaaaaoaaaaahmcaabaaaaaaaaaaa
kgaobaaaaaaaaaaaagaebaaaaaaaaaaaaoaaaaakdcaabaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaaaaaaaahdcaabaaa
aaaaaaaaegaabaaaaaaaaaaaogakbaaaaaaaaaaaaaaaaaajmcaabaaaaaaaaaaa
agaebaaaaaaaaaaaagiecaiaebaaaaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaa
acaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaag
pcdacaaaaaaaaaaaaaaaaaaaegaobaaaacaaaaaadcaaaaanpcaabaaaacaaaaaa
egiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaaialpaaaaaaaaaaaaialpaaaaiadp
egaebaaaaaaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaaabaaaaaaegaobaaa
adaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaaacaaaaaaegaobaaaacaaaaaa
dcaaaaanpcaabaaaacaaaaaaegiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaaialp
aaaaaaeaaaaaaaaaaaaaialpegaebaaaaaaaaaaaefaaaaajpcaabaaaadaaaaaa
egaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaa
aaaaaaaaadaaaaaaegaobaaaadaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaa
acaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaa
aeaaaaaaegaobaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaaafaaaaaa
egaobaaaacaaaaaadcaaaaanpcaabaaaacaaaaaaegiecaaaaaaaaaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaiadpaaaaaaaaaaaaaaeaegaebaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dgaaaaagpcdacaaaaaaaaaaaagaaaaaaegaobaaaadaaaaaaefaaaaajpcaabaaa
acaaaaaaogakbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaag
pcdacaaaaaaaaaaaahaaaaaaegaobaaaacaaaaaadcaaaaanpcaabaaaacaaaaaa
egiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaiadpaaaaaaaa
egaebaaaaaaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaaaiaaaaaaegaobaaa
adaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaaajaaaaaaegaobaaaacaaaaaa
aaaaaaaimcaabaaaaaaaaaaaagaebaaaaaaaaaaaagiecaaaaaaaaaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadgaaaaagpcdacaaaaaaaaaaaakaaaaaaegaobaaaacaaaaaadcaaaaan
pcaabaaaacaaaaaaegiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaaiadpaaaaaaea
aaaaaaeaaaaaialpegaebaaaaaaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaa
acaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaa
alaaaaaaegaobaaaadaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaaamaaaaaa
egaobaaaacaaaaaadcaaaaanpcaabaaaacaaaaaaegiecaaaaaaaaaaaabaaaaaa
aceaaaaaaaaaaaeaaaaaaaaaaaaaaaeaaaaaiadpegaebaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dgaaaaagpcdacaaaaaaaaaaaanaaaaaaegaobaaaadaaaaaaefaaaaajpcaabaaa
acaaaaaaogakbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaag
pcdacaaaaaaaaaaaaoaaaaaaegaobaaaacaaaaaadcaaaaandcaabaaaaaaaaaaa
egiacaaaaaaaaaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaa
egaabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadgaaaaagpcdacaaaaaaaaaaaapaaaaaaegaobaaa
aaaaaaaadgaaaaaipcaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadgaaaaaipcaabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadgaaaaafecaabaaaabaaaaaaabeaaaaappppppppdaaaaaabccaaaaah
icaabaaaabaaaaaaabeaaaaaacaaaaaackaabaaaabaaaaaaadaaaeaddkaabaaa
abaaaaaacjaaaaahicaabaaaabaaaaaackaabaaaabaaaaaaabeaaaaaacaaaaaa
boaaaaahicaabaaaabaaaaaadkaabaaaabaaaaaaabeaaaaaaeaaaaaaclaaaaaf
bcaabaaaadaaaaaackaabaaaabaaaaaaaaaaaaaibcaabaaaadaaaaaaakaabaia
ebaaaaaaabaaaaaaakaabaaaadaaaaaadbaaaaahccaabaaaadaaaaaaakaabaaa
adaaaaaaabeaaaaaaaaaaaaadhaaaaakbcaabaaaadaaaaaabkaabaaaadaaaaaa
akaabaiaebaaaaaaadaaaaaaakaabaaaadaaaaaadiaaaaahccaabaaaadaaaaaa
akaabaaaadaaaaaaakaabaaaadaaaaaadiaaaaahecaabaaaadaaaaaaakaabaaa
adaaaaaabkaabaaaadaaaaaadiaaaaakkcaabaaaadaaaaaafgafbaaaadaaaaaa
aceaaaaaaaaaaaaaaaaahambaaaaaaaaaaaahaebdcaaaaamgcaabaaaadaaaaaa
kgakbaaaadaaaaaaaceaaaaaaaaaaaaaaaaabaebaaaaeamaaaaaaaaafgahbaaa
adaaaaaaaaaaaaahccaabaaaadaaaaaabkaabaaaadaaaaaaabeaaaaaaaaamaea
bnaaaaahicaabaaaadaaaaaaakaabaaaadaaaaaaabeaaaaaaaaaiadpdbaaaaak
dcaabaaaaeaaaaaaagaabaaaadaaaaaaaceaaaaaaaaaiadpaaaaaaeaaaaaaaaa
aaaaaaaaabaaaaahicaabaaaadaaaaaadkaabaaaadaaaaaabkaabaaaaeaaaaaa
dcaaaaajbcaabaaaadaaaaaaakaabaaaadaaaaaaabeaaaaaaaaamambckaabaaa
adaaaaaaaaaaaaahbcaabaaaadaaaaaaakaabaaaadaaaaaaabeaaaaaaaaaeaeb
diaaaaakdcaabaaaadaaaaaaegaabaaaadaaaaaaaceaaaaaklkkckdoklkkckdo
aaaaaaaaaaaaaaaaabaaaaahbcaabaaaadaaaaaaakaabaaaadaaaaaadkaabaaa
adaaaaaadhaaaaajbcaabaaaadaaaaaaakaabaaaaeaaaaaabkaabaaaadaaaaaa
akaabaaaadaaaaaadgaaaaafpcaabaaaaeaaaaaaegaobaaaaaaaaaaadgaaaaaf
pcaabaaaafaaaaaaegaobaaaacaaaaaadgaaaaafccaabaaaadaaaaaaabeaaaaa
ppppppppdaaaaaabccaaaaahecaabaaaadaaaaaaabeaaaaaacaaaaaabkaabaaa
adaaaaaaadaaaeadckaabaaaadaaaaaaboaaaaahecaabaaaadaaaaaadkaabaaa
abaaaaaabkaabaaaadaaaaaaboaaaaahecaabaaaadaaaaaackaabaaaadaaaaaa
abeaaaaaabaaaaaadgaaaaahpcaabaaaagaaaaaaegdocaaeaaaaaaaackaabaaa
adaaaaaaclaaaaafecaabaaaadaaaaaabkaabaaaadaaaaaaaaaaaaaiecaabaaa
adaaaaaabkaabaiaebaaaaaaabaaaaaackaabaaaadaaaaaadbaaaaaiicaabaaa
adaaaaaackaabaiaebaaaaaaadaaaaaaabeaaaaaaaaaaaaadhaaaaakecaabaaa
adaaaaaadkaabaaaadaaaaaackaabaaaadaaaaaackaabaiaebaaaaaaadaaaaaa
diaaaaahicaabaaaadaaaaaackaabaaaadaaaaaackaabaaaadaaaaaadiaaaaah
bcaabaaaahaaaaaackaabaaaadaaaaaadkaabaaaadaaaaaadiaaaaakgcaabaaa
ahaaaaaapgapbaaaadaaaaaaaceaaaaaaaaaaaaaaaaahambaaaahaebaaaaaaaa
dcaaaaamdcaabaaaahaaaaaaagaabaaaahaaaaaaaceaaaaaaaaabaebaaaaeama
aaaaaaaaaaaaaaaajgafbaaaahaaaaaaaaaaaaahicaabaaaadaaaaaaakaabaaa
ahaaaaaaabeaaaaaaaaamaeabnaaaaahbcaabaaaahaaaaaackaabaaaadaaaaaa
abeaaaaaaaaaiadpdbaaaaakmcaabaaaahaaaaaakgakbaaaadaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaiadpaaaaaaeaabaaaaahbcaabaaaahaaaaaadkaabaaa
ahaaaaaaakaabaaaahaaaaaadcaaaaajecaabaaaadaaaaaackaabaaaadaaaaaa
abeaaaaaaaaamambbkaabaaaahaaaaaaaaaaaaahecaabaaaadaaaaaackaabaaa
adaaaaaaabeaaaaaaaaaeaebdiaaaaakmcaabaaaadaaaaaakgaobaaaadaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaklkkckdoklkkckdoabaaaaahecaabaaaadaaaaaa
ckaabaaaadaaaaaaakaabaaaahaaaaaadhaaaaajecaabaaaadaaaaaackaabaaa
ahaaaaaadkaabaaaadaaaaaackaabaaaadaaaaaadiaaaaahpcaabaaaagaaaaaa
agaabaaaadaaaaaaegaobaaaagaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaa
agaaaaaakgakbaaaadaaaaaaegaobaaaaeaaaaaadcaaaaajpcaabaaaafaaaaaa
agaabaaaadaaaaaakgakbaaaadaaaaaaegaobaaaafaaaaaaboaaaaahccaabaaa
adaaaaaabkaabaaaadaaaaaaabeaaaaaabaaaaaabgaaaaabdgaaaaafpcaabaaa
aaaaaaaaegaobaaaaeaaaaaadgaaaaafpcaabaaaacaaaaaaegaobaaaafaaaaaa
boaaaaahecaabaaaabaaaaaackaabaaaabaaaaaaabeaaaaaabaaaaaabgaaaaab
aoaaaaahpccabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaacaaaaaadoaaaaab
"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
"3.0-!!ARBvp1.0
PARAM c[5] = { program.local[0],
		state.matrix.mvp };
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 5 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_position0 v0
dcl_texcoord0 v1
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedgcclnnbgpijgpddakojponflfpghdgniabaaaaaaoeabaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefcaeabaaaa
eaaaabaaebaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaaddccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"3.0-!!ARBfp1.0
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
"ps_3_0
def c0, 0.00000000, 0, 0, 0
mov oC0, c0.x
"
}
SubProgram "d3d11 " {
"ps_4_0
eefiecedkjchoibnfhkdnbjinbbnkdkcngndlcpgabaaaaaapiaaaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaa
eaaaaaaaaoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaab"
}
}
 }
}
Fallback Off
}