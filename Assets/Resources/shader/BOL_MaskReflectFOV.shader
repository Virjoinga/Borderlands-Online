чаShader "Custom/BOL_MaskReflectFOV" {
Properties {
 _IllumnColor ("Emissive Color (Mask R)", Color) = (0.5,0.5,0.5,1)
 _MetalColor ("Metallic Color (Mask G)", Color) = (0.5,0.5,0.5,1)
 _MetalShininess ("Metallic Shininess (Mask G)", Range(0.03,1)) = 0.078125
 _SkinColor ("Skin Color (Mask B)", Color) = (1,1,1,1)
 _SkinShininess ("Skin Shininess (Mask B)", Range(0.03,1)) = 0.078125
 _ClothColor ("Cloth Color (Mask A)", Color) = (1,1,1,1)
 _ClothShininess ("Cloth Shininess (Mask A)", Range(0.03,1)) = 0.078125
 _Color ("Main Color", Color) = (1,1,1,1)
 _Shininess ("Main Shininess", Range(0.03,1)) = 0.078125
 _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
 _MaskTex ("Mask (RGB)", 2D) = "white" {}
 _BumpMap ("Normalmap", 2D) = "bump" {}
 _Cube ("Reflection Cubemap", CUBE) = "" { TexGen CubeReflect }
}
SubShader { 
 LOD 400
 Tags { "RenderType"="Opaque" }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "RenderType"="Opaque" }
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[29] = { { 1 },
		state.matrix.modelview[0],
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MUL R0.xyz, vertex.normal, c[26].w;
DP3 R2.w, R0, c[6];
DP3 R1.x, R0, c[5];
MOV R1.y, R2.w;
DP3 R1.z, R0, c[7];
MUL R0, R1.xyzz, R1.yzzx;
MOV R1.w, c[0].x;
DP4 R2.z, R1, c[21];
DP4 R2.y, R1, c[20];
DP4 R2.x, R1, c[19];
DP4 R3.z, R0, c[24];
DP4 R3.y, R0, c[23];
DP4 R3.x, R0, c[22];
MUL R0.w, R2, R2;
MAD R0.w, R1.x, R1.x, -R0;
ADD R0.xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R3.xyz, R0.w, c[25];
ADD result.texcoord[2].xyz, R0, R3;
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MOV R1, c[18];
DP4 R6.z, R1, c[11];
DP4 R6.y, R1, c[10];
DP4 R6.x, R1, c[9];
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.w, c[0].x;
MOV R1.xyz, c[17];
MOV R3, c[2];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R7.xyz, R2, c[26].w, -vertex.position;
MOV R2, c[1];
MUL R1, R3, c[15].y;
MAD R4, R2, c[15].x, R1;
MOV R1, c[3];
MAD R5, R1, c[15].z, R4;
DP3 result.texcoord[1].y, R6, R0;
DP3 result.texcoord[3].y, R0, R7;
MUL R0, R3, c[16].y;
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
MAD R5, R0, c[15].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MUL R3, R3, c[13].y;
MAD R4, R2, c[14].x, R4;
MAD R2, R2, c[13].x, R3;
MAD R3, R1, c[14].z, R4;
MAD R1, R1, c[13].z, R2;
MAD R2, R0, c[14].w, R3;
MAD R0, R0, c[13].w, R1;
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP4 result.position.x, vertex.position, R0;
DP3 result.texcoord[1].z, vertex.normal, R6;
DP3 result.texcoord[1].x, R6, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R7;
DP3 result.texcoord[3].x, vertex.attrib[14], R7;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 64 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_SHAr]
Vector 19 [unity_SHAg]
Vector 20 [unity_SHAb]
Vector 21 [unity_SHBr]
Vector 22 [unity_SHBg]
Vector 23 [unity_SHBb]
Vector 24 [unity_SHC]
Vector 25 [unity_Scale]
Vector 26 [_MainTex_ST]
Vector 27 [_BumpMap_ST]
"vs_2_0
def c28, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r1.xyz, v2, c25.w
dp3 r2.w, r1, c5
dp3 r0.x, r1, c4
dp3 r0.z, r1, c6
mov r0.y, r2.w
mov r0.w, c28.x
mul r1, r0.xyzz, r0.yzzx
dp4 r2.z, r0, c20
dp4 r2.y, r0, c19
dp4 r2.x, r0, c18
mul r0.w, r2, r2
mad r0.w, r0.x, r0.x, -r0
dp4 r0.z, r1, c23
dp4 r0.y, r1, c22
dp4 r0.x, r1, c21
mul r1.xyz, r0.w, c24
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov r0.w, c28.x
mov r0.xyz, c16
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c25.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c17, r0
mov r0, c9
dp4 r4.y, c17, r0
mov r1, c8
dp4 r4.x, c17, r1
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c14.y
mov r0.x, c14
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c14.z
mad r1, c2, r0.x, r1
mov r0.x, c14.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c13.y
mov r0.x, c13
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r0, c3, r0.x, r1
dp3 oT1.y, r4, r2
dp3 oT3.y, r2, r3
mov r2.x, c12.y
mul r1, c1, r2.x
mov r2.x, c12
mad r1, c0, r2.x, r1
mov r2.x, c12.z
mad r1, c2, r2.x, r1
mov r2.x, c12.w
mad r1, c3, r2.x, r1
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT3.z, v2, r3
dp3 oT3.x, v1, r3
dp4 oPos.y, v0, r0
dp4 oPos.x, v0, r1
mad oT0.zw, v3.xyxy, c27.xyxy, c27
mad oT0.xy, v3, c26, c26.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedejoojhimkgpmicgbefmofalmdpmmchefabaaaaaagaakaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcmeaiaaaaeaaaabaa
dbacaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacafaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
afaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
anaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaah
hcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaaj
hcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaah
eccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaa
abaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaa
acaaaaaafgafbaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaa
abaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaabaaaaaa
egadbaaaabaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadpbbaaaaai
bcaabaaaacaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaai
ccaabaaaacaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaai
ecaabaaaacaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaadiaaaaah
pcaabaaaadaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaa
aeaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaa
aeaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaa
aeaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaaaaaaaaahhcaabaaa
acaaaaaaegacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaahicaabaaaaaaaaaaa
bkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaa
abaaaaaaakaabaaaabaaaaaadkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaa
adaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaa
diaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaa
bbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaa
abaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaa
adaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaaaaaaaaai
hcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaal
hcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaia
ebaaaaaaaaaaaaaabaaaaaahcccabaaaaeaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahbccabaaaaeaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaa
baaaaaaheccabaaaaeaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedblfgbeanokkjhfkiofpeapnabnaencjgabaaaaaakeapaaaaaeaaaaaa
daaaaaaahaafaaaadmaoaaaaaeapaaaaebgpgodjdiafaaaadiafaaaaaaacpopp
laaeaaaaiiaaaaaaaiaaceaaaaaaieaaaaaaieaaaaaaceaaabaaieaaaaaaadaa
aeaaabaaaaaaaaaaaaaaanaaacaaafaaaaaaaaaaabaaaeaaabaaahaaaaaaaaaa
acaaaaaaabaaaiaaaaaaaaaaacaacgaaahaaajaaaaaaaaaaadaaaeaaaeaabaaa
aaaaaaaaadaaamaaadaabeaaaaaaaaaaadaabaaaafaabhaaaaaaaaaaaaaaaaaa
aaacpoppfbaaaaafbmaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
bpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaafaaoekaafaaooka
aeaaaaaeaaaaamoaadaaeejaagaaeekaagaaoekaabaaaaacaaaaapiaaiaaoeka
afaaaaadabaaahiaaaaaffiabiaaoekaaeaaaaaeabaaahiabhaaoekaaaaaaaia
abaaoeiaaeaaaaaeaaaaahiabjaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahia
bkaaoekaaaaappiaaaaaoeiaaiaaaaadabaaaboaabaaoejaaaaaoeiaabaaaaac
abaaahiaacaaoejaafaaaaadacaaahiaabaanciaabaamjjaaeaaaaaeabaaahia
abaamjiaabaancjaacaaoeibafaaaaadabaaahiaabaaoeiaabaappjaaiaaaaad
abaaacoaabaaoeiaaaaaoeiaaiaaaaadabaaaeoaacaaoejaaaaaoeiaabaaaaac
aaaaahiaahaaoekaafaaaaadacaaahiaaaaaffiabiaaoekaaeaaaaaeaaaaalia
bhaakekaaaaaaaiaacaakeiaaeaaaaaeaaaaahiabjaaoekaaaaakkiaaaaapeia
acaaaaadaaaaahiaaaaaoeiabkaaoekaaeaaaaaeaaaaahiaaaaaoeiablaappka
aaaaoejbaiaaaaadadaaaboaabaaoejaaaaaoeiaaiaaaaadadaaacoaabaaoeia
aaaaoeiaaiaaaaadadaaaeoaacaaoejaaaaaoeiaafaaaaadaaaaahiaacaaoeja
blaappkaafaaaaadabaaahiaaaaaffiabfaaoekaaeaaaaaeaaaaaliabeaakeka
aaaaaaiaabaakeiaaeaaaaaeaaaaahiabgaaoekaaaaakkiaaaaapeiaabaaaaac
aaaaaiiabmaaaakaajaaaaadabaaabiaajaaoekaaaaaoeiaajaaaaadabaaacia
akaaoekaaaaaoeiaajaaaaadabaaaeiaalaaoekaaaaaoeiaafaaaaadacaaapia
aaaacjiaaaaakeiaajaaaaadadaaabiaamaaoekaacaaoeiaajaaaaadadaaacia
anaaoekaacaaoeiaajaaaaadadaaaeiaaoaaoekaacaaoeiaacaaaaadabaaahia
abaaoeiaadaaoeiaafaaaaadaaaaaciaaaaaffiaaaaaffiaaeaaaaaeaaaaabia
aaaaaaiaaaaaaaiaaaaaffibaeaaaaaeacaaahoaapaaoekaaaaaaaiaabaaoeia
abaaaaacaaaaapiaacaaoekaafaaaaadabaaapiaaaaaoeiabbaaffkaabaaaaac
acaaapiaabaaoekaaeaaaaaeabaaapiaacaaoeiabbaaaakaabaaoeiaabaaaaac
adaaapiaadaaoekaaeaaaaaeabaaapiaadaaoeiabbaakkkaabaaoeiaabaaaaac
aeaaapiaaeaaoekaaeaaaaaeabaaapiaaeaaoeiabbaappkaabaaoeiaafaaaaad
abaaapiaabaaoeiaaaaaffjaafaaaaadafaaapiaaaaaoeiabaaaffkaaeaaaaae
afaaapiaacaaoeiabaaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiabaaakkka
afaaoeiaaeaaaaaeafaaapiaaeaaoeiabaaappkaafaaoeiaaeaaaaaeabaaapia
afaaoeiaaaaaaajaabaaoeiaafaaaaadafaaapiaaaaaoeiabcaaffkaaeaaaaae
afaaapiaacaaoeiabcaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiabcaakkka
afaaoeiaaeaaaaaeafaaapiaaeaaoeiabcaappkaafaaoeiaaeaaaaaeabaaapia
afaaoeiaaaaakkjaabaaoeiaafaaaaadaaaaapiaaaaaoeiabdaaffkaaeaaaaae
aaaaapiaacaaoeiabdaaaakaaaaaoeiaaeaaaaaeaaaaapiaadaaoeiabdaakkka
aaaaoeiaaeaaaaaeaaaaapiaaeaaoeiabdaappkaaaaaoeiaaeaaaaaeaaaaapia
aaaaoeiaaaaappjaabaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeaiaaaaeaaaabaadbacaaaa
fjaaaaaeegiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaa
fjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacafaaaaaadiaaaaajpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaal
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaafaaaaaa
egaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaaj
pcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaaeaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaa
aeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
afaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
adaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaaj
pccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaanaaaaaa
ogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaahhcaabaaa
aaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaa
jgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaa
abaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaal
hcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaa
kgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahcccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
bccabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaa
acaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaaihcaabaaaabaaaaaa
egbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaacaaaaaa
fgafbaaaabaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaabaaaaaa
egiicaaaadaaaaaaamaaaaaaagaabaaaabaaaaaaegaibaaaacaaaaaadcaaaaak
hcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaabaaaaaaegadbaaa
abaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaa
acaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaaiccaabaaa
acaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaaiecaabaaa
acaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaadiaaaaahpcaabaaa
adaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaa
egiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaa
egiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaa
egiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaaaaaaaaahhcaabaaaacaaaaaa
egacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaahicaabaaaaaaaaaaabkaabaaa
abaaaaaabkaabaaaabaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaaabaaaaaa
akaabaaaabaaaaaadkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaadaaaaaa
egiccaaaacaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaadiaaaaaj
hcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaa
aeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaa
abaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaa
aaaaaaaabaaaaaahcccabaaaaeaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahbccabaaaaeaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaah
eccabaaaaeaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadoaaaaabejfdeheo
maaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaakjaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaaaeaaaaaa
apaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafaepfdej
feejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfceeaaedepem
epfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaa
adaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaaimaaaaaa
acaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 13 [_ProjMat]
Vector 18 [unity_LightmapST]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[21] = { program.local[0],
		state.matrix.modelview[0],
		program.local[5..20] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R2, R0, c[15].y;
MAD R4, R1, c[15].x, R2;
MOV R2, c[3];
MUL R3, R0, c[16].y;
MAD R3, R1, c[16].x, R3;
MAD R5, R2, c[15].z, R4;
MAD R4, R2, c[16].z, R3;
MOV R3, c[4];
MAD R4, R3, c[16].w, R4;
MAD R5, R3, c[15].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R0, c[14].y;
MUL R0, R0, c[13].y;
MAD R0, R1, c[13].x, R0;
MAD R4, R1, c[14].x, R4;
MAD R1, R2, c[14].z, R4;
MAD R0, R2, c[13].z, R0;
MAD R1, R3, c[14].w, R1;
MAD R0, R3, c[13].w, R0;
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R1;
DP4 result.position.x, vertex.position, R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[20].xyxy, c[20];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[19], c[19].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[18], c[18].zwzw;
END
# 27 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 12 [_ProjMat]
Vector 16 [unity_LightmapST]
Vector 17 [_MainTex_ST]
Vector 18 [_BumpMap_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r1, c3, r0.x, r1
mov r0.x, c14.y
dp4 oPos.w, r1, v0
mul r1, c1, r0.x
mov r0.x, c14
mad r1, c0, r0.x, r1
mov r0.x, c14.z
mad r1, c2, r0.x, r1
mov r0.x, c14.w
mad r1, c3, r0.x, r1
mov r0.x, c13.y
dp4 oPos.z, v0, r1
mul r1, c1, r0.x
mov r0.x, c13
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.y, c13.w
mad r1, c3, r0.y, r1
mov r0.x, c12.y
mov r2.x, c12
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c12.z
mad r0, c2, r2.x, r0
mov r2.x, c12.w
mad r0, c3, r2.x, r0
dp4 oPos.y, v0, r1
dp4 oPos.x, v0, r0
mad oT0.zw, v3.xyxy, c18.xyxy, c18
mad oT0.xy, v3, c17, c17.zwzw
mad oT1.xy, v4, c16, c16.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 256
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedcgonblcmhlgacckgnljndmlpphflfhffabaaaaaajiafaaaaadaaaaaa
cmaaaaaapeaaaaaageabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefccmaeaaaaeaaaabaaalabaaaafjaaaaaeegiocaaaaaaaaaaa
baaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
giaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaabaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaabaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
abaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaabaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaabaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
abaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaabaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaoaaaaaaogikcaaaaaaaaaaaaoaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaapaaaaaakgiocaaa
aaaaaaaaapaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaaeaaaaaaegiacaaa
aaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 256
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedjjfflooodfjpijfnlgpioeeakiaapnlgabaaaaaaceaiaaaaaeaaaaaa
daaaaaaaliacaaaaomagaaaaleahaaaaebgpgodjiaacaaaaiaacaaaaaaacpopp
deacaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaadaa
aeaaabaaaaaaaaaaaaaaanaaadaaafaaaaaaaaaaabaaaeaaaeaaaiaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaadiaadaaapja
bpaaaaacafaaaeiaaeaaapjaaeaaaaaeaaaaadoaadaaoejaagaaoekaagaaooka
aeaaaaaeaaaaamoaadaaeejaahaaeekaahaaoekaaeaaaaaeabaaadoaaeaaoeja
afaaoekaafaaookaabaaaaacaaaaapiaacaaoekaafaaaaadabaaapiaaaaaoeia
ajaaffkaabaaaaacacaaapiaabaaoekaaeaaaaaeabaaapiaacaaoeiaajaaaaka
abaaoeiaabaaaaacadaaapiaadaaoekaaeaaaaaeabaaapiaadaaoeiaajaakkka
abaaoeiaabaaaaacaeaaapiaaeaaoekaaeaaaaaeabaaapiaaeaaoeiaajaappka
abaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaadafaaapiaaaaaoeia
aiaaffkaaeaaaaaeafaaapiaacaaoeiaaiaaaakaafaaoeiaaeaaaaaeafaaapia
adaaoeiaaiaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaaiaappkaafaaoeia
aeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaadafaaapiaaaaaoeia
akaaffkaaeaaaaaeafaaapiaacaaoeiaakaaaakaafaaoeiaaeaaaaaeafaaapia
adaaoeiaakaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaakaappkaafaaoeia
aeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaadaaaaapiaaaaaoeia
alaaffkaaeaaaaaeaaaaapiaacaaoeiaalaaaakaaaaaoeiaaeaaaaaeaaaaapia
adaaoeiaalaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeiaalaappkaaaaaoeia
aeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefccmaeaaaa
eaaaabaaalabaaaafjaaaaaeegiocaaaaaaaaaaabaaaaaaafjaaaaaeegiocaaa
abaaaaaaaiaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagiaaaaacacaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
afaaaaaakgikcaaaabaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
abaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaabaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaabaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaabaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaabaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
aoaaaaaaogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadcaaaaal
dccabaaaacaaaaaaegbabaaaaeaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaa
aaaaaaaaanaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 19 [unity_Scale]
Vector 20 [unity_LightmapST]
Vector 21 [_MainTex_ST]
Vector 22 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[23] = { { 1 },
		state.matrix.modelview[0],
		program.local[5..22] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R2.w, c[0].x;
MOV R2.xyz, c[17];
MOV R3, c[2];
DP4 R1.z, R2, c[11];
DP4 R1.x, R2, c[9];
DP4 R1.y, R2, c[10];
MAD R6.xyz, R1, c[19].w, -vertex.position;
MUL R0.xyz, R0, vertex.attrib[14].w;
DP3 result.texcoord[2].y, R6, R0;
MOV R2, c[1];
MUL R1, R3, c[15].y;
MAD R4, R2, c[15].x, R1;
MOV R1, c[3];
MUL R0, R3, c[16].y;
MAD R0, R2, c[16].x, R0;
MAD R5, R1, c[15].z, R4;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
MAD R5, R0, c[15].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MUL R3, R3, c[13].y;
MAD R4, R2, c[14].x, R4;
MAD R2, R2, c[13].x, R3;
MAD R3, R1, c[14].z, R4;
MAD R1, R1, c[13].z, R2;
MAD R2, R0, c[14].w, R3;
MAD R0, R0, c[13].w, R1;
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP4 result.position.x, vertex.position, R0;
DP3 result.texcoord[2].z, vertex.normal, R6;
DP3 result.texcoord[2].x, R6, vertex.attrib[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[22].xyxy, c[22];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[21], c[21].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[20], c[20].zwzw;
END
# 40 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [unity_Scale]
Vector 18 [unity_LightmapST]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_2_0
def c21, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r1.xyz, r0, v1.w
mov r0.w, c21.x
mov r0.xyz, c16
dp4 r2.x, r0, c8
dp4 r2.z, r0, c10
dp4 r2.y, r0, c9
mad r0.xyz, r2, c17.w, -v0
dp3 oT2.y, r0, r1
mov r0.w, c15.y
dp3 oT2.z, v2, r0
dp3 oT2.x, r0, v1
mul r1, c1, r0.w
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c14.y
mov r0.x, c14
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c14.z
mad r1, c2, r0.x, r1
mov r0.x, c14.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c13.y
mov r0.x, c13
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r0, c3, r0.x, r1
mov r2.x, c12.y
mul r1, c1, r2.x
mov r2.x, c12
mad r1, c0, r2.x, r1
mov r2.x, c12.z
mad r1, c2, r2.x, r1
mov r2.x, c12.w
mad r1, c3, r2.x, r1
dp4 oPos.y, v0, r0
dp4 oPos.x, v0, r1
mad oT0.zw, v3.xyxy, c20.xyxy, c20
mad oT0.xy, v3, c19, c19.zwzw
mad oT1.xy, v4, c18, c18.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 256
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecednlomgeaghiclhjgljikkkgabpjfokjlkabaaaaaagaahaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
nmafaaaaeaaaabaahhabaaaafjaaaaaeegiocaaaaaaaaaaabaaaaaaafjaaaaae
egiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaa
gfaaaaadhccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaafaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
acaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaaeaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
acaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaafgifcaaaacaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
agaaaaaapgipcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaa
aaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaaogikcaaa
aaaaaaaaaoaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaa
aaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaaeaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaa
diaaaaahhcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaak
hcaabaaaaaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaa
aaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaa
diaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaacaaaaaa
bbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaacaaaaaabaaaaaaaagiacaaa
abaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaa
acaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaaaaaaaaai
hcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaacaaaaaabdaaaaaadcaaaaal
hcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaacaaaaaabeaaaaaaegbcbaia
ebaaaaaaaaaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaa
baaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 256
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedgbpfmenghblnljafcabhgcbbmaagooncabaaaaaapeakaaaaaeaaaaaa
daaaaaaamaadaaaakeajaaaagmakaaaaebgpgodjiiadaaaaiiadaaaaaaacpopp
ceadaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaadaa
aeaaabaaaaaaaaaaaaaaanaaadaaafaaaaaaaaaaabaaaeaaabaaaiaaaaaaaaaa
acaaaeaaaeaaajaaaaaaaaaaacaabaaaafaaanaaaaaaaaaaaaaaaaaaaaacpopp
bpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaacia
acaaapjabpaaaaacafaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaae
aaaaadoaadaaoejaagaaoekaagaaookaaeaaaaaeaaaaamoaadaaeejaahaaeeka
ahaaoekaaeaaaaaeabaaadoaaeaaoejaafaaoekaafaaookaabaaaaacaaaaahia
aiaaoekaafaaaaadabaaahiaaaaaffiaaoaaoekaaeaaaaaeaaaaaliaanaakeka
aaaaaaiaabaakeiaaeaaaaaeaaaaahiaapaaoekaaaaakkiaaaaapeiaacaaaaad
aaaaahiaaaaaoeiabaaaoekaaeaaaaaeaaaaahiaaaaaoeiabbaappkaaaaaoejb
aiaaaaadacaaaboaabaaoejaaaaaoeiaabaaaaacabaaahiaabaaoejaafaaaaad
acaaahiaabaamjiaacaancjaaeaaaaaeabaaahiaacaamjjaabaanciaacaaoeib
afaaaaadabaaahiaabaaoeiaabaappjaaiaaaaadacaaacoaabaaoeiaaaaaoeia
aiaaaaadacaaaeoaacaaoejaaaaaoeiaabaaaaacaaaaapiaacaaoekaafaaaaad
abaaapiaaaaaoeiaakaaffkaabaaaaacacaaapiaabaaoekaaeaaaaaeabaaapia
acaaoeiaakaaaakaabaaoeiaabaaaaacadaaapiaadaaoekaaeaaaaaeabaaapia
adaaoeiaakaakkkaabaaoeiaabaaaaacaeaaapiaaeaaoekaaeaaaaaeabaaapia
aeaaoeiaakaappkaabaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaad
afaaapiaaaaaoeiaajaaffkaaeaaaaaeafaaapiaacaaoeiaajaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaajaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
ajaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaad
afaaapiaaaaaoeiaalaaffkaaeaaaaaeafaaapiaacaaoeiaalaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaalaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
alaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaad
aaaaapiaaaaaoeiaamaaffkaaeaaaaaeaaaaapiaacaaoeiaamaaaakaaaaaoeia
aeaaaaaeaaaaapiaadaaoeiaamaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeia
amaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaa
fdeieefcnmafaaaaeaaaabaahhabaaaafjaaaaaeegiocaaaaaaaaaaabaaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaa
acaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaa
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
pccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadcaaaaaldccabaaa
acaaaaaaegbabaaaaeaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaa
anaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaa
dcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaia
ebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaa
abaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaa
acaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaacaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
aaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaacaaaaaabdaaaaaa
dcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaacaaaaaabeaaaaaa
egbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaa
abaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaa
doaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_WorldSpaceLightPos0]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[30] = { { 1, 0.5 },
		state.matrix.modelview[0],
		program.local[5..29] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[15].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[13].y;
MAD R5, R2, c[15].x, R5;
MUL R3, R3, c[14].y;
MAD R4, R2, c[13].x, R4;
MAD R2, R2, c[14].x, R3;
MAD R3, R1, c[13].z, R4;
MAD R2, R1, c[14].z, R2;
MAD R2, R0, c[14].w, R2;
DP4 R6.y, vertex.position, R2;
MAD R3, R0, c[13].w, R3;
MAD R1, R1, c[15].z, R5;
MAD R0, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R0;
DP4 R6.x, vertex.position, R3;
MUL R2.xyz, R6.xyww, c[0].y;
MUL R0.xyz, vertex.normal, c[27].w;
MUL R2.y, R2, c[18].x;
ADD result.texcoord[4].xy, R2, R2.z;
DP3 R1.w, R0, c[6];
MOV R2.y, R1.w;
DP3 R2.x, R0, c[5];
DP3 R2.z, R0, c[7];
MOV R2.w, c[0].x;
MUL R1.w, R1, R1;
MAD R1.w, R2.x, R2.x, -R1;
MUL R0, R2.xyzz, R2.yzzx;
DP4 R1.z, R2, c[22];
DP4 R1.y, R2, c[21];
DP4 R1.x, R2, c[20];
MUL R3.xyz, R1.w, c[26];
DP4 R2.z, R0, c[25];
DP4 R2.y, R0, c[24];
DP4 R2.x, R0, c[23];
ADD R0.xyz, R1, R2;
ADD result.texcoord[2].xyz, R0, R3;
MOV R2.xyz, c[17];
MOV R2.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R2, c[11];
DP4 R0.y, R2, c[10];
DP4 R0.x, R2, c[9];
MAD R0.xyz, R0, c[27].w, -vertex.position;
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R2.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MOV R1, c[19];
MUL R2.xyz, R2, vertex.attrib[14].w;
DP4 R3.z, R1, c[11];
DP4 R3.y, R1, c[10];
DP4 R3.x, R1, c[9];
MOV result.position, R6;
MOV result.texcoord[4].zw, R6;
DP3 result.texcoord[1].y, R3, R2;
DP3 result.texcoord[3].y, R2, R0;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R0;
DP3 result.texcoord[3].x, vertex.attrib[14], R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[29].xyxy, c[29];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[28], c[28].zwzw;
END
# 69 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [_WorldSpaceLightPos0]
Vector 20 [unity_SHAr]
Vector 21 [unity_SHAg]
Vector 22 [unity_SHAb]
Vector 23 [unity_SHBr]
Vector 24 [unity_SHBg]
Vector 25 [unity_SHBb]
Vector 26 [unity_SHC]
Vector 27 [unity_Scale]
Vector 28 [_MainTex_ST]
Vector 29 [_BumpMap_ST]
"vs_2_0
def c30, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r0.xyz, v2, c27.w
dp3 r0.w, r0, c5
dp3 r2.x, r0, c4
dp3 r2.z, r0, c6
mov r2.y, r0.w
mul r1, r2.xyzz, r2.yzzx
mov r2.w, c30.x
dp4 r3.z, r1, c25
dp4 r3.y, r1, c24
dp4 r3.x, r1, c23
mov r1.x, c15.y
dp4 r0.z, r2, c22
dp4 r0.y, r2, c21
dp4 r0.x, r2, c20
add r0.xyz, r0, r3
mov r2.y, c15.x
mul r1, c1, r1.x
mad r1, c0, r2.y, r1
mov r2.y, c15.z
mad r1, c2, r2.y, r1
mov r2.y, c15.w
mad r1, c3, r2.y, r1
dp4 r3.w, r1, v0
mov r2.y, c13
mul r1, c1, r2.y
mov r2.y, c13.x
mad r1, c0, r2.y, r1
mov r2.y, c13.z
mad r1, c2, r2.y, r1
mov r2.y, c13.w
mad r1, c3, r2.y, r1
dp4 r3.y, v0, r1
mov r2.y, c12
mul r1, c1, r2.y
mov r2.y, c12.x
mad r1, c0, r2.y, r1
mov r2.y, c12.z
mad r1, c2, r2.y, r1
mul r2.y, r0.w, r0.w
mov r0.w, c12
mad r1, c3, r0.w, r1
dp4 r3.x, v0, r1
mad r0.w, r2.x, r2.x, -r2.y
mul r1.xyz, r0.w, c26
add oT2.xyz, r0, r1
mul r2.xyz, r3.xyww, c30.y
mov r1.xyz, v1
mov r0.x, r2
mul r0.y, r2, c17.x
mad oT4.xy, r2.z, c18.zwzw, r0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r1.yzxw
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r4.xyz, r1, v1.w
mov r1, c9
dp4 r2.y, c19, r1
mov r0, c10
dp4 r2.z, c19, r0
mov r0, c8
dp4 r2.x, c19, r0
mov r0.x, c14.y
mov r1.x, c14
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c14.z
mad r0, c2, r1.x, r0
mov r1.x, c14.w
mad r1, c3, r1.x, r0
dp4 r3.z, v0, r1
mov r0.xyz, c16
mov r0.w, c30.x
dp4 r5.z, r0, c10
dp4 r5.x, r0, c8
dp4 r5.y, r0, c9
mad r0.xyz, r5, c27.w, -v0
dp3 oT1.y, r2, r4
dp3 oT3.y, r4, r0
mov oPos, r3
mov oT4.zw, r3
dp3 oT1.z, v2, r2
dp3 oT1.x, r2, v1
dp3 oT3.z, v2, r0
dp3 oT3.x, v1, r0
mad oT0.zw, v3.xyxy, c29.xyxy, c29
mad oT0.xy, v3, c28, c28.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 304
Matrix 112 [_ProjMat]
Vector 272 [_MainTex_ST]
Vector 288 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefieceddjfmmfclhkcbhcdehclbhnmcdkjmjmofabaaaaaabaalaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefcfmajaaaaeaaaabaafhacaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacagaaaaaa
diaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaa
afaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaal
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaafaaaaaa
egaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
adaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaa
aeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
akaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaj
pcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaahaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaa
abaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaabbaaaaaaogikcaaa
aaaaaaaabbaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaa
aaaaaaaabcaaaaaakgiocaaaaaaaaaaabcaaaaaadiaaaaahhcaabaaaabaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaadiaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaaacaaaaaa
fgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaa
acaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaa
acaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaa
adaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaaacaaaaaabaaaaaah
cccabaaaacaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahbccabaaa
acaaaaaaegbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaaheccabaaaacaaaaaa
egbcbaaaacaaaaaaegacbaaaacaaaaaadiaaaaaihcaabaaaacaaaaaaegbcbaaa
acaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaadaaaaaafgafbaaa
acaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaacaaaaaaegiicaaa
adaaaaaaamaaaaaaagaabaaaacaaaaaaegaibaaaadaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaacaaaaaaegadbaaaacaaaaaa
dgaaaaaficaabaaaacaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaadaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaacaaaaaadiaaaaahpcaabaaaaeaaaaaa
jgacbaaaacaaaaaaegakbaaaacaaaaaabbaaaaaibcaabaaaafaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaaeaaaaaabbaaaaaiccaabaaaafaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaaeaaaaaabbaaaaaiecaabaaaafaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaaeaaaaaaaaaaaaahhcaabaaaadaaaaaaegacbaaa
adaaaaaaegacbaaaafaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaacaaaaaa
bkaabaaaacaaaaaadcaaaaakicaabaaaabaaaaaaakaabaaaacaaaaaaakaabaaa
acaaaaaadkaabaiaebaaaaaaabaaaaaadcaaaaakhccabaaaadaaaaaaegiccaaa
acaaaaaacmaaaaaapgapbaaaabaaaaaaegacbaaaadaaaaaadiaaaaajhcaabaaa
acaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaal
hcaabaaaacaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaacaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaacaaaaaaaaaaaaaihcaabaaaacaaaaaa
egacbaaaacaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaacaaaaaa
egacbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
baaaaaahcccabaaaaeaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaah
bccabaaaaeaaaaaaegbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaaheccabaaa
aeaaaaaaegbcbaaaacaaaaaaegacbaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaafaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaafaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 304
Matrix 112 [_ProjMat]
Vector 272 [_MainTex_ST]
Vector 288 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedbbojibehebekajjlihplbgnfephbbbloabaaaaaakabaaaaaaeaaaaaa
daaaaaaalmafaaaacaapaaaaoiapaaaaebgpgodjieafaaaaieafaaaaaaacpopp
pmaeaaaaiiaaaaaaaiaaceaaaaaaieaaaaaaieaaaaaaceaaabaaieaaaaaaahaa
aeaaabaaaaaaaaaaaaaabbaaacaaafaaaaaaaaaaabaaaeaaacaaahaaaaaaaaaa
acaaaaaaabaaajaaaaaaaaaaacaacgaaahaaakaaaaaaaaaaadaaaeaaaeaabbaa
aaaaaaaaadaaamaaadaabfaaaaaaaaaaadaabaaaafaabiaaaaaaaaaaaaaaaaaa
aaacpoppfbaaaaafbnaaapkaaaaaiadpaaaaaadpaaaaaaaaaaaaaaaabpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
bpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaafaaoekaafaaooka
aeaaaaaeaaaaamoaadaaeejaagaaeekaagaaoekaabaaaaacaaaaapiaajaaoeka
afaaaaadabaaahiaaaaaffiabjaaoekaaeaaaaaeabaaahiabiaaoekaaaaaaaia
abaaoeiaaeaaaaaeaaaaahiabkaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahia
blaaoekaaaaappiaaaaaoeiaaiaaaaadabaaaboaabaaoejaaaaaoeiaabaaaaac
abaaahiaacaaoejaafaaaaadacaaahiaabaanciaabaamjjaaeaaaaaeabaaahia
abaamjiaabaancjaacaaoeibafaaaaadabaaahiaabaaoeiaabaappjaaiaaaaad
abaaacoaabaaoeiaaaaaoeiaaiaaaaadabaaaeoaacaaoejaaaaaoeiaabaaaaac
aaaaahiaahaaoekaafaaaaadacaaahiaaaaaffiabjaaoekaaeaaaaaeaaaaalia
biaakekaaaaaaaiaacaakeiaaeaaaaaeaaaaahiabkaaoekaaaaakkiaaaaapeia
acaaaaadaaaaahiaaaaaoeiablaaoekaaeaaaaaeaaaaahiaaaaaoeiabmaappka
aaaaoejbaiaaaaadadaaaboaabaaoejaaaaaoeiaaiaaaaadadaaacoaabaaoeia
aaaaoeiaaiaaaaadadaaaeoaacaaoejaaaaaoeiaafaaaaadaaaaahiaacaaoeja
bmaappkaafaaaaadabaaahiaaaaaffiabgaaoekaaeaaaaaeaaaaaliabfaakeka
aaaaaaiaabaakeiaaeaaaaaeaaaaahiabhaaoekaaaaakkiaaaaapeiaabaaaaac
aaaaaiiabnaaaakaajaaaaadabaaabiaakaaoekaaaaaoeiaajaaaaadabaaacia
alaaoekaaaaaoeiaajaaaaadabaaaeiaamaaoekaaaaaoeiaafaaaaadacaaapia
aaaacjiaaaaakeiaajaaaaadadaaabiaanaaoekaacaaoeiaajaaaaadadaaacia
aoaaoekaacaaoeiaajaaaaadadaaaeiaapaaoekaacaaoeiaacaaaaadabaaahia
abaaoeiaadaaoeiaafaaaaadaaaaaciaaaaaffiaaaaaffiaaeaaaaaeaaaaabia
aaaaaaiaaaaaaaiaaaaaffibaeaaaaaeacaaahoabaaaoekaaaaaaaiaabaaoeia
abaaaaacaaaaapiaacaaoekaafaaaaadabaaapiaaaaaoeiabcaaffkaabaaaaac
acaaapiaabaaoekaaeaaaaaeabaaapiaacaaoeiabcaaaakaabaaoeiaabaaaaac
adaaapiaadaaoekaaeaaaaaeabaaapiaadaaoeiabcaakkkaabaaoeiaabaaaaac
aeaaapiaaeaaoekaaeaaaaaeabaaapiaaeaaoeiabcaappkaabaaoeiaafaaaaad
abaaapiaabaaoeiaaaaaffjaafaaaaadafaaapiaaaaaoeiabbaaffkaaeaaaaae
afaaapiaacaaoeiabbaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiabbaakkka
afaaoeiaaeaaaaaeafaaapiaaeaaoeiabbaappkaafaaoeiaaeaaaaaeabaaapia
afaaoeiaaaaaaajaabaaoeiaafaaaaadafaaapiaaaaaoeiabdaaffkaaeaaaaae
afaaapiaacaaoeiabdaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiabdaakkka
afaaoeiaaeaaaaaeafaaapiaaeaaoeiabdaappkaafaaoeiaaeaaaaaeabaaapia
afaaoeiaaaaakkjaabaaoeiaafaaaaadaaaaapiaaaaaoeiabeaaffkaaeaaaaae
aaaaapiaacaaoeiabeaaaakaaaaaoeiaaeaaaaaeaaaaapiaadaaoeiabeaakkka
aaaaoeiaaeaaaaaeaaaaapiaaeaaoeiabeaappkaaaaaoeiaaeaaaaaeaaaaapia
aaaaoeiaaaaappjaabaaoeiaafaaaaadabaaabiaaaaaffiaaiaaaakaafaaaaad
abaaaiiaabaaaaiabnaaffkaafaaaaadabaaafiaaaaapeiabnaaffkaacaaaaad
aeaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeia
abaaaaacaaaaammaaaaaoeiaabaaaaacaeaaamoaaaaaoeiappppaaaafdeieefc
fmajaaaaeaaaabaafhacaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaae
egiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaa
abaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaad
pccabaaaafaaaaaagiaaaaacagaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaiaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
akaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaakaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaa
agaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
adaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaa
egiacaaaaaaaaaaabbaaaaaaogikcaaaaaaaaaaabbaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaabcaaaaaakgiocaaaaaaaaaaa
bcaaaaaadiaaaaahhcaabaaaabaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaa
dcaaaaakhcaabaaaabaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaia
ebaaaaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaa
abaaaaaadiaaaaajhcaabaaaacaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaa
adaaaaaabbaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaabaaaaaaa
agiacaaaacaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaabcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaacaaaaaa
dcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaa
aaaaaaaaegacbaaaacaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaaabaaaaaa
egacbaaaacaaaaaabaaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaa
acaaaaaabaaaaaaheccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaaacaaaaaa
diaaaaaihcaabaaaacaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaa
diaaaaaihcaabaaaadaaaaaafgafbaaaacaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaaklcaabaaaacaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaacaaaaaa
egaibaaaadaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgakbaaaacaaaaaaegadbaaaacaaaaaadgaaaaaficaabaaaacaaaaaaabeaaaaa
aaaaiadpbbaaaaaibcaabaaaadaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaa
acaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaa
acaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaa
acaaaaaadiaaaaahpcaabaaaaeaaaaaajgacbaaaacaaaaaaegakbaaaacaaaaaa
bbaaaaaibcaabaaaafaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaaeaaaaaa
bbaaaaaiccaabaaaafaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaaeaaaaaa
bbaaaaaiecaabaaaafaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaaeaaaaaa
aaaaaaahhcaabaaaadaaaaaaegacbaaaadaaaaaaegacbaaaafaaaaaadiaaaaah
icaabaaaabaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaadcaaaaakicaabaaa
abaaaaaaakaabaaaacaaaaaaakaabaaaacaaaaaadkaabaiaebaaaaaaabaaaaaa
dcaaaaakhccabaaaadaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaabaaaaaa
egacbaaaadaaaaaadiaaaaajhcaabaaaacaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaa
acaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
acaaaaaaaaaaaaaihcaabaaaacaaaaaaegacbaaaacaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaacaaaaaaegacbaaaacaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaaeaaaaaaegacbaaa
abaaaaaaegacbaaaacaaaaaabaaaaaahbccabaaaaeaaaaaaegbcbaaaabaaaaaa
egacbaaaacaaaaaabaaaaaaheccabaaaaeaaaaaaegbcbaaaacaaaaaaegacbaaa
acaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaafaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaa
keaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaakeaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 13 [_ProjMat]
Vector 17 [_ProjectionParams]
Vector 19 [unity_LightmapST]
Vector 20 [_MainTex_ST]
Vector 21 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[22] = { { 0.5 },
		state.matrix.modelview[0],
		program.local[5..21] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R1, c[2];
MOV R0, c[1];
MUL R2, R1, c[16].y;
MAD R3, R0, c[16].x, R2;
MOV R2, c[3];
MAD R4, R2, c[16].z, R3;
MOV R3, c[4];
MUL R5, R1, c[15].y;
MAD R4, R3, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R1, c[13].y;
MAD R5, R0, c[15].x, R5;
MUL R1, R1, c[14].y;
MAD R4, R0, c[13].x, R4;
MAD R0, R0, c[14].x, R1;
MAD R1, R2, c[13].z, R4;
MAD R1, R3, c[13].w, R1;
DP4 R6.x, vertex.position, R1;
MAD R0, R2, c[14].z, R0;
MAD R0, R3, c[14].w, R0;
DP4 R6.y, vertex.position, R0;
MUL R0.xyz, R6.xyww, c[0].x;
MAD R1, R2, c[15].z, R5;
MAD R1, R3, c[15].w, R1;
DP4 R6.z, vertex.position, R1;
MUL R0.y, R0, c[17].x;
ADD result.texcoord[2].xy, R0, R0.z;
MOV result.position, R6;
MOV result.texcoord[2].zw, R6;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[21].xyxy, c[21];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[20], c[20].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[19], c[19].zwzw;
END
# 32 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Matrix 0 [glstate_matrix_modelview0]
Matrix 12 [_ProjMat]
Vector 16 [_ProjectionParams]
Vector 17 [_ScreenParams]
Vector 18 [unity_LightmapST]
Vector 19 [_MainTex_ST]
Vector 20 [_BumpMap_ST]
"vs_2_0
def c21, 0.50000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r1, c3, r0.x, r1
dp4 r0.w, r1, v0
mov r0.x, c12.y
mul r1, c1, r0.x
mov r0.x, c12
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.x, c12.w
mad r2, c3, r0.x, r1
mov r0.y, c13
mul r1, c1, r0.y
mov r0.x, c13
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r2
dp4 r0.y, v0, r1
mul r2.xyz, r0.xyww, c21.x
mov r0.z, c14.y
mul r1, c1, r0.z
mov r0.z, c14.x
mad r1, c0, r0.z, r1
mov r0.z, c14
mad r1, c2, r0.z, r1
mov r0.z, c14.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mul r2.y, r2, c16.x
mad oT2.xy, r2.z, c17.zwzw, r2
mov oPos, r0
mov oT2.zw, r0
mad oT0.zw, v3.xyxy, c20.xyxy, c20
mad oT0.xy, v3, c19, c19.zwzw
mad oT1.xy, v4, c18, c18.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 320
Matrix 112 [_ProjMat]
Vector 272 [unity_LightmapST]
Vector 288 [_MainTex_ST]
Vector 304 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecednboolngiobiebghadbbhfccllcaioiceabaaaaaafiagaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaaaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
neaeaaaaeaaaabaadfabaaaafjaaaaaeegiocaaaaaaaaaaabeaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaaaiaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaacaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
acaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaacaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaacaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaabcaaaaaaogikcaaaaaaaaaaa
bcaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
bdaaaaaakgiocaaaaaaaaaaabdaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaa
aeaaaaaaegiacaaaaaaaaaaabbaaaaaaogikcaaaaaaaaaaabbaaaaaadiaaaaai
ccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaak
ncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadp
aaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaa
adaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
ConstBuffer "$Globals" 320
Matrix 112 [_ProjMat]
Vector 272 [unity_LightmapST]
Vector 288 [_MainTex_ST]
Vector 304 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedhpikmaappcgcnknhdlpicmnccdhidjagabaaaaaafeajaaaaaeaaaaaa
daaaaaaaciadaaaaaeaiaaaammaiaaaaebgpgodjpaacaaaapaacaaaaaaacpopp
jiacaaaafiaaaaaaaeaaceaaaaaafeaaaaaafeaaaaaaceaaabaafeaaaaaaahaa
aeaaabaaaaaaaaaaaaaabbaaadaaafaaaaaaaaaaabaaafaaabaaaiaaaaaaaaaa
acaaaeaaaeaaajaaaaaaaaaaaaaaaaaaaaacpoppfbaaaaafanaaapkaaaaaaadp
aaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaiaaaaaapjabpaaaaacafaaadia
adaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaaeaaaaadoaadaaoejaagaaoeka
agaaookaaeaaaaaeaaaaamoaadaaeejaahaaeekaahaaoekaaeaaaaaeabaaadoa
aeaaoejaafaaoekaafaaookaabaaaaacaaaaapiaacaaoekaafaaaaadabaaapia
aaaaoeiaakaaffkaabaaaaacacaaapiaabaaoekaaeaaaaaeabaaapiaacaaoeia
akaaaakaabaaoeiaabaaaaacadaaapiaadaaoekaaeaaaaaeabaaapiaadaaoeia
akaakkkaabaaoeiaabaaaaacaeaaapiaaeaaoekaaeaaaaaeabaaapiaaeaaoeia
akaappkaabaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaadafaaapia
aaaaoeiaajaaffkaaeaaaaaeafaaapiaacaaoeiaajaaaakaafaaoeiaaeaaaaae
afaaapiaadaaoeiaajaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaajaappka
afaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaadafaaapia
aaaaoeiaalaaffkaaeaaaaaeafaaapiaacaaoeiaalaaaakaafaaoeiaaeaaaaae
afaaapiaadaaoeiaalaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaalaappka
afaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaadaaaaapia
aaaaoeiaamaaffkaaeaaaaaeaaaaapiaacaaoeiaamaaaakaaaaaoeiaaeaaaaae
aaaaapiaadaaoeiaamaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeiaamaappka
aaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeiaafaaaaadabaaabia
aaaaffiaaiaaaakaafaaaaadabaaaiiaabaaaaiaanaaaakaafaaaaadabaaafia
aaaapeiaanaaaakaacaaaaadacaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadma
aaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacacaaamoa
aaaaoeiappppaaaafdeieefcneaeaaaaeaaaabaadfabaaaafjaaaaaeegiocaaa
aaaaaaaabeaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaa
acaaaaaaaiaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaadaaaaaa
fpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
giaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaa
fgifcaaaacaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ahaaaaaaagiacaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaa
acaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaacaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaacaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
acaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
bcaaaaaaogikcaaaaaaaaaaabcaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaabdaaaaaakgiocaaaaaaaaaaabdaaaaaadcaaaaal
dccabaaaacaaaaaaegbabaaaaeaaaaaaegiacaaaaaaaaaaabbaaaaaaogikcaaa
aaaaaaaabbaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaadaaaaaakgaobaaa
aaaaaaaaaaaaaaahdccabaaaadaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
doaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apaaaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaaaaaalaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adamaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[24] = { { 1, 0.5 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MAD R5, R1, c[13].z, R5;
MAD R4, R1, c[14].z, R4;
MAD R4, R0, c[14].w, R4;
MAD R5, R0, c[13].w, R5;
MUL R3, R3, c[15].y;
MAD R2, R2, c[15].x, R3;
MAD R1, R1, c[15].z, R2;
MAD R1, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
DP4 R6.y, vertex.position, R4;
DP4 R6.x, vertex.position, R5;
MUL R4.xyz, R6.xyww, c[0].y;
MUL R4.y, R4, c[18].x;
MOV R2.w, c[0].x;
MOV R2.xyz, c[17];
MUL R0.xyz, R0, vertex.attrib[14].w;
DP4 R1.z, R2, c[11];
DP4 R1.x, R2, c[9];
DP4 R1.y, R2, c[10];
MAD R1.xyz, R1, c[20].w, -vertex.position;
ADD result.texcoord[3].xy, R4, R4.z;
MOV result.position, R6;
MOV result.texcoord[3].zw, R6;
DP3 result.texcoord[2].y, R1, R0;
DP3 result.texcoord[2].z, vertex.normal, R1;
DP3 result.texcoord[2].x, R1, vertex.attrib[14];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[23].xyxy, c[23];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[22], c[22].zwzw;
MAD result.texcoord[1].xy, vertex.texcoord[1], c[21], c[21].zwzw;
END
# 45 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_Scale]
Vector 20 [unity_LightmapST]
Vector 21 [_MainTex_ST]
Vector 22 [_BumpMap_ST]
"vs_2_0
def c23, 1.00000000, 0.50000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r0.w, r0, v0
mov r1.x, c12.y
mov r0.x, c12
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.y, c12.w
mad r2, c3, r0.y, r1
mov r0.x, c13.y
mul r1, c1, r0.x
mov r0.x, c13
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r1, c3, r0.x, r1
dp4 r0.y, v0, r1
dp4 r0.x, v0, r2
mul r1.xyz, r0.xyww, c23.y
mul r1.y, r1, c17.x
mad oT3.xy, r1.z, c18.zwzw, r1
mov r1.w, c23.x
mov r1.xyz, c16
dp4 r2.z, r1, c10
dp4 r2.x, r1, c8
dp4 r2.y, r1, c9
mad r2.xyz, r2, c19.w, -v0
mov r1.xyz, v1
mul r1.xyz, v2.zxyw, r1.yzxw
mov r3.xyz, v1
mad r3.xyz, v2.yzxw, r3.zxyw, -r1
mov r0.z, c14.y
mul r1, c1, r0.z
mov r0.z, c14.x
mad r1, c0, r0.z, r1
mov r0.z, c14
mad r1, c2, r0.z, r1
mov r0.z, c14.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mul r3.xyz, r3, v1.w
dp3 oT2.y, r2, r3
mov oPos, r0
mov oT3.zw, r0
dp3 oT2.z, v2, r2
dp3 oT2.x, r2, v1
mad oT0.zw, v3.xyxy, c22.xyxy, c22
mad oT0.xy, v3, c21, c21.zwzw
mad oT1.xy, v4, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 320
Matrix 112 [_ProjMat]
Vector 272 [unity_LightmapST]
Vector 288 [_MainTex_ST]
Vector 304 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedjgehbcoboffpfmeaeofagndkpjchnpipabaaaaaabaaiaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadamaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcheagaaaaeaaaabaa
jnabaaaafjaaaaaeegiocaaaaaaaaaaabeaaaaaafjaaaaaeegiocaaaabaaaaaa
agaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaa
gfaaaaadpccabaaaabaaaaaagfaaaaaddccabaaaacaaaaaagfaaaaadhccabaaa
adaaaaaagfaaaaadpccabaaaaeaaaaaagiaaaaacadaaaaaadiaaaaajpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaaafaaaaaadcaaaaal
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaacaaaaaaafaaaaaa
egaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaaj
pcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaaaeaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaacaaaaaa
aeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaa
fgifcaaaacaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
ahaaaaaaagiacaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaa
acaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaaahaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaacaaaaaaahaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaa
acaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaakaaaaaapgipcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaa
egbabaaaadaaaaaaegiacaaaaaaaaaaabcaaaaaaogikcaaaaaaaaaaabcaaaaaa
dcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaabdaaaaaa
kgiocaaaaaaaaaaabdaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaaeaaaaaa
egiacaaaaaaaaaaabbaaaaaaogikcaaaaaaaaaaabbaaaaaadiaaaaahhcaabaaa
abaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaa
jgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaadiaaaaah
hcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaa
acaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaal
hcaabaaaacaaaaaaegiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaacaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaacaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaacaaaaaaaaaaaaaihcaabaaaacaaaaaa
egacbaaaacaaaaaaegiccaaaacaaaaaabdaaaaaadcaaaaalhcaabaaaacaaaaaa
egacbaaaacaaaaaapgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
baaaaaahcccabaaaadaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaah
bccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaaheccabaaa
adaaaaaaegbcbaaaacaaaaaaegacbaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaa
agahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaaf
mccabaaaaeaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaaeaaaaaakgakbaaa
abaaaaaamgaabaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 320
Matrix 112 [_ProjMat]
Vector 272 [unity_LightmapST]
Vector 288 [_MainTex_ST]
Vector 304 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0_level_9_1
eefiecedafblbiaghkdeghnciidonkifghddkamhabaaaaaaaiamaaaaaeaaaaaa
daaaaaaaceaeaaaakaakaaaagialaaaaebgpgodjomadaaaaomadaaaaaaacpopp
iiadaaaageaaaaaaafaaceaaaaaagaaaaaaagaaaaaaaceaaabaagaaaaaaaahaa
aeaaabaaaaaaaaaaaaaabbaaadaaafaaaaaaaaaaabaaaeaaacaaaiaaaaaaaaaa
acaaaeaaaeaaakaaaaaaaaaaacaabaaaafaaaoaaaaaaaaaaaaaaaaaaaaacpopp
fbaaaaafbdaaapkaaaaaaadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacafaaaaia
aaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapjabpaaaaac
afaaadiaadaaapjabpaaaaacafaaaeiaaeaaapjaaeaaaaaeaaaaadoaadaaoeja
agaaoekaagaaookaaeaaaaaeaaaaamoaadaaeejaahaaeekaahaaoekaaeaaaaae
abaaadoaaeaaoejaafaaoekaafaaookaabaaaaacaaaaahiaaiaaoekaafaaaaad
abaaahiaaaaaffiaapaaoekaaeaaaaaeaaaaaliaaoaakekaaaaaaaiaabaakeia
aeaaaaaeaaaaahiabaaaoekaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeia
bbaaoekaaeaaaaaeaaaaahiaaaaaoeiabcaappkaaaaaoejbaiaaaaadacaaaboa
abaaoejaaaaaoeiaabaaaaacabaaahiaabaaoejaafaaaaadacaaahiaabaamjia
acaancjaaeaaaaaeabaaahiaacaamjjaabaanciaacaaoeibafaaaaadabaaahia
abaaoeiaabaappjaaiaaaaadacaaacoaabaaoeiaaaaaoeiaaiaaaaadacaaaeoa
acaaoejaaaaaoeiaabaaaaacaaaaapiaacaaoekaafaaaaadabaaapiaaaaaoeia
alaaffkaabaaaaacacaaapiaabaaoekaaeaaaaaeabaaapiaacaaoeiaalaaaaka
abaaoeiaabaaaaacadaaapiaadaaoekaaeaaaaaeabaaapiaadaaoeiaalaakkka
abaaoeiaabaaaaacaeaaapiaaeaaoekaaeaaaaaeabaaapiaaeaaoeiaalaappka
abaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaadafaaapiaaaaaoeia
akaaffkaaeaaaaaeafaaapiaacaaoeiaakaaaakaafaaoeiaaeaaaaaeafaaapia
adaaoeiaakaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaakaappkaafaaoeia
aeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaadafaaapiaaaaaoeia
amaaffkaaeaaaaaeafaaapiaacaaoeiaamaaaakaafaaoeiaaeaaaaaeafaaapia
adaaoeiaamaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaamaappkaafaaoeia
aeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaadaaaaapiaaaaaoeia
anaaffkaaeaaaaaeaaaaapiaacaaoeiaanaaaakaaaaaoeiaaeaaaaaeaaaaapia
adaaoeiaanaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeiaanaappkaaaaaoeia
aeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeiaafaaaaadabaaabiaaaaaffia
ajaaaakaafaaaaadabaaaiiaabaaaaiabdaaaakaafaaaaadabaaafiaaaaapeia
bdaaaakaacaaaaadadaaadoaabaakkiaabaaomiaaeaaaaaeaaaaadmaaaaappia
aaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiaabaaaaacadaaamoaaaaaoeia
ppppaaaafdeieefcheagaaaaeaaaabaajnabaaaafjaaaaaeegiocaaaaaaaaaaa
beaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
dccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaa
giaaaaacadaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaa
fgifcaaaacaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ahaaaaaaagiacaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaa
acaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaacaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaacaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaacaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
acaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaacaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
bcaaaaaaogikcaaaaaaaaaaabcaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaabdaaaaaakgiocaaaaaaaaaaabdaaaaaadcaaaaal
dccabaaaacaaaaaaegbabaaaaeaaaaaaegiacaaaaaaaaaaabbaaaaaaogikcaaa
aaaaaaaabbaaaaaadiaaaaahhcaabaaaabaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaabaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaabaaaaaadiaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgbpbaaaabaaaaaadiaaaaajhcaabaaaacaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaacaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaa
acaaaaaaegiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
acaaaaaaaaaaaaaihcaabaaaacaaaaaaegacbaaaacaaaaaaegiccaaaacaaaaaa
bdaaaaaadcaaaaalhcaabaaaacaaaaaaegacbaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaa
abaaaaaaegacbaaaacaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaa
egacbaaaacaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaa
acaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaaeaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaaeaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaadamaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_WorldSpaceLightPos0]
Vector 19 [unity_4LightPosX0]
Vector 20 [unity_4LightPosY0]
Vector 21 [unity_4LightPosZ0]
Vector 22 [unity_4LightAtten0]
Vector 23 [unity_LightColor0]
Vector 24 [unity_LightColor1]
Vector 25 [unity_LightColor2]
Vector 26 [unity_LightColor3]
Vector 27 [unity_SHAr]
Vector 28 [unity_SHAg]
Vector 29 [unity_SHAb]
Vector 30 [unity_SHBr]
Vector 31 [unity_SHBg]
Vector 32 [unity_SHBb]
Vector 33 [unity_SHC]
Vector 34 [unity_Scale]
Vector 35 [_MainTex_ST]
Vector 36 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[37] = { { 1, 0 },
		state.matrix.modelview[0],
		program.local[5..36] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MUL R3.xyz, vertex.normal, c[34].w;
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[20];
DP3 R3.w, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[19];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0].x;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[21];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[22];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[24];
MAD R1.xyz, R0.x, c[23], R1;
MAD R0.xyz, R0.z, c[25], R1;
MAD R1.xyz, R0.w, c[26], R0;
MUL R0, R4.xyzz, R4.yzzx;
DP4 R3.z, R0, c[32];
DP4 R3.y, R0, c[31];
DP4 R3.x, R0, c[30];
MUL R1.w, R3, R3;
MAD R0.x, R4, R4, -R1.w;
DP4 R2.z, R4, c[29];
DP4 R2.y, R4, c[28];
DP4 R2.x, R4, c[27];
ADD R2.xyz, R2, R3;
MUL R3.xyz, R0.x, c[33];
ADD R3.xyz, R2, R3;
ADD result.texcoord[2].xyz, R3, R1;
MOV R1, c[18];
MOV R0.xyz, vertex.attrib[14];
MUL R2.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R2;
DP4 R6.z, R1, c[11];
DP4 R6.y, R1, c[10];
DP4 R6.x, R1, c[9];
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.w, c[0].x;
MOV R1.xyz, c[17];
MOV R3, c[2];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R7.xyz, R2, c[34].w, -vertex.position;
MOV R2, c[1];
MUL R1, R3, c[15].y;
MAD R4, R2, c[15].x, R1;
MOV R1, c[3];
MAD R5, R1, c[15].z, R4;
DP3 result.texcoord[1].y, R6, R0;
DP3 result.texcoord[3].y, R0, R7;
MUL R0, R3, c[16].y;
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
MAD R5, R0, c[15].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MUL R3, R3, c[13].y;
MAD R4, R2, c[14].x, R4;
MAD R2, R2, c[13].x, R3;
MAD R3, R1, c[14].z, R4;
MAD R1, R1, c[13].z, R2;
MAD R2, R0, c[14].w, R3;
MAD R0, R0, c[13].w, R1;
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP4 result.position.x, vertex.position, R0;
DP3 result.texcoord[1].z, vertex.normal, R6;
DP3 result.texcoord[1].x, R6, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R7;
DP3 result.texcoord[3].x, vertex.attrib[14], R7;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[36].xyxy, c[36];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[35], c[35].zwzw;
END
# 95 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_WorldSpaceLightPos0]
Vector 18 [unity_4LightPosX0]
Vector 19 [unity_4LightPosY0]
Vector 20 [unity_4LightPosZ0]
Vector 21 [unity_4LightAtten0]
Vector 22 [unity_LightColor0]
Vector 23 [unity_LightColor1]
Vector 24 [unity_LightColor2]
Vector 25 [unity_LightColor3]
Vector 26 [unity_SHAr]
Vector 27 [unity_SHAg]
Vector 28 [unity_SHAb]
Vector 29 [unity_SHBr]
Vector 30 [unity_SHBg]
Vector 31 [unity_SHBb]
Vector 32 [unity_SHC]
Vector 33 [unity_Scale]
Vector 34 [_MainTex_ST]
Vector 35 [_BumpMap_ST]
"vs_2_0
def c36, 1.00000000, 0.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r3.xyz, v2, c33.w
dp4 r0.x, v0, c5
add r1, -r0.x, c19
dp3 r3.w, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c18
mul r1, r1, r1
mov r4.z, r3.x
mad r2, r4.x, r0, r2
mov r4.w, c36.x
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c20
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c21
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c36.x
dp4 r2.z, r4, c28
dp4 r2.y, r4, c27
dp4 r2.x, r4, c26
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c36.y
mul r0, r0, r1
mul r1.xyz, r0.y, c23
mad r1.xyz, r0.x, c22, r1
mad r0.xyz, r0.z, c24, r1
mad r1.xyz, r0.w, c25, r0
mul r0, r4.xyzz, r4.yzzx
mul r1.w, r3, r3
dp4 r3.z, r0, c31
dp4 r3.y, r0, c30
dp4 r3.x, r0, c29
mad r1.w, r4.x, r4.x, -r1
mul r0.xyz, r1.w, c32
add r2.xyz, r2, r3
add r0.xyz, r2, r0
add oT2.xyz, r0, r1
mov r1.w, c36.x
mov r1.xyz, c16
dp4 r0.z, r1, c10
dp4 r0.y, r1, c9
dp4 r0.x, r1, c8
mad r3.xyz, r0, c33.w, -v0
mov r1.xyz, v1
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r1.yzxw
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c17, r0
mov r0, c8
dp4 r4.x, c17, r0
mov r1, c9
dp4 r4.y, c17, r1
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c14.y
mov r0.x, c14
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c14.z
mad r1, c2, r0.x, r1
mov r0.x, c14.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c13.y
mov r0.x, c13
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r0, c3, r0.x, r1
dp3 oT1.y, r4, r2
dp3 oT3.y, r2, r3
mov r2.x, c12.y
mul r1, c1, r2.x
mov r2.x, c12
mad r1, c0, r2.x, r1
mov r2.x, c12.z
mad r1, c2, r2.x, r1
mov r2.x, c12.w
mad r1, c3, r2.x, r1
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT3.z, v2, r3
dp3 oT3.x, v1, r3
dp4 oPos.y, v0, r0
dp4 oPos.x, v0, r1
mad oT0.zw, v3.xyxy, c35.xyxy, c35
mad oT0.xy, v3, c34, c34.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedhfngdeocalkbcolllahiacegidhaklegabaaaaaalaanaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbeamaaaaeaaaabaa
afadaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacahaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
afaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
anaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaah
hcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaaj
hcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaah
eccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadgaaaaaficaabaaa
abaaaaaaabeaaaaaaaaaiadpdiaaaaaihcaabaaaacaaaaaaegbcbaaaacaaaaaa
pgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaadaaaaaafgafbaaaacaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaacaaaaaaegiicaaaadaaaaaa
amaaaaaaagaabaaaacaaaaaaegaibaaaadaaaaaadcaaaaakhcaabaaaabaaaaaa
egiccaaaadaaaaaaaoaaaaaakgakbaaaacaaaaaaegadbaaaacaaaaaabbaaaaai
bcaabaaaacaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaai
ccaabaaaacaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaai
ecaabaaaacaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaabaaaaaadiaaaaah
pcaabaaaadaaaaaajgacbaaaabaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaa
aeaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaa
aeaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaa
aeaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaadaaaaaaaaaaaaahhcaabaaa
acaaaaaaegacbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaahicaabaaaaaaaaaaa
bkaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaa
abaaaaaaakaabaaaabaaaaaadkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaa
acaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaa
diaaaaaihcaabaaaadaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaakhcaabaaaadaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaa
egacbaaaadaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaa
adaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaadaaaaaaaaaaaaajpcaabaaa
aeaaaaaafgafbaiaebaaaaaaadaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaah
pcaabaaaafaaaaaafgafbaaaabaaaaaaegaobaaaaeaaaaaadiaaaaahpcaabaaa
aeaaaaaaegaobaaaaeaaaaaaegaobaaaaeaaaaaaaaaaaaajpcaabaaaagaaaaaa
agaabaiaebaaaaaaadaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaa
adaaaaaakgakbaiaebaaaaaaadaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaaj
pcaabaaaafaaaaaaegaobaaaagaaaaaaagaabaaaabaaaaaaegaobaaaafaaaaaa
dcaaaaajpcaabaaaabaaaaaaegaobaaaadaaaaaakgakbaaaabaaaaaaegaobaaa
afaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaagaaaaaaegaobaaaagaaaaaa
egaobaaaaeaaaaaadcaaaaajpcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaa
adaaaaaaegaobaaaaeaaaaaaeeaaaaafpcaabaaaaeaaaaaaegaobaaaadaaaaaa
dcaaaaanpcaabaaaadaaaaaaegaobaaaadaaaaaaegiocaaaacaaaaaaafaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaadaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaadaaaaaadiaaaaah
pcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaaaeaaaaaadeaaaaakpcaabaaa
abaaaaaaegaobaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
diaaaaahpcaabaaaabaaaaaaegaobaaaadaaaaaaegaobaaaabaaaaaadiaaaaai
hcaabaaaadaaaaaafgafbaaaabaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaak
hcaabaaaadaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaabaaaaaaegacbaaa
adaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaa
abaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaa
ajaaaaaapgapbaaaabaaaaaaegacbaaaabaaaaaaaaaaaaahhccabaaaadaaaaaa
egacbaaaabaaaaaaegacbaaaacaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaa
aeaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaaeaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaaeaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedodgihlpamfdbplkfighploncblofclnbabaaaaaaombeaaaaaeaaaaaa
daaaaaaagiahaaaaiebdaaaaembeaaaaebgpgodjdaahaaaadaahaaaaaaacpopp
kiagaaaaiiaaaaaaaiaaceaaaaaaieaaaaaaieaaaaaaceaaabaaieaaaaaaadaa
aeaaabaaaaaaaaaaaaaaanaaacaaafaaaaaaaaaaabaaaeaaabaaahaaaaaaaaaa
acaaaaaaabaaaiaaaaaaaaaaacaaacaaaiaaajaaaaaaaaaaacaacgaaahaabbaa
aaaaaaaaadaaaeaaaeaabiaaaaaaaaaaadaaamaaajaabmaaaaaaaaaaaaaaaaaa
aaacpoppfbaaaaafcfaaapkaaaaaiadpaaaaaaaaaaaaaaaaaaaaaaaabpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
bpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaafaaoekaafaaooka
aeaaaaaeaaaaamoaadaaeejaagaaeekaagaaoekaabaaaaacaaaaapiaaiaaoeka
afaaaaadabaaahiaaaaaffiacbaaoekaaeaaaaaeabaaahiacaaaoekaaaaaaaia
abaaoeiaaeaaaaaeaaaaahiaccaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahia
cdaaoekaaaaappiaaaaaoeiaaiaaaaadabaaaboaabaaoejaaaaaoeiaabaaaaac
abaaahiaacaaoejaafaaaaadacaaahiaabaanciaabaamjjaaeaaaaaeabaaahia
abaamjiaabaancjaacaaoeibafaaaaadabaaahiaabaaoeiaabaappjaaiaaaaad
abaaacoaabaaoeiaaaaaoeiaaiaaaaadabaaaeoaacaaoejaaaaaoeiaabaaaaac
aaaaahiaahaaoekaafaaaaadacaaahiaaaaaffiacbaaoekaaeaaaaaeaaaaalia
caaakekaaaaaaaiaacaakeiaaeaaaaaeaaaaahiaccaaoekaaaaakkiaaaaapeia
acaaaaadaaaaahiaaaaaoeiacdaaoekaaeaaaaaeaaaaahiaaaaaoeiaceaappka
aaaaoejbaiaaaaadadaaaboaabaaoejaaaaaoeiaaiaaaaadadaaacoaabaaoeia
aaaaoeiaaiaaaaadadaaaeoaacaaoejaaaaaoeiaafaaaaadaaaaahiaaaaaffja
bnaaoekaaeaaaaaeaaaaahiabmaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
boaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiabpaaoekaaaaappjaaaaaoeia
acaaaaadabaaapiaaaaakkibalaaoekaacaaaaadacaaapiaaaaaaaibajaaoeka
acaaaaadaaaaapiaaaaaffibakaaoekaafaaaaadadaaahiaacaaoejaceaappka
afaaaaadaeaaahiaadaaffiabnaaoekaaeaaaaaeadaaaliabmaakekaadaaaaia
aeaakeiaaeaaaaaeadaaahiaboaaoekaadaakkiaadaapeiaafaaaaadaeaaapia
aaaaoeiaadaaffiaafaaaaadaaaaapiaaaaaoeiaaaaaoeiaaeaaaaaeaaaaapia
acaaoeiaacaaoeiaaaaaoeiaaeaaaaaeacaaapiaacaaoeiaadaaaaiaaeaaoeia
aeaaaaaeacaaapiaabaaoeiaadaakkiaacaaoeiaaeaaaaaeaaaaapiaabaaoeia
abaaoeiaaaaaoeiaahaaaaacabaaabiaaaaaaaiaahaaaaacabaaaciaaaaaffia
ahaaaaacabaaaeiaaaaakkiaahaaaaacabaaaiiaaaaappiaabaaaaacaeaaabia
cfaaaakaaeaaaaaeaaaaapiaaaaaoeiaamaaoekaaeaaaaiaafaaaaadabaaapia
abaaoeiaacaaoeiaalaaaaadabaaapiaabaaoeiacfaaffkaagaaaaacacaaabia
aaaaaaiaagaaaaacacaaaciaaaaaffiaagaaaaacacaaaeiaaaaakkiaagaaaaac
acaaaiiaaaaappiaafaaaaadaaaaapiaabaaoeiaacaaoeiaafaaaaadabaaahia
aaaaffiaaoaaoekaaeaaaaaeabaaahiaanaaoekaaaaaaaiaabaaoeiaaeaaaaae
aaaaahiaapaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahiabaaaoekaaaaappia
aaaaoeiaabaaaaacadaaaiiacfaaaakaajaaaaadabaaabiabbaaoekaadaaoeia
ajaaaaadabaaaciabcaaoekaadaaoeiaajaaaaadabaaaeiabdaaoekaadaaoeia
afaaaaadacaaapiaadaacjiaadaakeiaajaaaaadaeaaabiabeaaoekaacaaoeia
ajaaaaadaeaaaciabfaaoekaacaaoeiaajaaaaadaeaaaeiabgaaoekaacaaoeia
acaaaaadabaaahiaabaaoeiaaeaaoeiaafaaaaadaaaaaiiaadaaffiaadaaffia
aeaaaaaeaaaaaiiaadaaaaiaadaaaaiaaaaappibaeaaaaaeabaaahiabhaaoeka
aaaappiaabaaoeiaacaaaaadacaaahoaaaaaoeiaabaaoeiaabaaaaacaaaaapia
acaaoekaafaaaaadabaaapiaaaaaoeiabjaaffkaabaaaaacacaaapiaabaaoeka
aeaaaaaeabaaapiaacaaoeiabjaaaakaabaaoeiaabaaaaacadaaapiaadaaoeka
aeaaaaaeabaaapiaadaaoeiabjaakkkaabaaoeiaabaaaaacaeaaapiaaeaaoeka
aeaaaaaeabaaapiaaeaaoeiabjaappkaabaaoeiaafaaaaadabaaapiaabaaoeia
aaaaffjaafaaaaadafaaapiaaaaaoeiabiaaffkaaeaaaaaeafaaapiaacaaoeia
biaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiabiaakkkaafaaoeiaaeaaaaae
afaaapiaaeaaoeiabiaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaaja
abaaoeiaafaaaaadafaaapiaaaaaoeiabkaaffkaaeaaaaaeafaaapiaacaaoeia
bkaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiabkaakkkaafaaoeiaaeaaaaae
afaaapiaaeaaoeiabkaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkja
abaaoeiaafaaaaadaaaaapiaaaaaoeiablaaffkaaeaaaaaeaaaaapiaacaaoeia
blaaaakaaaaaoeiaaeaaaaaeaaaaapiaadaaoeiablaakkkaaaaaoeiaaeaaaaae
aaaaapiaaeaaoeiablaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappja
abaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaamma
aaaaoeiappppaaaafdeieefcbeamaaaaeaaaabaaafadaaaafjaaaaaeegiocaaa
aaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaa
acaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaa
aaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaad
dcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaad
hccabaaaaeaaaaaagiaaaaacahaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
agaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaa
agaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
adaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaaaaaaaaaa
egaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaa
anaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
aoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaa
abaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaa
cgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaa
acaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahcccabaaa
acaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaacaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadgaaaaaficaabaaaabaaaaaaabeaaaaaaaaaiadp
diaaaaaihcaabaaaacaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaabeaaaaaa
diaaaaaihcaabaaaadaaaaaafgafbaaaacaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaaklcaabaaaacaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaaacaaaaaa
egaibaaaadaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgakbaaaacaaaaaaegadbaaaacaaaaaabbaaaaaibcaabaaaacaaaaaaegiocaaa
acaaaaaacgaaaaaaegaobaaaabaaaaaabbaaaaaiccaabaaaacaaaaaaegiocaaa
acaaaaaachaaaaaaegaobaaaabaaaaaabbaaaaaiecaabaaaacaaaaaaegiocaaa
acaaaaaaciaaaaaaegaobaaaabaaaaaadiaaaaahpcaabaaaadaaaaaajgacbaaa
abaaaaaaegakbaaaabaaaaaabbaaaaaibcaabaaaaeaaaaaaegiocaaaacaaaaaa
cjaaaaaaegaobaaaadaaaaaabbaaaaaiccaabaaaaeaaaaaaegiocaaaacaaaaaa
ckaaaaaaegaobaaaadaaaaaabbaaaaaiecaabaaaaeaaaaaaegiocaaaacaaaaaa
claaaaaaegaobaaaadaaaaaaaaaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaa
egacbaaaaeaaaaaadiaaaaahicaabaaaaaaaaaaabkaabaaaabaaaaaabkaabaaa
abaaaaaadcaaaaakicaabaaaaaaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaa
dkaabaiaebaaaaaaaaaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaa
cmaaaaaapgapbaaaaaaaaaaaegacbaaaacaaaaaadiaaaaaihcaabaaaadaaaaaa
fgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaadaaaaaa
egiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaadaaaaaadcaaaaak
hcaabaaaadaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
adaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaadaaaaaaaaaaaaajpcaabaaaaeaaaaaafgafbaiaebaaaaaa
adaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaahpcaabaaaafaaaaaafgafbaaa
abaaaaaaegaobaaaaeaaaaaadiaaaaahpcaabaaaaeaaaaaaegaobaaaaeaaaaaa
egaobaaaaeaaaaaaaaaaaaajpcaabaaaagaaaaaaagaabaiaebaaaaaaadaaaaaa
egiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaaadaaaaaakgakbaiaebaaaaaa
adaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaa
agaaaaaaagaabaaaabaaaaaaegaobaaaafaaaaaadcaaaaajpcaabaaaabaaaaaa
egaobaaaadaaaaaakgakbaaaabaaaaaaegaobaaaafaaaaaadcaaaaajpcaabaaa
aeaaaaaaegaobaaaagaaaaaaegaobaaaagaaaaaaegaobaaaaeaaaaaadcaaaaaj
pcaabaaaadaaaaaaegaobaaaadaaaaaaegaobaaaadaaaaaaegaobaaaaeaaaaaa
eeaaaaafpcaabaaaaeaaaaaaegaobaaaadaaaaaadcaaaaanpcaabaaaadaaaaaa
egaobaaaadaaaaaaegiocaaaacaaaaaaafaaaaaaaceaaaaaaaaaiadpaaaaiadp
aaaaiadpaaaaiadpaoaaaaakpcaabaaaadaaaaaaaceaaaaaaaaaiadpaaaaiadp
aaaaiadpaaaaiadpegaobaaaadaaaaaadiaaaaahpcaabaaaabaaaaaaegaobaaa
abaaaaaaegaobaaaaeaaaaaadeaaaaakpcaabaaaabaaaaaaegaobaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaaabaaaaaa
egaobaaaadaaaaaaegaobaaaabaaaaaadiaaaaaihcaabaaaadaaaaaafgafbaaa
abaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaa
acaaaaaaagaaaaaaagaabaaaabaaaaaaegacbaaaadaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaaabaaaaaaegacbaaaadaaaaaa
dcaaaaakhcaabaaaabaaaaaaegiccaaaacaaaaaaajaaaaaapgapbaaaabaaaaaa
egacbaaaabaaaaaaaaaaaaahhccabaaaadaaaaaaegacbaaaabaaaaaaegacbaaa
acaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaa
adaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
aaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaabdaaaaaa
dcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaabeaaaaaa
egbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaaeaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahbccabaaaaeaaaaaaegbcbaaaabaaaaaaegacbaaa
abaaaaaabaaaaaaheccabaaaaeaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaa
doaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaa
apapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaa
adaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaa
apaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffied
epepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [_WorldSpaceLightPos0]
Vector 20 [unity_4LightPosX0]
Vector 21 [unity_4LightPosY0]
Vector 22 [unity_4LightPosZ0]
Vector 23 [unity_4LightAtten0]
Vector 24 [unity_LightColor0]
Vector 25 [unity_LightColor1]
Vector 26 [unity_LightColor2]
Vector 27 [unity_LightColor3]
Vector 28 [unity_SHAr]
Vector 29 [unity_SHAg]
Vector 30 [unity_SHAb]
Vector 31 [unity_SHBr]
Vector 32 [unity_SHBg]
Vector 33 [unity_SHBb]
Vector 34 [unity_SHC]
Vector 35 [unity_Scale]
Vector 36 [_MainTex_ST]
Vector 37 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[38] = { { 1, 0, 0.5 },
		state.matrix.modelview[0],
		program.local[5..37] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MUL R3.xyz, vertex.normal, c[35].w;
DP4 R0.x, vertex.position, c[6];
ADD R1, -R0.x, c[21];
DP3 R3.w, R3, c[6];
DP3 R4.x, R3, c[5];
DP3 R3.x, R3, c[7];
MUL R2, R3.w, R1;
DP4 R0.x, vertex.position, c[5];
ADD R0, -R0.x, c[20];
MUL R1, R1, R1;
MOV R4.z, R3.x;
MAD R2, R4.x, R0, R2;
MOV R4.w, c[0].x;
DP4 R4.y, vertex.position, c[7];
MAD R1, R0, R0, R1;
ADD R0, -R4.y, c[22];
MAD R1, R0, R0, R1;
MAD R0, R3.x, R0, R2;
MUL R2, R1, c[23];
MOV R4.y, R3.w;
RSQ R1.x, R1.x;
RSQ R1.y, R1.y;
RSQ R1.w, R1.w;
RSQ R1.z, R1.z;
MUL R0, R0, R1;
ADD R1, R2, c[0].x;
RCP R1.x, R1.x;
RCP R1.y, R1.y;
RCP R1.w, R1.w;
RCP R1.z, R1.z;
MAX R0, R0, c[0].y;
MUL R0, R0, R1;
MUL R1.xyz, R0.y, c[25];
MAD R1.xyz, R0.x, c[24], R1;
MAD R0.xyz, R0.z, c[26], R1;
MUL R1, R4.xyzz, R4.yzzx;
MAD R0.xyz, R0.w, c[27], R0;
MUL R0.w, R3, R3;
DP4 R3.z, R1, c[33];
DP4 R3.y, R1, c[32];
DP4 R3.x, R1, c[31];
MAD R0.w, R4.x, R4.x, -R0;
DP4 R2.z, R4, c[30];
DP4 R2.y, R4, c[29];
DP4 R2.x, R4, c[28];
ADD R2.xyz, R2, R3;
MOV R3, c[2];
MUL R1.xyz, R0.w, c[34];
ADD R1.xyz, R2, R1;
ADD result.texcoord[2].xyz, R1, R0;
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[15].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[13].y;
MAD R5, R2, c[15].x, R5;
MUL R3, R3, c[14].y;
MAD R4, R2, c[13].x, R4;
MAD R2, R2, c[14].x, R3;
MAD R3, R1, c[13].z, R4;
MAD R2, R1, c[14].z, R2;
MAD R3, R0, c[13].w, R3;
MAD R2, R0, c[14].w, R2;
DP4 R6.y, vertex.position, R2;
DP4 R6.x, vertex.position, R3;
MAD R1, R1, c[15].z, R5;
MAD R0, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R0;
MUL R2.xyz, R6.xyww, c[0].z;
MUL R2.y, R2, c[18].x;
ADD result.texcoord[4].xy, R2, R2.z;
MOV R2.xyz, c[17];
MOV R2.w, c[0].x;
MOV R1.xyz, vertex.attrib[14];
DP4 R0.z, R2, c[11];
DP4 R0.y, R2, c[10];
DP4 R0.x, R2, c[9];
MAD R0.xyz, R0, c[35].w, -vertex.position;
MUL R2.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R2.xyz, vertex.normal.yzxw, R1.zxyw, -R2;
MOV R1, c[19];
MUL R2.xyz, R2, vertex.attrib[14].w;
DP4 R3.z, R1, c[11];
DP4 R3.y, R1, c[10];
DP4 R3.x, R1, c[9];
MOV result.position, R6;
MOV result.texcoord[4].zw, R6;
DP3 result.texcoord[1].y, R3, R2;
DP3 result.texcoord[3].y, R2, R0;
DP3 result.texcoord[1].z, vertex.normal, R3;
DP3 result.texcoord[1].x, R3, vertex.attrib[14];
DP3 result.texcoord[3].z, vertex.normal, R0;
DP3 result.texcoord[3].x, vertex.attrib[14], R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[37].xyxy, c[37];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[36], c[36].zwzw;
END
# 100 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [_WorldSpaceLightPos0]
Vector 20 [unity_4LightPosX0]
Vector 21 [unity_4LightPosY0]
Vector 22 [unity_4LightPosZ0]
Vector 23 [unity_4LightAtten0]
Vector 24 [unity_LightColor0]
Vector 25 [unity_LightColor1]
Vector 26 [unity_LightColor2]
Vector 27 [unity_LightColor3]
Vector 28 [unity_SHAr]
Vector 29 [unity_SHAg]
Vector 30 [unity_SHAb]
Vector 31 [unity_SHBr]
Vector 32 [unity_SHBg]
Vector 33 [unity_SHBb]
Vector 34 [unity_SHC]
Vector 35 [unity_Scale]
Vector 36 [_MainTex_ST]
Vector 37 [_BumpMap_ST]
"vs_2_0
def c38, 1.00000000, 0.00000000, 0.50000000, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mul r3.xyz, v2, c35.w
dp4 r0.x, v0, c5
add r1, -r0.x, c21
dp3 r3.w, r3, c5
dp3 r4.x, r3, c4
dp3 r3.x, r3, c6
mul r2, r3.w, r1
dp4 r0.x, v0, c4
add r0, -r0.x, c20
mul r1, r1, r1
mov r4.z, r3.x
mad r2, r4.x, r0, r2
mov r4.w, c38.x
dp4 r4.y, v0, c6
mad r1, r0, r0, r1
add r0, -r4.y, c22
mad r1, r0, r0, r1
mad r0, r3.x, r0, r2
mul r2, r1, c23
mov r4.y, r3.w
rsq r1.x, r1.x
rsq r1.y, r1.y
rsq r1.w, r1.w
rsq r1.z, r1.z
mul r0, r0, r1
add r1, r2, c38.x
dp4 r2.z, r4, c30
dp4 r2.y, r4, c29
dp4 r2.x, r4, c28
rcp r1.x, r1.x
rcp r1.y, r1.y
rcp r1.w, r1.w
rcp r1.z, r1.z
max r0, r0, c38.y
mul r0, r0, r1
mul r1.xyz, r0.y, c25
mad r1.xyz, r0.x, c24, r1
mad r0.xyz, r0.z, c26, r1
mul r1, r4.xyzz, r4.yzzx
mad r0.xyz, r0.w, c27, r0
mul r0.w, r3, r3
dp4 r3.z, r1, c33
dp4 r3.y, r1, c32
dp4 r3.x, r1, c31
add r1.xyz, r2, r3
mad r0.w, r4.x, r4.x, -r0
mul r2.xyz, r0.w, c34
add r4.xyz, r1, r2
mov r0.w, c15.y
mul r1, c1, r0.w
mov r0.w, c15.x
mad r1, c0, r0.w, r1
mov r0.w, c15.z
mad r1, c2, r0.w, r1
mov r0.w, c15
mad r1, c3, r0.w, r1
dp4 r3.w, r1, v0
mov r0.w, c12.y
mul r1, c1, r0.w
mov r0.w, c12.x
mad r1, c0, r0.w, r1
mov r0.w, c12.z
mad r1, c2, r0.w, r1
mov r2.x, c12.w
mad r2, c3, r2.x, r1
dp4 r3.x, v0, r2
mov r0.w, c13.y
mul r1, c1, r0.w
mov r0.w, c13.x
mad r1, c0, r0.w, r1
mov r0.w, c13.z
mad r1, c2, r0.w, r1
mov r0.w, c13
mad r1, c3, r0.w, r1
dp4 r3.y, v0, r1
mul r1.xyz, r3.xyww, c38.z
add oT2.xyz, r4, r0
mov r2.xyz, v1
mov r0.x, r1
mul r0.y, r1, c17.x
mad oT4.xy, r1.z, c18.zwzw, r0
mul r1.xyz, v2.zxyw, r2.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r4.xyz, r1, v1.w
mov r1, c9
dp4 r2.y, c19, r1
mov r0, c10
dp4 r2.z, c19, r0
mov r0, c8
dp4 r2.x, c19, r0
mov r0.x, c14.y
mov r1.x, c14
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c14.z
mad r0, c2, r1.x, r0
mov r1.x, c14.w
mad r1, c3, r1.x, r0
dp4 r3.z, v0, r1
mov r0.xyz, c16
mov r0.w, c38.x
dp4 r5.z, r0, c10
dp4 r5.x, r0, c8
dp4 r5.y, r0, c9
mad r0.xyz, r5, c35.w, -v0
dp3 oT1.y, r2, r4
dp3 oT3.y, r4, r0
mov oPos, r3
mov oT4.zw, r3
dp3 oT1.z, v2, r2
dp3 oT1.x, r2, v1
dp3 oT3.z, v2, r0
dp3 oT3.x, v1, r0
mad oT0.zw, v3.xyxy, c37.xyxy, c37
mad oT0.xy, v3, c36, c36.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 304
Matrix 112 [_ProjMat]
Vector 272 [_MainTex_ST]
Vector 288 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedjldfkamckodjjdohnbbhdpohlpjjeokbabaaaaaagaaoaaaaadaaaaaa
cmaaaaaapeaaaaaakmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaa
aiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklfdeieefckmamaaaaeaaaabaacladaaaafjaaaaae
egiocaaaaaaaaaaabdaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaae
egiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagiaaaaacaiaaaaaa
diaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaa
afaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaal
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaafaaaaaa
egaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
adaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaa
aeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
akaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaj
pcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaahaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaa
abaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaa
egaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaabbaaaaaaogikcaaa
aaaaaaaabbaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaa
aaaaaaaabcaaaaaakgiocaaaaaaaaaaabcaaaaaadiaaaaahhcaabaaaabaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaabaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaadiaaaaahhcaabaaa
abaaaaaaegacbaaaabaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaaacaaaaaa
fgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaa
acaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaa
acaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaa
acaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaa
adaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaaacaaaaaabaaaaaah
cccabaaaacaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahbccabaaa
acaaaaaaegbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaaheccabaaaacaaaaaa
egbcbaaaacaaaaaaegacbaaaacaaaaaadgaaaaaficaabaaaacaaaaaaabeaaaaa
aaaaiadpdiaaaaaihcaabaaaadaaaaaaegbcbaaaacaaaaaapgipcaaaadaaaaaa
beaaaaaadiaaaaaihcaabaaaaeaaaaaafgafbaaaadaaaaaaegiccaaaadaaaaaa
anaaaaaadcaaaaaklcaabaaaadaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaaa
adaaaaaaegaibaaaaeaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaadaaaaaa
aoaaaaaakgakbaaaadaaaaaaegadbaaaadaaaaaabbaaaaaibcaabaaaadaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaacaaaaaadiaaaaahpcaabaaaaeaaaaaa
jgacbaaaacaaaaaaegakbaaaacaaaaaabbaaaaaibcaabaaaafaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaaeaaaaaabbaaaaaiccaabaaaafaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaaeaaaaaabbaaaaaiecaabaaaafaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaaeaaaaaaaaaaaaahhcaabaaaadaaaaaaegacbaaa
adaaaaaaegacbaaaafaaaaaadiaaaaahicaabaaaabaaaaaabkaabaaaacaaaaaa
bkaabaaaacaaaaaadcaaaaakicaabaaaabaaaaaaakaabaaaacaaaaaaakaabaaa
acaaaaaadkaabaiaebaaaaaaabaaaaaadcaaaaakhcaabaaaadaaaaaaegiccaaa
acaaaaaacmaaaaaapgapbaaaabaaaaaaegacbaaaadaaaaaadiaaaaaihcaabaaa
aeaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaa
aeaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaeaaaaaa
dcaaaaakhcaabaaaaeaaaaaaegiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaa
egacbaaaaeaaaaaadcaaaaakhcaabaaaaeaaaaaaegiccaaaadaaaaaaapaaaaaa
pgbpbaaaaaaaaaaaegacbaaaaeaaaaaaaaaaaaajpcaabaaaafaaaaaafgafbaia
ebaaaaaaaeaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaahpcaabaaaagaaaaaa
fgafbaaaacaaaaaaegaobaaaafaaaaaadiaaaaahpcaabaaaafaaaaaaegaobaaa
afaaaaaaegaobaaaafaaaaaaaaaaaaajpcaabaaaahaaaaaaagaabaiaebaaaaaa
aeaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaaaeaaaaaakgakbaia
ebaaaaaaaeaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaajpcaabaaaagaaaaaa
egaobaaaahaaaaaaagaabaaaacaaaaaaegaobaaaagaaaaaadcaaaaajpcaabaaa
acaaaaaaegaobaaaaeaaaaaakgakbaaaacaaaaaaegaobaaaagaaaaaadcaaaaaj
pcaabaaaafaaaaaaegaobaaaahaaaaaaegaobaaaahaaaaaaegaobaaaafaaaaaa
dcaaaaajpcaabaaaaeaaaaaaegaobaaaaeaaaaaaegaobaaaaeaaaaaaegaobaaa
afaaaaaaeeaaaaafpcaabaaaafaaaaaaegaobaaaaeaaaaaadcaaaaanpcaabaaa
aeaaaaaaegaobaaaaeaaaaaaegiocaaaacaaaaaaafaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaaeaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpegaobaaaaeaaaaaadiaaaaahpcaabaaaacaaaaaa
egaobaaaacaaaaaaegaobaaaafaaaaaadeaaaaakpcaabaaaacaaaaaaegaobaaa
acaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadiaaaaahpcaabaaa
acaaaaaaegaobaaaaeaaaaaaegaobaaaacaaaaaadiaaaaaihcaabaaaaeaaaaaa
fgafbaaaacaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaakhcaabaaaaeaaaaaa
egiccaaaacaaaaaaagaaaaaaagaabaaaacaaaaaaegacbaaaaeaaaaaadcaaaaak
hcaabaaaacaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaaacaaaaaaegacbaaa
aeaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaajaaaaaapgapbaaa
acaaaaaaegacbaaaacaaaaaaaaaaaaahhccabaaaadaaaaaaegacbaaaacaaaaaa
egacbaaaadaaaaaadiaaaaajhcaabaaaacaaaaaafgifcaaaabaaaaaaaeaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaa
acaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaa
acaaaaaaaaaaaaaihcaabaaaacaaaaaaegacbaaaacaaaaaaegiccaaaadaaaaaa
bdaaaaaadcaaaaalhcaabaaaacaaaaaaegacbaaaacaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaaeaaaaaaegacbaaa
abaaaaaaegacbaaaacaaaaaabaaaaaahbccabaaaaeaaaaaaegbcbaaaabaaaaaa
egacbaaaacaaaaaabaaaaaaheccabaaaaeaaaaaaegbcbaaaacaaaaaaegacbaaa
acaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaa
afaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadp
aaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaafaaaaaakgaobaaaaaaaaaaa
aaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 304
Matrix 112 [_ProjMat]
Vector 272 [_MainTex_ST]
Vector 288 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
Vector 32 [unity_4LightPosX0]
Vector 48 [unity_4LightPosY0]
Vector 64 [unity_4LightPosZ0]
Vector 80 [unity_4LightAtten0]
Vector 96 [unity_LightColor0]
Vector 112 [unity_LightColor1]
Vector 128 [unity_LightColor2]
Vector 144 [unity_LightColor3]
Vector 160 [unity_LightColor4]
Vector 176 [unity_LightColor5]
Vector 192 [unity_LightColor6]
Vector 208 [unity_LightColor7]
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedahdopmbgkdcphliblddihmmialdeefjcabaaaaaaoibfaaaaaeaaaaaa
daaaaaaaleahaaaagibeaaaadabfaaaaebgpgodjhmahaaaahmahaaaaaaacpopp
peagaaaaiiaaaaaaaiaaceaaaaaaieaaaaaaieaaaaaaceaaabaaieaaaaaaahaa
aeaaabaaaaaaaaaaaaaabbaaacaaafaaaaaaaaaaabaaaeaaacaaahaaaaaaaaaa
acaaaaaaabaaajaaaaaaaaaaacaaacaaaiaaakaaaaaaaaaaacaacgaaahaabcaa
aaaaaaaaadaaaeaaaeaabjaaaaaaaaaaadaaamaaajaabnaaaaaaaaaaaaaaaaaa
aaacpoppfbaaaaafcgaaapkaaaaaiadpaaaaaaaaaaaaaadpaaaaaaaabpaaaaac
afaaaaiaaaaaapjabpaaaaacafaaabiaabaaapjabpaaaaacafaaaciaacaaapja
bpaaaaacafaaadiaadaaapjaaeaaaaaeaaaaadoaadaaoejaafaaoekaafaaooka
aeaaaaaeaaaaamoaadaaeejaagaaeekaagaaoekaabaaaaacaaaaapiaajaaoeka
afaaaaadabaaahiaaaaaffiaccaaoekaaeaaaaaeabaaahiacbaaoekaaaaaaaia
abaaoeiaaeaaaaaeaaaaahiacdaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahia
ceaaoekaaaaappiaaaaaoeiaaiaaaaadabaaaboaabaaoejaaaaaoeiaabaaaaac
abaaahiaacaaoejaafaaaaadacaaahiaabaanciaabaamjjaaeaaaaaeabaaahia
abaamjiaabaancjaacaaoeibafaaaaadabaaahiaabaaoeiaabaappjaaiaaaaad
abaaacoaabaaoeiaaaaaoeiaaiaaaaadabaaaeoaacaaoejaaaaaoeiaabaaaaac
aaaaahiaahaaoekaafaaaaadacaaahiaaaaaffiaccaaoekaaeaaaaaeaaaaalia
cbaakekaaaaaaaiaacaakeiaaeaaaaaeaaaaahiacdaaoekaaaaakkiaaaaapeia
acaaaaadaaaaahiaaaaaoeiaceaaoekaaeaaaaaeaaaaahiaaaaaoeiacfaappka
aaaaoejbaiaaaaadadaaaboaabaaoejaaaaaoeiaaiaaaaadadaaacoaabaaoeia
aaaaoeiaaiaaaaadadaaaeoaacaaoejaaaaaoeiaafaaaaadaaaaahiaaaaaffja
boaaoekaaeaaaaaeaaaaahiabnaaoekaaaaaaajaaaaaoeiaaeaaaaaeaaaaahia
bpaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaahiacaaaoekaaaaappjaaaaaoeia
acaaaaadabaaapiaaaaakkibamaaoekaacaaaaadacaaapiaaaaaaaibakaaoeka
acaaaaadaaaaapiaaaaaffibalaaoekaafaaaaadadaaahiaacaaoejacfaappka
afaaaaadaeaaahiaadaaffiaboaaoekaaeaaaaaeadaaaliabnaakekaadaaaaia
aeaakeiaaeaaaaaeadaaahiabpaaoekaadaakkiaadaapeiaafaaaaadaeaaapia
aaaaoeiaadaaffiaafaaaaadaaaaapiaaaaaoeiaaaaaoeiaaeaaaaaeaaaaapia
acaaoeiaacaaoeiaaaaaoeiaaeaaaaaeacaaapiaacaaoeiaadaaaaiaaeaaoeia
aeaaaaaeacaaapiaabaaoeiaadaakkiaacaaoeiaaeaaaaaeaaaaapiaabaaoeia
abaaoeiaaaaaoeiaahaaaaacabaaabiaaaaaaaiaahaaaaacabaaaciaaaaaffia
ahaaaaacabaaaeiaaaaakkiaahaaaaacabaaaiiaaaaappiaabaaaaacaeaaabia
cgaaaakaaeaaaaaeaaaaapiaaaaaoeiaanaaoekaaeaaaaiaafaaaaadabaaapia
abaaoeiaacaaoeiaalaaaaadabaaapiaabaaoeiacgaaffkaagaaaaacacaaabia
aaaaaaiaagaaaaacacaaaciaaaaaffiaagaaaaacacaaaeiaaaaakkiaagaaaaac
acaaaiiaaaaappiaafaaaaadaaaaapiaabaaoeiaacaaoeiaafaaaaadabaaahia
aaaaffiaapaaoekaaeaaaaaeabaaahiaaoaaoekaaaaaaaiaabaaoeiaaeaaaaae
aaaaahiabaaaoekaaaaakkiaabaaoeiaaeaaaaaeaaaaahiabbaaoekaaaaappia
aaaaoeiaabaaaaacadaaaiiacgaaaakaajaaaaadabaaabiabcaaoekaadaaoeia
ajaaaaadabaaaciabdaaoekaadaaoeiaajaaaaadabaaaeiabeaaoekaadaaoeia
afaaaaadacaaapiaadaacjiaadaakeiaajaaaaadaeaaabiabfaaoekaacaaoeia
ajaaaaadaeaaaciabgaaoekaacaaoeiaajaaaaadaeaaaeiabhaaoekaacaaoeia
acaaaaadabaaahiaabaaoeiaaeaaoeiaafaaaaadaaaaaiiaadaaffiaadaaffia
aeaaaaaeaaaaaiiaadaaaaiaadaaaaiaaaaappibaeaaaaaeabaaahiabiaaoeka
aaaappiaabaaoeiaacaaaaadacaaahoaaaaaoeiaabaaoeiaabaaaaacaaaaapia
acaaoekaafaaaaadabaaapiaaaaaoeiabkaaffkaabaaaaacacaaapiaabaaoeka
aeaaaaaeabaaapiaacaaoeiabkaaaakaabaaoeiaabaaaaacadaaapiaadaaoeka
aeaaaaaeabaaapiaadaaoeiabkaakkkaabaaoeiaabaaaaacaeaaapiaaeaaoeka
aeaaaaaeabaaapiaaeaaoeiabkaappkaabaaoeiaafaaaaadabaaapiaabaaoeia
aaaaffjaafaaaaadafaaapiaaaaaoeiabjaaffkaaeaaaaaeafaaapiaacaaoeia
bjaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiabjaakkkaafaaoeiaaeaaaaae
afaaapiaaeaaoeiabjaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaaja
abaaoeiaafaaaaadafaaapiaaaaaoeiablaaffkaaeaaaaaeafaaapiaacaaoeia
blaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiablaakkkaafaaoeiaaeaaaaae
afaaapiaaeaaoeiablaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkja
abaaoeiaafaaaaadaaaaapiaaaaaoeiabmaaffkaaeaaaaaeaaaaapiaacaaoeia
bmaaaakaaaaaoeiaaeaaaaaeaaaaapiaadaaoeiabmaakkkaaaaaoeiaaeaaaaae
aaaaapiaaeaaoeiabmaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappja
abaaoeiaafaaaaadabaaabiaaaaaffiaaiaaaakaafaaaaadabaaaiiaabaaaaia
cgaakkkaafaaaaadabaaafiaaaaapeiacgaakkkaacaaaaadaeaaadoaabaakkia
abaaomiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaamma
aaaaoeiaabaaaaacaeaaamoaaaaaoeiappppaaaafdeieefckmamaaaaeaaaabaa
cladaaaafjaaaaaeegiocaaaaaaaaaaabdaaaaaafjaaaaaeegiocaaaabaaaaaa
agaaaaaafjaaaaaeegiocaaaacaaaaaacnaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaa
giaaaaacaiaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaa
fgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ahaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
adaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
bbaaaaaaogikcaaaaaaaaaaabbaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaabcaaaaaakgiocaaaaaaaaaaabcaaaaaadiaaaaah
hcaabaaaabaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaa
abaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaabaaaaaa
diaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaapgbpbaaaabaaaaaadiaaaaaj
hcaabaaaacaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaa
aaaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaacaaaaaadcaaaaalhcaabaaa
acaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaa
acaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaa
baaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaah
eccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaaacaaaaaadgaaaaaficaabaaa
acaaaaaaabeaaaaaaaaaiadpdiaaaaaihcaabaaaadaaaaaaegbcbaaaacaaaaaa
pgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaaeaaaaaafgafbaaaadaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaadaaaaaaegiicaaaadaaaaaa
amaaaaaaagaabaaaadaaaaaaegaibaaaaeaaaaaadcaaaaakhcaabaaaacaaaaaa
egiccaaaadaaaaaaaoaaaaaakgakbaaaadaaaaaaegadbaaaadaaaaaabbaaaaai
bcaabaaaadaaaaaaegiocaaaacaaaaaacgaaaaaaegaobaaaacaaaaaabbaaaaai
ccaabaaaadaaaaaaegiocaaaacaaaaaachaaaaaaegaobaaaacaaaaaabbaaaaai
ecaabaaaadaaaaaaegiocaaaacaaaaaaciaaaaaaegaobaaaacaaaaaadiaaaaah
pcaabaaaaeaaaaaajgacbaaaacaaaaaaegakbaaaacaaaaaabbaaaaaibcaabaaa
afaaaaaaegiocaaaacaaaaaacjaaaaaaegaobaaaaeaaaaaabbaaaaaiccaabaaa
afaaaaaaegiocaaaacaaaaaackaaaaaaegaobaaaaeaaaaaabbaaaaaiecaabaaa
afaaaaaaegiocaaaacaaaaaaclaaaaaaegaobaaaaeaaaaaaaaaaaaahhcaabaaa
adaaaaaaegacbaaaadaaaaaaegacbaaaafaaaaaadiaaaaahicaabaaaabaaaaaa
bkaabaaaacaaaaaabkaabaaaacaaaaaadcaaaaakicaabaaaabaaaaaaakaabaaa
acaaaaaaakaabaaaacaaaaaadkaabaiaebaaaaaaabaaaaaadcaaaaakhcaabaaa
adaaaaaaegiccaaaacaaaaaacmaaaaaapgapbaaaabaaaaaaegacbaaaadaaaaaa
diaaaaaihcaabaaaaeaaaaaafgbfbaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaa
dcaaaaakhcaabaaaaeaaaaaaegiccaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaa
egacbaaaaeaaaaaadcaaaaakhcaabaaaaeaaaaaaegiccaaaadaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegacbaaaaeaaaaaadcaaaaakhcaabaaaaeaaaaaaegiccaaa
adaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaeaaaaaaaaaaaaajpcaabaaa
afaaaaaafgafbaiaebaaaaaaaeaaaaaaegiocaaaacaaaaaaadaaaaaadiaaaaah
pcaabaaaagaaaaaafgafbaaaacaaaaaaegaobaaaafaaaaaadiaaaaahpcaabaaa
afaaaaaaegaobaaaafaaaaaaegaobaaaafaaaaaaaaaaaaajpcaabaaaahaaaaaa
agaabaiaebaaaaaaaeaaaaaaegiocaaaacaaaaaaacaaaaaaaaaaaaajpcaabaaa
aeaaaaaakgakbaiaebaaaaaaaeaaaaaaegiocaaaacaaaaaaaeaaaaaadcaaaaaj
pcaabaaaagaaaaaaegaobaaaahaaaaaaagaabaaaacaaaaaaegaobaaaagaaaaaa
dcaaaaajpcaabaaaacaaaaaaegaobaaaaeaaaaaakgakbaaaacaaaaaaegaobaaa
agaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaaahaaaaaaegaobaaaahaaaaaa
egaobaaaafaaaaaadcaaaaajpcaabaaaaeaaaaaaegaobaaaaeaaaaaaegaobaaa
aeaaaaaaegaobaaaafaaaaaaeeaaaaafpcaabaaaafaaaaaaegaobaaaaeaaaaaa
dcaaaaanpcaabaaaaeaaaaaaegaobaaaaeaaaaaaegiocaaaacaaaaaaafaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaakpcaabaaaaeaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpegaobaaaaeaaaaaadiaaaaah
pcaabaaaacaaaaaaegaobaaaacaaaaaaegaobaaaafaaaaaadeaaaaakpcaabaaa
acaaaaaaegaobaaaacaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
diaaaaahpcaabaaaacaaaaaaegaobaaaaeaaaaaaegaobaaaacaaaaaadiaaaaai
hcaabaaaaeaaaaaafgafbaaaacaaaaaaegiccaaaacaaaaaaahaaaaaadcaaaaak
hcaabaaaaeaaaaaaegiccaaaacaaaaaaagaaaaaaagaabaaaacaaaaaaegacbaaa
aeaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaaaiaaaaaakgakbaaa
acaaaaaaegacbaaaaeaaaaaadcaaaaakhcaabaaaacaaaaaaegiccaaaacaaaaaa
ajaaaaaapgapbaaaacaaaaaaegacbaaaacaaaaaaaaaaaaahhccabaaaadaaaaaa
egacbaaaacaaaaaaegacbaaaadaaaaaadiaaaaajhcaabaaaacaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaacaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaacaaaaaa
dcaaaaalhcaabaaaacaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaacaaaaaaaaaaaaaihcaabaaaacaaaaaaegacbaaaacaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaacaaaaaaegacbaaaacaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaa
aeaaaaaaegacbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahbccabaaaaeaaaaaa
egbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaaheccabaaaaeaaaaaaegbcbaaa
acaaaaaaegacbaaaacaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaa
akiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaa
aceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaafaaaaaa
kgaobaaaaaaaaaaaaaaaaaahdccabaaaafaaaaaakgakbaaaabaaaaaamgaabaaa
abaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaa
laaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
afaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaa
feeffiedepepfceeaaedepemepfcaaklepfdeheolaaaaaaaagaaaaaaaiaaaaaa
jiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapaaaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahaiaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaa
keaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaakeaaaaaaaeaaaaaa
aaaaaaaaadaaaaaaafaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ClothColor]
Float 6 [_Shininess]
Float 7 [_MetalShininess]
Float 8 [_SkinShininess]
Float 9 [_ClothShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..9],
		{ 0.5, 0.029999999, 2, 1 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R3.yzw, fragment.texcoord[0], texture[1], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R5.yw, fragment.texcoord[0].zwzw, texture[2], 2D;
MOV R1, c[2];
MOV R2.x, c[6];
ADD R1, -R1, c[5];
SGE R4.xyz, R3.yzww, c[10].x;
ADD R2.x, -R2, c[9];
MAD R3.x, R4.z, R2, c[6];
MAD R1, R3.w, R1, c[2];
ADD R2, -R1, c[4];
MAD R1, R3.z, R2, R1;
ADD R2, -R1, c[3];
MAD R1, R3.y, R2, R1;
MUL R0, R0, R1;
ADD R3.w, -R3.x, c[8].x;
MAD R3.x, R4.y, R3.w, R3;
ADD R3.z, -R3.x, c[7].x;
MAD R3.x, R4, R3.z, R3;
MUL R2.x, R3, R3;
ADD R1.w, R2.x, c[10].y;
MAD R2.xy, R5.wyzw, c[10].z, -c[10].w;
MUL R2.zw, R2.xyxy, R2.xyxy;
ADD_SAT R2.z, R2, R2.w;
DP3 R3.y, fragment.texcoord[3], fragment.texcoord[3];
ADD R2.z, -R2, c[10].w;
RSQ R2.z, R2.z;
RCP R2.z, R2.z;
MUL R0.w, R0, R1;
MOV R1.xyz, fragment.texcoord[1];
RSQ R3.y, R3.y;
MAD R1.xyz, R3.y, fragment.texcoord[3], R1;
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
DP3 R1.x, R2, R1;
MUL R1.y, R3.x, c[11];
MAX R1.x, R1, c[11];
POW R1.x, R1.x, R1.y;
MUL R0.w, R0, R1.x;
DP3 R1.x, R2, fragment.texcoord[1];
MAX R2.w, R1.x, c[11].x;
MOV R1, c[1];
MUL R2.xyz, R0, c[0];
MUL R0.w, R0, c[10].z;
MUL R1.w, R1, c[0];
MUL R2.xyz, R2, R2.w;
MUL R1.xyz, R1, c[0];
MAD R1.xyz, R1, R0.w, R2;
MUL R1.xyz, R1, c[10].z;
MAD result.color.xyz, R0, fragment.texcoord[2], R1;
MUL result.color.w, R0, R1;
END
# 52 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ClothColor]
Float 6 [_Shininess]
Float 7 [_MetalShininess]
Float 8 [_SkinShininess]
Float 9 [_ClothShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c10, -0.50000000, 1.00000000, 0.00000000, 0.03000000
def c11, 2.00000000, -1.00000000, 128.00000000, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r5, t0, s1
mov_pp r2, c5
add_pp r2, -c2, r2
mad_pp r3, r5.w, r2, c2
add_pp r2, -r3, c4
mad_pp r4, r5.z, r2, r3
add_pp r3, -r4, c3
mad_pp r3, r5.y, r3, r4
add r2.yzw, r5, c10.x
dp3_pp r4.x, t3, t3
cmp r2.yzw, r2, c10.y, c10.z
mov r0.y, t0.w
mov r0.x, t0.z
rsq_pp r4.x, r4.x
mov_pp r5.xyz, t1
mad_pp r5.xyz, r4.x, t3, r5
texld r1, r0, s2
texld r0, t0, s0
mov_pp r1.x, c9
add_pp r1.x, -c6, r1
mad_pp r1.x, r2.w, r1, c6
mul r0, r0, r3
add_pp r2.x, -r1, c8
mad_pp r3.x, r2.z, r2, r1
add_pp r2.x, -r3, c7
mov r1.x, r1.w
mad_pp r1.xy, r1, c11.x, c11.y
mad_pp r3.x, r2.y, r2, r3
mul_pp r2.xy, r1, r1
add_pp_sat r4.x, r2, r2.y
dp3_pp r2.x, r5, r5
add_pp r4.x, -r4, c10.y
rsq_pp r4.x, r4.x
rcp_pp r1.z, r4.x
mul_pp r4.x, r3, c11.z
rsq_pp r2.x, r2.x
mul_pp r2.xyz, r2.x, r5
dp3_pp r2.x, r1, r2
max_pp r5.x, r2, c10.z
pow r2.y, r5.x, r4.x
mul_pp r3.x, r3, r3
add r3.x, r3, c10.w
mul r3.x, r0.w, r3
mul r2.x, r3, r2.y
dp3_pp r1.x, r1, t1
max_pp r3.x, r1, c10.z
mul_pp r4.xyz, r0, c0
mov_pp r1.xyz, c0
mul r2.x, r2, c11
mul_pp r3.xyz, r4, r3.x
mul_pp r1.xyz, c1, r1
mad r1.xyz, r1, r2.x, r3
mov_pp r0.w, c0
mul_pp r3.x, c1.w, r0.w
mul r1.xyz, r1, c11.x
mul r0.w, r2.x, r3.x
mad_pp r0.xyz, r0, t2, r1
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 112 [_Color]
Vector 144 [_MetalColor]
Vector 160 [_SkinColor]
Vector 176 [_ClothColor]
Float 192 [_Shininess]
Float 196 [_MetalShininess]
Float 200 [_SkinShininess]
Float 204 [_ClothShininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedhooajalnenbkifjmkhgoklhgfclndpdhabaaaaaajiahaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcjaagaaaaeaaaaaaakeabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaaaaaaaakpcaabaaa
aaaaaaaaegiocaiaebaaaaaaaaaaaaaaahaaaaaaegiocaaaaaaaaaaaalaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaapgapbaaaabaaaaaaegaobaaaaaaaaaaa
egiocaaaaaaaaaaaahaaaaaaaaaaaaajpcaabaaaacaaaaaaegaobaiaebaaaaaa
aaaaaaaaegiocaaaaaaaaaaaakaaaaaadcaaaaajpcaabaaaaaaaaaaakgakbaaa
abaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaajpcaabaaaacaaaaaa
egaobaiaebaaaaaaaaaaaaaaegiocaaaaaaaaaaaajaaaaaadcaaaaajpcaabaaa
aaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaabnaaaaak
hcaabaaaabaaaaaajgahbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaabaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaegaobaaaacaaaaaaaaaaaaakicaabaaaabaaaaaaakiacaiaebaaaaaa
aaaaaaaaamaaaaaadkiacaaaaaaaaaaaamaaaaaadcaaaaakecaabaaaabaaaaaa
ckaabaaaabaaaaaadkaabaaaabaaaaaaakiacaaaaaaaaaaaamaaaaaaaaaaaaaj
icaabaaaabaaaaaackaabaiaebaaaaaaabaaaaaackiacaaaaaaaaaaaamaaaaaa
dcaaaaajccaabaaaabaaaaaabkaabaaaabaaaaaadkaabaaaabaaaaaackaabaaa
abaaaaaaaaaaaaajecaabaaaabaaaaaabkaabaiaebaaaaaaabaaaaaabkiacaaa
aaaaaaaaamaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaaabaaaaaackaabaaa
abaaaaaabkaabaaaabaaaaaadcaaaaajccaabaaaabaaaaaaakaabaaaabaaaaaa
akaabaaaabaaaaaaabeaaaaaipmcpfdmdiaaaaahbcaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaaedapaaaaahicaabaaaaaaaaaaafgafbaaaabaaaaaa
pgapbaaaaaaaaaaabaaaaaahccaabaaaabaaaaaaegbcbaaaaeaaaaaaegbcbaaa
aeaaaaaaeeaaaaafccaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaajocaabaaa
abaaaaaaagbjbaaaaeaaaaaafgafbaaaabaaaaaaagbjbaaaacaaaaaabaaaaaah
bcaabaaaacaaaaaajgahbaaaabaaaaaajgahbaaaabaaaaaaeeaaaaafbcaabaaa
acaaaaaaakaabaaaacaaaaaadiaaaaahocaabaaaabaaaaaafgaobaaaabaaaaaa
agaabaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaa
acaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaa
aceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialp
aaaaaaaaaaaaaaaaapaaaaahicaabaaaacaaaaaaegaabaaaacaaaaaaegaabaaa
acaaaaaaddaaaaahicaabaaaacaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaiadp
aaaaaaaiicaabaaaacaaaaaadkaabaiaebaaaaaaacaaaaaaabeaaaaaaaaaiadp
elaaaaafecaabaaaacaaaaaadkaabaaaacaaaaaabaaaaaahccaabaaaabaaaaaa
egacbaaaacaaaaaajgahbaaaabaaaaaabaaaaaahecaabaaaabaaaaaaegacbaaa
acaaaaaaegbcbaaaacaaaaaadeaaaaakgcaabaaaabaaaaaafgagbaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacpaaaaafccaabaaaabaaaaaa
bkaabaaaabaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaabaaaaaaakaabaaa
abaaaaaabjaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaajpcaabaaaacaaaaaa
egiocaaaaaaaaaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaadiaaaaahlcaabaaa
abaaaaaapgapbaaaaaaaaaaaegaibaaaacaaaaaadiaaaaahiccabaaaaaaaaaaa
dkaabaaaaaaaaaaadkaabaaaacaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaa
aaaaaaaaegiccaaaaaaaaaaaabaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaa
acaaaaaakgakbaaaabaaaaaaegadbaaaabaaaaaaaaaaaaahhcaabaaaabaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
aaaaaaaaegbcbaaaadaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 112 [_Color]
Vector 144 [_MetalColor]
Vector 160 [_SkinColor]
Vector 176 [_ClothColor]
Float 192 [_Shininess]
Float 196 [_MetalShininess]
Float 200 [_SkinShininess]
Float 204 [_ClothShininess]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedofcohcjcnnkojlmhlgphcfmjkfilbkbcabaaaaaaiaalaaaaaeaaaaaa
daaaaaaabeaeaaaakmakaaaaemalaaaaebgpgodjnmadaaaanmadaaaaaaacpppp
iiadaaaafeaaaaaaadaadaaaaaaafeaaaaaafeaaadaaceaaaaaafeaaaaaaaaaa
abababaaacacacaaaaaaabaaacaaaaaaaaaaaaaaaaaaahaaabaaacaaaaaaaaaa
aaaaajaaaeaaadaaaaaaaaaaaaacppppfbaaaaafahaaapkaaaaaaalpipmcpfdm
aaaaaaeaaaaaialpfbaaaaafaiaaapkaaaaaaaaaaaaaaaedaaaaaaaaaaaaaaaa
bpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaaia
acaachlabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaajaaaaiapkabpaaaaac
aaaaaajaabaiapkabpaaaaacaaaaaajaacaiapkaabaaaaacaaaaabiaaaaakkla
abaaaaacaaaaaciaaaaapplaecaaaaadabaaapiaaaaaoelaabaioekaecaaaaad
acaaapiaaaaaoelaaaaioekaecaaaaadaaaacpiaaaaaoeiaacaioekaabaaaaac
adaaapiaacaaoekaacaaaaadadaaapiaadaaoeibafaaoekaaeaaaaaeadaaapia
abaappiaadaaoeiaacaaoekabcaaaaaeaeaaapiaabaakkiaaeaaoekaadaaoeia
bcaaaaaeadaaapiaabaaffiaadaaoekaaeaaoeiaacaaaaadabaaadiaabaamjia
ahaaaakaacaaaaadabaaaeiaabaappiaahaaaakaafaaaaadacaaapiaacaaoeia
adaaoeiafiaaaaaeaaaacbiaabaakkiaagaappkaagaaaakafiaaaaaeaaaacbia
abaaffiaagaakkkaaaaaaaiafiaaaaaeaaaacbiaabaaaaiaagaaffkaaaaaaaia
aeaaaaaeaaaaaeiaaaaaaaiaaaaaaaiaahaaffkaafaaaaadaaaaabiaaaaaaaia
aiaaffkaafaaaaadacaaaiiaacaappiaaaaakkiaacaaaaadacaaciiaacaappia
acaappiaaiaaaaadaaaaceiaadaaoelaadaaoelaahaaaaacaaaaceiaaaaakkia
abaaaaacabaaahiaadaaoelaaeaaaaaeabaachiaabaaoeiaaaaakkiaabaaoela
ceaaaaacadaachiaabaaoeiaaeaaaaaeabaacbiaaaaappiaahaakkkaahaappka
aeaaaaaeabaacciaaaaaffiaahaakkkaahaappkafkaaaaaeabaadiiaabaaoeia
abaaoeiaaiaaaakaacaaaaadabaaciiaabaappibahaappkbahaaaaacabaaciia
abaappiaagaaaaacabaaceiaabaappiaaiaaaaadabaaciiaabaaoeiaadaaoeia
aiaaaaadaaaacciaabaaoeiaabaaoelaalaaaaadabaacbiaaaaaffiaaiaaaaka
alaaaaadaaaaaciaabaappiaaiaaaakacaaaaaadabaaaciaaaaaffiaaaaaaaia
afaaaaadacaaaiiaacaappiaabaaffiaabaaaaacaaaaapiaaaaaoekaafaaaaad
aaaaahiaaaaaoeiaabaaoekaafaaaaadaaaaahiaacaappiaaaaaoeiaafaaaaad
abaacoiaacaabliaaaaablkaaeaaaaaeaaaaahiaabaabliaabaaaaiaaaaaoeia
acaaaaadaaaachiaaaaaoeiaaaaaoeiaaeaaaaaeabaachiaacaaoeiaacaaoela
aaaaoeiaafaaaaadaaaaabiaaaaappiaabaappkaafaaaaadabaaciiaacaappia
aaaaaaiaabaaaaacaaaicpiaabaaoeiappppaaaafdeieefcjaagaaaaeaaaaaaa
keabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaaaaaaaaakpcaabaaaaaaaaaaaegiocaiaebaaaaaa
aaaaaaaaahaaaaaaegiocaaaaaaaaaaaalaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaapgapbaaaabaaaaaaegaobaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaa
aaaaaaajpcaabaaaacaaaaaaegaobaiaebaaaaaaaaaaaaaaegiocaaaaaaaaaaa
akaaaaaadcaaaaajpcaabaaaaaaaaaaakgakbaaaabaaaaaaegaobaaaacaaaaaa
egaobaaaaaaaaaaaaaaaaaajpcaabaaaacaaaaaaegaobaiaebaaaaaaaaaaaaaa
egiocaaaaaaaaaaaajaaaaaadcaaaaajpcaabaaaaaaaaaaafgafbaaaabaaaaaa
egaobaaaacaaaaaaegaobaaaaaaaaaaabnaaaaakhcaabaaaabaaaaaajgahbaaa
abaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaaabaaaaakhcaabaaa
abaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaacaaaaaa
aaaaaaakicaabaaaabaaaaaaakiacaiaebaaaaaaaaaaaaaaamaaaaaadkiacaaa
aaaaaaaaamaaaaaadcaaaaakecaabaaaabaaaaaackaabaaaabaaaaaadkaabaaa
abaaaaaaakiacaaaaaaaaaaaamaaaaaaaaaaaaajicaabaaaabaaaaaackaabaia
ebaaaaaaabaaaaaackiacaaaaaaaaaaaamaaaaaadcaaaaajccaabaaaabaaaaaa
bkaabaaaabaaaaaadkaabaaaabaaaaaackaabaaaabaaaaaaaaaaaaajecaabaaa
abaaaaaabkaabaiaebaaaaaaabaaaaaabkiacaaaaaaaaaaaamaaaaaadcaaaaaj
bcaabaaaabaaaaaaakaabaaaabaaaaaackaabaaaabaaaaaabkaabaaaabaaaaaa
dcaaaaajccaabaaaabaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaa
ipmcpfdmdiaaaaahbcaabaaaabaaaaaaakaabaaaabaaaaaaabeaaaaaaaaaaaed
apaaaaahicaabaaaaaaaaaaafgafbaaaabaaaaaapgapbaaaaaaaaaaabaaaaaah
ccaabaaaabaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaeeaaaaafccaabaaa
abaaaaaabkaabaaaabaaaaaadcaaaaajocaabaaaabaaaaaaagbjbaaaaeaaaaaa
fgafbaaaabaaaaaaagbjbaaaacaaaaaabaaaaaahbcaabaaaacaaaaaajgahbaaa
abaaaaaajgahbaaaabaaaaaaeeaaaaafbcaabaaaacaaaaaaakaabaaaacaaaaaa
diaaaaahocaabaaaabaaaaaafgaobaaaabaaaaaaagaabaaaacaaaaaaefaaaaaj
pcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaacaaaaaa
dcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
icaabaaaacaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahicaabaaa
acaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaacaaaaaa
dkaabaiaebaaaaaaacaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaa
dkaabaaaacaaaaaabaaaaaahccaabaaaabaaaaaaegacbaaaacaaaaaajgahbaaa
abaaaaaabaaaaaahecaabaaaabaaaaaaegacbaaaacaaaaaaegbcbaaaacaaaaaa
deaaaaakgcaabaaaabaaaaaafgagbaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaacpaaaaafccaabaaaabaaaaaabkaabaaaabaaaaaadiaaaaah
bcaabaaaabaaaaaabkaabaaaabaaaaaaakaabaaaabaaaaaabjaaaaafbcaabaaa
abaaaaaaakaabaaaabaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
akaabaaaabaaaaaadiaaaaajpcaabaaaacaaaaaaegiocaaaaaaaaaaaabaaaaaa
egiocaaaaaaaaaaaacaaaaaadiaaaaahlcaabaaaabaaaaaapgapbaaaaaaaaaaa
egaibaaaacaaaaaadiaaaaahiccabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaa
acaaaaaadiaaaaaihcaabaaaacaaaaaaegacbaaaaaaaaaaaegiccaaaaaaaaaaa
abaaaaaadcaaaaajhcaabaaaabaaaaaaegacbaaaacaaaaaakgakbaaaabaaaaaa
egadbaaaabaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaaaaaaaaaegbcbaaaadaaaaaa
egacbaaaabaaaaaadoaaaaabejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_4_0
eefieceddgfnocdjegcbpdmlbpiolgknbbdoociaabaaaaaabaabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaa
gfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_4_0_level_9_1
eefiecedlbigijnfbephlnnlnoleedpikilngjapabaaaaaahiabaaaaaeaaaaaa
daaaaaaajeaaaaaaneaaaaaaeeabaaaaebgpgodjfmaaaaaafmaaaaaaaaacpppp
diaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaacaaaacpia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdiaaaaaaeaaaaaaa
aoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaabejfdeheogiaaaaaaadaaaaaa
aiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaafmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_4_0
eefiecedolfjbkkehkkmcfkgkagkcpcmlmdgknfbabaaaaaaciabaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adaaaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_4_0_level_9_1
eefiecededknilamobiiblknpmmalaimegaaofioabaaaaaajaabaaaaaeaaaaaa
daaaaaaajeaaaaaaneaaaaaafmabaaaaebgpgodjfmaaaaaafmaaaaaaaaacpppp
diaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaacaaaacpia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdiaaaaaaeaaaaaaa
aoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaabejfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadaaaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ClothColor]
Float 6 [_Shininess]
Float 7 [_MetalShininess]
Float 8 [_SkinShininess]
Float 9 [_ClothShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..9],
		{ 0.5, 0.029999999, 2, 1 },
		{ 0, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R3.yzw, fragment.texcoord[0], texture[1], 2D;
TXP R3.x, fragment.texcoord[4], texture[3], 2D;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R5.yw, fragment.texcoord[0].zwzw, texture[2], 2D;
MOV R1, c[2];
MOV R2.x, c[6];
ADD R1, -R1, c[5];
SGE R4.xyz, R3.yzww, c[10].x;
ADD R2.x, -R2, c[9];
MAD R4.z, R4, R2.x, c[6].x;
MAD R1, R3.w, R1, c[2];
ADD R2, -R1, c[4];
MAD R1, R3.z, R2, R1;
ADD R2, -R1, c[3];
MAD R1, R3.y, R2, R1;
MUL R0, R0, R1;
ADD R3.w, -R4.z, c[8].x;
MAD R3.w, R4.y, R3, R4.z;
ADD R3.z, -R3.w, c[7].x;
MAD R3.z, R4.x, R3, R3.w;
MUL R2.x, R3.z, R3.z;
ADD R1.w, R2.x, c[10].y;
MAD R2.xy, R5.wyzw, c[10].z, -c[10].w;
MUL R2.zw, R2.xyxy, R2.xyxy;
ADD_SAT R2.z, R2, R2.w;
DP3 R3.y, fragment.texcoord[3], fragment.texcoord[3];
ADD R2.z, -R2, c[10].w;
RSQ R2.z, R2.z;
RCP R2.z, R2.z;
MUL R0.w, R0, R1;
MOV R1.xyz, fragment.texcoord[1];
RSQ R3.y, R3.y;
MAD R1.xyz, R3.y, fragment.texcoord[3], R1;
DP3 R2.w, R1, R1;
RSQ R2.w, R2.w;
MUL R1.xyz, R2.w, R1;
DP3 R1.x, R2, R1;
MUL R1.y, R3.z, c[11];
MAX R1.x, R1, c[11];
POW R1.x, R1.x, R1.y;
MUL R0.w, R0, R1.x;
DP3 R1.x, R2, fragment.texcoord[1];
MAX R2.w, R1.x, c[11].x;
MOV R1, c[1];
MUL R2.xyz, R0, c[0];
MUL R0.w, R0, c[10].z;
MUL R2.xyz, R2, R2.w;
MUL R1.xyz, R1, c[0];
MAD R1.xyz, R1, R0.w, R2;
MUL R2.x, R3, c[10].z;
MUL R1.w, R1, c[0];
MUL R1.xyz, R1, R2.x;
MUL R0.w, R0, R1;
MAD result.color.xyz, R0, fragment.texcoord[2], R1;
MUL result.color.w, R3.x, R0;
END
# 55 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Vector 3 [_MetalColor]
Vector 4 [_SkinColor]
Vector 5 [_ClothColor]
Float 6 [_Shininess]
Float 7 [_MetalShininess]
Float 8 [_SkinShininess]
Float 9 [_ClothShininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_MaskTex] 2D 1
SetTexture 2 [_BumpMap] 2D 2
SetTexture 3 [_ShadowMapTexture] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c10, -0.50000000, 1.00000000, 0.00000000, 0.03000000
def c11, 2.00000000, -1.00000000, 128.00000000, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
dcl t4
texld r3, t0, s1
texld r2, t0, s0
texldp r1, t4, s3
add r1.yzw, r3, c10.x
cmp r1.yzw, r1, c10.y, c10.z
mov_pp r4, c5
add_pp r4, -c2, r4
mad_pp r4, r3.w, r4, c2
add_pp r5, -r4, c4
mad_pp r4, r3.z, r5, r4
add_pp r5, -r4, c3
mad_pp r3, r3.y, r5, r4
mul r2, r2, r3
mov_pp r5.xyz, t1
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s2
mov_pp r0.x, c9
add_pp r0.x, -c6, r0
mad_pp r0.x, r1.w, r0, c6
add_pp r4.x, -r0, c8
mad_pp r0.x, r1.z, r4, r0
add_pp r3.x, -r0, c7
mov r4.x, r0.w
mov r4.y, r0
mad_pp r6.xy, r4, c11.x, c11.y
mad_pp r0.x, r1.y, r3, r0
mul_pp r3.xy, r6, r6
add_pp_sat r3.x, r3, r3.y
dp3_pp r4.x, t3, t3
rsq_pp r4.x, r4.x
mad_pp r4.xyz, r4.x, t3, r5
dp3_pp r5.x, r4, r4
rsq_pp r5.x, r5.x
add_pp r3.x, -r3, c10.y
rsq_pp r3.x, r3.x
mul_pp r4.xyz, r5.x, r4
rcp_pp r6.z, r3.x
dp3_pp r3.x, r6, r4
mul_pp r4.x, r0, c11.z
max_pp r3.x, r3, c10.z
pow r5.w, r3.x, r4.x
mov r3.x, r5.w
mul_pp r0.x, r0, r0
add r0.x, r0, c10.w
mul r0.x, r2.w, r0
mul r0.x, r0, r3
dp3_pp r3.x, r6, t1
mul r0.x, r0, c11
mul_pp r4.xyz, r2, c0
max_pp r3.x, r3, c10.z
mov_pp r5.xyz, c0
mul_pp r3.xyz, r4, r3.x
mul_pp r4.xyz, c1, r5
mad r3.xyz, r4, r0.x, r3
mov_pp r0.w, c0
mul_pp r4.x, c1.w, r0.w
mul r0.x, r0, r4
mul_pp r5.x, r1, c11
mul r0.w, r1.x, r0.x
mul r3.xyz, r3, r5.x
mad_pp r0.xyz, r2, t2, r3
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_MaskTex] 2D 2
SetTexture 2 [_BumpMap] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 304
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Vector 208 [_MetalColor]
Vector 224 [_SkinColor]
Vector 240 [_ClothColor]
Float 256 [_Shininess]
Float 260 [_MetalShininess]
Float 264 [_SkinShininess]
Float 268 [_ClothShininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedpcckocoocpeeakhoojdpfbjbmeemppbkabaaaaaadeaiaaaaadaaaaaa
cmaaaaaaoeaaaaaabiabaaaaejfdeheolaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaakeaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaakeaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaakeaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapalaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbeahaaaa
eaaaaaaamfabaaaafjaaaaaeegiocaaaaaaaaaaabbaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaad
aagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaa
abaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaa
adaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaadlcbabaaa
afaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaakpcaabaaa
aaaaaaaaegiocaiaebaaaaaaaaaaaaaaalaaaaaaegiocaaaaaaaaaaaapaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
acaaaaaadcaaaaakpcaabaaaaaaaaaaapgapbaaaabaaaaaaegaobaaaaaaaaaaa
egiocaaaaaaaaaaaalaaaaaaaaaaaaajpcaabaaaacaaaaaaegaobaiaebaaaaaa
aaaaaaaaegiocaaaaaaaaaaaaoaaaaaadcaaaaajpcaabaaaaaaaaaaakgakbaaa
abaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaajpcaabaaaacaaaaaa
egaobaiaebaaaaaaaaaaaaaaegiocaaaaaaaaaaaanaaaaaadcaaaaajpcaabaaa
aaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaabnaaaaak
hcaabaaaabaaaaaajgahbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaabaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaaegaobaaaacaaaaaaaaaaaaakicaabaaaabaaaaaaakiacaiaebaaaaaa
aaaaaaaabaaaaaaadkiacaaaaaaaaaaabaaaaaaadcaaaaakecaabaaaabaaaaaa
ckaabaaaabaaaaaadkaabaaaabaaaaaaakiacaaaaaaaaaaabaaaaaaaaaaaaaaj
icaabaaaabaaaaaackaabaiaebaaaaaaabaaaaaackiacaaaaaaaaaaabaaaaaaa
dcaaaaajccaabaaaabaaaaaabkaabaaaabaaaaaadkaabaaaabaaaaaackaabaaa
abaaaaaaaaaaaaajecaabaaaabaaaaaabkaabaiaebaaaaaaabaaaaaabkiacaaa
aaaaaaaabaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaaabaaaaaackaabaaa
abaaaaaabkaabaaaabaaaaaadcaaaaajccaabaaaabaaaaaaakaabaaaabaaaaaa
akaabaaaabaaaaaaabeaaaaaipmcpfdmdiaaaaahbcaabaaaabaaaaaaakaabaaa
abaaaaaaabeaaaaaaaaaaaedapaaaaahicaabaaaaaaaaaaafgafbaaaabaaaaaa
pgapbaaaaaaaaaaabaaaaaahccaabaaaabaaaaaaegbcbaaaaeaaaaaaegbcbaaa
aeaaaaaaeeaaaaafccaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaajocaabaaa
abaaaaaaagbjbaaaaeaaaaaafgafbaaaabaaaaaaagbjbaaaacaaaaaabaaaaaah
bcaabaaaacaaaaaajgahbaaaabaaaaaajgahbaaaabaaaaaaeeaaaaafbcaabaaa
acaaaaaaakaabaaaacaaaaaadiaaaaahocaabaaaabaaaaaafgaobaaaabaaaaaa
agaabaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaa
acaaaaaaaagabaaaadaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaa
aceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialp
aaaaaaaaaaaaaaaaapaaaaahicaabaaaacaaaaaaegaabaaaacaaaaaaegaabaaa
acaaaaaaddaaaaahicaabaaaacaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaiadp
aaaaaaaiicaabaaaacaaaaaadkaabaiaebaaaaaaacaaaaaaabeaaaaaaaaaiadp
elaaaaafecaabaaaacaaaaaadkaabaaaacaaaaaabaaaaaahccaabaaaabaaaaaa
egacbaaaacaaaaaajgahbaaaabaaaaaabaaaaaahecaabaaaabaaaaaaegacbaaa
acaaaaaaegbcbaaaacaaaaaadeaaaaakgcaabaaaabaaaaaafgagbaaaabaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacpaaaaafccaabaaaabaaaaaa
bkaabaaaabaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaabaaaaaaakaabaaa
abaaaaaabjaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaajpcaabaaaacaaaaaa
egiocaaaaaaaaaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaadiaaaaahpcaabaaa
acaaaaaapgapbaaaaaaaaaaaegaobaaaacaaaaaadiaaaaailcaabaaaabaaaaaa
egaibaaaaaaaaaaaegiicaaaaaaaaaaaabaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegbcbaaaadaaaaaadcaaaaajhcaabaaaabaaaaaaegadbaaa
abaaaaaakgakbaaaabaaaaaaegacbaaaacaaaaaaaoaaaaahdcaabaaaacaaaaaa
egbabaaaafaaaaaapgbpbaaaafaaaaaaefaaaaajpcaabaaaadaaaaaaegaabaaa
acaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaa
akaabaaaadaaaaaaakaabaaaadaaaaaadiaaaaahiccabaaaaaaaaaaadkaabaaa
acaaaaaaakaabaaaadaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaaabaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_MaskTex] 2D 2
SetTexture 2 [_BumpMap] 2D 3
SetTexture 3 [_ShadowMapTexture] 2D 0
ConstBuffer "$Globals" 304
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Vector 208 [_MetalColor]
Vector 224 [_SkinColor]
Vector 240 [_ClothColor]
Float 256 [_Shininess]
Float 260 [_MetalShininess]
Float 264 [_SkinShininess]
Float 268 [_ClothShininess]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedldjbpamgjkgdglkpcacmbmhjfneghondabaaaaaaieamaaaaaeaaaaaa
daaaaaaahmaeaaaajialaaaafaamaaaaebgpgodjeeaeaaaaeeaeaaaaaaacpppp
omadaaaafiaaaaaaadaadeaaaaaafiaaaaaafiaaaeaaceaaaaaafiaaadaaaaaa
aaababaaabacacaaacadadaaaaaaabaaacaaaaaaaaaaaaaaaaaaalaaabaaacaa
aaaaaaaaaaaaanaaaeaaadaaaaaaaaaaaaacppppfbaaaaafahaaapkaaaaaaalp
ipmcpfdmaaaaaaeaaaaaialpfbaaaaafaiaaapkaaaaaaaaaaaaaaaedaaaaaaaa
aaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaacaaaaaaiaabaachlabpaaaaac
aaaaaaiaacaachlabpaaaaacaaaaaaiaadaachlabpaaaaacaaaaaaiaaeaaapla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaacaaaaaaja
acaiapkabpaaaaacaaaaaajaadaiapkaabaaaaacaaaaabiaaaaakklaabaaaaac
aaaaaciaaaaapplaagaaaaacaaaaaeiaaeaapplaafaaaaadabaaadiaaaaakkia
aeaaoelaecaaaaadacaaapiaaaaaoelaacaioekaecaaaaadadaaapiaaaaaoela
abaioekaecaaaaadaaaacpiaaaaaoeiaadaioekaecaaaaadabaacpiaabaaoeia
aaaioekaabaaaaacaeaaapiaacaaoekaacaaaaadaeaaapiaaeaaoeibafaaoeka
aeaaaaaeaeaaapiaacaappiaaeaaoeiaacaaoekabcaaaaaeafaaapiaacaakkia
aeaaoekaaeaaoeiabcaaaaaeaeaaapiaacaaffiaadaaoekaafaaoeiaacaaaaad
acaaadiaacaamjiaahaaaakaacaaaaadacaaaeiaacaappiaahaaaakaafaaaaad
adaaapiaadaaoeiaaeaaoeiafiaaaaaeaaaacbiaacaakkiaagaappkaagaaaaka
fiaaaaaeaaaacbiaacaaffiaagaakkkaaaaaaaiafiaaaaaeaaaacbiaacaaaaia
agaaffkaaaaaaaiaaeaaaaaeaaaaaeiaaaaaaaiaaaaaaaiaahaaffkaafaaaaad
aaaaabiaaaaaaaiaaiaaffkaafaaaaadadaaaiiaadaappiaaaaakkiaacaaaaad
adaaciiaadaappiaadaappiaaiaaaaadaaaaceiaadaaoelaadaaoelaahaaaaac
aaaaceiaaaaakkiaabaaaaacacaaahiaadaaoelaaeaaaaaeacaachiaacaaoeia
aaaakkiaabaaoelaceaaaaacaeaachiaacaaoeiaaeaaaaaeacaacbiaaaaappia
ahaakkkaahaappkaaeaaaaaeacaacciaaaaaffiaahaakkkaahaappkafkaaaaae
acaadiiaacaaoeiaacaaoeiaaiaaaakaacaaaaadacaaciiaacaappibahaappkb
ahaaaaacacaaciiaacaappiaagaaaaacacaaceiaacaappiaaiaaaaadacaaciia
acaaoeiaaeaaoeiaaiaaaaadaaaacciaacaaoeiaabaaoelaalaaaaadabaaccia
aaaaffiaaiaaaakaalaaaaadaaaaaciaacaappiaaiaaaakacaaaaaadabaaaeia
aaaaffiaaaaaaaiaafaaaaadadaaaiiaadaappiaabaakkiaabaaaaacaaaaapia
aaaaoekaafaaaaadaaaaahiaaaaaoeiaabaaoekaafaaaaadaaaaahiaadaappia
aaaaoeiaafaaaaadacaachiaadaaoeiaaaaaoekaafaaaaadadaachiaadaaoeia
acaaoelaaeaaaaaeaaaaahiaacaaoeiaabaaffiaaaaaoeiaacaaaaadabaaacia
abaaaaiaabaaaaiaaeaaaaaeacaachiaaaaaoeiaabaaffiaadaaoeiaafaaaaad
aaaaabiaaaaappiaabaappkaafaaaaadaaaaabiaadaappiaaaaaaaiaafaaaaad
acaaciiaabaaaaiaaaaaaaiaabaaaaacaaaicpiaacaaoeiappppaaaafdeieefc
beahaaaaeaaaaaaamfabaaaafjaaaaaeegiocaaaaaaaaaaabbaaaaaafkaaaaad
aagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaa
fkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaae
aahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadhcbabaaa
acaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagcbaaaad
lcbabaaaafaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaaaaaaaak
pcaabaaaaaaaaaaaegiocaiaebaaaaaaaaaaaaaaalaaaaaaegiocaaaaaaaaaaa
apaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadcaaaaakpcaabaaaaaaaaaaapgapbaaaabaaaaaaegaobaaa
aaaaaaaaegiocaaaaaaaaaaaalaaaaaaaaaaaaajpcaabaaaacaaaaaaegaobaia
ebaaaaaaaaaaaaaaegiocaaaaaaaaaaaaoaaaaaadcaaaaajpcaabaaaaaaaaaaa
kgakbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaaaaaaaaajpcaabaaa
acaaaaaaegaobaiaebaaaaaaaaaaaaaaegiocaaaaaaaaaaaanaaaaaadcaaaaaj
pcaabaaaaaaaaaaafgafbaaaabaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaa
bnaaaaakhcaabaaaabaaaaaajgahbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadp
aaaaaadpaaaaaaaaabaaaaakhcaabaaaabaaaaaaegacbaaaabaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaahpcaabaaaaaaaaaaa
egaobaaaaaaaaaaaegaobaaaacaaaaaaaaaaaaakicaabaaaabaaaaaaakiacaia
ebaaaaaaaaaaaaaabaaaaaaadkiacaaaaaaaaaaabaaaaaaadcaaaaakecaabaaa
abaaaaaackaabaaaabaaaaaadkaabaaaabaaaaaaakiacaaaaaaaaaaabaaaaaaa
aaaaaaajicaabaaaabaaaaaackaabaiaebaaaaaaabaaaaaackiacaaaaaaaaaaa
baaaaaaadcaaaaajccaabaaaabaaaaaabkaabaaaabaaaaaadkaabaaaabaaaaaa
ckaabaaaabaaaaaaaaaaaaajecaabaaaabaaaaaabkaabaiaebaaaaaaabaaaaaa
bkiacaaaaaaaaaaabaaaaaaadcaaaaajbcaabaaaabaaaaaaakaabaaaabaaaaaa
ckaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaajccaabaaaabaaaaaaakaabaaa
abaaaaaaakaabaaaabaaaaaaabeaaaaaipmcpfdmdiaaaaahbcaabaaaabaaaaaa
akaabaaaabaaaaaaabeaaaaaaaaaaaedapaaaaahicaabaaaaaaaaaaafgafbaaa
abaaaaaapgapbaaaaaaaaaaabaaaaaahccaabaaaabaaaaaaegbcbaaaaeaaaaaa
egbcbaaaaeaaaaaaeeaaaaafccaabaaaabaaaaaabkaabaaaabaaaaaadcaaaaaj
ocaabaaaabaaaaaaagbjbaaaaeaaaaaafgafbaaaabaaaaaaagbjbaaaacaaaaaa
baaaaaahbcaabaaaacaaaaaajgahbaaaabaaaaaajgahbaaaabaaaaaaeeaaaaaf
bcaabaaaacaaaaaaakaabaaaacaaaaaadiaaaaahocaabaaaabaaaaaafgaobaaa
abaaaaaaagaabaaaacaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaadaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaa
acaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaacaaaaaaegaabaaaacaaaaaa
egaabaaaacaaaaaaddaaaaahicaabaaaacaaaaaadkaabaaaacaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaacaaaaaadkaabaiaebaaaaaaacaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaacaaaaaadkaabaaaacaaaaaabaaaaaahccaabaaa
abaaaaaaegacbaaaacaaaaaajgahbaaaabaaaaaabaaaaaahecaabaaaabaaaaaa
egacbaaaacaaaaaaegbcbaaaacaaaaaadeaaaaakgcaabaaaabaaaaaafgagbaaa
abaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacpaaaaafccaabaaa
abaaaaaabkaabaaaabaaaaaadiaaaaahbcaabaaaabaaaaaabkaabaaaabaaaaaa
akaabaaaabaaaaaabjaaaaafbcaabaaaabaaaaaaakaabaaaabaaaaaadiaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaaabaaaaaadiaaaaajpcaabaaa
acaaaaaaegiocaaaaaaaaaaaabaaaaaaegiocaaaaaaaaaaaacaaaaaadiaaaaah
pcaabaaaacaaaaaapgapbaaaaaaaaaaaegaobaaaacaaaaaadiaaaaailcaabaaa
abaaaaaaegaibaaaaaaaaaaaegiicaaaaaaaaaaaabaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaaegbcbaaaadaaaaaadcaaaaajhcaabaaaabaaaaaa
egadbaaaabaaaaaakgakbaaaabaaaaaaegacbaaaacaaaaaaaoaaaaahdcaabaaa
acaaaaaaegbabaaaafaaaaaapgbpbaaaafaaaaaaefaaaaajpcaabaaaadaaaaaa
egaabaaaacaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaaaaaaaaahicaabaaa
aaaaaaaaakaabaaaadaaaaaaakaabaaaadaaaaaadiaaaaahiccabaaaaaaaaaaa
dkaabaaaacaaaaaaakaabaaaadaaaaaadcaaaaajhccabaaaaaaaaaaaegacbaaa
abaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaabejfdeheolaaaaaaa
agaaaaaaaiaaaaaajiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
keaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaakeaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaakeaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahahaaaakeaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaa
keaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapalaaaafdfgfpfaepfdejfe
ejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_4_0
eefiecedefgnnaabljgofggbcamdcaipdjlehepcabaaaaaaciabaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adaaaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaa
aaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
"ps_4_0_level_9_1
eefiecedjjlhmbhdgldppdileepkihnmjhcphhbbabaaaaaajaabaaaaaeaaaaaa
daaaaaaajeaaaaaaneaaaaaafmabaaaaebgpgodjfmaaaaaafmaaaaaaaaacpppp
diaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaacaaaacpia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdiaaaaaaeaaaaaaa
aoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaabejfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadaaaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[1] = { { 0 } };
MOV result.color, c[0].x;
END
# 1 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_2_0
def c0, 0.00000000, 0, 0, 0
mov_pp r0, c0.x
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_4_0
eefiecedakimhkhedhpalnaclknnjgngkimipcbfabaaaaaaeaabaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
adaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaaaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcdiaaaaaaeaaaaaaaaoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaai
pccabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
"ps_4_0_level_9_1
eefiecedmjmdbhpmleendknpalfbkijohnddjcijabaaaaaakiabaaaaaeaaaaaa
daaaaaaajeaaaaaaneaaaaaaheabaaaaebgpgodjfmaaaaaafmaaaaaaaaacpppp
diaaaaaaceaaaaaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaaaceaaaaacpppp
fbaaaaafaaaaapkaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaacaaaacpia
aaaaaakaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdiaaaaaaeaaaaaaa
aoaaaaaagfaaaaadpccabaaaaaaaaaaadgaaaaaipccabaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaabejfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaadaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaaaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
}
 }
 Pass {
  Name "FORWARD"
  Tags { "LIGHTMODE"="ForwardAdd" "RenderType"="Opaque" }
  ZWrite Off
  Fog {
   Color (0,0,0,0)
  }
  Blend One One
Program "vp" {
SubProgram "opengl " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Matrix 17 [_ProjMat]
Vector 21 [_WorldSpaceCameraPos]
Vector 22 [_WorldSpaceLightPos0]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[26] = { { 1 },
		state.matrix.modelview[0],
		program.local[5..25] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1, c[22];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R6.xyz, R2, c[23].w, -vertex.position;
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.w, c[0].x;
MOV R1.xyz, c[21];
MOV R3, c[2];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R7.xyz, R2, c[23].w, -vertex.position;
MOV R2, c[1];
MUL R1, R3, c[19].y;
MAD R4, R2, c[19].x, R1;
MOV R1, c[3];
MAD R5, R1, c[19].z, R4;
DP3 result.texcoord[1].y, R6, R0;
DP3 result.texcoord[2].y, R0, R7;
MUL R0, R3, c[20].y;
MAD R0, R2, c[20].x, R0;
MAD R4, R1, c[20].z, R0;
MOV R0, c[4];
MAD R4, R0, c[20].w, R4;
MAD R5, R0, c[19].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[18].y;
MUL R3, R3, c[17].y;
MAD R4, R2, c[18].x, R4;
MAD R2, R2, c[17].x, R3;
MAD R3, R1, c[18].z, R4;
MAD R1, R1, c[17].z, R2;
MAD R2, R0, c[18].w, R3;
MAD R0, R0, c[17].w, R1;
DP4 result.position.x, vertex.position, R0;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP3 result.texcoord[1].z, vertex.normal, R6;
DP3 result.texcoord[1].x, R6, vertex.attrib[14];
DP3 result.texcoord[2].z, vertex.normal, R7;
DP3 result.texcoord[2].x, vertex.attrib[14], R7;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 54 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Matrix 16 [_ProjMat]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_BumpMap_ST]
"vs_2_0
def c25, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c25.x
mov r0.xyz, c20
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c22.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c21, r0
mov r0, c9
mov r1, c8
dp4 r4.y, c21, r0
dp4 r4.x, c21, r1
mad r0.xyz, r4, c22.w, -v0
dp3 oT1.y, r0, r2
dp3 oT2.y, r2, r3
dp3 oT1.z, v2, r0
dp3 oT1.x, r0, v1
mov r0.x, c19.y
mul r1, c1, r0.x
mov r0.x, c19
mad r1, c0, r0.x, r1
mov r0.x, c19.z
mad r1, c2, r0.x, r1
mov r0.x, c19.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c18.y
mov r0.x, c18
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c18.z
mad r1, c2, r0.x, r1
mov r0.x, c18.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c17.y
mov r0.x, c17
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c17.z
mad r1, c2, r0.x, r1
mov r0.x, c17.w
mad r0, c3, r0.x, r1
dp4 oPos.y, v0, r0
mov r2.x, c16.y
mul r1, c1, r2.x
mov r2.x, c16
mad r1, c0, r2.x, r1
mov r2.x, c16.z
mad r1, c2, r2.x, r1
mov r2.x, c16.w
mad r1, c3, r2.x, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oPos.x, v0, r1
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c24.xyxy, c24
mad oT0.xy, v3, c23, c23.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedalnboepjagbnhijhgopooeicakinmmfhabaaaaaaleajaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbiaiaaaaeaaaabaa
agacaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
anaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaah
hcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaaj
hcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaa
egacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaa
abaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaa
adaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
aaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaabdaaaaaa
dcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaabeaaaaaa
egbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaa
abaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaanaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaaaaaaaaaagaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedfgnbdfkolgbdlhfefnifokjfkoiphnpmabaaaaaagiaoaaaaaeaaaaaa
daaaaaaaoaaeaaaaaaanaaaamianaaaaebgpgodjkiaeaaaakiaeaaaaaaacpopp
diaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aiaaabaaaaaaaaaaaaaaanaaacaaajaaaaaaaaaaabaaaeaaabaaalaaaaaaaaaa
acaaaaaaabaaamaaaaaaaaaaadaaaeaaaeaaanaaaaaaaaaaadaaamaaajaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabia
abaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaajaaoekaajaaookaaeaaaaaeaaaaamoaadaaeejaakaaeeka
akaaoekaabaaaaacaaaaapiaamaaoekaafaaaaadabaaahiaaaaaffiabgaaoeka
aeaaaaaeabaaahiabfaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiabhaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaahiabiaaoekaaaaappiaaaaaoeiaaeaaaaae
aaaaahiaaaaaoeiabjaappkaaaaaoejbaiaaaaadabaaaboaabaaoejaaaaaoeia
abaaaaacabaaahiaabaaoejaafaaaaadacaaahiaabaamjiaacaancjaaeaaaaae
abaaahiaacaamjjaabaanciaacaaoeibafaaaaadabaaahiaabaaoeiaabaappja
aiaaaaadabaaacoaabaaoeiaaaaaoeiaaiaaaaadabaaaeoaacaaoejaaaaaoeia
abaaaaacaaaaahiaalaaoekaafaaaaadacaaahiaaaaaffiabgaaoekaaeaaaaae
aaaaaliabfaakekaaaaaaaiaacaakeiaaeaaaaaeaaaaahiabhaaoekaaaaakkia
aaaapeiaacaaaaadaaaaahiaaaaaoeiabiaaoekaaeaaaaaeaaaaahiaaaaaoeia
bjaappkaaaaaoejbaiaaaaadacaaaboaabaaoejaaaaaoeiaaiaaaaadacaaacoa
abaaoeiaaaaaoeiaaiaaaaadacaaaeoaacaaoejaaaaaoeiaafaaaaadaaaaapia
aaaaffjabcaaoekaaeaaaaaeaaaaapiabbaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiabdaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabeaaoekaaaaappja
aaaaoeiaafaaaaadabaaahiaaaaaffiaacaaoekaaeaaaaaeabaaahiaabaaoeka
aaaaaaiaabaaoeiaaeaaaaaeaaaaahiaadaaoekaaaaakkiaabaaoeiaaeaaaaae
adaaahoaaeaaoekaaaaappiaaaaaoeiaabaaaaacaaaaapiaagaaoekaafaaaaad
abaaapiaaaaaoeiaaoaaffkaabaaaaacacaaapiaafaaoekaaeaaaaaeabaaapia
acaaoeiaaoaaaakaabaaoeiaabaaaaacadaaapiaahaaoekaaeaaaaaeabaaapia
adaaoeiaaoaakkkaabaaoeiaabaaaaacaeaaapiaaiaaoekaaeaaaaaeabaaapia
aeaaoeiaaoaappkaabaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaad
afaaapiaaaaaoeiaanaaffkaaeaaaaaeafaaapiaacaaoeiaanaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaanaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
anaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaad
afaaapiaaaaaoeiaapaaffkaaeaaaaaeafaaapiaacaaoeiaapaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaapaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
apaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaad
aaaaapiaaaaaoeiabaaaffkaaeaaaaaeaaaaapiaacaaoeiabaaaaakaaaaaoeia
aeaaaaaeaaaaapiaadaaoeiabaaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeia
baaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaa
fdeieefcbiaiaaaaeaaaabaaagacaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
pcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
giaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaa
fgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ahaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
adaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaa
aaaaaaaaaoaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgbpbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaa
acaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaah
cccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaa
acaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaa
egbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaa
adaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaa
aeaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaa
afaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_World2Object]
Matrix 9 [_ProjMat]
Vector 13 [_WorldSpaceCameraPos]
Vector 14 [_WorldSpaceLightPos0]
Vector 15 [unity_Scale]
Vector 16 [_MainTex_ST]
Vector 17 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[18] = { { 1 },
		state.matrix.modelview[0],
		program.local[5..17] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1, c[14];
DP4 R6.z, R1, c[7];
DP4 R6.y, R1, c[6];
DP4 R6.x, R1, c[5];
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.w, c[0].x;
MOV R1.xyz, c[13];
MOV R3, c[2];
DP4 R2.z, R1, c[7];
DP4 R2.x, R1, c[5];
DP4 R2.y, R1, c[6];
MAD R7.xyz, R2, c[15].w, -vertex.position;
MOV R2, c[1];
MUL R1, R3, c[11].y;
MAD R4, R2, c[11].x, R1;
MOV R1, c[3];
MAD R5, R1, c[11].z, R4;
DP3 result.texcoord[1].y, R6, R0;
DP3 result.texcoord[2].y, R0, R7;
MUL R0, R3, c[12].y;
MAD R0, R2, c[12].x, R0;
MAD R4, R1, c[12].z, R0;
MOV R0, c[4];
MAD R4, R0, c[12].w, R4;
MAD R5, R0, c[11].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[10].y;
MUL R3, R3, c[9].y;
MAD R4, R2, c[10].x, R4;
MAD R2, R2, c[9].x, R3;
MAD R3, R1, c[10].z, R4;
MAD R1, R1, c[9].z, R2;
MAD R2, R0, c[10].w, R3;
MAD R0, R0, c[9].w, R1;
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP4 result.position.x, vertex.position, R0;
DP3 result.texcoord[1].z, vertex.normal, R6;
DP3 result.texcoord[1].x, R6, vertex.attrib[14];
DP3 result.texcoord[2].z, vertex.normal, R7;
DP3 result.texcoord[2].x, vertex.attrib[14], R7;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[17].xyxy, c[17];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[16], c[16].zwzw;
END
# 46 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_World2Object]
Matrix 8 [_ProjMat]
Vector 12 [_WorldSpaceCameraPos]
Vector 13 [_WorldSpaceLightPos0]
Vector 14 [unity_Scale]
Vector 15 [_MainTex_ST]
Vector 16 [_BumpMap_ST]
"vs_2_0
def c17, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c17.x
mov r0.xyz, c12
dp4 r1.z, r0, c6
dp4 r1.y, r0, c5
dp4 r1.x, r0, c4
mad r3.xyz, r1, c14.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c6
dp4 r4.z, c13, r0
mov r0, c5
dp4 r4.y, c13, r0
mov r1, c4
dp4 r4.x, c13, r1
mov r0.x, c11.y
mul r1, c1, r0.x
mov r0.x, c11
mad r1, c0, r0.x, r1
mov r0.x, c11.z
mad r1, c2, r0.x, r1
mov r0.x, c11.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c10.y
mov r0.x, c10
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c10.z
mad r1, c2, r0.x, r1
mov r0.x, c10.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c9.y
mov r0.x, c9
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c9.z
mad r1, c2, r0.x, r1
mov r0.x, c9.w
mad r0, c3, r0.x, r1
dp3 oT1.y, r4, r2
dp3 oT2.y, r2, r3
mov r2.x, c8.y
mul r1, c1, r2.x
mov r2.x, c8
mad r1, c0, r2.x, r1
mov r2.x, c8.z
mad r1, c2, r2.x, r1
mov r2.x, c8.w
mad r1, c3, r2.x, r1
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oPos.y, v0, r0
dp4 oPos.x, v0, r1
mad oT0.zw, v3.xyxy, c16.xyxy, c16
mad oT0.xy, v3, c15, c15.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 176
Matrix 48 [_ProjMat]
Vector 144 [_MainTex_ST]
Vector 160 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedofenbhgfhdiecbhgbmedmkopdnfalmooabaaaaaadeaiaaaaadaaaaaa
cmaaaaaapeaaaaaahmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
laagaaaaeaaaabaakmabaaaafjaaaaaeegiocaaaaaaaaaaaalaaaaaafjaaaaae
egiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaae
egiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaa
abaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaa
acaaaaaagfaaaaadhccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaal
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaafaaaaaa
egaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaa
diaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaaj
pcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaaeaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaa
aeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
afaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
adaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaaj
pccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaa
ogikcaaaaaaaaaaaajaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaakaaaaaakgiocaaaaaaaaaaaakaaaaaadiaaaaahhcaabaaa
aaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaa
jgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaa
abaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaal
hcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaa
kgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahcccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
bccabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaa
acaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaa
fgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaa
abaaaaaaaeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaah
cccabaaaadaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaa
adaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaadaaaaaa
egbcbaaaacaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 176
Matrix 48 [_ProjMat]
Vector 144 [_MainTex_ST]
Vector 160 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedodpmooonhgamlganomddhpdhmakcgfdkabaaaaaadmamaaaaaeaaaaaa
daaaaaaadeaeaaaaomakaaaalealaaaaebgpgodjpmadaaaapmadaaaaaaacpopp
imadaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aeaaabaaaaaaaaaaaaaaajaaacaaafaaaaaaaaaaabaaaeaaabaaahaaaaaaaaaa
acaaaaaaabaaaiaaaaaaaaaaadaaaeaaaeaaajaaaaaaaaaaadaabaaaafaaanaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabia
abaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaafaaoekaafaaookaaeaaaaaeaaaaamoaadaaeejaagaaeeka
agaaoekaabaaaaacaaaaapiaaiaaoekaafaaaaadabaaahiaaaaaffiaaoaaoeka
aeaaaaaeabaaahiaanaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiaapaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaahiabaaaoekaaaaappiaaaaaoeiaaiaaaaad
abaaaboaabaaoejaaaaaoeiaabaaaaacabaaahiaabaaoejaafaaaaadacaaahia
abaamjiaacaancjaaeaaaaaeabaaahiaacaamjjaabaanciaacaaoeibafaaaaad
abaaahiaabaaoeiaabaappjaaiaaaaadabaaacoaabaaoeiaaaaaoeiaaiaaaaad
abaaaeoaacaaoejaaaaaoeiaabaaaaacaaaaahiaahaaoekaafaaaaadacaaahia
aaaaffiaaoaaoekaaeaaaaaeaaaaaliaanaakekaaaaaaaiaacaakeiaaeaaaaae
aaaaahiaapaaoekaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeiabaaaoeka
aeaaaaaeaaaaahiaaaaaoeiabbaappkaaaaaoejbaiaaaaadacaaaboaabaaoeja
aaaaoeiaaiaaaaadacaaacoaabaaoeiaaaaaoeiaaiaaaaadacaaaeoaacaaoeja
aaaaoeiaabaaaaacaaaaapiaacaaoekaafaaaaadabaaapiaaaaaoeiaakaaffka
abaaaaacacaaapiaabaaoekaaeaaaaaeabaaapiaacaaoeiaakaaaakaabaaoeia
abaaaaacadaaapiaadaaoekaaeaaaaaeabaaapiaadaaoeiaakaakkkaabaaoeia
abaaaaacaeaaapiaaeaaoekaaeaaaaaeabaaapiaaeaaoeiaakaappkaabaaoeia
afaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaadafaaapiaaaaaoeiaajaaffka
aeaaaaaeafaaapiaacaaoeiaajaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeia
ajaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaajaappkaafaaoeiaaeaaaaae
abaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaadafaaapiaaaaaoeiaalaaffka
aeaaaaaeafaaapiaacaaoeiaalaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeia
alaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeiaalaappkaafaaoeiaaeaaaaae
abaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaadaaaaapiaaaaaoeiaamaaffka
aeaaaaaeaaaaapiaacaaoeiaamaaaakaaaaaoeiaaeaaaaaeaaaaapiaadaaoeia
amaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeiaamaappkaaaaaoeiaaeaaaaae
aaaaapiaaaaaoeiaaaaappjaabaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefclaagaaaaeaaaabaa
kmabaaaafjaaaaaeegiocaaaaaaaaaaaalaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
agaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaa
aaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaa
agaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
adaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaaaaaaaaaa
egaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaa
abaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaajaaaaaaogikcaaaaaaaaaaa
ajaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaa
akaaaaaakgiocaaaaaaaaaaaakaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaa
abaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaa
cgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaa
acaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahcccabaaa
acaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaacaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaa
aeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaa
adaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaal
hcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaa
egacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
adaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaa
adaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaadaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaa
egacbaaaabaaaaaadoaaaaabejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheoiaaaaaaaaeaaaaaa
aiaaaaaagiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaheaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Matrix 17 [_ProjMat]
Vector 21 [_WorldSpaceCameraPos]
Vector 22 [_WorldSpaceLightPos0]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[26] = { { 1 },
		state.matrix.modelview[0],
		program.local[5..25] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1, c[22];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R6.xyz, R2, c[23].w, -vertex.position;
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.w, c[0].x;
MOV R1.xyz, c[21];
MOV R3, c[2];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R7.xyz, R2, c[23].w, -vertex.position;
MOV R2, c[1];
MUL R1, R3, c[19].y;
MAD R4, R2, c[19].x, R1;
MOV R1, c[3];
MAD R5, R1, c[19].z, R4;
DP3 result.texcoord[1].y, R6, R0;
DP3 result.texcoord[2].y, R0, R7;
MUL R0, R3, c[20].y;
MAD R0, R2, c[20].x, R0;
MAD R4, R1, c[20].z, R0;
MOV R0, c[4];
MAD R4, R0, c[20].w, R4;
MAD R5, R0, c[19].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[18].y;
MUL R3, R3, c[17].y;
MAD R4, R2, c[18].x, R4;
MAD R2, R2, c[17].x, R3;
MAD R3, R1, c[18].z, R4;
MAD R1, R1, c[17].z, R2;
MAD R2, R0, c[18].w, R3;
MAD R0, R0, c[17].w, R1;
DP4 result.position.x, vertex.position, R0;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP3 result.texcoord[1].z, vertex.normal, R6;
DP3 result.texcoord[1].x, R6, vertex.attrib[14];
DP3 result.texcoord[2].z, vertex.normal, R7;
DP3 result.texcoord[2].x, vertex.attrib[14], R7;
DP4 result.texcoord[3].w, R0, c[16];
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 55 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Matrix 16 [_ProjMat]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_BumpMap_ST]
"vs_2_0
def c25, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c25.x
mov r0.xyz, c20
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c22.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c21, r0
mov r0, c9
mov r1, c8
dp4 r4.y, c21, r0
dp4 r4.x, c21, r1
mad r0.xyz, r4, c22.w, -v0
dp3 oT1.y, r0, r2
dp3 oT2.y, r2, r3
dp3 oT1.z, v2, r0
dp3 oT1.x, r0, v1
mov r0.x, c19.y
mul r1, c1, r0.x
mov r0.x, c19
mad r1, c0, r0.x, r1
mov r0.x, c19.z
mad r1, c2, r0.x, r1
mov r0.x, c19.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c18.y
mov r0.x, c18
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c18.z
mad r1, c2, r0.x, r1
mov r0.x, c18.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c17.y
mov r0.x, c17
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c17.z
mad r1, c2, r0.x, r1
mov r0.x, c17.w
mad r0, c3, r0.x, r1
dp4 oPos.y, v0, r0
mov r2.x, c16.y
mul r1, c1, r2.x
mov r2.x, c16
mad r1, c0, r2.x, r1
mov r2.x, c16.z
mad r1, c2, r2.x, r1
mov r2.x, c16.w
mad r1, c3, r2.x, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oPos.x, v0, r1
dp4 oT3.w, r0, c15
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c24.xyxy, c24
mad oT0.xy, v3, c23, c23.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedogljfigmmnpimibplhdmbopadkinidhlabaaaaaaleajaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbiaiaaaaeaaaabaa
agacaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
anaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaah
hcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaaj
hcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaa
egacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaa
abaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaa
adaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
aaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaabdaaaaaa
dcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaabeaaaaaa
egbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaa
abaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaanaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaipcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaadcaaaaakpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegaobaaaabaaaaaa
dcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaa
egaobaaaabaaaaaadcaaaaakpccabaaaaeaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "SPOT" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefieceddicehfncofabbecmjdjakbgnnokdnkfnabaaaaaagiaoaaaaaeaaaaaa
daaaaaaaoaaeaaaaaaanaaaamianaaaaebgpgodjkiaeaaaakiaeaaaaaaacpopp
diaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aiaaabaaaaaaaaaaaaaaanaaacaaajaaaaaaaaaaabaaaeaaabaaalaaaaaaaaaa
acaaaaaaabaaamaaaaaaaaaaadaaaeaaaeaaanaaaaaaaaaaadaaamaaajaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabia
abaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaajaaoekaajaaookaaeaaaaaeaaaaamoaadaaeejaakaaeeka
akaaoekaabaaaaacaaaaapiaamaaoekaafaaaaadabaaahiaaaaaffiabgaaoeka
aeaaaaaeabaaahiabfaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiabhaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaahiabiaaoekaaaaappiaaaaaoeiaaeaaaaae
aaaaahiaaaaaoeiabjaappkaaaaaoejbaiaaaaadabaaaboaabaaoejaaaaaoeia
abaaaaacabaaahiaabaaoejaafaaaaadacaaahiaabaamjiaacaancjaaeaaaaae
abaaahiaacaamjjaabaanciaacaaoeibafaaaaadabaaahiaabaaoeiaabaappja
aiaaaaadabaaacoaabaaoeiaaaaaoeiaaiaaaaadabaaaeoaacaaoejaaaaaoeia
abaaaaacaaaaahiaalaaoekaafaaaaadacaaahiaaaaaffiabgaaoekaaeaaaaae
aaaaaliabfaakekaaaaaaaiaacaakeiaaeaaaaaeaaaaahiabhaaoekaaaaakkia
aaaapeiaacaaaaadaaaaahiaaaaaoeiabiaaoekaaeaaaaaeaaaaahiaaaaaoeia
bjaappkaaaaaoejbaiaaaaadacaaaboaabaaoejaaaaaoeiaaiaaaaadacaaacoa
abaaoeiaaaaaoeiaaiaaaaadacaaaeoaacaaoejaaaaaoeiaafaaaaadaaaaapia
aaaaffjabcaaoekaaeaaaaaeaaaaapiabbaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiabdaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabeaaoekaaaaappja
aaaaoeiaafaaaaadabaaapiaaaaaffiaacaaoekaaeaaaaaeabaaapiaabaaoeka
aaaaaaiaabaaoeiaaeaaaaaeabaaapiaadaaoekaaaaakkiaabaaoeiaaeaaaaae
adaaapoaaeaaoekaaaaappiaabaaoeiaabaaaaacaaaaapiaagaaoekaafaaaaad
abaaapiaaaaaoeiaaoaaffkaabaaaaacacaaapiaafaaoekaaeaaaaaeabaaapia
acaaoeiaaoaaaakaabaaoeiaabaaaaacadaaapiaahaaoekaaeaaaaaeabaaapia
adaaoeiaaoaakkkaabaaoeiaabaaaaacaeaaapiaaiaaoekaaeaaaaaeabaaapia
aeaaoeiaaoaappkaabaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaad
afaaapiaaaaaoeiaanaaffkaaeaaaaaeafaaapiaacaaoeiaanaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaanaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
anaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaad
afaaapiaaaaaoeiaapaaffkaaeaaaaaeafaaapiaacaaoeiaapaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaapaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
apaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaad
aaaaapiaaaaaoeiabaaaffkaaeaaaaaeaaaaapiaacaaoeiabaaaaakaaaaaoeia
aeaaaaaeaaaaapiaadaaoeiabaaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeia
baaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaa
fdeieefcbiaiaaaaeaaaabaaagacaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
pcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaa
giaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaa
fgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ahaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
adaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaa
aaaaaaaaaoaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgbpbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaa
acaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaah
cccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaa
acaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaa
egbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaa
adaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaaipcaabaaaabaaaaaafgafbaaaaaaaaaaaegiocaaaaaaaaaaa
aeaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagaabaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaakpcaabaaaabaaaaaaegiocaaaaaaaaaaa
afaaaaaakgakbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaakpccabaaaaeaaaaaa
egiocaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegaobaaaabaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaapaaaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Matrix 17 [_ProjMat]
Vector 21 [_WorldSpaceCameraPos]
Vector 22 [_WorldSpaceLightPos0]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[26] = { { 1 },
		state.matrix.modelview[0],
		program.local[5..25] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1, c[22];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R6.xyz, R2, c[23].w, -vertex.position;
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.w, c[0].x;
MOV R1.xyz, c[21];
MOV R3, c[2];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R7.xyz, R2, c[23].w, -vertex.position;
MOV R2, c[1];
MUL R1, R3, c[19].y;
MAD R4, R2, c[19].x, R1;
MOV R1, c[3];
MAD R5, R1, c[19].z, R4;
DP3 result.texcoord[1].y, R6, R0;
DP3 result.texcoord[2].y, R0, R7;
MUL R0, R3, c[20].y;
MAD R0, R2, c[20].x, R0;
MAD R4, R1, c[20].z, R0;
MOV R0, c[4];
MAD R4, R0, c[20].w, R4;
MAD R5, R0, c[19].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[18].y;
MUL R3, R3, c[17].y;
MAD R4, R2, c[18].x, R4;
MAD R2, R2, c[17].x, R3;
MAD R3, R1, c[18].z, R4;
MAD R1, R1, c[17].z, R2;
MAD R2, R0, c[18].w, R3;
MAD R0, R0, c[17].w, R1;
DP4 result.position.x, vertex.position, R0;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP3 result.texcoord[1].z, vertex.normal, R6;
DP3 result.texcoord[1].x, R6, vertex.attrib[14];
DP3 result.texcoord[2].z, vertex.normal, R7;
DP3 result.texcoord[2].x, vertex.attrib[14], R7;
DP4 result.texcoord[3].z, R0, c[15];
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 54 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Matrix 16 [_ProjMat]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_BumpMap_ST]
"vs_2_0
def c25, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c25.x
mov r0.xyz, c20
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c22.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c21, r0
mov r0, c9
mov r1, c8
dp4 r4.y, c21, r0
dp4 r4.x, c21, r1
mad r0.xyz, r4, c22.w, -v0
dp3 oT1.y, r0, r2
dp3 oT2.y, r2, r3
dp3 oT1.z, v2, r0
dp3 oT1.x, r0, v1
mov r0.x, c19.y
mul r1, c1, r0.x
mov r0.x, c19
mad r1, c0, r0.x, r1
mov r0.x, c19.z
mad r1, c2, r0.x, r1
mov r0.x, c19.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c18.y
mov r0.x, c18
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c18.z
mad r1, c2, r0.x, r1
mov r0.x, c18.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c17.y
mov r0.x, c17
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c17.z
mad r1, c2, r0.x, r1
mov r0.x, c17.w
mad r0, c3, r0.x, r1
dp4 oPos.y, v0, r0
mov r2.x, c16.y
mul r1, c1, r2.x
mov r2.x, c16
mad r1, c0, r2.x, r1
mov r2.x, c16.z
mad r1, c2, r2.x, r1
mov r2.x, c16.w
mad r1, c3, r2.x, r1
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oPos.x, v0, r1
dp4 oT3.z, r0, c14
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c24.xyxy, c24
mad oT0.xy, v3, c23, c23.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedalnboepjagbnhijhgopooeicakinmmfhabaaaaaaleajaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcbiaiaaaaeaaaabaa
agacaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
anaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaah
hcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaaj
hcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaa
egacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaa
abaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaa
adaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaa
agiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
aaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaadaaaaaabdaaaaaa
dcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaapgipcaaaadaaaaaabeaaaaaa
egbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaaadaaaaaaegacbaaaaaaaaaaa
egacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaa
abaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaa
diaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaadaaaaaaanaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaaoaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
adaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaaihcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaaaeaaaaaadcaaaaakhcaabaaa
abaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
dcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaaaaaaaaaagaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedfgnbdfkolgbdlhfefnifokjfkoiphnpmabaaaaaagiaoaaaaaeaaaaaa
daaaaaaaoaaeaaaaaaanaaaamianaaaaebgpgodjkiaeaaaakiaeaaaaaaacpopp
diaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aiaaabaaaaaaaaaaaaaaanaaacaaajaaaaaaaaaaabaaaeaaabaaalaaaaaaaaaa
acaaaaaaabaaamaaaaaaaaaaadaaaeaaaeaaanaaaaaaaaaaadaaamaaajaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabia
abaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaajaaoekaajaaookaaeaaaaaeaaaaamoaadaaeejaakaaeeka
akaaoekaabaaaaacaaaaapiaamaaoekaafaaaaadabaaahiaaaaaffiabgaaoeka
aeaaaaaeabaaahiabfaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiabhaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaahiabiaaoekaaaaappiaaaaaoeiaaeaaaaae
aaaaahiaaaaaoeiabjaappkaaaaaoejbaiaaaaadabaaaboaabaaoejaaaaaoeia
abaaaaacabaaahiaabaaoejaafaaaaadacaaahiaabaamjiaacaancjaaeaaaaae
abaaahiaacaamjjaabaanciaacaaoeibafaaaaadabaaahiaabaaoeiaabaappja
aiaaaaadabaaacoaabaaoeiaaaaaoeiaaiaaaaadabaaaeoaacaaoejaaaaaoeia
abaaaaacaaaaahiaalaaoekaafaaaaadacaaahiaaaaaffiabgaaoekaaeaaaaae
aaaaaliabfaakekaaaaaaaiaacaakeiaaeaaaaaeaaaaahiabhaaoekaaaaakkia
aaaapeiaacaaaaadaaaaahiaaaaaoeiabiaaoekaaeaaaaaeaaaaahiaaaaaoeia
bjaappkaaaaaoejbaiaaaaadacaaaboaabaaoejaaaaaoeiaaiaaaaadacaaacoa
abaaoeiaaaaaoeiaaiaaaaadacaaaeoaacaaoejaaaaaoeiaafaaaaadaaaaapia
aaaaffjabcaaoekaaeaaaaaeaaaaapiabbaaoekaaaaaaajaaaaaoeiaaeaaaaae
aaaaapiabdaaoekaaaaakkjaaaaaoeiaaeaaaaaeaaaaapiabeaaoekaaaaappja
aaaaoeiaafaaaaadabaaahiaaaaaffiaacaaoekaaeaaaaaeabaaahiaabaaoeka
aaaaaaiaabaaoeiaaeaaaaaeaaaaahiaadaaoekaaaaakkiaabaaoeiaaeaaaaae
adaaahoaaeaaoekaaaaappiaaaaaoeiaabaaaaacaaaaapiaagaaoekaafaaaaad
abaaapiaaaaaoeiaaoaaffkaabaaaaacacaaapiaafaaoekaaeaaaaaeabaaapia
acaaoeiaaoaaaakaabaaoeiaabaaaaacadaaapiaahaaoekaaeaaaaaeabaaapia
adaaoeiaaoaakkkaabaaoeiaabaaaaacaeaaapiaaiaaoekaaeaaaaaeabaaapia
aeaaoeiaaoaappkaabaaoeiaafaaaaadabaaapiaabaaoeiaaaaaffjaafaaaaad
afaaapiaaaaaoeiaanaaffkaaeaaaaaeafaaapiaacaaoeiaanaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaanaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
anaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaaaajaabaaoeiaafaaaaad
afaaapiaaaaaoeiaapaaffkaaeaaaaaeafaaapiaacaaoeiaapaaaakaafaaoeia
aeaaaaaeafaaapiaadaaoeiaapaakkkaafaaoeiaaeaaaaaeafaaapiaaeaaoeia
apaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeiaaaaakkjaabaaoeiaafaaaaad
aaaaapiaaaaaoeiabaaaffkaaeaaaaaeaaaaapiaacaaoeiabaaaaakaaaaaoeia
aeaaaaaeaaaaapiaadaaoeiabaaakkkaaaaaoeiaaeaaaaaeaaaaapiaaeaaoeia
baaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeiaaaaappjaabaaoeiaaeaaaaae
aaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaa
fdeieefcbiaiaaaaeaaaabaaagacaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaa
fjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaa
fjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaad
pcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaa
ghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaad
hccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaa
giaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaa
fgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ahaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaa
aaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
adaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaa
aaaaaaaaaoaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgbpbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaa
egiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
baaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaa
acaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaa
abaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaah
cccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaa
acaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaa
egbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaa
adaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaaaaaaaaaaegiccaaaaaaaaaaa
aeaaaaaadcaaaaakhcaabaaaabaaaaaaegiccaaaaaaaaaaaadaaaaaaagaabaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaaaaaaaaa
afaaaaaakgakbaaaaaaaaaaaegacbaaaabaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_LightMatrix0]
Matrix 17 [_ProjMat]
Vector 21 [_WorldSpaceCameraPos]
Vector 22 [_WorldSpaceLightPos0]
Vector 23 [unity_Scale]
Vector 24 [_MainTex_ST]
Vector 25 [_BumpMap_ST]
"!!ARBvp1.0
PARAM c[26] = { { 1 },
		state.matrix.modelview[0],
		program.local[5..25] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
TEMP R7;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MOV R1, c[22];
DP4 R6.z, R1, c[11];
DP4 R6.y, R1, c[10];
DP4 R6.x, R1, c[9];
MUL R0.xyz, R0, vertex.attrib[14].w;
MOV R1.w, c[0].x;
MOV R1.xyz, c[21];
MOV R3, c[2];
DP4 R2.z, R1, c[11];
DP4 R2.x, R1, c[9];
DP4 R2.y, R1, c[10];
MAD R7.xyz, R2, c[23].w, -vertex.position;
MOV R2, c[1];
MUL R1, R3, c[19].y;
MAD R4, R2, c[19].x, R1;
MOV R1, c[3];
MAD R5, R1, c[19].z, R4;
DP3 result.texcoord[1].y, R6, R0;
DP3 result.texcoord[2].y, R0, R7;
MUL R0, R3, c[20].y;
MAD R0, R2, c[20].x, R0;
MAD R4, R1, c[20].z, R0;
MOV R0, c[4];
MAD R4, R0, c[20].w, R4;
MAD R5, R0, c[19].w, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R3, c[18].y;
MUL R3, R3, c[17].y;
MAD R4, R2, c[18].x, R4;
MAD R2, R2, c[17].x, R3;
MAD R3, R1, c[18].z, R4;
MAD R1, R1, c[17].z, R2;
MAD R2, R0, c[18].w, R3;
MAD R0, R0, c[17].w, R1;
DP4 result.position.x, vertex.position, R0;
DP4 R0.w, vertex.position, c[8];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
DP4 result.position.z, vertex.position, R5;
DP4 result.position.y, vertex.position, R2;
DP3 result.texcoord[1].z, vertex.normal, R6;
DP3 result.texcoord[1].x, R6, vertex.attrib[14];
DP3 result.texcoord[2].z, vertex.normal, R7;
DP3 result.texcoord[2].x, vertex.attrib[14], R7;
DP4 result.texcoord[3].y, R0, c[14];
DP4 result.texcoord[3].x, R0, c[13];
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[25].xyxy, c[25];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[24], c[24].zwzw;
END
# 52 instructions, 8 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_LightMatrix0]
Matrix 16 [_ProjMat]
Vector 20 [_WorldSpaceCameraPos]
Vector 21 [_WorldSpaceLightPos0]
Vector 22 [unity_Scale]
Vector 23 [_MainTex_ST]
Vector 24 [_BumpMap_ST]
"vs_2_0
def c25, 1.00000000, 0, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.w, c25.x
mov r0.xyz, c20
dp4 r1.z, r0, c10
dp4 r1.y, r0, c9
dp4 r1.x, r0, c8
mad r3.xyz, r1, c22.w, -v0
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r2.xyz, r1, v1.w
mov r0, c10
dp4 r4.z, c21, r0
mov r0, c9
dp4 r4.y, c21, r0
mov r1, c8
dp4 r4.x, c21, r1
mov r0.x, c19.y
mul r1, c1, r0.x
mov r0.x, c19
mad r1, c0, r0.x, r1
mov r0.x, c19.z
mad r1, c2, r0.x, r1
mov r0.x, c19.w
mad r0, c3, r0.x, r1
dp4 oPos.w, r0, v0
mov r1.x, c18.y
mov r0.x, c18
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c18.z
mad r1, c2, r0.x, r1
mov r0.x, c18.w
mad r0, c3, r0.x, r1
dp4 oPos.z, v0, r0
mov r1.x, c17.y
mov r0.x, c17
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c17.z
mad r1, c2, r0.x, r1
mov r0.x, c17.w
mad r0, c3, r0.x, r1
dp4 oPos.y, v0, r0
dp4 r0.w, v0, c7
dp4 r0.z, v0, c6
dp4 r0.x, v0, c4
dp4 r0.y, v0, c5
dp3 oT1.y, r4, r2
dp3 oT2.y, r2, r3
mov r2.x, c16.y
mul r1, c1, r2.x
mov r2.x, c16
mad r1, c0, r2.x, r1
mov r2.x, c16.z
mad r1, c2, r2.x, r1
mov r2.x, c16.w
mad r1, c3, r2.x, r1
dp3 oT1.z, v2, r4
dp3 oT1.x, r4, v1
dp3 oT2.z, v2, r3
dp3 oT2.x, v1, r3
dp4 oPos.x, v0, r1
dp4 oT3.y, r0, c13
dp4 oT3.x, r0, c12
mad oT0.zw, v3.xyxy, c24.xyxy, c24
mad oT0.xy, v3, c23, c23.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedockehcopifcgbllkalendnccoaiedoemabaaaaaaiiajaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadamaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcomahaaaaeaaaabaa
plabaaaafjaaaaaeegiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaa
afaaaaaafjaaaaaeegiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaaddccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
ajaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaajaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aiaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaahaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaa
pgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
anaaaaaaogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaa
adaaaaaaagiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaah
hcaabaaaaaaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaa
aaaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaa
diaaaaahhcaabaaaaaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaaj
hcaabaaaabaaaaaafgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaa
aaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaa
bcaaaaaakgikcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaabaaaaaahcccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaa
baaaaaahbccabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaah
eccabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaajhcaabaaa
abaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaal
hcaabaaaabaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaa
egacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaa
kgikcaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaa
egacbaaaabaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaa
egacbaaaabaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaa
baaaaaahcccabaaaadaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
bccabaaaadaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaa
adaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaamaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaaidcaabaaaabaaaaaafgafbaaaaaaaaaaa
egiacaaaaaaaaaaaaeaaaaaadcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
adaaaaaaagaabaaaaaaaaaaaegaabaaaabaaaaaadcaaaaakdcaabaaaaaaaaaaa
egiacaaaaaaaaaaaafaaaaaakgakbaaaaaaaaaaaegaabaaaaaaaaaaadcaaaaak
dccabaaaaeaaaaaaegiacaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegaabaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL_COOKIE" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 240
Matrix 48 [_LightMatrix0]
Matrix 112 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
ConstBuffer "UnityLighting" 720
Vector 0 [_WorldSpaceLightPos0]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0_level_9_1
eefiecedhlamgifcpeponfhiajifhbhepghafamjabaaaaaaciaoaaaaaeaaaaaa
daaaaaaammaeaaaamaamaaaaiianaaaaebgpgodjjeaeaaaajeaeaaaaaaacpopp
ceaeaaaahaaaaaaaagaaceaaaaaagmaaaaaagmaaaaaaceaaabaagmaaaaaaadaa
aiaaabaaaaaaaaaaaaaaanaaacaaajaaaaaaaaaaabaaaeaaabaaalaaaaaaaaaa
acaaaaaaabaaamaaaaaaaaaaadaaaeaaaeaaanaaaaaaaaaaadaaamaaajaabbaa
aaaaaaaaaaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabia
abaaapjabpaaaaacafaaaciaacaaapjabpaaaaacafaaadiaadaaapjaaeaaaaae
aaaaadoaadaaoejaajaaoekaajaaookaaeaaaaaeaaaaamoaadaaeejaakaaeeka
akaaoekaabaaaaacaaaaapiaamaaoekaafaaaaadabaaahiaaaaaffiabgaaoeka
aeaaaaaeabaaahiabfaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaahiabhaaoeka
aaaakkiaabaaoeiaaeaaaaaeaaaaahiabiaaoekaaaaappiaaaaaoeiaaiaaaaad
abaaaboaabaaoejaaaaaoeiaabaaaaacabaaahiaabaaoejaafaaaaadacaaahia
abaamjiaacaancjaaeaaaaaeabaaahiaacaamjjaabaanciaacaaoeibafaaaaad
abaaahiaabaaoeiaabaappjaaiaaaaadabaaacoaabaaoeiaaaaaoeiaaiaaaaad
abaaaeoaacaaoejaaaaaoeiaabaaaaacaaaaahiaalaaoekaafaaaaadacaaahia
aaaaffiabgaaoekaaeaaaaaeaaaaaliabfaakekaaaaaaaiaacaakeiaaeaaaaae
aaaaahiabhaaoekaaaaakkiaaaaapeiaacaaaaadaaaaahiaaaaaoeiabiaaoeka
aeaaaaaeaaaaahiaaaaaoeiabjaappkaaaaaoejbaiaaaaadacaaaboaabaaoeja
aaaaoeiaaiaaaaadacaaacoaabaaoeiaaaaaoeiaaiaaaaadacaaaeoaacaaoeja
aaaaoeiaafaaaaadaaaaapiaaaaaffjabcaaoekaaeaaaaaeaaaaapiabbaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiabdaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiabeaaoekaaaaappjaaaaaoeiaafaaaaadabaaadiaaaaaffiaacaaoeka
aeaaaaaeaaaaadiaabaaoekaaaaaaaiaabaaoeiaaeaaaaaeaaaaadiaadaaoeka
aaaakkiaaaaaoeiaaeaaaaaeadaaadoaaeaaoekaaaaappiaaaaaoeiaabaaaaac
aaaaapiaagaaoekaafaaaaadabaaapiaaaaaoeiaaoaaffkaabaaaaacacaaapia
afaaoekaaeaaaaaeabaaapiaacaaoeiaaoaaaakaabaaoeiaabaaaaacadaaapia
ahaaoekaaeaaaaaeabaaapiaadaaoeiaaoaakkkaabaaoeiaabaaaaacaeaaapia
aiaaoekaaeaaaaaeabaaapiaaeaaoeiaaoaappkaabaaoeiaafaaaaadabaaapia
abaaoeiaaaaaffjaafaaaaadafaaapiaaaaaoeiaanaaffkaaeaaaaaeafaaapia
acaaoeiaanaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiaanaakkkaafaaoeia
aeaaaaaeafaaapiaaeaaoeiaanaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeia
aaaaaajaabaaoeiaafaaaaadafaaapiaaaaaoeiaapaaffkaaeaaaaaeafaaapia
acaaoeiaapaaaakaafaaoeiaaeaaaaaeafaaapiaadaaoeiaapaakkkaafaaoeia
aeaaaaaeafaaapiaaeaaoeiaapaappkaafaaoeiaaeaaaaaeabaaapiaafaaoeia
aaaakkjaabaaoeiaafaaaaadaaaaapiaaaaaoeiabaaaffkaaeaaaaaeaaaaapia
acaaoeiabaaaaakaaaaaoeiaaeaaaaaeaaaaapiaadaaoeiabaaakkkaaaaaoeia
aeaaaaaeaaaaapiaaeaaoeiabaaappkaaaaaoeiaaeaaaaaeaaaaapiaaaaaoeia
aaaappjaabaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoekaaaaaoeiaabaaaaac
aaaaammaaaaaoeiappppaaaafdeieefcomahaaaaeaaaabaaplabaaaafjaaaaae
egiocaaaaaaaaaaaapaaaaaafjaaaaaeegiocaaaabaaaaaaafaaaaaafjaaaaae
egiocaaaacaaaaaaabaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaadhccabaaaadaaaaaa
gfaaaaaddccabaaaaeaaaaaagiaaaaacacaaaaaadiaaaaajpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaakaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaa
kgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaiaaaaaafgifcaaa
adaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaahaaaaaa
agiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaakaaaaaapgipcaaaadaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaiaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaahaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaajaaaaaakgikcaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
akaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpccabaaa
aaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaanaaaaaaogikcaaa
aaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaa
aaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaahhcaabaaaaaaaaaaa
jgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaa
acaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaa
aaaaaaaaegacbaaaaaaaaaaapgbpbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaa
fgifcaaaacaaaaaaaaaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaa
abaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaaacaaaaaaaaaaaaaaegacbaaa
abaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaa
acaaaaaaaaaaaaaaegacbaaaabaaaaaadcaaaaalhcaabaaaabaaaaaaegiccaaa
adaaaaaabdaaaaaapgipcaaaacaaaaaaaaaaaaaaegacbaaaabaaaaaabaaaaaah
cccabaaaacaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaa
acaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaacaaaaaa
egbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaajhcaabaaaabaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaabaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaabaaaaaa
dcaaaaalhcaabaaaabaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaabaaaaaaaaaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaabaaaaaaegacbaaaabaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaabaaaaaahcccabaaa
adaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbccabaaaadaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaaheccabaaaadaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiocaaaadaaaaaaanaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaaidcaabaaaabaaaaaafgafbaaaaaaaaaaaegiacaaaaaaaaaaa
aeaaaaaadcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaaadaaaaaaagaabaaa
aaaaaaaaegaabaaaabaaaaaadcaaaaakdcaabaaaaaaaaaaaegiacaaaaaaaaaaa
afaaaaaakgakbaaaaaaaaaaaegaabaaaaaaaaaaadcaaaaakdccabaaaaeaaaaaa
egiacaaaaaaaaaaaagaaaaaapgapbaaaaaaaaaaaegaabaaaaaaaaaaadoaaaaab
ejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaa
kjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaalaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaaabaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
faepfdejfeejepeoaafeebeoehefeofeaaeoepfcenebemaafeeffiedepepfcee
aaedepemepfcaaklepfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahaiaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahaiaaaaimaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaadamaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklkl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
DP3 R1.x, fragment.texcoord[3], fragment.texcoord[3];
DP3 R3.x, fragment.texcoord[2], fragment.texcoord[2];
MUL R0.xyz, R0, c[2];
RSQ R3.x, R3.x;
MOV result.color.w, c[4].x;
TEX R2.w, R1.x, texture[2], 2D;
DP3 R1.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R1.x, R1.x;
MUL R2.xyz, R1.x, fragment.texcoord[1];
MAD R1.xy, R1.wyzw, c[4].y, -c[4].z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
MAD R3.xyz, R3.x, fragment.texcoord[2], R2;
DP3 R1.w, R3, R3;
RSQ R1.w, R1.w;
MUL R3.xyz, R1.w, R3;
ADD R1.z, -R1, c[4];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
DP3 R3.x, R1, R3;
MOV R1.w, c[4];
MUL R3.y, R1.w, c[3].x;
MAX R1.w, R3.x, c[4].x;
POW R1.w, R1.w, R3.y;
MUL R0.w, R1, R0;
DP3 R1.x, R1, R2;
MAX R1.w, R1.x, c[4].x;
MUL R1.xyz, R0, c[0];
MUL R1.xyz, R1, R1.w;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R1.w, R2, c[4].y;
MAD R0.xyz, R0, R0.w, R1;
MUL result.color.xyz, R0, R1.w;
END
# 36 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
dp3 r0.x, t3, t3
mov r1.xy, r0.x
mul_pp r2.xyz, r2, c2
mul_pp r2.xyz, r2, c0
mov r0.y, t0.w
mov r0.x, t0.z
texld r6, r1, s2
texld r0, r0, s1
mov r0.x, r0.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3_pp r1.x, t2, t2
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
mov_pp r0.x, c3
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r4, r1
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r5.x, r1.x, r0.x
dp3_pp r1.x, r4, r3
max_pp r1.x, r1, c4.w
mul_pp r3.xyz, r2, r1.x
mov r0.x, r5.x
mov_pp r2.xyz, c0
mul r0.x, r0, r2.w
mul_pp r2.xyz, c1, r2
mul_pp r1.x, r6, c4
mad r0.xyz, r2, r0.x, r3
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "POINT" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_BumpMap] 2D 2
SetTexture 2 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedkeiohkaidhkldcjghhemeklfmkmflpojabaaaaaakiafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefckaaeaaaaeaaaaaaaciabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaacaaaaaaegbcbaaa
acaaaaaaeeaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahocaabaaa
aaaaaaaafgafbaaaaaaaaaaaagbjbaaaacaaaaaadcaaaaajhcaabaaaabaaaaaa
egbcbaaaadaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaabaaaaaahbcaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaa
abaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaa
aagabaaaacaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaa
aaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaa
aaaaaaaaapaaaaahbcaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaa
ddaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaai
bcaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaaf
ecaabaaaacaaaaaaakaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaa
acaaaaaaegacbaaaabaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaa
jgahbaaaaaaaaaaadeaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaaiecaabaaaaaaaaaaaakiacaaaaaaaaaaaamaaaaaaabeaaaaa
aaaaaaeddiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaa
bjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaa
egacbaaaabaaaaaaegiccaaaaaaaaaaaalaaaaaadiaaaaaihcaabaaaabaaaaaa
egacbaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaadiaaaaajhcaabaaaacaaaaaa
egiccaaaaaaaaaaaabaaaaaaegiccaaaaaaaaaaaacaaaaaadiaaaaahncaabaaa
aaaaaaaaagaabaaaaaaaaaaaagajbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaa
egacbaaaabaaaaaafgafbaaaaaaaaaaaigadbaaaaaaaaaaabaaaaaahicaabaaa
aaaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaa
pgapbaaaaaaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaaaaaaaaahicaabaaa
aaaaaaaaakaabaaaabaaaaaaakaabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_BumpMap] 2D 2
SetTexture 2 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedfbaeabpafdafknpbajllaadbgfbjpkbhabaaaaaakmaiaaaaaeaaaaaa
daaaaaaadaadaaaaniahaaaahiaiaaaaebgpgodjpiacaaaapiacaaaaaaacpppp
laacaaaaeiaaaaaaacaadaaaaaaaeiaaaaaaeiaaadaaceaaaaaaeiaaacaaaaaa
aaababaaabacacaaaaaaabaaacaaaaaaaaaaaaaaaaaaalaaacaaacaaaaaaaaaa
aaacppppfbaaaaafaeaaapkaaaaaaaeaaaaaialpaaaaaaaaaaaaiadpfbaaaaaf
afaaapkaaaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaapla
bpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaia
adaaahlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkaaiaaaaadaaaaciiaacaaoelaacaaoelaahaaaaacaaaacbia
aaaappiaceaaaaacabaachiaabaaoelaaeaaaaaeaaaachiaacaaoelaaaaaaaia
abaaoeiaceaaaaacacaachiaaaaaoeiaabaaaaacaaaaabiaaaaakklaabaaaaac
aaaaaciaaaaapplaaiaaaaadabaaaiiaadaaoelaadaaoelaabaaaaacadaaadia
abaappiaecaaaaadaaaacpiaaaaaoeiaacaioekaecaaaaadaeaacpiaaaaaoela
abaioekaecaaaaadadaacpiaadaaoeiaaaaioekaaeaaaaaeafaacbiaaaaappia
aeaaaakaaeaaffkaaeaaaaaeafaacciaaaaaffiaaeaaaakaaeaaffkafkaaaaae
abaadiiaafaaoeiaafaaoeiaaeaakkkaacaaaaadabaaciiaabaappibaeaappka
ahaaaaacabaaciiaabaappiaagaaaaacafaaceiaabaappiaaiaaaaadabaaciia
afaaoeiaacaaoeiaaiaaaaadaaaacbiaafaaoeiaabaaoeiaalaaaaadabaacbia
aaaaaaiaaeaakkkaalaaaaadaaaaabiaabaappiaaeaakkkaabaaaaacacaaabia
adaaaakaafaaaaadaaaaaciaacaaaaiaafaaaakacaaaaaadabaaaciaaaaaaaia
aaaaffiaafaaaaadaeaaaiiaaeaappiaabaaffiaafaaaaadaaaachiaaeaaoeia
acaaoekaafaaaaadaaaachiaaaaaoeiaaaaaoekaabaaaaacacaaahiaaaaaoeka
afaaaaadabaaaoiaacaabliaabaablkaafaaaaadabaaaoiaaeaappiaabaaoeia
aeaaaaaeaaaaahiaaaaaoeiaabaaaaiaabaabliaacaaaaadaaaaaiiaadaaaaia
adaaaaiaafaaaaadaaaachiaaaaappiaaaaaoeiaabaaaaacaaaaciiaaeaakkka
abaaaaacaaaicpiaaaaaoeiappppaaaafdeieefckaaeaaaaeaaaaaaaciabaaaa
fjaaaaaeegiocaaaaaaaaaaaanaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaad
aagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaaaaaaaaaa
ffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaabaaaaaahccaabaaa
aaaaaaaaegbcbaaaacaaaaaaegbcbaaaacaaaaaaeeaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagbjbaaa
acaaaaaadcaaaaajhcaabaaaabaaaaaaegbcbaaaadaaaaaaagaabaaaaaaaaaaa
jgahbaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaa
acaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaa
aceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahbcaabaaaaaaaaaaa
egaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaiadpaaaaaaaibcaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaaakaabaaaaaaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaabaaaaaah
ccaabaaaaaaaaaaaegacbaaaacaaaaaajgahbaaaaaaaaaaadeaaaaakdcaabaaa
aaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaiecaabaaaaaaaaaaa
akiacaaaaaaaaaaaamaaaaaaabeaaaaaaaaaaaeddiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
abaaaaaadiaaaaajhcaabaaaacaaaaaaegiccaaaaaaaaaaaabaaaaaaegiccaaa
aaaaaaaaacaaaaaadiaaaaahncaabaaaaaaaaaaaagaabaaaaaaaaaaaagajbaaa
acaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaafgafbaaaaaaaaaaa
igadbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaaegbcbaaaaeaaaaaaegbcbaaa
aeaaaaaaefaaaaajpcaabaaaabaaaaaapgapbaaaaaaaaaaaeghobaaaacaaaaaa
aagabaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaaakaabaaa
abaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaa
dgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheojiaaaaaa
afaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaa
imaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaa
aaaaaaaaadaaaaaaacaaaaaaahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaa
adaaaaaaahahaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
MAD R1.xy, R1.wyzw, c[4].y, -c[4].z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
DP3 R2.w, fragment.texcoord[2], fragment.texcoord[2];
ADD R1.z, -R1, c[4];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
MUL R0.xyz, R0, c[2];
MOV R2.xyz, fragment.texcoord[1];
RSQ R2.w, R2.w;
MAD R2.xyz, R2.w, fragment.texcoord[2], R2;
DP3 R1.w, R2, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R2;
DP3 R2.x, R1, R2;
MOV R1.w, c[4];
MUL R2.y, R1.w, c[3].x;
MAX R1.w, R2.x, c[4].x;
POW R1.w, R1.w, R2.y;
MUL R0.w, R1, R0;
DP3 R1.w, R1, fragment.texcoord[1];
MUL R1.xyz, R0, c[0];
MAX R1.w, R1, c[4].x;
MOV R0.xyz, c[1];
MUL R1.xyz, R1, R1.w;
MUL R0.xyz, R0, c[0];
MAD R0.xyz, R0, R0.w, R1;
MUL result.color.xyz, R0, c[4].y;
MOV result.color.w, c[4].x;
END
# 31 instructions, 3 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
texld r2, t0, s0
dp3_pp r1.x, t2, t2
rsq_pp r1.x, r1.x
mov_pp r3.xyz, t1
mad_pp r3.xyz, r1.x, t2, r3
mul_pp r2.xyz, r2, c2
mov r0.y, t0.w
mov r0.x, t0.z
texld r0, r0, s1
mov r0.x, r0.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
add_pp r1.x, -r0, c4.z
dp3_pp r0.x, r3, r3
rsq_pp r1.x, r1.x
rcp_pp r4.z, r1.x
rsq_pp r0.x, r0.x
mul_pp r1.xyz, r0.x, r3
dp3_pp r1.x, r4, r1
mov_pp r0.x, c3
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r3.w, r1.x, r0.x
mov r0.x, r3.w
mul_pp r3.xyz, r2, c0
dp3_pp r1.x, r4, t1
max_pp r1.x, r1, c4.w
mov_pp r2.xyz, c0
mul r0.x, r0, r2.w
mul_pp r1.xyz, r3, r1.x
mul_pp r2.xyz, c1, r2
mad r0.xyz, r2, r0.x, r1
mul r0.xyz, r0, c4.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 112 [_Color]
Float 128 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedgbofcidhgoljhpajhmcnpgnklamjjdmlabaaaaaamaaeaaaaadaaaaaa
cmaaaaaaleaaaaaaoiaaaaaaejfdeheoiaaaaaaaaeaaaaaaaiaaaaaagiaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklklfdeieefcnaadaaaaeaaaaaaapeaaaaaafjaaaaaeegiocaaa
aaaaaaaaajaaaaaafkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaa
fibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaa
gcbaaaadpcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaa
adaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegbcbaaaadaaaaaaagaabaaa
aaaaaaaaegbcbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaabaaaaaaegbcbaaaacaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaiecaabaaa
aaaaaaaaakiacaaaaaaaaaaaaiaaaaaaabeaaaaaaaaaaaeddiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
dkaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaahaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaabaaaaaadiaaaaajhcaabaaaacaaaaaaegiccaaaaaaaaaaaabaaaaaa
egiccaaaaaaaaaaaacaaaaaadiaaaaahncaabaaaaaaaaaaaagaabaaaaaaaaaaa
agajbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaafgafbaaa
aaaaaaaaigadbaaaaaaaaaaaaaaaaaahhccabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" }
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
ConstBuffer "$Globals" 176
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 112 [_Color]
Float 128 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedbhkkkkaojdpcmocgcggkahbibpeadidfabaaaaaagmahaaaaaeaaaaaa
daaaaaaaniacaaaalaagaaaadiahaaaaebgpgodjkaacaaaakaacaaaaaaacpppp
fmacaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaaaaaaaaa
abababaaaaaaabaaacaaaaaaaaaaaaaaaaaaahaaacaaacaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkaaaaaaaeaaaaaialpaaaaaaaaaaaaiadpfbaaaaafafaaapka
aaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaachlabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaajaaaaiapka
bpaaaaacaaaaaajaabaiapkaaiaaaaadaaaaciiaacaaoelaacaaoelaahaaaaac
aaaacbiaaaaappiaabaaaaacabaaahiaacaaoelaaeaaaaaeaaaachiaabaaoeia
aaaaaaiaabaaoelaceaaaaacabaachiaaaaaoeiaabaaaaacaaaaabiaaaaakkla
abaaaaacaaaaaciaaaaapplaecaaaaadaaaacpiaaaaaoeiaabaioekaecaaaaad
acaacpiaaaaaoelaaaaioekaaeaaaaaeadaacbiaaaaappiaaeaaaakaaeaaffka
aeaaaaaeadaacciaaaaaffiaaeaaaakaaeaaffkafkaaaaaeabaadiiaadaaoeia
adaaoeiaaeaakkkaacaaaaadabaaciiaabaappibaeaappkaahaaaaacabaaciia
abaappiaagaaaaacadaaceiaabaappiaaiaaaaadadaaciiaadaaoeiaabaaoeia
aiaaaaadaaaacbiaadaaoeiaabaaoelaalaaaaadabaacbiaaaaaaaiaaeaakkka
alaaaaadaaaaabiaadaappiaaeaakkkaabaaaaacadaaabiaadaaaakaafaaaaad
aaaaaciaadaaaaiaafaaaakacaaaaaadabaaaciaaaaaaaiaaaaaffiaafaaaaad
acaaaiiaacaappiaabaaffiaafaaaaadaaaachiaacaaoeiaacaaoekaafaaaaad
aaaachiaaaaaoeiaaaaaoekaabaaaaacacaaahiaaaaaoekaafaaaaadabaaaoia
acaabliaabaablkaafaaaaadabaaaoiaacaappiaabaaoeiaaeaaaaaeaaaaahia
aaaaoeiaabaaaaiaabaabliaacaaaaadaaaachiaaaaaoeiaaaaaoeiaabaaaaac
aaaaciiaaeaakkkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcnaadaaaa
eaaaaaaapeaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaajhcaabaaa
aaaaaaaaegbcbaaaadaaaaaaagaabaaaaaaaaaaaegbcbaaaacaaaaaabaaaaaah
icaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaficaabaaa
aaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaa
abaaaaaaaagabaaaabaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaaabaaaaaa
aceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialp
aaaaaaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaaegaabaaa
abaaaaaaddaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadp
aaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadp
elaaaaafecaabaaaabaaaaaadkaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaaaaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaa
abaaaaaaegbcbaaaacaaaaaadeaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacpaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaiecaabaaaaaaaaaaaakiacaaaaaaaaaaaaiaaaaaa
abeaaaaaaaaaaaeddiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaackaabaaa
aaaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaahaaaaaadiaaaaaihcaabaaa
abaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaadiaaaaajhcaabaaa
acaaaaaaegiccaaaaaaaaaaaabaaaaaaegiccaaaaaaaaaaaacaaaaaadiaaaaah
ncaabaaaaaaaaaaaagaabaaaaaaaaaaaagajbaaaacaaaaaadcaaaaajhcaabaaa
aaaaaaaaegacbaaaabaaaaaafgafbaaaaaaaaaaaigadbaaaaaaaaaaaaaaaaaah
hccabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheoiaaaaaaaaeaaaaaaaiaaaaaa
giaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaheaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaabaaaaaaapapaaaaheaaaaaaabaaaaaaaaaaaaaaadaaaaaa
acaaaaaaahahaaaaheaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaa
fdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaa
abaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaa
fdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
SetTexture 3 [_LightTextureB0] 2D 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[6] = { program.local[0..3],
		{ 0, 2, 1, 128 },
		{ 0.5 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R2, fragment.texcoord[0], texture[0], 2D;
MAD R3.xy, R3.wyzw, c[4].y, -c[4].z;
DP3 R0.z, fragment.texcoord[3], fragment.texcoord[3];
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R3.z, R3, R3.w;
RCP R0.x, fragment.texcoord[3].w;
MAD R0.xy, fragment.texcoord[3], R0.x, c[5].x;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R3.z, -R3, c[4];
RSQ R3.z, R3.z;
RCP R3.z, R3.z;
RSQ R1.x, R1.x;
MOV result.color.w, c[4].x;
TEX R0.w, R0, texture[2], 2D;
TEX R1.w, R0.z, texture[3], 2D;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, R1.x, fragment.texcoord[2], R0;
DP3 R3.w, R1, R1;
RSQ R3.w, R3.w;
MUL R1.xyz, R3.w, R1;
DP3 R1.x, R3, R1;
MOV R3.w, c[4];
MUL R1.y, R3.w, c[3].x;
MAX R1.x, R1, c[4];
POW R1.x, R1.x, R1.y;
MUL R2.w, R1.x, R2;
DP3 R1.x, R3, R0;
MUL R0.xyz, R2, c[2];
SLT R2.x, c[4], fragment.texcoord[3].z;
MUL R0.w, R2.x, R0;
MUL R0.w, R0, R1;
MUL R0.xyz, R0, c[0];
MAX R1.x, R1, c[4];
MUL R1.xyz, R0, R1.x;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R0.w, R0, c[4].y;
MAD R0.xyz, R0, R2.w, R1;
MUL result.color.xyz, R0, R0.w;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "SPOT" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
SetTexture 3 [_LightTextureB0] 2D 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0.50000000, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3
rcp r2.x, t3.w
mad r3.xy, t3, r2.x, c5.y
mov r0.y, t0.w
mov r0.x, t0.z
mov r1.xy, r0
dp3 r0.x, t3, t3
mov r2.xy, r0.x
texld r6, r2, s3
texld r1, r1, s1
texld r2, t0, s0
texld r0, r3, s2
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3_pp r1.x, t2, t2
mul_pp r2.xyz, r2, c2
mov r0.y, r1
mov r0.x, r1.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
mov_pp r0.x, c3
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r4, r1
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r5.x, r1.x, r0.x
dp3_pp r1.x, r4, r3
mov r0.x, r5.x
mul r0.x, r0, r2.w
mov_pp r3.xyz, c0
max_pp r1.x, r1, c4.w
mul_pp r2.xyz, r2, c0
mul_pp r2.xyz, r2, r1.x
cmp r1.x, -t3.z, c4.w, c4.z
mul_pp r1.x, r1, r0.w
mul_pp r1.x, r1, r6
mul_pp r3.xyz, c1, r3
mul_pp r1.x, r1, c4
mad r0.xyz, r3, r0.x, r2
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "SPOT" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_BumpMap] 2D 3
SetTexture 2 [_LightTexture0] 2D 0
SetTexture 3 [_LightTextureB0] 2D 1
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedelbeikfjfeafpajajjdedofgkcbkiehkabaaaaaaiaagaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefchiafaaaaeaaaaaaafoabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fibiaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadpcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaacaaaaaaegbcbaaaacaaaaaa
eeaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahocaabaaaaaaaaaaa
fgafbaaaaaaaaaaaagbjbaaaacaaaaaadcaaaaajhcaabaaaabaaaaaaegbcbaaa
adaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
adaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaea
aaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaa
apaaaaahbcaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaibcaabaaa
aaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaa
acaaaaaaakaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaajgahbaaa
aaaaaaaadeaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaaiecaabaaaaaaaaaaaakiacaaaaaaaaaaaamaaaaaaabeaaaaaaaaaaaed
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaalaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadiaaaaajhcaabaaaacaaaaaaegiccaaa
aaaaaaaaabaaaaaaegiccaaaaaaaaaaaacaaaaaadiaaaaahncaabaaaaaaaaaaa
agaabaaaaaaaaaaaagajbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaa
abaaaaaafgafbaaaaaaaaaaaigadbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaa
egbabaaaaeaaaaaapgbpbaaaaeaaaaaaaaaaaaakdcaabaaaabaaaaaaegaabaaa
abaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegaabaaaabaaaaaaeghobaaaacaaaaaaaagabaaaaaaaaaaadbaaaaah
icaabaaaaaaaaaaaabeaaaaaaaaaaaaackbabaaaaeaaaaaaabaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdiaaaaahicaabaaaaaaaaaaa
dkaabaaaabaaaaaadkaabaaaaaaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaa
aeaaaaaaegbcbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaaagaabaaaabaaaaaa
eghobaaaadaaaaaaaagabaaaabaaaaaaapaaaaahicaabaaaaaaaaaaapgapbaaa
aaaaaaaaagaabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "SPOT" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_BumpMap] 2D 3
SetTexture 2 [_LightTexture0] 2D 0
SetTexture 3 [_LightTextureB0] 2D 1
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedhcebkmfpkannnlemcmbehbfmgpbkmibnabaaaaaaoiajaaaaaeaaaaaa
daaaaaaajeadaaaabeajaaaaleajaaaaebgpgodjfmadaaaafmadaaaaaaacpppp
baadaaaaemaaaaaaacaadeaaaaaaemaaaaaaemaaaeaaceaaaaaaemaaacaaaaaa
adababaaaaacacaaabadadaaaaaaabaaacaaaaaaaaaaaaaaaaaaalaaacaaacaa
aaaaaaaaaaacppppfbaaaaafaeaaapkaaaaaaaeaaaaaialpaaaaaaaaaaaaiadp
fbaaaaafafaaapkaaaaaaadpaaaaaaedaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaaaplabpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaaiaacaachlabpaaaaac
aaaaaaiaadaaaplabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapka
bpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkaaiaaaaadaaaaciia
acaaoelaacaaoelaahaaaaacaaaacbiaaaaappiaceaaaaacabaachiaabaaoela
aeaaaaaeaaaachiaacaaoelaaaaaaaiaabaaoeiaceaaaaacacaachiaaaaaoeia
abaaaaacaaaaabiaaaaakklaabaaaaacaaaaaciaaaaapplaagaaaaacabaaaiia
adaapplaaeaaaaaeadaaadiaadaaoelaabaappiaafaaaakaaiaaaaadabaaaiia
adaaoelaadaaoelaabaaaaacaeaaadiaabaappiaecaaaaadaaaacpiaaaaaoeia
adaioekaecaaaaadafaacpiaaaaaoelaacaioekaecaaaaadadaacpiaadaaoeia
aaaioekaecaaaaadaeaacpiaaeaaoeiaabaioekaaeaaaaaeadaacbiaaaaappia
aeaaaakaaeaaffkaaeaaaaaeadaacciaaaaaffiaaeaaaakaaeaaffkafkaaaaae
abaadiiaadaaoeiaadaaoeiaaeaakkkaacaaaaadabaaciiaabaappibaeaappka
ahaaaaacabaaciiaabaappiaagaaaaacadaaceiaabaappiaaiaaaaadabaaciia
adaaoeiaacaaoeiaaiaaaaadaaaacbiaadaaoeiaabaaoeiaalaaaaadabaacbia
aaaaaaiaaeaakkkaalaaaaadaaaaabiaabaappiaaeaakkkaabaaaaacaaaaacia
afaaffkaafaaaaadaaaaaciaaaaaffiaadaaaakacaaaaaadabaaaciaaaaaaaia
aaaaffiaafaaaaadafaaaiiaafaappiaabaaffiaafaaaaadaaaachiaafaaoeia
acaaoekaafaaaaadaaaachiaaaaaoeiaaaaaoekaabaaaaacacaaahiaaaaaoeka
afaaaaadabaaaoiaacaabliaabaablkaafaaaaadabaaaoiaafaappiaabaaoeia
aeaaaaaeaaaaahiaaaaaoeiaabaaaaiaabaabliaafaaaaadaaaaciiaadaappia
aeaaaaiafiaaaaaeaaaaciiaadaakklbaeaakkkaaaaappiaacaaaaadaaaaaiia
aaaappiaaaaappiaafaaaaadaaaachiaaaaappiaaaaaoeiaabaaaaacaaaaaiia
aeaakkkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefchiafaaaaeaaaaaaa
foabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafkaaaaadaagabaaa
adaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaafibiaaaeaahabaaaadaaaaaa
ffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaad
hcbabaaaadaaaaaagcbaaaadpcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaa
giaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaaegbcbaaa
adaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaabaaaaaahccaabaaa
aaaaaaaaegbcbaaaacaaaaaaegbcbaaaacaaaaaaeeaaaaafccaabaaaaaaaaaaa
bkaabaaaaaaaaaaadiaaaaahocaabaaaaaaaaaaafgafbaaaaaaaaaaaagbjbaaa
acaaaaaadcaaaaajhcaabaaaabaaaaaaegbcbaaaadaaaaaaagaabaaaaaaaaaaa
jgahbaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaa
abaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
abaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaadaaaaaadcaaaaapdcaabaaa
acaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaa
aceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahbcaabaaaaaaaaaaa
egaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaahbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaaaaaaiadpaaaaaaaibcaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaacaaaaaaakaabaaaaaaaaaaa
baaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaabaaaaaah
ccaabaaaaaaaaaaaegacbaaaacaaaaaajgahbaaaaaaaaaaadeaaaaakdcaabaaa
aaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaiecaabaaaaaaaaaaa
akiacaaaaaaaaaaaamaaaaaaabeaaaaaaaaaaaeddiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaa
abaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaa
abaaaaaadiaaaaajhcaabaaaacaaaaaaegiccaaaaaaaaaaaabaaaaaaegiccaaa
aaaaaaaaacaaaaaadiaaaaahncaabaaaaaaaaaaaagaabaaaaaaaaaaaagajbaaa
acaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaafgafbaaaaaaaaaaa
igadbaaaaaaaaaaaaoaaaaahdcaabaaaabaaaaaaegbabaaaaeaaaaaapgbpbaaa
aeaaaaaaaaaaaaakdcaabaaaabaaaaaaegaabaaaabaaaaaaaceaaaaaaaaaaadp
aaaaaadpaaaaaaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegaabaaaabaaaaaa
eghobaaaacaaaaaaaagabaaaaaaaaaaadbaaaaahicaabaaaaaaaaaaaabeaaaaa
aaaaaaaackbabaaaaeaaaaaaabaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaaaaaiadpdiaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaa
aaaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaaeaaaaaaegbcbaaaaeaaaaaa
efaaaaajpcaabaaaabaaaaaaagaabaaaabaaaaaaeghobaaaadaaaaaaaagabaaa
abaaaaaaapaaaaahicaabaaaaaaaaaaapgapbaaaaaaaaaaaagaabaaaabaaaaaa
diaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahahaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R2, fragment.texcoord[0], texture[0], 2D;
TEX R1.w, fragment.texcoord[3], texture[3], CUBE;
MAD R3.xy, R3.wyzw, c[4].y, -c[4].z;
DP3 R0.x, fragment.texcoord[3], fragment.texcoord[3];
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD_SAT R3.z, R3, R3.w;
DP3 R1.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R3.z, -R3, c[4];
RSQ R3.z, R3.z;
RCP R3.z, R3.z;
RSQ R1.x, R1.x;
MOV result.color.w, c[4].x;
TEX R0.w, R0.x, texture[2], 2D;
DP3 R0.x, fragment.texcoord[1], fragment.texcoord[1];
RSQ R0.x, R0.x;
MUL R0.xyz, R0.x, fragment.texcoord[1];
MAD R1.xyz, R1.x, fragment.texcoord[2], R0;
DP3 R3.w, R1, R1;
RSQ R3.w, R3.w;
MUL R1.xyz, R3.w, R1;
DP3 R1.x, R3, R1;
MOV R3.w, c[4];
MUL R0.w, R0, R1;
MUL R1.y, R3.w, c[3].x;
MAX R1.x, R1, c[4];
POW R1.x, R1.x, R1.y;
MUL R2.w, R1.x, R2;
DP3 R1.x, R3, R0;
MUL R0.xyz, R2, c[2];
MUL R0.xyz, R0, c[0];
MAX R1.x, R1, c[4];
MUL R1.xyz, R0, R1.x;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R0.w, R0, c[4].y;
MAD R0.xyz, R0, R2.w, R1;
MUL result.color.xyz, R0, R0.w;
END
# 38 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "POINT_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTextureB0] 2D 2
SetTexture 3 [_LightTexture0] CUBE 3
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_cube s3
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xyz
texld r2, t0, s0
dp3 r0.x, t3, t3
mov r0.xy, r0.x
mul_pp r2.xyz, r2, c2
mov r1.y, t0.w
mov r1.x, t0.z
mul_pp r2.xyz, r2, c0
texld r6, r0, s2
texld r1, r1, s1
texld r0, t3, s3
dp3_pp r1.x, t1, t1
rsq_pp r3.x, r1.x
dp3_pp r1.x, t2, t2
mov r0.y, r1
mov r0.x, r1.w
mad_pp r4.xy, r0, c4.x, c4.y
mul_pp r0.xy, r4, r4
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r4.z, r0.x
mov_pp r0.x, c3
mul_pp r3.xyz, r3.x, t1
rsq_pp r1.x, r1.x
mad_pp r5.xyz, r1.x, t2, r3
dp3_pp r1.x, r5, r5
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r5
dp3_pp r1.x, r4, r1
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r5.x, r1.x, r0.x
dp3_pp r1.x, r4, r3
max_pp r1.x, r1, c4.w
mov r0.x, r5.x
mul r0.x, r0, r2.w
mov_pp r3.xyz, c0
mul_pp r2.xyz, r2, r1.x
mul r1.x, r6, r0.w
mul_pp r3.xyz, c1, r3
mul_pp r1.x, r1, c4
mad r0.xyz, r3, r0.x, r2
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "POINT_COOKIE" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_BumpMap] 2D 3
SetTexture 2 [_LightTextureB0] 2D 1
SetTexture 3 [_LightTexture0] CUBE 0
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedblpdoankanndjfebmojocgdifefdigllabaaaaaaoiafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcoaaeaaaaeaaaaaaadiabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fidaaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaacaaaaaaegbcbaaaacaaaaaa
eeaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahocaabaaaaaaaaaaa
fgafbaaaaaaaaaaaagbjbaaaacaaaaaadcaaaaajhcaabaaaabaaaaaaegbcbaaa
adaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
adaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaea
aaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaa
apaaaaahbcaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaibcaabaaa
aaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaa
acaaaaaaakaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaajgahbaaa
aaaaaaaadeaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaaiecaabaaaaaaaaaaaakiacaaaaaaaaaaaamaaaaaaabeaaaaaaaaaaaed
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaalaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadiaaaaajhcaabaaaacaaaaaaegiccaaa
aaaaaaaaabaaaaaaegiccaaaaaaaaaaaacaaaaaadiaaaaahncaabaaaaaaaaaaa
agaabaaaaaaaaaaaagajbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaa
abaaaaaafgafbaaaaaaaaaaaigadbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaapgapbaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
egbcbaaaaeaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaagaabaaaabaaaaaapgapbaaaacaaaaaadiaaaaahhccabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "POINT_COOKIE" }
SetTexture 0 [_MainTex] 2D 2
SetTexture 1 [_BumpMap] 2D 3
SetTexture 2 [_LightTextureB0] 2D 1
SetTexture 3 [_LightTexture0] CUBE 0
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedpibkjeehfkngjbldanhabhkcdjobllaaabaaaaaabmajaaaaaeaaaaaa
daaaaaaagaadaaaaeiaiaaaaoiaiaaaaebgpgodjciadaaaaciadaaaaaaacpppp
nmacaaaaemaaaaaaacaadeaaaaaaemaaaaaaemaaaeaaceaaaaaaemaaadaaaaaa
acababaaaaacacaaabadadaaaaaaabaaacaaaaaaaaaaaaaaaaaaalaaacaaacaa
aaaaaaaaaaacppppfbaaaaafaeaaapkaaaaaaaeaaaaaialpaaaaaaaaaaaaiadp
fbaaaaafafaaapkaaaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaia
aaaaaplabpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaaiaacaachlabpaaaaac
aaaaaaiaadaaahlabpaaaaacaaaaaajiaaaiapkabpaaaaacaaaaaajaabaiapka
bpaaaaacaaaaaajaacaiapkabpaaaaacaaaaaajaadaiapkaaiaaaaadaaaaciia
acaaoelaacaaoelaahaaaaacaaaacbiaaaaappiaceaaaaacabaachiaabaaoela
aeaaaaaeaaaachiaacaaoelaaaaaaaiaabaaoeiaceaaaaacacaachiaaaaaoeia
abaaaaacaaaaabiaaaaakklaabaaaaacaaaaaciaaaaapplaaiaaaaadabaaaiia
adaaoelaadaaoelaabaaaaacadaaadiaabaappiaecaaaaadaaaacpiaaaaaoeia
adaioekaecaaaaadaeaacpiaaaaaoelaacaioekaecaaaaadadaaapiaadaaoeia
abaioekaecaaaaadafaaapiaadaaoelaaaaioekaaeaaaaaeafaacbiaaaaappia
aeaaaakaaeaaffkaaeaaaaaeafaacciaaaaaffiaaeaaaakaaeaaffkafkaaaaae
abaadiiaafaaoeiaafaaoeiaaeaakkkaacaaaaadabaaciiaabaappibaeaappka
ahaaaaacabaaciiaabaappiaagaaaaacafaaceiaabaappiaaiaaaaadabaaciia
afaaoeiaacaaoeiaaiaaaaadaaaacbiaafaaoeiaabaaoeiaalaaaaadabaacbia
aaaaaaiaaeaakkkaalaaaaadaaaaabiaabaappiaaeaakkkaabaaaaacacaaabia
adaaaakaafaaaaadaaaaaciaacaaaaiaafaaaakacaaaaaadabaaaciaaaaaaaia
aaaaffiaafaaaaadaeaaaiiaaeaappiaabaaffiaafaaaaadaaaachiaaeaaoeia
acaaoekaafaaaaadaaaachiaaaaaoeiaaaaaoekaabaaaaacacaaahiaaaaaoeka
afaaaaadabaaaoiaacaabliaabaablkaafaaaaadabaaaoiaaeaappiaabaaoeia
aeaaaaaeaaaaahiaaaaaoeiaabaaaaiaabaabliaafaaaaadaaaaciiaadaaaaia
afaappiaacaaaaadaaaaaiiaaaaappiaaaaappiaafaaaaadaaaachiaaaaappia
aaaaoeiaabaaaaacaaaaciiaaeaakkkaabaaaaacaaaicpiaaaaaoeiappppaaaa
fdeieefcoaaeaaaaeaaaaaaadiabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafkaaaaadaagabaaaadaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaa
fidaaaaeaahabaaaadaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaad
hcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaadhcbabaaaaeaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaa
egbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaabaaaaaahccaabaaaaaaaaaaaegbcbaaaacaaaaaaegbcbaaaacaaaaaa
eeaaaaafccaabaaaaaaaaaaabkaabaaaaaaaaaaadiaaaaahocaabaaaaaaaaaaa
fgafbaaaaaaaaaaaagbjbaaaacaaaaaadcaaaaajhcaabaaaabaaaaaaegbcbaaa
adaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaa
egacbaaaabaaaaaaegacbaaaabaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaa
aaaaaaaadiaaaaahhcaabaaaabaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
adaaaaaadcaaaaapdcaabaaaacaaaaaahgapbaaaacaaaaaaaceaaaaaaaaaaaea
aaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaa
apaaaaahbcaabaaaaaaaaaaaegaabaaaacaaaaaaegaabaaaacaaaaaaddaaaaah
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaibcaabaaa
aaaaaaaaakaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaa
acaaaaaaakaabaaaaaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaajgahbaaa
aaaaaaaadeaaaaakdcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
diaaaaaiecaabaaaaaaaaaaaakiacaaaaaaaaaaaamaaaaaaabeaaaaaaaaaaaed
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaaf
bcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaacaaaaaadiaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaalaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaa
abaaaaaaegiccaaaaaaaaaaaabaaaaaadiaaaaajhcaabaaaacaaaaaaegiccaaa
aaaaaaaaabaaaaaaegiccaaaaaaaaaaaacaaaaaadiaaaaahncaabaaaaaaaaaaa
agaabaaaaaaaaaaaagajbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaa
abaaaaaafgafbaaaaaaaaaaaigadbaaaaaaaaaaabaaaaaahicaabaaaaaaaaaaa
egbcbaaaaeaaaaaaegbcbaaaaeaaaaaaefaaaaajpcaabaaaabaaaaaapgapbaaa
aaaaaaaaeghobaaaacaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
egbcbaaaaeaaaaaaeghobaaaadaaaaaaaagabaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaagaabaaaabaaaaaapgapbaaaacaaaaaadiaaaaahhccabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaa
aaaaaaaadoaaaaabejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaa
abaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
abaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaahahaaaa
imaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaaadaaaaaa
aaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaafeeffied
epepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaa
aaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0, 2, 1, 128 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEX R0, fragment.texcoord[0], texture[0], 2D;
TEX R1.yw, fragment.texcoord[0].zwzw, texture[1], 2D;
TEX R2.w, fragment.texcoord[3], texture[2], 2D;
MAD R1.xy, R1.wyzw, c[4].y, -c[4].z;
MUL R1.zw, R1.xyxy, R1.xyxy;
ADD_SAT R1.z, R1, R1.w;
DP3 R3.x, fragment.texcoord[2], fragment.texcoord[2];
ADD R1.z, -R1, c[4];
RSQ R1.z, R1.z;
RCP R1.z, R1.z;
MUL R0.xyz, R0, c[2];
MOV R2.xyz, fragment.texcoord[1];
RSQ R3.x, R3.x;
MAD R2.xyz, R3.x, fragment.texcoord[2], R2;
DP3 R1.w, R2, R2;
RSQ R1.w, R1.w;
MUL R2.xyz, R1.w, R2;
DP3 R2.x, R1, R2;
MOV R1.w, c[4];
MUL R2.y, R1.w, c[3].x;
MAX R1.w, R2.x, c[4].x;
POW R1.w, R1.w, R2.y;
MUL R0.w, R1, R0;
DP3 R1.w, R1, fragment.texcoord[1];
MUL R1.xyz, R0, c[0];
MAX R1.w, R1, c[4].x;
MUL R1.xyz, R1, R1.w;
MOV R0.xyz, c[1];
MUL R0.xyz, R0, c[0];
MUL R1.w, R2, c[4].y;
MAD R0.xyz, R0, R0.w, R1;
MUL result.color.xyz, R0, R1.w;
MOV result.color.w, c[4].x;
END
# 33 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL_COOKIE" }
Vector 0 [_LightColor0]
Vector 1 [_SpecColor]
Vector 2 [_Color]
Float 3 [_Shininess]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
SetTexture 2 [_LightTexture0] 2D 2
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c4, 2.00000000, -1.00000000, 1.00000000, 0.00000000
def c5, 128.00000000, 0, 0, 0
dcl t0
dcl t1.xyz
dcl t2.xyz
dcl t3.xy
texld r2, t0, s0
mul_pp r2.xyz, r2, c2
mov r0.y, t0.w
mov r0.x, t0.z
mov r1.xy, r0
mul_pp r2.xyz, r2, c0
mov_pp r4.xyz, t1
texld r1, r1, s1
texld r0, t3, s2
dp3_pp r1.x, t2, t2
rsq_pp r1.x, r1.x
mad_pp r4.xyz, r1.x, t2, r4
dp3_pp r1.x, r4, r4
mov r0.y, r1
mov r0.x, r1.w
mad_pp r3.xy, r0, c4.x, c4.y
mul_pp r0.xy, r3, r3
add_pp_sat r0.x, r0, r0.y
add_pp r0.x, -r0, c4.z
rsq_pp r0.x, r0.x
rcp_pp r3.z, r0.x
rsq_pp r1.x, r1.x
mul_pp r1.xyz, r1.x, r4
dp3_pp r1.x, r3, r1
mov_pp r0.x, c3
mul_pp r0.x, c5, r0
max_pp r1.x, r1, c4.w
pow r4.x, r1.x, r0.x
dp3_pp r1.x, r3, t1
max_pp r1.x, r1, c4.w
mul_pp r3.xyz, r2, r1.x
mov r0.x, r4.x
mul r0.x, r0, r2.w
mul_pp r1.x, r0.w, c4
mov_pp r2.xyz, c0
mul_pp r2.xyz, c1, r2
mad r0.xyz, r2, r0.x, r3
mul r0.xyz, r0, r1.x
mov_pp r0.w, c4
mov_pp oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL_COOKIE" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_BumpMap] 2D 2
SetTexture 2 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedkdhbkkllllgkcgikelmdnllkjpichngjabaaaaaaeaafaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefcdiaeaaaaeaaaaaaaaoabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaa
gcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaaddcbabaaa
aeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaadaaaaaaegbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadcaaaaajhcaabaaaaaaaaaaaegbcbaaaadaaaaaaagaabaaa
aaaaaaaaegbcbaaaacaaaaaabaaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaa
egacbaaaaaaaaaaaeeaaaaaficaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaah
hcaabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaadcaaaaap
dcaabaaaabaaaaaahgapbaaaabaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaa
aaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaa
aaaaaaaaegaabaaaabaaaaaaegaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaa
aaaaaaaabaaaaaahbcaabaaaaaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaa
baaaaaahccaabaaaaaaaaaaaegacbaaaabaaaaaaegbcbaaaacaaaaaadeaaaaak
dcaabaaaaaaaaaaaegaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaacpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaiecaabaaa
aaaaaaaaakiacaaaaaaaaaaaamaaaaaaabeaaaaaaaaaaaeddiaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaackaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaa
aaaaaaaaaagabaaaabaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
dkaabaaaabaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaalaaaaaadiaaaaaihcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaa
aaaaaaaaabaaaaaadiaaaaajhcaabaaaacaaaaaaegiccaaaaaaaaaaaabaaaaaa
egiccaaaaaaaaaaaacaaaaaadiaaaaahncaabaaaaaaaaaaaagaabaaaaaaaaaaa
agajbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaabaaaaaafgafbaaa
aaaaaaaaigadbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaaeaaaaaa
eghobaaaacaaaaaaaagabaaaaaaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaa
abaaaaaadkaabaaaabaaaaaadiaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaa
egacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaab
"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL_COOKIE" }
SetTexture 0 [_MainTex] 2D 1
SetTexture 1 [_BumpMap] 2D 2
SetTexture 2 [_LightTexture0] 2D 0
ConstBuffer "$Globals" 240
Vector 16 [_LightColor0]
Vector 32 [_SpecColor]
Vector 176 [_Color]
Float 192 [_Shininess]
BindCB  "$Globals" 0
"ps_4_0_level_9_1
eefiecedcejffjnkgdmmfeohjgjoahfajneblpdbabaaaaaaciaiaaaaaeaaaaaa
daaaaaaabeadaaaafeahaaaapeahaaaaebgpgodjnmacaaaanmacaaaaaaacpppp
jeacaaaaeiaaaaaaacaadaaaaaaaeiaaaaaaeiaaadaaceaaaaaaeiaaacaaaaaa
aaababaaabacacaaaaaaabaaacaaaaaaaaaaaaaaaaaaalaaacaaacaaaaaaaaaa
aaacppppfbaaaaafaeaaapkaaaaaaaeaaaaaialpaaaaaaaaaaaaiadpfbaaaaaf
afaaapkaaaaaaaedaaaaaaaaaaaaaaaaaaaaaaaabpaaaaacaaaaaaiaaaaaapla
bpaaaaacaaaaaaiaabaachlabpaaaaacaaaaaaiaacaachlabpaaaaacaaaaaaia
adaaadlabpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkabpaaaaac
aaaaaajaacaiapkaaiaaaaadaaaaciiaacaaoelaacaaoelaahaaaaacaaaacbia
aaaappiaabaaaaacabaaahiaacaaoelaaeaaaaaeaaaachiaabaaoeiaaaaaaaia
abaaoelaceaaaaacabaachiaaaaaoeiaabaaaaacaaaaabiaaaaakklaabaaaaac
aaaaaciaaaaapplaecaaaaadaaaacpiaaaaaoeiaacaioekaecaaaaadacaacpia
aaaaoelaabaioekaecaaaaadadaacpiaadaaoelaaaaioekaaeaaaaaeadaacbia
aaaappiaaeaaaakaaeaaffkaaeaaaaaeadaacciaaaaaffiaaeaaaakaaeaaffka
fkaaaaaeabaadiiaadaaoeiaadaaoeiaaeaakkkaacaaaaadabaaciiaabaappib
aeaappkaahaaaaacabaaciiaabaappiaagaaaaacadaaceiaabaappiaaiaaaaad
aaaacbiaadaaoeiaabaaoeiaaiaaaaadaaaacciaadaaoeiaabaaoelaalaaaaad
abaacbiaaaaaffiaaeaakkkaalaaaaadabaaaciaaaaaaaiaaeaakkkaabaaaaac
aaaaabiaadaaaakaafaaaaadaaaaabiaaaaaaaiaafaaaakacaaaaaadadaaabia
abaaffiaaaaaaaiaafaaaaadacaaaiiaacaappiaadaaaaiaafaaaaadaaaachia
acaaoeiaacaaoekaafaaaaadaaaachiaaaaaoeiaaaaaoekaabaaaaacacaaahia
aaaaoekaafaaaaadabaaaoiaacaabliaabaablkaafaaaaadabaaaoiaacaappia
abaaoeiaaeaaaaaeaaaaahiaaaaaoeiaabaaaaiaabaabliaacaaaaadaaaaaiia
adaappiaadaappiaafaaaaadaaaachiaaaaappiaaaaaoeiaabaaaaacaaaaciia
aeaakkkaabaaaaacaaaicpiaaaaaoeiappppaaaafdeieefcdiaeaaaaeaaaaaaa
aoabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaaacaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaafibiaaaeaahabaaa
acaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadhcbabaaaacaaaaaa
gcbaaaadhcbabaaaadaaaaaagcbaaaaddcbabaaaaeaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacadaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaadaaaaaa
egbcbaaaadaaaaaaeeaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaaj
hcaabaaaaaaaaaaaegbcbaaaadaaaaaaagaabaaaaaaaaaaaegbcbaaaacaaaaaa
baaaaaahicaabaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaaaaaaaaaeeaaaaaf
icaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaa
eghobaaaabaaaaaaaagabaaaacaaaaaadcaaaaapdcaabaaaabaaaaaahgapbaaa
abaaaaaaaceaaaaaaaaaaaeaaaaaaaeaaaaaaaaaaaaaaaaaaceaaaaaaaaaialp
aaaaialpaaaaaaaaaaaaaaaaapaaaaahicaabaaaaaaaaaaaegaabaaaabaaaaaa
egaabaaaabaaaaaaddaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaa
aaaaiadpaaaaaaaiicaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaaabeaaaaa
aaaaiadpelaaaaafecaabaaaabaaaaaadkaabaaaaaaaaaaabaaaaaahbcaabaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaabaaaaaahccaabaaaaaaaaaaa
egacbaaaabaaaaaaegbcbaaaacaaaaaadeaaaaakdcaabaaaaaaaaaaaegaabaaa
aaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaacpaaaaafbcaabaaa
aaaaaaaaakaabaaaaaaaaaaadiaaaaaiecaabaaaaaaaaaaaakiacaaaaaaaaaaa
amaaaaaaabeaaaaaaaaaaaeddiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
ckaabaaaaaaaaaaabjaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
diaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaadkaabaaaabaaaaaadiaaaaai
hcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaalaaaaaadiaaaaai
hcaabaaaabaaaaaaegacbaaaabaaaaaaegiccaaaaaaaaaaaabaaaaaadiaaaaaj
hcaabaaaacaaaaaaegiccaaaaaaaaaaaabaaaaaaegiccaaaaaaaaaaaacaaaaaa
diaaaaahncaabaaaaaaaaaaaagaabaaaaaaaaaaaagajbaaaacaaaaaadcaaaaaj
hcaabaaaaaaaaaaaegacbaaaabaaaaaafgafbaaaaaaaaaaaigadbaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaaeaaaaaaeghobaaaacaaaaaaaagabaaa
aaaaaaaaaaaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaadkaabaaaabaaaaaa
diaaaaahhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaaaaaaaaaadgaaaaaf
iccabaaaaaaaaaaaabeaaaaaaaaaaaaadoaaaaabejfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahahaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaadadaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaa
aiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfe
gbhcghgfheaaklkl"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassBase" "RenderType"="Opaque" }
  Fog { Mode Off }
Program "vp" {
SubProgram "opengl " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_ProjMat]
Vector 13 [unity_Scale]
Vector 14 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.modelview[0],
		program.local[5..14] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R0, c[2];
MOV R1, c[1];
MUL R2, R0, c[12].y;
MAD R3, R1, c[12].x, R2;
MOV R2, c[3];
MAD R4, R2, c[12].z, R3;
MOV R3, c[4];
MAD R4, R3, c[12].w, R4;
MUL R5, R0, c[11].y;
MAD R5, R1, c[11].x, R5;
DP4 result.position.w, R4, vertex.position;
MUL R4, R0, c[10].y;
MAD R4, R1, c[10].x, R4;
MAD R5, R2, c[11].z, R5;
MAD R4, R2, c[10].z, R4;
MAD R4, R3, c[10].w, R4;
MAD R5, R3, c[11].w, R5;
DP4 result.position.y, vertex.position, R4;
MUL R0, R0, c[9].y;
MAD R0, R1, c[9].x, R0;
MOV R4.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R4.yzxw;
MAD R0, R2, c[9].z, R0;
MAD R0, R3, c[9].w, R0;
DP4 result.position.x, vertex.position, R0;
MAD R1.xyz, vertex.normal.yzxw, R4.zxyw, -R1;
MUL R1.xyz, R1, vertex.attrib[14].w;
DP3 R0.y, R1, c[5];
DP3 R0.x, vertex.attrib[14], c[5];
DP3 R0.z, vertex.normal, c[5];
MUL result.texcoord[1].xyz, R0, c[13].w;
DP3 R0.y, R1, c[6];
DP3 R0.x, vertex.attrib[14], c[6];
DP3 R0.z, vertex.normal, c[6];
MUL result.texcoord[2].xyz, R0, c[13].w;
DP3 R0.y, R1, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
DP4 result.position.z, vertex.position, R5;
MUL result.texcoord[3].xyz, R0, c[13].w;
MAD result.texcoord[0].xy, vertex.texcoord[0], c[14], c[14].zwzw;
END
# 41 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_ProjMat]
Vector 12 [unity_Scale]
Vector 13 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.xyz, v1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r1
mul r0.xyz, r0, v1.w
dp3 r1.y, r0, c4
dp3 r1.x, v1, c4
dp3 r1.z, v2, c4
mul o2.xyz, r1, c12.w
dp3 r1.y, r0, c5
dp3 r0.y, r0, c6
dp3 r1.x, v1, c5
dp3 r1.z, v2, c5
mov r0.w, c11.y
mul o3.xyz, r1, c12.w
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o4.xyz, r0, c12.w
mul r1, c1, r0.w
mov r0.x, c11
mad r1, c0, r0.x, r1
mov r0.x, c11.z
mad r1, c2, r0.x, r1
mov r0.x, c11.w
mad r1, c3, r0.x, r1
mov r0.x, c10.y
dp4 o0.w, r1, v0
mul r1, c1, r0.x
mov r0.x, c10
mad r1, c0, r0.x, r1
mov r0.x, c10.z
mad r1, c2, r0.x, r1
mov r0.x, c10.w
mad r1, c3, r0.x, r1
mov r0.x, c9.y
dp4 o0.z, v0, r1
mul r1, c1, r0.x
mov r0.x, c9
mad r1, c0, r0.x, r1
mov r0.x, c9.z
mad r1, c2, r0.x, r1
mov r0.y, c9.w
mad r1, c3, r0.y, r1
mov r0.x, c8.y
mov r2.x, c8
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c8.z
mad r0, c2, r2.x, r0
mov r2.x, c8.w
mad r0, c3, r2.x, r0
dp4 o0.y, v0, r1
dp4 o0.x, v0, r0
mad o1.xy, v3, c13, c13.zwzw
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 208
Matrix 48 [_ProjMat]
Vector 192 [_BumpMap_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedoipildabgndleliealpgagllddbcleejabaaaaaaciaiaaaaadaaaaaa
cmaaaaaapeaaaaaajeabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheojiaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaahaiaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
ahaiaaaaimaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefcimagaaaaeaaaabaa
kdabaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaa
bfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaad
hcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaaghaaaaaepccabaaaaaaaaaaa
abaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadhccabaaaacaaaaaagfaaaaad
hccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaacadaaaaaadiaaaaaj
pcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaafaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaa
afaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaa
afaaaaaakgikcaaaabaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaafaaaaaaegaobaaa
aaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaa
aeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
abaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaabaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaa
aeaaaaaafgifcaaaabaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaadaaaaaaagiacaaaabaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaabaaaaaaagaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaa
pgipcaaaabaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaabaaaaaaahaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaabaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaabaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaabaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaajpccabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaa
amaaaaaaogikcaaaaaaaaaaaamaaaaaadiaaaaahhcaabaaaaaaaaaaajgbebaaa
abaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaaaaaaaaajgbebaaaacaaaaaa
cgbjbaaaabaaaaaaegacbaiaebaaaaaaaaaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaapgbpbaaaabaaaaaadgaaaaagbcaabaaaabaaaaaaakiacaaa
abaaaaaaamaaaaaadgaaaaagccaabaaaabaaaaaaakiacaaaabaaaaaaanaaaaaa
dgaaaaagecaabaaaabaaaaaaakiacaaaabaaaaaaaoaaaaaabaaaaaahccaabaaa
acaaaaaaegacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaaacaaaaaa
egbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaa
acaaaaaaegacbaaaabaaaaaadiaaaaaihccabaaaacaaaaaaegacbaaaacaaaaaa
pgipcaaaabaaaaaabeaaaaaadgaaaaagbcaabaaaabaaaaaabkiacaaaabaaaaaa
amaaaaaadgaaaaagccaabaaaabaaaaaabkiacaaaabaaaaaaanaaaaaadgaaaaag
ecaabaaaabaaaaaabkiacaaaabaaaaaaaoaaaaaabaaaaaahccaabaaaacaaaaaa
egacbaaaaaaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaaacaaaaaaegbcbaaa
abaaaaaaegacbaaaabaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaaacaaaaaa
egacbaaaabaaaaaadiaaaaaihccabaaaadaaaaaaegacbaaaacaaaaaapgipcaaa
abaaaaaabeaaaaaadgaaaaagbcaabaaaabaaaaaackiacaaaabaaaaaaamaaaaaa
dgaaaaagccaabaaaabaaaaaackiacaaaabaaaaaaanaaaaaadgaaaaagecaabaaa
abaaaaaackiacaaaabaaaaaaaoaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaabaaaaaa
egacbaaaabaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaacaaaaaaegacbaaa
abaaaaaadiaaaaaihccabaaaaeaaaaaaegacbaaaaaaaaaaapgipcaaaabaaaaaa
beaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
Float 0 [_Shininess]
Float 1 [_MetalShininess]
Float 2 [_SkinShininess]
Float 3 [_ClothShininess]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[5] = { program.local[0..3],
		{ 0.5, 2, 1 } };
TEMP R0;
TEMP R1;
TEX R0.yzw, fragment.texcoord[0], texture[0], 2D;
SGE R1.xyz, R0.yzww, c[4].x;
TEX R0.yw, fragment.texcoord[0], texture[1], 2D;
MOV R0.z, c[0].x;
ADD R1.w, -R0.z, c[3].x;
MAD R0.xy, R0.wyzw, c[4].y, -c[4].z;
MUL R0.zw, R0.xyxy, R0.xyxy;
MAD R1.z, R1, R1.w, c[0].x;
ADD_SAT R0.w, R0.z, R0;
ADD R0.z, -R1, c[2].x;
ADD R1.w, -R0, c[4].z;
MAD R0.w, R1.y, R0.z, R1.z;
ADD R1.y, -R0.w, c[1].x;
RSQ R0.z, R1.w;
RCP R0.z, R0.z;
MAD result.color.w, R1.x, R1.y, R0;
DP3 R1.z, fragment.texcoord[3], R0;
DP3 R1.x, R0, fragment.texcoord[1];
DP3 R1.y, R0, fragment.texcoord[2];
MAD result.color.xyz, R1, c[4].x, c[4].x;
END
# 20 instructions, 2 R-regs
"
}
SubProgram "d3d9 " {
Float 0 [_Shininess]
Float 1 [_MetalShininess]
Float 2 [_SkinShininess]
Float 3 [_ClothShininess]
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c4, -0.50000000, 1.00000000, 0.00000000, 0.50000000
def c5, 2.00000000, -1.00000000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xyz
dcl_texcoord2 v2.xyz
dcl_texcoord3 v3.xyz
texld r0.yzw, v0, s0
add r0.xyz, r0.yzww, c4.x
cmp r1.xyz, r0, c4.y, c4.z
texld r0.yw, v0, s1
mov_pp r0.z, c3.x
add_pp r1.w, -c0.x, r0.z
mad_pp r0.xy, r0.wyzw, c5.x, c5.y
mul_pp r0.zw, r0.xyxy, r0.xyxy
mad_pp r1.z, r1, r1.w, c0.x
add_pp_sat r0.w, r0.z, r0
add_pp r0.z, -r1, c2.x
add_pp r1.w, -r0, c4.y
mad_pp r0.w, r1.y, r0.z, r1.z
add_pp r1.y, -r0.w, c1.x
rsq_pp r0.z, r1.w
rcp_pp r0.z, r0.z
mad_pp oC0.w, r1.x, r1.y, r0
dp3 r1.z, v3, r0
dp3 r1.x, r0, v1
dp3 r1.y, r0, v2
mad_pp oC0.xyz, r1, c4.w, c4.w
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MaskTex] 2D 0
SetTexture 1 [_BumpMap] 2D 1
ConstBuffer "$Globals" 208
Float 176 [_Shininess]
Float 180 [_MetalShininess]
Float 184 [_SkinShininess]
Float 188 [_ClothShininess]
BindCB  "$Globals" 0
"ps_4_0
eefiecedeapjdhaldffkgddephdedofkhgkgkjcmabaaaaaafaaeaaaaadaaaaaa
cmaaaaaammaaaaaaaaabaaaaejfdeheojiaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaahahaaaaimaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahahaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaklklklepfdeheocmaaaaaaabaaaaaaaiaaaaaacaaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgfheaaklkl
fdeieefceiadaaaaeaaaaaaancaaaaaafjaaaaaeegiocaaaaaaaaaaaamaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaaddcbabaaa
abaaaaaagcbaaaadhcbabaaaacaaaaaagcbaaaadhcbabaaaadaaaaaagcbaaaad
hcbabaaaaeaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaa
dcaaaaapdcaabaaaaaaaaaaahgapbaaaaaaaaaaaaceaaaaaaaaaaaeaaaaaaaea
aaaaaaaaaaaaaaaaaceaaaaaaaaaialpaaaaialpaaaaaaaaaaaaaaaaapaaaaah
icaabaaaaaaaaaaaegaabaaaaaaaaaaaegaabaaaaaaaaaaaddaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpaaaaaaaiicaabaaaaaaaaaaa
dkaabaiaebaaaaaaaaaaaaaaabeaaaaaaaaaiadpelaaaaafecaabaaaaaaaaaaa
dkaabaaaaaaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaacaaaaaaegacbaaa
aaaaaaaabaaaaaahccaabaaaabaaaaaaegbcbaaaadaaaaaaegacbaaaaaaaaaaa
baaaaaahecaabaaaabaaaaaaegbcbaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaap
hccabaaaaaaaaaaaegacbaaaabaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadp
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaadpaaaaaaaaaaaaaaakbcaabaaa
aaaaaaaaakiacaiaebaaaaaaaaaaaaaaalaaaaaadkiacaaaaaaaaaaaalaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaabnaaaaakocaabaaaaaaaaaaafgaobaaaabaaaaaaaceaaaaaaaaaaaaa
aaaaaadpaaaaaadpaaaaaadpabaaaaakocaabaaaaaaaaaaafgaobaaaaaaaaaaa
aceaaaaaaaaaaaaaaaaaiadpaaaaiadpaaaaiadpdcaaaaakbcaabaaaaaaaaaaa
dkaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaaalaaaaaaaaaaaaaj
icaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaalaaaaaa
dcaaaaajbcaabaaaaaaaaaaackaabaaaaaaaaaaadkaabaaaaaaaaaaaakaabaaa
aaaaaaaaaaaaaaajecaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaabkiacaaa
aaaaaaaaalaaaaaadcaaaaajiccabaaaaaaaaaaabkaabaaaaaaaaaaackaabaaa
aaaaaaaaakaabaaaaaaaaaaadoaaaaab"
}
}
 }
 Pass {
  Name "PREPASS"
  Tags { "LIGHTMODE"="PrePassFinal" "RenderType"="Opaque" }
  ZWrite Off
Program "vp" {
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[15].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[13].y;
MAD R5, R2, c[15].x, R5;
MUL R3, R3, c[14].y;
MAD R4, R2, c[13].x, R4;
MAD R2, R2, c[14].x, R3;
MAD R3, R1, c[13].z, R4;
MAD R2, R1, c[14].z, R2;
MAD R3, R0, c[13].w, R3;
MAD R2, R0, c[14].w, R2;
MAD R1, R1, c[15].z, R5;
MAD R0, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R0;
MUL R1.xyz, vertex.normal, c[26].w;
DP4 R6.y, vertex.position, R2;
DP4 R6.x, vertex.position, R3;
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R2.w, R1, c[6];
MUL R2.y, R2, c[18].x;
DP3 R0.x, R1, c[5];
MOV R0.y, R2.w;
DP3 R0.z, R1, c[7];
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.z, R0, c[21];
DP4 R2.y, R0, c[20];
DP4 R2.x, R0, c[19];
MUL R0.y, R2.w, R2.w;
MAD R0.x, R0, R0, -R0.y;
MOV R2.w, c[0].y;
DP4 R3.z, R1, c[24];
DP4 R3.x, R1, c[22];
DP4 R3.y, R1, c[23];
ADD R2.xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[5].xyz, R2, R0;
MUL R3.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R3;
MUL R0.xyz, vertex.attrib[14].w, R1;
MOV R2.xyz, c[17];
DP4 R1.z, R2, c[11];
DP4 R1.x, R2, c[9];
DP4 R1.y, R2, c[10];
MAD R1.xyz, R1, c[26].w, -vertex.position;
DP3 R2.y, R0, c[5];
DP3 R2.w, -R1, c[5];
DP3 R2.x, vertex.attrib[14], c[5];
DP3 R2.z, vertex.normal, c[5];
MUL result.texcoord[2], R2, c[26].w;
DP3 R2.y, R0, c[6];
DP3 R0.y, R0, c[7];
DP3 R2.w, -R1, c[6];
DP3 R2.x, vertex.attrib[14], c[6];
DP3 R2.z, vertex.normal, c[6];
DP3 R0.w, -R1, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MUL result.texcoord[3], R2, c[26].w;
MUL result.texcoord[4], R0, c[26].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 74 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c29.x
mul r2.xyz, v2, c26.w
mul r0.y, r0, c17.x
mad o2.xy, r0.z, c18.zwzw, r0
dp3 r1.z, r2, c5
dp3 r0.x, r2, c4
mov r0.y, r1.z
dp3 r0.z, r2, c6
mov r0.w, c29.y
mul r2, r0.xyzz, r0.yzzx
dp4 r3.z, r0, c21
dp4 r3.y, r0, c20
dp4 r3.x, r0, c19
dp4 r0.w, r2, c24
dp4 r0.z, r2, c23
dp4 r0.y, r2, c22
add r2.xyz, r3, r0.yzww
mul r0.y, r1.z, r1.z
mad r1.z, r0.x, r0.x, -r0.y
mov r2.w, c14.y
mov r0.z, c14.x
mul r3, c1, r2.w
mad r3, c0, r0.z, r3
mov r0.x, c14.z
mad r0, c2, r0.x, r3
mul r3.xyz, r1.z, c25
mov r1.z, c14.w
mad r0, c3, r1.z, r0
dp4 r1.z, v0, r0
mov r0.w, c29.y
mov r0.xyz, v1
add o6.xyz, r2, r3
mul r2.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r2
mov o0, r1
mov o2.zw, r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c16
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c26.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c26.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c26.w
dp3 r0.y, r1, c6
dp3 r0.w, -r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c26.w
mad o1.zw, v3.xyxy, c28.xyxy, c28
mad o1.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 256
Matrix 48 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecednjhnpcilenkfhamhjiphplnipdifmnceabaaaaaalmamaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcpaakaaaaeaaaabaalmacaaaafjaaaaaeegiocaaaaaaaaaaa
apaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaac
aeaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
adaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
fgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaa
ahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
adaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaanaaaaaa
ogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaaiccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaa
abaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadp
dgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaacaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
dcaaaaalhcaabaaaaaaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaa
abaaaaaafgafbaiaebaaaaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaal
lcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaallcaabaaaaaaaaaaaegiicaaaadaaaaaaaoaaaaaa
kgakbaiaebaaaaaaaaaaaaaaegambaaaaaaaaaaadgaaaaaficaabaaaabaaaaaa
akaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaa
pgbpbaaaabaaaaaadgaaaaagbcaabaaaadaaaaaaakiacaaaadaaaaaaamaaaaaa
dgaaaaagccaabaaaadaaaaaaakiacaaaadaaaaaaanaaaaaadgaaaaagecaabaaa
adaaaaaaakiacaaaadaaaaaaaoaaaaaabaaaaaahccaabaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaadaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaabaaaaaa
egacbaaaadaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaaacaaaaaaegacbaaa
adaaaaaadiaaaaaipccabaaaadaaaaaaegaobaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaadgaaaaaficaabaaaabaaaaaabkaabaaaaaaaaaaadgaaaaagbcaabaaa
adaaaaaabkiacaaaadaaaaaaamaaaaaadgaaaaagccaabaaaadaaaaaabkiacaaa
adaaaaaaanaaaaaadgaaaaagecaabaaaadaaaaaabkiacaaaadaaaaaaaoaaaaaa
baaaaaahccaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaabaaaaaah
bcaabaaaabaaaaaaegbcbaaaabaaaaaaegacbaaaadaaaaaabaaaaaahecaabaaa
abaaaaaaegbcbaaaacaaaaaaegacbaaaadaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaabaaaaaapgipcaaaadaaaaaabeaaaaaadgaaaaagbcaabaaaabaaaaaa
ckiacaaaadaaaaaaamaaaaaadgaaaaagccaabaaaabaaaaaackiacaaaadaaaaaa
anaaaaaadgaaaaagecaabaaaabaaaaaackiacaaaadaaaaaaaoaaaaaabaaaaaah
ccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaahecaabaaaaaaaaaaa
egbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaa
aaaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
adaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaa
acaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MAD R5, R1, c[13].z, R5;
MAD R4, R1, c[14].z, R4;
MAD R4, R0, c[14].w, R4;
MAD R5, R0, c[13].w, R5;
MUL R3, R3, c[15].y;
MAD R2, R2, c[15].x, R3;
MAD R1, R1, c[15].z, R2;
MAD R1, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R0.xyz, vertex.attrib[14].w, R0;
MOV R2.xyz, c[17];
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[11];
DP4 R1.x, R2, c[9];
DP4 R1.y, R2, c[10];
MAD R1.xyz, R1, c[20].w, -vertex.position;
DP3 R2.y, R0, c[5];
DP4 R6.y, vertex.position, R4;
DP4 R6.x, vertex.position, R5;
MUL R4.xyz, R6.xyww, c[0].x;
MUL R4.y, R4, c[18].x;
DP3 R2.w, -R1, c[5];
DP3 R2.x, vertex.attrib[14], c[5];
DP3 R2.z, vertex.normal, c[5];
MUL result.texcoord[2], R2, c[20].w;
DP3 R2.y, R0, c[6];
DP3 R2.w, -R1, c[6];
DP3 R2.x, vertex.attrib[14], c[6];
DP3 R2.z, vertex.normal, c[6];
MUL result.texcoord[3], R2, c[20].w;
DP3 R2.y, R0, c[7];
DP3 R2.w, -R1, c[7];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD R0.xyz, R0, -c[19];
MUL result.texcoord[6].xyz, R0, c[19].w;
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[19].w;
DP4 R0.x, vertex.position, c[3];
DP3 R2.x, vertex.attrib[14], c[7];
DP3 R2.z, vertex.normal, c[7];
ADD result.texcoord[1].xy, R4, R4.z;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MUL result.texcoord[4], R2, c[20].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[23].xyxy, c[23];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[22], c[22].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[21], c[21].zwzw;
MUL result.texcoord[6].w, -R0.x, R0.y;
END
# 66 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c24, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r0.w, r0, v0
mov r1.x, c12.y
mov r0.x, c12
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.y, c12.w
mad r2, c3, r0.y, r1
mov r0.x, c13.y
mul r1, c1, r0.x
mov r0.x, c13
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r2
dp4 r0.y, v0, r1
mul r2.xyz, r0.xyww, c24.x
mov r0.z, c14.y
mul r2.y, r2, c17.x
mul r1, c1, r0.z
mov r0.z, c14.x
mad r1, c0, r0.z, r1
mov r0.z, c14
mad r1, c2, r0.z, r1
mov r0.z, c14.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mov r1.xyz, v1
mad o2.xy, r2.z, c18.zwzw, r2
mul r2.xyz, v2.zxyw, r1.yzxw
mov r1.xyz, v1
mad r1.xyz, v2.yzxw, r1.zxyw, -r2
mul r1.xyz, v1.w, r1
mov o0, r0
mov o2.zw, r0
mov r0.xyz, c16
mov r0.w, c24.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c20.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c20.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c20.w
dp3 r0.y, r1, c6
dp3 r0.x, v1, c6
dp3 r0.w, -r2, c6
dp3 r0.z, v2, c6
mul o5, r0, c20.w
mov r0.x, c19.w
add r0.y, c24, -r0.x
dp4 r0.x, v0, c2
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
add r1.xyz, r1, -c19
mul o7.xyz, r1, c19.w
mad o1.zw, v3.xyxy, c23.xyxy, c23
mad o1.xy, v3, c22, c22.zwzw
mad o6.xy, v4, c21, c21.zwzw
mul o7.w, -r0.x, r0.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedekeloddakofabkhoahbphkopnglcdlgbabaaaaaamiamaaaaadaaaaaa
cmaaaaaapeaaaaaanmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheooaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaneaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaneaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaneaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaadamaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
oeakaaaaeaaaabaaljacaaaafjaaaaaeegiocaaaaaaaaaaabaaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabkaaaaaafjaaaaae
egiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaa
abaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaad
dcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaaddccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaajpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
adaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
agaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaoaaaaaaogikcaaaaaaaaaaaaoaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaapaaaaaakgiocaaa
aaaaaaaaapaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaa
aaaaaaaaaaaaaaahdccabaaaacaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaa
bbaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaa
abaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaa
adaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaal
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaia
ebaaaaaaaaaaaaaadiaaaaajhcaabaaaabaaaaaafgafbaiaebaaaaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaallcaabaaaaaaaaaaaegiicaaaadaaaaaa
amaaaaaaagaabaiaebaaaaaaaaaaaaaaegaibaaaabaaaaaadcaaaaallcaabaaa
aaaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaaaaaaaaaaegambaaa
aaaaaaaadgaaaaaficaabaaaabaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
acaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaa
jgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaacaaaaaadiaaaaah
hcaabaaaacaaaaaaegacbaaaacaaaaaapgbpbaaaabaaaaaadgaaaaagbcaabaaa
adaaaaaaakiacaaaadaaaaaaamaaaaaadgaaaaagccaabaaaadaaaaaaakiacaaa
adaaaaaaanaaaaaadgaaaaagecaabaaaadaaaaaaakiacaaaadaaaaaaaoaaaaaa
baaaaaahccaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaabaaaaaah
bcaabaaaabaaaaaaegbcbaaaabaaaaaaegacbaaaadaaaaaabaaaaaahecaabaaa
abaaaaaaegbcbaaaacaaaaaaegacbaaaadaaaaaadiaaaaaipccabaaaadaaaaaa
egaobaaaabaaaaaapgipcaaaadaaaaaabeaaaaaadgaaaaaficaabaaaabaaaaaa
bkaabaaaaaaaaaaadgaaaaagbcaabaaaadaaaaaabkiacaaaadaaaaaaamaaaaaa
dgaaaaagccaabaaaadaaaaaabkiacaaaadaaaaaaanaaaaaadgaaaaagecaabaaa
adaaaaaabkiacaaaadaaaaaaaoaaaaaabaaaaaahccaabaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaadaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaabaaaaaa
egacbaaaadaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaaacaaaaaaegacbaaa
adaaaaaadiaaaaaipccabaaaaeaaaaaaegaobaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaadgaaaaagbcaabaaaabaaaaaackiacaaaadaaaaaaamaaaaaadgaaaaag
ccaabaaaabaaaaaackiacaaaadaaaaaaanaaaaaadgaaaaagecaabaaaabaaaaaa
ckiacaaaadaaaaaaaoaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaabaaaaaaegacbaaa
abaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaa
diaaaaaipccabaaaafaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dcaaaaaldccabaaaagaaaaaaegbabaaaaeaaaaaaegiacaaaaaaaaaaaanaaaaaa
ogikcaaaaaaaaaaaanaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaa
acaaaaaabjaaaaaadiaaaaaihccabaaaahaaaaaaegacbaaaaaaaaaaapgipcaaa
acaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaa
adaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaa
akbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaaacaaaaaabjaaaaaaabeaaaaa
aaaaiadpdiaaaaaiiccabaaaahaaaaaabkaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_Scale]
Vector 20 [unity_LightmapST]
Vector 21 [_MainTex_ST]
Vector 22 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[23] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..22] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R4, R2, c[14].x, R4;
MAD R5, R2, c[13].x, R5;
MUL R3, R3, c[15].y;
MAD R4, R1, c[14].z, R4;
MAD R4, R0, c[14].w, R4;
MAD R5, R1, c[13].z, R5;
MAD R2, R2, c[15].x, R3;
MAD R1, R1, c[15].z, R2;
MAD R5, R0, c[13].w, R5;
MAD R0, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R0;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R2.xyz, c[17];
MOV R2.w, c[0].y;
DP4 R0.z, R2, c[11];
DP4 R0.x, R2, c[9];
DP4 R0.y, R2, c[10];
MAD R0.xyz, R0, c[19].w, -vertex.position;
DP3 R2.y, R1, c[5];
DP4 R6.y, vertex.position, R4;
DP4 R6.x, vertex.position, R5;
MUL R4.xyz, R6.xyww, c[0].x;
DP3 result.texcoord[6].y, R1, R0;
DP3 R2.w, -R0, c[5];
DP3 R2.x, vertex.attrib[14], c[5];
DP3 R2.z, vertex.normal, c[5];
MUL result.texcoord[2], R2, c[19].w;
DP3 R2.y, R1, c[6];
DP3 R1.y, R1, c[7];
MOV R3.x, R4;
MUL R3.y, R4, c[18].x;
DP3 R2.w, -R0, c[6];
DP3 R2.x, vertex.attrib[14], c[6];
DP3 R2.z, vertex.normal, c[6];
DP3 R1.w, -R0, c[7];
DP3 R1.x, vertex.attrib[14], c[7];
DP3 R1.z, vertex.normal, c[7];
ADD result.texcoord[1].xy, R3, R4.z;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MUL result.texcoord[3], R2, c[19].w;
MUL result.texcoord[4], R1, c[19].w;
DP3 result.texcoord[6].z, vertex.normal, R0;
DP3 result.texcoord[6].x, vertex.attrib[14], R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[22].xyxy, c[22];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[21], c[21].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[20], c[20].zwzw;
END
# 61 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_Scale]
Vector 20 [unity_LightmapST]
Vector 21 [_MainTex_ST]
Vector 22 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c23, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r2.w, r0, v0
mov r1.x, c12.y
mov r0.x, c12
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.y, c12.w
mad r1, c3, r0.y, r1
mov r0.x, c13.y
mov r2.x, c13
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c13.z
mad r0, c2, r2.x, r0
mov r2.x, c13.w
mad r0, c3, r2.x, r0
dp4 r2.y, v0, r0
dp4 r2.x, v0, r1
mul r1.xyz, r2.xyww, c23.x
mul r1.y, r1, c17.x
mov r0.xyz, v1
mad o2.xy, r1.z, c18.zwzw, r1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, v1.w, r1
mov r0.x, c14.y
mov r1.x, c14
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c14.z
mad r0, c2, r1.x, r0
mov r1.x, c14.w
mad r1, c3, r1.x, r0
dp4 r2.z, v0, r1
mov r0.xyz, c16
mov r0.w, c23.y
dp3 r1.y, r3, c4
dp3 r1.x, v1, c4
dp3 r1.z, v2, c4
dp4 r4.z, r0, c10
dp4 r4.x, r0, c8
dp4 r4.y, r0, c9
mad r0.xyz, r4, c19.w, -v0
dp3 r1.w, -r0, c4
mul o3, r1, c19.w
dp3 r1.y, r3, c5
dp3 r1.w, -r0, c5
dp3 r1.x, v1, c5
dp3 r1.z, v2, c5
mul o4, r1, c19.w
dp3 r1.y, r3, c6
dp3 r1.w, -r0, c6
dp3 r1.x, v1, c6
dp3 r1.z, v2, c6
dp3 o7.y, r3, r0
mov o0, r2
mov o2.zw, r2
mul o5, r1, c19.w
dp3 o7.z, v2, r0
dp3 o7.x, v1, r0
mad o1.zw, v3.xyxy, c22.xyxy, c22
mad o1.xy, v3, c21, c21.zwzw
mad o6.xy, v4, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedhhmjegmemmklgphakjniohofpkpclbcjabaaaaaafealaaaaadaaaaaa
cmaaaaaapeaaaaaanmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheooaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaneaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaneaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaneaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaadamaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
haajaaaaeaaaabaafmacaaaafjaaaaaeegiocaaaaaaaaaaabaaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaa
afaaaaaagfaaaaaddccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaac
afaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
acaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaa
afaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
fgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaacaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
acaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaagaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
acaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaa
ahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
acaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaiccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaa
abaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadp
dgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaacaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaa
egiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
dcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaacaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaa
abaaaaaafgafbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaal
hcaabaaaabaaaaaaegiccaaaacaaaaaaamaaaaaaagaabaiaebaaaaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaallcaabaaaabaaaaaaegiicaaaacaaaaaaaoaaaaaa
kgakbaiaebaaaaaaaaaaaaaaegaibaaaabaaaaaadgaaaaaficaabaaaacaaaaaa
akaabaaaabaaaaaadiaaaaahhcaabaaaadaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaaadaaaaaaegacbaaaadaaaaaa
pgbpbaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakiacaaaacaaaaaaamaaaaaa
dgaaaaagccaabaaaaeaaaaaaakiacaaaacaaaaaaanaaaaaadgaaaaagecaabaaa
aeaaaaaaakiacaaaacaaaaaaaoaaaaaabaaaaaahccaabaaaacaaaaaaegacbaaa
adaaaaaaegacbaaaaeaaaaaabaaaaaahbcaabaaaacaaaaaaegbcbaaaabaaaaaa
egacbaaaaeaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaa
aeaaaaaadiaaaaaipccabaaaadaaaaaaegaobaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaadgaaaaaficaabaaaacaaaaaabkaabaaaabaaaaaadgaaaaagbcaabaaa
aeaaaaaabkiacaaaacaaaaaaamaaaaaadgaaaaagccaabaaaaeaaaaaabkiacaaa
acaaaaaaanaaaaaadgaaaaagecaabaaaaeaaaaaabkiacaaaacaaaaaaaoaaaaaa
baaaaaahccaabaaaacaaaaaaegacbaaaadaaaaaaegacbaaaaeaaaaaabaaaaaah
bcaabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaaeaaaaaabaaaaaahecaabaaa
acaaaaaaegbcbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaacaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaagbcaabaaaacaaaaaa
ckiacaaaacaaaaaaamaaaaaadgaaaaagccaabaaaacaaaaaackiacaaaacaaaaaa
anaaaaaadgaaaaagecaabaaaacaaaaaackiacaaaacaaaaaaaoaaaaaabaaaaaah
ccaabaaaabaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaabaaaaaahcccabaaa
ahaaaaaaegacbaaaadaaaaaaegacbaaaaaaaaaaabaaaaaahbcaabaaaabaaaaaa
egbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaa
acaaaaaaegacbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaabaaaaaa
pgipcaaaacaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaaeaaaaaa
egiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaabaaaaaahbccabaaa
ahaaaaaaegbcbaaaabaaaaaaegacbaaaaaaaaaaabaaaaaaheccabaaaahaaaaaa
egbcbaaaacaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[29] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..28] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[15].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[13].y;
MAD R5, R2, c[15].x, R5;
MUL R3, R3, c[14].y;
MAD R4, R2, c[13].x, R4;
MAD R2, R2, c[14].x, R3;
MAD R3, R1, c[13].z, R4;
MAD R2, R1, c[14].z, R2;
MAD R3, R0, c[13].w, R3;
MAD R2, R0, c[14].w, R2;
MAD R1, R1, c[15].z, R5;
MAD R0, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R0;
MUL R1.xyz, vertex.normal, c[26].w;
DP4 R6.y, vertex.position, R2;
DP4 R6.x, vertex.position, R3;
MUL R2.xyz, R6.xyww, c[0].x;
DP3 R2.w, R1, c[6];
MUL R2.y, R2, c[18].x;
DP3 R0.x, R1, c[5];
MOV R0.y, R2.w;
DP3 R0.z, R1, c[7];
MUL R1, R0.xyzz, R0.yzzx;
MOV R0.w, c[0].y;
ADD result.texcoord[1].xy, R2, R2.z;
DP4 R2.z, R0, c[21];
DP4 R2.y, R0, c[20];
DP4 R2.x, R0, c[19];
MUL R0.y, R2.w, R2.w;
MAD R0.x, R0, R0, -R0.y;
MOV R2.w, c[0].y;
DP4 R3.z, R1, c[24];
DP4 R3.x, R1, c[22];
DP4 R3.y, R1, c[23];
ADD R2.xyz, R2, R3;
MOV R1.xyz, vertex.attrib[14];
MUL R0.xyz, R0.x, c[25];
ADD result.texcoord[5].xyz, R2, R0;
MUL R3.xyz, vertex.normal.zxyw, R1.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R1.zxyw, -R3;
MUL R0.xyz, vertex.attrib[14].w, R1;
MOV R2.xyz, c[17];
DP4 R1.z, R2, c[11];
DP4 R1.x, R2, c[9];
DP4 R1.y, R2, c[10];
MAD R1.xyz, R1, c[26].w, -vertex.position;
DP3 R2.y, R0, c[5];
DP3 R2.w, -R1, c[5];
DP3 R2.x, vertex.attrib[14], c[5];
DP3 R2.z, vertex.normal, c[5];
MUL result.texcoord[2], R2, c[26].w;
DP3 R2.y, R0, c[6];
DP3 R0.y, R0, c[7];
DP3 R2.w, -R1, c[6];
DP3 R2.x, vertex.attrib[14], c[6];
DP3 R2.z, vertex.normal, c[6];
DP3 R0.w, -R1, c[7];
DP3 R0.x, vertex.attrib[14], c[7];
DP3 R0.z, vertex.normal, c[7];
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MUL result.texcoord[3], R2, c[26].w;
MUL result.texcoord[4], R0, c[26].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[28].xyxy, c[28];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[27], c[27].zwzw;
END
# 74 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_SHAr]
Vector 20 [unity_SHAg]
Vector 21 [unity_SHAb]
Vector 22 [unity_SHBr]
Vector 23 [unity_SHBg]
Vector 24 [unity_SHBb]
Vector 25 [unity_SHC]
Vector 26 [unity_Scale]
Vector 27 [_MainTex_ST]
Vector 28 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c29, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r1.w, r0, v0
mov r1.x, c12.y
mul r2, c1, r1.x
mov r0.x, c12
mad r2, c0, r0.x, r2
mov r0.x, c12.z
mad r2, c2, r0.x, r2
mov r0.y, c12.w
mad r2, c3, r0.y, r2
mov r0.x, c13.y
mov r1.x, c13
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c13.z
mad r0, c2, r1.x, r0
mov r1.x, c13.w
mad r0, c3, r1.x, r0
dp4 r1.x, v0, r2
dp4 r1.y, v0, r0
mul r0.xyz, r1.xyww, c29.x
mul r2.xyz, v2, c26.w
mul r0.y, r0, c17.x
mad o2.xy, r0.z, c18.zwzw, r0
dp3 r1.z, r2, c5
dp3 r0.x, r2, c4
mov r0.y, r1.z
dp3 r0.z, r2, c6
mov r0.w, c29.y
mul r2, r0.xyzz, r0.yzzx
dp4 r3.z, r0, c21
dp4 r3.y, r0, c20
dp4 r3.x, r0, c19
dp4 r0.w, r2, c24
dp4 r0.z, r2, c23
dp4 r0.y, r2, c22
add r2.xyz, r3, r0.yzww
mul r0.y, r1.z, r1.z
mad r1.z, r0.x, r0.x, -r0.y
mov r2.w, c14.y
mov r0.z, c14.x
mul r3, c1, r2.w
mad r3, c0, r0.z, r3
mov r0.x, c14.z
mad r0, c2, r0.x, r3
mul r3.xyz, r1.z, c25
mov r1.z, c14.w
mad r0, c3, r1.z, r0
dp4 r1.z, v0, r0
mov r0.w, c29.y
mov r0.xyz, v1
add o6.xyz, r2, r3
mul r2.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r0.xyz, v2.yzxw, r0.zxyw, -r2
mov o0, r1
mov o2.zw, r1
mul r1.xyz, v1.w, r0
mov r0.xyz, c16
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c26.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c26.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c26.w
dp3 r0.y, r1, c6
dp3 r0.w, -r2, c6
dp3 r0.x, v1, c6
dp3 r0.z, v2, c6
mul o5, r0, c26.w
mad o1.zw, v3.xyxy, c28.xyxy, c28
mad o1.xy, v3, c27, c27.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 256
Matrix 48 [_ProjMat]
Vector 208 [_MainTex_ST]
Vector 224 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityLighting" 720
Vector 608 [unity_SHAr]
Vector 624 [unity_SHAg]
Vector 640 [unity_SHAb]
Vector 656 [unity_SHBr]
Vector 672 [unity_SHBg]
Vector 688 [unity_SHBb]
Vector 704 [unity_SHC]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityLighting" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecednjhnpcilenkfhamhjiphplnipdifmnceabaaaaaalmamaaaaadaaaaaa
cmaaaaaapeaaaaaameabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheomiaaaaaaahaaaaaa
aiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaalmaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaalmaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaalmaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfcee
aaklklklfdeieefcpaakaaaaeaaaabaalmacaaaafjaaaaaeegiocaaaaaaaaaaa
apaaaaaafjaaaaaeegiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaa
cnaaaaaafjaaaaaeegiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaa
adaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaa
gfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaa
aeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaadhccabaaaagaaaaaagiaaaaac
aeaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
adaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaa
afaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
fgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaadaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
adaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaagaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaa
ahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
adaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaanaaaaaa
ogikcaaaaaaaaaaaanaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaaoaaaaaakgiocaaaaaaaaaaaaoaaaaaadiaaaaaiccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaa
abaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadp
dgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaacaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaadaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaa
egiccaaaadaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
dcaaaaalhcaabaaaaaaaaaaaegiccaaaadaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaadaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaadaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaa
abaaaaaafgafbaiaebaaaaaaaaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaal
lcaabaaaaaaaaaaaegiicaaaadaaaaaaamaaaaaaagaabaiaebaaaaaaaaaaaaaa
egaibaaaabaaaaaadcaaaaallcaabaaaaaaaaaaaegiicaaaadaaaaaaaoaaaaaa
kgakbaiaebaaaaaaaaaaaaaaegambaaaaaaaaaaadgaaaaaficaabaaaabaaaaaa
akaabaaaaaaaaaaadiaaaaahhcaabaaaacaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaacaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaacaaaaaadiaaaaahhcaabaaaacaaaaaaegacbaaaacaaaaaa
pgbpbaaaabaaaaaadgaaaaagbcaabaaaadaaaaaaakiacaaaadaaaaaaamaaaaaa
dgaaaaagccaabaaaadaaaaaaakiacaaaadaaaaaaanaaaaaadgaaaaagecaabaaa
adaaaaaaakiacaaaadaaaaaaaoaaaaaabaaaaaahccaabaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaadaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaabaaaaaa
egacbaaaadaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaaacaaaaaaegacbaaa
adaaaaaadiaaaaaipccabaaaadaaaaaaegaobaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaadgaaaaaficaabaaaabaaaaaabkaabaaaaaaaaaaadgaaaaagbcaabaaa
adaaaaaabkiacaaaadaaaaaaamaaaaaadgaaaaagccaabaaaadaaaaaabkiacaaa
adaaaaaaanaaaaaadgaaaaagecaabaaaadaaaaaabkiacaaaadaaaaaaaoaaaaaa
baaaaaahccaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaabaaaaaah
bcaabaaaabaaaaaaegbcbaaaabaaaaaaegacbaaaadaaaaaabaaaaaahecaabaaa
abaaaaaaegbcbaaaacaaaaaaegacbaaaadaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaabaaaaaapgipcaaaadaaaaaabeaaaaaadgaaaaagbcaabaaaabaaaaaa
ckiacaaaadaaaaaaamaaaaaadgaaaaagccaabaaaabaaaaaackiacaaaadaaaaaa
anaaaaaadgaaaaagecaabaaaabaaaaaackiacaaaadaaaaaaaoaaaaaabaaaaaah
ccaabaaaaaaaaaaaegacbaaaacaaaaaaegacbaaaabaaaaaabaaaaaahbcaabaaa
aaaaaaaaegbcbaaaabaaaaaaegacbaaaabaaaaaabaaaaaahecaabaaaaaaaaaaa
egbcbaaaacaaaaaaegacbaaaabaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaa
aaaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaaaaaaaaaegbcbaaa
acaaaaaapgipcaaaadaaaaaabeaaaaaadiaaaaaihcaabaaaabaaaaaafgafbaaa
aaaaaaaaegiccaaaadaaaaaaanaaaaaadcaaaaaklcaabaaaaaaaaaaaegiicaaa
adaaaaaaamaaaaaaagaabaaaaaaaaaaaegaibaaaabaaaaaadcaaaaakhcaabaaa
aaaaaaaaegiccaaaadaaaaaaaoaaaaaakgakbaaaaaaaaaaaegadbaaaaaaaaaaa
dgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaiadpbbaaaaaibcaabaaaabaaaaaa
egiocaaaacaaaaaacgaaaaaaegaobaaaaaaaaaaabbaaaaaiccaabaaaabaaaaaa
egiocaaaacaaaaaachaaaaaaegaobaaaaaaaaaaabbaaaaaiecaabaaaabaaaaaa
egiocaaaacaaaaaaciaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaacaaaaaa
jgacbaaaaaaaaaaaegakbaaaaaaaaaaabbaaaaaibcaabaaaadaaaaaaegiocaaa
acaaaaaacjaaaaaaegaobaaaacaaaaaabbaaaaaiccaabaaaadaaaaaaegiocaaa
acaaaaaackaaaaaaegaobaaaacaaaaaabbaaaaaiecaabaaaadaaaaaaegiocaaa
acaaaaaaclaaaaaaegaobaaaacaaaaaaaaaaaaahhcaabaaaabaaaaaaegacbaaa
abaaaaaaegacbaaaadaaaaaadiaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaa
bkaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaa
aaaaaaaabkaabaiaebaaaaaaaaaaaaaadcaaaaakhccabaaaagaaaaaaegiccaaa
acaaaaaacmaaaaaaagaabaaaaaaaaaaaegacbaaaabaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[24] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..23] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R5, R2, c[13].x, R5;
MAD R4, R2, c[14].x, R4;
MAD R5, R1, c[13].z, R5;
MAD R4, R1, c[14].z, R4;
MAD R4, R0, c[14].w, R4;
MAD R5, R0, c[13].w, R5;
MUL R3, R3, c[15].y;
MAD R2, R2, c[15].x, R3;
MAD R1, R1, c[15].z, R2;
MAD R1, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R1;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R0.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R0.xyz, vertex.attrib[14].w, R0;
MOV R2.xyz, c[17];
MOV R2.w, c[0].y;
DP4 R1.z, R2, c[11];
DP4 R1.x, R2, c[9];
DP4 R1.y, R2, c[10];
MAD R1.xyz, R1, c[20].w, -vertex.position;
DP3 R2.y, R0, c[5];
DP4 R6.y, vertex.position, R4;
DP4 R6.x, vertex.position, R5;
MUL R4.xyz, R6.xyww, c[0].x;
MUL R4.y, R4, c[18].x;
DP3 R2.w, -R1, c[5];
DP3 R2.x, vertex.attrib[14], c[5];
DP3 R2.z, vertex.normal, c[5];
MUL result.texcoord[2], R2, c[20].w;
DP3 R2.y, R0, c[6];
DP3 R2.w, -R1, c[6];
DP3 R2.x, vertex.attrib[14], c[6];
DP3 R2.z, vertex.normal, c[6];
MUL result.texcoord[3], R2, c[20].w;
DP3 R2.y, R0, c[7];
DP3 R2.w, -R1, c[7];
DP4 R0.z, vertex.position, c[7];
DP4 R0.x, vertex.position, c[5];
DP4 R0.y, vertex.position, c[6];
ADD R0.xyz, R0, -c[19];
MUL result.texcoord[6].xyz, R0, c[19].w;
MOV R0.x, c[0].y;
ADD R0.y, R0.x, -c[19].w;
DP4 R0.x, vertex.position, c[3];
DP3 R2.x, vertex.attrib[14], c[7];
DP3 R2.z, vertex.normal, c[7];
ADD result.texcoord[1].xy, R4, R4.z;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MUL result.texcoord[4], R2, c[20].w;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[23].xyxy, c[23];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[22], c[22].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[21], c[21].zwzw;
MUL result.texcoord[6].w, -R0.x, R0.y;
END
# 66 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_ShadowFadeCenterAndType]
Vector 20 [unity_Scale]
Vector 21 [unity_LightmapST]
Vector 22 [_MainTex_ST]
Vector 23 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c24, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r0.w, r0, v0
mov r1.x, c12.y
mov r0.x, c12
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.y, c12.w
mad r2, c3, r0.y, r1
mov r0.x, c13.y
mul r1, c1, r0.x
mov r0.x, c13
mad r1, c0, r0.x, r1
mov r0.x, c13.z
mad r1, c2, r0.x, r1
mov r0.x, c13.w
mad r1, c3, r0.x, r1
dp4 r0.x, v0, r2
dp4 r0.y, v0, r1
mul r2.xyz, r0.xyww, c24.x
mov r0.z, c14.y
mul r2.y, r2, c17.x
mul r1, c1, r0.z
mov r0.z, c14.x
mad r1, c0, r0.z, r1
mov r0.z, c14
mad r1, c2, r0.z, r1
mov r0.z, c14.w
mad r1, c3, r0.z, r1
dp4 r0.z, v0, r1
mov r1.xyz, v1
mad o2.xy, r2.z, c18.zwzw, r2
mul r2.xyz, v2.zxyw, r1.yzxw
mov r1.xyz, v1
mad r1.xyz, v2.yzxw, r1.zxyw, -r2
mul r1.xyz, v1.w, r1
mov o0, r0
mov o2.zw, r0
mov r0.xyz, c16
mov r0.w, c24.y
dp4 r2.z, r0, c10
dp4 r2.x, r0, c8
dp4 r2.y, r0, c9
mad r2.xyz, r2, c20.w, -v0
dp3 r0.y, r1, c4
dp3 r0.w, -r2, c4
dp3 r0.x, v1, c4
dp3 r0.z, v2, c4
mul o3, r0, c20.w
dp3 r0.y, r1, c5
dp3 r0.w, -r2, c5
dp3 r0.x, v1, c5
dp3 r0.z, v2, c5
mul o4, r0, c20.w
dp3 r0.y, r1, c6
dp3 r0.x, v1, c6
dp3 r0.w, -r2, c6
dp3 r0.z, v2, c6
mul o5, r0, c20.w
mov r0.x, c19.w
add r0.y, c24, -r0.x
dp4 r0.x, v0, c2
dp4 r1.z, v0, c6
dp4 r1.x, v0, c4
dp4 r1.y, v0, c5
add r1.xyz, r1, -c19
mul o7.xyz, r1, c19.w
mad o1.zw, v3.xyxy, c23.xyxy, c23
mad o1.xy, v3, c22, c22.zwzw
mad o6.xy, v4, c21, c21.zwzw
mul o7.w, -r0.x, r0.y
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityShadows" 416
Vector 400 [unity_ShadowFadeCenterAndType]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityShadows" 2
BindCB  "UnityPerDraw" 3
"vs_4_0
eefiecedekeloddakofabkhoahbphkopnglcdlgbabaaaaaamiamaaaaadaaaaaa
cmaaaaaapeaaaaaanmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheooaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaneaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaneaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaneaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaadamaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaa
apaaaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
oeakaaaaeaaaabaaljacaaaafjaaaaaeegiocaaaaaaaaaaabaaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabkaaaaaafjaaaaae
egiocaaaadaaaaaabfaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaadpcbabaaa
abaaaaaafpaaaaadhcbabaaaacaaaaaafpaaaaaddcbabaaaadaaaaaafpaaaaad
dcbabaaaaeaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaa
abaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaad
pccabaaaaeaaaaaagfaaaaadpccabaaaafaaaaaagfaaaaaddccabaaaagaaaaaa
gfaaaaadpccabaaaahaaaaaagiaaaaacaeaaaaaadiaaaaajpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaafaaaaaadcaaaaalpcaabaaa
aaaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaafaaaaaaegaobaaa
aaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
adaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaadaaaaaaafaaaaaaegaobaaaaaaaaaaadiaaaaah
pcaabaaaaaaaaaaaegaobaaaaaaaaaaafgbfbaaaaaaaaaaadiaaaaajpcaabaaa
abaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaadaaaaaaaeaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaaeaaaaaa
egaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaa
kgikcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaaaeaaaaaaegaobaaaabaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaaagbabaaaaaaaaaaaegaobaaa
aaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
adaaaaaaagaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaadaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaaagaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaadaaaaaa
agaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaa
kgbkbaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaa
aaaaaaaaaeaaaaaafgifcaaaadaaaaaaahaaaaaadcaaaaalpcaabaaaabaaaaaa
egiocaaaaaaaaaaaadaaaaaaagiacaaaadaaaaaaahaaaaaaegaobaaaabaaaaaa
dcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaadaaaaaa
ahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
agaaaaaapgipcaaaadaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaaf
pccabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaa
adaaaaaaegiacaaaaaaaaaaaaoaaaaaaogikcaaaaaaaaaaaaoaaaaaadcaaaaal
mccabaaaabaaaaaaagbebaaaadaaaaaaagiecaaaaaaaaaaaapaaaaaakgiocaaa
aaaaaaaaapaaaaaadiaaaaaiccaabaaaaaaaaaaabkaabaaaaaaaaaaaakiacaaa
abaaaaaaafaaaaaadiaaaaakncaabaaaabaaaaaaagahbaaaaaaaaaaaaceaaaaa
aaaaaadpaaaaaaaaaaaaaadpaaaaaadpdgaaaaafmccabaaaacaaaaaakgaobaaa
aaaaaaaaaaaaaaahdccabaaaacaaaaaakgakbaaaabaaaaaamgaabaaaabaaaaaa
diaaaaajhcaabaaaaaaaaaaafgifcaaaabaaaaaaaeaaaaaaegiccaaaadaaaaaa
bbaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaaadaaaaaabaaaaaaaagiacaaa
abaaaaaaaeaaaaaaegacbaaaaaaaaaaadcaaaaalhcaabaaaaaaaaaaaegiccaaa
adaaaaaabcaaaaaakgikcaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaaaaaaaaai
hcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaaaadaaaaaabdaaaaaadcaaaaal
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaaegbcbaia
ebaaaaaaaaaaaaaadiaaaaajhcaabaaaabaaaaaafgafbaiaebaaaaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaallcaabaaaaaaaaaaaegiicaaaadaaaaaa
amaaaaaaagaabaiaebaaaaaaaaaaaaaaegaibaaaabaaaaaadcaaaaallcaabaaa
aaaaaaaaegiicaaaadaaaaaaaoaaaaaakgakbaiaebaaaaaaaaaaaaaaegambaaa
aaaaaaaadgaaaaaficaabaaaabaaaaaaakaabaaaaaaaaaaadiaaaaahhcaabaaa
acaaaaaajgbebaaaabaaaaaacgbjbaaaacaaaaaadcaaaaakhcaabaaaacaaaaaa
jgbebaaaacaaaaaacgbjbaaaabaaaaaaegacbaiaebaaaaaaacaaaaaadiaaaaah
hcaabaaaacaaaaaaegacbaaaacaaaaaapgbpbaaaabaaaaaadgaaaaagbcaabaaa
adaaaaaaakiacaaaadaaaaaaamaaaaaadgaaaaagccaabaaaadaaaaaaakiacaaa
adaaaaaaanaaaaaadgaaaaagecaabaaaadaaaaaaakiacaaaadaaaaaaaoaaaaaa
baaaaaahccaabaaaabaaaaaaegacbaaaacaaaaaaegacbaaaadaaaaaabaaaaaah
bcaabaaaabaaaaaaegbcbaaaabaaaaaaegacbaaaadaaaaaabaaaaaahecaabaaa
abaaaaaaegbcbaaaacaaaaaaegacbaaaadaaaaaadiaaaaaipccabaaaadaaaaaa
egaobaaaabaaaaaapgipcaaaadaaaaaabeaaaaaadgaaaaaficaabaaaabaaaaaa
bkaabaaaaaaaaaaadgaaaaagbcaabaaaadaaaaaabkiacaaaadaaaaaaamaaaaaa
dgaaaaagccaabaaaadaaaaaabkiacaaaadaaaaaaanaaaaaadgaaaaagecaabaaa
adaaaaaabkiacaaaadaaaaaaaoaaaaaabaaaaaahccaabaaaabaaaaaaegacbaaa
acaaaaaaegacbaaaadaaaaaabaaaaaahbcaabaaaabaaaaaaegbcbaaaabaaaaaa
egacbaaaadaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaaacaaaaaaegacbaaa
adaaaaaadiaaaaaipccabaaaaeaaaaaaegaobaaaabaaaaaapgipcaaaadaaaaaa
beaaaaaadgaaaaagbcaabaaaabaaaaaackiacaaaadaaaaaaamaaaaaadgaaaaag
ccaabaaaabaaaaaackiacaaaadaaaaaaanaaaaaadgaaaaagecaabaaaabaaaaaa
ckiacaaaadaaaaaaaoaaaaaabaaaaaahccaabaaaaaaaaaaaegacbaaaacaaaaaa
egacbaaaabaaaaaabaaaaaahbcaabaaaaaaaaaaaegbcbaaaabaaaaaaegacbaaa
abaaaaaabaaaaaahecaabaaaaaaaaaaaegbcbaaaacaaaaaaegacbaaaabaaaaaa
diaaaaaipccabaaaafaaaaaaegaobaaaaaaaaaaapgipcaaaadaaaaaabeaaaaaa
dcaaaaaldccabaaaagaaaaaaegbabaaaaeaaaaaaegiacaaaaaaaaaaaanaaaaaa
ogikcaaaaaaaaaaaanaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaa
egiccaaaadaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaadaaaaaa
amaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaadaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaadaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaa
aaaaaaaaaaaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaaegiccaiaebaaaaaa
acaaaaaabjaaaaaadiaaaaaihccabaaaahaaaaaaegacbaaaaaaaaaaapgipcaaa
acaaaaaabjaaaaaadiaaaaaibcaabaaaaaaaaaaabkbabaaaaaaaaaaackiacaaa
adaaaaaaafaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaaadaaaaaaaeaaaaaa
akbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaaaaaaaaaackiacaaa
adaaaaaaagaaaaaackbabaaaaaaaaaaaakaabaaaaaaaaaaadcaaaaakbcaabaaa
aaaaaaaackiacaaaadaaaaaaahaaaaaadkbabaaaaaaaaaaaakaabaaaaaaaaaaa
aaaaaaajccaabaaaaaaaaaaadkiacaiaebaaaaaaacaaaaaabjaaaaaaabeaaaaa
aaaaiadpdiaaaaaiiccabaaaahaaaaaabkaabaaaaaaaaaaaakaabaiaebaaaaaa
aaaaaaaadoaaaaab"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" ATTR14
Matrix 5 [_Object2World]
Matrix 9 [_World2Object]
Matrix 13 [_ProjMat]
Vector 17 [_WorldSpaceCameraPos]
Vector 18 [_ProjectionParams]
Vector 19 [unity_Scale]
Vector 20 [unity_LightmapST]
Vector 21 [_MainTex_ST]
Vector 22 [_BumpMap_ST]
"3.0-!!ARBvp1.0
PARAM c[23] = { { 0.5, 1 },
		state.matrix.modelview[0],
		program.local[5..22] };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEMP R6;
MOV R3, c[2];
MOV R2, c[1];
MUL R0, R3, c[16].y;
MUL R5, R3, c[13].y;
MOV R1, c[3];
MAD R0, R2, c[16].x, R0;
MAD R4, R1, c[16].z, R0;
MOV R0, c[4];
MAD R4, R0, c[16].w, R4;
DP4 R6.w, R4, vertex.position;
MUL R4, R3, c[14].y;
MAD R4, R2, c[14].x, R4;
MAD R5, R2, c[13].x, R5;
MUL R3, R3, c[15].y;
MAD R4, R1, c[14].z, R4;
MAD R4, R0, c[14].w, R4;
MAD R5, R1, c[13].z, R5;
MAD R2, R2, c[15].x, R3;
MAD R1, R1, c[15].z, R2;
MAD R5, R0, c[13].w, R5;
MAD R0, R0, c[15].w, R1;
DP4 R6.z, vertex.position, R0;
MOV R0.xyz, vertex.attrib[14];
MUL R1.xyz, vertex.normal.zxyw, R0.yzxw;
MAD R1.xyz, vertex.normal.yzxw, R0.zxyw, -R1;
MUL R1.xyz, vertex.attrib[14].w, R1;
MOV R2.xyz, c[17];
MOV R2.w, c[0].y;
DP4 R0.z, R2, c[11];
DP4 R0.x, R2, c[9];
DP4 R0.y, R2, c[10];
MAD R0.xyz, R0, c[19].w, -vertex.position;
DP3 R2.y, R1, c[5];
DP4 R6.y, vertex.position, R4;
DP4 R6.x, vertex.position, R5;
MUL R4.xyz, R6.xyww, c[0].x;
DP3 result.texcoord[6].y, R1, R0;
DP3 R2.w, -R0, c[5];
DP3 R2.x, vertex.attrib[14], c[5];
DP3 R2.z, vertex.normal, c[5];
MUL result.texcoord[2], R2, c[19].w;
DP3 R2.y, R1, c[6];
DP3 R1.y, R1, c[7];
MOV R3.x, R4;
MUL R3.y, R4, c[18].x;
DP3 R2.w, -R0, c[6];
DP3 R2.x, vertex.attrib[14], c[6];
DP3 R2.z, vertex.normal, c[6];
DP3 R1.w, -R0, c[7];
DP3 R1.x, vertex.attrib[14], c[7];
DP3 R1.z, vertex.normal, c[7];
ADD result.texcoord[1].xy, R3, R4.z;
MOV result.position, R6;
MOV result.texcoord[1].zw, R6;
MUL result.texcoord[3], R2, c[19].w;
MUL result.texcoord[4], R1, c[19].w;
DP3 result.texcoord[6].z, vertex.normal, R0;
DP3 result.texcoord[6].x, vertex.attrib[14], R0;
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[22].xyxy, c[22];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[21], c[21].zwzw;
MAD result.texcoord[5].xy, vertex.texcoord[1], c[20], c[20].zwzw;
END
# 61 instructions, 7 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
Matrix 0 [glstate_matrix_modelview0]
Matrix 4 [_Object2World]
Matrix 8 [_World2Object]
Matrix 12 [_ProjMat]
Vector 16 [_WorldSpaceCameraPos]
Vector 17 [_ProjectionParams]
Vector 18 [_ScreenParams]
Vector 19 [unity_Scale]
Vector 20 [unity_LightmapST]
Vector 21 [_MainTex_ST]
Vector 22 [_BumpMap_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
dcl_texcoord6 o7
def c23, 0.50000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_tangent0 v1
dcl_normal0 v2
dcl_texcoord0 v3
dcl_texcoord1 v4
mov r0.x, c15.y
mul r1, c1, r0.x
mov r0.x, c15
mad r1, c0, r0.x, r1
mov r0.x, c15.z
mad r1, c2, r0.x, r1
mov r0.x, c15.w
mad r0, c3, r0.x, r1
dp4 r2.w, r0, v0
mov r1.x, c12.y
mov r0.x, c12
mul r1, c1, r1.x
mad r1, c0, r0.x, r1
mov r0.x, c12.z
mad r1, c2, r0.x, r1
mov r0.y, c12.w
mad r1, c3, r0.y, r1
mov r0.x, c13.y
mov r2.x, c13
mul r0, c1, r0.x
mad r0, c0, r2.x, r0
mov r2.x, c13.z
mad r0, c2, r2.x, r0
mov r2.x, c13.w
mad r0, c3, r2.x, r0
dp4 r2.y, v0, r0
dp4 r2.x, v0, r1
mul r1.xyz, r2.xyww, c23.x
mul r1.y, r1, c17.x
mov r0.xyz, v1
mad o2.xy, r1.z, c18.zwzw, r1
mul r1.xyz, v2.zxyw, r0.yzxw
mov r0.xyz, v1
mad r1.xyz, v2.yzxw, r0.zxyw, -r1
mul r3.xyz, v1.w, r1
mov r0.x, c14.y
mov r1.x, c14
mul r0, c1, r0.x
mad r0, c0, r1.x, r0
mov r1.x, c14.z
mad r0, c2, r1.x, r0
mov r1.x, c14.w
mad r1, c3, r1.x, r0
dp4 r2.z, v0, r1
mov r0.xyz, c16
mov r0.w, c23.y
dp3 r1.y, r3, c4
dp3 r1.x, v1, c4
dp3 r1.z, v2, c4
dp4 r4.z, r0, c10
dp4 r4.x, r0, c8
dp4 r4.y, r0, c9
mad r0.xyz, r4, c19.w, -v0
dp3 r1.w, -r0, c4
mul o3, r1, c19.w
dp3 r1.y, r3, c5
dp3 r1.w, -r0, c5
dp3 r1.x, v1, c5
dp3 r1.z, v2, c5
mul o4, r1, c19.w
dp3 r1.y, r3, c6
dp3 r1.w, -r0, c6
dp3 r1.x, v1, c6
dp3 r1.z, v2, c6
dp3 o7.y, r3, r0
mov o0, r2
mov o2.zw, r2
mul o5, r1, c19.w
dp3 o7.z, v2, r0
dp3 o7.x, v1, r0
mad o1.zw, v3.xyxy, c22.xyxy, c22
mad o1.xy, v3, c21, c21.zwzw
mad o6.xy, v4, c20, c20.zwzw
"
}
SubProgram "d3d11 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Bind "vertex" Vertex
Bind "color" Color
Bind "normal" Normal
Bind "texcoord" TexCoord0
Bind "texcoord1" TexCoord1
Bind "tangent" TexCoord2
ConstBuffer "$Globals" 288
Matrix 48 [_ProjMat]
Vector 208 [unity_LightmapST]
Vector 224 [_MainTex_ST]
Vector 240 [_BumpMap_ST]
ConstBuffer "UnityPerCamera" 128
Vector 64 [_WorldSpaceCameraPos] 3
Vector 80 [_ProjectionParams]
ConstBuffer "UnityPerDraw" 336
Matrix 64 [glstate_matrix_modelview0]
Matrix 192 [_Object2World]
Matrix 256 [_World2Object]
Vector 320 [unity_Scale]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
BindCB  "UnityPerDraw" 2
"vs_4_0
eefiecedhhmjegmemmklgphakjniohofpkpclbcjabaaaaaafealaaaaadaaaaaa
cmaaaaaapeaaaaaanmabaaaaejfdeheomaaaaaaaagaaaaaaaiaaaaaajiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaakbaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaakjaaaaaaaaaaaaaaaaaaaaaaadaaaaaaacaaaaaa
ahahaaaalaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaadaaaaaaapadaaaalaaaaaaa
abaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapadaaaaljaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapaaaaaafaepfdejfeejepeoaafeebeoehefeofeaaeoepfc
enebemaafeeffiedepepfceeaaedepemepfcaaklepfdeheooaaaaaaaaiaaaaaa
aiaaaaaamiaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaneaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaneaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaneaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaaneaaaaaaadaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapaaaaaaneaaaaaa
aeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaaneaaaaaaafaaaaaaaaaaaaaa
adaaaaaaagaaaaaaadamaaaaneaaaaaaagaaaaaaaaaaaaaaadaaaaaaahaaaaaa
ahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaklklklfdeieefc
haajaaaaeaaaabaafmacaaaafjaaaaaeegiocaaaaaaaaaaabaaaaaaafjaaaaae
egiocaaaabaaaaaaagaaaaaafjaaaaaeegiocaaaacaaaaaabfaaaaaafpaaaaad
pcbabaaaaaaaaaaafpaaaaadpcbabaaaabaaaaaafpaaaaadhcbabaaaacaaaaaa
fpaaaaaddcbabaaaadaaaaaafpaaaaaddcbabaaaaeaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaa
afaaaaaagfaaaaaddccabaaaagaaaaaagfaaaaadhccabaaaahaaaaaagiaaaaac
afaaaaaadiaaaaajpcaabaaaaaaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaa
acaaaaaaafaaaaaadcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaadaaaaaa
agiacaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaadcaaaaalpcaabaaaaaaaaaaa
egiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaafaaaaaaegaobaaaaaaaaaaa
dcaaaaalpcaabaaaaaaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaa
afaaaaaaegaobaaaaaaaaaaadiaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
fgbfbaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaa
fgifcaaaacaaaaaaaeaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaa
adaaaaaaagiacaaaacaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaaacaaaaaaaeaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaa
acaaaaaaaeaaaaaaegaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadiaaaaajpcaabaaaabaaaaaa
egiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaaagaaaaaadcaaaaalpcaabaaa
abaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaaacaaaaaaagaaaaaaegaobaaa
abaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaafaaaaaakgikcaaa
acaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaagaaaaaapgipcaaaacaaaaaaagaaaaaaegaobaaaabaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaa
diaaaaajpcaabaaaabaaaaaaegiocaaaaaaaaaaaaeaaaaaafgifcaaaacaaaaaa
ahaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaaaaaaaaaaadaaaaaaagiacaaa
acaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaalpcaabaaaabaaaaaaegiocaaa
aaaaaaaaafaaaaaakgikcaaaacaaaaaaahaaaaaaegaobaaaabaaaaaadcaaaaal
pcaabaaaabaaaaaaegiocaaaaaaaaaaaagaaaaaapgipcaaaacaaaaaaahaaaaaa
egaobaaaabaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadgaaaaafpccabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaaldccabaaaabaaaaaaegbabaaaadaaaaaaegiacaaaaaaaaaaaaoaaaaaa
ogikcaaaaaaaaaaaaoaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaadaaaaaa
agiecaaaaaaaaaaaapaaaaaakgiocaaaaaaaaaaaapaaaaaadiaaaaaiccaabaaa
aaaaaaaabkaabaaaaaaaaaaaakiacaaaabaaaaaaafaaaaaadiaaaaakncaabaaa
abaaaaaaagahbaaaaaaaaaaaaceaaaaaaaaaaadpaaaaaaaaaaaaaadpaaaaaadp
dgaaaaafmccabaaaacaaaaaakgaobaaaaaaaaaaaaaaaaaahdccabaaaacaaaaaa
kgakbaaaabaaaaaamgaabaaaabaaaaaadiaaaaajhcaabaaaaaaaaaaafgifcaaa
abaaaaaaaeaaaaaaegiccaaaacaaaaaabbaaaaaadcaaaaalhcaabaaaaaaaaaaa
egiccaaaacaaaaaabaaaaaaaagiacaaaabaaaaaaaeaaaaaaegacbaaaaaaaaaaa
dcaaaaalhcaabaaaaaaaaaaaegiccaaaacaaaaaabcaaaaaakgikcaaaabaaaaaa
aeaaaaaaegacbaaaaaaaaaaaaaaaaaaihcaabaaaaaaaaaaaegacbaaaaaaaaaaa
egiccaaaacaaaaaabdaaaaaadcaaaaalhcaabaaaaaaaaaaaegacbaaaaaaaaaaa
pgipcaaaacaaaaaabeaaaaaaegbcbaiaebaaaaaaaaaaaaaadiaaaaajhcaabaaa
abaaaaaafgafbaiaebaaaaaaaaaaaaaaegiccaaaacaaaaaaanaaaaaadcaaaaal
hcaabaaaabaaaaaaegiccaaaacaaaaaaamaaaaaaagaabaiaebaaaaaaaaaaaaaa
egacbaaaabaaaaaadcaaaaallcaabaaaabaaaaaaegiicaaaacaaaaaaaoaaaaaa
kgakbaiaebaaaaaaaaaaaaaaegaibaaaabaaaaaadgaaaaaficaabaaaacaaaaaa
akaabaaaabaaaaaadiaaaaahhcaabaaaadaaaaaajgbebaaaabaaaaaacgbjbaaa
acaaaaaadcaaaaakhcaabaaaadaaaaaajgbebaaaacaaaaaacgbjbaaaabaaaaaa
egacbaiaebaaaaaaadaaaaaadiaaaaahhcaabaaaadaaaaaaegacbaaaadaaaaaa
pgbpbaaaabaaaaaadgaaaaagbcaabaaaaeaaaaaaakiacaaaacaaaaaaamaaaaaa
dgaaaaagccaabaaaaeaaaaaaakiacaaaacaaaaaaanaaaaaadgaaaaagecaabaaa
aeaaaaaaakiacaaaacaaaaaaaoaaaaaabaaaaaahccaabaaaacaaaaaaegacbaaa
adaaaaaaegacbaaaaeaaaaaabaaaaaahbcaabaaaacaaaaaaegbcbaaaabaaaaaa
egacbaaaaeaaaaaabaaaaaahecaabaaaacaaaaaaegbcbaaaacaaaaaaegacbaaa
aeaaaaaadiaaaaaipccabaaaadaaaaaaegaobaaaacaaaaaapgipcaaaacaaaaaa
beaaaaaadgaaaaaficaabaaaacaaaaaabkaabaaaabaaaaaadgaaaaagbcaabaaa
aeaaaaaabkiacaaaacaaaaaaamaaaaaadgaaaaagccaabaaaaeaaaaaabkiacaaa
acaaaaaaanaaaaaadgaaaaagecaabaaaaeaaaaaabkiacaaaacaaaaaaaoaaaaaa
baaaaaahccaabaaaacaaaaaaegacbaaaadaaaaaaegacbaaaaeaaaaaabaaaaaah
bcaabaaaacaaaaaaegbcbaaaabaaaaaaegacbaaaaeaaaaaabaaaaaahecaabaaa
acaaaaaaegbcbaaaacaaaaaaegacbaaaaeaaaaaadiaaaaaipccabaaaaeaaaaaa
egaobaaaacaaaaaapgipcaaaacaaaaaabeaaaaaadgaaaaagbcaabaaaacaaaaaa
ckiacaaaacaaaaaaamaaaaaadgaaaaagccaabaaaacaaaaaackiacaaaacaaaaaa
anaaaaaadgaaaaagecaabaaaacaaaaaackiacaaaacaaaaaaaoaaaaaabaaaaaah
ccaabaaaabaaaaaaegacbaaaadaaaaaaegacbaaaacaaaaaabaaaaaahcccabaaa
ahaaaaaaegacbaaaadaaaaaaegacbaaaaaaaaaaabaaaaaahbcaabaaaabaaaaaa
egbcbaaaabaaaaaaegacbaaaacaaaaaabaaaaaahecaabaaaabaaaaaaegbcbaaa
acaaaaaaegacbaaaacaaaaaadiaaaaaipccabaaaafaaaaaaegaobaaaabaaaaaa
pgipcaaaacaaaaaabeaaaaaadcaaaaaldccabaaaagaaaaaaegbabaaaaeaaaaaa
egiacaaaaaaaaaaaanaaaaaaogikcaaaaaaaaaaaanaaaaaabaaaaaahbccabaaa
ahaaaaaaegbcbaaaabaaaaaaegacbaaaaaaaaaaabaaaaaaheccabaaaahaaaaaa
egbcbaaaacaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
}
Program "fp" {
// Platform d3d11 had shader errors
//   Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
//   Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 0.12298584, 0.5, 0.029999999, 2 },
		{ 0.30004883, 0.60009766, 0.099975586, 0 },
		{ 16, 1, 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MOV R2, c[0];
ADD R1.xyz, -R2, c[4];
MAD R1.xyz, R0.w, R1, c[0];
ADD R2.xyz, -R1, c[3];
MAD R2.xyz, R0.z, R2, R1;
ADD R3.xyz, -R2, c[2];
SGE R4.xyz, R0.yzww, c[9].y;
TEX R1, fragment.texcoord[0], texture[1], 2D;
MAD R2.xyz, R0.y, R3, R2;
MUL R2.xyz, R1, R2;
ADD R3.x, -R1.w, R0.w;
MAD R1.y, R0.w, R3.x, R1.w;
ADD R1.z, R0, -R1.y;
MOV R1.x, c[5];
ADD R1.x, -R1, c[8];
MAD R4.w, R4.z, R1.x, c[5].x;
MAD R3.w, R0.z, R1.z, R1.y;
MOV R1, c[10];
DP4 R1.x, R1, c[2];
ADD R4.z, -R4.w, c[7].x;
MUL R3.xyz, R2, R0.y;
RCP R1.x, R1.x;
MAD R1.xyz, R3, R1.x, -R3.w;
MAD R1.w, R4.y, R4.z, R4;
MAD R1.xyz, R0.y, R1, R3.w;
ADD R3.x, -R1.w, c[6];
MAD R1.w, R4.x, R3.x, R1;
ADD R3.x, -R2.w, c[4].w;
MAD R4.x, R0.w, R3, c[0].w;
MAD R2.w, R1, R1, c[9].z;
MOV R0.w, c[11].y;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R3.xy, R3.wyzw, c[9].w, -R0.w;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD R0.w, -R4.x, c[3];
MAD R0.z, R0, R0.w, R4.x;
ADD_SAT R3.z, R3, R3.w;
ADD R0.w, -R0.z, c[2];
MAD R0.y, R0, R0.w, R0.z;
ADD R3.z, -R3, c[11].y;
RSQ R0.z, R3.z;
RCP R3.z, R0.z;
ADD R0.z, -R1.w, c[11].y;
MUL R0.y, R2.w, R0;
DP3 R4.x, fragment.texcoord[2], R3;
DP3 R4.y, R3, fragment.texcoord[3];
DP3 R4.z, R3, fragment.texcoord[4];
MUL R1.xyz, R0.y, R1;
MOV R3.x, fragment.texcoord[2].w;
MOV R3.z, fragment.texcoord[4].w;
MOV R3.y, fragment.texcoord[3].w;
DP3 R0.y, R4, R3;
MUL R4.xyz, R4, R0.y;
MAD R3.xyz, -R4, c[9].w, R3;
MUL R3.w, R0.z, c[11].z;
TXB R4.xyz, R3, texture[4], CUBE;
MUL R3.xyz, R1, c[9].w;
TXP R1, fragment.texcoord[1], texture[0], 2D;
MUL R0.x, R0, c[1].w;
MUL R4.xyz, R3, R4;
LG2 R0.w, R1.w;
MUL R0.xyz, R0.x, c[1];
MAD R0.xyz, R0, c[11].x, R4;
MUL R3.xyz, R3, -R0.w;
LG2 R1.x, R1.x;
LG2 R1.z, R1.z;
LG2 R1.y, R1.y;
ADD R1.xyz, -R1, fragment.texcoord[5];
MAD R1.xyz, R2, R1, R3;
ADD result.color.xyz, R1, R0;
MOV result.color.w, c[9].x;
END
# 72 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c9, -0.50000000, 1.00000000, 0.00000000, 0.03000000
def c10, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c11, 2.00000000, -1.00000000, 8.00000000, 16.00000000
def c12, 0.12298584, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
mov_pp r0.xyz, c4
add_pp r1.xyz, -c0, r0
texld r0, v0, s2
mad_pp r1.xyz, r0.w, r1, c0
add_pp r2.xyz, -r1, c3
mad_pp r2.xyz, r0.z, r2, r1
texld r1, v0, s1
add r2.w, -r1, r0
add_pp r3.xyz, -r2, c2
mad_pp r2.xyz, r0.y, r3, r2
mul r2.xyz, r1, r2
mad r1.w, r0, r2, r1
add r1.x, r0.z, -r1.w
mad r2.w, r0.z, r1.x, r1
add r1.xyz, r0.yzww, c9.x
mov_pp r1.w, c8.x
cmp r4.xyz, r1, c9.y, c9.z
add_pp r1.w, -c5.x, r1
mad_pp r3.w, r4.z, r1, c5.x
mov_pp r1, c2
dp4_pp r1.x, c10, r1
add_pp r4.z, -r3.w, c7.x
mad_pp r1.w, r4.y, r4.z, r3
add_pp r3.w, -r1, c6.x
mad_pp r1.w, r4.x, r3, r1
mul r3.xyz, r2, r0.y
rcp r1.x, r1.x
mad r1.xyz, r3, r1.x, -r2.w
mad r3.xyz, r0.y, r1, r2.w
mov_pp r1.x, c4.w
add_pp r1.x, -c0.w, r1
mad_pp r0.w, r0, r1.x, c0
add_pp r2.w, -r0, c3
mad_pp r0.z, r0, r2.w, r0.w
add_pp r0.w, -r0.z, c2
texld r4.yw, v0.zwzw, s3
mad_pp r1.xy, r4.wyzw, c11.x, c11.y
mul_pp r4.xy, r1, r1
add_pp_sat r2.w, r4.x, r4.y
mad_pp r0.y, r0, r0.w, r0.z
mad r1.z, r1.w, r1.w, c9.w
mul r0.y, r1.z, r0
mul r3.xyz, r0.y, r3
add_pp r2.w, -r2, c9.y
rsq_pp r0.z, r2.w
rcp_pp r1.z, r0.z
add r0.z, -r1.w, c9.y
dp3_pp r4.x, v2, r1
dp3_pp r4.y, r1, v3
dp3_pp r4.z, r1, v4
mul r1.w, r0.z, c11.z
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r0.y, r4, r1
mul r4.xyz, r4, r0.y
mad r1.xyz, -r4, c11.x, r1
mul r0.x, r0, c1.w
texldb r1.xyz, r1, s4
mul r3.xyz, r3, c11.x
mul r4.xyz, r3, r1
texldp r1, v1, s0
log_pp r0.w, r1.w
mul r0.xyz, r0.x, c1
mad r0.xyz, r0, c11.w, r4
mul r3.xyz, r3, -r0.w
log_pp r1.x, r1.x
log_pp r1.z, r1.z
log_pp r1.y, r1.y
add_pp r1.xyz, -r1, v5
mad r1.xyz, r2, r1, r3
add oC0.xyz, r1, r0
mov_pp oC0.w, c12.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
Vector 9 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[13] = { program.local[0..9],
		{ 0.12298584, 8, 0.5, 0.029999999 },
		{ 0.30004883, 0.60009766, 0.099975586, 0 },
		{ 2, 16, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0, fragment.texcoord[0], texture[4], 2D;
MOV R2, c[0];
ADD R1.xyz, -R2, c[4];
MAD R1.xyz, R0.w, R1, c[0];
ADD R2.xyz, -R1, c[3];
MAD R1.xyz, R0.z, R2, R1;
ADD R2.xyz, -R1, c[2];
MAD R2.xyz, R0.y, R2, R1;
TEX R1, fragment.texcoord[0], texture[3], 2D;
MUL R2.xyz, R1, R2;
ADD R1.x, -R1.w, R0.w;
MAD R1.y, R0.w, R1.x, R1.w;
ADD R1.z, R0, -R1.y;
MOV R1.x, c[5];
SGE R4.xyz, R0.yzww, c[10].z;
ADD R1.x, -R1, c[8];
MAD R4.z, R4, R1.x, c[5].x;
MAD R3.w, R0.z, R1.z, R1.y;
ADD R4.w, -R4.z, c[7].x;
MOV R1, c[11];
DP4 R1.x, R1, c[2];
MAD R4.y, R4, R4.w, R4.z;
ADD R1.w, -R4.y, c[6].x;
MAD R1.w, R4.x, R1, R4.y;
MUL R3.xyz, R2, R0.y;
RCP R1.x, R1.x;
MAD R1.xyz, R3, R1.x, -R3.w;
MAD R3.xyz, R0.y, R1, R3.w;
ADD R1.x, -R2.w, c[4].w;
MAD R0.w, R0, R1.x, c[0];
ADD R2.w, -R0, c[3];
MAD R0.z, R0, R2.w, R0.w;
ADD R0.w, -R0.z, c[2];
TEX R4.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
MAD R1.xy, R4.wyzw, c[12].x, -c[12].z;
MUL R4.xy, R1, R1;
ADD_SAT R2.w, R4.x, R4.y;
MAD R0.y, R0, R0.w, R0.z;
MAD R1.z, R1.w, R1.w, c[10].w;
MUL R0.y, R1.z, R0;
ADD R2.w, -R2, c[12].z;
RSQ R0.z, R2.w;
RCP R1.z, R0.z;
ADD R0.z, -R1.w, c[12];
DP3 R4.x, fragment.texcoord[2], R1;
DP3 R4.y, R1, fragment.texcoord[3];
DP3 R4.z, R1, fragment.texcoord[4];
MUL R3.xyz, R0.y, R3;
MUL R1.w, R0.z, c[10].y;
MOV R1.x, fragment.texcoord[2].w;
MOV R1.z, fragment.texcoord[4].w;
MOV R1.y, fragment.texcoord[3].w;
DP3 R0.y, R4, R1;
MUL R4.xyz, R4, R0.y;
MAD R1.xyz, -R4, c[12].x, R1;
TXB R1.xyz, R1, texture[6], CUBE;
MUL R4.xyz, R3, c[12].x;
MUL R3.xyz, R4, R1;
MUL R1.x, R0, c[1].w;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MUL R1.xyz, R1.x, c[1];
MAD R3.xyz, R1, c[12].y, R3;
LG2 R0.w, R0.w;
TEX R1, fragment.texcoord[5], texture[1], 2D;
MUL R4.xyz, R4, -R0.w;
MUL R5.xyz, R1.w, R1;
TEX R1, fragment.texcoord[5], texture[2], 2D;
DP4 R0.w, fragment.texcoord[6], fragment.texcoord[6];
MUL R1.xyz, R1.w, R1;
MUL R1.xyz, R1, c[10].y;
RSQ R0.w, R0.w;
RCP R0.w, R0.w;
MAD R5.xyz, R5, c[10].y, -R1;
MAD_SAT R0.w, R0, c[9].z, c[9];
MAD R1.xyz, R0.w, R5, R1;
LG2 R0.x, R0.x;
LG2 R0.y, R0.y;
LG2 R0.z, R0.z;
ADD R0.xyz, -R0, R1;
MAD R0.xyz, R2, R0, R4;
ADD result.color.xyz, R0, R3;
MOV result.color.w, c[10].x;
END
# 82 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
Vector 9 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
def c10, 8.00000000, -0.50000000, 1.00000000, 0.00000000
def c11, 0.03000000, 2.00000000, -1.00000000, 16.00000000
def c12, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c13, 0.12298584, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
mov_pp r0.xyz, c4
add_pp r1.xyz, -c0, r0
texld r0, v0, s4
mad_pp r1.xyz, r0.w, r1, c0
add_pp r2.xyz, -r1, c3
mad_pp r2.xyz, r0.z, r2, r1
texld r1, v0, s3
add r2.w, -r1, r0
add_pp r3.xyz, -r2, c2
mad_pp r2.xyz, r0.y, r3, r2
mul r2.xyz, r1, r2
mad r1.w, r0, r2, r1
add r1.x, r0.z, -r1.w
mad r2.w, r0.z, r1.x, r1
add r1.xyz, r0.yzww, c10.y
mov_pp r1.w, c8.x
cmp r4.xyz, r1, c10.z, c10.w
add_pp r1.w, -c5.x, r1
mad_pp r3.w, r4.z, r1, c5.x
mov_pp r1, c2
dp4_pp r1.x, c12, r1
add_pp r4.z, -r3.w, c7.x
mad_pp r1.w, r4.y, r4.z, r3
add_pp r3.w, -r1, c6.x
mad_pp r1.w, r4.x, r3, r1
mul r3.xyz, r2, r0.y
rcp r1.x, r1.x
mad r1.xyz, r3, r1.x, -r2.w
mad r3.xyz, r0.y, r1, r2.w
mov_pp r1.x, c4.w
add_pp r1.x, -c0.w, r1
mad_pp r0.w, r0, r1.x, c0
add_pp r2.w, -r0, c3
mad_pp r0.z, r0, r2.w, r0.w
add_pp r0.w, -r0.z, c2
texld r4.yw, v0.zwzw, s5
mad_pp r1.xy, r4.wyzw, c11.y, c11.z
mul_pp r4.xy, r1, r1
add_pp_sat r2.w, r4.x, r4.y
mad_pp r0.y, r0, r0.w, r0.z
mad r1.z, r1.w, r1.w, c11.x
mul r0.y, r1.z, r0
add_pp r2.w, -r2, c10.z
rsq_pp r0.z, r2.w
rcp_pp r1.z, r0.z
add r0.z, -r1.w, c10
dp3_pp r4.x, v2, r1
dp3_pp r4.y, r1, v3
dp3_pp r4.z, r1, v4
mul r3.xyz, r0.y, r3
mul r1.w, r0.z, c10.x
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r0.y, r4, r1
mul r4.xyz, r4, r0.y
mad r1.xyz, -r4, c11.y, r1
texldb r1.xyz, r1, s6
mul r4.xyz, r3, c11.y
mul r3.xyz, r4, r1
mul r1.x, r0, c1.w
texldp r0, v1, s0
mul r1.xyz, r1.x, c1
mad r3.xyz, r1, c11.w, r3
log_pp r0.w, r0.w
texld r1, v5, s1
mul r4.xyz, r4, -r0.w
mul_pp r5.xyz, r1.w, r1
texld r1, v5, s2
dp4 r0.w, v6, v6
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c10.x
rsq r0.w, r0.w
rcp r0.w, r0.w
mad_pp r5.xyz, r5, c10.x, -r1
mad_sat r0.w, r0, c9.z, c9
mad_pp r1.xyz, r0.w, r5, r1
log_pp r0.x, r0.x
log_pp r0.y, r0.y
log_pp r0.z, r0.z
add_pp r0.xyz, -r0, r1
mad r0.xyz, r2, r0, r4
add oC0.xyz, r0, r3
mov_pp oC0.w, c13.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[14] = { program.local[0..8],
		{ 0.12298584, -0.40824828, -0.70710677, 0.57735026 },
		{ -0.40824831, 0.70710677, 0.57735026, 8 },
		{ 0.81649655, 0, 0.57735026, 1 },
		{ 0.5, 0.029999999, 2, 16 },
		{ 0.30004883, 0.60009766, 0.099975586, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R1, c[0];
TEX R2, fragment.texcoord[0], texture[4], 2D;
ADD R0.xyz, -R1, c[4];
MAD R0.xyz, R2.w, R0, c[0];
ADD R1.xyz, -R0, c[3];
MAD R0.xyz, R2.z, R1, R0;
ADD R1.xyz, -R0, c[2];
MAD R1.xyz, R2.y, R1, R0;
TEX R0, fragment.texcoord[0], texture[3], 2D;
MUL R3.xyz, R0, R1;
ADD R0.x, -R0.w, R2.w;
MAD R3.w, R2, R0.x, R0;
MOV R0, c[13];
DP4 R0.x, R0, c[2];
ADD R4.x, R2.z, -R3.w;
ADD R1.w, -R1, c[4];
MAD R0.w, R2.z, R4.x, R3;
MAD R1.w, R2, R1, c[0];
MUL R1.xyz, R3, R2.y;
RCP R0.x, R0.x;
MAD R0.xyz, R1, R0.x, -R0.w;
SGE R1.xyz, R2.yzww, c[12].x;
MAD R0.xyz, R2.y, R0, R0.w;
MOV R0.w, c[5].x;
ADD R0.w, -R0, c[8].x;
MAD R0.w, R1.z, R0, c[5].x;
ADD R1.z, -R0.w, c[7].x;
MAD R0.w, R1.y, R1.z, R0;
ADD R2.w, -R1, c[3];
MAD R1.z, R2, R2.w, R1.w;
ADD R1.y, -R0.w, c[6].x;
MAD R3.w, R1.x, R1.y, R0;
ADD R1.w, -R1.z, c[2];
MAD R1.x, R2.y, R1.w, R1.z;
MAD R0.w, R3, R3, c[12].y;
MUL R0.w, R0, R1.x;
MUL R1.xyz, R0.w, R0;
MUL R4.xyz, R1, c[12].z;
TEX R0, fragment.texcoord[5], texture[2], 2D;
DP3_SAT R1.z, R5, c[9].yzww;
DP3_SAT R1.x, R5, c[11];
DP3_SAT R1.y, R5, c[10];
MUL R0.xyz, R0.w, R0;
MUL R1.xyz, R0, R1;
TEX R0, fragment.texcoord[5], texture[1], 2D;
TEX R2.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
MOV R1.w, c[11];
MAD R5.xy, R2.wyzw, c[12].z, -R1.w;
MUL R2.zw, R5.xyxy, R5.xyxy;
ADD_SAT R1.w, R2.z, R2;
ADD R2.y, -R1.w, c[11].w;
RSQ R2.y, R2.y;
RCP R5.z, R2.y;
MUL R0.xyz, R0.w, R0;
DP3 R1.x, R1, c[10].w;
MUL R1.xyz, R0, R1.x;
TXP R0, fragment.texcoord[1], texture[0], 2D;
LG2 R0.x, R0.x;
LG2 R0.y, R0.y;
LG2 R0.z, R0.z;
LG2 R0.w, R0.w;
MUL R1.xyz, R1, c[10].w;
MOV R1.w, c[11];
ADD R1, -R0, R1;
MUL R2.yzw, R1.w, R4.xxyz;
DP3 R0.x, fragment.texcoord[2], R5;
DP3 R0.y, R5, fragment.texcoord[3];
DP3 R0.z, R5, fragment.texcoord[4];
MOV R5.x, fragment.texcoord[2].w;
MOV R5.z, fragment.texcoord[4].w;
MOV R5.y, fragment.texcoord[3].w;
DP3 R0.w, R0, R5;
MUL R0.xyz, R0, R0.w;
ADD R1.w, -R3, c[11];
MUL R0.w, R1, c[10];
MAD R0.xyz, -R0, c[12].z, R5;
TXB R0.xyz, R0, texture[6], CUBE;
MUL R4.xyz, R4, R0;
MUL R0.w, R2.x, c[1];
MUL R0.xyz, R0.w, c[1];
MAD R0.xyz, R0, c[12].w, R4;
MAD R1.xyz, R3, R1, R2.yzww;
ADD result.color.xyz, R1, R0;
MOV result.color.w, c[9].x;
END
# 84 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_OFF" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
def c9, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c10, -0.40824831, 0.70710677, 0.57735026, -0.50000000
def c11, 0.81649655, 0.00000000, 0.57735026, 1.00000000
def c12, 0.03000000, 2.00000000, -1.00000000, 16.00000000
def c13, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c14, 0.12298584, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
mov_pp r0.xyz, c4
add_pp r2.xyz, -c0, r0
texld r0, v0, s4
mad_pp r4.xyz, r0.w, r2, c0
add_pp r2.xyz, -r4, c3
mad_pp r2.xyz, r0.z, r2, r4
texld r3, v5, s2
mul_pp r3.xyz, r3.w, r3
dp3_pp_sat r4.z, r1, c9
dp3_pp_sat r4.x, r1, c11
dp3_pp_sat r4.y, r1, c10
mul_pp r3.xyz, r3, r4
add_pp r4.xyz, -r2, c2
mad_pp r2.xyz, r0.y, r4, r2
texld r1, v5, s1
mov_pp r4, c2
dp4_pp r4.w, c13, r4
add r4.xyz, r0.yzww, c10.w
cmp r4.xyz, r4, c11.w, c11.y
dp3_pp r2.w, r3, c9.w
mul_pp r1.xyz, r1.w, r1
mul_pp r3.xyz, r1, r2.w
texldp r1, v1, s0
mul_pp r3.xyz, r3, c9.w
mov_pp r3.w, c11
log_pp r1.x, r1.x
log_pp r1.y, r1.y
log_pp r1.z, r1.z
log_pp r1.w, r1.w
add_pp r1, -r1, r3
texld r3, v0, s3
add r2.w, -r3, r0
mad r3.w, r0, r2, r3
mul r2.xyz, r3, r2
add r2.w, r0.z, -r3
mad r2.w, r0.z, r2, r3
mov_pp r3.w, c8.x
add_pp r3.w, -c5.x, r3
mad_pp r3.w, r4.z, r3, c5.x
rcp r4.z, r4.w
mul r3.xyz, r2, r0.y
mad r3.xyz, r3, r4.z, -r2.w
add_pp r4.z, -r3.w, c7.x
mad_pp r4.y, r4, r4.z, r3.w
mad r3.xyz, r0.y, r3, r2.w
add_pp r2.w, -r4.y, c6.x
mad_pp r2.w, r4.x, r2, r4.y
texld r4.yw, v0.zwzw, s5
mov_pp r3.w, c4
add_pp r3.w, -c0, r3
mad_pp r4.x, r0.w, r3.w, c0.w
add_pp r0.w, -r4.x, c3
mad_pp r4.z, r0, r0.w, r4.x
mad_pp r5.xy, r4.wyzw, c12.y, c12.z
add_pp r4.x, -r4.z, c2.w
mul_pp r0.zw, r5.xyxy, r5.xyxy
mad_pp r4.x, r0.y, r4, r4.z
add_pp_sat r0.y, r0.z, r0.w
mad r3.w, r2, r2, c12.x
mul r0.z, r3.w, r4.x
mul r3.xyz, r0.z, r3
mul r4.xyz, r3, c12.y
mul r3.xyz, r1.w, r4
add_pp r0.y, -r0, c11.w
rsq_pp r0.y, r0.y
rcp_pp r5.z, r0.y
add r1.w, -r2, c11
dp3_pp r0.y, v2, r5
dp3_pp r0.z, r5, v3
dp3_pp r0.w, r5, v4
mov r5.x, v2.w
mov r5.z, v4.w
mov r5.y, v3.w
dp3 r3.w, r0.yzww, r5
mul r0.yzw, r0, r3.w
mad r5.xyz, -r0.yzww, c12.y, r5
mul r5.w, r1, c9
mul r0.w, r0.x, c1
texldb r5.xyz, r5, s6
mul r0.xyz, r4, r5
mul r4.xyz, r0.w, c1
mad r0.xyz, r4, c12.w, r0
mad r1.xyz, r2, r1, r3
add oC0.xyz, r1, r0
mov_pp oC0.w, c14.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 0.12298584, 0.5, 0.029999999, 2 },
		{ 0.30004883, 0.60009766, 0.099975586, 0 },
		{ 16, 1, 8 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEX R0, fragment.texcoord[0], texture[2], 2D;
MOV R3, c[0];
ADD R1.xyz, -R3, c[4];
MAD R1.xyz, R0.w, R1, c[0];
ADD R2.xyz, -R1, c[3];
MAD R2.xyz, R0.z, R2, R1;
ADD R3.xyz, -R2, c[2];
TEX R1, fragment.texcoord[0], texture[1], 2D;
MAD R2.xyz, R0.y, R3, R2;
MUL R1.xyz, R1, R2;
ADD R2.w, -R1, R0;
MAD R1.w, R0, R2, R1;
ADD R2.y, R0.z, -R1.w;
MOV R2.x, c[5];
SGE R4.xyz, R0.yzww, c[9].y;
ADD R2.x, -R2, c[8];
MAD R4.w, R4.z, R2.x, c[5].x;
MAD R1.w, R0.z, R2.y, R1;
MOV R2, c[10];
DP4 R2.x, R2, c[2];
ADD R4.z, -R4.w, c[7].x;
MUL R3.xyz, R1, R0.y;
RCP R2.x, R2.x;
MAD R2.xyz, R3, R2.x, -R1.w;
MAD R2.w, R4.y, R4.z, R4;
MAD R2.xyz, R0.y, R2, R1.w;
ADD R3.x, -R2.w, c[6];
MAD R1.w, R4.x, R3.x, R2;
ADD R3.x, -R3.w, c[4].w;
MAD R4.x, R0.w, R3, c[0].w;
MAD R2.w, R1, R1, c[9].z;
MOV R0.w, c[11].y;
TEX R3.yw, fragment.texcoord[0].zwzw, texture[3], 2D;
MAD R3.xy, R3.wyzw, c[9].w, -R0.w;
MUL R3.zw, R3.xyxy, R3.xyxy;
ADD R0.w, -R4.x, c[3];
MAD R0.z, R0, R0.w, R4.x;
ADD_SAT R3.z, R3, R3.w;
ADD R0.w, -R0.z, c[2];
MAD R0.y, R0, R0.w, R0.z;
ADD R3.z, -R3, c[11].y;
RSQ R0.z, R3.z;
RCP R3.z, R0.z;
ADD R0.z, -R1.w, c[11].y;
MUL R0.y, R2.w, R0;
MUL R2.xyz, R0.y, R2;
DP3 R4.x, fragment.texcoord[2], R3;
DP3 R4.y, R3, fragment.texcoord[3];
DP3 R4.z, R3, fragment.texcoord[4];
MOV R3.x, fragment.texcoord[2].w;
MOV R3.z, fragment.texcoord[4].w;
MOV R3.y, fragment.texcoord[3].w;
DP3 R0.y, R4, R3;
MUL R4.xyz, R4, R0.y;
MUL R3.w, R0.z, c[11].z;
MAD R3.xyz, -R4, c[9].w, R3;
MUL R1.w, R0.x, c[1];
TXP R0, fragment.texcoord[1], texture[0], 2D;
TXB R3.xyz, R3, texture[4], CUBE;
MUL R2.xyz, R2, c[9].w;
MUL R4.xyz, R2, R3;
MUL R3.xyz, R1.w, c[1];
MAD R3.xyz, R3, c[11].x, R4;
MUL R2.xyz, R0.w, R2;
ADD R0.xyz, R0, fragment.texcoord[5];
MAD R0.xyz, R1, R0, R2;
ADD result.color.xyz, R0, R3;
MOV result.color.w, c[9].x;
END
# 68 instructions, 5 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [_MainTex] 2D 1
SetTexture 2 [_MaskTex] 2D 2
SetTexture 3 [_BumpMap] 2D 3
SetTexture 4 [_Cube] CUBE 4
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_cube s4
def c9, -0.50000000, 1.00000000, 0.00000000, 0.03000000
def c10, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c11, 2.00000000, -1.00000000, 8.00000000, 16.00000000
def c12, 0.12298584, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xyz
mov_pp r0.xyz, c4
add_pp r1.xyz, -c0, r0
texld r0, v0, s2
mad_pp r1.xyz, r0.w, r1, c0
add_pp r2.xyz, -r1, c3
mad_pp r2.xyz, r0.z, r2, r1
texld r1, v0, s1
add r2.w, -r1, r0
mad r1.w, r0, r2, r1
add_pp r3.xyz, -r2, c2
mad_pp r2.xyz, r0.y, r3, r2
mul r1.xyz, r1, r2
add r2.x, r0.z, -r1.w
mad r1.w, r0.z, r2.x, r1
add r2.xyz, r0.yzww, c9.x
mov_pp r2.w, c8.x
cmp r4.xyz, r2, c9.y, c9.z
add_pp r2.w, -c5.x, r2
mad_pp r3.w, r4.z, r2, c5.x
mov_pp r2, c2
dp4_pp r2.x, c10, r2
add_pp r4.z, -r3.w, c7.x
mad_pp r2.w, r4.y, r4.z, r3
mul r3.xyz, r1, r0.y
rcp r2.x, r2.x
mad r2.xyz, r3, r2.x, -r1.w
mad r3.xyz, r0.y, r2, r1.w
add_pp r3.w, -r2, c6.x
mad_pp r1.w, r4.x, r3, r2
mov_pp r2.x, c4.w
add_pp r2.x, -c0.w, r2
mad_pp r0.w, r0, r2.x, c0
add_pp r4.x, -r0.w, c3.w
mad_pp r0.z, r0, r4.x, r0.w
add_pp r0.w, -r0.z, c2
texld r2.yw, v0.zwzw, s3
mad_pp r2.xy, r2.wyzw, c11.x, c11.y
mul_pp r2.zw, r2.xyxy, r2.xyxy
add_pp_sat r2.z, r2, r2.w
mad_pp r0.y, r0, r0.w, r0.z
mad r3.w, r1, r1, c9
add_pp r2.z, -r2, c9.y
rsq_pp r0.z, r2.z
rcp_pp r2.z, r0.z
add r0.z, -r1.w, c9.y
mul r0.y, r3.w, r0
dp3_pp r4.x, v2, r2
dp3_pp r4.y, r2, v3
dp3_pp r4.z, r2, v4
mul r3.xyz, r0.y, r3
mov r2.x, v2.w
mov r2.z, v4.w
mov r2.y, v3.w
dp3 r0.y, r4, r2
mul r4.xyz, r4, r0.y
mad r2.xyz, -r4, c11.x, r2
mul r2.w, r0.z, c11.z
texldb r4.xyz, r2, s4
mul r2.xyz, r3, c11.x
mul r1.w, r0.x, c1
texldp r0, v1, s0
mul r4.xyz, r2, r4
mul r3.xyz, r1.w, c1
mad r3.xyz, r3, c11.w, r4
mul r2.xyz, r0.w, r2
add_pp r0.xyz, r0, v5
mad r0.xyz, r1, r0, r2
add oC0.xyz, r0, r3
mov_pp oC0.w, c12.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
Vector 9 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[13] = { program.local[0..9],
		{ 0.12298584, 8, 0.5, 0.029999999 },
		{ 0.30004883, 0.60009766, 0.099975586, 0 },
		{ 2, 16, 1 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
TEX R0, fragment.texcoord[0], texture[4], 2D;
MOV R2, c[0];
ADD R1.xyz, -R2, c[4];
MAD R1.xyz, R0.w, R1, c[0];
ADD R2.xyz, -R1, c[3];
MAD R2.xyz, R0.z, R2, R1;
ADD R3.xyz, -R2, c[2];
SGE R4.xyz, R0.yzww, c[10].z;
TEX R1, fragment.texcoord[0], texture[3], 2D;
MAD R2.xyz, R0.y, R3, R2;
MUL R2.xyz, R1, R2;
ADD R3.x, -R1.w, R0.w;
MAD R1.y, R0.w, R3.x, R1.w;
ADD R1.z, R0, -R1.y;
MOV R1.x, c[5];
ADD R1.x, -R1, c[8];
MAD R4.w, R4.z, R1.x, c[5].x;
MAD R3.w, R0.z, R1.z, R1.y;
MOV R1, c[11];
DP4 R1.x, R1, c[2];
ADD R4.z, -R4.w, c[7].x;
MAD R1.w, R4.y, R4.z, R4;
ADD R4.y, -R1.w, c[6].x;
MAD R1.w, R4.x, R4.y, R1;
MUL R3.xyz, R2, R0.y;
RCP R1.x, R1.x;
MAD R1.xyz, R3, R1.x, -R3.w;
MAD R3.xyz, R0.y, R1, R3.w;
ADD R1.x, -R2.w, c[4].w;
MAD R0.w, R0, R1.x, c[0];
TEX R4.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
ADD R2.w, -R0, c[3];
MAD R2.w, R0.z, R2, R0;
MAD R1.xy, R4.wyzw, c[12].x, -c[12].z;
MUL R0.zw, R1.xyxy, R1.xyxy;
ADD_SAT R0.z, R0, R0.w;
ADD R3.w, -R2, c[2];
ADD R0.z, -R0, c[12];
MAD R1.z, R1.w, R1.w, c[10].w;
MAD R0.y, R0, R3.w, R2.w;
MUL R0.y, R1.z, R0;
RSQ R0.z, R0.z;
RCP R1.z, R0.z;
ADD R0.z, -R1.w, c[12];
MUL R3.xyz, R0.y, R3;
DP3 R4.x, fragment.texcoord[2], R1;
DP3 R4.y, R1, fragment.texcoord[3];
DP3 R4.z, R1, fragment.texcoord[4];
MUL R1.w, R0.z, c[10].y;
MUL R3.xyz, R3, c[12].x;
MOV R1.x, fragment.texcoord[2].w;
MOV R1.z, fragment.texcoord[4].w;
MOV R1.y, fragment.texcoord[3].w;
DP3 R0.y, R4, R1;
MUL R4.xyz, R4, R0.y;
MAD R1.xyz, -R4, c[12].x, R1;
TXB R1.xyz, R1, texture[6], CUBE;
MUL R0.x, R0, c[1].w;
MUL R1.xyz, R3, R1;
MUL R0.xyz, R0.x, c[1];
MAD R4.xyz, R0, c[12].y, R1;
TEX R0, fragment.texcoord[5], texture[1], 2D;
MUL R0.xyz, R0.w, R0;
TEX R1, fragment.texcoord[5], texture[2], 2D;
MUL R1.xyz, R1.w, R1;
MUL R1.xyz, R1, c[10].y;
DP4 R0.w, fragment.texcoord[6], fragment.texcoord[6];
RSQ R0.w, R0.w;
RCP R1.w, R0.w;
MAD R5.xyz, R0, c[10].y, -R1;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MAD_SAT R1.w, R1, c[9].z, c[9];
MAD R1.xyz, R1.w, R5, R1;
MUL R3.xyz, R0.w, R3;
ADD R0.xyz, R0, R1;
MAD R0.xyz, R2, R0, R3;
ADD result.color.xyz, R0, R4;
MOV result.color.w, c[10].x;
END
# 78 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
Vector 9 [unity_LightmapFade]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
def c10, 8.00000000, -0.50000000, 1.00000000, 0.00000000
def c11, 0.03000000, 2.00000000, -1.00000000, 16.00000000
def c12, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c13, 0.12298584, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
dcl_texcoord6 v6
mov_pp r0.xyz, c4
add_pp r1.xyz, -c0, r0
texld r0, v0, s4
mad_pp r1.xyz, r0.w, r1, c0
add_pp r2.xyz, -r1, c3
mad_pp r2.xyz, r0.z, r2, r1
texld r1, v0, s3
add r2.w, -r1, r0
add_pp r3.xyz, -r2, c2
mad_pp r2.xyz, r0.y, r3, r2
mul r2.xyz, r1, r2
mad r1.w, r0, r2, r1
add r3.xyz, r0.yzww, c10.y
add r1.x, r0.z, -r1.w
mad r2.w, r0.z, r1.x, r1
mov_pp r1, c2
dp4_pp r1.x, c12, r1
mov_pp r3.w, c8.x
cmp r3.xyz, r3, c10.z, c10.w
add_pp r3.w, -c5.x, r3
mad_pp r3.z, r3, r3.w, c5.x
add_pp r1.w, -r3.z, c7.x
mad_pp r1.w, r3.y, r1, r3.z
mul r4.xyz, r2, r0.y
rcp r1.x, r1.x
mad r1.xyz, r4, r1.x, -r2.w
mad r4.xyz, r0.y, r1, r2.w
add_pp r1.y, -r1.w, c6.x
mad_pp r1.w, r3.x, r1.y, r1
mov_pp r1.x, c4.w
add_pp r1.x, -c0.w, r1
mad_pp r0.w, r0, r1.x, c0
texld r3.yw, v0.zwzw, s5
add_pp r2.w, -r0, c3
mad_pp r2.w, r0.z, r2, r0
mad_pp r1.xy, r3.wyzw, c11.y, c11.z
mul_pp r0.zw, r1.xyxy, r1.xyxy
add_pp_sat r0.z, r0, r0.w
add_pp r3.x, -r2.w, c2.w
add_pp r0.z, -r0, c10
mad r1.z, r1.w, r1.w, c11.x
mad_pp r0.y, r0, r3.x, r2.w
mul r0.y, r1.z, r0
mul r3.xyz, r0.y, r4
rsq_pp r0.z, r0.z
rcp_pp r1.z, r0.z
add r0.z, -r1.w, c10
dp3_pp r4.x, v2, r1
dp3_pp r4.y, r1, v3
dp3_pp r4.z, r1, v4
mul r1.w, r0.z, c10.x
mul r3.xyz, r3, c11.y
mov r1.x, v2.w
mov r1.z, v4.w
mov r1.y, v3.w
dp3 r0.y, r4, r1
mul r4.xyz, r4, r0.y
mad r1.xyz, -r4, c11.y, r1
texldb r1.xyz, r1, s6
mul r0.x, r0, c1.w
mul r1.xyz, r3, r1
mul r0.xyz, r0.x, c1
mad r4.xyz, r0, c11.w, r1
texld r0, v5, s1
mul_pp r0.xyz, r0.w, r0
texld r1, v5, s2
mul_pp r1.xyz, r1.w, r1
mul_pp r1.xyz, r1, c10.x
dp4 r0.w, v6, v6
rsq r0.w, r0.w
rcp r1.w, r0.w
mad_pp r5.xyz, r0, c10.x, -r1
texldp r0, v1, s0
mad_sat r1.w, r1, c9.z, c9
mad_pp r1.xyz, r1.w, r5, r1
mul r3.xyz, r0.w, r3
add_pp r0.xyz, r0, r1
mad r0.xyz, r2, r0, r3
add oC0.xyz, r0, r4
mov_pp oC0.w, c13.x
"
}
SubProgram "opengl " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"3.0-!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[14] = { program.local[0..8],
		{ 0.12298584, -0.40824828, -0.70710677, 0.57735026 },
		{ -0.40824831, 0.70710677, 0.57735026, 8 },
		{ 0.81649655, 0, 0.57735026, 1 },
		{ 0.5, 0.029999999, 2, 16 },
		{ 0.30004883, 0.60009766, 0.099975586, 0 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
TEMP R4;
TEMP R5;
MOV R2, c[0];
TEX R1, fragment.texcoord[0], texture[4], 2D;
ADD R0.xyz, -R2, c[4];
MAD R0.xyz, R1.w, R0, c[0];
ADD R2.xyz, -R0, c[3];
MAD R0.xyz, R1.z, R2, R0;
ADD R2.xyz, -R0, c[2];
MAD R2.xyz, R1.y, R2, R0;
TEX R0, fragment.texcoord[0], texture[3], 2D;
MUL R3.xyz, R0, R2;
ADD R0.x, -R0.w, R1.w;
MAD R3.w, R1, R0.x, R0;
MOV R0, c[13];
DP4 R0.x, R0, c[2];
ADD R4.x, R1.z, -R3.w;
MAD R0.w, R1.z, R4.x, R3;
MUL R2.xyz, R3, R1.y;
RCP R0.x, R0.x;
MAD R0.xyz, R2, R0.x, -R0.w;
MAD R0.xyz, R1.y, R0, R0.w;
MOV R0.w, c[5].x;
SGE R2.xyz, R1.yzww, c[12].x;
ADD R0.w, -R0, c[8].x;
MAD R0.w, R2.z, R0, c[5].x;
ADD R2.w, -R2, c[4];
MAD R2.z, R1.w, R2.w, c[0].w;
ADD R1.w, -R0, c[7].x;
MAD R0.w, R2.y, R1, R0;
ADD R2.w, -R2.z, c[3];
MAD R1.w, R1.z, R2, R2.z;
ADD R1.z, -R0.w, c[6].x;
MAD R3.w, R2.x, R1.z, R0;
ADD R2.y, -R1.w, c[2].w;
MAD R1.y, R1, R2, R1.w;
MAD R0.w, R3, R3, c[12].y;
MUL R0.w, R0, R1.y;
MUL R2.xyz, R0.w, R0;
MUL R4.xyz, R2, c[12].z;
TEX R0, fragment.texcoord[5], texture[2], 2D;
DP3_SAT R2.z, R5, c[9].yzww;
DP3_SAT R2.x, R5, c[11];
DP3_SAT R2.y, R5, c[10];
MUL R0.xyz, R0.w, R0;
MUL R2.xyz, R0, R2;
TEX R0, fragment.texcoord[5], texture[1], 2D;
DP3 R1.w, R2, c[10].w;
MUL R2.xyz, R0.w, R0;
TEX R0.yw, fragment.texcoord[0].zwzw, texture[5], 2D;
MOV R0.x, c[11].w;
MAD R1.yz, R0.xwyw, c[12].z, -R0.x;
MUL R0.xyz, R2, R1.w;
MUL R5.xy, R1.yzzw, R1.yzzw;
MUL R2.xyz, R0, c[10].w;
ADD_SAT R1.w, R5.x, R5.y;
ADD R1.w, -R1, c[11];
RSQ R1.w, R1.w;
TXP R0, fragment.texcoord[1], texture[0], 2D;
MOV R2.w, c[11];
ADD R2, R0, R2;
RCP R1.w, R1.w;
MUL R5.xyz, R2.w, R4;
DP3 R0.x, fragment.texcoord[2], R1.yzww;
DP3 R0.y, R1.yzww, fragment.texcoord[3];
DP3 R0.z, R1.yzww, fragment.texcoord[4];
MOV R1.y, fragment.texcoord[2].w;
MOV R1.z, fragment.texcoord[3].w;
MOV R1.w, fragment.texcoord[4];
DP3 R0.w, R0, R1.yzww;
MUL R0.xyz, R0, R0.w;
ADD R2.w, -R3, c[11];
MAD R0.xyz, -R0, c[12].z, R1.yzww;
MUL R0.w, R2, c[10];
TXB R0.xyz, R0, texture[6], CUBE;
MUL R0.w, R1.x, c[1];
MUL R1.xyz, R4, R0;
MUL R0.xyz, R0.w, c[1];
MAD R0.xyz, R0, c[12].w, R1;
MAD R1.xyz, R3, R2, R5;
ADD result.color.xyz, R1, R0;
MOV result.color.w, c[9].x;
END
# 80 instructions, 6 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "LIGHTMAP_ON" "DIRLIGHTMAP_ON" "HDR_LIGHT_PREPASS_ON" }
Vector 0 [_Color]
Vector 1 [_IllumnColor]
Vector 2 [_MetalColor]
Vector 3 [_SkinColor]
Vector 4 [_ClothColor]
Float 5 [_Shininess]
Float 6 [_MetalShininess]
Float 7 [_SkinShininess]
Float 8 [_ClothShininess]
SetTexture 0 [_LightBuffer] 2D 0
SetTexture 1 [unity_Lightmap] 2D 1
SetTexture 2 [unity_LightmapInd] 2D 2
SetTexture 3 [_MainTex] 2D 3
SetTexture 4 [_MaskTex] 2D 4
SetTexture 5 [_BumpMap] 2D 5
SetTexture 6 [_Cube] CUBE 6
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
dcl_2d s3
dcl_2d s4
dcl_2d s5
dcl_cube s6
def c9, -0.40824828, -0.70710677, 0.57735026, 8.00000000
def c10, -0.40824831, 0.70710677, 0.57735026, -0.50000000
def c11, 0.81649655, 0.00000000, 0.57735026, 1.00000000
def c12, 0.03000000, 2.00000000, -1.00000000, 16.00000000
def c13, 0.30004883, 0.60009766, 0.09997559, 0.00000000
def c14, 0.12298584, 0, 0, 0
dcl_texcoord0 v0
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5.xy
mov_pp r0.xyz, c4
texld r1, v0, s4
add_pp r0.xyz, -c0, r0
mad_pp r0.xyz, r1.w, r0, c0
add_pp r3.xyz, -r0, c3
mad_pp r0.xyz, r1.z, r3, r0
add_pp r3.xyz, -r0, c2
mad_pp r3.xyz, r1.y, r3, r0
texld r0, v0, s3
mul r3.xyz, r0, r3
add r0.x, -r0.w, r1.w
mad r2.w, r1, r0.x, r0
mov_pp r0, c2
dp4_pp r0.x, c13, r0
add r3.w, r1.z, -r2
mad r0.w, r1.z, r3, r2
mov_pp r2.w, c8.x
dp3_pp_sat r5.z, r2, c9
dp3_pp_sat r5.x, r2, c11
dp3_pp_sat r5.y, r2, c10
mul r4.xyz, r3, r1.y
rcp r0.x, r0.x
mad r4.xyz, r4, r0.x, -r0.w
add r0.xyz, r1.yzww, c10.w
mad r4.xyz, r1.y, r4, r0.w
mov_pp r0.w, c4
add_pp r0.w, -c0, r0
cmp r0.xyz, r0, c11.w, c11.y
add_pp r2.w, -c5.x, r2
mad_pp r0.z, r0, r2.w, c5.x
mad_pp r1.w, r1, r0, c0
add_pp r0.w, -r0.z, c7.x
mad_pp r0.y, r0, r0.w, r0.z
add_pp r2.w, -r1, c3
mad_pp r0.w, r1.z, r2, r1
add_pp r0.z, -r0.y, c6.x
mad_pp r3.w, r0.x, r0.z, r0.y
add_pp r1.z, -r0.w, c2.w
mad_pp r0.y, r1, r1.z, r0.w
mad r0.x, r3.w, r3.w, c12
mul r1.y, r0.x, r0
mul r4.xyz, r1.y, r4
texld r0, v5, s2
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, r5
dp3_pp r2.x, r0, c9.w
texld r0, v5, s1
texld r1.yw, v0.zwzw, s5
mad_pp r1.yz, r1.xwyw, c12.y, c12.z
mul_pp r5.xy, r1.yzzw, r1.yzzw
mul_pp r0.xyz, r0.w, r0
mul_pp r0.xyz, r0, r2.x
mul_pp r2.xyz, r0, c9.w
add_pp_sat r1.w, r5.x, r5.y
add_pp r1.w, -r1, c11
rsq_pp r1.w, r1.w
texldp r0, v1, s0
mov_pp r2.w, c11
add_pp r2, r0, r2
rcp_pp r1.w, r1.w
mul r4.xyz, r4, c12.y
mul r5.xyz, r2.w, r4
dp3_pp r0.x, v2, r1.yzww
dp3_pp r0.y, r1.yzww, v3
dp3_pp r0.z, r1.yzww, v4
mov r1.y, v2.w
mov r1.z, v3.w
mov r1.w, v4
dp3 r0.w, r0, r1.yzww
mul r0.xyz, r0, r0.w
add r2.w, -r3, c11
mad r0.xyz, -r0, c12.y, r1.yzww
mul r0.w, r2, c9
texldb r0.xyz, r0, s6
mul r0.w, r1.x, c1
mul r1.xyz, r4, r0
mul r0.xyz, r0.w, c1
mad r0.xyz, r0, c12.w, r1
mad r1.xyz, r3, r2, r5
add oC0.xyz, r1, r0
mov_pp oC0.w, c14.x
"
}
}
 }
}
Fallback "Diffuse"
}