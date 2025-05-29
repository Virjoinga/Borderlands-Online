ŸTShader "Hidden/GlobalFog" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "black" {}
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
PARAM c[5] = { { 0.1 },
		state.matrix.mvp };
TEMP R0;
MOV R0.xyw, vertex.position;
MOV R0.z, c[0].x;
DP4 result.position.w, R0, c[4];
DP4 result.position.z, R0, c[3];
DP4 result.position.y, R0, c[2];
DP4 result.position.x, R0, c[1];
MOV result.texcoord[0].xy, vertex.texcoord[0];
MOV result.texcoord[1].xy, vertex.texcoord[0];
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
def c5, 0.10000000, 0.00000000, 1.00000000, 0
mov r0.z, c5.y
slt r1.x, c4.y, r0.z
max r1.x, -r1, r1
slt r1.x, c5.y, r1
mov r0.xyw, v0
mov r0.z, c5.x
dp4 oPos.w, r0, c3
dp4 oPos.z, r0, c2
dp4 oPos.y, r0, c1
dp4 oPos.x, r0, c0
add r1.y, -r1.x, c5.z
mul r0.y, v1, r1
add r0.x, -v1.y, c5.z
mad oT0.y, r1.x, r0.x, r0
mov oT1.xy, v1
mov oT0.x, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 64 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedcabhblchongoabkbjhialhlemkegobecabaaaaaaiiacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapalaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcjaabaaaaeaaaabaageaaaaaa
fjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadlcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaanpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaaaceaaaaamnmmmmdnmnmmmmdnmnmmmmdnmnmmmmdnegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaa
aeaaaaaaabeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaa
abaaaaaaabeaaaaaaaaaiadpdhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaa
bkaabaaaaaaaaaaabkbabaaaabaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaa
abaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 64 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedipoopdgbhllmmccnpbnfmkjnblbffdbeabaaaaaamiadaaaaaeaaaaaa
daaaaaaagmabaaaaaeadaaaafiadaaaaebgpgodjdeabaaaadeabaaaaaaacpopp
peaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaaeaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaaf
agaaapkamnmmmmdnaaaaaaaaaaaaaamaaaaaiadpbpaaaaacafaaaaiaaaaaapja
bpaaaaacafaaabiaabaaapjaabaaaaacaaaaadiaagaaoekaamaaaaadaaaaacia
abaaffkaaaaaffiaaeaaaaaeaaaaaeiaabaaffjaagaakkkaagaappkaaeaaaaae
aaaaacoaaaaaffiaaaaakkiaabaaffjaafaaaaadabaaapiaaaaaffjaadaaoeka
aeaaaaaeabaaapiaacaaoekaaaaaaajaabaaoeiaaeaaaaaeaaaaapiaaeaaoeka
aaaaaaiaabaaoeiaaeaaaaaeaaaaapiaafaaoekaaaaappjaaaaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
aaaaanoaabaabejappppaaaafdeieefcjaabaaaaeaaaabaageaaaaaafjaaaaae
egiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaad
lcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaanpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaaaceaaaaamnmmmmdnmnmmmmdnmnmmmmdnmnmmmmdnegaobaaaaaaaaaaa
dcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaaeaaaaaa
abeaaaaaaaaaaaaaaaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaa
abeaaaaaaaaaiadpdhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaa
aaaaaaaabkbabaaaabaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaa
doaaaaabejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapalaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheogiaaaaaa
adaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaafmaaaaaaabaaaaaa
aaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhegjgpgoaafeeffied
epepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_ZBufferParams]
Float 1 [_GlobalDensity]
Vector 2 [_FogColor]
Vector 3 [_StartDistance]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 1, 0, 0.99900001 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R1.x, fragment.texcoord[1], texture[0], 2D;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MAD R2.x, R1, c[0], c[0].y;
RCP R2.x, R2.x;
MAD R2.z, R2.x, c[3].y, -c[3].x;
RCP R2.y, c[3].z;
MUL R2.y, R2.z, R2;
SLT R2.x, c[4].z, R2;
ABS R2.x, R2;
ADD R1, -R0, c[2];
MUL_SAT R2.y, R2, c[1].x;
MAD R1, R2.y, R1, R0;
CMP R2.x, -R2, c[4].y, c[4];
CMP result.color, -R2.x, R1, R0;
END
# 14 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_ZBufferParams]
Float 1 [_GlobalDensity]
Vector 2 [_FogColor]
Vector 3 [_StartDistance]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c4, 0.99900001, 0.00000000, 1.00000000, 0
dcl t0.xy
dcl t1.xy
texld r0, t1, s0
texld r2, t0, s1
mad r0.x, r0, c0, c0.y
rcp r1.x, r0.x
add r0.x, -r1, c4
cmp r0.x, r0, c4.y, c4.z
rcp r3.x, c3.z
mad r1.x, r1, c3.y, -c3
mul r1.x, r1, r3
add r3, -r2, c2
mul_sat r1.x, r1, c1
mad r1, r1.x, r3, r2
abs_pp r0.x, r0
cmp_pp r0, -r0.x, r1, r2
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 16 [_GlobalDensity]
Vector 32 [_FogColor]
Vector 48 [_StartDistance]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedhdldejkninfafigfnfbnofajflphcobiabaaaaaaaiadaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdaacaaaaeaaaaaaaimaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaa
akaabaaaaaaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
dbaaaaahccaabaaaaaaaaaaaabeaaaaahhlohpdpakaabaaaaaaaaaaabpaaaead
bkaabaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab
bcaaaaabdcaaaaambcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaaaaaaaaaa
adaaaaaaakiacaiaebaaaaaaaaaaaaaaadaaaaaaaoaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaackiacaaaaaaaaaaaadaaaaaadicaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaabaaaaaaaaaaaaajpcaabaaaacaaaaaa
egaobaiaebaaaaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaadcaaaaajpccabaaa
aaaaaaaaagaabaaaaaaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaadoaaaaab
bfaaaaabdoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 16 [_GlobalDensity]
Vector 32 [_FogColor]
Vector 48 [_StartDistance]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedmdlppfbalhhdcicmeacbhlfgfdccgegpabaaaaaagmaeaaaaaeaaaaaa
daaaaaaajaabaaaamiadaaaadiaeaaaaebgpgodjfiabaaaafiabaaaaaaacpppp
beabaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaabaaadaaaaaaaaaaaaaaabaaahaaabaaadaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkahhlohpdpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaac
aaaaadiaaaaabllaecaaaaadaaaaapiaaaaaoeiaabaioekaecaaaaadabaacpia
aaaaoelaaaaioekaaeaaaaaeaaaaabiaadaaaakaaaaaaaiaadaaffkaagaaaaac
aaaaabiaaaaaaaiaaeaaaaaeaaaaaciaaaaaaaiaacaaffkaacaaaakbacaaaaad
aaaaabiaaaaaaaibaeaaaakaagaaaaacaaaaaeiaacaakkkaafaaaaadaaaaacia
aaaakkiaaaaaffiaafaaaaadaaaabciaaaaaffiaaaaaaakabcaaaaaeacaacpia
aaaaffiaabaaoekaabaaoeiafiaaaaaeaaaacpiaaaaaaaiaacaaoeiaabaaoeia
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdaacaaaaeaaaaaaaimaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaa
akaabaaaaaaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
dbaaaaahccaabaaaaaaaaaaaabeaaaaahhlohpdpakaabaaaaaaaaaaabpaaaead
bkaabaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab
bcaaaaabdcaaaaambcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaaaaaaaaaa
adaaaaaaakiacaiaebaaaaaaaaaaaaaaadaaaaaaaoaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaackiacaaaaaaaaaaaadaaaaaadicaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaabaaaaaaaaaaaaajpcaabaaaacaaaaaa
egaobaiaebaaaaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaadcaaaaajpccabaaa
aaaaaaaaagaabaaaaaaaaaaaegaobaaaacaaaaaaegaobaaaabaaaaaadoaaaaab
bfaaaaabdoaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamamaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback Off
}