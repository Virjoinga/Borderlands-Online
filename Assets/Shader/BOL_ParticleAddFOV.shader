¨èShader "BOL/FX/ParticleAddFOV" {
Properties {
 _TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
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
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  AlphaTest Greater 0.01
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 9 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[10] = { { 1.4874235 },
		state.matrix.modelview[0],
		state.matrix.projection,
		program.local[9] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
MOV R0, c[2];
MUL R2, R0, c[7].y;
MUL R1, R0, c[8].y;
MOV R0, c[1];
MAD R3, R0, c[7].x, R2;
MAD R1, R0, c[8].x, R1;
MOV R0, c[3];
MAD R2, R0, c[8].z, R1;
MOV R1, c[4];
MAD R2, R1, c[8].w, R2;
MAD R0, R0, c[7].z, R3;
MAD R1, R1, c[7].w, R0;
MOV R0.x, c[0];
DP4 result.position.z, vertex.position, R1;
MUL R1, R0.x, c[6];
MUL R0, R0.x, c[5];
MUL R3, R0.y, c[2];
MAD R3, R0.x, c[1], R3;
DP4 result.position.w, R2, vertex.position;
MUL R2, R1.y, c[2];
MAD R2, R1.x, c[1], R2;
MAD R2, R1.z, c[3], R2;
MAD R3, R0.z, c[3], R3;
MAD R1, R1.w, c[4], R2;
MAD R0, R0.w, c[4], R3;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
MOV result.color, vertex.color;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
END
# 29 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_projection]
Vector 8 [_MainTex_ST]
"vs_2_0
def c9, 1.48742354, 0, 0, 0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
mov r0, c5
mul r3, c9.x, r0
mov r0, c4
mul r0, c9.x, r0
mul r2, r0.y, c1
mad r2, r0.x, c0, r2
mul r1, r3.y, c1
mad r1, r3.x, c0, r1
mad r1, r3.z, c2, r1
mad r1, r3.w, c3, r1
mad r2, r0.z, c2, r2
dp4 oPos.y, v0, r1
mad r1, r0.w, c3, r2
mov r0.x, c7.y
dp4 oPos.x, v0, r1
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.y, c7.w
mad r1, c3, r0.y, r1
mov r0.x, c6.y
mov r2.x, c6
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c6.z
mad r0, c2, r2.x, r0
mov r2.x, c6.w
mad r0, c3, r2.x, r0
dp4 oPos.w, r1, v0
dp4 oPos.z, v0, r0
mov oD0, v1
mad oT0.xy, v2, c8, c8.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
ConstBuffer "UnityPerFrame" 208
Matrix 0 [glstate_matrix_projection]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerFrame" 2
"vs_4_0
eefiecedodfdpbegichboodnacdliaiaedomocmbabaaaaaabiagaaaaadaaaaaa
cmaaaaaajmaaaaaabaabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
gmaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaagcaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaafdfgfpfagphdgjhegjgpgoaa
edepemepfcaafeeffiedepepfceeaaklfdeieefcaaafaaaaeaaaabaaeaabaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
pcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagiaaaaac
acaaaaaadiaaaaaibcaabaaaaaaaaaaaakiacaaaacaaaaaaaaaaaaaaabeaaaaa
ofgdlodpdiaaaaaiccaabaaaaaaaaaaaakiacaaaacaaaaaaabaaaaaaabeaaaaa
ofgdlodpdiaaaaaiecaabaaaaaaaaaaaakiacaaaacaaaaaaacaaaaaaabeaaaaa
ofgdlodpdiaaaaaiicaabaaaaaaaaaaaakiacaaaacaaaaaaadaaaaaaabeaaaaa
ofgdlodpbbaaaaaibcaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
aeaaaaaabbaaaaaiccaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
afaaaaaabbaaaaaiecaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
agaaaaaabbaaaaaiicaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
ahaaaaaabbaaaaahbccabaaaaaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaa
diaaaaaibcaabaaaaaaaaaaabkiacaaaacaaaaaaaaaaaaaaabeaaaaaofgdlodp
diaaaaaiccaabaaaaaaaaaaabkiacaaaacaaaaaaabaaaaaaabeaaaaaofgdlodp
diaaaaaiecaabaaaaaaaaaaabkiacaaaacaaaaaaacaaaaaaabeaaaaaofgdlodp
diaaaaaiicaabaaaaaaaaaaabkiacaaaacaaaaaaadaaaaaaabeaaaaaofgdlodp
bbaaaaaibcaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaaeaaaaaa
bbaaaaaiccaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaafaaaaaa
bbaaaaaiecaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaagaaaaaa
bbaaaaaiicaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaahaaaaaa
bbaaaaahcccabaaaaaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaadgaaaaag
bcaabaaaaaaaaaaackiacaaaacaaaaaaaaaaaaaadgaaaaagccaabaaaaaaaaaaa
ckiacaaaacaaaaaaabaaaaaadgaaaaagecaabaaaaaaaaaaackiacaaaacaaaaaa
acaaaaaadgaaaaagicaabaaaaaaaaaaackiacaaaacaaaaaaadaaaaaabbaaaaai
bcaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaaeaaaaaabbaaaaai
ccaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaafaaaaaabbaaaaai
ecaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaagaaaaaabbaaaaai
icaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaahaaaaaabbaaaaah
eccabaaaaaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaadgaaaaagbcaabaaa
aaaaaaaadkiacaaaacaaaaaaaaaaaaaadgaaaaagccaabaaaaaaaaaaadkiacaaa
acaaaaaaabaaaaaadgaaaaagecaabaaaaaaaaaaadkiacaaaacaaaaaaacaaaaaa
dgaaaaagicaabaaaaaaaaaaadkiacaaaacaaaaaaadaaaaaabbaaaaaibcaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaaeaaaaaabbaaaaaiccaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaafaaaaaabbaaaaaiecaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaagaaaaaabbaaaaaiicaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaahaaaaaabbaaaaahiccabaaa
aaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaadgaaaaafpccabaaaabaaaaaa
egbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaa
aaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
ConstBuffer "UnityPerFrame" 208
Matrix 0 [glstate_matrix_projection]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerFrame" 2
"vs_4_0_level_9_1
eefiecedmlpamohoadlpajaicgkgajhdmhindlojabaaaaaacaajaaaaaeaaaaaa
daaaaaaadeadaaaadmaiaaaakmaiaaaaebgpgodjpmacaaaapmacaaaaaaacpopp
laacaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaacaa
abaaabaaaaaaaaaaabaaaeaaaeaaacaaaaaaaaaaacaaaaaaaeaaagaaaaaaaaaa
aaaaaaaaaaacpoppfbaaaaafakaaapkaofgdlodpaaaaaaaaaaaaaaaaaaaaaaaa
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaacia
acaaapjaabaaaaacaaaaabiaagaakkkaabaaaaacaaaaaciaahaakkkaabaaaaac
aaaaaeiaaiaakkkaabaaaaacaaaaaiiaajaakkkaajaaaaadabaaabiaaaaaoeia
acaaoekaajaaaaadabaaaciaaaaaoeiaadaaoekaajaaaaadabaaaeiaaaaaoeia
aeaaoekaajaaaaadabaaaiiaaaaaoeiaafaaoekaajaaaaadaaaaaemaabaaoeia
aaaaoejaaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaabaaaaacaaaaabia
akaaaakaafaaaaadabaaabiaaaaaaaiaagaaaakaafaaaaadabaaaciaaaaaaaia
ahaaaakaafaaaaadabaaaeiaaaaaaaiaaiaaaakaafaaaaadabaaaiiaaaaaaaia
ajaaaakaajaaaaadacaaabiaabaaoeiaacaaoekaajaaaaadacaaaciaabaaoeia
adaaoekaajaaaaadacaaaeiaabaaoeiaaeaaoekaajaaaaadacaaaiiaabaaoeia
afaaoekaajaaaaadabaaabiaacaaoeiaaaaaoejaafaaaaadacaaabiaaaaaaaia
agaaffkaafaaaaadacaaaciaaaaaaaiaahaaffkaafaaaaadacaaaeiaaaaaaaia
aiaaffkaafaaaaadacaaaiiaaaaaaaiaajaaffkaajaaaaadaaaaabiaacaaoeia
acaaoekaajaaaaadaaaaaciaacaaoeiaadaaoekaajaaaaadaaaaaeiaacaaoeia
aeaaoekaajaaaaadaaaaaiiaacaaoeiaafaaoekaajaaaaadabaaaciaaaaaoeia
aaaaoejaabaaaaacaaaaabiaagaappkaabaaaaacaaaaaciaahaappkaabaaaaac
aaaaaeiaaiaappkaabaaaaacaaaaaiiaajaappkaajaaaaadacaaabiaaaaaoeia
acaaoekaajaaaaadacaaaciaaaaaoeiaadaaoekaajaaaaadacaaaeiaaaaaoeia
aeaaoekaajaaaaadacaaaiiaaaaaoeiaafaaoekaajaaaaadaaaaabiaacaaoeia
aaaaoejaaeaaaaaeaaaaadmaaaaaaaiaaaaaoekaabaaoeiaabaaaaacaaaaaima
aaaaaaiaabaaaaacaaaaapoaabaaoejappppaaaafdeieefcaaafaaaaeaaaabaa
eaabaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaa
aiaaaaaafjaaaaaeegiocaaaacaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
giaaaaacacaaaaaadiaaaaaibcaabaaaaaaaaaaaakiacaaaacaaaaaaaaaaaaaa
abeaaaaaofgdlodpdiaaaaaiccaabaaaaaaaaaaaakiacaaaacaaaaaaabaaaaaa
abeaaaaaofgdlodpdiaaaaaiecaabaaaaaaaaaaaakiacaaaacaaaaaaacaaaaaa
abeaaaaaofgdlodpdiaaaaaiicaabaaaaaaaaaaaakiacaaaacaaaaaaadaaaaaa
abeaaaaaofgdlodpbbaaaaaibcaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
abaaaaaaaeaaaaaabbaaaaaiccaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
abaaaaaaafaaaaaabbaaaaaiecaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
abaaaaaaagaaaaaabbaaaaaiicaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaa
abaaaaaaahaaaaaabbaaaaahbccabaaaaaaaaaaaegaobaaaabaaaaaaegbobaaa
aaaaaaaadiaaaaaibcaabaaaaaaaaaaabkiacaaaacaaaaaaaaaaaaaaabeaaaaa
ofgdlodpdiaaaaaiccaabaaaaaaaaaaabkiacaaaacaaaaaaabaaaaaaabeaaaaa
ofgdlodpdiaaaaaiecaabaaaaaaaaaaabkiacaaaacaaaaaaacaaaaaaabeaaaaa
ofgdlodpdiaaaaaiicaabaaaaaaaaaaabkiacaaaacaaaaaaadaaaaaaabeaaaaa
ofgdlodpbbaaaaaibcaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
aeaaaaaabbaaaaaiccaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
afaaaaaabbaaaaaiecaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
agaaaaaabbaaaaaiicaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaa
ahaaaaaabbaaaaahcccabaaaaaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaa
dgaaaaagbcaabaaaaaaaaaaackiacaaaacaaaaaaaaaaaaaadgaaaaagccaabaaa
aaaaaaaackiacaaaacaaaaaaabaaaaaadgaaaaagecaabaaaaaaaaaaackiacaaa
acaaaaaaacaaaaaadgaaaaagicaabaaaaaaaaaaackiacaaaacaaaaaaadaaaaaa
bbaaaaaibcaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaaeaaaaaa
bbaaaaaiccaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaafaaaaaa
bbaaaaaiecaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaagaaaaaa
bbaaaaaiicaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaahaaaaaa
bbaaaaaheccabaaaaaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaadgaaaaag
bcaabaaaaaaaaaaadkiacaaaacaaaaaaaaaaaaaadgaaaaagccaabaaaaaaaaaaa
dkiacaaaacaaaaaaabaaaaaadgaaaaagecaabaaaaaaaaaaadkiacaaaacaaaaaa
acaaaaaadgaaaaagicaabaaaaaaaaaaadkiacaaaacaaaaaaadaaaaaabbaaaaai
bcaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaaeaaaaaabbaaaaai
ccaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaafaaaaaabbaaaaai
ecaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaagaaaaaabbaaaaai
icaabaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaabaaaaaaahaaaaaabbaaaaah
iccabaaaaaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaadgaaaaafpccabaaa
abaaaaaaegbobaaaabaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaa
egiacaaaaaaaaaaaacaaaaaaogikcaaaaaaaaaaaacaaaaaadoaaaaabejfdeheo
giaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaafjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaafpaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaafaepfdejfeejepeoaaedepem
epfcaafeeffiedepepfceeaaepfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adamaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Vector 9 [_ProjectionParams]
Vector 10 [_MainTex_ST]
"!!ARBvp1.0
PARAM c[11] = { { 1.4874235, 0.5 },
		state.matrix.modelview[0],
		state.matrix.projection,
		program.local[9..10] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
TEMP R8;
MOV R0, c[2];
MOV R3, c[1];
MUL R1, R0, c[8].y;
MUL R4, R0, c[7].y;
MAD R2, R3, c[8].x, R1;
MAD R4, R3, c[7].x, R4;
MOV R1, c[3];
MAD R2, R1, c[8].z, R2;
MOV R0, c[4];
MAD R2, R0, c[8].w, R2;
DP4 R8.x, R2, vertex.position;
MOV R3.x, c[0];
MUL R2, R3.x, c[5];
MUL R3, R3.x, c[6];
MUL R5, R2.y, c[2];
MUL R6, R3.y, c[2];
MAD R5, R2.x, c[1], R5;
MAD R6, R3.x, c[1], R6;
MAD R5, R2.z, c[3], R5;
MAD R2, R2.w, c[4], R5;
MAD R6, R3.z, c[3], R6;
MAD R3, R3.w, c[4], R6;
MAD R1, R1, c[7].z, R4;
MAD R0, R0, c[7].w, R1;
DP4 R7.z, vertex.position, R0;
DP4 R0.x, vertex.position, c[3];
DP4 R7.x, vertex.position, R2;
MOV R7.w, R8.x;
DP4 R7.y, vertex.position, R3;
MUL R2.xyz, R7.xyww, c[0].y;
MUL R2.y, R2, c[9].x;
ADD result.texcoord[1].xy, R2, R2.z;
MOV result.position, R7;
MOV result.texcoord[1].w, R8.x;
MOV result.color, vertex.color;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[10], c[10].zwzw;
MOV result.texcoord[1].z, -R0.x;
END
# 37 instructions, 9 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [glstate_matrix_projection]
Vector 8 [_ProjectionParams]
Vector 9 [_ScreenParams]
Vector 10 [_MainTex_ST]
"vs_2_0
def c11, 1.48742354, 0.50000000, 0, 0
dcl_position0 v0
dcl_color0 v1
dcl_texcoord0 v2
mov r0, c5
mul r2, c11.x, r0
mul r0, r2.y, c1
mad r1, r2.x, c0, r0
mad r1, r2.z, c2, r1
mov r0, c4
mul r0, c11.x, r0
mad r2, r2.w, c3, r1
mul r1, r0.y, c1
mad r1, r0.x, c0, r1
dp4 r0.y, v0, r2
mad r2, r0.z, c2, r1
mov r0.x, c7.y
mul r1, c1, r0.x
mov r0.x, c7
mad r1, c0, r0.x, r1
mov r0.x, c7.z
mad r1, c2, r0.x, r1
mov r0.x, c7.w
mad r1, c3, r0.x, r1
mad r2, r0.w, c3, r2
dp4 r1.w, r1, v0
dp4 r0.x, v0, r2
mov r0.w, r1
mul r1.xyz, r0.xyww, c11.y
mov r0.z, c6.y
mul r2, c1, r0.z
mov r0.z, c6.x
mad r2, c0, r0.z, r2
mov r0.z, c6
mad r2, c2, r0.z, r2
mov r0.z, c6.w
mad r2, c3, r0.z, r2
mul r1.y, r1, c8.x
dp4 r0.z, v0, r2
mov oPos, r0
dp4 r0.x, v0, c2
mad oT1.xy, r1.z, c9.zwzw, r1
mov oT1.w, r1
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
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
ConstBuffer "UnityPerFrame" 208
Matrix 0 [glstate_matrix_projection]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
BindCB  "UnityPerFrame" 3
"vs_4_0
eefiecedplhkpjcaapdfalbmjbjichkhmlcfcncpabaaaaaakeahaaaaadaaaaaa
cmaaaaaajmaaaaaaciabaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaafjaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafpaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafaepfdejfeejepeoaaedepemepfcaafeeffiedepepfceeaaepfdeheo
ieaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaahkaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaahkaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapaaaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeef
fiedepepfceeaaklfdeieefcheagaaaaeaaaabaajnabaaaafjaaaaaeegiocaaa
aaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaiaaaaaafjaaaaaeegiocaaaadaaaaaaaeaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacadaaaaaadgaaaaagbcaabaaa
aaaaaaaackiacaaaadaaaaaaaaaaaaaadgaaaaagccaabaaaaaaaaaaackiacaaa
adaaaaaaabaaaaaadgaaaaagecaabaaaaaaaaaaackiacaaaadaaaaaaacaaaaaa
dgaaaaagicaabaaaaaaaaaaackiacaaaadaaaaaaadaaaaaabbaaaaaibcaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaacaaaaaaaeaaaaaabbaaaaaiccaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaacaaaaaaafaaaaaabbaaaaaiecaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaacaaaaaaagaaaaaabbaaaaaiicaabaaa
abaaaaaaegaobaaaaaaaaaaaegiocaaaacaaaaaaahaaaaaabbaaaaaheccabaaa
aaaaaaaaegaobaaaabaaaaaaegbobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akiacaaaadaaaaaaaaaaaaaaabeaaaaaofgdlodpdiaaaaaiccaabaaaaaaaaaaa
akiacaaaadaaaaaaabaaaaaaabeaaaaaofgdlodpdiaaaaaiecaabaaaaaaaaaaa
akiacaaaadaaaaaaacaaaaaaabeaaaaaofgdlodpdiaaaaaiicaabaaaaaaaaaaa
akiacaaaadaaaaaaadaaaaaaabeaaaaaofgdlodpbbaaaaaibcaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaaeaaaaaabbaaaaaiccaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaafaaaaaabbaaaaaiecaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaagaaaaaabbaaaaaiicaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaahaaaaaabbaaaaahbcaabaaaaaaaaaaa
egaobaaaabaaaaaaegbobaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaabkiacaaa
adaaaaaaaaaaaaaaabeaaaaaofgdlodpdiaaaaaiccaabaaaabaaaaaabkiacaaa
adaaaaaaabaaaaaaabeaaaaaofgdlodpdiaaaaaiecaabaaaabaaaaaabkiacaaa
adaaaaaaacaaaaaaabeaaaaaofgdlodpdiaaaaaiicaabaaaabaaaaaabkiacaaa
adaaaaaaadaaaaaaabeaaaaaofgdlodpbbaaaaaibcaabaaaacaaaaaaegaobaaa
abaaaaaaegiocaaaacaaaaaaaeaaaaaabbaaaaaiccaabaaaacaaaaaaegaobaaa
abaaaaaaegiocaaaacaaaaaaafaaaaaabbaaaaaiecaabaaaacaaaaaaegaobaaa
abaaaaaaegiocaaaacaaaaaaagaaaaaabbaaaaaiicaabaaaacaaaaaaegaobaaa
abaaaaaaegiocaaaacaaaaaaahaaaaaabbaaaaahccaabaaaaaaaaaaaegaobaaa
acaaaaaaegbobaaaaaaaaaaadgaaaaagbcaabaaaabaaaaaadkiacaaaadaaaaaa
aaaaaaaadgaaaaagccaabaaaabaaaaaadkiacaaaadaaaaaaabaaaaaadgaaaaag
ecaabaaaabaaaaaadkiacaaaadaaaaaaacaaaaaadgaaaaagicaabaaaabaaaaaa
dkiacaaaadaaaaaaadaaaaaabbaaaaaibcaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaaeaaaaaabbaaaaaiccaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaafaaaaaabbaaaaaiecaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaagaaaaaabbaaaaaiicaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaahaaaaaabbaaaaahicaabaaaaaaaaaaaegaobaaaacaaaaaa
egbobaaaaaaaaaaadgaaaaaflccabaaaaaaaaaaaegambaaaaaaaaaaadiaaaaak
fcaabaaaabaaaaaaagadbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaaaadgaaaaaficcabaaaadaaaaaadkaabaaaaaaaaaaadiaaaaaibcaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaahicaabaaa
abaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaadpaaaaaaahdccabaaaadaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaa
abaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaa
acaaaaaaogikcaaaaaaaaaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaa
aaaaaaaackiacaaaacaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
acaaaaaaaeaaaaaaakbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaackiacaaaacaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaa
dcaaaaakbcaabaaaaaaaaaaackiacaaaacaaaaaaahaaaaaadkbabaaaaaaaaaaa
akaabaaaaaaaaaaadgaaaaageccabaaaadaaaaaaakaabaiaebaaaaaaaaaaaaaa
doaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 32 [_MainTex_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
ConstBuffer "UnityPerFrame" 208
Matrix 0 [glstate_matrix_projection]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
BindCB  "UnityPerFrame" 3
"vs_4_0_level_9_1
eefiecedhmbhmjfahmdkfiiccajoccdclkmfnakaabaaaaaafmalaaaaaeaaaaaa
daaaaaaaoeadaaaagaakaaaanaakaaaaebgpgodjkmadaaaakmadaaaaaaacpopp
feadaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaacaa
abaaabaaaaaaaaaaabaaafaaabaaacaaaaaaaaaaacaaaeaaaeaaadaaaaaaaaaa
adaaaaaaaeaaahaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafalaaapkaofgdlodp
aaaaaadpaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabia
abaaapjabpaaaaacafaaaciaacaaapjaabaaaaacaaaaabiaahaakkkaabaaaaac
aaaaaciaaiaakkkaabaaaaacaaaaaeiaajaakkkaabaaaaacaaaaaiiaakaakkka
ajaaaaadabaaabiaaaaaoeiaadaaoekaajaaaaadabaaaciaaaaaoeiaaeaaoeka
ajaaaaadabaaaeiaaaaaoeiaafaaoekaajaaaaadabaaaiiaaaaaoeiaagaaoeka
ajaaaaadaaaaaemaabaaoeiaaaaaoejaabaaaaacaaaaabiaalaaaakaafaaaaad
abaaabiaaaaaaaiaahaaffkaafaaaaadabaaaciaaaaaaaiaaiaaffkaafaaaaad
abaaaeiaaaaaaaiaajaaffkaafaaaaadabaaaiiaaaaaaaiaakaaffkaajaaaaad
acaaabiaabaaoeiaadaaoekaajaaaaadacaaaciaabaaoeiaaeaaoekaajaaaaad
acaaaeiaabaaoeiaafaaoekaajaaaaadacaaaiiaabaaoeiaagaaoekaajaaaaad
abaaaciaacaaoeiaaaaaoejaafaaaaadaaaaaciaabaaffiaacaaaakaafaaaaad
acaaaiiaaaaaffiaalaaffkaafaaaaadadaaabiaaaaaaaiaahaaaakaafaaaaad
adaaaciaaaaaaaiaaiaaaakaafaaaaadadaaaeiaaaaaaaiaajaaaakaafaaaaad
adaaaiiaaaaaaaiaakaaaakaajaaaaadaaaaabiaadaaoeiaadaaoekaajaaaaad
aaaaaciaadaaoeiaaeaaoekaajaaaaadaaaaaeiaadaaoeiaafaaoekaajaaaaad
aaaaaiiaadaaoeiaagaaoekaajaaaaadabaaabiaaaaaoeiaaaaaoejaabaaaaac
aaaaabiaahaappkaabaaaaacaaaaaciaaiaappkaabaaaaacaaaaaeiaajaappka
abaaaaacaaaaaiiaakaappkaajaaaaadadaaabiaaaaaoeiaadaaoekaajaaaaad
adaaaciaaaaaoeiaaeaaoekaajaaaaadadaaaeiaaaaaoeiaafaaoekaajaaaaad
adaaaiiaaaaaoeiaagaaoekaajaaaaadabaaaiiaadaaoeiaaaaaoejaafaaaaad
acaaafiaabaapeiaalaaffkaaeaaaaaeaaaaadmaabaappiaaaaaoekaabaaoeia
acaaaaadacaaadoaacaakkiaacaaomiaafaaaaadaaaaabiaaaaaffjaaeaakkka
aeaaaaaeaaaaabiaadaakkkaaaaaaajaaaaaaaiaaeaaaaaeaaaaabiaafaakkka
aaaakkjaaaaaaaiaaeaaaaaeaaaaabiaagaakkkaaaaappjaaaaaaaiaabaaaaac
acaaaeoaaaaaaaibaeaaaaaeabaaadoaacaaoejaabaaoekaabaaookaabaaaaac
aaaaaimaabaappiaabaaaaacacaaaioaabaappiaabaaaaacaaaaapoaabaaoeja
ppppaaaafdeieefcheagaaaaeaaaabaajnabaaaafjaaaaaeegiocaaaaaaaaaaa
adaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
aiaaaaaafjaaaaaeegiocaaaadaaaaaaaeaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadpcbabaaaabaaaaaafpaaaaaddcbabaaaacaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagiaaaaacadaaaaaadgaaaaagbcaabaaaaaaaaaaa
ckiacaaaadaaaaaaaaaaaaaadgaaaaagccaabaaaaaaaaaaackiacaaaadaaaaaa
abaaaaaadgaaaaagecaabaaaaaaaaaaackiacaaaadaaaaaaacaaaaaadgaaaaag
icaabaaaaaaaaaaackiacaaaadaaaaaaadaaaaaabbaaaaaibcaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaaeaaaaaabbaaaaaiccaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaafaaaaaabbaaaaaiecaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaagaaaaaabbaaaaaiicaabaaaabaaaaaa
egaobaaaaaaaaaaaegiocaaaacaaaaaaahaaaaaabbaaaaaheccabaaaaaaaaaaa
egaobaaaabaaaaaaegbobaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakiacaaa
adaaaaaaaaaaaaaaabeaaaaaofgdlodpdiaaaaaiccaabaaaaaaaaaaaakiacaaa
adaaaaaaabaaaaaaabeaaaaaofgdlodpdiaaaaaiecaabaaaaaaaaaaaakiacaaa
adaaaaaaacaaaaaaabeaaaaaofgdlodpdiaaaaaiicaabaaaaaaaaaaaakiacaaa
adaaaaaaadaaaaaaabeaaaaaofgdlodpbbaaaaaibcaabaaaabaaaaaaegaobaaa
aaaaaaaaegiocaaaacaaaaaaaeaaaaaabbaaaaaiccaabaaaabaaaaaaegaobaaa
aaaaaaaaegiocaaaacaaaaaaafaaaaaabbaaaaaiecaabaaaabaaaaaaegaobaaa
aaaaaaaaegiocaaaacaaaaaaagaaaaaabbaaaaaiicaabaaaabaaaaaaegaobaaa
aaaaaaaaegiocaaaacaaaaaaahaaaaaabbaaaaahbcaabaaaaaaaaaaaegaobaaa
abaaaaaaegbobaaaaaaaaaaadiaaaaaibcaabaaaabaaaaaabkiacaaaadaaaaaa
aaaaaaaaabeaaaaaofgdlodpdiaaaaaiccaabaaaabaaaaaabkiacaaaadaaaaaa
abaaaaaaabeaaaaaofgdlodpdiaaaaaiecaabaaaabaaaaaabkiacaaaadaaaaaa
acaaaaaaabeaaaaaofgdlodpdiaaaaaiicaabaaaabaaaaaabkiacaaaadaaaaaa
adaaaaaaabeaaaaaofgdlodpbbaaaaaibcaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaaeaaaaaabbaaaaaiccaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaafaaaaaabbaaaaaiecaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaagaaaaaabbaaaaaiicaabaaaacaaaaaaegaobaaaabaaaaaa
egiocaaaacaaaaaaahaaaaaabbaaaaahccaabaaaaaaaaaaaegaobaaaacaaaaaa
egbobaaaaaaaaaaadgaaaaagbcaabaaaabaaaaaadkiacaaaadaaaaaaaaaaaaaa
dgaaaaagccaabaaaabaaaaaadkiacaaaadaaaaaaabaaaaaadgaaaaagecaabaaa
abaaaaaadkiacaaaadaaaaaaacaaaaaadgaaaaagicaabaaaabaaaaaadkiacaaa
adaaaaaaadaaaaaabbaaaaaibcaabaaaacaaaaaaegaobaaaabaaaaaaegiocaaa
acaaaaaaaeaaaaaabbaaaaaiccaabaaaacaaaaaaegaobaaaabaaaaaaegiocaaa
acaaaaaaafaaaaaabbaaaaaiecaabaaaacaaaaaaegaobaaaabaaaaaaegiocaaa
acaaaaaaagaaaaaabbaaaaaiicaabaaaacaaaaaaegaobaaaabaaaaaaegiocaaa
acaaaaaaahaaaaaabbaaaaahicaabaaaaaaaaaaaegaobaaaacaaaaaaegbobaaa
aaaaaaaadgaaaaaflccabaaaaaaaaaaaegambaaaaaaaaaaadiaaaaakfcaabaaa
abaaaaaaagadbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaaaa
dgaaaaaficcabaaaadaaaaaadkaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaahicaabaaaabaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaaadpaaaaaaahdccabaaaadaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadgaaaaafpccabaaaabaaaaaaegbobaaaabaaaaaa
dcaaaaaldccabaaaacaaaaaaegbabaaaacaaaaaaegiacaaaaaaaaaaaacaaaaaa
ogikcaaaaaaaaaaaacaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaa
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
Vector 0 [_TintColor]
SetTexture 0 [_MainTex] 2D 0
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { program.local[0],
		{ 2 } };
TEMP R0;
TEMP R1;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R1, fragment.color.primary, c[0];
MUL R0, R1, R0;
MUL result.color, R0, c[1].x;
END
# 4 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_OFF" }
Vector 0 [_TintColor]
SetTexture 0 [_MainTex] 2D 0
"ps_2_0
dcl_2d s0
def c1, 2.00000000, 0, 0, 0
dcl v0
dcl t0.xy
texld r0, t0, s0
mul r1, v0, c0
mul r0, r1, r0
mul r0, r0, c1.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
BindCB  "$Globals" 0
"ps_4_0
eefiecedmggfklilcgogoppahahdoojbcfakmpbiabaaaaaalmabaaaaadaaaaaa
cmaaaaaakaaaaaaaneaaaaaaejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaaaaaaaeaaaaaaa
diaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
dcbabaaaacaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaaaaaaah
pcaabaaaaaaaaaaaegbobaaaabaaaaaaegbobaaaabaaaaaadiaaaaaipcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
pccabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_OFF" }
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedcnmimopbllpjfifjekfaphchkhconnkoabaaaaaaheacaaaaaeaaaaaa
daaaaaaaoeaaaaaammabaaaaeaacaaaaebgpgodjkmaaaaaakmaaaaaaaaacpppp
hiaaaaaadeaaaaaaabaaciaaaaaadeaaaaaadeaaabaaceaaaaaadeaaaaaaaaaa
aaaaabaaabaaaaaaaaaaaaaaaaacppppbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaadlabpaaaaacaaaaaajaaaaiapkaecaaaaadaaaaapiaabaaoela
aaaioekaafaaaaadabaaapiaaaaaoelaaaaaoekaacaaaaadabaaapiaabaaoeia
abaaoeiaafaaaaadaaaacpiaaaaaoeiaabaaoeiaabaaaaacaaaicpiaaaaaoeia
ppppaaaafdeieefcoaaaaaaaeaaaaaaadiaaaaaafjaaaaaeegiocaaaaaaaaaaa
acaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaaaaaaaahpcaabaaaaaaaaaaaegbobaaaabaaaaaa
egbobaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaaegaobaaaaaaaaaaaegiocaaa
aaaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahpccabaaaaaaaaaaaegaobaaaaaaaaaaa
egaobaaaabaaaaaadoaaaaabejfdeheogmaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaagcaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaakl
epfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_ZBufferParams]
Vector 1 [_TintColor]
Float 2 [_InvFade]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0..2],
		{ 2 } };
TEMP R0;
TEMP R1;
TXP R1.x, fragment.texcoord[1], texture[0], 2D;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MAD R1.x, R1, c[0].z, c[0].w;
RCP R1.x, R1.x;
ADD R1.x, R1, -fragment.texcoord[1].z;
MUL_SAT R1.w, R1.x, c[2].x;
MOV R1.xyz, fragment.color.primary;
MUL R1.w, fragment.color.primary, R1;
MUL R1, R1, c[1];
MUL R0, R1, R0;
MUL result.color, R0, c[3].x;
END
# 11 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SOFTPARTICLES_ON" }
Vector 0 [_ZBufferParams]
Vector 1 [_TintColor]
Float 2 [_InvFade]
SetTexture 0 [_CameraDepthTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c3, 2.00000000, 0, 0, 0
dcl v0
dcl t0.xy
dcl t1
texldp r0, t1, s0
texld r1, t0, s1
mad r0.x, r0, c0.z, c0.w
rcp r0.x, r0.x
add r0.x, r0, -t1.z
mul_sat r0.x, r0, c2
mov_pp r2.xyz, v0
mul_pp r2.w, v0, r0.x
mul r0, r2, c1
mul r0, r0, r1
mul r0, r0, c3.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
Float 48 [_InvFade]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedfiopamkgioepjnkmidmamfmfjefkpdikabaaaaaabaadaaaaadaaaaaa
cmaaaaaaliaaaaaaomaaaaaaejfdeheoieaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaahkaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adadaaaahkaaaaaaabaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaafdfgfpfa
gphdgjhegjgpgoaaedepemepfcaafeeffiedepepfceeaaklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklklfdeieefcbmacaaaaeaaaaaaaihaaaaaafjaaaaae
egiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaaddcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaaaaaaaaaaegbabaaaadaaaaaa
pgbpbaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaackiacaaaabaaaaaa
ahaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaa
aaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaa
aaaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaackbabaiaebaaaaaaadaaaaaa
dicaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaaadaaaaaa
diaaaaahicaabaaaaaaaaaaaakaabaaaaaaaaaaadkbabaaaabaaaaaadgaaaaaf
hcaabaaaaaaaaaaaegbcbaaaabaaaaaaaaaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaaaaaaaaaaegaobaaaaaaaaaaa
egiocaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaacaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahpccabaaaaaaaaaaaegaobaaa
aaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SOFTPARTICLES_ON" }
SetTexture 0 [_CameraDepthTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Vector 16 [_TintColor]
Float 48 [_InvFade]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefieceddjgphnmhhcbjfoemipecllejafilnjflabaaaaaalmaeaaaaaeaaaaaa
daaaaaaaniabaaaapmadaaaaiiaeaaaaebgpgodjkaabaaaakaabaaaaaaacpppp
faabaaaafaaaaaaaadaacmaaaaaafaaaaaaafaaaacaaceaaaaaafaaaabaaaaaa
aaababaaaaaaabaaabaaaaaaaaaaaaaaaaaaadaaabaaabaaaaaaaaaaabaaahaa
abaaacaaaaaaaaaaaaacppppfbaaaaafadaaapkaaaaaaaeaaaaaaaaaaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaaadlabpaaaaac
aaaaaaiaacaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapka
agaaaaacaaaaaiiaacaapplaafaaaaadaaaaadiaaaaappiaacaaoelaecaaaaad
aaaaapiaaaaaoeiaabaioekaecaaaaadabaaapiaabaaoelaaaaioekaaeaaaaae
aaaaabiaacaakkkaaaaaaaiaacaappkaagaaaaacaaaaabiaaaaaaaiaacaaaaad
aaaaabiaaaaaaaiaacaakklbafaaaaadaaaabbiaaaaaaaiaabaaaakaafaaaaad
aaaacbiaaaaaaaiaaaaapplaafaaaaadaaaaabiaaaaaaaiaadaaaakaafaaaaad
aaaaaiiaaaaaaaiaaaaappkaabaaaaacacaaahiaaaaaoelaafaaaaadacaaahia
acaaoeiaaaaaoekaafaaaaadaaaaahiaacaaoeiaadaaaakaafaaaaadaaaacpia
abaaoeiaaaaaoeiaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcbmacaaaa
eaaaaaaaihaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaa
abaaaaaaaiaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaaddcbabaaaacaaaaaagcbaaaadpcbabaaa
adaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaaoaaaaahdcaabaaa
aaaaaaaaegbabaaaadaaaaaapgbpbaaaadaaaaaaefaaaaajpcaabaaaaaaaaaaa
egaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadcaaaaalbcaabaaa
aaaaaaaackiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaadkiacaaaabaaaaaa
ahaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadp
aaaaiadpakaabaaaaaaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaa
ckbabaiaebaaaaaaadaaaaaadicaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaa
akiacaaaaaaaaaaaadaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaaaaaaaaa
dkbabaaaabaaaaaadgaaaaafhcaabaaaaaaaaaaaegbcbaaaabaaaaaaaaaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaa
aaaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaacaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaah
pccabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaadoaaaaabejfdeheo
ieaaaaaaaeaaaaaaaiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaa
apaaaaaaheaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaahkaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaadadaaaahkaaaaaaabaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapapaaaafdfgfpfagphdgjhegjgpgoaaedepemepfcaafeef
fiedepepfceeaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
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
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  AlphaTest Greater 0.01
  ColorMask RGB
  SetTexture [_MainTex] { ConstantColor [_TintColor] combine constant * primary }
  SetTexture [_MainTex] { combine texture * previous double }
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
  Fog {
   Color (0,0,0,0)
  }
  Blend SrcAlpha One
  AlphaTest Greater 0.01
  ColorMask RGB
  SetTexture [_MainTex] { combine texture * primary }
 }
}
}