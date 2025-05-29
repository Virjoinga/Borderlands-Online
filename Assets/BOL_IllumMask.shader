‹DShader "BOL/Scene/IllumMask" {
Properties {
 _Color ("Main Color", Color) = (0.5,0.5,0.5,1)
 _IllumColor ("Illum Color", Color) = (0.5,0.5,0.5,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _MaskTex ("Illumn (A)", 2D) = "white" {}
 _EmissionLM ("Emission (Lightmapper)", Float) = 1
 _DiffuseIntnsity ("Diffuse Intensity", Float) = 1
}
SubShader { 
 Tags { "RenderType"="Transparent" }
 Pass {
  Name "ILLUMMASK"
  Tags { "LIGHTMODE"="ForwardBase" "RenderType"="Transparent" }
  Blend SrcAlpha OneMinusSrcAlpha
  AlphaTest Greater 0.01
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
MAD result.texcoord[2].xy, vertex.texcoord[0], c[5], c[5].zwzw;
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
mad oT2.xy, v1, c4, c4.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 64 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedgjljmogfbnjhdhdafijmichlgeipldobabaaaaaacmacaaaaadaaaaaa
cmaaaaaakaaaaaaapiaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaacaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaacaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 64 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedaclpkolchbknicliigafdojcimfbcffkabaaaaaabiadaaaaaeaaaaaa
daaaaaaabiabaaaaemacaaaamaacaaaaebgpgodjoaaaaaaaoaaaaaaaaaacpopp
kaaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaeaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaaciaacaaapjaaeaaaaaeaaaaadoaacaaoeja
abaaoekaabaaookaafaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapia
acaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmabaaaa
eaaaabaaelaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaacaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaaeaaaaaaogikcaaa
aaaaaaaaaeaaaaaadoaaaaabejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahaaaaaagaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apadaaaafaepfdejfeejepeoaaeoepfcenebemaafeeffiedepepfceeaaklklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaacaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_EmissionLM]
Float 1 [_DiffuseIntnsity]
Vector 2 [_Color]
Vector 3 [_IllumColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
"!!ARBfp1.0
PARAM c[4] = { program.local[0..3] };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[2], texture[0], 2D;
TEX R1.w, fragment.texcoord[2], texture[1], 2D;
MUL R0, R0, c[2];
MUL R1.xyz, R0, c[3];
MUL R1.xyz, R1, R1.w;
MUL R1.xyz, R1, c[0].x;
MAD result.color.xyz, R0, c[1].x, R1;
MOV result.color.w, R0;
END
# 8 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_EmissionLM]
Float 1 [_DiffuseIntnsity]
Vector 2 [_Color]
Vector 3 [_IllumColor]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl t2.xy
texld r0, t2, s1
texld r1, t2, s0
mul r1, r1, c2
mul r0.xyz, r1, c3
mul r0.xyz, r0, r0.w
mul r0.xyz, r0, c0.x
mad r0.xyz, r1, c1.x, r0
mov r0.w, r1
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
ConstBuffer "$Globals" 80
Float 16 [_EmissionLM]
Float 20 [_DiffuseIntnsity]
Vector 32 [_Color]
Vector 48 [_IllumColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedefajdailipjhcdhpadkfagambbgombmfabaaaaaadeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaacaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcheabaaaa
eaaaaaaafnaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaa
abaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaahhcaabaaa
aaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaagiacaaaaaaaaaaaabaaaaaadcaaaaakhccabaaaaaaaaaaa
egacbaaaabaaaaaafgifcaaaaaaaaaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
ConstBuffer "$Globals" 80
Float 16 [_EmissionLM]
Float 20 [_DiffuseIntnsity]
Vector 32 [_Color]
Vector 48 [_IllumColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedejgmhgpkacomohogidagmdacipllkokaabaaaaaaceadaaaaaeaaaaaa
daaaaaaabmabaaaajiacaaaapaacaaaaebgpgodjoeaaaaaaoeaaaaaaaaacpppp
kmaaaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaaaaaaaaa
abababaaaaaaabaaadaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaadla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaecaaaaadaaaaapia
aaaaoelaabaioekaecaaaaadabaaapiaaaaaoelaaaaioekaafaaaaadabaaapia
abaaoeiaabaaoekaafaaaaadaaaaahiaabaaoeiaacaaoekaafaaaaadaaaaahia
aaaappiaaaaaoeiaafaaaaadaaaaahiaaaaaoeiaaaaaaakaaeaaaaaeabaaahia
abaaoeiaaaaaffkaaaaaoeiaabaaaaacaaaiapiaabaaoeiappppaaaafdeieefc
heabaaaaeaaaaaaafnaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
pcaabaaaabaaaaaaegaobaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaaaaaaaaaagiacaaaaaaaaaaaabaaaaaadcaaaaakhccabaaa
aaaaaaaaegacbaaaabaaaaaafgifcaaaaaaaaaaaabaaaaaaegacbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaabejfdeheofaaaaaaa
acaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
eeaaaaaaacaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
}
 }
}
Fallback "VertexLit"
}