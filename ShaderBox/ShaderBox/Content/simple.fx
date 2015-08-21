﻿float4x4 WorldViewProj;

float AmbientIntensity;
float4 AmbientColor;

float DiffuseIntensity;
float4 DiffuseColor;
float3 DiffuseDirection;

Texture2D Wood;
SamplerState WoodSampler = sampler_state
{
};

struct VertexInput
{
	float4 Position : SV_Position0;
	float3 Normal : NORMAL0;
	float2 TextureCoordinate : TEXCOORD0;
};

struct VertexOutput
{
	float4 Position : POSITION0;
	float3 Normal : NORMAL0;
	float2 TextureCoordinate : TEXCOORD0;
};

VertexOutput VertexShaderFunction(VertexInput input)
{
	VertexOutput output;
	output.Position = mul(input.Position, WorldViewProj);
	output.TextureCoordinate = input.TextureCoordinate;

	output.Normal = mul(input.Normal, WorldViewProj);
	// output.Normal = normalize(normal);

	return output;
}

float4 PixelShaderFunction(VertexOutput input) : COLOR0
{
	input.Normal = normalize(input.Normal);

	float4 texColor = Wood.Sample(WoodSampler, input.TextureCoordinate);
	float4 ambient = AmbientColor * AmbientIntensity;
	float4 diffuse = saturate(dot(-DiffuseDirection, input.Normal)) * DiffuseColor * DiffuseIntensity;
	return texColor * saturate(ambient + diffuse);
}

technique Default
{
	pass p0
	{
		VertexShader = compile vs_4_0_level_9_1 VertexShaderFunction();
		PixelShader = compile ps_4_0_level_9_1 PixelShaderFunction();
	}
}
