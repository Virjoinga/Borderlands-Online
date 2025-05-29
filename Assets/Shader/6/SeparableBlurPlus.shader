…oShader "Hidden/SeparableBlurPlus" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "" {}
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
Vector 5 [offsets]
"!!ARBvp1.0
PARAM c[7] = { { 2, -2, 3, -3 },
		state.matrix.mvp,
		program.local[5],
		{ 6.5, -6.5, 1, -1 } };
TEMP R0;
TEMP R1;
MOV R1, c[6];
MOV R0, c[0];
MAD result.texcoord[1], R1.zzww, c[5].xyxy, vertex.texcoord[0].xyxy;
MAD result.texcoord[2], R0.xxyy, c[5].xyxy, vertex.texcoord[0].xyxy;
MAD result.texcoord[3], R0.zzww, c[5].xyxy, vertex.texcoord[0].xyxy;
MAD result.texcoord[4], R1.xxyy, c[5].xyxy, vertex.texcoord[0].xyxy;
MOV result.texcoord[0].xy, vertex.texcoord[0];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [offsets]
"vs_2_0
def c5, 1.00000000, -1.00000000, 2.00000000, -2.00000000
def c6, 3.00000000, -3.00000000, 6.50000000, -6.50000000
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, c4
mov r0.zw, c4.xyxy
mad oT1, c5.xxyy, r0.xyxy, v1.xyxy
mad oT2, c5.zzww, r0.zwzw, v1.xyxy
mov r0.xy, c4
mov r0.zw, c4.xyxy
mad oT3, c6.xxyy, r0.xyxy, v1.xyxy
mad oT4, c6.zzww, r0.zwzw, v1.xyxy
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
ConstBuffer "$Globals" 32
Vector 16 [offsets]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedcnjpmmpimgiojencmeodocaggkdlegfiabaaaaaafeadaaaaadaaaaaa
cmaaaaaaiaaaaaaadiabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
keaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaakeaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefcbeacaaaa
eaaaabaaifaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaad
pccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaa
gfaaaaadpccabaaaafaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaaabaaaaaa
dcaaaaanpccabaaaacaaaaaaegiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaialpaaaaialpegbebaaaabaaaaaadcaaaaanpccabaaaadaaaaaa
egiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaamaaaaaaama
egbebaaaabaaaaaadcaaaaanpccabaaaaeaaaaaaegiecaaaaaaaaaaaabaaaaaa
aceaaaaaaaaaeaeaaaaaeaeaaaaaeamaaaaaeamaegbebaaaabaaaaaadcaaaaan
pccabaaaafaaaaaaegiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaanaeaaaaanaea
aaaanamaaaaanamaegbebaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 32
Vector 16 [offsets]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedbnlbhggefcndepmfbgofcmnbcijceeflabaaaaaameaeaaaaaeaaaaaa
daaaaaaajmabaaaaliadaaaaamaeaaaaebgpgodjgeabaaaageabaaaaaaacpopp
ceabaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaabaa
abaaabaaaaaaaaaaabaaaaaaaeaaacaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaaf
agaaapkaaaaaiadpaaaaialpaaaaaaeaaaaaaamafbaaaaafahaaapkaaaaaeaea
aaaaeamaaaaanaeaaaaanamabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabia
abaaapjaabaaaaacaaaaadiaabaaoekaaeaaaaaeabaaapoaaaaaeeiaagaafaka
abaaeejaaeaaaaaeacaaapoaaaaaeeiaagaapkkaabaaeejaaeaaaaaeadaaapoa
aaaaeeiaahaafakaabaaeejaaeaaaaaeaeaaapoaaaaaeeiaahaapkkaabaaeeja
afaaaaadaaaaapiaaaaaffjaadaaoekaaeaaaaaeaaaaapiaacaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaaeaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
afaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacaaaaadoaabaaoejappppaaaafdeieefc
beacaaaaeaaaabaaifaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaae
egiocaaaabaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaa
abaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaa
gfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaa
abaaaaaadcaaaaanpccabaaaacaaaaaaegiecaaaaaaaaaaaabaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaialpaaaaialpegbebaaaabaaaaaadcaaaaanpccabaaa
adaaaaaaegiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaama
aaaaaamaegbebaaaabaaaaaadcaaaaanpccabaaaaeaaaaaaegiecaaaaaaaaaaa
abaaaaaaaceaaaaaaaaaeaeaaaaaeaeaaaaaeamaaaaaeamaegbebaaaabaaaaaa
dcaaaaanpccabaaaafaaaaaaegiecaaaaaaaaaaaabaaaaaaaceaaaaaaaaanaea
aaaanaeaaaaanamaaaaanamaegbebaaaabaaaaaadoaaaaabejfdeheoemaaaaaa
acaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
ebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaafaepfdejfeejepeo
aafeeffiedepepfceeaaklklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadamaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apaaaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { { 0.22499999, 0.15000001, 0.11, 0.075000003 },
		{ 0.052499998 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R2, fragment.texcoord[1].zwzw, texture[0], 2D;
TEX R1, fragment.texcoord[1], texture[0], 2D;
TEX R8, fragment.texcoord[4].zwzw, texture[0], 2D;
TEX R7, fragment.texcoord[4], texture[0], 2D;
TEX R6, fragment.texcoord[3].zwzw, texture[0], 2D;
TEX R5, fragment.texcoord[3], texture[0], 2D;
TEX R4, fragment.texcoord[2].zwzw, texture[0], 2D;
TEX R3, fragment.texcoord[2], texture[0], 2D;
MUL R2, R2, c[0].y;
MUL R1, R1, c[0].y;
MUL R0, R0, c[0].x;
ADD R0, R0, R1;
ADD R0, R0, R2;
MUL R1, R3, c[0].z;
ADD R0, R0, R1;
MUL R2, R4, c[0].z;
ADD R0, R0, R2;
MUL R1, R5, c[0].w;
ADD R0, R0, R1;
MUL R2, R6, c[0].w;
ADD R0, R0, R2;
MUL R1, R7, c[1].x;
MUL R2, R8, c[1].x;
ADD R0, R0, R1;
ADD result.color, R0, R2;
END
# 26 instructions, 9 R-regs
"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c0, 0.22499999, 0.15000001, 0.11000000, 0.07500000
def c1, 0.05250000, 0, 0, 0
dcl t0.xy
dcl t1
dcl t2
dcl t3
dcl t4
texld r3, t3, s0
texld r5, t2, s0
texld r8, t0, s0
texld r7, t1, s0
mov r0.y, t1.w
mov r0.x, t1.z
mov r6.xy, r0
mov r0.y, t2.w
mov r0.x, t2.z
mov r4.xy, r0
mov r1.y, t3.w
mov r1.x, t3.z
mov r2.xy, r1
mov r0.y, t4.w
mov r0.x, t4.z
mul r7, r7, c0.y
mul r8, r8, c0.x
add_pp r7, r8, r7
mul r5, r5, c0.z
mul r3, r3, c0.w
texld r0, r0, s0
texld r1, t4, s0
texld r2, r2, s0
texld r4, r4, s0
texld r6, r6, s0
mul r6, r6, c0.y
add_pp r6, r7, r6
mul r4, r4, c0.z
add_pp r5, r6, r5
add_pp r4, r5, r4
mul r2, r2, c0.w
add_pp r3, r4, r3
add_pp r2, r3, r2
mul r1, r1, c1.x
mul r0, r0, c1.x
add_pp r1, r2, r1
add_pp r0, r1, r0
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedecmjibdhflelpoecehbijkkkbkkaigeeabaaaaaaieaeaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgeadaaaa
eaaaaaaanjaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaaddcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaagcbaaaad
pcbabaaaadaaaaaagcbaaaadpcbabaaaaeaaaaaagcbaaaadpcbabaaaafaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaa
egbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaakpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaaceaaaaajkjjbjdojkjjbjdojkjjbjdojkjjbjdo
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaaggggggdo
ggggggdoggggggdoggggggdoegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaampcaabaaa
aaaaaaaaegaobaaaabaaaaaaaceaaaaajkjjbjdojkjjbjdojkjjbjdojkjjbjdo
egaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaadaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaabaaaaaa
aceaaaaakoehobdnkoehobdnkoehobdnkoehobdnegaobaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaampcaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaakoehobdnkoehobdn
koehobdnkoehobdnegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
aeaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaampcaabaaaaaaaaaaa
egaobaaaabaaaaaaaceaaaaajkjjjjdnjkjjjjdnjkjjjjdnjkjjjjdnegaobaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaaeaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaa
jkjjjjdnjkjjjjdnjkjjjjdnjkjjjjdnegaobaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaafaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaam
pcaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaadnakfhdndnakfhdndnakfhdn
dnakfhdnegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaafaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaampccabaaaaaaaaaaaegaobaaa
abaaaaaaaceaaaaadnakfhdndnakfhdndnakfhdndnakfhdnegaobaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0_level_9_1
eefiecedhdfdagfdfgfgakfjfigdmopfpgbgmpgoabaaaaaaoeagaaaaaeaaaaaa
daaaaaaaimacaaaapiafaaaalaagaaaaebgpgodjfeacaaaafeacaaaaaaacpppp
cmacaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppfbaaaaafaaaaapkadnakfhdnaaaaaaaaaaaaaaaaaaaaaaaafbaaaaaf
abaaapkajkjjbjdoggggggdokoehobdnjkjjjjdnbpaaaaacaaaaaaiaaaaacdla
bpaaaaacaaaaaaiaabaacplabpaaaaacaaaaaaiaacaacplabpaaaaacaaaaaaia
adaacplabpaaaaacaaaaaaiaaeaacplabpaaaaacaaaaaajaaaaiapkaabaaaaac
aaaacbiaabaakklaabaaaaacaaaacciaabaapplaabaaaaacabaacbiaacaakkla
abaaaaacabaacciaacaapplaabaaaaacacaacbiaadaakklaabaaaaacacaaccia
adaapplaabaaaaacadaacbiaaeaakklaabaaaaacadaacciaaeaapplaecaaaaad
aeaaapiaabaaoelaaaaioekaecaaaaadafaaapiaaaaaoelaaaaioekaecaaaaad
aaaaapiaaaaaoeiaaaaioekaecaaaaadagaaapiaacaaoelaaaaioekaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadahaaapiaadaaoelaaaaioekaecaaaaad
acaaapiaacaaoeiaaaaioekaecaaaaadaiaaapiaaeaaoelaaaaioekaecaaaaad
adaaapiaadaaoeiaaaaioekaafaaaaadaeaaapiaaeaaoeiaabaaaakaaeaaaaae
aeaacpiaafaaoeiaabaaffkaaeaaoeiaaeaaaaaeaaaacpiaaaaaoeiaabaaaaka
aeaaoeiaaeaaaaaeaaaacpiaagaaoeiaabaakkkaaaaaoeiaaeaaaaaeaaaacpia
abaaoeiaabaakkkaaaaaoeiaaeaaaaaeaaaacpiaahaaoeiaabaappkaaaaaoeia
aeaaaaaeaaaacpiaacaaoeiaabaappkaaaaaoeiaaeaaaaaeaaaacpiaaiaaoeia
aaaaaakaaaaaoeiaaeaaaaaeaaaacpiaadaaoeiaaaaaaakaaaaaoeiaabaaaaac
aaaicpiaaaaaoeiappppaaaafdeieefcgeadaaaaeaaaaaaanjaaaaaafkaaaaad
aagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadpcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaad
pcbabaaaaeaaaaaagcbaaaadpcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaakpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
aceaaaaajkjjbjdojkjjbjdojkjjbjdojkjjbjdoefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaampcaabaaa
aaaaaaaaegaobaaaabaaaaaaaceaaaaaggggggdoggggggdoggggggdoggggggdo
egaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaabaaaaaa
aceaaaaajkjjbjdojkjjbjdojkjjbjdojkjjbjdoegaobaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaampcaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaakoehobdnkoehobdn
koehobdnkoehobdnegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
adaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaampcaabaaaaaaaaaaa
egaobaaaabaaaaaaaceaaaaakoehobdnkoehobdnkoehobdnkoehobdnegaobaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaaeaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaa
jkjjjjdnjkjjjjdnjkjjjjdnjkjjjjdnegaobaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaaeaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaam
pcaabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaajkjjjjdnjkjjjjdnjkjjjjdn
jkjjjjdnegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaafaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaampcaabaaaaaaaaaaaegaobaaa
abaaaaaaaceaaaaadnakfhdndnakfhdndnakfhdndnakfhdnegaobaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaogbkbaaaafaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadcaaaaampccabaaaaaaaaaaaegaobaaaabaaaaaaaceaaaaadnakfhdn
dnakfhdndnakfhdndnakfhdnegaobaaaaaaaaaaadoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaapapaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaapapaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapapaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
}
 }
}
Fallback Off
}