�Shader "Hidden/Tonemapper" {
Properties {
 _MainTex ("", 2D) = "black" {}
 _SmallTex ("", 2D) = "grey" {}
 _Curve ("", 2D) = "black" {}
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
Vector 0 [_HdrParams]
SetTexture 0 [_SmallTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0],
		{ 1.0002404e-006, 0.2199707, 0.70703125, 0.070983887 },
		{ 0.001, 1 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[1], 2D;
TEX R1.x, fragment.texcoord[0], texture[0], 2D;
ADD R1.z, R1.x, c[2].x;
RCP R1.w, R1.z;
DP3 R1.y, R0, c[1].yzww;
MAX R1.y, R1, c[1].x;
MUL R1.x, R1.y, c[0].z;
MUL R1.x, R1, R1.w;
RCP R1.z, c[0].w;
MAD R1.w, R1.x, R1.z, c[2].y;
ADD R1.z, R1.x, c[2].y;
MUL R1.x, R1, R1.w;
RCP R1.z, R1.z;
RCP R1.y, R1.y;
MUL R1.x, R1, R1.z;
MUL R1.x, R1, R1.y;
MUL result.color.xyz, R0, R1.x;
MOV result.color.w, R0;
END
# 18 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_HdrParams]
SetTexture 0 [_SmallTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 0.21997070, 0.70703125, 0.07098389, 0.00000100
def c2, 0.00100000, 1.00000000, 0, 0
dcl t0.xy
texld r3, t0, s1
texld r1, t0, s0
add r2.x, r1, c2
rcp r4.x, r2.x
dp3_pp r0.x, r3, c1
max_pp r0.x, r0, c1.w
mul r1.x, r0, c0.z
mul r1.x, r1, r4
rcp r2.x, c0.w
mad r4.x, r1, r2, c2.y
add r2.x, r1, c2.y
mul r1.x, r1, r4
rcp r2.x, r2.x
rcp r0.x, r0.x
mul r1.x, r1, r2
mul r0.x, r1, r0
mov r0.w, r3
mul r0.xyz, r3, r0.x
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_SmallTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_HdrParams]
BindCB  "$Globals" 0
"ps_4_0
eefiecedgodnkkimpbjhiooenelmnnglfnkfphmjabaaaaaapeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdeacaaaa
eaaaaaaainaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaagpbciddkefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaabaaaaaakccaabaaaaaaaaaaa
egacbaaaabaaaaaaaceaaaaakoehgbdopepndedphdgijbdnaaaaaaaadeaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaalndhigdfdiaaaaaiecaabaaa
aaaaaaaabkaabaaaaaaaaaaackiacaaaaaaaaaaaabaaaaaaaoaaaaahbcaabaaa
aaaaaaaackaabaaaaaaaaaaaakaabaaaaaaaaaaaaoaaaaaiecaabaaaaaaaaaaa
akaabaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaaaaaaaaahecaabaaaaaaaaaaa
ckaabaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahecaabaaaaaaaaaaackaabaaa
aaaaaaaaakaabaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaiadpaoaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaakaabaaa
aaaaaaaaaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaa
diaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_SmallTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_HdrParams]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefieceddkndfkagjnpbcejnodpbjbldepmgjlebabaaaaaakiaeaaaaaeaaaaaa
daaaaaaaoaabaaaabmaeaaaaheaeaaaaebgpgodjkiabaaaakiabaaaaaaacpppp
haabaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkakoehgbdo
pepndedphdgijbdnlndhigdffbaaaaafacaaapkagpbciddkaaaaiadpaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkabpaaaaac
aaaaaajaabaiapkaecaaaaadaaaaapiaaaaaoelaabaioekaecaaaaadabaaapia
aaaaoelaaaaioekaagaaaaacaaaaaciaaaaappkaacaaaaadaaaaabiaaaaaaaia
acaaaakaagaaaaacaaaaabiaaaaaaaiaaiaaaaadaaaaceiaabaaoeiaabaaoeka
alaaaaadacaaaiiaabaappkaaaaakkiaafaaaaadaaaaaeiaacaappiaaaaakkka
agaaaaacaaaaaiiaacaappiaafaaaaadacaaabiaaaaaaaiaaaaakkiaaeaaaaae
aaaaabiaaaaakkiaaaaaaaiaacaaffkaagaaaaacaaaaabiaaaaaaaiaaeaaaaae
aaaaaciaacaaaaiaaaaaffiaacaaffkaafaaaaadaaaaaciaaaaaffiaacaaaaia
afaaaaadaaaaabiaaaaaaaiaaaaaffiaafaaaaadaaaaabiaaaaappiaaaaaaaia
afaaaaadabaaahiaaaaaaaiaabaaoeiaabaaaaacaaaiapiaabaaoeiappppaaaa
fdeieefcdeacaaaaeaaaaaaainaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaaaaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaagpbciddkefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaabaaaaaak
ccaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaakoehgbdopepndedphdgijbdn
aaaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaalndhigdf
diaaaaaiecaabaaaaaaaaaaabkaabaaaaaaaaaaackiacaaaaaaaaaaaabaaaaaa
aoaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaakaabaaaaaaaaaaaaoaaaaai
ecaabaaaaaaaaaaaakaabaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaaaaaaaaah
ecaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaiadpaoaaaaahbcaabaaaaaaaaaaackaabaaa
aaaaaaaaakaabaaaaaaaaaaaaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaaaaaaaaaaadiaaaaahhccabaaaaaaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaabejfdeheo
faaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfa
gphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
}
 }
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
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0],
		{ 0.1732868, 0, 9.9999997e-005 },
		{ 0.2199707, 0.70703125, 0.070983887 },
		{ -1, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xy, c[3];
MAD R1.zw, R1.xyyx, c[0].xyxy, fragment.texcoord[0].xyxy;
MAD R1.xy, R1, c[0], fragment.texcoord[0];
ADD R0.zw, fragment.texcoord[0].xyxy, c[0].xyxy;
ADD R0.xy, fragment.texcoord[0], -c[0];
TEX R3.xyz, R1.zwzw, texture[0], 2D;
TEX R2.xyz, R1, texture[0], 2D;
TEX R1.xyz, R0.zwzw, texture[0], 2D;
TEX R0.xyz, R0, texture[0], 2D;
DP3 R0.x, R0, c[2];
DP3 R0.w, R1, c[2];
ADD R0.y, R0.w, c[1].z;
ADD R0.x, R0, c[1].z;
DP3 R0.z, R3, c[2];
ADD R0.z, R0, c[1];
LG2 R0.y, R0.y;
LG2 R0.x, R0.x;
ADD R0.x, R0, R0.y;
DP3 R0.y, R2, c[2];
ADD R0.y, R0, c[1].z;
LG2 R0.y, R0.y;
LG2 R0.z, R0.z;
ADD R0.x, R0, R0.y;
ADD R0.x, R0, R0.z;
MUL result.color, R0.x, c[1].x;
END
# 25 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 0.21997070, 0.70703125, 0.07098389, 0.00010000
def c2, -1.00000000, 1.00000000, 0.17328680, 0
dcl t0.xy
add r3.xy, t0, -c0
mov r2.xy, c0
mad r2.xy, c2, r2, t0
mov r0.x, c2.y
mov r0.y, c2.x
mov r1.xy, c0
mad r1.xy, r0, r1, t0
add r0.xy, t0, c0
texld r0, r0, s0
texld r1, r1, s0
texld r2, r2, s0
texld r3, r3, s0
dp3_pp r0.x, r0, c1
dp3_pp r3.x, r3, c1
add r0.x, r0, c1.w
add r3.x, r3, c1.w
dp3_pp r2.x, r2, c1
dp3_pp r1.x, r1, c1
add r2.x, r2, c1.w
add r1.x, r1, c1.w
log r0.x, r0.x
log r3.x, r3.x
add r0.x, r3, r0
log r2.x, r2.x
log r1.x, r1.x
add r0.x, r0, r2
add r0.x, r0, r1
mul r0.x, r0, c2.z
mov r0, r0.x
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
BindCB  "$Globals" 0
"ps_4_0
eefiecedcgpjhnapgggmbjojgikabhmhgbnaljkkabaaaaaadaaeaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefchaadaaaa
eaaaaaaanmaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaaaaaaaaidcaabaaaaaaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabaaaaaakbcaabaaa
aaaaaaaaegacbaaaaaaaaaaaaceaaaaakoehgbdopepndedphdgijbdnaaaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaabhlhnbdicpaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaabihcdbdpaaaaaaajgcaabaaaaaaaaaaaagbbbaaaabaaaaaa
agibcaiaebaaaaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaajgafbaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabaaaaaakccaabaaaaaaaaaaa
egacbaaaabaaaaaaaceaaaaakoehgbdopepndedphdgijbdnaaaaaaaaaaaaaaah
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaabhlhnbdicpaaaaafccaabaaa
aaaaaaaabkaabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaabihcdbdpakaabaaaaaaaaaaadcaaaaanpcaabaaaabaaaaaaegiecaaa
aaaaaaaaadaaaaaaaceaaaaaaaaaialpaaaaiadpaaaaiadpaaaaialpegbebaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaabaaaaaakccaabaaaaaaaaaaaegacbaaaabaaaaaa
aceaaaaakoehgbdopepndedphdgijbdnaaaaaaaaaaaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaabhlhnbdicpaaaaafccaabaaaaaaaaaaabkaabaaa
aaaaaaaabaaaaaakecaabaaaaaaaaaaaegacbaaaacaaaaaaaceaaaaakoehgbdo
pepndedphdgijbdnaaaaaaaaaaaaaaahecaabaaaaaaaaaaackaabaaaaaaaaaaa
abeaaaaabhlhnbdicpaaaaafecaabaaaaaaaaaaackaabaaaaaaaaaaadcaaaaaj
bcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaabihcdbdpakaabaaaaaaaaaaa
dcaaaaajbcaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaabihcdbdpakaabaaa
aaaaaaaadiaaaaakpccabaaaaaaaaaaaagaabaaaaaaaaaaaaceaaaaaaaaaiado
aaaaiadoaaaaiadoaaaaiadodoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedngnckgpplbiknmhjbhdgcpkdmnndpjncabaaaaaagmagaaaaaeaaaaaa
daaaaaaagiacaaaaoaafaaaadiagaaaaebgpgodjdaacaaaadaacaaaaaaacpppp
pmabaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaadaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkakoehgbdopepndedp
hdgijbdnbhlhnbdifbaaaaafacaaapkabihcdbdpaaaaialpaaaaiadpaaaaiado
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaacaaaaadaaaaadia
aaaaoelaaaaaoekaacaaaaadabaaadiaaaaaoelaaaaaoekbabaaaaacacaaagia
acaaoekaaeaaaaaeadaaadiaaaaaoekaacaamjiaaaaaoelaaeaaaaaeacaaadia
aaaaoekaacaamjibaaaaoelaecaaaaadaaaacpiaaaaaoeiaaaaioekaecaaaaad
abaacpiaabaaoeiaaaaioekaecaaaaadadaacpiaadaaoeiaaaaioekaecaaaaad
acaacpiaacaaoeiaaaaioekaaiaaaaadabaaciiaaaaaoeiaabaaoekaacaaaaad
abaaaiiaabaappiaabaappkaapaaaaacabaaaiiaabaappiaafaaaaadabaaaiia
abaappiaacaaaakaaiaaaaadacaaciiaabaaoeiaabaaoekaacaaaaadacaaaiia
acaappiaabaappkaapaaaaacacaaaiiaacaappiaaeaaaaaeacaaaiiaacaappia
acaaaakaabaappiaaiaaaaadaaaacbiaadaaoeiaabaaoekaacaaaaadaaaaabia
aaaaaaiaabaappkaapaaaaacaaaaabiaaaaaaaiaaeaaaaaeacaaaiiaaaaaaaia
acaaaakaacaappiaaiaaaaadaaaacbiaacaaoeiaabaaoekaacaaaaadaaaaabia
aaaaaaiaabaappkaapaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaabiaaaaaaaia
acaaaakaacaappiaafaaaaadaaaaapiaaaaaaaiaacaappkaabaaaaacaaaiapia
aaaaoeiappppaaaafdeieefchaadaaaaeaaaaaaanmaaaaaafjaaaaaeegiocaaa
aaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
adaaaaaaaaaaaaaidcaabaaaaaaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
adaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaabaaaaaakbcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
koehgbdopepndedphdgijbdnaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaabhlhnbdicpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaabihcdbdpaaaaaaaj
gcaabaaaaaaaaaaaagbbbaaaabaaaaaaagibcaiaebaaaaaaaaaaaaaaadaaaaaa
efaaaaajpcaabaaaabaaaaaajgafbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaabaaaaaakccaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaakoehgbdo
pepndedphdgijbdnaaaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaabhlhnbdicpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaaj
bcaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaabihcdbdpakaabaaaaaaaaaaa
dcaaaaanpcaabaaaabaaaaaaegiecaaaaaaaaaaaadaaaaaaaceaaaaaaaaaialp
aaaaiadpaaaaiadpaaaaialpegbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
egaabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabaaaaaak
ccaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaakoehgbdopepndedphdgijbdn
aaaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaabhlhnbdi
cpaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaabaaaaaakecaabaaaaaaaaaaa
egacbaaaacaaaaaaaceaaaaakoehgbdopepndedphdgijbdnaaaaaaaaaaaaaaah
ecaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaabhlhnbdicpaaaaafecaabaaa
aaaaaaaackaabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaackaabaaaaaaaaaaa
abeaaaaabihcdbdpakaabaaaaaaaaaaadcaaaaajbcaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaabihcdbdpakaabaaaaaaaaaaadiaaaaakpccabaaaaaaaaaaa
agaabaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiadoaaaaiadodoaaaaab
ejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend SrcAlpha OneMinusSrcAlpha
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
Vector 0 [_MainTex_TexelSize]
Float 1 [_AdaptionSpeed]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..1],
		{ 0.25, 2.718282, 1, -1 },
		{ 0.0125 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xy, c[2].zwzw;
MAD R1.zw, R1.xyyx, c[0].xyxy, fragment.texcoord[0].xyxy;
MAD R1.xy, R1, c[0], fragment.texcoord[0];
ADD R0.xy, fragment.texcoord[0], -c[0];
ADD R0.zw, fragment.texcoord[0].xyxy, c[0].xyxy;
TEX R2.xy, R1, texture[0], 2D;
TEX R1.xy, R0.zwzw, texture[0], 2D;
TEX R0.xy, R0, texture[0], 2D;
TEX R3.xy, R1.zwzw, texture[0], 2D;
ADD R0.xy, R0, R1;
ADD R0.xy, R0, R2;
ADD R0.xy, R0, R3;
MUL R0.zw, R0.xyxy, c[2].x;
MOV R0.x, c[3];
POW result.color.y, c[2].y, R0.w;
POW result.color.xz, c[2].y, R0.z;
MUL_SAT result.color.w, R0.x, c[1].x;
END
# 17 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Float 1 [_AdaptionSpeed]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c2, 1.00000000, -1.00000000, 0.25000000, 2.71828198
def c3, 0.01250000, 0, 0, 0
dcl t0.xy
add r3.xy, t0, -c0
add r2.xy, t0, c0
mov r1.xy, c0
mov r0.x, c2.y
mov r0.y, c2.x
mad r0.xy, r0, r1, t0
mov r1.xy, c0
mad r1.xy, c2, r1, t0
texld r1, r1, s0
texld r0, r0, s0
texld r2, r2, s0
texld r3, r3, s0
add r2.xy, r3, r2
add r1.xy, r2, r1
add r0.xy, r1, r0
mul r1.xy, r0, c2.z
pow r0.x, c2.w, r1.y
mov r1.y, r0.x
pow r0.x, c2.w, r1.x
mov r1.x, c1
mul_sat r1.w, c3.x, r1.x
mov r1.xz, r0.x
mov oC0, r1
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
Float 64 [_AdaptionSpeed]
BindCB  "$Globals" 0
"ps_4_0
eefiecedodhoojoggjfcljfkbkmbnlckmgnfhocdabaaaaaanaacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaacaaaa
eaaaaaaaieaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaaaaaaaajdcaabaaaaaaaaaaa
egbabaaaabaaaaaaegiacaiaebaaaaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaai
mcaabaaaaaaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaahhcaabaaaaaaaaaaaegaabaaaaaaaaaaaegaabaaaabaaaaaadcaaaaan
pcaabaaaabaaaaaaegiecaaaaaaaaaaaadaaaaaaaceaaaaaaaaaiadpaaaaialp
aaaaialpaaaaiadpegbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegaabaaaacaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egaabaaaabaaaaaaegacbaaaaaaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaaceaaaaadlkklidodlkklidodlkklidoaaaaaaaabjaaaaafhccabaaa
aaaaaaaaegacbaaaaaaaaaaadicaaaaiiccabaaaaaaaaaaaakiacaaaaaaaaaaa
aeaaaaaaabeaaaaamnmmemdmdoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
Float 64 [_AdaptionSpeed]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedaemfcceakkfmhkeikpfgihmhmfnmdjelabaaaaaaheaeaaaaaeaaaaaa
daaaaaaanaabaaaaoiadaaaaeaaeaaaaebgpgodjjiabaaaajiabaaaaaaacpppp
geabaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaadaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaiadpaaaaialp
aaaaiadpdlkklidofbaaaaafadaaapkamnmmemdmaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaacaaaaadaaaaadia
aaaaoelaaaaaoekbacaaaaadabaaadiaaaaaoelaaaaaoekaabaaaaacacaaadia
aaaaoekaaeaaaaaeadaaadiaacaaoeiaacaaoekaaaaaoelaaeaaaaaeacaaadia
acaaoeiaacaamjkaaaaaoelaecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadadaaapiaadaaoeiaaaaioekaecaaaaad
acaaapiaacaaoeiaaaaioekaacaaaaadaaaaadiaaaaaoeiaabaaoeiaacaaaaad
aaaaadiaadaaoeiaaaaaoeiaacaaaaadaaaaadiaacaaoeiaaaaaoeiaafaaaaad
aaaaadiaaaaaoeiaacaappkaaoaaaaacabaaafiaaaaaaaiaaoaaaaacabaaacia
aaaaffiaabaaaaacaaaaabiaabaaaakaafaaaaadabaabiiaaaaaaaiaadaaaaka
abaaaaacaaaiapiaabaaoeiappppaaaafdeieefcbaacaaaaeaaaaaaaieaaaaaa
fjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaaaaaaaajdcaabaaaaaaaaaaaegbabaaaabaaaaaa
egiacaiaebaaaaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaimcaabaaaaaaaaaaa
agbebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
ogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaabaaaaaadcaaaaanpcaabaaaabaaaaaa
egiecaaaaaaaaaaaadaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaialpaaaaiadp
egbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegaabaaaacaaaaaaaaaaaaahhcaabaaaaaaaaaaaegaabaaaabaaaaaa
egacbaaaaaaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
dlkklidodlkklidodlkklidoaaaaaaaabjaaaaafhccabaaaaaaaaaaaegacbaaa
aaaaaaaadicaaaaiiccabaaaaaaaaaaaakiacaaaaaaaaaaaaeaaaaaaabeaaaaa
mnmmemdmdoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
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
Vector 0 [_MainTex_TexelSize]
Float 1 [_AdaptionSpeed]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..1],
		{ 0.25, 2.718282, 1, -1 },
		{ 0.0125 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xy, c[2].zwzw;
MAD R1.zw, R1.xyyx, c[0].xyxy, fragment.texcoord[0].xyxy;
MAD R1.xy, R1, c[0], fragment.texcoord[0];
ADD R0.xy, fragment.texcoord[0], -c[0];
ADD R0.zw, fragment.texcoord[0].xyxy, c[0].xyxy;
TEX R2.xy, R1, texture[0], 2D;
TEX R1.xy, R0.zwzw, texture[0], 2D;
TEX R0.xy, R0, texture[0], 2D;
TEX R3.xy, R1.zwzw, texture[0], 2D;
ADD R0.xy, R0, R1;
ADD R0.xy, R0, R2;
ADD R0.xy, R0, R3;
MUL R0.zw, R0.xyxy, c[2].x;
MOV R0.x, c[3];
POW result.color.y, c[2].y, R0.w;
POW result.color.xz, c[2].y, R0.z;
MUL_SAT result.color.w, R0.x, c[1].x;
END
# 17 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Float 1 [_AdaptionSpeed]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c2, 1.00000000, -1.00000000, 0.25000000, 2.71828198
def c3, 0.01250000, 0, 0, 0
dcl t0.xy
add r3.xy, t0, -c0
add r2.xy, t0, c0
mov r1.xy, c0
mov r0.x, c2.y
mov r0.y, c2.x
mad r0.xy, r0, r1, t0
mov r1.xy, c0
mad r1.xy, c2, r1, t0
texld r1, r1, s0
texld r0, r0, s0
texld r2, r2, s0
texld r3, r3, s0
add r2.xy, r3, r2
add r1.xy, r2, r1
add r0.xy, r1, r0
mul r1.xy, r0, c2.z
pow r0.x, c2.w, r1.y
mov r1.y, r0.x
pow r0.x, c2.w, r1.x
mov r1.x, c1
mul_sat r1.w, c3.x, r1.x
mov r1.xz, r0.x
mov oC0, r1
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
Float 64 [_AdaptionSpeed]
BindCB  "$Globals" 0
"ps_4_0
eefiecedodhoojoggjfcljfkbkmbnlckmgnfhocdabaaaaaanaacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaacaaaa
eaaaaaaaieaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaaaaaaaajdcaabaaaaaaaaaaa
egbabaaaabaaaaaaegiacaiaebaaaaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaai
mcaabaaaaaaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaaefaaaaaj
pcaabaaaabaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaahhcaabaaaaaaaaaaaegaabaaaaaaaaaaaegaabaaaabaaaaaadcaaaaan
pcaabaaaabaaaaaaegiecaaaaaaaaaaaadaaaaaaaceaaaaaaaaaiadpaaaaialp
aaaaialpaaaaiadpegbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogakbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegaabaaaacaaaaaaaaaaaaahhcaabaaaaaaaaaaa
egaabaaaabaaaaaaegacbaaaaaaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaaceaaaaadlkklidodlkklidodlkklidoaaaaaaaabjaaaaafhccabaaa
aaaaaaaaegacbaaaaaaaaaaadicaaaaiiccabaaaaaaaaaaaakiacaaaaaaaaaaa
aeaaaaaaabeaaaaamnmmemdmdoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
Float 64 [_AdaptionSpeed]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedaemfcceakkfmhkeikpfgihmhmfnmdjelabaaaaaaheaeaaaaaeaaaaaa
daaaaaaanaabaaaaoiadaaaaeaaeaaaaebgpgodjjiabaaaajiabaaaaaaacpppp
geabaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaadaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaiadpaaaaialp
aaaaiadpdlkklidofbaaaaafadaaapkamnmmemdmaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaacaaaaadaaaaadia
aaaaoelaaaaaoekbacaaaaadabaaadiaaaaaoelaaaaaoekaabaaaaacacaaadia
aaaaoekaaeaaaaaeadaaadiaacaaoeiaacaaoekaaaaaoelaaeaaaaaeacaaadia
acaaoeiaacaamjkaaaaaoelaecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadadaaapiaadaaoeiaaaaioekaecaaaaad
acaaapiaacaaoeiaaaaioekaacaaaaadaaaaadiaaaaaoeiaabaaoeiaacaaaaad
aaaaadiaadaaoeiaaaaaoeiaacaaaaadaaaaadiaacaaoeiaaaaaoeiaafaaaaad
aaaaadiaaaaaoeiaacaappkaaoaaaaacabaaafiaaaaaaaiaaoaaaaacabaaacia
aaaaffiaabaaaaacaaaaabiaabaaaakaafaaaaadabaabiiaaaaaaaiaadaaaaka
abaaaaacaaaiapiaabaaoeiappppaaaafdeieefcbaacaaaaeaaaaaaaieaaaaaa
fjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaaaaaaaajdcaabaaaaaaaaaaaegbabaaaabaaaaaa
egiacaiaebaaaaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaimcaabaaaaaaaaaaa
agbebaaaabaaaaaaagiecaaaaaaaaaaaadaaaaaaefaaaaajpcaabaaaabaaaaaa
ogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaabaaaaaadcaaaaanpcaabaaaabaaaaaa
egiecaaaaaaaaaaaadaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaialpaaaaiadp
egbebaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogakbaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaaegaabaaaacaaaaaaaaaaaaahhcaabaaaaaaaaaaaegaabaaaabaaaaaa
egacbaaaaaaaaaaadiaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
dlkklidodlkklidodlkklidoaaaaaaaabjaaaaafhccabaaaaaaaaaaaegacbaaa
aaaaaaaadicaaaaiiccabaaaaaaaaaaaakiacaaaaaaaaaaaaeaaaaaaabeaaaaa
mnmmemdmdoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
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
Float 0 [_RangeScale]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Curve] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[7] = { program.local[0],
		{ 0.075300001, -0.2543, 1.1892, 0.5 },
		{ 0.0241188, 0.1228178, 0.84442663, 1 },
		{ 0.26506799, 0.67023426, 0.064091571 },
		{ 0.51413637, 0.32387859, 0.16036376 },
		{ -1.0217, 1.9777, 0.043900002 },
		{ 2.5651, -1.1665, -0.39860001 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
DP3 R1.z, R0, c[3];
DP3 R1.w, R0, c[2];
MOV R1.y, c[1].w;
MUL R1.x, R1.z, c[0];
MOV result.color.w, R0;
TEX R1.x, R1, texture[1], 2D;
DP3 R1.y, R0, c[4];
DP3 R0.x, R1.yzww, c[2].w;
RCP R0.x, R0.x;
MUL R0.xy, R1.yzzw, R0.x;
ADD R0.z, -R0.x, -R0.y;
ADD R0.z, R0, c[2].w;
RCP R0.y, R0.y;
MUL R0.x, R1, R0;
MUL R0.z, R1.x, R0;
MUL R0.z, R0, R0.y;
MUL R0.x, R0.y, R0;
MOV R0.y, R1.x;
DP3 result.color.z, R0, c[1];
DP3 result.color.y, R0, c[5];
DP3 result.color.x, R0, c[6];
END
# 22 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_RangeScale]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Curve] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 0.02411880, 0.12281780, 0.84442663, 0.50000000
def c2, 0.26506799, 0.67023426, 0.06409157, 1.00000000
def c3, 0.51413637, 0.32387859, 0.16036376, 0
def c4, 0.07530000, -0.25430000, 1.18920004, 0
def c5, -1.02170002, 1.97770000, 0.04390000, 0
def c6, 2.56509995, -1.16649997, -0.39860001, 0
dcl t0.xy
texld r2, t0, s0
dp3 r0.x, r2, c2
dp3 r3.x, r2, c3
mov r3.y, r0.x
mul r1.x, r0, c0
dp3 r3.z, r2, c1
dp3 r0.x, r3, c2.w
mov r1.y, c1.w
rcp r0.x, r0.x
mul r0.xy, r3, r0.x
add r2.x, -r0, -r0.y
add r3.x, r2, c2.w
rcp r2.x, r0.y
texld r1, r1, s1
mul r0.x, r1, r0
mul r3.x, r1, r3
mul r0.z, r3.x, r2.x
mul r0.x, r2, r0
mov r0.y, r1.x
dp3 r1.z, r0, c4
dp3 r1.y, r0, c5
mov r1.w, r2
dp3 r1.x, r0, c6
mov oC0, r1
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Curve] 2D 1
ConstBuffer "$Globals" 80
Float 72 [_RangeScale]
BindCB  "$Globals" 0
"ps_4_0
eefiecedacgkfaphcdjiaffbfbodiomcepjomddaabaaaaaahaadaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefclaacaaaa
eaaaaaaakmaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabaaaaaakecaabaaaabaaaaaa
aceaaaaamkjemfdmogihpldnficmfidpaaaaaaaaegacbaaaaaaaaaaabaaaaaak
bcaabaaaabaaaaaaaceaaaaahbjoaddpgkndkfdoggdgcedoaaaaaaaaegacbaaa
aaaaaaaabaaaaaakccaabaaaabaaaaaaaceaaaaapolgihdohjjecldphbeciddn
aaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaa
baaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaaaaa
egacbaaaabaaaaaaaoaaaaahdcaabaaaaaaaaaaaegaabaaaabaaaaaaagaabaaa
aaaaaaaadiaaaaaibcaabaaaabaaaaaabkaabaaaabaaaaaackiacaaaaaaaaaaa
aeaaaaaaaaaaaaaiecaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaa
aaaaiadpaaaaaaaiecaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaackaabaaa
aaaaaaaadgaaaaafccaabaaaabaaaaaaabeaaaaaaaaaaadpefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaabghobaaaabaaaaaaaagabaaaabaaaaaadiaaaaah
fcaabaaaaaaaaaaaagacbaaaaaaaaaaafgafbaaaabaaaaaaaoaaaaahfcaabaaa
abaaaaaaagacbaaaaaaaaaaafgafbaaaaaaaaaaabaaaaaakbccabaaaaaaaaaaa
aceaaaaajjckceeanpepjflpenbfmmloaaaaaaaaegacbaaaabaaaaaabaaaaaak
cccabaaaaaaaaaaaaceaaaaabbmhiclpegcfpndphnnadddnaaaaaaaaegacbaaa
abaaaaaabaaaaaakeccabaaaaaaaaaaaaceaaaaaoddgjkdnjmddiclolfdhjidp
aaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_Curve] 2D 1
ConstBuffer "$Globals" 80
Float 72 [_RangeScale]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefieceddpnacmmggedllkhlmkbpnaobjhgkcnbhabaaaaaameafaaaaaeaaaaaa
daaaaaaaiaacaaaadiafaaaajaafaaaaebgpgodjeiacaaaaeiacaaaaaaacpppp
baacaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaaaaaaaaa
abababaaaaaaaeaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkapolgihdo
hjjecldphbeciddnaaaaaadpfbaaaaafacaaapkahbjoaddpgkndkfdoggdgcedo
aaaaiadpfbaaaaafadaaapkamkjemfdmogihpldnficmfidpaaaaaaaafbaaaaaf
aeaaapkajjckceeanpepjflpenbfmmloaaaaaaaafbaaaaafafaaapkabbmhiclp
egcfpndphnnadddnaaaaaaaafbaaaaafagaaapkaoddgjkdnjmddiclolfdhjidp
aaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkabpaaaaac
aaaaaajaabaiapkaecaaaaadaaaaapiaaaaaoelaaaaioekaaiaaaaadabaaaeia
adaaoekaaaaaoeiaaiaaaaadabaaaciaabaaoekaaaaaoeiaafaaaaadacaaabia
abaaffiaaaaakkkaaiaaaaadabaaabiaacaaoekaaaaaoeiaaiaaaaadabaaaeia
acaappkaabaaoeiaagaaaaacabaaaeiaabaakkiaaeaaaaaeabaaaiiaabaaaaia
abaakkibacaappkaafaaaaadacaaamiaabaakkiaabaabliaaeaaaaaeabaaabia
abaaffiaabaakkibabaappiaabaaaaacacaaaciaabaappkaecaaaaadadaaapia
acaaoeiaabaioekaafaaaaadabaaabiaabaaaaiaadaaaaiaagaaaaacabaaacia
acaakkiaafaaaaadabaaaeiaacaappiaadaaaaiaabaaaaacacaaaciaadaaaaia
afaaaaadacaaabiaabaaffiaabaakkiaafaaaaadacaaaeiaabaaffiaabaaaaia
aiaaaaadaaaaabiaaeaaoekaacaaoeiaaiaaaaadaaaaaciaafaaoekaacaaoeia
aiaaaaadaaaaaeiaagaaoekaacaaoeiaabaaaaacaaaiapiaaaaaoeiappppaaaa
fdeieefclaacaaaaeaaaaaaakmaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabaaaaaak
ecaabaaaabaaaaaaaceaaaaamkjemfdmogihpldnficmfidpaaaaaaaaegacbaaa
aaaaaaaabaaaaaakbcaabaaaabaaaaaaaceaaaaahbjoaddpgkndkfdoggdgcedo
aaaaaaaaegacbaaaaaaaaaaabaaaaaakccaabaaaabaaaaaaaceaaaaapolgihdo
hjjecldphbeciddnaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaaaaaaaaabaaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadp
aaaaiadpaaaaaaaaegacbaaaabaaaaaaaoaaaaahdcaabaaaaaaaaaaaegaabaaa
abaaaaaaagaabaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaabkaabaaaabaaaaaa
ckiacaaaaaaaaaaaaeaaaaaaaaaaaaaiecaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpaaaaaaaiecaabaaaaaaaaaaabkaabaiaebaaaaaa
aaaaaaaackaabaaaaaaaaaaadgaaaaafccaabaaaabaaaaaaabeaaaaaaaaaaadp
efaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaabghobaaaabaaaaaaaagabaaa
abaaaaaadiaaaaahfcaabaaaaaaaaaaaagacbaaaaaaaaaaafgafbaaaabaaaaaa
aoaaaaahfcaabaaaabaaaaaaagacbaaaaaaaaaaafgafbaaaaaaaaaaabaaaaaak
bccabaaaaaaaaaaaaceaaaaajjckceeanpepjflpenbfmmloaaaaaaaaegacbaaa
abaaaaaabaaaaaakcccabaaaaaaaaaaaaceaaaaabbmhiclpegcfpndphnnadddn
aaaaaaaaegacbaaaabaaaaaabaaaaaakeccabaaaaaaaaaaaaceaaaaaoddgjkdn
jmddiclolfdhjidpaaaaaaaaegacbaaaabaaaaaadoaaaaabejfdeheofaaaaaaa
acaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
eeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
}
 }
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
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0],
		{ 2, 0.15000001, 0.050000001, 0.0040000002 },
		{ 0.5, 0.060000002, 0.066666663, 1.3790643 },
		{ 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0.xyz, fragment.texcoord[0], texture[0], 2D;
MUL R0.xyz, R0, c[0].x;
MUL R1.xyz, R0, c[1].x;
MUL R0.xyz, R1, c[1].y;
ADD R2.xyz, R0, c[2].x;
MAD R0.xyz, R1, c[1].y, c[1].z;
MAD R2.xyz, R1, R2, c[2].y;
MAD R0.xyz, R1, R0, c[1].w;
RCP R1.x, R2.x;
RCP R1.z, R2.z;
RCP R1.y, R2.y;
MAD R0.xyz, R0, R1, -c[2].z;
MUL result.color.xyz, R0, c[2].w;
MOV result.color.w, c[3].x;
END
# 14 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 2.00000000, 0.15000001, 0.05000000, 0.00400000
def c2, 0.15000001, 0.50000000, 0.06000000, -0.06666666
def c3, 1.37906432, 1.00000000, 0, 0
dcl t0.xy
texld r0, t0, s0
mul r0.xyz, r0, c0.x
mul r0.xyz, r0, c1.x
mad r2.xyz, r0, c2.x, c2.y
mad r1.xyz, r0, c1.y, c1.z
mad r2.xyz, r0, r2, c2.z
mad r0.xyz, r0, r1, c1.w
rcp r1.x, r2.x
rcp r1.z, r2.z
rcp r1.y, r2.y
mad r0.xyz, r0, r1, c2.w
mov r0.w, c3.y
mul r0.xyz, r0, c3.x
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0
eefiecedhcncacemgoebpmcjlofbflafefmaakeiabaaaaaanaacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaacaaaa
eaaaaaaaieaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaihcaabaaa
aaaaaaaaegacbaaaaaaaaaaafgifcaaaaaaaaaaaaeaaaaaadcaaaaaphcaabaaa
abaaaaaaegacbaaaaaaaaaaaaceaaaaajkjjjjdojkjjjjdojkjjjjdoaaaaaaaa
aceaaaaamnmmemdnmnmmemdnmnmmemdnaaaaaaaaaaaaaaahhcaabaaaacaaaaaa
egacbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaphcaabaaaaaaaaaaaegacbaaa
aaaaaaaaaceaaaaajkjjjjdojkjjjjdojkjjjjdoaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaadpaaaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaaaaaaaaaaceaaaaaipmchfdnipmchfdnipmchfdnaaaaaaaadcaaaaam
hcaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaaaceaaaaagpbciddl
gpbciddlgpbciddlaaaaaaaaaoaaaaahhcaabaaaaaaaaaaaegacbaaaabaaaaaa
egacbaaaaaaaaaaaaaaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
ijiiiilnijiiiilnijiiiilnaaaaaaaadiaaaaakhccabaaaaaaaaaaaegacbaaa
aaaaaaaaaceaaaaacoifladpcoifladpcoifladpaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedebkmfopklaphaooobhdkimabcgokfpkaabaaaaaaeaaeaaaaaeaaaaaa
daaaaaaajmabaaaaleadaaaaamaeaaaaebgpgodjgeabaaaageabaaaaaaacpppp
daabaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaaeaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkajkjjjjdomnmmemdn
gpbciddlaaaaaadpfbaaaaafacaaapkaipmchfdnijiiiilncoifladpaaaaiadp
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaaapia
aaaaoelaaaaioekaafaaaaadaaaaahiaaaaaoeiaaaaaffkaaeaaaaaeabaaahia
aaaaoeiaabaaaakaabaaffkaacaaaaadacaaahiaaaaaoeiaaaaaoeiaaeaaaaae
aaaaahiaaaaaoeiaabaaaakaabaappkaaeaaaaaeaaaaahiaacaaoeiaaaaaoeia
acaaaakaaeaaaaaeabaaahiaacaaoeiaabaaoeiaabaakkkaagaaaaacacaaabia
aaaaaaiaagaaaaacacaaaciaaaaaffiaagaaaaacacaaaeiaaaaakkiaaeaaaaae
aaaaahiaabaaoeiaacaaoeiaacaaffkaafaaaaadaaaaahiaaaaaoeiaacaakkka
abaaaaacaaaaaiiaacaappkaabaaaaacaaaiapiaaaaaoeiappppaaaafdeieefc
baacaaaaeaaaaaaaieaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaad
aagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaafgifcaaaaaaaaaaaaeaaaaaadcaaaaap
hcaabaaaabaaaaaaegacbaaaaaaaaaaaaceaaaaajkjjjjdojkjjjjdojkjjjjdo
aaaaaaaaaceaaaaamnmmemdnmnmmemdnmnmmemdnaaaaaaaaaaaaaaahhcaabaaa
acaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaaphcaabaaaaaaaaaaa
egacbaaaaaaaaaaaaceaaaaajkjjjjdojkjjjjdojkjjjjdoaaaaaaaaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaaaadcaaaaamhcaabaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaaaaaaaaaaceaaaaaipmchfdnipmchfdnipmchfdnaaaaaaaa
dcaaaaamhcaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaaaceaaaaa
gpbciddlgpbciddlgpbciddlaaaaaaaaaoaaaaahhcaabaaaaaaaaaaaegacbaaa
abaaaaaaegacbaaaaaaaaaaaaaaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
aceaaaaaijiiiilnijiiiilnijiiiilnaaaaaaaadiaaaaakhccabaaaaaaaaaaa
egacbaaaaaaaaaaaaceaaaaacoifladpcoifladpcoifladpaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaabejfdeheofaaaaaaaacaaaaaa
aiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
"
}
}
 }
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
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 0.2199707, 0.70703125, 0.070983887, 1 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
DP3 R1.x, R0, c[1];
MUL R1.y, R1.x, c[0].x;
ADD R1.z, R1.y, c[1].w;
RCP R1.z, R1.z;
MUL R1.y, R1, R1.z;
RCP R1.x, R1.x;
MUL R0.xyz, R0, R1.y;
MUL result.color.xyz, R0, R1.x;
MOV result.color.w, R0;
END
# 10 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 0.21997070, 0.70703125, 0.07098389, 1.00000000
dcl t0.xy
texld r3, t0, s0
dp3_pp r0.x, r3, c1
mul r1.x, r0, c0
add r2.x, r1, c1.w
rcp r2.x, r2.x
mul r1.x, r1, r2
mul r1.xyz, r3, r1.x
rcp r0.x, r0.x
mov r0.w, r3
mul r0.xyz, r1, r0.x
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0
eefiecedgckamcggmnkcoailbmoepjbafidcjjmeabaaaaaabeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfeabaaaa
eaaaaaaaffaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabaaaaaakbcaabaaa
abaaaaaaegacbaaaaaaaaaaaaceaaaaakoehgbdopepndedphdgijbdnaaaaaaaa
diaaaaaiccaabaaaabaaaaaaakaabaaaabaaaaaabkiacaaaaaaaaaaaaeaaaaaa
dcaaaaakecaabaaaabaaaaaaakaabaaaabaaaaaabkiacaaaaaaaaaaaaeaaaaaa
abeaaaaaaaaaiadpaoaaaaahccaabaaaabaaaaaabkaabaaaabaaaaaackaabaaa
abaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaafgafbaaaabaaaaaa
dgaaaaaficcabaaaaaaaaaaadkaabaaaaaaaaaaaaoaaaaahhccabaaaaaaaaaaa
egacbaaaaaaaaaaaagaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedechipgmcenhibgkmclacijoaphfednohabaaaaaadaadaaaaaeaaaaaa
daaaaaaaeiabaaaakeacaaaapmacaaaaebgpgodjbaabaaaabaabaaaaaaacpppp
nmaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaaeaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkakoehgbdopepndedp
hdgijbdnaaaaiadpbpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapka
ecaaaaadaaaaapiaaaaaoelaaaaioekaaiaaaaadabaaciiaaaaaoeiaabaaoeka
abaaaaacacaaaiiaabaappkaaeaaaaaeabaaabiaabaappiaaaaaffkaacaappia
agaaaaacabaaabiaabaaaaiaafaaaaadabaaaciaabaappiaaaaaffkaagaaaaac
abaaaeiaabaappiaafaaaaadabaaabiaabaaaaiaabaaffiaafaaaaadacaaahia
aaaaoeiaabaaaaiaafaaaaadaaaaahiaabaakkiaacaaoeiaabaaaaacaaaiapia
aaaaoeiappppaaaafdeieefcfeabaaaaeaaaaaaaffaaaaaafjaaaaaeegiocaaa
aaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
acaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaabaaaaaakbcaabaaaabaaaaaaegacbaaaaaaaaaaaaceaaaaa
koehgbdopepndedphdgijbdnaaaaaaaadiaaaaaiccaabaaaabaaaaaaakaabaaa
abaaaaaabkiacaaaaaaaaaaaaeaaaaaadcaaaaakecaabaaaabaaaaaaakaabaaa
abaaaaaabkiacaaaaaaaaaaaaeaaaaaaabeaaaaaaaaaiadpaoaaaaahccaabaaa
abaaaaaabkaabaaaabaaaaaackaabaaaabaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaafgafbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
aaaaaaaaaoaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaaagaabaaaabaaaaaa
doaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
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
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0],
		{ 0.0040000002, 0, 6.1999998, 0.5 },
		{ 1.7, 0.059999999 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, c[0].x;
ADD R0, R0, -c[1].x;
MAX R0, R0, c[1].y;
MUL R1, R0, c[1].z;
ADD R2, R1, c[2].x;
MAD R1, R0, c[1].z, c[1].w;
MAD R2, R0, R2, c[2].y;
MUL R0, R0, R1;
RCP R1.x, R2.x;
RCP R1.y, R2.y;
RCP R1.w, R2.w;
RCP R1.z, R2.z;
MUL R0, R0, R1;
MUL result.color, R0, R0;
END
# 15 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, -0.00400000, 0.00000000, 6.19999981, 0.50000000
def c2, 6.19999981, 1.70000005, 0.06000000, 0
dcl t0.xy
texld r0, t0, s0
mul r0, r0, c0.x
add r0, r0, c1.x
max r0, r0, c1.y
mad r2, r0, c2.x, c2.y
mad r1, r0, c1.z, c1.w
mad r2, r0, r2, c2.z
mul r0, r0, r1
rcp r1.x, r2.x
rcp r1.y, r2.y
rcp r1.w, r2.w
rcp r1.z, r2.z
mul r0, r0, r1
mul r0, r0, r0
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0
eefiecedocklhpmcjocieafojifbnpmddjmljenhabaaaaaajeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcneabaaaa
eaaaaaaahfaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaanpcaabaaa
aaaaaaaaegaobaaaaaaaaaaafgifcaaaaaaaaaaaaeaaaaaaaceaaaaagpbcidll
gpbcidllgpbcidllgpbcidlldeaaaaakpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadcaaaaappcaabaaaabaaaaaa
egaobaaaaaaaaaaaaceaaaaaggggmgeaggggmgeaggggmgeaggggmgeaaceaaaaa
aaaaaadpaaaaaadpaaaaaadpaaaaaadpdiaaaaahpcaabaaaabaaaaaaegaobaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaappcaabaaaacaaaaaaegaobaaaaaaaaaaa
aceaaaaaggggmgeaggggmgeaggggmgeaggggmgeaaceaaaaajkjjnjdpjkjjnjdp
jkjjnjdpjkjjnjdpdcaaaaampcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaa
acaaaaaaaceaaaaaipmchfdnipmchfdnipmchfdnipmchfdnaoaaaaahpcaabaaa
aaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaadiaaaaahpccabaaaaaaaaaaa
egaobaaaaaaaaaaaegaobaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedcgghppkmlhiadfepgfcbnbecpgimlcbbabaaaaaaamaeaaaaaeaaaaaa
daaaaaaakeabaaaaiaadaaaaniadaaaaebgpgodjgmabaaaagmabaaaaaaacpppp
diabaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaaeaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkagpbcidllaaaaaaaa
ggggmgeaaaaaaadpfbaaaaafacaaapkaggggmgeajkjjnjdpipmchfdnaaaaaaaa
bpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaaapia
aaaaoelaaaaioekaabaaaaacabaaaiiaabaaaakaaeaaaaaeaaaaapiaaaaaoeia
aaaaffkaabaappiaalaaaaadabaaapiaaaaaoeiaabaaffkaaeaaaaaeaaaaapia
abaaoeiaabaakkkaabaappkaafaaaaadaaaaapiaaaaaoeiaabaaoeiaaeaaaaae
acaaapiaabaaoeiaacaaaakaacaaffkaaeaaaaaeabaaapiaabaaoeiaacaaoeia
acaakkkaagaaaaacacaaabiaabaaaaiaagaaaaacacaaaciaabaaffiaagaaaaac
acaaaeiaabaakkiaagaaaaacacaaaiiaabaappiaafaaaaadaaaaapiaaaaaoeia
acaaoeiaafaaaaadaaaaapiaaaaaoeiaaaaaoeiaabaaaaacaaaiapiaaaaaoeia
ppppaaaafdeieefcneabaaaaeaaaaaaahfaaaaaafjaaaaaeegiocaaaaaaaaaaa
afaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaa
efaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaanpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgifcaaaaaaaaaaa
aeaaaaaaaceaaaaagpbcidllgpbcidllgpbcidllgpbcidlldeaaaaakpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
dcaaaaappcaabaaaabaaaaaaegaobaaaaaaaaaaaaceaaaaaggggmgeaggggmgea
ggggmgeaggggmgeaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaadpdiaaaaah
pcaabaaaabaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadcaaaaappcaabaaa
acaaaaaaegaobaaaaaaaaaaaaceaaaaaggggmgeaggggmgeaggggmgeaggggmgea
aceaaaaajkjjnjdpjkjjnjdpjkjjnjdpjkjjnjdpdcaaaaampcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegaobaaaacaaaaaaaceaaaaaipmchfdnipmchfdnipmchfdn
ipmchfdnaoaaaaahpcaabaaaaaaaaaaaegaobaaaabaaaaaaegaobaaaaaaaaaaa
diaaaaahpccabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaaaaaaaaadoaaaaab
ejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
}
 }
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
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 1 } };
TEMP R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, -c[0].x;
EX2 R0.x, R0.x;
EX2 R0.y, R0.y;
EX2 R0.w, R0.w;
EX2 R0.z, R0.z;
ADD result.color, -R0, c[1].x;
END
# 7 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_ExposureAdjustment]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 1.00000000, 0, 0, 0
dcl t0.xy
texld r0, t0, s0
mul r0, r0, -c0.x
exp r0.x, r0.x
exp r0.y, r0.y
exp r0.w, r0.w
exp r0.z, r0.z
add r0, -r0, c1.x
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0
eefiecedhnfpjonnhopcidpcfdpkcajpmjbniacmabaaaaaakaabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaaaaaaa
eaaaaaaadiaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaajpcaabaaa
aaaaaaaaegaobaaaaaaaaaaafgifcaiaebaaaaaaaaaaaaaaaeaaaaaabjaaaaaf
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaaaaaaaalpccabaaaaaaaaaaaegaobaia
ebaaaaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpdoaaaaab
"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Float 68 [_ExposureAdjustment]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedpifamnnccogklkdgohonfaeefglcloplabaaaaaaieacaaaaaeaaaaaa
daaaaaaabaabaaaapiabaaaafaacaaaaebgpgodjniaaaaaaniaaaaaaaaacpppp
keaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaaeaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaiadpaaaaaaaa
aaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapka
ecaaaaadaaaaapiaaaaaoelaaaaioekaafaaaaadaaaaapiaaaaaoeiaaaaaffkb
aoaaaaacabaaabiaaaaaaaiaaoaaaaacabaaaciaaaaaffiaaoaaaaacabaaaeia
aaaakkiaaoaaaaacabaaaiiaaaaappiaacaaaaadaaaaapiaabaaoeibabaaaaka
abaaaaacaaaiapiaaaaaoeiappppaaaafdeieefcoaaaaaaaeaaaaaaadiaaaaaa
fjaaaaaeegiocaaaaaaaaaaaafaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacabaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaajpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgifcaiaebaaaaaaaaaaaaaaaeaaaaaabjaaaaafpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaaaaaaaalpccabaaaaaaaaaaaegaobaiaebaaaaaaaaaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpdoaaaaabejfdeheofaaaaaaa
acaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
eeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
}
 }
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
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 0.25, 0.5, -0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R1.xy, c[1].yzzw;
MAD R1.zw, R1.xyxy, -c[0].xyxy, fragment.texcoord[0].xyxy;
MAD R0.zw, R1.x, -c[0].xyxy, fragment.texcoord[0].xyxy;
MAD R0.xy, R1.x, c[0], fragment.texcoord[0];
MAD R1.xy, R1, c[0], fragment.texcoord[0];
TEX R3, R1.zwzw, texture[0], 2D;
TEX R2, R1, texture[0], 2D;
TEX R1, R0.zwzw, texture[0], 2D;
TEX R0, R0, texture[0], 2D;
ADD R0.xzw, R0, R1;
ADD R0.xzw, R2, R0;
ADD R0.xzw, R3, R0;
MUL result.color.xzw, R0, c[1].x;
MAX R0.z, R2.y, R3.y;
MAX R0.x, R0.y, R1.y;
MAX result.color.y, R0.x, R0.z;
END
# 16 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 0.50000000, -0.50000000, 0.25000000, 0
dcl t0.xy
mov r1.xy, c0
mad r3.xy, c1.x, r1, t0
mov r0.xy, c0
mad r2.xy, c1.x, -r0, t0
mov r0.xy, c0
mov r1.xy, c0
mad r0.xy, c1, -r0, t0
mad r1.xy, c1, r1, t0
texld r0, r0, s0
texld r1, r1, s0
texld r2, r2, s0
texld r3, r3, s0
add r2.xzw, r3, r2
add r1.xzw, r1, r2
add r0.xzw, r0, r1
mul r1.xzw, r0, c1.z
max r0.x, r1.y, r0.y
max r2.x, r3.y, r2.y
max r1.y, r2.x, r0.x
mov oC0, r1
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
BindCB  "$Globals" 0
"ps_4_0
eefiecedkhklpccpimglgphihnjdfhfgddnjcnkaabaaaaaaoeacaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcceacaaaa
eaaaaaaaijaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaanpcaabaaaaaaaaaaa
egiecaaaaaaaaaaaadaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaalp
egbebaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaopcaabaaaacaaaaaaegiecaia
ebaaaaaaaaaaaaaaadaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaalp
egbebaaaabaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahncaabaaaabaaaaaaagaobaaa
abaaaaaaagaobaaaadaaaaaadeaaaaahccaabaaaabaaaaaabkaabaaaabaaaaaa
bkaabaaaadaaaaaaaaaaaaahncaabaaaaaaaaaaaagaobaaaaaaaaaaaagaobaaa
abaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaacaaaaaa
aaaaaaahncaabaaaaaaaaaaaagaobaaaacaaaaaaagaobaaaaaaaaaaadiaaaaak
nccabaaaaaaaaaaaagaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaaaaaaaaaiado
aaaaiadodeaaaaahcccabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaaabaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 48 [_MainTex_TexelSize]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfpbbcnpcppinkjhnccihjbngjfhkhdemabaaaaaapeaeaaaaaeaaaaaa
daaaaaaadmacaaaagiaeaaaamaaeaaaaebgpgodjaeacaaaaaeacaaaaaaacpppp
naabaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaadaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkaaaaaaadpaaaaaalp
aaaaiadoaaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapka
abaaaaacaaaaadiaabaaoekaaeaaaaaeabaaadiaaaaaoekaaaaaaaiaaaaaoela
aeaaaaaeacaaadiaaaaaoekaaaaaaaibaaaaoelaaeaaaaaeadaaadiaaaaaoeka
aaaaoeiaaaaaoelaaeaaaaaeaaaaadiaaaaaoekaaaaaoeibaaaaoelaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaad
adaaapiaadaaoeiaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaacaaaaad
aeaaabiaabaaaaiaacaaaaiaacaaaaadaeaaaciaabaakkiaacaakkiaacaaaaad
aeaaaeiaabaappiaacaappiaalaaaaadaeaaaiiaabaaffiaacaaffiaacaaaaad
abaaabiaadaaaaiaaeaaaaiaacaaaaadabaaaciaadaakkiaaeaaffiaacaaaaad
abaaaeiaadaappiaaeaakkiaacaaaaadacaaabiaaaaaaaiaabaaaaiaacaaaaad
acaaaciaaaaakkiaabaaffiaacaaaaadacaaaeiaaaaappiaabaakkiaalaaaaad
acaaaiiaadaaffiaaaaaffiaalaaaaadaaaaaciaaeaappiaacaappiaafaaaaad
aaaaabiaacaaaaiaabaakkkaafaaaaadaaaaaeiaacaaffiaabaakkkaafaaaaad
aaaaaiiaacaakkiaabaakkkaabaaaaacaaaiapiaaaaaoeiappppaaaafdeieefc
ceacaaaaeaaaaaaaijaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaad
aagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaanpcaabaaa
aaaaaaaaegiecaaaaaaaaaaaadaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaalpegbebaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaaopcaabaaaacaaaaaa
egiecaiaebaaaaaaaaaaaaaaadaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaalpegbebaaaabaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaa
acaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaahncaabaaaabaaaaaa
agaobaaaabaaaaaaagaobaaaadaaaaaadeaaaaahccaabaaaabaaaaaabkaabaaa
abaaaaaabkaabaaaadaaaaaaaaaaaaahncaabaaaaaaaaaaaagaobaaaaaaaaaaa
agaobaaaabaaaaaadeaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
acaaaaaaaaaaaaahncaabaaaaaaaaaaaagaobaaaacaaaaaaagaobaaaaaaaaaaa
diaaaaaknccabaaaaaaaaaaaagaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaaaaa
aaaaiadoaaaaiadodeaaaaahcccabaaaaaaaaaaabkaabaaaaaaaaaaabkaabaaa
abaaaaaadoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
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
Vector 0 [_HdrParams]
SetTexture 0 [_SmallTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0],
		{ 1.0002404e-006, 0.2199707, 0.70703125, 0.070983887 },
		{ 0.001, 1 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[1], 2D;
TEX R1.xy, fragment.texcoord[0], texture[0], 2D;
DP3 R1.z, R0, c[1].yzww;
MAX R1.z, R1, c[1].x;
MUL R1.w, R1.z, c[0].z;
ADD R1.x, R1, c[2];
MUL R1.y, R1, R1;
RCP R1.x, R1.x;
MUL R1.x, R1.w, R1;
RCP R1.y, R1.y;
MAD R1.w, R1.x, R1.y, c[2].y;
ADD R1.y, R1.x, c[2];
MUL R1.x, R1, R1.w;
RCP R1.y, R1.y;
RCP R1.z, R1.z;
MUL R1.x, R1, R1.y;
MUL R1.x, R1, R1.z;
MUL result.color.xyz, R0, R1.x;
MOV result.color.w, R0;
END
# 19 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_HdrParams]
SetTexture 0 [_SmallTex] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c1, 0.21997070, 0.70703125, 0.07098389, 0.00000100
def c2, 0.00100000, 1.00000000, 0, 0
dcl t0.xy
texld r2, t0, s0
texld r3, t0, s1
mul r0.x, r2.y, r2.y
rcp r1.x, r0.x
add r2.x, r2, c2
dp3_pp r0.x, r3, c1
rcp r4.x, r2.x
max_pp r0.x, r0, c1.w
mul r2.x, r0, c0.z
mul r2.x, r2, r4
mad r4.x, r2, r1, c2.y
add r1.x, r2, c2.y
mul r2.x, r2, r4
rcp r1.x, r1.x
rcp r0.x, r0.x
mul r1.x, r2, r1
mul r0.x, r1, r0
mov r0.w, r3
mul r0.xyz, r3, r0.x
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_SmallTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_HdrParams]
BindCB  "$Globals" 0
"ps_4_0
eefiecedljomehfoinndjifhakhopaclpdbbjgglabaaaaaaamadaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcemacaaaa
eaaaaaaajdaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaagpbciddkefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaabaaaaaakecaabaaaaaaaaaaaegacbaaa
abaaaaaaaceaaaaakoehgbdopepndedphdgijbdnaaaaaaaadeaaaaahecaabaaa
aaaaaaaackaabaaaaaaaaaaaabeaaaaalndhigdfdiaaaaaiicaabaaaaaaaaaaa
ckaabaaaaaaaaaaackiacaaaaaaaaaaaabaaaaaaaoaaaaahbcaabaaaaaaaaaaa
dkaabaaaaaaaaaaaakaabaaaaaaaaaaaaoaaaaahccaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaaaaaaiadpdiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadp
aoaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaaoaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaadiaaaaahhccabaaa
aaaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_SmallTex] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_HdrParams]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfcjdaaffniaijalgfengaapacfajlfmgabaaaaaanaaeaaaaaeaaaaaa
daaaaaaapaabaaaaeeaeaaaajmaeaaaaebgpgodjliabaaaaliabaaaaaaacpppp
iaabaaaadiaaaaaaabaacmaaaaaadiaaaaaadiaaacaaceaaaaaadiaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaacppppfbaaaaafabaaapkakoehgbdo
pepndedphdgijbdnlndhigdffbaaaaafacaaapkagpbciddkaaaaiadpaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaaadlabpaaaaacaaaaaajaaaaiapkabpaaaaac
aaaaaajaabaiapkaecaaaaadaaaaapiaaaaaoelaabaioekaecaaaaadabaaapia
aaaaoelaaaaioekaafaaaaadaaaaaciaaaaaffiaaaaaffiaacaaaaadaaaaabia
aaaaaaiaacaaaakaagaaaaacaaaaabiaaaaaaaiaagaaaaacaaaaaciaaaaaffia
aiaaaaadaaaaceiaabaaoeiaabaaoekaalaaaaadacaaaiiaabaappkaaaaakkia
afaaaaadaaaaaeiaacaappiaaaaakkkaagaaaaacaaaaaiiaacaappiaafaaaaad
acaaabiaaaaaaaiaaaaakkiaaeaaaaaeaaaaabiaaaaakkiaaaaaaaiaacaaffka
agaaaaacaaaaabiaaaaaaaiaaeaaaaaeaaaaaciaacaaaaiaaaaaffiaacaaffka
afaaaaadaaaaaciaaaaaffiaacaaaaiaafaaaaadaaaaabiaaaaaaaiaaaaaffia
afaaaaadaaaaabiaaaaappiaaaaaaaiaafaaaaadabaaahiaaaaaaaiaabaaoeia
abaaaaacaaaiapiaabaaoeiappppaaaafdeieefcemacaaaaeaaaaaaajdaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
gpbciddkefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaabaaaaaakecaabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaa
koehgbdopepndedphdgijbdnaaaaaaaadeaaaaahecaabaaaaaaaaaaackaabaaa
aaaaaaaaabeaaaaalndhigdfdiaaaaaiicaabaaaaaaaaaaackaabaaaaaaaaaaa
ckiacaaaaaaaaaaaabaaaaaaaoaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaa
akaabaaaaaaaaaaaaoaaaaahccaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaa
aaaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiadp
diaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpaoaaaaahbcaabaaa
aaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaaoaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaackaabaaaaaaaaaaadiaaaaahhccabaaaaaaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
doaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback Off
}