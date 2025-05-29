µ<Shader "Hidden/CustomMotionBlur" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _AccumOrig ("AccumOrig", Float) = 0.65
 _BlurRadius ("Blur Radius", Float) = 1
 _MaskTex ("Mask Tex", 2D) = "black" {}
}
SubShader { 
 Pass {
  BindChannels {
   Bind "vertex", Vertex
   Bind "texcoord", TexCoord
  }
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Vector 5 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
MAD result.texcoord[0].xy, vertex.texcoord[0], c[5], c[5].zwzw;
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
Vector 4 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.xy, v1, c4, c4.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 48
Vector 16 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedlpbfflgifpimcimkknjklcdkpkfjfcpkabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaabaaaaaaogikcaaa
aaaaaaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 48
Vector 16 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedkagjjfdjijkdpbdeojbliomgiaghinmjabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaabaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaabaaaaaaogikcaaa
aaaaaaaaabaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_AccumOrig]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 1 } };
TEMP R0;
TEX R0.x, fragment.texcoord[0], texture[0], 2D;
TEX result.color.xyz, fragment.texcoord[0], texture[1], 2D;
MOV R0.y, c[1].x;
ADD R0.y, R0, -c[0].x;
MAD result.color.w, R0.x, R0.y, c[0].x;
END
# 5 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_AccumOrig]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 1.00000000, 0, 0, 0
dcl t0.xy
texld r1, t0, s0
texld r0, t0, s1
mov r2.x, c0
add r2.x, c1, -r2
mad r0.w, r1.x, r2.x, c0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MaskTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 48
Float 32 [_AccumOrig]
BindCB  "$Globals" 0
"ps_4_0
eefiecedonkklppcphmdhjndhjopoiebmjkboochabaaaaaanmabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbmabaaaa
eaaaaaaaehaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaajccaabaaaaaaaaaaa
akiacaiaebaaaaaaaaaaaaaaacaaaaaaabeaaaaaaaaaiadpdcaaaaakiccabaaa
aaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaaaaaaaaaacaaaaaa
efaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadgaaaaafhccabaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MaskTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 48
Float 32 [_AccumOrig]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedkoikllcnomeefmcnnhmidajmledmldpfabaaaaaamaacaaaaaeaaaaaa
daaaaaaabaabaaaadeacaaaaimacaaaaebgpgodjniaaaaaaniaaaaaaaaacpppp
kaaaaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaabaaaaaa
aaababaaaaaaacaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkaecaaaaadaaaaapiaaaaaoelaabaioeka
ecaaaaadabaacpiaaaaaoelaaaaioekaabaaaaacacaaaiiaaaaaaakaacaaaaad
aaaaaciaacaappibabaaaakaaeaaaaaeabaaciiaaaaaaaiaaaaaffiaaaaaaaka
abaaaaacaaaicpiaabaaoeiappppaaaafdeieefcbmabaaaaeaaaaaaaehaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacabaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaaaaaaaaajccaabaaaaaaaaaaaakiacaiaebaaaaaa
aaaaaaaaacaaaaaaabeaaaaaaaaaiadpdcaaaaakiccabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaaaaaaaaaacaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadgaaaaaf
hccabaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheofaaaaaaaacaaaaaa
aiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
"
}
}
 }
}
Fallback Off
}