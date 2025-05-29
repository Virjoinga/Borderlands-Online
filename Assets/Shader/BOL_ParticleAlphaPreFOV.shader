žñShader "BOL/FX/ParticleAlphaPreFOV" {
Properties {
 _MainTex ("Particle Texture", 2D) = "white" {}
 _InvFade ("Soft Particles Factor", Range(0.01,3)) = 1
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend One OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 5 [_ProjMat]
Vector 9 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[10] = { program.local[0],
		state.matrix.modelview[0],
		program.local[5..9] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R2, R0, c[7].y;
MAD R4, R1, c[7].x, R2;
MOV R2, c[3];
MUL R3, R0, c[8].y;
MAD R3, R1, c[8].x, R3;
MAD R5, R2, c[7].z, R4;
MAD R4, R2, c[8].z, R3;
MOV R3, c[4];
MAD R4, R3, c[8].w, R4;
MAD R5, R3, c[7].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R0, c[6].y;
MUL R0, R0, c[5].y;
MAD R0, R1, c[5].x, R0;
MAD R4, R1, c[6].x, R4;
MAD R1, R2, c[6].z, R4;
MAD R0, R2, c[5].z, R0;
MAD R1, R3, c[6].w, R1;
MAD R0, R3, c[5].w, R0;
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
MOV result.color, vertex.color;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
END
# 26 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
Vector 8 [_MainTex_ST]
"vs_2_0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
mov r0.x, c6.y
dp4 oPos.w, r1, v0
mul r1, c1, r0.x
mov r0.x, c6
mad r1, c0, r0.x, r1
mov r0.x, c6.z
mad r1, c2, r0.x, r1
mov r0.x, c6.w
mad r1, c3, r0.x, r1
mov r0.x, c5.y
dp4 oPos.z, v0, r1
mul r1, c1, r0.x
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.y, c5.w
mad r1, c3, r0.y, r1
mov r0.x, c4.y
mov r2.x, c4
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c4.z
mad r0, c2, r2.x, r0
mov r2.x, c4.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
mov oD0, v1
mad oT0.xy, v2, c8, c8.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Matrix 48 [_ProjMat]
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddpbnbbicjghbdhcjlhindmpojhadflejabaaaaaaaaafaaaaadaaaaaa
cmaaaaaajmaaaaaabaabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
gmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaagcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefcoiadaaaaeaaaabaapkaaaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaafaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
abaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaabaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaaeaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
abaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaabaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaafgifcaaaabaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
agaaaaaapgipcaaaabaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaa
aaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
acaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Matrix 48 [_ProjMat]
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedpjbnihpmijjpdgfimjcoogklankjmakgabaaaaaageahaaaaaeaaaaaa
daaaaaaajaacaaaaiaagaaaapaagaaaaebgpgodjfiacaaaafiacaaaaaaacpopp
biacaaaaeaaaaaaaacaaceaaaaaadmaaaaaadmaaaaaaceaaabaadmaaaaaaacaa
afaaabaaaaaaaaaaabaaaeaaaeaaagaaaaaaaaaaaaaaaaaaaaacpoppbpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
aeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaabaaaaacaaaaapiaadaaoeka
afaaaaadabaaapiaaaaaoeiaahaaffkaabaaaaacacaaapiaacaaoekaaeaaaaae
abaaapiaacaaoeiaahaaaakaabaaoeiaabaaaaacadaaapiaaeaaoekaaeaaaaae
abaaapiaadaaoeiaahaakkkaabaaoeiaabaaaaacaeaaapiaafaaoekaaeaaaaae
abaaapiaaeaaoeiaahaappkaabaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffja
afaaaaadafaaapiaaaaaoeiaagaaffkaaeaaaaaeafaaapiaacaaoeiaagaaaaka
afaaoeiaaeaaaaaeafaaapiaadaaoeiaagaakkkaafaaoeiaaeaaaaaeafaaapia
aeaaoeiaagaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeia
afaaaaadafaaapiaaaaaoeiaaiaaffkaaeaaaaaeafaaapiaacaaoeiaaiaaaaka
afaaoeiaaeaaaaaeafaaapiaadaaoeiaaiaakkkaafaaoeiaaeaaaaaeafaaapia
aeaaoeiaaiaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeia
afaaaaadaaaaapiaaaaaoeiaajaaffkaaeaaaaaeaaaaapiaacaaoeiaajaaaaka
aaaaoeiaaeaaaaaeaaaaapiaadaaoeiaajaakkkaaaaaoeiaaeaaaaaeaaaaapia
aeaaoeiaajaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeia
aeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeia
abaaaaacaaaaapoaabaaoejappppaaaafdeieefcoiadaaaaeaaaabaapkaaaaaa
fjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaa
acaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaaddccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaafaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
abaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaabaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaaeaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
abaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaabaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaafgifcaaaabaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
agaaaaaapgipcaaaabaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaa
aaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
acaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadoaaaaab
ejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
fpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaafaepfdejfeejepeo
aaedepemepfcaafeeffiedepepfceeaaepfdeheogmaaaaaaadaaaaaaaiaaaaaa
faaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadamaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepep
fceeaakl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 5 [_ProjMat]
Vector 9 [_ProjectionParams]
Vector 10 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[11] = { { 0.5 },
		state.matrix.modelview[0],
		program.local[5..10] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R1, c[2];
MOV R0, c[1];
MUL R2, R1, c[8].y;
MOV R3, c[3];
MAD R2, R0, c[8].x, R2;
MAD R4, R3, c[8].z, R2;
MOV R2, c[4];
MAD R5, R2, c[8].w, R4;
DP4 R7.x, R5, vertex.position;
MUL R4, R1, c[7].y;
MAD R5, R0, c[7].x, R4;
MUL R4, R1, c[5].y;
MOV R6.w, R7.x;
MUL R1, R1, c[6].y;
MAD R4, R0, c[5].x, R4;
MAD R0, R0, c[6].x, R1;
MAD R1, R3, c[5].z, R4;
MAD R1, R2, c[5].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R0, R3, c[6].z, R0;
MAD R0, R2, c[6].w, R0;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MAD R1, R3, c[7].z, R5;
MAD R1, R2, c[7].w, R1;
MUL R0.y, R0, c[9].x;
DP4 R6.z, vertex.position, R1;
ADD result.texcoord[1].xy, R0, R0.z;
DP4 R0.x, vertex.position, c[3];
MOV result.position, R6;
MOV result.texcoord[1].w, R7.x;
MOV result.color, vertex.color;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MOV result.texcoord[1].z, -R0.x;
END
# 34 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_ProjMat]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [_MainTex_ST]
"vs_2_0
def c11, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r0, c3, r0.x, r1
dp4 r2.w, r0, v0
mov r0.x, c4.y
mul r1, c1, r0.x
mov r0.x, c4
mad r1, c0, r0.x, r1
mov r0.x, c4.z
mad r1, c2, r0.x, r1
mov r0.x, c4.w
mad r3, c3, r0.x, r1
mov r0.y, c5
mov r0.w, r2
mul r1, c1, r0.y
mov r0.x, c5
mad r1, c0, r0.x, r1
mov r0.x, c5.z
mad r1, c2, r0.x, r1
mov r0.x, c5.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r3
dp4 r0.y, v0, r1
mul r2.xyz, r0.xyww, c11.x
mov r0.z, c6.y
mul r1, c1, r0.z
mov r0.z, c6.x
mad r1, c0, r0.z, r1
mov r0.z, c6
mad r1, c2, r0.z, r1
mov r0.z, c6.w
mad r1, c3, r0.z, r1
mul r2.y, r2, c8.x
dp4 r0.z, v0, r1
mov oPos, r0
dp4 r0.x, v0, c2
mad oT1.xy, r2.z, c9.zwzw, r2
mov oT1.w, r2
mov oD0, v1
mad oT0.xy, v2, c10, c10.zwzw
mov oT1.z, -r0.x
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Matrix 48 [_ProjMat]
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedapnhncgbekmpcaenngklppgjlpfplfbfabaaaaaahaagaaaaadaaaaaa
cmaaaaaajmaaaaaaciabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
ieaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaahkaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaahkaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeef
fiedepepfceeaaklfdeieefceaafaaaaeaaaabaafaabaaaafjaaaaaeegiocaaa
aaaaaaaaahaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaiaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaa
fpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
giaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaacaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
acaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaacaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
acaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaa
acaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaaficcabaaaadaaaaaadkaabaaaaaaaaaaa
aaaaaaahdccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaai
bcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaaacaaaaaaafaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaacaaaaaaaeaaaaaaakbabaaaaaaaaaaaakaabaaa
aaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaagaaaaaackbabaaa
aaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaa
ahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaadgaaaaageccabaaaadaaaaaa
akaabaiaebaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 128
Matrix 48 [_ProjMat]
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedihijfeokjhekdicnpjpgjlhbdlpbegcpabaaaaaajmajaaaaaeaaaaaa
daaaaaaafiadaaaakaaiaaaabaajaaaaebgpgodjcaadaaaacaadaaaaaaacpopp
neacaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaacaa
afaaabaaaaaaaaaaabaaafaaabaaagaaaaaaaaaaacaaaeaaaeaaahaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafalaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaacia
acaaapjaabaaaaacaaaaapiaaiaaoekaafaaaaadabaaapiaaaaaffiaadaaoeka
aeaaaaaeabaaapiaacaaoekaaaaaaaiaabaaoeiaaeaaaaaeabaaapiaaeaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaapiaafaaoekaaaaappiaabaaoeiaafaaaaad
aaaaapiaaaaaoeiaaaaaffjaabaaaaacabaaapiaahaaoekaafaaaaadacaaapia
abaaffiaadaaoekaaeaaaaaeacaaapiaacaaoekaabaaaaiaacaaoeiaaeaaaaae
acaaapiaaeaaoekaabaakkiaacaaoeiaaeaaaaaeabaaapiaafaaoekaabaappia
acaaoeiaaeaaaaaeaaaaapiaabaaoeiaaaaaaajaaaaaoeiaabaaaaacabaaapia
ajaaoekaafaaaaadacaaapiaabaaffiaadaaoekaaeaaaaaeacaaapiaacaaoeka
abaaaaiaacaaoeiaaeaaaaaeacaaapiaaeaaoekaabaakkiaacaaoeiaaeaaaaae
abaaapiaafaaoekaabaappiaacaaoeiaaeaaaaaeaaaaapiaabaaoeiaaaaakkja
aaaaoeiaabaaaaacabaaapiaakaaoekaafaaaaadacaaapiaabaaffiaadaaoeka
aeaaaaaeacaaapiaacaaoekaabaaaaiaacaaoeiaaeaaaaaeacaaapiaaeaaoeka
abaakkiaacaaoeiaaeaaaaaeabaaapiaafaaoekaabaappiaacaaoeiaaeaaaaae
aaaaapiaabaaoeiaaaaappjaaaaaoeiaafaaaaadabaaabiaaaaaffiaagaaaaka
afaaaaadabaaaiiaabaaaaiaalaaaakaafaaaaadabaaafiaaaaapeiaalaaaaka
acaaaaadacaaadoaabaakkiaabaaomiaafaaaaadabaaabiaaaaaffjaaiaakkka
aeaaaaaeabaaabiaahaakkkaaaaaaajaabaaaaiaaeaaaaaeabaaabiaajaakkka
aaaakkjaabaaaaiaaeaaaaaeabaaabiaakaakkkaaaaappjaabaaaaiaabaaaaac
acaaaeoaabaaaaibaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaac
acaaaioaaaaappiaabaaaaacaaaaapoaabaaoejappppaaaafdeieefceaafaaaa
eaaaabaafaabaaaafjaaaaaeegiocaaaaaaaaaaaahaaaaaafjaaaaaeegiocaaa
abaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaaaiaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaafaaaaaadcaaaaal
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaafaaaaaa
egaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaaj
pcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaaeaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaa
aeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
afaaaaaakgikcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaacaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
acaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaahaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaahaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
acaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaa
egbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaa
aaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
iccabaaaadaaaaaadkaabaaaaaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaa
ckiacaaaacaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaa
aeaaaaaaakbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
ckiacaaaacaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaak
bcaabaaaaaaaaaaackiacaaaacaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaa
aaaaaaaadgaaaaageccabaaaadaaaaaaakaabaiaebaaaaaaaaaaaaaadoaaaaab
ejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
fpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaafaepfdejfeejepeo
aaedepemepfcaafeeffiedepepfceeaaepfdeheoieaaaaaaaeaaaaaaaiaaaaaa
giaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
acaaaaaaadamaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
TEMP R0;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, fragment.color.primary, R0;
MUL result.color, R0, fragment.color.primary.w;
END
# 3 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
dcl v0
dcl t0.xy
texld r0, t0, s0
mul r0, v0, r0
mul r0, r0, v0.w
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedlkijheakemncfblfpnlpghcnokibgamhabaaaaaamiabaaaaadaaaaaa
cmaaaaaakaaaaaaaneaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcomaaaaaaeaaaaaaa
dlaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaadgaaaaaficaabaaaaaaaaaaadkbabaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadgaaaaafhcaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegbobaaaabaaaaaadgaaaaafbcaabaaaabaaaaaa
dkbabaaaabaaaaaadiaaaaahpccabaaaaaaaaaaaagambaaaabaaaaaaegaobaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
"ps_4_0_level_9_1
eefiecedkjlkjddgcjnoblplhkgbafmghenkkhohabaaaaaaiiacaaaaaeaaaaaa
daaaaaaaomaaaaaaoaabaaaafeacaaaaebgpgodjleaaaaaaleaaaaaaaaacpppp
imaaaaaaciaaaaaaaaaaciaaaaaaciaaaaaaciaaabaaceaaaaaaciaaaaaaaaaa
aaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaaadlabpaaaaac
aaaaaajaaaaiapkaecaaaaadaaaaapiaabaaoelaaaaioekaabaaaaacabaaaiia
aaaapplaabaaaaacabaaahiaaaaaoeiaafaaaaadabaaapiaabaaoeiaaaaaoela
abaaaaacaaaaahiaaaaapplaafaaaaadaaaacpiaaaaaoeiaabaaoeiaabaaaaac
aaaicpiaaaaaoeiappppaaaafdeieefcomaaaaaaeaaaaaaadlaaaaaafkaaaaad
aagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaa
abaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
acaaaaaadgaaaaaficaabaaaaaaaaaaadkbabaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaaf
hcaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaegbobaaaabaaaaaadgaaaaafbcaabaaaabaaaaaadkbabaaaabaaaaaa
diaaaaahpccabaaaaaaaaaaaagambaaaabaaaaaaegaobaaaaaaaaaaadoaaaaab
ejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
gcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaafdfgfpfagphdgjhe
gjgpgoaaedepemepfcaafeeffiedepepfceeaaklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_ZBufferParams]
Float 1 [_InvFade]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0..1] };
TEMP R0;
TEMP R1;
TEMP R2;
TXP R1.x, fragment.texcoord[1], texture[0], 2D;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MAD R1.x, R1, c[0].z, c[0].w;
RCP R1.x, R1.x;
ADD R1.x, R1, -fragment.texcoord[1].z;
MUL_SAT R1.x, R1, c[1];
MUL R2.x, fragment.color.primary.w, R1;
MOV R1.xyz, fragment.color.primary;
MOV R1.w, R2.x;
MUL R0, R1, R0;
MUL result.color, R0, R2.x;
END
# 11 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_ZBufferParams]
Float 1 [_InvFade]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl v0
dcl t0.xy
dcl t1
texldp r0, t1, s0
texld r1, t0, s1
mad r0.x, r0, c0.z, c0.w
rcp r0.x, r0.x
add r0.x, r0, -t1.z
mul_sat r0.x, r0, c1
mul_pp r0.x, v0.w, r0
mov_pp r2.w, r0.x
mov_pp r2.xyz, v0
mul r1, r2, r1
mul r0, r1, r0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Float 112 [_InvFade]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedkgejajjfhfinglklomdgefokpephbhpmabaaaaaacmadaaaaadaaaaaa
cmaaaaaaliaaaaaaomaaaaaaejfdeheoieaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaafdfgfpfa
gphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaaklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklklfdeieefcdiacaaaaeaaaaaaaioaaaaaafjaaaaae
egiocaaaaaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaadaaaaaa
pgbpbaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaackiacaaaabaaaaaa
ahaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaa
aaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaa
aaaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaackbabaiaebaaaaaaadaaaaaa
dicaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaaahaaaaaa
diaaaaahicaabaaaaaaaaaaaakaabaaaaaaaaaaadkbabaaaabaaaaaadgaaaaaf
icaabaaaabaaaaaadkaabaaaaaaaaaaadgaaaaafhcaabaaaaaaaaaaaegbcbaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadgaaaaafhcaabaaaabaaaaaaegacbaaaacaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadgaaaaafbcaabaaa
acaaaaaadkaabaaaabaaaaaadiaaaaahpccabaaaaaaaaaaaagambaaaacaaaaaa
egaobaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 128
Float 112 [_InvFade]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedhljjlijapojckiffngndkhpdhfgifipkabaaaaaakiaeaaaaaeaaaaaa
daaaaaaakiabaaaaoiadaaaaheaeaaaaebgpgodjhaabaaaahaabaaaaaaacpppp
cmabaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaahaaabaaaaaaaaaaaaaaabaaahaaabaaabaaaaaaaaaaaaacpppp
bpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaaadlabpaaaaacaaaaaaia
acaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaagaaaaac
aaaaaiiaacaapplaafaaaaadaaaaadiaaaaappiaacaaoelaecaaaaadaaaaapia
aaaaoeiaabaioekaecaaaaadabaaapiaabaaoelaaaaioekaaeaaaaaeaaaaabia
abaakkkaaaaaaaiaabaappkaagaaaaacaaaaabiaaaaaaaiaacaaaaadaaaaabia
aaaaaaiaacaakklbafaaaaadaaaabbiaaaaaaaiaaaaaaakaafaaaaadaaaaciia
aaaaaaiaaaaapplaabaaaaacacaaciiaaaaappiaabaaaaacaaaaahiaaaaaoela
abaaaaacacaaahiaabaaoeiaafaaaaadaaaaapiaaaaaoeiaacaaoeiaabaaaaac
abaachiaacaappiaafaaaaadaaaacpiaabaaoeiaaaaaoeiaabaaaaacaaaicpia
aaaaoeiappppaaaafdeieefcdiacaaaaeaaaaaaaioaaaaaafjaaaaaeegiocaaa
aaaaaaaaaiaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaadaaaaaapgbpbaaa
adaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaackiacaaaabaaaaaaahaaaaaa
akaabaaaaaaaaaaadkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaaaaaaaaai
bcaabaaaaaaaaaaaakaabaaaaaaaaaaackbabaiaebaaaaaaadaaaaaadicaaaai
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaaahaaaaaadiaaaaah
icaabaaaaaaaaaaaakaabaaaaaaaaaaadkbabaaaabaaaaaadgaaaaaficaabaaa
abaaaaaadkaabaaaaaaaaaaadgaaaaafhcaabaaaaaaaaaaaegbcbaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadgaaaaafhcaabaaaabaaaaaaegacbaaaacaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadgaaaaafbcaabaaaacaaaaaa
dkaabaaaabaaaaaadiaaaaahpccabaaaaaaaaaaaagambaaaacaaaaaaegaobaaa
aaaaaaaadoaaaaabejfdeheoieaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaa
hkaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaafdfgfpfagphdgjhe
gjgpgoaaedepemepfcaafeeffiedepepfceeaaklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
}
 }
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend One OneMinusSrcAlpha
  ColorMask RGB
  SetTexture [_MainTex] { combine primary * primary alpha }
  SetTexture [_MainTex] { combine previous * texture }
 }
}
SubShader { 
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  BindChannels {
   Bind "vertex", Vertex
   Bind "color", Color
   Bind "texcoord", TexCoord
  }
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend One OneMinusSrcAlpha
  ColorMask RGB
  SetTexture [_MainTex] { combine texture * primary }
 }
}
}