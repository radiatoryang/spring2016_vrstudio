Shader "Custom/RobertWater"
{
	// "public variables" that get exposed to a Material
	Properties
	{
		// [_MainTex] is internal variable name
		// "Texture" is the label displayed in Unity Inspector
		// [2D] is the type of variable
		// "white" is the default value for this variable
		_MainTex ("Texture", 2D) = "white" {}
		_WaveFreq ("Wave Frequency Scalar", Float) = 10
		_WaveAmp ("Wave Amplitude Scalar", Float) = 0.5
	}
	// let's actually shading stuff...
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100 // "LOD" = "level of detail"

		// kind of like "one draw call"
		// most simple shaders are just 1 pass
		Pass
		{
			CGPROGRAM // CGPROGRAM is where shader code actually starts
			// "pragma" is Greek for "action"
			// pragma tells your code to do this "pre-compiler directive"
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			// ".cginc" files are just shader code
			// we're importing all this Unity code / functions to use
			#include "UnityCG.cginc"

			// "struct" is like a lightweight class
			// structs are usually more containers for data
			struct appdata
			{
				// "float4" is basically like a Vector4
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			// "v2f" == vertex 2 fragment
			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};


			sampler2D _MainTex;
			float4 _MainTex_ST; // S = Scale, T = Transform
			float _WaveFreq;
			float _WaveAmp;

			// VERTEX PROGRAM HAPPENS CONSTANTLY FOR EVERY VERTEX
			v2f vert (appdata v)
			{
				v2f o;
				// mul = "multiply", MVP = "Model View Projection"
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.vertex += float4( 0, sin(_Time.y * _WaveFreq + o.vertex.x) * _WaveAmp,0,0 ); // float4 goes "xyzw"
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			// FRAGMENT PROGRAM RUNS CONSTANTLY FOR EVERY PIXEL
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.y,0) );
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG // this is where CG/HLSL shader code *ends*
		}
	}
}
