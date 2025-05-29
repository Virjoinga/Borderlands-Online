±8Shader "BOL/FX/Projector" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _ShadowTex ("Cookie", 2D) = "" {}
}
SubShader { 
 Tags { "QUEUE"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" }
  ZWrite Off
  Fog {
   Color (0,0,0,1)
  }
  Blend SrcAlpha OneMinusSrcAlpha
  Offset -1, -1
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Matrix 5 [_Projector]
"!!ARBvp1.0
PARAM c[9] = { program.local[0],
		state.matrix.mvp,
		program.local[5..8] };
DP4 result.texcoord[0].w, vertex.position, c[8];
DP4 result.texcoord[0].z, vertex.position, c[7];
DP4 result.texcoord[0].y, vertex.position, c[6];
DP4 result.texcoord[0].x, vertex.position, c[5];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 8 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Projector]
"vs_2_0
dcl_position0 v0
dp4 oT0.w, v0, c7
dp4 oT0.z, v0, c6
dp4 oT0.y, v0, c5
dp4 oT0.x, v0, c4
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
ConstBuffer "$Globals" 96
Matrix 16 [_Projector]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedikcfmajkojnalmakcfdjpijhndgmaobjabaaaaaaemacaaaaadaaaaaa
cmaaaaaagaaaaaaaliaaaaaaejfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafaepfdejfeejepeoaaklklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaaebaaaaaaaaaaaaaaabaaaaaaadaaaaaaabaaaaaaapaaaaaa
feeffiedepepfceeaafdfgfpfaepfdejfeejepeoaaklklklfdeieefcimabaaaa
eaaaabaagdaaaaaafjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaagfaaaaadpccabaaaaaaaaaaa
ghaaaaaepccabaaaabaaaaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaaacaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaa
aaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpccabaaaabaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Bind "vertex" Vertex
ConstBuffer "$Globals" 96
Matrix 16 [_Projector]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedgijpohdnnfmjkkbchocokbmlefjfplbdabaaaaaageadaaaaaeaaaaaa
daaaaaaaeeabaaaaniacaaaaamadaaaaebgpgodjamabaaaaamabaaaaaaacpopp
mmaaaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaabaa
aeaaabaaaaaaaaaaabaaaaaaaeaaafaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjaafaaaaadaaaaapiaaaaaffjaacaaoekaaeaaaaaeaaaaapia
abaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapiaadaaoekaaaaakkjaaaaaoeia
aeaaaaaeaaaaapoaaeaaoekaaaaappjaaaaaoeiaafaaaaadaaaaapiaaaaaffja
agaaoekaaeaaaaaeaaaaapiaafaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaapia
ahaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiaaiaaoekaaaaappjaaaaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
ppppaaaafdeieefcimabaaaaeaaaabaagdaaaaaafjaaaaaeegiocaaaaaaaaaaa
afaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaa
gfaaaaadpccabaaaaaaaaaaaghaaaaaepccabaaaabaaaaaaabaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaaaaaaaaa
acaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaaaaaaaaaaeaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaai
pcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaabaaaaaaegiocaaaabaaaaaa
adaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadoaaaaabejfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaa
faepfdejfeejepeoaaklklklepfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaaebaaaaaaaaaaaaaaabaaaaaa
adaaaaaaabaaaaaaapaaaaaafeeffiedepepfceeaafdfgfpfaepfdejfeejepeo
aaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Vector 0 [_Color]
SetTexture 0 [_ShadowTex] 2D 0
"!!ARBfp1.0
PARAM c[1] = { program.local[0] };
TEMP R0;
TXP R0, fragment.texcoord[0], texture[0], 2D;
MUL result.color.xyz, R0, c[0];
MOV result.color.w, R0;
END
# 3 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Vector 0 [_Color]
SetTexture 0 [_ShadowTex] 2D 0
"ps_2_0
dcl_2d s0
dcl t0
texldp r0, t0, s0
mul_pp r0.xyz, r0, c0
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_ShadowTex] 2D 0
ConstBuffer "$Globals" 96
Vector 80 [_Color]
BindCB  "$Globals" 0
"ps_4_0
eefiecedimmchdabfhiekhkpfmfljjdclbmapacdabaaaaaaimabaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapalaaaaebaaaaaaaaaaaaaaabaaaaaa
adaaaaaaabaaaaaaapaaaaaafeeffiedepepfceeaafdfgfpfaepfdejfeejepeo
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmmaaaaaa
eaaaaaaaddaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadlcbabaaaaaaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaaoaaaaahdcaabaaaaaaaaaaa
egbabaaaaaaaaaaapgbpbaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaihccabaaaaaaaaaaa
egacbaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
SetTexture 0 [_ShadowTex] 2D 0
ConstBuffer "$Globals" 96
Vector 80 [_Color]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedpcpockblghhpalljgnchecomacdlkcfeabaaaaaadeacaaaaaeaaaaaa
daaaaaaaneaaaaaakiabaaaaaaacaaaaebgpgodjjmaaaaaajmaaaaaaaaacpppp
giaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaafaaabaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaajaaaaiapkaagaaaaacaaaaaiiaaaaapplaafaaaaadaaaaadiaaaaappia
aaaaoelaecaaaaadaaaacpiaaaaaoeiaaaaioekaafaaaaadaaaachiaaaaaoeia
aaaaoekaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcmmaaaaaaeaaaaaaa
ddaaaaaafjaaaaaeegiocaaaaaaaaaaaagaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadlcbabaaaaaaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacabaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaa
aaaaaaaapgbpbaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaihccabaaaaaaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaafaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
aaaaaaaadoaaaaabejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapalaaaaebaaaaaaaaaaaaaaabaaaaaaadaaaaaa
abaaaaaaapaaaaaafeeffiedepepfceeaafdfgfpfaepfdejfeejepeoaaklklkl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
}
 }
}
}