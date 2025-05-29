†ßShader "Hidden/SSAO" {
Properties {
 _MainTex ("", 2D) = "" {}
 _RandomTexture ("", 2D) = "" {}
 _SSAO ("", 2D) = "" {}
}
SubShader { 
 Pass {
  ZTest Always
  ZWrite Off
  Cull Off
  Fog { Mode Off }
Program "vp" {
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_NoiseScale]
Vector 5 [_CameraDepthNormalsTexture_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mad o1.xy, v1, c5, c5.zwzw
mul o2.xy, v1, c4
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Vector 0 [_ProjectionParams]
Float 1 [_NoSsaoDist]
Vector 2 [_Params]
SetTexture 0 [_RandomTexture] 2D 0
SetTexture 1 [_CameraDepthNormalsTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 2.00000000, -1.00000000, 0.30000001, 1.00000000
def c4, 0.88491488, 0.28420761, 0.36852399, 2.00000000
def c5, 3.55539989, 0.00000000, -1.77769995, 1.00000000
def c6, 1.00000000, 0.00392157, 0.12500000, 0
def c7, 0.18718980, -0.70276397, -0.23174790, 2.00000000
def c8, -0.24845780, 0.25553221, 0.34894389, 2.00000000
def c9, 0.13999920, -0.33577019, 0.55967891, 2.00000000
def c10, -0.47964570, 0.09398766, -0.58026528, 2.00000000
def c11, -0.31072500, -0.19136700, 0.05613686, 2.00000000
def c12, 0.32307819, 0.02207272, -0.41887251, 2.00000000
def c13, 0.01305719, 0.58723211, -0.11933700, 2.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
texld r0, v0, s1
mad r1.xyz, r0, c5.xxyw, c5.zzww
dp3 r0.x, r1, r1
texld r2.xyz, v1, s0
mad r2.xyz, r2, c3.x, c3.y
dp3 r0.y, r2, c13
mul r3.xyz, r2, r0.y
rcp r0.x, r0.x
mul r0.x, r0, c3
mul r1.xy, r0.x, r1
add r1.z, r0.x, c3.y
mad r3.xyz, -r3, c13.w, c13
dp3 r0.x, r1, r3
mul r4.xyz, r1, c3.z
cmp r0.x, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r0.x, r4
mul r0.xy, r0.zwzw, c6
add r0.w, r0.x, r0.y
mul r0.w, r0, c0.z
dp3 r0.z, r2, c12
mul r0.xyz, r2, r0.z
mad r0.xyz, -r0, c12.w, c12
dp3 r2.w, r1, r0
add r1.w, r0, -c1.x
cmp r1.w, -r1, r0, c1.x
cmp r2.w, r2, c3.y, -c3.y
mad_pp r0.xyz, r0, -r2.w, r4
rcp r0.w, r1.w
mul r2.w, r0, c2.x
mad r3.xy, r2.w, r3, v0
mad r0.xy, r2.w, r0, v0
texld r5.zw, r0, s1
mul r0.xy, r5.zwzw, c6
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r4.w, -r0.x, c0.z, r0.z
texld r6.zw, r3, s1
mul r0.xy, r6.zwzw, c6
mad r0.z, -r3, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.x, -r0, c0.z, r0.z
add r3.x, -r4.w, c3.w
pow r0, r3.x, c2.z
add r5.y, -r5.x, c3.w
pow r3, r5.y, c2.z
mov r0.w, r0.x
mov r0.y, r3.x
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, c5.y, r0.y
add r0.w, r0.z, r0
add r0.y, r4.w, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c11
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c10
mad r3.xyz, -r0, c11.w, c11
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c10.w, c10
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c9
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c8
mad r3.xyz, -r0, c9.w, c9
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
mad r0.xyz, -r0, c8.w, c8
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
texld r5.zw, r3, s1
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
pow r3, r0.w, c2.z
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
dp3 r3.x, r2, c4
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r0.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c7
mul r0.xyz, r2, r0.x
mul r2.xyz, r2, r3.x
mad r0.xyz, -r0, c7.w, c7
dp3 r3.x, r1, r0
mad r2.xyz, -r2, c4.w, c4
dp3 r1.x, r2, r1
cmp r3.x, r3, c3.y, -c3.y
mad_pp r0.xyz, r0, -r3.x, r4
mad r0.xy, r2.w, r0, v0
cmp r1.x, r1, c3.y, -c3.y
mad_pp r1.xyz, r2, -r1.x, r4
texld r3.zw, r0, s1
mad r0.xy, r1, r2.w, v0
texld r2.zw, r0, s1
mul r0.xy, r2.zwzw, c6
mad r2.x, -r0.z, c2, r1.w
mul r1.xy, r3.zwzw, c6
add r0.z, r1.x, r1.y
mad_sat r0.z, -r0, c0, r2.x
add r1.y, -r0.z, c3.w
pow r2, r1.y, c2.z
add r0.x, r0, r0.y
mad r1.x, -r1.z, c2, r1.w
mad_sat r0.x, -r0, c0.z, r1
add r0.y, -r0.x, c3.w
pow r1, r0.y, c2.z
mov r0.y, r2.x
add r1.y, r0.w, r0
add r0.y, r0.z, -c2
cmp r0.y, -r0, r0.w, r1
add r0.z, r0.y, r1.x
add r0.x, r0, -c2.y
cmp r0.x, -r0, r0.y, r0.z
mad oC0, -r0.x, c6.z, c6.x
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
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_NoiseScale]
Vector 5 [_CameraDepthNormalsTexture_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mad o1.xy, v1, c5, c5.zwzw
mul o2.xy, v1, c4
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Vector 0 [_ProjectionParams]
Float 1 [_NoSsaoDist]
Vector 2 [_Params]
SetTexture 0 [_RandomTexture] 2D 0
SetTexture 1 [_CameraDepthNormalsTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 2.00000000, -1.00000000, 0.30000001, 1.00000000
def c4, -0.69844460, -0.60034221, -0.04016943, 2.00000000
def c5, 3.55539989, 0.00000000, -1.77769995, 1.00000000
def c6, 1.00000000, 0.00392157, 0.07142857, 0
def c7, 0.03704464, -0.93913102, 0.13587651, 2.00000000
def c8, 0.70261252, 0.16482490, 0.02250625, 2.00000000
def c9, -0.32154989, 0.68320483, -0.34334460, 2.00000000
def c10, -0.01956503, -0.31080621, -0.41066301, 2.00000000
def c11, -0.32949659, 0.02684341, -0.40218359, 2.00000000
def c12, 0.19861419, 0.17672390, 0.43804911, 2.00000000
def c13, 0.18916769, -0.12837550, -0.09873557, 2.00000000
def c14, -0.08829653, 0.16497590, 0.13958789, 2.00000000
def c15, 0.38207859, -0.32413980, 0.41128251, 2.00000000
def c16, -0.62566841, 0.12416610, 0.11639320, 2.00000000
def c17, -0.23052961, -0.19000851, 0.50253958, 2.00000000
def c18, 0.16178370, 0.13385519, -0.35304859, 2.00000000
def c19, 0.40100390, 0.88993812, -0.01751772, 2.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
texld r0, v0, s1
mad r1.xyz, r0, c5.xxyw, c5.zzww
dp3 r0.x, r1, r1
texld r2.xyz, v1, s0
mad r2.xyz, r2, c3.x, c3.y
dp3 r0.y, r2, c19
mul r3.xyz, r2, r0.y
rcp r0.x, r0.x
mul r0.x, r0, c3
mul r1.xy, r0.x, r1
add r1.z, r0.x, c3.y
mad r3.xyz, -r3, c19.w, c19
dp3 r0.x, r1, r3
mul r4.xyz, r1, c3.z
cmp r0.x, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r0.x, r4
mul r0.xy, r0.zwzw, c6
add r0.w, r0.x, r0.y
mul r0.w, r0, c0.z
dp3 r0.z, r2, c18
mul r0.xyz, r2, r0.z
mad r0.xyz, -r0, c18.w, c18
dp3 r2.w, r1, r0
add r1.w, r0, -c1.x
cmp r1.w, -r1, r0, c1.x
cmp r2.w, r2, c3.y, -c3.y
mad_pp r0.xyz, r0, -r2.w, r4
rcp r0.w, r1.w
mul r2.w, r0, c2.x
mad r3.xy, r2.w, r3, v0
mad r0.xy, r2.w, r0, v0
texld r5.zw, r0, s1
mul r0.xy, r5.zwzw, c6
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r4.w, -r0.x, c0.z, r0.z
texld r6.zw, r3, s1
mul r0.xy, r6.zwzw, c6
mad r0.z, -r3, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.x, -r0, c0.z, r0.z
add r3.x, -r4.w, c3.w
pow r0, r3.x, c2.z
add r5.y, -r5.x, c3.w
pow r3, r5.y, c2.z
mov r0.w, r0.x
mov r0.y, r3.x
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, c5.y, r0.y
add r0.w, r0.z, r0
add r0.y, r4.w, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c17
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c16
mad r3.xyz, -r0, c17.w, c17
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c16.w, c16
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c15
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c14
mad r3.xyz, -r0, c15.w, c15
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c14.w, c14
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c13
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c12
mad r3.xyz, -r0, c13.w, c13
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c12.w, c12
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c11
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c10
mad r3.xyz, -r0, c11.w, c11
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c10.w, c10
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c9
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c8
mad r3.xyz, -r0, c9.w, c9
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
mad r0.xyz, -r0, c8.w, c8
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
texld r5.zw, r3, s1
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
pow r3, r0.w, c2.z
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
dp3 r3.x, r2, c4
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r0.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c7
mul r0.xyz, r2, r0.x
mul r2.xyz, r2, r3.x
mad r0.xyz, -r0, c7.w, c7
dp3 r3.x, r1, r0
mad r2.xyz, -r2, c4.w, c4
dp3 r1.x, r2, r1
cmp r3.x, r3, c3.y, -c3.y
mad_pp r0.xyz, r0, -r3.x, r4
mad r0.xy, r2.w, r0, v0
cmp r1.x, r1, c3.y, -c3.y
mad_pp r1.xyz, r2, -r1.x, r4
texld r3.zw, r0, s1
mad r0.xy, r1, r2.w, v0
texld r2.zw, r0, s1
mul r0.xy, r2.zwzw, c6
mad r2.x, -r0.z, c2, r1.w
mul r1.xy, r3.zwzw, c6
add r0.z, r1.x, r1.y
mad_sat r0.z, -r0, c0, r2.x
add r1.y, -r0.z, c3.w
pow r2, r1.y, c2.z
add r0.x, r0, r0.y
mad r1.x, -r1.z, c2, r1.w
mad_sat r0.x, -r0, c0.z, r1
add r0.y, -r0.x, c3.w
pow r1, r0.y, c2.z
mov r0.y, r2.x
add r1.y, r0.w, r0
add r0.y, r0.z, -c2
cmp r0.y, -r0, r0.w, r1
add r0.z, r0.y, r1.x
add r0.x, r0, -c2.y
cmp r0.x, -r0, r0.y, r0.z
mad oC0, -r0.x, c6.z, c6.x
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
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_NoiseScale]
Vector 5 [_CameraDepthNormalsTexture_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_texcoord1 o2
dcl_position0 v0
dcl_texcoord0 v1
mad o1.xy, v1, c5, c5.zwzw
mul o2.xy, v1, c4
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Vector 0 [_ProjectionParams]
Float 1 [_NoSsaoDist]
Vector 2 [_Params]
SetTexture 0 [_RandomTexture] 2D 0
SetTexture 1 [_CameraDepthNormalsTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c3, 2.00000000, -1.00000000, 0.30000001, 1.00000000
def c4, 0.24484210, -0.16109620, 0.12893660, 2.00000000
def c5, 3.55539989, 0.00000000, -1.77769995, 1.00000000
def c6, 1.00000000, 0.00392157, 0.03846154, 0
def c7, -0.34654510, -0.16546510, -0.67467582, 2.00000000
def c8, 0.19328220, -0.36920989, -0.60605878, 2.00000000
def c9, 0.63891470, 0.11910140, -0.52712059, 2.00000000
def c10, -0.48002321, -0.18994731, 0.23988080, 2.00000000
def c11, 0.12803879, -0.56324202, 0.34192759, 2.00000000
def c12, -0.13650180, -0.25134161, 0.47093701, 2.00000000
def c13, -0.34797809, 0.47257659, -0.71968502, 2.00000000
def c14, 0.18413830, 0.16969930, -0.89362812, 2.00000000
def c15, 0.27929190, 0.24872780, -0.05185341, 2.00000000
def c16, -0.77863449, -0.38148519, -0.23912621, 2.00000000
def c17, 0.06039629, 0.24629000, 0.45011759, 2.00000000
def c18, -0.17956620, -0.35438621, 0.07924347, 2.00000000
def c19, 0.06262707, -0.21286429, -0.03671562, 2.00000000
def c20, 0.82427520, 0.02434147, 0.06049098, 2.00000000
def c21, -0.26347670, 0.52779227, -0.11074460, 2.00000000
def c22, -0.19156390, -0.49734211, -0.31296289, 2.00000000
def c23, -0.27525371, 0.07625949, -0.12734090, 2.00000000
def c24, 0.53779137, 0.31121889, 0.42686400, 2.00000000
def c25, 0.65801197, -0.43959719, -0.29193729, 2.00000000
def c26, -0.11084120, 0.21628390, 0.13362780, 2.00000000
def c27, 0.31496060, -0.12945810, 0.70445168, 2.00000000
def c28, -0.37908071, 0.14541450, 0.10060500, 2.00000000
def c29, -0.41522461, 0.13208570, 0.70367342, 2.00000000
def c30, 0.05916681, 0.22015060, -0.14303020, 2.00000000
def c31, 0.21966070, 0.90326369, 0.22546770, 2.00000000
dcl_texcoord0 v0.xy
dcl_texcoord1 v1.xy
texld r0, v0, s1
mad r1.xyz, r0, c5.xxyw, c5.zzww
dp3 r0.x, r1, r1
texld r2.xyz, v1, s0
mad r2.xyz, r2, c3.x, c3.y
dp3 r0.y, r2, c31
mul r3.xyz, r2, r0.y
rcp r0.x, r0.x
mul r0.x, r0, c3
mul r1.xy, r0.x, r1
add r1.z, r0.x, c3.y
mad r3.xyz, -r3, c31.w, c31
dp3 r0.x, r1, r3
mul r4.xyz, r1, c3.z
cmp r0.x, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r0.x, r4
mul r0.xy, r0.zwzw, c6
add r0.w, r0.x, r0.y
mul r0.w, r0, c0.z
dp3 r0.z, r2, c30
mul r0.xyz, r2, r0.z
mad r0.xyz, -r0, c30.w, c30
dp3 r2.w, r1, r0
add r1.w, r0, -c1.x
cmp r1.w, -r1, r0, c1.x
cmp r2.w, r2, c3.y, -c3.y
mad_pp r0.xyz, r0, -r2.w, r4
rcp r0.w, r1.w
mul r2.w, r0, c2.x
mad r3.xy, r2.w, r3, v0
mad r0.xy, r2.w, r0, v0
texld r5.zw, r0, s1
mul r0.xy, r5.zwzw, c6
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r4.w, -r0.x, c0.z, r0.z
texld r6.zw, r3, s1
mul r0.xy, r6.zwzw, c6
mad r0.z, -r3, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.x, -r0, c0.z, r0.z
add r3.x, -r4.w, c3.w
pow r0, r3.x, c2.z
add r5.y, -r5.x, c3.w
pow r3, r5.y, c2.z
mov r0.w, r0.x
mov r0.y, r3.x
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, c5.y, r0.y
add r0.w, r0.z, r0
add r0.y, r4.w, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c29
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c28
mad r3.xyz, -r0, c29.w, c29
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c28.w, c28
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c27
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c26
mad r3.xyz, -r0, c27.w, c27
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c26.w, c26
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c25
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c24
mad r3.xyz, -r0, c25.w, c25
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c24.w, c24
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c23
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c22
mad r3.xyz, -r0, c23.w, c23
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c22.w, c22
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c21
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c20
mad r3.xyz, -r0, c21.w, c21
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c20.w, c20
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c19
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c18
mad r3.xyz, -r0, c19.w, c19
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c18.w, c18
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c17
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c16
mad r3.xyz, -r0, c17.w, c17
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c16.w, c16
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c15
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c14
mad r3.xyz, -r0, c15.w, c15
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c14.w, c14
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c13
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c12
mad r3.xyz, -r0, c13.w, c13
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c12.w, c12
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c11
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c10
mad r3.xyz, -r0, c11.w, c11
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
texld r5.zw, r3, s1
mad r0.xyz, -r0, c10.w, c10
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
pow r3, r0.w, c2.z
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r4.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c9
mul r0.xyz, r2, r0.x
dp3 r0.w, r2, c8
mad r3.xyz, -r0, c9.w, c9
mul r0.xyz, r2, r0.w
dp3 r0.w, r1, r3
cmp r3.w, r0, c3.y, -c3.y
mad_pp r3.xyz, r3, -r3.w, r4
mad r3.xy, r2.w, r3, v0
mad r0.xyz, -r0, c8.w, c8
dp3 r0.w, r1, r0
cmp r0.w, r0, c3.y, -c3.y
mad_pp r0.xyz, r0, -r0.w, r4
texld r5.zw, r3, s1
mul r3.xy, r5.zwzw, c6
mad r3.z, -r3, c2.x, r1.w
add r0.w, r3.x, r3.y
mad_sat r5.x, -r0.w, c0.z, r3.z
mad r0.xy, r2.w, r0, v0
texld r3.zw, r0, s1
mul r0.xy, r3.zwzw, c6
add r0.w, -r5.x, c3
mad r0.z, -r0, c2.x, r1.w
add r0.x, r0, r0.y
pow r3, r0.w, c2.z
mad_sat r5.y, -r0.x, c0.z, r0.z
add r3.y, -r5, c3.w
pow r0, r3.y, c2.z
mov r0.y, r3.x
mov r0.w, r0.x
dp3 r3.x, r2, c4
add r0.y, r4.w, r0
add r0.x, r5, -c2.y
cmp r0.z, -r0.x, r4.w, r0.y
add r0.w, r0.z, r0
add r0.y, r5, -c2
cmp r0.w, -r0.y, r0.z, r0
dp3 r0.x, r2, c7
mul r0.xyz, r2, r0.x
mul r2.xyz, r2, r3.x
mad r0.xyz, -r0, c7.w, c7
dp3 r3.x, r1, r0
mad r2.xyz, -r2, c4.w, c4
dp3 r1.x, r2, r1
cmp r3.x, r3, c3.y, -c3.y
mad_pp r0.xyz, r0, -r3.x, r4
mad r0.xy, r2.w, r0, v0
cmp r1.x, r1, c3.y, -c3.y
mad_pp r1.xyz, r2, -r1.x, r4
texld r3.zw, r0, s1
mad r0.xy, r1, r2.w, v0
texld r2.zw, r0, s1
mul r0.xy, r2.zwzw, c6
mad r2.x, -r0.z, c2, r1.w
mul r1.xy, r3.zwzw, c6
add r0.z, r1.x, r1.y
mad_sat r0.z, -r0, c0, r2.x
add r1.y, -r0.z, c3.w
pow r2, r1.y, c2.z
add r0.x, r0, r0.y
mad r1.x, -r1.z, c2, r1.w
mad_sat r0.x, -r0, c0.z, r1
add r0.y, -r0.x, c3.w
pow r1, r0.y, c2.z
mov r0.y, r2.x
add r1.y, r0.w, r0
add r0.y, r0.z, -c2
cmp r0.y, -r0, r0.w, r1
add r0.z, r0.y, r1.x
add r0.x, r0, -c2.y
cmp r0.x, -r0, r0.y, r0.z
mad oC0, -r0.x, c6.z, c6.x
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
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Vector 4 [_CameraDepthNormalsTexture_ST]
"vs_3_0
dcl_position o0
dcl_texcoord0 o1
dcl_position0 v0
dcl_texcoord0 v1
mad o1.xy, v1, c4, c4.zwzw
dp4 o0.w, v0, c3
dp4 o0.z, v0, c2
dp4 o0.y, v0, c1
dp4 o0.x, v0, c0
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Vector 0 [_ProjectionParams]
Vector 1 [_TexelOffsetScale]
SetTexture 0 [_SSAO] 2D 0
SetTexture 1 [_CameraDepthNormalsTexture] 2D 1
"ps_3_0
dcl_2d s0
dcl_2d s1
def c2, 5.00000000, 0.00000000, 1.00000000, 4.00000000
defi i0, 4, 0, 1, 0
def c3, -0.09997559, 1.00000000, 0.00392157, -0.20000000
dcl_texcoord0 v0.xy
texld r0.x, v0, s0
texld r1, v0, s1
mul r3.x, r0, c2
mov_pp r3.y, c2.x
mov r3.z, c2.y
loop aL, i0
add r3.w, -r3.z, c2
add r3.z, r3, c2
mad r2.xy, r3.z, c1, v0
texld r0, r2, s1
mul r2.zw, r0, c3.xyyz
mul r0.zw, r1, c3.xyyz
add_pp r0.xy, r1, -r0
abs_pp r0.xy, r0
add_pp r0.x, r0, r0.y
add_pp r0.x, r0, c3
add r2.z, r2, r2.w
add r0.z, r0, r0.w
add r0.z, r0, -r2
abs r0.z, r0
mul r0.z, r0, c0
add r0.y, r0.z, c3.w
cmp r0.y, r0, c2, c2.z
cmp_pp r0.x, r0, c2.y, c2.z
mul_pp r0.x, r0, r0.y
mul_pp r0.y, r3.w, r0.x
texld r0.x, r2, s0
mul r0.x, r0, r0.y
add_pp r3.x, r3, r0
add_pp r3.y, r0, r3
endloop
mov r3.z, c2.y
loop aL, i0
add r3.w, -r3.z, c2
add r3.z, r3, c2
mad r2.xy, -r3.z, c1, v0
texld r0, r2, s1
mul r2.zw, r0, c3.xyyz
mul r0.zw, r1, c3.xyyz
add_pp r0.xy, r1, -r0
abs_pp r0.xy, r0
add_pp r0.x, r0, r0.y
add_pp r0.x, r0, c3
add r2.z, r2, r2.w
add r0.z, r0, r0.w
add r0.z, r0, -r2
abs r0.z, r0
mul r0.z, r0, c0
add r0.y, r0.z, c3.w
cmp r0.y, r0, c2, c2.z
cmp_pp r0.x, r0, c2.y, c2.z
mul_pp r0.x, r0, r0.y
mul_pp r0.y, r3.w, r0.x
texld r0.x, r2, s0
mul r0.x, r0, r0.y
add_pp r3.x, r3, r0
add_pp r3.y, r0, r3
endloop
rcp_pp r0.x, r3.y
mul_pp oC0, r3.x, r0.x
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
SubProgram "d3d9 " {
Bind "vertex" Vertex
Bind "texcoord" TexCoord0
Matrix 0 [glstate_matrix_mvp]
Matrix 4 [glstate_matrix_texture0]
Matrix 8 [glstate_matrix_texture1]
"vs_2_0
def c12, 0.00000000, 0, 0, 0
dcl_position0 v0
dcl_texcoord0 v1
mov r0.zw, c12.x
mov r0.xy, v1
dp4 oT0.y, r0, c5
dp4 oT0.x, r0, c4
dp4 oT1.y, r0, c9
dp4 oT1.x, r0, c8
dp4 oPos.w, v0, c3
dp4 oPos.z, v0, c2
dp4 oPos.y, v0, c1
dp4 oPos.x, v0, c0
"
}
}
Program "fp" {
SubProgram "d3d9 " {
Vector 0 [_Params]
SetTexture 0 [_MainTex] 2D 0
SetTexture 1 [_SSAO] 2D 1
"ps_2_0
dcl_2d s0
dcl_2d s1
dcl t0.xy
dcl t1.xy
texld r2, t1, s1
texld r1, t0, s0
pow_pp r0.x, r2.x, c0.w
mov_pp r0.w, r1
mul_pp r0.xyz, r1, r0.x
mov_pp oC0, r0
"
}
}
 }
}
Fallback Off
}