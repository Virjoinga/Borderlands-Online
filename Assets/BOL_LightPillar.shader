ç‰Shader "BOL/Scene/LightPillar" {
Properties {
 _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
 _EmissiveColor ("Emissive Color", Color) = (0.5,0.5,0.5,0.5)
 _MainTex ("Main Texture", 2D) = "white" {}
 _EmissivePara ("Emissive Para", Float) = 1
}
SubShader { 
 LOD 1000
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Cull Off
  Blend SrcAlpha One
  AlphaTest Greater 0.01
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
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
Keywords { "SOFTPARTICLES_OFF" }
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
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 64 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedgakmemppdbmnoenoeikijcehiopgebopabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 64 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedlkamokpcpondimakhhdpieopkkgldhdcabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaeaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
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
Keywords { "SOFTPARTICLES_ON" }
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
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 64 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedgakmemppdbmnoenoeikijcehiopgebopabaaaaaaamacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 112
Vector 64 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedlkamokpcpondimakhhdpieopkkgldhdcabaaaaaapiacaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaakaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaeaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjaaeaaaaaeaaaaadoaabaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaadoaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Vector 1 [_EmissiveColor]
Float 2 [_EmissivePara]
Float 3 [_EmissiveOffset]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 2, 0 } };
TEMP R0;
TEMP R1;
MOV R1.x, c[2];
MOV R0.y, c[3].x;
MOV R0.x, c[4].y;
ADD R0.xy, fragment.texcoord[0], R0;
MUL R1.xyz, R1.x, c[0];
TEX R0.y, R0, texture[0], 2D;
TEX R0.x, fragment.texcoord[0], texture[0], 2D;
MUL R0.y, R0, c[1].w;
MUL R0.y, R0, c[4].x;
MUL R0.yzw, R0.y, c[1].xxyz;
MAD result.color.xyz, R1, c[4].x, R0.yzww;
MUL result.color.w, R0.x, c[0];
END
# 12 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
Vector 1 [_EmissiveColor]
Float 2 [_EmissivePara]
Float 3 [_EmissiveOffset]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c4, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
texld r2, t0, s0
mov r1.xyz, c0
mov_pp r0.y, c3.x
mov_pp r0.x, c4
add r0.xy, t0, r0
mul r1.xyz, c2.x, r1
texld r0, r0, s0
mul r0.x, r0.y, c1.w
mul r0.x, r0, c4.y
mul_pp r0.xyz, r0.x, c1
mad r0.xyz, r1, c4.y, r0
mul_pp r0.w, r2.x, c0
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 112
Vector 16 [_TintColor]
Vector 32 [_EmissiveColor]
Float 48 [_EmissivePara]
Float 52 [_EmissiveOffset]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjflpilpdlkdmgmnkbiojoejbodbkhodkabaaaaaaeaacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefciaabaaaa
eaaaaaaagaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadgaaaaafbcaabaaaaaaaaaaa
akbabaaaabaaaaaaaaaaaaaiccaabaaaaaaaaaaabkbabaaaabaaaaaabkiacaaa
aaaaaaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaapaaaaaibcaabaaaaaaaaaaafgafbaaaaaaaaaaa
pgipcaaaaaaaaaaaacaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaacaaaaaaaaaaaaajhcaabaaaabaaaaaaegiccaaaaaaaaaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
abaaaaaaagiacaaaaaaaaaaaadaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 112
Vector 16 [_TintColor]
Vector 32 [_EmissiveColor]
Float 48 [_EmissivePara]
Float 52 [_EmissiveOffset]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedmifekpjkmdhdfdabconbdjkdccjmjgmeabaaaaaaemadaaaaaeaaaaaa
daaaaaaadiabaaaamaacaaaabiadaaaaebgpgodjaaabaaaaaaabaaaaaaacpppp
mmaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaabaaadaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaajaaaaiapkaabaaaaacaaaaabiaaaaaaalaacaaaaadaaaaaciaaaaaffla
acaaffkaecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadabaacpiaaaaaoela
aaaioekaafaaaaadaaaaabiaaaaaffiaabaappkaacaaaaadaaaacbiaaaaaaaia
aaaaaaiaafaaaaadaaaachiaaaaaaaiaabaaoekaacaaaaadabaacoiaaaaablka
aaaablkaaeaaaaaeaaaachiaabaabliaacaaaakaaaaaoeiaafaaaaadaaaaciia
abaaaaiaaaaappkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefciaabaaaa
eaaaaaaagaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadgaaaaafbcaabaaaaaaaaaaa
akbabaaaabaaaaaaaaaaaaaiccaabaaaaaaaaaaabkbabaaaabaaaaaabkiacaaa
aaaaaaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaapaaaaaibcaabaaaaaaaaaaafgafbaaaaaaaaaaa
pgipcaaaaaaaaaaaacaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaacaaaaaaaaaaaaajhcaabaaaabaaaaaaegiccaaaaaaaaaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
abaaaaaaagiacaaaaaaaaaaaadaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaadoaaaaab
ejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapadaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_TintColor]
Vector 1 [_EmissiveColor]
Float 2 [_EmissivePara]
Float 3 [_EmissiveOffset]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 2, 0 } };
TEMP R0;
TEMP R1;
MOV R1.x, c[2];
MOV R0.y, c[3].x;
MOV R0.x, c[4].y;
ADD R0.xy, fragment.texcoord[0], R0;
MUL R1.xyz, R1.x, c[0];
TEX R0.y, R0, texture[0], 2D;
TEX R0.x, fragment.texcoord[0], texture[0], 2D;
MUL R0.y, R0, c[1].w;
MUL R0.y, R0, c[4].x;
MUL R0.yzw, R0.y, c[1].xxyz;
MAD result.color.xyz, R1, c[4].x, R0.yzww;
MUL result.color.w, R0.x, c[0];
END
# 12 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_TintColor]
Vector 1 [_EmissiveColor]
Float 2 [_EmissivePara]
Float 3 [_EmissiveOffset]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c4, 0.00000000, 2.00000000, 0, 0
dcl t0.xy
texld r2, t0, s0
mov r1.xyz, c0
mov_pp r0.y, c3.x
mov_pp r0.x, c4
add r0.xy, t0, r0
mul r1.xyz, c2.x, r1
texld r0, r0, s0
mul r0.x, r0.y, c1.w
mul r0.x, r0, c4.y
mul_pp r0.xyz, r0.x, c1
mad r0.xyz, r1, c4.y, r0
mul_pp r0.w, r2.x, c0
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 112
Vector 16 [_TintColor]
Vector 32 [_EmissiveColor]
Float 48 [_EmissivePara]
Float 52 [_EmissiveOffset]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjflpilpdlkdmgmnkbiojoejbodbkhodkabaaaaaaeaacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefciaabaaaa
eaaaaaaagaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadgaaaaafbcaabaaaaaaaaaaa
akbabaaaabaaaaaaaaaaaaaiccaabaaaaaaaaaaabkbabaaaabaaaaaabkiacaaa
aaaaaaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaapaaaaaibcaabaaaaaaaaaaafgafbaaaaaaaaaaa
pgipcaaaaaaaaaaaacaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaacaaaaaaaaaaaaajhcaabaaaabaaaaaaegiccaaaaaaaaaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
abaaaaaaagiacaaaaaaaaaaaadaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 112
Vector 16 [_TintColor]
Vector 32 [_EmissiveColor]
Float 48 [_EmissivePara]
Float 52 [_EmissiveOffset]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedmifekpjkmdhdfdabconbdjkdccjmjgmeabaaaaaaemadaaaaaeaaaaaa
daaaaaaadiabaaaamaacaaaabiadaaaaebgpgodjaaabaaaaaaabaaaaaaacpppp
mmaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaabaaadaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaajaaaaiapkaabaaaaacaaaaabiaaaaaaalaacaaaaadaaaaaciaaaaaffla
acaaffkaecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadabaacpiaaaaaoela
aaaioekaafaaaaadaaaaabiaaaaaffiaabaappkaacaaaaadaaaacbiaaaaaaaia
aaaaaaiaafaaaaadaaaachiaaaaaaaiaabaaoekaacaaaaadabaacoiaaaaablka
aaaablkaaeaaaaaeaaaachiaabaabliaacaaaakaaaaaoeiaafaaaaadaaaaciia
abaaaaiaaaaappkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefciaabaaaa
eaaaaaaagaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaadgaaaaafbcaabaaaaaaaaaaa
akbabaaaabaaaaaaaaaaaaaiccaabaaaaaaaaaaabkbabaaaabaaaaaabkiacaaa
aaaaaaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaapaaaaaibcaabaaaaaaaaaaafgafbaaaaaaaaaaa
pgipcaaaaaaaaaaaacaaaaaadiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaa
egiccaaaaaaaaaaaacaaaaaaaaaaaaajhcaabaaaabaaaaaaegiccaaaaaaaaaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaakhccabaaaaaaaaaaaegacbaaa
abaaaaaaagiacaaaaaaaaaaaadaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
iccabaaaaaaaaaaaakaabaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaadoaaaaab
ejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapadaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback "VertexLit"
}