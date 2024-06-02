Shader "Ciconia Studio/Double Sided/Standard/Diffuse Bump" {
	Properties {
		_Color ("Diffuse Color", Vector) = (1,1,1,1)
		_SpecColor ("Specular Color", Vector) = (1,1,1,1)
		_SpecularIntensity ("Specular Intensity", Range(0, 2)) = 0.2
		_Glossiness ("Glossiness", Range(0, 1)) = 0.5
		_MainTex ("Diffuse map (Spec A)", 2D) = "white" {}
		_BumpMap ("Normal map", 2D) = "bump" {}
		_NormalIntensity ("Normal Intensity", Range(0, 2)) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		sampler2D _MainTex;
		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	Fallback "Diffuse"
}