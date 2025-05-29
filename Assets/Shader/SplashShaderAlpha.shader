Shader "uniSWF/Splash/SplashShaderAlpha" {
Properties {
 _MainTex ("Texture to blend", 2D) = "black" {}
 _Color ("Color", Color) = (1,1,1,1)
}
SubShader { 
 Tags { "QUEUE"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" }
  Blend SrcAlpha OneMinusSrcAlpha
  SetTexture [_MainTex] { ConstantColor [_Color] combine constant lerp(constant) constant }
  SetTexture [_MainTex] { combine previous * texture }
 }
}
}