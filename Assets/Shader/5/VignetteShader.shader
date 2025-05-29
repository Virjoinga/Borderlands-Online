í7Shader "Hidden/VignetteShader" {
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
Float 0 [vignetteIntensity]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 1, 0.5, 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
ADD R1.xy, fragment.texcoord[0], -c[1].y;
MUL R1.xy, R1, c[1].z;
MUL R1.xy, R1, R1;
ADD R1.x, R1, R1.y;
MUL R1.x, -R1, c[0];
ADD R1.x, R1, c[1];
MUL result.color, R0, R1.x;
END
# 8 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [vignetteIntensity]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, -0.50000000, 2.00000000, 1.00000000, 0
dcl t0.xy
texld r1, t0, s0
add_pp r0.xy, t0, c1.x
mul_pp r0.xy, r0, c1.y
mul_pp r0.xy, r0, r0
add_pp r0.x, r0, r0.y
mul r0.x, -r0, c0
add r0.x, r0, c1.z
mul r0, r1, r0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 48
Float 32 [vignetteIntensity]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmgamncmaoeeohfbnioaejhgfhdikpclbabaaaaaaoeabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcceabaaaa
eaaaaaaaejaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaaaaaaakdcaabaaaaaaaaaaa
egbabaaaabaaaaaaaceaaaaaaaaaaalpaaaaaalpaaaaaaaaaaaaaaaaaaaaaaah
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaaapaaaaahbcaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaadcaaaaalbcaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaaakiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaiadp
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahpccabaaaaaaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 48
Float 32 [vignetteIntensity]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedlfkfnphbcgfcjljkdoneekjmmpompeonabaaaaaanmacaaaaaeaaaaaa
daaaaaaaceabaaaafaacaaaakiacaaaaebgpgodjomaaaaaaomaaaaaaaaacpppp
liaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaacaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaaalpaaaaaaaa
aaaaiadpaaaaaaaabpaaaaacaaaaaaiaaaaacdlabpaaaaacaaaaaajaaaaiapka
ecaaaaadaaaacpiaaaaaoelaaaaioekaacaaaaadabaacdiaaaaaoelaabaaaaka
acaaaaadabaacdiaabaaoeiaabaaoeiafkaaaaaeabaacbiaabaaoeiaabaaoeia
abaaffkaabaaaaacabaaaeiaabaakkkaaeaaaaaeabaaabiaabaaaaiaaaaaaakb
abaakkiaafaaaaadaaaacpiaaaaaoeiaabaaaaiaabaaaaacaaaicpiaaaaaoeia
ppppaaaafdeieefcceabaaaaeaaaaaaaejaaaaaafjaaaaaeegiocaaaaaaaaaaa
adaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaa
aaaaaaakdcaabaaaaaaaaaaaegbabaaaabaaaaaaaceaaaaaaaaaaalpaaaaaalp
aaaaaaaaaaaaaaaaaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaaegaabaaa
aaaaaaaaapaaaaahbcaabaaaaaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaa
dcaaaaalbcaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaaakiacaaaaaaaaaaa
acaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahpccabaaaaaaaaaaaagaabaaa
aaaaaaaaegaobaaaabaaaaaadoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaa
diaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback Off
}