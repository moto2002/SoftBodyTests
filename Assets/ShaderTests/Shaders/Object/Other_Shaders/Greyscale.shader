﻿Shader "Gabe/GreyscaleMask" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_ColorStrength ("Color Strength", Range(1,4)) = 1
		_EmissionColor ("Emission Color", Color) = (1,1,1,1)
		_EmissionTex ("Emission (RGB)", 2D) = "white" {}
		_EmissionStrength ("Emission Strength", Range(0,4)) = 1
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
//		_Position ("World Position", Vector) = (0,0,0,0)
//		_Radius ("Sphere Radius", Range(0,10)) = 0
//		_Softness ("Sphere Softness", Range(0,10)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex, _EmissionTex;

		struct Input {
			float2 uv_MainTex;
			float2 uv_EmissionTex;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color, _EmissionColor;
		half _ColorStrength, _EmissionStrength;

		// Spherical Mask
		uniform float4 GlobalMask_Position;
		uniform half GlobalMask_Radius;
		uniform half GlobalMask_Softness;


		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)


		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			// Grayscale
			half grayscale = (c.r + c.g + c.b ) * 0.333;
			fixed3 c_g = fixed3(grayscale,grayscale,grayscale);
			// Emmision
			fixed4 e = tex2D(_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength;

			half d = distance(GlobalMask_Position,IN.worldPos);
			half sum = saturate((d - GlobalMask_Radius) /  - GlobalMask_Softness);
			fixed4 lerpcolor = lerp(fixed4(c_g,1),c * _ColorStrength,sum);
			fixed4 lerpEmission = lerp(fixed4(0,0,0,0), e , sum);

			o.Albedo = lerpcolor.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Emission = lerpEmission.rgb;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
