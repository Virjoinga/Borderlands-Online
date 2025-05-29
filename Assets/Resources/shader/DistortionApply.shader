Ç:Shader "TKC/Distortion/Apply" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _OffsetTex ("OffsetTex", 2D) = "white" {}
}
SubShader { 
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend One Zero, Zero One
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
"!!ARBvp1.0
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
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mov oT0.xy, v1
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
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
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0_level_9_1
eefiecedmldjmmohbhmjmnnblgkeoagbliecmmbkabaaaaaalmacaaaaaeaaaaaa
daaaaaaaaeabaaaabaacaaaageacaaaaebgpgodjmmaaaaaammaaaaaaaaacpopp
jiaaaaaadeaaaaaaabaaceaaaaaadaaaaaaadaaaaaaaceaaabaadaaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaac
afaaabiaabaaapjaafaaaaadaaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapia
abaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaaeaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacaaaaadoaabaaoeja
ppppaaaafdeieefcaeabaaaaeaaaabaaebaaaaaafjaaaaaeegiocaaaaaaaaaaa
aeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaacabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaa
aaaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaa
abaaaaaaegbabaaaabaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfc
eeaaklklepfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
SetTexture 0 [_OffsetTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0, 1, 0.1, -0.1 } };
TEMP R0;
TEX R0.x, fragment.texcoord[0], texture[0], 2D;
MUL R0.xy, R0.x, c[0].zwzw;
ADD R0.zw, R0.xyxy, fragment.texcoord[0].xyxy;
ABS R0.y, R0;
ABS R0.x, R0;
CMP R0.y, -R0, c[0], c[0].x;
CMP R0.x, -R0, c[0].y, c[0];
MUL R0.x, R0, R0.y;
CMP R0.xy, -R0.x, R0.zwzw, fragment.texcoord[0];
TEX result.color, R0, texture[1], 2D;
END
# 10 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
SetTexture 0 [_OffsetTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c0, 0.10000000, -0.10000000, 0.00000000, 1.00000000
dcl t0.xy
texld r0, t0, s0
mul r0.xy, r0.x, c0
add r2.xy, r0, t0
abs r1.x, r0.y
abs r0.x, r0
cmp r1.x, -r1, c0.z, c0.w
cmp r0.x, -r0, c0.z, c0.w
mul_pp r0.x, r0, r1
cmp r0.xy, -r0.x, t0, r2
texld r0, r0, s1
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_OffsetTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
"ps_4_0
eefiecedjcpkpcdjklhdbmdnjaafnfhpaafjoejmabaaaaaaaeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefceeabaaaa
eaaaaaaafbaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaa
efaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaadjaaaaakgcaabaaaaaaaaaaaagaabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaiaaaaaaaaadcaaaaamjcaabaaaaaaaaaaaagaabaaaaaaaaaaa
aceaaaaamnmmmmdnaaaaaaaaaaaaaaaamnmmmmlnagbebaaaabaaaaaaabaaaaah
ccaabaaaaaaaaaaackaabaaaaaaaaaaabkaabaaaaaaaaaaadhaaaaajdcaabaaa
aaaaaaaafgafbaaaaaaaaaaamgaabaaaaaaaaaaaegbabaaaabaaaaaaefaaaaaj
pccabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_OffsetTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
"ps_4_0_level_9_1
eefiecedlhoaidakkmhchafeopohpndgoclgaabgabaaaaaacmadaaaaaeaaaaaa
daaaaaaafeabaaaakaacaaaapiacaaaaebgpgodjbmabaaaabmabaaaaaaacpppp
paaaaaaacmaaaaaaaaaacmaaaaaacmaaaaaacmaaacaaceaaaaaacmaaabaaaaaa
aaababaaaaacppppfbaaaaafaaaaapkamnmmmmdnmnmmmmlnaaaaaaiaaaaaialp
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaaja
abaiapkaecaaaaadaaaaapiaaaaaoelaabaioekaafaaaaadaaaaagiaaaaaaaia
aaaanckaaeaaaaaeabaaadiaaaaaaaiaaaaaoekaaaaaoelaafaaaaadaaaaabia
aaaakkiaaaaakkiaafaaaaadaaaaaciaaaaaffiaaaaaffiafiaaaaaeaaaaabia
aaaaaaibaaaakkkaaaaappkafiaaaaaeaaaaabiaaaaaffibaaaakkkbaaaaaaia
fiaaaaaeaaaaadiaaaaaaaiaaaaaoelaabaaoeiaecaaaaadaaaaapiaaaaaoeia
aaaioekaabaaaaacaaaiapiaaaaaoeiappppaaaafdeieefceeabaaaaeaaaaaaa
fbaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
djaaaaakgcaabaaaaaaaaaaaagaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaiaaaaaaaaadcaaaaamjcaabaaaaaaaaaaaagaabaaaaaaaaaaaaceaaaaa
mnmmmmdnaaaaaaaaaaaaaaaamnmmmmlnagbebaaaabaaaaaaabaaaaahccaabaaa
aaaaaaaackaabaaaaaaaaaaabkaabaaaaaaaaaaadhaaaaajdcaabaaaaaaaaaaa
fgafbaaaaaaaaaaamgaabaaaaaaaaaaaegbabaaaabaaaaaaefaaaaajpccabaaa
aaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadoaaaaab
ejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback Off
}