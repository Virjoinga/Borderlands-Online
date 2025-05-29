£þShader "Hidden/Dof/DepthOfFieldHdr" {
Properties {
 _MainTex ("-", 2D) = "black" {}
 _FgOverlap ("-", 2D) = "black" {}
 _LowRez ("-", 2D) = "black" {}
}
SubShader { 
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  ColorMask A
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform vec4 _ZBufferParams;
uniform sampler2D _MainTex;
uniform sampler2D _CameraDepthTexture;
uniform vec4 _CurveParams;
uniform vec4 _GunSightExtension;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 color_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD1);
  color_1 = tmpvar_2;
  float tmpvar_3;
  tmpvar_3 = (1.0/(((_ZBufferParams.x * texture2D (_CameraDepthTexture, xlv_TEXCOORD1).x) + _ZBufferParams.y)));
  vec4 tmpvar_4;
  tmpvar_4 = texture2D (_CameraDepthTexture, vec2(0.5, 0.5));
  float tmpvar_5;
  if (bool(_GunSightExtension.x)) {
    tmpvar_5 = (1.0/(((_ZBufferParams.x * tmpvar_4.x) + _ZBufferParams.y)));
  } else {
    tmpvar_5 = _CurveParams.w;
  };
  if (((((tmpvar_2.w == 0.123) || (tmpvar_2.w == 0.132)) || (tmpvar_2.w == 0.133)) || (tmpvar_2.w == 0.143))) {
    color_1.w = 0.0;
  } else {
    color_1.w = ((_CurveParams.z * abs((tmpvar_3 - tmpvar_5))) / (tmpvar_3 + 1e-05));
    color_1.w = clamp (max (0.0, (color_1.w - _CurveParams.y)), 0.0, _CurveParams.x);
  };
  gl_FragData[0] = color_1;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_ZBufferParams]
