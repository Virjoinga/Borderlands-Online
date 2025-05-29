ÚÆShader "Hidden/EdgeDetectGeometry" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "" {}
}
SubShader { 
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Keywords { "NoAlphaCorrection" }
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
Keywords { "NoAlphaCorrection" }
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
Keywords { "NoAlphaCorrection" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
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
SubProgram "opengl " {
Keywords { "AlphaCorrection" }
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
Keywords { "AlphaCorrection" }
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
Keywords { "AlphaCorrection" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
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
Keywords { "NoAlphaCorrection" }
Vector 0 [_ZBufferParams]
Vector 1 [_MainTex_TexelSize]
Vector 2 [_BgColor]
Float 3 [_BgFade]
Float 4 [_SampleDistance]
Float 5 [_Exponent]
Float 6 [_Threshold]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"3.0-!!ARBfp1.0
PARAM c[8] = { program.local[0..6],
		{ 0.0039215689, -1, 1, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xy, c[1];
MUL R1.zw, R0.xyxy, c[4].x;
MAD R0.xy, -R1.zwzw, c[7].wzzw, fragment.texcoord[1];
TEX R0.x, R0, texture[0], 2D;
MAD R0.x, R0, c[0], c[0].y;
MAD R1.xy, R1.zwzw, c[7].zwzw, fragment.texcoord[1];
RCP R0.w, R0.x;
TEX R0.x, R1, texture[0], 2D;
MAD R0.y, R0.x, c[0].x, c[0];
MAD R1.xy, -R1.zwzw, c[7].zwzw, fragment.texcoord[1];
TEX R0.x, R1, texture[0], 2D;
MAD R1.xy, R1.zwzw, c[7].wzzw, fragment.texcoord[1];
TEX R1.x, R1, texture[0], 2D;
RCP R0.z, R0.y;
MAD R0.x, R0, c[0], c[0].y;
RCP R0.y, R0.x;
TEX R0.x, fragment.texcoord[1], texture[0], 2D;
MAD R3.x, R0, c[0], c[0].y;
MAD R1.x, R1, c[0], c[0].y;
RCP R1.y, R3.x;
RCP R0.x, R1.x;
MAX R0, R1.y, R0;
MAD R2, R3.x, R0, -c[7].z;
MAD R0.zw, -R1, c[7].xyyz, fragment.texcoord[1].xyxy;
ADD R0.xy, fragment.texcoord[1], -R1.zwzw;
TEX R0.x, R0, texture[0], 2D;
TEX R1.x, R0.zwzw, texture[0], 2D;
MAD R0.y, R1.x, c[0].x, c[0];
MAD R0.x, R0, c[0], c[0].y;
RCP R0.w, R0.x;
RCP R0.z, R0.y;
ADD R0.xy, fragment.texcoord[1], R1.zwzw;
TEX R0.x, R0, texture[0], 2D;
MAD R1.zw, R1, c[7].xyyz, fragment.texcoord[1].xyxy;
TEX R1.x, R1.zwzw, texture[0], 2D;
MAD R0.y, R1.x, c[0].x, c[0];
MAD R0.x, R0, c[0], c[0].y;
RCP R0.x, R0.x;
RCP R0.y, R0.y;
MAX R0, R0, R1.y;
MUL R1, R2, c[7].wzyw;
MAD R0, R0, R3.x, -c[7].z;
MAD R1, R0, c[7].yzyz, R1;
MUL R2, R2, c[7].zwwy;
MAD R0, R0, c[7].zzyy, R2;
DP4 R1.x, R1, c[7].z;
DP4 R0.x, R0, c[7].z;
MUL R1.x, R1, R1;
MAD R0.x, R0, R0, R1;
RSQ R0.x, R0.x;
RCP_SAT R0.x, R0.x;
POW R1.x, R0.x, c[5].x;
TEX R0, fragment.texcoord[0], texture[1], 2D;
ADD R2.y, -R1.x, c[7].z;
ADD R1, -R0, c[2];
MOV R2.x, c[6];
MAD R1, R1, c[3].x, R0;
MAD R2.x, R2, -c[7], R2.y;
CMP R0.x, -R2, c[7].z, R2.y;
MUL result.color, R0.x, R1;
END
# 60 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "NoAlphaCorrection" }
Vector 0 [_ZBufferParams]
Vector 1 [_MainTex_TexelSize]
Vector 2 [_BgColor]
Float 3 [_BgFade]
Float 4 [_SampleDistance]
Float 5 [_Exponent]
Float 6 [_Threshold]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c7, -1.00000000, 1.00000000, 0.00000000, -0.00392157
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
mov r0.x, c4
mul r1.zw, c1.xyxy, r0.x
mad r0.xy, -r1.zwzw, c7.zyzw, v1
texld r0.x, r0, s0
mad r0.z, r0.x, c0.x, c0.y
mad r0.xy, r1.zwzw, c7.yzzw, v1
texld r0.x, r0, s0
mad r1.xy, -r1.zwzw, c7.yzzw, v1
mad r0.y, r0.x, c0.x, c0
texld r0.x, r1, s0
mad r1.xy, r1.zwzw, c7.zyzw, v1
rcp r0.w, r0.z
texld r1.x, r1, s0
rcp r0.z, r0.y
mad r0.x, r0, c0, c0.y
rcp r0.y, r0.x
texld r0.x, v1, s0
mad r3.x, r0, c0, c0.y
mad r1.x, r1, c0, c0.y
rcp r0.x, r1.x
mad r1.xy, -r1.zwzw, c7, v1
rcp r3.y, r3.x
max r0, r3.y, r0
mad r2, r3.x, r0, c7.x
add r0.xy, v1, -r1.zwzw
texld r0.x, r0, s0
texld r1.x, r1, s0
mad r0.y, r1.x, c0.x, c0
mad r0.x, r0, c0, c0.y
mad r1.xy, r1.zwzw, c7, v1
rcp r0.w, r0.x
rcp r0.z, r0.y
add r0.xy, v1, r1.zwzw
texld r0.x, r0, s0
texld r1.x, r1, s0
mad r0.y, r1.x, c0.x, c0
mul r1, r2, c7.zyxz
mad r0.x, r0, c0, c0.y
mul r2, r2, c7.yzzx
rcp r0.x, r0.x
rcp r0.y, r0.y
max r0, r0, r3.y
mad r0, r0, r3.x, c7.x
mad r1, r0, c7.xyxy, r1
mad r0, r0, c7.yyxx, r2
dp4 r1.x, r1, c7.y
dp4 r0.x, r0, c7.y
mul r1.x, r1, r1
mad r0.x, r0, r0, r1
rsq r0.x, r0.x
rcp_sat r1.x, r0.x
pow r0, r1.x, c5.x
mov r1.x, r0
texld r0, v0, s1
add r2.y, -r1.x, c7
add r1, -r0, c2
mov r2.x, c7.w
mad r1, r1, c3.x, r0
mad r2.x, c6, r2, r2.y
cmp r0.x, -r2, r2.y, c7.y
mul oC0, r0.x, r1
"
}
SubProgram "d3d11 " {
Keywords { "NoAlphaCorrection" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
Vector 32 [_BgColor]
Float 48 [_BgFade]
Float 52 [_SampleDistance]
Float 56 [_Exponent]
Float 60 [_Threshold]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedcmancefgffiocamnbhcmldgdgphklagpabaaaaaaimakaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaadaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaadaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgmajaaaa
eaaaaaaaflacaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaa
abaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacafaaaaaadiaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaafgifcaaaaaaaaaaaadaaaaaadcaaaaanmcaabaaaaaaaaaaaagaebaia
ebaaaaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaiadpaaaaaaaaagbebaaa
acaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaa
akaabaaaabaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakccaabaaaabaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpckaabaaaaaaaaaaadcaaaaam
mcaabaaaaaaaaaaaagaebaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaiadp
aaaaaaaaagbebaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaaakiacaaa
abaaaaaaahaaaaaaakaabaaaacaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaak
ecaabaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpckaabaaa
aaaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaaaaaaaaaaceaaaaaaaaaialp
aaaaiadpaaaaaaaaaaaaiadpegbebaaaacaaaaaadcaaaaanpcaabaaaaaaaaaaa
egaebaiaebaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaiadpaaaaaaaaaaaaiadp
egbebaaaacaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaacaaaaaaakiacaaa
abaaaaaaahaaaaaaakaabaaaacaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaak
ccaabaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaa
acaaaaaadcaaaaalbcaabaaaadaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaa
adaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaabaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaadaaaaaaefaaaaajpcaabaaa
adaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
dcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaa
bkiacaaaabaaaaaaahaaaaaaaoaaaaakecaabaaaacaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaadcaaaaalbcaabaaaaaaaaaaa
akiacaaaabaaaaaaahaaaaaaakaabaaaadaaaaaabkiacaaaabaaaaaaahaaaaaa
aoaaaaakicaabaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
akaabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaa
ahaaaaaaakaabaaaaaaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakccaabaaa
aaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaa
deaaaaahpcaabaaaabaaaaaafgafbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaam
pcaabaaaabaaaaaaegaobaaaabaaaaaaagaabaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaialpaaaaialpdiaaaaakpcaabaaaadaaaaaaegaobaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaiadpaaaaialpaaaaaaaadiaaaaakpcaabaaaabaaaaaa
egaobaaaabaaaaaaaceaaaaaaaaaiadpaaaaaaaaaaaaaaaaaaaaialpdcaaaaal
mcaabaaaaaaaaaaafgifcaaaaaaaaaaaadaaaaaaagiecaaaaaaaaaaaabaaaaaa
agbebaaaacaaaaaaefaaaaajpcaabaaaaeaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaaakiacaaaabaaaaaa
ahaaaaaaakaabaaaaeaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaa
acaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpckaabaaaaaaaaaaa
dcaaaaammcaabaaaaaaaaaaafgifcaiaebaaaaaaaaaaaaaaadaaaaaaagiecaaa
aaaaaaaaabaaaaaaagbebaaaacaaaaaaefaaaaajpcaabaaaaeaaaaaaogakbaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaa
akiacaaaabaaaaaaahaaaaaaakaabaaaaeaaaaaabkiacaaaabaaaaaaahaaaaaa
aoaaaaakicaabaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
ckaabaaaaaaaaaaadeaaaaahpcaabaaaacaaaaaafgafbaaaaaaaaaaaegaobaaa
acaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaacaaaaaaagaabaaaaaaaaaaa
aceaaaaaaaaaialpaaaaialpaaaaialpaaaaialpdcaaaaampcaabaaaacaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaialpaaaaiadpaaaaialpaaaaiadpegaobaaa
adaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaialpaaaaialpegaobaaaabaaaaaabbaaaaakbcaabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpbbaaaaak
ccaabaaaaaaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadp
aaaaiadpdiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaa
aaaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaddaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaa
aaaaaaaaadaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaai
bcaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaai
ccaabaaaaaaaaaaadkiacaaaaaaaaaaaadaaaaaaabeaaaaaibiaiadldbaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaadhaaaaajbcaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiadpakaabaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
aaaaaaajpcaabaaaacaaaaaaegaobaiaebaaaaaaabaaaaaaegiocaaaaaaaaaaa
acaaaaaadcaaaaakpcaabaaaabaaaaaaagiacaaaaaaaaaaaadaaaaaaegaobaaa
acaaaaaaegaobaaaabaaaaaadiaaaaahpccabaaaaaaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "AlphaCorrection" }
Vector 0 [_ZBufferParams]
Vector 1 [_MainTex_TexelSize]
Vector 2 [_BgColor]
Float 3 [_BgFade]
Float 4 [_SampleDistance]
Float 5 [_Exponent]
Float 6 [_Threshold]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"3.0-!!ARBfp1.0
PARAM c[9] = { program.local[0..6],
		{ 0.0039215689, -1, 1, 0 },
		{ 0.0099999998 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0.xy, c[1];
MUL R1.zw, R0.xyxy, c[4].x;
MAD R0.xy, -R1.zwzw, c[7].wzzw, fragment.texcoord[1];
TEX R0.x, R0, texture[0], 2D;
MAD R0.x, R0, c[0], c[0].y;
MAD R1.xy, R1.zwzw, c[7].zwzw, fragment.texcoord[1];
RCP R0.w, R0.x;
TEX R0.x, R1, texture[0], 2D;
MAD R0.y, R0.x, c[0].x, c[0];
MAD R1.xy, -R1.zwzw, c[7].zwzw, fragment.texcoord[1];
TEX R0.x, R1, texture[0], 2D;
MAD R1.xy, R1.zwzw, c[7].wzzw, fragment.texcoord[1];
TEX R1.x, R1, texture[0], 2D;
RCP R0.z, R0.y;
MAD R0.x, R0, c[0], c[0].y;
RCP R0.y, R0.x;
TEX R0.x, fragment.texcoord[1], texture[0], 2D;
MAD R3.x, R0, c[0], c[0].y;
MAD R1.x, R1, c[0], c[0].y;
RCP R1.y, R3.x;
RCP R0.x, R1.x;
MAX R0, R1.y, R0;
MAD R2, R3.x, R0, -c[7].z;
MAD R0.zw, -R1, c[7].xyyz, fragment.texcoord[1].xyxy;
ADD R0.xy, fragment.texcoord[1], -R1.zwzw;
TEX R0.x, R0, texture[0], 2D;
TEX R1.x, R0.zwzw, texture[0], 2D;
MAD R0.y, R1.x, c[0].x, c[0];
MAD R0.x, R0, c[0], c[0].y;
RCP R0.w, R0.x;
RCP R0.z, R0.y;
ADD R0.xy, fragment.texcoord[1], R1.zwzw;
TEX R0.x, R0, texture[0], 2D;
MAD R1.zw, R1, c[7].xyyz, fragment.texcoord[1].xyxy;
TEX R1.x, R1.zwzw, texture[0], 2D;
MAD R0.y, R1.x, c[0].x, c[0];
MAD R0.x, R0, c[0], c[0].y;
RCP R0.x, R0.x;
RCP R0.y, R0.y;
MAX R0, R0, R1.y;
MUL R1, R2, c[7].wzyw;
MAD R0, R0, R3.x, -c[7].z;
MAD R1, R0, c[7].yzyz, R1;
MUL R2, R2, c[7].zwwy;
MAD R0, R0, c[7].zzyy, R2;
DP4 R1.x, R1, c[7].z;
DP4 R0.x, R0, c[7].z;
MUL R1.x, R1, R1;
MAD R0.x, R0, R0, R1;
RSQ R0.x, R0.x;
RCP_SAT R0.x, R0.x;
POW R1.x, R0.x, c[5].x;
TEX R0, fragment.texcoord[0], texture[1], 2D;
ADD R2.y, -R1.x, c[7].z;
ADD R1, -R0, c[2];
MOV R2.x, c[6];
MAD R1, R1, c[3].x, R0;
MAD R2.x, R2, -c[7], R2.y;
CMP R0.x, -R2, c[7].z, R2.y;
MUL R1, R0.x, R1;
ADD R0.x, R0, -c[8];
CMP result.color.w, R0.x, c[7].z, R1;
MOV result.color.xyz, R1;
END
# 63 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "AlphaCorrection" }
Vector 0 [_ZBufferParams]
Vector 1 [_MainTex_TexelSize]
Vector 2 [_BgColor]
Float 3 [_BgFade]
Float 4 [_SampleDistance]
Float 5 [_Exponent]
Float 6 [_Threshold]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c7, -1.00000000, 1.00000000, 0.00000000, -0.00392157
def c8, -0.01000000, 0, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
mov r0.x, c4
mul r1.zw, c1.xyxy, r0.x
mad r0.xy, -r1.zwzw, c7.zyzw, v1
texld r0.x, r0, s0
mad r0.z, r0.x, c0.x, c0.y
mad r0.xy, r1.zwzw, c7.yzzw, v1
texld r0.x, r0, s0
mad r1.xy, -r1.zwzw, c7.yzzw, v1
mad r0.y, r0.x, c0.x, c0
texld r0.x, r1, s0
mad r1.xy, r1.zwzw, c7.zyzw, v1
rcp r0.w, r0.z
texld r1.x, r1, s0
rcp r0.z, r0.y
mad r0.x, r0, c0, c0.y
rcp r0.y, r0.x
texld r0.x, v1, s0
mad r3.x, r0, c0, c0.y
mad r1.x, r1, c0, c0.y
rcp r0.x, r1.x
mad r1.xy, -r1.zwzw, c7, v1
rcp r3.y, r3.x
max r0, r3.y, r0
mad r2, r3.x, r0, c7.x
add r0.xy, v1, -r1.zwzw
texld r0.x, r0, s0
texld r1.x, r1, s0
mad r0.y, r1.x, c0.x, c0
mad r0.x, r0, c0, c0.y
mad r1.xy, r1.zwzw, c7, v1
rcp r0.w, r0.x
rcp r0.z, r0.y
add r0.xy, v1, r1.zwzw
texld r0.x, r0, s0
texld r1.x, r1, s0
mad r0.y, r1.x, c0.x, c0
mul r1, r2, c7.zyxz
mad r0.x, r0, c0, c0.y
mul r2, r2, c7.yzzx
rcp r0.x, r0.x
rcp r0.y, r0.y
max r0, r0, r3.y
mad r0, r0, r3.x, c7.x
mad r1, r0, c7.xyxy, r1
mad r0, r0, c7.yyxx, r2
dp4 r1.x, r1, c7.y
dp4 r0.x, r0, c7.y
mul r1.x, r1, r1
mad r0.x, r0, r0, r1
rsq r0.x, r0.x
rcp_sat r1.x, r0.x
pow r0, r1.x, c5.x
mov r1.x, r0
texld r0, v0, s1
add r2.y, -r1.x, c7
add r1, -r0, c2
mov r2.x, c7.w
mad r1, r1, c3.x, r0
mad r2.x, c6, r2, r2.y
cmp r0.x, -r2, r2.y, c7.y
mul r1, r0.x, r1
add r0.x, r0, c8
cmp oC0.w, r0.x, r1, c7.y
mov oC0.xyz, r1
"
}
SubProgram "d3d11 " {
Keywords { "AlphaCorrection" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
Vector 32 [_BgColor]
Float 48 [_BgFade]
Float 52 [_SampleDistance]
Float 56 [_Exponent]
Float 60 [_Threshold]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedijjnoecojfcbhpeialifagiikegfpckjabaaaaaaoaakaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaadaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaadaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmaajaaaa
eaaaaaaahaacaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaa
abaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacafaaaaaadiaaaaajdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
abaaaaaafgifcaaaaaaaaaaaadaaaaaadcaaaaanmcaabaaaaaaaaaaaagaebaia
ebaaaaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaiadpaaaaaaaaagbebaaa
acaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaa
akaabaaaabaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakccaabaaaabaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpckaabaaaaaaaaaaadcaaaaam
mcaabaaaaaaaaaaaagaebaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaiadp
aaaaaaaaagbebaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaaakiacaaa
abaaaaaaahaaaaaaakaabaaaacaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaak
ecaabaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpckaabaaa
aaaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaaaaaaaaaaceaaaaaaaaaialp
aaaaiadpaaaaaaaaaaaaiadpegbebaaaacaaaaaadcaaaaanpcaabaaaaaaaaaaa
egaebaiaebaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaiadpaaaaaaaaaaaaiadp
egbebaaaacaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaacaaaaaaakiacaaa
abaaaaaaahaaaaaaakaabaaaacaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaak
ccaabaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaa
acaaaaaadcaaaaalbcaabaaaadaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaa
adaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaabaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaadaaaaaaefaaaaajpcaabaaa
adaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
dcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaa
bkiacaaaabaaaaaaahaaaaaaaoaaaaakecaabaaaacaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaadcaaaaalbcaabaaaaaaaaaaa
akiacaaaabaaaaaaahaaaaaaakaabaaaadaaaaaabkiacaaaabaaaaaaahaaaaaa
aoaaaaakicaabaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
akaabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaa
ahaaaaaaakaabaaaaaaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakccaabaaa
aaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaa
deaaaaahpcaabaaaabaaaaaafgafbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaam
pcaabaaaabaaaaaaegaobaaaabaaaaaaagaabaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaialpaaaaialpdiaaaaakpcaabaaaadaaaaaaegaobaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaiadpaaaaialpaaaaaaaadiaaaaakpcaabaaaabaaaaaa
egaobaaaabaaaaaaaceaaaaaaaaaiadpaaaaaaaaaaaaaaaaaaaaialpdcaaaaal
mcaabaaaaaaaaaaafgifcaaaaaaaaaaaadaaaaaaagiecaaaaaaaaaaaabaaaaaa
agbebaaaacaaaaaaefaaaaajpcaabaaaaeaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaaakiacaaaabaaaaaa
ahaaaaaaakaabaaaaeaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaa
acaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpckaabaaaaaaaaaaa
dcaaaaammcaabaaaaaaaaaaafgifcaiaebaaaaaaaaaaaaaaadaaaaaaagiecaaa
aaaaaaaaabaaaaaaagbebaaaacaaaaaaefaaaaajpcaabaaaaeaaaaaaogakbaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalecaabaaaaaaaaaaa
akiacaaaabaaaaaaahaaaaaaakaabaaaaeaaaaaabkiacaaaabaaaaaaahaaaaaa
aoaaaaakicaabaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
ckaabaaaaaaaaaaadeaaaaahpcaabaaaacaaaaaafgafbaaaaaaaaaaaegaobaaa
acaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaacaaaaaaagaabaaaaaaaaaaa
aceaaaaaaaaaialpaaaaialpaaaaialpaaaaialpdcaaaaampcaabaaaacaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaialpaaaaiadpaaaaialpaaaaiadpegaobaaa
adaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaialpaaaaialpegaobaaaabaaaaaabbaaaaakbcaabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpbbaaaaak
ccaabaaaaaaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadp
aaaaiadpdiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaaaaaaaaa
dcaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaa
aaaaaaaaelaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaddaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaackiacaaa
aaaaaaaaadaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaai
bcaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaai
ccaabaaaaaaaaaaadkiacaaaaaaaaaaaadaaaaaaabeaaaaaibiaiadldbaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaadhaaaaajbcaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiadpakaabaaaaaaaaaaadbaaaaah
ccaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaknhcddmefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaaaaaaaaj
pcaabaaaacaaaaaaegaobaiaebaaaaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaa
dcaaaaakpcaabaaaabaaaaaaagiacaaaaaaaaaaaadaaaaaaegaobaaaacaaaaaa
egaobaaaabaaaaaadiaaaaahpcaabaaaabaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaadhaaaaajiccabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiadp
dkaabaaaabaaaaaadgaaaaafhccabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
}
 }
}
Fallback Off
}