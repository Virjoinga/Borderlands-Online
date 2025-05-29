ÁXShader "uniSWF/Transparent/uniSWF-Double-Masked-Colour-Diffuse" {
Properties {
 _Color ("Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _MaskTex ("Base (RGB)", 2D) = "white" {}
 _Matrix2D ("_Matrix2D", Vector) = (0,0,0,0)
 _TestX ("_tX", Float) = 0
 _TestY ("_tY", Float) = 0
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  ZWrite Off
  Cull Off
  Blend SrcAlpha OneMinusSrcAlpha
Program "vp" {
SubProgram "opengl " {
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
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedkejgkochkjiddgaaajhoomcfbmeckomhabaaaaaahaacaaaaadaaaaaa
cmaaaaaajmaaaaaabaabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
gmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaagcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefcfiabaaaaeaaaabaafgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaa
dcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaadaaaaaa
ogikcaaaaaaaaaaaadaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedmdfifkiflonilgjbbpahgijlhecdoblpabaaaaaaheadaaaaaeaaaaaa
daaaaaaadaabaaaajaacaaaaaaadaaaaebgpgodjpiaaaaaapiaaaaaaaaacpopp
liaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaadaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
aeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaafaaaaadaaaaapiaaaaaffja
adaaoekaaeaaaaaeaaaaapiaacaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
aeaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
abaaaaacaaaaapoaabaaoejappppaaaafdeieefcfiabaaaaeaaaabaafgaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaa
dcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaadaaaaaa
ogikcaaaaaaaaaaaadaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaa
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
Vector 0 [_Matrix2D]
Float 1 [_tX]
Float 2 [_tY]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 1, 0 } };
TEMP R0;
TEMP R1;
TEX result.color.xyz, fragment.texcoord[0], texture[1], 2D;
ADD R0.y, -fragment.texcoord[0], c[3].x;
MUL R0.z, R0.y, c[0];
MAD R1.x, fragment.texcoord[0], c[0], R0.z;
ADD R0.z, R1.x, c[1].x;
MUL R0.x, R0.y, c[0].w;
MAD R0.x, fragment.texcoord[0], c[0].y, R0;
ADD R0.x, R0, c[2];
ADD R0.y, R0.x, c[3].x;
MOV R0.w, R0.y;
SLT R0.y, c[3].x, R0;
SLT R1.y, c[3].x, R0.z;
SLT R1.x, R1, -c[1];
ABS R0.y, R0;
TEX R0.w, R0.zwzw, texture[0], 2D;
ADD R0.z, R0, -c[3].x;
CMP R0.z, -R0, c[3].y, R0.w;
ABS R0.w, R1.y;
CMP R0.w, -R0, c[3].y, c[3].x;
MUL R0.w, R0, R1.x;
CMP R0.z, -R0.w, c[3].y, R0;
CMP R0.w, -R0.x, c[3].y, R0.z;
SLT R0.z, R0.x, -c[3].x;
CMP R0.x, -R0.y, c[3].y, c[3];
MUL R0.x, R0, R0.z;
CMP result.color.w, -R0.x, c[3].y, R0;
END
# 26 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Matrix2D]
Float 1 [_tX]
Float 2 [_tY]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 1.00000000, 0.00000000, -1.00000000, 0
dcl t0.xy
texld r4, t0, s1
add r0.x, -t0.y, c3
mul r1.x, r0, c0.w
mul r2.x, r0, c0.z
mad r2.x, t0, c0, r2
add r5.x, r2, c1
mad r1.x, t0, c0.y, r1
add r1.x, r1, c2
add r0.x, r1, c3
mov r5.y, r0.x
add r3.x, r5, c3.z
cmp r0.x, r0, c3.y, c3
texld r2, r5, s0
add r2.x, -r5, c3
cmp_pp r0.w, -r3.x, r2, c3.y
cmp r2.x, r2, c3.y, c3
abs_pp r2.x, r2
cmp r3.x, r5, c3.y, c3
cmp_pp r2.x, -r2, c3, c3.y
mul_pp r2.x, r2, r3
cmp_pp r0.w, -r2.x, r0, c3.y
cmp_pp r0.w, -r1.x, r0, c3.y
cmp r2.x, -r1, c3.y, c3
abs_pp r1.x, r2
cmp_pp r1.x, -r1, c3, c3.y
mul_pp r0.x, r1, r0
cmp_pp r4.w, -r0.x, r0, c3.y
mov_pp oC0, r4
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MaskTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_Matrix2D]
Float 32 [_tX]
Float 36 [_tY]
BindCB  "$Globals" 0
"ps_4_0
eefiecedkbilblepdkbhomooplhfkeeflohpokniabaaaaaaceadaaaaadaaaaaa
cmaaaaaakaaaaaaaneaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefceiacaaaaeaaaaaaa
jcaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaaaaaaaaibcaabaaaaaaaaaaabkbabaiaebaaaaaa
acaaaaaaabeaaaaaaaaaiadpdiaaaaaidcaabaaaaaaaaaaaagaabaaaaaaaaaaa
ogikcaaaaaaaaaaaabaaaaaadcaaaaakdcaabaaaaaaaaaaaagbabaaaacaaaaaa
egiacaaaaaaaaaaaabaaaaaaegaabaaaaaaaaaaaaaaaaaaigcaabaaaaaaaaaaa
agabbaaaaaaaaaaaagibcaaaaaaaaaaaacaaaaaaaaaaaaakjcaabaaaaaaaaaaa
kgakbaaaaaaaaaaaaceaaaaaaaaaiadpaaaaaaaaaaaaaaaaaaaaiadpdbaaaaak
dcaabaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaaaaaaaaaaaaabgafbaaa
aaaaaaaadbaaaaakfcaabaaaaaaaaaaafgaebaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaangafbaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadmaaaaahbcaabaaaaaaaaaaaakaabaaa
abaaaaaaakaabaaaaaaaaaaadmaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaa
akaabaaaaaaaaaaadmaaaaahbcaabaaaaaaaaaaabkaabaaaabaaaaaaakaabaaa
aaaaaaaadhaaaaajiccabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaa
dkaabaaaacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaaeghobaaa
abaaaaaaaagabaaaaaaaaaaadgaaaaafhccabaaaaaaaaaaaegacbaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MaskTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_Matrix2D]
Float 32 [_tX]
Float 36 [_tY]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedonodhbdgcofnkoeoohndeabpojplolkeabaaaaaanaaeaaaaaeaaaaaa
daaaaaaaniabaaaaciaeaaaajmaeaaaaebgpgodjkaabaaaakaabaaaaaaacpppp
giabaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaabaaaaaa
aaababaaaaaaabaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaiadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaabaaadlabpaaaaacaaaaaaja
aaaiapkabpaaaaacaaaaaajaabaiapkaacaaaaadaaaaaiiaabaafflbacaaaaka
afaaaaadaaaaabiaaaaappiaaaaappkaafaaaaadaaaaaciaaaaappiaaaaakkka
aeaaaaaeaaaaaciaabaaaalaaaaaaakaaaaaffiaacaaaaadabaaabiaaaaaffia
abaaaakaaeaaaaaeaaaaabiaabaaaalaaaaaffkaaaaaaaiaacaaaaadaaaaabia
aaaaaaiaabaaffkaacaaaaadabaaaciaaaaaaaiaacaaaakaecaaaaadaaaacpia
abaaoeiaabaioekaecaaaaadacaacpiaabaaoelaaaaioekafiaaaaaeaaaacbia
abaaaaiaaaaappiaacaaffkaacaaaaadaaaaaciaabaaaaibacaaaakafiaaaaae
aaaacbiaaaaaffiaaaaaaaiaacaaffkafiaaaaaeaaaacbiaabaaffiaaaaaaaia
acaaffkaacaaaaadaaaaaciaabaaffibacaaaakafiaaaaaeacaaciiaaaaaffia
aaaaaaiaacaaffkaabaaaaacaaaicpiaacaaoeiappppaaaafdeieefceiacaaaa
eaaaaaaajcaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaacaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacadaaaaaaaaaaaaaibcaabaaaaaaaaaaabkbabaia
ebaaaaaaacaaaaaaabeaaaaaaaaaiadpdiaaaaaidcaabaaaaaaaaaaaagaabaaa
aaaaaaaaogikcaaaaaaaaaaaabaaaaaadcaaaaakdcaabaaaaaaaaaaaagbabaaa
acaaaaaaegiacaaaaaaaaaaaabaaaaaaegaabaaaaaaaaaaaaaaaaaaigcaabaaa
aaaaaaaaagabbaaaaaaaaaaaagibcaaaaaaaaaaaacaaaaaaaaaaaaakjcaabaaa
aaaaaaaakgakbaaaaaaaaaaaaceaaaaaaaaaiadpaaaaaaaaaaaaaaaaaaaaiadp
dbaaaaakdcaabaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaaaaaaaaaaaaa
bgafbaaaaaaaaaaadbaaaaakfcaabaaaaaaaaaaafgaebaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaangafbaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadmaaaaahbcaabaaaaaaaaaaa
akaabaaaabaaaaaaakaabaaaaaaaaaaadmaaaaahbcaabaaaaaaaaaaackaabaaa
aaaaaaaaakaabaaaaaaaaaaadmaaaaahbcaabaaaaaaaaaaabkaabaaaabaaaaaa
akaabaaaaaaaaaaadhaaaaajiccabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaaaaadkaabaaaacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadgaaaaafhccabaaaaaaaaaaaegacbaaa
aaaaaaaadoaaaaabejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
fdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaaklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback Off
}