Vector 1 [_CurveParams]
Vector 2 [_GunSightExtension]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 0.50000000, -0.12298584, 1.00000000, 0.00000000
def c4, -0.13195801, -0.13305664, -0.14294434, 0.00001000
dcl_texcoord1 v0.xy
texld r2, v0, s0
add r0.y, r2.w, c4.x
add r0.x, r2.w, c3.y
abs r0.y, r0
abs r0.x, r0
add r0.z, r2.w, c4
abs r0.z, r0
cmp r0.y, -r0, c3.z, c3.w
cmp r0.x, -r0, c3.z, c3.w
add_pp_sat r0.x, r0, r0.y
add r0.y, r2.w, c4
abs r0.y, r0
cmp r0.y, -r0, c3.z, c3.w
add_pp_sat r0.x, r0, r0.y
cmp r0.z, -r0, c3, c3.w
add_pp_sat r0.y, r0.x, r0.z
texld r1.x, c3.x, s1
mad r0.z, r1.x, c0.x, c0.y
rcp r0.w, r0.z
texld r0.x, v0, s1
mad r0.x, r0, c0, c0.y
abs r0.z, c2.x
cmp r0.z, -r0, c1.w, r0.w
rcp r0.x, r0.x
add r0.z, r0.x, -r0
add r0.w, r0.x, c4
abs r0.x, r0.z
mul r0.x, r0, c1.z
rcp r0.z, r0.w
mul r0.z, r0.x, r0
abs_pp r0.x, r0.y
cmp r0.y, -r0.x, r0.z, c3.w
add r0.z, r0.y, -c1.y
max r0.z, r0, c3.w
min r0.z, r0, c1.x
max r0.z, r0, c3.w
cmp oC0.w, -r0.x, r0.z, r0.y
mov oC0.xyz, r2
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
ConstBuffer "$Globals" 80
Vector 16 [_CurveParams]
Vector 64 [_GunSightExtension]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedafclflhfgoipocdaeochdmimjgdecjhkabaaaaaagaaeaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefciiadaaaaeaaaaaaaocaaaaaa
fjaaaaaeegiocaaaaaaaaaaaafaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadmcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaampcaabaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaaaaaaaaaaaaeghobaaaabaaaaaa
aagabaaaabaaaaaadcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaa
akaabaaaaaaaaaaabkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaadjaaaaal
ccaabaaaaaaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaakiacaaa
aaaaaaaaaeaaaaaadhaaaaakbcaabaaaaaaaaaaabkaabaaaaaaaaaaaakaabaaa
aaaaaaaadkiacaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
abaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaalccaabaaaaaaaaaaa
akiacaaaabaaaaaaahaaaaaaakaabaaaabaaaaaabkiacaaaabaaaaaaahaaaaaa
aoaaaaakccaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadp
bkaabaaaaaaaaaaaaaaaaaaibcaabaaaaaaaaaaaakaabaiaebaaaaaaaaaaaaaa
bkaabaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaaaaaaaaaaabeaaaaa
kmmfchdhdiaaaaajbcaabaaaaaaaaaaaakaabaiaibaaaaaaaaaaaaaackiacaaa
aaaaaaaaabaaaaaaaoaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaa
aaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaabkiacaiaebaaaaaa
aaaaaaaaabaaaaaadeaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
aaaaaaaaddaaaaaibcaabaaaaaaaaaaaakaabaaaaaaaaaaaakiacaaaaaaaaaaa
abaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaabiaaaaakpcaabaaaacaaaaaapgapbaaaabaaaaaaaceaaaaa
gnohpldnacclahdochdbaidojigobcdodgaaaaafhccabaaaaaaaaaaaegacbaaa
abaaaaaadmaaaaahccaabaaaaaaaaaaabkaabaaaacaaaaaaakaabaaaacaaaaaa
dmaaaaahccaabaaaaaaaaaaackaabaaaacaaaaaabkaabaaaaaaaaaaadmaaaaah
ccaabaaaaaaaaaaadkaabaaaacaaaaaabkaabaaaaaaaaaaadhaaaaajiccabaaa
aaaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaaaaaakaabaaaaaaaaaaadoaaaaab
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
"!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
varying vec4 xlv_TEXCOORD5;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = gl_MultiTexCoord0.xy;
  xlv_TEXCOORD1 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(1.0, 1.0, -1.0, -1.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD2 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(2.0, 2.0, -2.0, -2.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD3 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(3.0, 3.0, -3.0, -3.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD4 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(4.0, 4.0, -4.0, -4.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD5 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(5.0, 5.0, -5.0, -5.0)) * _MainTex_TexelSize.xyxy) / 6.0));
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
varying vec4 xlv_TEXCOORD5;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = texture2D (_MainTex, xlv_TEXCOORD0);
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD1.xy);
  vec4 tmpvar_3;
  tmpvar_3 = texture2D (_MainTex, xlv_TEXCOORD1.zw);
  vec4 tmpvar_4;
  tmpvar_4 = texture2D (_MainTex, xlv_TEXCOORD2.xy);
  vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD2.zw);
  vec4 tmpvar_6;
  tmpvar_6 = texture2D (_MainTex, xlv_TEXCOORD3.xy);
  vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD3.zw);
  vec4 tmpvar_8;
  tmpvar_8 = texture2D (_MainTex, xlv_TEXCOORD4.xy);
  vec4 tmpvar_9;
  tmpvar_9 = texture2D (_MainTex, xlv_TEXCOORD4.zw);
  vec4 tmpvar_10;
  tmpvar_10 = texture2D (_MainTex, xlv_TEXCOORD5.xy);
  vec4 tmpvar_11;
  tmpvar_11 = texture2D (_MainTex, xlv_TEXCOORD5.zw);
  float tmpvar_12;
  tmpvar_12 = (tmpvar_2.w * 0.8);
  float tmpvar_13;
  tmpvar_13 = (tmpvar_3.w * 0.8);
  float tmpvar_14;
  tmpvar_14 = (tmpvar_4.w * 0.65);
  float tmpvar_15;
  tmpvar_15 = (tmpvar_5.w * 0.65);
  float tmpvar_16;
  tmpvar_16 = (tmpvar_6.w * 0.5);
  float tmpvar_17;
  tmpvar_17 = (tmpvar_7.w * 0.5);
  float tmpvar_18;
  tmpvar_18 = (tmpvar_8.w * 0.4);
  float tmpvar_19;
  tmpvar_19 = (tmpvar_9.w * 0.4);
  float tmpvar_20;
  tmpvar_20 = (tmpvar_10.w * 0.2);
  float tmpvar_21;
  tmpvar_21 = (tmpvar_11.w * 0.2);
  gl_FragData[0] = ((((((((((((tmpvar_1 * tmpvar_1.w) + (tmpvar_2 * tmpvar_12)) + (tmpvar_3 * tmpvar_13)) + (tmpvar_4 * tmpvar_14)) + (tmpvar_5 * tmpvar_15)) + (tmpvar_6 * tmpvar_16)) + (tmpvar_7 * tmpvar_17)) + (tmpvar_8 * tmpvar_18)) + (tmpvar_9 * tmpvar_19)) + (tmpvar_10 * tmpvar_20)) + (tmpvar_11 * tmpvar_21)) / (((((((((((tmpvar_1.w + tmpvar_12) + tmpvar_13) + tmpvar_14) + tmpvar_15) + tmpvar_16) + tmpvar_17) + tmpvar_18) + tmpvar_19) + tmpvar_20) + tmpvar_21) + 0.0001));
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
Vector 5 [_Offsets]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c6, 0.16666667, -0.16666667, 0.33333334, -0.33333334
def c7, 0.50000000, -0.50000000, 0.66666669, -0.66666669
def c8, 0.83333337, -0.83333337, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, c5
mul r0.xy, c4, r0
mad o2, r0.xyxy, c6.xxyy, v1.xyxy
mad o3, r0.xyxy, c6.zzww, v1.xyxy
mad o4, r0.xyxy, c7.xxyy, v1.xyxy
mad o5, r0.xyxy, c7.zzww, v1.xyxy
mad o6, r0.xyxy, c8.xxyy, v1.xyxy
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedgohcneiglfdbcbnppkcpeddheeclmhjfabaaaaaaaeaeaaaaadaaaaaa
cmaaaaaaiaaaaaaafaabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
lmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
lmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefckmacaaaaeaaaabaaklaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaa
afaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaa
abaaaaaadgaaaaafbcaabaaaaaaaaaaaabeaaaaaaaaaiadpdgaaaaagmcaabaaa
aaaaaaaaagiecaaaaaaaaaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaaagaobaaa
aaaaaaaaegiecaaaaaaaaaaaadaaaaaadiaaaaaidcaabaaaaaaaaaaaegaabaaa
aaaaaaaaegiacaaaaaaaaaaaacaaaaaadcaaaaampccabaaaacaaaaaaegaobaaa
aaaaaaaaaceaaaaaklkkckdoklkkckdoklkkckloklkkckloegbebaaaabaaaaaa
dcaaaaampccabaaaadaaaaaaogaobaaaaaaaaaaaaceaaaaaklkkkkdoklkkkkdo
klkkkkloklkkkkloegbebaaaabaaaaaadcaaaaampccabaaaaeaaaaaaogaobaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaalpaaaaaalpegbebaaaabaaaaaa
dcaaaaampccabaaaafaaaaaaogaobaaaaaaaaaaaaceaaaaaklkkckdpklkkckdp
klkkcklpklkkcklpegbebaaaabaaaaaadcaaaaampccabaaaagaaaaaaogaobaaa
aaaaaaaaaceaaaaafgffffdpfgffffdpfgfffflpfgfffflpegbebaaaabaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 0.80000001, 0.64999998, 0.50000000, 0.40000001
def c1, 0.20000000, 0.00010000, 0, 0
dcl_texcoord0 v0.xy
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5
texld r0, v1, s0
mul r4.x, r0.w, c0
mul r1, r0, r4.x
texld r3, v0, s0
mad r1, r3, r3.w, r1
texld r0, v1.zwzw, s0
mul r3.x, r0.w, c0
mad r2, r0, r3.x, r1
texld r1, v2, s0
mul r3.y, r1.w, c0
mad r1, r1, r3.y, r2
texld r0, v2.zwzw, s0
mul r2.x, r0.w, c0.y
mad r1, r0, r2.x, r1
texld r0, v3, s0
mul r2.y, r0.w, c0.z
add r2.z, r3.w, r4.x
mad r1, r0, r2.y, r1
add r2.z, r3.x, r2
add r2.w, r3.y, r2.z
texld r0, v3.zwzw, s0
mul r2.z, r0.w, c0
mad r1, r0, r2.z, r1
texld r0, v4, s0
mul r4.x, r0.w, c0.w
mad r3, r0, r4.x, r1
add r2.x, r2, r2.w
add r2.x, r2.y, r2
add r0.x, r2.z, r2
texld r2, v4.zwzw, s0
mul r4.w, r2, c0
add r0.x, r4, r0
add r4.x, r4.w, r0
texld r1, v5, s0
mul r4.y, r1.w, c1.x
mad r2, r2, r4.w, r3
texld r0, v5.zwzw, s0
add r4.z, r4.y, r4.x
mul r4.x, r0.w, c1
mad r1, r1, r4.y, r2
add r4.z, r4.x, r4
add r3.x, r4.z, c1.y
rcp r2.x, r3.x
mad r0, r0, r4.x, r1
mul oC0, r0, r2.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedpjfeelmebhghnbgmcbndfndbamnahkjhabaaaaaaieahaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcemagaaaaeaaaaaaajdabaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaa
gcbaaaadpcbabaaaaeaaaaaagcbaaaadpcbabaaaafaaaaaagcbaaaadpcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaa
aaaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
bcaabaaaabaaaaaadkaabaaaaaaaaaaaabeaaaaamnmmemdpdiaaaaahpcaabaaa
abaaaaaaegaobaaaaaaaaaaaagaabaaaabaaaaaaefaaaaajpcaabaaaacaaaaaa
egbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajpcaabaaa
abaaaaaaegaobaaaacaaaaaapgapbaaaacaaaaaaegaobaaaabaaaaaadcaaaaaj
bcaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaamnmmemdpdkaabaaaacaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaamnmmemdp
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaafgafbaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaajbcaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaamnmmemdp
akaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaadaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaacaaaaaa
abeaaaaaggggcgdpdcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaafgafbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaajbcaabaaaaaaaaaaadkaabaaaacaaaaaa
abeaaaaaggggcgdpakaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaa
adaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaa
dkaabaaaacaaaaaaabeaaaaaggggcgdpdcaaaaajpcaabaaaabaaaaaaegaobaaa
acaaaaaafgafbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaajbcaabaaaaaaaaaaa
dkaabaaaacaaaaaaabeaaaaaggggcgdpakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaaeaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
ccaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaadpdcaaaaajpcaabaaa
abaaaaaaegaobaaaacaaaaaafgafbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaaj
bcaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaadpakaabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaaeaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaadp
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaafgafbaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaajbcaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaadp
akaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaegbabaaaafaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaacaaaaaa
abeaaaaamnmmmmdodcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaafgafbaaa
aaaaaaaaegaobaaaabaaaaaadcaaaaajbcaabaaaaaaaaaaadkaabaaaacaaaaaa
abeaaaaamnmmmmdoakaabaaaaaaaaaaaefaaaaajpcaabaaaacaaaaaaogbkbaaa
afaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahccaabaaaaaaaaaaa
dkaabaaaacaaaaaaabeaaaaamnmmmmdodcaaaaajpcaabaaaabaaaaaaegaobaaa
acaaaaaafgafbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaajbcaabaaaaaaaaaaa
dkaabaaaacaaaaaaabeaaaaamnmmmmdoakaabaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaagaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaah
ccaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaamnmmemdodcaaaaajpcaabaaa
abaaaaaaegaobaaaacaaaaaafgafbaaaaaaaaaaaegaobaaaabaaaaaadcaaaaaj
bcaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaamnmmemdoakaabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaogbkbaaaagaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadiaaaaahccaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaamnmmemdo
dcaaaaajpcaabaaaabaaaaaaegaobaaaacaaaaaafgafbaaaaaaaaaaaegaobaaa
abaaaaaadcaaaaajbcaabaaaaaaaaaaadkaabaaaacaaaaaaabeaaaaamnmmemdo
akaabaaaaaaaaaaaaaaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaaabeaaaaa
bhlhnbdiaoaaaaahpccabaaaaaaaaaaaegaobaaaabaaaaaaagaabaaaaaaaaaaa
doaaaaab"
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
"!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
varying vec4 xlv_TEXCOORD5;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = gl_MultiTexCoord0.xy;
  xlv_TEXCOORD1 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(1.0, 1.0, -1.0, -1.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD2 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(2.0, 2.0, -2.0, -2.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD3 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(3.0, 3.0, -3.0, -3.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD4 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(4.0, 4.0, -4.0, -4.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD5 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(5.0, 5.0, -5.0, -5.0)) * _MainTex_TexelSize.xyxy) / 6.0));
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
varying vec4 xlv_TEXCOORD5;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = texture2D (_MainTex, xlv_TEXCOORD0);
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD1.xy);
  vec4 tmpvar_3;
  tmpvar_3 = texture2D (_MainTex, xlv_TEXCOORD1.zw);
  vec4 tmpvar_4;
  tmpvar_4 = texture2D (_MainTex, xlv_TEXCOORD2.xy);
  vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD2.zw);
  vec4 tmpvar_6;
  tmpvar_6 = texture2D (_MainTex, xlv_TEXCOORD3.xy);
  vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD3.zw);
  vec4 tmpvar_8;
  tmpvar_8 = texture2D (_MainTex, xlv_TEXCOORD4.xy);
  vec4 tmpvar_9;
  tmpvar_9 = texture2D (_MainTex, xlv_TEXCOORD4.zw);
  vec4 tmpvar_10;
  tmpvar_10 = texture2D (_MainTex, xlv_TEXCOORD5.xy);
  vec4 tmpvar_11;
  tmpvar_11 = texture2D (_MainTex, xlv_TEXCOORD5.zw);
  float t_12;
  t_12 = max (min ((((tmpvar_2.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_13;
  tmpvar_13 = ((t_12 * (t_12 * (3.0 - (2.0 * t_12)))) * 0.8);
  float t_14;
  t_14 = max (min ((((tmpvar_3.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_15;
  tmpvar_15 = ((t_14 * (t_14 * (3.0 - (2.0 * t_14)))) * 0.8);
  float t_16;
  t_16 = max (min ((((tmpvar_4.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_17;
  tmpvar_17 = ((t_16 * (t_16 * (3.0 - (2.0 * t_16)))) * 0.675);
  float t_18;
  t_18 = max (min ((((tmpvar_5.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_19;
  tmpvar_19 = ((t_18 * (t_18 * (3.0 - (2.0 * t_18)))) * 0.675);
  float t_20;
  t_20 = max (min ((((tmpvar_6.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_21;
  tmpvar_21 = ((t_20 * (t_20 * (3.0 - (2.0 * t_20)))) * 0.5);
  float t_22;
  t_22 = max (min ((((tmpvar_7.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_23;
  tmpvar_23 = ((t_22 * (t_22 * (3.0 - (2.0 * t_22)))) * 0.5);
  float t_24;
  t_24 = max (min ((((tmpvar_8.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_25;
  tmpvar_25 = ((t_24 * (t_24 * (3.0 - (2.0 * t_24)))) * 0.2);
  float t_26;
  t_26 = max (min ((((tmpvar_9.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_27;
  tmpvar_27 = ((t_26 * (t_26 * (3.0 - (2.0 * t_26)))) * 0.2);
  float t_28;
  t_28 = max (min ((((tmpvar_10.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_29;
  tmpvar_29 = ((t_28 * (t_28 * (3.0 - (2.0 * t_28)))) * 0.075);
  float t_30;
  t_30 = max (min ((((tmpvar_11.w - tmpvar_1.w) - -0.5) / 0.5), 1.0), 0.0);
  float tmpvar_31;
  tmpvar_31 = ((t_30 * (t_30 * (3.0 - (2.0 * t_30)))) * 0.075);
  gl_FragData[0] = ((((((((((((tmpvar_1 * tmpvar_1.w) + (tmpvar_2 * tmpvar_13)) + (tmpvar_3 * tmpvar_15)) + (tmpvar_4 * tmpvar_17)) + (tmpvar_5 * tmpvar_19)) + (tmpvar_6 * tmpvar_21)) + (tmpvar_7 * tmpvar_23)) + (tmpvar_8 * tmpvar_25)) + (tmpvar_9 * tmpvar_27)) + (tmpvar_10 * tmpvar_29)) + (tmpvar_11 * tmpvar_31)) / (((((((((((tmpvar_1.w + tmpvar_13) + tmpvar_15) + tmpvar_17) + tmpvar_19) + tmpvar_21) + tmpvar_23) + tmpvar_25) + tmpvar_27) + tmpvar_29) + tmpvar_31) + 0.0001));
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
Vector 5 [_Offsets]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c6, 0.16666667, -0.16666667, 0.33333334, -0.33333334
def c7, 0.50000000, -0.50000000, 0.66666669, -0.66666669
def c8, 0.83333337, -0.83333337, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, c5
mul r0.xy, c4, r0
mad o2, r0.xyxy, c6.xxyy, v1.xyxy
mad o3, r0.xyxy, c6.zzww, v1.xyxy
mad o4, r0.xyxy, c7.xxyy, v1.xyxy
mad o5, r0.xyxy, c7.zzww, v1.xyxy
mad o6, r0.xyxy, c8.xxyy, v1.xyxy
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedgohcneiglfdbcbnppkcpeddheeclmhjfabaaaaaaaeaeaaaaadaaaaaa
cmaaaaaaiaaaaaaafaabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
lmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
lmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefckmacaaaaeaaaabaaklaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaa
afaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaa
abaaaaaadgaaaaafbcaabaaaaaaaaaaaabeaaaaaaaaaiadpdgaaaaagmcaabaaa
aaaaaaaaagiecaaaaaaaaaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaaagaobaaa
aaaaaaaaegiecaaaaaaaaaaaadaaaaaadiaaaaaidcaabaaaaaaaaaaaegaabaaa
aaaaaaaaegiacaaaaaaaaaaaacaaaaaadcaaaaampccabaaaacaaaaaaegaobaaa
aaaaaaaaaceaaaaaklkkckdoklkkckdoklkkckloklkkckloegbebaaaabaaaaaa
dcaaaaampccabaaaadaaaaaaogaobaaaaaaaaaaaaceaaaaaklkkkkdoklkkkkdo
klkkkkloklkkkkloegbebaaaabaaaaaadcaaaaampccabaaaaeaaaaaaogaobaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaalpaaaaaalpegbebaaaabaaaaaa
dcaaaaampccabaaaafaaaaaaogaobaaaaaaaaaaaaceaaaaaklkkckdpklkkckdp
klkkcklpklkkcklpegbebaaaabaaaaaadcaaaaampccabaaaagaaaaaaogaobaaa
aaaaaaaaaceaaaaafgffffdpfgffffdpfgfffflpfgfffflpegbebaaaabaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 0.50000000, 2.00000000, 3.00000000, 0.80000001
def c1, 0.67500001, 0.20000000, 0.07500000, 0.00010000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5
texld r4, v0, s0
texld r1, v1, s0
add r0.x, -r4.w, r1.w
add r0.x, r0, c0
mul_sat r0.x, r0, c0.y
mad r0.y, -r0.x, c0, c0.z
mul r0.x, r0, r0
mul r0.x, r0, r0.y
mul r3.x, r0, c0.w
texld r0, v1.zwzw, s0
mul r1, r1, r3.x
mad r2, r4, r4.w, r1
add r3.y, -r4.w, r0.w
add r3.y, r3, c0.x
mul_sat r3.z, r3.y, c0.y
texld r1, v2, s0
add r3.y, -r4.w, r1.w
mad r3.w, -r3.z, c0.y, c0.z
mul r3.z, r3, r3
mul r3.z, r3, r3.w
mul r4.y, r3.z, c0.w
add r3.y, r3, c0.x
mad r2, r0, r4.y, r2
mul_sat r3.y, r3, c0
mad r0.y, -r3, c0, c0.z
mul r0.x, r3.y, r3.y
mul r3.y, r0.x, r0
mul r4.x, r3.y, c1
texld r0, v2.zwzw, s0
add r3.y, -r4.w, r0.w
mad r2, r1, r4.x, r2
add r3.y, r3, c0.x
mul_sat r3.z, r3.y, c0.y
texld r1, v3, s0
add r3.y, -r4.w, r1.w
mad r3.w, -r3.z, c0.y, c0.z
mul r3.z, r3, r3
mul r3.z, r3, r3.w
mul r4.z, r3, c1.x
add r3.y, r3, c0.x
mad r2, r0, r4.z, r2
mul_sat r3.y, r3, c0
mad r0.y, -r3, c0, c0.z
mul r0.x, r3.y, r3.y
mul r3.y, r0.x, r0
mul r5.x, r3.y, c0
mad r2, r1, r5.x, r2
texld r0, v3.zwzw, s0
add r3.y, -r4.w, r0.w
add r3.y, r3, c0.x
mul_sat r3.z, r3.y, c0.y
texld r1, v4, s0
add r3.y, -r4.w, r1.w
mad r3.w, -r3.z, c0.y, c0.z
mul r3.z, r3, r3
mul r3.z, r3, r3.w
mul r5.y, r3.z, c0.x
add r3.y, r3, c0.x
mad r0, r0, r5.y, r2
mul_sat r3.y, r3, c0
mad r2.y, -r3, c0, c0.z
mul r2.x, r3.y, r3.y
mul r2.x, r2, r2.y
add r2.y, r4.w, r3.x
mul r5.z, r2.x, c1.y
mad r3, r1, r5.z, r0
add r0.x, r4.y, r2.y
add r0.y, r4.x, r0.x
texld r2, v4.zwzw, s0
add r0.x, -r4.w, r2.w
add r0.y, r4.z, r0
add r0.y, r5.x, r0
texld r1, v5, s0
add r0.x, r0, c0
add r5.x, -r4.w, r1.w
add r0.z, r5.y, r0.y
mul_sat r0.x, r0, c0.y
mad r0.y, -r0.x, c0, c0.z
mul r0.x, r0, r0
mul r0.x, r0, r0.y
mul r4.y, r0.x, c1
add r0.y, r5.z, r0.z
add r4.x, r4.y, r0.y
texld r0, v5.zwzw, s0
add r4.z, r0.w, -r4.w
add r4.w, r5.x, c0.x
mul_sat r4.w, r4, c0.y
mad r5.x, -r4.w, c0.y, c0.z
mul r4.w, r4, r4
add r4.z, r4, c0.x
mad r2, r2, r4.y, r3
mul r5.x, r4.w, r5
mul_sat r4.z, r4, c0.y
mad r4.w, -r4.z, c0.y, c0.z
mul r4.z, r4, r4
mul r4.w, r4.z, r4
mul r4.z, r5.x, c1
add r5.x, r4.z, r4
mul r4.x, r4.w, c1.z
mad r1, r1, r4.z, r2
add r4.w, r4.x, r5.x
add r3.x, r4.w, c1.w
rcp r2.x, r3.x
mad r0, r0, r4.x, r1
mul oC0, r0, r2.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedhidigannnpjiklkfenkkjcpkagelminoabaaaaaaimaoaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfeanaaaaeaaaaaaaffadaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaa
gcbaaaadpcbabaaaaeaaaaaagcbaaaadpcbabaaaafaaaaaagcbaaaadpcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacaeaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaegbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaacaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaaaaaaaaibcaabaaaadaaaaaadkaabaaaabaaaaaadkaabaiaebaaaaaa
acaaaaaaaaaaaaahbcaabaaaadaaaaaaakaabaaaadaaaaaaabeaaaaaaaaaaadp
aacaaaahbcaabaaaadaaaaaaakaabaaaadaaaaaaakaabaaaadaaaaaadcaaaaaj
ccaabaaaadaaaaaaakaabaaaadaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaea
diaaaaahbcaabaaaadaaaaaaakaabaaaadaaaaaaakaabaaaadaaaaaadiaaaaah
bcaabaaaadaaaaaaakaabaaaadaaaaaabkaabaaaadaaaaaadiaaaaahccaabaaa
adaaaaaaakaabaaaadaaaaaaabeaaaaamnmmemdpdcaaaaajbcaabaaaadaaaaaa
akaabaaaadaaaaaaabeaaaaamnmmemdpdkaabaaaacaaaaaadiaaaaahpcaabaaa
abaaaaaaegaobaaaabaaaaaafgafbaaaadaaaaaadcaaaaajpcaabaaaabaaaaaa
egaobaaaacaaaaaapgapbaaaacaaaaaaegaobaaaabaaaaaaaaaaaaaibcaabaaa
acaaaaaadkaabaaaaaaaaaaadkaabaiaebaaaaaaacaaaaaaaaaaaaahbcaabaaa
acaaaaaaakaabaaaacaaaaaaabeaaaaaaaaaaadpaacaaaahbcaabaaaacaaaaaa
akaabaaaacaaaaaaakaabaaaacaaaaaadcaaaaajccaabaaaacaaaaaaakaabaaa
acaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaahbcaabaaaacaaaaaa
akaabaaaacaaaaaaakaabaaaacaaaaaadiaaaaahbcaabaaaacaaaaaaakaabaaa
acaaaaaabkaabaaaacaaaaaadiaaaaahccaabaaaacaaaaaaakaabaaaacaaaaaa
abeaaaaamnmmemdpdcaaaaajbcaabaaaacaaaaaaakaabaaaacaaaaaaabeaaaaa
mnmmemdpakaabaaaadaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaaaaaaaaa
fgafbaaaacaaaaaaegaobaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaa
adaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaiccaabaaaacaaaaaa
dkaabaiaebaaaaaaacaaaaaadkaabaaaabaaaaaaaaaaaaahccaabaaaacaaaaaa
bkaabaaaacaaaaaaabeaaaaaaaaaaadpaacaaaahccaabaaaacaaaaaabkaabaaa
acaaaaaabkaabaaaacaaaaaadcaaaaajecaabaaaacaaaaaabkaabaaaacaaaaaa
abeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaahccaabaaaacaaaaaabkaabaaa
acaaaaaabkaabaaaacaaaaaadiaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaa
ckaabaaaacaaaaaadiaaaaahecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaa
mnmmcmdpdcaaaaajbcaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaamnmmcmdp
akaabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaa
acaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaadaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaiccaabaaaacaaaaaadkaabaia
ebaaaaaaacaaaaaadkaabaaaabaaaaaaaaaaaaahccaabaaaacaaaaaabkaabaaa
acaaaaaaabeaaaaaaaaaaadpaacaaaahccaabaaaacaaaaaabkaabaaaacaaaaaa
bkaabaaaacaaaaaadcaaaaajecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaa
aaaaaamaabeaaaaaaaaaeaeadiaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaa
bkaabaaaacaaaaaadiaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaackaabaaa
acaaaaaadiaaaaahecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaamnmmcmdp
dcaaaaajbcaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaamnmmcmdpakaabaaa
acaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaaacaaaaaa
egaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaaeaaaaaaeghobaaa
aaaaaaaaaagabaaaaaaaaaaaaaaaaaaiccaabaaaacaaaaaadkaabaiaebaaaaaa
acaaaaaadkaabaaaabaaaaaaaaaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaa
abeaaaaaaaaaaadpaacaaaahccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaa
acaaaaaadcaaaaajecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaama
abeaaaaaaaaaeaeadiaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaa
acaaaaaadiaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaackaabaaaacaaaaaa
diaaaaahecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadpdcaaaaaj
bcaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadpakaabaaaacaaaaaa
dcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaaacaaaaaaegaobaaa
aaaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaaaeaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaaiccaabaaaacaaaaaadkaabaiaebaaaaaaacaaaaaa
dkaabaaaabaaaaaaaaaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaa
aaaaaadpaacaaaahccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaa
dcaaaaajecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaamaabeaaaaa
aaaaeaeadiaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaa
diaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaackaabaaaacaaaaaadiaaaaah
ecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadpdcaaaaajbcaabaaa
acaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadpakaabaaaacaaaaaadcaaaaaj
pcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaaacaaaaaaegaobaaaaaaaaaaa
efaaaaajpcaabaaaabaaaaaaegbabaaaafaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaaaaaaaaiccaabaaaacaaaaaadkaabaiaebaaaaaaacaaaaaadkaabaaa
abaaaaaaaaaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadp
aacaaaahccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaadcaaaaaj
ecaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaea
diaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaadiaaaaah
ccaabaaaacaaaaaabkaabaaaacaaaaaackaabaaaacaaaaaadiaaaaahecaabaaa
acaaaaaabkaabaaaacaaaaaaabeaaaaamnmmemdodcaaaaajbcaabaaaacaaaaaa
bkaabaaaacaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaajpcaabaaa
aaaaaaaaegaobaaaabaaaaaakgakbaaaacaaaaaaegaobaaaaaaaaaaaefaaaaaj
pcaabaaaabaaaaaaogbkbaaaafaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
aaaaaaaiccaabaaaacaaaaaadkaabaiaebaaaaaaacaaaaaadkaabaaaabaaaaaa
aaaaaaahccaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadpaacaaaah
ccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaadcaaaaajecaabaaa
acaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaah
ccaabaaaacaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaadiaaaaahccaabaaa
acaaaaaabkaabaaaacaaaaaackaabaaaacaaaaaadiaaaaahecaabaaaacaaaaaa
bkaabaaaacaaaaaaabeaaaaamnmmemdodcaaaaajbcaabaaaacaaaaaabkaabaaa
acaaaaaaabeaaaaamnmmemdoakaabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaa
egaobaaaabaaaaaakgakbaaaacaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaa
abaaaaaaegbabaaaagaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaai
ccaabaaaacaaaaaadkaabaiaebaaaaaaacaaaaaadkaabaaaabaaaaaaaaaaaaah
ccaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadpaacaaaahccaabaaa
acaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaadcaaaaajecaabaaaacaaaaaa
bkaabaaaacaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaahccaabaaa
acaaaaaabkaabaaaacaaaaaabkaabaaaacaaaaaadiaaaaahccaabaaaacaaaaaa
bkaabaaaacaaaaaackaabaaaacaaaaaadiaaaaahecaabaaaacaaaaaabkaabaaa
acaaaaaaabeaaaaajkjjjjdndcaaaaajbcaabaaaacaaaaaabkaabaaaacaaaaaa
abeaaaaajkjjjjdnakaabaaaacaaaaaadcaaaaajpcaabaaaaaaaaaaaegaobaaa
abaaaaaakgakbaaaacaaaaaaegaobaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaagaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaaaaaaaiccaabaaa
acaaaaaadkaabaiaebaaaaaaacaaaaaadkaabaaaabaaaaaaaaaaaaahccaabaaa
acaaaaaabkaabaaaacaaaaaaabeaaaaaaaaaaadpaacaaaahccaabaaaacaaaaaa
bkaabaaaacaaaaaabkaabaaaacaaaaaadcaaaaajecaabaaaacaaaaaabkaabaaa
acaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaahccaabaaaacaaaaaa
bkaabaaaacaaaaaabkaabaaaacaaaaaadiaaaaahccaabaaaacaaaaaabkaabaaa
acaaaaaackaabaaaacaaaaaadiaaaaahecaabaaaacaaaaaabkaabaaaacaaaaaa
abeaaaaajkjjjjdndcaaaaajbcaabaaaacaaaaaabkaabaaaacaaaaaaabeaaaaa
jkjjjjdnakaabaaaacaaaaaaaaaaaaahbcaabaaaacaaaaaaakaabaaaacaaaaaa
abeaaaaabhlhnbdidcaaaaajpcaabaaaaaaaaaaaegaobaaaabaaaaaakgakbaaa
acaaaaaaegaobaaaaaaaaaaaaoaaaaahpccabaaaaaaaaaaaegaobaaaaaaaaaaa
agaabaaaacaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend One One
 BlendOp Max
  ColorMask A
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  gl_FragData[0] = texture2D (_MainTex, xlv_TEXCOORD1);
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
dcl_texcoord1 v0.xy
texld r0, v0, s0
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedjloobendnpaiiejbaokogkbljkgkldnkabaaaaaadmabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgeaaaaaaeaaaaaaabjaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
mcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaaefaaaaajpccabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  ColorMask A
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform vec4 _ZBufferParams;
uniform sampler2D _CameraDepthTexture;
uniform vec4 _CurveParams;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 color_1;
  color_1.xyz = vec3(0.0, 0.0, 0.0);
  float tmpvar_2;
  tmpvar_2 = (1.0/(((_ZBufferParams.x * texture2D (_CameraDepthTexture, xlv_TEXCOORD1).x) + _ZBufferParams.y)));
  color_1.w = ((_CurveParams.z * (_CurveParams.w - tmpvar_2)) / (tmpvar_2 + 1e-05));
  color_1.w = clamp (max (0.0, (color_1.w - _CurveParams.y)), 0.0, _CurveParams.x);
  gl_FragData[0] = color_1;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_ZBufferParams]
Vector 1 [_CurveParams]
SetTexture 0 [_CameraDepthTexture] 2D 0
"ps_3_0
dcl_2d s0
def c2, 0.00001000, 0.00000000, 0, 0
dcl_texcoord1 v0.xy
texld r0.x, v0, s0
mad r0.x, r0, c0, c0.y
rcp r0.x, r0.x
add r0.y, r0.x, c2.x
add r0.x, -r0, c1.w
rcp r0.y, r0.y
mul r0.x, r0, c1.z
mad r0.x, r0, r0.y, -c1.y
max r0.x, r0, c2.y
min r0.x, r0, c1
mov oC0.xyz, c2.y
max oC0.w, r0.x, c2.y
"
}
SubProgram "d3d11 " {
SetTexture 0 [_CameraDepthTexture] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_CurveParams]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedhpefaggeanimkjikbmpnkldcpglekaeaabaaaaaaleacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcnmabaaaaeaaaaaaahhaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
mcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaa
bkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaaaaaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaakmmfchdhdiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaackiacaaaaaaaaaaaabaaaaaaaoaaaaahbcaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaabkiacaiaebaaaaaaaaaaaaaaabaaaaaadeaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaaaaaddaaaaaiiccabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaaaaaaaaaaaabaaaaaadgaaaaaihccabaaaaaaaaaaaaceaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = xlv_TEXCOORD1;
  int l_2;
  vec4 steps_3;
  vec2 lenStep_4;
  vec4 sum_5;
  float sampleCount_6;
  vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD1);
  sampleCount_6 = tmpvar_7.w;
  sum_5 = (tmpvar_7 * tmpvar_7.w);
  vec2 tmpvar_8;
  tmpvar_8 = (tmpvar_7.ww * 0.0909091);
  lenStep_4 = tmpvar_8;
  steps_3 = (((_Offsets.xyxy * _MainTex_TexelSize.xyxy) * tmpvar_8.xyxy) * vec4(1.0, 1.0, -1.0, -1.0));
  l_2 = 1;
  for (int l_2 = 1; l_2 < 12; ) {
    vec4 tmpvar_9;
    tmpvar_9 = (tmpvar_1.xyxy + (steps_3 * float(l_2)));
    vec4 tmpvar_10;
    tmpvar_10 = texture2D (_MainTex, tmpvar_9.xy);
    vec4 tmpvar_11;
    tmpvar_11 = texture2D (_MainTex, tmpvar_9.zw);
    vec2 tmpvar_12;
    tmpvar_12.x = tmpvar_10.w;
    tmpvar_12.y = tmpvar_11.w;
    vec2 tmpvar_13;
    vec2 t_14;
    t_14 = max (min ((((tmpvar_12 - (lenStep_4.xx * float(l_2))) - vec2(-0.4, -0.4)) / vec2(0.4, 0.4)), 1.0), 0.0);
    tmpvar_13 = (t_14 * (t_14 * (3.0 - (2.0 * t_14))));
    sum_5 = (sum_5 + ((tmpvar_10 * tmpvar_13.x) + (tmpvar_11 * tmpvar_13.y)));
    sampleCount_6 = (sampleCount_6 + dot (tmpvar_13, vec2(1.0, 1.0)));
    l_2 = (l_2 + 1);
  };
  gl_FragData[0] = (sum_5 / (1e-05 + sampleCount_6));
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Vector 1 [_Offsets]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c2, 0.09090909, 1.00000000, -1.00000000, 0.40000001
defi i0, 11, 1, 1, 0
def c3, 2.50000000, 2.00000000, 3.00000000, 0.00001000
dcl_texcoord1 v0.xy
texld r0, v0, s0
mov r1.xy, c1
mul r1.xy, c0, r1
mul r5.y, r0.w, c2.x
mul r1.xy, r5.y, r1
mov r5.x, r0.w
mul r2, r0, r0.w
mul r3, r1.xyxy, c2.yyzz
mov r5.z, c2.y
loop aL, i0
mad r0, r3, r5.z, v0.xyxy
texld r1, r0.zwzw, s0
texld r0, r0, s0
mov r4.y, r1.w
mov r4.x, r0.w
mad r4.xy, r5.z, -r5.y, r4
add r4.xy, r4, c2.w
mul_sat r4.xy, r4, c3.x
mad r4.zw, -r4.xyxy, c3.y, c3.z
mul r4.xy, r4, r4
mul r4.xy, r4, r4.zwzw
mul r1, r4.y, r1
mad r0, r0, r4.x, r1
add r1.x, r4, r4.y
add r2, r2, r0
add r5.x, r5, r1
add r5.z, r5, c2.y
endloop
add r0.x, r5, c3.w
rcp r0.x, r0.x
mul oC0, r2, r0.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
BindCB  "$Globals" 0
"ps_4_0
eefiecedifmadniofklhhocnfdlldjaapgfmhgplabaaaaaaoiaeaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaaeaaaaeaaaaaaaaeabaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaiaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahpcaabaaaabaaaaaapgapbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaimcolkdndiaaaaajpcaabaaaacaaaaaaegiecaaaaaaaaaaaacaaaaaa
egiecaaaaaaaaaaaadaaaaaadiaaaaahpcaabaaaacaaaaaaagaabaaaaaaaaaaa
egaobaaaacaaaaaadiaaaaakpcaabaaaacaaaaaaegaobaaaacaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaialpaaaaialpdgaaaaafpcaabaaaadaaaaaaegaobaaa
abaaaaaadgaaaaafccaabaaaaaaaaaaadkaabaaaaaaaaaaadgaaaaafecaabaaa
aaaaaaaaabeaaaaaabaaaaaadaaaaaabcbaaaaahbcaabaaaaeaaaaaackaabaaa
aaaaaaaaabeaaaaaamaaaaaaadaaaeadakaabaaaaeaaaaaaclaaaaafbcaabaaa
aeaaaaaackaabaaaaaaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaaacaaaaaa
agaabaaaaeaaaaaaogbobaaaabaaaaaaefaaaaajpcaabaaaagaaaaaaegaabaaa
afaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaafaaaaaa
ogakbaaaafaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaafbcaabaaa
ahaaaaaadkaabaaaagaaaaaadgaaaaafccaabaaaahaaaaaadkaabaaaafaaaaaa
dcaaaaakdcaabaaaaeaaaaaaagaabaiaebaaaaaaaaaaaaaaagaabaaaaeaaaaaa
egaabaaaahaaaaaaaaaaaaakdcaabaaaaeaaaaaaegaabaaaaeaaaaaaaceaaaaa
mnmmmmdomnmmmmdoaaaaaaaaaaaaaaaadicaaaakdcaabaaaaeaaaaaaegaabaaa
aeaaaaaaaceaaaaaaaaacaeaaaaacaeaaaaaaaaaaaaaaaaadcaaaaapmcaabaaa
aeaaaaaaagaebaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaamaaaaaaama
aceaaaaaaaaaaaaaaaaaaaaaaaaaeaeaaaaaeaeadiaaaaahdcaabaaaaeaaaaaa
egaabaaaaeaaaaaaegaabaaaaeaaaaaadiaaaaahdcaabaaaaeaaaaaaegaabaaa
aeaaaaaaogakbaaaaeaaaaaadiaaaaahpcaabaaaafaaaaaafgafbaaaaeaaaaaa
egaobaaaafaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaaagaaaaaaagaabaaa
aeaaaaaaegaobaaaafaaaaaaaaaaaaahpcaabaaaadaaaaaaegaobaaaadaaaaaa
egaobaaaafaaaaaaapaaaaakbcaabaaaaeaaaaaaegaabaaaaeaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaaaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakaabaaaaeaaaaaaboaaaaahecaabaaaaaaaaaaackaabaaaaaaaaaaa
abeaaaaaabaaaaaabgaaaaabaaaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaakmmfchdhaoaaaaahpccabaaaaaaaaaaaegaobaaaadaaaaaaagaabaaa
aaaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec4 _MainTex_TexelSize;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 outColor_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
  vec4 tmpvar_3;
  tmpvar_3 = texture2D (_MainTex, (xlv_TEXCOORD0 + (0.75 * _MainTex_TexelSize.xy)));
  vec4 tmpvar_4;
  tmpvar_4 = texture2D (_MainTex, (xlv_TEXCOORD0 - (0.75 * _MainTex_TexelSize.xy)));
  vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, (xlv_TEXCOORD0 + (vec2(0.75, -0.75) * _MainTex_TexelSize.xy)));
  vec4 tmpvar_6;
  tmpvar_6 = texture2D (_MainTex, (xlv_TEXCOORD0 - (vec2(0.75, -0.75) * _MainTex_TexelSize.xy)));
  vec4 tmpvar_7;
  tmpvar_7.x = tmpvar_3.w;
  tmpvar_7.y = tmpvar_4.w;
  tmpvar_7.z = tmpvar_5.w;
  tmpvar_7.w = tmpvar_6.w;
  vec4 tmpvar_8;
  tmpvar_8 = clamp ((10.0 * tmpvar_7), 0.0, 1.0);
  float tmpvar_9;
  tmpvar_9 = dot (tmpvar_8, vec4(1.0, 1.0, 1.0, 1.0));
  vec4 tmpvar_10;
  tmpvar_10 = ((((tmpvar_3 * tmpvar_8.x) + (tmpvar_4 * tmpvar_8.y)) + (tmpvar_5 * tmpvar_8.z)) + (tmpvar_6 * tmpvar_8.w));
  outColor_1 = tmpvar_2;
  if ((((tmpvar_2.w * tmpvar_9) * 8.0) > 1e-05)) {
    outColor_1.xyz = (tmpvar_10.xyz / tmpvar_9);
  };
  gl_FragData[0] = outColor_1;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c1, 0.75000000, -0.75000000, 10.00000000, 1.00000000
def c2, 8.00000000, -0.00001000, 0, 0
dcl_texcoord0 v0.xy
mov r0.zw, c0.xyxy
mad r1.xy, c1.x, -r0.zwzw, v0
texld r1, r1, s0
mov r2.zw, c0.xyxy
mad r3.xy, c1, -r2.zwzw, v0
texld r3, r3, s0
mov r0.xy, c0
mad r0.xy, c1.x, r0, v0
texld r0, r0, s0
mov r2.xy, c0
mad r2.xy, c1, r2, v0
texld r2, r2, s0
mov r4.x, r0.w
mov r4.y, r1.w
mov r4.w, r3
mov r4.z, r2.w
mul_sat r4, r4, c1.z
mul r1.xyz, r4.y, r1
mad r0.xyz, r4.x, r0, r1
texld r1, v0, s0
mad r0.xyz, r4.z, r2, r0
dp4 r0.w, r4, c1.w
rcp r2.x, r0.w
mad r0.xyz, r4.w, r3, r0
mul r0.w, r1, r0
mul r0.xyz, r0, r2.x
mad r0.w, r0, c2.x, c2.y
cmp oC0.xyz, -r0.w, r1, r0
mov oC0.w, r1
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
BindCB  "$Globals" 0
"ps_4_0
eefiecedjcmflllomockabffhlpdnkpdmhiajifmabaaaaaaaeaeaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefccmadaaaaeaaaaaaamlaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaaddcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacafaaaaaadcaaaaanpcaabaaaaaaaaaaaegiecaaaaaaaaaaa
acaaaaaaaceaaaaaaaaaeadpaaaaeadpaaaaeadpaaaaealpegbebaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadgaaaaafbcaabaaaacaaaaaadkaabaaaabaaaaaadcaaaaao
pcaabaaaadaaaaaaegiecaiaebaaaaaaaaaaaaaaacaaaaaaaceaaaaaaaaaeadp
aaaaeadpaaaaeadpaaaaealpegbebaaaabaaaaaaefaaaaajpcaabaaaaeaaaaaa
egaabaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaa
adaaaaaaogakbaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaaf
ccaabaaaacaaaaaadkaabaaaaeaaaaaadgaaaaafecaabaaaacaaaaaadkaabaaa
aaaaaaaadgaaaaaficaabaaaacaaaaaadkaabaaaadaaaaaadicaaaakpcaabaaa
acaaaaaaegaobaaaacaaaaaaaceaaaaaaaaacaebaaaacaebaaaacaebaaaacaeb
diaaaaahhcaabaaaaeaaaaaafgafbaaaacaaaaaaegacbaaaaeaaaaaadcaaaaaj
hcaabaaaabaaaaaaegacbaaaabaaaaaaagaabaaaacaaaaaaegacbaaaaeaaaaaa
dcaaaaajhcaabaaaaaaaaaaaegacbaaaaaaaaaaakgakbaaaacaaaaaaegacbaaa
abaaaaaadcaaaaajhcaabaaaaaaaaaaaegacbaaaadaaaaaapgapbaaaacaaaaaa
egacbaaaaaaaaaaabbaaaaakicaabaaaaaaaaaaaegaobaaaacaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaiadpaaaaiadpaoaaaaahhcaabaaaaaaaaaaaegacbaaa
aaaaaaaapgapbaaaaaaaaaaaefaaaaajpcaabaaaabaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahicaabaaaaaaaaaaadkaabaaa
aaaaaaaadkaabaaaabaaaaaadbaaaaahicaabaaaaaaaaaaaabeaaaaakmmfkhdf
dkaabaaaaaaaaaaadhaaaaajhccabaaaaaaaaaaapgapbaaaaaaaaaaaegacbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaaabaaaaaa
doaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend SrcAlpha OneMinusSrcAlpha
  ColorMask RGB
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec2 xlv_TEXCOORD0;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = texture2D (_MainTex, xlv_TEXCOORD0);
  vec4 tmpvar_2;
  tmpvar_2.xyz = tmpvar_1.xyz;
  tmpvar_2.w = (1.0 - clamp ((tmpvar_1.w * 5.0), 0.0, 1.0));
  gl_FragData[0] = tmpvar_2;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 5.00000000, 1.00000000, 0, 0
dcl_texcoord0 v0.xy
texld r0, v0, s0
mul_sat r0.w, r0, c0.x
mov oC0.xyz, r0
add oC0.w, -r0, c0.y
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecednkfjhkhkoojopnfnmlpfgenbdbcjdaecabaaaaaajeabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amaaaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefclmaaaaaaeaaaaaaacpaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaegbabaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dicaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaakaeadgaaaaaf
hccabaaaaaaaaaaaegacbaaaaaaaaaaaaaaaaaaiiccabaaaaaaaaaaadkaabaia
ebaaaaaaaaaaaaaaabeaaaaaaaaaiadpdoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  ColorMask A
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform vec4 _ZBufferParams;
uniform sampler2D _CameraDepthTexture;
uniform vec4 _CurveParams;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 color_1;
  color_1.xyz = vec3(0.0, 0.0, 0.0);
  float tmpvar_2;
  tmpvar_2 = (1.0/(((_ZBufferParams.x * texture2D (_CameraDepthTexture, xlv_TEXCOORD1).x) + _ZBufferParams.y)));
  color_1.w = ((_CurveParams.z * (_CurveParams.w - tmpvar_2)) / (tmpvar_2 + 1e-05));
  color_1.w = clamp (max (0.0, (color_1.w - _CurveParams.y)), 0.0, _CurveParams.x);
  gl_FragData[0] = vec4(float((color_1.w > 0.0)));
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_ZBufferParams]
Vector 1 [_CurveParams]
SetTexture 0 [_CameraDepthTexture] 2D 0
"ps_3_0
dcl_2d s0
def c2, 0.00001000, 0.00000000, 1.00000000, 0
dcl_texcoord1 v0.xy
texld r0.x, v0, s0
mad r0.x, r0, c0, c0.y
rcp r0.x, r0.x
add r0.y, r0.x, c2.x
add r0.x, -r0, c1.w
rcp r0.y, r0.y
mul r0.x, r0, c1.z
mad r0.x, r0, r0.y, -c1.y
max r0.x, r0, c2.y
min r0.x, r0, c1
max r0.x, r0, c2.y
cmp oC0, -r0.x, c2.y, c2.z
"
}
SubProgram "d3d11 " {
SetTexture 0 [_CameraDepthTexture] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_CurveParams]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedebobjjamioojedhlnnabblibfjibjaikabaaaaaaniacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcaaacaaaaeaaaaaaaiaaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
mcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dcaaaaalbcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaa
bkiacaaaabaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaiadpaaaaiadpakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaa
akaabaiaebaaaaaaaaaaaaaadkiacaaaaaaaaaaaabaaaaaaaaaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaakmmfchdhdiaaaaaiccaabaaaaaaaaaaa
bkaabaaaaaaaaaaackiacaaaaaaaaaaaabaaaaaaaoaaaaahbcaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaabkiacaiaebaaaaaaaaaaaaaaabaaaaaadeaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaaaaaddaaaaaibcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaaaaaaaaaaaabaaaaaadbaaaaahbcaabaaaaaaaaaaaabeaaaaa
aaaaaaaaakaabaaaaaaaaaaaabaaaaakpccabaaaaaaaaaaaagaabaaaaaaaaaaa
aceaaaaaaaaaiadpaaaaiadpaaaaiadpaaaaiadpdoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform sampler2D _FgOverlap;
uniform sampler2D _LowRez;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = texture2D (_MainTex, xlv_TEXCOORD1);
  vec4 tmpvar_2;
  tmpvar_2.xyz = mix (tmpvar_1, texture2D (_LowRez, xlv_TEXCOORD1), vec4(clamp ((max (tmpvar_1.w, texture2D (_FgOverlap, xlv_TEXCOORD1).w) * 8.0), 0.0, 1.0))).xyz;
  tmpvar_2.w = tmpvar_1.w;
  gl_FragData[0] = tmpvar_2;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LowRez] 2D 1
SetTexture 2 [_FgOverlap] 2D 2
"ps_3_0
dcl_2d s0
dcl_2d s1
dcl_2d s2
def c0, 8.00000000, 0, 0, 0
dcl_texcoord1 v0.xy
texld r0, v0, s0
texld r1.w, v0, s2
texld r1.xyz, v0, s1
max r1.w, r0, r1
add r1.xyz, -r0, r1
mul_sat r1.w, r1, c0.x
mad oC0.xyz, r1.w, r1, r0
mov oC0.w, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_LowRez] 2D 2
SetTexture 2 [_FgOverlap] 2D 1
"ps_4_0
eefiecedodpjifahljlpmgldlfffbholglhpgefkabaaaaaafeacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefchmabaaaaeaaaaaaafpaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafkaaaaadaagabaaa
acaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaa
ffffaaaafibiaaaeaahabaaaacaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacadaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaacaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaa
abaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadeaaaaah
bcaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaabaaaaaadicaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaaaebefaaaaajpcaabaaaacaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaacaaaaaaaaaaaaaiocaabaaa
aaaaaaaaagajbaiaebaaaaaaabaaaaaaagajbaaaacaaaaaadcaaaaajhccabaaa
aaaaaaaaagaabaaaaaaaaaaajgahbaaaaaaaaaaaegacbaaaabaaaaaadgaaaaaf
iccabaaaaaaaaaaadkaabaaaabaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform vec4 _ZBufferParams;
uniform sampler2D _MainTex;
uniform sampler2D _CameraDepthTexture;
uniform vec4 _CurveParams;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 color_1;
  color_1.xyz = texture2D (_MainTex, xlv_TEXCOORD1).xyz;
  float tmpvar_2;
  tmpvar_2 = (1.0/(((_ZBufferParams.x * texture2D (_CameraDepthTexture, xlv_TEXCOORD1).x) + _ZBufferParams.y)));
  color_1.w = ((_CurveParams.z * abs((tmpvar_2 - _CurveParams.w))) / (tmpvar_2 + 1e-05));
  color_1.w = (clamp (max (0.0, (color_1.w - _CurveParams.y)), 0.0, _CurveParams.x) * sign((tmpvar_2 - _CurveParams.w)));
  gl_FragData[0] = color_1;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_ZBufferParams]
Vector 1 [_CurveParams]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c2, 0.00001000, 0.00000000, 1.00000000, 0
dcl_texcoord1 v0.xy
texld r0.x, v0, s1
mad r0.x, r0, c0, c0.y
rcp r0.y, r0.x
add r0.z, r0.y, c2.x
add r0.x, r0.y, -c1.w
abs r0.y, r0.x
rcp r0.z, r0.z
mul r0.y, r0, c1.z
mad r0.y, r0, r0.z, -c1
cmp r0.z, r0.x, c2.y, c2
cmp r0.x, -r0, c2.y, c2.z
max r0.y, r0, c2
add r0.z, r0.x, -r0
min r0.y, r0, c1.x
max r0.x, r0.y, c2.y
mul oC0.w, r0.x, r0.z
texld oC0.xyz, v0, s0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
ConstBuffer "$Globals" 80
Vector 16 [_CurveParams]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedkckpnoaefmjgcbnfofmaohhodbcpniigabaaaaaaheadaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcjmacaaaaeaaaaaaakhaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadmcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaadcaaaaal
bcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaabkiacaaa
abaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadp
aaaaiadpaaaaiadpakaabaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaaakaabaaa
aaaaaaaaabeaaaaakmmfchdhaaaaaaajbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
dkiacaiaebaaaaaaaaaaaaaaabaaaaaadiaaaaajecaabaaaaaaaaaaaakaabaia
ibaaaaaaaaaaaaaackiacaaaaaaaaaaaabaaaaaaaoaaaaahccaabaaaaaaaaaaa
ckaabaaaaaaaaaaabkaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaabkaabaaa
aaaaaaaabkiacaiaebaaaaaaaaaaaaaaabaaaaaadeaaaaahccaabaaaaaaaaaaa
bkaabaaaaaaaaaaaabeaaaaaaaaaaaaaddaaaaaiccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakiacaaaaaaaaaaaabaaaaaadbaaaaahecaabaaaaaaaaaaaabeaaaaa
aaaaaaaaakaabaaaaaaaaaaadbaaaaahbcaabaaaaaaaaaaaakaabaaaaaaaaaaa
abeaaaaaaaaaaaaaboaaaaaibcaabaaaaaaaaaaackaabaiaebaaaaaaaaaaaaaa
akaabaaaaaaaaaaaclaaaaafbcaabaaaaaaaaaaaakaabaaaaaaaaaaadiaaaaah
iccabaaaaaaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaaf
hccabaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
vec3 DiscKernel[28];
varying vec2 xlv_TEXCOORD1;
void main ()
{
  DiscKernel[0] = vec3(0.62463, 0.54337, 0.8279);
  DiscKernel[1] = vec3(-0.13414, -0.94488, 0.95435);
  DiscKernel[2] = vec3(0.38772, -0.43475, 0.58253);
  DiscKernel[3] = vec3(0.12126, -0.19282, 0.22778);
  DiscKernel[4] = vec3(-0.20388, 0.11133, 0.2323);
  DiscKernel[5] = vec3(0.83114, -0.29218, 0.881);
  DiscKernel[6] = vec3(0.10759, -0.57839, 0.58831);
  DiscKernel[7] = vec3(0.28285, 0.79036, 0.83945);
  DiscKernel[8] = vec3(-0.36622, 0.39516, 0.53876);
  DiscKernel[9] = vec3(0.75591, 0.21916, 0.78704);
  DiscKernel[10] = vec3(-0.5261, 0.02386, 0.52664);
  DiscKernel[11] = vec3(-0.88216, -0.24471, 0.91547);
  DiscKernel[12] = vec3(-0.48888, -0.2933, 0.57011);
  DiscKernel[13] = vec3(0.44014, -0.08558, 0.44838);
  DiscKernel[14] = vec3(0.21179, 0.51373, 0.55567);
  DiscKernel[15] = vec3(0.05483, 0.95701, 0.95858);
  DiscKernel[16] = vec3(-0.59001, -0.70509, 0.91938);
  DiscKernel[17] = vec3(-0.80065, 0.24631, 0.83768);
  DiscKernel[18] = vec3(-0.19424, -0.18402, 0.26757);
  DiscKernel[19] = vec3(-0.43667, 0.76751, 0.88304);
  DiscKernel[20] = vec3(0.21666, 0.11602, 0.24577);
  DiscKernel[21] = vec3(0.15696, -0.856, 0.87027);
  DiscKernel[22] = vec3(-0.75821, 0.58363, 0.95682);
  DiscKernel[23] = vec3(0.99284, -0.02904, 0.99327);
  DiscKernel[24] = vec3(-0.22234, -0.57907, 0.62029);
  DiscKernel[25] = vec3(0.55052, -0.66984, 0.86704);
  DiscKernel[26] = vec3(0.46431, 0.28115, 0.5428);
  DiscKernel[27] = vec3(-0.07214, 0.60554, 0.60982);
  vec2 tmpvar_1;
  tmpvar_1 = xlv_TEXCOORD1;
  vec4 returnValue_2;
  int l_3;
  float sampleCount_4;
  vec4 poissonScale_5;
  vec4 sum_6;
  vec4 centerTap_7;
  vec4 tmpvar_8;
  tmpvar_8 = texture2D (_MainTex, xlv_TEXCOORD1);
  centerTap_7 = tmpvar_8;
  poissonScale_5 = ((_MainTex_TexelSize.xyxy * tmpvar_8.w) * _Offsets.w);
  float tmpvar_9;
  tmpvar_9 = max ((tmpvar_8.w * 0.25), _Offsets.z);
  sampleCount_4 = tmpvar_9;
  sum_6 = (tmpvar_8 * tmpvar_9);
  l_3 = 0;
  for (int l_3 = 0; l_3 < 28; ) {
    vec4 tmpvar_10;
    tmpvar_10 = texture2D (_MainTex, (tmpvar_1 + (DiscKernel[l_3].xy * poissonScale_5.xy)));
    if ((tmpvar_10.w > 0.0)) {
      float tmpvar_11;
      float t_12;
      t_12 = max (min ((((tmpvar_10.w - (centerTap_7.w * DiscKernel[l_3].z)) - -0.265) / 0.265), 1.0), 0.0);
      tmpvar_11 = (t_12 * (t_12 * (3.0 - (2.0 * t_12))));
      sum_6 = (sum_6 + (tmpvar_10 * tmpvar_11));
      sampleCount_4 = (sampleCount_4 + tmpvar_11);
    };
    l_3 = (l_3 + 1);
  };
  returnValue_2.xyz = (sum_6 / sampleCount_4).xyz;
  returnValue_2.w = tmpvar_8.w;
  gl_FragData[0] = returnValue_2;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Vector 1 [_Offsets]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c2, -0.07214000, 0.60553998, 0.46430999, 0.28115001
def c3, 0.55052000, -0.66983998, -0.22234000, -0.57906997
def c4, 0.99283999, -0.02904000, -0.75821000, 0.58363003
def c5, 0.15696000, -0.85600001, 0.21665999, 0.11602000
def c6, -0.43667001, 0.76751000, -0.19424000, -0.18402000
def c7, -0.80065000, 0.24631000, -0.59000999, -0.70508999
def c8, 0.05483000, 0.95700997, 0.21179000, 0.51372999
def c9, 0.44014001, -0.08558000, -0.48888001, -0.29330000
def c10, -0.88216001, -0.24471000, -0.52609998, 0.02386000
def c11, 0.75590998, 0.21916001, -0.36622000, 0.39515999
def c12, 0.28285000, 0.79035997, 0.10759000, -0.57839000
def c13, 0.83113998, -0.29218000, -0.20388000, 0.11133000
def c14, 0.12126000, -0.19282000, 0.38771999, -0.43474999
def c15, -0.13414000, -0.94488001, 0.62462997, 0.54337001
def c16, 0.25000000, 0.82789999, 0.26499999, 3.77358508
def c17, 2.00000000, 3.00000000, 0.95434999, 0.58253002
def c18, 0.22778000, 0.23230000, 0.88099998, 0.58831000
def c19, 0.83945000, 0.53876001, 0.78704000, 0.52664000
def c20, 0.91547000, 0.57011002, 0.44837999, 0.55567002
def c21, 0.95858002, 0.91938001, 0.83767998, 0.26756999
def c22, 0.88304001, 0.24577001, 0.87027001, 0.95682001
def c23, 0.99326998, 0.62028998, 0.86703998, 0.54280001
def c24, 0.60982001, 0, 0, 0
dcl_texcoord1 v0.xy
texld r0, v0, s0
mul r1.xy, r0.w, c0
mul r6.xy, r1, c1.w
mad r1.xy, r6, c15.zwzw, v0
texld r4, r1, s0
mad r1.x, -r0.w, c16.y, r4.w
add r1.x, r1, c16.z
mul_sat r1.y, r1.x, c16.w
mad r1.x, -r1.y, c17, c17.y
mul r1.y, r1, r1
mul r6.z, r1.y, r1.x
mul r2.x, r0.w, c16
max r6.w, r2.x, c1.z
mul r0.xyz, r0, r6.w
mad r3.xyz, r4, r6.z, r0
mad r1.xy, r6, c15, v0
texld r1, r1, s0
mad r2.x, -r0.w, c17.z, r1.w
add r2.x, r2, c16.z
cmp r3.xyz, -r4.w, r0, r3
mul_sat r2.x, r2, c16.w
mul r0.y, r2.x, r2.x
mad r0.x, -r2, c17, c17.y
mul r0.x, r0.y, r0
mad r1.xyz, r1, r0.x, r3
mad r2.xy, r6, c14.zwzw, v0
texld r5, r2, s0
mad r0.y, -r0.w, c17.w, r5.w
mad r2.xy, r6, c14, v0
texld r2, r2, s0
mad r0.z, -r0.w, c18.x, r2.w
add r0.z, r0, c16
mul_sat r3.w, r0.z, c16
cmp r1.xyz, -r1.w, r3, r1
add r0.y, r0, c16.z
mul_sat r3.x, r0.y, c16.w
mad r0.y, -r3.x, c17.x, c17
mul r3.x, r3, r3
mul r0.y, r3.x, r0
mad r3.xyz, r5, r0.y, r1
cmp r1.xyz, -r5.w, r1, r3
mad r5.xy, r6, c12.zwzw, v0
texld r9, r5, s0
mad r5.xy, r6, c11.zwzw, v0
texld r12, r5, s0
mul r3.x, r3.w, r3.w
mad r0.z, -r3.w, c17.x, c17.y
mul r0.z, r3.x, r0
mad r2.xyz, r2, r0.z, r1
cmp r2.xyz, -r2.w, r1, r2
mad r3.xy, r6, c13.zwzw, v0
texld r7, r3, s0
mad r1.xy, r6, c13, v0
texld r3, r1, s0
mad r1.z, -r0.w, c18.y, r7.w
mad r1.y, -r0.w, c18.z, r3.w
add r1.z, r1, c16
mul_sat r1.z, r1, c16.w
mad r1.x, -r1.z, c17, c17.y
mul r1.z, r1, r1
mul r1.x, r1.z, r1
mad r4.xyz, r7, r1.x, r2
add r1.y, r1, c16.z
mul_sat r1.z, r1.y, c16.w
mad r1.y, -r1.z, c17.x, c17
mad r7.xy, r6, c10.zwzw, v0
cmp r4.xyz, -r7.w, r2, r4
mul r1.z, r1, r1
mul r2.x, r1.z, r1.y
mad r3.xyz, r3, r2.x, r4
cmp r3.xyz, -r3.w, r4, r3
mad r4.xy, r6, c12, v0
mad r1.y, -r0.w, c18.w, r9.w
add r1.y, r1, c16.z
mul_sat r2.y, r1, c16.w
texld r8, r4, s0
mad r1.z, -r2.y, c17.x, c17.y
mad r1.y, -r0.w, c19.x, r8.w
mul r2.y, r2, r2
mul r2.y, r2, r1.z
mad r4.xyz, r9, r2.y, r3
add r1.y, r1, c16.z
mul_sat r1.z, r1.y, c16.w
mad r1.y, -r1.z, c17.x, c17
mul r1.z, r1, r1
mul r2.z, r1, r1.y
cmp r3.xyz, -r9.w, r3, r4
mad r4.xyz, r8, r2.z, r3
cmp r4.xyz, -r8.w, r3, r4
mad r3.xy, r6, c11, v0
mad r8.xy, r6, c9.zwzw, v0
texld r16, r8, s0
mad r8.xy, r6, c8.zwzw, v0
mad r9.xy, r6, c7.zwzw, v0
mad r1.y, -r0.w, c19, r12.w
texld r10, r3, s0
add r1.y, r1, c16.z
mul_sat r3.x, r1.y, c16.w
mad r1.z, -r3.x, c17.x, c17.y
mad r1.y, -r0.w, c19.z, r10.w
mul r3.x, r3, r3
mul r3.x, r3, r1.z
mad r5.xyz, r12, r3.x, r4
add r1.y, r1, c16.z
mul_sat r1.z, r1.y, c16.w
mad r1.y, -r1.z, c17.x, c17
mul r1.z, r1, r1
mul r3.y, r1.z, r1
texld r14, r7, s0
cmp r4.xyz, -r12.w, r4, r5
mad r5.xyz, r10, r3.y, r4
cmp r4.xyz, -r10.w, r4, r5
mad r5.xy, r6, c10, v0
mad r1.y, -r0.w, c19.w, r14.w
add r1.y, r1, c16.z
mul_sat r3.z, r1.y, c16.w
texld r11, r5, s0
mad r1.z, -r3, c17.x, c17.y
mad r1.y, -r0.w, c20.x, r11.w
mul r3.z, r3, r3
mul r3.z, r3, r1
mad r5.xyz, r14, r3.z, r4
add r1.y, r1, c16.z
mul_sat r1.z, r1.y, c16.w
mad r1.y, -r1.z, c17.x, c17
mad r10.xy, r6, c6.zwzw, v0
cmp r4.xyz, -r14.w, r4, r5
mul r1.z, r1, r1
mul r5.x, r1.z, r1.y
mad r7.xyz, r11, r5.x, r4
cmp r4.xyz, -r11.w, r4, r7
mad r7.xy, r6, c9, v0
mad r1.y, -r0.w, c20, r16.w
add r1.y, r1, c16.z
mul_sat r5.y, r1, c16.w
texld r13, r7, s0
mad r1.z, -r5.y, c17.x, c17.y
mad r1.y, -r0.w, c20.z, r13.w
mul r5.y, r5, r5
mul r5.y, r5, r1.z
mad r7.xyz, r16, r5.y, r4
add r1.y, r1, c16.z
mul_sat r1.z, r1.y, c16.w
mad r1.y, -r1.z, c17.x, c17
mul r1.z, r1, r1
mul r5.z, r1, r1.y
texld r18, r8, s0
cmp r4.xyz, -r16.w, r4, r7
mad r7.xyz, r13, r5.z, r4
cmp r4.xyz, -r13.w, r4, r7
mad r7.xy, r6, c8, v0
mad r1.y, -r0.w, c20.w, r18.w
texld r15, r7, s0
add r1.y, r1, c16.z
mul_sat r7.x, r1.y, c16.w
mad r1.z, -r7.x, c17.x, c17.y
mad r1.y, -r0.w, c21.x, r15.w
mul r7.x, r7, r7
mul r7.x, r7, r1.z
mad r8.xyz, r18, r7.x, r4
add r1.y, r1, c16.z
mul_sat r1.z, r1.y, c16.w
mad r1.y, -r1.z, c17.x, c17
mul r1.z, r1, r1
mul r7.y, r1.z, r1
texld r19, r9, s0
cmp r4.xyz, -r18.w, r4, r8
mad r8.xyz, r15, r7.y, r4
cmp r4.xyz, -r15.w, r4, r8
mad r8.xy, r6, c7, v0
mad r1.y, -r0.w, c21, r19.w
add r1.y, r1, c16.z
mul_sat r7.z, r1.y, c16.w
texld r17, r8, s0
mad r1.z, -r7, c17.x, c17.y
mad r1.y, -r0.w, c21.z, r17.w
mul r7.z, r7, r7
mul r7.z, r7, r1
mad r8.xyz, r19, r7.z, r4
add r1.y, r1, c16.z
mul_sat r1.z, r1.y, c16.w
mad r1.y, -r1.z, c17.x, c17
cmp r4.xyz, -r19.w, r4, r8
mul r1.z, r1, r1
mul r8.x, r1.z, r1.y
mad r9.xyz, r17, r8.x, r4
cmp r4.xyz, -r17.w, r4, r9
texld r20, r10, s0
mad r9.xy, r6, c6, v0
mad r1.y, -r0.w, c21.w, r20.w
add r1.y, r1, c16.z
mul_sat r8.y, r1, c16.w
texld r21, r9, s0
mad r1.z, -r8.y, c17.x, c17.y
mad r1.y, -r0.w, c22.x, r21.w
mul r8.y, r8, r8
mul r8.y, r8, r1.z
mad r9.xyz, r20, r8.y, r4
add r1.y, r1, c16.z
mul_sat r1.y, r1, c16.w
mad r1.z, -r1.y, c17.x, c17.y
mul r1.y, r1, r1
mul r8.z, r1.y, r1
cmp r4.xyz, -r20.w, r4, r9
mad r9.xyz, r21, r8.z, r4
cmp r9.xyz, -r21.w, r4, r9
add r1.y, r6.w, r6.z
cmp r1.y, -r4.w, r6.w, r1
add r0.x, r0, r1.y
cmp r1.y, -r1.w, r1, r0.x
mad r4.xy, r6, c5.zwzw, v0
texld r4, r4, s0
mad r1.z, -r0.w, c22.y, r4.w
add r0.x, r0.y, r1.y
add r1.z, r1, c16
mul_sat r0.y, r1.z, c16.w
cmp r1.z, -r5.w, r1.y, r0.x
mad r0.x, -r0.y, c17, c17.y
mul r0.y, r0, r0
mul r6.z, r0.y, r0.x
mad r4.xyz, r4, r6.z, r9
add r1.y, r0.z, r1.z
cmp r0.xyz, -r4.w, r9, r4
cmp r4.z, -r2.w, r1, r1.y
add r2.w, r1.x, r4.z
cmp r2.w, -r7, r4.z, r2
add r2.x, r2, r2.w
cmp r2.w, -r3, r2, r2.x
mad r4.xy, r6, c5, v0
texld r1, r4, s0
add r2.x, r2.y, r2.w
mad r4.x, -r0.w, c22.z, r1.w
add r4.x, r4, c16.z
mul_sat r3.w, r4.x, c16
mad r2.y, -r3.w, c17.x, c17
mul r3.w, r3, r3
mul r4.x, r3.w, r2.y
mad r1.xyz, r1, r4.x, r0
cmp r0.xyz, -r1.w, r0, r1
cmp r2.x, -r9.w, r2.w, r2
add r1.z, r2, r2.x
cmp r1.z, -r8.w, r2.x, r1
mad r1.xy, r6, c4.zwzw, v0
texld r2, r1, s0
add r1.x, r3, r1.z
cmp r1.y, -r12.w, r1.z, r1.x
mad r3.x, -r0.w, c22.w, r2.w
add r1.z, r3.x, c16
add r1.x, r3.y, r1.y
cmp r3.x, -r10.w, r1.y, r1
mul_sat r1.z, r1, c16.w
mad r1.x, -r1.z, c17, c17.y
mul r1.y, r1.z, r1.z
mul r4.y, r1, r1.x
mad r1.xyz, r2, r4.y, r0
cmp r0.xyz, -r2.w, r0, r1
add r2.x, r3.z, r3
cmp r2.x, -r14.w, r3, r2
mad r1.xy, r6, c4, v0
texld r3, r1, s0
add r1.z, r5.x, r2.x
cmp r1.y, -r11.w, r2.x, r1.z
add r1.x, r5.y, r1.y
cmp r2.z, -r16.w, r1.y, r1.x
add r2.y, r5.z, r2.z
mad r1.z, -r0.w, c23.x, r3.w
add r1.z, r1, c16
mul_sat r1.y, r1.z, c16.w
mad r1.x, -r1.y, c17, c17.y
mul r1.y, r1, r1
mul r2.x, r1.y, r1
mad r1.xyz, r3, r2.x, r0
cmp r0.xyz, -r3.w, r0, r1
cmp r2.y, -r13.w, r2.z, r2
add r1.z, r7.x, r2.y
mad r1.xy, r6, c3.zwzw, v0
texld r5, r1, s0
cmp r1.z, -r18.w, r2.y, r1
add r1.x, r7.y, r1.z
cmp r1.y, -r15.w, r1.z, r1.x
add r1.x, r7.z, r1.y
cmp r3.x, -r19.w, r1.y, r1
mad r2.y, -r0.w, c23, r5.w
add r1.z, r2.y, c16
mul_sat r1.z, r1, c16.w
add r2.z, r8.x, r3.x
cmp r2.z, -r17.w, r3.x, r2
mad r1.x, -r1.z, c17, c17.y
mul r1.y, r1.z, r1.z
mul r2.y, r1, r1.x
mad r1.xyz, r5, r2.y, r0
cmp r0.xyz, -r5.w, r0, r1
mad r1.xy, r6, c3, v0
texld r7, r1, s0
add r1.z, r8.y, r2
cmp r1.y, -r20.w, r2.z, r1.z
add r1.x, r8.z, r1.y
cmp r3.x, -r21.w, r1.y, r1
add r2.z, r6, r3.x
mad r1.z, -r0.w, c23, r7.w
add r1.z, r1, c16
mul_sat r1.y, r1.z, c16.w
mad r1.x, -r1.y, c17, c17.y
mul r1.y, r1, r1
mul r4.z, r1.y, r1.x
mad r1.xyz, r7, r4.z, r0
cmp r0.xyz, -r7.w, r0, r1
cmp r2.z, -r4.w, r3.x, r2
add r1.z, r4.x, r2
cmp r3.x, -r1.w, r2.z, r1.z
add r2.z, r4.y, r3.x
cmp r2.z, -r2.w, r3.x, r2
add r2.x, r2, r2.z
mad r1.xy, r6, c2.zwzw, v0
texld r1, r1, s0
mad r3.y, -r0.w, c23.w, r1.w
add r2.w, r3.y, c16.z
cmp r2.x, -r3.w, r2.z, r2
mul_sat r2.w, r2, c16
mad r2.z, -r2.w, c17.x, c17.y
mul r2.w, r2, r2
mul r4.x, r2.w, r2.z
mad r3.xyz, r1, r4.x, r0
add r1.z, r2.y, r2.x
cmp r1.z, -r5.w, r2.x, r1
mad r1.xy, r6, c2, v0
texld r2, r1, s0
add r1.x, r4.z, r1.z
cmp r1.y, -r7.w, r1.z, r1.x
add r1.x, r4, r1.y
mad r3.w, -r0, c24.x, r2
add r1.z, r3.w, c16
cmp r1.y, -r1.w, r1, r1.x
mul_sat r1.z, r1, c16.w
mad r1.x, -r1.z, c17, c17.y
mul r1.z, r1, r1
mul r1.z, r1, r1.x
cmp r3.xyz, -r1.w, r0, r3
add r1.x, r1.z, r1.y
cmp r0.x, -r2.w, r1.y, r1
mad r1.xyz, r2, r1.z, r3
rcp r0.x, r0.x
cmp r1.xyz, -r2.w, r3, r1
mul oC0.xyz, r1, r0.x
mov oC0.w, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
BindCB  "$Globals" 0
"ps_4_0
eefiecedahloenbdlanhlmkppffmecnfemlainlmabaaaaaaomafaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbeafaaaaeaaaaaaaefabaaaa
dfbiaaaahcaaaaaamaohbpdpembkaldpebpbfddpaaaaaaaappflajlokiodhblp
eifahedpaaaaaaaadmidmgdoinjhnololacabfdpaaaaaaaackfhpidnjlhceflo
cjdpgjdoaaaaaaaaolmffalopmaaoednanoagndoaaaaaaaajhmffedpjojijflo
dhijgbdpaaaaaaaacffinmdnfobbbelphmjlbgdpaaaaaaaalhnbjadoaiffekdp
dcogfgdpaaaaaaaadaiblllogjfcmkdocnomajdpaaaaaaaafbidebdphlglgado
hehlejdpaaaaaaaahnkoaglpamhgmddmobnbagdpaaaaaaaadnnfgblpecjfhklo
dofmgkdpaaaaaaaahleopkloglcljglollpcbbdpaaaaaaaaaifkobdojbeekpln
bajcofdoaaaaaaaahknpfidompidaddpgeeaaodpaaaaaaaagmjfgadnjlpohedp
iagfhfdpaaaaaaaaofakbhlpmhiadelphnfmgldpaaaaaaaaggphemlpladihmdo
dchcfgdpaaaaaaaankogeglolngpdmlooppoiidoaaaaaaaadgjdnploijhleedp
ojaogcdpaaaaaaaabonmfndoofjlondnccklhldoaaaaaaaabplkcadonbccfllp
aemkfodpaaaaaaaaanbkeclpmhgibfdpcipchedpaaaaaaaamdckhodpelofonlm
pbeghodpaaaaaaaabjkngdlooodnbelpfdmlbodpaaaaaaaaobooamdpkchkcllp
ffpgfndpaaaaaaaaaklkondoofpcipdopbpeakdpaaaaaaaacdlojdlnklaebldp
ckbnbmdpaaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacafaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaidcaabaaa
abaaaaaapgapbaaaaaaaaaaaegiacaaaaaaaaaaaacaaaaaadiaaaaaidcaabaaa
abaaaaaaegaabaaaabaaaaaapgipcaaaaaaaaaaaadaaaaaadiaaaaahecaabaaa
abaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaiadodeaaaaaiecaabaaaabaaaaaa
ckaabaaaabaaaaaackiacaaaaaaaaaaaadaaaaaadiaaaaahhcaabaaaaaaaaaaa
egacbaaaaaaaaaaakgakbaaaabaaaaaadgaaaaafhcaabaaaacaaaaaaegacbaaa
aaaaaaaadgaaaaaficaabaaaabaaaaaackaabaaaabaaaaaadgaaaaaficaabaaa
acaaaaaaabeaaaaaaaaaaaaadaaaaaabcbaaaaahbcaabaaaadaaaaaadkaabaaa
acaaaaaaabeaaaaabmaaaaaaadaaaeadakaabaaaadaaaaaadcaaaaakdcaabaaa
adaaaaaaegjajaaadkaabaaaacaaaaaaegaabaaaabaaaaaaogbkbaaaabaaaaaa
efaaaaajpcaabaaaadaaaaaaegaabaaaadaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaadbaaaaahbcaabaaaaeaaaaaaabeaaaaaaaaaaaaadkaabaaaadaaaaaa
bpaaaeadakaabaaaaeaaaaaadcaaaaalicaabaaaadaaaaaadkaabaiaebaaaaaa
aaaaaaaackjajaaadkaabaaaacaaaaaadkaabaaaadaaaaaaaaaaaaahicaabaaa
adaaaaaadkaabaaaadaaaaaaabeaaaaabekoihdodicaaaahicaabaaaadaaaaaa
dkaabaaaadaaaaaaabeaaaaaglichbeadcaaaaajbcaabaaaaeaaaaaadkaabaaa
adaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaahicaabaaaadaaaaaa
dkaabaaaadaaaaaadkaabaaaadaaaaaadiaaaaahccaabaaaaeaaaaaadkaabaaa
adaaaaaaakaabaaaaeaaaaaadcaaaaajhcaabaaaacaaaaaaegacbaaaadaaaaaa
fgafbaaaaeaaaaaaegacbaaaacaaaaaadcaaaaajicaabaaaabaaaaaaakaabaaa
aeaaaaaadkaabaaaadaaaaaadkaabaaaabaaaaaabfaaaaabboaaaaahicaabaaa
acaaaaaadkaabaaaacaaaaaaabeaaaaaabaaaaaabgaaaaabaoaaaaahhccabaaa
aaaaaaaaegacbaaaacaaaaaapgapbaaaabaaaaaadgaaaaaficcabaaaaaaaaaaa
dkaabaaaaaaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform sampler2D _LowRez;
uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
vec2 SmallDiscKernel[12];
varying vec2 xlv_TEXCOORD1;
void main ()
{
  SmallDiscKernel[0] = vec2(-0.326212, -0.40581);
  SmallDiscKernel[1] = vec2(-0.840144, -0.07358);
  SmallDiscKernel[2] = vec2(-0.695914, 0.457137);
  SmallDiscKernel[3] = vec2(-0.203345, 0.620716);
  SmallDiscKernel[4] = vec2(0.96234, -0.194983);
  SmallDiscKernel[5] = vec2(0.473434, -0.480026);
  SmallDiscKernel[6] = vec2(0.519456, 0.767022);
  SmallDiscKernel[7] = vec2(0.185461, -0.893124);
  SmallDiscKernel[8] = vec2(0.507431, 0.064425);
  SmallDiscKernel[9] = vec2(0.89642, 0.412458);
  SmallDiscKernel[10] = vec2(-0.32194, -0.932615);
  SmallDiscKernel[11] = vec2(-0.791559, -0.59771);
  vec2 tmpvar_1;
  tmpvar_1 = xlv_TEXCOORD1;
  int l_2;
  float sampleCount_3;
  vec4 poissonScale_4;
  vec4 smallBlur_5;
  vec4 centerTap_6;
  vec4 tmpvar_7;
  tmpvar_7 = texture2D (_LowRez, xlv_TEXCOORD1);
  vec4 tmpvar_8;
  tmpvar_8 = texture2D (_MainTex, xlv_TEXCOORD1);
  centerTap_6 = tmpvar_8;
  poissonScale_4 = ((_MainTex_TexelSize.xyxy * tmpvar_8.w) * _Offsets.w);
  float tmpvar_9;
  tmpvar_9 = max ((tmpvar_8.w * 0.25), 0.1);
  sampleCount_3 = tmpvar_9;
  smallBlur_5 = (tmpvar_8 * tmpvar_9);
  l_2 = 0;
  for (int l_2 = 0; l_2 < 12; ) {
    vec4 tmpvar_10;
    tmpvar_10 = texture2D (_MainTex, (tmpvar_1 + ((SmallDiscKernel[l_2] * poissonScale_4.xy) * 1.1)));
    vec2 arg0_11;
    arg0_11 = (SmallDiscKernel[l_2] * 1.1);
    float tmpvar_12;
    float t_13;
    t_13 = max (min ((((tmpvar_10.w - (centerTap_6.w * sqrt(dot (arg0_11, arg0_11)))) - -0.265) / 0.265), 1.0), 0.0);
    tmpvar_12 = (t_13 * (t_13 * (3.0 - (2.0 * t_13))));
    smallBlur_5 = (smallBlur_5 + (tmpvar_10 * tmpvar_12));
    sampleCount_3 = (sampleCount_3 + tmpvar_12);
    l_2 = (l_2 + 1);
  };
  float t_14;
  t_14 = max (min (((tmpvar_8.w - 0.4) / 0.2), 1.0), 0.0);
  vec4 tmpvar_15;
  tmpvar_15 = mix ((smallBlur_5 / (sampleCount_3 + 1e-05)), tmpvar_7, vec4((t_14 * (t_14 * (3.0 - (2.0 * t_14))))));
  smallBlur_5 = tmpvar_15;
  vec4 tmpvar_16;
  if ((tmpvar_8.w < 0.01)) {
    tmpvar_16 = tmpvar_8;
  } else {
    vec4 tmpvar_17;
    tmpvar_17.xyz = tmpvar_15.xyz;
    tmpvar_17.w = tmpvar_8.w;
    tmpvar_16 = tmpvar_17;
  };
  gl_FragData[0] = tmpvar_16;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Vector 1 [_Offsets]
SetTexture 0 [_LowRez] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c2, -0.01000000, -0.40000001, 4.99999952, 1.09106636
def c3, 2.00000000, 3.00000000, -0.87071490, -0.65748101
def c4, 0.26499999, 3.77358508, -0.35413402, -1.02587652
def c5, 1.08528042, 0.98606205, 0.45370382, 1.08543336
def c6, 0.55817407, 0.07086750, 0.56265485, 1.00339437
def c7, 0.20400710, -0.98243642, 0.57140166, 0.84372425
def c8, 1.01900470, 0.52077740, -0.52802861, 0.74163556
def c9, 1.05857396, -0.21448131, 1.08008385, 0.71849245
def c10, -0.22367951, 0.68278760, -0.76550537, 0.50285071
def c11, 0.91589147, -0.92415839, -0.08093800, 0.92769593
def c12, 0.25000000, 0.10000000, -0.35883319, -0.44639102
def c13, 0.57273573, 0.00001000, 0, 0
dcl_texcoord1 v0.xy
texld r0, v0, s1
mul r1.xy, r0.w, c0
mul r4.xy, r1, c1.w
mad r1.xy, r4, c12.zwzw, v0
texld r2, r1, s1
mad r1.x, -r0.w, c13, r2.w
add r1.x, r1, c4
mul_sat r1.z, r1.x, c4.y
mad r5.xy, r4, c10.zwzw, v0
mul r2.w, r1.z, r1.z
mad r3.x, -r1.z, c3, c3.y
mul r4.w, r2, r3.x
mad r1.xy, r4, c11.yzzw, v0
texld r1, r1, s1
mul r2.w, r0, c12.x
mad r1.w, -r0, c11, r1
add r1.w, r1, c4.x
max r4.z, r2.w, c12.y
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r2.xyz, r2, r4.w
mul r3.w, r1, r2
mad r2.xyz, r0, r4.z, r2
mad r3.xyz, r1, r3.w, r2
texld r2, r5, s1
mad r1.xy, r4, c10, v0
texld r1, r1, s1
mad r2.w, -r0, c11.x, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r5.x, -r2.w, c3, c3.y
mul r2.w, r2, r2
mul r5.x, r2.w, r5
mad r1.w, -r0, c9, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r2.xyz, r2, r5.x, r3
mul r5.y, r1.w, r2.w
mad r3.xyz, r1, r5.y, r2
mad r6.xy, r4, c9, v0
texld r2, r6, s1
mad r1.xy, r4, c8.yzzw, v0
texld r1, r1, s1
mad r2.w, -r0, c9.z, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r5.z, -r2.w, c3.x, c3.y
mul r2.w, r2, r2
mul r5.z, r2.w, r5
mad r1.w, -r0, c8, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r2.xyz, r2, r5.z, r3
mul r5.w, r1, r2
mad r3.xyz, r1, r5.w, r2
mad r6.xy, r4, c7.zwzw, v0
texld r2, r6, s1
mad r1.xy, r4, c7, v0
texld r1, r1, s1
mad r2.w, -r0, c8.x, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r6.x, -r2.w, c3, c3.y
mul r2.w, r2, r2
mul r6.x, r2.w, r6
mad r3.xyz, r2, r6.x, r3
mad r2.xy, r4, c6, v0
mad r1.w, -r0, c6, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mul r6.y, r1.w, r1.w
mad r1.w, -r1, c3.x, c3.y
mul r6.y, r6, r1.w
texld r2, r2, s1
mad r1.w, -r0, c6.z, r2
add r1.w, r1, c4.x
mad r1.xyz, r1, r6.y, r3
add r2.w, r4.z, r4
add r3.x, r3.w, r2.w
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r2.w, r1, r2
mad r2.xyz, r2, r2.w, r1
add r1.z, r5.x, r3.x
add r3.x, r5.y, r1.z
mad r1.xy, r4, c5.yzzw, v0
texld r1, r1, s1
add r3.x, r5.z, r3
mad r1.w, -r0, c5, r1
add r3.x, r5.w, r3
add r3.x, r6, r3
add r1.w, r1, c4.x
add r3.w, r6.y, r3.x
mul_sat r1.w, r1, c4.y
mad r3.x, -r1.w, c3, c3.y
mul r1.w, r1, r1
mul r1.w, r1, r3.x
mad r3.xyz, r1, r1.w, r2
add r1.z, r2.w, r3.w
mad r2.xy, r4, c3.zwzw, v0
texld r2, r2, s1
mad r1.xy, r4, c4.zwzw, v0
add r3.w, r1, r1.z
texld r1, r1, s1
mad r1.w, -r0, c5.x, r1
add r4.x, r1.w, c4
mad r1.w, -r0, c2, r2
mul_sat r2.w, r4.x, c4.y
mad r4.x, -r2.w, c3, c3.y
mul r2.w, r2, r2
mul r4.x, r2.w, r4
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r1.w, r1, r2
mad r1.xyz, r1, r4.x, r3
mad r2.xyz, r2, r1.w, r1
add r3.w, r4.x, r3
add r2.w, r1, r3
add r2.w, r2, c13.y
add r1.w, r0, c2.y
rcp r2.w, r2.w
texld r1.xyz, v0, s0
mad r1.xyz, -r2, r2.w, r1
mul r2.xyz, r2, r2.w
mul_sat r1.w, r1, c2.z
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r1.w, r1, r2
mad r1.xyz, r1.w, r1, r2
mov r1.w, r0
add r2.x, r0.w, c2
cmp oC0, r2.x, r1, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_LowRez] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
BindCB  "$Globals" 0
"ps_4_0
eefiecedccjohmboblfdipbemppkbkclgcflifdkabaaaaaalaagaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcniafaaaaeaaaaaaahgabaaaa
dfbiaaaadcaaaaaaecafkhlofemgmploaaaaaaaaaaaaaaaaknbdfhlpbmlbjgln
aaaaaaaaaaaaaaaaglchdclpnmanokdoaaaaaaaaaaaaaaaakmdjfalodoohbodp
aaaaaaaaaaaaaaaaokflhgdpkakjehloaaaaaaaaaaaaaaaapbgfpcdopimfpflo
aaaaaaaaaaaaaaaabcplaedpiofleedpaaaaaaaaaaaaaaaahnojdndomgkdgelp
aaaaaaaaaaaaaaaappogabdpebpbiddnaaaaaaaaaaaaaaaamihlgfdplccnnddo
aaaaaaaaaaaaaaaafcnfkelonllpgolpaaaaaaaaaaaaaaaajmkdeklpigadbjlp
aaaaaaaaaaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacahaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaaidcaabaaa
acaaaaaapgapbaaaabaaaaaaegiacaaaaaaaaaaaacaaaaaadiaaaaaidcaabaaa
acaaaaaaegaabaaaacaaaaaapgipcaaaaaaaaaaaadaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaiadodeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaamnmmmmdndiaaaaahhcaabaaaadaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaafhcaabaaaaeaaaaaaegacbaaaadaaaaaa
dgaaaaafecaabaaaacaaaaaadkaabaaaaaaaaaaadgaaaaaficaabaaaacaaaaaa
abeaaaaaaaaaaaaadaaaaaabcbaaaaahicaabaaaadaaaaaadkaabaaaacaaaaaa
abeaaaaaamaaaaaaadaaaeaddkaabaaaadaaaaaadiaaaaaidcaabaaaafaaaaaa
egaabaaaacaaaaaaegjajaaadkaabaaaacaaaaaadcaaaaamdcaabaaaafaaaaaa
egaabaaaafaaaaaaaceaaaaamnmmimdpmnmmimdpaaaaaaaaaaaaaaaaogbkbaaa
abaaaaaaefaaaaajpcaabaaaafaaaaaaegaabaaaafaaaaaaeghobaaaabaaaaaa
aagabaaaaaaaaaaadiaaaaaldcaabaaaagaaaaaaaceaaaaamnmmimdpmnmmimdp
aaaaaaaaaaaaaaaaegjajaaadkaabaaaacaaaaaaapaaaaahicaabaaaadaaaaaa
egaabaaaagaaaaaaegaabaaaagaaaaaaelaaaaaficaabaaaadaaaaaadkaabaaa
adaaaaaadcaaaaakicaabaaaadaaaaaadkaabaiaebaaaaaaabaaaaaadkaabaaa
adaaaaaadkaabaaaafaaaaaaaaaaaaahicaabaaaadaaaaaadkaabaaaadaaaaaa
abeaaaaabekoihdodicaaaahicaabaaaadaaaaaadkaabaaaadaaaaaaabeaaaaa
glichbeadcaaaaajicaabaaaaeaaaaaadkaabaaaadaaaaaaabeaaaaaaaaaaama
abeaaaaaaaaaeaeadiaaaaahicaabaaaadaaaaaadkaabaaaadaaaaaadkaabaaa
adaaaaaadiaaaaahicaabaaaafaaaaaadkaabaaaadaaaaaadkaabaaaaeaaaaaa
dcaaaaajhcaabaaaaeaaaaaaegacbaaaafaaaaaapgapbaaaafaaaaaaegacbaaa
aeaaaaaadcaaaaajecaabaaaacaaaaaadkaabaaaaeaaaaaadkaabaaaadaaaaaa
ckaabaaaacaaaaaaboaaaaahicaabaaaacaaaaaadkaabaaaacaaaaaaabeaaaaa
abaaaaaabgaaaaabaaaaaaahicaabaaaaaaaaaaackaabaaaacaaaaaaabeaaaaa
kmmfchdhaoaaaaahhcaabaaaacaaaaaaegacbaaaaeaaaaaapgapbaaaaaaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaamnmmmmlodicaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaappppjpeadcaaaaajicaabaaa
acaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaadkaabaaaacaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadbaaaaahbcaabaaa
acaaaaaadkaabaaaabaaaaaaabeaaaaaaknhcddmdgaaaaaficaabaaaaaaaaaaa
dkaabaaaabaaaaaadhaaaaajpccabaaaaaaaaaaaagaabaaaacaaaaaaegaobaaa
abaaaaaaegaobaaaaaaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  ColorMask A
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform vec4 _ZBufferParams;
uniform sampler2D _CameraDepthTexture;
uniform sampler2D _FgOverlap;
uniform vec4 _CurveParams;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 color_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_FgOverlap, xlv_TEXCOORD1);
  color_1.xyz = tmpvar_2.xyz;
  float tmpvar_3;
  tmpvar_3 = (1.0/(((_ZBufferParams.x * texture2D (_CameraDepthTexture, xlv_TEXCOORD1).x) + _ZBufferParams.y)));
  color_1.w = ((_CurveParams.z * abs((tmpvar_3 - _CurveParams.w))) / (tmpvar_3 + 1e-05));
  color_1.w = clamp (max (0.0, (color_1.w - _CurveParams.y)), 0.0, _CurveParams.x);
  gl_FragData[0] = max (color_1.wwww, tmpvar_2.wwww);
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_ZBufferParams]
Vector 1 [_CurveParams]
SetTexture 0 [_FgOverlap] 2D 0
SetTexture 1 [_CameraDepthTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c2, 0.00001000, 0.00000000, 0, 0
dcl_texcoord1 v0.xy
texld r0.x, v0, s1
mad r0.x, r0, c0, c0.y
rcp r0.x, r0.x
add r0.y, r0.x, -c1.w
add r0.z, r0.x, c2.x
abs r0.x, r0.y
rcp r0.y, r0.z
mul r0.x, r0, c1.z
mad r0.x, r0, r0.y, -c1.y
max r0.x, r0, c2.y
min r0.x, r0, c1
texld r0.w, v0, s0
max r0.x, r0, c2.y
max oC0, r0.x, r0.w
"
}
SubProgram "d3d11 " {
SetTexture 0 [_FgOverlap] 2D 1
SetTexture 1 [_CameraDepthTexture] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_CurveParams]
ConstBuffer "UnityPerCamera" 128
Vector 112 [_ZBufferParams]
BindCB  "$Globals" 0
BindCB  "UnityPerCamera" 1
"ps_4_0
eefiecedonekoompkbkmbbjihnjinmhpoiankkjbabaaaaaapeacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbmacaaaaeaaaaaaaihaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafjaaaaaeegiocaaaabaaaaaaaiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadmcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadcaaaaal
bcaabaaaaaaaaaaaakiacaaaabaaaaaaahaaaaaaakaabaaaaaaaaaaabkiacaaa
abaaaaaaahaaaaaaaoaaaaakbcaabaaaaaaaaaaaaceaaaaaaaaaiadpaaaaiadp
aaaaiadpaaaaiadpakaabaaaaaaaaaaaaaaaaaajccaabaaaaaaaaaaaakaabaaa
aaaaaaaadkiacaiaebaaaaaaaaaaaaaaabaaaaaaaaaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaakmmfchdhdiaaaaajccaabaaaaaaaaaaabkaabaia
ibaaaaaaaaaaaaaackiacaaaaaaaaaaaabaaaaaaaoaaaaahbcaabaaaaaaaaaaa
bkaabaaaaaaaaaaaakaabaaaaaaaaaaaaaaaaaajbcaabaaaaaaaaaaaakaabaaa
aaaaaaaabkiacaiaebaaaaaaaaaaaaaaabaaaaaadeaaaaahbcaabaaaaaaaaaaa
akaabaaaaaaaaaaaabeaaaaaaaaaaaaaddaaaaaibcaabaaaaaaaaaaaakaabaaa
aaaaaaaaakiacaaaaaaaaaaaabaaaaaaefaaaaajpcaabaaaabaaaaaaogbkbaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaadeaaaaahpccabaaaaaaaaaaa
agaabaaaaaaaaaaapgapbaaaabaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend One One
 BlendOp Max
  ColorMask A
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform sampler2D _FgOverlap;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 tmpvar_1;
  tmpvar_1 = texture2D (_MainTex, xlv_TEXCOORD1);
  gl_FragData[0] = vec4((float((tmpvar_1.w < 0.01)) * clamp ((texture2D (_FgOverlap, xlv_TEXCOORD1).w - tmpvar_1.w), 0.0, 1.0)));
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_FgOverlap] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c0, -0.01000000, 0.00000000, 1.00000000, 0
dcl_texcoord1 v0.xy
texld r0.w, v0, s0
texld r1.w, v0, s1
add r0.x, r0.w, c0
add_sat r0.y, -r0.w, r1.w
cmp r0.x, r0, c0.y, c0.z
mul oC0, r0.x, r0.y
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_FgOverlap] 2D 1
"ps_4_0
eefiecedmmacnfakoiindlgiijbcjdoamdojlgkiabaaaaaapiabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefccaabaaaaeaaaaaaaeiaaaaaa
fkaaaaadaagabaaaaaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaa
aaaaaaaaffffaaaafibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadmcbabaaa
abaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacacaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadbaaaaah
bcaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaknhcddmabaaaaahbcaabaaa
aaaaaaaaakaabaaaaaaaaaaaabeaaaaaaaaaiadpefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaabaaaaaaaacaaaaiccaabaaa
aaaaaaaadkaabaiaebaaaaaaaaaaaaaadkaabaaaabaaaaaadiaaaaahpccabaaa
aaaaaaaafgafbaaaaaaaaaaaagaabaaaaaaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec4 _MainTex_TexelSize;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  gl_FragData[0] = ((((texture2D (_MainTex, (xlv_TEXCOORD1 + (0.75 * _MainTex_TexelSize.xy))) + texture2D (_MainTex, (xlv_TEXCOORD1 - (0.75 * _MainTex_TexelSize.xy)))) + texture2D (_MainTex, (xlv_TEXCOORD1 + (vec2(0.75, -0.75) * _MainTex_TexelSize.xy)))) + texture2D (_MainTex, (xlv_TEXCOORD1 - (vec2(0.75, -0.75) * _MainTex_TexelSize.xy)))) / 4.0);
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c1, 0.75000000, -0.75000000, 0.25000000, 0
dcl_texcoord1 v0.xy
mov r0.zw, c0.xyxy
mad r1.xy, c1.x, -r0.zwzw, v0
mov r0.xy, c0
mad r0.xy, c1.x, r0, v0
texld r1, r1, s0
texld r0, r0, s0
add r2, r0, r1
mov r0.zw, c0.xyxy
mad r1.xy, c1, -r0.zwzw, v0
mov r0.xy, c0
mad r0.xy, c1, r0, v0
texld r0, r0, s0
texld r1, r1, s0
add r0, r2, r0
add r0, r0, r1
mul oC0, r0, c1.z
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
BindCB  "$Globals" 0
"ps_4_0
eefiecedcgdemcjlncegeokiejfghaedelpojmakabaaaaaakiacaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcnaabaaaaeaaaaaaaheaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaeaaaaaadcaaaaanpcaabaaaaaaaaaaaegiecaaaaaaaaaaa
acaaaaaaaceaaaaaaaaaeadpaaaaeadpaaaaeadpaaaaealpogbobaaaabaaaaaa
efaaaaajpcaabaaaabaaaaaaegaabaaaaaaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaefaaaaajpcaabaaaaaaaaaaaogakbaaaaaaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaadcaaaaaopcaabaaaacaaaaaaegiecaiaebaaaaaaaaaaaaaa
acaaaaaaaceaaaaaaaaaeadpaaaaeadpaaaaeadpaaaaealpogbobaaaabaaaaaa
efaaaaajpcaabaaaadaaaaaaegaabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaefaaaaajpcaabaaaacaaaaaaogakbaaaacaaaaaaeghobaaaaaaaaaaa
aagabaaaaaaaaaaaaaaaaaahpcaabaaaabaaaaaaegaobaaaabaaaaaaegaobaaa
adaaaaaaaaaaaaahpcaabaaaaaaaaaaaegaobaaaaaaaaaaaegaobaaaabaaaaaa
aaaaaaahpcaabaaaaaaaaaaaegaobaaaacaaaaaaegaobaaaaaaaaaaadiaaaaak
pccabaaaaaaaaaaaegaobaaaaaaaaaaaaceaaaaaaaaaiadoaaaaiadoaaaaiado
aaaaiadodoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec4 _CurveParams;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 returnValue_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD1);
  returnValue_1.w = tmpvar_2.w;
  returnValue_1.xyz = mix (vec3(0.0, 0.0, 0.0), vec3(1.0, 1.0, 1.0), vec3(clamp ((tmpvar_2.w / _CurveParams.x), 0.0, 1.0)));
  gl_FragData[0] = returnValue_1;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_CurveParams]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
dcl_texcoord1 v0.xy
texld r0.w, v0, s0
rcp r0.x, c0.x
mul_sat r0.xyz, r0.w, r0.x
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 16 [_CurveParams]
BindCB  "$Globals" 0
"ps_4_0
eefiecedifhcdlaelhpdjbdbcbeiiebmdhigmpapabaaaaaajmabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcmeaaaaaaeaaaaaaadbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaacaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacabaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaaaoaaaaaibcaabaaaaaaaaaaadkaabaaa
aaaaaaaaakiacaaaaaaaaaaaabaaaaaadgaaaaaficcabaaaaaaaaaaadkaabaaa
aaaaaaaadgcaaaafhccabaaaaaaaaaaaagaabaaaaaaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
vec3 DiscKernel[28];
varying vec2 xlv_TEXCOORD1;
void main ()
{
  DiscKernel[0] = vec3(0.62463, 0.54337, 0.8279);
  DiscKernel[1] = vec3(-0.13414, -0.94488, 0.95435);
  DiscKernel[2] = vec3(0.38772, -0.43475, 0.58253);
  DiscKernel[3] = vec3(0.12126, -0.19282, 0.22778);
  DiscKernel[4] = vec3(-0.20388, 0.11133, 0.2323);
  DiscKernel[5] = vec3(0.83114, -0.29218, 0.881);
  DiscKernel[6] = vec3(0.10759, -0.57839, 0.58831);
  DiscKernel[7] = vec3(0.28285, 0.79036, 0.83945);
  DiscKernel[8] = vec3(-0.36622, 0.39516, 0.53876);
  DiscKernel[9] = vec3(0.75591, 0.21916, 0.78704);
  DiscKernel[10] = vec3(-0.5261, 0.02386, 0.52664);
  DiscKernel[11] = vec3(-0.88216, -0.24471, 0.91547);
  DiscKernel[12] = vec3(-0.48888, -0.2933, 0.57011);
  DiscKernel[13] = vec3(0.44014, -0.08558, 0.44838);
  DiscKernel[14] = vec3(0.21179, 0.51373, 0.55567);
  DiscKernel[15] = vec3(0.05483, 0.95701, 0.95858);
  DiscKernel[16] = vec3(-0.59001, -0.70509, 0.91938);
  DiscKernel[17] = vec3(-0.80065, 0.24631, 0.83768);
  DiscKernel[18] = vec3(-0.19424, -0.18402, 0.26757);
  DiscKernel[19] = vec3(-0.43667, 0.76751, 0.88304);
  DiscKernel[20] = vec3(0.21666, 0.11602, 0.24577);
  DiscKernel[21] = vec3(0.15696, -0.856, 0.87027);
  DiscKernel[22] = vec3(-0.75821, 0.58363, 0.95682);
  DiscKernel[23] = vec3(0.99284, -0.02904, 0.99327);
  DiscKernel[24] = vec3(-0.22234, -0.57907, 0.62029);
  DiscKernel[25] = vec3(0.55052, -0.66984, 0.86704);
  DiscKernel[26] = vec3(0.46431, 0.28115, 0.5428);
  DiscKernel[27] = vec3(-0.07214, 0.60554, 0.60982);
  vec2 tmpvar_1;
  tmpvar_1 = xlv_TEXCOORD1;
  vec4 returnValue_2;
  int l_3;
  float sampleCount_4;
  vec4 poissonScale_5;
  vec4 sum_6;
  vec4 centerTap_7;
  vec4 tmpvar_8;
  tmpvar_8 = texture2D (_MainTex, xlv_TEXCOORD1);
  centerTap_7 = tmpvar_8;
  poissonScale_5 = ((_MainTex_TexelSize.xyxy * tmpvar_8.w) * _Offsets.w);
  float tmpvar_9;
  tmpvar_9 = max ((tmpvar_8.w * 0.25), _Offsets.z);
  sampleCount_4 = tmpvar_9;
  sum_6 = (tmpvar_8 * tmpvar_9);
  l_3 = 0;
  for (int l_3 = 0; l_3 < 28; ) {
    vec4 tmpvar_10;
    tmpvar_10.xy = vec2(1.2, 1.2);
    tmpvar_10.zw = DiscKernel[l_3].zz;
    vec4 tmpvar_11;
    tmpvar_11 = (tmpvar_1.xyxy + ((DiscKernel[l_3].xyxy * poissonScale_5.xyxy) / tmpvar_10));
    vec4 tmpvar_12;
    tmpvar_12 = texture2D (_MainTex, tmpvar_11.xy);
    vec4 tmpvar_13;
    tmpvar_13 = texture2D (_MainTex, tmpvar_11.zw);
    if (((tmpvar_12.w + tmpvar_13.w) > 0.0)) {
      vec2 tmpvar_14;
      tmpvar_14.y = 1.0;
      tmpvar_14.x = (DiscKernel[l_3].z / 1.2);
      vec2 tmpvar_15;
      tmpvar_15.x = tmpvar_12.w;
      tmpvar_15.y = tmpvar_13.w;
      vec2 tmpvar_16;
      vec2 t_17;
      t_17 = max (min ((((tmpvar_15 - (centerTap_7.ww * tmpvar_14)) - vec2(-0.265, -0.265)) / vec2(0.265, 0.265)), 1.0), 0.0);
      tmpvar_16 = (t_17 * (t_17 * (3.0 - (2.0 * t_17))));
      sum_6 = (sum_6 + ((tmpvar_12 * tmpvar_16.x) + (tmpvar_13 * tmpvar_16.y)));
      sampleCount_4 = (sampleCount_4 + dot (tmpvar_16, vec2(1.0, 1.0)));
    };
    l_3 = (l_3 + 1);
  };
  returnValue_2.xyz = (sum_6 / sampleCount_4).xyz;
  returnValue_2.w = tmpvar_8.w;
  gl_FragData[0] = returnValue_2;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Vector 1 [_Offsets]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c2, -0.06011667, 0.50461662, -0.11829720, 0.99298143
def c3, 0.38692498, 0.23429167, 0.85539788, 0.51796240
def c4, 0.45876667, -0.55819994, 0.63494194, -0.77255952
def c5, -0.18528333, -0.48255831, -0.35844526, -0.93354720
def c6, 0.82736665, -0.02420000, 0.99956709, -0.02923676
def c7, -0.63184166, 0.48635834, -0.79242694, 0.60996842
def c8, 0.13079999, -0.71333331, 0.18035781, -0.98360282
def c9, 0.18054999, 0.09668333, 0.88155586, 0.47206739
def c10, -0.36389166, 0.63959163, -0.49450761, 0.86916786
def c11, -0.16186666, -0.15335000, -0.72594094, -0.68774527
def c12, -0.66720831, 0.20525832, -0.95579457, 0.29403830
def c13, -0.49167499, -0.58757496, -0.64174765, -0.76691902
def c14, 0.04569167, 0.79750830, 0.05719919, 0.99836206
def c15, 0.17649166, 0.42810830, 0.38114345, 0.92452347
def c16, 0.36678332, -0.07131667, 0.98162276, -0.19086489
def c17, -0.40740001, -0.24441667, -0.85751873, -0.51446211
def c18, -0.73513335, -0.20392500, -0.96361434, -0.26730531
def c19, -0.43841663, 0.01988333, -0.99897456, 0.04530609
def c20, 0.62992495, 0.18263334, 0.96044677, 0.27846110
def c21, -0.30518332, 0.32929999, -0.67974609, 0.73346198
def c22, 0.23570833, 0.65863329, 0.33694682, 0.94152117
def c23, 0.08965833, -0.48199165, 0.18287978, -0.98313814
def c24, 0.69261664, -0.24348333, 0.94340521, -0.33164585
def c25, -0.16990000, 0.09277500, -0.87765813, 0.47925097
def c26, 0.10105000, -0.16068333, 0.53235579, -0.84651858
def c27, 0.32309997, -0.36229166, 0.66557944, -0.74631345
def c28, -0.11178333, -0.78740001, -0.14055640, -0.99007696
def c29, 0.52052498, 0.45280832, 0.75447518, 0.65632325
def c30, 0.25000000, 0.68991661, 1.00000000, 0.26499999
def c31, 3.77358508, 2.00000000, 3.00000000, 0
def c32, 0.79529160, 1.00000000, 0.48544165, 0.18981665
def c33, 0.19358332, 1.00000000, 0.73416662, 0.49025831
def c34, 0.69954163, 1.00000000, 0.44896665, 0.65586662
def c35, 0.43886665, 1.00000000, 0.76289165, 0.47509167
def c36, 0.37364998, 1.00000000, 0.46305832, 0.79881662
def c37, 0.76615000, 1.00000000, 0.69806665, 0.22297499
def c38, 0.73586667, 1.00000000, 0.20480832, 0.72522497
def c39, 0.79734999, 1.00000000, 0.82772493, 0.51690829
def c40, 0.72253329, 1.00000000, 0.45233333, 0.50818330
dcl_texcoord1 v0.xy
texld r16, v0, s0
mul r0.xy, r16.w, c0
mul r4.xy, r0, c1.w
mad r0, r4.xyxy, c29, v0.xyxy
texld r1, r0.zwzw, s0
texld r0, r0, s0
add r21.w, r0, r1
mov r2.y, r1.w
mov r2.x, r0.w
mad r2.xy, -r16.w, c30.yzzw, r2
add r2.xy, r2, c30.w
mul_sat r2.xy, r2, c31.x
mad r2.zw, -r2.xyxy, c31.y, c31.z
mul r2.xy, r2, r2
mul r4.zw, r2.xyxy, r2
mul r1.xyz, r1, r4.w
mul r2.x, r16.w, c30
max r18.x, r2, c1.z
mad r0.xyz, r0, r4.z, r1
mul r1.xyz, r16, r18.x
add r5.xyz, r1, r0
mad r2, r4.xyxy, c28, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
cmp r6.xyz, -r21.w, r1, r5
add r21.z, r2.w, r3.w
mov r0.y, r3.w
mov r0.x, r2.w
mad r0.xy, -r16.w, c32, r0
add r1.xy, r0, c30.w
mul_sat r5.zw, r1.xyxy, c31.x
mad r0, r4.xyxy, c27, v0.xyxy
texld r1, r0.zwzw, s0
texld r0, r0, s0
add r21.y, r0.w, r1.w
mov r5.y, r1.w
mov r5.x, r0.w
mad r7.zw, -r16.w, c32.xyzy, r5.xyxy
mad r7.xy, -r5.zwzw, c31.y, c31.z
mul r5.xy, r5.zwzw, r5.zwzw
mul r5.xy, r5, r7
mul r3.xyz, r3, r5.y
mad r2.xyz, r2, r5.x, r3
add r5.zw, r7, c30.w
mul_sat r5.zw, r5, c31.x
mad r7.xy, -r5.zwzw, c31.y, c31.z
mul r3.xy, r5.zwzw, r5.zwzw
mul r5.zw, r3.xyxy, r7.xyxy
mul r3.xyz, r1, r5.w
add r2.xyz, r6, r2
cmp r1.xyz, -r21.z, r6, r2
mad r0.xyz, r0, r5.z, r3
add r6.xyz, r1, r0
mad r2, r4.xyxy, c26, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
cmp r7.xyz, -r21.y, r1, r6
add r21.x, r2.w, r3.w
mov r0.y, r3.w
mov r0.x, r2.w
mad r0.xy, -r16.w, c32.wyzw, r0
add r1.xy, r0, c30.w
mul_sat r6.zw, r1.xyxy, c31.x
mad r0, r4.xyxy, c25, v0.xyxy
texld r1, r0.zwzw, s0
texld r0, r0, s0
add r20.w, r0, r1
mov r6.y, r1.w
mov r6.x, r0.w
mad r8.zw, -r16.w, c33.xyxy, r6.xyxy
mad r8.xy, -r6.zwzw, c31.y, c31.z
mul r6.xy, r6.zwzw, r6.zwzw
mul r6.xy, r6, r8
mul r3.xyz, r3, r6.y
mad r2.xyz, r2, r6.x, r3
add r6.zw, r8, c30.w
mul_sat r6.zw, r6, c31.x
add r2.xyz, r7, r2
mad r8.xy, -r6.zwzw, c31.y, c31.z
mul r3.xy, r6.zwzw, r6.zwzw
mul r6.zw, r3.xyxy, r8.xyxy
mul r3.xyz, r1, r6.w
cmp r1.xyz, -r21.x, r7, r2
mad r0.xyz, r0, r6.z, r3
add r0.xyz, r1, r0
cmp r8.xyz, -r20.w, r1, r0
mad r2, r4.xyxy, c24, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r20.z, r2.w, r3.w
mad r0, r4.xyxy, c23, v0.xyxy
mov r7.y, r3.w
mov r7.x, r2.w
mad r7.xy, -r16.w, c33.zyzw, r7
add r1.xy, r7, c30.w
mul_sat r7.zw, r1.xyxy, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
add r20.y, r0.w, r1.w
mov r7.y, r1.w
mov r7.x, r0.w
mad r9.zw, -r16.w, c33.xywy, r7.xyxy
mad r9.xy, -r7.zwzw, c31.y, c31.z
mul r7.xy, r7.zwzw, r7.zwzw
mul r7.xy, r7, r9
mul r3.xyz, r3, r7.y
mad r2.xyz, r2, r7.x, r3
add r7.zw, r9, c30.w
mul_sat r7.zw, r7, c31.x
add r2.xyz, r8, r2
mad r9.xy, -r7.zwzw, c31.y, c31.z
mul r3.xy, r7.zwzw, r7.zwzw
mul r7.zw, r3.xyxy, r9.xyxy
mul r3.xyz, r1, r7.w
cmp r1.xyz, -r20.z, r8, r2
mad r0.xyz, r0, r7.z, r3
add r0.xyz, r1, r0
cmp r9.xyz, -r20.y, r1, r0
mad r2, r4.xyxy, c22, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r20.x, r2.w, r3.w
mad r0, r4.xyxy, c21, v0.xyxy
mov r8.y, r3.w
mov r8.x, r2.w
mad r8.xy, -r16.w, c34, r8
add r1.xy, r8, c30.w
mul_sat r8.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r10.xy, -r8, c31.y, c31.z
mul r8.xy, r8, r8
mul r8.xy, r8, r10
mul r3.xyz, r3, r8.y
mad r2.xyz, r2, r8.x, r3
add r2.xyz, r9, r2
add r19.w, r0, r1
mov r8.w, r1
mov r8.z, r0.w
mad r8.zw, -r16.w, c34.xyzy, r8
add r8.zw, r8, c30.w
mul_sat r8.zw, r8, c31.x
mad r10.xy, -r8.zwzw, c31.y, c31.z
mul r3.xy, r8.zwzw, r8.zwzw
mul r8.zw, r3.xyxy, r10.xyxy
mul r3.xyz, r1, r8.w
cmp r1.xyz, -r20.x, r9, r2
mad r0.xyz, r0, r8.z, r3
add r0.xyz, r1, r0
cmp r10.xyz, -r19.w, r1, r0
mad r2, r4.xyxy, c20, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r19.z, r2.w, r3.w
mad r0, r4.xyxy, c19, v0.xyxy
mov r9.y, r3.w
mov r9.x, r2.w
mad r9.xy, -r16.w, c34.wyzw, r9
add r1.xy, r9, c30.w
mul_sat r9.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r11.xy, -r9, c31.y, c31.z
mul r9.xy, r9, r9
mul r9.xy, r9, r11
mul r3.xyz, r3, r9.y
mad r2.xyz, r2, r9.x, r3
add r2.xyz, r10, r2
add r19.y, r0.w, r1.w
mov r9.w, r1
mov r9.z, r0.w
mad r9.zw, -r16.w, c35.xyxy, r9
add r9.zw, r9, c30.w
mul_sat r9.zw, r9, c31.x
mad r3.xy, -r9.zwzw, c31.y, c31.z
mul r9.zw, r9, r9
mul r9.zw, r9, r3.xyxy
mul r3.xyz, r1, r9.w
cmp r1.xyz, -r19.z, r10, r2
mad r0.xyz, r0, r9.z, r3
add r0.xyz, r1, r0
cmp r11.xyz, -r19.y, r1, r0
mad r2, r4.xyxy, c18, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r19.x, r2.w, r3.w
mad r0, r4.xyxy, c17, v0.xyxy
mov r10.y, r3.w
mov r10.x, r2.w
mad r10.xy, -r16.w, c35.zyzw, r10
add r1.xy, r10, c30.w
mul_sat r10.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r12.xy, -r10, c31.y, c31.z
mul r10.xy, r10, r10
mul r10.xy, r10, r12
mul r3.xyz, r3, r10.y
mad r2.xyz, r2, r10.x, r3
add r2.xyz, r11, r2
add r18.w, r0, r1
mov r10.w, r1
mov r10.z, r0.w
mad r10.zw, -r16.w, c35.xywy, r10
add r10.zw, r10, c30.w
mul_sat r10.zw, r10, c31.x
mad r3.xy, -r10.zwzw, c31.y, c31.z
mul r10.zw, r10, r10
mul r10.zw, r10, r3.xyxy
mul r3.xyz, r1, r10.w
cmp r1.xyz, -r19.x, r11, r2
mad r0.xyz, r0, r10.z, r3
add r0.xyz, r1, r0
cmp r12.xyz, -r18.w, r1, r0
mad r2, r4.xyxy, c16, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r18.z, r2.w, r3.w
mad r0, r4.xyxy, c15, v0.xyxy
mov r11.y, r3.w
mov r11.x, r2.w
mad r11.xy, -r16.w, c36, r11
add r1.xy, r11, c30.w
mul_sat r11.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r13.xy, -r11, c31.y, c31.z
mul r11.xy, r11, r11
mul r11.xy, r11, r13
mul r3.xyz, r3, r11.y
mad r2.xyz, r2, r11.x, r3
add r2.xyz, r12, r2
add r18.y, r0.w, r1.w
mov r11.w, r1
mov r11.z, r0.w
mad r11.zw, -r16.w, c36.xyzy, r11
add r11.zw, r11, c30.w
mul_sat r11.zw, r11, c31.x
mad r3.xy, -r11.zwzw, c31.y, c31.z
mul r11.zw, r11, r11
mul r11.zw, r11, r3.xyxy
mul r3.xyz, r1, r11.w
cmp r1.xyz, -r18.z, r12, r2
mad r0.xyz, r0, r11.z, r3
add r0.xyz, r1, r0
cmp r13.xyz, -r18.y, r1, r0
mad r2, r4.xyxy, c14, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r22.x, r2.w, r3.w
mad r0, r4.xyxy, c13, v0.xyxy
mov r12.y, r3.w
mov r12.x, r2.w
mad r12.xy, -r16.w, c36.wyzw, r12
add r1.xy, r12, c30.w
mul_sat r12.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r14.xy, -r12, c31.y, c31.z
mul r12.xy, r12, r12
mul r12.xy, r12, r14
mul r3.xyz, r3, r12.y
mad r2.xyz, r2, r12.x, r3
add r2.xyz, r13, r2
add r22.y, r0.w, r1.w
mov r12.w, r1
mov r12.z, r0.w
mad r12.zw, -r16.w, c37.xyxy, r12
add r12.zw, r12, c30.w
mul_sat r12.zw, r12, c31.x
mad r3.xy, -r12.zwzw, c31.y, c31.z
mul r12.zw, r12, r12
mul r12.zw, r12, r3.xyxy
mul r3.xyz, r1, r12.w
cmp r1.xyz, -r22.x, r13, r2
mad r0.xyz, r0, r12.z, r3
add r0.xyz, r1, r0
cmp r14.xyz, -r22.y, r1, r0
mad r2, r4.xyxy, c12, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r22.z, r2.w, r3.w
mad r0, r4.xyxy, c11, v0.xyxy
mov r13.y, r3.w
mov r13.x, r2.w
mad r13.xy, -r16.w, c37.zyzw, r13
add r1.xy, r13, c30.w
mul_sat r13.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r15.xy, -r13, c31.y, c31.z
mul r13.xy, r13, r13
mul r13.xy, r13, r15
mul r3.xyz, r3, r13.y
mad r2.xyz, r2, r13.x, r3
add r2.xyz, r14, r2
add r22.w, r0, r1
mov r13.w, r1
mov r13.z, r0.w
mad r13.zw, -r16.w, c37.xywy, r13
add r13.zw, r13, c30.w
mul_sat r13.zw, r13, c31.x
mad r3.xy, -r13.zwzw, c31.y, c31.z
mul r13.zw, r13, r13
mul r13.zw, r13, r3.xyxy
mul r3.xyz, r1, r13.w
cmp r1.xyz, -r22.z, r14, r2
mad r0.xyz, r0, r13.z, r3
add r0.xyz, r1, r0
cmp r15.xyz, -r22.w, r1, r0
mad r2, r4.xyxy, c10, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r23.x, r2.w, r3.w
mad r0, r4.xyxy, c9, v0.xyxy
mov r14.y, r3.w
mov r14.x, r2.w
mad r14.xy, -r16.w, c38, r14
add r1.xy, r14, c30.w
mul_sat r14.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r16.xy, -r14, c31.y, c31.z
mul r14.xy, r14, r14
mul r14.xy, r14, r16
mul r3.xyz, r3, r14.y
mad r2.xyz, r2, r14.x, r3
add r2.xyz, r15, r2
add r23.y, r0.w, r1.w
mov r14.w, r1
mov r14.z, r0.w
mad r14.zw, -r16.w, c38.xyzy, r14
add r14.zw, r14, c30.w
mul_sat r14.zw, r14, c31.x
mad r3.xy, -r14.zwzw, c31.y, c31.z
mul r14.zw, r14, r14
mul r14.zw, r14, r3.xyxy
mul r3.xyz, r1, r14.w
cmp r1.xyz, -r23.x, r15, r2
mad r0.xyz, r0, r14.z, r3
add r0.xyz, r1, r0
cmp r16.xyz, -r23.y, r1, r0
mad r2, r4.xyxy, c8, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r24.x, r2.w, r3.w
mad r0, r4.xyxy, c7, v0.xyxy
mov r15.y, r3.w
mov r15.x, r2.w
mad r15.xy, -r16.w, c38.wyzw, r15
add r1.xy, r15, c30.w
mul_sat r15.xy, r1, c31.x
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r17.xy, -r15, c31.y, c31.z
mul r15.xy, r15, r15
mul r15.xy, r15, r17
mul r3.xyz, r3, r15.y
mad r2.xyz, r2, r15.x, r3
add r2.xyz, r16, r2
add r24.y, r0.w, r1.w
mov r15.w, r1
mov r15.z, r0.w
mad r15.zw, -r16.w, c39.xyxy, r15
add r15.zw, r15, c30.w
mul_sat r15.zw, r15, c31.x
mad r3.xy, -r15.zwzw, c31.y, c31.z
mul r15.zw, r15, r15
mul r15.zw, r15, r3.xyxy
mul r3.xyz, r1, r15.w
cmp r1.xyz, -r24.x, r16, r2
mad r0.xyz, r0, r15.z, r3
mad r2, r4.xyxy, c6, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
add r0.xyz, r1, r0
add r25.z, r2.w, r3.w
mov r16.y, r3.w
mov r16.x, r2.w
mad r17.xy, -r16.w, c39.zyzw, r16
cmp r16.xyz, -r24.y, r1, r0
add r1.xy, r17, c30.w
mul_sat r17.xy, r1, c31.x
mad r0, r4.xyxy, c5, v0.xyxy
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r23.zw, -r17.xyxy, c31.y, c31.z
mul r17.xy, r17, r17
mul r17.xy, r17, r23.zwzw
mul r3.xyz, r3, r17.y
mad r2.xyz, r2, r17.x, r3
add r2.xyz, r16, r2
add r25.w, r0, r1
mov r17.w, r1
mov r17.z, r0.w
mad r17.zw, -r16.w, c39.xywy, r17
add r17.zw, r17, c30.w
mul_sat r17.zw, r17, c31.x
mad r3.xy, -r17.zwzw, c31.y, c31.z
mul r17.zw, r17, r17
mul r17.zw, r17, r3.xyxy
mul r3.xyz, r1, r17.w
cmp r1.xyz, -r25.z, r16, r2
mad r0.xyz, r0, r17.z, r3
mad r2, r4.xyxy, c4, v0.xyxy
texld r3, r2.zwzw, s0
texld r2, r2, s0
mov r16.x, r2.w
mov r16.y, r3.w
add r0.xyz, r1, r0
mad r23.zw, -r16.w, c40.xyxy, r16.xyxy
cmp r16.xyz, -r25.w, r1, r0
add r1.xy, r23.zwzw, c30.w
mul_sat r23.zw, r1.xyxy, c31.x
mad r0, r4.xyxy, c3, v0.xyxy
texld r1, r0.zwzw, s0
texld r0, r0, s0
mad r25.xy, -r23.zwzw, c31.y, c31.z
mul r23.zw, r23, r23
mul r23.zw, r23, r25.xyxy
mul r3.xyz, r3, r23.w
mad r2.xyz, r2, r23.z, r3
add r2.w, r2, r3
add r2.xyz, r16, r2
cmp r2.xyz, -r2.w, r16, r2
mov r24.w, r1
mov r24.z, r0.w
mad r24.zw, -r16.w, c40.xyzy, r24
add r24.zw, r24, c30.w
mul_sat r24.zw, r24, c31.x
mad r3.xy, -r24.zwzw, c31.y, c31.z
mul r24.zw, r24, r24
mul r3.xy, r24.zwzw, r3
mul r1.xyz, r1, r3.y
mad r0.xyz, r0, r3.x, r1
add r1.x, r4.z, r4.w
add r1.x, r18, r1
add r4.z, r0.w, r1.w
add r0.xyz, r2, r0
cmp r2.xyz, -r4.z, r2, r0
mad r0, r4.xyxy, c2, v0.xyxy
cmp r1.x, -r21.w, r18, r1
add r1.y, r5.x, r5
add r1.y, r1.x, r1
cmp r1.x, -r21.z, r1, r1.y
add r1.z, r5, r5.w
add r1.y, r1.x, r1.z
cmp r1.x, -r21.y, r1, r1.y
add r1.z, r6.x, r6.y
add r1.y, r1.x, r1.z
cmp r1.x, -r21, r1, r1.y
add r1.z, r6, r6.w
add r1.y, r1.x, r1.z
cmp r1.x, -r20.w, r1, r1.y
add r1.z, r7.x, r7.y
add r1.y, r1.x, r1.z
cmp r1.x, -r20.z, r1, r1.y
add r1.z, r7, r7.w
add r1.y, r1.x, r1.z
cmp r1.x, -r20.y, r1, r1.y
add r1.z, r8.x, r8.y
add r1.y, r1.x, r1.z
cmp r1.x, -r20, r1, r1.y
add r1.z, r8, r8.w
add r1.y, r1.x, r1.z
cmp r1.x, -r19.w, r1, r1.y
add r1.z, r9.x, r9.y
add r1.y, r1.x, r1.z
cmp r1.x, -r19.z, r1, r1.y
add r1.z, r9, r9.w
add r1.y, r1.x, r1.z
cmp r1.x, -r19.y, r1, r1.y
add r1.z, r10.x, r10.y
add r1.y, r1.x, r1.z
cmp r1.x, -r19, r1, r1.y
add r1.z, r10, r10.w
add r1.y, r1.x, r1.z
cmp r1.x, -r18.w, r1, r1.y
add r1.z, r11.x, r11.y
add r1.y, r1.x, r1.z
cmp r1.x, -r18.z, r1, r1.y
add r1.z, r11, r11.w
add r1.y, r1.x, r1.z
cmp r1.x, -r18.y, r1, r1.y
add r1.z, r12.x, r12.y
add r1.y, r1.x, r1.z
cmp r1.x, -r22, r1, r1.y
add r1.z, r12, r12.w
add r1.y, r1.x, r1.z
cmp r1.x, -r22.y, r1, r1.y
add r1.z, r13.x, r13.y
add r1.y, r1.x, r1.z
cmp r1.x, -r22.z, r1, r1.y
add r1.z, r13, r13.w
add r1.y, r1.x, r1.z
cmp r1.x, -r22.w, r1, r1.y
add r1.z, r14.x, r14.y
add r1.y, r1.x, r1.z
cmp r1.x, -r23, r1, r1.y
add r1.z, r14, r14.w
add r1.y, r1.x, r1.z
cmp r1.x, -r23.y, r1, r1.y
add r1.z, r15.x, r15.y
add r1.y, r1.x, r1.z
cmp r1.x, -r24, r1, r1.y
add r1.z, r15, r15.w
add r1.y, r1.x, r1.z
cmp r1.x, -r24.y, r1, r1.y
add r1.z, r17.x, r17.y
add r1.y, r1.x, r1.z
cmp r1.x, -r25.z, r1, r1.y
add r1.z, r17, r17.w
add r1.y, r1.x, r1.z
cmp r4.w, -r25, r1.x, r1.y
add r1.x, r23.z, r23.w
add r4.x, r4.w, r1
texld r1, r0.zwzw, s0
texld r0, r0, s0
cmp r2.w, -r2, r4, r4.x
add r4.x, r3, r3.y
add r4.x, r2.w, r4
mov r3.z, r0.w
mov r3.w, r1
mad r3.zw, -r16.w, c40.xywy, r3
add r3.zw, r3, c30.w
mul_sat r3.xy, r3.zwzw, c31.x
mad r3.zw, -r3.xyxy, c31.y, c31.z
mul r3.xy, r3, r3
mul r3.xy, r3, r3.zwzw
mul r1.xyz, r1, r3.y
mad r1.xyz, r0, r3.x, r1
add r0.x, r0.w, r1.w
cmp r2.w, -r4.z, r2, r4.x
add r3.z, r3.x, r3.y
add r3.y, r2.w, r3.z
cmp r0.y, -r0.x, r2.w, r3
rcp r0.w, r0.y
add r1.xyz, r2, r1
cmp r0.xyz, -r0.x, r2, r1
mul oC0.xyz, r0, r0.w
mov oC0.w, r16
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
BindCB  "$Globals" 0
"ps_4_0
eefiecedpllblgpkknfneifggcginfnghfedhabiabaaaaaagaahaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefciiagaaaaeaaaaaaakcabaaaa
dfbiaaaahcaaaaaamaohbpdpembkaldpebpbfddpaaaaaaaappflajlokiodhblp
eifahedpaaaaaaaadmidmgdoinjhnololacabfdpaaaaaaaackfhpidnjlhceflo
cjdpgjdoaaaaaaaaolmffalopmaaoednanoagndoaaaaaaaajhmffedpjojijflo
dhijgbdpaaaaaaaacffinmdnfobbbelphmjlbgdpaaaaaaaalhnbjadoaiffekdp
dcogfgdpaaaaaaaadaiblllogjfcmkdocnomajdpaaaaaaaafbidebdphlglgado
hehlejdpaaaaaaaahnkoaglpamhgmddmobnbagdpaaaaaaaadnnfgblpecjfhklo
dofmgkdpaaaaaaaahleopkloglcljglollpcbbdpaaaaaaaaaifkobdojbeekpln
bajcofdoaaaaaaaahknpfidompidaddpgeeaaodpaaaaaaaagmjfgadnjlpohedp
iagfhfdpaaaaaaaaofakbhlpmhiadelphnfmgldpaaaaaaaaggphemlpladihmdo
dchcfgdpaaaaaaaankogeglolngpdmlooppoiidoaaaaaaaadgjdnploijhleedp
ojaogcdpaaaaaaaabonmfndoofjlondnccklhldoaaaaaaaabplkcadonbccfllp
aemkfodpaaaaaaaaanbkeclpmhgibfdpcipchedpaaaaaaaamdckhodpelofonlm
pbeghodpaaaaaaaabjkngdlooodnbelpfdmlbodpaaaaaaaaobooamdpkchkcllp
ffpgfndpaaaaaaaaaklkondoofpcipdopbpeakdpaaaaaaaacdlojdlnklaebldp
ckbnbmdpaaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaa
gfaaaaadpccabaaaaaaaaaaagiaaaaacaiaaaaaaefaaaaajpcaabaaaaaaaaaaa
ogbkbaaaabaaaaaamghjbaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaaipcaabaaa
abaaaaaafgafbaaaaaaaaaaaegiecaaaaaaaaaaaacaaaaaadiaaaaaipcaabaaa
abaaaaaaegaobaaaabaaaaaapgipcaaaaaaaaaaaadaaaaaadiaaaaahbcaabaaa
acaaaaaabkaabaaaaaaaaaaaabeaaaaaaaaaiadodeaaaaaibcaabaaaacaaaaaa
akaabaaaacaaaaaackiacaaaaaaaaaaaadaaaaaadiaaaaahocaabaaaacaaaaaa
agaobaaaaaaaaaaaagaabaaaacaaaaaadgaaaaafbcaabaaaadaaaaaaabeaaaaa
jkjjjjdpdgaaaaafhcaabaaaaeaaaaaajgahbaaaacaaaaaadgaaaaafecaabaaa
aaaaaaaaakaabaaaacaaaaaadgaaaaaficaabaaaaaaaaaaaabeaaaaaaaaaaaaa
daaaaaabcbaaaaahccaabaaaadaaaaaadkaabaaaaaaaaaaaabeaaaaabmaaaaaa
adaaaeadbkaabaaaadaaaaaadiaaaaaipcaabaaaafaaaaaaegaobaaaabaaaaaa
egjejaaadkaabaaaaaaaaaaadgaaaaagecaabaaaadaaaaaackjajaaadkaabaaa
aaaaaaaaaoaaaaahpcaabaaaafaaaaaaegaobaaaafaaaaaaagakbaaaadaaaaaa
aaaaaaahpcaabaaaafaaaaaaegaobaaaafaaaaaaogbobaaaabaaaaaaefaaaaaj
pcaabaaaagaaaaaaegaabaaaafaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
efaaaaajpcaabaaaafaaaaaaogakbaaaafaaaaaaeghobaaaaaaaaaaaaagabaaa
aaaaaaaaaaaaaaahccaabaaaadaaaaaadkaabaaaafaaaaaadkaabaaaagaaaaaa
dbaaaaahccaabaaaadaaaaaaabeaaaaaaaaaaaaabkaabaaaadaaaaaabpaaaead
bkaabaaaadaaaaaadiaaaaaibcaabaaaaaaaaaaabkaabaaaaaaaaaaackjajaaa
dkaabaaaaaaaaaaadgaaaaafbcaabaaaahaaaaaadkaabaaaagaaaaaadgaaaaaf
ccaabaaaahaaaaaadkaabaaaafaaaaaadcaaaaangcaabaaaadaaaaaaagabbaia
ebaaaaaaaaaaaaaaaceaaaaaaaaaaaaaffffffdpaaaaiadpaaaaaaaaagabbaaa
ahaaaaaaaaaaaaakgcaabaaaadaaaaaafgagbaaaadaaaaaaaceaaaaaaaaaaaaa
bekoihdobekoihdoaaaaaaaadicaaaakgcaabaaaadaaaaaafgagbaaaadaaaaaa
aceaaaaaaaaaaaaaglichbeaglichbeaaaaaaaaadcaaaaapdcaabaaaahaaaaaa
jgafbaaaadaaaaaaaceaaaaaaaaaaamaaaaaaamaaaaaaaaaaaaaaaaaaceaaaaa
aaaaeaeaaaaaeaeaaaaaaaaaaaaaaaaadiaaaaahgcaabaaaadaaaaaafgagbaaa
adaaaaaafgagbaaaadaaaaaadiaaaaahgcaabaaaadaaaaaafgagbaaaadaaaaaa
agabbaaaahaaaaaadiaaaaahhcaabaaaafaaaaaakgakbaaaadaaaaaaegacbaaa
afaaaaaadcaaaaajhcaabaaaafaaaaaaegacbaaaagaaaaaafgafbaaaadaaaaaa
egacbaaaafaaaaaaaaaaaaahhcaabaaaaeaaaaaaegacbaaaaeaaaaaaegacbaaa
afaaaaaaapaaaaakbcaabaaaaaaaaaaajgafbaaaadaaaaaaaceaaaaaaaaaiadp
aaaaiadpaaaaaaaaaaaaaaaaaaaaaaahecaabaaaaaaaaaaaakaabaaaaaaaaaaa
ckaabaaaaaaaaaaabfaaaaabboaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaabaaaaaabgaaaaabaoaaaaahhccabaaaaaaaaaaaegacbaaaaeaaaaaa
kgakbaaaaaaaaaaadgaaaaaficcabaaaaaaaaaaabkaabaaaaaaaaaaadoaaaaab
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform sampler2D _LowRez;
uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
vec3 DiscKernel[28];
varying vec2 xlv_TEXCOORD1;
void main ()
{
  DiscKernel[0] = vec3(0.62463, 0.54337, 0.8279);
  DiscKernel[1] = vec3(-0.13414, -0.94488, 0.95435);
  DiscKernel[2] = vec3(0.38772, -0.43475, 0.58253);
  DiscKernel[3] = vec3(0.12126, -0.19282, 0.22778);
  DiscKernel[4] = vec3(-0.20388, 0.11133, 0.2323);
  DiscKernel[5] = vec3(0.83114, -0.29218, 0.881);
  DiscKernel[6] = vec3(0.10759, -0.57839, 0.58831);
  DiscKernel[7] = vec3(0.28285, 0.79036, 0.83945);
  DiscKernel[8] = vec3(-0.36622, 0.39516, 0.53876);
  DiscKernel[9] = vec3(0.75591, 0.21916, 0.78704);
  DiscKernel[10] = vec3(-0.5261, 0.02386, 0.52664);
  DiscKernel[11] = vec3(-0.88216, -0.24471, 0.91547);
  DiscKernel[12] = vec3(-0.48888, -0.2933, 0.57011);
  DiscKernel[13] = vec3(0.44014, -0.08558, 0.44838);
  DiscKernel[14] = vec3(0.21179, 0.51373, 0.55567);
  DiscKernel[15] = vec3(0.05483, 0.95701, 0.95858);
  DiscKernel[16] = vec3(-0.59001, -0.70509, 0.91938);
  DiscKernel[17] = vec3(-0.80065, 0.24631, 0.83768);
  DiscKernel[18] = vec3(-0.19424, -0.18402, 0.26757);
  DiscKernel[19] = vec3(-0.43667, 0.76751, 0.88304);
  DiscKernel[20] = vec3(0.21666, 0.11602, 0.24577);
  DiscKernel[21] = vec3(0.15696, -0.856, 0.87027);
  DiscKernel[22] = vec3(-0.75821, 0.58363, 0.95682);
  DiscKernel[23] = vec3(0.99284, -0.02904, 0.99327);
  DiscKernel[24] = vec3(-0.22234, -0.57907, 0.62029);
  DiscKernel[25] = vec3(0.55052, -0.66984, 0.86704);
  DiscKernel[26] = vec3(0.46431, 0.28115, 0.5428);
  DiscKernel[27] = vec3(-0.07214, 0.60554, 0.60982);
  vec2 tmpvar_1;
  tmpvar_1 = xlv_TEXCOORD1;
  int l_2;
  float sampleCount_3;
  vec4 poissonScale_4;
  vec4 smallBlur_5;
  vec4 centerTap_6;
  vec4 tmpvar_7;
  tmpvar_7 = texture2D (_LowRez, xlv_TEXCOORD1);
  vec4 tmpvar_8;
  tmpvar_8 = texture2D (_MainTex, xlv_TEXCOORD1);
  centerTap_6 = tmpvar_8;
  poissonScale_4 = ((_MainTex_TexelSize.xyxy * tmpvar_8.w) * _Offsets.w);
  float tmpvar_9;
  tmpvar_9 = max ((tmpvar_8.w * 0.25), 0.1);
  sampleCount_3 = tmpvar_9;
  smallBlur_5 = (tmpvar_8 * tmpvar_9);
  l_2 = 0;
  for (int l_2 = 0; l_2 < 28; ) {
    vec4 tmpvar_10;
    tmpvar_10 = texture2D (_MainTex, (tmpvar_1 + (DiscKernel[l_2].xy * poissonScale_4.xy)));
    float tmpvar_11;
    float t_12;
    t_12 = max (min ((((tmpvar_10.w - (centerTap_6.w * DiscKernel[l_2].z)) - -0.265) / 0.265), 1.0), 0.0);
    tmpvar_11 = (t_12 * (t_12 * (3.0 - (2.0 * t_12))));
    smallBlur_5 = (smallBlur_5 + (tmpvar_10 * tmpvar_11));
    sampleCount_3 = (sampleCount_3 + tmpvar_11);
    l_2 = (l_2 + 1);
  };
  float t_13;
  t_13 = max (min (((tmpvar_8.w - 0.65) / 0.2), 1.0), 0.0);
  vec4 tmpvar_14;
  tmpvar_14 = mix ((smallBlur_5 / (sampleCount_3 + 1e-05)), tmpvar_7, vec4((t_13 * (t_13 * (3.0 - (2.0 * t_13))))));
  smallBlur_5 = tmpvar_14;
  vec4 tmpvar_15;
  if ((tmpvar_8.w < 0.01)) {
    tmpvar_15 = tmpvar_8;
  } else {
    vec4 tmpvar_16;
    tmpvar_16.xyz = tmpvar_14.xyz;
    tmpvar_16.w = tmpvar_8.w;
    tmpvar_15 = tmpvar_16;
  };
  gl_FragData[0] = tmpvar_15;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Vector 1 [_Offsets]
SetTexture 0 [_LowRez] 2D 0
SetTexture 1 [_MainTex] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c2, -0.01000000, -0.64999998, 4.99999905, 0.60982001
def c3, 2.00000000, 3.00000000, -0.07214000, 0.60553998
def c4, 0.26499999, 3.77358508, 0.46430999, 0.28115001
def c5, 0.54280001, 0.55052000, -0.66983998, 0.86703998
def c6, -0.22234000, -0.57906997, 0.62028998, 0.99326998
def c7, 0.99283999, -0.02904000, -0.75821000, 0.58363003
def c8, 0.95682001, 0.15696000, -0.85600001, 0.87027001
def c9, 0.21665999, 0.11602000, 0.24577001, 0.88304001
def c10, -0.43667001, 0.76751000, -0.19424000, -0.18402000
def c11, 0.26756999, -0.80065000, 0.24631000, 0.83767998
def c12, -0.59000999, -0.70508999, 0.91938001, 0.95858002
def c13, 0.05483000, 0.95700997, 0.21179000, 0.51372999
def c14, 0.55567002, 0.44014001, -0.08558000, 0.44837999
def c15, -0.48888001, -0.29330000, 0.57011002, 0.91547000
def c16, -0.88216001, -0.24471000, -0.52609998, 0.02386000
def c17, 0.52664000, 0.75590998, 0.21916001, 0.78704000
def c18, -0.36622000, 0.39515999, 0.53876001, 0.83945000
def c19, 0.28285000, 0.79035997, 0.10759000, -0.57839000
def c20, 0.58831000, 0.83113998, -0.29218000, 0.88099998
def c21, -0.20388000, 0.11133000, 0.23230000, 0.22778000
def c22, 0.12126000, -0.19282000, 0.38771999, -0.43474999
def c23, 0.58253002, -0.13414000, -0.94488001, 0.95434999
def c24, 0.25000000, 0.10000000, 0.62462997, 0.54337001
def c25, 0.82789999, 0.00001000, 0, 0
dcl_texcoord1 v0.xy
texld r0, v0, s1
mul r1.xy, r0.w, c0
mul r3.xy, r1, c1.w
mad r1.xy, r3, c24.zwzw, v0
texld r2, r1, s1
mad r1.x, -r0.w, c25, r2.w
add r1.x, r1, c4
mul_sat r1.z, r1.x, c4.y
mad r6.xy, r3, c22.zwzw, v0
mad r7.xy, r3, c19.zwzw, v0
mad r8.xy, r3, c15, v0
mad r9.xy, r3, c12, v0
mul r2.w, r1.z, r1.z
mad r3.z, -r1, c3.x, c3.y
mul r5.z, r2.w, r3
mad r1.xy, r3, c23.yzzw, v0
texld r1, r1, s1
mul r2.w, r0, c24.x
mad r1.w, -r0, c23, r1
add r1.w, r1, c4.x
max r5.y, r2.w, c24
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r2.xyz, r2, r5.z
mul r5.x, r1.w, r2.w
mad r2.xyz, r0, r5.y, r2
mad r4.xyz, r1, r5.x, r2
texld r2, r6, s1
mad r1.xy, r3, c22, v0
texld r1, r1, s1
mad r2.w, -r0, c23.x, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r3.z, -r2.w, c3.x, c3.y
mul r2.w, r2, r2
mul r4.w, r2, r3.z
mad r2.xyz, r2, r4.w, r4
mad r1.w, -r0, c21, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r4.z, r1.w, r2.w
mad r6.xyz, r1, r4.z, r2
mad r4.xy, r3, c21, v0
texld r2, r4, s1
mad r1.xy, r3, c20.yzzw, v0
texld r1, r1, s1
mad r2.w, -r0, c21.z, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r3.z, -r2.w, c3.x, c3.y
mul r2.w, r2, r2
mul r4.y, r2.w, r3.z
mad r1.w, -r0, c20, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r2.xyz, r2, r4.y, r6
mul r4.x, r1.w, r2.w
mad r6.xyz, r1, r4.x, r2
texld r2, r7, s1
mad r1.xy, r3, c19, v0
texld r1, r1, s1
mad r2.w, -r0, c20.x, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r3.z, -r2.w, c3.x, c3.y
mul r2.w, r2, r2
mul r3.w, r2, r3.z
mad r1.w, -r0, c18, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r2.xyz, r2, r3.w, r6
mul r3.z, r1.w, r2.w
mad r6.xyz, r1, r3.z, r2
mad r7.xy, r3, c18, v0
texld r2, r7, s1
mad r1.xy, r3, c17.yzzw, v0
texld r1, r1, s1
mad r2.w, -r0, c18.z, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r5.w, -r2, c3.x, c3.y
mul r2.w, r2, r2
mul r5.w, r2, r5
mad r1.w, -r0, c17, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r7.xy, r3, c16.zwzw, v0
mad r2.xyz, r2, r5.w, r6
mul r6.w, r1, r2
mad r6.xyz, r1, r6.w, r2
texld r2, r7, s1
mad r1.xy, r3, c16, v0
texld r1, r1, s1
mad r2.w, -r0, c17.x, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r7.x, -r2.w, c3, c3.y
mul r2.w, r2, r2
mul r7.x, r2.w, r7
mad r1.w, -r0, c15, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r2.xyz, r2, r7.x, r6
mul r7.y, r1.w, r2.w
mad r6.xyz, r1, r7.y, r2
texld r2, r8, s1
mad r1.xy, r3, c14.yzzw, v0
texld r1, r1, s1
mad r2.w, -r0, c15.z, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r7.z, -r2.w, c3.x, c3.y
mul r2.w, r2, r2
mul r7.z, r2.w, r7
mad r1.w, -r0, c14, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r8.xy, r3, c13.zwzw, v0
mad r2.xyz, r2, r7.z, r6
mul r7.w, r1, r2
mad r6.xyz, r1, r7.w, r2
texld r2, r8, s1
mad r1.xy, r3, c13, v0
texld r1, r1, s1
mad r2.w, -r0, c14.x, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r8.x, -r2.w, c3, c3.y
mul r2.w, r2, r2
mul r8.x, r2.w, r8
mad r1.w, -r0, c12, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r2.xyz, r2, r8.x, r6
mul r8.y, r1.w, r2.w
mad r6.xyz, r1, r8.y, r2
texld r2, r9, s1
mad r1.xy, r3, c11.yzzw, v0
texld r1, r1, s1
mad r2.w, -r0, c12.z, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r8.z, -r2.w, c3.x, c3.y
mul r2.w, r2, r2
mul r8.z, r2.w, r8
mad r1.w, -r0, c11, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r9.xy, r3, c10.zwzw, v0
mad r2.xyz, r2, r8.z, r6
mul r8.w, r1, r2
mad r6.xyz, r1, r8.w, r2
texld r2, r9, s1
mad r1.xy, r3, c10, v0
texld r1, r1, s1
mad r2.w, -r0, c11.x, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r9.x, -r2.w, c3, c3.y
mul r2.w, r2, r2
mul r9.z, r2.w, r9.x
mad r1.w, -r0, c9, r1
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mad r2.xyz, r2, r9.z, r6
mul r9.w, r1, r2
mad r6.xyz, r1, r9.w, r2
mad r9.xy, r3, c9, v0
texld r2, r9, s1
mad r1.xy, r3, c8.yzzw, v0
texld r1, r1, s1
mad r2.w, -r0, c9.z, r2
add r2.w, r2, c4.x
mul_sat r2.w, r2, c4.y
mad r9.x, -r2.w, c3, c3.y
mad r1.w, -r0, c8, r1
add r1.w, r1, c4.x
mul r2.w, r2, r2
mul r2.w, r2, r9.x
mad r2.xyz, r2, r2.w, r6
mul_sat r1.w, r1, c4.y
mad r6.x, -r1.w, c3, c3.y
mul r1.w, r1, r1
mul r6.x, r1.w, r6
mad r2.xyz, r1, r6.x, r2
add r1.z, r5.y, r5
add r5.x, r5, r1.z
mad r1.xy, r3, c7.zwzw, v0
texld r1, r1, s1
add r4.w, r4, r5.x
add r4.z, r4, r4.w
add r4.y, r4, r4.z
mad r1.w, -r0, c8.x, r1
add r1.w, r1, c4.x
add r4.y, r4.x, r4
mul_sat r1.w, r1, c4.y
mad r4.x, -r1.w, c3, c3.y
mul r1.w, r1, r1
mul r4.x, r1.w, r4
mad r2.xyz, r1, r4.x, r2
add r1.z, r3.w, r4.y
add r3.z, r3, r1
mad r1.xy, r3, c7, v0
texld r1, r1, s1
add r3.z, r5.w, r3
mad r1.w, -r0, c6, r1
add r3.z, r6.w, r3
add r3.z, r7.x, r3
add r1.w, r1, c4.x
add r3.w, r7.y, r3.z
mul_sat r1.w, r1, c4.y
mad r3.z, -r1.w, c3.x, c3.y
mul r1.w, r1, r1
mul r3.z, r1.w, r3
mad r2.xyz, r1, r3.z, r2
add r1.z, r7, r3.w
add r3.w, r7, r1.z
mad r1.xy, r3, c6, v0
texld r1, r1, s1
add r3.w, r8.x, r3
mad r1.w, -r0, c6.z, r1
add r3.w, r8.y, r3
add r3.w, r8.z, r3
add r1.w, r1, c4.x
add r4.y, r8.w, r3.w
mul_sat r1.w, r1, c4.y
mad r3.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r3.w, r1, r3
mad r2.xyz, r1, r3.w, r2
add r1.z, r9, r4.y
add r4.y, r9.w, r1.z
mad r1.xy, r3, c5.yzzw, v0
texld r1, r1, s1
add r2.w, r2, r4.y
mad r1.w, -r0, c5, r1
add r2.w, r6.x, r2
add r2.w, r4.x, r2
add r1.w, r1, c4.x
add r3.z, r3, r2.w
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r1.w, r1, r2
mad r4.xyz, r1, r1.w, r2
add r1.z, r3.w, r3
mad r2.xy, r3, c3.zwzw, v0
mad r1.xy, r3, c4.zwzw, v0
add r3.z, r1.w, r1
texld r1, r1, s1
mad r1.w, -r0, c5.x, r1
texld r2, r2, s1
add r3.x, r1.w, c4
mad r1.w, -r0, c2, r2
mul_sat r2.w, r3.x, c4.y
mad r3.x, -r2.w, c3, c3.y
mul r2.w, r2, r2
mul r3.x, r2.w, r3
add r1.w, r1, c4.x
mul_sat r1.w, r1, c4.y
mad r2.w, -r1, c3.x, c3.y
mul r1.w, r1, r1
mul r1.w, r1, r2
mad r1.xyz, r1, r3.x, r4
mad r2.xyz, r2, r1.w, r1
add r3.y, r3.x, r3.z
add r2.w, r1, r3.y
add r2.w, r2, c25.y
rcp r2.w, r2.w
texld r1.xyz, v0, s0
add r1.w, r0, c2.y
mad r1.xyz, -r2, r2.w, r1
mul_sat r1.w, r1, c2.z
mul r3.xyz, r2, r2.w
mad r2.x, -r1.w, c3, c3.y
mul r1.w, r1, r1
mul r1.w, r1, r2.x
mad r1.xyz, r1.w, r1, r3
mov r1.w, r0
add r2.x, r0.w, c2
cmp oC0, r2.x, r1, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_LowRez] 2D 1
SetTexture 1 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
BindCB  "$Globals" 0
"ps_4_0
eefiecedgpmcjgfkjgjcjcjnfhfhifbdbodolealabaaaaaadaahaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcfiagaaaaeaaaaaaajgabaaaa
dfbiaaaahcaaaaaamaohbpdpembkaldpebpbfddpaaaaaaaappflajlokiodhblp
eifahedpaaaaaaaadmidmgdoinjhnololacabfdpaaaaaaaackfhpidnjlhceflo
cjdpgjdoaaaaaaaaolmffalopmaaoednanoagndoaaaaaaaajhmffedpjojijflo
dhijgbdpaaaaaaaacffinmdnfobbbelphmjlbgdpaaaaaaaalhnbjadoaiffekdp
dcogfgdpaaaaaaaadaiblllogjfcmkdocnomajdpaaaaaaaafbidebdphlglgado
hehlejdpaaaaaaaahnkoaglpamhgmddmobnbagdpaaaaaaaadnnfgblpecjfhklo
dofmgkdpaaaaaaaahleopkloglcljglollpcbbdpaaaaaaaaaifkobdojbeekpln
bajcofdoaaaaaaaahknpfidompidaddpgeeaaodpaaaaaaaagmjfgadnjlpohedp
iagfhfdpaaaaaaaaofakbhlpmhiadelphnfmgldpaaaaaaaaggphemlpladihmdo
dchcfgdpaaaaaaaankogeglolngpdmlooppoiidoaaaaaaaadgjdnploijhleedp
ojaogcdpaaaaaaaabonmfndoofjlondnccklhldoaaaaaaaabplkcadonbccfllp
aemkfodpaaaaaaaaanbkeclpmhgibfdpcipchedpaaaaaaaamdckhodpelofonlm
pbeghodpaaaaaaaabjkngdlooodnbelpfdmlbodpaaaaaaaaobooamdpkchkcllp
ffpgfndpaaaaaaaaaklkondoofpcipdopbpeakdpaaaaaaaacdlojdlnklaebldp
ckbnbmdpaaaaaaaafjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaa
aaaaaaaafkaaaaadaagabaaaabaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaa
fibiaaaeaahabaaaabaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaagfaaaaad
pccabaaaaaaaaaaagiaaaaacagaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaa
abaaaaaaeghobaaaaaaaaaaaaagabaaaabaaaaaaefaaaaajpcaabaaaabaaaaaa
ogbkbaaaabaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaadiaaaaaidcaabaaa
acaaaaaapgapbaaaabaaaaaaegiacaaaaaaaaaaaacaaaaaadiaaaaaidcaabaaa
acaaaaaaegaabaaaacaaaaaapgipcaaaaaaaaaaaadaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaiadodeaaaaahicaabaaaaaaaaaaa
dkaabaaaaaaaaaaaabeaaaaamnmmmmdndiaaaaahhcaabaaaadaaaaaapgapbaaa
aaaaaaaaegacbaaaabaaaaaadgaaaaafhcaabaaaaeaaaaaaegacbaaaadaaaaaa
dgaaaaafecaabaaaacaaaaaadkaabaaaaaaaaaaadgaaaaaficaabaaaacaaaaaa
abeaaaaaaaaaaaaadaaaaaabcbaaaaahicaabaaaadaaaaaadkaabaaaacaaaaaa
abeaaaaabmaaaaaaadaaaeaddkaabaaaadaaaaaadcaaaaakdcaabaaaafaaaaaa
egjajaaadkaabaaaacaaaaaaegaabaaaacaaaaaaogbkbaaaabaaaaaaefaaaaaj
pcaabaaaafaaaaaaegaabaaaafaaaaaaeghobaaaabaaaaaaaagabaaaaaaaaaaa
dcaaaaalicaabaaaadaaaaaadkaabaiaebaaaaaaabaaaaaackjajaaadkaabaaa
acaaaaaadkaabaaaafaaaaaaaaaaaaahicaabaaaadaaaaaadkaabaaaadaaaaaa
abeaaaaabekoihdodicaaaahicaabaaaadaaaaaadkaabaaaadaaaaaaabeaaaaa
glichbeadcaaaaajicaabaaaaeaaaaaadkaabaaaadaaaaaaabeaaaaaaaaaaama
abeaaaaaaaaaeaeadiaaaaahicaabaaaadaaaaaadkaabaaaadaaaaaadkaabaaa
adaaaaaadiaaaaahicaabaaaafaaaaaadkaabaaaadaaaaaadkaabaaaaeaaaaaa
dcaaaaajhcaabaaaaeaaaaaaegacbaaaafaaaaaapgapbaaaafaaaaaaegacbaaa
aeaaaaaadcaaaaajecaabaaaacaaaaaadkaabaaaaeaaaaaadkaabaaaadaaaaaa
ckaabaaaacaaaaaaboaaaaahicaabaaaacaaaaaadkaabaaaacaaaaaaabeaaaaa
abaaaaaabgaaaaabaaaaaaahicaabaaaaaaaaaaackaabaaaacaaaaaaabeaaaaa
kmmfchdhaoaaaaahhcaabaaaacaaaaaaegacbaaaaeaaaaaapgapbaaaaaaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaaggggcglpdicaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaapoppjpeadcaaaaajicaabaaa
acaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaaaamaabeaaaaaaaaaeaeadiaaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahicaabaaa
aaaaaaaadkaabaaaaaaaaaaadkaabaaaacaaaaaaaaaaaaaihcaabaaaaaaaaaaa
egacbaaaaaaaaaaaegacbaiaebaaaaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaaaaaaaaaegacbaaaacaaaaaadbaaaaahbcaabaaa
acaaaaaadkaabaaaabaaaaaaabeaaaaaaknhcddmdgaaaaaficaabaaaaaaaaaaa
dkaabaaaabaaaaaadhaaaaajpccabaaaaaaaaaaaagaabaaaacaaaaaaegaobaaa
abaaaaaaegaobaaaaaaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
varying vec4 xlv_TEXCOORD5;
void main ()
{
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = gl_MultiTexCoord0.xy;
  xlv_TEXCOORD1 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(1.0, 1.0, -1.0, -1.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD2 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(2.0, 2.0, -2.0, -2.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD3 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(3.0, 3.0, -3.0, -3.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD4 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(4.0, 4.0, -4.0, -4.0)) * _MainTex_TexelSize.xyxy) / 6.0));
  xlv_TEXCOORD5 = (gl_MultiTexCoord0.xyxy + (((_Offsets.xyxy * vec4(5.0, 5.0, -5.0, -5.0)) * _MainTex_TexelSize.xyxy) / 6.0));
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec2 xlv_TEXCOORD0;
varying vec4 xlv_TEXCOORD1;
varying vec4 xlv_TEXCOORD2;
varying vec4 xlv_TEXCOORD3;
varying vec4 xlv_TEXCOORD4;
varying vec4 xlv_TEXCOORD5;
void main ()
{
  vec4 sum_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD0);
  vec4 tmpvar_3;
  tmpvar_3 = texture2D (_MainTex, xlv_TEXCOORD1.xy);
  vec4 tmpvar_4;
  tmpvar_4 = texture2D (_MainTex, xlv_TEXCOORD1.zw);
  vec4 tmpvar_5;
  tmpvar_5 = texture2D (_MainTex, xlv_TEXCOORD2.xy);
  vec4 tmpvar_6;
  tmpvar_6 = texture2D (_MainTex, xlv_TEXCOORD2.zw);
  vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD3.xy);
  vec4 tmpvar_8;
  tmpvar_8 = texture2D (_MainTex, xlv_TEXCOORD3.zw);
  vec4 tmpvar_9;
  tmpvar_9 = texture2D (_MainTex, xlv_TEXCOORD4.xy);
  vec4 tmpvar_10;
  tmpvar_10 = texture2D (_MainTex, xlv_TEXCOORD4.zw);
  vec4 tmpvar_11;
  tmpvar_11 = texture2D (_MainTex, xlv_TEXCOORD5.xy);
  vec4 tmpvar_12;
  tmpvar_12 = texture2D (_MainTex, xlv_TEXCOORD5.zw);
  float tmpvar_13;
  tmpvar_13 = (clamp ((2.0 * tmpvar_3.w), 0.0, 1.0) * 0.8);
  float tmpvar_14;
  tmpvar_14 = (clamp ((2.0 * tmpvar_4.w), 0.0, 1.0) * 0.8);
  float tmpvar_15;
  tmpvar_15 = (clamp ((2.0 * tmpvar_5.w), 0.0, 1.0) * 0.675);
  float tmpvar_16;
  tmpvar_16 = (clamp ((2.0 * tmpvar_6.w), 0.0, 1.0) * 0.675);
  float tmpvar_17;
  tmpvar_17 = (clamp ((2.0 * tmpvar_7.w), 0.0, 1.0) * 0.5);
  float tmpvar_18;
  tmpvar_18 = (clamp ((2.0 * tmpvar_8.w), 0.0, 1.0) * 0.5);
  float tmpvar_19;
  tmpvar_19 = (clamp ((2.0 * tmpvar_9.w), 0.0, 1.0) * 0.2);
  float tmpvar_20;
  tmpvar_20 = (clamp ((2.0 * tmpvar_10.w), 0.0, 1.0) * 0.2);
  float tmpvar_21;
  tmpvar_21 = (clamp ((2.0 * tmpvar_11.w), 0.0, 1.0) * 0.075);
  float tmpvar_22;
  tmpvar_22 = (clamp ((2.0 * tmpvar_12.w), 0.0, 1.0) * 0.075);
  sum_1.xyz = ((((((((((((tmpvar_2 * tmpvar_2.w) + (tmpvar_3 * tmpvar_13)) + (tmpvar_4 * tmpvar_14)) + (tmpvar_5 * tmpvar_15)) + (tmpvar_6 * tmpvar_16)) + (tmpvar_7 * tmpvar_17)) + (tmpvar_8 * tmpvar_18)) + (tmpvar_9 * tmpvar_19)) + (tmpvar_10 * tmpvar_20)) + (tmpvar_11 * tmpvar_21)) + (tmpvar_12 * tmpvar_22)) / (((((((((((tmpvar_2.w + tmpvar_13) + tmpvar_14) + tmpvar_15) + tmpvar_16) + tmpvar_17) + tmpvar_18) + tmpvar_19) + tmpvar_20) + tmpvar_21) + tmpvar_22) + 0.0001)).xyz;
  sum_1.w = tmpvar_2.w;
  if ((tmpvar_2.w < 0.01)) {
    sum_1.xyz = tmpvar_2.xyz;
  };
  gl_FragData[0] = sum_1;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
Vector 5 [_Offsets]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_texcoord2 o3
dcl_texcoord3 o4
dcl_texcoord4 o5
dcl_texcoord5 o6
def c6, 0.16666667, -0.16666667, 0.33333334, -0.33333334
def c7, 0.50000000, -0.50000000, 0.66666669, -0.66666669
def c8, 0.83333337, -0.83333337, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, c5
mul r0.xy, c4, r0
mad o2, r0.xyxy, c6.xxyy, v1.xyxy
mad o3, r0.xyxy, c6.zzww, v1.xyxy
mad o4, r0.xyxy, c7.xxyy, v1.xyxy
mad o5, r0.xyxy, c7.zzww, v1.xyxy
mad o6, r0.xyxy, c8.xxyy, v1.xyxy
mov o1.xy, v1
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedgohcneiglfdbcbnppkcpeddheeclmhjfabaaaaaaaeaeaaaaadaaaaaa
cmaaaaaaiaaaaaaafaabaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
lmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaaapaaaaaalmaaaaaaacaaaaaa
aaaaaaaaadaaaaaaadaaaaaaapaaaaaalmaaaaaaadaaaaaaaaaaaaaaadaaaaaa
aeaaaaaaapaaaaaalmaaaaaaaeaaaaaaaaaaaaaaadaaaaaaafaaaaaaapaaaaaa
lmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaaapaaaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefckmacaaaaeaaaabaaklaaaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadpccabaaaacaaaaaa
gfaaaaadpccabaaaadaaaaaagfaaaaadpccabaaaaeaaaaaagfaaaaadpccabaaa
afaaaaaagfaaaaadpccabaaaagaaaaaagiaaaaacabaaaaaadiaaaaaipcaabaaa
aaaaaaaafgbfbaaaaaaaaaaaegiocaaaabaaaaaaabaaaaaadcaaaaakpcaabaaa
aaaaaaaaegiocaaaabaaaaaaaaaaaaaaagbabaaaaaaaaaaaegaobaaaaaaaaaaa
dcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaacaaaaaakgbkbaaaaaaaaaaa
egaobaaaaaaaaaaadcaaaaakpccabaaaaaaaaaaaegiocaaaabaaaaaaadaaaaaa
pgbpbaaaaaaaaaaaegaobaaaaaaaaaaadgaaaaafdccabaaaabaaaaaaegbabaaa
abaaaaaadgaaaaafbcaabaaaaaaaaaaaabeaaaaaaaaaiadpdgaaaaagmcaabaaa
aaaaaaaaagiecaaaaaaaaaaaacaaaaaadiaaaaaipcaabaaaaaaaaaaaagaobaaa
aaaaaaaaegiecaaaaaaaaaaaadaaaaaadiaaaaaidcaabaaaaaaaaaaaegaabaaa
aaaaaaaaegiacaaaaaaaaaaaacaaaaaadcaaaaampccabaaaacaaaaaaegaobaaa
aaaaaaaaaceaaaaaklkkckdoklkkckdoklkkckloklkkckloegbebaaaabaaaaaa
dcaaaaampccabaaaadaaaaaaogaobaaaaaaaaaaaaceaaaaaklkkkkdoklkkkkdo
klkkkkloklkkkkloegbebaaaabaaaaaadcaaaaampccabaaaaeaaaaaaogaobaaa
aaaaaaaaaceaaaaaaaaaaadpaaaaaadpaaaaaalpaaaaaalpegbebaaaabaaaaaa
dcaaaaampccabaaaafaaaaaaogaobaaaaaaaaaaaaceaaaaaklkkckdpklkkckdp
klkkcklpklkkcklpegbebaaaabaaaaaadcaaaaampccabaaaagaaaaaaogaobaaa
aaaaaaaaaceaaaaafgffffdpfgffffdpfgfffflpfgfffflpegbebaaaabaaaaaa
doaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 2.00000000, 0.80000001, 0.67500001, 0.50000000
def c1, 0.20000000, 0.07500000, 0.00010000, -0.01000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1
dcl_texcoord2 v2
dcl_texcoord3 v3
dcl_texcoord4 v4
dcl_texcoord5 v5
texld r0, v1, s0
texld r2, v1.zwzw, s0
mul_sat r0.w, r0, c0.x
mul r3.x, r0.w, c0.y
mul r1.xyz, r0, r3.x
texld r0, v0, s0
mad r4.xyz, r0, r0.w, r1
texld r1, v2, s0
mul_sat r2.w, r2, c0.x
mul r3.y, r2.w, c0
mad r4.xyz, r2, r3.y, r4
texld r2, v2.zwzw, s0
mul_sat r1.w, r1, c0.x
mul r3.z, r1.w, c0
mad r4.xyz, r1, r3.z, r4
mul_sat r2.w, r2, c0.x
mul r3.w, r2, c0.z
mad r4.xyz, r2, r3.w, r4
texld r1, v3, s0
mul_sat r1.w, r1, c0.x
mul r4.w, r1, c0
texld r2, v3.zwzw, s0
mad r1.xyz, r1, r4.w, r4
add r1.w, r0, r3.x
mul_sat r2.w, r2, c0.x
mul r3.x, r2.w, c0.w
add r2.w, r3.y, r1
mad r2.xyz, r2, r3.x, r1
texld r1, v4, s0
add r2.w, r3.z, r2
mul_sat r1.w, r1, c0.x
mul r1.w, r1, c1.x
mad r4.xyz, r1, r1.w, r2
add r2.w, r3, r2
add r1.x, r4.w, r2.w
add r1.x, r3, r1
texld r2, v4.zwzw, s0
mul_sat r1.y, r2.w, c0.x
mul r2.w, r1.y, c1.x
add r1.x, r1.w, r1
add r4.w, r2, r1.x
texld r3, v5, s0
texld r1, v5.zwzw, s0
mul_sat r3.w, r3, c0.x
mul r3.w, r3, c1.y
mad r2.xyz, r2, r2.w, r4
mul_sat r1.w, r1, c0.x
mul r1.w, r1, c1.y
mad r2.xyz, r3, r3.w, r2
add r4.w, r3, r4
add r4.w, r1, r4
add r2.w, r4, c1.z
mad r1.xyz, r1, r1.w, r2
rcp r2.w, r2.w
mul r2.xyz, r1, r2.w
add r1.x, r0.w, c1.w
cmp oC0.xyz, r1.x, r2, r0
mov oC0.w, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedmgfohgabecndcmnhjndejndhdonlgpedabaaaaaapaaiaaaaadaaaaaa
cmaaaaaapmaaaaaadaabaaaaejfdeheomiaaaaaaahaaaaaaaiaaaaaalaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaalmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaalmaaaaaaabaaaaaaaaaaaaaaadaaaaaaacaaaaaa
apapaaaalmaaaaaaacaaaaaaaaaaaaaaadaaaaaaadaaaaaaapapaaaalmaaaaaa
adaaaaaaaaaaaaaaadaaaaaaaeaaaaaaapapaaaalmaaaaaaaeaaaaaaaaaaaaaa
adaaaaaaafaaaaaaapapaaaalmaaaaaaafaaaaaaaaaaaaaaadaaaaaaagaaaaaa
apapaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcliahaaaaeaaaaaaaooabaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
dcbabaaaabaaaaaagcbaaaadpcbabaaaacaaaaaagcbaaaadpcbabaaaadaaaaaa
gcbaaaadpcbabaaaaeaaaaaagcbaaaadpcbabaaaafaaaaaagcbaaaadpcbabaaa
agaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacagaaaaaaefaaaaajpcaabaaa
aaaaaaaaogbkbaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
icaabaaaaaaaaaaadkaabaaaaaaaaaaadkaabaaaaaaaaaaadiaaaaahbcaabaaa
abaaaaaadkaabaaaaaaaaaaaabeaaaaamnmmemdpefaaaaajpcaabaaaacaaaaaa
egbabaaaacaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaahccaabaaa
abaaaaaadkaabaaaacaaaaaadkaabaaaacaaaaaadiaaaaahecaabaaaabaaaaaa
bkaabaaaabaaaaaaabeaaaaamnmmemdpdiaaaaahhcaabaaaacaaaaaakgakbaaa
abaaaaaaegacbaaaacaaaaaaefaaaaajpcaabaaaadaaaaaaegbabaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadcaaaaajhcaabaaaacaaaaaaegacbaaa
adaaaaaapgapbaaaadaaaaaaegacbaaaacaaaaaadcaaaaajhcaabaaaaaaaaaaa
egacbaaaaaaaaaaaagaabaaaabaaaaaaegacbaaaacaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
bcaabaaaabaaaaaadkaabaaaacaaaaaadkaabaaaacaaaaaadiaaaaahecaabaaa
abaaaaaaakaabaaaabaaaaaaabeaaaaamnmmcmdpdcaaaaajhcaabaaaaaaaaaaa
egacbaaaacaaaaaakgakbaaaabaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaogbkbaaaadaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
ecaabaaaabaaaaaadkaabaaaacaaaaaadkaabaaaacaaaaaadiaaaaahicaabaaa
abaaaaaackaabaaaabaaaaaaabeaaaaamnmmcmdpdcaaaaajhcaabaaaaaaaaaaa
egacbaaaacaaaaaapgapbaaaabaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaegbabaaaaeaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
icaabaaaabaaaaaadkaabaaaacaaaaaadkaabaaaacaaaaaadiaaaaahicaabaaa
acaaaaaadkaabaaaabaaaaaaabeaaaaaaaaaaadpdcaaaaajhcaabaaaaaaaaaaa
egacbaaaacaaaaaapgapbaaaacaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
acaaaaaaogbkbaaaaeaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
icaabaaaacaaaaaadkaabaaaacaaaaaadkaabaaaacaaaaaadiaaaaahbcaabaaa
aeaaaaaadkaabaaaacaaaaaaabeaaaaaaaaaaadpdcaaaaajhcaabaaaaaaaaaaa
egacbaaaacaaaaaaagaabaaaaeaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaafaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
bcaabaaaacaaaaaadkaabaaaaeaaaaaadkaabaaaaeaaaaaadiaaaaahccaabaaa
acaaaaaaakaabaaaacaaaaaaabeaaaaamnmmemdodcaaaaajhcaabaaaaaaaaaaa
egacbaaaaeaaaaaafgafbaaaacaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aeaaaaaaogbkbaaaafaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
ccaabaaaacaaaaaadkaabaaaaeaaaaaadkaabaaaaeaaaaaadiaaaaahecaabaaa
acaaaaaabkaabaaaacaaaaaaabeaaaaamnmmemdodcaaaaajhcaabaaaaaaaaaaa
egacbaaaaeaaaaaakgakbaaaacaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aeaaaaaaegbabaaaagaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
ecaabaaaacaaaaaadkaabaaaaeaaaaaadkaabaaaaeaaaaaadiaaaaahicaabaaa
aeaaaaaackaabaaaacaaaaaaabeaaaaajkjjjjdndcaaaaajhcaabaaaaaaaaaaa
egacbaaaaeaaaaaapgapbaaaaeaaaaaaegacbaaaaaaaaaaaefaaaaajpcaabaaa
aeaaaaaaogbkbaaaagaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaaacaaaah
icaabaaaaeaaaaaadkaabaaaaeaaaaaadkaabaaaaeaaaaaadiaaaaahbcaabaaa
afaaaaaadkaabaaaaeaaaaaaabeaaaaajkjjjjdndcaaaaajhcaabaaaaaaaaaaa
egacbaaaaeaaaaaaagaabaaaafaaaaaaegacbaaaaaaaaaaadcaaaaajccaabaaa
abaaaaaabkaabaaaabaaaaaaabeaaaaamnmmemdpdkaabaaaadaaaaaadcaaaaaj
icaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaamnmmemdpbkaabaaaabaaaaaa
dcaaaaajicaabaaaaaaaaaaaakaabaaaabaaaaaaabeaaaaamnmmcmdpdkaabaaa
aaaaaaaadcaaaaajicaabaaaaaaaaaaackaabaaaabaaaaaaabeaaaaamnmmcmdp
dkaabaaaaaaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaabaaaaaaabeaaaaa
aaaaaadpdkaabaaaaaaaaaaadcaaaaajicaabaaaaaaaaaaadkaabaaaacaaaaaa
abeaaaaaaaaaaadpdkaabaaaaaaaaaaadcaaaaajicaabaaaaaaaaaaaakaabaaa
acaaaaaaabeaaaaamnmmemdodkaabaaaaaaaaaaadcaaaaajicaabaaaaaaaaaaa
bkaabaaaacaaaaaaabeaaaaamnmmemdodkaabaaaaaaaaaaadcaaaaajicaabaaa
aaaaaaaackaabaaaacaaaaaaabeaaaaajkjjjjdndkaabaaaaaaaaaaadcaaaaaj
icaabaaaaaaaaaaadkaabaaaaeaaaaaaabeaaaaajkjjjjdndkaabaaaaaaaaaaa
aaaaaaahicaabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaabhlhnbdiaoaaaaah
hcaabaaaaaaaaaaaegacbaaaaaaaaaaapgapbaaaaaaaaaaadbaaaaahicaabaaa
aaaaaaaadkaabaaaadaaaaaaabeaaaaaaknhcddmdhaaaaajhccabaaaaaaaaaaa
pgapbaaaaaaaaaaaegacbaaaadaaaaaaegacbaaaaaaaaaaadgaaaaaficcabaaa
aaaaaaaadkaabaaaadaaaaaadoaaaaab"
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
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec4 c_1;
  vec4 tmpvar_2;
  tmpvar_2 = texture2D (_MainTex, xlv_TEXCOORD1);
  c_1.xyz = tmpvar_2.xyz;
  c_1.w = clamp ((tmpvar_2.w * 100.0), 0.0, 1.0);
  gl_FragData[0] = c_1;
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c0, 100.00000000, 0, 0, 0
dcl_texcoord1 v0.xy
texld r0, v0, s0
mul_sat oC0.w, r0, c0.x
mov oC0.xyz, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefieceddgacmecgcnmlpngfimmgbagldgnkknhpabaaaaaaheabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcjmaaaaaaeaaaaaaachaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
mcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaagiaaaaacabaaaaaaefaaaaaj
pcaabaaaaaaaaaaaogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaa
dicaaaahiccabaaaaaaaaaaadkaabaaaaaaaaaaaabeaaaaaaaaamiecdgaaaaaf
hccabaaaaaaaaaaaegacbaaaaaaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend DstAlpha OneMinusDstAlpha, Zero One
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
uniform vec4 _MainTex_TexelSize;
uniform vec4 _Offsets;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = xlv_TEXCOORD1;
  int l_2;
  vec4 steps_3;
  vec2 lenStep_4;
  vec4 sum_5;
  float sampleCount_6;
  vec4 tmpvar_7;
  tmpvar_7 = texture2D (_MainTex, xlv_TEXCOORD1);
  sampleCount_6 = tmpvar_7.w;
  sum_5 = (tmpvar_7 * tmpvar_7.w);
  vec2 tmpvar_8;
  tmpvar_8 = (tmpvar_7.ww * 0.0909091);
  lenStep_4 = tmpvar_8;
  steps_3 = (((_Offsets.xyxy * _MainTex_TexelSize.xyxy) * tmpvar_8.xyxy) * vec4(1.0, 1.0, -1.0, -1.0));
  l_2 = 1;
  for (int l_2 = 1; l_2 < 12; ) {
    vec4 tmpvar_9;
    tmpvar_9 = (tmpvar_1.xyxy + (steps_3 * float(l_2)));
    vec4 tmpvar_10;
    tmpvar_10 = texture2D (_MainTex, tmpvar_9.xy);
    vec4 tmpvar_11;
    tmpvar_11 = texture2D (_MainTex, tmpvar_9.zw);
    vec2 tmpvar_12;
    tmpvar_12.x = tmpvar_10.w;
    tmpvar_12.y = tmpvar_11.w;
    vec2 tmpvar_13;
    vec2 t_14;
    t_14 = max (min ((((tmpvar_12 - (lenStep_4.xx * float(l_2))) - vec2(-0.4, -0.4)) / vec2(0.4, 0.4)), 1.0), 0.0);
    tmpvar_13 = (t_14 * (t_14 * (3.0 - (2.0 * t_14))));
    sum_5 = (sum_5 + ((tmpvar_10 * tmpvar_13.x) + (tmpvar_11 * tmpvar_13.y)));
    sampleCount_6 = (sampleCount_6 + dot (tmpvar_13, vec2(1.0, 1.0)));
    l_2 = (l_2 + 1);
  };
  gl_FragData[0] = (sum_5 / (1e-05 + sampleCount_6));
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.xy, v1
mov r2.x, c5
mov r0.zw, v1.xyxy
dp4 r1.w, v0, c3
dp4 r1.z, v0, c2
dp4 r1.y, v0, c1
dp4 r1.x, v0, c0
if_lt c4.y, r2.x
add r0.w, -v1.y, c5.y
mov r0.z, v1.x
endif
mov r2.x, c5
if_lt c4.y, r2.x
add r0.y, -v1, c5
mov r0.x, v1
endif
mov o0, r1
mov o1.xy, r0.zwzw
mov o2.xy, r0
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedkgjficmedejgdpgffhjlpgmaddellojeabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajkccabaaaabaaaaaaagaabaaaaaaaaaaafgafbaaaaaaaaaaafgbfbaaa
abaaaaaadgaaaaaffccabaaaabaaaaaaagbabaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
Vector 0 [_MainTex_TexelSize]
Vector 1 [_Offsets]
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
def c2, 0.09090909, 1.00000000, -1.00000000, 0.40000001
defi i0, 11, 1, 1, 0
def c3, 2.50000000, 2.00000000, 3.00000000, 0.00001000
dcl_texcoord1 v0.xy
texld r0, v0, s0
mov r1.xy, c1
mul r1.xy, c0, r1
mul r5.y, r0.w, c2.x
mul r1.xy, r5.y, r1
mov r5.x, r0.w
mul r2, r0, r0.w
mul r3, r1.xyxy, c2.yyzz
mov r5.z, c2.y
loop aL, i0
mad r0, r3, r5.z, v0.xyxy
texld r1, r0.zwzw, s0
texld r0, r0, s0
mov r4.y, r1.w
mov r4.x, r0.w
mad r4.xy, r5.z, -r5.y, r4
add r4.xy, r4, c2.w
mul_sat r4.xy, r4, c3.x
mad r4.zw, -r4.xyxy, c3.y, c3.z
mul r4.xy, r4, r4
mul r4.xy, r4, r4.zwzw
mul r1, r4.y, r1
mad r0, r0, r4.x, r1
add r1.x, r4, r4.y
add r2, r2, r0
add r5.x, r5, r1
add r5.z, r5, c2.y
endloop
add r0.x, r5, c3.w
rcp r0.x, r0.x
mul oC0, r2, r0.x
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
Vector 48 [_Offsets]
BindCB  "$Globals" 0
"ps_4_0
eefiecedifmadniofklhhocnfdlldjaapgfmhgplabaaaaaaoiaeaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcbaaeaaaaeaaaaaaaaeabaaaa
fjaaaaaeegiocaaaaaaaaaaaaeaaaaaafkaaaaadaagabaaaaaaaaaaafibiaaae
aahabaaaaaaaaaaaffffaaaagcbaaaadmcbabaaaabaaaaaagfaaaaadpccabaaa
aaaaaaaagiaaaaacaiaaaaaaefaaaaajpcaabaaaaaaaaaaaogbkbaaaabaaaaaa
eghobaaaaaaaaaaaaagabaaaaaaaaaaadiaaaaahpcaabaaaabaaaaaapgapbaaa
aaaaaaaaegaobaaaaaaaaaaadiaaaaahbcaabaaaaaaaaaaadkaabaaaaaaaaaaa
abeaaaaaimcolkdndiaaaaajpcaabaaaacaaaaaaegiecaaaaaaaaaaaacaaaaaa
egiecaaaaaaaaaaaadaaaaaadiaaaaahpcaabaaaacaaaaaaagaabaaaaaaaaaaa
egaobaaaacaaaaaadiaaaaakpcaabaaaacaaaaaaegaobaaaacaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaialpaaaaialpdgaaaaafpcaabaaaadaaaaaaegaobaaa
abaaaaaadgaaaaafccaabaaaaaaaaaaadkaabaaaaaaaaaaadgaaaaafecaabaaa
aaaaaaaaabeaaaaaabaaaaaadaaaaaabcbaaaaahbcaabaaaaeaaaaaackaabaaa
aaaaaaaaabeaaaaaamaaaaaaadaaaeadakaabaaaaeaaaaaaclaaaaafbcaabaaa
aeaaaaaackaabaaaaaaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaaacaaaaaa
agaabaaaaeaaaaaaogbobaaaabaaaaaaefaaaaajpcaabaaaagaaaaaaegaabaaa
afaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaaefaaaaajpcaabaaaafaaaaaa
ogakbaaaafaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadgaaaaafbcaabaaa
ahaaaaaadkaabaaaagaaaaaadgaaaaafccaabaaaahaaaaaadkaabaaaafaaaaaa
dcaaaaakdcaabaaaaeaaaaaaagaabaiaebaaaaaaaaaaaaaaagaabaaaaeaaaaaa
egaabaaaahaaaaaaaaaaaaakdcaabaaaaeaaaaaaegaabaaaaeaaaaaaaceaaaaa
mnmmmmdomnmmmmdoaaaaaaaaaaaaaaaadicaaaakdcaabaaaaeaaaaaaegaabaaa
aeaaaaaaaceaaaaaaaaacaeaaaaacaeaaaaaaaaaaaaaaaaadcaaaaapmcaabaaa
aeaaaaaaagaebaaaaeaaaaaaaceaaaaaaaaaaaaaaaaaaaaaaaaaaamaaaaaaama
aceaaaaaaaaaaaaaaaaaaaaaaaaaeaeaaaaaeaeadiaaaaahdcaabaaaaeaaaaaa
egaabaaaaeaaaaaaegaabaaaaeaaaaaadiaaaaahdcaabaaaaeaaaaaaegaabaaa
aeaaaaaaogakbaaaaeaaaaaadiaaaaahpcaabaaaafaaaaaafgafbaaaaeaaaaaa
egaobaaaafaaaaaadcaaaaajpcaabaaaafaaaaaaegaobaaaagaaaaaaagaabaaa
aeaaaaaaegaobaaaafaaaaaaaaaaaaahpcaabaaaadaaaaaaegaobaaaadaaaaaa
egaobaaaafaaaaaaapaaaaakbcaabaaaaeaaaaaaegaabaaaaeaaaaaaaceaaaaa
aaaaiadpaaaaiadpaaaaaaaaaaaaaaaaaaaaaaahccaabaaaaaaaaaaabkaabaaa
aaaaaaaaakaabaaaaeaaaaaaboaaaaahecaabaaaaaaaaaaackaabaaaaaaaaaaa
abeaaaaaabaaaaaabgaaaaabaaaaaaahbcaabaaaaaaaaaaabkaabaaaaaaaaaaa
abeaaaaakmmfchdhaoaaaaahpccabaaaaaaaaaaaegaobaaaadaaaaaaagaabaaa
aaaaaaaadoaaaaab"
}
}
 }
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
  Blend DstAlpha One, Zero One
Program "vp" {
SubProgram "opengl " {
"!!GLSL
#ifdef VERTEX

varying vec2 xlv_TEXCOORD0;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  vec2 tmpvar_1;
  tmpvar_1 = gl_MultiTexCoord0.xy;
  gl_Position = (gl_ModelViewProjectionMatrix * gl_Vertex);
  xlv_TEXCOORD0 = tmpvar_1;
  xlv_TEXCOORD1 = tmpvar_1;
}


#endif
#ifdef FRAGMENT
uniform sampler2D _MainTex;
varying vec2 xlv_TEXCOORD1;
void main ()
{
  gl_FragData[0] = texture2D (_MainTex, xlv_TEXCOORD1);
}


#endif
"
}
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_MainTex_TexelSize]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
def c5, 0.00000000, 1.00000000, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r1.z, c5.x
dp4 r0.x, v0, c0
mov r1.xy, v1
dp4 r0.w, v0, c3
dp4 r0.z, v0, c2
dp4 r0.y, v0, c1
if_lt c4.y, r1.z
add r1.y, -v1, c5
mov r1.x, v1
endif
mov o0, r0
mov o1.xy, r1
mov o2.xy, v1
"
}
SubProgram "d3d11 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
ConstBuffer "$Globals" 80
Vector 32 [_MainTex_TexelSize]
ConstBuffer "UnityPerDraw" 336
Matrix 0 [glstate_matrix_mvp]
BindCB  "$Globals" 0
BindCB  "UnityPerDraw" 1
"vs_4_0
eefiecedbppjboecbfimpddaoamfhjgfgmodcldmabaaaaaahmacaaaaadaaaaaa
cmaaaaaaiaaaaaaapaaaaaaaejfdeheoemaaaaaaacaaaaaaaiaaaaaadiaaaaaa
aaaaaaaaaaaaaaaaadaaaaaaaaaaaaaaapapaaaaebaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadadaaaafaepfdejfeejepeoaafeeffiedepepfceeaaklkl
epfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaaaaaaaaaaabaaaaaaadaaaaaa
aaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaaadaaaaaaabaaaaaaadamaaaa
fmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaaamadaaaafdfgfpfagphdgjhe
gjgpgoaafeeffiedepepfceeaaklklklfdeieefcieabaaaaeaaaabaagbaaaaaa
fjaaaaaeegiocaaaaaaaaaaaadaaaaaafjaaaaaeegiocaaaabaaaaaaaeaaaaaa
fpaaaaadpcbabaaaaaaaaaaafpaaaaaddcbabaaaabaaaaaaghaaaaaepccabaaa
aaaaaaaaabaaaaaagfaaaaaddccabaaaabaaaaaagfaaaaadmccabaaaabaaaaaa
giaaaaacabaaaaaadiaaaaaipcaabaaaaaaaaaaafgbfbaaaaaaaaaaaegiocaaa
abaaaaaaabaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaaabaaaaaaaaaaaaaa
agbabaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpcaabaaaaaaaaaaaegiocaaa
abaaaaaaacaaaaaakgbkbaaaaaaaaaaaegaobaaaaaaaaaaadcaaaaakpccabaaa
aaaaaaaaegiocaaaabaaaaaaadaaaaaapgbpbaaaaaaaaaaaegaobaaaaaaaaaaa
dbaaaaaibcaabaaaaaaaaaaabkiacaaaaaaaaaaaacaaaaaaabeaaaaaaaaaaaaa
aaaaaaaiccaabaaaaaaaaaaabkbabaiaebaaaaaaabaaaaaaabeaaaaaaaaaiadp
dhaaaaajcccabaaaabaaaaaaakaabaaaaaaaaaaabkaabaaaaaaaaaaabkbabaaa
abaaaaaadgaaaaafnccabaaaabaaaaaaagbebaaaabaaaaaadoaaaaab"
}
}
Program "fp" {
SubProgram "opengl " {
"!!GLSL"
}
SubProgram "d3d9 " {
SetTexture 0 [_MainTex] 2D 0
"ps_3_0
dcl_2d s0
dcl_texcoord1 v0.xy
texld r0, v0, s0
mov oC0, r0
"
}
SubProgram "d3d11 " {
SetTexture 0 [_MainTex] 2D 0
"ps_4_0
eefiecedjloobendnpaiiejbaokogkbljkgkldnkabaaaaaadmabaaaaadaaaaaa
cmaaaaaajmaaaaaanaaaaaaaejfdeheogiaaaaaaadaaaaaaaiaaaaaafaaaaaaa
aaaaaaaaabaaaaaaadaaaaaaaaaaaaaaapaaaaaafmaaaaaaaaaaaaaaaaaaaaaa
adaaaaaaabaaaaaaadaaaaaafmaaaaaaabaaaaaaaaaaaaaaadaaaaaaabaaaaaa
amamaaaafdfgfpfagphdgjhegjgpgoaafeeffiedepepfceeaaklklklepfdeheo
cmaaaaaaabaaaaaaaiaaaaaacaaaaaaaaaaaaaaaaaaaaaaaadaaaaaaaaaaaaaa
apaaaaaafdfgfpfegbhcghgfheaaklklfdeieefcgeaaaaaaeaaaaaaabjaaaaaa
fkaaaaadaagabaaaaaaaaaaafibiaaaeaahabaaaaaaaaaaaffffaaaagcbaaaad
mcbabaaaabaaaaaagfaaaaadpccabaaaaaaaaaaaefaaaaajpccabaaaaaaaaaaa
ogbkbaaaabaaaaaaeghobaaaaaaaaaaaaagabaaaaaaaaaaadoaaaaab"
}
}
 }
}
Fallback Off
}