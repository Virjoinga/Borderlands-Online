‡EShader "Custom/FX/BumpDistort" {
Properties {
 _BumpAmt ("Distortion", Range(0,10)) = 2
}
SubShader { 
 Tags { "QUEUE"="Transparent" "RenderType"="Opaque" }
 GrabPass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" }
 }
 Pass {
  Name "BASE"
  Tags { "LIGHTMODE"="Always" "QUEUE"="Transparent" "RenderType"="Opaque" }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
"!!ARBvp1.0
PARAM c[5] = { { 0.5 },
		state.matrix.mvp };
TEMP R0;
TEMP R1;
DP4 R0.w, vertex.position, c[2];
DP4 R0.z, vertex.position, c[4];
DP4 R0.x, vertex.position, c[1];
MOV R1.w, R0.z;
DP4 R1.z, vertex.position, c[3];
MOV R1.x, R0;
MOV R0.y, R0.w;
MOV R1.y, R0.w;
ADD R0.xy, R0.z, R0;
MOV result.position, R1;
MOV result.texcoord[0].zw, R1;
MUL result.texcoord[0].xy, R0, c[0].x;
MOV result.texcoord[1].xyz, vertex.normal;
END
# 13 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Matrix 0 [glstate_matrix_mvp]
"vs_2_0
def c4, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_normal0 v1
dp4 r0.w, v0, c1
dp4 r0.z, v0, c3
dp4 r0.x, v0, c0
mov r1.w, r0.z
dp4 r1.z, v0, c2
mov r1.x, r0
mov r0.y, -r0.w
mov r1.y, r0.w
add r0.xy, r0.z, r0
mov oPos, r1
mov oT0.zw, r1
mul oT0.xy, r0, c4.x
mov oT1.xyz, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "normal" Normal
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0
eefiecedakdklemmgpljblhihdolnamhglfbheidabaaaaaaieacaaaaadaaaaaa
cmaaaaaahmaaaaaaomaaaaaaejfdeheoeiaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaahahaaaafaepfdejfeejepeoaaeoepfcenebemaaepfdeheo
giaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaafmaaaaaa
abaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaa
feeffiedepepfceeaaklklklfdeieefcjaabaaaaeaaaabaageaaaaaafjaaaaae
egiocaaaaaaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
abaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaamdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaialp
aaaaaaaaaaaaaaaapgapbaaaaaaaaaaadgaaaaafmccabaaaabaaaaaakgaobaaa
aaaaaaaadiaaaaakdccabaaaabaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaaaaaaaaaaaadgaaaaafhccabaaaacaaaaaaegbcbaaaabaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
Bind "normal" Normal
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "UnityPerDraw" 0
"vs_4_0_level_9_1
eefiecedibchfochidfanknedhljajjffabnfghdabaaaaaakeadaaaaaeaaaaaa
daaaaaaaemabaaaaoeacaaaadeadaaaaebgpgodjbeabaaaabeabaaaaaaacpopp
oaaaaaaadeaaaaaaabaaceaaaaaadaaaaaaadaaaaaaaceaaabaadaaaaaaaaaaa
aeaaabaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafafaaapkaaaaaiadpaaaaialp
aaaaaadpaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapiaabaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapia
aeaaoekaaaaappjaaaaaoeiaaeaaaaaeabaaadiaaaaaoeiaafaaoekaaaaappia
afaaaaadaaaaadoaabaaoeiaafaakkkaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacaaaaamoaaaaaoeiaabaaaaac
abaaahoaabaaoejappppaaaafdeieefcjaabaaaaeaaaabaageaaaaaafjaaaaae
egiocaaaaaaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadhcbabaaa
abaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadhccabaaaacaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaamdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaialp
aaaaaaaaaaaaaaaapgapbaaaaaaaaaaadgaaaaafmccabaaaabaaaaaakgaobaaa
aaaaaaaadiaaaaakdccabaaaabaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaaaaaaaaaaaadgaaaaafhccabaaaacaaaaaaegbcbaaaabaaaaaa
doaaaaabejfdeheoeiaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
ahahaaaafaepfdejfeejepeoaaeoepfcenebemaaepfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_BumpAmt]
Vector 1 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0..1],
		{ 1, 2 } };
