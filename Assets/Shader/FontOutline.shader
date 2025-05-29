‡‹Shader "Custom/FontOutline" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _OriTex ("Base (RGB)", 2D) = "black" {}
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
MOV result.texcoord[1].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 6 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, v1
mov o2.xy, r1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddbbbmdklahgjciloapjampdnhiehnaelabaaaaaaniacaaaaadaaaaaa
cmaaaaaaiaaaaaaadiabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaadapaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaadapaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaadapaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefcjiabaaaa
eaaaabaaggaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaadbaaaaai
bcaabaaaaaaaaaaabkiacaaaaaaaaaaaabaaaaaaabeaaaaaaaaaaaaaaaaaaaai
ccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadpdhaaaaaj
cccabaaaacaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaaabaaaaaa
dgaaaaafbccabaaaacaaaaaaakbabaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_MainTex_TexelSize]
Float 1 [_SampleDistance]
Float 2 [_Exponent]
Vector 3 [_OutlineColor]
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
PARAM c[5] = { program.local[0..3],
		{ -1, 1, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0.xy, c[0];
MUL R0.xy, R0, c[1].x;
MAD R0.zw, -R0.xyxy, c[4].xyzy, fragment.texcoord[1].xyxy;
TEX R2.w, R0.zwzw, texture[0], 2D;
MAD R0.zw, R0.xyxy, c[4].xyyz, fragment.texcoord[1].xyxy;
MAD R1.xy, -R0, c[4].yzzw, fragment.texcoord[1];
TEX R1.w, R1, texture[0], 2D;
TEX R0.w, R0.zwzw, texture[0], 2D;
MOV R2.z, R0.w;
TEX R0.w, fragment.texcoord[1], texture[0], 2D;
MOV R2.y, R1.w;
MAD R1.xy, R0, c[4].zyzw, fragment.texcoord[1];
TEX R1.w, R1, texture[0], 2D;
MOV R2.x, R1.w;
MAD R1.zw, -R0.xyxy, c[4].xyxy, fragment.texcoord[1].xyxy;
TEX R1.w, R1.zwzw, texture[0], 2D;
ADD R1.xy, fragment.texcoord[1], -R0;
RCP R0.z, R0.w;
MUL R3, R2, R0.z;
TEX R5.w, R1, texture[0], 2D;
ADD R1.xy, fragment.texcoord[1], R0;
MOV R5.z, R1.w;
MAD R0.xy, R0, c[4], fragment.texcoord[1];
TEX R2.w, R0, texture[0], 2D;
TEX R1.w, R1, texture[0], 2D;
MOV R5.y, R2.w;
MOV R5.x, R1.w;
ADD R0, R5, -R0.w;
MUL R4, R3, c[4].zyxz;
MAD R1, R0, c[4].xyxy, R4;
MUL R2, R3, c[4].yzzx;
DP4 R1.x, R1, c[4].y;
MAD R0, R0, c[4].yyxx, R2;
MUL R1.x, R1, R1;
DP4 R0.x, R0, c[4].y;
MAD R0.x, R0, R0, R1;
RSQ R0.x, R0.x;
RCP_SAT R0.x, R0.x;
POW R0.x, R0.x, c[2].x;
MUL result.color, R0.x, c[3];
END
# 40 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Float 1 [_SampleDistance]
Float 2 [_Exponent]
Vector 3 [_OutlineColor]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c4, -1.00000000, 1.00000000, 0.00000000, 0
dcl_texcoord1 v0.xy
mov r0.x, c1
mul r0.xy, c0, r0.x
mad r2.xy, r0, c4.yzzw, v0
texld r0.w, r2, s0
mad r1.xy, -r0, c4.zyzw, v0
texld r2.w, r1, s0
mad r1.xy, -r0, c4.yzzw, v0
texld r1.w, r1, s0
mov r2.z, r0.w
texld r0.w, v0, s0
mov r2.y, r1.w
mad r1.xy, r0, c4.zyzw, v0
texld r1.w, r1, s0
add r1.xy, v0, -r0
texld r5.w, r1, s0
mov r2.x, r1.w
rcp r0.z, r0.w
mul r3, r2, r0.z
mad r2.xy, -r0, c4, v0
texld r1.w, r2, s0
add r1.xy, v0, r0
mov r5.z, r1.w
mad r0.xy, r0, c4, v0
texld r2.w, r0, s0
texld r1.w, r1, s0
mov r5.y, r2.w
mov r5.x, r1.w
add r0, r5, -r0.w
mul r4, r3, c4.zyxz
mad r1, r0, c4.xyxy, r4
mul r2, r3, c4.yzzx
mad r0, r0, c4.yyxx, r2
dp4 r1.x, r1, c4.y
dp4 r0.x, r0, c4.y
mul r1.x, r1, r1
mad r0.x, r0, r0, r1
rsq r0.x, r0.x
rcp_sat r1.x, r0.x
pow r0, r1.x, c2.x
mul oC0, r0.x, c3
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 16 [_MainTex_TexelSize]
Float 84 [_SampleDistance]
Float 88 [_Exponent]
Vector 96 [_OutlineColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedafohahnhecjnnedmijgedlfnebkgdcdkabaaaaaanaagaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaadaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaadaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefclaafaaaa
eaaaaaaagmabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaacaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaadiaaaaajdcaabaaaaaaaaaaa
egiacaaaaaaaaaaaabaaaaaafgifcaaaaaaaaaaaafaaaaaadcaaaaanmcaabaaa
aaaaaaaaagaebaiaebaaaaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaiadp
aaaaaaaaagbebaaaacaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
mghjbaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaammcaabaaaaaaaaaaaagaebaaa
aaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaiadpaaaaaaaaagbebaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadgaaaaafecaabaaaabaaaaaadkaabaaaacaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaam
pcaabaaaadaaaaaaegaebaaaaaaaaaaaaceaaaaaaaaaialpaaaaiadpaaaaaaaa
aaaaiadpegbebaaaacaaaaaadcaaaaanpcaabaaaaaaaaaaaegaebaiaebaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaiadpaaaaaaaaaaaaiadpegbebaaaacaaaaaa
efaaaaajpcaabaaaaeaaaaaaogakbaaaadaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaamghjbaaaaaaaaaaa
aagabaaaaaaaaaaadgaaaaafbcaabaaaabaaaaaadkaabaaaaeaaaaaaefaaaaaj
pcaabaaaaeaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadgaaaaafecaabaaaadaaaaaadkaabaaaaaaaaaaadgaaaaaficaabaaa
abaaaaaadkaabaaaaeaaaaaaaoaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaa
pgapbaaaacaaaaaadiaaaaakpcaabaaaabaaaaaaegaobaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaiadpaaaaialpaaaaaaaadiaaaaakpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaaceaaaaaaaaaiadpaaaaaaaaaaaaaaaaaaaaialpdcaaaaaldcaabaaa
acaaaaaafgifcaaaaaaaaaaaafaaaaaaegiacaaaaaaaaaaaabaaaaaaegbabaaa
acaaaaaaefaaaaajpcaabaaaaeaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadgaaaaafbcaabaaaadaaaaaadkaabaaaaeaaaaaadcaaaaam
dcaabaaaacaaaaaafgifcaiaebaaaaaaaaaaaaaaafaaaaaaegiacaaaaaaaaaaa
abaaaaaaegbabaaaacaaaaaaefaaaaajpcaabaaaaeaaaaaaegaabaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaaficaabaaaadaaaaaadkaabaaa
aeaaaaaaaaaaaaaipcaabaaaacaaaaaapgapbaiaebaaaaaaacaaaaaaegaobaaa
adaaaaaadcaaaaampcaabaaaabaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaialp
aaaaiadpaaaaialpaaaaiadpegaobaaaabaaaaaadcaaaaampcaabaaaaaaaaaaa
egaobaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaialpaaaaialpegaobaaa
aaaaaaaabbaaaaakbcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpbbaaaaakccaabaaaaaaaaaaaegaobaaaabaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpdiaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaaelaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaddaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaiadpcpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaa
aaaaaaaaakaabaaaaaaaaaaackiacaaaaaaaaaaaafaaaaaabjaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpaaaaaaaibcaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdiaaaaaipccabaaaaaaaaaaaagaabaaaaaaaaaaa
egiocaaaaaaaaaaaagaaaaaadoaaaaab"
}
}
 }
 Pass {
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Vector 5 [_MainTex_TexelSize]
"3.0-!!ARBvp1.0
PARAM c[6] = { { -0.5, 0.5 },
		state.matrix.mvp,
		program.local[5] };
TEMP R0;
MOV R0.xy, c[0];
ADD result.texcoord[0].xy, vertex.texcoord[0], c[5];
MAD result.texcoord[1].xy, R0.x, c[5], vertex.texcoord[0];
MAD result.texcoord[2].xy, R0.yxzw, c[5], vertex.texcoord[0];
MAD result.texcoord[3].xy, R0, c[5], vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
def c5, -0.50000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, c4
mad o2.xy, c5.x, r0, v1
mov r0.xy, c4
mov r0.zw, c4.xyxy
add o1.xy, v1, c4
mad o3.xy, c5.yxzw, r0, v1
mad o4.xy, c5, r0.zwzw, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedcelcjkichjmnkoiecpldlgnjkhalnppbabaaaaaaaiadaaaaadaaaaaa
cmaaaaaaiaaaaaaacaabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadamaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaa
acaaaaaaamadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
fdeieefcoaabaaaaeaaaabaahiaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaa
fjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaa
abaaaaaagfaaaaadmccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaad
mccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaaaaaaaaaidccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaabaaaaaadcaaaaanmccabaaaabaaaaaaagiecaaaaaaaaaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaalpaaaaaalpagbebaaaabaaaaaadcaaaaan
dccabaaaacaaaaaaegiacaaaaaaaaaaaabaaaaaaaceaaaaaaaaaaadpaaaaaalp
aaaaaaaaaaaaaaaaegbabaaaabaaaaaadcaaaaanmccabaaaacaaaaaaagiecaaa
aaaaaaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaalpaaaaaadpagbebaaa
abaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0.25 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1, fragment.texcoord[1], texture[0], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
ADD R2, R0, R1;
TEX R0, fragment.texcoord[2], texture[0], 2D;
TEX R1, fragment.texcoord[3], texture[0], 2D;
ADD R0, R2, R0;
ADD R0, R0, R1;
MUL result.color, R0, c[0].x;
END
# 8 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 0.25000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
dcl_texcoord2 v2.xy
dcl_texcoord3 v3.xy
texld r1, v1, s0
texld r0, v0, s0
add_pp r2, r0, r1
texld r0, v2, s0
texld r1, v3, s0
add_pp r0, r2, r0
add_pp r0, r0, r1
mul_pp oC0, r0, c0.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedalknenbibabgihclfmlldhpebhnaneffabaaaaaaiaacaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefchiabaaaaeaaaaaaafoaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadiaaaaakpccabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiadoaaaaiadodoaaaaab
"
}
}
 }
 Pass {
  ZTest Always
  Cull Off
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Vector 5 [_MainTex_TexelSize]
Float 6 [_Parameter]
"3.0-!!ARBvp1.0
PARAM c[7] = { { 1, 0 },
		state.matrix.mvp,
		program.local[5..6] };
TEMP R0;
MOV R0.x, c[6];
MUL R0.xy, R0.x, c[5];
MOV result.texcoord[0].xy, vertex.texcoord[0];
MOV result.texcoord[0].zw, c[0].x;
MUL result.texcoord[1].xy, R0, c[0].yxzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
Float 5 [_Parameter]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c6, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, c4
mul r0.xy, c5.x, r0
mov o1.xy, v1
mov o1.zw, c6.x
mul o2.xy, r0, c6.yxzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 16 [_MainTex_TexelSize]
Float 112 [_Parameter]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedegdoibglhpapkdchjakjmpokkjicjddoabaaaaaakmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklfdeieefcleabaaaaeaaaabaagnaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaadgaaaaaimccabaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaiadpaaaaiadpdgaaaaagjcaabaaaaaaaaaaa
agiacaaaaaaaaaaaahaaaaaadgaaaaaigcaabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaiadpaaaaaaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaaegaabaaaaaaaaaaa
egiacaaaaaaaaaaaabaaaaaadiaaaaahdccabaaaacaaaaaaogakbaaaaaaaaaaa
egaabaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { { 3, 0.020492554, 0, 0.085510254 },
		{ 0.23205566, 0, 0.32397461, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xy, fragment.texcoord[0];
MAD R0.xy, -fragment.texcoord[1], c[0].x, R0;
ADD R2.xy, R0, fragment.texcoord[1];
TEX R1, R2, texture[0], 2D;
TEX R0, R0, texture[0], 2D;
MUL R1, R1, c[0].wwwz;
ADD R2.xy, R2, fragment.texcoord[1];
MAD R1, R0, c[0].yyyz, R1;
TEX R0, R2, texture[0], 2D;
ADD R2.xy, R2, fragment.texcoord[1];
MAD R1, R0, c[1].xxxy, R1;
TEX R0, R2, texture[0], 2D;
ADD R2.xy, R2, fragment.texcoord[1];
MAD R1, R0, c[1].zzzw, R1;
TEX R0, R2, texture[0], 2D;
MAD R1, R0, c[1].xxxy, R1;
ADD R2.xy, R2, fragment.texcoord[1];
TEX R0, R2, texture[0], 2D;
MAD R0, R0, c[0].wwwz, R1;
ADD R2.xy, R2, fragment.texcoord[1];
TEX R1, R2, texture[0], 2D;
MAD result.color, R1, c[0].yyyz, R0;
END
# 22 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 3.00000000, 0.08551025, 0.00000000, 0.02049255
def c1, 0.23205566, 0.00000000, 0.32397461, 1.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
mov_pp r0.xy, v0
mad_pp r0.xy, -v1, c0.x, r0
add_pp r2.xy, r0, v1
texld r1, r2, s0
texld r0, r0, s0
mul_pp r1, r1, c0.yyyz
add_pp r2.xy, r2, v1
mad_pp r1, r0, c0.wwwz, r1
texld r0, r2, s0
add_pp r2.xy, r2, v1
mad_pp r1, r0, c1.xxxy, r1
texld r0, r2, s0
add_pp r2.xy, r2, v1
mad_pp r1, r0, c1.zzzw, r1
texld r0, r2, s0
mad_pp r1, r0, c1.xxxy, r1
add_pp r2.xy, r2, v1
texld r0, r2, s0
mad_pp r0, r0, c0.yyyz, r1
add_pp r2.xy, r2, v1
texld r1, r2, s0
mad_pp oC0, r1, c0.wwwz, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedpmidpnaopnhhgdlplnhdohjapolhdokbabaaaaaaoiacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaacaaaaeaaaaaaaieaaaaaa
dfbiaaaaboaaaaaajoopkhdmaaaaaaaaaaaaaaaaaaaaaaaakabkkpdnaaaaaaaa
aaaaaaaaaaaaaaaagijbgndoaaaaaaaaaaaaaaaaaaaaaaaafeodkfdoaaaaaaaa
aaaaaaaaaaaaiadpgijbgndoaaaaaaaaaaaaaaaaaaaaaaaakabkkpdnaaaaaaaa
aaaaaaaaaaaaaaaajoopkhdmaaaaaaaaaaaaaaaaaaaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaa
dcaaaaandcaabaaaaaaaaaaaegbabaiaebaaaaaaacaaaaaaaceaaaaaaaaaeaea
aaaaeaeaaaaaaaaaaaaaaaaaegbabaaaabaaaaaadgaaaaaipcaabaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadgaaaaafmcaabaaaaaaaaaaa
agaebaaaaaaaaaaadgaaaaafbcaabaaaacaaaaaaabeaaaaaaaaaaaaadaaaaaab
cbaaaaahccaabaaaacaaaaaaakaabaaaacaaaaaaabeaaaaaahaaaaaaadaaaead
bkaabaaaacaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadcaaaaakpcaabaaaabaaaaaaegaobaaaadaaaaaa
agjmjaaaakaabaaaacaaaaaaegaobaaaabaaaaaaaaaaaaahmcaabaaaaaaaaaaa
kgaobaaaaaaaaaaaagbebaaaacaaaaaaboaaaaahbcaabaaaacaaaaaaakaabaaa
acaaaaaaabeaaaaaabaaaaaabgaaaaabdgaaaaafpccabaaaaaaaaaaaegaobaaa
abaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  Cull Off
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Vector 5 [_MainTex_TexelSize]
Float 6 [_Parameter]
"3.0-!!ARBvp1.0
PARAM c[7] = { { 1, 0 },
		state.matrix.mvp,
		program.local[5..6] };
TEMP R0;
MOV R0.x, c[6];
MUL R0.xy, R0.x, c[5];
MOV result.texcoord[0].xy, vertex.texcoord[0];
MOV result.texcoord[0].zw, c[0].x;
MUL result.texcoord[1].xy, R0, c[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
Float 5 [_Parameter]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c6, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, c4
mul r0.xy, c5.x, r0
mov o1.xy, v1
mov o1.zw, c6.x
mul o2.xy, r0, c6
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Vector 16 [_MainTex_TexelSize]
Float 112 [_Parameter]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedaekidmnfcbmhpbomigfinknnehphlbfjabaaaaaakmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklfdeieefcleabaaaaeaaaabaagnaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaadgaaaaaimccabaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaiadpaaaaiadpdgaaaaaijcaabaaaaaaaaaaa
aceaaaaaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaadgaaaaaggcaabaaaaaaaaaaa
agiacaaaaaaaaaaaahaaaaaadiaaaaaidcaabaaaaaaaaaaaegaabaaaaaaaaaaa
egiacaaaaaaaaaaaabaaaaaadiaaaaahdccabaaaacaaaaaaogakbaaaaaaaaaaa
egaabaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
SetTexture 0 [_MainTex] 2D 0
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { { 3, 0.020492554, 0, 0.085510254 },
		{ 0.23205566, 0, 0.32397461, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
MOV R0.xy, fragment.texcoord[0];
MAD R0.xy, -fragment.texcoord[1], c[0].x, R0;
ADD R2.xy, R0, fragment.texcoord[1];
TEX R1, R2, texture[0], 2D;
TEX R0, R0, texture[0], 2D;
MUL R1, R1, c[0].wwwz;
ADD R2.xy, R2, fragment.texcoord[1];
MAD R1, R0, c[0].yyyz, R1;
TEX R0, R2, texture[0], 2D;
ADD R2.xy, R2, fragment.texcoord[1];
MAD R1, R0, c[1].xxxy, R1;
TEX R0, R2, texture[0], 2D;
ADD R2.xy, R2, fragment.texcoord[1];
MAD R1, R0, c[1].zzzw, R1;
TEX R0, R2, texture[0], 2D;
MAD R1, R0, c[1].xxxy, R1;
ADD R2.xy, R2, fragment.texcoord[1];
TEX R0, R2, texture[0], 2D;
MAD R0, R0, c[0].wwwz, R1;
ADD R2.xy, R2, fragment.texcoord[1];
TEX R1, R2, texture[0], 2D;
MAD result.color, R1, c[0].yyyz, R0;
END
# 22 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 3.00000000, 0.08551025, 0.00000000, 0.02049255
def c1, 0.23205566, 0.00000000, 0.32397461, 1.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
mov_pp r0.xy, v0
mad_pp r0.xy, -v1, c0.x, r0
add_pp r2.xy, r0, v1
texld r1, r2, s0
texld r0, r0, s0
mul_pp r1, r1, c0.yyyz
add_pp r2.xy, r2, v1
mad_pp r1, r0, c0.wwwz, r1
texld r0, r2, s0
add_pp r2.xy, r2, v1
mad_pp r1, r0, c1.xxxy, r1
texld r0, r2, s0
add_pp r2.xy, r2, v1
mad_pp r1, r0, c1.zzzw, r1
texld r0, r2, s0
mad_pp r1, r0, c1.xxxy, r1
add_pp r2.xy, r2, v1
texld r0, r2, s0
mad_pp r0, r0, c0.yyyz, r1
add_pp r2.xy, r2, v1
texld r1, r2, s0
mad_pp oC0, r1, c0.wwwz, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedpmidpnaopnhhgdlplnhdohjapolhdokbabaaaaaaoiacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaacaaaaeaaaaaaaieaaaaaa
dfbiaaaaboaaaaaajoopkhdmaaaaaaaaaaaaaaaaaaaaaaaakabkkpdnaaaaaaaa
aaaaaaaaaaaaaaaagijbgndoaaaaaaaaaaaaaaaaaaaaaaaafeodkfdoaaaaaaaa
aaaaaaaaaaaaiadpgijbgndoaaaaaaaaaaaaaaaaaaaaaaaakabkkpdnaaaaaaaa
aaaaaaaaaaaaaaaajoopkhdmaaaaaaaaaaaaaaaaaaaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaa
dcaaaaandcaabaaaaaaaaaaaegbabaiaebaaaaaaacaaaaaaaceaaaaaaaaaeaea
aaaaeaeaaaaaaaaaaaaaaaaaegbabaaaabaaaaaadgaaaaaipcaabaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadgaaaaafmcaabaaaaaaaaaaa
agaebaaaaaaaaaaadgaaaaafbcaabaaaacaaaaaaabeaaaaaaaaaaaaadaaaaaab
cbaaaaahccaabaaaacaaaaaaakaabaaaacaaaaaaabeaaaaaahaaaaaaadaaaead
bkaabaaaacaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadcaaaaakpcaabaaaabaaaaaaegaobaaaadaaaaaa
agjmjaaaakaabaaaacaaaaaaegaobaaaabaaaaaaaaaaaaahmcaabaaaaaaaaaaa
kgaobaaaaaaaaaaaagbebaaaacaaaaaaboaaaaahbcaabaaaacaaaaaaakaabaaa
acaaaaaaabeaaaaaabaaaaaabgaaaaabdgaaaaafpccabaaaaaaaaaaaegaobaaa
abaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  Cull Off
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
Vector 0 [_BgFadeColor]
Float 1 [_BgFade]
SetTexture 0 [_OriTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0..1] };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1, fragment.texcoord[0], texture[0], 2D;
ADD R2, -R1, c[0];
TEX R0, fragment.texcoord[0], texture[1], 2D;
MAD R2, R2, c[1].x, R1;
ADD R2, R2, -R0;
MAD result.color, R1.w, R2, R0;
END
# 6 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_BgFadeColor]
Float 1 [_BgFade]
SetTexture 0 [_OriTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_texcoord0 v0.xy
texld r0, v0, s0
add r2, -r0, c0
texld r1, v0, s1
mad r2, r2, c1.x, r0
add r2, r2, -r1
mad oC0, r0.w, r2, r1
"
}
SubProgram "d3d11 " {
SetTexture 0 [_OriTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Vector 64 [_BgFadeColor]
Float 80 [_BgFade]
BindCB  "$Globals" 0
"ps_4_0
eefiecedbbijbfgekmbeggilmgamafllcbdlibpnabaaaaaaamacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcemabaaaa
eaaaaaaafdaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaajpcaabaaaabaaaaaa
egaobaiaebaaaaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaadcaaaaakpcaabaaa
abaaaaaaagiacaaaaaaaaaaaafaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaaaaaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaiaebaaaaaa
acaaaaaadcaaaaajpccabaaaaaaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaa
egaobaaaacaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  Cull Off
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
Float 0 [_Intensity]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_OriTex] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1, fragment.texcoord[0], texture[1], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MAD R2, -R0, c[0].x, R1;
DP3 R1.x, R1, c[1].x;
MUL R0, R0, c[0].x;
CMP R1.x, -R1, c[1], c[1].y;
MAD result.color, R1.x, R2, R0;
END
# 7 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_Intensity]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_OriTex] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c1, 1.00000000, 0.00000000, 0, 0
dcl_texcoord0 v0.xy
texld r1, v0, s1
texld r0, v0, s0
mad r2, -r0, c0.x, r1
dp3 r1.x, r1, c1.x
mul r0, r0, c0.x
cmp r1.x, -r1, c1.y, c1
mad oC0, r1.x, r2, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_OriTex] 2D 1
ConstBuffer "$Globals" 128
Float 32 [_Intensity]
BindCB  "$Globals" 0
"ps_4_0
eefiecedghafochafbdnmgocnjmmdkbmheaoelceabaaaaaaemacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcimabaaaa
eaaaaaaagdaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaabaaaaaakbcaabaaaabaaaaaa
egacbaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaaaaadbaaaaah
bcaabaaaabaaaaaaabeaaaaaaaaaaaaaakaabaaaabaaaaaaabaaaaahbcaabaaa
abaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaacaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaa
adaaaaaaegaobaaaacaaaaaaagiacaaaaaaaaaaaacaaaaaadcaaaaalpcaabaaa
aaaaaaaaegaobaiaebaaaaaaacaaaaaaagiacaaaaaaaaaaaacaaaaaaegaobaaa
aaaaaaaadcaaaaajpccabaaaaaaaaaaaagaabaaaabaaaaaaegaobaaaaaaaaaaa
egaobaaaadaaaaaadoaaaaab"
}
}
 }
}
Fallback Off
}