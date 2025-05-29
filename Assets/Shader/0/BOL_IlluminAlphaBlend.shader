¨NShader "BOL/UI/IlluminAlphaBlend" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,0.5)
 _MainTex ("Texture", 2D) = "white" {}
 _IllumTex ("Illumin (A)", 2D) = "white" {}
 _EmissionLM ("Emission (Lightmapper)", Float) = 1
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Cull Off
  Blend SrcAlpha OneMinusSrcAlpha
  AlphaTest Greater 0.01
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Vector 5 [_Color]
Vector 6 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[7] = { program.local[0],
		state.matrix.mvp,
		program.local[5..6] };
MUL result.color, vertex.color, c[5];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[6], c[6].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[6], c[6].zwzw;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 7 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_Color]
Vector 5 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
dcl_texcoord1 v2
dcl_color0 v3
mul oD0, v3, c4
mad oT0.xy, v1, c5, c5.zwzw
mad oT1.xy, v2, c5, c5.zwzw
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 64
Vector 16 [_Color]
Vector 48 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedaffjafcjjdconfcmcnjapnfmdheoiighabaaaaaadaadaaaaadaaaaaa
cmaaaaaapeaaaaaaiaabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoieaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaahkaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
amadaaaafdfgfpfaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaakl
fdeieefckiabaaaaeaaaabaagkaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaa
fjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaipccabaaaabaaaaaa
egbobaaaafaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaadaaaaaa
kgiocaaaaaaaaaaaadaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 64
Vector 16 [_Color]
Vector 48 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedoegjmcmmgmjcfgmlmefhkbmmpdekdpdcabaaaaaageaeaaaaaeaaaaaa
daaaaaaagaabaaaabaadaaaaniadaaaaebgpgodjciabaaaaciabaaaaaaacpopp
nmaaaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaabaa
abaaabaaaaaaaaaaaaaaadaaabaaacaaaaaaaaaaabaaaaaaaeaaadaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaadiaadaaapja
bpaaaaacafaaaeiaaeaaapjabpaaaaacafaaafiaafaaapjaafaaaaadaaaaapoa
afaaoejaabaaoekaaeaaaaaeabaaadoaadaaoejaacaaoekaacaaookaaeaaaaae
abaaamoaaeaabejaacaabekaacaalekaafaaaaadaaaaapiaaaaaffjaaeaaoeka
aeaaaaaeaaaaapiaadaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaafaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaappjaaaaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaa
fdeieefckiabaaaaeaaaabaagkaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaa
fjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
dcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaafpaaaaadpcbabaaaafaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadmccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaipccabaaaabaaaaaa
egbobaaaafaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaaeaaaaaaagiecaaaaaaaaaaaadaaaaaa
kgiocaaaaaaaaaaaadaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaa
laaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapapaaaafaepfdejfeejepeoaafeebeoehefeofe
aaeoepfcenebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoieaaaaaa
aeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
heaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaahkaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaacaaaaaaadamaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaamadaaaafdfgfpfaepfdejfeejepeoaaedepemepfcaafeeffiedepep
fceeaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_EmissionLM]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_IllumTex] 2D 1
"!!ARBfp1.0
PARAM c[1] = { program.local[0] };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[1], texture[1], 2D;
MUL R0, fragment.color.primary, R0;
MUL R1.x, R1.w, c[0];
MOV result.color.w, R0;
MUL result.color.xyz, R0, R1.x;
END
# 6 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_EmissionLM]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_IllumTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl v0
dcl t0.xy
dcl t1.xy
texld r0, t1, s1
texld r1, t0, s0
mul r0.x, r0.w, c0
mul r1, v0, r1
mul r0.xyz, r1, r0.x
mov r0.w, r1
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_IllumTex] 2D 1
ConstBuffer "$Globals" 64
Float 32 [_EmissionLM]
BindCB  "$Globals" 0
"ps_4_0
eefiecedknjdgpeglpbcgefcmjhnbjcfjafjngigabaaaaaadmacaaaaadaaaaaa
cmaaaaaaliaaaaaaomaaaaaaejfdeheoieaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaafdfgfpfa
epfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklklfdeieefceiabaaaaeaaaaaaafcaaaaaafjaaaaae
egiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaa
abaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaad
mcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaacaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
diaaaaaibcaabaaaaaaaaaaadkaabaaaaaaaaaaaakiacaaaaaaaaaaaacaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahocaabaaaaaaaaaaaagajbaaaabaaaaaaagbjbaaaabaaaaaa
diaaaaahiccabaaaaaaaaaaadkaabaaaabaaaaaadkbabaaaabaaaaaadiaaaaah
hccabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_IllumTex] 2D 1
ConstBuffer "$Globals" 64
Float 32 [_EmissionLM]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedckllbhdopeendcojmahmmjndfdeidppiabaaaaaadaadaaaaaeaaaaaa
daaaaaaacaabaaaahaacaaaapmacaaaaebgpgodjoiaaaaaaoiaaaaaaaaacpppp
laaaaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaaaaaaaaa
abababaaaaaaacaaabaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaapla
bpaaaaacaaaaaaiaabaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaaja
abaiapkaabaaaaacaaaaadiaabaabllaecaaaaadaaaaapiaaaaaoeiaabaioeka
ecaaaaadabaacpiaabaaoelaaaaioekaafaaaaadaaaaabiaaaaappiaaaaaaaka
afaaaaadaaaaaoiaabaabliaaaaabllaafaaaaadabaaaiiaabaappiaaaaappla
afaaaaadabaaahiaaaaaaaiaaaaabliaabaaaaacaaaiapiaabaaoeiappppaaaa
fdeieefceiabaaaaeaaaaaaafcaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadmcbabaaaacaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaa
acaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaa
dkaabaaaaaaaaaaaakiacaaaaaaaaaaaacaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahocaabaaa
aaaaaaaaagajbaaaabaaaaaaagbjbaaaabaaaaaadiaaaaahiccabaaaaaaaaaaa
dkaabaaaabaaaaaadkbabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaaagaabaaa
aaaaaaaajgahbaaaaaaaaaaadoaaaaabejfdeheoieaaaaaaaeaaaaaaaiaaaaaa
giaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadadaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaamamaaaa
fdfgfpfaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback "VertexLit"
}