Ú?Shader "BOL/Scene/IlluminDiffuse" {
Properties {
 _MainTex ("Base", 2D) = "white" {}
 _MaskTex ("Mask (RGB)", 2D) = "white" {}
 _IllumnColor ("Emissive Color (Mask R)", Color) = (0.5,0.5,0.5,1)
 _SelfIllumination ("Self Illumination", Range(0,2)) = 1
}
SubShader { 
 Pass {
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
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedfkhdfmapkojemjflkpilebekfgbncghhabaaaaaacmacaaaaadaaaaaa
cmaaaaaakaaaaaaapiaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaacaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaabaaaaaaogikcaaa
aaaaaaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedaiieahaefpmogdpdlkkidanekkgkfkeoabaaaaaabiadaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaamaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaabaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaaeaaaaaeaaaaadoaacaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaacaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaabaaaaaaogikcaaa
aaaaaaaaabaaaaaadoaaaaabejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_SelfIllumination]
Vector 1 [_IllumnColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
"!!ARBfp1.0
PARAM c[3] = { program.local[0..1],
		{ 16 } };
TEMP R0;
TEMP R1;
TEX R1.x, fragment.texcoord[0], texture[1], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, c[0].x;
MUL R1.x, R1, c[1].w;
MUL R1.xyz, R1.x, c[1];
MAD result.color.xyz, R1, c[2].x, R0;
MOV result.color.w, R0;
END
# 7 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_SelfIllumination]
Vector 1 [_IllumnColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c2, 16.00000000, 0, 0, 0
dcl t0.xy
texld r1, t0, s1
texld r0, t0, s0
mul r1.x, r1, c1.w
mul_pp r0, r0, c0.x
mul r1.xyz, r1.x, c1
mad r0.xyz, r1, c2.x, r0
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
ConstBuffer "$Globals" 64
Float 32 [_SelfIllumination]
Vector 48 [_IllumnColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedogjafeimjemmdgnaccclkgfhaknlnaebabaaaaaabeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfeabaaaa
eaaaaaaaffaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaiccaabaaaaaaaaaaa
dkiacaaaaaaaaaaaadaaaaaaabeaaaaaaaaaiaebdiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaaabaaaaaa
egaobaaaabaaaaaaagiacaaaaaaaaaaaacaaaaaadcaaaaakhccabaaaaaaaaaaa
egiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
ConstBuffer "$Globals" 64
Float 32 [_SelfIllumination]
Vector 48 [_IllumnColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedenjccjefbppkghkjfkhlldenomnafiddabaaaaaaamadaaaaaeaaaaaa
daaaaaaaceabaaaaiaacaaaaniacaaaaebgpgodjomaaaaaaomaaaaaaaaacpppp
leaaaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaaaaaaaaa
abababaaaaaaacaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaiaeb
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaacdlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkaecaaaaadaaaaapiaaaaaoelaabaioeka
ecaaaaadabaacpiaaaaaoelaaaaioekaafaaaaadaaaaabiaaaaaaaiaabaappka
afaaaaadaaaaabiaaaaaaaiaacaaaakaafaaaaadabaaapiaabaaoeiaaaaaaaka
aeaaaaaeabaachiaabaaoekaaaaaaaiaabaaoeiaabaaaaacaaaicpiaabaaoeia
ppppaaaafdeieefcfeabaaaaeaaaaaaaffaaaaaafjaaaaaeegiocaaaaaaaaaaa
aeaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaaiccaabaaaaaaaaaaadkiacaaaaaaaaaaaadaaaaaaabeaaaaaaaaaiaeb
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
diaaaaaipcaabaaaabaaaaaaegaobaaaabaaaaaaagiacaaaaaaaaaaaacaaaaaa
dcaaaaakhccabaaaaaaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaa
egacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab
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