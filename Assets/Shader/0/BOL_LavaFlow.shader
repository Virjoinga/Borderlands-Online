ÝúShader "BOL/Scene/LavaFlow" {
Properties {
 _FlowLavaTex0 ("Flow Lava 0 (R Channel)", 2D) = "white" {}
 _FlowLavaTex1 ("Flow Lava 1 (R Channel)", 2D) = "white" {}
 _SoftCloudTex0 ("Soft Cloud 0 (B Channel)", 2D) = "white" {}
 _SoftCloudTex1 ("Soft Cloud 1 (B Channel)", 2D) = "white" {}
 _RockMaskTex ("Rock Mask (G Channel)", 2D) = "white" {}
 _LavaRockTex ("Lava Rock", 2D) = "white" {}
 _FlowRateRock ("Flow Rate Rock", Float) = 2
 _FlowRateLava ("Flow Rate Lava", Float) = 1.5
 _TileRateU ("Tile Rate U", Float) = 2
 _TileRateV ("Tile Rate V", Float) = 1
 _LavaPatternRate ("Lava Pattern Rate", Float) = 1
 _EmissivePower ("Emissive Power", Range(0,3)) = 1
 _MaskRangeCoeff ("Mask Range Coefficient", Float) = 0
 _LavaColor ("Lava Color", Color) = (1,1,1,1)
}
SubShader { 
 Tags { "QUEUE"="Geometry" "RenderType"="Opaque" }
 Pass {
  Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "QUEUE"="Geometry" "RenderType"="Opaque" }
Program "vp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddjaobeelpjjdmggipcgkfdgcpfgjemflabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
ajaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaa
afaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
ahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedeoildeffaekanbhpebbeankglchnngcbabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaadaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaa
aaaaaaaaadaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaa
kgiocaaaaaaaaaaaaiaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaa
agaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddjaobeelpjjdmggipcgkfdgcpfgjemflabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
ajaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaa
afaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
ahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedeoildeffaekanbhpebbeankglchnngcbabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaadaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaa
aaaaaaaaadaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaa
kgiocaaaaaaaaaaaaiaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaa
agaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddjaobeelpjjdmggipcgkfdgcpfgjemflabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
ajaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaa
afaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
ahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedeoildeffaekanbhpebbeankglchnngcbabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaadaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaa
aaaaaaaaadaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaa
kgiocaaaaaaaaaaaaiaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaa
agaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedanaibcbfcjjmoieafbafbgagohhbcejnabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
anaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaaaaaaaaaa
ajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
alaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaa
aaaaaaaaaiaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedhfjekedjgldaddnjpcnbofnocdfkloljabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaahaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaamaaaaaa
kgiocaaaaaaaaaaaamaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaa
akaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedanaibcbfcjjmoieafbafbgagohhbcejnabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
anaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaaaaaaaaaa
ajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
alaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaa
aaaaaaaaaiaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedhfjekedjgldaddnjpcnbofnocdfkloljabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaahaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaamaaaaaa
kgiocaaaaaaaaaaaamaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaa
akaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedanaibcbfcjjmoieafbafbgagohhbcejnabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
anaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaaaaaaaaaa
ajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
alaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaa
aaaaaaaaaiaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedhfjekedjgldaddnjpcnbofnocdfkloljabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaahaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaamaaaaaa
kgiocaaaaaaaaaaaamaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaa
akaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefieceddjaobeelpjjdmggipcgkfdgcpfgjemflabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
ajaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaadaaaaaaogikcaaaaaaaaaaaadaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaafaaaaaakgiocaaaaaaaaaaa
afaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
ahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaeaaaaaakgiocaaa
aaaaaaaaaeaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaagaaaaaaogikcaaaaaaaaaaaagaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 192
Vector 48 [_FlowLavaTex0_ST]
Vector 64 [_FlowLavaTex1_ST]
Vector 80 [_SoftCloudTex0_ST]
Vector 96 [_SoftCloudTex1_ST]
Vector 112 [_RockMaskTex_ST]
Vector 128 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedeoildeffaekanbhpebbeankglchnngcbabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaadaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaajaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaadaaaaaaogikcaaa
aaaaaaaaadaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaafaaaaaakgiocaaaaaaaaaaaafaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaa
kgiocaaaaaaaaaaaaiaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaeaaaaaakgiocaaaaaaaaaaaaeaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaagaaaaaaogikcaaaaaaaaaaa
agaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 5 [_Object2World]
Vector 9 [_FlowLavaTex0_ST]
Vector 10 [_FlowLavaTex1_ST]
Vector 11 [_SoftCloudTex0_ST]
Vector 12 [_SoftCloudTex1_ST]
Vector 13 [_RockMaskTex_ST]
Vector 14 [_LavaRockTex_ST]
"!!ARBvp1.0
PARAM c[15] = { program.local[0],
		state.matrix.mvp,
		program.local[5..14] };
MAD result.texcoord[0].zw, vertex.texcoord[0].xyxy, c[11].xyxy, c[11];
MAD result.texcoord[0].xy, vertex.texcoord[0], c[9], c[9].zwzw;
MAD result.texcoord[1].zw, vertex.texcoord[0].xyxy, c[14].xyxy, c[14];
MAD result.texcoord[1].xy, vertex.texcoord[0], c[13], c[13].zwzw;
MAD result.texcoord[2].xy, vertex.texcoord[0], c[12], c[12].zwzw;
MAD result.texcoord[2].zw, vertex.texcoord[0].xyxy, c[10].xyxy, c[10];
DP4 result.position.w, vertex.position, c[4];
DP4 result.position.z, vertex.position, c[3];
DP4 result.position.y, vertex.position, c[2];
DP4 result.position.x, vertex.position, c[1];
DP4 result.color.z, vertex.position, c[7];
DP4 result.color.y, vertex.position, c[6];
DP4 result.color.x, vertex.position, c[5];
END
# 13 instructions, 0 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [_Object2World]
Vector 8 [_FlowLavaTex0_ST]
Vector 9 [_FlowLavaTex1_ST]
Vector 10 [_SoftCloudTex0_ST]
Vector 11 [_SoftCloudTex1_ST]
Vector 12 [_RockMaskTex_ST]
Vector 13 [_LavaRockTex_ST]
"vs_2_0
dcl_position0 v0
dcl_texcoord0 v1
mad oT0.zw, v1.xyxy, c10.xyxy, c10
mad oT0.xy, v1, c8, c8.zwzw
mad oT1.zw, v1.xyxy, c13.xyxy, c13
mad oT1.xy, v1, c12, c12.zwzw
mad oT2.xy, v1, c11, c11.zwzw
mad oT2.zw, v1.xyxy, c9.xyxy, c9
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
dp4 oD0.z, v0, c6
dp4 oD0.y, v0, c5
dp4 oD0.x, v0, c4
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedanaibcbfcjjmoieafbafbgagohhbcejnabaaaaaapaadaaaaadaaaaaa
cmaaaaaaiaaaaaaaceabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaa
imaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaahaiaaaafdfgfpfaepfdejfeejepeoaafeeffiedepepfceeaaedepem
epfcaaklfdeieefcmeacaaaaeaaaabaalbaaaaaafjaaaaaeegiocaaaaaaaaaaa
anaaaaaafjaaaaaeegiocaaaabaaaaaabaaaaaaafpaaaaadpcbabaaaaaaaaaaa
fpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaaaaaaaaaaabaaaaaagfaaaaad
pccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaagfaaaaadpccabaaaadaaaaaa
gfaaaaadhccabaaaaeaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaa
egiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaak
pcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaa
aaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaaldccabaaaabaaaaaaegbabaaaabaaaaaa
egiacaaaaaaaaaaaahaaaaaaogikcaaaaaaaaaaaahaaaaaadcaaaaalmccabaaa
abaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaajaaaaaakgiocaaaaaaaaaaa
ajaaaaaadcaaaaaldccabaaaacaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaa
alaaaaaaogikcaaaaaaaaaaaalaaaaaadcaaaaalmccabaaaacaaaaaaagbebaaa
abaaaaaaagiecaaaaaaaaaaaamaaaaaakgiocaaaaaaaaaaaamaaaaaadcaaaaal
mccabaaaadaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaaiaaaaaakgiocaaa
aaaaaaaaaiaaaaaadcaaaaaldccabaaaadaaaaaaegbabaaaabaaaaaaegiacaaa
aaaaaaaaakaaaaaaogikcaaaaaaaaaaaakaaaaaadiaaaaaihcaabaaaaaaaaaaa
fgbfbaaaaaaaaaaaegiccaaaabaaaaaaanaaaaaadcaaaaakhcaabaaaaaaaaaaa
egiccaaaabaaaaaaamaaaaaaagbabaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaak
hcaabaaaaaaaaaaaegiccaaaabaaaaaaaoaaaaaakgbkbaaaaaaaaaaaegacbaaa
aaaaaaaadcaaaaakhccabaaaaeaaaaaaegiccaaaabaaaaaaapaaaaaapgbpbaaa
aaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" "VERTEXLIGHT_ON" }
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 256
Vector 112 [_FlowLavaTex0_ST]
Vector 128 [_FlowLavaTex1_ST]
Vector 144 [_SoftCloudTex0_ST]
Vector 160 [_SoftCloudTex1_ST]
Vector 176 [_RockMaskTex_ST]
Vector 192 [_LavaRockTex_ST]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
Matrix 192 [_Object2World]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0_level_9_1
eefiecedhfjekedjgldaddnjpcnbofnocdfkloljabaaaaaajiafaaaaaeaaaaaa
daaaaaaaneabaaaakaaeaaaapeaeaaaaebgpgodjjmabaaaajmabaaaaaaacpopp
faabaaaaemaaaaaaadaaceaaaaaaeiaaaaaaeiaaaaaaceaaabaaeiaaaaaaahaa
agaaabaaaaaaaaaaabaaaaaaaeaaahaaaaaaaaaaabaaamaaaeaaalaaaaaaaaaa
aaaaaaaaaaacpoppbpaaaaacafaaaaiaaaaaapjabpaaaaacafaaabiaabaaapja
afaaaaadaaaaahiaaaaaffjaamaaoekaaeaaaaaeaaaaahiaalaaoekaaaaaaaja
aaaaoeiaaeaaaaaeaaaaahiaanaaoekaaaaakkjaaaaaoeiaaeaaaaaeadaaahoa
aoaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadoaabaaoejaabaaoekaabaaooka
aeaaaaaeacaaamoaabaaeejaacaaeekaacaaoekaaeaaaaaeaaaaamoaabaaeeja
adaaeekaadaaoekaaeaaaaaeacaaadoaabaaoejaaeaaoekaaeaaookaaeaaaaae
abaaadoaabaaoejaafaaoekaafaaookaaeaaaaaeabaaamoaabaaeejaagaaeeka
agaaoekaafaaaaadaaaaapiaaaaaffjaaiaaoekaaeaaaaaeaaaaapiaahaaoeka
aaaaaajaaaaaoeiaaeaaaaaeaaaaapiaajaaoekaaaaakkjaaaaaoeiaaeaaaaae
aaaaapiaakaaoekaaaaappjaaaaaoeiaaeaaaaaeaaaaadmaaaaappiaaaaaoeka
aaaaoeiaabaaaaacaaaaammaaaaaoeiappppaaaafdeieefcmeacaaaaeaaaabaa
lbaaaaaafjaaaaaeegiocaaaaaaaaaaaanaaaaaafjaaaaaeegiocaaaabaaaaaa
baaaaaaafpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaae
pccabaaaaaaaaaaaabaaaaaagfaaaaadpccabaaaabaaaaaagfaaaaadpccabaaa
acaaaaaagfaaaaadpccabaaaadaaaaaagfaaaaadhccabaaaaeaaaaaagiaaaaac
abaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaa
abaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaa
aaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaa
acaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaa
egiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaal
dccabaaaabaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaahaaaaaaogikcaaa
aaaaaaaaahaaaaaadcaaaaalmccabaaaabaaaaaaagbebaaaabaaaaaaagiecaaa
aaaaaaaaajaaaaaakgiocaaaaaaaaaaaajaaaaaadcaaaaaldccabaaaacaaaaaa
egbabaaaabaaaaaaegiacaaaaaaaaaaaalaaaaaaogikcaaaaaaaaaaaalaaaaaa
dcaaaaalmccabaaaacaaaaaaagbebaaaabaaaaaaagiecaaaaaaaaaaaamaaaaaa
kgiocaaaaaaaaaaaamaaaaaadcaaaaalmccabaaaadaaaaaaagbebaaaabaaaaaa
agiecaaaaaaaaaaaaiaaaaaakgiocaaaaaaaaaaaaiaaaaaadcaaaaaldccabaaa
adaaaaaaegbabaaaabaaaaaaegiacaaaaaaaaaaaakaaaaaaogikcaaaaaaaaaaa
akaaaaaadiaaaaaihcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiccaaaabaaaaaa
anaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaaamaaaaaaagbabaaa
aaaaaaaaegacbaaaaaaaaaaadcaaaaakhcaabaaaaaaaaaaaegiccaaaabaaaaaa
aoaaaaaakgbkbaaaaaaaaaaaegacbaaaaaaaaaaadcaaaaakhccabaaaaeaaaaaa
egiccaaaabaaaaaaapaaaaaapgbpbaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab
ejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaaaaaaaaaaaaaaaaaaadaaaaaa
aaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadadaaaa
faepfdejfeejepeoaafeeffiedepepfceeaaklklepfdeheojmaaaaaaafaaaaaa
aiaaaaaaiaaaaaaaaaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaabaaaaaaapaaaaaaimaaaaaaabaaaaaaaaaaaaaa
adaaaaaaacaaaaaaapaaaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaa
apaaaaaajfaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahaiaaaafdfgfpfa
epfdejfeejepeoaafeeffiedepepfceeaaedepemepfcaakl"
}
}
Program "fp" {
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 1, 0, 0.050000001, 0.5 },
		{ 0, 0.02, 0.2, 20 },
		{ 0.0020000001, 3 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.zw, fragment.texcoord[2].xyxy, c[10].xyxy;
MOV R0.y, c[4].x;
MOV R0.x, c[3];
MAD R1.xy, fragment.texcoord[0].zwzw, R0, c[9].yzzw;
MOV result.color.w, c[9].x;
TEX R0.z, R0.zwzw, texture[1], 2D;
TEX R1.z, R1, texture[1], 2D;
MUL R1.x, fragment.color.primary, c[11];
MOV R0.w, c[9];
MAD R0.w, R0, c[0].y, R1.x;
SIN R0.w, R0.w;
MUL R2.xy, R0.w, c[10];
MOV R0.w, c[1].x;
MUL R0.w, R0, c[0].y;
MAD R1.xy, fragment.texcoord[1], R0, R2;
MAD R2.zw, fragment.texcoord[0].xyxy, R0.xyxy, R2.xyxy;
MAD R2.xy, fragment.texcoord[1].zwzw, R0, R2;
MAD R0.xy, R0.w, c[9].yzzw, R2.zwzw;
MAD R2.xy, R0.w, c[9].yzzw, R2;
MAD R1.xy, R0.w, c[9].yzzw, R1;
MUL R1.z, R1, c[9].w;
MUL R1.w, R0.z, c[9];
ADD R0.zw, fragment.texcoord[2], R1;
MOV R2.z, c[0].y;
MUL R1.z, R2, c[2].x;
MAD R0.zw, R1.z, c[10].xyxz, R0;
TEX R0.x, R0, texture[1], 2D;
TEX R0.y, R1, texture[1], 2D;
TEX R3.xyz, R2, texture[0], 2D;
TEX R2.x, R0.zwzw, texture[1], 2D;
TEX R1.x, fragment.texcoord[0], texture[1], 2D;
MUL R0.z, R1.x, R2.x;
MUL R0.w, R0.x, R0.y;
POW R0.z, R0.z, c[5].x;
MUL R0.z, R0, c[6].x;
MUL R0.xyz, R0.z, c[8];
MUL R0.xyz, R0, c[10].w;
MUL_SAT R0.w, R0, c[11].y;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R3, c[10].z, -R0;
ADD R0.w, R0, c[9].x;
MAD result.color.xyz, R0.w, R1, R0;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c9, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c10, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c11, 0.00000000, 0.05000000, 0.02000000, 0.20000000
def c12, 20.00000000, 0.00200000, 0.15915491, 0.50000000
def c13, 6.28318501, -3.14159298, 3.00000000, 0
dcl t0
dcl t1
dcl t2
dcl v0.x
mov r4.y, c4.x
mov r4.x, c3
mov r6.x, t2.z
mov r6.y, t2.w
mov r0.y, c11.z
mov r0.x, c11
add r0.xy, t2, r0
mov r1.x, t0.z
mov r1.y, t0.w
mad r1.xy, r1, r4, c11
texld r0, r0, s1
texld r1, r1, s1
mov r0.y, c0
mul r0.x, v0, c12.y
mad r0.x, c9.w, r0.y, r0
mad r0.x, r0, c12.z, c12.w
frc r0.x, r0
mad r0.x, r0, c13, c13.y
sincos r2.xy, r0.x, c10.xyzw, c9.xyzw
mov r0.y, c11.z
mov r0.x, c11
mul r5.xy, r2.y, r0
mov r0.y, c0
mul r0.x, c1, r0.y
mul r2.y, r0.z, c9.w
mov r1.x, t1.z
mov r1.y, t1.w
mad r1.xy, r1, r4, r5
mad r3.xy, r0.x, c11, r1
mul r2.x, r1.z, c9.w
add r2.xy, r6, r2
mov r1.x, c2
mul r1.x, c0.y, r1
mov r6.x, c11
mov r6.y, c11.w
mad r2.xy, r1.x, r6, r2
mad r1.xy, t1, r4, r5
mad r5.xy, t0, r4, r5
mad r4.xy, r0.x, c11, r1
mad r0.xy, r0.x, c11, r5
texld r1, r3, s0
texld r3, r0, s1
texld r0, r4, s1
texld r2, r2, s1
texld r4, t0, s1
mul r0.x, r4, r2
pow r2.w, r0.x, c5.x
mov r0.x, r2.w
mul r2.x, r0, c6
mul r0.x, r3, r0.y
mul r2.xyz, r2.x, c8
mul_sat r0.x, r0, c13.z
add r0.x, -r0, c7
mul r2.xyz, r2, c12.x
mad r1.xyz, r1, c11.w, -r2
add r0.x, r0, c9.z
mad r0.xyz, r0.x, r1, r2
mov r0.w, c9.z
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 192
Float 144 [_FlowRateRock]
Float 148 [_FlowRateLava]
Float 152 [_TileRateU]
Float 156 [_TileRateV]
Float 160 [_LavaPatternRate]
Float 164 [_EmissivePower]
Float 168 [_MaskRangeCoeff]
Vector 176 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedhcjmhbkhknebefffgmloebpphakjpnanabaaaaaaimagaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
amaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaajaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaajaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaakaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaakaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaajaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaajaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaakaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 192
Float 144 [_FlowRateRock]
Float 148 [_FlowRateLava]
Float 152 [_TileRateU]
Float 156 [_TileRateV]
Float 160 [_LavaPatternRate]
Float 164 [_EmissivePower]
Float 168 [_MaskRangeCoeff]
Vector 176 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedfogicmlmoacapnjhkhndipfijecbojmmabaaaaaaoeakaaaaaeaaaaaa
daaaaaaaieaeaaaaamakaaaalaakaaaaebgpgodjemaeaaaaemaeaaaaaaacpppp
aiaeaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaajaaadaaaaaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkagpbcaddlaaaaaadpidpjccdoaaaaeaeafbaaaaafafaaapka
nlapmjeanlapejmaaknhkddmaaaaaaaafbaaaaafagaaapkaaaaaaaaamnmmemdn
aaaaiadpaaaakaebfbaaaaafahaaapkaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaa
fbaaaaafaiaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafajaaapka
klkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaahla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaacaaaaadia
agaaoekaaeaaaaaeabaaabiaaaaakklaaaaakkkaaaaaaaiaaeaaaaaeabaaacia
aaaapplaaaaappkaaaaaffiaacaaaaadaaaaadiaacaaoelaafaablkaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaaeaaaaae
aaaaabiaabaakkiaaeaaffkaacaakklaaeaaaaaeaaaaaciaaaaakkiaaeaaffka
acaapplaabaaaaacabaaadiaaaaaoekaafaaaaadaaaaaeiaabaaffiaadaaffka
aeaaaaaeaaaaadiaaaaakkiaahaaoekaaaaaoeiaafaaaaadaaaaaeiaadaaaala
aeaaaakaabaaaaacaaaaaiiaaeaaffkaaeaaaaaeaaaaaeiaadaaffkaaaaappia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaaeaakkkaaeaaffkabdaaaaacaaaaaeia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaafaaaakaafaaffkacfaaaaaeacaaacia
aaaakkiaaiaaoekaajaaoekaafaaaaadaaaaamiaacaaffiaafaaoekaaeaaaaae
acaaabiaaaaaaalaaaaakkkaaaaappiaaeaaaaaeacaaaciaaaaafflaaaaappka
aaaakkiaafaaaaadabaaabiaabaaaaiaadaaffkaaeaaaaaeacaaadiaabaaaaia
agaaoekaacaaoeiaaeaaaaaeadaaabiaabaaaalaaaaakkkaaaaappiaaeaaaaae
adaaaciaabaafflaaaaappkaaaaakkiaaeaaaaaeaeaaabiaabaakklaaaaakkka
aaaappiaaeaaaaaeaeaaaciaabaapplaaaaappkaaaaakkiaaeaaaaaeaeaaadia
abaaaaiaagaaoekaaeaaoeiaaeaaaaaeabaaadiaabaaaaiaagaaoekaadaaoeia
ecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadadaaapiaaaaaoelaaaaioeka
ecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaadabaaapiaabaaoeiaaaaioeka
ecaaaaadaeaaapiaaeaaoeiaabaioekaafaaaaadaeaaaiiaaaaaaaiaadaaaaia
caaaaaadaaaaabiaaeaappiaabaaaakaafaaaaadaeaaaiiaaaaaaaiaabaaffka
afaaaaadaeaaaiiaaeaappiaagaappkaafaaaaadaaaaahiaaeaappiaacaaoeka
afaaaaadaaaaaiiaabaaffiaacaaaaiaafaaaaadaaaabiiaaaaappiaaeaappka
acaaaaadaaaaaiiaaaaappibabaakkkaacaaaaadaaaaaiiaaaaappiaagaakkka
aeaaaaaeabaaahiaaeaaoeiaahaaffkaaaaaoeibaeaaaaaeaaaaahiaaaaappia
abaaoeiaaaaaoeiaabaaaaacaaaaaiiaagaakkkaabaaaaacaaaiapiaaaaaoeia
ppppaaaafdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
amaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaajaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaajaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaakaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaakaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaajaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaajaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaakaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 1, 0, 0.050000001, 0.5 },
		{ 0, 0.02, 0.2, 20 },
		{ 0.0020000001, 3 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.zw, fragment.texcoord[2].xyxy, c[10].xyxy;
MOV R0.y, c[4].x;
MOV R0.x, c[3];
MAD R1.xy, fragment.texcoord[0].zwzw, R0, c[9].yzzw;
MOV result.color.w, c[9].x;
TEX R0.z, R0.zwzw, texture[1], 2D;
TEX R1.z, R1, texture[1], 2D;
MUL R1.x, fragment.color.primary, c[11];
MOV R0.w, c[9];
MAD R0.w, R0, c[0].y, R1.x;
SIN R0.w, R0.w;
MUL R2.xy, R0.w, c[10];
MOV R0.w, c[1].x;
MUL R0.w, R0, c[0].y;
MAD R1.xy, fragment.texcoord[1], R0, R2;
MAD R2.zw, fragment.texcoord[0].xyxy, R0.xyxy, R2.xyxy;
MAD R2.xy, fragment.texcoord[1].zwzw, R0, R2;
MAD R0.xy, R0.w, c[9].yzzw, R2.zwzw;
MAD R2.xy, R0.w, c[9].yzzw, R2;
MAD R1.xy, R0.w, c[9].yzzw, R1;
MUL R1.z, R1, c[9].w;
MUL R1.w, R0.z, c[9];
ADD R0.zw, fragment.texcoord[2], R1;
MOV R2.z, c[0].y;
MUL R1.z, R2, c[2].x;
MAD R0.zw, R1.z, c[10].xyxz, R0;
TEX R0.x, R0, texture[1], 2D;
TEX R0.y, R1, texture[1], 2D;
TEX R3.xyz, R2, texture[0], 2D;
TEX R2.x, R0.zwzw, texture[1], 2D;
TEX R1.x, fragment.texcoord[0], texture[1], 2D;
MUL R0.z, R1.x, R2.x;
MUL R0.w, R0.x, R0.y;
POW R0.z, R0.z, c[5].x;
MUL R0.z, R0, c[6].x;
MUL R0.xyz, R0.z, c[8];
MUL R0.xyz, R0, c[10].w;
MUL_SAT R0.w, R0, c[11].y;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R3, c[10].z, -R0;
ADD R0.w, R0, c[9].x;
MAD result.color.xyz, R0.w, R1, R0;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c9, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c10, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c11, 0.00000000, 0.05000000, 0.02000000, 0.20000000
def c12, 20.00000000, 0.00200000, 0.15915491, 0.50000000
def c13, 6.28318501, -3.14159298, 3.00000000, 0
dcl t0
dcl t1
dcl t2
dcl v0.x
mov r4.y, c4.x
mov r4.x, c3
mov r6.x, t2.z
mov r6.y, t2.w
mov r0.y, c11.z
mov r0.x, c11
add r0.xy, t2, r0
mov r1.x, t0.z
mov r1.y, t0.w
mad r1.xy, r1, r4, c11
texld r0, r0, s1
texld r1, r1, s1
mov r0.y, c0
mul r0.x, v0, c12.y
mad r0.x, c9.w, r0.y, r0
mad r0.x, r0, c12.z, c12.w
frc r0.x, r0
mad r0.x, r0, c13, c13.y
sincos r2.xy, r0.x, c10.xyzw, c9.xyzw
mov r0.y, c11.z
mov r0.x, c11
mul r5.xy, r2.y, r0
mov r0.y, c0
mul r0.x, c1, r0.y
mul r2.y, r0.z, c9.w
mov r1.x, t1.z
mov r1.y, t1.w
mad r1.xy, r1, r4, r5
mad r3.xy, r0.x, c11, r1
mul r2.x, r1.z, c9.w
add r2.xy, r6, r2
mov r1.x, c2
mul r1.x, c0.y, r1
mov r6.x, c11
mov r6.y, c11.w
mad r2.xy, r1.x, r6, r2
mad r1.xy, t1, r4, r5
mad r5.xy, t0, r4, r5
mad r4.xy, r0.x, c11, r1
mad r0.xy, r0.x, c11, r5
texld r1, r3, s0
texld r3, r0, s1
texld r0, r4, s1
texld r2, r2, s1
texld r4, t0, s1
mul r0.x, r4, r2
pow r2.w, r0.x, c5.x
mov r0.x, r2.w
mul r2.x, r0, c6
mul r0.x, r3, r0.y
mul r2.xyz, r2.x, c8
mul_sat r0.x, r0, c13.z
add r0.x, -r0, c7
mul r2.xyz, r2, c12.x
mad r1.xyz, r1, c11.w, -r2
add r0.x, r0, c9.z
mad r0.xyz, r0.x, r1, r2
mov r0.w, c9.z
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 192
Float 144 [_FlowRateRock]
Float 148 [_FlowRateLava]
Float 152 [_TileRateU]
Float 156 [_TileRateV]
Float 160 [_LavaPatternRate]
Float 164 [_EmissivePower]
Float 168 [_MaskRangeCoeff]
Vector 176 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedhcjmhbkhknebefffgmloebpphakjpnanabaaaaaaimagaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
amaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaajaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaajaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaakaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaakaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaajaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaajaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaakaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 192
Float 144 [_FlowRateRock]
Float 148 [_FlowRateLava]
Float 152 [_TileRateU]
Float 156 [_TileRateV]
Float 160 [_LavaPatternRate]
Float 164 [_EmissivePower]
Float 168 [_MaskRangeCoeff]
Vector 176 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedfogicmlmoacapnjhkhndipfijecbojmmabaaaaaaoeakaaaaaeaaaaaa
daaaaaaaieaeaaaaamakaaaalaakaaaaebgpgodjemaeaaaaemaeaaaaaaacpppp
aiaeaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaajaaadaaaaaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkagpbcaddlaaaaaadpidpjccdoaaaaeaeafbaaaaafafaaapka
nlapmjeanlapejmaaknhkddmaaaaaaaafbaaaaafagaaapkaaaaaaaaamnmmemdn
aaaaiadpaaaakaebfbaaaaafahaaapkaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaa
fbaaaaafaiaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafajaaapka
klkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaahla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaacaaaaadia
agaaoekaaeaaaaaeabaaabiaaaaakklaaaaakkkaaaaaaaiaaeaaaaaeabaaacia
aaaapplaaaaappkaaaaaffiaacaaaaadaaaaadiaacaaoelaafaablkaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaaeaaaaae
aaaaabiaabaakkiaaeaaffkaacaakklaaeaaaaaeaaaaaciaaaaakkiaaeaaffka
acaapplaabaaaaacabaaadiaaaaaoekaafaaaaadaaaaaeiaabaaffiaadaaffka
aeaaaaaeaaaaadiaaaaakkiaahaaoekaaaaaoeiaafaaaaadaaaaaeiaadaaaala
aeaaaakaabaaaaacaaaaaiiaaeaaffkaaeaaaaaeaaaaaeiaadaaffkaaaaappia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaaeaakkkaaeaaffkabdaaaaacaaaaaeia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaafaaaakaafaaffkacfaaaaaeacaaacia
aaaakkiaaiaaoekaajaaoekaafaaaaadaaaaamiaacaaffiaafaaoekaaeaaaaae
acaaabiaaaaaaalaaaaakkkaaaaappiaaeaaaaaeacaaaciaaaaafflaaaaappka
aaaakkiaafaaaaadabaaabiaabaaaaiaadaaffkaaeaaaaaeacaaadiaabaaaaia
agaaoekaacaaoeiaaeaaaaaeadaaabiaabaaaalaaaaakkkaaaaappiaaeaaaaae
adaaaciaabaafflaaaaappkaaaaakkiaaeaaaaaeaeaaabiaabaakklaaaaakkka
aaaappiaaeaaaaaeaeaaaciaabaapplaaaaappkaaaaakkiaaeaaaaaeaeaaadia
abaaaaiaagaaoekaaeaaoeiaaeaaaaaeabaaadiaabaaaaiaagaaoekaadaaoeia
ecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadadaaapiaaaaaoelaaaaioeka
ecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaadabaaapiaabaaoeiaaaaioeka
ecaaaaadaeaaapiaaeaaoeiaabaioekaafaaaaadaeaaaiiaaaaaaaiaadaaaaia
caaaaaadaaaaabiaaeaappiaabaaaakaafaaaaadaeaaaiiaaaaaaaiaabaaffka
afaaaaadaeaaaiiaaeaappiaagaappkaafaaaaadaaaaahiaaeaappiaacaaoeka
afaaaaadaaaaaiiaabaaffiaacaaaaiaafaaaaadaaaabiiaaaaappiaaeaappka
acaaaaadaaaaaiiaaaaappibabaakkkaacaaaaadaaaaaiiaaaaappiaagaakkka
aeaaaaaeabaaahiaaeaaoeiaahaaffkaaaaaoeibaeaaaaaeaaaaahiaaaaappia
abaaoeiaaaaaoeiaabaaaaacaaaaaiiaagaakkkaabaaaaacaaaiapiaaaaaoeia
ppppaaaafdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
amaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaajaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaajaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaakaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaakaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaajaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaajaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaakaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 1, 0, 0.050000001, 0.5 },
		{ 0, 0.02, 0.2, 20 },
		{ 0.0020000001, 3 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.zw, fragment.texcoord[2].xyxy, c[10].xyxy;
MOV R0.y, c[4].x;
MOV R0.x, c[3];
MAD R1.xy, fragment.texcoord[0].zwzw, R0, c[9].yzzw;
MOV result.color.w, c[9].x;
TEX R0.z, R0.zwzw, texture[1], 2D;
TEX R1.z, R1, texture[1], 2D;
MUL R1.x, fragment.color.primary, c[11];
MOV R0.w, c[9];
MAD R0.w, R0, c[0].y, R1.x;
SIN R0.w, R0.w;
MUL R2.xy, R0.w, c[10];
MOV R0.w, c[1].x;
MUL R0.w, R0, c[0].y;
MAD R1.xy, fragment.texcoord[1], R0, R2;
MAD R2.zw, fragment.texcoord[0].xyxy, R0.xyxy, R2.xyxy;
MAD R2.xy, fragment.texcoord[1].zwzw, R0, R2;
MAD R0.xy, R0.w, c[9].yzzw, R2.zwzw;
MAD R2.xy, R0.w, c[9].yzzw, R2;
MAD R1.xy, R0.w, c[9].yzzw, R1;
MUL R1.z, R1, c[9].w;
MUL R1.w, R0.z, c[9];
ADD R0.zw, fragment.texcoord[2], R1;
MOV R2.z, c[0].y;
MUL R1.z, R2, c[2].x;
MAD R0.zw, R1.z, c[10].xyxz, R0;
TEX R0.x, R0, texture[1], 2D;
TEX R0.y, R1, texture[1], 2D;
TEX R3.xyz, R2, texture[0], 2D;
TEX R2.x, R0.zwzw, texture[1], 2D;
TEX R1.x, fragment.texcoord[0], texture[1], 2D;
MUL R0.z, R1.x, R2.x;
MUL R0.w, R0.x, R0.y;
POW R0.z, R0.z, c[5].x;
MUL R0.z, R0, c[6].x;
MUL R0.xyz, R0.z, c[8];
MUL R0.xyz, R0, c[10].w;
MUL_SAT R0.w, R0, c[11].y;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R3, c[10].z, -R0;
ADD R0.w, R0, c[9].x;
MAD result.color.xyz, R0.w, R1, R0;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c9, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c10, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c11, 0.00000000, 0.05000000, 0.02000000, 0.20000000
def c12, 20.00000000, 0.00200000, 0.15915491, 0.50000000
def c13, 6.28318501, -3.14159298, 3.00000000, 0
dcl t0
dcl t1
dcl t2
dcl v0.x
mov r4.y, c4.x
mov r4.x, c3
mov r6.x, t2.z
mov r6.y, t2.w
mov r0.y, c11.z
mov r0.x, c11
add r0.xy, t2, r0
mov r1.x, t0.z
mov r1.y, t0.w
mad r1.xy, r1, r4, c11
texld r0, r0, s1
texld r1, r1, s1
mov r0.y, c0
mul r0.x, v0, c12.y
mad r0.x, c9.w, r0.y, r0
mad r0.x, r0, c12.z, c12.w
frc r0.x, r0
mad r0.x, r0, c13, c13.y
sincos r2.xy, r0.x, c10.xyzw, c9.xyzw
mov r0.y, c11.z
mov r0.x, c11
mul r5.xy, r2.y, r0
mov r0.y, c0
mul r0.x, c1, r0.y
mul r2.y, r0.z, c9.w
mov r1.x, t1.z
mov r1.y, t1.w
mad r1.xy, r1, r4, r5
mad r3.xy, r0.x, c11, r1
mul r2.x, r1.z, c9.w
add r2.xy, r6, r2
mov r1.x, c2
mul r1.x, c0.y, r1
mov r6.x, c11
mov r6.y, c11.w
mad r2.xy, r1.x, r6, r2
mad r1.xy, t1, r4, r5
mad r5.xy, t0, r4, r5
mad r4.xy, r0.x, c11, r1
mad r0.xy, r0.x, c11, r5
texld r1, r3, s0
texld r3, r0, s1
texld r0, r4, s1
texld r2, r2, s1
texld r4, t0, s1
mul r0.x, r4, r2
pow r2.w, r0.x, c5.x
mov r0.x, r2.w
mul r2.x, r0, c6
mul r0.x, r3, r0.y
mul r2.xyz, r2.x, c8
mul_sat r0.x, r0, c13.z
add r0.x, -r0, c7
mul r2.xyz, r2, c12.x
mad r1.xyz, r1, c11.w, -r2
add r0.x, r0, c9.z
mad r0.xyz, r0.x, r1, r2
mov r0.w, c9.z
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 192
Float 144 [_FlowRateRock]
Float 148 [_FlowRateLava]
Float 152 [_TileRateU]
Float 156 [_TileRateV]
Float 160 [_LavaPatternRate]
Float 164 [_EmissivePower]
Float 168 [_MaskRangeCoeff]
Vector 176 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedhcjmhbkhknebefffgmloebpphakjpnanabaaaaaaimagaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
amaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaajaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaajaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaakaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaakaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaajaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaajaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaakaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_OFF" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 192
Float 144 [_FlowRateRock]
Float 148 [_FlowRateLava]
Float 152 [_TileRateU]
Float 156 [_TileRateV]
Float 160 [_LavaPatternRate]
Float 164 [_EmissivePower]
Float 168 [_MaskRangeCoeff]
Vector 176 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedfogicmlmoacapnjhkhndipfijecbojmmabaaaaaaoeakaaaaaeaaaaaa
daaaaaaaieaeaaaaamakaaaalaakaaaaebgpgodjemaeaaaaemaeaaaaaaacpppp
aiaeaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaajaaadaaaaaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkagpbcaddlaaaaaadpidpjccdoaaaaeaeafbaaaaafafaaapka
nlapmjeanlapejmaaknhkddmaaaaaaaafbaaaaafagaaapkaaaaaaaaamnmmemdn
aaaaiadpaaaakaebfbaaaaafahaaapkaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaa
fbaaaaafaiaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafajaaapka
klkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaahla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaacaaaaadia
agaaoekaaeaaaaaeabaaabiaaaaakklaaaaakkkaaaaaaaiaaeaaaaaeabaaacia
aaaapplaaaaappkaaaaaffiaacaaaaadaaaaadiaacaaoelaafaablkaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaaeaaaaae
aaaaabiaabaakkiaaeaaffkaacaakklaaeaaaaaeaaaaaciaaaaakkiaaeaaffka
acaapplaabaaaaacabaaadiaaaaaoekaafaaaaadaaaaaeiaabaaffiaadaaffka
aeaaaaaeaaaaadiaaaaakkiaahaaoekaaaaaoeiaafaaaaadaaaaaeiaadaaaala
aeaaaakaabaaaaacaaaaaiiaaeaaffkaaeaaaaaeaaaaaeiaadaaffkaaaaappia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaaeaakkkaaeaaffkabdaaaaacaaaaaeia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaafaaaakaafaaffkacfaaaaaeacaaacia
aaaakkiaaiaaoekaajaaoekaafaaaaadaaaaamiaacaaffiaafaaoekaaeaaaaae
acaaabiaaaaaaalaaaaakkkaaaaappiaaeaaaaaeacaaaciaaaaafflaaaaappka
aaaakkiaafaaaaadabaaabiaabaaaaiaadaaffkaaeaaaaaeacaaadiaabaaaaia
agaaoekaacaaoeiaaeaaaaaeadaaabiaabaaaalaaaaakkkaaaaappiaaeaaaaae
adaaaciaabaafflaaaaappkaaaaakkiaaeaaaaaeaeaaabiaabaakklaaaaakkka
aaaappiaaeaaaaaeaeaaaciaabaapplaaaaappkaaaaakkiaaeaaaaaeaeaaadia
abaaaaiaagaaoekaaeaaoeiaaeaaaaaeabaaadiaabaaaaiaagaaoekaadaaoeia
ecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadadaaapiaaaaaoelaaaaioeka
ecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaadabaaapiaabaaoeiaaaaioeka
ecaaaaadaeaaapiaaeaaoeiaabaioekaafaaaaadaeaaaiiaaaaaaaiaadaaaaia
caaaaaadaaaaabiaaeaappiaabaaaakaafaaaaadaeaaaiiaaaaaaaiaabaaffka
afaaaaadaeaaaiiaaeaappiaagaappkaafaaaaadaaaaahiaaeaappiaacaaoeka
afaaaaadaaaaaiiaabaaffiaacaaaaiaafaaaaadaaaabiiaaaaappiaaeaappka
acaaaaadaaaaaiiaaaaappibabaakkkaacaaaaadaaaaaiiaaaaappiaagaakkka
aeaaaaaeabaaahiaaeaaoeiaahaaffkaaaaaoeibaeaaaaaeaaaaahiaaaaappia
abaaoeiaaaaaoeiaabaaaaacaaaaaiiaagaakkkaabaaaaacaaaiapiaaaaaoeia
ppppaaaafdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
amaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaajaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaajaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaakaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaakaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
alaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaajaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaajaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaakaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 1, 0, 0.050000001, 0.5 },
		{ 0, 0.02, 0.2, 20 },
		{ 0.0020000001, 3 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.zw, fragment.texcoord[2].xyxy, c[10].xyxy;
MOV R0.y, c[4].x;
MOV R0.x, c[3];
MAD R1.xy, fragment.texcoord[0].zwzw, R0, c[9].yzzw;
MOV result.color.w, c[9].x;
TEX R0.z, R0.zwzw, texture[1], 2D;
TEX R1.z, R1, texture[1], 2D;
MUL R1.x, fragment.color.primary, c[11];
MOV R0.w, c[9];
MAD R0.w, R0, c[0].y, R1.x;
SIN R0.w, R0.w;
MUL R2.xy, R0.w, c[10];
MOV R0.w, c[1].x;
MUL R0.w, R0, c[0].y;
MAD R1.xy, fragment.texcoord[1], R0, R2;
MAD R2.zw, fragment.texcoord[0].xyxy, R0.xyxy, R2.xyxy;
MAD R2.xy, fragment.texcoord[1].zwzw, R0, R2;
MAD R0.xy, R0.w, c[9].yzzw, R2.zwzw;
MAD R2.xy, R0.w, c[9].yzzw, R2;
MAD R1.xy, R0.w, c[9].yzzw, R1;
MUL R1.z, R1, c[9].w;
MUL R1.w, R0.z, c[9];
ADD R0.zw, fragment.texcoord[2], R1;
MOV R2.z, c[0].y;
MUL R1.z, R2, c[2].x;
MAD R0.zw, R1.z, c[10].xyxz, R0;
TEX R0.x, R0, texture[1], 2D;
TEX R0.y, R1, texture[1], 2D;
TEX R3.xyz, R2, texture[0], 2D;
TEX R2.x, R0.zwzw, texture[1], 2D;
TEX R1.x, fragment.texcoord[0], texture[1], 2D;
MUL R0.z, R1.x, R2.x;
MUL R0.w, R0.x, R0.y;
POW R0.z, R0.z, c[5].x;
MUL R0.z, R0, c[6].x;
MUL R0.xyz, R0.z, c[8];
MUL R0.xyz, R0, c[10].w;
MUL_SAT R0.w, R0, c[11].y;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R3, c[10].z, -R0;
ADD R0.w, R0, c[9].x;
MAD result.color.xyz, R0.w, R1, R0;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c9, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c10, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c11, 0.00000000, 0.05000000, 0.02000000, 0.20000000
def c12, 20.00000000, 0.00200000, 0.15915491, 0.50000000
def c13, 6.28318501, -3.14159298, 3.00000000, 0
dcl t0
dcl t1
dcl t2
dcl v0.x
mov r4.y, c4.x
mov r4.x, c3
mov r6.x, t2.z
mov r6.y, t2.w
mov r0.y, c11.z
mov r0.x, c11
add r0.xy, t2, r0
mov r1.x, t0.z
mov r1.y, t0.w
mad r1.xy, r1, r4, c11
texld r0, r0, s1
texld r1, r1, s1
mov r0.y, c0
mul r0.x, v0, c12.y
mad r0.x, c9.w, r0.y, r0
mad r0.x, r0, c12.z, c12.w
frc r0.x, r0
mad r0.x, r0, c13, c13.y
sincos r2.xy, r0.x, c10.xyzw, c9.xyzw
mov r0.y, c11.z
mov r0.x, c11
mul r5.xy, r2.y, r0
mov r0.y, c0
mul r0.x, c1, r0.y
mul r2.y, r0.z, c9.w
mov r1.x, t1.z
mov r1.y, t1.w
mad r1.xy, r1, r4, r5
mad r3.xy, r0.x, c11, r1
mul r2.x, r1.z, c9.w
add r2.xy, r6, r2
mov r1.x, c2
mul r1.x, c0.y, r1
mov r6.x, c11
mov r6.y, c11.w
mad r2.xy, r1.x, r6, r2
mad r1.xy, t1, r4, r5
mad r5.xy, t0, r4, r5
mad r4.xy, r0.x, c11, r1
mad r0.xy, r0.x, c11, r5
texld r1, r3, s0
texld r3, r0, s1
texld r0, r4, s1
texld r2, r2, s1
texld r4, t0, s1
mul r0.x, r4, r2
pow r2.w, r0.x, c5.x
mov r0.x, r2.w
mul r2.x, r0, c6
mul r0.x, r3, r0.y
mul r2.xyz, r2.x, c8
mul_sat r0.x, r0, c13.z
add r0.x, -r0, c7
mul r2.xyz, r2, c12.x
mad r1.xyz, r1, c11.w, -r2
add r0.x, r0, c9.z
mad r0.xyz, r0.x, r1, r2
mov r0.w, c9.z
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 256
Float 208 [_FlowRateRock]
Float 212 [_FlowRateLava]
Float 216 [_TileRateU]
Float 220 [_TileRateV]
Float 224 [_LavaPatternRate]
Float 228 [_EmissivePower]
Float 232 [_MaskRangeCoeff]
Vector 240 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedojpnlceekckgemjccebbgmkgkcmhkhifabaaaaaaimagaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
baaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaanaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaanaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaaoaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaaoaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
apaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaanaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaanaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaaoaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_OFF" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 256
Float 208 [_FlowRateRock]
Float 212 [_FlowRateLava]
Float 216 [_TileRateU]
Float 220 [_TileRateV]
Float 224 [_LavaPatternRate]
Float 228 [_EmissivePower]
Float 232 [_MaskRangeCoeff]
Vector 240 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedmjdnokhambonafcalcckfkclajpgalilabaaaaaaoeakaaaaaeaaaaaa
daaaaaaaieaeaaaaamakaaaalaakaaaaebgpgodjemaeaaaaemaeaaaaaaacpppp
aiaeaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaanaaadaaaaaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkagpbcaddlaaaaaadpidpjccdoaaaaeaeafbaaaaafafaaapka
nlapmjeanlapejmaaknhkddmaaaaaaaafbaaaaafagaaapkaaaaaaaaamnmmemdn
aaaaiadpaaaakaebfbaaaaafahaaapkaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaa
fbaaaaafaiaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafajaaapka
klkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaahla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaacaaaaadia
agaaoekaaeaaaaaeabaaabiaaaaakklaaaaakkkaaaaaaaiaaeaaaaaeabaaacia
aaaapplaaaaappkaaaaaffiaacaaaaadaaaaadiaacaaoelaafaablkaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaaeaaaaae
aaaaabiaabaakkiaaeaaffkaacaakklaaeaaaaaeaaaaaciaaaaakkiaaeaaffka
acaapplaabaaaaacabaaadiaaaaaoekaafaaaaadaaaaaeiaabaaffiaadaaffka
aeaaaaaeaaaaadiaaaaakkiaahaaoekaaaaaoeiaafaaaaadaaaaaeiaadaaaala
aeaaaakaabaaaaacaaaaaiiaaeaaffkaaeaaaaaeaaaaaeiaadaaffkaaaaappia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaaeaakkkaaeaaffkabdaaaaacaaaaaeia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaafaaaakaafaaffkacfaaaaaeacaaacia
aaaakkiaaiaaoekaajaaoekaafaaaaadaaaaamiaacaaffiaafaaoekaaeaaaaae
acaaabiaaaaaaalaaaaakkkaaaaappiaaeaaaaaeacaaaciaaaaafflaaaaappka
aaaakkiaafaaaaadabaaabiaabaaaaiaadaaffkaaeaaaaaeacaaadiaabaaaaia
agaaoekaacaaoeiaaeaaaaaeadaaabiaabaaaalaaaaakkkaaaaappiaaeaaaaae
adaaaciaabaafflaaaaappkaaaaakkiaaeaaaaaeaeaaabiaabaakklaaaaakkka
aaaappiaaeaaaaaeaeaaaciaabaapplaaaaappkaaaaakkiaaeaaaaaeaeaaadia
abaaaaiaagaaoekaaeaaoeiaaeaaaaaeabaaadiaabaaaaiaagaaoekaadaaoeia
ecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadadaaapiaaaaaoelaaaaioeka
ecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaadabaaapiaabaaoeiaaaaioeka
ecaaaaadaeaaapiaaeaaoeiaabaioekaafaaaaadaeaaaiiaaaaaaaiaadaaaaia
caaaaaadaaaaabiaaeaappiaabaaaakaafaaaaadaeaaaiiaaaaaaaiaabaaffka
afaaaaadaeaaaiiaaeaappiaagaappkaafaaaaadaaaaahiaaeaappiaacaaoeka
afaaaaadaaaaaiiaabaaffiaacaaaaiaafaaaaadaaaabiiaaaaappiaaeaappka
acaaaaadaaaaaiiaaaaappibabaakkkaacaaaaadaaaaaiiaaaaappiaagaakkka
aeaaaaaeabaaahiaaeaaoeiaahaaffkaaaaaoeibaeaaaaaeaaaaahiaaaaappia
abaaoeiaaaaaoeiaabaaaaacaaaaaiiaagaakkkaabaaaaacaaaiapiaaaaaoeia
ppppaaaafdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
baaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaanaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaanaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaaoaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaaoaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
apaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaanaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaanaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaaoaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 1, 0, 0.050000001, 0.5 },
		{ 0, 0.02, 0.2, 20 },
		{ 0.0020000001, 3 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.zw, fragment.texcoord[2].xyxy, c[10].xyxy;
MOV R0.y, c[4].x;
MOV R0.x, c[3];
MAD R1.xy, fragment.texcoord[0].zwzw, R0, c[9].yzzw;
MOV result.color.w, c[9].x;
TEX R0.z, R0.zwzw, texture[1], 2D;
TEX R1.z, R1, texture[1], 2D;
MUL R1.x, fragment.color.primary, c[11];
MOV R0.w, c[9];
MAD R0.w, R0, c[0].y, R1.x;
SIN R0.w, R0.w;
MUL R2.xy, R0.w, c[10];
MOV R0.w, c[1].x;
MUL R0.w, R0, c[0].y;
MAD R1.xy, fragment.texcoord[1], R0, R2;
MAD R2.zw, fragment.texcoord[0].xyxy, R0.xyxy, R2.xyxy;
MAD R2.xy, fragment.texcoord[1].zwzw, R0, R2;
MAD R0.xy, R0.w, c[9].yzzw, R2.zwzw;
MAD R2.xy, R0.w, c[9].yzzw, R2;
MAD R1.xy, R0.w, c[9].yzzw, R1;
MUL R1.z, R1, c[9].w;
MUL R1.w, R0.z, c[9];
ADD R0.zw, fragment.texcoord[2], R1;
MOV R2.z, c[0].y;
MUL R1.z, R2, c[2].x;
MAD R0.zw, R1.z, c[10].xyxz, R0;
TEX R0.x, R0, texture[1], 2D;
TEX R0.y, R1, texture[1], 2D;
TEX R3.xyz, R2, texture[0], 2D;
TEX R2.x, R0.zwzw, texture[1], 2D;
TEX R1.x, fragment.texcoord[0], texture[1], 2D;
MUL R0.z, R1.x, R2.x;
MUL R0.w, R0.x, R0.y;
POW R0.z, R0.z, c[5].x;
MUL R0.z, R0, c[6].x;
MUL R0.xyz, R0.z, c[8];
MUL R0.xyz, R0, c[10].w;
MUL_SAT R0.w, R0, c[11].y;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R3, c[10].z, -R0;
ADD R0.w, R0, c[9].x;
MAD result.color.xyz, R0.w, R1, R0;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c9, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c10, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c11, 0.00000000, 0.05000000, 0.02000000, 0.20000000
def c12, 20.00000000, 0.00200000, 0.15915491, 0.50000000
def c13, 6.28318501, -3.14159298, 3.00000000, 0
dcl t0
dcl t1
dcl t2
dcl v0.x
mov r4.y, c4.x
mov r4.x, c3
mov r6.x, t2.z
mov r6.y, t2.w
mov r0.y, c11.z
mov r0.x, c11
add r0.xy, t2, r0
mov r1.x, t0.z
mov r1.y, t0.w
mad r1.xy, r1, r4, c11
texld r0, r0, s1
texld r1, r1, s1
mov r0.y, c0
mul r0.x, v0, c12.y
mad r0.x, c9.w, r0.y, r0
mad r0.x, r0, c12.z, c12.w
frc r0.x, r0
mad r0.x, r0, c13, c13.y
sincos r2.xy, r0.x, c10.xyzw, c9.xyzw
mov r0.y, c11.z
mov r0.x, c11
mul r5.xy, r2.y, r0
mov r0.y, c0
mul r0.x, c1, r0.y
mul r2.y, r0.z, c9.w
mov r1.x, t1.z
mov r1.y, t1.w
mad r1.xy, r1, r4, r5
mad r3.xy, r0.x, c11, r1
mul r2.x, r1.z, c9.w
add r2.xy, r6, r2
mov r1.x, c2
mul r1.x, c0.y, r1
mov r6.x, c11
mov r6.y, c11.w
mad r2.xy, r1.x, r6, r2
mad r1.xy, t1, r4, r5
mad r5.xy, t0, r4, r5
mad r4.xy, r0.x, c11, r1
mad r0.xy, r0.x, c11, r5
texld r1, r3, s0
texld r3, r0, s1
texld r0, r4, s1
texld r2, r2, s1
texld r4, t0, s1
mul r0.x, r4, r2
pow r2.w, r0.x, c5.x
mov r0.x, r2.w
mul r2.x, r0, c6
mul r0.x, r3, r0.y
mul r2.xyz, r2.x, c8
mul_sat r0.x, r0, c13.z
add r0.x, -r0, c7
mul r2.xyz, r2, c12.x
mad r1.xyz, r1, c11.w, -r2
add r0.x, r0, c9.z
mad r0.xyz, r0.x, r1, r2
mov r0.w, c9.z
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 256
Float 208 [_FlowRateRock]
Float 212 [_FlowRateLava]
Float 216 [_TileRateU]
Float 220 [_TileRateV]
Float 224 [_LavaPatternRate]
Float 228 [_EmissivePower]
Float 232 [_MaskRangeCoeff]
Vector 240 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedojpnlceekckgemjccebbgmkgkcmhkhifabaaaaaaimagaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
baaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaanaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaanaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaaoaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaaoaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
apaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaanaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaanaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaaoaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_OFF" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 256
Float 208 [_FlowRateRock]
Float 212 [_FlowRateLava]
Float 216 [_TileRateU]
Float 220 [_TileRateV]
Float 224 [_LavaPatternRate]
Float 228 [_EmissivePower]
Float 232 [_MaskRangeCoeff]
Vector 240 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedmjdnokhambonafcalcckfkclajpgalilabaaaaaaoeakaaaaaeaaaaaa
daaaaaaaieaeaaaaamakaaaalaakaaaaebgpgodjemaeaaaaemaeaaaaaaacpppp
aiaeaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaanaaadaaaaaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkagpbcaddlaaaaaadpidpjccdoaaaaeaeafbaaaaafafaaapka
nlapmjeanlapejmaaknhkddmaaaaaaaafbaaaaafagaaapkaaaaaaaaamnmmemdn
aaaaiadpaaaakaebfbaaaaafahaaapkaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaa
fbaaaaafaiaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafajaaapka
klkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaahla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaacaaaaadia
agaaoekaaeaaaaaeabaaabiaaaaakklaaaaakkkaaaaaaaiaaeaaaaaeabaaacia
aaaapplaaaaappkaaaaaffiaacaaaaadaaaaadiaacaaoelaafaablkaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaaeaaaaae
aaaaabiaabaakkiaaeaaffkaacaakklaaeaaaaaeaaaaaciaaaaakkiaaeaaffka
acaapplaabaaaaacabaaadiaaaaaoekaafaaaaadaaaaaeiaabaaffiaadaaffka
aeaaaaaeaaaaadiaaaaakkiaahaaoekaaaaaoeiaafaaaaadaaaaaeiaadaaaala
aeaaaakaabaaaaacaaaaaiiaaeaaffkaaeaaaaaeaaaaaeiaadaaffkaaaaappia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaaeaakkkaaeaaffkabdaaaaacaaaaaeia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaafaaaakaafaaffkacfaaaaaeacaaacia
aaaakkiaaiaaoekaajaaoekaafaaaaadaaaaamiaacaaffiaafaaoekaaeaaaaae
acaaabiaaaaaaalaaaaakkkaaaaappiaaeaaaaaeacaaaciaaaaafflaaaaappka
aaaakkiaafaaaaadabaaabiaabaaaaiaadaaffkaaeaaaaaeacaaadiaabaaaaia
agaaoekaacaaoeiaaeaaaaaeadaaabiaabaaaalaaaaakkkaaaaappiaaeaaaaae
adaaaciaabaafflaaaaappkaaaaakkiaaeaaaaaeaeaaabiaabaakklaaaaakkka
aaaappiaaeaaaaaeaeaaaciaabaapplaaaaappkaaaaakkiaaeaaaaaeaeaaadia
abaaaaiaagaaoekaaeaaoeiaaeaaaaaeabaaadiaabaaaaiaagaaoekaadaaoeia
ecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadadaaapiaaaaaoelaaaaioeka
ecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaadabaaapiaabaaoeiaaaaioeka
ecaaaaadaeaaapiaaeaaoeiaabaioekaafaaaaadaeaaaiiaaaaaaaiaadaaaaia
caaaaaadaaaaabiaaeaappiaabaaaakaafaaaaadaeaaaiiaaaaaaaiaabaaffka
afaaaaadaeaaaiiaaeaappiaagaappkaafaaaaadaaaaahiaaeaappiaacaaoeka
afaaaaadaaaaaiiaabaaffiaacaaaaiaafaaaaadaaaabiiaaaaappiaaeaappka
acaaaaadaaaaaiiaaaaappibabaakkkaacaaaaadaaaaaiiaaaaappiaagaakkka
aeaaaaaeabaaahiaaeaaoeiaahaaffkaaaaaoeibaeaaaaaeaaaaahiaaaaappia
abaaoeiaaaaaoeiaabaaaaacaaaaaiiaagaakkkaabaaaaacaaaiapiaaaaaoeia
ppppaaaafdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
baaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaanaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaanaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaaoaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaaoaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
apaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaanaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaanaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaaoaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
SubProgram "opengl " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"!!ARBfp1.0
OPTION ARB_precision_hint_fastest;
PARAM c[12] = { program.local[0..8],
		{ 1, 0, 0.050000001, 0.5 },
		{ 0, 0.02, 0.2, 20 },
		{ 0.0020000001, 3 } };
TEMP R0;
TEMP R1;
TEMP R2;
TEMP R3;
ADD R0.zw, fragment.texcoord[2].xyxy, c[10].xyxy;
MOV R0.y, c[4].x;
MOV R0.x, c[3];
MAD R1.xy, fragment.texcoord[0].zwzw, R0, c[9].yzzw;
MOV result.color.w, c[9].x;
TEX R0.z, R0.zwzw, texture[1], 2D;
TEX R1.z, R1, texture[1], 2D;
MUL R1.x, fragment.color.primary, c[11];
MOV R0.w, c[9];
MAD R0.w, R0, c[0].y, R1.x;
SIN R0.w, R0.w;
MUL R2.xy, R0.w, c[10];
MOV R0.w, c[1].x;
MUL R0.w, R0, c[0].y;
MAD R1.xy, fragment.texcoord[1], R0, R2;
MAD R2.zw, fragment.texcoord[0].xyxy, R0.xyxy, R2.xyxy;
MAD R2.xy, fragment.texcoord[1].zwzw, R0, R2;
MAD R0.xy, R0.w, c[9].yzzw, R2.zwzw;
MAD R2.xy, R0.w, c[9].yzzw, R2;
MAD R1.xy, R0.w, c[9].yzzw, R1;
MUL R1.z, R1, c[9].w;
MUL R1.w, R0.z, c[9];
ADD R0.zw, fragment.texcoord[2], R1;
MOV R2.z, c[0].y;
MUL R1.z, R2, c[2].x;
MAD R0.zw, R1.z, c[10].xyxz, R0;
TEX R0.x, R0, texture[1], 2D;
TEX R0.y, R1, texture[1], 2D;
TEX R3.xyz, R2, texture[0], 2D;
TEX R2.x, R0.zwzw, texture[1], 2D;
TEX R1.x, fragment.texcoord[0], texture[1], 2D;
MUL R0.z, R1.x, R2.x;
MUL R0.w, R0.x, R0.y;
POW R0.z, R0.z, c[5].x;
MUL R0.z, R0, c[6].x;
MUL R0.xyz, R0.z, c[8];
MUL R0.xyz, R0, c[10].w;
MUL_SAT R0.w, R0, c[11].y;
ADD R0.w, -R0, c[7].x;
MAD R1.xyz, R3, c[10].z, -R0;
ADD R0.w, R0, c[9].x;
MAD result.color.xyz, R0.w, R1, R0;
END
# 42 instructions, 4 R-regs
"
}
SubProgram "d3d9 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
Vector 0 [_Time]
Float 1 [_FlowRateRock]
Float 2 [_FlowRateLava]
Float 3 [_TileRateU]
Float 4 [_TileRateV]
Float 5 [_LavaPatternRate]
Float 6 [_EmissivePower]
Float 7 [_MaskRangeCoeff]
Vector 8 [_LavaColor]
SetTexture 0 [_LavaRockTex] 2D 0
SetTexture 1 [_FlowLavaTex0] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
def c9, -0.02083333, -0.12500000, 1.00000000, 0.50000000
def c10, -0.00000155, -0.00002170, 0.00260417, 0.00026042
def c11, 0.00000000, 0.05000000, 0.02000000, 0.20000000
def c12, 20.00000000, 0.00200000, 0.15915491, 0.50000000
def c13, 6.28318501, -3.14159298, 3.00000000, 0
dcl t0
dcl t1
dcl t2
dcl v0.x
mov r4.y, c4.x
mov r4.x, c3
mov r6.x, t2.z
mov r6.y, t2.w
mov r0.y, c11.z
mov r0.x, c11
add r0.xy, t2, r0
mov r1.x, t0.z
mov r1.y, t0.w
mad r1.xy, r1, r4, c11
texld r0, r0, s1
texld r1, r1, s1
mov r0.y, c0
mul r0.x, v0, c12.y
mad r0.x, c9.w, r0.y, r0
mad r0.x, r0, c12.z, c12.w
frc r0.x, r0
mad r0.x, r0, c13, c13.y
sincos r2.xy, r0.x, c10.xyzw, c9.xyzw
mov r0.y, c11.z
mov r0.x, c11
mul r5.xy, r2.y, r0
mov r0.y, c0
mul r0.x, c1, r0.y
mul r2.y, r0.z, c9.w
mov r1.x, t1.z
mov r1.y, t1.w
mad r1.xy, r1, r4, r5
mad r3.xy, r0.x, c11, r1
mul r2.x, r1.z, c9.w
add r2.xy, r6, r2
mov r1.x, c2
mul r1.x, c0.y, r1
mov r6.x, c11
mov r6.y, c11.w
mad r2.xy, r1.x, r6, r2
mad r1.xy, t1, r4, r5
mad r5.xy, t0, r4, r5
mad r4.xy, r0.x, c11, r1
mad r0.xy, r0.x, c11, r5
texld r1, r3, s0
texld r3, r0, s1
texld r0, r4, s1
texld r2, r2, s1
texld r4, t0, s1
mul r0.x, r4, r2
pow r2.w, r0.x, c5.x
mov r0.x, r2.w
mul r2.x, r0, c6
mul r0.x, r3, r0.y
mul r2.xyz, r2.x, c8
mul_sat r0.x, r0, c13.z
add r0.x, -r0, c7
mul r2.xyz, r2, c12.x
mad r1.xyz, r1, c11.w, -r2
add r0.x, r0, c9.z
mad r0.xyz, r0.x, r1, r2
mov r0.w, c9.z
mov oC0, r0
"
}
SubProgram "d3d11 " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 256
Float 208 [_FlowRateRock]
Float 212 [_FlowRateLava]
Float 216 [_TileRateU]
Float 220 [_TileRateV]
Float 224 [_LavaPatternRate]
Float 228 [_EmissivePower]
Float 232 [_MaskRangeCoeff]
Vector 240 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedojpnlceekckgemjccebbgmkgkcmhkhifabaaaaaaimagaaaaadaaaaaa
cmaaaaaanaaaaaaaaeabaaaaejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklklfdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
baaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaanaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaanaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaaoaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaaoaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
apaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaanaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaanaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaaoaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaab"
}
SubProgram "d3d11_9x " {
Keywords { "DIRECTIONAL" "SHADOWS_SCREEN" "LIGHTMAP_ON" "DIRLIGHTMAP_ON" }
SetTexture 0 [_LavaRockTex] 2D 1
SetTexture 1 [_FlowLavaTex0] 2D 0
ConstBuffer "$Globals" 256
Float 208 [_FlowRateRock]
Float 212 [_FlowRateLava]
Float 216 [_TileRateU]
Float 220 [_TileRateV]
Float 224 [_LavaPatternRate]
Float 228 [_EmissivePower]
Float 232 [_MaskRangeCoeff]
Vector 240 [_LavaColor]
ConstBuffer "UnityPerCamera" 128
Vector 0 [_Time]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0_level_9_1
eefiecedmjdnokhambonafcalcckfkclajpgalilabaaaaaaoeakaaaaaeaaaaaa
daaaaaaaieaeaaaaamakaaaalaakaaaaebgpgodjemaeaaaaemaeaaaaaaacpppp
aiaeaaaaeeaaaaaaacaacmaaaaaaeeaaaaaaeeaaacaaceaaaaaaeeaaabaaaaaa
aaababaaaaaaanaaadaaaaaaaaaaaaaaabaaaaaaabaaadaaaaaaaaaaaaacpppp
fbaaaaafaeaaapkagpbcaddlaaaaaadpidpjccdoaaaaeaeafbaaaaafafaaapka
nlapmjeanlapejmaaknhkddmaaaaaaaafbaaaaafagaaapkaaaaaaaaamnmmemdn
aaaaiadpaaaakaebfbaaaaafahaaapkaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaa
fbaaaaafaiaaapkaabannalfgballglhklkkckdlijiiiidjfbaaaaafajaaapka
klkkkklmaaaaaaloaaaaiadpaaaaaadpbpaaaaacaaaaaaiaaaaaaplabpaaaaac
aaaaaaiaabaaaplabpaaaaacaaaaaaiaacaaaplabpaaaaacaaaaaaiaadaaahla
bpaaaaacaaaaaajaaaaiapkabpaaaaacaaaaaajaabaiapkaabaaaaacaaaaadia
agaaoekaaeaaaaaeabaaabiaaaaakklaaaaakkkaaaaaaaiaaeaaaaaeabaaacia
aaaapplaaaaappkaaaaaffiaacaaaaadaaaaadiaacaaoelaafaablkaecaaaaad
abaaapiaabaaoeiaaaaioekaecaaaaadaaaaapiaaaaaoeiaaaaioekaaeaaaaae
aaaaabiaabaakkiaaeaaffkaacaakklaaeaaaaaeaaaaaciaaaaakkiaaeaaffka
acaapplaabaaaaacabaaadiaaaaaoekaafaaaaadaaaaaeiaabaaffiaadaaffka
aeaaaaaeaaaaadiaaaaakkiaahaaoekaaaaaoeiaafaaaaadaaaaaeiaadaaaala
aeaaaakaabaaaaacaaaaaiiaaeaaffkaaeaaaaaeaaaaaeiaadaaffkaaaaappia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaaeaakkkaaeaaffkabdaaaaacaaaaaeia
aaaakkiaaeaaaaaeaaaaaeiaaaaakkiaafaaaakaafaaffkacfaaaaaeacaaacia
aaaakkiaaiaaoekaajaaoekaafaaaaadaaaaamiaacaaffiaafaaoekaaeaaaaae
acaaabiaaaaaaalaaaaakkkaaaaappiaaeaaaaaeacaaaciaaaaafflaaaaappka
aaaakkiaafaaaaadabaaabiaabaaaaiaadaaffkaaeaaaaaeacaaadiaabaaaaia
agaaoekaacaaoeiaaeaaaaaeadaaabiaabaaaalaaaaakkkaaaaappiaaeaaaaae
adaaaciaabaafflaaaaappkaaaaakkiaaeaaaaaeaeaaabiaabaakklaaaaakkka
aaaappiaaeaaaaaeaeaaaciaabaapplaaaaappkaaaaakkiaaeaaaaaeaeaaadia
abaaaaiaagaaoekaaeaaoeiaaeaaaaaeabaaadiaabaaaaiaagaaoekaadaaoeia
ecaaaaadaaaaapiaaaaaoeiaaaaioekaecaaaaadadaaapiaaaaaoelaaaaioeka
ecaaaaadacaaapiaacaaoeiaaaaioekaecaaaaadabaaapiaabaaoeiaaaaioeka
ecaaaaadaeaaapiaaeaaoeiaabaioekaafaaaaadaeaaaiiaaaaaaaiaadaaaaia
caaaaaadaaaaabiaaeaappiaabaaaakaafaaaaadaeaaaiiaaaaaaaiaabaaffka
afaaaaadaeaaaiiaaeaappiaagaappkaafaaaaadaaaaahiaaeaappiaacaaoeka
afaaaaadaaaaaiiaabaaffiaacaaaaiaafaaaaadaaaabiiaaaaappiaaeaappka
acaaaaadaaaaaiiaaaaappibabaakkkaacaaaaadaaaaaiiaaaaappiaagaakkka
aeaaaaaeabaaahiaaeaaoeiaahaaffkaaaaaoeibaeaaaaaeaaaaahiaaaaappia
abaaoeiaaaaaoeiaabaaaaacaaaaaiiaagaakkkaabaaaaacaaaiapiaaaaaoeia
ppppaaaafdeieefciaafaaaaeaaaaaaagaabaaaafjaaaaaeegiocaaaaaaaaaaa
baaaaaaafjaaaaaeegiocaaaabaaaaaaabaaaaaafkaaaaadaagabaaaaaaaaaaa
fkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaae
aahabaaaabaaaaaaffffaaaagcbaaaadpcbabaaaabaaaaaagcbaaaadpcbabaaa
acaaaaaagcbaaaadpcbabaaaadaaaaaagcbaaaadbcbabaaaaeaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacaeaaaaaadcaaaaandcaabaaaaaaaaaaaogbkbaaa
abaaaaaaogikcaaaaaaaaaaaanaaaaaaaceaaaaaaaaaaaaamnmmemdnaaaaaaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaackaabaaaaaaaaaaaabeaaaaa
aaaaaadpaaaaaaakmcaabaaaaaaaaaaaagbebaaaadaaaaaaaceaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaknhkddmefaaaaajpcaabaaaabaaaaaaogakbaaaaaaaaaaa
eghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaackaabaaa
abaaaaaaabeaaaaaaaaaaadpaaaaaaahdcaabaaaaaaaaaaaegaabaaaaaaaaaaa
ogbkbaaaadaaaaaadiaaaaajpcaabaaaabaaaaaaagifcaaaaaaaaaaaanaaaaaa
fgifcaaaabaaaaaaaaaaaaaadcaaaaamdcaabaaaaaaaaaaaogakbaaaabaaaaaa
aceaaaaaaaaaaaaamnmmemdoaaaaaaaaaaaaaaaaegaabaaaaaaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegaabaaaaaaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaakaabaaaacaaaaaa
cpaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaa
akaabaaaaaaaaaaaakiacaaaaaaaaaaaaoaaaaaabjaaaaafbcaabaaaaaaaaaaa
akaabaaaaaaaaaaadiaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaaa
aaaaaaaaaoaaaaaadiaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaakaebdiaaaaaihcaabaaaaaaaaaaaagaabaaaaaaaaaaaegiccaaaaaaaaaaa
apaaaaaadiaaaaahicaabaaaaaaaaaaaakbabaaaaeaaaaaaabeaaaaagpbcaddl
dcaaaaakicaabaaaaaaaaaaabkiacaaaabaaaaaaaaaaaaaaabeaaaaaaaaaaadp
dkaabaaaaaaaaaaaenaaaaagicaabaaaaaaaaaaaaanaaaaadkaabaaaaaaaaaaa
diaaaaakmcaabaaaabaaaaaapgapbaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaknhkddmdcaaaaakpcaabaaaacaaaaaaogbebaaaacaaaaaaogiocaaa
aaaaaaaaanaaaaaaogaobaaaabaaaaaadcaaaaakmcaabaaaabaaaaaaagbebaaa
abaaaaaakgiocaaaaaaaaaaaanaaaaaakgaobaaaabaaaaaadcaaaaammcaabaaa
abaaaaaaagaebaaaabaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaamnmmemdn
kgaobaaaabaaaaaadcaaaaampcaabaaaacaaaaaaegaebaaaabaaaaaaaceaaaaa
aaaaaaaamnmmemdnaaaaaaaamnmmemdnegaobaaaacaaaaaaefaaaaajpcaabaaa
abaaaaaaogakbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaa
efaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaabaaaaaaaagabaaa
aaaaaaaadiaaaaahicaabaaaaaaaaaaaakaabaaaabaaaaaabkaabaaaacaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaeaeaaaaaaaaj
icaabaaaaaaaaaaadkaabaiaebaaaaaaaaaaaaaackiacaaaaaaaaaaaaoaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadpdcaaaaan
hcaabaaaabaaaaaaegacbaaaadaaaaaaaceaaaaamnmmemdomnmmemdomnmmemdo
aaaaaaaaegacbaiaebaaaaaaaaaaaaaadcaaaaajhccabaaaaaaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaa
abeaaaaaaaaaiadpdoaaaaabejfdeheojmaaaaaaafaaaaaaaiaaaaaaiaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaaimaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaapapaaaaimaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaaimaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaajfaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaeaaaaaaahabaaaafdfgfpfaepfdejfeejepeoaa
feeffiedepepfceeaaedepemepfcaaklepfdeheocmaaaaaaabaaaaaaaiaaaaaa
caaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapaaaaaafdfgfpfegbhcghgf
heaaklkl"
}
}
 }
}
}