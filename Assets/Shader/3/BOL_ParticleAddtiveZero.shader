„¬Shader "BOL/FX/ParticleAddtiveZero" {
Properties {
 _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
 _MainTex ("Particle Texture", 2D) = "white" {}
 _InvFade ("Soft Particles Factor", Range(0.01,3)) = 1
 _DiffusePara ("Diffuse Para", Float) = 1
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZWrite Off
  Cull Off
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha Zero
  AlphaTest Greater 0.99
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 5 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
MOV result.color, vertex.color;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[5], c[5].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 6 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
mov oD0, v1
mad oT0.xy, v2, c4, c4.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddoellgnlfilkjcnhpflcklipjanghigmabaaaaaahaacaaaaadaaaaaa
cmaaaaaajmaaaaaabaabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
gmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaagcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefcfiabaaaaeaaaabaafgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaa
dcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaa
ogikcaaaaaaaaaaaacaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedaohmkcmlcibmkipbenhacfnehadnaapgabaaaaaaheadaaaaaeaaaaaa
daaaaaaadaabaaaajaacaaaaaaadaaaaebgpgodjpiaaaaaapiaaaaaaaaacpopp
liaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaacaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
aeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaafaaaaadaaaaapiaaaaaffja
adaaoekaaeaaaaaeaaaaapiaacaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
aeaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
abaaaaacaaaaapoaabaaoejappppaaaafdeieefcfiabaaaaeaaaabaafgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaa
dcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaa
ogikcaaaaaaaaaaaacaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaa
faaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaa
epfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
gcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfagphdgjhe
gjgpgoaaedepemepfcaafeeffiedepepfceeaakl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 9 [_ProjectionParams]
Vector 10 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[11] = { { 0.5 },
		state.matrix.modelview[0],
		state.matrix.mvp,
		program.local[9..10] };
TEMP R0;
TEMP R1;
DP4 R1.w, vertex.position, c[8];
DP4 R0.x, vertex.position, c[5];
MOV R0.w, R1;
DP4 R0.y, vertex.position, c[6];
MUL R1.xyz, R0.xyww, c[0].x;
MUL R1.y, R1, c[9].x;
DP4 R0.z, vertex.position, c[7];
MOV result.position, R0;
DP4 R0.x, vertex.position, c[3];
ADD result.texcoord[1].xy, R1, R1.z;
MOV result.color, vertex.color;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MOV result.texcoord[1].z, -R0.x;
MOV result.texcoord[1].w, R1;
END
# 14 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_mvp]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [_MainTex_ST]
"vs_2_0
def c11, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
dp4 r1.w, v0, c7
dp4 r0.x, v0, c4
mov r0.w, r1
dp4 r0.y, v0, c5
mul r1.xyz, r0.xyww, c11.x
mul r1.y, r1, c8.x
dp4 r0.z, v0, c6
mov oPos, r0
dp4 r0.x, v0, c2
mad oT1.xy, r1.z, c9.zwzw, r1
mov oD0, v1
mad oT0.xy, v2, c10, c10.zwzw
mov oT1.z, -r0.x
mov oT1.w, r1
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecednmpbjacibpimicngiphdfdihadeeendaabaaaaaaoaadaaaaadaaaaaa
cmaaaaaajmaaaaaaciabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
ieaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaahkaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaahkaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeef
fiedepepfceeaaklfdeieefclaacaaaaeaaaabaakmaaaaaafjaaaaaeegiocaaa
aaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaiaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaa
fpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
giaaaaacacaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
acaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
acaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaa
egbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaa
aaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
iccabaaaadaaaaaadkaabaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaa
ckiacaaaacaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaa
aeaaaaaaakbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
ckiacaaaacaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaacaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaa
aaaaaaaadgaaaaageccabaaaadaaaaaaakaabaiaebaaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedebcippahhcnnkilpdplfokklbbpcocajabaaaaaakmafaaaaaeaaaaaa
daaaaaaapiabaaaalaaeaaaacaafaaaaebgpgodjmaabaaaamaabaaaaaaacpopp
heabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaacaa
abaaabaaaaaaaaaaabaaafaaabaaacaaaaaaaaaaacaaaaaaaiaaadaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafalaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaacia
acaaapjaafaaaaadaaaaapiaaaaaffjaaeaaoekaaeaaaaaeaaaaapiaadaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaafaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaagaaoekaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaacaaaaka
afaaaaadabaaaiiaabaaaaiaalaaaakaafaaaaadabaaafiaaaaapeiaalaaaaka
acaaaaadacaaadoaabaakkiaabaaomiaafaaaaadabaaabiaaaaaffjaaiaakkka
aeaaaaaeabaaabiaahaakkkaaaaaaajaabaaaaiaaeaaaaaeabaaabiaajaakkka
aaaakkjaabaaaaiaaeaaaaaeabaaabiaakaakkkaaaaappjaabaaaaiaabaaaaac
acaaaeoaabaaaaibaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
acaaaioaaaaappiaabaaaaacaaaaapoaabaaoejappppaaaafdeieefclaacaaaa
eaaaabaakmaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaa
abaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaaaiaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaacaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaacaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaacaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaa
acaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaaficcabaaaadaaaaaadkaabaaaaaaaaaaa
aaaaaaahdccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
bcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaaakaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaackbabaaa
aaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaa
ahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaaadaaaaaa
akaabaiaebaaaaaaaaaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaa
faaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaa
epfdeheoieaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
hkaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaahkaaaaaaabaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaaedepemep
fcaafeeffiedepepfceeaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Float 1 [_DiffusePara]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R1, fragment.color.primary, c[1].x;
MUL R1, R1, c[0];
MUL R0, R1, R0;
MUL result.color, R0, c[2].x;
END
# 5 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Float 1 [_DiffusePara]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c2, 2.00000000, 0, 0, 0
dcl v0
dcl t0.xy
texld r0, t0, s0
mul r1, v0, c1.x
mul r1, r1, c0
mul r0, r1, r0
mul r0, r0, c2.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
Float 48 [_DiffusePara]
BindCB  "$Globals" 0
"ps_4_0
eefiecedkmnefdgclcjcpelgjkpkppaianbkooheabaaaaaaoaabaaaaadaaaaaa
cmaaaaaakaaaaaaaneaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcaeabaaaaeaaaaaaa
ebaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaaaaaaaj
bcaabaaaaaaaaaaaakiacaaaaaaaaaaaadaaaaaaakiacaaaaaaaaaaaadaaaaaa
diaaaaahpcaabaaaaaaaaaaaagaabaaaaaaaaaaaegbobaaaabaaaaaadiaaaaai
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
diaaaaahpccabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
Float 48 [_DiffusePara]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedaedcabembnedchnnjpamhgdocdpljeiaabaaaaaaleacaaaaaeaaaaaa
daaaaaaaaaabaaaaamacaaaaiaacaaaaebgpgodjmiaaaaaamiaaaaaaaaacpppp
iiaaaaaaeaaaaaaaacaaciaaaaaaeaaaaaaaeaaaabaaceaaaaaaeaaaaaaaaaaa
aaaaabaaabaaaaaaaaaaaaaaaaaaadaaabaaabaaaaaaaaaaaaacppppbpaaaaac
aaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaaadlabpaaaaacaaaaaajaaaaiapka
ecaaaaadaaaaapiaabaaoelaaaaioekaacaaaaadabaaaiiaabaaaakaabaaaaka
afaaaaadabaaapiaabaappiaaaaaoelaafaaaaadabaaapiaabaaoeiaaaaaoeka
afaaaaadaaaacpiaaaaaoeiaabaaoeiaabaaaaacaaaicpiaaaaaoeiappppaaaa
fdeieefcaeabaaaaeaaaaaaaebaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
pcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaaaaaaaaajbcaabaaaaaaaaaaaakiacaaaaaaaaaaaadaaaaaa
akiacaaaaaaaaaaaadaaaaaadiaaaaahpcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egbobaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaaa
aaaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahpccabaaaaaaaaaaaegaobaaaaaaaaaaa
egaobaaaabaaaaaadoaaaaabejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_ZBufferParams]
Vector 1 [_TintColor]
Float 2 [_DiffusePara]
Float 3 [_InvFade]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 2 } };
TEMP R0;
TEMP R1;
TXP R1.x, fragment.texcoord[1], texture[0], 2D;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MAD R1.x, R1, c[0].z, c[0].w;
RCP R1.x, R1.x;
ADD R1.x, R1, -fragment.texcoord[1].z;
MUL_SAT R1.w, R1.x, c[3].x;
MOV R1.xyz, fragment.color.primary;
MUL R1.w, fragment.color.primary, R1;
MUL R1, R1, c[2].x;
MUL R1, R1, c[1];
MUL R0, R1, R0;
MUL result.color, R0, c[4].x;
END
# 12 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_ZBufferParams]
Vector 1 [_TintColor]
Float 2 [_DiffusePara]
Float 3 [_InvFade]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c4, 2.00000000, 0, 0, 0
dcl v0
dcl t0.xy
dcl t1
texldp r0, t1, s0
texld r1, t0, s1
mad r0.x, r0, c0.z, c0.w
rcp r0.x, r0.x
add r0.x, r0, -t1.z
mul_sat r0.x, r0, c3
mov_pp r2.xyz, v0
mul_pp r2.w, v0, r0.x
mul r0, r2, c2.x
mul r0, r0, c1
mul r0, r0, r1
mul r0, r0, c4.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
Float 48 [_DiffusePara]
Float 52 [_InvFade]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedbnolgbgcldmbfjcimgflgbldjiklahopabaaaaaadeadaaaaadaaaaaa
cmaaaaaaliaaaaaaomaaaaaaejfdeheoieaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaafdfgfpfa
gphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaaklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklklfdeieefceaacaaaaeaaaaaaajaaaaaaafjaaaaae
egiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaadaaaaaa
pgbpbaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaackiacaaaabaaaaaa
ahaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaa
aaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaa
aaaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaackbabaiaebaaaaaaadaaaaaa
dicaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaaaaaaaaaaadaaaaaa
diaaaaahicaabaaaaaaaaaaaakaabaaaaaaaaaaadkbabaaaabaaaaaaaaaaaaaj
bcaabaaaabaaaaaaakiacaaaaaaaaaaaadaaaaaaakiacaaaaaaaaaaaadaaaaaa
dgaaaaafhcaabaaaaaaaaaaaegbcbaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaagaabaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaaegaobaaa
aaaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
acaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahpccabaaaaaaaaaaa
egaobaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
Float 48 [_DiffusePara]
Float 52 [_InvFade]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedpljobacdgondmkiibgdaipjamecheaghabaaaaaaliaeaaaaaeaaaaaa
daaaaaaalaabaaaapiadaaaaieaeaaaaebgpgodjhiabaaaahiabaaaaaaacpppp
ciabaaaafaaaaaaaadaacmaaaaaafaaaaaaafaaaacaaceaaaaaafaaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaaaadaaabaaabaaaaaaaaaaabaaahaa
abaaacaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaia
abaaadlabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaac
aaaaaajaabaiapkaagaaaaacaaaaaiiaacaapplaafaaaaadaaaaadiaaaaappia
acaaoelaecaaaaadaaaaapiaaaaaoeiaabaioekaecaaaaadabaaapiaabaaoela
aaaioekaaeaaaaaeaaaaabiaacaakkkaaaaaaaiaacaappkaagaaaaacaaaaabia
aaaaaaiaacaaaaadaaaaabiaaaaaaaiaacaakklbafaaaaadaaaabbiaaaaaaaia
abaaffkaafaaaaadaaaaciiaaaaaaaiaaaaapplaacaaaaadacaaaiiaabaaaaka
abaaaakaabaaaaacaaaaahiaaaaaoelaafaaaaadaaaaapiaaaaaoeiaacaappia
afaaaaadaaaaapiaaaaaoeiaaaaaoekaafaaaaadaaaacpiaabaaoeiaaaaaoeia
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefceaacaaaaeaaaaaaajaaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaa
adaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaackiacaaa
abaaaaaaahaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaahaaaaaaaoaaaaak
bcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaa
aaaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaackbabaiaebaaaaaa
adaaaaaadicaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaaaaaaaaaa
adaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaaaaaaaaadkbabaaaabaaaaaa
aaaaaaajbcaabaaaabaaaaaaakiacaaaaaaaaaaaadaaaaaaakiacaaaaaaaaaaa
adaaaaaadgaaaaafhcaabaaaaaaaaaaaegbcbaaaabaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahpccabaaa
aaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadoaaaaabejfdeheoieaaaaaa
aeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
heaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaahkaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadadaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapapaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepep
fceeaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
}