TEMP R0;
MOV R0.y, c[2].x;
MOV R0.x, fragment.texcoord[1].y;
MAD R0.xy, R0.yxzw, c[2].y, -c[2].x;
MUL R0.xy, R0, c[0].x;
MUL R0.xy, R0, c[1];
MOV R0.z, fragment.texcoord[0].w;
MAD R0.xy, R0, fragment.texcoord[0].z, fragment.texcoord[0];
TXP result.color, R0.xyzz, texture[0], 2D;
END
# 8 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_BumpAmt]
Vector 1 [_GrabTexture_TexelSize]
SetTexture 0 [_GrabTexture] 2D 0
"ps_2_0
dcl_2d s0
def c2, 1.00000000, 2.00000000, -1.00000000, 0
dcl t0
dcl t1.xy
mov_pp r0.w, c2.x
mov_pp r0.x, r0.w
mov_pp r0.y, t1
mad_pp r0.xy, r0, c2.y, c2.z
mul r0.xy, r0, c0.x
mul r0.xy, r0, c1
mov r0.zw, t0
mad r0.xy, r0, t0.z, t0
texldp r0, r0, s0
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_GrabTexture] 2D 0
ConstBuffer "$Globals" 48
Float 16 [_BumpAmt]
Vector 32 [_GrabTexture_TexelSize]
BindCB  "$Globals" 0
"ps_4_0
eefiecedggjmkhplgkdbfcefbeaciicddpijkdoaabaaaaaadiacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahacaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgaabaaaaeaaaaaaafiaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadccbabaaa
acaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaadgaaaaafbcaabaaa
aaaaaaaaabeaaaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaabkbabaaaacaaaaaa
abeaaaaaaaaaaaeaaaaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaa
aaaaiadpaaaaialpaaaaaaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaaegaabaaa
aaaaaaaaagiacaaaaaaaaaaaabaaaaaadiaaaaaidcaabaaaaaaaaaaaegaabaaa
aaaaaaaaegiacaaaaaaaaaaaacaaaaaadcaaaaajdcaabaaaaaaaaaaaegaabaaa
aaaaaaaakgbkbaaaabaaaaaaegbabaaaabaaaaaaaoaaaaahdcaabaaaaaaaaaaa
egaabaaaaaaaaaaapgbpbaaaabaaaaaaefaaaaajpccabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_GrabTexture] 2D 0
ConstBuffer "$Globals" 48
Float 16 [_BumpAmt]
Vector 32 [_GrabTexture_TexelSize]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefieceddegnlnfghlflbhfdbhkojkmlemghfjagabaaaaaaeiadaaaaaeaaaaaa
daaaaaaadmabaaaakeacaaaabeadaaaaebgpgodjaeabaaaaaeabaaaaaaacpppp
naaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaabaaacaaaaaaaaaaaaaaaaacppppfbaaaaafacaaapkaaaaaiadpaaaaaaea
aaaaialpaaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaachla
bpaaaaacaaaaaajaaaaiapkaabaaaaacaaaacbiaacaaaakaaeaaaaaeaaaaccia
abaafflaacaaffkaacaakkkaafaaaaadaaaaadiaaaaaoeiaaaaaaakaafaaaaad
aaaaadiaaaaaoeiaabaaoekaaeaaaaaeaaaaadiaaaaaoeiaaaaakklaaaaaoela
agaaaaacaaaaaeiaaaaapplaafaaaaadaaaaadiaaaaakkiaaaaaoeiaecaaaaad
aaaacpiaaaaaoeiaaaaioekaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefc
gaabaaaaeaaaaaaafiaaaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaad
aagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaadccbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
abaaaaaadgaaaaafbcaabaaaaaaaaaaaabeaaaaaaaaaaaaadiaaaaahccaabaaa
aaaaaaaabkbabaaaacaaaaaaabeaaaaaaaaaaaeaaaaaaaakdcaabaaaaaaaaaaa
egaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaialpaaaaaaaaaaaaaaaadiaaaaai
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaagiacaaaaaaaaaaaabaaaaaadiaaaaai
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaegiacaaaaaaaaaaaacaaaaaadcaaaaaj
dcaabaaaaaaaaaaaegaabaaaaaaaaaaakgbkbaaaabaaaaaaegbabaaaabaaaaaa
aoaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaapgbpbaaaabaaaaaaefaaaaaj
pccabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
doaaaaabejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahacaaaafdfgfpfa
gphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
}
 }
}
Fallback Off
}