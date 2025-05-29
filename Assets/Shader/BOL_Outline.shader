ӃShader "BOL/FX/Outline" {
Properties {
 _MainTex ("", 2D) = "" {}
 _BOL ("", 2D) = "" {}
 _NoiseTex ("", 2D) = "" {}
 _Threshold ("", Float) = 0.01
 _Step ("", Float) = 0
 _LineWidth ("", Float) = 0
 _LineSoftness ("", Float) = 1
 _AntiRimParam ("", Float) = 1
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
Vector 9 [_MainTex_TexelSize]
"3.0-!!ARBvp1.0
PARAM c[10] = { { 0 },
		state.matrix.mvp,
		state.matrix.texture[0],
		program.local[9] };
TEMP R0;
MOV R0.zw, c[0].x;
MOV R0.xy, vertex.texcoord[0];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
MOV result.texcoord[0].zw, c[9].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_texture0]
Vector 8 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
def c9, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.zw, c9.x
mov r0.xy, v1
dp4 o1.y, r0, c5
dp4 o1.x, r0, c4
mov o1.zw, c8.xyxy
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
ConstBuffer "UnityPerDrawTexMatrices" 768
Matrix 512 [glstate_matrix_texture0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerDrawTexMatrices" 2
"vs_4_0
eefiecedekgmicmaadbmmjingmiaggelcoceohldabaaaaaafaacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefchaabaaaa
eaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafjaaaaaeegiocaaaacaaaaaaccaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiacaaaacaaaaaacbaaaaaadcaaaaakdccabaaaabaaaaaaegiacaaaacaaaaaa
caaaaaaaagbabaaaabaaaaaaegaabaaaaaaaaaaadgaaaaagmccabaaaabaaaaaa
agiecaaaaaaaaaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_Threshold]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[4] = { program.local[0],
		{ -1, 0, 1, 0.0039215689 },
		{ 999.90002, 0.1, 0, 127 },
		{ 0.0078125 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEX R4, fragment.texcoord[0], texture[0], 2D;
MAD R3.zw, fragment.texcoord[0], c[1].xyxy, fragment.texcoord[0].xyxy;
TEX R0, R3.zwzw, texture[0], 2D;
MUL R1.zw, R0, c[1];
ADD R0.w, R1.z, R1;
MUL R1.xy, R4.zwzw, c[1].zwzw;
MAD R3.xy, fragment.texcoord[0].zwzw, c[1].zyzw, fragment.texcoord[0];
ADD R1.x, R1, R1.y;
MAD R0.z, R1.x, c[2].x, c[2].y;
RCP R5.x, R0.z;
MOV R1.xy, R0;
MAD R0.w, R0, c[2].x, c[2].y;
MUL R1.z, R0.w, R5.x;
MOV R0.xy, R4;
MUL R0.z, R5.x, R0;
TEX R0.w, fragment.texcoord[0], texture[1], 2D;
TEX R1.w, R3.zwzw, texture[1], 2D;
ADD R4, R1, -R0;
ABS R4, R4;
DP4 R1.z, R4, c[2].yyyz;
TEX R2, R3, texture[0], 2D;
MUL R1.xy, R2.zwzw, c[1].zwzw;
ADD R1.x, R1, R1.y;
MAD R1.y, R1.x, c[2].x, c[2];
MUL R4.z, R5.x, R1.y;
TEX R4.w, R3, texture[1], 2D;
MOV R4.xy, R2;
ADD R2, -R0, R4;
ABS R2, R2;
MAD R5.zw, fragment.texcoord[0], c[1].xyyx, fragment.texcoord[0].xyxy;
DP4 R1.y, R2, c[2].yyyz;
TEX R3, R5.zwzw, texture[0], 2D;
MUL R2.xy, R3.zwzw, c[1].zwzw;
SLT R1.x, c[0], R1.z;
ADD R1.z, R2.x, R2.y;
MAD R4.xy, fragment.texcoord[0].zwzw, c[1].yzzw, fragment.texcoord[0];
MAD R1.z, R1, c[2].x, c[2].y;
TEX R2, R4, texture[0], 2D;
MUL R2.zw, R2, c[1];
MUL R3.z, R5.x, R1;
ADD R1.z, R2, R2.w;
TEX R3.w, R5.zwzw, texture[1], 2D;
ADD R6, -R0, R3;
MAD R2.z, R1, c[2].x, c[2].y;
ABS R6, R6;
DP4 R1.z, R6, c[2].yyyz;
TEX R2.w, R4, texture[1], 2D;
MUL R2.z, R5.x, R2;
ADD R5, -R0, R2;
MIN R0.x, R3.w, R2.w;
MIN R0.y, R1.w, R4.w;
MIN R0.y, R0, R0.x;
ABS R5, R5;
DP4 R0.x, R5, c[2].yyyz;
MIN R0.y, R0.w, R0;
SLT R1.w, c[0].x, R0.x;
SLT R1.y, c[0].x, R1;
SLT R1.z, c[0].x, R1;
ABS R0.x, R0.y;
CMP R0, -R0.x, R1, c[2].w;
MUL result.color, R0, c[3].x;
END
# 61 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_Threshold]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c1, -1.00000000, 0.00000000, 1.00000000, 0.00392157
def c2, 999.90002441, 0.10000000, 0.00000000, 127.00000000
def c3, 0.00781250, 0, 0, 0
dcl_texcoord0 v0
mad r2.xy, v0.zwzw, c1, v0
texld r1, v0, s0
mul r0.xy, r1.zwzw, c1.zwzw
texld r4, r2, s0
add r0.z, r0.x, r0.y
mul r0.xy, r4.zwzw, c1.zwzw
mad r0.z, r0, c2.x, c2.y
rcp r6.x, r0.z
add r0.x, r0, r0.y
mad r3.xy, v0.zwzw, c1.zyzw, v0
mad r0.x, r0, c2, c2.y
mul r1.z, r6.x, r0
mul r5.z, r0.x, r6.x
texld r0, r3, s0
mul r0.zw, r0, c1
texld r4.w, r3, s1
mov r5.xy, r4
add r0.w, r0.z, r0
mad r0.w, r0, c2.x, c2.y
texld r1.w, v0, s1
texld r5.w, r2, s1
add r2, r5, -r1
abs r2, r2
dp4 r0.z, r2, c2.yyyz
mov r4.xy, r0
add r2.x, -r0.z, c0
mul r4.z, r6.x, r0.w
add r0, -r1, r4
mad r3.xy, v0.zwzw, c1.yxzw, v0
cmp r4.x, r2, c1.y, c1.z
abs r0, r0
dp4 r2.x, r0, c2.yyyz
texld r0, r3, s0
mul r0.zw, r0, c1
add r0.z, r0, r0.w
add r2.x, -r2, c0
mad r0.z, r0, c2.x, c2.y
texld r0.w, r3, s1
mul r0.z, r6.x, r0
add r3, -r1, r0
cmp r4.y, r2.x, c1, c1.z
mad r5.xy, v0.zwzw, c1.yzzw, v0
texld r2, r5, s0
mul r2.zw, r2, c1
add r0.x, r2.z, r2.w
mad r0.y, r0.x, c2.x, c2
abs r3, r3
dp4 r0.x, r3, c2.yyyz
add r0.x, -r0, c0
cmp r4.z, r0.x, c1.y, c1
mul r2.z, r6.x, r0.y
texld r2.w, r5, s1
add r3, -r1, r2
abs r3, r3
min r0.y, r0.w, r2.w
min r0.x, r5.w, r4.w
min r0.x, r0, r0.y
dp4 r0.z, r3, c2.yyyz
add r0.y, -r0.z, c0.x
min r0.x, r1.w, r0
cmp r4.w, r0.y, c1.y, c1.z
abs r0.x, r0
cmp r0, -r0.x, c2.w, r4
mul oC0, r0, c3.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_CameraDepthNormalsTexture] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Float 32 [_Threshold]
BindCB  "$Globals" 0
"ps_4_0
eefiecedfmnoikmogjbochfllghbhijjmcinbdopabaaaaaaaaaiaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefceaahaaaa
eaaaaaaanaabaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacafaaaaaadcaaaaampcaabaaaaaaaaaaaogbobaaa
abaaaaaaaceaaaaaaaaaialpaaaaaaaaaaaaiadpaaaaaaaaegbebaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
abaaaaaaapaaaaakicaabaaaabaaaaaaogakbaaaabaaaaaaaceaaaaaaaaaiadp
ibiaiadlaaaaaaaaaaaaaaaadcaaaaajicaabaaaabaaaaaadkaabaaaabaaaaaa
abeaaaaajkpjhjeeabeaaaaamnmmmmdnefaaaaajpcaabaaaacaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaapaaaaakicaabaaaacaaaaaa
ogakbaaaacaaaaaaaceaaaaaaaaaiadpibiaiadlaaaaaaaaaaaaaaaadcaaaaaj
icaabaaaacaaaaaadkaabaaaacaaaaaaabeaaaaajkpjhjeeabeaaaaamnmmmmdn
aoaaaaahecaabaaaabaaaaaadkaabaaaabaaaaaadkaabaaaacaaaaaadgaaaaaf
ecaabaaaacaaaaaaabeaaaaaaaaaiadpaaaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaiaebaaaaaaacaaaaaabaaaaaalbcaabaaaabaaaaaaegacbaia
ibaaaaaaabaaaaaaaceaaaaamnmmmmdnmnmmmmdnmnmmmmdnaaaaaaaadbaaaaai
bcaabaaaabaaaaaaakiacaaaaaaaaaaaacaaaaaaakaabaaaabaaaaaaabaaaaah
bcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaa
adaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaapaaaaak
icaabaaaadaaaaaaogakbaaaadaaaaaaaceaaaaaaaaaiadpibiaiadlaaaaaaaa
aaaaaaaadcaaaaajicaabaaaadaaaaaadkaabaaaadaaaaaaabeaaaaajkpjhjee
abeaaaaamnmmmmdnaoaaaaahecaabaaaadaaaaaadkaabaaaadaaaaaadkaabaaa
acaaaaaaaaaaaaaihcaabaaaadaaaaaaegacbaiaebaaaaaaacaaaaaaegacbaaa
adaaaaaabaaaaaalbcaabaaaadaaaaaaegacbaiaibaaaaaaadaaaaaaaceaaaaa
mnmmmmdnmnmmmmdnmnmmmmdnaaaaaaaadbaaaaaibcaabaaaadaaaaaaakiacaaa
aaaaaaaaacaaaaaaakaabaaaadaaaaaaabaaaaahccaabaaaabaaaaaaakaabaaa
adaaaaaaabeaaaaaaaaaiadpdcaaaaampcaabaaaadaaaaaaogbobaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaialpaaaaaaaaaaaaiadpegbebaaaabaaaaaaefaaaaaj
pcaabaaaaeaaaaaaegaabaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
apaaaaakicaabaaaaeaaaaaaogakbaaaaeaaaaaaaceaaaaaaaaaiadpibiaiadl
aaaaaaaaaaaaaaaadcaaaaajicaabaaaaeaaaaaadkaabaaaaeaaaaaaabeaaaaa
jkpjhjeeabeaaaaamnmmmmdnaoaaaaahecaabaaaaeaaaaaadkaabaaaaeaaaaaa
dkaabaaaacaaaaaaaaaaaaaihcaabaaaaeaaaaaaegacbaiaebaaaaaaacaaaaaa
egacbaaaaeaaaaaabaaaaaalbcaabaaaaeaaaaaaegacbaiaibaaaaaaaeaaaaaa
aceaaaaamnmmmmdnmnmmmmdnmnmmmmdnaaaaaaaadbaaaaaibcaabaaaaeaaaaaa
akiacaaaaaaaaaaaacaaaaaaakaabaaaaeaaaaaaabaaaaahecaabaaaabaaaaaa
akaabaaaaeaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaaeaaaaaaogakbaaa
adaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaapaaaaakicaabaaaaeaaaaaa
ogakbaaaaeaaaaaaaceaaaaaaaaaiadpibiaiadlaaaaaaaaaaaaaaaadcaaaaaj
icaabaaaaeaaaaaadkaabaaaaeaaaaaaabeaaaaajkpjhjeeabeaaaaamnmmmmdn
aoaaaaahecaabaaaaeaaaaaadkaabaaaaeaaaaaadkaabaaaacaaaaaaaaaaaaai
hcaabaaaacaaaaaaegacbaiaebaaaaaaacaaaaaaegacbaaaaeaaaaaabaaaaaal
bcaabaaaacaaaaaaegacbaiaibaaaaaaacaaaaaaaceaaaaamnmmmmdnmnmmmmdn
mnmmmmdnaaaaaaaadbaaaaaibcaabaaaacaaaaaaakiacaaaaaaaaaaaacaaaaaa
akaabaaaacaaaaaaabaaaaahicaabaaaabaaaaaaakaabaaaacaaaaaaabeaaaaa
aaaaiadpdiaaaaakpcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaadm
aaaaaadmaaaaaadmaaaaaadmefaaaaajpcaabaaaacaaaaaaegaabaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaa
aaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaddaaaaahbcaabaaaaaaaaaaa
dkaabaaaaaaaaaaadkaabaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaegaabaaa
adaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaadaaaaaa
ogakbaaaadaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaddaaaaahccaabaaa
aaaaaaaadkaabaaaacaaaaaadkaabaaaadaaaaaaddaaaaahbcaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaddaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkaabaaaacaaaaaabiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaaaaadhaaaaampccabaaaaaaaaaaaagaabaaaaaaaaaaa
aceaaaaaaaaahodpaaaahodpaaaahodpaaaahodpegaobaaaabaaaaaadoaaaaab
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
Vector 9 [_MainTex_TexelSize]
"3.0-!!ARBvp1.0
PARAM c[10] = { { 0 },
		state.matrix.mvp,
		state.matrix.texture[0],
		program.local[9] };
TEMP R0;
MOV R0.zw, c[0].x;
MOV R0.xy, vertex.texcoord[0];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
MOV result.texcoord[0].zw, c[9].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_texture0]
Vector 8 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
def c9, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.zw, c9.x
mov r0.xy, v1
dp4 o1.y, r0, c5
dp4 o1.x, r0, c4
mov o1.zw, c8.xyxy
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
ConstBuffer "UnityPerDrawTexMatrices" 768
Matrix 512 [glstate_matrix_texture0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerDrawTexMatrices" 2
"vs_4_0
eefiecedekgmicmaadbmmjingmiaggelcoceohldabaaaaaafaacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefchaabaaaa
eaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafjaaaaaeegiocaaaacaaaaaaccaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiacaaaacaaaaaacbaaaaaadcaaaaakdccabaaaabaaaaaaegiacaaaacaaaaaa
caaaaaaaagbabaaaabaaaaaaegaabaaaaaaaaaaadgaaaaagmccabaaaabaaaaaa
agiecaaaaaaaaaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_Step]
SetTexture 0 [_BOL] 2D 0
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[3] = { program.local[0],
		{ 128, 0, 1, 126 },
		{ 0, -1, 0.0078125 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R1, R0, c[1].x;
MUL R2.xy, fragment.texcoord[0].zwzw, c[0].x;
MAD R2.zw, R2.xyxy, c[1].xyyz, fragment.texcoord[0].xyxy;
TEX R0.w, R2.zwzw, texture[0], 2D;
MUL R0.x, R0.w, c[1];
ABS R0.y, R1.w;
SLT R0.z, c[1].y, R0.x;
CMP R0.y, -R0, c[1], c[1].z;
MUL R0.y, R0, R0.z;
SGE R0.w, c[1], R0.x;
MUL R0.z, R0.y, R0.w;
ADD R0.w, R0.x, c[0].x;
MAD R0.xy, R2, c[2], fragment.texcoord[0];
CMP R0.w, -R0.z, R0, R1;
TEX R0.z, R0, texture[0], 2D;
MUL R0.x, R0.z, c[1];
ABS R0.y, R1.z;
SLT R0.z, c[1].y, R0.x;
CMP R0.y, -R0, c[1], c[1].z;
MUL R0.y, R0, R0.z;
SGE R1.w, c[1], R0.x;
MUL R0.z, R0.y, R1.w;
ADD R1.w, R0.x, c[0].x;
MAD R0.xy, R2, c[2].yxzw, fragment.texcoord[0];
TEX R0.x, R0, texture[0], 2D;
ABS R0.y, R1.x;
CMP R0.z, -R0, R1.w, R1;
MUL R0.x, R0, c[1];
SLT R1.z, c[1].y, R0.x;
SGE R1.w, c[1], R0.x;
CMP R0.y, -R0, c[1], c[1].z;
MUL R0.y, R0, R1.z;
MUL R2.z, R0.y, R1.w;
MAD R1.zw, R2.xyxy, c[1].xyzy, fragment.texcoord[0].xyxy;
ADD R0.x, R0, c[0];
TEX R0.y, R1.zwzw, texture[0], 2D;
CMP R0.x, -R2.z, R0, R1;
MUL R1.x, R0.y, c[1];
ABS R0.y, R1;
SLT R1.z, c[1].y, R1.x;
CMP R0.y, -R0, c[1], c[1].z;
MUL R0.y, R0, R1.z;
SGE R1.z, c[1].w, R1.x;
ADD R1.x, R1, c[0];
MUL R0.y, R0, R1.z;
CMP R0.y, -R0, R1.x, R1;
MUL result.color, R0, c[2].z;
END
# 48 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_Step]
SetTexture 0 [_BOL] 2D 0
"ps_3_0
dcl_2d s0
def c1, 128.00000000, 1.00000000, 0.00000000, 126.00000000
def c2, 0.00000000, -1.00000000, 0.00781250, 0
dcl_texcoord0 v0
mul r2.xy, v0.zwzw, c0.x
mad r0.xy, r2, c1.zyzw, v0
texld r0.w, r0, s0
mul r0.x, r0.w, c1
add r0.w, -r0.x, c1
texld r1, v0, s0
mul r1, r1, c1.x
abs r0.y, r1.w
cmp r0.z, -r0.x, c1, c1.y
cmp r0.y, -r0, c1, c1.z
mul_pp r0.y, r0, r0.z
cmp r0.w, r0, c1.y, c1.z
mul_pp r0.z, r0.y, r0.w
add r0.w, r0.x, c0.x
mad r0.xy, r2, c2, v0
cmp r0.w, -r0.z, r1, r0
texld r0.z, r0, s0
mul r0.x, r0.z, c1
abs r0.y, r1.z
add r1.w, -r0.x, c1
cmp r0.z, -r0.x, c1, c1.y
cmp r0.y, -r0, c1, c1.z
mul_pp r0.y, r0, r0.z
cmp r1.w, r1, c1.y, c1.z
mul_pp r0.z, r0.y, r1.w
add r1.w, r0.x, c0.x
mad r0.xy, r2, c2.yxzw, v0
texld r0.x, r0, s0
abs r0.y, r1.x
cmp r0.z, -r0, r1, r1.w
mul r0.x, r0, c1
add r1.w, -r0.x, c1
cmp r1.z, -r0.x, c1, c1.y
cmp r0.y, -r0, c1, c1.z
mul_pp r0.y, r0, r1.z
cmp r1.w, r1, c1.y, c1.z
mul_pp r0.y, r0, r1.w
add r0.x, r0, c0
cmp r0.x, -r0.y, r1, r0
mad r2.xy, r2, c1.yzzw, v0
texld r0.y, r2, s0
mul r1.z, r0.y, c1.x
abs r1.x, r1.y
cmp r0.y, -r1.x, c1, c1.z
cmp r1.x, -r1.z, c1.z, c1.y
add r1.w, -r1.z, c1
mul_pp r0.y, r0, r1.x
cmp r1.x, r1.w, c1.y, c1.z
add r1.z, r1, c0.x
mul_pp r0.y, r0, r1.x
cmp r0.y, -r0, r1, r1.z
mul oC0, r0, c2.z
"
}
SubProgram "d3d11 " {
SetTexture 0 [_BOL] 2D 0
ConstBuffer "$Globals" 64
Float 36 [_Step]
BindCB  "$Globals" 0
"ps_4_0
eefiecedilhbjdahajffccmnipgemoajkfjliffpabaaaaaapmafaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdmafaaaa
eaaaaaaaepabaaaafjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaadgaaaaaigcaabaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaiadpaaaaaaaaaaaaaaaadgaaaaagjcaabaaaaaaaaaaa
fgifcaaaaaaaaaaaacaaaaaadiaaaaahpcaabaaaabaaaaaabgaebaaaaaaaaaaa
ogbobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaalgaobaaa
aaaaaaaaegbebaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaaaaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaa
bkaabaaaabaaaaaaabeaaaaaaaaaaaedbkiacaaaaaaaaaaaacaaaaaabnaaaaah
ccaabaaaaaaaaaaaabeaaaaaaaaahmdpbkaabaaaabaaaaaadbaaaaahecaabaaa
aaaaaaaaabeaaaaaaaaaaaaabkaabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabiaaaaakpcaabaaa
acaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
diaaaaakpcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaedaaaaaaed
aaaaaaedaaaaaaedabaaaaahecaabaaaaaaaaaaackaabaaaaaaaaaaabkaabaaa
acaaaaaaabaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaackaabaaaaaaaaaaa
dhaaaaajccaabaaaadaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaa
abaaaaaabnaaaaahbcaabaaaaaaaaaaaabeaaaaaaaaahmdpdkaabaaaaaaaaaaa
dbaaaaahccaabaaaaaaaaaaaabeaaaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaak
ecaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaaedbkiacaaaaaaaaaaa
acaaaaaaabaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaadkaabaaaacaaaaaa
abaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadhaaaaaj
icaabaaaadaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaadkaabaaaabaaaaaa
diaaaaaipcaabaaaaaaaaaaaogbobaaaabaaaaaafgifcaaaaaaaaaaaacaaaaaa
dcaaaaampcaabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaialpaaaaaaaa
aaaaaaaaaaaaialpegbebaaaabaaaaaaefaaaaajpcaabaaaaeaaaaaaegaabaaa
aaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogakbaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadbaaaaahbcaabaaa
aaaaaaaaabeaaaaaaaaaaaaaakaabaaaaeaaaaaaabaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakaabaaaacaaaaaabnaaaaahccaabaaaaaaaaaaaabeaaaaa
aaaahmdpakaabaaaaeaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaaaeaaaaaa
abeaaaaaaaaaaaedbkiacaaaaaaaaaaaacaaaaaaabaaaaahbcaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakaabaaaaaaaaaaadhaaaaajbcaabaaaadaaaaaaakaabaaa
aaaaaaaadkaabaaaaaaaaaaaakaabaaaabaaaaaadbaaaaahbcaabaaaaaaaaaaa
abeaaaaaaaaaaaaackaabaaaaaaaaaaaabaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaackaabaaaacaaaaaabnaaaaahccaabaaaaaaaaaaaabeaaaaaaaaahmdp
ckaabaaaaaaaaaaadcaaaaakecaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaaedbkiacaaaaaaaaaaaacaaaaaaabaaaaahbcaabaaaaaaaaaaabkaabaaa
aaaaaaaaakaabaaaaaaaaaaadhaaaaajecaabaaaadaaaaaaakaabaaaaaaaaaaa
ckaabaaaaaaaaaaackaabaaaabaaaaaadiaaaaakpccabaaaaaaaaaaaegaobaaa
adaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaadmaaaaaadmdoaaaaab"
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
Vector 9 [_MainTex_TexelSize]
"3.0-!!ARBvp1.0
PARAM c[10] = { { 0 },
		state.matrix.mvp,
		state.matrix.texture[0],
		program.local[9] };
TEMP R0;
MOV R0.zw, c[0].x;
MOV R0.xy, vertex.texcoord[0];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
MOV result.texcoord[0].zw, c[9].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_texture0]
Vector 8 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
def c9, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.zw, c9.x
mov r0.xy, v1
dp4 o1.y, r0, c5
dp4 o1.x, r0, c4
mov o1.zw, c8.xyxy
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
ConstBuffer "UnityPerDrawTexMatrices" 768
Matrix 512 [glstate_matrix_texture0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerDrawTexMatrices" 2
"vs_4_0
eefiecedekgmicmaadbmmjingmiaggelcoceohldabaaaaaafaacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefchaabaaaa
eaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafjaaaaaeegiocaaaacaaaaaaccaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiacaaaacaaaaaacbaaaaaadcaaaaakdccabaaaabaaaaaaegiacaaaacaaaaaa
caaaaaaaagbabaaaabaaaaaaegaabaaaaaaaaaaadgaaaaagmccabaaaabaaaaaa
agiecaaaaaaaaaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
SetTexture 0 [_BOL] 2D 0
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[2] = { { 128, 1, 0, -1 },
		{ 0.0078125 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0, R0, c[0].x;
ADD R1.x, R0.w, -c[0].y;
MUL R1.zw, fragment.texcoord[0], R0.w;
MAD R1.zw, R1, c[0].xyzy, fragment.texcoord[0].xyxy;
TEX R2.xy, R1.zwzw, texture[0], 2D;
MUL R2.xy, R2, c[0].x;
SGE R2.zw, R2.xyxy, c[0].y;
ADD R2.zw, -R2, c[0].y;
MUL R1.xy, fragment.texcoord[0].zwzw, R1.x;
MAD R1.xy, R1, c[0].zyzw, fragment.texcoord[0];
TEX R1.xy, R1, texture[0], 2D;
MUL R1.zw, R1.xyxy, c[0].x;
SGE R1.xy, R1.zwzw, c[0].y;
ADD R1.xy, -R1, c[0].y;
MAD R1.xy, R1, c[0].x, R1.zwzw;
MIN R3.x, R1, R1.y;
MAD R2.xy, R2.zwzw, c[0].x, R2;
MIN R1.z, R2.x, R2.y;
ADD R3.y, R3.x, R1.z;
ADD R1.x, R0.z, -c[0].y;
MUL R1.zw, fragment.texcoord[0], R0.z;
MAD R1.zw, R1, c[0], fragment.texcoord[0].xyxy;
TEX R2.xy, R1.zwzw, texture[0], 2D;
MUL R2.xy, R2, c[0].x;
SGE R2.zw, R2.xyxy, c[0].y;
ADD R2.zw, -R2, c[0].y;
MUL R1.xy, fragment.texcoord[0].zwzw, R1.x;
MAD R1.xy, R1, c[0].zwzw, fragment.texcoord[0];
TEX R1.xy, R1, texture[0], 2D;
MUL R1.zw, R1.xyxy, c[0].x;
SGE R1.xy, R1.zwzw, c[0].y;
ADD R1.xy, -R1, c[0].y;
MAD R1.xy, R1, c[0].x, R1.zwzw;
MAD R2.xy, R2.zwzw, c[0].x, R2;
MIN R1.x, R1, R1.y;
MIN R1.z, R2.x, R2.y;
ADD R2.x, R1, R1.z;
ADD R1.z, R3.y, -c[0].y;
ADD R1.y, R3.x, -c[0];
RCP R1.z, R1.z;
MAX R1.y, R1, c[0].z;
MUL R1.y, R1, R1.z;
SLT R1.w, c[0].z, R0;
MAD R1.w, R1.y, R1, R0;
ADD R0.w, R1.x, -c[0].y;
ADD R1.y, R2.x, -c[0];
RCP R1.x, R1.y;
MAX R0.w, R0, c[0].z;
MUL R0.w, R0, R1.x;
SLT R1.y, c[0].z, R0.z;
MAD R1.z, R0.w, R1.y, R0;
ADD R0.z, R0.x, -c[0].y;
MUL R1.xy, fragment.texcoord[0].zwzw, R0.x;
MAD R1.xy, R1, c[0].wzzw, fragment.texcoord[0];
TEX R2.zw, R1, texture[0], 2D;
MUL R2.xy, R2.zwzw, c[0].x;
SGE R2.zw, R2.xyxy, c[0].y;
ADD R2.zw, -R2, c[0].y;
MUL R0.zw, fragment.texcoord[0], R0.z;
MAD R0.zw, R0, c[0].xywz, fragment.texcoord[0].xyxy;
TEX R0.zw, R0.zwzw, texture[0], 2D;
MUL R1.xy, R0.zwzw, c[0].x;
SGE R0.zw, R1.xyxy, c[0].y;
ADD R0.zw, -R0, c[0].y;
MAD R0.zw, R0, c[0].x, R1.xyxy;
MIN R3.x, R0.z, R0.w;
MAD R2.xy, R2.zwzw, c[0].x, R2;
MIN R1.x, R2, R2.y;
ADD R3.y, R3.x, R1.x;
ADD R0.z, R0.y, -c[0].y;
MUL R1.xy, fragment.texcoord[0].zwzw, R0.y;
MAD R1.xy, R1, c[0].yzzw, fragment.texcoord[0];
TEX R2.zw, R1, texture[0], 2D;
MUL R2.xy, R2.zwzw, c[0].x;
SGE R2.zw, R2.xyxy, c[0].y;
MUL R0.zw, fragment.texcoord[0], R0.z;
MAD R0.zw, R0, c[0].xyyz, fragment.texcoord[0].xyxy;
TEX R0.zw, R0.zwzw, texture[0], 2D;
MUL R1.xy, R0.zwzw, c[0].x;
SGE R0.zw, R1.xyxy, c[0].y;
ADD R2.zw, -R2, c[0].y;
ADD R0.zw, -R0, c[0].y;
MAD R0.zw, R0, c[0].x, R1.xyxy;
MAD R2.xy, R2.zwzw, c[0].x, R2;
MIN R1.x, R2, R2.y;
MIN R0.z, R0, R0.w;
ADD R0.w, R0.z, R1.x;
ADD R1.y, R3, -c[0];
ADD R1.x, R3, -c[0].y;
RCP R1.y, R1.y;
MAX R1.x, R1, c[0].z;
MUL R1.x, R1, R1.y;
SLT R2.x, c[0].z, R0;
MAD R1.x, R1, R2, R0;
ADD R0.x, R0.z, -c[0].y;
ADD R0.w, R0, -c[0].y;
RCP R0.z, R0.w;
MAX R0.x, R0, c[0].z;
SLT R0.w, c[0].z, R0.y;
MUL R0.x, R0, R0.z;
MAD R1.y, R0.x, R0.w, R0;
MUL result.color, R1, c[1].x;
END
# 103 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
SetTexture 0 [_BOL] 2D 0
"ps_3_0
dcl_2d s0
def c0, 128.00000000, -1.00000000, 0.00000000, 1.00000000
def c1, 0.00781250, 0, 0, 0
dcl_texcoord0 v0
texld r0, v0, s0
mul r1, r0, c0.x
mul r0.zw, v0, r1.w
add r0.x, r1.w, c0.y
mad r2.xy, r0.zwzw, c0.zwzw, v0
texld r2.xy, r2, s0
mad r2.zw, r2.xyxy, c0.x, c0.y
cmp r2.zw, r2, c0.z, c0.x
mul r0.xy, v0.zwzw, r0.x
mad r0.xy, r0, c0.zwzw, v0
texld r0.xy, r0, s0
mad r0.zw, r0.xyxy, c0.x, c0.y
cmp r0.zw, r0, c0.z, c0.x
mad r0.xy, r0, c0.x, r0.zwzw
min r3.x, r0, r0.y
mad r2.xy, r2, c0.x, r2.zwzw
min r0.z, r2.x, r2.y
add r3.y, r3.x, r0.z
mul r0.zw, v0, r1.z
add r0.x, r1.z, c0.y
mad r2.xy, r0.zwzw, c0.zyzw, v0
texld r2.xy, r2, s0
mad r2.zw, r2.xyxy, c0.x, c0.y
cmp r2.zw, r2, c0.z, c0.x
mul r0.xy, v0.zwzw, r0.x
mad r0.xy, r0, c0.zyzw, v0
texld r0.xy, r0, s0
mad r0.zw, r0.xyxy, c0.x, c0.y
cmp r0.zw, r0, c0.z, c0.x
mad r0.xy, r0, c0.x, r0.zwzw
mad r2.xy, r2, c0.x, r2.zwzw
min r0.x, r0, r0.y
min r0.z, r2.x, r2.y
add r2.x, r0, r0.z
add r0.z, r3.y, c0.y
add r0.y, r3.x, c0
add r0.x, r0, c0.y
cmp r0.w, -r1, c0.z, c0
rcp r0.z, r0.z
max r0.y, r0, c0.z
mul r0.y, r0, r0.z
mad r2.w, r0.y, r0, r1
add r0.y, r2.x, c0
cmp r0.z, -r1, c0, c0.w
rcp r0.y, r0.y
max r0.x, r0, c0.z
mul r0.x, r0, r0.y
mad r2.z, r0.x, r0, r1
mul r0.zw, v0, r1.x
mad r2.xy, r0.zwzw, c0.yzzw, v0
texld r1.zw, r2, s0
mad r2.xy, r1.zwzw, c0.x, c0.y
cmp r2.xy, r2, c0.z, c0.x
add r0.x, r1, c0.y
mul r0.xy, v0.zwzw, r0.x
mad r0.xy, r0, c0.yzzw, v0
texld r0.zw, r0, s0
mad r0.xy, r0.zwzw, c0.x, c0.y
cmp r0.xy, r0, c0.z, c0.x
mad r0.xy, r0.zwzw, c0.x, r0
mad r1.zw, r1, c0.x, r2.xyxy
min r3.x, r0, r0.y
min r0.z, r1, r1.w
add r3.y, r3.x, r0.z
mul r0.zw, v0, r1.y
mad r2.xy, r0.zwzw, c0.wzzw, v0
texld r1.zw, r2, s0
mad r2.xy, r1.zwzw, c0.x, c0.y
cmp r2.xy, r2, c0.z, c0.x
add r0.x, r1.y, c0.y
mul r0.xy, v0.zwzw, r0.x
mad r0.xy, r0, c0.wzzw, v0
texld r0.zw, r0, s0
mad r0.xy, r0.zwzw, c0.x, c0.y
cmp r0.xy, r0, c0.z, c0.x
mad r0.xy, r0.zwzw, c0.x, r0
mad r1.zw, r1, c0.x, r2.xyxy
min r0.z, r1, r1.w
min r0.x, r0, r0.y
add r0.y, r0.x, r0.z
add r0.w, r3.y, c0.y
add r0.z, r3.x, c0.y
add r0.y, r0, c0
add r0.x, r0, c0.y
rcp r0.w, r0.w
max r0.z, r0, c0
mul r0.z, r0, r0.w
cmp r1.z, -r1.x, c0, c0.w
mad r2.x, r0.z, r1.z, r1
rcp r0.y, r0.y
max r0.x, r0, c0.z
cmp r0.z, -r1.y, c0, c0.w
mul r0.x, r0, r0.y
mad r2.y, r0.x, r0.z, r1
mul oC0, r2, c1.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_BOL] 2D 0
"ps_4_0
eefiecedefmpinkpoodiphmdggahflcjdnincjiaabaaaaaabmamaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfmalaaaa
eaaaaaaanhacaaaafkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaac
agaaaaaadiaaaaakpcaabaaaaaaaaaaaogbobaaaabaaaaaaaceaaaaaaaaaialp
aaaaaaaaaaaaiadpaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaappcaabaaaacaaaaaaegaobaaa
abaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaedaaaaaaedaceaaaaaaaaaialp
aaaaialpaaaaialpaaaaialpdcaaaaajpcaabaaaadaaaaaaegaobaaaaaaaaaaa
agafbaaaacaaaaaaegbebaaaabaaaaaaefaaaaajpcaabaaaaeaaaaaaegaabaaa
adaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaadaaaaaa
ogakbaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabnaaaaakdcaabaaa
acaaaaaaogakbaaaaeaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaaaaaaaaaaaa
dhaaaaapdcaabaaaacaaaaaaegaabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaaaaaaaaaadcaaaaam
dcaabaaaacaaaaaaogakbaaaaeaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaa
aaaaaaaaegaabaaaacaaaaaaddaaaaahbcaabaaaacaaaaaabkaabaaaacaaaaaa
akaabaaaacaaaaaadiaaaaakpcaabaaaaeaaaaaaegaobaaaabaaaaaaaceaaaaa
aaaaaaedaaaaaaedaaaaaaedaaaaaaeddbaaaaakpcaabaaaabaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaegaobaaaabaaaaaaabaaaaakpcaabaaa
abaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
dcaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaaagafbaaaaeaaaaaaegbebaaa
abaaaaaaefaaaaajpcaabaaaafaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaabnaaaaakdcaabaaaaaaaaaaaogakbaaaafaaaaaa
aceaaaaaaaaaaadmaaaaaadmaaaaaaaaaaaaaaaadhaaaaapdcaabaaaaaaaaaaa
egaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaceaaaaa
aaaaaaedaaaaaaedaaaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaa
afaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaaaaaaaaaaegaabaaaaaaaaaaa
ddaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaaaaaaaaahccaabaaa
aaaaaaaaakaabaaaacaaaaaaabeaaaaaaaaaialpdeaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaialpaoaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaajbcaabaaaafaaaaaaakaabaaaaaaaaaaaakaabaaa
abaaaaaaakaabaaaaeaaaaaabnaaaaakdcaabaaaaaaaaaaaogakbaaaadaaaaaa
aceaaaaaaaaaaadmaaaaaadmaaaaaaaaaaaaaaaadhaaaaapdcaabaaaaaaaaaaa
egaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaceaaaaa
aaaaaaedaaaaaaedaaaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaa
adaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaaaaaaaaaaegaabaaaaaaaaaaa
ddaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaah
ccaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaialpdeaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaaaaabnaaaaakdcaabaaaacaaaaaa
ogakbaaaaaaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaaaaaaaaaaaadhaaaaap
dcaabaaaacaaaaaaegaabaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaaaaaaaaaadcaaaaammcaabaaa
aaaaaaaakgaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaedaaaaaaed
agaebaaaacaaaaaaddaaaaahecaabaaaaaaaaaaadkaabaaaaaaaaaaackaabaaa
aaaaaaaaaaaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaialpaoaaaaah
bcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaajccaabaaa
afaaaaaaakaabaaaaaaaaaaabkaabaaaabaaaaaabkaabaaaaeaaaaaadiaaaaak
pcaabaaaaaaaaaaaogbobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaialpaaaaaaaa
aaaaiadpdcaaaaajpcaabaaaacaaaaaaegaobaaaaaaaaaaakgapbaaaacaaaaaa
egbebaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaakgapbaaa
aeaaaaaaegbebaaaabaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaacaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaa
acaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaabnaaaaakdcaabaaaabaaaaaa
egaabaaaadaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaaaaaaaaaaaadhaaaaap
dcaabaaaabaaaaaaegaabaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaaaaaaaaaadcaaaaamdcaabaaa
abaaaaaaegaabaaaadaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaaaaaaaaaa
egaabaaaabaaaaaaddaaaaahbcaabaaaabaaaaaabkaabaaaabaaaaaaakaabaaa
abaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaaaaaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaabnaaaaakmcaabaaaaaaaaaaaagaebaaaadaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaadmaaaaaadmdhaaaaapmcaabaaaaaaaaaaa
kgaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaedaaaaaaeddcaaaaammcaabaaaaaaaaaaaagaebaaa
adaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaedaaaaaaedkgaobaaaaaaaaaaa
ddaaaaahecaabaaaaaaaaaaadkaabaaaaaaaaaaackaabaaaaaaaaaaaaaaaaaah
ecaabaaaaaaaaaaackaabaaaaaaaaaaaakaabaaaabaaaaaaaaaaaaahicaabaaa
aaaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaialpdeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaaaaaaaaaaaahecaabaaaaaaaaaaackaabaaa
aaaaaaaaabeaaaaaaaaaialpaoaaaaahecaabaaaaaaaaaaadkaabaaaaaaaaaaa
ckaabaaaaaaaaaaadcaaaaajecaabaaaafaaaaaackaabaaaaaaaaaaackaabaaa
abaaaaaackaabaaaaeaaaaaabnaaaaakmcaabaaaaaaaaaaaagaebaaaacaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaadmaaaaaadmdhaaaaapmcaabaaaaaaaaaaa
kgaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaedaaaaaaeddcaaaaammcaabaaaaaaaaaaaagaebaaa
acaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaedaaaaaaedkgaobaaaaaaaaaaa
bnaaaaakdcaabaaaabaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaadmaaaaaadm
aaaaaaaaaaaaaaaadhaaaaapdcaabaaaabaaaaaaegaabaaaabaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaaa
aaaaaaaadcaaaaamdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaed
aaaaaaedaaaaaaaaaaaaaaaaegaabaaaabaaaaaaddaaaaahfcaabaaaaaaaaaaa
fgahbaaaaaaaaaaaagacbaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaackaabaaaaaaaaaaaaaaaaaakdcaabaaaaaaaaaaaigaabaaaaaaaaaaa
aceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaadeaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaaaaaaoaaaaahbcaabaaaaaaaaaaabkaabaaa
aaaaaaaaakaabaaaaaaaaaaadcaaaaajicaabaaaafaaaaaaakaabaaaaaaaaaaa
dkaabaaaabaaaaaadkaabaaaaeaaaaaadiaaaaakpccabaaaaaaaaaaaegaobaaa
afaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaadmaaaaaadmdoaaaaab"
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
Vector 9 [_MainTex_TexelSize]
"3.0-!!ARBvp1.0
PARAM c[10] = { { 0 },
		state.matrix.mvp,
		state.matrix.texture[0],
		program.local[9] };
TEMP R0;
MOV R0.zw, c[0].x;
MOV R0.xy, vertex.texcoord[0];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
MOV result.texcoord[0].zw, c[9].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_texture0]
Vector 8 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
def c9, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.zw, c9.x
mov r0.xy, v1
dp4 o1.y, r0, c5
dp4 o1.x, r0, c4
mov o1.zw, c8.xyxy
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
ConstBuffer "UnityPerDrawTexMatrices" 768
Matrix 512 [glstate_matrix_texture0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerDrawTexMatrices" 2
"vs_4_0
eefiecedekgmicmaadbmmjingmiaggelcoceohldabaaaaaafaacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefchaabaaaa
eaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafjaaaaaeegiocaaaacaaaaaaccaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiacaaaacaaaaaacbaaaaaadcaaaaakdccabaaaabaaaaaaegiacaaaacaaaaaa
caaaaaaaagbabaaaabaaaaaaegaabaaaaaaaaaaadgaaaaagmccabaaaabaaaaaa
agiecaaaaaaaaaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_LineWidth]
Float 1 [_LineSoftness]
Float 2 [_AntiRimParam]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_BOL] 2D 2
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[7] = { program.local[0..2],
		{ 128, 1, 0.0039215689, 999.90002 },
		{ 0.1, 2, 0.050000001, 0 },
		{ 1.5, 0.5, 3, 0.25 },
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MUL R0, R0, c[3].x;
SGE R1, R0, c[3].y;
ADD R1, -R1, c[3].y;
MAD R0, R1, c[3].x, R0;
MIN R0.z, R0, R0.w;
MIN R0.x, R0, R0.y;
ADD R0.z, R0, -c[3].y;
ADD R0.x, R0, -c[3].y;
TEX R1, fragment.texcoord[0], texture[1], 2D;
ABS R2.z, R1.w;
MUL R0.y, R0.z, R0.z;
MAD R0.y, R0.x, R0.x, R0;
CMP R1.w, -R2.z, R1, c[3].y;
MUL R2.x, R0, R0.z;
RSQ R2.y, R0.y;
TEX R0, fragment.texcoord[0], texture[0], 2D;
MUL R0.zw, R0, c[3].xyyz;
ADD R0.z, R0, R0.w;
MUL R2.z, R0, c[3].w;
ADD R0.xy, R0, -c[5].y;
MUL R0.zw, R0.xyxy, c[4].y;
MOV R0.xy, c[5].xzzw;
MUL R0.zw, R0, R0;
MUL R2.w, R0.y, c[2].x;
ADD R0.y, R0.z, R0.w;
ADD R0.z, R2.w, c[3].y;
ADD R0.y, -R0, c[3];
POW R0.z, R0.y, R0.z;
ADD R0.y, R2.z, c[4].x;
MUL R0.w, -R0.y, c[4].x;
MOV R2.z, c[4].y;
ADD R2.w, -R2.z, c[0].x;
ADD R0.w, R0, c[0].x;
ADD R0.z, -R1.w, R0;
MOV R2.z, c[3].y;
MAX R2.w, R0, R2;
MIN R0.w, R2.z, c[2].x;
MUL R2.z, R0.w, R0;
MAD R0.z, R2.x, R2.y, -R2.w;
RCP R2.x, R1.w;
MUL R0.w, R2.z, R0;
MAD R0.w, R0, c[5], R1;
MUL R1.xyz, R1, R2.x;
ADD R1.w, R0.x, c[1].x;
MUL R0.y, R0, c[4].z;
ADD R0.x, R0.y, c[1];
MIN R0.x, R0, R1.w;
RCP R0.x, R0.x;
MUL R1.xyz, R1, R0.w;
MOV R1.w, R0;
ADD R1, R1, -c[6].xxxy;
MUL_SAT R0.x, R0.z, R0;
MAD result.color, R0.x, R1, c[6].xxxy;
END
# 54 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_LineWidth]
Float 1 [_LineSoftness]
Float 2 [_AntiRimParam]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_BOL] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 128.00000000, -1.00000000, 0.00000000, 0.10000000
def c4, 1.00000000, 0.00392157, 999.90002441, 0.10000000
def c5, -2.00000000, 0.05000000, 1.50000000, -0.50000000
def c6, 2.00000000, 3.00000000, 1.00000000, 0.25000000
def c7, -0.00000000, -1.00000000, 0.00000000, 1.00000000
dcl_texcoord0 v0.xy
texld r0, v0, s2
mad r1, r0, c3.x, c3.y
cmp r1, r1, c3.z, c3.x
mad r0, r0, c3.x, r1
min r0.z, r0, r0.w
min r0.x, r0, r0.y
add r0.z, r0, c3.y
add r0.x, r0, c3.y
texld r1, v0, s1
abs r2.x, r1.w
cmp r1.w, -r2.x, c4.x, r1
mul r0.y, r0.z, r0.z
mad r0.y, r0.x, r0.x, r0
mul r3.x, r0, r0.z
rsq r3.y, r0.y
texld r0, v0, s0
add r0.xy, r0, c5.w
mul r0.xy, r0, c6.x
mul r0.xy, r0, r0
add r0.x, r0, r0.y
mov r2.x, c2
mad r0.y, r2.x, c6, c6.z
add r0.x, -r0, c4
pow r2, r0.x, r0.y
mul r0.xy, r0.zwzw, c4
add r0.x, r0, r0.y
mad r0.x, r0, c4.z, c4.w
mov r0.y, r2.x
mul r0.w, -r0.x, c3
mov r0.z, c0.x
add r0.y, -r1.w, r0
add r0.w, r0, c0.x
add r0.z, c5.x, r0
max r0.z, r0.w, r0
mov r2.x, c2
min r0.w, c4.x, r2.x
mul r2.x, r0.w, r0.y
mad r0.y, r3.x, r3, -r0.z
mul r0.z, r2.x, r0.w
rcp r0.w, r1.w
mad r0.z, r0, c6.w, r1.w
mul r1.xyz, r1, r0.w
mul r1.w, r0.x, c5.y
mov r0.w, c1.x
add r0.x, c5.z, r0.w
add r0.w, r1, c1.x
min r0.x, r0.w, r0
rcp r0.x, r0.x
mul r1.xyz, r1, r0.z
mov r1.w, r0.z
add r1, r1, c7.xxxy
mul_sat r0.x, r0.y, r0
mad oC0, r0.x, r1, c7.zzzw
"
}
SubProgram "d3d11 " {
SetTexture 0 [_CameraDepthNormalsTexture] 2D 2
SetTexture 1 [_MainTex] 2D 0
SetTexture 2 [_BOL] 2D 1
ConstBuffer "$Globals" 64
Float 40 [_LineWidth]
Float 44 [_LineSoftness]
Float 48 [_AntiRimParam]
BindCB  "$Globals" 0
"ps_4_0
eefiecedpgojdakdgibakhjjnfpdloiodmklkfapabaaaaaakaagaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaafaaaa
eaaaaaaahiabaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaeaaaaaaddaaaaaibcaabaaaaaaaaaaaakiacaaaaaaaaaaa
adaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaacaaaaaaaaaaaaakgcaabaaaaaaaaaaaagabbaaa
abaaaaaaaceaaaaaaaaaaaaaaaaaaalpaaaaaalpaaaaaaaaapaaaaakicaabaaa
aaaaaaaaogakbaaaabaaaaaaaceaaaaaaaaaiadpibiaiadlaaaaaaaaaaaaaaaa
dcaaaaajicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaajkpjhjeeabeaaaaa
mnmmmmdnaaaaaaahgcaabaaaaaaaaaaafgagbaaaaaaaaaaafgagbaaaaaaaaaaa
apaaaaahccaabaaaaaaaaaaajgafbaaaaaaaaaaajgafbaaaaaaaaaaaaaaaaaai
ccaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaaf
ccaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaakecaabaaaaaaaaaaaakiacaaa
aaaaaaaaadaaaaaaabeaaaaaaaaaeaeaabeaaaaaaaaaiadpdiaaaaahdcaabaaa
aaaaaaaaegaabaaaaaaaaaaaigaabaaaaaaaaaaabjaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaaaaaaaaabiaaaaahecaabaaaaaaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaaadhaaaaajecaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaiadpdkaabaaaabaaaaaaaaaaaaaiccaabaaaaaaaaaaackaabaiaebaaaaaa
aaaaaaaabkaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaajicaabaaaacaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaiadockaabaaaaaaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpckaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaa
acaaaaaaegacbaaaaaaaaaaaaaaaaaakpcaabaaaabaaaaaaegaobaaaacaaaaaa
aceaaaaaaaaaaaiaaaaaaaiaaaaaaaiaaaaaialpefaaaaajpcaabaaaacaaaaaa
egbabaaaabaaaaaaeghobaaaacaaaaaaaagabaaaabaaaaaabnaaaaakpcaabaaa
adaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaadmaaaaaadm
dhaaaaappcaabaaaadaaaaaaegaobaaaadaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaedaaaaaaeddcaaaaam
pcaabaaaacaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaed
aaaaaaedegaobaaaadaaaaaaddaaaaahhcaabaaaaaaaaaaafgahbaaaacaaaaaa
agacbaaaacaaaaaaaaaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaa
aaaaialpaaaaialpaaaaialpaaaaaaaadiaaaaahhcaabaaaaaaaaaaaggakbaaa
aaaaaaaaegacbaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaackaabaaaaaaaaaaa
bkaabaaaaaaaaaaaelaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaaaoaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaadcaaaaalccaabaaa
aaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaamnmmmmdnckiacaaaaaaaaaaa
acaaaaaadcaaaaakecaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaamnmmemdn
dkiacaaaaaaaaaaaacaaaaaaaaaaaaaldcaabaaaacaaaaaalgipcaaaaaaaaaaa
acaaaaaaaceaaaaaaaaamadpaaaaaamaaaaaaaaaaaaaaaaadeaaaaahccaabaaa
aaaaaaaabkaabaaaaaaaaaaabkaabaaaacaaaaaaddaaaaahecaabaaaaaaaaaaa
ckaabaaaaaaaaaaaakaabaaaacaaaaaaaaaaaaaibcaabaaaaaaaaaaabkaabaia
ebaaaaaaaaaaaaaaakaabaaaaaaaaaaaaocaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaackaabaaaaaaaaaaadcaaaaampccabaaaaaaaaaaaagaabaaaaaaaaaaa
egaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpdoaaaaab
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
Vector 9 [_MainTex_TexelSize]
"3.0-!!ARBvp1.0
PARAM c[10] = { { 0 },
		state.matrix.mvp,
		state.matrix.texture[0],
		program.local[9] };
TEMP R0;
MOV R0.zw, c[0].x;
MOV R0.xy, vertex.texcoord[0];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
MOV result.texcoord[0].zw, c[9].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_texture0]
Vector 8 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
def c9, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.zw, c9.x
mov r0.xy, v1
dp4 o1.y, r0, c5
dp4 o1.x, r0, c4
mov o1.zw, c8.xyxy
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
ConstBuffer "UnityPerDrawTexMatrices" 768
Matrix 512 [glstate_matrix_texture0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerDrawTexMatrices" 2
"vs_4_0
eefiecedekgmicmaadbmmjingmiaggelcoceohldabaaaaaafaacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefchaabaaaa
eaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafjaaaaaeegiocaaaacaaaaaaccaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiacaaaacaaaaaacbaaaaaadcaaaaakdccabaaaabaaaaaaegiacaaaacaaaaaa
caaaaaaaagbabaaaabaaaaaaegaabaaaaaaaaaaadgaaaaagmccabaaaabaaaaaa
agiecaaaaaaaaaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_LineWidth]
Float 1 [_LineSoftness]
Float 2 [_AntiRimParam]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_BOL] 2D 2
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[7] = { program.local[0..2],
		{ 128, 1, 0.0039215689, 999.90002 },
		{ 0.1, 2, 0.050000001, 0 },
		{ 1.5, 0.5, 3, 0.25 },
		{ 0, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MUL R0, R0, c[3].x;
SGE R1, R0, c[3].y;
ADD R1, -R1, c[3].y;
MAD R0, R1, c[3].x, R0;
MIN R0.x, R0, R0.y;
MIN R0.z, R0, R0.w;
ADD R0.y, R0.z, -c[3];
ADD R0.x, R0, -c[3].y;
MUL R0.z, R0.y, R0.y;
MAD R1.y, R0.x, R0.x, R0.z;
MUL R1.x, R0, R0.y;
TEX R0, fragment.texcoord[0], texture[0], 2D;
ADD R1.zw, R0.xyxy, -c[5].y;
MUL R0.zw, R0, c[3].xyyz;
ADD R0.x, R0.z, R0.w;
MUL R0.z, R0.x, c[3].w;
MUL R1.zw, R1, c[4].y;
MUL R0.xy, R1.zwzw, R1.zwzw;
ADD R0.z, R0, c[4].x;
MUL R0.w, -R0.z, c[4].x;
MOV R1.z, c[4].y;
RSQ R1.y, R1.y;
ADD R0.w, R0, c[0].x;
ADD R1.z, -R1, c[0].x;
MAX R1.z, R0.w, R1;
ADD R0.w, R0.x, R0.y;
MOV R0.xy, c[5].xzzw;
ADD R1.w, -R0, c[3].y;
TEX R0.w, fragment.texcoord[0], texture[1], 2D;
MUL R0.y, R0, c[2].x;
ADD R0.y, R0, c[3];
POW R1.w, R1.w, R0.y;
ABS R2.x, R0.w;
CMP R0.y, -R2.x, R0.w, c[3];
ADD R2.x, R1.w, -R0.y;
MOV R0.w, c[3].y;
MIN R1.w, R0, c[2].x;
MAD R0.w, R1.x, R1.y, -R1.z;
MUL R2.x, R1.w, R2;
MUL R1.y, R2.x, R1.w;
ADD R1.x, R0, c[1];
MUL R0.z, R0, c[4];
ADD R0.x, R0.z, c[1];
MIN R0.x, R0, R1;
MAD R0.y, R1, c[5].w, R0;
RCP R0.x, R0.x;
ADD R1.xy, R0.y, -c[6];
MUL_SAT R0.x, R0.w, R0;
MAD result.color, R0.x, R1.xxxy, c[6].xxxy;
END
# 50 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_LineWidth]
Float 1 [_LineSoftness]
Float 2 [_AntiRimParam]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_BOL] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c3, 128.00000000, -1.00000000, 0.00000000, 0.10000000
def c4, 1.00000000, 0.00392157, 999.90002441, 0.10000000
def c5, -2.00000000, 0.05000000, 1.50000000, -0.50000000
def c6, 2.00000000, 3.00000000, 1.00000000, 0.25000000
def c7, -0.00000000, -1.00000000, 0.00000000, 1.00000000
dcl_texcoord0 v0.xy
texld r0, v0, s2
mad r1, r0, c3.x, c3.y
cmp r1, r1, c3.z, c3.x
mad r0, r0, c3.x, r1
min r0.x, r0, r0.y
min r0.z, r0, r0.w
add r0.y, r0.z, c3
add r0.x, r0, c3.y
mul r0.z, r0.y, r0.y
mad r1.x, r0, r0, r0.z
mul r1.y, r0.x, r0
texld r0, v0, s0
mul r0.zw, r0, c4.xyxy
add r0.z, r0, r0.w
mad r1.z, r0, c4, c4.w
add r0.xy, r0, c5.w
mov r0.z, c0.x
mul r0.w, -r1.z, c3
mul r0.xy, r0, c6.x
rsq r1.x, r1.x
add r0.z, c5.x, r0
add r0.w, r0, c0.x
max r1.w, r0, r0.z
mul r0.zw, r0.xyxy, r0.xyxy
mov r0.x, c2
add r0.y, r0.z, r0.w
mad r2.y, r0.x, c6, c6.z
add r2.x, -r0.y, c4
pow r0, r2.x, r2.y
texld r0.w, v0, s1
abs r0.y, r0.w
mov r0.z, r0.x
cmp r0.x, -r0.y, c4, r0.w
add r0.w, r0.z, -r0.x
mov r0.y, c2.x
min r0.z, c4.x, r0.y
mul r0.w, r0.z, r0
mad r0.y, r1, r1.x, -r1.w
mul r1.x, r0.w, r0.z
mov r0.z, c1.x
mul r0.w, r1.z, c5.y
add r0.w, r0, c1.x
add r0.z, c5, r0
min r0.z, r0.w, r0
mad r0.w, r1.x, c6, r0.x
rcp r0.x, r0.z
add r0.zw, r0.w, c7.xyxy
mul_sat r0.x, r0.y, r0
mad oC0, r0.x, r0.zzzw, c7.zzzw
"
}
SubProgram "d3d11 " {
SetTexture 0 [_CameraDepthNormalsTexture] 2D 2
SetTexture 1 [_MainTex] 2D 0
SetTexture 2 [_BOL] 2D 1
ConstBuffer "$Globals" 64
Float 40 [_LineWidth]
Float 44 [_LineSoftness]
Float 48 [_AntiRimParam]
BindCB  "$Globals" 0
"ps_4_0
eefiecedppllbkpkniedgemkjppmahdmnmacppkjabaaaaaafmagaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapadaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcjmafaaaa
eaaaaaaaghabaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaabaaaaaabnaaaaakpcaabaaaabaaaaaaegaobaaa
aaaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaadmaaaaaadmdhaaaaappcaabaaa
abaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aceaaaaaaaaaaaedaaaaaaedaaaaaaedaaaaaaeddcaaaaampcaabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaedaaaaaaedegaobaaa
abaaaaaaddaaaaahhcaabaaaaaaaaaaafgahbaaaaaaaaaaaagacbaaaaaaaaaaa
aaaaaaakhcaabaaaaaaaaaaaegacbaaaaaaaaaaaaceaaaaaaaaaialpaaaaialp
aaaaialpaaaaaaaadiaaaaahhcaabaaaaaaaaaaaggakbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaahccaabaaaaaaaaaaackaabaaaaaaaaaaabkaabaaaaaaaaaaa
elaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaaaoaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabkaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaaapaaaaakccaabaaaaaaaaaaa
ogakbaaaabaaaaaaaceaaaaaaaaaiadpibiaiadlaaaaaaaaaaaaaaaaaaaaaaak
mcaabaaaaaaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaalp
aaaaaalpaaaaaaahmcaabaaaaaaaaaaakgaobaaaaaaaaaaakgaobaaaaaaaaaaa
apaaaaahecaabaaaaaaaaaaaogakbaaaaaaaaaaaogakbaaaaaaaaaaaaaaaaaai
ecaabaaaaaaaaaaackaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaaf
ecaabaaaaaaaaaaackaabaaaaaaaaaaadcaaaaajccaabaaaaaaaaaaabkaabaaa
aaaaaaaaabeaaaaajkpjhjeeabeaaaaamnmmmmdndcaaaaalicaabaaaaaaaaaaa
bkaabaiaebaaaaaaaaaaaaaaabeaaaaamnmmmmdnckiacaaaaaaaaaaaacaaaaaa
dcaaaaakccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaamnmmemdndkiacaaa
aaaaaaaaacaaaaaaaaaaaaaldcaabaaaabaaaaaalgipcaaaaaaaaaaaacaaaaaa
aceaaaaaaaaamadpaaaaaamaaaaaaaaaaaaaaaaadeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaabkaabaaaabaaaaaaddaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakaabaaaabaaaaaaaaaaaaaibcaabaaaaaaaaaaadkaabaiaebaaaaaa
aaaaaaaaakaabaaaaaaaaaaaaocaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakccaabaaaaaaaaaaaakiacaaaaaaaaaaaadaaaaaa
abeaaaaaaaaaeaeaabeaaaaaaaaaiadpdiaaaaahccaabaaaaaaaaaaackaabaaa
aaaaaaaabkaabaaaaaaaaaaabjaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaabiaaaaahecaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaaaa
dhaaaaajecaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaaaaaaiadpdkaabaaa
abaaaaaaaaaaaaaiccaabaaaaaaaaaaackaabaiaebaaaaaaaaaaaaaabkaabaaa
aaaaaaaaddaaaaaiicaabaaaaaaaaaaaakiacaaaaaaaaaaaadaaaaaaabeaaaaa
aaaaiadpdiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaa
diaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaadkaabaaaaaaaaaaadcaaaaaj
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiadockaabaaaaaaaaaaa
aaaaaaakpcaabaaaabaaaaaafgafbaaaaaaaaaaaaceaaaaaaaaaaaiaaaaaaaia
aaaaaaiaaaaaialpdcaaaaampccabaaaaaaaaaaaagaabaaaaaaaaaaaegaobaaa
abaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpdoaaaaab"
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
Vector 9 [_MainTex_TexelSize]
"3.0-!!ARBvp1.0
PARAM c[10] = { { 0 },
		state.matrix.mvp,
		state.matrix.texture[0],
		program.local[9] };
TEMP R0;
MOV R0.zw, c[0].x;
MOV R0.xy, vertex.texcoord[0];
DP4 result.texcoord[0].y, R0, c[6];
DP4 result.texcoord[0].x, R0, c[5];
MOV result.texcoord[0].zw, c[9].xyxy;
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
END
# 9 instructions, 1 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_texture0]
Vector 8 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
def c9, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.zw, c9.x
mov r0.xy, v1
dp4 o1.y, r0, c5
dp4 o1.x, r0, c4
mov o1.zw, c8.xyxy
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 64
Vector 16 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
ConstBuffer "UnityPerDrawTexMatrices" 768
Matrix 512 [glstate_matrix_texture0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
BindCB  "UnityPerDrawTexMatrices" 2
"vs_4_0
eefiecedekgmicmaadbmmjingmiaggelcoceohldabaaaaaafaacaaaaadaaaaaa
cmaaaaaaiaaaaaaaniaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
fdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklfdeieefchaabaaaa
eaaaabaafmaaaaaafjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaa
abaaaaaaaeaaaaaafjaaaaaeegiocaaaacaaaaaaccaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaaaaaaaaafgbfbaaaabaaaaaa
egiacaaaacaaaaaacbaaaaaadcaaaaakdccabaaaabaaaaaaegiacaaaacaaaaaa
caaaaaaaagbabaaaabaaaaaaegaabaaaaaaaaaaadgaaaaagmccabaaaabaaaaaa
agiecaaaaaaaaaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_AntiRimParam]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_BOL] 2D 1
SetTexture 2 [_MainTex] 2D 2
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0],
		{ 0, 0.5, 2, 0.33333001 },
		{ 16, 128, 1, 3 },
		{ 0.2, 0.40000001, 0.60000002, 0.80000001 },
		{ 0.25 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[1], 2D;
MUL R0, R0, c[2].y;
SGE R1, R0, c[2].z;
ADD R1, -R1, c[2].z;
MAD R0, R1, c[2].y, R0;
ADD R1.xy, R0.ywzw, -c[2].w;
MAX R3.xy, R1, c[1].x;
TEX R2.xy, fragment.texcoord[0], texture[0], 2D;
ADD R2.xy, R2, -c[1].y;
MUL R4.xy, R2, c[1].z;
ABS R0.w, R4.x;
MOV R1.w, c[1].x;
MOV R1.z, R4.x;
MUL R2.xy, R1.zwzw, R1.zwzw;
ADD R0.y, R2.x, R2;
RSQ R0.y, R0.y;
MUL R1.zw, R0.y, R1;
ADD R0.xy, R0.xzzw, -c[2].w;
POW R0.w, R0.w, c[1].w;
MUL R1.zw, R1, R0.w;
MAX R3.zw, R0.xyxy, c[1].x;
MUL R0.zw, R1, c[2].x;
MAX R0.xy, -R3.zwzw, R0.zwzw;
MIN R0.xy, R3, R0;
MUL R2.xy, fragment.texcoord[0].zwzw, R0;
MAD R0.xy, R2, c[3].x, fragment.texcoord[0];
MOV R1.y, R4;
MOV R1.x, c[1];
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD R1.z, R1, R1.w;
RSQ R1.z, R1.z;
ABS R1.w, R4.y;
MUL R1.xy, R1.z, R1;
POW R1.w, R1.w, c[1].w;
MUL R1.zw, R1.xyxy, R1.w;
MUL R2.zw, R1, c[2].x;
MAX R2.zw, R2, -R3;
MIN R3.xy, R2.zwzw, R3;
MAD R1.xy, R2, c[3].y, fragment.texcoord[0];
MUL R4.zw, fragment.texcoord[0], R3.xyxy;
TEX R1, R1, texture[2], 2D;
TEX R0, R0, texture[2], 2D;
MAX R0, R0, R1;
MAD R1.zw, R2.xyxy, c[3].w, fragment.texcoord[0].xyxy;
MAD R1.xy, R2, c[3].z, fragment.texcoord[0];
TEX R2, R1.zwzw, texture[2], 2D;
TEX R1, R1, texture[2], 2D;
MAX R1, R1, R2;
MAX R3, R0, R1;
MAD R0.zw, R4, c[3].w, fragment.texcoord[0].xyxy;
TEX R1, R0.zwzw, texture[2], 2D;
MAD R0.xy, R4.zwzw, c[3].z, fragment.texcoord[0];
TEX R0, R0, texture[2], 2D;
MAX R2, R0, R1;
MAD R0.zw, R4, c[3].y, fragment.texcoord[0].xyxy;
TEX R1, R0.zwzw, texture[2], 2D;
MAD R0.xy, R4.zwzw, c[3].x, fragment.texcoord[0];
TEX R0, R0, texture[2], 2D;
MAX R0, R0, R1;
MAX R1, R0, R2;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MAX R0, R0, R1;
MAX R0, R0, R3;
MUL R1.zw, R4.xyxy, R4.xyxy;
ADD R1.z, R1, R1.w;
MOV R1.y, c[0].x;
MAD R1.w, R1.y, c[2], c[2].z;
ADD R1.y, -R1.z, c[2].z;
ABS R1.x, R0.w;
POW R1.z, R1.y, R1.w;
CMP R1.y, -R1.x, R0.w, c[2].z;
MOV R1.x, c[2].z;
MOV R0.w, c[1].z;
MIN R0.w, R0, c[0].x;
ADD R1.z, -R1.y, R1;
MIN R1.x, R1, c[0];
MUL R1.x, R1, R1.z;
MUL R1.x, R0.w, R1;
MAD R1.x, R1, c[4], R1.y;
RCP R0.w, R1.y;
MUL R0.xyz, R0, R0.w;
MUL result.color.xyz, R0, R1.x;
MOV result.color.w, R1.x;
END
# 83 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_AntiRimParam]
SetTexture 0 [_CameraDepthNormalsTexture] 2D 0
SetTexture 1 [_BOL] 2D 1
SetTexture 2 [_MainTex] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c1, -0.50000000, 0.00000000, 0.33333001, 16.00000000
def c2, 128.00000000, -1.00000000, 0.00000000, -3.00000000
def c3, 0.20000000, 0.40000001, 0.60000002, 0.80000001
def c4, 2.00000000, 1.00000000, 3.00000000, 0.25000000
dcl_texcoord0 v0
texld r0, v0, s1
mad r1, r0, c2.x, c2.y
cmp r1, r1, c2.z, c2.x
mad r1, r0, c2.x, r1
add r2.xy, r1.xzzw, c2.w
add r0.zw, r1.xyyw, c2.w
texld r0.xy, v0, s0
add r0.xy, r0, c1.x
mul r4.xy, r0, c4.x
max r3.zw, r0, c1.y
abs r2.z, r4.y
pow r0, r2.z, c1.z
mov r1.w, r4.y
mov r1.z, c1.y
mul r1.xy, r1.zwzw, r1.zwzw
add r0.y, r1.x, r1
mov r0.z, r0.x
rsq r0.y, r0.y
mul r0.xy, r0.y, r1.zwzw
mul r0.xy, r0, r0.z
max r3.xy, r2, c1.y
mul r0.xy, r0, c1.w
max r0.xy, r0, -r3
min r0.xy, r0, r3.zwzw
mul r4.zw, v0, r0.xyxy
mad r1.xy, r4.zwzw, c3.y, v0
mad r0.xy, r4.zwzw, c3.x, v0
mad r5.xy, r4.zwzw, c3.z, v0
texld r1, r1, s2
texld r0, r0, s2
max r2, r0, r1
texld r1, r5, s2
abs r6.x, r4
pow r0, r6.x, c1.z
mov r5.y, c1
mov r5.x, r4
mul r5.zw, r5.xyxy, r5.xyxy
add r0.y, r5.z, r5.w
mov r0.z, r0.x
rsq r0.y, r0.y
mul r0.xy, r0.y, r5
mul r0.zw, r0.xyxy, r0.z
mad r0.xy, r4.zwzw, c3.w, v0
mul r4.zw, r0, c1.w
max r3.xy, -r3, r4.zwzw
min r3.xy, r3.zwzw, r3
texld r0, r0, s2
max r0, r1, r0
max r1, r2, r0
texld r0, v0, s2
mul r4.zw, v0, r3.xyxy
max r2, r0, r1
mad r1.xy, r4.zwzw, c3.w, v0
mad r0.xy, r4.zwzw, c3.z, v0
texld r1, r1, s2
texld r0, r0, s2
max r3, r0, r1
mad r1.xy, r4.zwzw, c3.y, v0
mad r0.xy, r4.zwzw, c3.x, v0
texld r1, r1, s2
texld r0, r0, s2
max r0, r0, r1
max r0, r0, r3
mul r1.zw, r4.xyxy, r4.xyxy
mov r1.x, c0
add r1.y, r1.z, r1.w
max r0, r2, r0
mad r3.y, r1.x, c4.z, c4
add r3.x, -r1.y, c4.y
pow r1, r3.x, r3.y
abs r1.y, r0.w
cmp r0.w, -r1.y, c4.y, r0
add r1.z, -r0.w, r1.x
mov r1.y, c0.x
mov r1.x, c0
min r1.y, c4, r1
min r1.x, c4, r1
mul r1.y, r1, r1.z
mul r1.y, r1.x, r1
rcp r1.x, r0.w
mad r0.w, r1.y, c4, r0
mul r0.xyz, r0, r1.x
mul oC0.xyz, r0, r0.w
mov oC0.w, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_CameraDepthNormalsTexture] 2D 2
SetTexture 1 [_BOL] 2D 1
SetTexture 2 [_MainTex] 2D 0
ConstBuffer "$Globals" 64
Float 48 [_AntiRimParam]
BindCB  "$Globals" 0
"ps_4_0
eefieceddbabekfelcihgabcniipkfndkhiahcfpabaaaaaakaajaaaaadaaaaaa
cmaaaaaaieaaaaaaliaaaaaaejfdeheofaaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaeeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcoaaiaaaa
eaaaaaaadiacaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaae
aahabaaaacaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacagaaaaaaefaaaaajpcaabaaaaaaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaacaaaaaaaaaaaaakdcaabaaaaaaaaaaaegaabaaa
aaaaaaaaaceaaaaaaaaaaalpaaaaaalpaaaaaaaaaaaaaaaaaaaaaaahdcaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaadiaaaaahmcaabaaaaaaaaaaa
fgabbaaaaaaaaaaafgabbaaaaaaaaaaaeeaaaaafmcaabaaaaaaaaaaakgaobaaa
aaaaaaaadiaaaaahmcaabaaaaaaaaaaakgaobaaaaaaaaaaafgabbaaaaaaaaaaa
cpaaaaagdcaabaaaabaaaaaabgafbaiaibaaaaaaaaaaaaaaapaaaaahbcaabaaa
aaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaaaaaaaaaibcaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpcpaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaakdcaabaaaabaaaaaaegaabaaaabaaaaaaaceaaaaa
dlkkkkdodlkkkkdoaaaaaaaaaaaaaaaabjaaaaafdcaabaaaabaaaaaaegaabaaa
abaaaaaadiaaaaahmcaabaaaabaaaaaakgaobaaaaaaaaaaaagaebaaaabaaaaaa
diaaaaakpcaabaaaacaaaaaaigaibaaaabaaaaaaaceaaaaaaaaaaaaaaaaaiaeb
aaaaaaaaaaaaiaebdiaaaaakpcaabaaaabaaaaaahgahbaaaabaaaaaaaceaaaaa
aaaaiaebaaaaaaaaaaaaiaebaaaaaaaaefaaaaajpcaabaaaadaaaaaaegbabaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaabnaaaaakpcaabaaaaeaaaaaa
iganbaaaadaaaaaaaceaaaaaaaaaaadmaaaaaadmaaaaaadmaaaaaadmdhaaaaap
pcaabaaaaeaaaaaaegaobaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaedaaaaaaeddcaaaaampcaabaaa
adaaaaaaiganbaaaadaaaaaaaceaaaaaaaaaaaedaaaaaaedaaaaaaedaaaaaaed
egaobaaaaeaaaaaaaaaaaaakpcaabaaaadaaaaaaegaobaaaadaaaaaaaceaaaaa
aaaaeamaaaaaeamaaaaaeamaaaaaeamadeaaaaakpcaabaaaadaaaaaaegaobaaa
adaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadeaaaaaipcaabaaa
acaaaaaaegaobaaaacaaaaaaegaebaiaebaaaaaaadaaaaaaddaaaaahpcaabaaa
acaaaaaaogaobaaaadaaaaaaegaobaaaacaaaaaadiaaaaahpcaabaaaacaaaaaa
egaobaaaacaaaaaaogbobaaaabaaaaaadcaaaaampcaabaaaaeaaaaaaogaobaaa
acaaaaaaaceaaaaamnmmemdomnmmemdomnmmmmdomnmmmmdoegbebaaaabaaaaaa
dcaaaaampcaabaaaacaaaaaaegaobaaaacaaaaaaaceaaaaajkjjbjdpjkjjbjdp
mnmmemdpmnmmemdpegbebaaaabaaaaaaefaaaaajpcaabaaaafaaaaaaegaabaaa
aeaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaaeaaaaaa
ogakbaaaaeaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadeaaaaahpcaabaaa
aeaaaaaaegaobaaaaeaaaaaaegaobaaaafaaaaaaefaaaaajpcaabaaaafaaaaaa
egaabaaaacaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaogakbaaaacaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadeaaaaah
pcaabaaaacaaaaaaegaobaaaacaaaaaaegaobaaaafaaaaaadeaaaaahpcaabaaa
acaaaaaaegaobaaaacaaaaaaegaobaaaaeaaaaaaefaaaaajpcaabaaaaeaaaaaa
egbabaaaabaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadeaaaaahpcaabaaa
acaaaaaaegaobaaaacaaaaaaegaobaaaaeaaaaaadeaaaaaipcaabaaaabaaaaaa
egaobaaaabaaaaaaegaebaiaebaaaaaaadaaaaaaddaaaaahpcaabaaaabaaaaaa
ogaobaaaadaaaaaaegaobaaaabaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaa
abaaaaaaogbobaaaabaaaaaadcaaaaampcaabaaaadaaaaaaogaobaaaabaaaaaa
aceaaaaamnmmemdomnmmemdomnmmmmdomnmmmmdoegbebaaaabaaaaaadcaaaaam
pcaabaaaabaaaaaaegaobaaaabaaaaaaaceaaaaajkjjbjdpjkjjbjdpmnmmemdp
mnmmemdpegbebaaaabaaaaaaefaaaaajpcaabaaaaeaaaaaaegaabaaaadaaaaaa
eghobaaaacaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaadaaaaaaogakbaaa
adaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadeaaaaahpcaabaaaadaaaaaa
egaobaaaadaaaaaaegaobaaaaeaaaaaaefaaaaajpcaabaaaaeaaaaaaegaabaaa
abaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogakbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadeaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaaegaobaaaaeaaaaaadeaaaaahpcaabaaaabaaaaaa
egaobaaaabaaaaaaegaobaaaadaaaaaadeaaaaahpcaabaaaabaaaaaaegaobaaa
abaaaaaaegaobaaaacaaaaaabiaaaaahccaabaaaaaaaaaaadkaabaaaabaaaaaa
abeaaaaaaaaaaaaadhaaaaajccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
aaaaiadpdkaabaaaabaaaaaadcaaaaakecaabaaaaaaaaaaaakiacaaaaaaaaaaa
adaaaaaaabeaaaaaaaaaeaeaabeaaaaaaaaaiadpdiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaaibcaabaaaaaaaaaaabkaabaiaebaaaaaaaaaaaaaaakaabaaa
aaaaaaaaddaaaaalmcaabaaaaaaaaaaaagiacaaaaaaaaaaaadaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaiadpaaaaaaeadiaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaackaabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaajicaabaaaacaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaiadobkaabaaaaaaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpbkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
agaabaaaaaaaaaaaegacbaaaabaaaaaadiaaaaahhcaabaaaacaaaaaapgapbaaa
acaaaaaaegacbaaaaaaaaaaaaaaaaaakpcaabaaaaaaaaaaaegaobaaaacaaaaaa
aceaaaaaaaaaaaiaaaaaaaiaaaaaaaiaaaaaialpaaaaaaakpccabaaaaaaaaaaa
egaobaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaiadpdoaaaaab
"
}
}
 }
}
Fallback Off
}