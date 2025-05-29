ª|Shader "BOL/FX/ParticleAdditiveZTestAlways" {
Properties {
 _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
 _MainTex ("Particle Texture", 2D) = "white" {}
 _InvFade ("Soft Particles Factor", Range(0.01,3)) = 1
}
SubShader { 
 Tags { "QUEUE"="Transparent+1" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent+1" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZTest Always
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
Keywords { "SOFTPARTICLES_ON" }
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
Keywords { "SOFTPARTICLES_ON" }
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
Keywords { "SOFTPARTICLES_ON" }
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
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R1, fragment.color.primary, c[0];
MUL R0, R1, R0;
MUL result.color, R0, c[1].x;
END
# 4 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 2.00000000, 0, 0, 0
dcl v0
dcl t0.xy
texld r0, t0, s0
mul r1, v0, c0
mul r0, r1, r0
mul r0, r0, c1.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmggfklilcgogoppahahdoojbcfakmpbiabaaaaaalmabaaaaadaaaaaa
cmaaaaaakaaaaaaaneaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaaaaaaaeaaaaaaa
diaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaaaaaaah
pcaabaaaaaaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaadiaaaaaipcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
pccabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedcnmimopbllpjfifjekfaphchkhconnkoabaaaaaaheacaaaaaeaaaaaa
daaaaaaaoeaaaaaammabaaaaeaacaaaaebgpgodjkmaaaaaakmaaaaaaaaacpppp
hiaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaabaaabaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaaapiaabaaoela
aaaioekaafaaaaadabaaapiaaaaaoelaaaaaoekaacaaaaadabaaapiaabaaoeia
abaaoeiaafaaaaadaaaacpiaaaaaoeiaabaaoeiaabaaaaacaaaicpiaaaaaoeia
ppppaaaafdeieefcoaaaaaaaeaaaaaaadiaaaaaafjaaaaaeegiocaaaaaaaaaaa
acaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaaaaaaaahpcaabaaaaaaaaaaaegbobaaaabaaaaaa
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
Vector 0 [_TintColor]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
PARAM c[2] = { program.local[0],
		{ 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R1, fragment.color.primary, c[0];
MUL R0, R1, R0;
MUL result.color, R0, c[1].x;
END
# 4 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_TintColor]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 2.00000000, 0, 0, 0
dcl v0
dcl t0.xy
texld r0, t0, s0
mul r1, v0, c0
mul r0, r1, r0
mul r0, r0, c1.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmggfklilcgogoppahahdoojbcfakmpbiabaaaaaalmabaaaaadaaaaaa
cmaaaaaakaaaaaaaneaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaaaaaaaeaaaaaaa
diaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaaaaaaah
pcaabaaaaaaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaadiaaaaaipcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
pccabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedcnmimopbllpjfifjekfaphchkhconnkoabaaaaaaheacaaaaaeaaaaaa
daaaaaaaoeaaaaaammabaaaaeaacaaaaebgpgodjkmaaaaaakmaaaaaaaaacpppp
hiaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaabaaabaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaaapiaabaaoela
aaaioekaafaaaaadabaaapiaaaaaoelaaaaaoekaacaaaaadabaaapiaabaaoeia
abaaoeiaafaaaaadaaaacpiaaaaaoeiaabaaoeiaabaaaaacaaaicpiaaaaaoeia
ppppaaaafdeieefcoaaaaaaaeaaaaaaadiaaaaaafjaaaaaeegiocaaaaaaaaaaa
acaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaaaaaaaahpcaabaaaaaaaaaaaegbobaaaabaaaaaa
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
}
 }
}
}