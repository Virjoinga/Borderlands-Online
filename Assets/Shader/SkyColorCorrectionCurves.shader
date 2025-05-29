àrShader "Hidden/SkyColorCorrectionCurves" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "" {}
 _RgbTex ("_RgbTex (RGB)", 2D) = "" {}
 _ZCurve ("_ZCurve (RGB)", 2D) = "" {}
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
Vector 5 [_CameraDepthTexture_ST]
"!!ARBvp1.0
PARAM c[6] = { program.local[0],
		state.matrix.mvp,
		program.local[5] };
MOV result.texcoord[0].xy, vertex.texcoord[0];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[5], c[5].zwzw;
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
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_CameraDepthTexture_ST]
Vector 5 [_MainTex_TexelSize]
"vs_2_0
def c6, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.x, c6
slt r0.x, c5.y, r0
max r0.x, -r0, r0
slt r0.z, c6.x, r0.x
mad r0.xy, v1, c4, c4.zwzw
add r0.w, -r0.z, c6.y
mul r0.w, r0.y, r0
add r0.y, -r0, c6
mad oT1.y, r0.z, r0, r0.w
mov oT0.xy, v1
mov oT1.x, r0
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
Vector 16 [_CameraDepthTexture_ST]
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedjogjjeapifcokefllgkicklkandbflknabaaaaaalmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcmeabaaaaeaaaabaahbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
dcaaaaalgcaabaaaaaaaaaaaagbbbaaaabaaaaaaagibcaaaaaaaaaaaabaaaaaa
kgilcaaaaaaaaaaaabaaaaaaaaaaaaaiicaabaaaaaaaaaaackaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpdhaaaaajiccabaaaabaaaaaaakaabaaaaaaaaaaa
dkaabaaaaaaaaaaackaabaaaaaaaaaaadgaaaaafeccabaaaabaaaaaabkaabaaa
aaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_CameraDepthTexture_ST]
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedjjmgglcghhinfgbfkioalfofpejahimdabaaaaaabmaeaaaaaeaaaaaa
daaaaaaaimabaaaafiadaaaakmadaaaaebgpgodjfeabaaaafeabaaaaaaacpopp
beabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaabaa
acaaabaaaaaaaaaaabaaaaaaaeaaadaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaaf
ahaaapkaaaaaaaaaaaaaaamaaaaaiadpaaaaaaaabpaaaaacafaaaaiaaaaaapja
bpaaaaacafaaabiaabaaapjaabaaaaacaaaaabiaahaaaakaamaaaaadaaaaabia
acaaffkaaaaaaaiaaeaaaaaeaaaaagiaabaanajaabaanakaabaapikaaeaaaaae
aaaaaiiaaaaakkiaahaaffkaahaakkkaaeaaaaaeaaaaaeoaaaaaaaiaaaaappia
aaaakkiaabaaaaacaaaaaioaaaaaffiaafaaaaadaaaaapiaaaaaffjaaeaaoeka
aeaaaaaeaaaaapiaadaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaafaaoeka
aaaakkjaaaaaoeiaaeaaaaaeaaaaapiaagaaoekaaaaappjaaaaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
aaaaadoaabaaoejappppaaaafdeieefcmeabaaaaeaaaabaahbaaaaaafjaaaaae
egiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadbaaaaai
bcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaadcaaaaal
gcaabaaaaaaaaaaaagbbbaaaabaaaaaaagibcaaaaaaaaaaaabaaaaaakgilcaaa
aaaaaaaaabaaaaaaaaaaaaaiicaabaaaaaaaaaaackaabaiaebaaaaaaaaaaaaaa
abeaaaaaaaaaiadpdhaaaaajiccabaaaabaaaaaaakaabaaaaaaaaaaadkaabaaa
aaaaaaaackaabaaaaaaaaaaadgaaaaafeccabaaaabaaaaaabkaabaaaaaaaaaaa
dgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaadoaaaaabejfdeheoemaaaaaa
acaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
ebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafaepfdejfeejepeo
aafeeffiedepepfceeaaklklepfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_ZBufferParams]
Float 1 [_Saturation]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
SetTexture 2 [_ZCurve] 2D 2
SetTexture 3 [_RgbTex] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..1],
		{ 0.5, 0.89990234, 0, 0.125 },
		{ 1, 0, 0.375, 0.625 },
		{ 0.2199707, 0.70703125, 0.070983887 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R1, fragment.texcoord[0], texture[0], 2D;
TEX R0.x, fragment.texcoord[1], texture[1], 2D;
MAD R0.x, R0, c[0], c[0].y;
MOV R0.z, R1;
MOV R0.w, c[3];
MOV R0.y, c[2].x;
RCP R0.x, R0.x;
MOV R3.x, R1.y;
MOV R3.y, c[3].z;
MOV R2.x, R1;
MOV R2.y, c[2].w;
MOV result.color.w, R1;
TEX R4.xyz, R0.zwzw, texture[3], 2D;
TEX R0.x, R0, texture[2], 2D;
TEX R2.xyz, R2, texture[3], 2D;
TEX R3.xyz, R3, texture[3], 2D;
ADD R0.y, R0.x, -c[2];
MUL R4.xyz, R4, c[3].yyxw;
MUL R3.xyz, R3, c[3].yxyw;
MUL R2.xyz, R2, c[3].xyyw;
ADD R2.xyz, R2, R3;
ADD R2.xyz, R2, R4;
ADD R2.xyz, R2, -R1;
CMP R0.x, R0.y, c[2].z, R0;
MAD R0.xyz, R0.x, R2, R1;
DP3 R0.w, R0, c[4];
ADD R0.xyz, R0, -R0.w;
MAD result.color.xyz, R0, c[1].x, R0.w;
END
# 28 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_ZBufferParams]
Float 1 [_Saturation]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
SetTexture 2 [_ZCurve] 2D 2
SetTexture 3 [_RgbTex] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c2, 0.50000000, -0.89990234, 0.00000000, 0.12500000
def c3, 1.00000000, 0.00000000, 0.37500000, 0.62500000
def c4, 0.21997070, 0.70703125, 0.07098389, 0
dcl t0.xy
dcl t1.xy
texld r0, t1, s1
texld r1, t0, s0
mad r0.x, r0, c0, c0.y
mov_pp r4.x, r1.z
mov_pp r3.x, r1
mov_pp r3.y, c2.w
mov_pp r2.x, r1.y
mov_pp r2.y, c3.z
rcp r0.x, r0.x
mov_pp r0.y, c2.x
mov_pp r4.y, c3.w
texld r5, r0, s2
texld r0, r4, s3
texld r2, r2, s3
texld r3, r3, s3
mov r4.y, c3.x
mov r4.xz, c3.y
mul r4.xyz, r2, r4
mov r2.yz, c3.y
mov r2.x, c3
mul r2.xyz, r3, r2
add_pp r3.xyz, r2, r4
mov r2.z, c3.x
mov r2.xy, c3.y
mul r0.xyz, r0, r2
add_pp r2.xyz, r3, r0
add_pp r0.x, r5, c2.y
cmp_pp r0.x, r0, r5, c2.z
add_pp r2.xyz, r2, -r1
mad_pp r1.xyz, r0.x, r2, r1
dp3_pp r0.x, r1, c4
add_pp r1.xyz, r1, -r0.x
mov_pp r0.w, r1
mad_pp r0.xyz, r1, c1.x, r0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
SetTexture 2 [_ZCurve] 2D 3
SetTexture 3 [_RgbTex] 2D 2
ConstBuffer "$Globals" 64
Float 48 [_Saturation]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedgdiiigcmjnohpleacphhdeegggafhdfbabaaaaaameaeaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcomadaaaaeaaaaaaaplaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaad
mcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
dcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaa
bkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaadgaaaaaikcaabaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaadpaaaaaaaaaaaaaadoefaaaaajpcaabaaaabaaaaaa
egaabaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaadaaaaaadbaaaaahbcaabaaa
aaaaaaaaakaabaaaabaaaaaaabeaaaaaggggggdpdhaaaaajbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaaaaaakaabaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaaf
ecaabaaaaaaaaaaaakaabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaa
aaaaaaaaeghobaaaadaaaaaaaagabaaaacaaaaaadgaaaaaikcaabaaaadaaaaaa
aceaaaaaaaaaaaaaaaaamadoaaaaaaaaaaaacadpdgaaaaaffcaabaaaadaaaaaa
fgagbaaaabaaaaaaefaaaaajpcaabaaaaeaaaaaaegaabaaaadaaaaaaeghobaaa
adaaaaaaaagabaaaacaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaaadaaaaaa
eghobaaaadaaaaaaaagabaaaacaaaaaadiaaaaakocaabaaaaaaaaaaaagajbaaa
aeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaiadpaaaaaaaadcaaaaamocaabaaa
aaaaaaaaagajbaaaacaaaaaaaceaaaaaaaaaaaaaaaaaiadpaaaaaaaaaaaaaaaa
fgaobaaaaaaaaaaadcaaaaamocaabaaaaaaaaaaaagajbaaaadaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpfgaobaaaaaaaaaaaaaaaaaaiocaabaaa
aaaaaaaaagajbaiaebaaaaaaabaaaaaafgaobaaaaaaaaaaadcaaaaajhcaabaaa
aaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaabaaaaaakicaabaaaaaaaaaaaegacbaaa
aaaaaaaaaceaaaaakoehgbdopepndedphdgijbdnaaaaaaaaaaaaaaaihcaabaaa
aaaaaaaapgapbaiaebaaaaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaa
aaaaaaaaagiacaaaaaaaaaaaadaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
SetTexture 2 [_ZCurve] 2D 3
SetTexture 3 [_RgbTex] 2D 2
ConstBuffer "$Globals" 64
Float 48 [_Saturation]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedgocohafjlkgknaabckajcfaclbpakedeabaaaaaafiahaaaaaeaaaaaa
daaaaaaamaacaaaaleagaaaaceahaaaaebgpgodjiiacaaaaiiacaaaaaaacpppp
dmacaaaaemaaaaaaacaadeaaaaaaemaaaaaaemaaaeaaceaaaaaaemaaaaaaaaaa
abababaaadacacaaacadadaaaaaaadaaabaaaaaaaaaaaaaaabaaahaaabaaabaa
aaaaaaaaaaacppppfbaaaaafacaaapkaaaaaaadpgggggglpaaaaaaaaaaaaaado
fbaaaaafadaaapkaaaaamadoaaaaaaaaaaaaiadpaaaaaaaafbaaaaafaeaaapka
aaaacadpaaaaaaaaaaaaaaaaaaaaiadpfbaaaaafafaaapkakoehgbdopepndedp
hdgijbdnaaaaaaaafbaaaaafagaaapkaaaaaaaaaaaaaaaaaaaaaiadpaaaaaaaa
bpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaaja
abaiapkabpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkaabaaaaac
aaaaadiaaaaabllaecaaaaadaaaacpiaaaaaoeiaabaioekaecaaaaadabaacpia
aaaaoelaaaaioekaaeaaaaaeaaaaabiaabaaaakaaaaaaaiaabaaffkaagaaaaac
aaaacbiaaaaaaaiaabaaaaacaaaacciaacaaaakaabaaaaacacaacciaadaaaaka
abaaaaacacaacbiaabaaffiaabaaaaacadaacciaacaappkaabaaaaacadaacbia
abaaaaiaabaaaaacaeaacciaaeaaaakaabaaaaacaeaacbiaabaakkiaecaaaaad
aaaacpiaaaaaoeiaadaioekaecaaaaadacaaapiaacaaoeiaacaioekaecaaaaad
adaaapiaadaaoeiaacaioekaecaaaaadaeaaapiaaeaaoeiaacaioekaacaaaaad
acaaaiiaaaaaaaiaacaaffkafiaaaaaeacaaciiaacaappiaaaaaaaiaacaakkka
afaaaaadaaaachiaacaaoeiaadaablkaaeaaaaaeaaaachiaadaaoeiaaeaablka
aaaaoeiaaeaaaaaeaaaachiaaeaaoeiaagaaoekaaaaaoeiabcaaaaaeadaachia
acaappiaaaaaoeiaabaaoeiaaiaaaaadadaaciiaadaaoeiaafaaoekabcaaaaae
abaachiaaaaaaakaadaaoeiaadaappiaabaaaaacaaaicpiaabaaoeiappppaaaa
fdeieefcomadaaaaeaaaaaaaplaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaa
fjaaaaaeegiocaaaabaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaaadaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
fibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaaffffaaaa
gcbaaaaddcbabaaaabaaaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacafaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaaakiacaaa
abaaaaaaahaaaaaaakaabaaaaaaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaak
bcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaa
aaaaaaaadgaaaaaikcaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaadpaaaaaaaa
aaaaaadoefaaaaajpcaabaaaabaaaaaaegaabaaaaaaaaaaaeghobaaaacaaaaaa
aagabaaaadaaaaaadbaaaaahbcaabaaaaaaaaaaaakaabaaaabaaaaaaabeaaaaa
ggggggdpdhaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaaa
akaabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadgaaaaafecaabaaaaaaaaaaaakaabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaaaaaaaaaeghobaaaadaaaaaaaagabaaa
acaaaaaadgaaaaaikcaabaaaadaaaaaaaceaaaaaaaaaaaaaaaaamadoaaaaaaaa
aaaacadpdgaaaaaffcaabaaaadaaaaaafgagbaaaabaaaaaaefaaaaajpcaabaaa
aeaaaaaaegaabaaaadaaaaaaeghobaaaadaaaaaaaagabaaaacaaaaaaefaaaaaj
pcaabaaaadaaaaaaogakbaaaadaaaaaaeghobaaaadaaaaaaaagabaaaacaaaaaa
diaaaaakocaabaaaaaaaaaaaagajbaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaiadpaaaaaaaadcaaaaamocaabaaaaaaaaaaaagajbaaaacaaaaaaaceaaaaa
aaaaaaaaaaaaiadpaaaaaaaaaaaaaaaafgaobaaaaaaaaaaadcaaaaamocaabaaa
aaaaaaaaagajbaaaadaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadp
fgaobaaaaaaaaaaaaaaaaaaiocaabaaaaaaaaaaaagajbaiaebaaaaaaabaaaaaa
fgaobaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaagaabaaaaaaaaaaajgahbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
baaaaaakicaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaakoehgbdopepndedp
hdgijbdnaaaaaaaaaaaaaaaihcaabaaaaaaaaaaapgapbaiaebaaaaaaaaaaaaaa
egacbaaaaaaaaaaadcaaaaakhccabaaaaaaaaaaaagiacaaaaaaaaaaaadaaaaaa
egacbaaaaaaaaaaapgapbaaaaaaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaabaaaaaaamamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
Fallback Off
}